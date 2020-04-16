// Decompiled with JetBrains decompiler
// Type: FSM.FRMSiteLetterList
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMSiteLetterList : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvLetters;
    private string _selectedTemplate;

    public FRMSiteLetterList()
    {
      this.Load += new EventHandler(this.FRMSiteLetterList_Load);
      this._dvLetters = (DataView) null;
      this._selectedTemplate = "";
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
      this.GroupBox1 = new GroupBox();
      this.dgLetters = new DataGrid();
      this.btnSelect = new Button();
      this.GroupBox1.SuspendLayout();
      this.dgLetters.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.btnSelect);
      this.GroupBox1.Controls.Add((Control) this.dgLetters);
      this.GroupBox1.Location = new System.Drawing.Point(8, 40);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(512, 328);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Letters";
      this.dgLetters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgLetters.DataMember = "";
      this.dgLetters.HeaderForeColor = SystemColors.ControlText;
      this.dgLetters.Location = new System.Drawing.Point(8, 16);
      this.dgLetters.Name = "dgLetters";
      this.dgLetters.Size = new Size(496, 272);
      this.dgLetters.TabIndex = 2;
      this.btnSelect.Location = new System.Drawing.Point(424, 296);
      this.btnSelect.Name = "btnSelect";
      this.btnSelect.Size = new Size(75, 23);
      this.btnSelect.TabIndex = 3;
      this.btnSelect.Text = "Select";
      this.btnSelect.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(528, 382);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMSiteLetterList);
      this.RightToLeftLayout = true;
      this.Text = "Site Letter List";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.dgLetters.EndInit();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSelect
    {
      get
      {
        return this._btnSelect;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSelect_Click);
        Button btnSelect1 = this._btnSelect;
        if (btnSelect1 != null)
          btnSelect1.Click -= eventHandler;
        this._btnSelect = value;
        Button btnSelect2 = this._btnSelect;
        if (btnSelect2 == null)
          return;
        btnSelect2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgLetters { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.SetupTemplateDataGrid();
      DataTable table = new DataTable();
      table.Columns.Add("Template");
      string[] files = Directory.GetFiles(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\SiteLetters\\");
      int index = 0;
      while (index < files.Length)
      {
        string path = files[index];
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(path.Replace(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\SiteLetters\\", ""), "vssver.scc", false) > 0U)
        {
          DataRow row = table.NewRow();
          row["Template"] = (object) Path.GetFileName(path);
          table.Rows.Add(row);
        }
        checked { ++index; }
      }
      this.dvLetters = new DataView(table);
    }

    public IUserControl LoadedControl
    {
      get
      {
        IUserControl userControl;
        return userControl;
      }
    }

    public void ResetMe(int newID)
    {
    }

    public DataView dvLetters
    {
      get
      {
        return this._dvLetters;
      }
      set
      {
        this._dvLetters = value;
        this._dvLetters.Table.TableName = Enums.TableNames.tblSite.ToString();
        this._dvLetters.AllowNew = false;
        this._dvLetters.AllowEdit = false;
        this._dvLetters.AllowDelete = false;
        this.dgLetters.DataSource = (object) this.dvLetters;
      }
    }

    private DataRow SelectedLetterDatarow
    {
      get
      {
        return this.dgLetters.CurrentRowIndex != -1 ? this.dvLetters[this.dgLetters.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public string SelectedTemplate
    {
      get
      {
        return this._selectedTemplate;
      }
      set
      {
        this._selectedTemplate = value;
      }
    }

    public void SetupTemplateDataGrid()
    {
      Helper.SetUpDataGrid(this.dgLetters, false);
      DataGridTableStyle tableStyle = this.dgLetters.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Template";
      dataGridLabelColumn.MappingName = "Template";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 300;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblSite.ToString();
      this.dgLetters.TableStyles.Add(tableStyle);
    }

    private void btnSelect_Click(object sender, EventArgs e)
    {
      if (this.SelectedLetterDatarow == null)
        return;
      this.SelectedTemplate = Conversions.ToString(this.SelectedLetterDatarow["Template"]);
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMSiteLetterList_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }
  }
}
