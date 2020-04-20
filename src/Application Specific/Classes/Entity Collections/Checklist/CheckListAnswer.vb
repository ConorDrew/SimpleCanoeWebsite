Imports System.Data.SqlClient

Namespace Entity

    Namespace CheckLists

        Public Class CheckListAnswer

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

#End Region

#Region "CheckListAnswer Properties"

            Private _ChecklistAnswerID As Integer = 0
            Public ReadOnly Property ChecklistAnswerID() As Integer
                Get
                    Return _ChecklistAnswerID
                End Get
            End Property
            Public WriteOnly Property SetChecklistAnswerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ChecklistAnswerID", Value)
                End Set
            End Property

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

            Private _EnumTableID As Integer = 0
            Public ReadOnly Property EnumTableID() As Integer
                Get
                    Return _EnumTableID
                End Get
            End Property
            Public WriteOnly Property SetEnumTableID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EnumTableID", Value)
                End Set
            End Property

            Private _QuestionID As Integer = 0
            Public ReadOnly Property QuestionID() As Integer
                Get
                    Return _QuestionID
                End Get
            End Property
            Public WriteOnly Property SetQuestionID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuestionID", Value)
                End Set
            End Property

            Private _ResultID As Integer = 0
            Public ReadOnly Property ResultID() As Integer
                Get
                    Return _ResultID
                End Get
            End Property
            Public WriteOnly Property SetResultID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ResultID", Value)
                End Set
            End Property

            Private _Comments As String = String.Empty
            Public ReadOnly Property Comments() As String
                Get
                    Return _Comments
                End Get
            End Property
            Public WriteOnly Property SetComments() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Comments", Value)
                End Set
            End Property







#End Region

        End Class

    End Namespace

End Namespace

