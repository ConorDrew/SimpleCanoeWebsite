using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMVATRates : FRMBaseForm, IForm
    {
        

        public FRMVATRates() : base()
        {
            
            
            base.Load += FRMVATRates_Load;

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

        private Button _btnAddNew;

        internal Button btnAddNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddNew != null)
                {
                    _btnAddNew.Click -= btnAddNew_Click;
                }

                _btnAddNew = value;
                if (_btnAddNew != null)
                {
                    _btnAddNew.Click += btnAddNew_Click;
                }
            }
        }

        private DataGrid _dgVATRates;

        internal DataGrid dgVATRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgVATRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgVATRates != null)
                {
                    _dgVATRates.Click -= dgVATRates_Click;
                }

                _dgVATRates = value;
                if (_dgVATRates != null)
                {
                    _dgVATRates.Click += dgVATRates_Click;
                }
            }
        }

        private GroupBox _grpDetails;

        internal GroupBox grpDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpDetails != null)
                {
                }

                _grpDetails = value;
                if (_grpDetails != null)
                {
                }
            }
        }

        private TextBox _txtVATRate;

        internal TextBox txtVATRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVATRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVATRate != null)
                {
                }

                _txtVATRate = value;
                if (_txtVATRate != null)
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

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
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

        private DateTimePicker _dtpVATDate;

        internal DateTimePicker dtpVATDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpVATDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpVATDate != null)
                {
                }

                _dtpVATDate = value;
                if (_dtpVATDate != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _dgVATRates = new DataGrid();
            _dgVATRates.Click += new EventHandler(dgVATRates_Click);
            _grpDetails = new GroupBox();
            _dtpVATDate = new DateTimePicker();
            _Label1 = new Label();
            _txtVATRate = new TextBox();
            _Label2 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _Label3 = new Label();
            _txtCode = new TextBox();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVATRates).BeginInit();
            _grpDetails.SuspendLayout();
            SuspendLayout();
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_btnAddNew);
            _GroupBox1.Controls.Add(_dgVATRates);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(512, 328);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "VAT Rates";
            //
            // btnAddNew
            //
            _btnAddNew.AccessibleDescription = "Add new item";
            _btnAddNew.Cursor = Cursors.Hand;
            _btnAddNew.UseVisualStyleBackColor = true;
            _btnAddNew.Location = new Point(8, 16);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.Size = new Size(48, 24);
            _btnAddNew.TabIndex = 0;
            _btnAddNew.Text = "New";
            //
            // dgVATRates
            //
            _dgVATRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVATRates.DataMember = "";
            _dgVATRates.HeaderForeColor = SystemColors.ControlText;
            _dgVATRates.Location = new Point(8, 52);
            _dgVATRates.Name = "dgVATRates";
            _dgVATRates.Size = new Size(496, 268);
            _dgVATRates.TabIndex = 1;
            //
            // grpDetails
            //
            _grpDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _grpDetails.Controls.Add(_txtCode);
            _grpDetails.Controls.Add(_Label3);
            _grpDetails.Controls.Add(_dtpVATDate);
            _grpDetails.Controls.Add(_Label1);
            _grpDetails.Controls.Add(_txtVATRate);
            _grpDetails.Controls.Add(_Label2);
            _grpDetails.Controls.Add(_btnSave);
            _grpDetails.Location = new Point(8, 374);
            _grpDetails.Name = "grpDetails";
            _grpDetails.Size = new Size(512, 106);
            _grpDetails.TabIndex = 1;
            _grpDetails.TabStop = false;
            _grpDetails.Text = "Details";
            //
            // dtpVATDate
            //
            _dtpVATDate.Location = new Point(120, 48);
            _dtpVATDate.Name = "dtpVATDate";
            _dtpVATDate.Size = new Size(328, 21);
            _dtpVATDate.TabIndex = 1;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 48);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(120, 23);
            _Label1.TabIndex = 8;
            _Label1.Text = "From Date";
            //
            // txtVATRate
            //
            _txtVATRate.Location = new Point(120, 24);
            _txtVATRate.MaxLength = 255;
            _txtVATRate.Name = "txtVATRate";
            _txtVATRate.Size = new Size(328, 21);
            _txtVATRate.TabIndex = 0;
            //
            // Label2
            //
            _Label2.Location = new Point(8, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(120, 23);
            _Label2.TabIndex = 5;
            _Label2.Text = "Rate Amount (%)";
            //
            // btnSave
            //
            _btnSave.AccessibleDescription = "Save item";
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Cursor = Cursors.Hand;
            _btnSave.UseVisualStyleBackColor = true;
            _btnSave.ImageIndex = 1;
            _btnSave.Location = new Point(456, 74);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(48, 23);
            _btnSave.TabIndex = 3;
            _btnSave.Text = "Save";
            //
            // Label3
            //
            _Label3.Location = new Point(8, 72);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(120, 23);
            _Label3.TabIndex = 10;
            _Label3.Text = "Code";
            //
            // txtCode
            //
            _txtCode.Location = new Point(120, 75);
            _txtCode.MaxLength = 5;
            _txtCode.Name = "txtCode";
            _txtCode.Size = new Size(328, 21);
            _txtCode.TabIndex = 2;
            //
            // FRMVATRates
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(528, 486);
            Controls.Add(_GroupBox1);
            Controls.Add(_grpDetails);
            Name = "FRMVATRates";
            Text = "VAT Rates";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpDetails, 0);
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVATRates).EndInit();
            _grpDetails.ResumeLayout(false);
            _grpDetails.PerformLayout();
            ResumeLayout(false);
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupRatesDataGrid();
            PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
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

        
        
        private Entity.Sys.Enums.FormState _pageState;

        private Entity.Sys.Enums.FormState PageState
        {
            get
            {
                return _pageState;
            }

            set
            {
                _pageState = value;
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
                dgVATRates.DataSource = RatesDataview;
            }
        }

        private DataRow SelectedVATRateDataRow
        {
            get
            {
                if (!(dgVATRates.CurrentRowIndex == -1))
                {
                    return RatesDataview[dgVATRates.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        
        

        private void SetupRatesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgVATRates);
            var tbStyle = dgVATRates.TableStyles[0];
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
            var VATRateCode = new DataGridLabelColumn();
            VATRateCode.Format = "";
            VATRateCode.FormatInfo = null;
            VATRateCode.HeaderText = "Code";
            VATRateCode.MappingName = "VATRateCode";
            VATRateCode.ReadOnly = true;
            VATRateCode.Width = 75;
            VATRateCode.NullText = "";
            tbStyle.GridColumnStyles.Add(VATRateCode);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblVATRates.ToString();
            dgVATRates.TableStyles.Add(tbStyle);
        }

        private void SetUpPageState(Entity.Sys.Enums.FormState state)
        {
            Entity.Sys.Helper.ClearGroupBox(grpDetails);
            switch (state)
            {
                case Entity.Sys.Enums.FormState.Load:
                    {
                        grpDetails.Enabled = false;
                        btnAddNew.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Insert:
                    {
                        grpDetails.Enabled = true;
                        btnAddNew.Enabled = true;
                        btnSave.Enabled = true;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Update:
                    {
                        btnAddNew.Enabled = true;
                        grpDetails.Enabled = true;
                        btnSave.Enabled = true;
                        break;
                    }
            }

            PageState = state;
        }

        private void FRMVATRates_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void dgVATRates_Click(object sender, EventArgs e)
        {
            try
            {
                SetUpPageState(Entity.Sys.Enums.FormState.Update);
                if (SelectedVATRateDataRow is object)
                {
                    txtVATRate.Text = Entity.Sys.Helper.MakeDoubleValid(SelectedVATRateDataRow["VATRate"]).ToString();
                    dtpVATDate.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedVATRateDataRow["DateIntroduced"]);
                    txtCode.Text = Entity.Sys.Helper.MakeStringValid(SelectedVATRateDataRow["VATRateCode"]);
                }
                else
                {
                    SetUpPageState(Entity.Sys.Enums.FormState.Insert);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Item data cannot load : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SetUpPageState(Entity.Sys.Enums.FormState.Insert);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        
        

        private void PopulateDatagrid(Entity.Sys.Enums.FormState state)
        {
            RatesDataview = App.DB.VATRatesSQL.VATRates_GetAll();
            SetUpPageState(state);
        }

        private void Save()
        {
            var vatRate = new Entity.VATRatess.VATRates();
            vatRate.IgnoreExceptionsOnSetMethods = true;
            vatRate.SetVATRate = txtVATRate.Text;
            vatRate.DateIntroduced = dtpVATDate.Value;
            vatRate.SetVATRateCode = txtCode.Text;
            var validator = new Entity.VATRatess.VATRatesValidator();
            try
            {
                validator.Validate(vatRate);
                var switchExpr = PageState;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            App.DB.VATRatesSQL.Insert(vatRate);
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            vatRate.SetVATRateID = SelectedVATRateDataRow["VATRateID"];
                            App.DB.VATRatesSQL.Update(vatRate);
                            break;
                        }
                }

                PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
            }
            catch (ValidationException ex)
            {
                App.ShowMessage(validator.CriticalMessagesString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error Saving : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}