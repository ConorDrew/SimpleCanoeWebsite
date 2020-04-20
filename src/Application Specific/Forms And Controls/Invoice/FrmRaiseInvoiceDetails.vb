Public Class FrmRaiseInvoiceDetails : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents dgInvoiceAddresses As System.Windows.Forms.DataGrid

    Friend WithEvents dtpRaiseInvoiceOn As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRaiseInvoiceOn As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceAddress As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents gpbRaiseInvoice As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gpbRaiseInvoice = New System.Windows.Forms.GroupBox
        Me.dgInvoiceAddresses = New System.Windows.Forms.DataGrid
        Me.dtpRaiseInvoiceOn = New System.Windows.Forms.DateTimePicker
        Me.lblRaiseInvoiceOn = New System.Windows.Forms.Label
        Me.lblInvoiceAddress = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.gpbRaiseInvoice.SuspendLayout()
        CType(Me.dgInvoiceAddresses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbRaiseInvoice
        '
        Me.gpbRaiseInvoice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbRaiseInvoice.Controls.Add(Me.dgInvoiceAddresses)
        Me.gpbRaiseInvoice.Controls.Add(Me.dtpRaiseInvoiceOn)
        Me.gpbRaiseInvoice.Controls.Add(Me.lblRaiseInvoiceOn)
        Me.gpbRaiseInvoice.Controls.Add(Me.lblInvoiceAddress)
        Me.gpbRaiseInvoice.Controls.Add(Me.btnOK)

        Me.gpbRaiseInvoice.Location = New System.Drawing.Point(8, 32)
        Me.gpbRaiseInvoice.Name = "gpbRaiseInvoice"
        Me.gpbRaiseInvoice.Size = New System.Drawing.Size(512, 240)
        Me.gpbRaiseInvoice.TabIndex = 2
        Me.gpbRaiseInvoice.TabStop = False
        Me.gpbRaiseInvoice.Text = "Raise Invoice"
        '
        'dgInvoiceAddresses
        '
        Me.dgInvoiceAddresses.DataMember = ""
        Me.dgInvoiceAddresses.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgInvoiceAddresses.Location = New System.Drawing.Point(16, 64)
        Me.dgInvoiceAddresses.Name = "dgInvoiceAddresses"
        Me.dgInvoiceAddresses.Size = New System.Drawing.Size(488, 136)
        Me.dgInvoiceAddresses.TabIndex = 7
        '
        'dtpRaiseInvoiceOn
        '
        Me.dtpRaiseInvoiceOn.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpRaiseInvoiceOn.Location = New System.Drawing.Point(136, 24)
        Me.dtpRaiseInvoiceOn.Name = "dtpRaiseInvoiceOn"
        Me.dtpRaiseInvoiceOn.Size = New System.Drawing.Size(120, 21)
        Me.dtpRaiseInvoiceOn.TabIndex = 6
        '
        'lblRaiseInvoiceOn
        '
        Me.lblRaiseInvoiceOn.Location = New System.Drawing.Point(16, 24)
        Me.lblRaiseInvoiceOn.Name = "lblRaiseInvoiceOn"
        Me.lblRaiseInvoiceOn.Size = New System.Drawing.Size(112, 23)
        Me.lblRaiseInvoiceOn.TabIndex = 5
        Me.lblRaiseInvoiceOn.Text = "Raise Invoice On:"
        Me.lblRaiseInvoiceOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInvoiceAddress
        '
        Me.lblInvoiceAddress.Location = New System.Drawing.Point(16, 48)
        Me.lblInvoiceAddress.Name = "lblInvoiceAddress"
        Me.lblInvoiceAddress.TabIndex = 8
        Me.lblInvoiceAddress.Text = "Invoice Address"
        '
        'btnOK
        '
        Me.btnOK.UseVisualStyleBackColor = True
        Me.btnOK.Location = New System.Drawing.Point(216, 208)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'FrmRaiseInvoiceDetails
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(528, 278)
        Me.ControlBox = False
        Me.Controls.Add(Me.gpbRaiseInvoice)
        Me.Name = "FrmRaiseInvoiceDetails"
        Me.Text = "Raise Invoice"
        Me.Controls.SetChildIndex(Me.gpbRaiseInvoice, 0)
        Me.gpbRaiseInvoice.ResumeLayout(False)
        CType(Me.dgInvoiceAddresses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        OrderID = GetParameter(0)
        LoadForm(sender, e, Me)
        Dim orderInvoiceAddressID As Integer = 0

        Try
            orderInvoiceAddressID = GetParameter(1)
        Catch ex As Exception
            'AMY PUT EMPTY TRY
        End Try

        SetupInvoiceAddressDataGrid()
        'Set raise date to today
        dtpRaiseInvoiceOn.Value = Now

        'Load Invoice Addresses
        InvoiceAddresses = DB.InvoiceAddress.InvoiceAddress_Get_OrderID(OrderID)
        If InvoiceAddresses.Table.Rows.Count > 0 Then
            dgInvoiceAddresses.CurrentRowIndex = 0

            dgInvoiceAddresses.Select(dgInvoiceAddresses.CurrentRowIndex)
        End If

        If orderInvoiceAddressID > 0 Then
            Dim rwCnt As Integer = 0
            For Each dr As DataRow In InvoiceAddresses.Table.Rows
                If dr("AddressType") = Entity.Sys.Enums.InvoiceAddressType.Invoice.ToString And
                    dr("AddressID") = orderInvoiceAddressID Then

                    If InvoiceAddresses.Table.Rows.Count > 0 Then
                        dgInvoiceAddresses.UnSelect(dgInvoiceAddresses.CurrentRowIndex)
                    End If

                    dgInvoiceAddresses.CurrentRowIndex = rwCnt
                    dgInvoiceAddresses.Select(dgInvoiceAddresses.CurrentRowIndex)
                    Exit For
                Else
                    rwCnt += 1
                End If
            Next
        End If

    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe

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

        'Dim Tick As New DataGridBoolColumn
        'Tick.HeaderText = ""
        'Tick.MappingName = "Tick"
        'Tick.ReadOnly = True
        'Tick.Width = 25
        'Tick.NullText = ""
        'tStyle.GridColumnStyles.Add(Tick)

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

#End Region

#Region " Events "

    Private Sub FrmRaiseInvoiceDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If SelectedInvoiceAddressesDataRow Is Nothing And InvoiceAddresses.Table.Rows.Count > 0 Then
            Exit Sub
        Else
            Dim Invoice2BRaised As New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
            Invoice2BRaised.RaiseDate = dtpRaiseInvoiceOn.Value
            Invoice2BRaised.SetInvoiceTypeID = CInt(Entity.Sys.Enums.InvoiceType.Order)
            Invoice2BRaised.SetLinkID = OrderID

            If SelectedInvoiceAddressesDataRow Is Nothing And InvoiceAddresses.Table.Rows.Count = 0 Then
                MessageBox.Show("There is no invoice addresses to select. You will need to select an address at invoice generation", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Invoice2BRaised.SetAddressLinkID = SelectedInvoiceAddressesDataRow("AddressID")
                Invoice2BRaised.SetAddressTypeID = SelectedInvoiceAddressesDataRow("AddressTypeID")
            End If

            DB.InvoiceToBeRaised.Insert(Invoice2BRaised)
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If

    End Sub

    Private Sub dgInvoiceAddresses_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInvoiceAddresses.Click
        If InvoiceAddresses.Table.Rows.Count > 0 Then
            dgInvoiceAddresses.Select(dgInvoiceAddresses.CurrentRowIndex)
        End If
    End Sub

#End Region

End Class