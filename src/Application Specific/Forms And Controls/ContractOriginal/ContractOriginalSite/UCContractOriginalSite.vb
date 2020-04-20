Imports FSM.Entity
Imports FSM.Entity.Sys

Public Class UCContractOriginalSite : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SetupAssetsDataGrid()

        Combo.SetUpCombo(Me.cboVisitFrequencyID, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

        'Combo.SetUpCombo(Me.cboVisitDuration, DynamicDataTables.VisitDuration(), "VisitDuration", "DisplayMember")
        'cboVisitDuration.SelectedIndex = 0
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

    Friend WithEvents grpContractSite As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFirstVisitDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFirstVisitDate As System.Windows.Forms.Label
    Friend WithEvents cboVisitFrequencyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisitFrequencyID As System.Windows.Forms.Label
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents lblSite As System.Windows.Forms.Label
    Friend WithEvents grpAssets As System.Windows.Forms.GroupBox
    Friend WithEvents dgAssets As System.Windows.Forms.DataGrid
    Friend WithEvents grpVisits As System.Windows.Forms.GroupBox
    Friend WithEvents dgVisits As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpScheduleOfRates As System.Windows.Forms.GroupBox
    Friend WithEvents btnSiteScheduleOfRates As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents dgSystemRates As System.Windows.Forms.DataGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkLLCertificateReqd As System.Windows.Forms.CheckBox
    Friend WithEvents txtAdditionalNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtVisitDuration As System.Windows.Forms.TextBox
    Friend WithEvents chkCommercial As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddVisit As System.Windows.Forms.Button
    Friend WithEvents btRemoveVisit As System.Windows.Forms.Button
    Friend WithEvents dgVisitsSetup As System.Windows.Forms.DataGrid
    Friend WithEvents dgScheduleOfRates As System.Windows.Forms.DataGrid

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpContractSite = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAddVisit = New System.Windows.Forms.Button()
        Me.btRemoveVisit = New System.Windows.Forms.Button()
        Me.dgVisitsSetup = New System.Windows.Forms.DataGrid()
        Me.chkCommercial = New System.Windows.Forms.CheckBox()
        Me.txtVisitDuration = New System.Windows.Forms.TextBox()
        Me.txtAdditionalNotes = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkLLCertificateReqd = New System.Windows.Forms.CheckBox()
        Me.grpScheduleOfRates = New System.Windows.Forms.GroupBox()
        Me.dgSystemRates = New System.Windows.Forms.DataGrid()
        Me.btnSiteScheduleOfRates = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.dgScheduleOfRates = New System.Windows.Forms.DataGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpAssets = New System.Windows.Forms.GroupBox()
        Me.dgAssets = New System.Windows.Forms.DataGrid()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.dtpFirstVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.lblFirstVisitDate = New System.Windows.Forms.Label()
        Me.cboVisitFrequencyID = New System.Windows.Forms.ComboBox()
        Me.lblVisitFrequencyID = New System.Windows.Forms.Label()
        Me.lblSite = New System.Windows.Forms.Label()
        Me.grpVisits = New System.Windows.Forms.GroupBox()
        Me.dgVisits = New System.Windows.Forms.DataGrid()
        Me.grpContractSite.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgVisitsSetup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpScheduleOfRates.SuspendLayout()
        CType(Me.dgSystemRates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgScheduleOfRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAssets.SuspendLayout()
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVisits.SuspendLayout()
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpContractSite
        '
        Me.grpContractSite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContractSite.Controls.Add(Me.GroupBox1)
        Me.grpContractSite.Controls.Add(Me.chkCommercial)
        Me.grpContractSite.Controls.Add(Me.txtVisitDuration)
        Me.grpContractSite.Controls.Add(Me.txtAdditionalNotes)
        Me.grpContractSite.Controls.Add(Me.Label2)
        Me.grpContractSite.Controls.Add(Me.chkLLCertificateReqd)
        Me.grpContractSite.Controls.Add(Me.grpScheduleOfRates)
        Me.grpContractSite.Controls.Add(Me.Label1)
        Me.grpContractSite.Controls.Add(Me.grpAssets)
        Me.grpContractSite.Controls.Add(Me.txtSite)
        Me.grpContractSite.Controls.Add(Me.dtpFirstVisitDate)
        Me.grpContractSite.Controls.Add(Me.lblFirstVisitDate)
        Me.grpContractSite.Controls.Add(Me.cboVisitFrequencyID)
        Me.grpContractSite.Controls.Add(Me.lblVisitFrequencyID)
        Me.grpContractSite.Controls.Add(Me.lblSite)
        Me.grpContractSite.Controls.Add(Me.grpVisits)
        Me.grpContractSite.Location = New System.Drawing.Point(5, 6)
        Me.grpContractSite.Name = "grpContractSite"
        Me.grpContractSite.Size = New System.Drawing.Size(931, 600)
        Me.grpContractSite.TabIndex = 0
        Me.grpContractSite.TabStop = False
        Me.grpContractSite.Text = "Main Details"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnAddVisit)
        Me.GroupBox1.Controls.Add(Me.btRemoveVisit)
        Me.GroupBox1.Controls.Add(Me.dgVisitsSetup)

        Me.GroupBox1.Location = New System.Drawing.Point(13, 264)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(912, 164)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Commercial Contract Visits Setup"
        '
        'btnAddVisit
        '
        Me.btnAddVisit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddVisit.Location = New System.Drawing.Point(10, 129)
        Me.btnAddVisit.Name = "btnAddVisit"
        Me.btnAddVisit.Size = New System.Drawing.Size(89, 23)
        Me.btnAddVisit.TabIndex = 4
        Me.btnAddVisit.Text = "Add"
        '
        'btRemoveVisit
        '
        Me.btRemoveVisit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btRemoveVisit.Location = New System.Drawing.Point(802, 129)
        Me.btRemoveVisit.Name = "btRemoveVisit"
        Me.btRemoveVisit.Size = New System.Drawing.Size(101, 23)
        Me.btRemoveVisit.TabIndex = 5
        Me.btRemoveVisit.Text = "Remove"
        '
        'dgVisitsSetup
        '
        Me.dgVisitsSetup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVisitsSetup.DataMember = ""
        Me.dgVisitsSetup.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVisitsSetup.Location = New System.Drawing.Point(10, 21)
        Me.dgVisitsSetup.Name = "dgVisitsSetup"
        Me.dgVisitsSetup.Size = New System.Drawing.Size(892, 102)
        Me.dgVisitsSetup.TabIndex = 0
        '
        'chkCommercial
        '
        Me.chkCommercial.AutoSize = True
        Me.chkCommercial.Location = New System.Drawing.Point(161, 86)
        Me.chkCommercial.Name = "chkCommercial"
        Me.chkCommercial.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkCommercial.Size = New System.Drawing.Size(95, 17)
        Me.chkCommercial.TabIndex = 7
        Me.chkCommercial.Text = "Commercial"
        Me.chkCommercial.UseVisualStyleBackColor = True
        '
        'txtVisitDuration
        '
        Me.txtVisitDuration.Location = New System.Drawing.Point(407, 88)
        Me.txtVisitDuration.Name = "txtVisitDuration"
        Me.txtVisitDuration.Size = New System.Drawing.Size(136, 21)
        Me.txtVisitDuration.TabIndex = 9
        '
        'txtAdditionalNotes
        '
        Me.txtAdditionalNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdditionalNotes.Location = New System.Drawing.Point(656, 56)
        Me.txtAdditionalNotes.Multiline = True
        Me.txtAdditionalNotes.Name = "txtAdditionalNotes"
        Me.txtAdditionalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAdditionalNotes.Size = New System.Drawing.Size(265, 53)
        Me.txtAdditionalNotes.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(549, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Additional Notes"
        '
        'chkLLCertificateReqd
        '
        Me.chkLLCertificateReqd.AutoSize = True
        Me.chkLLCertificateReqd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLLCertificateReqd.Location = New System.Drawing.Point(16, 86)
        Me.chkLLCertificateReqd.Name = "chkLLCertificateReqd"
        Me.chkLLCertificateReqd.Size = New System.Drawing.Size(139, 17)
        Me.chkLLCertificateReqd.TabIndex = 6
        Me.chkLLCertificateReqd.Text = "L/L Certificate Reqd"
        Me.chkLLCertificateReqd.UseVisualStyleBackColor = True
        '
        'grpScheduleOfRates
        '
        Me.grpScheduleOfRates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpScheduleOfRates.Controls.Add(Me.dgSystemRates)
        Me.grpScheduleOfRates.Controls.Add(Me.btnSiteScheduleOfRates)
        Me.grpScheduleOfRates.Controls.Add(Me.btnRemove)
        Me.grpScheduleOfRates.Controls.Add(Me.dgScheduleOfRates)

        Me.grpScheduleOfRates.Location = New System.Drawing.Point(13, 109)
        Me.grpScheduleOfRates.Name = "grpScheduleOfRates"
        Me.grpScheduleOfRates.Size = New System.Drawing.Size(912, 155)
        Me.grpScheduleOfRates.TabIndex = 12
        Me.grpScheduleOfRates.TabStop = False
        Me.grpScheduleOfRates.Text = "Contract Schedule Of Rates"
        '
        'dgSystemRates
        '
        Me.dgSystemRates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSystemRates.DataMember = ""
        Me.dgSystemRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSystemRates.Location = New System.Drawing.Point(11, 19)
        Me.dgSystemRates.Name = "dgSystemRates"
        Me.dgSystemRates.Size = New System.Drawing.Size(432, 106)
        Me.dgSystemRates.TabIndex = 0
        '
        'btnSiteScheduleOfRates
        '
        Me.btnSiteScheduleOfRates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSiteScheduleOfRates.Location = New System.Drawing.Point(449, 126)
        Me.btnSiteScheduleOfRates.Name = "btnSiteScheduleOfRates"
        Me.btnSiteScheduleOfRates.Size = New System.Drawing.Size(89, 23)
        Me.btnSiteScheduleOfRates.TabIndex = 2
        Me.btnSiteScheduleOfRates.Text = "Add"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(802, 126)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(101, 23)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove"
        '
        'dgScheduleOfRates
        '
        Me.dgScheduleOfRates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgScheduleOfRates.DataMember = ""
        Me.dgScheduleOfRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgScheduleOfRates.Location = New System.Drawing.Point(449, 19)
        Me.dgScheduleOfRates.Name = "dgScheduleOfRates"
        Me.dgScheduleOfRates.Size = New System.Drawing.Size(454, 106)
        Me.dgScheduleOfRates.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(307, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Visit Duration"
        '
        'grpAssets
        '
        Me.grpAssets.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpAssets.Controls.Add(Me.dgAssets)

        Me.grpAssets.Location = New System.Drawing.Point(14, 434)
        Me.grpAssets.Name = "grpAssets"
        Me.grpAssets.Size = New System.Drawing.Size(442, 156)
        Me.grpAssets.TabIndex = 13
        Me.grpAssets.TabStop = False
        Me.grpAssets.Text = "Appliances"
        '
        'dgAssets
        '
        Me.dgAssets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAssets.DataMember = ""
        Me.dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAssets.Location = New System.Drawing.Point(10, 21)
        Me.dgAssets.Name = "dgAssets"
        Me.dgAssets.Size = New System.Drawing.Size(423, 130)
        Me.dgAssets.TabIndex = 0
        '
        'txtSite
        '
        Me.txtSite.Location = New System.Drawing.Point(78, 19)
        Me.txtSite.Multiline = True
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSite.Size = New System.Drawing.Size(843, 31)
        Me.txtSite.TabIndex = 1
        '
        'dtpFirstVisitDate
        '
        Me.dtpFirstVisitDate.Location = New System.Drawing.Point(139, 57)
        Me.dtpFirstVisitDate.Name = "dtpFirstVisitDate"
        Me.dtpFirstVisitDate.Size = New System.Drawing.Size(162, 21)
        Me.dtpFirstVisitDate.TabIndex = 3
        Me.dtpFirstVisitDate.Tag = "ContractSite.FirstVisitDate"
        '
        'lblFirstVisitDate
        '
        Me.lblFirstVisitDate.Location = New System.Drawing.Point(18, 58)
        Me.lblFirstVisitDate.Name = "lblFirstVisitDate"
        Me.lblFirstVisitDate.Size = New System.Drawing.Size(89, 20)
        Me.lblFirstVisitDate.TabIndex = 2
        Me.lblFirstVisitDate.Text = "First Visit Date"
        '
        'cboVisitFrequencyID
        '
        Me.cboVisitFrequencyID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVisitFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitFrequencyID.Location = New System.Drawing.Point(407, 58)
        Me.cboVisitFrequencyID.Name = "cboVisitFrequencyID"
        Me.cboVisitFrequencyID.Size = New System.Drawing.Size(136, 21)
        Me.cboVisitFrequencyID.TabIndex = 5
        Me.cboVisitFrequencyID.Tag = "ContractSite.VisitFrequencyID"
        '
        'lblVisitFrequencyID
        '
        Me.lblVisitFrequencyID.Location = New System.Drawing.Point(307, 57)
        Me.lblVisitFrequencyID.Name = "lblVisitFrequencyID"
        Me.lblVisitFrequencyID.Size = New System.Drawing.Size(94, 20)
        Me.lblVisitFrequencyID.TabIndex = 4
        Me.lblVisitFrequencyID.Text = "Visit Frequency"
        '
        'lblSite
        '
        Me.lblSite.Location = New System.Drawing.Point(13, 19)
        Me.lblSite.Name = "lblSite"
        Me.lblSite.Size = New System.Drawing.Size(64, 20)
        Me.lblSite.TabIndex = 0
        Me.lblSite.Text = "Property"
        '
        'grpVisits
        '
        Me.grpVisits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVisits.Controls.Add(Me.dgVisits)

        Me.grpVisits.Location = New System.Drawing.Point(462, 434)
        Me.grpVisits.Name = "grpVisits"
        Me.grpVisits.Size = New System.Drawing.Size(465, 157)
        Me.grpVisits.TabIndex = 14
        Me.grpVisits.TabStop = False
        Me.grpVisits.Text = "Visits Created"
        '
        'dgVisits
        '
        Me.dgVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVisits.DataMember = ""
        Me.dgVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVisits.Location = New System.Drawing.Point(10, 21)
        Me.dgVisits.Name = "dgVisits"
        Me.dgVisits.Size = New System.Drawing.Size(446, 131)
        Me.dgVisits.TabIndex = 0
        '
        'UCContractOriginalSite
        '
        Me.Controls.Add(Me.grpContractSite)
        Me.Name = "UCContractOriginalSite"
        Me.Size = New System.Drawing.Size(941, 616)
        Me.grpContractSite.ResumeLayout(False)
        Me.grpContractSite.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgVisitsSetup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpScheduleOfRates.ResumeLayout(False)
        CType(Me.dgSystemRates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgScheduleOfRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAssets.ResumeLayout(False)
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVisits.ResumeLayout(False)
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentContractSite
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraTest As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _OldContractSite As Entity.ContractOriginalSites.ContractOriginalSite

    Public Property OldContractSite() As Entity.ContractOriginalSites.ContractOriginalSite
        Get
            Return _OldContractSite
        End Get
        Set(ByVal value As Entity.ContractOriginalSites.ContractOriginalSite)
            _OldContractSite = value
        End Set
    End Property

    Private _currentContractSite As Entity.ContractOriginalSites.ContractOriginalSite

    Public Property CurrentContractSite() As Entity.ContractOriginalSites.ContractOriginalSite
        Get
            Return _currentContractSite
        End Get
        Set(ByVal Value As Entity.ContractOriginalSites.ContractOriginalSite)
            _currentContractSite = Value

            SetupSystemRatesDataGrid()

            SystemRates = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll_WithoutDefaults

            If _currentContractSite Is Nothing Then
                _currentContractSite = New Entity.ContractOriginalSites.ContractOriginalSite
                _currentContractSite.Exists = False
            End If

            If _currentContractSite.Exists Then
                Populate()
                Me.dtpFirstVisitDate.Enabled = False
                Me.cboVisitFrequencyID.Enabled = False
                Me.txtVisitDuration.Enabled = False
                'Me.cboVisitDuration.Enabled = False
                Visits = DB.ContractOriginalPPMVisit.GetAll_For_ContractSiteID(_currentContractSite.ContractSiteID)
            Else
                If OldContractSite Is Nothing Then
                    _currentContractSite.ContractSiteScheduleOfRates = BuildUpScheduleOfRatesDataview()
                    dtpFirstVisitDate.Value = CurrentContract.ContractStartDate
                Else
                    _currentContractSite.ContractSiteScheduleOfRates = OldContractSite.ContractSiteScheduleOfRates

                    Dim visitDuration As Integer = 0
                    For Each drSOR As DataRow In CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows
                        visitDuration += (drSOR("Qty") * drSOR("TimeInMins"))
                    Next
                    _currentContractSite.SetVisitDuration = visitDuration

                    _currentContractSite.SetAdditionalNotes = OldContractSite.AdditionalNotes
                    _currentContractSite.SetIncludeAssetPrice = OldContractSite.IncludeAssetPrice
                    _currentContractSite.SetIncludeMileagePrice = OldContractSite.IncludeMileagePrice
                    _currentContractSite.SetIncludeRates = OldContractSite.IncludeRates
                    _currentContractSite.SetLLCertReqd = OldContractSite.LLCertReqd
                    _currentContractSite.SetPricePerMile = OldContractSite.PricePerMile
                    _currentContractSite.SetPricePerVisit = OldContractSite.PricePerVisit
                    _currentContractSite.SetAverageMileage = OldContractSite.AverageMileage
                    _currentContractSite.SetTotalSitePrice = OldContractSite.TotalSitePrice

                    _currentContractSite.SetVisitFrequencyID = OldContractSite.VisitFrequencyID
                    _currentContractSite.FirstVisitDate = OldContractSite.FirstVisitDate

                    Populate()
                End If

            End If

            Site = DB.Sites.Get(SiteID)

            txtSite.Text = Replace(Replace(Replace(
                                    Site.Address1 & ", " & Site.Address2 & ", " & Site.Address3 & ", " & Site.Address4 & ", " & Site.Address5 & ", " & Site.Postcode & "." _
                                    , ", , ", ", "), ", , ", ", "), ", , ", ", ")

        End Set
    End Property

    Private _SiteID As Integer = 0

    Public Property SiteID() As Integer
        Get
            Return _SiteID
        End Get
        Set(ByVal Value As Integer)
            _SiteID = Value

        End Set
    End Property

    Private _site As Entity.Sites.Site

    Public Property Site() As Entity.Sites.Site
        Get
            Return _site
        End Get
        Set(ByVal value As Entity.Sites.Site)
            _site = value
        End Set
    End Property

    Private _CurrentContract As Entity.ContractsOriginal.ContractOriginal

    Public Property CurrentContract() As Entity.ContractsOriginal.ContractOriginal
        Get
            Return _CurrentContract
        End Get
        Set(ByVal Value As Entity.ContractsOriginal.ContractOriginal)
            _CurrentContract = Value
        End Set
    End Property

    Private _Assets As DataView

    Private Property Assets() As DataView
        Get
            Return _Assets
        End Get
        Set(ByVal Value As DataView)
            _Assets = Value
            _Assets.Table.TableName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString
            _Assets.AllowNew = False
            _Assets.AllowEdit = True
            _Assets.AllowDelete = False
            Me.dgAssets.DataSource = Assets
        End Set
    End Property

    Private _SystemRates As DataView

    Private Property SystemRates() As DataView
        Get
            Return _SystemRates
        End Get
        Set(ByVal Value As DataView)
            _SystemRates = Value
            _SystemRates.Table.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
            _SystemRates.AllowNew = False
            _SystemRates.AllowEdit = True
            _SystemRates.AllowDelete = False
            Me.dgSystemRates.DataSource = SystemRates
        End Set
    End Property

    Private ReadOnly Property SelectedSystemRatesDataRow() As DataRow
        Get
            If Not Me.dgSystemRates.CurrentRowIndex = -1 Then
                Return SystemRates(Me.dgSystemRates.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _Visits As DataView

    Private Property Visits() As DataView
        Get
            Return _Visits
        End Get
        Set(ByVal Value As DataView)
            _Visits = Value
            _Visits.Table.TableName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
            _Visits.AllowNew = False
            _Visits.AllowEdit = True
            _Visits.AllowDelete = False
            Me.dgVisits.DataSource = Visits
        End Set
    End Property

    Private _Visits2 As DataView

    Private Property Visits2() As DataView
        Get
            Return _Visits2
        End Get
        Set(ByVal Value As DataView)
            _Visits2 = Value
            _Visits2.Table.TableName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
            _Visits2.AllowNew = False
            _Visits2.AllowEdit = True
            _Visits2.AllowDelete = False
            Me.dgVisitsSetup.DataSource = Visits2
        End Set
    End Property

    Private ReadOnly Property SelectedVisitDataRow() As DataRow
        Get
            If Not Me.dgVisits.CurrentRowIndex = -1 Then
                Return Visits(Me.dgVisits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property SelectedVisitDataRow2() As DataRow
        Get
            If Not Me.dgVisitsSetup.CurrentRowIndex = -1 Then
                Return Visits2(Me.dgVisitsSetup.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property SelectedAssetDataRow() As DataRow
        Get
            If Not Me.dgAssets.CurrentRowIndex = -1 Then
                Return Assets(Me.dgAssets.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property SelectedRatesDataRow() As DataRow
        Get
            If Not Me.dgScheduleOfRates.CurrentRowIndex = -1 Then
                Return CurrentContractSite.ContractSiteScheduleOfRates(Me.dgScheduleOfRates.CurrentRowIndex).Row
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

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 50
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Product As New DataGridLabelColumn
        Product.Format = ""
        Product.FormatInfo = Nothing
        Product.HeaderText = "Product"
        Product.MappingName = "Product"
        Product.ReadOnly = True
        Product.Width = 94
        Product.NullText = ""
        tStyle.GridColumnStyles.Add(Product)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 94
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim SerialNum As New DataGridLabelColumn
        SerialNum.Format = ""
        SerialNum.FormatInfo = Nothing
        SerialNum.HeaderText = "Serial Number"
        SerialNum.MappingName = "SerialNum"
        SerialNum.ReadOnly = True
        SerialNum.Width = 94
        SerialNum.NullText = ""
        tStyle.GridColumnStyles.Add(SerialNum)

        Dim PricePerVisit As New DataGridEditableTextBoxColumn
        PricePerVisit.Format = "C"
        PricePerVisit.FormatInfo = Nothing
        PricePerVisit.HeaderText = "Price Per Visit (Click cell to change)"
        PricePerVisit.MappingName = "PricePerVisit"
        PricePerVisit.ReadOnly = False
        PricePerVisit.Width = 150
        PricePerVisit.NullText = ""
        tStyle.GridColumnStyles.Add(PricePerVisit)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString
        Me.dgAssets.TableStyles.Add(tStyle)

        ' Entity.Sys.Helper.RemoveEventHandlers(Me.dgAssets)
    End Sub

    Public Sub SetupVisitDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgVisits)
        Dim tStyle As DataGridTableStyle = Me.dgVisits.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim EstimatedVisitDate As New DataGridLabelColumn
        EstimatedVisitDate.Format = "dd/MM/yyyy"
        EstimatedVisitDate.FormatInfo = Nothing
        EstimatedVisitDate.HeaderText = "Estimated Visit Date"
        EstimatedVisitDate.MappingName = "EstimatedVisitDate"
        EstimatedVisitDate.ReadOnly = True
        EstimatedVisitDate.Width = 130
        EstimatedVisitDate.NullText = ""
        tStyle.GridColumnStyles.Add(EstimatedVisitDate)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job No."
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 80
        JobNumber.NullText = ""
        tStyle.GridColumnStyles.Add(JobNumber)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yyyy"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Visit Date"
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 80
        StartDateTime.NullText = "Not Set"
        tStyle.GridColumnStyles.Add(StartDateTime)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Engineer"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 100
        Name.NullText = "N/A"
        tStyle.GridColumnStyles.Add(Name)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
        Me.dgVisits.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupVisit2DataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgVisitsSetup)
        Dim tStyle As DataGridTableStyle = Me.dgVisitsSetup.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim VisitType As New DataGridLabelColumn
        VisitType.Format = "dd/MM/yyyy"
        VisitType.FormatInfo = Nothing
        VisitType.HeaderText = "Visit Type"
        VisitType.MappingName = "VisitType"
        VisitType.ReadOnly = True
        VisitType.Width = 130
        VisitType.NullText = ""
        tStyle.GridColumnStyles.Add(VisitType)

        Dim Frequency As New DataGridLabelColumn
        Frequency.Format = ""
        Frequency.FormatInfo = Nothing
        Frequency.HeaderText = "Frequency"
        Frequency.MappingName = "Frequency"
        Frequency.ReadOnly = True
        Frequency.Width = 150
        Frequency.NullText = ""
        tStyle.GridColumnStyles.Add(Frequency)

        Dim VisitDate As New DataGridLabelColumn
        VisitDate.Format = "dd/MM/yyyy"
        VisitDate.FormatInfo = Nothing
        VisitDate.HeaderText = "Est Visit Date"
        VisitDate.MappingName = "VisitDate"
        VisitDate.ReadOnly = True
        VisitDate.Width = 200
        VisitDate.NullText = "Not Set"
        tStyle.GridColumnStyles.Add(VisitDate)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "SubCon / Pref Engineers"
        Name.MappingName = "EngName"
        Name.ReadOnly = True
        Name.Width = 250
        Name.NullText = "N/A"
        tStyle.GridColumnStyles.Add(Name)

        Dim PricePerVisit As New DataGridEditableTextBoxColumn
        PricePerVisit.Format = "C"
        PricePerVisit.FormatInfo = Nothing
        PricePerVisit.HeaderText = "Cost"
        PricePerVisit.MappingName = "COST"
        PricePerVisit.ReadOnly = False
        PricePerVisit.Width = 150
        PricePerVisit.NullText = ""
        tStyle.GridColumnStyles.Add(PricePerVisit)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
        Me.dgVisitsSetup.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupSystemRatesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgSystemRates)
        Dim tStyle As DataGridTableStyle = Me.dgSystemRates.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgSystemRates.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim QtyPerVisit As New DataGridEditableTextBoxColumn
        QtyPerVisit.Format = "D" 'Decimal
        QtyPerVisit.FormatInfo = Nothing
        QtyPerVisit.HeaderText = "Quantity To Add"
        QtyPerVisit.MappingName = "Qty"
        QtyPerVisit.ReadOnly = False
        QtyPerVisit.Width = 100
        QtyPerVisit.NullText = ""
        tStyle.GridColumnStyles.Add(QtyPerVisit)

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 100
        Category.NullText = ""
        tStyle.GridColumnStyles.Add(Category)

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Code"
        Code.MappingName = "Code"
        Code.ReadOnly = True
        Code.Width = 100
        Code.NullText = ""
        tStyle.GridColumnStyles.Add(Code)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 150
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Unit Price"
        Price.MappingName = "Price"
        Price.ReadOnly = False
        Price.Width = 80
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
        Me.dgSystemRates.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupScheduleOfRatesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgScheduleOfRates)
        Dim tStyle As DataGridTableStyle = Me.dgScheduleOfRates.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 100
        Category.NullText = ""
        tStyle.GridColumnStyles.Add(Category)

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Code"
        Code.MappingName = "Code"
        Code.ReadOnly = True
        Code.Width = 100
        Code.NullText = ""
        tStyle.GridColumnStyles.Add(Code)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 150
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Unit Price"
        Price.MappingName = "Price"
        Price.ReadOnly = False
        Price.Width = 80
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim QtyPerVisit As New DataGridLabelColumn
        QtyPerVisit.Format = ""
        QtyPerVisit.FormatInfo = Nothing
        QtyPerVisit.HeaderText = "Unit Qty Per Visit"
        QtyPerVisit.MappingName = "Qty"
        QtyPerVisit.ReadOnly = False
        QtyPerVisit.Width = 100
        QtyPerVisit.NullText = ""
        tStyle.GridColumnStyles.Add(QtyPerVisit)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractOriginalSiteRates.ToString
        Me.dgScheduleOfRates.TableStyles.Add(tStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub UCContractSite_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
        If Visits2 Is Nothing Then
            Visits2 = DB.ContractVisits.GetAll_For_ContractSiteID(0) ' generate a grid
        End If
    End Sub

    Private Sub dgAssets_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgAssets.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgAssets.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            dgAssets.CurrentRowIndex = HitTestInfo.Row()
        End If

        If HitTestInfo.Column = 0 Then
            Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(Me.dgAssets(Me.dgAssets.CurrentRowIndex, 0))
            Assets.Table.Rows(dgAssets.CurrentRowIndex).Item("Tick") = selected
        End If
    End Sub

    Private Sub dgSystemRates_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgSystemRates.MouseUp
        Try
            If SelectedSystemRatesDataRow Is Nothing Then
                Exit Sub
            End If

            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgSystemRates.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgSystemRates.CurrentRowIndex = HitTestInfo.Row()
            End If

            If HitTestInfo.Column = 0 Then
                Dim selected As Boolean = Not CBool(Me.dgSystemRates(Me.dgSystemRates.CurrentRowIndex, 0))

                If SelectedSystemRatesDataRow.Item("Qty") = 0 Then
                    SelectedSystemRatesDataRow.Item("Qty") = 1
                End If

                Me.dgSystemRates(Me.dgSystemRates.CurrentRowIndex, 0) = selected
            End If
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Not SelectedRatesDataRow Is Nothing Then
            With SelectedRatesDataRow

                If MessageBox.Show("DELETE :" & .Item("Description"), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    'REMOVE SOR TIME
                    Dim visitDuration As Integer = Entity.Sys.Helper.MakeIntegerValid(Me.txtVisitDuration.Text)
                    visitDuration -= (SelectedRatesDataRow("Qty") * SelectedRatesDataRow("TimeInMins"))
                    Me.txtVisitDuration.Text = visitDuration

                    If SelectedRatesDataRow("ContractOriginalSiteRateID") > 0 Then
                        DB.ContractOriginalSiteRates.Delete(SelectedRatesDataRow("ContractOriginalSiteRateID"))
                        CurrentContractSite.ContractSiteScheduleOfRates = DB.ContractOriginalSiteRates.ContractOriginalSiteRates_GetForContractSite(CurrentContractSite.ContractSiteID)
                        Save()
                    Else
                        CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.Remove(SelectedRatesDataRow)
                    End If

                    dgScheduleOfRates.DataSource = CurrentContractSite.ContractSiteScheduleOfRates

                End If

            End With
        End If
    End Sub

    Private Sub btnSiteScheduleOfRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiteScheduleOfRates.Click

        For Each tickedRow As DataRow In SystemRates.Table.Select("Tick = 1")
            If CurrentContractSite.ContractSiteScheduleOfRates.Table.Select("RateID = " & tickedRow("SystemScheduleOfRateID")).Length > 0 Then
                Dim updateRow As DataRow = CurrentContractSite.ContractSiteScheduleOfRates.Table.Select("RateID = " & tickedRow("SystemScheduleOfRateID"))(0)
                updateRow.Item("Qty") += tickedRow("Qty")
                updateRow.Item("Updated") = True
                updateRow.AcceptChanges()
                CurrentContractSite.ContractSiteScheduleOfRates.Table.AcceptChanges()
            Else
                Dim newRow As DataRow = CurrentContractSite.ContractSiteScheduleOfRates.Table.NewRow

                newRow.Item("ContractOriginalSiteRateID") = 0
                newRow.Item("RateID") = tickedRow("SystemScheduleOfRateID")
                newRow.Item("ScheduleOfRatesCategoryID") = tickedRow("ScheduleOfRatesCategoryID")
                newRow.Item("Category") = tickedRow("Category")
                newRow.Item("Code") = tickedRow("Code")
                newRow.Item("Description") = tickedRow("Description")
                newRow.Item("Price") = tickedRow("Price")
                newRow.Item("TimeInMins") = tickedRow("TimeInMins")
                newRow.Item("Qty") = tickedRow("Qty")
                newRow.Item("Updated") = False

                CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.Add(newRow)
                CurrentContractSite.ContractSiteScheduleOfRates.Table.AcceptChanges()
            End If
            Dim visitDuration As Integer = Entity.Sys.Helper.MakeIntegerValid(Me.txtVisitDuration.Text)
            visitDuration += (tickedRow("Qty") * tickedRow("TimeInMins"))
            Me.txtVisitDuration.Text = visitDuration
        Next

        dgScheduleOfRates.DataSource = CurrentContractSite.ContractSiteScheduleOfRates

        For Each tickedRow As DataRow In SystemRates.Table.Select("Tick = 1")
            tickedRow.Item("Tick") = 0
            tickedRow.Item("Qty") = 0
        Next

        SystemRates.Table.AcceptChanges()

    End Sub

    Private Sub dgVisits_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgVisits.DoubleClick
        ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitDataRow("JobID"), CurrentContractSite.PropertyID, Me})
    End Sub

    Private Sub dgVisits2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgVisitsSetup.DoubleClick
        ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitDataRow("JobID"), CurrentContractSite.PropertyID, Me})
    End Sub

#End Region

#Region "Functions"

    Private Function BuildUpScheduleOfRatesDataview() As DataView
        Dim newTable As New DataTable
        newTable.Columns.Add("ContractOriginalSiteRateID")
        newTable.Columns.Add("RateID")
        newTable.Columns.Add("ScheduleOfRatesCategoryID")
        newTable.Columns.Add("Category")
        newTable.Columns.Add("Code")
        newTable.Columns.Add("Description")
        newTable.Columns.Add("TimeInMins", GetType(Integer))
        newTable.Columns.Add("Price", GetType(Double))
        newTable.Columns.Add("Qty", GetType(Integer))
        newTable.Columns.Add("Updated")
        newTable.TableName = Entity.Sys.Enums.TableNames.tblContractOriginalSiteRates.ToString
        Return New DataView(newTable)
    End Function

    Private Function CalculateSiteTotal(ByVal SORPrice As Double) As Double
        Dim numberOfVisit As Integer = 0
        Select Case CType(Combo.GetSelectedItemValue(cboVisitFrequencyID), Entity.Sys.Enums.VisitFrequency)
            Case Entity.Sys.Enums.VisitFrequency.Annually
                numberOfVisit = 1
            Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                numberOfVisit = 2
            Case Entity.Sys.Enums.VisitFrequency.Monthly
                numberOfVisit = 12
            Case Entity.Sys.Enums.VisitFrequency.Quarterly
                numberOfVisit = 4
            Case Entity.Sys.Enums.VisitFrequency.Weekly
                numberOfVisit = 52
        End Select
        Return numberOfVisit * SORPrice
    End Function

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate

        If Visits2 Is Nothing Then
            Visits2 = DB.ContractVisits.GetAll_For_ContractSiteID(0) ' generate a grid
        End If

        If Not ID = 0 Then
            CurrentContractSite = DB.ContractOriginalSite.Get(ID)
            SiteID = CurrentContractSite.PropertyID
            CurrentContract.SetContractID = CurrentContractSite.ContractID
            dgVisitsSetup.DataSource = DB.ContractVisits.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID)
            Visits2 = DB.ContractVisits.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID)
        End If

        Me.dtpFirstVisitDate.Value = CurrentContractSite.FirstVisitDate
        Combo.SetSelectedComboItem_By_Value(Me.cboVisitFrequencyID, CurrentContractSite.VisitFrequencyID)
        Me.txtVisitDuration.Text = CurrentContractSite.VisitDuration

        Me.txtAdditionalNotes.Text = CurrentContractSite.AdditionalNotes
        Me.chkLLCertificateReqd.Checked = CurrentContractSite.LLCertReqd
        Me.chkCommercial.Checked = CurrentContractSite.Commercial

        Me.dgScheduleOfRates.DataSource = CurrentContractSite.ContractSiteScheduleOfRates
    End Sub

    Public Sub PopAssets()
        Assets = DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(CurrentContractSite.ContractSiteID, SiteID)

        If Not CurrentContractSite.Exists Then
            For Each dr As DataRow In Assets.Table.Rows
                dr("Tick") = True
            Next
        End If
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            If Not CurrentContractSite.ContractSiteScheduleOfRates.Table.Columns.Contains("Total") Then
                CurrentContractSite.ContractSiteScheduleOfRates.Table.Columns.Add(New DataColumn("Total", GetType(Double), "Price * Qty"))
                CurrentContractSite.ContractSiteScheduleOfRates.Table.AcceptChanges()
            End If

            Dim SORPrice As Double

            If IsDBNull(CurrentContractSite.ContractSiteScheduleOfRates.Table.Compute("SUM(Total)", "")) Then
                SORPrice = 0
            Else
                SORPrice = CurrentContractSite.ContractSiteScheduleOfRates.Table.Compute("SUM(Total)", "")
            End If

            Me.Cursor = Cursors.WaitCursor
            CurrentContractSite.IgnoreExceptionsOnSetMethods = True

            CurrentContractSite.SetPropertyID = SiteID
            CurrentContractSite.SetContractID = CurrentContract.ContractID
            CurrentContractSite.SetPricePerVisit = SORPrice
            CurrentContractSite.FirstVisitDate = Me.dtpFirstVisitDate.Value
            CurrentContractSite.SetVisitFrequencyID = Combo.GetSelectedItemValue(Me.cboVisitFrequencyID)
            If Combo.GetSelectedItemValue(Me.cboVisitFrequencyID) < 1 Then
                CurrentContractSite.SetVisitFrequencyID = 7 ' monthly
            End If

            'CurrentContractSite.SetVisitDuration = Combo.GetSelectedItemValue(cboVisitDuration)
            CurrentContractSite.SetVisitDuration = Me.txtVisitDuration.Text
            CurrentContractSite.SetAverageMileage = 0 ':removed at Robs request
            CurrentContractSite.SetIncludeAssetPrice = False
            CurrentContractSite.SetIncludeMileagePrice = False
            CurrentContractSite.SetTotalSitePrice = CalculateSiteTotal(SORPrice)
            CurrentContractSite.SetPricePerMile = 0 ':removed at Robs request
            CurrentContractSite.SetIncludeRates = True
            CurrentContractSite.SetLLCertReqd = Me.chkLLCertificateReqd.Checked
            CurrentContractSite.SetAdditionalNotes = Me.txtAdditionalNotes.Text
            CurrentContractSite.SetCommercial = Me.chkCommercial.Checked

            If Visits2.Table.Rows.Count < 1 Then
                Dim cV As New Entity.ContractOriginalSites.ContractOriginalSiteValidator
                cV.Validate(CurrentContractSite, CurrentContract)
            End If

            If CurrentContractSite.Exists Then 'UPDATE

                If ShowMessage("Are you sure you want to save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Function
                End If

                DB.ContractOriginalSite.Update(CurrentContractSite)

                'DELETE AND RE INSERT ASSET
                DB.ContractOriginalSiteAsset.Delete(CurrentContractSite.ContractSiteID)

                For Each drAsset As DataRow In Assets.Table.Rows
                    If Entity.Sys.Helper.MakeBooleanValid(drAsset("Tick")) = True Then

                        'NOW ADD TO CONTRACT SITE AS NORMAL
                        Dim ContractSiteAsset As New Entity.ContractOriginalSiteAssets.ContractOriginalSiteAsset
                        ContractSiteAsset.SetAssetID = drAsset("AssetID")
                        ContractSiteAsset.SetContractSiteID = CurrentContractSite.ContractSiteID
                        ContractSiteAsset.SetPricePerVisit = drAsset("PricePerVisit")
                        ContractSiteAsset = DB.ContractOriginalSiteAsset.Insert(ContractSiteAsset)
                    End If
                Next drAsset

                'NOW ADD THE AMEND THE ASSETS ON JOBS WHERE THE FIRST VISIT HAS NOT BEEN DOWNLOADED
                For Each drJob As DataRow In Visits.Table.Rows
                    Dim dtEngVisits As DataTable = DB.EngineerVisits.EngineerVisits_Get_All_JobID(drJob("JobID")).Table
                    If CType(dtEngVisits.Rows(0).Item("StatusEnumID"), Entity.Sys.Enums.VisitStatus) < Entity.Sys.Enums.VisitStatus.Downloaded Then
                        DB.JobAsset.Delete(drJob("JobID"))

                        'INSERT ANY ASSETS
                        For Each dr As DataRow In Assets.Table.Rows
                            If Entity.Sys.Helper.MakeBooleanValid(dr("Tick")) = True Then
                                Dim JobAsset As New Entity.JobAssets.JobAsset
                                JobAsset.SetAssetID = dr("AssetID")
                                JobAsset.SetJobID = drJob("JobID")
                                JobAsset = DB.JobAsset.Insert(JobAsset)
                            End If
                        Next
                    End If

                Next drJob

                Assets = DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(CurrentContractSite.ContractSiteID, SiteID)

                For Each drRate As DataRow In CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows
                    If drRate("Updated") = True Then
                        Dim contractSOR As New Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates
                        contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID
                        contractSOR.SetContractOriginalSiteRateID = drRate("ContractOriginalSiteRateID")
                        contractSOR.SetQty = drRate("Qty")
                        contractSOR.SetRateID = drRate("RateID")
                        DB.ContractOriginalSiteRates.Update(contractSOR)
                    Else
                        If Entity.Sys.Helper.MakeIntegerValid(drRate("ContractOriginalSiteRateID")) = 0 Then
                            Dim contractSOR As New Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates
                            contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID
                            contractSOR.SetQty = drRate("Qty")
                            contractSOR.SetRateID = drRate("RateID")
                            DB.ContractOriginalSiteRates.Insert(contractSOR)
                        End If
                    End If
                Next

                Dim st As String = ""
                Dim ii As Integer = 0

                For Each dr As DataRow In Visits2.Table.Rows
                    ii += 1
                    DB.ContractVisits.Delete(dr("ContractVisitID"))
                    Dim r As Integer = DB.ExecuteScalar("SELECT COUNT(*) FROM tblContractVisits WHERE ContractVisitID = " & dr("ContractVisitID"))
                    If r > 0 Then '
                        ' it has been moved on too far
                        st += "row " & ii & "couldn't be ammended as its gone past scheduled " & vbNewLine
                    Else
                        'it has been removed so please remove ppm
                        DB.ContractOriginalSite.Delete_Visits(dr("ContractSiteID"))
                        ' then re add the visit
                        ScheduleSingleRow(dr)
                    End If
                Next

                If Visits Is Nothing OrElse Visits.Table.Rows.Count = 0 Then
                    ScheduleJob()
                End If

                If st.ToString.Length > 0 Then
                    ShowMessage(st, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else 'INSERT

                If ShowMessage("Are you sure you want to save?" & vbCrLf & "Information cannot be altered after save and jobs will be scheduled", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Function
                End If

                CurrentContractSite = DB.ContractOriginalSite.Insert(CurrentContractSite)

                'DELETE AND RE INSERT ASSET
                DB.ContractOriginalSiteAsset.Delete(CurrentContractSite.ContractSiteID)

                For Each drAsset As DataRow In Assets.Table.Rows
                    If Entity.Sys.Helper.MakeBooleanValid(drAsset("Tick")) = True Then
                        Dim ContractSiteAsset As New Entity.ContractOriginalSiteAssets.ContractOriginalSiteAsset
                        ContractSiteAsset.SetAssetID = drAsset("AssetID")
                        ContractSiteAsset.SetContractSiteID = CurrentContractSite.ContractSiteID
                        ContractSiteAsset.SetPricePerVisit = drAsset("PricePerVisit")
                        ContractSiteAsset = DB.ContractOriginalSiteAsset.Insert(ContractSiteAsset)
                    End If
                Next drAsset

                For Each drRate As DataRow In CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows
                    If drRate("Updated") = True Then
                        Dim contractSOR As New Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates
                        contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID
                        contractSOR.SetContractOriginalSiteRateID = drRate("ContractOriginalSiteRateID")
                        contractSOR.SetQty = drRate("Qty")
                        contractSOR.SetRateID = drRate("RateID")
                        DB.ContractOriginalSiteRates.Update(contractSOR)
                    Else
                        If Entity.Sys.Helper.MakeIntegerValid(drRate("ContractOriginalSiteRateID")) = 0 Then
                            Dim contractSOR As New Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates
                            contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID
                            contractSOR.SetQty = drRate("Qty")
                            contractSOR.SetRateID = drRate("RateID")
                            DB.ContractOriginalSiteRates.Insert(contractSOR)
                        End If
                    End If
                Next

                If Visits Is Nothing OrElse Visits.Table.Rows.Count = 0 Then
                    ScheduleJob()
                End If
            End If

            RaiseEvent StateChanged(CurrentContractSite.ContractSiteID)

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

    Private Sub ScheduleJob()
        Try
            Dim contractDuration As Integer

            'New Way
            Dim startDate As DateTime = Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") & " 00:00:00"
            Dim endDate As DateTime = Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") & " 00:00:00"
            contractDuration = endDate.Subtract(startDate).Days
            Dim M As Integer = Math.Abs((startDate.Year - endDate.Year))
            Dim months As Integer = ((M * 12) + Math.Abs((startDate.Month - endDate.Month)))
            Dim days As Integer = endDate.Subtract(startDate).Days

            'How Visit Should happen in days ' NOOOOOOO
            Dim numOfVisits As Integer = 0
            Dim visitFreqInMonths As Integer = 0
            Dim visitFreqIndays As Integer = 0

            Select Case CType(CurrentContractSite.VisitFrequencyID, Entity.Sys.Enums.VisitFrequency)
                Case Entity.Sys.Enums.VisitFrequency.Annually
                    visitFreqInMonths = 12
                Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                    visitFreqInMonths = 6
                Case Entity.Sys.Enums.VisitFrequency.Monthly
                    visitFreqInMonths = 1
                Case Entity.Sys.Enums.VisitFrequency.Quarterly
                    visitFreqInMonths = 3
                Case Entity.Sys.Enums.VisitFrequency.GBS_4_Month_Visits
                    visitFreqInMonths = 4
                Case Entity.Sys.Enums.VisitFrequency.Fortnightly
                    visitFreqIndays = 14
            End Select

            If visitFreqIndays = 0 Then
                numOfVisits = Math.Floor(months / visitFreqInMonths)
                If numOfVisits = 0 Then
                    numOfVisits = 1
                End If
            ElseIf visitFreqIndays > 0 Then
                numOfVisits = Math.Floor(days / visitFreqIndays)
                If numOfVisits = 0 Then
                    numOfVisits = 1
                End If
            End If

            Dim estVisitDate As DateTime = dtpFirstVisitDate.Value.Date & " 09:00:00"

            Dim jobSummary As String = String.Empty
            Dim rateCount As Integer = 0
            For Each rateRow As DataRow In CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows
                If rateCount > 0 Then
                    jobSummary += " And "
                End If
                If rateRow("Qty") > 1 Then
                    jobSummary += rateRow("Qty") & " x " & rateRow("Description")
                Else
                    jobSummary += rateRow("Description")
                End If
                rateCount += 1
            Next

            If CurrentContractSite.LLCertReqd = True Then
                If jobSummary.Length > 0 Then
                    jobSummary += ". "
                End If
                jobSummary += "Landlord Certificate Required"
            End If

            If jobSummary.Length > 0 Then
                jobSummary += ". "
            End If

            jobSummary += CurrentContractSite.AdditionalNotes

            If CDate(Format(estVisitDate, "dd/MM/yyyy") & " 00:00:00") _
                        >= CDate(Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") & " 00:00:00") _
                            And CDate(Format(estVisitDate, "dd/MM/yyyy") & " 00:00:00") _
                        <= CDate(Format(CurrentContract.ContractEndDate, "dd/MM/yyyy") & " 00:00:00") Then

                'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                If estVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                    estVisitDate = estVisitDate.AddDays(2)
                ElseIf estVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                    estVisitDate = estVisitDate.AddDays(1)
                End If

                'CREATE JOB
                Dim job As New Entity.Jobs.Job
                job.SetPropertyID = CurrentContractSite.PropertyID
                job.SetJobDefinitionEnumID = CInt(Entity.Sys.Enums.JobDefinition.Contract)
                If chkCommercial.Checked Then
                    job.SetJobTypeID = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Commercial'")(0).Item("ManagerID")
                ElseIf chkLLCertificateReqd.Checked Then
                    job.SetJobTypeID = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service and Certificate'")(0).Item("ManagerID")
                Else
                    job.SetJobTypeID = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")(0).Item("ManagerID")
                End If

                job.SetStatusEnumID = CInt(Entity.Sys.Enums.JobStatus.Open)
                job.SetCreatedByUserID = loggedInUser.UserID
                job.SetFOC = True
                Dim JobNumber As New JobNumber
                JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract)
                job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
                job.SetPONumber = ""
                job.SetQuoteID = 0
                job.SetContractID = CurrentContract.ContractID

                If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                    job.SetDeleted = True
                End If

                'INSERT ANY ASSETS
                For Each dr As DataRow In Assets.Table.Rows
                    If Entity.Sys.Helper.MakeBooleanValid(dr("Tick")) = True Then
                        Dim JobAsset As New Entity.JobAssets.JobAsset
                        JobAsset.SetAssetID = dr("AssetID")
                        job.Assets.Add(JobAsset)
                    End If
                Next

                '  INSERT JOB ITEM
                Dim jobOfWork As New Entity.JobOfWorks.JobOfWork
                jobOfWork.SetPONumber = ""
                jobOfWork.IgnoreExceptionsOnSetMethods = True
                If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                    jobOfWork.SetDeleted = True
                End If

                For Each sorRow As DataRow In CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows
                    Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(sorRow("ScheduleOfRatesCategoryID"), sorRow("Description"), sorRow("Code"), Site.CustomerID)
                    Dim customerSorId As Integer = 0
                    If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors.Rows(0).Item(0))

                    If Not customerSorId > 0 Then
                        Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                                .SetCode = sorRow("Code"),
                                .SetDescription = sorRow("Description"),
                                .SetPrice = sorRow("Price"),
                                .SetScheduleOfRatesCategoryID = sorRow("ScheduleOfRatesCategoryID"),
                                .SetTimeInMins = sorRow("TimeInMins"),
                                .SetCustomerID = Site.CustomerID
                            }
                        customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
                        DB.CustomerScheduleOfRate.Delete(customerSorId)
                    End If

                    Dim jobItem As New JobItems.JobItem
                    jobItem.IgnoreExceptionsOnSetMethods = True
                    jobItem.SetSummary = sorRow("Description")
                    jobItem.SetQty = 1
                    jobItem.SetRateID = customerSorId
                    jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
                    jobOfWork.JobItems.Add(jobItem)

                Next

                If jobOfWork.JobItems.Count = 0 Then
                    Dim jobItem As New Entity.JobItems.JobItem
                    jobItem.IgnoreExceptionsOnSetMethods = True
                    jobItem.SetSummary = jobSummary

                    jobOfWork.JobItems.Add(jobItem)
                End If

                'IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                Dim engineerVisit As New Entity.EngineerVisits.EngineerVisit
                engineerVisit.IgnoreExceptionsOnSetMethods = True
                engineerVisit.SetEngineerID = 0 'engineerID

                engineerVisit.SetNotesToEngineer = jobSummary

                engineerVisit.StartDateTime = DateTime.MinValue
                engineerVisit.EndDateTime = DateTime.MinValue
                engineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
                'End If

                If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                    engineerVisit.SetDeleted = True
                End If

                jobOfWork.EngineerVisits.Add(engineerVisit)

                job.JobOfWorks.Add(jobOfWork)
                job = DB.Job.Insert(job)

                'CREATE PPM VISIT RECORD
                Dim PPM As New Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisit
                PPM.SetContractSiteID = CurrentContractSite.ContractSiteID
                PPM.EstimatedVisitDate = estVisitDate
                PPM.SetJobID = job.JobID
                DB.ContractOriginalPPMVisit.Insert(PPM)
                If visitFreqIndays = 0 Then
                    estVisitDate = estVisitDate.AddMonths(visitFreqInMonths)
                ElseIf visitFreqIndays > 0 Then
                    estVisitDate = estVisitDate.AddDays(visitFreqIndays)
                End If

            End If
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub ScheduleSingleRow(ByVal dr As DataRow)
        Try

            'Duration OF Contract In Days
            Dim contractDuration As Integer
            'contractDuration = CurrentContract.ContractEndDate.Subtract(CurrentContract.ContractStartDate).Days

            'New Way
            Dim startDate As DateTime = Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") & " 00:00:00"
            Dim endDate As DateTime = Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") & " 00:00:00"
            contractDuration = endDate.Subtract(startDate).Days
            Dim M As Integer = Math.Abs((startDate.Year - endDate.Year))
            Dim months As Integer = ((M * 12) + Math.Abs((startDate.Month - endDate.Month)))
            Dim days As Integer = endDate.Subtract(startDate).Days

            'How Visit Should happen in days ' NOOOOOOO
            Dim numOfVisits As Integer = 0
            Dim visitFreqInMonths As Integer = 0
            Dim visitFreqIndays As Integer = 0

            Dim estVisitDate As DateTime = Today.Date & " 09:00:00"
            Dim visitFrequency As Entity.Sys.Enums.VisitFrequency = CType(dr("FrequencyID"), Entity.Sys.Enums.VisitFrequency)
            Select Case visitFrequency
                Case Entity.Sys.Enums.VisitFrequency.Annually
                    visitFreqInMonths = 12
                    estVisitDate = dr("VisitDate").Date & " 9:00:00"
                Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                    visitFreqInMonths = 6
                    estVisitDate = CurrentContract.ContractStartDate.AddMonths(6)
                Case Entity.Sys.Enums.VisitFrequency.Monthly
                    visitFreqInMonths = 1
                    estVisitDate = CurrentContract.ContractStartDate.AddMonths(1)
                Case Entity.Sys.Enums.VisitFrequency.Quarterly
                    visitFreqInMonths = 3
                    estVisitDate = CurrentContract.ContractStartDate.AddMonths(3)
                Case Entity.Sys.Enums.VisitFrequency.GBS_4_Month_Visits
                    visitFreqInMonths = 4
                    estVisitDate = CurrentContract.ContractStartDate.AddMonths(4)
                Case Entity.Sys.Enums.VisitFrequency.Fortnightly
                    visitFreqIndays = 14
                    estVisitDate = CurrentContract.ContractStartDate.AddDays(14)
            End Select

            If visitFreqIndays = 0 Then
                numOfVisits = Math.Floor(months / visitFreqInMonths)
                If numOfVisits = 0 Then
                    numOfVisits = 1
                End If
            ElseIf visitFreqIndays > 0 Then
                numOfVisits = Math.Floor(days / visitFreqIndays)
                If numOfVisits = 0 Then
                    numOfVisits = 1
                End If
            End If

            Dim jobSummary As String = String.Empty
            Dim rateCount As Integer = 0

            Dim time As Integer = dr("HoursReq")

            'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
            If estVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                estVisitDate = estVisitDate.AddDays(2)
            ElseIf estVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                estVisitDate = estVisitDate.AddDays(1)
            End If

            'CREATE JOB
            Dim job As New Entity.Jobs.Job
            job.SetPropertyID = CurrentContractSite.PropertyID
            job.SetJobDefinitionEnumID = CInt(Entity.Sys.Enums.JobDefinition.Contract)

            'If chkCommercial.Checked Then

            job.SetJobTypeID = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Commercial'")(0).Item("ManagerID")

            job.SetStatusEnumID = CInt(Entity.Sys.Enums.JobStatus.Open)
            job.SetCreatedByUserID = loggedInUser.UserID
            job.SetFOC = True
            Dim JobNumber As New JobNumber
            JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract)
            job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
            job.SetPONumber = ""
            job.SetQuoteID = 0
            job.SetContractID = CurrentContract.ContractID

            'INSERT ANY ASSETS
            For Each dr2 As DataRow In Assets.Table.Rows
                If Entity.Sys.Helper.MakeBooleanValid(dr2("Tick")) = True Then
                    Dim JobAsset As New Entity.JobAssets.JobAsset
                    JobAsset.SetAssetID = dr2("AssetID")
                    job.Assets.Add(JobAsset)
                End If
            Next

            While time > 0

                '  INSERT JOB ITEM
                Dim jobOfWork As New Entity.JobOfWorks.JobOfWork
                jobOfWork.SetPONumber = ""
                jobOfWork.IgnoreExceptionsOnSetMethods = True
                If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                    jobOfWork.SetDeleted = True
                End If

                Dim description As String = ""

                If dr("VisitType") = "SubContractor" Then
                    description = dr("SubContractor").ToString & " "
                Else
                    description = dr("VisitType") & " Service "
                End If

                Select Case visitFrequency

                    Case Entity.Sys.Enums.VisitFrequency.Annually
                        description += "Annual Visit. "
                    Case Else
                        description += dr("Frequency") & " Visit. "

                End Select

                Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(4701, "Contracted Visit", "C3", Site.CustomerID)
                Dim customerSorId As Integer = 0
                If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors.Rows(0)(0))

                If Not customerSorId > 0 Then
                    Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                            .SetCode = "C3",
                            .SetDescription = "Contracted Visit",
                            .SetPrice = 0,
                            .SetScheduleOfRatesCategoryID = 4701,
                            .SetTimeInMins = 60,
                            .SetCustomerID = Site.CustomerID
                        }
                    customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
                End If

                Dim jobitemtime As Integer = 0

                If time < 8.1 Then
                    jobitemtime = time
                    time = 0
                Else
                    jobitemtime = 8
                    time = time - 8

                End If

                Dim jobItem As New Entity.JobItems.JobItem
                jobItem.IgnoreExceptionsOnSetMethods = True
                jobItem.SetSummary = description
                jobItem.SetQty = jobitemtime
                jobItem.SetRateID = customerSorId
                jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
                jobOfWork.JobItems.Add(jobItem)

                'IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                Dim engineerVisit As New Entity.EngineerVisits.EngineerVisit
                engineerVisit.IgnoreExceptionsOnSetMethods = True
                engineerVisit.SetEngineerID = 0 'engineerID

                description += dr("AdditionalNotes")
                engineerVisit.SetNotesToEngineer = description

                engineerVisit.StartDateTime = DateTime.MinValue
                engineerVisit.EndDateTime = DateTime.MinValue
                engineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)

                jobOfWork.EngineerVisits.Add(engineerVisit)

                job.JobOfWorks.Add(jobOfWork)

            End While

            job = DB.Job.Insert(job)

            'CREATE PPM VISIT RECORD
            Dim PPM As New Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisit
            PPM.SetContractSiteID = CurrentContractSite.ContractSiteID
            PPM.EstimatedVisitDate = estVisitDate
            PPM.SetJobID = job.JobID
            DB.ContractOriginalPPMVisit.Insert(PPM)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''UPDATE VISIT DATE IN tblContractVisits''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim contractVisit As New Entity.ContractOriginalVisits.ContractOriginalVisit

            contractVisit.SetAdditionalNotes = dr("AdditionalNotes")
            contractVisit.SetContractSiteID = CurrentContractSite.ContractSiteID
            contractVisit.SetCost = dr("Cost")
            contractVisit.EstimatedVisitDate = estVisitDate
            contractVisit.SetFrequency = dr("Frequency")
            contractVisit.SetFrequencyID = dr("FrequencyID")
            contractVisit.SetHoursReq = dr("HoursReq")
            contractVisit.SetJobID = job.JobID
            contractVisit.SetPreferredEngineer = dr("PreferredEngineer")
            contractVisit.SetPreferredEngineerID = dr("PreferredEngineerID")
            contractVisit.SetSubContractor = dr("SubContractor")
            contractVisit.SetSubContractorID = dr("SubContractorID")
            contractVisit.SetVisitType = dr("VisitType")
            contractVisit.SetVisitTypeID = dr("VisitTypeID")

            DB.ContractVisits.Insert(contractVisit)

            If visitFreqIndays = 0 Then
                estVisitDate = estVisitDate.AddMonths(visitFreqInMonths)
            ElseIf visitFreqIndays > 0 Then
                estVisitDate = estVisitDate.AddDays(visitFreqIndays)
            End If
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Function MatchingEngineer(ByVal job As Entity.Jobs.Job, ByVal estVisitDate As DateTime) As ArrayList
        Dim site As New Entity.Sites.Site
        Dim engineerID As Integer = 0
        Dim slotDuration As Integer = 0 'MINTUES
        Dim visitDuration As Integer = 0
        Dim numOfSlotsNeeded As Integer = 0
        Dim match As New ArrayList
        Dim postcode As String = ""
        Dim postcodeEngineers As DataView = Nothing
        Dim cntPostcodeEng As Integer = 0
        Dim randomNum As Integer = 0

        'SYSTEM NUMBER OF MINUTES IN A SLOTS
        slotDuration = DB.Manager.Get.TimeSlot

        'VISIT DURATION FOR THIS SITE IN HOURS
        visitDuration = txtVisitDuration.Text 'Combo.GetSelectedItemValue(cboVisitDuration)

        'NUM OF SLOTS NEEDED FOR VISIT
        If visitDuration > 0 Then
            numOfSlotsNeeded = visitDuration / slotDuration
        End If
        '***************************************************************

        'SEE IF THE SITE HAS A DEFAULT ENGINEER
        site = DB.Sites.Get(job.PropertyID)

        If site.EngineerID > 0 Then
            'IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
            match = CheckAvailability(estVisitDate, site.EngineerID, numOfSlotsNeeded)
        End If
        'IF A ENG & SLOT IS FOUND, RETURN
        If match.Count > 0 Then
            Return match
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

                match = CheckAvailability(estVisitDate _
                                            , postcodeEngineers.Table.Rows(randomNum).Item("EngineerID") _
                                            , numOfSlotsNeeded)
                'IF A ENG & SLOT IS FOUND, RETURN
                If match.Count > 0 Then
                    Return match
                Else
                    postcodeEngineers.Table.Rows.Remove(postcodeEngineers.Table.Rows(randomNum))
                End If

            Next i
        End If
        Return match
    End Function

    Private Function CheckAvailability(ByVal estimatedVisitDate As DateTime,
                                         ByVal engineerID As Integer,
                                         ByVal numOfSlotsNeeded As Integer) As ArrayList

        Dim engTimeSlots As DataTable
        Dim numOfSlotsAvailable As New ArrayList
        Dim actualVisitDate As DateTime = estimatedVisitDate
        Dim match As New ArrayList
        Dim startSlotTime As String = ""

        For day As Integer = 0 To 4
            numOfSlotsAvailable.Clear()

            'ADD ON DAYS - UNLESS FIRST TIME IN
            If day <> 0 Then
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
                        If numOfSlotsAvailable.Count = numOfSlotsNeeded Then
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

                If numOfSlotsAvailable.Count = numOfSlotsNeeded Or
                    numOfSlotsAvailable(0) = DB.Manager.Get.WorkingHoursStart() Then

                    'IF THERE ARE ENOUGH AVAILABLE CONSECTUTIVE SLOTS ADD THE START TIME ONTO THE DATE

                    If numOfSlotsAvailable(0) = DB.Manager.Get.WorkingHoursStart() Then
                        startSlotTime = numOfSlotsAvailable(0)
                    Else
                        startSlotTime = Replace(numOfSlotsAvailable(0), "T", "").Insert(2, ":")
                    End If
                    actualVisitDate = CDate(Format(actualVisitDate, "dd/MM/yyyy") & " " & startSlotTime)

                    match.Add(actualVisitDate)
                    match.Add(engineerID)
                    Return (match)
                End If

            End If
        Next day
        Return (match)

    End Function

#End Region

    Private Sub btnAddVisit_Click(sender As Object, e As EventArgs) Handles btnAddVisit.Click
        Dim dt As New DataTable

        If Visits2 Is Nothing Then
            Visits2 = DB.ContractVisits.GetAll_For_ContractSiteID(0) ' generate a grid
        End If

        dt = Visits2.Table

        Dim f As DLGSetupVisit = New DLGSetupVisit

        f.ShowDialog()

        If f.DialogResult = DialogResult.OK Then
            Dim dr As DataRow = dt.NewRow

            dr("SubContractor") = Combo.GetSelectedItemDescription(f.cboSubContractor)
            dr("PreferredEngineer") = Combo.GetSelectedItemDescription(f.cboPreferredEngineer)
            dr("VisitType") = Combo.GetSelectedItemDescription(f.cboType)
            dr("Frequency") = Combo.GetSelectedItemDescription(f.cboFrequency)

            dr("VisitTypeID") = Combo.GetSelectedItemValue(f.cboType)
            dr("VisitDate") = f.dtpTargetDate.Value
            dr("FrequencyID") = Combo.GetSelectedItemValue(f.cboFrequency)
            dr("Cost") = f.txtFilter.Text.Replace("£", "")
            dr("SubContractorID") = Combo.GetSelectedItemValue(f.cboSubContractor)
            dr("PreferredEngineerID") = Combo.GetSelectedItemValue(f.cboPreferredEngineer)
            dr("HoursReq") = f.TextBox1.Text
            dr("AdditionalNotes") = f.txtAdditional.Text

            If Combo.GetSelectedItemValue(f.cboPreferredEngineer) > 0 Then
                dr("EngName") = Combo.GetSelectedItemDescription(f.cboPreferredEngineer)
            End If
            If Combo.GetSelectedItemValue(f.cboSubContractor) > 0 Then
                dr("EngName") = Combo.GetSelectedItemDescription(f.cboSubContractor)
            End If

            dt.Rows.Add(dr)

            dgVisitsSetup.DataSource = dt
            Visits2.Table = dt

        End If

    End Sub

    Private Sub btRemoveVisit_Click(sender As Object, e As EventArgs) Handles btRemoveVisit.Click

        If Not SelectedVisitDataRow2 Is Nothing Then
            With SelectedVisitDataRow2

                If MessageBox.Show("DELETE :" & .Item("VisitType"), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    'REMOVE

                    If IsDBNull(SelectedVisitDataRow2("ContractVisitID")) OrElse SelectedVisitDataRow2("ContractVisitID") < 1 Then
                        ' not in DB
                        Visits2.Table.Rows.Remove(SelectedVisitDataRow2)
                    Else
                        'In DB
                        DB.ContractVisits.Delete(SelectedVisitDataRow2("ContractVisitID"))
                        Visits2 = DB.ContractVisits.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID)
                    End If

                    dgVisitsSetup.DataSource = Visits2
                End If
            End With
        End If
    End Sub

End Class