Imports FSM.Entity.EngineerVisitAssetWorkSheets
Imports FSM.Entity.Sys

Public Class UCHIUWorksheet : Inherits FSM.UCBase : Implements IUserControl

    Public Sub New(ByVal worksheet As Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet, ByVal jobID As Integer, ByVal EngineerVisit As Entity.EngineerVisits.EngineerVisit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        DtPassFailNa = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFailNA).Table
        DtNotTestedPassFail = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.NotTestedPassFailNA).Table
        DtApplianceServiced = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ApplianceServiced).Table
        DtYesNo = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table
        DtYesNoNa = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table
        DtPassFail = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFail).Table


        Me._Worksheet = worksheet
        Me._jobID = jobID
        Me._EngineerVisit = EngineerVisit

        SetUpCombos()
        Populate()

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
#Region " Windows Form Designer generated code "
    Friend WithEvents txtResults As TextBox
    Friend WithEvents cboSafety As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cboServiced As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cboSystemOperation As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboInspectPumps As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboCleanStrainers As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboCleanPortValue As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboLeaksPressure As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboLLAppliance As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboAppliance As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNotTested1 As Label
    Friend WithEvents lblNotTested2 As Label
    Friend WithEvents lblNotTested3 As Label
    Friend WithEvents lblNotTested5 As Label
    Friend WithEvents lblNotTested4 As Label
    Friend WithEvents lblNotTested10 As Label
    Friend WithEvents lblNotTested18 As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.cboSafety = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboServiced = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboSystemOperation = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboInspectPumps = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboCleanStrainers = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboCleanPortValue = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboLeaksPressure = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboLLAppliance = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAppliance = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNotTested1 = New System.Windows.Forms.Label()
        Me.lblNotTested2 = New System.Windows.Forms.Label()
        Me.lblNotTested3 = New System.Windows.Forms.Label()
        Me.lblNotTested5 = New System.Windows.Forms.Label()
        Me.lblNotTested4 = New System.Windows.Forms.Label()
        Me.lblNotTested10 = New System.Windows.Forms.Label()
        Me.lblNotTested18 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtResults
        '
        Me.txtResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResults.Location = New System.Drawing.Point(601, 259)
        Me.txtResults.Name = "txtResults"
        Me.txtResults.Size = New System.Drawing.Size(188, 21)
        Me.txtResults.TabIndex = 13
        '
        'cboSafety
        '
        Me.cboSafety.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSafety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSafety.Location = New System.Drawing.Point(601, 330)
        Me.cboSafety.Name = "cboSafety"
        Me.cboSafety.Size = New System.Drawing.Size(188, 21)
        Me.cboSafety.TabIndex = 22
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 333)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 13)
        Me.Label18.TabIndex = 365
        Me.Label18.Text = "Appliance safety"
        '
        'cboServiced
        '
        Me.cboServiced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboServiced.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiced.Location = New System.Drawing.Point(601, 294)
        Me.cboServiced.Name = "cboServiced"
        Me.cboServiced.Size = New System.Drawing.Size(188, 21)
        Me.cboServiced.TabIndex = 21
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 297)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(181, 13)
        Me.Label19.TabIndex = 363
        Me.Label19.Text = "Appliance service or inspected"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 263)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 13)
        Me.Label15.TabIndex = 354
        Me.Label15.Text = "Recorded results"
        '
        'cboSystemOperation
        '
        Me.cboSystemOperation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSystemOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSystemOperation.Location = New System.Drawing.Point(601, 222)
        Me.cboSystemOperation.Name = "cboSystemOperation"
        Me.cboSystemOperation.Size = New System.Drawing.Size(188, 21)
        Me.cboSystemOperation.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(376, 13)
        Me.Label8.TabIndex = 348
        Me.Label8.Text = "Check the system operation parameters and record your results"
        '
        'cboInspectPumps
        '
        Me.cboInspectPumps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboInspectPumps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInspectPumps.Location = New System.Drawing.Point(601, 187)
        Me.cboInspectPumps.Name = "cboInspectPumps"
        Me.cboInspectPumps.Size = New System.Drawing.Size(188, 21)
        Me.cboInspectPumps.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 190)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(223, 13)
        Me.Label9.TabIndex = 346
        Me.Label9.Text = "Inspect the functionality of the pumps"
        '
        'cboCleanStrainers
        '
        Me.cboCleanStrainers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCleanStrainers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCleanStrainers.Location = New System.Drawing.Point(601, 152)
        Me.cboCleanStrainers.Name = "cboCleanStrainers"
        Me.cboCleanStrainers.Size = New System.Drawing.Size(188, 21)
        Me.cboCleanStrainers.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(178, 13)
        Me.Label10.TabIndex = 344
        Me.Label10.Text = "Check and clean the strainers"
        '
        'cboCleanPortValue
        '
        Me.cboCleanPortValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCleanPortValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCleanPortValue.Location = New System.Drawing.Point(601, 117)
        Me.cboCleanPortValue.Name = "cboCleanPortValue"
        Me.cboCleanPortValue.Size = New System.Drawing.Size(188, 21)
        Me.cboCleanPortValue.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 13)
        Me.Label3.TabIndex = 342
        Me.Label3.Text = "Check and clean the port valves"
        '
        'cboLeaksPressure
        '
        Me.cboLeaksPressure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLeaksPressure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeaksPressure.Location = New System.Drawing.Point(601, 82)
        Me.cboLeaksPressure.Name = "cboLeaksPressure"
        Me.cboLeaksPressure.Size = New System.Drawing.Size(188, 21)
        Me.cboLeaksPressure.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(492, 30)
        Me.Label4.TabIndex = 340
        Me.Label4.Text = "Check for leaks and pressure drops in both the primary and secondary sides of the" &
    " heading exchanger"
        '
        'cboLLAppliance
        '
        Me.cboLLAppliance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLLAppliance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLLAppliance.Location = New System.Drawing.Point(601, 45)
        Me.cboLLAppliance.Name = "cboLLAppliance"
        Me.cboLLAppliance.Size = New System.Drawing.Size(188, 21)
        Me.cboLLAppliance.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 13)
        Me.Label2.TabIndex = 336
        Me.Label2.Text = "Landlords Appliance "
        '
        'cboAppliance
        '
        Me.cboAppliance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAppliance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAppliance.Location = New System.Drawing.Point(601, 10)
        Me.cboAppliance.Name = "cboAppliance"
        Me.cboAppliance.Size = New System.Drawing.Size(188, 21)
        Me.cboAppliance.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 334
        Me.Label1.Text = "Appliance"
        '
        'lblNotTested1
        '
        Me.lblNotTested1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested1.AutoSize = True
        Me.lblNotTested1.Location = New System.Drawing.Point(661, 85)
        Me.lblNotTested1.Name = "lblNotTested1"
        Me.lblNotTested1.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested1.TabIndex = 379
        Me.lblNotTested1.Text = "Not Tested"
        '
        'lblNotTested2
        '
        Me.lblNotTested2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested2.AutoSize = True
        Me.lblNotTested2.Location = New System.Drawing.Point(661, 120)
        Me.lblNotTested2.Name = "lblNotTested2"
        Me.lblNotTested2.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested2.TabIndex = 380
        Me.lblNotTested2.Text = "Not Tested"
        '
        'lblNotTested3
        '
        Me.lblNotTested3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested3.AutoSize = True
        Me.lblNotTested3.Location = New System.Drawing.Point(661, 155)
        Me.lblNotTested3.Name = "lblNotTested3"
        Me.lblNotTested3.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested3.TabIndex = 381
        Me.lblNotTested3.Text = "Not Tested"
        '
        'lblNotTested5
        '
        Me.lblNotTested5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested5.AutoSize = True
        Me.lblNotTested5.Location = New System.Drawing.Point(661, 226)
        Me.lblNotTested5.Name = "lblNotTested5"
        Me.lblNotTested5.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested5.TabIndex = 383
        Me.lblNotTested5.Text = "Not Tested"
        '
        'lblNotTested4
        '
        Me.lblNotTested4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested4.AutoSize = True
        Me.lblNotTested4.Location = New System.Drawing.Point(661, 190)
        Me.lblNotTested4.Name = "lblNotTested4"
        Me.lblNotTested4.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested4.TabIndex = 382
        Me.lblNotTested4.Text = "Not Tested"
        '
        'lblNotTested10
        '
        Me.lblNotTested10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested10.AutoSize = True
        Me.lblNotTested10.Location = New System.Drawing.Point(661, 262)
        Me.lblNotTested10.Name = "lblNotTested10"
        Me.lblNotTested10.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested10.TabIndex = 388
        Me.lblNotTested10.Text = "Not Tested"
        '
        'lblNotTested18
        '
        Me.lblNotTested18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested18.AutoSize = True
        Me.lblNotTested18.Location = New System.Drawing.Point(661, 297)
        Me.lblNotTested18.Name = "lblNotTested18"
        Me.lblNotTested18.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested18.TabIndex = 396
        Me.lblNotTested18.Text = "Not Tested"
        '
        'UCHIUWorksheet
        '
        Me.Controls.Add(Me.txtResults)
        Me.Controls.Add(Me.cboSafety)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboServiced)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboSystemOperation)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboInspectPumps)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboCleanStrainers)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboCleanPortValue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboLeaksPressure)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboLLAppliance)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboAppliance)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNotTested18)
        Me.Controls.Add(Me.lblNotTested10)
        Me.Controls.Add(Me.lblNotTested5)
        Me.Controls.Add(Me.lblNotTested4)
        Me.Controls.Add(Me.lblNotTested3)
        Me.Controls.Add(Me.lblNotTested2)
        Me.Controls.Add(Me.lblNotTested1)
        Me.Name = "UCHIUWorksheet"
        Me.Size = New System.Drawing.Size(789, 382)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Properties"

    Dim DtPassFailNa As DataTable = Nothing
    Dim DtNotTestedPassFail As DataTable = Nothing
    Dim DtApplianceServiced As DataTable = Nothing
    Dim DtYesNo As DataTable = Nothing
    Dim DtYesNoNa As DataTable = Nothing
    Dim DtPassFail As DataTable = Nothing


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
    Public Event RecordsChanged(dv As DataView, pageIn As Enums.PageViewing, FromASave As Boolean, FromADelete As Boolean, extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(newID As Integer) Implements IUserControl.StateChanged

    Public Property JobID() As Integer
        Get
            Return _jobID
        End Get
        Set(ByVal Value As Integer)
            _jobID = Value
        End Set
    End Property

    Public ReadOnly Property LoadedItem As Object Implements IUserControl.LoadedItem
        Get
            Throw New NotImplementedException()
        End Get
    End Property

#End Region


    Public Sub LoadForm(sender As Object, e As EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public Sub SetUpCombos()
        Combo.SetUpCombo(Me.cboLLAppliance, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.LLTenPriv).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAppliance, DB.JobAsset.JobAsset_Get_For_Job(JobID).Table, "AssetID", "AssetDescriptionWithLocation", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboLeaksPressure, DtNotTestedPassFail, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboCleanPortValue, DtNotTestedPassFail, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboCleanStrainers, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboInspectPumps, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSystemOperation, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboServiced, DtApplianceServiced, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSafety, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        cboSafety.Items.Add(New Combo("Visually Passed", "999999999"))
    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate
        Combo.SetSelectedComboItem_By_Value(Me.cboAppliance, Worksheet.AssetID)
        Combo.SetSelectedComboItem_By_Value(Me.cboLLAppliance, Worksheet.LandlordsApplianceID)
        Combo.SetSelectedComboItem_By_Value(Me.cboLeaksPressure, Worksheet.FlueFlowTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboCleanPortValue, Worksheet.SpillageTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboCleanStrainers, Worksheet.FlueTerminationSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboInspectPumps, Worksheet.VisualConditionOfFlueSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSystemOperation, Worksheet.VentilationProvisionSatisfactoryID)
        Me.txtResults.Text = Worksheet.Nozzle
        Combo.SetSelectedComboItem_By_Value(Me.cboServiced, Worksheet.ApplianceServiceOrInspectedID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSafety, Worksheet.ApplianceSafeID)

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            Worksheet.SetReading = CInt(Enums.WorksheetFuelTypes.HIU)

            Worksheet.SetAssetID = Combo.GetSelectedItemValue(Me.cboAppliance)
            Worksheet.SetLandlordsApplianceID = Combo.GetSelectedItemValue(Me.cboLLAppliance)

            Worksheet.SetFlueFlowTestID = Combo.GetSelectedItemValue(Me.cboLeaksPressure)
            Worksheet.SetSpillageTestID = Combo.GetSelectedItemValue(Me.cboCleanPortValue)
            Worksheet.SetFlueTerminationSatisfactoryID = Combo.GetSelectedItemValue(Me.cboCleanStrainers)
            Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.GetSelectedItemValue(Me.cboInspectPumps)
            Worksheet.SetVentilationProvisionSatisfactoryID = Combo.GetSelectedItemValue(Me.cboSystemOperation)

            Worksheet.SetNozzle = Me.txtResults.Text

            Worksheet.SetApplianceServiceOrInspectedID = Combo.GetSelectedItemValue(Me.cboServiced)

            Worksheet.SetApplianceSafeID = Combo.GetSelectedItemValue(Me.cboSafety)

            Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID

            Dim dValidator As New EngineerVisitAssetWorkSheetValidatorHIU
            dValidator.Validate(Worksheet)

            If Worksheet?.EngineerVisitAssetWorkSheetID > 0 Then
                DB.EngineerVisitAssetWorkSheet.Update(Worksheet)
            Else
                DB.EngineerVisitAssetWorkSheet.Insert(Worksheet)
            End If

            If Worksheet.LandlordsApplianceID = Entity.Sys.Enums.YesNoNA.No Then
                Dim oAsset As Entity.Assets.Asset = DB.Asset.Asset_Get(Worksheet.AssetID)
                oAsset.SetTenantsAppliance = True
                DB.Asset.Update(oAsset)
            Else
                Dim oAsset As Entity.Assets.Asset = DB.Asset.Asset_Get(Worksheet.AssetID)
                oAsset.SetTenantsAppliance = False
                DB.Asset.Update(oAsset)
            End If

            ShowMessage("Your worksheet has been saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True

        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Error saving details : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

End Class

