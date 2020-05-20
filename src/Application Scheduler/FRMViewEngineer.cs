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

        private Label _lblRegion;

        private Label _lblDepartment;

        private Label _lblTelNum;

        private Label _lblManName;

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

        private GroupBox _grpPostcodes;

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
            this._grpEngineerInfo = new System.Windows.Forms.GroupBox();
            this._txtManager = new System.Windows.Forms.TextBox();
            this._txtDepartment = new System.Windows.Forms.TextBox();
            this._txtEngineerGroup = new System.Windows.Forms.TextBox();
            this._txtRegion = new System.Windows.Forms.TextBox();
            this._txtPhone = new System.Windows.Forms.TextBox();
            this._txtName = new System.Windows.Forms.TextBox();
            this._lblEngGroup = new System.Windows.Forms.Label();
            this._lblRegion = new System.Windows.Forms.Label();
            this._lblDepartment = new System.Windows.Forms.Label();
            this._lblTelNum = new System.Windows.Forms.Label();
            this._lblManName = new System.Windows.Forms.Label();
            this._lblName = new System.Windows.Forms.Label();
            this._grpPostcodes = new System.Windows.Forms.GroupBox();
            this._txtPostcode = new System.Windows.Forms.TextBox();
            this._grpQualifications = new System.Windows.Forms.GroupBox();
            this._txtQual = new System.Windows.Forms.TextBox();
            this._btnClose = new System.Windows.Forms.Button();
            this._grpEngineerInfo.SuspendLayout();
            this._grpPostcodes.SuspendLayout();
            this._grpQualifications.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpEngineerInfo
            // 
            this._grpEngineerInfo.Controls.Add(this._txtManager);
            this._grpEngineerInfo.Controls.Add(this._txtDepartment);
            this._grpEngineerInfo.Controls.Add(this._txtEngineerGroup);
            this._grpEngineerInfo.Controls.Add(this._txtRegion);
            this._grpEngineerInfo.Controls.Add(this._txtPhone);
            this._grpEngineerInfo.Controls.Add(this._txtName);
            this._grpEngineerInfo.Controls.Add(this._lblEngGroup);
            this._grpEngineerInfo.Controls.Add(this._lblRegion);
            this._grpEngineerInfo.Controls.Add(this._lblDepartment);
            this._grpEngineerInfo.Controls.Add(this._lblTelNum);
            this._grpEngineerInfo.Controls.Add(this._lblManName);
            this._grpEngineerInfo.Controls.Add(this._lblName);
            this._grpEngineerInfo.Enabled = false;
            this._grpEngineerInfo.Location = new System.Drawing.Point(0, 12);
            this._grpEngineerInfo.Name = "_grpEngineerInfo";
            this._grpEngineerInfo.Size = new System.Drawing.Size(829, 137);
            this._grpEngineerInfo.TabIndex = 1;
            this._grpEngineerInfo.TabStop = false;
            this._grpEngineerInfo.Text = "Engineer Information";
            // 
            // _txtManager
            // 
            this._txtManager.Enabled = false;
            this._txtManager.Location = new System.Drawing.Point(560, 31);
            this._txtManager.Name = "_txtManager";
            this._txtManager.Size = new System.Drawing.Size(247, 21);
            this._txtManager.TabIndex = 64;
            // 
            // _txtDepartment
            // 
            this._txtDepartment.Enabled = false;
            this._txtDepartment.Location = new System.Drawing.Point(560, 60);
            this._txtDepartment.Name = "_txtDepartment";
            this._txtDepartment.Size = new System.Drawing.Size(247, 21);
            this._txtDepartment.TabIndex = 63;
            // 
            // _txtEngineerGroup
            // 
            this._txtEngineerGroup.Enabled = false;
            this._txtEngineerGroup.Location = new System.Drawing.Point(560, 90);
            this._txtEngineerGroup.Name = "_txtEngineerGroup";
            this._txtEngineerGroup.Size = new System.Drawing.Size(247, 21);
            this._txtEngineerGroup.TabIndex = 62;
            // 
            // _txtRegion
            // 
            this._txtRegion.Enabled = false;
            this._txtRegion.Location = new System.Drawing.Point(120, 90);
            this._txtRegion.Name = "_txtRegion";
            this._txtRegion.Size = new System.Drawing.Size(247, 21);
            this._txtRegion.TabIndex = 61;
            // 
            // _txtPhone
            // 
            this._txtPhone.Enabled = false;
            this._txtPhone.Location = new System.Drawing.Point(120, 60);
            this._txtPhone.Name = "_txtPhone";
            this._txtPhone.Size = new System.Drawing.Size(247, 21);
            this._txtPhone.TabIndex = 8;
            // 
            // _txtName
            // 
            this._txtName.Enabled = false;
            this._txtName.Location = new System.Drawing.Point(120, 31);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(247, 21);
            this._txtName.TabIndex = 6;
            // 
            // _lblEngGroup
            // 
            this._lblEngGroup.AutoSize = true;
            this._lblEngGroup.Location = new System.Drawing.Point(453, 93);
            this._lblEngGroup.Name = "_lblEngGroup";
            this._lblEngGroup.Size = new System.Drawing.Size(101, 13);
            this._lblEngGroup.TabIndex = 5;
            this._lblEngGroup.Text = "Engineer Group:";
            // 
            // _lblRegion
            // 
            this._lblRegion.AutoSize = true;
            this._lblRegion.Location = new System.Drawing.Point(12, 93);
            this._lblRegion.Name = "_lblRegion";
            this._lblRegion.Size = new System.Drawing.Size(51, 13);
            this._lblRegion.TabIndex = 4;
            this._lblRegion.Text = "Region:";
            // 
            // _lblDepartment
            // 
            this._lblDepartment.AutoSize = true;
            this._lblDepartment.Location = new System.Drawing.Point(453, 63);
            this._lblDepartment.Name = "_lblDepartment";
            this._lblDepartment.Size = new System.Drawing.Size(80, 13);
            this._lblDepartment.TabIndex = 3;
            this._lblDepartment.Text = "Department:";
            // 
            // _lblTelNum
            // 
            this._lblTelNum.AutoSize = true;
            this._lblTelNum.Location = new System.Drawing.Point(12, 63);
            this._lblTelNum.Name = "_lblTelNum";
            this._lblTelNum.Size = new System.Drawing.Size(96, 13);
            this._lblTelNum.TabIndex = 2;
            this._lblTelNum.Text = "Phone Number:";
            // 
            // _lblManName
            // 
            this._lblManName.AutoSize = true;
            this._lblManName.Location = new System.Drawing.Point(453, 34);
            this._lblManName.Name = "_lblManName";
            this._lblManName.Size = new System.Drawing.Size(61, 13);
            this._lblManName.TabIndex = 1;
            this._lblManName.Text = "Manager:";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(12, 34);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(45, 13);
            this._lblName.TabIndex = 0;
            this._lblName.Text = "Name:";
            // 
            // _grpPostcodes
            // 
            this._grpPostcodes.Controls.Add(this._txtPostcode);
            this._grpPostcodes.Location = new System.Drawing.Point(0, 155);
            this._grpPostcodes.Name = "_grpPostcodes";
            this._grpPostcodes.Size = new System.Drawing.Size(829, 209);
            this._grpPostcodes.TabIndex = 2;
            this._grpPostcodes.TabStop = false;
            this._grpPostcodes.Text = "Postcodes";
            // 
            // _txtPostcode
            // 
            this._txtPostcode.Location = new System.Drawing.Point(15, 25);
            this._txtPostcode.Multiline = true;
            this._txtPostcode.Name = "_txtPostcode";
            this._txtPostcode.ReadOnly = true;
            this._txtPostcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtPostcode.Size = new System.Drawing.Size(792, 178);
            this._txtPostcode.TabIndex = 0;
            // 
            // _grpQualifications
            // 
            this._grpQualifications.Controls.Add(this._txtQual);
            this._grpQualifications.Location = new System.Drawing.Point(0, 370);
            this._grpQualifications.Name = "_grpQualifications";
            this._grpQualifications.Size = new System.Drawing.Size(829, 159);
            this._grpQualifications.TabIndex = 3;
            this._grpQualifications.TabStop = false;
            this._grpQualifications.Text = "Qualifications";
            // 
            // _txtQual
            // 
            this._txtQual.Location = new System.Drawing.Point(15, 25);
            this._txtQual.Multiline = true;
            this._txtQual.Name = "_txtQual";
            this._txtQual.ReadOnly = true;
            this._txtQual.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtQual.Size = new System.Drawing.Size(792, 116);
            this._txtQual.TabIndex = 0;
            // 
            // _btnClose
            // 
            this._btnClose.Location = new System.Drawing.Point(15, 532);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(75, 23);
            this._btnClose.TabIndex = 4;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRMViewEngineer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(829, 561);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._grpQualifications);
            this.Controls.Add(this._grpPostcodes);
            this.Controls.Add(this._grpEngineerInfo);
            this.MaximumSize = new System.Drawing.Size(845, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(845, 600);
            this.Name = "FRMViewEngineer";
            this.Text = "Viewing Engineer : ";
            this._grpEngineerInfo.ResumeLayout(false);
            this._grpEngineerInfo.PerformLayout();
            this._grpPostcodes.ResumeLayout(false);
            this._grpPostcodes.PerformLayout();
            this._grpQualifications.ResumeLayout(false);
            this._grpQualifications.PerformLayout();
            this.ResumeLayout(false);

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
            Text = Conversions.ToString("Viewing Engineer : " + Engineer.Rows[0]["Name"]);
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