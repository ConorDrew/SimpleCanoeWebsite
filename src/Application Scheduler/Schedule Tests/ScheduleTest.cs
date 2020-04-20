using System;
using System.Collections;
using System.Data;

namespace FSM
{
    public abstract class ScheduleTest
    {
        public class TestResult
        {
            private bool _pass;
            private bool _cancelSchedule;
            private bool _passwordPrompt;
            private string _failMessage;
            private ArrayList _failMessages = new ArrayList();

            public TestResult()
            {
                _pass = true;
                _failMessage = failMessage;
                _cancelSchedule = false;
                _passwordPrompt = false;
            }

            public TestResult(string failMessage, bool cancelSchedule = false, bool passwordPrompt = false)
            {
                _pass = false;
                _failMessage = failMessage;
                _cancelSchedule = cancelSchedule;
                _passwordPrompt = passwordPrompt;
            }

            public TestResult(ArrayList failMessages, bool cancelSchedule = false, bool passwordPrompt = false)
            {
                _pass = false;
                _failMessages = failMessages;
                _cancelSchedule = cancelSchedule;
                _passwordPrompt = passwordPrompt;
            }

            public bool pass
            {
                get
                {
                    return _pass;
                }
            }

            public string failMessage
            {
                get
                {
                    return _failMessage;
                }
            }

            public ArrayList failMessages
            {
                get
                {
                    return _failMessages;
                }
            }

            public bool CancelSchedule
            {
                get
                {
                    return _cancelSchedule;
                }
            }

            public bool PasswordPrompt
            {
                get
                {
                    return _passwordPrompt;
                }
            }
        }

        protected abstract string TestName { get; }

        public abstract TestResult Test(DataRow testRow, int engineerID, DateTime day);
    }
}