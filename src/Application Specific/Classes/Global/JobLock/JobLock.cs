using System;

namespace FSM.Entity
{
    namespace JobLock
    {
        public class JobLock
        {

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int _jobLockID = 0;

            public int JobLockID
            {
                get
                {
                    return _jobLockID;
                }

                set
                {
                    _jobLockID = value;
                }
            }

            private int _jobID = 0;

            public int JobID
            {
                get
                {
                    return _jobID;
                }

                set
                {
                    _jobID = value;
                }
            }

            private int _userID = 0;

            public int UserID
            {
                get
                {
                    return _userID;
                }

                set
                {
                    _userID = value;
                }
            }

            private DateTime _dateLock = default;

            public DateTime DateLock
            {
                get
                {
                    return _dateLock;
                }

                set
                {
                    _dateLock = value;
                }
            }

            private string _nameOfUserWhoLocked = "";

            public string NameOfUserWhoLocked
            {
                get
                {
                    return _nameOfUserWhoLocked;
                }

                set
                {
                    _nameOfUserWhoLocked = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}