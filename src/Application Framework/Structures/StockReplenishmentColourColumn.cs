﻿using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class StockReplenishmentColourColumn : DataGridLabelColumn
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            // set the color required dependant on the column value
            Brush brush;
            brush = Brushes.LightGreen;

            DataRowView row = (DataRowView)source.List[rowNum];
            // IS THERE ANY ON ORDER?
            if (Entity.Sys.Helper.MakeIntegerValid(row["UnitsOnOrder"]) > 0 & Entity.Sys.Helper.MakeIntegerValid(row["UnitsOnOrder"]) + Entity.Sys.Helper.MakeIntegerValid(row["Amount"]) >= Entity.Sys.Helper.MakeIntegerValid(row["MinimumQuantity"]))

            {
                brush = Brushes.LightBlue;
            }
            else if (Entity.Sys.Helper.MakeIntegerValid(row["Amount"]) < Entity.Sys.Helper.MakeIntegerValid(row["MinimumQuantity"]))
            {
                brush = Brushes.Salmon;
            }
            else if (Entity.Sys.Helper.MakeIntegerValid(row["Amount"]) < Entity.Sys.Helper.MakeIntegerValid(row["RecommendedQuantity"]))
            {
                brush = Brushes.Yellow;
            }
            else
            {
                brush = Brushes.LightGreen;
            }
            // color the row cell
            var rect = bounds;
            g.FillRectangle(brush, rect);
            g.DrawString(Entity.Sys.Helper.MakeIntegerValid(row["Amount"]).ToString(), DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}