using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class DataGridSchedulerColumn : DataGridLabelColumn
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            var brush = Brushes.White;
            var strBrush = Brushes.MidnightBlue;
            string str = "";

            // Need to get row information from data
            DataRow row = (DataRow)source.List[rowNum].row;

            // check for row before we call it
            if (row.Table.Columns.Contains("IsJobLate"))
            {
                if (Entity.Sys.Helper.MakeBooleanValid(row["IsJobLate"]))
                {
                    brush = Brushes.Red;
                    str = "L";
                }
            }

            // check for row before we call it
            if (row.Table.Columns.Contains("IsServiceOverDue"))
            {
                if (Entity.Sys.Helper.MakeBooleanValid(row["IsServiceOverDue"]))
                {
                    brush = Brushes.Orange;
                    str = "O";
                }
            }

            // check for row before we call it
            if (row.Table.Columns.Contains("Declined"))
            {
                if (Entity.Sys.Helper.MakeBooleanValid(row["Declined"]))
                {
                    brush = Brushes.LightGray;
                    str = "D";
                }
            }

            var rect = bounds;
            g.FillRectangle(brush, rect);
            g.DrawString(str, DataGridTableStyle.DataGrid.Font, strBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}