using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class UnscheduledCallsColumn : DataGridLabelColumn
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            // set the color required dependant on the column value
            Brush brush;
            string str = "";
            brush = Brushes.White;
            DataRowView row = (DataRowView)source.List[rowNum];

            if (Entity.Sys.Helper.MakeBooleanValid(row["FollowUpDeclined"]) == true)
            {
                brush = Brushes.Salmon;
            }
            else
            {
                brush = backBrush;
            }

            // If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item("PartsNeedOrdering")) = True Then
            // brush = Brushes.Purple
            // Else : brush = backBrush
            // End If

            TextBox.Text = "";

            // color the row cell
            var rect = bounds;
            g.FillRectangle(brush, rect);
            base.Paint(g, bounds, source, rowNum, brush, foreBrush, alignToRight);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}