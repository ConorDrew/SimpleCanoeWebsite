Public Class UCInvoiceAddress : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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

    Friend WithEvents grpInvoiceAddress As System.Windows.Forms.GroupBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress3 As System.Windows.Forms.Label
    Friend WithEvents lblTown As System.Windows.Forms.Label
    Friend WithEvents lblCounty As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents lblPostcode As System.Windows.Forms.Label
    Friend WithEvents txtTelephoneNum As System.Windows.Forms.TextBox
    Friend WithEvents lblTelephoneNum As System.Windows.Forms.Label
    Friend WithEvents txtFaxNum As System.Windows.Forms.TextBox
    Friend WithEvents lblFaxNum As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress5 As System.Windows.Forms.TextBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpInvoiceAddress = New System.Windows.Forms.GroupBox
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
        Me.grpInvoiceAddress.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInvoiceAddress
        '
        Me.grpInvoiceAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInvoiceAddress.Controls.Add(Me.txtAddress1)
        Me.grpInvoiceAddress.Controls.Add(Me.lblAddress1)
        Me.grpInvoiceAddress.Controls.Add(Me.txtAddress2)
        Me.grpInvoiceAddress.Controls.Add(Me.lblAddress2)
        Me.grpInvoiceAddress.Controls.Add(Me.txtAddress3)
        Me.grpInvoiceAddress.Controls.Add(Me.lblAddress3)
        Me.grpInvoiceAddress.Controls.Add(Me.txtAddress4)
        Me.grpInvoiceAddress.Controls.Add(Me.lblTown)
        Me.grpInvoiceAddress.Controls.Add(Me.txtAddress5)
        Me.grpInvoiceAddress.Controls.Add(Me.lblCounty)
        Me.grpInvoiceAddress.Controls.Add(Me.txtPostcode)
        Me.grpInvoiceAddress.Controls.Add(Me.lblPostcode)
        Me.grpInvoiceAddress.Controls.Add(Me.txtTelephoneNum)
        Me.grpInvoiceAddress.Controls.Add(Me.lblTelephoneNum)
        Me.grpInvoiceAddress.Controls.Add(Me.txtFaxNum)
        Me.grpInvoiceAddress.Controls.Add(Me.lblFaxNum)
        Me.grpInvoiceAddress.Controls.Add(Me.txtEmailAddress)
        Me.grpInvoiceAddress.Controls.Add(Me.lblEmailAddress)
        Me.grpInvoiceAddress.Location = New System.Drawing.Point(8, 8)
        Me.grpInvoiceAddress.Name = "grpInvoiceAddress"
        Me.grpInvoiceAddress.Size = New System.Drawing.Size(625, 313)
        Me.grpInvoiceAddress.TabIndex = 1
        Me.grpInvoiceAddress.TabStop = False
        Me.grpInvoiceAddress.Text = "Main Details"
        '
        'txtAddress1
        '
        Me.txtAddress1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress1.Location = New System.Drawing.Point(141, 24)
        Me.txtAddress1.MaxLength = 255
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(474, 21)
        Me.txtAddress1.TabIndex = 2
        Me.txtAddress1.Tag = "InvoiceAddress.Address1"
        Me.txtAddress1.Text = ""
        '
        'lblAddress1
        '
        Me.lblAddress1.Location = New System.Drawing.Point(14, 24)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(73, 20)
        Me.lblAddress1.TabIndex = 31
        Me.lblAddress1.Text = "Address 1"
        '
        'txtAddress2
        '
        Me.txtAddress2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress2.Location = New System.Drawing.Point(141, 56)
        Me.txtAddress2.MaxLength = 255
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(474, 21)
        Me.txtAddress2.TabIndex = 3
        Me.txtAddress2.Tag = "InvoiceAddress.Address2"
        Me.txtAddress2.Text = ""
        '
        'lblAddress2
        '
        Me.lblAddress2.Location = New System.Drawing.Point(14, 56)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(71, 20)
        Me.lblAddress2.TabIndex = 31
        Me.lblAddress2.Text = "Address 2"
        '
        'txtAddress3
        '
        Me.txtAddress3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress3.Location = New System.Drawing.Point(141, 88)
        Me.txtAddress3.MaxLength = 255
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(473, 21)
        Me.txtAddress3.TabIndex = 4
        Me.txtAddress3.Tag = "InvoiceAddress.Address3"
        Me.txtAddress3.Text = ""
        '
        'lblAddress3
        '
        Me.lblAddress3.Location = New System.Drawing.Point(14, 88)
        Me.lblAddress3.Name = "lblAddress3"
        Me.lblAddress3.Size = New System.Drawing.Size(73, 20)
        Me.lblAddress3.TabIndex = 31
        Me.lblAddress3.Text = "Address 3"
        '
        'txtAddress4
        '
        Me.txtAddress4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress4.Location = New System.Drawing.Point(141, 120)
        Me.txtAddress4.MaxLength = 255
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.Size = New System.Drawing.Size(472, 21)
        Me.txtAddress4.TabIndex = 5
        Me.txtAddress4.Tag = "InvoiceAddress.Town"
        Me.txtAddress4.Text = ""
        '
        'lblTown
        '
        Me.lblTown.Location = New System.Drawing.Point(14, 120)
        Me.lblTown.Name = "lblTown"
        Me.lblTown.Size = New System.Drawing.Size(64, 20)
        Me.lblTown.TabIndex = 31
        Me.lblTown.Text = "Address 4"
        '
        'txtAddress5
        '
        Me.txtAddress5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress5.Location = New System.Drawing.Point(141, 152)
        Me.txtAddress5.MaxLength = 255
        Me.txtAddress5.Name = "txtAddress5"
        Me.txtAddress5.Size = New System.Drawing.Size(473, 21)
        Me.txtAddress5.TabIndex = 6
        Me.txtAddress5.Tag = "InvoiceAddress.County"
        Me.txtAddress5.Text = ""
        '
        'lblCounty
        '
        Me.lblCounty.Location = New System.Drawing.Point(14, 152)
        Me.lblCounty.Name = "lblCounty"
        Me.lblCounty.Size = New System.Drawing.Size(61, 20)
        Me.lblCounty.TabIndex = 31
        Me.lblCounty.Text = "Address 5"
        '
        'txtPostcode
        '
        Me.txtPostcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostcode.Location = New System.Drawing.Point(141, 184)
        Me.txtPostcode.MaxLength = 255
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(473, 21)
        Me.txtPostcode.TabIndex = 7
        Me.txtPostcode.Tag = "InvoiceAddress.Postcode"
        Me.txtPostcode.Text = ""
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(14, 184)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(66, 20)
        Me.lblPostcode.TabIndex = 31
        Me.lblPostcode.Text = "Postcode"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelephoneNum.Location = New System.Drawing.Point(141, 216)
        Me.txtTelephoneNum.MaxLength = 255
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.Size = New System.Drawing.Size(473, 21)
        Me.txtTelephoneNum.TabIndex = 8
        Me.txtTelephoneNum.Tag = "InvoiceAddress.TelephoneNum"
        Me.txtTelephoneNum.Text = ""
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(14, 216)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(108, 20)
        Me.lblTelephoneNum.TabIndex = 31
        Me.lblTelephoneNum.Text = "Telephone"
        '
        'txtFaxNum
        '
        Me.txtFaxNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFaxNum.Location = New System.Drawing.Point(141, 248)
        Me.txtFaxNum.MaxLength = 255
        Me.txtFaxNum.Name = "txtFaxNum"
        Me.txtFaxNum.Size = New System.Drawing.Size(473, 21)
        Me.txtFaxNum.TabIndex = 9
        Me.txtFaxNum.Tag = "InvoiceAddress.FaxNum"
        Me.txtFaxNum.Text = ""
        '
        'lblFaxNum
        '
        Me.lblFaxNum.Location = New System.Drawing.Point(14, 248)
        Me.lblFaxNum.Name = "lblFaxNum"
        Me.lblFaxNum.Size = New System.Drawing.Size(70, 20)
        Me.lblFaxNum.TabIndex = 31
        Me.lblFaxNum.Text = "Fax"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(141, 280)
        Me.txtEmailAddress.MaxLength = 255
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(473, 21)
        Me.txtEmailAddress.TabIndex = 10
        Me.txtEmailAddress.Tag = "InvoiceAddress.EmailAddress"
        Me.txtEmailAddress.Text = ""
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(14, 280)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(97, 20)
        Me.lblEmailAddress.TabIndex = 31
        Me.lblEmailAddress.Text = "Email Address"
        '
        'UCInvoiceAddress
        '
        Me.Controls.Add(Me.grpInvoiceAddress)
        Me.Name = "UCInvoiceAddress"
        Me.Size = New System.Drawing.Size(640, 329)
        Me.grpInvoiceAddress.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentInvoiceAddress
        End Get
    End Property

#End Region

#Region "Properties"

    Private _SiteID As Integer = 0
    Public Property SiteID() As Integer
        Get
            Return _SiteID
        End Get
        Set(ByVal Value As Integer)
            _SiteID = Value
        End Set
    End Property

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentInvoiceAddress As Entity.InvoiceAddresss.InvoiceAddress
    Public Property CurrentInvoiceAddress() As Entity.InvoiceAddresss.InvoiceAddress
        Get
            Return _currentInvoiceAddress
        End Get
        Set(ByVal Value As Entity.InvoiceAddresss.InvoiceAddress)
            _currentInvoiceAddress = Value

            If CurrentInvoiceAddress Is Nothing Then
                CurrentInvoiceAddress = New Entity.InvoiceAddresss.InvoiceAddress
                CurrentInvoiceAddress.Exists = False
            End If

            If CurrentInvoiceAddress.Exists Then
                Populate()
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCInvoiceAddress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentInvoiceAddress = DB.InvoiceAddress.InvoiceAddress_Get(ID)
        End If

        Me.txtAddress1.Text = CurrentInvoiceAddress.Address1
        Me.txtAddress2.Text = CurrentInvoiceAddress.Address2
        Me.txtAddress3.Text = CurrentInvoiceAddress.Address3
        Me.txtAddress4.Text = CurrentInvoiceAddress.Address4
        Me.txtAddress5.Text = CurrentInvoiceAddress.Address5
        Me.txtPostcode.Text = CurrentInvoiceAddress.Postcode
        Me.txtTelephoneNum.Text = CurrentInvoiceAddress.TelephoneNum
        Me.txtFaxNum.Text = CurrentInvoiceAddress.FaxNum
        Me.txtEmailAddress.Text = CurrentInvoiceAddress.EmailAddress
     
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentInvoiceAddress.IgnoreExceptionsOnSetMethods = True

            CurrentInvoiceAddress.SetAddress1 = Me.txtAddress1.Text.Trim
            CurrentInvoiceAddress.SetAddress2 = Me.txtAddress2.Text.Trim
            CurrentInvoiceAddress.SetAddress3 = Me.txtAddress3.Text.Trim
            CurrentInvoiceAddress.SetAddress4 = Me.txtAddress4.Text.Trim
            CurrentInvoiceAddress.SetAddress5 = Me.txtAddress5.Text.Trim
            CurrentInvoiceAddress.SetPostcode = Me.txtPostcode.Text.Trim
            CurrentInvoiceAddress.SetTelephoneNum = Me.txtTelephoneNum.Text.Trim
            CurrentInvoiceAddress.SetFaxNum = Me.txtFaxNum.Text.Trim
            CurrentInvoiceAddress.SetEmailAddress = Me.txtEmailAddress.Text.Trim
            CurrentInvoiceAddress.SetSiteID = SiteID

            Dim cV As New Entity.InvoiceAddresss.InvoiceAddressValidator
            cV.Validate(CurrentInvoiceAddress)

            If CurrentInvoiceAddress.Exists Then
                DB.InvoiceAddress.Update(CurrentInvoiceAddress)
            Else
                CurrentInvoiceAddress = DB.InvoiceAddress.Insert(CurrentInvoiceAddress)
            End If

            RaiseEvent StateChanged(CurrentInvoiceAddress.InvoiceAddressID)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

End Class

