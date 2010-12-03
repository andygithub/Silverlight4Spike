Imports System.Linq
Imports System.Reflection
Imports Caliburn.Core.Metadata
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework
Imports Microsoft.Practices.ServiceLocation
Imports SilverlightDataEntry.Presenters.Interfaces
Imports SilverlightDataEntry.Services.Interfaces
Imports SilverlightDataEntry.Constants

Namespace Presenters

    <Singleton(GetType(IShellPresenter))> _
    Public Class ShellPresenter
        Inherits PresenterManager
        Implements IShellPresenter
        Private ReadOnly _serviceLocator As IServiceLocator
        Private ReadOnly _settings As ISettings
        Private ReadOnly _historyManager As HistoryManager(Of IHomePresenter)
        Private _dialogModel As IPresenter

        Public Sub New(ByVal serviceLocator As IServiceLocator, ByVal stateManager As IStateManager, ByVal settings As ISettings)
            _serviceLocator = serviceLocator
            _settings = settings
            _historyManager = New HistoryManager(Of IHomePresenter)(Me, stateManager, serviceLocator)
        End Sub

        Public Property DialogModel() As IPresenter
            Get
                Return _dialogModel
            End Get
            Set(ByVal value As IPresenter)
                _dialogModel = value
                NotifyOfPropertyChange(PropertyNames.DialogModel)
            End Set
        End Property

        Public Overloads Sub Open(Of T As IPresenter)() Implements IShellPresenter.Open
            Dim presenter = _serviceLocator.GetInstance(Of T)()
            Me.Open(presenter)
        End Sub

        Public Sub GoHome()
            Open(Of IHomePresenter)()
        End Sub

        Public Sub ShowDialog(Of T As {IPresenter, ILifecycleNotifier})(ByVal presenter As T) Implements IShellPresenter.ShowDialog
            AddHandler presenter.WasShutdown, (Sub() DialogModel = Nothing)
            DialogModel = presenter
        End Sub

        Protected Overrides Sub OnInitialize()
            MyBase.OnInitialize()

            _settings.Load()
        End Sub

        Protected Overrides Sub OnActivate()
            MyBase.OnActivate()
            _historyManager.Initialize(Assembly.GetExecutingAssembly())
        End Sub

        Protected Overrides Sub ExecuteShutdownModel(ByVal model As ISubordinate, ByVal completed As Action)
            Dim dialogPresenter = _serviceLocator.GetInstance(Of IQuestionPresenter)()

            Dim composite = TryCast(model, ISubordinateComposite)
            If composite IsNot Nothing Then
                dialogPresenter.Setup(composite.GetChildren().Cast(Of Question)(), completed)
                ShowDialog(dialogPresenter)
            Else
                Dim question = DirectCast(model, Question)
                dialogPresenter.Setup((New List(Of Question)(New Question() {question})), completed)
                ShowDialog(dialogPresenter)
            End If
        End Sub
    End Class

End Namespace
