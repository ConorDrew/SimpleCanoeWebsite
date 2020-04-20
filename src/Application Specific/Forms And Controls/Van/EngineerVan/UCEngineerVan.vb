Public Class UCEngineerVan : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Combo.SetUpCombo(Me.cboEngineerID, DB.Engineer.Engineer_GetAll_IncludeDeleted().Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    'UserControl overrides dispose to clean up the component list.
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

    Friend WithEvents grpEngineerVan As System.Windows.Forms.GroupBox
    Friend WithEvents cboEngineerID As System.Windows.Forms.ComboBox
    Friend WithEvents lblEngineerID As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents chkUntilFurtherNotice As System.Windows.Forms.CheckBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpEngineerVan = New System.Windows.Forms.GroupBox()
        Me.chkUntilFurtherNotice = New System.Windows.Forms.CheckBox()
        Me.cboEngineerID = New System.Windows.Forms.ComboBox()
        Me.lblEngineerID = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.grpEngineerVan.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpEngineerVan
        '
        Me.grpEngineerVan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineerVan.Controls.Add(Me.chkUntilFurtherNotice)
        Me.grpEngineerVan.Controls.Add(Me.cboEngineerID)
        Me.grpEngineerVan.Controls.Add(Me.lblEngineerID)
        Me.grpEngineerVan.Controls.Add(Me.dtpStartDateTime)
        Me.grpEngineerVan.Controls.Add(Me.lblStartDateTime)
        Me.grpEngineerVan.Controls.Add(Me.dtpEndDateTime)
        Me.grpEngineerVan.Controls.Add(Me.lblEndDateTime)
        Me.grpEngineerVan.Location = New System.Drawing.Point(8, 8)
        Me.grpEngineerVan.Name = "grpEngineerVan"
        Me.grpEngineerVan.Size = New System.Drawing.Size(601, 114)
        Me.grpEngineerVan.TabIndex = 1
        Me.grpEngineerVan.TabStop = False
        Me.grpEngineerVan.Text = "Main Details"
        '
        'chkUntilFurtherNotice
        '
        Me.chkUntilFurtherNotice.Location = New System.Drawing.Point(408, 88)
        Me.chkUntilFurtherNotice.Name = "chkUntilFurtherNotice"
        Me.chkUntilFurtherNotice.Size = New System.Drawing.Size(136, 24)
        Me.chkUntilFurtherNotice.TabIndex = 5
        Me.chkUntilFurtherNotice.Text = "Until Further Notice"
        '
        'cboEngineerID
        '
        Me.cboEngineerID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEngineerID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboEngineerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEngineerID.Location = New System.Drawing.Point(112, 24)
        Me.cboEngineerID.Name = "cboEngineerID"
        Me.cboEngineerID.Size = New System.Drawing.Size(480, 21)
        Me.cboEngineerID.TabIndex = 2
        Me.cboEngineerID.Tag = "EngineerVan.EngineerID"
        '
        'lblEngineerID
        '
        Me.lblEngineerID.Location = New System.Drawing.Point(8, 24)
        Me.lblEngineerID.Name = "lblEngineerID"
        Me.lblEngineerID.Size = New System.Drawing.Size(71, 20)
        Me.lblEngineerID.TabIndex = 31
        Me.lblEngineerID.Text = "Engineer"
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMMM yyyy HH:mm"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(112, 56)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.Size = New System.Drawing.Size(184, 21)
        Me.dtpStartDateTime.TabIndex = 3
        Me.dtpStartDateTime.Tag = "EngineerVan.StartDateTime"
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(8, 56)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(104, 20)
        Me.lblStartDateTime.TabIndex = 31
        Me.lblStartDateTime.Text = "Start Date Time"
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMMM yyyy HH:mm"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(408, 56)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.Size = New System.Drawing.Size(184, 21)
        Me.dtpEndDateTime.TabIndex = 4
        Me.dtpEndDateTime.Tag = "EngineerVan.EndDateTime"
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(304, 56)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(96, 20)
        Me.lblEndDateTime.TabIndex = 31
        Me.lblEndDateTime.Text = "End Date Time"
        '
        'UCEngineerVan
        '
        Me.Controls.Add(Me.grpEngineerVan)
        Me.Name = "UCEngineerVan"
        Me.Size = New System.Drawing.Size(616, 136)
        Me.grpEngineerVan.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentEngineerVan
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _VanID As Integer = 0

    Public Property VanID() As Integer
        Get
            Return _VanID
        End Get
        Set(ByVal Value As Integer)
            _VanID = Value
        End Set
    End Property

    Private _currentEngineerVan As Entity.EngineerVans.EngineerVan

    Public Property CurrentEngineerVan() As Entity.EngineerVans.EngineerVan
        Get
            Return _currentEngineerVan
        End Get
        Set(ByVal Value As Entity.EngineerVans.EngineerVan)
            _currentEngineerVan = Value

            If CurrentEngineerVan Is Nothing Then
                CurrentEngineerVan = New Entity.EngineerVans.EngineerVan
                CurrentEngineerVan.Exists = False
            End If

            If CurrentEngineerVan.Exists Then
                Populate()
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCEngineerVan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub chkUntilFurtherNotice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUntilFurtherNotice.CheckedChanged
        Me.dtpEndDateTime.Enabled = Not Me.chkUntilFurtherNotice.Checked
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentEngineerVan = DB.EngineerVan.EngineerVan_Get(ID)
        End If

        Combo.SetSelectedComboItem_By_Value(Me.cboEngineerID, CurrentEngineerVan.EngineerID)
        Me.dtpStartDateTime.Value = CurrentEngineerVan.StartDateTime
        If CurrentEngineerVan.EndDateTime = Nothing Then
            Me.chkUntilFurtherNotice.Checked = True
            Me.dtpEndDateTime.Value = Now
        Else
            Me.chkUntilFurtherNotice.Checked = False
            Me.dtpEndDateTime.Value = CurrentEngineerVan.EndDateTime
        End If
        Me.dtpEndDateTime.Enabled = Not Me.chkUntilFurtherNotice.Checked
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentEngineerVan.IgnoreExceptionsOnSetMethods = True

            CurrentEngineerVan.SetEngineerID = Combo.GetSelectedItemValue(Me.cboEngineerID)
            CurrentEngineerVan.SetVanID = VanID
            CurrentEngineerVan.StartDateTime = Me.dtpStartDateTime.Value

            If Me.chkUntilFurtherNotice.Checked Or Me.dtpEndDateTime.Value > Date.Now Then
                If Me.chkUntilFurtherNotice.Checked Then
                    CurrentEngineerVan.EndDateTime = Nothing
                Else
                    CurrentEngineerVan.EndDateTime = Me.dtpEndDateTime.Value
                End If

                Dim dvCurrentEngineersOnVan As DataView = DB.EngineerVan.EngineerVan_GetAll_For_Van(VanID)
                Dim drActiveEngineers As DataRow() = dvCurrentEngineersOnVan.Table.Select("EnddateTime > '" & Date.Now & "' Or EnddateTime Is null")

                If drActiveEngineers.Length > 0 Then
                    Dim Message As String = "There is currently an engineer assigned to this profile, by adding this engineer you will be removing the current engineer assigned, would you like to continue?"
                    If ShowMessage(Message, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Return False
                    Else
                        For Each drActiveEngineer As DataRow In drActiveEngineers
                            Dim engineerVanId As Integer = Entity.Sys.Helper.MakeIntegerValid(drActiveEngineer("EngineerVanID"))
                            If engineerVanId > 0 Then
                                Dim activeEngineerVan As Entity.EngineerVans.EngineerVan = DB.EngineerVan.EngineerVan_Get(engineerVanId)
                                activeEngineerVan.EndDateTime = Date.Now
                                DB.EngineerVan.Update(activeEngineerVan)
                            End If
                        Next

                    End If
                End If
            Else
                CurrentEngineerVan.EndDateTime = Me.dtpEndDateTime.Value
            End If

            Dim cV As New Entity.EngineerVans.EngineerVanValidator
            cV.Validate(CurrentEngineerVan)

            If CurrentEngineerVan.Exists Then
                DB.EngineerVan.Update(CurrentEngineerVan)
                If CurrentEngineerVan.StartDateTime < Date.Now.AddDays(2) Then

                    If DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID > 0 AndAlso DB.User.Get(DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID).EmailAddress.Length > 2 Then
                        Email(Entity.Sys.EmailAddress.StockFinancials, "The engineer (" & DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).Name & ") has been deactivated On the van " & DB.Van.Van_Get(CurrentEngineerVan.VanID).Registration, loggedInUser.Fullname, DB.User.Get(DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID).EmailAddress)
                    Else
                        Email(Entity.Sys.EmailAddress.StockFinancials, "A New engineer (" & DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).Name & ") has been deactivated On the van " & DB.Van.Van_Get(CurrentEngineerVan.VanID).Registration & "", loggedInUser.Fullname, "")
                    End If

                End If
            Else
                CurrentEngineerVan = DB.EngineerVan.Insert(CurrentEngineerVan)

                If DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID > 0 AndAlso DB.User.Get(DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID).EmailAddress.Length > 2 Then
                    Email(Entity.Sys.EmailAddress.StockFinancials, "A New engineer (" & DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).Name & ") has been added To van " & DB.Van.Van_Get(CurrentEngineerVan.VanID).Registration, loggedInUser.Fullname, DB.User.Get(DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID).EmailAddress)
                Else
                    Email(Entity.Sys.EmailAddress.StockFinancials, "A New engineer (" & DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).Name & ") has been added To van " & DB.Van.Van_Get(CurrentEngineerVan.VanID).Registration, loggedInUser.Fullname, "")
                End If
            End If

            RaiseEvent StateChanged(CurrentEngineerVan.EngineerVanID)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub Email(ByVal emailadd As String, ByVal message As String, ByVal addinguser As String, ByVal cc As String)

        Dim PersonName As String = Nothing
        Dim GreetingPart As String = Nothing

        Dim FeedbackEmail As New Entity.Sys.Emails
        FeedbackEmail.From = Entity.Sys.EmailAddress.Gabriel
        FeedbackEmail.To = emailadd

        FeedbackEmail.CC = cc

        FeedbackEmail.Subject = "An Engineer to van link has been modified"
        FeedbackEmail.Body = "<span style='font-family: Calibri, Sans-Serif'>" &
            "<p>Hi</p>" &
            "<p>User : " & addinguser & " has modified an engineer to van link</p>" &
            "<p>" & message & "</p>" &
            "<p>King Regards,</p>" &
            "<p>" & TheSystem.Configuration.CompanyName & "</p>" &
            "</span>"

        FeedbackEmail.SendMe = True
        If FeedbackEmail.Send() Then

        End If

    End Sub

#End Region

End Class