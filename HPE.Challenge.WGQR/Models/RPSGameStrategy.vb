Imports System.ComponentModel.DataAnnotations

Public NotInheritable Class RPSGameStrategy
    Inherits ValidationAttribute


    Private Const ROCK As String = "R"
    Private Const PAPER As String = "P"
    Private Const SCISSORS As String = "S"

    Property Strategy As String

    Public Overrides Function IsValid(value As Object) As Boolean
        Dim resultado As Boolean = False
        If value.Equals(ROCK) Or value.Equals(PAPER) Or value.Equals(SCISSORS) Then
            resultado = True
        End If
        Return resultado
    End Function

End Class
