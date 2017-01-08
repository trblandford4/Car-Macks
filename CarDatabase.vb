Imports System.Data.OleDb
'connects to the access database to the model
'Dependenncies: Node, Car, Demand, DataSet
Public Class CarDatabase
    Public Property CityList As New List(Of String)   ' All cities
    Public Property NodeList As New List(Of Node)    'create a list of nodes for each city
    Public Property CarList As New List(Of Car)      'create a list of cars
    Public Property NumCars As Integer              'stores the number of cars in the model
    Public Property demandList As New List(Of Demand)       'stores a list of demands for the cities
    Public Property Distance As Integer(,)

    Private myDataAdapter As OleDbDataAdapter 'Data Adaptor
    Private myConnectionStr As String 'Connection String
    Private myDataSet As New DataSet 'Operable DataSet
    Private mySQL As String ' SQL String

    Private Property ObjVal As Decimal

    'Constructor for this class
    Public Sub New()
        FillDataSet()
        FillAllLists()
    End Sub

    Public Sub GetDistanceData(Cities As List(Of String))
        ' TODO: Generate distance array from Google Maps Data
        Dim googlemaps As New GoogleMapsAPI
        Distance = googlemaps.GetDistances(Cities)
    End Sub

    'Data Adaptor
    Public Sub CreateDataAdaptor(tableName As String)
        myConnectionStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & Application.StartupPath & "\TravelingSalesmanDatabase.accdb"
        mySQL = "SELECT * FROM " & tableName
        myDataAdapter = New OleDbDataAdapter(mySQL, myConnectionStr)
        myDataAdapter.Fill(myDataSet, tableName)
    End Sub
    'fills the dataset with the data from the tables in the database
    Public Sub FillDataSet()
        CreateDataAdaptor("Cars")
        CreateDataAdaptor("Nodes")
    End Sub
    'Fills the node list with the cities
    Public Sub FillNodeList(cities As List(Of String))
        Dim scale = 1.0
        For i As Integer = 0 To GetRowCount("Nodes") - 1
            Dim id = GetValue(i, "City", "Nodes")
            Dim r As New Node(id)
            r.ID = GetValue(i, "City", "Nodes")
            r.Xcoord = CInt(GetValue(i, "XCoord", "Nodes")) * scale
            r.Ycoord = CInt(GetValue(i, "Ycoord", "Nodes")) * scale
            NodeList.Add(r)
        Next
    End Sub
    'Fill the carslist with cars
    'Fills the citylist with cities
    'Fills the nodelist with nodess
    Public Sub FillAllLists()
        FillCars()
        FillCities()
        FillNodeList(CityList)
    End Sub
    'returns the value in a table based on the column name and the table name and row number
    Public Function GetValue(i As Integer, colName As String, tableName As String) As String
        Return myDataSet.Tables(tableName).Rows(i)(colName).ToString
    End Function
    'Returns the count of the total rows in the specified table
    Public Function GetRowCount(tableName As String) As Integer
        Return myDataSet.Tables(tableName).Rows.Count
    End Function
    'add's the cities to city list
    Public Sub FillCities()
        For j As Integer = 0 To GetRowCount("Cars") - 1
            CityList.Add(GetValue(j, "City", "Cars"))
        Next
    End Sub
    'fills the car list with cars
    Public Sub FillCars()
        For j As Integer = 0 To GetRowCount("Cars") - 1
            Dim carId As Integer = GetValue(j, "ID", "Cars")
            Dim c As New Car(carId)

            c.Type = GetValue(j, "Type", "Cars")
            c.City = GetValue(j, "City", "Cars")
            c.State = GetValue(j, "State", "Cars")
            c.Manufacturer = GetValue(j, "Manufacturer", "Cars")
            c.Year = GetValue(j, "Year", "Cars")
            CarList.Add(c)
        Next

        NumCars = CarList.Count
    End Sub
    'Returns the car based on the car type
    'This function retives the cars at a given Node
    Public Function GetCar(c As String) As Car
        For Each k In CarList
            If k.Type = c Then
                Return k
            End If
        Next
        Return Nothing
    End Function
    'Updates the database
    Public Sub UpdateDatabase()
        Dim myCommandBuilder As New OleDbCommandBuilder(myDataAdapter)

        myDataAdapter.InsertCommand = myCommandBuilder.GetInsertCommand
        myDataAdapter.UpdateCommand = myCommandBuilder.GetUpdateCommand
        myDataAdapter.DeleteCommand = myCommandBuilder.GetDeleteCommand

        Dim updateCount As Integer = myDataAdapter.Update(myDataSet.Tables("Cars"))
        MessageBox.Show(updateCount & " records updated.")
    End Sub

End Class
