Public Class UCPartsToBeCredited : Inherits FSM.UCBase : Implements IUserControl

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
    Friend WithEvents PartToBeCredited As System.Windows.Forms.GroupBox
    Friend WithEvents btnFindPart As System.Windows.Forms.Button
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnFindSupplier As System.Windows.Forms.Button
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnFindOrder As System.Windows.Forms.Button
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PartToBeCredited = New System.Windows.Forms.GroupBox
        Me.btnFindPart = New System.Windows.Forms.Button
        Me.txtPart = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnFindSupplier = New System.Windows.Forms.Button
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnFindOrder = New System.Windows.Forms.Button
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.txtOrder = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PartToBeCredited.SuspendLayout()
        Me.SuspendLayout()
        '
        'PartToBeCredited
        '
        Me.PartToBeCredited.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PartToBeCredited.Controls.Add(Me.btnFindPart)
        Me.PartToBeCredited.Controls.Add(Me.txtPart)
        Me.PartToBeCredited.Controls.Add(Me.Label4)
        Me.PartToBeCredited.Controls.Add(Me.btnFindSupplier)
        Me.PartToBeCredited.Controls.Add(Me.txtSupplier)
        Me.PartToBeCredited.Controls.Add(Me.Label3)
        Me.PartToBeCredited.Controls.Add(Me.btnFindOrder)
        Me.PartToBeCredited.Controls.Add(Me.txtQty)
        Me.PartToBeCredited.Controls.Add(Me.txtOrder)
        Me.PartToBeCredited.Controls.Add(Me.Label2)
        Me.PartToBeCredited.Controls.Add(Me.Label1)
        Me.PartToBeCredited.Location = New System.Drawing.Point(0, 3)
        Me.PartToBeCredited.Name = "PartToBeCredited"
        Me.PartToBeCredited.Size = New System.Drawing.Size(548, 147)
        Me.PartToBeCredited.TabIndex = 0
        Me.PartToBeCredited.TabStop = False
        Me.PartToBeCredited.Text = "Part To Be Credited"
        '
        'btnFindPart
        '
        Me.btnFindPart.Location = New System.Drawing.Point(465, 82)
        Me.btnFindPart.Name = "btnFindPart"
        Me.btnFindPart.Size = New System.Drawing.Size(34, 23)
        Me.btnFindPart.TabIndex = 8
        Me.btnFindPart.Text = "..."
        Me.btnFindPart.UseVisualStyleBackColor = True
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(106, 84)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.ReadOnly = True
        Me.txtPart.Size = New System.Drawing.Size(353, 21)
        Me.txtPart.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Part"
        '
        'btnFindSupplier
        '
        Me.btnFindSupplier.Location = New System.Drawing.Point(465, 55)
        Me.btnFindSupplier.Name = "btnFindSupplier"
        Me.btnFindSupplier.Size = New System.Drawing.Size(34, 23)
        Me.btnFindSupplier.TabIndex = 5
        Me.btnFindSupplier.Text = "..."
        Me.btnFindSupplier.UseVisualStyleBackColor = True
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(106, 57)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(353, 21)
        Me.txtSupplier.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Supplier"
        '
        'btnFindOrder
        '
        Me.btnFindOrder.Location = New System.Drawing.Point(465, 28)
        Me.btnFindOrder.Name = "btnFindOrder"
        Me.btnFindOrder.Size = New System.Drawing.Size(34, 23)
        Me.btnFindOrder.TabIndex = 2
        Me.btnFindOrder.Text = "..."
        Me.btnFindOrder.UseVisualStyleBackColor = True
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(106, 111)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(100, 21)
        Me.txtQty.TabIndex = 10
        '
        'txtOrder
        '
        Me.txtOrder.Location = New System.Drawing.Point(106, 30)
        Me.txtOrder.Name = "txtOrder"
        Me.txtOrder.Size = New System.Drawing.Size(353, 21)
        Me.txtOrder.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Quantity"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order"
        '
        'UCPartsToBeCredited
        '
        Me.Controls.Add(Me.PartToBeCredited)
        Me.Name = "UCPartsToBeCredited"
        Me.Size = New System.Drawing.Size(565, 163)
        Me.PartToBeCredited.ResumeLayout(False)
        Me.PartToBeCredited.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentPartsToBeCredited
        End Get
    End Property

#End Region

#Region "Properties"
    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentPartsToBeCredited As Entity.PartsToBeCrediteds.PartsToBeCredited
    Public Property CurrentPartsToBeCredited() As Entity.PartsToBeCrediteds.PartsToBeCredited
        Get
            Return _currentPartsToBeCredited
        End Get
        Set(ByVal Value As Entity.PartsToBeCrediteds.PartsToBeCredited)
            _currentPartsToBeCredited = Value

            If CurrentPartsToBeCredited Is Nothing Then
                _currentPartsToBeCredited = New Entity.PartsToBeCrediteds.PartsToBeCredited
                _currentPartsToBeCredited.Exists = False
            End If

            If CurrentPartsToBeCredited.Exists Then
                Populate()
            End If
        End Set
    End Property

    Private _OrderID As Integer
    Public Property OrderID() As Integer
        Get
            Return _OrderID
        End Get
        Set(ByVal Value As Integer)
            _OrderID = Value
            If _OrderID > 0 Then
                Dim oOrder As Entity.Orders.Order = DB.Order.Order_Get(OrderID)
                If oOrder.Exists Then
                    txtOrder.Text = oOrder.OrderReference
                    txtOrder.ReadOnly = True
                    Dim dr() As DataRow = DB.Order.Order_ItemsGetAll(OrderID).Table.Select("SupplierID > 0 ")
                    If dr.Length > 0 Then
                        SupplierID = dr(0).Item("SupplierID")
                        btnFindSupplier.Enabled = False
                    Else
                        SupplierID = 0
                        btnFindSupplier.Enabled = True
                    End If
                End If
            Else
                txtOrder.Text = ""
                txtOrder.ReadOnly = False
                SupplierID = 0
                btnFindSupplier.Enabled = True
            End If
        End Set
    End Property

    Private _SupplierID As Integer
    Public Property SupplierID() As Integer
        Get
            Return _SupplierID
        End Get
        Set(ByVal Value As Integer)
            _SupplierID = Value
            If _SupplierID > 0 Then
                Dim oSupplier As Entity.Suppliers.Supplier = DB.Supplier.Supplier_Get(_SupplierID)
                If oSupplier.Exists Then
                    txtSupplier.Text = oSupplier.Name
                End If
            Else
                txtSupplier.Text = ""
            End If
        End Set
    End Property

    Private _PartID As Integer = 0
    Private Property PartID() As Integer
        Get
            Return _PartID
        End Get
        Set(ByVal value As Integer)
            _PartID = value
            If _PartID > 0 Then
                Dim oPart As Entity.Parts.Part = DB.Part.Part_Get(_PartID)
                If Not oPart Is Nothing Then
                    txtPart.Text = oPart.Name & " (" & oPart.Number & ") "
                End If
            Else
                txtPart.Text = ""
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCPartsToBeCredited_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub


    Private Sub btnFindOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindOrder.Click
        OrderID = FindRecord(Entity.Sys.Enums.TableNames.tblOrder)
    End Sub

    Private Sub btnFindSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSupplier.Click
        SupplierID = FindRecord(Entity.Sys.Enums.TableNames.tblSupplier)
    End Sub

    Private Sub btnFindPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPart.Click
        FindPart()
    End Sub

#End Region

#Region "Functions"

    Private Sub FindPart(Optional ByVal PartNumber As String = "")
        PartID = FindRecord(Entity.Sys.Enums.TableNames.tblPart, OrderID, PartNumber)
        If PartID > 0 Then
            If SupplierID > 0 Then
                If DB.PartSupplier.PartSupplierPacks_Get(PartID, SupplierID).Table.Rows.Count = 0 Then
                    ShowMessage("This part is not supplied by the choosen supplier.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim foundPartNumber As String = DB.Part.Part_Get(PartID).Number
                    PartID = 0
                    FindPart(foundPartNumber)
                End If
            End If
        End If

    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate

        If Not ID = 0 Then
            CurrentPartsToBeCredited = DB.PartsToBeCredited.PartsToBeCredited_Get(ID)
        End If

        OrderID = CurrentPartsToBeCredited.OrderID
        SupplierID = CurrentPartsToBeCredited.SupplierID
        PartID = CurrentPartsToBeCredited.PartID
        Me.txtOrder.Text = CurrentPartsToBeCredited.OrderReference
        Me.txtQty.Text = CurrentPartsToBeCredited.Qty

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim keepFormOpenAsNew As Boolean = False
            CurrentPartsToBeCredited.IgnoreExceptionsOnSetMethods = True

            CurrentPartsToBeCredited.SetOrderID = OrderID
            CurrentPartsToBeCredited.SetSupplierID = SupplierID
            CurrentPartsToBeCredited.SetPartID = PartID
            CurrentPartsToBeCredited.SetQty = Me.txtQty.Text.Trim
            CurrentPartsToBeCredited.SetStatusID = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return)
            CurrentPartsToBeCredited.SetManuallyAdded = True
            CurrentPartsToBeCredited.SetOrderReference = txtOrder.Text

            Dim cV As New Entity.PartsToBeCrediteds.PartsToBeCreditedValidator
            cV.Validate(CurrentPartsToBeCredited)

            If CurrentPartsToBeCredited.Exists Then
                DB.PartsToBeCredited.Update(CurrentPartsToBeCredited)
            Else
                CurrentPartsToBeCredited = DB.PartsToBeCredited.Insert(CurrentPartsToBeCredited)
                keepFormOpenAsNew = True
            End If

            If keepFormOpenAsNew Then
                CurrentPartsToBeCredited = New Entity.PartsToBeCrediteds.PartsToBeCredited
                PartID = 0
                txtQty.Text = ""
                RaiseEvent StateChanged(0)
            Else
                RaiseEvent StateChanged(CurrentPartsToBeCredited.PartsToBeCreditedID)
            End If

            ShowMessage("Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

