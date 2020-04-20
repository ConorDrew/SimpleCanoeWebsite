Public Class FRMPickDespatchDetails : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents radPartsDespatched As System.Windows.Forms.RadioButton
    Friend WithEvents cboEngineer As System.Windows.Forms.ComboBox
    Friend WithEvents radReadyToSchedule As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblHeading = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.radPartsDespatched = New System.Windows.Forms.RadioButton
        Me.cboEngineer = New System.Windows.Forms.ComboBox
        Me.radReadyToSchedule = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'lblHeading
        '
        Me.lblHeading.Location = New System.Drawing.Point(8, 40)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(410, 36)
        Me.lblHeading.TabIndex = 2
        Me.lblHeading.Text = "This order related to the visit '{0}' is waiting for parts. Please select the sta" & _
            "tus and engineer you would be despatching the parts to:"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(343, 145)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(11, 145)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(101, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Do Not Update"
        '
        'radPartsDespatched
        '
        Me.radPartsDespatched.AutoSize = True
        Me.radPartsDespatched.Location = New System.Drawing.Point(11, 79)
        Me.radPartsDespatched.Name = "radPartsDespatched"
        Me.radPartsDespatched.Size = New System.Drawing.Size(119, 17)
        Me.radPartsDespatched.TabIndex = 0
        Me.radPartsDespatched.Text = "Parts Depatched"
        Me.radPartsDespatched.UseVisualStyleBackColor = True
        '
        'cboEngineer
        '
        Me.cboEngineer.FormattingEnabled = True
        Me.cboEngineer.Location = New System.Drawing.Point(154, 78)
        Me.cboEngineer.Name = "cboEngineer"
        Me.cboEngineer.Size = New System.Drawing.Size(264, 21)
        Me.cboEngineer.TabIndex = 1
        '
        'radReadyToSchedule
        '
        Me.radReadyToSchedule.AutoSize = True
        Me.radReadyToSchedule.Checked = True
        Me.radReadyToSchedule.Location = New System.Drawing.Point(11, 112)
        Me.radReadyToSchedule.Name = "radReadyToSchedule"
        Me.radReadyToSchedule.Size = New System.Drawing.Size(135, 17)
        Me.radReadyToSchedule.TabIndex = 2
        Me.radReadyToSchedule.TabStop = True
        Me.radReadyToSchedule.Text = "Ready To Schedule"
        Me.radReadyToSchedule.UseVisualStyleBackColor = True
        '
        'FRMPickDespatchDetails
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(422, 174)
        Me.ControlBox = False
        Me.Controls.Add(Me.radReadyToSchedule)
        Me.Controls.Add(Me.cboEngineer)
        Me.Controls.Add(Me.radPartsDespatched)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblHeading)
        Me.MaximumSize = New System.Drawing.Size(438, 212)
        Me.MinimumSize = New System.Drawing.Size(438, 212)
        Me.Name = "FRMPickDespatchDetails"
        Me.Text = "Update Visit"
        Me.Controls.SetChildIndex(Me.lblHeading, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.radPartsDespatched, 0)
        Me.Controls.SetChildIndex(Me.cboEngineer, 0)
        Me.Controls.SetChildIndex(Me.radReadyToSchedule, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        Combo.SetUpCombo(Me.cboEngineer, DB.Engineer.Engineer_GetAll.Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetSelectedComboItem_By_Value(Me.cboEngineer, 0)
        Me.cboEngineer.Enabled = False

        EngVisit = GetParameter(0)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe

    End Sub

#End Region

#Region "Properties"

    Private _EngVisit As Entity.EngineerVisits.EngineerVisit
    Public Property EngVisit() As Entity.EngineerVisits.EngineerVisit
        Get
            Return _EngVisit
        End Get
        Set(ByVal Value As Entity.EngineerVisits.EngineerVisit)
            _EngVisit = Value

            Me.lblHeading.Text = String.Format(Me.lblHeading.Text, DB.Job.Job_Get_For_An_EngineerVisit_ID(EngVisit.EngineerVisitID).JobNumber)
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMPickDespatchDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub radPartsDespatched_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radPartsDespatched.CheckedChanged
        If Me.radPartsDespatched.Checked Then
            Me.cboEngineer.Enabled = True
        Else
            Combo.SetSelectedComboItem_By_Value(Me.cboEngineer, 0)
            Me.cboEngineer.Enabled = False
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If EngVisit.StatusEnumID >= CInt(Entity.Sys.Enums.VisitStatus.Scheduled) Then
            ShowMessage("This visit has already been scheduled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not Me.radPartsDespatched.Checked And Not Me.radReadyToSchedule.Checked Then
            ShowMessage("Status not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Me.radPartsDespatched.Checked And Combo.GetSelectedItemValue(Me.cboEngineer) = 0 Then
            ShowMessage("Engineer not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        EngVisit.SetPartsToFit = True

        If Me.radPartsDespatched.Checked Then
            EngVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Parts_Despatched)
            EngVisit.SetExpectedEngineerID = Combo.GetSelectedItemValue(Me.cboEngineer)
        ElseIf Me.radReadyToSchedule.Checked Then
            EngVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
        End If

        DB.EngineerVisits.Update(EngVisit, 0, True)

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

#End Region

End Class
