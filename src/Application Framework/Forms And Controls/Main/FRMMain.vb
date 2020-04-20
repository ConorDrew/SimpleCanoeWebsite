Imports System.Collections.Generic
Imports System.IO
Imports FSM.Entity.Sys

Public Class FRMMain : Inherits System.Windows.Forms.Form : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents MnuMainNav As System.Windows.Forms.MainMenu

    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChangeLogin As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLogout As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuContactSheet As System.Windows.Forms.MenuItem
    Friend WithEvents infoBar As System.Windows.Forms.StatusBar
    Friend WithEvents mnuSystemHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSetup As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReports As System.Windows.Forms.MenuItem
    Friend WithEvents pnlMiddle As System.Windows.Forms.Panel
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents pnlMiddleTitle As System.Windows.Forms.Panel
    Friend WithEvents btnCloseMiddle As System.Windows.Forms.Button
    Friend WithEvents dgSearchResults As System.Windows.Forms.DataGrid
    Friend WithEvents splitLeftAndMiddle As System.Windows.Forms.Splitter
    Friend WithEvents splitMiddleTop As System.Windows.Forms.Splitter
    Friend WithEvents splitMiddleBottom As System.Windows.Forms.Splitter
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents lblMiddleTitle As System.Windows.Forms.Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnleHeaderRight As System.Windows.Forms.Panel
    Friend WithEvents lblRightTitle As System.Windows.Forms.Label
    Friend WithEvents btnCloseRight As System.Windows.Forms.Button
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlButtonsRight As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents mnuCustomers As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSpares As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStaff As System.Windows.Forms.MenuItem
    Friend WithEvents mnuJobs As System.Windows.Forms.MenuItem
    Friend WithEvents mnuInvoicing As System.Windows.Forms.MenuItem
    Friend WithEvents mnuScheduler As System.Windows.Forms.MenuItem
    Friend WithEvents btnHQ As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents mnuVan As MenuItem
    Friend WithEvents mnuNpPrint As MenuItem
    Friend WithEvents mnuUpstairs As MenuItem
    Friend WithEvents mnuDownstairs As MenuItem
    Friend WithEvents ContainerMiddlePanelBtns As TableLayoutPanel
    Friend WithEvents splitMiddleAndRight As Splitter
    Friend WithEvents btnGoBack As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMMain))
        Me.MnuMainNav = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuChangeLogin = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuLogout = New System.Windows.Forms.MenuItem()
        Me.mnuCustomers = New System.Windows.Forms.MenuItem()
        Me.mnuSpares = New System.Windows.Forms.MenuItem()
        Me.mnuStaff = New System.Windows.Forms.MenuItem()
        Me.mnuJobs = New System.Windows.Forms.MenuItem()
        Me.mnuScheduler = New System.Windows.Forms.MenuItem()
        Me.mnuInvoicing = New System.Windows.Forms.MenuItem()
        Me.mnuReports = New System.Windows.Forms.MenuItem()
        Me.mnuVan = New System.Windows.Forms.MenuItem()
        Me.mnuSetup = New System.Windows.Forms.MenuItem()
        Me.mnuSystemHelp = New System.Windows.Forms.MenuItem()
        Me.mnuContactSheet = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.mnuNpPrint = New System.Windows.Forms.MenuItem()
        Me.mnuUpstairs = New System.Windows.Forms.MenuItem()
        Me.mnuDownstairs = New System.Windows.Forms.MenuItem()
        Me.infoBar = New System.Windows.Forms.StatusBar()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.splitLeftAndMiddle = New System.Windows.Forms.Splitter()
        Me.pnlMiddle = New System.Windows.Forms.Panel()
        Me.dgSearchResults = New System.Windows.Forms.DataGrid()
        Me.splitMiddleTop = New System.Windows.Forms.Splitter()
        Me.pnlMiddleTitle = New System.Windows.Forms.Panel()
        Me.btnCloseMiddle = New System.Windows.Forms.Button()
        Me.lblMiddleTitle = New System.Windows.Forms.Label()
        Me.splitMiddleBottom = New System.Windows.Forms.Splitter()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.ContainerMiddlePanelBtns = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pnleHeaderRight = New System.Windows.Forms.Panel()
        Me.btnHQ = New System.Windows.Forms.Button()
        Me.btnCloseRight = New System.Windows.Forms.Button()
        Me.lblRightTitle = New System.Windows.Forms.Label()
        Me.pnlButtonsRight = New System.Windows.Forms.Panel()
        Me.btnGoBack = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.splitMiddleAndRight = New System.Windows.Forms.Splitter()
        Me.pnlMiddle.SuspendLayout()
        CType(Me.dgSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMiddleTitle.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.ContainerMiddlePanelBtns.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.pnleHeaderRight.SuspendLayout()
        Me.pnlButtonsRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMainNav
        '
        Me.MnuMainNav.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuCustomers, Me.mnuSpares, Me.mnuStaff, Me.mnuJobs, Me.mnuScheduler, Me.mnuInvoicing, Me.mnuReports, Me.mnuVan, Me.mnuSetup, Me.mnuSystemHelp, Me.mnuNpPrint})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuChangeLogin, Me.MenuItem3, Me.mnuLogout})
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        '
        'mnuChangeLogin
        '
        Me.mnuChangeLogin.Index = 0
        resources.ApplyResources(Me.mnuChangeLogin, "mnuChangeLogin")
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        resources.ApplyResources(Me.MenuItem3, "MenuItem3")
        '
        'mnuLogout
        '
        Me.mnuLogout.Index = 2
        resources.ApplyResources(Me.mnuLogout, "mnuLogout")
        '
        'mnuCustomers
        '
        Me.mnuCustomers.Index = 1
        resources.ApplyResources(Me.mnuCustomers, "mnuCustomers")
        '
        'mnuSpares
        '
        Me.mnuSpares.Index = 2
        resources.ApplyResources(Me.mnuSpares, "mnuSpares")
        '
        'mnuStaff
        '
        Me.mnuStaff.Index = 3
        resources.ApplyResources(Me.mnuStaff, "mnuStaff")
        '
        'mnuJobs
        '
        Me.mnuJobs.Index = 4
        resources.ApplyResources(Me.mnuJobs, "mnuJobs")
        '
        'mnuScheduler
        '
        Me.mnuScheduler.Index = 5
        resources.ApplyResources(Me.mnuScheduler, "mnuScheduler")
        '
        'mnuInvoicing
        '
        Me.mnuInvoicing.Index = 6
        resources.ApplyResources(Me.mnuInvoicing, "mnuInvoicing")
        '
        'mnuReports
        '
        Me.mnuReports.Index = 7
        resources.ApplyResources(Me.mnuReports, "mnuReports")
        '
        'mnuVan
        '
        Me.mnuVan.Index = 8
        resources.ApplyResources(Me.mnuVan, "mnuVan")
        '
        'mnuSetup
        '
        Me.mnuSetup.Index = 9
        resources.ApplyResources(Me.mnuSetup, "mnuSetup")
        '
        'mnuSystemHelp
        '
        Me.mnuSystemHelp.Index = 10
        Me.mnuSystemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuContactSheet, Me.MenuItem15, Me.mnuAbout})
        resources.ApplyResources(Me.mnuSystemHelp, "mnuSystemHelp")
        '
        'mnuContactSheet
        '
        Me.mnuContactSheet.Index = 0
        resources.ApplyResources(Me.mnuContactSheet, "mnuContactSheet")
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 1
        resources.ApplyResources(Me.MenuItem15, "MenuItem15")
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 2
        resources.ApplyResources(Me.mnuAbout, "mnuAbout")
        '
        'mnuNpPrint
        '
        Me.mnuNpPrint.Index = 11
        Me.mnuNpPrint.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuUpstairs, Me.mnuDownstairs})
        resources.ApplyResources(Me.mnuNpPrint, "mnuNpPrint")
        '
        'mnuUpstairs
        '
        Me.mnuUpstairs.Index = 0
        resources.ApplyResources(Me.mnuUpstairs, "mnuUpstairs")
        '
        'mnuDownstairs
        '
        Me.mnuDownstairs.Index = 1
        resources.ApplyResources(Me.mnuDownstairs, "mnuDownstairs")
        '
        'infoBar
        '
        resources.ApplyResources(Me.infoBar, "infoBar")
        Me.infoBar.Name = "infoBar"
        Me.infoBar.SizingGrip = False
        '
        'pnlLeft
        '
        Me.pnlLeft.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.pnlLeft, "pnlLeft")
        Me.pnlLeft.Name = "pnlLeft"
        '
        'splitLeftAndMiddle
        '
        Me.splitLeftAndMiddle.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer))
        resources.ApplyResources(Me.splitLeftAndMiddle, "splitLeftAndMiddle")
        Me.splitLeftAndMiddle.Name = "splitLeftAndMiddle"
        Me.splitLeftAndMiddle.TabStop = False
        '
        'pnlMiddle
        '
        Me.pnlMiddle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlMiddle.Controls.Add(Me.dgSearchResults)
        Me.pnlMiddle.Controls.Add(Me.splitMiddleTop)
        Me.pnlMiddle.Controls.Add(Me.pnlMiddleTitle)
        Me.pnlMiddle.Controls.Add(Me.splitMiddleBottom)
        Me.pnlMiddle.Controls.Add(Me.pnlButtons)
        resources.ApplyResources(Me.pnlMiddle, "pnlMiddle")
        Me.pnlMiddle.Name = "pnlMiddle"
        '
        'dgSearchResults
        '
        Me.dgSearchResults.DataMember = ""
        resources.ApplyResources(Me.dgSearchResults, "dgSearchResults")
        Me.dgSearchResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSearchResults.Name = "dgSearchResults"
        '
        'splitMiddleTop
        '
        Me.splitMiddleTop.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me.splitMiddleTop, "splitMiddleTop")
        Me.splitMiddleTop.Name = "splitMiddleTop"
        Me.splitMiddleTop.TabStop = False
        '
        'pnlMiddleTitle
        '
        resources.ApplyResources(Me.pnlMiddleTitle, "pnlMiddleTitle")
        Me.pnlMiddleTitle.Controls.Add(Me.btnCloseMiddle)
        Me.pnlMiddleTitle.Controls.Add(Me.lblMiddleTitle)
        Me.pnlMiddleTitle.Name = "pnlMiddleTitle"
        '
        'btnCloseMiddle
        '
        resources.ApplyResources(Me.btnCloseMiddle, "btnCloseMiddle")
        Me.btnCloseMiddle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCloseMiddle.Name = "btnCloseMiddle"
        '
        'lblMiddleTitle
        '
        Me.lblMiddleTitle.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lblMiddleTitle, "lblMiddleTitle")
        Me.lblMiddleTitle.ForeColor = System.Drawing.Color.White
        Me.lblMiddleTitle.Name = "lblMiddleTitle"
        '
        'splitMiddleBottom
        '
        Me.splitMiddleBottom.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me.splitMiddleBottom, "splitMiddleBottom")
        Me.splitMiddleBottom.Name = "splitMiddleBottom"
        Me.splitMiddleBottom.TabStop = False
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.White
        Me.pnlButtons.Controls.Add(Me.ContainerMiddlePanelBtns)
        resources.ApplyResources(Me.pnlButtons, "pnlButtons")
        Me.pnlButtons.Name = "pnlButtons"
        '
        'ContainerMiddlePanelBtns
        '
        resources.ApplyResources(Me.ContainerMiddlePanelBtns, "ContainerMiddlePanelBtns")
        Me.ContainerMiddlePanelBtns.Controls.Add(Me.btnExport, 2, 0)
        Me.ContainerMiddlePanelBtns.Controls.Add(Me.btnAddNew, 0, 0)
        Me.ContainerMiddlePanelBtns.Controls.Add(Me.btnDelete, 1, 0)
        Me.ContainerMiddlePanelBtns.Name = "ContainerMiddlePanelBtns"
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.BackColor = System.Drawing.SystemColors.Control
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.Name = "btnExport"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnAddNew
        '
        resources.ApplyResources(Me.btnAddNew, "btnAddNew")
        Me.btnAddNew.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'pnlRight
        '
        resources.ApplyResources(Me.pnlRight, "pnlRight")
        Me.pnlRight.BackColor = System.Drawing.Color.White
        Me.pnlRight.Controls.Add(Me.Splitter2)
        Me.pnlRight.Controls.Add(Me.pnlContent)
        Me.pnlRight.Controls.Add(Me.Splitter1)
        Me.pnlRight.Controls.Add(Me.pnleHeaderRight)
        Me.pnlRight.Controls.Add(Me.pnlButtonsRight)
        Me.pnlRight.Name = "pnlRight"
        '
        'Splitter2
        '
        Me.Splitter2.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me.Splitter2, "Splitter2")
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.TabStop = False
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pnlContent, "pnlContent")
        Me.pnlContent.Name = "pnlContent"
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me.Splitter1, "Splitter1")
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.TabStop = False
        '
        'pnleHeaderRight
        '
        resources.ApplyResources(Me.pnleHeaderRight, "pnleHeaderRight")
        Me.pnleHeaderRight.Controls.Add(Me.btnHQ)
        Me.pnleHeaderRight.Controls.Add(Me.btnCloseRight)
        Me.pnleHeaderRight.Controls.Add(Me.lblRightTitle)
        Me.pnleHeaderRight.Name = "pnleHeaderRight"
        '
        'btnHQ
        '
        resources.ApplyResources(Me.btnHQ, "btnHQ")
        Me.btnHQ.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHQ.Name = "btnHQ"
        '
        'btnCloseRight
        '
        resources.ApplyResources(Me.btnCloseRight, "btnCloseRight")
        Me.btnCloseRight.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCloseRight.Name = "btnCloseRight"
        '
        'lblRightTitle
        '
        Me.lblRightTitle.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lblRightTitle, "lblRightTitle")
        Me.lblRightTitle.ForeColor = System.Drawing.Color.White
        Me.lblRightTitle.Name = "lblRightTitle"
        '
        'pnlButtonsRight
        '
        Me.pnlButtonsRight.BackColor = System.Drawing.Color.White
        Me.pnlButtonsRight.Controls.Add(Me.btnGoBack)
        Me.pnlButtonsRight.Controls.Add(Me.btnSave)
        resources.ApplyResources(Me.pnlButtonsRight, "pnlButtonsRight")
        Me.pnlButtonsRight.Name = "pnlButtonsRight"
        '
        'btnGoBack
        '
        Me.btnGoBack.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.btnGoBack, "btnGoBack")
        Me.btnGoBack.Name = "btnGoBack"
        Me.btnGoBack.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Name = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'splitMiddleAndRight
        '
        resources.ApplyResources(Me.splitMiddleAndRight, "splitMiddleAndRight")
        Me.splitMiddleAndRight.Name = "splitMiddleAndRight"
        Me.splitMiddleAndRight.TabStop = False
        '
        'FRMMain
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.Add(Me.splitMiddleAndRight)
        Me.Controls.Add(Me.pnlRight)
        Me.Controls.Add(Me.pnlMiddle)
        Me.Controls.Add(Me.splitLeftAndMiddle)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.infoBar)
        Me.IsMdiContainer = True
        Me.Menu = Me.MnuMainNav
        Me.Name = "FRMMain"
        Me.ShowIcon = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMiddle.ResumeLayout(False)
        CType(Me.dgSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMiddleTitle.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ContainerMiddlePanelBtns.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.pnleHeaderRight.ResumeLayout(False)
        Me.pnlButtonsRight.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        Dim menu As New UCSideBar
        menu.Dock = DockStyle.Fill
        Me.pnlLeft.Controls.Add(menu)

        _FormButtons = New ArrayList
        LoopControls(Me)
        SetupButtonMouseOvers()

        UpdateMessage()
        mnuNpPrint.Visible = loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.NeopostPrint)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _FormButtons As ArrayList = Nothing

    Public Property FormButtons() As ArrayList
        Get
            Return _FormButtons
        End Get
        Set(ByVal Value As ArrayList)
            _FormButtons = Value
        End Set
    End Property

    Public ReadOnly Property MenuBar() As UCSideBar
        Get
            Return Me.pnlLeft.Controls(0)
        End Get
    End Property

    Private _SelectedMenu As Entity.Sys.Enums.MenuTypes = Entity.Sys.Enums.MenuTypes.NONE

    Public Property SelectedMenu() As Entity.Sys.Enums.MenuTypes
        Get
            Return _SelectedMenu
        End Get
        Set(ByVal Value As Entity.Sys.Enums.MenuTypes)
            _SelectedMenu = Value
        End Set
    End Property

    Private _Page As Entity.Sys.Enums.PageViewing = Entity.Sys.Enums.PageViewing.NONE

    Public Property Page() As Entity.Sys.Enums.PageViewing
        Get
            Return _Page
        End Get
        Set(ByVal Value As Entity.Sys.Enums.PageViewing)
            _Page = Value
        End Set
    End Property

    Private _dvSearchResults As DataView

    Private Property SearchResults() As DataView
        Get
            Return _dvSearchResults
        End Get
        Set(ByVal value As DataView)
            _dvSearchResults = value
            _dvSearchResults.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString
            _dvSearchResults.AllowNew = False
            _dvSearchResults.AllowEdit = False
            _dvSearchResults.AllowDelete = False
            Me.dgSearchResults.DataSource = SearchResults
        End Set
    End Property

    Private ReadOnly Property SelectedSearchResultDataRow() As DataRow
        Get
            If Not Me.dgSearchResults.CurrentRowIndex = -1 Then
                Return SearchResults(Me.dgSearchResults.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _Exporting As Boolean = False

    Private Property Exporting() As Boolean
        Get
            Return _Exporting
        End Get
        Set(ByVal value As Boolean)
            _Exporting = value
        End Set
    End Property

    Private _SearchText As String = String.Empty

    Public Property SearchText() As String
        Get
            Return _SearchText
        End Get
        Set(ByVal value As String)
            _SearchText = value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub FRMMenu_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Logout()
    End Sub

    Private Sub FRMMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Logout()
            End If
        Catch ex As Exception
            ShowMessage("Action cannot be completed : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "File"

    Private Sub mnuChangeLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeLogin.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.NONE)
        ShowForm(GetType(FRMChangePassword), False, Nothing)
    End Sub

    Private Sub mnuLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogout.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.NONE)
        Logout()
    End Sub

#End Region

#Region "Home"

    Private Sub mnuCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCustomers.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.Customers)
    End Sub

    Private Sub mnuSpares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSpares.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.Spares)
    End Sub

    Private Sub mnuStaff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStaff.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.Staff)
    End Sub

    Private Sub mnuJobs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuJobs.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.Jobs)
    End Sub

    Private Sub mnuScheduler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuScheduler.Click
        Dim schedulerMain As New frmSchedulerMain
        schedulerMain.Show()
    End Sub

    Private Sub mnuInvoicing_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInvoicing.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.Invoicing)
    End Sub

    Private Sub mnuReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReports.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.Reports)
    End Sub

    Private Sub mnuVan_Click(sender As Object, e As EventArgs) Handles mnuVan.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.FleetVan)
    End Sub

    Private Sub mnuSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetup.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.Setup)
    End Sub

#End Region

#Region "Help"

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.NONE)
        ShowForm(GetType(FRMAbout), False, Nothing)
    End Sub

    Private Sub mnuContactSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContactSheet.Click
        Navigation.Navigate(Entity.Sys.Enums.MenuTypes.NONE)
        ShowForm(GetType(FRMContactDetails), False, Nothing)
    End Sub

#End Region

    Private Sub btnCloseMiddle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseMiddle.Click
        Navigation.Close_Middle()
        CurrentCustomerID = 0
        CurrentPropertyID = 0
    End Sub

    Private Sub btnCloseRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseRight.Click
        Navigation.Close_Right()
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        Add()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub dgSearchResults_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearchResults.Click, dgSearchResults.CurrentCellChanged
        Me.Cursor = Cursors.WaitCursor
        View()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSearchResults_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearchResults.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        Open()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnGoBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoBack.Click
        If Page = Entity.Sys.Enums.PageViewing.Asset Then
            Dim assetsPropertyID As Integer = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Assets.Asset).PropertyID
            SetSearchResults(DB.Sites.GetAll_Light_New(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, False, False)
            SearchResults.RowFilter = "SiteID =" & assetsPropertyID
            Me.dgSearchResults.Select(0)
            dgSearchResults_Click(sender, e)
        ElseIf Page = Entity.Sys.Enums.PageViewing.Property Then
            Dim PropertyCustID As Integer = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Sites.Site).CustomerID
            SetSearchResults(DB.Customer.Customer_GetAll_Light(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Customer, False, False)
            SearchResults.RowFilter = "CustomerID =" & PropertyCustID
            Me.dgSearchResults.Select(0)
            dgSearchResults_Click(sender, e)
        Else
            Me.btnGoBack.Visible = False
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Select Case Page

            Case Entity.Sys.Enums.PageViewing.Engineer

                Dim exportData As New DataTable
                exportData.Columns.Add("Name")
                exportData.Columns.Add("Department")
                exportData.Columns.Add("EngineerID")
                exportData.Columns.Add("Region")
                exportData.Columns.Add("TelephoneNum")
                exportData.Columns.Add("Technician")
                exportData.Columns.Add("Supervisor")

                For Each dr As DataRowView In CType(dgSearchResults.DataSource, DataView)
                    Dim newRw As DataRow = exportData.NewRow
                    newRw("Name") = dr("Name")
                    newRw("Department") = dr("Department")
                    newRw("EngineerID") = dr("EngineerID")
                    newRw("Region") = dr("Region")
                    newRw("TelephoneNum") = dr("TelephoneNum")
                    newRw("Technician") = dr("Technician")
                    newRw("Supervisor") = dr("Supervisor")
                    exportData.Rows.Add(newRw)
                Next
                ExportHelper.Export(exportData, "Engineers", Enums.ExportType.XLS)

            Case Entity.Sys.Enums.PageViewing.Property
                Exporting = True
                Dim exportData As New DataTable
                exportData.Columns.Add("Customer")
                exportData.Columns.Add("Name")
                exportData.Columns.Add("Address 1")
                exportData.Columns.Add("Address 2")
                exportData.Columns.Add("Address 3")
                exportData.Columns.Add("Postcode")
                exportData.Columns.Add("Telephone")
                exportData.Columns.Add("Mobile")
                exportData.Columns.Add("Email")
                exportData.Columns.Add("Date added to system", System.Type.GetType("System.DateTime"))
                exportData.Columns.Add("SiteFuel")
                exportData.Columns.Add("PolicyNumber")
                exportData.Columns.Add("LastServiceDate")

                For Each dr As DataRowView In CType(dgSearchResults.DataSource, DataView)
                    Dim newRw As DataRow = exportData.NewRow
                    newRw("Customer") = dr("CustomerName")
                    newRw("Name") = dr("Name")
                    newRw("Address 1") = dr("Address1")
                    newRw("Address 2") = dr("Address2")
                    newRw("Address 3") = dr("Address3")
                    newRw("Postcode") = dr("Postcode")
                    newRw("Telephone") = dr("TelephoneNum")
                    newRw("Mobile") = dr("FaxNum")
                    newRw("Email") = dr("EmailAddress")
                    newRw("Date added to system") = CDate(Format(dr("SiteAddedOnDateTime"), "dd/MM/yyyy"))
                    newRw("SiteFuel") = dr("SiteFuel")
                    newRw("PolicyNumber") = dr("PolicyNumber")
                    newRw("LastServiceDate") = dr("LastServiceDate")
                    exportData.Rows.Add(newRw)
                Next
                ExportHelper.Export(exportData, "Properties", Enums.ExportType.XLS)

                Exporting = False
            Case Entity.Sys.Enums.PageViewing.FleetVan
                Dim dv As DataView = DB.FleetVan.GetAll()
                ExportHelper.Export(dv.Table, "Fleet Vans", Enums.ExportType.XLS)
        End Select
    End Sub

#End Region

#Region "Functions"

    Private Sub LoopControls(ByVal controlToLoop As Control)
        For Each control As Control In controlToLoop.Controls
            If control.GetType.Name = "TabControl" Then
                LoopControls(control)
            ElseIf control.GetType.Name = "TabPage" Then
                CType(control, TabPage).BackColor = Color.White
                LoopControls(control)
            ElseIf control.GetType.Name = "GroupBox" Then
                CType(control, GroupBox).FlatStyle = FlatStyle.System
                LoopControls(control)
            ElseIf control.GetType.Name = "Panel" Then
                LoopControls(control)
            ElseIf control.GetType.Name = "Button" Then
                CType(control, Button).FlatStyle = FlatStyle.Standard
                CType(control, Button).Cursor = Cursors.Hand
                CType(control, Button).UseVisualStyleBackColor = False
                CType(control, Button).BackColor = System.Drawing.SystemColors.Control
                CType(control, Button).AccessibleDescription = CType(control, Button).Text
                FormButtons.Add(control)
            ElseIf control.GetType.Name = "ComboBox" Then
                CType(control, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
                CType(control, ComboBox).Cursor = Cursors.Hand
            ElseIf control.GetType.Name = "CheckBox" Then
                CType(control, CheckBox).FlatStyle = FlatStyle.System
                CType(control, CheckBox).Cursor = Cursors.Hand
            ElseIf control.GetType.Name = "NumericUpDown" Then
                CType(control, NumericUpDown).Cursor = Cursors.Hand
            ElseIf control.GetType.Name = "DataGrid" Then
                Entity.Sys.Helper.SetUpDataGrid(CType(control, DataGrid))
                Dim tStyle As DataGridTableStyle = CType(control, DataGrid).TableStyles(0)
                tStyle.ReadOnly = True
                tStyle.MappingName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
                CType(control, DataGrid).TableStyles.Add(tStyle)
            ElseIf control.GetType.Name = "UCButton" Then
                CType(control, Button).FlatStyle = FlatStyle.Standard
                CType(control, Button).Cursor = Cursors.Hand
                CType(control, Button).UseVisualStyleBackColor = False
                CType(control, Button).BackColor = System.Drawing.SystemColors.Control
                CType(control, Button).AccessibleDescription = CType(control, Button).Text
                FormButtons.Add(control)
            Else
                If control.GetType().IsSubclassOf(GetType(UCBase)) Then
                    LoopControls(CType(control, UCBase))
                End If
            End If
        Next
    End Sub

    Private Sub SetupButtonMouseOvers()
        For Each btn As Object In FormButtons
            AddHandler CType(btn, Button).MouseHover, AddressOf CreateHover
        Next
    End Sub

    Private Sub CreateHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Entity.Sys.Helper.Setup_Button(sender, CType(sender, Button).AccessibleDescription)
    End Sub

    Public Sub SetSearchResults(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, Optional ByVal FromADelete As Boolean = False, Optional ByVal ExtraText As String = "")
        SetupSearchResultsDataGrid(dv, pageIn, FromASave, FromADelete, ExtraText)

    End Sub

    Public Sub UpdateMessage()
        Me.Text = TheSystem.Configuration.CompanyName & " " & Me.Text & " v." & TheSystem.Configuration.SystemVersion
        Me.infoBar.Text = "Welcome " & loggedInUser.Fullname & ". " & DB.User.LastLogon(loggedInUser.UserID)
        Select Case TheSystem.Configuration.DBName
            Case Enums.DataBaseName.RftFsm_Beta, Enums.DataBaseName.GaswayServicesFSM_Beta, Enums.DataBaseName.BlueflameServicesFsm_Beta
                Me.infoBar.Text += " THIS IS THE BETA DATABASE"
                If Me.pnlLeft.Controls.Count > 0 Then
                    For Each pnlLeft As UCSideBar In Me.pnlLeft.Controls
                        pnlLeft.BackColor = Color.LightGoldenrodYellow
                    Next
                End If
        End Select
    End Sub

    Private Sub SetupSearchResultsDataGrid(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, Optional ByVal FromASave As Boolean = True, Optional ByVal FromADelete As Boolean = False, Optional ByVal ExtraText As String = "")
        If FromASave Then
            Me.pnlRight.Visible = True
        Else
            If FromADelete Then
                MainForm.pnlRight.Visible = False
                MainForm.pnlContent.Controls.Clear()
            Else
                If Not Navigation.Close_Right Then
                    Exit Sub
                End If
            End If
        End If

        Page = pageIn

        Dim tStyle As DataGridTableStyle = Me.dgSearchResults.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.btnAddNew.Enabled = True
        Me.btnDelete.Visible = True
        Me.btnAddNew.Visible = True
        Me.btnGoBack.Visible = False
        Me.btnExport.Visible = False

        Me.btnHQ.Visible = False

        Select Case Page

            Case Entity.Sys.Enums.PageViewing.Customer

                Dim CustomerName As New DataGridLabelColumn
                CustomerName.Format = ""
                CustomerName.FormatInfo = Nothing
                CustomerName.HeaderText = "Name"
                CustomerName.MappingName = "Name"
                CustomerName.ReadOnly = True
                CustomerName.Width = 200
                CustomerName.NullText = ""
                tStyle.GridColumnStyles.Add(CustomerName)

                Dim AccountNumber As New DataGridLabelColumn
                AccountNumber.Format = ""
                AccountNumber.FormatInfo = Nothing
                AccountNumber.HeaderText = "Account Number"
                AccountNumber.MappingName = "AccountNumber"
                AccountNumber.ReadOnly = True
                AccountNumber.Width = 140
                AccountNumber.NullText = ""
                tStyle.GridColumnStyles.Add(AccountNumber)

                Dim Region As New DataGridLabelColumn
                Region.Format = ""
                Region.FormatInfo = Nothing
                Region.HeaderText = "Region"
                Region.MappingName = "Region"
                Region.ReadOnly = True
                Region.Width = 140
                Region.NullText = ""
                tStyle.GridColumnStyles.Add(Region)

                Me.lblMiddleTitle.Text = "Customers"

            Case Entity.Sys.Enums.PageViewing.Property
                Me.btnHQ.Visible = True

                Me.btnGoBack.Text = "Go to Customer"
                Me.btnGoBack.Visible = True
                Me.btnExport.Visible = False

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 100
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Address1 As New DataGridLabelColumn
                Address1.Format = ""
                Address1.FormatInfo = Nothing
                Address1.HeaderText = "Address 1"
                Address1.MappingName = "Address1"
                Address1.ReadOnly = True
                Address1.Width = 100
                Address1.NullText = ""
                tStyle.GridColumnStyles.Add(Address1)

                Dim Address2 As New DataGridLabelColumn
                Address2.Format = ""
                Address2.FormatInfo = Nothing
                Address2.HeaderText = "Address 2"
                Address2.MappingName = "Address2"
                Address2.ReadOnly = True
                Address2.Width = 100
                Address2.NullText = ""
                tStyle.GridColumnStyles.Add(Address2)

                Dim Postcode As New DataGridLabelColumn
                Postcode.Format = ""
                Postcode.FormatInfo = Nothing
                Postcode.HeaderText = "Postcode"
                Postcode.MappingName = "Postcode"
                Postcode.ReadOnly = True
                Postcode.Width = 75
                Postcode.NullText = ""
                tStyle.GridColumnStyles.Add(Postcode)

                Dim HeadOffice As New DataGridLabelColumn
                HeadOffice.Format = ""
                HeadOffice.FormatInfo = Nothing
                HeadOffice.HeaderText = "HO"
                HeadOffice.MappingName = "HeadOfficeResult"
                HeadOffice.ReadOnly = True
                HeadOffice.Width = 75
                HeadOffice.NullText = ""
                tStyle.GridColumnStyles.Add(HeadOffice)

                Dim Region As New DataGridLabelColumn
                Region.Format = ""
                Region.FormatInfo = Nothing
                Region.HeaderText = "Region"
                Region.MappingName = "Region"
                Region.ReadOnly = True
                Region.Width = 100
                Region.NullText = ""
                tStyle.GridColumnStyles.Add(Region)

                Dim SiteFuel As New DataGridLabelColumn
                SiteFuel.Format = ""
                SiteFuel.FormatInfo = Nothing
                SiteFuel.HeaderText = "SiteFuel"
                SiteFuel.MappingName = "SiteFuel"
                SiteFuel.ReadOnly = True
                SiteFuel.Width = 100
                SiteFuel.NullText = ""
                tStyle.GridColumnStyles.Add(SiteFuel)

                Dim PolicyNumber As New DataGridLabelColumn
                PolicyNumber.Format = ""
                PolicyNumber.FormatInfo = Nothing
                PolicyNumber.HeaderText = "PolicyNumber"
                PolicyNumber.MappingName = "PolicyNumber"
                PolicyNumber.ReadOnly = True
                PolicyNumber.Width = 100
                PolicyNumber.NullText = ""
                tStyle.GridColumnStyles.Add(PolicyNumber)

                Dim LastServiceDate As New DataGridLabelColumn
                LastServiceDate.Format = ""
                LastServiceDate.FormatInfo = Nothing
                LastServiceDate.HeaderText = "Last Service Date"
                LastServiceDate.MappingName = "LastServiceDate"
                LastServiceDate.ReadOnly = True
                LastServiceDate.Width = 100
                LastServiceDate.NullText = ""
                tStyle.GridColumnStyles.Add(LastServiceDate)

                If ExtraText.Trim.Length > 0 Then
                    Me.lblMiddleTitle.Text = "Properties For " & ExtraText
                Else
                    Me.lblMiddleTitle.Text = "Properties"
                End If

            Case Entity.Sys.Enums.PageViewing.Asset
                Me.btnGoBack.Text = "Go to Property"
                Me.btnGoBack.Visible = True

                Dim Product As New DataGridLabelColumn
                Product.Format = ""
                Product.FormatInfo = Nothing
                Product.HeaderText = "Product"
                Product.MappingName = "Product"
                Product.ReadOnly = True
                Product.Width = 150
                Product.NullText = ""
                tStyle.GridColumnStyles.Add(Product)

                Dim Location As New DataGridLabelColumn
                Location.Format = ""
                Location.FormatInfo = Nothing
                Location.HeaderText = "Location"
                Location.MappingName = "Location"
                Location.ReadOnly = True
                Location.Width = 100
                Location.NullText = ""
                tStyle.GridColumnStyles.Add(Location)

                Dim SerialNum As New DataGridLabelColumn
                SerialNum.Format = ""
                SerialNum.FormatInfo = Nothing
                SerialNum.HeaderText = "Serial"
                SerialNum.MappingName = "SerialNum"
                SerialNum.ReadOnly = True
                SerialNum.Width = 150
                SerialNum.NullText = ""
                tStyle.GridColumnStyles.Add(SerialNum)

                If ExtraText.Trim.Length > 0 Then
                    Me.lblMiddleTitle.Text = "Appliances For " & ExtraText
                Else
                    Me.lblMiddleTitle.Text = "Appliances"
                End If

                If ViewingAllAssets Then
                    Me.btnAddNew.Enabled = False
                End If
            Case Entity.Sys.Enums.PageViewing.Part

                Dim PartName As New DataGridLabelColumn
                PartName.Format = ""
                PartName.FormatInfo = Nothing
                PartName.HeaderText = "Name"
                PartName.MappingName = "Name"
                PartName.ReadOnly = True
                PartName.Width = 130
                PartName.NullText = ""
                tStyle.GridColumnStyles.Add(PartName)

                Dim PartNumber As New DataGridLabelColumn
                PartNumber.Format = ""
                PartNumber.FormatInfo = Nothing
                PartNumber.HeaderText = "Number (MPN)"
                PartNumber.MappingName = "Number"
                PartNumber.ReadOnly = True
                PartNumber.Width = 130
                PartNumber.NullText = ""
                tStyle.GridColumnStyles.Add(PartNumber)

                Dim PartReference As New DataGridLabelColumn
                PartReference.Format = ""
                PartReference.FormatInfo = Nothing
                PartReference.HeaderText = "Reference"
                PartReference.MappingName = "Reference"
                PartReference.ReadOnly = True
                PartReference.Width = 130
                PartReference.NullText = ""
                tStyle.GridColumnStyles.Add(PartReference)

                Dim Quantity As New DataGridLabelColumn
                Quantity.Format = ""
                Quantity.FormatInfo = Nothing
                Quantity.HeaderText = "Qty"
                Quantity.MappingName = "WarehouseQuantity"
                Quantity.ReadOnly = True
                Quantity.Width = 50
                Quantity.NullText = ""
                tStyle.GridColumnStyles.Add(Quantity)

                Dim UnitType As New DataGridLabelColumn
                UnitType.Format = ""
                UnitType.FormatInfo = Nothing
                UnitType.HeaderText = "Unit Type"
                UnitType.MappingName = "UnitType"
                UnitType.ReadOnly = True
                UnitType.Width = 130
                UnitType.NullText = ""
                tStyle.GridColumnStyles.Add(UnitType)

                Dim SellPrice As New DataGridLabelColumn
                SellPrice.Format = "C"
                SellPrice.FormatInfo = Nothing
                SellPrice.HeaderText = "Sell Price"
                SellPrice.MappingName = "SellPrice"
                SellPrice.ReadOnly = True
                SellPrice.Width = 120
                SellPrice.NullText = ""
                tStyle.GridColumnStyles.Add(SellPrice)

                Me.lblMiddleTitle.Text = "Parts"

            Case Entity.Sys.Enums.PageViewing.PartPack

                Dim PartName As New DataGridLabelColumn
                PartName.Format = ""
                PartName.FormatInfo = Nothing
                PartName.HeaderText = "Pack Name"
                PartName.MappingName = "PackName"
                PartName.ReadOnly = True
                PartName.Width = 250
                PartName.NullText = ""
                tStyle.GridColumnStyles.Add(PartName)

                Me.lblMiddleTitle.Text = "Part Packs"

            Case Entity.Sys.Enums.PageViewing.Product

                Dim ProductName As New DataGridLabelColumn
                ProductName.Format = ""
                ProductName.FormatInfo = Nothing
                ProductName.HeaderText = "Description"
                ProductName.MappingName = "typemakemodel"
                ProductName.ReadOnly = True
                ProductName.Width = 200
                ProductName.NullText = ""
                tStyle.GridColumnStyles.Add(ProductName)

                Dim ProductNumber As New DataGridLabelColumn
                ProductNumber.Format = ""
                ProductNumber.FormatInfo = Nothing
                ProductNumber.HeaderText = "GC Number"
                ProductNumber.MappingName = "Number"
                ProductNumber.ReadOnly = True
                ProductNumber.Width = 120
                ProductNumber.NullText = ""
                tStyle.GridColumnStyles.Add(ProductNumber)

                Dim ProductReference As New DataGridLabelColumn
                ProductReference.Format = ""
                ProductReference.FormatInfo = Nothing
                ProductReference.HeaderText = "Reference"
                ProductReference.MappingName = "Reference"
                ProductReference.ReadOnly = True
                ProductReference.Width = 120
                ProductReference.NullText = ""
                tStyle.GridColumnStyles.Add(ProductReference)
                Me.lblMiddleTitle.Text = "Products"

            Case Entity.Sys.Enums.PageViewing.Supplier

                Dim SupplierName As New DataGridLabelColumn
                SupplierName.Format = ""
                SupplierName.FormatInfo = Nothing
                SupplierName.HeaderText = "Name"
                SupplierName.MappingName = "Name"
                SupplierName.ReadOnly = True
                SupplierName.Width = 120
                SupplierName.NullText = ""
                tStyle.GridColumnStyles.Add(SupplierName)

                Dim Address1 As New DataGridLabelColumn
                Address1.Format = ""
                Address1.FormatInfo = Nothing
                Address1.HeaderText = "Address 1"
                Address1.MappingName = "Address1"
                Address1.ReadOnly = True
                Address1.Width = 100
                Address1.NullText = ""
                tStyle.GridColumnStyles.Add(Address1)

                Dim Postcode As New DataGridLabelColumn
                Postcode.Format = ""
                Postcode.FormatInfo = Nothing
                Postcode.HeaderText = "Postcode"
                Postcode.MappingName = "Postcode"
                Postcode.ReadOnly = True
                Postcode.Width = 100
                Postcode.NullText = ""
                tStyle.GridColumnStyles.Add(Postcode)

                Dim Tel As New DataGridLabelColumn
                Tel.Format = ""
                Tel.FormatInfo = Nothing
                Tel.HeaderText = "Tel"
                Tel.MappingName = "TelephoneNum"
                Tel.ReadOnly = True
                Tel.Width = 100
                Tel.NullText = ""
                tStyle.GridColumnStyles.Add(Tel)

                Me.lblMiddleTitle.Text = "Suppliers"

            Case Entity.Sys.Enums.PageViewing.Engineer

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 160
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim PDAID As New DataGridLabelColumn
                PDAID.Format = ""
                PDAID.FormatInfo = Nothing
                PDAID.HeaderText = "Engineer ID"
                PDAID.MappingName = "EngineerID"
                PDAID.ReadOnly = True
                PDAID.Width = 80
                PDAID.NullText = ""
                tStyle.GridColumnStyles.Add(PDAID)

                Dim Region As New DataGridLabelColumn
                Region.Format = ""
                Region.FormatInfo = Nothing
                Region.HeaderText = "Region"
                Region.MappingName = "Region"
                Region.ReadOnly = True
                Region.Width = 120
                Region.NullText = ""
                tStyle.GridColumnStyles.Add(Region)

                Dim TelNum As New DataGridLabelColumn
                TelNum.Format = ""
                TelNum.FormatInfo = Nothing
                TelNum.HeaderText = "Telephone Number"
                TelNum.MappingName = "TelephoneNum"
                TelNum.ReadOnly = True
                TelNum.Width = 120
                TelNum.NullText = ""
                tStyle.GridColumnStyles.Add(TelNum)

                Dim technician As New DataGridLabelColumn
                technician.Format = ""
                technician.FormatInfo = Nothing
                technician.HeaderText = "Technician"
                technician.MappingName = "Technician"
                technician.ReadOnly = True
                technician.Width = 100
                technician.NullText = ""
                tStyle.GridColumnStyles.Add(technician)

                Dim supervisor As New DataGridLabelColumn
                supervisor.Format = ""
                supervisor.FormatInfo = Nothing
                supervisor.HeaderText = "Supervisor"
                supervisor.MappingName = "Supervisor"
                supervisor.ReadOnly = True
                supervisor.Width = 100
                supervisor.NullText = ""
                tStyle.GridColumnStyles.Add(supervisor)

                Me.lblMiddleTitle.Text = "Engineers"
                Me.btnExport.Visible = True

            Case Entity.Sys.Enums.PageViewing.Equipment

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Equipment"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 160
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Region As New DataGridLabelColumn
                Region.Format = ""
                Region.FormatInfo = Nothing
                Region.HeaderText = "Serial"
                Region.MappingName = "SerialNumber"
                Region.ReadOnly = True
                Region.Width = 120
                Region.NullText = ""
                tStyle.GridColumnStyles.Add(Region)

                Dim Warranty As New DataGridLabelColumn
                Warranty.Format = ""
                Warranty.FormatInfo = Nothing
                Warranty.HeaderText = "Warranty"
                Warranty.MappingName = "WarrantyEndDate"
                Warranty.ReadOnly = True
                Warranty.Width = 120
                Warranty.NullText = ""
                tStyle.GridColumnStyles.Add(Warranty)

                Me.lblMiddleTitle.Text = "Equipment"
                Me.btnExport.Visible = True

            Case Entity.Sys.Enums.PageViewing.Subcontractor

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 160
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Region As New DataGridLabelColumn
                Region.Format = ""
                Region.FormatInfo = Nothing
                Region.HeaderText = "Region"
                Region.MappingName = "Region"
                Region.ReadOnly = True
                Region.Width = 120
                Region.NullText = ""
                tStyle.GridColumnStyles.Add(Region)

                Dim Address1 As New DataGridLabelColumn
                Address1.Format = ""
                Address1.FormatInfo = Nothing
                Address1.HeaderText = "Address1"
                Address1.MappingName = "Address1"
                Address1.ReadOnly = True
                Address1.Width = 80
                Address1.NullText = ""
                tStyle.GridColumnStyles.Add(Address1)

                Dim Postcode As New DataGridLabelColumn
                Postcode.Format = ""
                Postcode.FormatInfo = Nothing
                Postcode.HeaderText = "Postcode"
                Postcode.MappingName = "Postcode"
                Postcode.ReadOnly = True
                Postcode.Width = 80
                Postcode.NullText = ""
                tStyle.GridColumnStyles.Add(Postcode)

                Dim TelNum As New DataGridLabelColumn
                TelNum.Format = ""
                TelNum.FormatInfo = Nothing
                TelNum.HeaderText = "Telephone Number"
                TelNum.MappingName = "TelephoneNum"
                TelNum.ReadOnly = True
                TelNum.Width = 120
                TelNum.NullText = ""
                tStyle.GridColumnStyles.Add(TelNum)

                Me.lblMiddleTitle.Text = "Subcontractors"

            Case Entity.Sys.Enums.PageViewing.StockProfile

                Dim Registration As New DataGridLabelColumn
                Registration.Format = ""
                Registration.FormatInfo = Nothing
                Registration.HeaderText = "Profile Name"
                Registration.MappingName = "Registration"
                Registration.ReadOnly = True
                Registration.Width = 200
                Registration.NullText = ""
                tStyle.GridColumnStyles.Add(Registration)

                Dim department As New DataGridLabelColumn
                department.Format = ""
                department.FormatInfo = Nothing
                department.HeaderText = "Department"
                department.MappingName = "Department"
                department.ReadOnly = True
                department.Width = 100
                department.NullText = ""
                tStyle.GridColumnStyles.Add(department)

                Me.lblMiddleTitle.Text = "Stock Profiles"
                Me.btnExport.Visible = True
                Me.btnDelete.Visible = True

            Case Entity.Sys.Enums.PageViewing.Warehouse

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 100
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Size As New DataGridLabelColumn
                Size.Format = ""
                Size.FormatInfo = Nothing
                Size.HeaderText = "Size"
                Size.MappingName = "Size"
                Size.ReadOnly = True
                Size.Width = 80
                Size.NullText = ""
                tStyle.GridColumnStyles.Add(Size)

                Dim Address1 As New DataGridLabelColumn
                Address1.Format = ""
                Address1.FormatInfo = Nothing
                Address1.HeaderText = "Address 1"
                Address1.MappingName = "Address1"
                Address1.ReadOnly = True
                Address1.Width = 100
                Address1.NullText = ""
                tStyle.GridColumnStyles.Add(Address1)

                Dim Address2 As New DataGridLabelColumn
                Address2.Format = ""
                Address2.FormatInfo = Nothing
                Address2.HeaderText = "Address 2"
                Address2.MappingName = "Address2"
                Address2.ReadOnly = True
                Address2.Width = 100
                Address2.NullText = ""
                tStyle.GridColumnStyles.Add(Address2)

                Dim Postcode As New DataGridLabelColumn
                Postcode.Format = ""
                Postcode.FormatInfo = Nothing
                Postcode.HeaderText = "Postcode"
                Postcode.MappingName = "Postcode"
                Postcode.ReadOnly = True
                Postcode.Width = 75
                Postcode.NullText = ""
                tStyle.GridColumnStyles.Add(Postcode)

                Me.lblMiddleTitle.Text = "Warehouses"
            Case Entity.Sys.Enums.PageViewing.FleetVan
                Dim registration As New DataGridLabelColumn
                registration.Format = ""
                registration.FormatInfo = Nothing
                registration.HeaderText = "Registration"
                registration.MappingName = "Registration"
                registration.ReadOnly = True
                registration.Width = 100
                registration.NullText = ""
                tStyle.GridColumnStyles.Add(registration)

                Dim make As New DataGridLabelColumn
                make.Format = ""
                make.FormatInfo = Nothing
                make.HeaderText = "Engineer"
                make.MappingName = "Name"
                make.ReadOnly = True
                make.Width = 200
                make.NullText = ""
                tStyle.GridColumnStyles.Add(make)

                Me.lblMiddleTitle.Text = "Fleet Vans"
                Me.btnExport.Visible = True
            Case Entity.Sys.Enums.PageViewing.FleetVanType

                Dim make As New DataGridLabelColumn
                make.Format = ""
                make.FormatInfo = Nothing
                make.HeaderText = "Make"
                make.MappingName = "Make"
                make.ReadOnly = True
                make.Width = 140
                make.NullText = ""
                tStyle.GridColumnStyles.Add(make)

                Dim model As New DataGridLabelColumn
                model.Format = ""
                model.FormatInfo = Nothing
                model.HeaderText = "Model"
                model.MappingName = "Model"
                model.ReadOnly = True
                model.Width = 210
                model.NullText = ""
                tStyle.GridColumnStyles.Add(model)

                Me.lblMiddleTitle.Text = "Van Types"

            Case Entity.Sys.Enums.PageViewing.FleetEquipment

                Dim name As New DataGridLabelColumn
                name.Format = ""
                name.FormatInfo = Nothing
                name.HeaderText = "Name"
                name.MappingName = "Name"
                name.ReadOnly = True
                name.Width = 140
                name.NullText = ""
                tStyle.GridColumnStyles.Add(name)

                Dim cost As New DataGridLabelColumn
                cost.Format = "C"
                cost.FormatInfo = Nothing
                cost.HeaderText = "Cost"
                cost.MappingName = "Cost"
                cost.ReadOnly = True
                cost.Width = 210
                cost.NullText = ""
                tStyle.GridColumnStyles.Add(cost)

                Me.lblMiddleTitle.Text = "Fleet Equipment"

            Case Entity.Sys.Enums.PageViewing.UserQuals

                Dim fullName As New DataGridLabelColumn
                fullName.Format = ""
                fullName.FormatInfo = Nothing
                fullName.HeaderText = "Name"
                fullName.MappingName = "FullName"
                fullName.ReadOnly = True
                fullName.Width = 125
                fullName.NullText = ""
                tStyle.GridColumnStyles.Add(fullName)

                Me.lblMiddleTitle.Text = "Users"

                Me.btnAddNew.Visible = False
                Me.btnDelete.Visible = False
                Me.btnExport.Visible = False

        End Select

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString
        'Me.dgSearchResults.TableStyles.Add(tStyle)

        Me.pnlMiddle.Visible = True

        SearchResults = dv

        If Page = Entity.Sys.Enums.PageViewing.Property Then
            If Not FromADelete Then
                If Not CurrentPropertyID = 0 Then
                    Dim rwCnt As Integer = 0

                    For Each row As DataRow In SearchResults.Table.Rows
                        If row.Item("SiteID") = CurrentPropertyID Then
                            Exit For
                        Else
                            rwCnt += 1
                        End If
                    Next

                    dgSearchResults.CurrentRowIndex = rwCnt
                End If
            End If

        End If
    End Sub

    Private Sub btnHQ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHQ.Click
        Dim TheHQ As Entity.Sites.Site = DB.Sites.Get(SelectedSearchResultDataRow.Item("CustomerID"), Entity.Sites.SiteSQL.GetBy.CustomerHq)
        If TheHQ Is Nothing OrElse Not TheHQ.Exists Then
            ShowMessage("No head office has been assigned", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If TheHQ.SiteID = Entity.Sys.Helper.MakeIntegerValid(
            SelectedSearchResultDataRow.Item("SiteID")) Then
            ShowMessage("This site is the head office", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ShowForm(GetType(FRMSitePopup), True, New Object() {TheHQ.SiteID})
    End Sub

    Private Sub Add()
        Select Case Page
            Case Entity.Sys.Enums.PageViewing.Customer
                ShowForm(GetType(FRMCustomer), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.Property
                Dim custCheck As Entity.Customers.Customer = DB.Customer.Customer_Get(CurrentCustomerID)
                If Not custCheck Is Nothing Then
                    If custCheck.Status = Entity.Sys.Enums.CustomerStatus.OnHold Then
                        ShowMessage("Customer On Hold.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
                ShowForm(GetType(FRMSite), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.Asset
                ShowForm(GetType(FRMAsset), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.Subcontractor
                ShowForm(GetType(FRMSubcontractor), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.Supplier
                Dim _ssmList As New List(Of Entity.Sys.Enums.SecuritySystemModules)
                _ssmList.Add(Entity.Sys.Enums.SecuritySystemModules.Finance)
                _ssmList.Add(Entity.Sys.Enums.SecuritySystemModules.Compliance)
                If loggedInUser.HasAccessToMulitpleModules(_ssmList) Then
                    ShowForm(GetType(FRMSupplier), True, Nothing)
                Else
                    Dim msg As String = "You do not have the necessary security permissions." & vbCrLf
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                    Throw New Security.SecurityException(msg)
                End If
            Case Entity.Sys.Enums.PageViewing.Product
                ShowForm(GetType(FRMProduct), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.Part
                If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.CreateParts) = False Then
                    Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                    Throw New Security.SecurityException(msg)
                Else
                    'If EnterOverridePassword() Then
                    ShowForm(GetType(FRMPart), True, Nothing)
                End If
            Case Entity.Sys.Enums.PageViewing.PartPack
                Dim ssm As Entity.Sys.Enums.SecuritySystemModules
                ssm = Entity.Sys.Enums.SecuritySystemModules.CreateParts
                If loggedInUser.HasAccessToModule(ssm) = False Then
                    Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                    Throw New Security.SecurityException(msg)
                Else
                    'If EnterOverridePassword() Then
                    ShowForm(GetType(FRMPartPack), True, Nothing)
                End If
            Case Entity.Sys.Enums.PageViewing.Engineer
                ShowForm(GetType(FRMEngineer), True, Nothing)
            Case Enums.PageViewing.StockProfile
                ShowForm(GetType(FRMVan), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.FleetVan
                ShowForm(GetType(FRMFleetVan), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.FleetVanType
                ShowForm(GetType(FRMFleetVanType), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.FleetEquipment
                ShowForm(GetType(FRMFleetEquipment), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.Equipment
                ShowForm(GetType(FRMEquipment), True, Nothing)
            Case Entity.Sys.Enums.PageViewing.Warehouse
                ShowForm(GetType(FRMWarehouse), True, Nothing)
        End Select
    End Sub

    Private Sub Delete()
        If SelectedSearchResultDataRow Is Nothing Then
            Exit Sub
        End If

        If ShowMessage("You are about to delete an item." & vbCrLf & vbCrLf &
                       "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                       DialogResult.Yes Then
        Else
            Exit Sub
        End If

        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.IT) Then
            Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
            Exit Sub
        End If

        Select Case Page
            Case Entity.Sys.Enums.PageViewing.Supplier
                DB.Supplier.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SupplierID")))
                SetSearchResults(DB.Supplier.Supplier_GetAll(), Entity.Sys.Enums.PageViewing.Supplier, False, True)
            Case Entity.Sys.Enums.PageViewing.Customer
                Dim customerID As Integer =
                    Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("CustomerID"))

                'check if the customer has active sites if so then we can't delete
                If DB.Customer.Customer_GetActiveSiteCount(customerID) = 0 Then
                    DB.Customer.Delete(customerID)
                    SetSearchResults(DB.Customer.Customer_GetAll_Light(loggedInUser.UserID),
                                     Entity.Sys.Enums.PageViewing.Customer, False, True)
                Else
                    ShowMessage("This customer has active sites so cannot be deleted",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Entity.Sys.Enums.PageViewing.Property
                'SHOULD NOT BE ABLE TO DELETE A SITE IF IT HAS ACTIVE JOBS OR ORDERS
                If DB.Sites.Site_CanItBeDeleted(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SiteID"))).Table.Rows.Count > 0 Then
                    If ShowMessage("This site has active jobs or orders" & vbCrLf & vbCrLf &
                                   "Do you wish to continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
                        Exit Sub
                    End If
                End If
                DB.Job.Job_Delete_BySite(SelectedSearchResultDataRow.Item("SiteID"))
                DB.Sites.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SiteID")))

                If CurrentCustomerID = 0 Then
                    SetSearchResults(DB.Sites.GetAll_Light_New(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, False, True)
                Else
                    Dim cust As New Entity.Customers.Customer
                    cust = DB.Customer.Customer_Get(CurrentCustomerID)
                    SetSearchResults(DB.Sites.GetForCustomer_Light(CurrentCustomerID, loggedInUser.UserID),
                                     Entity.Sys.Enums.PageViewing.Property, False, True, cust.Name & " (" & cust.AccountNumber & ")")
                End If
            Case Entity.Sys.Enums.PageViewing.Asset
                DB.Asset.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("AssetID")))
                If CurrentPropertyID = 0 Then
                    SetSearchResults(DB.Asset.Asset_GetAll(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Asset, False, True)
                Else
                    Dim site As New Entity.Sites.Site
                    site = DB.Sites.Get(CurrentPropertyID)
                    Dim cust As New Entity.Customers.Customer
                    cust = DB.Customer.Customer_Get(site.CustomerID)
                    SetSearchResults(DB.Asset.Asset_GetForSite(CurrentPropertyID), Entity.Sys.Enums.PageViewing.Asset, False, True, site.Address1 & ", " & site.Postcode & " (" & cust.AccountNumber & ")")
                End If

            Case Entity.Sys.Enums.PageViewing.Product
                DB.Product.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("ProductID")))
                SetSearchResults(DB.Product.Product_GetAll, Entity.Sys.Enums.PageViewing.Product, False, True)
            Case Entity.Sys.Enums.PageViewing.Part
                Dim partID As Integer =
                        Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("PartID"))

                Dim suppliers As DataView = DB.PartSupplier.Get_ByPartID(partID)
                Dim stockList As DataView = DB.Part.Stock_Get_Locations(partID)
                If suppliers.Table.Rows.Count > 0 And stockList.Table.Rows.Count > 0 Then
                    ShowMessage("This part has active suppliers and stock so cannot be deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                DB.Part.Delete(partID)
                Dim ctrl As ISearchControl = MenuBar.pnlSearch.Controls.Item(0)
                If ctrl IsNot Nothing Then ctrl.Search()
                'SetSearchResults(DB.Part.Part_GetAll, Entity.Sys.Enums.PageViewing.Part, False, True)
            Case Entity.Sys.Enums.PageViewing.PartPack
                DB.ExecuteScalar("DELETE FROM tblPartPack WHERE PackID = " & SelectedSearchResultDataRow.Item("PackID"))
                SetSearchResults(DB.Part.PartPack_GetAll, Entity.Sys.Enums.PageViewing.PartPack, False, True)
            Case Enums.PageViewing.Engineer
                Dim engineerId As Integer = Helper.MakeIntegerValid(SelectedSearchResultDataRow("EngineerID"))
                Dim dvJobs As DataView = DB.EngineerVisits.Get_ByEngineerIdAndStatusEnumId(engineerId, CInt(Enums.VisitStatus.Scheduled))
                dvJobs.Table.Merge(DB.EngineerVisits.Get_ByEngineerIdAndStatusEnumId(engineerId, CInt(Enums.VisitStatus.Downloaded)).Table)
                If dvJobs.Count > 1 Then
                    ShowMessage("This engineer has jobs that are scheduled/downloaded so cannot be deleted!" & vbCrLf & vbCrLf & "An export of their jobs will follow!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ExportHelper.Export(dvJobs.Table, "Jobs", Enums.ExportType.XLS)
                    Exit Sub
                Else
                    DB.Engineer.Delete(engineerId)
                    SetSearchResults(DB.Engineer.Engineer_GetAll_NoSub, Entity.Sys.Enums.PageViewing.Engineer, False, True)
                End If
            Case Entity.Sys.Enums.PageViewing.Equipment
                DB.Engineer.DeleteEquipment(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("EquipmentID")))
                SetSearchResults(DB.Engineer.Equipment_GetAll, Entity.Sys.Enums.PageViewing.Equipment, False, True)
            Case Entity.Sys.Enums.PageViewing.FleetVanType
                DB.FleetVanType.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanTypeID")))
                SetSearchResults(DB.FleetVanType.GetAll, Entity.Sys.Enums.PageViewing.FleetVanType, False, True)
            Case Entity.Sys.Enums.PageViewing.FleetEquipment
                Dim equipmentID As Integer = Entity.Sys.Helper.MakeIntegerValid(
                    SelectedSearchResultDataRow.Item("EquipmentID"))

                If DB.FleetEquipment.GetActiveCount(equipmentID) = 0 Then
                    DB.FleetEquipment.Delete(equipmentID)
                    SetSearchResults(DB.FleetEquipment.GetAll, Entity.Sys.Enums.PageViewing.FleetEquipment, False, True)
                Else
                    ShowMessage("This equipment is still in use by vans",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Entity.Sys.Enums.PageViewing.FleetVan
                ShowMessage("Vans cannot be deleted, only returned", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Case Entity.Sys.Enums.PageViewing.Subcontractor
                DB.SubContractor.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SubcontractorID")))
                SetSearchResults(DB.SubContractor.Subcontractor_GetAll, Entity.Sys.Enums.PageViewing.Subcontractor, False, True)
            Case Entity.Sys.Enums.PageViewing.StockProfile
                DB.Van.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanID")))
                SetSearchResults(DB.Van.Van_GetAll(True), Entity.Sys.Enums.PageViewing.StockProfile, False, True)
            Case Entity.Sys.Enums.PageViewing.Warehouse
                DB.Warehouse.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("WarehouseID")))
                SetSearchResults(DB.Warehouse.Warehouse_GetAll, Entity.Sys.Enums.PageViewing.Warehouse, False, True)
        End Select
    End Sub

    Public Sub View()
        If Exporting Then
            Exit Sub
        End If

        If SelectedSearchResultDataRow Is Nothing Then
            Exit Sub
        End If

        Dim ctrl As IUserControl = Nothing

        If Not Page = Entity.Sys.Enums.PageViewing.Property Then
            SearchText = ""
        End If

        Select Case Page
            Case Entity.Sys.Enums.PageViewing.Supplier
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SupplierID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Suppliers.Supplier).SupplierID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Supplier"
                ctrl = New UCSupplier
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SupplierID")))

            Case Entity.Sys.Enums.PageViewing.Customer
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("CustomerID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Customers.Customer).CustomerID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Customer"
                ctrl = New UCCustomer
                CurrentCustomerID = Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("CustomerID"))
                ctrl.Populate(CurrentCustomerID)

            Case Entity.Sys.Enums.PageViewing.Property
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SiteID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Sites.Site).SiteID Then
                            Exit Sub
                        End If
                    End If
                End If

                Dim oCust As New Entity.Customers.Customer
                oCust = DB.Customer.Customer_Get_ForSiteID(SelectedSearchResultDataRow.Item("SiteID"))
                Me.lblRightTitle.Text = "Manage Property for Customer: " & oCust.Name & ", Acc: " & oCust.AccountNumber
                ctrl = New UCSite
                CurrentPropertyID = Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SiteID"))
                ctrl.Populate(CurrentPropertyID)

            Case Entity.Sys.Enums.PageViewing.Asset
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("AssetID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Assets.Asset).AssetID Then
                            Exit Sub
                        End If
                    End If
                End If

                Dim oProperty As New Entity.Sites.Site
                oProperty = DB.Sites.Get(SelectedSearchResultDataRow.Item("AssetID"), Entity.Sites.SiteSQL.GetBy.Asset)
                Dim oCust As New Entity.Customers.Customer
                oCust = DB.Customer.Customer_Get_ForSiteID(oProperty.SiteID)
                Me.lblRightTitle.Text = "Manage Appliance for Property: " & oProperty.Name & ", " & oProperty.Postcode & ", Customer: " & oCust.Name & ", Acc: " & oCust.AccountNumber
                ctrl = New UCAsset
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("AssetID")))

            Case Entity.Sys.Enums.PageViewing.Contact
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("ContactID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Contacts.Contact).ContactID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Contact"
                ctrl = New UCContact
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("ContactID")))

            Case Entity.Sys.Enums.PageViewing.Part
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("PartID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Parts.Part).PartID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Part"
                ctrl = New UCPart
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("PartID")))

            Case Entity.Sys.Enums.PageViewing.PartPack
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("PackID")) = CType(Me.pnlContent.Controls(0), UCPartPack).PackID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Part Pack"
                ctrl = New UCPartPack
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("PackID")))

            Case Entity.Sys.Enums.PageViewing.Product
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("ProductID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Products.Product).ProductID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Product"
                ctrl = New UCProduct
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("ProductID")))

            Case Entity.Sys.Enums.PageViewing.Engineer
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("EngineerID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Engineers.Engineer).EngineerID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Engineer"
                ctrl = New UCEngineer
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("EngineerID")))

            Case Entity.Sys.Enums.PageViewing.Subcontractor
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SubcontractorID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Subcontractors.Subcontractor).SubcontractorID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Subcontractor"
                ctrl = New UCSubcontractor
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SubcontractorID")))

            Case Entity.Sys.Enums.PageViewing.StockProfile
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Vans.Van).VanID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Van Stock Profiles"
                ctrl = New UCVan
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanID")))

            Case Entity.Sys.Enums.PageViewing.Equipment
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("EquipmentID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Engineers.Equipment).EquipmentID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Equipment"
                ctrl = New UCEquipment
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("EquipmentID")))

            Case Entity.Sys.Enums.PageViewing.StockProfile
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Vans.Van).VanID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Profiles"
                ctrl = New UCVan
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanID")))

            Case Entity.Sys.Enums.PageViewing.FleetVan
                If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Fleet) = False Then
                    Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                    Throw New Security.SecurityException(msg)
                End If

                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanID")) =
                            CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.FleetVans.FleetVan).VanID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Van"
                ctrl = New UCFleetVan
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanID")))

            Case Entity.Sys.Enums.PageViewing.FleetVanType
                If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Fleet) = False Then
                    Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                    Throw New Security.SecurityException(msg)
                End If
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanTypeID")) =
                            CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.FleetVans.FleetVanType).VanTypeID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Van Type"
                ctrl = New UCFleetVanType
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanTypeID")))

            Case Entity.Sys.Enums.PageViewing.FleetEquipment
                If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Fleet) = False Then
                    Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                    Throw New Security.SecurityException(msg)
                End If
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("EquipmentID")) =
                            CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.FleetVans.FleetEquipment).EquipmentID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Equipment"
                ctrl = New UCFleetEquipment
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("EquipmentID")))

            Case Entity.Sys.Enums.PageViewing.Warehouse
                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("WarehouseID")) = CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Warehouses.Warehouse).WarehouseID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage Warehouse"
                ctrl = New UCWarehouse
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("WarehouseID")))

            Case Entity.Sys.Enums.PageViewing.UserQuals
                Dim _ssmList As New List(Of Entity.Sys.Enums.SecuritySystemModules) From
                    {Entity.Sys.Enums.SecuritySystemModules.Compliance, Entity.Sys.Enums.SecuritySystemModules.IT}

                If loggedInUser.HasAccessToMulitpleModules(_ssmList) = False Then
                    Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                    Throw New Security.SecurityException(msg)
                End If

                If Me.pnlRight.Visible Then
                    If Me.pnlContent.Controls.Count > 0 Then
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("UserID")) =
                            CType(CType(Me.pnlContent.Controls(0), IUserControl).LoadedItem, Entity.Users.User).UserID Then
                            Exit Sub
                        End If
                    End If
                End If

                Me.lblRightTitle.Text = "Manage User"
                ctrl = New UCUserQualification
                ctrl.Populate(Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("UserID")))
        End Select

        AddHandler ctrl.RecordsChanged, AddressOf MainForm.SetSearchResults

        Me.pnlContent.Controls.Clear()
        Me.pnlContent.Controls.Add(ctrl)
        Navigation.Show_Right()
    End Sub

    Private Sub Open()
        If SelectedSearchResultDataRow Is Nothing Then
            Exit Sub
        End If

        Select Case Page
            Case Entity.Sys.Enums.PageViewing.Supplier
                ShowForm(GetType(FRMSupplier), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SupplierID"))})
            Case Entity.Sys.Enums.PageViewing.Customer
                ShowForm(GetType(FRMCustomer), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("CustomerID"))})
            Case Entity.Sys.Enums.PageViewing.Property
                ShowForm(GetType(FRMSite), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SiteID"))})
            Case Entity.Sys.Enums.PageViewing.Asset
                ShowForm(GetType(FRMAsset), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("AssetID"))})
            Case Entity.Sys.Enums.PageViewing.Product
                ShowForm(GetType(FRMProduct), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("ProductID")), False})
            Case Entity.Sys.Enums.PageViewing.Part
                ShowForm(GetType(FRMPart), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("PartID")), False})
            Case Entity.Sys.Enums.PageViewing.Engineer
                ShowForm(GetType(FRMEngineer), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("EngineerID"))})
            Case Entity.Sys.Enums.PageViewing.Subcontractor
                ShowForm(GetType(FRMSubcontractor), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("SubcontractorID"))})
            Case Entity.Sys.Enums.PageViewing.StockProfile
                ShowForm(GetType(FRMVan), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("VanID"))})
            Case Entity.Sys.Enums.PageViewing.Warehouse
                ShowForm(GetType(FRMWarehouse), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedSearchResultDataRow.Item("WarehouseID"))})
        End Select
    End Sub

    Private Sub Save()
        CType(Me.pnlContent.Controls(0), IUserControl).Save()
    End Sub

    Public Sub RefreshEntity(ByVal id As Integer, Optional ByVal IDColumnName As String = "")
        If IDColumnName = "" Then
            If Not SearchResults Is Nothing Then
                If SearchResults.Table.Rows.Count = 1 Then
                    Me.dgSearchResults.Select(0)
                End If
            End If
        Else
            Dim index As Integer = 0
            For Each row As DataRow In CType(dgSearchResults.DataSource, DataView).Table.Rows
                If CInt(row.Item(IDColumnName)) = id Then
                    Me.dgSearchResults.CurrentRowIndex = index
                    Exit For
                Else
                    index += 1
                End If
            Next

        End If

        View()

        If Me.pnlContent.Controls.Count > 0 Then
            CType(Me.pnlContent.Controls(0), IUserControl).Populate(id)
        End If

    End Sub

    Private Sub mnuUpstairs_Click(sender As Object, e As EventArgs) Handles mnuUpstairs.Click
        Try
            Dim dlg As OpenFileDialog = New OpenFileDialog
            If dlg.ShowDialog = DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                Dim tempfile As New FileInfo(dlg.FileName)
                If Path.GetExtension(tempfile.Name) <> ".docx" Then Throw New Exception("Incorrect File Format")
                Dim pdfFile As New FileInfo(PrintHelper.ToPdf(tempfile.FullName))
                If Path.GetExtension(pdfFile.Name) <> ".pdf" Then Throw New Exception("Error converting to pdf")

                Dim filePath As String = "\\PHOCAS.gasway.co.uk\Aggregator_IO\Inputs\Upstairs Documents\"
                Dim fileType As String = Path.GetExtension(pdfFile.Name)
                File.Copy(pdfFile.FullName, filePath & pdfFile.Name.Replace(fileType, "_" & Now.ToString("ddMMyyHHmmss") & fileType))
                File.Delete(pdfFile.FullName)
                ShowMessage("File successfully copy to Upstairs Printer! ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cursor.Current = Cursors.Default
            End If
        Catch ex As Exception
            ShowMessage("File data could not be printed : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub mnuDownstairs_Click(sender As Object, e As EventArgs) Handles mnuDownstairs.Click
        Try
            Dim dlg As OpenFileDialog = New OpenFileDialog
            If dlg.ShowDialog = DialogResult.OK Then
                Dim tempfile As New FileInfo(dlg.FileName)
                If Path.GetExtension(tempfile.Name) <> ".docx" Then Throw New Exception("Incorrect File Format")
                Dim pdfFile As New FileInfo(PrintHelper.ToPdf(tempfile.FullName))
                If Path.GetExtension(pdfFile.Name) <> ".pdf" Then Throw New Exception("Error converting to pdf")

                Dim filePath As String = "\\PHOCAS.gasway.co.uk\Aggregator_IO\Inputs\Downstairs Documents\"
                Dim fileType As String = Path.GetExtension(pdfFile.Name)
                File.Copy(pdfFile.FullName, filePath & pdfFile.Name.Replace(fileType, "_" & Now.ToString("ddMMyyHHmmss") & fileType))
                File.Delete(pdfFile.FullName)
                ShowMessage("File successfully copy to Downstairs Printer! ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ShowMessage("File data could not be printed : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pnlMiddle_Resize(sender As Object, e As EventArgs) Handles pnlMiddle.Resize
        Dim width As Integer = pnlMiddle.Width

        If MainForm IsNot Nothing Then
            Navigation.ResponsiveUI()
        End If

        Navigation.Show_Right()
    End Sub

#End Region

End Class