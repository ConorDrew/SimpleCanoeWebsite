Imports System.Collections

Public Class UCFleetEquipment : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
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

    Friend WithEvents grpVan As GroupBox
    Friend WithEvents lblName As Label
    Friend WithEvents txtCost As TextBox
    Friend WithEvents lblCost As Label
    Friend WithEvents txtDescription As RichTextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtName As TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpVan = New System.Windows.Forms.GroupBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.lblCost = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.RichTextBox()
        Me.grpVan.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpVan
        '
        Me.grpVan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVan.Controls.Add(Me.txtDescription)
        Me.grpVan.Controls.Add(Me.lblDescription)
        Me.grpVan.Controls.Add(Me.txtName)
        Me.grpVan.Controls.Add(Me.lblName)
        Me.grpVan.Controls.Add(Me.txtCost)
        Me.grpVan.Controls.Add(Me.lblCost)
        Me.grpVan.Location = New System.Drawing.Point(12, 13)
        Me.grpVan.Name = "grpVan"
        Me.grpVan.Size = New System.Drawing.Size(415, 151)
        Me.grpVan.TabIndex = 3
        Me.grpVan.TabStop = False
        Me.grpVan.Text = "Details"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(12, 33)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(58, 20)
        Me.lblName.TabIndex = 47
        Me.lblName.Text = "Name"
        '
        'txtCost
        '
        Me.txtCost.Location = New System.Drawing.Point(299, 30)
        Me.txtCost.MaxLength = 10
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(77, 21)
        Me.txtCost.TabIndex = 3
        '
        'lblCost
        '
        Me.lblCost.Location = New System.Drawing.Point(241, 33)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(73, 20)
        Me.lblCost.TabIndex = 45
        Me.lblCost.Text = "Cost"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(95, 30)
        Me.txtName.MaxLength = 20
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(131, 21)
        Me.txtName.TabIndex = 1
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(12, 69)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(84, 20)
        Me.lblDescription.TabIndex = 49
        Me.lblDescription.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(95, 69)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(281, 62)
        Me.txtDescription.TabIndex = 50
        Me.txtDescription.Text = ""
        '
        'UCFleetEquipment
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.grpVan)
        Me.Name = "UCFleetEquipment"
        Me.Size = New System.Drawing.Size(439, 179)
        Me.grpVan.ResumeLayout(False)
        Me.grpVan.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentEquipment
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentEquipment As Entity.FleetVans.FleetEquipment

    Public Property CurrentEquipment() As Entity.FleetVans.FleetEquipment
        Get
            Return _currentEquipment
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetEquipment)
            _currentEquipment = Value

            If _currentEquipment Is Nothing Then
                _currentEquipment = New Entity.FleetVans.FleetEquipment
                _currentEquipment.Exists = False
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCVan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

#End Region

#Region "Functions"

    'Public Sub PopulateQuantities(ByVal VanID As Integer)
    '    PartQuantitiesDataview = DB.Part.PartLocations_GetForVanHM(VanID)
    'End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentEquipment = DB.FleetEquipment.Get(ID)
        End If

        Me.txtName.Text = CurrentEquipment.Name
        Me.txtCost.Text = CurrentEquipment.Cost
        Me.txtDescription.Text = CurrentEquipment.Description

        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentEquipment.IgnoreExceptionsOnSetMethods = True

            CurrentEquipment.SetName = Me.txtName.Text.Trim
            CurrentEquipment.SetCost = Me.txtCost.Text.Trim
            CurrentEquipment.SetDescription = Me.txtDescription.Text.Trim

            Dim cV As New Entity.FleetVans.FleetEquipmentValidator
            cV.Validate(CurrentEquipment)

            If CurrentEquipment.Exists Then
                DB.FleetEquipment.Update(CurrentEquipment)
            Else
                CurrentEquipment = DB.FleetEquipment.Insert(CurrentEquipment)
            End If

            MainForm.RefreshEntity(CurrentEquipment.EquipmentID)

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