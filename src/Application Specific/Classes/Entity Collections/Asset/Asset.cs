using System;
using System.Collections;

namespace FSM.Entity
{
    namespace Assets
    {
        public class Asset
        {
            private DataTypeValidator _dataTypeValidator;

            public Asset()
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

            private int _AssetID = 0;

            public int AssetID
            {
                get
                {
                    return _AssetID;
                }
            }

            public object SetAssetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AssetID", value);
                }
            }

            private int _PropertyID = 0;

            public int PropertyID
            {
                get
                {
                    return _PropertyID;
                }
            }

            public object SetPropertyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PropertyID", value);
                }
            }

            private int _ProductID = 0;

            public int ProductID
            {
                get
                {
                    return _ProductID;
                }
            }

            public object SetProductID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ProductID", value);
                }
            }

            private string _SerialNum = string.Empty;

            public string SerialNum
            {
                get
                {
                    return _SerialNum;
                }
            }

            public object SetSerialNum
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SerialNum", value);
                }
            }

            private DateTime _DateFitted = default;

            public DateTime DateFitted
            {
                get
                {
                    return _DateFitted;
                }

                set
                {
                    _DateFitted = value;
                }
            }

            private string _Location = string.Empty;

            public string Location
            {
                get
                {
                    return _Location;
                }
            }

            public object SetLocation
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Location", value);
                }
            }

            private DateTime _CertificateLastIssued = default;

            public DateTime CertificateLastIssued
            {
                get
                {
                    return _CertificateLastIssued;
                }

                set
                {
                    _CertificateLastIssued = value;
                }
            }

            private DateTime _LastServicedDate = default;

            public DateTime LastServicedDate
            {
                get
                {
                    return _LastServicedDate;
                }

                set
                {
                    _LastServicedDate = value;
                }
            }

            private string _BoughtFrom = string.Empty;

            public string BoughtFrom
            {
                get
                {
                    return _BoughtFrom;
                }
            }

            public object SetBoughtFrom
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BoughtFrom", value);
                }
            }

            private string _SuppliedBy = string.Empty;

            public string SuppliedBy
            {
                get
                {
                    return _SuppliedBy;
                }
            }

            public object SetSuppliedBy
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SuppliedBy", value);
                }
            }

            private string _Notes = string.Empty;

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

            private string _GCNumber = string.Empty;

            public string GCNumber
            {
                get
                {
                    return _GCNumber;
                }
            }

            public object SetGCNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_GCNumber", value);
                }
            }

            private string _YearOfManufacture = string.Empty;

            public string YearOfManufacture
            {
                get
                {
                    return _YearOfManufacture;
                }
            }

            public object SetYearOfManufacture
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_YearOfManufacture", value);
                }
            }

            private double _ApproximateValue = 0;

            public double ApproximateValue
            {
                get
                {
                    return _ApproximateValue;
                }
            }

            public object SetApproximateValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ApproximateValue", value);
                }
            }

            private DateTime _WarrantyStartDate = default;

            public DateTime WarrantyStartDate
            {
                get
                {
                    return _WarrantyStartDate;
                }

                set
                {
                    _WarrantyStartDate = value;
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

            private int _GasTypeID = 0;

            public int GasTypeID
            {
                get
                {
                    return _GasTypeID;
                }
            }

            public object SetGasTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_GasTypeID", value);
                }
            }

            private int _FlueTypeID = 0;

            public int FlueTypeID
            {
                get
                {
                    return _FlueTypeID;
                }
            }

            public object SetFlueTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FlueTypeID", value);
                }
            }

            private bool _Active = false;

            public bool Active
            {
                get
                {
                    return _Active;
                }
            }

            public object SetActive
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Active", value);
                }
            }

            private bool _TenantsAppliance = false;

            public bool TenantsAppliance
            {
                get
                {
                    return _TenantsAppliance;
                }
            }

            public object SetTenantsAppliance
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TenantsAppliance", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}