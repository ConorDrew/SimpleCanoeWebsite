using System.Collections;

namespace FSM.Entity
{
    namespace Subcontractors
    {
        public class Subcontractor
        {
            private DataTypeValidator _dataTypeValidator;

            public Subcontractor()
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
            private int _SubcontractorID = 0;

            public int SubcontractorID
            {
                get
                {
                    return _SubcontractorID;
                }
            }

            public object SetSubcontractorID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SubcontractorID", value);
                }
            }

            private int _EngineerID = 0;

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
                    Engineer = App.DB.Engineer.Engineer_Get(EngineerID);
                }
            }

            private int _LinkToSupplierID = 0;

            public int LinkToSupplierID
            {
                get
                {
                    return _LinkToSupplierID;
                }
            }

            public object SetLinkToSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LinkToSupplierID", value);
                }
            }

            private int _taxRate = 0;

            public int TaxRate
            {
                get
                {
                    return _taxRate;
                }
            }

            public object SetTaxRate
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_taxRate", value);
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private Engineers.Engineer _Engineer = null;

            public Engineers.Engineer Engineer
            {
                get
                {
                    return _Engineer;
                }

                set
                {
                    _Engineer = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}