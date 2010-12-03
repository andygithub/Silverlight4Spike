Imports Microsoft.Practices.ServiceLocation
Imports Caliburn.Core
Imports Caliburn.Core.Metadata
Imports Caliburn.PresentationFramework
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework
Imports SilverlightDataEntry.Presenters.Interfaces
Imports SilverlightDataEntry.Services.Interfaces
Imports SilverlightDataEntry.Model
Imports SilverlightDataEntry.Constants
Imports System.ComponentModel
Imports Caliburn.PresentationFramework.Filters
Imports Caliburn.ModelFramework


Namespace Presenters

    <HistoryKey(DisplayNames.ConsumerDetails)>
<PerRequest(GetType(ICustomerAddressPresenter))>
    Public Class CustomerAddressPresenter
        Inherits Presenter
        Implements ICustomerAddressPresenter

        Private _customerAddress As CustomerAddress
        Private ReadOnly _shellPresenter As IShellPresenter
        Private ReadOnly _serviceLocator As IServiceLocator

        Public Sub New(ByVal shellPresenter As IShellPresenter, ByVal serviceLocator As IServiceLocator)
            _shellPresenter = shellPresenter
            _serviceLocator = serviceLocator
        End Sub

        Public Sub Setup(ByVal item As Model.SearchResults) Implements Interfaces.ICustomerAddressPresenter.Setup
            _customerAddress = item.ToCustomerAddress
        End Sub

        Public Property CurrentCustomerAddress As Model.CustomerAddress Implements Interfaces.ICustomerAddressPresenter.CurrentCustomerAddress
            Get
                Return _customerAddress
            End Get
            Set(ByVal value As Model.CustomerAddress)
                _customerAddress = value
                NotifyOfPropertyChange(PropertyNames.CurrentCustomerAddress)
            End Set
        End Property

        Private Sub OnPropertyChangedEvent(ByVal s As Object, ByVal e As PropertyChangedEventArgs)
            If e.PropertyName = PropertyNames.IsDirty OrElse e.PropertyName = PropertyNames.IsValid Then
                NotifyOfPropertyChange(PropertyNames.CanSave)
            End If
        End Sub

        Protected Overrides Sub OnInitialize()
            MyBase.OnInitialize()
            DisplayName = DisplayNames.ConsumerAddress

            CurrentCustomerAddress.BeginEdit()
            CurrentCustomerAddress.Validate()
        End Sub

        Protected Overrides Sub OnActivate()
            MyBase.OnActivate()
            AddHandler CurrentCustomerAddress.PropertyChanged, AddressOf OnPropertyChangedEvent
        End Sub

        Protected Overrides Sub OnDeactivate()
            MyBase.OnDeactivate()
            RemoveHandler CurrentCustomerAddress.PropertyChanged, AddressOf OnPropertyChangedEvent
        End Sub

        Protected Overrides Sub OnShutdown()
            MyBase.OnShutdown()
            'CurrentCustomerAddress.CancelEdit()
        End Sub

        <Dependencies(PropertyNames.CanSave)>
        <Preview(PropertyNames.CanSave)>
        Public Function Apply() As IResult Implements ICustomerAddressPresenter.Apply
            Return SaveData(Sub(x) CurrentCustomerAddress.BeginEdit())
        End Function

        <Dependencies(PropertyNames.CanSave)>
        <Preview(PropertyNames.CanSave)>
        Public Function Ok() As IResult Implements ICustomerAddressPresenter.Ok
            Return SaveData(Sub(x) Me.Search())
        End Function

        Public ReadOnly Property CanSave() As Boolean
            Get
                Return CurrentCustomerAddress.IsDirty AndAlso CurrentCustomerAddress.IsValid
            End Get
        End Property

        Public Sub Cancel() Implements ICustomerAddressPresenter.Cancel

            Me.Shutdown()
            _shellPresenter.Open(Of IHomePresenter)()
        End Sub

        Public Sub Search() Implements ICustomerAddressPresenter.Search
            Me.Shutdown()
            _shellPresenter.Open(Of ISearchPresenter)()
        End Sub

        Private Function SaveData(ByVal callback As Action(Of AsyncCompletedEventArgs)) As IResult
            CurrentCustomerAddress.EndEdit()
            Dim dto = CurrentCustomerAddress.ToServiceCustomerAddress

            If dto.Service_Id = Guid.Empty Then
                dto.Service_Id = Guid.NewGuid()
            End If

            Return New WebServiceResult(Of SearchService.SearchDataClient, AsyncCompletedEventArgs)(Sub(x) x.UpdateConsumerAddressAsync(dto), callback)
        End Function

        Public Function ValidateItem() As IResult
            Return New ErrorResult(CurrentCustomerAddress.Validate())
        End Function

        Public Overrides Function CanShutdown() As Boolean
            Return Not CurrentCustomerAddress.IsDirty
        End Function

        Public Function CreateShutdownModel() As ISubordinate Implements ISupportCustomShutdown.CreateShutdownModel
            If Not CurrentCustomerAddress.IsValid Then
                Return New Question(Me, String.Format(My.Resources.Messages.InvalidConsumerAddressOnClose, CurrentCustomerAddress.FullName), Answer.Yes, Answer.No) With {.Answer = Answer.Yes}
            End If
            If CurrentCustomerAddress.IsDirty Then
                Return New Question(Me, String.Format(My.Resources.Messages.DirtyConsumerAddressOnClose, CurrentCustomerAddress.FullName), Answer.Yes, Answer.No) With {.Answer = Answer.Yes}
            End If
            Return Nothing
        End Function

        Public Overloads Function CanShutdown(ByVal shutdownModel As ISubordinate) As Boolean Implements ISupportCustomShutdown.CanShutdown
            Dim question = DirectCast(shutdownModel, Question)

            If CurrentCustomerAddress.IsValid Then
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