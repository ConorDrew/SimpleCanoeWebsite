Namespace Entity
    Namespace HeartBeats
        Public Class HeartBeat

            Private _dataTypeValidator As DataTypeValidator
            Public Sub New()
                _dataTypeValidator = New DataTypeValidator
            End Sub

            Private _LockedVisitID As Integer = 0
            Public ReadOnly Property LockedVisitID() As Integer
                Get
                    Return _LockedVisitID
                End Get
            End Property
            Public WriteOnly Property SetLockedVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LockedVisitID", Value)
                End Set
            End Property


            Private _LastHeartBeat As DateTime = Nothing
            Public Property LastHeartBeat() As DateTime
                Get
                    Return _LastHeartBeat
                End Get
                Set(ByVal Value As DateTime)
                    _LastHeartBeat = Value
                End Set
            End Property


            Private _LastCheck As DateTime = Nothing
            Public Property LastCheck() As DateTime
                Get
                    Return _LastCheck
                End Get
                Set(ByVal Value As DateTime)
                    _LastCheck = Value
                End Set
            End Property


        End Class
    End Namespace
End Namespace