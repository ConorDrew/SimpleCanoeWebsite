using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class DataGridDistrictColumn : DataGridLabelColumn
    {
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {

            // Need to get row information from data
            DataRow row = (DataRow)source.List[rowNum].row;

            // check for row before we call it

            bool district = false;
            if (row.Table.Columns.Contains("CommercialDistrict"))
            {
                district = Entity.Sys.Helper.MakeBooleanValid(row["CommercialDistrict"]);
            }

            if (district)
            {
                backBrush = Brushes.Orange;
            }
            else
            {
                backBrush = backBrush;
            }

            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }
    }
}