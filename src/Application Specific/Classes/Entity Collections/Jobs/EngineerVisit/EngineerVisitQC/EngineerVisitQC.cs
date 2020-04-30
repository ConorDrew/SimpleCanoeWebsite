using System;
using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitQCs
    {
        public class EngineerVisitQC
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitQC()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            
            

            private int _EngineerVisitQCID = 0;

            public int EngineerVisitQCID
            {
                get
                {
                    return _EngineerVisitQCID;
                }
            }

            public object SetEngineerVisitQCID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitQCID", value);
                }
            }

            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }
            }

            public object SetEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitID", value);
                }
            }

            private int _FTFCode = 0;

            public int FTFCode
            {
                get
                {
                    return _FTFCode;
                }
            }

            public object SetFTFCode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FTFCode", value);
                }
            }

            private int _Recall = 0;

            public int Recall
            {
                get
                {
                    return _Recall;
                }
            }

            public object SetRecall
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Recall", value);
                }
            }

            private int _EngineerID = 0;

            public int EngineerID
            {
                get
                {
                    return _EngineerID;
                }
            }

            public object SetEngineerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerID", value);
                }
            }

            private int _JobTypeIncorrect = 0;

            public int JobTypeIncorrect
            {
                get
                {
                    return _JobTypeIncorrect;
                }
            }

            public object SetJobTypeIncorrect
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobTypeIncorrect", value);
                }
            }

            private int _CustomerDetailsIncorrect = 0;

            public int CustomerDetailsIncorrect
            {
                get
                {
                    return _CustomerDetailsIncorrect;
                }
            }

            public object SetCustomerDetailsIncorrect
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerDetailsIncorrect", value);
                }
            }

            private int _SorIncorrect = 0;

            public int SorIncorrect
            {
                get
                {
                    return _SorIncorrect;
                }
            }

            public object SetSorIncorrect
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SorIncorrect", value);
                }
            }

            private int _OrderNumberAttached = 0;

            public int OrderNumberAttached
            {
                get
                {
                    return _OrderNumberAttached;
                }
            }

            public object SetOrderNumberAttached
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderNumberAttached", value);
                }
            }

            private int _PaymentMethodDetailed = 0;

            public int PaymentMethodDetailed
            {
                get
                {
                    return _PaymentMethodDetailed;
                }
            }

            public object SetPaymentMethodDetailed
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PaymentMethodDetailed", value);
                }
            }

            private int _LabourTimeMissing = 0;

            public int LabourTimeMissing
            {
                get
                {
                    return _LabourTimeMissing;
                }
            }

            public object SetLabourTimeMissing
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LabourTimeMissing", value);
                }
            }

            private int _LGSRMissing = 0;

            public int LGSRMissing
            {
                get
                {
                    return _LGSRMissing;
                }
            }

            public object SetLGSRMissing
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LGSRMissing", value);
                }
            }

            private int _PartsConfirmation = 0;

            public int PartsConfirmation
            {
                get
                {
                    return _PartsConfirmation;
                }
            }

            public object SetPartsConfirmation
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartsConfirmation", value);
                }
            }

            private int _ApplianceRecorded = 0;

            public int ApplianceRecorded
            {
                get
                {
                    return _ApplianceRecorded;
                }
            }

            public object SetApplianceRecorded
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ApplianceRecorded", value);
                }
            }

            private int _JobUploadInTimeScale = 0;

            public int JobUploadInTimeScale
            {
                get
                {
                    return _JobUploadInTimeScale;
                }
            }

            public object SetJobUploadInTimeScale
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobUploadInTimeScale", value);
                }
            }

            private int _PaymentMethodSelectionIncorrect = 0;

            public int PaymentMethodSelectionIncorrect
            {
                get
                {
                    return _PaymentMethodSelectionIncorrect;
                }
            }

            public object SetPaymentMethodSelectionIncorrect
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PaymentMethodSelectionIncorrect", value);
                }
            }

            private int _PaymentCollection = 0;

            public int PaymentCollection
            {
                get
                {
                    return _PaymentCollection;
                }
            }

            public object SetPaymentCollection
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PaymentCollection", value);
                }
            }

            private int _EngineerPaymentReceived = 0;

            public int EngineerPaymentReceived
            {
                get
                {
                    return _EngineerPaymentReceived;
                }
            }

            public object SetEngineerPaymentReceived
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerPaymentReceived", value);
                }
            }

            private int _CustomerSigned = 0;

            public int CustomerSigned
            {
                get
                {
                    return _CustomerSigned;
                }
            }

            public object SetCustomerSigned
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerSigned", value);
                }
            }

            private string _PoorJobNotes = string.Empty;

            public string PoorJobNotes
            {
                get
                {
                    return _PoorJobNotes;
                }
            }

            public object SetPoorJobNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PoorJobNotes", value);
                }
            }

            private bool _DocumentsRecieved = false;

            public bool DocumentsRecieved
            {
                get
                {
                    return _DocumentsRecieved;
                }
            }

            public bool SetDocumentsRecieved
            {
                set
                {
                    _DocumentsRecieved = value;
                }
            }

            private DateTime _DateDocumentsRecieved = default;

            public DateTime DateDocumentsRecieved
            {
                get
                {
                    return _DateDocumentsRecieved;
                }

                set
                {
                    _DateDocumentsRecieved = value;
                }
            }

            
        }
    }
}