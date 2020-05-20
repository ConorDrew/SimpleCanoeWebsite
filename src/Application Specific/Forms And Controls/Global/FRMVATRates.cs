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
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._btnAddNew = new System.Windows.Forms.Button();
            this._dgVATRates = new System.Windows.Forms.DataGrid();
            this._grpDetails = new System.Windows.Forms.GroupBox();
            this._txtCode = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._dtpVATDate = new System.Windows.Forms.DateTimePicker();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtVATRate = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgVATRates)).BeginInit();
            this._grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._btnAddNew);
            this._GroupBox1.Controls.Add(this._dgVATRates);
            this._GroupBox1.Location = new System.Drawing.Point(8, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(512, 356);
            this._GroupBox1.TabIndex = 0;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "VAT Rates";
            // 
            // _btnAddNew
            // 
            this._btnAddNew.AccessibleDescription = "Add new item";
            this._btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddNew.Location = new System.Drawing.Point(8, 16);
            this._btnAddNew.Name = "_btnAddNew";
            this._btnAddNew.Size = new System.Drawing.Size(48, 24);
            this._btnAddNew.TabIndex = 0;
            this._btnAddNew.Text = "New";
            this._btnAddNew.UseVisualStyleBackColor = true;
            this._btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // _dgVATRates
            // 
            this._dgVATRates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgVATRates.DataMember = "";
            this._dgVATRates.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgVATRates.Location = new System.Drawing.Point(8, 52);
            this._dgVATRates.Name = "_dgVATRates";
            this._dgVATRates.Size = new System.Drawing.Size(496, 296);
            this._dgVATRates.TabIndex = 1;
            this._dgVATRates.Click += new System.EventHandler(this.dgVATRates_Click);
            // 
            // _grpDetails
            // 
            this._grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpDetails.Controls.Add(this._txtCode);
            this._grpDetails.Controls.Add(this._Label3);
            this._grpDetails.Controls.Add(this._dtpVATDate);
            this._grpDetails.Controls.Add(this._Label1);
            this._grpDetails.Controls.Add(this._txtVATRate);
            this._grpDetails.Controls.Add(this._Label2);
            this._grpDetails.Controls.Add(this._btnSave);
            this._grpDetails.Location = new System.Drawing.Point(8, 374);
            this._grpDetails.Name = "_grpDetails";
            this._grpDetails.Size = new System.Drawing.Size(512, 106);
            this._grpDetails.TabIndex = 1;
            this._grpDetails.TabStop = false;
            this._grpDetails.Text = "Details";
            // 
            // _txtCode
            // 
            this._txtCode.Location = new System.Drawing.Point(120, 75);
            this._txtCode.MaxLength = 5;
            this._txtCode.Name = "_txtCode";
            this._txtCode.Size = new System.Drawing.Size(328, 21);
            this._txtCode.TabIndex = 2;
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 72);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(120, 23);
            this._Label3.TabIndex = 10;
            this._Label3.Text = "Code";
            // 
            // _dtpVATDate
            // 
            this._dtpVATDate.Location = new System.Drawing.Point(120, 48);
            this._dtpVATDate.Name = "_dtpVATDate";
            this._dtpVATDate.Size = new System.Drawing.Size(328, 21);
            this._dtpVATDate.TabIndex = 1;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 48);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(120, 23);
            this._Label1.TabIndex = 8;
            this._Label1.Text = "From Date";
            // 
            // _txtVATRate
            // 
            this._txtVATRate.Location = new System.Drawing.Point(120, 24);
            this._txtVATRate.MaxLength = 255;
            this._txtVATRate.Name = "_txtVATRate";
            this._txtVATRate.Size = new System.Drawing.Size(328, 21);
            this._txtVATRate.TabIndex = 0;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(8, 24);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(120, 23);
            this._Label2.TabIndex = 5;
            this._Label2.Text = "Rate Amount (%)";
            // 
            // _btnSave
            // 
            this._btnSave.AccessibleDescription = "Save item";
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSave.ImageIndex = 1;
            this._btnSave.Location = new System.Drawing.Point(456, 74);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(48, 23);
            this._btnSave.TabIndex = 3;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FRMVATRates
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(528, 486);
            this.Controls.Add(this._GroupBox1);
            this.Controls.Add(this._grpDetails);
            this.Name = "FRMVATRates";
            this.Text = "VAT Rates";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgVATRates)).EndInit();
            this._grpDetails.ResumeLayout(false);
            this._grpDetails.PerformLayout();
            this.ResumeLayout(false);

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