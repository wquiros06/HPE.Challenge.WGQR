Namespace Round
    Public Class Round
        Private theKnockOutStage As KnockOutStage

        Public Sub New(brackets As KnockOutStage)
            Me.theKnockOutStage = brackets
        End Sub

        Public Function Execute() As KnockOutStage
            Dim winners As Players = ResolveRound()
            Return NextRound(winners)
        End Function

        Private Function ResolveRound() As Players
            Dim winners As New Players
            For Each key As Key.Key In theKnockOutStage.Brackets
                Try
                    winners.Add(key.Resolve)
                Catch ex As Key.Exceptions.DesertKey
                    winners.Add(New Player.MissingPlayer)
                End Try
            Next
            Return winners
        End Function

        Private Function NextRound(players As Players) As KnockOutStage
            Dim brackets As KnockOutStage = New KnockOutStage
            While players.AreThereEnough()
                brackets.Add(players.GetKey())
            End While
            Return brackets
        End Function
    End Class
End Namespace