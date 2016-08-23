Namespace Business
    Public Class RPSGame
        Implements IRPSGame, IDisposable

        Private roundsTemp As New List(Of Models.RPSGame)

        Public Function playGame(ByRef rpsgame As Models.RPSGame) As Models.RPSGame Implements IRPSGame.playGame
            Dim winner As Models.RPSUser = Nothing
            Dim loser As Models.RPSUser = Nothing
            If rpsgame.UserOne IsNot Nothing AndAlso rpsgame.UserTwo IsNot Nothing Then
                If Not rpsgame.UserOne.GameStrategy.IsValid(rpsgame.UserOne.GameStrategy.Strategy) Then
                    Throw New Exception("Player one's strategy is not valid")
                End If
                If Not rpsgame.UserTwo.GameStrategy.IsValid(rpsgame.UserTwo.GameStrategy.Strategy) Then
                    Throw New Exception("Player two's strategy is not valid")
                End If

                If rpsgame.UserOne.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.R)) Then

                    If rpsgame.UserTwo.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.R)) Then
                        winner = rpsgame.UserOne
                        loser = rpsgame.UserTwo
                    ElseIf rpsgame.UserTwo.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.P)) Then
                        winner = rpsgame.UserTwo
                        loser = rpsgame.UserOne
                    ElseIf rpsgame.UserTwo.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.S)) Then
                        winner = rpsgame.UserOne
                        loser = rpsgame.UserTwo
                    End If

                ElseIf rpsgame.UserOne.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.P)) Then

                    If rpsgame.UserTwo.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.P)) Then
                        winner = rpsgame.UserOne
                        loser = rpsgame.UserTwo
                    ElseIf rpsgame.UserTwo.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.R)) Then
                        winner = rpsgame.UserOne
                        loser = rpsgame.UserTwo
                    ElseIf rpsgame.UserTwo.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.S)) Then
                        winner = rpsgame.UserTwo
                        loser = rpsgame.UserOne
                    End If

                ElseIf rpsgame.UserOne.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.S)) Then

                    If rpsgame.UserTwo.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.S)) Then
                        winner = rpsgame.UserOne
                        loser = rpsgame.UserTwo
                    ElseIf rpsgame.UserTwo.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.R)) Then
                        winner = rpsgame.UserTwo
                        loser = rpsgame.UserOne
                    ElseIf rpsgame.UserTwo.GameStrategy.Strategy.Equals([Enum].GetName(GetType(GameStrategy), GameStrategy.P)) Then
                        winner = rpsgame.UserOne
                        loser = rpsgame.UserTwo
                    End If

                End If
            Else
                Throw New Exception("There aren't players")
            End If
            rpsgame.RESULT_MESAGGE = String.Format("Player {0} beats player {1}", winner.Name, loser.Name)
            rpsgame.Winner = winner
            rpsgame.Loser = loser
            Return rpsgame
        End Function

        Private Property _instance As IRPSGame
        Public Property Instance As IRPSGame
            Get
                Return New RPSGame()
            End Get
            Set(value As IRPSGame)
                _instance = value
            End Set
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

        'Public Function playTournament(rounds As IList(Of Models.RPSGame)) As Models.RPSGame Implements IRPSGame.playTournament
        '    'Dim finalPlay As New Models.RPSGame

        '    Dim roundPlayed As New Models.RPSGame
        '    Dim currentGame As New Models.RPSGame
        '    Dim isFinalGame As Boolean = False
        '    If rounds.Count = 1 Then
        '        Return playGame(rounds.FirstOrDefault())
        '    ElseIf rounds.Count Mod 2 = 0 Then
        '        While rounds.Count > 0 And Not isFinalGame
        '            For Each round In rounds
        '                roundPlayed = playGame(round)

        '                If currentGame.UserOne Is Nothing Then
        '                    currentGame.UserOne = roundPlayed.Winner
        '                ElseIf currentGame.UserTwo Is Nothing Then
        '                    currentGame.UserTwo = roundPlayed.Winner
        '                    roundsTemp.Add(currentGame)
        '                    currentGame = New Models.RPSGame
        '                Else
        '                    currentGame.UserOne = roundPlayed.Winner
        '                End If
        '            Next
        '            Dim newRound As List(Of Models.RPSGame) = roundsTemp
        '            roundsTemp = New List(Of Models.RPSGame)
        '            If newRound.Count = 1 Then
        '                isFinalGame = True
        '            End If
        '            currentGame = playTournament(newRound)
        '        End While
        '    Else
        '        Throw New Exception("Number of rounds is not enough to play a tournament")
        '    End If
        '    Return currentGame
        'End Function

        Public Function playTournament(rounds As IList(Of Models.RPSGame)) As Models.RPSGame Implements IRPSGame.playTournament
            Dim isFinalGame As Boolean = False
            Dim newRound As New List(Of Models.RPSGame)
            Dim finalGame As New Models.RPSGame
            If rounds.Count Mod 2 = 0 Then
                Dim totalRounds = rounds.Count / 2
                Dim countRound = 0
                While countRound < totalRounds
                    Dim nextPlayerOne As Models.RPSUser = playGame(rounds.Item(countRound)).Winner
                    Dim nextPlayerTwo As Models.RPSUser = playGame(rounds.Item(countRound + 1)).Winner
                    Dim newGame As New Models.RPSGame With {.UserOne = nextPlayerOne,
                                                            .UserTwo = nextPlayerTwo}
                    newRound.Add(newGame)
                    countRound = countRound + 1
                End While
                finalGame = playTournament(newRound)
            Else
                Throw New Exception("Number of rounds is not enough to play a tournament")
            End If
            Return finalGame
        End Function
    End Class
End Namespace
