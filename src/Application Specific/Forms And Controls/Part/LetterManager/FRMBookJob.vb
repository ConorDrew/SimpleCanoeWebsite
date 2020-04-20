Public Class FRMBookJob

    Public dr As DataRow = Nothing
    Public Max As Date = Date.MaxValue
    Public dt As New DataTable
    Dim Min As Date = Today.AddDays(1)

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Combo.GetSelectedItemValue(cboAppointment) = 0 Then
            ShowMessage("Please select an AM or PM appointment ", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf dtpDate.SelectedDates.Count = 0 Then
            ShowMessage("Please select a Date ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Combo.SetUpCombo(Me.cboAppointment, DynamicDataTables.Appointments, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        dtpDate.MaxDate = Max
        dtpDate.MinDate = Min
        dtpDate.SelectDate(Today)
        dtpDate.ActiveMonth.Month = Min.Month
        dtpDate.ActiveMonth.Year = Min.Year
        Dim d(dt.Rows.Count / 2) As Pabo.Calendar.DateItem

        Dim i As Integer = 0
        Dim inarea As Integer = 0
        Dim col As Integer = 0
        For Each row As DataRow In dt.Rows

            If row("AMPM") = "AM" Then
                d(i) = New Pabo.Calendar.DateItem
                inarea = 0
                col = col + row("Avail")
                If row("Avail") > 0 Then
                    '  d(i).Text = d(i).Text & "AM"
                End If

                If row("InArea") = 1 Then
                    inarea += 1

                End If
            Else
                d(i).Date = CDate(row("Date"))

                If row("Avail") > 0 Then
                    ' d(i).Text = d(i).Text & " PM"

                End If

                col = col + row("Avail")

                Select Case col

                    Case 0
                        d(i).BackColor1 = Color.Red

                        'Case Is > 20
                        '    d(i).BackColor1 = Color.Green

                    Case Is > 10
                        d(i).BackColor1 = Color.Yellow

                    Case Is > 2
                        d(i).BackColor1 = Color.Orange

                End Select

                If row("InArea") = 1 Then
                    inarea += 1

                End If

                If inarea > 0 Then

                    d(i).BackColor1 = Color.Green

                End If

                col = 0
                i = i + 1
            End If

        Next

        dtpDate.AddDateInfo(d)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Combo.SetSelectedComboItem_By_Value(cboAppointment, "0")
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub dtpDate_MonthChanged(sender As Object, e As Pabo.Calendar.DayClickEventArgs) Handles dtpDate.DayClick

        Dim dr As DataRow() = dt.Select("Date = '" & CDate(e.Date).ToString("dd/MM/yyyy") & " 00:00:00' AND Avail > 0")
        If dr.Length > 1 Then
            ' two avaialble appointemnts
            lblMessage.Text = "AM and PM Available"
        ElseIf dr.Length > 0 AndAlso dr(0)("AMPM") = "AM" Then
            lblMessage.Text = "AM Available"
        ElseIf dr.Length > 0 AndAlso dr(0)("AMPM") = "PM" Then
            lblMessage.Text = "PM Available"
        Else
            lblMessage.Text = "No Suggested Appointments available on this day"
        End If

        Dim dr2 As DataRow() = dt.Select("Date = '" & CDate(e.Date).ToString("dd/MM/yyyy") & " 00:00:00' AND InArea = 1")
        If dr2.Length > 1 Then
            ' two avaialble appointemnts

            lblMessage.Text = "Engineer in this area AM and PM"
        ElseIf dr2.Length > 0 AndAlso dr2(0)("AMPM") = "AM" Then
            lblMessage.Text = "Engineer in this area AM"
            If dr.Length > 0 AndAlso (dr(0)("AMPM") = "PM" Or dr(1)("AMPM") = "PM") Then
                lblMessage.Text += ", PM is also Available but no close engineer"
            End If
        ElseIf dr2.Length > 0 AndAlso dr2(0)("AMPM") = "PM" Then
            lblMessage.Text = "Engineer in this area PM"
            If dr.Length > 0 AndAlso dr(0)("AMPM") = "AM" Then
                lblMessage.Text += ", AM is also Available but no close engineer"
            End If
        Else

        End If

    End Sub

End Class