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
            _grpJobTypeColours = new GroupBox();
            _btnSaveJobColour = new Button();
            _btnSaveJobColour.Click += new EventHandler(btnSaveJobColour_Click);
            _btnDeleteJobColour = new Button();
            _btnDeleteJobColour.Click += new EventHandler(btnDeleteJobColour_Click);
            _cboColour = new ComboBox();
            _cboColour.DrawItem += new DrawItemEventHandler(cboColour_DrawItem);
            _lblColour = new Label();
            _cboJobType = new ComboBox();
            _lblJobType = new Label();
            _dgJobTypeColours = new DataGrid();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _grpJobTypeColours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobTypeColours).BeginInit();
            SuspendLayout();
            //
            // grpJobTypeColours
            //
            _grpJobTypeColours.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpJobTypeColours.Controls.Add(_btnSaveJobColour);
            _grpJobTypeColours.Controls.Add(_btnDeleteJobColour);
            _grpJobTypeColours.Controls.Add(_cboColour);
            _grpJobTypeColours.Controls.Add(_lblColour);
            _grpJobTypeColours.Controls.Add(_cboJobType);
            _grpJobTypeColours.Controls.Add(_lblJobType);
            _grpJobTypeColours.Controls.Add(_dgJobTypeColours);
            _grpJobTypeColours.Location = new Point(12, 57);
            _grpJobTypeColours.Name = "grpJobTypeColours";
            _grpJobTypeColours.Size = new Size(316, 536);
            _grpJobTypeColours.TabIndex = 1;
            _grpJobTypeColours.TabStop = false;
            _grpJobTypeColours.Text = "Job Type Colours";
            //
            // btnSaveJobColour
            //
            _btnSaveJobColour.AccessibleDescription = "Save item";
            _btnSaveJobColour.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveJobColour.Cursor = Cursors.Hand;
            _btnSaveJobColour.ImageIndex = 1;
            _btnSaveJobColour.Location = new Point(7, 506);
            _btnSaveJobColour.Name = "btnSaveJobColour";
            _btnSaveJobColour.Size = new Size(94, 24);
            _btnSaveJobColour.TabIndex = 9;
            _btnSaveJobColour.Text = "Save";
            _btnSaveJobColour.UseVisualStyleBackColor = true;
            //
            // btnDeleteJobColour
            //
            _btnDeleteJobColour.AccessibleDescription = "Save item";
            _btnDeleteJobColour.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteJobColour.Cursor = Cursors.Hand;
            _btnDeleteJobColour.ImageIndex = 1;
            _btnDeleteJobColour.Location = new Point(215, 506);
            _btnDeleteJobColour.Name = "btnDeleteJobColour";
            _btnDeleteJobColour.Size = new Size(93, 24);
            _btnDeleteJobColour.TabIndex = 8;
            _btnDeleteJobColour.Text = "Delete";
            _btnDeleteJobColour.UseVisualStyleBackColor = true;
            //
            // cboColour
            //
            _cboColour.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboColour.DrawMode = DrawMode.OwnerDrawFixed;
            _cboColour.FormattingEnabled = true;
            _cboColour.Location = new Point(85, 50);
            _cboColour.Name = "cboColour";
            _cboColour.Size = new Size(223, 22);
            _cboColour.TabIndex = 7;
            //
            // lblColour
            //
            _lblColour.AutoSize = true;
            _lblColour.Location = new Point(10, 54);
            _lblColour.Name = "lblColour";
            _lblColour.Size = new Size(45, 13);
            _lblColour.TabIndex = 6;
            _lblColour.Text = "Colour";
            //
            // cboJobType
            //
            _cboJobType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboJobType.FormattingEnabled = true;
            _cboJobType.Location = new Point(85, 20);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(223, 21);
            _cboJobType.TabIndex = 5;
            //
            // lblJobType
            //
            _lblJobType.AutoSize = true;
            _lblJobType.Location = new Point(10, 25);
            _lblJobType.Name = "lblJobType";
            _lblJobType.Size = new Size(57, 13);
            _lblJobType.TabIndex = 4;
            _lblJobType.Text = "Job Type";
            //
            // dgJobTypeColours
            //
            _dgJobTypeColours.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgJobTypeColours.DataMember = "";
            _dgJobTypeColours.HeaderForeColor = SystemColors.ControlText;
            _dgJobTypeColours.Location = new Point(7, 92);
            _dgJobTypeColours.Name = "dgJobTypeColours";
            _dgJobTypeColours.Size = new Size(301, 408);
            _dgJobTypeColours.TabIndex = 2;
            //
            // btnClose
            //
            _btnClose.AccessibleDescription = "Save item";
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Cursor = Cursors.Hand;
            _btnClose.ImageIndex = 1;
            _btnClose.Location = new Point(12, 599);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(68, 26);
            _btnClose.TabIndex = 4;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            //
            // FRMSchedulerSettings
            //
            AutoScaleBaseSize = new Size(6, 14);
            BackColor = Color.White;
            ClientSize = new Size(690, 636);
            Controls.Add(_btnClose);
            Controls.Add(_grpJobTypeColours);
            MinimumSize = new Size(706, 675);
            Name = "FRMSchedulerSettings";
            Text = "Settings";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpJobTypeColours, 0);
            Controls.SetChildIndex(_btnClose, 0);
            _grpJobTypeColours.ResumeLayout(false);
            _grpJobTypeColours.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobTypeColours).EndInit();
            ResumeLayout(false);
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