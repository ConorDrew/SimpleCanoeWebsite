Imports System.Data.SqlClient

Namespace Entity

    Namespace Notes

        Public Class Notes

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

#Region "Notes Properties"


            Private _NoteID As Integer = 0
            Public ReadOnly Property NoteID() As Integer
                Get
                    Return _NoteID
                End Get
            End Property
            Public WriteOnly Property SetNoteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NoteID", Value)
                End Set
            End Property


            Private _CategoryID As Integer = 0
            Public ReadOnly Property CategoryID() As Integer
                Get
                    Return _CategoryID
                End Get
            End Property
            Public WriteOnly Property SetCategoryID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CategoryID", Value)
                End Set
            End Property


            Private _NoteDate As DateTime = Nothing
            Public Property NoteDate() As DateTime
                Get
                    Return _NoteDate
                End Get
                Set(ByVal Value As DateTime)
                    _NoteDate = Value
                End Set
            End Property


            Private _Note As String = String.Empty
            Public ReadOnly Property Note() As String
                Get
                    Return _Note
                End Get
            End Property
            Public WriteOnly Property SetNote() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Note", Value)
                End Set
            End Property


            Private _DateCreated As DateTime = Nothing
            Public Property DateCreated() As DateTime
                Get
                    Return _DateCreated
                End Get
                Set(ByVal Value As DateTime)
                    _DateCreated = Value
                End Set
            End Property


            Private _UserIDBy As Integer = 0
            Public ReadOnly Property UserIDBy() As Integer
                Get
                    Return _UserIDBy
                End Get
            End Property
            Public WriteOnly Property SetUserIDBy() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_UserIDBy", Value)
                End Set
            End Property

            Private _contactID As Integer = 0
            Public ReadOnly Property ContactID() As Integer
                Get
                    Return _contactID
                End Get
            End Property
            Public WriteOnly Property SetContactID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_contactID", Value)
                End Set
            End Property

            Private _DateTimeOfReminder As DateTime = Nothing
            Public Property DateTimeOfReminder() As DateTime
                Get
                    Return _DateTimeOfReminder
                End Get
                Set(ByVal Value As DateTime)
                    _DateTimeOfReminder = Value
                End Set
            End Property

            Private _ReminderStatusID As Integer = CInt(Entity.Sys.Enums.NoteReminderStatus.Cancelled)
            Public ReadOnly Property ReminderStatusID() As Integer
                Get
                    Return _ReminderStatusID
                End Get
            End Property
            Public WriteOnly Property SetReminderStatusID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReminderStatusID", Value)
                End Set
            End Property


            Private _UserIDFor As Integer = 0
            Public ReadOnly Property UserIDFor() As Integer
                Get
                    Return _UserIDFor
                End Get
            End Property
            Public WriteOnly Property SetUserIDFor() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_UserIDFor", Value)
                End Set
            End Property
#End Region

        End Class

    End Namespace

End Namespace

