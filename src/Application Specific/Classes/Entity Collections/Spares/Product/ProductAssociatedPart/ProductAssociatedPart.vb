Imports System.Data.SqlClient

Namespace Entity

    Namespace ProductAssociatedParts

        Public Class ProductAssociatedPart

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

#Region "ProductAssociatedPart Properties"


            Private _ProductAssociatedPartID As Integer = 0
            Public ReadOnly Property ProductAssociatedPartID() As Integer
                Get
                    Return _ProductAssociatedPartID
                End Get
            End Property
            Public WriteOnly Property SetProductAssociatedPartID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ProductAssociatedPartID", Value)
                End Set
            End Property


            Private _ProductID As Integer = 0
            Public ReadOnly Property ProductID() As Integer
                Get
                    Return _ProductID
                End Get
            End Property
            Public WriteOnly Property SetProductID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ProductID", Value)
                End Set
            End Property


            Private _PartID As Integer = 0
            Public ReadOnly Property PartID() As Integer
                Get
                    Return _PartID
                End Get
            End Property
            Public WriteOnly Property SetPartID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartID", Value)
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

