Imports FSM.Entity.Sys
Imports FSM.Entity.Settings.Scheduler
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports FSM.Entity.EngineerRoles

Public Class FRMEngineerRolesDeleteMe

#Region "Interface Methods"

    'Public ReadOnly Property LoadedControl As IUserControl Implements IForm.LoadedControl
    '    Get
    '        Return Nothing
    '    End Get
    'End Property

    'Public Sub LoadMe(sender As Object, e As EventArgs) Implements IForm.LoadMe
    '    LoadForm(sender, e, Me)
    '    Me.PopulateEngineerRole()
    'End Sub

    'Public Sub ResetMe(newID As Integer) Implements IForm.ResetMe
    '    Throw New NotImplementedException()
    'End Sub

#End Region

#Region "Properties"

    Private _dvEngineerRole As DataView

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.PopulateEngineerRole()
    End Sub

    Private Property DvEngineerRole() As DataView
        Get
            Return _dvEngineerRole
        End Get
        Set(ByVal value As DataView)
            _dvEngineerRole = value
            _dvEngineerRole.Table.TableName = "EngineerRole"
            Me.dgrdEngineerRoles.DataSource = _dvEngineerRole
        End Set
    End Property

#End Region

#Region "Function"

    Private Sub PopulateEngineerRole()
        SetupDgrdEngineerRoles()
        Dim dt As DataTable = Helper.ToDataTable(DB.EngineerRole.GetAll())
        Dim dv As New DataView(dt)
        DvEngineerRole = dv
    End Sub

    Public Sub SaveEngineerRole()
        Try
            Dim engineerRole As New EngineerRole
            engineerRole.Name = Me.txtName.ToString.Trim()
            engineerRole.HourlyCostToCompany = Helper.MakeDoubleValid(Me.txtHourlyCostToCompany)
            engineerRole.Description = Me.txtDescription.ToString.Trim()

            engineerRole = DB.EngineerRole.Insert(engineerRole)
            If (engineerRole.Id > 0) Then
                'success => refresh grid
                Me.PopulateEngineerRole()
            Else
                ShowMessage("The operation failed. Please change name and try again!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            ShowMessage("The operation. Error: " & ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupDgrdEngineerRoles()
        Helper.SetUpDataGrid(Me.dgrdEngineerRoles)
        Dim dgts As DataGridTableStyle = Me.dgrdEngineerRoles.TableStyles(0)

        Dim roleName As New DataGridJobTypeColumn
        roleName.Format = ""
        roleName.FormatInfo = Nothing
        roleName.HeaderText = "Role Name"
        roleName.MappingName = "Name"
        roleName.ReadOnly = True
        roleName.Width = 145
        roleName.NullText = ""
        dgts.GridColumnStyles.Add(roleName)

        Dim rate As New DataGridJobTypeColumn
        rate.Format = ""
        rate.FormatInfo = Nothing
        rate.HeaderText = "Hourly Cost"
        rate.MappingName = "HourlyCostToCompany"
        rate.ReadOnly = True
        rate.Width = 100
        rate.NullText = ""
        dgts.GridColumnStyles.Add(rate)

        Dim description As New DataGridJobTypeColumn
        description.Format = ""
        description.FormatInfo = Nothing
        description.HeaderText = "Description"
        description.MappingName = "Desctription"
        description.ReadOnly = True
        description.Width = 100
        description.NullText = ""
        dgts.GridColumnStyles.Add(description)

        dgts.ReadOnly = True
        dgts.MappingName = "EngineerRole"
        Me.dgrdEngineerRoles.TableStyles.Add(dgts)
    End Sub

#End Region

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

    End Sub

End Class