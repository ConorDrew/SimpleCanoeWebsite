using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class Contract3AssetsColourColumnConvert : DataGridEditableTextBoxColumn
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private object _theUserControl;

        public object theUserControl
        {
            get
            {
                return _theUserControl;
            }

            set
            {
                _theUserControl = value;
            }
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            // set the color required dependant on the column value
            Brush brush;
            string str = "";
            if (string.IsNullOrEmpty(Entity.Sys.Helper.MakeStringValid(source.List[rowNum].row.item(MappingName.ToString()))))
            {
                str = "-";
                brush = Brushes.White;
                ReadOnly = true;
            }
            else
            {
                brush = Brushes.Yellow;
                str = Entity.Sys.Helper.MakeStringValid(source.List[rowNum].row.item(MappingName.ToString()));
                ReadOnly = false;
                TextBox.TextChanged += ValidateAssetDuration;
                TextBox.TextChanged += SaveDuration;
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

        private void SaveDuration(object sender, EventArgs e)
        {
            ((UCQuoteContractOption3Convert)theUserControl).UpdateDurations(Entity.Sys.Helper.MakeDoubleValid(((TextBox)sender).Text), Conversions.ToDate("01" + MappingName.ToString()));  // , assetId)
        }


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}