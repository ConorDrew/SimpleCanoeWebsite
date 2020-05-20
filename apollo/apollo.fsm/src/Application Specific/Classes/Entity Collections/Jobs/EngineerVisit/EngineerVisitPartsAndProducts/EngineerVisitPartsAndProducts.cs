using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitsPartsAndProducts
    {
        public class EngineerVisitPartsAndProducts
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitPartsAndProducts()
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

            
            
            private int _PartOrProductID = 0;

            public int PartOrProductID
            {
                get
                {
                    return _PartOrProductID;
                }
            }

            public object SetPartOrProductID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartOrProductID", value);
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

            private int _Quantity = 0;

            public int Quantity
            {
                get
                {
                    return _Quantity;
                }
            }

            public object SetQuantity
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Quantity", value);
                }
            }

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

            private int _AllocatedID = 0;

            public int AllocatedID
            {
                get
                {
                    return _AllocatedID;
                }
            }

            public object SetAllocatedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AllocatedID", value);
                }
            }

            private int _LocationID = 0;

            public int LocationID
            {
                get
                {
                    return _LocationID;
                }
            }

            public object SetLocationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LocationID", value);
                }
            }

            private double _SpecialPrice = 0.0;

            public double SpecialPrice
            {
                get
                {
                    return _SpecialPrice;
                }
            }

            public object SetSpecialPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SpecialPrice", value);
                }
            }

            private string _SpecialPartNumber = "";

            public string SpecialPartNumber
            {
                get
                {
                    return _SpecialPartNumber;
                }
            }

            public object SetSpecialPartNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SpecialPartNumber", value);
                }
            }

            private string _SpecialDescription = "";

            public string SpecialDescription
            {
                get
                {
                    return _SpecialDescription;
                }
            }

            public object SetSpecialDescription
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SpecialDescription", value);
                }
            }



            
        }
    }
}