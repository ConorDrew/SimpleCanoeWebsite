Public Class UCQuoteJobSelectASite : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents grpSites As System.Windows.Forms.GroupBox
    Friend WithEvents dgSites As System.Windows.Forms.DataGrid



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpSites = New System.Windows.Forms.GroupBox
        Me.dgSites = New System.Windows.Forms.DataGrid
        Me.grpSites.SuspendLayout()
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSites
        '
        Me.grpSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSites.Controls.Add(Me.dgSites)
        Me.grpSites.Location = New System.Drawing.Point(8, 0)
        Me.grpSites.Name = "grpSites"
        Me.grpSites.Size = New System.Drawing.Size(608, 288)
        Me.grpSites.TabIndex = 28
        Me.grpSites.TabStop = False
        Me.grpSites.Text = "Select A Property For The Quote:"
        '
        'dgSites
        '
        Me.dgSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSites.DataMember = ""
        Me.dgSites.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSites.Location = New System.Drawing.Point(8, 26)
        Me.dgSites.Name = "dgSites"
        Me.dgSites.Size = New System.Drawing.Size(592, 254)
        Me.dgSites.TabIndex = 1
        '
        'UCQuoteJobSelectASite
        '
        Me.Controls.Add(Me.grpSites)
        Me.Name = "UCQuoteJobSelectASite"
        Me.Size = New System.Drawing.Size(624, 296)
        Me.grpSites.ResumeLayout(False)
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        SetupSiteDataGrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return SelectedSiteDataRow
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged
    Public Event SiteSelected(ByVal SiteID As Integer)

    Private _Sites As DataView = Nothing
    Public Property Sites() As DataView
        Get
            Return _Sites
        End Get
        Set(ByVal Value As DataView)
            _Sites = Value
            _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
            _Sites.AllowNew = False
            _Sites.AllowEdit = False
            _Sites.AllowDelete = False

            Me.dgSites.DataSource = Sites
        End Set
    End Property

    Private ReadOnly Property SelectedSiteDataRow() As DataRow
        Get
            If Not Me.dgSites.CurrentRowIndex = -1 Then
                Return Sites(Me.dgSites.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub UCQuoteJob_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

#End Region

#Region "Setup"

    Public Sub SetupSiteDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgSites)
        Dim tStyle As DataGridTableStyle = Me.dgSites.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Address1 As New DataGridLabelColumn
        Address1.Format = ""
        Address1.FormatInfo = Nothing
        Address1.HeaderText = "Address 1"
        Address1.MappingName = "Address1"
        Address1.ReadOnly = True
        Address1.Width = 100
        Address1.NullText = ""
        tStyle.GridColumnStyles.Add(Address1)

        Dim Address2 As New DataGridLabelColumn
        Address2.Format = ""
        Address2.FormatInfo = Nothing
        Address2.HeaderText = "Address 2"
        Address2.MappingName = "Address2"
        Address2.ReadOnly = True
        Address2.Width = 100
        Address2.NullText = ""
        tStyle.GridColumnStyles.Add(Address2)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "Postcode"
        Postcode.ReadOnly = True
        Postcode.Width = 75
        Postcode.NullText = ""
        tStyle.GridColumnStyles.Add(Postcode)

        Dim HeadOffice As New DataGridLabelColumn
        HeadOffice.Format = ""
        HeadOffice.FormatInfo = Nothing
        HeadOffice.HeaderText = "HO"
        HeadOffice.MappingName = "HeadOfficeResult"
        HeadOffice.ReadOnly = True
        HeadOffice.Width = 75
        HeadOffice.NullText = ""
        tStyle.GridColumnStyles.Add(HeadOffice)

        Dim Region As New DataGridLabelColumn
        Region.Format = ""
        Region.FormatInfo = Nothing
        Region.HeaderText = "Region"
        Region.MappingName = "Region"
        Region.ReadOnly = True
        Region.Width = 100
        Region.NullText = ""
        tStyle.GridColumnStyles.Add(Region)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSite.ToString
        Me.dgSites.TableStyles.Add(tStyle)

    End Sub

#End Region

#Region "Functions"

    Public Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        Sites = DB.Sites.GetForCustomer_Light(ID, loggedInUser.UserID)
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor

            If SelectedSiteDataRow Is Nothing Then
                RaiseEvent SiteSelected(0)
                Return False
            Else
                RaiseEvent SiteSelected(SelectedSiteDataRow("SiteID"))
                Return True
            End If

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

