Imports System.Collections.Generic
Imports Caliburn.Core.Metadata
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Caliburn.Silverlight.ApplicationFramework
Imports SilverlightDataEntry.Presenters.Interfaces
Namespace Presenters

    <PerRequest(GetType(IQuestionPresenter))> _
    Public Class QuestionPresenter
        Inherits Presenter
        Implements IQuestionPresenter
        Private _completed As Action
        Private _questions As IEnumerable(Of Question)

        Public ReadOnly Property Questions() As IEnumerable(Of Question)
            Get
                Return _questions
            End Get
        End Property

        Public Sub Setup(ByVal questions As IEnumerable(Of Question), ByVal completed As Action) Implements IQuestionPresenter.Setup
            _completed = completed
            _questions = questions
        End Sub

        Protected Overrides Sub OnShutdown()
            MyBase.OnShutdown()

            _completed()
        End Sub
    End Class
End Namespace
