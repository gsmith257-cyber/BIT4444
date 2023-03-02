Public Class NetworkData
    Public Shared Function GetConnections() As String(,)
        Return {{"Alice", "Celine"},
                {"Alice", "Frank"},
                {"Blake", "Alice"},
                {"Celine", "Blake"},
                {"Celine", "Frank"},
                {"Daniel", "Alice"},
                {"Daniel", "Henry"},
                {"Emma", "Alice"},
                {"Emma", "Celine"},
                {"Emma", "Henry"},
                {"Frank", "Blake"},
                {"Frank", "Daniel"},
                {"Frank", "Henry"},
                {"Grace", "Alice"},
                {"Grace", "Daniel"},
                {"Grace", "Frank"},
                {"Henry", "Celine"},
                {"Henry", "Grace"},
                {"Henry", "Iris"},
                {"Iris", "Alice"},
                {"Iris", "Celine"}}
    End Function

    Public Shared Function GetRandomConnections(n As Integer) As String(,)
        Dim userList As New List(Of String)
        For i As Integer = 0 To n - 1
            Dim userName As String = "user" & i
            If i < 10 Then
                userName = "user0" & i
            End If
            userList.Add(userName)
        Next

        Dim connections(n - 2, 1) As String
        Dim k As Integer = 0
        Do While userList.Count > 1
            connections(k, 0) = userList(GetRandom(0, userList.Count - 1))
            userList.Remove(connections(k, 0))
            connections(k, 1) = userList(GetRandom(0, userList.Count - 1))
            k += 1
        Loop
        Return connections
    End Function

    Public Shared Function GetRandom(Min As Integer, Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
End Class
