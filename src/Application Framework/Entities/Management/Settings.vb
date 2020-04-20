Namespace Entity

    Namespace Management

        Public Class Settings

            Private _dataTypeValidator As DataTypeValidator
            Public Sub New()
                _dataTypeValidator = New DataTypeValidator
            End Sub

#Region "Class Properties"

            Public Property IgnoreExceptionsOnSetMethods() As Boolean
                Get
                    Return Me._dataTypeValidator.IgnoreExceptionsOnSetMethods
                End Get
                Set(ByVal Value As Boolean)
                    Me._dataTypeValidator.IgnoreExceptionsOnSetMethods = Value
                End Set
            End Property

            Public ReadOnly Property Errors() As Hashtable
                Get
                    Return _dataTypeValidator.Errors
                End Get
            End Property

            Public ReadOnly Property DTValidator() As DataTypeValidator
                Get
                    Return _dataTypeValidator
                End Get
            End Property

            Private _exists As Boolean = False
            Public Property Exists() As Boolean
                Get
                    Return _exists
                End Get
                Set(ByVal Value As Boolean)
                    _exists = Value
                End Set
            End Property

            Private _deleted As Boolean = False
            Public ReadOnly Property Deleted() As Boolean
                Get
                    Return _deleted
                End Get
            End Property
            Public WriteOnly Property SetDeleted() As Boolean
                Set(ByVal Value As Boolean)
                    _deleted = Value
                End Set
            End Property

#End Region

#Region "Settings"

            Private _WorkingHoursStart As String = String.Empty
            Public ReadOnly Property WorkingHoursStart() As String
                Get
                    Return _WorkingHoursStart
                End Get
            End Property
            Public WriteOnly Property SetWorkingHoursStart() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_WorkingHoursStart", Value)
                End Set
            End Property

            Private _WorkingHoursEnd As String = String.Empty
            Public ReadOnly Property WorkingHoursEnd() As String
                Get
                    Return _WorkingHoursEnd
                End Get
            End Property
            Public WriteOnly Property SetWorkingHoursEnd() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_WorkingHoursEnd", Value)
                End Set
            End Property

            Private _OverridePassword As String = String.Empty
            Public ReadOnly Property OverridePassword() As String
                Get
                    Return _OverridePassword
                End Get
            End Property
            Public WriteOnly Property SetOverridePassword() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OverridePassword", Value)
                End Set
            End Property

            Private _OverridePassword_Service As String = String.Empty
            Public ReadOnly Property OverridePassword_Service() As String
                Get
                    Return _OverridePassword_Service
                End Get
            End Property
            Public WriteOnly Property SetOverridePassword_Service() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OverridePassword_Service", Value)
                End Set
            End Property

            Private _MileageRate As Double = 1
            Public ReadOnly Property MileageRate() As Double
                Get
                    Return _MileageRate
                End Get
            End Property
            Public WriteOnly Property SetMileageRate() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MileageRate", Value)
                End Set
            End Property

            Private _PartsMarkup As Double = 0
            Public ReadOnly Property PartsMarkup() As Double
                Get
                    Return _PartsMarkup
                End Get
            End Property
            Public WriteOnly Property SetPartsMarkup() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartsMarkup", Value)
                End Set
            End Property


            Private _RatesMarkup As Double = 0
            Public ReadOnly Property RatesMarkup() As Double
                Get
                    Return _RatesMarkup
                End Get
            End Property
            Public WriteOnly Property SetRatesMarkup() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RatesMarkup", Value)
                End Set
            End Property


            Private _CalloutPrefix As String = String.Empty
            Public ReadOnly Property CalloutPrefix() As String
                Get
                    Return _CalloutPrefix
                End Get
            End Property
            Public WriteOnly Property SetCalloutPrefix() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CalloutPrefix", Value)
                End Set
            End Property

            Private _MiscPrefix As String = String.Empty
            Public ReadOnly Property MiscPrefix() As String
                Get
                    Return _MiscPrefix
                End Get
            End Property
            Public WriteOnly Property SetMiscPrefix() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MiscPrefix", Value)
                End Set
            End Property

            Private _PPMPrefix As String = String.Empty
            Public ReadOnly Property PPMPrefix() As String
                Get
                    Return _PPMPrefix
                End Get
            End Property
            Public WriteOnly Property SetPPMPrefix() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PPMPrefix", Value)
                End Set
            End Property

            Private _QuotePrefix As String = String.Empty
            Public ReadOnly Property QuotePrefix() As String
                Get
                    Return _QuotePrefix
                End Get
            End Property
            Public WriteOnly Property SetQuotePrefix() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuotePrefix", Value)
                End Set
            End Property

            Private _TimeSlot As Integer = 0
            Public ReadOnly Property TimeSlot() As Integer
                Get
                    Return _TimeSlot
                End Get
            End Property
            Public WriteOnly Property SetTimeSlot() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TimeSlot", Value)
                End Set
            End Property

            Private _InvoicePrefix As String = String.Empty
            Public ReadOnly Property InvoicePrefix() As String
                Get
                    Return _InvoicePrefix
                End Get
            End Property
            Public WriteOnly Property SetInvoicePrefix() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoicePrefix", Value)
                End Set
            End Property

            Private _RecallVariable As Integer = 0
            Public ReadOnly Property RecallVariable() As Integer
                Get
                    Return _RecallVariable
                End Get
            End Property
            Public WriteOnly Property SetRecallVariable() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RecallVariable", Value)
                End Set
            End Property


            Private _PartsImportMarkup As Double = 0
            Public ReadOnly Property PartsImportMarkup() As Double
                Get
                    Return _PartsImportMarkup
                End Get
            End Property
            Public WriteOnly Property SetPartsImportMarkup() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartsImportMarkup", Value)
                End Set
            End Property

            Private _ServiceFromLetterPrefix As String = String.Empty
            Public ReadOnly Property ServiceFromLetterPrefix() As String
                Get
                    Return _ServiceFromLetterPrefix
                End Get
            End Property
            Public WriteOnly Property SetServiceFromLetterPrefix() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ServiceFromLetterPrefix", Value)
                End Set
            End Property
#End Region

        End Class

    End Namespace

End Namespace
