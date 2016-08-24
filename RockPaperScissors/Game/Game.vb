Namespace Game
    Public Class Game
        Public Property gameID As Integer
        Private playerOne As Player.Player
        Private playerTwo As Player.Player

        Public Sub New(playerOne As Player.Player, playerTwo As Player.Player)
            Me.playerOne = playerOne
            Me.playerTwo = playerTwo
        End Sub

        Public Function Play() As Player.CurrentPlayer
            Dim rule As Rules.Rule = Rules.Rule.Make(playerOne, playerTwo)
            Return rule.Execute
        End Function
    End Class
End Namespace