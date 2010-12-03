Imports Caliburn.PresentationFramework.ApplicationModel
Imports SilverlightDataEntry.Model
Imports Caliburn.PresentationFramework

Namespace Presenters.Interfaces

    Public Interface ICustomerAddressPresenter
        Inherits IPresenter, ISupportCustomShutdown

        Property CurrentCustomerAddress As CustomerAddress
        Sub Setup(ByVal item As SearchResults)
        Sub Cancel()
        Sub Search()
        Function Ok() As IResult
        Function Apply() As IResult

    End Interface

End Namespace