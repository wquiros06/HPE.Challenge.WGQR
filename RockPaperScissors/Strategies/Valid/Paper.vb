Imports Microsoft.VisualBasic
Namespace Strategies.Valid
    Public Class Paper
        Inherits Strategies.Strategy
        Public Overrides ReadOnly Property Shape As String
            Get
                Return "P"
            End Get
        End Property
    End Class
End Namespace