Imports RockPaperScissors

Namespace Player_Test
    <TestClass>
    Public Class Choose_Tests

        Private player As Player.Player

        <TestMethod>
        Public Sub PlayerUsePaperStrategy_Choose_P()
            Dim expectedValue As String = "P"

            player = New Player.CurrentPlayer("Lila", "P")
            Dim returnedValue As String = player.Choose

            Assert.AreEqual(expectedValue, returnedValue)
        End Sub
        <TestMethod>
        Public Sub PlayerUseRockStrategy_Choose_R()
            Dim expectedValue As String = "R"

            Dim player As Player.Player = New Player.CurrentPlayer("Lila", "R")
            Dim returnedValue As String = player.Choose

            Assert.AreEqual(expectedValue, returnedValue)
        End Sub
        <TestMethod>
        Public Sub PlayerUseScissorsStrategy_Choose_S()
            Dim expectedValue As String = "S"

            player = New Player.CurrentPlayer("Lila", "S")
            Dim returnedValue As String = player.Choose

            Assert.AreEqual(expectedValue, returnedValue)
        End Sub

        <TestMethod> _
        <ExpectedException(GetType(Strategies.Exceptions.IllegalStrategy))>
        Public Sub PlayerUseIllegalStrategy_ReturnsException()
            Dim player As Player.Player = New Player.CurrentPlayer("Lila", "x")
            Dim returnedValue As String = player.Choose
        End Sub
    End Class
End Namespace