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
    public class FRMOrderCharges : FRMBaseForm, IForm
    {
        

        public FRMOrderCharges() : base()
        {
            
            
            base.Load += FRMOrderCharges_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboChargeType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.OrderChargeTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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
        private GroupBox _grpCharges;

        internal GroupBox grpCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCharges != null)
                {
                }

                _grpCharges = value;
                if (_grpCharges != null)
                {
                }
            }
        }

        private DataGrid _dgCharges;

        internal DataGrid dgCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgCharges != null)
                {
                    _dgCharges.Click -= dgCharges_Click;
                    _dgCharges.CurrentCellChanged -= dgCharges_Click;
                }

                _dgCharges = value;
                if (_dgCharges != null)
                {
                    _dgCharges.Click += dgCharges_Click;
                    _dgCharges.CurrentCellChanged += dgCharges_Click;
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

        private ComboBox _cboChargeType;

        internal ComboBox cboChargeType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboChargeType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboChargeType != null)
                {
                }

                _cboChargeType = value;
                if (_cboChargeType != null)
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

        private TextBox _txtAmount;

        internal TextBox txtAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAmount != null)
                {
                }

                _txtAmount = value;
                if (_txtAmount != null)
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

        private Button _btnDelete;

        internal Button btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpCharges = new System.Windows.Forms.GroupBox();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._txtAmount = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._cboChargeType = new System.Windows.Forms.ComboBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._dgCharges = new System.Windows.Forms.DataGrid();
            this._grpCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpCharges
            // 
            this._grpCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCharges.Controls.Add(this._btnDelete);
            this._grpCharges.Controls.Add(this._btnSave);
            this._grpCharges.Controls.Add(this._txtAmount);
            this._grpCharges.Controls.Add(this._Label2);
            this._grpCharges.Controls.Add(this._cboChargeType);
            this._grpCharges.Controls.Add(this._Label1);
            this._grpCharges.Controls.Add(this._dgCharges);
            this._grpCharges.Location = new System.Drawing.Point(8, 12);
            this._grpCharges.Name = "_grpCharges";
            this._grpCharges.Size = new System.Drawing.Size(552, 300);
            this._grpCharges.TabIndex = 2;
            this._grpCharges.TabStop = false;
            this._grpCharges.Text = "Charges";
            // 
            // _btnDelete
            // 
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDelete.Location = new System.Drawing.Point(480, 236);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(64, 23);
            this._btnDelete.TabIndex = 5;
            this._btnDelete.Text = "Remove";
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(480, 268);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(64, 23);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Add";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _txtAmount
            // 
            this._txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAmount.Location = new System.Drawing.Point(400, 268);
            this._txtAmount.Name = "_txtAmount";
            this._txtAmount.Size = new System.Drawing.Size(72, 21);
            this._txtAmount.TabIndex = 3;
            // 
            // _Label2
            // 
            this._Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label2.Location = new System.Drawing.Point(336, 268);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(56, 23);
            this._Label2.TabIndex = 3;
            this._Label2.Text = "Amount:";
            // 
            // _cboChargeType
            // 
            this._cboChargeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboChargeType.Location = new System.Drawing.Point(96, 268);
            this._cboChargeType.Name = "_cboChargeType";
            this._cboChargeType.Size = new System.Drawing.Size(232, 21);
            this._cboChargeType.TabIndex = 2;
            // 
            // _Label1
            // 
            this._Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label1.Location = new System.Drawing.Point(8, 268);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(88, 23);
            this._Label1.TabIndex = 1;
            this._Label1.Text = "Charge Type:";
            // 
            // _dgCharges
            // 
            this._dgCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgCharges.DataMember = "";
            this._dgCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgCharges.Location = new System.Drawing.Point(8, 25);
            this._dgCharges.Name = "_dgCharges";
            this._dgCharges.Size = new System.Drawing.Size(536, 203);
            this._dgCharges.TabIndex = 1;
            this._dgCharges.CurrentCellChanged += new System.EventHandler(this.dgCharges_Click);
            this._dgCharges.Click += new System.EventHandler(this.dgCharges_Click);
            // 
            // FRMOrderCharges
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(568, 318);
            this.Controls.Add(this._grpCharges);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(576, 352);
            this.Name = "FRMOrderCharges";
            this.Text = "Order Charges";
            this._grpCharges.ResumeLayout(false);
            this._grpCharges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCharges)).EndInit();
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            OrderID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            LoadForm(sender, e, this);
            SetupChargesDatagrid();
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
            OrderID = newID;
        }

        
        
        private int _OrderID;

        public int OrderID
        {
            get
            {
                return _OrderID;
            }

            set
            {
                _OrderID = value;
                RefreshDatagrid();
            }
        }

        private Entity.Sys.Enums.FormState _PageState = Entity.Sys.Enums.FormState.Insert;

        public Entity.Sys.Enums.FormState PageState
        {
            get
            {
                return _PageState;
            }

            set
            {
                _PageState = value;
                var switchExpr = PageState;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            btnSave.Text = "Add";
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            btnSave.Text = "Update";
                            break;
                        }
                }

                txtAmount.Text = "";
                var argcombo = cboChargeType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            }
        }

        private DataView _ChargesDataView = null;

        public DataView ChargesDataView
        {
            get
            {
                return _ChargesDataView;
            }

            set
            {
                _ChargesDataView = value;
                _ChargesDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString();
                _ChargesDataView.AllowNew = false;
                _ChargesDataView.AllowEdit = false;
                _ChargesDataView.AllowDelete = false;
                dgCharges.DataSource = ChargesDataView;
            }
        }

        private DataRow SelectedChargeDataRow
        {
            get
            {
                if (!(dgCharges.CurrentRowIndex == -1))
                {
                    return ChargesDataView[dgCharges.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        
        

        public void SetupChargesDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgCharges);
            var tStyle = dgCharges.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var ChargeType = new DataGridLabelColumn();
            ChargeType.Format = "";
            ChargeType.FormatInfo = null;
            ChargeType.HeaderText = "ChargeType";
            ChargeType.MappingName = "ChargeType";
            ChargeType.ReadOnly = true;
            ChargeType.Width = 130;
            ChargeType.NullText = "N/A";
            tStyle.GridColumnStyles.Add(ChargeType);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "C";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 130;
            Amount.NullText = "N/A";
            tStyle.GridColumnStyles.Add(Amount);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString();
            dgCharges.TableStyles.Add(tStyle);
        }

        private void FRMOrderCharges_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void dgCharges_Click(object sender, EventArgs e)
        {
            if (SelectedChargeDataRow is null)
            {
                PageState = Entity.Sys.Enums.FormState.Insert;
                return;
            }

            PageState = Entity.Sys.Enums.FormState.Update;
            txtAmount.Text = Conversions.ToString(SelectedChargeDataRow["Amount"]);
            var argcombo = cboChargeType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(SelectedChargeDataRow["OrderChargeTypeID"]));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var oOrderCharge = new Entity.OrderCharges.OrderCharge();
                oOrderCharge.IgnoreExceptionsOnSetMethods = true;
                oOrderCharge.SetAmount = txtAmount.Text.Trim();
                oOrderCharge.SetOrderChargeTypeID = Combo.get_GetSelectedItemValue(cboChargeType);
                oOrderCharge.SetOrderID = OrderID;
                var oValidator = new Entity.OrderCharges.OrderChargeValidator();
                oValidator.Validate(oOrderCharge);
                var switchExpr = PageState;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            App.DB.OrderCharge.Insert(oOrderCharge);
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            oOrderCharge.SetOrderChargeID = SelectedChargeDataRow["OrderChargeID"];
                            App.DB.OrderCharge.Update(oOrderCharge);
                            break;
                        }
                }

                RefreshDatagrid();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedChargeDataRow is null)
            {
                App.ShowMessage("Please select a charge to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                PageState = Entity.Sys.Enums.FormState.Insert;
                return;
            }

            if (App.ShowMessage("Are you sure you want to remove this charge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            App.DB.OrderCharge.Delete(Conversions.ToInteger(SelectedChargeDataRow["OrderChargeID"]));
            RefreshDatagrid();
        }

        
        

        public void RefreshDatagrid()
        {
            ChargesDataView = App.DB.OrderCharge.OrderCharge_GetForOrder(OrderID);
            PageState = Entity.Sys.Enums.FormState.Insert;
        }

        
    }
}