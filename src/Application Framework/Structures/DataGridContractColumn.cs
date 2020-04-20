﻿using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class DataGridContractColumn : DataGridLabelColumn
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {

            // Need to get row information from data
            DataRow row = (DataRow)source.List[rowNum].row;

            // check for row before we call it
            bool renewed = false;
            if (row.Table.Columns.Contains("Renewed"))
            {
                var switchExpr = Entity.Sys.Helper.MakeStringValid(row["Renewed"]);
                switch (switchExpr)
                {
                    case "Renewed":
                        {
                            renewed = true;
                            break;
                        }

                    case "Transfered":
                        {
                            renewed = true;
                            break;
                        }

                    default:
                        {
                            renewed = false;
                            break;
                        }
                }
            }

            bool contactMade = false;
            if (row.Table.Columns.Contains("ContactMade"))
            {
                contactMade = Entity.Sys.Helper.MakeBooleanValid(row["ContactMade"]);
            }

            if (!renewed & !contactMade)
            {
                backBrush = Brushes.Red;
            }
            else if (!renewed & contactMade)
            {
                backBrush = Brushes.Yellow;
            }
            else
            {
                backBrush = backBrush;
            }

            base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}