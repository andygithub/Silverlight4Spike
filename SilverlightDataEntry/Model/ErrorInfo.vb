Namespace Model


    Public Class ErrorInfo

        Sub New(ByVal name As String, ByVal message As String, ByVal instanceObject As Object)
            PropertyName = name
            ErrorMessage = message
            Instance = instanceObject
        End Sub

        Public Property PropertyName As String
        Public Property ErrorMessage As String
        Public Property Instance As Object

    End Class

End Namespace