﻿using Microsoft.VisualBasic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class DataGridSiteFuelColumn : DataGridLabelColumn
    {
        

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            // Need to get row information from data
            DataRowView row = (DataRowView)source.List[rowNum];

            // check for row before we call it
            if (row.DataView.Table.Columns.Contains("LastServiceDate"))
            {
                var lsd = Entity.Sys.Helper.MakeDateTimeValid(row["LastServiceDate"]);
                if (lsd != default && lsd > System.Data.SqlTypes.SqlDateTime.MinValue.Value.AddYears(1))
                {
                    if (lsd <= DateAndTime.Now.AddDays(-365))
                    {
                        backBrush = Brushes.Black;
                        foreBrush = Brushes.Yellow;
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-352) & lsd > DateAndTime.Now.AddDays(-365))
                    {
                        backBrush = Brushes.Red;
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-330) & lsd > DateAndTime.Now.AddDays(-352))
                    {
                        backBrush = Brushes.Orange;
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-309) & lsd > DateAndTime.Now.AddDays(-330))
                    {
                        backBrush = Brushes.Yellow;
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-281) & lsd > DateAndTime.Now.AddDays(-309))
                    {
                        backBrush = Brushes.PaleGreen;
                    }
                    else
                    {
                        backBrush = backBrush;
                    }
                }
            }

            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }

        
    }
}