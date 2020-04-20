Public Class frmAbsences : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Search As System.Windows.Forms.GroupBox
    Friend WithEvents cboEngineers As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnShowResults As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents dgAbsences As System.Windows.Forms.DataGrid
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboUsers As System.Windows.Forms.ComboBox
    Friend WithEvents mnuAbsenceType As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuEngineerAbsence As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUserAbsence As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuBlockOfAbsences As System.Windows.Forms.MenuItem
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgAbsences = New System.Windows.Forms.DataGrid
        Me.Search = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboUsers = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.btnShowResults = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboEngineers = New System.Windows.Forms.ComboBox
        Me.btnNew = New System.Windows.Forms.Button
        Me.mnuAbsenceType = New System.Windows.Forms.ContextMenu
        Me.mnuEngineerAbsence = New System.Windows.Forms.MenuItem
        Me.mnuUserAbsence = New System.Windows.Forms.MenuItem
        Me.btnDelete = New System.Windows.Forms.Button
        Me.mnuBlockOfAbsences = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgAbsences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgAbsences)

        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(741, 216)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Double click to edit"
        '
        'dgAbsences
        '
        Me.dgAbsences.AllowNavigation = False
        Me.dgAbsences.AlternatingBackColor = System.Drawing.Color.GhostWhite
        Me.dgAbsences.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAbsences.BackgroundColor = System.Drawing.Color.White
        Me.dgAbsences.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgAbsences.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.dgAbsences.CaptionForeColor = System.Drawing.Color.White
        Me.dgAbsences.CaptionVisible = False
        Me.dgAbsences.DataMember = ""
        Me.dgAbsences.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dgAbsences.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgAbsences.GridLineColor = System.Drawing.Color.RoyalBlue
        Me.dgAbsences.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.dgAbsences.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgAbsences.HeaderForeColor = System.Drawing.Color.Lavender
        Me.dgAbsences.LinkColor = System.Drawing.Color.Teal
        Me.dgAbsences.Location = New System.Drawing.Point(10, 17)
        Me.dgAbsences.Name = "dgAbsences"
        Me.dgAbsences.ParentRowsBackColor = System.Drawing.Color.Lavender
        Me.dgAbsences.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.dgAbsences.ParentRowsVisible = False
        Me.dgAbsences.RowHeadersVisible = False
        Me.dgAbsences.SelectionBackColor = System.Drawing.Color.Teal
        Me.dgAbsences.SelectionForeColor = System.Drawing.Color.PaleGreen
        Me.dgAbsences.Size = New System.Drawing.Size(722, 190)
        Me.dgAbsences.TabIndex = 7
        '
        'Search
        '
        Me.Search.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Search.Controls.Add(Me.Label5)
        Me.Search.Controls.Add(Me.cboUsers)
        Me.Search.Controls.Add(Me.Label2)
        Me.Search.Controls.Add(Me.dtTo)
        Me.Search.Controls.Add(Me.dtFrom)
        Me.Search.Controls.Add(Me.Label4)
        Me.Search.Controls.Add(Me.Label3)
        Me.Search.Controls.Add(Me.cboType)
        Me.Search.Controls.Add(Me.btnShowResults)
        Me.Search.Controls.Add(Me.Label1)
        Me.Search.Controls.Add(Me.cboEngineers)

        Me.Search.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Search.Location = New System.Drawing.Point(8, 40)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(741, 144)
        Me.Search.TabIndex = 1
        Me.Search.TabStop = False
        Me.Search.Text = "Search"
        '
        'Label5
        '

        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(16, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 17)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "User:"
        '
        'cboUsers
        '
        Me.cboUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsers.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboUsers.Location = New System.Drawing.Point(112, 48)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(624, 21)
        Me.cboUsers.TabIndex = 2
        '
        'Label2
        '

        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(16, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 18)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Absent From"
        '
        'dtTo
        '
        Me.dtTo.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(304, 112)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(152, 20)
        Me.dtTo.TabIndex = 5
        '
        'dtFrom
        '
        Me.dtFrom.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(112, 112)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(152, 20)
        Me.dtFrom.TabIndex = 4
        Me.dtFrom.Value = New Date(2007, 9, 14, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(272, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 18)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "To"
        '
        'Label3
        '

        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(16, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Absence Type:"
        '
        'cboType
        '
        Me.cboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboType.Location = New System.Drawing.Point(112, 80)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(624, 21)
        Me.cboType.TabIndex = 3
        '
        'btnShowResults
        '
        Me.btnShowResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowResults.UseVisualStyleBackColor = True
        Me.btnShowResults.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnShowResults.Location = New System.Drawing.Point(670, 112)
        Me.btnShowResults.Name = "btnShowResults"
        Me.btnShowResults.Size = New System.Drawing.Size(64, 23)
        Me.btnShowResults.TabIndex = 6
        Me.btnShowResults.Text = "Show"
        '
        'Label1
        '

        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Engineer:"
        '
        'cboEngineers
        '
        Me.cboEngineers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEngineers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEngineers.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cboEngineers.Location = New System.Drawing.Point(112, 19)
        Me.cboEngineers.Name = "cboEngineers"
        Me.cboEngineers.Size = New System.Drawing.Size(624, 21)
        Me.cboEngineers.TabIndex = 1
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNew.ContextMenu = Me.mnuAbsenceType
        Me.btnNew.UseVisualStyleBackColor = True
        Me.btnNew.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnNew.Location = New System.Drawing.Point(8, 416)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 23)
        Me.btnNew.TabIndex = 8
        Me.btnNew.Text = "Add New"
        '
        'mnuAbsenceType
        '
        Me.mnuAbsenceType.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEngineerAbsence, Me.mnuUserAbsence, Me.MenuItem2, Me.mnuBlockOfAbsences})
        '
        'mnuEngineerAbsence
        '
        Me.mnuEngineerAbsence.Index = 0
        Me.mnuEngineerAbsence.Text = "Engineer Absence"
        '
        'mnuUserAbsence
        '
        Me.mnuUserAbsence.Index = 1
        Me.mnuUserAbsence.Text = "User Absence"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnDelete.Location = New System.Drawing.Point(688, 416)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 23)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete"
        '
        'mnuBlockOfAbsences
        '
        Me.mnuBlockOfAbsences.Index = 3
        Me.mnuBlockOfAbsences.Text = "Block of Absences"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 2
        Me.MenuItem2.Text = "-"
        '
        'frmAbsences
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(760, 446)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.GroupBox1)
        Me.MinimumSize = New System.Drawing.Size(768, 480)
        Me.Name = "frmAbsences"
        Me.Text = "Absences"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Search, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgAbsences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Search.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

    Private _dvAbsences As New DataView
    Public Property AbsencesDataView() As DataView
        Get
            Return _dvAbsences
        End Get
        Set(ByVal Value As DataView)
            _dvAbsences = Value
            _dvAbsences.Table.TableName = "tblEngineerAbsence"
            dgAbsences.DataSource = _dvAbsences
            _dvAbsences.AllowNew = False
            _dvAbsences.AllowEdit = False
            _dvAbsences.AllowDelete = False
        End Set
    End Property

    Public ReadOnly Property SelectedAbsenceRow() As DataRow
        Get
            If dgAbsences.CurrentRowIndex > -1 Then
                Return AbsencesDataView(dgAbsences.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Public Event RefreshEngineerAbsences()

    Private Sub frmHolidays_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(Me)
        SetupAbsenceDataGridGrid()
        LoadEngineerComboBox()
        LoadUserComboBox()
        LoadAbsencestypeComboBox()
    End Sub

    Private Sub btnShowResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowResults.Click
        SearchAbsences()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EditAbsence()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        mnuAbsenceType.Show(btnNew, New Point(0, 0))
    End Sub

    Private Sub dgAbsences_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAbsences.DoubleClick
        EditAbsence()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteAbsence()
    End Sub

    Private Sub mnuEngineerAbsence_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEngineerAbsence.Click
        Dim frm As New FrmEngineerAbsence
        frm.ShowDialog()
    End Sub

    Private Sub mnuUserAbsence_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuUserAbsence.Click
        Dim frm As New FrmUserAbsence
        frm.ShowDialog()
    End Sub

    Private Sub mnuBlockOfAbsences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBlockOfAbsences.Click
        Dim frm As New FrmBlockAbsence
        AddHandler frm.UserAbsenceChanged, AddressOf SearchAbsences
        frm.ShowDialog()
    End Sub

#End Region

#Region "Functions"

    Private Sub SetupAbsenceDataGridGrid()

        SuspendLayout()
        Entity.Sys.Helper.SetUpDataGrid(dgAbsences)

        Dim tbStyle As DataGridTableStyle = Me.dgAbsences.TableStyles(0)
        tbStyle.GridColumnStyles.Clear()

        dgAbsences.ReadOnly = True

        Dim Name As New DataGridLabelColumn
        Name.MappingName = "Name"
        Name.HeaderText = "Name"
        Name.Width = 200
        Name.NullText = ""
        Name.ReadOnly = True
        tbStyle.GridColumnStyles.Add(Name)


        Dim PersonnelType As New DataGridLabelColumn
        PersonnelType.MappingName = "PersonnelType"
        PersonnelType.HeaderText = "Personnel Type"
        PersonnelType.Width = 200
        PersonnelType.NullText = ""
        PersonnelType.ReadOnly = True
        tbStyle.GridColumnStyles.Add(PersonnelType)

        Dim UnavailableType As New DataGridLabelColumn
        UnavailableType.MappingName = "Description"
        UnavailableType.HeaderText = "Type"
        UnavailableType.Width = 110
        UnavailableType.NullText = ""
        UnavailableType.ReadOnly = True
        tbStyle.GridColumnStyles.Add(UnavailableType)

        Dim DateFrom As New DataGridLabelColumn
        DateFrom.MappingName = "DateFrom"
        DateFrom.HeaderText = "Date From"
        DateFrom.Format = "dd/MM/yyyy HH:mm"
        DateFrom.Width = 100
        DateFrom.NullText = ""
        DateFrom.ReadOnly = True
        tbStyle.GridColumnStyles.Add(DateFrom)

        Dim DateTo As New DataGridLabelColumn
        DateTo.MappingName = "DateTo"
        DateTo.HeaderText = "Date To"
        DateTo.Format = "dd/MM/yyyy HH:mm"
        DateTo.NullText = ""
        DateTo.Width = 100
        DateTo.ReadOnly = True
        tbStyle.GridColumnStyles.Add(DateTo)

        tbStyle.MappingName = "tblEngineerAbsence"

        dgAbsences.TableStyles.Add(tbStyle)
        ResumeLayout()
    End Sub

    Private Sub LoadAbsencestypeComboBox()
        Dim dt As New DataTable
        dt = DB.EngineerAbsence.EngineerAbsenceTypes_GetAll

        Dim drAll As DataRow = dt.NewRow

        drAll("Description") = "All"
        drAll("EngineerAbsenceTypeID") = 0
        dt.Rows.InsertAt(drAll, 0)

        dt.AcceptChanges()

        cboType.DataSource = dt
        cboType.DisplayMember = "Description"
        cboType.ValueMember = "EngineerAbsenceTypeID"

    End Sub

    Private Sub LoadEngineerComboBox()
        Dim dt As New DataTable
        dt = DB.Engineer.Engineer_GetAll.Table

        Dim drAll As DataRow = dt.NewRow

        drAll("Name") = "All"
        drAll("EngineerID") = 0
        dt.Rows.InsertAt(drAll, 0)

        dt.AcceptChanges()

        cboEngineers.DataSource = dt
        cboEngineers.DisplayMember = "Name"
        cboEngineers.ValueMember = "EngineerID"
    End Sub

    Private Sub LoadUserComboBox()
        Dim dt As New DataTable
        dt = DB.User.GetAll.Table

        Dim drAll As DataRow = dt.NewRow

        drAll("Fullname") = "All"
        drAll("UserID") = 0
        dt.Rows.InsertAt(drAll, 0)

        dt.AcceptChanges()

        cboUsers.DataSource = dt
        cboUsers.DisplayMember = "Fullname"
        cboUsers.ValueMember = "UserID"
    End Sub

    Public Sub EditAbsence()
        If dgAbsences.CurrentRowIndex > -1 Then
            If Not SelectedAbsenceRow Is Nothing Then

                If SelectedAbsenceRow("PersonnelType") = "Engineer" Then
                    Dim frm As New FrmEngineerAbsence(CInt(SelectedAbsenceRow.Item("ID")))
                    frm.ShowDialog()
                Else
                    Dim frm As New FrmUserAbsence(CInt(SelectedAbsenceRow.Item("ID")))
                    frm.ShowDialog()
                End If

            End If
        End If
    End Sub

    Public Sub NewAbsence()
        Dim frm As New FrmEngineerAbsence
        frm.ShowDialog()
    End Sub

    Private Sub SearchAbsences()
        Dim sql As String
        Dim where As New ArrayList

        sql = "SELECT EngineerAbsenceID AS ID,'Engineer' as PersonnelType , tblEngineer.Name as [Name], DateTo, DateFrom, AbsenceTypeID, Description"
        sql += " FROM tblEngineerAbsence"
        sql += " INNER JOIN tblEngineer ON tblEngineer.EngineerID = tblEngineerAbsence.EngineerID"
        sql += " LEFT JOIN tblEngineerAbsenceTypes ON tblEngineerAbsenceTypes.EngineerAbsenceTypeID = tblEngineerAbsence.AbsenceTypeID"

        'AMY PUT THIS IN TO CORRECT THE FILTER
        Dim dateStr As String = ""
        dateStr = " (('{0}' Between tblEngineerAbsence.DateFrom AND tblEngineerAbsence.DateTo) OR " & _
              " ('{1}' Between tblEngineerAbsence.DateFrom AND tblEngineerAbsence.DateTo) OR " & _
              " (tblEngineerAbsence.DateFrom Between '{0}' AND '{1}' AND tblEngineerAbsence.DateTo Between '{0}' AND '{1}') ) "

        where.Add(String.Format(dateStr, dtFrom.Value.ToString("yyyy-MM-dd") & " 00:00:00", dtTo.Value.ToString("yyyy-MM-dd") & " 23:59:59"))

        'where.Add(String.Format(" tblEngineerAbsence.DateFrom >= '{0}'", dtFrom.Value.ToString("yyyy-MM-dd") & " 00:00:00"))
        'where.Add(String.Format(" tblEngineerAbsence.DateTo <='{0}'", dtTo.Value.ToString("yyyy-MM-dd") & " 23:59:59"))

        If cboEngineers.SelectedIndex > 0 Then
            where.Add(String.Format(" tblEngineerAbsence.EngineerID = '{0}'", cboEngineers.SelectedValue))
        End If

        If cboType.SelectedIndex > 0 Then
            where.Add(String.Format("tblEngineerAbsenceTypes.EngineerAbsenceTypeID = {0}", cboType.SelectedValue))
        End If
        where.Add(" tblEngineerAbsence.Deleted = 0")
        where.Add(" tblEngineer.Deleted = 0")
        where.Add(" tblEngineerAbsenceTypes.Deleted = 0")

        If where.Count > 0 Then
            sql += "  WHERE"
            For x As Integer = 0 To where.Count - 1
                If x > 0 Then
                    sql += " AND"
                End If
                sql += " " & CStr(where(x))
            Next
        End If

        where.Clear()

        sql += " UNION "
        sql += "SELECT UserAbsenceID AS ID, 'User' as PersonnelType ,tblUser.Fullname AS [Name] , DateTo, DateFrom, AbsenceTypeID, Description"
        sql += " FROM tblUserAbsence"
        sql += " INNER JOIN tblUser ON tblUser.UserID = tblUserAbsence.UserID"
        sql += " LEFT JOIN tblUserAbsenceTypes ON tblUserAbsenceTypes.UserAbsenceTypeID = tblUserAbsence.AbsenceTypeID"

        'AMY PUT THIS IN TO CORRECT THE FILTER
        dateStr = ""
        dateStr = " (('{0}' Between tblUserAbsence.DateFrom AND tblUserAbsence.DateTo) OR " & _
              " ('{1}' Between tblUserAbsence.DateFrom AND tblUserAbsence.DateTo) OR " & _
              " (tblUserAbsence.DateFrom Between '{0}' AND '{1}' AND tblUserAbsence.DateTo Between '{0}' AND '{1}') ) "

        where.Add(String.Format(dateStr, dtFrom.Value.ToString("yyyy-MM-dd") & " 00:00:00", dtTo.Value.ToString("yyyy-MM-dd") & " 23:59:59"))

        'where.Add(String.Format(" tblUserAbsence.DateFrom >= '{0}'", dtFrom.Value.ToString("yyyy-MM-dd") & " 00:00:00"))
        'where.Add(String.Format(" tblUserAbsence.DateTo <='{0}'", dtTo.Value.ToString("yyyy-MM-dd") & " 23:59:59"))

        If cboUsers.SelectedIndex > 0 Then
            where.Add(String.Format(" tblUserAbsence.UserID = '{0}'", cboUsers.SelectedValue))
        End If

        If cboType.SelectedIndex > 0 Then
            where.Add(String.Format("tblUserAbsenceTypes.UserAbsenceTypeID = {0}", cboType.SelectedValue))
        End If
        where.Add(" tblUserAbsence.Deleted = 0")
        where.Add(" tblUser.Deleted = 0")
        where.Add(" tblUserAbsenceTypes.Deleted = 0")

        If where.Count > 0 Then
            sql += "  WHERE"
            For x As Integer = 0 To where.Count - 1
                If x > 0 Then
                    sql += " AND"
                End If
                sql += " " & CStr(where(x))
            Next
        End If


        Dim dt As DataTable = DB.EngineerAbsence.AbsenceSearch(sql)
        AbsencesDataView = New DataView(dt)

        If dt.Rows.Count > 0 Then
            dgAbsences.Select(0)
        End If

        Me.ActiveControl = cboEngineers
        cboEngineers.Focus()

    End Sub

    Private Sub DeleteAbsence()
        If dgAbsences.CurrentRowIndex > -1 Then
            If Not SelectedAbsenceRow Is Nothing Then
                If SelectedAbsenceRow("PersonnelType") = "Engineer" Then
                    Dim str As String = String.Format("Are you sure you want to delete engineer {0}'s absence from {1} to {2}?", SelectedAbsenceRow.Item("Name"), CStr(Format(SelectedAbsenceRow.Item("DateFrom"), "dd/MM/yy")), CStr(Format(SelectedAbsenceRow.Item("DateTo"), "dd/MM/yy")))
                    If MessageBox.Show(str, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        DB.EngineerAbsence.Delete(CInt(SelectedAbsenceRow.Item("ID")))
                        SearchAbsences()
                    End If
                Else
                    Dim str As String = String.Format("Are you sure you want to delete user {0}'s absence from {1} to {2}?", SelectedAbsenceRow.Item("Name"), CStr(Format(SelectedAbsenceRow.Item("DateFrom"), "dd/MM/yy")), CStr(Format(SelectedAbsenceRow.Item("DateTo"), "dd/MM/yy")))
                    If MessageBox.Show(str, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        DB.UserAbsence.Delete(CInt(SelectedAbsenceRow.Item("ID")))
                        SearchAbsences()
                    End If
                End If
            End If
        Else
            ShowMessage("Please select an absence to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region


End Class
