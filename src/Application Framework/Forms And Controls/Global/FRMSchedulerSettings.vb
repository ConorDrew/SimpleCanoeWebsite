Imports FSM.Entity.Sys
Imports FSM.Entity.Settings.Scheduler
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection

Public Class FRMSchedulerSettings : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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

    Friend WithEvents grpJobTypeColours As GroupBox
    Friend WithEvents btnSaveJobColour As Button
    Friend WithEvents btnDeleteJobColour As Button
    Friend WithEvents cboColour As ComboBox
    Friend WithEvents lblColour As Label
    Friend WithEvents cboJobType As ComboBox
    Friend WithEvents lblJobType As Label
    Friend WithEvents dgJobTypeColours As DataGrid
    Friend WithEvents btnClose As Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobTypeColours = New System.Windows.Forms.GroupBox()
        Me.btnSaveJobColour = New System.Windows.Forms.Button()
        Me.btnDeleteJobColour = New System.Windows.Forms.Button()
        Me.cboColour = New System.Windows.Forms.ComboBox()
        Me.lblColour = New System.Windows.Forms.Label()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.dgJobTypeColours = New System.Windows.Forms.DataGrid()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpJobTypeColours.SuspendLayout()
        CType(Me.dgJobTypeColours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpJobTypeColours
        '
        Me.grpJobTypeColours.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpJobTypeColours.Controls.Add(Me.btnSaveJobColour)
        Me.grpJobTypeColours.Controls.Add(Me.btnDeleteJobColour)
        Me.grpJobTypeColours.Controls.Add(Me.cboColour)
        Me.grpJobTypeColours.Controls.Add(Me.lblColour)
        Me.grpJobTypeColours.Controls.Add(Me.cboJobType)
        Me.grpJobTypeColours.Controls.Add(Me.lblJobType)
        Me.grpJobTypeColours.Controls.Add(Me.dgJobTypeColours)
        Me.grpJobTypeColours.Location = New System.Drawing.Point(12, 57)
        Me.grpJobTypeColours.Name = "grpJobTypeColours"
        Me.grpJobTypeColours.Size = New System.Drawing.Size(316, 536)
        Me.grpJobTypeColours.TabIndex = 1
        Me.grpJobTypeColours.TabStop = False
        Me.grpJobTypeColours.Text = "Job Type Colours"
        '
        'btnSaveJobColour
        '
        Me.btnSaveJobColour.AccessibleDescription = "Save item"
        Me.btnSaveJobColour.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveJobColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveJobColour.ImageIndex = 1
        Me.btnSaveJobColour.Location = New System.Drawing.Point(7, 506)
        Me.btnSaveJobColour.Name = "btnSaveJobColour"
        Me.btnSaveJobColour.Size = New System.Drawing.Size(94, 24)
        Me.btnSaveJobColour.TabIndex = 9
        Me.btnSaveJobColour.Text = "Save"
        Me.btnSaveJobColour.UseVisualStyleBackColor = True
        '
        'btnDeleteJobColour
        '
        Me.btnDeleteJobColour.AccessibleDescription = "Save item"
        Me.btnDeleteJobColour.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteJobColour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteJobColour.ImageIndex = 1
        Me.btnDeleteJobColour.Location = New System.Drawing.Point(215, 506)
        Me.btnDeleteJobColour.Name = "btnDeleteJobColour"
        Me.btnDeleteJobColour.Size = New System.Drawing.Size(93, 24)
        Me.btnDeleteJobColour.TabIndex = 8
        Me.btnDeleteJobColour.Text = "Delete"
        Me.btnDeleteJobColour.UseVisualStyleBackColor = True
        '
        'cboColour
        '
        Me.cboColour.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboColour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboColour.FormattingEnabled = True
        Me.cboColour.Location = New System.Drawing.Point(85, 50)
        Me.cboColour.Name = "cboColour"
        Me.cboColour.Size = New System.Drawing.Size(223, 22)
        Me.cboColour.TabIndex = 7
        '
        'lblColour
        '
        Me.lblColour.AutoSize = True
        Me.lblColour.Location = New System.Drawing.Point(10, 54)
        Me.lblColour.Name = "lblColour"
        Me.lblColour.Size = New System.Drawing.Size(45, 13)
        Me.lblColour.TabIndex = 6
        Me.lblColour.Text = "Colour"
        '
        'cboJobType
        '
        Me.cboJobType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJobType.FormattingEnabled = True
        Me.cboJobType.Location = New System.Drawing.Point(85, 20)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(223, 21)
        Me.cboJobType.TabIndex = 5
        '
        'lblJobType
        '
        Me.lblJobType.AutoSize = True
        Me.lblJobType.Location = New System.Drawing.Point(10, 25)
        Me.lblJobType.Name = "lblJobType"
        Me.lblJobType.Size = New System.Drawing.Size(57, 13)
        Me.lblJobType.TabIndex = 4
        Me.lblJobType.Text = "Job Type"
        '
        'dgJobTypeColours
        '
        Me.dgJobTypeColours.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgJobTypeColours.DataMember = ""
        Me.dgJobTypeColours.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobTypeColours.Location = New System.Drawing.Point(7, 92)
        Me.dgJobTypeColours.Name = "dgJobTypeColours"
        Me.dgJobTypeColours.Size = New System.Drawing.Size(301, 408)
        Me.dgJobTypeColours.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.AccessibleDescription = "Save item"
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.ImageIndex = 1
        Me.btnClose.Location = New System.Drawing.Point(12, 599)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 26)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FRMSchedulerSettings
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(690, 636)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpJobTypeColours)
        Me.MinimumSize = New System.Drawing.Size(706, 675)
        Me.Name = "FRMSchedulerSettings"
        Me.Text = "Settings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpJobTypeColours, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.grpJobTypeColours.ResumeLayout(False)
        Me.grpJobTypeColours.PerformLayout()
        CType(Me.dgJobTypeColours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _dvJobTypeColour As DataView

    Private Property DvJobTypeColour() As DataView
        Get
            Return _dvJobTypeColour
        End Get
        Set(ByVal value As DataView)
            _dvJobTypeColour = value
            _dvJobTypeColour.Table.TableName = "JobTypeColour"
            Me.dgJobTypeColours.DataSource = DvJobTypeColour
        End Set
    End Property

    Private ReadOnly Property DrSelectedJobTypeColour() As DataRow
        Get
            If Not Me.dgJobTypeColours.CurrentRowIndex = -1 Then
                Return DvJobTypeColour(Me.dgJobTypeColours.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub FRMUserSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.SetUpCombo(Me.cboJobType, DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        SetUpColourCombo()
        SetupDgJobColours()
        PopulateJobTypeColours()
    End Sub

    Private Sub cboColour_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cboColour.DrawItem
        Dim g As Graphics = e.Graphics
        Dim rect As Rectangle = e.Bounds
        If e.Index >= 0 Then
            Dim n As String = CType(sender, ComboBox).Items(e.Index).ToString()
            Dim f As Font = New Font("Arial", 9, FontStyle.Regular)
            Dim c As Color = Color.FromName(n)
            Dim b As Brush = New SolidBrush(c)
            g.DrawString(n, f, Brushes.Black, rect.X, rect.Top)
            g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10)
        End If
    End Sub

    Private Sub btnSaveJobColour_Click(sender As Object, e As EventArgs) Handles btnSaveJobColour.Click
        SaveJobTypeColour()
    End Sub

    Private Sub btnDeleteJobColour_Click(sender As Object, e As EventArgs) Handles btnDeleteJobColour.Click
        DeleteJobTypeColour()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

#Region "Function"

    Private Sub PopulateJobTypeColours()
        SetupDgJobColours()
        Dim dt As DataTable = Helper.ToDataTable(DB.JobTypeColour.Get_All())
        Dim dv As New DataView(dt)
        DvJobTypeColour = dv
    End Sub

    Public Sub SaveJobTypeColour()
        Try
            Dim jobTypeId As Integer = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboJobType))
            If jobTypeId = 0 Or cboColour.SelectedIndex = 0 Then Exit Sub

            Dim colour As String = cboColour.SelectedItem
            Dim jtcs As List(Of JobTypeColour) = DB.JobTypeColour.Get_All()
            If jtcs IsNot Nothing Then jtcs = jtcs.Where(Function(x) x.JobTypeId = jobTypeId Or x.Colour = colour).ToList()
            If jtcs IsNot Nothing AndAlso jtcs.Count > 0 Then
                ShowMessage(jtcs.FirstOrDefault().JobType & " has a link to " & jtcs.FirstOrDefault().Colour & "!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ResetJobTypeColour()
                Exit Sub
            End If

            Dim jtc As New JobTypeColour() With {.JobTypeId = jobTypeId, .Colour = colour}
            jtc = DB.JobTypeColour.Insert(jtc)
            If jtc.Id > 0 Then ResetJobTypeColour()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DeleteJobTypeColour()
        If DrSelectedJobTypeColour Is Nothing Then
            ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            Cursor.Current = Cursors.WaitCursor
            DB.JobTypeColour.Delete(DrSelectedJobTypeColour("Id"))
            ResetJobTypeColour()
        Catch ex As Exception
            ShowMessage("Error deleting: " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub ResetJobTypeColour()
        PopulateJobTypeColours()
        Combo.SetSelectedComboItem_By_Value(cboJobType, 0)
        cboColour.SelectedIndex = 0
    End Sub

    Public Sub SetUpColourCombo()
        cboColour.Items.Clear()
        cboColour.Items.Add("-- Please Select --")

        Dim colourList As New ArrayList
        Dim colorType As Type = GetType(Color)
        Dim propInfo As PropertyInfo() = colorType.GetProperties(BindingFlags.Static Or BindingFlags.DeclaredOnly Or BindingFlags.Public)

        For Each colour As PropertyInfo In propInfo
            cboColour.Items.Add(colour.Name)
        Next
        cboColour.DisplayMember = "Description"
        cboColour.ValueMember = "Value"
        cboColour.SelectedIndex = 0
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupDgJobColours()
        Helper.SetUpDataGrid(Me.dgJobTypeColours)
        Dim dgts As DataGridTableStyle = Me.dgJobTypeColours.TableStyles(0)

        Dim jobType As New DataGridJobTypeColumn
        jobType.Format = ""
        jobType.FormatInfo = Nothing
        jobType.HeaderText = "Job Type"
        jobType.MappingName = "JobType"
        jobType.ReadOnly = True
        jobType.Width = 145
        jobType.NullText = ""
        dgts.GridColumnStyles.Add(jobType)

        Dim colour As New DataGridJobTypeColumn
        colour.Format = ""
        colour.FormatInfo = Nothing
        colour.HeaderText = "Colour"
        colour.MappingName = "Colour"
        colour.ReadOnly = True
        colour.Width = 100
        colour.NullText = ""
        dgts.GridColumnStyles.Add(colour)

        dgts.ReadOnly = True
        dgts.MappingName = "JobTypeColour"
        Me.dgJobTypeColours.TableStyles.Add(dgts)
    End Sub

#End Region

End Class