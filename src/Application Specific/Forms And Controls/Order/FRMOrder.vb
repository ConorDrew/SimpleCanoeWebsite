Public Class FRMOrder : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        TheLoadedControl = New UCOrder
        Me.pnlMain.Controls.Add(TheLoadedControl)
        AddHandler CType(TheLoadedControl, UCOrder).FormClose, AddressOf CloseTheForm
        AddHandler LoadedControl.StateChanged, AddressOf ResetMe
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
    Friend WithEvents btnSave As System.Windows.Forms.Button

    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(8, 612)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 25)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(75, 613)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 25)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Location = New System.Drawing.Point(0, 32)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(825, 570)
        Me.pnlMain.TabIndex = 1
        '
        'FRMOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(833, 650)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pnlMain)
        Me.MinimumSize = New System.Drawing.Size(841, 684)
        Me.Name = "FRMOrder"
        Me.Text = "Order : ID {0}"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        CType(LoadedControl, UCOrder).ucJobOrder.SetupVisitsDataGrid()
        CType(LoadedControl, UCOrder).SetupProductsDatagrid()
        CType(LoadedControl, UCOrder).SetupPartsDatagrid()
        CType(LoadedControl, UCOrder).SetupPriceRequestDatagrid()

        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        CType(LoadedControl, UCOrder).PassedID = GetParameter(1)
        CType(LoadedControl, UCOrder).CurrentOrder = DB.Order.Order_Get(ID)

        If Entity.Sys.Helper.MakeIntegerValid(GetParameter(2)) > 0 Then
            Combo.SetSelectedComboItem_By_Value(CType(LoadedControl, UCOrder).cboOrderTypeID, Entity.Sys.Helper.MakeIntegerValid(GetParameter(2)))
            CType(LoadedControl, UCOrder).cboOrderTypeID.Enabled = False

            If CType(LoadedControl, UCOrder).PassedID = 0 Then
                CType(LoadedControl, UCOrder).ucJobOrder.EngineerVisitsDataView = DB.EngineerVisits.EngineerVisits_Get(GetParameter(1))
                CType(LoadedControl, UCOrder).ucJobOrder.txtJobSearch.Enabled = False
                CType(LoadedControl, UCOrder).ucJobOrder.btnSearch.Enabled = False
                CType(LoadedControl, UCOrder).lblOrderStatus.Text = "PLEASE SAVE BASE ORDER DETAILS BEFORE ADDING ITEMS"
                CType(LoadedControl, UCOrder).lblOrderStatus.Visible = True
            Else
                Select Case CType(GetParameter(2), Entity.Sys.Enums.OrderType)
                    Case Entity.Sys.Enums.OrderType.Job
                        CType(LoadedControl, UCOrder).ucJobOrder.txtJobSearch.Enabled = False
                        CType(LoadedControl, UCOrder).ucJobOrder.btnSearch.Enabled = False
                        CType(LoadedControl, UCOrder).txtOrderReference.ReadOnly = True
                        CType(LoadedControl, UCOrder).dtpDatePlaced.Enabled = False
                        CType(LoadedControl, UCOrder).chkDeadlineNA.Checked = True
                        CType(LoadedControl, UCOrder).chkDeadlineNA.Enabled = False
                        CType(LoadedControl, UCOrder).lblOrderStatus.Text = ""
                        CType(LoadedControl, UCOrder).lblOrderStatus.Visible = False
                        CType(LoadedControl, UCOrder).ucJobOrder.Enabled = False

                        CType(LoadedControl, UCOrder).ucJobOrder.EngineerVisitsDataView = DB.EngineerVisits.EngineerVisits_Get(GetParameter(1))
                        CType(LoadedControl, UCOrder).txtOrderReference.Text = "VisitOrder-" & CType(LoadedControl, UCOrder).ucJobOrder.EngineerVisitsDataView.Table.Rows(0).Item("EngineerVisitID")

                        LoadedControl.Save()
                        CType(LoadedControl, UCOrder).CurrentOrder = DB.Order.Order_Get(ID)
                        CType(LoadedControl, UCOrder).tcOrderDetails.SelectedTab = CType(LoadedControl, UCOrder).tabParts

                    Case Entity.Sys.Enums.OrderType.Customer

                        Dim oQuoteOrder As Entity.QuoteOrders.QuoteOrder = CType(GetParameter(3), Entity.QuoteOrders.QuoteOrder)

                        CType(LoadedControl, UCOrder).txtOrderReference.Text = oQuoteOrder.CustomerRef
                        CType(LoadedControl, UCOrder).txtOrderReference.ReadOnly = True
                        CType(LoadedControl, UCOrder).dtpDatePlaced.Enabled = False
                        If oQuoteOrder.DeliveryDeadline = Nothing Then
                            CType(LoadedControl, UCOrder).chkDeadlineNA.Checked = True
                            CType(LoadedControl, UCOrder).dtpDeliveryDeadline.Enabled = False
                        Else
                            CType(LoadedControl, UCOrder).chkDeadlineNA.Checked = False
                            CType(LoadedControl, UCOrder).dtpDeliveryDeadline.Enabled = True
                            CType(LoadedControl, UCOrder).dtpDeliveryDeadline.Value = oQuoteOrder.DeliveryDeadline
                        End If

                        CType(LoadedControl, UCOrder).ucCustomerOrder.Customer = DB.Customer.Customer_Get(oQuoteOrder.CustomerID)
                        CType(LoadedControl, UCOrder).ucCustomerOrder.theProperty = DB.Sites.Get(oQuoteOrder.PropertyID)

                        CType(LoadedControl, UCOrder).lblOrderStatus.Text = ""
                        CType(LoadedControl, UCOrder).lblOrderStatus.Visible = False
                        CType(LoadedControl, UCOrder).ucJobOrder.Enabled = False
                        LoadedControl.Save()
                        CType(LoadedControl, UCOrder).CurrentOrder = DB.Order.Order_Get(ID)
                        CType(LoadedControl, UCOrder).tcOrderDetails.SelectedTab = CType(LoadedControl, UCOrder).tabParts

                End Select

            End If
        End If

        CType(LoadedControl, UCOrder).SetupItemsIncludedDatagrid()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Me.pnlMain.Controls(0)
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        ID = newID
    End Sub

#End Region

#Region "Properties"

    Private TheLoadedControl As IUserControl

    Private _ID As Integer = 0

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
            If ID = 0 Then
                PageState = Entity.Sys.Enums.FormState.Insert
                Me.Text = "Order : Adding New..."
                Me.btnSave.Enabled = True
            Else
                PageState = Entity.Sys.Enums.FormState.Update
                Me.Text = "Order : ID " & ID
                Me.btnSave.Enabled = True
            End If
        End Set
    End Property

    Private _pageState As Entity.Sys.Enums.FormState

    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub FRMOrder_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        CloseTheForm()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If LoadedControl.Save() Then
            CType(LoadedControl, UCOrder).CurrentOrder = DB.Order.Order_Get(ID)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub CloseTheForm()
        If CType(TheLoadedControl, UCOrder).OrderNumberUsed = False Then
            DB.Job.DeleteReservedOrderNumber(CType(TheLoadedControl, UCOrder).OrderNumber.JobNumber, CType(TheLoadedControl, UCOrder).OrderNumber.Prefix)
        End If
    End Sub

#End Region

End Class