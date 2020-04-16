// Decompiled with JetBrains decompiler
// Type: FSM.FRMStandardSentences
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.StandardSentences;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMStandardSentences : FRMBaseForm, IForm
  {
    private IContainer components;
    private Enums.FormState _pageState;
    private DataView _dvStandardSentences;

    public FRMStandardSentences()
    {
      this.Load += new EventHandler(this.FRMPartCategories_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox gpbStandardSentences { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbEditAdd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgStandardSentences
    {
      get
      {
        return this._dgStandardSentences;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgStandardSentences_Click);
        DataGrid standardSentences1 = this._dgStandardSentences;
        if (standardSentences1 != null)
          standardSentences1.Click -= eventHandler;
        this._dgStandardSentences = value;
        DataGrid standardSentences2 = this._dgStandardSentences;
        if (standardSentences2 == null)
          return;
        standardSentences2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSentence { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddNew
    {
      get
      {
        return this._btnAddNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNew_Click);
        Button btnAddNew1 = this._btnAddNew;
        if (btnAddNew1 != null)
          btnAddNew1.Click -= eventHandler;
        this._btnAddNew = value;
        Button btnAddNew2 = this._btnAddNew;
        if (btnAddNew2 == null)
          return;
        btnAddNew2.Click += eventHandler;
      }
    }

    internal virtual Button btnDelete
    {
      get
      {
        return this._btnDelete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDelete_Click);
        Button btnDelete1 = this._btnDelete;
        if (btnDelete1 != null)
          btnDelete1.Click -= eventHandler;
        this._btnDelete = value;
        Button btnDelete2 = this._btnDelete;
        if (btnDelete2 == null)
          return;
        btnDelete2.Click += eventHandler;
      }
    }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.gpbStandardSentences = new GroupBox();
      this.btnDelete = new Button();
      this.btnAddNew = new Button();
      this.dgStandardSentences = new DataGrid();
      this.gpbEditAdd = new GroupBox();
      this.txtSentence = new TextBox();
      this.Label1 = new Label();
      this.btnSave = new Button();
      this.gpbStandardSentences.SuspendLayout();
      this.dgStandardSentences.BeginInit();
      this.gpbEditAdd.SuspendLayout();
      this.SuspendLayout();
      this.gpbStandardSentences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.gpbStandardSentences.Controls.Add((Control) this.btnDelete);
      this.gpbStandardSentences.Controls.Add((Control) this.btnAddNew);
      this.gpbStandardSentences.Controls.Add((Control) this.dgStandardSentences);
      this.gpbStandardSentences.Location = new System.Drawing.Point(8, 40);
      this.gpbStandardSentences.Name = "gpbStandardSentences";
      this.gpbStandardSentences.Size = new Size(608, 448);
      this.gpbStandardSentences.TabIndex = 2;
      this.gpbStandardSentences.TabStop = false;
      this.gpbStandardSentences.Text = "Standard Sentences";
      this.btnDelete.Location = new System.Drawing.Point(520, 16);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.TabIndex = 2;
      this.btnDelete.Text = "Delete";
      this.btnDelete.Visible = false;
      this.btnAddNew.Location = new System.Drawing.Point(8, 16);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.TabIndex = 1;
      this.btnAddNew.Text = "Add New";
      this.dgStandardSentences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgStandardSentences.DataMember = "";
      this.dgStandardSentences.HeaderForeColor = SystemColors.ControlText;
      this.dgStandardSentences.Location = new System.Drawing.Point(8, 42);
      this.dgStandardSentences.Name = "dgStandardSentences";
      this.dgStandardSentences.Size = new Size(592, 398);
      this.dgStandardSentences.TabIndex = 0;
      this.gpbEditAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbEditAdd.Controls.Add((Control) this.txtSentence);
      this.gpbEditAdd.Controls.Add((Control) this.Label1);
      this.gpbEditAdd.Controls.Add((Control) this.btnSave);
      this.gpbEditAdd.Location = new System.Drawing.Point(624, 40);
      this.gpbEditAdd.Name = "gpbEditAdd";
      this.gpbEditAdd.Size = new Size(224, 448);
      this.gpbEditAdd.TabIndex = 3;
      this.gpbEditAdd.TabStop = false;
      this.gpbEditAdd.Text = "Add/Edit";
      this.txtSentence.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSentence.Location = new System.Drawing.Point(8, 42);
      this.txtSentence.Multiline = true;
      this.txtSentence.Name = "txtSentence";
      this.txtSentence.ScrollBars = ScrollBars.Vertical;
      this.txtSentence.Size = new Size(208, 256);
      this.txtSentence.TabIndex = 0;
      this.txtSentence.Text = "";
      this.Label1.Location = new System.Drawing.Point(8, 24);
      this.Label1.Name = "Label1";
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Sentence";
      this.btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(136, 306);
      this.btnSave.Name = "btnSave";
      this.btnSave.TabIndex = 3;
      this.btnSave.Text = "Save";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(856, 494);
      this.Controls.Add((Control) this.gpbEditAdd);
      this.Controls.Add((Control) this.gpbStandardSentences);
      this.Name = nameof (FRMStandardSentences);
      this.Text = "Standard Sentences";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.gpbStandardSentences, 0);
      this.Controls.SetChildIndex((Control) this.gpbEditAdd, 0);
      this.gpbStandardSentences.ResumeLayout(false);
      this.dgStandardSentences.EndInit();
      this.gpbEditAdd.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupManagerDataGrid();
      this.PopulateDatagrid(Enums.FormState.Insert);
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

    private Enums.FormState PageState
    {
      get
      {
        return this._pageState;
      }
      set
      {
        this._pageState = value;
      }
    }

    private DataView DvStandardSentences
    {
      get
      {
        return this._dvStandardSentences;
      }
      set
      {
        this._dvStandardSentences = value;
        this._dvStandardSentences.AllowNew = false;
        this._dvStandardSentences.AllowEdit = false;
        this._dvStandardSentences.AllowDelete = false;
        this._dvStandardSentences.Table.TableName = Enums.TableNames.tblStandardSentences.ToString();
        this.dgStandardSentences.DataSource = (object) this.DvStandardSentences;
      }
    }

    private DataRow SelectedStandardSentencesDataRow
    {
      get
      {
        return this.dgStandardSentences.CurrentRowIndex != -1 ? this.DvStandardSentences[this.dgStandardSentences.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private void SetupManagerDataGrid()
    {
      Helper.SetUpDataGrid(this.dgStandardSentences, false);
      DataGridTableStyle tableStyle = this.dgStandardSentences.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
      dataGridLabelColumn.Format = "";
      dataGridLabelColumn.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn.HeaderText = "Sentence";
      dataGridLabelColumn.MappingName = "Sentence";
      dataGridLabelColumn.ReadOnly = true;
      dataGridLabelColumn.Width = 550;
      dataGridLabelColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblStandardSentences.ToString();
      this.dgStandardSentences.TableStyles.Add(tableStyle);
    }

    private void SetUpPageState(Enums.FormState state)
    {
      Helper.ClearGroupBox(this.gpbEditAdd);
      switch (state)
      {
        case Enums.FormState.Load:
          this.gpbEditAdd.Enabled = false;
          this.btnAddNew.Enabled = false;
          this.btnDelete.Enabled = false;
          this.btnSave.Enabled = false;
          break;
        case Enums.FormState.Insert:
          this.gpbEditAdd.Enabled = true;
          this.btnAddNew.Enabled = true;
          this.btnDelete.Enabled = false;
          this.btnSave.Enabled = true;
          break;
        case Enums.FormState.Update:
          this.btnAddNew.Enabled = true;
          this.gpbEditAdd.Enabled = true;
          this.btnSave.Enabled = true;
          this.btnDelete.Enabled = true;
          break;
      }
      this.PageState = state;
    }

    private void FRMPartCategories_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void dgStandardSentences_Click(object sender, EventArgs e)
    {
      try
      {
        this.SetUpPageState(Enums.FormState.Update);
        if (this.SelectedStandardSentencesDataRow != null)
          this.txtSentence.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedStandardSentencesDataRow["Sentence"]));
        else
          this.SetUpPageState(Enums.FormState.Insert);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Item data cannot load : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      this.SetUpPageState(Enums.FormState.Insert);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      this.Delete();
    }

    private void PopulateDatagrid(Enums.FormState state)
    {
      this.DvStandardSentences = App.DB.StandardSentence.GetAll();
      this.SetUpPageState(state);
    }

    private void Save()
    {
      StandardSentence oStandardSentence = new StandardSentence();
      oStandardSentence.IgnoreExceptionsOnSetMethods = true;
      oStandardSentence.SetSentence = (object) this.txtSentence.Text.Trim();
      StandardSentenceValidator sentenceValidator = new StandardSentenceValidator();
      try
      {
        sentenceValidator.Validate(oStandardSentence);
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            App.DB.StandardSentence.Insert(oStandardSentence);
            break;
          case Enums.FormState.Update:
            oStandardSentence.SetSentenceID = RuntimeHelpers.GetObjectValue(this.SelectedStandardSentencesDataRow["SentenceID"]);
            App.DB.StandardSentence.Update(oStandardSentence);
            break;
        }
        this.PopulateDatagrid(Enums.FormState.Insert);
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(sentenceValidator.CriticalMessagesString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error Saving : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void Delete()
    {
      try
      {
        if (this.SelectedStandardSentencesDataRow != null)
        {
          if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Are you sure you want to delete \"", this.SelectedStandardSentencesDataRow["Sentence"]), (object) "\"?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
          App.DB.StandardSentence.Delete(Conversions.ToInteger(this.SelectedStandardSentencesDataRow["SentenceID"]));
          this.PopulateDatagrid(Enums.FormState.Insert);
        }
        else
        {
          int num = (int) App.ShowMessage("Please select an item to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error deleting : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }
  }
}
