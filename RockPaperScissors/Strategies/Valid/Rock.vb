Imports Microsoft.VisualBasic
Namespace Strategies.Valid
    Public Class Rock
        Inherits Strategies.Strategy

        Public Overrides ReadOnly Property Shape As String
            Get
                Return "R"
            End Get
        End Property
    End Class
End Namespace