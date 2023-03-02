Public Class Edge
    Public Property NodeList As List(Of Node)
    Public Property EdgeName As String

    Public Shared Function GetEdgeName(name1 As String, name2 As String)
        If name2 > name1 Then
            Return name1 & "--" & name2
        Else
            Return name2 & "--" & name1
        End If
    End Function

    Public Overrides Function ToString() As String
        Return GetEdgeName(NodeList(0).Name, NodeList(1).Name)
    End Function


End Class
