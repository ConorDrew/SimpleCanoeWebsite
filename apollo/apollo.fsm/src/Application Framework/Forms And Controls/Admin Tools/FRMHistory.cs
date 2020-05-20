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
            this._dgHistory = new System.Windows.Forms.DataGrid();
            this._Panel1 = new System.Windows.Forms.Panel();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnClear = new System.Windows.Forms.Button();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._cboFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._dgHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgHistory
            // 
            this._dgHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgHistory.DataMember = "";
            this._dgHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgHistory.Location = new System.Drawing.Point(8, 12);
            this._dgHistory.Name = "_dgHistory";
            this._dgHistory.Size = new System.Drawing.Size(752, 460);
            this._dgHistory.TabIndex = 1;
            // 
            // _Panel1
            // 
            this._Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Panel1.BackColor = System.Drawing.Color.Red;
            this._Panel1.Location = new System.Drawing.Point(8, 488);
            this._Panel1.Name = "_Panel1";
            this._Panel1.Size = new System.Drawing.Size(16, 16);
            this._Panel1.TabIndex = 19;
            // 
            // _Label1
            // 
            this._Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label1.Location = new System.Drawing.Point(32, 488);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(168, 16);
            this._Label1.TabIndex = 18;
            this._Label1.Text = "Out of hours login recorded.";
            // 
            // _btnClear
            // 
            this._btnClear.AccessibleDescription = "Clear system interaction history";
            this._btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnClear.Location = new System.Drawing.Point(712, 480);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(48, 23);
            this._btnClear.TabIndex = 3;
            this._btnClear.Text = "Clear";
            this._btnClear.UseVisualStyleBackColor = true;
            this._btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // _Label2
            // 
            this._Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label2.Location = new System.Drawing.Point(216, 488);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(64, 16);
            this._Label2.TabIndex = 20;
            this._Label2.Text = "Show last ";
            // 
            // _Label3
            // 
            this._Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label3.Location = new System.Drawing.Point(360, 488);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(64, 16);
            this._Label3.TabIndex = 21;
            this._Label3.Text = "Records";
            // 
            // _cboFilter
            // 
            this._cboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboFilter.Location = new System.Drawing.Point(280, 484);
            this._cboFilter.Name = "_cboFilter";
            this._cboFilter.Size = new System.Drawing.Size(80, 21);
            this._cboFilter.TabIndex = 2;
            this._cboFilter.Text = "ComboBox1";
            this._cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // FRMHistory
            // 
            this.AcceptButton = this._btnClear;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(768, 510);
            this.Controls.Add(this._cboFilter);
            this.Controls.Add(this._Label3);
            this.Controls.Add(this._Label2);
            this.Controls.Add(this._btnClear);
            this.Controls.Add(this._Panel1);
            this.Controls.Add(this._Label1);
            this.Controls.Add(this._dgHistory);
            this.MinimumSize = new System.Drawing.Size(776, 544);
            this.Name = "FRMHistory";
            this.Text = "System History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this._dgHistory)).EndInit();
            this.ResumeLayout(false);

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