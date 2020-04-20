Imports FSM.Entity.EngineerVisitAssetWorkSheets
Imports FSM.Entity.Sys

Public Class UCASHPWorksheet : Inherits FSM.UCBase : Implements IUserControl

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
    Friend WithEvents cboSafety As ComboBox
    Friend WithEvents cboServiced As ComboBox
    Friend WithEvents cboSafetyDeviceOperation As ComboBox
    Friend WithEvents cboVentilation As ComboBox
    Friend WithEvents cboStability As ComboBox
    Friend WithEvents cboSafetyDevices As ComboBox
    Friend WithEvents cboOperation As ComboBox
    Friend WithEvents cboPressureTest As ComboBox
    Friend WithEvents cboLLAppliance As ComboBox
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
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents cboGlycol As ComboBox
    Friend WithEvents cboCondition As ComboBox
    Friend WithEvents cboLegionella As ComboBox
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
        Me.cboSafety = New System.Windows.Forms.ComboBox()
        Me.cboServiced = New System.Windows.Forms.ComboBox()
        Me.cboSafetyDeviceOperation = New System.Windows.Forms.ComboBox()
        Me.cboVentilation = New System.Windows.Forms.ComboBox()
        Me.cboStability = New System.Windows.Forms.ComboBox()
        Me.cboSafetyDevices = New System.Windows.Forms.ComboBox()
        Me.cboOperation = New System.Windows.Forms.ComboBox()
        Me.cboPressureTest = New System.Windows.Forms.ComboBox()
        Me.cboLLAppliance = New System.Windows.Forms.ComboBox()
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
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.cboGlycol = New System.Windows.Forms.ComboBox()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.cboLegionella = New System.Windows.Forms.ComboBox()
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
        'cboSafety
        '
        Me.cboSafety.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSafety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSafety.Location = New System.Drawing.Point(601, 369)
        Me.cboSafety.Name = "cboSafety"
        Me.cboSafety.Size = New System.Drawing.Size(188, 21)
        Me.cboSafety.TabIndex = 14
        '
        'cboServiced
        '
        Me.cboServiced.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboServiced.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiced.Location = New System.Drawing.Point(601, 339)
        Me.cboServiced.Name = "cboServiced"
        Me.cboServiced.Size = New System.Drawing.Size(188, 21)
        Me.cboServiced.TabIndex = 13
        '
        'cboSafetyDeviceOperation
        '
        Me.cboSafetyDeviceOperation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSafetyDeviceOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSafetyDeviceOperation.Location = New System.Drawing.Point(601, 218)
        Me.cboSafetyDeviceOperation.Name = "cboSafetyDeviceOperation"
        Me.cboSafetyDeviceOperation.Size = New System.Drawing.Size(188, 21)
        Me.cboSafetyDeviceOperation.TabIndex = 9
        '
        'cboVentilation
        '
        Me.cboVentilation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboVentilation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVentilation.Location = New System.Drawing.Point(601, 188)
        Me.cboVentilation.Name = "cboVentilation"
        Me.cboVentilation.Size = New System.Drawing.Size(188, 21)
        Me.cboVentilation.TabIndex = 8
        '
        'cboStability
        '
        Me.cboStability.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStability.Location = New System.Drawing.Point(601, 159)
        Me.cboStability.Name = "cboStability"
        Me.cboStability.Size = New System.Drawing.Size(188, 21)
        Me.cboStability.TabIndex = 7
        '
        'cboSafetyDevices
        '
        Me.cboSafetyDevices.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSafetyDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSafetyDevices.Location = New System.Drawing.Point(601, 129)
        Me.cboSafetyDevices.Name = "cboSafetyDevices"
        Me.cboSafetyDevices.Size = New System.Drawing.Size(188, 21)
        Me.cboSafetyDevices.TabIndex = 6
        '
        'cboOperation
        '
        Me.cboOperation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOperation.Location = New System.Drawing.Point(601, 99)
        Me.cboOperation.Name = "cboOperation"
        Me.cboOperation.Size = New System.Drawing.Size(188, 21)
        Me.cboOperation.TabIndex = 5
        '
        'cboPressureTest
        '
        Me.cboPressureTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPressureTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPressureTest.Location = New System.Drawing.Point(601, 69)
        Me.cboPressureTest.Name = "cboPressureTest"
        Me.cboPressureTest.Size = New System.Drawing.Size(188, 21)
        Me.cboPressureTest.TabIndex = 4
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
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(3, 372)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(101, 13)
        Me.Label46.TabIndex = 348
        Me.Label46.Text = "Appliance safety"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(3, 342)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(181, 13)
        Me.Label47.TabIndex = 347
        Me.Label47.Text = "Appliance service or inspected"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(3, 312)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(42, 13)
        Me.Label55.TabIndex = 346
        Me.Label55.Text = "Glycol"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(3, 282)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(106, 13)
        Me.Label56.TabIndex = 345
        Me.Label56.Text = "Overall Condition"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(3, 251)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(102, 13)
        Me.Label57.TabIndex = 344
        Me.Label57.Text = "Legionella active"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(3, 221)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(143, 13)
        Me.Label58.TabIndex = 343
        Me.Label58.Text = "Safety device operation"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(3, 191)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(52, 13)
        Me.Label59.TabIndex = 342
        Me.Label59.Text = "Free Air"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(3, 162)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(53, 13)
        Me.Label60.TabIndex = 341
        Me.Label60.Text = "Stability"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(3, 132)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(91, 13)
        Me.Label61.TabIndex = 340
        Me.Label61.Text = "Safety devices"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(3, 102)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(63, 13)
        Me.Label62.TabIndex = 339
        Me.Label62.Text = "Operation"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(3, 72)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(84, 13)
        Me.Label63.TabIndex = 338
        Me.Label63.Text = "Pressure Test"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(3, 43)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(125, 13)
        Me.Label65.TabIndex = 336
        Me.Label65.Text = "Landlords Appliance "
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
        'cboGlycol
        '
        Me.cboGlycol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboGlycol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGlycol.Location = New System.Drawing.Point(601, 307)
        Me.cboGlycol.Name = "cboGlycol"
        Me.cboGlycol.Size = New System.Drawing.Size(188, 21)
        Me.cboGlycol.TabIndex = 12
        '
        'cboCondition
        '
        Me.cboCondition.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.Location = New System.Drawing.Point(601, 277)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(188, 21)
        Me.cboCondition.TabIndex = 11
        '
        'cboLegionella
        '
        Me.cboLegionella.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLegionella.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLegionella.Location = New System.Drawing.Point(601, 248)
        Me.cboLegionella.Name = "cboLegionella"
        Me.cboLegionella.Size = New System.Drawing.Size(188, 21)
        Me.cboLegionella.TabIndex = 10
        '
        'lblNotTested10
        '
        Me.lblNotTested10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested10.AutoSize = True
        Me.lblNotTested10.Location = New System.Drawing.Point(660, 341)
        Me.lblNotTested10.Name = "lblNotTested10"
        Me.lblNotTested10.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested10.TabIndex = 406
        Me.lblNotTested10.Text = "Not Tested"
        '
        'lblNotTested9
        '
        Me.lblNotTested9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested9.AutoSize = True
        Me.lblNotTested9.Location = New System.Drawing.Point(660, 311)
        Me.lblNotTested9.Name = "lblNotTested9"
        Me.lblNotTested9.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested9.TabIndex = 405
        Me.lblNotTested9.Text = "Not Tested"
        '
        'lblNotTested8
        '
        Me.lblNotTested8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested8.AutoSize = True
        Me.lblNotTested8.Location = New System.Drawing.Point(660, 281)
        Me.lblNotTested8.Name = "lblNotTested8"
        Me.lblNotTested8.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested8.TabIndex = 404
        Me.lblNotTested8.Text = "Not Tested"
        '
        'lblNotTested7
        '
        Me.lblNotTested7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested7.AutoSize = True
        Me.lblNotTested7.Location = New System.Drawing.Point(660, 251)
        Me.lblNotTested7.Name = "lblNotTested7"
        Me.lblNotTested7.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested7.TabIndex = 403
        Me.lblNotTested7.Text = "Not Tested"
        '
        'lblNotTested6
        '
        Me.lblNotTested6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested6.AutoSize = True
        Me.lblNotTested6.Location = New System.Drawing.Point(660, 222)
        Me.lblNotTested6.Name = "lblNotTested6"
        Me.lblNotTested6.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested6.TabIndex = 402
        Me.lblNotTested6.Text = "Not Tested"
        '
        'lblNotTested5
        '
        Me.lblNotTested5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested5.AutoSize = True
        Me.lblNotTested5.Location = New System.Drawing.Point(660, 192)
        Me.lblNotTested5.Name = "lblNotTested5"
        Me.lblNotTested5.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested5.TabIndex = 401
        Me.lblNotTested5.Text = "Not Tested"
        '
        'lblNotTested4
        '
        Me.lblNotTested4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested4.AutoSize = True
        Me.lblNotTested4.Location = New System.Drawing.Point(660, 162)
        Me.lblNotTested4.Name = "lblNotTested4"
        Me.lblNotTested4.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested4.TabIndex = 400
        Me.lblNotTested4.Text = "Not Tested"
        '
        'lblNotTested3
        '
        Me.lblNotTested3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested3.AutoSize = True
        Me.lblNotTested3.Location = New System.Drawing.Point(660, 132)
        Me.lblNotTested3.Name = "lblNotTested3"
        Me.lblNotTested3.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested3.TabIndex = 399
        Me.lblNotTested3.Text = "Not Tested"
        '
        'lblNotTested2
        '
        Me.lblNotTested2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested2.AutoSize = True
        Me.lblNotTested2.Location = New System.Drawing.Point(660, 102)
        Me.lblNotTested2.Name = "lblNotTested2"
        Me.lblNotTested2.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested2.TabIndex = 398
        Me.lblNotTested2.Text = "Not Tested"
        '
        'lblNotTested1
        '
        Me.lblNotTested1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNotTested1.AutoSize = True
        Me.lblNotTested1.Location = New System.Drawing.Point(660, 72)
        Me.lblNotTested1.Name = "lblNotTested1"
        Me.lblNotTested1.Size = New System.Drawing.Size(67, 13)
        Me.lblNotTested1.TabIndex = 397
        Me.lblNotTested1.Text = "Not Tested"
        '
        'UCASHPWorksheet
        '
        Me.Controls.Add(Me.cboGlycol)
        Me.Controls.Add(Me.cboCondition)
        Me.Controls.Add(Me.cboLegionella)
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
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.cboSafety)
        Me.Controls.Add(Me.cboServiced)
        Me.Controls.Add(Me.cboSafetyDeviceOperation)
        Me.Controls.Add(Me.cboVentilation)
        Me.Controls.Add(Me.cboStability)
        Me.Controls.Add(Me.cboSafetyDevices)
        Me.Controls.Add(Me.cboOperation)
        Me.Controls.Add(Me.cboPressureTest)
        Me.Controls.Add(Me.cboLLAppliance)
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
        Me.Name = "UCASHPWorksheet"
        Me.Size = New System.Drawing.Size(789, 407)
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
        Combo.SetUpCombo(Me.cboLLAppliance, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.LLTenPriv).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAppliance, DB.JobAsset.JobAsset_Get_For_Job(JobID).Table, "AssetID", "AssetDescriptionWithLocation", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPressureTest, DtNotTestedPassFail, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboOperation, DtNotTestedPassFail, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSafetyDevices, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboStability, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboVentilation, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSafetyDeviceOperation, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboServiced, DtApplianceServiced, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSafety, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        cboSafety.Items.Add(New Combo("Visually Passed", "999999999"))

        Combo.SetUpCombo(Me.cboGlycol, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboLegionella, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboCondition, DtPassFailNa, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate
        Combo.SetSelectedComboItem_By_Value(Me.cboAppliance, Worksheet.AssetID)
        Combo.SetSelectedComboItem_By_Value(Me.cboPressureTest, Worksheet.FlueFlowTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboOperation, Worksheet.SpillageTestID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSafetyDevices, Worksheet.FlueTerminationSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboStability, Worksheet.VisualConditionOfFlueSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboVentilation, Worksheet.VentilationProvisionSatisfactoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSafetyDeviceOperation, Worksheet.SafetyDeviceOperationID)
        Combo.SetSelectedComboItem_By_Value(Me.cboServiced, Worksheet.ApplianceServiceOrInspectedID)
        Combo.SetSelectedComboItem_By_Value(Me.cboSafety, Worksheet.ApplianceSafeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboLLAppliance, Worksheet.LandlordsApplianceID)
        Combo.SetSelectedComboItem_By_Value(Me.cboGlycol, Worksheet.DischargeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboLegionella, Worksheet.SweepOutcomeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboCondition, Worksheet.OverallID)

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            Worksheet.SetReading = CInt(Enums.WorksheetFuelTypes.ASHP)

            Worksheet.SetAssetID = Combo.GetSelectedItemValue(Me.cboAppliance)
            Worksheet.SetLandlordsApplianceID = Combo.GetSelectedItemValue(Me.cboLLAppliance)
            Worksheet.SetFlueFlowTestID = Combo.GetSelectedItemValue(Me.cboPressureTest)
            Worksheet.SetSpillageTestID = Combo.GetSelectedItemValue(Me.cboOperation)
            Worksheet.SetFlueTerminationSatisfactoryID = Combo.GetSelectedItemValue(Me.cboSafetyDevices)
            Worksheet.SetVisualConditionOfFlueSatisfactoryID = Combo.GetSelectedItemValue(Me.cboStability)
            Worksheet.SetVentilationProvisionSatisfactoryID = Combo.GetSelectedItemValue(Me.cboVentilation)
            Worksheet.SetSafetyDeviceOperationID = Combo.GetSelectedItemValue(Me.cboSafetyDeviceOperation)
            Worksheet.SetSweepOutcomeID = Combo.GetSelectedItemValue(Me.cboLegionella)
            Worksheet.SetOverallID = Combo.GetSelectedItemValue(Me.cboCondition)
            Worksheet.SetDischargeID = Combo.GetSelectedItemValue(Me.cboGlycol)


            Worksheet.SetApplianceServiceOrInspectedID = Combo.GetSelectedItemValue(Me.cboServiced)

            Worksheet.SetApplianceSafeID = Combo.GetSelectedItemValue(Me.cboSafety)

            Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID

            Dim dValidator As New EngineerVisitAssetWorkSheetValidatorASHP
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

