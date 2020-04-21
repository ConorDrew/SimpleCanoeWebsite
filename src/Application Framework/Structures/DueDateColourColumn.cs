using Microsoft.VisualBasic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class DueDateColourColumn : DataGridLabelColumn
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            // set the color required dependant on the column value
            Brush brush;
            DataRowView row = (DataRowView)source.List[rowNum];
            if (Entity.Sys.Helper.MakeDateTimeValid(row["NextVisitDate"]) < DateAndTime.Now.AddDays(14) & (Entity.Sys.Helper.MakeStringValid(row["Type"]) ?? "") != "Letter 3" | Entity.Sys.Helper.MakeDateTimeValid(row["NextVisitDate"]) < DateAndTime.Now.AddDays(9) & (Entity.Sys.Helper.MakeStringValid(row["Type"]) ?? "") == "Letter 3")
            {
                brush = Brushes.Red;
            }
            else
            {
                brush = Brushes.White;
            }

            // color the row cell
            var rect = bounds;
            g.FillRectangle(brush, rect);
            string strDate;
            strDate = Strings.Format(Entity.Sys.Helper.MakeDateTimeValid(row["NextVisitDate"]), "dddd dd/MM/yyyy");
            g.DrawString(strDate, DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}