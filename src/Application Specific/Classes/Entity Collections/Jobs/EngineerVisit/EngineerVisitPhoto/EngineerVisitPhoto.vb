Imports System.Data.SqlClient

Namespace Entity

Namespace EngineerVisitPhotos

Public Class EngineerVisitPhoto

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

#Region "EngineerVisitPhoto Properties"

      
Private _EngineerVisitPhotoID As Integer = 0
Public Readonly Property EngineerVisitPhotoID() As Integer
	Get 
		Return _EngineerVisitPhotoID
	End Get	
End Property	
Public Writeonly Property SetEngineerVisitPhotoID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_EngineerVisitPhotoID", Value)
	End Set
End Property


Private _EngineerVisitID As Integer = 0
Public Readonly Property EngineerVisitID() As Integer
	Get 
		Return _EngineerVisitID
	End Get	
End Property	
Public Writeonly Property SetEngineerVisitID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_EngineerVisitID", Value)
	End Set
End Property

            Private _Photo As Byte() = Nothing
            Public ReadOnly Property Photo() As Byte()
                Get
                    Return _Photo
                End Get
            End Property
            Public WriteOnly Property SetPhoto() As Object
                Set(ByVal Value As Object)
                    _Photo = Value
                End Set
            End Property

            Private _Caption As String = String.Empty
            Public ReadOnly Property Caption() As String
                Get
                    Return _Caption
                End Get
            End Property
            Public WriteOnly Property SetCaption() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Caption", Value)
                End Set
            End Property



#End Region

End Class

End Namespace

End Namespace

