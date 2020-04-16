// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobLock.JobLock
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;

namespace FSM.Entity.JobLock
{
    public class JobLock
    {
        private int _jobLockID;
        private int _jobID;
        private int _userID;
        private DateTime _dateLock;
        private string _nameOfUserWhoLocked;

        public JobLock()
        {
            this._jobLockID = 0;
            this._jobID = 0;
            this._userID = 0;
            this._dateLock = DateTime.MinValue;
            this._nameOfUserWhoLocked = "";
        }

        public int JobLockID
        {
            get
            {
                return this._jobLockID;
            }
            set
            {
                this._jobLockID = value;
            }
        }

        public int JobID
        {
            get
            {
                return this._jobID;
            }
            set
            {
                this._jobID = value;
            }
        }

        public int UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                this._userID = value;
            }
        }

        public DateTime DateLock
        {
            get
            {
                return this._dateLock;
            }
            set
            {
                this._dateLock = value;
            }
        }

        public string NameOfUserWhoLocked
        {
            get
            {
                return this._nameOfUserWhoLocked;
            }
            set
            {
                this._nameOfUserWhoLocked = value;
            }
        }
    }
}