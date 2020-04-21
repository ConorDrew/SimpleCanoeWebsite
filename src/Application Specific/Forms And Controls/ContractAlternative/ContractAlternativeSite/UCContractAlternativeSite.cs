using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCContractAlternativeSite : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCContractAlternativeSite() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCContractSite_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            SetupAssetsDataGrid();
            SetupJobItemsDataGrid();
            var argc = cboVisitFrequencyID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.VisitFrequency, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboVisitDuration;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.VisitDuration, "VisitDuration", "DisplayMember");
            cboVisitDuration.SelectedIndex = 0;
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

        private GroupBox _grpContractSite;

        internal GroupBox grpContractSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContractSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContractSite != null)
                {
                }

                _grpContractSite = value;
                if (_grpContractSite != null)
                {
                }
            }
        }

        private TextBox _txtSite;

        internal TextBox txtSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSite != null)
                {
                }

                _txtSite = value;
                if (_txtSite != null)
                {
                }
            }
        }

        private Label _lblSite;

        internal Label lblSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSite != null)
                {
                }

                _lblSite = value;
                if (_lblSite != null)
                {
                }
            }
        }

        private DataGrid _dgAssets;

        internal DataGrid dgAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAssets != null)
                {
                    _dgAssets.MouseUp -= dgAssets_MouseUp;
                }

                _dgAssets = value;
                if (_dgAssets != null)
                {
                    _dgAssets.MouseUp += dgAssets_MouseUp;
                }
            }
        }

        private GroupBox _grpVisits;

        internal GroupBox grpVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVisits != null)
                {
                }

                _grpVisits = value;
                if (_grpVisits != null)
                {
                }
            }
        }

        private GroupBox _grpJobItems;

        internal GroupBox grpJobItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobItems != null)
                {
                }

                _grpJobItems = value;
                if (_grpJobItems != null)
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

        private ComboBox _cboVisitDuration;

        internal ComboBox cboVisitDuration
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVisitDuration;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVisitDuration != null)
                {
                }

                _cboVisitDuration = value;
                if (_cboVisitDuration != null)
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

        private ComboBox _cboVisitFrequencyID;

        internal ComboBox cboVisitFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVisitFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVisitFrequencyID != null)
                {
                }

                _cboVisitFrequencyID = value;
                if (_cboVisitFrequencyID != null)
                {
                }
            }
        }

        private Label _lblVisitFrequencyID;

        internal Label lblVisitFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitFrequencyID != null)
                {
                }

                _lblVisitFrequencyID = value;
                if (_lblVisitFrequencyID != null)
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

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private Button _btnRemove;

        internal Button btnRemove
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemove;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemove != null)
                {
                    _btnRemove.Click -= btnRemove_Click;
                }

                _btnRemove = value;
                if (_btnRemove != null)
                {
                    _btnRemove.Click += btnRemove_Click;
                }
            }
        }

        private DataGrid _dgJobItems;

        internal DataGrid dgJobItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgJobItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgJobItems != null)
                {
                    _dgJobItems.MouseUp -= dgJobItems_MouseUp;
                }

                _dgJobItems = value;
                if (_dgJobItems != null)
                {
                    _dgJobItems.MouseUp += dgJobItems_MouseUp;
                }
            }
        }

        private Button _btnAddToJobOfWork;

        internal Button btnAddToJobOfWork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddToJobOfWork;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddToJobOfWork != null)
                {
                    _btnAddToJobOfWork.Click -= btnAddToJobOfWork_Click;
                }

                _btnAddToJobOfWork = value;
                if (_btnAddToJobOfWork != null)
                {
                    _btnAddToJobOfWork.Click += btnAddToJobOfWork_Click;
                }
            }
        }

        private TabControl _TCJobsOfWork;

        internal TabControl TCJobsOfWork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TCJobsOfWork;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TCJobsOfWork != null)
                {
                }

                _TCJobsOfWork = value;
                if (_TCJobsOfWork != null)
                {
                }
            }
        }

        private Button _btnRemoveJobOfWork;

        internal Button btnRemoveJobOfWork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveJobOfWork;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveJobOfWork != null)
                {
                    _btnRemoveJobOfWork.Click -= btnRemoveJobOfWork_Click;
                }

                _btnRemoveJobOfWork = value;
                if (_btnRemoveJobOfWork != null)
                {
                    _btnRemoveJobOfWork.Click += btnRemoveJobOfWork_Click;
                }
            }
        }

        private Button _btnAddJobOfWork;

        internal Button btnAddJobOfWork
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddJobOfWork;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddJobOfWork != null)
                {
                    _btnAddJobOfWork.Click -= btnAddJobOfWork_Click;
                }

                _btnAddJobOfWork = value;
                if (_btnAddJobOfWork != null)
                {
                    _btnAddJobOfWork.Click += btnAddJobOfWork_Click;
                }
            }
        }

        private TextBox _txtDescriptionItem;

        internal TextBox txtDescriptionItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDescriptionItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDescriptionItem != null)
                {
                }

                _txtDescriptionItem = value;
                if (_txtDescriptionItem != null)
                {
                }
            }
        }

        private GroupBox _gpJobItems;

        internal GroupBox gpJobItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpJobItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpJobItems != null)
                {
                }

                _gpJobItems = value;
                if (_gpJobItems != null)
                {
                }
            }
        }

        private GroupBox _grpJobItemAdd;

        internal GroupBox grpJobItemAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobItemAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobItemAdd != null)
                {
                }

                _grpJobItemAdd = value;
                if (_grpJobItemAdd != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpContractSite = new GroupBox();
            _gpJobItems = new GroupBox();
            _dgJobItems = new DataGrid();
            _dgJobItems.MouseUp += new MouseEventHandler(dgJobItems_MouseUp);
            _btnAddToJobOfWork = new Button();
            _btnAddToJobOfWork.Click += new EventHandler(btnAddToJobOfWork_Click);
            _btnRemove = new Button();
            _btnRemove.Click += new EventHandler(btnRemove_Click);
            _txtSite = new TextBox();
            _lblSite = new Label();
            _grpVisits = new GroupBox();
            _btnRemoveJobOfWork = new Button();
            _btnRemoveJobOfWork.Click += new EventHandler(btnRemoveJobOfWork_Click);
            _btnAddJobOfWork = new Button();
            _btnAddJobOfWork.Click += new EventHandler(btnAddJobOfWork_Click);
            _TCJobsOfWork = new TabControl();
            _grpJobItemAdd = new GroupBox();
            _cboVisitDuration = new ComboBox();
            _cboVisitFrequencyID = new ComboBox();
            _lblPricePerVisit = new Label();
            _Label2 = new Label();
            _txtDescriptionItem = new TextBox();
            _lblVisitFrequencyID = new Label();
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _txtPricePerVisit = new TextBox();
            _txtPricePerVisit.LostFocus += new EventHandler(txtPricePerVisit_LostFocus);
            _Label1 = new Label();
            _dgAssets = new DataGrid();
            _dgAssets.MouseUp += new MouseEventHandler(dgAssets_MouseUp);
            _grpJobItems = new GroupBox();
            _grpContractSite.SuspendLayout();
            _gpJobItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobItems).BeginInit();
            _grpVisits.SuspendLayout();
            _grpJobItemAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssets).BeginInit();
            SuspendLayout();
            // 
            // grpContractSite
            // 
            _grpContractSite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContractSite.Controls.Add(_gpJobItems);
            _grpContractSite.Controls.Add(_txtSite);
            _grpContractSite.Controls.Add(_lblSite);
            _grpContractSite.Controls.Add(_grpVisits);
            _grpContractSite.Controls.Add(_grpJobItemAdd);
            _grpContractSite.Location = new Point(7, 3);
            _grpContractSite.Name = "grpContractSite";
            _grpContractSite.Size = new Size(971, 664);
            _grpContractSite.TabIndex = 1;
            _grpContractSite.TabStop = false;
            _grpContractSite.Text = "Main Details";
            // 
            // gpJobItems
            // 
            _gpJobItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpJobItems.Controls.Add(_dgJobItems);
            _gpJobItems.Controls.Add(_btnAddToJobOfWork);
            _gpJobItems.Controls.Add(_btnRemove);
            _gpJobItems.Location = new Point(10, 146);
            _gpJobItems.Name = "gpJobItems";
            _gpJobItems.Size = new Size(949, 107);
            _gpJobItems.TabIndex = 3;
            _gpJobItems.TabStop = false;
            _gpJobItems.Text = "Job Items ";
            // 
            // dgJobItems
            // 
            _dgJobItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _dgJobItems.DataMember = "";
            _dgJobItems.HeaderForeColor = SystemColors.ControlText;
            _dgJobItems.Location = new Point(8, 17);
            _dgJobItems.Name = "dgJobItems";
            _dgJobItems.Size = new Size(809, 85);
            _dgJobItems.TabIndex = 1;
            // 
            // btnAddToJobOfWork
            // 
            _btnAddToJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddToJobOfWork.UseVisualStyleBackColor = true;
            _btnAddToJobOfWork.Location = new Point(820, 77);
            _btnAddToJobOfWork.Name = "btnAddToJobOfWork";
            _btnAddToJobOfWork.Size = new Size(124, 23);
            _btnAddToJobOfWork.TabIndex = 2;
            _btnAddToJobOfWork.Text = "Add To Job Of Work";
            // 
            // btnRemove
            // 
            _btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnRemove.UseVisualStyleBackColor = true;
            _btnRemove.Location = new Point(820, 17);
            _btnRemove.Name = "btnRemove";
            _btnRemove.Size = new Size(124, 23);
            _btnRemove.TabIndex = 0;
            _btnRemove.Text = "Remove";
            // 
            // txtSite
            // 
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Location = new Point(70, 18);
            _txtSite.Multiline = true;
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.ScrollBars = ScrollBars.Vertical;
            _txtSite.Size = new Size(887, 21);
            _txtSite.TabIndex = 0;
            _txtSite.Text = "";
            // 
            // lblSite
            // 
            _lblSite.Location = new Point(15, 21);
            _lblSite.Name = "lblSite";
            _lblSite.Size = new Size(52, 19);
            _lblSite.TabIndex = 33;
            _lblSite.Text = "Property";
            // 
            // grpVisits
            // 
            _grpVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVisits.Controls.Add(_btnRemoveJobOfWork);
            _grpVisits.Controls.Add(_btnAddJobOfWork);
            _grpVisits.Controls.Add(_TCJobsOfWork);
            _grpVisits.Location = new Point(10, 254);
            _grpVisits.Name = "grpVisits";
            _grpVisits.Size = new Size(949, 403);
            _grpVisits.TabIndex = 4;
            _grpVisits.TabStop = false;
            _grpVisits.Text = "Jobs Of Work";
            // 
            // btnRemoveJobOfWork
            // 
            _btnRemoveJobOfWork.AccessibleDescription = "Remove Selected Job Of Work";
            _btnRemoveJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnRemoveJobOfWork.UseVisualStyleBackColor = true;
            _btnRemoveJobOfWork.Location = new Point(914, 16);
            _btnRemoveJobOfWork.Name = "btnRemoveJobOfWork";
            _btnRemoveJobOfWork.Size = new Size(24, 23);
            _btnRemoveJobOfWork.TabIndex = 2;
            _btnRemoveJobOfWork.Text = "-";
            // 
            // btnAddJobOfWork
            // 
            _btnAddJobOfWork.AccessibleDescription = "Add Job Of Work";
            _btnAddJobOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddJobOfWork.UseVisualStyleBackColor = true;
            _btnAddJobOfWork.Location = new Point(882, 16);
            _btnAddJobOfWork.Name = "btnAddJobOfWork";
            _btnAddJobOfWork.Size = new Size(24, 23);
            _btnAddJobOfWork.TabIndex = 1;
            _btnAddJobOfWork.Text = "+";
            // 
            // TCJobsOfWork
            // 
            _TCJobsOfWork.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TCJobsOfWork.Location = new Point(8, 17);
            _TCJobsOfWork.Name = "TCJobsOfWork";
            _TCJobsOfWork.SelectedIndex = 0;
            _TCJobsOfWork.Size = new Size(933, 381);
            _TCJobsOfWork.TabIndex = 0;
            // 
            // grpJobItemAdd
            // 
            _grpJobItemAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpJobItemAdd.Controls.Add(_cboVisitDuration);
            _grpJobItemAdd.Controls.Add(_cboVisitFrequencyID);
            _grpJobItemAdd.Controls.Add(_lblPricePerVisit);
            _grpJobItemAdd.Controls.Add(_Label2);
            _grpJobItemAdd.Controls.Add(_txtDescriptionItem);
            _grpJobItemAdd.Controls.Add(_lblVisitFrequencyID);
            _grpJobItemAdd.Controls.Add(_btnAdd);
            _grpJobItemAdd.Controls.Add(_txtPricePerVisit);
            _grpJobItemAdd.Controls.Add(_Label1);
            _grpJobItemAdd.Controls.Add(_dgAssets);
            _grpJobItemAdd.Location = new Point(10, 41);
            _grpJobItemAdd.Name = "grpJobItemAdd";
            _grpJobItemAdd.Size = new Size(949, 106);
            _grpJobItemAdd.TabIndex = 2;
            _grpJobItemAdd.TabStop = false;
            _grpJobItemAdd.Text = "Add Job Items";
            // 
            // cboVisitDuration
            // 
            _cboVisitDuration.Cursor = Cursors.Hand;
            _cboVisitDuration.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisitDuration.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _cboVisitDuration.ItemHeight = 13;
            _cboVisitDuration.Location = new Point(360, 52);
            _cboVisitDuration.Name = "cboVisitDuration";
            _cboVisitDuration.Size = new Size(95, 21);
            _cboVisitDuration.TabIndex = 2;
            _cboVisitDuration.Tag = "ContractSite.VisitDuration";
            // 
            // cboVisitFrequencyID
            // 
            _cboVisitFrequencyID.Cursor = Cursors.Hand;
            _cboVisitFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisitFrequencyID.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _cboVisitFrequencyID.ItemHeight = 13;
            _cboVisitFrequencyID.Location = new Point(127, 52);
            _cboVisitFrequencyID.Name = "cboVisitFrequencyID";
            _cboVisitFrequencyID.Size = new Size(136, 21);
            _cboVisitFrequencyID.TabIndex = 1;
            _cboVisitFrequencyID.Tag = "ContractSite.VisitFrequencyID";
            // 
            // lblPricePerVisit
            // 
            _lblPricePerVisit.BackColor = Color.White;
            _lblPricePerVisit.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblPricePerVisit.Location = new Point(9, 82);
            _lblPricePerVisit.Name = "lblPricePerVisit";
            _lblPricePerVisit.Size = new Size(118, 20);
            _lblPricePerVisit.TabIndex = 31;
            _lblPricePerVisit.Text = "Item Price Per Visit";
            _lblPricePerVisit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            _Label2.BackColor = Color.White;
            _Label2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label2.Location = new Point(9, 19);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(71, 20);
            _Label2.TabIndex = 39;
            _Label2.Text = "Description";
            _Label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDescriptionItem
            // 
            _txtDescriptionItem.Location = new Point(127, 19);
            _txtDescriptionItem.Multiline = true;
            _txtDescriptionItem.Name = "txtDescriptionItem";
            _txtDescriptionItem.ScrollBars = ScrollBars.Vertical;
            _txtDescriptionItem.Size = new Size(328, 25);
            _txtDescriptionItem.TabIndex = 0;
            _txtDescriptionItem.Text = "";
            // 
            // lblVisitFrequencyID
            // 
            _lblVisitFrequencyID.BackColor = Color.White;
            _lblVisitFrequencyID.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblVisitFrequencyID.Location = new Point(9, 52);
            _lblVisitFrequencyID.Name = "lblVisitFrequencyID";
            _lblVisitFrequencyID.Size = new Size(94, 20);
            _lblVisitFrequencyID.TabIndex = 31;
            _lblVisitFrequencyID.Text = "Visit Frequency";
            _lblVisitFrequencyID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            _btnAdd.UseVisualStyleBackColor = true;
            _btnAdd.Location = new Point(887, 76);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(53, 23);
            _btnAdd.TabIndex = 5;
            _btnAdd.Text = "Add";
            // 
            // txtPricePerVisit
            // 
            _txtPricePerVisit.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPricePerVisit.Location = new Point(127, 82);
            _txtPricePerVisit.MaxLength = 9;
            _txtPricePerVisit.Name = "txtPricePerVisit";
            _txtPricePerVisit.Size = new Size(136, 21);
            _txtPricePerVisit.TabIndex = 3;
            _txtPricePerVisit.Tag = "ContractSite.PricePerVisit";
            _txtPricePerVisit.Text = "";
            // 
            // Label1
            // 
            _Label1.BackColor = Color.White;
            _Label1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(273, 52);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(82, 20);
            _Label1.TabIndex = 37;
            _Label1.Text = "Visit Duration";
            _Label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgAssets
            // 
            _dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAssets.DataMember = "";
            _dgAssets.HeaderForeColor = SystemColors.ControlText;
            _dgAssets.Location = new Point(458, 13);
            _dgAssets.Name = "dgAssets";
            _dgAssets.Size = new Size(427, 86);
            _dgAssets.TabIndex = 4;
            // 
            // grpJobItems
            // 
            _grpJobItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpJobItems.Location = new Point(10, 88);
            _grpJobItems.Name = "grpJobItems";
            _grpJobItems.Size = new Size(603, 230);
            _grpJobItems.TabIndex = 35;
            _grpJobItems.TabStop = false;
            _grpJobItems.Text = "Job Items";
            // 
            // UCContractAlternativeSite
            // 
            Controls.Add(_grpContractSite);
            Name = "UCContractAlternativeSite";
            Size = new Size(983, 675);
            _grpContractSite.ResumeLayout(false);
            _gpJobItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgJobItems).EndInit();
            _grpVisits.ResumeLayout(false);
            _grpJobItemAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssets).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentContractSite;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraTest);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.ContractAlternativeSites.ContractAlternativeSite _currentContractSite;

        public Entity.ContractAlternativeSites.ContractAlternativeSite CurrentContractSite
        {
            get
            {
                return _currentContractSite;
            }

            set
            {
                _currentContractSite = value;
                txtPricePerVisit.Text = "£0.00";
                if (CurrentContractSite is null)
                {
                    CurrentContractSite = new Entity.ContractAlternativeSites.ContractAlternativeSite();
                    CurrentContractSite.Exists = false;
                }

                if (CurrentContractSite.Exists)
                {
                    Populate();
                }
                else
                {
                    var tp = AddJobOfWork(null);
                }

                var site = new Entity.Sites.Site();
                site = App.DB.Sites.Get(SiteID);
                txtSite.Text = Strings.Replace(Strings.Replace(Strings.Replace(site.Address1 + ", " + site.Address2 + ", " + site.Address3 + ", " + site.Address4 + ", " + site.Address5 + ", " + site.Postcode + ".", ", , ", ", "), ", , ", ", "), ", , ", ", ");
                JobItems = App.DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID);
            }
        }

        private int _SiteID = 0;

        public int SiteID
        {
            get
            {
                return _SiteID;
            }

            set
            {
                _SiteID = value;
            }
        }

        private Entity.ContractsAlternative.ContractAlternative _CurrentContract;

        public Entity.ContractsAlternative.ContractAlternative CurrentContract
        {
            get
            {
                return _CurrentContract;
            }

            set
            {
                _CurrentContract = value;
            }
        }

        private DataView _Assets;

        private DataView Assets
        {
            get
            {
                return _Assets;
            }

            set
            {
                _Assets = value;
                _Assets.Table.TableName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString();
                _Assets.AllowNew = false;
                _Assets.AllowEdit = true;
                _Assets.AllowDelete = false;
                dgAssets.DataSource = Assets;
            }
        }

        private DataRow SelectedAssetDataRow
        {
            get
            {
                if (!(dgAssets.CurrentRowIndex == -1))
                {
                    return Assets[dgAssets.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _JobItems;

        private DataView JobItems
        {
            get
            {
                return _JobItems;
            }

            set
            {
                _JobItems = value;
                _JobItems.AllowDelete = false;
                _JobItems.AllowEdit = false;
                _JobItems.AllowNew = false;
                dgJobItems.DataSource = JobItems;
            }
        }

        private DataRow SelectedJobItemDataRow
        {
            get
            {
                if (!(dgJobItems.CurrentRowIndex == -1))
                {
                    return JobItems[dgJobItems.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupAssetsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgAssets);
            var tStyle = dgAssets.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgAssets.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Product = new DataGridLabelColumn();
            Product.Format = "";
            Product.FormatInfo = null;
            Product.HeaderText = "Product";
            Product.MappingName = "Product";
            Product.ReadOnly = true;
            Product.Width = 150;
            Product.NullText = "";
            tStyle.GridColumnStyles.Add(Product);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 90;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var SerialNum = new DataGridLabelColumn();
            SerialNum.Format = "";
            SerialNum.FormatInfo = null;
            SerialNum.HeaderText = "Serial Number";
            SerialNum.MappingName = "SerialNum";
            SerialNum.ReadOnly = true;
            SerialNum.Width = 90;
            SerialNum.NullText = "";
            tStyle.GridColumnStyles.Add(SerialNum);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString();
            dgAssets.TableStyles.Add(tStyle);
        }

        public void SetupJobItemsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgJobItems);
            var tStyle = dgJobItems.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 200;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var PricePerVisit = new DataGridLabelColumn();
            PricePerVisit.Format = "C";
            PricePerVisit.FormatInfo = null;
            PricePerVisit.HeaderText = "Item Price Per Visit";
            PricePerVisit.MappingName = "ItemPricePerVisit";
            PricePerVisit.ReadOnly = true;
            PricePerVisit.Width = 120;
            PricePerVisit.NullText = "";
            tStyle.GridColumnStyles.Add(PricePerVisit);
            var VisitFrequency = new DataGridLabelColumn();
            VisitFrequency.Format = "";
            VisitFrequency.FormatInfo = null;
            VisitFrequency.HeaderText = "Visit Frequency";
            VisitFrequency.MappingName = "VisitFrequency";
            VisitFrequency.ReadOnly = true;
            VisitFrequency.Width = 110;
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
            Assets.HeaderText = "Appliances";
            Assets.MappingName = "Assets";
            Assets.ReadOnly = true;
            Assets.Width = 130;
            Assets.NullText = "";
            tStyle.GridColumnStyles.Add(Assets);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
            dgJobItems.TableStyles.Add(tStyle);
        }

        private void UCContractSite_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void dgAssets_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgAssets.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                dgAssets.CurrentRowIndex = HitTestInfo.Row;
            }

            if (HitTestInfo.Column == 0)
            {
                bool selected = !Entity.Sys.Helper.MakeBooleanValid(dgAssets[dgAssets.CurrentRowIndex, 0]);
                Assets.Table.Rows[dgAssets.CurrentRowIndex]["Tick"] = selected;
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var jI = new Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems();
                jI.SetDescription = txtDescriptionItem.Text.Trim().Trim();
                jI.SetItemPricePerVisit = txtPricePerVisit.Text.Trim().Replace("£", "");
                jI.SetVisitFrequencyID = Combo.get_GetSelectedItemValue(cboVisitFrequencyID);
                jI.SetVisitDuration = Combo.get_GetSelectedItemValue(cboVisitDuration);
                jI.SetContractSiteID = CurrentContractSite.ContractSiteID;
                var jIV = new Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItemsValidator();
                jIV.Validate(jI);
                jI = App.DB.ContractAlternativeSiteJobItems.Insert(jI);

                // DELETE AND RE INSERT ASSET
                App.DB.ContractAlternativeSiteAsset.Delete(CurrentContractSite.ContractSiteID);
                foreach (DataRow drAsset in Assets.Table.Rows)
                {
                    if (Entity.Sys.Helper.MakeBooleanValid(drAsset["Tick"]) == true)
                    {
                        var ContractSiteAsset = new Entity.ContractAlternativeSiteAssets.ContractAlternativeSiteAsset();
                        ContractSiteAsset.SetAssetID = drAsset["AssetID"];
                        ContractSiteAsset.SetContractSiteJobItemID = jI.ContractSiteJobItemID;
                        ContractSiteAsset = App.DB.ContractAlternativeSiteAsset.Insert(ContractSiteAsset);
                    }
                }

                JobItems = App.DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID);
                txtDescriptionItem.Text = "";
                var argcombo = cboVisitDuration;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, 1.ToString());
                var argcombo1 = cboVisitFrequencyID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
                txtPricePerVisit.Text = "£0.00";
                foreach (DataRow drAsset in Assets.Table.Rows)
                    drAsset["Tick"] = false;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgJobItems_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgJobItems.HitTest(e.X, e.Y);
            if (SelectedJobItemDataRow is object)
            {
                if (HitTestInfo.Column == 4)
                {
                    App.ShowForm(typeof(FRMJobItemAssets), true, new object[] { SelectedJobItemDataRow["ContractSiteJobItemID"] });
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (SelectedJobItemDataRow is null)
            {
                return;
            }

            App.DB.ContractAlternativeSiteJobItems.Delete(Conversions.ToInteger(SelectedJobItemDataRow["ContractSiteJobItemID"]));
            JobItems.Table.Rows.Remove(SelectedJobItemDataRow);
        }

        private void btnAddJobOfWork_Click(object sender, EventArgs e)
        {
            var tp = AddJobOfWork(null);
        }

        private void btnRemoveJobOfWork_Click(object sender, EventArgs e)
        {
            RemoveJobOfWork();
        }

        private void btnAddToJobOfWork_Click(object sender, EventArgs e)
        {
            if (SelectedJobItemDataRow is null)
            {
                App.ShowMessage("Please select an item to add.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (TCJobsOfWork.TabPages.Count == 0)
            {
                App.ShowMessage("Please add a 'Job Of Work' tab page first.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).Visits.Table.Rows.Count > 0)
            {
                App.ShowMessage("Work has been scheduled so no more items can be added.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0)
            {
                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).JobItemsAddedDataView.Table.Rows[0]["VisitFrequencyID"], SelectedJobItemDataRow["VisitFrequencyID"], false)))
                {
                    App.ShowMessage("All 'Job Items' on a 'Job Of Work' must have the same visit frequency", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            App.DB.ContractAlternativeSiteJobItems.Update(Conversions.ToInteger(SelectedJobItemDataRow["ContractSiteJobitemID"]), ((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork.ContractSiteJobOfWorkID);
            JobItems = App.DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID);
            ((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).JobItemsAddedDataView = App.DB.ContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork.ContractSiteJobOfWorkID);
            // CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CurrentJobOfWork = CType(Me.TCJobsOfWork.SelectedTab.Controls(0), UCJobOfWork).CurrentJobOfWork
            ((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).CalculateItemTotal();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentContractSite = App.DB.ContractAlternativeSite.Get(ID);
                SiteID = CurrentContractSite.PropertyID;
                CurrentContract.SetContractID = CurrentContractSite.ContractID;
            }

            if (CurrentContractSite.JobOfWorks.Count > 0)
            {
                TCJobsOfWork.TabPages.Clear();
                foreach (Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork jobOfWork in CurrentContractSite.JobOfWorks)
                    var tp = AddJobOfWork(jobOfWork);
                TCJobsOfWork.SelectedTab = TCJobsOfWork.TabPages[0];
            }
        }

        public void PopAssets()
        {
            Assets = App.DB.ContractAlternativeSiteAsset.GetAll_SiteID(SiteID);
            if (!CurrentContractSite.Exists)
            {
                foreach (DataRow dr in Assets.Table.Rows)
                    dr["Tick"] = true;
            }
        }

        public bool Save()
        {
            try
            {
                if (TCJobsOfWork.TabPages.Count > 0)
                {

                    // DOES ANYTHING NEED SCHEDULING?
                    bool show = false;
                    foreach (TabPage tab in TCJobsOfWork.TabPages)
                    {
                        if (((UCJobOfWork)tab.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0 & ((UCJobOfWork)tab.Controls[0]).Visits.Table.Rows.Count == 0)
                        {
                            show = true;
                        }
                    }

                    if (show)
                    {
                        if (App.ShowMessage("Are you sure? " + "Any 'Jobs Of Work' not scheduled will now be scheduled and you will not be able to added anymore job items.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }

                Cursor = Cursors.WaitCursor;
                CurrentContractSite.IgnoreExceptionsOnSetMethods = true;
                CurrentContractSite.SetPropertyID = SiteID;
                CurrentContractSite.SetContractID = CurrentContract.ContractID;
                var cV = new Entity.ContractAlternativeSites.ContractAlternativeSiteValidator();
                cV.Validate(CurrentContractSite, CurrentContract);
                if (CurrentContractSite.Exists) // UPDATE
                {
                    App.DB.ContractAlternativeSite.Update(CurrentContractSite);
                    foreach (TabPage tab in TCJobsOfWork.TabPages)
                    {
                        App.DB.ContractAlternativeSiteJobOfWork.Update(((UCJobOfWork)tab.Controls[0]).CurrentJobOfWork, ((UCJobOfWork)tab.Controls[0]).ScheduleOfRatesDataview);

                        // START SCHEDULING JOBS************************
                        if (((UCJobOfWork)tab.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0 & ((UCJobOfWork)tab.Controls[0]).Visits.Table.Rows.Count == 0)
                        {
                            ScheduleJob(((UCJobOfWork)tab.Controls[0]).JobItemsAddedDataView, ((UCJobOfWork)tab.Controls[0]).CurrentJobOfWork.FirstVisitDate, ((UCJobOfWork)tab.Controls[0]).CurrentJobOfWork.ContractSiteJobOfWorkID);
                        }
                        // *********************************************
                    }
                }

                StateChanged?.Invoke(CurrentContractSite.ContractSiteID);
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

        private void ScheduleJob(DataView JobItemDV, DateTime FirstVisitDate, int ContractSiteJobOfWorkID)
        {
            try
            {

                // Duration OF Contract In Days
                int ContractDuration;
                // ContractDuration = CurrentContract.ContractEndDate.Subtract(CurrentContract.ContractStartDate).Days

                // New Way
                DateTime startDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00");
                DateTime endDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") + " 00:00:00");
                ContractDuration = endDate.Subtract(startDate).Days;

                // How Visit Should happen in days
                int NumOfVisits = 0;
                int VisitFreqInDays = 0;
                var switchExpr = (Entity.Sys.Enums.VisitFrequency)Conversions.ToInteger(JobItemDV.Table.Rows[0]["VisitFrequencyID"]);
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.VisitFrequency.Annually:
                        {
                            VisitFreqInDays = 365;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Bi_Annually:
                        {
                            VisitFreqInDays = 182;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Monthly:
                        {
                            VisitFreqInDays = 30;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Quarterly:
                        {
                            VisitFreqInDays = 91;
                            break;
                        }

                    case Entity.Sys.Enums.VisitFrequency.Weekly:
                        {
                            VisitFreqInDays = 7;
                            break;
                        }
                }

                NumOfVisits = Conversions.ToInteger(Math.Floor(ContractDuration / (double)VisitFreqInDays));
                if (NumOfVisits == 0)
                {
                    NumOfVisits = 1;
                }

                DateTime EstVisitDate = Conversions.ToDate(FirstVisitDate.Date + " 09:00:00");
                for (int i = 1, loopTo = NumOfVisits; i <= loopTo; i++)
                {
                    if (EstVisitDate >= CurrentContract.ContractStartDate & EstVisitDate <= CurrentContract.ContractEndDate)
                    {

                        // MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                        if (EstVisitDate.DayOfWeek == DayOfWeek.Saturday)
                        {
                            EstVisitDate = EstVisitDate.AddDays(2);
                        }
                        else if (EstVisitDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            EstVisitDate = EstVisitDate.AddDays(1);
                        }

                        // CREATE JOB
                        var job = new Entity.Jobs.Job();
                        job.SetPropertyID = CurrentContractSite.PropertyID;
                        job.SetJobDefinitionEnumID = Conversions.ToInteger(Entity.Sys.Enums.JobDefinition.Contract);
                        job.SetJobTypeID = App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")[0]["ManagerID"];
                        job.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.JobStatus.Open);
                        job.SetCreatedByUserID = App.loggedInUser.UserID;
                        var JobNumber = new JobNumber();
                        JobNumber = App.DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract);
                        job.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                        job.SetPONumber = "";
                        job.SetQuoteID = 0;
                        job.SetFOC = true;
                        job.SetContractID = CurrentContract.ContractID;
                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            job.SetDeleted = true;
                        }

                        // INSERT JOB ITEM
                        var JobOfWork = new Entity.JobOfWorks.JobOfWork();
                        JobOfWork.IgnoreExceptionsOnSetMethods = true;
                        JobOfWork.SetPONumber = "";
                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            JobOfWork.SetDeleted = true;
                        }

                        // Work out how long all the jobitems will take - running tally
                        int JobDuration = 0;
                        foreach (DataRow rw in JobItemDV.Table.Rows)
                        {
                            var JobItem = new Entity.JobItems.JobItem();
                            JobItem.IgnoreExceptionsOnSetMethods = true;
                            JobItem.SetSummary = Entity.Sys.Helper.MakeStringValid("PPM Contract Visit: ") + rw["Description"];
                            JobDuration += rw["VisitDuration"];

                            // INSERT ANY ASSETS
                            var AssetsDV = App.DB.ContractAlternativeSiteAsset.GetAll_JobItemID(Conversions.ToInteger(rw["ContractSiteJobItemID"]));
                            foreach (DataRow dr in AssetsDV.Table.Rows)
                            {
                                var JobAsset = new Entity.JobAssets.JobAsset();
                                JobAsset.SetAssetID = dr["AssetID"];
                                job.Assets.Add(JobAsset);
                            }

                            JobOfWork.JobItems.Add(JobItem);
                        }

                        // NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                        var match = new ArrayList();
                        int engineerID = 0;
                        DateTime actualVisitDate = default;
                        match = MatchingEngineer(job, EstVisitDate, JobDuration);
                        if (match is object)
                        {
                            if (match.Count > 0)
                            {
                                actualVisitDate = Conversions.ToDate(match[0]);
                                engineerID = Conversions.ToInteger(match[1]);
                            }
                        }

                        // IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                        var EngineerVisit = new Entity.EngineerVisits.EngineerVisit();
                        EngineerVisit.IgnoreExceptionsOnSetMethods = true;
                        EngineerVisit.SetEngineerID = engineerID;
                        EngineerVisit.SetNotesToEngineer = "PPM Contract Visit";

                        // If engineerID > 0 Then
                        // EngineerVisit.StartDateTime = actualVisitDate
                        // EngineerVisit.EndDateTime = actualVisitDate.AddMinutes(JobDuration)
                        // EngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                        // Else
                        EngineerVisit.StartDateTime = DateTime.MinValue;
                        EngineerVisit.EndDateTime = DateTime.MinValue;
                        EngineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule);
                        // End If

                        if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
                        {
                            EngineerVisit.SetDeleted = true;
                        }

                        JobOfWork.EngineerVisits.Add(EngineerVisit);
                        job.JobOfWorks.Add(JobOfWork);
                        job = App.DB.Job.Insert(job);

                        // CREATE PPM VISIT RECORD
                        var PPM = new Entity.ContractAlternativePPMVisits.ContractAlternativePPMVisit();
                        PPM.SetContractSiteJobOfWorkID = ContractSiteJobOfWorkID;
                        PPM.EstimatedVisitDate = EstVisitDate;
                        PPM.SetJobID = job.JobID;
                        App.DB.ContractAlternativePPMVisit.Insert(PPM);
                        EstVisitDate = EstVisitDate.AddDays(VisitFreqInDays);
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TabPage AddJobOfWork(Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork jobOfWork)
        {
            var tp = new TabPage();
            tp.BackColor = Color.White;
            var ctrl = new UCJobOfWork();
            ctrl.OnControl = this;
            if (jobOfWork is null)
            {
                jobOfWork = new Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork();
                jobOfWork.SetContractSiteID = CurrentContractSite.ContractSiteID;
                jobOfWork.FirstVisitDate = CurrentContract.ContractStartDate.AddDays(1);
                jobOfWork.SetPricePerMile = Entity.Sys.Helper.MakeDoubleValid(App.DB.Manager.Get()?.MileageRate);
                jobOfWork = App.DB.ContractAlternativeSiteJobOfWork.Insert(jobOfWork);
            }

            ctrl.CurrentJobOfWork = jobOfWork;
            ctrl.RemovedItem += ItemRemovedFromJobOfWork;
            ctrl.Dock = DockStyle.Fill;
            tp.Controls.Add(ctrl);
            TCJobsOfWork.TabPages.Add(tp);
            CheckTabs();
            TCJobsOfWork.SelectedTab = tp;
            return tp;
        }

        private void CheckTabs()
        {
            int i = 1;
            foreach (TabPage tab in TCJobsOfWork.TabPages)
            {
                tab.Text = "Job Of Work #" + i;
                i += 1;
            }
        }

        private void RemoveJobOfWork()
        {
            if (((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).JobItemsAddedDataView.Table.Rows.Count > 0)
            {
                App.ShowMessage("Items of work has been added to this Job Of Work." + Constants.vbCrLf + "You must remove all the items first.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).Visits.Table.Rows.Count > 0)
            {
                App.ShowMessage("Work has been scheduled." + Constants.vbCrLf + "Cannot remove this Job of Work.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            App.DB.ContractAlternativeSiteJobOfWork.Delete(((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork.ContractSiteJobOfWorkID);
            TCJobsOfWork.TabPages.Remove(TCJobsOfWork.SelectedTab);
            CheckTabs();
        }

        public void ItemRemovedFromJobOfWork()
        {
            JobItems = App.DB.ContractAlternativeSiteJobItems.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID);
            ((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork = ((UCJobOfWork)TCJobsOfWork.SelectedTab.Controls[0]).CurrentJobOfWork;
        }

        private ArrayList MatchingEngineer(Entity.Jobs.Job job, DateTime estVisitDate, int visitDuration)
        {
            var site = new Entity.Sites.Site();
            int engineerID = 0;
            int slotDuration = 0; // MINTUES
                                  // Dim visitDuration As Integer = 0
            int numOfSlotsNeeded = 0;
            var match = new ArrayList();
            string postcode = "";
            DataView postcodeEngineers = null;
            int cntPostcodeEng = 0;
            int randomNum = 0;

            // SYSTEM NUMBER OF MINUTES IN A SLOTS
            slotDuration = App.DB.Manager.Get().TimeSlot;

            // VISIT DURATION FOR THIS SITE IN HOURS - its passed!
            // visitDuration = Combo.GetSelectedItemValue(cboVisitDuration)

            // NUM OF SLOTS NEEDED FOR VISIT
            if (visitDuration > 0)
            {
                numOfSlotsNeeded = (int)(visitDuration / (double)slotDuration);
            }
            // ***************************************************************

            // SEE IF THE SITE HAS A DEFAULT ENGINEER
            site = App.DB.Sites.Get(job.PropertyID);
            if (site.EngineerID > 0)
            {
                // IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
                match = CheckAvailability(estVisitDate, site.EngineerID, numOfSlotsNeeded);
            }
            // IF A ENG & SLOT IS FOUND, RETURN
            if (match.Count > 0)
            {
                return match;
            }

            // NO MATCH FOUND FOR SITE ENGINEER
            // IS THERE A MATCH FOR POSTCODE ENGINEERS
            postcode = site.Postcode.Replace("-", "");
            postcode = postcode.Replace(" ", "");
            postcode = postcode.Substring(0, postcode.Length - 3);

            // GET ALL THE ENGINEERS THAT COVER THAT POSTCODE
            postcodeEngineers = App.DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(postcode);
            cntPostcodeEng = postcodeEngineers.Table.Rows.Count;
            if (cntPostcodeEng > 0)
            {
                for (int i = 0, loopTo = cntPostcodeEng - 1; i <= loopTo; i++)
                {
                    VBMath.Randomize();
                    randomNum = Conversions.ToInteger(Conversion.Int(postcodeEngineers.Table.Rows.Count * VBMath.Rnd() + 1)) - 1;
                    match = CheckAvailability(estVisitDate, Conversions.ToInteger(postcodeEngineers.Table.Rows[randomNum]["EngineerID"]), numOfSlotsNeeded);

                    // IF A ENG & SLOT IS FOUND, RETURN
                    if (match.Count > 0)
                    {
                        return match;
                    }
                    else
                    {
                        postcodeEngineers.Table.Rows.Remove(postcodeEngineers.Table.Rows[randomNum]);
                    }
                }
            }

            return default;
        }

        private ArrayList CheckAvailability(DateTime estimatedVisitDate, int engineerID, int numOfSlotsNeeded)
        {
            DataTable engTimeSlots;
            var numOfSlotsAvailable = new ArrayList();
            var actualVisitDate = estimatedVisitDate;
            var match = new ArrayList();
            string startSlotTime = "";
            for (int day = 0; day <= 4; day++)
            {
                numOfSlotsAvailable.Clear();

                // ADD ON DAYS - UNLESS FIRST TIME IN
                if (day != 0)
                {
                    actualVisitDate = actualVisitDate.AddDays(1);
                }

                // MAKE IT NOT SAT
                if (actualVisitDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    actualVisitDate = actualVisitDate.AddDays(2);
                }
                // MAKE IT NOT SUN
                if (actualVisitDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    actualVisitDate = actualVisitDate.AddDays(1);
                }

                // GET SLOTS USED
                engTimeSlots = App.DB.Scheduler.Scheduler_DayTimeSlots(actualVisitDate, engineerID.ToString());
                // SLOTS ARE DISPLAY AS COLUMNS IN THIS TABLE THAT WHY WE LOOP THROUGH COLUMNS INSTEAD OF ROWS
                if (engTimeSlots.Rows.Count > 0)
                {
                    for (int colCnt = 0, loopTo = engTimeSlots.Columns.Count - 1; colCnt <= loopTo; colCnt++)
                    {
                        // LOOP THOROUGH EACH COLUMNS TRYING TO FIND AVAILABLE CONSECTUTIVE COLUMNS
                        // EQUAL TO THE NUMBER OF REQUIRED SLOTS
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(engTimeSlots.Rows[0][colCnt], 0, false)))
                        {
                            numOfSlotsAvailable.Add(engTimeSlots.Columns[colCnt].ColumnName);
                            if (numOfSlotsAvailable.Count == numOfSlotsNeeded)
                            {
                                break;
                            }
                        }
                        else
                        {
                            // NOTHING AVAIALABLE
                            numOfSlotsAvailable.Clear();
                        }
                    }
                }
                else
                {
                    // IF NO ROW THEN NOTHING USED FOR THAT DAY SO VISIT CAN GO AT THE BEGINNING
                    numOfSlotsAvailable.Add(App.DB.Manager.Get().WorkingHoursStart);
                }

                if (numOfSlotsAvailable.Count > 0)
                {
                    if (Conversions.ToBoolean(numOfSlotsAvailable.Count == numOfSlotsNeeded | Operators.ConditionalCompareObjectEqual(numOfSlotsAvailable[0], App.DB.Manager.Get().WorkingHoursStart, false)))
                    {

                        // IF THERE ARE ENOUGH AVAILABLE CONSECTUTIVE SLOTS ADD THE START TIME ONTO THE DATE

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(numOfSlotsAvailable[0], App.DB.Manager.Get().WorkingHoursStart, false)))
                        {
                            startSlotTime = Conversions.ToString(numOfSlotsAvailable[0]);
                        }
                        else
                        {
                            startSlotTime = Strings.Replace(Conversions.ToString(numOfSlotsAvailable[0]), "T", "").Insert(2, ":");
                        }

                        actualVisitDate = Conversions.ToDate(Strings.Format(actualVisitDate, "dd/MM/yyyy") + " " + startSlotTime);
                        match.Add(actualVisitDate);
                        match.Add(engineerID);
                        return match;
                    }
                }
            }

            return match;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}