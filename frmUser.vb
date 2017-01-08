Public Class frmUser
    Public myMap As New UserDatabase
    Private users As List(Of User)

    ' Authenticate user and load main application form
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim auth As Boolean = False
        For Each user In users
            If txtUser.Text = user.username And txtPass.Text = user.password Then
                auth = True
            End If
        Next

        If auth = True Then
            Me.Hide()
            frmMain.ShowDialog()
        Else
            MessageBox.Show("Username/Password are Incorrect.")
        End If
    End Sub

    ' Fill user list
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        users = myMap.UserList
    End Sub

    ' Close Application
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class