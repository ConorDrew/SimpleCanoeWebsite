using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMErrors : FRMBaseForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMErrors(string errorString) : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            txtErrors.Text = errorString.Trim();
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
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        private TextBox _txtErrors;

        internal TextBox txtErrors
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtErrors;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtErrors != null)
                {
                }

                _txtErrors = value;
                if (_txtErrors != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _txtErrors = new TextBox();
            SuspendLayout();
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnClose.UseVisualStyleBackColor = true;
            _btnClose.Location = new Point(776, 432);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 2;
            _btnClose.Text = "Close";
            //
            // txtErrors
            //
            _txtErrors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtErrors.Location = new Point(8, 40);
            _txtErrors.Multiline = true;
            _txtErrors.Name = "txtErrors";
            _txtErrors.ReadOnly = true;
            _txtErrors.ScrollBars = ScrollBars.Both;
            _txtErrors.Size = new Size(824, 384);
            _txtErrors.TabIndex = 1;
            _txtErrors.Text = "";
            //
            // FRMErrors
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(840, 462);
            ControlBox = false;
            Controls.Add(_txtErrors);
            Controls.Add(_btnClose);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(848, 496);
            Name = "FRMErrors";
            Text = "Job Portal - Import Errors";
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_txtErrors, 0);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}