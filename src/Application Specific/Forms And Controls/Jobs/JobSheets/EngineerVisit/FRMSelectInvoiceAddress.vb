Imports FSM.Entity.Sys

Public Class FRMSelectInvoiceAddress : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal SiteIDIn As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        SiteID = SiteIDIn

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select
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
    Friend WithEvents btnOK As System.Windows.Forms.Button

    Friend WithEvents grpHO As System.Windows.Forms.GroupBox
    Friend WithEvents chkHO As System.Windows.Forms.CheckBox
    Friend WithEvents txtHO As System.Windows.Forms.TextBox
    Friend WithEvents grpProperty As System.Windows.Forms.GroupBox
    Friend WithEvents chkProperty As System.Windows.Forms.CheckBox
    Friend WithEvents txtProperty As System.Windows.Forms.TextBox
    Friend WithEvents grpInvoiceAddress As System.Windows.Forms.GroupBox
    Friend WithEvents chkInvoiceAddress As System.Windows.Forms.CheckBox
    Friend WithEvents dgInvoiceAddresses As System.Windows.Forms.DataGrid
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents grpDept As GroupBox
    Friend WithEvents chkDept As CheckBox
    Friend WithEvents cboDept As ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grpHO = New System.Windows.Forms.GroupBox()
        Me.chkHO = New System.Windows.Forms.CheckBox()
        Me.txtHO = New System.Windows.Forms.TextBox()
        Me.grpProperty = New System.Windows.Forms.GroupBox()
        Me.chkProperty = New System.Windows.Forms.CheckBox()
        Me.txtProperty = New System.Windows.Forms.TextBox()
        Me.grpInvoiceAddress = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgInvoiceAddresses = New System.Windows.Forms.DataGrid()
        Me.chkInvoiceAddress = New System.Windows.Forms.CheckBox()
        Me.grpDept = New System.Windows.Forms.GroupBox()
        Me.chkDept = New System.Windows.Forms.CheckBox()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.grpHO.SuspendLayout()
        Me.grpProperty.SuspendLayout()
        Me.grpInvoiceAddress.SuspendLayout()
        CType(Me.dgInvoiceAddresses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDept.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(1185, 515)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 515)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        '
        'grpHO
        '
        Me.grpHO.Controls.Add(Me.chkHO)
        Me.grpHO.Controls.Add(Me.txtHO)
        Me.grpHO.Location = New System.Drawing.Point(8, 38)
        Me.grpHO.Name = "grpHO"
        Me.grpHO.Size = New System.Drawing.Size(411, 232)
        Me.grpHO.TabIndex = 7
        Me.grpHO.TabStop = False
        Me.grpHO.Text = "Head Office"
        '
        'chkHO
        '
        Me.chkHO.AutoSize = True
        Me.chkHO.Location = New System.Drawing.Point(6, 20)
        Me.chkHO.Name = "chkHO"
        Me.chkHO.Size = New System.Drawing.Size(61, 17)
        Me.chkHO.TabIndex = 1
        Me.chkHO.Text = "Select"
        Me.chkHO.UseVisualStyleBackColor = True
        '
        'txtHO
        '
        Me.txtHO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHO.Location = New System.Drawing.Point(6, 43)
        Me.txtHO.Multiline = True
        Me.txtHO.Name = "txtHO"
        Me.txtHO.ReadOnly = True
        Me.txtHO.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtHO.Size = New System.Drawing.Size(399, 183)
        Me.txtHO.TabIndex = 0
        '
        'grpProperty
        '
        Me.grpProperty.Controls.Add(Me.chkProperty)
        Me.grpProperty.Controls.Add(Me.txtProperty)
        Me.grpProperty.Location = New System.Drawing.Point(425, 38)
        Me.grpProperty.Name = "grpProperty"
        Me.grpProperty.Size = New System.Drawing.Size(411, 232)
        Me.grpProperty.TabIndex = 8
        Me.grpProperty.TabStop = False
        Me.grpProperty.Text = "Property"
        '
        'chkProperty
        '
        Me.chkProperty.AutoSize = True
        Me.chkProperty.Location = New System.Drawing.Point(6, 20)
        Me.chkProperty.Name = "chkProperty"
        Me.chkProperty.Size = New System.Drawing.Size(61, 17)
        Me.chkProperty.TabIndex = 1
        Me.chkProperty.Text = "Select"
        Me.chkProperty.UseVisualStyleBackColor = True
        '
        'txtProperty
        '
        Me.txtProperty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProperty.Location = New System.Drawing.Point(6, 43)
        Me.txtProperty.Multiline = True
        Me.txtProperty.Name = "txtProperty"
        Me.txtProperty.ReadOnly = True
        Me.txtProperty.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtProperty.Size = New System.Drawing.Size(399, 183)
        Me.txtProperty.TabIndex = 0
        '
        'grpInvoiceAddress
        '
        Me.grpInvoiceAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInvoiceAddress.Controls.Add(Me.btnAdd)
        Me.grpInvoiceAddress.Controls.Add(Me.dgInvoiceAddresses)
        Me.grpInvoiceAddress.Controls.Add(Me.chkInvoiceAddress)
        Me.grpInvoiceAddress.Location = New System.Drawing.Point(8, 276)
        Me.grpInvoiceAddress.Name = "grpInvoiceAddress"
        Me.grpInvoiceAddress.Size = New System.Drawing.Size(1248, 233)
        Me.grpInvoiceAddress.TabIndex = 9
        Me.grpInvoiceAddress.TabStop = False
        Me.grpInvoiceAddress.Text = "Invoice Address"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(1167, 16)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgInvoiceAddresses
        '
        Me.dgInvoiceAddresses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgInvoiceAddresses.DataMember = ""
        Me.dgInvoiceAddresses.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgInvoiceAddresses.Location = New System.Drawing.Point(6, 43)
        Me.dgInvoiceAddresses.Name = "dgInvoiceAddresses"
        Me.dgInvoiceAddresses.Size = New System.Drawing.Size(1236, 184)
        Me.dgInvoiceAddresses.TabIndex = 10
        '
        'chkInvoiceAddress
        '
        Me.chkInvoiceAddress.AutoSize = True
        Me.chkInvoiceAddress.Location = New System.Drawing.Point(6, 20)
        Me.chkInvoiceAddress.Name = "chkInvoiceAddress"
        Me.chkInvoiceAddress.Size = New System.Drawing.Size(61, 17)
        Me.chkInvoiceAddress.TabIndex = 1
        Me.chkInvoiceAddress.Text = "Select"
        Me.chkInvoiceAddress.UseVisualStyleBackColor = True
        '
        'grpDept
        '
        Me.grpDept.Controls.Add(Me.cboDept)
        Me.grpDept.Controls.Add(Me.chkDept)
        Me.grpDept.Location = New System.Drawing.Point(842, 38)
        Me.grpDept.Name = "grpDept"
        Me.grpDept.Size = New System.Drawing.Size(408, 232)
        Me.grpDept.TabIndex = 9
        Me.grpDept.TabStop = False
        Me.grpDept.Text = "Department"
        '
        'chkDept
        '
        Me.chkDept.AutoSize = True
        Me.chkDept.Location = New System.Drawing.Point(6, 20)
        Me.chkDept.Name = "chkDept"
        Me.chkDept.Size = New System.Drawing.Size(61, 17)
        Me.chkDept.TabIndex = 1
        Me.chkDept.Text = "Select"
        Me.chkDept.UseVisualStyleBackColor = True
        '
        'cboDept
        '
        Me.cboDept.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(93, 18)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(309, 21)
        Me.cboDept.TabIndex = 33
        '
        'FRMSelectInvoiceAddress
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1265, 545)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpDept)
        Me.Controls.Add(Me.grpInvoiceAddress)
        Me.Controls.Add(Me.grpProperty)
        Me.Controls.Add(Me.grpHO)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.MinimumSize = New System.Drawing.Size(853, 530)
        Me.Name = "FRMSelectInvoiceAddress"
        Me.Text = "Select an address for the invoice"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.grpHO, 0)
        Me.Controls.SetChildIndex(Me.grpProperty, 0)
        Me.Controls.SetChildIndex(Me.grpInvoiceAddress, 0)
        Me.Controls.SetChildIndex(Me.grpDept, 0)
        Me.grpHO.ResumeLayout(False)
        Me.grpHO.PerformLayout()
        Me.grpProperty.ResumeLayout(False)
        Me.grpProperty.PerformLayout()
        Me.grpInvoiceAddress.ResumeLayout(False)
        Me.grpInvoiceAddress.PerformLayout()
        CType(Me.dgInvoiceAddresses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDept.ResumeLayout(False)
        Me.grpDept.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupDG()
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

    Private _SiteID As Integer = 0

    Public Property SiteID() As Integer
        Get
            Return _SiteID
        End Get
        Set(ByVal value As Integer)
            _SiteID = value

            TheSite = DB.Sites.Get(SiteID)

            TheHQ = DB.Sites.Get(TheSite.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq)

            If TheHQ Is Nothing Then
                Me.txtHO.Text = "No Head Office Assigned"
                Me.chkHO.Enabled = False
            End If

            InvoiceAddresses = DB.InvoiceAddress.InvoiceAddress_GetForSite(SiteID)

        End Set
    End Property

    Private _Site As Entity.Sites.Site = Nothing

    Public Property TheSite() As Entity.Sites.Site
        Get
            Return _Site
        End Get
        Set(ByVal value As Entity.Sites.Site)
            _Site = value

            Dim address As String = ""

            If TheSite.Name.Trim.Length > 0 Then
                address += TheSite.Name & vbCrLf
            End If
            If TheSite.Address1.Trim.Length > 0 Then
                address += TheSite.Address1 & vbCrLf
            End If
            If TheSite.Address2.Trim.Length > 0 Then
                address += TheSite.Address2 & vbCrLf
            End If
            If TheSite.Address3.Trim.Length > 0 Then
                address += TheSite.Address3 & vbCrLf
            End If
            If TheSite.Address4.Trim.Length > 0 Then
                address += TheSite.Address4 & vbCrLf
            End If
            If TheSite.Address5.Trim.Length > 0 Then
                address += TheSite.Address5 & vbCrLf
            End If
            If TheSite.Postcode.Trim.Length > 0 Then
                address += TheSite.Postcode & vbCrLf
            End If

            Me.txtProperty.Text = address
        End Set
    End Property

    Private _TheHQ As Entity.Sites.Site = Nothing

    Public Property TheHQ() As Entity.Sites.Site
        Get
            Return _TheHQ
        End Get
        Set(ByVal value As Entity.Sites.Site)
            _TheHQ = value

            If TheHQ IsNot Nothing AndAlso TheHQ.Exists Then
                Dim address As String = ""

                If TheHQ.Name.Trim.Length > 0 Then
                    address += TheHQ.Name & vbCrLf
                End If
                If TheHQ.Address1.Trim.Length > 0 Then
                    address += TheHQ.Address1 & vbCrLf
                End If
                If TheHQ.Address2.Trim.Length > 0 Then
                    address += TheHQ.Address2 & vbCrLf
                End If
                If TheHQ.Address3.Trim.Length > 0 Then
                    address += TheHQ.Address3 & vbCrLf
                End If
                If TheHQ.Address4.Trim.Length > 0 Then
                    address += TheHQ.Address4 & vbCrLf
                End If
                If TheHQ.Address5.Trim.Length > 0 Then
                    address += TheHQ.Address5 & vbCrLf
                End If
                If TheHQ.Postcode.Trim.Length > 0 Then
                    address += TheHQ.Postcode & vbCrLf
                End If

                Me.txtHO.Text = address
            End If
        End Set
    End Property

    Private _InvoiceAddresses As DataView = Nothing

    Public Property InvoiceAddresses() As DataView
        Get
            Return _InvoiceAddresses
        End Get
        Set(ByVal value As DataView)
            _InvoiceAddresses = value
            _InvoiceAddresses.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
            _InvoiceAddresses.AllowNew = False
            _InvoiceAddresses.AllowEdit = False
            _InvoiceAddresses.AllowDelete = False
            Me.dgInvoiceAddresses.DataSource = InvoiceAddresses
        End Set
    End Property

    Private ReadOnly Property SelectedInvoiceAddress() As DataRow
        Get
            If Not Me.dgInvoiceAddresses.CurrentRowIndex = -1 Then
                Return InvoiceAddresses(Me.dgInvoiceAddresses.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _AddressLinkID As Integer = 0

    Public Property AddressLinkID() As Integer
        Get
            Return _AddressLinkID
        End Get
        Set(ByVal value As Integer)
            _AddressLinkID = value
        End Set
    End Property

    Private _AddressTypeID As Integer = 0

    Public Property AddressTypeID() As Integer
        Get
            Return _AddressTypeID
        End Get
        Set(ByVal value As Integer)
            _AddressTypeID = value
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDG()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgInvoiceAddresses)
        Dim tStyle As DataGridTableStyle = Me.dgInvoiceAddresses.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Address1 As New DataGridLabelColumn
        Address1.Format = ""
        Address1.FormatInfo = Nothing
        Address1.HeaderText = "Address 1"
        Address1.MappingName = "Address1"
        Address1.ReadOnly = True
        Address1.Width = 100
        Address1.NullText = ""
        tStyle.GridColumnStyles.Add(Address1)

        Dim Address2 As New DataGridLabelColumn
        Address2.Format = ""
        Address2.FormatInfo = Nothing
        Address2.HeaderText = "Address 2"
        Address2.MappingName = "Address2"
        Address2.ReadOnly = True
        Address2.Width = 100
        Address2.NullText = ""
        tStyle.GridColumnStyles.Add(Address2)

        Dim Address3 As New DataGridLabelColumn
        Address3.Format = ""
        Address3.FormatInfo = Nothing
        Address3.HeaderText = "Address 3"
        Address3.MappingName = "Address3"
        Address3.ReadOnly = True
        Address3.Width = 100
        Address3.NullText = ""
        tStyle.GridColumnStyles.Add(Address3)

        Dim Address4 As New DataGridLabelColumn
        Address4.Format = ""
        Address4.FormatInfo = Nothing
        Address4.HeaderText = "Address 4"
        Address4.MappingName = "Address4"
        Address4.ReadOnly = True
        Address4.Width = 100
        Address4.NullText = ""
        tStyle.GridColumnStyles.Add(Address4)

        Dim Address5 As New DataGridLabelColumn
        Address5.Format = ""
        Address5.FormatInfo = Nothing
        Address5.HeaderText = "Address5"
        Address5.MappingName = "Address5"
        Address5.ReadOnly = True
        Address5.Width = 100
        Address5.NullText = ""
        tStyle.GridColumnStyles.Add(Address5)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "Postcode"
        Postcode.ReadOnly = True
        Postcode.Width = 75
        Postcode.NullText = ""
        tStyle.GridColumnStyles.Add(Postcode)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
        Me.dgInvoiceAddresses.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim count As Integer = 0
        If chkHO.Checked Then
            count += 1
        End If
        If chkProperty.Checked Then
            count += 1
        End If
        If chkInvoiceAddress.Checked Then
            count += 1
        End If

        If chkDept.Checked Then
            count += 1
        End If

        Select Case count
            Case 0
                ShowMessage("You have not selected an address", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Case 1
                If chkInvoiceAddress.Checked Then
                    If SelectedInvoiceAddress Is Nothing Then
                        ShowMessage("You have not selected an address", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            Case Else
                ShowMessage("You can only select a single address for the invoice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
        End Select

        If chkHO.Checked Then
            AddressLinkID = TheHQ.SiteID
            AddressTypeID = CInt(Entity.Sys.Enums.InvoiceAddressType.HQ)
        End If

        If chkProperty.Checked Then
            AddressLinkID = SiteID
            AddressTypeID = CInt(Entity.Sys.Enums.InvoiceAddressType.Site)
        End If

        If chkInvoiceAddress.Checked Then
            AddressLinkID = SelectedInvoiceAddress.Item("InvoiceAddressID")
            AddressTypeID = CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice)
        End If

        If chkDept.Checked Then
            Dim invoiceAddress As New Entity.InvoiceAddresss.InvoiceAddress
            With invoiceAddress
                .SetAddress1 = "DEPT " & Combo.GetSelectedItemValue(cboDept)
                .SetAddress2 = TheSystem.Configuration.CompanyName
                .SetAddress3 = TheSystem.Configuration.CompanyAddres1
                .SetAddress4 = TheSystem.Configuration.CompanyAddres3
                .SetAddress5 = String.Empty
                .SetPostcode = TheSystem.Configuration.CompanyPostcode
                .SetSiteID = SiteID
            End With

            AddressLinkID = DB.InvoiceAddress.Insert(invoiceAddress)?.InvoiceAddressID
            AddressTypeID = CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice)
        End If

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub FRMSelectInvoiceAddress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ShowForm(GetType(FRMInvoiceAddress), True, New Object() {0, SiteID, Me})
        SiteID = SiteID
    End Sub

#End Region

End Class