Imports System.Collections.Generic

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMSelectDatabase
    Inherits FSM.FRMBaseForm


    Private _dbs As DataTable
    Private ReadOnly Property Databases() As DataTable
        Get
            Return _dbs
        End Get
    End Property
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer


    Public Sub New(ByVal dbs As DataTable)
        MyBase.New()
        _dbs = dbs
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
    End Sub
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboDatabase = New System.Windows.Forms.ComboBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnOk)
        Me.GroupBox1.Controls.Add(Me.cboDatabase)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 95)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Please Select The Database."
        '
        'cboDatabase
        '
        Me.cboDatabase.FormattingEnabled = True
        Me.cboDatabase.Location = New System.Drawing.Point(6, 29)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Size = New System.Drawing.Size(340, 21)
        Me.cboDatabase.TabIndex = 0
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(271, 66)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "OK"
        '
        'FRMSelectDatabase
        '
        Me.ClientSize = New System.Drawing.Size(380, 145)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FRMSelectDatabase"
        Me.ShowInTaskbar = True
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDatabase As ComboBox


End Class
