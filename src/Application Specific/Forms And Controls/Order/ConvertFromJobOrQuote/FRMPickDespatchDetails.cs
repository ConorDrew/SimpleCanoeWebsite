using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMPickDespatchDetails : FRMBaseForm, IForm
    {
        

        public FRMPickDespatchDetails() : base()
        {
            
            
            base.Load += FRMPickDespatchDetails_Load;

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
        private Label _lblHeading;

        internal Label lblHeading
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblHeading;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblHeading != null)
                {
                }

                _lblHeading = value;
                if (_lblHeading != null)
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

        private RadioButton _radPartsDespatched;

        internal RadioButton radPartsDespatched
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radPartsDespatched;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radPartsDespatched != null)
                {
                    _radPartsDespatched.CheckedChanged -= radPartsDespatched_CheckedChanged;
                }

                _radPartsDespatched = value;
                if (_radPartsDespatched != null)
                {
                    _radPartsDespatched.CheckedChanged += radPartsDespatched_CheckedChanged;
                }
            }
        }

        private ComboBox _cboEngineer;

        internal ComboBox cboEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineer != null)
                {
                }

                _cboEngineer = value;
                if (_cboEngineer != null)
                {
                }
            }
        }

        private RadioButton _radReadyToSchedule;

        internal RadioButton radReadyToSchedule
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radReadyToSchedule;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radReadyToSchedule != null)
                {
                }

                _radReadyToSchedule = value;
                if (_radReadyToSchedule != null)
                {
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._lblHeading = new System.Windows.Forms.Label();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._radPartsDespatched = new System.Windows.Forms.RadioButton();
            this._cboEngineer = new System.Windows.Forms.ComboBox();
            this._radReadyToSchedule = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // _lblHeading
            // 
            this._lblHeading.Location = new System.Drawing.Point(8, 14);
            this._lblHeading.Name = "_lblHeading";
            this._lblHeading.Size = new System.Drawing.Size(410, 36);
            this._lblHeading.TabIndex = 2;
            this._lblHeading.Text = "This order related to the visit \'{0}\' is waiting for parts. Please select the sta" +
    "tus and engineer you would be despatching the parts to:";
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(343, 145);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 3;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(11, 145);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(101, 23);
            this._btnCancel.TabIndex = 4;
            this._btnCancel.Text = "Do Not Update";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _radPartsDespatched
            // 
            this._radPartsDespatched.AutoSize = true;
            this._radPartsDespatched.Location = new System.Drawing.Point(11, 53);
            this._radPartsDespatched.Name = "_radPartsDespatched";
            this._radPartsDespatched.Size = new System.Drawing.Size(119, 17);
            this._radPartsDespatched.TabIndex = 0;
            this._radPartsDespatched.Text = "Parts Depatched";
            this._radPartsDespatched.UseVisualStyleBackColor = true;
            this._radPartsDespatched.CheckedChanged += new System.EventHandler(this.radPartsDespatched_CheckedChanged);
            // 
            // _cboEngineer
            // 
            this._cboEngineer.FormattingEnabled = true;
            this._cboEngineer.Location = new System.Drawing.Point(154, 52);
            this._cboEngineer.Name = "_cboEngineer";
            this._cboEngineer.Size = new System.Drawing.Size(264, 21);
            this._cboEngineer.TabIndex = 1;
            // 
            // _radReadyToSchedule
            // 
            this._radReadyToSchedule.AutoSize = true;
            this._radReadyToSchedule.Checked = true;
            this._radReadyToSchedule.Location = new System.Drawing.Point(11, 86);
            this._radReadyToSchedule.Name = "_radReadyToSchedule";
            this._radReadyToSchedule.Size = new System.Drawing.Size(134, 17);
            this._radReadyToSchedule.TabIndex = 2;
            this._radReadyToSchedule.TabStop = true;
            this._radReadyToSchedule.Text = "Ready To Schedule";
            this._radReadyToSchedule.UseVisualStyleBackColor = true;
            // 
            // FRMPickDespatchDetails
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(422, 173);
            this.ControlBox = false;
            this.Controls.Add(this._radReadyToSchedule);
            this.Controls.Add(this._cboEngineer);
            this.Controls.Add(this._radPartsDespatched);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._lblHeading);
            this.MaximumSize = new System.Drawing.Size(438, 212);
            this.MinimumSize = new System.Drawing.Size(438, 212);
            this.Name = "FRMPickDespatchDetails";
            this.Text = "Update Visit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboEngineer;
            Combo.SetUpCombo(ref argc, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argcombo = cboEngineer;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            cboEngineer.Enabled = false;
            EngVisit = (Entity.EngineerVisits.EngineerVisit)get_GetParameter(0);
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

        
        
        private Entity.EngineerVisits.EngineerVisit _EngVisit;

        public Entity.EngineerVisits.EngineerVisit EngVisit
        {
            get
            {
                return _EngVisit;
            }

            set
            {
                _EngVisit = value;
                lblHeading.Text = string.Format(lblHeading.Text, App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngVisit.EngineerVisitID).JobNumber);
            }
        }

        private void FRMPickDespatchDetails_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void radPartsDespatched_CheckedChanged(object sender, EventArgs e)
        {
            if (radPartsDespatched.Checked)
            {
                cboEngineer.Enabled = true;
            }
            else
            {
                var argcombo = cboEngineer;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
                cboEngineer.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (EngVisit.StatusEnumID >= Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled))
            {
                App.ShowMessage("This visit has already been scheduled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!radPartsDespatched.Checked & !radReadyToSchedule.Checked)
            {
                App.ShowMessage("Status not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (radPartsDespatched.Checked & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboEngineer)) == 0)
            {
                App.ShowMessage("Engineer not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            EngVisit.SetPartsToFit = true;
            if (radPartsDespatched.Checked)
            {
                EngVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Parts_Despatched);
                EngVisit.SetExpectedEngineerID = Combo.get_GetSelectedItemValue(cboEngineer);
            }
            else if (radReadyToSchedule.Checked)
            {
                EngVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule);
            }

            App.DB.EngineerVisits.Update(EngVisit, 0, true);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
    }
}