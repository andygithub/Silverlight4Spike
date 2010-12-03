Imports System
Imports System.Collections.Generic
Imports Caliburn.ModelFramework
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Namespace Model

    Public Class Customer
        Implements INotifyPropertyChanged, IEditableObject
        Private Const _GroupName As String = "Name"

        Private _cache As Customer

        Private _FirstName As String
        Private _LastName As String
        Private _IsDirty As Boolean

        Public Property Id As Guid

        Public Property IsDirty As Boolean
            Get
                Return _IsDirty
            End Get
            Set(ByVal value As Boolean)
                If _IsDirty <> value Then
                    _IsDirty = value
                    OnPropertyChanged(Constants.PropertyNames.IsDirty)
                End If
            End Set
        End Property

        <Required()>
        <StringLength(10, ErrorMessage:=Constants.Messages.LastNameLength)>
        <Display(Name:="Last Name", GroupName:=_GroupName, Description:="This contains the last name value of the customer.  Can't exceed 10 characters.  Required Field")>
        Public Property LastName As String
            Get
                Return _LastName
            End Get
            Set(ByVal value As String)
                If _LastName <> value Then
                    _LastName = value
                    OnPropertyChanged(Constants.PropertyNames.LastName)
                    IsDirty = True
                    Validator.ValidateProperty(value, New ValidationContext(Me, Nothing, Nothing) With {.MemberName = Constants.PropertyNames.LastName})
                End If
            End Set
        End Property

        <Required()>
        <Display(Name:="First Name", GroupName:=_GroupName, Description:="Required Field")>
        Public Property FirstName As String
            Get
                Return _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
                OnPropertyChanged(Constants.PropertyNames.FirstName)
                IsDirty = True
                Validator.ValidateProperty(value, New ValidationContext(Me, Nothing, Nothing) With {.MemberName = Constants.PropertyNames.FirstName})
            End Set
        End Property

        <Display(Name:="Date of Birth", GroupName:=_GroupName, Description:="Customer Date of Birth")>
        Public Property DateOfBirth As Date

        <Display(Name:="Account Number", GroupName:=_GroupName)>
        Public Property AccountNumber As String
        Public Property CustomerAccountStatus As Enumerations.AccountStatus
        Public Property DateCreated As Date
        Public Property CustomerLevel As String
        Public Property AmountOwed As Double
        Public Property OrderCount As Integer

        Public ReadOnly Property FullName As String
            Get
                Return Me.LastName & ", " & Me.FirstName
            End Get
        End Property

        Public Sub BeginEdit() Implements System.ComponentModel.IEditableObject.BeginEdit
            _cache = New Customer
            _cache.FirstName = Me.FirstName
            _cache.LastName = Me.LastName
            _cache.DateOfBirth = Me.DateOfBirth
            IsDirty = False
        End Sub

        Public Sub CancelEdit() Implements System.ComponentModel.IEditableObject.CancelEdit
            If _cache Is Nothing Then Exit Sub
            Me.FirstName = _cache.FirstName
            Me.LastName = _cache.LastName
            Me.DateOfBirth = _cache.DateOfBirth
            IsDirty = False
            _cache = Nothing
        End Sub

        Public Sub EndEdit() Implements System.ComponentModel.IEditableObject.EndEdit
            IsDirty = False
            _cache = Nothing
        End Sub

        Protected Overridable Sub OnPropertyChanged(ByVal propName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
        End Sub

        Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Public Function Validate() As IEnumerable(Of ValidationResult)
            Dim _v As New ValidationContext(Me, Nothing, Nothing)
            Dim _vResults As New List(Of ValidationResult)
            Validator.TryValidateObject(Me, _v, _vResults, True)

            Return _vResults

        End Function

        Public ReadOnly Property IsValid As Boolean
            Get
                Dim _v As New ValidationContext(Me, Nothing, Nothing)
                Dim _vResults As New List(Of ValidationResult)
                Return Validator.TryValidateObject(Me, _v, _vResults, True)
            End Get
        End Property
    End Class

End Namespace