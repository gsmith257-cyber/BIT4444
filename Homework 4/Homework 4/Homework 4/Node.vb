Public Class Node
    Public Property Name As String
    Public Property OutArcList As New List(Of Arc)
    Public Property InArcList As New List(Of Arc)

    Public Sub New(n As String)
        Name = n
    End Sub

    ' given input node and edge, checks if edge contains node
    ' if so, returns the other (friend) node
    Public Shared Function GetFriend(n As Node, e As Edge) As Node
        Try
            If Not e.NodeList.Contains(n) Then
                Throw New Exception("Node and edge are not connected.")
            End If
            Dim i As Integer = Math.Abs(e.NodeList.IndexOf(n) - 1)
            Return e.NodeList(i)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Operator +(n As Node, e As Edge) As Node
        Return GetFriend(n, e)
    End Operator

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
