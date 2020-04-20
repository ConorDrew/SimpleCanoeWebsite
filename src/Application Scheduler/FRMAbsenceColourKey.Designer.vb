<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMAbsenceColourKey
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
        Me.dgAbsences = New System.Windows.Forms.DataGrid
        CType(Me.dgAbsences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgAbsences
        '
        Me.dgAbsences.AllowNavigation = False
        Me.dgAbsences.AlternatingBackColor = System.Drawing.Color.GhostWhite
        Me.dgAbsences.BackgroundColor = System.Drawing.Color.White
        Me.dgAbsences.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgAbsences.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.dgAbsences.CaptionForeColor = System.Drawing.Color.White
        Me.dgAbsences.CaptionVisible = False
        Me.dgAbsences.DataMember = ""
        Me.dgAbsences.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAbsences.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dgAbsences.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgAbsences.GridLineColor = System.Drawing.Color.RoyalBlue
        Me.dgAbsences.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.dgAbsences.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgAbsences.HeaderForeColor = System.Drawing.Color.Lavender
        Me.dgAbsences.LinkColor = System.Drawing.Color.Teal
        Me.dgAbsences.Location = New System.Drawing.Point(0, 0)
        Me.dgAbsences.Name = "dgAbsences"
        Me.dgAbsences.ParentRowsBackColor = System.Drawing.Color.Lavender
        Me.dgAbsences.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.dgAbsences.ParentRowsVisible = False
        Me.dgAbsences.RowHeadersVisible = False
        Me.dgAbsences.SelectionBackColor = System.Drawing.Color.Teal
        Me.dgAbsences.SelectionForeColor = System.Drawing.Color.PaleGreen
        Me.dgAbsences.Size = New System.Drawing.Size(292, 266)
        Me.dgAbsences.TabIndex = 8
        '
        'FRMAbsenceColourKey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.dgAbsences)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRMAbsenceColourKey"
        Me.Text = "Absence Colour Key"
        CType(Me.dgAbsences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgAbsences As System.Windows.Forms.DataGrid
End Class
