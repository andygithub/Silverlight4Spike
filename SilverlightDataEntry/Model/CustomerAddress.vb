Imports Caliburn.ModelFramework
Imports Caliburn.Silverlight.ApplicationFramework.Interrogators

Namespace Model

    Public Class CustomerAddress
        Inherits ModelBase

        Public Property Id As Guid
        Public Property FirstName As String
        Public Property LastName As String
        Public Property AccountNumber As String

        Public ReadOnly Property FullName As String
            Get
                Return Me.LastName & ", " & Me.FirstName
            End Get
        End Property

        Public Shared ReadOnly AddressLine1Property As IPropertyDefinition(Of String) = [Property](Of CustomerAddress, String)(Function(x) x.AddressLine1).MustNotBeBlank(My.Resources.Messages.BlankAddressLine1)
        Public Shared ReadOnly AddressLine2Property As IPropertyDefinition(Of String) = [Property](Of CustomerAddress, String)(Function(x) x.AddressLine2)
        Public Shared ReadOnly CityProperty As IPropertyDefinition(Of String) = [Property](Of CustomerAddress, String)(Function(x) x.City)
        Public Shared ReadOnly StateProperty As IPropertyDefinition(Of String) = [Property](Of CustomerAddress, String)(Function(x) x.State)
        Public Shared ReadOnly ZipProperty As IPropertyDefinition(Of String) = [Property](Of CustomerAddress, String)(Function(x) x.Zip)

        Public Property AddressLine1() As String
            Get
                Return GetValue(AddressLine1Property)
            End Get
            Set(ByVal value As String)
                SetValue(AddressLine1Property, value)
            End Set
        End Property

        Public Property AddressLine2 As String
            Get
                Return GetValue(AddressLine2Property)
            End Get
            Set(ByVal value As String)
                SetValue(AddressLine2Property, value)
            End Set
        End Property

        Public Property City As String
            Get
                Return GetValue(CityProperty)
            End Get
            Set(ByVal value As String)
                SetValue(CityProperty, value)
            End Set
        End Property

        Public Property State As String
            Get
                Return GetValue(StateProperty)
            End Get
            Set(ByVal value As String)
                SetValue(StateProperty, value)
            End Set
        End Property

        Public Property Zip As String
            Get
                Return GetValue(ZipProperty)
            End Get
            Set(ByVal value As String)
                SetValue(ZipProperty, value)
            End Set
        End Property


    End Class

End Namespace