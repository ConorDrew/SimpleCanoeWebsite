using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class JobCompletedIn1Column : DataGridLabelColumn
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            // set the color required dependant on the column value
            Brush brush;
            DataRowView row = (DataRowView)source.List[rowNum];
            var switchExpr = Entity.Sys.Helper.MakeStringValid(row["VisitCompletedInOne"]);
            switch (switchExpr)
            {
                case "Yes":
                    {
                        brush = Brushes.LightGreen;
                        break;
                    }

                case "No":
                    {
                        brush = Brushes.Salmon;
                        break;
                    }

                default:
                    {
                        brush = Brushes.White;
                        break;
                    }
            }

            // color the row cell
            var rect = bounds;
            g.FillRectangle(brush, rect);
            g.DrawString(Entity.Sys.Helper.MakeStringValid(row["VisitCompletedInOne"]), DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}