Imports Microsoft.SolverFoundation.Common
Imports Microsoft.SolverFoundation.Services
Imports Microsoft.SolverFoundation.Solvers

' Implements the optimization procedures for the Vehicle Routing Problem with Capacity Constraints
' Dependencies: Network
Public Class Optimization
    'Creates a list that stores
    Private decisionList As New SortedList(Of String, Integer)
    Private functionList As New SortedList(Of String, Integer)

    ' A Value to Store total distance of solution to return
    Private totalDistance As Integer

    ' Default Constructor
    Public Sub New()

    End Sub

    ' Builds and solves the VRP model for a given network
    ' Returns the shortest path as a list of arcs from the origin to the destination if problem is feasible
    'DEPENDENCIES: Network, Database, Arc, Car, Node, frmNetwork, frmMap
    ' TODO: Improve Capacity constraint
    Public Function GetShortestPath(net As Network, origin As String,
                                    destination As String,
                                    ByRef objval As Decimal) As List(Of Arc)


        Dim myModel As New SimplexSolver


        Dim str As String = "Decision Variables:" & vbCrLf
        'Set the variables 
        For Each arc In net.PathList.Values
            Dim dbName As String = "b-" & arc.ID
            decisionList.Add(dbName, 0)
            myModel.AddVariable(dbName, decisionList(dbName))
            myModel.SetBounds(decisionList(dbName), 0, 1)
            myModel.SetIntegrality(decisionList(dbName), True)
            str &= dbName & vbCrLf

            Dim dcName As String = "c-" & arc.ID
            decisionList.Add(dcName, 0)
            myModel.AddVariable(dcName, decisionList(dcName))
            myModel.SetBounds(decisionList(dcName), 0, 3)
            str &= dcName & vbCrLf
        Next

        str &= "Flow const" & vbCrLf
        'Creating Conservation of Flow Constraints
        For Each city In net.CityList.Values
            Dim fName As String = "flow:" & "-" & city.ID
            functionList.Add(fName, 0)
            myModel.AddRow(fName, functionList(fName))

            str &= fName & " :: "
            'Inflows
            For Each arc In city.ArcsIn
                Dim dName As String = "c-" & arc.ID
                myModel.SetCoefficient(functionList(fName), decisionList(dName), 1)
                str &= " + " & dName
            Next

            'Outflows
            For Each arc In city.ArcsOut
                Dim dName As String = "c-" & arc.ID
                myModel.SetCoefficient(functionList(fName), decisionList(dName), -1)
                str &= " - " & dName
            Next

            'RHS
            myModel.SetBounds(functionList(fName), city.Demand, city.Demand)
            str &= " = " & city.Demand & vbCrLf
        Next


        str &= "Conn const" & vbCrLf
        'Connecting Constraint
        For Each arc In net.PathList.Values
            Dim fname As String = "conn" & arc.ID
            functionList.Add(fname, 0)
            str &= fname & " :: "
            myModel.AddRow(fname, functionList(fname))
            myModel.SetCoefficient(functionList(fname), decisionList("c-" & arc.ID), 1)
            myModel.SetCoefficient(functionList(fname), decisionList("b-" & arc.ID), -30)
            myModel.SetBounds(functionList(fname), Rational.NegativeInfinity, 0)
            str &= " + c-" & arc.ID & " -30 b-" & arc.ID & " <= 0" & vbCrLf
        Next

        str &= "Indegree const" & vbCrLf
        'Indegree Constraint
        For Each city In net.CityList.Values
            Dim fname As String = "ind - " & city.ID
            functionList.Add(fname, 0)
            str &= fname & "indegree :: "

            myModel.AddRow(fname, functionList(fname))
            For Each arc In city.ArcsIn
                myModel.SetCoefficient(functionList(fname), decisionList("b-" & arc.ID), 1)
                str &= " + b-" & arc.ID
            Next
            myModel.SetBounds(functionList(fname), 1, 1)
            str &= " == 1" & vbCrLf

            str &= fname & "outdegree :: "
            For Each arc In city.ArcsOut
                myModel.SetCoefficient(functionList(fname), decisionList("b-" & arc.ID), 1)
                str &= " + b-" & arc.ID
            Next
            myModel.SetBounds(functionList(fname), 1, 1)
            str &= " == 1" & vbCrLf
        Next

        ' =================================================================================
        ' Form for Debugging Purposes
        ' =================================================================================
        'Dim frm As New frmCheck
        'frm.RichTextBox1.Text = str
        'frm.Show()
        ' =======================================================s==========================
        '
        ' =================================================================================

        'Creating Objective
        Dim oid As Integer
        functionList.Add("obj", 0)
        myModel.AddRow("obj", functionList("obj"))
        For Each arc In net.PathList.Values
            myModel.SetCoefficient(functionList("obj"), decisionList("b-" & arc.ID), arc.Cost)
        Next

        ' Adding objective to the models

        myModel.AddGoal(functionList("obj"), 0, True)
        myModel.Solve(New SimplexSolverParams())


        If myModel.LpResult <> 2 Then
            'Solve Heuristically
            Dim pathList As New List(Of Arc)
            Dim totalDemand = 0

            For Each city In net.CityList.Values
                totalDemand = totalDemand + city.Demand
            Next

            Dim min As Integer = 1000000
            For Each arc In net.CityList(origin).ArcsOut
                If arc.Cost < min Then
                    min = arc.Cost
                End If
            Next
            totalDistance = totalDistance + min
            Dim nextCity As New Node
            For Each arc In net.CityList(origin).ArcsOut
                If arc.Cost = min Then
                    pathList.Add(arc)
                    net.CityList(origin).ArcsIn.Clear()
                    nextCity = arc.Head
                End If
            Next
            Dim visited As New List(Of Node)
            visited.Add(net.CityList("BlacksburgIn"))
            While totalDemand - 1 > 1
                Dim minCost As Integer = 1000000
                For Each arc In nextCity.ArcsOut
                    If visited.Contains(arc.Head) Then
                        Continue For
                    End If

                    If arc.Cost < minCost Then
                        minCost = arc.Cost
                    End If
                Next
                For Each arc In nextCity.ArcsOut
                    If arc.Cost = minCost Then
                        pathList.Add(arc)
                        visited.Add(arc.Tail)
                        nextCity = arc.Head
                    End If
                Next
                totalDistance = totalDistance + minCost
                totalDemand = totalDemand - nextCity.Demand
            End While

            For Each arc In nextCity.ArcsOut
                If arc.Head.ID = "BlacksburgIn" Then
                    pathList.Add(arc)
                    totalDistance = totalDistance + arc.Cost
                End If
            Next

            Return pathList
        Else
            ' getting the solution
            objval = myModel.GetValue(functionList("obj")).ToDouble
            For Each arc In net.PathList.Values
                arc.Flow = myModel.GetValue(decisionList("b-" & arc.ID)).ToDouble
            Next

            ' create the list of arcs from origin node to destination node
            Dim totalCost As Decimal = 0
            Dim shortestPath As New List(Of String)
            Dim node As Node = net.GetNode(origin)
            Do While node.ID <> destination
                For Each arc In node.ArcsOut
                    If arc.Flow > 0.001 Then
                        node = arc.Head
                        totalCost += arc.Cost
                        shortestPath.Add(arc.ID & " (" & arc.Cost & ")")
                        Exit For
                    End If
                Next
            Loop
            Return Nothing
        End If

    End Function

    Public Function GetTotalDistance() As Integer
        Return totalDistance
    End Function

End Class