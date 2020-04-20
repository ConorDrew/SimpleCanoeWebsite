Public Class UCSideBar : Inherits FSM.UCBase

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        AddHandler btnCustomer.ButtonClicked, AddressOf MenuSelectionChanged
        AddHandler btnSpares.ButtonClicked, AddressOf MenuSelectionChanged
        AddHandler btnStaff.ButtonClicked, AddressOf MenuSelectionChanged
        AddHandler btnJobs.ButtonClicked, AddressOf MenuSelectionChanged
        AddHandler btnInvoicing.ButtonClicked, AddressOf MenuSelectionChanged
        AddHandler btnReports.ButtonClicked, AddressOf MenuSelectionChanged
        AddHandler btnVan.ButtonClicked, AddressOf MenuSelectionChanged

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
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnVan As FSM.UCMainButton
    Friend WithEvents btnReports As FSM.UCMainButton
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlSubMenu As System.Windows.Forms.Panel
    Friend WithEvents btnCustomer As FSM.UCMainButton
    Friend WithEvents btnSpares As FSM.UCMainButton
    Friend WithEvents btnJobs As FSM.UCMainButton
    Friend WithEvents btnInvoicing As FSM.UCMainButton
    Friend WithEvents btnStaff As FSM.UCMainButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCSideBar))
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnVan = New FSM.UCMainButton()
        Me.btnReports = New FSM.UCMainButton()
        Me.btnInvoicing = New FSM.UCMainButton()
        Me.btnJobs = New FSM.UCMainButton()
        Me.btnStaff = New FSM.UCMainButton()
        Me.btnSpares = New FSM.UCMainButton()
        Me.btnCustomer = New FSM.UCMainButton()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.pnlSubMenu = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlButtons.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnVan)
        Me.pnlButtons.Controls.Add(Me.btnReports)
        Me.pnlButtons.Controls.Add(Me.btnInvoicing)
        Me.pnlButtons.Controls.Add(Me.btnJobs)
        Me.pnlButtons.Controls.Add(Me.btnStaff)
        Me.pnlButtons.Controls.Add(Me.btnSpares)
        Me.pnlButtons.Controls.Add(Me.btnCustomer)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 430)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(160, 224)
        Me.pnlButtons.TabIndex = 1
        '
        'btnVan
        '
        Me.btnVan.AutoScroll = True
        Me.btnVan.BackColor = System.Drawing.Color.White
        Me.btnVan.BackgroundImage = CType(resources.GetObject("btnVan.BackgroundImage"), System.Drawing.Image)
        Me.btnVan.Caption = "Fleet"
        Me.btnVan.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnVan.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVan.FormButtons = Nothing
        Me.btnVan.IAmSelected = False
        Me.btnVan.Image = CType(resources.GetObject("btnVan.Image"), System.Drawing.Image)
        Me.btnVan.Location = New System.Drawing.Point(0, 192)
        Me.btnVan.MenuType = FSM.Entity.Sys.Enums.MenuTypes.FleetVan
        Me.btnVan.Name = "btnVan"
        Me.btnVan.Size = New System.Drawing.Size(160, 32)
        Me.btnVan.TabIndex = 8
        '
        'btnReports
        '
        Me.btnReports.AutoScroll = True
        Me.btnReports.BackColor = System.Drawing.Color.White
        Me.btnReports.BackgroundImage = CType(resources.GetObject("btnReports.BackgroundImage"), System.Drawing.Image)
        Me.btnReports.Caption = "Reports"
        Me.btnReports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReports.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.FormButtons = Nothing
        Me.btnReports.IAmSelected = False
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.Location = New System.Drawing.Point(0, 160)
        Me.btnReports.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Reports
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(160, 32)
        Me.btnReports.TabIndex = 7
        '
        'btnInvoicing
        '
        Me.btnInvoicing.AutoScroll = True
        Me.btnInvoicing.BackColor = System.Drawing.Color.White
        Me.btnInvoicing.BackgroundImage = CType(resources.GetObject("btnInvoicing.BackgroundImage"), System.Drawing.Image)
        Me.btnInvoicing.Caption = "Invoicing"
        Me.btnInvoicing.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnInvoicing.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvoicing.FormButtons = Nothing
        Me.btnInvoicing.IAmSelected = False
        Me.btnInvoicing.Image = CType(resources.GetObject("btnInvoicing.Image"), System.Drawing.Image)
        Me.btnInvoicing.Location = New System.Drawing.Point(0, 128)
        Me.btnInvoicing.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Invoicing
        Me.btnInvoicing.Name = "btnInvoicing"
        Me.btnInvoicing.Size = New System.Drawing.Size(160, 32)
        Me.btnInvoicing.TabIndex = 6
        '
        'btnJobs
        '
        Me.btnJobs.AutoScroll = True
        Me.btnJobs.BackColor = System.Drawing.Color.White
        Me.btnJobs.BackgroundImage = CType(resources.GetObject("btnJobs.BackgroundImage"), System.Drawing.Image)
        Me.btnJobs.Caption = "Jobs"
        Me.btnJobs.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnJobs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJobs.FormButtons = Nothing
        Me.btnJobs.IAmSelected = False
        Me.btnJobs.Image = CType(resources.GetObject("btnJobs.Image"), System.Drawing.Image)
        Me.btnJobs.Location = New System.Drawing.Point(0, 96)
        Me.btnJobs.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Jobs
        Me.btnJobs.Name = "btnJobs"
        Me.btnJobs.Size = New System.Drawing.Size(160, 32)
        Me.btnJobs.TabIndex = 5
        '
        'btnStaff
        '
        Me.btnStaff.AutoScroll = True
        Me.btnStaff.BackColor = System.Drawing.Color.White
        Me.btnStaff.BackgroundImage = CType(resources.GetObject("btnStaff.BackgroundImage"), System.Drawing.Image)
        Me.btnStaff.Caption = "Staff"
        Me.btnStaff.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnStaff.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStaff.FormButtons = Nothing
        Me.btnStaff.IAmSelected = False
        Me.btnStaff.Image = CType(resources.GetObject("btnStaff.Image"), System.Drawing.Image)
        Me.btnStaff.Location = New System.Drawing.Point(0, 64)
        Me.btnStaff.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Staff
        Me.btnStaff.Name = "btnStaff"
        Me.btnStaff.Size = New System.Drawing.Size(160, 32)
        Me.btnStaff.TabIndex = 4
        '
        'btnSpares
        '
        Me.btnSpares.AutoScroll = True
        Me.btnSpares.BackColor = System.Drawing.Color.White
        Me.btnSpares.BackgroundImage = CType(resources.GetObject("btnSpares.BackgroundImage"), System.Drawing.Image)
        Me.btnSpares.Caption = "Spares"
        Me.btnSpares.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSpares.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSpares.FormButtons = Nothing
        Me.btnSpares.IAmSelected = False
        Me.btnSpares.Image = CType(resources.GetObject("btnSpares.Image"), System.Drawing.Image)
        Me.btnSpares.Location = New System.Drawing.Point(0, 32)
        Me.btnSpares.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Spares
        Me.btnSpares.Name = "btnSpares"
        Me.btnSpares.Size = New System.Drawing.Size(160, 32)
        Me.btnSpares.TabIndex = 3
        '
        'btnCustomer
        '
        Me.btnCustomer.AutoScroll = True
        Me.btnCustomer.BackColor = System.Drawing.Color.White
        Me.btnCustomer.BackgroundImage = CType(resources.GetObject("btnCustomer.BackgroundImage"), System.Drawing.Image)
        Me.btnCustomer.Caption = "Customers"
        Me.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer.FormButtons = Nothing
        Me.btnCustomer.IAmSelected = False
        Me.btnCustomer.Image = CType(resources.GetObject("btnCustomer.Image"), System.Drawing.Image)
        Me.btnCustomer.Location = New System.Drawing.Point(0, 0)
        Me.btnCustomer.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Customers
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(160, 32)
        Me.btnCustomer.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.Silver
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Enabled = False
        Me.Splitter1.Location = New System.Drawing.Point(0, 425)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(160, 5)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'pnlSearch
        '
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSearch.Location = New System.Drawing.Point(0, 273)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(160, 152)
        Me.pnlSearch.TabIndex = 3
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.pnlSubMenu)
        Me.pnlMenu.Controls.Add(Me.Label1)
        Me.pnlMenu.Controls.Add(Me.pnlHeader)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(160, 273)
        Me.pnlMenu.TabIndex = 4
        '
        'pnlSubMenu
        '
        Me.pnlSubMenu.AutoScroll = True
        Me.pnlSubMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSubMenu.Location = New System.Drawing.Point(0, 50)
        Me.pnlSubMenu.Name = "pnlSubMenu"
        Me.pnlSubMenu.Size = New System.Drawing.Size(160, 223)
        Me.pnlSubMenu.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(0, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Please select option"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlHeader.BackgroundImage = CType(resources.GetObject("pnlHeader.BackgroundImage"), System.Drawing.Image)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(160, 34)
        Me.pnlHeader.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 32)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = ">>"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(32, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(128, 32)
        Me.lblTitle.TabIndex = 28
        Me.lblTitle.Text = "HOME"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UCSideBar
        '
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.pnlButtons)
        Me.Name = "UCSideBar"
        Me.Size = New System.Drawing.Size(160, 654)
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Functions"

    Private Sub MenuSelectionChanged(ByVal MenuType As Entity.Sys.Enums.MenuTypes)
        Navigation.Navigate(MenuType)
    End Sub

#End Region

 
End Class
