Imports Caliburn.PresentationFramework.ApplicationModel
Imports SilverlightDataEntry.Model
Imports Caliburn.PresentationFramework

Namespace Presenters.Interfaces

    Public Interface ICustomerDetailsPresenter
        Inherits IPresenter, ISupportCustomShutdown

        Property CurrentCustomer As Customer
        Sub Setup(ByVal item As SearchResults)
        Sub Cancel()
        Sub Search()
        Function Ok() As IResult
        Function Apply() As IResult

    End Interface

End Namespace