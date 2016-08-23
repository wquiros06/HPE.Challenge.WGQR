﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34014
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace WSRpsGameTest
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="WSRpsGameTest.WSRpsGameSoap")>  _
    Public Interface WSRpsGameSoap
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/HelloWorld", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function HelloWorld() As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/HelloWorld", ReplyAction:="*")>  _
        Function HelloWorldAsync() As System.Threading.Tasks.Task(Of String)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/playGame", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(MemberInfo)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(Attribute))>  _
        Function playGame(ByVal game As WSRpsGameTest.RPSGame) As WSRpsGameTest.RPSGame
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/playGame", ReplyAction:="*")>  _
        Function playGameAsync(ByVal game As WSRpsGameTest.RPSGame) As System.Threading.Tasks.Task(Of WSRpsGameTest.RPSGame)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/playTournament", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(MemberInfo)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(Attribute))>  _
        Function playTournament(ByVal rounds() As WSRpsGameTest.RPSGame) As WSRpsGameTest.RPSGame
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/playTournament", ReplyAction:="*")>  _
        Function playTournamentAsync(ByVal rounds() As WSRpsGameTest.RPSGame) As System.Threading.Tasks.Task(Of WSRpsGameTest.RPSGame)
    End Interface
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class RPSGame
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private rESULT_MESAGGEField As String
        
        Private userOneField As RPSUser
        
        Private userTwoField As RPSUser
        
        Private winnerField As RPSUser
        
        Private loserField As RPSUser
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>  _
        Public Property RESULT_MESAGGE() As String
            Get
                Return Me.rESULT_MESAGGEField
            End Get
            Set
                Me.rESULT_MESAGGEField = value
                Me.RaisePropertyChanged("RESULT_MESAGGE")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>  _
        Public Property UserOne() As RPSUser
            Get
                Return Me.userOneField
            End Get
            Set
                Me.userOneField = value
                Me.RaisePropertyChanged("UserOne")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=2)>  _
        Public Property UserTwo() As RPSUser
            Get
                Return Me.userTwoField
            End Get
            Set
                Me.userTwoField = value
                Me.RaisePropertyChanged("UserTwo")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=3)>  _
        Public Property Winner() As RPSUser
            Get
                Return Me.winnerField
            End Get
            Set
                Me.winnerField = value
                Me.RaisePropertyChanged("Winner")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=4)>  _
        Public Property Loser() As RPSUser
            Get
                Return Me.loserField
            End Get
            Set
                Me.loserField = value
                Me.RaisePropertyChanged("Loser")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class RPSUser
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private idField As Long
        
        Private nameField As String
        
        Private gameStrategyField As RPSGameStrategy
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>  _
        Public Property ID() As Long
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = value
                Me.RaisePropertyChanged("ID")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>  _
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = value
                Me.RaisePropertyChanged("Name")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=2)>  _
        Public Property GameStrategy() As RPSGameStrategy
            Get
                Return Me.gameStrategyField
            End Get
            Set
                Me.gameStrategyField = value
                Me.RaisePropertyChanged("GameStrategy")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class RPSGameStrategy
        Inherits ValidationAttribute
        
        Private strategyField As String
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>  _
        Public Property Strategy() As String
            Get
                Return Me.strategyField
            End Get
            Set
                Me.strategyField = value
                Me.RaisePropertyChanged("Strategy")
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.Xml.Serialization.XmlIncludeAttribute(GetType(RPSGameStrategy)),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public MustInherit Class ValidationAttribute
        Inherits Attribute
        
        Private errorMessageField As String
        
        Private errorMessageResourceNameField As String
        
        Private errorMessageResourceTypeField As Type
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>  _
        Public Property ErrorMessage() As String
            Get
                Return Me.errorMessageField
            End Get
            Set
                Me.errorMessageField = value
                Me.RaisePropertyChanged("ErrorMessage")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>  _
        Public Property ErrorMessageResourceName() As String
            Get
                Return Me.errorMessageResourceNameField
            End Get
            Set
                Me.errorMessageResourceNameField = value
                Me.RaisePropertyChanged("ErrorMessageResourceName")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=2)>  _
        Public Property ErrorMessageResourceType() As Type
            Get
                Return Me.errorMessageResourceTypeField
            End Get
            Set
                Me.errorMessageResourceTypeField = value
                Me.RaisePropertyChanged("ErrorMessageResourceType")
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public MustInherit Class Type
        Inherits MemberInfo
    End Class
    
    '''<remarks/>
    <System.Xml.Serialization.XmlIncludeAttribute(GetType(Type)),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public MustInherit Class MemberInfo
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<remarks/>
    <System.Xml.Serialization.XmlIncludeAttribute(GetType(ValidationAttribute)),  _
     System.Xml.Serialization.XmlIncludeAttribute(GetType(RPSGameStrategy)),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public MustInherit Class Attribute
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface WSRpsGameSoapChannel
        Inherits WSRpsGameTest.WSRpsGameSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class WSRpsGameSoapClient
        Inherits System.ServiceModel.ClientBase(Of WSRpsGameTest.WSRpsGameSoap)
        Implements WSRpsGameTest.WSRpsGameSoap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function HelloWorld() As String Implements WSRpsGameTest.WSRpsGameSoap.HelloWorld
            Return MyBase.Channel.HelloWorld
        End Function
        
        Public Function HelloWorldAsync() As System.Threading.Tasks.Task(Of String) Implements WSRpsGameTest.WSRpsGameSoap.HelloWorldAsync
            Return MyBase.Channel.HelloWorldAsync
        End Function
        
        Public Function playGame(ByVal game As WSRpsGameTest.RPSGame) As WSRpsGameTest.RPSGame Implements WSRpsGameTest.WSRpsGameSoap.playGame
            Return MyBase.Channel.playGame(game)
        End Function
        
        Public Function playGameAsync(ByVal game As WSRpsGameTest.RPSGame) As System.Threading.Tasks.Task(Of WSRpsGameTest.RPSGame) Implements WSRpsGameTest.WSRpsGameSoap.playGameAsync
            Return MyBase.Channel.playGameAsync(game)
        End Function
        
        Public Function playTournament(ByVal rounds() As WSRpsGameTest.RPSGame) As WSRpsGameTest.RPSGame Implements WSRpsGameTest.WSRpsGameSoap.playTournament
            Return MyBase.Channel.playTournament(rounds)
        End Function
        
        Public Function playTournamentAsync(ByVal rounds() As WSRpsGameTest.RPSGame) As System.Threading.Tasks.Task(Of WSRpsGameTest.RPSGame) Implements WSRpsGameTest.WSRpsGameSoap.playTournamentAsync
            Return MyBase.Channel.playTournamentAsync(rounds)
        End Function
    End Class
End Namespace
