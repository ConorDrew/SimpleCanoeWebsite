Public Class FRMAbout : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpVersionInformation As System.Windows.Forms.GroupBox
    Friend WithEvents grpAssemblyInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents txttrademark As System.Windows.Forms.TextBox
    Friend WithEvents txtCopyright As System.Windows.Forms.TextBox
    Friend WithEvents txtproduct As System.Windows.Forms.TextBox
    Friend WithEvents txtcompany As System.Windows.Forms.TextBox
    Friend WithEvents txtdescription As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents lbltrademark As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblproduct As System.Windows.Forms.Label
    Friend WithEvents lblcompany As System.Windows.Forms.Label
    Friend WithEvents lbldescription As System.Windows.Forms.Label
    Friend WithEvents lbltitle As System.Windows.Forms.Label
    Friend WithEvents grpVersion As System.Windows.Forms.GroupBox
    Friend WithEvents rtbLatestRelease As RichTextBox
    Friend WithEvents txtVersionHistory As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpVersionInformation = New System.Windows.Forms.GroupBox()
        Me.grpAssemblyInformation = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.txttrademark = New System.Windows.Forms.TextBox()
        Me.txtCopyright = New System.Windows.Forms.TextBox()
        Me.txtproduct = New System.Windows.Forms.TextBox()
        Me.txtcompany = New System.Windows.Forms.TextBox()
        Me.txtdescription = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.lbltrademark = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblproduct = New System.Windows.Forms.Label()
        Me.lblcompany = New System.Windows.Forms.Label()
        Me.lbldescription = New System.Windows.Forms.Label()
        Me.lbltitle = New System.Windows.Forms.Label()
        Me.grpVersion = New System.Windows.Forms.GroupBox()
        Me.txtVersionHistory = New System.Windows.Forms.TextBox()
        Me.rtbLatestRelease = New System.Windows.Forms.RichTextBox()
        Me.grpVersionInformation.SuspendLayout()
        Me.grpAssemblyInformation.SuspendLayout()
        Me.grpVersion.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpVersionInformation
        '
        Me.grpVersionInformation.Controls.Add(Me.rtbLatestRelease)

        Me.grpVersionInformation.Location = New System.Drawing.Point(8, 40)
        Me.grpVersionInformation.Name = "grpVersionInformation"
        Me.grpVersionInformation.Size = New System.Drawing.Size(392, 184)
        Me.grpVersionInformation.TabIndex = 2
        Me.grpVersionInformation.TabStop = False
        Me.grpVersionInformation.Text = "Latest Release Notes"
        '
        'grpAssemblyInformation
        '
        Me.grpAssemblyInformation.Controls.Add(Me.Label1)
        Me.grpAssemblyInformation.Controls.Add(Me.txtVersion)
        Me.grpAssemblyInformation.Controls.Add(Me.txttrademark)
        Me.grpAssemblyInformation.Controls.Add(Me.txtCopyright)
        Me.grpAssemblyInformation.Controls.Add(Me.txtproduct)
        Me.grpAssemblyInformation.Controls.Add(Me.txtcompany)
        Me.grpAssemblyInformation.Controls.Add(Me.txtdescription)
        Me.grpAssemblyInformation.Controls.Add(Me.txtTitle)
        Me.grpAssemblyInformation.Controls.Add(Me.lbltrademark)
        Me.grpAssemblyInformation.Controls.Add(Me.lblCopyright)
        Me.grpAssemblyInformation.Controls.Add(Me.lblproduct)
        Me.grpAssemblyInformation.Controls.Add(Me.lblcompany)
        Me.grpAssemblyInformation.Controls.Add(Me.lbldescription)
        Me.grpAssemblyInformation.Controls.Add(Me.lbltitle)

        Me.grpAssemblyInformation.Location = New System.Drawing.Point(8, 232)
        Me.grpAssemblyInformation.Name = "grpAssemblyInformation"
        Me.grpAssemblyInformation.Size = New System.Drawing.Size(392, 200)
        Me.grpAssemblyInformation.TabIndex = 3
        Me.grpAssemblyInformation.TabStop = False
        Me.grpAssemblyInformation.Text = "Assembly Information"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Version:"
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(104, 24)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.ReadOnly = True
        Me.txtVersion.Size = New System.Drawing.Size(280, 21)
        Me.txtVersion.TabIndex = 2
        '
        'txttrademark
        '
        Me.txttrademark.Location = New System.Drawing.Point(104, 168)
        Me.txttrademark.Name = "txttrademark"
        Me.txttrademark.ReadOnly = True
        Me.txttrademark.Size = New System.Drawing.Size(280, 21)
        Me.txttrademark.TabIndex = 8
        '
        'txtCopyright
        '
        Me.txtCopyright.Location = New System.Drawing.Point(104, 144)
        Me.txtCopyright.Name = "txtCopyright"
        Me.txtCopyright.ReadOnly = True
        Me.txtCopyright.Size = New System.Drawing.Size(280, 21)
        Me.txtCopyright.TabIndex = 7
        '
        'txtproduct
        '
        Me.txtproduct.Location = New System.Drawing.Point(104, 120)
        Me.txtproduct.Name = "txtproduct"
        Me.txtproduct.ReadOnly = True
        Me.txtproduct.Size = New System.Drawing.Size(280, 21)
        Me.txtproduct.TabIndex = 6
        '
        'txtcompany
        '
        Me.txtcompany.Location = New System.Drawing.Point(104, 96)
        Me.txtcompany.Name = "txtcompany"
        Me.txtcompany.ReadOnly = True
        Me.txtcompany.Size = New System.Drawing.Size(280, 21)
        Me.txtcompany.TabIndex = 5
        '
        'txtdescription
        '
        Me.txtdescription.Location = New System.Drawing.Point(104, 72)
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.ReadOnly = True
        Me.txtdescription.Size = New System.Drawing.Size(280, 21)
        Me.txtdescription.TabIndex = 4
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(104, 48)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(280, 21)
        Me.txtTitle.TabIndex = 3
        '
        'lbltrademark
        '
        Me.lbltrademark.Location = New System.Drawing.Point(8, 168)
        Me.lbltrademark.Name = "lbltrademark"
        Me.lbltrademark.Size = New System.Drawing.Size(72, 16)
        Me.lbltrademark.TabIndex = 5
        Me.lbltrademark.Text = "Trademark:"
        '
        'lblCopyright
        '
        Me.lblCopyright.Location = New System.Drawing.Point(8, 144)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(64, 16)
        Me.lblCopyright.TabIndex = 4
        Me.lblCopyright.Text = "Copyright:"
        '
        'lblproduct
        '
        Me.lblproduct.Location = New System.Drawing.Point(8, 120)
        Me.lblproduct.Name = "lblproduct"
        Me.lblproduct.Size = New System.Drawing.Size(56, 16)
        Me.lblproduct.TabIndex = 3
        Me.lblproduct.Text = "Product:"
        '
        'lblcompany
        '
        Me.lblcompany.Location = New System.Drawing.Point(8, 96)
        Me.lblcompany.Name = "lblcompany"
        Me.lblcompany.Size = New System.Drawing.Size(64, 16)
        Me.lblcompany.TabIndex = 2
        Me.lblcompany.Text = "Company:"
        '
        'lbldescription
        '
        Me.lbldescription.Location = New System.Drawing.Point(8, 72)
        Me.lbldescription.Name = "lbldescription"
        Me.lbldescription.Size = New System.Drawing.Size(80, 16)
        Me.lbldescription.TabIndex = 1
        Me.lbldescription.Text = "Description:"
        '
        'lbltitle
        '
        Me.lbltitle.Location = New System.Drawing.Point(8, 48)
        Me.lbltitle.Name = "lbltitle"
        Me.lbltitle.Size = New System.Drawing.Size(40, 16)
        Me.lbltitle.TabIndex = 0
        Me.lbltitle.Text = "Title:"
        '
        'grpVersion
        '
        Me.grpVersion.Controls.Add(Me.txtVersionHistory)
        Me.grpVersion.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grpVersion.Location = New System.Drawing.Point(408, 40)
        Me.grpVersion.Name = "grpVersion"
        Me.grpVersion.Size = New System.Drawing.Size(409, 392)
        Me.grpVersion.TabIndex = 4
        Me.grpVersion.TabStop = False
        Me.grpVersion.Text = "Version History"
        '
        'txtVersionHistory
        '
        Me.txtVersionHistory.Location = New System.Drawing.Point(8, 16)
        Me.txtVersionHistory.Multiline = True
        Me.txtVersionHistory.Name = "txtVersionHistory"
        Me.txtVersionHistory.ReadOnly = True
        Me.txtVersionHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtVersionHistory.Size = New System.Drawing.Size(392, 368)
        Me.txtVersionHistory.TabIndex = 9
        '
        'rtbLatestRelease
        '
        Me.rtbLatestRelease.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbLatestRelease.Location = New System.Drawing.Point(3, 17)
        Me.rtbLatestRelease.Name = "rtbLatestRelease"
        Me.rtbLatestRelease.Size = New System.Drawing.Size(386, 164)
        Me.rtbLatestRelease.TabIndex = 0
        Me.rtbLatestRelease.Text = ""
        '
        'FRMAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(826, 433)
        Me.Controls.Add(Me.grpVersion)
        Me.Controls.Add(Me.grpAssemblyInformation)
        Me.Controls.Add(Me.grpVersionInformation)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(842, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(832, 472)
        Me.Name = "FRMAbout"
        Me.Text = "About"
        Me.Controls.SetChildIndex(Me.grpVersionInformation, 0)
        Me.Controls.SetChildIndex(Me.grpAssemblyInformation, 0)
        Me.Controls.SetChildIndex(Me.grpVersion, 0)
        Me.grpVersionInformation.ResumeLayout(False)
        Me.grpAssemblyInformation.ResumeLayout(False)
        Me.grpAssemblyInformation.PerformLayout()
        Me.grpVersion.ResumeLayout(False)
        Me.grpVersion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        Populate()
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

    Private Sub FRMAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

#End Region

#Region "Functions"

    Public Sub Populate()
        Me.txtVersion.Text = TheSystem.Configuration.SystemVersion
        Me.txtTitle.Text = TheSystem.Title
        Me.txtdescription.Text = TheSystem.Description
        Me.txtcompany.Text = TheSystem.Company
        Me.txtproduct.Text = TheSystem.Product
        Me.txtCopyright.Text = TheSystem.Copyright
        Me.txttrademark.Text = TheSystem.Trademark
        Me.txtVersionHistory.Text = Entity.Sys.Helper.GetTextResource("Versions.txt")

        Dim releaseNote As String = Entity.Sys.Helper.GetTextResource(ReleaseNoteTextFile)
        rtbLatestRelease.Text = releaseNote
    End Sub

#End Region

End Class
