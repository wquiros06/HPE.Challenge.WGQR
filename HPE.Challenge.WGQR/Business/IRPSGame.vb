Namespace Business
    Public Interface IRPSGame
        Function playGame(ByRef game As Models.RPSGame) As Models.RPSGame
        Function playTournament(rounds As IList(Of Models.RPSGame)) As Models.RPSGame
    End Interface
End Namespace
