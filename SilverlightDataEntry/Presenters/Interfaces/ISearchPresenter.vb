Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.PresentationFramework
Imports SilverlightDataEntry.Model

Namespace Presenters.Interfaces

    Public Interface ISearchPresenter
        Inherits IPresenter

        ReadOnly Property Results() As BindableCollection(Of SearchResults)
        Property SearchStatus As String
        Function LoadContacts(ByVal accountNumber As String, ByVal firstName As String, ByVal lastName As String) As IResult
        Sub Search(ByVal AccountNumber As String, ByVal FirstName As String, ByVal LastName As String)
        Sub Cancel()
        Sub EditCustomer(ByVal item As SearchResults)
        Sub EditAddress(ByVal item As SearchResults)

    End Interface

End Namespace