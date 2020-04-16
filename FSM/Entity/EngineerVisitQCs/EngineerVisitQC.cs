// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitQCs.EngineerVisitQC
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitQCs
{
    public class EngineerVisitQC
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _EngineerVisitQCID;
        private int _EngineerVisitID;
        private int _FTFCode;
        private int _Recall;
        private int _EngineerID;
        private int _JobTypeIncorrect;
        private int _CustomerDetailsIncorrect;
        private int _SorIncorrect;
        private int _OrderNumberAttached;
        private int _PaymentMethodDetailed;
        private int _LabourTimeMissing;
        private int _LGSRMissing;
        private int _PartsConfirmation;
        private int _ApplianceRecorded;
        private int _JobUploadInTimeScale;
        private int _PaymentMethodSelectionIncorrect;
        private int _PaymentCollection;
        private int _EngineerPaymentReceived;
        private int _CustomerSigned;
        private string _PoorJobNotes;
        private bool _DocumentsRecieved;
        private DateTime _DateDocumentsRecieved;

        public EngineerVisitQC()
        {
            this._exists = false;
            this._deleted = false;
            this._EngineerVisitQCID = 0;
            this._EngineerVisitID = 0;
            this._FTFCode = 0;
            this._Recall = 0;
            this._EngineerID = 0;
            this._JobTypeIncorrect = 0;
            this._CustomerDetailsIncorrect = 0;
            this._SorIncorrect = 0;
            this._OrderNumberAttached = 0;
            this._PaymentMethodDetailed = 0;
            this._LabourTimeMissing = 0;
            this._LGSRMissing = 0;
            this._PartsConfirmation = 0;
            this._ApplianceRecorded = 0;
            this._JobUploadInTimeScale = 0;
            this._PaymentMethodSelectionIncorrect = 0;
            this._PaymentCollection = 0;
            this._EngineerPaymentReceived = 0;
            this._CustomerSigned = 0;
            this._PoorJobNotes = string.Empty;
            this._DocumentsRecieved = false;
            this._DateDocumentsRecieved = DateTime.MinValue;
            this._dataTypeValidator = new DataTypeValidator();
        }

        public bool IgnoreExceptionsOnSetMethods
        {
            get
            {
                return this._dataTypeValidator.IgnoreExceptionsOnSetMethods;
            }
            set
            {
                this._dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
            }
        }

        public Hashtable Errors
        {
            get
            {
                return this._dataTypeValidator.Errors;
            }
        }

        public DataTypeValidator DTValidator
        {
            get
            {
                return this._dataTypeValidator;
            }
        }

        public bool Exists
        {
            get
            {
                return this._exists;
            }
            set
            {
                this._exists = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return this._deleted;
            }
        }

        public bool SetDeleted
        {
            set
            {
                this._deleted = value;
            }
        }

        public int EngineerVisitQCID
        {
            get
            {
                return this._EngineerVisitQCID;
            }
        }

        public object SetEngineerVisitQCID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerVisitQCID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerVisitID
        {
            get
            {
                return this._EngineerVisitID;
            }
        }

        public object SetEngineerVisitID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerVisitID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int FTFCode
        {
            get
            {
                return this._FTFCode;
            }
        }

        public object SetFTFCode
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_FTFCode", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Recall
        {
            get
            {
                return this._Recall;
            }
        }

        public object SetRecall
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Recall", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerID
        {
            get
            {
                return this._EngineerID;
            }
        }

        public object SetEngineerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int JobTypeIncorrect
        {
            get
            {
                return this._JobTypeIncorrect;
            }
        }

        public object SetJobTypeIncorrect
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_JobTypeIncorrect", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int CustomerDetailsIncorrect
        {
            get
            {
                return this._CustomerDetailsIncorrect;
            }
        }

        public object SetCustomerDetailsIncorrect
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerDetailsIncorrect", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SorIncorrect
        {
            get
            {
                return this._SorIncorrect;
            }
        }

        public object SetSorIncorrect
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SorIncorrect", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int OrderNumberAttached
        {
            get
            {
                return this._OrderNumberAttached;
            }
        }

        public object SetOrderNumberAttached
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderNumberAttached", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PaymentMethodDetailed
        {
            get
            {
                return this._PaymentMethodDetailed;
            }
        }

        public object SetPaymentMethodDetailed
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PaymentMethodDetailed", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int LabourTimeMissing
        {
            get
            {
                return this._LabourTimeMissing;
            }
        }

        public object SetLabourTimeMissing
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LabourTimeMissing", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int LGSRMissing
        {
            get
            {
                return this._LGSRMissing;
            }
        }

        public object SetLGSRMissing
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LGSRMissing", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PartsConfirmation
        {
            get
            {
                return this._PartsConfirmation;
            }
        }

        public object SetPartsConfirmation
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartsConfirmation", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ApplianceRecorded
        {
            get
            {
                return this._ApplianceRecorded;
            }
        }

        public object SetApplianceRecorded
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ApplianceRecorded", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int JobUploadInTimeScale
        {
            get
            {
                return this._JobUploadInTimeScale;
            }
        }

        public object SetJobUploadInTimeScale
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_JobUploadInTimeScale", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PaymentMethodSelectionIncorrect
        {
            get
            {
                return this._PaymentMethodSelectionIncorrect;
            }
        }

        public object SetPaymentMethodSelectionIncorrect
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PaymentMethodSelectionIncorrect", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PaymentCollection
        {
            get
            {
                return this._PaymentCollection;
            }
        }

        public object SetPaymentCollection
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PaymentCollection", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerPaymentReceived
        {
            get
            {
                return this._EngineerPaymentReceived;
            }
        }

        public object SetEngineerPaymentReceived
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerPaymentReceived", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int CustomerSigned
        {
            get
            {
                return this._CustomerSigned;
            }
        }

        public object SetCustomerSigned
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerSigned", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string PoorJobNotes
        {
            get
            {
                return this._PoorJobNotes;
            }
        }

        public object SetPoorJobNotes
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PoorJobNotes", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool DocumentsRecieved
        {
            get
            {
                return this._DocumentsRecieved;
            }
        }

        public bool SetDocumentsRecieved
        {
            set
            {
                this._DocumentsRecieved = value;
            }
        }

        public DateTime DateDocumentsRecieved
        {
            get
            {
                return this._DateDocumentsRecieved;
            }
            set
            {
                this._DateDocumentsRecieved = value;
            }
        }
    }
}