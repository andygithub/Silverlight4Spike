Imports SilverlightDataEntry.Enumerations
Imports Caliburn.Silverlight.ApplicationFramework

Namespace Model


    Public Class AppointmentTypeCollection
        Inherits BindableEnumCollection(Of AppointmentType)

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal values() As AppointmentType)
            MyBase.New(values)
        End Sub

    End Class

End Namespace
