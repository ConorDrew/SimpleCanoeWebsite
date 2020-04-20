using System.Data;
using System.Linq;
using FSM.Entity.Orders;
using FSM.Entity.Sys;

namespace FSM.Business.Orders
{
    public class OrderControl
    {
        private Order _order;

        public OrderControl(Order order)
        {
            _order = order;
        }

        public bool IsWithinJobSpendLimit()
        {
            bool isValid = false;
            var job = App.DB.Job.Job_Get_ByOrderID(_order.OrderID);
            if (job is null)
            {
                isValid = true;
            }
            else
            {
                // ask business for the allowance
                decimal spendLimit = GetJobSpendLimit(job.JobID);
                if (spendLimit == -1)
                {
                    isValid = true;
                }
                else if (GetCurrentJobCost(job.JobID) > spendLimit)
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        private decimal GetJobSpendLimit(int jobId)
        {
            decimal spendLimit = -1;
            var costCentre = App.DB.CostCentre.Get(jobId, default, Entity.CostCentres.Enums.GetBy.JobId)?.FirstOrDefault();
            if (costCentre is object && costCentre.JobSpendLimit > 0)
            {
                spendLimit = costCentre.JobSpendLimit;
            }
            else
            {
                var customer = App.DB.Customer.Customer_Get_ByOrderID(_order.OrderID);
                if (customer is object && customer.JobSpendLimit > 0)
                {
                    spendLimit = customer.JobSpendLimit;
                }
            }

            return spendLimit;
        }

        private decimal GetCurrentJobCost(int jobId)
        {
            var dvPartsCost = App.DB.EngineerVisitsPartsAndProducts.Get_CurrentCost_ByJobID(jobId);
            decimal total = 0.0M;
            foreach (DataRow row in dvPartsCost.Table.Rows)
            {
                if (!Helper.MakeStringValid(row["Part"]).Contains("IBC"))
                {
                    total += Helper.MakeDoubleValid(row["Cost"]);
                }
            }

            return total;
        }
    }
}