using System;
using System.Collections;

namespace FSM.Entity
{
    namespace QuoteOrders
    {
        public class QuoteOrder
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteOrder()
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

            
            

            private int _QuoteOrderID = 0;

            public int QuoteOrderID
            {
                get
                {
                    return _QuoteOrderID;
                }
            }

            public object SetQuoteOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteOrderID", value);
                }
            }

            private int _CustomerID = 0;

            public int CustomerID
            {
                get
                {
                    return _CustomerID;
                }
            }

            public object SetCustomerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerID", value);
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

            private int _QuoteStatusID = 0;

            public int QuoteStatusID
            {
                get
                {
                    return _QuoteStatusID;
                }
            }

            public object SetQuoteStatusID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteStatusID", value);
                }
            }

            private int _ContactID = 0;

            public int ContactID
            {
                get
                {
                    return _ContactID;
                }
            }

            public object SetContactID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContactID", value);
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

            private string _ReasonForReject = string.Empty;

            public string ReasonForReject
            {
                get
                {
                    return _ReasonForReject;
                }
            }

            public object SetReasonForReject
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonForReject", value);
                }
            }

            private int _ReasonForRejectID = 0;

            public int ReasonForRejectID
            {
                get
                {
                    return _ReasonForRejectID;
                }
            }

            public object SetReasonForRejectID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonForRejectID", value);
                }
            }

            private string _CustomerRef = string.Empty;

            public string CustomerRef
            {
                get
                {
                    return _CustomerRef;
                }
            }

            public object SetCustomerRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerRef", value);
                }
            }

            private DateTime _DeliveryDeadline = default;

            public DateTime DeliveryDeadline
            {
                get
                {
                    return _DeliveryDeadline;
                }

                set
                {
                    _DeliveryDeadline = value;
                }
            }

            private string _SpecialInstructions = string.Empty;

            public string SpecialInstructions
            {
                get
                {
                    return _SpecialInstructions;
                }
            }

            public object SetSpecialInstructions
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SpecialInstructions", value);
                }
            }

            private int _CreatedByUser = 0;

            public int CreatedByUser
            {
                get
                {
                    return _CreatedByUser;
                }
            }

            public object SetCreatedByUser
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CreatedByUser", value);
                }
            }

            private int _AllocatedToUser = 0;

            public int AllocatedToUser
            {
                get
                {
                    return _AllocatedToUser;
                }
            }

            public object SetAllocatedToUser
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AllocatedToUser", value);
                }
            }

            private DateTime _EnquiryDate = default;

            public DateTime EnquiryDate
            {
                get
                {
                    return _EnquiryDate;
                }

                set
                {
                    _EnquiryDate = value;
                }
            }

            private DateTime _validUntilDate = default;

            public DateTime ValidUntilDate
            {
                get
                {
                    return _validUntilDate;
                }

                set
                {
                    _validUntilDate = value;
                }
            }

            private string _Availability = string.Empty;

            public string Availability
            {
                get
                {
                    return _Availability;
                }
            }

            public object SetAvailability
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Availability", value);
                }
            }

            private string _PriceDetails = string.Empty;

            public string PriceDetails
            {
                get
                {
                    return _PriceDetails;
                }
            }

            public object SetPriceDetails
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PriceDetails", value);
                }
            }

            private string _PriceExcludeDetails = string.Empty;

            public string PriceExcludeDetails
            {
                get
                {
                    return _PriceExcludeDetails;
                }
            }

            public object SetPriceExcludeDetails
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PriceExcludeDetails", value);
                }
            }
            
        }
    }
}