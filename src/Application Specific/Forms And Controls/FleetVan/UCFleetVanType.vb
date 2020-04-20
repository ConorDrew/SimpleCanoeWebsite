Imports System.Collections

Public Class UCFleetVanType : Inherits FSM.UCBase : Implements IUserControl

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
    Friend WithEvents txtDateIntervals As TextBox
    Friend WithEvents lblDateIntervals As Label
    Friend WithEvents txtModel As TextBox
    Friend WithEvents lblModel As Label
    Friend WithEvents txtMake As TextBox
    Friend WithEvents lblMake As Label
    Friend WithEvents txtMileageIntervals As TextBox
    Friend WithEvents lblMileageService As Label
    Friend WithEvents txtPayload As TextBox
    Friend WithEvents lblPayLoad As Label
    Friend WithEvents txtGrossVehicleWeight As TextBox
    Friend WithEvents lblGrossVehicleWeight As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpVan = New System.Windows.Forms.GroupBox()
        Me.txtDateIntervals = New System.Windows.Forms.TextBox()
        Me.lblDateIntervals = New System.Windows.Forms.Label()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.txtMake = New System.Windows.Forms.TextBox()
        Me.lblMake = New System.Windows.Forms.Label()
        Me.txtMileageIntervals = New System.Windows.Forms.TextBox()
        Me.lblMileageService = New System.Windows.Forms.Label()
        Me.txtPayload = New System.Windows.Forms.TextBox()
        Me.lblPayLoad = New System.Windows.Forms.Label()
        Me.txtGrossVehicleWeight = New System.Windows.Forms.TextBox()
        Me.lblGrossVehicleWeight = New System.Windows.Forms.Label()
        Me.grpVan.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpVan
        '
        Me.grpVan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVan.Controls.Add(Me.txtPayload)
        Me.grpVan.Controls.Add(Me.lblPayLoad)
        Me.grpVan.Controls.Add(Me.txtGrossVehicleWeight)
        Me.grpVan.Controls.Add(Me.lblGrossVehicleWeight)
        Me.grpVan.Controls.Add(Me.txtDateIntervals)
        Me.grpVan.Controls.Add(Me.lblDateIntervals)
        Me.grpVan.Controls.Add(Me.txtModel)
        Me.grpVan.Controls.Add(Me.lblModel)
        Me.grpVan.Controls.Add(Me.txtMake)
        Me.grpVan.Controls.Add(Me.lblMake)
        Me.grpVan.Controls.Add(Me.txtMileageIntervals)
        Me.grpVan.Controls.Add(Me.lblMileageService)
        Me.grpVan.Location = New System.Drawing.Point(12, 13)
        Me.grpVan.Name = "grpVan"
        Me.grpVan.Size = New System.Drawing.Size(554, 146)
        Me.grpVan.TabIndex = 3
        Me.grpVan.TabStop = False
        Me.grpVan.Text = "Details"
        '
        'txtDateIntervals
        '
        Me.txtDateIntervals.Location = New System.Drawing.Point(457, 68)
        Me.txtDateIntervals.MaxLength = 10
        Me.txtDateIntervals.Name = "txtDateIntervals"
        Me.txtDateIntervals.Size = New System.Drawing.Size(77, 21)
        Me.txtDateIntervals.TabIndex = 4
        '
        'lblDateIntervals
        '
        Me.lblDateIntervals.Location = New System.Drawing.Point(260, 68)
        Me.lblDateIntervals.Name = "lblDateIntervals"
        Me.lblDateIntervals.Size = New System.Drawing.Size(191, 20)
        Me.lblDateIntervals.TabIndex = 51
        Me.lblDateIntervals.Text = "Date Service Intervals (Months)"
        '
        'txtModel
        '
        Me.txtModel.Location = New System.Drawing.Point(76, 68)
        Me.txtModel.MaxLength = 20
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(167, 21)
        Me.txtModel.TabIndex = 2
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(12, 71)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(58, 20)
        Me.lblModel.TabIndex = 49
        Me.lblModel.Text = "Model"
        '
        'txtMake
        '
        Me.txtMake.Location = New System.Drawing.Point(76, 30)
        Me.txtMake.MaxLength = 20
        Me.txtMake.Name = "txtMake"
        Me.txtMake.Size = New System.Drawing.Size(167, 21)
        Me.txtMake.TabIndex = 1
        '
        'lblMake
        '
        Me.lblMake.Location = New System.Drawing.Point(12, 33)
        Me.lblMake.Name = "lblMake"
        Me.lblMake.Size = New System.Drawing.Size(58, 20)
        Me.lblMake.TabIndex = 47
        Me.lblMake.Text = "Make"
        '
        'txtMileageIntervals
        '
        Me.txtMileageIntervals.Location = New System.Drawing.Point(457, 30)
        Me.txtMileageIntervals.MaxLength = 10
        Me.txtMileageIntervals.Name = "txtMileageIntervals"
        Me.txtMileageIntervals.Size = New System.Drawing.Size(77, 21)
        Me.txtMileageIntervals.TabIndex = 3
        '
        'lblMileageService
        '
        Me.lblMileageService.Location = New System.Drawing.Point(260, 33)
        Me.lblMileageService.Name = "lblMileageService"
        Me.lblMileageService.Size = New System.Drawing.Size(160, 20)
        Me.lblMileageService.TabIndex = 45
        Me.lblMileageService.Text = "Mileage Service Intervals"
        '
        'txtPayload
        '
        Me.txtPayload.Location = New System.Drawing.Point(457, 106)
        Me.txtPayload.MaxLength = 10
        Me.txtPayload.Name = "txtPayload"
        Me.txtPayload.Size = New System.Drawing.Size(77, 21)
        Me.txtPayload.TabIndex = 53
        '
        'lblPayLoad
        '
        Me.lblPayLoad.Location = New System.Drawing.Point(387, 106)
        Me.lblPayLoad.Name = "lblPayLoad"
        Me.lblPayLoad.Size = New System.Drawing.Size(55, 20)
        Me.lblPayLoad.TabIndex = 55
        Me.lblPayLoad.Text = "Payload"
        '
        'txtGrossVehicleWeight
        '
        Me.txtGrossVehicleWeight.Location = New System.Drawing.Point(158, 106)
        Me.txtGrossVehicleWeight.MaxLength = 20
        Me.txtGrossVehicleWeight.Name = "txtGrossVehicleWeight"
        Me.txtGrossVehicleWeight.Size = New System.Drawing.Size(85, 21)
        Me.txtGrossVehicleWeight.TabIndex = 52
        '
        'lblGrossVehicleWeight
        '
        Me.lblGrossVehicleWeight.Location = New System.Drawing.Point(12, 109)
        Me.lblGrossVehicleWeight.Name = "lblGrossVehicleWeight"
        Me.lblGrossVehicleWeight.Size = New System.Drawing.Size(140, 20)
        Me.lblGrossVehicleWeight.TabIndex = 54
        Me.lblGrossVehicleWeight.Text = "Gross Vehicle Weight"
        '
        'UCFleetVanType
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.grpVan)
        Me.Name = "UCFleetVanType"
        Me.Size = New System.Drawing.Size(580, 171)
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
            Return CurrentVanType
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private oldDepartment As Integer = 0

    Private _currentVanType As Entity.FleetVans.FleetVanType

    Public Property CurrentVanType() As Entity.FleetVans.FleetVanType
        Get
            Return _currentVanType
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVanType)
            _currentVanType = Value

            If _currentVanType Is Nothing Then
                _currentVanType = New Entity.FleetVans.FleetVanType
                _currentVanType.Exists = False
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
            CurrentVanType = DB.FleetVanType.Get(ID)
        End If

        Me.txtMake.Text = CurrentVanType.Make
        Me.txtModel.Text = CurrentVanType.Model
        Me.txtMileageIntervals.Text = CurrentVanType.MileageServiceInterval
        Me.txtDateIntervals.Text = CurrentVanType.DateServiceInterval
        Me.txtGrossVehicleWeight.Text = CurrentVanType.GrossVehicleWeight
        Me.txtPayload.Text = CurrentVanType.Payload

        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentVanType.IgnoreExceptionsOnSetMethods = True

            CurrentVanType.SetMake = Me.txtMake.Text.Trim
            CurrentVanType.SetModel = Me.txtModel.Text.Trim
            CurrentVanType.SetMileageServiceInterval = Me.txtMileageIntervals.Text.Trim
            CurrentVanType.SetDateServiceInterval = Me.txtDateIntervals.Text.Trim
            CurrentVanType.SetGrossVehicleWeight = Math.Round(Entity.Sys.Helper.MakeDoubleValid(Me.txtGrossVehicleWeight.Text), 2)
            CurrentVanType.SetPayload = Math.Round(Entity.Sys.Helper.MakeDoubleValid(Me.txtPayload.Text), 2)

            Dim cV As New Entity.FleetVans.FleetVanTypeValidator
            cV.Validate(CurrentVanType)

            If CurrentVanType.Exists Then
                DB.FleetVanType.Update(CurrentVanType)
            Else
                CurrentVanType = DB.FleetVanType.Insert(CurrentVanType)
            End If

            MainForm.RefreshEntity(CurrentVanType.VanTypeID)

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