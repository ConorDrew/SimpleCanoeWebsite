Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Sys

Public Class FrmDisplayEngineers
    Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Combo.SetUpCombo(Me.cboEngineerGroup, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.EngineerGroup, True).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboRegionID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions, True).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        If IsGasway Then
            Me.lblQualification.Text = "Qualifications"
        ElseIf IsRFT Then
            Me.lblQualification.Text = "Trades"
        End If

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
    Friend WithEvents grpMain As System.Windows.Forms.GroupBox

    Friend WithEvents dgEngineers As System.Windows.Forms.DataGrid
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents cboEngineerGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblEngineerName As Label
    Friend WithEvents txtNameFilter As TextBox
    Friend WithEvents cboRegionID As ComboBox
    Friend WithEvents lblRegion As Label
    Friend WithEvents txtPostcodeFilter As TextBox
    Friend WithEvents lblPostcode As Label
    Friend WithEvents btnClearFilters As Button
    Friend WithEvents txtQualificationFilter As TextBox
    Friend WithEvents lblQualification As Label
    Friend WithEvents btnOk As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpMain = New System.Windows.Forms.GroupBox()
        Me.txtQualificationFilter = New System.Windows.Forms.TextBox()
        Me.lblQualification = New System.Windows.Forms.Label()
        Me.btnClearFilters = New System.Windows.Forms.Button()
        Me.cboRegionID = New System.Windows.Forms.ComboBox()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.txtPostcodeFilter = New System.Windows.Forms.TextBox()
        Me.lblPostcode = New System.Windows.Forms.Label()
        Me.txtNameFilter = New System.Windows.Forms.TextBox()
        Me.lblEngineerName = New System.Windows.Forms.Label()
        Me.cboEngineerGroup = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.dgEngineers = New System.Windows.Forms.DataGrid()
        Me.grpMain.SuspendLayout()
        CType(Me.dgEngineers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpMain
        '
        Me.grpMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMain.Controls.Add(Me.txtQualificationFilter)
        Me.grpMain.Controls.Add(Me.lblQualification)
        Me.grpMain.Controls.Add(Me.btnClearFilters)
        Me.grpMain.Controls.Add(Me.cboRegionID)
        Me.grpMain.Controls.Add(Me.lblRegion)
        Me.grpMain.Controls.Add(Me.txtPostcodeFilter)
        Me.grpMain.Controls.Add(Me.lblPostcode)
        Me.grpMain.Controls.Add(Me.txtNameFilter)
        Me.grpMain.Controls.Add(Me.lblEngineerName)
        Me.grpMain.Controls.Add(Me.cboEngineerGroup)
        Me.grpMain.Controls.Add(Me.Label24)
        Me.grpMain.Controls.Add(Me.btnOk)
        Me.grpMain.Controls.Add(Me.btnClearAll)
        Me.grpMain.Controls.Add(Me.btnSelectAll)
        Me.grpMain.Controls.Add(Me.dgEngineers)
        Me.grpMain.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.grpMain.Location = New System.Drawing.Point(8, 32)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(661, 529)
        Me.grpMain.TabIndex = 10
        Me.grpMain.TabStop = False
        Me.grpMain.Text = "Engineers to Display"
        '
        'txtQualificationFilter
        '
        Me.txtQualificationFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQualificationFilter.Location = New System.Drawing.Point(121, 93)
        Me.txtQualificationFilter.Name = "txtQualificationFilter"
        Me.txtQualificationFilter.Size = New System.Drawing.Size(426, 20)
        Me.txtQualificationFilter.TabIndex = 5
        '
        'lblQualification
        '
        Me.lblQualification.Location = New System.Drawing.Point(9, 93)
        Me.lblQualification.Name = "lblQualification"
        Me.lblQualification.Size = New System.Drawing.Size(93, 20)
        Me.lblQualification.TabIndex = 57
        Me.lblQualification.Text = "Qualification"
        '
        'btnClearFilters
        '
        Me.btnClearFilters.Location = New System.Drawing.Point(553, 93)
        Me.btnClearFilters.Name = "btnClearFilters"
        Me.btnClearFilters.Size = New System.Drawing.Size(99, 23)
        Me.btnClearFilters.TabIndex = 6
        Me.btnClearFilters.Text = "Clear Filters"
        Me.btnClearFilters.UseVisualStyleBackColor = True
        '
        'cboRegionID
        '
        Me.cboRegionID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRegionID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRegionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegionID.Location = New System.Drawing.Point(121, 62)
        Me.cboRegionID.Name = "cboRegionID"
        Me.cboRegionID.Size = New System.Drawing.Size(188, 21)
        Me.cboRegionID.TabIndex = 3
        Me.cboRegionID.Tag = ""
        '
        'lblRegion
        '
        Me.lblRegion.Location = New System.Drawing.Point(9, 64)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(105, 20)
        Me.lblRegion.TabIndex = 54
        Me.lblRegion.Text = "Region"
        '
        'txtPostcodeFilter
        '
        Me.txtPostcodeFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostcodeFilter.Location = New System.Drawing.Point(433, 62)
        Me.txtPostcodeFilter.Name = "txtPostcodeFilter"
        Me.txtPostcodeFilter.Size = New System.Drawing.Size(219, 20)
        Me.txtPostcodeFilter.TabIndex = 4
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(327, 62)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(93, 20)
        Me.lblPostcode.TabIndex = 52
        Me.lblPostcode.Text = "Postcode"
        '
        'txtNameFilter
        '
        Me.txtNameFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNameFilter.Location = New System.Drawing.Point(433, 34)
        Me.txtNameFilter.Name = "txtNameFilter"
        Me.txtNameFilter.Size = New System.Drawing.Size(219, 20)
        Me.txtNameFilter.TabIndex = 2
        '
        'lblEngineerName
        '
        Me.lblEngineerName.Location = New System.Drawing.Point(327, 34)
        Me.lblEngineerName.Name = "lblEngineerName"
        Me.lblEngineerName.Size = New System.Drawing.Size(105, 20)
        Me.lblEngineerName.TabIndex = 48
        Me.lblEngineerName.Text = "Engineer Name"
        '
        'cboEngineerGroup
        '
        Me.cboEngineerGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEngineerGroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboEngineerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEngineerGroup.Location = New System.Drawing.Point(121, 32)
        Me.cboEngineerGroup.Name = "cboEngineerGroup"
        Me.cboEngineerGroup.Size = New System.Drawing.Size(188, 21)
        Me.cboEngineerGroup.TabIndex = 1
        Me.cboEngineerGroup.Tag = ""
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(9, 34)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 20)
        Me.Label24.TabIndex = 47
        Me.Label24.Text = "Engineer Group"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnOk.Location = New System.Drawing.Point(588, 495)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(64, 23)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearAll.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClearAll.Location = New System.Drawing.Point(80, 495)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(64, 23)
        Me.btnClearAll.TabIndex = 8
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSelectAll.Location = New System.Drawing.Point(10, 495)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(64, 23)
        Me.btnSelectAll.TabIndex = 7
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'dgEngineers
        '
        Me.dgEngineers.DataMember = ""
        Me.dgEngineers.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEngineers.Location = New System.Drawing.Point(10, 128)
        Me.dgEngineers.Name = "dgEngineers"
        Me.dgEngineers.Size = New System.Drawing.Size(645, 353)
        Me.dgEngineers.TabIndex = 50
        Me.dgEngineers.TabStop = False
        '
        'FrmDisplayEngineers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(672, 562)
        Me.Controls.Add(Me.grpMain)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(688, 601)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(688, 601)
        Me.Name = "FrmDisplayEngineers"
        Me.Text = "Display Engineers"
        Me.Controls.SetChildIndex(Me.grpMain, 0)
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        CType(Me.dgEngineers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

    Dim engineersPostcodes As String
    Dim engineersPostcodesList As List(Of String)
    Dim engineersQualifications As String
    Dim engineersQualificationsList As List(Of String)

    Private _dvEngineer As DataView

    Public Property EngineersDataView() As DataView
        Get
            Return _dvEngineer
        End Get
        Set(ByVal Value As DataView)
            _dvEngineer = Value

            If Not EngineersDataView Is Nothing Then
                _dvEngineer.AllowNew = False
                _dvEngineer.AllowEdit = True
                _dvEngineer.AllowDelete = False
                _dvEngineer.Table.TableName = "tblEngineers"
            End If

            dgEngineers.DataSource = EngineersDataView

        End Set
    End Property

    Private ReadOnly Property SelectedEngineerDataRow() As DataRow
        Get
            If EngineersDataView Is Nothing Then
                Return Nothing
            End If
            If Not Me.dgEngineers.CurrentRowIndex = -1 Then
                Return EngineersDataView(Me.dgEngineers.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Functions"

    Private Sub SetUpDataGrid()
        SuspendLayout()

        Dim tsEngineers As DataGridTableStyle = dgEngineers.TableStyles(0)
        Dim include As New DataGridBoolColumn
        include.HeaderText = "Include"
        include.MappingName = "Include"
        include.ReadOnly = False
        include.Width = 50
        include.AllowNull = False
        tsEngineers.GridColumnStyles.Add(include)

        Dim engineerID As New DataGridLabelColumn
        engineerID.Format = ""
        engineerID.FormatInfo = Nothing
        engineerID.HeaderText = "Engineer ID"
        engineerID.MappingName = "EngineerID"
        engineerID.ReadOnly = True
        engineerID.Width = 75
        tsEngineers.GridColumnStyles.Add(engineerID)

        Dim engineerName As New DataGridLabelColumn
        engineerName.Format = ""
        engineerName.FormatInfo = Nothing
        engineerName.HeaderText = "Engineer Name"
        engineerName.MappingName = "Name"
        engineerName.ReadOnly = True
        engineerName.Width = 200
        tsEngineers.GridColumnStyles.Add(engineerName)

        Dim Department As New DataGridLabelColumn
        Department.Format = ""
        Department.FormatInfo = Nothing
        Department.HeaderText = "Department"
        Department.MappingName = "Department"
        Department.ReadOnly = True
        Department.Width = 80
        tsEngineers.GridColumnStyles.Add(Department)

        Dim Region As New DataGridLabelColumn
        Region.Format = ""
        Region.FormatInfo = Nothing
        Region.HeaderText = "Region"
        Region.MappingName = "Region"
        Region.ReadOnly = True
        Region.Width = 200
        tsEngineers.GridColumnStyles.Add(Region)

        tsEngineers.ReadOnly = True
        tsEngineers.MappingName = "tblEngineers"

        Me.dgEngineers.TableStyles.Add(tsEngineers)

    End Sub

#End Region

#Region "Events"

    Private Sub dgEngineers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgEngineers.Click

        If SelectedEngineerDataRow Is Nothing Then
            ShowMessage("Please select a engineer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        SelectedEngineerDataRow.Item("Include") = If(SelectedEngineerDataRow.Item("Include") = True, False, True)
    End Sub

    Private Sub dgEngineers_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgEngineers.MouseDoubleClick
        Dim currentDataGrid As DataGrid = CType(sender, DataGrid)
        Dim hitTestInfo As DataGrid.HitTestInfo = currentDataGrid.HitTest(e.X, e.Y)

        If hitTestInfo.Type <> DataGrid.HitTestType.ColumnHeader Then
            If SelectedEngineerDataRow IsNot Nothing Then
                Dim dtEngineer As DataTable = SelectedEngineerDataRow.Table.Clone
                dtEngineer.Rows.Add(SelectedEngineerDataRow.ItemArray)

                Using frmViewEngineer As New FRMViewEngineer(dtEngineer)
                    frmViewEngineer.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        SelectAllTicks()
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        ClearTicks()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Close()
    End Sub

    Private Sub FrmDisplayEngineers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(Me)
        SetUpDataGrid()
        txtNameFilter.Select()
        Populate()
    End Sub

    Private Sub cboEngineerGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEngineerGroup.SelectedIndexChanged
        Try
            If IsRFT Then
                Filter()
            Else
                ClearTicks()
                Dim engineerGroupID As Integer = 0
                engineerGroupID = Combo.GetSelectedItemValue(cboEngineerGroup)

                If engineerGroupID > 0 Then
                    If EngineersDataView IsNot Nothing Then
                        If EngineersDataView.Table IsNot Nothing Then
                            Filter()
                            For Each r As DataRow In EngineersDataView.Table.Rows
                                If CInt(r("EngineerGroupID")) = engineerGroupID Then
                                    r("Include") = True
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub filterChange(sender As Object, e As EventArgs) Handles cboRegionID.SelectedIndexChanged, txtNameFilter.TextChanged, txtPostcodeFilter.TextChanged, txtQualificationFilter.TextChanged
        If Not EngineersDataView Is Nothing Then
            If Not EngineersDataView.Table Is Nothing Then
                Filter()
            End If
        End If
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        Reset_filters()
        ClearTicks()
    End Sub

#End Region

#Region "Functions"

    Private Sub Reset_filters()
        Me.txtPostcodeFilter.Text = ""
        Me.txtNameFilter.Text = ""
        Me.txtQualificationFilter.Text = ""
        Combo.SetSelectedComboItem_By_Value(Me.cboEngineerGroup, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboRegionID, 0)
    End Sub

    Private Sub ClearTicks()
        If EngineersDataView IsNot Nothing Then
            If EngineersDataView.Table IsNot Nothing Then
                For Each r As DataRow In EngineersDataView.Table.Rows
                    r("Include") = False
                Next
            End If
        End If
    End Sub

    Private Sub SelectAllTicks()
        If EngineersDataView IsNot Nothing Then
            If EngineersDataView.Table IsNot Nothing Then
                For Each r As DataRowView In EngineersDataView
                    r.BeginEdit()
                    r("Include") = True
                    r.EndEdit()
                Next
            End If
        End If
    End Sub

    Private Sub Populate()
        engineersPostcodes = String.Join(",", (From x In EngineersDataView.Table.AsEnumerable Select x("PostCodes")).ToArray)
        engineersPostcodesList = engineersPostcodes.ToLower().Split(",").[Select](Function(x) x.Trim()).Distinct().ToList()
        engineersQualifications = String.Join(",", (From x In EngineersDataView.Table.AsEnumerable Select x("Qualifications")).ToArray)
        engineersQualificationsList = engineersQualifications.ToLower().Split(",").[Select](Function(x) x.Trim()).Distinct().ToList()
    End Sub

    Private Sub Filter()
        Dim regionFilter As String = String.Empty
        Dim regionId As Integer = Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboRegionID))
        If regionId > 0 Then
            regionFilter = " AND RegionID = " & regionId
        End If

        Dim postcodeFilter As String = String.Empty
        Dim engineerIds As New List(Of Integer)
        If Not Helper.IsStringEmpty(txtPostcodeFilter.Text) Then

            Dim searchPostcodes As List(Of String) = txtPostcodeFilter.Text.ToLower().Split(",").[Select](Function(x) x.Trim()).ToList()
            Dim countOfSearchPostcodes As Integer = 0
            For Each postcode As String In searchPostcodes
                Dim match As Boolean = engineersPostcodesList.Where(Function(x) x.ToString() = postcode).Any()
                If match AndAlso Not Helper.IsStringEmpty(postcode) Then
                    countOfSearchPostcodes += 1
                End If
            Next

            For Each dr As DataRow In EngineersDataView.Table.Rows
                Dim postcodes As List(Of String) = Helper.MakeStringValid(dr("PostCodes")).ToLower().Split(",").[Select](Function(x) x.Trim()).Distinct().ToList()
                Dim countOfMatches As Integer = 0
                For Each postcode As String In searchPostcodes
                    Dim match As Boolean = postcodes.Where(Function(x) x.ToString() = postcode).Any()
                    If match AndAlso Not Helper.IsStringEmpty(postcode) Then
                        countOfMatches += 1
                    End If
                Next

                If countOfMatches > 0 AndAlso countOfMatches = countOfSearchPostcodes Then
                    engineerIds.Add(Helper.MakeIntegerValid(dr("EngineerID")))
                End If
            Next

            If engineerIds.Count > 0 Then
                postcodeFilter = " AND EngineerID IN (" & String.Join(",", engineerIds.ToArray()) & ")"
            End If
        End If

        Dim qualificationsFilter As String = String.Empty
        Dim engineerQualIds As New List(Of Integer)
        If Not Helper.IsStringEmpty(txtQualificationFilter.Text) Then

            Dim searchQualifications As List(Of String) = txtQualificationFilter.Text.ToLower().Split(",").[Select](Function(x) x.Trim()).ToList()
            Dim countOfSearchQualifications As Integer = 0

            For Each Qualifications As String In searchQualifications
                Dim match As Boolean = engineersQualificationsList.Where(Function(x) x.ToString() = Qualifications).Any()
                If match AndAlso Not Helper.IsStringEmpty(Qualifications) Then
                    countOfSearchQualifications += 1
                End If
            Next

            For Each dr As DataRow In EngineersDataView.Table.Rows
                Dim Qualifications As List(Of String) = Helper.MakeStringValid(dr("Qualifications")).ToLower().Split(",").[Select](Function(x) x.Trim()).Distinct().ToList()
                Dim countOfMatches As Integer = 0
                For Each Qual As String In searchQualifications
                    Dim match As Boolean = Qualifications.Where(Function(x) x.ToString() = Qual).Any()
                    If match AndAlso Not Helper.IsStringEmpty(Qual) Then
                        countOfMatches += 1
                    End If
                Next

                If countOfMatches > 0 AndAlso countOfMatches = countOfSearchQualifications Then
                    engineerQualIds.Add(Helper.MakeIntegerValid(dr("EngineerID")))
                End If
            Next

            If engineerQualIds.Count > 0 Then
                qualificationsFilter = " AND EngineerID IN (" & String.Join(",", engineerQualIds.ToArray()) & ")"
            End If

        End If

        Dim engineerGroup As String = String.Empty
        Dim engineerGroupId As Integer = Combo.GetSelectedItemValue(cboEngineerGroup)

        If (IsRFT Or IsBlueflame) AndAlso engineerGroupId > 0 Then
            engineerGroup = " AND EngineerGroupID = " & Combo.GetSelectedItemValue(cboEngineerGroup)
        End If

        Dim filter As String = "Name LIKE '%" & Helper.RemoveSpecialCharacters(Me.txtNameFilter.Text) & "%'" & regionFilter & postcodeFilter & qualificationsFilter & engineerGroup

        EngineersDataView.RowFilter = filter

        Me.grpMain.Text = "Engineers to Display (" & EngineersDataView.Count & ")"
    End Sub

#End Region

End Class