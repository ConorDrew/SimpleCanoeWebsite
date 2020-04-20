Public Class FRMFindCustomers
    Inherits FRMBaseForm

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
    Friend WithEvents grpCustomers As System.Windows.Forms.GroupBox
    Friend WithEvents dgCustomers As System.Windows.Forms.DataGrid
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents lblCustomerName As Label
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpCustomers = New System.Windows.Forms.GroupBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.dgCustomers = New System.Windows.Forms.DataGrid()
        Me.grpCustomers.SuspendLayout()
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpCustomers
        '
        Me.grpCustomers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCustomers.Controls.Add(Me.txtFilter)
        Me.grpCustomers.Controls.Add(Me.lblCustomerName)
        Me.grpCustomers.Controls.Add(Me.btnOk)
        Me.grpCustomers.Controls.Add(Me.btnClearAll)
        Me.grpCustomers.Controls.Add(Me.btnSelectAll)
        Me.grpCustomers.Controls.Add(Me.dgCustomers)
        Me.grpCustomers.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.grpCustomers.Location = New System.Drawing.Point(8, 32)
        Me.grpCustomers.Name = "grpCustomers"
        Me.grpCustomers.Size = New System.Drawing.Size(661, 428)
        Me.grpCustomers.TabIndex = 10
        Me.grpCustomers.TabStop = False
        Me.grpCustomers.Text = "Customer to Add"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(118, 31)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(219, 20)
        Me.txtFilter.TabIndex = 49
        '
        'lblCustomerName
        '
        Me.lblCustomerName.Location = New System.Drawing.Point(7, 34)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(105, 20)
        Me.lblCustomerName.TabIndex = 48
        Me.lblCustomerName.Text = "Customer Name"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnOk.Location = New System.Drawing.Point(588, 394)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(64, 23)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearAll.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClearAll.Location = New System.Drawing.Point(80, 394)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(64, 23)
        Me.btnClearAll.TabIndex = 3
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSelectAll.Location = New System.Drawing.Point(10, 394)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(64, 23)
        Me.btnSelectAll.TabIndex = 2
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'dgCustomers
        '
        Me.dgCustomers.AllowNavigation = False
        Me.dgCustomers.AlternatingBackColor = System.Drawing.Color.GhostWhite
        Me.dgCustomers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCustomers.BackgroundColor = System.Drawing.Color.White
        Me.dgCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgCustomers.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.dgCustomers.CaptionForeColor = System.Drawing.Color.White
        Me.dgCustomers.CaptionText = "Engineers"
        Me.dgCustomers.CaptionVisible = False
        Me.dgCustomers.DataMember = ""
        Me.dgCustomers.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dgCustomers.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgCustomers.GridLineColor = System.Drawing.Color.RoyalBlue
        Me.dgCustomers.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.dgCustomers.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgCustomers.HeaderForeColor = System.Drawing.Color.Lavender
        Me.dgCustomers.LinkColor = System.Drawing.Color.Teal
        Me.dgCustomers.Location = New System.Drawing.Point(10, 72)
        Me.dgCustomers.Name = "dgCustomers"
        Me.dgCustomers.ParentRowsBackColor = System.Drawing.Color.Lavender
        Me.dgCustomers.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.dgCustomers.ParentRowsVisible = False
        Me.dgCustomers.RowHeadersVisible = False
        Me.dgCustomers.SelectionBackColor = System.Drawing.Color.Teal
        Me.dgCustomers.SelectionForeColor = System.Drawing.Color.PaleGreen
        Me.dgCustomers.Size = New System.Drawing.Size(642, 313)
        Me.dgCustomers.TabIndex = 1
        '
        'FRMFindCustomers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(672, 461)
        Me.Controls.Add(Me.grpCustomers)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(688, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(688, 400)
        Me.Name = "FRMFindCustomers"
        Me.Text = "Customers"
        Me.Controls.SetChildIndex(Me.grpCustomers, 0)
        Me.grpCustomers.ResumeLayout(False)
        Me.grpCustomers.PerformLayout()
        CType(Me.dgCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

#End Region

#Region "Properties"

    Private _dvCustomers As DataView
    Public Property CustomerDataView() As DataView
        Get
            Return _dvCustomers
        End Get
        Set(ByVal Value As DataView)
            _dvCustomers = Value
            If Not CustomerDataView Is Nothing Then
                If Not CustomerDataView.Table Is Nothing Then
                    _dvCustomers.Table.TableName = Entity.Sys.Enums.TableNames.tblCustomer
                    _dvCustomers.AllowNew = False
                End If
            End If
            dgCustomers.DataSource = CustomerDataView
        End Set
    End Property

#End Region

#Region "Functions"

    Private Sub SetUpDataGrid()
        SuspendLayout()

        Entity.Sys.Helper.SetUpDataGrid(dgCustomers)
        Dim tStyle As DataGridTableStyle = dgCustomers.TableStyles(0)

        'Set up columns 
        tStyle.ReadOnly = False
        dgCustomers.ReadOnly = False

        Dim include As New DataGridBoolColumn
        include.HeaderText = "Include"
        include.MappingName = "Include"
        include.ReadOnly = False
        include.Width = 50
        'turn off tristate
        include.AllowNull = False
        tStyle.GridColumnStyles.Add(include)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 170
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim AccountNumber As New DataGridLabelColumn
        AccountNumber.Format = ""
        AccountNumber.FormatInfo = Nothing
        AccountNumber.HeaderText = "Account Number"
        AccountNumber.MappingName = "AccountNumber"
        AccountNumber.ReadOnly = True
        AccountNumber.Width = 100
        AccountNumber.NullText = ""
        tStyle.GridColumnStyles.Add(AccountNumber)

        Dim Region As New DataGridLabelColumn
        Region.Format = ""
        Region.FormatInfo = Nothing
        Region.HeaderText = "Region"
        Region.MappingName = "Region"
        Region.ReadOnly = True
        Region.Width = 100
        Region.NullText = ""
        tStyle.GridColumnStyles.Add(Region)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 140
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim HO As New DataGridLabelColumn
        HO.Format = ""
        HO.FormatInfo = Nothing
        HO.HeaderText = "Head Office"
        HO.MappingName = "ho"
        HO.ReadOnly = True
        HO.Width = 250
        HO.NullText = ""
        tStyle.GridColumnStyles.Add(HO)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblCustomer

        Me.dgCustomers.TableStyles.Add(tStyle)
        ResumeLayout(True)
    End Sub

#End Region

#Region "Events"

    Private Sub DgCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCustomers.Click, dgCustomers.DoubleClick

        Try
            ' this code mainly facilitates single clicks to change the state of a checkbox
            Dim includeColumn As Integer = 0
            Dim pt As Point = Me.dgCustomers.PointToClient(Control.MousePosition)
            Dim hti As DataGrid.HitTestInfo = Me.dgCustomers.HitTest(pt)
            Dim bmb As BindingManagerBase = Me.BindingContext(Me.dgCustomers.DataSource,
                                                        Me.dgCustomers.DataMember)

            If hti.Row < bmb.Count AndAlso hti.Type = DataGrid.HitTestType.Cell AndAlso hti.Column = includeColumn Then
                Dim selected As Boolean = Not CBool(Me.dgCustomers(hti.Row, includeColumn))
                Me.dgCustomers(hti.Row, includeColumn) = selected
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub BtnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        If Not CustomerDataView Is Nothing Then
            If Not CustomerDataView.Table Is Nothing Then
                For Each r As DataRow In CustomerDataView.Table.Rows
                    r("Include") = True
                Next
            End If
        End If
    End Sub

    Private Sub BtnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        If Not CustomerDataView Is Nothing Then
            If Not CustomerDataView.Table Is Nothing Then
                For Each r As DataRow In CustomerDataView.Table.Rows
                    r("Include") = False
                Next
            End If
            Me.txtFilter.Text = String.Empty
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Close()
    End Sub

    Private Sub FrmDisplayEngineers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(Me)
        SetUpDataGrid()
        Populate()
    End Sub

    Private Sub Populate()
        CustomerDataView = DB.Customer.Customer_GetAll_Light(loggedInUser.UserID)
        If CustomerDataView Is Nothing Then Exit Sub
        Dim dtCustomers As DataTable = CustomerDataView.Table
        dtCustomers.Columns.Add("Include", GetType(System.Boolean))
        For Each dr As DataRow In dtCustomers.Rows
            dr("Include") = False
        Next
        CustomerDataView = New DataView(dtCustomers)
    End Sub

    Private Sub TxtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        If Not CustomerDataView Is Nothing Then
            If Not CustomerDataView.Table Is Nothing Then
                CustomerDataView.RowFilter = "Name LIKE '%" & Me.txtFilter.Text & "%'"
            End If
        End If
    End Sub

#End Region

End Class
