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


Namespace Presenters

    <Singleton(GetType(ISearchPresenter))>
<HistoryKey(DisplayNames.Search)>
    Public Class SearchPresenter
        Inherits Presenter 'MultiPresenterManager
        Implements ISearchPresenter

        Private ReadOnly _shellPresenter As IShellPresenter
        Private ReadOnly _serviceLocator As IServiceLocator

        Private ReadOnly _SearchResults As New BindableCollection(Of SearchResults)
        Private _SearchStatus As String

        Public Sub New(ByVal shellPresenter As IShellPresenter, ByVal serviceLocator As IServiceLocator)
            _shellPresenter = shellPresenter
            _serviceLocator = serviceLocator
        End Sub

        Protected Overrides Sub OnInitialize()
            MyBase.OnInitialize()

            DisplayName = DisplayNames.Search

        End Sub

        Public ReadOnly Property Results() As BindableCollection(Of SearchResults) Implements ISearchPresenter.Results
            Get
                Return _SearchResults
            End Get
        End Property

        Public Property SearchStatus As String Implements ISearchPresenter.SearchStatus
            Get
                Return _SearchStatus
            End Get
            Set(ByVal value As String)
                _SearchStatus = value
                NotifyOfPropertyChange(PropertyNames.SearchStatus)
            End Set
        End Property


        Public Function LoadContacts(ByVal accountNumber As String, ByVal firstName As String, ByVal lastName As String) As IResult Implements ISearchPresenter.LoadContacts
            _SearchResults.Clear()
            Return New WebServiceResult(Of SearchService.SearchDataClient, SearchService.GetSearchDataCompletedEventArgs) _
            (Sub(x) x.GetSearchDataAsync(accountNumber, firstName, lastName), Sub(x) x.Result.Apply(Sub(dto) _SearchResults.Add(Map.ToSearchResults(dto))))

        End Function

        Public Sub Search(ByVal accountNumber As String, ByVal firstName As String, ByVal lastName As String) Implements ISearchPresenter.Search
            SearchStatus = My.Resources.Messages.SearchParametersAre & CoalesceSearchParmeter(accountNumber) & My.Resources.Messages.FirstName & CoalesceSearchParmeter(firstName) & My.Resources.Messages.LastName & CoalesceSearchParmeter(lastName)
        End Sub

        Public Sub Cancel() Implements ISearchPresenter.Cancel
            _shellPresenter.Open(Of IHomePresenter)()
        End Sub

        Private Function CoalesceSearchParmeter(ByVal value As String) As String
            If String.IsNullOrWhiteSpace(value) Then Return My.Resources.Messages.NotEntered
            Return value
        End Function

        Public Sub EditCustomer(ByVal item As SearchResults) Implements ISearchPresenter.EditCustomer
            Dim presenter = _serviceLocator.GetInstance(Of ICustomerDetailsPresenter)()
            presenter.Setup(item)
            'this opens the control within the existing page.  this would be for tab layout or popup windows.
            'Me.Open(presenter)
            'this opens the control in its own window.
            _shellPresenter.Open(presenter)
        End Sub

        Public Sub EditAddress(ByVal item As SearchResults) Implements ISearchPresenter.EditAddress
            Dim presenter = _serviceLocator.GetInstance(Of ICustomerAddressPresenter)()
            presenter.Setup(item)
            _shellPresenter.Open(presenter)
        End Sub

    End Class

End Namespace