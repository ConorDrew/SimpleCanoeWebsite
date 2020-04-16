// Decompiled with JetBrains decompiler
// Type: FSM.FRMAnswers
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CheckLists;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMAnswers : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _EngineerVisitID;
    private int _SectionID;
    private CheckList _Checklist;
    private DataView _ChecklistDataview;

    public FRMAnswers()
    {
      this.Load += new EventHandler(this.FRMAnswers_Load);
      this._EngineerVisitID = 0;
      this._SectionID = 0;
      this._Checklist = (CheckList) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpAnswers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgChecklist { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpAnswers = new GroupBox();
      this.dgChecklist = new DataGrid();
      this.btnClose = new Button();
      this.btnSave = new Button();
      this.Label1 = new Label();
      this.grpAnswers.SuspendLayout();
      this.dgChecklist.BeginInit();
      this.SuspendLayout();
      this.grpAnswers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAnswers.Controls.Add((Control) this.dgChecklist);
      this.grpAnswers.Location = new System.Drawing.Point(8, 40);
      this.grpAnswers.Name = "grpAnswers";
      this.grpAnswers.Size = new Size(856, 480);
      this.grpAnswers.TabIndex = 1;
      this.grpAnswers.TabStop = false;
      this.grpAnswers.Text = "Answers relate to the closest question (All preceeding information are headings)";
      this.dgChecklist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgChecklist.DataMember = "";
      this.dgChecklist.HeaderForeColor = SystemColors.ControlText;
      this.dgChecklist.Location = new System.Drawing.Point(8, 25);
      this.dgChecklist.Name = "dgChecklist";
      this.dgChecklist.Size = new Size(840, 447);
      this.dgChecklist.TabIndex = 1;
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(8, 528);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(48, 23);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Close";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(816, 528);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(48, 23);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Label1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      this.Label1.Font = new Font("Verdana", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new System.Drawing.Point(208, 528);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(600, 23);
      this.Label1.TabIndex = 4;
      this.Label1.Text = "Pick a result and enter any comments for each question and then click save";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(872, 558);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.grpAnswers);
      this.MinimumSize = new Size(880, 592);
      this.Name = nameof (FRMAnswers);
      this.Text = "Checklist Questions & Answers";
      this.Controls.SetChildIndex((Control) this.grpAnswers, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.grpAnswers.ResumeLayout(false);
      this.dgChecklist.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDataGrid();
      this.EngineerVisitID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.SectionID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1)));
      this.Checklist = App.DB.Checklists.Get(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(2))));
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

    public int EngineerVisitID
    {
      get
      {
        return this._EngineerVisitID;
      }
      set
      {
        this._EngineerVisitID = value;
      }
    }

    public int SectionID
    {
      get
      {
        return this._SectionID;
      }
      set
      {
        this._SectionID = value;
      }
    }

    public CheckList Checklist
    {
      get
      {
        return this._Checklist;
      }
      set
      {
        this._Checklist = value;
        if (this._Checklist == null)
        {
          this._Checklist = new CheckList();
          this._Checklist.Exists = false;
        }
        this.Populate();
      }
    }

    public DataView ChecklistDataview
    {
      get
      {
        return this._ChecklistDataview;
      }
      set
      {
        this._ChecklistDataview = value;
        this._ChecklistDataview.AllowNew = false;
        this._ChecklistDataview.AllowEdit = true;
        this._ChecklistDataview.AllowDelete = false;
        this._ChecklistDataview.Table.TableName = Enums.TableNames.tblCheckListAnswers.ToString();
        this.dgChecklist.DataSource = (object) this.ChecklistDataview;
      }
    }

    private void SetupDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgChecklist.TableStyles[0];
      this.dgChecklist.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Section";
      dataGridLabelColumn1.MappingName = "Section";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Area";
      dataGridLabelColumn2.MappingName = "Area";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 150;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Task";
      dataGridLabelColumn3.MappingName = "Task";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Sub Task";
      dataGridLabelColumn4.MappingName = "SubTask";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridComboBoxColumn gridComboBoxColumn = new DataGridComboBoxColumn(false);
      gridComboBoxColumn.HeaderText = "Result (Select)";
      gridComboBoxColumn.MappingName = "Result";
      gridComboBoxColumn.ReadOnly = false;
      gridComboBoxColumn.Width = 75;
      gridComboBoxColumn.NullText = "";
      gridComboBoxColumn.ComboBox.DataSource = (object) DynamicDataTables.ChecklistResults;
      gridComboBoxColumn.ComboBox.DisplayMember = "DisplayMember";
      gridComboBoxColumn.ComboBox.ValueMember = "ValueMember";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridComboBoxColumn);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "Comments";
      editableTextBoxColumn.MappingName = "Comments";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 500;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.MappingName = Enums.TableNames.tblCheckListAnswers.ToString();
      this.dgChecklist.TableStyles.Add(tableStyle);
    }

    private void FRMAnswers_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void Populate()
    {
      this.ChecklistDataview = App.DB.Checklists.Get_Questions_And_Answers_For_Section(this.SectionID, this.Checklist.CheckListID);
    }

    private void Save()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        int checkListId;
        if (this.Checklist.Exists)
        {
          checkListId = this.Checklist.CheckListID;
        }
        else
        {
          this.Checklist.IgnoreExceptionsOnSetMethods = true;
          this.Checklist.SetEngineerVisitID = (object) this.EngineerVisitID;
          this.Checklist.SetSectionID = (object) this.SectionID;
          checkListId = App.DB.Checklists.Insert(this.Checklist).CheckListID;
        }
        CheckListAnswer oCheckListAnswer = new CheckListAnswer();
        oCheckListAnswer.SetCheckListID = (object) checkListId;
        App.DB.Checklists.DeleteAnswers(checkListId);
        IEnumerator enumerator;
        try
        {
          enumerator = this.ChecklistDataview.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["SubTaskID"])) > 0U)
            {
              oCheckListAnswer.SetEnumTableID = (object) 45;
              oCheckListAnswer.SetQuestionID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["SubTaskID"]));
            }
            else if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["TaskID"])) > 0U)
            {
              oCheckListAnswer.SetEnumTableID = (object) 46;
              oCheckListAnswer.SetQuestionID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["TaskID"]));
            }
            else if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["AreaID"])) > 0U)
            {
              oCheckListAnswer.SetEnumTableID = (object) 43;
              oCheckListAnswer.SetQuestionID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["AreaID"]));
            }
            else
            {
              oCheckListAnswer.SetEnumTableID = (object) 44;
              oCheckListAnswer.SetQuestionID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["SectionID"]));
            }
            oCheckListAnswer.SetResultID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Result"]));
            oCheckListAnswer.SetComments = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Comments"]));
            App.DB.Checklists.InsertAnswer(oCheckListAnswer);
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.Checklist = App.DB.Checklists.Get(checkListId);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error saving answers : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }
  }
}
