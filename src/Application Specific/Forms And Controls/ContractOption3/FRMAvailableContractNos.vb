Public Class FRMAvailableContractNos : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents dgAvailableContractNos As System.Windows.Forms.DataGrid

    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtPostfix As System.Windows.Forms.TextBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lblPrefix As System.Windows.Forms.Label
    Friend WithEvents lblPostfix As System.Windows.Forms.Label
    Friend WithEvents gpbContractNumbers As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FRMAvailableContractNos))
        Me.dgAvailableContractNos = New System.Windows.Forms.DataGrid
        Me.txtPrefix = New System.Windows.Forms.TextBox
        Me.txtPostfix = New System.Windows.Forms.TextBox
        Me.lblPrefix = New System.Windows.Forms.Label
        Me.lblPostfix = New System.Windows.Forms.Label
        Me.gpbContractNumbers = New System.Windows.Forms.GroupBox
        Me.lblResult = New System.Windows.Forms.Label
        Me.btnSelect = New System.Windows.Forms.Button
        CType(Me.dgAvailableContractNos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbContractNumbers.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgAvailableContractNos
        '
        Me.dgAvailableContractNos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAvailableContractNos.DataMember = ""
        Me.dgAvailableContractNos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAvailableContractNos.Location = New System.Drawing.Point(11, 74)
        Me.dgAvailableContractNos.Name = "dgAvailableContractNos"
        Me.dgAvailableContractNos.Size = New System.Drawing.Size(293, 301)
        Me.dgAvailableContractNos.TabIndex = 0
        '
        'txtPrefix
        '
        Me.txtPrefix.Location = New System.Drawing.Point(12, 45)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(120, 21)
        Me.txtPrefix.TabIndex = 1
        Me.txtPrefix.Text = ""
        '
        'txtPostfix
        '
        Me.txtPostfix.Location = New System.Drawing.Point(184, 45)
        Me.txtPostfix.Name = "txtPostfix"
        Me.txtPostfix.Size = New System.Drawing.Size(120, 21)
        Me.txtPostfix.TabIndex = 2
        Me.txtPostfix.Text = ""
        '
        'lblPrefix
        '

        Me.lblPrefix.Location = New System.Drawing.Point(11, 23)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(120, 17)
        Me.lblPrefix.TabIndex = 3
        Me.lblPrefix.Text = "Prefix:"
        '
        'lblPostfix
        '

        Me.lblPostfix.Location = New System.Drawing.Point(180, 23)
        Me.lblPostfix.Name = "lblPostfix"
        Me.lblPostfix.Size = New System.Drawing.Size(120, 17)
        Me.lblPostfix.TabIndex = 4
        Me.lblPostfix.Text = "Postfix"
        '
        'gpbContractNumbers
        '
        Me.gpbContractNumbers.Controls.Add(Me.lblResult)
        Me.gpbContractNumbers.Controls.Add(Me.btnSelect)
        Me.gpbContractNumbers.Controls.Add(Me.lblPrefix)
        Me.gpbContractNumbers.Controls.Add(Me.txtPrefix)
        Me.gpbContractNumbers.Controls.Add(Me.lblPostfix)
        Me.gpbContractNumbers.Controls.Add(Me.txtPostfix)
        Me.gpbContractNumbers.Controls.Add(Me.dgAvailableContractNos)

        Me.gpbContractNumbers.Location = New System.Drawing.Point(11, 39)
        Me.gpbContractNumbers.Name = "gpbContractNumbers"
        Me.gpbContractNumbers.Size = New System.Drawing.Size(319, 414)
        Me.gpbContractNumbers.TabIndex = 5
        Me.gpbContractNumbers.TabStop = False
        Me.gpbContractNumbers.Text = "Contract Numbers"
        '
        'lblResult

        Me.lblResult.Location = New System.Drawing.Point(12, 380)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(197, 25)
        Me.lblResult.TabIndex = 6
        Me.lblResult.Text = "Label3"
        '
        'btnSelect
        '
        Me.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelect.UseVisualStyleBackColor = True
        Me.btnSelect.Location = New System.Drawing.Point(217, 381)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(90, 25)
        Me.btnSelect.TabIndex = 5
        Me.btnSelect.Text = "&Select"
        '
        'FRMAvailableContractNos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(340, 458)
        Me.Controls.Add(Me.gpbContractNumbers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(346, 490)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(346, 490)
        Me.Name = "FRMAvailableContractNos"
        Me.Text = "Available Contract Nos"
        Me.Controls.SetChildIndex(Me.gpbContractNumbers, 0)
        CType(Me.dgAvailableContractNos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbContractNumbers.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        txtRef = GetParameter(0)
        LoadForm(sender, e, Me)
        SetupContractsDataGrid()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe

    End Sub

#End Region

#Region "Properties"

    Public txtRef As TextBox

    Private _dvContracts As DataView

    Private Property ContractsDataview() As DataView
        Get
            Return _dvContracts
        End Get
        Set(ByVal value As DataView)
            _dvContracts = value
            _dvContracts.AllowNew = False
            _dvContracts.AllowEdit = False
            _dvContracts.AllowDelete = False
            _dvContracts.Table.TableName = Entity.Sys.Enums.TableNames.tblContractOption3.ToString
            Me.dgAvailableContractNos.DataSource = ContractsDataview
        End Set
    End Property

#End Region

#Region " Setup "

    Private Sub SetupContractsDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgAvailableContractNos)
        Dim tbStyle As DataGridTableStyle = Me.dgAvailableContractNos.TableStyles(0)

        Dim ContractName As New DataGridLabelColumn
        ContractName.Format = ""
        ContractName.FormatInfo = Nothing
        ContractName.HeaderText = "Reference"
        ContractName.MappingName = "Ref"
        ContractName.ReadOnly = True
        ContractName.Width = 135
        ContractName.NullText = ""
        tbStyle.GridColumnStyles.Add(ContractName)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractOption3.ToString
        Me.dgAvailableContractNos.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Functions"

    Private Sub PopulatePage()
        Try
            ContractsDataview = New DataView(DB.ContractOption3.ContractReference_Get(txtPrefix.Text, txtPostfix.Text))
        Catch ex As Exception
            MsgBox("Available contract numbers cannot be loaded : " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
        PopulateResult()
    End Sub

    Private Sub PopulateResult()
        lblResult.Text = ""
        If txtPrefix.Text.Trim.Length > 0 Then
            lblResult.Text = txtPrefix.Text & "/"
        End If
        lblResult.Text += ContractsDataview(dgAvailableContractNos.CurrentRowIndex)("REF")
        If txtPostfix.Text.Trim.Length > 0 Then
            lblResult.Text += "/" & txtPostfix.Text
        End If

    End Sub

#End Region

#Region "Events Procedures"

    Private Sub FRMAvailableContractNos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
        SetupContractsDataGrid()
        PopulatePage()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lblResult.Text.Trim.Length > 0 Then
            Me.txtRef.Text = lblResult.Text
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub txtPrefix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrefix.TextChanged
        If txtPrefix.Text.Length > 0 Then
            If IsNumeric(txtPrefix.Text.Substring(txtPrefix.Text.Length - 1, 1)) Or
                    txtPrefix.Text.Substring(txtPrefix.Text.Length - 1, 1) = "/" Then
                txtPrefix.Text = txtPrefix.Text.Substring(0, txtPrefix.Text.Length - 1)
            End If
        End If

        PopulatePage()
        Me.txtPrefix.Focus()
    End Sub

    Private Sub txtPostfix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPostfix.TextChanged
        If txtPostfix.Text.Length > 0 Then
            If IsNumeric(txtPostfix.Text.Substring(txtPostfix.Text.Length - 1, 1)) Or
                    txtPostfix.Text.Substring(txtPostfix.Text.Length - 1, 1) = "/" Then
                txtPostfix.Text = txtPostfix.Text.Substring(0, txtPostfix.Text.Length - 1)
            End If
        End If

        PopulatePage()
        Me.txtPostfix.Focus()
    End Sub

    Private Sub dgAvailableContractNos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAvailableContractNos.Click, dgAvailableContractNos.CurrentCellChanged
        PopulateResult()
    End Sub

#End Region

End Class