using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMViewEngineer : FRMBaseForm, IForm
    {
        public FRMViewEngineer()
        {
            
            
            base.Load += FRMEngineer_Load;
        }

        

        public FRMViewEngineer(DataTable dtEngineer) : base()
        {
            base.Load += FRMEngineer_Load;
            Engineer = dtEngineer;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        private GroupBox _grpEngineerInfo;

        internal GroupBox grpEngineerInfo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineerInfo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineerInfo != null)
                {
                }

                _grpEngineerInfo = value;
                if (_grpEngineerInfo != null)
                {
                }
            }
        }

        private TextBox _txtPhone;

        internal TextBox txtPhone
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPhone;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPhone != null)
                {
                }

                _txtPhone = value;
                if (_txtPhone != null)
                {
                }
            }
        }

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        private Label _lblEngGroup;

        internal Label lblEngGroup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngGroup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngGroup != null)
                {
                }

                _lblEngGroup = value;
                if (_lblEngGroup != null)
                {
                }
            }
        }

        private Label _lblRegion;

        internal Label lblRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRegion != null)
                {
                }

                _lblRegion = value;
                if (_lblRegion != null)
                {
                }
            }
        }

        private Label _lblDepartment;

        internal Label lblDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDepartment != null)
                {
                }

                _lblDepartment = value;
                if (_lblDepartment != null)
                {
                }
            }
        }

        private Label _lblTelNum;

        internal Label lblTelNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTelNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTelNum != null)
                {
                }

                _lblTelNum = value;
                if (_lblTelNum != null)
                {
                }
            }
        }

        private Label _lblManName;

        internal Label lblManName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblManName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblManName != null)
                {
                }

                _lblManName = value;
                if (_lblManName != null)
                {
                }
            }
        }

        private Label _lblName;

        internal Label lblName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblName != null)
                {
                }

                _lblName = value;
                if (_lblName != null)
                {
                }
            }
        }

        private FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter _Customer_Get_ForSiteIDTableAdapter1;

        internal FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter Customer_Get_ForSiteIDTableAdapter1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Customer_Get_ForSiteIDTableAdapter1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Customer_Get_ForSiteIDTableAdapter1 != null)
                {
                }

                _Customer_Get_ForSiteIDTableAdapter1 = value;
                if (_Customer_Get_ForSiteIDTableAdapter1 != null)
                {
                }
            }
        }

        private GroupBox _grpPostcodes;

        internal GroupBox grpPostcodes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPostcodes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPostcodes != null)
                {
                }

                _grpPostcodes = value;
                if (_grpPostcodes != null)
                {
                }
            }
        }

        private TextBox _txtPostcode;

        internal TextBox txtPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPostcode != null)
                {
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
                {
                }
            }
        }

        private GroupBox _grpQualifications;

        internal GroupBox grpQualifications
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpQualifications;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpQualifications != null)
                {
                }

                _grpQualifications = value;
                if (_grpQualifications != null)
                {
                }
            }
        }

        private TextBox _txtQual;

        internal TextBox txtQual
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQual;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQual != null)
                {
                }

                _txtQual = value;
                if (_txtQual != null)
                {
                }
            }
        }

        private TextBox _txtRegion;

        internal TextBox txtRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRegion != null)
                {
                }

                _txtRegion = value;
                if (_txtRegion != null)
                {
                }
            }
        }

        private TextBox _txtManager;

        internal TextBox txtManager
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtManager;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtManager != null)
                {
                }

                _txtManager = value;
                if (_txtManager != null)
                {
                }
            }
        }

        private TextBox _txtDepartment;

        internal TextBox txtDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDepartment != null)
                {
                }

                _txtDepartment = value;
                if (_txtDepartment != null)
                {
                }
            }
        }

        private TextBox _txtEngineerGroup;

        internal TextBox txtEngineerGroup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineerGroup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineerGroup != null)
                {
                }

                _txtEngineerGroup = value;
                if (_txtEngineerGroup != null)
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
            _grpEngineerInfo = new GroupBox();
            _txtManager = new TextBox();
            _txtDepartment = new TextBox();
            _txtEngineerGroup = new TextBox();
            _txtRegion = new TextBox();
            _txtPhone = new TextBox();
            _txtName = new TextBox();
            _lblEngGroup = new Label();
            _lblRegion = new Label();
            _lblDepartment = new Label();
            _lblTelNum = new Label();
            _lblManName = new Label();
            _lblName = new Label();
            _Customer_Get_ForSiteIDTableAdapter1 = new FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter();
            _grpPostcodes = new GroupBox();
            _txtPostcode = new TextBox();
            _grpQualifications = new GroupBox();
            _txtQual = new TextBox();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _grpEngineerInfo.SuspendLayout();
            _grpPostcodes.SuspendLayout();
            _grpQualifications.SuspendLayout();
            SuspendLayout();
            //
            // grpEngineerInfo
            //
            _grpEngineerInfo.Controls.Add(_txtManager);
            _grpEngineerInfo.Controls.Add(_txtDepartment);
            _grpEngineerInfo.Controls.Add(_txtEngineerGroup);
            _grpEngineerInfo.Controls.Add(_txtRegion);
            _grpEngineerInfo.Controls.Add(_txtPhone);
            _grpEngineerInfo.Controls.Add(_txtName);
            _grpEngineerInfo.Controls.Add(_lblEngGroup);
            _grpEngineerInfo.Controls.Add(_lblRegion);
            _grpEngineerInfo.Controls.Add(_lblDepartment);
            _grpEngineerInfo.Controls.Add(_lblTelNum);
            _grpEngineerInfo.Controls.Add(_lblManName);
            _grpEngineerInfo.Controls.Add(_lblName);
            _grpEngineerInfo.Enabled = false;
            _grpEngineerInfo.Location = new Point(0, 53);
            _grpEngineerInfo.Name = "grpEngineerInfo";
            _grpEngineerInfo.Size = new Size(829, 146);
            _grpEngineerInfo.TabIndex = 1;
            _grpEngineerInfo.TabStop = false;
            _grpEngineerInfo.Text = "Engineer Information";
            //
            // txtManager
            //
            _txtManager.Enabled = false;
            _txtManager.Location = new Point(560, 31);
            _txtManager.Name = "txtManager";
            _txtManager.Size = new Size(247, 21);
            _txtManager.TabIndex = 64;
            //
            // txtDepartment
            //
            _txtDepartment.Enabled = false;
            _txtDepartment.Location = new Point(560, 60);
            _txtDepartment.Name = "txtDepartment";
            _txtDepartment.Size = new Size(247, 21);
            _txtDepartment.TabIndex = 63;
            //
            // txtEngineerGroup
            //
            _txtEngineerGroup.Enabled = false;
            _txtEngineerGroup.Location = new Point(560, 90);
            _txtEngineerGroup.Name = "txtEngineerGroup";
            _txtEngineerGroup.Size = new Size(247, 21);
            _txtEngineerGroup.TabIndex = 62;
            //
            // txtRegion
            //
            _txtRegion.Enabled = false;
            _txtRegion.Location = new Point(120, 90);
            _txtRegion.Name = "txtRegion";
            _txtRegion.Size = new Size(247, 21);
            _txtRegion.TabIndex = 61;
            //
            // txtPhone
            //
            _txtPhone.Enabled = false;
            _txtPhone.Location = new Point(120, 60);
            _txtPhone.Name = "txtPhone";
            _txtPhone.Size = new Size(247, 21);
            _txtPhone.TabIndex = 8;
            //
            // txtName
            //
            _txtName.Enabled = false;
            _txtName.Location = new Point(120, 31);
            _txtName.Name = "txtName";
            _txtName.Size = new Size(247, 21);
            _txtName.TabIndex = 6;
            //
            // lblEngGroup
            //
            _lblEngGroup.AutoSize = true;
            _lblEngGroup.Location = new Point(453, 93);
            _lblEngGroup.Name = "lblEngGroup";
            _lblEngGroup.Size = new Size(101, 13);
            _lblEngGroup.TabIndex = 5;
            _lblEngGroup.Text = "Engineer Group:";
            //
            // lblRegion
            //
            _lblRegion.AutoSize = true;
            _lblRegion.Location = new Point(12, 93);
            _lblRegion.Name = "lblRegion";
            _lblRegion.Size = new Size(51, 13);
            _lblRegion.TabIndex = 4;
            _lblRegion.Text = "Region:";
            //
            // lblDepartment
            //
            _lblDepartment.AutoSize = true;
            _lblDepartment.Location = new Point(453, 63);
            _lblDepartment.Name = "lblDepartment";
            _lblDepartment.Size = new Size(80, 13);
            _lblDepartment.TabIndex = 3;
            _lblDepartment.Text = "Department:";
            //
            // lblTelNum
            //
            _lblTelNum.AutoSize = true;
            _lblTelNum.Location = new Point(12, 63);
            _lblTelNum.Name = "lblTelNum";
            _lblTelNum.Size = new Size(96, 13);
            _lblTelNum.TabIndex = 2;
            _lblTelNum.Text = "Phone Number:";
            //
            // lblManName
            //
            _lblManName.AutoSize = true;
            _lblManName.Location = new Point(453, 34);
            _lblManName.Name = "lblManName";
            _lblManName.Size = new Size(61, 13);
            _lblManName.TabIndex = 1;
            _lblManName.Text = "Manager:";
            //
            // lblName
            //
            _lblName.AutoSize = true;
            _lblName.Location = new Point(12, 34);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(45, 13);
            _lblName.TabIndex = 0;
            _lblName.Text = "Name:";
            //
            // Customer_Get_ForSiteIDTableAdapter1
            //
            _Customer_Get_ForSiteIDTableAdapter1.ClearBeforeFill = true;
            //
            // grpPostcodes
            //
            _grpPostcodes.Controls.Add(_txtPostcode);
            _grpPostcodes.Location = new Point(0, 205);
            _grpPostcodes.Name = "grpPostcodes";
            _grpPostcodes.Size = new Size(829, 159);
            _grpPostcodes.TabIndex = 2;
            _grpPostcodes.TabStop = false;
            _grpPostcodes.Text = "Postcodes";
            //
            // txtPostcode
            //
            _txtPostcode.Location = new Point(15, 25);
            _txtPostcode.Multiline = true;
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.ReadOnly = true;
            _txtPostcode.ScrollBars = ScrollBars.Vertical;
            _txtPostcode.Size = new Size(792, 116);
            _txtPostcode.TabIndex = 0;
            //
            // grpQualifications
            //
            _grpQualifications.Controls.Add(_txtQual);
            _grpQualifications.Location = new Point(0, 370);
            _grpQualifications.Name = "grpQualifications";
            _grpQualifications.Size = new Size(829, 159);
            _grpQualifications.TabIndex = 3;
            _grpQualifications.TabStop = false;
            _grpQualifications.Text = "Qualifications";
            //
            // txtQual
            //
            _txtQual.Location = new Point(15, 25);
            _txtQual.Multiline = true;
            _txtQual.Name = "txtQual";
            _txtQual.ReadOnly = true;
            _txtQual.ScrollBars = ScrollBars.Vertical;
            _txtQual.Size = new Size(792, 116);
            _txtQual.TabIndex = 0;
            //
            // btnClose
            //
            _btnClose.Location = new Point(15, 532);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(75, 23);
            _btnClose.TabIndex = 4;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            //
            // FRMViewEngineer
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(829, 561);
            Controls.Add(_btnClose);
            Controls.Add(_grpQualifications);
            Controls.Add(_grpPostcodes);
            Controls.Add(_grpEngineerInfo);
            MaximumSize = new Size(845, 600);
            MinimizeBox = false;
            MinimumSize = new Size(845, 600);
            Name = "FRMViewEngineer";
            Text = "Viewing Engineer : ";
            Controls.SetChildIndex(_grpEngineerInfo, 0);
            Controls.SetChildIndex(_grpPostcodes, 0);
            Controls.SetChildIndex(_grpQualifications, 0);
            Controls.SetChildIndex(_btnClose, 0);
            _grpEngineerInfo.ResumeLayout(false);
            _grpEngineerInfo.PerformLayout();
            _grpPostcodes.ResumeLayout(false);
            _grpPostcodes.PerformLayout();
            _grpQualifications.ResumeLayout(false);
            _grpQualifications.PerformLayout();
            ResumeLayout(false);
        }

        
        

        private void LoadMe(object sender, EventArgs e)
        {
            Populate();
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

        
        
        private DataTable _engineer = null;

        public DataTable Engineer
        {
            get
            {
                return _engineer;
            }

            set
            {
                _engineer = value;
            }
        }

        private void FRMEngineer_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void Populate()
        {
            Text = Conversions.ToString("Viewing Engineer : " + (DataTable)Engineer.Rows[0]["Name"]);
            if (!Information.IsDBNull(Engineer.Rows[0]["Name"]))
            {
                txtName.Text = Conversions.ToString(Engineer.Rows[0]["Name"]);
            }
            else
            {
                txtName.Text = "<<No Name set>>";
            }

            if (!Information.IsDBNull(Engineer.Rows[0]["TelephoneNum"]))
            {
                txtPhone.Text = "<<No Phone Number Set>>";
            }
            else
            {
                txtPhone.Text = Conversions.ToString(Engineer.Rows[0]["TelephoneNum"]);
            }

            if (!Information.IsDBNull(Engineer.Rows[0]["Region"]))
            {
                txtRegion.Text = Conversions.ToString(Engineer.Rows[0]["Region"]);
            }
            else
            {
                txtRegion.Text = "<<No Region set>>";
            }

            if (!Information.IsDBNull(Engineer.Rows[0]["Manager"]))
            {
                txtManager.Text = Conversions.ToString(Engineer.Rows[0]["Manager"]);
            }
            else
            {
                txtManager.Text = "<<No Manager set>>";
            }

            if (!Information.IsDBNull(Engineer.Rows[0]["Department"]))
            {
                txtDepartment.Text = Conversions.ToString(Engineer.Rows[0]["Department"]);
            }
            else
            {
                txtDepartment.Text = "<<No Department set>>";
            }

            if (!Information.IsDBNull(Engineer.Rows[0]["EngineerGroup"]))
            {
                txtEngineerGroup.Text = Conversions.ToString(Engineer.Rows[0]["EngineerGroup"]);
            }
            else
            {
                txtEngineerGroup.Text = "<<No Engineer Group set>>";
            }

            if (!Information.IsDBNull(Engineer.Rows[0]["PostCodes"]))
            {
                txtPostcode.Text = Conversions.ToString(Engineer.Rows[0]["PostCodes"]);
            }
            else
            {
                txtPostcode.Text = "<<No PostCodes set >>";
            }

            if (!Information.IsDBNull(Engineer.Rows[0]["Qualifications"]))
            {
                txtQual.Text = Conversions.ToString(Engineer.Rows[0]["Qualifications"]);
            }
            else
            {
                txtQual.Text = "<<No Qualifications set>>";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        void IForm.LoadMe(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        
    }
}