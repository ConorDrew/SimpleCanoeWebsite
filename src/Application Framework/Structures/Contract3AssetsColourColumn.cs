using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class Contract3AssetsColourColumn : DataGridEditableTextBoxColumn
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            // set the color required dependant on the column value
            Brush brush;
            string str = "";
            var dr = (DataRowView)source.List[rowNum];
            if (string.IsNullOrEmpty(Entity.Sys.Helper.MakeStringValid(dr[MappingName.ToString()])))
            {
                str = "-";
                brush = Brushes.White;
                ReadOnly = true;
            }
            else
            {
                brush = Brushes.Yellow;
                str = Entity.Sys.Helper.MakeStringValid(dr[MappingName.ToString()]);
                ReadOnly = false;
                TextBox.TextChanged += ValidateAssetDuration;
            }
            // color the row cell
            var rect = bounds;
            g.FillRectangle(brush, rect);
            g.DrawString(str, DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        private void ValidateAssetDuration(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(((TextBox)sender).Text) & ((TextBox)sender).Text.Trim().Length > 0)
            {
                ((TextBox)sender).Text = 0.ToString();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}