Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports RSPGameManager.Models

Namespace Controllers
    Public Class HomeController
        Inherits System.Web.Mvc.Controller

        Private db As New RSPGameManagerContext

        ' GET: Home
        Function Index() As ActionResult
            Return View(db.Players.ToList())
        End Function

        ' GET: Home/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim player As Player = db.Players.Find(id)
            If IsNothing(player) Then
                Return HttpNotFound()
            End If
            Return View(player)
        End Function

        ' GET: Home/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Home/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="playerID,Name,Strategy,Score,Self")> ByVal player As Player) As ActionResult
            If ModelState.IsValid Then
                db.Players.Add(player)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(player)
        End Function

        ' GET: Home/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim player As Player = db.Players.Find(id)
            If IsNothing(player) Then
                Return HttpNotFound()
            End If
            Return View(player)
        End Function

        ' POST: Home/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="playerID,Name,Strategy,Score,Self")> ByVal player As Player) As ActionResult
            If ModelState.IsValid Then
                db.Entry(player).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(player)
        End Function

        ' GET: Home/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim player As Player = db.Players.Find(id)
            If IsNothing(player) Then
                Return HttpNotFound()
            End If
            Return View(player)
        End Function

        ' POST: Home/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim player As Player = db.Players.Find(id)
            db.Players.Remove(player)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
