Namespace Rules
    Public MustInherit Class Rule
        Private Shared thePlayerOne As Player.Player
        Private Shared thePlayerTwo As Player.Player

        Public Shared Function Make(playerOne As Player.Player, playerTwo As Player.Player) As Rule
            thePlayerOne = playerOne
            thePlayerTwo = playerTwo

            If StrategiesAreEquals(playerOne.Choose, playerTwo.Choose) Then
                Return GetTieRule()
            Else
                Return GetRule()
            End If
        End Function

        Private Shared Function StrategiesAreEquals(playerOneStrategy As String, playerTwoStrategy As String) As Boolean
            Return String.Equals(playerOneStrategy, playerTwoStrategy)
        End Function

        Private Shared Function GetTieRule() As Rule
            Return New Tie()
        End Function

        Private Shared Function GetRule() As Rule
            Dim theStrategies As String = FormatStrategies()
            Select Case theStrategies
                Case "RP"
                    Return New RockPaper
                Case "RS"
                    Return New RockScissors
                Case "PR"
                    Return New PaperRock
                Case "PS"
                    Return New PaperScissors
                Case "SR"
                    Return New ScissorsRock
                Case "SP"
                    Return New ScissorsPaper
            End Select
        End Function

        Private Shared Function FormatStrategies() As String
            Return thePlayerOne.Choose + thePlayerTwo.Choose
        End Function

        Protected Function PlayerOneBeats() As Player.Player
            Return thePlayerOne
        End Function

        Protected Function PlayerTwoBeats() As Player.Player
            Return thePlayerTwo
        End Function

        MustOverride Function Execute() As Player.CurrentPlayer
    End Class
End Namespace