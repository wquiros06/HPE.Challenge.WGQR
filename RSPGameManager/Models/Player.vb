Imports System.Globalization
Namespace Models
    Public Class Player
        Public Property playerID As Integer
        Public Property Name As String
        Public Property Strategy As String
        Public Property Score As Long

        Public Property Self() As String
            Get
                Return String.Format(CultureInfo.CurrentCulture,
                    "api/players/{0}", Me.playerID)
            End Get
            Set(value As String)

            End Set
        End Property
    End Class
End Namespace