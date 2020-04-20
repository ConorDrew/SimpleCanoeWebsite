Public Class FRMTimeSlotRates : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents dgTimeslots As System.Windows.Forms.DataGrid
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents gpbTimeslots As System.Windows.Forms.GroupBox
    Friend WithEvents tabTimeSlots As System.Windows.Forms.TabPage
    Friend WithEvents tabBankHolidays As System.Windows.Forms.TabPage
    Friend WithEvents gpbBankHolidays As System.Windows.Forms.GroupBox
    Friend WithEvents dgBankHolidays As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gpbTimeslots = New System.Windows.Forms.GroupBox
        Me.dgTimeslots = New System.Windows.Forms.DataGrid
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabTimeSlots = New System.Windows.Forms.TabPage
        Me.tabBankHolidays = New System.Windows.Forms.TabPage
        Me.btnSave = New System.Windows.Forms.Button
        Me.gpbBankHolidays = New System.Windows.Forms.GroupBox
        Me.dgBankHolidays = New System.Windows.Forms.DataGrid
        Me.gpbTimeslots.SuspendLayout()
        CType(Me.dgTimeslots, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabTimeSlots.SuspendLayout()
        Me.tabBankHolidays.SuspendLayout()
        Me.gpbBankHolidays.SuspendLayout()
        CType(Me.dgBankHolidays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbTimeslots
        '
        Me.gpbTimeslots.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbTimeslots.Controls.Add(Me.dgTimeslots)

        Me.gpbTimeslots.Location = New System.Drawing.Point(8, 8)
        Me.gpbTimeslots.Name = "gpbTimeslots"
        Me.gpbTimeslots.Size = New System.Drawing.Size(680, 256)
        Me.gpbTimeslots.TabIndex = 0
        Me.gpbTimeslots.TabStop = False
        Me.gpbTimeslots.Text = "Time Slot Charge Rates"
        '
        'dgTimeslots
        '
        Me.dgTimeslots.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTimeslots.DataMember = ""
        Me.dgTimeslots.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTimeslots.Location = New System.Drawing.Point(10, 21)
        Me.dgTimeslots.Name = "dgTimeslots"
        Me.dgTimeslots.Size = New System.Drawing.Size(661, 227)
        Me.dgTimeslots.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabTimeSlots)
        Me.TabControl1.Controls.Add(Me.tabBankHolidays)
        Me.TabControl1.Location = New System.Drawing.Point(0, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(704, 296)
        Me.TabControl1.TabIndex = 1
        '
        'tabTimeSlots
        '
        Me.tabTimeSlots.Controls.Add(Me.gpbTimeslots)
        Me.tabTimeSlots.Location = New System.Drawing.Point(4, 22)
        Me.tabTimeSlots.Name = "tabTimeSlots"
        Me.tabTimeSlots.Size = New System.Drawing.Size(696, 270)
        Me.tabTimeSlots.TabIndex = 0
        Me.tabTimeSlots.Text = "Time Slot Charge Rates"
        '
        'tabBankHolidays
        '
        Me.tabBankHolidays.Controls.Add(Me.gpbBankHolidays)
        Me.tabBankHolidays.Location = New System.Drawing.Point(4, 22)
        Me.tabBankHolidays.Name = "tabBankHolidays"
        Me.tabBankHolidays.Size = New System.Drawing.Size(696, 270)
        Me.tabBankHolidays.TabIndex = 1
        Me.tabBankHolidays.Text = "Bank Holidays"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(616, 352)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Save"
        '
        'gpbBankHolidays
        '
        Me.gpbBankHolidays.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbBankHolidays.Controls.Add(Me.dgBankHolidays)

        Me.gpbBankHolidays.Location = New System.Drawing.Point(8, 7)
        Me.gpbBankHolidays.Name = "gpbBankHolidays"
        Me.gpbBankHolidays.Size = New System.Drawing.Size(680, 256)
        Me.gpbBankHolidays.TabIndex = 1
        Me.gpbBankHolidays.TabStop = False
        Me.gpbBankHolidays.Text = "Bank Holiday Rates"
        '
        'dgBankHolidays
        '
        Me.dgBankHolidays.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgBankHolidays.DataMember = ""
        Me.dgBankHolidays.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgBankHolidays.Location = New System.Drawing.Point(10, 22)
        Me.dgBankHolidays.Name = "dgBankHolidays"
        Me.dgBankHolidays.Size = New System.Drawing.Size(661, 226)
        Me.dgBankHolidays.TabIndex = 0
        '
        'FRMTimeSlotRates
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(704, 390)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FRMTimeSlotRates"
        Me.Text = "Time Slot Rates"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.gpbTimeslots.ResumeLayout(False)
        CType(Me.dgTimeslots, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabTimeSlots.ResumeLayout(False)
        Me.tabBankHolidays.ResumeLayout(False)
        Me.gpbBankHolidays.ResumeLayout(False)
        CType(Me.dgBankHolidays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe

        LoadForm(sender, e, Me)
        LabourTypesDataview = DB.TimeSlotRates.LabourTypes_Get
        SetupBankHolidayDataGrid()
        SetupRatesDataGrid()
        Populate()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get

        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe

    End Sub

#End Region

#Region "Properties"

    Private _dvRates As DataView
    Private Property RatesDataview() As DataView
        Get
            Return _dvRates
        End Get
        Set(ByVal value As DataView)
            _dvRates = value
            _dvRates.AllowNew = False
            _dvRates.AllowEdit = True
            _dvRates.AllowDelete = False
            _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblTimeslotRates.ToString
            Me.dgTimeslots.DataSource = RatesDataview
        End Set
    End Property

    Private _dvBankHoliday As DataView
    Private Property BankHolidayDataview() As DataView
        Get
            Return _dvBankHoliday
        End Get
        Set(ByVal value As DataView)
            _dvBankHoliday = value
            _dvBankHoliday.AllowNew = True
            _dvBankHoliday.AllowEdit = True
            _dvBankHoliday.AllowDelete = False
            _dvBankHoliday.Table.TableName = Entity.Sys.Enums.TableNames.tblBankHolidays.ToString
            Me.dgBankHolidays.DataSource = BankHolidayDataview
        End Set
    End Property

    Private _dvLabourTypes As DataView
    Private Property LabourTypesDataview() As DataView
        Get
            Return _dvLabourTypes
        End Get
        Set(ByVal value As DataView)
            _dvLabourTypes = value
        End Set
    End Property
#End Region

#Region "Setup"

    Public Sub SetupRatesDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgTimeslots.TableStyles(0)

        Dim Timeslot As New DataGridLabelColumn
        Timeslot.Format = "HH:mm"
        Timeslot.FormatInfo = Nothing
        Timeslot.HeaderText = "Timeslot"
        Timeslot.MappingName = "Timeslot"
        Timeslot.ReadOnly = False
        Timeslot.Width = 75
        Timeslot.NullText = ""
        tbStyle.GridColumnStyles.Add(Timeslot)

        Dim Monday As New DataGridComboBoxColumn
        Monday.HeaderText = "Monday"
        Monday.MappingName = "Monday"
        Monday.ReadOnly = False
        Monday.Width = 90
        Monday.ComboBox.DataSource = LabourTypesDataview
        Monday.ComboBox.DisplayMember = "LabourType"
        Monday.ComboBox.ValueMember = "LabourTypeID"
        tbStyle.GridColumnStyles.Add(Monday)

        Dim Tuesday As New DataGridComboBoxColumn
        Tuesday.HeaderText = "Tuesday"
        Tuesday.MappingName = "Tuesday"
        Tuesday.ReadOnly = False
        Tuesday.Width = 90
        Tuesday.ComboBox.DataSource = LabourTypesDataview
        Tuesday.ComboBox.DisplayMember = "LabourType"
        Tuesday.ComboBox.ValueMember = "LabourTypeID"
        tbStyle.GridColumnStyles.Add(Tuesday)

        Dim Wednesday As New DataGridComboBoxColumn
        Wednesday.HeaderText = "Wednesday"
        Wednesday.MappingName = "Wednesday"
        Wednesday.ReadOnly = False
        Wednesday.Width = 90
        Wednesday.ComboBox.DataSource = LabourTypesDataview
        Wednesday.ComboBox.DisplayMember = "LabourType"
        Wednesday.ComboBox.ValueMember = "LabourTypeID"
        tbStyle.GridColumnStyles.Add(Wednesday)

        Dim Thursday As New DataGridComboBoxColumn
        Thursday.HeaderText = "Thursday"
        Thursday.MappingName = "Thursday"
        Thursday.ReadOnly = False
        Thursday.Width = 90
        Thursday.ComboBox.DataSource = LabourTypesDataview
        Thursday.ComboBox.DisplayMember = "LabourType"
        Thursday.ComboBox.ValueMember = "LabourTypeID"
        tbStyle.GridColumnStyles.Add(Thursday)

        Dim Friday As New DataGridComboBoxColumn
        Friday.HeaderText = "Friday"
        Friday.MappingName = "Friday"
        Friday.ReadOnly = False
        Friday.Width = 90
        Friday.ComboBox.DataSource = LabourTypesDataview
        Friday.ComboBox.DisplayMember = "LabourType"
        Friday.ComboBox.ValueMember = "LabourTypeID"
        tbStyle.GridColumnStyles.Add(Friday)

        Dim Saturday As New DataGridComboBoxColumn
        Saturday.HeaderText = "Saturday"
        Saturday.MappingName = "Saturday"
        Saturday.ReadOnly = False
        Saturday.Width = 90
        Saturday.ComboBox.DataSource = LabourTypesDataview
        Saturday.ComboBox.DisplayMember = "LabourType"
        Saturday.ComboBox.ValueMember = "LabourTypeID"
        tbStyle.GridColumnStyles.Add(Saturday)

        Dim Sunday As New DataGridComboBoxColumn
        Sunday.HeaderText = "Sunday"
        Sunday.MappingName = "Sunday"
        Sunday.ReadOnly = False
        Sunday.Width = 90
        Sunday.ComboBox.DataSource = LabourTypesDataview
        Sunday.ComboBox.DisplayMember = "LabourType"
        Sunday.ComboBox.ValueMember = "LabourTypeID"
        tbStyle.GridColumnStyles.Add(Sunday)

        tbStyle.AllowSorting = False
        tbStyle.ReadOnly = False
        dgTimeslots.ReadOnly = False
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblTimeslotRates.ToString
        Me.dgTimeslots.TableStyles.Add(tbStyle)
    End Sub

    Public Sub SetupBankHolidayDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgBankHolidays.TableStyles(0)

        Dim BankHolidayDate As New DataGridEditableTextBoxColumn
        BankHolidayDate.Format = "dd/MM/yyyy"
        BankHolidayDate.FormatInfo = Nothing
        BankHolidayDate.HeaderText = "Bank Holiday Date"
        BankHolidayDate.MappingName = "BankHolidayDate"
        BankHolidayDate.ReadOnly = False
        BankHolidayDate.Width = 150
        BankHolidayDate.NullText = ""
        tbStyle.GridColumnStyles.Add(BankHolidayDate)

        Dim LabourRateID As New DataGridComboBoxColumn
        LabourRateID.HeaderText = "Labour Rate"
        LabourRateID.MappingName = "LabourRateID"
        LabourRateID.ReadOnly = False
        LabourRateID.Width = 150
        LabourRateID.ComboBox.DataSource = LabourTypesDataview
        LabourRateID.ComboBox.DisplayMember = "LabourType"
        LabourRateID.ComboBox.ValueMember = "LabourTypeID"
        tbStyle.GridColumnStyles.Add(LabourRateID)

        tbStyle.AllowSorting = False
        tbStyle.ReadOnly = False
        dgBankHolidays.ReadOnly = False
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblBankHolidays.ToString
        Me.dgBankHolidays.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMTimeSlotRates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub
#End Region

#Region " Functions "

    Private Sub Populate()

        RatesDataview = DB.TimeSlotRates.GetAll
        BankHolidayDataview = DB.TimeSlotRates.BankHolidays_GetAll
    End Sub

    Private Sub Save()

        For Each dr As DataRow In RatesDataview.Table.Rows
            DB.TimeSlotRates.Update(dr("UniqueID"), _
                                    dr("Monday"), _
                                    dr("Tuesday"), _
                                    dr("Wednesday"), _
                                    dr("Thursday"), _
                                    dr("Friday"), _
                                    dr("Saturday"), _
                                    dr("Sunday"))
        Next dr

        For Each bankHoliday As DataRow In BankHolidayDataview.Table.Rows
            If Entity.Sys.Helper.MakeIntegerValid(bankHoliday("LabourRateID")) = 0 Then
                bankHoliday("LabourRateID") = Entity.Sys.Enums.LabourTypes.Double
            End If

            If Entity.Sys.Helper.MakeIntegerValid(bankHoliday("bankHolidayID")) = 0 Then
                DB.TimeSlotRates.BankHolidays_Insert(bankHoliday("bankHolidayDate"), bankHoliday("LabourRateID"))
            Else
                DB.TimeSlotRates.BankHolidays_Update(bankHoliday("bankHolidayDate"), bankHoliday("LabourRateID"), bankHoliday("bankHolidayID"))
            End If
        Next
        Populate()
    End Sub

#End Region

End Class
