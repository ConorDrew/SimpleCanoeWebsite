using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class pnlUnscheduledCalls : UserControl
    {
        private Splitter _splitForm;

        internal Splitter splitForm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _splitForm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_splitForm != null)
                {
                    _splitForm.MouseDown -= splitForm_MouseDown;
                    _splitForm.MouseMove -= splitForm_MouseMove;
                    _splitForm.MouseUp -= splitForm_MouseUp;
                }

                _splitForm = value;
                if (_splitForm != null)
                {
                    _splitForm.MouseDown += splitForm_MouseDown;
                    _splitForm.MouseMove += splitForm_MouseMove;
                    _splitForm.MouseUp += splitForm_MouseUp;
                }
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
                if (_pnlHeader != null)
                {
                }

                _pnlHeader = value;
                if (_pnlHeader != null)
                {
                }
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
                if (_lblTitle != null)
                {
                }

                _lblTitle = value;
                if (_lblTitle != null)
                {
                }
            }
        }

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                    _cboType.SelectedIndexChanged -= cboType_SelectedIndexChanged;
                }

                _cboType = value;
                if (_cboType != null)
                {
                    _cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
                }
            }
        }

        private Label _Label15;

        internal Label Label15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label15 != null)
                {
                }

                _Label15 = value;
                if (_Label15 != null)
                {
                }
            }
        }

        private CheckBox _chkHasPartsToFit;

        internal CheckBox chkHasPartsToFit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkHasPartsToFit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkHasPartsToFit != null)
                {
                    _chkHasPartsToFit.CheckedChanged -= chkHasPartsToFit_CheckedChanged;
                }

                _chkHasPartsToFit = value;
                if (_chkHasPartsToFit != null)
                {
                    _chkHasPartsToFit.CheckedChanged += chkHasPartsToFit_CheckedChanged;
                }
            }
        }

        private Label _Label16;

        internal Label Label16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label16 != null)
                {
                }

                _Label16 = value;
                if (_Label16 != null)
                {
                }
            }
        }

        private CheckBox _chkEstimatedVisitDate;

        internal CheckBox chkEstimatedVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkEstimatedVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkEstimatedVisitDate != null)
                {
                    _chkEstimatedVisitDate.CheckedChanged -= chkEstimatedVisitDate_CheckedChanged;
                }

                _chkEstimatedVisitDate = value;
                if (_chkEstimatedVisitDate != null)
                {
                    _chkEstimatedVisitDate.CheckedChanged += chkEstimatedVisitDate_CheckedChanged;
                }
            }
        }

        private DateTimePicker _dtpTo;

        internal DateTimePicker dtpTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTo != null)
                {
                    _dtpTo.ValueChanged -= dtpTo_ValueChanged;
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                    _dtpTo.ValueChanged += dtpTo_ValueChanged;
                }
            }
        }

        private DateTimePicker _dtpFrom;

        internal DateTimePicker dtpFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFrom != null)
                {
                    _dtpFrom.ValueChanged -= dtpFrom_ValueChanged;
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
                {
                    _dtpFrom.ValueChanged += dtpFrom_ValueChanged;
                }
            }
        }

        private Label _Label17;

        internal Label Label17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label17 != null)
                {
                }

                _Label17 = value;
                if (_Label17 != null)
                {
                }
            }
        }

        private CheckBox _chkDeclined;

        internal CheckBox chkDeclined
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDeclined;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDeclined != null)
                {
                    _chkDeclined.CheckedChanged -= chkDeclined_CheckedChanged;
                }

                _chkDeclined = value;
                if (_chkDeclined != null)
                {
                    _chkDeclined.CheckedChanged += chkDeclined_CheckedChanged;
                }
            }
        }

        private Label _Label18;

        internal Label Label18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label18 != null)
                {
                }

                _Label18 = value;
                if (_Label18 != null)
                {
                }
            }
        }

        private ComboBox _cboSiteFuel;

        internal ComboBox cboSiteFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSiteFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSiteFuel != null)
                {
                    _cboSiteFuel.SelectedIndexChanged -= cboSiteFuel_SelectedIndexChanged;
                }

                _cboSiteFuel = value;
                if (_cboSiteFuel != null)
                {
                    _cboSiteFuel.SelectedIndexChanged += cboSiteFuel_SelectedIndexChanged;
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

        private ComboBox _cboRegion;

        internal ComboBox cboRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRegion != null)
                {
                    _cboRegion.SelectedIndexChanged -= cboRegion_SelectedIndexChanged;
                }

                _cboRegion = value;
                if (_cboRegion != null)
                {
                    _cboRegion.SelectedIndexChanged += cboRegion_SelectedIndexChanged;
                }
            }
        }

        private TextBox _TextBox1;

        internal TextBox TextBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBox1 != null)
                {
                    _TextBox1.TextChanged -= TextBox1_TextChanged;
                }

                _TextBox1 = value;
                if (_TextBox1 != null)
                {
                    _TextBox1.TextChanged += TextBox1_TextChanged;
                }
            }
        }

        private Label _Label10;

        internal Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label10 != null)
                {
                }

                _Label10 = value;
                if (_Label10 != null)
                {
                }
            }
        }

        private CheckBox _chkPNO;

        internal CheckBox chkPNO
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPNO;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPNO != null)
                {
                    _chkPNO.CheckedChanged -= chkPNO_CheckedChanged;
                }

                _chkPNO = value;
                if (_chkPNO != null)
                {
                    _chkPNO.CheckedChanged += chkPNO_CheckedChanged;
                }
            }
        }

        private CheckBox _chkWaitingParts;

        internal CheckBox chkWaitingParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkWaitingParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkWaitingParts != null)
                {
                    _chkWaitingParts.CheckedChanged -= chkWaitingParts_CheckedChanged;
                }

                _chkWaitingParts = value;
                if (_chkWaitingParts != null)
                {
                    _chkWaitingParts.CheckedChanged += chkWaitingParts_CheckedChanged;
                }
            }
        }

        private Label _Label20;

        internal Label Label20
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label20;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label20 != null)
                {
                }

                _Label20 = value;
                if (_Label20 != null)
                {
                }
            }
        }

        private Panel _Panel7;

        internal Panel Panel7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel7 != null)
                {
                }

                _Panel7 = value;
                if (_Panel7 != null)
                {
                }
            }
        }

        private Panel _Panel6;

        internal Panel Panel6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel6 != null)
                {
                }

                _Panel6 = value;
                if (_Panel6 != null)
                {
                }
            }
        }

        private Label _Label19;

        internal Label Label19
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label19;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label19 != null)
                {
                }

                _Label19 = value;
                if (_Label19 != null)
                {
                }
            }
        }

        private Label _lblQualification;

        internal Label lblQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQualification != null)
                {
                }

                _lblQualification = value;
                if (_lblQualification != null)
                {
                }
            }
        }

        private ComboBox _cboQualification;

        internal ComboBox cboQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQualification != null)
                {
                    _cboQualification.SelectedIndexChanged -= cboQualification_SelectedIndexChanged;
                }

                _cboQualification = value;
                if (_cboQualification != null)
                {
                    _cboQualification.SelectedIndexChanged += cboQualification_SelectedIndexChanged;
                }
            }
        }

        private CheckBox _chkViewAll;

        internal CheckBox chkViewAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkViewAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkViewAll != null)
                {
                    _chkViewAll.Click -= chkViewAll_Click;
                }

                _chkViewAll = value;
                if (_chkViewAll != null)
                {
                    _chkViewAll.Click += chkViewAll_Click;
                }
            }
        }

        private Panel _pnlControls;

        internal Panel pnlControls
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlControls;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlControls != null)
                {
                }

                _pnlControls = value;
                if (_pnlControls != null)
                {
                }
            }
        }

        public pnlUnscheduledCalls(MouseEventHandler gridMouseDown, MouseEventHandler gridMouseMove, DragEventHandler gridDragOver, DragEventHandler gridDragDrop, MouseEventHandler gridMouseUp, int TEXTSIZEs) : base()
        {
            TEXTSIZE = TEXTSIZEs;
            InitializeComponent();
            base.Load += pnlUnscheduledCalls_Load;
            dgCalls.MouseDown += gridMouseDown;
            dgCalls.MouseMove += gridMouseMove;
            dgCalls.DragOver += gridDragOver;
            dgCalls.DragDrop += gridDragDrop;
            dgCalls.MouseUp += gridMouseUp;
        }

        private Panel _pnlTop;

        internal Panel pnlTop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlTop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlTop != null)
                {
                }

                _pnlTop = value;
                if (_pnlTop != null)
                {
                }
            }
        }

        private ContextMenu _mnuVisitAction;

        internal ContextMenu mnuVisitAction
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuVisitAction;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuVisitAction != null)
                {
                }

                _mnuVisitAction = value;
                if (_mnuVisitAction != null)
                {
                }
            }
        }

        private MenuItem _mnuView;

        internal MenuItem mnuView
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuView;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuView != null)
                {
                }

                _mnuView = value;
                if (_mnuView != null)
                {
                }
            }
        }

        private Panel _pnlLegend;

        internal Panel pnlLegend
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlLegend;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlLegend != null)
                {
                }

                _pnlLegend = value;
                if (_pnlLegend != null)
                {
                }
            }
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
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

        private TextBox _txtSearchPostcode;

        internal TextBox txtSearchPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearchPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearchPostcode != null)
                {
                    _txtSearchPostcode.TextChanged -= TextBox_Filter;
                }

                _txtSearchPostcode = value;
                if (_txtSearchPostcode != null)
                {
                    _txtSearchPostcode.TextChanged += TextBox_Filter;
                }
            }
        }

        private TextBox _txtSearchJobNo;

        internal TextBox txtSearchJobNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearchJobNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearchJobNo != null)
                {
                    _txtSearchJobNo.TextChanged -= TextBox_Filter;
                }

                _txtSearchJobNo = value;
                if (_txtSearchJobNo != null)
                {
                    _txtSearchJobNo.TextChanged += TextBox_Filter;
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

        private DataGrid _dgCalls;

        internal DataGrid dgCalls
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgCalls;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgCalls != null)
                {
                    _dgCalls.DoubleClick -= dgCalls_DoubleClick;
                }

                _dgCalls = value;
                if (_dgCalls != null)
                {
                    _dgCalls.DoubleClick += dgCalls_DoubleClick;
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                }
            }
        }

        private Panel _Panel2;

        internal Panel Panel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel2 != null)
                {
                }

                _Panel2 = value;
                if (_Panel2 != null)
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

        private Panel _Panel3;

        internal Panel Panel3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel3 != null)
                {
                }

                _Panel3 = value;
                if (_Panel3 != null)
                {
                }
            }
        }

        private Panel _Panel4;

        internal Panel Panel4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel4 != null)
                {
                }

                _Panel4 = value;
                if (_Panel4 != null)
                {
                }
            }
        }

        private TextBox _txtSearchAddress1;

        internal TextBox txtSearchAddress1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearchAddress1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearchAddress1 != null)
                {
                    _txtSearchAddress1.TextChanged -= TextBox_Filter;
                }

                _txtSearchAddress1 = value;
                if (_txtSearchAddress1 != null)
                {
                    _txtSearchAddress1.TextChanged += TextBox_Filter;
                }
            }
        }

        private TextBox _txtSearchCustomerName;

        internal TextBox txtSearchCustomerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearchCustomerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearchCustomerName != null)
                {
                    _txtSearchCustomerName.TextChanged -= TextBox_Filter;
                }

                _txtSearchCustomerName = value;
                if (_txtSearchCustomerName != null)
                {
                    _txtSearchCustomerName.TextChanged += TextBox_Filter;
                }
            }
        }

        private Label _lblOverdue;

        internal Label lblOverdue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOverdue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOverdue != null)
                {
                }

                _lblOverdue = value;
                if (_lblOverdue != null)
                {
                }
            }
        }

        private PictureBox _picRegion;

        internal PictureBox picRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picRegion != null)
                {
                }

                _picRegion = value;
                if (_picRegion != null)
                {
                }
            }
        }

        private PictureBox _picPostalRegions;

        internal PictureBox picPostalRegions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picPostalRegions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picPostalRegions != null)
                {
                }

                _picPostalRegions = value;
                if (_picPostalRegions != null)
                {
                }
            }
        }

        private PictureBox _picLevels;

        internal PictureBox picLevels
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picLevels;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picLevels != null)
                {
                }

                _picLevels = value;
                if (_picLevels != null)
                {
                }
            }
        }

        private Label _Label12;

        internal Label Label12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label12 != null)
                {
                }

                _Label12 = value;
                if (_Label12 != null)
                {
                }
            }
        }

        private Label _Label13;

        internal Label Label13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label13 != null)
                {
                }

                _Label13 = value;
                if (_Label13 != null)
                {
                }
            }
        }

        private Label _Label14;

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(pnlUnscheduledCalls));
            _splitForm = new Splitter();
            _splitForm.MouseDown += new MouseEventHandler(splitForm_MouseDown);
            _splitForm.MouseMove += new MouseEventHandler(splitForm_MouseMove);
            _splitForm.MouseUp += new MouseEventHandler(splitForm_MouseUp);
            _mnuVisitAction = new ContextMenu();
            _mnuView = new MenuItem();
            _pnlHeader = new Panel();
            _lblTitle = new Label();
            _pnlControls = new Panel();
            _pnlTop = new Panel();
            _dgCalls = new DataGrid();
            _dgCalls.DoubleClick += new EventHandler(dgCalls_DoubleClick);
            _GroupBox1 = new GroupBox();
            _lblQualification = new Label();
            _cboQualification = new ComboBox();
            _cboQualification.SelectedIndexChanged += new EventHandler(cboQualification_SelectedIndexChanged);
            _chkWaitingParts = new CheckBox();
            _chkWaitingParts.CheckedChanged += new EventHandler(chkWaitingParts_CheckedChanged);
            _chkPNO = new CheckBox();
            _chkPNO.CheckedChanged += new EventHandler(chkPNO_CheckedChanged);
            _TextBox1 = new TextBox();
            _TextBox1.TextChanged += new EventHandler(TextBox1_TextChanged);
            _Label10 = new Label();
            _Label9 = new Label();
            _cboRegion = new ComboBox();
            _cboRegion.SelectedIndexChanged += new EventHandler(cboRegion_SelectedIndexChanged);
            _Label18 = new Label();
            _cboSiteFuel = new ComboBox();
            _cboSiteFuel.SelectedIndexChanged += new EventHandler(cboSiteFuel_SelectedIndexChanged);
            _chkDeclined = new CheckBox();
            _chkDeclined.CheckedChanged += new EventHandler(chkDeclined_CheckedChanged);
            _dtpTo = new DateTimePicker();
            _dtpTo.ValueChanged += new EventHandler(dtpTo_ValueChanged);
            _dtpFrom = new DateTimePicker();
            _dtpFrom.ValueChanged += new EventHandler(dtpFrom_ValueChanged);
            _Label17 = new Label();
            _Label16 = new Label();
            _chkEstimatedVisitDate = new CheckBox();
            _chkEstimatedVisitDate.CheckedChanged += new EventHandler(chkEstimatedVisitDate_CheckedChanged);
            _chkHasPartsToFit = new CheckBox();
            _chkHasPartsToFit.CheckedChanged += new EventHandler(chkHasPartsToFit_CheckedChanged);
            _cboType = new ComboBox();
            _cboType.SelectedIndexChanged += new EventHandler(cboType_SelectedIndexChanged);
            _Label15 = new Label();
            _txtSearchAddress1 = new TextBox();
            _txtSearchAddress1.TextChanged += new EventHandler(TextBox_Filter);
            _Label4 = new Label();
            _txtSearchPostcode = new TextBox();
            _txtSearchPostcode.TextChanged += new EventHandler(TextBox_Filter);
            _txtSearchCustomerName = new TextBox();
            _txtSearchCustomerName.TextChanged += new EventHandler(TextBox_Filter);
            _txtSearchJobNo = new TextBox();
            _txtSearchJobNo.TextChanged += new EventHandler(TextBox_Filter);
            _Label1 = new Label();
            _Label3 = new Label();
            _Label2 = new Label();
            _pnlLegend = new Panel();
            _Label20 = new Label();
            _Panel7 = new Panel();
            _Panel6 = new Panel();
            _Label19 = new Label();
            _Label14 = new Label();
            _Label13 = new Label();
            _Label12 = new Label();
            _picLevels = new PictureBox();
            _picPostalRegions = new PictureBox();
            _picRegion = new PictureBox();
            _lblOverdue = new Label();
            _Label7 = new Label();
            _Label8 = new Label();
            _Panel3 = new Panel();
            _Panel4 = new Panel();
            _Label6 = new Label();
            _Label5 = new Label();
            _Panel2 = new Panel();
            _Panel1 = new Panel();
            _chkViewAll = new CheckBox();
            _chkViewAll.Click += new EventHandler(chkViewAll_Click);
            _pnlHeader.SuspendLayout();
            _pnlControls.SuspendLayout();
            _pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCalls).BeginInit();
            _GroupBox1.SuspendLayout();
            _pnlLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_picLevels).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picPostalRegions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picRegion).BeginInit();
            SuspendLayout();
            //
            // splitForm
            //
            _splitForm.Dock = DockStyle.Right;
            _splitForm.Location = new Point(545, 0);
            _splitForm.Name = "splitForm";
            _splitForm.Size = new Size(3, 536);
            _splitForm.TabIndex = 1;
            _splitForm.TabStop = false;
            //
            // mnuVisitAction
            //
            _mnuVisitAction.MenuItems.AddRange(new MenuItem[] { _mnuView });
            //
            // mnuView
            //
            _mnuView.Index = 0;
            _mnuView.Text = "&View";
            //
            // pnlHeader
            //
            _pnlHeader.BackColor = Color.SteelBlue;
            _pnlHeader.Controls.Add(_lblTitle);
            _pnlHeader.Location = new Point(0, 0);
            _pnlHeader.Name = "pnlHeader";
            _pnlHeader.Size = new Size(205, 20);
            _pnlHeader.TabIndex = 6;
            //
            // lblTitle
            //
            _lblTitle.Dock = DockStyle.Fill;
            _lblTitle.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblTitle.ForeColor = Color.White;
            _lblTitle.Location = new Point(0, 0);
            _lblTitle.Name = "lblTitle";
            _lblTitle.Size = new Size(205, 20);
            _lblTitle.TabIndex = 0;
            _lblTitle.Text = "Unscheduled Calls";
            _lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlControls
            //
            _pnlControls.Controls.Add(_pnlTop);
            _pnlControls.Controls.Add(_pnlHeader);
            _pnlControls.Dock = DockStyle.Fill;
            _pnlControls.Location = new Point(0, 0);
            _pnlControls.Name = "pnlControls";
            _pnlControls.Size = new Size(545, 536);
            _pnlControls.TabIndex = 0;
            //
            // pnlTop
            //
            _pnlTop.Controls.Add(_dgCalls);
            _pnlTop.Controls.Add(_GroupBox1);
            _pnlTop.Controls.Add(_pnlLegend);
            _pnlTop.Dock = DockStyle.Fill;
            _pnlTop.Location = new Point(0, 0);
            _pnlTop.Name = "pnlTop";
            _pnlTop.Padding = new Padding(0, 0, 0, 5);
            _pnlTop.Size = new Size(545, 536);
            _pnlTop.TabIndex = 12;
            //
            // dgCalls
            //
            _dgCalls.AllowDrop = true;
            _dgCalls.CaptionText = "Holding Area";
            _dgCalls.ContextMenu = _mnuVisitAction;
            _dgCalls.DataMember = "";
            _dgCalls.Dock = DockStyle.Fill;
            _dgCalls.HeaderForeColor = SystemColors.ControlText;
            _dgCalls.Location = new Point(0, 0);
            _dgCalls.Name = "dgCalls";
            _dgCalls.Size = new Size(545, 175);
            _dgCalls.TabIndex = 1;
            //
            // GroupBox1
            //
            _GroupBox1.BackColor = Color.White;
            _GroupBox1.Controls.Add(_chkViewAll);
            _GroupBox1.Controls.Add(_lblQualification);
            _GroupBox1.Controls.Add(_cboQualification);
            _GroupBox1.Controls.Add(_chkWaitingParts);
            _GroupBox1.Controls.Add(_chkPNO);
            _GroupBox1.Controls.Add(_TextBox1);
            _GroupBox1.Controls.Add(_Label10);
            _GroupBox1.Controls.Add(_Label9);
            _GroupBox1.Controls.Add(_cboRegion);
            _GroupBox1.Controls.Add(_Label18);
            _GroupBox1.Controls.Add(_cboSiteFuel);
            _GroupBox1.Controls.Add(_chkDeclined);
            _GroupBox1.Controls.Add(_dtpTo);
            _GroupBox1.Controls.Add(_dtpFrom);
            _GroupBox1.Controls.Add(_Label17);
            _GroupBox1.Controls.Add(_Label16);
            _GroupBox1.Controls.Add(_chkEstimatedVisitDate);
            _GroupBox1.Controls.Add(_chkHasPartsToFit);
            _GroupBox1.Controls.Add(_cboType);
            _GroupBox1.Controls.Add(_Label15);
            _GroupBox1.Controls.Add(_txtSearchAddress1);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_txtSearchPostcode);
            _GroupBox1.Controls.Add(_txtSearchCustomerName);
            _GroupBox1.Controls.Add(_txtSearchJobNo);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Dock = DockStyle.Bottom;
            _GroupBox1.Location = new Point(0, 175);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(545, 229);
            _GroupBox1.TabIndex = 25;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Filters";
            //
            // lblQualification
            //
            _lblQualification.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblQualification.Location = new Point(216, 140);
            _lblQualification.Name = "lblQualification";
            _lblQualification.Size = new Size(81, 18);
            _lblQualification.TabIndex = 42;
            _lblQualification.Text = "Qualification";
            //
            // cboQualification
            //
            _cboQualification.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboQualification.FormattingEnabled = true;
            _cboQualification.Location = new Point(321, 137);
            _cboQualification.Name = "cboQualification";
            _cboQualification.Size = new Size(214, 21);
            _cboQualification.TabIndex = 41;
            //
            // chkWaitingParts
            //
            _chkWaitingParts.Location = new Point(280, 202);
            _chkWaitingParts.Name = "chkWaitingParts";
            _chkWaitingParts.RightToLeft = RightToLeft.No;
            _chkWaitingParts.Size = new Size(255, 21);
            _chkWaitingParts.TabIndex = 40;
            _chkWaitingParts.Text = "Include Waiting For Parts";
            _chkWaitingParts.UseVisualStyleBackColor = true;
            //
            // chkPNO
            //
            _chkPNO.Location = new Point(280, 180);
            _chkPNO.Name = "chkPNO";
            _chkPNO.RightToLeft = RightToLeft.No;
            _chkPNO.Size = new Size(255, 21);
            _chkPNO.TabIndex = 39;
            _chkPNO.Text = "Include Parts Need Ordering";
            _chkPNO.UseVisualStyleBackColor = true;
            //
            // TextBox1
            //
            _TextBox1.Location = new Point(321, 110);
            _TextBox1.Name = "TextBox1";
            _TextBox1.Size = new Size(214, 21);
            _TextBox1.TabIndex = 37;
            //
            // Label10
            //
            _Label10.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label10.Location = new Point(217, 114);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(80, 16);
            _Label10.TabIndex = 38;
            _Label10.Text = "Summary";
            //
            // Label9
            //
            _Label9.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label9.Location = new Point(216, 88);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(58, 16);
            _Label9.TabIndex = 36;
            _Label9.Text = "Region";
            //
            // cboRegion
            //
            _cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegion.FormattingEnabled = true;
            _cboRegion.Location = new Point(321, 85);
            _cboRegion.Name = "cboRegion";
            _cboRegion.Size = new Size(214, 21);
            _cboRegion.TabIndex = 35;
            //
            // Label18
            //
            _Label18.AutoSize = true;
            _Label18.Location = new Point(218, 63);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(56, 13);
            _Label18.TabIndex = 34;
            _Label18.Text = "Site Fuel";
            //
            // cboSiteFuel
            //
            _cboSiteFuel.FormattingEnabled = true;
            _cboSiteFuel.Location = new Point(321, 60);
            _cboSiteFuel.Name = "cboSiteFuel";
            _cboSiteFuel.Size = new Size(214, 21);
            _cboSiteFuel.TabIndex = 33;
            //
            // chkDeclined
            //
            _chkDeclined.Location = new Point(6, 201);
            _chkDeclined.Name = "chkDeclined";
            _chkDeclined.RightToLeft = RightToLeft.No;
            _chkDeclined.Size = new Size(249, 23);
            _chkDeclined.TabIndex = 31;
            _chkDeclined.Text = "Only Declined jobs - Red Highlight";
            _chkDeclined.UseVisualStyleBackColor = true;
            //
            // dtpTo
            //
            _dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dtpTo.CustomFormat = "dd/MM/yyyy";
            _dtpTo.Format = DateTimePickerFormat.Custom;
            _dtpTo.Location = new Point(399, 35);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(136, 21);
            _dtpTo.TabIndex = 30;
            //
            // dtpFrom
            //
            _dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dtpFrom.CustomFormat = "dd/MM/yyyy";
            _dtpFrom.Format = DateTimePickerFormat.Custom;
            _dtpFrom.Location = new Point(399, 11);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(136, 21);
            _dtpFrom.TabIndex = 29;
            //
            // Label17
            //
            _Label17.AutoSize = true;
            _Label17.Location = new Point(357, 38);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(20, 13);
            _Label17.TabIndex = 28;
            _Label17.Text = "To";
            //
            // Label16
            //
            _Label16.AutoSize = true;
            _Label16.Location = new Point(357, 14);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(36, 13);
            _Label16.TabIndex = 27;
            _Label16.Text = "From";
            //
            // chkEstimatedVisitDate
            //
            _chkEstimatedVisitDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _chkEstimatedVisitDate.Location = new Point(221, 16);
            _chkEstimatedVisitDate.Name = "chkEstimatedVisitDate";
            _chkEstimatedVisitDate.Size = new Size(119, 19);
            _chkEstimatedVisitDate.TabIndex = 26;
            _chkEstimatedVisitDate.Text = "Estimated Visit Date";
            _chkEstimatedVisitDate.UseVisualStyleBackColor = true;
            //
            // chkHasPartsToFit
            //
            _chkHasPartsToFit.Location = new Point(6, 180);
            _chkHasPartsToFit.Name = "chkHasPartsToFit";
            _chkHasPartsToFit.RightToLeft = RightToLeft.No;
            _chkHasPartsToFit.Size = new Size(268, 20);
            _chkHasPartsToFit.TabIndex = 6;
            _chkHasPartsToFit.Text = "Only parts to fit jobs - Orange Highlight";
            _chkHasPartsToFit.UseVisualStyleBackColor = true;
            //
            // cboType
            //
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.FormattingEnabled = true;
            _cboType.Location = new Point(111, 110);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(94, 21);
            _cboType.TabIndex = 5;
            //
            // Label15
            //
            _Label15.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label15.Location = new Point(7, 114);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(80, 16);
            _Label15.TabIndex = 25;
            _Label15.Text = "Job Type";
            //
            // txtSearchAddress1
            //
            _txtSearchAddress1.Location = new Point(111, 86);
            _txtSearchAddress1.Name = "txtSearchAddress1";
            _txtSearchAddress1.Size = new Size(94, 21);
            _txtSearchAddress1.TabIndex = 4;
            //
            // Label4
            //
            _Label4.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label4.Location = new Point(7, 90);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(80, 16);
            _Label4.TabIndex = 24;
            _Label4.Text = "Address 1";
            //
            // txtSearchPostcode
            //
            _txtSearchPostcode.Location = new Point(111, 62);
            _txtSearchPostcode.Name = "txtSearchPostcode";
            _txtSearchPostcode.Size = new Size(94, 21);
            _txtSearchPostcode.TabIndex = 3;
            //
            // txtSearchCustomerName
            //
            _txtSearchCustomerName.Location = new Point(111, 38);
            _txtSearchCustomerName.Name = "txtSearchCustomerName";
            _txtSearchCustomerName.Size = new Size(94, 21);
            _txtSearchCustomerName.TabIndex = 2;
            //
            // txtSearchJobNo
            //
            _txtSearchJobNo.Location = new Point(111, 15);
            _txtSearchJobNo.Name = "txtSearchJobNo";
            _txtSearchJobNo.Size = new Size(94, 21);
            _txtSearchJobNo.TabIndex = 1;
            //
            // Label1
            //
            _Label1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(7, 66);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(72, 21);
            _Label1.TabIndex = 22;
            _Label1.Text = "Postcode";
            //
            // Label3
            //
            _Label3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.Location = new Point(7, 17);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(64, 16);
            _Label3.TabIndex = 20;
            _Label3.Text = "Job No";
            //
            // Label2
            //
            _Label2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label2.Location = new Point(7, 40);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(104, 21);
            _Label2.TabIndex = 19;
            _Label2.Text = "Customer Name";
            //
            // pnlLegend
            //
            _pnlLegend.BackColor = Color.White;
            _pnlLegend.Controls.Add(_Label20);
            _pnlLegend.Controls.Add(_Panel7);
            _pnlLegend.Controls.Add(_Panel6);
            _pnlLegend.Controls.Add(_Label19);
            _pnlLegend.Controls.Add(_Label14);
            _pnlLegend.Controls.Add(_Label13);
            _pnlLegend.Controls.Add(_Label12);
            _pnlLegend.Controls.Add(_picLevels);
            _pnlLegend.Controls.Add(_picPostalRegions);
            _pnlLegend.Controls.Add(_picRegion);
            _pnlLegend.Controls.Add(_lblOverdue);
            _pnlLegend.Controls.Add(_Label7);
            _pnlLegend.Controls.Add(_Label8);
            _pnlLegend.Controls.Add(_Panel3);
            _pnlLegend.Controls.Add(_Panel4);
            _pnlLegend.Controls.Add(_Label6);
            _pnlLegend.Controls.Add(_Label5);
            _pnlLegend.Controls.Add(_Panel2);
            _pnlLegend.Controls.Add(_Panel1);
            _pnlLegend.Dock = DockStyle.Bottom;
            _pnlLegend.Location = new Point(0, 404);
            _pnlLegend.Name = "pnlLegend";
            _pnlLegend.Size = new Size(545, 127);
            _pnlLegend.TabIndex = 24;
            //
            // Label20
            //
            _Label20.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label20.Font = new Font("Verdana", 8.0F);
            _Label20.Location = new Point(328, 103);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(192, 16);
            _Label20.TabIndex = 23;
            _Label20.Text = "Service overdue on site";
            //
            // Panel7
            //
            _Panel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel7.BackColor = Color.Orange;
            _Panel7.Location = new Point(304, 101);
            _Panel7.Name = "Panel7";
            _Panel7.Size = new Size(16, 16);
            _Panel7.TabIndex = 22;
            //
            // Panel6
            //
            _Panel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel6.BackColor = Color.Red;
            _Panel6.Location = new Point(8, 101);
            _Panel6.Name = "Panel6";
            _Panel6.Size = new Size(16, 16);
            _Panel6.TabIndex = 21;
            //
            // Label19
            //
            _Label19.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label19.Font = new Font("Verdana", 8.0F);
            _Label19.Location = new Point(32, 101);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(192, 16);
            _Label19.TabIndex = 22;
            _Label19.Text = "Visit is extremely late";
            //
            // Label14
            //
            _Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label14.Font = new Font("Verdana", 8.0F);
            _Label14.Location = new Point(328, 85);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(192, 16);
            _Label14.TabIndex = 18;
            _Label14.Text = "Qualification check passed";
            //
            // Label13
            //
            _Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label13.Font = new Font("Verdana", 8.0F);
            _Label13.Location = new Point(328, 69);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(216, 16);
            _Label13.TabIndex = 17;
            _Label13.Text = "Postal region check passed";
            //
            // Label12
            //
            _Label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label12.Font = new Font("Verdana", 8.0F);
            _Label12.Location = new Point(328, 53);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(192, 16);
            _Label12.TabIndex = 16;
            _Label12.Text = "Region check passed";
            //
            // picLevels
            //
            _picLevels.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _picLevels.BackColor = Color.Transparent;
            _picLevels.Image = (Image)resources.GetObject("picLevels.Image");
            _picLevels.Location = new Point(304, 85);
            _picLevels.Name = "picLevels";
            _picLevels.Size = new Size(16, 16);
            _picLevels.SizeMode = PictureBoxSizeMode.StretchImage;
            _picLevels.TabIndex = 14;
            _picLevels.TabStop = false;
            //
            // picPostalRegions
            //
            _picPostalRegions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _picPostalRegions.BackColor = Color.Transparent;
            _picPostalRegions.Image = (Image)resources.GetObject("picPostalRegions.Image");
            _picPostalRegions.Location = new Point(304, 69);
            _picPostalRegions.Name = "picPostalRegions";
            _picPostalRegions.Size = new Size(16, 16);
            _picPostalRegions.SizeMode = PictureBoxSizeMode.StretchImage;
            _picPostalRegions.TabIndex = 13;
            _picPostalRegions.TabStop = false;
            //
            // picRegion
            //
            _picRegion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _picRegion.BackColor = Color.Transparent;
            _picRegion.Image = (Image)resources.GetObject("picRegion.Image");
            _picRegion.Location = new Point(304, 53);
            _picRegion.Name = "picRegion";
            _picRegion.Size = new Size(16, 16);
            _picRegion.SizeMode = PictureBoxSizeMode.StretchImage;
            _picRegion.TabIndex = 12;
            _picRegion.TabStop = false;
            //
            // lblOverdue
            //
            _lblOverdue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblOverdue.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblOverdue.ForeColor = Color.Black;
            _lblOverdue.Location = new Point(0, 3);
            _lblOverdue.Name = "lblOverdue";
            _lblOverdue.Size = new Size(545, 32);
            _lblOverdue.TabIndex = 11;
            _lblOverdue.Text = "There are no contract jobs overdue.";
            _lblOverdue.TextAlign = ContentAlignment.MiddleCenter;
            //
            // Label7
            //
            _Label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label7.Font = new Font("Verdana", 8.0F);
            _Label7.Location = new Point(32, 85);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(192, 16);
            _Label7.TabIndex = 7;
            _Label7.Text = "Booked Schedule Period";
            //
            // Label8
            //
            _Label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label8.Font = new Font("Verdana", 8.0F);
            _Label8.Location = new Point(32, 69);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(192, 16);
            _Label8.TabIndex = 6;
            _Label8.Text = "Free Schedule Period";
            //
            // Panel3
            //
            _Panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel3.BackColor = Color.LightSteelBlue;
            _Panel3.Location = new Point(8, 85);
            _Panel3.Name = "Panel3";
            _Panel3.Size = new Size(16, 16);
            _Panel3.TabIndex = 5;
            //
            // Panel4
            //
            _Panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel4.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            _Panel4.Location = new Point(8, 69);
            _Panel4.Name = "Panel4";
            _Panel4.Size = new Size(16, 16);
            _Panel4.TabIndex = 4;
            //
            // Label6
            //
            _Label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label6.Font = new Font("Verdana", 8.0F);
            _Label6.Location = new Point(32, 53);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(192, 16);
            _Label6.TabIndex = 3;
            _Label6.Text = "Some job tests failed";
            //
            // Label5
            //
            _Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label5.Font = new Font("Verdana", 8.0F);
            _Label5.Location = new Point(32, 37);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(192, 16);
            _Label5.TabIndex = 2;
            _Label5.Text = "All job tests passed";
            //
            // Panel2
            //
            _Panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel2.BackColor = Color.Coral;
            _Panel2.Location = new Point(8, 53);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(16, 16);
            _Panel2.TabIndex = 1;
            //
            // Panel1
            //
            _Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel1.BackColor = Color.LightGreen;
            _Panel1.Location = new Point(8, 37);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(16, 16);
            _Panel1.TabIndex = 0;
            //
            // chkViewAll
            //
            _chkViewAll.AutoCheck = false;
            _chkViewAll.Location = new Point(10, 140);
            _chkViewAll.Name = "chkViewAll";
            _chkViewAll.RightToLeft = RightToLeft.No;
            _chkViewAll.Size = new Size(195, 20);
            _chkViewAll.TabIndex = 43;
            _chkViewAll.Text = "View All Visits";
            _chkViewAll.UseVisualStyleBackColor = true;
            //
            // pnlUnscheduledCalls
            //
            BackColor = Color.WhiteSmoke;
            Controls.Add(_pnlControls);
            Controls.Add(_splitForm);
            Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Name = "pnlUnscheduledCalls";
            Size = new Size(548, 536);
            _pnlHeader.ResumeLayout(false);
            _pnlControls.ResumeLayout(false);
            _pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgCalls).EndInit();
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            _pnlLegend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_picLevels).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picPostalRegions).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picRegion).EndInit();
            ResumeLayout(false);
        }

        public class createdTypeColour : DataGridLabelColumn
        {
            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                var brush = default(Brush);
                string str = Conversions.ToString(((DataRow)source.List[rowNum])["createdType"]);
                switch (str)
                {
                    case "manual":
                        {
                            brush = new SolidBrush(Color.LightBlue);
                            break;
                        }

                    case "recent":
                        {
                            brush = new SolidBrush(Color.LightGreen);
                            break;
                        }

                    case "generated":
                        {
                            brush = new SolidBrush(Color.LightYellow);
                            break;
                        }
                }

                var rect = bounds;
                g.FillRectangle(brush, rect);
            }
        }

        private DataView _dvunsched;

        public DataView CallsDataview
        {
            get
            {
                return _dvunsched;
            }

            set
            {
                _dvunsched = value;
            }
        }

        private DataTable _dtUnscheduledCalls;

        public DataTable unscheduledCalls
        {
            get
            {
                return _dtUnscheduledCalls;
            }

            set
            {
                _dtUnscheduledCalls = value;
                CallsDataview = new DataView(_dtUnscheduledCalls);
                dgCalls.DataSource = CallsDataview;
                setOverdueLabel();
            }
        }

        private DataRow SelectedDataRow
        {
            get
            {
                if (!(dgCalls.CurrentRowIndex == -1))
                {
                    return CallsDataview[dgCalls.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public Size MinimumSize
        {
            get
            {
                return new Size(208, 536);
            }
        }

        private int TEXTSIZE = 7;

        public void setOverdueLabel()
        {
            try
            {
                var dvFiltered = new DataView(_dtUnscheduledCalls);
                dvFiltered.RowFilter = string.Format("EstimatedVisitDate <= '{0}'", Strings.Format(DateAndTime.Now, "yyyy/MM/dd"));
                short overdueCount = Conversions.ToShort(dvFiltered.Count);
                if (overdueCount > 1)
                {
                    lblOverdue.Text = string.Format("There are {0} contract jobs overdue.", overdueCount);
                    lblOverdue.ForeColor = Color.Red;
                }
                else if (overdueCount == 1)
                {
                    lblOverdue.Text = string.Format("There is 1 contract job overdue.", overdueCount);
                    lblOverdue.ForeColor = Color.Red;
                }
                else if (overdueCount == 0)
                {
                    lblOverdue.Text = "There are no contract job overdue.";
                    lblOverdue.ForeColor = Color.Black;
                }
            }
            catch
            {
                lblOverdue.Text = "There are no contract job overdue.";
                lblOverdue.ForeColor = Color.Black;
            }
        }

        private bool isLoading = false;

        private void pnlUnscheduledCalls_Load(object sender, EventArgs e)
        {
            SetUpCallsDataGrid();
            isLoading = true;
            var argc = cboType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            var argc1 = cboSiteFuel;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.GasTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            if (App.loggedInUser.UserRegions.Count > 0)
            {
                var argc2 = cboRegion;
                Combo.SetUpCombo(ref argc2, App.loggedInUser.UserRegions.Table, "RegionID", "Name", Enums.ComboValues.No_Filter);
            }
            else
            {
                var argc3 = cboRegion;
                Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            }

            chkHasPartsToFit.Checked = false;
            chkEstimatedVisitDate.Checked = true;
            chkPNO.Checked = true;
            dtpTo.Value = DateAndTime.Now.AddDays(14);
            dtpFrom.Value = DateAndTime.Now.AddYears(-2);
            var argc4 = cboQualification;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            switch (true)
            {
                case object _ when App.IsRFT:
                    {
                        lblQualification.Text = "Trade";
                        break;
                    }

                default:
                    {
                        lblQualification.Text = "Qualification";
                        lblQualification.Visible = false;
                        cboQualification.Visible = false;
                        break;
                    }
            }

            isLoading = false;
        }

        private void SetUpCallsDataGrid()
        {
            double diff = 1;
            var switchExpr = TEXTSIZE;
            switch (switchExpr)
            {
                case 8:
                    {
                        diff = 1.1;
                        break;
                    }

                case 9:
                    {
                        diff = 1.15;
                        break;
                    }

                case 10:
                    {
                        diff = 1.2;
                        break;
                    }

                case 11:
                    {
                        diff = 1.25;
                        break;
                    }

                case 12:
                    {
                        diff = 1.3;
                        break;
                    }
            }

            ModScheduler.SetUpSchedulerDataGrid(dgCalls, true);
            var tStyle = dgCalls.TableStyles[0];
            tStyle.DataGrid.Font = new Font("Verdana", TEXTSIZE, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            tStyle.DataGrid.HeaderFont = new Font("Verdana", TEXTSIZE, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            var PartsToFit = new ColourColumn();
            PartsToFit.Format = "";
            PartsToFit.FormatInfo = null;
            PartsToFit.HeaderText = "";
            PartsToFit.MappingName = "PartsToFit";
            PartsToFit.ReadOnly = true;
            PartsToFit.Width = Conversions.ToInteger(10 * diff);
            PartsToFit.NullText = "";
            tStyle.GridColumnStyles.Add(PartsToFit);
            var JobID = new UnscheduledCallsColumn();
            JobID.Format = "";
            JobID.FormatInfo = null;
            JobID.HeaderText = "Job No";
            JobID.MappingName = "JobNumber";
            JobID.ReadOnly = true;
            JobID.Width = Conversions.ToInteger(55 * diff);
            JobID.NullText = "";
            tStyle.GridColumnStyles.Add(JobID);
            var Site = new UnscheduledCallsColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Address";
            Site.MappingName = "Address1";
            Site.ReadOnly = true;
            Site.Width = Conversions.ToInteger(95 * diff);
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var PostCode = new UnscheduledCallsColumn();
            PostCode.Format = "";
            PostCode.FormatInfo = null;
            PostCode.HeaderText = "Postcode";
            PostCode.MappingName = "PostCode";
            PostCode.ReadOnly = true;
            PostCode.Width = Conversions.ToInteger(65 * diff);
            PostCode.NullText = "";
            tStyle.GridColumnStyles.Add(PostCode);
            var Items = new UnscheduledCallsColumn();
            Items.Format = "";
            Items.FormatInfo = null;
            Items.HeaderText = "Job Summary";
            Items.MappingName = "JobItems";
            Items.ReadOnly = true;
            Items.Width = Conversions.ToInteger(100 * diff);
            Items.NullText = "";
            tStyle.GridColumnStyles.Add(Items);
            var SiteFuel = new UnscheduledCallsColumn();
            SiteFuel.Format = "";
            SiteFuel.FormatInfo = null;
            SiteFuel.HeaderText = "Fuel";
            SiteFuel.MappingName = "SiteFuel";
            SiteFuel.ReadOnly = true;
            SiteFuel.Width = Conversions.ToInteger(30 * diff);
            SiteFuel.NullText = "";
            tStyle.GridColumnStyles.Add(SiteFuel);
            var Notes = new UnscheduledCallsColumn();
            Notes.Format = "";
            Notes.FormatInfo = null;
            Notes.HeaderText = "Notes";
            Notes.MappingName = "NotesToEngineer";
            Notes.ReadOnly = true;
            Notes.Width = Conversions.ToInteger(200 * diff);
            Notes.NullText = "";
            tStyle.GridColumnStyles.Add(Notes);
            var qualification = new UnscheduledCallsColumn();
            qualification.Format = "";
            qualification.FormatInfo = null;
            switch (true)
            {
                case object _ when App.IsRFT:
                    {
                        qualification.HeaderText = "Trade";
                        break;
                    }

                default:
                    {
                        qualification.HeaderText = "Qualification";
                        break;
                    }
            }

            qualification.MappingName = "Qualification";
            qualification.ReadOnly = true;
            qualification.Width = Conversions.ToInteger(75 * diff);
            qualification.NullText = "";
            tStyle.GridColumnStyles.Add(qualification);
            var DueDate = new UnscheduledCallsColumn();
            DueDate.Format = "";
            DueDate.FormatInfo = null;
            DueDate.HeaderText = "Due Date";
            DueDate.MappingName = "DueDate";
            DueDate.ReadOnly = true;
            DueDate.Width = Conversions.ToInteger(75 * diff);
            DueDate.NullText = "";
            tStyle.GridColumnStyles.Add(DueDate);
            var AMPM = new UnscheduledCallsColumn();
            AMPM.Format = "";
            AMPM.FormatInfo = null;
            AMPM.HeaderText = "";
            AMPM.MappingName = "AMPM";
            AMPM.ReadOnly = true;
            AMPM.Width = Conversions.ToInteger(25 * diff);
            AMPM.NullText = "";
            tStyle.GridColumnStyles.Add(AMPM);
            var CustomerName = new UnscheduledCallsColumn();
            CustomerName.Format = "";
            CustomerName.FormatInfo = null;
            CustomerName.HeaderText = "Customer";
            CustomerName.MappingName = "customername";
            CustomerName.ReadOnly = true;
            CustomerName.Width = Conversions.ToInteger(100 * diff);
            CustomerName.NullText = "";
            tStyle.GridColumnStyles.Add(CustomerName);
            var JobType = new DataGridJobTypeColumn();
            JobType.Format = "";
            JobType.FormatInfo = null;
            JobType.HeaderText = "Type";
            JobType.MappingName = "Type";
            JobType.ReadOnly = true;
            JobType.Width = Conversions.ToInteger(75 * diff);
            JobType.NullText = "";
            tStyle.GridColumnStyles.Add(JobType);
            var SummedSOR = new UnscheduledCallsColumn();
            SummedSOR.Format = "";
            SummedSOR.FormatInfo = null;
            SummedSOR.HeaderText = "SOR Time";
            SummedSOR.MappingName = "SummedSOR";
            SummedSOR.ReadOnly = true;
            SummedSOR.Width = Conversions.ToInteger(50 * diff);
            SummedSOR.NullText = "";
            tStyle.GridColumnStyles.Add(SummedSOR);
            var EstimatedVisitDate = new UnscheduledCallsColumn();
            EstimatedVisitDate.Format = "dd/MM/yyyy";
            EstimatedVisitDate.FormatInfo = null;
            EstimatedVisitDate.HeaderText = "Est Date";
            EstimatedVisitDate.MappingName = "EstimatedVisitDate";
            EstimatedVisitDate.ReadOnly = true;
            EstimatedVisitDate.Width = Conversions.ToInteger(75 * diff);
            EstimatedVisitDate.NullText = "N/A";
            tStyle.GridColumnStyles.Add(EstimatedVisitDate);
            tStyle.ReadOnly = true;
            tStyle.MappingName = "UnscheduledWork";
            dgCalls.TableStyles.Add(tStyle);
        }

        public void clearSelections()
        {
            try
            {
                for (int rowCount = 0, loopTo = ((DataView)dgCalls.DataSource).Count - 1; rowCount <= loopTo; rowCount++)
                    dgCalls.UnSelect(rowCount);
            }
            catch
            {
            }
        }

        private void TextBox_Filter(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkHasPartsToFit_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        public void ApplyFilters()
        {
            if (isLoading)
            {
                return;
            }

            string FilterString;
            FilterString = "postcode like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(txtSearchPostcode.Text)) + "%' AND ";
            FilterString += "Address1 like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(txtSearchAddress1.Text)) + "%' AND ";
            FilterString += "JobNumber like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(txtSearchJobNo.Text)) + "%' AND ";
            FilterString += "customername like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(txtSearchCustomerName.Text)) + "%' AND ";
            FilterString += "JobItems like '%" + Helper.RemoveSpecialCharacters(Strings.Trim(TextBox1.Text)) + "%' ";
            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboType)) == 0))
            {
                FilterString += "AND JobTypeID = " + Combo.get_GetSelectedItemValue(cboType) + " ";
            }

            if (chkHasPartsToFit.Checked)
            {
                FilterString += "AND PartsToFit <> 0 ";
            }

            if (chkDeclined.Checked)
            {
                FilterString += "AND FollowUpDeclined <> 0 ";
            }

            if (chkPNO.Checked == false)
            {
                FilterString += "AND PartsNeedOrdering = 0 ";
            }

            if (chkWaitingParts.Checked == false)
            {
                FilterString += "AND WaitingForParts = 0 ";
            }

            if (chkHasPartsToFit.Checked == false)
            {
                if (chkEstimatedVisitDate.Checked)
                {
                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = true;
                    FilterString += " AND ((EstimatedVisitDate >= '" + Strings.Format(dtpFrom.Value.Date, "dd-MMM-yyyy 00:00:00") + "' AND EstimatedVisitDate <= '" + Strings.Format(dtpTo.Value.Date, "dd-MMM-yyyy 23:59:59") + "') OR (EstimatedVisitDate IS NULL))";
                }
                else
                {
                    dtpFrom.Enabled = false;
                    dtpTo.Enabled = false;
                    dtpFrom.Value = DateAndTime.Now;
                    dtpTo.Value = DateAndTime.Now;
                }
            }

            if (!((Combo.get_GetSelectedItemValue(cboSiteFuel) ?? "") == "0"))
            {
                FilterString += " AND FuelID = '" + Combo.get_GetSelectedItemValue(cboSiteFuel) + "' ";
            }

            if (!((Combo.get_GetSelectedItemValue(cboRegion) ?? "") == "0"))
            {
                FilterString += " AND RegionID = " + Combo.get_GetSelectedItemValue(cboRegion) + " ";
            }

            if (!((Combo.get_GetSelectedItemValue(cboQualification) ?? "") == "0"))
            {
                FilterString += " AND QualificationID = " + Combo.get_GetSelectedItemValue(cboQualification) + " ";
            }

            if (CallsDataview is object)
            {
                CallsDataview.RowFilter = FilterString;
            }
        }

        private void pnlUnscheduledCalls_Resize(object sender, EventArgs e)
        {
            bool skip = false;
            if (Height < MinimumSize.Height)
            {
                Height = MinimumSize.Height;
            }

            if (Width < MinimumSize.Width)
            {
                Width = MinimumSize.Width;
            }

            pnlTop.Height = Conversions.ToInteger(Height * 0.7);
        }

        private int mousePosDownX = -1;

        private void splitForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousePosDownX = e.X;
        }

        private void splitForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!(mousePosDownX == -1))
            {
                Width += e.X - mousePosDownX;
            }
        }

        private void splitForm_MouseUp(object sender, MouseEventArgs e)
        {
            mousePosDownX = -1;
        }

        private void dgCalls_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select a visit to open the job", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedDataRow["JobID"], SelectedDataRow["SiteID"], this, null, SelectedDataRow["EngineerVisitID"] });
            }
            catch
            {
            }
        }

        private void chkEstimatedVisitDate_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkDeclined_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboSiteFuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkPNO_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkWaitingParts_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void chkViewAll_Click(object sender, EventArgs e)
        {
            chkViewAll.Checked = !chkViewAll.Checked;
        }
    }
}