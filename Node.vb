' Implements the Node class
' Dependencies: Arc
Public Class Node

    Public Property ID As String                ' Holds node ID
    Public Property Tag As String               ' Holds any message attached to a node
    Public Property Xcoord As Integer
    Public Property Ycoord As Integer
    Public Property ArcsIn As List(Of Arc)      ' All arcs comint into the node
    Public Property ArcsOut As List(Of Arc)     ' All arcs leaving a node
    Public Property Demand As Integer           ' Demand at the node

    ' Default Constructor
    Public Sub New()

    End Sub

    ' Constructor given a node ID
    Public Sub New(nodeID As String)
        ID = nodeID
        ArcsIn = New List(Of Arc)
        ArcsOut = New List(Of Arc)
        Demand = 1
    End Sub

    ' Returns node information
    Public Overrides Function ToString() As String
        Dim str As String = "Node " & ID & ": Demand: " & Demand
        Return str
    End Function

End Class