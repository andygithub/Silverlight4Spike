Imports SilverlightDataEntry.Enumerations
Namespace Model

    ''' <summary>
    ''' Simple read only model class to show how to bind items to a grid.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SearchResults

        Public Property Id As Guid
        Public Property LastName As String
        Public Property FirstName As String
        Public Property DateOfBirth As Date
        Public Property AccountNumber As String
        Public Property CustomerAccountStatus As Enumerations.AccountStatus
        Public Property DateCreated As Date

        Public ReadOnly Property FullName As String
            Get
                Return Me.LastName & ", " & Me.FirstName
            End Get
        End Property

    End Class

End Namespace