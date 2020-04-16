// Decompiled with JetBrains decompiler
// Type: FSM.FRMBookJob
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Pabo.Calendar;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMBookJob : Form
  {
    private IContainer components;
    public DataRow dr;
    public DateTime Max;
    public DataTable dt;
    private DateTime Min;

    public FRMBookJob()
    {
      this.Load += new EventHandler(this.FRMChangePriority_Load);
      this.dr = (DataRow) null;
      this.Max = DateTime.MaxValue;
      this.dt = new DataTable();
      this.Min = DateAndTime.Today.AddDays(1.0);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMBookJob));
      this.GroupBox1 = new GroupBox();
      this.Label4 = new Label();
      this.txtEngineernotes = new TextBox();
      this.lblMessage = new Label();
      this.dtpDate = new Pabo.Calendar.MonthCalendar();
      this.Label2 = new Label();
      this.cboAppointment = new ComboBox();
      this.Button1 = new Button();
      this.Label3 = new Label();
      this.Label1 = new Label();
      this.btnOK = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.txtEngineernotes);
      this.GroupBox1.Controls.Add((Control) this.lblMessage);
      this.GroupBox1.Controls.Add((Control) this.dtpDate);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.cboAppointment);
      this.GroupBox1.Controls.Add((Control) this.Button1);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Location = new System.Drawing.Point(5, 1);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(505, 421);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(19, 333);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(145, 13);
      this.Label4.TabIndex = 14;
      this.Label4.Text = "Additional Notes To Engineer";
      this.txtEngineernotes.Location = new System.Drawing.Point(170, 330);
      this.txtEngineernotes.Multiline = true;
      this.txtEngineernotes.Name = "txtEngineernotes";
      this.txtEngineernotes.Size = new Size(226, 51);
      this.txtEngineernotes.TabIndex = 13;
      this.lblMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.lblMessage.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessage.ForeColor = Color.Maroon;
      this.lblMessage.Location = new System.Drawing.Point(7, 241);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(492, 24);
      this.lblMessage.TabIndex = 12;
      this.lblMessage.TextAlign = ContentAlignment.TopCenter;
      this.dtpDate.ActiveMonth.Month = 5;
      this.dtpDate.ActiveMonth.Year = 2017;
      this.dtpDate.Culture = new CultureInfo("en-GB");
      this.dtpDate.Footer.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.dtpDate.Header.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.dtpDate.Header.TextColor = Color.White;
      this.dtpDate.ImageList = (ImageList) null;
      this.dtpDate.Location = new System.Drawing.Point(170, 43);
      this.dtpDate.MaxDate = new DateTime(2027, 5, 10, 12, 28, 13, 983);
      this.dtpDate.MinDate = new DateTime(2007, 5, 10, 12, 28, 13, 983);
      this.dtpDate.Month.BackgroundImage = (Image) null;
      this.dtpDate.Month.DateFont = new Font("Microsoft Sans Serif", 8.25f);
      this.dtpDate.Month.TextFont = new Font("Microsoft Sans Serif", 8.25f);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.SelectionMode = mcSelectionMode.One;
      this.dtpDate.Size = new Size(225, 195);
      this.dtpDate.TabIndex = 11;
      this.dtpDate.Weekdays.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.dtpDate.Weeknumbers.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(93, 282);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(66, 13);
      this.Label2.TabIndex = 10;
      this.Label2.Text = "Appointment";
      this.cboAppointment.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAppointment.FormattingEnabled = true;
      this.cboAppointment.Location = new System.Drawing.Point(170, 277);
      this.cboAppointment.Name = "cboAppointment";
      this.cboAppointment.Size = new Size(226, 21);
      this.cboAppointment.TabIndex = 8;
      this.Button1.UseVisualStyleBackColor = true;
      this.Button1.Location = new System.Drawing.Point(7, 392);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 7;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.Label3.AutoSize = true;
      this.Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.ForeColor = Color.Maroon;
      this.Label3.Location = new System.Drawing.Point(184, 16);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(186, 16);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Please select an Appointment";
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(93, 55);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(30, 13);
      this.Label1.TabIndex = 3;
      this.Label1.Text = "Date";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Location = new System.Drawing.Point(424, 392);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "Proceed";
      this.btnOK.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(513, 434);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MinimumSize = new Size(529, 393);
      this.Name = nameof (FRMBookJob);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Book Appointment";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        Button btnOk1 = this._btnOK;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOK = value;
        Button btnOk2 = this._btnOK;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAppointment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Pabo.Calendar.MonthCalendar dtpDate
    {
      get
      {
        return this._dtpDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        DayClickEventHandler clickEventHandler = new DayClickEventHandler(this.dtpDate_MonthChanged);
        Pabo.Calendar.MonthCalendar dtpDate1 = this._dtpDate;
        if (dtpDate1 != null)
          dtpDate1.DayClick -= clickEventHandler;
        this._dtpDate = value;
        Pabo.Calendar.MonthCalendar dtpDate2 = this._dtpDate;
        if (dtpDate2 == null)
          return;
        dtpDate2.DayClick += clickEventHandler;
      }
    }

    internal virtual Label lblMessage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEngineernotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) == 0.0)
      {
        int num1 = (int) App.ShowMessage("Please select an AM or PM appointment ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.dtpDate.SelectedDates.Count == 0)
      {
        int num2 = (int) App.ShowMessage("Please select a Date ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMChangePriority_Load(object sender, EventArgs e)
    {
      ComboBox cboAppointment = this.cboAppointment;
      Combo.SetUpCombo(ref cboAppointment, DynamicDataTables.Appointments, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboAppointment = cboAppointment;
      this.dtpDate.MaxDate = this.Max;
      this.dtpDate.MinDate = this.Min;
      this.dtpDate.SelectDate(DateAndTime.Today);
      this.dtpDate.ActiveMonth.Month = this.Min.Month;
      this.dtpDate.ActiveMonth.Year = this.Min.Year;
      DateItem[] info = new DateItem[checked ((int) Math.Round(unchecked ((double) this.dt.Rows.Count / 2.0)) + 1)];
      int index = 0;
      int num1 = 0;
      int num2 = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = this.dt.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["AMPM"], (object) "AM", false))
          {
            info[index] = new DateItem();
            num1 = 0;
            num2 = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, current["Avail"]));
            if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["Avail"], (object) 0, false))
              ;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InArea"], (object) 1, false))
              checked { ++num1; }
          }
          else
          {
            info[index].Date = Conversions.ToDate(current["Date"]);
            if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["Avail"], (object) 0, false))
              ;
            int integer = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, current["Avail"]));
            if (integer == 0)
              info[index].BackColor1 = Color.Red;
            else if (integer > 10)
              info[index].BackColor1 = Color.Yellow;
            else if (integer > 2)
              info[index].BackColor1 = Color.Orange;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InArea"], (object) 1, false))
              checked { ++num1; }
            if (num1 > 0)
              info[index].BackColor1 = Color.Green;
            num2 = 0;
            checked { ++index; }
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.dtpDate.AddDateInfo(info);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      ComboBox cboAppointment = this.cboAppointment;
      Combo.SetSelectedComboItem_By_Value(ref cboAppointment, "0");
      this.cboAppointment = cboAppointment;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void dtpDate_MonthChanged(object sender, DayClickEventArgs e)
    {
      DataRow[] dataRowArray1 = this.dt.Select("Date = '" + Conversions.ToDate(e.Date).ToString("dd/MM/yyyy") + " 00:00:00' AND Avail > 0");
      this.lblMessage.Text = dataRowArray1.Length <= 1 ? (dataRowArray1.Length <= 0 || !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRowArray1[0]["AMPM"], (object) "AM", false) ? (dataRowArray1.Length <= 0 || !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRowArray1[0]["AMPM"], (object) "PM", false) ? "No Suggested Appointments available on this day" : "PM Available") : "AM Available") : "AM and PM Available";
      DataRow[] dataRowArray2 = this.dt.Select("Date = '" + Conversions.ToDate(e.Date).ToString("dd/MM/yyyy") + " 00:00:00' AND InArea = 1");
      if (dataRowArray2.Length > 1)
        this.lblMessage.Text = "Engineer in this area AM and PM";
      else if (dataRowArray2.Length > 0 && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRowArray2[0]["AMPM"], (object) "AM", false))
      {
        this.lblMessage.Text = "Engineer in this area AM";
        if (!Conversions.ToBoolean((object) (bool) (dataRowArray1.Length <= 0 ? 0 : (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowArray1[0]["AMPM"], (object) "PM", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRowArray1[1]["AMPM"], (object) "PM", false))) ? 1 : 0))))
          return;
        Label lblMessage;
        string str = (lblMessage = this.lblMessage).Text + ", PM is also Available but no close engineer";
        lblMessage.Text = str;
      }
      else
      {
        if (dataRowArray2.Length <= 0 || !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRowArray2[0]["AMPM"], (object) "PM", false))
          return;
        this.lblMessage.Text = "Engineer in this area PM";
        if (dataRowArray1.Length <= 0 || !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRowArray1[0]["AMPM"], (object) "AM", false))
          return;
        Label lblMessage;
        string str = (lblMessage = this.lblMessage).Text + ", AM is also Available but no close engineer";
        lblMessage.Text = str;
      }
    }
  }
}
