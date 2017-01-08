Public Class User
    Public Property ID As Integer
    Public Property username As String
    Public Property password As String

    Public Sub New()

    End Sub

    Public Sub New(uid As Integer)
        ID = uid
    End Sub
End Class
