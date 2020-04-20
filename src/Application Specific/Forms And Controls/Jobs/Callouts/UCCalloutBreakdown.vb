Imports System.Linq

Public Class UCCalloutBreakdown : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents grpJobItemsAdded As System.Windows.Forms.GroupBox

    Friend WithEvents dgJobItemsAdded As System.Windows.Forms.DataGrid
    Friend WithEvents tcEngineerVisits As System.Windows.Forms.TabControl
    Friend WithEvents btnRemoveEngineerVisit As System.Windows.Forms.Button
    Friend WithEvents btnAddEngineerVisit As System.Windows.Forms.Button
    Friend WithEvents txtJobItemSummary As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveItem As System.Windows.Forms.Button
    Friend WithEvents btnRemoveItem As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblQualification As System.Windows.Forms.Label
    Friend WithEvents cboQualification As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddRate As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobItemsAdded = New System.Windows.Forms.GroupBox()
        Me.lblQualification = New System.Windows.Forms.Label()
        Me.cboQualification = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.txtPONumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAddRate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJobItemSummary = New System.Windows.Forms.TextBox()
        Me.btnSaveItem = New System.Windows.Forms.Button()
        Me.btnRemoveItem = New System.Windows.Forms.Button()
        Me.btnRemoveEngineerVisit = New System.Windows.Forms.Button()
        Me.btnAddEngineerVisit = New System.Windows.Forms.Button()
        Me.tcEngineerVisits = New System.Windows.Forms.TabControl()
        Me.dgJobItemsAdded = New System.Windows.Forms.DataGrid()
        Me.grpJobItemsAdded.SuspendLayout()
        CType(Me.dgJobItemsAdded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpJobItemsAdded
        '
        Me.grpJobItemsAdded.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobItemsAdded.Controls.Add(Me.lblQualification)
        Me.grpJobItemsAdded.Controls.Add(Me.cboQualification)
        Me.grpJobItemsAdded.Controls.Add(Me.Label4)
        Me.grpJobItemsAdded.Controls.Add(Me.cboPriority)
        Me.grpJobItemsAdded.Controls.Add(Me.txtPONumber)
        Me.grpJobItemsAdded.Controls.Add(Me.Label3)
        Me.grpJobItemsAdded.Controls.Add(Me.btnAddRate)
        Me.grpJobItemsAdded.Controls.Add(Me.Label1)
        Me.grpJobItemsAdded.Controls.Add(Me.txtJobItemSummary)
        Me.grpJobItemsAdded.Controls.Add(Me.btnSaveItem)
        Me.grpJobItemsAdded.Controls.Add(Me.btnRemoveItem)
        Me.grpJobItemsAdded.Controls.Add(Me.btnRemoveEngineerVisit)
        Me.grpJobItemsAdded.Controls.Add(Me.btnAddEngineerVisit)
        Me.grpJobItemsAdded.Controls.Add(Me.tcEngineerVisits)
        Me.grpJobItemsAdded.Controls.Add(Me.dgJobItemsAdded)
        Me.grpJobItemsAdded.Location = New System.Drawing.Point(8, 8)
        Me.grpJobItemsAdded.Name = "grpJobItemsAdded"
        Me.grpJobItemsAdded.Size = New System.Drawing.Size(864, 280)
        Me.grpJobItemsAdded.TabIndex = 0
        Me.grpJobItemsAdded.TabStop = False
        Me.grpJobItemsAdded.Text = "Job Items"
        '
        'lblQualification
        '
        Me.lblQualification.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQualification.AutoSize = True
        Me.lblQualification.Location = New System.Drawing.Point(277, 22)
        Me.lblQualification.Name = "lblQualification"
        Me.lblQualification.Size = New System.Drawing.Size(77, 13)
        Me.lblQualification.TabIndex = 26
        Me.lblQualification.Text = "Qualification"
        '
        'cboQualification
        '
        Me.cboQualification.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboQualification.FormattingEnabled = True
        Me.cboQualification.Location = New System.Drawing.Point(369, 18)
        Me.cboQualification.Name = "cboQualification"
        Me.cboQualification.Size = New System.Drawing.Size(223, 21)
        Me.cboQualification.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(598, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Priority"
        '
        'cboPriority
        '
        Me.cboPriority.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPriority.FormattingEnabled = True
        Me.cboPriority.Location = New System.Drawing.Point(652, 18)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(142, 21)
        Me.cboPriority.TabIndex = 23
        '
        'txtPONumber
        '
        Me.txtPONumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPONumber.Location = New System.Drawing.Point(84, 20)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Size = New System.Drawing.Size(185, 21)
        Me.txtPONumber.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 20)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "PO Number"
        '
        'btnAddRate
        '
        Me.btnAddRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddRate.Location = New System.Drawing.Point(6, 248)
        Me.btnAddRate.Name = "btnAddRate"
        Me.btnAddRate.Size = New System.Drawing.Size(354, 23)
        Me.btnAddRate.TabIndex = 20
        Me.btnAddRate.Text = "Add Description From A Property Schedule Of Rates List"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(6, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Enter Summary"
        '
        'txtJobItemSummary
        '
        Me.txtJobItemSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobItemSummary.Location = New System.Drawing.Point(8, 191)
        Me.txtJobItemSummary.Multiline = True
        Me.txtJobItemSummary.Name = "txtJobItemSummary"
        Me.txtJobItemSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtJobItemSummary.Size = New System.Drawing.Size(261, 49)
        Me.txtJobItemSummary.TabIndex = 15
        '
        'btnSaveItem
        '
        Me.btnSaveItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveItem.Location = New System.Drawing.Point(296, 220)
        Me.btnSaveItem.Name = "btnSaveItem"
        Me.btnSaveItem.Size = New System.Drawing.Size(64, 23)
        Me.btnSaveItem.TabIndex = 16
        Me.btnSaveItem.Text = "Save"
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveItem.Location = New System.Drawing.Point(296, 191)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(62, 23)
        Me.btnRemoveItem.TabIndex = 17
        Me.btnRemoveItem.Text = "Remove"
        '
        'btnRemoveEngineerVisit
        '
        Me.btnRemoveEngineerVisit.AccessibleDescription = "Remove Engineer Visit"
        Me.btnRemoveEngineerVisit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveEngineerVisit.Location = New System.Drawing.Point(832, 25)
        Me.btnRemoveEngineerVisit.Name = "btnRemoveEngineerVisit"
        Me.btnRemoveEngineerVisit.Size = New System.Drawing.Size(24, 23)
        Me.btnRemoveEngineerVisit.TabIndex = 4
        Me.btnRemoveEngineerVisit.Text = "_"
        '
        'btnAddEngineerVisit
        '
        Me.btnAddEngineerVisit.AccessibleDescription = "Add Engineer Visit"
        Me.btnAddEngineerVisit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddEngineerVisit.Location = New System.Drawing.Point(800, 25)
        Me.btnAddEngineerVisit.Name = "btnAddEngineerVisit"
        Me.btnAddEngineerVisit.Size = New System.Drawing.Size(24, 23)
        Me.btnAddEngineerVisit.TabIndex = 3
        Me.btnAddEngineerVisit.Text = "+"
        '
        'tcEngineerVisits
        '
        Me.tcEngineerVisits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcEngineerVisits.Location = New System.Drawing.Point(369, 48)
        Me.tcEngineerVisits.Name = "tcEngineerVisits"
        Me.tcEngineerVisits.SelectedIndex = 0
        Me.tcEngineerVisits.Size = New System.Drawing.Size(487, 224)
        Me.tcEngineerVisits.TabIndex = 5
        '
        'dgJobItemsAdded
        '
        Me.dgJobItemsAdded.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgJobItemsAdded.DataMember = ""
        Me.dgJobItemsAdded.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobItemsAdded.Location = New System.Drawing.Point(8, 48)
        Me.dgJobItemsAdded.Name = "dgJobItemsAdded"
        Me.dgJobItemsAdded.Size = New System.Drawing.Size(352, 121)
        Me.dgJobItemsAdded.TabIndex = 1
        '
        'UCCalloutBreakdown
        '
        Me.Controls.Add(Me.grpJobItemsAdded)
        Me.Name = "UCCalloutBreakdown"
        Me.Size = New System.Drawing.Size(880, 296)
        Me.grpJobItemsAdded.ResumeLayout(False)
        Me.grpJobItemsAdded.PerformLayout()
        CType(Me.dgJobItemsAdded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        SetupJobItemsAddedDataGrid()

        For Each CalloutBreakdown As TabPage In Me.tcEngineerVisits.TabPages
            CType(CalloutBreakdown.Controls(0), UCVisitBreakdown).SetupDG()
        Next
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return JobOfWork
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _onContol As UCLogCallout = Nothing

    Public Property OnContol() As UCLogCallout
        Get
            Return _onContol
        End Get
        Set(ByVal Value As UCLogCallout)
            _onContol = Value
        End Set
    End Property

    Private _jobOfWork As Entity.JobOfWorks.JobOfWork

    Public Property JobOfWork() As Entity.JobOfWorks.JobOfWork
        Get
            Return _jobOfWork
        End Get
        Set(ByVal Value As Entity.JobOfWorks.JobOfWork)
            _jobOfWork = Value

            If _jobOfWork Is Nothing Then
                _jobOfWork = New Entity.JobOfWorks.JobOfWork
            End If
        End Set
    End Property

    Public Property JobItemsAddedDataView() As DataView
        Get
            Return m_dJobItemsAddedTable
        End Get
        Set(ByVal Value As DataView)
            m_dJobItemsAddedTable = Value
            m_dJobItemsAddedTable.Table.TableName = "JOB_ITEMS_ADDED"
            m_dJobItemsAddedTable.AllowNew = False
            m_dJobItemsAddedTable.AllowEdit = False
            m_dJobItemsAddedTable.AllowDelete = False
            Me.dgJobItemsAdded.DataSource = JobItemsAddedDataView
        End Set
    End Property

    Private m_dJobItemsAddedTable As DataView = Nothing

    Private ReadOnly Property SelectedItemAddedDataRow() As DataRow
        Get
            If Not Me.dgJobItemsAdded.CurrentRowIndex = -1 Then
                Return JobItemsAddedDataView(Me.dgJobItemsAdded.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _JobItemState As Entity.Sys.Enums.FormState = Entity.Sys.Enums.FormState.Insert

    Public Property JobItemState() As Entity.Sys.Enums.FormState
        Get
            Return _JobItemState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _JobItemState = Value
            If Value = Entity.Sys.Enums.FormState.Insert Then
                Me.btnSaveItem.Text = "Add"
            ElseIf Value = Entity.Sys.Enums.FormState.Update Then
                Me.btnSaveItem.Text = "Update"
            Else
                Me.btnSaveItem.Text = "Save"
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCCalloutBreakdown_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)

        Select Case True
            Case IsRFT
                Me.lblQualification.Text = "Trade"
            Case Else
                Me.lblQualification.Text = "Qualification"
        End Select
    End Sub

    Private Sub dgJobItemsAdded_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgJobItemsAdded.Click, dgJobItemsAdded.CurrentCellChanged
        If SelectedItemAddedDataRow Is Nothing Then
            JobItemState = Entity.Sys.Enums.FormState.Insert
            Exit Sub
        End If

        Me.txtJobItemSummary.Text = SelectedItemAddedDataRow.Item("Summary")
        JobItemState = Entity.Sys.Enums.FormState.Update
    End Sub

    Private Sub btnSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveItem.Click
        If Me.txtJobItemSummary.Text.Trim.Length = 0 Then
            ShowMessage("Job Item Summary Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If JobItemState = Entity.Sys.Enums.FormState.Insert Then
            JobItemsAddedDataView.Table.AcceptChanges()
            Dim newRow As DataRow = JobItemsAddedDataView.Table.NewRow
            newRow.Item("Summary") = Me.txtJobItemSummary.Text.Trim
            newRow.Item("RateID") = 0
            JobItemsAddedDataView.Table.Rows.Add(newRow)
        ElseIf JobItemState = Entity.Sys.Enums.FormState.Update Then
            JobItemsAddedDataView.Table.AcceptChanges()
            SelectedItemAddedDataRow.Item("Summary") = Me.txtJobItemSummary.Text.Trim
        End If

        JobItemsAddedDataView.Sort = "Summary"

        Me.txtJobItemSummary.Text = ""
        JobItemState = Entity.Sys.Enums.FormState.Insert
        Me.ActiveControl = Me.txtJobItemSummary
        Me.txtJobItemSummary.Focus()
    End Sub

    Private Sub btnRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveItem.Click
        If SelectedItemAddedDataRow Is Nothing Then
            ShowMessage("Please select an item to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        For Each tp As TabPage In Me.tcEngineerVisits.TabPages
            If CType(tp.Controls(0), UCVisitBreakdown).EngineerVisit.StatusEnumID >= CInt(Entity.Sys.Enums.VisitStatus.Scheduled) Then
                ShowMessage("This item cannot be removed as it is related to a visit that has progressed to 'scheduled' or further.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtJobItemSummary.Text = ""
                JobItemState = Entity.Sys.Enums.FormState.Insert
                Exit Sub
            End If
        Next

        If ShowMessage("Are you sure you want to remove this item of work?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        JobItemsAddedDataView.Table.AcceptChanges()
        JobItemsAddedDataView.Table.Rows.Remove(SelectedItemAddedDataRow)

        JobItemsAddedDataView.Sort = "Summary"

        Me.txtJobItemSummary.Text = ""
        JobItemState = Entity.Sys.Enums.FormState.Insert
        Me.ActiveControl = Me.txtJobItemSummary
        Me.txtJobItemSummary.Focus()
    End Sub

    Private Sub btnAddEngineerVisit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddEngineerVisit.Click
        AddEngineerVisit(Nothing)
    End Sub

    Private Sub btnRemoveEngineerVisit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveEngineerVisit.Click
        RemoveEngineerVisit()
    End Sub

    Private Sub btnAddRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRate.Click
        Using f As New FRMSiteScheduleOfRateList(OnContol.Site.SiteID, JobItemsAddedDataView, False, True)
            f.ShowDialog()
        End Using
    End Sub

#End Region

#Region "Setup"

    Public Sub SetupJobItemsAddedDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgJobItemsAdded)
        Dim tStyle As DataGridTableStyle = Me.dgJobItemsAdded.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Summary As New DataGridLabelColumn
        Summary.Format = ""
        Summary.FormatInfo = Nothing
        Summary.HeaderText = "Summary"
        Summary.MappingName = "Summary"
        Summary.ReadOnly = True
        Summary.Width = 375
        Summary.NullText = ""
        tStyle.GridColumnStyles.Add(Summary)

        Dim Qty As New DataGridLabelColumn
        Qty.Format = ""
        Qty.FormatInfo = Nothing
        Qty.HeaderText = "Qty"
        Qty.MappingName = "Qty"
        Qty.ReadOnly = True
        Qty.Width = 50
        Qty.NullText = ""
        tStyle.GridColumnStyles.Add(Qty)

        tStyle.ReadOnly = True
        tStyle.MappingName = "JOB_ITEMS_ADDED"
        Me.dgJobItemsAdded.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Functions"

    Public Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate

        Combo.SetUpCombo(cboQualification, OnContol.DvEngineerLevels.Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        If OnContol.Site.SiteID > 0 Then
            Combo.SetUpCombo(cboPriority, OnContol.DvCustomerPriorities.Table, "PriorityID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        End If

        Dim dtAdded As New DataTable
        dtAdded.Columns.Add(New DataColumn("JobItemID"))
        dtAdded.Columns.Add(New DataColumn("Summary"))
        dtAdded.Columns.Add(New DataColumn("RateID"))
        dtAdded.Columns.Add(New DataColumn("Qty"))
        dtAdded.Columns.Add(New DataColumn("SystemLinkID"))
        JobItemsAddedDataView = New DataView(dtAdded)

        If JobOfWork.JobOfWorkID = 0 Then
            AddEngineerVisit(Nothing)
            cboPriority.Enabled = True
            Combo.SetSelectedComboItem_By_Value(cboPriority, JobOfWork.Priority)
        Else
            Me.tcEngineerVisits.TabPages.Clear()
            Me.txtPONumber.Text = JobOfWork.PONumber

            Combo.SetSelectedComboItem_By_Value(cboPriority, JobOfWork.Priority)
            Combo.SetSelectedComboItem_By_Value(cboQualification, JobOfWork.QualificationID)

            For Each visit As Entity.EngineerVisits.EngineerVisit In OnContol.EngineerVisits.Where(Function(x) x.JobOfWorkID = JobOfWork.JobOfWorkID).ToList()
                AddEngineerVisit(visit)

                If visit.StatusEnumID > CInt(Entity.Sys.Enums.VisitStatus.Scheduled) Then
                    OnContol.cboJobType.Enabled = False

                End If
                If visit.StatusEnumID > CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule) Then
                    If JobOfWork.Priority > 0 Then
                        cboPriority.Enabled = False
                    Else
                        cboPriority.Enabled = True
                    End If
                End If

                If visit.StatusEnumID >= CInt(Entity.Sys.Enums.VisitStatus.Downloaded) Then
                    btnSaveItem.Enabled = False
                    btnRemoveItem.Enabled = False
                    btnAddRate.Enabled = False
                Else
                    btnSaveItem.Enabled = True
                    btnRemoveItem.Enabled = True
                    btnAddRate.Enabled = True
                End If
            Next

            If OnContol.Job.StatusEnumID >= CInt(Entity.Sys.Enums.JobStatus.Complete) Then
                Me.btnAddEngineerVisit.Enabled = False
                Me.btnRemoveEngineerVisit.Enabled = False
            End If
        End If

        If OnContol.DvJobItems.Table.Rows.Count > 0 Then
            For Each dr As DataRow In OnContol.DvJobItems.Table.Select("JobOfWorkID = " & JobOfWork.JobOfWorkID)
                Dim newRow As DataRow = JobItemsAddedDataView.Table.NewRow
                newRow.Item("JobItemID") = dr("JobItemID")
                newRow.Item("RateID") = dr("RateID")
                newRow.Item("Summary") = dr("Summary")
                newRow.Item("Qty") = dr("Qty")
                newRow.Item("SystemLinkID") = dr("SystemLinkID")
                JobItemsAddedDataView.Table.Rows.Add(newRow)
            Next
        End If

        JobItemsAddedDataView.Sort = "Summary"

        JobItemState = Entity.Sys.Enums.FormState.Insert
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        'DO NOTHING
    End Function

    Public Sub AddEngineerVisit(ByVal engineerVisit As Entity.EngineerVisits.EngineerVisit)
        Dim tp As New TabPage
        tp.BackColor = Color.White

        Dim ctrl As New UCVisitBreakdown
        ctrl.OnControl = Me
        ctrl.EngineerVisit = engineerVisit
        ctrl.Populate()

        If engineerVisit Is Nothing Then
            Combo.SetSelectedComboItem_By_Value(ctrl.cboStatus, 0)
        End If

        ctrl.Dock = DockStyle.Fill
        tp.Controls.Add(ctrl)
        Me.tcEngineerVisits.TabPages.Add(tp)
        CheckTabs()

        Me.tcEngineerVisits.SelectedTab = tp
    End Sub

    Private Sub RemoveEngineerVisit()
        If CType(Me.tcEngineerVisits.SelectedTab.Controls(0), UCVisitBreakdown).EngineerVisit.StatusEnumID > Entity.Sys.Enums.VisitStatus.Ready_For_Schedule Then
            ShowMessage("This visit is either scheduled, on a PDA or completed and therefore cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim OrderIDs As New ArrayList

        If CType(Me.tcEngineerVisits.SelectedTab.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID > 0 Then
            'ARE THERE ANY ORDERS FOR THIS VISIT?
            Dim ordered As Boolean = False
            Dim engOrders As DataView = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(CType(Me.tcEngineerVisits.SelectedTab.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID)

            If engOrders.Table.Rows.Count > 0 Then
                For Each dr As DataRow In engOrders.Table.Rows
                    'WHAT STATUS ARE THEY?
                    ordered = True
                Next
            End If

            'IF ANYTHING ELSE DON'T DELETE THE VISIT
            If ordered Then
                ShowMessage("This visit has orders that are being processed and therefore cannot be removed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                For Each OrderID As Integer In OrderIDs
                    OnContol.EngineerVisitsOrdersRemoved.Add(OrderID)
                Next

                OnContol.EngineerVisitsRemoved.Add(CType(Me.tcEngineerVisits.SelectedTab.Controls(0), UCVisitBreakdown).EngineerVisit.EngineerVisitID)
            End If

        End If
        Me.tcEngineerVisits.TabPages.Remove(Me.tcEngineerVisits.SelectedTab)

        CheckTabs()
    End Sub

    Private Sub CheckTabs()
        If Me.tcEngineerVisits.TabPages.Count = 1 Then
            Me.btnRemoveEngineerVisit.Enabled = False
        Else
            Me.btnRemoveEngineerVisit.Enabled = True
        End If

        Dim i As Integer = 1
        For Each tab As TabPage In Me.tcEngineerVisits.TabPages
            tab.Text = "Visit #" & i
            i += 1
        Next

        If CType(Me.tcEngineerVisits.TabPages(Me.tcEngineerVisits.TabPages.Count - 1).Controls(0), UCVisitBreakdown).EngineerVisit.StatusEnumID = Entity.Sys.Enums.VisitStatus.Uploaded Then
            Me.btnAddEngineerVisit.Enabled = True
        Else
            Me.btnAddEngineerVisit.Enabled = False
        End If
    End Sub

#End Region

End Class