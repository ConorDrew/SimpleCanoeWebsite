Imports FSM.Entity.EngineerVisitAssetWorkSheets
Imports FSM.Entity.Sys

Public Class UCComercialWorksheet : Inherits FSM.UCBase : Implements IUserControl

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

    Friend WithEvents txtMaxCO As TextBox
    Friend WithEvents txtMaxCO2 As TextBox
    Friend WithEvents txtHeatInput As TextBox
    Friend WithEvents txtOperatingPressure As TextBox
    Friend WithEvents cboSafety As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cboServiced As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboGastight As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboFSPFitted As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboGasIsolation As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboManufactureInfo As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboElectricalIsolator As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboGasHose As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboTested As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboLLAppliance As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboAppliance As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNotTested1 As Label
    Friend WithEvents lblNotTested2 As Label
    Friend WithEvents lblNotTested3 As Label
    Friend WithEvents lblNotTested6 As Label
    Friend WithEvents lblNotTested5 As Label
    Friend WithEvents lblNotTested4 As Label
    Friend WithEvents lblNotTested10 As Label
    Friend WithEvents lblNotTested9 As Label
    Friend WithEvents lblNotTested8 As Label
    Friend WithEvents lblNotTested7 As Label
    Friend WithEvents lblNotTested18 As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtMaxCO = New System.Windows.Forms.TextBox()
        Me.txtMaxCO2 = New System.Windows.Forms.TextBox()
        Me.txtHeatInput = New System.Windows.Forms.TextBox()
        Me.txtOperatingPressure = New System.Windows.Forms.TextBox()
        Me.cboSafety = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboServiced = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboGastight = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboFSPFitted = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboGasIsolation = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboManufactureInfo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboElectricalIsolator = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboGasHose = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTested = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboLLAppliance = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAppliance = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNotTested1 = New System.Windows.Forms.Label()
        Me.lblNotTested2 = New System.Windows.Forms.Label()
        Me.lblNotTested3 = New System.Windows.Forms.Label()
        Me.lblNotTested6 = New System.Windows.Forms.Label()
        Me.lblNotTested5 = New System.Windows.Forms.Label()
        Me.lblNotTested4 = New System.Windows.Forms.Label()
        Me.lblNotTested10 = New System.Windows.Forms.Label()
        Me.lblNotTested9 = New System.Windows.Forms.Label()
        Me.lblNotTested8 = New System.Windows.Forms.Label()
        Me.lblNotTested7 = New System.Windows.Forms.Label()
        Me.lblNotTested18 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtMaxCO
        '
        Me.txtMaxCO.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMaxCO.Location = New System.Drawing.Point(601, 278)
        Me.txtMaxCO.Name = "txtMaxCO"
        Me.txtMaxCO.Size = New System.Drawing.Size(188, 21)
        Me.txtMaxCO.TabIndex = 10
        '
        'txtMaxCO2
        '
        Me.txtMaxCO2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMaxCO2.Location = New System.Drawing.Point(601, 309)
        Me.txtMaxCO2.Name = "txtMaxCO2"
        Me.txtMaxCO2.Size = New System.Drawing.Size(188, 21)
        Me.txtMaxCO2.TabIndex = 11
        '
        'txtHeatInput
        '
        Me.txtHeatInput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHeatInput.Location = New System.Drawing.Point(601, 339)
        Me.txtHeatInput.Name = "txtHeatInput"
        Me.txtHeatInput.Size = New System.Drawing.Size(188, 21)
        Me.txtHeatInput.TabIndex = 12
        '
        'txtOperatingPressure
        '
        Me.txtOperatingPressure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOperatingPressure.Location = New System.Drawing.Point(601, 368)
        Me.txtOperatingPressure.Name = "txtOperatingPressure"
        Me.txtOperatingPressure.Size = New System.Drawing.Size(188, 21)
        Me.txtOperatingPressure.TabIndex = 13
        '
        'cboSafety
        '
        Me.cboSafety.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSafety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSafety.Location = New System.Drawing.Point(601, 428)
        Me.cboSafety.Name = "cboSafety"
        Me.cboSafety.Size = New System.Drawing.Size(188, 21)
        Me.cboSafety.TabIndex = 22
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 431)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 13)
        Me.Label18.TabIndex = 365
        Me.Label18.Text = "Appliance safety"
        '
        'cboServiced
        '
        Me.cboServiced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboServiced.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiced.Location = New System.Drawing.Point(601, 398)
        Me.cboServiced.Name = "cboServiced"
        Me.cboServiced.Size = New System.Drawing.Size(188, 21)
        Me.cboServiced.TabIndex = 21
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 401)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(181, 13)
        Me.Label19.TabIndex = 363
        Me.Label19.Text = "Appliance service or inspected"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 372)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(161, 13)
        Me.Label15.TabIndex = 354
        Me.Label15.Text = "Operating pressure (mbar)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 342)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 13)
        Me.Label16.TabIndex = 353
        Me.Label16.Text = "Heat input (KW)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 312)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(209, 13)
        Me.Label17.TabIndex = 352
        Me.Label17.Text = "Max CO2 reading around Appliance"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(202, 13)
        Me.Label6.TabIndex = 351
        Me.Label6.Text = "Max CO reading around Appliance"
        '
        'cboGastight
        '
        Me.cboGastight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboGastight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGastight.Location = New System.Drawing.Point(601, 248)
        Me.cboGastight.Name = "cboGastight"
        Me.cboGastight.Size = New System.Drawing.Size(188, 21)
        Me.cboGastight.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 13)
        Me.Label7.TabIndex = 350
        Me.Label7.Text = "Pipework gastight"
        '
        'cboFSPFitted
        '
        Me.cboFSPFitted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFSPFitted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFSPFitted.Location = New System.Drawing.Point(601, 218)
        Me.cboFSPFitted.Name = "cboFSPFitted"
        Me.cboFSPFitted.Size = New System.Drawing.Size(188, 21)
        Me.cboFSPFitted.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 221)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 13)
        Me.Label8.TabIndex = 348
        Me.Label8.Text = "FSP fitted to all burners"
        '
        'cboGasIsolation
        '
        Me.cboGasIsolation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboGasIsolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGasIsolation.Location = New System.Drawing.Point(601, 189)
        Me.cboGasIsolation.Name = "cboGasIsolation"
        Me.cboGasIsolation.Size = New System.Drawing.Size(188, 21)
        Me.cboGasIsolation.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 192)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 13)
        Me.Label9.TabIndex = 346
        Me.Label9.Text = "Gas isolation value fitted"
        '
        'cboManufactureInfo
        '
        Me.cboManufactureInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboManufactureInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboManufactureInfo.Location = New System.Drawing.Point(601, 159)
        Me.cboManufactureInfo.Name = "cboManufactureInfo"
        Me.cboManufactureInfo.Size = New System.Drawing.Size(188, 21)
        Me.cboManufactureInfo.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 162)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(208, 13)
        Me.Label10.TabIndex = 344
        Me.Label10.Text = "Manufactures inforamtion Available"
        '
        'cboElectricalIsolator
        '
        Me.cboElectricalIsolator.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboElectricalIsolator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboElectricalIsolator.Location = New System.Drawing.Point(601, 129)
        Me.cboElectricalIsolator.Name = "cboElectricalIsolator"
        Me.cboElectricalIsolator.Size = New System.Drawing.Size(188, 21)
        Me.cboElectricalIsolator.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(251, 13)
        Me.Label3.TabIndex = 342
        Me.Label3.Text = "Electrical isolator fitten and correctly fused"
        '
        'cboGasHose
        '
        Me.cboGasHose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboGasHose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGasHose.Location = New System.Drawing.Point(601, 99)
        Me.cboGasHose.Name = "cboGasHose"
        Me.cboGasHose.Size = New System.Drawing.Size(188, 21)
        Me.cboGasHose.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(276, 13)
        Me.Label4.TabIndex = 340
        Me.Label4.Text = "Gas hose and required restraint fitted correctly"
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
        Me.lblNotTested18.Location = New System.Drawing.Point(661, 401)
        Me.lblNotTested18.Name = "lblNotTested18"
        Me.lblNotTested18.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested18.TabIndex = 396
        Me.lblNotTested18.Text = "Not Tested"
        '
        'UCComercialWorksheet
        '
        Me.Controls.Add(Me.txtMaxCO)
        Me.Controls.Add(Me.txtMaxCO2)
        Me.Controls.Add(Me.txtHeatInput)
        Me.Controls.Add(Me.txtOperatingPressure)
        Me.Controls.Add(Me.cboSafety)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboServiced)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboGastight)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboFSPFitted)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboGasIsolation)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboManufactureInfo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboElectricalIsolator)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboGasHose)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTested)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboLLAppliance)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboAppliance)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNotTested18)
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
        Me.Name = "UCComercialWorksheet"
        Me.Size = New System.Drawing.Size(789, 462)
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
        Combo.SetUpCombo(Me.cboTested, DtYesNo, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboGasHose, DtYesNoNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboElectricalIsolator, DtYesNoNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboManufactureInfo, DtYesNoNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboGasIsolation, DtYesNoNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFSPFitted, DtYesNoNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboGastight, DtYesNoNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboServiced, DtApplianceServiced, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSafety, DtYesNoNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        cboSafety.Items.Add(New Combo("Visually Passed", "999999999"))
    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate
        Me.txtMaxCO.Text = Worksheet.DHWFlowRate
        Me.txtMaxCO2.Text = Worksheet.ColdWaterTemp
        Me.txtHeatInput.Text = Worksheet.InletStaticPressure
        Me.txtOperatingPressure.Text = Worksheet.MaxBurnerPressure


        Combo.SetSelectedComboItem_By_Value(Me.cboAppliance, Worksheet.AssetID)
        Combo.SetSelectedComboItem_By_Value(Me.cboGasHose, Worksheet.FlueFlowTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboElectricalIsolator, Worksheet.SpillageTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboManufactureInfo, Worksheet.FlueTerminationSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboGasIsolation, Worksheet.VisualConditionOfFlueSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboFSPFitted, Worksheet.VentilationProvisionSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboGastight, Worksheet.SafetyDeviceOperationID)
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

        Me.cboGasHose.Visible = False
        Me.cboElectricalIsolator.Visible = False
        Me.cboManufactureInfo.Visible = False
        Me.cboGasIsolation.Visible = False
        Me.cboFSPFitted.Visible = False
        Me.cboGastight.Visible = False
        Me.cboServiced.Visible = False

        Me.txtMaxCO.Visible = False
        Me.txtMaxCO2.Visible = False
        Me.txtHeatInput.Visible = False
        Me.txtOperatingPressure.Visible = False
    End Sub

    Private Sub Tested()

        Me.cboGasHose.Visible = True
        Me.cboElectricalIsolator.Visible = True
        Me.cboManufactureInfo.Visible = True
        Me.cboGasIsolation.Visible = True
        Me.cboFSPFitted.Visible = True
        Me.cboGastight.Visible = True
        Me.cboServiced.Visible = True

        Me.txtMaxCO.Visible = True
        Me.txtMaxCO2.Visible = True
        Me.txtHeatInput.Visible = True
        Me.txtOperatingPressure.Visible = True
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            Worksheet.SetReading = CInt(Enums.WorksheetFuelTypes.ComCat)

            Worksheet.SetAssetID = Combo.GetSelectedItemValue(Me.cboAppliance)
            Worksheet.SetLandlordsApplianceID = Combo.GetSelectedItemValue(Me.cboLLAppliance)
            Worksheet.SetApplianceTestedID = Combo.GetSelectedItemValue(Me.cboTested)
            If Combo.GetSelectedItemDescription(Me.cboTested) <> "No" Then
                Worksheet.SetFlueFlowTestID = Combo.GetSelectedItemValue(Me.cboGasHose)
                Worksheet.SetSpillageTestID = Combo.GetSelectedItemValue(Me.cboElectricalIsolator)
                Worksheet.SetFlueTerminationSatisfactoryID = Combo.GetSelectedItemValue(Me.cboManufactureInfo)
                Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.GetSelectedItemValue(Me.cboGasIsolation)
                Worksheet.SetVentilationProvisionSatisfactoryID = Combo.GetSelectedItemValue(Me.cboFSPFitted)
                Worksheet.SetSafetyDeviceOperationID = Combo.GetSelectedItemValue(Me.cboGastight)

                Worksheet.SetDHWFlowRate = Me.txtMaxCO.Text
                Worksheet.SetColdWaterTemp = Me.txtMaxCO2.Text

                Worksheet.SetInletStaticPressure = Me.txtHeatInput.Text
                Worksheet.SetMaxBurnerPressure = Me.txtOperatingPressure.Text

                Worksheet.SetApplianceServiceOrInspectedID = Combo.GetSelectedItemValue(Me.cboServiced)
            End If

            Worksheet.SetApplianceSafeID = Combo.GetSelectedItemValue(Me.cboSafety)

            Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID

            Dim dValidator As New EngineerVisitAssetWorkSheetValidatorComCat
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

