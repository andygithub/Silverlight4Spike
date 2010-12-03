Imports Caliburn.Core
Imports Caliburn.Core.Metadata
Imports Caliburn.ModelFramework
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework
Imports SilverlightDataEntry.Presenters.Interfaces
Imports SilverlightDataEntry.Services.Interfaces
Imports SilverlightDataEntry.Model
Imports Caliburn.PresentationFramework
Imports Microsoft.Practices.ServiceLocation
Imports SilverlightDataEntry.Constants
Imports Caliburn.PresentationFramework.Filters
Imports System.ComponentModel

Namespace Presenters

    <HistoryKey(DisplayNames.ConsumerDetails)>
    <PerRequest(GetType(ICustomerDetailsPresenter))>
    Public Class CustomerDetailsPresenter
        Inherits Presenter
        Implements ICustomerDetailsPresenter

        Private _customer As Customer
        Private ReadOnly _shellPresenter As IShellPresenter
        Private ReadOnly _serviceLocator As IServiceLocator

        Public Sub New(ByVal shellPresenter As IShellPresenter, ByVal serviceLocator As IServiceLocator)
            _shellPresenter = shellPresenter
            _serviceLocator = serviceLocator
        End Sub

        Public Sub Setup(ByVal item As Model.SearchResults) Implements Interfaces.ICustomerDetailsPresenter.Setup
            _customer = item.ToCustomer
        End Sub

        Public Property CurrentCustomer As Model.Customer Implements Interfaces.ICustomerDetailsPresenter.CurrentCustomer
            Get
                Return _customer
            End Get
            Set(ByVal value As Model.Customer)
                _customer = value
                NotifyOfPropertyChange(PropertyNames.CurrentCustomer)
            End Set
        End Property

        Private Sub OnPropertyChangedEvent(ByVal s As Object, ByVal e As PropertyChangedEventArgs)
            If e.PropertyName = PropertyNames.IsDirty OrElse e.PropertyName = PropertyNames.IsValid Then
                NotifyOfPropertyChange(PropertyNames.CanSave)
            End If
        End Sub

        Protected Overrides Sub OnInitialize()
            MyBase.OnInitialize()
            DisplayName = DisplayNames.ConsumerDetails

            CurrentCustomer.BeginEdit()
            CurrentCustomer.Validate()
        End Sub

        Protected Overrides Sub OnActivate()
            MyBase.OnActivate()
            AddHandler CurrentCustomer.PropertyChanged, AddressOf OnPropertyChangedEvent
        End Sub

        Protected Overrides Sub OnDeactivate()
            MyBase.OnDeactivate()
            RemoveHandler CurrentCustomer.PropertyChanged, AddressOf OnPropertyChangedEvent
        End Sub

        Protected Overrides Sub OnShutdown()
            MyBase.OnShutdown()
        End Sub

        <Dependencies(PropertyNames.CanSave)> _
        <Preview(PropertyNames.CanSave)> _
        Public Function Apply() As IResult Implements ICustomerDetailsPresenter.Apply
            Return SaveContact(Sub(x) CurrentCustomer.BeginEdit())
        End Function

        <Dependencies(PropertyNames.CanSave)> _
        <Preview(PropertyNames.CanSave)> _
        Public Function Ok() As IResult Implements ICustomerDetailsPresenter.Ok
            Return SaveContact(Sub(x) Me.Search())
        End Function

        Public ReadOnly Property CanSave() As Boolean
            Get
                Return CurrentCustomer.IsDirty AndAlso CurrentCustomer.IsValid
            End Get
        End Property

        Public Sub Cancel() Implements ICustomerDetailsPresenter.Cancel

            Me.Shutdown()
            _shellPresenter.Open(Of IHomePresenter)()
        End Sub

        Public Sub Search() Implements ICustomerDetailsPresenter.Search
            Me.Shutdown()
            _shellPresenter.Open(Of ISearchPresenter)()
        End Sub

        Private Function SaveContact(ByVal callback As Action(Of AsyncCompletedEventArgs)) As IResult
            CurrentCustomer.EndEdit()
            Dim dto = CurrentCustomer.ToServiceCustomer

            If dto.Service_Id = Guid.Empty Then
                dto.Service_Id = Guid.NewGuid()
            End If

            Return New WebServiceResult(Of SearchService.SearchDataClient, AsyncCompletedEventArgs)(Sub(x) x.UpdateConsumerAsync(dto), callback)
        End Function

        Public Function ValidateCurrentCustomer() As IResult
            Return New ErrorResult(CurrentCustomer.Validate())
        End Function

        Public Overrides Function CanShutdown() As Boolean
            Return Not CurrentCustomer.IsDirty
        End Function

        Public Function CreateShutdownModel() As ISubordinate Implements ISupportCustomShutdown.CreateShutdownModel
            If Not CurrentCustomer.IsValid Then
                Return New Question(Me, String.Format(My.Resources.Messages.InvalidConsumerOnClose, CurrentCustomer.FullName), Answer.Yes, Answer.No) With {.Answer = Answer.Yes}
            End If
            If CurrentCustomer.IsDirty Then
                Return New Question(Me, String.Format(My.Resources.Messages.DirtyConsumerOnClose, CurrentCustomer.FullName), Answer.Yes, Answer.No) With {.Answer = Answer.Yes}
            End If            
            Return Nothing
        End Function

        Public Overloads Function CanShutdown(ByVal shutdownModel As ISubordinate) As Boolean Implements ISupportCustomShutdown.CanShutdown
            Dim question = DirectCast(shutdownModel, Question)

            If CurrentCustomer.IsValid Then
                If question.Answer = Answer.Cancel Then Return False

                If question.Answer = Answer.Yes Then
                    Execute(Apply())
                End If

                Return True
            End If

            If question.Answer = Answer.Yes Then Return True

            Return False
        End Function

        Protected Overrides Sub ExecuteShutdownModel(ByVal model As ISubordinate, ByVal completed As Action)

            Dim _question = CType(model, Question)
            Dim dialogPresenter = _serviceLocator.GetInstance(Of IQuestionPresenter)()

            dialogPresenter.Setup(New Question() {_question}, completed)

            _shellPresenter.ShowDialog(dialogPresenter)
        End Sub

    End Class

End Namespace