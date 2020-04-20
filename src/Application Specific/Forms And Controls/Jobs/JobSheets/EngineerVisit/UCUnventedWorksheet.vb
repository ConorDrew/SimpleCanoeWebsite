Imports FSM.Entity.EngineerVisitAssetWorkSheets
Imports FSM.Entity.Sys

Public Class UCUnventedWorksheet : Inherits FSM.UCBase : Implements IUserControl

    Public Sub New(ByVal worksheet As Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet, ByVal jobID As Integer, ByVal EngineerVisit As Entity.EngineerVisits.EngineerVisit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        DtPassFailNa = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFailNA).Table
        DtNotTestedPassFail = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.NotTestedPassFailNA).Table
        DtApplianceServiced = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ApplianceServiced).Table
        DtYesNoNa = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table
        DtYesNo = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table
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
    Friend WithEvents cboServiceRecord As ComboBox
    Friend WithEvents cboWaterPressure As ComboBox
    Friend WithEvents cboScaledUp As ComboBox
    Friend WithEvents cboTundish As ComboBox
    Friend WithEvents cboExpansionGap As ComboBox
    Friend WithEvents cboSacrificialAnode As ComboBox
    Friend WithEvents cboFilterStrainerCheck As ComboBox
    Friend WithEvents cboPrechargePressure As ComboBox
    Friend WithEvents cboIntegrity As ComboBox
    Friend WithEvents cboPressureDownstream As ComboBox
    Friend WithEvents cboAppliance As ComboBox
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents cboExpansionReliefValve As ComboBox
    Friend WithEvents cboPressureReliefValve As ComboBox
    Friend WithEvents cboDischargePipes As ComboBox
    Friend WithEvents lblNotTested10 As Label
    Friend WithEvents lblNotTested9 As Label
    Friend WithEvents lblNotTested8 As Label
    Friend WithEvents lblNotTested7 As Label
    Friend WithEvents lblNotTested6 As Label
    Friend WithEvents lblNotTested5 As Label
    Friend WithEvents lblNotTested4 As Label
    Friend WithEvents lblNotTested3 As Label
    Friend WithEvents lblNotTested2 As Label
    Friend WithEvents lblNotTested1 As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cboServiceRecord = New System.Windows.Forms.ComboBox()
        Me.cboWaterPressure = New System.Windows.Forms.ComboBox()
        Me.cboScaledUp = New System.Windows.Forms.ComboBox()
        Me.cboTundish = New System.Windows.Forms.ComboBox()
        Me.cboExpansionGap = New System.Windows.Forms.ComboBox()
        Me.cboSacrificialAnode = New System.Windows.Forms.ComboBox()
        Me.cboFilterStrainerCheck = New System.Windows.Forms.ComboBox()
        Me.cboPrechargePressure = New System.Windows.Forms.ComboBox()
        Me.cboIntegrity = New System.Windows.Forms.ComboBox()
        Me.cboPressureDownstream = New System.Windows.Forms.ComboBox()
        Me.cboAppliance = New System.Windows.Forms.ComboBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.cboExpansionReliefValve = New System.Windows.Forms.ComboBox()
        Me.cboPressureReliefValve = New System.Windows.Forms.ComboBox()
        Me.cboDischargePipes = New System.Windows.Forms.ComboBox()
        Me.lblNotTested10 = New System.Windows.Forms.Label()
        Me.lblNotTested9 = New System.Windows.Forms.Label()
        Me.lblNotTested8 = New System.Windows.Forms.Label()
        Me.lblNotTested7 = New System.Windows.Forms.Label()
        Me.lblNotTested6 = New System.Windows.Forms.Label()
        Me.lblNotTested5 = New System.Windows.Forms.Label()
        Me.lblNotTested4 = New System.Windows.Forms.Label()
        Me.lblNotTested3 = New System.Windows.Forms.Label()
        Me.lblNotTested2 = New System.Windows.Forms.Label()
        Me.lblNotTested1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboServiceRecord
        '
        Me.cboServiceRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboServiceRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiceRecord.Location = New System.Drawing.Point(601, 463)
        Me.cboServiceRecord.Name = "cboServiceRecord"
        Me.cboServiceRecord.Size = New System.Drawing.Size(188, 21)
        Me.cboServiceRecord.TabIndex = 14
        '
        'cboWaterPressure
        '
        Me.cboWaterPressure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboWaterPressure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWaterPressure.Location = New System.Drawing.Point(601, 428)
        Me.cboWaterPressure.Name = "cboWaterPressure"
        Me.cboWaterPressure.Size = New System.Drawing.Size(188, 21)
        Me.cboWaterPressure.TabIndex = 13
        '
        'cboScaledUp
        '
        Me.cboScaledUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboScaledUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScaledUp.Location = New System.Drawing.Point(601, 287)
        Me.cboScaledUp.Name = "cboScaledUp"
        Me.cboScaledUp.Size = New System.Drawing.Size(188, 21)
        Me.cboScaledUp.TabIndex = 9
        '
        'cboTundish
        '
        Me.cboTundish.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTundish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTundish.Location = New System.Drawing.Point(601, 252)
        Me.cboTundish.Name = "cboTundish"
        Me.cboTundish.Size = New System.Drawing.Size(188, 21)
        Me.cboTundish.TabIndex = 8
        '
        'cboExpansionGap
        '
        Me.cboExpansionGap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboExpansionGap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExpansionGap.Location = New System.Drawing.Point(601, 218)
        Me.cboExpansionGap.Name = "cboExpansionGap"
        Me.cboExpansionGap.Size = New System.Drawing.Size(188, 21)
        Me.cboExpansionGap.TabIndex = 7
        '
        'cboSacrificialAnode
        '
        Me.cboSacrificialAnode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSacrificialAnode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSacrificialAnode.Location = New System.Drawing.Point(601, 183)
        Me.cboSacrificialAnode.Name = "cboSacrificialAnode"
        Me.cboSacrificialAnode.Size = New System.Drawing.Size(188, 21)
        Me.cboSacrificialAnode.TabIndex = 6
        '
        'cboFilterStrainerCheck
        '
        Me.cboFilterStrainerCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFilterStrainerCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterStrainerCheck.Location = New System.Drawing.Point(601, 148)
        Me.cboFilterStrainerCheck.Name = "cboFilterStrainerCheck"
        Me.cboFilterStrainerCheck.Size = New System.Drawing.Size(188, 21)
        Me.cboFilterStrainerCheck.TabIndex = 5
        '
        'cboPrechargePressure
        '
        Me.cboPrechargePressure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPrechargePressure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrechargePressure.Location = New System.Drawing.Point(601, 113)
        Me.cboPrechargePressure.Name = "cboPrechargePressure"
        Me.cboPrechargePressure.Size = New System.Drawing.Size(188, 21)
        Me.cboPrechargePressure.TabIndex = 4
        '
        'cboIntegrity
        '
        Me.cboIntegrity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboIntegrity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIntegrity.Location = New System.Drawing.Point(601, 79)
        Me.cboIntegrity.Name = "cboIntegrity"
        Me.cboIntegrity.Size = New System.Drawing.Size(188, 21)
        Me.cboIntegrity.TabIndex = 3
        '
        'cboPressureDownstream
        '
        Me.cboPressureDownstream.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPressureDownstream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPressureDownstream.Location = New System.Drawing.Point(601, 45)
        Me.cboPressureDownstream.Name = "cboPressureDownstream"
        Me.cboPressureDownstream.Size = New System.Drawing.Size(188, 21)
        Me.cboPressureDownstream.TabIndex = 2
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
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(3, 466)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(306, 13)
        Me.Label46.TabIndex = 348
        Me.Label46.Text = "Complete service record/Benchmark log if Available"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(3, 431)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(326, 13)
        Me.Label47.TabIndex = 347
        Me.Label47.Text = "Check water pressure and flow rates at terminal fittings"
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(3, 396)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(568, 30)
        Me.Label55.TabIndex = 346
        Me.Label55.Text = "Manually lift the lever to operate the expansion relief valve. Check that it open" &
    "s, water discharges satisfactorily then closes and reseals correctly. If there i" &
    "s any doubt, replace the valve"
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(3, 361)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(546, 30)
        Me.Label56.TabIndex = 345
        Me.Label56.Text = "Manually Lift the lever to operate the temperature and pressure relief valve. Che" &
    "ck that it opens, water discharges satisfactory then close and reseals correctly" &
    ". if there is any doubt replace valves"
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(3, 325)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(546, 31)
        Me.Label57.TabIndex = 344
        Me.Label57.Text = "Check discharge pipes D1 and D2 for blockages or obstructions. Check water discha" &
    "rges from termination point and the termination is correctly positioned"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(3, 290)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(226, 13)
        Me.Label58.TabIndex = 343
        Me.Label58.Text = "Ensure the connection is not scaled up"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(3, 255)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(408, 13)
        Me.Label59.TabIndex = 342
        Me.Label59.Text = "Check tundish is visible and no water passing from the safety controls"
        '
        'Label60
        '
        Me.Label60.Location = New System.Drawing.Point(3, 221)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(546, 29)
        Me.Label60.TabIndex = 341
        Me.Label60.Text = "If system has internal type expansion facility, re-set expansion gap whilst testi" &
    "ng the temperature/pressure relief valve"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(3, 186)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(400, 13)
        Me.Label61.TabIndex = 340
        Me.Label61.Text = "Visually inspect sacrificial anode if applicable and renew if necessary"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(3, 151)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(458, 13)
        Me.Label62.TabIndex = 339
        Me.Label62.Text = "Remove and Visibly inspect the filter/strainer and thoroughly clean as required"
        '
        'Label63
        '
        Me.Label63.Location = New System.Drawing.Point(3, 116)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(546, 30)
        Me.Label63.TabIndex = 338
        Me.Label63.Text = "Check pre-charge pressure in expansion vessel and top up as necessary or if water" &
    " is leaking from schrader valve, replace expansion vessel"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(3, 82)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(303, 13)
        Me.Label64.TabIndex = 337
        Me.Label64.Text = "Check integrity of cylinder for leaks or damage etc."
        '
        'Label65
        '
        Me.Label65.Location = New System.Drawing.Point(3, 48)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(546, 29)
        Me.Label65.TabIndex = 336
        Me.Label65.Text = "Check water pressure downstream of pressure reducing/limiting valve, adjust or re" &
    "palace the valve if pressure is too high"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(3, 13)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(62, 13)
        Me.Label66.TabIndex = 335
        Me.Label66.Text = "Appliance"
        '
        'cboExpansionReliefValve
        '
        Me.cboExpansionReliefValve.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboExpansionReliefValve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExpansionReliefValve.Location = New System.Drawing.Point(601, 391)
        Me.cboExpansionReliefValve.Name = "cboExpansionReliefValve"
        Me.cboExpansionReliefValve.Size = New System.Drawing.Size(188, 21)
        Me.cboExpansionReliefValve.TabIndex = 12
        '
        'cboPressureReliefValve
        '
        Me.cboPressureReliefValve.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPressureReliefValve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPressureReliefValve.Location = New System.Drawing.Point(601, 356)
        Me.cboPressureReliefValve.Name = "cboPressureReliefValve"
        Me.cboPressureReliefValve.Size = New System.Drawing.Size(188, 21)
        Me.cboPressureReliefValve.TabIndex = 11
        '
        'cboDischargePipes
        '
        Me.cboDischargePipes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDischargePipes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDischargePipes.Location = New System.Drawing.Point(601, 322)
        Me.cboDischargePipes.Name = "cboDischargePipes"
        Me.cboDischargePipes.Size = New System.Drawing.Size(188, 21)
        Me.cboDischargePipes.TabIndex = 10
        '
        'lblNotTested10
        '
        Me.lblNotTested10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested10.AutoSize = True
        Me.lblNotTested10.Location = New System.Drawing.Point(656, 430)
        Me.lblNotTested10.Name = "lblNotTested10"
        Me.lblNotTested10.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested10.TabIndex = 416
        Me.lblNotTested10.Text = "Not Tested"
        '
        'lblNotTested9
        '
        Me.lblNotTested9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested9.AutoSize = True
        Me.lblNotTested9.Location = New System.Drawing.Point(656, 395)
        Me.lblNotTested9.Name = "lblNotTested9"
        Me.lblNotTested9.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested9.TabIndex = 415
        Me.lblNotTested9.Text = "Not Tested"
        '
        'lblNotTested8
        '
        Me.lblNotTested8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested8.AutoSize = True
        Me.lblNotTested8.Location = New System.Drawing.Point(656, 360)
        Me.lblNotTested8.Name = "lblNotTested8"
        Me.lblNotTested8.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested8.TabIndex = 414
        Me.lblNotTested8.Text = "Not Tested"
        '
        'lblNotTested7
        '
        Me.lblNotTested7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested7.AutoSize = True
        Me.lblNotTested7.Location = New System.Drawing.Point(656, 325)
        Me.lblNotTested7.Name = "lblNotTested7"
        Me.lblNotTested7.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested7.TabIndex = 413
        Me.lblNotTested7.Text = "Not Tested"
        '
        'lblNotTested6
        '
        Me.lblNotTested6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested6.AutoSize = True
        Me.lblNotTested6.Location = New System.Drawing.Point(656, 291)
        Me.lblNotTested6.Name = "lblNotTested6"
        Me.lblNotTested6.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested6.TabIndex = 412
        Me.lblNotTested6.Text = "Not Tested"
        '
        'lblNotTested5
        '
        Me.lblNotTested5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested5.AutoSize = True
        Me.lblNotTested5.Location = New System.Drawing.Point(656, 256)
        Me.lblNotTested5.Name = "lblNotTested5"
        Me.lblNotTested5.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested5.TabIndex = 411
        Me.lblNotTested5.Text = "Not Tested"
        '
        'lblNotTested4
        '
        Me.lblNotTested4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested4.AutoSize = True
        Me.lblNotTested4.Location = New System.Drawing.Point(656, 221)
        Me.lblNotTested4.Name = "lblNotTested4"
        Me.lblNotTested4.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested4.TabIndex = 410
        Me.lblNotTested4.Text = "Not Tested"
        '
        'lblNotTested3
        '
        Me.lblNotTested3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested3.AutoSize = True
        Me.lblNotTested3.Location = New System.Drawing.Point(656, 186)
        Me.lblNotTested3.Name = "lblNotTested3"
        Me.lblNotTested3.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested3.TabIndex = 409
        Me.lblNotTested3.Text = "Not Tested"
        '
        'lblNotTested2
        '
        Me.lblNotTested2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested2.AutoSize = True
        Me.lblNotTested2.Location = New System.Drawing.Point(656, 151)
        Me.lblNotTested2.Name = "lblNotTested2"
        Me.lblNotTested2.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested2.TabIndex = 408
        Me.lblNotTested2.Text = "Not Tested"
        '
        'lblNotTested1
        '
        Me.lblNotTested1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested1.AutoSize = True
        Me.lblNotTested1.Location = New System.Drawing.Point(656, 116)
        Me.lblNotTested1.Name = "lblNotTested1"
        Me.lblNotTested1.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested1.TabIndex = 407
        Me.lblNotTested1.Text = "Not Tested"
        '
        'UCUnventedWorksheet
        '
        Me.Controls.Add(Me.cboExpansionReliefValve)
        Me.Controls.Add(Me.cboPressureReliefValve)
        Me.Controls.Add(Me.cboDischargePipes)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.cboServiceRecord)
        Me.Controls.Add(Me.cboWaterPressure)
        Me.Controls.Add(Me.cboScaledUp)
        Me.Controls.Add(Me.cboTundish)
        Me.Controls.Add(Me.cboExpansionGap)
        Me.Controls.Add(Me.cboSacrificialAnode)
        Me.Controls.Add(Me.cboFilterStrainerCheck)
        Me.Controls.Add(Me.cboPrechargePressure)
        Me.Controls.Add(Me.cboIntegrity)
        Me.Controls.Add(Me.cboPressureDownstream)
        Me.Controls.Add(Me.cboAppliance)
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
        Me.Name = "UCUnventedWorksheet"
        Me.Size = New System.Drawing.Size(789, 511)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Properties"

    Dim DtPassFailNa As DataTable = Nothing
    Dim DtNotTestedPassFail As DataTable = Nothing
    Dim DtApplianceServiced As DataTable = Nothing
    Dim DtYesNo As DataTable = Nothing
    Dim DtPassFail As DataTable = Nothing
    Dim DtYesNoNa As DataTable = Nothing

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
        Combo.SetUpCombo(Me.cboExpansionReliefValve, DynamicDataTables.TankType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAppliance, DB.JobAsset.JobAsset_Get_For_Job(JobID).Table, "AssetID", "AssetDescriptionWithLocation", Entity.Sys.Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboPressureDownstream, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboIntegrity, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPrechargePressure, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFilterStrainerCheck, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSacrificialAnode, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboExpansionGap, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboTundish, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboScaledUp, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboWaterPressure, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboServiceRecord, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        cboServiceRecord.Items.Add(New Combo("Visually Passed", "999999999"))


        Combo.SetUpCombo(Me.cboDischargePipes, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPressureReliefValve, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate
        Combo.SetSelectedComboItem_By_Value(Me.cboAppliance, Worksheet.AssetID)
        Combo.SetSelectedComboItem_By_Value(Me.cboPrechargePressure, Worksheet.SpillageTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboFilterStrainerCheck, Worksheet.FlueTerminationSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSacrificialAnode, Worksheet.VisualConditionOfFlueSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboExpansionGap, Worksheet.VentilationProvisionSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboTundish, Worksheet.SafetyDeviceOperationID)
        Combo.SetSelectedComboItem_By_Value(Me.cboScaledUp, Worksheet.SweepOutcomeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboWaterPressure, Worksheet.ApplianceServiceOrInspectedID)
        Combo.SetSelectedComboItem_By_Value(Me.cboServiceRecord, Worksheet.ApplianceSafeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboPressureDownstream, Worksheet.LandlordsApplianceID)
        Combo.SetSelectedComboItem_By_Value(Me.cboIntegrity, Worksheet.FlueFlowTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboExpansionReliefValve, Worksheet.TankID) ' setddtank
        Combo.SetSelectedComboItem_By_Value(Me.cboDischargePipes, Worksheet.OverallID)
        Combo.SetSelectedComboItem_By_Value(Me.cboPressureReliefValve, Worksheet.DischargeID)

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            Worksheet.SetReading = CInt(Enums.WorksheetFuelTypes.Unvented)

            Worksheet.SetAssetID = Combo.GetSelectedItemValue(Me.cboAppliance)
            Worksheet.SetLandlordsApplianceID = Combo.GetSelectedItemValue(Me.cboPressureDownstream)
            Worksheet.SetFlueFlowTestID = Combo.GetSelectedItemValue(Me.cboIntegrity)
            Worksheet.SetSpillageTestID = Combo.GetSelectedItemValue(Me.cboPrechargePressure)
            Worksheet.SetFlueTerminationSatisfactoryID = Combo.GetSelectedItemValue(Me.cboFilterStrainerCheck)
            Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.GetSelectedItemValue(Me.cboSacrificialAnode)
            Worksheet.SetVentilationProvisionSatisfactoryID = Combo.GetSelectedItemValue(Me.cboExpansionGap)
            Worksheet.SetSafetyDeviceOperationID = Combo.GetSelectedItemValue(Me.cboTundish)
            Worksheet.SetSweepOutcomeID = Combo.GetSelectedItemValue(Me.cboScaledUp)
            Worksheet.SetOverallID = Combo.GetSelectedItemValue(Me.cboDischargePipes)
            Worksheet.SetDischargeID = Combo.GetSelectedItemValue(Me.cboPressureReliefValve)
            Worksheet.SetTankID = Combo.GetSelectedItemValue(Me.cboExpansionReliefValve) 'setddtank


            Worksheet.SetApplianceServiceOrInspectedID = Combo.GetSelectedItemValue(Me.cboWaterPressure)

            Worksheet.SetApplianceSafeID = Combo.GetSelectedItemValue(Me.cboServiceRecord)

            Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID

            Dim dValidator As New EngineerVisitAssetWorkSheetValidatorUnvented
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

