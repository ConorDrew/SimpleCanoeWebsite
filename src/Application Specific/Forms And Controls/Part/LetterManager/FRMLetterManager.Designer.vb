<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMLetterManager: Inherits FSM.FRMBaseForm : Implements IForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpServices = New System.Windows.Forms.GroupBox()
        Me.dgServicesDue = New System.Windows.Forms.DataGrid()
        Me.btnResetFilters = New System.Windows.Forms.Button()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.tbMinsPerDay = New System.Windows.Forms.TextBox()
        Me.cboLetterNumber = New System.Windows.Forms.ComboBox()
        Me.lbMinsPerDay = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpLetterCreateDate = New System.Windows.Forms.DateTimePicker()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnUnselect = New System.Windows.Forms.Button()
        Me.btnGenerateLetters = New System.Windows.Forms.Button()
        Me.grpServices.SuspendLayout()
        CType(Me.dgServicesDue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpServices
        '
        Me.grpServices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpServices.Controls.Add(Me.dgServicesDue)
        Me.grpServices.Location = New System.Drawing.Point(12, 180)
        Me.grpServices.Name = "grpServices"
        Me.grpServices.Size = New System.Drawing.Size(962, 245)
        Me.grpServices.TabIndex = 3
        Me.grpServices.TabStop = False
        Me.grpServices.Text = "Services Due"
        '
        'dgServicesDue
        '
        Me.dgServicesDue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgServicesDue.DataMember = ""
        Me.dgServicesDue.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgServicesDue.Location = New System.Drawing.Point(8, 20)
        Me.dgServicesDue.Name = "dgServicesDue"
        Me.dgServicesDue.Size = New System.Drawing.Size(946, 217)
        Me.dgServicesDue.TabIndex = 14
        '
        'btnResetFilters
        '
        Me.btnResetFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnResetFilters.Location = New System.Drawing.Point(20, 431)
        Me.btnResetFilters.Name = "btnResetFilters"
        Me.btnResetFilters.Size = New System.Drawing.Size(111, 23)
        Me.btnResetFilters.TabIndex = 4
        Me.btnResetFilters.Text = "Reset Filters"
        Me.btnResetFilters.UseVisualStyleBackColor = True
        '
        'grpFilters
        '
        Me.grpFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilters.Controls.Add(Me.tbMinsPerDay)
        Me.grpFilters.Controls.Add(Me.cboLetterNumber)
        Me.grpFilters.Controls.Add(Me.lbMinsPerDay)
        Me.grpFilters.Controls.Add(Me.Label14)
        Me.grpFilters.Controls.Add(Me.btnFilter)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Controls.Add(Me.dtpLetterCreateDate)
        Me.grpFilters.Controls.Add(Me.txtCustomer)
        Me.grpFilters.Controls.Add(Me.Label4)
        Me.grpFilters.Location = New System.Drawing.Point(12, 38)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(962, 107)
        Me.grpFilters.TabIndex = 5
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Filters"
        '
        'tbMinsPerDay
        '
        Me.tbMinsPerDay.Location = New System.Drawing.Point(142, 76)
        Me.tbMinsPerDay.Name = "tbMinsPerDay"
        Me.tbMinsPerDay.Size = New System.Drawing.Size(53, 21)
        Me.tbMinsPerDay.TabIndex = 5
        Me.tbMinsPerDay.Text = "400"
        '
        'cboLetterNumber
        '
        Me.cboLetterNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLetterNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLetterNumber.Location = New System.Drawing.Point(415, 49)
        Me.cboLetterNumber.Name = "cboLetterNumber"
        Me.cboLetterNumber.Size = New System.Drawing.Size(324, 21)
        Me.cboLetterNumber.TabIndex = 41
        '
        'lbMinsPerDay
        '
        Me.lbMinsPerDay.AutoSize = True
        Me.lbMinsPerDay.Location = New System.Drawing.Point(6, 79)
        Me.lbMinsPerDay.Name = "lbMinsPerDay"
        Me.lbMinsPerDay.Size = New System.Drawing.Size(132, 13)
        Me.lbMinsPerDay.TabIndex = 4
        Me.lbMinsPerDay.Text = "Working Mins Per Day"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(351, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 16)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Letter No."
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(879, 74)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 30
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 16)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Letter Create Date"
        '
        'dtpLetterCreateDate
        '
        Me.dtpLetterCreateDate.Location = New System.Drawing.Point(142, 50)
        Me.dtpLetterCreateDate.Name = "dtpLetterCreateDate"
        Me.dtpLetterCreateDate.Size = New System.Drawing.Size(200, 21)
        Me.dtpLetterCreateDate.TabIndex = 28
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(142, 22)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(774, 21)
        Me.txtCustomer.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Customer"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(12, 151)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectAll.TabIndex = 6
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnUnselect
        '
        Me.btnUnselect.Location = New System.Drawing.Point(93, 151)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Size = New System.Drawing.Size(96, 23)
        Me.btnUnselect.TabIndex = 7
        Me.btnUnselect.Text = "Unselect All"
        Me.btnUnselect.UseVisualStyleBackColor = True
        '
        'btnGenerateLetters
        '
        Me.btnGenerateLetters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateLetters.Location = New System.Drawing.Point(808, 431)
        Me.btnGenerateLetters.Name = "btnGenerateLetters"
        Me.btnGenerateLetters.Size = New System.Drawing.Size(158, 23)
        Me.btnGenerateLetters.TabIndex = 8
        Me.btnGenerateLetters.Text = "Generate Letters"
        Me.btnGenerateLetters.UseVisualStyleBackColor = True
        '
        'FRMLetterManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 466)
        Me.Controls.Add(Me.btnGenerateLetters)
        Me.Controls.Add(Me.btnUnselect)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.btnResetFilters)
        Me.Controls.Add(Me.grpServices)
        Me.Name = "FRMLetterManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Letter Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpServices, 0)
        Me.Controls.SetChildIndex(Me.btnResetFilters, 0)
        Me.Controls.SetChildIndex(Me.grpFilters, 0)
        Me.Controls.SetChildIndex(Me.btnSelectAll, 0)
        Me.Controls.SetChildIndex(Me.btnUnselect, 0)
        Me.Controls.SetChildIndex(Me.btnGenerateLetters, 0)
        Me.grpServices.ResumeLayout(False)
        CType(Me.dgServicesDue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpServices As System.Windows.Forms.GroupBox
    Friend WithEvents dgServicesDue As System.Windows.Forms.DataGrid
    Friend WithEvents btnResetFilters As System.Windows.Forms.Button
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpLetterCreateDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnUnselect As System.Windows.Forms.Button
    Friend WithEvents btnGenerateLetters As System.Windows.Forms.Button
    Friend WithEvents cboLetterNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbMinsPerDay As System.Windows.Forms.TextBox
    Friend WithEvents lbMinsPerDay As System.Windows.Forms.Label
End Class
