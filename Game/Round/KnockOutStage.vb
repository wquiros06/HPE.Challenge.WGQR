Namespace Round
    Public Class KnockOutStage
        Private theKnockoutStage As IList(Of Key.Key)

        Sub New()
            theKnockoutStage = New List(Of Key.Key)
        End Sub

        Sub New(knockoutStage As IList(Of Key.Key))
            theKnockoutStage = knockoutStage
        End Sub

        Public ReadOnly Property Brackets As IList(Of Key.Key)
            Get
                Return theKnockoutStage
            End Get
        End Property

        Public Sub Add(bracket As Key.Key)
            theKnockoutStage.Add(bracket)
        End Sub

        Public Function Count() As Integer
            Return theKnockoutStage.Count
        End Function
    End Class
End Namespace