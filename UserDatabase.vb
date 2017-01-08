Imports System.Data.OleDb
'connects to the access database to the model
'Dependenncies: Node, Car, Demand, DataSet
Public Class UserDatabase
    Public Property UserList As New List(Of User)   ' All Users

    Private myDataAdapter As OleDbDataAdapter 'Data Adaptor
    Private myConnectionStr As String 'Connection String
    Private myDataSet As New DataSet 'Operable DataSet
    Private mySQL As String ' SQL String

    Private Property ObjVal As Decimal

    'Constructor for this class
    Public Sub New()
        FillDataSet()
        FillUsers()
    End Sub

    'Data Adaptor
    Public Sub CreateDataAdaptor(tableName As String)
        myConnectionStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & Application.StartupPath & "\UserDatabase.accdb"
        mySQL = "SELECT * FROM " & tableName
        myDataAdapter = New OleDbDataAdapter(mySQL, myConnectionStr)
        myDataAdapter.Fill(myDataSet, tableName)
    End Sub
    'fills the dataset with the data from the tables in the database
    Public Sub FillDataSet()
        CreateDataAdaptor("Users")
    End Sub

    'returns the value in a table based on the column name and the table name and row number
    Public Function GetValue(i As Integer, colName As String, tableName As String) As String
        Return myDataSet.Tables(tableName).Rows(i)(colName).ToString
    End Function
    'Returns the count of the total rows in the specified table
    Public Function GetRowCount(tableName As String) As Integer
        Return myDataSet.Tables(tableName).Rows.Count
    End Function

    'fills the car list with cars
    Public Sub FillUsers()
        For j As Integer = 0 To GetRowCount("Users") - 1
            Dim id As Integer = GetValue(j, "ID", "Users")
            Dim u As New User(id)

            u.username = GetValue(j, "username", "Users")
            u.password = GetValue(j, "password", "Users")
            UserList.Add(u)
        Next
    End Sub
    'Updates the database
    Public Sub UpdateDatabase()
        Dim myCommandBuilder As New OleDbCommandBuilder(myDataAdapter)

        myDataAdapter.InsertCommand = myCommandBuilder.GetInsertCommand
        myDataAdapter.UpdateCommand = myCommandBuilder.GetUpdateCommand
        myDataAdapter.DeleteCommand = myCommandBuilder.GetDeleteCommand

        Dim updateCount As Integer = myDataAdapter.Update(myDataSet.Tables("Users"))
        MessageBox.Show(updateCount & " records updated.")
    End Sub

End Class
