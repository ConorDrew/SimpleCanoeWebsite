using System;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    static class ModScheduler
    {
        
        // Set the format and data
        public static void SetUpSchedulerDataGrid(DataGrid dg, bool captionIsVisible = false)
        {
            dg.TableStyles.Clear();
            dg.TableStyles.Add(DefaultSchedulerTableStyle());
            dg.AllowNavigation = false;
            dg.CaptionVisible = captionIsVisible;
            dg.AlternatingBackColor = Color.GhostWhite;
            dg.BackgroundColor = Color.White;
            dg.BorderStyle = BorderStyle.FixedSingle;
            dg.CaptionBackColor = Color.RoyalBlue;
            dg.CaptionForeColor = Color.White;
            dg.Font = new Font("Verdana", 8.0F);
            dg.ForeColor = Color.MidnightBlue;
            dg.GridLineColor = Color.RoyalBlue;
            dg.HeaderBackColor = Color.MidnightBlue;
            dg.HeaderFont = new Font("Verdana", 8.0F, FontStyle.Bold);
            dg.HeaderForeColor = Color.Lavender;
            dg.LinkColor = Color.Teal;
            dg.ParentRowsBackColor = Color.Lavender;
            dg.ParentRowsForeColor = Color.MidnightBlue;
            dg.ParentRowsVisible = false;
            dg.RowHeadersVisible = false;
            dg.SelectionBackColor = Color.Teal;
            dg.SelectionForeColor = Color.PaleGreen;
            dg.ReadOnly = true;
            dg.Click += dGrid_Multievents;
            dg.CurrentCellChanged += dGrid_Multievents;
        }

        // Fire the events required
        public static void dGrid_Multievents(object sender, EventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.ReadOnly)
            {
                if (dg.CurrentCell.ColumnNumber > -1 & dg.CurrentRowIndex > -1)
                {
                    dg.CurrentCell = new DataGridCell(dg.CurrentRowIndex, -1);
                    dg.Select(dg.CurrentRowIndex);
                }
            }
        }

        // Set the style
        public static DataGridTableStyle DefaultSchedulerTableStyle()
        {
            var DataGridTableStyle1 = new DataGridTableStyle();
            DataGridTableStyle1.AlternatingBackColor = Color.GhostWhite;
            DataGridTableStyle1.BackColor = Color.GhostWhite;
            DataGridTableStyle1.ForeColor = Color.MidnightBlue;
            DataGridTableStyle1.GridLineColor = Color.RoyalBlue;
            DataGridTableStyle1.HeaderBackColor = Color.MidnightBlue;
            DataGridTableStyle1.HeaderForeColor = Color.Lavender;
            DataGridTableStyle1.LinkColor = Color.Teal;
            DataGridTableStyle1.MappingName = "";
            DataGridTableStyle1.ReadOnly = true;
            DataGridTableStyle1.RowHeadersVisible = false;
            DataGridTableStyle1.SelectionBackColor = Color.LightSteelBlue;
            DataGridTableStyle1.SelectionForeColor = Color.MidnightBlue;
            DataGridTableStyle1.PreferredRowHeight = 10;
            return DataGridTableStyle1;
        }

        
    }
}