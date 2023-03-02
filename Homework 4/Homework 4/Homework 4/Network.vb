Public Class Network
    Private Property NodeSortedList As New SortedList(Of String, UserNode)
    Private Property EdgeSortedList As New SortedList(Of String, Edge)
    Private Property ArcSortedList As New SortedList(Of String, Arc)

    Public Event Finished()

    Public Sub GenerateNetwork()
        Dim connections(,) As String = NetworkData.GetRandomConnections(20)
        For i As Integer = 0 To connections.GetUpperBound(0)
            GetArc(connections(i, 0), connections(i, 1))
        Next
        RaiseEvent Finished()
    End Sub

    ' adds new node if it does not exists and return node
    Public Function GetNode(user As String) As UserNode
        If Not NodeSortedList.ContainsKey(user) Then
            NodeSortedList.Add(user, New UserNode(user))
        End If
        Return NodeSortedList(user)
    End Function

    ' adds new edge if it does not exists and returns edge
    Public Function GetArc(user1 As String, user2 As String) As Arc
        Dim arcName As String = Edge.GetEdgeName(user1, user2)
        If Not ArcSortedList.ContainsKey(arcName) Then
            ArcSortedList.Add(arcName, New Arc(GetNode(user1), GetNode(user2)))
        End If
        Return ArcSortedList(arcName)
    End Function

    ' returns keys collection of NodeSortedList
    Public Function GetNodeKeys()
        Return NodeSortedList.Keys
    End Function

    ' returns values collection of NodeSortedList
    Public Function GetNodeValues()
        Return NodeSortedList.Values
    End Function

    'constructor
    Public Sub New()
        GenerateNetwork()
    End Sub
End Class
