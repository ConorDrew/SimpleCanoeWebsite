Public Class DataTypeValidator

#Region "Properties"

    Private _ignoreExceptionsOnSetMethods As Boolean = False
    Public Property IgnoreExceptionsOnSetMethods() As Boolean
        Get
            Return Me._ignoreExceptionsOnSetMethods
        End Get
        Set(ByVal Value As Boolean)
            _ignoreExceptionsOnSetMethods = Value
        End Set
    End Property

    Private _errorTable As Hashtable
    Public ReadOnly Property Errors() As Hashtable
        Get
            Return Me._errorTable
        End Get
    End Property

#End Region

#Region "Functions"

    Public Sub New()
        _errorTable = New Hashtable
    End Sub

    Public Sub SetValue(ByVal sender As Object, ByVal variableName As String, ByVal value As Object)
        If value Is Nothing Then
            Return
        End If

        Dim f As System.Reflection.FieldInfo
        Dim propertyName As String

        If Not (value.GetType.IsPrimitive() Or value.GetType.FullName = "System.String" Or value.GetType().FullName = "System.DBNull" Or value.GetType().FullName = "System.Decimal") Then
            Throw New System.Exception("SetValue() can only be used with primitive & string types.")
        End If

        Try

            '################################## Begin changes by Henry ####################################
            'f = sender.GetType().GetField(variableName, _
            '     System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic Or _
            '     System.Reflection.BindingFlags.NonPublic)

            '#################################### Replaced with: ##########################################
            'Loop through the base clases of sender to find the property wanted
            Dim senderType As Type = sender.GetType
            While f Is Nothing
                f = senderType.GetField(variableName, _
                     System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic Or _
                       System.Reflection.BindingFlags.Public Or Reflection.BindingFlags.FlattenHierarchy)
                'If a field wasn't found, try the base class if there is one
                If f Is Nothing AndAlso Not sender.GetType.BaseType Is Nothing Then
                    senderType = senderType.BaseType
                Else
                    Exit While
                End If
            End While
            '####################################### End replaced #########################################


            Dim strValue As String = ""
            propertyName = GetAssociatedSetPropertyName(variableName)
            Dim setProperty As Boolean = True

            If value.GetType().FullName = "System.DBNull" Then
                setProperty = False
            End If

            If setProperty Then
                Select Case f.FieldType.FullName
                    Case "System.Int16", "System.Int32", "System.Int64", "System.Integer", "System.Decimal", "System.Double"
                        If CStr(value).Trim().Length = 0 Then
                            'setProperty = False
                            'Else
                            'value = 0
                            setProperty = True
                        End If
                End Select
            End If

            'for a list of types:
            'ms-help://MS.VSCC.2003/MS.MSDNQTR.2003APR.1033/vblr7/html/vagrpDataType.htm        

            If setProperty Then
                'ok, try and set the value of the variable
                f.SetValue(sender, Convert.ChangeType(value, f.FieldType))
            End If

            'remove error if a previous one exists
            RemoveError(propertyName)

        Catch nre As NullReferenceException
            'remove error if a previous one exists
            RemoveError(propertyName)

            Dim message As String = "Field name '{0}' could not be found in class '{1}'."
            Throw New NullReferenceException(String.Format(message, variableName, sender.GetType().Name))

        Catch ex As Exception
            'remove error if a previous one exists
            RemoveError(propertyName)

            ' value could not be converted  to correct data type.
            Dim message As String = "*'{0}' could not be set because the input was not of type {1}."
            message = String.Format(message, propertyName, f.FieldType.Name)

            If IgnoreExceptionsOnSetMethods() Then
                AddError(propertyName, message)
            Else
                Throw New Exception(message)
            End If
        End Try
    End Sub

    Private Function GetAssociatedSetPropertyName(ByVal fieldName As String) As String
        Dim propertyName As String = fieldName.Substring(fieldName.IndexOf("_") + 1)
        propertyName = Char.ToUpper(propertyName.Chars(0)) & propertyName.Substring(1)
        Return propertyName
    End Function

    Private Sub AddError(ByVal propertyName As String, ByVal errorMessage As String)
        _errorTable.Add(propertyName, errorMessage)
    End Sub

    Private Sub RemoveError(ByVal propertyName As String)
        _errorTable.Remove(propertyName)
    End Sub

#End Region

End Class



