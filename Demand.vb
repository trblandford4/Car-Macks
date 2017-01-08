
Public Class Demand
    Public Property OrderID As Integer
    Public Property CarID As Integer
    Public Property NodeId As Integer
    Public Property Amount As Integer

    'default constructor
    Public Sub New()

    End Sub

    Public Sub New(Order As Integer, Car As Integer, NID As Integer)
        OrderID = Order
        CarID = Car
        NodeId = NID
    End Sub
End Class
