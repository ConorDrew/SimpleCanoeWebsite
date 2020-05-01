using System;
using System.Collections;

namespace FSM.Entity
{
    namespace StandardSentences
    {
        public class StandardSentence
        {
            private DataTypeValidator _dataTypeValidator;

            public StandardSentence()
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

            private int _SentenceID = 0;

            public int SentenceID
            {
                get
                {
                    return _SentenceID;
                }
            }

            public object SetSentenceID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SentenceID", value);
                }
            }

            private string _Sentence = string.Empty;

            public string Sentence
            {
                get
                {
                    return _Sentence;
                }
            }

            public object SetSentence
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Sentence", value);
                }
            }
        }
    }
}