Public Class DLGEngineerVisitDefect : Inherits FSM.FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
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
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboAsset As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtActionTaken As System.Windows.Forms.TextBox
    Friend WithEvents chkWarningNoticeIssued As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisconnected As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtActionTaken = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkDisconnected = New System.Windows.Forms.CheckBox
        Me.chkWarningNoticeIssued = New System.Windows.Forms.CheckBox
        Me.cboAsset = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Location = New System.Drawing.Point(448, 384)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Location = New System.Drawing.Point(8, 384)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtActionTaken)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtComments)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtReason)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkDisconnected)
        Me.GroupBox1.Controls.Add(Me.chkWarningNoticeIssued)
        Me.GroupBox1.Controls.Add(Me.cboAsset)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboCategory)
        Me.GroupBox1.Controls.Add(Me.Label1)

        Me.GroupBox1.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(512, 336)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Defect Details"
        '
        'txtActionTaken
        '
        Me.txtActionTaken.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtActionTaken.Location = New System.Drawing.Point(120, 226)
        Me.txtActionTaken.Multiline = True
        Me.txtActionTaken.Name = "txtActionTaken"
        Me.txtActionTaken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtActionTaken.Size = New System.Drawing.Size(384, 48)
        Me.txtActionTaken.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Action Taken"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(120, 282)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComments.Size = New System.Drawing.Size(384, 46)
        Me.txtComments.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Comments"
        '
        'txtReason
        '
        Me.txtReason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReason.Location = New System.Drawing.Point(120, 170)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReason.Size = New System.Drawing.Size(384, 48)
        Me.txtReason.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Reason"
        '
        'chkDisconnected
        '
        Me.chkDisconnected.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDisconnected.Location = New System.Drawing.Point(16, 136)
        Me.chkDisconnected.Name = "chkDisconnected"
        Me.chkDisconnected.Size = New System.Drawing.Size(120, 24)
        Me.chkDisconnected.TabIndex = 5
        Me.chkDisconnected.Text = "Disconnected"
        '
        'chkWarningNoticeIssued
        '
        Me.chkWarningNoticeIssued.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWarningNoticeIssued.Location = New System.Drawing.Point(16, 88)
        Me.chkWarningNoticeIssued.Name = "chkWarningNoticeIssued"
        Me.chkWarningNoticeIssued.Size = New System.Drawing.Size(120, 40)
        Me.chkWarningNoticeIssued.TabIndex = 4
        Me.chkWarningNoticeIssued.Text = "Warning Notice Issued"
        '
        'cboAsset
        '
        Me.cboAsset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAsset.Location = New System.Drawing.Point(120, 27)
        Me.cboAsset.Name = "cboAsset"
        Me.cboAsset.Size = New System.Drawing.Size(384, 21)
        Me.cboAsset.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Appliance"
        '
        'cboCategory
        '
        Me.cboCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Location = New System.Drawing.Point(120, 59)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(384, 21)
        Me.cboCategory.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Category"
        '
        'DLGEngineerVisitDefect
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(528, 414)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.MinimumSize = New System.Drawing.Size(536, 448)
        Me.Name = "DLGEngineerVisitDefect"
        Me.Text = "Engineer Visit Defect"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

    Private _updating As Boolean = True
    Public Property Updating() As Boolean
        Get
            Return _updating
        End Get
        Set(ByVal Value As Boolean)
            _updating = Value
        End Set
    End Property

    Private _Defect As Entity.EngineerVisitDefectss.EngineerVisitDefects
    Public Property Defect() As Entity.EngineerVisitDefectss.EngineerVisitDefects
        Get
            Return _Defect
        End Get
        Set(ByVal Value As Entity.EngineerVisitDefectss.EngineerVisitDefects)
            _Defect = Value
        End Set
    End Property

    Private _EngineerVisit As Entity.EngineerVisits.EngineerVisit
    Public Property EngineerVisit() As Entity.EngineerVisits.EngineerVisit
        Get
            Return _EngineerVisit
        End Get
        Set(ByVal Value As Entity.EngineerVisits.EngineerVisit)
            _EngineerVisit = Value
        End Set
    End Property

    Private _jobID As Integer
    Public Property JobID() As Integer
        Get
            Return _jobID
        End Get
        Set(ByVal Value As Integer)
            _jobID = Value
        End Set
    End Property

#End Region

#Region "Functions"

    Private Sub populateDefect()

        Combo.SetSelectedComboItem_By_Value(Me.cboAsset, Defect.AssetID)
        Combo.SetSelectedComboItem_By_Value(Me.cboCategory, Defect.CategoryID)
        Me.chkDisconnected.Checked = Defect.Disconnected
        Me.chkWarningNoticeIssued.Checked = Defect.WarningNoticeIssued
        Me.txtReason.Text = Defect.Reason
        Me.txtActionTaken.Text = Defect.ActionTaken
        Me.txtComments.Text = Defect.Comments

    End Sub

#End Region

#Region "Events"

    Private Sub DLGEngineerVisitDefect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If loggedInUser.Admin = False Then
            btnSave.Enabled = False
            cboAsset.Enabled = False
            cboCategory.Enabled = False
            chkDisconnected.Enabled = False
            chkWarningNoticeIssued.Enabled = False
            txtActionTaken.ReadOnly = True
            txtComments.ReadOnly = True
            txtReason.ReadOnly = True
        End If

        Combo.SetUpCombo(Me.cboCategory, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.DefectCategorys).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAsset, DB.JobAsset.JobAsset_Get_For_Job(JobID).Table, "AssetID", "AssetDescriptionWithLocation", Entity.Sys.Enums.ComboValues.Not_Applicable)
        If Defect.Exists = True And Updating = True Then
            populateDefect()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Defect.SetAssetID = Combo.GetSelectedItemValue(Me.cboAsset)
            Defect.SetCategoryID = Combo.GetSelectedItemValue(Me.cboCategory)
            Defect.SetActionTaken = Me.txtActionTaken.Text
            Defect.SetComments = Me.txtComments.Text
            Defect.SetDisconnected = Me.chkDisconnected.Checked
            Defect.SetWarningNoticeIssued = Me.chkWarningNoticeIssued.Checked
            Defect.SetReason = Me.txtReason.Text
            Defect.SetEngineerVisitID = EngineerVisit.EngineerVisitID

            Dim dValidator As New Entity.EngineerVisitDefectss.EngineerVisitDefectsValidator
            dValidator.Validate(Defect)

            If Updating Then
                DB.EngineerVisitDefects.Update(Defect)
            Else
                DB.EngineerVisitDefects.Insert(Defect)
            End If

            Me.DialogResult = DialogResult.OK

        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Error saving details : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

End Class
