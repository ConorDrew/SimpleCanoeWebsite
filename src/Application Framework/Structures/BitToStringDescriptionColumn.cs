using System;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class BitToStringDescriptionColumn : DataGridEditableTextBoxColumn
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            // set the color required dependant on the column value
            var brush = Brushes.White;
            string str = "";
            try
            {
            }
            // If CType([source].Current, DataRowView).Row.Item("EngineerVisitID") = Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("EngineerVisitID")) Then
            // brush = Brushes.Gainsboro
            // Else
            // brush = Brushes.White
            // End If
            catch (Exception ex)
            {
            }

            if (Entity.Sys.Helper.MakeBooleanValid(source.List[rowNum].row.item(MappingName.ToString())))
            {
                str = "Yes";
            }
            else
            {
                str = "No";
            }
            // color the row cell
            var rect = bounds;
            g.FillRectangle(brush, rect);
            g.DrawString(str, DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}