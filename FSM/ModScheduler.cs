// Decompiled with JetBrains decompiler
// Type: FSM.ModScheduler
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
  [StandardModule]
  internal sealed class ModScheduler
  {
    public static void SetUpSchedulerDataGrid(DataGrid dg, bool captionIsVisible = false)
    {
      dg.TableStyles.Clear();
      dg.TableStyles.Add(ModScheduler.DefaultSchedulerTableStyle());
      dg.AllowNavigation = false;
      dg.CaptionVisible = captionIsVisible;
      dg.AlternatingBackColor = Color.GhostWhite;
      dg.BackgroundColor = Color.White;
      dg.BorderStyle = BorderStyle.FixedSingle;
      dg.CaptionBackColor = Color.RoyalBlue;
      dg.CaptionForeColor = Color.White;
      dg.Font = new Font("Verdana", 8f);
      dg.ForeColor = Color.MidnightBlue;
      dg.GridLineColor = Color.RoyalBlue;
      dg.HeaderBackColor = Color.MidnightBlue;
      dg.HeaderFont = new Font("Verdana", 8f, FontStyle.Bold);
      dg.HeaderForeColor = Color.Lavender;
      dg.LinkColor = Color.Teal;
      dg.ParentRowsBackColor = Color.Lavender;
      dg.ParentRowsForeColor = Color.MidnightBlue;
      dg.ParentRowsVisible = false;
      dg.RowHeadersVisible = false;
      dg.SelectionBackColor = Color.Teal;
      dg.SelectionForeColor = Color.PaleGreen;
      dg.ReadOnly = true;
      dg.Click += new EventHandler(ModScheduler.dGrid_Multievents);
      dg.CurrentCellChanged += new EventHandler(ModScheduler.dGrid_Multievents);
    }

    public static void dGrid_Multievents(object sender, EventArgs e)
    {
      DataGrid dataGrid = (DataGrid) sender;
      if (!dataGrid.ReadOnly || !(dataGrid.CurrentCell.ColumnNumber > -1 & dataGrid.CurrentRowIndex > -1))
        return;
      dataGrid.CurrentCell = new DataGridCell(dataGrid.CurrentRowIndex, -1);
      dataGrid.Select(dataGrid.CurrentRowIndex);
    }

    public static DataGridTableStyle DefaultSchedulerTableStyle()
    {
      return new DataGridTableStyle()
      {
        AlternatingBackColor = Color.GhostWhite,
        BackColor = Color.GhostWhite,
        ForeColor = Color.MidnightBlue,
        GridLineColor = Color.RoyalBlue,
        HeaderBackColor = Color.MidnightBlue,
        HeaderForeColor = Color.Lavender,
        LinkColor = Color.Teal,
        MappingName = "",
        ReadOnly = true,
        RowHeadersVisible = false,
        SelectionBackColor = Color.LightSteelBlue,
        SelectionForeColor = Color.MidnightBlue,
        PreferredRowHeight = 10
      };
    }
  }
}
