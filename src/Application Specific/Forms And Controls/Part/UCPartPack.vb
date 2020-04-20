Imports System.Collections.Generic
Imports System.Linq

Public Class UCPartPack : Inherits FSM.UCBase : Implements IUserControl

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

    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents grpPart As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvPartPack As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents dgPackSuppliers As DataGridView
    Friend WithEvents lblPackSuppliers As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.grpPart = New System.Windows.Forms.GroupBox()
        Me.lblPackSuppliers = New System.Windows.Forms.Label()
        Me.dgPackSuppliers = New System.Windows.Forms.DataGridView()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvPartPack = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabDetails.SuspendLayout()
        Me.grpPart.SuspendLayout()
        CType(Me.dgPackSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPartPack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.grpPart)
        Me.tabDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Size = New System.Drawing.Size(624, 612)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Main Details"
        '
        'grpPart
        '
        Me.grpPart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPart.Controls.Add(Me.lblPackSuppliers)
        Me.grpPart.Controls.Add(Me.dgPackSuppliers)
        Me.grpPart.Controls.Add(Me.btnRemove)
        Me.grpPart.Controls.Add(Me.btnAdd)
        Me.grpPart.Controls.Add(Me.dgvPartPack)
        Me.grpPart.Controls.Add(Me.Label2)
        Me.grpPart.Controls.Add(Me.txtName)
        Me.grpPart.Location = New System.Drawing.Point(8, 8)
        Me.grpPart.Name = "grpPart"
        Me.grpPart.Size = New System.Drawing.Size(609, 595)
        Me.grpPart.TabIndex = 0
        Me.grpPart.TabStop = False
        Me.grpPart.Text = "Main Details"
        '
        'lblPackSuppliers
        '
        Me.lblPackSuppliers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPackSuppliers.Location = New System.Drawing.Point(8, 400)
        Me.lblPackSuppliers.Name = "lblPackSuppliers"
        Me.lblPackSuppliers.Size = New System.Drawing.Size(117, 21)
        Me.lblPackSuppliers.TabIndex = 63
        Me.lblPackSuppliers.Text = "Pack Suppliers"
        '
        'dgPackSuppliers
        '
        Me.dgPackSuppliers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgPackSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPackSuppliers.Location = New System.Drawing.Point(11, 424)
        Me.dgPackSuppliers.Name = "dgPackSuppliers"
        Me.dgPackSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPackSuppliers.Size = New System.Drawing.Size(585, 160)
        Me.dgPackSuppliers.TabIndex = 62
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(11, 358)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 61
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(521, 358)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 60
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvPartPack
        '
        Me.dgvPartPack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPartPack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartPack.Location = New System.Drawing.Point(11, 64)
        Me.dgvPartPack.Name = "dgvPartPack"
        Me.dgvPartPack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartPack.Size = New System.Drawing.Size(585, 279)
        Me.dgvPartPack.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 21)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(160, 26)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(436, 21)
        Me.txtName.TabIndex = 0
        Me.txtName.Tag = "Part.Name"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabDetails)
        Me.TabControl1.Location = New System.Drawing.Point(1, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(632, 638)
        Me.TabControl1.TabIndex = 0
        '
        'UCPartPack
        '
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "UCPartPack"
        Me.Size = New System.Drawing.Size(640, 648)
        Me.tabDetails.ResumeLayout(False)
        Me.grpPart.ResumeLayout(False)
        Me.grpPart.PerformLayout()
        CType(Me.dgPackSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPartPack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupPartPackDatagrid()
        SetupPackSuppliersDatagrid()

    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return PackID
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Public PackID As Integer = 0
    Private PartPackName As String

    Private ReadOnly Property DrSelectedPartPack() As DataRow
        Get
            If Not Me.dgvPartPack.CurrentCell.RowIndex = -1 Then
                Return PartPackDataview(Me.dgvPartPack.CurrentCell.RowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _PartPackDataView As DataView = Nothing

    Public Property PartPackDataview() As DataView
        Get
            Return _PartPackDataView
        End Get
        Set(ByVal Value As DataView)
            _PartPackDataView = Value
            _PartPackDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString
            _PartPackDataView.AllowNew = False
            _PartPackDataView.AllowEdit = True
            _PartPackDataView.AllowDelete = False
            Me.dgvPartPack.DataSource = PartPackDataview
        End Set
    End Property

    Private _dvPackSuppliers As DataView = Nothing

    Public Property DvPackSuppliers() As DataView
        Get
            Return _dvPackSuppliers
        End Get
        Set(ByVal Value As DataView)
            _dvPackSuppliers = Value
            _dvPackSuppliers.Table.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString
            _dvPackSuppliers.AllowNew = False
            _dvPackSuppliers.AllowEdit = True
            _dvPackSuppliers.AllowDelete = False
            Me.dgPackSuppliers.DataSource = DvPackSuppliers
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupPartPackDatagrid()

        Entity.Sys.Helper.SetUpDataGridView(Me.dgvPartPack)
        dgvPartPack.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPartPack.AutoGenerateColumns = False
        dgvPartPack.Columns.Clear()
        dgvPartPack.EditMode = DataGridViewEditMode.EditOnEnter

        Dim PartName As New DataGridViewTextBoxColumn
        PartName.FillWeight = 70
        PartName.HeaderText = "Part Name"
        PartName.DataPropertyName = "PartName"
        PartName.ReadOnly = True
        PartName.Visible = True
        PartName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartPack.Columns.Add(PartName)

        Dim PartNumber As New DataGridViewTextBoxColumn
        PartNumber.HeaderText = "Part Number"
        PartNumber.DataPropertyName = "PartNumber"
        PartNumber.FillWeight = 70
        PartNumber.ReadOnly = True
        PartNumber.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartPack.Columns.Add(PartNumber)

        Dim Qty As New DataGridViewTextBoxColumn
        Qty.HeaderText = "Qty"
        Qty.DataPropertyName = "Qty"
        Qty.FillWeight = 70
        Qty.ReadOnly = True
        Qty.SortMode = DataGridViewColumnSortMode.Automatic
        dgvPartPack.Columns.Add(Qty)

        dgvPartPack.Sort(PartName, System.ComponentModel.ListSortDirection.Descending)

    End Sub

    Private Sub SetupPackSuppliersDatagrid()

        Entity.Sys.Helper.SetUpDataGridView(Me.dgPackSuppliers)
        dgPackSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgPackSuppliers.AutoGenerateColumns = False
        dgPackSuppliers.Columns.Clear()
        dgPackSuppliers.EditMode = DataGridViewEditMode.EditOnEnter

        Dim supplier As New DataGridViewTextBoxColumn
        supplier.HeaderText = "Supplier"
        supplier.DataPropertyName = "SupplierName"
        supplier.FillWeight = 100
        supplier.ReadOnly = True
        supplier.Visible = True
        supplier.SortMode = DataGridViewColumnSortMode.Automatic
        dgPackSuppliers.Columns.Add(supplier)

        Dim qtyInPack As New DataGridViewTextBoxColumn
        qtyInPack.FillWeight = 70
        qtyInPack.HeaderText = "Qty Of Parts In Pack"
        qtyInPack.DataPropertyName = "QuantityOfPartsInPack"
        qtyInPack.ReadOnly = True
        qtyInPack.Visible = True
        qtyInPack.SortMode = DataGridViewColumnSortMode.Automatic
        dgPackSuppliers.Columns.Add(qtyInPack)

        Dim cost As New DataGridViewTextBoxColumn
        cost.HeaderText = "Cost"
        cost.DataPropertyName = "Price"
        cost.FillWeight = 70
        cost.ReadOnly = True
        cost.SortMode = DataGridViewColumnSortMode.Automatic
        dgPackSuppliers.Columns.Add(cost)

        dgPackSuppliers.Sort(qtyInPack, System.ComponentModel.ListSortDirection.Descending)
    End Sub

#End Region

#Region "Events"

    Private Sub UCPart_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

#End Region

#Region "Functions"

    Public Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        PackID = ID
        PartPackName = DB.ExecuteScalar("Select PackName From tblPartPack where PackID  = " & PackID)
        Me.txtName.Text = PartPackName
        PartPackDataview = DB.Part.PartPack_Get(PackID)
        DvPackSuppliers = DB.Part.PartPack_Get_Suppliers(PackID)
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            If txtName.Text.Length = 0 Then
                ShowMessage("Enter a Pack Name!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            Dim PerformSave As Boolean = False
            Dim isNameUnique As Boolean = True
            Dim isNewPack As Boolean = False

            Dim dvCurrentPartPacks As DataView = DB.Part.PartPack_GetAll()
            If dvCurrentPartPacks.Count > 0 AndAlso PackID = 0 Then
                Dim partPacks As List(Of String) = dvCurrentPartPacks.Table.Rows.OfType(Of DataRow)().[Select](Function(dr) dr.Field(Of String)("PackName")).ToList()
                isNameUnique = Not partPacks.Contains(Me.txtName.Text.Trim())
            End If
            If Not isNameUnique Then
                Dim msg As String = "A pack with this name already exists"
                ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

            If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.EditParts) = True Or loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.CreateParts) = True Then
                PerformSave = True
            Else
                Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
                Return False
            End If

            If PerformSave Then
                If Not PartPackDataview Is Nothing AndAlso PartPackDataview.Count > 0 Then
                    If PackID = 0 Then
                        PackID = DB.ExecuteScalar("Select ISNULL(MAX(PackID),0) From tblPartPack") + 1
                        isNewPack = True
                    End If
                    PartPackName = txtName.Text
                    DB.ExecuteScalar("Delete from tblPartPAck WHERE PackID = " & PackID)
                    For Each dr As DataRow In PartPackDataview.Table.Rows
                        DB.ExecuteScalar("INSERT INTO tblPartPack (PackName,PackID,Qty,PartID) VALUES ('" & txtName.Text & "'," & PackID & "," & dr("qty") & "," & dr("PartID") & ")")
                    Next

                    Dim msg As String = "Save successful"
                    ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    RaiseEvent RecordsChanged(DB.Part.PartPack_GetAll(), Entity.Sys.Enums.PageViewing.PartPack, True, False, "")
                    RaiseEvent StateChanged(PackID)
                    MainForm.RefreshEntity(PackID, "PackID")
                End If

            End If

            Return True
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim dialogue1 As FRMFindPart
        dialogue1 = checkIfExists(GetType(FRMFindPart).Name, True)
        If dialogue1 Is Nothing Then
            dialogue1 = Activator.CreateInstance(GetType(FRMFindPart))
        End If
        dialogue1.TableToSearch = Entity.Sys.Enums.TableNames.tblPart
        dialogue1.ShowInTaskbar = False
        dialogue1.ShowDialog()

        Dim datarows() As DataRow = Nothing
        If dialogue1.DialogResult = DialogResult.OK Then
            datarows = dialogue1.Datarows
            If Save() Then
                If PackID = 0 Then
                    PartPackName = txtName.Text
                    PackID = DB.ExecuteScalar("Select ISNULL(MAX(PackID),0) From tblPartPack") + 1
                End If
                For Each dr As DataRow In datarows
                    DB.ExecuteScalar("INSERT INTO tblPartPack (PackName,PackID,PartID,Qty) VALUES ('" & PartPackName & "'," & PackID & "," & dr("PartID") & "," & dr("Qty") & " )")
                Next
                PartPackDataview = DB.Part.PartPack_Get(PackID)

                DvPackSuppliers = DB.Part.PartPack_Get_Suppliers(PackID)
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        If DrSelectedPartPack Is Nothing Then
            Exit Sub
        End If

        Dim partPackId As Integer = CInt(DrSelectedPartPack("PartPackID"))

        If partPackId > 0 Then
            DB.ExecuteScalar("Delete From tblpartPack where PartPackID = " & partPackId)

            PartPackDataview = DB.Part.PartPack_Get(PackID)
            DvPackSuppliers = DB.Part.PartPack_Get_Suppliers(PackID)
        End If

    End Sub

End Class