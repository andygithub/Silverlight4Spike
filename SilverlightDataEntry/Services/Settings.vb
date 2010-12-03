Imports Caliburn.Core.Metadata
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework
Imports Caliburn.PresentationFramework
Imports SilverlightDataEntry.Constants

Namespace Services

    <Singleton(GetType(ISettings))> _
    Public Class Settings
        Inherits SettingsBase
        Implements ISettings

        Public Property EarliestAppointment() As TimeSpan Implements ISettings.EarliestAppointment
            Get
                Dim milliseconds = Me.[Get](PropertyNames.EarliestAppointment, TimeSpan.FromHours(9).TotalMilliseconds)
                Return TimeSpan.FromMilliseconds(milliseconds)
            End Get
            Set(ByVal value As TimeSpan)
                InsertOrUpdate(PropertyNames.EarliestAppointment, value.TotalMilliseconds.ToString())
                NotifyOfPropertyChange(PropertyNames.EarliestAppointment)
            End Set
        End Property

        Public Property LatestAppointment() As TimeSpan Implements ISettings.LatestAppointment
            Get
                Dim milliseconds = Me.[Get](PropertyNames.LatestAppointment, TimeSpan.FromHours(17).TotalMilliseconds)
                Return TimeSpan.FromMilliseconds(milliseconds)
            End Get
            Set(ByVal value As TimeSpan)
                InsertOrUpdate(PropertyNames.LatestAppointment, value.TotalMilliseconds.ToString())
                NotifyOfPropertyChange(PropertyNames.LatestAppointment)
            End Set
        End Property

        Public Property AppointmentDate() As Date Implements ISettings.AppointmentDate
            Get
                Return Me.[Get](PropertyNames.AppointmentDate, DateTime.Now)
            End Get
            Set(ByVal value As Date)
                InsertOrUpdate(PropertyNames.AppointmentDate, value.ToString())
                NotifyOfPropertyChange(PropertyNames.AppointmentDate)
            End Set
        End Property

        Public Property SelectedAppointmentType() As Enumerations.AppointmentType Implements ISettings.SelectedAppointmentType
            Get
                Return Me.[Get](PropertyNames.SelectedAppointmentType, Enumerations.AppointmentType.Unscheduled)
            End Get
            Set(ByVal value As Enumerations.AppointmentType)
                InsertOrUpdate(PropertyNames.SelectedAppointmentType, value)
                NotifyOfPropertyChange(PropertyNames.SelectedAppointmentType)
            End Set
        End Property

        Public Property Status() As String Implements ISettings.Status
            Get
                Return Me.[Get](PropertyNames.Status, String.Empty)
            End Get
            Set(ByVal value As String)
                InsertOrUpdate(PropertyNames.Status, value.ToString())
                NotifyOfPropertyChange(PropertyNames.Status)
            End Set
        End Property

        Public Overloads Sub Load() Implements Interfaces.ISettings.Load
            Diagnostics.Debug.WriteLine("initializing the settings.")
        End Sub

        Public Overloads Sub Save() Implements Interfaces.ISettings.Save
            Diagnostics.Debug.WriteLine("saving the settings.")
        End Sub

    End Class
End Namespace
