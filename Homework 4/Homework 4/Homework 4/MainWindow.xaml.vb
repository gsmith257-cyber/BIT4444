Class MainWindow
    Private WithEvents socialNetwork As New Network()

    Private Sub PopulateComboBox()
        'clear
        UserComboBox.Items.Clear()

        For Each user In socialNetwork.GetNodeKeys()
            UserComboBox.Items.Add(user)
        Next
        UserComboBox.SelectedIndex = 0
    End Sub

    Private Sub PopulateListBox(username As String)
        'get user node
        Dim userNode As UserNode = socialNetwork.GetNode(username)

        'Call the BFS sub of the current node variable
        userNode.BFS()

        'Clear the Items collection of the connections list box
        FriendsListBox.Items.Clear()

        'Include a for each loop over the keys collection of the parent sorted list of the current node variable
        For Each key In userNode.ParentSortedList.Keys
            'declare a variable for current node as UserNode and assign to it the value of the parent sorted list with the current key as key
            Dim currentNode As UserNode = userNode.ParentSortedList(key)
            'Add to the Items collection of the connections list box
            FriendsListBox.Items.Add(key)
        Next
        'select the top item in the connection list box
        FriendsListBox.SelectedIndex = 0

    End Sub

    Private Sub PopulateNetworkTreeView()
        'clear
        NetworkTreeView.Items.Clear()

        'declare a selected node variable as UserNode and assign to it by calling the GetNode function of the social network variable and passing the ToString function of the SelectedItem of the user combo box to GetNode
        Dim selectedNode As UserNode = socialNetwork.GetNode(UserComboBox.SelectedItem.ToString())
        Dim node = socialNetwork.GetNode(UserComboBox.SelectedItem)
        'Declare a variable as a new sorted list of string keys and TeeViewItem type values
        Dim sortedList As New SortedList(Of String, TreeViewItem)
        'a for each loop over the Keys collection of the parent sorted list of the selected node variable. In this for each loop, add to the TVI sorted list the loop variable as the key and a New TreeViewItem as its corresponding value
        For Each key In selectedNode.ParentSortedList.Keys
            sortedList.Add(key, New TreeViewItem())
        Next
        'include a second for each loop over the Keys collection of the parent sorted list of the selected node variable
        For Each key In selectedNode.ParentSortedList.Keys
            'decleare a variable for current TVI variable as TreeViewItem and assign to it the value from TVI sorted list using the loop variable as the key
            Dim currentTVI As TreeViewItem = sortedList(key)
            'Declare a current node variable as UserNode and assign to it by calling the GetNode function of the social network variable and passing the loop variable to GetNode
            Dim currentNode As UserNode = socialNetwork.GetNode(key)
            'Declare a parent node variable as UserNode and assign to it the value from the parent sorted list of the selected node variable using the Name property of the current node variable as the key
            Dim parentNode As UserNode = selectedNode.ParentSortedList(currentNode.Name)
            'Declare a degree variable as integer and assign to it by calling the GetDegree function of the selected node variable and passing the current node variable to GetDegree
            Dim degree As Integer = selectedNode.GetDegree(currentNode)
            'Concatenate the Name property of the current node variable and the degree variable with a color character (":") in between them, and assign this concatenated string to the Header property of the current TVI variable
            currentTVI.Header = currentNode.Name & ":" & degree
            'Check if the parent node variable is Nothing
            If parentNode Is Nothing Then
                'If so, add the current TVI variable to the Items collection of the network tree view
                NetworkTreeView.Items.Add(currentTVI)
            Else
                'If not, declare a parent TVI variable as TreeViewItem and assign to it the value from the TVI sorted list using the Name property of the parent node variable as the key
                Dim parentTVI As TreeViewItem = sortedList(parentNode.Name)
                'Add the current TVI variable to the Items collection of the parent TVI variable
                parentTVI.Items.Add(currentTVI)
            End If
        Next
    End Sub

    Private Sub LoadWindows()
        'populate combo box
        PopulateComboBox()
        'populate list box
        PopulateListBox(UserComboBox.SelectedItem.ToString())

        'populate tree view
        PopulateNetworkTreeView()
    End Sub

    Private Sub UserComboBoxSelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles UserComboBox.SelectionChanged
        'populate list box
        PopulateListBox(UserComboBox.SelectedItem.ToString())

        'populate tree view
        PopulateNetworkTreeView()
    End Sub

    Private Sub ConnectionListBoxSelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles FriendsListBox.SelectionChanged
        'check if the Count property of the Items collection of the connection list box is greater than 0
        If FriendsListBox.Items.Count > 0 Then
            'declare a current node variable as UserNode and assign to it by calling the GetNode function of the social network variable and passing the ToString function of the SelectedItem property of the user combo box to GetNode
            Dim currentNode As UserNode = socialNetwork.GetNode(UserComboBox.SelectedItem.ToString())
            'declare a connection node variable as UserNode and assign to it by calling the GetNode function of the social network variable and passing the ToString function of the SelectedItem property of the connection list box to GetNode
            Dim connectionNode As UserNode = socialNetwork.GetNode(FriendsListBox.SelectedItem.ToString())
            'declare a degree variable as integer and assign to it by calling the GetDegree function of the current node variable and passing the connection node variable to GetDegree
            Dim degree As Integer = currentNode.GetDegree(connectionNode)
            'Concatenate the Name property of the connection node variable and the degree variable with a color character (":") in between them, and assign this concatenated string to the Header property of the current TVI variable
            DegreeBlock.Text = degree

        End If
    End Sub



End Class
