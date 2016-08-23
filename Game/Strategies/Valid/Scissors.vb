Imports Microsoft.VisualBasic
Namespace Strategies.Valid
    Public Class Scissors
        Inherits Strategies.Strategy
        Public Overrides ReadOnly Property Shape As String
            Get
                Return "S"
            End Get
        End Property
    End Class
End Namespace
