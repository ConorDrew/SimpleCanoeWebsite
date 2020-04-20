using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class ImporterLabelColumn : DataGridTextBoxColumn
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText)
        {
        }

        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)
        {
        }

        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly)
        {
        }

        private string _ColumnName;

        public string ColumnName
        {
            get
            {
                return _ColumnName;
            }

            set
            {
                _ColumnName = value;
            }
        }

        public ImporterLabelColumn(string ColumnNameIn)
        {
            ColumnName = ColumnNameIn;
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            var rect = bounds;
            try
            {
                if (Conversions.ToBoolean(source.List[rowNum].row.item(ColumnName + "COLOURBOOLEANCOLUMN")))
                {
                    g.FillRectangle(Brushes.Red, rect);
                }
                else
                {
                    g.FillRectangle(Brushes.White, rect);
                }
            }
            catch
            {
                g.FillRectangle(Brushes.White, rect);
            }

            g.DrawString(Entity.Sys.Helper.MakeStringValid(source.List[rowNum].row.item(ColumnName)), DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}