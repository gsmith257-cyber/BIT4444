Public Class Arc

    Inherits Edge

    Public Property Tail As Node
    Public Property Head As Node

    Public Sub New(t As Node, h As Node)
        EdgeName = Edge.GetEdgeName(t.Name, h.Name)
        NodeList = New List(Of Node)
        NodeList.Add(t)
        NodeList.Add(h)
        Tail = t
        Head = h
        Tail.OutArcList.Add(Me)
        Head.InArcList.Add(Me)
    End Sub

    Public Sub New(a As Arc)
        EdgeName = a.EdgeName
        NodeList = a.NodeList
        Tail = a.Head
        Head = a.Tail
        Tail.OutArcList.Add(Me)
        Head.InArcList.Add(Me)
    End Sub

    Public Overrides Function ToString() As String
        Return Tail.Name & "->" & Head.Name
    End Function

End Class
