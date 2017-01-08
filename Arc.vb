' Implements the Arc Class
' Dependencies: Node
Public Class Arc

    Public Property ID As String            ' Holds arc ID
    Public Property Tag As String           ' Holds any message attached to a node
    Public Property Tail As Node            ' Tail node of the arc
    Public Property Head As Node            ' Head node of the arc
    Public Property Capacity As Decimal     ' Capacity of the arc
    Public Property Cost As Decimal         ' Cost of the arc
    Public Property Flow As Decimal         ' Flow amount on the arc

    ' Default constructor
    Public Sub New()

    End Sub

    ' Constructor for a given tail and head node
    Public Sub New(t As Node, h As Node)
        Try
            If t Is Nothing Or h Is Nothing Then
                Throw New Exception("Tail or head node does not exist.")
            End If
            Tail = t
            Head = h
            ID = t.ID & " -> " & h.ID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Arc error")
        End Try
    End Sub

    ' Returns arc information
    Public Overrides Function ToString() As String
        Dim str As String = "Arc (" & Tail.ID & ", " & Head.ID & "): Capa: " &
            Capacity & ", Cost: " & Cost & ", Flow: " & Flow
        Return str
    End Function

End Class
