Public Class Car
    Public Property Id As Integer
    Public Property Type As String
    Public Property Manufacturer As String
    Public Property Color As String
    Public Property Year As String
    Public Property Price As Double
    Public Property City As String
    Public Property State As String

    'Constructor
    Public Sub New()

    End Sub

    Public Sub New(CarID As Integer)
        Id = CarID
    End Sub

    ' ============
    ' Print Car
    ' ============
    Public Function AssetToText() As String
        Return Year & " " & Manufacturer & " " & Type
    End Function
End Class
