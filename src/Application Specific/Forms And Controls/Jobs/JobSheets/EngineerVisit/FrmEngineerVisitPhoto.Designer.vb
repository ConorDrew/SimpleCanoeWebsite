<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEngineerVisitPhoto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEngineerVisitPhoto))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSavePicture = New System.Windows.Forms.Button()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSavePicture)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 668)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(877, 32)
        Me.Panel1.TabIndex = 1
        '
        'btnSavePicture
        '
        Me.btnSavePicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSavePicture.Location = New System.Drawing.Point(799, 6)
        Me.btnSavePicture.Name = "btnSavePicture"
        Me.btnSavePicture.Size = New System.Drawing.Size(75, 23)
        Me.btnSavePicture.TabIndex = 0
        Me.btnSavePicture.Text = "Save"
        Me.btnSavePicture.UseVisualStyleBackColor = True
        '
        'picImage
        '
        Me.picImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picImage.Location = New System.Drawing.Point(0, 0)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(877, 668)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImage.TabIndex = 2
        Me.picImage.TabStop = False
        '
        'FrmEngineerVisitPhoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 700)
        Me.Controls.Add(Me.picImage)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEngineerVisitPhoto"
        Me.Text = "Engineer Visit Photo"
        Me.Panel1.ResumeLayout(False)
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSavePicture As System.Windows.Forms.Button
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
End Class
