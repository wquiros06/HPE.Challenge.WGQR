Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class rpsGameTest
    Dim wsTest As New WSRpsGameTest.WSRpsGameSoapClient

    '<TestMethod()>
    Public Sub playGameTest()
        Dim playerOne As New WSRpsGameTest.RPSUser With {.Name = "Armando"}
        playerOne.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerOne.GameStrategy.Strategy = "P"


        Dim playerTwo As New WSRpsGameTest.RPSUser With {.Name = "Dave"}
        playerTwo.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerTwo.GameStrategy.Strategy = "S"

        Dim game As New WSRpsGameTest.RPSGame
        game.UserOne = playerOne
        game.UserTwo = playerTwo
        Dim resultado = wsTest.playGame(game)
        Dim mensaje = resultado.RESULT_MESAGGE
        Dim nomWiner = resultado.Winner.Name
    End Sub

    '<TestMethod()>
    Public Sub playTournamentTest()
        Dim rounds As New List(Of WSRpsGameTest.RPSGame)
        Dim game1 As New WSRpsGameTest.RPSGame
        Dim playerOne1 As New WSRpsGameTest.RPSUser With {.Name = "Armando"}
        playerOne1.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerOne1.GameStrategy.Strategy = "P"
        Dim playerTwo1 As New WSRpsGameTest.RPSUser With {.Name = "Dave"}
        playerTwo1.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerTwo1.GameStrategy.Strategy = "S"
        game1.UserOne = playerOne1
        game1.UserTwo = playerTwo1
        rounds.Add(game1)

        Dim game2 As New WSRpsGameTest.RPSGame
        Dim playerOne2 As New WSRpsGameTest.RPSUser With {.Name = "Richard"}
        playerOne2.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerOne2.GameStrategy.Strategy = "R"
        Dim playerTwo2 As New WSRpsGameTest.RPSUser With {.Name = "Michael"}
        playerTwo2.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerTwo2.GameStrategy.Strategy = "S"
        game2.UserOne = playerOne2
        game2.UserTwo = playerTwo2
        rounds.Add(game2)

        Dim game3 As New WSRpsGameTest.RPSGame
        Dim playerOne3 As New WSRpsGameTest.RPSUser With {.Name = "Allen"}
        playerOne3.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerOne3.GameStrategy.Strategy = "S"
        Dim playerTwo3 As New WSRpsGameTest.RPSUser With {.Name = "Omer"}
        playerTwo3.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerTwo3.GameStrategy.Strategy = "P"
        game3.UserOne = playerOne3
        game3.UserTwo = playerTwo3
        rounds.Add(game3)

        Dim game4 As New WSRpsGameTest.RPSGame
        Dim playerOne4 As New WSRpsGameTest.RPSUser With {.Name = "John"}
        playerOne4.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerOne4.GameStrategy.Strategy = "R"
        Dim playerTwo4 As New WSRpsGameTest.RPSUser With {.Name = "Robert"}
        playerTwo4.GameStrategy = New WSRpsGameTest.RPSGameStrategy()
        playerTwo4.GameStrategy.Strategy = "P"
        game4.UserOne = playerOne4
        game4.UserTwo = playerTwo4
        rounds.Add(game4)


        Dim resultado = wsTest.playTournament(rounds.ToArray())
        Dim mensaje = resultado.RESULT_MESAGGE
        Dim nomWiner = resultado.Winner.Name
    End Sub


End Class