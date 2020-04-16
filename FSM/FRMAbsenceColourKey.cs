// Decompiled with JetBrains decompiler
// Type: FSM.FRMAbsenceColourKey
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMAbsenceColourKey : Form
  {
    private IContainer components;

    public FRMAbsenceColourKey()
    {
      this.Load += new EventHandler(this.FRMAbsenceColourKey_Load);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.dgAbsences = new DataGrid();
      this.dgAbsences.BeginInit();
      this.SuspendLayout();
      this.dgAbsences.AllowNavigation = false;
      this.dgAbsences.AlternatingBackColor = Color.GhostWhite;
      this.dgAbsences.BackgroundColor = Color.White;
      this.dgAbsences.BorderStyle = BorderStyle.FixedSingle;
      this.dgAbsences.CaptionBackColor = Color.RoyalBlue;
      this.dgAbsences.CaptionForeColor = Color.White;
      this.dgAbsences.CaptionVisible = false;
      this.dgAbsences.DataMember = "";
      this.dgAbsences.Dock = DockStyle.Fill;
      this.dgAbsences.Font = new Font("Verdana", 8f);
      this.dgAbsences.ForeColor = Color.MidnightBlue;
      this.dgAbsences.GridLineColor = Color.RoyalBlue;
      this.dgAbsences.HeaderBackColor = Color.MidnightBlue;
      this.dgAbsences.HeaderFont = new Font("Tahoma", 8f, FontStyle.Bold);
      this.dgAbsences.HeaderForeColor = Color.Lavender;
      this.dgAbsences.LinkColor = Color.Teal;
      this.dgAbsences.Location = new System.Drawing.Point(0, 0);
      this.dgAbsences.Name = "dgAbsences";
      this.dgAbsences.ParentRowsBackColor = Color.Lavender;
      this.dgAbsences.ParentRowsForeColor = Color.MidnightBlue;
      this.dgAbsences.ParentRowsVisible = false;
      this.dgAbsences.RowHeadersVisible = false;
      this.dgAbsences.SelectionBackColor = Color.Teal;
      this.dgAbsences.SelectionForeColor = Color.PaleGreen;
      this.dgAbsences.Size = new Size(292, 266);
      this.dgAbsences.TabIndex = 8;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(292, 266);
      this.Controls.Add((Control) this.dgAbsences);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (FRMAbsenceColourKey);
      this.Text = "Absence Colour Key";
      this.dgAbsences.EndInit();
      this.ResumeLayout(false);
    }

    internal virtual DataGrid dgAbsences { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void FRMAbsenceColourKey_Load(object sender, EventArgs e)
    {
      this.setUpDg();
      this.dgAbsences.DataSource = (object) App.DB.EngineerAbsence.EngineerAbsenceTypes_GetAll();
    }

    private void setUpDg()
    {
      ModScheduler.SetUpSchedulerDataGrid(this.dgAbsences, false);
      DataGridTableStyle tableStyle = this.dgAbsences.TableStyles[0];
      frmEngineerSchedule.unavailableBar unavailableBar = new frmEngineerSchedule.unavailableBar();
      unavailableBar.Format = "";
      unavailableBar.FormatInfo = (IFormatProvider) null;
      unavailableBar.HeaderText = "Colour";
      unavailableBar.MappingName = "AbsenceColumn";
      unavailableBar.ReadOnly = true;
      unavailableBar.Width = 60;
      unavailableBar.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unavailableBar);
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.MappingName = "Description";
      dataGridLabelColumn.HeaderText = "Absence Type";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Alignment = HorizontalAlignment.Center;
      dataGridLabelColumn.Width = 100;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.MappingName = "tblEngineerAbsenceTypes";
    }
  }
}
