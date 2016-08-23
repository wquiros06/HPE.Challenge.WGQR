Imports RockPaperScissors
Namespace Game_Test
    <TestClass>
    Public Class PlayerOneChooseRockStrategy_Tests

        Private playerOne As Player.Player
        Private playerTwo As Player.Player
        Private expectedValue As Player.Player
        Private returnedValue As Player.Player
        Private game As Game.Game

        <TestInitialize>
        Sub Initialize()
            playerOne = New Player.CurrentPlayer("Wen", "R")
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
        Public Sub PlayerTwoChoosePaper_PlayerTwoBeats()
            playerTwo = New Player.CurrentPlayer("Andres", "P")
            expectedValue = playerTwo

            game = New Game.Game(playerOne, playerTwo)
            returnedValue = game.Play()

            Assert.AreEqual(expectedValue, returnedValue)
        End Sub

        <TestMethod>
        Public Sub PlayerTwoChooseScissors_PlayerOneBeats()
            expectedValue = playerOne

            playerTwo = New Player.CurrentPlayer("Andres", "S")
            game = New Game.Game(playerOne, playerTwo)
            returnedValue = game.Play()

            Assert.AreEqual(expectedValue, returnedValue)
        End Sub

        <TestMethod> _
        <ExpectedException(GetType(Strategies.Exceptions.IllegalStrategy))>
        Public Sub PlayerTwoChooseIllegalStrategy_ReturnsException()

            playerTwo = New Player.CurrentPlayer("Andres", "X")
            game = New Game.Game(playerOne, playerTwo)
            returnedValue = game.Play()
        End Sub
    End Class
End Namespace