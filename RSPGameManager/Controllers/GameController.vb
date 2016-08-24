Imports System.Net
Imports System.Web.Http
Imports RockPaperScissors

Namespace Controllers
    Public Class GameController
        Inherits ApiController

        ' GET: api/Game
        Public Function GetValues() As IEnumerable(Of String)
            Return New String() {"value1", "value2"}
        End Function

        ' GET: api/Game/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/Game
        Public Sub PostValue(nombrePlayerOne As String, strategyPlayerOne As String, nombrePlayerTwo As String,
                             strategyPlayerTwo As String)
            Dim playerOne As New Player.CurrentPlayer(nombrePlayerOne, strategyPlayerOne)
            Dim playerTwo As New Player.CurrentPlayer(nombrePlayerTwo, strategyPlayerTwo)
            Dim game As New Game.Game(playerOne, playerTwo)
            game.Play()

        End Sub

        ' PUT: api/Game/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Game/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace