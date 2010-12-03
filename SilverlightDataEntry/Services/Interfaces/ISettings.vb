Imports System
Imports System.ComponentModel

Namespace Services.Interfaces

    Public Interface ISettings
        Inherits INotifyPropertyChanged

        Property EarliestAppointment As TimeSpan
        Property AppointmentDate As Date
        Property LatestAppointment As TimeSpan
        Property SelectedAppointmentType As Enumerations.AppointmentType
        Property Status As String

        Sub Save()
        Sub Load()
    End Interface
End Namespace