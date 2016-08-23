Imports System.ComponentModel.DataAnnotations

Namespace Models
    Public Class RPSUser

        <Key()> _
        Property ID As Long

        <Display(Name:="Name")> _
        <Required()> _
        Property Name As String

        Property GameStrategy As RPSGameStrategy
    End Class
End Namespace
