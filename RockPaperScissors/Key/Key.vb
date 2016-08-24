Namespace Key
    Public Class Key
        Private thePlayerOne As Player.Player
        Private thePlayerTwo As Player.Player

        Public Sub New(playerOne As Player.Player, playerTwo As Player.Player)
            Me.thePlayerOne = playerOne
            Me.thePlayerTwo = playerTwo
        End Sub

        Public Function Resolve() As Player.CurrentPlayer
            If PlayersAreValid() Then
                Return New Game.Game(thePlayerOne, thePlayerTwo).Play
            Else
                Return GetWinnerByDefault()
            End If
        End Function

        Private Function PlayersAreValid() As Boolean
            Return thePlayerOne.IsValid And thePlayerTwo.IsValid
        End Function

        Private Function GetWinnerByDefault() As Player.CurrentPlayer
            If SomePlayerIsValid() Then
                Return SearchValidPlayer()
            Else
                Throw New Exceptions.DesertKey
            End If
        End Function

        Private Function SomePlayerIsValid() As Boolean
            Return thePlayerOne.IsValid Or thePlayerTwo.IsValid
        End Function

        Private Function SearchValidPlayer() As Player.CurrentPlayer
            If thePlayerOne.IsValid Then
                Return thePlayerOne
            Else
                Return thePlayerTwo
            End If
        End Function

        Public ReadOnly Property PlayerOne As Player.Player
            Get
                Return thePlayerOne
            End Get
        End Property

        Public ReadOnly Property PlayerTwo As Player.Player
            Get
                Return thePlayerTwo
            End Get
        End Property
    End Class
End Namespace