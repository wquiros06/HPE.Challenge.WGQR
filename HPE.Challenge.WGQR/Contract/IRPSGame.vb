Namespace Contract
    Public Interface IRPSGame
        Function playGame(game As Models.RPSGame) As Models.RPSGame
        Function playTournament(rounds As List(Of Models.RPSGame)) As Models.RPSGame
    End Interface
End Namespace
