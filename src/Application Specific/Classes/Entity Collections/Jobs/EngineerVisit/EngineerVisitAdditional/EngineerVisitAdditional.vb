Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitAdditionals

        Public Class EngineerVisitAdditional

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

#Region "EngineerVisitNCCGSR Properties"


            Private _EngineerVisitID As Integer = 0
            Public ReadOnly Property EngineerVisitID() As Integer
                Get
                    Return _EngineerVisitID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitID", Value)
                End Set
            End Property


            Private _EngineerVisitAdditionalID As Integer = 0
            Public ReadOnly Property EngineerVisitAdditionalID() As Integer
                Get
                    Return _EngineerVisitAdditionalID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitAdditionalID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitAdditionalID", Value)
                End Set
            End Property

            Private _TestTypeID As Integer = 0
            Public ReadOnly Property TestTypeID() As Integer
                Get
                    Return _TestTypeID
                End Get
            End Property
            Public WriteOnly Property SetTestTypeID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TestTypeID", Value)
                End Set
            End Property

            Private _Test1 As Integer = 0
            Public ReadOnly Property Test1() As Integer
                Get
                    Return _Test1
                End Get
            End Property
            Public WriteOnly Property SetTest1() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test1", Value)
                End Set
            End Property

            Private _Test2 As Integer = 0
            Public ReadOnly Property Test2() As Integer
                Get
                    Return _Test2
                End Get
            End Property
            Public WriteOnly Property SetTest2() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test2", Value)
                End Set
            End Property

            Private _Test3 As Integer = 0
            Public ReadOnly Property Test3() As Integer
                Get
                    Return _Test3
                End Get
            End Property
            Public WriteOnly Property SetTest3() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test3", Value)
                End Set
            End Property

            Private _Test4 As Integer = 0
            Public ReadOnly Property Test4() As Integer
                Get
                    Return _Test4
                End Get
            End Property
            Public WriteOnly Property SetTest4() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test4", Value)
                End Set
            End Property

            Private _Test5 As Integer = 0
            Public ReadOnly Property Test5() As Integer
                Get
                    Return _Test5
                End Get
            End Property
            Public WriteOnly Property SetTest5() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test5", Value)
                End Set
            End Property

            Private _Test6 As Integer = 0
            Public ReadOnly Property Test6() As Integer
                Get
                    Return _Test6
                End Get
            End Property
            Public WriteOnly Property SetTest6() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test6", Value)
                End Set
            End Property

            Private _Test7 As Integer = 0
            Public ReadOnly Property Test7() As Integer
                Get
                    Return _Test7
                End Get
            End Property
            Public WriteOnly Property SetTest7() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test7", Value)
                End Set
            End Property

            Private _Test8 As Integer = 0
            Public ReadOnly Property Test8() As Integer
                Get
                    Return _Test8
                End Get
            End Property
            Public WriteOnly Property SetTest8() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test8", Value)
                End Set
            End Property

            Private _Test9 As Integer = 0
            Public ReadOnly Property Test9() As Integer
                Get
                    Return _Test9
                End Get
            End Property
            Public WriteOnly Property SetTest9() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test9", Value)
                End Set
            End Property

            Private _Test10 As Integer = 0
            Public ReadOnly Property Test10() As Integer
                Get
                    Return _Test10
                End Get
            End Property
            Public WriteOnly Property SetTest10() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test10", Value)
                End Set
            End Property



            Private _Test111 As Integer = 0
            Public ReadOnly Property Test111() As Integer
                Get
                    Return _Test111
                End Get
            End Property
            Public WriteOnly Property SetTest111() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test111", Value)
                End Set
            End Property





            Private _Test112 As Integer = 0
            Public ReadOnly Property Test112() As Integer
                Get
                    Return _Test112
                End Get
            End Property
            Public WriteOnly Property SetTest112() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test112", Value)
                End Set
            End Property



            Private _Test113 As Integer = 0
            Public ReadOnly Property Test113() As Integer
                Get
                    Return _Test113
                End Get
            End Property
            Public WriteOnly Property SetTest113() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test113", Value)
                End Set
            End Property



            Private _Test114 As Integer = 0
            Public ReadOnly Property Test114() As Integer
                Get
                    Return _Test114
                End Get
            End Property
            Public WriteOnly Property SetTest114() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test114", Value)
                End Set
            End Property



            Private _Test115 As Integer = 0
            Public ReadOnly Property Test115() As Integer
                Get
                    Return _Test115
                End Get
            End Property
            Public WriteOnly Property SetTest115() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test115", Value)
                End Set
            End Property



            Private _Test116 As Integer = 0
            Public ReadOnly Property Test116() As Integer
                Get
                    Return _Test116
                End Get
            End Property
            Public WriteOnly Property SetTest116() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test116", Value)
                End Set
            End Property



            Private _Test117 As Integer = 0
            Public ReadOnly Property Test117() As Integer
                Get
                    Return _Test117
                End Get
            End Property
            Public WriteOnly Property SetTest117() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test117", Value)
                End Set
            End Property



            Private _Test118 As Integer = 0
            Public ReadOnly Property Test118() As Integer
                Get
                    Return _Test118
                End Get
            End Property
            Public WriteOnly Property SetTest118() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test118", Value)
                End Set
            End Property





            Private _Test119 As Integer = 0
            Public ReadOnly Property Test119() As Integer
                Get
                    Return _Test119
                End Get
            End Property
            Public WriteOnly Property SetTest119() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test119", Value)
                End Set
            End Property


            Private _Test120 As Integer = 0
            Public ReadOnly Property Test120() As Integer
                Get
                    Return _Test120
                End Get
            End Property
            Public WriteOnly Property SetTest120() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test120", Value)
                End Set
            End Property




            Private _Test11 As String = String.Empty
            Public ReadOnly Property Test11() As String
                Get
                    Return _Test11
                End Get
            End Property
            Public WriteOnly Property SetTest11() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test11", Value)
                End Set
            End Property

            Private _Test12 As String = String.Empty
            Public ReadOnly Property Test12() As String
                Get
                    Return _Test12
                End Get
            End Property
            Public WriteOnly Property SetTest12() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test12", Value)
                End Set
            End Property

            Private _Test13 As String = String.Empty
            Public ReadOnly Property Test13() As String
                Get
                    Return _Test13
                End Get
            End Property
            Public WriteOnly Property SetTest13() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test13", Value)
                End Set
            End Property

            Private _Test14 As String = String.Empty
            Public ReadOnly Property Test14() As String
                Get
                    Return _Test14
                End Get
            End Property
            Public WriteOnly Property SetTest14() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test14", Value)
                End Set
            End Property

            Private _Test15 As String = String.Empty
            Public ReadOnly Property Test15() As String
                Get
                    Return _Test15
                End Get
            End Property
            Public WriteOnly Property SetTest15() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test15", Value)
                End Set
            End Property


            Private _Test121 As Integer = 0
            Public ReadOnly Property Test121() As Integer
                Get
                    Return _Test121
                End Get
            End Property
            Public WriteOnly Property SetTest121() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test121", Value)
                End Set
            End Property


            Private _Test122 As Integer = 0
            Public ReadOnly Property Test122() As Integer
                Get
                    Return _Test122
                End Get
            End Property
            Public WriteOnly Property SetTest122() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test122", Value)
                End Set
            End Property


            Private _Test123 As Integer = 0
            Public ReadOnly Property Test123() As Integer
                Get
                    Return _Test123
                End Get
            End Property
            Public WriteOnly Property SetTest123() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test123", Value)
                End Set
            End Property

            Private _Test124 As Integer = 0
            Public ReadOnly Property Test124() As Integer
                Get
                    Return _Test124
                End Get
            End Property
            Public WriteOnly Property SetTest124() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test124", Value)
                End Set
            End Property

            Private _Test125 As Integer = 0
            Public ReadOnly Property Test125() As Integer
                Get
                    Return _Test125
                End Get
            End Property
            Public WriteOnly Property SetTest125() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test125", Value)
                End Set
            End Property


            Private _Test126 As Integer = 0
            Public ReadOnly Property Test126() As Integer
                Get
                    Return _Test126
                End Get
            End Property
            Public WriteOnly Property SetTest126() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test126", Value)
                End Set
            End Property

            Private _Test127 As Integer = 0
            Public ReadOnly Property Test127() As Integer
                Get
                    Return _Test125
                End Get
            End Property
            Public WriteOnly Property SetTest127() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test127", Value)
                End Set
            End Property



            Private _Test128 As Integer = 0
            Public ReadOnly Property Test128() As Integer
                Get
                    Return _Test128
                End Get
            End Property
            Public WriteOnly Property SetTest128() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test128", Value)
                End Set
            End Property



            Private _Test129 As Integer = 0
            Public ReadOnly Property Test129() As Integer
                Get
                    Return _Test129
                End Get
            End Property
            Public WriteOnly Property SetTest129() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test129", Value)
                End Set
            End Property


            Private _Test130 As Integer = 0
            Public ReadOnly Property Test130() As Integer
                Get
                    Return _Test130
                End Get
            End Property
            Public WriteOnly Property SetTest130() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test130", Value)
                End Set
            End Property



            Private _Test131 As Integer = 0
            Public ReadOnly Property Test131() As Integer
                Get
                    Return _Test131
                End Get
            End Property
            Public WriteOnly Property SetTest131() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test131", Value)
                End Set
            End Property



            Private _Test132 As Integer = 0
            Public ReadOnly Property Test132() As Integer
                Get
                    Return _Test132
                End Get
            End Property
            Public WriteOnly Property SetTest132() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test132", Value)
                End Set
            End Property



            Private _Test133 As Integer = 0
            Public ReadOnly Property Test133() As Integer
                Get
                    Return _Test133
                End Get
            End Property
            Public WriteOnly Property SetTest133() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test133", Value)
                End Set
            End Property



            Private _Test134 As Integer = 0
            Public ReadOnly Property Test134() As Integer
                Get
                    Return _Test134
                End Get
            End Property
            Public WriteOnly Property SetTest134() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test134", Value)
                End Set
            End Property



            Private _Test135 As Integer = 0
            Public ReadOnly Property Test135() As Integer
                Get
                    Return _Test135
                End Get
            End Property
            Public WriteOnly Property SetTest135() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test135", Value)
                End Set
            End Property



            Private _Test136 As Integer = 0
            Public ReadOnly Property Test136() As Integer
                Get
                    Return _Test136
                End Get
            End Property
            Public WriteOnly Property SetTest136() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test136", Value)
                End Set
            End Property



            Private _Test137 As Integer = 0
            Public ReadOnly Property Test137() As Integer
                Get
                    Return _Test137
                End Get
            End Property
            Public WriteOnly Property SetTest137() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test137", Value)
                End Set
            End Property



            Private _Test138 As Integer = 0
            Public ReadOnly Property Test138() As Integer
                Get
                    Return _Test138
                End Get
            End Property
            Public WriteOnly Property SetTest138() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test138", Value)
                End Set
            End Property



            Private _Test139 As Integer = 0
            Public ReadOnly Property Test139() As Integer
                Get
                    Return _Test139
                End Get
            End Property
            Public WriteOnly Property SetTest139() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test139", Value)
                End Set
            End Property


            Private _Test140 As Integer = 0
            Public ReadOnly Property Test140() As Integer
                Get
                    Return _Test140
                End Get
            End Property
            Public WriteOnly Property SetTest140() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test140", Value)
                End Set
            End Property









            Private _Test216 As String = String.Empty
            Public ReadOnly Property Test216() As String
                Get
                    Return _Test216
                End Get
            End Property
            Public WriteOnly Property SetTest216() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test216", Value)
                End Set
            End Property


            Private _Test217 As String = String.Empty
            Public ReadOnly Property Test217() As String
                Get
                    Return _Test217
                End Get
            End Property
            Public WriteOnly Property SetTest217() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test217", Value)
                End Set
            End Property


            Private _Test218 As String = String.Empty
            Public ReadOnly Property Test218() As String
                Get
                    Return _Test218
                End Get
            End Property
            Public WriteOnly Property SetTest218() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test218", Value)
                End Set
            End Property


            Private _Test219 As String = String.Empty
            Public ReadOnly Property Test219() As String
                Get
                    Return _Test219
                End Get
            End Property
            Public WriteOnly Property SetTest219() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test219", Value)
                End Set
            End Property


            Private _Test220 As String = String.Empty
            Public ReadOnly Property Test220() As String
                Get
                    Return _Test220
                End Get
            End Property
            Public WriteOnly Property SetTest220() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test220", Value)
                End Set
            End Property


            Private _Test221 As String = String.Empty
            Public ReadOnly Property Test221() As String
                Get
                    Return _Test221
                End Get
            End Property
            Public WriteOnly Property SetTest221() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test221", Value)
                End Set
            End Property



            Private _Test222 As String = String.Empty
            Public ReadOnly Property Test222() As String
                Get
                    Return _Test222
                End Get
            End Property
            Public WriteOnly Property SetTest222() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test222", Value)
                End Set
            End Property


            Private _Test223 As String = String.Empty
            Public ReadOnly Property Test223() As String
                Get
                    Return _Test223
                End Get
            End Property
            Public WriteOnly Property SetTest223() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test223", Value)
                End Set
            End Property

            Private _Test224 As String = String.Empty
            Public ReadOnly Property Test224() As String
                Get
                    Return _Test224
                End Get
            End Property
            Public WriteOnly Property SetTest224() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test224", Value)
                End Set
            End Property
            Private _Test225 As String = String.Empty
            Public ReadOnly Property Test225() As String
                Get
                    Return _Test225
                End Get
            End Property
            Public WriteOnly Property SetTest225() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test225", Value)
                End Set
            End Property
            Private _Test226 As String = String.Empty
            Public ReadOnly Property Test226() As String
                Get
                    Return _Test226
                End Get
            End Property
            Public WriteOnly Property SetTest226() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test226", Value)
                End Set
            End Property

            Private _Test227 As String = String.Empty
            Public ReadOnly Property Test227() As String
                Get
                    Return _Test227
                End Get
            End Property
            Public WriteOnly Property SetTest227() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test227", Value)
                End Set
            End Property


            Private _Test228 As String = String.Empty
            Public ReadOnly Property Test228() As String
                Get
                    Return _Test228
                End Get
            End Property
            Public WriteOnly Property SetTest228() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test228", Value)
                End Set
            End Property


            Private _Test229 As String = String.Empty
            Public ReadOnly Property Test229() As String
                Get
                    Return _Test229
                End Get
            End Property
            Public WriteOnly Property SetTest229() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test229", Value)
                End Set
            End Property


            Private _Test230 As String = String.Empty
            Public ReadOnly Property Test230() As String
                Get
                    Return _Test230
                End Get
            End Property
            Public WriteOnly Property SetTest230() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test230", Value)
                End Set
            End Property


            Private _Test231 As String = String.Empty
            Public ReadOnly Property Test231() As String
                Get
                    Return _Test231
                End Get
            End Property
            Public WriteOnly Property SetTest231() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test231", Value)
                End Set
            End Property


            Private _Test232 As String = String.Empty
            Public ReadOnly Property Test232() As String
                Get
                    Return _Test232
                End Get
            End Property
            Public WriteOnly Property SetTest232() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test232", Value)
                End Set
            End Property


            Private _Test233 As String = String.Empty
            Public ReadOnly Property Test233() As String
                Get
                    Return _Test233
                End Get
            End Property
            Public WriteOnly Property SetTest233() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test233", Value)
                End Set
            End Property

            Private _Test234 As String = String.Empty
            Public ReadOnly Property Test234() As String
                Get
                    Return _Test234
                End Get
            End Property
            Public WriteOnly Property SetTest234() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test234", Value)
                End Set
            End Property

            Private _Test235 As String = String.Empty
            Public ReadOnly Property Test235() As String
                Get
                    Return _Test235
                End Get
            End Property
            Public WriteOnly Property SetTest235() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test235", Value)
                End Set
            End Property

            Private _Test236 As String = String.Empty
            Public ReadOnly Property Test236() As String
                Get
                    Return _Test236
                End Get
            End Property
            Public WriteOnly Property SetTest236() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test236", Value)
                End Set
            End Property

            Private _Test237 As String = String.Empty
            Public ReadOnly Property Test237() As String
                Get
                    Return _Test237
                End Get
            End Property
            Public WriteOnly Property SetTest237() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test237", Value)
                End Set
            End Property


            Private _Test238 As String = String.Empty
            Public ReadOnly Property Test238() As String
                Get
                    Return _Test238
                End Get
            End Property
            Public WriteOnly Property SetTest238() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test238", Value)
                End Set
            End Property


            Private _Test239 As String = String.Empty
            Public ReadOnly Property Test239() As String
                Get
                    Return _Test239
                End Get
            End Property
            Public WriteOnly Property SetTest239() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test239", Value)
                End Set
            End Property


            Private _Test240 As String = String.Empty
            Public ReadOnly Property Test240() As String
                Get
                    Return _Test240
                End Get
            End Property
            Public WriteOnly Property SetTest240() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Test240", Value)
                End Set
            End Property



            Private _Test16 As DateTime = DateTime.MinValue
            Public ReadOnly Property Test16() As DateTime
                Get
                    Return _Test16
                End Get
            End Property
            Public WriteOnly Property SetTest16() As DateTime
                Set(ByVal Value As DateTime)
                    If IsDBNull(Value) Then
                        _Test16 = "1900-01-01"
                    Else
                        _Test16 = CDate(Value)
                    End If
                End Set
            End Property

            Private _Test17 As DateTime = DateTime.MinValue
            Public ReadOnly Property Test17() As DateTime
                Get
                    Return _Test17
                End Get
            End Property
            Public WriteOnly Property SetTest17() As DateTime
                Set(ByVal Value As DateTime)
                    If IsDBNull(Value) Then
                        _Test17 = "1900-01-01"
                    Else
                        _Test17 = CDate(Value)
                    End If
                End Set
            End Property

            Private _Test18 As DateTime = DateTime.MinValue
            Public ReadOnly Property Test18() As DateTime
                Get
                    Return _Test18
                End Get
            End Property
            Public WriteOnly Property SetTest18() As DateTime
                Set(ByVal Value As DateTime)
                    If IsDBNull(Value) Then
                        _Test18 = "1900-01-01"
                    Else
                        _Test18 = CDate(Value)
                    End If
                End Set
            End Property



            Private _TypeString As String = String.Empty
            Public ReadOnly Property TypeString() As String
                Get
                    Return _TypeString
                End Get
            End Property
            Public WriteOnly Property SetTypeString() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TypeString", Value)
                End Set
            End Property





#End Region

        End Class

    End Namespace

End Namespace

