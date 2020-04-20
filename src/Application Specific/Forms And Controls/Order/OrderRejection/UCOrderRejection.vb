Public Class UCOrderRejection : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboPossibleReasons, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.QuoteRejectionReasons).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

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
    Friend WithEvents grpMain As System.Windows.Forms.GroupBox
    Friend WithEvents cboPossibleReasons As System.Windows.Forms.ComboBox
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpMain = New System.Windows.Forms.GroupBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.cboPossibleReasons = New System.Windows.Forms.ComboBox
        Me.grpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpMain
        '
        Me.grpMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMain.Controls.Add(Me.btnAdd)
        Me.grpMain.Controls.Add(Me.Label2)
        Me.grpMain.Controls.Add(Me.Label1)
        Me.grpMain.Controls.Add(Me.txtReason)
        Me.grpMain.Controls.Add(Me.cboPossibleReasons)
        Me.grpMain.Location = New System.Drawing.Point(8, 8)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(633, 314)
        Me.grpMain.TabIndex = 1
        Me.grpMain.TabStop = False
        Me.grpMain.Text = "Order Rejection Reason"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(568, 33)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(56, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        '
        'Label2
        '

        Me.Label2.Location = New System.Drawing.Point(16, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Possible Reasons:"
        '
        'Label1
        '

        Me.Label1.Location = New System.Drawing.Point(16, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Reason:"
        '
        'txtReason
        '
        Me.txtReason.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReason.Location = New System.Drawing.Point(128, 65)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReason.Size = New System.Drawing.Size(496, 239)
        Me.txtReason.TabIndex = 3
        Me.txtReason.Text = ""
        '
        'cboPossibleReasons
        '
        Me.cboPossibleReasons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPossibleReasons.Location = New System.Drawing.Point(128, 33)
        Me.cboPossibleReasons.Name = "cboPossibleReasons"
        Me.cboPossibleReasons.Size = New System.Drawing.Size(432, 21)
        Me.cboPossibleReasons.TabIndex = 1
        '
        'UCOrderRejection
        '
        Me.Controls.Add(Me.grpMain)
        Me.Name = "UCOrderRejection"
        Me.Size = New System.Drawing.Size(648, 336)
        Me.grpMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return txtReason.Text
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal ExtraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged
    Public Event ReasonChanged(ByVal reason As String)

#End Region

#Region "Events"

    Private Sub UCQuoteContractSite_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtReason.Text.Trim.Length > 0 Then
            txtReason.Text += " " & Combo.GetSelectedItemDescription(cboPossibleReasons)
        Else
            txtReason.Text += Combo.GetSelectedItemDescription(cboPossibleReasons)
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            If txtReason.Text.Trim.Length > 0 Then
                Return True
            Else
                ShowMessage("Please enter a reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region


End Class
