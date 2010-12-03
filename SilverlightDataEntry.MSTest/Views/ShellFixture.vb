Imports Microsoft.Silverlight.Testing
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SilverlightDataEntry.Views
Imports System.ComponentModel.DataAnnotations

Namespace SilverlightUnitTest

    <TestClass()>
    Public Class ShellFixture
        Inherits SilverlightTest

        <TestMethod()>
        <Asynchronous()>
        Public Sub Page_Initialized_ShouldHaveATitleTextBlock()

            Dim _page As New ShellView

            WaitFor(_page, "Loaded")

            TestPanel.Children.Add(_page)
            EnqueueCallback(Sub() Assert.IsTrue(_page.AppTitle IsNot Nothing))

            EnqueueTestComplete()
            TestPanel.Children.Remove(_page)
        End Sub

        <TestMethod()>
        <Asynchronous()>
        Public Sub Page_Initialized_ShouldHaveATitleTextBlockWithSpecifiedText()

            Dim _page As New ShellView

            WaitFor(_page, "Loaded")

            TestPanel.Children.Add(_page)
            EnqueueCallback(Sub() Assert.IsTrue(_page.AppTitle.Text = "Silverlight Data Entry"))

            EnqueueTestComplete()
            TestPanel.Children.Remove(_page)
        End Sub

        '<TestMethod()>
        '<Asynchronous()>
        'Public Sub Page_Initialized_ClickTitleTextBlock()

        '    Dim _page As New ShellView

        '    WaitFor(_page, "Loaded")

        '    TestPanel.Children.Add(_page)

        '    EnqueueCallback(Sub() Assert.IsTrue(_page.AppTitle.Text = "Silverlight Data Entry"))

        '    EnqueueTestComplete()
        '    TestPanel.Children.Remove(_page)
        'End Sub

        <TestMethod()>
        <Asynchronous()>
        Public Sub Page_Initialized_ShouldHaveADisplayTextBlock()

            Dim _page As New ShellView

            WaitFor(_page, "Loaded")

            TestPanel.Children.Add(_page)
            EnqueueCallback(Sub() Assert.IsTrue(_page.DisplayTitle IsNot Nothing))

            EnqueueTestComplete()
            TestPanel.Children.Remove(_page)
        End Sub

        <TestMethod()>
        <Asynchronous()>
        Public Sub Page_Initialized_ShouldHaveADisplayTextBlockWithSpecifiedText()

            Dim _page As New ShellView

            WaitFor(_page, "Loaded")

            TestPanel.Children.Add(_page)
            EnqueueCallback(Sub() Assert.IsTrue(_page.DisplayTitle.Text = String.Empty))

            EnqueueTestComplete()
            TestPanel.Children.Remove(_page)

        End Sub


        Public Sub WaitFor(Of T)(ByVal objectToWaitForItsEvent As T, ByVal eventName As String)


            Dim eventInfo As Reflection.EventInfo = objectToWaitForItsEvent.[GetType]().GetEvent(eventName)
            Dim eventRaised As Boolean = False

            If GetType(RoutedEventHandler).IsAssignableFrom(eventInfo.EventHandlerType) Then

                eventInfo.AddEventHandler(objectToWaitForItsEvent, DirectCast(Sub() eventRaised = True, RoutedEventHandler))

            ElseIf GetType(EventHandler).IsAssignableFrom(eventInfo.EventHandlerType) Then

                eventInfo.AddEventHandler(objectToWaitForItsEvent, DirectCast(Sub() eventRaised = True, EventHandler))
            End If

            EnqueueConditional(Function() eventRaised)
        End Sub


    End Class
End Namespace