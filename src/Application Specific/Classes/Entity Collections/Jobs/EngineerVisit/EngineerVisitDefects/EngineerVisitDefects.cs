using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitDefectss
    {
        public class EngineerVisitDefects
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitDefects()
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

            private int _EngineerVisitDefectID = 0;

            public int EngineerVisitDefectID
            {
                get
                {
                    return _EngineerVisitDefectID;
                }
            }

            public object SetEngineerVisitDefectID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitDefectID", value);
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

            public object SetCategoryID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CategoryID", value);
                }
            }

            private string _Reason = string.Empty;

            public string Reason
            {
                get
                {
                    return _Reason;
                }
            }

            public object SetReason
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Reason", value);
                }
            }

            private string _ActionTaken = string.Empty;

            public string ActionTaken
            {
                get
                {
                    return _ActionTaken;
                }
            }

            public object SetActionTaken
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ActionTaken", value);
                }
            }

            private bool _WarningNoticeIssued = false;

            public bool WarningNoticeIssued
            {
                get
                {
                    return _WarningNoticeIssued;
                }
            }

            public object SetWarningNoticeIssued
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WarningNoticeIssued", value);
                }
            }

            private bool _Disconnected = false;

            public bool Disconnected
            {
                get
                {
                    return _Disconnected;
                }
            }

            public object SetDisconnected
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Disconnected", value);
                }
            }

            private string _Comments = string.Empty;

            public string Comments
            {
                get
                {
                    return _Comments;
                }
            }

            public object SetComments
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Comments", value);
                }
            }

            private int _AssetID = 0;

            public int AssetID
            {
                get
                {
                    return _AssetID;
                }
            }

            public object SetAssetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AssetID", value);
                }
            }

            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }
            }

            public object SetEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitID", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}