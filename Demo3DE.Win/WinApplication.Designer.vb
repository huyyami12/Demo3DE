Imports Microsoft.VisualBasic
Imports System

Partial Public Class Demo3DEWindowsFormsApplication
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso (Not components Is Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

#Region "Component Designer generated code"

	''' <summary> 
	''' Required method for Designer support - do not modify 
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
		Me.module3 = New Global.Demo3DE.Module.Demo3DEModule()
		Me.module4 = New Global.Demo3DE.Module.Win.Demo3DEWindowsFormsModule()
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.securityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex()
        Me.securityStrategyComplex1.SupportNavigationPermissionsForTypes = False
        Me.auditTrailModule = New DevExpress.ExpressApp.AuditTrail.AuditTrailModule()
        Me.objectsModule = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
        Me.conditionalAppearanceModule = New DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule()
        Me.scriptRecorderModuleBase = New DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase()
        Me.scriptRecorderWindowsFormsModule = New DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule()
        Me.validationModule = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.validationWindowsFormsModule = New DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule()
        Me.authenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
		CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        ' 
        ' securityStrategyComplex1
        ' 
        Me.securityStrategyComplex1.Authentication = Me.authenticationStandard1
        Me.securityStrategyComplex1.RoleType = GetType(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole)
        ' ApplicationUser descends from PermissionPolicyUser and supports OAuth authentication. For more information, refer to the following help topic: https://docs.devexpress.com/eXpressAppFramework/402197
        ' If your application uses PermissionPolicyUser or a custom user type, set the UserType property as follows:
        Me.securityStrategyComplex1.UserType = GetType(Demo3DE.Module.BusinessObjects.ApplicationUser)
        ' 
        ' securityModule1
        ' 
        Me.securityModule1.UserType = GetType(Demo3DE.Module.BusinessObjects.ApplicationUser)
        ' 
        ' authenticationStandard1
        ' 
        Me.authenticationStandard1.LogonParametersType = GetType(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters)
        ' ApplicationUserLoginInfo is only necessary for applications that use the ApplicationUser user type.
        ' Comment out the following line if using PermissionPolicyUser or a custom user type.
        Me.authenticationStandard1.UserLoginInfoType = GetType(Demo3DE.Module.BusinessObjects.ApplicationUserLoginInfo)
        '
        ' auditTrailModule
        '
        Me.auditTrailModule.AuditDataItemPersistentType = GetType(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent)
        '
        ' validationModule
        '
        Me.validationModule.AllowValidationDetailsAccess = False
        ' 
		' Demo3DEWindowsFormsApplication
		' 
        Me.ApplicationName = "Demo3DE"
        Me.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema
        Me.Modules.Add(Me.module1)
		Me.Modules.Add(Me.module2)
		Me.Modules.Add(Me.module3)
		Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.securityModule1)
        Me.Security = Me.securityStrategyComplex1
        Me.Modules.Add(Me.auditTrailModule)
        Me.Modules.Add(Me.objectsModule)
        Me.Modules.Add(Me.conditionalAppearanceModule)
        Me.Modules.Add(Me.scriptRecorderModuleBase)
        Me.Modules.Add(Me.scriptRecorderWindowsFormsModule)
        Me.Modules.Add(Me.validationModule)
        Me.Modules.Add(Me.validationWindowsFormsModule)
        Me.UseOldTemplates = False

		CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

	End Sub

#End Region

	Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
	Private module3 As Global.Demo3DE.Module.Demo3DEModule
    Private module4 As Global.Demo3DE.Module.Win.Demo3DEWindowsFormsModule
    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Private securityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex
    Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
    Private auditTrailModule As DevExpress.ExpressApp.AuditTrail.AuditTrailModule
    Private objectsModule As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private conditionalAppearanceModule As DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule
    Private scriptRecorderModuleBase As DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase
    Private scriptRecorderWindowsFormsModule As DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule
    Private validationModule As DevExpress.ExpressApp.Validation.ValidationModule
    Private validationWindowsFormsModule As DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule
End Class
