using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMContactDetails : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMContactDetails() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMContactDetails_Load;

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

        private Label _lblTel;

        internal Label lblTel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTel != null)
                {
                }

                _lblTel = value;
                if (_lblTel != null)
                {
                }
            }
        }

        private Label _lblAddress1;

        internal Label lblAddress1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress1 != null)
                {
                }

                _lblAddress1 = value;
                if (_lblAddress1 != null)
                {
                }
            }
        }

        private Label _lblAddress2;

        internal Label lblAddress2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress2 != null)
                {
                }

                _lblAddress2 = value;
                if (_lblAddress2 != null)
                {
                }
            }
        }

        private Label _lblAddress3;

        internal Label lblAddress3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress3 != null)
                {
                }

                _lblAddress3 = value;
                if (_lblAddress3 != null)
                {
                }
            }
        }

        private Label _lblAddress4;

        internal Label lblAddress4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress4 != null)
                {
                }

                _lblAddress4 = value;
                if (_lblAddress4 != null)
                {
                }
            }
        }

        private Label _lblAddress5;

        internal Label lblAddress5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress5 != null)
                {
                }

                _lblAddress5 = value;
                if (_lblAddress5 != null)
                {
                }
            }
        }

        private Label _lblPostcode;

        internal Label lblPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPostcode != null)
                {
                }

                _lblPostcode = value;
                if (_lblPostcode != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _lblName = new Label();
            _lblTel = new Label();
            _lblAddress1 = new Label();
            _lblAddress2 = new Label();
            _lblAddress3 = new Label();
            _lblAddress4 = new Label();
            _lblAddress5 = new Label();
            _lblPostcode = new Label();
            SuspendLayout();
            //
            // lblName
            //
            _lblName.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblName.Location = new Point(8, 56);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(248, 16);
            _lblName.TabIndex = 2;
            //
            // lblTel
            //
            _lblTel.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblTel.Location = new Point(32, 80);
            _lblTel.Name = "lblTel";
            _lblTel.Size = new Size(144, 16);
            _lblTel.TabIndex = 7;
            //
            // lblAddress1
            //
            _lblAddress1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblAddress1.Location = new Point(248, 80);
            _lblAddress1.Name = "lblAddress1";
            _lblAddress1.Size = new Size(184, 16);
            _lblAddress1.TabIndex = 12;
            //
            // lblAddress2
            //
            _lblAddress2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblAddress2.Location = new Point(248, 104);
            _lblAddress2.Name = "lblAddress2";
            _lblAddress2.Size = new Size(184, 16);
            _lblAddress2.TabIndex = 13;
            //
            // lblAddress3
            //
            _lblAddress3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblAddress3.Location = new Point(248, 128);
            _lblAddress3.Name = "lblAddress3";
            _lblAddress3.Size = new Size(184, 16);
            _lblAddress3.TabIndex = 14;
            //
            // lblAddress4
            //
            _lblAddress4.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblAddress4.Location = new Point(248, 152);
            _lblAddress4.Name = "lblAddress4";
            _lblAddress4.Size = new Size(184, 16);
            _lblAddress4.TabIndex = 15;
            //
            // lblAddress5
            //
            _lblAddress5.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblAddress5.Location = new Point(248, 176);
            _lblAddress5.Name = "lblAddress5";
            _lblAddress5.Size = new Size(184, 16);
            _lblAddress5.TabIndex = 16;
            //
            // lblPostcode
            //
            _lblPostcode.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblPostcode.Location = new Point(248, 200);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(184, 16);
            _lblPostcode.TabIndex = 17;
            //
            // FRMContactDetails
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(448, 233);
            Controls.Add(_lblPostcode);
            Controls.Add(_lblAddress5);
            Controls.Add(_lblAddress4);
            Controls.Add(_lblAddress3);
            Controls.Add(_lblAddress2);
            Controls.Add(_lblAddress1);
            Controls.Add(_lblTel);
            Controls.Add(_lblName);
            MaximizeBox = false;
            MaximumSize = new Size(464, 272);
            MinimizeBox = false;
            MinimumSize = new Size(464, 272);
            Name = "FRMContactDetails";
            Text = "Contact Sheet";
            Controls.SetChildIndex(_lblName, 0);
            Controls.SetChildIndex(_lblTel, 0);
            Controls.SetChildIndex(_lblAddress1, 0);
            Controls.SetChildIndex(_lblAddress2, 0);
            Controls.SetChildIndex(_lblAddress3, 0);
            Controls.SetChildIndex(_lblAddress4, 0);
            Controls.SetChildIndex(_lblAddress5, 0);
            Controls.SetChildIndex(_lblPostcode, 0);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
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

        private void FRMContactDetails_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
            lblName.Text = App.TheSystem.Configuration.CompanyName;
            lblAddress1.Text = App.TheSystem.Configuration.CompanyAddres1;
            lblAddress2.Text = App.TheSystem.Configuration.CompanyAddres2;
            lblAddress3.Text = App.TheSystem.Configuration.CompanyAddres3;
            lblAddress4.Text = App.TheSystem.Configuration.CompanyAddres4;
            lblAddress5.Text = App.TheSystem.Configuration.CompanyAddres5;
            lblPostcode.Text = App.TheSystem.Configuration.CompanyPostcode;
            lblTel.Text = App.TheSystem.Configuration.CompanyTelephoneNumber;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}