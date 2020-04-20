Public Class Combo

#Region "Properties"

    Private _description As String = ""

    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal Value As String)
            _description = Value
        End Set
    End Property

    Private _value As String = ""

    Public Property Value() As String
        Get
            Return _value
        End Get
        Set(ByVal Value As String)
            _value = Value
        End Set
    End Property

    Private _additionalItem As Object = Nothing

    Public Property AdditionalItem() As Object
        Get
            Return _additionalItem
        End Get
        Set(ByVal Value As Object)
            _additionalItem = Value
        End Set
    End Property

#End Region

#Region "Functions"

    Sub New(ByVal descriptionIn As String, ByVal valueIn As String, Optional ByVal additionalItemIn As Object = Nothing)
        Description = descriptionIn
        Value = valueIn
        AdditionalItem = additionalItemIn
    End Sub

    Public Shared Sub SetSelectedComboItem_By_Value(ByRef combo As ComboBox, ByVal value As String)
        Dim index As Integer = 0
        For Each item As Combo In combo.Items
            If item.Value = value Then
                combo.SelectedIndex = index
                Exit Sub
            End If
            index += 1
        Next
    End Sub

    Public Shared Sub SetSelectedComboItem_By_Description(ByRef combo As ComboBox, ByVal description As String)
        Dim index As Integer = 0
        For Each item As Combo In combo.Items
            If item.Description = description Then
                combo.SelectedIndex = index
                Exit Sub
            End If
            index += 1
        Next
    End Sub

    Public Shared ReadOnly Property GetSelectedItemValue(ByVal comboIn As ComboBox) As String
        Get
            Try
                Return CType(comboIn.SelectedItem, Combo).Value
            Catch
                Return 0
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property GetSelectedItemDescription(ByVal comboIn As ComboBox) As String
        Get
            Try
                If IsAnInitialItem(comboIn) Then
                    Return ""
                Else
                    Return CType(comboIn.SelectedItem, Combo).Description
                End If
            Catch
                Return ""
            End Try
        End Get
    End Property

    Private Shared ReadOnly Property IsAnInitialItem(ByVal comboIn As ComboBox) As Boolean
        Get
            Try
                If CType(comboIn.SelectedItem, Combo).Description.ToLower.StartsWith("-- Please Select --".ToLower) Then
                    Return True
                ElseIf CType(comboIn.SelectedItem, Combo).Description.ToLower.StartsWith("-- Add New --".ToLower) Then
                    Return True
                ElseIf CType(comboIn.SelectedItem, Combo).Description.ToLower.StartsWith("-- Other --".ToLower) Then
                    Return True
                ElseIf CType(comboIn.SelectedItem, Combo).Description.ToLower.StartsWith("-- No Filter --".ToLower) Then
                    Return True
                ElseIf CType(comboIn.SelectedItem, Combo).Description.ToLower.StartsWith("-- Off The Road --".ToLower) Then
                    Return True
                ElseIf CType(comboIn.SelectedItem, Combo).Description.ToLower.StartsWith("-- Not Applicable --".ToLower) Then
                    Return True
                ElseIf CType(comboIn.SelectedItem, Combo).Description.ToLower.StartsWith("--".ToLower) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return True
            End Try
        End Get
    End Property

    'Set the format and data
    Public Shared Sub SetUpCombo(ByRef c As ComboBox, ByVal DT As DataTable, ByVal ValueMember As String, ByVal DisplayMember As String, Optional ByVal InitialItemText As Entity.Sys.Enums.ComboValues = Entity.Sys.Enums.ComboValues.None)
        c.Items.Clear()

        If InitialItemText <> Entity.Sys.Enums.ComboValues.None Then
            Select Case InitialItemText
                Case Entity.Sys.Enums.ComboValues.Please_Select
                    c.Items.Add(New Combo("-- Please Select --", 0))
                Case Entity.Sys.Enums.ComboValues.Please_Select_Negative
                    c.Items.Add(New Combo("-- Please Select --", -1))
                Case Entity.Sys.Enums.ComboValues.Add_New
                    c.Items.Add(New Combo("-- Add New --", 0))
                Case Entity.Sys.Enums.ComboValues.Other
                    c.Items.Add(New Combo("-- Other --", 0))
                Case Entity.Sys.Enums.ComboValues.No_Filter
                    c.Items.Add(New Combo("-- No Filter --", 0))
                Case Entity.Sys.Enums.ComboValues.Off_The_Road
                    c.Items.Add(New Combo("-- Off The Road --", 0))
                Case Entity.Sys.Enums.ComboValues.Not_Applicable
                    c.Items.Add(New Combo("-- Not Applicable --", 0))
                Case Entity.Sys.Enums.ComboValues.Dashes
                    c.Items.Add(New Combo("--", 0))
                Case Entity.Sys.Enums.ComboValues.All_Appointments
                    c.Items.Add(New Combo("-- All Appointments --", 0))
            End Select
        End If

        If Not DT Is Nothing Then
            For Each DataRow As DataRow In DT.Rows
                c.Items.Add(New Combo(SetComboDeletedPostfix(DataRow, DisplayMember), DataRow.Item(ValueMember)))
            Next
        End If

        c.DisplayMember = "Description"
        c.ValueMember = "Value"

        Select Case InitialItemText
            Case Entity.Sys.Enums.ComboValues.Please_Select_Negative
                SetSelectedComboItem_By_Value(c, "-1")
            Case Else
                SetSelectedComboItem_By_Value(c, "0")
        End Select
    End Sub

    Public Shared Sub SetUpComboQual(ByRef c As ComboBox, ByVal DT As DataTable, ByVal ValueMember As String, ByVal DisplayMember As String, Optional ByVal InitialItemText As Entity.Sys.Enums.ComboValues = Entity.Sys.Enums.ComboValues.None)
        c.Items.Clear()

        If InitialItemText <> Entity.Sys.Enums.ComboValues.None Then
            Select Case InitialItemText
                Case Entity.Sys.Enums.ComboValues.Please_Select
                    c.Items.Add(New Combo("-- Please Select --", 0))
                Case Entity.Sys.Enums.ComboValues.Add_New
                    c.Items.Add(New Combo("-- Add New --", 0))
                Case Entity.Sys.Enums.ComboValues.Other
                    c.Items.Add(New Combo("-- Other --", 0))
                Case Entity.Sys.Enums.ComboValues.No_Filter
                    c.Items.Add(New Combo("-- No Filter --", 0))
                Case Entity.Sys.Enums.ComboValues.Off_The_Road
                    c.Items.Add(New Combo("-- Off The Road --", 0))
                Case Entity.Sys.Enums.ComboValues.Not_Applicable
                    c.Items.Add(New Combo("-- Not Applicable --", 0))
                Case Entity.Sys.Enums.ComboValues.Dashes
                    c.Items.Add(New Combo("--", 0))
            End Select
        End If

        If Not DT Is Nothing Then
            For Each DataRow As DataRow In DT.Rows
                c.Items.Add(New Combo(DataRow("Description") + " * " + SetComboDeletedPostfix(DataRow, DisplayMember), DataRow.Item(ValueMember)))
            Next
        End If

        c.DisplayMember = "Description"
        c.ValueMember = "Value"

        SetSelectedComboItem_By_Value(c, "0")
    End Sub

    'Place a prefix on the item to indicate the fact that it is a deleted record
    Private Shared Function SetComboDeletedPostfix(ByVal DR As DataRow, ByVal DisplayMember As String) As String
        Try
            If Entity.Sys.Helper.MakeBooleanValid(DR.Item("Deleted")) Then
                Return DR.Item(DisplayMember) & TheSystem.DeletedPostfix
            Else
                Return DR.Item(DisplayMember)
            End If
        Catch
            'We know the table does not have a 'Deleted' column in it
            Return DR.Item(DisplayMember)
        End Try
    End Function

#End Region

End Class