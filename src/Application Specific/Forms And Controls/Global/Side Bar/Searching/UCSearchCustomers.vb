Public Class UCSearchCustomers : Inherits FSM.UCBase : Implements ISearchControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSearchFor As System.Windows.Forms.ComboBox
    Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSearchFor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCriteria = New System.Windows.Forms.TextBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Search For"
        '
        'cboSearchFor
        '
        Me.cboSearchFor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboSearchFor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSearchFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchFor.Location = New System.Drawing.Point(8, 24)
        Me.cboSearchFor.Name = "cboSearchFor"
        Me.cboSearchFor.Size = New System.Drawing.Size(152, 21)
        Me.cboSearchFor.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Enter Search Criteria"
        '
        'txtCriteria
        '
        Me.txtCriteria.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCriteria.Location = New System.Drawing.Point(8, 64)
        Me.txtCriteria.MaxLength = 25
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(101, 21)
        Me.txtCriteria.TabIndex = 0
        '
        'btnFind
        '
        Me.btnFind.AccessibleDescription = "Search for records by comparing multiple columns"
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFind.Location = New System.Drawing.Point(115, 64)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(45, 23)
        Me.btnFind.TabIndex = 1
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'UCSearchCustomers
        '
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtCriteria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboSearchFor)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UCSearchCustomers"
        Me.Size = New System.Drawing.Size(160, 96)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private tt As New ToolTip 'AMY PUT THIS HERE

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISearchControl.LoadForm
        LoadBaseControl(Me)

        Combo.SetUpCombo(Me.cboSearchFor, DynamicDataTables.Setup_Search_Options(Entity.Sys.Enums.MenuTypes.Customers), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetSelectedComboItem_By_Value(cboSearchFor, CInt(Entity.Sys.Enums.TableNames.tblSite))
        txtCriteria.Focus()

    End Sub

    Private Sub Search() Implements ISearchControl.Search
        If Combo.GetSelectedItemValue(Me.cboSearchFor) = "0" Then
            ShowMessage("Please select what you would like to search for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Navigation.Close_Middle()
        Navigation.Close_Right()

        For Each form As Form In MainForm.MdiChildren
            form.Dispose()
        Next

        CurrentCustomerID = 0
        CurrentPropertyID = 0
        Select Case Combo.GetSelectedItemValue(Me.cboSearchFor)
            Case Entity.Sys.Enums.TableNames.tblCustomer
                MainForm.SetSearchResults(DB.Customer.Customer_Search(Me.txtCriteria.Text.Trim, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Customer, False, False)
            Case Entity.Sys.Enums.TableNames.tblSite
                Dim dv As DataView = DB.Sites.Search(Me.txtCriteria.Text.Trim, loggedInUser.UserID)
                MainForm.SetSearchResults(dv, Entity.Sys.Enums.PageViewing.Property, False, False)
                MainForm.SearchText = Me.txtCriteria.Text.Trim
                If dv.Table.Rows.Count > 0 Then
                    MainForm.dgSearchResults.CurrentRowIndex = 0
                    MainForm.dgSearchResults.Select(0)
                    MainForm.View()
                End If
            Case Entity.Sys.Enums.TableNames.tblAsset
                    MainForm.SetSearchResults(DB.Asset.Asset_Search(Me.txtCriteria.Text.Trim), Entity.Sys.Enums.PageViewing.Asset, False, False)

        End Select
    End Sub

#End Region

#Region "Events"

    Private Sub UCSearchSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)

    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Search()
    End Sub

    Private Sub cboSearchFor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchFor.SelectedIndexChanged
        Select Case Combo.GetSelectedItemValue(Me.cboSearchFor)
            Case Entity.Sys.Enums.TableNames.tblCustomer
                tt.SetToolTip(Me.txtCriteria, "Searches on Name, Acc No, Type or Contract Ref.")
            Case Entity.Sys.Enums.TableNames.tblSite
                tt.SetToolTip(Me.txtCriteria, "Searches on Name, Address, Postcode, Phone, Fax, Email, Job No or Contract Ref.")
            Case Entity.Sys.Enums.TableNames.tblAsset
                tt.SetToolTip(Me.txtCriteria, "Searches on Gasway Ref, Serial Number, Location, Type, Make or Model.")
            Case Else
                tt.SetToolTip(Me.txtCriteria, "Select Search For")
        End Select
    End Sub

    Private Sub txtCriteria_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCriteria.KeyUp
        If e.KeyCode = Keys.Enter Then
            Search()
        End If
    End Sub
#End Region

End Class
