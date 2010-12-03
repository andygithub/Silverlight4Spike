Imports System.Runtime.CompilerServices

Namespace Model

    Module Map

        <Extension()>
        Public Function ToSearchResults(ByVal item As SearchService.ServiceSearchResults) As SearchResults
            Dim _item As New SearchResults
            With item
                _item.Id = .Service_Id
                _item.AccountNumber = .Service_AccountNumber
                _item.CustomerAccountStatus = .Service_CustomerAccountStatus
                _item.DateCreated = .Service_DateCreated
                _item.DateOfBirth = .Service_DateOfBirth
                _item.FirstName = .Service_FirstName
                _item.LastName = .Service_LastName
            End With
            Return _item
        End Function

        <Extension()>
        Public Function ToCustomer(ByVal item As SearchResults) As Customer
            Dim _item As New Customer
            With item
                _item.Id = .Id
                _item.AccountNumber = .AccountNumber
                _item.CustomerAccountStatus = .CustomerAccountStatus
                _item.DateCreated = .DateCreated
                _item.DateOfBirth = .DateOfBirth
                _item.FirstName = .FirstName
                _item.LastName = .LastName
                'add other properties
            End With
            Return _item
        End Function

        <Extension()>
        Public Function ToServiceCustomer(ByVal item As Customer) As SearchService.ServiceConsumer
            Dim _item As New SearchService.ServiceConsumer
            With item
                _item.Service_Id = .Id
                _item.Service_AccountNumber = .AccountNumber
                _item.Service_CustomerAccountStatus = .CustomerAccountStatus
                _item.Service_DateCreated = .DateCreated
                _item.Service_DateOfBirth = .DateOfBirth
                _item.Service_FirstName = .FirstName
                _item.Service_LastName = .LastName
                _item.Service_CustomerLevel = .CustomerLevel
                _item.Service_DateCreated = .DateCreated
                _item.Service_AmountOwed = .AmountOwed
                _item.Service_OrderCount = .OrderCount
                'add other properties
            End With
            Return _item
        End Function

        <Extension()>
        Public Function ToServiceCustomerAddress(ByVal item As CustomerAddress) As SearchService.ServiceConsumerAdress
            Dim _item As New SearchService.ServiceConsumerAdress
            With item
                _item.Service_Id = .Id
                _item.Service_AccountNumber = .AccountNumber
                _item.Service_FirstName = .FirstName
                _item.Service_LastName = .LastName
                _item.Service_Address1 = .AddressLine1
                _item.Service_Address2 = .AddressLine2
                _item.Service_City = .City
                _item.Service_State = .State
                _item.Service_Zip = .Zip
                'add other properties
            End With
            Return _item
        End Function

        <Extension()>
        Public Function ToCustomerAddress(ByVal item As SearchResults) As CustomerAddress
            Dim _item As New CustomerAddress
            With item
                _item.Id = .Id
                _item.AccountNumber = .AccountNumber
                '_item.CustomerAccountStatus = .CustomerAccountStatus
                '_item.DateCreated = .DateCreated
                '_item.DateOfBirth = .DateOfBirth
                _item.FirstName = .FirstName
                _item.LastName = .LastName
                'add other properties
            End With
            Return _item
        End Function

    End Module

End Namespace