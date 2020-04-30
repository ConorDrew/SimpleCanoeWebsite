using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace PartsToBeCrediteds
    {
        public class PartsToBeCredited
        {
            private DataTypeValidator _dataTypeValidator;

            public PartsToBeCredited()
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

            
            

            private int _PartsToBeCreditedID = 0;

            public int PartsToBeCreditedID
            {
                get
                {
                    return _PartsToBeCreditedID;
                }
            }

            public object SetPartsToBeCreditedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartsToBeCreditedID", value);
                }
            }

            private int _OrderID = 0;

            public int OrderID
            {
                get
                {
                    return _OrderID;
                }
            }

            public object SetOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderID", value);
                }
            }

            private int _SupplierID = 0;

            public int SupplierID
            {
                get
                {
                    return _SupplierID;
                }
            }

            public object SetSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SupplierID", value);
                }
            }

            private int _PartID = 0;

            public int PartID
            {
                get
                {
                    return _PartID;
                }
            }

            public object SetPartID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartID", value);
                }
            }

            private int _Qty = 0;

            public int Qty
            {
                get
                {
                    return _Qty;
                }
            }

            public object SetQty
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Qty", value);
                }
            }

            private bool _ManuallyAdded = false;

            public int ManuallyAdded
            {
                get
                {
                    return Conversions.ToInteger(_ManuallyAdded);
                }
            }

            public object SetManuallyAdded
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ManuallyAdded", value);
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

            private double _CreditReceived = 0;

            public double CreditReceived
            {
                get
                {
                    return _CreditReceived;
                }
            }

            public object SetCreditReceived
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CreditReceived", value);
                }
            }

            private string _OrderReference = 0.ToString();

            public string OrderReference
            {
                get
                {
                    return _OrderReference;
                }
            }

            public object SetOrderReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderReference", value);
                }
            }

            private int _PartOrderID = 0;

            public int PartOrderID
            {
                get
                {
                    return _PartOrderID;
                }
            }

            public object SetPartOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartOrderID", value);
                }
            }

            private string _ReturnRef = 0.ToString();

            public string ReturnRef
            {
                get
                {
                    return _ReturnRef;
                }
            }

            public object SetReturnRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReturnRef", value);
                }
            }


            
        }
    }
}