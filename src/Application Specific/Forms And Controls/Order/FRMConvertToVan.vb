Public Class FRMConvertToVan : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal UsedIn As Boolean, ByVal QuantityIn As Integer, ByVal PartProductNameIn As String, ByVal TypeIn As String, ByVal IDIn As Integer, ByVal AllocatedIn As ArrayList)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Used = UsedIn
        Quantity = QuantityIn
        PartProductName = PartProductNameIn
        Type = TypeIn
        ID = IDIn
        Allocated = AllocatedIn
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpOptions As System.Windows.Forms.GroupBox
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents dgLocations As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpOptions = New System.Windows.Forms.GroupBox
        Me.lblDetails = New System.Windows.Forms.Label
        Me.dgLocations = New System.Windows.Forms.DataGrid
        Me.grpOptions.SuspendLayout()
        CType(Me.dgLocations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(480, 512)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 512)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        '
        'grpOptions
        '
        Me.grpOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOptions.Controls.Add(Me.dgLocations)
        Me.grpOptions.Location = New System.Drawing.Point(8, 64)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(544, 440)
        Me.grpOptions.TabIndex = 7
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "Enter amount to distribute to each location"
        '
        'lblDetails
        '
        Me.lblDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetails.Location = New System.Drawing.Point(8, 40)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(544, 23)
        Me.lblDetails.TabIndex = 8
        Me.lblDetails.Text = "PARTPRODUCTDETAILS"
        '
        'dgLocations
        '
        Me.dgLocations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLocations.DataMember = ""
        Me.dgLocations.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgLocations.Location = New System.Drawing.Point(8, 24)
        Me.dgLocations.Name = "dgLocations"
        Me.dgLocations.Size = New System.Drawing.Size(528, 408)
        Me.dgLocations.TabIndex = 2
        '
        'FRMDistributeAllocated
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(560, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.MinimumSize = New System.Drawing.Size(568, 576)
        Me.Name = "FRMDistributeAllocated"
        Me.Text = "Part / Product Manager"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.grpOptions, 0)
        Me.Controls.SetChildIndex(Me.lblDetails, 0)
        Me.grpOptions.ResumeLayout(False)
        CType(Me.dgLocations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupDG()

        Locations = DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3(ID)

        If Not Used Then
            Me.lblDetails.Text = "You must declare where these " & Quantity & " " & PartProductName & "'s have been returned to:"
            Me.grpOptions.Text = "Enter quantity to distribute to each location"
        Else
            Me.lblDetails.Text = "You must declare where you got these " & Quantity & " " & PartProductName & "'s from:"
            Me.grpOptions.Text = "Enter quantity for each location"
        End If
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

    Private _Used As Boolean
    Public Property Used() As Boolean
        Get
            Return _Used
        End Get
        Set(ByVal Value As Boolean)
            _Used = Value
        End Set
    End Property

    Private _PartProductName As String
    Public Property PartProductName() As String
        Get
            Return _PartProductName
        End Get
        Set(ByVal Value As String)
            _PartProductName = Value
        End Set
    End Property

    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal Value As String)
            _Type = Value
        End Set
    End Property

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property

    Private _Quantity As Integer
    Public Property Quantity() As Integer
        Get
            Return _Quantity
        End Get
        Set(ByVal Value As Integer)
            _Quantity = Value
        End Set
    End Property

    Private _Allocated As ArrayList = Nothing
    Public Property Allocated() As ArrayList
        Get
            Return _Allocated
        End Get
        Set(ByVal Value As ArrayList)
            _Allocated = Value
        End Set
    End Property

    Private _Locations As DataView = Nothing
    Public Property Locations() As DataView
        Get
            Return _Locations
        End Get
        Set(ByVal Value As DataView)
            If Used Then
                Value.Table.AcceptChanges()
                'Value.Table.Columns.Add(New DataColumn("Available"))
                Value.Table.Columns.Add(New DataColumn("StockTransactionType", System.Type.GetType("System.Int32")))
                Value.Table.Columns.Add(New DataColumn("OrderPartProductID", System.Type.GetType("System.Int32")))

                For Each row As DataRow In Value.Table.Rows
                    'Try
                    row.Item("StockTransactionType") = CInt(Entity.Sys.Enums.Transaction.StockOut)
                    row.Item("OrderPartProductID") = 0

                    '  Select Case Type
                    'Case "Part"
                    '    Select Case row.Item("Location")
                    '        Case "Van"
                    '            row.Item("Available") = CStr(DB.PartTransaction.GetByVan(row.Item("ID")).Table.Select("PartID = " & ID)(0).Item("Amount"))
                    '        Case "Warehouse"
                    '            row.Item("Available") = CStr(DB.PartTransaction.GetByWarehouse(row.Item("ID")).Table.Select("PartID = " & ID)(0).Item("Amount"))
                    '    End Select
                    'Case "Product"
                    '    Select Case row.Item("Location")
                    '        Case "Van"
                    '            row.Item("Available") = CStr(DB.ProductTransaction.GetByVan(row.Item("ID")).Table.Select("ProductID = " & ID)(0).Item("Amount"))
                    '        Case "Warehouse"
                    '            row.Item("Available") = CStr(DB.ProductTransaction.GetByWarehouse(row.Item("ID")).Table.Select("ProductID = " & ID)(0).Item("Amount"))
                    '    End Select
                    '  End Select
                    'Catch ex As Exception
                    '    row.Item("Available") = "Unknown"
                    'End Try
                Next

                For Each allocatedItem As ArrayList In Allocated
                    Dim AllocatedLocation As DataRow = Value.Table.NewRow
                    AllocatedLocation("Location") = "**ORDER**"
                    AllocatedLocation("Name") = "**ORDER**"
                    AllocatedLocation("AdditionalDetails") = "**AN ORDER ALLOCATION**"
                    AllocatedLocation("ID") = 0
                    AllocatedLocation("AllocatedID") = allocatedItem.Item(0)
                    AllocatedLocation("LocationID") = 0
                    AllocatedLocation("Quantity") = 0
                    AllocatedLocation.Item("Available") = allocatedItem.Item(1)
                    AllocatedLocation.Item("StockTransactionType") = 0
                    AllocatedLocation.Item("OrderPartProductID") = allocatedItem.Item(2)
                    Value.Table.Rows.Add(AllocatedLocation)
                Next

                Dim OtherLocation As DataRow = Value.Table.NewRow
                OtherLocation("Location") = "**OTHER**"
                OtherLocation("Name") = "**OTHER**"
                OtherLocation("AdditionalDetails") = "**OTHER**"
                OtherLocation("ID") = 0
                OtherLocation("AllocatedID") = 0
                OtherLocation("LocationID") = 0
                OtherLocation("Quantity") = 0
                OtherLocation.Item("Available") = "N/A"
                OtherLocation.Item("StockTransactionType") = 0
                OtherLocation.Item("OrderPartProductID") = 0
                Value.Table.Rows.Add(OtherLocation)
            End If

            _Locations = Value
            _Locations.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString
            _Locations.AllowNew = False
            _Locations.AllowEdit = True
            _Locations.AllowDelete = False
            Me.dgLocations.DataSource = Locations
        End Set
    End Property

    Private ReadOnly Property SelectedLocationDataRow() As DataRow
        Get
            If Not Me.dgLocations.CurrentRowIndex = -1 Then
                Return Locations(Me.dgLocations.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDG()
        Dim tStyle As DataGridTableStyle = Me.dgLocations.TableStyles(0)

        tStyle.ReadOnly = False
        tStyle.AllowSorting = False
        Me.dgLocations.ReadOnly = False

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 100
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 150
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim Quantity As New DataGridTextBoxColumn
        Quantity.Format = ""
        Quantity.FormatInfo = Nothing
        Quantity.HeaderText = "Qty"
        Quantity.MappingName = "Quantity"
        Quantity.ReadOnly = False
        Quantity.Width = 50
        Quantity.NullText = ""
        tStyle.GridColumnStyles.Add(Quantity)

        If Used Then
            Dim Available As New DataGridTextBoxColumn
            Available.Format = ""
            Available.FormatInfo = Nothing
            Available.HeaderText = "Available"
            Available.MappingName = "Available"
            Available.ReadOnly = False
            Available.Width = 50
            Available.NullText = ""
            tStyle.GridColumnStyles.Add(Available)
        End If

        Dim AdditionalDetails As New DataGridLabelColumn
        AdditionalDetails.Format = ""
        AdditionalDetails.FormatInfo = Nothing
        AdditionalDetails.HeaderText = "Additional Details"
        AdditionalDetails.MappingName = "AdditionalDetails"
        AdditionalDetails.ReadOnly = True
        AdditionalDetails.Width = 300
        AdditionalDetails.NullText = ""
        tStyle.GridColumnStyles.Add(AdditionalDetails)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString
        Me.dgLocations.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMDistributeAllocated_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim totalDistributed As Integer = 0

        For Each row As DataRow In Locations.Table.Rows
            If row.Item("Quantity") > 0 Then
                totalDistributed += row.Item("Quantity")
            End If
        Next

        If totalDistributed = Quantity Then
            If Not Used Then
                Me.DialogResult = DialogResult.OK
            Else
                Dim errors As New ArrayList

                For Each row As DataRow In Locations.Table.Rows
                    If row.Item("Quantity") > 0 Then
                        Select Case row.Item("Available")
                            Case "Unknown"
                                errors.Add("Stock check could not take place for " & row.Item("Location") & " - " & row.Item("Name"))
                            Case "N/A"
                                errors.Add("Stock has been marked as being collected from an unknown location")
                            Case Else
                                If CInt(row.Item("Quantity")) > CInt(row.Item("Available")) Then
                                    If row.Item("Location") = "**ORDER**" Then
                                        ShowMessage("Using a quantity higher than what is allocated for an item is not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    Else
                                        errors.Add("More stock than is currently known as available is being collected from " & row.Item("Location") & " - " & row.Item("Name") & ". This will cause negative stock amounts")
                                    End If
                                End If
                        End Select
                    End If
                Next

                If errors.Count = 0 Then
                    Me.DialogResult = DialogResult.OK
                Else
                    Dim str As String = "Please note the following:" & vbCrLf & vbCrLf
                    For Each err As String In errors
                        str += err & vbCrLf
                    Next
                    If ShowMessage(str & vbCrLf & "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me.DialogResult = DialogResult.OK
                    End If
                End If
            End If
        Else
            ShowMessage("A total of " & Quantity & " need to be distributed. So far " & totalDistributed & " have been", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#End Region

End Class
