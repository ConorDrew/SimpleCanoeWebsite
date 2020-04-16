// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisits.EngineerVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisitAdditionals;
using FSM.Entity.EngineerVisitNCCGSRs;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisits
{
    public class EngineerVisit
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _EngineerVisitID;
        private int _JobOfWorkID;
        private int _AppointmentID;
        private int _EngineerID;
        private DateTime _StartDateTime;
        private DateTime _EndDateTime;
        private int _StatusEnumID;
        private string _NotesToEngineer;
        private string _NotesFromEngineer;
        private int _OutcomeEnumID;
        private string _OutcomeDetails;
        private string _VisitOutcome;
        private string _CustomerName;
        private byte[] _CustomerSignature;
        private byte[] _EngineerSignature;
        private int _ManualEntryByUserID;
        private DateTime _ManualEntryOn;
        private DataView _PartsAndProductsUsed;
        private DataView _TimeSheets;
        private DataView _Photos;
        private bool _visitLocked;
        private DataView _PartsAndProductsAllocated;
        private int _GasInstallationTightnessTestID;
        private int _PaymentMethodID;
        private double _AmountCollected;
        private int _EmergencyControlAccessibleID;
        private int _BondingID;
        private int _PropertyRented;
        private int _SignatureSelectedID;
        private bool _PartsToFit;
        private bool _GasServiceCompleted;
        private bool _EmailReceipt;
        private bool _UseSORDescription;
        private DateTime _Downloading;
        private int _ExpectedEngineerID;
        private DateTime _DueDate;
        private DateTime _EstimatedDate;
        private string _AMPM;
        private int _VisitNumber;
        private EngineerVisitNCCGSR _EngineerVisitNCCGSR;
        private EngineerVisitAdditional _EngineerVisitSMOKE;
        private EngineerVisitAdditional _EngineerVisitCOMO;
        private EngineerVisitAdditional _EngineerVisitAdditionalWorksheets;
        private bool _Recharge;
        private bool _excludeFromTextMessage;
        private string _CostsTo;
        private int _RechargeTypeID;
        private int _NccRadID;
        private bool _Change;
        private int _MeterCappedID;
        private int _MeterLocationID;
        private string _ExpectedDepartment;
        private string _visitStatus;
        private int _FuelID;

        public EngineerVisit()
        {
            this._exists = false;
            this._deleted = false;
            this._EngineerVisitID = 0;
            this._JobOfWorkID = 0;
            this._AppointmentID = 0;
            this._EngineerID = 0;
            this._StartDateTime = DateTime.MinValue;
            this._EndDateTime = DateTime.MinValue;
            this._StatusEnumID = 0;
            this._NotesToEngineer = string.Empty;
            this._NotesFromEngineer = string.Empty;
            this._OutcomeEnumID = 0;
            this._OutcomeDetails = string.Empty;
            this._VisitOutcome = string.Empty;
            this._CustomerName = string.Empty;
            this._CustomerSignature = (byte[])null;
            this._EngineerSignature = (byte[])null;
            this._ManualEntryByUserID = 0;
            this._ManualEntryOn = DateTime.MinValue;
            this._PartsAndProductsUsed = new DataView();
            this._TimeSheets = new DataView();
            this._Photos = new DataView();
            this._visitLocked = false;
            this._PartsAndProductsAllocated = new DataView();
            this._PartsToFit = false;
            this._GasServiceCompleted = false;
            this._EmailReceipt = false;
            this._UseSORDescription = false;
            this._ExpectedEngineerID = 0;
            this._EstimatedDate = DateAndTime.Today;
            this._AMPM = string.Empty;
            this._VisitNumber = 0;
            this._EngineerVisitNCCGSR = (EngineerVisitNCCGSR)null;
            this._EngineerVisitSMOKE = (EngineerVisitAdditional)null;
            this._EngineerVisitCOMO = (EngineerVisitAdditional)null;
            this._EngineerVisitAdditionalWorksheets = (EngineerVisitAdditional)null;
            this._Recharge = false;
            this._excludeFromTextMessage = false;
            this._CostsTo = string.Empty;
            this._Change = false;
            this._ExpectedDepartment = string.Empty;
            this._visitStatus = string.Empty;
            this._FuelID = 0;
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

        public int JobOfWorkID
        {
            get
            {
                return this._JobOfWorkID;
            }
        }

        public object SetJobOfWorkID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_JobOfWorkID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int AppointmentID
        {
            get
            {
                return this._AppointmentID;
            }
        }

        public object SetAppointmentID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AppointmentID", RuntimeHelpers.GetObjectValue(value));
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

        public DateTime StartDateTime
        {
            get
            {
                return this._StartDateTime;
            }
            set
            {
                this._StartDateTime = value;
            }
        }

        public DateTime EndDateTime
        {
            get
            {
                return this._EndDateTime;
            }
            set
            {
                this._EndDateTime = value;
            }
        }

        public int StatusEnumID
        {
            get
            {
                return this._StatusEnumID;
            }
        }

        public object SetStatusEnumID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_StatusEnumID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string NotesToEngineer
        {
            get
            {
                return this._NotesToEngineer;
            }
        }

        public object SetNotesToEngineer
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_NotesToEngineer", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string NotesFromEngineer
        {
            get
            {
                return this._NotesFromEngineer;
            }
        }

        public object SetNotesFromEngineer
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_NotesFromEngineer", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int OutcomeEnumID
        {
            get
            {
                return this._OutcomeEnumID;
            }
        }

        public object SetOutcomeEnumID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OutcomeEnumID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string OutcomeDetails
        {
            get
            {
                return this._OutcomeDetails;
            }
        }

        public object SetOutcomeDetails
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OutcomeDetails", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string VisitOutcome
        {
            get
            {
                return this._VisitOutcome;
            }
        }

        public object SetVisitOutcome
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VisitOutcome", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string CustomerName
        {
            get
            {
                return this._CustomerName;
            }
        }

        public object SetCustomerName
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerName", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public byte[] CustomerSignature
        {
            get
            {
                return this._CustomerSignature;
            }
            set
            {
                this._CustomerSignature = value;
            }
        }

        public byte[] EngineerSignature
        {
            get
            {
                return this._EngineerSignature;
            }
            set
            {
                this._EngineerSignature = value;
            }
        }

        public int ManualEntryByUserID
        {
            get
            {
                return this._ManualEntryByUserID;
            }
        }

        public object SetManualEntryByUserID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ManualEntryByUserID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime ManualEntryOn
        {
            get
            {
                return this._ManualEntryOn;
            }
            set
            {
                this._ManualEntryOn = value;
            }
        }

        public DataView PartsAndProductsUsed
        {
            get
            {
                return this._PartsAndProductsUsed;
            }
            set
            {
                this._PartsAndProductsUsed = value;
            }
        }

        public DataView TimeSheets
        {
            get
            {
                return this._TimeSheets;
            }
            set
            {
                this._TimeSheets = value;
            }
        }

        public DataView Photos
        {
            get
            {
                return this._Photos;
            }
            set
            {
                this._Photos = value;
            }
        }

        public bool VisitLocked
        {
            get
            {
                return this._visitLocked;
            }
        }

        public bool SetVisitLocked
        {
            set
            {
                this._visitLocked = value;
            }
        }

        public DataView PartsAndProductsAllocated
        {
            get
            {
                return this._PartsAndProductsAllocated;
            }
            set
            {
                this._PartsAndProductsAllocated = value;
            }
        }

        public int GasInstallationTightnessTestID
        {
            get
            {
                return this._GasInstallationTightnessTestID;
            }
        }

        public object SetGasInstallationTightnessTestID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_GasInstallationTightnessTestID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PaymentMethodID
        {
            get
            {
                return this._PaymentMethodID;
            }
        }

        public object SetPaymentMethodID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PaymentMethodID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double AmountCollected
        {
            get
            {
                return this._AmountCollected;
            }
        }

        public object SetAmountCollected
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AmountCollected", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EmergencyControlAccessibleID
        {
            get
            {
                return this._EmergencyControlAccessibleID;
            }
        }

        public object SetEmergencyControlAccessibleID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EmergencyControlAccessibleID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int BondingID
        {
            get
            {
                return this._BondingID;
            }
        }

        public object SetBondingID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_BondingID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PropertyRented
        {
            get
            {
                return this._PropertyRented;
            }
        }

        public object SetPropertyRented
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PropertyRented", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SignatureSelectedID
        {
            get
            {
                return this._SignatureSelectedID;
            }
        }

        public object SetSignatureSelectedID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SignatureSelectedID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool PartsToFit
        {
            get
            {
                return this._PartsToFit;
            }
        }

        public object SetPartsToFit
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartsToFit", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool GasServiceCompleted
        {
            get
            {
                return this._GasServiceCompleted;
            }
        }

        public object SetGasServiceCompleted
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_GasServiceCompleted", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool EmailReceipt
        {
            get
            {
                return this._EmailReceipt;
            }
        }

        public object SetEmailReceipt
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EmailReceipt", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool UseSORDescription
        {
            get
            {
                return this._UseSORDescription;
            }
        }

        public object SetUseSORDescription
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_UseSORDescription", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime Downloading
        {
            get
            {
                return this._Downloading;
            }
            set
            {
                this._Downloading = value;
            }
        }

        public int ExpectedEngineerID
        {
            get
            {
                return this._ExpectedEngineerID;
            }
        }

        public object SetExpectedEngineerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ExpectedEngineerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime DueDate
        {
            get
            {
                return this._DueDate;
            }
            set
            {
                this._DueDate = value;
            }
        }

        public DateTime EstimatedDate
        {
            get
            {
                return this._EstimatedDate;
            }
            set
            {
                this._EstimatedDate = value;
            }
        }

        public string AMPM
        {
            get
            {
                return this._AMPM;
            }
        }

        public object SetAMPM
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AMPM", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VisitNumber
        {
            get
            {
                return this._VisitNumber;
            }
        }

        public object SetVisitNumber
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VisitNumber", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public EngineerVisitNCCGSR EngineerVisitNCCGSR
        {
            get
            {
                return this._EngineerVisitNCCGSR;
            }
            set
            {
                this._EngineerVisitNCCGSR = value;
            }
        }

        public EngineerVisitAdditional EngineerVisitSMOKE
        {
            get
            {
                return this._EngineerVisitSMOKE;
            }
            set
            {
                this._EngineerVisitSMOKE = value;
            }
        }

        public EngineerVisitAdditional EngineerVisitCOMO
        {
            get
            {
                return this._EngineerVisitCOMO;
            }
            set
            {
                this._EngineerVisitCOMO = value;
            }
        }

        public EngineerVisitAdditional EngineerVisitAdditionalWorksheets
        {
            get
            {
                return this._EngineerVisitAdditionalWorksheets;
            }
            set
            {
                this._EngineerVisitAdditionalWorksheets = value;
            }
        }

        public bool Recharge
        {
            get
            {
                return this._Recharge;
            }
        }

        public object SetRecharge
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Recharge", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool ExcludeFromTextMessage
        {
            get
            {
                return this._excludeFromTextMessage;
            }
        }

        public object SetExcludeFromTextMessage
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_excludeFromTextMessage", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string CostsTo
        {
            get
            {
                return this._CostsTo;
            }
        }

        public object SetCostsTo
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CostsTo", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int RechargeTypeID
        {
            get
            {
                return this._RechargeTypeID;
            }
        }

        public object setRechargeTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_RechargeTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int NccRadID
        {
            get
            {
                return this._NccRadID;
            }
        }

        public object setNccRadID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_NccRadID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool Change
        {
            get
            {
                return this._Change;
            }
        }

        public object setChange
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Change", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int MeterCappedID
        {
            get
            {
                return this._MeterCappedID;
            }
        }

        public object SetMeterCappedID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MeterCappedID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int MeterLocationID
        {
            get
            {
                return this._MeterLocationID;
            }
        }

        public object SetMeterLocationID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MeterLocationID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string ExpectedDepartment
        {
            get
            {
                return this._ExpectedDepartment;
            }
        }

        public object SetExpectedDepartment
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ExpectedDepartment", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string VisitStatus
        {
            get
            {
                return this._visitStatus;
            }
        }

        public object SetVisitStatus
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_visitStatus", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int FuelID
        {
            get
            {
                return this._FuelID;
            }
        }

        public object SetFuelID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_FuelID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}