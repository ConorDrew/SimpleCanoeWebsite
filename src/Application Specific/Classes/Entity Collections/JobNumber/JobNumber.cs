namespace FSM
{
    public class JobNumber
    {
        private int _jobNumber = 0;
        private string _prefix = 0.ToString();
        private string _OrderNumber = "";

        public int Number
        {
            get
            {
                return _jobNumber;
            }

            set
            {
                _jobNumber = value;
            }
        }

        public string Prefix
        {
            get
            {
                return _prefix;
            }

            set
            {
                _prefix = value;
            }
        }

        public string OrderNumber
        {
            get
            {
                return _OrderNumber;
            }

            set
            {
                _OrderNumber = value;
            }
        }

        public JobNumber()
        {
        }

        public JobNumber(int jobNumberIn, string PrefixIn)
        {
            Number = jobNumberIn;
            Prefix = PrefixIn;
        }
    }
}