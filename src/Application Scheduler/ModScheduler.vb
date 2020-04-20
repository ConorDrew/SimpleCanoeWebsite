Module ModScheduler
#Region "Datagrid"

    'Set the format and data
    Public Sub SetUpSchedulerDataGrid(ByVal dg As DataGrid, Optional ByVal captionIsVisible As Boolean = False)
        dg.TableStyles.Clear()
        dg.TableStyles.Add(DefaultSchedulerTableStyle)
        dg.AllowNavigation = False
        dg.CaptionVisible = captionIsVisible
        dg.AlternatingBackColor = System.Drawing.Color.GhostWhite
        dg.BackgroundColor = System.Drawing.Color.White
        dg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        dg.CaptionBackColor = System.Drawing.Color.RoyalBlue
        dg.CaptionForeColor = System.Drawing.Color.White
        dg.Font = New System.Drawing.Font("Verdana", 8.0!)
        dg.ForeColor = System.Drawing.Color.MidnightBlue
        dg.GridLineColor = System.Drawing.Color.RoyalBlue
        dg.HeaderBackColor = System.Drawing.Color.MidnightBlue
        dg.HeaderFont = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        dg.HeaderForeColor = System.Drawing.Color.Lavender
        dg.LinkColor = System.Drawing.Color.Teal
        dg.ParentRowsBackColor = System.Drawing.Color.Lavender
        dg.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        dg.ParentRowsVisible = False
        dg.RowHeadersVisible = False
        dg.SelectionBackColor = System.Drawing.Color.Teal
        dg.SelectionForeColor = System.Drawing.Color.PaleGreen
        dg.ReadOnly = True

        AddHandler dg.Click, AddressOf dGrid_Multievents
        AddHandler dg.CurrentCellChanged, AddressOf dGrid_Multievents

    End Sub

    'Fire the events required
    Public Sub dGrid_Multievents(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dg As DataGrid = CType(sender, DataGrid)
        If dg.ReadOnly Then
            If dg.CurrentCell.ColumnNumber > -1 And dg.CurrentRowIndex > -1 Then
                dg.CurrentCell = New DataGridCell(dg.CurrentRowIndex, -1)
                dg.Select(dg.CurrentRowIndex)
            End If
        End If
    End Sub

    'Set the style
    Public Function DefaultSchedulerTableStyle() As DataGridTableStyle
        Dim DataGridTableStyle1 As New DataGridTableStyle
        DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.GhostWhite
        DataGridTableStyle1.BackColor = System.Drawing.Color.GhostWhite
        DataGridTableStyle1.ForeColor = System.Drawing.Color.MidnightBlue
        DataGridTableStyle1.GridLineColor = System.Drawing.Color.RoyalBlue
        DataGridTableStyle1.HeaderBackColor = System.Drawing.Color.MidnightBlue
        DataGridTableStyle1.HeaderForeColor = System.Drawing.Color.Lavender
        DataGridTableStyle1.LinkColor = System.Drawing.Color.Teal
        DataGridTableStyle1.MappingName = ""
        DataGridTableStyle1.ReadOnly = True
        DataGridTableStyle1.RowHeadersVisible = False
        DataGridTableStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridTableStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue
        DataGridTableStyle1.PreferredRowHeight = 10
        Return DataGridTableStyle1
    End Function

#End Region

End Module
