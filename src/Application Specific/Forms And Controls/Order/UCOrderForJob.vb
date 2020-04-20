Public Class UCOrderForJob : Inherits FSM.UCBase : Implements IUserControl

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
    Friend WithEvents grpJob As System.Windows.Forms.GroupBox
    Friend WithEvents dgEngineerVisits As System.Windows.Forms.DataGrid
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtJobSearch As System.Windows.Forms.TextBox
    Friend WithEvents grpWarehouse As System.Windows.Forms.GroupBox
    Friend WithEvents txtWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents btnFindWarehouse As System.Windows.Forms.Button
    Friend WithEvents grpCustomerSearch As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJob = New System.Windows.Forms.GroupBox
        Me.dgEngineerVisits = New System.Windows.Forms.DataGrid
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtJobSearch = New System.Windows.Forms.TextBox
        Me.grpCustomerSearch = New System.Windows.Forms.GroupBox
        Me.grpWarehouse = New System.Windows.Forms.GroupBox
        Me.btnFindWarehouse = New System.Windows.Forms.Button
        Me.txtWarehouse = New System.Windows.Forms.TextBox
        Me.grpJob.SuspendLayout()
        CType(Me.dgEngineerVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCustomerSearch.SuspendLayout()
        Me.grpWarehouse.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpJob
        '
        Me.grpJob.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJob.Controls.Add(Me.dgEngineerVisits)
        Me.grpJob.Location = New System.Drawing.Point(8, 128)
        Me.grpJob.Name = "grpJob"
        Me.grpJob.Size = New System.Drawing.Size(696, 248)
        Me.grpJob.TabIndex = 10
        Me.grpJob.TabStop = False
        Me.grpJob.Text = "Select a Visit to assign this Order to:"
        '
        'dgEngineerVisits
        '
        Me.dgEngineerVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgEngineerVisits.DataMember = ""
        Me.dgEngineerVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEngineerVisits.Location = New System.Drawing.Point(8, 26)
        Me.dgEngineerVisits.Name = "dgEngineerVisits"
        Me.dgEngineerVisits.Size = New System.Drawing.Size(680, 214)
        Me.dgEngineerVisits.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(640, 25)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(48, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Find"
        '
        'txtJobSearch
        '
        Me.txtJobSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobSearch.Location = New System.Drawing.Point(8, 24)
        Me.txtJobSearch.Name = "txtJobSearch"
        Me.txtJobSearch.Size = New System.Drawing.Size(624, 21)
        Me.txtJobSearch.TabIndex = 1
        '
        'grpCustomerSearch
        '
        Me.grpCustomerSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCustomerSearch.BackColor = System.Drawing.Color.White
        Me.grpCustomerSearch.Controls.Add(Me.btnSearch)
        Me.grpCustomerSearch.Controls.Add(Me.txtJobSearch)
        Me.grpCustomerSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomerSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpCustomerSearch.Location = New System.Drawing.Point(8, 8)
        Me.grpCustomerSearch.Name = "grpCustomerSearch"
        Me.grpCustomerSearch.Size = New System.Drawing.Size(696, 56)
        Me.grpCustomerSearch.TabIndex = 9
        Me.grpCustomerSearch.TabStop = False
        Me.grpCustomerSearch.Text = "Job Number / Address"
        '
        'grpWarehouse
        '
        Me.grpWarehouse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpWarehouse.Controls.Add(Me.btnFindWarehouse)
        Me.grpWarehouse.Controls.Add(Me.txtWarehouse)
        Me.grpWarehouse.Location = New System.Drawing.Point(8, 70)
        Me.grpWarehouse.Name = "grpWarehouse"
        Me.grpWarehouse.Size = New System.Drawing.Size(696, 52)
        Me.grpWarehouse.TabIndex = 11
        Me.grpWarehouse.TabStop = False
        Me.grpWarehouse.Text = "Warehouse"
        '
        'btnFindWarehouse
        '
        Me.btnFindWarehouse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindWarehouse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFindWarehouse.Location = New System.Drawing.Point(640, 18)
        Me.btnFindWarehouse.Name = "btnFindWarehouse"
        Me.btnFindWarehouse.Size = New System.Drawing.Size(48, 23)
        Me.btnFindWarehouse.TabIndex = 3
        Me.btnFindWarehouse.Text = "..."
        '
        'txtWarehouse
        '
        Me.txtWarehouse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWarehouse.Location = New System.Drawing.Point(8, 20)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.ReadOnly = True
        Me.txtWarehouse.Size = New System.Drawing.Size(624, 21)
        Me.txtWarehouse.TabIndex = 0
        '
        'UCOrderForJob
        '
        Me.Controls.Add(Me.grpWarehouse)
        Me.Controls.Add(Me.grpCustomerSearch)
        Me.Controls.Add(Me.grpJob)
        Me.Name = "UCOrderForJob"
        Me.Size = New System.Drawing.Size(712, 377)
        Me.grpJob.ResumeLayout(False)
        CType(Me.dgEngineerVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCustomerSearch.ResumeLayout(False)
        Me.grpCustomerSearch.PerformLayout()
        Me.grpWarehouse.ResumeLayout(False)
        Me.grpWarehouse.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupVisitsDataGrid()
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

    Public Property EngineerVisitsDataView() As DataView
        Get
            Return m_dTable
        End Get
        Set(ByVal Value As DataView)
            m_dTable = Value
            m_dTable.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
            m_dTable.AllowNew = False
            m_dTable.AllowEdit = False
            m_dTable.AllowDelete = False
            Me.dgEngineerVisits.DataSource = EngineerVisitsDataView
        End Set
    End Property

    Private m_dTable As DataView = Nothing

    Public ReadOnly Property SelectedEngineerVisitDataRow() As DataRow
        Get
            If Not Me.dgEngineerVisits.CurrentRowIndex = -1 Then
                Return EngineerVisitsDataView(Me.dgEngineerVisits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _Warehouse As Entity.Warehouses.Warehouse
    Public Property Warehouse() As Entity.Warehouses.Warehouse
        Get
            Return _Warehouse
        End Get
        Set(ByVal value As Entity.Warehouses.Warehouse)
            _Warehouse = value

            If Not _Warehouse Is Nothing Then
                Dim strWarehouse As String = _Warehouse.Name & ". " & _Warehouse.Address1

                If _Warehouse.Postcode.Length > 0 Then
                    strWarehouse += ", " & _Warehouse.Postcode
                End If

            End If

        End Set

    End Property

#End Region

#Region "Setup"

    Public Sub SetupVisitsDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgEngineerVisits)
        Dim tbStyle As DataGridTableStyle = Me.dgEngineerVisits.TableStyles(0)

        tbStyle.GridColumnStyles.Clear()

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 150
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 150
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 75
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim PONumber As New DataGridLabelColumn
        PONumber.Format = ""
        PONumber.FormatInfo = Nothing
        PONumber.HeaderText = "PO Number"
        PONumber.MappingName = "PONumber"
        PONumber.ReadOnly = True
        PONumber.Width = 75
        PONumber.NullText = ""
        tbStyle.GridColumnStyles.Add(PONumber)

        Dim JobDefinition As New DataGridLabelColumn
        JobDefinition.Format = ""
        JobDefinition.FormatInfo = Nothing
        JobDefinition.HeaderText = "Definition"
        JobDefinition.MappingName = "JobDefinition"
        JobDefinition.ReadOnly = True
        JobDefinition.Width = 75
        JobDefinition.NullText = ""
        tbStyle.GridColumnStyles.Add(JobDefinition)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        tbStyle.GridColumnStyles.Add(Type)

        Dim VisitStatus As New DataGridLabelColumn
        VisitStatus.Format = ""
        VisitStatus.FormatInfo = Nothing
        VisitStatus.HeaderText = "Status"
        VisitStatus.MappingName = "VisitStatus"
        VisitStatus.ReadOnly = True
        VisitStatus.Width = 75
        VisitStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitStatus)

        Dim VisitDate As New DataGridLabelColumn
        VisitDate.Format = "dd/MMM/yyyy"
        VisitDate.FormatInfo = Nothing
        VisitDate.HeaderText = "Date"
        VisitDate.MappingName = "startdatetime"
        VisitDate.ReadOnly = True
        VisitDate.Width = 100
        VisitDate.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(VisitDate)

        Dim VisitEngineer As New DataGridLabelColumn
        VisitEngineer.Format = ""
        VisitEngineer.FormatInfo = Nothing
        VisitEngineer.HeaderText = "Engineer"
        VisitEngineer.MappingName = "Engineer"
        VisitEngineer.ReadOnly = True
        VisitEngineer.Width = 100
        VisitEngineer.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(VisitEngineer)

        Dim jobOfWork As New DataGridLabelColumn
        jobOfWork.Format = ""
        jobOfWork.FormatInfo = Nothing
        jobOfWork.HeaderText = "Job Of Work"
        jobOfWork.MappingName = "JOWNo"
        jobOfWork.ReadOnly = True
        jobOfWork.Width = 100
        jobOfWork.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(jobOfWork)

        Dim visit As New DataGridLabelColumn
        visit.Format = ""
        visit.FormatInfo = Nothing
        visit.HeaderText = "Visit"
        visit.MappingName = "VisitNo"
        visit.ReadOnly = True
        visit.Width = 100
        visit.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(visit)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
        Me.dgEngineerVisits.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub btnFindWarehouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindWarehouse.Click

        Dim warehouseID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
        If Not warehouseID = 0 Then
            Warehouse = DB.Warehouse.Warehouse_Get(warehouseID)
        End If

    End Sub

    Private Sub UCOrderForJob_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Not String.IsNullOrEmpty(txtJobSearch.Text) Then
            EngineerVisitsDataView = DB.EngineerVisits.EngineerVisits_Search(Me.txtJobSearch.Text, True)
        End If

    End Sub

    Private Sub txtJobSearch_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtJobSearch.KeyUp
        If e.KeyCode = Keys.Enter AndAlso Not String.IsNullOrEmpty(txtJobSearch.Text) Then
            EngineerVisitsDataView = DB.EngineerVisits.EngineerVisits_Search(Me.txtJobSearch.Text, True)
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save

    End Function

#End Region

    
    
End Class
