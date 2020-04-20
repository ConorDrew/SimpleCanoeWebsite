Imports System.Data.SqlClient

Namespace Entity

    Namespace CheckLists

        Public Class CheckList

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

#Region "CheckList Properties"


            Private _CheckListID As Integer = 0
            Public ReadOnly Property CheckListID() As Integer
                Get
                    Return _CheckListID
                End Get
            End Property
            Public WriteOnly Property SetCheckListID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CheckListID", Value)
                End Set
            End Property


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


            Private _SectionID As Integer = 0
            Public ReadOnly Property SectionID() As Integer
                Get
                    Return _SectionID
                End Get
            End Property
            Public WriteOnly Property SetSectionID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SectionID", Value)
                End Set
            End Property


            Private _AddedOn As DateTime = DateTime.MinValue
            Public Property AddedOn() As DateTime
                Get
                    Return _AddedOn
                End Get
                Set(ByVal Value As DateTime)
                    _AddedOn = Value
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

