<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMAddVanEquipment
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMAddVanEquipment))
        Me.grpEquipment = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cboEquipment = New System.Windows.Forms.ComboBox()
        Me.grpEquipment.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpEquipment
        '
        Me.grpEquipment.Controls.Add(Me.btnAdd)
        Me.grpEquipment.Controls.Add(Me.cboEquipment)
        Me.grpEquipment.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpEquipment.Location = New System.Drawing.Point(5, 1)
        Me.grpEquipment.Name = "grpEquipment"
        Me.grpEquipment.Size = New System.Drawing.Size(277, 76)
        Me.grpEquipment.TabIndex = 0
        Me.grpEquipment.TabStop = False
        Me.grpEquipment.Text = "Select Equipment"
        '
        'btnAdd
        '
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAdd.Location = New System.Drawing.Point(90, 46)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cboEquipment
        '
        Me.cboEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEquipment.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboEquipment.FormattingEnabled = True
        Me.cboEquipment.Location = New System.Drawing.Point(7, 19)
        Me.cboEquipment.Name = "cboEquipment"
        Me.cboEquipment.Size = New System.Drawing.Size(264, 21)
        Me.cboEquipment.TabIndex = 0
        '
        'FRMAddVanEquipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(284, 82)
        Me.Controls.Add(Me.grpEquipment)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRMAddVanEquipment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Van Equipment"
        Me.grpEquipment.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpEquipment As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cboEquipment As System.Windows.Forms.ComboBox
End Class
