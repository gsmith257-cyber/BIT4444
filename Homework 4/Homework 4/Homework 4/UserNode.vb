Public Class UserNode
    Inherits Node
    Public Property ParentSortedList As New SortedList(Of String, UserNode)

    Public Sub New(name As String)
        MyBase.New(name)
    End Sub

    Public Sub BFS()
        'clear the parent sorted list
        ParentSortedList.Clear()
        'Declare a user list as a new list of UserNode and declare a list of explored nodes as a new list of UserNode. Add the class instance variable Me to this user list
        Dim userList As New List(Of UserNode)
        Dim exploredNodes As New List(Of UserNode)
        userList.Add(Me)
        'Add to the parent sorted list the Name property (from the base class) as key and Nothing as its corresponding value
        ParentSortedList.Add(Name, Nothing)
        'Include a do while loop with the condition that the Count property of user list is greater than 0
        While userList.Count > 0
            'declare a variable for parent node as UserNode and assign to it the first item in user list (using 0 as the index number). Remove the first item from the user list (using RemoveAt with 0 as the index number). Add the parent node variable to the explored list
            Dim parentNode As UserNode = userList(0)
            userList.RemoveAt(0)
            exploredNodes.Add(parentNode)
            'Include a For Each loop (still inside the do while loop) over the OutArcList property of the parent node variable. Inside the for each loop, declare a child node variable as UserNode and assign to it the Head property of the for each loop variable.
            For Each arc As Arc In parentNode.OutArcList
                Dim childNode As UserNode = arc.Head
                'Include an if statement with the condition that the child node variable is not in the explored list. If the condition is true, add the child node variable to the user list and add the child node variable to the parent sorted list with the Name property of the parent node variable as key and the parent node variable as value
                If Not exploredNodes.Contains(childNode) Then
                    userList.Add(childNode)
                    ParentSortedList.Add(childNode.Name, parentNode)
                End If
            Next
        End While
    End Sub

    Public Function GetDegree(user As UserNode) As Integer
        'check if the parent sorted list does not contain the Name property of the input argument in its Keys collection using an if then structure, and return -1 inside the if then structure
        If Not ParentSortedList.ContainsKey(user.Name) Then
            Return -1
        End If
        Dim degree As Integer = 0
        'declare a variable for current node as UserNode and assign to it the input argument
        Dim currentNode As UserNode = user
        'Include a do while loop with the condition that the current variable is not the class instance variable
        While currentNode IsNot Me
            'increment the degree variable by 1
            degree += 1
            'assign to the current variable the value of the parent sorted list with the Name property of the current variable as key
            currentNode = ParentSortedList(currentNode.Name)
        End While
        'return the degree variable
        Return degree
    End Function

End Class
