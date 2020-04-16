// Decompiled with JetBrains decompiler
// Type: FSM.FRMPrivNotes
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
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMPrivNotes : Form
  {
    private IContainer components;
    public DataRow dr;
    public DateTime Max;
    public DataTable dt;

    public FRMPrivNotes()
    {
      this.Load += new EventHandler(this.FRMChangePriority_Load);
      this.dr = (DataRow) null;
      this.Max = DateTime.MaxValue;
      this.dt = new DataTable();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMPrivNotes));
      this.GroupBox1 = new GroupBox();
      this.btnAdd = new Button();
      this.dgvNotes = new DataGridView();
      this.Label4 = new Label();
      this.txtEngineernotes = new TextBox();
      this.lblMessage = new Label();
      this.btnClose = new Button();
      this.GroupBox1.SuspendLayout();
      ((ISupportInitialize) this.dgvNotes).BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.btnAdd);
      this.GroupBox1.Controls.Add((Control) this.dgvNotes);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.txtEngineernotes);
      this.GroupBox1.Controls.Add((Control) this.lblMessage);
      this.GroupBox1.Controls.Add((Control) this.btnClose);
      this.GroupBox1.Location = new System.Drawing.Point(5, 1);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(945, 421);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Location = new System.Drawing.Point(842, 330);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(97, 51);
      this.btnAdd.TabIndex = 16;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseMnemonic = false;
      this.btnAdd.UseVisualStyleBackColor = true;
      this.dgvNotes.AllowUserToAddRows = false;
      this.dgvNotes.AllowUserToDeleteRows = false;
      this.dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvNotes.Location = new System.Drawing.Point(10, 11);
      this.dgvNotes.Name = "dgvNotes";
      this.dgvNotes.Size = new Size(929, 296);
      this.dgvNotes.TabIndex = 15;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(19, 333);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(120, 13);
      this.Label4.TabIndex = 14;
      this.Label4.Text = "Additional Private Notes";
      this.txtEngineernotes.Location = new System.Drawing.Point(145, 330);
      this.txtEngineernotes.Multiline = true;
      this.txtEngineernotes.Name = "txtEngineernotes";
      this.txtEngineernotes.Size = new Size(691, 51);
      this.txtEngineernotes.TabIndex = 13;
      this.lblMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.lblMessage.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMessage.ForeColor = Color.Maroon;
      this.lblMessage.Location = new System.Drawing.Point(7, 241);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(932, 24);
      this.lblMessage.TabIndex = 12;
      this.lblMessage.TextAlign = ContentAlignment.TopCenter;
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Location = new System.Drawing.Point(450, 392);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(75, 23);
      this.btnClose.TabIndex = 7;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(962, 434);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MinimumSize = new Size(529, 393);
      this.Name = nameof (FRMPrivNotes);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Private Notes";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      ((ISupportInitialize) this.dgvNotes).EndInit();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label lblMessage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEngineernotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgvNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

    private void FRMChangePriority_Load(object sender, EventArgs e)
    {
      Helper.SetUpDataGridView(this.dgvNotes, false);
      this.dgvNotes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.dgvNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      this.dgvNotes.AutoGenerateColumns = false;
      this.dgvNotes.Columns.Clear();
      this.dgvNotes.EditMode = DataGridViewEditMode.EditOnEnter;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.Width = 1;
      viewTextBoxColumn1.DataPropertyName = "JobNoteID";
      viewTextBoxColumn1.Name = "JobNoteID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvNotes.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.Width = 110;
      viewTextBoxColumn2.DataPropertyName = "JobNumber";
      viewTextBoxColumn2.Name = "JobNumber";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvNotes.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.Width = 600;
      viewTextBoxColumn3.DataPropertyName = "Note";
      viewTextBoxColumn3.Name = "Note";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvNotes.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.Width = 130;
      viewTextBoxColumn4.DataPropertyName = "LastEdited";
      viewTextBoxColumn4.Name = "LastEdited";
      viewTextBoxColumn4.HeaderText = "Last Edited";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvNotes.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.Width = 145;
      viewTextBoxColumn5.DataPropertyName = "EditedBy";
      viewTextBoxColumn5.HeaderText = "Edited By";
      viewTextBoxColumn5.Name = "EditedBy";
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.Visible = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvNotes.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
      this.dgvNotes.DataSource = (object) this.dt;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      DataRow row = this.dt.NewRow();
      row[0] = (object) 0;
      row[1] = (object) App.loggedInUser.UserID;
      row[2] = (object) App.loggedInUser.UserID;
      row[3] = (object) this.txtEngineernotes.Text;
      row[4] = (object) DateTime.Now;
      row[5] = (object) App.loggedInUser.Username;
      row[6] = (object) DateTime.Now;
      row[7] = (object) App.loggedInUser.Username;
      row[8] = (object) 0;
      row[9] = (object) "New..";
      row[10] = (object) 0;
      this.dt.Rows.InsertAt(row, 0);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
