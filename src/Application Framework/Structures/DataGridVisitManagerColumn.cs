using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class DataGridVisitManagerColumn : DataGridLabelColumn
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);

            // Need to get row information from data
            DataRow row = (DataRow)source.List[rowNum].row;

            // check for row before we call it
            bool chargable = false;
            if (row.Table.Columns.Contains("VisitChargeable"))
            {
                var switchExpr = Entity.Sys.Helper.MakeIntegerValid(row["VisitChargeable"]);
                switch (switchExpr)
                {
                    case Conversions.ToInteger(Entity.Sys.Enums.TabletYesNoNA.Yes):
                        {
                            backBrush = Brushes.Yellow;
                            break;
                        }

                    case Conversions.ToInteger(Entity.Sys.Enums.TabletYesNoNA.No):
                        {
                            backBrush = Brushes.LightGreen;
                            break;
                        }

                    default:
                        {
                            backBrush = backBrush;
                            break;
                        }
                }
            }

            var rect = bounds;
            g.FillRectangle(backBrush, rect);
            g.DrawString("", DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}