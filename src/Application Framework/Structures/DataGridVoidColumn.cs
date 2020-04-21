using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class DataGridVoidColumn : DataGridLabelColumn
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            // Need to get row information from data
            DataRowView row = (DataRowView)source.List[rowNum];

            // check for row before we call it

            bool voidProp = false;
            if (row.DataView.Table.Columns.Contains("PropertyVoid"))
            {
                voidProp = Entity.Sys.Helper.MakeBooleanValid(row["PropertyVoid"]);
            }

            if (voidProp)
            {
                backBrush = Brushes.Yellow;
            }
            else
            {
                backBrush = backBrush;
            }

            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}