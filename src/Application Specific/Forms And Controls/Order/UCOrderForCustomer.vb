Public Class UCOrderForCustomer : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboUsers, DB.User.GetAll().Table, "UserID", "FullName", Entity.Sys.Enums.ComboValues.Please_Select)

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFindSite As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnFindWarehouse As System.Windows.Forms.Button
    Friend WithEvents txtWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSpecial As System.Windows.Forms.Label
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents cboUsers As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnFindContact As System.Windows.Forms.Button
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnFindInvoiceAddress As System.Windows.Forms.Button
    Friend WithEvents txtInvoiceAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnFindWarehouse = New System.Windows.Forms.Button
        Me.txtWarehouse = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnFindSite = New System.Windows.Forms.Button
        Me.txtSite = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnFindCustomer = New System.Windows.Forms.Button
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblSpecial = New System.Windows.Forms.Label
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.cboUsers = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnFindContact = New System.Windows.Forms.Button
        Me.txtContact = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnFindInvoiceAddress = New System.Windows.Forms.Button
        Me.txtInvoiceAddress = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblSpecial)
        Me.GroupBox1.Controls.Add(Me.txtSpecialInstructions)
        Me.GroupBox1.Controls.Add(Me.cboUsers)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btnFindContact)
        Me.GroupBox1.Controls.Add(Me.txtContact)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.btnFindInvoiceAddress)
        Me.GroupBox1.Controls.Add(Me.txtInvoiceAddress)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.btnFindWarehouse)
        Me.GroupBox1.Controls.Add(Me.txtWarehouse)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnFindSite)
        Me.GroupBox1.Controls.Add(Me.txtSite)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnFindCustomer)
        Me.GroupBox1.Controls.Add(Me.txtCustomer)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 392)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Details"
        '
        'btnFindWarehouse
        '
        Me.btnFindWarehouse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindWarehouse.BackColor = System.Drawing.Color.White
        Me.btnFindWarehouse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindWarehouse.Location = New System.Drawing.Point(528, 133)
        Me.btnFindWarehouse.Name = "btnFindWarehouse"
        Me.btnFindWarehouse.Size = New System.Drawing.Size(32, 23)
        Me.btnFindWarehouse.TabIndex = 6
        Me.btnFindWarehouse.Text = "..."
        '
        'txtWarehouse
        '
        Me.txtWarehouse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWarehouse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWarehouse.Location = New System.Drawing.Point(128, 133)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.ReadOnly = True
        Me.txtWarehouse.Size = New System.Drawing.Size(392, 21)
        Me.txtWarehouse.TabIndex = 5
        Me.txtWarehouse.Text = ""
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 20)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Warehouse"
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = System.Drawing.Color.White
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(528, 97)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSite.TabIndex = 4
        Me.btnFindSite.Text = "..."
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(128, 97)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(392, 21)
        Me.txtSite.TabIndex = 3
        Me.txtSite.Text = ""
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Property"
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(528, 25)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 2
        Me.btnFindCustomer.Text = "..."
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(8, 25)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(512, 21)
        Me.txtCustomer.TabIndex = 1
        Me.txtCustomer.Text = ""
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(560, 23)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Please select a property to deliver to.  If property is currently unknown, select a wareh" & _
        "ouse to deliver to."
        '
        'lblSpecial
        '
        Me.lblSpecial.Location = New System.Drawing.Point(8, 280)
        Me.lblSpecial.Name = "lblSpecial"
        Me.lblSpecial.Size = New System.Drawing.Size(120, 40)
        Me.lblSpecial.TabIndex = 119
        Me.lblSpecial.Text = "Special Instructions"
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(128, 280)
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(392, 66)
        Me.txtSpecialInstructions.TabIndex = 118
        Me.txtSpecialInstructions.Text = ""
        '
        'cboUsers
        '
        Me.cboUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUsers.Location = New System.Drawing.Point(128, 232)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(392, 21)
        Me.cboUsers.TabIndex = 114
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 230)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 24)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "Co-ordinator"
        '
        'btnFindContact
        '
        Me.btnFindContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindContact.BackColor = System.Drawing.Color.White
        Me.btnFindContact.Enabled = False
        Me.btnFindContact.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindContact.Location = New System.Drawing.Point(528, 206)
        Me.btnFindContact.Name = "btnFindContact"
        Me.btnFindContact.Size = New System.Drawing.Size(32, 24)
        Me.btnFindContact.TabIndex = 113
        Me.btnFindContact.Text = "..."
        '
        'txtContact
        '
        Me.txtContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContact.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(128, 208)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.ReadOnly = True
        Me.txtContact.Size = New System.Drawing.Size(392, 21)
        Me.txtContact.TabIndex = 112
        Me.txtContact.Text = ""
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 206)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 24)
        Me.Label14.TabIndex = 116
        Me.Label14.Text = "Contact"
        '
        'btnFindInvoiceAddress
        '
        Me.btnFindInvoiceAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindInvoiceAddress.BackColor = System.Drawing.Color.White
        Me.btnFindInvoiceAddress.Enabled = False
        Me.btnFindInvoiceAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindInvoiceAddress.Location = New System.Drawing.Point(528, 254)
        Me.btnFindInvoiceAddress.Name = "btnFindInvoiceAddress"
        Me.btnFindInvoiceAddress.Size = New System.Drawing.Size(32, 24)
        Me.btnFindInvoiceAddress.TabIndex = 111
        Me.btnFindInvoiceAddress.Text = "..."
        '
        'txtInvoiceAddress
        '
        Me.txtInvoiceAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvoiceAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceAddress.Location = New System.Drawing.Point(128, 256)
        Me.txtInvoiceAddress.Name = "txtInvoiceAddress"
        Me.txtInvoiceAddress.ReadOnly = True
        Me.txtInvoiceAddress.Size = New System.Drawing.Size(392, 21)
        Me.txtInvoiceAddress.TabIndex = 110
        Me.txtInvoiceAddress.Text = ""
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 254)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 24)
        Me.Label15.TabIndex = 115
        Me.Label15.Text = "Invoice Address"
        '
        'UCOrderForCustomer
        '
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UCOrderForCustomer"
        Me.Size = New System.Drawing.Size(592, 408)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        Me.btnFindSite.Enabled = False
        Me.btnFindWarehouse.Enabled = False
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _oCustomer As Entity.Customers.Customer
    Public Property Customer() As Entity.Customers.Customer
        Get
            Return _oCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _oCustomer = Value
            Me.txtCustomer.Text = Customer.Name & " (" & Customer.AccountNumber & ")"
        End Set
    End Property

    Private _oProperty As Entity.Sites.Site
    Public Property theProperty() As Entity.Sites.Site
        Get
            Return _oProperty
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _oProperty = Value
            If theProperty Is Nothing Then
                Me.txtSite.Text = ""
                Me.btnFindInvoiceAddress.Enabled = False
                Me.btnFindContact.Enabled = False
            Else
                Me.txtSite.Text = theProperty.Address1 & ", " & theProperty.Address2 & ", " & theProperty.Postcode
                Me.btnFindInvoiceAddress.Enabled = True
                Me.btnFindContact.Enabled = True
                InvoiceAddress = Nothing
                Contact = Nothing
                Warehouse = Nothing
            End If
        End Set
    End Property

    Private _oWarehouse As Entity.Warehouses.Warehouse
    Public Property Warehouse() As Entity.Warehouses.Warehouse
        Get
            Return _oWarehouse
        End Get
        Set(ByVal Value As Entity.Warehouses.Warehouse)
            _oWarehouse = Value
            If Warehouse Is Nothing Then
                Me.txtWarehouse.Text = ""
            Else
                Me.txtWarehouse.Text = Warehouse.Name & " (" & Warehouse.Address1 & ", " & Warehouse.Postcode & ")"
                Me.btnFindInvoiceAddress.Enabled = False
                Me.btnFindContact.Enabled = False
                theProperty = Nothing
            End If
        End Set
    End Property

    Private _invoiceAddress As New Entity.InvoiceAddresss.InvoiceAddress

    Public Property InvoiceAddress() As Entity.InvoiceAddresss.InvoiceAddress
        Get
            Return _invoiceAddress
        End Get
        Set(ByVal Value As Entity.InvoiceAddresss.InvoiceAddress)
            _invoiceAddress = Value
            If Not InvoiceAddress Is Nothing Then
                Me.txtInvoiceAddress.Text = InvoiceAddress.Address1 & ", " & InvoiceAddress.Address2 & ", " & InvoiceAddress.Postcode
            Else
                Me.txtInvoiceAddress.Text = ""
            End If
        End Set
    End Property

    Private _contact As New Entity.Contacts.Contact
    Public Property Contact() As Entity.Contacts.Contact
        Get
            Return _contact
        End Get
        Set(ByVal Value As Entity.Contacts.Contact)
            _contact = Value
            If Not Contact Is Nothing Then
                Me.txtContact.Text = Contact.FirstName & " " & Contact.Surname
            Else
                Me.txtContact.Text = ""
            End If
        End Set
    End Property
#End Region

#Region "Events"

    Private Sub UCOrderForCustomer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            Customer = DB.Customer.Customer_Get(ID)
            theProperty = Nothing
            Warehouse = Nothing
            Me.btnFindSite.Enabled = True
            Me.btnFindWarehouse.Enabled = True
        Else
            Me.btnFindSite.Enabled = False
            Me.btnFindWarehouse.Enabled = False
        End If
    End Sub

    Private Sub btnFindSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSite.Click
        If Not Customer Is Nothing Then
            Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblSite, Customer.CustomerID)
            If Not ID = 0 Then
                theProperty = DB.Sites.Get(ID)
                Warehouse = Nothing
            End If
        End If
    End Sub

    Private Sub btnFindWarehouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindWarehouse.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
        If Not ID = 0 Then
            Warehouse = DB.Warehouse.Warehouse_Get(ID)
            theProperty = Nothing
        End If
    End Sub

    Private Sub btnFindContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindContact.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblContact, theProperty.SiteID)
        If Not ID = 0 Then
            Contact = DB.Contact.Contact_Get(ID)
        End If
    End Sub

    Private Sub btnFindInvoiceAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindInvoiceAddress.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblInvoiceAddress, theProperty.SiteID)
        If Not ID = 0 Then
            InvoiceAddress = DB.InvoiceAddress.InvoiceAddress_Get(ID)
        End If
    End Sub
#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        'DO NOTHING
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        'DO NOTHING
    End Function

#End Region

End Class
