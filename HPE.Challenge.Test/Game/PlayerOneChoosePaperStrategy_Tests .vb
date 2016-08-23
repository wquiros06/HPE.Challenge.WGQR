Imports RockPaperScissors
Namespace Game_Test
    <TestClass>
    Public Class PlayerOneChoosePaperStrategy_Tests

        Private playerOne As Player.Player
        Private playerTwo As Player.Player
        Private expectedValue As Player.Player
        Private returnedValue As Player.Player
        Private game As Game.Game

        <TestInitialize>
        Sub Initialize()
            playerOne = New Player.CurrentPlayer("Wen", "P")
        End Sub

        <TestMethod>
        Public Sub PlayerTwoChooseRock_PlayerOneBeats()
            expectedValue = playerOne

            playerTwo = New Player.CurrentPlayer("Andres", "R")
            game = New Game.Game(playerOne, playerTwo)
            returnedValue = game.Play()

            Assert.AreEqual(expectedValue, returnedValue)
        End Sub

        <TestMethod>
        Public Sub PlayerTwoChoosePaper_PlayerOneBeats()
            expectedValue = playerOne

            playerTwo = New Player.CurrentPlayer("Andres", "P")
            game = New Game.Game(playerOne, playerTwo)
            returnedValue = game.Play()

            Assert.AreEqual(expectedValue, returnedValue)
        End Sub

        <TestMethod>
        Public Sub PlayerTwoChooseScissors_PlayerTwoBeats()
            playerTwo = New Player.CurrentPlayer("Andres", "S")
            expectedValue = playerTwo

            game = New Game.Game(playerOne, playerTwo)
            returnedValue = game.Play()

            Assert.AreEqual(expectedValue, returnedValue)
        End Sub
    End Class
End Namespace