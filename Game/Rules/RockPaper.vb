Namespace Rules
    Public Class RockPaper
        Inherits Rule

        Public Overrides Function Execute() As Player.CurrentPlayer
            Return PlayerTwoBeats()
        End Function
    End Class
End Namespace
