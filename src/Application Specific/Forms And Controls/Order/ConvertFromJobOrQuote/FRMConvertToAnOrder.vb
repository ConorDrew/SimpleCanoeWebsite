Public Class FRMConvertToAnOrder : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboChargeType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.OrderChargeTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

    End Sub

    Public Sub New(ByVal trans As SqlClient.SqlTransaction)
        MyBase.New()

        Me.Trans = trans

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents grpJob As System.Windows.Forms.GroupBox
    Friend WithEvents dgEngineerVisits As System.Windows.Forms.DataGrid
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpPartsAndProducts As System.Windows.Forms.GroupBox
    Friend WithEvents dgPartsAndProducts As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents btnAddPart As System.Windows.Forms.Button
    Friend WithEvents lblinformation As System.Windows.Forms.Label
    Friend WithEvents chkAwaiting As System.Windows.Forms.CheckBox
    Friend WithEvents chkConfirmed As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDeadline As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grpCharges As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnChargesSave As System.Windows.Forms.Button
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboChargeType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgCharges As System.Windows.Forms.DataGrid
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents chkDoNotConsolidate As System.Windows.Forms.CheckBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJob = New System.Windows.Forms.GroupBox
        Me.dgEngineerVisits = New System.Windows.Forms.DataGrid
        Me.grpPartsAndProducts = New System.Windows.Forms.GroupBox
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.dgPartsAndProducts = New System.Windows.Forms.DataGrid
        Me.btnAddProduct = New System.Windows.Forms.Button
        Me.btnAddPart = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblinformation = New System.Windows.Forms.Label
        Me.chkAwaiting = New System.Windows.Forms.CheckBox
        Me.chkConfirmed = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpDeadline = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grpCharges = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnChargesSave = New System.Windows.Forms.Button
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboChargeType = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgCharges = New System.Windows.Forms.DataGrid
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.chkDoNotConsolidate = New System.Windows.Forms.CheckBox
        Me.grpJob.SuspendLayout()
        CType(Me.dgEngineerVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPartsAndProducts.SuspendLayout()
        CType(Me.dgPartsAndProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.grpCharges.SuspendLayout()
        CType(Me.dgCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpJob
        '
        Me.grpJob.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJob.Controls.Add(Me.dgEngineerVisits)
        Me.grpJob.Location = New System.Drawing.Point(8, 40)
        Me.grpJob.Name = "grpJob"
        Me.grpJob.Size = New System.Drawing.Size(976, 152)
        Me.grpJob.TabIndex = 1
        Me.grpJob.TabStop = False
        Me.grpJob.Text = "More than one engineer visit exists for this job, please select the visit to assi" & _
            "gn this order to and click OK"
        '
        'dgEngineerVisits
        '
        Me.dgEngineerVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgEngineerVisits.DataMember = ""
        Me.dgEngineerVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEngineerVisits.Location = New System.Drawing.Point(8, 30)
        Me.dgEngineerVisits.Name = "dgEngineerVisits"
        Me.dgEngineerVisits.Size = New System.Drawing.Size(960, 114)
        Me.dgEngineerVisits.TabIndex = 1
        '
        'grpPartsAndProducts
        '
        Me.grpPartsAndProducts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPartsAndProducts.Controls.Add(Me.btnExport)
        Me.grpPartsAndProducts.Controls.Add(Me.btnRemove)
        Me.grpPartsAndProducts.Controls.Add(Me.dgPartsAndProducts)
        Me.grpPartsAndProducts.Controls.Add(Me.btnAddProduct)
        Me.grpPartsAndProducts.Controls.Add(Me.btnAddPart)
        Me.grpPartsAndProducts.Location = New System.Drawing.Point(0, 0)
        Me.grpPartsAndProducts.Name = "grpPartsAndProducts"
        Me.grpPartsAndProducts.Size = New System.Drawing.Size(968, 275)
        Me.grpPartsAndProducts.TabIndex = 2
        Me.grpPartsAndProducts.TabStop = False
        Me.grpPartsAndProducts.Text = "Parts && Products"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(198, 243)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(88, 23)
        Me.btnExport.TabIndex = 9
        Me.btnExport.Text = "Export"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(788, 241)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(164, 23)
        Me.btnRemove.TabIndex = 8
        Me.btnRemove.Text = "Remove Part / Product"
        '
        'dgPartsAndProducts
        '
        Me.dgPartsAndProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPartsAndProducts.DataMember = ""
        Me.dgPartsAndProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPartsAndProducts.Location = New System.Drawing.Point(8, 20)
        Me.dgPartsAndProducts.Name = "dgPartsAndProducts"
        Me.dgPartsAndProducts.Size = New System.Drawing.Size(952, 215)
        Me.dgPartsAndProducts.TabIndex = 3
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddProduct.Location = New System.Drawing.Point(104, 243)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(88, 23)
        Me.btnAddProduct.TabIndex = 6
        Me.btnAddProduct.Text = "Add Product"
        '
        'btnAddPart
        '
        Me.btnAddPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddPart.Location = New System.Drawing.Point(8, 243)
        Me.btnAddPart.Name = "btnAddPart"
        Me.btnAddPart.Size = New System.Drawing.Size(88, 23)
        Me.btnAddPart.TabIndex = 7
        Me.btnAddPart.Text = "Add Part"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(928, 536)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 536)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'lblinformation
        '
        Me.lblinformation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblinformation.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblinformation.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinformation.Location = New System.Drawing.Point(328, 536)
        Me.lblinformation.Name = "lblinformation"
        Me.lblinformation.Size = New System.Drawing.Size(600, 24)
        Me.lblinformation.TabIndex = 8
        Me.lblinformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkAwaiting
        '
        Me.chkAwaiting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAwaiting.AutoSize = True
        Me.chkAwaiting.Location = New System.Drawing.Point(91, 508)
        Me.chkAwaiting.Name = "chkAwaiting"
        Me.chkAwaiting.Size = New System.Drawing.Size(152, 17)
        Me.chkAwaiting.TabIndex = 9
        Me.chkAwaiting.Text = "Awaiting Confirmation"
        Me.chkAwaiting.UseVisualStyleBackColor = True
        '
        'chkConfirmed
        '
        Me.chkConfirmed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkConfirmed.AutoSize = True
        Me.chkConfirmed.Location = New System.Drawing.Point(249, 508)
        Me.chkConfirmed.Name = "chkConfirmed"
        Me.chkConfirmed.Size = New System.Drawing.Size(86, 17)
        Me.chkConfirmed.TabIndex = 10
        Me.chkConfirmed.Text = "Confirmed"
        Me.chkConfirmed.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 508)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Order Status"
        '
        'dtpDeadline
        '
        Me.dtpDeadline.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpDeadline.CustomFormat = "dddd dd MMMM yyyy"
        Me.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeadline.Location = New System.Drawing.Point(456, 508)
        Me.dtpDeadline.Name = "dtpDeadline"
        Me.dtpDeadline.Size = New System.Drawing.Size(244, 21)
        Me.dtpDeadline.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(341, 509)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Delivery Deadline"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 198)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(976, 304)
        Me.TabControl1.TabIndex = 14
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grpPartsAndProducts)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(968, 278)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Parts & Products"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grpCharges)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(968, 278)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Charges"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grpCharges
        '
        Me.grpCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCharges.Controls.Add(Me.btnDelete)
        Me.grpCharges.Controls.Add(Me.btnChargesSave)
        Me.grpCharges.Controls.Add(Me.txtAmount)
        Me.grpCharges.Controls.Add(Me.Label3)
        Me.grpCharges.Controls.Add(Me.cboChargeType)
        Me.grpCharges.Controls.Add(Me.Label4)
        Me.grpCharges.Controls.Add(Me.dgCharges)
        Me.grpCharges.Location = New System.Drawing.Point(6, 0)
        Me.grpCharges.Name = "grpCharges"
        Me.grpCharges.Size = New System.Drawing.Size(956, 272)
        Me.grpCharges.TabIndex = 3
        Me.grpCharges.TabStop = False
        Me.grpCharges.Text = "Charges"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(884, 208)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Remove"
        '
        'btnChargesSave
        '
        Me.btnChargesSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChargesSave.Location = New System.Drawing.Point(884, 240)
        Me.btnChargesSave.Name = "btnChargesSave"
        Me.btnChargesSave.Size = New System.Drawing.Size(64, 23)
        Me.btnChargesSave.TabIndex = 4
        Me.btnChargesSave.Text = "Add"
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.Location = New System.Drawing.Point(804, 240)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(72, 21)
        Me.txtAmount.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(740, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Amount:"
        '
        'cboChargeType
        '
        Me.cboChargeType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboChargeType.Location = New System.Drawing.Point(96, 240)
        Me.cboChargeType.Name = "cboChargeType"
        Me.cboChargeType.Size = New System.Drawing.Size(636, 21)
        Me.cboChargeType.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(8, 240)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Charge Type:"
        '
        'dgCharges
        '
        Me.dgCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCharges.DataMember = ""
        Me.dgCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCharges.Location = New System.Drawing.Point(8, 25)
        Me.dgCharges.Name = "dgCharges"
        Me.dgCharges.Size = New System.Drawing.Size(940, 175)
        Me.dgCharges.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(705, 508)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 20)
        Me.Label17.TabIndex = 70
        Me.Label17.Text = "Dept"
        '
        'txtDepartment
        '
        Me.txtDepartment.Location = New System.Drawing.Point(749, 511)
        Me.txtDepartment.MaxLength = 100
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(131, 21)
        Me.txtDepartment.TabIndex = 69
        Me.txtDepartment.Tag = ""
        '
        'chkDoNotConsolidate
        '
        Me.chkDoNotConsolidate.AutoSize = True
        Me.chkDoNotConsolidate.Location = New System.Drawing.Point(91, 540)
        Me.chkDoNotConsolidate.Name = "chkDoNotConsolidate"
        Me.chkDoNotConsolidate.Size = New System.Drawing.Size(136, 17)
        Me.chkDoNotConsolidate.TabIndex = 71
        Me.chkDoNotConsolidate.Text = "Do Not Consolidate"
        Me.chkDoNotConsolidate.UseVisualStyleBackColor = True
        '
        'FRMConvertToAnOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(992, 566)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkDoNotConsolidate)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtDepartment)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpDeadline)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkConfirmed)
        Me.Controls.Add(Me.chkAwaiting)
        Me.Controls.Add(Me.lblinformation)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpJob)
        Me.Name = "FRMConvertToAnOrder"
        Me.Text = "Convert to an order"
        Me.Controls.SetChildIndex(Me.grpJob, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.lblinformation, 0)
        Me.Controls.SetChildIndex(Me.chkAwaiting, 0)
        Me.Controls.SetChildIndex(Me.chkConfirmed, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dtpDeadline, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.txtDepartment, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.chkDoNotConsolidate, 0)
        Me.grpJob.ResumeLayout(False)
        CType(Me.dgEngineerVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPartsAndProducts.ResumeLayout(False)
        CType(Me.dgPartsAndProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.grpCharges.ResumeLayout(False)
        Me.grpCharges.PerformLayout()
        CType(Me.dgCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        Me.chkAwaiting.Checked = True
        Me.dtpDeadline.Value = Now

        OrderType = GetParameter(0)

        Select Case OrderType
            Case Entity.Sys.Enums.OrderType.Job
                Me.Size = New Size(1000, 600)
                Me.MinimumSize = New Size(1000, 600)
                Me.Height = 608
                Me.grpPartsAndProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                     Or System.Windows.Forms.AnchorStyles.Left) _
                                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                EngineerVisitID = GetParameter(4)
                NeedsTransaction = GetParameter(5)
                If EngineerVisitID > 0 Then

                    If Not Trans Is Nothing Then
                        EngineerVisitsDataView = DB.EngineerVisits.EngineerVisits_Get(EngineerVisitID, Trans)
                    Else
                        EngineerVisitsDataView = DB.EngineerVisits.EngineerVisits_Get(EngineerVisitID)
                    End If

                    PartsAndProducts = GetParameter(2)
                    grpJob.Text = "Visit Information"
                Else
                    ID = GetParameter(1)
                    If Not Trans Is Nothing Then
                        EngineerVisitsDataView = DB.EngineerVisits.EngineerVisits_Get_All_JobID(ID, Trans)
                    Else
                        EngineerVisitsDataView = DB.EngineerVisits.EngineerVisits_Get_All_JobID(ID)
                    End If

                    PartsAndProducts = GetParameter(2)
                End If

                RefreshDatagrid()

            Case Entity.Sys.Enums.OrderType.Customer
                Me.Size = New Size(1000, 448)
                Me.MinimumSize = New Size(1000, 448)
                Me.Height = 448
                Me.grpPartsAndProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                 Or System.Windows.Forms.AnchorStyles.Left) _
                 Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                PartsAndProducts = GetParameter(2)
                QuoteOrder = GetParameter(3)
        End Select

        Application.DoEvents()
        LoadForm(sender, e, Me)

        SetupVisitsDataGrid()
        SetupPartsAndProductsDataGrid()
        SetupChargesDatagrid()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        ID = newID
    End Sub

#End Region

#Region "Properties"

    Private _Trans As SqlClient.SqlTransaction
    Public Property Trans() As SqlClient.SqlTransaction
        Get
            Return _Trans
        End Get
        Set(ByVal value As SqlClient.SqlTransaction)
            _Trans = value
        End Set
    End Property

    Private m_dTable2 As DataView = Nothing
    Public Property PriceRequestItemsDataView() As DataView
        Get
            Return m_dTable2
        End Get
        Set(ByVal Value As DataView)
            m_dTable2 = Value
        End Set
    End Property

    Private _QuoteOrder As Entity.QuoteOrders.QuoteOrder
    Public Property QuoteOrder() As Entity.QuoteOrders.QuoteOrder
        Get
            Return _QuoteOrder
        End Get
        Set(ByVal Value As Entity.QuoteOrders.QuoteOrder)
            _QuoteOrder = Value

            If Not QuoteOrder Is Nothing Then
                Me.dtpDeadline.Value = QuoteOrder.DeliveryDeadline
            End If
        End Set
    End Property

    Private _OrderType As Entity.Sys.Enums.OrderType
    Public Property OrderType() As Entity.Sys.Enums.OrderType
        Get
            Return _OrderType
        End Get
        Set(ByVal Value As Entity.Sys.Enums.OrderType)
            _OrderType = Value
        End Set
    End Property

    Private _ID As Integer = 0
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property

    Private _EngineerVisitID As Integer = 0
    Public Property EngineerVisitID() As Integer
        Get
            Return _EngineerVisitID
        End Get
        Set(ByVal Value As Integer)
            _EngineerVisitID = Value
        End Set
    End Property

    Private _EngineerVisitsDataView As DataView = Nothing
    Public Property EngineerVisitsDataView() As DataView
        Get
            Return _EngineerVisitsDataView
        End Get
        Set(ByVal Value As DataView)
            Value.Table.AcceptChanges()
            Value.Table.Columns.Add(New DataColumn("VisitCount"))

            Dim i As Integer = 1
            For Each row As DataRow In Value.Table.Rows
                row.Item("VisitCount") = i
                i += 1
            Next

            _EngineerVisitsDataView = Value
            _EngineerVisitsDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
            _EngineerVisitsDataView.AllowNew = False
            _EngineerVisitsDataView.AllowEdit = False
            _EngineerVisitsDataView.AllowDelete = False
            Me.dgEngineerVisits.DataSource = EngineerVisitsDataView
        End Set
    End Property

    Public ReadOnly Property SelectedEngineerVisitDataRow() As DataRow
        Get
            If Not Me.dgEngineerVisits.CurrentRowIndex = -1 Then
                Return EngineerVisitsDataView(Me.dgEngineerVisits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _PartsAndProducts As DataView = Nothing
    Public Property PartsAndProducts() As DataView
        Get
            Return _PartsAndProducts
        End Get
        Set(ByVal Value As DataView)
            Value.Table.AcceptChanges()
            Value.Table.Columns.Add(New DataColumn("SupplierID"))
            Value.Table.Columns.Add(New DataColumn("QuantityToOrder"))
            Value.Table.Columns.Add(New DataColumn("GetFrom"))
            Value.Table.Columns.Add(New DataColumn("GetFromText"))
            Value.Table.Columns.Add(New DataColumn("GetID"))
            Value.Table.Columns.Add(New DataColumn("BuyPrice", System.Type.GetType("System.Double")))
            Value.Table.Columns.Add(New DataColumn("VisitCount"))
            Value.Table.Columns.Add(New DataColumn("Shelf"))
            Value.Table.Columns.Add(New DataColumn("Bin"))
            'If EngineerVisitID > 0 Then
            '    Value.Table.Columns.Add(New DataColumn("SellPrice"))
            'End If

            Value.Table.AcceptChanges()

            For Each row As DataRow In Value.Table.Rows
                Dim dt As DataTable

                If CStr(row.Item("type")).ToUpper = "PART" Then
                    If Not Trans Is Nothing Then
                        dt = DB.Part.Stock_Get_Locations(row.Item("PartProductID"), Trans).Table
                    Else
                        dt = DB.Part.Stock_Get_Locations(row.Item("PartProductID")).Table
                    End If
                Else
                    If Not Trans Is Nothing Then
                        dt = DB.Product.Stock_Get_Locations(row.Item("PartProductID"), Trans).Table
                    Else
                        dt = DB.Product.Stock_Get_Locations(row.Item("PartProductID")).Table
                    End If
                End If

                Dim warehouseID As Integer = 0
                Dim locationID As Integer = 0
                Dim shelf As String = ""
                Dim bin As String = ""

                For Each partProductRow As DataRow In dt.Rows
                    If partProductRow.Item("Type") = "WAREHOUSE" Then
                        If partProductRow.Item("Quantity") >= row.Item("quantity") Then
                            warehouseID = partProductRow.Item("WarehouseID")
                            locationID = partProductRow.Item("LocationID")
                            shelf = partProductRow.Item("Shelf")
                            bin = partProductRow.Item("Bin")
                            Exit For
                        End If
                    End If
                Next

                If Not warehouseID = 0 Then
                    row.Item("QuantityToOrder") = row.Item("quantity")
                    row.Item("GetFrom") = 3
                    If Not Trans Is Nothing Then
                        row.Item("GetFromText") = DB.Warehouse.Warehouse_Get(warehouseID, Trans).Name
                    Else
                        row.Item("GetFromText") = DB.Warehouse.Warehouse_Get(warehouseID).Name
                    End If
                    row.Item("GetID") = locationID
                    row.Item("BuyPrice") = 0
                    row.Item("Shelf") = shelf
                    row.Item("Bin") = bin
                End If
            Next

            _PartsAndProducts = Value
            _PartsAndProducts.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
            _PartsAndProducts.AllowNew = False
            _PartsAndProducts.AllowEdit = True
            _PartsAndProducts.AllowDelete = False
            Me.dgPartsAndProducts.DataSource = PartsAndProducts
        End Set
    End Property

    Public ReadOnly Property SelectedPartProductDataRow() As DataRow
        Get
            If Not Me.dgPartsAndProducts.CurrentRowIndex = -1 Then
                Return PartsAndProducts(Me.dgPartsAndProducts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _NeedsTransaction As Boolean = False
    Public Property NeedsTransaction() As Boolean
        Get
            Return _NeedsTransaction
        End Get
        Set(ByVal value As Boolean)
            _NeedsTransaction = value
        End Set
    End Property

    Private _ChargesDataView As DataView = Nothing
    Public Property ChargesDataView() As DataView
        Get
            Return _ChargesDataView
        End Get
        Set(ByVal Value As DataView)
            _ChargesDataView = Value
            _ChargesDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString
            _ChargesDataView.AllowNew = False
            _ChargesDataView.AllowEdit = False
            _ChargesDataView.AllowDelete = False
            Me.dgCharges.DataSource = ChargesDataView
        End Set
    End Property

    Private ReadOnly Property SelectedChargeDataRow() As DataRow
        Get
            If Not Me.dgCharges.CurrentRowIndex = -1 Then
                Return ChargesDataView(Me.dgCharges.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _PageState As Entity.Sys.Enums.FormState = Entity.Sys.Enums.FormState.Insert
    Public Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _PageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _PageState = Value

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    Me.btnSave.Text = "Add"
                Case Entity.Sys.Enums.FormState.Update
                    Me.btnSave.Text = "Update"
            End Select

            Me.txtAmount.Text = ""
            Combo.SetSelectedComboItem_By_Value(Me.cboChargeType, 0)
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub SetupVisitsDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgEngineerVisits)
        Dim tbStyle As DataGridTableStyle = Me.dgEngineerVisits.TableStyles(0)

        tbStyle.GridColumnStyles.Clear()

        Dim VisitCount As New DataGridLabelColumn
        VisitCount.Format = ""
        VisitCount.FormatInfo = Nothing
        VisitCount.HeaderText = "#"
        VisitCount.MappingName = "VisitCount"
        VisitCount.ReadOnly = True
        VisitCount.Width = 50
        VisitCount.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitCount)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 150
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 150
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 75
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim PONumber As New DataGridLabelColumn
        PONumber.Format = ""
        PONumber.FormatInfo = Nothing
        PONumber.HeaderText = "PO Number"
        PONumber.MappingName = "PONumber"
        PONumber.ReadOnly = True
        PONumber.Width = 75
        PONumber.NullText = ""
        tbStyle.GridColumnStyles.Add(PONumber)

        Dim JobDefinition As New DataGridLabelColumn
        JobDefinition.Format = ""
        JobDefinition.FormatInfo = Nothing
        JobDefinition.HeaderText = "Definition"
        JobDefinition.MappingName = "JobDefinition"
        JobDefinition.ReadOnly = True
        JobDefinition.Width = 75
        JobDefinition.NullText = ""
        tbStyle.GridColumnStyles.Add(JobDefinition)

        Dim NotesToEngineer As New DataGridLabelColumn
        NotesToEngineer.Format = ""
        NotesToEngineer.FormatInfo = Nothing
        NotesToEngineer.HeaderText = "Notes To Engineer"
        NotesToEngineer.MappingName = "NotesToEngineer"
        NotesToEngineer.ReadOnly = True
        NotesToEngineer.Width = 75
        NotesToEngineer.NullText = ""
        tbStyle.GridColumnStyles.Add(NotesToEngineer)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        tbStyle.GridColumnStyles.Add(Type)

        Dim VisitStatus As New DataGridLabelColumn
        VisitStatus.Format = ""
        VisitStatus.FormatInfo = Nothing
        VisitStatus.HeaderText = "Status"
        VisitStatus.MappingName = "VisitStatus"
        VisitStatus.ReadOnly = True
        VisitStatus.Width = 75
        VisitStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitStatus)

        Dim VisitDate As New DataGridLabelColumn
        VisitDate.Format = "dd/MMM/yyyy"
        VisitDate.FormatInfo = Nothing
        VisitDate.HeaderText = "Date"
        VisitDate.MappingName = "startdatetime"
        VisitDate.ReadOnly = True
        VisitDate.Width = 100
        VisitDate.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(VisitDate)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
        Me.dgEngineerVisits.TableStyles.Add(tbStyle)
    End Sub

    Public Sub SetupPartsAndProductsDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgPartsAndProducts)
        Dim tStyle As DataGridTableStyle = Me.dgPartsAndProducts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgPartsAndProducts.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim type As New DataGridLabelColumn
        type.Format = ""
        type.FormatInfo = Nothing
        type.HeaderText = "Type"
        type.MappingName = "type"
        type.ReadOnly = True
        type.Width = 75
        type.NullText = ""
        tStyle.GridColumnStyles.Add(type)

        Dim number As New DataGridLabelColumn
        number.Format = ""
        number.FormatInfo = Nothing
        number.HeaderText = "Number"
        number.MappingName = "number"
        number.ReadOnly = True
        number.Width = 120
        number.NullText = ""
        tStyle.GridColumnStyles.Add(number)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 130
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        If Not Trans Is Nothing Then
            Dim GetFrom As New DataGridComboBoxColumn(Trans, True)
            GetFrom.HeaderText = "Get From (Select)"
            GetFrom.MappingName = "GetFrom"
            GetFrom.ReadOnly = False
            GetFrom.Width = 150
            'no actual DB call so doesnt need tran
            GetFrom.ComboBox.DataSource = DB.Order.Get_All_Places_Item_Can_Be_Got_From().Table
            GetFrom.ComboBox.DisplayMember = "DisplayMember"
            GetFrom.ComboBox.ValueMember = "ValueMember"
            AddHandler GetFrom.itemSelected, AddressOf ItemSelected
            tStyle.GridColumnStyles.Add(GetFrom)
        Else
            Dim GetFrom As New DataGridComboBoxColumn(True)
            GetFrom.HeaderText = "Get From (Select)"
            GetFrom.MappingName = "GetFrom"
            GetFrom.ReadOnly = False
            GetFrom.Width = 150
            'no actual DB call so doesnt need tran
            GetFrom.ComboBox.DataSource = DB.Order.Get_All_Places_Item_Can_Be_Got_From().Table
            GetFrom.ComboBox.DisplayMember = "DisplayMember"
            GetFrom.ComboBox.ValueMember = "ValueMember"
            AddHandler GetFrom.itemSelected, AddressOf ItemSelected
            tStyle.GridColumnStyles.Add(GetFrom)
        End If

        Dim GetFromText As New DataGridLabelColumn
        GetFromText.Format = ""
        GetFromText.FormatInfo = Nothing
        GetFromText.HeaderText = "From"
        GetFromText.MappingName = "GetFromText"
        GetFromText.ReadOnly = True
        GetFromText.Width = 130
        GetFromText.NullText = ""
        tStyle.GridColumnStyles.Add(GetFromText)

        Dim Shelf As New DataGridLabelColumn
        Shelf.Format = ""
        Shelf.FormatInfo = Nothing
        Shelf.HeaderText = "Shelf"
        Shelf.MappingName = "Shelf"
        Shelf.ReadOnly = True
        Shelf.Width = 75
        Shelf.NullText = ""
        tStyle.GridColumnStyles.Add(Shelf)

        Dim Bin As New DataGridLabelColumn
        Bin.Format = ""
        Bin.FormatInfo = Nothing
        Bin.HeaderText = "Bin"
        Bin.MappingName = "Bin"
        Bin.ReadOnly = True
        Bin.Width = 100
        Bin.NullText = ""
        tStyle.GridColumnStyles.Add(Bin)

        Dim BuyPrice As New DataGridEditableTextBoxColumn
        BuyPrice.Format = "C"
        BuyPrice.FormatInfo = Nothing
        BuyPrice.HeaderText = "Pack/Unit Buy Price"
        BuyPrice.MappingName = "BuyPrice"
        BuyPrice.ReadOnly = False
        BuyPrice.Width = 105
        BuyPrice.NullText = ""
        tStyle.GridColumnStyles.Add(BuyPrice)

        Dim Sellprice As New DataGridEditableTextBoxColumn
        Sellprice.Format = "C"
        Sellprice.FormatInfo = Nothing
        Sellprice.HeaderText = "Unit Sell Price"
        Sellprice.MappingName = "Sellprice"
        Sellprice.ReadOnly = False
        Sellprice.Width = 100
        Sellprice.NullText = ""
        tStyle.GridColumnStyles.Add(Sellprice)

        Dim quantity As New DataGridLabelColumn
        quantity.Format = ""
        quantity.FormatInfo = Nothing
        quantity.HeaderText = "Qty Needed"
        quantity.MappingName = "quantity"
        quantity.ReadOnly = False
        quantity.Width = 100
        quantity.NullText = ""
        tStyle.GridColumnStyles.Add(quantity)

        Dim quantityToOrder As New DataGridEditableTextBoxColumn
        quantityToOrder.Format = ""
        quantityToOrder.FormatInfo = Nothing
        quantityToOrder.HeaderText = "Qty Packs/Units to Order"
        quantityToOrder.MappingName = "QuantityToOrder"
        If EngineerVisitID > 0 Then
            quantityToOrder.ReadOnly = True
        Else
            quantityToOrder.ReadOnly = False
        End If
        quantityToOrder.Width = 120
        quantityToOrder.NullText = ""
        tStyle.GridColumnStyles.Add(quantityToOrder)

        If OrderType = Entity.Sys.Enums.OrderType.Job And EngineerVisitID = 0 Then
            Dim VisitCount As New DataGridComboBoxColumn
            VisitCount.HeaderText = "Visit # (Select)"
            VisitCount.MappingName = "VisitCount"
            VisitCount.ReadOnly = False
            VisitCount.Width = 90
            VisitCount.ComboBox.DataSource = EngineerVisitsDataView.Table
            VisitCount.ComboBox.DisplayMember = "VisitCount"
            VisitCount.ComboBox.ValueMember = "VisitCount"
            VisitCount.ComboBox.SelectedValue = 1
            tStyle.GridColumnStyles.Add(VisitCount)
        End If

        tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
        Me.dgPartsAndProducts.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupChargesDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgCharges)
        Dim tStyle As DataGridTableStyle = Me.dgCharges.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim ChargeType As New DataGridLabelColumn
        ChargeType.Format = ""
        ChargeType.FormatInfo = Nothing
        ChargeType.HeaderText = "ChargeType"
        ChargeType.MappingName = "ChargeType"
        ChargeType.ReadOnly = True
        ChargeType.Width = 130
        ChargeType.NullText = "N/A"
        tStyle.GridColumnStyles.Add(ChargeType)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = "C"
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 130
        Amount.NullText = "N/A"
        tStyle.GridColumnStyles.Add(Amount)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString
        Me.dgCharges.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Functions"

    Public Sub ItemSelected()
        If Not CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID = 0 Then
            SelectedPartProductDataRow.Item("GetID") = CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID()

            Select Case CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).SearchingFor
                Case "Supplier"
                    If SelectedPartProductDataRow.Item("Type") = "Product" Then

                        Dim oProductSupplier As Entity.ProductSuppliers.ProductSupplier

                        If Not Trans Is Nothing Then
                            oProductSupplier = DB.ProductSupplier.ProductSupplier_Get(CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID, Trans)
                        Else
                            oProductSupplier = DB.ProductSupplier.ProductSupplier_Get(CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID)
                        End If

                        Dim oSupplier As Entity.Suppliers.Supplier

                        If Not Trans Is Nothing Then
                            oSupplier = DB.Supplier.Supplier_Get(oProductSupplier.SupplierID, Trans)
                        Else
                            oSupplier = DB.Supplier.Supplier_Get(oProductSupplier.SupplierID)
                        End If

                        SelectedPartProductDataRow.Item("BuyPrice") = oProductSupplier.Price
                        SelectedPartProductDataRow.Item("GetFromText") = oSupplier.Name
                        SelectedPartProductDataRow.Item("SupplierID") = oSupplier.SupplierID
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedPartProductDataRow.Item("Quantity")) = 0 Then
                            SelectedPartProductDataRow.Item("Quantity") = 1
                        End If
                        SelectedPartProductDataRow.Item("QuantityToOrder") = Math.Ceiling(SelectedPartProductDataRow.Item("Quantity") / oProductSupplier.QuantityInPack)
                        SelectedPartProductDataRow.Item("GetFrom") = 1
                        SelectedPartProductDataRow.Item("Shelf") = ""
                        SelectedPartProductDataRow.Item("Bin") = ""
                    Else
                        Dim oPartSupplier As Entity.PartSuppliers.PartSupplier
                        If Not Trans Is Nothing Then
                            oPartSupplier = DB.PartSupplier.PartSupplier_Get(CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID, Trans)
                        Else
                            oPartSupplier = DB.PartSupplier.PartSupplier_Get(CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID)
                        End If

                        Dim oSupplier As Entity.Suppliers.Supplier

                        If Not Trans Is Nothing Then
                            oSupplier = DB.Supplier.Supplier_Get(oPartSupplier.SupplierID, Trans)
                        Else
                            oSupplier = DB.Supplier.Supplier_Get(oPartSupplier.SupplierID)
                        End If

                        SelectedPartProductDataRow.Item("BuyPrice") = oPartSupplier.Price
                        SelectedPartProductDataRow.Item("GetFromText") = oSupplier.Name
                        SelectedPartProductDataRow.Item("SupplierID") = oSupplier.SupplierID
                        If Entity.Sys.Helper.MakeIntegerValid(SelectedPartProductDataRow.Item("Quantity")) = 0 Then
                            SelectedPartProductDataRow.Item("Quantity") = 1
                        End If
                        SelectedPartProductDataRow.Item("QuantityToOrder") = Math.Ceiling(SelectedPartProductDataRow.Item("Quantity") / oPartSupplier.QuantityInPack)
                        SelectedPartProductDataRow.Item("GetFrom") = 1
                        SelectedPartProductDataRow.Item("Shelf") = ""
                        SelectedPartProductDataRow.Item("Bin") = ""
                    End If
                Case "Van"
                    If Not Trans Is Nothing Then
                        SelectedPartProductDataRow.Item("GetFromText") = DB.Van.Van_GetByLocationID(CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID, Trans).Registration
                    Else
                        SelectedPartProductDataRow.Item("GetFromText") = DB.Van.Van_GetByLocationID(CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID).Registration
                    End If
                    SelectedPartProductDataRow.Item("BuyPrice") = 0
                    SelectedPartProductDataRow.Item("GetFrom") = 2
                    SelectedPartProductDataRow.Item("QuantityToOrder") = SelectedPartProductDataRow.Item("Quantity")
                    SelectedPartProductDataRow.Item("Shelf") = ""
                    SelectedPartProductDataRow.Item("Bin") = ""
                Case "Warehouse"
                    Dim dt As DataTable = Nothing

                    If Not Trans Is Nothing Then
                        Dim w As Entity.Warehouses.Warehouse = DB.Warehouse.Warehouse_GetByLocationID(CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID, Trans)
                        SelectedPartProductDataRow.Item("GetFromText") = w.Name
                        If CStr(SelectedPartProductDataRow.Item("type")).ToUpper = "PART" Then
                            dt = DB.Part.Stock_Get_Locations(SelectedPartProductDataRow.Item("PartProductID"), Trans).Table
                        End If
                    Else
                        Dim w As Entity.Warehouses.Warehouse = DB.Warehouse.Warehouse_GetByLocationID(CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ReturnID)
                        SelectedPartProductDataRow.Item("GetFromText") = w.Name
                        If CStr(SelectedPartProductDataRow.Item("type")).ToUpper = "PART" Then
                            dt = DB.Part.Stock_Get_Locations(SelectedPartProductDataRow.Item("PartProductID")).Table
                        End If
                    End If

                    Dim shelf As String = ""
                    Dim bin As String = ""
                    If Not dt Is Nothing Then
                        For Each row As DataRow In dt.Rows
                            If SelectedPartProductDataRow.Item("GetID") = row.Item("LocationID") Then
                                shelf = row.Item("Shelf")
                                bin = row.Item("Bin")
                                Exit For
                            End If
                        Next
                    End If

                    SelectedPartProductDataRow.Item("BuyPrice") = 0
                    SelectedPartProductDataRow.Item("GetFrom") = 3
                    SelectedPartProductDataRow.Item("QuantityToOrder") = SelectedPartProductDataRow.Item("Quantity")
                    SelectedPartProductDataRow.Item("Shelf") = shelf
                    SelectedPartProductDataRow.Item("Bin") = bin
            End Select
        Else
            CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).ComboBox.SelectedValue = 0
            SelectedPartProductDataRow.Item("GetID") = "0"
            SelectedPartProductDataRow.Item("QuantityToOrder") = "0"
            SelectedPartProductDataRow.Item("BuyPrice") = "0"
            SelectedPartProductDataRow.Item("QuantityToOrder") = 1
            SelectedPartProductDataRow.Item("GetFromText") = ""
            SelectedPartProductDataRow.Item("Shelf") = ""
            SelectedPartProductDataRow.Item("Bin") = ""
        End If
        SelectedPartProductDataRow.AcceptChanges()
        SelectedPartProductDataRow.Table.AcceptChanges()
        Application.DoEvents()
    End Sub

    Public Function validatePartsAndProducts() As Boolean
        Dim validationString As String = String.Empty

        For Each row As DataRow In Me.PartsAndProducts.Table.Rows
            If IsDBNull(row.Item("GetFrom")) Then
                validationString += "You must select where to get Item : " & row.Item("Name") & " : " & row.Item("Number") & " from " & vbCrLf

            Else
                If Not IsNumeric(row.Item("GetFrom")) Or row.Item("GetFrom") = 0 Then
                    validationString += "You must select where to get Item : " & row.Item("Name") & " : " & row.Item("Number") & " from " & vbCrLf
                End If
            End If

            If EngineerVisitID = 0 And OrderType = Entity.Sys.Enums.OrderType.Job Then
                If IsDBNull(row.Item("VisitCount")) Then
                    validationString += "You must select a visit for item : " & row.Item("Name") & " : " & row.Item("Number") & vbCrLf
                Else
                    If Not IsNumeric(row.Item("VisitCount")) Or row.Item("VisitCount") = 0 Then
                        validationString += "You must select a visit for item : " & row.Item("Name") & " : " & row.Item("Number") & vbCrLf
                    End If
                End If
            End If

            If IsDBNull(row.Item("SellPrice")) Then
                validationString += "You must set a sell price for item : " & row.Item("Name") & " : " & row.Item("Number") & vbCrLf
            Else
                If Not IsNumeric(row.Item("SellPrice")) Or row.Item("SellPrice") = 0 Then
                    validationString += "You must set a sell price for item : " & row.Item("Name") & " : " & row.Item("Number") & vbCrLf
                End If
            End If

            If validationString.Length > 0 Then
                ShowMessage(validationString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Select Case row.Item("GetFrom")
                Case "1"
                    'supplier
                    If row.Item("Type") = "Product" Then
                        Dim oOrderProduct As New Entity.OrderProducts.OrderProduct
                        oOrderProduct.SetBuyPrice = row.Item("BuyPrice")
                        oOrderProduct.SetSellPrice = row.Item("SellPrice")
                        oOrderProduct.SetQuantity = row.Item("QuantityToOrder")
                        oOrderProduct.SetProductSupplierID = row.Item("GetID")

                        Dim oOrderProductValidator As New Entity.OrderProducts.OrderProductValidator
                        oOrderProductValidator.Validate(oOrderProduct)

                    Else
                        Dim oOrderPart As New Entity.OrderParts.OrderPart
                        oOrderPart.SetBuyPrice = row.Item("BuyPrice")
                        oOrderPart.SetSellPrice = row.Item("SellPrice")
                        oOrderPart.SetQuantity = row.Item("QuantityToOrder")
                        oOrderPart.SetPartSupplierID = row.Item("GetID")

                        Dim oOrderPartValidator As New Entity.OrderParts.OrderPartValidator
                        oOrderPartValidator.Validate(oOrderPart)
                    End If
                Case "2", "3"
                    'warehouse/van
                    If row.Item("Type") = "Product" Then
                        Dim oOrderLocationProduct As New Entity.OrderLocationProduct.OrderLocationProduct
                        oOrderLocationProduct.SetProductID = row.Item("PartProductID")
                        oOrderLocationProduct.SetSellPrice = row.Item("SellPrice")
                        oOrderLocationProduct.SetQuantity = row.Item("QuantityToOrder")
                        oOrderLocationProduct.SetLocationID = row.Item("GetID")

                        Dim oOrderLocationProductValidator As New Entity.OrderLocationProduct.OrderLocationProductValidator

                        If Not Trans Is Nothing Then
                            oOrderLocationProductValidator.Validate(oOrderLocationProduct, Trans)
                        Else
                            oOrderLocationProductValidator.Validate(oOrderLocationProduct)
                        End If

                    Else
                        Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                        oOrderLocationPart.SetPartID = row.Item("PartProductID")
                        oOrderLocationPart.SetSellPrice = row.Item("SellPrice")
                        oOrderLocationPart.SetQuantity = row.Item("QuantityToOrder")
                        oOrderLocationPart.SetLocationID = row.Item("GetID")

                        Dim oOrderLocationPartValidator As New Entity.OrderLocationPart.OrderLocationPartValidator

                        If Not Trans Is Nothing Then
                            oOrderLocationPartValidator.Validate(oOrderLocationPart, Trans)
                        Else
                            oOrderLocationPartValidator.Validate(oOrderLocationPart)
                        End If

                    End If
            End Select
        Next

        Return True
    End Function

#End Region

#Region "Events"

    Private Sub FRMConvertToAnOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)

        Me.lblinformation.Text = "Please Select where to get each item from by clicking in the Grid"
    End Sub

    Private Sub dgPartsAndProducts_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPartsAndProducts.CurrentCellChanged
        CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).TheID = SelectedPartProductDataRow("PartProductID")
        CType(Me.dgPartsAndProducts.TableStyles(0).GridColumnStyles("GetFrom"), DataGridComboBoxColumn).Type = SelectedPartProductDataRow("Type")
    End Sub

    Private Sub chkAwaiting_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAwaiting.CheckedChanged
        Me.chkConfirmed.Checked = Not Me.chkAwaiting.Checked
    End Sub

    Private Sub chkConfirmed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConfirmed.CheckedChanged
        Me.chkAwaiting.Checked = Not Me.chkConfirmed.Checked
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ShowMessage("Are you sure you wish to cancel the auto creation of this order? You will need to manually create the order at a later date.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim con As SqlClient.SqlConnection

        If NeedsTransaction = True Then
            con = New SqlClient.SqlConnection(DB.ServerConnectionString)
            con.Open()
            Trans = con.BeginTransaction(IsolationLevel.ReadUncommitted)
        End If

        Dim orders As New ArrayList
        Dim errorOccured As Boolean
        Try
            If validatePartsAndProducts() = False Then
                Exit Sub
            End If

            If txtDepartment.Text.Trim.Length = 0 And chkConfirmed.Checked = True Then
                ShowMessage("Department Reference missing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim userPrefix As String = ""
            Dim username() As String = loggedInUser.Fullname.Split(" ")
            For Each s As String In username
                userPrefix += s.Substring(0, 1)
            Next

            If OrderType = Entity.Sys.Enums.OrderType.Job Then
                'JOB ORDER
                Cursor.Current = Cursors.WaitCursor

                If EngineerVisitID > 0 Then

                    Dim SupplierList As New Hashtable

                    For Each supplierRow As DataRow In Me.PartsAndProducts.Table.Select("GetFrom = 1")
                        If Not SupplierList.Contains(supplierRow.Item("SupplierID")) Then
                            Dim oEngineerVisitOrder As New Entity.EngineerVisitOrders.EngineerVisitOrder
                            Dim jb As Entity.Jobs.Job
                            If Not Trans Is Nothing Then
                                jb = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID, Trans)
                            Else
                                jb = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID)
                            End If
                            Dim oOrder As New Entity.Orders.Order
                            If Not Trans Is Nothing Then
                                oOrder.SetOrderReference = userPrefix & jb.JobNumber & "_V" & EngineerVisitID & "-" & DB.Order.Order_Get_ByRef(userPrefix & jb.JobNumber & "_V" & EngineerVisitID & "-", Trans).Table.Rows.Count + 1
                            Else
                                oOrder.SetOrderReference = userPrefix & jb.JobNumber & "_V" & EngineerVisitID & "-" & DB.Order.Order_Get_ByRef(userPrefix & jb.JobNumber & "_V" & EngineerVisitID & "-").Table.Rows.Count + 1
                            End If
                            oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.Job)
                            oOrder.SetUserID = loggedInUser.UserID
                            oOrder.DeliveryDeadline = Me.dtpDeadline.Value.Date
                            oOrder.DatePlaced = Now
                            If Me.chkAwaiting.Checked Then
                                oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                            Else
                                oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed)
                                chkDoNotConsolidate.Checked = True
                            End If
                            oOrder.SetDepartmentRef = txtDepartment.Text

                            If Not Trans Is Nothing Then
                                oOrder = DB.Order.Insert(oOrder, Trans)
                            Else
                                oOrder = DB.Order.Insert(oOrder)
                            End If

                            For Each drCharge As DataRow In ChargesDataView.Table.Rows
                                Dim oOrderCharge As New Entity.OrderCharges.OrderCharge
                                oOrderCharge.SetAmount = drCharge("Amount")
                                oOrderCharge.SetOrderChargeTypeID = drCharge("OrderChargeTypeID")
                                oOrderCharge.SetOrderID = oOrder.OrderID
                                oOrderCharge.SetReference = drCharge("Reference")
                                DB.OrderCharge.Insert(oOrderCharge)
                            Next

                            If ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then
                                Dim warehouseID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse, Trans)
                                If warehouseID > 0 Then
                                    oEngineerVisitOrder.SetWarehouseID = warehouseID
                                End If
                            End If

                            oEngineerVisitOrder.SetEngineerVisitID = EngineerVisitID
                            oEngineerVisitOrder.SetOrderID = oOrder.OrderID

                            If Not Trans Is Nothing Then
                                oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, Trans)
                            Else
                                oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder)
                            End If

                            Dim oEngineerVisit As Entity.EngineerVisits.EngineerVisit

                            If Not Trans Is Nothing Then
                                oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID, Trans)
                            Else
                                oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID)
                            End If

                            If oEngineerVisit.StatusEnumID < CInt(Entity.Sys.Enums.VisitStatus.Scheduled) Then
                                oEngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts)
                                If Not Trans Is Nothing Then
                                    DB.EngineerVisits.Update(oEngineerVisit, 0, True, Trans)
                                Else
                                    DB.EngineerVisits.Update(oEngineerVisit, 0, True)
                                End If
                            End If

                            orders.Add(New Object() {oOrder.OrderID, EngineerVisitID})
                            SupplierList.Add(supplierRow.Item("SupplierID"), oOrder)
                        End If

                        If supplierRow.Item("Type") = "Product" Then
                            Dim oOrderProduct As New Entity.OrderProducts.OrderProduct
                            oOrderProduct.SetOrderID = CType(SupplierList.Item(supplierRow.Item("SupplierID")), Entity.Orders.Order).OrderID
                            oOrderProduct.SetBuyPrice = supplierRow.Item("BuyPrice")
                            oOrderProduct.SetSellPrice = supplierRow.Item("SellPrice")
                            oOrderProduct.SetQuantity = supplierRow.Item("QuantityToOrder")
                            oOrderProduct.SetProductSupplierID = supplierRow.Item("GetID")

                            If Not Trans Is Nothing Then
                                oOrderProduct = DB.OrderProduct.Insert(oOrderProduct, Not (chkDoNotConsolidate.Checked), Trans)
                            Else
                                oOrderProduct = DB.OrderProduct.Insert(oOrderProduct, Not (chkDoNotConsolidate.Checked))
                            End If

                            Try
                                supplierRow.Item("OrderItemID") = oOrderProduct.OrderProductID
                                supplierRow.Item("OrderLocationTypeID") = CInt(Entity.Sys.Enums.LocationType.Supplier)
                            Catch ex As Exception
                            End Try
                        Else
                            Dim oOrderPart As New Entity.OrderParts.OrderPart
                            oOrderPart.SetOrderID = CType(SupplierList.Item(supplierRow.Item("SupplierID")), Entity.Orders.Order).OrderID
                            oOrderPart.SetBuyPrice = supplierRow.Item("BuyPrice")
                            oOrderPart.SetSellPrice = supplierRow.Item("SellPrice")
                            oOrderPart.SetQuantity = supplierRow.Item("QuantityToOrder")
                            oOrderPart.SetPartSupplierID = supplierRow.Item("GetID")

                            If Not Trans Is Nothing Then

                                oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (chkDoNotConsolidate.Checked), Trans)
                            Else
                                oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (chkDoNotConsolidate.Checked))
                            End If

                            Try
                                supplierRow.Item("OrderItemID") = oOrderPart.OrderPartID
                                supplierRow.Item("OrderLocationTypeID") = CInt(Entity.Sys.Enums.LocationType.Supplier)
                            Catch ex As Exception
                            End Try
                        End If
                    Next

                    Dim LocationList As New Hashtable

                    For Each locationRow As DataRow In Me.PartsAndProducts.Table.Select("GetFrom = 2 OR GetFrom = 3")
                        If Not LocationList.Contains(locationRow.Item("GetID")) Then
                            Dim oEngineerVisitOrder As New Entity.EngineerVisitOrders.EngineerVisitOrder
                            Dim jb As Entity.Jobs.Job
                            If Not Trans Is Nothing Then
                                jb = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID, Trans)
                            Else
                                jb = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID)
                            End If
                            Dim oOrder As New Entity.Orders.Order

                            If Not Trans Is Nothing Then
                                oOrder.SetOrderReference = userPrefix & jb.JobNumber & "_V" & EngineerVisitID & "-" & DB.Order.Order_Get_ByRef(userPrefix & jb.JobNumber & "_V" & EngineerVisitID & "-", Trans).Table.Rows.Count + 1
                            Else
                                oOrder.SetOrderReference = userPrefix & jb.JobNumber & "_V" & EngineerVisitID & "-" & DB.Order.Order_Get_ByRef(userPrefix & jb.JobNumber & "_V" & EngineerVisitID & "-").Table.Rows.Count + 1
                            End If

                            oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.Job)
                            oOrder.SetUserID = loggedInUser.UserID
                            oOrder.DeliveryDeadline = Me.dtpDeadline.Value.Date
                            oOrder.DatePlaced = Now
                            If Me.chkAwaiting.Checked Then
                                oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                            Else
                                oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed)
                                chkDoNotConsolidate.Checked = True
                            End If

                            If Not Trans Is Nothing Then
                                oOrder = DB.Order.Insert(oOrder, Trans)
                            Else
                                oOrder = DB.Order.Insert(oOrder)
                            End If

                            If ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then

                                Dim warehouseID As Integer

                                If Not Trans Is Nothing Then
                                    warehouseID = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse, Trans)
                                Else
                                    warehouseID = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
                                End If

                                If warehouseID > 0 Then
                                    oEngineerVisitOrder.SetWarehouseID = warehouseID
                                End If
                            End If

                            oEngineerVisitOrder.SetEngineerVisitID = EngineerVisitID
                            oEngineerVisitOrder.SetOrderID = oOrder.OrderID
                            If Not Trans Is Nothing Then
                                oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, Trans)
                            Else
                                oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder)
                            End If

                            Dim oEngineerVisit As Entity.EngineerVisits.EngineerVisit
                            If Not Trans Is Nothing Then
                                oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID, Trans)
                            Else
                                oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID)
                            End If

                            If oEngineerVisit.StatusEnumID < CInt(Entity.Sys.Enums.VisitStatus.Scheduled) Then
                                oEngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts)

                                If Not Trans Is Nothing Then
                                    DB.EngineerVisits.Update(oEngineerVisit, 0, True, Trans)
                                Else
                                    DB.EngineerVisits.Update(oEngineerVisit, 0, True)
                                End If

                            End If


                            orders.Add(New Object() {oOrder.OrderID, EngineerVisitID})
                            LocationList.Add(locationRow.Item("GetID"), oOrder)
                        End If

                        If locationRow.Item("Type") = "Product" Then
                            Dim oOrderLocationProduct As New Entity.OrderLocationProduct.OrderLocationProduct
                            oOrderLocationProduct.SetProductID = locationRow.Item("PartProductID")
                            oOrderLocationProduct.SetSellPrice = locationRow.Item("SellPrice")
                            oOrderLocationProduct.SetQuantity = locationRow.Item("QuantityToOrder")
                            oOrderLocationProduct.SetLocationID = locationRow.Item("GetID")
                            oOrderLocationProduct.SetOrderID = CType(LocationList.Item(locationRow.Item("GetID")), Entity.Orders.Order).OrderID

                            If Not Trans Is Nothing Then
                                oOrderLocationProduct = DB.OrderLocationProduct.Insert(oOrderLocationProduct, Not (chkDoNotConsolidate.Checked), Trans)
                            Else
                                oOrderLocationProduct = DB.OrderLocationProduct.Insert(oOrderLocationProduct, Not (chkDoNotConsolidate.Checked))
                            End If

                            locationRow.Item("OrderItemID") = oOrderLocationProduct.OrderLocationProductID
                            locationRow.Item("OrderLocationTypeID") = CInt(Entity.Sys.Enums.LocationType.Warehouse)

                            Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                            oProductTransaction.IgnoreExceptionsOnSetMethods = True
                            oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID
                            oProductTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockReserve)
                            oProductTransaction.SetProductID = oOrderLocationProduct.ProductID
                            oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity
                            oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID

                            If Not Trans Is Nothing Then
                                oProductTransaction = DB.ProductTransaction.Insert(oProductTransaction, Trans)
                            Else
                                oProductTransaction = DB.ProductTransaction.Insert(oProductTransaction)
                            End If

                        Else
                            Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                            oOrderLocationPart.SetPartID = locationRow.Item("PartProductID")
                            oOrderLocationPart.SetSellPrice = locationRow.Item("SellPrice")
                            oOrderLocationPart.SetQuantity = locationRow.Item("QuantityToOrder")
                            oOrderLocationPart.SetLocationID = locationRow.Item("GetID")
                            oOrderLocationPart.SetOrderID = CType(LocationList.Item(locationRow.Item("GetID")), Entity.Orders.Order).OrderID

                            If Not Trans Is Nothing Then
                                oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, Not (chkDoNotConsolidate.Checked), Trans)
                            Else
                                oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, Not (chkDoNotConsolidate.Checked))
                            End If

                            locationRow.Item("OrderItemID") = oOrderLocationPart.OrderLocationPartID
                            locationRow.Item("OrderLocationTypeID") = CInt(Entity.Sys.Enums.LocationType.Warehouse)

                            Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                            oPartTransaction.IgnoreExceptionsOnSetMethods = True
                            oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID
                            oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockReserve)
                            oPartTransaction.SetPartID = oOrderLocationPart.PartID
                            oPartTransaction.SetAmount = -oOrderLocationPart.Quantity
                            oPartTransaction.SetLocationID = oOrderLocationPart.LocationID

                            oPartTransaction = DB.PartTransaction.Insert(oPartTransaction, Trans)
                        End If
                    Next
                Else
                    For Each row As DataRow In EngineerVisitsDataView.Table.Rows
                        Dim SupplierList As New Hashtable

                        For Each supplierRow As DataRow In Me.PartsAndProducts.Table.Select("GetFrom = 1")
                            If Not SupplierList.Contains(supplierRow.Item("SupplierID")) Then
                                If Me.PartsAndProducts.Table.Select("VisitCount = " & row.Item("VisitCount")).Length > 0 Then
                                    Dim oOrder As New Entity.Orders.Order
                                    oOrder.SetOrderReference = userPrefix & "ENG-" & row.Item("EngineerVisitID") & "-" & SupplierList.Count + 1
                                    oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.Job)
                                    oOrder.SetUserID = loggedInUser.UserID
                                    oOrder.DeliveryDeadline = Me.dtpDeadline.Value.Date
                                    oOrder.DatePlaced = Now
                                    If Me.chkAwaiting.Checked Then
                                        oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                                    Else
                                        oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed)
                                        chkDoNotConsolidate.Checked = True
                                    End If
                                    oOrder.SetDepartmentRef = txtDepartment.Text

                                    If Not Trans Is Nothing Then
                                        oOrder = DB.Order.Insert(oOrder, Trans)
                                    Else
                                        oOrder = DB.Order.Insert(oOrder)
                                    End If

                                    Dim oEngineerVisitOrder As New Entity.EngineerVisitOrders.EngineerVisitOrder

                                    If ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then
                                        Dim warehouseID As Integer

                                        If Not Trans Is Nothing Then
                                            warehouseID = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse, Trans)
                                        Else
                                            warehouseID = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
                                        End If

                                        If warehouseID > 0 Then
                                            oEngineerVisitOrder.SetWarehouseID = warehouseID
                                        End If
                                    End If

                                    oEngineerVisitOrder.SetEngineerVisitID = row.Item("EngineerVisitID")
                                    oEngineerVisitOrder.SetOrderID = oOrder.OrderID

                                    If Not Trans Is Nothing Then
                                        oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, Trans)
                                    Else
                                        oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder)
                                    End If

                                    Dim oEngineerVisit As Entity.EngineerVisits.EngineerVisit

                                    If Not Trans Is Nothing Then
                                        oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(row.Item("EngineerVisitID"), Trans)
                                    Else
                                        oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(row.Item("EngineerVisitID"))
                                    End If

                                    If oEngineerVisit.StatusEnumID < CInt(Entity.Sys.Enums.VisitStatus.Scheduled) Then
                                        oEngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts)
                                        If Not Trans Is Nothing Then
                                            DB.EngineerVisits.Update(oEngineerVisit, 0, True, Trans)
                                        Else
                                            DB.EngineerVisits.Update(oEngineerVisit, 0, True)
                                        End If
                                    End If

                                    SupplierList.Add(supplierRow.Item("SupplierID"), oOrder)
                                    orders.Add(New Object() {oOrder.OrderID, row.Item("EngineerVisitID")})
                                End If
                            End If

                            If supplierRow.Item("VisitCount") = row.Item("VisitCount") Then
                                If supplierRow.Item("Type") = "Product" Then
                                    Dim oOrderProduct As New Entity.OrderProducts.OrderProduct
                                    oOrderProduct.SetOrderID = CType(SupplierList.Item(supplierRow.Item("SupplierID")), Entity.Orders.Order).OrderID
                                    oOrderProduct.SetBuyPrice = supplierRow.Item("BuyPrice")
                                    oOrderProduct.SetSellPrice = supplierRow.Item("SellPrice")
                                    oOrderProduct.SetQuantity = supplierRow.Item("QuantityToOrder")
                                    oOrderProduct.SetProductSupplierID = supplierRow.Item("GetID")

                                    If Not Trans Is Nothing Then
                                        oOrderProduct = DB.OrderProduct.Insert(oOrderProduct, Not (chkDoNotConsolidate.Checked), Trans)
                                    Else
                                        oOrderProduct = DB.OrderProduct.Insert(oOrderProduct, Not (chkDoNotConsolidate.Checked))
                                    End If

                                    supplierRow.Item("OrderItemID") = oOrderProduct.OrderProductID
                                Else
                                    Dim oOrderPart As New Entity.OrderParts.OrderPart
                                    oOrderPart.SetOrderID = CType(SupplierList.Item(supplierRow.Item("SupplierID")), Entity.Orders.Order).OrderID
                                    oOrderPart.SetBuyPrice = supplierRow.Item("BuyPrice")
                                    oOrderPart.SetSellPrice = supplierRow.Item("SellPrice")
                                    oOrderPart.SetQuantity = supplierRow.Item("QuantityToOrder")
                                    oOrderPart.SetPartSupplierID = supplierRow.Item("GetID")

                                    If Not Trans Is Nothing Then
                                        oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (chkDoNotConsolidate.Checked), Trans)
                                    Else
                                        oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (chkDoNotConsolidate.Checked))
                                    End If

                                    supplierRow.Item("OrderItemID") = oOrderPart.OrderPartID
                                End If
                            End If
                        Next

                        Dim LocationList As New Hashtable

                        For Each locationRow As DataRow In Me.PartsAndProducts.Table.Select("GetFrom = 2 OR GetFrom = 3")
                            If Not LocationList.Contains(locationRow.Item("GetID")) Then
                                If locationRow.Item("VisitCount") = row.Item("VisitCount") Then
                                    Dim oOrder As New Entity.Orders.Order
                                    oOrder.SetOrderReference = userPrefix & "ENG-" & row.Item("EngineerVisitID") & "-" & LocationList.Count + 1
                                    oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.Job)
                                    oOrder.SetUserID = loggedInUser.UserID
                                    oOrder.DeliveryDeadline = Me.dtpDeadline.Value.Date
                                    oOrder.DatePlaced = Now
                                    If Me.chkAwaiting.Checked Then
                                        oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                                    Else
                                        oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed)
                                        chkDoNotConsolidate.Checked = True
                                    End If
                                    oOrder.SetDepartmentRef = txtDepartment.Text
                                    If Not Trans Is Nothing Then
                                        oOrder = DB.Order.Insert(oOrder, Trans)
                                    Else
                                        oOrder = DB.Order.Insert(oOrder)
                                    End If

                                    Dim oEngineerVisitOrder As New Entity.EngineerVisitOrders.EngineerVisitOrder

                                    If ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then
                                        Dim warehouseID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
                                        If warehouseID > 0 Then
                                            oEngineerVisitOrder.SetWarehouseID = warehouseID
                                        End If
                                    End If

                                    oEngineerVisitOrder.SetEngineerVisitID = row.Item("EngineerVisitID")
                                    oEngineerVisitOrder.SetOrderID = oOrder.OrderID

                                    If Not Trans Is Nothing Then
                                        oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, Trans)
                                    Else
                                        oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder)
                                    End If

                                    Dim oEngineerVisit As Entity.EngineerVisits.EngineerVisit

                                    If Not Trans Is Nothing Then
                                        oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(row.Item("EngineerVisitID"), Trans)
                                    Else
                                        oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(row.Item("EngineerVisitID"))
                                    End If

                                    If oEngineerVisit.StatusEnumID < CInt(Entity.Sys.Enums.VisitStatus.Scheduled) Then

                                        oEngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts)

                                        If Not Trans Is Nothing Then
                                            DB.EngineerVisits.Update(oEngineerVisit, 0, True, Trans)
                                        Else
                                            DB.EngineerVisits.Update(oEngineerVisit, 0, True)
                                        End If

                                    End If

                                    LocationList.Add(locationRow.Item("GetID"), oOrder)
                                    orders.Add(New Object() {oOrder.OrderID, row.Item("EngineerVisitID")})
                                End If
                            End If

                            If locationRow.Item("VisitCount") = row.Item("VisitCount") Then
                                If locationRow.Item("Type") = "Product" Then
                                    Dim oOrderLocationProduct As New Entity.OrderLocationProduct.OrderLocationProduct
                                    oOrderLocationProduct.SetProductID = locationRow.Item("PartProductID")
                                    oOrderLocationProduct.SetSellPrice = locationRow.Item("SellPrice")
                                    oOrderLocationProduct.SetQuantity = locationRow.Item("QuantityToOrder")
                                    oOrderLocationProduct.SetLocationID = locationRow.Item("GetID")
                                    oOrderLocationProduct.SetOrderID = CType(LocationList.Item(locationRow.Item("GetID")), Entity.Orders.Order).OrderID

                                    If Not Trans Is Nothing Then
                                        oOrderLocationProduct = DB.OrderLocationProduct.Insert(oOrderLocationProduct, Not (chkDoNotConsolidate.Checked), Trans)
                                    Else
                                        oOrderLocationProduct = DB.OrderLocationProduct.Insert(oOrderLocationProduct, Not (chkDoNotConsolidate.Checked))
                                    End If

                                    locationRow.Item("OrderItemID") = oOrderLocationProduct.OrderLocationProductID

                                    Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                                    oProductTransaction.IgnoreExceptionsOnSetMethods = True
                                    oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID
                                    oProductTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockReserve)
                                    oProductTransaction.SetProductID = oOrderLocationProduct.ProductID
                                    oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity
                                    oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID
                                Else
                                    Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                                    oOrderLocationPart.SetPartID = locationRow.Item("PartProductID")
                                    oOrderLocationPart.SetSellPrice = locationRow.Item("SellPrice")
                                    oOrderLocationPart.SetQuantity = locationRow.Item("QuantityToOrder")
                                    oOrderLocationPart.SetLocationID = locationRow.Item("GetID")
                                    oOrderLocationPart.SetOrderID = CType(LocationList.Item(locationRow.Item("GetID")), Entity.Orders.Order).OrderID


                                    If Not Trans Is Nothing Then
                                        oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, Not (chkDoNotConsolidate.Checked), Trans)
                                    Else
                                        oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, Not (chkDoNotConsolidate.Checked))
                                    End If

                                    locationRow.Item("OrderItemID") = oOrderLocationPart.OrderLocationPartID

                                    Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                    oPartTransaction.IgnoreExceptionsOnSetMethods = True
                                    oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID
                                    oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockReserve)
                                    oPartTransaction.SetPartID = oOrderLocationPart.PartID
                                    oPartTransaction.SetAmount = -oOrderLocationPart.Quantity
                                    oPartTransaction.SetLocationID = oOrderLocationPart.LocationID

                                    If Not Trans Is Nothing Then
                                        oPartTransaction = DB.PartTransaction.Insert(oPartTransaction, Trans)
                                    Else
                                        oPartTransaction = DB.PartTransaction.Insert(oPartTransaction)
                                    End If

                                End If
                            End If
                        Next
                    Next
                End If

                If NeedsTransaction = True Then

                    'CYCLE THROUGH ORDERS

                    For Each row As DataRow In PartsAndProducts.Table.Rows

                        row.AcceptChanges()
                        If IsDBNull(row.Item("Quantity")) Then
                            row.Item("Quantity") = row.Item("QuantityToOrder")
                        End If

                        DB.EngineerVisitPartProductAllocated.UpdateOne(row.Item("ID"), EngineerVisitID, row.Item("Type"), row.Item("Quantity"), _
                             row.Item("OrderItemID"), row.Item("PartProductID"), _
                             Entity.Sys.Helper.MakeIntegerValid(row.Item("OrderLocationTypeID")), Trans)

                    Next

                    Trans.Commit()

                End If

            Else
                'CUSTOMER 
                Dim SupplierList As New Hashtable

                For Each supplierRow As DataRow In Me.PartsAndProducts.Table.Select("GetFrom = 1")
                    If Not SupplierList.Contains(supplierRow.Item("SupplierID")) Then
                        Dim oOrder As New Entity.Orders.Order
                        Dim oCustomerOrder As New Entity.CustomerOrders.CustomerOrder
                        Dim oSiteOrder As Entity.SiteOrders.SiteOrder
                        Dim oOrderLocation As Entity.OrderLocations.OrderLocation

                        oOrder.SetOrderReference = userPrefix & QuoteOrder.CustomerRef & "-" & SupplierList.Count + 1
                        oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.Customer)
                        oOrder.SetUserID = loggedInUser.UserID
                        oOrder.DeliveryDeadline = Me.dtpDeadline.Value.Date
                        oOrder.DatePlaced = Now
                        If Me.chkAwaiting.Checked Then
                            oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                        Else
                            oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed)
                            chkDoNotConsolidate.Checked = True
                        End If
                        oOrder.SetSpecialInstructions = QuoteOrder.SpecialInstructions
                        oOrder.SetContactID = QuoteOrder.ContactID
                        oOrder.SetInvoiceAddressID = QuoteOrder.InvoiceAddressID
                        oOrder.SetAllocatedToUser = QuoteOrder.AllocatedToUser

                        If Not Trans Is Nothing Then
                            oOrder = DB.Order.Insert(oOrder, Trans)
                        Else
                            oOrder = DB.Order.Insert(oOrder)
                        End If


                        oCustomerOrder.SetCustomerID = QuoteOrder.CustomerID
                        oCustomerOrder.SetOrderID = oOrder.OrderID

                        If Not Trans Is Nothing Then
                            oCustomerOrder = DB.CustomerOrder.Insert(oCustomerOrder, Trans)
                        Else
                            oCustomerOrder = DB.CustomerOrder.Insert(oCustomerOrder)
                        End If

                        If Not QuoteOrder Is Nothing Then
                            If QuoteOrder.PropertyID > 0 Then
                                oSiteOrder = New Entity.SiteOrders.SiteOrder
                                oSiteOrder.SetOrderID = oOrder.OrderID
                                oSiteOrder.SetSiteID = QuoteOrder.PropertyID

                                If Not Trans Is Nothing Then
                                    oSiteOrder = DB.SiteOrder.Insert(oSiteOrder, Trans)
                                Else
                                    oSiteOrder = DB.SiteOrder.Insert(oSiteOrder)
                                End If

                            Else
                                oOrderLocation = New Entity.OrderLocations.OrderLocation
                                If Not Trans Is Nothing Then
                                    oOrderLocation.SetLocationID = DB.Warehouse.Warehouse_GetDV(QuoteOrder.WarehouseID, Trans).Table.Rows(0).Item("LocationID")
                                Else
                                    oOrderLocation.SetLocationID = DB.Warehouse.Warehouse_GetDV(QuoteOrder.WarehouseID).Table.Rows(0).Item("LocationID")
                                End If

                                oOrderLocation.SetOrderID = oOrder.OrderID
                                If Not Trans Is Nothing Then
                                    oOrderLocation = DB.OrderLocation.Insert(oOrderLocation, Trans)
                                Else
                                    oOrderLocation = DB.OrderLocation.Insert(oOrderLocation)
                                End If

                            End If
                        End If

                        SupplierList.Add(supplierRow.Item("SupplierID"), oOrder)
                        orders.Add(New Object() {oOrder.OrderID, QuoteOrder.PropertyID})
                    End If

                    For Each pricerequestRow As DataRow In Me.PriceRequestItemsDataView.Table.Rows
                        If pricerequestRow.Item("SupplierID") = supplierRow.Item("SupplierID") Then
                            If pricerequestRow.Item("Included") = "1" Then
                                If pricerequestRow.Item("Type") = "Product" Then
                                    Dim oOrderProduct As New Entity.OrderProducts.OrderProduct
                                    oOrderProduct.SetOrderID = CType(SupplierList.Item(supplierRow.Item("SupplierID")), Entity.Orders.Order).OrderID
                                    oOrderProduct.SetBuyPrice = pricerequestRow.Item("BuyPrice")
                                    oOrderProduct.SetSellPrice = pricerequestRow.Item("SellPrice")
                                    oOrderProduct.SetQuantity = 1
                                    oOrderProduct.SetProductSupplierID = pricerequestRow.Item("ProductSupplierID")
                                    If Not Trans Is Nothing Then
                                        oOrderProduct = DB.OrderProduct.Insert(oOrderProduct, Not (chkDoNotConsolidate.Checked), Trans)
                                    Else
                                        oOrderProduct = DB.OrderProduct.Insert(oOrderProduct, Not (chkDoNotConsolidate.Checked))
                                    End If
                                Else
                                    Dim oOrderPart As New Entity.OrderParts.OrderPart
                                    oOrderPart.SetOrderID = CType(SupplierList.Item(supplierRow.Item("SupplierID")), Entity.Orders.Order).OrderID
                                    oOrderPart.SetBuyPrice = pricerequestRow.Item("BuyPrice")
                                    oOrderPart.SetSellPrice = pricerequestRow.Item("SellPrice")
                                    oOrderPart.SetQuantity = 1
                                    oOrderPart.SetPartSupplierID = pricerequestRow.Item("PartSupplierID")
                                    If Not Trans Is Nothing Then
                                        oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (chkDoNotConsolidate.Checked), Trans)
                                    Else
                                        oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (chkDoNotConsolidate.Checked))
                                    End If
                                End If
                            End If
                        End If
                    Next

                    If supplierRow.Item("Type") = "Product" Then
                        Dim oOrderProduct As New Entity.OrderProducts.OrderProduct
                        oOrderProduct.SetOrderID = CType(SupplierList.Item(supplierRow.Item("SupplierID")), Entity.Orders.Order).OrderID
                        oOrderProduct.SetBuyPrice = supplierRow.Item("BuyPrice")
                        oOrderProduct.SetSellPrice = supplierRow.Item("SellPrice")
                        oOrderProduct.SetQuantity = supplierRow.Item("QuantityToOrder")
                        oOrderProduct.SetProductSupplierID = supplierRow.Item("GetID")

                        If Not Trans Is Nothing Then
                            oOrderProduct = DB.OrderProduct.Insert(oOrderProduct, Not (chkDoNotConsolidate.Checked), Trans)
                        Else
                            oOrderProduct = DB.OrderProduct.Insert(oOrderProduct, Not (chkDoNotConsolidate.Checked))
                        End If

                    Else
                        Dim oOrderPart As New Entity.OrderParts.OrderPart
                        oOrderPart.SetOrderID = CType(SupplierList.Item(supplierRow.Item("SupplierID")), Entity.Orders.Order).OrderID
                        oOrderPart.SetBuyPrice = supplierRow.Item("BuyPrice")
                        oOrderPart.SetSellPrice = supplierRow.Item("SellPrice")
                        oOrderPart.SetQuantity = supplierRow.Item("QuantityToOrder")
                        oOrderPart.SetPartSupplierID = supplierRow.Item("GetID")

                        If Not Trans Is Nothing Then
                            oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (chkDoNotConsolidate.Checked), Trans)
                        Else
                            oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (chkDoNotConsolidate.Checked))
                        End If

                    End If
                Next

                Dim LocationList As New Hashtable

                For Each locationRow As DataRow In Me.PartsAndProducts.Table.Select("GetFrom = 2 OR GetFrom = 3")
                    If Not LocationList.Contains(locationRow.Item("GetID")) Then
                        Dim oOrder As New Entity.Orders.Order
                        Dim oCustomerOrder As New Entity.CustomerOrders.CustomerOrder
                        Dim oSiteOrder As Entity.SiteOrders.SiteOrder
                        Dim oOrderLocation As Entity.OrderLocations.OrderLocation

                        oOrder.SetOrderReference = QuoteOrder.CustomerRef & "-" & LocationList.Count + 1
                        oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.Customer)
                        oOrder.SetUserID = loggedInUser.UserID
                        oOrder.DeliveryDeadline = Me.dtpDeadline.Value.Date
                        oOrder.DatePlaced = Now
                        If Me.chkAwaiting.Checked Then
                            oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                        Else
                            oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed)
                            chkDoNotConsolidate.Checked = True
                        End If
                        oOrder.SetSpecialInstructions = QuoteOrder.SpecialInstructions
                        oOrder.SetContactID = QuoteOrder.ContactID
                        oOrder.SetInvoiceAddressID = QuoteOrder.InvoiceAddressID
                        oOrder.SetAllocatedToUser = QuoteOrder.AllocatedToUser

                        If Not Trans Is Nothing Then
                            oOrder = DB.Order.Insert(oOrder, Trans)
                        Else
                            oOrder = DB.Order.Insert(oOrder)
                        End If

                        oCustomerOrder.SetCustomerID = QuoteOrder.CustomerID
                        oCustomerOrder.SetOrderID = oOrder.OrderID

                        If Not Trans Is Nothing Then
                            oCustomerOrder = DB.CustomerOrder.Insert(oCustomerOrder, Trans)
                        Else
                            oCustomerOrder = DB.CustomerOrder.Insert(oCustomerOrder)
                        End If

                        If Not QuoteOrder Is Nothing Then
                            If QuoteOrder.PropertyID > 0 Then
                                oSiteOrder = New Entity.SiteOrders.SiteOrder
                                oSiteOrder.SetOrderID = oOrder.OrderID
                                oSiteOrder.SetSiteID = QuoteOrder.PropertyID

                                If Not Trans Is Nothing Then
                                    oSiteOrder = DB.SiteOrder.Insert(oSiteOrder, Trans)
                                Else
                                    oSiteOrder = DB.SiteOrder.Insert(oSiteOrder)
                                End If

                            Else
                                oOrderLocation = New Entity.OrderLocations.OrderLocation

                                If Not Trans Is Nothing Then
                                    oOrderLocation.SetLocationID = DB.Warehouse.Warehouse_GetDV(QuoteOrder.WarehouseID, Trans).Table.Rows(0).Item("LocationID")
                                Else
                                    oOrderLocation.SetLocationID = DB.Warehouse.Warehouse_GetDV(QuoteOrder.WarehouseID).Table.Rows(0).Item("LocationID")
                                End If

                                oOrderLocation.SetOrderID = oOrder.OrderID

                                If Not Trans Is Nothing Then
                                    oOrderLocation = DB.OrderLocation.Insert(oOrderLocation, Trans)
                                Else
                                    oOrderLocation = DB.OrderLocation.Insert(oOrderLocation)
                                End If

                            End If
                        End If

                        LocationList.Add(locationRow.Item("GetID"), oOrder)
                        orders.Add(New Object() {oOrder.OrderID, QuoteOrder.PropertyID})
                    End If

                    If locationRow.Item("Type") = "Product" Then
                        Dim oOrderLocationProduct As New Entity.OrderLocationProduct.OrderLocationProduct
                        oOrderLocationProduct.SetProductID = locationRow.Item("PartProductID")
                        oOrderLocationProduct.SetSellPrice = locationRow.Item("SellPrice")
                        oOrderLocationProduct.SetQuantity = locationRow.Item("QuantityToOrder")
                        oOrderLocationProduct.SetLocationID = locationRow.Item("GetID")
                        oOrderLocationProduct.SetOrderID = CType(LocationList.Item(locationRow.Item("GetID")), Entity.Orders.Order).OrderID

                        If Not Trans Is Nothing Then
                            oOrderLocationProduct = DB.OrderLocationProduct.Insert(oOrderLocationProduct, Not (chkDoNotConsolidate.Checked), Trans)
                        Else
                            oOrderLocationProduct = DB.OrderLocationProduct.Insert(oOrderLocationProduct, Not (chkDoNotConsolidate.Checked))
                        End If

                        Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                        oProductTransaction.IgnoreExceptionsOnSetMethods = True
                        oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID
                        oProductTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockReserve)
                        oProductTransaction.SetProductID = oOrderLocationProduct.ProductID
                        oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity
                        oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID
                    Else
                        Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                        oOrderLocationPart.SetPartID = locationRow.Item("PartProductID")
                        oOrderLocationPart.SetSellPrice = locationRow.Item("SellPrice")
                        oOrderLocationPart.SetQuantity = locationRow.Item("QuantityToOrder")
                        oOrderLocationPart.SetLocationID = locationRow.Item("GetID")
                        oOrderLocationPart.SetOrderID = CType(LocationList.Item(locationRow.Item("GetID")), Entity.Orders.Order).OrderID

                        If Not Trans Is Nothing Then
                            oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, Not (chkDoNotConsolidate.Checked), Trans)
                        Else
                            oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, Not (chkDoNotConsolidate.Checked))
                        End If

                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                        oPartTransaction.IgnoreExceptionsOnSetMethods = True
                        oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID
                        oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockReserve)
                        oPartTransaction.SetPartID = oOrderLocationPart.PartID
                        oPartTransaction.SetAmount = -oOrderLocationPart.Quantity
                        oPartTransaction.SetLocationID = oOrderLocationPart.LocationID

                        If Not Trans Is Nothing Then
                            oPartTransaction = DB.PartTransaction.Insert(oPartTransaction, Trans)
                        Else
                            oPartTransaction = DB.PartTransaction.Insert(oPartTransaction)
                        End If

                    End If
                Next

            End If
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            errorOccured = True
        Catch ex As Exception
            If Not Trans Is Nothing Then
                Trans.Rollback()
            End If
            If Not con Is Nothing Then
                con.Close()
            End If
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            errorOccured = True
        Finally
            Me.Cursor = Cursors.Default
        End Try

        If Not OrderType = Entity.Sys.Enums.OrderType.Job Then
            If orders.Count = 1 Then
                ShowForm(GetType(FRMOrder), False, New Object() {orders(0)(0), orders(0)(1), 0, Me}, True)
            ElseIf orders.Count > 1 Then
                Dim orderIDs As New ArrayList

                For Each order As Object In orders
                    orderIDs.Add(order(0))
                Next

                ShowForm(GetType(FRMOrderManager), False, New Object() {Nothing, orderIDs})
            End If
        End If

        If Not errorOccured = True Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub btnAddPart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddPart.Click

        Dim partID As Integer

        If Not Trans Is Nothing Then
            partID = FindRecord(Entity.Sys.Enums.TableNames.tblPart, Trans)
        Else
            partID = FindRecord(Entity.Sys.Enums.TableNames.tblPart)
        End If

        If partID > 0 Then

            Dim oPart As Entity.Parts.Part

            If Not Trans Is Nothing Then
                oPart = DB.Part.Part_Get(partID, Trans)
            Else
                oPart = DB.Part.Part_Get(partID)
            End If

            Dim newRow As DataRow = PartsAndProducts.Table.NewRow
            newRow.Item("PartProductID") = oPart.PartID
            newRow.Item("Number") = oPart.Number
            newRow.Item("Name") = oPart.Name
            newRow.Item("Type") = "Part"
            PartsAndProducts.Table.Rows.Add(newRow)
            PartsAndProducts.Table.AcceptChanges()
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim msg As String = "Are you sure you want to remove this item from the order?"

        If OrderType = Entity.Sys.Enums.OrderType.Job Then
            msg += vbCrLf & "Removing this item will remove it from the job"
        End If

        If ShowMessage(msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Not SelectedPartProductDataRow Is Nothing Then
                PartsAndProducts.Table.Rows.Remove(SelectedPartProductDataRow)
            End If
        End If
    End Sub

    Private Sub btnAddProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProduct.Click

        Dim productID As Integer

        If Not Trans Is Nothing Then
            productID = FindRecord(Entity.Sys.Enums.TableNames.tblProduct, Trans)
        Else
            productID = FindRecord(Entity.Sys.Enums.TableNames.tblProduct)
        End If

        If productID > 0 Then
            Dim oProduct As Entity.Products.Product

            If Not Trans Is Nothing Then
                oProduct = DB.Product.Product_Get(productID, Trans)
            Else
                oProduct = DB.Product.Product_Get(productID)
            End If

            Dim newRow As DataRow = PartsAndProducts.Table.NewRow
            newRow.Item("PartProductID") = oProduct.ProductID
            newRow.Item("Name") = oProduct.Name
            newRow.Item("Number") = oProduct.Number
            newRow.Item("Type") = "Product"
            PartsAndProducts.Table.Rows.Add(newRow)
            PartsAndProducts.Table.AcceptChanges()
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Type"))
        dt.Columns.Add(New DataColumn("Name"))
        dt.Columns.Add(New DataColumn("Number"))
        dt.Columns.Add(New DataColumn("Quantity"))
        dt.Columns.Add(New DataColumn("Location"))
        dt.Columns.Add(New DataColumn("Shelf"))
        dt.Columns.Add(New DataColumn("Bin"))

        For Each row As DataRow In PartsAndProducts.Table.Rows
            Dim r As DataRow = dt.NewRow
            r("Type") = row.Item("Type")
            r("Name") = row.Item("Name")
            r("Number") = row.Item("Number")
            r("Quantity") = row.Item("Quantity")
            r("Location") = row.Item("GetFromText")
            r("Shelf") = row.Item("Shelf")
            r("Bin") = row.Item("Bin")
            dt.Rows.Add(r)
        Next

        Dim oExport As New Entity.Sys.Exporting(dt, "Job Order Pick List")
        oExport = Nothing
    End Sub

#End Region

#Region "Charges"

    Public Sub RefreshDatagrid()
        ChargesDataView = DB.OrderCharge.OrderCharge_GetForOrder(0)
        PageState = Entity.Sys.Enums.FormState.Insert
    End Sub

    Private Sub dgCharges_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCharges.Click, dgCharges.CurrentCellChanged
        If Me.SelectedChargeDataRow Is Nothing Then
            PageState = Entity.Sys.Enums.FormState.Insert
            Exit Sub
        End If

        PageState = Entity.Sys.Enums.FormState.Update
        Me.txtAmount.Text = SelectedChargeDataRow.Item("Amount")
        Combo.SetSelectedComboItem_By_Value(Me.cboChargeType, SelectedChargeDataRow.Item("OrderChargeTypeID"))
    End Sub

    Private Sub btnChargesSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChargesSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oOrderCharge As New Entity.OrderCharges.OrderCharge
            oOrderCharge.IgnoreExceptionsOnSetMethods = True
            oOrderCharge.SetAmount = Me.txtAmount.Text.Trim
            oOrderCharge.SetOrderChargeTypeID = Combo.GetSelectedItemValue(Me.cboChargeType)
            oOrderCharge.SetOrderID = 0

            Dim oValidator As New Entity.OrderCharges.OrderChargeValidator
            oValidator.Validate(oOrderCharge)

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    Dim drNew As DataRow
                    drNew = ChargesDataView.Table.NewRow
                    drNew("Amount") = oOrderCharge.Amount
                    drNew("Reference") = oOrderCharge.Reference
                    drNew("ChargeType") = Combo.GetSelectedItemDescription(Me.cboChargeType)
                    drNew("OrderChargeTypeID") = Combo.GetSelectedItemValue(Me.cboChargeType)
                    ChargesDataView.Table.Rows.Add(drNew)

                Case Entity.Sys.Enums.FormState.Update

                    SelectedChargeDataRow("Amount") = oOrderCharge.Amount
                    SelectedChargeDataRow("Reference") = oOrderCharge.Reference
                    SelectedChargeDataRow("ChargeType") = Combo.GetSelectedItemDescription(Me.cboChargeType)
                    SelectedChargeDataRow("OrderChargeTypeID") = Combo.GetSelectedItemValue(Me.cboChargeType)
            End Select

            PageState = Entity.Sys.Enums.FormState.Insert

        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If SelectedChargeDataRow Is Nothing Then
            ShowMessage("Please select a charge to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            PageState = Entity.Sys.Enums.FormState.Insert
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to remove this charge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        ChargesDataView.Table.Rows.Remove(SelectedChargeDataRow)

    End Sub

#End Region

End Class
