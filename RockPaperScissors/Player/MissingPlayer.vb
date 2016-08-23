Namespace Player
    Public Class MissingPlayer
        Implements Player

        Public Function Choose() As String Implements Player.Choose
            Throw New Exceptions.NoPlayer
        End Function

        Public ReadOnly Property Name As String Implements Player.Name
            Get
                Throw New Exceptions.NoPlayer
            End Get
        End Property

        Public ReadOnly Property IsValid As Boolean Implements Player.IsValid
            Get
                Return False
            End Get
        End Property
    End Class
End Namespace