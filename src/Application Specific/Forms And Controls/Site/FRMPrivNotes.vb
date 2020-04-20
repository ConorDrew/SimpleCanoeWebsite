Public Class FRMPrivNotes

    Public dr As DataRow = Nothing
    Public Max As Date = Date.MaxValue
    Public dt As New DataTable

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Entity.Sys.Helper.SetUpDataGridView(Me.dgvNotes)
        '    dgvNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvNotes.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        dgvNotes.AutoGenerateColumns = False
        dgvNotes.Columns.Clear()
        dgvNotes.EditMode = DataGridViewEditMode.EditOnEnter

        Dim SiteID As New DataGridViewTextBoxColumn

        SiteID.Width = 1
        SiteID.DataPropertyName = "JobNoteID"
        SiteID.Name = "JobNoteID"
        SiteID.ReadOnly = True
        SiteID.Visible = False
        SiteID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvNotes.Columns.Add(SiteID)

        Dim Code As New DataGridViewTextBoxColumn

        Code.Width = 110
        Code.DataPropertyName = "JobNumber"
        Code.Name = "JobNumber"
        Code.ReadOnly = True
        Code.Visible = True
        Code.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvNotes.Columns.Add(Code)

        Dim Description As New DataGridViewTextBoxColumn

        Description.Width = 600
        Description.DataPropertyName = "Note"
        Description.Name = "Note"
        Description.ReadOnly = True
        Description.Visible = True
        Description.SortMode = DataGridViewColumnSortMode.Programmatic
        '  Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        dgvNotes.Columns.Add(Description)

        Dim Qty As New DataGridViewTextBoxColumn

        Qty.Width = 130
        Qty.DataPropertyName = "LastEdited"
        Qty.Name = "LastEdited"
        Qty.HeaderText = "Last Edited"
        Qty.ReadOnly = True
        Qty.Visible = True
        Qty.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvNotes.Columns.Add(Qty)

        Dim Time As New DataGridViewTextBoxColumn

        Time.Width = 145
        Time.DataPropertyName = "EditedBy"
        Time.HeaderText = "Edited By"
        Time.Name = "EditedBy"
        Time.ReadOnly = True
        Time.Visible = True
        Time.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvNotes.Columns.Add(Time)

        dgvNotes.DataSource = dt

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim dr As DataRow = dt.NewRow

        dr(0) = 0
        dr(1) = loggedInUser.UserID
        dr(2) = loggedInUser.UserID
        dr(3) = txtEngineernotes.Text
        dr(4) = Date.Now
        dr(5) = loggedInUser.Username
        dr(6) = Date.Now
        dr(7) = loggedInUser.Username
        dr(8) = 0
        dr(9) = "New.."
        dr(10) = 0

        dt.Rows.InsertAt(dr, 0)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If

    End Sub

End Class