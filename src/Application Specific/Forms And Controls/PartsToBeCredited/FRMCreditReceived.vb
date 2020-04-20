Public Class FRMCreditReceived : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get

        End Get
    End Property

    Public Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Combo.SetUpCombo(Me.cboTaxCode, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.VATCodes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Dashes)

        PartCreditsID = GetParameter(0)
        SetupCreditDataGrid()
      
    End Sub

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe

    End Sub

#End Region

#Region "Properties"

    Private _PartCreditsID As Integer = 0
    Private Property PartCreditsID() As Integer
        Get
            Return _PartCreditsID
        End Get
        Set(ByVal value As Integer)
            _PartCreditsID = value
            Populate()
        End Set
    End Property

    Private _dvCredits As DataView
    Private Property CreditsDataview() As DataView
        Get
            Return _dvCredits
        End Get
        Set(ByVal value As DataView)
            _dvCredits = value
            _dvCredits.AllowNew = False
            _dvCredits.AllowEdit = True
            _dvCredits.AllowDelete = False
            _dvCredits.Table.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
            Me.dgCredits.DataSource = CreditsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedCreditDataRow() As DataRow
        Get
            If Not Me.dgCredits.CurrentRowIndex = -1 Then
                Return CreditsDataview(Me.dgCredits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupCreditDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgCredits.TableStyles(0)

        Dim Supplier As New DataGridLabelColumn
        Supplier.Format = ""
        Supplier.FormatInfo = Nothing
        Supplier.HeaderText = "Supplier"
        Supplier.MappingName = "Supplier"
        Supplier.ReadOnly = True
        Supplier.Width = 140
        Supplier.NullText = ""
        tbStyle.GridColumnStyles.Add(Supplier)

        Dim OrderReference As New DataGridLabelColumn
        OrderReference.Format = ""
        OrderReference.FormatInfo = Nothing
        OrderReference.HeaderText = "Order Reference"
        OrderReference.MappingName = "OrderReference"
        OrderReference.ReadOnly = True
        OrderReference.Width = 120
        OrderReference.NullText = ""
        tbStyle.GridColumnStyles.Add(OrderReference)

        Dim Part As New DataGridLabelColumn
        Part.Format = ""
        Part.FormatInfo = Nothing
        Part.HeaderText = "Part"
        Part.MappingName = "Part"
        Part.ReadOnly = True
        Part.Width = 160
        Part.NullText = ""
        tbStyle.GridColumnStyles.Add(Part)

        Dim Qty As New DataGridLabelColumn
        Qty.Format = ""
        Qty.FormatInfo = Nothing
        Qty.HeaderText = "Qty"
        Qty.MappingName = "Qty"
        Qty.ReadOnly = True
        Qty.Width = 60
        Qty.NullText = ""
        tbStyle.GridColumnStyles.Add(Qty)

        Dim SellPrice As New DataGridLabelColumn
        SellPrice.Format = "C"
        SellPrice.FormatInfo = Nothing
        SellPrice.HeaderText = "Buy Price"
        SellPrice.MappingName = "Price"
        SellPrice.ReadOnly = True
        SellPrice.Width = 60
        SellPrice.NullText = ""
        tbStyle.GridColumnStyles.Add(SellPrice)

        Dim TotalPrice As New DataGridLabelColumn
        TotalPrice.Format = "C"
        TotalPrice.FormatInfo = Nothing
        TotalPrice.HeaderText = "Total Price"
        TotalPrice.MappingName = "Total"
        TotalPrice.ReadOnly = True
        TotalPrice.Width = 60
        TotalPrice.NullText = ""
        tbStyle.GridColumnStyles.Add(TotalPrice)

        Dim CreditReceived As New DataGridEditableTextBoxColumn
        CreditReceived.Format = "C"
        CreditReceived.FormatInfo = Nothing
        CreditReceived.HeaderText = "Credit Received"
        CreditReceived.MappingName = "CreditReceived"
        CreditReceived.ReadOnly = False
        CreditReceived.Width = 120
        CreditReceived.NullText = ""
        AddHandler CreditReceived.TextBox.TextChanged, AddressOf CreditReceived_LostFocus
        tbStyle.GridColumnStyles.Add(CreditReceived)

        tbStyle.ReadOnly = False
        dgCredits.ReadOnly = False
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
        Me.dgCredits.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMCreditReceived_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub dgCredits_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCredits.CurrentCellChanged
        TotalAmount()
    End Sub

    Private Sub CreditReceived_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TotalAmount()
    End Sub

    Private Sub cboTaxCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTaxCode.SelectedIndexChanged
        Calculate_Tax()
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate()
        Dim creditReference As String = ""

        Select Case CStr(PartCreditsID).Length
            Case 1
                creditReference = "000000" & PartCreditsID
            Case 2
                creditReference = "00000" & PartCreditsID
            Case 3
                creditReference = "0000" & PartCreditsID
            Case 4
                creditReference = "000" & PartCreditsID
            Case 5
                creditReference = "00" & PartCreditsID
            Case 6
                creditReference = "0" & PartCreditsID
            Case Else
                creditReference = PartCreditsID
        End Select

        txtCreditReference.Text = creditReference
        txtNominalCode.Text = GetParameter(1)
        txtDepartment.Text = GetParameter(2)
        CreditsDataview = DB.PartsToBeCredited.PartsToBeCredited_Get_PartsCreditID(PartCreditsID)
        TotalAmount()
        Combo.SetSelectedComboItem_By_Value(cboTaxCode, GetParameter(3))
        txtExtraRef.Text = GetParameter(4)
        If GetParameter(5) = Nothing Then
            dtpDateReceived.Value = Now
        Else
            dtpDateReceived.Value = GetParameter(5)
        End If
        txtSupplierCreditRef.Text = GetParameter(6)
    End Sub

    Private Sub TotalAmount()
        Dim totalAmount As Double = 0
        Dim orderAmount As Double = 0
        For Each dr As DataRow In CreditsDataview.Table.Rows
            totalAmount += Entity.Sys.Helper.MakeDoubleValid(dr("CreditReceived"))
            orderAmount += Entity.Sys.Helper.MakeDoubleValid(dr("Total"))
        Next
        Me.txtTotalAmount.Text = Format(totalAmount, "C")
        Me.txtOrignalAmount.Text = Format(orderAmount, "C")
        Calculate_Tax()
    End Sub

    Private Sub Calculate_Tax()
        Dim supplierInvoiceAmount As Double = Entity.Sys.Helper.MakeDoubleValid(txtTotalAmount.Text.Replace("£", ""))

        If Combo.GetSelectedItemValue(Me.cboTaxCode) = 0 Then
            Me.txtVAT.Text = Format(0, "C")
        Else
            Try
                Me.txtVAT.Text = Format(supplierInvoiceAmount * (DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(Me.cboTaxCode)).PercentageRate / 100), "C")
            Catch ex As Exception
                Me.txtVAT.Text = Format(0, "C")
            End Try
        End If

    End Sub


    Private Sub Save()
        Try
            Dim err As String = ""
            If txtSupplierCreditRef.Text.Length = 0 Then
                err += "Suppplier Credit Ref Missing" & vbCrLf
            End If
            If txtNominalCode.Text.Length = 0 Then
                err += "Nominal Code Missing" & vbCrLf
            End If
            If txtDepartment.Text.Length = 0 Then
                err += "Department Missing" & vbCrLf
            End If
            If Combo.GetSelectedItemValue(cboTaxCode) = 0 Then
                err += "Tax Code Missing" & vbCrLf
            End If
            If Entity.Sys.Helper.MakeDoubleValid(txtTotalAmount.Text.Replace("£", "")) = 0 Then
                err += "Amount must be greater than zero" & vbCrLf
            End If

            If err.Length > 0 Then
                ShowMessage(err, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            DB.PartsToBeCredited.PartCredits_Update(PartCreditsID, _
                                                    Entity.Sys.Helper.MakeDoubleValid(txtTotalAmount.Text.Replace("£", "")), _
                                                txtnotes.Text, _
                                                dtpDateReceived.Value, Date.MinValue, _
                                                Combo.GetSelectedItemValue(cboTaxCode), _
                                                txtNominalCode.Text, _
                                                txtDepartment.Text, _
                                                txtExtraRef.Text, txtSupplierCreditRef.Text)


            For Each dr As DataRow In CreditsDataview.Table.Rows
                Dim oPartToCredit As Entity.PartsToBeCrediteds.PartsToBeCredited = DB.PartsToBeCredited.PartsToBeCredited_Get(dr("PartsToBeCreditedID"))
                oPartToCredit.SetCreditReceived = Entity.Sys.Helper.MakeDoubleValid(dr("CreditReceived"))
                oPartToCredit.SetStatusID = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Received)
                DB.PartsToBeCredited.Update(oPartToCredit)
            Next dr

            ShowMessage("Credit Saved ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


#End Region

End Class