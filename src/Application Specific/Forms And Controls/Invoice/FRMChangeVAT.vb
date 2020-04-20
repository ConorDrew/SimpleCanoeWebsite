Public Class FRMChangeVAT
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal CurrentRateID As Integer, ByVal InvoicedIDin As Integer, ByVal InvNumber As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SetupRatesDataGrid()
        GroupBox1.Text = String.Format(GroupBox1.Text, InvNumber)

        InvoicedID = InvoicedIDin
        Populate(CurrentRateID)
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

    Friend WithEvents btnSetRate As System.Windows.Forms.Button
    Friend WithEvents dgRates As System.Windows.Forms.DataGrid

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgRates = New System.Windows.Forms.DataGrid
        Me.btnSetRate = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgRates)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 224)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select A VAT Rate for {0}"
        '
        'dgRates
        '
        Me.dgRates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRates.DataMember = ""
        Me.dgRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgRates.Location = New System.Drawing.Point(8, 16)
        Me.dgRates.Name = "dgRates"
        Me.dgRates.Size = New System.Drawing.Size(256, 192)
        Me.dgRates.TabIndex = 0
        '
        'btnSetRate
        '
        Me.btnSetRate.UseVisualStyleBackColor = True
        Me.btnSetRate.Location = New System.Drawing.Point(112, 240)
        Me.btnSetRate.Name = "btnSetRate"
        Me.btnSetRate.TabIndex = 1
        Me.btnSetRate.Text = "Set Rate"
        '
        'FRMChangeVAT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(288, 266)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSetRate)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximumSize = New System.Drawing.Size(294, 298)
        Me.MinimumSize = New System.Drawing.Size(294, 298)
        Me.Name = "FRMChangeVAT"
        Me.Text = "Change VAT Rate"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

    Private _InvoicedID As Integer

    Private Property InvoicedID() As Integer
        Get
            Return _InvoicedID
        End Get
        Set(ByVal Value As Integer)
            _InvoicedID = Value
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
            _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblVATRates.ToString
            Me.dgRates.DataSource = RatesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedVATRateDataRow() As DataRow
        Get
            If Not Me.dgRates.CurrentRowIndex = -1 Then
                Return RatesDataview(Me.dgRates.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub btnSetRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetRate.Click
        Dim inv As Entity.Invoiceds.Invoiced = DB.Invoiced.Invoiced_Get(InvoicedID)
        inv.SetVATRateID = SelectedVATRateDataRow("VatRateID")
        DB.Invoiced.Update(inv)
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupRatesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgRates)
        Dim tbStyle As DataGridTableStyle = Me.dgRates.TableStyles(0)

        Dim VATRate As New DataGridLabelColumn
        VATRate.Format = ""
        VATRate.FormatInfo = Nothing
        VATRate.HeaderText = "VAT Rate"
        VATRate.MappingName = "VATRate"
        VATRate.ReadOnly = True
        VATRate.Width = 150
        VATRate.NullText = ""
        tbStyle.GridColumnStyles.Add(VATRate)

        Dim DateIntroduced As New DataGridLabelColumn
        DateIntroduced.Format = "dd/MM/yyyy"
        DateIntroduced.FormatInfo = Nothing
        DateIntroduced.HeaderText = "Date Introduced"
        DateIntroduced.MappingName = "DateIntroduced"
        DateIntroduced.ReadOnly = True
        DateIntroduced.Width = 150
        DateIntroduced.NullText = ""
        tbStyle.GridColumnStyles.Add(DateIntroduced)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblVATRates.ToString
        Me.dgRates.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(ByVal CurrentRateID As Integer)
        RatesDataview = DB.VATRatesSQL.VATRates_GetAll

        Dim i As Integer = 0
        For Each r As DataRow In RatesDataview.Table.Rows
            If r("VATRateID") = CurrentRateID Then
                dgRates.CurrentRowIndex = i
                dgRates.Select(i)
            End If
            i += 1
        Next r

    End Sub

#End Region

End Class