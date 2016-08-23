Namespace Tournament
Public Class Tournament
        Private knockOutStage As Round.KnockOutStage

        Sub New(knockOutStage As Round.KnockOutStage)
            ValidateTournament(knockOutStage)
        End Sub

        Public Sub Start()
            If NumberOfKeysIsPowerOfTwo() Then
                GetChampion(Me.knockOutStage)
            Else
                Throw New Exceptions.NotEnoughPlayers
            End If
        End Sub

        Private Sub ValidateTournament(knockOutStage As Round.KnockOutStage)
            If ArePlayersNameDiferent(knockOutStage) Then
                Me.knockOutStage = knockOutStage
            Else
                Throw New Exceptions.RepeatedPlayerName
            End If
        End Sub

        Private Function ArePlayersNameDiferent(knockoutStage As Round.KnockOutStage) As Boolean
            Dim players As IDictionary(Of String, String) = New Dictionary(Of String, String)
            For Each bracket In knockoutStage.Brackets
                If bracket.PlayerOne.IsValid Then
                    If players.ContainsKey(bracket.PlayerOne.Name) Then
                        Return False
                    Else
                        players.Add(bracket.PlayerOne.Name, bracket.PlayerOne.Name)
                    End If
                End If

                If bracket.PlayerTwo.IsValid Then
                    If players.ContainsKey(bracket.PlayerTwo.Name) Then
                        Return False
                    Else
                        players.Add(bracket.PlayerTwo.Name, bracket.PlayerTwo.Name)
                    End If
                End If
            Next
            Return True
        End Function

        Private Function NumberOfKeysIsPowerOfTwo() As Boolean
            Dim keys As Integer = NumberOfBrackets(Me.knockOutStage)
            Return keys & (keys - 1)
        End Function

        Private Function NumberOfBrackets(knockOutStage As Round.KnockOutStage) As Integer
            Return knockOutStage.Count
        End Function

        Private Sub GetChampion(knockOutStage As Round.KnockOutStage)
            If IsFinalGame(knockOutStage) Then
                Champion = knockOutStage.Brackets.First.Resolve
            Else
                Dim newRound As Round.KnockOutStage = New Round.Round(knockOutStage).Execute
                GetChampion(newRound)
            End If
        End Sub

        Private Function IsFinalGame(knockOutStage As Round.KnockOutStage) As Boolean
            Return NumberOfBrackets(knockOutStage) = 1
        End Function

        Public Property Champion As Player.CurrentPlayer
    End Class
End Namespace