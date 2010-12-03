Imports Microsoft.Silverlight.Testing
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SilverlightDataEntry.Model
Imports System.ComponentModel.DataAnnotations

Namespace SilverlightUnitTest

    <TestClass()>
    Public Class CustomerFixture


        <TestMethod()>
        <Tag(FixtureConstants._Synch)>
        <Description(FixtureConstants._Rules)>
        Public Sub RulesSuccess()
            Dim _customer As New Customer
            _customer.LastName = "testing"
            _customer.FirstName = "test"

            Assert.AreEqual(0, _customer.Validate.Count)
        End Sub

        <TestMethod()>
        <Tag(FixtureConstants._Synch)>
        <Description(FixtureConstants._Rules)>
        Public Sub RulesFail_Required_LastName()
            Dim _customer As New Customer
            _customer.LastName = "testing"
            Dim _list = _customer.Validate
            Assert.IsTrue(_list.First.ErrorMessage.EndsWith(FixtureConstants._IsRequired))
        End Sub

        <TestMethod()>
        <Tag(FixtureConstants._Synch)>
        <Description(FixtureConstants._Rules)>
        Public Sub RulesFail_Required_FirstName()
            Dim _customer As New Customer
            _customer.FirstName = "test"
            Dim _list = _customer.Validate
            Assert.IsTrue(_list.First.ErrorMessage.EndsWith(FixtureConstants._IsRequired))
        End Sub

        '<ExpectedException(GetType(ValidationException), Constants.Messages.LastNameLength)> this doesn't work the same way the nunit version works.  Need to manually catch the exception and check the message.
        <TestMethod()>
        <Tag(FixtureConstants._Synch)>
        <Description(FixtureConstants._Rules)>
        Public Sub RulesFail_Length_LastName()

            Try
                Dim _customer As New Customer With {.LastName = "testingtestingtesting"}
            Catch ex As ValidationException
                Assert.AreEqual(Constants.Messages.LastNameLength, ex.Message)
            End Try
        End Sub

    End Class
End Namespace
