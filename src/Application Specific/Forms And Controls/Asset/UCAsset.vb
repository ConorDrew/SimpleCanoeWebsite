Public Class UCAsset : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
          Combo.SetUpCombo(Me.cboGasType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.GasTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFlueType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.FlueTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents grpAsset As System.Windows.Forms.GroupBox
    Friend WithEvents chkDateUnknown As System.Windows.Forms.CheckBox
    Friend WithEvents lblProductID As System.Windows.Forms.Label
    Friend WithEvents txtSerialNum As System.Windows.Forms.TextBox
    Friend WithEvents lblSerialNum As System.Windows.Forms.Label
    Friend WithEvents lblDateFitted As System.Windows.Forms.Label
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents tabDocuments As System.Windows.Forms.TabPage
    Friend WithEvents pnlDocuments As System.Windows.Forms.Panel
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkCertificateLastIssuedUnknown As System.Windows.Forms.CheckBox
    Friend WithEvents dtpCertificateLastIssued As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBoughtFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierBy As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateFitted As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkLastServicedDateUnknown As System.Windows.Forms.CheckBox
    Friend WithEvents dtpLastServicedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents tabJobs As System.Windows.Forms.TabPage
    Friend WithEvents dgJobs As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddJob As System.Windows.Forms.Button
    Friend WithEvents grpJobs As System.Windows.Forms.GroupBox
    Friend WithEvents dtpWarrantyEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkWarrantyStartDateUnknown As System.Windows.Forms.CheckBox
    Friend WithEvents dtpWarrantyStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGCNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtYearOfManufacture As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtApproximateValue As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboGasType As System.Windows.Forms.ComboBox
    Friend WithEvents cboFlueType As System.Windows.Forms.ComboBox
    Friend WithEvents btnFindProduct As System.Windows.Forms.Button
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents chkTenantsAppliance As System.Windows.Forms.CheckBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabDetails = New System.Windows.Forms.TabPage
        Me.grpAsset = New System.Windows.Forms.GroupBox
        Me.chkTenantsAppliance = New System.Windows.Forms.CheckBox
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.btnFindProduct = New System.Windows.Forms.Button
        Me.txtProduct = New System.Windows.Forms.TextBox
        Me.cboFlueType = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboGasType = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtApproximateValue = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtYearOfManufacture = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtGCNumber = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpWarrantyEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkWarrantyStartDateUnknown = New System.Windows.Forms.CheckBox
        Me.dtpWarrantyStartDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkLastServicedDateUnknown = New System.Windows.Forms.CheckBox
        Me.dtpLastServicedDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkCertificateLastIssuedUnknown = New System.Windows.Forms.CheckBox
        Me.dtpCertificateLastIssued = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtBoughtFrom = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSupplierBy = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.chkDateUnknown = New System.Windows.Forms.CheckBox
        Me.lblProductID = New System.Windows.Forms.Label
        Me.txtSerialNum = New System.Windows.Forms.TextBox
        Me.lblSerialNum = New System.Windows.Forms.Label
        Me.dtpDateFitted = New System.Windows.Forms.DateTimePicker
        Me.lblDateFitted = New System.Windows.Forms.Label
        Me.lblLocationID = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.lblNotes = New System.Windows.Forms.Label
        Me.tabDocuments = New System.Windows.Forms.TabPage
        Me.pnlDocuments = New System.Windows.Forms.Panel
        Me.tabJobs = New System.Windows.Forms.TabPage
        Me.grpJobs = New System.Windows.Forms.GroupBox
        Me.btnAddJob = New System.Windows.Forms.Button
        Me.dgJobs = New System.Windows.Forms.DataGrid
        Me.TabControl1.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.grpAsset.SuspendLayout()
        Me.tabDocuments.SuspendLayout()
        Me.tabJobs.SuspendLayout()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabDetails)
        Me.TabControl1.Controls.Add(Me.tabDocuments)
        Me.TabControl1.Controls.Add(Me.tabJobs)
        Me.TabControl1.Location = New System.Drawing.Point(1, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(788, 582)
        Me.TabControl1.TabIndex = 0
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.grpAsset)
        Me.tabDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Size = New System.Drawing.Size(780, 556)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Main Details"
        '
        'grpAsset
        '
        Me.grpAsset.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAsset.Controls.Add(Me.chkTenantsAppliance)
        Me.grpAsset.Controls.Add(Me.chkActive)
        Me.grpAsset.Controls.Add(Me.btnFindProduct)
        Me.grpAsset.Controls.Add(Me.txtProduct)
        Me.grpAsset.Controls.Add(Me.cboFlueType)
        Me.grpAsset.Controls.Add(Me.Label11)
        Me.grpAsset.Controls.Add(Me.cboGasType)
        Me.grpAsset.Controls.Add(Me.Label10)
        Me.grpAsset.Controls.Add(Me.txtApproximateValue)
        Me.grpAsset.Controls.Add(Me.Label9)
        Me.grpAsset.Controls.Add(Me.txtYearOfManufacture)
        Me.grpAsset.Controls.Add(Me.Label8)
        Me.grpAsset.Controls.Add(Me.txtGCNumber)
        Me.grpAsset.Controls.Add(Me.Label7)
        Me.grpAsset.Controls.Add(Me.dtpWarrantyEndDate)
        Me.grpAsset.Controls.Add(Me.Label5)
        Me.grpAsset.Controls.Add(Me.chkWarrantyStartDateUnknown)
        Me.grpAsset.Controls.Add(Me.dtpWarrantyStartDate)
        Me.grpAsset.Controls.Add(Me.Label6)
        Me.grpAsset.Controls.Add(Me.chkLastServicedDateUnknown)
        Me.grpAsset.Controls.Add(Me.dtpLastServicedDate)
        Me.grpAsset.Controls.Add(Me.Label4)
        Me.grpAsset.Controls.Add(Me.chkCertificateLastIssuedUnknown)
        Me.grpAsset.Controls.Add(Me.dtpCertificateLastIssued)
        Me.grpAsset.Controls.Add(Me.Label3)
        Me.grpAsset.Controls.Add(Me.txtBoughtFrom)
        Me.grpAsset.Controls.Add(Me.Label2)
        Me.grpAsset.Controls.Add(Me.txtSupplierBy)
        Me.grpAsset.Controls.Add(Me.Label1)
        Me.grpAsset.Controls.Add(Me.txtLocation)
        Me.grpAsset.Controls.Add(Me.chkDateUnknown)
        Me.grpAsset.Controls.Add(Me.lblProductID)
        Me.grpAsset.Controls.Add(Me.txtSerialNum)
        Me.grpAsset.Controls.Add(Me.lblSerialNum)
        Me.grpAsset.Controls.Add(Me.dtpDateFitted)
        Me.grpAsset.Controls.Add(Me.lblDateFitted)
        Me.grpAsset.Controls.Add(Me.lblLocationID)
        Me.grpAsset.Controls.Add(Me.txtNotes)
        Me.grpAsset.Controls.Add(Me.lblNotes)
        Me.grpAsset.Location = New System.Drawing.Point(11, 6)
        Me.grpAsset.Name = "grpAsset"
        Me.grpAsset.Size = New System.Drawing.Size(762, 542)
        Me.grpAsset.TabIndex = 0
        Me.grpAsset.TabStop = False
        Me.grpAsset.Text = "Details"
        '
        'chkTenantsAppliance
        '
        Me.chkTenantsAppliance.Location = New System.Drawing.Point(217, 426)
        Me.chkTenantsAppliance.Name = "chkTenantsAppliance"
        Me.chkTenantsAppliance.Size = New System.Drawing.Size(140, 24)
        Me.chkTenantsAppliance.TabIndex = 39
        Me.chkTenantsAppliance.Text = "Tenants Appliance"
        '
        'chkActive
        '
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Location = New System.Drawing.Point(152, 426)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(88, 24)
        Me.chkActive.TabIndex = 38
        Me.chkActive.Text = "Active"
        '
        'btnFindProduct
        '
        Me.btnFindProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindProduct.Location = New System.Drawing.Point(727, 18)
        Me.btnFindProduct.Name = "btnFindProduct"
        Me.btnFindProduct.Size = New System.Drawing.Size(29, 23)
        Me.btnFindProduct.TabIndex = 37
        Me.btnFindProduct.Text = "..."
        Me.btnFindProduct.UseVisualStyleBackColor = True
        '
        'txtProduct
        '
        Me.txtProduct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProduct.Location = New System.Drawing.Point(152, 20)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.ReadOnly = True
        Me.txtProduct.Size = New System.Drawing.Size(569, 21)
        Me.txtProduct.TabIndex = 36
        '
        'cboFlueType
        '
        Me.cboFlueType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFlueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlueType.Location = New System.Drawing.Point(152, 128)
        Me.cboFlueType.Name = "cboFlueType"
        Me.cboFlueType.Size = New System.Drawing.Size(174, 21)
        Me.cboFlueType.TabIndex = 9
        Me.cboFlueType.Tag = ""
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 20)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Flue Type"
        '
        'cboGasType
        '
        Me.cboGasType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboGasType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGasType.Location = New System.Drawing.Point(152, 155)
        Me.cboGasType.Name = "cboGasType"
        Me.cboGasType.Size = New System.Drawing.Size(174, 21)
        Me.cboGasType.TabIndex = 11
        Me.cboGasType.Tag = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(9, 158)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 20)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Fuel Type"
        '
        'txtApproximateValue
        '
        Me.txtApproximateValue.Location = New System.Drawing.Point(152, 399)
        Me.txtApproximateValue.MaxLength = 100
        Me.txtApproximateValue.Name = "txtApproximateValue"
        Me.txtApproximateValue.Size = New System.Drawing.Size(174, 21)
        Me.txtApproximateValue.TabIndex = 33
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(9, 402)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 20)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Approximate Value"
        '
        'txtYearOfManufacture
        '
        Me.txtYearOfManufacture.Location = New System.Drawing.Point(152, 372)
        Me.txtYearOfManufacture.MaxLength = 100
        Me.txtYearOfManufacture.Name = "txtYearOfManufacture"
        Me.txtYearOfManufacture.Size = New System.Drawing.Size(174, 21)
        Me.txtYearOfManufacture.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(9, 375)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 20)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Year Of Manufacture"
        '
        'txtGCNumber
        '
        Me.txtGCNumber.Location = New System.Drawing.Point(152, 74)
        Me.txtGCNumber.MaxLength = 100
        Me.txtGCNumber.Name = "txtGCNumber"
        Me.txtGCNumber.ReadOnly = True
        Me.txtGCNumber.Size = New System.Drawing.Size(174, 21)
        Me.txtGCNumber.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(9, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "GC Number"
        '
        'dtpWarrantyEndDate
        '
        Me.dtpWarrantyEndDate.Location = New System.Drawing.Point(152, 291)
        Me.dtpWarrantyEndDate.Name = "dtpWarrantyEndDate"
        Me.dtpWarrantyEndDate.Size = New System.Drawing.Size(174, 21)
        Me.dtpWarrantyEndDate.TabIndex = 25
        Me.dtpWarrantyEndDate.Tag = "Asset.WarrantyEndDate"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(9, 295)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Warranty End Date"
        '
        'chkWarrantyStartDateUnknown
        '
        Me.chkWarrantyStartDateUnknown.Location = New System.Drawing.Point(343, 268)
        Me.chkWarrantyStartDateUnknown.Name = "chkWarrantyStartDateUnknown"
        Me.chkWarrantyStartDateUnknown.Size = New System.Drawing.Size(88, 24)
        Me.chkWarrantyStartDateUnknown.TabIndex = 23
        Me.chkWarrantyStartDateUnknown.Text = "Unknown"
        '
        'dtpWarrantyStartDate
        '
        Me.dtpWarrantyStartDate.Location = New System.Drawing.Point(152, 264)
        Me.dtpWarrantyStartDate.Name = "dtpWarrantyStartDate"
        Me.dtpWarrantyStartDate.Size = New System.Drawing.Size(174, 21)
        Me.dtpWarrantyStartDate.TabIndex = 22
        Me.dtpWarrantyStartDate.Tag = "Asset.WarrantyStartDate"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 268)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 20)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Warranty Start Date"
        '
        'chkLastServicedDateUnknown
        '
        Me.chkLastServicedDateUnknown.Location = New System.Drawing.Point(343, 209)
        Me.chkLastServicedDateUnknown.Name = "chkLastServicedDateUnknown"
        Me.chkLastServicedDateUnknown.Size = New System.Drawing.Size(88, 24)
        Me.chkLastServicedDateUnknown.TabIndex = 17
        Me.chkLastServicedDateUnknown.Text = "Unknown"
        '
        'dtpLastServicedDate
        '
        Me.dtpLastServicedDate.Location = New System.Drawing.Point(152, 210)
        Me.dtpLastServicedDate.Name = "dtpLastServicedDate"
        Me.dtpLastServicedDate.Size = New System.Drawing.Size(174, 21)
        Me.dtpLastServicedDate.TabIndex = 16
        Me.dtpLastServicedDate.Tag = "Asset.LastServicedDate"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Last Serviced Date"
        '
        'chkCertificateLastIssuedUnknown
        '
        Me.chkCertificateLastIssuedUnknown.Location = New System.Drawing.Point(343, 182)
        Me.chkCertificateLastIssuedUnknown.Name = "chkCertificateLastIssuedUnknown"
        Me.chkCertificateLastIssuedUnknown.Size = New System.Drawing.Size(88, 24)
        Me.chkCertificateLastIssuedUnknown.TabIndex = 14
        Me.chkCertificateLastIssuedUnknown.Text = "Unknown"
        '
        'dtpCertificateLastIssued
        '
        Me.dtpCertificateLastIssued.Location = New System.Drawing.Point(152, 183)
        Me.dtpCertificateLastIssued.Name = "dtpCertificateLastIssued"
        Me.dtpCertificateLastIssued.Size = New System.Drawing.Size(174, 21)
        Me.dtpCertificateLastIssued.TabIndex = 13
        Me.dtpCertificateLastIssued.Tag = "Asset.CertificateLastIssued"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Certificate Last Issued"
        '
        'txtBoughtFrom
        '
        Me.txtBoughtFrom.Location = New System.Drawing.Point(152, 318)
        Me.txtBoughtFrom.MaxLength = 100
        Me.txtBoughtFrom.Name = "txtBoughtFrom"
        Me.txtBoughtFrom.Size = New System.Drawing.Size(174, 21)
        Me.txtBoughtFrom.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 321)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Gasway Ref"
        '
        'txtSupplierBy
        '
        Me.txtSupplierBy.Location = New System.Drawing.Point(152, 345)
        Me.txtSupplierBy.MaxLength = 100
        Me.txtSupplierBy.Name = "txtSupplierBy"
        Me.txtSupplierBy.Size = New System.Drawing.Size(174, 21)
        Me.txtSupplierBy.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 348)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Supplied By"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(152, 47)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(174, 21)
        Me.txtLocation.TabIndex = 3
        '
        'chkDateUnknown
        '
        Me.chkDateUnknown.Location = New System.Drawing.Point(343, 235)
        Me.chkDateUnknown.Name = "chkDateUnknown"
        Me.chkDateUnknown.Size = New System.Drawing.Size(88, 24)
        Me.chkDateUnknown.TabIndex = 20
        Me.chkDateUnknown.Text = "Unknown"
        '
        'lblProductID
        '
        Me.lblProductID.Location = New System.Drawing.Point(9, 23)
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Size = New System.Drawing.Size(109, 20)
        Me.lblProductID.TabIndex = 0
        Me.lblProductID.Text = "Product"
        '
        'txtSerialNum
        '
        Me.txtSerialNum.Location = New System.Drawing.Point(152, 101)
        Me.txtSerialNum.MaxLength = 50
        Me.txtSerialNum.Name = "txtSerialNum"
        Me.txtSerialNum.Size = New System.Drawing.Size(174, 21)
        Me.txtSerialNum.TabIndex = 7
        Me.txtSerialNum.Tag = "Asset.SerialNum"
        '
        'lblSerialNum
        '
        Me.lblSerialNum.Location = New System.Drawing.Point(9, 101)
        Me.lblSerialNum.Name = "lblSerialNum"
        Me.lblSerialNum.Size = New System.Drawing.Size(133, 20)
        Me.lblSerialNum.TabIndex = 6
        Me.lblSerialNum.Text = "Serial"
        '
        'dtpDateFitted
        '
        Me.dtpDateFitted.Location = New System.Drawing.Point(152, 237)
        Me.dtpDateFitted.Name = "dtpDateFitted"
        Me.dtpDateFitted.Size = New System.Drawing.Size(174, 21)
        Me.dtpDateFitted.TabIndex = 19
        Me.dtpDateFitted.Tag = "Asset.DateFitted"
        '
        'lblDateFitted
        '
        Me.lblDateFitted.Location = New System.Drawing.Point(9, 239)
        Me.lblDateFitted.Name = "lblDateFitted"
        Me.lblDateFitted.Size = New System.Drawing.Size(125, 20)
        Me.lblDateFitted.TabIndex = 18
        Me.lblDateFitted.Text = "Date Fitted"
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(9, 50)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(117, 20)
        Me.lblLocationID.TabIndex = 2
        Me.lblLocationID.Text = "Location"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(152, 456)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(600, 77)
        Me.txtNotes.TabIndex = 35
        Me.txtNotes.Tag = "Asset.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(9, 456)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(101, 20)
        Me.lblNotes.TabIndex = 34
        Me.lblNotes.Text = "Notes"
        '
        'tabDocuments
        '
        Me.tabDocuments.Controls.Add(Me.pnlDocuments)
        Me.tabDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tabDocuments.Name = "tabDocuments"
        Me.tabDocuments.Size = New System.Drawing.Size(780, 556)
        Me.tabDocuments.TabIndex = 1
        Me.tabDocuments.Text = "Documents"
        '
        'pnlDocuments
        '
        Me.pnlDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDocuments.Location = New System.Drawing.Point(0, 0)
        Me.pnlDocuments.Name = "pnlDocuments"
        Me.pnlDocuments.Size = New System.Drawing.Size(780, 556)
        Me.pnlDocuments.TabIndex = 0
        '
        'tabJobs
        '
        Me.tabJobs.Controls.Add(Me.grpJobs)
        Me.tabJobs.Location = New System.Drawing.Point(4, 22)
        Me.tabJobs.Name = "tabJobs"
        Me.tabJobs.Size = New System.Drawing.Size(780, 556)
        Me.tabJobs.TabIndex = 2
        Me.tabJobs.Text = "Jobs"
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.btnAddJob)
        Me.grpJobs.Controls.Add(Me.dgJobs)
        Me.grpJobs.Location = New System.Drawing.Point(7, 9)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(768, 542)
        Me.grpJobs.TabIndex = 1
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Jobs"
        '
        'btnAddJob
        '
        Me.btnAddJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddJob.Location = New System.Drawing.Point(8, 514)
        Me.btnAddJob.Name = "btnAddJob"
        Me.btnAddJob.Size = New System.Drawing.Size(75, 23)
        Me.btnAddJob.TabIndex = 2
        Me.btnAddJob.Text = "Add Job"
        '
        'dgJobs
        '
        Me.dgJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgJobs.DataMember = ""
        Me.dgJobs.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobs.Location = New System.Drawing.Point(8, 20)
        Me.dgJobs.Name = "dgJobs"
        Me.dgJobs.Size = New System.Drawing.Size(752, 488)
        Me.dgJobs.TabIndex = 1
        '
        'UCAsset
        '
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "UCAsset"
        Me.Size = New System.Drawing.Size(795, 594)
        Me.TabControl1.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.grpAsset.ResumeLayout(False)
        Me.grpAsset.PerformLayout()
        Me.tabDocuments.ResumeLayout(False)
        Me.tabJobs.ResumeLayout(False)
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupJobsDataGrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentAsset
        End Get
    End Property

#End Region

#Region "Properties"

    Private DocumentsControl As UCDocumentsList


    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentAsset As Entity.Assets.Asset
    Public Property CurrentAsset() As Entity.Assets.Asset
        Get
            Return _currentAsset
        End Get
        Set(ByVal Value As Entity.Assets.Asset)
            _currentAsset = Value

            If CurrentAsset Is Nothing Then
                CurrentAsset = New Entity.Assets.Asset
                CurrentAsset.Exists = False
            End If

            If CurrentAsset.Exists Then
                Populate()
                Me.pnlDocuments.Controls.Clear()
                DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblAsset, CurrentAsset.AssetID)
                Me.pnlDocuments.Controls.Add(DocumentsControl)
                Me.grpJobs.Enabled = True
                'Me.btnAddJob.Enabled = True
                PopulateJobs()
            Else
                Me.grpJobs.Enabled = False
            End If
        End Set
    End Property

    Private _LoadProductID As Integer
    'This is used to allow pre-selection of the product on load of the form
    Public Property LoadProductID() As Integer
        Get
            Return _LoadProductID
        End Get
        Set(ByVal Value As Integer)
            _LoadProductID = Value
            If Value > 0 Then
                selectedProductID = _LoadProductID
                Me.btnFindProduct.Enabled = False
            End If
        End Set
    End Property

    Private _LoadSiteID As Integer
    'This is used to allow pre-selection of a Site that isnt set by CurrentSiteID
    Public Property LoadSiteID() As Integer
        Get
            Return _LoadSiteID
        End Get
        Set(ByVal Value As Integer)
            _LoadSiteID = Value
        End Set
    End Property

    Private _jobsTable As DataView
    Public Property JobsDataView() As DataView
        Get
            Return _jobsTable
        End Get
        Set(ByVal Value As DataView)
            _jobsTable = Value
            _jobsTable.Table.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            _jobsTable.AllowNew = False
            _jobsTable.AllowEdit = False
            _jobsTable.AllowDelete = False
            Me.dgJobs.DataSource = JobsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedJobDataRow() As DataRow
        Get
            If Not Me.dgJobs.CurrentRowIndex = -1 Then
                Return JobsDataView(Me.dgJobs.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _selectedProductID As Integer = 0
    Private Property selectedProductID() As Integer
        Get
            Return _selectedProductID
        End Get
        Set(ByVal value As Integer)
            _selectedProductID = value
            If _selectedProductID > 0 Then
                Dim oProduct As Entity.Products.Product = DB.Product.Product_Get(_selectedProductID)
                If Not oProduct Is Nothing Then
                    Me.txtGCNumber.Text = oProduct.Number

                    Dim oType As Entity.PickLists.PickList = DB.Picklists.Get_One_As_Object(oProduct.TypeID)
                    If Not otype Is Nothing Then
                        Me.txtProduct.Text = otype.Name & "-"
                    End If

                    Dim oMake As Entity.PickLists.PickList = DB.Picklists.Get_One_As_Object(oProduct.MakeID)
                    If Not oMake Is Nothing Then
                        Me.txtProduct.Text += oMake.Name & "-"
                    End If

                    Dim oModel As Entity.PickLists.PickList = DB.Picklists.Get_One_As_Object(oProduct.ModelID)
                    If Not oModel Is Nothing Then
                        Me.txtProduct.Text += oModel.Name
                    End If
                Else
                    selectedProductID = 0
                End If
            Else
                Me.txtGCNumber.Text = ""
                Me.txtProduct.Text = ""
            End If
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub SetupJobsDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgJobs)
        Dim tStyle As DataGridTableStyle = Me.dgJobs.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 100
        JobNumber.NullText = ""
        tStyle.GridColumnStyles.Add(JobNumber)

        Dim PONumber As New DataGridLabelColumn
        PONumber.Format = ""
        PONumber.FormatInfo = Nothing
        PONumber.HeaderText = "PO Number"
        PONumber.MappingName = "PONumber"
        PONumber.ReadOnly = True
        PONumber.Width = 100
        PONumber.NullText = ""
        tStyle.GridColumnStyles.Add(PONumber)

        Dim DateCreated As New DataGridLabelColumn
        DateCreated.Format = "dd/MMM/yyyy"
        DateCreated.FormatInfo = Nothing
        DateCreated.HeaderText = "Date Created"
        DateCreated.MappingName = "DateCreated"
        DateCreated.ReadOnly = True
        DateCreated.Width = 100
        DateCreated.NullText = ""
        tStyle.GridColumnStyles.Add(DateCreated)

        Dim Definition As New DataGridLabelColumn
        Definition.Format = ""
        Definition.FormatInfo = Nothing
        Definition.HeaderText = "Definition"
        Definition.MappingName = "JobDefinition"
        Definition.ReadOnly = True
        Definition.Width = 100
        Definition.NullText = ""
        tStyle.GridColumnStyles.Add(Definition)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 100
        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        tStyle.GridColumnStyles.Add(Type)

        Dim JobStatus As New DataGridLabelColumn
        JobStatus.Format = ""
        JobStatus.FormatInfo = Nothing
        JobStatus.HeaderText = "Status"
        JobStatus.MappingName = "JobStatus"
        JobStatus.ReadOnly = True
        JobStatus.Width = 100
        JobStatus.NullText = ""
        tStyle.GridColumnStyles.Add(JobStatus)

        Dim CreatedBy As New DataGridLabelColumn
        CreatedBy.Format = ""
        CreatedBy.FormatInfo = Nothing
        CreatedBy.HeaderText = "Created By"
        CreatedBy.MappingName = "CreatedBy"
        CreatedBy.ReadOnly = True
        CreatedBy.Width = 100
        CreatedBy.NullText = ""
        tStyle.GridColumnStyles.Add(CreatedBy)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblJob.ToString
        Me.dgJobs.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCAsset_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub chkDateUnknown_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateUnknown.CheckedChanged
        If Me.chkDateUnknown.Checked = False Then
            Me.dtpDateFitted.Enabled = True
        Else
            Me.dtpDateFitted.Enabled = False
        End If
    End Sub

    Private Sub chkCertificateLastIssuedUnknown_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCertificateLastIssuedUnknown.CheckedChanged
        If Me.chkCertificateLastIssuedUnknown.Checked = False Then
            Me.dtpCertificateLastIssued.Enabled = True
        Else
            Me.dtpCertificateLastIssued.Enabled = False
        End If
    End Sub

    Private Sub chkLastServiceDateUnknown_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLastServicedDateUnknown.CheckedChanged
        If Me.chkLastServicedDateUnknown.Checked = False Then
            Me.dtpLastServicedDate.Enabled = True
        Else
            Me.dtpLastServicedDate.Enabled = False
        End If
    End Sub

    Private Sub chkWarrantyStartDateUnknown_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWarrantyStartDateUnknown.CheckedChanged
        If Me.chkWarrantyStartDateUnknown.Checked = False Then
            Me.dtpWarrantyStartDate.Enabled = True
            Me.dtpWarrantyEndDate.Enabled = True
        Else
            Me.dtpWarrantyStartDate.Enabled = False
            Me.dtpWarrantyEndDate.Enabled = False
        End If
    End Sub

    Private Sub dgJobs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgJobs.DoubleClick
        If SelectedJobDataRow Is Nothing Then
            Exit Sub
        End If
     

        ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedJobDataRow.Item("JobID"), CurrentAsset.PropertyID, Me})
    End Sub

    Private Sub btnAddJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJob.Click
        Dim currentSite As Entity.Sites.Site = DB.Sites.Get(CurrentAsset.PropertyID)
        Dim customerStatus As Integer = DB.Customer.Customer_Get(currentSite.CustomerID).Status

        If currentSite.OnStop And Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        ElseIf customerStatus = CInt(Entity.Sys.Enums.CustomerStatus.OnHold) And
            Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        ElseIf currentSite.OnStop Then
            If ShowMessage("This property is on stop. Do you want to continue?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        ElseIf customerStatus = CInt(Entity.Sys.Enums.CustomerStatus.OnHold) Then
            If ShowMessage("The customer is on hold. Do you want to continue?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        Else
        End If

        If loggedInUser.UserRegions.Count > 0 Then
            If loggedInUser.UserRegions.Table.Select("RegionID = " & currentSite.RegionID).Length < 1 Then
                Dim msg As String = "You do not have the necessary security permissions." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
        Else
            Dim msg As String = "You do not have the necessary security permissions." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        If (String.IsNullOrEmpty(currentSite.TelephoneNum) And String.IsNullOrEmpty(currentSite.FaxNum)) Or
            String.IsNullOrEmpty(currentSite.EmailAddress) Then
            If ShowMessage("The phone number/email address is missing from site. Do you want to continue?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        ShowForm(GetType(FRMLogCallout), True, New Object() {0, CurrentAsset.PropertyID, Me, CurrentAsset.AssetID})
    End Sub

    Private Sub dtpWarrantyStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpWarrantyStartDate.ValueChanged
        dtpWarrantyEndDate.Value = dtpWarrantyStartDate.Value.AddYears(1).AddDays(-1)
    End Sub

    Private Sub btnFindProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindProduct.Click
        selectedProductID = FindRecord(Entity.Sys.Enums.TableNames.tblProduct)
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateJobs()
        JobsDataView = DB.Job.Job_GetAll_For_Asset(CurrentAsset.AssetID)
    End Sub

    Public Sub DisableControls()
        If Not loggedInUser.HasAccessToModule(
            Entity.Sys.Enums.SecuritySystemModules.Compliance) Then
            txtLocation.Enabled = False
            txtSerialNum.Enabled = False

            Me.dtpDateFitted.Enabled = False
            Me.chkDateUnknown.Enabled = False

            Me.dtpCertificateLastIssued.Enabled = False
            Me.chkCertificateLastIssuedUnknown.Enabled = False

            Me.dtpLastServicedDate.Enabled = False
            Me.chkLastServicedDateUnknown.Enabled = False

            Me.dtpWarrantyStartDate.Enabled = False
            Me.chkWarrantyStartDateUnknown.Enabled = False

            Me.dtpWarrantyEndDate.Enabled = False
            Me.chkWarrantyStartDateUnknown.Enabled = False
        End If
    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate

        If ControlLoading = False Then

            ControlLoading = True
            If Not ID = 0 Then
                CurrentAsset = DB.Asset.Asset_Get(ID)
            End If

            selectedProductID = CurrentAsset.ProductID
            btnFindProduct.Enabled = False
            Me.txtSerialNum.Text = CurrentAsset.SerialNum

            If CurrentAsset.DateFitted = Date.MinValue Then
                Me.chkDateUnknown.Checked = True
            Else
                Me.dtpDateFitted.Value = CurrentAsset.DateFitted
            End If

            If CurrentAsset.CertificateLastIssued = Date.MinValue Then
                Me.chkCertificateLastIssuedUnknown.Checked = True
            Else
                Me.dtpCertificateLastIssued.Value = CurrentAsset.CertificateLastIssued
            End If

            If CurrentAsset.LastServicedDate = Date.MinValue Then
                Me.chkLastServicedDateUnknown.Checked = True
            Else
                Me.dtpLastServicedDate.Value = CurrentAsset.LastServicedDate
            End If

            If CurrentAsset.WarrantyStartDate = Date.MinValue Then
                Me.chkWarrantyStartDateUnknown.Checked = True
            Else
                Me.dtpWarrantyStartDate.Value = CurrentAsset.WarrantyStartDate
            End If

            If CurrentAsset.WarrantyEndDate = Date.MinValue Then
                Me.chkWarrantyStartDateUnknown.Checked = True
            Else
                Me.dtpWarrantyEndDate.Value = CurrentAsset.WarrantyEndDate
            End If

            Me.txtBoughtFrom.Text = CurrentAsset.BoughtFrom
            Me.txtSupplierBy.Text = CurrentAsset.SuppliedBy
            Me.txtLocation.Text = CurrentAsset.Location
            Me.txtNotes.Text = CurrentAsset.Notes
            Me.txtGCNumber.Text = CurrentAsset.GCNumber
            Me.txtYearOfManufacture.Text = CurrentAsset.YearOfManufacture
            Me.txtApproximateValue.Text = CurrentAsset.ApproximateValue
            Me.chkActive.Checked = CurrentAsset.Active
            Me.chkTenantsAppliance.Checked = CurrentAsset.TenantsAppliance

            Combo.SetSelectedComboItem_By_Value(Me.cboGasType, CurrentAsset.GasTypeID)
            Combo.SetSelectedComboItem_By_Value(Me.cboFlueType, CurrentAsset.FlueTypeID)
            txtBoughtFrom.Enabled = False
            txtSupplierBy.Enabled = False
            txtYearOfManufacture.Enabled = False
            txtApproximateValue.Enabled = False
            cboFlueType.Enabled = False
            cboGasType.Enabled = False
            DisableControls()
            AddChangeHandlers(Me)
            ControlChanged = False
            ControlLoading = False
        End If

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentAsset.IgnoreExceptionsOnSetMethods = True

            CurrentAsset.SetProductID = selectedProductID
            CurrentAsset.SetSerialNum = Me.txtSerialNum.Text.Trim
            If Me.chkDateUnknown.Checked = True Then
                CurrentAsset.DateFitted = Date.MinValue
            Else
                CurrentAsset.DateFitted = Me.dtpDateFitted.Value
            End If

            If Me.chkCertificateLastIssuedUnknown.Checked = True Then
                CurrentAsset.CertificateLastIssued = Date.MinValue
            Else
                CurrentAsset.CertificateLastIssued = Me.dtpCertificateLastIssued.Value
            End If

            If Me.chkLastServicedDateUnknown.Checked = True Then
                CurrentAsset.LastServicedDate = Date.MinValue
            Else
                CurrentAsset.LastServicedDate = Me.dtpLastServicedDate.Value
            End If

            If Me.chkWarrantyStartDateUnknown.Checked = True Then
                CurrentAsset.WarrantyStartDate = Date.MinValue
                CurrentAsset.WarrantyEndDate = Date.MinValue
            Else
                CurrentAsset.WarrantyStartDate = Me.dtpWarrantyStartDate.Value
                CurrentAsset.WarrantyEndDate = Me.dtpWarrantyEndDate.Value
            End If

            CurrentAsset.SetBoughtFrom = Me.txtBoughtFrom.Text.Trim
            CurrentAsset.SetSuppliedBy = Me.txtSupplierBy.Text.Trim
            CurrentAsset.SetLocation = Me.txtLocation.Text.Trim
            CurrentAsset.SetNotes = Me.txtNotes.Text.Trim
            CurrentAsset.SetGCNumber = Me.txtGCNumber.Text.Trim
            CurrentAsset.SetYearOfManufacture = Me.txtYearOfManufacture.Text.Trim
            If Me.txtApproximateValue.Text.Trim.Length = 0 Then
                CurrentAsset.SetApproximateValue = 0
            Else
                CurrentAsset.SetApproximateValue = Me.txtApproximateValue.Text.Trim
            End If
            CurrentAsset.SetGasTypeID = Combo.GetSelectedItemValue(Me.cboGasType)
            CurrentAsset.SetFlueTypeID = Combo.GetSelectedItemValue(Me.cboFlueType)
            CurrentAsset.SetActive = Me.chkActive.Checked
            CurrentAsset.SetTenantsAppliance = Me.chkTenantsAppliance.Checked

            Dim cV As New Entity.Assets.AssetValidator
            cV.Validate(CurrentAsset)

            If CurrentAsset.Exists Then
                DB.Asset.Update(CurrentAsset)
            Else
                If LoadSiteID > 0 Then
                    CurrentAsset.SetPropertyID = LoadSiteID
                Else
                    CurrentAsset.SetPropertyID = CurrentPropertyID
                End If
                CurrentAsset = DB.Asset.Insert(CurrentAsset)
            End If

            If Not LoadSiteID > 0 Then
                If CurrentPropertyID = 0 Then
                    RaiseEvent RecordsChanged(DB.Asset.Asset_GetAll(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Asset, True, False, "")
                Else
                    RaiseEvent RecordsChanged(DB.Asset.Asset_GetForSite(CurrentPropertyID), Entity.Sys.Enums.PageViewing.Asset, True, False, "")
                End If
                RaiseEvent StateChanged(CurrentAsset.AssetID)
                MainForm.RefreshEntity(CurrentAsset.AssetID)
            End If

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

