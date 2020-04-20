<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMPOInvoiceAuthReasons
    Inherits FSM.FRMBaseForm

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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grbAuthReasons = New System.Windows.Forms.GroupBox()
        Me.txtAuthReasonOther = New System.Windows.Forms.TextBox()
        Me.AuthReasonOption1 = New System.Windows.Forms.RadioButton()
        Me.AuthReasonOption3 = New System.Windows.Forms.RadioButton()
        Me.AuthReasonOption2 = New System.Windows.Forms.RadioButton()
        Me.grbAuthReasons.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(441, 347)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(360, 347)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'grbAuthReasons
        '
        Me.grbAuthReasons.Controls.Add(Me.txtAuthReasonOther)
        Me.grbAuthReasons.Controls.Add(Me.AuthReasonOption1)
        Me.grbAuthReasons.Controls.Add(Me.AuthReasonOption3)
        Me.grbAuthReasons.Controls.Add(Me.AuthReasonOption2)
        Me.grbAuthReasons.Location = New System.Drawing.Point(12, 48)
        Me.grbAuthReasons.Name = "grbAuthReasons"
        Me.grbAuthReasons.Size = New System.Drawing.Size(504, 119)
        Me.grbAuthReasons.TabIndex = 17
        Me.grbAuthReasons.TabStop = False
        Me.grbAuthReasons.Text = "Authorisation Reason"
        '
        'txtAuthReasonOther
        '
        Me.txtAuthReasonOther.Location = New System.Drawing.Point(48, 82)
        Me.txtAuthReasonOther.Name = "txtAuthReasonOther"
        Me.txtAuthReasonOther.Size = New System.Drawing.Size(433, 21)
        Me.txtAuthReasonOther.TabIndex = 16
        '
        'AuthReasonOption1
        '
        Me.AuthReasonOption1.AutoSize = True
        Me.AuthReasonOption1.Location = New System.Drawing.Point(48, 18)
        Me.AuthReasonOption1.Name = "AuthReasonOption1"
        Me.AuthReasonOption1.Size = New System.Drawing.Size(213, 17)
        Me.AuthReasonOption1.TabIndex = 13
        Me.AuthReasonOption1.TabStop = True
        Me.AuthReasonOption1.Text = "PO price wrong but value correct"
        Me.AuthReasonOption1.UseVisualStyleBackColor = True
        '
        'AuthReasonOption3
        '
        Me.AuthReasonOption3.AutoSize = True
        Me.AuthReasonOption3.Location = New System.Drawing.Point(48, 58)
        Me.AuthReasonOption3.Name = "AuthReasonOption3"
        Me.AuthReasonOption3.Size = New System.Drawing.Size(57, 17)
        Me.AuthReasonOption3.TabIndex = 15
        Me.AuthReasonOption3.TabStop = True
        Me.AuthReasonOption3.Text = "Other"
        Me.AuthReasonOption3.UseVisualStyleBackColor = True
        '
        'AuthReasonOption2
        '
        Me.AuthReasonOption2.AutoSize = True
        Me.AuthReasonOption2.Location = New System.Drawing.Point(48, 39)
        Me.AuthReasonOption2.Name = "AuthReasonOption2"
        Me.AuthReasonOption2.Size = New System.Drawing.Size(200, 17)
        Me.AuthReasonOption2.TabIndex = 14
        Me.AuthReasonOption2.TabStop = True
        Me.AuthReasonOption2.Text = "PO price wrong credit required"
        Me.AuthReasonOption2.UseVisualStyleBackColor = True
        '
        'FRMPOInvoiceAuthReasons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 382)
        Me.Controls.Add(Me.grbAuthReasons)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "FRMPOInvoiceAuthReasons"
        Me.Text = "FRMPOInvoiceAuthReasons"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.grbAuthReasons, 0)
        Me.grbAuthReasons.ResumeLayout(False)
        Me.grbAuthReasons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grbAuthReasons As System.Windows.Forms.GroupBox
    Friend WithEvents txtAuthReasonOther As System.Windows.Forms.TextBox
    Friend WithEvents AuthReasonOption1 As System.Windows.Forms.RadioButton
    Friend WithEvents AuthReasonOption3 As System.Windows.Forms.RadioButton
    Friend WithEvents AuthReasonOption2 As System.Windows.Forms.RadioButton
End Class
