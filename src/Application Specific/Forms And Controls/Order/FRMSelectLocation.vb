Public Class FRMSelectLocation : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents grpLocations As System.Windows.Forms.GroupBox
    Friend WithEvents dgLocations As System.Windows.Forms.DataGrid
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpLocations = New System.Windows.Forms.GroupBox
        Me.dgLocations = New System.Windows.Forms.DataGrid
        Me.grpLocations.SuspendLayout()
        CType(Me.dgLocations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(856, 444)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(60, 25)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(12, 444)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 25)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'grpLocations
        '
        Me.grpLocations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLocations.Controls.Add(Me.dgLocations)
        Me.grpLocations.Location = New System.Drawing.Point(12, 38)
        Me.grpLocations.Name = "grpLocations"
        Me.grpLocations.Size = New System.Drawing.Size(904, 400)
        Me.grpLocations.TabIndex = 3
        Me.grpLocations.TabStop = False
        Me.grpLocations.Text = "Select location to replenish from : {0}"
        '
        'dgLocations
        '
        Me.dgLocations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLocations.DataMember = ""
        Me.dgLocations.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgLocations.Location = New System.Drawing.Point(9, 20)
        Me.dgLocations.Name = "dgLocations"
        Me.dgLocations.Size = New System.Drawing.Size(889, 374)
        Me.dgLocations.TabIndex = 1
        '
        'FRMSelectLocation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(928, 481)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpLocations)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.MinimumSize = New System.Drawing.Size(825, 420)
        Me.Name = "FRMSelectLocation"
        Me.Text = "Replenish from..."
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.grpLocations, 0)
        Me.grpLocations.ResumeLayout(False)
        CType(Me.dgLocations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupDG()

        Dim dt As DataView
        If GetParameter(8) = "DailyStockReplen" Then
            dt = DB.Part.Part_Locations_Get_For_Replenishment_Suppliers_Only(GetParameter(0))
        Else
            dt = DB.Part.Part_Locations_Get_For_Replenishment(GetParameter(0))
        End If

        For Each warehouse As ArrayList In CType(GetParameter(4), ArrayList)
            For Each row As DataRow In CType(warehouse.Item(1), DataTable).Rows
                If row.Item("PartID") = GetParameter(0) Then
                    If Not row.Item("LocationID") = 0 Then
                        For Each location As DataRow In dt.Table.Rows
                            If GetParameter(8) = "" Then
                                If location.Item("Type") = "Warehouse" Then
                                    If location.Item("ID") = row.Item("LocationID") Then
                                        location.Item("InStock") = (Entity.Sys.Helper.MakeIntegerValid(location.Item("InStock")) - Entity.Sys.Helper.MakeIntegerValid(row.Item("Quantity")))
                                    End If
                                End If
                            Else
                                If location.Item("Type") = "Warehouse" Then
                                    location.Delete()
                                End If
                            End If
                        Next
                    End If
                End If
            Next
        Next

        For Each van As ArrayList In CType(GetParameter(5), ArrayList)
            For Each row As DataRow In CType(van.Item(1), DataTable).Rows
                If row.Item("PartID") = GetParameter(0) Then
                    If Not row.Item("LocationID") = 0 Then
                        For Each location As DataRow In dt.Table.Rows
                            If GetParameter(8) = "" Then
                                If location.Item("Type") = "Warehouse" Then
                                    If location.Item("ID") = row.Item("LocationID") Then
                                        location.Item("InStock") = (Entity.Sys.Helper.MakeIntegerValid(location.Item("InStock")) - Entity.Sys.Helper.MakeIntegerValid(row.Item("Quantity")))
                                    End If
                                End If
                            Else
                                If location.Item("Type") = "Warehouse" Then
                                    location.Delete()
                                End If
                            End If
                        Next
                    End If
                End If
            Next
        Next

        If Not Entity.Sys.Helper.MakeIntegerValid(GetParameter(7)) = 0 Then
            For Each row As DataRow In dt.Table.Rows
                If row.Item("Type") = Entity.Sys.Helper.MakeStringValid(GetParameter(6)) And row.Item("ID") = Entity.Sys.Helper.MakeIntegerValid(GetParameter(7)) Then
                    row.Item("Tick") = True
                    Exit For
                End If
            Next
        End If

        Locations = dt

        Me.grpLocations.Text = "Please select where you would like to get " & GetParameter(3) & " of item '" & GetParameter(1) & "' for location '" & GetParameter(2) & "' from"
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        'DO NOTHING
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupDG()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgLocations)
        Dim tbStyle As DataGridTableStyle = Me.dgLocations.TableStyles(0)

        tbStyle.GridColumnStyles.Clear()

        tbStyle.ReadOnly = False
        Me.dgLocations.ReadOnly = False
        tbStyle.AllowSorting = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = False
        Tick.Width = 25
        Tick.NullText = ""
        tbStyle.GridColumnStyles.Add(Tick)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 150
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 200
        Name.NullText = ""
        tbStyle.GridColumnStyles.Add(Name)

        Dim InStock As New DataGridLabelColumn
        InStock.Format = ""
        InStock.FormatInfo = Nothing
        InStock.HeaderText = "Stock"
        InStock.MappingName = "InStock"
        InStock.ReadOnly = True
        InStock.Width = 75
        InStock.NullText = ""
        tbStyle.GridColumnStyles.Add(InStock)

        Dim InPack As New DataGridLabelColumn
        InPack.Format = ""
        InPack.FormatInfo = Nothing
        InPack.HeaderText = "In Pack"
        InPack.MappingName = "InPack"
        InPack.ReadOnly = True
        InPack.Width = 75
        InPack.NullText = ""
        tbStyle.GridColumnStyles.Add(InPack)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 100
        Price.NullText = ""
        tbStyle.GridColumnStyles.Add(Price)

        Dim Deleted As New DataGridLabelColumn
        Deleted.Format = ""
        Deleted.FormatInfo = Nothing
        Deleted.HeaderText = "Deleted"
        Deleted.MappingName = "Deleted"
        Deleted.ReadOnly = True
        Deleted.Width = 100
        Deleted.NullText = ""
        tbStyle.GridColumnStyles.Add(Deleted)

        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblLocations.ToString
        Me.dgLocations.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Properties"

    Private _Locations As DataView = Nothing
    Public Property Locations() As DataView
        Get
            Return _Locations
        End Get
        Set(ByVal Value As DataView)
            _Locations = Value
            _Locations.Table.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
            _Locations.AllowNew = False
            _Locations.AllowEdit = True
            _Locations.AllowDelete = False
            Me.dgLocations.DataSource = Locations
        End Set
    End Property

    Private ReadOnly Property SelectedDataRow() As DataRow
        Get
            If Not Me.dgLocations.CurrentRowIndex = -1 Then
                Return Locations(Me.dgLocations.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _LocationID As Integer = 0
    Public ReadOnly Property LocationID() As Integer
        Get
            Return _LocationID
        End Get
    End Property

    Private _PartSupplierID As Integer = 0
    Public ReadOnly Property PartSupplierID() As Integer
        Get
            Return _PartSupplierID
        End Get
    End Property

    Private _SupplierID As Integer = 0
    Public ReadOnly Property SupplierID() As Integer
        Get
            Return _SupplierID
        End Get
    End Property

    Private _InPack As Integer = 0
    Public ReadOnly Property InPack() As Integer
        Get
            Return _InPack
        End Get
    End Property

    Private _Price As Double = 0.0
    Public ReadOnly Property Price() As Double
        Get
            Return _Price
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub FRMSelectLocation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub dgLocations_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgLocations.MouseUp
        Try
            Try
                Dim HitTestInfo As DataGrid.HitTestInfo = Me.dgLocations.HitTest(e.X, e.Y)
                If Locations.Table.Rows(HitTestInfo.Row) Is Nothing Then
                    Exit Sub
                End If
                If Not Locations.Table.Columns(HitTestInfo.Column).ColumnName.Trim.ToLower = "Tick".ToLower Then
                    Exit Sub
                End If
            Catch
                Exit Sub
            End Try

            If SelectedDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not CBool(Me.dgLocations(Me.dgLocations.CurrentRowIndex, 0))
            Me.dgLocations(Me.dgLocations.CurrentRowIndex, 0) = selected
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult =DialogResult.Cancel
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not Locations.Table.Select("Tick=1").Length = 1 Then
            ShowMessage("Please ensure only one location has been selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        With CType(Locations.Table.Select("Tick=1")(0), DataRow)
            If .Item("Type") = "Warehouse" Then
                _LocationID = .Item("ID")
                _PartSupplierID = 0
                _SupplierID = 0
            Else
                _LocationID = 0
                _PartSupplierID = .Item("ID")
                _SupplierID = .Item("OtherID")
            End If

            _InPack = .Item("InPack")
            _Price = .Item("Price")
        End With

        Me.DialogResult =DialogResult.OK
    End Sub

#End Region

End Class

