Imports System.Data.SqlClient

Namespace Entity


    Namespace JobInstalls

        Public Class JobInstall

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


            Private _siexists As Boolean = False
            Public Property SIExists() As Boolean
                Get
                    Return _siexists
                End Get
                Set(ByVal Value As Boolean)
                    _siexists = Value
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

#Region "JobInstall Properties"


            Private _JobInstallID As Integer = 0
            Public ReadOnly Property JobInstallID() As Integer
                Get
                    Return _JobInstallID
                End Get
            End Property
            Public WriteOnly Property SetJobInstallID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobInstallID", Value)
                End Set
            End Property


            Private _JobID As Integer = 0
            Public ReadOnly Property JobID() As Integer
                Get
                    Return _JobID
                End Get
            End Property
            Public WriteOnly Property SetJobID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobID", Value)
                End Set
            End Property


            Private _Surveyed As Integer = 0
            Public ReadOnly Property Surveyed() As Integer
                Get
                    Return _Surveyed
                End Get
            End Property
            Public WriteOnly Property SetSurveyed() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Surveyed", Value)
                End Set
            End Property


            Private _Deposit As Double = 0
            Public ReadOnly Property Deposit() As Double
                Get
                    Return _Deposit
                End Get
            End Property
            Public WriteOnly Property SetDeposit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Deposit", Value)
                End Set
            End Property


            Private _POStatus As Integer = 0
            Public ReadOnly Property POStatus() As Integer
                Get
                    Return _POStatus
                End Get
            End Property
            Public WriteOnly Property SetPOStatus() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_POStatus", Value)
                End Set
            End Property


            Private _EngCalledSuper As Integer = 0
            Public ReadOnly Property EngCalledSuper() As Integer
                Get
                    Return _EngCalledSuper
                End Get
            End Property
            Public WriteOnly Property SetEngCalledSuper() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngCalledSuper", Value)
                End Set
            End Property

            Private _ExtraLabour As Integer = 0
            Public ReadOnly Property ExtraLabour() As Integer
                Get
                    Return _ExtraLabour
                End Get
            End Property
            Public WriteOnly Property SetExtraLabour() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ExtraLabour", Value)
                End Set
            End Property


            Private _FurtherWorks As Integer = 0
            Public ReadOnly Property FurtherWorks() As Integer
                Get
                    Return _FurtherWorks
                End Get
            End Property
            Public WriteOnly Property SetFurtherWorks() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FurtherWorks", Value)
                End Set
            End Property


            Private _PaymentTaken As Double = 0
            Public ReadOnly Property PaymentTaken() As Double
                Get
                    Return _PaymentTaken
                End Get
            End Property
            Public WriteOnly Property SetPaymentTaken() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PaymentTaken", Value)
                End Set
            End Property


            Private _QC As Integer = 0
            Public ReadOnly Property QC() As Integer
                Get
                    Return _QC
                End Get
            End Property
            Public WriteOnly Property SetQC() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QC", Value)
                End Set
            End Property

            Private _PaperWork As Integer = 0
            Public ReadOnly Property PaperWork() As Integer
                Get
                    Return _PaperWork
                End Get
            End Property
            Public WriteOnly Property SetPaperWork() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PaperWork", Value)
                End Set
            End Property

            Private _EstPartCost As Double = 0.0
            Public ReadOnly Property EstPartCost() As Double
                Get
                    Return _EstPartCost
                End Get
            End Property
            Public WriteOnly Property SetEstPartCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EstPartCost", Value)
                End Set
            End Property

            Private _actPartCost As Double = 0
            Public ReadOnly Property actPartCost() As Double
                Get
                    Return _actPartCost
                End Get
            End Property
            Public WriteOnly Property SetactPartCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_actPartCost", Value)
                End Set
            End Property

            Private _EstLabourCost As Double = 0
            Public ReadOnly Property EstLabourCost() As Double
                Get
                    Return _EstLabourCost
                End Get
            End Property
            Public WriteOnly Property SetEstLabourCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EstLabourCost", Value)
                End Set
            End Property

            Private _actLabourCost As Double = 0
            Public ReadOnly Property actLabourCost() As Double
                Get
                    Return _actLabourCost
                End Get
            End Property
            Public WriteOnly Property SetactLabourCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_actLabourCost", Value)
                End Set
            End Property

            Private _EstElecCost As Double = 0
            Public ReadOnly Property EstElecCost() As Double
                Get
                    Return _EstElecCost
                End Get
            End Property
            Public WriteOnly Property SetEstElecCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EstElecCost", Value)
                End Set
            End Property

            Private _actElecCost As Double = 0
            Public ReadOnly Property actElecCost() As Double
                Get
                    Return _actElecCost
                End Get
            End Property
            Public WriteOnly Property SetactElecCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_actElecCost", Value)
                End Set
            End Property

            Private _EstTotalCost As Double = 0
            Public ReadOnly Property EstTotalCost() As Double
                Get
                    Return _EstTotalCost
                End Get
            End Property
            Public WriteOnly Property SetEstTotalCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EstTotalCost", Value)
                End Set
            End Property

            Private _actTotalCost As Double = 0
            Public ReadOnly Property actTotalCost() As Double
                Get
                    Return _actTotalCost
                End Get
            End Property
            Public WriteOnly Property SetactTotalCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_actTotalCost", Value)
                End Set
            End Property

            Private _EstProfitMoney As Double = 0
            Public ReadOnly Property EstProfitMoney() As Double
                Get
                    Return _EstProfitMoney
                End Get
            End Property
            Public WriteOnly Property SetEstProfitMoney() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EstProfitMoney", Value)
                End Set
            End Property

            Private _ActProfitMoney As Double = 0
            Public ReadOnly Property ActProfitMoney() As Double
                Get
                    Return _ActProfitMoney
                End Get
            End Property
            Public WriteOnly Property SetActProfitMoney() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ActProfitMoney", Value)
                End Set
            End Property

            Private _EstProfitPerc As Double = 0
            Public ReadOnly Property EstProfitPerc() As Double
                Get
                    Return _EstProfitPerc
                End Get
            End Property
            Public WriteOnly Property SetEstProfitPerc() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EstProfitPerc", Value)
                End Set
            End Property

            Private _ActProfitPerc As Double = 0
            Public ReadOnly Property ActProfitPerc() As Double
                Get
                    Return _ActProfitPerc
                End Get
            End Property
            Public WriteOnly Property SetActProfitPerc() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ActProfitPerc", Value)
                End Set
            End Property

            Private _QuotedAmount As Double = 0
            Public ReadOnly Property QuotedAmount() As Double
                Get
                    Return _QuotedAmount
                End Get
            End Property
            Public WriteOnly Property SetQuotedAmount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuotedAmount", Value)
                End Set
            End Property


            Private _SupplierInvoice As Double = 0
            Public ReadOnly Property SupplierInvoice() As Double
                Get
                    Return _SupplierInvoice
                End Get
            End Property
            Public WriteOnly Property SetSupplierInvoice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SupplierInvoice", Value)
                End Set
            End Property

            Private _SubConPO As Double = 0
            Public ReadOnly Property SubConPO() As Double
                Get
                    Return _SubConPO
                End Get
            End Property
            Public WriteOnly Property SetSubConPO() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SubConPO", Value)
                End Set
            End Property


            Private _SubConEst As Double = 0
            Public ReadOnly Property SubConEst() As Double
                Get
                    Return _SubConEst
                End Get
            End Property
            Public WriteOnly Property SetSubConEst() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SubConEst", Value)
                End Set
            End Property


            Private _SubConSI As Double = 0
            Public ReadOnly Property SubConSI() As Double
                Get
                    Return _SubConSI
                End Get
            End Property
            Public WriteOnly Property SetSubConSI() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SubConSI", Value)
                End Set
            End Property

            Private _Manual As Double = 0
            Public ReadOnly Property Manual() As Double
                Get
                    Return _Manual
                End Get
            End Property
            Public WriteOnly Property SetManual() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Manual", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

