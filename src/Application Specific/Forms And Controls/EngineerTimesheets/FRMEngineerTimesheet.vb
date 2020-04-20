Public Class FRMEngineerTimesheet : Inherits FSM.FRMBaseForm : Implements IForm


#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.TimeSheetTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)

        CurrentTimesheet = DB.EngineerTimesheets.Get(GetParameter(0))
        If GetParameter(1) = "Visit" Then
            cboType.Enabled = False
            btnFindRecord.Enabled = False
        End If
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

    Private _CurrentTimesheet As Entity.EngineerTimeSheets.EngineerTimeSheet
    Private Property CurrentTimesheet() As Entity.EngineerTimeSheets.EngineerTimeSheet
        Get
            Return _CurrentTimesheet
        End Get
        Set(ByVal value As Entity.EngineerTimeSheets.EngineerTimeSheet)
            _CurrentTimesheet = value

            If _CurrentTimesheet Is Nothing Then
                _CurrentTimesheet = New Entity.EngineerTimeSheets.EngineerTimeSheet
                _CurrentTimesheet.Exists = False
            End If

            If CurrentTimesheet.Exists Then
                Populate()
            Else
                oEngineer = Nothing
                Combo.SetSelectedComboItem_By_Value(cboType, 0)
                txtComments.Text = ""
                dtpFrom.Value = Now()
                dtpTo.Value = Now
            End If

        End Set
    End Property

    Private _oEngineer As Entity.Engineers.Engineer
    Public Property oEngineer() As Entity.Engineers.Engineer
        Get
            Return _oEngineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _oEngineer = Value
            If Not _oEngineer Is Nothing Then
                Me.txtSearch.Text = oEngineer.Name
            Else
                Me.txtSearch.Text = ""
            End If
        End Set
    End Property


#End Region

#Region "Events"

    Private Sub FRMEngineerTimesheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnFindRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRecord.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            oEngineer = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate()
        Combo.SetSelectedComboItem_By_Value(cboType, CurrentTimesheet.TimeSheetTypeID)
        oEngineer = DB.Engineer.Engineer_Get(CurrentTimesheet.EngineerID)
        txtComments.Text = CurrentTimesheet.Comments
        dtpFrom.Value = CurrentTimesheet.StartDateTime
        dtpTo.Value = CurrentTimesheet.EndDateTime
    End Sub

    Private Sub Save()
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentTimesheet.IgnoreExceptionsOnSetMethods = True

            CurrentTimesheet.SetTimeSheetTypeID = Combo.GetSelectedItemValue(cboType)

            If Not oEngineer Is Nothing Then
                CurrentTimesheet.SetEngineerID = oEngineer.EngineerID
            End If

            CurrentTimesheet.SetComments = txtComments.Text

            CurrentTimesheet.StartDateTime = dtpFrom.Value
            CurrentTimesheet.EndDateTime = dtpTo.Value
 
            Dim cV As New Entity.EngineerTimeSheets.EngineerTimeSheetValidator
            cV.Validate(CurrentTimesheet)


            If GetParameter(1) = "General" Then
                If CurrentTimesheet.Exists Then
                    DB.EngineerTimesheets.Update(CurrentTimesheet)
                Else
                    DB.EngineerTimesheets.Insert(CurrentTimesheet)
                End If
            ElseIf GetParameter(1) = "Visit" Then
                If CurrentTimesheet.Exists Then
                    DB.EngineerTimesheets.UpdateVisit(CurrentTimesheet)
                Else
                    ' DB.EngineerVisitsTimeSheet.Insert(CurrentTimesheet)
                End If

            End If



            ShowMessage("Timesheet Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

#End Region

End Class