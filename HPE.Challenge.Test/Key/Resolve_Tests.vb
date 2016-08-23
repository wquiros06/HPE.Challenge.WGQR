Imports RockPaperScissors
Namespace Key_Tests
    <TestClass()>
    Public Class Resolve_Tests
        Private playerOne As Player.Player
        Private playerTwo As Player.Player
        Private expectedResult As Player.CurrentPlayer
        Private obtainedResult As Player.CurrentPlayer

        <TestMethod()>
        Public Sub SomePlayerWins()
            playerOne = New Player.CurrentPlayer("Wen", "R")
            playerTwo = New Player.CurrentPlayer("Andres", "S")

            Dim winner As Player.CurrentPlayer = New Key.Key(playerOne, playerTwo).Resolve
            Assert.IsTrue(winner.IsValid)
        End Sub

        <TestMethod()>
        Public Sub PlayerOneDoesNotPlay_PlayerTwoWins()
            playerOne = New Player.MissingPlayer

            playerTwo = New Player.CurrentPlayer("Andres", "S")
            expectedResult = playerTwo

            obtainedResult = New Key.Key(playerOne, playerTwo).Resolve

            Assert.AreEqual(expectedResult, obtainedResult)
        End Sub

        <TestMethod()>
        Public Sub PlayerTwoDoesNotPlay_PlayerOneWins()
            playerOne = New Player.CurrentPlayer("Andres", "S")
            expectedResult = playerOne

            playerTwo = New Player.MissingPlayer
            obtainedResult = New Key.Key(playerOne, playerTwo).Resolve

            Assert.AreEqual(expectedResult, obtainedResult)
        End Sub

        <TestMethod()> _
        <ExpectedException(GetType(Key.Exceptions.DesertKey))>
        Public Sub NoPlayers_ReturnException()
            playerOne = New Player.MissingPlayer
            playerTwo = New Player.MissingPlayer

            obtainedResult = New Key.Key(playerOne, playerTwo).Resolve
        End Sub
    End Class
End Namespace