Imports System.Collections.Generic
Imports FSM.Entity.Sys

Public Class DLGVisitAssetWorkSheet : Inherits FSM.FRMBaseForm



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
#Region " Windows Form Designer generated code "
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ddReading As ComboBox
    Friend WithEvents lblReading As Label
    Friend WithEvents pnlUCView As Panel
    Friend WithEvents Customer_Get_ForSiteIDTableAdapter1 As FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Customer_Get_ForSiteIDTableAdapter1 = New FSM.FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter()
        Me.ddReading = New System.Windows.Forms.ComboBox()
        Me.lblReading = New System.Windows.Forms.Label()
        Me.pnlUCView = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.Location = New System.Drawing.Point(193, 922)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 38
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.Location = New System.Drawing.Point(546, 922)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 39
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Customer_Get_ForSiteIDTableAdapter1
        '
        Me.Customer_Get_ForSiteIDTableAdapter1.ClearBeforeFill = True
        '
        'ddReading
        '
        Me.ddReading.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddReading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddReading.Location = New System.Drawing.Point(613, 47)
        Me.ddReading.Name = "ddReading"
        Me.ddReading.Size = New System.Drawing.Size(188, 21)
        Me.ddReading.TabIndex = 47
        '
        'lblReading
        '
        Me.lblReading.AutoSize = True
        Me.lblReading.Location = New System.Drawing.Point(16, 50)
        Me.lblReading.Name = "lblReading"
        Me.lblReading.Size = New System.Drawing.Size(30, 13)
        Me.lblReading.TabIndex = 48
        Me.lblReading.Text = "Fuel"
        '
        'pnlUCView
        '
        Me.pnlUCView.AutoSize = True
        Me.pnlUCView.Location = New System.Drawing.Point(12, 77)
        Me.pnlUCView.Name = "pnlUCView"
        Me.pnlUCView.Size = New System.Drawing.Size(789, 100)
        Me.pnlUCView.TabIndex = 256
        '
        'DLGVisitAssetWorkSheet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(813, 957)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlUCView)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.ddReading)
        Me.Controls.Add(Me.lblReading)
        Me.Name = "DLGVisitAssetWorkSheet"
        Me.Text = "Appliance Work Sheet"
        Me.Controls.SetChildIndex(Me.lblReading, 0)
        Me.Controls.SetChildIndex(Me.ddReading, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.pnlUCView, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Properties"

    Dim StopChangeTestedDD As Boolean = False
    Dim ChildUserInterface As Object = Nothing

    Private _updating As Boolean = True

    Public Property Updating() As Boolean
        Get
            Return _updating
        End Get
        Set(ByVal Value As Boolean)
            _updating = Value
        End Set
    End Property

    Private _Worksheet As Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet

    Public Property Worksheet() As Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet
        Get
            Return _Worksheet
        End Get
        Set(ByVal Value As Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet)
            _Worksheet = Value
        End Set
    End Property

    Private _EngineerVisit As Entity.EngineerVisits.EngineerVisit

    Public Property EngineerVisit() As Entity.EngineerVisits.EngineerVisit
        Get
            Return _EngineerVisit
        End Get
        Set(ByVal Value As Entity.EngineerVisits.EngineerVisit)
            _EngineerVisit = Value
        End Set
    End Property

    Private _jobID As Integer

    Public Property JobID() As Integer
        Get
            Return _jobID
        End Get
        Set(ByVal Value As Integer)
            _jobID = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub DLGVisitAssetWorkSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ControlLoading = True

        Combo.SetUpCombo(Me.ddReading, DynamicDataTables.ReadingType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select_Negative)

        If loggedInUser.Admin = False Then
            btnSave.Enabled = False
            ddReading.Enabled = False
            pnlUCView.Enabled = False
        End If

        If Worksheet IsNot Nothing AndAlso Not Worksheet.EngineerVisitAssetWorkSheetID = 0 Then
            Combo.SetSelectedComboItem_By_Value(Me.ddReading, Worksheet.Reading)
        End If

        ShowForm()

        ControlLoading = False
    End Sub



    Public Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim saved As Boolean
        Select Case CInt(Combo.GetSelectedItemValue(Me.ddReading))
            Case Enums.WorksheetFuelTypes.Gas
                saved = CType(ChildUserInterface, UCGasWorksheet).Save()
            Case Enums.WorksheetFuelTypes.Oil
                saved = CType(ChildUserInterface, UCOilWorksheet).Save()
            Case Enums.WorksheetFuelTypes.Solar
                saved = CType(ChildUserInterface, UCSolarWorksheet).Save()
            Case Enums.WorksheetFuelTypes.Other
                saved = CType(ChildUserInterface, UCOtherWorksheet).Save()
            Case Enums.WorksheetFuelTypes.ASHP
                saved = CType(ChildUserInterface, UCASHPWorksheet).Save()
            Case Enums.WorksheetFuelTypes.GSHP
                saved = CType(ChildUserInterface, UCGSHPWorksheet).Save()
            Case Enums.WorksheetFuelTypes.SolidFuel
                saved = CType(ChildUserInterface, UCSolidWorksheet).Save()
            Case Enums.WorksheetFuelTypes.Unvented
                saved = CType(ChildUserInterface, UCUnventedWorksheet).Save()
            Case Enums.WorksheetFuelTypes.ComCat
                saved = CType(ChildUserInterface, UCComercialWorksheet).Save()
            Case Enums.WorksheetFuelTypes.HIU
                saved = CType(ChildUserInterface, UCHIUWorksheet).Save()
        End Select
        If saved Then
            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub cboApplianceTested_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowForm()
    End Sub

    Private Sub ddReading_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddReading.SelectedIndexChanged
        ShowForm()
    End Sub

#End Region

#Region "Functions"

    Private Sub ShowForm()
        Select Case CInt(Combo.GetSelectedItemValue(Me.ddReading))
            Case Enums.WorksheetFuelTypes.Gas
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCGasWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)

            Case Enums.WorksheetFuelTypes.Oil
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCOilWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)

            Case Enums.WorksheetFuelTypes.Solar
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCSolarWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)

            Case Enums.WorksheetFuelTypes.Other
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCOtherWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)

            Case Enums.WorksheetFuelTypes.ASHP
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCASHPWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)
            Case Enums.WorksheetFuelTypes.GSHP
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCGSHPWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)
            Case Enums.WorksheetFuelTypes.SolidFuel
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCSolidWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)
            Case Enums.WorksheetFuelTypes.Unvented
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCUnventedWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)
            Case Enums.WorksheetFuelTypes.ComCat
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCComercialWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)
            Case Enums.WorksheetFuelTypes.HIU
                pnlUCView.Controls.Clear()

                ChildUserInterface = New UCHIUWorksheet(_Worksheet, _jobID, _EngineerVisit)
                pnlUCView.Controls.Add(ChildUserInterface)
        End Select
        ControlLoading = False
    End Sub

#End Region

End Class