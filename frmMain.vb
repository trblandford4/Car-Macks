Imports System.Net

Public Class frmMain
    Public myMap As New CarDatabase
    Public origNode As Node
    Public destNode As Node
    Private available As New List(Of Car)
    Private selected As New List(Of Car)
    Private cities As New List(Of String)
    Public shortestPath As New List(Of Arc)
    Public WithEvents myNet As New Network     ' Network of cities and connections

    'Adds the cars to the availiable list box when the form loades
    Private Sub frmNetwork_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCars()
        UpdateLists()
    End Sub

    ' Exits Application on Form Close
    Private Sub frmMain_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Application.Exit()
    End Sub

    'Loads Cars into the Available list
    Private Sub loadCars()
        For Each c In myMap.CarList
            available.Add(c)
        Next
    End Sub

    'Finds the shortest path and stores it
    'checks if the problem is infeasible and put it in a messagebox
    Private Sub FindBestPath()
        UpdateCities()
        myMap.GetDistanceData(cities)
        myNet = New Network(cities, myMap)
        Dim objval As Decimal
        Dim myOpt As New Optimization
        shortestPath = myOpt.GetShortestPath(myNet, myNet.CityList("BlacksburgOut").ID,
                                                                    myNet.CityList("BlacksburgIn").ID, objval)
        If shortestPath IsNot Nothing Then
            Dim params(shortestPath.Count) As String
            params(0) = "Blacksburg, VA"

            Dim i As Integer = 1
            For Each arc In shortestPath
                If arc Is shortestPath.First Then
                    Continue For
                End If
                If arc Is shortestPath.Last Then
                    params(i) = arc.Tail.ID
                    params(i + 1) = "Blacksburg, VA"
                Else
                    params(i) = arc.Tail.ID
                End If
                i = i + 1
            Next

            Dim url As String = "https://www.google.com/maps/dir/"
            For j As Integer = 0 To params.Count - 1
                lstPath.Items.Add(params(j))
                url &= params(j).Replace(" ", "+") & "/"

            Next
            wbGoogleMaps.Navigate(url)
            txtTotalDistance.Text = myOpt.GetTotalDistance() & " miles"
        Else
            MessageBox.Show("Problem infeasable")
        End If
    End Sub

    'Updates the list of cities
    Public Sub UpdateCities()
        For Each car In selected
            Dim location As String = car.City & ", " & car.State
            If Not cities.Contains(location) Then
                cities.Add(location)
            End If
        Next

        cities.Sort()
    End Sub

    ' =================================
    ' Update listboxes with asset lists
    ' =================================
    Sub UpdateLists()
        ' =======================================================
        ' Clear Available list box and populate with updated list
        ' =======================================================
        LstBoxAvailable.Items.Clear()

        For Each car In available
            LstBoxAvailable.Items.Add(car.AssetToText())
        Next
        ' =======================================================
        ' Clear Available list box and populate with updated list
        ' =======================================================
        lstBoxSelected.Items.Clear()
        For Each car In selected
            lstBoxSelected.Items.Add(car.AssetToText())
        Next

    End Sub


    ' ===================================
    ' Get Selected Available from listbox
    ' ===================================
    Function GetHilitedAvailable() As List(Of Car)
        Dim assets As New List(Of Car)
        For i = 0 To available.Count - 1
            If LstBoxAvailable.GetSelected(i) Then
                assets.Add(available(i))
            End If
        Next
        Return assets
    End Function

    ' ===================================
    ' Get Selected Available from listbox
    ' ===================================
    Function GetHilitedSelected() As List(Of Car)
        Dim assets As New List(Of Car)
        For i = 0 To selected.Count - 1
            If lstBoxSelected.GetSelected(i) Then
                assets.Add(selected(i))
            End If
        Next
        Return assets
    End Function

    ' =====================================
    ' Get index of Available Asset from list
    ' =====================================
    Function GetAvailableIndex(c As Car) As Integer
        For i = 0 To available.Count() - 1
            If available(i).Id = c.Id Then
                Return i
            End If
        Next
        Return -1
    End Function

    ' =====================================
    ' Get index of Selected Asset from list
    ' =====================================
    Function GetSelectedIndex(c As Car) As Integer
        For i = 0 To selected.Count() - 1
            If selected(i).Id = c.Id Then
                Return i
            End If
        Next
        Return -1
    End Function

    ' ==========================================================
    ' Move highlighted assets from available to selected listbox
    ' ==========================================================
    Sub AvailableToSelected()
        Dim selectedAssets = GetHilitedAvailable()
        If selected.Count >= 5 Then
            MessageBox.Show("You've already selected 5 cars and met the trucks capacity.")
        ElseIf selectedAssets.Count > 0 And selectedAssets.Count <= 5 And selected.Count + selectedAssets.Count <= 5 Then
            For Each asset In selectedAssets
                Dim i = GetAvailableIndex(asset)
                selected.Add(available(i))
                available.Remove(available(i))
            Next
            UpdateLists()
        Else
            MessageBox.Show("Please select 1 to 5 Cars.")
        End If
    End Sub

    ' ==========================================================
    ' Move highlighted assets from selected to available listbox
    ' ==========================================================
    Sub SelectedToAvailable()
        Dim selectedAssets = GetHilitedSelected()
        If selectedAssets.Count > 0 Then
            For Each asset In selectedAssets
                Dim i = GetSelectedIndex(asset)
                available.Add(selected(i))
                selected.Remove(selected(i))
            Next
            UpdateLists()
        Else
            MessageBox.Show("No Asset Selected")
        End If
    End Sub

    ' finds the best path and shows it on the map when the shortest path button is pushed
    Private Sub btnShortestPath_Click(sender As Object, e As EventArgs) Handles btnShortestPath.Click
        If Not CheckForInternetConnection() Then
            MessageBox.Show("It appears you are offline, please connect to the internet and try again.")
            Return
        End If

        If lstPath.Items.Count > 0 Then
            MessageBox.Show("Please reset.")
        ElseIf lstBoxSelected.Items.Count > 0 Then
            tslStatus.Text = "Loading..."
            FindBestPath()
            If lstPath.Items.Count > 0 Then
                tslStatus.Text = "Done."
            End If
        Else
            MessageBox.Show("No Cars Selected")
        End If

    End Sub

    'Returns the specified form
    Private Function GetForm(txt As String) As Form
        For Each frm In Application.OpenForms
            If frm.Text = txt Then
                Return frm
            End If
        Next
        Return Nothing
    End Function

    'Opens the child form
    Private Sub OpenChildForm(frm As Form)
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    'Adds the asset to the selected list
    Private Sub btnAddAsset_Click(sender As Object, e As EventArgs) Handles btnAddAsset.Click
        AvailableToSelected()
    End Sub
    'removes the asset from the selected box and put it in the availiable box
    Private Sub btnRemoveAsset_Click(sender As Object, e As EventArgs) Handles btnRemoveAsset.Click
        SelectedToAvailable()
    End Sub

    ' Shows Team Information Form
    Private Sub MapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MapToolStripMenuItem.Click
        frmMeetUs.ShowDialog()
    End Sub

    'Shows TSP Information Form
    Private Sub tsmArcs_Click(sender As Object, e As EventArgs) Handles tsmArcs.Click
        frmTSP.ShowDialog()
    End Sub

    'Shows About Us Form
    Private Sub tsmNodes_Click(sender As Object, e As EventArgs) Handles tsmNodes.Click
        frmAbout.ShowDialog()
    End Sub

    'Resets the project
    Private Sub btnResetNet_Click(sender As Object, e As EventArgs) Handles btnResetNet.Click
        reset()
    End Sub

    'Resets the project
    Private Sub reset()
        If Not myNet Is Nothing Then
            myNet.ResetNet()
            myNet = Nothing
            cities.Clear()
            available.Clear()
            selected.Clear()
            loadCars()
            UpdateLists()
            shortestPath.Clear()
            lstPath.Items.Clear()
            txtTotalDistance.Text = ""
            wbGoogleMaps.DocumentText = ""
            tslStatus.Text = "Status"
        Else
            MessageBox.Show("You've already reset.")
        End If
    End Sub

    'Updates the progress bar as map loads
    Private Sub wbGoogleMaps_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles wbGoogleMaps.ProgressChanged
        If e.MaximumProgress <> 0 And e.MaximumProgress >= e.CurrentProgress Then
            ProgressBar1.Value = Convert.ToInt32(100 * e.CurrentProgress / e.MaximumProgress)
        Else
            With ProgressBar1
                .Value = 100
                .Visible = True
            End With
        End If
    End Sub

    'Verifies web connection
    Public Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
End Class