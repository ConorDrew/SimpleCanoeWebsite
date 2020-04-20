Public Class UCQuoteContractAlternative : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboQuoteContractStatusID, DynamicDataTables.QuoteContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

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

    Friend WithEvents grpQuoteContract As System.Windows.Forms.GroupBox
    Friend WithEvents txtQuoteContractReference As System.Windows.Forms.TextBox
    Friend WithEvents lblQuoteContractReference As System.Windows.Forms.Label
    Friend WithEvents dtpQuoteContractDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblQuoteContractDate As System.Windows.Forms.Label
    Friend WithEvents dtpContractStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractStart As System.Windows.Forms.Label
    Friend WithEvents dtpContractEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractEnd As System.Windows.Forms.Label
    Friend WithEvents cboQuoteContractStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblQuoteContractStatusID As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents grpSites As System.Windows.Forms.GroupBox
    Friend WithEvents dgSites As System.Windows.Forms.DataGrid
    Friend WithEvents lblContractPrice As System.Windows.Forms.Label
    Friend WithEvents txtQuoteContractPrice As System.Windows.Forms.TextBox
    Friend WithEvents btnCalculatePrice As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpQuoteContract = New System.Windows.Forms.GroupBox
        Me.btnCalculatePrice = New System.Windows.Forms.Button
        Me.txtQuoteContractPrice = New System.Windows.Forms.TextBox
        Me.lblContractPrice = New System.Windows.Forms.Label
        Me.lblMsg = New System.Windows.Forms.Label
        Me.grpSites = New System.Windows.Forms.GroupBox
        Me.dgSites = New System.Windows.Forms.DataGrid
        Me.txtQuoteContractReference = New System.Windows.Forms.TextBox
        Me.lblQuoteContractReference = New System.Windows.Forms.Label
        Me.dtpQuoteContractDate = New System.Windows.Forms.DateTimePicker
        Me.lblQuoteContractDate = New System.Windows.Forms.Label
        Me.dtpContractStart = New System.Windows.Forms.DateTimePicker
        Me.lblContractStart = New System.Windows.Forms.Label
        Me.dtpContractEnd = New System.Windows.Forms.DateTimePicker
        Me.lblContractEnd = New System.Windows.Forms.Label
        Me.cboQuoteContractStatusID = New System.Windows.Forms.ComboBox
        Me.lblQuoteContractStatusID = New System.Windows.Forms.Label
        Me.grpQuoteContract.SuspendLayout()
        Me.grpSites.SuspendLayout()
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpQuoteContract
        '
        Me.grpQuoteContract.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpQuoteContract.Controls.Add(Me.btnCalculatePrice)
        Me.grpQuoteContract.Controls.Add(Me.txtQuoteContractPrice)
        Me.grpQuoteContract.Controls.Add(Me.lblContractPrice)
        Me.grpQuoteContract.Controls.Add(Me.lblMsg)
        Me.grpQuoteContract.Controls.Add(Me.grpSites)
        Me.grpQuoteContract.Controls.Add(Me.txtQuoteContractReference)
        Me.grpQuoteContract.Controls.Add(Me.lblQuoteContractReference)
        Me.grpQuoteContract.Controls.Add(Me.dtpQuoteContractDate)
        Me.grpQuoteContract.Controls.Add(Me.lblQuoteContractDate)
        Me.grpQuoteContract.Controls.Add(Me.dtpContractStart)
        Me.grpQuoteContract.Controls.Add(Me.lblContractStart)
        Me.grpQuoteContract.Controls.Add(Me.dtpContractEnd)
        Me.grpQuoteContract.Controls.Add(Me.lblContractEnd)
        Me.grpQuoteContract.Controls.Add(Me.cboQuoteContractStatusID)
        Me.grpQuoteContract.Controls.Add(Me.lblQuoteContractStatusID)
        Me.grpQuoteContract.Location = New System.Drawing.Point(8, 8)
        Me.grpQuoteContract.Name = "grpQuoteContract"
        Me.grpQuoteContract.Size = New System.Drawing.Size(739, 594)
        Me.grpQuoteContract.TabIndex = 1
        Me.grpQuoteContract.TabStop = False
        Me.grpQuoteContract.Text = "Main Details"
        '
        'btnCalculatePrice
        '
        Me.btnCalculatePrice.UseVisualStyleBackColor = True
        Me.btnCalculatePrice.Location = New System.Drawing.Point(476, 104)
        Me.btnCalculatePrice.Name = "btnCalculatePrice"
        Me.btnCalculatePrice.Size = New System.Drawing.Size(195, 23)
        Me.btnCalculatePrice.TabIndex = 7
        Me.btnCalculatePrice.Text = "Calculate Price From Property Price"
        '
        'txtQuoteContractPrice
        '
        Me.txtQuoteContractPrice.Location = New System.Drawing.Point(476, 76)
        Me.txtQuoteContractPrice.MaxLength = 9
        Me.txtQuoteContractPrice.Name = "txtQuoteContractPrice"
        Me.txtQuoteContractPrice.Size = New System.Drawing.Size(195, 21)
        Me.txtQuoteContractPrice.TabIndex = 6
        Me.txtQuoteContractPrice.Tag = "Contract.ContractPrice"
        Me.txtQuoteContractPrice.Text = ""
        '
        'lblContractPrice
        '
        Me.lblContractPrice.Location = New System.Drawing.Point(344, 76)
        Me.lblContractPrice.Name = "lblContractPrice"
        Me.lblContractPrice.Size = New System.Drawing.Size(122, 21)
        Me.lblContractPrice.TabIndex = 51
        Me.lblContractPrice.Text = "Total Contract Price"
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMsg.Location = New System.Drawing.Point(16, 104)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(280, 23)
        Me.lblMsg.TabIndex = 35
        Me.lblMsg.Text = "Please save before adding properties"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpSites
        '
        Me.grpSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSites.Controls.Add(Me.dgSites)
        Me.grpSites.Location = New System.Drawing.Point(10, 134)
        Me.grpSites.Name = "grpSites"
        Me.grpSites.Size = New System.Drawing.Size(712, 450)
        Me.grpSites.TabIndex = 34
        Me.grpSites.TabStop = False
        Me.grpSites.Text = "Properties"
        '
        'dgSites
        '
        Me.dgSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSites.DataMember = ""
        Me.dgSites.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSites.Location = New System.Drawing.Point(11, 26)
        Me.dgSites.Name = "dgSites"
        Me.dgSites.Size = New System.Drawing.Size(692, 404)
        Me.dgSites.TabIndex = 2
        '
        'txtQuoteContractReference
        '
        Me.txtQuoteContractReference.Location = New System.Drawing.Point(144, 25)
        Me.txtQuoteContractReference.MaxLength = 100
        Me.txtQuoteContractReference.Name = "txtQuoteContractReference"
        Me.txtQuoteContractReference.Size = New System.Drawing.Size(177, 21)
        Me.txtQuoteContractReference.TabIndex = 0
        Me.txtQuoteContractReference.Tag = "QuoteContract.QuoteContractReference"
        Me.txtQuoteContractReference.Text = ""
        '
        'lblQuoteContractReference
        '
        Me.lblQuoteContractReference.Location = New System.Drawing.Point(14, 25)
        Me.lblQuoteContractReference.Name = "lblQuoteContractReference"
        Me.lblQuoteContractReference.Size = New System.Drawing.Size(134, 21)
        Me.lblQuoteContractReference.TabIndex = 31
        Me.lblQuoteContractReference.Text = "Quote Contract Ref."
        '
        'dtpQuoteContractDate
        '
        Me.dtpQuoteContractDate.Location = New System.Drawing.Point(144, 49)
        Me.dtpQuoteContractDate.Name = "dtpQuoteContractDate"
        Me.dtpQuoteContractDate.Size = New System.Drawing.Size(177, 21)
        Me.dtpQuoteContractDate.TabIndex = 2
        Me.dtpQuoteContractDate.Tag = "QuoteContract.QuoteContractDate"
        '
        'lblQuoteContractDate
        '
        Me.lblQuoteContractDate.Location = New System.Drawing.Point(14, 49)
        Me.lblQuoteContractDate.Name = "lblQuoteContractDate"
        Me.lblQuoteContractDate.Size = New System.Drawing.Size(134, 21)
        Me.lblQuoteContractDate.TabIndex = 31
        Me.lblQuoteContractDate.Text = "Quote Contract Date"
        '
        'dtpContractStart
        '
        Me.dtpContractStart.Location = New System.Drawing.Point(476, 25)
        Me.dtpContractStart.Name = "dtpContractStart"
        Me.dtpContractStart.Size = New System.Drawing.Size(195, 21)
        Me.dtpContractStart.TabIndex = 4
        Me.dtpContractStart.Tag = "QuoteContract.ContractStart"
        '
        'lblContractStart
        '
        Me.lblContractStart.Location = New System.Drawing.Point(344, 25)
        Me.lblContractStart.Name = "lblContractStart"
        Me.lblContractStart.Size = New System.Drawing.Size(103, 21)
        Me.lblContractStart.TabIndex = 31
        Me.lblContractStart.Text = "Contract Start"
        '
        'dtpContractEnd
        '
        Me.dtpContractEnd.Location = New System.Drawing.Point(476, 49)
        Me.dtpContractEnd.Name = "dtpContractEnd"
        Me.dtpContractEnd.Size = New System.Drawing.Size(195, 21)
        Me.dtpContractEnd.TabIndex = 5
        Me.dtpContractEnd.Tag = "QuoteContract.ContractEnd"
        '
        'lblContractEnd
        '
        Me.lblContractEnd.Location = New System.Drawing.Point(344, 49)
        Me.lblContractEnd.Name = "lblContractEnd"
        Me.lblContractEnd.Size = New System.Drawing.Size(103, 21)
        Me.lblContractEnd.TabIndex = 31
        Me.lblContractEnd.Text = "Contract End"
        '
        'cboQuoteContractStatusID
        '
        Me.cboQuoteContractStatusID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboQuoteContractStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQuoteContractStatusID.Location = New System.Drawing.Point(144, 76)
        Me.cboQuoteContractStatusID.Name = "cboQuoteContractStatusID"
        Me.cboQuoteContractStatusID.Size = New System.Drawing.Size(177, 21)
        Me.cboQuoteContractStatusID.TabIndex = 3
        Me.cboQuoteContractStatusID.Tag = "QuoteContract.QuoteContractStatusID"
        '
        'lblQuoteContractStatusID
        '
        Me.lblQuoteContractStatusID.Location = New System.Drawing.Point(14, 76)
        Me.lblQuoteContractStatusID.Name = "lblQuoteContractStatusID"
        Me.lblQuoteContractStatusID.Size = New System.Drawing.Size(134, 21)
        Me.lblQuoteContractStatusID.TabIndex = 31
        Me.lblQuoteContractStatusID.Text = "Quote Contract Status"
        '
        'UCQuoteContractAlternative
        '
        Me.Controls.Add(Me.grpQuoteContract)
        Me.Name = "UCQuoteContractAlternative"
        Me.Size = New System.Drawing.Size(754, 616)
        Me.grpQuoteContract.ResumeLayout(False)
        Me.grpSites.ResumeLayout(False)
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
            Return CurrentQuoteContract
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Public Event RefreshButton()

    Private _currentQuoteContract As Entity.QuoteContractAlternatives.QuoteContractAlternative

    Public Property CurrentQuoteContract() As Entity.QuoteContractAlternatives.QuoteContractAlternative
        Get
            Return _currentQuoteContract
        End Get
        Set(ByVal Value As Entity.QuoteContractAlternatives.QuoteContractAlternative)
            _currentQuoteContract = Value

            If _currentQuoteContract Is Nothing Then
                _currentQuoteContract = New Entity.QuoteContractAlternatives.QuoteContractAlternative
                _currentQuoteContract.Exists = False
            End If

            If _currentQuoteContract.Exists Then

                Loading = True
                Populate()
                lblMsg.Visible = False

                Loading = False
            Else
                lblMsg.Visible = True
                txtQuoteContractPrice.Text = Format(CDbl(0.0), "C")
            End If
        End Set
    End Property

    Private _IDToLinkTo As Integer = 0

    Public Property IDToLinkTo() As Integer
        Get
            Return _IDToLinkTo
        End Get
        Set(ByVal Value As Integer)
            _IDToLinkTo = Value
            Sites = DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(CurrentQuoteContract.QuoteContractID, IDToLinkTo)
        End Set
    End Property

    Private _Sites As DataView

    Private Property Sites() As DataView
        Get
            Return _Sites
        End Get
        Set(ByVal Value As DataView)
            _Sites = Value
            _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString
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
        Site.Width = 500
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

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
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString
        Me.dgSites.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgSites)
    End Sub

#End Region

#Region "Events"

    Private Sub UCQuoteContract_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub dgSites_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgSites.MouseUp
        Try
            If CType(CurrentQuoteContract.QuoteContractStatusID, Entity.Sys.Enums.QuoteContractStatus) <> Entity.Sys.Enums.QuoteContractStatus.Generated Then
                Exit Sub
            End If
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
                Dim site As New Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite
                site.SetQuoteContractID = CurrentQuoteContract.QuoteContractID
                site.SetSiteID = SelectedSiteDataRow("SiteID")
                site = DB.QuoteContractAlternativeSite.Insert(site)

                ShowForm(GetType(FRMQuoteContractAlternativeSite), True, New Object() {site.QuoteContractSiteID, SelectedSiteDataRow("SiteID"), CurrentQuoteContract, Me})
            Else
                If ShowMessage("Are you sure you want to remove this property from the quote.",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    DB.QuoteContractAlternativeSite.Delete(SelectedSiteDataRow("QuoteContractSiteID"))

                End If
            End If
            Sites = DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(CurrentQuoteContract.QuoteContractID, IDToLinkTo)
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
                ShowForm(GetType(FRMQuoteContractAlternativeSite), True, New Object() {SelectedSiteDataRow("QuoteContractSiteID"), SelectedSiteDataRow("SiteID"), CurrentQuoteContract, Me})
            Else
                If CType(CurrentQuoteContract.QuoteContractStatusID, Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Generated Then
                    ShowForm(GetType(FRMQuoteContractAlternativeSite), True, New Object() {0, SelectedSiteDataRow("SiteID"), CurrentQuoteContract, Me})
                End If
            End If

            Sites = DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(CurrentQuoteContract.QuoteContractID, IDToLinkTo)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboQuoteContractStatusID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboQuoteContractStatusID.SelectedIndexChanged
        'IS THE FORM LOADING
        If Loading Or CurrentQuoteContract Is Nothing Then
            Exit Sub
        End If

        'IF ADDING NEW CANNOT ACCEPT OR REJECT
        If Not CurrentQuoteContract.Exists And
            (CType(Combo.GetSelectedItemValue(cboQuoteContractStatusID), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Accepted Or
            CType(Combo.GetSelectedItemValue(cboQuoteContractStatusID), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Rejected) Then

            ShowMessage("You can not accept or reject a quote until you have saved.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Combo.SetSelectedComboItem_By_Value(cboQuoteContractStatusID, CInt(Entity.Sys.Enums.QuoteContractStatus.Generated))

            Exit Sub
        End If

        'ACCEPTING
        If CType(Combo.GetSelectedItemValue(cboQuoteContractStatusID), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Accepted Then

            Dim msgRes As MsgBoxResult
            msgRes = ShowMessage("You are converting this quote to a live contract." & vbCrLf & "Do you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If msgRes = DialogResult.Yes Then
                If Save() = False Then
                    Exit Sub
                End If
            ElseIf msgRes = MsgBoxResult.Cancel Then
                Exit Sub
            End If

            ShowForm(GetType(FRMQuoteContractAlternativeConvert), True, New Object() {CurrentQuoteContract.QuoteContractID})

            Dim Contract As Entity.ContractsAlternative.ContractAlternative = DB.ContractAlternative.Get_For_Quote_ID(CurrentQuoteContract.QuoteContractID)
            If Not Contract Is Nothing Then
                Loading = True
                Combo.SetSelectedComboItem_By_Value(cboQuoteContractStatusID, Entity.Sys.Enums.QuoteContractStatus.Accepted)
                Loading = False
                Me.Save()
                Me.Populate(CurrentQuoteContract.QuoteContractID)
            Else
                Combo.SetSelectedComboItem_By_Value(cboQuoteContractStatusID, Entity.Sys.Enums.QuoteContractStatus.Generated)
                Me.Save()
            End If

            'REJECTING
        ElseIf CType(Combo.GetSelectedItemValue(cboQuoteContractStatusID), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Rejected Then

            ShowForm(GetType(FRMQuoteRejection), True, New Object() {Me, ""})
            Me.Populate(CurrentQuoteContract.QuoteContractID)
        End If

    End Sub

    Private Sub txtQuoteContractPrice_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuoteContractPrice.LostFocus
        Dim price As String = ""

        If txtQuoteContractPrice.Text.Trim.Length = 0 Then
            price = Format(0.0, "C")
        ElseIf Not IsNumeric(txtQuoteContractPrice.Text.Replace("£", "")) Then
            price = Format(0.0, "C")
        Else
            price = Format(CDbl(txtQuoteContractPrice.Text.Replace("£", "")), "C")
        End If
        txtQuoteContractPrice.Text = price
    End Sub

    Public Sub RejectReasonChanged(ByVal Reason As String, ByVal ReasonID As Integer)
        CurrentQuoteContract.SetReasonForReject = Reason
        CurrentQuoteContract.SetReasonForRejectID = ReasonID
        Save()
    End Sub

    Private Sub btnCalculatePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculatePrice.Click
        If CurrentQuoteContract.QuoteContractID > 0 Then
            Me.txtQuoteContractPrice.Text = Format(DB.QuoteContractAlternative.CalculatedTotal(CurrentQuoteContract.QuoteContractID), "C")
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentQuoteContract = DB.QuoteContractAlternative.Get(ID)
        End If
        If CType(CurrentQuoteContract.QuoteContractStatusID, Entity.Sys.Enums.QuoteContractStatus) <> Entity.Sys.Enums.QuoteContractStatus.Generated Then
            Entity.Sys.Helper.MakeReadOnly(Me.grpQuoteContract, True)
            ' Entity.Sys.Helper.MakeReadOnly(Me.grpSites, True)
        Else
            Entity.Sys.Helper.MakeReadOnly(Me.grpQuoteContract, False)
            '  Entity.Sys.Helper.MakeReadOnly(Me.grpSites, False)
        End If

        Me.txtQuoteContractReference.Text = CurrentQuoteContract.QuoteContractReference
        Me.dtpQuoteContractDate.Value = CurrentQuoteContract.QuoteContractDate
        Me.dtpContractStart.Value = CurrentQuoteContract.ContractStart
        Me.dtpContractEnd.Value = CurrentQuoteContract.ContractEnd
        Combo.SetSelectedComboItem_By_Value(Me.cboQuoteContractStatusID, CurrentQuoteContract.QuoteContractStatusID)
        Me.txtQuoteContractPrice.Text = Format(CurrentQuoteContract.QuoteContractPrice, "C")

        Me.txtQuoteContractPrice.Text = Format(CurrentQuoteContract.QuoteContractPrice, "C")

        RaiseEvent RefreshButton()
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try

            Me.Cursor = Cursors.WaitCursor
            CurrentQuoteContract.IgnoreExceptionsOnSetMethods = True
            CurrentQuoteContract.SetCustomerID = IDToLinkTo
            CurrentQuoteContract.SetQuoteContractReference = Me.txtQuoteContractReference.Text.Trim
            CurrentQuoteContract.QuoteContractDate = Me.dtpQuoteContractDate.Value
            CurrentQuoteContract.ContractStart = Me.dtpContractStart.Value
            CurrentQuoteContract.ContractEnd = Me.dtpContractEnd.Value
            CurrentQuoteContract.SetQuoteContractStatusID = Combo.GetSelectedItemValue(Me.cboQuoteContractStatusID)
            CurrentQuoteContract.SetQuoteContractPrice = Me.txtQuoteContractPrice.Text.Trim.Replace("£", "")

            If CurrentQuoteContract.ReasonForReject = "" And CType(CurrentQuoteContract.QuoteContractStatusID, Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Rejected Then
                CurrentQuoteContract.SetQuoteContractStatusID = CInt(Entity.Sys.Enums.QuoteContractStatus.Generated)
            End If

            If CType(CurrentQuoteContract.QuoteContractStatusID, Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Accepted And
                DB.ContractAlternative.Get_For_Quote_ID(CurrentQuoteContract.QuoteContractID) Is Nothing Then
                CurrentQuoteContract.SetQuoteContractStatusID = CInt(Entity.Sys.Enums.QuoteContractStatus.Generated)
            End If

            Dim cV As New Entity.QuoteContractAlternatives.QuoteContractAlternativeValidator
            cV.Validate(CurrentQuoteContract)

            If CurrentQuoteContract.Exists Then
                DB.QuoteContractAlternative.Update(CurrentQuoteContract)
            Else
                CurrentQuoteContract = DB.QuoteContractAlternative.Insert(CurrentQuoteContract)
            End If

            Populate()
            RaiseEvent StateChanged(CurrentQuoteContract.QuoteContractID)

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