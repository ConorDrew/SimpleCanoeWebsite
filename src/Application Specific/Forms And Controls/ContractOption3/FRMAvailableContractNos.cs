using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class FRMAvailableContractNos : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMAvailableContractNos() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMAvailableContractNos_Load;

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
        private DataGrid _dgAvailableContractNos;

        internal DataGrid dgAvailableContractNos
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAvailableContractNos;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAvailableContractNos != null)
                {
                    _dgAvailableContractNos.Click -= dgAvailableContractNos_Click;
                    _dgAvailableContractNos.CurrentCellChanged -= dgAvailableContractNos_Click;
                }

                _dgAvailableContractNos = value;
                if (_dgAvailableContractNos != null)
                {
                    _dgAvailableContractNos.Click += dgAvailableContractNos_Click;
                    _dgAvailableContractNos.CurrentCellChanged += dgAvailableContractNos_Click;
                }
            }
        }

        private TextBox _txtPrefix;

        internal TextBox txtPrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPrefix != null)
                {
                    _txtPrefix.TextChanged -= txtPrefix_TextChanged;
                }

                _txtPrefix = value;
                if (_txtPrefix != null)
                {
                    _txtPrefix.TextChanged += txtPrefix_TextChanged;
                }
            }
        }

        private TextBox _txtPostfix;

        internal TextBox txtPostfix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPostfix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPostfix != null)
                {
                    _txtPostfix.TextChanged -= txtPostfix_TextChanged;
                }

                _txtPostfix = value;
                if (_txtPostfix != null)
                {
                    _txtPostfix.TextChanged += txtPostfix_TextChanged;
                }
            }
        }

        private Button _btnSelect;

        internal Button btnSelect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelect != null)
                {
                    _btnSelect.Click -= btnSelect_Click;
                }

                _btnSelect = value;
                if (_btnSelect != null)
                {
                    _btnSelect.Click += btnSelect_Click;
                }
            }
        }

        private Label _lblResult;

        internal Label lblResult
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblResult;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblResult != null)
                {
                }

                _lblResult = value;
                if (_lblResult != null)
                {
                }
            }
        }

        private Label _lblPrefix;

        internal Label lblPrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPrefix != null)
                {
                }

                _lblPrefix = value;
                if (_lblPrefix != null)
                {
                }
            }
        }

        private Label _lblPostfix;

        internal Label lblPostfix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPostfix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPostfix != null)
                {
                }

                _lblPostfix = value;
                if (_lblPostfix != null)
                {
                }
            }
        }

        private GroupBox _gpbContractNumbers;

        internal GroupBox gpbContractNumbers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbContractNumbers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbContractNumbers != null)
                {
                }

                _gpbContractNumbers = value;
                if (_gpbContractNumbers != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.Resources.ResourceManager(typeof(FRMAvailableContractNos));
            _dgAvailableContractNos = new DataGrid();
            _dgAvailableContractNos.Click += new EventHandler(dgAvailableContractNos_Click);
            _dgAvailableContractNos.CurrentCellChanged += new EventHandler(dgAvailableContractNos_Click);
            _dgAvailableContractNos.Click += new EventHandler(dgAvailableContractNos_Click);
            _dgAvailableContractNos.CurrentCellChanged += new EventHandler(dgAvailableContractNos_Click);
            _txtPrefix = new TextBox();
            _txtPrefix.TextChanged += new EventHandler(txtPrefix_TextChanged);
            _txtPostfix = new TextBox();
            _txtPostfix.TextChanged += new EventHandler(txtPostfix_TextChanged);
            _lblPrefix = new Label();
            _lblPostfix = new Label();
            _gpbContractNumbers = new GroupBox();
            _lblResult = new Label();
            _btnSelect = new Button();
            _btnSelect.Click += new EventHandler(btnSelect_Click);
            ((System.ComponentModel.ISupportInitialize)_dgAvailableContractNos).BeginInit();
            _gpbContractNumbers.SuspendLayout();
            SuspendLayout();
            // 
            // dgAvailableContractNos
            // 
            _dgAvailableContractNos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAvailableContractNos.DataMember = "";
            _dgAvailableContractNos.HeaderForeColor = SystemColors.ControlText;
            _dgAvailableContractNos.Location = new Point(11, 74);
            _dgAvailableContractNos.Name = "dgAvailableContractNos";
            _dgAvailableContractNos.Size = new Size(293, 301);
            _dgAvailableContractNos.TabIndex = 0;
            // 
            // txtPrefix
            // 
            _txtPrefix.Location = new Point(12, 45);
            _txtPrefix.Name = "txtPrefix";
            _txtPrefix.Size = new Size(120, 21);
            _txtPrefix.TabIndex = 1;
            _txtPrefix.Text = "";
            // 
            // txtPostfix
            // 
            _txtPostfix.Location = new Point(184, 45);
            _txtPostfix.Name = "txtPostfix";
            _txtPostfix.Size = new Size(120, 21);
            _txtPostfix.TabIndex = 2;
            _txtPostfix.Text = "";
            // 
            // lblPrefix
            // 

            _lblPrefix.Location = new Point(11, 23);
            _lblPrefix.Name = "lblPrefix";
            _lblPrefix.Size = new Size(120, 17);
            _lblPrefix.TabIndex = 3;
            _lblPrefix.Text = "Prefix:";
            // 
            // lblPostfix
            // 

            _lblPostfix.Location = new Point(180, 23);
            _lblPostfix.Name = "lblPostfix";
            _lblPostfix.Size = new Size(120, 17);
            _lblPostfix.TabIndex = 4;
            _lblPostfix.Text = "Postfix";
            // 
            // gpbContractNumbers
            // 
            _gpbContractNumbers.Controls.Add(_lblResult);
            _gpbContractNumbers.Controls.Add(_btnSelect);
            _gpbContractNumbers.Controls.Add(_lblPrefix);
            _gpbContractNumbers.Controls.Add(_txtPrefix);
            _gpbContractNumbers.Controls.Add(_lblPostfix);
            _gpbContractNumbers.Controls.Add(_txtPostfix);
            _gpbContractNumbers.Controls.Add(_dgAvailableContractNos);
            _gpbContractNumbers.Location = new Point(11, 39);
            _gpbContractNumbers.Name = "gpbContractNumbers";
            _gpbContractNumbers.Size = new Size(319, 414);
            _gpbContractNumbers.TabIndex = 5;
            _gpbContractNumbers.TabStop = false;
            _gpbContractNumbers.Text = "Contract Numbers";
            // 
            // lblResult

            _lblResult.Location = new Point(12, 380);
            _lblResult.Name = "lblResult";
            _lblResult.Size = new Size(197, 25);
            _lblResult.TabIndex = 6;
            _lblResult.Text = "Label3";
            // 
            // btnSelect
            // 
            _btnSelect.Cursor = Cursors.Hand;
            _btnSelect.UseVisualStyleBackColor = true;
            _btnSelect.Location = new Point(217, 381);
            _btnSelect.Name = "btnSelect";
            _btnSelect.Size = new Size(90, 25);
            _btnSelect.TabIndex = 5;
            _btnSelect.Text = "&Select";
            // 
            // FRMAvailableContractNos
            // 
            AutoScaleBaseSize = new Size(6, 14);
            BackColor = Color.White;
            ClientSize = new Size(340, 458);
            Controls.Add(_gpbContractNumbers);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(346, 490);
            MinimizeBox = false;
            MinimumSize = new Size(346, 490);
            Name = "FRMAvailableContractNos";
            Text = "Available Contract Nos";
            Controls.SetChildIndex(_gpbContractNumbers, 0);
            ((System.ComponentModel.ISupportInitialize)_dgAvailableContractNos).EndInit();
            _gpbContractNumbers.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            txtRef = (TextBox)get_GetParameter(0);
            LoadForm(sender, e, this);
            SetupContractsDataGrid();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return default;
            }
        }

        public void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public TextBox txtRef;
        private DataView _dvContracts;

        private DataView ContractsDataview
        {
            get
            {
                return _dvContracts;
            }

            set
            {
                _dvContracts = value;
                _dvContracts.AllowNew = false;
                _dvContracts.AllowEdit = false;
                _dvContracts.AllowDelete = false;
                _dvContracts.Table.TableName = Entity.Sys.Enums.TableNames.tblContractOption3.ToString();
                dgAvailableContractNos.DataSource = ContractsDataview;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupContractsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgAvailableContractNos);
            var tbStyle = dgAvailableContractNos.TableStyles[0];
            var ContractName = new DataGridLabelColumn();
            ContractName.Format = "";
            ContractName.FormatInfo = null;
            ContractName.HeaderText = "Reference";
            ContractName.MappingName = "Ref";
            ContractName.ReadOnly = true;
            ContractName.Width = 135;
            ContractName.NullText = "";
            tbStyle.GridColumnStyles.Add(ContractName);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractOption3.ToString();
            dgAvailableContractNos.TableStyles.Add(tbStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void PopulatePage()
        {
            try
            {
                ContractsDataview = new DataView(App.DB.ContractOption3.ContractReference_Get(txtPrefix.Text, txtPostfix.Text));
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Available contract numbers cannot be loaded : " + ex.Message, MsgBoxStyle.Exclamation);
            }

            PopulateResult();
        }

        private void PopulateResult()
        {
            lblResult.Text = "";
            if (txtPrefix.Text.Trim().Length > 0)
            {
                lblResult.Text = txtPrefix.Text + "/";
            }

            lblResult.Text += ContractsDataview[dgAvailableContractNos.CurrentRowIndex]["REF"];
            if (txtPostfix.Text.Trim().Length > 0)
            {
                lblResult.Text += "/" + txtPostfix.Text;
            }
        }

        private void FRMAvailableContractNos_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
            SetupContractsDataGrid();
            PopulatePage();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lblResult.Text.Trim().Length > 0)
            {
                txtRef.Text = lblResult.Text;
                if (Modal)
                {
                    Close();
                }
                else
                {
                    Dispose();
                }
            }
        }

        private void txtPrefix_TextChanged(object sender, EventArgs e)
        {
            if (txtPrefix.Text.Length > 0)
            {
                if (Information.IsNumeric(txtPrefix.Text.Substring(txtPrefix.Text.Length - 1, 1)) | (txtPrefix.Text.Substring(txtPrefix.Text.Length - 1, 1) ?? "") == "/")
                {
                    txtPrefix.Text = txtPrefix.Text.Substring(0, txtPrefix.Text.Length - 1);
                }
            }

            PopulatePage();
            txtPrefix.Focus();
        }

        private void txtPostfix_TextChanged(object sender, EventArgs e)
        {
            if (txtPostfix.Text.Length > 0)
            {
                if (Information.IsNumeric(txtPostfix.Text.Substring(txtPostfix.Text.Length - 1, 1)) | (txtPostfix.Text.Substring(txtPostfix.Text.Length - 1, 1) ?? "") == "/")
                {
                    txtPostfix.Text = txtPostfix.Text.Substring(0, txtPostfix.Text.Length - 1);
                }
            }

            PopulatePage();
            txtPostfix.Focus();
        }

        private void dgAvailableContractNos_Click(object sender, EventArgs e)
        {
            PopulateResult();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}