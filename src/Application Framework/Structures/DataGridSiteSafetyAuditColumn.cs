using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FSM.Entity.Sys;

namespace FSM
{
    public class DataGridSiteSafetyAuditColumn : DataGridLabelColumn
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {

            // Need to get row information from data
            DataRow row = (DataRow)source.List[rowNum].row;

            // check for row before we call it
            if (row.Table.Columns.Contains("Result"))
            {
                double result = Helper.MakeDoubleValid(row["Result"]);
                if (result >= 90)
                {
                    backBrush = Brushes.Green;
                    foreBrush = new SolidBrush(Helper.ContrastColor(Color.Green));
                }
                else if (result >= 75 && result < 90)
                {
                    backBrush = Brushes.Orange;
                    foreBrush = new SolidBrush(Helper.ContrastColor(Color.Orange));
                }
                else if (result >= 60 && result < 75)
                {
                    backBrush = Brushes.Orange;
                    foreBrush = new SolidBrush(Helper.ContrastColor(Color.Orange));
                }
                else
                {
                    backBrush = Brushes.Red;
                    foreBrush = new SolidBrush(Helper.ContrastColor(Color.Red));
                }
            }

            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}