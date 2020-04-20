Public Class FRMTypeMakeModel : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpItems As System.Windows.Forms.GroupBox
    Friend WithEvents dgManager As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtPercentageRate As System.Windows.Forms.TextBox
    Friend WithEvents lblPercentageRate As System.Windows.Forms.Label
    Friend WithEvents cbxShowOnJob As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpItems = New System.Windows.Forms.GroupBox()
        Me.dgManager = New System.Windows.Forms.DataGrid()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.cbxShowOnJob = New System.Windows.Forms.CheckBox()
        Me.txtPercentageRate = New System.Windows.Forms.TextBox()
        Me.lblPercentageRate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpItems.SuspendLayout()
        CType(Me.dgManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpItems
        '
        Me.grpItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpItems.Controls.Add(Me.dgManager)
        Me.grpItems.Controls.Add(Me.btnAddNew)

        Me.grpItems.Location = New System.Drawing.Point(8, 72)
        Me.grpItems.Name = "grpItems"
        Me.grpItems.Size = New System.Drawing.Size(368, 416)
        Me.grpItems.TabIndex = 5
        Me.grpItems.TabStop = False
        Me.grpItems.Text = "Items"
        '
        'dgManager
        '
        Me.dgManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgManager.DataMember = ""
        Me.dgManager.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgManager.Location = New System.Drawing.Point(8, 53)
        Me.dgManager.Name = "dgManager"
        Me.dgManager.Size = New System.Drawing.Size(352, 355)
        Me.dgManager.TabIndex = 3
        '
        'btnAddNew
        '
        Me.btnAddNew.AccessibleDescription = "Add new item"
        Me.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddNew.UseVisualStyleBackColor = True
        Me.btnAddNew.Location = New System.Drawing.Point(8, 24)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(48, 23)
        Me.btnAddNew.TabIndex = 2
        Me.btnAddNew.Text = "New"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Select Type"
        '
        'cboType
        '
        Me.cboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboType.DisplayMember = "Description"
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(88, 45)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(288, 21)
        Me.cboType.TabIndex = 1
        Me.cboType.ValueMember = "Value"
        '
        'grpDetails
        '
        Me.grpDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetails.Controls.Add(Me.cbxShowOnJob)
        Me.grpDetails.Controls.Add(Me.txtPercentageRate)
        Me.grpDetails.Controls.Add(Me.lblPercentageRate)
        Me.grpDetails.Controls.Add(Me.Label3)
        Me.grpDetails.Controls.Add(Me.txtName)
        Me.grpDetails.Controls.Add(Me.txtDescription)
        Me.grpDetails.Controls.Add(Me.Label2)
        Me.grpDetails.Controls.Add(Me.btnSave)

        Me.grpDetails.Location = New System.Drawing.Point(384, 40)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(392, 216)
        Me.grpDetails.TabIndex = 7
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Details"
        '
        'cbxShowOnJob
        '
        Me.cbxShowOnJob.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxShowOnJob.AutoSize = True
        Me.cbxShowOnJob.Location = New System.Drawing.Point(208, 188)
        Me.cbxShowOnJob.Name = "cbxShowOnJob"
        Me.cbxShowOnJob.Size = New System.Drawing.Size(98, 17)
        Me.cbxShowOnJob.TabIndex = 10
        Me.cbxShowOnJob.Text = "Show on Job"
        Me.cbxShowOnJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbxShowOnJob.UseVisualStyleBackColor = True
        '
        'txtPercentageRate
        '
        Me.txtPercentageRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPercentageRate.Location = New System.Drawing.Point(104, 184)
        Me.txtPercentageRate.MaxLength = 255
        Me.txtPercentageRate.Name = "txtPercentageRate"
        Me.txtPercentageRate.Size = New System.Drawing.Size(87, 21)
        Me.txtPercentageRate.TabIndex = 9
        Me.txtPercentageRate.Visible = False
        '
        'lblPercentageRate
        '
        Me.lblPercentageRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPercentageRate.Location = New System.Drawing.Point(6, 184)
        Me.lblPercentageRate.Name = "lblPercentageRate"
        Me.lblPercentageRate.Size = New System.Drawing.Size(72, 21)
        Me.lblPercentageRate.TabIndex = 8
        Me.lblPercentageRate.Text = "Rate (%)"
        Me.lblPercentageRate.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Description"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(104, 24)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(280, 21)
        Me.txtName.TabIndex = 5
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(104, 56)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(280, 120)
        Me.txtDescription.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Name"
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "Save item"
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.ImageIndex = 1
        Me.btnSave.Location = New System.Drawing.Point(336, 184)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(48, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        '
        'FRMTypeMakeModel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(784, 494)
        Me.Controls.Add(Me.grpDetails)
        Me.Controls.Add(Me.grpItems)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboType)
        Me.MinimumSize = New System.Drawing.Size(792, 528)
        Me.Name = "FRMTypeMakeModel"
        Me.Text = "Picklists / Settings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.cboType, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.grpItems, 0)
        Me.Controls.SetChildIndex(Me.grpDetails, 0)
        Me.grpItems.ResumeLayout(False)
        CType(Me.dgManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupManagerDataGrid()

        Settings = DB.Manager.Get

        Combo.SetUpCombo(Me.cboType, DB.Picklists.PickListTypesLimited().Table, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)


        PopulateDatagrid(Entity.Sys.Enums.FormState.Load)



        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)

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

    Private _pageState As Entity.Sys.Enums.FormState
    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
        End Set
    End Property

    Private _dvManager As DataView
    Private Property ManagerDataview() As DataView
        Get
            Return _dvManager
        End Get
        Set(ByVal value As DataView)
            _dvManager = value
            _dvManager.AllowNew = False
            _dvManager.AllowEdit = False
            _dvManager.AllowDelete = False
            _dvManager.Table.TableName = Entity.Sys.Enums.TableNames.tblPickLists.ToString
            Me.dgManager.DataSource = ManagerDataview
        End Set
    End Property

    Private ReadOnly Property SelectedManagerDataRow() As DataRow
        Get
            If Not Me.dgManager.CurrentRowIndex = -1 Then
                Return ManagerDataview(Me.dgManager.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _settings As Entity.Management.Settings = Nothing
    Public Property Settings() As Entity.Management.Settings
        Get
            Return _settings
        End Get
        Set(ByVal Value As Entity.Management.Settings)
            _settings = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupManagerDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgManager.TableStyles(0)

        Dim name As New DataGridLabelColumn
        name.Format = ""
        name.FormatInfo = Nothing
        name.HeaderText = "Name"
        name.MappingName = "Name"
        name.ReadOnly = True
        name.Width = 177
        name.NullText = ""
        tbStyle.GridColumnStyles.Add(name)

        Dim description As New DataGridLabelColumn
        description.Format = ""
        description.FormatInfo = Nothing
        description.HeaderText = "Description"
        description.MappingName = "Description"
        description.ReadOnly = True
        description.Width = 177
        description.NullText = ""
        tbStyle.GridColumnStyles.Add(description)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPickLists.ToString
        Me.dgManager.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetUpPageState(ByVal state As Entity.Sys.Enums.FormState)
        Entity.Sys.Helper.ClearGroupBox(Me.grpDetails)
        Select Case state
            Case Entity.Sys.Enums.FormState.Load
                Me.grpDetails.Enabled = False
                Me.btnAddNew.Enabled = False

                Me.btnSave.Enabled = False
            Case Entity.Sys.Enums.FormState.Insert
                Me.grpDetails.Enabled = True
                Me.btnAddNew.Enabled = True

                Me.btnSave.Enabled = True
            Case Entity.Sys.Enums.FormState.Update
                Me.btnAddNew.Enabled = True
                Me.grpDetails.Enabled = True
                Me.btnSave.Enabled = True

        End Select
        PageState = state
    End Sub

#End Region

#Region "Events"

    Private Sub FRMManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If Me.cboType.SelectedIndex = 0 Then
            PopulateDatagrid(Entity.Sys.Enums.FormState.Load)
        Else
            PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
        End If
        If CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.PickListTypes.Engineer_Levels) Then
            cbxShowOnJob.Visible = True
        Else
            cbxShowOnJob.Visible = False

        End If
    End Sub

    Private Sub dgManager_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgManager.Click, dgManager.CurrentCellChanged
        Try
            SetUpPageState(Entity.Sys.Enums.FormState.Update)
            If Not SelectedManagerDataRow Is Nothing Then
                If Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow("Name")) = "RC - Recall" Then
                    ShowMessage("This item cannont be edited", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SetUpPageState(Entity.Sys.Enums.FormState.Insert)
                    Exit Sub
                End If

                Me.txtName.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow("Name"))
                Me.txtDescription.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow("Description"))
                If (CDbl(Entity.Sys.Helper.MakeDoubleValid(SelectedManagerDataRow("PercentageRate"))) = 0.0) Then
                    cbxShowOnJob.Checked = 0
                Else
                    cbxShowOnJob.Checked = 1
                End If
            Else
                If Me.cboType.SelectedIndex = 0 Then
                    SetUpPageState(Entity.Sys.Enums.FormState.Load)
                Else
                    SetUpPageState(Entity.Sys.Enums.FormState.Insert)
                End If
            End If
        Catch ex As Exception
            ShowMessage("Item data cannot load : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        SetUpPageState(Entity.Sys.Enums.FormState.Insert)
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Delete()
    End Sub



#End Region

#Region "Functions"

    Private Sub PopulateDatagrid(ByVal state As Entity.Sys.Enums.FormState)
        Try
            Me.lblPercentageRate.Visible = False
            Me.txtPercentageRate.Visible = False

            If CInt(Combo.GetSelectedItemValue(Me.cboType)) = 0 Then
                Dim dt As New DataTable
                dt.TableName = Entity.Sys.Enums.TableNames.tblPickLists.ToString
                ManagerDataview = New DataView(dt)
            Else
                ManagerDataview = DB.Picklists.GetAll(CInt(Combo.GetSelectedItemValue(Me.cboType)))

                Select Case CInt(Combo.GetSelectedItemValue(Me.cboType))
                    Case CInt(Entity.Sys.Enums.PickListTypes.VATCodes), CInt(Entity.Sys.Enums.PickListTypes.PartCategories)
                        Me.lblPercentageRate.Visible = True
                        Me.txtPercentageRate.Visible = True
                End Select
            End If
            SetUpPageState(state)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub SaveSettings()
    '    Try
    '        Settings.IgnoreExceptionsOnSetMethods = True
    '        Settings.SetWorkingHoursStart = Combo.GetSelectedItemValue(Me.cboWorkingHoursStart)
    '        Settings.SetWorkingHoursEnd = Combo.GetSelectedItemValue(Me.cboWorkingHoursEnd)
    '        Settings.SetMileageRate = Me.txtMileageRate.Text.Trim
    '        Settings.SetPartsMarkup = Me.txtPartsMarkup.Text.Trim
    '        Settings.SetRatesMarkup = Me.txtRatesMarkup.Text.Trim
    '        Settings.SetCalloutPrefix = Me.txtCalloutPrefix.Text.Trim
    '        Settings.SetMiscPrefix = Me.txtMiscPrefix.Text.Trim
    '        Settings.SetPPMPrefix = Me.txtPPMPrefix.Text.Trim
    '        Settings.SetQuotePrefix = Me.txtQuotePrefix.Text.Trim
    '        Settings.SetTimeSlot = cboTimeSlot.SelectedItem
    '        Settings.SetInvoicePrefix = Me.txtInvoicePrefix.Text.Trim
    '        Settings.SetRecallVariable = Me.txtRecallVariable.Text.Trim
    '        Settings.SetPartsImportMarkup = Me.txtPartsImportMarkup.text.trim
    '        Settings.SetServiceFromLetterPrefix = Me.txtServiceFromLetterPrefix.Text.Trim

    '        Dim sV As New Entity.Management.SettingsValidator
    '        sV.Validate(Settings)

    '        DB.Manager.UpdateSettings(Settings)

    '        'UPDATE ALL CUSTOMERS WHO ACCEPT CHANGES
    '        DB.CustomerCharge.UpdateALL(Settings.MileageRate, Settings.PartsMarkup, Settings.RatesMarkup)
    '        'UPDATE ALL SITES WHO ACCEPT CHANGES
    '        DB.SiteCharge.UpdateALL(Settings.MileageRate, Settings.PartsMarkup, Settings.RatesMarkup)

    '        ShowMessage("Settings updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Catch vex As ValidationException
    '        Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
    '        msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
    '        ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '    Catch ex As Exception
    '        ShowMessage("Error Saving : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub Save()
        Dim picklist As New Entity.PickLists.PickList
        picklist.IgnoreExceptionsOnSetMethods = True
        picklist.SetName = Me.txtName.Text.Trim
        picklist.SetDescription = Me.txtDescription.Text.Trim
        picklist.SetEnumTypeID = Combo.GetSelectedItemValue(Me.cboType)
        Select Case CInt(Combo.GetSelectedItemValue(Me.cboType))
            Case CInt(Entity.Sys.Enums.PickListTypes.VATCodes), CInt(Entity.Sys.Enums.PickListTypes.PartCategories)
                picklist.SetPercentageRate = Me.txtPercentageRate.Text.Trim
            Case Else
                picklist.SetPercentageRate = 0.0
                If CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.PickListTypes.Engineer_Levels) Then
                    picklist.SetPercentageRate = CDbl(cbxShowOnJob.Checked)
                End If

        End Select

        If PageState = Entity.Sys.Enums.FormState.Update Then

            picklist.SetManagerID = SelectedManagerDataRow.Item("ManagerID")

        End If

        Dim validator As New Entity.PickLists.PickListValidator

        Try
            validator.Validate(picklist)

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    DB.Picklists.Insert(picklist)
                Case Entity.Sys.Enums.FormState.Update
                    DB.Picklists.Update(picklist)
                    If CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.PickListTypes.PartCategories) Then DB.Picklists.UpdateSellPrices(picklist)
            End Select

            PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
        Catch ex As ValidationException
            ShowMessage(validator.CriticalMessagesString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Error Saving : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Delete()
        Try
            If Not SelectedManagerDataRow Is Nothing Then
                If ShowMessage("Are you sure you want to delete """ & SelectedManagerDataRow("Name") & """ from """ & Combo.GetSelectedItemDescription(Me.cboType) & """?", MessageBoxButtons.YesNo, MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    If CType(CInt(Combo.GetSelectedItemValue(Me.cboType)), Entity.Sys.Enums.PickListTypes) = Entity.Sys.Enums.PickListTypes.Regions Then
                        Dim dv As DataView = DB.Picklists.Region_Usage(SelectedManagerDataRow("ManagerID"))
                        If dv.Table.Rows.Count > 0 Then
                            Dim str As String = "The region you are trying to delete is still allocated to the following records:" & vbCrLf
                            For Each dr As DataRow In dv.Table.Rows
                                str += "* " & dr("type") & " - " & dr("Name") & vbCrLf
                            Next
                            MessageBox.Show(str, "Region Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If

                    DB.Picklists.Delete(SelectedManagerDataRow("ManagerID"))
                    PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
                End If
            Else
                ShowMessage("Please select an item to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ShowMessage("Error deleting : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region


End Class
