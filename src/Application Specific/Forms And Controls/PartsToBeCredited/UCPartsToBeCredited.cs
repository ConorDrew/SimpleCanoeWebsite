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
    public class UCPartsToBeCredited : UCBase, IUserControl
    {
        

        public UCPartsToBeCredited() : base()
        {
            
            
            base.Load += UCPartsToBeCredited_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call
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

        private GroupBox _PartToBeCredited;

        internal GroupBox PartToBeCredited
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PartToBeCredited;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PartToBeCredited != null)
                {
                }

                _PartToBeCredited = value;
                if (_PartToBeCredited != null)
                {
                }
            }
        }

        private Button _btnFindPart;

        internal Button btnFindPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindPart != null)
                {
                    _btnFindPart.Click -= btnFindPart_Click;
                }

                _btnFindPart = value;
                if (_btnFindPart != null)
                {
                    _btnFindPart.Click += btnFindPart_Click;
                }
            }
        }

        private TextBox _txtPart;

        internal TextBox txtPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPart != null)
                {
                }

                _txtPart = value;
                if (_txtPart != null)
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

        private Button _btnFindSupplier;

        internal Button btnFindSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSupplier != null)
                {
                    _btnFindSupplier.Click -= btnFindSupplier_Click;
                }

                _btnFindSupplier = value;
                if (_btnFindSupplier != null)
                {
                    _btnFindSupplier.Click += btnFindSupplier_Click;
                }
            }
        }

        private TextBox _txtSupplier;

        internal TextBox txtSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplier != null)
                {
                }

                _txtSupplier = value;
                if (_txtSupplier != null)
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

        private Button _btnFindOrder;

        internal Button btnFindOrder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindOrder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindOrder != null)
                {
                    _btnFindOrder.Click -= btnFindOrder_Click;
                }

                _btnFindOrder = value;
                if (_btnFindOrder != null)
                {
                    _btnFindOrder.Click += btnFindOrder_Click;
                }
            }
        }

        private TextBox _txtQty;

        internal TextBox txtQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQty != null)
                {
                }

                _txtQty = value;
                if (_txtQty != null)
                {
                }
            }
        }

        private TextBox _txtOrder;

        internal TextBox txtOrder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOrder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOrder != null)
                {
                }

                _txtOrder = value;
                if (_txtOrder != null)
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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _PartToBeCredited = new GroupBox();
            _btnFindPart = new Button();
            _btnFindPart.Click += new EventHandler(btnFindPart_Click);
            _txtPart = new TextBox();
            _Label4 = new Label();
            _btnFindSupplier = new Button();
            _btnFindSupplier.Click += new EventHandler(btnFindSupplier_Click);
            _txtSupplier = new TextBox();
            _Label3 = new Label();
            _btnFindOrder = new Button();
            _btnFindOrder.Click += new EventHandler(btnFindOrder_Click);
            _txtQty = new TextBox();
            _txtOrder = new TextBox();
            _Label2 = new Label();
            _Label1 = new Label();
            _PartToBeCredited.SuspendLayout();
            SuspendLayout();
            //
            // PartToBeCredited
            //
            _PartToBeCredited.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _PartToBeCredited.Controls.Add(_btnFindPart);
            _PartToBeCredited.Controls.Add(_txtPart);
            _PartToBeCredited.Controls.Add(_Label4);
            _PartToBeCredited.Controls.Add(_btnFindSupplier);
            _PartToBeCredited.Controls.Add(_txtSupplier);
            _PartToBeCredited.Controls.Add(_Label3);
            _PartToBeCredited.Controls.Add(_btnFindOrder);
            _PartToBeCredited.Controls.Add(_txtQty);
            _PartToBeCredited.Controls.Add(_txtOrder);
            _PartToBeCredited.Controls.Add(_Label2);
            _PartToBeCredited.Controls.Add(_Label1);
            _PartToBeCredited.Location = new Point(0, 3);
            _PartToBeCredited.Name = "PartToBeCredited";
            _PartToBeCredited.Size = new Size(548, 147);
            _PartToBeCredited.TabIndex = 0;
            _PartToBeCredited.TabStop = false;
            _PartToBeCredited.Text = "Part To Be Credited";
            //
            // btnFindPart
            //
            _btnFindPart.Location = new Point(465, 82);
            _btnFindPart.Name = "btnFindPart";
            _btnFindPart.Size = new Size(34, 23);
            _btnFindPart.TabIndex = 8;
            _btnFindPart.Text = "...";
            _btnFindPart.UseVisualStyleBackColor = true;
            //
            // txtPart
            //
            _txtPart.Location = new Point(106, 84);
            _txtPart.Name = "txtPart";
            _txtPart.ReadOnly = true;
            _txtPart.Size = new Size(353, 21);
            _txtPart.TabIndex = 7;
            //
            // Label4
            //
            _Label4.AutoSize = true;
            _Label4.Location = new Point(18, 87);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(30, 13);
            _Label4.TabIndex = 6;
            _Label4.Text = "Part";
            //
            // btnFindSupplier
            //
            _btnFindSupplier.Location = new Point(465, 55);
            _btnFindSupplier.Name = "btnFindSupplier";
            _btnFindSupplier.Size = new Size(34, 23);
            _btnFindSupplier.TabIndex = 5;
            _btnFindSupplier.Text = "...";
            _btnFindSupplier.UseVisualStyleBackColor = true;
            //
            // txtSupplier
            //
            _txtSupplier.Location = new Point(106, 57);
            _txtSupplier.Name = "txtSupplier";
            _txtSupplier.ReadOnly = true;
            _txtSupplier.Size = new Size(353, 21);
            _txtSupplier.TabIndex = 4;
            //
            // Label3
            //
            _Label3.AutoSize = true;
            _Label3.Location = new Point(18, 60);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(54, 13);
            _Label3.TabIndex = 3;
            _Label3.Text = "Supplier";
            //
            // btnFindOrder
            //
            _btnFindOrder.Location = new Point(465, 28);
            _btnFindOrder.Name = "btnFindOrder";
            _btnFindOrder.Size = new Size(34, 23);
            _btnFindOrder.TabIndex = 2;
            _btnFindOrder.Text = "...";
            _btnFindOrder.UseVisualStyleBackColor = true;
            //
            // txtQty
            //
            _txtQty.Location = new Point(106, 111);
            _txtQty.Name = "txtQty";
            _txtQty.Size = new Size(100, 21);
            _txtQty.TabIndex = 10;
            //
            // txtOrder
            //
            _txtOrder.Location = new Point(106, 30);
            _txtOrder.Name = "txtOrder";
            _txtOrder.Size = new Size(353, 21);
            _txtOrder.TabIndex = 1;
            //
            // Label2
            //
            _Label2.AutoSize = true;
            _Label2.Location = new Point(18, 114);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(55, 13);
            _Label2.TabIndex = 9;
            _Label2.Text = "Quantity";
            //
            // Label1
            //
            _Label1.AutoSize = true;
            _Label1.Location = new Point(18, 33);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(40, 13);
            _Label1.TabIndex = 0;
            _Label1.Text = "Order";
            //
            // UCPartsToBeCredited
            //
            Controls.Add(_PartToBeCredited);
            Name = "UCPartsToBeCredited";
            Size = new Size(565, 163);
            _PartToBeCredited.ResumeLayout(false);
            _PartToBeCredited.PerformLayout();
            ResumeLayout(false);
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentPartsToBeCredited;
            }
        }

        
        

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.PartsToBeCrediteds.PartsToBeCredited _currentPartsToBeCredited;

        public Entity.PartsToBeCrediteds.PartsToBeCredited CurrentPartsToBeCredited
        {
            get
            {
                return _currentPartsToBeCredited;
            }

            set
            {
                _currentPartsToBeCredited = value;
                if (CurrentPartsToBeCredited is null)
                {
                    _currentPartsToBeCredited = new Entity.PartsToBeCrediteds.PartsToBeCredited();
                    _currentPartsToBeCredited.Exists = false;
                }

                if (CurrentPartsToBeCredited.Exists)
                {
                    Populate();
                }
            }
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
                if (_OrderID > 0)
                {
                    var oOrder = App.DB.Order.Order_Get(OrderID);
                    if (oOrder.Exists)
                    {
                        txtOrder.Text = oOrder.OrderReference;
                        txtOrder.ReadOnly = true;
                        var dr = App.DB.Order.Order_ItemsGetAll(OrderID).Table.Select("SupplierID > 0 ");
                        if (dr.Length > 0)
                        {
                            SupplierID = Conversions.ToInteger(dr[0]["SupplierID"]);
                            btnFindSupplier.Enabled = false;
                        }
                        else
                        {
                            SupplierID = 0;
                            btnFindSupplier.Enabled = true;
                        }
                    }
                }
                else
                {
                    txtOrder.Text = "";
                    txtOrder.ReadOnly = false;
                    SupplierID = 0;
                    btnFindSupplier.Enabled = true;
                }
            }
        }

        private int _SupplierID;

        public int SupplierID
        {
            get
            {
                return _SupplierID;
            }

            set
            {
                _SupplierID = value;
                if (_SupplierID > 0)
                {
                    var oSupplier = App.DB.Supplier.Supplier_Get(_SupplierID);
                    if (oSupplier.Exists)
                    {
                        txtSupplier.Text = oSupplier.Name;
                    }
                }
                else
                {
                    txtSupplier.Text = "";
                }
            }
        }

        private int _PartID = 0;

        private int PartID
        {
            get
            {
                return _PartID;
            }

            set
            {
                _PartID = value;
                if (_PartID > 0)
                {
                    var oPart = App.DB.Part.Part_Get(_PartID);
                    if (oPart is object)
                    {
                        txtPart.Text = oPart.Name + " (" + oPart.Number + ") ";
                    }
                }
                else
                {
                    txtPart.Text = "";
                }
            }
        }

        private void UCPartsToBeCredited_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnFindOrder_Click(object sender, EventArgs e)
        {
            OrderID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblOrder));
        }

        private void btnFindSupplier_Click(object sender, EventArgs e)
        {
            SupplierID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSupplier));
        }

        private void btnFindPart_Click(object sender, EventArgs e)
        {
            FindPart();
        }

        
        

        private void FindPart(string PartNumber = "")
        {
            PartID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblPart, OrderID, PartNumber));
            if (PartID > 0)
            {
                if (SupplierID > 0)
                {
                    if (App.DB.PartSupplier.PartSupplierPacks_Get(PartID, SupplierID).Table.Rows.Count == 0)
                    {
                        App.ShowMessage("This part is not supplied by the choosen supplier.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string foundPartNumber = App.DB.Part.Part_Get(PartID).Number;
                        PartID = 0;
                        FindPart(foundPartNumber);
                    }
                }
            }
        }

        public void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentPartsToBeCredited = App.DB.PartsToBeCredited.PartsToBeCredited_Get(ID);
            }

            OrderID = CurrentPartsToBeCredited.OrderID;
            SupplierID = CurrentPartsToBeCredited.SupplierID;
            PartID = CurrentPartsToBeCredited.PartID;
            txtOrder.Text = CurrentPartsToBeCredited.OrderReference;
            txtQty.Text = CurrentPartsToBeCredited.Qty.ToString();
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                bool keepFormOpenAsNew = false;
                CurrentPartsToBeCredited.IgnoreExceptionsOnSetMethods = true;
                CurrentPartsToBeCredited.SetOrderID = OrderID;
                CurrentPartsToBeCredited.SetSupplierID = SupplierID;
                CurrentPartsToBeCredited.SetPartID = PartID;
                CurrentPartsToBeCredited.SetQty = txtQty.Text.Trim();
                CurrentPartsToBeCredited.SetStatusID = Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return);
                CurrentPartsToBeCredited.SetManuallyAdded = true;
                CurrentPartsToBeCredited.SetOrderReference = txtOrder.Text;
                var cV = new Entity.PartsToBeCrediteds.PartsToBeCreditedValidator();
                cV.Validate(CurrentPartsToBeCredited);
                if (CurrentPartsToBeCredited.Exists)
                {
                    App.DB.PartsToBeCredited.Update(CurrentPartsToBeCredited);
                }
                else
                {
                    CurrentPartsToBeCredited = App.DB.PartsToBeCredited.Insert(CurrentPartsToBeCredited);
                    keepFormOpenAsNew = true;
                }

                if (keepFormOpenAsNew)
                {
                    CurrentPartsToBeCredited = new Entity.PartsToBeCrediteds.PartsToBeCredited();
                    PartID = 0;
                    txtQty.Text = "";
                    StateChanged?.Invoke(0);
                }
                else
                {
                    StateChanged?.Invoke(CurrentPartsToBeCredited.PartsToBeCreditedID);
                }

                App.ShowMessage("Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        
    }
}