using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCQuoteJobOfWork : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCQuoteJobOfWork() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCJobOfWork_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            SetupJobItemsDataGrid();
        }

        // UserControl overrides dispose to clean up the component list.
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
        private GroupBox _grpScheduleOfRates;

        internal GroupBox grpScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpScheduleOfRates != null)
                {
                }

                _grpScheduleOfRates = value;
                if (_grpScheduleOfRates != null)
                {
                }
            }
        }

        private Button _btnSiteScheduleOfRates;

        internal Button btnSiteScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSiteScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSiteScheduleOfRates != null)
                {
                    _btnSiteScheduleOfRates.Click -= btnSiteScheduleOfRates_Click;
                }

                _btnSiteScheduleOfRates = value;
                if (_btnSiteScheduleOfRates != null)
                {
                    _btnSiteScheduleOfRates.Click += btnSiteScheduleOfRates_Click;
                }
            }
        }

        private TextBox _txtQuantityPerVisit;

        internal TextBox txtQuantityPerVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuantityPerVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuantityPerVisit != null)
                {
                }

                _txtQuantityPerVisit = value;
                if (_txtQuantityPerVisit != null)
                {
                }
            }
        }

        private Label _Label7;

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
                {
                }
            }
        }

        private Button _btnAddRates;

        internal Button btnAddRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddRates != null)
                {
                    _btnAddRates.Click -= btnAddRates_Click;
                }

                _btnAddRates = value;
                if (_btnAddRates != null)
                {
                    _btnAddRates.Click += btnAddRates_Click;
                }
            }
        }

        private Button _btnRemoveRates;

        internal Button btnRemoveRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveRates != null)
                {
                    _btnRemoveRates.Click -= btnRemoveRates_Click;
                }

                _btnRemoveRates = value;
                if (_btnRemoveRates != null)
                {
                    _btnRemoveRates.Click += btnRemoveRates_Click;
                }
            }
        }

        private ComboBox _cboScheduleOfRatesCategoryID;

        internal ComboBox cboScheduleOfRatesCategoryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboScheduleOfRatesCategoryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboScheduleOfRatesCategoryID != null)
                {
                }

                _cboScheduleOfRatesCategoryID = value;
                if (_cboScheduleOfRatesCategoryID != null)
                {
                }
            }
        }

        private Label _lblScheduleOfRatesCategoryID;

        internal Label lblScheduleOfRatesCategoryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblScheduleOfRatesCategoryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblScheduleOfRatesCategoryID != null)
                {
                }

                _lblScheduleOfRatesCategoryID = value;
                if (_lblScheduleOfRatesCategoryID != null)
                {
                }
            }
        }

        private TextBox _txtCode;

        internal TextBox txtCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCode != null)
                {
                }

                _txtCode = value;
                if (_txtCode != null)
                {
                }
            }
        }

        private Label _lblCode;

        internal Label lblCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCode != null)
                {
                }

                _lblCode = value;
                if (_lblCode != null)
                {
                }
            }
        }

        private TextBox _txtDescriptionRate;

        internal TextBox txtDescriptionRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDescriptionRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDescriptionRate != null)
                {
                }

                _txtDescriptionRate = value;
                if (_txtDescriptionRate != null)
                {
                }
            }
        }

        private Label _lblDescription;

        internal Label lblDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDescription != null)
                {
                }

                _lblDescription = value;
                if (_lblDescription != null)
                {
                }
            }
        }

        private TextBox _txtPrice;

        internal TextBox txtPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPrice != null)
                {
                }

                _txtPrice = value;
                if (_txtPrice != null)
                {
                }
            }
        }

        private Label _lblPrice;

        internal Label lblPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPrice != null)
                {
                }

                _lblPrice = value;
                if (_lblPrice != null)
                {
                }
            }
        }

        private DataGrid _dgScheduleOfRates;

        internal DataGrid dgScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgScheduleOfRates != null)
                {
                }

                _dgScheduleOfRates = value;
                if (_dgScheduleOfRates != null)
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

        private TextBox _txtRatesTotal;

        internal TextBox txtRatesTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRatesTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRatesTotal != null)
                {
                }

                _txtRatesTotal = value;
                if (_txtRatesTotal != null)
                {
                }
            }
        }

        private TextBox _txtTotalSitePrice;

        internal TextBox txtTotalSitePrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTotalSitePrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTotalSitePrice != null)
                {
                    _txtTotalSitePrice.LostFocus -= txtTotalSitePrice_LostFocus;
                }

                _txtTotalSitePrice = value;
                if (_txtTotalSitePrice != null)
                {
                    _txtTotalSitePrice.LostFocus += txtTotalSitePrice_LostFocus;
                }
            }
        }

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
                {
                }
            }
        }

        private CheckBox _chkRates;

        internal CheckBox chkRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkRates != null)
                {
                    _chkRates.CheckedChanged -= chkRates_CheckedChanged;
                }

                _chkRates = value;
                if (_chkRates != null)
                {
                    _chkRates.CheckedChanged += chkRates_CheckedChanged;
                }
            }
        }

        private Label _Label9;

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
                {
                }
            }
        }

        private TextBox _txtItemTotal;

        internal TextBox txtItemTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtItemTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtItemTotal != null)
                {
                }

                _txtItemTotal = value;
                if (_txtItemTotal != null)
                {
                }
            }
        }

        private TextBox _txtPricePerVisit;

        internal TextBox txtPricePerVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPricePerVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPricePerVisit != null)
                {
                    _txtPricePerVisit.LostFocus -= txtPricePerVisit_LostFocus;
                }

                _txtPricePerVisit = value;
                if (_txtPricePerVisit != null)
                {
                    _txtPricePerVisit.LostFocus += txtPricePerVisit_LostFocus;
                }
            }
        }

        private Label _lblPricePerVisit;

        internal Label lblPricePerVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPricePerVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPricePerVisit != null)
                {
                }

                _lblPricePerVisit = value;
                if (_lblPricePerVisit != null)
                {
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
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

        private TextBox _txtMileageCostPerVisit;

        internal TextBox txtMileageCostPerVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMileageCostPerVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMileageCostPerVisit != null)
                {
                }

                _txtMileageCostPerVisit = value;
                if (_txtMileageCostPerVisit != null)
                {
                }
            }
        }

        private TextBox _txtAverageMileage;

        internal TextBox txtAverageMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAverageMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAverageMileage != null)
                {
                    _txtAverageMileage.LostFocus -= txtAverageMileage_LostFocus;
                }

                _txtAverageMileage = value;
                if (_txtAverageMileage != null)
                {
                    _txtAverageMileage.LostFocus += txtAverageMileage_LostFocus;
                }
            }
        }

        private TextBox _txtCostPerMile;

        internal TextBox txtCostPerMile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCostPerMile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCostPerMile != null)
                {
                    _txtCostPerMile.LostFocus -= txtCostPerMile_Focus;
                }

                _txtCostPerMile = value;
                if (_txtCostPerMile != null)
                {
                    _txtCostPerMile.LostFocus += txtCostPerMile_Focus;
                }
            }
        }

        private CheckBox _chkIncludeMileage;

        internal CheckBox chkIncludeMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkIncludeMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkIncludeMileage != null)
                {
                    _chkIncludeMileage.CheckedChanged -= chkIncludeMileage_CheckedChanged;
                }

                _chkIncludeMileage = value;
                if (_chkIncludeMileage != null)
                {
                    _chkIncludeMileage.CheckedChanged += chkIncludeMileage_CheckedChanged;
                }
            }
        }

        private Button _btnRemoveFromJobOfWork;

        internal Button btnRemoveFromJobOfWork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveFromJobOfWork;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveFromJobOfWork != null)
                {
                    _btnRemoveFromJobOfWork.Click -= btnRemoveFromJobOfWork_Click;
                }

                _btnRemoveFromJobOfWork = value;
                if (_btnRemoveFromJobOfWork != null)
                {
                    _btnRemoveFromJobOfWork.Click += btnRemoveFromJobOfWork_Click;
                }
            }
        }

        private DataGrid _dgVisits;

        internal DataGrid dgVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgVisits != null)
                {
                }

                _dgVisits = value;
                if (_dgVisits != null)
                {
                }
            }
        }

        private DataGrid _dgJobItemsAdded;

        internal DataGrid dgJobItemsAdded
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgJobItemsAdded;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgJobItemsAdded != null)
                {
                    _dgJobItemsAdded.MouseUp -= dgJobItemsAdded_MouseUp;
                }

                _dgJobItemsAdded = value;
                if (_dgJobItemsAdded != null)
                {
                    _dgJobItemsAdded.MouseUp += dgJobItemsAdded_MouseUp;
                }
            }
        }

        private DateTimePicker _dtpFirstVisitDate;

        internal DateTimePicker dtpFirstVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFirstVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFirstVisitDate != null)
                {
                    _dtpFirstVisitDate.LostFocus -= dtpFirstVisitDate_LostFocus;
                }

                _dtpFirstVisitDate = value;
                if (_dtpFirstVisitDate != null)
                {
                    _dtpFirstVisitDate.LostFocus += dtpFirstVisitDate_LostFocus;
                }
            }
        }

        private Label _lblFirstVisitDate;

        internal Label lblFirstVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFirstVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFirstVisitDate != null)
                {
                }

                _lblFirstVisitDate = value;
                if (_lblFirstVisitDate != null)
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

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpScheduleOfRates = new GroupBox();
            _btnSiteScheduleOfRates = new Button();
            _btnSiteScheduleOfRates.Click += new EventHandler(btnSiteScheduleOfRates_Click);
            _txtQuantityPerVisit = new TextBox();
            _Label7 = new Label();
            _btnAddRates = new Button();
            _btnAddRates.Click += new EventHandler(btnAddRates_Click);
            _btnRemoveRates = new Button();
            _btnRemoveRates.Click += new EventHandler(btnRemoveRates_Click);
            _cboScheduleOfRatesCategoryID = new ComboBox();
            _lblScheduleOfRatesCategoryID = new Label();
            _txtCode = new TextBox();
            _lblCode = new Label();
            _txtDescriptionRate = new TextBox();
            _lblDescription = new Label();
            _txtPrice = new TextBox();
            _lblPrice = new Label();
            _dgScheduleOfRates = new DataGrid();
            _Label8 = new Label();
            _txtRatesTotal = new TextBox();
            _txtTotalSitePrice = new TextBox();
            _txtTotalSitePrice.LostFocus += new EventHandler(txtTotalSitePrice_LostFocus);
            _Label6 = new Label();
            _chkRates = new CheckBox();
            _chkRates.CheckedChanged += new EventHandler(chkRates_CheckedChanged);
            _Label9 = new Label();
            _txtItemTotal = new TextBox();
            _txtPricePerVisit = new TextBox();
            _txtPricePerVisit.LostFocus += new EventHandler(txtPricePerVisit_LostFocus);
            _lblPricePerVisit = new Label();
            _Label5 = new Label();
            _Label4 = new Label();
            _Label2 = new Label();
            _txtMileageCostPerVisit = new TextBox();
            _txtAverageMileage = new TextBox();
            _txtAverageMileage.LostFocus += new EventHandler(txtAverageMileage_LostFocus);
            _txtCostPerMile = new TextBox();
            _txtCostPerMile.LostFocus += new EventHandler(txtCostPerMile_Focus);
            _chkIncludeMileage = new CheckBox();
            _chkIncludeMileage.CheckedChanged += new EventHandler(chkIncludeMileage_CheckedChanged);
            _btnRemoveFromJobOfWork = new Button();
            _btnRemoveFromJobOfWork.Click += new EventHandler(btnRemoveFromJobOfWork_Click);
            _dgVisits = new DataGrid();
            _dgJobItemsAdded = new DataGrid();
            _dgJobItemsAdded.MouseUp += new MouseEventHandler(dgJobItemsAdded_MouseUp);
            _dtpFirstVisitDate = new DateTimePicker();
            _dtpFirstVisitDate.LostFocus += new EventHandler(dtpFirstVisitDate_LostFocus);
            _lblFirstVisitDate = new Label();
            _Label1 = new Label();
            _Label3 = new Label();
            _grpScheduleOfRates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgVisits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgJobItemsAdded).BeginInit();
            SuspendLayout();
            //
            // grpScheduleOfRates
            //
            _grpScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpScheduleOfRates.Controls.Add(_btnSiteScheduleOfRates);
            _grpScheduleOfRates.Controls.Add(_txtQuantityPerVisit);
            _grpScheduleOfRates.Controls.Add(_Label7);
            _grpScheduleOfRates.Controls.Add(_btnAddRates);
            _grpScheduleOfRates.Controls.Add(_btnRemoveRates);
            _grpScheduleOfRates.Controls.Add(_cboScheduleOfRatesCategoryID);
            _grpScheduleOfRates.Controls.Add(_lblScheduleOfRatesCategoryID);
            _grpScheduleOfRates.Controls.Add(_txtCode);
            _grpScheduleOfRates.Controls.Add(_lblCode);
            _grpScheduleOfRates.Controls.Add(_txtDescriptionRate);
            _grpScheduleOfRates.Controls.Add(_lblDescription);
            _grpScheduleOfRates.Controls.Add(_txtPrice);
            _grpScheduleOfRates.Controls.Add(_lblPrice);
            _grpScheduleOfRates.Controls.Add(_dgScheduleOfRates);
            _grpScheduleOfRates.Location = new Point(456, 0);
            _grpScheduleOfRates.Name = "grpScheduleOfRates";
            _grpScheduleOfRates.Size = new Size(432, 208);
            _grpScheduleOfRates.TabIndex = 3;
            _grpScheduleOfRates.TabStop = false;
            _grpScheduleOfRates.Text = "Property Contract Schedule Of Rates";
            //
            // btnSiteScheduleOfRates
            //
            _btnSiteScheduleOfRates.Location = new Point(96, 175);
            _btnSiteScheduleOfRates.Name = "btnSiteScheduleOfRates";
            _btnSiteScheduleOfRates.Size = new Size(240, 23);
            _btnSiteScheduleOfRates.TabIndex = 7;
            _btnSiteScheduleOfRates.Text = "Add Property Schedule Of Rates";
            //
            // txtQuantityPerVisit
            //
            _txtQuantityPerVisit.Location = new Point(344, 40);
            _txtQuantityPerVisit.MaxLength = 9;
            _txtQuantityPerVisit.Name = "txtQuantityPerVisit";
            _txtQuantityPerVisit.Size = new Size(72, 21);
            _txtQuantityPerVisit.TabIndex = 4;
            _txtQuantityPerVisit.Tag = "SystemScheduleOfRate.Price";
            _txtQuantityPerVisit.Text = "";
            //
            // Label7
            //
            _Label7.Location = new Point(264, 40);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(80, 20);
            _Label7.TabIndex = 48;
            _Label7.Text = "Qty Per Visit";
            //
            // btnAddRates
            //
            _btnAddRates.Location = new Point(8, 175);
            _btnAddRates.Name = "btnAddRates";
            _btnAddRates.Size = new Size(72, 23);
            _btnAddRates.TabIndex = 6;
            _btnAddRates.Text = "Add";
            //
            // btnRemoveRates
            //
            _btnRemoveRates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnRemoveRates.Location = new Point(352, 176);
            _btnRemoveRates.Name = "btnRemoveRates";
            _btnRemoveRates.Size = new Size(72, 23);
            _btnRemoveRates.TabIndex = 8;
            _btnRemoveRates.Text = "Remove";
            //
            // cboScheduleOfRatesCategoryID
            //
            _cboScheduleOfRatesCategoryID.Cursor = Cursors.Hand;
            _cboScheduleOfRatesCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboScheduleOfRatesCategoryID.Location = new Point(88, 16);
            _cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID";
            _cboScheduleOfRatesCategoryID.Size = new Size(171, 21);
            _cboScheduleOfRatesCategoryID.TabIndex = 0;
            _cboScheduleOfRatesCategoryID.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            //
            // lblScheduleOfRatesCategoryID
            //
            _lblScheduleOfRatesCategoryID.Location = new Point(8, 16);
            _lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID";
            _lblScheduleOfRatesCategoryID.Size = new Size(80, 20);
            _lblScheduleOfRatesCategoryID.TabIndex = 43;
            _lblScheduleOfRatesCategoryID.Text = "Category";
            //
            // txtCode
            //
            _txtCode.Location = new Point(88, 40);
            _txtCode.MaxLength = 50;
            _txtCode.Name = "txtCode";
            _txtCode.Size = new Size(171, 21);
            _txtCode.TabIndex = 1;
            _txtCode.Tag = "SystemScheduleOfRate.Code";
            _txtCode.Text = "";
            //
            // lblCode
            //
            _lblCode.Location = new Point(8, 40);
            _lblCode.Name = "lblCode";
            _lblCode.Size = new Size(80, 20);
            _lblCode.TabIndex = 42;
            _lblCode.Text = "Code";
            //
            // txtDescriptionRate
            //
            _txtDescriptionRate.Location = new Point(88, 64);
            _txtDescriptionRate.MaxLength = 0;
            _txtDescriptionRate.Multiline = true;
            _txtDescriptionRate.Name = "txtDescriptionRate";
            _txtDescriptionRate.ScrollBars = ScrollBars.Vertical;
            _txtDescriptionRate.Size = new Size(336, 24);
            _txtDescriptionRate.TabIndex = 2;
            _txtDescriptionRate.Tag = "SystemScheduleOfRate.Description";
            _txtDescriptionRate.Text = "";
            //
            // lblDescription
            //
            _lblDescription.Location = new Point(8, 64);
            _lblDescription.Name = "lblDescription";
            _lblDescription.Size = new Size(80, 20);
            _lblDescription.TabIndex = 41;
            _lblDescription.Text = "Description";
            //
            // txtPrice
            //
            _txtPrice.Location = new Point(344, 16);
            _txtPrice.MaxLength = 9;
            _txtPrice.Name = "txtPrice";
            _txtPrice.Size = new Size(72, 21);
            _txtPrice.TabIndex = 3;
            _txtPrice.Tag = "SystemScheduleOfRate.Price";
            _txtPrice.Text = "";
            //
            // lblPrice
            //
            _lblPrice.Location = new Point(264, 16);
            _lblPrice.Name = "lblPrice";
            _lblPrice.Size = new Size(80, 20);
            _lblPrice.TabIndex = 40;
            _lblPrice.Text = "Price";
            //
            // dgScheduleOfRates
            //
            _dgScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgScheduleOfRates.DataMember = "";
            _dgScheduleOfRates.HeaderForeColor = SystemColors.ControlText;
            _dgScheduleOfRates.Location = new Point(8, 90);
            _dgScheduleOfRates.Name = "dgScheduleOfRates";
            _dgScheduleOfRates.Size = new Size(416, 82);
            _dgScheduleOfRates.TabIndex = 5;
            //
            // Label8
            //
            _Label8.Location = new Point(208, 264);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(128, 23);
            _Label8.TabIndex = 102;
            _Label8.Text = "Rate Total Per Visit";
            _Label8.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtRatesTotal
            //
            _txtRatesTotal.Enabled = false;
            _txtRatesTotal.Location = new Point(344, 264);
            _txtRatesTotal.MaxLength = 50;
            _txtRatesTotal.Name = "txtRatesTotal";
            _txtRatesTotal.Size = new Size(72, 21);
            _txtRatesTotal.TabIndex = 11;
            _txtRatesTotal.Tag = "SystemScheduleOfRate.Code";
            _txtRatesTotal.Text = "";
            //
            // txtTotalSitePrice
            //
            _txtTotalSitePrice.Location = new Point(344, 288);
            _txtTotalSitePrice.Name = "txtTotalSitePrice";
            _txtTotalSitePrice.Size = new Size(72, 21);
            _txtTotalSitePrice.TabIndex = 13;
            _txtTotalSitePrice.Text = "";
            //
            // Label6
            //
            _Label6.Location = new Point(208, 288);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(104, 23);
            _Label6.TabIndex = 106;
            _Label6.Text = "Total Work Price";
            _Label6.TextAlign = ContentAlignment.MiddleLeft;
            //
            // chkRates
            //
            _chkRates.Location = new Point(8, 264);
            _chkRates.Name = "chkRates";
            _chkRates.Size = new Size(176, 23);
            _chkRates.TabIndex = 10;
            _chkRates.Text = "Include Rates in Visit Total";
            //
            // Label9
            //
            _Label9.Location = new Point(208, 192);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(96, 16);
            _Label9.TabIndex = 109;
            _Label9.Text = "Item Total";
            _Label9.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtItemTotal
            //
            _txtItemTotal.Enabled = false;
            _txtItemTotal.Location = new Point(344, 192);
            _txtItemTotal.MaxLength = 50;
            _txtItemTotal.Name = "txtItemTotal";
            _txtItemTotal.Size = new Size(72, 21);
            _txtItemTotal.TabIndex = 5;
            _txtItemTotal.Tag = "SystemScheduleOfRate.Code";
            _txtItemTotal.Text = "";
            //
            // txtPricePerVisit
            //
            _txtPricePerVisit.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPricePerVisit.Location = new Point(128, 288);
            _txtPricePerVisit.MaxLength = 9;
            _txtPricePerVisit.Name = "txtPricePerVisit";
            _txtPricePerVisit.Size = new Size(72, 21);
            _txtPricePerVisit.TabIndex = 12;
            _txtPricePerVisit.Tag = "ContractSite.PricePerVisit";
            _txtPricePerVisit.Text = "";
            //
            // lblPricePerVisit
            //
            _lblPricePerVisit.BackColor = Color.White;
            _lblPricePerVisit.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblPricePerVisit.Location = new Point(8, 288);
            _lblPricePerVisit.Name = "lblPricePerVisit";
            _lblPricePerVisit.Size = new Size(120, 20);
            _lblPricePerVisit.TabIndex = 108;
            _lblPricePerVisit.Text = "Total Price Per Visit";
            _lblPricePerVisit.TextAlign = ContentAlignment.MiddleLeft;
            //
            // Label5
            //
            _Label5.Location = new Point(8, 216);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(102, 21);
            _Label5.TabIndex = 105;
            _Label5.Text = "Mileage Per Visit";
            _Label5.TextAlign = ContentAlignment.MiddleLeft;
            //
            // Label4
            //
            _Label4.Location = new Point(208, 216);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(82, 21);
            _Label4.TabIndex = 104;
            _Label4.Text = "Price Per Mile";
            _Label4.TextAlign = ContentAlignment.MiddleLeft;
            //
            // Label2
            //
            _Label2.Location = new Point(208, 240);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(136, 21);
            _Label2.TabIndex = 103;
            _Label2.Text = "Mileage Total Per Visit";
            _Label2.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtMileageCostPerVisit
            //
            _txtMileageCostPerVisit.Enabled = false;
            _txtMileageCostPerVisit.Location = new Point(344, 240);
            _txtMileageCostPerVisit.Name = "txtMileageCostPerVisit";
            _txtMileageCostPerVisit.Size = new Size(72, 21);
            _txtMileageCostPerVisit.TabIndex = 9;
            _txtMileageCostPerVisit.Text = "";
            //
            // txtAverageMileage
            //
            _txtAverageMileage.Location = new Point(128, 216);
            _txtAverageMileage.Name = "txtAverageMileage";
            _txtAverageMileage.Size = new Size(72, 21);
            _txtAverageMileage.TabIndex = 6;
            _txtAverageMileage.Text = "0";
            //
            // txtCostPerMile
            //
            _txtCostPerMile.Location = new Point(344, 216);
            _txtCostPerMile.Name = "txtCostPerMile";
            _txtCostPerMile.Size = new Size(72, 21);
            _txtCostPerMile.TabIndex = 7;
            _txtCostPerMile.Text = "£0.00";
            //
            // chkIncludeMileage
            //
            _chkIncludeMileage.Location = new Point(8, 240);
            _chkIncludeMileage.Name = "chkIncludeMileage";
            _chkIncludeMileage.Size = new Size(193, 21);
            _chkIncludeMileage.TabIndex = 8;
            _chkIncludeMileage.Text = "Include Mileage in Visit Total";
            //
            // btnRemoveFromJobOfWork
            //
            _btnRemoveFromJobOfWork.UseVisualStyleBackColor = true;
            _btnRemoveFromJobOfWork.Location = new Point(352, 8);
            _btnRemoveFromJobOfWork.Name = "btnRemoveFromJobOfWork";
            _btnRemoveFromJobOfWork.Size = new Size(96, 23);
            _btnRemoveFromJobOfWork.TabIndex = 1;
            _btnRemoveFromJobOfWork.Text = "Remove";
            //
            // dgVisits
            //
            _dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVisits.DataMember = "";
            _dgVisits.HeaderForeColor = SystemColors.ControlText;
            _dgVisits.Location = new Point(424, 224);
            _dgVisits.Name = "dgVisits";
            _dgVisits.Size = new Size(456, 80);
            _dgVisits.TabIndex = 14;
            //
            // dgJobItemsAdded
            //
            _dgJobItemsAdded.DataMember = "";
            _dgJobItemsAdded.HeaderForeColor = SystemColors.ControlText;
            _dgJobItemsAdded.Location = new Point(8, 32);
            _dgJobItemsAdded.Name = "dgJobItemsAdded";
            _dgJobItemsAdded.Size = new Size(440, 160);
            _dgJobItemsAdded.TabIndex = 2;
            //
            // dtpFirstVisitDate
            //
            _dtpFirstVisitDate.CalendarFont = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dtpFirstVisitDate.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dtpFirstVisitDate.Format = DateTimePickerFormat.Short;
            _dtpFirstVisitDate.Location = new Point(104, 192);
            _dtpFirstVisitDate.Name = "dtpFirstVisitDate";
            _dtpFirstVisitDate.Size = new Size(96, 21);
            _dtpFirstVisitDate.TabIndex = 4;
            _dtpFirstVisitDate.Tag = "ContractSite.FirstVisitDate";
            _dtpFirstVisitDate.Value = new DateTime(2007, 6, 18, 15, 21, 39, 569);
            //
            // lblFirstVisitDate
            //
            _lblFirstVisitDate.BackColor = Color.White;
            _lblFirstVisitDate.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblFirstVisitDate.Location = new Point(8, 192);
            _lblFirstVisitDate.Name = "lblFirstVisitDate";
            _lblFirstVisitDate.Size = new Size(96, 16);
            _lblFirstVisitDate.TabIndex = 98;
            _lblFirstVisitDate.Text = "First Visit Date";
            //
            // Label1
            //
            _Label1.Location = new Point(424, 208);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(100, 16);
            _Label1.TabIndex = 101;
            _Label1.Text = "PPM Scheduled";
            //
            // Label3
            //
            _Label3.Location = new Point(8, 8);
            _Label3.Name = "Label3";
            _Label3.TabIndex = 100;
            _Label3.Text = "Job Items Added";
            //
            // UCQuoteJobOfWork
            //
            Controls.Add(_grpScheduleOfRates);
            Controls.Add(_Label8);
            Controls.Add(_txtRatesTotal);
            Controls.Add(_txtTotalSitePrice);
            Controls.Add(_Label6);
            Controls.Add(_chkRates);
            Controls.Add(_Label9);
            Controls.Add(_txtItemTotal);
            Controls.Add(_txtPricePerVisit);
            Controls.Add(_lblPricePerVisit);
            Controls.Add(_Label5);
            Controls.Add(_Label4);
            Controls.Add(_Label2);
            Controls.Add(_txtMileageCostPerVisit);
            Controls.Add(_txtAverageMileage);
            Controls.Add(_txtCostPerMile);
            Controls.Add(_chkIncludeMileage);
            Controls.Add(_btnRemoveFromJobOfWork);
            Controls.Add(_dgVisits);
            Controls.Add(_dgJobItemsAdded);
            Controls.Add(_dtpFirstVisitDate);
            Controls.Add(_lblFirstVisitDate);
            Controls.Add(_Label1);
            Controls.Add(_Label3);
            Name = "UCQuoteJobOfWork";
            Size = new Size(896, 312);
            _grpScheduleOfRates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRates).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgVisits).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgJobItemsAdded).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupJobItemsDataGrid();
            SetupVisitDataGrid();
            SetupScheduleOfRatesDataGrid();
        }

        public object LoadedItem
        {
            get
            {
                return null;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public event RemovedItemEventHandler RemovedItem;

        public delegate void RemovedItemEventHandler();

        private UCQuoteContractAlternativeSite _onControl = null;

        public UCQuoteContractAlternativeSite OnControl
        {
            get
            {
                return _onControl;
            }

            set
            {
                _onControl = value;
            }
        }

        private Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork _CurrentJobOfWork;

        public Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork CurrentJobOfWork
        {
            get
            {
                return _CurrentJobOfWork;
            }

            set
            {
                _CurrentJobOfWork = value;
                txtCostPerMile.Text = Strings.Format(App.DB.CustomerCharge.CustomerCharge_GetForSite(OnControl.CurrentQuoteContractSite.SiteID).MileageRate, "C");
                txtPricePerVisit.Text = "£0.00";
                ScheduleOfRatesDataview = BuildUpScheduleOfRatesDataview();
                if (_CurrentJobOfWork is null)
                {
                    _CurrentJobOfWork = new Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork();
                    dtpFirstVisitDate.Value = OnControl.CurrentQuoteContract.ContractStart.AddDays(1);
                    _CurrentJobOfWork.FirstVisitDate = OnControl.CurrentQuoteContract.ContractStart.AddDays(1);
                }

                dtpFirstVisitDate.Value = _CurrentJobOfWork.FirstVisitDate;
                JobItemsAddedDataView = App.DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(_CurrentJobOfWork.QuoteContractSiteJobOfWorkID);
                Visits = App.DB.QuoteContractAlternativePPMVisits.GetAll_For_QuoteContractSiteJobOfWorkID(_CurrentJobOfWork.QuoteContractSiteJobOfWorkID);
                if (Visits.Table.Rows.Count > 0)
                {
                    dtpFirstVisitDate.Enabled = false;
                    btnRemoveFromJobOfWork.Enabled = false;
                }
                else
                {
                    dtpFirstVisitDate.Enabled = true;
                    btnRemoveFromJobOfWork.Enabled = true;
                }

                var argc = cboScheduleOfRatesCategoryID;
                Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
                Populate();
            }
        }

        private DataView _JobItemsAddedDataView;

        public DataView JobItemsAddedDataView
        {
            get
            {
                return _JobItemsAddedDataView;
            }

            set
            {
                _JobItemsAddedDataView = value;
                _JobItemsAddedDataView.AllowNew = false;
                _JobItemsAddedDataView.AllowEdit = false;
                _JobItemsAddedDataView.AllowDelete = false;
                _JobItemsAddedDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
                dgJobItemsAdded.DataSource = JobItemsAddedDataView;
            }
        }

        private DataRow SelectedJobItemsDataRow
        {
            get
            {
                if (!(dgJobItemsAdded.CurrentRowIndex == -1))
                {
                    return JobItemsAddedDataView[dgJobItemsAdded.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _Visits;

        public DataView Visits
        {
            get
            {
                return _Visits;
            }

            set
            {
                _Visits = value;
                _Visits.Table.TableName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString();
                _Visits.AllowNew = false;
                _Visits.AllowEdit = true;
                _Visits.AllowDelete = false;
                dgVisits.DataSource = Visits;
            }
        }

        private DataView _ScheduleOfRatesDataview;

        public DataView ScheduleOfRatesDataview
        {
            get
            {
                return _ScheduleOfRatesDataview;
            }

            set
            {
                _ScheduleOfRatesDataview = value;
                _ScheduleOfRatesDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
                _ScheduleOfRatesDataview.AllowNew = false;
                _ScheduleOfRatesDataview.AllowEdit = true;
                _ScheduleOfRatesDataview.AllowDelete = false;
                dgScheduleOfRates.DataSource = ScheduleOfRatesDataview;
            }
        }

        private DataRow SelectedRatesDataRow
        {
            get
            {
                if (!(dgScheduleOfRates.CurrentRowIndex == -1))
                {
                    return ScheduleOfRatesDataview[dgScheduleOfRates.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private bool _isLoading = false;

        private bool IsLoading
        {
            get
            {
                return _isLoading;
            }

            set
            {
                _isLoading = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupJobItemsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgJobItemsAdded);
            var tStyle = dgJobItemsAdded.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 100;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var PricePerVisit = new DataGridLabelColumn();
            PricePerVisit.Format = "C";
            PricePerVisit.FormatInfo = null;
            PricePerVisit.HeaderText = "Item Price Per Visit";
            PricePerVisit.MappingName = "ItemPricePerVisit";
            PricePerVisit.ReadOnly = true;
            PricePerVisit.Width = 85;
            PricePerVisit.NullText = "";
            tStyle.GridColumnStyles.Add(PricePerVisit);
            var VisitFrequency = new DataGridLabelColumn();
            VisitFrequency.Format = "";
            VisitFrequency.FormatInfo = null;
            VisitFrequency.HeaderText = "Visit Frequency";
            VisitFrequency.MappingName = "VisitFrequency";
            VisitFrequency.ReadOnly = true;
            VisitFrequency.Width = 100;
            VisitFrequency.NullText = "";
            tStyle.GridColumnStyles.Add(VisitFrequency);
            var VisitDuration = new DataGridLabelColumn();
            VisitDuration.Format = "";
            VisitDuration.FormatInfo = null;
            VisitDuration.HeaderText = "Visit Duration";
            VisitDuration.MappingName = "VisitDuration";
            VisitDuration.ReadOnly = true;
            VisitDuration.Width = 90;
            VisitDuration.NullText = "";
            VisitDuration.Alignment = HorizontalAlignment.Center;
            tStyle.GridColumnStyles.Add(VisitDuration);
            var Assets = new DataGridLabelColumn();
            Assets.Format = "C";
            Assets.FormatInfo = null;
            Assets.HeaderText = "Assets";
            Assets.MappingName = "Assets";
            Assets.ReadOnly = true;
            Assets.Width = 130;
            Assets.NullText = "";
            tStyle.GridColumnStyles.Add(Assets);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
            dgJobItemsAdded.TableStyles.Add(tStyle);
        }

        public void SetupVisitDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgVisits);
            var tStyle = dgVisits.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var EstimatedVisitDate = new DataGridLabelColumn();
            EstimatedVisitDate.Format = "dd/MM/yyyy";
            EstimatedVisitDate.FormatInfo = null;
            EstimatedVisitDate.HeaderText = "Estimated Visit Date";
            EstimatedVisitDate.MappingName = "EstimatedVisitDate";
            EstimatedVisitDate.ReadOnly = true;
            EstimatedVisitDate.Width = 150;
            EstimatedVisitDate.NullText = "";
            tStyle.GridColumnStyles.Add(EstimatedVisitDate);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "JobNumber";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 100;
            JobNumber.NullText = "";
            tStyle.GridColumnStyles.Add(JobNumber);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yyyy";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Visit Date";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 100;
            StartDateTime.NullText = "Not Set";
            tStyle.GridColumnStyles.Add(StartDateTime);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Engineer";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 100;
            Name.NullText = "N/A";
            tStyle.GridColumnStyles.Add(Name);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString();
            dgVisits.TableStyles.Add(tStyle);
        }

        public void SetupScheduleOfRatesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgScheduleOfRates);
            var tStyle = dgScheduleOfRates.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 95;
            Category.NullText = "";
            tStyle.GridColumnStyles.Add(Category);
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Code";
            Code.MappingName = "Code";
            Code.ReadOnly = true;
            Code.Width = 75;
            Code.NullText = "";
            tStyle.GridColumnStyles.Add(Code);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 105;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Unit Price";
            Price.MappingName = "Price";
            Price.ReadOnly = false;
            Price.Width = 60;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var QtyPerVisit = new DataGridLabelColumn();
            QtyPerVisit.Format = "";
            QtyPerVisit.FormatInfo = null;
            QtyPerVisit.HeaderText = "Unit Qty Per Visit";
            QtyPerVisit.MappingName = "QtyPerVisit";
            QtyPerVisit.ReadOnly = false;
            QtyPerVisit.Width = 100;
            QtyPerVisit.NullText = "";
            tStyle.GridColumnStyles.Add(QtyPerVisit);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
            dgScheduleOfRates.TableStyles.Add(tStyle);
        }

        private void UCJobOfWork_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnRemoveFromJobOfWork_Click(object sender, EventArgs e)
        {
            if (SelectedJobItemsDataRow is null)
            {
                return;
            }

            App.DB.QuoteContractAlternativeSiteJobItems.Update(Conversions.ToInteger(SelectedJobItemsDataRow["QuoteContractSiteJobItemID"]), 0);
            CalculateItemTotal();
            RemovedItem?.Invoke();
        }

        private void dtpFirstVisitDate_LostFocus(object sender, EventArgs e)
        {
            if (dtpFirstVisitDate.Value < OnControl.CurrentQuoteContract.ContractStart | dtpFirstVisitDate.Value > OnControl.CurrentQuoteContract.ContractEnd)
            {
                App.ShowMessage("First Visit must be inside the contract boundaries", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFirstVisitDate.Value = OnControl.CurrentQuoteContract.ContractStart.AddDays(1);
            }
            else
            {
                CurrentJobOfWork.FirstVisitDate = dtpFirstVisitDate.Value;
            }
        }

        private void dgJobItemsAdded_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgJobItemsAdded.HitTest(e.X, e.Y);
            if (HitTestInfo.Column == 4)
            {
                App.ShowForm(typeof(FRMQuoteJobItemAssets), true, new object[] { SelectedJobItemsDataRow["QuoteContractSiteJobItemID"] });
            }
        }

        private void txtPricePerVisit_LostFocus(object sender, EventArgs e)
        {
            string price = "";
            if (txtPricePerVisit.Text.Trim().Length == 0)
            {
                price = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtPricePerVisit.Text.Replace("£", "")))
            {
                price = Strings.Format(0.0, "C");
            }
            else
            {
                price = Strings.Format(Conversions.ToDouble(txtPricePerVisit.Text.Replace("£", "")), "C");
            }

            txtPricePerVisit.Text = price;
            CalculateSiteTotal();
        }

        private void txtAverageMileage_LostFocus(object sender, EventArgs e)
        {
            string mileage = "";
            if (txtAverageMileage.Text.Trim().Length == 0)
            {
                mileage = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtAverageMileage.Text))
            {
                mileage = Strings.Format(0.0, "C");
            }
            else
            {
                mileage = Strings.Format(Conversions.ToDouble(txtAverageMileage.Text), "F");
            }

            txtAverageMileage.Text = mileage;
            CalculateMileageTotal();
            CalculateSiteTotal();
            CurrentJobOfWork.SetAverageMileage = txtAverageMileage.Text.Replace("£", "");
        }

        private void txtCostPerMile_Focus(object sender, EventArgs e)
        {
            string price = "";
            if (txtCostPerMile.Text.Trim().Length == 0)
            {
                price = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtCostPerMile.Text.Replace("£", "")))
            {
                price = Strings.Format(0.0, "C");
            }
            else
            {
                price = Strings.Format(Conversions.ToDouble(txtCostPerMile.Text.Replace("£", "")), "C");
            }

            txtCostPerMile.Text = price;
            CalculateMileageTotal();
            CalculateSiteTotal();
            CurrentJobOfWork.SetPricePerMile = txtCostPerMile.Text.Replace("£", "");
        }

        private void chkIncludeMileage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncludeMileage.Checked)
            {
                IncludeMileage();
            }
            else
            {
                TakeawayMileage();
            }

            CalculateSiteTotal();
            CurrentJobOfWork.SetIncludeMileagePrice = chkIncludeMileage.Checked;
        }

        private void chkRates_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRates.Checked)
            {
                IncludeRates();
            }
            else
            {
                TakeawayRates();
            }

            CalculateSiteTotal();
            CurrentJobOfWork.SetIncludeRates = chkRates.Checked;
        }

        private void btnAddRates_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string errorMsg = "";
            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboScheduleOfRatesCategoryID)) > 0))
            {
                errorMsg = "* Category is missing" + Constants.vbCrLf;
                valid = false;
            }

            if (txtDescriptionRate.Text.Trim().Length == 0)
            {
                errorMsg += "* Description is missing" + Constants.vbCrLf;
                valid = false;
            }

            if (txtPrice.Text.Trim().Length == 0)
            {
                errorMsg += "* Price is missing" + Constants.vbCrLf;
                valid = false;
            }
            else if (Information.IsNumeric(txtPrice.Text) == false)
            {
                errorMsg += "* Price must be numeric" + Constants.vbCrLf;
                valid = false;
            }

            if (txtQuantityPerVisit.Text.Trim().Length == 0)
            {
                errorMsg += "* Quantity is missing" + Constants.vbCrLf;
                valid = false;
            }
            else if (Information.IsNumeric(txtQuantityPerVisit.Text) == false)
            {
                errorMsg += "* Qty must be numeric" + Constants.vbCrLf;
                valid = false;
            }

            if (valid)
            {
                DataRow newRow;
                newRow = ScheduleOfRatesDataview.Table.NewRow();
                newRow["ScheduleOfRatesCategoryID"] = Combo.get_GetSelectedItemValue(cboScheduleOfRatesCategoryID);
                newRow["Category"] = Combo.get_GetSelectedItemDescription(cboScheduleOfRatesCategoryID);
                newRow["Code"] = txtCode.Text;
                newRow["Description"] = txtDescriptionRate.Text;
                newRow["Price"] = txtPrice.Text;
                newRow["QtyPerVisit"] = txtQuantityPerVisit.Text;
                ScheduleOfRatesDataview.Table.Rows.Add(newRow);
                var argcombo = cboScheduleOfRatesCategoryID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
                txtCode.Text = "";
                txtDescriptionRate.Text = "";
                txtPrice.Text = "";
                txtQuantityPerVisit.Text = "";
                // dgScheduleOfRates.DataSource = ScheduleOfRatesDataview
                CalculateRates();
                CalculateSiteTotal();
            }
            else
            {
                MessageBox.Show("Please correct the following:" + Constants.vbCrLf + errorMsg, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoveRates_Click(object sender, EventArgs e)
        {
            if (SelectedRatesDataRow is object)
            {
                {
                    var withBlock = SelectedRatesDataRow;
                    if ((int)MessageBox.Show(Conversions.ToString("DELETE :" + withBlock["Description"]), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)MsgBoxResult.Yes)
                    {
                        ScheduleOfRatesDataview.Table.Rows.Remove(SelectedRatesDataRow);
                        CalculateRates();
                        CalculateSiteTotal();
                    }
                }
            }
        }

        private void btnSiteScheduleOfRates_Click(object sender, EventArgs e)
        {
            var argDataviewToLinkToIn = ScheduleOfRatesDataview;
            using (var f = new FRMSiteScheduleOfRateList(OnControl.CurrentQuoteContractSite.SiteID, ref argDataviewToLinkToIn))
            {
                f.ShowDialog();
            }

            dgScheduleOfRates.DataSource = ScheduleOfRatesDataview;
            CalculateRates();
            CalculateSiteTotal();
        }

        private void txtTotalSitePrice_LostFocus(object sender, EventArgs e)
        {
            string price = "";
            if (txtTotalSitePrice.Text.Trim().Length == 0)
            {
                price = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtTotalSitePrice.Text.Replace("£", "")))
            {
                price = Strings.Format(0.0, "C");
            }
            else
            {
                price = Strings.Format(Conversions.ToDouble(txtTotalSitePrice.Text.Replace("£", "")), "C");
            }

            txtTotalSitePrice.Text = price;
            CurrentJobOfWork.SetTotalSitePrice = price.Replace("£", "");
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private DataView BuildUpScheduleOfRatesDataview()
        {
            var newTable = new DataTable();
            newTable.Columns.Add("ScheduleOfRatesCategoryID");
            newTable.Columns.Add("Category");
            newTable.Columns.Add("Code");
            newTable.Columns.Add("Description");
            newTable.Columns.Add("Price");
            newTable.Columns.Add("QtyPerVisit");
            newTable.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
            return new DataView(newTable);
        }

        private void IncludeMileage()
        {
            txtPricePerVisit.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) + Entity.Sys.Helper.MakeDoubleValid(txtMileageCostPerVisit.Text.Replace("£", "")), "C");
        }

        private void TakeawayMileage()
        {
            txtPricePerVisit.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) - Entity.Sys.Helper.MakeDoubleValid(txtMileageCostPerVisit.Text.Replace("£", "")), "C");
        }

        private void IncludeRates()
        {
            txtPricePerVisit.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) + Entity.Sys.Helper.MakeDoubleValid(txtRatesTotal.Text.Replace("£", "")), "C");
        }

        private void TakeawayRates()
        {
            txtPricePerVisit.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) - Entity.Sys.Helper.MakeDoubleValid(txtRatesTotal.Text.Replace("£", "")), "C");
        }

        private void CalculateRates()
        {
            decimal oldTotal = 0.0M;
            decimal runningTotal = 0.0M;
            if (txtRatesTotal.Text.Trim().Length == 0)
            {
                txtRatesTotal.Text = "£0.00";
            }
            else
            {
                oldTotal = Conversions.ToDecimal(txtRatesTotal.Text.Replace("£", "0"));
            }

            foreach (DataRow rate in ScheduleOfRatesDataview.Table.Rows)
                runningTotal += (decimal)rate["Price"] * (int)rate["QtyPerVisit"];
            txtRatesTotal.Text = Strings.Format(runningTotal, "C");
            if (chkRates.Checked)
            {
                txtPricePerVisit.Text = (Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) - Conversions.ToDouble(oldTotal)).ToString();
                txtPricePerVisit.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) + Conversions.ToDouble(runningTotal), "C");
            }
        }

        private void CalculateMileageTotal()
        {
            decimal oldTotal = 0.0M;
            if (txtMileageCostPerVisit.Text.Trim().Length == 0)
            {
                txtMileageCostPerVisit.Text = "£0.00";
            }
            else
            {
                oldTotal = Conversions.ToDecimal(txtMileageCostPerVisit.Text.Replace("£", "0"));
            }

            txtMileageCostPerVisit.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(txtAverageMileage.Text) * Entity.Sys.Helper.MakeDoubleValid(txtCostPerMile.Text.Replace("£", "")), "C");
            if (chkIncludeMileage.Checked)
            {
                txtPricePerVisit.Text = (Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) - Conversions.ToDouble(oldTotal)).ToString();
                txtPricePerVisit.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) + Conversions.ToDouble(txtMileageCostPerVisit.Text.Replace("£", "")), "C");
            }
        }

        public void CalculateItemTotal()
        {
            decimal oldTotal = 0.0M;
            decimal runningTotal = 0.0M;
            if (txtItemTotal.Text.Trim().Length == 0)
            {
                txtItemTotal.Text = "£0.00";
            }
            else
            {
                oldTotal = Conversions.ToDecimal(txtItemTotal.Text.Replace("£", "0"));
            }

            foreach (DataRow ji in JobItemsAddedDataView.Table.Rows)
                runningTotal += (decimal)ji["ItemPricePerVisit"];
            txtItemTotal.Text = Strings.Format(runningTotal, "C");
            txtPricePerVisit.Text = (Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) - Conversions.ToDouble(oldTotal)).ToString();
            txtPricePerVisit.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(txtPricePerVisit.Text.Replace("£", "")) + Conversions.ToDouble(runningTotal), "C");
            CalculateSiteTotal();
        }

        private void CalculateSiteTotal()
        {
            int numberOfVisit = 0;
            string price = "";
            if (txtPricePerVisit.Text.Trim().Length == 0)
            {
                price = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtPricePerVisit.Text.Replace("£", "")))
            {
                price = Strings.Format(0.0, "C");
            }
            else
            {
                price = Strings.Format(Conversions.ToDouble(txtPricePerVisit.Text.Replace("£", "")), "C");
            }

            txtPricePerVisit.Text = price;
            if (SelectedJobItemsDataRow is object)
            {
                var switchExpr = (Entity.Sys.Enums.VisitFrequency)Conversions.ToInteger(SelectedJobItemsDataRow["VisitFrequencyID"]);
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.VisitFrequency.Annually:
                        {
                            numberOfVisit = 1;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Bi_Annually:
                        {
                            numberOfVisit = 2;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Monthly:
                        {
                            numberOfVisit = 12;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Quarterly:
                        {
                            numberOfVisit = 4;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Weekly:
                        {
                            numberOfVisit = 52;
                            break;
                        }
                }
            }

            if (numberOfVisit == 0)
            {
                txtTotalSitePrice.Text = "£0.00";
            }
            else
            {
                txtTotalSitePrice.Text = Strings.Format(Conversions.ToDouble(txtPricePerVisit.Text.Replace("£", "")) * numberOfVisit, "C");
            }

            if (IsLoading == false)
            {
                CurrentJobOfWork.SetPricePerVisit = price.Replace("£", "");
                CurrentJobOfWork.SetTotalSitePrice = txtTotalSitePrice.Text.Replace("£", "");
            }
        }

        public void Populate(int ID = 0)
        {
            IsLoading = true;
            dtpFirstVisitDate.Value = CurrentJobOfWork.FirstVisitDate;
            txtAverageMileage.Text = CurrentJobOfWork.AverageMileage.ToString();
            txtCostPerMile.Text = Strings.Format(CurrentJobOfWork.PricePerMile, "C");
            chkIncludeMileage.Checked = CurrentJobOfWork.IncludeMileagePrice;
            chkRates.Checked = CurrentJobOfWork.IncludeRates;
            ScheduleOfRatesDataview = App.DB.QuoteContractAlternativeSiteJobOfWork.GetJobOfWorkScheduleOfRates(CurrentJobOfWork.QuoteContractSiteJobOfWorkID);
            CalculateRates();
            CalculateMileageTotal();
            CalculateItemTotal();
            CalculateSiteTotal();
            txtPricePerVisit.Text = Strings.Format(CurrentJobOfWork.PricePerVisit, "C");
            txtTotalSitePrice.Text = Strings.Format(CurrentJobOfWork.TotalSitePrice, "C");
            IsLoading = false;
            CurrentJobOfWork.SetPricePerVisit = txtPricePerVisit.Text.Replace("£", "");
            CurrentJobOfWork.SetTotalSitePrice = txtTotalSitePrice.Text.Replace("£", "");
        }

        public bool Save()
        {
            try
            {
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}