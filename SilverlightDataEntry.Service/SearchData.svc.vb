
Public Class SearchData
    Implements ISearchData


    Public Sub New()
    End Sub

    Public Function GetSearchData(ByVal accountNumber As String, ByVal firstName As String, ByVal lastName As String) As IEnumerable(Of ServiceSearchResults) Implements ISearchData.GetSearchData
        Return BuildListofSearchResults(accountNumber, firstName, lastName)
    End Function

    Private Function BuildListofSearchResults(ByVal accountNumber As String, ByVal firstName As String, ByVal lastName As String) As IEnumerable(Of ServiceSearchResults)

        Return ({New ServiceSearchResults With {.Service_Id = Guid.NewGuid, .Service_AccountNumber = 1308930897, .Service_CustomerAccountStatus = AccountStatus.Good, .Service_DateCreated = DateTime.Now, .Service_DateOfBirth = DateTime.Now.AddDays(-500), .Service_FirstName = "Grey", .Service_LastName = "Dark"},
                New ServiceSearchResults With {.Service_Id = Guid.NewGuid, .Service_AccountNumber = 31789136, .Service_CustomerAccountStatus = AccountStatus.Failure, .Service_DateCreated = DateTime.Now, .Service_DateOfBirth = DateTime.Now.AddDays(-800), .Service_FirstName = "Silver", .Service_LastName = "Light"},
                New ServiceSearchResults With {.Service_Id = Guid.NewGuid, .Service_AccountNumber = 509018236, .Service_CustomerAccountStatus = AccountStatus.Warning, .Service_DateCreated = DateTime.Now.AddMonths(60), .Service_DateOfBirth = DateTime.Now.AddDays(800), .Service_FirstName = "Rick", .Service_LastName = "Robbins"}
            }).ToList

    End Function

    Public Sub UpdateConsumer(ByVal item As ServiceConsumer) Implements ISearchData.UpdateConsumer
        System.Diagnostics.Debug.WriteLine("The Update Consumer method is called for: " & item.Service_LastName)
    End Sub

    Public Sub UpdateConsumerAddress(ByVal item As ServiceConsumerAdress) Implements ISearchData.UpdateConsumerAddress
        System.Diagnostics.Debug.WriteLine("The Update Consumer Address method is called for: " & item.Service_LastName)
    End Sub

End Class
