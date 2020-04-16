// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Products.Product
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Products
{
    public class Product
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _ProductID;
        private string _Number;
        private string _Reference;
        private string _Name;
        private int _TypeID;
        private int _MakeID;
        private int _ModelID;
        private double _sellPrice;
        private string _Notes;
        private int _MinimumQuantity;
        private int _RecommendedQuantity;
        private DataView _AssociatedPart;

        public Product()
        {
            this._exists = false;
            this._deleted = false;
            this._ProductID = 0;
            this._Number = string.Empty;
            this._Reference = string.Empty;
            this._Name = string.Empty;
            this._TypeID = 0;
            this._MakeID = 0;
            this._ModelID = 0;
            this._sellPrice = 0.0;
            this._Notes = string.Empty;
            this._MinimumQuantity = 0;
            this._RecommendedQuantity = 0;
            this._AssociatedPart = new DataView();
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

        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
        }

        public object SetProductID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ProductID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Number
        {
            get
            {
                return this._Number;
            }
        }

        public object SetNumber
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Number", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Reference
        {
            get
            {
                return this._Reference;
            }
        }

        public object SetReference
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Reference", RuntimeHelpers.GetObjectValue(value));
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

        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
        }

        public object SetTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int MakeID
        {
            get
            {
                return this._MakeID;
            }
        }

        public object SetMakeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MakeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ModelID
        {
            get
            {
                return this._ModelID;
            }
        }

        public object SetModelID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ModelID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double SellPrice
        {
            get
            {
                return this._sellPrice;
            }
        }

        public object SetSellPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_sellPrice", RuntimeHelpers.GetObjectValue(value));
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

        public int MinimumQuantity
        {
            get
            {
                return this._MinimumQuantity;
            }
        }

        public object SetMinimumQuantity
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MinimumQuantity", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int RecommendedQuantity
        {
            get
            {
                return this._RecommendedQuantity;
            }
        }

        public object SetRecommendedQuantity
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_RecommendedQuantity", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DataView AssociatedPart
        {
            get
            {
                return this._AssociatedPart;
            }
            set
            {
                this._AssociatedPart = value;
            }
        }
    }
}