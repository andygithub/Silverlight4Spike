Imports Caliburn.Core.Metadata
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework
Imports SilverlightDataEntry.Presenters.Interfaces
Imports SilverlightDataEntry.Services.Interfaces
Imports SilverlightDataEntry.Constants
Imports Caliburn.PresentationFramework

Namespace Presenters

    <PerRequest(GetType(ISettingsPresenter))> _
    <HistoryKey(DisplayNames.Settings)> _
    Public Class SettingsPresenter
        Inherits Presenter
        Implements ISettingsPresenter

        Private ReadOnly _shellPresenter As IShellPresenter
        Private ReadOnly _settings As ISettings

        Private _earliestAppointment As TimeSpan
        Private _latestAppointment As TimeSpan
        Private _appointmentDate As Date
        Private _selectedAppointmentType As Enumerations.AppointmentType
        Private _status As String

        Public Sub New(ByVal shellPresenter As IShellPresenter, ByVal settings As ISettings)
            _shellPresenter = shellPresenter
            _settings = settings
        End Sub

        Protected Overrides Sub OnInitialize()
            MyBase.OnInitialize()

            DisplayName = DisplayNames.Settings
            EarliestAppointment = _settings.EarliestAppointment
            LatestAppointment = _settings.LatestAppointment
            AppointmentDate = _settings.AppointmentDate
            SelectedAppointmentType = _settings.SelectedAppointmentType
        End Sub

        Public Property EarliestAppointment() As TimeSpan
            Get
                Return _earliestAppointment
            End Get
            Set(ByVal value As TimeSpan)
                _earliestAppointment = value
                NotifyOfPropertyChange(PropertyNames.EarliestAppointment)
            End Set
        End Property

        Public Property LatestAppointment() As TimeSpan
            Get
                Return _latestAppointment
            End Get
            Set(ByVal value As TimeSpan)
                _latestAppointment = value
                NotifyOfPropertyChange(PropertyNames.LatestAppointment)
            End Set
        End Property

        Public Property AppointmentDate() As Date
            Get
                Return _appointmentDate
            End Get
            Set(ByVal value As Date)
                _appointmentDate = value
                NotifyOfPropertyChange(PropertyNames.AppointmentDate)
            End Set
        End Property

        Public Property SelectedAppointmentType() As Enumerations.AppointmentType
            Get
                Return _selectedAppointmentType
            End Get
            Set(ByVal value As Enumerations.AppointmentType)
                _selectedAppointmentType = value
                NotifyOfPropertyChange(PropertyNames.SelectedAppointmentType)
            End Set
        End Property

        Public Property Status() As String
            Get
                Return _status
            End Get
            Set(ByVal value As String)
                _status = value
                NotifyOfPropertyChange(PropertyNames.Status)
            End Set
        End Property

        Public Sub AppointmentTypeModified()
            Me.Status = My.Resources.Messages.CurrentAppointmentType & Me.SelectedAppointmentType.ToString
        End Sub

        Public Sub Save()
            _settings.EarliestAppointment = EarliestAppointment
            _settings.LatestAppointment = LatestAppointment
            _settings.AppointmentDate = AppointmentDate
            _settings.SelectedAppointmentType = SelectedAppointmentType

            _settings.Save()

            _shellPresenter.Open(Of IHomePresenter)()
        End Sub

        Public Sub Cancel()
            _shellPresenter.Open(Of IHomePresenter)()
        End Sub
    End Class

End Namespace
