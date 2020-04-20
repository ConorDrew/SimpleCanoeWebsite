using System.Collections;

namespace FSM.Entity
{
    namespace CheckLists
    {
        public class CheckListAnswer
        {
            private DataTypeValidator _dataTypeValidator;

            public CheckListAnswer()
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _ChecklistAnswerID = 0;

            public int ChecklistAnswerID
            {
                get
                {
                    return _ChecklistAnswerID;
                }
            }

            public object SetChecklistAnswerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ChecklistAnswerID", value);
                }
            }

            private int _CheckListID = 0;

            public int CheckListID
            {
                get
                {
                    return _CheckListID;
                }
            }

            public object SetCheckListID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CheckListID", value);
                }
            }

            private int _EnumTableID = 0;

            public int EnumTableID
            {
                get
                {
                    return _EnumTableID;
                }
            }

            public object SetEnumTableID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EnumTableID", value);
                }
            }

            private int _QuestionID = 0;

            public int QuestionID
            {
                get
                {
                    return _QuestionID;
                }
            }

            public object SetQuestionID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuestionID", value);
                }
            }

            private int _ResultID = 0;

            public int ResultID
            {
                get
                {
                    return _ResultID;
                }
            }

            public object SetResultID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ResultID", value);
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







            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}