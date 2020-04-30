using System.Collections;

namespace FSM
{
    public class ValidatorMessages
    {
        
        private ArrayList _criticalMessages;

        public ArrayList CriticalMessages
        {
            get
            {
                return _criticalMessages;
            }
        }

        private ArrayList _warningMessages;

        public ArrayList WarningMessages
        {
            get
            {
                return _warningMessages;
            }
        }

        
        

        public ValidatorMessages()
        {
            _criticalMessages = new ArrayList();
            _warningMessages = new ArrayList();
        }

        
    }
}