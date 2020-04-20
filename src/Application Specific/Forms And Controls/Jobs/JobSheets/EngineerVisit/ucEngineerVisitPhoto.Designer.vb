<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucEngineerVisitPhoto
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtCaption = New System.Windows.Forms.TextBox()
        Me.picPhoto = New System.Windows.Forms.PictureBox()
        Me.picDeleteImage = New System.Windows.Forms.PictureBox()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDeleteImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCaption
        '
        Me.txtCaption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCaption.Location = New System.Drawing.Point(3, 240)
        Me.txtCaption.Multiline = True
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(228, 44)
        Me.txtCaption.TabIndex = 1
        '
        'picPhoto
        '
        Me.picPhoto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPhoto.BackColor = System.Drawing.Color.White
        Me.picPhoto.Location = New System.Drawing.Point(3, 3)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(228, 231)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPhoto.TabIndex = 4
        Me.picPhoto.TabStop = False
        '
        'picDeleteImage
        '
        Me.picDeleteImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picDeleteImage.BackColor = System.Drawing.Color.Transparent
        Me.picDeleteImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picDeleteImage.Image = Global.FSM.My.Resources.Resources.delete
        Me.picDeleteImage.Location = New System.Drawing.Point(208, 3)
        Me.picDeleteImage.Name = "picDeleteImage"
        Me.picDeleteImage.Size = New System.Drawing.Size(23, 22)
        Me.picDeleteImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDeleteImage.TabIndex = 5
        Me.picDeleteImage.TabStop = False
        '
        'ucEngineerVisitPhoto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.picDeleteImage)
        Me.Controls.Add(Me.txtCaption)
        Me.Controls.Add(Me.picPhoto)
        Me.Name = "ucEngineerVisitPhoto"
        Me.Size = New System.Drawing.Size(234, 287)
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDeleteImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCaption As System.Windows.Forms.TextBox
    Friend WithEvents picPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents picDeleteImage As System.Windows.Forms.PictureBox

End Class
