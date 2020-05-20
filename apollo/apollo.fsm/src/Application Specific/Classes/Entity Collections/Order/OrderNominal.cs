
namespace FSM.Orders
{
    public class OrderNominal
    {
        public OrderNominal()
        {
        }

        private string _nominalCode;

        public string NominalCode
        {
            get
            {
                return _nominalCode;
            }

            set
            {
                _nominalCode = value;
            }
        }

        private string _friendlyName;

        public string FriendlyName
        {
            get
            {
                return _friendlyName;
            }

            set
            {
                _friendlyName = value;
            }
        }

        private int _quantity;

        public int Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = value;
            }
        }

        private double _total;

        public double Total
        {
            get
            {
                return _total;
            }

            set
            {
                _total = value;
            }
        }

        private double _invoicedTotal;

        public double InvoicedTotal
        {
            get
            {
                return _invoicedTotal;
            }

            set
            {
                _invoicedTotal = value;
            }
        }
    }
}