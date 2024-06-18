Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Security.ClientServer

' For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Web.WebApplication
Partial Public Class Demo3DEAspNetApplication
    Inherits WebApplication
    Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
    Private module3 As Demo3DE.Module.Demo3DEModule
    Private module4 As Demo3DE.Module.Web.Demo3DEAspNetModule

    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Private securityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex
    Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
    Private auditTrailModule As DevExpress.ExpressApp.AuditTrail.AuditTrailModule
    Private objectsModule As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private conditionalAppearanceModule As DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule
    Private mapsAspNetModule As DevExpress.ExpressApp.Maps.Web.MapsAspNetModule
    Private scriptRecorderModuleBase As DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase
    Private scriptRecorderAspNetModule As DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule
    Private validationModule As DevExpress.ExpressApp.Validation.ValidationModule
    Private validationAspNetModule As DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Function CreateViewUrlManager() As IViewUrlManager
        Return New ViewUrlManager()
    End Function

    Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
        args.ObjectSpaceProvider = New SecuredObjectSpaceProvider(DirectCast(Me.Security, ISelectDataSecurityProvider), GetDataStoreProvider(args.ConnectionString, args.Connection), True)
        args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
    End Sub
    Private Function GetDataStoreProvider(ByVal connectionString As String, ByVal connection As System.Data.IDbConnection) As IXpoDataStoreProvider
        Dim application As System.Web.HttpApplicationState = If((System.Web.HttpContext.Current IsNot Nothing), System.Web.HttpContext.Current.Application, Nothing)
        Dim dataStoreProvider As IXpoDataStoreProvider = Nothing
        If Not application Is Nothing AndAlso application("DataStoreProvider") IsNot Nothing Then
            dataStoreProvider = TryCast(application("DataStoreProvider"), IXpoDataStoreProvider)
        Else
		    dataStoreProvider = XPObjectSpaceProvider.GetDataStoreProvider(connectionString, connection, True)
            If Not application Is Nothing Then
                application("DataStoreProvider") = dataStoreProvider
            End If
        End If
        Return dataStoreProvider
    End Function
    Private Sub Demo3DEAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
        e.Updater.Update()
        e.Handled = True
#Else
        If System.Diagnostics.Debugger.IsAttached Then
            e.Updater.Update()
            e.Handled = True
        Else
            Dim message As String = "The application cannot connect to the specified database, " & _
				"because the database doesn't exist, its version is older " & _
				"than that of the application or its schema does not match " & _
				"the ORM data model structure. To avoid this error, use one " & _
				"of the solutions from the https://www.devexpress.com/kb=T367835 KB Article."

            If e.CompatibilityError IsNot Nothing AndAlso e.CompatibilityError.Exception IsNot Nothing Then
                message &= Constants.vbCrLf & Constants.vbCrLf & "Inner exception: " & e.CompatibilityError.Exception.Message
            End If
            Throw New InvalidOperationException(message)
        End If
#End If
    End Sub
    Private Sub InitializeComponent()
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
        Me.module3 = New Demo3DE.Module.Demo3DEModule()
        Me.module4 = New Demo3DE.Module.Web.Demo3DEAspNetModule()
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.securityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex()
        Me.securityStrategyComplex1.SupportNavigationPermissionsForTypes = False
        Me.authenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
        Me.auditTrailModule = New DevExpress.ExpressApp.AuditTrail.AuditTrailModule()
        Me.objectsModule = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
        Me.conditionalAppearanceModule = New DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule()
        Me.mapsAspNetModule = New DevExpress.ExpressApp.Maps.Web.MapsAspNetModule()
        Me.scriptRecorderModuleBase = New DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase()
        Me.scriptRecorderAspNetModule = New DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule()
        Me.validationModule = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.validationAspNetModule = New DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule()
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
        ' Demo3DEAspNetApplication
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
        Me.Modules.Add(Me.mapsAspNetModule)
        Me.Modules.Add(Me.scriptRecorderModuleBase)
        Me.Modules.Add(Me.scriptRecorderAspNetModule)
        Me.Modules.Add(Me.validationModule)
        Me.Modules.Add(Me.validationAspNetModule)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub
End Class

