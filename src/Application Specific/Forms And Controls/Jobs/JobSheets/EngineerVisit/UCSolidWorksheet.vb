Imports FSM.Entity.EngineerVisitAssetWorkSheets
Imports FSM.Entity.EngineerVisits
Imports FSM.Entity.Sys

Public Class UCSolidWorksheet : Inherits FSM.UCBase : Implements IUserControl

    Public Sub New(ByVal worksheet As Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet, ByVal jobID As Integer, ByVal EngineerVisit As Entity.EngineerVisits.EngineerVisit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        DtYesNo = DB.Picklists.GetAll(Enums.PickListTypes.YesNo).Table
        DtPassFail = DB.Picklists.GetAll(Enums.PickListTypes.PassFail).Table
        DtPassFailNA = DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA).Table

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

    Friend WithEvents txtFlueDraught As TextBox
    Friend WithEvents txtNominalOutput As TextBox
    Friend WithEvents txtVentilationType As TextBox
    Friend WithEvents cboSafety As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cboExtractorFans As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboSweptBrush As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboFlueClear As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboFireGuardFixingPoint As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboCorrectHearthSize As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboChimneySwept As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboChimneyStructureSound As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboVisualCondition As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboTerminationSatisfactory As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboAppliance As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblNotTested1 As Label
    Friend WithEvents lblNotTested2 As Label
    Friend WithEvents lblNotTested3 As Label
    Friend WithEvents lblNotTested6 As Label
    Friend WithEvents lblNotTested5 As Label
    Friend WithEvents lblNotTested4 As Label
    Friend WithEvents lblNotTested12 As Label
    Friend WithEvents lblNotTested11 As Label
    Friend WithEvents lblNotTested10 As Label
    Friend WithEvents lblNotTested9 As Label
    Friend WithEvents lblNotTested8 As Label
    Friend WithEvents lblNotTested7 As Label
    Friend WithEvents lblNotTested18 As Label
    Friend WithEvents lblNotTested17 As Label
    Friend WithEvents lblNotTested16 As Label
    Friend WithEvents lblNotTested15 As Label
    Friend WithEvents lblNotTested14 As Label
    Friend WithEvents lblNotTested13 As Label
    Friend WithEvents cboCombustionAir As ComboBox
    Friend WithEvents cboFluePerformance As ComboBox
    Friend WithEvents cboSafetyDevice As ComboBox
    Friend WithEvents cboApplianceServiced As ComboBox
    Friend WithEvents cboTennantKnow As ComboBox
    Friend WithEvents cboInstuctions As ComboBox
    Friend WithEvents cboTypeOfCylinder As ComboBox
    Friend WithEvents cboImmersionHeater As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents cboSmokeDrawTest As ComboBox
    Friend WithEvents cboUsingApprovedFuel As ComboBox
    Friend WithEvents cboVentilationAirProvision As ComboBox
    Friend WithEvents cboSmokePressureTest As ComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtFlueDraught = New System.Windows.Forms.TextBox()
        Me.txtNominalOutput = New System.Windows.Forms.TextBox()
        Me.txtVentilationType = New System.Windows.Forms.TextBox()
        Me.cboSafety = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboExtractorFans = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSweptBrush = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboFlueClear = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboFireGuardFixingPoint = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboCorrectHearthSize = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboChimneySwept = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboChimneyStructureSound = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboVisualCondition = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTerminationSatisfactory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAppliance = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblNotTested1 = New System.Windows.Forms.Label()
        Me.lblNotTested2 = New System.Windows.Forms.Label()
        Me.lblNotTested3 = New System.Windows.Forms.Label()
        Me.lblNotTested6 = New System.Windows.Forms.Label()
        Me.lblNotTested5 = New System.Windows.Forms.Label()
        Me.lblNotTested4 = New System.Windows.Forms.Label()
        Me.lblNotTested12 = New System.Windows.Forms.Label()
        Me.lblNotTested11 = New System.Windows.Forms.Label()
        Me.lblNotTested10 = New System.Windows.Forms.Label()
        Me.lblNotTested9 = New System.Windows.Forms.Label()
        Me.lblNotTested8 = New System.Windows.Forms.Label()
        Me.lblNotTested7 = New System.Windows.Forms.Label()
        Me.lblNotTested18 = New System.Windows.Forms.Label()
        Me.lblNotTested17 = New System.Windows.Forms.Label()
        Me.lblNotTested16 = New System.Windows.Forms.Label()
        Me.lblNotTested15 = New System.Windows.Forms.Label()
        Me.lblNotTested14 = New System.Windows.Forms.Label()
        Me.lblNotTested13 = New System.Windows.Forms.Label()
        Me.cboCombustionAir = New System.Windows.Forms.ComboBox()
        Me.cboFluePerformance = New System.Windows.Forms.ComboBox()
        Me.cboSafetyDevice = New System.Windows.Forms.ComboBox()
        Me.cboApplianceServiced = New System.Windows.Forms.ComboBox()
        Me.cboTennantKnow = New System.Windows.Forms.ComboBox()
        Me.cboInstuctions = New System.Windows.Forms.ComboBox()
        Me.cboTypeOfCylinder = New System.Windows.Forms.ComboBox()
        Me.cboImmersionHeater = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboSmokeDrawTest = New System.Windows.Forms.ComboBox()
        Me.cboUsingApprovedFuel = New System.Windows.Forms.ComboBox()
        Me.cboVentilationAirProvision = New System.Windows.Forms.ComboBox()
        Me.cboSmokePressureTest = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtFlueDraught
        '
        Me.txtFlueDraught.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlueDraught.Location = New System.Drawing.Point(601, 276)
        Me.txtFlueDraught.Name = "txtFlueDraught"
        Me.txtFlueDraught.Size = New System.Drawing.Size(188, 21)
        Me.txtFlueDraught.TabIndex = 10
        '
        'txtNominalOutput
        '
        Me.txtNominalOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNominalOutput.Location = New System.Drawing.Point(601, 366)
        Me.txtNominalOutput.Name = "txtNominalOutput"
        Me.txtNominalOutput.Size = New System.Drawing.Size(188, 21)
        Me.txtNominalOutput.TabIndex = 11
        '
        'txtVentilationType
        '
        Me.txtVentilationType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVentilationType.Location = New System.Drawing.Point(601, 576)
        Me.txtVentilationType.Name = "txtVentilationType"
        Me.txtVentilationType.Size = New System.Drawing.Size(188, 21)
        Me.txtVentilationType.TabIndex = 18
        '
        'cboSafety
        '
        Me.cboSafety.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSafety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSafety.Location = New System.Drawing.Point(601, 636)
        Me.cboSafety.Name = "cboSafety"
        Me.cboSafety.Size = New System.Drawing.Size(188, 21)
        Me.cboSafety.TabIndex = 20
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 641)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(134, 13)
        Me.Label18.TabIndex = 365
        Me.Label18.Text = "Appliance Safe To Use"
        '
        'cboExtractorFans
        '
        Me.cboExtractorFans.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboExtractorFans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExtractorFans.Location = New System.Drawing.Point(601, 606)
        Me.cboExtractorFans.Name = "cboExtractorFans"
        Me.cboExtractorFans.Size = New System.Drawing.Size(188, 21)
        Me.cboExtractorFans.TabIndex = 19
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 611)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(129, 13)
        Me.Label19.TabIndex = 363
        Me.Label19.Text = "Extractor Fans In Use"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 581)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(97, 13)
        Me.Label20.TabIndex = 361
        Me.Label20.Text = "Ventilation Type"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 552)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(176, 13)
        Me.Label21.TabIndex = 360
        Me.Label21.Text = "Type Of Cylinder At Location?"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 522)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(181, 13)
        Me.Label22.TabIndex = 359
        Me.Label22.Text = "Operating Instruction Present?"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(30, 608)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 358
        Me.Label11.Text = "CO2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 461)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(164, 13)
        Me.Label12.TabIndex = 357
        Me.Label12.Text = "Immersion Heater Present?"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 431)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 13)
        Me.Label13.TabIndex = 356
        Me.Label13.Text = "Appliance Serviced"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 402)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(204, 13)
        Me.Label14.TabIndex = 355
        Me.Label14.Text = "Safety Device Operating Correctly"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 372)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 13)
        Me.Label15.TabIndex = 354
        Me.Label15.Text = "Nominal Output"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 342)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(212, 13)
        Me.Label16.TabIndex = 353
        Me.Label16.Text = "Flue Performance Tests Satisfactory"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 312)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(223, 13)
        Me.Label17.TabIndex = 352
        Me.Label17.Text = "Combustion Air Provision Satisfactory"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 13)
        Me.Label6.TabIndex = 351
        Me.Label6.Text = "Flue Draught Reading"
        '
        'cboSweptBrush
        '
        Me.cboSweptBrush.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSweptBrush.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSweptBrush.Location = New System.Drawing.Point(601, 246)
        Me.cboSweptBrush.Name = "cboSweptBrush"
        Me.cboSweptBrush.Size = New System.Drawing.Size(188, 21)
        Me.cboSweptBrush.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(232, 13)
        Me.Label7.TabIndex = 350
        Me.Label7.Text = "Swept Brush Visible At Top Of Chimney"
        '
        'cboFlueClear
        '
        Me.cboFlueClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFlueClear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlueClear.Location = New System.Drawing.Point(601, 216)
        Me.cboFlueClear.Name = "cboFlueClear"
        Me.cboFlueClear.Size = New System.Drawing.Size(188, 21)
        Me.cboFlueClear.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 221)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 13)
        Me.Label8.TabIndex = 348
        Me.Label8.Text = "Flue Clear Of Obstuction"
        '
        'cboFireGuardFixingPoint
        '
        Me.cboFireGuardFixingPoint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFireGuardFixingPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFireGuardFixingPoint.Location = New System.Drawing.Point(601, 187)
        Me.cboFireGuardFixingPoint.Name = "cboFireGuardFixingPoint"
        Me.cboFireGuardFixingPoint.Size = New System.Drawing.Size(188, 21)
        Me.cboFireGuardFixingPoint.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 192)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 13)
        Me.Label9.TabIndex = 346
        Me.Label9.Text = "Fire Guard Fixing Point"
        '
        'cboCorrectHearthSize
        '
        Me.cboCorrectHearthSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCorrectHearthSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorrectHearthSize.Location = New System.Drawing.Point(601, 157)
        Me.cboCorrectHearthSize.Name = "cboCorrectHearthSize"
        Me.cboCorrectHearthSize.Size = New System.Drawing.Size(188, 21)
        Me.cboCorrectHearthSize.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 162)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 13)
        Me.Label10.TabIndex = 344
        Me.Label10.Text = "Correct Hearth Size"
        '
        'cboChimneySwept
        '
        Me.cboChimneySwept.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboChimneySwept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChimneySwept.Location = New System.Drawing.Point(601, 127)
        Me.cboChimneySwept.Name = "cboChimneySwept"
        Me.cboChimneySwept.Size = New System.Drawing.Size(188, 21)
        Me.cboChimneySwept.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 342
        Me.Label3.Text = "Chimney Swept"
        '
        'cboChimneyStructureSound
        '
        Me.cboChimneyStructureSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboChimneyStructureSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChimneyStructureSound.Location = New System.Drawing.Point(601, 97)
        Me.cboChimneyStructureSound.Name = "cboChimneyStructureSound"
        Me.cboChimneyStructureSound.Size = New System.Drawing.Size(188, 21)
        Me.cboChimneyStructureSound.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 13)
        Me.Label4.TabIndex = 340
        Me.Label4.Text = "Chimney Structure Sound"
        '
        'cboVisualCondition
        '
        Me.cboVisualCondition.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboVisualCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualCondition.Location = New System.Drawing.Point(601, 67)
        Me.cboVisualCondition.Name = "cboVisualCondition"
        Me.cboVisualCondition.Size = New System.Drawing.Size(188, 21)
        Me.cboVisualCondition.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 338
        Me.Label5.Text = "Visual Condition"
        '
        'cboTerminationSatisfactory
        '
        Me.cboTerminationSatisfactory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTerminationSatisfactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerminationSatisfactory.Location = New System.Drawing.Point(601, 38)
        Me.cboTerminationSatisfactory.Name = "cboTerminationSatisfactory"
        Me.cboTerminationSatisfactory.Size = New System.Drawing.Size(188, 21)
        Me.cboTerminationSatisfactory.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 13)
        Me.Label2.TabIndex = 336
        Me.Label2.Text = "Termination Satisfactory"
        '
        'cboAppliance
        '
        Me.cboAppliance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAppliance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAppliance.Location = New System.Drawing.Point(601, 8)
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
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 491)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(271, 13)
        Me.Label23.TabIndex = 378
        Me.Label23.Text = "Does the tenant know how to use the system?"
        '
        'lblNotTested1
        '
        Me.lblNotTested1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested1.AutoSize = True
        Me.lblNotTested1.Location = New System.Drawing.Point(661, 100)
        Me.lblNotTested1.Name = "lblNotTested1"
        Me.lblNotTested1.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested1.TabIndex = 379
        Me.lblNotTested1.Text = "Not Tested"
        '
        'lblNotTested2
        '
        Me.lblNotTested2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested2.AutoSize = True
        Me.lblNotTested2.Location = New System.Drawing.Point(661, 130)
        Me.lblNotTested2.Name = "lblNotTested2"
        Me.lblNotTested2.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested2.TabIndex = 380
        Me.lblNotTested2.Text = "Not Tested"
        '
        'lblNotTested3
        '
        Me.lblNotTested3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested3.AutoSize = True
        Me.lblNotTested3.Location = New System.Drawing.Point(661, 160)
        Me.lblNotTested3.Name = "lblNotTested3"
        Me.lblNotTested3.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested3.TabIndex = 381
        Me.lblNotTested3.Text = "Not Tested"
        '
        'lblNotTested6
        '
        Me.lblNotTested6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested6.AutoSize = True
        Me.lblNotTested6.Location = New System.Drawing.Point(661, 250)
        Me.lblNotTested6.Name = "lblNotTested6"
        Me.lblNotTested6.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested6.TabIndex = 384
        Me.lblNotTested6.Text = "Not Tested"
        '
        'lblNotTested5
        '
        Me.lblNotTested5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested5.AutoSize = True
        Me.lblNotTested5.Location = New System.Drawing.Point(661, 220)
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
        'lblNotTested12
        '
        Me.lblNotTested12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested12.AutoSize = True
        Me.lblNotTested12.Location = New System.Drawing.Point(661, 429)
        Me.lblNotTested12.Name = "lblNotTested12"
        Me.lblNotTested12.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested12.TabIndex = 390
        Me.lblNotTested12.Text = "Not Tested"
        '
        'lblNotTested11
        '
        Me.lblNotTested11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested11.AutoSize = True
        Me.lblNotTested11.Location = New System.Drawing.Point(661, 399)
        Me.lblNotTested11.Name = "lblNotTested11"
        Me.lblNotTested11.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested11.TabIndex = 389
        Me.lblNotTested11.Text = "Not Tested"
        '
        'lblNotTested10
        '
        Me.lblNotTested10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested10.AutoSize = True
        Me.lblNotTested10.Location = New System.Drawing.Point(661, 369)
        Me.lblNotTested10.Name = "lblNotTested10"
        Me.lblNotTested10.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested10.TabIndex = 388
        Me.lblNotTested10.Text = "Not Tested"
        '
        'lblNotTested9
        '
        Me.lblNotTested9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested9.AutoSize = True
        Me.lblNotTested9.Location = New System.Drawing.Point(661, 339)
        Me.lblNotTested9.Name = "lblNotTested9"
        Me.lblNotTested9.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested9.TabIndex = 387
        Me.lblNotTested9.Text = "Not Tested"
        '
        'lblNotTested8
        '
        Me.lblNotTested8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested8.AutoSize = True
        Me.lblNotTested8.Location = New System.Drawing.Point(661, 309)
        Me.lblNotTested8.Name = "lblNotTested8"
        Me.lblNotTested8.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested8.TabIndex = 386
        Me.lblNotTested8.Text = "Not Tested"
        '
        'lblNotTested7
        '
        Me.lblNotTested7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested7.AutoSize = True
        Me.lblNotTested7.Location = New System.Drawing.Point(661, 279)
        Me.lblNotTested7.Name = "lblNotTested7"
        Me.lblNotTested7.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested7.TabIndex = 385
        Me.lblNotTested7.Text = "Not Tested"
        '
        'lblNotTested18
        '
        Me.lblNotTested18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested18.AutoSize = True
        Me.lblNotTested18.Location = New System.Drawing.Point(661, 609)
        Me.lblNotTested18.Name = "lblNotTested18"
        Me.lblNotTested18.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested18.TabIndex = 396
        Me.lblNotTested18.Text = "Not Tested"
        '
        'lblNotTested17
        '
        Me.lblNotTested17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested17.AutoSize = True
        Me.lblNotTested17.Location = New System.Drawing.Point(661, 579)
        Me.lblNotTested17.Name = "lblNotTested17"
        Me.lblNotTested17.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested17.TabIndex = 395
        Me.lblNotTested17.Text = "Not Tested"
        '
        'lblNotTested16
        '
        Me.lblNotTested16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested16.AutoSize = True
        Me.lblNotTested16.Location = New System.Drawing.Point(661, 549)
        Me.lblNotTested16.Name = "lblNotTested16"
        Me.lblNotTested16.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested16.TabIndex = 394
        Me.lblNotTested16.Text = "Not Tested"
        '
        'lblNotTested15
        '
        Me.lblNotTested15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested15.AutoSize = True
        Me.lblNotTested15.Location = New System.Drawing.Point(661, 519)
        Me.lblNotTested15.Name = "lblNotTested15"
        Me.lblNotTested15.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested15.TabIndex = 393
        Me.lblNotTested15.Text = "Not Tested"
        '
        'lblNotTested14
        '
        Me.lblNotTested14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested14.AutoSize = True
        Me.lblNotTested14.Location = New System.Drawing.Point(661, 489)
        Me.lblNotTested14.Name = "lblNotTested14"
        Me.lblNotTested14.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested14.TabIndex = 392
        Me.lblNotTested14.Text = "Not Tested"
        '
        'lblNotTested13
        '
        Me.lblNotTested13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested13.AutoSize = True
        Me.lblNotTested13.Location = New System.Drawing.Point(661, 459)
        Me.lblNotTested13.Name = "lblNotTested13"
        Me.lblNotTested13.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested13.TabIndex = 391
        Me.lblNotTested13.Text = "Not Tested"
        '
        'cboCombustionAir
        '
        Me.cboCombustionAir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCombustionAir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCombustionAir.Location = New System.Drawing.Point(601, 306)
        Me.cboCombustionAir.Name = "cboCombustionAir"
        Me.cboCombustionAir.Size = New System.Drawing.Size(188, 21)
        Me.cboCombustionAir.TabIndex = 397
        '
        'cboFluePerformance
        '
        Me.cboFluePerformance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFluePerformance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFluePerformance.Location = New System.Drawing.Point(601, 336)
        Me.cboFluePerformance.Name = "cboFluePerformance"
        Me.cboFluePerformance.Size = New System.Drawing.Size(188, 21)
        Me.cboFluePerformance.TabIndex = 398
        '
        'cboSafetyDevice
        '
        Me.cboSafetyDevice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSafetyDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSafetyDevice.ItemHeight = 13
        Me.cboSafetyDevice.Location = New System.Drawing.Point(601, 397)
        Me.cboSafetyDevice.Name = "cboSafetyDevice"
        Me.cboSafetyDevice.Size = New System.Drawing.Size(188, 21)
        Me.cboSafetyDevice.TabIndex = 12
        '
        'cboApplianceServiced
        '
        Me.cboApplianceServiced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboApplianceServiced.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboApplianceServiced.Location = New System.Drawing.Point(601, 426)
        Me.cboApplianceServiced.Name = "cboApplianceServiced"
        Me.cboApplianceServiced.Size = New System.Drawing.Size(188, 21)
        Me.cboApplianceServiced.TabIndex = 13
        '
        'cboTennantKnow
        '
        Me.cboTennantKnow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTennantKnow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTennantKnow.Location = New System.Drawing.Point(601, 486)
        Me.cboTennantKnow.Name = "cboTennantKnow"
        Me.cboTennantKnow.Size = New System.Drawing.Size(188, 21)
        Me.cboTennantKnow.TabIndex = 15
        '
        'cboInstuctions
        '
        Me.cboInstuctions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboInstuctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInstuctions.Location = New System.Drawing.Point(601, 517)
        Me.cboInstuctions.Name = "cboInstuctions"
        Me.cboInstuctions.Size = New System.Drawing.Size(188, 21)
        Me.cboInstuctions.TabIndex = 16
        '
        'cboTypeOfCylinder
        '
        Me.cboTypeOfCylinder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTypeOfCylinder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeOfCylinder.Location = New System.Drawing.Point(601, 547)
        Me.cboTypeOfCylinder.Name = "cboTypeOfCylinder"
        Me.cboTypeOfCylinder.Size = New System.Drawing.Size(188, 21)
        Me.cboTypeOfCylinder.TabIndex = 17
        '
        'cboImmersionHeater
        '
        Me.cboImmersionHeater.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboImmersionHeater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImmersionHeater.Location = New System.Drawing.Point(601, 456)
        Me.cboImmersionHeater.Name = "cboImmersionHeater"
        Me.cboImmersionHeater.Size = New System.Drawing.Size(188, 21)
        Me.cboImmersionHeater.TabIndex = 14
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 760)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(130, 13)
        Me.Label24.TabIndex = 409
        Me.Label24.Text = "Using Approved Fuel?"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 730)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(214, 13)
        Me.Label25.TabIndex = 408
        Me.Label25.Text = "Ventilation Air Provision Satisfactory"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 700)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(128, 13)
        Me.Label26.TabIndex = 407
        Me.Label26.Text = "Smoke Pressure Test"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(3, 671)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(112, 13)
        Me.Label27.TabIndex = 406
        Me.Label27.Text = "Smoke Draw Test "
        '
        'cboSmokeDrawTest
        '
        Me.cboSmokeDrawTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSmokeDrawTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSmokeDrawTest.Location = New System.Drawing.Point(601, 666)
        Me.cboSmokeDrawTest.Name = "cboSmokeDrawTest"
        Me.cboSmokeDrawTest.Size = New System.Drawing.Size(188, 21)
        Me.cboSmokeDrawTest.TabIndex = 21
        '
        'cboUsingApprovedFuel
        '
        Me.cboUsingApprovedFuel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUsingApprovedFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsingApprovedFuel.Location = New System.Drawing.Point(601, 757)
        Me.cboUsingApprovedFuel.Name = "cboUsingApprovedFuel"
        Me.cboUsingApprovedFuel.Size = New System.Drawing.Size(188, 21)
        Me.cboUsingApprovedFuel.TabIndex = 24
        '
        'cboVentilationAirProvision
        '
        Me.cboVentilationAirProvision.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboVentilationAirProvision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVentilationAirProvision.Location = New System.Drawing.Point(601, 727)
        Me.cboVentilationAirProvision.Name = "cboVentilationAirProvision"
        Me.cboVentilationAirProvision.Size = New System.Drawing.Size(188, 21)
        Me.cboVentilationAirProvision.TabIndex = 23
        '
        'cboSmokePressureTest
        '
        Me.cboSmokePressureTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSmokePressureTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSmokePressureTest.Location = New System.Drawing.Point(601, 696)
        Me.cboSmokePressureTest.Name = "cboSmokePressureTest"
        Me.cboSmokePressureTest.Size = New System.Drawing.Size(188, 21)
        Me.cboSmokePressureTest.TabIndex = 22
        '
        'UCSolidWorksheet
        '
        Me.Controls.Add(Me.cboSmokeDrawTest)
        Me.Controls.Add(Me.cboUsingApprovedFuel)
        Me.Controls.Add(Me.cboVentilationAirProvision)
        Me.Controls.Add(Me.cboSmokePressureTest)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.cboImmersionHeater)
        Me.Controls.Add(Me.cboTypeOfCylinder)
        Me.Controls.Add(Me.cboInstuctions)
        Me.Controls.Add(Me.cboTennantKnow)
        Me.Controls.Add(Me.cboApplianceServiced)
        Me.Controls.Add(Me.cboSafetyDevice)
        Me.Controls.Add(Me.cboFluePerformance)
        Me.Controls.Add(Me.cboCombustionAir)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtFlueDraught)
        Me.Controls.Add(Me.txtNominalOutput)
        Me.Controls.Add(Me.txtVentilationType)
        Me.Controls.Add(Me.cboSafety)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboExtractorFans)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboSweptBrush)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboFlueClear)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboFireGuardFixingPoint)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboCorrectHearthSize)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboChimneySwept)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboChimneyStructureSound)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboVisualCondition)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboTerminationSatisfactory)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboAppliance)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNotTested18)
        Me.Controls.Add(Me.lblNotTested17)
        Me.Controls.Add(Me.lblNotTested16)
        Me.Controls.Add(Me.lblNotTested15)
        Me.Controls.Add(Me.lblNotTested14)
        Me.Controls.Add(Me.lblNotTested13)
        Me.Controls.Add(Me.lblNotTested12)
        Me.Controls.Add(Me.lblNotTested11)
        Me.Controls.Add(Me.lblNotTested10)
        Me.Controls.Add(Me.lblNotTested9)
        Me.Controls.Add(Me.lblNotTested8)
        Me.Controls.Add(Me.lblNotTested7)
        Me.Controls.Add(Me.lblNotTested6)
        Me.Controls.Add(Me.lblNotTested5)
        Me.Controls.Add(Me.lblNotTested4)
        Me.Controls.Add(Me.lblNotTested3)
        Me.Controls.Add(Me.lblNotTested2)
        Me.Controls.Add(Me.lblNotTested1)
        Me.Name = "UCSolidWorksheet"
        Me.Size = New System.Drawing.Size(789, 795)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Properties"

    Dim DtYesNo As DataTable = Nothing
    Dim DtPassFail As DataTable = Nothing
    Dim DtPassFailNA As DataTable = Nothing

    Private _Worksheet As EngineerVisitAssetWorkSheet

    Public Property Worksheet() As EngineerVisitAssetWorkSheet
        Get
            Return _Worksheet
        End Get
        Set(ByVal Value As EngineerVisitAssetWorkSheet)
            _Worksheet = Value
        End Set
    End Property

    Private _EngineerVisit As EngineerVisit

    Public Property EngineerVisit() As EngineerVisit
        Get
            Return _EngineerVisit
        End Get
        Set(ByVal Value As EngineerVisit)
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
        Combo.SetUpCombo(Me.cboAppliance, DB.JobAsset.JobAsset_Get_For_Job(JobID).Table, "AssetID", "AssetDescriptionWithLocation", Entity.Sys.Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboCorrectHearthSize, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFireGuardFixingPoint, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboChimneyStructureSound, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboChimneySwept, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFlueClear, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSweptBrush, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboTerminationSatisfactory, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboVisualCondition, DtPassFail, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboExtractorFans, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSmokeDrawTest, DtPassFail, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSmokePressureTest, DtPassFailNA, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboVentilationAirProvision, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboCombustionAir, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFluePerformance, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSafetyDevice, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboApplianceServiced, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSafety, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboTennantKnow, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboInstuctions, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboTypeOfCylinder, DynamicDataTables.TankType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboImmersionHeater, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboUsingApprovedFuel, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate

        Combo.SetSelectedComboItem_By_Value(Me.cboAppliance, Worksheet.AssetID)
        Combo.SetSelectedComboItem_By_Value(Me.cboTerminationSatisfactory, Worksheet.LandlordsApplianceID)
        Combo.SetSelectedComboItem_By_Value(Me.cboVisualCondition, Worksheet.ApplianceTestedID)
        Combo.SetSelectedComboItem_By_Value(Me.cboChimneySwept, Worksheet.SpillageTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboCorrectHearthSize, Worksheet.FlueTerminationSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboFireGuardFixingPoint, Worksheet.VisualConditionOfFlueSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboChimneyStructureSound, Worksheet.FlueFlowTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboFlueClear, Worksheet.VentilationProvisionSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSweptBrush, Worksheet.SafetyDeviceOperationID)
        Me.txtFlueDraught.Text = Worksheet.DHWFlowRate
        Combo.SetSelectedComboItem_By_Value(Me.cboCombustionAir, Worksheet.ColdWaterTemp)
        Combo.SetSelectedComboItem_By_Value(Me.cboFluePerformance, Worksheet.DHWTemp)
        Me.txtNominalOutput.Text = Worksheet.InletStaticPressure
        Combo.SetSelectedComboItem_By_Value(Me.cboSafetyDevice, Worksheet.InletWorkingPressure)
        Combo.SetSelectedComboItem_By_Value(Me.cboApplianceServiced, Worksheet.MinBurnerPressure)
        Combo.SetSelectedComboItem_By_Value(Me.cboImmersionHeater, Worksheet.Nozzle)
        Combo.SetSelectedComboItem_By_Value(Me.cboTennantKnow, Worksheet.CO2)
        Combo.SetSelectedComboItem_By_Value(Me.cboInstuctions, Worksheet.CO2CORatio)
        Combo.SetSelectedComboItem_By_Value(Me.cboTypeOfCylinder, Worksheet.BMake)
        Me.txtVentilationType.Text = Worksheet.BModel
        Combo.SetSelectedComboItem_By_Value(Me.cboExtractorFans, Worksheet.ApplianceServiceOrInspectedID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSafety, Worksheet.ApplianceSafeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSmokeDrawTest, Worksheet.DischargeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSmokePressureTest, Worksheet.SweepOutcomeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboVentilationAirProvision, Worksheet.OverallID)
        Combo.SetSelectedComboItem_By_Value(Me.cboUsingApprovedFuel, Worksheet.TankID)

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            Worksheet.SetReading = CInt(Enums.WorksheetFuelTypes.SolidFuel)
            Worksheet.SetAssetID = Combo.GetSelectedItemValue(Me.cboAppliance)
            Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID

            Worksheet.SetInletStaticPressure = Me.txtNominalOutput.Text
            Worksheet.SetFlueTerminationSatisfactoryID = Combo.GetSelectedItemValue(Me.cboCorrectHearthSize)
            Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.GetSelectedItemValue(Me.cboFireGuardFixingPoint)
            Worksheet.SetFlueFlowTestID = Combo.GetSelectedItemValue(Me.cboChimneyStructureSound)
            Worksheet.SetSpillageTestID = Combo.GetSelectedItemValue(Me.cboChimneySwept)
            Worksheet.SetVentilationProvisionSatisfactoryID = Combo.GetSelectedItemValue(Me.cboFlueClear)
            Worksheet.SetSafetyDeviceOperationID = Combo.GetSelectedItemValue(Me.cboSweptBrush)
            Worksheet.SetLandlordsApplianceID = Combo.GetSelectedItemValue(Me.cboTerminationSatisfactory)
            Worksheet.SetApplianceTestedID = Combo.GetSelectedItemValue(Me.cboVisualCondition)
            Worksheet.SetApplianceServiceOrInspectedID = Combo.GetSelectedItemValue(Me.cboExtractorFans)
            Worksheet.SetDischargeID = Combo.GetSelectedItemValue(Me.cboSmokeDrawTest)
            Worksheet.SetSweepOutcomeID = Combo.GetSelectedItemValue(Me.cboSmokePressureTest)
            Worksheet.SetDHWFlowRate = Me.txtFlueDraught.Text
            Worksheet.SetBModel = Me.txtVentilationType.Text
            Worksheet.SetOverallID = Combo.GetSelectedItemValue(Me.cboVentilationAirProvision)
            Worksheet.SetColdWaterTemp = Combo.GetSelectedItemValue(Me.cboCombustionAir)
            Worksheet.SetDHWTemp = Combo.GetSelectedItemValue(Me.cboFluePerformance)
            Worksheet.SetInletWorkingPressure = Combo.GetSelectedItemValue(Me.cboSafetyDevice)
            Worksheet.SetMinBurnerPressure = Combo.GetSelectedItemValue(Me.cboApplianceServiced)
            Worksheet.SetApplianceSafeID = Combo.GetSelectedItemValue(Me.cboSafety)
            Worksheet.SetCO2 = Combo.GetSelectedItemValue(Me.cboTennantKnow)
            Worksheet.SetCO2CORatio = Combo.GetSelectedItemValue(Me.cboInstuctions)
            Worksheet.SetBMake = Combo.GetSelectedItemValue(Me.cboTypeOfCylinder)
            Worksheet.SetNozzle = Combo.GetSelectedItemValue(Me.cboImmersionHeater)
            Worksheet.SetTankID = Combo.GetSelectedItemValue(Me.cboUsingApprovedFuel)

            Dim dValidator As New EngineerVisitAssetWorkSheetValidatorSolid
            dValidator.Validate(Worksheet)

            If Worksheet?.EngineerVisitAssetWorkSheetID > 0 Then
                DB.EngineerVisitAssetWorkSheet.Update(Worksheet)
            Else
                DB.EngineerVisitAssetWorkSheet.Insert(Worksheet)
            End If

            If Worksheet.LandlordsApplianceID = Enums.YesNoNA.No Then
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