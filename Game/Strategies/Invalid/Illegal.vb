Imports Microsoft.VisualBasic
Namespace Strategies.Invalid
    Public Class Illegal
        Inherits Strategies.Strategy

        Public Overrides ReadOnly Property Shape As String
            Get
                Throw New Exceptions.IllegalStrategy
            End Get
        End Property
    End Class
End Namespace