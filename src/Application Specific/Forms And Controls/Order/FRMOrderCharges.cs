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
            _grpCharges = new GroupBox();
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _txtAmount = new TextBox();
            _Label2 = new Label();
            _cboChargeType = new ComboBox();
            _Label1 = new Label();
            _dgCharges = new DataGrid();
            _dgCharges.Click += new EventHandler(dgCharges_Click);
            _dgCharges.CurrentCellChanged += new EventHandler(dgCharges_Click);
            _dgCharges.Click += new EventHandler(dgCharges_Click);
            _dgCharges.CurrentCellChanged += new EventHandler(dgCharges_Click);
            _grpCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCharges).BeginInit();
            SuspendLayout();
            //
            // grpCharges
            //
            _grpCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpCharges.Controls.Add(_btnDelete);
            _grpCharges.Controls.Add(_btnSave);
            _grpCharges.Controls.Add(_txtAmount);
            _grpCharges.Controls.Add(_Label2);
            _grpCharges.Controls.Add(_cboChargeType);
            _grpCharges.Controls.Add(_Label1);
            _grpCharges.Controls.Add(_dgCharges);
            _grpCharges.Location = new Point(8, 40);
            _grpCharges.Name = "grpCharges";
            _grpCharges.Size = new Size(552, 272);
            _grpCharges.TabIndex = 2;
            _grpCharges.TabStop = false;
            _grpCharges.Text = "Charges";
            //
            // btnDelete
            //
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDelete.Location = new Point(480, 208);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(64, 23);
            _btnDelete.TabIndex = 5;
            _btnDelete.Text = "Remove";
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(480, 240);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(64, 23);
            _btnSave.TabIndex = 4;
            _btnSave.Text = "Add";
            //
            // txtAmount
            //
            _txtAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _txtAmount.Location = new Point(400, 240);
            _txtAmount.Name = "txtAmount";
            _txtAmount.Size = new Size(72, 21);
            _txtAmount.TabIndex = 3;
            _txtAmount.Text = "";
            //
            // Label2
            //
            _Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label2.Location = new Point(336, 240);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(56, 23);
            _Label2.TabIndex = 3;
            _Label2.Text = "Amount:";
            //
            // cboChargeType
            //
            _cboChargeType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _cboChargeType.Location = new Point(96, 240);
            _cboChargeType.Name = "cboChargeType";
            _cboChargeType.Size = new Size(232, 21);
            _cboChargeType.TabIndex = 2;
            //
            // Label1
            //
            _Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label1.Location = new Point(8, 240);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(88, 23);
            _Label1.TabIndex = 1;
            _Label1.Text = "Charge Type:";
            //
            // dgCharges
            //
            _dgCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgCharges.DataMember = "";
            _dgCharges.HeaderForeColor = SystemColors.ControlText;
            _dgCharges.Location = new Point(8, 25);
            _dgCharges.Name = "dgCharges";
            _dgCharges.Size = new Size(536, 175);
            _dgCharges.TabIndex = 1;
            //
            // FRMOrderCharges
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(568, 318);
            Controls.Add(_grpCharges);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(576, 352);
            Name = "FRMOrderCharges";
            Text = "Order Charges";
            Controls.SetChildIndex(_grpCharges, 0);
            _grpCharges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgCharges).EndInit();
            ResumeLayout(false);
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