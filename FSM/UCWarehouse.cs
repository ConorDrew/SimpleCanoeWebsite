// Decompiled with JetBrains decompiler
// Type: FSM.UCWarehouse
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using FSM.Entity.Warehouses;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCWarehouse : UCBase, IUserControl
    {
        private IContainer components;
        private DataView m_dTable;
        private DataView m_dTable2;
        private Warehouse _currentWarehouse;
        private DataView _VansDataView;
        private DataGrid _dgVans;
        private DataGrid _dgParts;

        public UCWarehouse()
        {
            this.Load += new EventHandler(this.UCWarehouse_Load);
            this.m_dTable = (DataView)null;
            this.m_dTable2 = (DataView)null;
            this._VansDataView = (DataView)null;
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        internal virtual TabControl tcWarehouse { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TabPage tabStock { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual GroupBox grpWarehouse { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtSize { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblSize { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtAddress4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblAddress4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtAddress5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblAddress5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual CheckBox chkActive { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual DataGrid dgProducts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual TabPage tpVans { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual GroupBox grpVans { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

        internal virtual DataGrid dgVans
        {
            get
            {
                return this._dgVans;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgVans_MouseUp);
                DataGrid dgVans1 = this._dgVans;
                if (dgVans1 != null)
                    dgVans1.MouseUp -= mouseEventHandler;
                this._dgVans = value;
                DataGrid dgVans2 = this._dgVans;
                if (dgVans2 == null)
                    return;
                dgVans2.MouseUp += mouseEventHandler;
            }
        }

        internal virtual DataGrid dgParts
        {
            get
            {
                return this._dgParts;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.dgParts_DoubleClick);
                DataGrid dgParts1 = this._dgParts;
                if (dgParts1 != null)
                    dgParts1.DoubleClick -= eventHandler;
                this._dgParts = value;
                DataGrid dgParts2 = this._dgParts;
                if (dgParts2 == null)
                    return;
                dgParts2.DoubleClick += eventHandler;
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.tcWarehouse = new TabControl();
            this.tabDetails = new TabPage();
            this.grpWarehouse = new GroupBox();
            this.txtName = new TextBox();
            this.lblName = new Label();
            this.txtSize = new TextBox();
            this.lblSize = new Label();
            this.txtNotes = new TextBox();
            this.lblNotes = new Label();
            this.txtAddress1 = new TextBox();
            this.lblAddress1 = new Label();
            this.txtAddress2 = new TextBox();
            this.lblAddress2 = new Label();
            this.txtAddress3 = new TextBox();
            this.lblAddress3 = new Label();
            this.txtAddress4 = new TextBox();
            this.lblAddress4 = new Label();
            this.txtAddress5 = new TextBox();
            this.lblAddress5 = new Label();
            this.txtPostcode = new TextBox();
            this.lblPostcode = new Label();
            this.txtTelephoneNum = new TextBox();
            this.lblTelephoneNum = new Label();
            this.txtFaxNum = new TextBox();
            this.lblFaxNum = new Label();
            this.txtEmailAddress = new TextBox();
            this.lblEmailAddress = new Label();
            this.chkActive = new CheckBox();
            this.tabStock = new TabPage();
            this.GroupBox2 = new GroupBox();
            this.dgParts = new DataGrid();
            this.GroupBox1 = new GroupBox();
            this.dgProducts = new DataGrid();
            this.tpVans = new TabPage();
            this.grpVans = new GroupBox();
            this.dgVans = new DataGrid();
            this.tcWarehouse.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.grpWarehouse.SuspendLayout();
            this.tabStock.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.dgParts.BeginInit();
            this.GroupBox1.SuspendLayout();
            this.dgProducts.BeginInit();
            this.tpVans.SuspendLayout();
            this.grpVans.SuspendLayout();
            this.dgVans.BeginInit();
            this.SuspendLayout();
            this.tcWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tcWarehouse.Controls.Add((Control)this.tabDetails);
            this.tcWarehouse.Controls.Add((Control)this.tabStock);
            this.tcWarehouse.Controls.Add((Control)this.tpVans);
            this.tcWarehouse.Location = new System.Drawing.Point(3, 8);
            this.tcWarehouse.Name = "tcWarehouse";
            this.tcWarehouse.SelectedIndex = 0;
            this.tcWarehouse.Size = new Size(710, 591);
            this.tcWarehouse.TabIndex = 0;
            this.tabDetails.Controls.Add((Control)this.grpWarehouse);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Size = new Size(702, 565);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "Main Details";
            this.grpWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.grpWarehouse.Controls.Add((Control)this.txtName);
            this.grpWarehouse.Controls.Add((Control)this.lblName);
            this.grpWarehouse.Controls.Add((Control)this.txtSize);
            this.grpWarehouse.Controls.Add((Control)this.lblSize);
            this.grpWarehouse.Controls.Add((Control)this.txtNotes);
            this.grpWarehouse.Controls.Add((Control)this.lblNotes);
            this.grpWarehouse.Controls.Add((Control)this.txtAddress1);
            this.grpWarehouse.Controls.Add((Control)this.lblAddress1);
            this.grpWarehouse.Controls.Add((Control)this.txtAddress2);
            this.grpWarehouse.Controls.Add((Control)this.lblAddress2);
            this.grpWarehouse.Controls.Add((Control)this.txtAddress3);
            this.grpWarehouse.Controls.Add((Control)this.lblAddress3);
            this.grpWarehouse.Controls.Add((Control)this.txtAddress4);
            this.grpWarehouse.Controls.Add((Control)this.lblAddress4);
            this.grpWarehouse.Controls.Add((Control)this.txtAddress5);
            this.grpWarehouse.Controls.Add((Control)this.lblAddress5);
            this.grpWarehouse.Controls.Add((Control)this.txtPostcode);
            this.grpWarehouse.Controls.Add((Control)this.lblPostcode);
            this.grpWarehouse.Controls.Add((Control)this.txtTelephoneNum);
            this.grpWarehouse.Controls.Add((Control)this.lblTelephoneNum);
            this.grpWarehouse.Controls.Add((Control)this.txtFaxNum);
            this.grpWarehouse.Controls.Add((Control)this.lblFaxNum);
            this.grpWarehouse.Controls.Add((Control)this.txtEmailAddress);
            this.grpWarehouse.Controls.Add((Control)this.lblEmailAddress);
            this.grpWarehouse.Controls.Add((Control)this.chkActive);
            this.grpWarehouse.Location = new System.Drawing.Point(8, 8);
            this.grpWarehouse.Name = "grpWarehouse";
            this.grpWarehouse.Size = new Size(683, 553);
            this.grpWarehouse.TabIndex = 2;
            this.grpWarehouse.TabStop = false;
            this.grpWarehouse.Text = "Main Details";
            this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtName.Location = new System.Drawing.Point(120, 24);
            this.txtName.MaxLength = (int)byte.MaxValue;
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(482, 21);
            this.txtName.TabIndex = 1;
            this.txtName.Tag = (object)"Warehouse.Name";
            this.lblName.Location = new System.Drawing.Point(8, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(104, 20);
            this.lblName.TabIndex = 31;
            this.lblName.Text = "Name";
            this.txtSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtSize.Location = new System.Drawing.Point(120, 58);
            this.txtSize.MaxLength = (int)byte.MaxValue;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new Size(554, 21);
            this.txtSize.TabIndex = 3;
            this.txtSize.Tag = (object)"Warehouse.Size";
            this.lblSize.Location = new System.Drawing.Point(8, 56);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new Size(104, 20);
            this.lblSize.TabIndex = 31;
            this.lblSize.Text = "Size";
            this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.txtNotes.Location = new System.Drawing.Point(120, 378);
            this.txtNotes.MaxLength = 0;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = ScrollBars.Vertical;
            this.txtNotes.Size = new Size(554, 168);
            this.txtNotes.TabIndex = 13;
            this.txtNotes.Tag = (object)"Warehouse.Notes";
            this.lblNotes.Location = new System.Drawing.Point(8, 376);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new Size(104, 20);
            this.lblNotes.TabIndex = 31;
            this.lblNotes.Text = "Notes";
            this.txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtAddress1.Location = new System.Drawing.Point(120, 90);
            this.txtAddress1.MaxLength = (int)byte.MaxValue;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new Size(554, 21);
            this.txtAddress1.TabIndex = 4;
            this.txtAddress1.Tag = (object)"Warehouse.Address1";
            this.lblAddress1.Location = new System.Drawing.Point(8, 88);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new Size(104, 20);
            this.lblAddress1.TabIndex = 31;
            this.lblAddress1.Text = "Address 1";
            this.txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtAddress2.Location = new System.Drawing.Point(120, 122);
            this.txtAddress2.MaxLength = (int)byte.MaxValue;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new Size(554, 21);
            this.txtAddress2.TabIndex = 5;
            this.txtAddress2.Tag = (object)"Warehouse.Address2";
            this.lblAddress2.Location = new System.Drawing.Point(8, 120);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new Size(104, 20);
            this.lblAddress2.TabIndex = 31;
            this.lblAddress2.Text = "Address 2";
            this.txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtAddress3.Location = new System.Drawing.Point(120, 154);
            this.txtAddress3.MaxLength = (int)byte.MaxValue;
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new Size(554, 21);
            this.txtAddress3.TabIndex = 6;
            this.txtAddress3.Tag = (object)"Warehouse.Address3";
            this.lblAddress3.Location = new System.Drawing.Point(8, 152);
            this.lblAddress3.Name = "lblAddress3";
            this.lblAddress3.Size = new Size(104, 20);
            this.lblAddress3.TabIndex = 31;
            this.lblAddress3.Text = "Address 3";
            this.txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtAddress4.Location = new System.Drawing.Point(120, 186);
            this.txtAddress4.MaxLength = (int)byte.MaxValue;
            this.txtAddress4.Name = "txtAddress4";
            this.txtAddress4.Size = new Size(554, 21);
            this.txtAddress4.TabIndex = 7;
            this.txtAddress4.Tag = (object)"Warehouse.Address4";
            this.lblAddress4.Location = new System.Drawing.Point(8, 184);
            this.lblAddress4.Name = "lblAddress4";
            this.lblAddress4.Size = new Size(104, 20);
            this.lblAddress4.TabIndex = 31;
            this.lblAddress4.Text = "Address 4";
            this.txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtAddress5.Location = new System.Drawing.Point(120, 218);
            this.txtAddress5.MaxLength = (int)byte.MaxValue;
            this.txtAddress5.Name = "txtAddress5";
            this.txtAddress5.Size = new Size(554, 21);
            this.txtAddress5.TabIndex = 8;
            this.txtAddress5.Tag = (object)"Warehouse.Address5";
            this.lblAddress5.Location = new System.Drawing.Point(8, 216);
            this.lblAddress5.Name = "lblAddress5";
            this.lblAddress5.Size = new Size(104, 20);
            this.lblAddress5.TabIndex = 31;
            this.lblAddress5.Text = "Address 5";
            this.txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtPostcode.Location = new System.Drawing.Point(120, 250);
            this.txtPostcode.MaxLength = 10;
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new Size(554, 21);
            this.txtPostcode.TabIndex = 9;
            this.txtPostcode.Tag = (object)"Warehouse.Postcode";
            this.lblPostcode.Location = new System.Drawing.Point(8, 248);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new Size(104, 20);
            this.lblPostcode.TabIndex = 31;
            this.lblPostcode.Text = "Postcode";
            this.txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtTelephoneNum.Location = new System.Drawing.Point(120, 282);
            this.txtTelephoneNum.MaxLength = 20;
            this.txtTelephoneNum.Name = "txtTelephoneNum";
            this.txtTelephoneNum.Size = new Size(554, 21);
            this.txtTelephoneNum.TabIndex = 10;
            this.txtTelephoneNum.Tag = (object)"Warehouse.TelephoneNum";
            this.lblTelephoneNum.Location = new System.Drawing.Point(8, 280);
            this.lblTelephoneNum.Name = "lblTelephoneNum";
            this.lblTelephoneNum.Size = new Size(104, 20);
            this.lblTelephoneNum.TabIndex = 31;
            this.lblTelephoneNum.Text = "Telephone";
            this.txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtFaxNum.Location = new System.Drawing.Point(120, 314);
            this.txtFaxNum.MaxLength = 20;
            this.txtFaxNum.Name = "txtFaxNum";
            this.txtFaxNum.Size = new Size(554, 21);
            this.txtFaxNum.TabIndex = 11;
            this.txtFaxNum.Tag = (object)"Warehouse.FaxNum";
            this.lblFaxNum.Location = new System.Drawing.Point(8, 312);
            this.lblFaxNum.Name = "lblFaxNum";
            this.lblFaxNum.Size = new Size(104, 20);
            this.lblFaxNum.TabIndex = 31;
            this.lblFaxNum.Text = "Fax";
            this.txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtEmailAddress.Location = new System.Drawing.Point(120, 346);
            this.txtEmailAddress.MaxLength = (int)byte.MaxValue;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new Size(554, 21);
            this.txtEmailAddress.TabIndex = 12;
            this.txtEmailAddress.Tag = (object)"Warehouse.EmailAddress";
            this.lblEmailAddress.Location = new System.Drawing.Point(8, 344);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new Size(104, 20);
            this.lblEmailAddress.TabIndex = 31;
            this.lblEmailAddress.Text = "Email Address";
            this.chkActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.chkActive.Font = new Font("Verdana", 8f);
            this.chkActive.Location = new System.Drawing.Point(610, 26);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new Size(64, 18);
            this.chkActive.TabIndex = 2;
            this.chkActive.Tag = (object)"Warehouse.Active";
            this.chkActive.Text = "Active";
            this.tabStock.Controls.Add((Control)this.GroupBox2);
            this.tabStock.Controls.Add((Control)this.GroupBox1);
            this.tabStock.Location = new System.Drawing.Point(4, 22);
            this.tabStock.Name = "tabStock";
            this.tabStock.Size = new Size(702, 565);
            this.tabStock.TabIndex = 1;
            this.tabStock.Text = "Stock";
            this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.GroupBox2.Controls.Add((Control)this.dgParts);
            this.GroupBox2.Location = new System.Drawing.Point(8, 216);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new Size(683, 338);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Parts held in warehouse";
            this.dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgParts.DataMember = "";
            this.dgParts.HeaderForeColor = SystemColors.ControlText;
            this.dgParts.Location = new System.Drawing.Point(8, 26);
            this.dgParts.Name = "dgParts";
            this.dgParts.Size = new Size(667, 304);
            this.dgParts.TabIndex = 2;
            this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.GroupBox1.Controls.Add((Control)this.dgProducts);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new Size(683, 200);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Products held in warehouse";
            this.dgProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgProducts.DataMember = "";
            this.dgProducts.HeaderForeColor = SystemColors.ControlText;
            this.dgProducts.Location = new System.Drawing.Point(8, 26);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new Size(667, 166);
            this.dgProducts.TabIndex = 1;
            this.tpVans.Controls.Add((Control)this.grpVans);
            this.tpVans.Location = new System.Drawing.Point(4, 22);
            this.tpVans.Name = "tpVans";
            this.tpVans.Padding = new Padding(3);
            this.tpVans.Size = new Size(702, 565);
            this.tpVans.TabIndex = 2;
            this.tpVans.Text = "Vans";
            this.tpVans.UseVisualStyleBackColor = true;
            this.grpVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.grpVans.Controls.Add((Control)this.dgVans);
            this.grpVans.Location = new System.Drawing.Point(6, 3);
            this.grpVans.Name = "grpVans";
            this.grpVans.Size = new Size(690, 549);
            this.grpVans.TabIndex = 4;
            this.grpVans.TabStop = false;
            this.grpVans.Text = "Tick those vans for this warehouse";
            this.dgVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgVans.DataMember = "";
            this.dgVans.HeaderForeColor = SystemColors.ControlText;
            this.dgVans.Location = new System.Drawing.Point(6, 20);
            this.dgVans.Name = "dgVans";
            this.dgVans.Size = new Size(678, 523);
            this.dgVans.TabIndex = 2;
            this.Controls.Add((Control)this.tcWarehouse);
            this.Name = nameof(UCWarehouse);
            this.Size = new Size(723, 604);
            this.tcWarehouse.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.grpWarehouse.ResumeLayout(false);
            this.grpWarehouse.PerformLayout();
            this.tabStock.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.dgParts.EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.dgProducts.EndInit();
            this.tpVans.ResumeLayout(false);
            this.grpVans.ResumeLayout(false);
            this.dgVans.EndInit();
            this.ResumeLayout(false);
        }

        void IUserControl.LoadForm(object sender, EventArgs e)
        {
            this.LoadBaseControl((Control)this);
            this.SetupPartsDatagrid();
            this.SetupProductsDatagrid();
            this.SetupVansDatagrid();
        }

        public object LoadedItem
        {
            get
            {
                return (object)this.CurrentWarehouse;
            }
        }

        public DataView ProductsDataView
        {
            get
            {
                return this.m_dTable;
            }
            set
            {
                this.m_dTable = value;
                this.m_dTable.Table.TableName = Enums.TableNames.tblProduct.ToString();
                this.m_dTable.AllowNew = false;
                this.m_dTable.AllowEdit = false;
                this.m_dTable.AllowDelete = false;
                this.dgProducts.DataSource = (object)this.ProductsDataView;
            }
        }

        private DataRow SelectedProductDataRow
        {
            get
            {
                return this.dgProducts.CurrentRowIndex != -1 ? this.ProductsDataView[this.dgProducts.CurrentRowIndex].Row : (DataRow)null;
            }
        }

        public DataView PartsDataView
        {
            get
            {
                return this.m_dTable2;
            }
            set
            {
                this.m_dTable2 = value;
                this.m_dTable2.Table.TableName = Enums.TableNames.tblPart.ToString();
                this.m_dTable2.AllowNew = false;
                this.m_dTable2.AllowEdit = false;
                this.m_dTable2.AllowDelete = false;
                this.dgParts.DataSource = (object)this.PartsDataView;
            }
        }

        private DataRow SelectedPartDataRow
        {
            get
            {
                return this.dgParts.CurrentRowIndex != -1 ? this.PartsDataView[this.dgParts.CurrentRowIndex].Row : (DataRow)null;
            }
        }

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public event IUserControl.StateChangedEventHandler StateChanged;

        private readonly IUserControl userControl;

        public Warehouse CurrentWarehouse
        {
            get
            {
                return this._currentWarehouse;
            }
            set
            {
                this._currentWarehouse = value;
                if (this.CurrentWarehouse == null)
                {
                    this.CurrentWarehouse = new Warehouse();
                    this.CurrentWarehouse.Exists = false;
                }
                if (this.CurrentWarehouse.Exists)
                    userControl.Populate(0);
                else
                    this.VansDataView = App.DB.Van.Van_GetAll_For_Warehouse(0);
            }
        }

        public DataView VansDataView
        {
            get
            {
                return this._VansDataView;
            }
            set
            {
                this._VansDataView = value;
                this._VansDataView.Table.TableName = Enums.TableNames.tblVan.ToString();
                this._VansDataView.AllowNew = false;
                this._VansDataView.AllowEdit = false;
                this._VansDataView.AllowDelete = false;
                this.dgVans.DataSource = (object)this.VansDataView;
            }
        }

        private DataRow SelectedVanDataRow
        {
            get
            {
                return this.dgVans.CurrentRowIndex != -1 ? this.VansDataView[this.dgVans.CurrentRowIndex].Row : (DataRow)null;
            }
        }

        public IUserControl.RecordsChangedEventHandler RecordsChangedEvent { get; private set; }
        public IUserControl.StateChangedEventHandler StateChangedEvent { get; private set; }

        public void SetupProductsDatagrid()
        {
            Helper.SetUpDataGrid(this.dgProducts, false);
            DataGridTableStyle tableStyle = this.dgProducts.TableStyles[0];
            tableStyle.GridColumnStyles.Clear();
            DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
            dataGridLabelColumn1.Format = "";
            dataGridLabelColumn1.FormatInfo = (IFormatProvider)null;
            dataGridLabelColumn1.HeaderText = "Description";
            dataGridLabelColumn1.MappingName = "typemakemodel";
            dataGridLabelColumn1.ReadOnly = true;
            dataGridLabelColumn1.Width = 180;
            dataGridLabelColumn1.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridLabelColumn1);
            DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
            dataGridLabelColumn2.Format = "";
            dataGridLabelColumn2.FormatInfo = (IFormatProvider)null;
            dataGridLabelColumn2.HeaderText = "GC Number";
            dataGridLabelColumn2.MappingName = "ProductNumber";
            dataGridLabelColumn2.ReadOnly = true;
            dataGridLabelColumn2.Width = 140;
            dataGridLabelColumn2.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridLabelColumn2);
            DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
            dataGridLabelColumn3.Format = "";
            dataGridLabelColumn3.FormatInfo = (IFormatProvider)null;
            dataGridLabelColumn3.HeaderText = "Product Reference";
            dataGridLabelColumn3.MappingName = "Reference";
            dataGridLabelColumn3.ReadOnly = true;
            dataGridLabelColumn3.Width = 200;
            dataGridLabelColumn3.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridLabelColumn3);
            DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
            dataGridLabelColumn4.Format = "";
            dataGridLabelColumn4.FormatInfo = (IFormatProvider)null;
            dataGridLabelColumn4.HeaderText = "Amount";
            dataGridLabelColumn4.MappingName = "Amount";
            dataGridLabelColumn4.ReadOnly = true;
            dataGridLabelColumn4.Width = 120;
            dataGridLabelColumn4.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridLabelColumn4);
            tableStyle.ReadOnly = true;
            tableStyle.MappingName = Enums.TableNames.tblProduct.ToString();
            this.dgProducts.TableStyles.Add(tableStyle);
        }

        public void SetupPartsDatagrid()
        {
            Helper.SetUpDataGrid(this.dgParts, false);
            DataGridTableStyle tableStyle = this.dgParts.TableStyles[0];
            tableStyle.GridColumnStyles.Clear();
            DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
            dataGridLabelColumn1.Format = "";
            dataGridLabelColumn1.FormatInfo = (IFormatProvider)null;
            dataGridLabelColumn1.HeaderText = "Part Name";
            dataGridLabelColumn1.MappingName = "PartName";
            dataGridLabelColumn1.ReadOnly = true;
            dataGridLabelColumn1.Width = 180;
            dataGridLabelColumn1.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridLabelColumn1);
            DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
            dataGridLabelColumn2.Format = "";
            dataGridLabelColumn2.FormatInfo = (IFormatProvider)null;
            dataGridLabelColumn2.HeaderText = "Part Number";
            dataGridLabelColumn2.MappingName = "PartNumber";
            dataGridLabelColumn2.ReadOnly = true;
            dataGridLabelColumn2.Width = 70;
            dataGridLabelColumn2.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridLabelColumn2);
            DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
            dataGridLabelColumn3.Format = "";
            dataGridLabelColumn3.FormatInfo = (IFormatProvider)null;
            dataGridLabelColumn3.HeaderText = "Part Reference";
            dataGridLabelColumn3.MappingName = "Reference";
            dataGridLabelColumn3.ReadOnly = true;
            dataGridLabelColumn3.Width = 100;
            dataGridLabelColumn3.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridLabelColumn3);
            DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
            dataGridLabelColumn4.Format = "";
            dataGridLabelColumn4.FormatInfo = (IFormatProvider)null;
            dataGridLabelColumn4.HeaderText = "Amount";
            dataGridLabelColumn4.MappingName = "Amount";
            dataGridLabelColumn4.ReadOnly = true;
            dataGridLabelColumn4.Width = 120;
            dataGridLabelColumn4.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridLabelColumn4);
            tableStyle.ReadOnly = true;
            tableStyle.MappingName = Enums.TableNames.tblPart.ToString();
            this.dgParts.TableStyles.Add(tableStyle);
        }

        public void SetupVansDatagrid()
        {
            Helper.SetUpDataGrid(this.dgVans, false);
            DataGridTableStyle tableStyle = this.dgVans.TableStyles[0];
            tableStyle.GridColumnStyles.Clear();
            tableStyle.ReadOnly = false;
            tableStyle.AllowSorting = false;
            this.dgVans.ReadOnly = false;
            this.dgVans.AllowSorting = false;
            DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
            dataGridBoolColumn.HeaderText = "";
            dataGridBoolColumn.MappingName = "Tick";
            dataGridBoolColumn.ReadOnly = true;
            dataGridBoolColumn.Width = 25;
            dataGridBoolColumn.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridBoolColumn);
            DataGridLabelColumn dataGridLabelColumn = new DataGridLabelColumn();
            dataGridLabelColumn.Format = "";
            dataGridLabelColumn.FormatInfo = (IFormatProvider)null;
            dataGridLabelColumn.HeaderText = "Registration";
            dataGridLabelColumn.MappingName = "Registration";
            dataGridLabelColumn.ReadOnly = true;
            dataGridLabelColumn.Width = 300;
            dataGridLabelColumn.NullText = "";
            tableStyle.GridColumnStyles.Add((DataGridColumnStyle)dataGridLabelColumn);
            tableStyle.MappingName = Enums.TableNames.tblVan.ToString();
            this.dgVans.TableStyles.Add(tableStyle);
        }

        private void UCWarehouse_Load(object sender, EventArgs e)
        {
            userControl.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void dgParts_DoubleClick(object sender, EventArgs e)
        {
            if (this.SelectedPartDataRow == null)
                return;
            App.ShowForm(typeof(FRMPart), true, new object[2]
            {
        this.SelectedPartDataRow["PartID"],
        (object) true
            }, false);
            this.PartsDataView = App.DB.PartTransaction.GetByWarehouse(this.CurrentWarehouse.WarehouseID, false);
        }

        private void dgVans_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo hitTestInfo = this.dgVans.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
                    this.dgVans.CurrentRowIndex = hitTestInfo.Row;
                if ((uint)hitTestInfo.Column > 0U || this.SelectedVanDataRow == null)
                    return;
                bool flag = !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.dgVans[this.dgVans.CurrentRowIndex, 0]));
                if (!flag && Conversions.ToBoolean(this.SelectedVanDataRow["HasStock"]))
                {
                    int num = (int)App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)"'", this.SelectedVanDataRow["Name"]), (object)"' on this van has stock so cannot be unselected")), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    this.dgVans[this.dgVans.CurrentRowIndex, 0] = (object)flag;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
        }

        void IUserControl.Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if ((uint)ID > 0U)
                this.CurrentWarehouse = App.DB.Warehouse.Warehouse_Get(ID);
            this.ProductsDataView = App.DB.ProductTransaction.GetByWarehouse(this.CurrentWarehouse.WarehouseID);
            this.PartsDataView = App.DB.PartTransaction.GetByWarehouse(this.CurrentWarehouse.WarehouseID, false);
            this.VansDataView = App.DB.Van.Van_GetAll_For_Warehouse(this.CurrentWarehouse.WarehouseID);
            this.txtName.Text = this.CurrentWarehouse.Name;
            this.txtSize.Text = this.CurrentWarehouse.Size;
            this.txtNotes.Text = this.CurrentWarehouse.Notes;
            this.txtAddress1.Text = this.CurrentWarehouse.Address1;
            this.txtAddress2.Text = this.CurrentWarehouse.Address2;
            this.txtAddress3.Text = this.CurrentWarehouse.Address3;
            this.txtAddress4.Text = this.CurrentWarehouse.Address4;
            this.txtAddress5.Text = this.CurrentWarehouse.Address5;
            this.txtPostcode.Text = this.CurrentWarehouse.Postcode;
            this.txtTelephoneNum.Text = this.CurrentWarehouse.TelephoneNum;
            this.txtFaxNum.Text = this.CurrentWarehouse.FaxNum;
            this.txtEmailAddress.Text = this.CurrentWarehouse.EmailAddress;
            this.chkActive.Checked = this.CurrentWarehouse.Active;
            App.AddChangeHandlers((Control)this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            bool flag;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.CurrentWarehouse.IgnoreExceptionsOnSetMethods = true;
                this.CurrentWarehouse.SetName = (object)this.txtName.Text.Trim();
                this.CurrentWarehouse.SetSize = (object)this.txtSize.Text.Trim();
                this.CurrentWarehouse.SetNotes = (object)this.txtNotes.Text.Trim();
                this.CurrentWarehouse.SetAddress1 = (object)this.txtAddress1.Text.Trim();
                this.CurrentWarehouse.SetAddress2 = (object)this.txtAddress2.Text.Trim();
                this.CurrentWarehouse.SetAddress3 = (object)this.txtAddress3.Text.Trim();
                this.CurrentWarehouse.SetAddress4 = (object)this.txtAddress4.Text.Trim();
                this.CurrentWarehouse.SetAddress5 = (object)this.txtAddress5.Text.Trim();
                this.CurrentWarehouse.SetPostcode = (object)this.txtPostcode.Text.Trim();
                this.CurrentWarehouse.SetTelephoneNum = (object)this.txtTelephoneNum.Text.Trim();
                this.CurrentWarehouse.SetFaxNum = (object)this.txtFaxNum.Text.Trim();
                this.CurrentWarehouse.SetEmailAddress = (object)this.txtEmailAddress.Text.Trim();
                this.CurrentWarehouse.SetActive = (object)this.chkActive.Checked;
                new WarehouseValidator().Validate(this.CurrentWarehouse);
                if (this.CurrentWarehouse.Exists)
                    App.DB.Warehouse.Update(this.CurrentWarehouse, this.VansDataView);
                else
                    this.CurrentWarehouse = App.DB.Warehouse.Insert(this.CurrentWarehouse, this.VansDataView);
                // ISSUE: reference to a compiler-generated field
                IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
                if (recordsChangedEvent != null)
                    recordsChangedEvent(App.DB.Warehouse.Warehouse_GetAll(), Enums.PageViewing.Warehouse, true, false, "");
                // ISSUE: reference to a compiler-generated field
                IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
                if (stateChangedEvent != null)
                    stateChangedEvent(this.CurrentWarehouse.WarehouseID);
                App.MainForm.RefreshEntity(this.CurrentWarehouse.WarehouseID, "");
                flag = true;
            }
            catch (ValidationException ex)
            {
                ProjectData.SetProjectError((Exception)ex);
                int num = (int)App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object)"\r\n", (object)ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = false;
                ProjectData.ClearProjectError();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
                ProjectData.ClearProjectError();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return flag;
        }
    }
}