Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports RSPGameManager.Models

Namespace Controllers
    Public Class PlayersController
        Inherits System.Web.Http.ApiController

        Private db As New RSPGameManagerContext

        ' GET: api/Players
        Function GetPlayers() As IQueryable(Of Player)
            Return db.Players
        End Function

        ' GET: api/Players/5
        <ResponseType(GetType(Player))>
        Function GetPlayer(ByVal id As Integer) As IHttpActionResult
            Dim player As Player = db.Players.Find(id)
            If IsNothing(player) Then
                Return NotFound()
            End If

            Return Ok(player)
        End Function

        ' GET: api/Player/10
        Function GetTopPlayers(ByVal top As Integer) As IQueryable(Of Player)
            Dim theTopPlayers = (From thePlayer In db.Players
                                 Order By thePlayer.Score Descending
                                 Take top).AsQueryable()
            Return theTopPlayers
        End Function

        ' PUT: api/Players/5
        <ResponseType(GetType(Void))>
        Function PutPlayer(ByVal id As Integer, ByVal player As Player) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = player.playerID Then
                Return BadRequest()
            End If

            db.Entry(player).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (PlayerExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Players
        <ResponseType(GetType(Player))>
        Function PostPlayer(ByVal player As Player) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Players.Add(player)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = player.playerID}, player)
        End Function

        ' DELETE: api/Players/5
        <ResponseType(GetType(Player))>
        Function DeletePlayer(ByVal id As Integer) As IHttpActionResult
            Dim player As Player = db.Players.Find(id)
            If IsNothing(player) Then
                Return NotFound()
            End If

            db.Players.Remove(player)
            db.SaveChanges()

            Return Ok(player)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function PlayerExists(ByVal id As Integer) As Boolean
            Return db.Players.Count(Function(e) e.playerID = id) > 0
        End Function
    End Class
End Namespace