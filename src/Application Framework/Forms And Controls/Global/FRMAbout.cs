using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMAbout : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMAbout() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMAbout_Load;

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
        private GroupBox _grpVersionInformation;

        internal GroupBox grpVersionInformation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVersionInformation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVersionInformation != null)
                {
                }

                _grpVersionInformation = value;
                if (_grpVersionInformation != null)
                {
                }
            }
        }

        private GroupBox _grpAssemblyInformation;

        internal GroupBox grpAssemblyInformation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAssemblyInformation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAssemblyInformation != null)
                {
                }

                _grpAssemblyInformation = value;
                if (_grpAssemblyInformation != null)
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

        private TextBox _txtVersion;

        internal TextBox txtVersion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVersion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVersion != null)
                {
                }

                _txtVersion = value;
                if (_txtVersion != null)
                {
                }
            }
        }

        private TextBox _txttrademark;

        internal TextBox txttrademark
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txttrademark;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txttrademark != null)
                {
                }

                _txttrademark = value;
                if (_txttrademark != null)
                {
                }
            }
        }

        private TextBox _txtCopyright;

        internal TextBox txtCopyright
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCopyright;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCopyright != null)
                {
                }

                _txtCopyright = value;
                if (_txtCopyright != null)
                {
                }
            }
        }

        private TextBox _txtproduct;

        internal TextBox txtproduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtproduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtproduct != null)
                {
                }

                _txtproduct = value;
                if (_txtproduct != null)
                {
                }
            }
        }

        private TextBox _txtcompany;

        internal TextBox txtcompany
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtcompany;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtcompany != null)
                {
                }

                _txtcompany = value;
                if (_txtcompany != null)
                {
                }
            }
        }

        private TextBox _txtdescription;

        internal TextBox txtdescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtdescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtdescription != null)
                {
                }

                _txtdescription = value;
                if (_txtdescription != null)
                {
                }
            }
        }

        private TextBox _txtTitle;

        internal TextBox txtTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTitle != null)
                {
                }

                _txtTitle = value;
                if (_txtTitle != null)
                {
                }
            }
        }

        private Label _lbltrademark;

        internal Label lbltrademark
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltrademark;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltrademark != null)
                {
                }

                _lbltrademark = value;
                if (_lbltrademark != null)
                {
                }
            }
        }

        private Label _lblCopyright;

        internal Label lblCopyright
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCopyright;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCopyright != null)
                {
                }

                _lblCopyright = value;
                if (_lblCopyright != null)
                {
                }
            }
        }

        private Label _lblproduct;

        internal Label lblproduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblproduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblproduct != null)
                {
                }

                _lblproduct = value;
                if (_lblproduct != null)
                {
                }
            }
        }

        private Label _lblcompany;

        internal Label lblcompany
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcompany;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcompany != null)
                {
                }

                _lblcompany = value;
                if (_lblcompany != null)
                {
                }
            }
        }

        private Label _lbldescription;

        internal Label lbldescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbldescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbldescription != null)
                {
                }

                _lbldescription = value;
                if (_lbldescription != null)
                {
                }
            }
        }

        private Label _lbltitle;

        internal Label lbltitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltitle != null)
                {
                }

                _lbltitle = value;
                if (_lbltitle != null)
                {
                }
            }
        }

        private GroupBox _grpVersion;

        internal GroupBox grpVersion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVersion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVersion != null)
                {
                }

                _grpVersion = value;
                if (_grpVersion != null)
                {
                }
            }
        }

        private RichTextBox _rtbLatestRelease;

        internal RichTextBox rtbLatestRelease
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rtbLatestRelease;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rtbLatestRelease != null)
                {
                }

                _rtbLatestRelease = value;
                if (_rtbLatestRelease != null)
                {
                }
            }
        }

        private TextBox _txtVersionHistory;

        internal TextBox txtVersionHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVersionHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVersionHistory != null)
                {
                }

                _txtVersionHistory = value;
                if (_txtVersionHistory != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpVersionInformation = new GroupBox();
            _grpAssemblyInformation = new GroupBox();
            _Label1 = new Label();
            _txtVersion = new TextBox();
            _txttrademark = new TextBox();
            _txtCopyright = new TextBox();
            _txtproduct = new TextBox();
            _txtcompany = new TextBox();
            _txtdescription = new TextBox();
            _txtTitle = new TextBox();
            _lbltrademark = new Label();
            _lblCopyright = new Label();
            _lblproduct = new Label();
            _lblcompany = new Label();
            _lbldescription = new Label();
            _lbltitle = new Label();
            _grpVersion = new GroupBox();
            _txtVersionHistory = new TextBox();
            _rtbLatestRelease = new RichTextBox();
            _grpVersionInformation.SuspendLayout();
            _grpAssemblyInformation.SuspendLayout();
            _grpVersion.SuspendLayout();
            SuspendLayout();
            // 
            // grpVersionInformation
            // 
            _grpVersionInformation.Controls.Add(_rtbLatestRelease);
            _grpVersionInformation.Location = new Point(8, 40);
            _grpVersionInformation.Name = "grpVersionInformation";
            _grpVersionInformation.Size = new Size(392, 184);
            _grpVersionInformation.TabIndex = 2;
            _grpVersionInformation.TabStop = false;
            _grpVersionInformation.Text = "Latest Release Notes";
            // 
            // grpAssemblyInformation
            // 
            _grpAssemblyInformation.Controls.Add(_Label1);
            _grpAssemblyInformation.Controls.Add(_txtVersion);
            _grpAssemblyInformation.Controls.Add(_txttrademark);
            _grpAssemblyInformation.Controls.Add(_txtCopyright);
            _grpAssemblyInformation.Controls.Add(_txtproduct);
            _grpAssemblyInformation.Controls.Add(_txtcompany);
            _grpAssemblyInformation.Controls.Add(_txtdescription);
            _grpAssemblyInformation.Controls.Add(_txtTitle);
            _grpAssemblyInformation.Controls.Add(_lbltrademark);
            _grpAssemblyInformation.Controls.Add(_lblCopyright);
            _grpAssemblyInformation.Controls.Add(_lblproduct);
            _grpAssemblyInformation.Controls.Add(_lblcompany);
            _grpAssemblyInformation.Controls.Add(_lbldescription);
            _grpAssemblyInformation.Controls.Add(_lbltitle);
            _grpAssemblyInformation.Location = new Point(8, 232);
            _grpAssemblyInformation.Name = "grpAssemblyInformation";
            _grpAssemblyInformation.Size = new Size(392, 200);
            _grpAssemblyInformation.TabIndex = 3;
            _grpAssemblyInformation.TabStop = false;
            _grpAssemblyInformation.Text = "Assembly Information";
            // 
            // Label1
            // 
            _Label1.Location = new Point(8, 24);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 16);
            _Label1.TabIndex = 10;
            _Label1.Text = "Version:";
            // 
            // txtVersion
            // 
            _txtVersion.Location = new Point(104, 24);
            _txtVersion.Name = "txtVersion";
            _txtVersion.ReadOnly = true;
            _txtVersion.Size = new Size(280, 21);
            _txtVersion.TabIndex = 2;
            // 
            // txttrademark
            // 
            _txttrademark.Location = new Point(104, 168);
            _txttrademark.Name = "txttrademark";
            _txttrademark.ReadOnly = true;
            _txttrademark.Size = new Size(280, 21);
            _txttrademark.TabIndex = 8;
            // 
            // txtCopyright
            // 
            _txtCopyright.Location = new Point(104, 144);
            _txtCopyright.Name = "txtCopyright";
            _txtCopyright.ReadOnly = true;
            _txtCopyright.Size = new Size(280, 21);
            _txtCopyright.TabIndex = 7;
            // 
            // txtproduct
            // 
            _txtproduct.Location = new Point(104, 120);
            _txtproduct.Name = "txtproduct";
            _txtproduct.ReadOnly = true;
            _txtproduct.Size = new Size(280, 21);
            _txtproduct.TabIndex = 6;
            // 
            // txtcompany
            // 
            _txtcompany.Location = new Point(104, 96);
            _txtcompany.Name = "txtcompany";
            _txtcompany.ReadOnly = true;
            _txtcompany.Size = new Size(280, 21);
            _txtcompany.TabIndex = 5;
            // 
            // txtdescription
            // 
            _txtdescription.Location = new Point(104, 72);
            _txtdescription.Name = "txtdescription";
            _txtdescription.ReadOnly = true;
            _txtdescription.Size = new Size(280, 21);
            _txtdescription.TabIndex = 4;
            // 
            // txtTitle
            // 
            _txtTitle.Location = new Point(104, 48);
            _txtTitle.Name = "txtTitle";
            _txtTitle.ReadOnly = true;
            _txtTitle.Size = new Size(280, 21);
            _txtTitle.TabIndex = 3;
            // 
            // lbltrademark
            // 
            _lbltrademark.Location = new Point(8, 168);
            _lbltrademark.Name = "lbltrademark";
            _lbltrademark.Size = new Size(72, 16);
            _lbltrademark.TabIndex = 5;
            _lbltrademark.Text = "Trademark:";
            // 
            // lblCopyright
            // 
            _lblCopyright.Location = new Point(8, 144);
            _lblCopyright.Name = "lblCopyright";
            _lblCopyright.Size = new Size(64, 16);
            _lblCopyright.TabIndex = 4;
            _lblCopyright.Text = "Copyright:";
            // 
            // lblproduct
            // 
            _lblproduct.Location = new Point(8, 120);
            _lblproduct.Name = "lblproduct";
            _lblproduct.Size = new Size(56, 16);
            _lblproduct.TabIndex = 3;
            _lblproduct.Text = "Product:";
            // 
            // lblcompany
            // 
            _lblcompany.Location = new Point(8, 96);
            _lblcompany.Name = "lblcompany";
            _lblcompany.Size = new Size(64, 16);
            _lblcompany.TabIndex = 2;
            _lblcompany.Text = "Company:";
            // 
            // lbldescription
            // 
            _lbldescription.Location = new Point(8, 72);
            _lbldescription.Name = "lbldescription";
            _lbldescription.Size = new Size(80, 16);
            _lbldescription.TabIndex = 1;
            _lbldescription.Text = "Description:";
            // 
            // lbltitle
            // 
            _lbltitle.Location = new Point(8, 48);
            _lbltitle.Name = "lbltitle";
            _lbltitle.Size = new Size(40, 16);
            _lbltitle.TabIndex = 0;
            _lbltitle.Text = "Title:";
            // 
            // grpVersion
            // 
            _grpVersion.Controls.Add(_txtVersionHistory);
            _grpVersion.Font = new Font("Verdana", 8.25F);
            _grpVersion.Location = new Point(408, 40);
            _grpVersion.Name = "grpVersion";
            _grpVersion.Size = new Size(409, 392);
            _grpVersion.TabIndex = 4;
            _grpVersion.TabStop = false;
            _grpVersion.Text = "Version History";
            // 
            // txtVersionHistory
            // 
            _txtVersionHistory.Location = new Point(8, 16);
            _txtVersionHistory.Multiline = true;
            _txtVersionHistory.Name = "txtVersionHistory";
            _txtVersionHistory.ReadOnly = true;
            _txtVersionHistory.ScrollBars = ScrollBars.Both;
            _txtVersionHistory.Size = new Size(392, 368);
            _txtVersionHistory.TabIndex = 9;
            // 
            // rtbLatestRelease
            // 
            _rtbLatestRelease.Dock = DockStyle.Fill;
            _rtbLatestRelease.Location = new Point(3, 17);
            _rtbLatestRelease.Name = "rtbLatestRelease";
            _rtbLatestRelease.Size = new Size(386, 164);
            _rtbLatestRelease.TabIndex = 0;
            _rtbLatestRelease.Text = "";
            // 
            // FRMAbout
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(826, 433);
            Controls.Add(_grpVersion);
            Controls.Add(_grpAssemblyInformation);
            Controls.Add(_grpVersionInformation);
            MaximizeBox = false;
            MaximumSize = new Size(842, 500);
            MinimizeBox = false;
            MinimumSize = new Size(832, 472);
            Name = "FRMAbout";
            Text = "About";
            Controls.SetChildIndex(_grpVersionInformation, 0);
            Controls.SetChildIndex(_grpAssemblyInformation, 0);
            Controls.SetChildIndex(_grpVersion, 0);
            _grpVersionInformation.ResumeLayout(false);
            _grpAssemblyInformation.ResumeLayout(false);
            _grpAssemblyInformation.PerformLayout();
            _grpVersion.ResumeLayout(false);
            _grpVersion.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            Populate();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        private void FRMAbout_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void Populate()
        {
            txtVersion.Text = App.TheSystem.Configuration.SystemVersion;
            txtTitle.Text = App.TheSystem.Title;
            txtdescription.Text = App.TheSystem.Description;
            txtcompany.Text = App.TheSystem.Company;
            txtproduct.Text = App.TheSystem.Product;
            txtCopyright.Text = App.TheSystem.Copyright;
            txttrademark.Text = App.TheSystem.Trademark;
            txtVersionHistory.Text = Entity.Sys.Helper.GetTextResource("Versions.txt");
            string releaseNote = Entity.Sys.Helper.GetTextResource(App.ReleaseNoteTextFile);
            rtbLatestRelease.Text = releaseNote;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}