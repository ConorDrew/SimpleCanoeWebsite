Public Class UCContractOption3Site : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboInvoiceFrequencyID, DynamicDataTables.InvoiceFrequency, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboVisitFrequencyID, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

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

    Friend WithEvents grpContractOption3Site As System.Windows.Forms.GroupBox
    Friend WithEvents lblSiteID As System.Windows.Forms.Label
    Friend WithEvents txtContractSiteReference As System.Windows.Forms.TextBox
    Friend WithEvents lblContractSiteReference As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpFirstVisitDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFirstVisitDate As System.Windows.Forms.Label
    Friend WithEvents cboVisitFrequencyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisitFrequencyID As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceFrequencyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblInvoiceFrequencyID As System.Windows.Forms.Label
    Friend WithEvents txtSitePrice As System.Windows.Forms.TextBox
    Friend WithEvents lblSitePrice As System.Windows.Forms.Label
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents gpbAssets As System.Windows.Forms.GroupBox
    Friend WithEvents dgAssets As System.Windows.Forms.DataGrid
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents btnRefreshGrid As System.Windows.Forms.Button
    Friend WithEvents gpbPPM As System.Windows.Forms.GroupBox
    Friend WithEvents dgPPMVisits As System.Windows.Forms.DataGrid
    Friend WithEvents gpbInvoiceAddress As System.Windows.Forms.GroupBox
    Friend WithEvents dgInvoiceAddress As System.Windows.Forms.DataGrid
    Friend WithEvents dtpFirstInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpContractOption3Site = New System.Windows.Forms.GroupBox
        Me.gpbPPM = New System.Windows.Forms.GroupBox
        Me.dgPPMVisits = New System.Windows.Forms.DataGrid
        Me.btnRefreshGrid = New System.Windows.Forms.Button
        Me.lblWarning = New System.Windows.Forms.Label
        Me.gpbAssets = New System.Windows.Forms.GroupBox
        Me.dgAssets = New System.Windows.Forms.DataGrid
        Me.txtSite = New System.Windows.Forms.TextBox
        Me.lblSiteID = New System.Windows.Forms.Label
        Me.txtContractSiteReference = New System.Windows.Forms.TextBox
        Me.lblContractSiteReference = New System.Windows.Forms.Label
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.lblStartDate = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.lblEndDate = New System.Windows.Forms.Label
        Me.dtpFirstVisitDate = New System.Windows.Forms.DateTimePicker
        Me.lblFirstVisitDate = New System.Windows.Forms.Label
        Me.cboVisitFrequencyID = New System.Windows.Forms.ComboBox
        Me.lblVisitFrequencyID = New System.Windows.Forms.Label
        Me.cboInvoiceFrequencyID = New System.Windows.Forms.ComboBox
        Me.lblInvoiceFrequencyID = New System.Windows.Forms.Label
        Me.txtSitePrice = New System.Windows.Forms.TextBox
        Me.lblSitePrice = New System.Windows.Forms.Label
        Me.gpbInvoiceAddress = New System.Windows.Forms.GroupBox
        Me.dgInvoiceAddress = New System.Windows.Forms.DataGrid
        Me.dtpFirstInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpContractOption3Site.SuspendLayout()
        Me.gpbPPM.SuspendLayout()
        CType(Me.dgPPMVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbAssets.SuspendLayout()
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbInvoiceAddress.SuspendLayout()
        CType(Me.dgInvoiceAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpContractOption3Site
        '
        Me.grpContractOption3Site.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContractOption3Site.Controls.Add(Me.gpbInvoiceAddress)
        Me.grpContractOption3Site.Controls.Add(Me.dtpFirstInvoiceDate)
        Me.grpContractOption3Site.Controls.Add(Me.Label1)
        Me.grpContractOption3Site.Controls.Add(Me.gpbPPM)
        Me.grpContractOption3Site.Controls.Add(Me.btnRefreshGrid)
        Me.grpContractOption3Site.Controls.Add(Me.lblWarning)
        Me.grpContractOption3Site.Controls.Add(Me.gpbAssets)
        Me.grpContractOption3Site.Controls.Add(Me.txtSite)
        Me.grpContractOption3Site.Controls.Add(Me.lblSiteID)
        Me.grpContractOption3Site.Controls.Add(Me.txtContractSiteReference)
        Me.grpContractOption3Site.Controls.Add(Me.lblContractSiteReference)
        Me.grpContractOption3Site.Controls.Add(Me.dtpStartDate)
        Me.grpContractOption3Site.Controls.Add(Me.lblStartDate)
        Me.grpContractOption3Site.Controls.Add(Me.dtpEndDate)
        Me.grpContractOption3Site.Controls.Add(Me.lblEndDate)
        Me.grpContractOption3Site.Controls.Add(Me.dtpFirstVisitDate)
        Me.grpContractOption3Site.Controls.Add(Me.lblFirstVisitDate)
        Me.grpContractOption3Site.Controls.Add(Me.cboVisitFrequencyID)
        Me.grpContractOption3Site.Controls.Add(Me.lblVisitFrequencyID)
        Me.grpContractOption3Site.Controls.Add(Me.cboInvoiceFrequencyID)
        Me.grpContractOption3Site.Controls.Add(Me.lblInvoiceFrequencyID)
        Me.grpContractOption3Site.Controls.Add(Me.txtSitePrice)
        Me.grpContractOption3Site.Controls.Add(Me.lblSitePrice)
        Me.grpContractOption3Site.Location = New System.Drawing.Point(8, 8)
        Me.grpContractOption3Site.Name = "grpContractOption3Site"
        Me.grpContractOption3Site.Size = New System.Drawing.Size(979, 594)
        Me.grpContractOption3Site.TabIndex = 1
        Me.grpContractOption3Site.TabStop = False
        Me.grpContractOption3Site.Text = "Main Details"
        '
        'gpbPPM
        '
        Me.gpbPPM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbPPM.Controls.Add(Me.dgPPMVisits)

        Me.gpbPPM.Location = New System.Drawing.Point(9, 449)
        Me.gpbPPM.Name = "gpbPPM"
        Me.gpbPPM.Size = New System.Drawing.Size(963, 139)
        Me.gpbPPM.TabIndex = 12
        Me.gpbPPM.TabStop = False
        Me.gpbPPM.Text = "Scheduled Visit"
        '
        'dgPPMVisits
        '
        Me.dgPPMVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPPMVisits.DataMember = ""
        Me.dgPPMVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPPMVisits.Location = New System.Drawing.Point(10, 19)
        Me.dgPPMVisits.Name = "dgPPMVisits"
        Me.dgPPMVisits.Size = New System.Drawing.Size(947, 112)
        Me.dgPPMVisits.TabIndex = 0
        '
        'btnRefreshGrid
        '
        Me.btnRefreshGrid.UseVisualStyleBackColor = True
        Me.btnRefreshGrid.Location = New System.Drawing.Point(424, 120)
        Me.btnRefreshGrid.Name = "btnRefreshGrid"
        Me.btnRefreshGrid.Size = New System.Drawing.Size(200, 23)
        Me.btnRefreshGrid.TabIndex = 7
        Me.btnRefreshGrid.Text = "Load Assets Scheduled"
        '
        'lblWarning
        '
        Me.lblWarning.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Red
        Me.lblWarning.Location = New System.Drawing.Point(328, 144)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(296, 16)
        Me.lblWarning.TabIndex = 20
        Me.lblWarning.Text = "! First Date must be between Start &&End Date"
        Me.lblWarning.Visible = False
        '
        'gpbAssets
        '
        Me.gpbAssets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbAssets.Controls.Add(Me.dgAssets)
        Me.gpbAssets.Location = New System.Drawing.Point(9, 168)
        Me.gpbAssets.Name = "gpbAssets"
        Me.gpbAssets.Size = New System.Drawing.Size(963, 272)
        Me.gpbAssets.TabIndex = 11
        Me.gpbAssets.TabStop = False
        Me.gpbAssets.Text = "Assets - Enter duration in hours for each month"
        '
        'dgAssets
        '
        Me.dgAssets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAssets.DataMember = ""
        Me.dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAssets.Location = New System.Drawing.Point(10, 25)
        Me.dgAssets.Name = "dgAssets"
        Me.dgAssets.Size = New System.Drawing.Size(947, 239)
        Me.dgAssets.TabIndex = 0
        '
        'txtSite
        '
        Me.txtSite.Location = New System.Drawing.Point(120, 24)
        Me.txtSite.Multiline = True
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSite.Size = New System.Drawing.Size(200, 68)
        Me.txtSite.TabIndex = 0
        Me.txtSite.Text = ""
        '
        'lblSiteID
        '
        Me.lblSiteID.Location = New System.Drawing.Point(9, 25)
        Me.lblSiteID.Name = "lblSiteID"
        Me.lblSiteID.Size = New System.Drawing.Size(139, 20)
        Me.lblSiteID.TabIndex = 13
        Me.lblSiteID.Text = "Property"
        '
        'txtContractSiteReference
        '
        Me.txtContractSiteReference.Location = New System.Drawing.Point(120, 96)
        Me.txtContractSiteReference.MaxLength = 100
        Me.txtContractSiteReference.Name = "txtContractSiteReference"
        Me.txtContractSiteReference.ReadOnly = True
        Me.txtContractSiteReference.Size = New System.Drawing.Size(200, 21)
        Me.txtContractSiteReference.TabIndex = 1
        Me.txtContractSiteReference.Tag = "ContractOption3Site.ContractSiteReference"
        Me.txtContractSiteReference.Text = ""
        '
        'lblContractSiteReference
        '
        Me.lblContractSiteReference.Location = New System.Drawing.Point(10, 96)
        Me.lblContractSiteReference.Name = "lblContractSiteReference"
        Me.lblContractSiteReference.Size = New System.Drawing.Size(139, 20)
        Me.lblContractSiteReference.TabIndex = 14
        Me.lblContractSiteReference.Text = "Contract Property Ref"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(424, 24)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.TabIndex = 3
        Me.dtpStartDate.Tag = "ContractOption3Site.StartDate"
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(328, 25)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(96, 20)
        Me.lblStartDate.TabIndex = 16
        Me.lblStartDate.Text = "Start Date"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(424, 48)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.TabIndex = 4
        Me.dtpEndDate.Tag = "ContractOption3Site.EndDate"
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(328, 49)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(96, 20)
        Me.lblEndDate.TabIndex = 17
        Me.lblEndDate.Text = "End Date"
        '
        'dtpFirstVisitDate
        '
        Me.dtpFirstVisitDate.Location = New System.Drawing.Point(424, 72)
        Me.dtpFirstVisitDate.Name = "dtpFirstVisitDate"
        Me.dtpFirstVisitDate.TabIndex = 5
        Me.dtpFirstVisitDate.Tag = "ContractOption3Site.FirstVisitDate"
        '
        'lblFirstVisitDate
        '
        Me.lblFirstVisitDate.Location = New System.Drawing.Point(328, 72)
        Me.lblFirstVisitDate.Name = "lblFirstVisitDate"
        Me.lblFirstVisitDate.Size = New System.Drawing.Size(96, 20)
        Me.lblFirstVisitDate.TabIndex = 18
        Me.lblFirstVisitDate.Text = "First Visit Date"
        '
        'cboVisitFrequencyID
        '
        Me.cboVisitFrequencyID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVisitFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitFrequencyID.Location = New System.Drawing.Point(424, 96)
        Me.cboVisitFrequencyID.Name = "cboVisitFrequencyID"
        Me.cboVisitFrequencyID.Size = New System.Drawing.Size(200, 21)
        Me.cboVisitFrequencyID.TabIndex = 6
        Me.cboVisitFrequencyID.Tag = "ContractOption3Site.VisitFrequencyID"
        '
        'lblVisitFrequencyID
        '
        Me.lblVisitFrequencyID.Location = New System.Drawing.Point(328, 96)
        Me.lblVisitFrequencyID.Name = "lblVisitFrequencyID"
        Me.lblVisitFrequencyID.Size = New System.Drawing.Size(96, 20)
        Me.lblVisitFrequencyID.TabIndex = 19
        Me.lblVisitFrequencyID.Text = "Visit Frequency"
        '
        'cboInvoiceFrequencyID
        '
        Me.cboInvoiceFrequencyID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboInvoiceFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInvoiceFrequencyID.Location = New System.Drawing.Point(768, 24)
        Me.cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID"
        Me.cboInvoiceFrequencyID.Size = New System.Drawing.Size(200, 21)
        Me.cboInvoiceFrequencyID.TabIndex = 8
        Me.cboInvoiceFrequencyID.Tag = "ContractOption3Site.InvoiceFrequencyID"
        '
        'lblInvoiceFrequencyID
        '
        Me.lblInvoiceFrequencyID.Location = New System.Drawing.Point(632, 24)
        Me.lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID"
        Me.lblInvoiceFrequencyID.Size = New System.Drawing.Size(112, 20)
        Me.lblInvoiceFrequencyID.TabIndex = 21
        Me.lblInvoiceFrequencyID.Text = "Invoice Frequency "
        '
        'txtSitePrice
        '
        Me.txtSitePrice.Location = New System.Drawing.Point(120, 121)
        Me.txtSitePrice.MaxLength = 9
        Me.txtSitePrice.Name = "txtSitePrice"
        Me.txtSitePrice.Size = New System.Drawing.Size(200, 21)
        Me.txtSitePrice.TabIndex = 2
        Me.txtSitePrice.Tag = "ContractOption3Site.SitePrice"
        Me.txtSitePrice.Text = ""
        '
        'lblSitePrice
        '
        Me.lblSitePrice.Location = New System.Drawing.Point(10, 121)
        Me.lblSitePrice.Name = "lblSitePrice"
        Me.lblSitePrice.Size = New System.Drawing.Size(112, 20)
        Me.lblSitePrice.TabIndex = 15
        Me.lblSitePrice.Text = "Property Price"
        '
        'gpbInvoiceAddress
        '
        Me.gpbInvoiceAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbInvoiceAddress.Controls.Add(Me.dgInvoiceAddress)
        Me.gpbInvoiceAddress.Location = New System.Drawing.Point(636, 72)
        Me.gpbInvoiceAddress.Name = "gpbInvoiceAddress"
        Me.gpbInvoiceAddress.Size = New System.Drawing.Size(336, 96)
        Me.gpbInvoiceAddress.TabIndex = 10
        Me.gpbInvoiceAddress.TabStop = False
        Me.gpbInvoiceAddress.Text = "Invoice Address"
        '
        'dgInvoiceAddress
        '
        Me.dgInvoiceAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgInvoiceAddress.DataMember = ""
        Me.dgInvoiceAddress.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgInvoiceAddress.Location = New System.Drawing.Point(8, 16)
        Me.dgInvoiceAddress.Name = "dgInvoiceAddress"
        Me.dgInvoiceAddress.Size = New System.Drawing.Size(320, 72)
        Me.dgInvoiceAddress.TabIndex = 0
        '
        'dtpFirstInvoiceDate
        '
        Me.dtpFirstInvoiceDate.Location = New System.Drawing.Point(768, 48)
        Me.dtpFirstInvoiceDate.Name = "dtpFirstInvoiceDate"
        Me.dtpFirstInvoiceDate.TabIndex = 9
        Me.dtpFirstInvoiceDate.Tag = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(632, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 20)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "First Invoice Date"
        '
        'UCContractOption3Site
        '
        Me.Controls.Add(Me.grpContractOption3Site)
        Me.Name = "UCContractOption3Site"
        Me.Size = New System.Drawing.Size(994, 616)
        Me.grpContractOption3Site.ResumeLayout(False)
        Me.gpbPPM.ResumeLayout(False)
        CType(Me.dgPPMVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbAssets.ResumeLayout(False)
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbInvoiceAddress.ResumeLayout(False)
        CType(Me.dgInvoiceAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentContractOption3Site
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal ExtraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _InvoiceInserted As Boolean = False
    Private Property InvoiceInserted() As Boolean
        Get
            Return _InvoiceInserted
        End Get
        Set(ByVal Value As Boolean)
            _InvoiceInserted = Value
        End Set
    End Property

    Private _currentContractOption3Site As Entity.ContractOption3Sites.ContractOption3Site
    Public Property CurrentContractOption3Site() As Entity.ContractOption3Sites.ContractOption3Site
        Get
            Return _currentContractOption3Site
        End Get
        Set(ByVal Value As Entity.ContractOption3Sites.ContractOption3Site)
            _currentContractOption3Site = Value

            If CurrentContractOption3Site Is Nothing Then
                CurrentContractOption3Site = New Entity.ContractOption3Sites.ContractOption3Site
                CurrentContractOption3Site.Exists = False
            End If

            If CurrentContractOption3Site.Exists Then
                Populate()
                Dim site As New Entity.Sites.Site
                site = DB.Sites.Get(CurrentContractOption3Site.PropertyID)
                txtSite.Text = Replace(Replace(Replace( _
                                        site.Address1 & ", " & site.Address2 & ", " & site.Address3 & ", " & site.Address4 & ", " & site.Address5 & ", " & site.Postcode & "." _
                                        , ", , ", ", "), ", , ", ", "), ", , ", ", ")

                PPMSchedule = DB.ContractOption3SitePPMVisit.ContractOption3SitePPMVisit_GetAll_ContractSiteID(CurrentContractOption3Site.ContractSiteID)
          

                'LETS CHECK IF WE HAD AN INVOICED ADDRESS ID ALREADY BEFORE THIS UPDATE
                If CurrentContractOption3Site.InvoiceAddressID > 0 Then
                    InvoiceInserted = True
                End If

                If InvoiceInserted Then
                    dtpFirstInvoiceDate.Enabled = False
                    cboInvoiceFrequencyID.Enabled = False
                    gpbInvoiceAddress.Enabled = False
                End If
                'Load Invoice Addresses
                InvoiceAddresses = DB.InvoiceAddress.InvoiceAddress_Get_SiteID(CurrentContractOption3Site.PropertyID)

                If CurrentContractOption3Site.InvoiceAddressID > 0 Then
                    Dim c As Integer = 0
                    For Each dr As DataRow In InvoiceAddresses.Table.Rows
                        If dr("AddressID") = CurrentContractOption3Site.InvoiceAddressID And _
                            dr("AddressTypeID") = CurrentContractOption3Site.InvoiceAddressTypeID Then
                            dgInvoiceAddress.CurrentRowIndex = c
                            Exit For
                        End If
                        c += 1
                    Next dr
                Else
                    dgInvoiceAddress.CurrentRowIndex = 0
                End If


                dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex)
            End If
        End Set
    End Property

    Private _Assets As DataView
    Private Property Assets() As DataView
        Get
            Return _Assets
        End Get
        Set(ByVal Value As DataView)
            _Assets = Value
            _Assets.AllowNew = False
            _Assets.AllowEdit = True
            _Assets.AllowDelete = False
            _Assets.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString

            dgAssets.DataSource = _Assets
        End Set
    End Property

    Private _NumOfMonths As Integer = 0
    Private Property NumOfMonths() As Integer
        Get
            Return _NumOfMonths
        End Get
        Set(ByVal Value As Integer)
            _NumOfMonths = Value
        End Set
    End Property

    Private _Visits As New ArrayList
    Private Property Visits() As ArrayList
        Get
            Return _Visits
        End Get
        Set(ByVal Value As ArrayList)
            _Visits = Value
        End Set
    End Property

    Private _AssetDurations As New DataView
    Private Property AssetDurations() As DataView
        Get
            Return _AssetDurations
        End Get
        Set(ByVal Value As DataView)
            _AssetDurations = Value
        End Set
    End Property

    Private _PPMSchedule As New DataView
    Private Property PPMSchedule() As DataView
        Get
            Return _PPMSchedule
        End Get
        Set(ByVal Value As DataView)
            _PPMSchedule = Value
            _PPMSchedule.AllowNew = False
            _PPMSchedule.AllowEdit = True
            _PPMSchedule.AllowDelete = False
            _PPMSchedule.Table.TableName = Entity.Sys.Enums.TableNames.tblContractOption3SitePPMVisit.ToString

            dgPPMVisits.DataSource = PPMSchedule
        End Set
    End Property


    Private _InvoiceAddresses As DataView
    Private Property InvoiceAddresses() As DataView
        Get
            Return _InvoiceAddresses
        End Get
        Set(ByVal Value As DataView)
            _InvoiceAddresses = Value
            _InvoiceAddresses.AllowDelete = False
            _InvoiceAddresses.AllowEdit = False
            _InvoiceAddresses.AllowNew = False
            _InvoiceAddresses.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
            dgInvoiceAddress.DataSource = InvoiceAddresses
        End Set
    End Property

    Private ReadOnly Property SelectedInvoiceAddressesDataRow() As DataRow
        Get
            If Not Me.dgInvoiceAddress.CurrentRowIndex = -1 Then
                Return InvoiceAddresses(Me.dgInvoiceAddress.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property
#End Region

#Region "SetUp"

    Public Sub SetupAssetsDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgAssets)
        Dim tStyle As DataGridTableStyle = Me.dgAssets.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgAssets.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Product As New DataGridLabelColumn
        Product.Format = ""
        Product.FormatInfo = Nothing
        Product.HeaderText = "Product"
        Product.MappingName = "Product"
        Product.ReadOnly = True
        Product.Width = 150
        Product.NullText = ""
        tStyle.GridColumnStyles.Add(Product)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 90
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim SerialNum As New DataGridLabelColumn
        SerialNum.Format = ""
        SerialNum.FormatInfo = Nothing
        SerialNum.HeaderText = "Serial Number"
        SerialNum.MappingName = "SerialNum"
        SerialNum.ReadOnly = True
        SerialNum.Width = 90
        SerialNum.NullText = ""
        tStyle.GridColumnStyles.Add(SerialNum)

        Dim numOfMonths As Integer = 0
        numOfMonths = Math.Ceiling(DateDiff(DateInterval.Month, dtpStartDate.Value, dtpEndDate.Value))

        For i As Integer = 0 To numOfMonths
            Dim dglc As New Contract3AssetsColourColumn
            dglc.HeaderText = Format(dtpStartDate.Value.AddMonths(i), "MMM yy")
            dglc.MappingName = Format(dtpStartDate.Value.AddMonths(i), "MMM yy")
            dglc.ReadOnly = False
            dglc.Width = 50
            dglc.NullText = "-"
            tStyle.GridColumnStyles.Add(dglc)
        Next

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblAsset.ToString
        Me.dgAssets.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupPPMDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgPPMVisits)
        Dim tStyle As DataGridTableStyle = Me.dgPPMVisits.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim EstimatedVisitDate As New DataGridLabelColumn
        EstimatedVisitDate.Format = "dd/MM/yyyy"
        EstimatedVisitDate.FormatInfo = Nothing
        EstimatedVisitDate.HeaderText = "Approx. VisitDate"
        EstimatedVisitDate.MappingName = "VisitDate"
        EstimatedVisitDate.ReadOnly = True
        EstimatedVisitDate.Width = 220
        EstimatedVisitDate.NullText = ""
        tStyle.GridColumnStyles.Add(EstimatedVisitDate)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 220
        JobNumber.NullText = ""
        tStyle.GridColumnStyles.Add(JobNumber)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yyyy"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Visit Date"
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 220
        StartDateTime.NullText = "Not Set"
        tStyle.GridColumnStyles.Add(StartDateTime)

        Dim Engineer As New DataGridLabelColumn
        Engineer.Format = ""
        Engineer.FormatInfo = Nothing
        Engineer.HeaderText = "Engineer"
        Engineer.MappingName = "Name"
        Engineer.ReadOnly = True
        Engineer.Width = 220
        Engineer.NullText = "N/A"
        tStyle.GridColumnStyles.Add(Engineer)

       



        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractOption3SitePPMVisit.ToString
        Me.dgPPMVisits.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupInvoiceAddressDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgInvoiceAddress)
        Dim tStyle As DataGridTableStyle = Me.dgInvoiceAddress.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False
        dgInvoiceAddress.ReadOnly = False

        Dim AddressType As New DataGridLabelColumn
        AddressType.Format = ""
        AddressType.FormatInfo = Nothing
        AddressType.HeaderText = "Address Type"
        AddressType.MappingName = "AddressType"
        AddressType.ReadOnly = True
        AddressType.Width = 95
        AddressType.NullText = ""
        tStyle.GridColumnStyles.Add(AddressType)

        Dim Address1 As New DataGridLabelColumn
        Address1.Format = ""
        Address1.FormatInfo = Nothing
        Address1.HeaderText = "Address 1"
        Address1.MappingName = "Address1"
        Address1.ReadOnly = True
        Address1.Width = 75
        Address1.NullText = ""
        tStyle.GridColumnStyles.Add(Address1)

        Dim Address2 As New DataGridLabelColumn
        Address2.Format = ""
        Address2.FormatInfo = Nothing
        Address2.HeaderText = "Address 2"
        Address2.MappingName = "Address2"
        Address2.ReadOnly = True
        Address2.Width = 75
        Address2.NullText = ""
        tStyle.GridColumnStyles.Add(Address2)

        Dim Address3 As New DataGridLabelColumn
        Address3.Format = ""
        Address3.FormatInfo = Nothing
        Address3.HeaderText = "Address 3"
        Address3.MappingName = "Address3"
        Address3.ReadOnly = True
        Address3.Width = 75
        Address3.NullText = ""
        tStyle.GridColumnStyles.Add(Address3)

        Dim Address4 As New DataGridLabelColumn
        Address4.Format = ""
        Address4.FormatInfo = Nothing
        Address4.HeaderText = "Address 4"
        Address4.MappingName = "Address4"
        Address4.ReadOnly = True
        Address4.Width = 75
        Address4.NullText = ""
        tStyle.GridColumnStyles.Add(Address4)

        Dim Address5 As New DataGridLabelColumn
        Address5.Format = ""
        Address5.FormatInfo = Nothing
        Address5.HeaderText = "Address 5"
        Address5.MappingName = "Address5"
        Address5.ReadOnly = True
        Address5.Width = 75
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


        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
        Me.dgInvoiceAddress.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCContractOption3Site_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
        SetupAssetsDataGrid()
        SetupPPMDataGrid()
    End Sub

    Private Sub dtpStartDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged
        ClearAssetsGrid()
    End Sub

    Private Sub dtpEndDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEndDate.ValueChanged
        ClearAssetsGrid()
    End Sub

    Private Sub dtpFirstVisitDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFirstVisitDate.ValueChanged
        ClearAssetsGrid()
    End Sub

    Private Sub cboVisitFrequencyID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVisitFrequencyID.SelectedIndexChanged
        ClearAssetsGrid()
    End Sub

    Private Sub btnRefreshGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshGrid.Click
        RefreshAssetsGrid()
    End Sub

    Private Sub dgInvoiceAddress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInvoiceAddress.Click
        dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex)
    End Sub

#End Region

#Region "Functions"

    Private Sub ClearAssetsGrid()
        If Not CurrentContractOption3Site Is Nothing Then
            Assets = DB.Asset.Asset_GetForSite(CurrentContractOption3Site.PropertyID)

        End If

        If dtpFirstVisitDate.Value >= dtpStartDate.Value And _
                   dtpFirstVisitDate.Value <= dtpEndDate.Value Then
            lblWarning.Visible = False
        Else
            lblWarning.Visible = True
        End If

    End Sub

    Private Sub RefreshAssetsGrid()
        Me.Cursor = Cursors.WaitCursor
        Dim estVisitDate As DateTime = Nothing
        Dim numOfVisits As Integer = 0
        Dim visitFreqInMonths As Integer = 0

        If Not CurrentContractOption3Site Is Nothing Then
            If Not Assets Is Nothing Then
                NumOfMonths = Math.Ceiling(DateDiff(DateInterval.Month, dtpStartDate.Value, dtpEndDate.Value))

                ClearAssetsGrid()
                Visits = New ArrayList

                For i As Integer = 0 To NumOfMonths
                    Assets.Table.Columns.Add(Format(dtpStartDate.Value.AddMonths(i), "MMM yy"))
                Next

                If Combo.GetSelectedItemValue(cboVisitFrequencyID) > 0 Then
                    If dtpFirstVisitDate.Value.Date >= dtpStartDate.Value.Date And _
                        dtpFirstVisitDate.Value.Date <= dtpEndDate.Value.Date Then
                        lblWarning.Visible = False

                        'How Visit Should happen in days
                        numOfVisits = 0
                        '   visitFreqInDays = 0
                        visitFreqInMonths = 0
                        Select Case CType(Combo.GetSelectedItemValue(cboVisitFrequencyID), Entity.Sys.Enums.VisitFrequency)
                            Case Entity.Sys.Enums.VisitFrequency.Annually
                                'visitFreqInDays = 365
                                visitFreqInMonths = 12
                            Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                                'visitFreqInDays = 182
                                visitFreqInMonths = 6
                            Case Entity.Sys.Enums.VisitFrequency.Monthly
                                ' visitFreqInDays = 30
                                visitFreqInMonths = 1
                            Case Entity.Sys.Enums.VisitFrequency.Quarterly
                                'visitFreqInDays = 91
                                visitFreqInMonths = 3

                        End Select

                        '  numOfVisits = Math.Floor(Math.Ceiling(DateDiff(DateInterval.Day, dtpStartDate.Value, dtpEndDate.Value)) / visitFreqInDays)
                        numOfVisits = Math.Ceiling(DateDiff(DateInterval.Month, dtpStartDate.Value, dtpEndDate.Value) / visitFreqInMonths)
                        If numOfVisits = 0 Then
                            numOfVisits = 1
                        End If
                        estVisitDate = dtpFirstVisitDate.Value.Date & " 09:00:00"

                        For i As Integer = 1 To numOfVisits

                            If estVisitDate >= CDate(Format(dtpStartDate.Value.Date, "dd/MM/yyyy") & " 09:00") _
                                    And estVisitDate <= CDate(Format(dtpEndDate.Value.Date, "dd/MM/yyyy") & " 09:00") Then

                                'I WANT TO STORE THE DATE IT SHOULD HAVE BEEN SO THE DATES AT THE START OF THE MONTH DON@T CREEP UP FOR EAXMPLE - ALP
                                Dim shouldHaveBeenDate As DateTime = estVisitDate
                                'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                                If estVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                                    estVisitDate = estVisitDate.AddDays(2)
                                ElseIf estVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                                    estVisitDate = estVisitDate.AddDays(1)
                                End If

                                For Each drAsset As DataRow In Assets.Table.Rows
                                    Dim rVal As DataRow()
                                    rVal = AssetDurations.Table.Select("CompareMonth=" & Format(estVisitDate, "yyyyMM") & _
                                                                        " AND AssetID=" & drAsset("AssetID"))
                                    If rVal.Length > 0 Then
                                        drAsset(Format(estVisitDate, "MMM yy")) = rVal(0).Item("VisitDuration")
                                    Else
                                        drAsset(Format(estVisitDate, "MMM yy")) = "0"
                                    End If

                                Next drAsset
                                Visits.Add(estVisitDate)

                                ' estVisitDate = estVisitDate.AddDays(visitFreqInDays)
                                estVisitDate = shouldHaveBeenDate.AddMonths(visitFreqInMonths)
                            End If
                        Next i

                    Else
                        lblWarning.Visible = True

                    End If
                End If
            End If

            SetupAssetsDataGrid()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentContractOption3Site = DB.ContractOption3Site.ContractOption3Site_Get(ID)
        End If

        AssetDurations = DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_GetAll_ForContractSiteID(CurrentContractOption3Site.ContractSiteID)

        Me.txtContractSiteReference.Text = CurrentContractOption3Site.ContractSiteReference

        Try
            Me.dtpStartDate.Value = CurrentContractOption3Site.StartDate
            Me.dtpEndDate.Value = CurrentContractOption3Site.EndDate
            Me.dtpFirstVisitDate.Value = CurrentContractOption3Site.FirstVisitDate
            Me.dtpFirstInvoiceDate.Value = CurrentContractOption3Site.FirstInvoiceDate
        Catch ex As Exception
            'AMY DID THIS 
            dtpStartDate.Value = Now
            dtpEndDate.Value = Now.AddYears(1).AddDays(-1)
            dtpFirstVisitDate.Value = Now
            Me.dtpFirstInvoiceDate.Value = Now
        End Try

        Combo.SetSelectedComboItem_By_Value(Me.cboVisitFrequencyID, CurrentContractOption3Site.VisitFrequencyID)
        Combo.SetSelectedComboItem_By_Value(Me.cboInvoiceFrequencyID, CurrentContractOption3Site.InvoiceFrequencyID)
        Me.txtSitePrice.Text = Format(CurrentContractOption3Site.SitePrice, "C")


        Assets = DB.Asset.Asset_GetForSite(CurrentContractOption3Site.PropertyID)

        AssetDurations = DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_GetAll_ForContractSiteID(CurrentContractOption3Site.ContractSiteID)
        RefreshAssetsGrid()
        If AssetDurations.Table.Rows.Count > 0 Then
            Me.dtpStartDate.Enabled = False
            Me.dtpEndDate.Enabled = False
            Me.dtpFirstVisitDate.Enabled = False
            Me.cboVisitFrequencyID.Enabled = False
            Me.btnRefreshGrid.Enabled = False
            Me.dgAssets.Enabled = False
        End If
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentContractOption3Site.IgnoreExceptionsOnSetMethods = True

            CurrentContractOption3Site.SetContractSiteReference = Me.txtContractSiteReference.Text.Trim
            CurrentContractOption3Site.StartDate = Me.dtpStartDate.Value
            CurrentContractOption3Site.EndDate = Me.dtpEndDate.Value
            CurrentContractOption3Site.FirstVisitDate = Me.dtpFirstVisitDate.Value
            CurrentContractOption3Site.SetVisitFrequencyID = Combo.GetSelectedItemValue(Me.cboVisitFrequencyID)
            CurrentContractOption3Site.SetInvoiceFrequencyID = Combo.GetSelectedItemValue(Me.cboInvoiceFrequencyID)
            CurrentContractOption3Site.SetSitePrice = Me.txtSitePrice.Text.Trim.Replace("£", "")
            CurrentContractOption3Site.FirstInvoiceDate = dtpFirstInvoiceDate.Value


            If Not SelectedInvoiceAddressesDataRow Is Nothing Then
                CurrentContractOption3Site.SetInvoiceAddressID = SelectedInvoiceAddressesDataRow("AddressID")
                CurrentContractOption3Site.SetInvoiceAddressTypeID = SelectedInvoiceAddressesDataRow("AddressTypeID")
            End If

            Dim cV As New Entity.ContractOption3Sites.ContractOption3SiteValidator
            cV.Validate(CurrentContractOption3Site, Assets)

            If CurrentContractOption3Site.Exists Then
                DB.ContractOption3Site.Update(CurrentContractOption3Site)

                If PPMSchedule.Table.Rows.Count = 0 Then

                    If ShowMessage("Visit will now be scheduled - are you sure you want to save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                        DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_Delete(CurrentContractOption3Site.ContractSiteID)

                        For Each vDate As Object In Visits ' For each Visit 

                            Dim oJob As New Entity.Jobs.Job
                            oJob = CreateJob(vDate)

                            'CREATE PPM VISIT RECORD
                            Dim PPM As New Entity.ContractOption3SitePPMVisits.ContractOption3SitePPMVisit
                            PPM.SetContractSiteID = CurrentContractOption3Site.ContractSiteID
                            PPM.VisitDate = vDate
                            PPM.SetJobID = oJob.JobID
                            DB.ContractOption3SitePPMVisit.Insert(PPM)

                        Next vDate

                    End If
                End If
            Else
                CurrentContractOption3Site = DB.ContractOption3Site.Insert(CurrentContractOption3Site)

            End If
            If Not InvoiceInserted Then
                InsertInvoiceToBeRaiseLines()
            End If


            RaiseEvent StateChanged(CurrentContractOption3Site.ContractSiteID)

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

    Private Function CreateJob(ByVal vDate As DateTime) As Entity.Jobs.Job
        Dim durationTotal As Double = 0
        Dim slotDuration As Double = 0
        Dim numOfSlotsNeeded As Integer = 0
        Dim dayStartDate As DateTime = Nothing
        Dim dayEndDate As DateTime = Nothing
        Dim workingDayMinutes As Double = 0
        Dim workingDaySlots As Integer = 0
        Dim numOfDaysNeeded As Integer = 0
        Dim numOfMintuesNeeded As Integer = 0

        'CREATE new Job 
        Dim oJob As New Entity.Jobs.Job
        oJob.SetContractID = CurrentContractOption3Site.ContractID
        oJob.SetCreatedByUserID = loggedInUser.UserID
        oJob.SetJobDefinitionEnumID = Entity.Sys.Helper.MakeIntegerValid(Entity.Sys.Enums.JobDefinition.Contract)
        Dim JobNumber As New JobNumber
        JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract)
        oJob.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
        oJob.SetPONumber = ""
        oJob.SetQuoteID = 0
        oJob.SetJobTypeID = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")(0).Item("ManagerID")
        oJob.SetPropertyID = CurrentContractOption3Site.PropertyID
        oJob.SetStatusEnumID = Entity.Sys.Helper.MakeIntegerValid(Entity.Sys.Enums.JobStatus.Open)
        oJob.DateCreated = Now
        oJob.SetFOC = True
        Dim curContract As New Entity.ContractOption3s.ContractOption3
        curContract = DB.ContractOption3.ContractOption3_Get(CurrentContractOption3Site.ContractID)

        ' IF CONTRACT IS NOT ACTIVE, FLAG JOB AS DELETED
        If CType(curContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
            oJob.SetDeleted = True
        End If

        'FOR EACH ASSET FOR THE VISIT DATE
        For Each rAsset As DataRow In Assets.Table.Rows
            'IF DURATION > 0 THEN SAVE DURATION 
            If rAsset(Format(vDate, "MMM yy")) > 0 Then
                Dim assetDuration As New Entity.ContractOption3SiteAsset.ContractOption3SiteAsset
                assetDuration.SetContractSiteID = CurrentContractOption3Site.ContractSiteID
                assetDuration.SetAssetID = rAsset("AssetID")
                assetDuration.ScheduledMonth = vDate
                assetDuration.SetVisitDuration = rAsset(Format(vDate, "MMM yy"))
                DB.ContractOption3SiteAsset.Insert(assetDuration)

                'ADD TO JOB ASSETS
                Dim jobAsset As New Entity.JobAssets.JobAsset
                jobAsset.SetAssetID = rAsset("AssetID")
                oJob.Assets.Add(jobAsset)

                'SUM UP DURATION
                durationTotal += Entity.Sys.Helper.MakeDoubleValid(rAsset(Format(vDate, "MMM yy")))
            End If
        Next

        '  CREATE JOB OF WORK  
        Dim ojobOfWork As New Entity.JobOfWorks.JobOfWork
        ojobOfWork.IgnoreExceptionsOnSetMethods = True
        ojobOfWork.SetPONumber = ""
        ' IF CONTRACT IS NOT ACTIVE, FLAG JOB AS DELETED
        If CType(curContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
            ojobOfWork.SetDeleted = True
        End If

        'CREATE JOB ITEM - just on for default
        Dim ojobItem As New Entity.JobItems.JobItem
        ojobItem.IgnoreExceptionsOnSetMethods = True
        ojobItem.SetSummary = Entity.Sys.Helper.MakeStringValid("PPM Contract Visit")
        ojobOfWork.JobItems.Add(ojobItem)

        'SYSTEM NUMBER OF MINUTES IN A SLOTS
        Dim settings As New Entity.Management.Settings
        settings = DB.Manager.Get
        slotDuration = settings.TimeSlot


        'NUM OF SLOTS NEEDED FOR VISIT
        If durationTotal > 0 Then
            numOfMintuesNeeded = durationTotal * 60
            numOfSlotsNeeded = numOfMintuesNeeded / slotDuration
        Else
            numOfSlotsNeeded = 1
        End If

        'NEED SEE IF TOTAL DURATION IS GREATER THAN WORKING DAY 
        dayStartDate = Entity.Sys.Helper.MakeDateTimeValid("01/01/1900 " & settings.WorkingHoursStart)
        dayEndDate = Entity.Sys.Helper.MakeDateTimeValid("01/01/1900 " & settings.WorkingHoursEnd)
        'NUMBER OF SLOTS IN A DAY
        workingDayMinutes = DateDiff(DateInterval.Minute, dayStartDate, dayEndDate)
        workingDaySlots = workingDayMinutes / slotDuration

        numOfDaysNeeded = Math.Ceiling(numOfSlotsNeeded / workingDaySlots)

        'Dim matches As New ArrayList 'Arraylist of arraylists
        'FIND A SUITABLE ENGINEER FIRST
        'matches = GetEngineersAndVisits(numOfDaysNeeded, workingDaySlots, vDate)

        For i As Integer = 0 To numOfDaysNeeded - 1
            Dim oEngVisit As New Entity.EngineerVisits.EngineerVisit
            oEngVisit.IgnoreExceptionsOnSetMethods = True
            'Try
            '    oEngVisit.SetEngineerID = Entity.Sys.Helper.MakeIntegerValid(CType(matches.Item(i), ArrayList).Item(1))
            'Catch ex As Exception
            oEngVisit.SetEngineerID = 0
            'End Try

            oEngVisit.SetNotesToEngineer = "PPM Contract Visit"

            'If oEngVisit.EngineerID > 0 Then

            '    oEngVisit.StartDateTime = CType(matches.Item(i), ArrayList).Item(0)
            '    If numOfMintuesNeeded > workingDayMinutes Then
            '        oEngVisit.EndDateTime = CType(matches.Item(i), ArrayList).Item(0).AddHours(Math.Ceiling(workingDayMinutes / 60))
            '        numOfMintuesNeeded -= workingDayMinutes
            '    Else
            '        oEngVisit.EndDateTime = CType(matches.Item(i), ArrayList).Item(0).AddHours(Math.Ceiling(numOfMintuesNeeded / 60))
            '    End If
            '    oEngVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
            'Else
            oEngVisit.StartDateTime = DateTime.MinValue
            oEngVisit.EndDateTime = DateTime.MinValue
            oEngVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
            'End If

            ojobOfWork.EngineerVisits.Add(oEngVisit)
        Next i


        'ADD JOB OF WORK TO JOB
        oJob.JobOfWorks.Add(ojobOfWork)
        'INSERT JOB 
        oJob = DB.Job.Insert(oJob)

        Return oJob
    End Function

    Private Function GetEngineersAndVisits(ByVal numOfDaysNeeded As Integer, ByVal numOfSlotsInADay As Integer, _
                                            ByVal estVisitDate As DateTime) As ArrayList
        Dim site As New Entity.Sites.Site
        Dim matches As New ArrayList
        Dim postcode As String = ""
        Dim postcodeEngineers As DataView = Nothing
        Dim cntPostcodeEng As Integer = 0
        Dim randomNum As Integer = 0


        'SEE IF THE SITE HAS A DEFAULT ENGINEER
        site = DB.Sites.Get(CurrentContractOption3Site.PropertyID)

        If site.EngineerID > 0 Then
            'IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS) 
            matches = CheckAvailability(estVisitDate, site.EngineerID, numOfDaysNeeded, numOfSlotsInADay)
        End If
        'IF A ENG & SLOT IS FOUND, RETURN
        If matches.Count > 0 Then
            Return matches
        End If

        'NO MATCH FOUND FOR SITE ENGINEER
        'IS THERE A MATCH FOR POSTCODE ENGINEERS
        postcode = site.Postcode.Replace("-", "")
        postcode = postcode.Replace(" ", "")
        postcode = postcode.Substring(0, postcode.Length - 3)

        'GET ALL THE ENGINEERS THAT COVER THAT POSTCODE
        postcodeEngineers = DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(postcode)
        cntPostcodeEng = postcodeEngineers.Table.Rows.Count

        If cntPostcodeEng > 0 Then
            For i As Integer = 0 To cntPostcodeEng - 1
                Randomize()
                randomNum = CInt(Int((postcodeEngineers.Table.Rows.Count * Rnd()) + 1)) - 1

                matches = CheckAvailability(estVisitDate, postcodeEngineers.Table.Rows(randomNum).Item("EngineerID"), numOfDaysNeeded, numOfSlotsInADay)

                'IF A ENG & SLOT IS FOUND, RETURN
                If matches.Count > 0 Then
                    Return matches
                Else
                    postcodeEngineers.Table.Rows.Remove(postcodeEngineers.Table.Rows(randomNum))
                End If

            Next i
        End If
    End Function

    Private Function CheckAvailability(ByVal estimatedVisitDate As DateTime, _
                                        ByVal engineerID As Integer, _
                                        ByVal numOfDaysNeeded As Integer, _
                                        ByVal numOfSlotsInADay As Integer) As ArrayList

        Dim engTimeSlots As DataTable
        Dim numOfSlotsAvailable As New ArrayList
        Dim actualVisitDate As DateTime = estimatedVisitDate
        Dim matches As New ArrayList
        Dim startSlotTime As String = ""
        Dim matchcount As Integer = 0

        For day As Integer = 0 To 4 ' SEARCHES OVER NEXT 5 WORKING DAYS
            matches.Clear()
            matchcount = 0
            'ADD ON DAYS - UNLESS FIRST TIME IN
            If day <> 0 Then
                actualVisitDate = estimatedVisitDate.AddDays(1)
            End If

            For i As Integer = 1 To numOfDaysNeeded ' SEARCHES 1st VISIT AND ALL SUSEQUNCE DAYS
                numOfSlotsAvailable.Clear()

                'ADD ON DAYS - UNLESS FIRST TIME IN
                If i <> 1 Then
                    actualVisitDate = actualVisitDate.AddDays(1)
                End If

                'MAKE IT NOT SAT
                If actualVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                    actualVisitDate = actualVisitDate.AddDays(2)
                End If
                'MAKE IT NOT SUN
                If actualVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                    actualVisitDate = actualVisitDate.AddDays(1)
                End If

                'GET SLOTS USED
                engTimeSlots = DB.Scheduler.Scheduler_DayTimeSlots(actualVisitDate, engineerID)
                'SLOTS ARE DISPLAY AS COLUMNS IN THIS TABLE THAT WHY WE LOOP THROUGH COLUMNS INSTEAD OF ROWS
                If engTimeSlots.Rows.Count > 0 Then
                    For colCnt As Integer = 0 To engTimeSlots.Columns.Count - 1
                        'LOOP THOROUGH EACH COLUMNS TRYING TO FIND AVAILABLE CONSECTUTIVE COLUMNS
                        'EQUAL TO THE NUMBER OF REQUIRED SLOTS
                        If engTimeSlots.Rows(0).Item(colCnt) = 0 Then
                            numOfSlotsAvailable.Add(engTimeSlots.Columns(colCnt).ColumnName)
                            If numOfSlotsAvailable.Count = numOfSlotsInADay Then
                                Exit For
                            End If
                        Else
                            'NOTHING AVAIALABLE
                            numOfSlotsAvailable.Clear()
                        End If
                    Next
                Else
                    'IF NO ROW THEN NOTHING USED FOR THAT DAY SO VISIT CAN GO AT THE BEGINNING
                    numOfSlotsAvailable.Add(DB.Manager.Get.WorkingHoursStart())
                End If


                If numOfSlotsAvailable.Count > 0 Then
                    Dim match As New ArrayList

                    If numOfSlotsAvailable.Count = numOfSlotsInADay _
                        Or (numOfSlotsAvailable(0) = DB.Manager.Get.WorkingHoursStart() And _
                                                        numOfSlotsAvailable.Count = 1) Then

                        'IF THERE ARE ENOUGH AVAILABLE CONSECTUTIVE SLOTS ADD THE START TIME ONTO THE DATE

                        If numOfSlotsAvailable(0) = DB.Manager.Get.WorkingHoursStart() Then
                            startSlotTime = numOfSlotsAvailable(0)
                        Else
                            startSlotTime = Replace(numOfSlotsAvailable(0), "T", "").Insert(2, ":")
                        End If
                        actualVisitDate = CDate(Format(actualVisitDate, "dd/MM/yyyy") & " " & startSlotTime)

                        match.Add(actualVisitDate)
                        match.Add(engineerID)
                        matches.Add(match)
                        matchcount += 1
                    Else
                        match.Add(Nothing)
                        match.Add(0)
                        matches.Add(match)
                    End If

                End If
                If matchcount <> i Then
                    Exit For
                End If
            Next i
            If matchcount = numOfDaysNeeded Then
                Return (matches)
            End If
        Next day

        Return (matches)

    End Function

    Private Sub InsertInvoiceToBeRaiseLines()
        Dim numberOfInvoicesToRaise As Integer = 0

        Select Case CType(CurrentContractOption3Site.InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency)
            Case Entity.Sys.Enums.InvoiceFrequency.Annually
                numberOfInvoicesToRaise = DateDiff(DateInterval.Year, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate)
            Case Entity.Sys.Enums.InvoiceFrequency.Bi_Annually
                numberOfInvoicesToRaise = (DateDiff(DateInterval.Year, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate)) * 2
            Case Entity.Sys.Enums.InvoiceFrequency.Monthly
                numberOfInvoicesToRaise = DateDiff(DateInterval.Month, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate)
            Case Entity.Sys.Enums.InvoiceFrequency.Per_Visit
                'Invoice the visit
            Case Entity.Sys.Enums.InvoiceFrequency.Quarterly
                numberOfInvoicesToRaise = DateDiff(DateInterval.Month, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate) / 3
            Case Entity.Sys.Enums.InvoiceFrequency.Weekly
                numberOfInvoicesToRaise = DateDiff(DateInterval.Day, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate) / 7
        End Select
        Dim raiseDate As DateTime = CurrentContractOption3Site.FirstInvoiceDate
        For i As Integer = 1 To numberOfInvoicesToRaise
            Dim invToBeRaised As New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
            invToBeRaised.SetAddressLinkID = CurrentContractOption3Site.InvoiceAddressID
            invToBeRaised.SetAddressTypeID = CurrentContractOption3Site.InvoiceAddressTypeID
            invToBeRaised.SetInvoiceTypeID = CInt(Entity.Sys.Enums.InvoiceType.Contract_Option3)
            invToBeRaised.SetLinkID = CurrentContractOption3Site.ContractSiteID
            invToBeRaised.RaiseDate = raiseDate
            DB.InvoiceToBeRaised.Insert(invToBeRaised)

            Select Case CType(CurrentContractOption3Site.InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency)
                Case Entity.Sys.Enums.InvoiceFrequency.Annually
                    raiseDate = raiseDate.AddYears(1)
                Case Entity.Sys.Enums.InvoiceFrequency.Bi_Annually
                    raiseDate = raiseDate.AddMonths(6)
                Case Entity.Sys.Enums.InvoiceFrequency.Monthly
                    raiseDate = raiseDate.AddMonths(1)
                Case Entity.Sys.Enums.InvoiceFrequency.Quarterly
                    raiseDate = raiseDate.AddMonths(3)
                Case Entity.Sys.Enums.InvoiceFrequency.Weekly
                    raiseDate = raiseDate.AddDays(7)
            End Select
        Next

    End Sub

#End Region

End Class

