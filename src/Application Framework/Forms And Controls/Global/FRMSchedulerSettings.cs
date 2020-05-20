using FSM.Entity.Settings.Scheduler;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
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
        public FRMSchedulerSettings() : base()
        {
            base.Load += FRMUserSettings_Load;

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

        private GroupBox _grpJobTypeColours;

        private Button _btnSaveJobColour;

        private Button _btnDeleteJobColour;

        private ComboBox _cboColour;

        internal ComboBox cboColour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboColour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboColour != null)
                {
                    _cboColour.DrawItem -= cboColour_DrawItem;
                }

                _cboColour = value;
                if (_cboColour != null)
                {
                    _cboColour.DrawItem += cboColour_DrawItem;
                }
            }
        }

        private Label _lblColour;

        private ComboBox _cboJobType;

        internal ComboBox cboJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobType != null)
                {
                }

                _cboJobType = value;
                if (_cboJobType != null)
                {
                }
            }
        }

        private Label _lblJobType;

        private DataGrid _dgJobTypeColours;

        internal DataGrid dgJobTypeColours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgJobTypeColours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgJobTypeColours != null)
                {
                }

                _dgJobTypeColours = value;
                if (_dgJobTypeColours != null)
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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpJobTypeColours = new System.Windows.Forms.GroupBox();
            this._btnSaveJobColour = new System.Windows.Forms.Button();
            this._btnDeleteJobColour = new System.Windows.Forms.Button();
            this._cboColour = new System.Windows.Forms.ComboBox();
            this._lblColour = new System.Windows.Forms.Label();
            this._cboJobType = new System.Windows.Forms.ComboBox();
            this._lblJobType = new System.Windows.Forms.Label();
            this._dgJobTypeColours = new System.Windows.Forms.DataGrid();
            this._btnClose = new System.Windows.Forms.Button();
            this._grpJobTypeColours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgJobTypeColours)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpJobTypeColours
            // 
            this._grpJobTypeColours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._grpJobTypeColours.Controls.Add(this._btnSaveJobColour);
            this._grpJobTypeColours.Controls.Add(this._btnDeleteJobColour);
            this._grpJobTypeColours.Controls.Add(this._cboColour);
            this._grpJobTypeColours.Controls.Add(this._lblColour);
            this._grpJobTypeColours.Controls.Add(this._cboJobType);
            this._grpJobTypeColours.Controls.Add(this._lblJobType);
            this._grpJobTypeColours.Controls.Add(this._dgJobTypeColours);
            this._grpJobTypeColours.Location = new System.Drawing.Point(12, 12);
            this._grpJobTypeColours.Name = "_grpJobTypeColours";
            this._grpJobTypeColours.Size = new System.Drawing.Size(316, 581);
            this._grpJobTypeColours.TabIndex = 1;
            this._grpJobTypeColours.TabStop = false;
            this._grpJobTypeColours.Text = "Job Type Colours";
            // 
            // _btnSaveJobColour
            // 
            this._btnSaveJobColour.AccessibleDescription = "Save item";
            this._btnSaveJobColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveJobColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSaveJobColour.ImageIndex = 1;
            this._btnSaveJobColour.Location = new System.Drawing.Point(7, 551);
            this._btnSaveJobColour.Name = "_btnSaveJobColour";
            this._btnSaveJobColour.Size = new System.Drawing.Size(94, 24);
            this._btnSaveJobColour.TabIndex = 9;
            this._btnSaveJobColour.Text = "Save";
            this._btnSaveJobColour.UseVisualStyleBackColor = true;
            this._btnSaveJobColour.Click += new System.EventHandler(this.btnSaveJobColour_Click);
            // 
            // _btnDeleteJobColour
            // 
            this._btnDeleteJobColour.AccessibleDescription = "Save item";
            this._btnDeleteJobColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteJobColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDeleteJobColour.ImageIndex = 1;
            this._btnDeleteJobColour.Location = new System.Drawing.Point(215, 551);
            this._btnDeleteJobColour.Name = "_btnDeleteJobColour";
            this._btnDeleteJobColour.Size = new System.Drawing.Size(93, 24);
            this._btnDeleteJobColour.TabIndex = 8;
            this._btnDeleteJobColour.Text = "Delete";
            this._btnDeleteJobColour.UseVisualStyleBackColor = true;
            this._btnDeleteJobColour.Click += new System.EventHandler(this.btnDeleteJobColour_Click);
            // 
            // _cboColour
            // 
            this._cboColour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboColour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboColour.FormattingEnabled = true;
            this._cboColour.Location = new System.Drawing.Point(85, 50);
            this._cboColour.Name = "_cboColour";
            this._cboColour.Size = new System.Drawing.Size(223, 22);
            this._cboColour.TabIndex = 7;
            this._cboColour.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cboColour_DrawItem);
            // 
            // _lblColour
            // 
            this._lblColour.AutoSize = true;
            this._lblColour.Location = new System.Drawing.Point(10, 54);
            this._lblColour.Name = "_lblColour";
            this._lblColour.Size = new System.Drawing.Size(45, 13);
            this._lblColour.TabIndex = 6;
            this._lblColour.Text = "Colour";
            // 
            // _cboJobType
            // 
            this._cboJobType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboJobType.FormattingEnabled = true;
            this._cboJobType.Location = new System.Drawing.Point(85, 20);
            this._cboJobType.Name = "_cboJobType";
            this._cboJobType.Size = new System.Drawing.Size(223, 21);
            this._cboJobType.TabIndex = 5;
            // 
            // _lblJobType
            // 
            this._lblJobType.AutoSize = true;
            this._lblJobType.Location = new System.Drawing.Point(10, 25);
            this._lblJobType.Name = "_lblJobType";
            this._lblJobType.Size = new System.Drawing.Size(57, 13);
            this._lblJobType.TabIndex = 4;
            this._lblJobType.Text = "Job Type";
            // 
            // _dgJobTypeColours
            // 
            this._dgJobTypeColours.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgJobTypeColours.DataMember = "";
            this._dgJobTypeColours.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgJobTypeColours.Location = new System.Drawing.Point(7, 92);
            this._dgJobTypeColours.Name = "_dgJobTypeColours";
            this._dgJobTypeColours.Size = new System.Drawing.Size(301, 453);
            this._dgJobTypeColours.TabIndex = 2;
            // 
            // _btnClose
            // 
            this._btnClose.AccessibleDescription = "Save item";
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnClose.ImageIndex = 1;
            this._btnClose.Location = new System.Drawing.Point(12, 599);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(68, 26);
            this._btnClose.TabIndex = 4;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRMSchedulerSettings
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(690, 636);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._grpJobTypeColours);
            this.MinimumSize = new System.Drawing.Size(706, 675);
            this.Name = "FRMSchedulerSettings";
            this.Text = "Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpJobTypeColours.ResumeLayout(false);
            this._grpJobTypeColours.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgJobTypeColours)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void ResetMe(int newID)
        {
        }

        private DataView _dvJobTypeColour;

        private DataView DvJobTypeColour
        {
            get
            {
                return _dvJobTypeColour;
            }

            set
            {
                _dvJobTypeColour = value;
                _dvJobTypeColour.Table.TableName = "JobTypeColour";
                dgJobTypeColours.DataSource = DvJobTypeColour;
            }
        }

        private DataRow DrSelectedJobTypeColour
        {
            get
            {
                if (!(dgJobTypeColours.CurrentRowIndex == -1))
                {
                    return DvJobTypeColour[dgJobTypeColours.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void FRMUserSettings_Load(object sender, EventArgs e)
        {
            var argc = cboJobType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            SetUpColourCombo();
            SetupDgJobColours();
            PopulateJobTypeColours();
        }

        private void cboColour_DrawItem(object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            var rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                var f = new Font("Arial", 9, FontStyle.Regular);
                var c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
            }
        }

        private void btnSaveJobColour_Click(object sender, EventArgs e)
        {
            SaveJobTypeColour();
        }

        private void btnDeleteJobColour_Click(object sender, EventArgs e)
        {
            DeleteJobTypeColour();
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

        private void PopulateJobTypeColours()
        {
            SetupDgJobColours();
            var dt = Helper.ToDataTable(App.DB.JobTypeColour.Get_All());
            var dv = new DataView(dt);
            DvJobTypeColour = dv;
        }

        public void SaveJobTypeColour()
        {
            try
            {
                int jobTypeId = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboJobType));
                if (jobTypeId == 0 | cboColour.SelectedIndex == 0)
                    return;
                string colour = Conversions.ToString(cboColour.SelectedItem);
                var jtcs = App.DB.JobTypeColour.Get_All();
                if (jtcs is object)
                    jtcs = jtcs.Where(x => x.JobTypeId == jobTypeId | (x.Colour ?? "") == (colour ?? "")).ToList();
                if (jtcs is object && jtcs.Count > 0)
                {
                    App.ShowMessage(jtcs.FirstOrDefault().JobType + " has a link to " + jtcs.FirstOrDefault().Colour + "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetJobTypeColour();
                    return;
                }

                var jtc = new JobTypeColour() { JobTypeId = jobTypeId, Colour = colour };
                jtc = App.DB.JobTypeColour.Insert(jtc);
                if (jtc.Id > 0)
                    ResetJobTypeColour();
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteJobTypeColour()
        {
            if (DrSelectedJobTypeColour is null)
            {
                App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                App.DB.JobTypeColour.Delete(Conversions.ToInteger(DrSelectedJobTypeColour["Id"]));
                ResetJobTypeColour();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error deleting: " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void ResetJobTypeColour()
        {
            PopulateJobTypeColours();
            var argcombo = cboJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            cboColour.SelectedIndex = 0;
        }

        public void SetUpColourCombo()
        {
            cboColour.Items.Clear();
            cboColour.Items.Add("-- Please Select --");
            var colourList = new ArrayList();
            var colorType = typeof(Color);
            var propInfo = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo colour in propInfo)
                cboColour.Items.Add(colour.Name);
            cboColour.DisplayMember = "Description";
            cboColour.ValueMember = "Value";
            cboColour.SelectedIndex = 0;
        }

        private void SetupDgJobColours()
        {
            Helper.SetUpDataGrid(dgJobTypeColours);
            var dgts = dgJobTypeColours.TableStyles[0];
            var jobType = new DataGridJobTypeColumn();
            jobType.Format = "";
            jobType.FormatInfo = null;
            jobType.HeaderText = "Job Type";
            jobType.MappingName = "JobType";
            jobType.ReadOnly = true;
            jobType.Width = 145;
            jobType.NullText = "";
            dgts.GridColumnStyles.Add(jobType);
            var colour = new DataGridJobTypeColumn();
            colour.Format = "";
            colour.FormatInfo = null;
            colour.HeaderText = "Colour";
            colour.MappingName = "Colour";
            colour.ReadOnly = true;
            colour.Width = 100;
            colour.NullText = "";
            dgts.GridColumnStyles.Add(colour);
            dgts.ReadOnly = true;
            dgts.MappingName = "JobTypeColour";
            dgJobTypeColours.TableStyles.Add(dgts);
        }
    }
}