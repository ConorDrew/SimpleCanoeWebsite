using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class DLGSetupVisit : FRMBaseForm, IForm
    {
        public DLGSetupVisit() : base()
        {
            base.Load += DLGFindRecord_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboFrequency;
            Combo.SetUpCombo(ref argc, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboType;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.ContractVisitType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc2 = cboPreferredEngineer;
            Combo.SetUpCombo(ref argc2, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable);
            var argc3 = cboSubContractor;
            Combo.SetUpCombo(ref argc3, App.DB.SubContractor.Subcontractor_GetAll().Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable);

            // Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

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

        private DateTimePicker _dtpTargetDate;

        internal DateTimePicker dtpTargetDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTargetDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTargetDate != null)
                {
                }

                _dtpTargetDate = value;
                if (_dtpTargetDate != null)
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

        private Button _btnOK;

        internal Button btnOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
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

        private ComboBox _cboFrequency;

        internal ComboBox cboFrequency
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFrequency;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFrequency != null)
                {
                    _cboFrequency.SelectedIndexChanged -= cboFrequency_SelectedIndexChanged;
                }

                _cboFrequency = value;
                if (_cboFrequency != null)
                {
                    _cboFrequency.SelectedIndexChanged += cboFrequency_SelectedIndexChanged;
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

        private ComboBox _cboPreferredEngineer;

        internal ComboBox cboPreferredEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPreferredEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPreferredEngineer != null)
                {
                }

                _cboPreferredEngineer = value;
                if (_cboPreferredEngineer != null)
                {
                }
            }
        }

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
                {
                }
            }
        }

        private ComboBox _cboSubContractor;

        internal ComboBox cboSubContractor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSubContractor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSubContractor != null)
                {
                }

                _cboSubContractor = value;
                if (_cboSubContractor != null)
                {
                }
            }
        }

        private CheckBox _CheckBox1;

        internal CheckBox CheckBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CheckBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CheckBox1 != null)
                {
                    _CheckBox1.CheckedChanged -= CheckBox1_CheckedChanged;
                }

                _CheckBox1 = value;
                if (_CheckBox1 != null)
                {
                    _CheckBox1.CheckedChanged += CheckBox1_CheckedChanged;
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

        private TextBox _txtFilter;

        internal TextBox txtFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFilter != null)
                {
                }

                _txtFilter = value;
                if (_txtFilter != null)
                {
                }
            }
        }

        private TextBox _TextBox1;

        internal TextBox TextBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBox1 != null)
                {
                    _TextBox1.TextChanged -= TextBox1_TextChanged;
                }

                _TextBox1 = value;
                if (_TextBox1 != null)
                {
                    _TextBox1.TextChanged += TextBox1_TextChanged;
                }
            }
        }

        private Label _Label7;

        private TextBox _txtAdditional;

        internal TextBox txtAdditional
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAdditional;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAdditional != null)
                {
                }

                _txtAdditional = value;
                if (_txtAdditional != null)
                {
                }
            }
        }

        private Label _Label8;

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                }

                _cboType = value;
                if (_cboType != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _Label4 = new Label();
            _dtpTargetDate = new DateTimePicker();
            _Label3 = new Label();
            _cboType = new ComboBox();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _Label2 = new Label();
            _cboFrequency = new ComboBox();
            _cboFrequency.SelectedIndexChanged += new EventHandler(cboFrequency_SelectedIndexChanged);
            _Label5 = new Label();
            _cboPreferredEngineer = new ComboBox();
            _Label6 = new Label();
            _cboSubContractor = new ComboBox();
            _CheckBox1 = new CheckBox();
            _CheckBox1.CheckedChanged += new EventHandler(CheckBox1_CheckedChanged);
            _Label1 = new Label();
            _txtFilter = new TextBox();
            _TextBox1 = new TextBox();
            _TextBox1.TextChanged += new EventHandler(TextBox1_TextChanged);
            _Label7 = new Label();
            _txtAdditional = new TextBox();
            _Label8 = new Label();
            SuspendLayout();
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(8, 451);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(56, 23);
            _btnCancel.TabIndex = 4;
            _btnCancel.Text = "Cancel";
            //
            // Label4
            //
            _Label4.Location = new Point(8, 144);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(95, 24);
            _Label4.TabIndex = 12;
            _Label4.Text = "Target Date";
            //
            // dtpTargetDate
            //
            _dtpTargetDate.Location = new Point(122, 140);
            _dtpTargetDate.Name = "dtpTargetDate";
            _dtpTargetDate.Size = new Size(298, 21);
            _dtpTargetDate.TabIndex = 3;
            //
            // Label3
            //
            _Label3.Location = new Point(10, 76);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(93, 15);
            _Label3.TabIndex = 10;
            _Label3.Text = "Visit Type";
            //
            // cboType
            //
            _cboType.FormattingEnabled = true;
            _cboType.Location = new Point(122, 73);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(298, 21);
            _cboType.TabIndex = 1;
            //
            // btnOK
            //
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(364, 454);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(56, 23);
            _btnOK.TabIndex = 3;
            _btnOK.Text = "OK";
            //
            // Label2
            //
            _Label2.Location = new Point(10, 109);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(93, 15);
            _Label2.TabIndex = 14;
            _Label2.Text = "Frequency";
            //
            // cboFrequency
            //
            _cboFrequency.FormattingEnabled = true;
            _cboFrequency.Location = new Point(122, 106);
            _cboFrequency.Name = "cboFrequency";
            _cboFrequency.Size = new Size(298, 21);
            _cboFrequency.TabIndex = 2;
            //
            // Label5
            //
            _Label5.Location = new Point(8, 177);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(112, 18);
            _Label5.TabIndex = 16;
            _Label5.Text = "Prefered Engineer";
            //
            // cboPreferredEngineer
            //
            _cboPreferredEngineer.FormattingEnabled = true;
            _cboPreferredEngineer.Location = new Point(122, 173);
            _cboPreferredEngineer.Name = "cboPreferredEngineer";
            _cboPreferredEngineer.Size = new Size(298, 21);
            _cboPreferredEngineer.TabIndex = 5;
            //
            // Label6
            //
            _Label6.Location = new Point(10, 214);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(106, 15);
            _Label6.TabIndex = 18;
            _Label6.Text = "Sub Contractor";
            //
            // cboSubContractor
            //
            _cboSubContractor.FormattingEnabled = true;
            _cboSubContractor.Location = new Point(122, 211);
            _cboSubContractor.Name = "cboSubContractor";
            _cboSubContractor.Size = new Size(298, 21);
            _cboSubContractor.TabIndex = 6;
            //
            // CheckBox1
            //
            _CheckBox1.AutoSize = true;
            _CheckBox1.Location = new Point(13, 369);
            _CheckBox1.Name = "CheckBox1";
            _CheckBox1.Size = new Size(133, 17);
            _CheckBox1.TabIndex = 19;
            _CheckBox1.Text = "System Generated";
            _CheckBox1.UseVisualStyleBackColor = true;
            _CheckBox1.Visible = false;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 283);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(100, 24);
            _Label1.TabIndex = 2;
            _Label1.Text = "Expected Cost";
            //
            // txtFilter
            //
            _txtFilter.Location = new Point(122, 281);
            _txtFilter.Name = "txtFilter";
            _txtFilter.Size = new Size(298, 21);
            _txtFilter.TabIndex = 25;
            //
            // TextBox1
            //
            _TextBox1.Location = new Point(122, 246);
            _TextBox1.Name = "TextBox1";
            _TextBox1.Size = new Size(298, 21);
            _TextBox1.TabIndex = 20;
            //
            // Label7
            //
            _Label7.Location = new Point(8, 248);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(100, 24);
            _Label7.TabIndex = 21;
            _Label7.Text = "Hours Required";
            //
            // txtAdditional
            //
            _txtAdditional.Location = new Point(122, 314);
            _txtAdditional.Multiline = true;
            _txtAdditional.Name = "txtAdditional";
            _txtAdditional.Size = new Size(298, 125);
            _txtAdditional.TabIndex = 30;
            //
            // Label8
            //
            _Label8.Location = new Point(8, 316);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(100, 24);
            _Label8.TabIndex = 23;
            _Label8.Text = "Additional Notes";
            //
            // DLGSetupVisit
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(432, 481);
            ControlBox = false;
            Controls.Add(_txtAdditional);
            Controls.Add(_Label8);
            Controls.Add(_TextBox1);
            Controls.Add(_Label7);
            Controls.Add(_CheckBox1);
            Controls.Add(_Label6);
            Controls.Add(_cboSubContractor);
            Controls.Add(_Label5);
            Controls.Add(_cboPreferredEngineer);
            Controls.Add(_Label2);
            Controls.Add(_cboFrequency);
            Controls.Add(_Label4);
            Controls.Add(_dtpTargetDate);
            Controls.Add(_Label3);
            Controls.Add(_cboType);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            Controls.Add(_txtFilter);
            Controls.Add(_Label1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(350, 392);
            Name = "DLGSetupVisit";
            Text = "Find {0}";
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_txtFilter, 0);
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_cboType, 0);
            Controls.SetChildIndex(_Label3, 0);
            Controls.SetChildIndex(_dtpTargetDate, 0);
            Controls.SetChildIndex(_Label4, 0);
            Controls.SetChildIndex(_cboFrequency, 0);
            Controls.SetChildIndex(_Label2, 0);
            Controls.SetChildIndex(_cboPreferredEngineer, 0);
            Controls.SetChildIndex(_Label5, 0);
            Controls.SetChildIndex(_cboSubContractor, 0);
            Controls.SetChildIndex(_Label6, 0);
            Controls.SetChildIndex(_CheckBox1, 0);
            Controls.SetChildIndex(_Label7, 0);
            Controls.SetChildIndex(_TextBox1, 0);
            Controls.SetChildIndex(_Label8, 0);
            Controls.SetChildIndex(_txtAdditional, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            ActiveControl = txtFilter;
            txtFilter.Focus();
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

        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        private string _2ndID = 0.ToString();

        public string SecondID
        {
            get
            {
                return _2ndID;
            }

            set
            {
                _2ndID = value;
            }
        }

        private string _FrequencyID = 0.ToString();

        private DateTime _EffDate = DateTime.MinValue;

        private void cboFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboFrequency)) == 7)
            {
                CheckBox1.Enabled = true;
                dtpTargetDate.Enabled = true;
            }
            else
            {
                CheckBox1.Checked = true;
                CheckBox1.Enabled = false;
                dtpTargetDate.Enabled = false;
            }
        }

        private void DLGFindRecord_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((Combo.get_GetSelectedItemValue(cboType) ?? "") == "0")
            {
                App.ShowMessage("No type selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboFrequency)) == 0)
                {
                    App.ShowMessage("No Frequency selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (!Information.IsNumeric(txtFilter.Text))
                {
                    App.ShowMessage("Please only input numbers into the cost box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (!Information.IsNumeric(TextBox1.Text) || Conversions.ToInteger(TextBox1.Text) == 0)
                {
                    App.ShowMessage("Please enter a valid number into the Hours Required box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                dtpTargetDate.Enabled = false;
            }
            else
            {
                dtpTargetDate.Enabled = true;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}