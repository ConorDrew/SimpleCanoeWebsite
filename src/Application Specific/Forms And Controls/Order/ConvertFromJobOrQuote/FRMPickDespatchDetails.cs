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
            _lblHeading = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _radPartsDespatched = new RadioButton();
            _radPartsDespatched.CheckedChanged += new EventHandler(radPartsDespatched_CheckedChanged);
            _cboEngineer = new ComboBox();
            _radReadyToSchedule = new RadioButton();
            SuspendLayout();
            //
            // lblHeading
            //
            _lblHeading.Location = new Point(8, 40);
            _lblHeading.Name = "lblHeading";
            _lblHeading.Size = new Size(410, 36);
            _lblHeading.TabIndex = 2;
            _lblHeading.Text = "This order related to the visit '{0}' is waiting for parts. Please select the sta" + "tus and engineer you would be despatching the parts to:";
            //
            // btnOK
            //
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(343, 145);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 3;
            _btnOK.Text = "OK";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(11, 145);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(101, 23);
            _btnCancel.TabIndex = 4;
            _btnCancel.Text = "Do Not Update";
            //
            // radPartsDespatched
            //
            _radPartsDespatched.AutoSize = true;
            _radPartsDespatched.Location = new Point(11, 79);
            _radPartsDespatched.Name = "radPartsDespatched";
            _radPartsDespatched.Size = new Size(119, 17);
            _radPartsDespatched.TabIndex = 0;
            _radPartsDespatched.Text = "Parts Depatched";
            _radPartsDespatched.UseVisualStyleBackColor = true;
            //
            // cboEngineer
            //
            _cboEngineer.FormattingEnabled = true;
            _cboEngineer.Location = new Point(154, 78);
            _cboEngineer.Name = "cboEngineer";
            _cboEngineer.Size = new Size(264, 21);
            _cboEngineer.TabIndex = 1;
            //
            // radReadyToSchedule
            //
            _radReadyToSchedule.AutoSize = true;
            _radReadyToSchedule.Checked = true;
            _radReadyToSchedule.Location = new Point(11, 112);
            _radReadyToSchedule.Name = "radReadyToSchedule";
            _radReadyToSchedule.Size = new Size(135, 17);
            _radReadyToSchedule.TabIndex = 2;
            _radReadyToSchedule.TabStop = true;
            _radReadyToSchedule.Text = "Ready To Schedule";
            _radReadyToSchedule.UseVisualStyleBackColor = true;
            //
            // FRMPickDespatchDetails
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(422, 174);
            ControlBox = false;
            Controls.Add(_radReadyToSchedule);
            Controls.Add(_cboEngineer);
            Controls.Add(_radPartsDespatched);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            Controls.Add(_lblHeading);
            MaximumSize = new Size(438, 212);
            MinimumSize = new Size(438, 212);
            Name = "FRMPickDespatchDetails";
            Text = "Update Visit";
            Controls.SetChildIndex(_lblHeading, 0);
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_radPartsDespatched, 0);
            Controls.SetChildIndex(_cboEngineer, 0);
            Controls.SetChildIndex(_radReadyToSchedule, 0);
            ResumeLayout(false);
            PerformLayout();
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