Namespace Round
    Public Class Players
        Private players As IList(Of Player.Player)

        Public Sub New()
            players = New List(Of Player.Player)
        End Sub

        Public Sub New(players As IList(Of Player.Player))
            Me.players = players
        End Sub

        Public Sub Add(player As Player.Player)
            players.Add(player)
        End Sub

        Public Function AreThereEnough()
            Return Count() >= 2
        End Function

        Private Function Count() As Integer
            Return players.Count
        End Function

        Public Function GetKey() As Key.Key
            Dim newKey As Key.Key = ExtractKey()
            Remove(newKey)
            Return newKey
        End Function

        Private Function ExtractKey() As Key.Key
            Dim playerOne As Player.Player = players.ElementAt(0)
            Dim playerTwo As Player.Player = players.ElementAt(1)
            Return New Key.Key(playerOne, playerTwo)
        End Function

        Private Sub Remove(key As Key.Key)
            players.Remove(key.PlayerOne)
            players.Remove(key.PlayerTwo)
        End Sub
    End Class
End Namespace