using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMChangeVAT : Form
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMChangeVAT(int CurrentRateID, int InvoicedIDin, string InvNumber) : base()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            SetupRatesDataGrid();
            GroupBox1.Text = string.Format(GroupBox1.Text, InvNumber);
            InvoicedID = InvoicedIDin;
            Populate(CurrentRateID);
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

        private Button _btnSetRate;

        internal Button btnSetRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSetRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSetRate != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnSetRate.Click -= btnSetRate_Click;
                }

                _btnSetRate = value;
                if (_btnSetRate != null)
                {
                    _btnSetRate.Click += btnSetRate_Click;
                }
            }
        }

        private DataGrid _dgRates;

        internal DataGrid dgRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgRates != null)
                {
                }

                _dgRates = value;
                if (_dgRates != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _dgRates = new DataGrid();
            _btnSetRate = new Button();
            _btnSetRate.Click += new EventHandler(btnSetRate_Click);
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRates).BeginInit();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dgRates);
            _GroupBox1.Location = new Point(8, 8);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(272, 224);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Select A VAT Rate for {0}";
            // 
            // dgRates
            // 
            _dgRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgRates.DataMember = "";
            _dgRates.HeaderForeColor = SystemColors.ControlText;
            _dgRates.Location = new Point(8, 16);
            _dgRates.Name = "dgRates";
            _dgRates.Size = new Size(256, 192);
            _dgRates.TabIndex = 0;
            // 
            // btnSetRate
            // 
            _btnSetRate.UseVisualStyleBackColor = true;
            _btnSetRate.Location = new Point(112, 240);
            _btnSetRate.Name = "btnSetRate";
            _btnSetRate.TabIndex = 1;
            _btnSetRate.Text = "Set Rate";
            // 
            // FRMChangeVAT
            // 
            AutoScaleBaseSize = new Size(5, 13);
            BackColor = Color.White;
            ClientSize = new Size(288, 266);
            ControlBox = false;
            Controls.Add(_btnSetRate);
            Controls.Add(_GroupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximumSize = new Size(294, 298);
            MinimumSize = new Size(294, 298);
            Name = "FRMChangeVAT";
            Text = "Change VAT Rate";
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgRates).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _InvoicedID;

        private int InvoicedID
        {
            get
            {
                return _InvoicedID;
            }

            set
            {
                _InvoicedID = value;
            }
        }

        private DataView _dvRates;

        private DataView RatesDataview
        {
            get
            {
                return _dvRates;
            }

            set
            {
                _dvRates = value;
                _dvRates.AllowNew = false;
                _dvRates.AllowEdit = false;
                _dvRates.AllowDelete = false;
                _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblVATRates.ToString();
                dgRates.DataSource = RatesDataview;
            }
        }

        private DataRow SelectedVATRateDataRow
        {
            get
            {
                if (!(dgRates.CurrentRowIndex == -1))
                {
                    return RatesDataview[dgRates.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void btnSetRate_Click(object sender, EventArgs e)
        {
            var inv = App.DB.Invoiced.Invoiced_Get(InvoicedID);
            inv.SetVATRateID = SelectedVATRateDataRow["VatRateID"];
            App.DB.Invoiced.Update(inv);
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
        private void SetupRatesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgRates);
            var tbStyle = dgRates.TableStyles[0];
            var VATRate = new DataGridLabelColumn();
            VATRate.Format = "";
            VATRate.FormatInfo = null;
            VATRate.HeaderText = "VAT Rate";
            VATRate.MappingName = "VATRate";
            VATRate.ReadOnly = true;
            VATRate.Width = 150;
            VATRate.NullText = "";
            tbStyle.GridColumnStyles.Add(VATRate);
            var DateIntroduced = new DataGridLabelColumn();
            DateIntroduced.Format = "dd/MM/yyyy";
            DateIntroduced.FormatInfo = null;
            DateIntroduced.HeaderText = "Date Introduced";
            DateIntroduced.MappingName = "DateIntroduced";
            DateIntroduced.ReadOnly = true;
            DateIntroduced.Width = 150;
            DateIntroduced.NullText = "";
            tbStyle.GridColumnStyles.Add(DateIntroduced);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblVATRates.ToString();
            dgRates.TableStyles.Add(tbStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int CurrentRateID)
        {
            RatesDataview = App.DB.VATRatesSQL.VATRates_GetAll();
            int i = 0;
            foreach (DataRow r in RatesDataview.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["VATRateID"], CurrentRateID, false)))
                {
                    dgRates.CurrentRowIndex = i;
                    dgRates.Select(i);
                }

                i += 1;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}