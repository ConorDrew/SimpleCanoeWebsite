using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class DataGridSchedulerJobColumn : DataGridLabelColumn
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            // Need to get row information from data
            DataRowView row = (DataRowView)source.List[rowNum];
            if (row.DataView.Table.Columns.Contains("IsJobLate"))
            {
                if (Entity.Sys.Helper.MakeBooleanValid(row["IsJobLate"]))
                {
                    backBrush = Brushes.Red;
                }
            }

            if (row.DataView.Table.Columns.Contains("IsServiceOverDue"))
            {
                if (Entity.Sys.Helper.MakeBooleanValid(row["IsServiceOverDue"]))
                {
                    backBrush = Brushes.Orange;
                }
            }

            if (row.DataView.Table.Columns.Contains("Declined"))
            {
                if (Entity.Sys.Helper.MakeBooleanValid(row["Declined"]))
                {
                    backBrush = Brushes.LightGray;
                }
            }

            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}