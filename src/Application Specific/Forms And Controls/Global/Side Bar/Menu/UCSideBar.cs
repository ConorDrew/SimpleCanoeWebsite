using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCSideBar : UCBase
    {
        

        public UCSideBar() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            btnCustomer.ButtonClicked += MenuSelectionChanged;
            btnSpares.ButtonClicked += MenuSelectionChanged;
            btnStaff.ButtonClicked += MenuSelectionChanged;
            btnJobs.ButtonClicked += MenuSelectionChanged;
            btnInvoicing.ButtonClicked += MenuSelectionChanged;
            btnReports.ButtonClicked += MenuSelectionChanged;
            btnVan.ButtonClicked += MenuSelectionChanged;
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
        private Panel _pnlButtons;

        internal Panel pnlButtons
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlButtons;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _pnlButtons = value;
            }
        }

        private UCMainButton _btnVan;

        internal UCMainButton btnVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _btnVan = value;
            }
        }

        private UCMainButton _btnReports;

        internal UCMainButton btnReports
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReports;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _btnReports = value;
            }
        }

        private Splitter _Splitter1;

        internal Splitter Splitter1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Splitter1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _Splitter1 = value;
            }
        }

        private Panel _pnlSearch;

        internal Panel pnlSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _pnlSearch = value;
            }
        }

        private Panel _pnlMenu;

        internal Panel pnlMenu
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlMenu;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _pnlMenu = value;
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
                _Label1 = value;
            }
        }

        private Panel _pnlHeader;

        internal Panel pnlHeader
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlHeader;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _pnlHeader = value;
            }
        }

        private Label _lblTitle;

        internal Label lblTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _lblTitle = value;
            }
        }

        private Panel _pnlSubMenu;

        internal Panel pnlSubMenu
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlSubMenu;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _pnlSubMenu = value;
            }
        }

        private UCMainButton _btnCustomer;

        internal UCMainButton btnCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _btnCustomer = value;
            }
        }

        private UCMainButton _btnSpares;

        internal UCMainButton btnSpares
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSpares;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _btnSpares = value;
            }
        }

        private UCMainButton _btnJobs;

        internal UCMainButton btnJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _btnJobs = value;
            }
        }

        private UCMainButton _btnInvoicing;

        internal UCMainButton btnInvoicing
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnInvoicing;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _btnInvoicing = value;
            }
        }

        private UCMainButton _btnStaff;

        internal UCMainButton btnStaff
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnStaff;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _btnStaff = value;
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
                _Label2 = value;
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSideBar));
            _pnlButtons = new Panel();
            _btnVan = new UCMainButton();
            _btnReports = new UCMainButton();
            _btnInvoicing = new UCMainButton();
            _btnJobs = new UCMainButton();
            _btnStaff = new UCMainButton();
            _btnSpares = new UCMainButton();
            _btnCustomer = new UCMainButton();
            _Splitter1 = new Splitter();
            _pnlSearch = new Panel();
            _pnlMenu = new Panel();
            _pnlSubMenu = new Panel();
            _Label1 = new Label();
            _pnlHeader = new Panel();
            _Label2 = new Label();
            _lblTitle = new Label();
            _pnlButtons.SuspendLayout();
            _pnlMenu.SuspendLayout();
            _pnlHeader.SuspendLayout();
            SuspendLayout();
            //
            // pnlButtons
            //
            _pnlButtons.Controls.Add(_btnVan);
            _pnlButtons.Controls.Add(_btnReports);
            _pnlButtons.Controls.Add(_btnInvoicing);
            _pnlButtons.Controls.Add(_btnJobs);
            _pnlButtons.Controls.Add(_btnStaff);
            _pnlButtons.Controls.Add(_btnSpares);
            _pnlButtons.Controls.Add(_btnCustomer);
            _pnlButtons.Dock = DockStyle.Bottom;
            _pnlButtons.Location = new Point(0, 430);
            _pnlButtons.Name = "pnlButtons";
            _pnlButtons.Size = new Size(160, 224);
            _pnlButtons.TabIndex = 1;
            //
            // btnVan
            //
            _btnVan.AutoScroll = true;
            _btnVan.BackColor = Color.White;
            _btnVan.BackgroundImage = (Image)resources.GetObject("btnVan.BackgroundImage");
            _btnVan.Caption = "Fleet";
            _btnVan.Dock = DockStyle.Top;
            _btnVan.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnVan.FormButtons = null;
            _btnVan.IAmSelected = false;
            _btnVan.Image = (Image)resources.GetObject("btnVan.Image");
            _btnVan.Location = new Point(0, 192);
            _btnVan.MenuType = Entity.Sys.Enums.MenuTypes.FleetVan;
            _btnVan.Name = "btnVan";
            _btnVan.Size = new Size(160, 32);
            _btnVan.TabIndex = 8;
            //
            // btnReports
            //
            _btnReports.AutoScroll = true;
            _btnReports.BackColor = Color.White;
            _btnReports.BackgroundImage = (Image)resources.GetObject("btnReports.BackgroundImage");
            _btnReports.Caption = "Reports";
            _btnReports.Dock = DockStyle.Top;
            _btnReports.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnReports.FormButtons = null;
            _btnReports.IAmSelected = false;
            _btnReports.Image = (Image)resources.GetObject("btnReports.Image");
            _btnReports.Location = new Point(0, 160);
            _btnReports.MenuType = Entity.Sys.Enums.MenuTypes.Reports;
            _btnReports.Name = "btnReports";
            _btnReports.Size = new Size(160, 32);
            _btnReports.TabIndex = 7;
            //
            // btnInvoicing
            //
            _btnInvoicing.AutoScroll = true;
            _btnInvoicing.BackColor = Color.White;
            _btnInvoicing.BackgroundImage = (Image)resources.GetObject("btnInvoicing.BackgroundImage");
            _btnInvoicing.Caption = "Invoicing";
            _btnInvoicing.Dock = DockStyle.Top;
            _btnInvoicing.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnInvoicing.FormButtons = null;
            _btnInvoicing.IAmSelected = false;
            _btnInvoicing.Image = (Image)resources.GetObject("btnInvoicing.Image");
            _btnInvoicing.Location = new Point(0, 128);
            _btnInvoicing.MenuType = Entity.Sys.Enums.MenuTypes.Invoicing;
            _btnInvoicing.Name = "btnInvoicing";
            _btnInvoicing.Size = new Size(160, 32);
            _btnInvoicing.TabIndex = 6;
            //
            // btnJobs
            //
            _btnJobs.AutoScroll = true;
            _btnJobs.BackColor = Color.White;
            _btnJobs.BackgroundImage = (Image)resources.GetObject("btnJobs.BackgroundImage");
            _btnJobs.Caption = "Jobs";
            _btnJobs.Dock = DockStyle.Top;
            _btnJobs.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnJobs.FormButtons = null;
            _btnJobs.IAmSelected = false;
            _btnJobs.Image = (Image)resources.GetObject("btnJobs.Image");
            _btnJobs.Location = new Point(0, 96);
            _btnJobs.MenuType = Entity.Sys.Enums.MenuTypes.Jobs;
            _btnJobs.Name = "btnJobs";
            _btnJobs.Size = new Size(160, 32);
            _btnJobs.TabIndex = 5;
            //
            // btnStaff
            //
            _btnStaff.AutoScroll = true;
            _btnStaff.BackColor = Color.White;
            _btnStaff.BackgroundImage = (Image)resources.GetObject("btnStaff.BackgroundImage");
            _btnStaff.Caption = "Staff";
            _btnStaff.Dock = DockStyle.Top;
            _btnStaff.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnStaff.FormButtons = null;
            _btnStaff.IAmSelected = false;
            _btnStaff.Image = (Image)resources.GetObject("btnStaff.Image");
            _btnStaff.Location = new Point(0, 64);
            _btnStaff.MenuType = Entity.Sys.Enums.MenuTypes.Staff;
            _btnStaff.Name = "btnStaff";
            _btnStaff.Size = new Size(160, 32);
            _btnStaff.TabIndex = 4;
            //
            // btnSpares
            //
            _btnSpares.AutoScroll = true;
            _btnSpares.BackColor = Color.White;
            _btnSpares.BackgroundImage = (Image)resources.GetObject("btnSpares.BackgroundImage");
            _btnSpares.Caption = "Spares";
            _btnSpares.Dock = DockStyle.Top;
            _btnSpares.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnSpares.FormButtons = null;
            _btnSpares.IAmSelected = false;
            _btnSpares.Image = (Image)resources.GetObject("btnSpares.Image");
            _btnSpares.Location = new Point(0, 32);
            _btnSpares.MenuType = Entity.Sys.Enums.MenuTypes.Spares;
            _btnSpares.Name = "btnSpares";
            _btnSpares.Size = new Size(160, 32);
            _btnSpares.TabIndex = 3;
            //
            // btnCustomer
            //
            _btnCustomer.AutoScroll = true;
            _btnCustomer.BackColor = Color.White;
            _btnCustomer.BackgroundImage = (Image)resources.GetObject("btnCustomer.BackgroundImage");
            _btnCustomer.Caption = "Customers";
            _btnCustomer.Dock = DockStyle.Top;
            _btnCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnCustomer.FormButtons = null;
            _btnCustomer.IAmSelected = false;
            _btnCustomer.Image = (Image)resources.GetObject("btnCustomer.Image");
            _btnCustomer.Location = new Point(0, 0);
            _btnCustomer.MenuType = Entity.Sys.Enums.MenuTypes.Customers;
            _btnCustomer.Name = "btnCustomer";
            _btnCustomer.Size = new Size(160, 32);
            _btnCustomer.TabIndex = 0;
            //
            // Splitter1
            //
            _Splitter1.BackColor = Color.Silver;
            _Splitter1.Dock = DockStyle.Bottom;
            _Splitter1.Enabled = false;
            _Splitter1.Location = new Point(0, 425);
            _Splitter1.Name = "Splitter1";
            _Splitter1.Size = new Size(160, 5);
            _Splitter1.TabIndex = 2;
            _Splitter1.TabStop = false;
            //
            // pnlSearch
            //
            _pnlSearch.Dock = DockStyle.Bottom;
            _pnlSearch.Location = new Point(0, 273);
            _pnlSearch.Name = "pnlSearch";
            _pnlSearch.Size = new Size(160, 152);
            _pnlSearch.TabIndex = 3;
            //
            // pnlMenu
            //
            _pnlMenu.Controls.Add(_pnlSubMenu);
            _pnlMenu.Controls.Add(_Label1);
            _pnlMenu.Controls.Add(_pnlHeader);
            _pnlMenu.Dock = DockStyle.Fill;
            _pnlMenu.Location = new Point(0, 0);
            _pnlMenu.Name = "pnlMenu";
            _pnlMenu.Size = new Size(160, 273);
            _pnlMenu.TabIndex = 4;
            //
            // pnlSubMenu
            //
            _pnlSubMenu.AutoScroll = true;
            _pnlSubMenu.Dock = DockStyle.Fill;
            _pnlSubMenu.Location = new Point(0, 50);
            _pnlSubMenu.Name = "pnlSubMenu";
            _pnlSubMenu.Size = new Size(160, 223);
            _pnlSubMenu.TabIndex = 6;
            //
            // Label1
            //
            _Label1.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            _Label1.Dock = DockStyle.Top;
            _Label1.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.ForeColor = Color.DimGray;
            _Label1.Location = new Point(0, 34);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(160, 16);
            _Label1.TabIndex = 5;
            _Label1.Text = "Please select option";
            //
            // pnlHeader
            //
            _pnlHeader.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            _pnlHeader.BackgroundImage = (Image)resources.GetObject("pnlHeader.BackgroundImage");
            _pnlHeader.Controls.Add(_Label2);
            _pnlHeader.Controls.Add(_lblTitle);
            _pnlHeader.Dock = DockStyle.Top;
            _pnlHeader.Location = new Point(0, 0);
            _pnlHeader.Name = "pnlHeader";
            _pnlHeader.Size = new Size(160, 34);
            _pnlHeader.TabIndex = 4;
            //
            // Label2
            //
            _Label2.BackColor = Color.Transparent;
            _Label2.Font = new Font("Verdana", 11.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label2.ForeColor = Color.White;
            _Label2.Location = new Point(0, 0);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(32, 32);
            _Label2.TabIndex = 29;
            _Label2.Text = ">>";
            _Label2.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblTitle
            //
            _lblTitle.BackColor = Color.Transparent;
            _lblTitle.Font = new Font("Verdana", 10.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblTitle.ForeColor = Color.White;
            _lblTitle.Location = new Point(32, 0);
            _lblTitle.Name = "lblTitle";
            _lblTitle.Size = new Size(128, 32);
            _lblTitle.TabIndex = 28;
            _lblTitle.Text = "HOME";
            _lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // UCSideBar
            //
            Controls.Add(_pnlMenu);
            Controls.Add(_pnlSearch);
            Controls.Add(_Splitter1);
            Controls.Add(_pnlButtons);
            Name = "UCSideBar";
            Size = new Size(160, 654);
            _pnlButtons.ResumeLayout(false);
            _pnlMenu.ResumeLayout(false);
            _pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        
        

        private void MenuSelectionChanged(Entity.Sys.Enums.MenuTypes MenuType)
        {
            Navigation.Navigate(MenuType);
        }

        
    }
}