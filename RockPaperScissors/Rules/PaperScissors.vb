Namespace Rules
    Public Class PaperScissors
        Inherits Rule

        Public Overrides Function Execute() As Player.CurrentPlayer
            Return PlayerTwoBeats()
        End Function
    End Class
End Namespace
