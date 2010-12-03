Imports System.Reflection
Imports Caliburn.Core
Imports Caliburn.PresentationFramework.ApplicationModel
Imports Microsoft.Practices.ServiceLocation
Imports Caliburn.Unity
Imports Microsoft.Practices.Unity

Partial Public Class App
    Inherits CaliburnApplication

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Function CreateContainer() As IServiceLocator
        Dim _container As New UnityContainer

        _container.RegisterType(Of IStateManager, DeepLinkStateManager)(New ContainerControlledLifetimeManager)
        Return New UnityAdapter(_container)
    End Function

    Protected Overrides Function SelectAssemblies() As Assembly()
        Return New Assembly() {Assembly.GetExecutingAssembly()}
    End Function

    Protected Overrides Function CreateRootModel() As Object
        Dim binder = DirectCast(Container.GetInstance(Of IBinder)(), DefaultBinder)
        binder.EnableMessageConventions()
        binder.EnableBindingConventions()

        Return Container.GetInstance(Of IShellPresenter)()
    End Function

End Class
