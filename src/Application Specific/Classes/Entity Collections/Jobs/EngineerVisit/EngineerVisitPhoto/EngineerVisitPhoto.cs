using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitPhotos
    {
        public class EngineerVisitPhoto
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitPhoto()
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

            
            

            private int _EngineerVisitPhotoID = 0;

            public int EngineerVisitPhotoID
            {
                get
                {
                    return _EngineerVisitPhotoID;
                }
            }

            public object SetEngineerVisitPhotoID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitPhotoID", value);
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

            private byte[] _Photo = null;

            public byte[] Photo
            {
                get
                {
                    return _Photo;
                }
            }

            public object SetPhoto
            {
                set
                {
                    _Photo = (byte[])value;
                }
            }

            private string _Caption = string.Empty;

            public string Caption
            {
                get
                {
                    return _Caption;
                }
            }

            public object SetCaption
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Caption", value);
                }
            }



            
        }
    }
}