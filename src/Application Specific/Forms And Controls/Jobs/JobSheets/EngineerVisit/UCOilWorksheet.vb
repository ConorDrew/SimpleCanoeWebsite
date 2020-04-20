Imports FSM.Entity.EngineerVisitAssetWorkSheets
Imports FSM.Entity.Sys

Public Class UCOilWorksheet : Inherits FSM.UCBase : Implements IUserControl

    Public Sub New(ByVal worksheet As Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet, ByVal jobID As Integer, ByVal EngineerVisit As Entity.EngineerVisits.EngineerVisit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        DtPassFailNa = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFailNA).Table
        DtNotTestedPassFail = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.NotTestedPassFailNA).Table
        DtApplianceServiced = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ApplianceServiced).Table
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

    Friend WithEvents txtSmokeNo As TextBox
    Friend WithEvents txtEFFNet As TextBox
    Friend WithEvents txtGasTemp As TextBox
    Friend WithEvents txtEFFGross As TextBox
    Friend WithEvents txtInletPressure As TextBox
    Friend WithEvents txtNozzleSize As TextBox
    Friend WithEvents txtCO2 As TextBox
    Friend WithEvents txtCO2Ration As TextBox
    Friend WithEvents txtCO2Min As TextBox
    Friend WithEvents txtCO2Max As TextBox
    Friend WithEvents cboSafety As ComboBox
    Friend WithEvents cboServiced As ComboBox
    Friend WithEvents cboDevice As ComboBox
    Friend WithEvents cboAirSupply As ComboBox
    Friend WithEvents cboOilPipework As ComboBox
    Friend WithEvents cboOilStorage As ComboBox
    Friend WithEvents cboBurner As ComboBox
    Friend WithEvents cboFlueFlow As ComboBox
    Friend WithEvents cboTested As ComboBox
    Friend WithEvents cboLLAppliance As ComboBox
    Friend WithEvents cboAppliance As ComboBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboTankType As ComboBox
    Friend WithEvents lblNotTested18 As Label
    Friend WithEvents lblNotTested17 As Label
    Friend WithEvents lblNotTested16 As Label
    Friend WithEvents lblNotTested15 As Label
    Friend WithEvents lblNotTested14 As Label
    Friend WithEvents lblNotTested13 As Label
    Friend WithEvents lblNotTested12 As Label
    Friend WithEvents lblNotTested11 As Label
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
        Me.txtSmokeNo = New System.Windows.Forms.TextBox()
        Me.txtEFFNet = New System.Windows.Forms.TextBox()
        Me.txtGasTemp = New System.Windows.Forms.TextBox()
        Me.txtEFFGross = New System.Windows.Forms.TextBox()
        Me.txtInletPressure = New System.Windows.Forms.TextBox()
        Me.txtNozzleSize = New System.Windows.Forms.TextBox()
        Me.txtCO2 = New System.Windows.Forms.TextBox()
        Me.txtCO2Ration = New System.Windows.Forms.TextBox()
        Me.txtCO2Min = New System.Windows.Forms.TextBox()
        Me.txtCO2Max = New System.Windows.Forms.TextBox()
        Me.cboSafety = New System.Windows.Forms.ComboBox()
        Me.cboServiced = New System.Windows.Forms.ComboBox()
        Me.cboDevice = New System.Windows.Forms.ComboBox()
        Me.cboAirSupply = New System.Windows.Forms.ComboBox()
        Me.cboOilPipework = New System.Windows.Forms.ComboBox()
        Me.cboOilStorage = New System.Windows.Forms.ComboBox()
        Me.cboBurner = New System.Windows.Forms.ComboBox()
        Me.cboFlueFlow = New System.Windows.Forms.ComboBox()
        Me.cboTested = New System.Windows.Forms.ComboBox()
        Me.cboLLAppliance = New System.Windows.Forms.ComboBox()
        Me.cboAppliance = New System.Windows.Forms.ComboBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTankType = New System.Windows.Forms.ComboBox()
        Me.lblNotTested18 = New System.Windows.Forms.Label()
        Me.lblNotTested17 = New System.Windows.Forms.Label()
        Me.lblNotTested16 = New System.Windows.Forms.Label()
        Me.lblNotTested15 = New System.Windows.Forms.Label()
        Me.lblNotTested14 = New System.Windows.Forms.Label()
        Me.lblNotTested13 = New System.Windows.Forms.Label()
        Me.lblNotTested12 = New System.Windows.Forms.Label()
        Me.lblNotTested11 = New System.Windows.Forms.Label()
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
        'txtSmokeNo
        '
        Me.txtSmokeNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSmokeNo.Location = New System.Drawing.Point(601, 278)
        Me.txtSmokeNo.Name = "txtSmokeNo"
        Me.txtSmokeNo.Size = New System.Drawing.Size(188, 21)
        Me.txtSmokeNo.TabIndex = 10
        '
        'txtEFFNet
        '
        Me.txtEFFNet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEFFNet.Location = New System.Drawing.Point(601, 309)
        Me.txtEFFNet.Name = "txtEFFNet"
        Me.txtEFFNet.Size = New System.Drawing.Size(188, 21)
        Me.txtEFFNet.TabIndex = 11
        '
        'txtGasTemp
        '
        Me.txtGasTemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGasTemp.Location = New System.Drawing.Point(601, 339)
        Me.txtGasTemp.Name = "txtGasTemp"
        Me.txtGasTemp.Size = New System.Drawing.Size(188, 21)
        Me.txtGasTemp.TabIndex = 12
        '
        'txtEFFGross
        '
        Me.txtEFFGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEFFGross.Location = New System.Drawing.Point(601, 368)
        Me.txtEFFGross.Name = "txtEFFGross"
        Me.txtEFFGross.Size = New System.Drawing.Size(188, 21)
        Me.txtEFFGross.TabIndex = 13
        '
        'txtInletPressure
        '
        Me.txtInletPressure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInletPressure.Location = New System.Drawing.Point(601, 399)
        Me.txtInletPressure.Name = "txtInletPressure"
        Me.txtInletPressure.Size = New System.Drawing.Size(188, 21)
        Me.txtInletPressure.TabIndex = 14
        '
        'txtNozzleSize
        '
        Me.txtNozzleSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNozzleSize.Location = New System.Drawing.Point(601, 429)
        Me.txtNozzleSize.Name = "txtNozzleSize"
        Me.txtNozzleSize.Size = New System.Drawing.Size(188, 21)
        Me.txtNozzleSize.TabIndex = 15
        '
        'txtCO2
        '
        Me.txtCO2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCO2.Location = New System.Drawing.Point(601, 488)
        Me.txtCO2.Name = "txtCO2"
        Me.txtCO2.Size = New System.Drawing.Size(188, 21)
        Me.txtCO2.TabIndex = 17
        '
        'txtCO2Ration
        '
        Me.txtCO2Ration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCO2Ration.Location = New System.Drawing.Point(601, 519)
        Me.txtCO2Ration.Name = "txtCO2Ration"
        Me.txtCO2Ration.Size = New System.Drawing.Size(188, 21)
        Me.txtCO2Ration.TabIndex = 18
        '
        'txtCO2Min
        '
        Me.txtCO2Min.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCO2Min.Location = New System.Drawing.Point(601, 549)
        Me.txtCO2Min.Name = "txtCO2Min"
        Me.txtCO2Min.Size = New System.Drawing.Size(188, 21)
        Me.txtCO2Min.TabIndex = 19
        '
        'txtCO2Max
        '
        Me.txtCO2Max.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCO2Max.Location = New System.Drawing.Point(601, 578)
        Me.txtCO2Max.Name = "txtCO2Max"
        Me.txtCO2Max.Size = New System.Drawing.Size(188, 21)
        Me.txtCO2Max.TabIndex = 20
        '
        'cboSafety
        '
        Me.cboSafety.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSafety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSafety.Location = New System.Drawing.Point(601, 638)
        Me.cboSafety.Name = "cboSafety"
        Me.cboSafety.Size = New System.Drawing.Size(188, 21)
        Me.cboSafety.TabIndex = 22
        '
        'cboServiced
        '
        Me.cboServiced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboServiced.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiced.Location = New System.Drawing.Point(601, 608)
        Me.cboServiced.Name = "cboServiced"
        Me.cboServiced.Size = New System.Drawing.Size(188, 21)
        Me.cboServiced.TabIndex = 21
        '
        'cboDevice
        '
        Me.cboDevice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDevice.Location = New System.Drawing.Point(601, 248)
        Me.cboDevice.Name = "cboDevice"
        Me.cboDevice.Size = New System.Drawing.Size(188, 21)
        Me.cboDevice.TabIndex = 9
        '
        'cboAirSupply
        '
        Me.cboAirSupply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAirSupply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAirSupply.Location = New System.Drawing.Point(601, 218)
        Me.cboAirSupply.Name = "cboAirSupply"
        Me.cboAirSupply.Size = New System.Drawing.Size(188, 21)
        Me.cboAirSupply.TabIndex = 8
        '
        'cboOilPipework
        '
        Me.cboOilPipework.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboOilPipework.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOilPipework.Location = New System.Drawing.Point(601, 189)
        Me.cboOilPipework.Name = "cboOilPipework"
        Me.cboOilPipework.Size = New System.Drawing.Size(188, 21)
        Me.cboOilPipework.TabIndex = 7
        '
        'cboOilStorage
        '
        Me.cboOilStorage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboOilStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOilStorage.Location = New System.Drawing.Point(601, 159)
        Me.cboOilStorage.Name = "cboOilStorage"
        Me.cboOilStorage.Size = New System.Drawing.Size(188, 21)
        Me.cboOilStorage.TabIndex = 6
        '
        'cboBurner
        '
        Me.cboBurner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboBurner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBurner.Location = New System.Drawing.Point(601, 129)
        Me.cboBurner.Name = "cboBurner"
        Me.cboBurner.Size = New System.Drawing.Size(188, 21)
        Me.cboBurner.TabIndex = 5
        '
        'cboFlueFlow
        '
        Me.cboFlueFlow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFlueFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlueFlow.Location = New System.Drawing.Point(601, 99)
        Me.cboFlueFlow.Name = "cboFlueFlow"
        Me.cboFlueFlow.Size = New System.Drawing.Size(188, 21)
        Me.cboFlueFlow.TabIndex = 4
        '
        'cboTested
        '
        Me.cboTested.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTested.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTested.Location = New System.Drawing.Point(601, 69)
        Me.cboTested.Name = "cboTested"
        Me.cboTested.Size = New System.Drawing.Size(188, 21)
        Me.cboTested.TabIndex = 3
        '
        'cboLLAppliance
        '
        Me.cboLLAppliance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLLAppliance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLLAppliance.Location = New System.Drawing.Point(601, 40)
        Me.cboLLAppliance.Name = "cboLLAppliance"
        Me.cboLLAppliance.Size = New System.Drawing.Size(188, 21)
        Me.cboLLAppliance.TabIndex = 2
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
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(3, 491)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(48, 13)
        Me.Label44.TabIndex = 443
        Me.Label44.Text = "CO2 %"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 641)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(101, 13)
        Me.Label24.TabIndex = 442
        Me.Label24.Text = "Appliance safety"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 611)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(181, 13)
        Me.Label25.TabIndex = 441
        Me.Label25.Text = "Appliance service or inspected"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 581)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(61, 13)
        Me.Label26.TabIndex = 440
        Me.Label26.Text = "CO2 max"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(3, 552)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(57, 13)
        Me.Label27.TabIndex = 439
        Me.Label27.Text = "CO2 min"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(3, 522)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(54, 13)
        Me.Label28.TabIndex = 438
        Me.Label28.Text = "CO ppm"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(3, 461)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(63, 13)
        Me.Label29.TabIndex = 437
        Me.Label29.Text = "Tank type"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 431)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(70, 13)
        Me.Label30.TabIndex = 436
        Me.Label30.Text = "Nozzle size"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 402)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(117, 13)
        Me.Label31.TabIndex = 435
        Me.Label31.Text = "Pump pressure PSI"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(3, 372)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(75, 13)
        Me.Label32.TabIndex = 434
        Me.Label32.Text = "Eff Gross %"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(3, 342)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(117, 13)
        Me.Label33.TabIndex = 433
        Me.Label33.Text = "Flue Gas temp cent"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(3, 312)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(65, 13)
        Me.Label34.TabIndex = 432
        Me.Label34.Text = "EFF Net %"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(3, 281)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(70, 13)
        Me.Label35.TabIndex = 431
        Me.Label35.Text = "Smoke No "
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(3, 251)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(143, 13)
        Me.Label36.TabIndex = 430
        Me.Label36.Text = "Safety device operation"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(3, 221)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(64, 13)
        Me.Label37.TabIndex = 429
        Me.Label37.Text = "Air supply"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(3, 192)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(119, 13)
        Me.Label38.TabIndex = 428
        Me.Label38.Text = "Oil supply pipework"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(3, 162)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 13)
        Me.Label39.TabIndex = 427
        Me.Label39.Text = "Oil storage"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(3, 132)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(116, 13)
        Me.Label40.TabIndex = 426
        Me.Label40.Text = "Burner satisfactory"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(3, 102)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(94, 13)
        Me.Label41.TabIndex = 425
        Me.Label41.Text = "Chimney / Flue"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(3, 72)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(101, 13)
        Me.Label42.TabIndex = 424
        Me.Label42.Text = "Appliance tested"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(3, 43)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(125, 13)
        Me.Label43.TabIndex = 423
        Me.Label43.Text = "Landlords Appliance "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "Appliance"
        '
        'cboTankType
        '
        Me.cboTankType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTankType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTankType.Location = New System.Drawing.Point(601, 458)
        Me.cboTankType.Name = "cboTankType"
        Me.cboTankType.Size = New System.Drawing.Size(188, 21)
        Me.cboTankType.TabIndex = 16
        '
        'lblNotTested18
        '
        Me.lblNotTested18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested18.AutoSize = True
        Me.lblNotTested18.Location = New System.Drawing.Point(662, 581)
        Me.lblNotTested18.Name = "lblNotTested18"
        Me.lblNotTested18.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested18.TabIndex = 462
        Me.lblNotTested18.Text = "Not Tested"
        '
        'lblNotTested17
        '
        Me.lblNotTested17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested17.AutoSize = True
        Me.lblNotTested17.Location = New System.Drawing.Point(662, 551)
        Me.lblNotTested17.Name = "lblNotTested17"
        Me.lblNotTested17.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested17.TabIndex = 461
        Me.lblNotTested17.Text = "Not Tested"
        '
        'lblNotTested16
        '
        Me.lblNotTested16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested16.AutoSize = True
        Me.lblNotTested16.Location = New System.Drawing.Point(662, 521)
        Me.lblNotTested16.Name = "lblNotTested16"
        Me.lblNotTested16.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested16.TabIndex = 460
        Me.lblNotTested16.Text = "Not Tested"
        '
        'lblNotTested15
        '
        Me.lblNotTested15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested15.AutoSize = True
        Me.lblNotTested15.Location = New System.Drawing.Point(662, 491)
        Me.lblNotTested15.Name = "lblNotTested15"
        Me.lblNotTested15.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested15.TabIndex = 459
        Me.lblNotTested15.Text = "Not Tested"
        '
        'lblNotTested14
        '
        Me.lblNotTested14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested14.AutoSize = True
        Me.lblNotTested14.Location = New System.Drawing.Point(662, 461)
        Me.lblNotTested14.Name = "lblNotTested14"
        Me.lblNotTested14.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested14.TabIndex = 458
        Me.lblNotTested14.Text = "Not Tested"
        '
        'lblNotTested13
        '
        Me.lblNotTested13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested13.AutoSize = True
        Me.lblNotTested13.Location = New System.Drawing.Point(662, 431)
        Me.lblNotTested13.Name = "lblNotTested13"
        Me.lblNotTested13.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested13.TabIndex = 457
        Me.lblNotTested13.Text = "Not Tested"
        '
        'lblNotTested12
        '
        Me.lblNotTested12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested12.AutoSize = True
        Me.lblNotTested12.Location = New System.Drawing.Point(662, 401)
        Me.lblNotTested12.Name = "lblNotTested12"
        Me.lblNotTested12.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested12.TabIndex = 456
        Me.lblNotTested12.Text = "Not Tested"
        '
        'lblNotTested11
        '
        Me.lblNotTested11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested11.AutoSize = True
        Me.lblNotTested11.Location = New System.Drawing.Point(662, 371)
        Me.lblNotTested11.Name = "lblNotTested11"
        Me.lblNotTested11.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested11.TabIndex = 455
        Me.lblNotTested11.Text = "Not Tested"
        '
        'lblNotTested10
        '
        Me.lblNotTested10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested10.AutoSize = True
        Me.lblNotTested10.Location = New System.Drawing.Point(662, 341)
        Me.lblNotTested10.Name = "lblNotTested10"
        Me.lblNotTested10.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested10.TabIndex = 454
        Me.lblNotTested10.Text = "Not Tested"
        '
        'lblNotTested9
        '
        Me.lblNotTested9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested9.AutoSize = True
        Me.lblNotTested9.Location = New System.Drawing.Point(662, 311)
        Me.lblNotTested9.Name = "lblNotTested9"
        Me.lblNotTested9.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested9.TabIndex = 453
        Me.lblNotTested9.Text = "Not Tested"
        '
        'lblNotTested8
        '
        Me.lblNotTested8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested8.AutoSize = True
        Me.lblNotTested8.Location = New System.Drawing.Point(662, 281)
        Me.lblNotTested8.Name = "lblNotTested8"
        Me.lblNotTested8.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested8.TabIndex = 452
        Me.lblNotTested8.Text = "Not Tested"
        '
        'lblNotTested7
        '
        Me.lblNotTested7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested7.AutoSize = True
        Me.lblNotTested7.Location = New System.Drawing.Point(662, 251)
        Me.lblNotTested7.Name = "lblNotTested7"
        Me.lblNotTested7.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested7.TabIndex = 451
        Me.lblNotTested7.Text = "Not Tested"
        '
        'lblNotTested6
        '
        Me.lblNotTested6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested6.AutoSize = True
        Me.lblNotTested6.Location = New System.Drawing.Point(662, 222)
        Me.lblNotTested6.Name = "lblNotTested6"
        Me.lblNotTested6.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested6.TabIndex = 450
        Me.lblNotTested6.Text = "Not Tested"
        '
        'lblNotTested5
        '
        Me.lblNotTested5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested5.AutoSize = True
        Me.lblNotTested5.Location = New System.Drawing.Point(662, 192)
        Me.lblNotTested5.Name = "lblNotTested5"
        Me.lblNotTested5.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested5.TabIndex = 449
        Me.lblNotTested5.Text = "Not Tested"
        '
        'lblNotTested4
        '
        Me.lblNotTested4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested4.AutoSize = True
        Me.lblNotTested4.Location = New System.Drawing.Point(662, 162)
        Me.lblNotTested4.Name = "lblNotTested4"
        Me.lblNotTested4.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested4.TabIndex = 448
        Me.lblNotTested4.Text = "Not Tested"
        '
        'lblNotTested3
        '
        Me.lblNotTested3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested3.AutoSize = True
        Me.lblNotTested3.Location = New System.Drawing.Point(662, 132)
        Me.lblNotTested3.Name = "lblNotTested3"
        Me.lblNotTested3.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested3.TabIndex = 447
        Me.lblNotTested3.Text = "Not Tested"
        '
        'lblNotTested2
        '
        Me.lblNotTested2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested2.AutoSize = True
        Me.lblNotTested2.Location = New System.Drawing.Point(662, 102)
        Me.lblNotTested2.Name = "lblNotTested2"
        Me.lblNotTested2.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested2.TabIndex = 446
        Me.lblNotTested2.Text = "Not Tested"
        '
        'lblNotTested1
        '
        Me.lblNotTested1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested1.AutoSize = True
        Me.lblNotTested1.Location = New System.Drawing.Point(662, 72)
        Me.lblNotTested1.Name = "lblNotTested1"
        Me.lblNotTested1.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested1.TabIndex = 445
        Me.lblNotTested1.Text = "Not Tested"
        '
        'UCOilWorksheet
        '
        Me.Controls.Add(Me.cboTankType)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSmokeNo)
        Me.Controls.Add(Me.txtEFFNet)
        Me.Controls.Add(Me.txtGasTemp)
        Me.Controls.Add(Me.txtEFFGross)
        Me.Controls.Add(Me.txtInletPressure)
        Me.Controls.Add(Me.txtNozzleSize)
        Me.Controls.Add(Me.txtCO2)
        Me.Controls.Add(Me.txtCO2Ration)
        Me.Controls.Add(Me.txtCO2Min)
        Me.Controls.Add(Me.txtCO2Max)
        Me.Controls.Add(Me.cboSafety)
        Me.Controls.Add(Me.cboServiced)
        Me.Controls.Add(Me.cboDevice)
        Me.Controls.Add(Me.cboAirSupply)
        Me.Controls.Add(Me.cboOilPipework)
        Me.Controls.Add(Me.cboOilStorage)
        Me.Controls.Add(Me.cboBurner)
        Me.Controls.Add(Me.cboFlueFlow)
        Me.Controls.Add(Me.cboTested)
        Me.Controls.Add(Me.cboLLAppliance)
        Me.Controls.Add(Me.cboAppliance)
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
        Me.Name = "UCOilWorksheet"
        Me.Size = New System.Drawing.Size(789, 666)
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
        Combo.SetUpCombo(Me.cboTested, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNATab).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFlueFlow, DtNotTestedPassFail, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboBurner, DtNotTestedPassFail, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboOilStorage, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboOilPipework, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAirSupply, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboDevice, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboServiced, DtApplianceServiced, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSafety, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        cboSafety.Items.Add(New Combo("Visually Passed", "999999999"))
        Combo.SetUpCombo(Me.cboTankType, DynamicDataTables.TankType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate
        Combo.SetSelectedComboItem_By_Value(Me.cboAppliance, Worksheet.AssetID)
        Combo.SetSelectedComboItem_By_Value(Me.cboLLAppliance, Worksheet.LandlordsApplianceID)
        Combo.SetSelectedComboItem_By_Value(Me.cboTested, Worksheet.ApplianceTestedID)
        Combo.SetSelectedComboItem_By_Value(Me.cboFlueFlow, Worksheet.FlueFlowTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboBurner, Worksheet.SpillageTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboOilStorage, Worksheet.FlueTerminationSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboOilPipework, Worksheet.VisualConditionOfFlueSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboAirSupply, Worksheet.VentilationProvisionSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboDevice, Worksheet.SafetyDeviceOperationID)
        Me.txtSmokeNo.Text = Worksheet.DHWFlowRate
        Me.txtEFFNet.Text = Worksheet.ColdWaterTemp
        Me.txtGasTemp.Text = Worksheet.DHWTemp
        Me.txtEFFGross.Text = Worksheet.InletStaticPressure
        Me.txtInletPressure.Text = Worksheet.InletWorkingPressure
        Me.txtNozzleSize.Text = Worksheet.Nozzle
        Combo.SetSelectedComboItem_By_Value(Me.cboTankType, Worksheet.TankID)
        Me.txtCO2.Text = Worksheet.CO2
        Me.txtCO2Ration.Text = Worksheet.CO2CORatio
        Me.txtCO2Min.Text = Worksheet.BMake
        Me.txtCO2Max.Text = Worksheet.BModel
        Combo.SetSelectedComboItem_By_Value(Me.cboServiced, Worksheet.ApplianceServiceOrInspectedID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSafety, Worksheet.ApplianceSafeID)




        If Combo.GetSelectedItemDescription(Me.cboTested) <> "No" Then
        Else
            NotTested()
        End If

    End Sub

    Private Sub NotTested()
        Me.cboFlueFlow.Visible = False
        Me.cboBurner.Visible = False
        Me.cboOilStorage.Visible = False
        Me.cboOilPipework.Visible = False
        Me.cboAirSupply.Visible = False
        Me.cboDevice.Visible = False
        Me.cboServiced.Visible = False
        Me.cboTankType.Visible = False

        Me.txtSmokeNo.Visible = False
        Me.txtEFFNet.Visible = False
        Me.txtGasTemp.Visible = False
        Me.txtEFFGross.Visible = False
        Me.txtInletPressure.Visible = False
        Me.txtNozzleSize.Visible = False
        Me.txtCO2.Visible = False
        Me.txtCO2Ration.Visible = False
        Me.txtCO2Min.Visible = False
        Me.txtCO2Max.Visible = False
    End Sub

    Private Sub Tested()
        Me.cboFlueFlow.Visible = True
        Me.cboBurner.Visible = True
        Me.cboOilStorage.Visible = True
        Me.cboOilPipework.Visible = True
        Me.cboAirSupply.Visible = True
        Me.cboDevice.Visible = True
        Me.cboServiced.Visible = True
        Me.cboTankType.Visible = True

        Me.txtSmokeNo.Visible = True
        Me.txtEFFNet.Visible = True
        Me.txtGasTemp.Visible = True
        Me.txtEFFGross.Visible = True
        Me.txtInletPressure.Visible = True
        Me.txtNozzleSize.Visible = True
        Me.txtCO2.Visible = True
        Me.txtCO2Ration.Visible = True
        Me.txtCO2Min.Visible = True
        Me.txtCO2Max.Visible = True
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            Worksheet.SetReading = CInt(Enums.WorksheetFuelTypes.Oil)

            Worksheet.SetAssetID = Combo.GetSelectedItemValue(Me.cboAppliance)
            Worksheet.SetLandlordsApplianceID = Combo.GetSelectedItemValue(Me.cboLLAppliance)
            Worksheet.SetApplianceTestedID = Combo.GetSelectedItemValue(Me.cboTested)
            If Combo.GetSelectedItemDescription(Me.cboTested) <> "No" Then
                Worksheet.SetFlueFlowTestID = Combo.GetSelectedItemValue(Me.cboFlueFlow)
                Worksheet.SetSpillageTestID = Combo.GetSelectedItemValue(Me.cboBurner)
                Worksheet.SetFlueTerminationSatisfactoryID = Combo.GetSelectedItemValue(Me.cboOilStorage)
                Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.GetSelectedItemValue(Me.cboOilPipework)
                Worksheet.SetVentilationProvisionSatisfactoryID = Combo.GetSelectedItemValue(Me.cboAirSupply)
                Worksheet.SetSafetyDeviceOperationID = Combo.GetSelectedItemValue(Me.cboDevice)
                Worksheet.SetTankID = Combo.GetSelectedItemValue(Me.cboTankType)
                Worksheet.SetNozzle = Me.txtNozzleSize.Text

                Worksheet.SetDHWFlowRate = Me.txtSmokeNo.Text
                Worksheet.SetColdWaterTemp = Me.txtEFFNet.Text

                Worksheet.SetDHWTemp = Me.txtGasTemp.Text
                Worksheet.SetInletStaticPressure = Me.txtEFFGross.Text
                Worksheet.SetInletWorkingPressure = Me.txtInletPressure.Text


                Worksheet.SetCO2 = Me.txtCO2.Text
                Worksheet.SetCO2CORatio = Me.txtCO2Ration.Text
                Worksheet.SetBMake = Me.txtCO2Min.Text
                Worksheet.SetBModel = Me.txtCO2Max.Text

                Worksheet.SetApplianceServiceOrInspectedID = Combo.GetSelectedItemValue(Me.cboServiced)
            End If

            Worksheet.SetApplianceSafeID = Combo.GetSelectedItemValue(Me.cboSafety)

            Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID

            Dim dValidator As New EngineerVisitAssetWorkSheetValidatorOil
            dValidator.Validate(Worksheet, Combo.GetSelectedItemDescription(Me.cboTested))

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

    Private Sub cboTested_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTested.SelectionChangeCommitted
        Dim currentWorksheet As EngineerVisitAssetWorkSheet = Worksheet
        Worksheet = New EngineerVisitAssetWorkSheet
        If currentWorksheet?.EngineerVisitAssetWorkSheetID > 0 Then Worksheet.SetEngineerVisitAssetWorkSheetID = currentWorksheet.EngineerVisitAssetWorkSheetID

        If Combo.GetSelectedItemDescription(Me.cboTested) <> "No" Then
            Tested()
        Else
            NotTested()
        End If
    End Sub
End Class

