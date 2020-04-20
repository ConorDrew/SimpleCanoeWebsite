Public Class UCDocuments : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboDocumentTypeID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.DocumentTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
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

    Friend WithEvents grpDocuments As System.Windows.Forms.GroupBox
    Friend WithEvents lblTableEnumID As System.Windows.Forms.Label
    Friend WithEvents cboDocumentTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDocumentTypeID As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtDocumentName As System.Windows.Forms.TextBox
    Friend WithEvents lblAddedBy As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdated As System.Windows.Forms.Label
    Friend WithEvents btnOpen As System.Windows.Forms.Button


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpDocuments = New System.Windows.Forms.GroupBox
        Me.btnOpen = New System.Windows.Forms.Button
        Me.lblLastUpdated = New System.Windows.Forms.Label
        Me.lblAddedBy = New System.Windows.Forms.Label
        Me.txtDocumentName = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.lblTableEnumID = New System.Windows.Forms.Label
        Me.cboDocumentTypeID = New System.Windows.Forms.ComboBox
        Me.lblDocumentTypeID = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.lblNotes = New System.Windows.Forms.Label
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.lblLocation = New System.Windows.Forms.Label
        Me.grpDocuments.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDocuments
        '
        Me.grpDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDocuments.Controls.Add(Me.btnOpen)
        Me.grpDocuments.Controls.Add(Me.lblLastUpdated)
        Me.grpDocuments.Controls.Add(Me.lblAddedBy)
        Me.grpDocuments.Controls.Add(Me.txtDocumentName)
        Me.grpDocuments.Controls.Add(Me.btnBrowse)
        Me.grpDocuments.Controls.Add(Me.lblTableEnumID)
        Me.grpDocuments.Controls.Add(Me.cboDocumentTypeID)
        Me.grpDocuments.Controls.Add(Me.lblDocumentTypeID)
        Me.grpDocuments.Controls.Add(Me.txtName)
        Me.grpDocuments.Controls.Add(Me.lblName)
        Me.grpDocuments.Controls.Add(Me.txtNotes)
        Me.grpDocuments.Controls.Add(Me.lblNotes)
        Me.grpDocuments.Controls.Add(Me.txtLocation)
        Me.grpDocuments.Controls.Add(Me.lblLocation)
        Me.grpDocuments.Location = New System.Drawing.Point(8, 8)
        Me.grpDocuments.Name = "grpDocuments"
        Me.grpDocuments.Size = New System.Drawing.Size(636, 533)
        Me.grpDocuments.TabIndex = 1
        Me.grpDocuments.TabStop = False
        Me.grpDocuments.Text = "Main Details"
        '
        'btnOpen
        '
        Me.btnOpen.AccessibleDescription = "Open Document"
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Location = New System.Drawing.Point(539, 417)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(88, 23)
        Me.btnOpen.TabIndex = 8
        Me.btnOpen.Text = "Open"
        '
        'lblLastUpdated
        '
        Me.lblLastUpdated.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastUpdated.ForeColor = System.Drawing.Color.Blue
        Me.lblLastUpdated.Location = New System.Drawing.Point(128, 499)
        Me.lblLastUpdated.Name = "lblLastUpdated"
        Me.lblLastUpdated.Size = New System.Drawing.Size(499, 24)
        Me.lblLastUpdated.TabIndex = 33
        '
        'lblAddedBy
        '
        Me.lblAddedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAddedBy.ForeColor = System.Drawing.Color.Blue
        Me.lblAddedBy.Location = New System.Drawing.Point(128, 459)
        Me.lblAddedBy.Name = "lblAddedBy"
        Me.lblAddedBy.Size = New System.Drawing.Size(499, 24)
        Me.lblAddedBy.TabIndex = 32
        '
        'txtDocumentName
        '
        Me.txtDocumentName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDocumentName.Location = New System.Drawing.Point(128, 418)
        Me.txtDocumentName.Name = "txtDocumentName"
        Me.txtDocumentName.ReadOnly = True
        Me.txtDocumentName.Size = New System.Drawing.Size(403, 21)
        Me.txtDocumentName.TabIndex = 7
        Me.txtDocumentName.Tag = ""
        '
        'btnBrowse
        '
        Me.btnBrowse.AccessibleDescription = "Find Document To Upload"
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(539, 386)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(88, 23)
        Me.btnBrowse.TabIndex = 6
        Me.btnBrowse.Text = "Browse"
        '
        'lblTableEnumID
        '
        Me.lblTableEnumID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTableEnumID.ForeColor = System.Drawing.Color.Blue
        Me.lblTableEnumID.Location = New System.Drawing.Point(8, 28)
        Me.lblTableEnumID.Name = "lblTableEnumID"
        Me.lblTableEnumID.Size = New System.Drawing.Size(616, 20)
        Me.lblTableEnumID.TabIndex = 31
        '
        'cboDocumentTypeID
        '
        Me.cboDocumentTypeID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDocumentTypeID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDocumentTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocumentTypeID.Location = New System.Drawing.Point(128, 59)
        Me.cboDocumentTypeID.Name = "cboDocumentTypeID"
        Me.cboDocumentTypeID.Size = New System.Drawing.Size(499, 21)
        Me.cboDocumentTypeID.TabIndex = 2
        Me.cboDocumentTypeID.Tag = "Documents.DocumentTypeID"
        '
        'lblDocumentTypeID
        '
        Me.lblDocumentTypeID.Location = New System.Drawing.Point(8, 59)
        Me.lblDocumentTypeID.Name = "lblDocumentTypeID"
        Me.lblDocumentTypeID.Size = New System.Drawing.Size(112, 20)
        Me.lblDocumentTypeID.TabIndex = 31
        Me.lblDocumentTypeID.Text = "Document Type"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(128, 90)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(499, 21)
        Me.txtName.TabIndex = 3
        Me.txtName.Tag = "Documents.Name"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(8, 90)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(96, 20)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = "Reference"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(128, 121)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNotes.Size = New System.Drawing.Size(499, 256)
        Me.txtNotes.TabIndex = 4
        Me.txtNotes.Tag = "Documents.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(8, 121)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(112, 20)
        Me.lblNotes.TabIndex = 31
        Me.lblNotes.Text = "Notes"
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.Location = New System.Drawing.Point(128, 387)
        Me.txtLocation.MaxLength = 16
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(403, 21)
        Me.txtLocation.TabIndex = 5
        Me.txtLocation.Tag = "Documents.Location"
        '
        'lblLocation
        '
        Me.lblLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLocation.Location = New System.Drawing.Point(8, 387)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(104, 20)
        Me.lblLocation.TabIndex = 31
        Me.lblLocation.Text = "Document"
        '
        'UCDocuments
        '
        Me.Controls.Add(Me.grpDocuments)
        Me.Name = "UCDocuments"
        Me.Size = New System.Drawing.Size(651, 555)
        Me.grpDocuments.ResumeLayout(False)
        Me.grpDocuments.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentDocuments
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentDocuments As Entity.Documentss.Documents
    Public Property CurrentDocuments() As Entity.Documentss.Documents
        Get
            Return _currentDocuments
        End Get
        Set(ByVal Value As Entity.Documentss.Documents)
            _currentDocuments = Value

            If CurrentDocuments Is Nothing Then
                CurrentDocuments = New Entity.Documentss.Documents
                CurrentDocuments.Exists = False
            End If

            If CurrentDocuments.Exists Then
                Populate()
            Else
                Me.lblAddedBy.Text = "Added By : NOT SAVED"
                Me.lblLastUpdated.Text = "Last Updated By : NOT SAVED"
                Me.btnBrowse.Enabled = True
                Me.btnOpen.Enabled = False
            End If

            Me.lblTableEnumID.Text = "This document is linked to record ID '" & IDToLinkTo & "' for the entity of '" & EntityToLinkTo.ToString.Replace("TBL", "") & "'"
        End Set
    End Property

    Private _EntityToLinkTo As Entity.Sys.Enums.TableNames
    Public Property EntityToLinkTo() As Entity.Sys.Enums.TableNames
        Get
            Return _EntityToLinkTo
        End Get
        Set(ByVal Value As Entity.Sys.Enums.TableNames)
            _EntityToLinkTo = Value
        End Set
    End Property

    Private _IDToLinkTo As Integer = 0
    Public Property IDToLinkTo() As Integer
        Get
            Return _IDToLinkTo
        End Get
        Set(ByVal Value As Integer)
            _IDToLinkTo = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCDocuments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim dlg As New OpenFileDialog
        dlg.ShowDialog()
        If dlg.FileName.Trim.Length > 0 Then
            Me.txtLocation.Text = dlg.FileName.Trim
            Me.txtDocumentName.Text = New System.IO.FileInfo(dlg.FileName.Trim).Name
        End If
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Entity.Sys.Helper.StartProcess(Me.txtLocation.Text.Trim)

        DB.Documents.Opened(CurrentDocuments.DocumentID)

        CurrentDocuments = DB.Documents.Documents_Get(CurrentDocuments.DocumentID)
        Populate()

        RaiseEvent StateChanged(CurrentDocuments.DocumentID)
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentDocuments = DB.Documents.Documents_Get(ID)
        End If

        Combo.SetSelectedComboItem_By_Value(Me.cboDocumentTypeID, CurrentDocuments.DocumentTypeID)
        Me.txtName.Text = CurrentDocuments.Name
        Me.txtNotes.Text = CurrentDocuments.Notes
        Me.txtLocation.Text = CurrentDocuments.Location
        Me.txtDocumentName.Text = New System.IO.FileInfo(CurrentDocuments.Location).Name

        Me.lblAddedBy.Text = "Added By : " & CurrentDocuments.AddedByUserName & " at " & Format(CurrentDocuments.AddedOn, "dddd dd MMMM yyyy HH:mm:ss") & "."
        Me.lblLastUpdated.Text = "Last Updated By : " & CurrentDocuments.LastUpdatedByUserName & " at " & Format(CurrentDocuments.LastUpdatedOn, "dddd dd MMMM yyyy HH:mm:ss") & "."
        Me.btnBrowse.Enabled = False
        Me.btnOpen.Enabled = True
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentDocuments.IgnoreExceptionsOnSetMethods = True

            CurrentDocuments.SetTableEnumID = CInt(EntityToLinkTo)
            CurrentDocuments.SetRecordID = IDToLinkTo
            CurrentDocuments.SetDocumentTypeID = Combo.GetSelectedItemValue(Me.cboDocumentTypeID)
            CurrentDocuments.SetName = Me.txtName.Text.Trim
            CurrentDocuments.SetNotes = Me.txtNotes.Text.Trim
            CurrentDocuments.SetLocation = Me.txtLocation.Text.Trim

            Dim cV As New Entity.Documentss.DocumentsValidator
            cV.Validate(CurrentDocuments)

            If CurrentDocuments.Exists Then
                DB.Documents.Update(CurrentDocuments)
            Else
                CurrentDocuments = DB.Documents.Insert(CurrentDocuments)
            End If

            RaiseEvent StateChanged(CurrentDocuments.DocumentID)

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

#End Region

End Class

