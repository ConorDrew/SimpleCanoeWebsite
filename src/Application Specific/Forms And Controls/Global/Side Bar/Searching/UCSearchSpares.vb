Public Class UCSearchSpares : Inherits FSM.UCBase : Implements ISearchControl

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
    Friend WithEvents cboSearchOn As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSearchFor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCriteria = New System.Windows.Forms.TextBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.cboSearchOn = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search"
        '
        'cboSearchFor
        '
        Me.cboSearchFor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSearchFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchFor.Location = New System.Drawing.Point(34, 18)
        Me.cboSearchFor.Name = "cboSearchFor"
        Me.cboSearchFor.Size = New System.Drawing.Size(123, 21)
        Me.cboSearchFor.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Enter Search Criteria"
        '
        'txtCriteria
        '
        Me.txtCriteria.Location = New System.Drawing.Point(10, 84)
        Me.txtCriteria.MaxLength = 25
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(96, 21)
        Me.txtCriteria.TabIndex = 2
        '
        'btnFind
        '
        Me.btnFind.AccessibleDescription = "Search for records by comparing multiple columns"
        Me.btnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFind.Location = New System.Drawing.Point(112, 84)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(45, 23)
        Me.btnFind.TabIndex = 3
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'cboSearchOn
        '
        Me.cboSearchOn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSearchOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchOn.Location = New System.Drawing.Point(34, 41)
        Me.cboSearchOn.Name = "cboSearchOn"
        Me.cboSearchOn.Size = New System.Drawing.Size(123, 21)
        Me.cboSearchOn.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "On"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "For"
        '
        'UCSearchSpares
        '
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboSearchOn)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtCriteria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboSearchFor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UCSearchSpares"
        Me.Size = New System.Drawing.Size(160, 111)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISearchControl.LoadForm
        LoadBaseControl(Me)

        Combo.SetUpCombo(Me.cboSearchFor, DynamicDataTables.Setup_Search_Options(Entity.Sys.Enums.MenuTypes.Spares), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetSelectedComboItem_By_Value(cboSearchFor, Entity.Sys.Enums.TableNames.tblPart)

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

        Select Case Combo.GetSelectedItemValue(Me.cboSearchFor)
            Case Entity.Sys.Enums.TableNames.tblSupplier
                MainForm.SetSearchResults(DB.Supplier.Supplier_Search(Me.txtCriteria.Text.Trim, Combo.GetSelectedItemValue(cboSearchOn)), Entity.Sys.Enums.PageViewing.Supplier, False, False)
            Case Entity.Sys.Enums.TableNames.tblProduct
                MainForm.SetSearchResults(DB.Product.Product_Search(Me.txtCriteria.Text.Trim, Combo.GetSelectedItemValue(cboSearchOn)), Entity.Sys.Enums.PageViewing.Product, False, False)
            Case Entity.Sys.Enums.TableNames.tblPart
                MainForm.SetSearchResults(DB.Part.Part_Search(Me.txtCriteria.Text.Trim, Combo.GetSelectedItemValue(cboSearchOn)), Entity.Sys.Enums.PageViewing.Part, False, False)
            Case Entity.Sys.Enums.TableNames.tblWarehouse
                MainForm.SetSearchResults(DB.Warehouse.Warehouse_Search(Me.txtCriteria.Text.Trim, Combo.GetSelectedItemValue(cboSearchOn)), Entity.Sys.Enums.PageViewing.Warehouse, False, False)
        End Select
    End Sub

#End Region

#Region "Events"

    Private Sub cboSearchFor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchFor.SelectedIndexChanged
        Combo.SetUpCombo(Me.cboSearchOn, DynamicDataTables.Setup_Search_On_Options(Entity.Sys.Enums.MenuTypes.Spares, Combo.GetSelectedItemValue(Me.cboSearchFor)), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetSelectedComboItem_By_Value(cboSearchOn, "")
    End Sub

    Private Sub UCSearchSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Search()
    End Sub

    Private Sub txtCriteria_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCriteria.KeyUp
        If e.KeyCode = Keys.Enter Then
            Search()
        End If
    End Sub
#End Region

End Class
