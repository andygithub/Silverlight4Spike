Imports Caliburn.Core.Metadata
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework
Imports SilverlightDataEntry.Presenters.Interfaces
Namespace Presenters

    <Singleton(GetType(ILoadScreen))> _
    Public Class LoadScreenPresenter
        Inherits Presenter
        Implements ILoadScreen
        Private ReadOnly _shellPresenter As IShellPresenter

        Public Sub New(ByVal shellPresenter As IShellPresenter)
            _shellPresenter = shellPresenter
        End Sub

        Public Sub StartLoading() Implements ILoadScreen.StartLoading
            _shellPresenter.ShowDialog(Me)
        End Sub

        Public Sub StopLoading() Implements ILoadScreen.StopLoading
            Shutdown()
        End Sub
    End Class

End Namespace
