Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class rpsGame
    Inherits System.Web.Services.WebService
    Implements Contract.IRPSGame

    Private Property business As New Business.RPSGame

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Function getWinner(game As Models.RPSGame) As Models.RPSUser Implements Contract.IRPSGame.getWinner
        Return business.Instance.getWiner(game)
    End Function
End Class