using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FSM.Entity.Sys;

namespace FSM
{
    public class DataGridJobTypeColumn : DataGridLabelColumn
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            // Need to get row information from data
            DataRow row = (DataRow)source.List[rowNum].row;

            // check for row before we call it
            if (row.Table.Columns.Contains("JobTypeID"))
            {
                int jobTypeId = Helper.MakeIntegerValid(row["JobTypeID"]);
                var color = Color.Transparent;
                if (row.Table.Columns.Contains("Colour"))
                {
                    string colour = Helper.MakeStringValid(row["Colour"]);
                    if (!string.IsNullOrWhiteSpace(colour))
                    {
                        color = Color.FromName(colour);
                    }
                }

                if (color != Color.Transparent)
                {
                    backBrush = new SolidBrush(color);
                    foreBrush = new SolidBrush(Helper.ContrastColor(color));
                }
            }

            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}