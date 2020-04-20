Public Class FRMContactInfo : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal oSite As Entity.Sites.Site)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        CurrentSite = oSite

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

    Friend WithEvents txtTelephoneNum As TextBox
    Friend WithEvents lblTelephoneNum As Label
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents lblEmailAddress As Label
    Friend WithEvents txtFaxNum As TextBox
    Friend WithEvents lblFaxNum As Label
    Friend WithEvents txtHeadOffice As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSiteName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents grpSite As GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtTelephoneNum = New System.Windows.Forms.TextBox()
        Me.lblTelephoneNum = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.txtFaxNum = New System.Windows.Forms.TextBox()
        Me.lblFaxNum = New System.Windows.Forms.Label()
        Me.txtHeadOffice = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSiteName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpSite = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(595, 236)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Location = New System.Drawing.Point(125, 152)
        Me.txtTelephoneNum.MaxLength = 50
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.Size = New System.Drawing.Size(132, 21)
        Me.txtTelephoneNum.TabIndex = 101
        Me.txtTelephoneNum.Tag = "Site.TelephoneNum"
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(24, 155)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(48, 20)
        Me.lblTelephoneNum.TabIndex = 107
        Me.lblTelephoneNum.Text = "Tel"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(125, 182)
        Me.txtEmailAddress.MaxLength = 100
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(223, 21)
        Me.txtEmailAddress.TabIndex = 103
        Me.txtEmailAddress.Tag = "Site.EmailAddress"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(24, 185)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(98, 20)
        Me.lblEmailAddress.TabIndex = 106
        Me.lblEmailAddress.Text = "Email Address"
        '
        'txtFaxNum
        '
        Me.txtFaxNum.Location = New System.Drawing.Point(362, 154)
        Me.txtFaxNum.MaxLength = 50
        Me.txtFaxNum.Name = "txtFaxNum"
        Me.txtFaxNum.Size = New System.Drawing.Size(145, 21)
        Me.txtFaxNum.TabIndex = 102
        Me.txtFaxNum.Tag = "Site.FaxNum"
        '
        'lblFaxNum
        '
        Me.lblFaxNum.Location = New System.Drawing.Point(288, 155)
        Me.lblFaxNum.Name = "lblFaxNum"
        Me.lblFaxNum.Size = New System.Drawing.Size(50, 20)
        Me.lblFaxNum.TabIndex = 104
        Me.lblFaxNum.Text = "Mobile"
        '
        'txtHeadOffice
        '
        Me.txtHeadOffice.Location = New System.Drawing.Point(125, 91)
        Me.txtHeadOffice.Name = "txtHeadOffice"
        Me.txtHeadOffice.ReadOnly = True
        Me.txtHeadOffice.Size = New System.Drawing.Size(382, 21)
        Me.txtHeadOffice.TabIndex = 109
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(24, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 23)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Head Office:"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New System.Drawing.Point(125, 62)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(382, 21)
        Me.txtCustomerName.TabIndex = 108
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Property:"
        '
        'txtSiteName
        '
        Me.txtSiteName.Location = New System.Drawing.Point(125, 120)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.ReadOnly = True
        Me.txtSiteName.Size = New System.Drawing.Size(382, 21)
        Me.txtSiteName.TabIndex = 110
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Customer:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(426, 243)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(109, 30)
        Me.btnSave.TabIndex = 105
        Me.btnSave.Text = "Save"
        '
        'grpSite
        '
        Me.grpSite.Location = New System.Drawing.Point(6, 38)
        Me.grpSite.Name = "grpSite"
        Me.grpSite.Size = New System.Drawing.Size(529, 188)
        Me.grpSite.TabIndex = 114
        Me.grpSite.TabStop = False
        Me.grpSite.Text = "Site "
        '
        'FRMContactInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(547, 288)
        Me.Controls.Add(Me.txtHeadOffice)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSiteName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTelephoneNum)
        Me.Controls.Add(Me.lblTelephoneNum)
        Me.Controls.Add(Me.txtEmailAddress)
        Me.Controls.Add(Me.lblEmailAddress)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtFaxNum)
        Me.Controls.Add(Me.lblFaxNum)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpSite)
        Me.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Name = "FRMContactInfo"
        Me.Text = "Site Contact Information"
        Me.Controls.SetChildIndex(Me.grpSite, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.lblFaxNum, 0)
        Me.Controls.SetChildIndex(Me.txtFaxNum, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.lblEmailAddress, 0)
        Me.Controls.SetChildIndex(Me.txtEmailAddress, 0)
        Me.Controls.SetChildIndex(Me.lblTelephoneNum, 0)
        Me.Controls.SetChildIndex(Me.txtTelephoneNum, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtSiteName, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtCustomerName, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtHeadOffice, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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

#Region "Properties"

    Private _osite As Entity.Sites.Site

    Public Property CurrentSite() As Entity.Sites.Site
        Get
            Return _osite
        End Get
        Set(ByVal value As Entity.Sites.Site)
            _osite = value

            Me.txtSiteName.Text = CurrentSite.Address1 & " " & CurrentSite.Address2 & ", " & CurrentSite.Postcode

            Dim CurrentCustomer As New Entity.Customers.Customer
            CurrentCustomer = DB.Customer.Customer_Get_Light(CurrentSite.CustomerID)
            Me.txtCustomerName.Text = CurrentCustomer.Name

            Dim currentSiteHQ As Entity.Sites.Site
            currentSiteHQ = DB.Sites.Get(CurrentSite.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq)
            If currentSiteHQ IsNot Nothing Then
                With currentSiteHQ
                    Me.txtHeadOffice.Text = .Address1 & ", " & .Address2
                End With
            Else
                Me.txtHeadOffice.Text = "Not Allocated"
            End If

            Me.txtTelephoneNum.Text = CurrentSite.TelephoneNum
            Me.txtFaxNum.Text = CurrentSite.FaxNum
            Me.txtEmailAddress.Text = CurrentSite.EmailAddress
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMContactInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With CurrentSite
            .SetTelephoneNum = Me.txtTelephoneNum.Text
            .SetFaxNum = Me.txtFaxNum.Text
            .SetEmailAddress = Me.txtEmailAddress.Text
        End With
        DB.Sites.Update(CurrentSite)
        Me.DialogResult = DialogResult.Yes
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub FRMContactInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            'check user wants to close window
            If e.CloseReason = CloseReason.FormOwnerClosing OrElse e.CloseReason = CloseReason.UserClosing Then
                If MsgBox("Are you sure?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Form closing") = MsgBoxResult.No Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

End Class