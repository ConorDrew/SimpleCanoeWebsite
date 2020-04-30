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
            _TreeView1 = new TreeView();
            _Label1 = new Label();
            _GroupBox2 = new GroupBox();
            _btnOk = new Button();
            _btnOk.Click += new EventHandler(btnYes_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnNo_Click);
            _GroupBox2.SuspendLayout();
            SuspendLayout();
            //
            // TreeView1
            //
            _TreeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TreeView1.Font = new Font("Verdana", 8.0F);
            _TreeView1.ImageIndex = -1;
            _TreeView1.Location = new Point(8, 56);
            _TreeView1.Name = "TreeView1";
            _TreeView1.SelectedImageIndex = -1;
            _TreeView1.Size = new Size(518, 392);
            _TreeView1.TabIndex = 1;
            //
            // Label1
            //
            _Label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _Label1.Font = new Font("Verdana", 8.0F);
            _Label1.Location = new Point(8, 24);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(501, 30);
            _Label1.TabIndex = 1;
            _Label1.Text = "The test you are trying to assign does not satisfy all the conditions of the engi" + "neer scheduler due to the reasons below.";
            //
            // GroupBox2
            //
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox2.Controls.Add(_Label1);
            _GroupBox2.Controls.Add(_TreeView1);
            _GroupBox2.Font = new Font("Verdana", 8.0F);
            _GroupBox2.Location = new Point(8, 40);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(538, 456);
            _GroupBox2.TabIndex = 5;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Result";
            //
            // btnOk
            //
            _btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOk.UseVisualStyleBackColor = true;
            _btnOk.Font = new Font("Verdana", 8.0F);
            _btnOk.Location = new Point(472, 504);
            _btnOk.Name = "btnOk";
            _btnOk.Size = new Size(72, 23);
            _btnOk.TabIndex = 3;
            _btnOk.Text = "Continue";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.DialogResult = DialogResult.Cancel;
            _btnCancel.UseVisualStyleBackColor = true;
            _btnCancel.Font = new Font("Verdana", 8.0F);
            _btnCancel.Location = new Point(8, 502);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(72, 23);
            _btnCancel.TabIndex = 4;
            _btnCancel.Text = "Cancel";
            //
            // FrmOverride
            //
            AcceptButton = _btnOk;
            AutoScaleBaseSize = new Size(6, 14);
            CancelButton = _btnCancel;
            ClientSize = new Size(552, 534);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOk);
            Controls.Add(_GroupBox2);
            MinimizeBox = false;
            MinimumSize = new Size(560, 568);
            Name = "FrmOverride";
            Text = "Are you sure you want to schedule this work here?";
            Controls.SetChildIndex(_GroupBox2, 0);
            Controls.SetChildIndex(_btnOk, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            _GroupBox2.ResumeLayout(false);
            ResumeLayout(false);
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