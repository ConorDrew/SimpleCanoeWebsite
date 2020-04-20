Public Class FrmBlockAbsence

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadAbsencestypeComboBox()
    End Sub

    Public Event UserAbsenceChanged()

#Region "Properties"

    Private _dvEmployees As DataView

    Public Property EmployeesDataView() As DataView
        Get
            Return _dvEmployees
        End Get
        Set(ByVal Value As DataView)
            _dvEmployees = Value

            If Not EmployeesDataView Is Nothing Then
                If Not EmployeesDataView.Table Is Nothing Then
                    _dvEmployees.Table.TableName = "tblEmployees"
                    _dvEmployees.AllowNew = False
                End If
            End If
            dgEmployees.DataSource = EmployeesDataView
        End Set
    End Property

#End Region

#Region "Functions"

    Private Sub setUpDataGrid()
        SuspendLayout()

        Entity.Sys.Helper.SetUpDataGrid(dgEmployees)
        Dim ts As DataGridTableStyle = dgEmployees.TableStyles(0)

        'Set up columns
        ts.ReadOnly = False
        dgEmployees.ReadOnly = False

        Dim include As New DataGridBoolColumn
        include.HeaderText = "Include"
        include.MappingName = "Include"
        include.ReadOnly = False
        include.Width = 50
        include.AllowNull = False
        ts.GridColumnStyles.Add(include)

        Dim name As New DataGridLabelColumn
        name.Format = ""
        name.FormatInfo = Nothing
        name.HeaderText = "Name"
        name.MappingName = "Name"
        name.ReadOnly = True
        name.Width = 200
        ts.GridColumnStyles.Add(name)

        ts.MappingName = "tblEmployees"

        Me.dgEmployees.TableStyles.Add(ts)
        ResumeLayout(True)
    End Sub

    Private Sub LoadAbsencestypeComboBox()
        Dim dt As New DataTable
        dt = DB.EngineerAbsence.EngineerAbsenceTypes_GetAll

        Dim pleaseSelect As DataRow = dt.NewRow()
        pleaseSelect("Description") = "-- Please Select --"
        pleaseSelect("EngineerAbsenceTypeID") = 0
        dt.Rows.InsertAt(pleaseSelect, 0)
        dt.AcceptChanges()

        cboType.DataSource = dt

        cboType.DisplayMember = "Description"
        cboType.ValueMember = "EngineerAbsenceTypeID"
    End Sub

    Private Sub Save()
        Try

            If Not ((IsNumeric(txtStartTimeHours.Text) AndAlso txtStartTimeHours.Text >= 0 AndAlso txtStartTimeHours.Text <= 23) AndAlso
                 (IsNumeric(txtStartTimeMinutes.Text) AndAlso txtStartTimeMinutes.Text >= 0 AndAlso txtStartTimeMinutes.Text <= 59)) Then

                MessageBox.Show("Start time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Exit Sub
            End If

            If Not ((IsNumeric(txtEndTimeHours.Text) AndAlso txtEndTimeHours.Text >= 0 AndAlso txtEndTimeHours.Text <= 23) AndAlso
                (IsNumeric(txtEndTimeMinutes.Text) AndAlso txtEndTimeMinutes.Text >= 0 AndAlso txtEndTimeMinutes.Text <= 59)) Then

                MessageBox.Show("End time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Exit Sub
            End If

            Dim startTime As DateTime = New DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day,
                                                                CInt(txtStartTimeHours.Text),
                                                                 CInt(txtStartTimeMinutes.Text), 0)
            Dim endTime As DateTime = New DateTime(dtTo.Value.Year, dtTo.Value.Month, dtTo.Value.Day,
                                                           CInt(txtEndTimeHours.Text),
                                                           CInt(txtEndTimeMinutes.Text), 0)

            If DateTime.Compare(startTime, endTime) > 0 Then
                MessageBox.Show("End date can not be before start date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Exit Sub
            End If

            If cboType.SelectedValue = 0 Then
                MessageBox.Show("Please select an absence type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                Exit Sub
            End If

            Dim ua As Entity.UserAbsence.UserAbsence = Nothing
            Dim ea As Entity.EngineerAbsence.EngineerAbsence

            For Each r As DataRowView In EmployeesDataView
                If CBool(r("Include")) Then
                    If cboEmployeeGroup.Text = "Engineers" Then
                        ea = New Entity.EngineerAbsence.EngineerAbsence
                        ea.IgnoreExceptionsOnSetMethods = False
                        ea.SetComments = txtComments.Text
                        ea.SetAbsenceTypeID = cboType.SelectedValue
                        ea.SetEngineerID = CStr(r("ID"))
                        ea.DateFrom = startTime
                        ea.DateTo = endTime
                        DB.EngineerAbsence.Insert(ea)
                    Else
                        ua = New Entity.UserAbsence.UserAbsence
                        ua.IgnoreExceptionsOnSetMethods = False
                        ua.SetComments = txtComments.Text
                        ua.SetAbsenceTypeID = cboType.SelectedValue
                        ua.SetUserID = CStr(r("ID"))
                        ua.DateFrom = startTime
                        ua.DateTo = endTime
                        DB.UserAbsence.Insert(ua)
                    End If
                End If
            Next

            RaiseEvent UserAbsenceChanged()
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        Catch ex As ValidationException
            Dim msg As String = "Please correct the following errors:{0}{1}"
            msg = String.Format(msg, vbNewLine, ex.Validator.CriticalMessagesString())
            MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
        Catch ex As Exception
            MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub FrmBlockAbsence_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadForm(Me)
        setUpDataGrid()
        cboEmployeeGroup.SelectedIndex = 0
        Me.ActiveControl = cboEmployeeGroup
        cboEmployeeGroup.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub dgEmployees_Clicks(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgEmployees.Click, dgEmployees.DoubleClick
        Try
            ' this code mainly facilitates single clicks to change the state of a checkbox
            Dim includeColumn As Integer = 0
            Dim pt As Point = Me.dgEmployees.PointToClient(Control.MousePosition)
            Dim hti As DataGrid.HitTestInfo = Me.dgEmployees.HitTest(pt)
            Dim bmb As BindingManagerBase = Me.BindingContext(Me.dgEmployees.DataSource,
                                                        Me.dgEmployees.DataMember)

            If hti.Row < bmb.Count AndAlso hti.Type = DataGrid.HitTestType.Cell AndAlso hti.Column = includeColumn Then
                Dim selected As Boolean = Not CBool(Me.dgEmployees(hti.Row, includeColumn))
                Me.dgEmployees(hti.Row, includeColumn) = selected
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        Try
            If Not EmployeesDataView Is Nothing Then
                If Not EmployeesDataView.Table Is Nothing Then
                    For Each r As DataRow In EmployeesDataView.Table.Rows
                        r("Include") = True
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Try
            If Not EmployeesDataView Is Nothing Then
                If Not EmployeesDataView.Table Is Nothing Then
                    For Each r As DataRow In EmployeesDataView.Table.Rows
                        r("Include") = False
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboEmployeeGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmployeeGroup.SelectedIndexChanged
        Try
            Dim dt As New DataTable
            If cboEmployeeGroup.Text = "Engineers" Then
                dt = DB.Engineer.Engineer_GetAll.Table
                dt.Columns("EngineerID").ColumnName = "ID"

                gbEmployees.Text = "Engineers"
            Else
                dt = DB.User.GetAll.Table
                dt.Columns("Fullname").ColumnName = "Name"
                dt.Columns("UserID").ColumnName = "ID"

                gbEmployees.Text = "Users"
            End If

            Dim dc As DataColumn = New DataColumn()
            dc.DataType = GetType(System.Boolean)
            dc.DefaultValue = False
            dc.ColumnName = "Include"
            dc.ReadOnly = False

            dt.Columns.Add(dc)
            dt.TableName = "tblEmployees"
            dt.AcceptChanges()

            EmployeesDataView = New DataView(dt)
        Catch ex As Exception
            MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtEndTimeHours_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartTimeHours.TextChanged,
                                                                                                                       txtStartTimeMinutes.TextChanged,
                                                                                                                       txtEndTimeHours.TextChanged,
                                                                                                                       txtEndTimeMinutes.TextChanged

        Dim sequence As TextBox() = New TextBox() {txtStartTimeHours, txtStartTimeMinutes, txtEndTimeHours, txtEndTimeMinutes}
        Dim currentBox As TextBox = CType(sender, TextBox)

        If currentBox.Text.Length >= 2 AndAlso Array.IndexOf(sequence, currentBox) < sequence.Length - 1 Then
            sequence(Array.IndexOf(sequence, currentBox) + 1).Focus()
            sequence(Array.IndexOf(sequence, currentBox) + 1).SelectAll()

        ElseIf currentBox.Text.Length = 0 AndAlso Array.IndexOf(sequence, currentBox) - 1 >= 0 Then
            sequence(Array.IndexOf(sequence, currentBox) - 1).Focus()
            sequence(Array.IndexOf(sequence, currentBox) - 1).SelectAll()

        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim itemsSelected As Boolean = False
            If Not EmployeesDataView Is Nothing Then
                If Not EmployeesDataView.Table Is Nothing Then
                    For Each r As DataRowView In EmployeesDataView
                        If CBool(r("Include")) Then
                            itemsSelected = True
                        End If
                    Next
                End If
            End If

            If itemsSelected = False Then
                MessageBox.Show("You must select at least one employee from the list", "Selection required", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Save()
            End If
        Catch ex As Exception
            MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class