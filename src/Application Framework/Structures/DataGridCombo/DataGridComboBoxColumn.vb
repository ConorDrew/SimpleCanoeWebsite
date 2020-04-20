Imports System
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.ComponentModel
'Imports SolutionsNET.BusinessClass.Bases

Public Class DataGridComboBoxColumn
    Inherits DataGridColumnStyle

#Region " declarations "

    ' This internal combobox is the key component of all this.
    ' It will be moved around to the cells that are to be edited
    ' set to the correct value and then shown.  When 
    ' the user navigates off the cell, then this combobox is
    ' hidden.
    Private WithEvents myComboBox As ComboBox
    Private _getFrom As Boolean = False
    Private _theID As Integer = 0
    Private _type As String = ""
    Private _searchingFor As String
    Private _returnID As Integer = 0
    Private trans As SqlClient.SqlTransaction

    Public Event itemSelected()

    ' You will see this used in the "Edit" and "Commit" members below.
    Private myPreviouslyEditedCellRow As Integer


#End Region

#Region " constructor "

    Public Sub New(Optional ByVal isGetFrom As Boolean = False)
        _getFrom = isGetFrom
        myComboBox = New ComboBox
        myComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        myComboBox.Cursor = Cursors.Hand
        myComboBox.Visible = False
    End Sub

    Public Sub New(ByVal trans As SqlClient.SqlTransaction, Optional ByVal isGetFrom As Boolean = False)
        _getFrom = isGetFrom
        myComboBox = New ComboBox
        myComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        myComboBox.Cursor = Cursors.Hand
        myComboBox.Visible = False
        Me.trans = trans
    End Sub

#End Region

#Region "Events"
    Private Sub myComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myComboBox.SelectedIndexChanged
        If _getFrom = True Then
            Dim IDs() As Integer
            Select Case CInt(myComboBox.SelectedValue)
                Case 1
                    'SUPPLIER
                    Dim SupplierID As Integer = 0
                    SearchingFor = "Supplier"
                    If Type = "Product" Then

                        If Not trans Is Nothing Then
                            SupplierID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct, trans, TheID)
                        Else
                            SupplierID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct, TheID)
                        End If

                        If SupplierID = 0 Then Exit Sub
                        Dim FRMChoose As FRMChooseSupplierPacks = ShowForm(GetType(FRMChooseSupplierPacks), True, New Object() {SupplierID, TheID, 0, trans})
                        If FRMChoose.DialogResult = DialogResult.OK Then
                            ReturnID = FRMChoose.ProductSupplierID
                        End If
                    Else
                        If Not trans Is Nothing Then
                            SupplierID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart, trans, TheID)
                        Else
                            SupplierID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart, TheID)
                        End If

                        If SupplierID = 0 Then Exit Sub
                        Dim FRMChoose As FRMChooseSupplierPacks = ShowForm(GetType(FRMChooseSupplierPacks), True, New Object() {SupplierID, 0, TheID, trans})
                        If FRMChoose.DialogResult = DialogResult.OK Then
                            ReturnID = FRMChoose.PartSupplierID
                        End If
                    End If
                    RaiseEvent itemSelected()
                Case 3
                    'WAREHOUSE
                    SearchingFor = "Warehouse"
                    If Type = "Product" Then
                        If Not trans Is Nothing Then
                            ReturnID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct, trans, TheID)
                        Else
                            ReturnID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct, TheID)
                        End If
                    Else
                        If Not trans Is Nothing Then
                            ReturnID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart, trans, TheID)
                        Else
                            ReturnID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart, TheID)
                        End If

                    End If
                    RaiseEvent itemSelected()
                Case 2
                    'VAN
                    SearchingFor = "Van"
                    If Type = "Product" Then
                        If Not trans Is Nothing Then
                            ReturnID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct, trans, TheID)
                        Else
                            ReturnID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct, TheID)
                        End If
                    Else
                        If Not trans Is Nothing Then
                            ReturnID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart, trans, TheID)
                        Else
                            ReturnID = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart, TheID)
                        End If

                    End If
                    RaiseEvent itemSelected()
            End Select
        End If
    End Sub
#End Region

#Region " accessors "

    Public Property ReturnID() As Integer
        Get
            Return _returnID
        End Get
        Set(ByVal Value As Integer)
            _returnID = Value
        End Set
    End Property

    Public Property TheID() As Integer
        Get
            Return _theID
        End Get
        Set(ByVal Value As Integer)
            _theID = Value
        End Set
    End Property

    Public Property SearchingFor() As String
        Get
            Return _searchingFor
        End Get
        Set(ByVal Value As String)
            _searchingFor = Value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Public ReadOnly Property ComboBox() As ComboBox
        Get
            ' We expose the combobox so that its databinding
            ' properties can be set when we are setting
            ' the columnstyle properties.
            Return myComboBox
        End Get
    End Property

    Private ReadOnly Property parentGrid() As DataGrid
        Get
            ' Just an internal convenience, used in the "Paint" method below.
            Return MyBase.Container
        End Get
    End Property

#End Region

#Region " methods that handle user cell editing "

    Protected Overrides Sub Abort(ByVal rowNum As Integer)
        ' when the user aborts the editing of a combobox cell, this method is called and
        ' it will remove the combobox from site on the form.
        myComboBox.Visible = False
    End Sub

    Protected Overrides Function Commit(ByVal dataSource As CurrencyManager, _
                                        ByVal rowNum As Integer) As Boolean

        ' when the user select's a new item, then the new value needs to be set
        ' in the bound data.
        ' The call to "SetColumnValueAtRow" sets the correct value from 
        ' the("selectedValue")property in the bound data source.

        ' We qualify this to only rows that we know from the 'Edit' method
        ' that we have been editing.

        ' And of course, set the combobox to not be visible in any case.
        Try
            If myPreviouslyEditedCellRow = rowNum Then
                MyBase.SetColumnValueAtRow(dataSource, rowNum, myComboBox.SelectedValue)
            End If

        Catch ex As Exception
            'AMY PUPOSELY LEFT EMPTY
        End Try

        myComboBox.Visible = False

        Return True

    End Function

    Protected Overloads Overrides Sub Edit(ByVal [source] As CurrencyManager, _
                                           ByVal rowNum As Integer, _
                                           ByVal bounds As Rectangle, _
                                           ByVal [readOnly] As Boolean, _
                                           ByVal instantText As String, _
                                           ByVal cellIsVisible As Boolean)
        ' Here is where the work takes place.  Whenever ever the user enters the cell
        ' by any means, this override method is called.

        Debug.WriteLine(String.Format("ComboBox Edit; current Height: {0}", myComboBox.Height))


        ' At this point, the cell is looking just like a text box, and displaying the
        ' appropriate to the user.  But now that we have navigation into the cell, we
        ' need to display our combobox overtop of the location in the form.  But first
        ' we need to make sure that the combobox will be displaying the correct value
        ' for this cell.

        ' First, use our method "GetColumnValueAtRow" to obtain the actual display
        ' value that corresponds to the value in this cell.  
        ' Typically, this is a classic "Lookup" situation, so its a guid, 
        ' or ID code of some sort.  In this demo, its a two letter code 
        ' (such as PA for Pennsylvania) for the state.  So what gets returned
        ' is the "DisplayValue" for the state code.  In other words, "Pennsylvania" 
        ' is returned, not "PA"
        Dim currentValue As Object = Me.GetColumnValueAtRow(source, rowNum)
        If currentValue Is Nothing Then
            ' If its a new row, or if its never been set, then we tell the 
            ' combobox that there is NO selection.
            myComboBox.SelectedItem = Nothing
        Else
            ' But otherwise, we use the "FindStringExact" method to get
            ' the corresponding Index value of a string in our bound "lookup" list
            ' And we set the "SelectedIndex" value accordingly.  This causes the
            ' combobox to have the correct item displayed when we set its
            ' "Visible" property from false to true.
            myComboBox.SelectedIndex = myComboBox.FindStringExact(currentValue)
        End If

        ' This prepares the combobox to be the correct back color for when there
        ' are alternating row colors.
        If IsOdd(rowNum) Then
            myComboBox.BackColor = MyBase.DataGridTableStyle.AlternatingBackColor
        Else
            myComboBox.BackColor = MyBase.DataGridTableStyle.BackColor
        End If

        ' Bounds is a rectangle object that corresponds to the exact coordinates and
        ' size of the current cell we need to edit.  So we use it to put the
        ' combobox at the correct location, and we display it here too.
        myComboBox.Location = New Point(bounds.X, bounds.Y)
        myComboBox.Visible = True

        ' This is a nice UI touch, not functionally necessary but I like it.
        ' It gives consistency to the look and feel the user is 
        ' navigating the grid.
        If Not currentValue Is Nothing Then
            ' make the text selected by default
            Try
                myComboBox.SelectionStart = 0
                myComboBox.SelectionLength = currentValue.ToString.Length
            Catch ex As Exception
                'AMY PUPOSELY LEFT EMPTY
            End Try
        End If

        Debug.WriteLine(("SelectedItem: " + myComboBox.SelectedIndex.ToString))

        ' And this will indicate to the "Commit" method that we have edited the cell
        ' in this row.
        myPreviouslyEditedCellRow = rowNum

    End Sub

    Private Function IsOdd(ByVal number As Integer) As Boolean
        Return ((number Mod 2) <> 0)
    End Function

#End Region

#Region " handle cell value methods "

    Protected Overrides Function GetColumnValueAtRow(ByVal source As CurrencyManager, _
                                                     ByVal rowNum As Integer) As Object
        ' This is a key method.  Given the row number and the
        ' source CurrencyManager, (which contains a reference 
        ' to the bound DataSource list), we can obtain the 
        ' *ValueMember* from the MyBase method, and then use that
        ' to obtain the *DisplayMember* from the combobox
        ' And that is what this method will return.

        ' Get the ValueMember (The lookup code so to speak, like "PA"
        ' in our example)
        Dim myValueMember As Object = MyBase.GetColumnValueAtRow(source, rowNum)

        Dim myDisplayMember As Object

        ' Get the DisplayMember.  In our example it would be "Pennsylvania"
        myDisplayMember = getItem(myValueMember, True)

        ' And return the DisplayMember value
        Return myDisplayMember

    End Function

    Private Function getItem(ByVal findByValue As Object, _
                             ByVal findByValueMember As Boolean) As Object
        ' This method will find items in our ComboBox's datasource.  
        ' Given a valueMember it will find the corresponding 
        ' displayMember, or given a displayMember
        ' it will find the corresponding valueMember.
        ' The "findByValueMember" tells us which way it is.

        ' if findByValueMember is true then we want to return
        ' the corresponding DisplayMember
        ' otherwise then we want to return the corresponding
        ' ValueMember
        Dim returnProperty As String = myComboBox.DisplayMember
        Dim compareProperty As String = myComboBox.ValueMember
        If findByValueMember Then
            returnProperty = myComboBox.DisplayMember
            compareProperty = myComboBox.ValueMember
        Else
            returnProperty = myComboBox.ValueMember
            compareProperty = myComboBox.DisplayMember
        End If

        ' Of course, we iterate datasource of combobox list 
        ' NOT the datasource of the datagrid

        ' We get the currency manager of the datasource here.
        Dim myCm As CurrencyManager = _
            CType(MyBase.DataGridTableStyle.DataGrid.BindingContext(myComboBox.DataSource), _
            CurrencyManager)

        If TypeOf myCm.List Is DataView Then
            ' The ComboBox is bound to a DataView, or DataTable that implements a default
            ' DataView and so cast the currency manager's list to a DataView
            Dim myDV As DataView = CType(myCm.List, DataView)

            ' Now do the iteration
            Dim myIndex As Integer
            For myIndex = 0 To myDV.Count - 1 Step 1
                If findByValue.Equals(myDV.Item(myIndex).Item(compareProperty)) Then
                    Exit For
                End If
            Next

            ' If set item was found return corresponding value, otherwise return nothing
            If myIndex < myDV.Count Then
                Return myDV.Item(myIndex).Item(returnProperty)
            Else
                Return Nothing
            End If
        ElseIf TypeOf myCm.List Is BindableCollection Then
            ' The ComboBox is bound to an IBindingList implementation
            ' so cast the currency manager's list to an IBindingList object
            Dim myList As BindableCollection = CType(myCm.List, BindableCollection)
            Dim myItem As BindableItem
            Dim isEqual As Boolean = False

            ' Now do the iteration
            For Each myItem In myList
                If findByValue.Equals(myItem.PropertyValue(compareProperty)) Then
                    isEqual = True
                    Exit For
                End If
            Next

            ' If set item was found return corresponding value, otherwise return nothing
            If isEqual Then
                Return myItem.PropertyValue(returnProperty)
            Else
                Return Nothing
            End If
        End If

    End Function

#End Region

#Region " Width changed event "

    Private Sub NewComboBoxColumn_WidthChanged(ByVal sender As Object, _
                                               ByVal e As System.EventArgs) _
                                               Handles MyBase.WidthChanged
        ' This method is what adjusts the width of the combobox 
        ' if the user resizes the datagrid column.
        myComboBox.Width = MyBase.Width
        MyBase.Invalidate()
    End Sub

#End Region

#Region " dimension methods "

    Protected Overrides Function GetMinimumHeight() As Integer
        ' When the datagrid is first being painted, it checks each column
        ' for this method and whichever column returns the highest value
        ' that is the value that the row height is set too.

        ' By setting this property to some text value, we force the combobox to adjust
        ' it's height to its font size.  It apparently gets its default 
        ' font size from its container, which is the datagrid.  
        ' So if we change the font of the datagrid, this combobox
        ' font default changes accordingly, and we want our combobox
        ' to reflect that.  Hence setting the text to 'something'
        ' Otherwise, the font size will not be reflected in the
        ' height of our combobox and our minimum height may not 
        ' be adequate.
        myComboBox.SelectedText = "something"
        Return GetPreferredHeight(Nothing, Nothing)
    End Function

    Protected Overrides Function GetPreferredHeight(ByVal g As System.Drawing.Graphics, _
                                                    ByVal value As Object) As Integer
        Return myComboBox.Height
    End Function

    Protected Overrides Function GetPreferredSize(ByVal g As System.Drawing.Graphics, _
                                                  ByVal value As Object) As System.Drawing.Size
        Return New Size(myComboBox.Width, GetPreferredHeight(g, value))
    End Function

#End Region

#Region " paint methods "

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, _
                                            ByVal bounds As System.Drawing.Rectangle, _
                                            ByVal [source] As CurrencyManager, _
                                            ByVal rowNum As Integer)
        Me.Paint(g, bounds, [source], rowNum, False)
    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, _
                                            ByVal bounds As System.Drawing.Rectangle, _
                                            ByVal [source] As CurrencyManager, _
                                            ByVal rowNum As Integer, _
                                            ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, [source], rowNum, Brushes.White, Brushes.Black, False)
    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, _
                                            ByVal bounds As System.Drawing.Rectangle, _
                                            ByVal [source] As CurrencyManager, _
                                            ByVal rowNum As Integer, _
                                            ByVal backBrush As System.Drawing.Brush, _
                                            ByVal foreBrush As System.Drawing.Brush, _
                                            ByVal alignToRight As Boolean)
        ' This method is responsible for painting the cell
        ' for all instances except when the combobox is visible.
        ' This method usually gets called once for each
        ' row in the column.  So the grid uses this method
        ' on each column style to paint itself cell by 
        ' cell from left to right and top to bottom.

        ' So first, we want to get the value of the text that needs to be shown.
        Dim displayMember As String = Me.GetColumnValueAtRow([source], rowNum)

        ' Next we want to paint the whole background color of
        ' the cell area appropriately.  By using the backBrush
        ' passed in, we get the color of the rest of the row
        ' and so this column cell will match the rest of the
        ' row.  This makes for row selections and alternating
        ' row colors to be painted appropriately in this cell.

        ' colour the row if it is selected
        If [source].Position <> -1 Then
            If rowNum = [source].Position Then
                g.FillRectangle(New SolidBrush(Color.LightSteelBlue), bounds)
            Else
                g.FillRectangle(backBrush, bounds)
            End If
        End If

        ' demo this line and then comment it out.
        'g.FillRectangle(New SolidBrush(Color.White), bounds)



        ' Next, we create slightly adjusted rectangle in which to 
        ' paint the text overtop of the background just painted.
        Dim textRect As RectangleF
        textRect = New RectangleF(bounds.X + 1, _
                                  bounds.Y + 2, _
                                  bounds.Width - 3, _
                                  MyBase.FontHeight)
        ' demo this line to show how an unadjusted text draw looks
        ' then comment it out.
        'textRect = New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height)

        g.DrawString(displayMember, myComboBox.Font, foreBrush, textRect)


    End Sub

#End Region

#Region " column setup overrides "

    Protected Overrides Sub SetDataGridInColumn(ByVal value As DataGrid)

        ' This method probably sets a reference within
        ' our base to the parent datagrid, so it may be
        ' retrieved from the MyBase.Container property.
        ' Likely called early on when the tablestyle is
        ' added to the DataGridTableStyles collection
        ' of the datagrid to which this belongs
        MyBase.SetDataGridInColumn(value)

        ' And here, we make sure that the Parent DataGrid
        ' contains a reference to this instance in its
        ' collection of contained controls.
        If Not value.Controls.Contains(myComboBox) Then
            value.Controls.Add(myComboBox)
        End If

    End Sub

#End Region

End Class
