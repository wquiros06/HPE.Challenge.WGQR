Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Games",
                Function(c) New With
                    {
                        .gameID = c.Int(nullable := False, identity := True)
                    }) _
                .PrimaryKey(Function(t) t.gameID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Games")
        End Sub
    End Class
End Namespace
