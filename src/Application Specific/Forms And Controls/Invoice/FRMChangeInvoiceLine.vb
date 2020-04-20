Public Class FRMChangeInvoiceLine : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Combo.SetUpCombo(Me.cboInvoiceTaxCodeNew, DB.VATRatesSQL.VATRates_GetAll_InputOrOutput("O").Table, "VATRateID", "Friendly", Entity.Sys.Enums.ComboValues.Please_Select)
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

    Friend WithEvents lblAmount As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents lblVatRate As Label
    Friend WithEvents cboInvoiceTaxCodeNew As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.lblVatRate = New System.Windows.Forms.Label()
        Me.cboInvoiceTaxCodeNew = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Location = New System.Drawing.Point(12, 66)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(51, 13)
        Me.lblAmount.TabIndex = 1
        Me.lblAmount.Text = "Amount"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(89, 63)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(192, 21)
        Me.txtAmount.TabIndex = 2
        '
        'lblVatRate
        '
        Me.lblVatRate.AutoSize = True
        Me.lblVatRate.Location = New System.Drawing.Point(12, 108)
        Me.lblVatRate.Name = "lblVatRate"
        Me.lblVatRate.Size = New System.Drawing.Size(55, 13)
        Me.lblVatRate.TabIndex = 3
        Me.lblVatRate.Text = "Vat Rate"
        '
        'cboInvoiceTaxCodeNew
        '
        Me.cboInvoiceTaxCodeNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInvoiceTaxCodeNew.Location = New System.Drawing.Point(89, 105)
        Me.cboInvoiceTaxCodeNew.Name = "cboInvoiceTaxCodeNew"
        Me.cboInvoiceTaxCodeNew.Size = New System.Drawing.Size(83, 21)
        Me.cboInvoiceTaxCodeNew.TabIndex = 108
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(206, 145)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 109
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(15, 145)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 110
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FRMChangeInvoiceLine
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(304, 180)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cboInvoiceTaxCodeNew)
        Me.Controls.Add(Me.lblVatRate)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.lblAmount)
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.Name = "FRMChangeInvoiceLine"
        Me.Text = "Update"
        Me.Controls.SetChildIndex(Me.lblAmount, 0)
        Me.Controls.SetChildIndex(Me.txtAmount, 0)
        Me.Controls.SetChildIndex(Me.lblVatRate, 0)
        Me.Controls.SetChildIndex(Me.cboInvoiceTaxCodeNew, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region



#Region " Events "

    Private Sub FRMChangeInvoiceLine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
        txtAmount.Text = Entity.Sys.Helper.MakeDoubleValid(GetParameter(0))
        Combo.SetSelectedComboItem_By_Value(cboInvoiceTaxCodeNew, Entity.Sys.Helper.MakeIntegerValid(GetParameter(1)))
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

#End Region

End Class