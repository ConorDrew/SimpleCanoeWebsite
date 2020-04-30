using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMHistory : FRMBaseForm, IForm
    {
        public FRMHistory() : base()
        {
            base.Load += FRMHistory_Load;

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
        private DataGrid _dgHistory;

        internal DataGrid dgHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgHistory != null)
                {
                }

                _dgHistory = value;
                if (_dgHistory != null)
                {
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
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

        private Button _btnClear;

        internal Button btnClear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClear != null)
                {
                    _btnClear.Click -= btnClear_Click;
                }

                _btnClear = value;
                if (_btnClear != null)
                {
                    _btnClear.Click += btnClear_Click;
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

        private ComboBox _cboFilter;

        internal ComboBox cboFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFilter != null)
                {
                    _cboFilter.SelectedIndexChanged -= cboFilter_SelectedIndexChanged;
                }

                _cboFilter = value;
                if (_cboFilter != null)
                {
                    _cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _dgHistory = new DataGrid();
            _Panel1 = new Panel();
            _Label1 = new Label();
            _btnClear = new Button();
            _btnClear.Click += new EventHandler(btnClear_Click);
            _Label2 = new Label();
            _Label3 = new Label();
            _cboFilter = new ComboBox();
            _cboFilter.SelectedIndexChanged += new EventHandler(cboFilter_SelectedIndexChanged);
            ((System.ComponentModel.ISupportInitialize)_dgHistory).BeginInit();
            SuspendLayout();
            //
            // dgHistory
            //
            _dgHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgHistory.DataMember = "";
            _dgHistory.HeaderForeColor = SystemColors.ControlText;
            _dgHistory.Location = new Point(8, 40);
            _dgHistory.Name = "dgHistory";
            _dgHistory.Size = new Size(752, 432);
            _dgHistory.TabIndex = 1;
            //
            // Panel1
            //
            _Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel1.BackColor = Color.Red;
            _Panel1.Location = new Point(8, 488);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(16, 16);
            _Panel1.TabIndex = 19;
            //
            // Label1
            //
            _Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label1.Location = new Point(32, 488);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(168, 16);
            _Label1.TabIndex = 18;
            _Label1.Text = "Out of hours login recorded.";
            //
            // btnClear
            //
            _btnClear.AccessibleDescription = "Clear system interaction history";
            _btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnClear.Cursor = Cursors.Hand;
            _btnClear.UseVisualStyleBackColor = true;
            _btnClear.Location = new Point(712, 480);
            _btnClear.Name = "btnClear";
            _btnClear.Size = new Size(48, 23);
            _btnClear.TabIndex = 3;
            _btnClear.Text = "Clear";
            //
            // Label2
            //
            _Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label2.Location = new Point(216, 488);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(64, 16);
            _Label2.TabIndex = 20;
            _Label2.Text = "Show last ";
            //
            // Label3
            //
            _Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label3.Location = new Point(360, 488);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(64, 16);
            _Label3.TabIndex = 21;
            _Label3.Text = "Records";
            //
            // cboFilter
            //
            _cboFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _cboFilter.Location = new Point(280, 484);
            _cboFilter.Name = "cboFilter";
            _cboFilter.Size = new Size(80, 21);
            _cboFilter.TabIndex = 2;
            _cboFilter.Text = "ComboBox1";
            //
            // FRMHistory
            //
            AcceptButton = _btnClear;
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(768, 510);
            Controls.Add(_cboFilter);
            Controls.Add(_Label3);
            Controls.Add(_Label2);
            Controls.Add(_btnClear);
            Controls.Add(_Panel1);
            Controls.Add(_Label1);
            Controls.Add(_dgHistory);
            MinimumSize = new Size(776, 544);
            Name = "FRMHistory";
            Text = "System History";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_dgHistory, 0);
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_Panel1, 0);
            Controls.SetChildIndex(_btnClear, 0);
            Controls.SetChildIndex(_Label2, 0);
            Controls.SetChildIndex(_Label3, 0);
            Controls.SetChildIndex(_cboFilter, 0);
            ((System.ComponentModel.ISupportInitialize)_dgHistory).EndInit();
            ResumeLayout(false);
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupHistoryDataGrid();
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("ValueMember"));
            DataRow newRow;
            for (int i = 100; i <= 10000; i += +100)
            {
                newRow = dt.NewRow();
                newRow["ValueMember"] = i;
                dt.Rows.Add(newRow);
            }

            var argc = cboFilter;
            Combo.SetUpCombo(ref argc, dt, "ValueMember", "ValueMember", Entity.Sys.Enums.ComboValues.None);
            var argcombo = cboFilter;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 100.ToString());
            PopulatePage();
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

        private DataView _dvHistory;

        private DataView HistoryDataview
        {
            get
            {
                return _dvHistory;
            }

            set
            {
                _dvHistory = value;
                _dvHistory.AllowNew = false;
                _dvHistory.AllowEdit = false;
                _dvHistory.AllowDelete = false;
                _dvHistory.Table.TableName = Entity.Sys.Enums.TableNames.tblHistory.ToString();
                dgHistory.DataSource = HistoryDataview;
            }
        }

        private void SetupHistoryDataGrid()
        {
            var tStyle = dgHistory.TableStyles[0];
            var OutOfHours = new OutOfHoursColourColumn();
            OutOfHours.Format = "";
            OutOfHours.FormatInfo = null;
            OutOfHours.HeaderText = "";
            OutOfHours.MappingName = "OutOfHours";
            OutOfHours.ReadOnly = true;
            OutOfHours.Width = 25;
            OutOfHours.NullText = "";
            tStyle.GridColumnStyles.Add(OutOfHours);
            var AccessDate = new DataGridLabelColumn();
            AccessDate.Format = "dd/MM/yyyy HH:mm";
            AccessDate.FormatInfo = null;
            AccessDate.HeaderText = "Date";
            AccessDate.MappingName = "AccessDate";
            AccessDate.ReadOnly = true;
            AccessDate.Width = 125;
            AccessDate.NullText = "";
            tStyle.GridColumnStyles.Add(AccessDate);
            var User = new DataGridLabelColumn();
            User.Format = "";
            User.FormatInfo = null;
            User.HeaderText = "User";
            User.MappingName = "Fullname";
            User.ReadOnly = true;
            User.Width = 85;
            User.NullText = "";
            tStyle.GridColumnStyles.Add(User);
            var FormTitle = new DataGridLabelColumn();
            FormTitle.Format = "";
            FormTitle.FormatInfo = null;
            FormTitle.HeaderText = "Page ; Action";
            FormTitle.MappingName = "FormTitle";
            FormTitle.ReadOnly = true;
            FormTitle.Width = 185;
            FormTitle.NullText = "";
            tStyle.GridColumnStyles.Add(FormTitle);
            var AccessType = new DataGridLabelColumn();
            AccessType.Format = "";
            AccessType.FormatInfo = null;
            AccessType.HeaderText = "Type";
            AccessType.MappingName = "AccessType";
            AccessType.ReadOnly = true;
            AccessType.Width = 65;
            AccessType.NullText = "";
            tStyle.GridColumnStyles.Add(AccessType);
            var Statement = new DataGridLabelColumn();
            Statement.Format = "";
            Statement.FormatInfo = null;
            Statement.HeaderText = "Statement";
            Statement.MappingName = "Statement";
            Statement.ReadOnly = true;
            Statement.Width = 800;
            Statement.NullText = "";
            tStyle.GridColumnStyles.Add(Statement);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblHistory.ToString();
            dgHistory.TableStyles.Add(tStyle);
        }

        private void FRMHistory_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePage();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.FSMAdmin))
            {
                if ((int)App.ShowMessage("Are you sure you want to delete all records?", MessageBoxButtons.YesNo, (MessageBoxIcon)MsgBoxStyle.Question) == (int)MsgBoxResult.Yes)
                {
                    App.DB.Manager.DeleteHistory();
                    PopulatePage();
                }
            }
        }

        private void PopulatePage()
        {
            try
            {
                HistoryDataview = App.DB.Manager.GetHistory(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboFilter)));
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, (MessageBoxIcon)MsgBoxStyle.Exclamation);
            }
        }
    }
}