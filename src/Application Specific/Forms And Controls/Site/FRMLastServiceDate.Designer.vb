<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMLastServiceDate : Inherits FSM.FRMBaseForm : Implements IForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpActualServiceDate = New System.Windows.Forms.DateTimePicker()
        Me.lblActualServiceDate = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dtpLastServiceDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpActualServiceDate)
        Me.GroupBox1.Controls.Add(Me.lblActualServiceDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.dtpLastServiceDate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 118)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Change Last Service Date"
        '
        'dtpActualServiceDate
        '
        Me.dtpActualServiceDate.Location = New System.Drawing.Point(173, 43)
        Me.dtpActualServiceDate.Name = "dtpActualServiceDate"
        Me.dtpActualServiceDate.Size = New System.Drawing.Size(139, 21)
        Me.dtpActualServiceDate.TabIndex = 140
        '
        'lblActualServiceDate
        '
        Me.lblActualServiceDate.Location = New System.Drawing.Point(6, 49)
        Me.lblActualServiceDate.Name = "lblActualServiceDate"
        Me.lblActualServiceDate.Size = New System.Drawing.Size(124, 20)
        Me.lblActualServiceDate.TabIndex = 139
        Me.lblActualServiceDate.Text = "Service Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Service Due Date"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(237, 79)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 137
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dtpLastServiceDate
        '
        Me.dtpLastServiceDate.Location = New System.Drawing.Point(173, 17)
        Me.dtpLastServiceDate.Name = "dtpLastServiceDate"
        Me.dtpLastServiceDate.Size = New System.Drawing.Size(139, 21)
        Me.dtpLastServiceDate.TabIndex = 136
        '
        'FRMLastServiceDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 168)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FRMLastServiceDate"
        Me.Text = "Change Last Service Date"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpActualServiceDate As DateTimePicker
    Friend WithEvents lblActualServiceDate As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents dtpLastServiceDate As DateTimePicker
End Class
