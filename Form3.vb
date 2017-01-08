Public Class Form
    Public testData As New Database
    Dim origin As Node
    Dim destination As Node
    Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each c In testData.Carlist
            LstBoxAvailable.Items.Add(c.CarName)

        Next

        MessageBox.Show(testData.Carlist.Count)


    End Sub

    Private Sub FindBestPath()
        Dim distance As Integer
        Dim TravelingOptimization As Optimization = New Optimization(testData)

        Dim c As New Car
        Dim karList As New List(Of Car)

        For Each Item In lstBoxSelected.Items

            karList.Add(testData.GetCar(Item))
        Next

        TravelingOptimization.GetTotalDistance(testData, lstBoxSelected.Text, distance)


    End Sub

    Private Sub LstBoxAvailable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstBoxAvailable.SelectedIndexChanged

    End Sub

    Private Sub cmdPlaceOrder_Click(sender As Object, e As EventArgs) Handles cmdPlaceOrder.Click
        MessageBox.Show(testData.Carlist.Count)
    End Sub

    Private Sub lstBoxSelected_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBoxSelected.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
