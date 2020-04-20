<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMGenDropBox
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMGenDropBox))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.lblMiddle = New System.Windows.Forms.Label()
        Me.lblref = New System.Windows.Forms.Label()
        Me.txtref = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cbo1 = New System.Windows.Forms.ComboBox()
        Me.cbo2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.lblTop)
        Me.GroupBox1.Controls.Add(Me.lblMiddle)
        Me.GroupBox1.Controls.Add(Me.lblref)
        Me.GroupBox1.Controls.Add(Me.txtref)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Controls.Add(Me.cbo1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(505, 169)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(10, 140)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblTop
        '
        Me.lblTop.AutoSize = True
        Me.lblTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTop.ForeColor = System.Drawing.Color.Maroon
        Me.lblTop.Location = New System.Drawing.Point(6, 19)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(366, 16)
        Me.lblTop.TabIndex = 6
        Me.lblTop.Text = "You Must Take Payment Now In order to set up this Contract. "
        '
        'lblMiddle
        '
        Me.lblMiddle.AutoSize = True
        Me.lblMiddle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMiddle.ForeColor = System.Drawing.Color.Maroon
        Me.lblMiddle.Location = New System.Drawing.Point(5, 45)
        Me.lblMiddle.Name = "lblMiddle"
        Me.lblMiddle.Size = New System.Drawing.Size(354, 16)
        Me.lblMiddle.TabIndex = 5
        Me.lblMiddle.Text = " Please select payment type and detail payment reference"
        '
        'lblref
        '
        Me.lblref.AutoSize = True
        Me.lblref.Location = New System.Drawing.Point(93, 115)
        Me.lblref.Name = "lblref"
        Me.lblref.Size = New System.Drawing.Size(101, 13)
        Me.lblref.TabIndex = 3
        Me.lblref.Text = "Payment Reference"
        '
        'txtref
        '
        Me.txtref.Location = New System.Drawing.Point(200, 112)
        Me.txtref.Name = "txtref"
        Me.txtref.Size = New System.Drawing.Size(226, 20)
        Me.txtref.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(424, 140)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "Proceed"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cbo1
        '
        Me.cbo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo1.FormattingEnabled = True
        Me.cbo1.Location = New System.Drawing.Point(97, 76)
        Me.cbo1.Name = "cbo1"
        Me.cbo1.Size = New System.Drawing.Size(330, 21)
        Me.cbo1.TabIndex = 0
        '
        'cbo2
        '
        Me.cbo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo2.FormattingEnabled = True
        Me.cbo2.Location = New System.Drawing.Point(96, 76)
        Me.cbo2.Name = "cbo2"
        Me.cbo2.Size = New System.Drawing.Size(330, 21)
        Me.cbo2.TabIndex = 8
        Me.cbo2.Visible = False
        '
        'FRMGenDropBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(513, 182)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRMGenDropBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cbo1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents lblMiddle As System.Windows.Forms.Label
    Friend WithEvents lblref As System.Windows.Forms.Label
    Friend WithEvents txtref As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbo2 As ComboBox
End Class
