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
    public class FRMViewContractAlternativeChargeDetails : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMViewContractAlternativeChargeDetails() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMViewContractAlternativeChargeDetails_Load;

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
                }

                _txtAverageMileage = value;
                if (_txtAverageMileage != null)
                {
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
                }

                _txtCostPerMile = value;
                if (_txtCostPerMile != null)
                {
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
                }

                _chkIncludeMileage = value;
                if (_chkIncludeMileage != null)
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
                }

                _chkRates = value;
                if (_chkRates != null)
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

        private Button _btnDone;

        internal Button btnDone
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDone;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDone != null)
                {
                    _btnDone.Click -= btnDone_Click;
                }

                _btnDone = value;
                if (_btnDone != null)
                {
                    _btnDone.Click += btnDone_Click;
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _Label1 = new Label();
            _dgScheduleOfRates = new DataGrid();
            _Label5 = new Label();
            _Label4 = new Label();
            _Label3 = new Label();
            _txtMileageCostPerVisit = new TextBox();
            _txtAverageMileage = new TextBox();
            _txtCostPerMile = new TextBox();
            _Label8 = new Label();
            _txtRatesTotal = new TextBox();
            _chkRates = new CheckBox();
            _chkIncludeMileage = new CheckBox();
            _btnDone = new Button();
            _btnDone.Click += new EventHandler(btnDone_Click);
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRates).BeginInit();
            SuspendLayout();
            //
            // GroupBox1
            //
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_dgScheduleOfRates);
            _GroupBox1.Controls.Add(_Label5);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_txtMileageCostPerVisit);
            _GroupBox1.Controls.Add(_txtAverageMileage);
            _GroupBox1.Controls.Add(_txtCostPerMile);
            _GroupBox1.Controls.Add(_Label8);
            _GroupBox1.Controls.Add(_txtRatesTotal);
            _GroupBox1.Controls.Add(_chkRates);
            _GroupBox1.Controls.Add(_chkIncludeMileage);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(688, 240);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Charge Information";
            //
            // Label1
            //
            _Label1.Location = new Point(6, 17);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(144, 24);
            _Label1.TabIndex = 80;
            _Label1.Text = "Schedule Of Rates";
            _Label1.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dgScheduleOfRates
            //
            _dgScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgScheduleOfRates.DataMember = "";
            _dgScheduleOfRates.HeaderForeColor = SystemColors.ControlText;
            _dgScheduleOfRates.Location = new Point(8, 44);
            _dgScheduleOfRates.Name = "dgScheduleOfRates";
            _dgScheduleOfRates.Size = new Size(672, 113);
            _dgScheduleOfRates.TabIndex = 79;
            //
            // Label5
            //
            _Label5.Enabled = false;
            _Label5.Location = new Point(112, 208);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(104, 23);
            _Label5.TabIndex = 78;
            _Label5.Text = "Mileage Per Visit";
            _Label5.TextAlign = ContentAlignment.MiddleLeft;
            //
            // Label4
            //
            _Label4.Enabled = false;
            _Label4.Location = new Point(296, 208);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(98, 23);
            _Label4.TabIndex = 77;
            _Label4.Text = "Price Per Mile";
            _Label4.TextAlign = ContentAlignment.MiddleLeft;
            //
            // Label3
            //
            _Label3.Enabled = false;
            _Label3.Location = new Point(464, 208);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(144, 23);
            _Label3.TabIndex = 76;
            _Label3.Text = "= Mileage Price Per Visit";
            _Label3.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtMileageCostPerVisit
            //
            _txtMileageCostPerVisit.Enabled = false;
            _txtMileageCostPerVisit.Location = new Point(608, 208);
            _txtMileageCostPerVisit.Name = "txtMileageCostPerVisit";
            _txtMileageCostPerVisit.Size = new Size(72, 21);
            _txtMileageCostPerVisit.TabIndex = 74;
            //
            // txtAverageMileage
            //
            _txtAverageMileage.Enabled = false;
            _txtAverageMileage.Location = new Point(232, 208);
            _txtAverageMileage.Name = "txtAverageMileage";
            _txtAverageMileage.Size = new Size(58, 21);
            _txtAverageMileage.TabIndex = 73;
            _txtAverageMileage.Text = "0";
            //
            // txtCostPerMile
            //
            _txtCostPerMile.Enabled = false;
            _txtCostPerMile.Location = new Point(400, 208);
            _txtCostPerMile.Name = "txtCostPerMile";
            _txtCostPerMile.Size = new Size(58, 21);
            _txtCostPerMile.TabIndex = 72;
            _txtCostPerMile.Text = "£0.00";
            //
            // Label8
            //
            _Label8.Enabled = false;
            _Label8.Location = new Point(520, 160);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(87, 24);
            _Label8.TabIndex = 71;
            _Label8.Text = "Rate Total:";
            _Label8.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtRatesTotal
            //
            _txtRatesTotal.Enabled = false;
            _txtRatesTotal.Location = new Point(608, 162);
            _txtRatesTotal.MaxLength = 50;
            _txtRatesTotal.Name = "txtRatesTotal";
            _txtRatesTotal.Size = new Size(72, 21);
            _txtRatesTotal.TabIndex = 70;
            _txtRatesTotal.Tag = "SystemScheduleOfRate.Code";
            //
            // chkRates
            //
            _chkRates.Enabled = false;
            _chkRates.Location = new Point(8, 158);
            _chkRates.Name = "chkRates";
            _chkRates.Size = new Size(176, 25);
            _chkRates.TabIndex = 69;
            _chkRates.Text = "Include Rates in Visit Total";
            //
            // chkIncludeMileage
            //
            _chkIncludeMileage.Enabled = false;
            _chkIncludeMileage.Location = new Point(8, 184);
            _chkIncludeMileage.Name = "chkIncludeMileage";
            _chkIncludeMileage.Size = new Size(192, 23);
            _chkIncludeMileage.TabIndex = 75;
            _chkIncludeMileage.Text = "Include Mileage in Visit Total";
            //
            // btnDone
            //
            _btnDone.UseVisualStyleBackColor = true;
            _btnDone.Location = new Point(600, 288);
            _btnDone.Name = "btnDone";
            _btnDone.Size = new Size(90, 25);
            _btnDone.TabIndex = 1;
            _btnDone.Text = "Done";
            //
            // FRMViewContractAlternativeChargeDetails
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(704, 318);
            Controls.Add(_GroupBox1);
            Controls.Add(_btnDone);
            Name = "FRMViewContractAlternativeChargeDetails";
            Text = "Job Item Charges";
            Controls.SetChildIndex(_btnDone, 0);
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRates).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupScheduleOfRatesDataGrid();
            ScheduleOfRatesDataview = App.DB.ContractAlternativeSiteJobOfWork.GetJobOfWorkScheduleOfRates(Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0)));
            chkIncludeMileage.Checked = Conversions.ToBoolean(get_GetParameter(1));
            chkRates.Checked = Conversions.ToBoolean(get_GetParameter(2));
            txtAverageMileage.Text = Conversions.ToString(get_GetParameter(3));
            txtCostPerMile.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(get_GetParameter(4)), "C");
            CalculateRates();
            CalculateMileageTotal();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return default;
            }
        }

        public void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _ScheduleOfRatesDataview;

        private DataView ScheduleOfRatesDataview
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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
            Category.Width = 150;
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
            Description.Width = 250;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = false;
            Price.Width = 75;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var QtyPerVisit = new DataGridLabelColumn();
            QtyPerVisit.Format = "";
            QtyPerVisit.FormatInfo = null;
            QtyPerVisit.HeaderText = "Qty Per Visit";
            QtyPerVisit.MappingName = "QtyPerVisit";
            QtyPerVisit.ReadOnly = false;
            QtyPerVisit.Width = 85;
            QtyPerVisit.NullText = "";
            tStyle.GridColumnStyles.Add(QtyPerVisit);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
            dgScheduleOfRates.TableStyles.Add(tStyle);
        }

        private void FRMViewContractAlternativeChargeDetails_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnDone_Click(object sender, EventArgs e)
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
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void CalculateRates()
        {
            decimal runningTotal = 0.0M;
            foreach (DataRow rate in ScheduleOfRatesDataview.Table.Rows)
                runningTotal += (decimal)rate["Price"] * (decimal)rate["QtyPerVisit"];
            txtRatesTotal.Text = Strings.Format(runningTotal, "C");
        }

        private void CalculateMileageTotal()
        {
            txtMileageCostPerVisit.Text = Strings.Format(Entity.Sys.Helper.MakeDoubleValid(txtAverageMileage.Text) * Entity.Sys.Helper.MakeDoubleValid(txtCostPerMile.Text.Replace("£", "")), "C");
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}