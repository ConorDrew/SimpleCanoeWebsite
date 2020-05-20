using System.Collections;

namespace FSM.Entity
{
    namespace InvoiceAddresss
    {
        public class InvoiceAddress
        {
            private DataTypeValidator _dataTypeValidator;

            public InvoiceAddress()
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

            private string _Address1 = string.Empty;

            public string Address1
            {
                get
                {
                    return _Address1;
                }
            }

            public object SetAddress1
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address1", value);
                }
            }

            private string _Address2 = string.Empty;

            public string Address2
            {
                get
                {
                    return _Address2;
                }
            }

            public object SetAddress2
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address2", value);
                }
            }

            private string _Address3 = string.Empty;

            public string Address3
            {
                get
                {
                    return _Address3;
                }
            }

            public object SetAddress3
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address3", value);
                }
            }

            private string _Address4 = string.Empty;

            public string Address4
            {
                get
                {
                    return _Address4;
                }
            }

            public object SetAddress4
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address4", value);
                }
            }

            private string _Address5 = string.Empty;

            public string Address5
            {
                get
                {
                    return _Address5;
                }
            }

            public object SetAddress5
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address5", value);
                }
            }

            private string _Postcode = string.Empty;

            public string Postcode
            {
                get
                {
                    return _Postcode;
                }
            }

            public object SetPostcode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Postcode", value);
                }
            }

            private string _TelephoneNum = string.Empty;

            public string TelephoneNum
            {
                get
                {
                    return _TelephoneNum;
                }
            }

            public object SetTelephoneNum
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TelephoneNum", value);
                }
            }

            private string _FaxNum = string.Empty;

            public string FaxNum
            {
                get
                {
                    return _FaxNum;
                }
            }

            public object SetFaxNum
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FaxNum", value);
                }
            }

            private string _EmailAddress = string.Empty;

            public string EmailAddress
            {
                get
                {
                    return _EmailAddress;
                }
            }

            public object SetEmailAddress
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EmailAddress", value);
                }
            }

            private int _SiteID = 0;

            public int SiteID
            {
                get
                {
                    return _SiteID;
                }
            }

            public object SetSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteID", value);
                }
            }



            
        }
    }
}