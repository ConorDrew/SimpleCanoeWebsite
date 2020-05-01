using System;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Jobs
    {
        public class Job
        {
            private DataTypeValidator _dataTypeValidator;

            public Job()
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



            private int _JobID = 0;

            public int JobID
            {
                get
                {
                    return _JobID;
                }
            }

            public object SetJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobID", value);
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

            private int _JobDefinitionEnumID = 0;

            public int JobDefinitionEnumID
            {
                get
                {
                    return _JobDefinitionEnumID;
                }
            }

            public object SetJobDefinitionEnumID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobDefinitionEnumID", value);
                }
            }

            private int _JobTypeID = 0;

            public int JobTypeID
            {
                get
                {
                    return _JobTypeID;
                }
            }

            public object SetJobTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobTypeID", value);
                }
            }

            private int _StatusEnumID = 0;

            public int StatusEnumID
            {
                get
                {
                    return _StatusEnumID;
                }
            }

            public object SetStatusEnumID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_StatusEnumID", value);
                }
            }

            private DateTime _DateCreated = default;

            public DateTime DateCreated
            {
                get
                {
                    return _DateCreated;
                }

                set
                {
                    _DateCreated = value;
                }
            }

            private int _CreatedByUserID = 0;

            public int CreatedByUserID
            {
                get
                {
                    return _CreatedByUserID;
                }
            }

            public object SetCreatedByUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CreatedByUserID", value);
                }
            }

            private string _JobNumber = string.Empty;

            public string JobNumber
            {
                get
                {
                    return _JobNumber;
                }
            }

            public object SetJobNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobNumber", value);
                }
            }

            private string _PONumber = string.Empty;

            public string PONumber
            {
                get
                {
                    return _PONumber;
                }
            }

            public object SetPONumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PONumber", value);
                }
            }

            private int _QuoteID = 0;

            public int QuoteID
            {
                get
                {
                    return _QuoteID;
                }
            }

            public object SetQuoteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteID", value);
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

            private bool _ToBePartPaid = false;

            public bool ToBePartPaid
            {
                get
                {
                    return _ToBePartPaid;
                }
            }

            public object SetToBePartPaid
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ToBePartPaid", value);
                }
            }

            private double _retention = 0;

            public double Retention
            {
                get
                {
                    return _retention;
                }
            }

            public object SetRetention
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_retention", value);
                }
            }

            private bool _CollectPayment = Conversions.ToBoolean(0);

            public bool CollectPayment
            {
                get
                {
                    return _CollectPayment;
                }
            }

            public object SetCollectPayment
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CollectPayment", value);
                }
            }

            private bool _POC = false;

            public bool POC
            {
                get
                {
                    return _POC;
                }
            }

            public object SetPOC
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_POC", value);
                }
            }

            private bool _OTI = false;

            public bool OTI
            {
                get
                {
                    return _OTI;
                }
            }

            public object SetOTI
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OTI", value);
                }
            }

            private bool _fOC = false;

            public bool FOC
            {
                get
                {
                    return _fOC;
                }
            }

            public object SetFOC
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_fOC", value);
                }
            }

            private int _salesRepUserID = 0;

            public int SalesRepUserID
            {
                get
                {
                    return _salesRepUserID;
                }
            }

            public object SetSalesRepUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_salesRepUserID", value);
                }
            }

            private int _jobCreationType = 0;

            public int JobCreationType
            {
                get
                {
                    return _jobCreationType;
                }
            }

            public object SetJobCreationType
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_jobCreationType", value);
                }
            }

            private string _Headline = string.Empty;

            public string Headline
            {
                get
                {
                    return _Headline;
                }
            }

            public object SetHeadline
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Headline", value);
                }
            }



            private ArrayList _assets = new ArrayList();

            public ArrayList Assets
            {
                get
                {
                    return _assets;
                }

                set
                {
                    _assets = value;
                }
            }

            private ArrayList _jobOfWorks = new ArrayList();

            public ArrayList JobOfWorks
            {
                get
                {
                    return _jobOfWorks;
                }

                set
                {
                    _jobOfWorks = value;
                }
            }

            private DataView _JobQualificationsLevels = new DataView();

            public DataView JobQualificationsLevels
            {
                get
                {
                    return _JobQualificationsLevels;
                }

                set
                {
                    _JobQualificationsLevels = value;
                    _JobQualificationsLevels.AllowEdit = true;
                    _JobQualificationsLevels.AllowNew = false;
                    _JobQualificationsLevels.AllowDelete = false;
                }
            }

            private DataView _JobSheets = new DataView();

            public DataView JobSheets
            {
                get
                {
                    return _JobSheets;
                }

                set
                {
                    _JobSheets = value;
                    _JobSheets.AllowEdit = true;
                    _JobSheets.AllowNew = false;
                    _JobSheets.AllowDelete = false;
                }
            }


        }
    }
}