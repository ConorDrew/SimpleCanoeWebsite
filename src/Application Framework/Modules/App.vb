Imports System.Collections.Generic

Public Module App

    Public TheSystem As New Entity.Sys.SystemData
    Public LoginForm As FRMLogin
    Public MainForm As FRMMain
    Public DB As Entity.Sys.Database
    Public loggedInUser As Entity.Users.User
    Public WithEvents MouseHanlderEvent As New MouseHandler
    Public IsLowResolution As Boolean
    Public IsGasway As Boolean
    Public IsRFT As Boolean
    Public IsBlueflame As Boolean

#Region "Properties"

    Private _CurrentCustomerID As Integer = 0

    Public Property CurrentCustomerID() As Integer
        Get
            Return _CurrentCustomerID
        End Get
        Set(ByVal Value As Integer)
            _CurrentCustomerID = Value

            If MainForm.MenuBar.pnlSubMenu.Controls.Count = 0 Then
                Exit Property
            End If

            If CurrentCustomerID = 0 Then
                If MainForm.SelectedMenu = Entity.Sys.Enums.MenuTypes.Customers Then
                    MainForm.MenuBar.pnlSubMenu.Controls(1).Text = "Show All Properties"
                    MainForm.MenuBar.pnlSubMenu.Controls(2).Text = "Show All Appliances"
                    ViewingAllSites = True
                End If
            Else
                If MainForm.SelectedMenu = Entity.Sys.Enums.MenuTypes.Customers Then
                    MainForm.MenuBar.pnlSubMenu.Controls(1).Text = "Properties For Customer"
                    MainForm.MenuBar.pnlSubMenu.Controls(2).Text = "Show All Appliances"
                    ViewingAllSites = False
                End If
            End If
        End Set
    End Property

    Private _ViewingAllSites As Boolean = True

    Public Property ViewingAllSites() As Boolean
        Get
            Return _ViewingAllSites
        End Get
        Set(ByVal Value As Boolean)
            _ViewingAllSites = Value
        End Set
    End Property

    Private _CurrentPropertyID As Integer = 0

    Public Property CurrentPropertyID() As Integer
        Get
            Return _CurrentPropertyID
        End Get
        Set(ByVal Value As Integer)
            _CurrentPropertyID = Value

            If MainForm.MenuBar.pnlSubMenu.Controls.Count = 0 Then
                Exit Property
            End If

            If CurrentPropertyID = 0 Then
                If MainForm.SelectedMenu = Entity.Sys.Enums.MenuTypes.Customers Then
                    MainForm.MenuBar.pnlSubMenu.Controls(2).Text = "Show All Appliances"
                    ViewingAllAssets = True
                End If
            Else
                If MainForm.SelectedMenu = Entity.Sys.Enums.MenuTypes.Customers Then
                    MainForm.MenuBar.pnlSubMenu.Controls(2).Text = "Appliances For Property"
                    ViewingAllAssets = False
                End If
            End If
        End Set
    End Property

    Private _ViewingAllAssets As Boolean = True

    Public Property ViewingAllAssets() As Boolean
        Get
            Return _ViewingAllAssets
        End Get
        Set(ByVal Value As Boolean)
            _ViewingAllAssets = Value
        End Set
    End Property

    Private _dtVisit As New DataTable

    Public Property dtVisitFilters() As DataTable
        Get
            If _dtVisit.Columns.Count = 0 Then
                _dtVisit.Columns.Add("Field")
                _dtVisit.Columns.Add("Value")
                _dtVisit.Columns.Add("Type")
            End If
            Return _dtVisit
        End Get
        Set(ByVal value As DataTable)
            _dtVisit = value
        End Set
    End Property

    Private _releaseNoteTextFile As String

    Public ReadOnly Property ReleaseNoteTextFile As String
        Get
            Return _releaseNoteTextFile
        End Get
    End Property

#End Region

#Region "Application Methods"

    'Starting point of the application
    Public Sub Main()
        Try
            Application.EnableVisualStyles()
            AddHandler Application.ThreadException, AddressOf AppErrorOccurred

            Cursor.Current = Cursors.AppStarting

            Select Case TheSystem.Configuration.DBName
                Case Entity.Sys.Enums.DataBaseName.GaswayServicesFSM, Entity.Sys.Enums.DataBaseName.GaswayServicesFSM_Beta
                    IsGasway = True
                Case Entity.Sys.Enums.DataBaseName.RftFsm_Beta, Entity.Sys.Enums.DataBaseName.RftServicesFsm
                    IsRFT = True
                Case Entity.Sys.Enums.DataBaseName.BlueflameServicesFsm, Entity.Sys.Enums.DataBaseName.BlueflameServicesFsm_Beta
                    IsBlueflame = True
            End Select

            If ShowAppearanceMessage() Then

                DB = New Entity.Sys.Database

                _releaseNoteTextFile = "18.09.25_RN.txt"
                If LoginForm Is Nothing Then
                    LoginForm = Activator.CreateInstance(GetType(FRMLogin))
                End If
                LoginForm.ShowInTaskbar = True
                LoginForm.Show()
                Application.Run(LoginForm)
            Else
                Application.Exit()
            End If
        Catch ex As Exception

            Dim eventLog As New Diagnostics.EventLog
            Dim errorMsg As String = ex.Message

            If Not ex.InnerException Is Nothing Then
                errorMsg += vbCrLf + "Inner Exception:" + vbCrLf + ex.InnerException.Message
            End If

            LogError(ex.GetType().Name, errorMsg, ex.StackTrace)

            ShowMessage("Application error : " & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub AppErrorOccurred(ByVal sender As Object, ByVal t As System.Threading.ThreadExceptionEventArgs)
        If TypeOf (t.Exception) Is System.Security.SecurityException Then
            ShowMessage(t.Exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            ShowMessage("An error has occured in the application. Please contact support with the following exception : " & vbCrLf & t.Exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogError(t.GetType().Name, t.Exception.Message, t.Exception.StackTrace)
        End If
    End Sub

    'Check the operating system and screen resolution to show message to user about the design
    Private Function ShowAppearanceMessage() As Boolean
        Dim screenResolution As String = "Unknown_Width x Unknown_Height"

        screenResolution = screenResolution.Replace("Unknown_Height", Screen.PrimaryScreen.Bounds.Height.ToString)
        screenResolution = screenResolution.Replace("Unknown_Width", Screen.PrimaryScreen.Bounds.Width.ToString)

        If (Screen.PrimaryScreen.Bounds.Height <= Entity.Sys.Consts.ScreenBestResolutionHeight) Or (Screen.PrimaryScreen.Bounds.Width <= Entity.Sys.Consts.ScreenBestResolutionWidth) Then
            IsLowResolution = True
        End If

        If (Screen.PrimaryScreen.Bounds.Height < Entity.Sys.Consts.ScreenMinResolutionHeight) Or (Screen.PrimaryScreen.Bounds.Width < Entity.Sys.Consts.ScreenMinResolutionWidth) Then
            Dim message As String = "It has been detected that your screen resolution is " & screenResolution & "." & vbCrLf & vbCrLf
            message += "This application has been designed to run with a minimum screen resolution of 1024 x 730." & vbCrLf & vbCrLf
            message += "Therefore the application will not function correctly." & vbCrLf & vbCrLf
            message += "Gabriel will now exit, please contact IT support to change device resolution?"

            ShowMessage(message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False

        ElseIf (Screen.PrimaryScreen.Bounds.Height < Entity.Sys.Consts.ScreenWarningResolutionHeight) Or (Screen.PrimaryScreen.Bounds.Width < Entity.Sys.Consts.ScreenWarningResolutionWidth) Then
            Dim message As String = "It has been detected that your screen resolution is " & screenResolution & "." & vbCrLf & vbCrLf
            message += "This application has been designed to run with a screen resolution of at least 1024 x 768." & vbCrLf & vbCrLf
            message += "Therefore the application may not function correctly." & vbCrLf & vbCrLf
            message += "Would you like to continue?"

            If ShowMessage(message, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If

    End Function

    'This method is used for the opening of new form such as login, menu and any other top level forms
    Public Function ShowForm(ByVal frm As System.Type, ByVal asDialgue As Boolean, ByVal parameters() As Object, Optional ByVal IgnoreIfOpen As Boolean = False) As Form
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim newForm As Form = Nothing

            If Not IgnoreIfOpen Then
                newForm = checkIfExists(frm.Name, True)
            End If

            If newForm Is Nothing Then
                newForm = Activator.CreateInstance(frm)
                '    newForm.Icon = New Icon(newForm.GetType(), "Logo.ico")

                CType(newForm, IBaseForm).SetFormParameters = parameters

                newForm.ShowInTaskbar = False
                newForm.StartPosition = FormStartPosition.CenterScreen
                newForm.SizeGripStyle = SizeGripStyle.Hide

                If asDialgue Then

                    If Not frm.Name.ToUpper = "FRMAnswers".ToUpper And
                            Not frm.Name.ToUpper = "FRMEngineerVisit".ToUpper And
                            Not frm.Name.ToUpper = "FRMPostcodeManager".ToUpper And
                            Not frm.Name.ToUpper = "FRMStockReplenishment".ToUpper And
                            Not frm.Name.ToUpper = "FRMReceiveStock".ToUpper And
                            Not frm.Name.ToUpper = "FRMPartsToOrders".ToUpper And
                            Not frm.Name.ToUpper = "FRMAddToQuote".ToUpper And
                            Not frm.Name.ToUpper = "FRMAddToOrder".ToUpper And
                            Not frm.Name.ToUpper = "FRMOrderCharges".ToUpper And
                            Not frm.Name.ToUpper = "FRMEnterEmailAddress".ToUpper And
                            Not frm.Name.ToUpper = "FRMChooseSupplierPacks".ToUpper And
                            Not frm.Name.ToUpper = "FRMPickDespatchDetails".ToUpper And
                            Not frm.Name.ToUpper = "FRMEngineerHistory".ToUpper And
                            Not frm.Name.ToUpper = "FRMVanHistory".ToUpper And
                            Not frm.Name.ToUpper = "FRMViewContractAlternativeChargeDetails".ToUpper And
                            Not frm.Name.ToUpper = "FRMAvailableContractNos".ToUpper And
                            Not frm.Name.ToUpper = "FRMChooseAsset".ToUpper And
                            Not frm.Name.ToUpper = "FRMJobAudit".ToUpper And
                            Not frm.Name.ToUpper = "FRMRaiseInvoiceDetails".ToUpper And
                            Not frm.Name.ToUpper = "FRMConvertToAnOrder".ToUpper And
                            Not frm.Name.ToUpper = "FrmInvoicedPayment".ToUpper And
                            Not frm.Name.ToUpper = "FRMContractRenewal".ToUpper And
                            Not frm.Name.ToUpper = "FRMSiteCustomerAudit".ToUpper And
                            Not frm.Name.ToUpper = "FRMSitePopup".ToUpper And
                            Not frm.Name.ToUpper = "FRMConsolidation".ToUpper And
                            Not frm.Name.ToUpper = "FRMConsolidation_Location".ToUpper And
                            Not frm.Name.ToUpper = "FRMConvertToPDF".ToUpper And
                            Not frm.Name.ToUpper = "FRMSiteVisitManager".ToUpper And
                            Not frm.Name.ToUpper = "FRMSiteLetterList".ToUpper And
                            Not frm.Name.ToUpper = "FRMSelectLocation".ToUpper And
                            Not frm.Name.ToUpper = "FRMCreditReceived".ToUpper And
                            Not frm.Name.ToUpper = "FRMEngineerTimesheet".ToUpper And
                            Not frm.Name.ToUpper = "FRMLastServiceDate".ToUpper And
                            Not frm.Name.ToUpper = "FRMChangeInvoicedTotal".ToUpper And
                            Not frm.Name.ToUpper = "FRMChangePaymentTerms".ToUpper And
                            Not frm.Name.ToUpper = "FRMAmendServiceDate".ToUpper And
                            Not frm.Name.ToUpper = "FRMChangeSageDate".ToUpper And
                            Not frm.Name.ToUpper = "FRMJobWizard".ToUpper And
                            Not frm.Name.ToUpper = "FRMAddInvoiceAddress".ToUpper And
                            Not frm.Name.ToUpper = "FRMChangeInvoiceLine".ToUpper And
                            Not frm.Name.ToUpper = "FRMViewEngineer".ToUpper Then

                        AddHandler CType(newForm, IForm).LoadedControl.RecordsChanged, AddressOf MainForm.SetSearchResults
                        AddHandler CType(newForm, IForm).LoadedControl.StateChanged, AddressOf CType(newForm, IForm).ResetMe
                    End If

                    If frm.Name.ToUpper = "FRMQuoteRejection".ToUpper Then
                        If CType(parameters(0), UserControl).Name = "UCQuoteContractAlternative" Then
                            AddHandler CType(newForm, FRMQuoteRejection).ReasonEdited, AddressOf CType(parameters(0), UCQuoteContractAlternative).RejectReasonChanged
                        ElseIf CType(parameters(0), UserControl).Name = "UCGenerateQuote" Then
                            AddHandler CType(newForm, FRMQuoteRejection).ReasonEdited, AddressOf CType(parameters(0), UCGenerateQuote).RejectReasonChanged
                        ElseIf CType(parameters(0), UserControl).Name = "UCQuoteContractOption3" Then
                            AddHandler CType(newForm, FRMQuoteRejection).ReasonEdited, AddressOf CType(parameters(0), UCQuoteContractOption3).RejectReasonChanged
                        Else
                            AddHandler CType(newForm, FRMQuoteRejection).ReasonEdited, AddressOf CType(parameters(0), UCQuoteJob).RejectReasonChanged
                        End If
                    End If

                    If frm.Name.ToUpper = "FRMOrderRejection".ToUpper Then
                        AddHandler CType(newForm, FRMOrderRejection).ReasonEdited, AddressOf CType(parameters(0), UCOrder).ReasonChanged
                    End If

                    newForm.ShowDialog()
                    If frm.Name.ToUpper = "FRMChooseSupplierPacks".ToUpper Or
                    frm.Name.ToUpper = "FRMSelectLocation".ToUpper Or
                    frm.Name.ToUpper = "FRMLastServiceDate".ToUpper Or
                    frm.Name.ToUpper = "FRMChangeInvoicedTotal".ToUpper Or
                    frm.Name.ToUpper = "FRMChangeInvoiceLine".ToUpper Or
                    frm.Name.ToUpper = "FRMChangePaymentTerms".ToUpper Or
                    frm.Name.ToUpper = "FRMChangeSageDate".ToUpper Or
                    frm.Name.ToUpper = "FRMSiteLetterList".ToUpper Then
                        Return newForm
                    Else
                        newForm.Dispose()
                        Return Nothing
                    End If
                Else
                    CType(newForm, IBaseForm).SetFormParameters = parameters

                    newForm.MdiParent = MainForm

                    MainForm.pnlRight.Visible = False
                    MainForm.pnlContent.Controls.Clear()
                    MainForm.pnlMiddle.Visible = False

                    newForm.Show()

                    Return newForm
                End If
            Else
                CType(newForm, IBaseForm).SetFormParameters = parameters

                Select Case frm.Name.ToUpper
                    Case "FRMVisitManager".ToUpper
                        CType(newForm, FRMVisitManager).PopulateDatagrid(True)
                    Case "FRMOrderManager".ToUpper
                        CType(newForm, FRMOrderManager).PopulateDatagrid()
                    Case "FRMQuoteManager".ToUpper
                        CType(newForm, FRMQuoteManager).PopulateDatagrid()
                End Select

                Return newForm
            End If
        Catch ex As Exception
            ShowMessage("Cannot open form : " & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim msg As String = ex.Message
            If Not ex.InnerException Is Nothing Then
                msg += vbCrLf + "Inner Exception:" + vbCrLf + ex.InnerException.Message
            End If
            LogError(ex.GetType().Name, msg, ex.StackTrace)
            Return Nothing
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    'This method is used to return a boolean value for if the override password was entered correctly
    Public Function EnterOverridePassword() As Boolean

#If Not DEBUG Then
        Dim dialogue As DLGPasswordOverride
        dialogue = checkIfExists(GetType(DLGPasswordOverride).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGPasswordOverride))
        End If
        '    dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.ShowDialog()
        If dialogue.DialogResult = DialogResult.OK Then
            Return True
        Else
            ShowMessage("Incorrect password or operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        dialogue.Close()
#Else
        Return True
#End If

    End Function

    Public Function EnterOverridePasswordINV() As Boolean

#If Not DEBUG Then
        Dim dialogue As DLGPasswordOverrideINV
        dialogue = checkIfExists(GetType(DLGPasswordOverrideINV).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGPasswordOverrideINV))
        End If
        '   dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.ShowDialog()
        If dialogue.DialogResult = DialogResult.OK Then
            Return True
        Else
            ShowMessage("Incorrect password or operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        dialogue.Close()
#Else
        Return True
#End If

    End Function

    Public Function EnterOverridePassword_Service() As Boolean
        Dim dialogue As DLGPasswordOverride
        dialogue = checkIfExists(GetType(DLGPasswordOverride_Service).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGPasswordOverride_Service))
        End If
        '   dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.ShowDialog()
        If dialogue.DialogResult = DialogResult.OK Then
            Return True
        Else
            ShowMessage("Incorrect password or operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        dialogue.Close()
    End Function

    Public Function FindRecord(ByVal tableToSearchIn As Entity.Sys.Enums.TableNames, Optional ByVal ForeignKeyFilter As Integer = 0, Optional ByVal PartNumber As String = "", Optional ByVal ForMassPartEntry As Boolean = False) As Object
        Dim dialogue As DLGFindRecord
        dialogue = checkIfExists(GetType(DLGFindRecord).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGFindRecord))
        End If
        '   dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.ForMassPartEntry = ForMassPartEntry
        dialogue.ForeignKeyFilter = ForeignKeyFilter
        dialogue.PartNumber = PartNumber
        dialogue.TableToSearch = tableToSearchIn
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            If ForMassPartEntry Then
                Return dialogue.PartsToAdd
            Else
                Return dialogue.ID
            End If
        Else
            If ForMassPartEntry Then
                Return Nothing
            Else
                Return 0
            End If
        End If
        dialogue.Close()
    End Function

    Public Function FindRecord(ByVal tableToSearchIn As Entity.Sys.Enums.TableNames, ByVal trans As SqlClient.SqlTransaction, Optional ByVal ForeignKeyFilter As Integer = 0, Optional ByVal PartNumber As String = "") As Integer
        Dim dialogue As DLGFindRecord
        dialogue = checkIfExists(GetType(DLGFindRecord).Name, True)
        If dialogue Is Nothing Then
            ' Carl said use constructor
            ' dialogue = Activator.CreateInstance(GetType(DLGFindRecord))
            dialogue = New DLGFindRecord(trans)
        End If

        '  dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.ForeignKeyFilter = ForeignKeyFilter
        dialogue.PartNumber = PartNumber
        dialogue.TableToSearch = tableToSearchIn
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Return dialogue.ID
        Else
            Return 0
        End If
        dialogue.Close()
    End Function

    Public Function PickPartProductSupplier(ByVal tableToSearchIn As Entity.Sys.Enums.TableNames, ByVal PartOrProductID As Integer) As Integer
        Dim dialogue As DLGPickPartProductSupplier
        dialogue = checkIfExists(GetType(DLGPickPartProductSupplier).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGPickPartProductSupplier))
        End If
        '  dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.ID = PartOrProductID
        dialogue.TableToSearch = tableToSearchIn
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Return dialogue.ID
        Else
            Return 0
        End If
        dialogue.Close()
    End Function

    Public Function FindRecordMultiId(ByVal tableToSearchIn As Entity.Sys.Enums.TableNames, ByVal foreignKeyFilter As List(Of Integer)) As Integer
        Dim dialogue As DLGFindRecord
        dialogue = checkIfExists(GetType(DLGFindRecord).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGFindRecord))
        End If
        '  dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.ForeignKeyFilters = foreignKeyFilter
        dialogue.TableToSearch = tableToSearchIn
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            Return dialogue.ID
        Else
            Return 0
        End If
        dialogue.Close()
    End Function

    'If a form already exists, then use it so give focus
    Public Function checkIfExists(ByVal formIn As String, ByVal giveFocus As Boolean) As Form
        For Each form As Form In MainForm.MdiChildren
            If LCase(form.Name) = LCase(formIn) Then
                If giveFocus Then
                    form.Focus()
                End If
                Return form
            End If
        Next
        Return Nothing
    End Function

    'Log the user in
    Public Sub Login()
        If MainForm Is Nothing Then
            MainForm = Activator.CreateInstance(GetType(FRMMain))
        End If
        MainForm.ShowInTaskbar = True
        MainForm.Show()
        LoginForm.Hide()

        Try
            Dim settings As Entity.Management.Settings = DB.Manager.Get()
            Dim WorkingHoursStart As New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursStart.Split(":")(0), settings.WorkingHoursStart.Split(":")(1), 0)
            Dim WorkingHoursEnd As New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursEnd.Split(":")(0), settings.WorkingHoursEnd.Split(":")(1), 0)

            Dim outOfHours As String = IIf(Now > WorkingHoursStart And Now < WorkingHoursEnd, "0", "1")

            Select Case TheSystem.DataBaseServerType
                Case Entity.Sys.Enums.DatabaseSystems.Microsoft_SQL_Server
                    DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) " & "VALUES (GETDATE(), " & loggedInUser.UserID & ", 'LOGON', 'HIDDEN', 'Authenticate'," & outOfHours & ")", False)
                Case Entity.Sys.Enums.DatabaseSystems.MySQL
                    DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) " & "VALUES (Now(), " & loggedInUser.UserID & ", 'LOGON', 'HIDDEN', 'Authenticate'," & outOfHours & ")", False)
            End Select
        Catch
            'DO NOTHING
        End Try

    End Sub

    'Log the user out of the system
    Public Sub Logout()

        If ShowMessage("Are you sure you want to logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim forms As New List(Of Form)
            For Each form As Form In Application.OpenForms
                forms.Add(form)
            Next

            For i As Integer = 0 To forms.Count - 1
                Dim form As Form = forms(i)
                Select Case form.Name
                    Case MainForm.Name
                    Case LoginForm.Name
                    Case Else
                        form.Dispose()
                End Select
            Next

            If DB IsNot Nothing Then DB.JobLock.DeleteAll()
            loggedInUser = Nothing
            MainForm.Hide()
            MainForm = Nothing
            LoginForm.Show()
        End If

    End Sub

    'Close the application
    Public Sub CloseApplication()

        If ShowMessage("Are you sure you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If

    End Sub

#End Region

#Region "Helper Methods"

    Public Function ShowMessage(ByVal MessageText As String, ByVal MessageBoxButton As MessageBoxButtons, ByVal MessagesBoxIcon As MessageBoxIcon) As DialogResult
        Return MessageBox.Show(MessageText, TheSystem.Title, MessageBoxButton, MessagesBoxIcon)
    End Function

    Public Function ShowMessageWithDetails(ByVal title As String, ByVal messageText As String, ByVal details As List(Of String)) As DialogResult
        Dim detailsStr As String = String.Join(Environment.NewLine, details.ToArray())
        Dim dialogTypeName As String = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg"
        Dim dialogType As Type = GetType(Form).Assembly.[GetType](dialogTypeName)
        Dim dialog As Form = CType(Activator.CreateInstance(dialogType, New PropertyGrid()), Form)

        dialog.Text = title
        dialogType.GetProperty("Message").SetValue(dialog, messageText, Nothing)
        dialogType.GetProperty("Details").SetValue(dialog, detailsStr, Nothing)
        Dim result As DialogResult = dialog.ShowDialog()
        Return result
    End Function

    Public Sub ShowSecurityError()
        Dim msg As String = "You do not have the necessary security permissions." & vbCrLf & vbCrLf &
            "Contact your administrator if you think this is wrong or you need the permissions changing."
        Throw New Security.SecurityException(msg)
    End Sub

    Public Sub LogError(ByVal errorType As String, ByVal errorMsg As String, ByVal stackTrace As String)
        If loggedInUser IsNot Nothing AndAlso Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) Then
            Exit Sub
        End If
#If Not DEBUG Then
        Dim email As New Entity.Sys.Emails
        email.To = Entity.Sys.EmailAddress.AutomatedReports
        email.From = Entity.Sys.EmailAddress.Gabriel
        email.Subject = "Gabriel Error on " & Now.ToString("dd/MM/yyyy hh:mm:ss") & " caused by " & loggedInUser?.Fullname
        email.Body = "<p>Hi, <br/><br/>"
        email.Body += "An " & errorType & " error occurred on Gabriel on " & Now.ToString("dd/MM/yyyy hh:mm:ss") & " caused by " & loggedInUser?.Fullname & "<br/><br/>"
        email.Body += "Error Message: " & errorMsg & "<br/><br/>"
        email.Body += "Stack Trace: " & stackTrace & "<br/><br/>"
        email.Body += "Kind regards," & "<br/><br/>"
        email.Body += "Gabriel"
        email.SendMe = True
        email.Send()
#End If
    End Sub

#End Region

#Region "SaveChangesCode"

    Public ControlLoading As Boolean = False
    Public ControlChanged As Boolean = False

    Public Sub AddChangeHandlers(ByVal controlToLoop As Control)
        For Each cntrl As Control In controlToLoop.Controls
            Select Case cntrl.GetType.Name
                Case "TabControl", "TabPage", "GroupBox", "Panel"
                    AddChangeHandlers(cntrl)
                Case "ComboBox"
                    AddHandler CType(cntrl, ComboBox).SelectedIndexChanged, AddressOf AnythingChanges
                Case "CheckBox"
                    AddHandler CType(cntrl, CheckBox).CheckedChanged, AddressOf AnythingChanges
                Case "NumericUpDown"
                    AddHandler CType(cntrl, NumericUpDown).Click, AddressOf AnythingChanges
                Case "DateTimePicker"
                    AddHandler CType(cntrl, DateTimePicker).ValueChanged, AddressOf AnythingChanges
                Case "TextBox"
                    AddHandler CType(cntrl, TextBox).TextChanged, AddressOf AnythingChanges
                Case "RadioButton"
                    AddHandler CType(cntrl, RadioButton).CheckedChanged, AddressOf AnythingChanges
            End Select
        Next
    End Sub

    Public Sub AnythingChanges(ByVal sender As Object, ByVal e As System.EventArgs)
        If ControlLoading = False Then
            ControlChanged = True
        End If
    End Sub

#End Region

End Module