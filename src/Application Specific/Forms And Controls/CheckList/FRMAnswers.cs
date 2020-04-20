using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMAnswers : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMAnswers() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMAnswers_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components is null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private GroupBox _grpAnswers;

        internal GroupBox grpAnswers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAnswers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAnswers != null)
                {
                }

                _grpAnswers = value;
                if (_grpAnswers != null)
                {
                }
            }
        }

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private DataGrid _dgChecklist;

        internal DataGrid dgChecklist
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgChecklist;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgChecklist != null)
                {
                }

                _dgChecklist = value;
                if (_dgChecklist != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpAnswers = new GroupBox();
            _dgChecklist = new DataGrid();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _Label1 = new Label();
            _grpAnswers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgChecklist).BeginInit();
            SuspendLayout();
            // 
            // grpAnswers
            // 
            _grpAnswers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAnswers.Controls.Add(_dgChecklist);
            _grpAnswers.Location = new Point(8, 40);
            _grpAnswers.Name = "grpAnswers";
            _grpAnswers.Size = new Size(856, 480);
            _grpAnswers.TabIndex = 1;
            _grpAnswers.TabStop = false;
            _grpAnswers.Text = "Answers relate to the closest question (All preceeding information are headings)";
            // 
            // dgChecklist
            // 
            _dgChecklist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgChecklist.DataMember = "";
            _dgChecklist.HeaderForeColor = SystemColors.ControlText;
            _dgChecklist.Location = new Point(8, 25);
            _dgChecklist.Name = "dgChecklist";
            _dgChecklist.Size = new Size(840, 447);
            _dgChecklist.TabIndex = 1;
            // 
            // btnClose
            // 
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(8, 528);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(48, 23);
            _btnClose.TabIndex = 3;
            _btnClose.Text = "Close";
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(816, 528);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(48, 23);
            _btnSave.TabIndex = 2;
            _btnSave.Text = "Save";
            // 
            // Label1
            // 
            _Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label1.BackColor = Color.FromArgb(Conversions.ToByte(255), Conversions.ToByte(255), Conversions.ToByte(192));
            _Label1.Font = new Font("Verdana", 10.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(208, 528);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(600, 23);
            _Label1.TabIndex = 4;
            _Label1.Text = "Pick a result and enter any comments for each question and then click save";
            _Label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FRMAnswers
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(872, 558);
            Controls.Add(_Label1);
            Controls.Add(_btnSave);
            Controls.Add(_btnClose);
            Controls.Add(_grpAnswers);
            MinimumSize = new Size(880, 592);
            Name = "FRMAnswers";
            Text = "Checklist Questions & Answers";
            Controls.SetChildIndex(_grpAnswers, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_Label1, 0);
            _grpAnswers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgChecklist).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDataGrid();
            EngineerVisitID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            SectionID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(1));
            Checklist = App.DB.Checklists.Get(Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(2)));
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _EngineerVisitID = 0;

        public int EngineerVisitID
        {
            get
            {
                return _EngineerVisitID;
            }

            set
            {
                _EngineerVisitID = value;
            }
        }

        private int _SectionID = 0;

        public int SectionID
        {
            get
            {
                return _SectionID;
            }

            set
            {
                _SectionID = value;
            }
        }

        private Entity.CheckLists.CheckList _Checklist = null;

        public Entity.CheckLists.CheckList Checklist
        {
            get
            {
                return _Checklist;
            }

            set
            {
                _Checklist = value;
                if (_Checklist is null)
                {
                    _Checklist = new Entity.CheckLists.CheckList();
                    _Checklist.Exists = false;
                }

                Populate();
            }
        }

        private DataView _ChecklistDataview;

        public DataView ChecklistDataview
        {
            get
            {
                return _ChecklistDataview;
            }

            set
            {
                _ChecklistDataview = value;
                _ChecklistDataview.AllowNew = false;
                _ChecklistDataview.AllowEdit = true;
                _ChecklistDataview.AllowDelete = false;
                _ChecklistDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblCheckListAnswers.ToString();
                dgChecklist.DataSource = ChecklistDataview;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupDataGrid()
        {
            var tbStyle = dgChecklist.TableStyles[0];
            dgChecklist.ReadOnly = false;
            tbStyle.AllowSorting = false;
            tbStyle.ReadOnly = false;
            var Section = new DataGridLabelColumn();
            Section.Format = "";
            Section.FormatInfo = null;
            Section.HeaderText = "Section";
            Section.MappingName = "Section";
            Section.ReadOnly = true;
            Section.Width = 150;
            Section.NullText = "";
            tbStyle.GridColumnStyles.Add(Section);
            var Area = new DataGridLabelColumn();
            Area.Format = "";
            Area.FormatInfo = null;
            Area.HeaderText = "Area";
            Area.MappingName = "Area";
            Area.ReadOnly = true;
            Area.Width = 150;
            Area.NullText = "";
            tbStyle.GridColumnStyles.Add(Area);
            var Task = new DataGridLabelColumn();
            Task.Format = "";
            Task.FormatInfo = null;
            Task.HeaderText = "Task";
            Task.MappingName = "Task";
            Task.ReadOnly = true;
            Task.Width = 150;
            Task.NullText = "";
            tbStyle.GridColumnStyles.Add(Task);
            var SubTask = new DataGridLabelColumn();
            SubTask.Format = "";
            SubTask.FormatInfo = null;
            SubTask.HeaderText = "Sub Task";
            SubTask.MappingName = "SubTask";
            SubTask.ReadOnly = true;
            SubTask.Width = 150;
            SubTask.NullText = "";
            tbStyle.GridColumnStyles.Add(SubTask);
            var Result = new DataGridComboBoxColumn();
            Result.HeaderText = "Result (Select)";
            Result.MappingName = "Result";
            Result.ReadOnly = false;
            Result.Width = 75;
            Result.NullText = "";
            Result.ComboBox.DataSource = DynamicDataTables.ChecklistResults;
            Result.ComboBox.DisplayMember = "DisplayMember";
            Result.ComboBox.ValueMember = "ValueMember";
            tbStyle.GridColumnStyles.Add(Result);
            var Comments = new DataGridEditableTextBoxColumn();
            Comments.Format = "";
            Comments.FormatInfo = null;
            Comments.HeaderText = "Comments";
            Comments.MappingName = "Comments";
            Comments.ReadOnly = false;
            Comments.Width = 500;
            Comments.NullText = "";
            tbStyle.GridColumnStyles.Add(Comments);
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblCheckListAnswers.ToString();
            dgChecklist.TableStyles.Add(tbStyle);
        }

        private void FRMAnswers_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate()
        {
            ChecklistDataview = App.DB.Checklists.Get_Questions_And_Answers_For_Section(SectionID, Checklist.CheckListID);
        }

        private void Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                int tempChecklistID;
                if (Checklist.Exists == true)
                {
                    tempChecklistID = Checklist.CheckListID;
                }
                else
                {
                    Checklist.IgnoreExceptionsOnSetMethods = true;
                    Checklist.SetEngineerVisitID = EngineerVisitID;
                    Checklist.SetSectionID = SectionID;
                    tempChecklistID = App.DB.Checklists.Insert(Checklist).CheckListID;
                }

                var oCheckListAnswer = new Entity.CheckLists.CheckListAnswer();
                oCheckListAnswer.SetCheckListID = tempChecklistID;
                App.DB.Checklists.DeleteAnswers(tempChecklistID);
                foreach (DataRow row in ChecklistDataview.Table.Rows)
                {
                    if (!(Entity.Sys.Helper.MakeIntegerValid(row["SubTaskID"]) == 0))
                    {
                        oCheckListAnswer.SetEnumTableID = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblSubTask);
                        oCheckListAnswer.SetQuestionID = Entity.Sys.Helper.MakeIntegerValid(row["SubTaskID"]);
                    }
                    else if (!(Entity.Sys.Helper.MakeIntegerValid(row["TaskID"]) == 0))
                    {
                        oCheckListAnswer.SetEnumTableID = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblTask);
                        oCheckListAnswer.SetQuestionID = Entity.Sys.Helper.MakeIntegerValid(row["TaskID"]);
                    }
                    else if (!(Entity.Sys.Helper.MakeIntegerValid(row["AreaID"]) == 0))
                    {
                        oCheckListAnswer.SetEnumTableID = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblArea);
                        oCheckListAnswer.SetQuestionID = Entity.Sys.Helper.MakeIntegerValid(row["AreaID"]);
                    }
                    else
                    {
                        oCheckListAnswer.SetEnumTableID = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblSection);
                        oCheckListAnswer.SetQuestionID = Entity.Sys.Helper.MakeIntegerValid(row["SectionID"]);
                    }

                    oCheckListAnswer.SetResultID = Entity.Sys.Helper.MakeIntegerValid(row["Result"]);
                    oCheckListAnswer.SetComments = Entity.Sys.Helper.MakeStringValid(row["Comments"]);
                    App.DB.Checklists.InsertAnswer(oCheckListAnswer);
                }

                Checklist = App.DB.Checklists.Get(tempChecklistID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error saving answers : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}