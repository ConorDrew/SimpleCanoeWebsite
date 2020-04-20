using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class DLGEngineerVisitDefect : FRMBaseForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public DLGEngineerVisitDefect() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += DLGEngineerVisitDefect_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
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

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
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

        private ComboBox _cboCategory;

        internal ComboBox cboCategory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCategory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCategory != null)
                {
                }

                _cboCategory = value;
                if (_cboCategory != null)
                {
                }
            }
        }

        private ComboBox _cboAsset;

        internal ComboBox cboAsset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAsset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAsset != null)
                {
                }

                _cboAsset = value;
                if (_cboAsset != null)
                {
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private TextBox _txtReason;

        internal TextBox txtReason
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtReason;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtReason != null)
                {
                }

                _txtReason = value;
                if (_txtReason != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private TextBox _txtComments;

        internal TextBox txtComments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtComments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtComments != null)
                {
                }

                _txtComments = value;
                if (_txtComments != null)
                {
                }
            }
        }

        private TextBox _txtActionTaken;

        internal TextBox txtActionTaken
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtActionTaken;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtActionTaken != null)
                {
                }

                _txtActionTaken = value;
                if (_txtActionTaken != null)
                {
                }
            }
        }

        private CheckBox _chkWarningNoticeIssued;

        internal CheckBox chkWarningNoticeIssued
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkWarningNoticeIssued;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkWarningNoticeIssued != null)
                {
                }

                _chkWarningNoticeIssued = value;
                if (_chkWarningNoticeIssued != null)
                {
                }
            }
        }

        private CheckBox _chkDisconnected;

        internal CheckBox chkDisconnected
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDisconnected;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDisconnected != null)
                {
                }

                _chkDisconnected = value;
                if (_chkDisconnected != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _GroupBox1 = new GroupBox();
            _txtActionTaken = new TextBox();
            _Label5 = new Label();
            _txtComments = new TextBox();
            _Label4 = new Label();
            _txtReason = new TextBox();
            _Label3 = new Label();
            _chkDisconnected = new CheckBox();
            _chkWarningNoticeIssued = new CheckBox();
            _cboAsset = new ComboBox();
            _Label2 = new Label();
            _cboCategory = new ComboBox();
            _Label1 = new Label();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.UseVisualStyleBackColor = true;
            _btnSave.Location = new Point(448, 384);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(75, 23);
            _btnSave.TabIndex = 2;
            _btnSave.Text = "Save";
            // 
            // btnCancel
            // 
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.UseVisualStyleBackColor = true;
            _btnCancel.Location = new Point(8, 384);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 3;
            _btnCancel.Text = "Cancel";
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_txtActionTaken);
            _GroupBox1.Controls.Add(_Label5);
            _GroupBox1.Controls.Add(_txtComments);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_txtReason);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_chkDisconnected);
            _GroupBox1.Controls.Add(_chkWarningNoticeIssued);
            _GroupBox1.Controls.Add(_cboAsset);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_cboCategory);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(512, 336);
            _GroupBox1.TabIndex = 4;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Defect Details";
            // 
            // txtActionTaken
            // 
            _txtActionTaken.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtActionTaken.Location = new Point(120, 226);
            _txtActionTaken.Multiline = true;
            _txtActionTaken.Name = "txtActionTaken";
            _txtActionTaken.ScrollBars = ScrollBars.Vertical;
            _txtActionTaken.Size = new Size(384, 48);
            _txtActionTaken.TabIndex = 11;
            // 
            // Label5
            // 
            _Label5.Location = new Point(16, 224);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(80, 23);
            _Label5.TabIndex = 10;
            _Label5.Text = "Action Taken";
            // 
            // txtComments
            // 
            _txtComments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtComments.Location = new Point(120, 282);
            _txtComments.Multiline = true;
            _txtComments.Name = "txtComments";
            _txtComments.ScrollBars = ScrollBars.Vertical;
            _txtComments.Size = new Size(384, 46);
            _txtComments.TabIndex = 9;
            // 
            // Label4
            // 
            _Label4.Location = new Point(16, 280);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(80, 23);
            _Label4.TabIndex = 8;
            _Label4.Text = "Comments";
            // 
            // txtReason
            // 
            _txtReason.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtReason.Location = new Point(120, 170);
            _txtReason.Multiline = true;
            _txtReason.Name = "txtReason";
            _txtReason.ScrollBars = ScrollBars.Vertical;
            _txtReason.Size = new Size(384, 48);
            _txtReason.TabIndex = 7;
            // 
            // Label3
            // 
            _Label3.Location = new Point(16, 168);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(80, 23);
            _Label3.TabIndex = 6;
            _Label3.Text = "Reason";
            // 
            // chkDisconnected
            // 
            _chkDisconnected.CheckAlign = ContentAlignment.MiddleRight;
            _chkDisconnected.Location = new Point(16, 136);
            _chkDisconnected.Name = "chkDisconnected";
            _chkDisconnected.Size = new Size(120, 24);
            _chkDisconnected.TabIndex = 5;
            _chkDisconnected.Text = "Disconnected";
            // 
            // chkWarningNoticeIssued
            // 
            _chkWarningNoticeIssued.CheckAlign = ContentAlignment.MiddleRight;
            _chkWarningNoticeIssued.Location = new Point(16, 88);
            _chkWarningNoticeIssued.Name = "chkWarningNoticeIssued";
            _chkWarningNoticeIssued.Size = new Size(120, 40);
            _chkWarningNoticeIssued.TabIndex = 4;
            _chkWarningNoticeIssued.Text = "Warning Notice Issued";
            // 
            // cboAsset
            // 
            _cboAsset.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboAsset.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAsset.Location = new Point(120, 27);
            _cboAsset.Name = "cboAsset";
            _cboAsset.Size = new Size(384, 21);
            _cboAsset.TabIndex = 3;
            // 
            // Label2
            // 
            _Label2.Location = new Point(16, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(72, 23);
            _Label2.TabIndex = 2;
            _Label2.Text = "Appliance";
            // 
            // cboCategory
            // 
            _cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboCategory.Location = new Point(120, 59);
            _cboCategory.Name = "cboCategory";
            _cboCategory.Size = new Size(384, 21);
            _cboCategory.TabIndex = 1;
            // 
            // Label1
            // 
            _Label1.Location = new Point(16, 56);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(72, 23);
            _Label1.TabIndex = 0;
            _Label1.Text = "Category";
            // 
            // DLGEngineerVisitDefect
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(528, 414);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Controls.Add(_btnCancel);
            Controls.Add(_btnSave);
            MinimumSize = new Size(536, 448);
            Name = "DLGEngineerVisitDefect";
            Text = "Engineer Visit Defect";
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool _updating = true;

        public bool Updating
        {
            get
            {
                return _updating;
            }

            set
            {
                _updating = value;
            }
        }

        private Entity.EngineerVisitDefectss.EngineerVisitDefects _Defect;

        public Entity.EngineerVisitDefectss.EngineerVisitDefects Defect
        {
            get
            {
                return _Defect;
            }

            set
            {
                _Defect = value;
            }
        }

        private Entity.EngineerVisits.EngineerVisit _EngineerVisit;

        public Entity.EngineerVisits.EngineerVisit EngineerVisit
        {
            get
            {
                return _EngineerVisit;
            }

            set
            {
                _EngineerVisit = value;
            }
        }

        private int _jobID;

        public int JobID
        {
            get
            {
                return _jobID;
            }

            set
            {
                _jobID = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void populateDefect()
        {
            var argcombo = cboAsset;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Defect.AssetID.ToString());
            var argcombo1 = cboCategory;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Defect.CategoryID.ToString());
            chkDisconnected.Checked = Defect.Disconnected;
            chkWarningNoticeIssued.Checked = Defect.WarningNoticeIssued;
            txtReason.Text = Defect.Reason;
            txtActionTaken.Text = Defect.ActionTaken;
            txtComments.Text = Defect.Comments;
        }

        private void DLGEngineerVisitDefect_Load(object sender, EventArgs e)
        {
            if (App.loggedInUser.Admin == false)
            {
                btnSave.Enabled = false;
                cboAsset.Enabled = false;
                cboCategory.Enabled = false;
                chkDisconnected.Enabled = false;
                chkWarningNoticeIssued.Enabled = false;
                txtActionTaken.ReadOnly = true;
                txtComments.ReadOnly = true;
                txtReason.ReadOnly = true;
            }

            var argc = cboCategory;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.DefectCategorys).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboAsset;
            Combo.SetUpCombo(ref argc1, App.DB.JobAsset.JobAsset_Get_For_Job(JobID).Table, "AssetID", "AssetDescriptionWithLocation", Entity.Sys.Enums.ComboValues.Not_Applicable);
            if (Defect.Exists == true & Updating == true)
            {
                populateDefect();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Defect.SetAssetID = Combo.get_GetSelectedItemValue(cboAsset);
                Defect.SetCategoryID = Combo.get_GetSelectedItemValue(cboCategory);
                Defect.SetActionTaken = txtActionTaken.Text;
                Defect.SetComments = txtComments.Text;
                Defect.SetDisconnected = chkDisconnected.Checked;
                Defect.SetWarningNoticeIssued = chkWarningNoticeIssued.Checked;
                Defect.SetReason = txtReason.Text;
                Defect.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                var dValidator = new Entity.EngineerVisitDefectss.EngineerVisitDefectsValidator();
                dValidator.Validate(Defect);
                if (Updating)
                {
                    App.DB.EngineerVisitDefects.Update(Defect);
                }
                else
                {
                    App.DB.EngineerVisitDefects.Insert(Defect);
                }

                DialogResult = DialogResult.OK;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error saving details : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}