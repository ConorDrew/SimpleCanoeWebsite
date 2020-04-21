using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FrmEngineerAbsence : FRMBaseForm
    {
        public FrmEngineerAbsence()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            base.Load += FrmEngineerAbsence_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FrmEngineerAbsence(int absenceID = 0) : base()
        {
            base.Load += FrmEngineerAbsence_Load;
            AbsenceID = absenceID;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            TheLoadedControl = new UCAbsences(Entity.Sys.Enums.UserType.Engineer, absenceID);
            pnlAbsence.Controls.Add((Control)TheLoadedControl);
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

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private Panel _pnlAbsence;

        internal Panel pnlAbsence
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlAbsence;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlAbsence != null)
                {
                }

                _pnlAbsence = value;
                if (_pnlAbsence != null)
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
                    _btnCancel.Click -= btnClose_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnClose_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnClose_Click);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _pnlAbsence = new Panel();
            SuspendLayout();
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Font = new Font("Verdana", 8.0F);
            _btnCancel.Location = new Point(12, 315);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(64, 23);
            _btnCancel.TabIndex = 11;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Font = new Font("Verdana", 8.0F);
            _btnSave.Location = new Point(552, 315);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(64, 24);
            _btnSave.TabIndex = 10;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            //
            // pnlAbsence
            //
            _pnlAbsence.Location = new Point(0, 53);
            _pnlAbsence.Name = "pnlAbsence";
            _pnlAbsence.Size = new Size(624, 249);
            _pnlAbsence.TabIndex = 12;
            //
            // FrmEngineerAbsence
            //
            AutoScaleBaseSize = new Size(6, 14);
            AutoSize = true;
            ClientSize = new Size(628, 343);
            Controls.Add(_pnlAbsence);
            Controls.Add(_btnSave);
            Controls.Add(_btnCancel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEngineerAbsence";
            Text = "Engineer Absence";
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_pnlAbsence, 0);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private IUserControl TheLoadedControl;
        private int _absenceID = 0;

        public int AbsenceID
        {
            get
            {
                return _absenceID;
            }

            set
            {
                _absenceID = value;
            }
        }

        private void FrmEngineerAbsence_Load(object sender, EventArgs e)
        {
            LoadForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TheLoadedControl.Save())
            {
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}