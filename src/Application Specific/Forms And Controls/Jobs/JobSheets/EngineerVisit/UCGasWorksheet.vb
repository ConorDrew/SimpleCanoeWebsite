Imports FSM.Entity.EngineerVisitAssetWorkSheets
Imports FSM.Entity.Sys

Public Class UCGasWorksheet : Inherits FSM.UCBase : Implements IUserControl

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

    Friend WithEvents txtDHWFlow As TextBox
    Friend WithEvents txtColdTemp As TextBox
    Friend WithEvents txtDHWTemp As TextBox
    Friend WithEvents txtHeadInput As TextBox
    Friend WithEvents txtInletPressure As TextBox
    Friend WithEvents txtMinBurnerPressure As TextBox
    Friend WithEvents txtMaxBurnerPressure As TextBox
    Friend WithEvents txtCO2 As TextBox
    Friend WithEvents txtCO2Ration As TextBox
    Friend WithEvents txtCO2Min As TextBox
    Friend WithEvents txtCO2Max As TextBox
    Friend WithEvents cboSafety As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cboServiced As ComboBox
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
    Friend WithEvents cboDevice As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboProvisions As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboVisualCondition As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboFlueTermination As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboFlueSpil As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboFlueFlow As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboTested As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboLLAppliance As ComboBox
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtDHWFlow = New System.Windows.Forms.TextBox()
        Me.txtColdTemp = New System.Windows.Forms.TextBox()
        Me.txtDHWTemp = New System.Windows.Forms.TextBox()
        Me.txtHeadInput = New System.Windows.Forms.TextBox()
        Me.txtInletPressure = New System.Windows.Forms.TextBox()
        Me.txtMinBurnerPressure = New System.Windows.Forms.TextBox()
        Me.txtMaxBurnerPressure = New System.Windows.Forms.TextBox()
        Me.txtCO2 = New System.Windows.Forms.TextBox()
        Me.txtCO2Ration = New System.Windows.Forms.TextBox()
        Me.txtCO2Min = New System.Windows.Forms.TextBox()
        Me.txtCO2Max = New System.Windows.Forms.TextBox()
        Me.cboSafety = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboServiced = New System.Windows.Forms.ComboBox()
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
        Me.cboDevice = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboProvisions = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboVisualCondition = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboFlueTermination = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboFlueSpil = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboFlueFlow = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTested = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboLLAppliance = New System.Windows.Forms.ComboBox()
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
        Me.SuspendLayout()
        '
        'txtDHWFlow
        '
        Me.txtDHWFlow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDHWFlow.Location = New System.Drawing.Point(601, 278)
        Me.txtDHWFlow.Name = "txtDHWFlow"
        Me.txtDHWFlow.Size = New System.Drawing.Size(188, 21)
        Me.txtDHWFlow.TabIndex = 10
        '
        'txtColdTemp
        '
        Me.txtColdTemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtColdTemp.Location = New System.Drawing.Point(601, 309)
        Me.txtColdTemp.Name = "txtColdTemp"
        Me.txtColdTemp.Size = New System.Drawing.Size(188, 21)
        Me.txtColdTemp.TabIndex = 11
        '
        'txtDHWTemp
        '
        Me.txtDHWTemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDHWTemp.Location = New System.Drawing.Point(601, 339)
        Me.txtDHWTemp.Name = "txtDHWTemp"
        Me.txtDHWTemp.Size = New System.Drawing.Size(188, 21)
        Me.txtDHWTemp.TabIndex = 12
        '
        'txtHeadInput
        '
        Me.txtHeadInput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHeadInput.Location = New System.Drawing.Point(601, 368)
        Me.txtHeadInput.Name = "txtHeadInput"
        Me.txtHeadInput.Size = New System.Drawing.Size(188, 21)
        Me.txtHeadInput.TabIndex = 13
        '
        'txtInletPressure
        '
        Me.txtInletPressure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInletPressure.Location = New System.Drawing.Point(601, 399)
        Me.txtInletPressure.Name = "txtInletPressure"
        Me.txtInletPressure.Size = New System.Drawing.Size(188, 21)
        Me.txtInletPressure.TabIndex = 14
        '
        'txtMinBurnerPressure
        '
        Me.txtMinBurnerPressure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMinBurnerPressure.Location = New System.Drawing.Point(601, 429)
        Me.txtMinBurnerPressure.Name = "txtMinBurnerPressure"
        Me.txtMinBurnerPressure.Size = New System.Drawing.Size(188, 21)
        Me.txtMinBurnerPressure.TabIndex = 15
        '
        'txtMaxBurnerPressure
        '
        Me.txtMaxBurnerPressure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMaxBurnerPressure.Location = New System.Drawing.Point(601, 458)
        Me.txtMaxBurnerPressure.Name = "txtMaxBurnerPressure"
        Me.txtMaxBurnerPressure.Size = New System.Drawing.Size(188, 21)
        Me.txtMaxBurnerPressure.TabIndex = 16
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
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 641)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 13)
        Me.Label18.TabIndex = 365
        Me.Label18.Text = "Appliance safety"
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
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 611)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(181, 13)
        Me.Label19.TabIndex = 363
        Me.Label19.Text = "Appliance service or inspected"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 581)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 13)
        Me.Label20.TabIndex = 361
        Me.Label20.Text = "CO2 max"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 552)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(57, 13)
        Me.Label21.TabIndex = 360
        Me.Label21.Text = "CO2 min"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 522)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(123, 13)
        Me.Label22.TabIndex = 359
        Me.Label22.Text = "CO2 / co ration high"
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
        Me.Label12.Size = New System.Drawing.Size(126, 13)
        Me.Label12.TabIndex = 357
        Me.Label12.Text = "Max burner pressure"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 431)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 13)
        Me.Label13.TabIndex = 356
        Me.Label13.Text = "Min burner pressure"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 402)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 13)
        Me.Label14.TabIndex = 355
        Me.Label14.Text = "Inlet working pressure"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 372)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 354
        Me.Label15.Text = "Head input"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 342)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 13)
        Me.Label16.TabIndex = 353
        Me.Label16.Text = "DHW temp"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 312)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 13)
        Me.Label17.TabIndex = 352
        Me.Label17.Text = "Cold water temp"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 351
        Me.Label6.Text = "DHW flow rate"
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 13)
        Me.Label7.TabIndex = 350
        Me.Label7.Text = "Safety device operation"
        '
        'cboProvisions
        '
        Me.cboProvisions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboProvisions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvisions.Location = New System.Drawing.Point(601, 218)
        Me.cboProvisions.Name = "cboProvisions"
        Me.cboProvisions.Size = New System.Drawing.Size(188, 21)
        Me.cboProvisions.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 221)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(192, 13)
        Me.Label8.TabIndex = 348
        Me.Label8.Text = "Ventilation provision satisfactory"
        '
        'cboVisualCondition
        '
        Me.cboVisualCondition.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboVisualCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualCondition.Location = New System.Drawing.Point(601, 189)
        Me.cboVisualCondition.Name = "cboVisualCondition"
        Me.cboVisualCondition.Size = New System.Drawing.Size(188, 21)
        Me.cboVisualCondition.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 192)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(141, 13)
        Me.Label9.TabIndex = 346
        Me.Label9.Text = "Visual Condition of Flue"
        '
        'cboFlueTermination
        '
        Me.cboFlueTermination.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFlueTermination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlueTermination.Location = New System.Drawing.Point(601, 159)
        Me.cboFlueTermination.Name = "cboFlueTermination"
        Me.cboFlueTermination.Size = New System.Drawing.Size(188, 21)
        Me.cboFlueTermination.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 162)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(171, 13)
        Me.Label10.TabIndex = 344
        Me.Label10.Text = "Flue Termination satisfactory"
        '
        'cboFlueSpil
        '
        Me.cboFlueSpil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFlueSpil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlueSpil.Location = New System.Drawing.Point(601, 129)
        Me.cboFlueSpil.Name = "cboFlueSpil"
        Me.cboFlueSpil.Size = New System.Drawing.Size(188, 21)
        Me.cboFlueSpil.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 342
        Me.Label3.Text = "Flue spilage test"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 340
        Me.Label4.Text = "Flue Flow test"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 338
        Me.Label5.Text = "Appliance tested"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 43)
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
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 491)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 13)
        Me.Label23.TabIndex = 378
        Me.Label23.Text = "CO2"
        '
        'lblNotTested1
        '
        Me.lblNotTested1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested1.AutoSize = True
        Me.lblNotTested1.Location = New System.Drawing.Point(661, 102)
        Me.lblNotTested1.Name = "lblNotTested1"
        Me.lblNotTested1.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested1.TabIndex = 379
        Me.lblNotTested1.Text = "Not Tested"
        '
        'lblNotTested2
        '
        Me.lblNotTested2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested2.AutoSize = True
        Me.lblNotTested2.Location = New System.Drawing.Point(661, 132)
        Me.lblNotTested2.Name = "lblNotTested2"
        Me.lblNotTested2.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested2.TabIndex = 380
        Me.lblNotTested2.Text = "Not Tested"
        '
        'lblNotTested3
        '
        Me.lblNotTested3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested3.AutoSize = True
        Me.lblNotTested3.Location = New System.Drawing.Point(661, 162)
        Me.lblNotTested3.Name = "lblNotTested3"
        Me.lblNotTested3.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested3.TabIndex = 381
        Me.lblNotTested3.Text = "Not Tested"
        '
        'lblNotTested6
        '
        Me.lblNotTested6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested6.AutoSize = True
        Me.lblNotTested6.Location = New System.Drawing.Point(661, 252)
        Me.lblNotTested6.Name = "lblNotTested6"
        Me.lblNotTested6.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested6.TabIndex = 384
        Me.lblNotTested6.Text = "Not Tested"
        '
        'lblNotTested5
        '
        Me.lblNotTested5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested5.AutoSize = True
        Me.lblNotTested5.Location = New System.Drawing.Point(661, 222)
        Me.lblNotTested5.Name = "lblNotTested5"
        Me.lblNotTested5.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested5.TabIndex = 383
        Me.lblNotTested5.Text = "Not Tested"
        '
        'lblNotTested4
        '
        Me.lblNotTested4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested4.AutoSize = True
        Me.lblNotTested4.Location = New System.Drawing.Point(661, 192)
        Me.lblNotTested4.Name = "lblNotTested4"
        Me.lblNotTested4.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested4.TabIndex = 382
        Me.lblNotTested4.Text = "Not Tested"
        '
        'lblNotTested12
        '
        Me.lblNotTested12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested12.AutoSize = True
        Me.lblNotTested12.Location = New System.Drawing.Point(661, 431)
        Me.lblNotTested12.Name = "lblNotTested12"
        Me.lblNotTested12.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested12.TabIndex = 390
        Me.lblNotTested12.Text = "Not Tested"
        '
        'lblNotTested11
        '
        Me.lblNotTested11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested11.AutoSize = True
        Me.lblNotTested11.Location = New System.Drawing.Point(661, 401)
        Me.lblNotTested11.Name = "lblNotTested11"
        Me.lblNotTested11.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested11.TabIndex = 389
        Me.lblNotTested11.Text = "Not Tested"
        '
        'lblNotTested10
        '
        Me.lblNotTested10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested10.AutoSize = True
        Me.lblNotTested10.Location = New System.Drawing.Point(661, 371)
        Me.lblNotTested10.Name = "lblNotTested10"
        Me.lblNotTested10.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested10.TabIndex = 388
        Me.lblNotTested10.Text = "Not Tested"
        '
        'lblNotTested9
        '
        Me.lblNotTested9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested9.AutoSize = True
        Me.lblNotTested9.Location = New System.Drawing.Point(661, 341)
        Me.lblNotTested9.Name = "lblNotTested9"
        Me.lblNotTested9.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested9.TabIndex = 387
        Me.lblNotTested9.Text = "Not Tested"
        '
        'lblNotTested8
        '
        Me.lblNotTested8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested8.AutoSize = True
        Me.lblNotTested8.Location = New System.Drawing.Point(661, 311)
        Me.lblNotTested8.Name = "lblNotTested8"
        Me.lblNotTested8.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested8.TabIndex = 386
        Me.lblNotTested8.Text = "Not Tested"
        '
        'lblNotTested7
        '
        Me.lblNotTested7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested7.AutoSize = True
        Me.lblNotTested7.Location = New System.Drawing.Point(661, 281)
        Me.lblNotTested7.Name = "lblNotTested7"
        Me.lblNotTested7.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested7.TabIndex = 385
        Me.lblNotTested7.Text = "Not Tested"
        '
        'lblNotTested18
        '
        Me.lblNotTested18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested18.AutoSize = True
        Me.lblNotTested18.Location = New System.Drawing.Point(661, 611)
        Me.lblNotTested18.Name = "lblNotTested18"
        Me.lblNotTested18.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested18.TabIndex = 396
        Me.lblNotTested18.Text = "Not Tested"
        '
        'lblNotTested17
        '
        Me.lblNotTested17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested17.AutoSize = True
        Me.lblNotTested17.Location = New System.Drawing.Point(661, 581)
        Me.lblNotTested17.Name = "lblNotTested17"
        Me.lblNotTested17.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested17.TabIndex = 395
        Me.lblNotTested17.Text = "Not Tested"
        '
        'lblNotTested16
        '
        Me.lblNotTested16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested16.AutoSize = True
        Me.lblNotTested16.Location = New System.Drawing.Point(661, 551)
        Me.lblNotTested16.Name = "lblNotTested16"
        Me.lblNotTested16.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested16.TabIndex = 394
        Me.lblNotTested16.Text = "Not Tested"
        '
        'lblNotTested15
        '
        Me.lblNotTested15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested15.AutoSize = True
        Me.lblNotTested15.Location = New System.Drawing.Point(661, 521)
        Me.lblNotTested15.Name = "lblNotTested15"
        Me.lblNotTested15.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested15.TabIndex = 393
        Me.lblNotTested15.Text = "Not Tested"
        '
        'lblNotTested14
        '
        Me.lblNotTested14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested14.AutoSize = True
        Me.lblNotTested14.Location = New System.Drawing.Point(661, 491)
        Me.lblNotTested14.Name = "lblNotTested14"
        Me.lblNotTested14.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested14.TabIndex = 392
        Me.lblNotTested14.Text = "Not Tested"
        '
        'lblNotTested13
        '
        Me.lblNotTested13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested13.AutoSize = True
        Me.lblNotTested13.Location = New System.Drawing.Point(661, 461)
        Me.lblNotTested13.Name = "lblNotTested13"
        Me.lblNotTested13.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested13.TabIndex = 391
        Me.lblNotTested13.Text = "Not Tested"
        '
        'UCGasWorksheet
        '
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtDHWFlow)
        Me.Controls.Add(Me.txtColdTemp)
        Me.Controls.Add(Me.txtDHWTemp)
        Me.Controls.Add(Me.txtHeadInput)
        Me.Controls.Add(Me.txtInletPressure)
        Me.Controls.Add(Me.txtMinBurnerPressure)
        Me.Controls.Add(Me.txtMaxBurnerPressure)
        Me.Controls.Add(Me.txtCO2)
        Me.Controls.Add(Me.txtCO2Ration)
        Me.Controls.Add(Me.txtCO2Min)
        Me.Controls.Add(Me.txtCO2Max)
        Me.Controls.Add(Me.cboSafety)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboServiced)
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
        Me.Controls.Add(Me.cboDevice)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboProvisions)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboVisualCondition)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboFlueTermination)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboFlueSpil)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboFlueFlow)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTested)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboLLAppliance)
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
        Me.Name = "UCGasWorksheet"
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
        Combo.SetUpCombo(Me.cboFlueSpil, DtNotTestedPassFail, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFlueTermination, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboVisualCondition, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboProvisions, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboDevice, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboServiced, DtApplianceServiced, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSafety, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        cboSafety.Items.Add(New Combo("Visually Passed", "999999999"))
    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate
        Me.txtDHWFlow.Text = Worksheet.DHWFlowRate
        Me.txtColdTemp.Text = Worksheet.ColdWaterTemp
        Me.txtDHWTemp.Text = Worksheet.DHWTemp
        Me.txtHeadInput.Text = Worksheet.InletStaticPressure
        Me.txtInletPressure.Text = Worksheet.InletWorkingPressure
        Me.txtMinBurnerPressure.Text = Worksheet.MinBurnerPressure
        Me.txtMaxBurnerPressure.Text = Worksheet.MaxBurnerPressure
        Me.txtCO2.Text = Worksheet.CO2
        Me.txtCO2Ration.Text = Worksheet.CO2CORatio
        Me.txtCO2Min.Text = Worksheet.BMake
        Me.txtCO2Max.Text = Worksheet.BModel

        Combo.SetSelectedComboItem_By_Value(Me.cboAppliance, Worksheet.AssetID)
        Combo.SetSelectedComboItem_By_Value(Me.cboFlueFlow, Worksheet.FlueFlowTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboFlueSpil, Worksheet.SpillageTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboFlueTermination, Worksheet.FlueTerminationSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboVisualCondition, Worksheet.VisualConditionOfFlueSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboProvisions, Worksheet.VentilationProvisionSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboDevice, Worksheet.SafetyDeviceOperationID)
        Combo.SetSelectedComboItem_By_Value(Me.cboServiced, Worksheet.ApplianceServiceOrInspectedID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSafety, Worksheet.ApplianceSafeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboLLAppliance, Worksheet.LandlordsApplianceID)
        Combo.SetSelectedComboItem_By_Value(Me.cboTested, Worksheet.ApplianceTestedID)

        If Combo.GetSelectedItemDescription(Me.cboTested) <> "No" Then
        Else
            NotTested()
        End If

    End Sub

    Private Sub NotTested()

        Me.cboFlueFlow.Visible = False
        Me.cboFlueSpil.Visible = False
        Me.cboFlueTermination.Visible = False
        Me.cboVisualCondition.Visible = False
        Me.cboProvisions.Visible = False
        Me.cboDevice.Visible = False
        Me.cboServiced.Visible = False

        Me.txtDHWFlow.Visible = False
        Me.txtColdTemp.Visible = False
        Me.txtDHWTemp.Visible = False
        Me.txtHeadInput.Visible = False
        Me.txtInletPressure.Visible = False
        Me.txtMinBurnerPressure.Visible = False
        Me.txtMaxBurnerPressure.Visible = False
        Me.txtCO2.Visible = False
        Me.txtCO2Ration.Visible = False
        Me.txtCO2Min.Visible = False
        Me.txtCO2Max.Visible = False
    End Sub

    Private Sub Tested()

        Me.cboFlueFlow.Visible = True
        Me.cboFlueSpil.Visible = True
        Me.cboFlueTermination.Visible = True
        Me.cboVisualCondition.Visible = True
        Me.cboProvisions.Visible = True
        Me.cboDevice.Visible = True
        Me.cboServiced.Visible = True

        Me.txtDHWFlow.Visible = True
        Me.txtColdTemp.Visible = True
        Me.txtDHWTemp.Visible = True
        Me.txtHeadInput.Visible = True
        Me.txtInletPressure.Visible = True
        Me.txtMinBurnerPressure.Visible = True
        Me.txtMaxBurnerPressure.Visible = True
        Me.txtCO2.Visible = True
        Me.txtCO2Ration.Visible = True
        Me.txtCO2Min.Visible = True
        Me.txtCO2Max.Visible = True
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            Worksheet.SetReading = CInt(Enums.WorksheetFuelTypes.Gas)

            Worksheet.SetAssetID = Combo.GetSelectedItemValue(Me.cboAppliance)
            Worksheet.SetLandlordsApplianceID = Combo.GetSelectedItemValue(Me.cboLLAppliance)
            Worksheet.SetApplianceTestedID = Combo.GetSelectedItemValue(Me.cboTested)
            If Combo.GetSelectedItemDescription(Me.cboTested) <> "No" Then
                Worksheet.SetFlueFlowTestID = Combo.GetSelectedItemValue(Me.cboFlueFlow)
                Worksheet.SetSpillageTestID = Combo.GetSelectedItemValue(Me.cboFlueSpil)
                Worksheet.SetFlueTerminationSatisfactoryID = Combo.GetSelectedItemValue(Me.cboFlueTermination)
                Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.GetSelectedItemValue(Me.cboVisualCondition)
                Worksheet.SetVentilationProvisionSatisfactoryID = Combo.GetSelectedItemValue(Me.cboProvisions)
                Worksheet.SetSafetyDeviceOperationID = Combo.GetSelectedItemValue(Me.cboDevice)

                Worksheet.SetDHWFlowRate = Me.txtDHWFlow.Text
                Worksheet.SetColdWaterTemp = Me.txtColdTemp.Text

                Worksheet.SetDHWTemp = Me.txtDHWTemp.Text
                Worksheet.SetInletStaticPressure = Me.txtHeadInput.Text
                Worksheet.SetInletWorkingPressure = Me.txtInletPressure.Text

                Worksheet.SetMinBurnerPressure = Me.txtMinBurnerPressure.Text
                Worksheet.SetMaxBurnerPressure = Me.txtMaxBurnerPressure.Text
                Worksheet.SetCO2 = Me.txtCO2.Text
                Worksheet.SetCO2CORatio = Me.txtCO2Ration.Text
                Worksheet.SetBMake = Me.txtCO2Min.Text
                Worksheet.SetBModel = Me.txtCO2Max.Text

                Worksheet.SetApplianceServiceOrInspectedID = Combo.GetSelectedItemValue(Me.cboServiced)
            End If

            Worksheet.SetApplianceSafeID = Combo.GetSelectedItemValue(Me.cboSafety)

            Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID

            Dim dValidator As New EngineerVisitAssetWorkSheetValidatorGas
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

