Imports System.Data.SqlClient

Namespace Entity

    Namespace Documentss

        Public Class Documents

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

#Region "Documents Properties"

            Private _DocumentID As Integer = 0
            Public ReadOnly Property DocumentID() As Integer
                Get
                    Return _DocumentID
                End Get
            End Property
            Public WriteOnly Property SetDocumentID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DocumentID", Value)
                End Set
            End Property

            Private _TableEnumID As Integer = 0
            Public ReadOnly Property TableEnumID() As Integer
                Get
                    Return _TableEnumID
                End Get
            End Property
            Public WriteOnly Property SetTableEnumID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TableEnumID", Value)
                End Set
            End Property

            Private _RecordID As Integer = 0
            Public ReadOnly Property RecordID() As Integer
                Get
                    Return _RecordID
                End Get
            End Property
            Public WriteOnly Property SetRecordID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RecordID", Value)
                End Set
            End Property

            Private _DocumentTypeID As Integer = 0
            Public ReadOnly Property DocumentTypeID() As Integer
                Get
                    Return _DocumentTypeID
                End Get
            End Property
            Public WriteOnly Property SetDocumentTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DocumentTypeID", Value)
                End Set
            End Property

            Private _Name As String = String.Empty
            Public ReadOnly Property Name() As String
                Get
                    Return _Name
                End Get
            End Property
            Public WriteOnly Property SetName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Name", Value)
                End Set
            End Property

            Private _Notes As String = String.Empty
            Public ReadOnly Property Notes() As String
                Get
                    Return _Notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Notes", Value)
                End Set
            End Property

            Private _Location As String = String.Empty
            Public ReadOnly Property Location() As String
                Get
                    Return _Location
                End Get
            End Property
            Public WriteOnly Property SetLocation() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Location", Value)
                End Set
            End Property

            Private _AddedOn As DateTime = Nothing
            Public Property AddedOn() As DateTime
                Get
                    Return _AddedOn
                End Get
                Set(ByVal Value As DateTime)
                    _AddedOn = Value
                End Set
            End Property

            Private _AddedByUserID As Integer = 0
            Public ReadOnly Property AddedByUserID() As Integer
                Get
                    Return _AddedByUserID
                End Get
            End Property
            Public WriteOnly Property SetAddedByUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AddedByUserID", Value)
                End Set
            End Property

            Private _LastUpdatedOn As DateTime = Nothing
            Public Property LastUpdatedOn() As DateTime
                Get
                    Return _LastUpdatedOn
                End Get
                Set(ByVal Value As DateTime)
                    _LastUpdatedOn = Value
                End Set
            End Property

            Private _LastUpdatedByUserID As Integer = 0
            Public ReadOnly Property LastUpdatedByUserID() As Integer
                Get
                    Return _LastUpdatedByUserID
                End Get
            End Property
            Public WriteOnly Property SetLastUpdatedByUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LastUpdatedByUserID", Value)
                End Set
            End Property

#End Region

#Region "Additional Properties"

            Private _Type As String = String.Empty
            Public Property Type() As String
                Get
                    Return _Type
                End Get
                Set(ByVal Value As String)
                    _Type = Value
                End Set
            End Property

            Private _AddedByUserName As String = String.Empty
            Public Property AddedByUserName() As String
                Get
                    Return _AddedByUserName
                End Get
                Set(ByVal Value As String)
                    _AddedByUserName = Value
                End Set
            End Property

            Private _LastUpdatedByUserName As String = String.Empty
            Public Property LastUpdatedByUserName() As String
                Get
                    Return _LastUpdatedByUserName
                End Get
                Set(ByVal Value As String)
                    _LastUpdatedByUserName = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

