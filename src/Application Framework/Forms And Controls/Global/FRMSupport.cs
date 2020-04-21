using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMSupport : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMSupport() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMSupport_Load;

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
        private GroupBox _grpContactUs;

        internal GroupBox grpContactUs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContactUs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContactUs != null)
                {
                }

                _grpContactUs = value;
                if (_grpContactUs != null)
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

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private TextBox _txtFax;

        internal TextBox txtFax
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFax;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFax != null)
                {
                }

                _txtFax = value;
                if (_txtFax != null)
                {
                }
            }
        }

        private TextBox _txtTel;

        internal TextBox txtTel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTel != null)
                {
                }

                _txtTel = value;
                if (_txtTel != null)
                {
                }
            }
        }

        private TextBox _txtAddress;

        internal TextBox txtAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress != null)
                {
                }

                _txtAddress = value;
                if (_txtAddress != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpContactUs = new GroupBox();
            _Label1 = new Label();
            _Label8 = new Label();
            _Label2 = new Label();
            _txtFax = new TextBox();
            _txtTel = new TextBox();
            _txtAddress = new TextBox();
            _grpContactUs.SuspendLayout();
            SuspendLayout();
            //
            // grpContactUs
            //
            _grpContactUs.Anchor = AnchorStyles.Left;
            _grpContactUs.Controls.Add(_Label1);
            _grpContactUs.Controls.Add(_Label8);
            _grpContactUs.Controls.Add(_Label2);
            _grpContactUs.Controls.Add(_txtFax);
            _grpContactUs.Controls.Add(_txtTel);
            _grpContactUs.Controls.Add(_txtAddress);
            _grpContactUs.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _grpContactUs.Location = new Point(8, 40);
            _grpContactUs.Name = "grpContactUs";
            _grpContactUs.Size = new Size(296, 264);
            _grpContactUs.TabIndex = 8;
            _grpContactUs.TabStop = false;
            _grpContactUs.Text = "Contact Us";
            //
            // Label1
            //
            _Label1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(16, 200);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(72, 23);
            _Label1.TabIndex = 16;
            _Label1.Text = "Tel";
            //
            // Label8
            //
            _Label8.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label8.Location = new Point(16, 232);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(72, 23);
            _Label8.TabIndex = 15;
            _Label8.Text = "Fax";
            //
            // Label2
            //
            _Label2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label2.Location = new Point(16, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(72, 23);
            _Label2.TabIndex = 9;
            _Label2.Text = "Address";
            //
            // txtFax
            //
            _txtFax.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtFax.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtFax.Location = new Point(104, 232);
            _txtFax.Name = "txtFax";
            _txtFax.ReadOnly = true;
            _txtFax.Size = new Size(184, 20);
            _txtFax.TabIndex = 3;
            _txtFax.Text = "";
            //
            // txtTel
            //
            _txtTel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtTel.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtTel.Location = new Point(104, 200);
            _txtTel.Name = "txtTel";
            _txtTel.ReadOnly = true;
            _txtTel.Size = new Size(184, 20);
            _txtTel.TabIndex = 2;
            _txtTel.Text = "";
            //
            // txtAddress
            //
            _txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtAddress.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtAddress.Location = new Point(104, 24);
            _txtAddress.Multiline = true;
            _txtAddress.Name = "txtAddress";
            _txtAddress.ReadOnly = true;
            _txtAddress.ScrollBars = ScrollBars.Both;
            _txtAddress.Size = new Size(184, 168);
            _txtAddress.TabIndex = 1;
            _txtAddress.Text = "";
            //
            // FRMSupport
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(312, 310);
            Controls.Add(_grpContactUs);
            MaximizeBox = false;
            MaximumSize = new Size(320, 344);
            MinimizeBox = false;
            MinimumSize = new Size(320, 344);
            Name = "FRMSupport";
            Text = "Support";
            Controls.SetChildIndex(_grpContactUs, 0);
            _grpContactUs.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            txtAddress.Text = App.TheSystem.Address;
            txtTel.Text = App.TheSystem.Telephone;
            txtFax.Text = App.TheSystem.Fax;
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

        private void FRMSupport_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}