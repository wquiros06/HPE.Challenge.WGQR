Namespace Rules
    Public Class RockScissors
        Inherits Rule

        Public Overrides Function Execute() As Player.CurrentPlayer
            Return PlayerOneBeats()
        End Function
    End Class
End Namespace
