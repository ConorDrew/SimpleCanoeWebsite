Public Class FRMAddInvoiceAddress : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents gpbSelectInvoiceAddress As System.Windows.Forms.GroupBox

    Friend WithEvents dgInvoiceAddresses As System.Windows.Forms.DataGrid
    Friend WithEvents lblInvoiceAddress As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gpbSelectInvoiceAddress = New System.Windows.Forms.GroupBox
        Me.dgInvoiceAddresses = New System.Windows.Forms.DataGrid
        Me.lblInvoiceAddress = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.gpbSelectInvoiceAddress.SuspendLayout()
        CType(Me.dgInvoiceAddresses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbSelectInvoiceAddress
        '
        Me.gpbSelectInvoiceAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbSelectInvoiceAddress.Controls.Add(Me.btnCancel)
        Me.gpbSelectInvoiceAddress.Controls.Add(Me.dgInvoiceAddresses)
        Me.gpbSelectInvoiceAddress.Controls.Add(Me.lblInvoiceAddress)
        Me.gpbSelectInvoiceAddress.Controls.Add(Me.btnOK)

        Me.gpbSelectInvoiceAddress.Location = New System.Drawing.Point(8, 40)
        Me.gpbSelectInvoiceAddress.Name = "gpbSelectInvoiceAddress"
        Me.gpbSelectInvoiceAddress.Size = New System.Drawing.Size(512, 328)
        Me.gpbSelectInvoiceAddress.TabIndex = 3
        Me.gpbSelectInvoiceAddress.TabStop = False
        Me.gpbSelectInvoiceAddress.Text = "Select Invoice Address"
        '
        'dgInvoiceAddresses
        '
        Me.dgInvoiceAddresses.DataMember = ""
        Me.dgInvoiceAddresses.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgInvoiceAddresses.Location = New System.Drawing.Point(16, 48)
        Me.dgInvoiceAddresses.Name = "dgInvoiceAddresses"
        Me.dgInvoiceAddresses.Size = New System.Drawing.Size(488, 240)
        Me.dgInvoiceAddresses.TabIndex = 7
        '
        'lblInvoiceAddress
        '
        Me.lblInvoiceAddress.Location = New System.Drawing.Point(16, 24)
        Me.lblInvoiceAddress.Name = "lblInvoiceAddress"
        Me.lblInvoiceAddress.TabIndex = 8
        Me.lblInvoiceAddress.Text = "Invoice Address"
        '
        'btnOK
        '
        Me.btnOK.UseVisualStyleBackColor = True
        Me.btnOK.Location = New System.Drawing.Point(424, 296)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Location = New System.Drawing.Point(16, 296)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'FRMAddInvoiceAddress
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(528, 382)
        Me.ControlBox = False
        Me.Controls.Add(Me.gpbSelectInvoiceAddress)
        Me.MaximumSize = New System.Drawing.Size(536, 416)
        Me.MinimumSize = New System.Drawing.Size(536, 416)
        Me.Name = "FRMAddInvoiceAddress"
        Me.Text = "Select Invoice Address"
        Me.Controls.SetChildIndex(Me.gpbSelectInvoiceAddress, 0)
        Me.gpbSelectInvoiceAddress.ResumeLayout(False)
        CType(Me.dgInvoiceAddresses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        OrderID = GetParameter(0)
        SetupInvoiceAddressDataGrid()
        'Load Invoice Addresses
        InvoiceAddresses = DB.InvoiceAddress.InvoiceAddress_Get_OrderID(OrderID)
        If InvoiceAddresses.Table.Rows.Count > 0 Then
            dgInvoiceAddresses.CurrentRowIndex = 0

            dgInvoiceAddresses.Select(dgInvoiceAddresses.CurrentRowIndex)
        End If

        InvoiceToBeRaised = DB.InvoiceToBeRaised.InvoiceToBeRaised_Get(GetParameter(1))

        AddHandler AddressSelected, AddressOf CType(GetParameter(2), FRMInvoiceManager).PopulateDatagrid
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region " Setup "

    Public Sub SetupInvoiceAddressDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgInvoiceAddresses)
        Dim tStyle As DataGridTableStyle = Me.dgInvoiceAddresses.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False
        dgInvoiceAddresses.ReadOnly = False

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
        Me.dgInvoiceAddresses.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region " Properties "

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
            dgInvoiceAddresses.DataSource = InvoiceAddresses
        End Set
    End Property

    Private ReadOnly Property SelectedInvoiceAddressesDataRow() As DataRow
        Get
            If Not Me.dgInvoiceAddresses.CurrentRowIndex = -1 Then
                Return InvoiceAddresses(Me.dgInvoiceAddresses.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _OrderID As Integer

    Private Property OrderID() As Integer
        Get
            Return _OrderID
        End Get
        Set(ByVal Value As Integer)
            _OrderID = Value
        End Set
    End Property

    Private _InvoiceToBeRaised As Entity.InvoiceToBeRaiseds.InvoiceToBeRaised

    Private Property InvoiceToBeRaised() As Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
        Get
            Return _InvoiceToBeRaised
        End Get
        Set(ByVal Value As Entity.InvoiceToBeRaiseds.InvoiceToBeRaised)
            _InvoiceToBeRaised = Value
        End Set
    End Property

    Private Event AddressSelected()

#End Region

#Region " Events "

    Private Sub FRMAddInvoiceAddress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not SelectedInvoiceAddressesDataRow Is Nothing Then
            InvoiceToBeRaised.SetAddressLinkID = SelectedInvoiceAddressesDataRow("AddressID")
            InvoiceToBeRaised.SetAddressTypeID = SelectedInvoiceAddressesDataRow("AddressTypeID")
            DB.InvoiceToBeRaised.Update(InvoiceToBeRaised)
            RaiseEvent AddressSelected()
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If

    End Sub

#End Region

End Class