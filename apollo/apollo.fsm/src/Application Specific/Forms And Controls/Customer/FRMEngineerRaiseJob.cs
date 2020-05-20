using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMEngineerRaiseJob : FRMBaseForm
    {
        

        public FRMEngineerRaiseJob() : base()
        {
            
            
            base.Load += FRMEngineer_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboEngineer;
            Combo.SetUpCombo(ref argc, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private CheckBox _chkSuper;

        internal CheckBox chkSuper
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSuper;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSuper != null)
                {
                }

                _chkSuper = value;
                if (_chkSuper != null)
                {
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

        private Panel _pnlMain;

        internal Panel pnlMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlMain != null)
                {
                }

                _pnlMain = value;
                if (_pnlMain != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._pnlMain = new System.Windows.Forms.Panel();
            this._chkSuper = new System.Windows.Forms.CheckBox();
            this._cboEngineer = new System.Windows.Forms.ComboBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Location = new System.Drawing.Point(8, 80);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 25);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(72, 80);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 25);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _pnlMain
            // 
            this._pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlMain.Controls.Add(this._chkSuper);
            this._pnlMain.Controls.Add(this._cboEngineer);
            this._pnlMain.Controls.Add(this._Label1);
            this._pnlMain.Location = new System.Drawing.Point(8, 12);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(613, 62);
            this._pnlMain.TabIndex = 1;
            // 
            // _chkSuper
            // 
            this._chkSuper.AutoSize = true;
            this._chkSuper.Location = new System.Drawing.Point(417, 20);
            this._chkSuper.Name = "_chkSuper";
            this._chkSuper.Size = new System.Drawing.Size(88, 17);
            this._chkSuper.TabIndex = 2;
            this._chkSuper.Text = "Supervisor";
            this._chkSuper.UseVisualStyleBackColor = true;
            // 
            // _cboEngineer
            // 
            this._cboEngineer.FormattingEnabled = true;
            this._cboEngineer.Location = new System.Drawing.Point(116, 18);
            this._cboEngineer.Name = "_cboEngineer";
            this._cboEngineer.Size = new System.Drawing.Size(284, 21);
            this._cboEngineer.TabIndex = 1;
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(48, 21);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(62, 13);
            this._Label1.TabIndex = 0;
            this._Label1.Text = "Engineer:";
            // 
            // FRMEngineerRaiseJob
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(621, 118);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(629, 100);
            this.Name = "FRMEngineerRaiseJob";
            this.Text = "Engineer : ID {0}";
            this._pnlMain.ResumeLayout(false);
            this._pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        private void FRMEngineer_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboEngineer)) == 0)
            {
                Interaction.MsgBox("Oops You haven't selected an Engineer", MsgBoxStyle.OkOnly, "Error");
            }

            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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
}