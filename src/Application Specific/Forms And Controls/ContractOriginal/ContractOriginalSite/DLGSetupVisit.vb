Public Class DLGSetupVisit : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "



    Public Sub New()

        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Combo.SetUpCombo(Me.cboFrequency, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboType, DynamicDataTables.ContractVisitType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPreferredEngineer, DB.Engineer.Engineer_GetAll.Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        Combo.SetUpCombo(Me.cboSubContractor, DB.SubContractor.Subcontractor_GetAll.Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)

        '   Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

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
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpTargetDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFrequency As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPreferredEngineer As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSubContractor As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAdditional As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTargetDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFrequency = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboPreferredEngineer = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSubContractor = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAdditional = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 451)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 24)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Target Date"
        '
        'dtpTargetDate
        '
        Me.dtpTargetDate.Location = New System.Drawing.Point(122, 140)
        Me.dtpTargetDate.Name = "dtpTargetDate"
        Me.dtpTargetDate.Size = New System.Drawing.Size(298, 21)
        Me.dtpTargetDate.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Visit Type"
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(122, 73)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(298, 21)
        Me.cboType.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(364, 454)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(56, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Frequency"
        '
        'cboFrequency
        '
        Me.cboFrequency.FormattingEnabled = True
        Me.cboFrequency.Location = New System.Drawing.Point(122, 106)
        Me.cboFrequency.Name = "cboFrequency"
        Me.cboFrequency.Size = New System.Drawing.Size(298, 21)
        Me.cboFrequency.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 18)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Prefered Engineer"
        '
        'cboPreferredEngineer
        '
        Me.cboPreferredEngineer.FormattingEnabled = True
        Me.cboPreferredEngineer.Location = New System.Drawing.Point(122, 173)
        Me.cboPreferredEngineer.Name = "cboPreferredEngineer"
        Me.cboPreferredEngineer.Size = New System.Drawing.Size(298, 21)
        Me.cboPreferredEngineer.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(10, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 15)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Sub Contractor"
        '
        'cboSubContractor
        '
        Me.cboSubContractor.FormattingEnabled = True
        Me.cboSubContractor.Location = New System.Drawing.Point(122, 211)
        Me.cboSubContractor.Name = "cboSubContractor"
        Me.cboSubContractor.Size = New System.Drawing.Size(298, 21)
        Me.cboSubContractor.TabIndex = 6
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(13, 369)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(133, 17)
        Me.CheckBox1.TabIndex = 19
        Me.CheckBox1.Text = "System Generated"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 283)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Expected Cost"
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(122, 281)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(298, 21)
        Me.txtFilter.TabIndex = 25
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(122, 246)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(298, 21)
        Me.TextBox1.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 24)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Hours Required"
        '
        'txtAdditional
        '
        Me.txtAdditional.Location = New System.Drawing.Point(122, 314)
        Me.txtAdditional.Multiline = True
        Me.txtAdditional.Name = "txtAdditional"
        Me.txtAdditional.Size = New System.Drawing.Size(298, 125)
        Me.txtAdditional.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 316)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 24)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Additional Notes"
        '
        'DLGSetupVisit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(432, 481)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtAdditional)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboSubContractor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboPreferredEngineer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboFrequency)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpTargetDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(350, 392)
        Me.Name = "DLGSetupVisit"
        Me.Text = "Find {0}"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtFilter, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.cboType, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpTargetDate, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cboFrequency, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cboPreferredEngineer, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboSubContractor, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtAdditional, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Me.ActiveControl = Me.txtFilter
        Me.txtFilter.Focus()
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

    Private _ID As Integer = 0
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property

    Private _2ndID As String = 0
    Public Property SecondID() As String
        Get
            Return _2ndID
        End Get
        Set(ByVal Value As String)
            _2ndID = Value
        End Set
    End Property


    Private _FrequencyID As String = 0
    Public Property FrequencyID() As String
        Get
            Return _FrequencyID
        End Get
        Set(ByVal Value As String)
            _FrequencyID = Value
        End Set
    End Property


    Private _EffDate As Date = Date.MinValue
    Public Property EffDate() As Date
        Get
            Return _EffDate
        End Get
        Set(ByVal Value As Date)
            _EffDate = Value
        End Set
    End Property



#End Region



#Region "Events"


    Private Sub cboFrequency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFrequency.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboFrequency) = 7 Then
            CheckBox1.Enabled = True
            dtpTargetDate.Enabled = True
        Else
            CheckBox1.Checked = True
            CheckBox1.Enabled = False
            dtpTargetDate.Enabled = False
        End If
    End Sub

    Private Sub DLGFindRecord_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

   

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

   
    

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If Combo.GetSelectedItemValue(cboType) = "0" Then
            ShowMessage("No type selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        Else
            If CInt(Combo.GetSelectedItemValue(cboFrequency)) = 0 Then
                ShowMessage("No Frequency selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            If Not IsNumeric(txtFilter.Text) Then
                ShowMessage("Please only input numbers into the cost box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            If Not IsNumeric(TextBox1.Text) OrElse CInt(TextBox1.Text) = 0 Then
                ShowMessage("Please enter a valid number into the Hours Required box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If


            Me.DialogResult = DialogResult.OK
        End If
    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then

            dtpTargetDate.Enabled = False

        Else
            dtpTargetDate.Enabled = True

        End If
    End Sub
 

#End Region

#Region "Functions"



#End Region

  
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
