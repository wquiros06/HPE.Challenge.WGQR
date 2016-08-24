Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Players",
                Function(c) New With
                    {
                        .playerID = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .Strategy = c.String(),
                        .Score = c.Long(nullable := False),
                        .Self = c.String()
                    }) _
                .PrimaryKey(Function(t) t.playerID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Players")
        End Sub
    End Class
End Namespace
