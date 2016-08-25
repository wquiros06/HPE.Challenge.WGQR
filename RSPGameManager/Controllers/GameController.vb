Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Description

Namespace Controllers
    Public Class GameController
        Inherits ApiController

        Private playerOne As RockPaperScissors.Player.Player
        Private playerTwo As RockPaperScissors.Player.Player

        ' GET: api/Game
        Public Function GetValues() As IList(Of RockPaperScissors.Game.Game)
            Return New List(Of RockPaperScissors.Game.Game)
        End Function

        ' GET: api/Game/5
        Public Function GetValue(ByVal id As Integer) As RockPaperScissors.Game.Game
            Return New RockPaperScissors.Game.Game(playerOne, playerTwo)
        End Function

        ' POST: api/Game
        <ResponseType(GetType(RockPaperScissors.Player.Player))>
        Public Function PostValue(<FromUri> playerOne As Models.Player, _
                                  <FromUri> playerTwo As Models.Player) _
                              As IHttpActionResult
            'Public Function PostValue(<FromBody()> ByVal namePlayerOne As String, <FromBody()> ByVal strategyPlayerOne As String, _
            '  <FromBody()> ByVal namePlayerTwo As String, <FromBody()> ByVal strategyPlayerTwo As String) _

            Dim thePlayerOne As New RockPaperScissors.Player.CurrentPlayer(playerOne.Name, playerOne.Strategy)
            Dim thePlayerTwo As New RockPaperScissors.Player.CurrentPlayer(playerTwo.Name, playerTwo.Strategy)

            Dim game As New RockPaperScissors.Game.Game(thePlayerOne, thePlayerOne)
            Dim theGameWinner As RockPaperScissors.Player.CurrentPlayer = game.Play()
            Dim winner As New Models.Player()
            With winner
                .Name = theGameWinner.Name
                .Strategy = theGameWinner.Choose
            End With
            Return CreatedAtRoute("DefaultApi", New With {.id = theGameWinner.Name}, theGameWinner)
        End Function

        ' PUT: api/Game/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Game/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace