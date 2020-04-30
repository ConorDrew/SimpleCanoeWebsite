using System.Collections;

namespace FSM.Entity
{
    namespace Parts
    {
        public class Part
        {
            private DataTypeValidator _dataTypeValidator;

            public Part()
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

            private int _SPartID = 0;

            public int SPartID
            {
                get
                {
                    return _SPartID;
                }
            }

            public object SetSPartID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SPartID", value);
                }
            }

            private int _CategoryID = 0;

            public int CategoryID
            {
                get
                {
                    return _CategoryID;
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

            private int _FuelID = 0;

            public int FuelID
            {
                get
                {
                    return _FuelID;
                }
            }

            public object SetFuelID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FuelID", value);
                }
            }

            public object SetCategoryID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CategoryID", value);
                }
            }

            private int _UnitTypeID = 0;

            public int UnitTypeID
            {
                get
                {
                    return _UnitTypeID;
                }
            }

            public object SetUnitTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UnitTypeID", value);
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

            private int _WarehouseID = 0;

            public int WarehouseID
            {
                get
                {
                    return _WarehouseID;
                }
            }

            public object SetWarehouseID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WarehouseID", value);
                }
            }

            private int _BinID = 0;

            public int BinID
            {
                get
                {
                    return _BinID;
                }
            }

            public object SetBinID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BinID", value);
                }
            }

            private int _ShelfID = 0;

            public int ShelfID
            {
                get
                {
                    return _ShelfID;
                }
            }

            public object SetShelfID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ShelfID", value);
                }
            }

            private int _WarehouseQuantity = 0;

            public int WarehouseQuantity
            {
                get
                {
                    return _WarehouseQuantity;
                }
            }

            public object SetWarehouseQuantity
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WarehouseQuantity", value);
                }
            }

            private int _WarehouseIDAlternative = 0;

            public int WarehouseIDAlternative
            {
                get
                {
                    return _WarehouseIDAlternative;
                }
            }

            public object SetWarehouseIDAlternative
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WarehouseIDAlternative", value);
                }
            }

            private int _BinIDAlternative = 0;

            public int BinIDAlternative
            {
                get
                {
                    return _BinIDAlternative;
                }
            }

            public object SetBinIDAlternative
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BinIDAlternative", value);
                }
            }

            private int _ShelfIDAlternative = 0;

            public int ShelfIDAlternative
            {
                get
                {
                    return _ShelfIDAlternative;
                }
            }

            public object SetShelfIDAlternative
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ShelfIDAlternative", value);
                }
            }

            private bool _EndFlagged = false;

            public bool EndFlagged
            {
                get
                {
                    return _EndFlagged;
                }
            }

            public bool SetEndFlagged
            {
                set
                {
                    _EndFlagged = value;
                }
            }

            private bool _Equipment = false;

            public bool Equipment
            {
                get
                {
                    return _Equipment;
                }
            }

            public bool SetEquipment
            {
                set
                {
                    _Equipment = value;
                }
            }

            private bool _IsSpecialPart = false;

            public bool IsSpecialPart
            {
                get
                {
                    return _IsSpecialPart;
                }
            }

            public bool SetIsSpecialPart
            {
                set
                {
                    _IsSpecialPart = value;
                }
            }

            
        }
    }
}