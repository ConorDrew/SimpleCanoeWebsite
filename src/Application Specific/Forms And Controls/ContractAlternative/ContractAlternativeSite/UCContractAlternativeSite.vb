Public Class UCContractAlternativeSite : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SetupAssetsDataGrid()
        SetupJobItemsDataGrid()
        Combo.SetUpCombo(Me.cboVisitFrequencyID, DynamicDataTables.VisitFrequency, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboVisitDuration, DynamicDataTables.VisitDuration(), "VisitDuration", "DisplayMember")
        cboVisitDuration.SelectedIndex = 0
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
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents lblSite As System.Windows.Forms.Label
    Friend WithEvents dgAssets As System.Windows.Forms.DataGrid
    Friend WithEvents grpVisits As System.Windows.Forms.GroupBox
    Friend WithEvents grpJobItems As System.Windows.Forms.GroupBox
    Friend WithEvents txtPricePerVisit As System.Windows.Forms.TextBox
    Friend WithEvents cboVisitDuration As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPricePerVisit As System.Windows.Forms.Label
    Friend WithEvents cboVisitFrequencyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisitFrequencyID As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents dgJobItems As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddToJobOfWork As System.Windows.Forms.Button
    Friend WithEvents TCJobsOfWork As System.Windows.Forms.TabControl
    Friend WithEvents btnRemoveJobOfWork As System.Windows.Forms.Button
    Friend WithEvents btnAddJobOfWork As System.Windows.Forms.Button
    Friend WithEvents txtDescriptionItem As System.Windows.Forms.TextBox
    Friend WithEvents gpJobItems As System.Windows.Forms.GroupBox
    Friend WithEvents grpJobItemAdd As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpContractSite = New System.Windows.Forms.GroupBox
        Me.gpJobItems = New System.Windows.Forms.GroupBox
        Me.dgJobItems = New System.Windows.Forms.DataGrid
        Me.btnAddToJobOfWork = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.txtSite = New System.Windows.Forms.TextBox
        Me.lblSite = New System.Windows.Forms.Label
        Me.grpVisits = New System.Windows.Forms.GroupBox
        Me.btnRemoveJobOfWork = New System.Windows.Forms.Button
        Me.btnAddJobOfWork = New System.Windows.Forms.Button
        Me.TCJobsOfWork = New System.Windows.Forms.TabControl
        Me.grpJobItemAdd = New System.Windows.Forms.GroupBox
        Me.cboVisitDuration = New System.Windows.Forms.ComboBox
        Me.cboVisitFrequencyID = New System.Windows.Forms.ComboBox
        Me.lblPricePerVisit = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescriptionItem = New System.Windows.Forms.TextBox
        Me.lblVisitFrequencyID = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.txtPricePerVisit = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgAssets = New System.Windows.Forms.DataGrid
        Me.grpJobItems = New System.Windows.Forms.GroupBox
        Me.grpContractSite.SuspendLayout()
        Me.gpJobItems.SuspendLayout()
        CType(Me.dgJobItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVisits.SuspendLayout()
        Me.grpJobItemAdd.SuspendLayout()
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpContractSite
        '
        Me.grpContractSite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContractSite.Controls.Add(Me.gpJobItems)
        Me.grpContractSite.Controls.Add(Me.txtSite)
        Me.grpContractSite.Controls.Add(Me.lblSite)
        Me.grpContractSite.Controls.Add(Me.grpVisits)
        Me.grpContractSite.Controls.Add(Me.grpJobItemAdd)
        Me.grpContractSite.Location = New System.Drawing.Point(7, 3)
        Me.grpContractSite.Name = "grpContractSite"
        Me.grpContractSite.Size = New System.Drawing.Size(971, 664)
        Me.grpContractSite.TabIndex = 1
        Me.grpContractSite.TabStop = False
        Me.grpContractSite.Text = "Main Details"
        '
        'gpJobItems
        '
        Me.gpJobItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpJobItems.Controls.Add(Me.dgJobItems)
        Me.gpJobItems.Controls.Add(Me.btnAddToJobOfWork)
        Me.gpJobItems.Controls.Add(Me.btnRemove)

        Me.gpJobItems.Location = New System.Drawing.Point(10, 146)
        Me.gpJobItems.Name = "gpJobItems"
        Me.gpJobItems.Size = New System.Drawing.Size(949, 107)
        Me.gpJobItems.TabIndex = 3
        Me.gpJobItems.TabStop = False
        Me.gpJobItems.Text = "Job Items "
        '
        'dgJobItems
        '
        Me.dgJobItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgJobItems.DataMember = ""
        Me.dgJobItems.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobItems.Location = New System.Drawing.Point(8, 17)
        Me.dgJobItems.Name = "dgJobItems"
        Me.dgJobItems.Size = New System.Drawing.Size(809, 85)
        Me.dgJobItems.TabIndex = 1
        '
        'btnAddToJobOfWork
        '
        Me.btnAddToJobOfWork.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddToJobOfWork.UseVisualStyleBackColor = True
        Me.btnAddToJobOfWork.Location = New System.Drawing.Point(820, 77)
        Me.btnAddToJobOfWork.Name = "btnAddToJobOfWork"
        Me.btnAddToJobOfWork.Size = New System.Drawing.Size(124, 23)
        Me.btnAddToJobOfWork.TabIndex = 2
        Me.btnAddToJobOfWork.Text = "Add To Job Of Work"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.UseVisualStyleBackColor = True
        Me.btnRemove.Location = New System.Drawing.Point(820, 17)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(124, 23)
        Me.btnRemove.TabIndex = 0
        Me.btnRemove.Text = "Remove"
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Location = New System.Drawing.Point(70, 18)
        Me.txtSite.Multiline = True
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSite.Size = New System.Drawing.Size(887, 21)
        Me.txtSite.TabIndex = 0
        Me.txtSite.Text = ""
        '
        'lblSite
        '
        Me.lblSite.Location = New System.Drawing.Point(15, 21)
        Me.lblSite.Name = "lblSite"
        Me.lblSite.Size = New System.Drawing.Size(52, 19)
        Me.lblSite.TabIndex = 33
        Me.lblSite.Text = "Property"
        '
        'grpVisits
        '
        Me.grpVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVisits.Controls.Add(Me.btnRemoveJobOfWork)
        Me.grpVisits.Controls.Add(Me.btnAddJobOfWork)
        Me.grpVisits.Controls.Add(Me.TCJobsOfWork)

        Me.grpVisits.Location = New System.Drawing.Point(10, 254)
        Me.grpVisits.Name = "grpVisits"
        Me.grpVisits.Size = New System.Drawing.Size(949, 403)
        Me.grpVisits.TabIndex = 4
        Me.grpVisits.TabStop = False
        Me.grpVisits.Text = "Jobs Of Work"
        '
        'btnRemoveJobOfWork
        '
        Me.btnRemoveJobOfWork.AccessibleDescription = "Remove Selected Job Of Work"
        Me.btnRemoveJobOfWork.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveJobOfWork.UseVisualStyleBackColor = True
        Me.btnRemoveJobOfWork.Location = New System.Drawing.Point(914, 16)
        Me.btnRemoveJobOfWork.Name = "btnRemoveJobOfWork"
        Me.btnRemoveJobOfWork.Size = New System.Drawing.Size(24, 23)
        Me.btnRemoveJobOfWork.TabIndex = 2
        Me.btnRemoveJobOfWork.Text = "-"
        '
        'btnAddJobOfWork
        '
        Me.btnAddJobOfWork.AccessibleDescription = "Add Job Of Work"
        Me.btnAddJobOfWork.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddJobOfWork.UseVisualStyleBackColor = True
        Me.btnAddJobOfWork.Location = New System.Drawing.Point(882, 16)
        Me.btnAddJobOfWork.Name = "btnAddJobOfWork"
        Me.btnAddJobOfWork.Size = New System.Drawing.Size(24, 23)
        Me.btnAddJobOfWork.TabIndex = 1
        Me.btnAddJobOfWork.Text = "+"
        '
        'TCJobsOfWork
        '
        Me.TCJobsOfWork.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TCJobsOfWork.Location = New System.Drawing.Point(8, 17)
        Me.TCJobsOfWork.Name = "TCJobsOfWork"
        Me.TCJobsOfWork.SelectedIndex = 0
        Me.TCJobsOfWork.Size = New System.Drawing.Size(933, 381)
        Me.TCJobsOfWork.TabIndex = 0
        '
        'grpJobItemAdd
        '
        Me.grpJobItemAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobItemAdd.Controls.Add(Me.cboVisitDuration)
        Me.grpJobItemAdd.Controls.Add(Me.cboVisitFrequencyID)
        Me.grpJobItemAdd.Controls.Add(Me.lblPricePerVisit)
        Me.grpJobItemAdd.Controls.Add(Me.Label2)
        Me.grpJobItemAdd.Controls.Add(Me.txtDescriptionItem)
        Me.grpJobItemAdd.Controls.Add(Me.lblVisitFrequencyID)
        Me.grpJobItemAdd.Controls.Add(Me.btnAdd)
        Me.grpJobItemAdd.Controls.Add(Me.txtPricePerVisit)
        Me.grpJobItemAdd.Controls.Add(Me.Label1)
        Me.grpJobItemAdd.Controls.Add(Me.dgAssets)

        Me.grpJobItemAdd.Location = New System.Drawing.Point(10, 41)
        Me.grpJobItemAdd.Name = "grpJobItemAdd"
        Me.grpJobItemAdd.Size = New System.Drawing.Size(949, 106)
        Me.grpJobItemAdd.TabIndex = 2
        Me.grpJobItemAdd.TabStop = False
        Me.grpJobItemAdd.Text = "Add Job Items"
        '
        'cboVisitDuration
        '
        Me.cboVisitDuration.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVisitDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitDuration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVisitDuration.ItemHeight = 13
        Me.cboVisitDuration.Location = New System.Drawing.Point(360, 52)
        Me.cboVisitDuration.Name = "cboVisitDuration"
        Me.cboVisitDuration.Size = New System.Drawing.Size(95, 21)
        Me.cboVisitDuration.TabIndex = 2
        Me.cboVisitDuration.Tag = "ContractSite.VisitDuration"
        '
        'cboVisitFrequencyID
        '
        Me.cboVisitFrequencyID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVisitFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitFrequencyID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVisitFrequencyID.ItemHeight = 13
        Me.cboVisitFrequencyID.Location = New System.Drawing.Point(127, 52)
        Me.cboVisitFrequencyID.Name = "cboVisitFrequencyID"
        Me.cboVisitFrequencyID.Size = New System.Drawing.Size(136, 21)
        Me.cboVisitFrequencyID.TabIndex = 1
        Me.cboVisitFrequencyID.Tag = "ContractSite.VisitFrequencyID"
        '
        'lblPricePerVisit
        '
        Me.lblPricePerVisit.BackColor = System.Drawing.Color.White
        Me.lblPricePerVisit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPricePerVisit.Location = New System.Drawing.Point(9, 82)
        Me.lblPricePerVisit.Name = "lblPricePerVisit"
        Me.lblPricePerVisit.Size = New System.Drawing.Size(118, 20)
        Me.lblPricePerVisit.TabIndex = 31
        Me.lblPricePerVisit.Text = "Item Price Per Visit"
        Me.lblPricePerVisit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Description"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescriptionItem
        '
        Me.txtDescriptionItem.Location = New System.Drawing.Point(127, 19)
        Me.txtDescriptionItem.Multiline = True
        Me.txtDescriptionItem.Name = "txtDescriptionItem"
        Me.txtDescriptionItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescriptionItem.Size = New System.Drawing.Size(328, 25)
        Me.txtDescriptionItem.TabIndex = 0
        Me.txtDescriptionItem.Text = ""
        '
        'lblVisitFrequencyID
        '
        Me.lblVisitFrequencyID.BackColor = System.Drawing.Color.White
        Me.lblVisitFrequencyID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVisitFrequencyID.Location = New System.Drawing.Point(9, 52)
        Me.lblVisitFrequencyID.Name = "lblVisitFrequencyID"
        Me.lblVisitFrequencyID.Size = New System.Drawing.Size(94, 20)
        Me.lblVisitFrequencyID.TabIndex = 31
        Me.lblVisitFrequencyID.Text = "Visit Frequency"
        Me.lblVisitFrequencyID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAdd
        '
        Me.btnAdd.UseVisualStyleBackColor = True
        Me.btnAdd.Location = New System.Drawing.Point(887, 76)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(53, 23)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        '
        'txtPricePerVisit
        '
        Me.txtPricePerVisit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPricePerVisit.Location = New System.Drawing.Point(127, 82)
        Me.txtPricePerVisit.MaxLength = 9
        Me.txtPricePerVisit.Name = "txtPricePerVisit"
        Me.txtPricePerVisit.Size = New System.Drawing.Size(136, 21)
        Me.txtPricePerVisit.TabIndex = 3
        Me.txtPricePerVisit.Tag = "ContractSite.PricePerVisit"
        Me.txtPricePerVisit.Text = ""
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(273, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Visit Duration"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgAssets
        '
        Me.dgAssets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAssets.DataMember = ""
        Me.dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAssets.Location = New System.Drawing.Point(458, 13)
        Me.dgAssets.Name = "dgAssets"
        Me.dgAssets.Size = New System.Drawing.Size(427, 86)
        Me.dgAssets.TabIndex = 4
        '
        'grpJobItems
        '
        Me.grpJobItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        Me.grpJobItems.Location = New System.Drawing.Point(10, 88)
        Me.grpJobItems.Name = "grpJobItems"
        Me.grpJobItems.Size = New System.Drawing.Size(603, 230)
        Me.grpJobItems.TabIndex = 35
        Me.grpJobItems.TabStop = False
        Me.grpJobItems.Text = "Job Items"
        '
        'UCContractAlternativeSite
        '
        Me.Controls.Add(Me.grpContractSite)
        Me.Name = "UCContractAlternativeSite"
        Me.Size = New System.Drawing.Size(983, 675)
        Me.grpContractSite.ResumeLayout(False)
        Me.gpJobItems.ResumeLayout(False)
        CType(Me.dgJobItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVisits.ResumeLayout(False)
        Me.grpJobItemAdd.ResumeLayout(False)
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private _currentContractSite As Entity.ContractAlternativeSites.ContractAlternativeSite

    Public Property CurrentContractSite() As Entity.ContractAlternativeSites.ContractAlternativeSite
        Get
            Return _currentContractSite
        End Get
        Set(ByVal Value As Entity.ContractAlternativeSites.ContractAlternativeSite)
            _currentContractSite = Value

            Me.txtPricePerVisit.Text = "£0.00"

            If CurrentContractSite Is Nothing Then
                CurrentContractSite = New Entity.ContractAlternativeSites.ContractAlternativeSite
                CurrentContractSite.Exists = False
            End If

            If CurrentContractSite.Exists Then
                Populate()
            Else
                Dim tp As TabPage = AddJobOfWork(Nothing)
            End If

            Dim site As New Entity.Sites.Site
            site = DB.Sites.Get(SiteID)
            txtSite.Text = Replace(Replace(Replace(
                                    site.Address1 & ", " & site.Address2 & ", " & site.Address3 & ", " & site.Address4 & ", " & site.Address5 & ", " & site.Postcode & "." _
                                    , ", , ", ", "), ", , ", ", "), ", , ", ", ")

            JobItems = DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID)

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

    Private _CurrentContract As Entity.ContractsAlternative.ContractAlternative

    Public Property CurrentContract() As Entity.ContractsAlternative.ContractAlternative
        Get
            Return _CurrentContract
        End Get
        Set(ByVal Value As Entity.ContractsAlternative.ContractAlternative)
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

    Private ReadOnly Property SelectedAssetDataRow() As DataRow
        Get
            If Not Me.dgAssets.CurrentRowIndex = -1 Then
                Return Assets(Me.dgAssets.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _JobItems As DataView

    Private Property JobItems() As DataView
        Get
            Return _JobItems
        End Get
        Set(ByVal Value As DataView)
            _JobItems = Value

            _JobItems.AllowDelete = False
            _JobItems.AllowEdit = False
            _JobItems.AllowNew = False
            dgJobItems.DataSource = JobItems
        End Set
    End Property

    Private ReadOnly Property SelectedJobItemDataRow() As DataRow
        Get
            If Not Me.dgJobItems.CurrentRowIndex = -1 Then
                Return JobItems(Me.dgJobItems.CurrentRowIndex).Row
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
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

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

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString
        Me.dgAssets.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupJobItemsDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgJobItems)
        Dim tStyle As DataGridTableStyle = Me.dgJobItems.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 200
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim PricePerVisit As New DataGridLabelColumn
        PricePerVisit.Format = "C"
        PricePerVisit.FormatInfo = Nothing
        PricePerVisit.HeaderText = "Item Price Per Visit"
        PricePerVisit.MappingName = "ItemPricePerVisit"
        PricePerVisit.ReadOnly = True
        PricePerVisit.Width = 120
        PricePerVisit.NullText = ""
        tStyle.GridColumnStyles.Add(PricePerVisit)

        Dim VisitFrequency As New DataGridLabelColumn
        VisitFrequency.Format = ""
        VisitFrequency.FormatInfo = Nothing
        VisitFrequency.HeaderText = "Visit Frequency"
        VisitFrequency.MappingName = "VisitFrequency"
        VisitFrequency.ReadOnly = True
        VisitFrequency.Width = 110
        VisitFrequency.NullText = ""
        tStyle.GridColumnStyles.Add(VisitFrequency)

        Dim VisitDuration As New DataGridLabelColumn
        VisitDuration.Format = ""
        VisitDuration.FormatInfo = Nothing
        VisitDuration.HeaderText = "Visit Duration"
        VisitDuration.MappingName = "VisitDuration"
        VisitDuration.ReadOnly = True
        VisitDuration.Width = 90
        VisitDuration.NullText = ""
        VisitDuration.Alignment = HorizontalAlignment.Center
        tStyle.GridColumnStyles.Add(VisitDuration)

        Dim Assets As New DataGridLabelColumn
        Assets.Format = "C"
        Assets.FormatInfo = Nothing
        Assets.HeaderText = "Appliances"
        Assets.MappingName = "Assets"
        Assets.ReadOnly = True
        Assets.Width = 130
        Assets.NullText = ""
        tStyle.GridColumnStyles.Add(Assets)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString
        Me.dgJobItems.TableStyles.Add(tStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub UCContractSite_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
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

    Private Sub txtPricePerVisit_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPricePerVisit.LostFocus
        Dim price As String = ""

        If txtPricePerVisit.Text.Trim.Length = 0 Then
            price = Format(0.0, "C")
        ElseIf Not IsNumeric(txtPricePerVisit.Text.Replace("£", "")) Then
            price = Format(0.0, "C")
        Else
            price = Format(CDbl(txtPricePerVisit.Text.Replace("£", "")), "C")
        End If
        txtPricePerVisit.Text = price
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim jI As New Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems
            jI.SetDescription = Me.txtDescriptionItem.Text.Trim.Trim
            jI.SetItemPricePerVisit = Me.txtPricePerVisit.Text.Trim.Replace("£", "")
            jI.SetVisitFrequencyID = Combo.GetSelectedItemValue(Me.cboVisitFrequencyID)
            jI.SetVisitDuration = Combo.GetSelectedItemValue(cboVisitDuration)
            jI.SetContractSiteID = CurrentContractSite.ContractSiteID

            Dim jIV As New Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItemsValidator

            jIV.Validate(jI)

            jI = DB.ContractAlternativeSiteJobItems.Insert(jI)

            'DELETE AND RE INSERT ASSET
            DB.ContractAlternativeSiteAsset.Delete(CurrentContractSite.ContractSiteID)

            For Each drAsset As DataRow In Assets.Table.Rows
                If Entity.Sys.Helper.MakeBooleanValid(drAsset("Tick")) = True Then

                    Dim ContractSiteAsset As New Entity.ContractAlternativeSiteAssets.ContractAlternativeSiteAsset
                    ContractSiteAsset.SetAssetID = drAsset("AssetID")
                    ContractSiteAsset.SetContractSiteJobItemID = jI.ContractSiteJobItemID
                    ContractSiteAsset = DB.ContractAlternativeSiteAsset.Insert(ContractSiteAsset)

                End If
            Next drAsset

            JobItems = DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID)

            Me.txtDescriptionItem.Text = ""

            Combo.SetSelectedComboItem_By_Value(cboVisitDuration, 1)
            Combo.SetSelectedComboItem_By_Value(cboVisitFrequencyID, 0)
            Me.txtPricePerVisit.Text = "£0.00"

            For Each drAsset As DataRow In Assets.Table.Rows
                drAsset("Tick") = False
            Next
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub dgJobItems_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgJobItems.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgJobItems.HitTest(e.X, e.Y)

        If Not SelectedJobItemDataRow Is Nothing Then
            If HitTestInfo.Column = 4 Then
                ShowForm(GetType(FRMJobItemAssets), True, New Object() {SelectedJobItemDataRow("ContractSiteJobItemID")})
            End If
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If SelectedJobItemDataRow Is Nothing Then
            Exit Sub
        End If

        DB.ContractAlternativeSiteJobItems.Delete(SelectedJobItemDataRow("ContractSiteJobItemID"))

        JobItems.Table.Rows.Remove(SelectedJobItemDataRow)
    End Sub

    Private Sub btnAddJobOfWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJobOfWork.Click
        Dim tp As TabPage = AddJobOfWork(Nothing)
    End Sub

    Private Sub btnRemoveJobOfWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveJobOfWork.Click
        RemoveJobOfWork()
    End Sub

    Private Sub btnAddToJobOfWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToJobOfWork.Click
        If SelectedJobItemDataRow Is Nothing Then
            ShowMessage("Please select an item to add.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If TCJobsOfWork.TabPages.Count = 0 Then
            ShowMessage("Please add a 'Job Of Work' tab page first.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).Visits.Table.Rows.Count > 0 Then
            ShowMessage("Work has been scheduled so no more items can be added.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).JobItemsAddedDataView.Table.Rows.Count > 0 Then
            If CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).JobItemsAddedDataView.Table.Rows(0).Item("VisitFrequencyID") _
                        <> SelectedJobItemDataRow.Item("VisitFrequencyID") Then
                ShowMessage("All 'Job Items' on a 'Job Of Work' must have the same visit frequency", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        DB.ContractAlternativeSiteJobItems.Update(SelectedJobItemDataRow.Item("ContractSiteJobitemID"),
                   CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CurrentJobOfWork.ContractSiteJobOfWorkID)

        JobItems = DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID)

        CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).JobItemsAddedDataView = DB.ContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CurrentJobOfWork.ContractSiteJobOfWorkID)
        ' CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CurrentJobOfWork = CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CurrentJobOfWork
        CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CalculateItemTotal()
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentContractSite = DB.ContractAlternativeSite.Get(ID)
            SiteID = CurrentContractSite.PropertyID
            CurrentContract.SetContractID = CurrentContractSite.ContractID
        End If

        If CurrentContractSite.JobOfWorks.Count > 0 Then
            Me.TCJobsOfWork.TabPages.Clear()

            For Each jobOfWork As Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork In CurrentContractSite.JobOfWorks
                Dim tp As TabPage = AddJobOfWork(jobOfWork)
            Next
            Me.TCJobsOfWork.SelectedTab = Me.TCJobsOfWork.TabPages(0)
        End If

    End Sub

    Public Sub PopAssets()
        Assets = DB.ContractAlternativeSiteAsset.GetAll_SiteID(SiteID)

        If Not CurrentContractSite.Exists Then
            For Each dr As DataRow In Assets.Table.Rows
                dr("Tick") = True
            Next
        End If
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            If TCJobsOfWork.TabPages.Count > 0 Then

                'DOES ANYTHING NEED SCHEDULING?
                Dim show As Boolean = False
                For Each tab As TabPage In Me.TCJobsOfWork.TabPages
                    If CType(tab.Controls(0), UCJobOfWork).JobItemsAddedDataView.Table.Rows.Count > 0 And
                                             CType(tab.Controls(0), UCJobOfWork).Visits.Table.Rows.Count = 0 Then
                        show = True
                    End If
                Next tab
                If show Then
                    If ShowMessage("Are you sure? " & "Any 'Jobs Of Work' not scheduled will now be scheduled and you will not be able to added anymore job items.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                        Return False
                    End If
                End If
            End If

            Me.Cursor = Cursors.WaitCursor
            CurrentContractSite.IgnoreExceptionsOnSetMethods = True

            CurrentContractSite.SetPropertyID = SiteID
            CurrentContractSite.SetContractID = CurrentContract.ContractID

            Dim cV As New Entity.ContractAlternativeSites.ContractAlternativeSiteValidator
            cV.Validate(CurrentContractSite, CurrentContract)

            If CurrentContractSite.Exists Then 'UPDATE

                DB.ContractAlternativeSite.Update(CurrentContractSite)

                For Each tab As TabPage In Me.TCJobsOfWork.TabPages
                    DB.ContractAlternativeSiteJobOfWork.Update(CType(tab.Controls(0), UCJobOfWork).CurrentJobOfWork, CType(tab.Controls(0), UCJobOfWork).ScheduleOfRatesDataview)

                    'START SCHEDULING JOBS************************
                    If CType(tab.Controls(0), UCJobOfWork).JobItemsAddedDataView.Table.Rows.Count > 0 And
                                            CType(tab.Controls(0), UCJobOfWork).Visits.Table.Rows.Count = 0 Then

                        ScheduleJob(CType(tab.Controls(0), UCJobOfWork).JobItemsAddedDataView,
                                CType(tab.Controls(0), UCJobOfWork).CurrentJobOfWork.FirstVisitDate,
                                   CType(tab.Controls(0), UCJobOfWork).CurrentJobOfWork.ContractSiteJobOfWorkID)

                    End If
                    '*********************************************
                Next
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

    Private Sub ScheduleJob(ByVal JobItemDV As DataView, ByVal FirstVisitDate As DateTime,
                                ByVal ContractSiteJobOfWorkID As Integer)
        Try

            'Duration OF Contract In Days
            Dim ContractDuration As Integer
            'ContractDuration = CurrentContract.ContractEndDate.Subtract(CurrentContract.ContractStartDate).Days

            'New Way
            Dim startDate As DateTime = Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") & " 00:00:00"
            Dim endDate As DateTime = Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") & " 00:00:00"
            ContractDuration = endDate.Subtract(startDate).Days

            'How Visit Should happen in days
            Dim NumOfVisits As Integer = 0
            Dim VisitFreqInDays As Integer = 0

            Select Case CType(JobItemDV.Table.Rows(0).Item("VisitFrequencyID"), Entity.Sys.Enums.VisitFrequency)
                Case Entity.Sys.Enums.VisitFrequency.Annually
                    VisitFreqInDays = 365
                Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                    VisitFreqInDays = 182
                Case Entity.Sys.Enums.VisitFrequency.Monthly
                    VisitFreqInDays = 30
                Case Entity.Sys.Enums.VisitFrequency.Quarterly
                    VisitFreqInDays = 91
                Case Entity.Sys.Enums.VisitFrequency.Weekly
                    VisitFreqInDays = 7
            End Select

            NumOfVisits = Math.Floor(ContractDuration / VisitFreqInDays)
            If NumOfVisits = 0 Then
                NumOfVisits = 1
            End If

            Dim EstVisitDate As DateTime = FirstVisitDate.Date & " 09:00:00"

            For i As Integer = 1 To NumOfVisits
                If EstVisitDate >= CurrentContract.ContractStartDate And EstVisitDate <= CurrentContract.ContractEndDate Then

                    'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                    If EstVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                        EstVisitDate = EstVisitDate.AddDays(2)
                    ElseIf EstVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                        EstVisitDate = EstVisitDate.AddDays(1)
                    End If

                    'CREATE JOB
                    Dim job As New Entity.Jobs.Job
                    job.SetPropertyID = CurrentContractSite.PropertyID
                    job.SetJobDefinitionEnumID = CInt(Entity.Sys.Enums.JobDefinition.Contract)
                    job.SetJobTypeID = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")(0).Item("ManagerID")
                    job.SetStatusEnumID = CInt(Entity.Sys.Enums.JobStatus.Open)
                    job.SetCreatedByUserID = loggedInUser.UserID
                    Dim JobNumber As New JobNumber
                    JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract)
                    job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
                    job.SetPONumber = ""
                    job.SetQuoteID = 0
                    job.SetFOC = True
                    job.SetContractID = CurrentContract.ContractID

                    If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        job.SetDeleted = True
                    End If

                    '  INSERT JOB ITEM
                    Dim JobOfWork As New Entity.JobOfWorks.JobOfWork
                    JobOfWork.IgnoreExceptionsOnSetMethods = True
                    JobOfWork.SetPONumber = ""
                    If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        JobOfWork.SetDeleted = True
                    End If

                    'Work out how long all the jobitems will take - running tally
                    Dim JobDuration As Integer = 0

                    For Each rw As DataRow In JobItemDV.Table.Rows

                        Dim JobItem As New Entity.JobItems.JobItem
                        JobItem.IgnoreExceptionsOnSetMethods = True
                        JobItem.SetSummary = Entity.Sys.Helper.MakeStringValid("PPM Contract Visit: ") &
                                        rw("Description")

                        JobDuration += rw("VisitDuration")

                        'INSERT ANY ASSETS
                        Dim AssetsDV As DataView = DB.ContractAlternativeSiteAsset.GetAll_JobItemID(rw.Item("ContractSiteJobItemID"))

                        For Each dr As DataRow In AssetsDV.Table.Rows
                            Dim JobAsset As New Entity.JobAssets.JobAsset
                            JobAsset.SetAssetID = dr("AssetID")
                            job.Assets.Add(JobAsset)
                        Next dr

                        JobOfWork.JobItems.Add(JobItem)
                    Next rw

                    'NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                    Dim match As New ArrayList
                    Dim engineerID As Integer = 0
                    Dim actualVisitDate As DateTime = Nothing
                    match = MatchingEngineer(job, EstVisitDate, JobDuration)
                    If Not match Is Nothing Then
                        If match.Count > 0 Then
                            actualVisitDate = match(0)
                            engineerID = match(1)
                        End If
                    End If

                    'IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                    Dim EngineerVisit As New Entity.EngineerVisits.EngineerVisit
                    EngineerVisit.IgnoreExceptionsOnSetMethods = True
                    EngineerVisit.SetEngineerID = engineerID
                    EngineerVisit.SetNotesToEngineer = "PPM Contract Visit"

                    'If engineerID > 0 Then
                    '    EngineerVisit.StartDateTime = actualVisitDate
                    '    EngineerVisit.EndDateTime = actualVisitDate.AddMinutes(JobDuration)
                    '    EngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                    'Else
                    EngineerVisit.StartDateTime = DateTime.MinValue
                    EngineerVisit.EndDateTime = DateTime.MinValue
                    EngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
                    'End If

                    If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        EngineerVisit.SetDeleted = True
                    End If

                    JobOfWork.EngineerVisits.Add(EngineerVisit)

                    job.JobOfWorks.Add(JobOfWork)
                    job = DB.Job.Insert(job)

                    'CREATE PPM VISIT RECORD
                    Dim PPM As New Entity.ContractAlternativePPMVisits.ContractAlternativePPMVisit
                    PPM.SetContractSiteJobOfWorkID = ContractSiteJobOfWorkID
                    PPM.EstimatedVisitDate = EstVisitDate
                    PPM.SetJobID = job.JobID
                    DB.ContractAlternativePPMVisit.Insert(PPM)
                    EstVisitDate = EstVisitDate.AddDays(VisitFreqInDays)
                End If
            Next i
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Function AddJobOfWork(ByVal jobOfWork As Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork) As TabPage
        Dim tp As New TabPage
        tp.BackColor = Color.White

        Dim ctrl As New UCJobOfWork
        ctrl.OnControl = Me
        If jobOfWork Is Nothing Then
            jobOfWork = New Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork
            jobOfWork.SetContractSiteID = CurrentContractSite.ContractSiteID
            jobOfWork.FirstVisitDate = CurrentContract.ContractStartDate.AddDays(1)
            jobOfWork.SetPricePerMile = Entity.Sys.Helper.MakeDoubleValid(DB.Manager.Get()?.MileageRate)
            jobOfWork = DB.ContractAlternativeSiteJobOfWork.Insert(jobOfWork)
        End If
        ctrl.CurrentJobOfWork = jobOfWork
        AddHandler ctrl.RemovedItem, AddressOf ItemRemovedFromJobOfWork

        ctrl.Dock = DockStyle.Fill
        tp.Controls.Add(ctrl)
        Me.TCJobsOfWork.TabPages.Add(tp)
        CheckTabs()

        Me.TCJobsOfWork.SelectedTab = tp

        Return tp
    End Function

    Private Sub CheckTabs()
        Dim i As Integer = 1
        For Each tab As TabPage In Me.TCJobsOfWork.TabPages
            tab.Text = "Job Of Work #" & i
            i += 1
        Next
    End Sub

    Private Sub RemoveJobOfWork()

        If CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).JobItemsAddedDataView.Table.Rows.Count > 0 Then
            ShowMessage("Items of work has been added to this Job Of Work." & vbCrLf & "You must remove all the items first.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).Visits.Table.Rows.Count > 0 Then
            ShowMessage("Work has been scheduled." & vbCrLf & "Cannot remove this Job of Work.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        DB.ContractAlternativeSiteJobOfWork.Delete(CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CurrentJobOfWork.ContractSiteJobOfWorkID)

        Me.TCJobsOfWork.TabPages.Remove(Me.TCJobsOfWork.SelectedTab)

        CheckTabs()
    End Sub

    Public Sub ItemRemovedFromJobOfWork()
        JobItems = DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID)

        CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CurrentJobOfWork = CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CurrentJobOfWork

    End Sub

    Private Function MatchingEngineer(ByVal job As Entity.Jobs.Job, ByVal estVisitDate As DateTime,
                                    ByVal visitDuration As Integer) As ArrayList
        Dim site As New Entity.Sites.Site
        Dim engineerID As Integer = 0
        Dim slotDuration As Integer = 0 'MINTUES
        'Dim visitDuration As Integer = 0
        Dim numOfSlotsNeeded As Integer = 0
        Dim match As New ArrayList
        Dim postcode As String = ""
        Dim postcodeEngineers As DataView = Nothing
        Dim cntPostcodeEng As Integer = 0
        Dim randomNum As Integer = 0

        'SYSTEM NUMBER OF MINUTES IN A SLOTS
        slotDuration = DB.Manager.Get.TimeSlot

        'VISIT DURATION FOR THIS SITE IN HOURS - its passed!
        ' visitDuration = Combo.GetSelectedItemValue(cboVisitDuration)

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

End Class