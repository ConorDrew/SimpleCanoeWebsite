Public Class FRMPartsToBeCreditedManager : Inherits FSM.FRMBaseForm : Implements IForm


#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        CreatePartsAndProductsDistribution()
        SetupCreditDataGrid()
        Combo.SetUpCombo(cboStatus, DynamicDataTables.CreditStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        ResetFilters()

        PopulateDatagrid()

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

    Private _dvCredits As DataView
    Private Property CreditsDataview() As DataView
        Get
            Return _dvCredits
        End Get
        Set(ByVal value As DataView)
            _dvCredits = value
            _dvCredits.AllowNew = False
            _dvCredits.AllowEdit = False
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

    Private _PartsDistribution As DataView = Nothing
    Public Property PartsDistribution() As DataView
        Get
            Return _PartsDistribution
        End Get
        Set(ByVal Value As DataView)
            _PartsDistribution = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupCreditDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgCredits.TableStyles(0)

        Dim tick As New DataGridBoolColumn
        tick.HeaderText = ""
        tick.MappingName = "tick"
        tick.ReadOnly = True
        tick.Width = 25
        tick.NullText = ""
        tbStyle.GridColumnStyles.Add(tick)

        Dim Supplier As New DataGridLabelColumn
        Supplier.Format = ""
        Supplier.FormatInfo = Nothing
        Supplier.HeaderText = "Supplier"
        Supplier.MappingName = "Supplier"
        Supplier.ReadOnly = True
        Supplier.Width = 180
        Supplier.NullText = ""
        tbStyle.GridColumnStyles.Add(Supplier)

        Dim OrderReference As New DataGridLabelColumn
        OrderReference.Format = ""
        OrderReference.FormatInfo = Nothing
        OrderReference.HeaderText = "Order Ref"
        OrderReference.MappingName = "OrderReference"
        OrderReference.ReadOnly = True
        OrderReference.Width = 90
        OrderReference.NullText = ""
        tbStyle.GridColumnStyles.Add(OrderReference)

        Dim Part As New DataGridLabelColumn
        Part.Format = ""
        Part.FormatInfo = Nothing
        Part.HeaderText = "Part"
        Part.MappingName = "Part"
        Part.ReadOnly = True
        Part.Width = 270
        Part.NullText = "N/A"
        tbStyle.GridColumnStyles.Add(Part)

        Dim Qty As New DataGridLabelColumn
        Qty.Format = ""
        Qty.FormatInfo = Nothing
        Qty.HeaderText = "Qty"
        Qty.MappingName = "Qty"
        Qty.ReadOnly = True
        Qty.Width = 40
        Qty.NullText = ""
        Qty.Alignment = HorizontalAlignment.Center
        tbStyle.GridColumnStyles.Add(Qty)

        Dim Status As New DataGridLabelColumn
        Status.Format = ""
        Status.FormatInfo = Nothing
        Status.HeaderText = "Status"
        Status.MappingName = "Status"
        Status.ReadOnly = True
        Status.Width = 200
        Status.NullText = ""
        tbStyle.GridColumnStyles.Add(Status)

        Dim ManuallyAdded As New DataGridLabelColumn
        ManuallyAdded.Format = ""
        ManuallyAdded.FormatInfo = Nothing
        ManuallyAdded.HeaderText = "Manually Added"
        ManuallyAdded.MappingName = "ManuallyAdded"
        ManuallyAdded.ReadOnly = True
        ManuallyAdded.Width = 60
        ManuallyAdded.NullText = ""
        ManuallyAdded.Alignment = HorizontalAlignment.Center
        tbStyle.GridColumnStyles.Add(ManuallyAdded)

        Dim CreditReference As New DataGridLabelColumn
        CreditReference.Format = ""
        CreditReference.FormatInfo = Nothing
        CreditReference.HeaderText = "Credit Ref"
        CreditReference.MappingName = "CreditReference"
        CreditReference.ReadOnly = True
        CreditReference.Width = 90
        CreditReference.NullText = ""
        tbStyle.GridColumnStyles.Add(CreditReference)

        Dim DateCreated As New DataGridLabelColumn
        DateCreated.Format = ""
        DateCreated.FormatInfo = Nothing
        DateCreated.HeaderText = "Date Created"
        DateCreated.MappingName = "DateCreated"
        DateCreated.ReadOnly = True
        DateCreated.Width = 120
        DateCreated.NullText = ""
        tbStyle.GridColumnStyles.Add(DateCreated)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
        Me.dgCredits.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMOrderManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub btnGenerateCreditDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateCreditDocument.Click
        Try
            Dim partCreditID As Integer = 0
            Dim currentSupplierID As Integer = 0
            Dim creditReference As String = ""
            Dim TotalCount As Integer = 0
            Dim invalidcount As Integer = 0
            Dim details As New ArrayList
            Dim InvalidMessageString As String = "The following credits could not be generated as incorrect status<br>"

            For Each r As DataRowView In CreditsDataview
                If CBool(r("Tick")) = True And CInt(r("StatusID")) = Entity.Sys.Enums.PartsToBeCreditedStatus.Part_Returned_To_Supplier Then
                    TotalCount += 1

                    If currentSupplierID = 0 Then
                        currentSupplierID = r("SupplierID")
                    End If

                    partCreditID = Entity.Sys.Helper.MakeIntegerValid(r("PartCreditsID"))
                    creditReference = Entity.Sys.Helper.MakeStringValid(r("creditReference"))

                    If partCreditID = 0 Then
                        'create the credit items
                        For Each h As DataRowView In CreditsDataview
                            If CBool(h("Tick")) = True Then
                                If CBool(h("ManuallyAdded")) = True Then
                                    If PartLocation(h.Row) = False Then
                                        ShowMessage("Generation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub
                                    End If
                                End If
                            End If
                        Next

                        'INSERT NEW CREDIT ROW
                        'partCreditID = DB.PartsToBeCredited.PartCredits_Insert
                        'For Each h As DataRowView In CreditsDataview
                        '    If CBool(h("Tick")) = True Then
                        '        DB.PartsToBeCredited.PartCreditParts_Insert(partCreditID, h("PartsToBeCreditedID"))
                        '        Dim oPartToCredit As Entity.PartsToBeCrediteds.PartsToBeCredited
                        '        oPartToCredit = DB.PartsToBeCredited.PartsToBeCredited_Get(h("PartsToBeCreditedID"))
                        '        oPartToCredit.SetStatusID = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Req_Sent_To_Supplier)
                        '        DB.PartsToBeCredited.Update(oPartToCredit)
                        '    End If
                        'Next

                        'TAKE THE STOCK QTY AWAY
                        For Each distRow As DataRow In PartsDistribution.Table.Rows
                            Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                            oPartTransaction.SetLocationID = distRow.Item("LocationID")
                            oPartTransaction.SetPartID = distRow.Item("PartProductID")
                            oPartTransaction.SetOrderPartID = distRow.Item("OrderPartProductID")
                            If CInt(distRow("StockTransactionType")) = CInt(Entity.Sys.Enums.Transaction.StockOut) Then
                                oPartTransaction.SetAmount = distRow.Item("Quantity") * -1
                            Else
                                oPartTransaction.SetAmount = distRow.Item("Quantity")
                            End If
                            oPartTransaction.SetTransactionTypeID = distRow.Item("StockTransactionType")
                            DB.PartTransaction.Insert(oPartTransaction)
                        Next

                        Select Case CStr(partCreditID).Length
                            Case 1
                                creditReference = "000000" & partCreditID
                            Case 2
                                creditReference = "00000" & partCreditID
                            Case 3
                                creditReference = "0000" & partCreditID
                            Case 4
                                creditReference = "000" & partCreditID
                            Case 5
                                creditReference = "00" & partCreditID
                            Case 6
                                creditReference = "0" & partCreditID
                            Case Else
                                creditReference = partCreditID
                        End Select
                    Else
                        details.Add(DB.PartsToBeCredited.PartsToBeCredited_Get_PartsCreditID(partCreditID).Table)
                    End If

                ElseIf CBool(r("Tick")) = True And Not CInt(r("StatusID")) = Entity.Sys.Enums.PartsToBeCreditedStatus.Part_Returned_To_Supplier Then
                    invalidcount += 1
                    InvalidMessageString = InvalidMessageString & r("CreditReference") & "<br>"
                Else
                End If
            Next

            If TotalCount = 0 Then
                ShowMessage("No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Exit Sub
            Else
                If currentSupplierID = 24 Then 'Alpha Boilers
                    Dim oPrint As New Entity.Sys.Printing(details, "Alpha Part Credit", Entity.Sys.Enums.SystemDocumentType.AlphaPartCredit, True)
                Else
                    Dim oPrint As New Entity.Sys.Printing(details, "Part Credit", Entity.Sys.Enums.SystemDocumentType.PartCredit, True)
                End If
                Dim dialogresult As DialogResult
                dialogresult = ShowMessage("Do you want to update these to 'Credit Req Sent to Supplier' Status?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If dialogresult =DialogResult.Yes Then
                    For Each r As DataRowView In CreditsDataview
                        If CBool(r("Tick")) = True Then
                            Dim oPartsToBeCredited As Entity.PartsToBeCrediteds.PartsToBeCredited
                            oPartsToBeCredited = DB.PartsToBeCredited.PartsToBeCredited_Get(r("PartsToBeCreditedID"))
                            oPartsToBeCredited.SetStatusID = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Req_Sent_To_Supplier)
                            DB.PartsToBeCredited.Update(oPartsToBeCredited)
                        End If
                    Next

                    PopulateDatagrid()
                Else
                    Exit Sub
                End If
            End If

            If invalidcount > 1 Then
                ShowMessage(InvalidMessageString, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Exit Sub
            End If

        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    'Private Sub btnGenerateCreditDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateCreditDocument.Click
    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        Dim partCreditID As Integer = 0
    '        Dim currentSupplierID As Integer = 0
    '        Dim creditReference As String = ""
    '        Dim count As Integer = 0

    '        For Each r As DataRowView In CreditsDataview
    '            If CBool(r("Tick")) = True Then
    '                count += 1
    '                If currentSupplierID = 0 Then
    '                    currentSupplierID = r("SupplierID")
    '                    partCreditID = Entity.Sys.Helper.MakeIntegerValid(r("PartCreditsID"))
    '                    creditReference = Entity.Sys.Helper.MakeStringValid(r("creditReference"))
    '                    If partCreditID > 0 Then
    '                        If ShowMessage("This part: " & r("Part") & " exists on a credit. Reprint?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then
    '                            Exit For
    '                        Else
    '                            Exit Sub
    '                        End If
    '                    End If
    '                End If
    '                If r("SupplierID") <> currentSupplierID Then
    '                    ShowMessage("All selected must be for the same supplier", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Exit Sub
    '                End If
    '            End If
    '        Next

    '        If count = 0 Then
    '            ShowMessage("No items selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End If
    '        Dim details As New ArrayList

    '        If partCreditID = 0 Then

    '            details.Add(CreditsDataview.Table)

    '            For Each r As DataRowView In CreditsDataview
    '                If CBool(r("Tick")) = True Then
    '                    If CBool(r("ManuallyAdded")) = True Then
    '                        If PartLocation(r.Row) = False Then
    '                            ShowMessage("Generation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                            Exit Sub
    '                        End If
    '                    End If
    '                End If
    '            Next

    '            'INSERT NEW CREDIT ROW
    '            partCreditID = DB.PartsToBeCredited.PartCredits_Insert
    '            For Each r As DataRowView In CreditsDataview
    '                If CBool(r("Tick")) = True Then
    '                    DB.PartsToBeCredited.PartCreditParts_Insert(partCreditID, r("PartsToBeCreditedID"))
    '                    Dim oPartToCredit As Entity.PartsToBeCrediteds.PartsToBeCredited
    '                    oPartToCredit = DB.PartsToBeCredited.PartsToBeCredited_Get(r("PartsToBeCreditedID"))
    '                    oPartToCredit.SetStatusID = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Req_Sent_To_Supplier)
    '                    DB.PartsToBeCredited.Update(oPartToCredit)
    '                End If
    '            Next

    '            'TAKE THE STOCK QTY AWAY
    '            For Each distRow As DataRow In PartsDistribution.Table.Rows
    '                Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
    '                oPartTransaction.SetLocationID = distRow.Item("LocationID")
    '                oPartTransaction.SetPartID = distRow.Item("PartProductID")
    '                oPartTransaction.SetOrderPartID = distRow.Item("OrderPartProductID")
    '                If CInt(distRow("StockTransactionType")) = CInt(Entity.Sys.Enums.Transaction.StockOut) Then
    '                    oPartTransaction.SetAmount = distRow.Item("Quantity") * -1
    '                Else
    '                    oPartTransaction.SetAmount = distRow.Item("Quantity")
    '                End If
    '                oPartTransaction.SetTransactionTypeID = distRow.Item("StockTransactionType")
    '                DB.PartTransaction.Insert(oPartTransaction)
    '            Next

    '            Select Case CStr(partCreditID).Length
    '                Case 1
    '                    creditReference = "000000" & partCreditID
    '                Case 2
    '                    creditReference = "00000" & partCreditID
    '                Case 3
    '                    creditReference = "0000" & partCreditID
    '                Case 4
    '                    creditReference = "000" & partCreditID
    '                Case 5
    '                    creditReference = "00" & partCreditID
    '                Case 6
    '                    creditReference = "0" & partCreditID
    '                Case Else
    '                    creditReference = partCreditID
    '            End Select
    '        Else
    '            details.Add(DB.PartsToBeCredited.PartsToBeCredited_Get_PartsCreditID(partCreditID).Table)
    '        End If

    '                details.Add(creditReference)
    '        Dim oPrint As New Entity.Sys.Printing(details, "Part Credit", Entity.Sys.Enums.SystemDocumentType.PartCredit)
    '        If ShowMessage("Do you want to update these to 'Credit Req Sent to Supplier' Status?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).Yes Then
    '            For Each r As DataRowView In CreditsDataview
    '                If CBool(r("Tick")) = True Then
    '                    Dim oPartsToBeCredited As Entity.PartsToBeCrediteds.PartsToBeCredited
    '                    oPartsToBeCredited = DB.PartsToBeCredited.PartsToBeCredited_Get(r("PartsToBeCreditedID"))
    '                    oPartsToBeCredited.SetStatusID = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Req_Sent_To_Supplier)
    '                    DB.PartsToBeCredited.Update(oPartsToBeCredited)
    '                End If
    '            Next

    '            PopulateDatagrid()
    '        Else
    '            Exit Sub
    '        End If

    '    Catch ex As Exception
    '        ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Finally
    '        Me.Cursor = Cursors.Default
    '    End Try
    'End Sub

    Private Sub btnCreditAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreditAmount.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Not CreditsDataview Is Nothing Then
                For Each r As DataRow In CreditsDataview.Table.Rows
                    r("Tick") = False
                Next
            End If

            If Not SelectedCreditDataRow Is Nothing Then
                If SelectedCreditDataRow("StatusID") = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return) Then
                    ShowMessage("Parts must be returned before credit can be received", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf SelectedCreditDataRow("StatusID") = CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Sent_To_Sage) Then

                    ShowMessage("Credit Details sent to Sage.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    'OPEN CREDIT 
                    ShowForm(GetType(FRMCreditReceived), True, New Object() {SelectedCreditDataRow("PartCreditsID"), _
                                                                             Entity.Sys.Helper.MakeStringValid(SelectedCreditDataRow("NominalCode")), _
                                                Entity.Sys.Helper.MakeStringValid(SelectedCreditDataRow("DepartmentRef")), _
                                                Entity.Sys.Helper.MakeIntegerValid(SelectedCreditDataRow("TaxCodeID")), _
                                                Entity.Sys.Helper.MakeStringValid(SelectedCreditDataRow("ExtraRef")), _
                                                Entity.Sys.Helper.MakeDateTimeValid(SelectedCreditDataRow("DateReceived")), _
                                                Entity.Sys.Helper.MakeStringValid(SelectedCreditDataRow("SupplierCreditRef"))})
                End If
            End If

            PopulateDatagrid()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        ShowForm(GetType(FRMPartsToBeCredited), True, New Object() {0})
        PopulateDatagrid()
    End Sub

    Private Sub dgCredits_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCredits.DoubleClick
        If Not SelectedCreditDataRow Is Nothing Then
            If SelectedCreditDataRow("ManuallyAdded") = True Then
                If SelectedCreditDataRow("StatusID") < CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Part_Returned_To_Supplier) Then
                    ShowForm(GetType(FRMPartsToBeCredited), True, New Object() {SelectedCreditDataRow("PartsToBeCreditedID")})
                Else
                    ShowMessage("This part has been returned and cannot be edited", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                ShowMessage("Only manually added parts can be edited", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub dgCredits_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgCredits.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgCredits.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            If HitTestInfo.Column = 0 Then
                Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(SelectedCreditDataRow.Item("tick"))
                SelectedCreditDataRow.Item("Tick") = selected
            End If
        End If
    End Sub

    Private Sub txtOrderReference_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderReference.TextChanged
        RunFilter()
    End Sub

    Private Sub txtSupplier_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplier.TextChanged
        RunFilter()
    End Sub

    Private Sub txtPart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPart.TextChanged
        RunFilter()
    End Sub

    Private Sub txtCreditReference_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditReference.TextChanged
        RunFilter()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        RunFilter()
    End Sub
#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try

            CreditsDataview = DB.PartsToBeCredited.PartsToBeCredited_GetAll
            RunFilter()

        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        If Not CreditsDataview Is Nothing Then
            For Each r As DataRow In CreditsDataview.Table.Rows
                r("Tick") = False
            Next
        End If
        txtOrderReference.Text = ""
        txtSupplier.Text = ""
        txtPart.Text = ""
        txtCreditReference.Text = ""
        Combo.SetSelectedComboItem_By_Value(cboStatus, 0)
    End Sub

    Private Sub RunFilter()
        If Not CreditsDataview Is Nothing Then
            For Each r As DataRow In CreditsDataview.Table.Rows
                r("Tick") = False
            Next

            Dim whereClause As String = " 1 = 1 "
            If txtOrderReference.Text.Length > 0 Then
                whereClause += " AND OrderReference LIKE '%" & txtOrderReference.Text & "%'"
            End If
            If txtSupplier.Text.Length > 0 Then
                whereClause += " AND Supplier LIKE '" & txtSupplier.Text & "%'"
            End If
            If txtCreditReference.Text.Length > 0 Then
                whereClause += " AND CreditReference LIKE '" & txtCreditReference.Text & "%'"
            End If
            If txtPart.Text.Length > 0 Then
                whereClause += " AND Part LIKE '%" & txtPart.Text & "%'"
            End If

            If Combo.GetSelectedItemValue(cboStatus) > 0 Then
                whereClause += " AND StatusID = " & Combo.GetSelectedItemValue(cboStatus)
            End If

            CreditsDataview.RowFilter = whereClause

        End If
    End Sub

    Private Sub CreatePartsAndProductsDistribution()
        Dim dt As New DataTable
        dt.Columns.Add("Type")
        dt.Columns.Add("DistributedID")
        dt.Columns.Add("LocationID")
        dt.Columns.Add("AllocatedID")
        dt.Columns.Add("Other")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("PartProductID")
        dt.Columns.Add("OrderPartProductID")
        dt.Columns.Add("StockTransactionType")

        PartsDistribution = New DataView(dt)
    End Sub

    Private Function PartLocation(ByVal dr As DataRow) As Boolean

        Dim frmDistribution As New FRMDistributeAllocated(True, dr("Qty"), dr("Part"), "Part", dr("PartID"), _
                                                         New ArrayList)

        If frmDistribution.ShowDialog = DialogResult.OK Then

            For Each row As DataRow In frmDistribution.Locations.Table.Rows
                If row.Item("Quantity") > 0 Then
                    Dim r As DataRow = PartsDistribution.Table.NewRow
                    r("Type") = "Part"
                    r("DistributedID") = 0
                    r("LocationID") = row.Item("LocationID")
                    r("AllocatedID") = row.Item("AllocatedID")
                    If row.Item("LocationID") = 0 And row.Item("AllocatedID") = 0 Then
                        r("Other") = True
                    Else
                        r("Other") = False
                    End If
                    r("Quantity") = row.Item("Quantity")
                    r("PartProductID") = dr("PartID")
                    r("OrderPartProductID") = row.Item("OrderPartProductID")
                    r("StockTransactionType") = row.Item("StockTransactionType")
                    PartsDistribution.Table.Rows.Add(r)
                End If
            Next

            Return True
        Else
            Return False
        End If
    End Function



#End Region


End Class