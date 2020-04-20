Public Class FRMSitePopup : Inherits FSM.FRMBaseForm : Implements IForm

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

    Friend WithEvents btnSendEmailToSite As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress3 As System.Windows.Forms.Label
    Friend WithEvents txtAddress4 As System.Windows.Forms.TextBox
    Friend WithEvents lblTown As System.Windows.Forms.Label
    Friend WithEvents txtAddress5 As System.Windows.Forms.TextBox
    Friend WithEvents lblCounty As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents lblPostcode As System.Windows.Forms.Label
    Friend WithEvents txtTelephoneNum As System.Windows.Forms.TextBox
    Friend WithEvents lblTelephoneNum As System.Windows.Forms.Label
    Friend WithEvents txtFaxNum As System.Windows.Forms.TextBox
    Friend WithEvents lblFaxNum As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents btnClose As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSendEmailToSite = New System.Windows.Forms.Button
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.lblAddress1 = New System.Windows.Forms.Label
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.lblAddress2 = New System.Windows.Forms.Label
        Me.txtAddress3 = New System.Windows.Forms.TextBox
        Me.lblAddress3 = New System.Windows.Forms.Label
        Me.txtAddress4 = New System.Windows.Forms.TextBox
        Me.lblTown = New System.Windows.Forms.Label
        Me.txtAddress5 = New System.Windows.Forms.TextBox
        Me.lblCounty = New System.Windows.Forms.Label
        Me.txtPostcode = New System.Windows.Forms.TextBox
        Me.lblPostcode = New System.Windows.Forms.Label
        Me.txtTelephoneNum = New System.Windows.Forms.TextBox
        Me.lblTelephoneNum = New System.Windows.Forms.Label
        Me.txtFaxNum = New System.Windows.Forms.TextBox
        Me.lblFaxNum = New System.Windows.Forms.Label
        Me.txtEmailAddress = New System.Windows.Forms.TextBox
        Me.lblEmailAddress = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(10, 290)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 25)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        '
        'btnSendEmailToSite
        '
        Me.btnSendEmailToSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendEmailToSite.Location = New System.Drawing.Point(541, 264)
        Me.btnSendEmailToSite.Name = "btnSendEmailToSite"
        Me.btnSendEmailToSite.Size = New System.Drawing.Size(75, 23)
        Me.btnSendEmailToSite.TabIndex = 11
        Me.btnSendEmailToSite.Text = "Email"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(105, 45)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(511, 21)
        Me.txtName.TabIndex = 1
        Me.txtName.Tag = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 20)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Name"
        '
        'txtAddress1
        '
        Me.txtAddress1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress1.Location = New System.Drawing.Point(105, 69)
        Me.txtAddress1.MaxLength = 255
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress1.Size = New System.Drawing.Size(511, 21)
        Me.txtAddress1.TabIndex = 2
        Me.txtAddress1.Tag = "Site.Address1"
        '
        'lblAddress1
        '
        Me.lblAddress1.Location = New System.Drawing.Point(7, 69)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(67, 20)
        Me.lblAddress1.TabIndex = 26
        Me.lblAddress1.Text = "Address 1"
        '
        'txtAddress2
        '
        Me.txtAddress2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress2.Location = New System.Drawing.Point(105, 93)
        Me.txtAddress2.MaxLength = 255
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.ReadOnly = True
        Me.txtAddress2.Size = New System.Drawing.Size(511, 21)
        Me.txtAddress2.TabIndex = 3
        Me.txtAddress2.Tag = "Site.Address2"
        '
        'lblAddress2
        '
        Me.lblAddress2.Location = New System.Drawing.Point(7, 93)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(72, 20)
        Me.lblAddress2.TabIndex = 28
        Me.lblAddress2.Text = "Address 2"
        '
        'txtAddress3
        '
        Me.txtAddress3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress3.Location = New System.Drawing.Point(105, 117)
        Me.txtAddress3.MaxLength = 255
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.ReadOnly = True
        Me.txtAddress3.Size = New System.Drawing.Size(511, 21)
        Me.txtAddress3.TabIndex = 4
        Me.txtAddress3.Tag = "Site.Address3"
        '
        'lblAddress3
        '
        Me.lblAddress3.Location = New System.Drawing.Point(7, 117)
        Me.lblAddress3.Name = "lblAddress3"
        Me.lblAddress3.Size = New System.Drawing.Size(64, 20)
        Me.lblAddress3.TabIndex = 32
        Me.lblAddress3.Text = "Address 3"
        '
        'txtAddress4
        '
        Me.txtAddress4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress4.Location = New System.Drawing.Point(105, 141)
        Me.txtAddress4.MaxLength = 100
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.ReadOnly = True
        Me.txtAddress4.Size = New System.Drawing.Size(511, 21)
        Me.txtAddress4.TabIndex = 5
        Me.txtAddress4.Tag = "Site.Town"
        '
        'lblTown
        '
        Me.lblTown.Location = New System.Drawing.Point(7, 141)
        Me.lblTown.Name = "lblTown"
        Me.lblTown.Size = New System.Drawing.Size(67, 20)
        Me.lblTown.TabIndex = 35
        Me.lblTown.Text = "Address 4"
        '
        'txtAddress5
        '
        Me.txtAddress5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress5.Location = New System.Drawing.Point(105, 165)
        Me.txtAddress5.MaxLength = 100
        Me.txtAddress5.Name = "txtAddress5"
        Me.txtAddress5.ReadOnly = True
        Me.txtAddress5.Size = New System.Drawing.Size(511, 21)
        Me.txtAddress5.TabIndex = 6
        Me.txtAddress5.Tag = "Site.County"
        '
        'lblCounty
        '
        Me.lblCounty.Location = New System.Drawing.Point(7, 165)
        Me.lblCounty.Name = "lblCounty"
        Me.lblCounty.Size = New System.Drawing.Size(64, 20)
        Me.lblCounty.TabIndex = 37
        Me.lblCounty.Text = "Address 5"
        '
        'txtPostcode
        '
        Me.txtPostcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostcode.Location = New System.Drawing.Point(105, 189)
        Me.txtPostcode.MaxLength = 10
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.ReadOnly = True
        Me.txtPostcode.Size = New System.Drawing.Size(511, 21)
        Me.txtPostcode.TabIndex = 7
        Me.txtPostcode.Tag = "Site.Postcode"
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(7, 189)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(67, 20)
        Me.lblPostcode.TabIndex = 40
        Me.lblPostcode.Text = "Postcode"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelephoneNum.Location = New System.Drawing.Point(105, 213)
        Me.txtTelephoneNum.MaxLength = 50
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.ReadOnly = True
        Me.txtTelephoneNum.Size = New System.Drawing.Size(511, 21)
        Me.txtTelephoneNum.TabIndex = 8
        Me.txtTelephoneNum.Tag = "Site.TelephoneNum"
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(7, 213)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(107, 20)
        Me.lblTelephoneNum.TabIndex = 41
        Me.lblTelephoneNum.Text = "Tel"
        '
        'txtFaxNum
        '
        Me.txtFaxNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFaxNum.Location = New System.Drawing.Point(105, 237)
        Me.txtFaxNum.MaxLength = 50
        Me.txtFaxNum.Name = "txtFaxNum"
        Me.txtFaxNum.ReadOnly = True
        Me.txtFaxNum.Size = New System.Drawing.Size(511, 21)
        Me.txtFaxNum.TabIndex = 9
        Me.txtFaxNum.Tag = "Site.FaxNum"
        '
        'lblFaxNum
        '
        Me.lblFaxNum.Location = New System.Drawing.Point(7, 237)
        Me.lblFaxNum.Name = "lblFaxNum"
        Me.lblFaxNum.Size = New System.Drawing.Size(72, 20)
        Me.lblFaxNum.TabIndex = 42
        Me.lblFaxNum.Text = "Fax"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(105, 263)
        Me.txtEmailAddress.MaxLength = 100
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.ReadOnly = True
        Me.txtEmailAddress.Size = New System.Drawing.Size(430, 21)
        Me.txtEmailAddress.TabIndex = 10
        Me.txtEmailAddress.Tag = "Site.EmailAddress"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(7, 261)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(99, 20)
        Me.lblEmailAddress.TabIndex = 43
        Me.lblEmailAddress.Text = "Email Address"
        '
        'frmCandidateAssessment
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(628, 327)
        Me.Controls.Add(Me.btnSendEmailToSite)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAddress1)
        Me.Controls.Add(Me.lblAddress1)
        Me.Controls.Add(Me.txtAddress2)
        Me.Controls.Add(Me.lblAddress2)
        Me.Controls.Add(Me.txtAddress3)
        Me.Controls.Add(Me.lblAddress3)
        Me.Controls.Add(Me.txtAddress4)
        Me.Controls.Add(Me.lblTown)
        Me.Controls.Add(Me.txtAddress5)
        Me.Controls.Add(Me.lblCounty)
        Me.Controls.Add(Me.txtPostcode)
        Me.Controls.Add(Me.lblPostcode)
        Me.Controls.Add(Me.txtTelephoneNum)
        Me.Controls.Add(Me.lblTelephoneNum)
        Me.Controls.Add(Me.txtFaxNum)
        Me.Controls.Add(Me.lblFaxNum)
        Me.Controls.Add(Me.txtEmailAddress)
        Me.Controls.Add(Me.lblEmailAddress)
        Me.Controls.Add(Me.btnClose)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(636, 361)
        Me.Name = "frmCandidateAssessment"
        Me.Text = "Property : ID {0}"
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.lblEmailAddress, 0)
        Me.Controls.SetChildIndex(Me.txtEmailAddress, 0)
        Me.Controls.SetChildIndex(Me.lblFaxNum, 0)
        Me.Controls.SetChildIndex(Me.txtFaxNum, 0)
        Me.Controls.SetChildIndex(Me.lblTelephoneNum, 0)
        Me.Controls.SetChildIndex(Me.txtTelephoneNum, 0)
        Me.Controls.SetChildIndex(Me.lblPostcode, 0)
        Me.Controls.SetChildIndex(Me.txtPostcode, 0)
        Me.Controls.SetChildIndex(Me.lblCounty, 0)
        Me.Controls.SetChildIndex(Me.txtAddress5, 0)
        Me.Controls.SetChildIndex(Me.lblTown, 0)
        Me.Controls.SetChildIndex(Me.txtAddress4, 0)
        Me.Controls.SetChildIndex(Me.lblAddress3, 0)
        Me.Controls.SetChildIndex(Me.txtAddress3, 0)
        Me.Controls.SetChildIndex(Me.lblAddress2, 0)
        Me.Controls.SetChildIndex(Me.txtAddress2, 0)
        Me.Controls.SetChildIndex(Me.lblAddress1, 0)
        Me.Controls.SetChildIndex(Me.txtAddress1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtName, 0)
        Me.Controls.SetChildIndex(Me.btnSendEmailToSite, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        CurrentSite = DB.Sites.Get(Entity.Sys.Helper.MakeIntegerValid(GetParameter(0)))
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        'DO NOTHING
    End Sub

#End Region

#Region "Properties"

    Private _currentSite As Entity.Sites.Site

    Public Property CurrentSite() As Entity.Sites.Site
        Get
            Return _currentSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _currentSite = Value

            Populate()
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMSitePopup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSendEmailToSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmailToSite.Click
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = "mailto:" & CurrentSite.EmailAddress
        myProcess.StartInfo.UseShellExecute = True
        myProcess.StartInfo.RedirectStandardOutput = False
        myProcess.Start()
        myProcess.Dispose()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate()
        Me.Text = "Property : ID " & CurrentSite.SiteID
        Me.txtName.Text = CurrentSite.Name
        Me.txtAddress1.Text = CurrentSite.Address1
        Me.txtAddress2.Text = CurrentSite.Address2
        Me.txtAddress3.Text = CurrentSite.Address3
        Me.txtAddress4.Text = CurrentSite.Address4
        Me.txtAddress5.Text = CurrentSite.Address5
        Me.txtPostcode.Text = CurrentSite.Postcode
        Me.txtTelephoneNum.Text = CurrentSite.TelephoneNum
        Me.txtFaxNum.Text = CurrentSite.FaxNum
        Me.txtEmailAddress.Text = CurrentSite.EmailAddress
    End Sub

#End Region

End Class