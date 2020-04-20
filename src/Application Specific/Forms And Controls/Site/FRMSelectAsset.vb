Public Class FRMSelectAsset : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgAssets As System.Windows.Forms.DataGrid
    Friend WithEvents chkCERT2 As System.Windows.Forms.CheckBox
    Friend WithEvents btnNoAsset As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgAssets = New System.Windows.Forms.DataGrid()
        Me.btnNoAsset = New System.Windows.Forms.Button()
        Me.chkCERT2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Please select an Appliance to be serviced"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(480, 312)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgAssets)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 243)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'dgAssets
        '
        Me.dgAssets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAssets.DataMember = ""
        Me.dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAssets.Location = New System.Drawing.Point(8, 18)
        Me.dgAssets.Name = "dgAssets"
        Me.dgAssets.Size = New System.Drawing.Size(528, 217)
        Me.dgAssets.TabIndex = 0
        '
        'btnNoAsset
        '
        Me.btnNoAsset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNoAsset.Location = New System.Drawing.Point(8, 312)
        Me.btnNoAsset.Name = "btnNoAsset"
        Me.btnNoAsset.Size = New System.Drawing.Size(94, 23)
        Me.btnNoAsset.TabIndex = 6
        Me.btnNoAsset.Text = "No Appliance"
        Me.btnNoAsset.Visible = False
        '
        'chkCERT2
        '
        Me.chkCERT2.AutoSize = True
        Me.chkCERT2.Location = New System.Drawing.Point(229, 316)
        Me.chkCERT2.Name = "chkCERT2"
        Me.chkCERT2.Size = New System.Drawing.Size(91, 17)
        Me.chkCERT2.TabIndex = 7
        Me.chkCERT2.Text = "Certificate?"
        Me.chkCERT2.UseVisualStyleBackColor = True
        Me.chkCERT2.Checked = True
        '
        'FRMSelectAsset
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(560, 342)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkCERT2)
        Me.Controls.Add(Me.btnNoAsset)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(568, 376)
        Me.Name = "FRMSelectAsset"
        Me.Text = "Select an Appliance"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnNoAsset, 0)
        Me.Controls.SetChildIndex(Me.chkCERT2, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupAssetDataGrid()
        AssetsDataview = DB.Asset.Asset_GetForSite(SiteID)

        AssetsDataview.AllowNew = True
        Dim newrow As DataRowView = AssetsDataview.AddNew

        newrow("Product") = "Boiler - Unknown"
        newrow("AssetID") = 2
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Storage Boiler - Unknown"
        newrow("AssetID") = 3
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Oil Boiler - Unknown"
        newrow("AssetID") = 4
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Gas Fire - Unknown"
        newrow("AssetID") = 5
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Unit Heater - Unknown"
        newrow("AssetID") = 6
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Large Unit Heater - Unknown"
        newrow("AssetID") = 7
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Water Heater - Unknown"
        newrow("AssetID") = 8
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Unvented Cylinder - Unknown"
        newrow("AssetID") = 9
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Unvented Cylinder - Unknown"
        newrow("AssetID") = 9
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Cooker - Unknown"
        newrow("AssetID") = 10
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Hob - Unknown"
        newrow("AssetID") = 11
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Warm Air Unit - Unknown"
        newrow("AssetID") = 12
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Air Source - Unknown"
        newrow("AssetID") = 13
        newrow.EndEdit()
        newrow = AssetsDataview.AddNew
        newrow("Product") = "Range Cooker - Unknown"
        newrow("AssetID") = 14
        newrow.EndEdit()


        dgAssets.DataSource = AssetsDataview


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

    Private _SiteID As Integer
    Public Property SiteID() As Integer
        Get
            Return _SiteID
        End Get
        Set(ByVal Value As Integer)
            _SiteID = Value
        End Set
    End Property

    Private _dvAssets As DataView
    Private Property AssetsDataview() As DataView
        Get
            Return _dvAssets
        End Get
        Set(ByVal value As DataView)
            _dvAssets = value
            _dvAssets.AllowNew = False
            _dvAssets.AllowEdit = False
            _dvAssets.AllowDelete = False
            _dvAssets.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString
            Me.dgAssets.DataSource = AssetsDataview
        End Set
    End Property

    Public ReadOnly Property SelectedAssetDataRow() As DataRow
        Get
            If Not Me.dgAssets.CurrentRowIndex = -1 Then
                Return AssetsDataview(Me.dgAssets.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"
    Public Sub SetupAssetDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgAssets)
        Dim tStyle As DataGridTableStyle = Me.dgAssets.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim AssetID As New DataGridLabelColumn
        AssetID.Format = ""
        AssetID.FormatInfo = Nothing
        AssetID.HeaderText = "AssetID"
        AssetID.MappingName = "AssetID"
        AssetID.ReadOnly = True

        AssetID.Width = 0
        AssetID.NullText = ""
        tStyle.GridColumnStyles.Add(AssetID)


        Dim AssetDescription As New DataGridLabelColumn
        AssetDescription.Format = ""
        AssetDescription.FormatInfo = Nothing
        AssetDescription.HeaderText = "Product"
        AssetDescription.MappingName = "Product"
        AssetDescription.ReadOnly = True
        AssetDescription.Width = 250
        AssetDescription.NullText = ""
        tStyle.GridColumnStyles.Add(AssetDescription)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 100
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        'Dim SerialNumber As New DataGridLabelColumn
        'SerialNumber.Format = ""
        'SerialNumber.FormatInfo = Nothing
        'SerialNumber.HeaderText = "SerialNumber"
        'SerialNumber.MappingName = "SerialNum"
        'SerialNumber.ReadOnly = True
        'SerialNumber.Width = 120
        'SerialNumber.NullText = ""
        'tStyle.GridColumnStyles.Add(SerialNumber)

        'Dim BoughtFrom As New DataGridLabelColumn
        'BoughtFrom.Format = ""
        'BoughtFrom.FormatInfo = Nothing
        'BoughtFrom.HeaderText = "Bought From"
        'BoughtFrom.MappingName = "BoughtFrom"
        'BoughtFrom.ReadOnly = True
        'BoughtFrom.Width = 100
        'BoughtFrom.NullText = ""
        'tStyle.GridColumnStyles.Add(BoughtFrom)

        'Dim SuppliedBy As New DataGridLabelColumn
        'SuppliedBy.Format = ""
        'SuppliedBy.FormatInfo = Nothing
        'SuppliedBy.HeaderText = "Supplied By"
        'SuppliedBy.MappingName = "SuppliedBy"
        'SuppliedBy.ReadOnly = True
        'SuppliedBy.Width = 100
        'SuppliedBy.NullText = ""
        'tStyle.GridColumnStyles.Add(SuppliedBy)

        'Dim DateFitted As New DataGridLabelColumn
        'DateFitted.Format = "dd/MMM/yyyy"
        'DateFitted.FormatInfo = Nothing
        'DateFitted.HeaderText = "Date Fitted"
        'DateFitted.MappingName = "DateFitted"
        'DateFitted.ReadOnly = True
        'DateFitted.Width = 100
        'DateFitted.NullText = ""
        'tStyle.GridColumnStyles.Add(DateFitted)

        'Dim LastServicedDate As New DataGridLabelColumn
        'LastServicedDate.Format = "dd/MMM/yyyy"
        'LastServicedDate.FormatInfo = Nothing
        'LastServicedDate.HeaderText = "Last Serviced Date"
        'LastServicedDate.MappingName = "LastServicedDate"
        'LastServicedDate.ReadOnly = True
        'LastServicedDate.Width = 100
        'LastServicedDate.NullText = ""
        'tStyle.GridColumnStyles.Add(LastServicedDate)

        'Dim CertLastIssued As New DataGridLabelColumn
        'CertLastIssued.Format = "dd/MMM/yyyy"
        'CertLastIssued.FormatInfo = Nothing
        'CertLastIssued.HeaderText = "Certificate Last Issued"
        'CertLastIssued.MappingName = "CertificateLastIssued"
        'CertLastIssued.ReadOnly = True
        'CertLastIssued.Width = 100
        'CertLastIssued.NullText = ""
        'tStyle.GridColumnStyles.Add(CertLastIssued)

        'Dim Notes As New DataGridLabelColumn
        'Notes.Format = "dd/MMM/yyyy"
        'Notes.FormatInfo = Nothing
        'Notes.HeaderText = "Notes"
        'Notes.MappingName = "Notes"
        'Notes.ReadOnly = True
        'Notes.Width = 100
        'Notes.NullText = ""
        'tStyle.GridColumnStyles.Add(Notes)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblAsset.ToString()
        Me.dgAssets.TableStyles.Add(tStyle)
    End Sub
#End Region

#Region "Events"
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If SelectedAssetDataRow Is Nothing Then
            ShowMessage("Please select an appliance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub dgAssets_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAssets.DoubleClick
        If SelectedAssetDataRow Is Nothing Then
            ShowMessage("Please select an appliance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub FRMChooseAsset_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnNoAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoAsset.Click
        Me.DialogResult = DialogResult.Yes
    End Sub
#End Region

End Class
