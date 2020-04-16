// Decompiled with JetBrains decompiler
// Type: FSM.FRMSchedulerSettings
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Settings.Scheduler;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMSchedulerSettings : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvJobTypeColour;

    public FRMSchedulerSettings()
    {
      this.Load += new EventHandler(this.FRMUserSettings_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpJobTypeColours { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveJobColour
    {
      get
      {
        return this._btnSaveJobColour;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveJobColour_Click);
        Button btnSaveJobColour1 = this._btnSaveJobColour;
        if (btnSaveJobColour1 != null)
          btnSaveJobColour1.Click -= eventHandler;
        this._btnSaveJobColour = value;
        Button btnSaveJobColour2 = this._btnSaveJobColour;
        if (btnSaveJobColour2 == null)
          return;
        btnSaveJobColour2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeleteJobColour
    {
      get
      {
        return this._btnDeleteJobColour;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteJobColour_Click);
        Button btnDeleteJobColour1 = this._btnDeleteJobColour;
        if (btnDeleteJobColour1 != null)
          btnDeleteJobColour1.Click -= eventHandler;
        this._btnDeleteJobColour = value;
        Button btnDeleteJobColour2 = this._btnDeleteJobColour;
        if (btnDeleteJobColour2 == null)
          return;
        btnDeleteJobColour2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboColour
    {
      get
      {
        return this._cboColour;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cboColour_DrawItem);
        ComboBox cboColour1 = this._cboColour;
        if (cboColour1 != null)
          cboColour1.DrawItem -= itemEventHandler;
        this._cboColour = value;
        ComboBox cboColour2 = this._cboColour;
        if (cboColour2 == null)
          return;
        cboColour2.DrawItem += itemEventHandler;
      }
    }

    internal virtual Label lblColour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgJobTypeColours { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobTypeColours = new GroupBox();
      this.btnSaveJobColour = new Button();
      this.btnDeleteJobColour = new Button();
      this.cboColour = new ComboBox();
      this.lblColour = new Label();
      this.cboJobType = new ComboBox();
      this.lblJobType = new Label();
      this.dgJobTypeColours = new DataGrid();
      this.btnClose = new Button();
      this.grpJobTypeColours.SuspendLayout();
      this.dgJobTypeColours.BeginInit();
      this.SuspendLayout();
      this.grpJobTypeColours.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpJobTypeColours.Controls.Add((Control) this.btnSaveJobColour);
      this.grpJobTypeColours.Controls.Add((Control) this.btnDeleteJobColour);
      this.grpJobTypeColours.Controls.Add((Control) this.cboColour);
      this.grpJobTypeColours.Controls.Add((Control) this.lblColour);
      this.grpJobTypeColours.Controls.Add((Control) this.cboJobType);
      this.grpJobTypeColours.Controls.Add((Control) this.lblJobType);
      this.grpJobTypeColours.Controls.Add((Control) this.dgJobTypeColours);
      this.grpJobTypeColours.Location = new System.Drawing.Point(12, 57);
      this.grpJobTypeColours.Name = "grpJobTypeColours";
      this.grpJobTypeColours.Size = new Size(316, 536);
      this.grpJobTypeColours.TabIndex = 1;
      this.grpJobTypeColours.TabStop = false;
      this.grpJobTypeColours.Text = "Job Type Colours";
      this.btnSaveJobColour.AccessibleDescription = "Save item";
      this.btnSaveJobColour.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveJobColour.Cursor = Cursors.Hand;
      this.btnSaveJobColour.ImageIndex = 1;
      this.btnSaveJobColour.Location = new System.Drawing.Point(7, 506);
      this.btnSaveJobColour.Name = "btnSaveJobColour";
      this.btnSaveJobColour.Size = new Size(94, 24);
      this.btnSaveJobColour.TabIndex = 9;
      this.btnSaveJobColour.Text = "Save";
      this.btnSaveJobColour.UseVisualStyleBackColor = true;
      this.btnDeleteJobColour.AccessibleDescription = "Save item";
      this.btnDeleteJobColour.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnDeleteJobColour.Cursor = Cursors.Hand;
      this.btnDeleteJobColour.ImageIndex = 1;
      this.btnDeleteJobColour.Location = new System.Drawing.Point(215, 506);
      this.btnDeleteJobColour.Name = "btnDeleteJobColour";
      this.btnDeleteJobColour.Size = new Size(93, 24);
      this.btnDeleteJobColour.TabIndex = 8;
      this.btnDeleteJobColour.Text = "Delete";
      this.btnDeleteJobColour.UseVisualStyleBackColor = true;
      this.cboColour.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboColour.DrawMode = DrawMode.OwnerDrawFixed;
      this.cboColour.FormattingEnabled = true;
      this.cboColour.Location = new System.Drawing.Point(85, 50);
      this.cboColour.Name = "cboColour";
      this.cboColour.Size = new Size(223, 22);
      this.cboColour.TabIndex = 7;
      this.lblColour.AutoSize = true;
      this.lblColour.Location = new System.Drawing.Point(10, 54);
      this.lblColour.Name = "lblColour";
      this.lblColour.Size = new Size(45, 13);
      this.lblColour.TabIndex = 6;
      this.lblColour.Text = "Colour";
      this.cboJobType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboJobType.FormattingEnabled = true;
      this.cboJobType.Location = new System.Drawing.Point(85, 20);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(223, 21);
      this.cboJobType.TabIndex = 5;
      this.lblJobType.AutoSize = true;
      this.lblJobType.Location = new System.Drawing.Point(10, 25);
      this.lblJobType.Name = "lblJobType";
      this.lblJobType.Size = new Size(57, 13);
      this.lblJobType.TabIndex = 4;
      this.lblJobType.Text = "Job Type";
      this.dgJobTypeColours.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgJobTypeColours.DataMember = "";
      this.dgJobTypeColours.HeaderForeColor = SystemColors.ControlText;
      this.dgJobTypeColours.Location = new System.Drawing.Point(7, 92);
      this.dgJobTypeColours.Name = "dgJobTypeColours";
      this.dgJobTypeColours.Size = new Size(301, 408);
      this.dgJobTypeColours.TabIndex = 2;
      this.btnClose.AccessibleDescription = "Save item";
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Cursor = Cursors.Hand;
      this.btnClose.ImageIndex = 1;
      this.btnClose.Location = new System.Drawing.Point(12, 599);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(68, 26);
      this.btnClose.TabIndex = 4;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.BackColor = Color.White;
      this.ClientSize = new Size(690, 636);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.grpJobTypeColours);
      this.MinimumSize = new Size(706, 675);
      this.Name = nameof (FRMSchedulerSettings);
      this.Text = "Settings";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpJobTypeColours, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.grpJobTypeColours.ResumeLayout(false);
      this.grpJobTypeColours.PerformLayout();
      this.dgJobTypeColours.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    private DataView DvJobTypeColour
    {
      get
      {
        return this._dvJobTypeColour;
      }
      set
      {
        this._dvJobTypeColour = value;
        this._dvJobTypeColour.Table.TableName = "JobTypeColour";
        this.dgJobTypeColours.DataSource = (object) this.DvJobTypeColour;
      }
    }

    private DataRow DrSelectedJobTypeColour
    {
      get
      {
        return this.dgJobTypeColours.CurrentRowIndex != -1 ? this.DvJobTypeColour[this.dgJobTypeColours.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void FRMUserSettings_Load(object sender, EventArgs e)
    {
      ComboBox cboJobType = this.cboJobType;
      Combo.SetUpCombo(ref cboJobType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobType = cboJobType;
      this.SetUpColourCombo();
      this.SetupDgJobColours();
      this.PopulateJobTypeColours();
    }

    private void cboColour_DrawItem(object sender, DrawItemEventArgs e)
    {
      Graphics graphics = e.Graphics;
      Rectangle bounds = e.Bounds;
      if (e.Index < 0)
        return;
      string str = ((ComboBox) sender).Items[e.Index].ToString();
      Font font = new Font("Arial", 9f, FontStyle.Regular);
      Brush brush = (Brush) new SolidBrush(Color.FromName(str));
      graphics.DrawString(str, font, Brushes.Black, (float) bounds.X, (float) bounds.Top);
      graphics.FillRectangle(brush, checked (bounds.X + 110), checked (bounds.Y + 5), checked (bounds.Width - 10), checked (bounds.Height - 10));
    }

    private void btnSaveJobColour_Click(object sender, EventArgs e)
    {
      this.SaveJobTypeColour();
    }

    private void btnDeleteJobColour_Click(object sender, EventArgs e)
    {
      this.DeleteJobTypeColour();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void PopulateJobTypeColours()
    {
      this.SetupDgJobColours();
      this.DvJobTypeColour = new DataView(Helper.ToDataTable<JobTypeColour>((IList<JobTypeColour>) App.DB.JobTypeColour.Get_All()));
    }

    public void SaveJobTypeColour()
    {
      try
      {
        int num = Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboJobType));
        if (num == 0 | this.cboColour.SelectedIndex == 0)
          return;
        string Right = Conversions.ToString(this.cboColour.SelectedItem);
        List<JobTypeColour> source = App.DB.JobTypeColour.Get_All();
        if (source != null)
          source = source.Where<JobTypeColour>((Func<JobTypeColour, bool>) (x => x.JobTypeId == num | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(x.Colour, Right, false) == 0)).ToList<JobTypeColour>();
        if (source != null && source.Count > 0)
        {
          int num1 = (int) App.ShowMessage(source.FirstOrDefault<JobTypeColour>().JobType + " has a link to " + source.FirstOrDefault<JobTypeColour>().Colour + "!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          this.ResetJobTypeColour();
        }
        else
        {
          JobTypeColour userJobTypeColour = new JobTypeColour()
          {
            JobTypeId = num,
            Colour = Right
          };
          if (App.DB.JobTypeColour.Insert(userJobTypeColour).Id > 0)
            this.ResetJobTypeColour();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void DeleteJobTypeColour()
    {
      if (this.DrSelectedJobTypeColour == null)
      {
        int num1 = (int) App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
          return;
        try
        {
          Cursor.Current = Cursors.WaitCursor;
          App.DB.JobTypeColour.Delete(Conversions.ToInteger(this.DrSelectedJobTypeColour["Id"]));
          this.ResetJobTypeColour();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage("Error deleting: \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Cursor.Current = Cursors.Default;
        }
      }
    }

    public void ResetJobTypeColour()
    {
      this.PopulateJobTypeColours();
      ComboBox cboJobType = this.cboJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboJobType, Conversions.ToString(0));
      this.cboJobType = cboJobType;
      this.cboColour.SelectedIndex = 0;
    }

    public void SetUpColourCombo()
    {
      this.cboColour.Items.Clear();
      this.cboColour.Items.Add((object) "-- Please Select --");
      ArrayList arrayList = new ArrayList();
      PropertyInfo[] properties = typeof (Color).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
      int index = 0;
      while (index < properties.Length)
      {
        this.cboColour.Items.Add((object) properties[index].Name);
        checked { ++index; }
      }
      this.cboColour.DisplayMember = "Description";
      this.cboColour.ValueMember = "Value";
      this.cboColour.SelectedIndex = 0;
    }

    private void SetupDgJobColours()
    {
      Helper.SetUpDataGrid(this.dgJobTypeColours, false);
      DataGridTableStyle tableStyle = this.dgJobTypeColours.TableStyles[0];
      DataGridJobTypeColumn gridJobTypeColumn1 = new DataGridJobTypeColumn();
      gridJobTypeColumn1.Format = "";
      gridJobTypeColumn1.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn1.HeaderText = "Job Type";
      gridJobTypeColumn1.MappingName = "JobType";
      gridJobTypeColumn1.ReadOnly = true;
      gridJobTypeColumn1.Width = 145;
      gridJobTypeColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn1);
      DataGridJobTypeColumn gridJobTypeColumn2 = new DataGridJobTypeColumn();
      gridJobTypeColumn2.Format = "";
      gridJobTypeColumn2.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn2.HeaderText = "Colour";
      gridJobTypeColumn2.MappingName = "Colour";
      gridJobTypeColumn2.ReadOnly = true;
      gridJobTypeColumn2.Width = 100;
      gridJobTypeColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = "JobTypeColour";
      this.dgJobTypeColours.TableStyles.Add(tableStyle);
    }
  }
}
