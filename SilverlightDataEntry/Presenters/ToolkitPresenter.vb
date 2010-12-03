Imports Caliburn.Core.Metadata
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework
Imports SilverlightDataEntry.Presenters.Interfaces
Imports SilverlightDataEntry.Constants
Namespace Presenters

    <PerRequest(GetType(IToolkitPresenter))> _
    <HistoryKey(DisplayNames.Toolkit)> _
    Public Class ToolkitPresenter
        Inherits Presenter
        Implements IToolkitPresenter
        Private ReadOnly _shellPresenter As IShellPresenter

        Public Sub New(ByVal shellPresenter As IShellPresenter)
            _shellPresenter = shellPresenter
        End Sub

        Protected Overrides Sub OnInitialize()
            MyBase.OnInitialize()

            DisplayName = DisplayNames.Toolkit
        End Sub

        Public Sub GotoHome()
            _shellPresenter.Open(Of IHomePresenter)()
        End Sub

    End Class
End Namespace
