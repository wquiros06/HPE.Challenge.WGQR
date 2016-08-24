Imports System.Globalization
Imports RockPaperScissors.Game
Imports RockPaperScissors.Player

Namespace Models
    Public Class Game
        Inherits RockPaperScissors.Game.Game

        Public Sub New(playerOne As Player, playerTwo As Player)
            MyBase.New(playerOne, playerTwo)
        End Sub


        Public Property Self() As String
            Get
                Return String.Format(CultureInfo.CurrentCulture,
                   "api/game/{0}", Me.gameID)
            End Get
            Set(value As String)

            End Set
        End Property
    End Class
End Namespace