// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CheckLists.CheckListAnswer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.CheckLists
{
    public class CheckListAnswer
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private int _ChecklistAnswerID;
        private int _CheckListID;
        private int _EnumTableID;
        private int _QuestionID;
        private int _ResultID;
        private string _Comments;

        public CheckListAnswer()
        {
            this._exists = false;
            this._ChecklistAnswerID = 0;
            this._CheckListID = 0;
            this._EnumTableID = 0;
            this._QuestionID = 0;
            this._ResultID = 0;
            this._Comments = string.Empty;
            this._dataTypeValidator = new DataTypeValidator();
        }

        public bool IgnoreExceptionsOnSetMethods
        {
            get
            {
                return this._dataTypeValidator.IgnoreExceptionsOnSetMethods;
            }
            set
            {
                this._dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
            }
        }

        public Hashtable Errors
        {
            get
            {
                return this._dataTypeValidator.Errors;
            }
        }

        public DataTypeValidator DTValidator
        {
            get
            {
                return this._dataTypeValidator;
            }
        }

        public bool Exists
        {
            get
            {
                return this._exists;
            }
            set
            {
                this._exists = value;
            }
        }

        public int ChecklistAnswerID
        {
            get
            {
                return this._ChecklistAnswerID;
            }
        }

        public object SetChecklistAnswerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ChecklistAnswerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int CheckListID
        {
            get
            {
                return this._CheckListID;
            }
        }

        public object SetCheckListID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CheckListID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EnumTableID
        {
            get
            {
                return this._EnumTableID;
            }
        }

        public object SetEnumTableID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EnumTableID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QuestionID
        {
            get
            {
                return this._QuestionID;
            }
        }

        public object SetQuestionID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuestionID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ResultID
        {
            get
            {
                return this._ResultID;
            }
        }

        public object SetResultID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ResultID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Comments
        {
            get
            {
                return this._Comments;
            }
        }

        public object SetComments
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Comments", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}