using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Contacts
    {
        public class Contact
        {
            private DataTypeValidator _dataTypeValidator;

            public Contact()
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

            private string _Salutation = string.Empty;

            public string Salutation
            {
                get
                {
                    return _Salutation;
                }
            }

            public object SetSalutation
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Salutation", value);
                }
            }

            private string _FirstName = string.Empty;

            public string FirstName
            {
                get
                {
                    return _FirstName;
                }
            }

            public object SetFirstName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FirstName", value);
                }
            }

            private string _Surname = string.Empty;

            public string Surname
            {
                get
                {
                    return _Surname;
                }
            }

            public object SetSurname
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Surname", value);
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

            private string _MobileNo = string.Empty;

            public string MobileNo
            {
                get
                {
                    return _MobileNo;
                }
            }

            public object SetMobileNo
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MobileNo", value);
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

            private int _LinkID = 0;

            public int LinkID
            {
                get
                {
                    return _LinkID;
                }
            }

            public object SetLinkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LinkID", value);
                }
            }

            private int _LinkRef = 0;

            public int LinkRef
            {
                get
                {
                    return _LinkRef;
                }
            }

            public object SetLinkRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LinkRef", value);
                }
            }

            private bool _NoMarketing = false;

            public bool NoMarketing
            {
                get
                {
                    return _NoMarketing;
                }
            }

            public bool SetNoMarketing
            {
                set
                {
                    _NoMarketing = value;
                }
            }

            private string _PortalUserName = string.Empty;

            public string PortalUserName
            {
                get
                {
                    return _PortalUserName;
                }
            }

            public object SetPortalUserName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PortalUserName", value);
                }
            }

            private string _PortalPassword = string.Empty;

            public string PortalPassword
            {
                get
                {
                    return _PortalPassword;
                }
            }

            public object SetPortalPassword
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PortalPassword", value);
                }
            }

            private bool _PortalGSRPrint = false;

            public bool PortalGSRPrint
            {
                get
                {
                    return _PortalGSRPrint;
                }
            }

            public object SetPortalGSRPrint
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PortalGSRPrint", value);
                }
            }

            private int _EID = 0;

            public int EID
            {
                get
                {
                    return _EID;
                }
            }

            public object SetEID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EID", value);
                }
            }

            private bool _onContract = false;

            public bool OnContract
            {
                get
                {
                    return _onContract;
                }
            }

            public bool SetOnContract
            {
                set
                {
                    _onContract = value;
                }
            }

            private bool _pointOfContact = false;

            public bool PointOfContact
            {
                get
                {
                    return _pointOfContact;
                }
            }

            public bool SetPointOfContact
            {
                set
                {
                    _pointOfContact = value;
                }
            }

            private int _relationshipID;

            public int RelationshipID
            {
                get
                {
                    return _relationshipID;
                }
            }

            public int SetRelationshipID
            {
                set
                {
                    _relationshipID = value;
                }
            }

            private string _relationship;

            public int SetRelationship
            {
                set
                {
                    _relationship = value.ToString();
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
        }
    }
}