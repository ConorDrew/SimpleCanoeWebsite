Public Class UCCustomerScheduleOfRate : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal EntityToLinkToIn As Entity.Sys.Enums.TableNames, ByVal IDToLinkToIn As Integer, Optional ByVal _readOnly As Boolean = False)
        MyBase.New()

        IsReadOnlyMode = _readOnly
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        EntityToLinkTo = EntityToLinkToIn
        IDToLinkTo = IDToLinkToIn
        Me.Dock = DockStyle.Fill
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

    Friend WithEvents grpCustomerScheduleOfRate As System.Windows.Forms.GroupBox
    Friend WithEvents cboScheduleOfRatesCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblScheduleOfRatesCategoryID As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents dgRates As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAddUpdate As System.Windows.Forms.Button
    Friend WithEvents txtTimeInMins As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAddSystemScheduleOfRates As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpCustomerScheduleOfRate = New System.Windows.Forms.GroupBox
        Me.txtTimeInMins = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAddSystemScheduleOfRates = New System.Windows.Forms.Button
        Me.btnAddUpdate = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.dgRates = New System.Windows.Forms.DataGrid
        Me.cboScheduleOfRatesCategoryID = New System.Windows.Forms.ComboBox
        Me.lblScheduleOfRatesCategoryID = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.lblCode = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.lblPrice = New System.Windows.Forms.Label
        Me.grpCustomerScheduleOfRate.SuspendLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpCustomerScheduleOfRate
        '
        Me.grpCustomerScheduleOfRate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.txtTimeInMins)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.Label1)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.btnAddSystemScheduleOfRates)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.btnAddUpdate)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.btnRemove)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.btnAddNew)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.dgRates)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.cboScheduleOfRatesCategoryID)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.lblScheduleOfRatesCategoryID)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.txtCode)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.lblCode)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.txtDescription)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.lblDescription)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.txtPrice)
        Me.grpCustomerScheduleOfRate.Controls.Add(Me.lblPrice)
        Me.grpCustomerScheduleOfRate.Location = New System.Drawing.Point(0, -1)
        Me.grpCustomerScheduleOfRate.Name = "grpCustomerScheduleOfRate"
        Me.grpCustomerScheduleOfRate.Size = New System.Drawing.Size(477, 419)
        Me.grpCustomerScheduleOfRate.TabIndex = 0
        Me.grpCustomerScheduleOfRate.TabStop = False
        Me.grpCustomerScheduleOfRate.Text = "Schedule Of Rates"
        '
        'txtTimeInMins
        '
        Me.txtTimeInMins.Location = New System.Drawing.Point(194, 135)
        Me.txtTimeInMins.MaxLength = 9
        Me.txtTimeInMins.Name = "txtTimeInMins"
        Me.txtTimeInMins.Size = New System.Drawing.Size(266, 21)
        Me.txtTimeInMins.TabIndex = 7
        Me.txtTimeInMins.Tag = "SystemScheduleOfRate.Price"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Time (In Minutes)"
        '
        'btnAddSystemScheduleOfRates
        '
        Me.btnAddSystemScheduleOfRates.Location = New System.Drawing.Point(139, 188)
        Me.btnAddSystemScheduleOfRates.Name = "btnAddSystemScheduleOfRates"
        Me.btnAddSystemScheduleOfRates.Size = New System.Drawing.Size(200, 23)
        Me.btnAddSystemScheduleOfRates.TabIndex = 12
        Me.btnAddSystemScheduleOfRates.Text = "Add System Schedule of Rates"
        '
        'btnAddUpdate
        '
        Me.btnAddUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddUpdate.Location = New System.Drawing.Point(368, 157)
        Me.btnAddUpdate.Name = "btnAddUpdate"
        Me.btnAddUpdate.Size = New System.Drawing.Size(101, 23)
        Me.btnAddUpdate.TabIndex = 10
        Me.btnAddUpdate.Text = "Add/Update"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(10, 186)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(101, 23)
        Me.btnRemove.TabIndex = 11
        Me.btnRemove.Text = "Remove"
        '
        'btnAddNew
        '
        Me.btnAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddNew.Location = New System.Drawing.Point(367, 187)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(101, 23)
        Me.btnAddNew.TabIndex = 13
        Me.btnAddNew.Text = "Add New"
        '
        'dgRates
        '
        Me.dgRates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRates.DataMember = ""
        Me.dgRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgRates.Location = New System.Drawing.Point(8, 214)
        Me.dgRates.Name = "dgRates"
        Me.dgRates.Size = New System.Drawing.Size(460, 196)
        Me.dgRates.TabIndex = 14
        '
        'cboScheduleOfRatesCategoryID
        '
        Me.cboScheduleOfRatesCategoryID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboScheduleOfRatesCategoryID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboScheduleOfRatesCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScheduleOfRatesCategoryID.Location = New System.Drawing.Point(194, 20)
        Me.cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID"
        Me.cboScheduleOfRatesCategoryID.Size = New System.Drawing.Size(266, 21)
        Me.cboScheduleOfRatesCategoryID.TabIndex = 1
        Me.cboScheduleOfRatesCategoryID.Tag = "CustomerScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblScheduleOfRatesCategoryID
        '
        Me.lblScheduleOfRatesCategoryID.Location = New System.Drawing.Point(11, 19)
        Me.lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID"
        Me.lblScheduleOfRatesCategoryID.Size = New System.Drawing.Size(179, 20)
        Me.lblScheduleOfRatesCategoryID.TabIndex = 0
        Me.lblScheduleOfRatesCategoryID.Text = "Schedule Of Rates Category"
        '
        'txtCode
        '
        Me.txtCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode.Location = New System.Drawing.Point(194, 47)
        Me.txtCode.MaxLength = 50
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(266, 21)
        Me.txtCode.TabIndex = 3
        Me.txtCode.Tag = "SystemScheduleOfRate.Code"
        '
        'lblCode
        '
        Me.lblCode.Location = New System.Drawing.Point(11, 47)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(179, 20)
        Me.lblCode.TabIndex = 2
        Me.lblCode.Text = "Code"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(194, 76)
        Me.txtDescription.MaxLength = 0
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(266, 53)
        Me.txtDescription.TabIndex = 5
        Me.txtDescription.Tag = "CustomerScheduleOfRate.Description"
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(11, 75)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(179, 20)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description"
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrice.Location = New System.Drawing.Point(194, 161)
        Me.txtPrice.MaxLength = 9
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(160, 21)
        Me.txtPrice.TabIndex = 9
        Me.txtPrice.Tag = "CustomerScheduleOfRate.Price"
        '
        'lblPrice
        '
        Me.lblPrice.Location = New System.Drawing.Point(11, 160)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(179, 20)
        Me.lblPrice.TabIndex = 8
        Me.lblPrice.Text = "Price"
        '
        'UCCustomerScheduleOfRate
        '
        Me.Controls.Add(Me.grpCustomerScheduleOfRate)
        Me.Name = "UCCustomerScheduleOfRate"
        Me.Size = New System.Drawing.Size(481, 424)
        Me.grpCustomerScheduleOfRate.ResumeLayout(False)
        Me.grpCustomerScheduleOfRate.PerformLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        Combo.SetUpCombo(cboScheduleOfRatesCategoryID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _EntityToLinkTo As Entity.Sys.Enums.TableNames

    Public Property EntityToLinkTo() As Entity.Sys.Enums.TableNames
        Get
            Return _EntityToLinkTo
        End Get
        Set(ByVal Value As Entity.Sys.Enums.TableNames)
            _EntityToLinkTo = Value
        End Set
    End Property

    Private _IDToLinkTo As Integer = 0

    Public Property IDToLinkTo() As Integer
        Get
            Return _IDToLinkTo
        End Get
        Set(ByVal Value As Integer)
            _IDToLinkTo = Value
            If IDToLinkTo = 0 Then
                grpCustomerScheduleOfRate.Enabled = False
            Else
                grpCustomerScheduleOfRate.Enabled = True

                Populate(IDToLinkTo)

            End If
        End Set
    End Property

    Private _dvRates As DataView

    Private Property RatesDataview() As DataView
        Get
            Return _dvRates
        End Get
        Set(ByVal value As DataView)
            _dvRates = value
            _dvRates.AllowNew = False
            _dvRates.AllowEdit = False
            _dvRates.AllowDelete = False
            _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString
            Me.dgRates.DataSource = RatesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedRatesDataRow() As DataRow
        Get
            If Not Me.dgRates.CurrentRowIndex = -1 Then
                Return RatesDataview(Me.dgRates.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _pageState As Entity.Sys.Enums.FormState

    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
            PageSetup()
        End Set
    End Property

    Private _currentCustomerScheduleOfRate As New Entity.CustomerScheduleOfRates.CustomerScheduleOfRate

    Public Property CurrentCustomerScheduleOfRate() As Entity.CustomerScheduleOfRates.CustomerScheduleOfRate
        Get
            Return _currentCustomerScheduleOfRate
        End Get
        Set(ByVal Value As Entity.CustomerScheduleOfRates.CustomerScheduleOfRate)
            _currentCustomerScheduleOfRate = Value
        End Set
    End Property

    Private _isReadOnlyMode As Boolean

    Public Property IsReadOnlyMode() As Boolean
        Get
            Return _isReadOnlyMode
        End Get
        Set(ByVal value As Boolean)
            _isReadOnlyMode = value
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub SetupRatesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgRates)
        Dim tbStyle As DataGridTableStyle = Me.dgRates.TableStyles(0)

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 90
        Category.NullText = ""
        tbStyle.GridColumnStyles.Add(Category)

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Code"
        Code.MappingName = "Code"
        Code.ReadOnly = True
        Code.Width = 65
        Code.NullText = ""
        tbStyle.GridColumnStyles.Add(Code)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 170
        Description.NullText = ""
        tbStyle.GridColumnStyles.Add(Description)

        Dim TimeInMins As New DataGridLabelColumn
        TimeInMins.Format = ""
        TimeInMins.FormatInfo = Nothing
        TimeInMins.HeaderText = "Time (Mins)"
        TimeInMins.MappingName = "TimeInMins"
        TimeInMins.ReadOnly = True
        TimeInMins.Width = 50
        TimeInMins.NullText = ""
        tbStyle.GridColumnStyles.Add(TimeInMins)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Unit Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 75
        Price.NullText = ""
        tbStyle.GridColumnStyles.Add(Price)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString
        Me.dgRates.TableStyles.Add(tbStyle)
    End Sub

    Private Sub PageSetup()
        If IsReadOnlyMode Then
            btnAddNew.Enabled = False
            btnRemove.Enabled = False
            btnAddUpdate.Enabled = False
            btnAddSystemScheduleOfRates.Enabled = False
            txtCode.Enabled = False
            txtDescription.Enabled = False
            txtPrice.Enabled = False
            txtTimeInMins.Enabled = False
            cboScheduleOfRatesCategoryID.Enabled = False
        Else
            If PageState = Entity.Sys.Enums.FormState.Insert Then
                btnAddNew.Text = "Cancel Add"
                btnAddUpdate.Text = "Add"
                dgRates.Enabled = False
                btnAddNew.Enabled = True
                btnRemove.Enabled = False
                btnAddUpdate.Enabled = True
                cboScheduleOfRatesCategoryID.Enabled = True
                txtCode.Enabled = True
                txtDescription.Enabled = True
                txtPrice.Enabled = True
                txtTimeInMins.Enabled = True

            ElseIf PageState = Entity.Sys.Enums.FormState.Update Then
                btnAddNew.Text = "Cancel Update"
                btnAddUpdate.Text = "Update"

                dgRates.Enabled = True
                btnAddNew.Enabled = True
                btnRemove.Enabled = True
                btnAddUpdate.Enabled = True
                If CBool(SelectedRatesDataRow("AllowDeleted")) = False Then
                    Combo.SetSelectedComboItem_By_Value(cboScheduleOfRatesCategoryID, 0)
                    cboScheduleOfRatesCategoryID.Enabled = False
                    txtCode.Enabled = False
                    txtDescription.Enabled = False
                Else
                    cboScheduleOfRatesCategoryID.Enabled = True
                    txtCode.Enabled = True
                    txtDescription.Enabled = True
                End If

                txtPrice.Enabled = True
                txtTimeInMins.Enabled = True
            Else 'Load
                btnAddNew.Text = "Add New"

                dgRates.Enabled = True
                btnAddNew.Enabled = True
                btnRemove.Enabled = False
                btnAddUpdate.Enabled = False
                cboScheduleOfRatesCategoryID.Enabled = False
                txtCode.Enabled = False
                txtDescription.Enabled = False
                txtPrice.Enabled = False
                txtTimeInMins.Enabled = False

                Combo.SetSelectedComboItem_By_Value(cboScheduleOfRatesCategoryID, 0)
                Me.txtCode.Text = ""
                Me.txtDescription.Text = ""
                Me.txtPrice.Text = Format(0, "C")
                Me.txtTimeInMins.Text = ""
            End If
        End If

    End Sub

#End Region

#Region "Events"

    Private Sub UCCustomerScheduleOfRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
        SetupRatesDataGrid()
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        If PageState = Entity.Sys.Enums.FormState.Insert Or PageState = Entity.Sys.Enums.FormState.Update Then
            Populate(IDToLinkTo)
            PageState = Entity.Sys.Enums.FormState.Load
        Else
            PageState = Entity.Sys.Enums.FormState.Insert
        End If
    End Sub

    Private Sub btnAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUpdate.Click
        Save()
    End Sub

    Private Sub dgRates_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRates.Click

        If Not IsReadOnlyMode Then
            If Not SelectedRatesDataRow Is Nothing Then
                With SelectedRatesDataRow
                    Combo.SetSelectedComboItem_By_Value(cboScheduleOfRatesCategoryID, .Item("ScheduleOfRatesCategoryID"))
                    Me.txtCode.Text = .Item("Code")
                    Me.txtDescription.Text = .Item("Description")
                    Me.txtPrice.Text = Format(.Item("Price"), "C")
                    Me.txtTimeInMins.Text = .Item("TimeInMins")
                End With
                PageState = Entity.Sys.Enums.FormState.Update
            End If
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Not SelectedRatesDataRow Is Nothing Then
            DeleteRate()
        Else
            PageState = Entity.Sys.Enums.FormState.Load
        End If
    End Sub

    Private Sub btnAddSystemScheduleOfRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSystemScheduleOfRates.Click
        Using f As New FRMSystemScheduleOfRateList(Entity.Sys.Enums.TableNames.tblCustomer, IDToLinkTo)
            f.ShowDialog()
        End Using
        Populate(IDToLinkTo)
    End Sub

#End Region

#Region "Functions"

    Public Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        RatesDataview = DB.CustomerScheduleOfRate.GetAll_For_CustomerID(ID)
        PageState = Entity.Sys.Enums.FormState.Load
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try

            If PageState = Entity.Sys.Enums.FormState.Update Then
                CurrentCustomerScheduleOfRate.SetAllowDeleted = SelectedRatesDataRow("AllowDeleted")
            Else
                CurrentCustomerScheduleOfRate.SetAllowDeleted = 1
            End If
            CurrentCustomerScheduleOfRate.SetCustomerID = IDToLinkTo
            CurrentCustomerScheduleOfRate.SetCode = Me.txtCode.Text.Trim
            CurrentCustomerScheduleOfRate.SetDescription = Me.txtDescription.Text.Trim
            CurrentCustomerScheduleOfRate.SetPrice = Replace(Me.txtPrice.Text.Trim, "£", "")
            CurrentCustomerScheduleOfRate.SetTimeInMins = Me.txtTimeInMins.Text.Trim

            If CurrentCustomerScheduleOfRate.AllowDeleted Then
                CurrentCustomerScheduleOfRate.SetScheduleOfRatesCategoryID = Combo.GetSelectedItemValue(cboScheduleOfRatesCategoryID)
            Else
                CurrentCustomerScheduleOfRate.SetScheduleOfRatesCategoryID = -1
            End If

            Dim rV As New Entity.CustomerScheduleOfRates.CustomerScheduleOfRateValidator
            rV.Validate(CurrentCustomerScheduleOfRate)

            'Try
            '    With SelectedRatesDataRow

            '        If CBool(.Item("AllowDeleted")) Then
            '            If MessageBox.Show("UPDATE :" & .Item("Description"), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            '                DB.CustomerScheduleOfRate.Delete(.Item("CustomerScheduleOfRateID"))

            '            End If
            '        Else
            '            MessageBox.Show("This rate is a system default and cannot be deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        End If

            '    End With
            'Catch ex As Exception
            '    MessageBox.Show("ERROR: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End Try

            If PageState = Entity.Sys.Enums.FormState.Update Then
                CurrentCustomerScheduleOfRate.SetCustomerScheduleOfRateID = SelectedRatesDataRow("CustomerScheduleOfRateID")
                DB.CustomerScheduleOfRate.Update(CurrentCustomerScheduleOfRate)

                'UPDATE SITE SCHEDULER OF RATES WITH CUSTOMER - WHERE THEY ACCPET CHANGES
                Try
                    With SelectedRatesDataRow

                        If CBool(.Item("AllowDeleted")) Then
                            If MessageBox.Show("UPDATE :" & .Item("Description"), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                                DB.CustomerScheduleOfRate.Delete(.Item("CustomerScheduleOfRateID"))
                                CurrentCustomerScheduleOfRate = DB.CustomerScheduleOfRate.Insert(CurrentCustomerScheduleOfRate)
                                '  Populate(IDToLinkTo)
                            End If
                        Else
                            MessageBox.Show("This rate is a system default and cannot be deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End With
                Catch ex As Exception
                    MessageBox.Show("ERROR: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

                '      CurrentCustomerScheduleOfRate = DB.CustomerScheduleOfRate.Insert(CurrentCustomerScheduleOfRate)

                'With CurrentCustomerScheduleOfRate
                '    DB.SiteScheduleOfRate.SiteScheduleOfRates_UpdateForCustomer(.CustomerID, .Price, _
                '                                                            .Description, .Code, _
                '                                                            .ScheduleOfRatesCategoryID, .TimeInMins)

                'End With
            Else
                CurrentCustomerScheduleOfRate = DB.CustomerScheduleOfRate.Insert(CurrentCustomerScheduleOfRate)
            End If

            Populate(IDToLinkTo)
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function

    Private Function DeleteRate()
        Try
            With SelectedRatesDataRow

                If CBool(.Item("AllowDeleted")) Then
                    If MessageBox.Show("DELETE :" & .Item("Description"), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                        DB.CustomerScheduleOfRate.Delete(.Item("CustomerScheduleOfRateID"))
                        Populate(IDToLinkTo)
                    End If
                Else
                    MessageBox.Show("This rate is a system default and cannot be deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End With
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function

#End Region

End Class