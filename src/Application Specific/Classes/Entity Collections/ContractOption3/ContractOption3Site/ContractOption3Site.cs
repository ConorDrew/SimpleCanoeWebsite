using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ContractOption3Sites
    {
        public class ContractOption3Site
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOption3Site()
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

            private int _ContractSiteID = 0;

            public int ContractSiteID
            {
                get
                {
                    return _ContractSiteID;
                }
            }

            public object SetContractSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteID", value);
                }
            }

            private int _ContractID = 0;

            public int ContractID
            {
                get
                {
                    return _ContractID;
                }
            }

            public object SetContractID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractID", value);
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

            private string _ContractSiteReference = string.Empty;

            public string ContractSiteReference
            {
                get
                {
                    return _ContractSiteReference;
                }
            }

            public object SetContractSiteReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteReference", value);
                }
            }

            private DateTime _StartDate = default;

            public DateTime StartDate
            {
                get
                {
                    return _StartDate;
                }

                set
                {
                    _StartDate = value;
                }
            }

            private DateTime _EndDate = default;

            public DateTime EndDate
            {
                get
                {
                    return _EndDate;
                }

                set
                {
                    _EndDate = value;
                }
            }

            private DateTime _FirstVisitDate = default;

            public DateTime FirstVisitDate
            {
                get
                {
                    return _FirstVisitDate;
                }

                set
                {
                    _FirstVisitDate = value;
                }
            }

            private int _VisitFrequencyID = 0;

            public int VisitFrequencyID
            {
                get
                {
                    return _VisitFrequencyID;
                }
            }

            public object SetVisitFrequencyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisitFrequencyID", value);
                }
            }

            private int _InvoiceFrequencyID = 0;

            public int InvoiceFrequencyID
            {
                get
                {
                    return _InvoiceFrequencyID;
                }
            }

            public object SetInvoiceFrequencyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceFrequencyID", value);
                }
            }

            private double _SitePrice = 0;

            public double SitePrice
            {
                get
                {
                    return _SitePrice;
                }
            }

            public object SetSitePrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SitePrice", value);
                }
            }

            private DateTime _FirstInvoiceDate;

            public DateTime FirstInvoiceDate
            {
                get
                {
                    return _FirstInvoiceDate;
                }

                set
                {
                    _FirstInvoiceDate = value;
                }
            }

            private int _InvoiceAddressTypeID;

            public int InvoiceAddressTypeID
            {
                get
                {
                    return _InvoiceAddressTypeID;
                }
            }

            public object SetInvoiceAddressTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceAddressTypeID", value);
                }
            }

            private int _InvoiceAddressID = 0;

            public int InvoiceAddressID
            {
                get
                {
                    return _InvoiceAddressID;
                }
            }

            public object SetInvoiceAddressID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceAddressID", value);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}