Imports Microsoft.VisualBasic
Namespace Strategies
    Public MustInherit Class Strategy
        MustOverride ReadOnly Property Shape As String

        Public Shared Function Make(playerMovement As Char) As Strategy
            Select Case (playerMovement)
                Case "R"
                    Return New Valid.Rock
                Case "P"
                    Return New Valid.Paper
                Case "S"
                    Return New Valid.Scissors
                Case Else
                    Return New Invalid.Illegal
            End Select
        End Function
    End Class
End Namespace