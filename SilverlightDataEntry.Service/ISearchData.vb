<ServiceContract()>
Public Interface ISearchData

    <OperationContract()> Function GetSearchData(ByVal accountNumber As String, ByVal firstName As String, ByVal lastName As String) As IEnumerable(Of ServiceSearchResults)

    <OperationContract()> Sub UpdateConsumer(ByVal item As ServiceConsumer)

    <OperationContract()> Sub UpdateConsumerAddress(ByVal item As ServiceConsumerAdress)

End Interface

<DataContract()>
Public Class ServiceSearchResults

    <DataMember()> Public Property Service_Id As Guid
    <DataMember()> Public Property Service_LastName As String
    <DataMember()> Public Property Service_FirstName As String
    <DataMember()> Public Property Service_DateOfBirth As String
    <DataMember()> Public Property Service_AccountNumber As String
    <DataMember()> Public Property Service_CustomerAccountStatus As AccountStatus
    <DataMember()> Public Property Service_DateCreated As Date
End Class

<DataContract()>
Public Class ServiceConsumer

    <DataMember()> Public Property Service_Id As Guid
    <DataMember()> Public Property Service_LastName As String
    <DataMember()> Public Property Service_FirstName As String
    <DataMember()> Public Property Service_DateOfBirth As String
    <DataMember()> Public Property Service_AccountNumber As String
    <DataMember()> Public Property Service_CustomerAccountStatus As AccountStatus
    <DataMember()> Public Property Service_DateCreated As Date
    <DataMember()> Public Property Service_CustomerLevel As String
    <DataMember()> Public Property Service_AmountOwed As Double
    <DataMember()> Public Property Service_OrderCount As Integer
End Class

<DataContract()>
Public Class ServiceConsumerAdress

    <DataMember()> Public Property Service_Id As Guid
    <DataMember()> Public Property Service_LastName As String
    <DataMember()> Public Property Service_FirstName As String
    <DataMember()> Public Property Service_AccountNumber As String
    <DataMember()> Public Property Service_Address1 As String
    <DataMember()> Public Property Service_Address2 As String
    <DataMember()> Public Property Service_City As String
    <DataMember()> Public Property Service_State As String
    <DataMember()> Public Property Service_Zip As String

End Class

Public Enum AccountStatus

    Failure = -10
    Warning = 1
    Good = 10

End Enum
