Imports Caliburn.Core.Metadata
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework
Imports SilverlightDataEntry.Presenters.Interfaces
Imports SilverlightDataEntry.Constants
Namespace Presenters

    <PerRequest(GetType(IHomePresenter))> _
    <HistoryKey(DisplayNames.Home)> _
    Public Class HomePresenter
        Inherits Presenter
        Implements IHomePresenter
        Private ReadOnly _shellPresenter As IShellPresenter

        Public Sub New(ByVal shellPresenter As IShellPresenter)
            _shellPresenter = shellPresenter
        End Sub

        Protected Overrides Sub OnInitialize()
            MyBase.OnInitialize()

            DisplayName = DisplayNames.Home
        End Sub

        Public Sub GotoConsumerSearch()
            _shellPresenter.Open(Of ISearchPresenter)()
        End Sub

        Public Sub GotoToolkit()
            _shellPresenter.Open(Of IToolkitPresenter)()
        End Sub

        Public Sub GotoSettings()
            _shellPresenter.Open(Of ISettingsPresenter)()
        End Sub
    End Class
End Namespace
