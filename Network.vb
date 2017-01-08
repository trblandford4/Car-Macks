'Sets up the network of nodes and arcs
'DEPENDENCIES: Map, Database, Node, Arc

Public Class Network
    Public CityList As New SortedList(Of String, Node) 'List of cities
    Public PathList As New SortedList(Of String, Arc) 'list of paths
    Public myMap As CarDatabase

    Public Event Changed(net As Network) 'Signals Changes in Network

    ' Constructor
    Public Sub New()

    End Sub

    ' Constructor
    Public Sub New(cities As List(Of String), map As CarDatabase)
        myMap = map
        CreateNetwork(cities, map)
    End Sub

    'Sets the demand for each city in the citylist
    Public Function GetDemand() As Integer
        Dim demand As Integer = 0

        For Each city In CityList.Values
            demand = demand + city.Demand
        Next

    End Function

    ' Return number of nodes in the network
    Public ReadOnly Property NodeCount As Integer
        Get
            Return CityList.Count
        End Get
    End Property
    'Adds the city to the cityList and incraments the demand if the city
    'is already in the list
    Public Function AddCity(city As String) As Boolean
        Try
            If CityList.ContainsKey(city) Then
                CityList(city).Demand = CityList(city).Demand + 1
            End If
            Dim newCity As New Node(city)
            For Each n In myMap.NodeList
                If n.ID = newCity.ID Then
                    newCity = n
                End If
            Next

            CityList.Add(city, newCity)
            RaiseEvent Changed(Me)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "City Exists")
        End Try
        Return False
    End Function
    'add city to the network with it's assigned id
    'returns the updated networks
    Public Shared Operator +(net As Network, id As String) As Network
        net.AddCity(id)
        Return net
    End Operator
    'Gets the count of cities in cityList
    Public ReadOnly Property CityCount As Integer
        Get
            Return CityList.Count
        End Get
    End Property
    'Gets the node using the cityid from cityList
    'Throws an exception if the cityid passed is not in cityList
    Public Function GetNode(id As String) As Node
        Try
            If Not CityList.ContainsKey(id) Then
                Throw New Exception("City " & id & " does not exist.")
            End If
            Return CityList(id)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "City error")
            Return Nothing
        End Try
    End Function
    'Gets the arc in the pathList for a specific arcId
    'throws an exception if the PathList does not contain the id key
    Public Function GetArc(id As String) As Arc
        Try
            If Not PathList.ContainsKey(id) Then
                Throw New Exception("Arc " & id & " does not exist.")
            End If
            Return PathList(id)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Arc error")
            Return Nothing
        End Try
    End Function

    ' Adds an arc to the network given tail and head node IDs and arc distance
    Public Function AddArc(tailID As String, headID As String, cost As Decimal) As Boolean
        If Not CityList.ContainsKey(tailID) Then
            AddCity(tailID)
        End If
        If Not CityList.ContainsKey(headID) Then
            AddCity(headID)
        End If
        Dim t As Node = GetNode(tailID)
        Dim h As Node = GetNode(headID)
        Dim a = New Arc(t, h)
        If PathList.ContainsKey(a.ID) Then
            MessageBox.Show("Arc " & a.ID & " already exists.")
            Return False
        Else
            PathList.Add(a.ID, a)
            t.ArcsOut.Add(a)
            h.ArcsIn.Add(a)
            a.Cost = cost
            Return True
        End If

    End Function

    ' Adds all nodes to the network from a NetworkMap
    ' Dependencies: AddNode
    Public Sub AddCities(cities As List(Of String))
        For i As Integer = 0 To cities.Count - 1
            AddCity(cities(i))
        Next
    End Sub

    ' Adds all arcs less than a connection radius to the network from a NetworkMap
    ' Dependencies: AddArc
    Public Sub AddConnections(map As CarDatabase)
        Dim i As Integer = 0
        For Each cityI In CityList.Values
            If cityI.ID = "BlacksburgIn" Then
                Continue For
            End If
            Dim j As Integer = 0
            For Each cityJ In CityList.Values
                If cityI.ID = "BlacksburgOut" And cityJ.ID = "BlacksburgIn" Then
                    Continue For
                End If
                If cityJ.ID = "BlacksburgOut" Then
                    Continue For
                End If

                If cityI.ID <> cityJ.ID Then
                    AddArc(cityI.ID, cityJ.ID, map.Distance(j, i))
                    j = j + 1
                End If
            Next
            i = i + 1
        Next
    End Sub

    ' Creates the network from a NetworkMap and a connection radius
    ' Dependencies: AddCities, AddConnections
    Public Sub CreateNetwork(cities As List(Of String), map As CarDatabase)
        CityList.Clear()
        AddCity("BlacksburgOut")
        AddCities(cities)
        AddCity("BlacksburgIn")
        AddConnections(map)

        ' Create origin node with only outflows.
        CityList("BlacksburgOut").Demand = 0

        AddArc("BlacksburgIn", "BlacksburgOut", 0)
    End Sub
    'Resets the form so the user can enter the data multiple timess
    Public Sub ResetNet()
        For Each city In CityList.Values
            city.ArcsIn.Clear()
            city.ArcsOut.Clear()
        Next
        CityList.Clear()
        For Each arc In PathList.Values
            arc = Nothing
        Next
        PathList.Clear()
    End Sub
End Class
