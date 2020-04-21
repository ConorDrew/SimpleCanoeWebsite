using System.Collections;

namespace FSM
{
    public class ValidatorMessages
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public ValidatorMessages()
        {
            _criticalMessages = new ArrayList();
            _warningMessages = new ArrayList();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}