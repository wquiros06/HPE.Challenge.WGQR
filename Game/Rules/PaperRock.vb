Namespace Rules
    Public Class PaperRock
        Inherits Rule

        Public Overrides Function Execute() As Player.CurrentPlayer
            Return PlayerOneBeats()
        End Function
    End Class
End Namespace
