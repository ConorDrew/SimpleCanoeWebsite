using System;
using Microsoft.VisualBasic;

namespace FSM
{
    public class BaseValidator
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected ValidatorMessages _validatorMessages;

        public ValidatorMessages ValidatorMessages
        {
            get
            {
                return _validatorMessages;
            }

            set
            {
                _validatorMessages = value;
            }
        }

        public string CriticalMessagesString()
        {
            string msgString = "";
            foreach (string s in _validatorMessages.CriticalMessages)
                msgString += s + Constants.vbCrLf;
            return msgString;
        }

        public string WarningMessageString()
        {
            string msgString = "";
            foreach (string s in _validatorMessages.WarningMessages)
                msgString += s + Constants.vbCrLf;
            return msgString;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public BaseValidator()
        {
            _validatorMessages = new ValidatorMessages();
        }

        public void AddCriticalMessage(string message)
        {
            _validatorMessages.CriticalMessages.Add(message);
        }

        public void AddWarningMessage(string message)
        {
            _validatorMessages.WarningMessages.Add(message);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public class ValidationException : Exception
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private BaseValidator m_valid = new BaseValidator();

        public BaseValidator Validator
        {
            get
            {
                return m_valid;
            }

            set
            {
                m_valid = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public ValidationException(BaseValidator inValidator)
        {
            m_valid = inValidator;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}