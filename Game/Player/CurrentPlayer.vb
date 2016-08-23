Namespace Player
    Public Class CurrentPlayer
        Implements Player


        Private strategy As Strategies.Strategy
        Private playerName As String

        Sub New(playerName As String, playerStrategy As Char)
            strategy = Strategies.Strategy.Make(playerStrategy)
            Me.playerName = playerName
        End Sub

        Public Function Choose() As String Implements Player.Choose
            Return strategy.Shape
        End Function

        Public ReadOnly Property Name As String Implements Player.Name
            Get
                Return playerName.Trim().ToUpper()
            End Get
        End Property

        Public ReadOnly Property IsValid As Boolean Implements Player.IsValid
            Get
                Return True
            End Get
        End Property
    End Class
End Namespace