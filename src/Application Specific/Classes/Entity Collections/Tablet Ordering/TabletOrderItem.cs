﻿using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace TabletOrders
    {
        public class TabletOrderItem
        {
            private DataTypeValidator _dataTypeValidator;

            public TabletOrderItem()
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

            private int _TabletOrderID = 0;

            public int TabletOrderID
            {
                get
                {
                    return _TabletOrderID;
                }
            }

            public object SetTabletOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TabletOrderID", value);
                }
            }

            private int _EngineerID;

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

            private int _SupplierID;

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
        }
    }
}