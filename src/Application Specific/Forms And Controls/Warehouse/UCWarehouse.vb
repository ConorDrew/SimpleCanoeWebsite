Public Class UCWarehouse : Inherits FSM.UCBase : Implements IUserControl

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
    Friend WithEvents tcWarehouse As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents tabStock As System.Windows.Forms.TabPage
    Friend WithEvents grpWarehouse As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress3 As System.Windows.Forms.Label
    Friend WithEvents txtAddress4 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress4 As System.Windows.Forms.Label
    Friend WithEvents txtAddress5 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress5 As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents lblPostcode As System.Windows.Forms.Label
    Friend WithEvents txtTelephoneNum As System.Windows.Forms.TextBox
    Friend WithEvents lblTelephoneNum As System.Windows.Forms.Label
    Friend WithEvents txtFaxNum As System.Windows.Forms.TextBox
    Friend WithEvents lblFaxNum As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgProducts As System.Windows.Forms.DataGrid
    Friend WithEvents tpVans As System.Windows.Forms.TabPage
    Friend WithEvents grpVans As System.Windows.Forms.GroupBox
    Friend WithEvents dgVans As System.Windows.Forms.DataGrid
    Friend WithEvents dgParts As System.Windows.Forms.DataGrid



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tcWarehouse = New System.Windows.Forms.TabControl
        Me.tabDetails = New System.Windows.Forms.TabPage
        Me.grpWarehouse = New System.Windows.Forms.GroupBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtSize = New System.Windows.Forms.TextBox
        Me.lblSize = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.lblNotes = New System.Windows.Forms.Label
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.lblAddress1 = New System.Windows.Forms.Label
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.lblAddress2 = New System.Windows.Forms.Label
        Me.txtAddress3 = New System.Windows.Forms.TextBox
        Me.lblAddress3 = New System.Windows.Forms.Label
        Me.txtAddress4 = New System.Windows.Forms.TextBox
        Me.lblAddress4 = New System.Windows.Forms.Label
        Me.txtAddress5 = New System.Windows.Forms.TextBox
        Me.lblAddress5 = New System.Windows.Forms.Label
        Me.txtPostcode = New System.Windows.Forms.TextBox
        Me.lblPostcode = New System.Windows.Forms.Label
        Me.txtTelephoneNum = New System.Windows.Forms.TextBox
        Me.lblTelephoneNum = New System.Windows.Forms.Label
        Me.txtFaxNum = New System.Windows.Forms.TextBox
        Me.lblFaxNum = New System.Windows.Forms.Label
        Me.txtEmailAddress = New System.Windows.Forms.TextBox
        Me.lblEmailAddress = New System.Windows.Forms.Label
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.tabStock = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgParts = New System.Windows.Forms.DataGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgProducts = New System.Windows.Forms.DataGrid
        Me.tpVans = New System.Windows.Forms.TabPage
        Me.grpVans = New System.Windows.Forms.GroupBox
        Me.dgVans = New System.Windows.Forms.DataGrid
        Me.tcWarehouse.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.grpWarehouse.SuspendLayout()
        Me.tabStock.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpVans.SuspendLayout()
        Me.grpVans.SuspendLayout()
        CType(Me.dgVans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcWarehouse
        '
        Me.tcWarehouse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcWarehouse.Controls.Add(Me.tabDetails)
        Me.tcWarehouse.Controls.Add(Me.tabStock)
        Me.tcWarehouse.Controls.Add(Me.tpVans)
        Me.tcWarehouse.Location = New System.Drawing.Point(3, 8)
        Me.tcWarehouse.Name = "tcWarehouse"
        Me.tcWarehouse.SelectedIndex = 0
        Me.tcWarehouse.Size = New System.Drawing.Size(710, 591)
        Me.tcWarehouse.TabIndex = 0
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.grpWarehouse)
        Me.tabDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Size = New System.Drawing.Size(702, 565)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Main Details"
        '
        'grpWarehouse
        '
        Me.grpWarehouse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpWarehouse.Controls.Add(Me.txtName)
        Me.grpWarehouse.Controls.Add(Me.lblName)
        Me.grpWarehouse.Controls.Add(Me.txtSize)
        Me.grpWarehouse.Controls.Add(Me.lblSize)
        Me.grpWarehouse.Controls.Add(Me.txtNotes)
        Me.grpWarehouse.Controls.Add(Me.lblNotes)
        Me.grpWarehouse.Controls.Add(Me.txtAddress1)
        Me.grpWarehouse.Controls.Add(Me.lblAddress1)
        Me.grpWarehouse.Controls.Add(Me.txtAddress2)
        Me.grpWarehouse.Controls.Add(Me.lblAddress2)
        Me.grpWarehouse.Controls.Add(Me.txtAddress3)
        Me.grpWarehouse.Controls.Add(Me.lblAddress3)
        Me.grpWarehouse.Controls.Add(Me.txtAddress4)
        Me.grpWarehouse.Controls.Add(Me.lblAddress4)
        Me.grpWarehouse.Controls.Add(Me.txtAddress5)
        Me.grpWarehouse.Controls.Add(Me.lblAddress5)
        Me.grpWarehouse.Controls.Add(Me.txtPostcode)
        Me.grpWarehouse.Controls.Add(Me.lblPostcode)
        Me.grpWarehouse.Controls.Add(Me.txtTelephoneNum)
        Me.grpWarehouse.Controls.Add(Me.lblTelephoneNum)
        Me.grpWarehouse.Controls.Add(Me.txtFaxNum)
        Me.grpWarehouse.Controls.Add(Me.lblFaxNum)
        Me.grpWarehouse.Controls.Add(Me.txtEmailAddress)
        Me.grpWarehouse.Controls.Add(Me.lblEmailAddress)
        Me.grpWarehouse.Controls.Add(Me.chkActive)
        Me.grpWarehouse.Location = New System.Drawing.Point(8, 8)
        Me.grpWarehouse.Name = "grpWarehouse"
        Me.grpWarehouse.Size = New System.Drawing.Size(683, 553)
        Me.grpWarehouse.TabIndex = 2
        Me.grpWarehouse.TabStop = False
        Me.grpWarehouse.Text = "Main Details"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(120, 24)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(482, 21)
        Me.txtName.TabIndex = 1
        Me.txtName.Tag = "Warehouse.Name"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(8, 24)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(104, 20)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = "Name"
        '
        'txtSize
        '
        Me.txtSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSize.Location = New System.Drawing.Point(120, 58)
        Me.txtSize.MaxLength = 255
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(554, 21)
        Me.txtSize.TabIndex = 3
        Me.txtSize.Tag = "Warehouse.Size"
        '
        'lblSize
        '
        Me.lblSize.Location = New System.Drawing.Point(8, 56)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(104, 20)
        Me.lblSize.TabIndex = 31
        Me.lblSize.Text = "Size"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(120, 378)
        Me.txtNotes.MaxLength = 0
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(554, 168)
        Me.txtNotes.TabIndex = 13
        Me.txtNotes.Tag = "Warehouse.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(8, 376)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(104, 20)
        Me.lblNotes.TabIndex = 31
        Me.lblNotes.Text = "Notes"
        '
        'txtAddress1
        '
        Me.txtAddress1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress1.Location = New System.Drawing.Point(120, 90)
        Me.txtAddress1.MaxLength = 255
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(554, 21)
        Me.txtAddress1.TabIndex = 4
        Me.txtAddress1.Tag = "Warehouse.Address1"
        '
        'lblAddress1
        '
        Me.lblAddress1.Location = New System.Drawing.Point(8, 88)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(104, 20)
        Me.lblAddress1.TabIndex = 31
        Me.lblAddress1.Text = "Address 1"
        '
        'txtAddress2
        '
        Me.txtAddress2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress2.Location = New System.Drawing.Point(120, 122)
        Me.txtAddress2.MaxLength = 255
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(554, 21)
        Me.txtAddress2.TabIndex = 5
        Me.txtAddress2.Tag = "Warehouse.Address2"
        '
        'lblAddress2
        '
        Me.lblAddress2.Location = New System.Drawing.Point(8, 120)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(104, 20)
        Me.lblAddress2.TabIndex = 31
        Me.lblAddress2.Text = "Address 2"
        '
        'txtAddress3
        '
        Me.txtAddress3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress3.Location = New System.Drawing.Point(120, 154)
        Me.txtAddress3.MaxLength = 255
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(554, 21)
        Me.txtAddress3.TabIndex = 6
        Me.txtAddress3.Tag = "Warehouse.Address3"
        '
        'lblAddress3
        '
        Me.lblAddress3.Location = New System.Drawing.Point(8, 152)
        Me.lblAddress3.Name = "lblAddress3"
        Me.lblAddress3.Size = New System.Drawing.Size(104, 20)
        Me.lblAddress3.TabIndex = 31
        Me.lblAddress3.Text = "Address 3"
        '
        'txtAddress4
        '
        Me.txtAddress4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress4.Location = New System.Drawing.Point(120, 186)
        Me.txtAddress4.MaxLength = 255
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.Size = New System.Drawing.Size(554, 21)
        Me.txtAddress4.TabIndex = 7
        Me.txtAddress4.Tag = "Warehouse.Address4"
        '
        'lblAddress4
        '
        Me.lblAddress4.Location = New System.Drawing.Point(8, 184)
        Me.lblAddress4.Name = "lblAddress4"
        Me.lblAddress4.Size = New System.Drawing.Size(104, 20)
        Me.lblAddress4.TabIndex = 31
        Me.lblAddress4.Text = "Address 4"
        '
        'txtAddress5
        '
        Me.txtAddress5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress5.Location = New System.Drawing.Point(120, 218)
        Me.txtAddress5.MaxLength = 255
        Me.txtAddress5.Name = "txtAddress5"
        Me.txtAddress5.Size = New System.Drawing.Size(554, 21)
        Me.txtAddress5.TabIndex = 8
        Me.txtAddress5.Tag = "Warehouse.Address5"
        '
        'lblAddress5
        '
        Me.lblAddress5.Location = New System.Drawing.Point(8, 216)
        Me.lblAddress5.Name = "lblAddress5"
        Me.lblAddress5.Size = New System.Drawing.Size(104, 20)
        Me.lblAddress5.TabIndex = 31
        Me.lblAddress5.Text = "Address 5"
        '
        'txtPostcode
        '
        Me.txtPostcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostcode.Location = New System.Drawing.Point(120, 250)
        Me.txtPostcode.MaxLength = 10
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(554, 21)
        Me.txtPostcode.TabIndex = 9
        Me.txtPostcode.Tag = "Warehouse.Postcode"
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(8, 248)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(104, 20)
        Me.lblPostcode.TabIndex = 31
        Me.lblPostcode.Text = "Postcode"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelephoneNum.Location = New System.Drawing.Point(120, 282)
        Me.txtTelephoneNum.MaxLength = 20
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.Size = New System.Drawing.Size(554, 21)
        Me.txtTelephoneNum.TabIndex = 10
        Me.txtTelephoneNum.Tag = "Warehouse.TelephoneNum"
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(8, 280)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(104, 20)
        Me.lblTelephoneNum.TabIndex = 31
        Me.lblTelephoneNum.Text = "Telephone"
        '
        'txtFaxNum
        '
        Me.txtFaxNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFaxNum.Location = New System.Drawing.Point(120, 314)
        Me.txtFaxNum.MaxLength = 20
        Me.txtFaxNum.Name = "txtFaxNum"
        Me.txtFaxNum.Size = New System.Drawing.Size(554, 21)
        Me.txtFaxNum.TabIndex = 11
        Me.txtFaxNum.Tag = "Warehouse.FaxNum"
        '
        'lblFaxNum
        '
        Me.lblFaxNum.Location = New System.Drawing.Point(8, 312)
        Me.lblFaxNum.Name = "lblFaxNum"
        Me.lblFaxNum.Size = New System.Drawing.Size(104, 20)
        Me.lblFaxNum.TabIndex = 31
        Me.lblFaxNum.Text = "Fax"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmailAddress.Location = New System.Drawing.Point(120, 346)
        Me.txtEmailAddress.MaxLength = 255
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(554, 21)
        Me.txtEmailAddress.TabIndex = 12
        Me.txtEmailAddress.Tag = "Warehouse.EmailAddress"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(8, 344)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(104, 20)
        Me.lblEmailAddress.TabIndex = 31
        Me.lblEmailAddress.Text = "Email Address"
        '
        'chkActive
        '
        Me.chkActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActive.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.chkActive.Location = New System.Drawing.Point(610, 26)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(64, 18)
        Me.chkActive.TabIndex = 2
        Me.chkActive.Tag = "Warehouse.Active"
        Me.chkActive.Text = "Active"
        '
        'tabStock
        '
        Me.tabStock.Controls.Add(Me.GroupBox2)
        Me.tabStock.Controls.Add(Me.GroupBox1)
        Me.tabStock.Location = New System.Drawing.Point(4, 22)
        Me.tabStock.Name = "tabStock"
        Me.tabStock.Size = New System.Drawing.Size(702, 565)
        Me.tabStock.TabIndex = 1
        Me.tabStock.Text = "Stock"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgParts)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 216)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(683, 338)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parts held in warehouse"
        '
        'dgParts
        '
        Me.dgParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgParts.DataMember = ""
        Me.dgParts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgParts.Location = New System.Drawing.Point(8, 26)
        Me.dgParts.Name = "dgParts"
        Me.dgParts.Size = New System.Drawing.Size(667, 304)
        Me.dgParts.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgProducts)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(683, 200)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Products held in warehouse"
        '
        'dgProducts
        '
        Me.dgProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProducts.DataMember = ""
        Me.dgProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProducts.Location = New System.Drawing.Point(8, 26)
        Me.dgProducts.Name = "dgProducts"
        Me.dgProducts.Size = New System.Drawing.Size(667, 166)
        Me.dgProducts.TabIndex = 1
        '
        'tpVans
        '
        Me.tpVans.Controls.Add(Me.grpVans)
        Me.tpVans.Location = New System.Drawing.Point(4, 22)
        Me.tpVans.Name = "tpVans"
        Me.tpVans.Padding = New System.Windows.Forms.Padding(3)
        Me.tpVans.Size = New System.Drawing.Size(702, 565)
        Me.tpVans.TabIndex = 2
        Me.tpVans.Text = "Vans"
        Me.tpVans.UseVisualStyleBackColor = True
        '
        'grpVans
        '
        Me.grpVans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVans.Controls.Add(Me.dgVans)
        Me.grpVans.Location = New System.Drawing.Point(6, 3)
        Me.grpVans.Name = "grpVans"
        Me.grpVans.Size = New System.Drawing.Size(690, 549)
        Me.grpVans.TabIndex = 4
        Me.grpVans.TabStop = False
        Me.grpVans.Text = "Tick those vans for this warehouse"
        '
        'dgVans
        '
        Me.dgVans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVans.DataMember = ""
        Me.dgVans.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVans.Location = New System.Drawing.Point(6, 20)
        Me.dgVans.Name = "dgVans"
        Me.dgVans.Size = New System.Drawing.Size(678, 523)
        Me.dgVans.TabIndex = 2
        '
        'UCWarehouse
        '
        Me.Controls.Add(Me.tcWarehouse)
        Me.Name = "UCWarehouse"
        Me.Size = New System.Drawing.Size(723, 604)
        Me.tcWarehouse.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.grpWarehouse.ResumeLayout(False)
        Me.grpWarehouse.PerformLayout()
        Me.tabStock.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpVans.ResumeLayout(False)
        Me.grpVans.ResumeLayout(False)
        CType(Me.dgVans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupPartsDatagrid()
        SetupProductsDatagrid()
        SetupVansDatagrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentWarehouse
        End Get
    End Property

#End Region

#Region "Properties"

    Private m_dTable As DataView = Nothing
    Public Property ProductsDataView() As DataView
        Get
            Return m_dTable
        End Get
        Set(ByVal Value As DataView)
            m_dTable = Value
            m_dTable.Table.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
            m_dTable.AllowNew = False
            m_dTable.AllowEdit = False
            m_dTable.AllowDelete = False
            Me.dgProducts.DataSource = ProductsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedProductDataRow() As DataRow
        Get
            If Not Me.dgProducts.CurrentRowIndex = -1 Then
                Return ProductsDataView(Me.dgProducts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private m_dTable2 As DataView = Nothing
    Public Property PartsDataView() As DataView
        Get
            Return m_dTable2
        End Get
        Set(ByVal Value As DataView)
            m_dTable2 = Value
            m_dTable2.Table.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
            m_dTable2.AllowNew = False
            m_dTable2.AllowEdit = False
            m_dTable2.AllowDelete = False
            Me.dgParts.DataSource = PartsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedPartDataRow() As DataRow
        Get
            If Not Me.dgParts.CurrentRowIndex = -1 Then
                Return PartsDataView(Me.dgParts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentWarehouse As Entity.Warehouses.Warehouse
    Public Property CurrentWarehouse() As Entity.Warehouses.Warehouse
        Get
            Return _currentWarehouse
        End Get
        Set(ByVal Value As Entity.Warehouses.Warehouse)
            _currentWarehouse = Value

            If CurrentWarehouse Is Nothing Then
                CurrentWarehouse = New Entity.Warehouses.Warehouse
                CurrentWarehouse.Exists = False
            End If

            If CurrentWarehouse.Exists Then
                Populate()
            Else
                VansDataView = DB.Van.Van_GetAll_For_Warehouse(0)
            End If
        End Set
    End Property

    Private _VansDataView As DataView = Nothing
    Public Property VansDataView() As DataView
        Get
            Return _VansDataView
        End Get
        Set(ByVal Value As DataView)
            _VansDataView = Value
            _VansDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString
            _VansDataView.AllowNew = False
            _VansDataView.AllowEdit = False
            _VansDataView.AllowDelete = False
            Me.dgVans.DataSource = VansDataView
        End Set
    End Property

    Private ReadOnly Property SelectedVanDataRow() As DataRow
        Get
            If Not Me.dgVans.CurrentRowIndex = -1 Then
                Return VansDataView(Me.dgVans.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupProductsDatagrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgProducts)
        Dim tStyle As DataGridTableStyle = Me.dgProducts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim ProductName As New DataGridLabelColumn
        ProductName.Format = ""
        ProductName.FormatInfo = Nothing
        ProductName.HeaderText = "Description"
        ProductName.MappingName = "typemakemodel"
        ProductName.ReadOnly = True
        ProductName.Width = 180
        ProductName.NullText = ""
        tStyle.GridColumnStyles.Add(ProductName)

        Dim ProductNumber As New DataGridLabelColumn
        ProductNumber.Format = ""
        ProductNumber.FormatInfo = Nothing
        ProductNumber.HeaderText = "GC Number"
        ProductNumber.MappingName = "ProductNumber"
        ProductNumber.ReadOnly = True
        ProductNumber.Width = 140
        ProductNumber.NullText = ""
        tStyle.GridColumnStyles.Add(ProductNumber)

        Dim ProductReference As New DataGridLabelColumn
        ProductReference.Format = ""
        ProductReference.FormatInfo = Nothing
        ProductReference.HeaderText = "Product Reference"
        ProductReference.MappingName = "Reference"
        ProductReference.ReadOnly = True
        ProductReference.Width = 200
        ProductReference.NullText = ""
        tStyle.GridColumnStyles.Add(ProductReference)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 120
        Amount.NullText = ""
        tStyle.GridColumnStyles.Add(Amount)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProduct.ToString
        Me.dgProducts.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupPartsDatagrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgParts)
        Dim tStyle As DataGridTableStyle = Me.dgParts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim PartName As New DataGridLabelColumn
        PartName.Format = ""
        PartName.FormatInfo = Nothing
        PartName.HeaderText = "Part Name"
        PartName.MappingName = "PartName"
        PartName.ReadOnly = True
        PartName.Width = 180
        PartName.NullText = ""
        tStyle.GridColumnStyles.Add(PartName)

        Dim PartNumber As New DataGridLabelColumn
        PartNumber.Format = ""
        PartNumber.FormatInfo = Nothing
        PartNumber.HeaderText = "Part Number"
        PartNumber.MappingName = "PartNumber"
        PartNumber.ReadOnly = True
        PartNumber.Width = 70
        PartNumber.NullText = ""
        tStyle.GridColumnStyles.Add(PartNumber)

        Dim PartReference As New DataGridLabelColumn
        PartReference.Format = ""
        PartReference.FormatInfo = Nothing
        PartReference.HeaderText = "Part Reference"
        PartReference.MappingName = "Reference"
        PartReference.ReadOnly = True
        PartReference.Width = 100
        PartReference.NullText = ""
        tStyle.GridColumnStyles.Add(PartReference)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 120
        Amount.NullText = ""
        tStyle.GridColumnStyles.Add(Amount)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString
        Me.dgParts.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupVansDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgVans)
        Dim tStyle As DataGridTableStyle = Me.dgVans.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        tStyle.ReadOnly = False
        tStyle.AllowSorting = False
        dgVans.ReadOnly = False
        dgVans.AllowSorting = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Registration As New DataGridLabelColumn
        Registration.Format = ""
        Registration.FormatInfo = Nothing
        Registration.HeaderText = "Registration"
        Registration.MappingName = "Registration"
        Registration.ReadOnly = True
        Registration.Width = 300
        Registration.NullText = ""
        tStyle.GridColumnStyles.Add(Registration)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblVan.ToString
        Me.dgVans.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCWarehouse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub dgParts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgParts.DoubleClick
        If SelectedPartDataRow Is Nothing Then
            Exit Sub
        End If
        ShowForm(GetType(FRMPart), True, New Object() {SelectedPartDataRow.Item("PartID"), True})
        PartsDataView = DB.PartTransaction.GetByWarehouse(CurrentWarehouse.WarehouseID)
    End Sub

    Private Sub dgVans_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgVans.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgVans.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgVans.CurrentRowIndex = HitTestInfo.Row()
            End If

            If Not HitTestInfo.Column = 0 Then
                Exit Sub
            End If
            If SelectedVanDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(Me.dgVans(Me.dgVans.CurrentRowIndex, 0))

            If Not selected Then
                If SelectedVanDataRow.Item("HasStock") Then
                    ShowMessage("'" & SelectedVanDataRow.Item("Name") & "' on this van has stock so cannot be unselected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            Me.dgVans(Me.dgVans.CurrentRowIndex, 0) = selected
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentWarehouse = DB.Warehouse.Warehouse_Get(ID)
        End If

        ProductsDataView = DB.ProductTransaction.GetByWarehouse(CurrentWarehouse.WarehouseID)
        PartsDataView = DB.PartTransaction.GetByWarehouse(CurrentWarehouse.WarehouseID)
        VansDataView = DB.Van.Van_GetAll_For_Warehouse(CurrentWarehouse.WarehouseID)

        Me.txtName.Text = CurrentWarehouse.Name
        Me.txtSize.Text = CurrentWarehouse.Size
        Me.txtNotes.Text = CurrentWarehouse.Notes
        Me.txtAddress1.Text = CurrentWarehouse.Address1
        Me.txtAddress2.Text = CurrentWarehouse.Address2
        Me.txtAddress3.Text = CurrentWarehouse.Address3
        Me.txtAddress4.Text = CurrentWarehouse.Address4
        Me.txtAddress5.Text = CurrentWarehouse.Address5
        Me.txtPostcode.Text = CurrentWarehouse.Postcode
        Me.txtTelephoneNum.Text = CurrentWarehouse.TelephoneNum
        Me.txtFaxNum.Text = CurrentWarehouse.FaxNum
        Me.txtEmailAddress.Text = CurrentWarehouse.EmailAddress
        Me.chkActive.Checked = CurrentWarehouse.Active
        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentWarehouse.IgnoreExceptionsOnSetMethods = True

            CurrentWarehouse.SetName = Me.txtName.Text.Trim
            CurrentWarehouse.SetSize = Me.txtSize.Text.Trim
            CurrentWarehouse.SetNotes = Me.txtNotes.Text.Trim
            CurrentWarehouse.SetAddress1 = Me.txtAddress1.Text.Trim
            CurrentWarehouse.SetAddress2 = Me.txtAddress2.Text.Trim
            CurrentWarehouse.SetAddress3 = Me.txtAddress3.Text.Trim
            CurrentWarehouse.SetAddress4 = Me.txtAddress4.Text.Trim
            CurrentWarehouse.SetAddress5 = Me.txtAddress5.Text.Trim
            CurrentWarehouse.SetPostcode = Me.txtPostcode.Text.Trim
            CurrentWarehouse.SetTelephoneNum = Me.txtTelephoneNum.Text.Trim
            CurrentWarehouse.SetFaxNum = Me.txtFaxNum.Text.Trim
            CurrentWarehouse.SetEmailAddress = Me.txtEmailAddress.Text.Trim
            CurrentWarehouse.SetActive = Me.chkActive.Checked

            Dim cV As New Entity.Warehouses.WarehouseValidator
            cV.Validate(CurrentWarehouse)

            If CurrentWarehouse.Exists Then
                DB.Warehouse.Update(CurrentWarehouse, VansDataView)
            Else
                CurrentWarehouse = DB.Warehouse.Insert(CurrentWarehouse, VansDataView)
            End If

            RaiseEvent RecordsChanged(DB.Warehouse.Warehouse_GetAll(), Entity.Sys.Enums.PageViewing.Warehouse, True, False, "")
            RaiseEvent StateChanged(CurrentWarehouse.WarehouseID)
            MainForm.RefreshEntity(CurrentWarehouse.WarehouseID)

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

