Public Class FRMContactDetails : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents lblName As System.Windows.Forms.Label

    Friend WithEvents lblTel As System.Windows.Forms.Label
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents lblAddress3 As System.Windows.Forms.Label
    Friend WithEvents lblAddress4 As System.Windows.Forms.Label
    Friend WithEvents lblAddress5 As System.Windows.Forms.Label
    Friend WithEvents lblPostcode As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblTel = New System.Windows.Forms.Label()
        Me.lblAddress1 = New System.Windows.Forms.Label()
        Me.lblAddress2 = New System.Windows.Forms.Label()
        Me.lblAddress3 = New System.Windows.Forms.Label()
        Me.lblAddress4 = New System.Windows.Forms.Label()
        Me.lblAddress5 = New System.Windows.Forms.Label()
        Me.lblPostcode = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(8, 56)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(248, 16)
        Me.lblName.TabIndex = 2
        '
        'lblTel
        '
        Me.lblTel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTel.Location = New System.Drawing.Point(32, 80)
        Me.lblTel.Name = "lblTel"
        Me.lblTel.Size = New System.Drawing.Size(144, 16)
        Me.lblTel.TabIndex = 7
        '
        'lblAddress1
        '
        Me.lblAddress1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress1.Location = New System.Drawing.Point(248, 80)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(184, 16)
        Me.lblAddress1.TabIndex = 12
        '
        'lblAddress2
        '
        Me.lblAddress2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress2.Location = New System.Drawing.Point(248, 104)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(184, 16)
        Me.lblAddress2.TabIndex = 13
        '
        'lblAddress3
        '
        Me.lblAddress3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress3.Location = New System.Drawing.Point(248, 128)
        Me.lblAddress3.Name = "lblAddress3"
        Me.lblAddress3.Size = New System.Drawing.Size(184, 16)
        Me.lblAddress3.TabIndex = 14
        '
        'lblAddress4
        '
        Me.lblAddress4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress4.Location = New System.Drawing.Point(248, 152)
        Me.lblAddress4.Name = "lblAddress4"
        Me.lblAddress4.Size = New System.Drawing.Size(184, 16)
        Me.lblAddress4.TabIndex = 15
        '
        'lblAddress5
        '
        Me.lblAddress5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress5.Location = New System.Drawing.Point(248, 176)
        Me.lblAddress5.Name = "lblAddress5"
        Me.lblAddress5.Size = New System.Drawing.Size(184, 16)
        Me.lblAddress5.TabIndex = 16
        '
        'lblPostcode
        '
        Me.lblPostcode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPostcode.Location = New System.Drawing.Point(248, 200)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(184, 16)
        Me.lblPostcode.TabIndex = 17
        '
        'FRMContactDetails
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(448, 233)
        Me.Controls.Add(Me.lblPostcode)
        Me.Controls.Add(Me.lblAddress5)
        Me.Controls.Add(Me.lblAddress4)
        Me.Controls.Add(Me.lblAddress3)
        Me.Controls.Add(Me.lblAddress2)
        Me.Controls.Add(Me.lblAddress1)
        Me.Controls.Add(Me.lblTel)
        Me.Controls.Add(Me.lblName)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(464, 272)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(464, 272)
        Me.Name = "FRMContactDetails"
        Me.Text = "Contact Sheet"
        Me.Controls.SetChildIndex(Me.lblName, 0)
        Me.Controls.SetChildIndex(Me.lblTel, 0)
        Me.Controls.SetChildIndex(Me.lblAddress1, 0)
        Me.Controls.SetChildIndex(Me.lblAddress2, 0)
        Me.Controls.SetChildIndex(Me.lblAddress3, 0)
        Me.Controls.SetChildIndex(Me.lblAddress4, 0)
        Me.Controls.SetChildIndex(Me.lblAddress5, 0)
        Me.Controls.SetChildIndex(Me.lblPostcode, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Events"

    Private Sub FRMContactDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)

        Me.lblName.Text = TheSystem.Configuration.CompanyName
        Me.lblAddress1.Text = TheSystem.Configuration.CompanyAddres1
        Me.lblAddress2.Text = TheSystem.Configuration.CompanyAddres2
        Me.lblAddress3.Text = TheSystem.Configuration.CompanyAddres3
        Me.lblAddress4.Text = TheSystem.Configuration.CompanyAddres4
        Me.lblAddress5.Text = TheSystem.Configuration.CompanyAddres5
        Me.lblPostcode.Text = TheSystem.Configuration.CompanyPostcode
        Me.lblTel.Text = TheSystem.Configuration.CompanyTelephoneNumber
    End Sub

#End Region

End Class