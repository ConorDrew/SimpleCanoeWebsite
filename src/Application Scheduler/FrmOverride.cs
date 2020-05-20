using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FrmOverride : FRMBaseForm
    {
        public FrmOverride(ArrayList fails, int engineerVisitIDIn, bool isCopyIn, bool _cancelScheduled, bool _passwordPrompt) : base()
        {
            base.Load += FrmOverride_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            ReasonsForFailure = fails;
            CancelSchedule = _cancelScheduled;
            PasswordPrompt = _passwordPrompt;
            // Add any initialization after the InitializeComponent() call
            EngineerVisitID = engineerVisitIDIn;
            isCopy = isCopyIn;
        }

        

        public FrmOverride() : base()
        {
            base.Load += FrmOverride_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
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
        private TreeView _TreeView1;

        internal TreeView TreeView1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TreeView1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TreeView1 != null)
                {
                }

                _TreeView1 = value;
                if (_TreeView1 != null)
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

        private GroupBox _GroupBox2;

        internal GroupBox GroupBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        private Button _btnOk;

        internal Button btnOk
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOk;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOk != null)
                {
                    _btnOk.Click -= btnYes_Click;
                }

                _btnOk = value;
                if (_btnOk != null)
                {
                    _btnOk.Click += btnYes_Click;
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
                    _btnCancel.Click -= btnNo_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnNo_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._TreeView1 = new System.Windows.Forms.TreeView();
            this._Label1 = new System.Windows.Forms.Label();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _TreeView1
            // 
            this._TreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TreeView1.Font = new System.Drawing.Font("Verdana", 8F);
            this._TreeView1.Location = new System.Drawing.Point(8, 56);
            this._TreeView1.Name = "_TreeView1";
            this._TreeView1.Size = new System.Drawing.Size(518, 420);
            this._TreeView1.TabIndex = 1;
            // 
            // _Label1
            // 
            this._Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Label1.Font = new System.Drawing.Font("Verdana", 8F);
            this._Label1.Location = new System.Drawing.Point(8, 24);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(501, 30);
            this._Label1.TabIndex = 1;
            this._Label1.Text = "The test you are trying to assign does not satisfy all the conditions of the engi" +
    "neer scheduler due to the reasons below.";
            // 
            // _GroupBox2
            // 
            this._GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox2.Controls.Add(this._Label1);
            this._GroupBox2.Controls.Add(this._TreeView1);
            this._GroupBox2.Font = new System.Drawing.Font("Verdana", 8F);
            this._GroupBox2.Location = new System.Drawing.Point(8, 12);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(538, 484);
            this._GroupBox2.TabIndex = 5;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Result";
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOk.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnOk.Location = new System.Drawing.Point(472, 504);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(72, 23);
            this._btnOk.TabIndex = 3;
            this._btnOk.Text = "Continue";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnCancel.Location = new System.Drawing.Point(8, 502);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(72, 23);
            this._btnCancel.TabIndex = 4;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // FrmOverride
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(552, 534);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._GroupBox2);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(560, 568);
            this.Name = "FrmOverride";
            this.Text = "Are you sure you want to schedule this work here?";
            this._GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        
        private bool isCopy = false;
        private int _engineerVisitID;

        private int EngineerVisitID
        {
            get
            {
                return _engineerVisitID;
            }

            set
            {
                _engineerVisitID = value;
            }
        }

        private ArrayList _fails;

        public ArrayList ReasonsForFailure
        {
            get
            {
                return _fails;
            }

            set
            {
                _fails = value;
            }
        }

        private bool _cancelSchedule;

        private bool CancelSchedule
        {
            get
            {
                return _cancelSchedule;
            }

            set
            {
                _cancelSchedule = value;
            }
        }

        private bool _passwordPrompt;

        private bool PasswordPrompt
        {
            get
            {
                return _passwordPrompt;
            }

            set
            {
                _passwordPrompt = value;
            }
        }

        private void FrmOverride_Load(object sender, EventArgs e)
        {
            LoadForm(this);
            LoadReasons();
        }

        private void LoadReasons()
        {
            for (int x = 0, loopTo = ReasonsForFailure.Count - 1; x <= loopTo; x++)
                TreeView1.Nodes.Add(Conversions.ToString(ReasonsForFailure[x]));
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            for (int x = 0, loopTo = ReasonsForFailure.Count - 1; x <= loopTo; x++)
            {
                if (PasswordPrompt)
                {
                    DLGPasswordOverride dialogue;
                    dialogue = (DLGPasswordOverride)App.checkIfExists(typeof(DLGPasswordOverride).Name, true);
                    if (dialogue is null)
                    {
                        dialogue = (DLGPasswordOverride)Activator.CreateInstance(typeof(DLGPasswordOverride));
                    }

                    dialogue.ShowInTaskbar = false;
                    dialogue.ShowDialog();
                    if (dialogue.DialogResult == DialogResult.OK)
                    {
                        DialogResult = DialogResult.OK;
                        break;
                    }
                    else
                    {
                        DialogResult = DialogResult.No;
                        App.ShowMessage("Override Password is required to continue, visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                }
                else if (CancelSchedule)
                {
                    DialogResult = DialogResult.No;
                    App.ShowMessage("Visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }

                DialogResult = DialogResult.OK;
            }

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