﻿#ExternalChecksum("C:\Users\amaurer\Documents\Visual Studio 2010\Projects\SilverLightDataEntry\SilverlightDataEntry\Views\SettingsView.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","B9090CCFF32887BCFB33BAEB14BCA35D")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.1
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Automation.Peers
Imports System.Windows.Automation.Provider
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Interop
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Resources
Imports System.Windows.Shapes
Imports System.Windows.Threading


Namespace Views
    
    <Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
    Partial Public Class SettingsView
        Inherits System.Windows.Controls.UserControl
        
        Friend WithEvents LayoutRoot As System.Windows.Controls.Grid
        
        Friend WithEvents SelectedAppointmentType As System.Windows.Controls.ComboBox
        
        Friend WithEvents Save As System.Windows.Controls.Button
        
        Friend WithEvents Cancel As System.Windows.Controls.Button
        
        Private _contentLoaded As Boolean
        
        '''<summary>
        '''InitializeComponent
        '''</summary>
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub InitializeComponent()
            If _contentLoaded Then
                Return
            End If
            _contentLoaded = true
            System.Windows.Application.LoadComponent(Me, New System.Uri("/SilverlightDataEntry;component/Views/SettingsView.xaml", System.UriKind.Relative))
            Me.LayoutRoot = CType(Me.FindName("LayoutRoot"),System.Windows.Controls.Grid)
            Me.SelectedAppointmentType = CType(Me.FindName("SelectedAppointmentType"),System.Windows.Controls.ComboBox)
            Me.Save = CType(Me.FindName("Save"),System.Windows.Controls.Button)
            Me.Cancel = CType(Me.FindName("Cancel"),System.Windows.Controls.Button)
        End Sub
    End Class
End Namespace

