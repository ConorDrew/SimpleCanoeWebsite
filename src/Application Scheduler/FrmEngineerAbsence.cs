﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FrmEngineerAbsence : FRMBaseForm, IForm
    {
        public FrmEngineerAbsence()
        {
            base.Load += FrmEngineerAbsence_Load;
        }

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
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._pnlAbsence = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnCancel.Location = new System.Drawing.Point(12, 315);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(64, 23);
            this._btnCancel.TabIndex = 11;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnSave.Location = new System.Drawing.Point(552, 315);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(64, 24);
            this._btnSave.TabIndex = 10;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _pnlAbsence
            // 
            this._pnlAbsence.Location = new System.Drawing.Point(0, 12);
            this._pnlAbsence.Name = "_pnlAbsence";
            this._pnlAbsence.Size = new System.Drawing.Size(624, 290);
            this._pnlAbsence.TabIndex = 12;
            // 
            // FrmEngineerAbsence
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(628, 343);
            this.Controls.Add(this._pnlAbsence);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEngineerAbsence";
            this.Text = "Engineer Absence";
            this.ResumeLayout(false);

        }

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
            LoadMe(sender, e);
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

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
        }

        public IUserControl LoadedControl { get; }

        public void ResetMe(int newID)
        {
        }
    }
}