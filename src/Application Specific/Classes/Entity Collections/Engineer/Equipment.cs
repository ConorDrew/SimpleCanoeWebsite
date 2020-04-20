using System;
using System.Collections;

namespace FSM.Entity
{
    namespace Engineers
    {
        public class Equipment
        {
            private DataTypeValidator _dataTypeValidator;

            public Equipment()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            private int _EquipmentID = 0;

            public int EquipmentID
            {
                get
                {
                    return _EquipmentID;
                }
            }

            public object SetEquipmentID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EquipmentID", value);
                }
            }

            private string _Name = string.Empty;

            public string Name
            {
                get
                {
                    return _Name;
                }
            }

            public object SetName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Name", value);
                }
            }

            private int _EquipmentTypeID = 0;

            public int EquipmentTypeID
            {
                get
                {
                    return _EquipmentTypeID;
                }
            }

            public object SetEquipmentTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EquipmentTypeID", value);
                }
            }

            private string _SerialNumber = "";

            public string SerialNumber
            {
                get
                {
                    return _SerialNumber;
                }
            }

            public object SetSerialNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SerialNumber", value);
                }
            }

            private string _CertificateNumber = "";

            public string CertificateNumber
            {
                get
                {
                    return _CertificateNumber;
                }
            }

            public object SetCertificateNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CertificateNumber", value);
                }
            }

            private int _StatusID = 0;

            public int StatusID
            {
                get
                {
                    return _StatusID;
                }
            }

            public object SetStatusID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_StatusID", value);
                }
            }

            private DateTime _CalibrationDate = default;

            public DateTime CalibrationDate
            {
                get
                {
                    return _CalibrationDate;
                }

                set
                {
                    _CalibrationDate = value;
                }
            }

            private double _CalibrationMonths = 0;

            public double CalibrationMonths
            {
                get
                {
                    return _CalibrationMonths;
                }
            }

            public object SetCalibrationMonths
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CalibrationMonths", value);
                }
            }

            private DateTime _WarrantyEndDate = default;

            public DateTime WarrantyEndDate
            {
                get
                {
                    return _WarrantyEndDate;
                }

                set
                {
                    _WarrantyEndDate = value;
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

            private string _Notes = "";

            public string Notes
            {
                get
                {
                    return _Notes;
                }
            }

            public object SetNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Notes", value);
                }
            }

            private string _AssetNo = "";

            public string AssetNo
            {
                get
                {
                    return _AssetNo;
                }
            }

            public object SetAssetNo
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AssetNo", value);
                }
            }

            private DateTime _StatusChangeDate = default;

            public DateTime StatusChangeDate
            {
                get
                {
                    return _StatusChangeDate;
                }

                set
                {
                    _StatusChangeDate = value;
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}