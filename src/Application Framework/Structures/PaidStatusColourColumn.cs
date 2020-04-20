using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class PaidStatusColourColumn : DataGridLabelColumn
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            // set the color required dependant on the column value
            var brush = default(Brush);
            var switchExpr = Entity.Sys.Helper.MakeIntegerValid(source.List[rowNum].row.item("PaidStatus"));
            switch (switchExpr)
            {
                case -2:
                    {
                        brush = Brushes.White;
                        break;
                    }

                case -1:
                    {
                        brush = Brushes.Red;
                        break;
                    }

                case 0:
                    {
                        brush = Brushes.Gold;
                        break;
                    }

                case 1:
                    {
                        brush = Brushes.LightGreen;
                        break;
                    }
            }

            // color the row cell
            var rect = bounds;
            g.FillRectangle(brush, rect);
            g.DrawString("", DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}