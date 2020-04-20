Public Class FRMOrderCharges : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Combo.SetUpCombo(Me.cboChargeType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.OrderChargeTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
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
    Friend WithEvents grpCharges As System.Windows.Forms.GroupBox
    Friend WithEvents dgCharges As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboChargeType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpCharges = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboChargeType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgCharges = New System.Windows.Forms.DataGrid
        Me.grpCharges.SuspendLayout()
        CType(Me.dgCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpCharges
        '
        Me.grpCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCharges.Controls.Add(Me.btnDelete)
        Me.grpCharges.Controls.Add(Me.btnSave)
        Me.grpCharges.Controls.Add(Me.txtAmount)
        Me.grpCharges.Controls.Add(Me.Label2)
        Me.grpCharges.Controls.Add(Me.cboChargeType)
        Me.grpCharges.Controls.Add(Me.Label1)
        Me.grpCharges.Controls.Add(Me.dgCharges)
        Me.grpCharges.Location = New System.Drawing.Point(8, 40)
        Me.grpCharges.Name = "grpCharges"
        Me.grpCharges.Size = New System.Drawing.Size(552, 272)
        Me.grpCharges.TabIndex = 2
        Me.grpCharges.TabStop = False
        Me.grpCharges.Text = "Charges"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(480, 208)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Remove"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(480, 240)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Add"
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.Location = New System.Drawing.Point(400, 240)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(72, 21)
        Me.txtAmount.TabIndex = 3
        Me.txtAmount.Text = ""
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(336, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Amount:"
        '
        'cboChargeType
        '
        Me.cboChargeType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboChargeType.Location = New System.Drawing.Point(96, 240)
        Me.cboChargeType.Name = "cboChargeType"
        Me.cboChargeType.Size = New System.Drawing.Size(232, 21)
        Me.cboChargeType.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(8, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Charge Type:"
        '
        'dgCharges
        '
        Me.dgCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCharges.DataMember = ""
        Me.dgCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCharges.Location = New System.Drawing.Point(8, 25)
        Me.dgCharges.Name = "dgCharges"
        Me.dgCharges.Size = New System.Drawing.Size(536, 175)
        Me.dgCharges.TabIndex = 1
        '
        'FRMOrderCharges
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(568, 318)
        Me.Controls.Add(Me.grpCharges)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(576, 352)
        Me.Name = "FRMOrderCharges"
        Me.Text = "Order Charges"
        Me.Controls.SetChildIndex(Me.grpCharges, 0)
        Me.grpCharges.ResumeLayout(False)
        CType(Me.dgCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        OrderID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        LoadForm(sender, e, Me)
        SetupChargesDatagrid()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        OrderID = newID
    End Sub

#End Region

#Region "Properties"

    Private _OrderID As Integer
    Public Property OrderID() As Integer
        Get
            Return _OrderID
        End Get
        Set(ByVal Value As Integer)
            _OrderID = Value

            RefreshDatagrid()
        End Set
    End Property

    Private _PageState As Entity.Sys.Enums.FormState = Entity.Sys.Enums.FormState.Insert
    Public Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _PageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _PageState = Value

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    Me.btnSave.Text = "Add"
                Case Entity.Sys.Enums.FormState.Update
                    Me.btnSave.Text = "Update"
            End Select

            Me.txtAmount.Text = ""
            Combo.SetSelectedComboItem_By_Value(Me.cboChargeType, 0)
        End Set
    End Property

    Private _ChargesDataView As DataView = Nothing
    Public Property ChargesDataView() As DataView
        Get
            Return _ChargesDataView
        End Get
        Set(ByVal Value As DataView)
            _ChargesDataView = Value
            _ChargesDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString
            _ChargesDataView.AllowNew = False
            _ChargesDataView.AllowEdit = False
            _ChargesDataView.AllowDelete = False
            Me.dgCharges.DataSource = ChargesDataView
        End Set
    End Property

    Private ReadOnly Property SelectedChargeDataRow() As DataRow
        Get
            If Not Me.dgCharges.CurrentRowIndex = -1 Then
                Return ChargesDataView(Me.dgCharges.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupChargesDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgCharges)
        Dim tStyle As DataGridTableStyle = Me.dgCharges.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim ChargeType As New DataGridLabelColumn
        ChargeType.Format = ""
        ChargeType.FormatInfo = Nothing
        ChargeType.HeaderText = "ChargeType"
        ChargeType.MappingName = "ChargeType"
        ChargeType.ReadOnly = True
        ChargeType.Width = 130
        ChargeType.NullText = "N/A"
        tStyle.GridColumnStyles.Add(ChargeType)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = "C"
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 130
        Amount.NullText = "N/A"
        tStyle.GridColumnStyles.Add(Amount)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString
        Me.dgCharges.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMOrderCharges_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub dgCharges_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCharges.Click, dgCharges.CurrentCellChanged
        If Me.SelectedChargeDataRow Is Nothing Then
            PageState = Entity.Sys.Enums.FormState.Insert
            Exit Sub
        End If

        PageState = Entity.Sys.Enums.FormState.Update
        Me.txtAmount.Text = SelectedChargeDataRow.Item("Amount")
        Combo.SetSelectedComboItem_By_Value(Me.cboChargeType, SelectedChargeDataRow.Item("OrderChargeTypeID"))
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oOrderCharge As New Entity.OrderCharges.OrderCharge
            oOrderCharge.IgnoreExceptionsOnSetMethods = True
            oOrderCharge.SetAmount = Me.txtAmount.Text.Trim
            oOrderCharge.SetOrderChargeTypeID = Combo.GetSelectedItemValue(Me.cboChargeType)
            oOrdercharge.SetOrderID = OrderID

            Dim oValidator As New Entity.OrderCharges.OrderChargeValidator
            oValidator.Validate(oOrderCharge)

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    DB.OrderCharge.Insert(oOrderCharge)
                Case Entity.Sys.Enums.FormState.Update
                    oOrderCharge.SetOrderChargeID = Me.SelectedChargeDataRow.Item("OrderChargeID")
                    DB.OrderCharge.Update(oOrderCharge)
            End Select

            RefreshDatagrid()

        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If SelectedChargeDataRow Is Nothing Then
            ShowMessage("Please select a charge to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            PageState = Entity.Sys.Enums.FormState.Insert
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to remove this charge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        DB.OrderCharge.Delete(SelectedChargeDataRow.Item("OrderChargeID"))

        RefreshDatagrid()
    End Sub

#End Region

#Region "Functions"

    Public Sub RefreshDatagrid()
        ChargesDataView = DB.OrderCharge.OrderCharge_GetForOrder(OrderID)
        PageState = Entity.Sys.Enums.FormState.Insert
    End Sub

#End Region

End Class
