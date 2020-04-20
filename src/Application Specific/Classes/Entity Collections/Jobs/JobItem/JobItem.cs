﻿using System.Collections;

namespace FSM.Entity
{
    namespace JobItems
    {
        public class JobItem
        {
            private DataTypeValidator _dataTypeValidator;

            public JobItem()
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _JobItemID = 0;

            public int JobItemID
            {
                get
                {
                    return _JobItemID;
                }
            }

            public object SetJobItemID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobItemID", value);
                }
            }

            private int _JobOfWorkID = 0;

            public int JobOfWorkID
            {
                get
                {
                    return _JobOfWorkID;
                }
            }

            public object SetJobOfWorkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobOfWorkID", value);
                }
            }

            private string _Summary = string.Empty;

            public string Summary
            {
                get
                {
                    return _Summary;
                }
            }

            public object SetSummary
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Summary", value);
                }
            }

            private int _RateID = 0;

            public int RateID
            {
                get
                {
                    return _RateID;
                }
            }

            public object SetRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RateID", value);
                }
            }

            private decimal _Qty;

            public decimal Qty
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

            private int _systemLinkId = 0;

            public int SystemLinkID
            {
                get
                {
                    return _systemLinkId;
                }
            }

            public object SetSystemLinkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_systemLinkId", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}