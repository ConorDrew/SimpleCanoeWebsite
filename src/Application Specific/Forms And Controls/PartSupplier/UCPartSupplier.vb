Public Class UCPartSupplier : Inherits FSM.UCBase : Implements IUserControl

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

    Friend WithEvents grpPartSupplier As System.Windows.Forms.GroupBox
    Friend WithEvents txtPartCode As System.Windows.Forms.TextBox
    Friend WithEvents lblPartCode As System.Windows.Forms.Label
    Friend WithEvents cboSupplierID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupplierID As System.Windows.Forms.Label
    Friend WithEvents txtQuantityInPack As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantityInPack As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSecondaryPrice As TextBox
    Friend WithEvents lblSecondaryPrice As Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpPartSupplier = New System.Windows.Forms.GroupBox()
        Me.txtSecondaryPrice = New System.Windows.Forms.TextBox()
        Me.lblSecondaryPrice = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPartCode = New System.Windows.Forms.TextBox()
        Me.lblPartCode = New System.Windows.Forms.Label()
        Me.cboSupplierID = New System.Windows.Forms.ComboBox()
        Me.lblSupplierID = New System.Windows.Forms.Label()
        Me.txtQuantityInPack = New System.Windows.Forms.TextBox()
        Me.lblQuantityInPack = New System.Windows.Forms.Label()
        Me.grpPartSupplier.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpPartSupplier
        '
        Me.grpPartSupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPartSupplier.Controls.Add(Me.txtSecondaryPrice)
        Me.grpPartSupplier.Controls.Add(Me.lblSecondaryPrice)
        Me.grpPartSupplier.Controls.Add(Me.txtPrice)
        Me.grpPartSupplier.Controls.Add(Me.Label1)
        Me.grpPartSupplier.Controls.Add(Me.txtPartCode)
        Me.grpPartSupplier.Controls.Add(Me.lblPartCode)
        Me.grpPartSupplier.Controls.Add(Me.cboSupplierID)
        Me.grpPartSupplier.Controls.Add(Me.lblSupplierID)
        Me.grpPartSupplier.Controls.Add(Me.txtQuantityInPack)
        Me.grpPartSupplier.Controls.Add(Me.lblQuantityInPack)
        Me.grpPartSupplier.Location = New System.Drawing.Point(9, 1)
        Me.grpPartSupplier.Name = "grpPartSupplier"
        Me.grpPartSupplier.Size = New System.Drawing.Size(578, 141)
        Me.grpPartSupplier.TabIndex = 1
        Me.grpPartSupplier.TabStop = False
        Me.grpPartSupplier.Text = "Main Details"
        '
        'txtSecondaryPrice
        '
        Me.txtSecondaryPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSecondaryPrice.Location = New System.Drawing.Point(376, 107)
        Me.txtSecondaryPrice.Name = "txtSecondaryPrice"
        Me.txtSecondaryPrice.Size = New System.Drawing.Size(192, 21)
        Me.txtSecondaryPrice.TabIndex = 33
        Me.txtSecondaryPrice.Visible = False
        '
        'lblSecondaryPrice
        '
        Me.lblSecondaryPrice.Location = New System.Drawing.Point(263, 107)
        Me.lblSecondaryPrice.Name = "lblSecondaryPrice"
        Me.lblSecondaryPrice.Size = New System.Drawing.Size(105, 23)
        Me.lblSecondaryPrice.TabIndex = 34
        Me.lblSecondaryPrice.Text = "Secondary Price"
        Me.lblSecondaryPrice.Visible = False
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrice.Location = New System.Drawing.Point(376, 80)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(192, 21)
        Me.txtPrice.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(328, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 23)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Price"
        '
        'txtPartCode
        '
        Me.txtPartCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartCode.Location = New System.Drawing.Point(128, 52)
        Me.txtPartCode.MaxLength = 100
        Me.txtPartCode.Name = "txtPartCode"
        Me.txtPartCode.Size = New System.Drawing.Size(440, 21)
        Me.txtPartCode.TabIndex = 2
        Me.txtPartCode.Tag = "PartSupplier.PartCode"
        '
        'lblPartCode
        '
        Me.lblPartCode.Location = New System.Drawing.Point(8, 53)
        Me.lblPartCode.Name = "lblPartCode"
        Me.lblPartCode.Size = New System.Drawing.Size(111, 20)
        Me.lblPartCode.TabIndex = 31
        Me.lblPartCode.Text = "Part Code (SPN)"
        '
        'cboSupplierID
        '
        Me.cboSupplierID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSupplierID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSupplierID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplierID.Location = New System.Drawing.Point(128, 23)
        Me.cboSupplierID.Name = "cboSupplierID"
        Me.cboSupplierID.Size = New System.Drawing.Size(440, 21)
        Me.cboSupplierID.TabIndex = 1
        Me.cboSupplierID.Tag = "PartSupplier.SupplierID"
        '
        'lblSupplierID
        '
        Me.lblSupplierID.Location = New System.Drawing.Point(8, 24)
        Me.lblSupplierID.Name = "lblSupplierID"
        Me.lblSupplierID.Size = New System.Drawing.Size(69, 20)
        Me.lblSupplierID.TabIndex = 31
        Me.lblSupplierID.Text = "Supplier "
        '
        'txtQuantityInPack
        '
        Me.txtQuantityInPack.Location = New System.Drawing.Point(128, 80)
        Me.txtQuantityInPack.MaxLength = 8
        Me.txtQuantityInPack.Name = "txtQuantityInPack"
        Me.txtQuantityInPack.Size = New System.Drawing.Size(184, 21)
        Me.txtQuantityInPack.TabIndex = 3
        Me.txtQuantityInPack.Tag = "PartSupplier.QuantityInPack"
        Me.txtQuantityInPack.Text = "1"
        '
        'lblQuantityInPack
        '
        Me.lblQuantityInPack.Location = New System.Drawing.Point(8, 82)
        Me.lblQuantityInPack.Name = "lblQuantityInPack"
        Me.lblQuantityInPack.Size = New System.Drawing.Size(111, 20)
        Me.lblQuantityInPack.TabIndex = 31
        Me.lblQuantityInPack.Text = "Quantity In Pack"
        '
        'UCPartSupplier
        '
        Me.Controls.Add(Me.grpPartSupplier)
        Me.Name = "UCPartSupplier"
        Me.Size = New System.Drawing.Size(592, 150)
        Me.grpPartSupplier.ResumeLayout(False)
        Me.grpPartSupplier.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentPartSupplier
        End Get
    End Property

#End Region

#Region "Properties"

    Private _PartID As Integer = 0
    Private _PrimaryUpdate As Boolean = False
    Private _SecondaryUpdate As Boolean = False
    Public Property PartID() As Integer
        Get
            Return _PartID
        End Get
        Set(ByVal Value As Integer)
            _PartID = Value
        End Set
    End Property

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentPartSupplier As Entity.PartSuppliers.PartSupplier
    Public Property CurrentPartSupplier() As Entity.PartSuppliers.PartSupplier
        Get
            Return _currentPartSupplier
        End Get
        Set(ByVal Value As Entity.PartSuppliers.PartSupplier)
            _currentPartSupplier = Value

            If CurrentPartSupplier Is Nothing Then
                CurrentPartSupplier = New Entity.PartSuppliers.PartSupplier
                CurrentPartSupplier.Exists = False
                txtQuantityInPack.Text = "1"
            End If

            If CurrentPartSupplier.Exists Then
                Populate()
                Me.cboSupplierID.Enabled = False
            Else
                Me.cboSupplierID.Enabled = True
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCPartSupplier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentPartSupplier = DB.PartSupplier.PartSupplier_Get(ID)
        End If

        Me.txtPartCode.Text = CurrentPartSupplier.PartCode
        Combo.SetSelectedComboItem_By_Value(Me.cboSupplierID, CurrentPartSupplier.SupplierID)
        Me.txtQuantityInPack.Text = CurrentPartSupplier.QuantityInPack
        Me.txtPrice.Text = CurrentPartSupplier.Price
        Me.txtSecondaryPrice.Text = CurrentPartSupplier.SecondaryPrice

        If Not DB.Supplier.Supplier_GetSecondaryPrice(CurrentPartSupplier.SupplierID) Then
            Me.txtSecondaryPrice.Visible = False
            Me.lblSecondaryPrice.Visible = False
        End If
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            'If EnterOverridePassword() Then
            Dim ssm As Entity.Sys.Enums.SecuritySystemModules
            ssm = Entity.Sys.Enums.SecuritySystemModules.EditParts
            Dim ssm2 As Entity.Sys.Enums.SecuritySystemModules
            ssm2 = Entity.Sys.Enums.SecuritySystemModules.CreateParts
            If loggedInUser.HasAccessToModule(ssm) = True Or loggedInUser.HasAccessToModule(ssm2) = True Then
                Me.Cursor = Cursors.WaitCursor
                CurrentPartSupplier.IgnoreExceptionsOnSetMethods = True

                CurrentPartSupplier.SetPartCode = Me.txtPartCode.Text.Trim
                CurrentPartSupplier.SetPartID = PartID
                CurrentPartSupplier.SetSupplierID = Combo.GetSelectedItemValue(Me.cboSupplierID)
                CurrentPartSupplier.SetQuantityInPack = Me.txtQuantityInPack.Text.Trim
                CurrentPartSupplier.SetPrice = Me.txtPrice.Text.Trim
                If Not String.IsNullOrEmpty(Me.txtSecondaryPrice.Text.Trim) Then
                    CurrentPartSupplier.SetSecondaryPrice = Me.txtSecondaryPrice.Text.Trim
                End If

                Dim cV As New Entity.PartSuppliers.PartSupplierValidator
                cV.Validate(CurrentPartSupplier)

                If CurrentPartSupplier.Exists Then
                    DB.PartSupplier.Update(CurrentPartSupplier, _PrimaryUpdate, _SecondaryUpdate)
                Else
                    CurrentPartSupplier = DB.PartSupplier.Insert(CurrentPartSupplier)
                End If

                RaiseEvent StateChanged(CurrentPartSupplier.PartSupplierID)

                Return True
            Else
                Return False
            End If
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

    Private Sub cboSupplierID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSupplierID.SelectedIndexChanged
        If Not DB.Supplier.Supplier_GetSecondaryPrice(Combo.GetSelectedItemValue(Me.cboSupplierID)) Then
            Me.txtSecondaryPrice.Visible = False
            Me.lblSecondaryPrice.Visible = False
        Else
            Me.txtSecondaryPrice.Visible = True
            Me.lblSecondaryPrice.Visible = True
        End If
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.KeyDown, txtSecondaryPrice.KeyDown
        If CType(sender, TextBox).Name = "txtPrice" Then
            _PrimaryUpdate = True
        ElseIf CType(sender, TextBox).Name = "txtSecondaryPrice" Then
            _SecondaryUpdate = True
        End If
    End Sub

#End Region

End Class

