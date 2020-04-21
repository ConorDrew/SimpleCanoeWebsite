using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class ColourColumn : DataGridLabelColumn
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            // set the color required dependant on the column value
            Brush brush;
            string str = "";
            brush = Brushes.White;
            var switchExpr = MappingName.ToString();
            var dr = (DataRowView)source.List[rowNum];
            switch (switchExpr)
            {
                case "PartsToFit":
                    {
                        if (Entity.Sys.Helper.MakeBooleanValid(dr[MappingName.ToString()]))
                        {
                            brush = Brushes.Orange;
                        }

                        if (Entity.Sys.Helper.MakeBooleanValid(dr["PartsNeedOrdering"]))
                        {
                            brush = Brushes.Purple;
                        }

                        TextBox.Text = "";
                        break;
                    }

                case "AllPartsReceived":
                    {
                        if (Entity.Sys.Helper.MakeBooleanValid(dr[MappingName.ToString()]))
                        {
                            brush = Brushes.Blue;
                        }

                        TextBox.Text = "";
                        break;
                    }
                    // Case "PartsNeedOrdering"
                    // If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item(Me.MappingName.ToString)) Then
                    // brush = Brushes.Purple
                    // End If
                    // Me.TextBox.Text = ""
            }
            // color the row cell
            var rect = bounds;
            g.FillRectangle(brush, rect);
            g.DrawString(str, DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}