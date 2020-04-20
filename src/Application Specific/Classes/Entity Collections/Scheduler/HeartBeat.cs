using System;

namespace FSM.Entity
{
    namespace HeartBeats
    {
        public class HeartBeat
        {
            private DataTypeValidator _dataTypeValidator;

            public HeartBeat()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            private int _LockedVisitID = 0;

            public int LockedVisitID
            {
                get
                {
                    return _LockedVisitID;
                }
            }

            public object SetLockedVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LockedVisitID", value);
                }
            }

            private DateTime _LastHeartBeat = default;

            public DateTime LastHeartBeat
            {
                get
                {
                    return _LastHeartBeat;
                }

                set
                {
                    _LastHeartBeat = value;
                }
            }

            private DateTime _LastCheck = default;

            public DateTime LastCheck
            {
                get
                {
                    return _LastCheck;
                }

                set
                {
                    _LastCheck = value;
                }
            }
        }
    }
}