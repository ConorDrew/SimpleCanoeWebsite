using System.Collections;
using System.Data;

namespace FSM.Entity
{
    namespace Products
    {
        public class Product
        {
            private DataTypeValidator _dataTypeValidator;

            public Product()
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

            private string _Number = string.Empty;

            public string Number
            {
                get
                {
                    return _Number;
                }
            }

            public object SetNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Number", value);
                }
            }

            private string _Reference = string.Empty;

            public string Reference
            {
                get
                {
                    return _Reference;
                }
            }

            public object SetReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Reference", value);
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

            private int _TypeID = 0;

            public int TypeID
            {
                get
                {
                    return _TypeID;
                }
            }

            public object SetTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TypeID", value);
                }
            }

            private int _MakeID = 0;

            public int MakeID
            {
                get
                {
                    return _MakeID;
                }
            }

            public object SetMakeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MakeID", value);
                }
            }

            private int _ModelID = 0;

            public int ModelID
            {
                get
                {
                    return _ModelID;
                }
            }

            public object SetModelID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ModelID", value);
                }
            }

            private double _sellPrice = 0;

            public double SellPrice
            {
                get
                {
                    return _sellPrice;
                }
            }

            public object SetSellPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_sellPrice", value);
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

            private int _MinimumQuantity = 0;

            public int MinimumQuantity
            {
                get
                {
                    return _MinimumQuantity;
                }
            }

            public object SetMinimumQuantity
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MinimumQuantity", value);
                }
            }

            private int _RecommendedQuantity = 0;

            public int RecommendedQuantity
            {
                get
                {
                    return _RecommendedQuantity;
                }
            }

            public object SetRecommendedQuantity
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RecommendedQuantity", value);
                }
            }

            private DataView _AssociatedPart = new DataView();

            public DataView AssociatedPart
            {
                get
                {
                    return _AssociatedPart;
                }

                set
                {
                    _AssociatedPart = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}