Public Class UCQuoteContractOption3 : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboContractStatus, DynamicDataTables.QuoteContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
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

    Friend WithEvents grpQuoteContractOption3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpQuoteContractDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblQuoteContractDate As System.Windows.Forms.Label
    Friend WithEvents btnCalculatePrice As System.Windows.Forms.Button
    Friend WithEvents txtContractPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents gpbSite As System.Windows.Forms.GroupBox
    Friend WithEvents dgSites As System.Windows.Forms.DataGrid
    Friend WithEvents txtContractReference As System.Windows.Forms.TextBox
    Friend WithEvents lblContractReference As System.Windows.Forms.Label
    Friend WithEvents cboContractStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblContractStatus As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpQuoteContractOption3 = New System.Windows.Forms.GroupBox
        Me.btnCalculatePrice = New System.Windows.Forms.Button
        Me.txtContractPrice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblMsg = New System.Windows.Forms.Label
        Me.gpbSite = New System.Windows.Forms.GroupBox
        Me.dgSites = New System.Windows.Forms.DataGrid
        Me.txtContractReference = New System.Windows.Forms.TextBox
        Me.lblContractReference = New System.Windows.Forms.Label
        Me.cboContractStatus = New System.Windows.Forms.ComboBox
        Me.lblContractStatus = New System.Windows.Forms.Label
        Me.dtpQuoteContractDate = New System.Windows.Forms.DateTimePicker
        Me.lblQuoteContractDate = New System.Windows.Forms.Label
        Me.grpQuoteContractOption3.SuspendLayout()
        Me.gpbSite.SuspendLayout()
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpQuoteContractOption3
        '
        Me.grpQuoteContractOption3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpQuoteContractOption3.Controls.Add(Me.btnCalculatePrice)
        Me.grpQuoteContractOption3.Controls.Add(Me.txtContractPrice)
        Me.grpQuoteContractOption3.Controls.Add(Me.Label1)
        Me.grpQuoteContractOption3.Controls.Add(Me.lblMsg)
        Me.grpQuoteContractOption3.Controls.Add(Me.gpbSite)
        Me.grpQuoteContractOption3.Controls.Add(Me.txtContractReference)
        Me.grpQuoteContractOption3.Controls.Add(Me.lblContractReference)
        Me.grpQuoteContractOption3.Controls.Add(Me.cboContractStatus)
        Me.grpQuoteContractOption3.Controls.Add(Me.lblContractStatus)
        Me.grpQuoteContractOption3.Controls.Add(Me.dtpQuoteContractDate)
        Me.grpQuoteContractOption3.Controls.Add(Me.lblQuoteContractDate)
        Me.grpQuoteContractOption3.Location = New System.Drawing.Point(8, 8)
        Me.grpQuoteContractOption3.Name = "grpQuoteContractOption3"
        Me.grpQuoteContractOption3.Size = New System.Drawing.Size(625, 594)
        Me.grpQuoteContractOption3.TabIndex = 1
        Me.grpQuoteContractOption3.TabStop = False
        Me.grpQuoteContractOption3.Text = "Main Details"
        '
        'btnCalculatePrice
        '
        Me.btnCalculatePrice.UseVisualStyleBackColor = True
        Me.btnCalculatePrice.Location = New System.Drawing.Point(348, 77)
        Me.btnCalculatePrice.Name = "btnCalculatePrice"
        Me.btnCalculatePrice.Size = New System.Drawing.Size(266, 23)
        Me.btnCalculatePrice.TabIndex = 57
        Me.btnCalculatePrice.Text = "Calculate Price From Property Price"
        '
        'txtContractPrice
        '
        Me.txtContractPrice.Location = New System.Drawing.Point(136, 52)
        Me.txtContractPrice.MaxLength = 100
        Me.txtContractPrice.Name = "txtContractPrice"
        Me.txtContractPrice.Size = New System.Drawing.Size(200, 21)
        Me.txtContractPrice.TabIndex = 55
        Me.txtContractPrice.Tag = "ContractOption3.ContractPrice"
        Me.txtContractPrice.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 20)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Quote Price"
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMsg.Location = New System.Drawing.Point(16, 77)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(280, 23)
        Me.lblMsg.TabIndex = 54
        Me.lblMsg.Text = "Please save before adding properties"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpbSite
        '
        Me.gpbSite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbSite.Controls.Add(Me.dgSites)

        Me.gpbSite.Location = New System.Drawing.Point(10, 104)
        Me.gpbSite.Name = "gpbSite"
        Me.gpbSite.Size = New System.Drawing.Size(603, 483)
        Me.gpbSite.TabIndex = 53
        Me.gpbSite.TabStop = False
        Me.gpbSite.Text = "Properties"
        '
        'dgSites
        '
        Me.dgSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSites.DataMember = ""
        Me.dgSites.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSites.Location = New System.Drawing.Point(10, 27)
        Me.dgSites.Name = "dgSites"
        Me.dgSites.Size = New System.Drawing.Size(584, 447)
        Me.dgSites.TabIndex = 0
        '
        'txtContractReference
        '
        Me.txtContractReference.Location = New System.Drawing.Point(136, 28)
        Me.txtContractReference.MaxLength = 100
        Me.txtContractReference.Name = "txtContractReference"
        Me.txtContractReference.Size = New System.Drawing.Size(200, 21)
        Me.txtContractReference.TabIndex = 49
        Me.txtContractReference.Tag = "ContractOption3.ContractReference"
        Me.txtContractReference.Text = ""
        '
        'lblContractReference
        '
        Me.lblContractReference.Location = New System.Drawing.Point(14, 29)
        Me.lblContractReference.Name = "lblContractReference"
        Me.lblContractReference.Size = New System.Drawing.Size(118, 20)
        Me.lblContractReference.TabIndex = 52
        Me.lblContractReference.Text = "Quote Reference"
        '
        'cboContractStatus
        '
        Me.cboContractStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContractStatus.Location = New System.Drawing.Point(455, 28)
        Me.cboContractStatus.Name = "cboContractStatus"
        Me.cboContractStatus.Size = New System.Drawing.Size(158, 21)
        Me.cboContractStatus.TabIndex = 50
        Me.cboContractStatus.Tag = "ContractOption3.ContractStatus"
        '
        'lblContractStatus
        '
        Me.lblContractStatus.Location = New System.Drawing.Point(348, 29)
        Me.lblContractStatus.Name = "lblContractStatus"
        Me.lblContractStatus.Size = New System.Drawing.Size(99, 20)
        Me.lblContractStatus.TabIndex = 51
        Me.lblContractStatus.Text = "Quote Status"
        '
        'dtpQuoteContractDate
        '
        Me.dtpQuoteContractDate.Location = New System.Drawing.Point(455, 52)
        Me.dtpQuoteContractDate.Name = "dtpQuoteContractDate"
        Me.dtpQuoteContractDate.Size = New System.Drawing.Size(158, 21)
        Me.dtpQuoteContractDate.TabIndex = 5
        Me.dtpQuoteContractDate.Tag = "QuoteContractOption3.QuoteContractDate"
        '
        'lblQuoteContractDate
        '
        Me.lblQuoteContractDate.Location = New System.Drawing.Point(348, 52)
        Me.lblQuoteContractDate.Name = "lblQuoteContractDate"
        Me.lblQuoteContractDate.Size = New System.Drawing.Size(99, 20)
        Me.lblQuoteContractDate.TabIndex = 31
        Me.lblQuoteContractDate.Text = "Quote Date"
        '
        'UCQuoteContractOption3
        '
        Me.Controls.Add(Me.grpQuoteContractOption3)
        Me.Name = "UCQuoteContractOption3"
        Me.Size = New System.Drawing.Size(640, 616)
        Me.grpQuoteContractOption3.ResumeLayout(False)
        Me.gpbSite.ResumeLayout(False)
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentQuoteContractOption3
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Public Event RefreshButton()

    Private _currentQuoteContractOption3 As Entity.QuoteContractOption3s.QuoteContractOption3

    Public Property CurrentQuoteContractOption3() As Entity.QuoteContractOption3s.QuoteContractOption3
        Get
            Return _currentQuoteContractOption3
        End Get
        Set(ByVal Value As Entity.QuoteContractOption3s.QuoteContractOption3)
            _currentQuoteContractOption3 = Value

            If _currentQuoteContractOption3 Is Nothing Then
                _currentQuoteContractOption3 = New Entity.QuoteContractOption3s.QuoteContractOption3
                _currentQuoteContractOption3.Exists = False
            End If

            If _currentQuoteContractOption3.Exists Then
                Loading = True
                Populate()
                gpbSite.Enabled = True
                lblMsg.Visible = False
                Loading = False
            Else
                gpbSite.Enabled = False
                lblMsg.Visible = True
                txtContractPrice.Text = Format(CDbl(0.0), "C")
            End If

            Sites = DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(_currentQuoteContractOption3.QuoteContractID, IDToLinkTo)
        End Set
    End Property

    Private _IDToLinkTo As Integer = 0

    Public Property IDToLinkTo() As Integer
        Get
            Return _IDToLinkTo
        End Get
        Set(ByVal Value As Integer)
            _IDToLinkTo = Value
        End Set
    End Property

    Private _Sites As DataView

    Private Property Sites() As DataView
        Get
            Return _Sites
        End Get
        Set(ByVal Value As DataView)
            _Sites = Value
            _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString
            _Sites.AllowNew = False
            _Sites.AllowEdit = False
            _Sites.AllowDelete = False
            Me.dgSites.DataSource = Sites
        End Set
    End Property

    Private ReadOnly Property SelectedSiteDataRow() As DataRow
        Get
            If Not Me.dgSites.CurrentRowIndex = -1 Then
                Return Sites(Me.dgSites.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _loading As Boolean = False

    Private Property Loading() As Boolean
        Get
            Return _loading
        End Get
        Set(ByVal Value As Boolean)
            _loading = Value
        End Set
    End Property

#End Region

#Region "SetUp"

    Public Sub SetupSitesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgSites)
        Dim tStyle As DataGridTableStyle = Me.dgSites.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgSites.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 50
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 250
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        Dim ContractSiteReference As New DataGridLabelColumn
        ContractSiteReference.Format = ""
        ContractSiteReference.FormatInfo = Nothing
        ContractSiteReference.HeaderText = "Property Reference"
        ContractSiteReference.MappingName = "QuoteContractSiteReference"
        ContractSiteReference.ReadOnly = True
        ContractSiteReference.Width = 100
        ContractSiteReference.NullText = ""
        tStyle.GridColumnStyles.Add(ContractSiteReference)

        Dim StartDate As New DataGridLabelColumn
        StartDate.Format = "dd/MM/yyyy"
        StartDate.FormatInfo = Nothing
        StartDate.HeaderText = "Start Date"
        StartDate.MappingName = "StartDate"
        StartDate.ReadOnly = True
        StartDate.Width = 75
        StartDate.NullText = ""
        tStyle.GridColumnStyles.Add(StartDate)

        Dim EndDate As New DataGridLabelColumn
        EndDate.Format = "dd/MM/yyyy"
        EndDate.FormatInfo = Nothing
        EndDate.HeaderText = "End Date"
        EndDate.MappingName = "EndDate"
        EndDate.ReadOnly = True
        EndDate.Width = 75
        EndDate.NullText = ""
        tStyle.GridColumnStyles.Add(EndDate)

        Dim SitePrice As New DataGridLabelColumn
        SitePrice.Format = "C"
        SitePrice.FormatInfo = Nothing
        SitePrice.HeaderText = "Property Price"
        SitePrice.MappingName = "SitePrice"
        SitePrice.ReadOnly = True
        SitePrice.Width = 100
        SitePrice.NullText = ""
        tStyle.GridColumnStyles.Add(SitePrice)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString
        Me.dgSites.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgSites)
    End Sub

#End Region

#Region "Events"

    Private Sub UCQuoteContractOption3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
        SetupSitesDataGrid()
    End Sub

    Private Sub cboQuoteContractStatusID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContractStatus.SelectedIndexChanged
        'IS THE FORM LOADING
        If Loading Or CurrentQuoteContractOption3 Is Nothing Then
            Exit Sub
        End If

        'IF ADDING NEW CANNOT ACCEPT OR REJECT
        If Not CurrentQuoteContractOption3.Exists And
            (CType(Combo.GetSelectedItemValue(cboContractStatus), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Accepted Or
            CType(Combo.GetSelectedItemValue(cboContractStatus), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Rejected) Then

            ShowMessage("You can not accept or reject a quote until you have saved.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Combo.SetSelectedComboItem_By_Value(cboContractStatus, CInt(Entity.Sys.Enums.QuoteContractStatus.Generated))

            Exit Sub
        End If

        'ACCEPTING
        If CType(Combo.GetSelectedItemValue(cboContractStatus), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Accepted Then

            Dim msgRes As MsgBoxResult
            msgRes = ShowMessage("You are converting this quote to a live contract." & vbCrLf & "Do you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If msgRes = DialogResult.Yes Then
                If Save() = False Then
                    Exit Sub
                End If
            ElseIf msgRes = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ShowForm(GetType(FRMQuoteContractOption3Convert), True, New Object() {CurrentQuoteContractOption3.QuoteContractID})

            Dim Contract As Entity.ContractOption3s.ContractOption3 = DB.ContractOption3.ContractOption3_Get_For_Quote_ID(CurrentQuoteContractOption3.QuoteContractID)
            If Not Contract Is Nothing Then
                Loading = True
                Combo.SetSelectedComboItem_By_Value(cboContractStatus, Entity.Sys.Enums.QuoteContractStatus.Accepted)
                Loading = False
                Me.Save()
                Me.Populate(CurrentQuoteContractOption3.QuoteContractID)
            Else
                Combo.SetSelectedComboItem_By_Value(cboContractStatus, Entity.Sys.Enums.QuoteContractStatus.Generated)
                Me.Save()
            End If

            'REJECTING
        ElseIf CType(Combo.GetSelectedItemValue(cboContractStatus), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Rejected Then

            ShowForm(GetType(FRMQuoteRejection), True, New Object() {Me, ""})
            Me.Populate(CurrentQuoteContractOption3.QuoteContractID)
        End If

    End Sub

    Private Sub dgSites_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgSites.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgSites.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgSites.CurrentRowIndex = HitTestInfo.Row()
            End If

            If Not HitTestInfo.Column = 0 Then
                Exit Sub
            End If
            If SelectedSiteDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(Me.dgSites(Me.dgSites.CurrentRowIndex, 0))

            If selected = True Then
                Save()
                Dim site As New Entity.QuoteContractOption3Sites.QuoteContractOption3Site
                site.SetQuoteContractID = CurrentQuoteContractOption3.QuoteContractID
                site.SetSiteID = SelectedSiteDataRow("SiteID")
                site.SetQuoteContractSiteReference = DB.QuoteContractOption3Site.GetNextSiteReference(CurrentQuoteContractOption3.QuoteContractID)
                site = DB.QuoteContractOption3Site.Insert(site)

                ShowForm(GetType(FRMQuoteContractOption3Site), True, New Object() {site.QuoteContractSiteID, Me})
            Else

                If ShowMessage("You are about to remove this property from the quote." &
                vbCrLf & "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If DB.QuoteContractOption3Site.Delete(SelectedSiteDataRow("QuoteContractSiteID")) > 0 Then
                        ShowMessage("Could not remove property from quote as there are active visits", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If

            Sites = DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(CurrentQuoteContractOption3.QuoteContractID, IDToLinkTo)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgSites_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgSites.DoubleClick
        Try
            If SelectedSiteDataRow Is Nothing Then
                Exit Sub
            End If
            Dim Ticked As Boolean = Entity.Sys.Helper.MakeBooleanValid(Me.dgSites(Me.dgSites.CurrentRowIndex, 0))

            If Ticked = True Then
                ShowForm(GetType(FRMQuoteContractOption3Site), True, New Object() {SelectedSiteDataRow("QuoteContractSiteID"), Me})
            Else
                Save()
                Dim site As New Entity.QuoteContractOption3Sites.QuoteContractOption3Site
                site.SetQuoteContractID = CurrentQuoteContractOption3.QuoteContractID
                site.SetSiteID = SelectedSiteDataRow("SiteID")
                site.SetQuoteContractSiteReference = DB.QuoteContractOption3Site.GetNextSiteReference(CurrentQuoteContractOption3.QuoteContractID)
                site = DB.QuoteContractOption3Site.Insert(site)
                ShowForm(GetType(FRMQuoteContractOption3Site), True, New Object() {site.QuoteContractSiteID, Me})

            End If

            Sites = DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(CurrentQuoteContractOption3.QuoteContractID, IDToLinkTo)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtQuoteContractPrice_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContractPrice.LostFocus
        Dim price As String = ""

        If txtContractPrice.Text.Trim.Length = 0 Then
            price = Format(0.0, "C")
        ElseIf Not IsNumeric(txtContractPrice.Text.Replace("£", "")) Then
            price = Format(0.0, "C")
        Else
            price = Format(CDbl(txtContractPrice.Text.Replace("£", "")), "C")
        End If
        txtContractPrice.Text = price
    End Sub

    Public Sub RejectReasonChanged(ByVal Reason As String, ByVal ReasonID As Integer)
        CurrentQuoteContractOption3.SetReasonForReject = Reason
        CurrentQuoteContractOption3.SetReasonForRejectID = ReasonID
        Save()
    End Sub

    Private Sub btnCalculatePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculatePrice.Click
        If CurrentQuoteContractOption3.QuoteContractID > 0 Then
            Me.txtContractPrice.Text = Format(DB.QuoteContractOption3.QuoteContractCalculatedTotal(CurrentQuoteContractOption3.QuoteContractID), "C")
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentQuoteContractOption3 = DB.QuoteContractOption3.QuoteContractOption3_Get(ID)
        End If

        If CType(CurrentQuoteContractOption3.QuoteContractStatusID, Entity.Sys.Enums.QuoteContractStatus) <> Entity.Sys.Enums.QuoteContractStatus.Generated Then
            Entity.Sys.Helper.MakeReadOnly(Me.grpQuoteContractOption3, True)
        Else
            Entity.Sys.Helper.MakeReadOnly(Me.grpQuoteContractOption3, False)
        End If

        Me.txtContractReference.Text = CurrentQuoteContractOption3.QuoteContractReference
        Combo.SetSelectedComboItem_By_Value(Me.cboContractStatus, CurrentQuoteContractOption3.QuoteContractStatusID)
        Me.dtpQuoteContractDate.Value = CurrentQuoteContractOption3.QuoteContractDate
        Me.txtContractPrice.Text = Format(CurrentQuoteContractOption3.QuoteContractPrice, "C")

        RaiseEvent RefreshButton()
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentQuoteContractOption3.IgnoreExceptionsOnSetMethods = True

            CurrentQuoteContractOption3.SetCustomerID = IDToLinkTo
            CurrentQuoteContractOption3.SetQuoteContractReference = Me.txtContractReference.Text.Trim
            CurrentQuoteContractOption3.SetQuoteContractStatusID = Combo.GetSelectedItemValue(Me.cboContractStatus)
            CurrentQuoteContractOption3.QuoteContractDate = Me.dtpQuoteContractDate.Value
            CurrentQuoteContractOption3.SetQuoteContractPrice = Me.txtContractPrice.Text.Trim.Replace("£", "")

            Dim cV As New Entity.QuoteContractOption3s.QuoteContractOption3Validator
            cV.Validate(CurrentQuoteContractOption3)

            If CurrentQuoteContractOption3.Exists Then
                DB.QuoteContractOption3.Update(CurrentQuoteContractOption3)
            Else
                CurrentQuoteContractOption3 = DB.QuoteContractOption3.Insert(CurrentQuoteContractOption3)
            End If

            RaiseEvent StateChanged(CurrentQuoteContractOption3.QuoteContractID)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

End Class