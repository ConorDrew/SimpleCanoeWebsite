Public Class FRMViewContractAlternativeChargeDetails : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMileageCostPerVisit As System.Windows.Forms.TextBox
    Friend WithEvents txtAverageMileage As System.Windows.Forms.TextBox
    Friend WithEvents txtCostPerMile As System.Windows.Forms.TextBox
    Friend WithEvents chkIncludeMileage As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRatesTotal As System.Windows.Forms.TextBox
    Friend WithEvents chkRates As System.Windows.Forms.CheckBox
    Friend WithEvents dgScheduleOfRates As System.Windows.Forms.DataGrid
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgScheduleOfRates = New System.Windows.Forms.DataGrid
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMileageCostPerVisit = New System.Windows.Forms.TextBox
        Me.txtAverageMileage = New System.Windows.Forms.TextBox
        Me.txtCostPerMile = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtRatesTotal = New System.Windows.Forms.TextBox
        Me.chkRates = New System.Windows.Forms.CheckBox
        Me.chkIncludeMileage = New System.Windows.Forms.CheckBox
        Me.btnDone = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgScheduleOfRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dgScheduleOfRates)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMileageCostPerVisit)
        Me.GroupBox1.Controls.Add(Me.txtAverageMileage)
        Me.GroupBox1.Controls.Add(Me.txtCostPerMile)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtRatesTotal)
        Me.GroupBox1.Controls.Add(Me.chkRates)
        Me.GroupBox1.Controls.Add(Me.chkIncludeMileage)

        Me.GroupBox1.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(688, 240)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Charge Information"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 24)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Schedule Of Rates"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgScheduleOfRates
        '
        Me.dgScheduleOfRates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgScheduleOfRates.DataMember = ""
        Me.dgScheduleOfRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgScheduleOfRates.Location = New System.Drawing.Point(8, 44)
        Me.dgScheduleOfRates.Name = "dgScheduleOfRates"
        Me.dgScheduleOfRates.Size = New System.Drawing.Size(672, 113)
        Me.dgScheduleOfRates.TabIndex = 79
        '
        'Label5
        '
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(112, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 23)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Mileage Per Visit"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(296, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 23)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Price Per Mile"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(464, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 23)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "= Mileage Price Per Visit"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMileageCostPerVisit
        '
        Me.txtMileageCostPerVisit.Enabled = False
        Me.txtMileageCostPerVisit.Location = New System.Drawing.Point(608, 208)
        Me.txtMileageCostPerVisit.Name = "txtMileageCostPerVisit"
        Me.txtMileageCostPerVisit.Size = New System.Drawing.Size(72, 21)
        Me.txtMileageCostPerVisit.TabIndex = 74
        '
        'txtAverageMileage
        '
        Me.txtAverageMileage.Enabled = False
        Me.txtAverageMileage.Location = New System.Drawing.Point(232, 208)
        Me.txtAverageMileage.Name = "txtAverageMileage"
        Me.txtAverageMileage.Size = New System.Drawing.Size(58, 21)
        Me.txtAverageMileage.TabIndex = 73
        Me.txtAverageMileage.Text = "0"
        '
        'txtCostPerMile
        '
        Me.txtCostPerMile.Enabled = False
        Me.txtCostPerMile.Location = New System.Drawing.Point(400, 208)
        Me.txtCostPerMile.Name = "txtCostPerMile"
        Me.txtCostPerMile.Size = New System.Drawing.Size(58, 21)
        Me.txtCostPerMile.TabIndex = 72
        Me.txtCostPerMile.Text = "£0.00"
        '
        'Label8
        '
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(520, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 24)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Rate Total:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRatesTotal
        '
        Me.txtRatesTotal.Enabled = False
        Me.txtRatesTotal.Location = New System.Drawing.Point(608, 162)
        Me.txtRatesTotal.MaxLength = 50
        Me.txtRatesTotal.Name = "txtRatesTotal"
        Me.txtRatesTotal.Size = New System.Drawing.Size(72, 21)
        Me.txtRatesTotal.TabIndex = 70
        Me.txtRatesTotal.Tag = "SystemScheduleOfRate.Code"
        '
        'chkRates
        '
        Me.chkRates.Enabled = False
        Me.chkRates.Location = New System.Drawing.Point(8, 158)
        Me.chkRates.Name = "chkRates"
        Me.chkRates.Size = New System.Drawing.Size(176, 25)
        Me.chkRates.TabIndex = 69
        Me.chkRates.Text = "Include Rates in Visit Total"
        '
        'chkIncludeMileage
        '
        Me.chkIncludeMileage.Enabled = False
        Me.chkIncludeMileage.Location = New System.Drawing.Point(8, 184)
        Me.chkIncludeMileage.Name = "chkIncludeMileage"
        Me.chkIncludeMileage.Size = New System.Drawing.Size(192, 23)
        Me.chkIncludeMileage.TabIndex = 75
        Me.chkIncludeMileage.Text = "Include Mileage in Visit Total"
        '
        'btnDone
        '
        Me.btnDone.UseVisualStyleBackColor = True
        Me.btnDone.Location = New System.Drawing.Point(600, 288)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(90, 25)
        Me.btnDone.TabIndex = 1
        Me.btnDone.Text = "Done"
        '
        'FRMViewContractAlternativeChargeDetails
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(704, 318)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDone)
        Me.Name = "FRMViewContractAlternativeChargeDetails"
        Me.Text = "Job Item Charges"
        Me.Controls.SetChildIndex(Me.btnDone, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgScheduleOfRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupScheduleOfRatesDataGrid()
        ScheduleOfRatesDataview = DB.ContractAlternativeSiteJobOfWork.GetJobOfWorkScheduleOfRates(Entity.Sys.Helper.MakeIntegerValid(GetParameter(0)))
        Me.chkIncludeMileage.Checked = GetParameter(1)
        Me.chkRates.Checked = GetParameter(2)
        Me.txtAverageMileage.Text = GetParameter(3)
        Me.txtCostPerMile.Text = Format(Entity.Sys.Helper.MakeDoubleValid(GetParameter(4)), "C")
        CalculateRates()

        CalculateMileageTotal()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get

        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe

    End Sub

#End Region

#Region "Properties"

    Private _ScheduleOfRatesDataview As DataView

    Private Property ScheduleOfRatesDataview() As DataView
        Get
            Return _ScheduleOfRatesDataview
        End Get
        Set(ByVal Value As DataView)
            _ScheduleOfRatesDataview = Value

            _ScheduleOfRatesDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
            _ScheduleOfRatesDataview.AllowNew = False
            _ScheduleOfRatesDataview.AllowEdit = True
            _ScheduleOfRatesDataview.AllowDelete = False
            Me.dgScheduleOfRates.DataSource = ScheduleOfRatesDataview
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub SetupScheduleOfRatesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgScheduleOfRates)
        Dim tStyle As DataGridTableStyle = Me.dgScheduleOfRates.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 150
        Category.NullText = ""
        tStyle.GridColumnStyles.Add(Category)

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Code"
        Code.MappingName = "Code"
        Code.ReadOnly = True
        Code.Width = 75
        Code.NullText = ""
        tStyle.GridColumnStyles.Add(Code)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 250
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = False
        Price.Width = 75
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim QtyPerVisit As New DataGridLabelColumn
        QtyPerVisit.Format = ""
        QtyPerVisit.FormatInfo = Nothing
        QtyPerVisit.HeaderText = "Qty Per Visit"
        QtyPerVisit.MappingName = "QtyPerVisit"
        QtyPerVisit.ReadOnly = False
        QtyPerVisit.Width = 85
        QtyPerVisit.NullText = ""
        tStyle.GridColumnStyles.Add(QtyPerVisit)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
        Me.dgScheduleOfRates.TableStyles.Add(tStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub FRMViewContractAlternativeChargeDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub CalculateRates()

        Dim runningTotal As Decimal = 0.0
        For Each rate As DataRow In ScheduleOfRatesDataview.Table.Rows
            runningTotal += rate.Item("Price") * rate.Item("QtyPerVisit")
        Next

        Me.txtRatesTotal.Text = Format(runningTotal, "C")

    End Sub

    Private Sub CalculateMileageTotal()

        Me.txtMileageCostPerVisit.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Me.txtAverageMileage.Text) _
                                    * Entity.Sys.Helper.MakeDoubleValid(Me.txtCostPerMile.Text.Replace("£", "")), "C")

    End Sub

#End Region

End Class