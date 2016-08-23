Imports RockPaperScissors

<TestClass()> Public Class Start_Test
    Private playerOne As Player.Player
    Private playerTwo As Player.Player
    Private expectedResult As Player.CurrentPlayer
    Private obtainedResult As Player.CurrentPlayer
    Private knockoutStage As Round.KnockOutStage

    <TestInitialize>
    Sub Initialize()
        knockoutStage = New Round.KnockOutStage
    End Sub

    <TestMethod()> Public Sub PlayTournamentWithTwoPlayers_PlayerOneWins()
        playerOne = New Player.CurrentPlayer("Wen", "R")
        expectedResult = playerOne

        playerTwo = New Player.CurrentPlayer("Andres", "S")
        knockoutStage.Add(New Key.Key(playerOne, playerTwo))
        Dim tournament = New Tournament.Tournament(knockoutStage)
        tournament.Start()
        obtainedResult = tournament.Champion

        Assert.AreEqual(expectedResult, obtainedResult)
    End Sub

    <TestMethod()> Public Sub PlayTournamentWithTwoPlayers_PlayerOneIsNotPresent_PlayerTwoWins()
        playerTwo = New Player.CurrentPlayer("Andres", "S")
        expectedResult = playerTwo

        playerOne = New Player.MissingPlayer
        knockoutStage.Add(New Key.Key(playerOne, playerTwo))
        Dim tournament = New Tournament.Tournament(knockoutStage)
        tournament.Start()
        obtainedResult = tournament.Champion

        Assert.AreEqual(expectedResult, obtainedResult)
    End Sub

    <TestMethod()> Public Sub PlayTournamentWithFourPlayers_PlayerOneWins()
        playerOne = GetPlayer("Wen", "P")
        playerTwo = GetPlayer("Andres", "S")
        knockoutStage.Add(New Key.Key(playerOne, playerTwo))
        Dim playerThree As Player.Player = GetPlayer("Lila", "R")
        expectedResult = playerThree
        Dim playerFour As Player.Player = GetPlayer("Cani", "S")
        knockoutStage.Add(New Key.Key(playerThree, playerFour))

        Dim tournament = New Tournament.Tournament(knockoutStage)
        tournament.Start()
        obtainedResult = tournament.Champion

        Assert.AreEqual(expectedResult, obtainedResult)
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(Tournament.Exceptions.RepeatedPlayerName))>
    Public Sub PlayTournamentWithFourPlayers_PlayerRepeatedName()
        playerOne = GetPlayer("Wen", "P")
        playerTwo = GetPlayer("Andres", "S")
        knockoutStage.Add(New Key.Key(playerOne, playerTwo))
        Dim playerThree As Player.Player = GetPlayer("Lila", "R")
        Dim playerFour As Player.Player = GetPlayer("Lila", "S")
        knockoutStage.Add(New Key.Key(playerThree, playerFour))

        Dim tournament = New Tournament.Tournament(knockoutStage)
    End Sub

    Private Function GetPlayer(name As String, strategy As String) As Player.CurrentPlayer
        Return New Player.CurrentPlayer(name, strategy)
    End Function

End Class