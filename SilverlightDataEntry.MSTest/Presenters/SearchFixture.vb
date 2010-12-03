Imports Microsoft.Silverlight.Testing
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SilverlightDataEntry.Presenters
Imports System.ComponentModel.DataAnnotations
Imports Caliburn.PresentationFramework
Imports Microsoft.Practices.Unity
Imports Caliburn.Unity
Imports Caliburn.Silverlight.ApplicationFramework
Imports System.Reflection

Namespace SilverlightUnitTest

    <TestClass()>
    Public Class SearchFixture
        Private Const _accountNumber As String = "8888"

        Private ReadOnly _shellPresenter As SilverlightDataEntry.Presenters.Interfaces.IShellPresenter
        Private ReadOnly _serviceLocator As Microsoft.Practices.ServiceLocation.IServiceLocator

        <TestMethod()>
        <Tag(FixtureConstants._Synch)>
        <Description(FixtureConstants._Presenter)>
        Public Sub LoadContactsReturnsRecords()

            'Dim _container As New UnityContainer
            '_container.RegisterType(Of ILoadScreen, LoadScreenPresenter)()
            '_container.RegisterType(Of IEventHandlerFactory()
            'Interfaces.ISearchPresenter =
            Dim _presenter As New SearchPresenter(_shellPresenter, _serviceLocator) 'New UnityAdapter(_container))

            Dim _result As IResult = _presenter.LoadContacts(_accountNumber, "first", "last")
            'this execute forces the call to the web service.  ideally we would just interogate iresult for a successful test.
            'http://caliburn.codeplex.com/wikipage?title=IResult&referringTitle=Documentation
            'if we call execute we will need to build into the servicelocator all necessary registrations.
            'the impmlementation also wraps UI dialogs
            '_presenter.Execute(_result)

            Assert.IsTrue(0 = _presenter.Results.Count)


        End Sub

        <TestMethod()>
        <Tag(FixtureConstants._Synch)>
        <Description(FixtureConstants._Presenter)>
        Public Sub SearchStatusValueTesting()

            Dim _presenter As Interfaces.ISearchPresenter = New SearchPresenter(_shellPresenter, _serviceLocator)

            _presenter.Search(_accountNumber, "first", "last")
            Assert.IsTrue(_presenter.SearchStatus.Contains(_accountNumber))
        End Sub

    End Class

End Namespace