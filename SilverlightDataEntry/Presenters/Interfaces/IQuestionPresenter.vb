Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework

Namespace Presenters.Interfaces

    Public Interface IQuestionPresenter
        Inherits IPresenter, ILifecycleNotifier

        Sub Setup(ByVal questions As IEnumerable(Of Question), ByVal completed As Action)
    End Interface

End Namespace