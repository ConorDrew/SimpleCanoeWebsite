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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSideBar));
            this._pnlButtons = new System.Windows.Forms.Panel();
            this._btnVan = new FSM.UCMainButton();
            this._btnReports = new FSM.UCMainButton();
            this._btnInvoicing = new FSM.UCMainButton();
            this._btnJobs = new FSM.UCMainButton();
            this._btnStaff = new FSM.UCMainButton();
            this._btnSpares = new FSM.UCMainButton();
            this._btnCustomer = new FSM.UCMainButton();
            this._Splitter1 = new System.Windows.Forms.Splitter();
            this._pnlSearch = new System.Windows.Forms.Panel();
            this._pnlMenu = new System.Windows.Forms.Panel();
            this._pnlSubMenu = new System.Windows.Forms.Panel();
            this._Label1 = new System.Windows.Forms.Label();
            this._pnlHeader = new System.Windows.Forms.Panel();
            this._Label2 = new System.Windows.Forms.Label();
            this._lblTitle = new System.Windows.Forms.Label();
            this._pnlButtons.SuspendLayout();
            this._pnlMenu.SuspendLayout();
            this._pnlHeader.SuspendLayout();
            this.SuspendLayout();
            //
            // _pnlButtons
            //
            this._pnlButtons.Controls.Add(this._btnVan);
            this._pnlButtons.Controls.Add(this._btnReports);
            this._pnlButtons.Controls.Add(this._btnInvoicing);
            this._pnlButtons.Controls.Add(this._btnJobs);
            this._pnlButtons.Controls.Add(this._btnStaff);
            this._pnlButtons.Controls.Add(this._btnSpares);
            this._pnlButtons.Controls.Add(this._btnCustomer);
            this._pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._pnlButtons.Location = new System.Drawing.Point(0, 430);
            this._pnlButtons.Name = "_pnlButtons";
            this._pnlButtons.Size = new System.Drawing.Size(160, 224);
            this._pnlButtons.TabIndex = 1;
            //
            // _btnVan
            //
            this._btnVan.AutoScroll = true;
            this._btnVan.BackColor = System.Drawing.Color.White;
            this._btnVan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnVan.BackgroundImage")));
            this._btnVan.Caption = "Fleet";
            this._btnVan.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnVan.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnVan.FormButtons = null;
            this._btnVan.IAmSelected = false;
            this._btnVan.Image = ((System.Drawing.Image)(resources.GetObject("_btnVan.Image")));
            this._btnVan.Location = new System.Drawing.Point(0, 192);
            this._btnVan.MenuType = FSM.Entity.Sys.Enums.MenuTypes.FleetVan;
            this._btnVan.Name = "_btnVan";
            this._btnVan.Size = new System.Drawing.Size(160, 32);
            this._btnVan.TabIndex = 8;
            //
            // _btnReports
            //
            this._btnReports.AutoScroll = true;
            this._btnReports.BackColor = System.Drawing.Color.White;
            this._btnReports.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnReports.BackgroundImage")));
            this._btnReports.Caption = "Reports";
            this._btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnReports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnReports.FormButtons = null;
            this._btnReports.IAmSelected = false;
            this._btnReports.Image = ((System.Drawing.Image)(resources.GetObject("_btnReports.Image")));
            this._btnReports.Location = new System.Drawing.Point(0, 160);
            this._btnReports.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Reports;
            this._btnReports.Name = "_btnReports";
            this._btnReports.Size = new System.Drawing.Size(160, 32);
            this._btnReports.TabIndex = 7;
            //
            // _btnInvoicing
            //
            this._btnInvoicing.AutoScroll = true;
            this._btnInvoicing.BackColor = System.Drawing.Color.White;
            this._btnInvoicing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnInvoicing.BackgroundImage")));
            this._btnInvoicing.Caption = "Invoicing";
            this._btnInvoicing.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnInvoicing.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnInvoicing.FormButtons = null;
            this._btnInvoicing.IAmSelected = false;
            this._btnInvoicing.Image = ((System.Drawing.Image)(resources.GetObject("_btnInvoicing.Image")));
            this._btnInvoicing.Location = new System.Drawing.Point(0, 128);
            this._btnInvoicing.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Invoicing;
            this._btnInvoicing.Name = "_btnInvoicing";
            this._btnInvoicing.Size = new System.Drawing.Size(160, 32);
            this._btnInvoicing.TabIndex = 6;
            //
            // _btnJobs
            //
            this._btnJobs.AutoScroll = true;
            this._btnJobs.BackColor = System.Drawing.Color.White;
            this._btnJobs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnJobs.BackgroundImage")));
            this._btnJobs.Caption = "Jobs";
            this._btnJobs.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnJobs.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnJobs.FormButtons = null;
            this._btnJobs.IAmSelected = false;
            this._btnJobs.Image = ((System.Drawing.Image)(resources.GetObject("_btnJobs.Image")));
            this._btnJobs.Location = new System.Drawing.Point(0, 96);
            this._btnJobs.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Jobs;
            this._btnJobs.Name = "_btnJobs";
            this._btnJobs.Size = new System.Drawing.Size(160, 32);
            this._btnJobs.TabIndex = 5;
            //
            // _btnStaff
            //
            this._btnStaff.AutoScroll = true;
            this._btnStaff.BackColor = System.Drawing.Color.White;
            this._btnStaff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnStaff.BackgroundImage")));
            this._btnStaff.Caption = "Staff";
            this._btnStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnStaff.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnStaff.FormButtons = null;
            this._btnStaff.IAmSelected = false;
            this._btnStaff.Image = ((System.Drawing.Image)(resources.GetObject("_btnStaff.Image")));
            this._btnStaff.Location = new System.Drawing.Point(0, 64);
            this._btnStaff.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Staff;
            this._btnStaff.Name = "_btnStaff";
            this._btnStaff.Size = new System.Drawing.Size(160, 32);
            this._btnStaff.TabIndex = 4;
            //
            // _btnSpares
            //
            this._btnSpares.AutoScroll = true;
            this._btnSpares.BackColor = System.Drawing.Color.White;
            this._btnSpares.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnSpares.BackgroundImage")));
            this._btnSpares.Caption = "Spares";
            this._btnSpares.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnSpares.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnSpares.FormButtons = null;
            this._btnSpares.IAmSelected = false;
            this._btnSpares.Image = ((System.Drawing.Image)(resources.GetObject("_btnSpares.Image")));
            this._btnSpares.Location = new System.Drawing.Point(0, 32);
            this._btnSpares.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Spares;
            this._btnSpares.Name = "_btnSpares";
            this._btnSpares.Size = new System.Drawing.Size(160, 32);
            this._btnSpares.TabIndex = 3;
            //
            // _btnCustomer
            //
            this._btnCustomer.AutoScroll = true;
            this._btnCustomer.BackColor = System.Drawing.Color.White;
            this._btnCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_btnCustomer.BackgroundImage")));
            this._btnCustomer.Caption = "Customers";
            this._btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this._btnCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCustomer.FormButtons = null;
            this._btnCustomer.IAmSelected = false;
            this._btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("_btnCustomer.Image")));
            this._btnCustomer.Location = new System.Drawing.Point(0, 0);
            this._btnCustomer.MenuType = FSM.Entity.Sys.Enums.MenuTypes.Customers;
            this._btnCustomer.Name = "_btnCustomer";
            this._btnCustomer.Size = new System.Drawing.Size(160, 32);
            this._btnCustomer.TabIndex = 0;
            //
            // _Splitter1
            //
            this._Splitter1.BackColor = System.Drawing.Color.Silver;
            this._Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Splitter1.Enabled = false;
            this._Splitter1.Location = new System.Drawing.Point(0, 425);
            this._Splitter1.Name = "_Splitter1";
            this._Splitter1.Size = new System.Drawing.Size(160, 5);
            this._Splitter1.TabIndex = 2;
            this._Splitter1.TabStop = false;
            //
            // _pnlSearch
            //
            this._pnlSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._pnlSearch.Location = new System.Drawing.Point(0, 273);
            this._pnlSearch.Name = "_pnlSearch";
            this._pnlSearch.Size = new System.Drawing.Size(160, 152);
            this._pnlSearch.TabIndex = 3;
            //
            // _pnlMenu
            //
            this._pnlMenu.Controls.Add(this._pnlSubMenu);
            this._pnlMenu.Controls.Add(this._Label1);
            this._pnlMenu.Controls.Add(this._pnlHeader);
            this._pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlMenu.Location = new System.Drawing.Point(0, 0);
            this._pnlMenu.Name = "_pnlMenu";
            this._pnlMenu.Size = new System.Drawing.Size(160, 273);
            this._pnlMenu.TabIndex = 4;
            //
            // _pnlSubMenu
            //
            this._pnlSubMenu.AutoScroll = true;
            this._pnlSubMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlSubMenu.Location = new System.Drawing.Point(0, 50);
            this._pnlSubMenu.Name = "_pnlSubMenu";
            this._pnlSubMenu.Size = new System.Drawing.Size(160, 223);
            this._pnlSubMenu.TabIndex = 6;
            //
            // _Label1
            //
            this._Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this._Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1.ForeColor = System.Drawing.Color.DimGray;
            this._Label1.Location = new System.Drawing.Point(0, 34);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(160, 16);
            this._Label1.TabIndex = 5;
            this._Label1.Text = "Please select option";
            //
            // _pnlHeader
            //
            this._pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._pnlHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_pnlHeader.BackgroundImage")));
            this._pnlHeader.Controls.Add(this._Label2);
            this._pnlHeader.Controls.Add(this._lblTitle);
            this._pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlHeader.Location = new System.Drawing.Point(0, 0);
            this._pnlHeader.Name = "_pnlHeader";
            this._pnlHeader.Size = new System.Drawing.Size(160, 34);
            this._pnlHeader.TabIndex = 4;
            //
            // _Label2
            //
            this._Label2.BackColor = System.Drawing.Color.Transparent;
            this._Label2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label2.ForeColor = System.Drawing.Color.White;
            this._Label2.Location = new System.Drawing.Point(0, 0);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(32, 32);
            this._Label2.TabIndex = 29;
            this._Label2.Text = ">>";
            this._Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _lblTitle
            //
            this._lblTitle.BackColor = System.Drawing.Color.Transparent;
            this._lblTitle.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTitle.ForeColor = System.Drawing.Color.White;
            this._lblTitle.Location = new System.Drawing.Point(32, 0);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(128, 32);
            this._lblTitle.TabIndex = 28;
            this._lblTitle.Text = "HOME";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // UCSideBar
            //
            this.Controls.Add(this._pnlMenu);
            this.Controls.Add(this._pnlSearch);
            this.Controls.Add(this._Splitter1);
            this.Controls.Add(this._pnlButtons);
            this.Name = "UCSideBar";
            this.Size = new System.Drawing.Size(160, 654);
            this._pnlButtons.ResumeLayout(false);
            this._pnlMenu.ResumeLayout(false);
            this._pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void MenuSelectionChanged(Entity.Sys.Enums.MenuTypes MenuType)
        {
            Navigation.Navigate(MenuType);
        }
    }
}