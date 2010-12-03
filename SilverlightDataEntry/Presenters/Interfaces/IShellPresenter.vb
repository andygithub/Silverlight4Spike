Imports Caliburn.PresentationFramework.ApplicationModel

Namespace Presenters.Interfaces

    Public Interface IShellPresenter
        Inherits IPresenterManager
        Overloads Sub Open(Of T As IPresenter)()
        Sub ShowDialog(Of T As {IPresenter, ILifecycleNotifier})(ByVal presenter As T)
    End Interface

End Namespace