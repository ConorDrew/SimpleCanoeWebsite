// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Engineers.Equipment
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Engineers
{
    public class Equipment
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _EquipmentID;
        private string _Name;
        private int _EquipmentTypeID;
        private string _SerialNumber;
        private string _CertificateNumber;
        private int _StatusID;
        private DateTime _CalibrationDate;
        private double _CalibrationMonths;
        private DateTime _WarrantyEndDate;
        private int _EngineerID;
        private string _Notes;
        private string _AssetNo;
        private DateTime _StatusChangeDate;

        public Equipment()
        {
            this._exists = false;
            this._deleted = false;
            this._EquipmentID = 0;
            this._Name = string.Empty;
            this._EquipmentTypeID = 0;
            this._SerialNumber = "";
            this._CertificateNumber = "";
            this._StatusID = 0;
            this._CalibrationDate = DateTime.MinValue;
            this._CalibrationMonths = 0.0;
            this._WarrantyEndDate = DateTime.MinValue;
            this._EngineerID = 0;
            this._Notes = "";
            this._AssetNo = "";
            this._StatusChangeDate = DateTime.MinValue;
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

        public int EquipmentID
        {
            get
            {
                return this._EquipmentID;
            }
        }

        public object SetEquipmentID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EquipmentID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public object SetName
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Name", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EquipmentTypeID
        {
            get
            {
                return this._EquipmentTypeID;
            }
        }

        public object SetEquipmentTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EquipmentTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string SerialNumber
        {
            get
            {
                return this._SerialNumber;
            }
        }

        public object SetSerialNumber
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SerialNumber", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string CertificateNumber
        {
            get
            {
                return this._CertificateNumber;
            }
        }

        public object SetCertificateNumber
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CertificateNumber", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int StatusID
        {
            get
            {
                return this._StatusID;
            }
        }

        public object SetStatusID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_StatusID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime CalibrationDate
        {
            get
            {
                return this._CalibrationDate;
            }
            set
            {
                this._CalibrationDate = value;
            }
        }

        public double CalibrationMonths
        {
            get
            {
                return this._CalibrationMonths;
            }
        }

        public object SetCalibrationMonths
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CalibrationMonths", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime WarrantyEndDate
        {
            get
            {
                return this._WarrantyEndDate;
            }
            set
            {
                this._WarrantyEndDate = value;
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

        public string Notes
        {
            get
            {
                return this._Notes;
            }
        }

        public object SetNotes
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Notes", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string AssetNo
        {
            get
            {
                return this._AssetNo;
            }
        }

        public object SetAssetNo
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AssetNo", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime StatusChangeDate
        {
            get
            {
                return this._StatusChangeDate;
            }
            set
            {
                this._StatusChangeDate = value;
            }
        }
    }
}