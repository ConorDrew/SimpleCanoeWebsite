Public Class DataGridCheckBox
    Inherits DataGridColumnStyle

    Friend WithEvents chkBox As New CheckBox

    ' The isEditing field tracks whether or not the user is
    ' editing data with the hosted control.
    Private isEditing As Boolean

    Public Sub New()
        Me.chkBox.Checked = False
        Me.chkBox.Visible = False

        Me.chkBox.CheckAlign = ContentAlignment.MiddleCenter
        Me.Alignment = HorizontalAlignment.Center
    End Sub

    Protected Overrides Sub Abort(ByVal rowNum As Integer)
        isEditing = False
        RemoveHandler chkBox.CheckedChanged, _
        AddressOf CheckBoxChanged
        Invalidate()
    End Sub

    Public Event CheckedChanged(ByVal checked As Integer)

    Private Sub CheckBoxChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.isEditing = True
        MyBase.ColumnStartedEditing(chkBox)
    End Sub

    Protected Overrides Function Commit(ByVal dataSource As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Boolean
        chkBox.Bounds = Rectangle.Empty

        AddHandler chkBox.CheckedChanged, _
        AddressOf CheckBoxChanged

        'If Not isEditing Then
        '    Return True
        'End If
        isEditing = False
        chkBox.Enabled = True


        Try
            Dim value As Integer = CInt(chkBox.Checked) * -1
            SetColumnValueAtRow(dataSource, rowNum, value)
            RaiseEvent CheckedChanged(CInt(chkBox.Checked))
        Catch
        End Try

        Invalidate()

        Try
            CType(dataSource.Current, DataRowView).Row.AcceptChanges()
        Catch ex As Exception

        End Try


        Return True
    End Function

    Protected Overloads Overrides Sub Edit( _
     ByVal [source] As CurrencyManager, _
    ByVal rowNum As Integer, _
    ByVal bounds As Rectangle, _
    ByVal [readOnly] As Boolean, _
    ByVal instantText As String, _
    ByVal cellIsVisible As Boolean)


        If Not IsDBNull(GetColumnValueAtRow([source], rowNum)) Then
            Dim value As Boolean = _
            CType(GetColumnValueAtRow([source], rowNum), Boolean)

            If cellIsVisible Then
                chkBox.Bounds = New Rectangle _
                    (bounds.X + 2, bounds.Y + 2, bounds.Width - 4, _
                    bounds.Height - 4)

                chkBox.BackColor = Color.Transparent
                chkBox.Checked = Not value
                chkBox.Visible = True

                SetColumnValueAtRow([source], rowNum, chkBox.Checked)

                AddHandler chkBox.CheckedChanged, _
                AddressOf CheckBoxChanged

                RaiseEvent CheckedChanged(chkBox.Checked)


            Else
                chkBox.Checked = value
                chkBox.Visible = False
            End If

            If chkBox.Visible Then
                DataGridTableStyle.DataGrid.Invalidate(bounds)
            End If
        End If
        Commit([source], rowNum)
        concedefocus()
        updateUI(source, rowNum, instantText)
    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal [source] As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)

        Dim rect As Rectangle = New Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width - 3, _
                 bounds.Height - 3)

        If IsDBNull(GetColumnValueAtRow([source], rowNum)) = False Then
            Dim checked As Boolean = CType(GetColumnValueAtRow([source], rowNum), Boolean)

            g.FillRectangle(backBrush, bounds)

            If checked = True Then
                ControlPaint.DrawCheckBox(g, rect, ButtonState.Checked)
            Else
                ControlPaint.DrawCheckBox(g, rect, ButtonState.Normal)
            End If
        Else
            g.FillRectangle(backBrush, bounds)

            ControlPaint.DrawCheckBox(g, rect, ButtonState.Inactive)
        End If
    End Sub

    Protected Overrides Sub SetDataGridInColumn(ByVal value As DataGrid)
        MyBase.SetDataGridInColumn(value)
        If Not (chkBox.Parent Is Nothing) Then
            chkBox.Parent.Controls.Remove(chkBox)
        End If
        If Not (value Is Nothing) Then
            value.Controls.Add(chkBox)
        End If
    End Sub

    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return Not chkBox.Enabled
        End Get
        Set(ByVal Value As Boolean)
            chkBox.Enabled = Not (Value)
        End Set
    End Property

    Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, ByVal value As Object) As System.Drawing.Size

    End Function

    Protected Overrides Function GetMinimumHeight() As Integer

    End Function

    Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, ByVal value As Object) As Integer

    End Function

    Protected Overrides Sub ColumnStartedEditing(ByVal editingControl As System.Windows.Forms.Control)

    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer)

    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)

    End Sub

    
End Class
