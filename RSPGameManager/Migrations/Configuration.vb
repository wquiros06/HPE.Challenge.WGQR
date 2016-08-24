Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports RSPGameManager.Models

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of Models.RSPGameManagerContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As Models.RSPGameManagerContext)
            context.Players.AddOrUpdate(New Models.Player With {.Name = "Richard", _
                                                                .Strategy = "R", _
                                                                .Score = 3})
            context.Players.AddOrUpdate(New Models.Player With {.Name = "Dave", _
                                                                .Strategy = "S", _
                                                                .Score = 1})
        End Sub

    End Class

End Namespace
