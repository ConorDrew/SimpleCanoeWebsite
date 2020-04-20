Public Class UCProductSupplier : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Combo.SetUpCombo(Me.cboSupplierID, DB.Supplier.Supplier_GetAll.Table, "SupplierID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
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

    Friend WithEvents grpProductSupplier As System.Windows.Forms.GroupBox
    Friend WithEvents cboSupplierID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupplierID As System.Windows.Forms.Label
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents lblProductCode As System.Windows.Forms.Label
    Friend WithEvents txtQuantityInPack As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantityInPack As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpProductSupplier = New System.Windows.Forms.GroupBox
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboSupplierID = New System.Windows.Forms.ComboBox
        Me.lblSupplierID = New System.Windows.Forms.Label
        Me.txtProductCode = New System.Windows.Forms.TextBox
        Me.lblProductCode = New System.Windows.Forms.Label
        Me.txtQuantityInPack = New System.Windows.Forms.TextBox
        Me.lblQuantityInPack = New System.Windows.Forms.Label
        Me.grpProductSupplier.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpProductSupplier
        '
        Me.grpProductSupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProductSupplier.Controls.Add(Me.txtPrice)
        Me.grpProductSupplier.Controls.Add(Me.Label1)
        Me.grpProductSupplier.Controls.Add(Me.cboSupplierID)
        Me.grpProductSupplier.Controls.Add(Me.lblSupplierID)
        Me.grpProductSupplier.Controls.Add(Me.txtProductCode)
        Me.grpProductSupplier.Controls.Add(Me.lblProductCode)
        Me.grpProductSupplier.Controls.Add(Me.txtQuantityInPack)
        Me.grpProductSupplier.Controls.Add(Me.lblQuantityInPack)
        Me.grpProductSupplier.Location = New System.Drawing.Point(0, 1)
        Me.grpProductSupplier.Name = "grpProductSupplier"
        Me.grpProductSupplier.Size = New System.Drawing.Size(584, 112)
        Me.grpProductSupplier.TabIndex = 1
        Me.grpProductSupplier.TabStop = False
        Me.grpProductSupplier.Text = "Main Details"
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrice.Location = New System.Drawing.Point(384, 80)
        Me.txtPrice.MaxLength = 8
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(191, 21)
        Me.txtPrice.TabIndex = 33
        Me.txtPrice.Tag = "ProductSupplier.Price"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(336, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 18)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Price"
        '
        'cboSupplierID
        '
        Me.cboSupplierID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSupplierID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSupplierID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplierID.Location = New System.Drawing.Point(136, 24)
        Me.cboSupplierID.Name = "cboSupplierID"
        Me.cboSupplierID.Size = New System.Drawing.Size(439, 21)
        Me.cboSupplierID.TabIndex = 3
        Me.cboSupplierID.Tag = "ProductSupplier.SupplierID"
        '
        'lblSupplierID
        '
        Me.lblSupplierID.Location = New System.Drawing.Point(8, 24)
        Me.lblSupplierID.Name = "lblSupplierID"
        Me.lblSupplierID.Size = New System.Drawing.Size(67, 20)
        Me.lblSupplierID.TabIndex = 31
        Me.lblSupplierID.Text = "Supplier"
        '
        'txtProductCode
        '
        Me.txtProductCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductCode.Location = New System.Drawing.Point(136, 51)
        Me.txtProductCode.MaxLength = 100
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(439, 21)
        Me.txtProductCode.TabIndex = 4
        Me.txtProductCode.Tag = "ProductSupplier.ProductCode"
        '
        'lblProductCode
        '
        Me.lblProductCode.Location = New System.Drawing.Point(8, 51)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(94, 20)
        Me.lblProductCode.TabIndex = 31
        Me.lblProductCode.Text = "Product Code"
        '
        'txtQuantityInPack
        '
        Me.txtQuantityInPack.Location = New System.Drawing.Point(136, 79)
        Me.txtQuantityInPack.MaxLength = 8
        Me.txtQuantityInPack.Name = "txtQuantityInPack"
        Me.txtQuantityInPack.Size = New System.Drawing.Size(184, 21)
        Me.txtQuantityInPack.TabIndex = 6
        Me.txtQuantityInPack.Tag = "ProductSupplier.QuantityInPack"
        Me.txtQuantityInPack.Text = "1"
        '
        'lblQuantityInPack
        '
        Me.lblQuantityInPack.Location = New System.Drawing.Point(8, 79)
        Me.lblQuantityInPack.Name = "lblQuantityInPack"
        Me.lblQuantityInPack.Size = New System.Drawing.Size(114, 20)
        Me.lblQuantityInPack.TabIndex = 31
        Me.lblQuantityInPack.Text = "Quantity In Pack"
        '
        'UCProductSupplier
        '
        Me.Controls.Add(Me.grpProductSupplier)
        Me.Name = "UCProductSupplier"
        Me.Size = New System.Drawing.Size(592, 120)
        Me.grpProductSupplier.ResumeLayout(False)
        Me.grpProductSupplier.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentProductSupplier
        End Get
    End Property

#End Region

#Region "Properties"

    Private _ProductID As Integer = 0
    Public Property ProductID() As Integer
        Get
            Return _ProductID
        End Get
        Set(ByVal Value As Integer)
            _ProductID = Value
        End Set
    End Property

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentProductSupplier As Entity.ProductSuppliers.ProductSupplier
    Public Property CurrentProductSupplier() As Entity.ProductSuppliers.ProductSupplier
        Get
            Return _currentProductSupplier
        End Get
        Set(ByVal Value As Entity.ProductSuppliers.ProductSupplier)
            _currentProductSupplier = Value

            If CurrentProductSupplier Is Nothing Then
                CurrentProductSupplier = New Entity.ProductSuppliers.ProductSupplier
                CurrentProductSupplier.Exists = False
                txtQuantityInPack.Text = "1"
            End If

            If CurrentProductSupplier.Exists Then
                Populate()
                Me.cboSupplierID.Enabled = False
            Else
                Me.cboSupplierID.Enabled = True
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCProductSupplier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentProductSupplier = DB.ProductSupplier.ProductSupplier_Get(ID)
        End If

        Combo.SetSelectedComboItem_By_Value(Me.cboSupplierID, CurrentProductSupplier.SupplierID)
        Me.txtProductCode.Text = CurrentProductSupplier.ProductCode
        Me.txtQuantityInPack.Text = CurrentProductSupplier.QuantityInPack
        Me.txtPrice.Text = CurrentProductSupplier.Price

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentProductSupplier.IgnoreExceptionsOnSetMethods = True

            CurrentProductSupplier.SetProductID = ProductID
            CurrentProductSupplier.SetSupplierID = Combo.GetSelectedItemValue(Me.cboSupplierID)
            CurrentProductSupplier.SetProductCode = Me.txtProductCode.Text.Trim
            CurrentProductSupplier.SetQuantityInPack = Me.txtQuantityInPack.Text.Trim
            CurrentProductSupplier.SetPrice = Me.txtPrice.Text

            Dim cV As New Entity.ProductSuppliers.ProductSupplierValidator
            cV.Validate(CurrentProductSupplier)

            If CurrentProductSupplier.Exists Then
                DB.ProductSupplier.Update(CurrentProductSupplier)
            Else
                CurrentProductSupplier = DB.ProductSupplier.Insert(CurrentProductSupplier)
            End If

            RaiseEvent StateChanged(CurrentProductSupplier.ProductSupplierID)

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

#End Region

End Class

