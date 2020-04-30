using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMPartsInvoiceImport : FRMBaseForm
    {
        

        public FRMPartsInvoiceImport() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboValidateType;
            Combo.SetUpCombo(ref argc, DynamicDataTables.PartsInvoiceImportValidationResults, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            if (!((App.loggedInUser.Fullname ?? "") == "Hayleigh Mann"))
            {
                Button1.Visible = false;
            }
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
        private GroupBox _grpExcelFile;

        internal GroupBox grpExcelFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpExcelFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpExcelFile != null)
                {
                }

                _grpExcelFile = value;
                if (_grpExcelFile != null)
                {
                }
            }
        }

        private TabControl _tcData;

        internal TabControl tcData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcData != null)
                {
                }

                _tcData = value;
                if (_tcData != null)
                {
                }
            }
        }

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        private ProgressBar _pbStatus;

        internal ProgressBar pbStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbStatus != null)
                {
                }

                _pbStatus = value;
                if (_pbStatus != null)
                {
                }
            }
        }

        private Label _lblMessages;

        internal Label lblMessages
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMessages;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMessages != null)
                {
                }

                _lblMessages = value;
                if (_lblMessages != null)
                {
                }
            }
        }

        private LinkLabel _btnExportParts;

        internal LinkLabel btnExportParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExportParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExportParts != null)
                {
                }

                _btnExportParts = value;
                if (_btnExportParts != null)
                {
                }
            }
        }

        private Button _btnCheckFiles;

        internal Button btnCheckFiles
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCheckFiles;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCheckFiles != null)
                {
                    _btnCheckFiles.Click -= btnCheckFiles_Click;
                }

                _btnCheckFiles = value;
                if (_btnCheckFiles != null)
                {
                    _btnCheckFiles.Click += btnCheckFiles_Click;
                }
            }
        }

        private LinkLabel _llOpenFolder;

        internal LinkLabel llOpenFolder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _llOpenFolder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_llOpenFolder != null)
                {
                    _llOpenFolder.LinkClicked -= llOpenFolder_LinkClicked;
                }

                _llOpenFolder = value;
                if (_llOpenFolder != null)
                {
                    _llOpenFolder.LinkClicked += llOpenFolder_LinkClicked;
                }
            }
        }

        private Button _btnExportResults;

        internal Button btnExportResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExportResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExportResults != null)
                {
                    _btnExportResults.Click -= btnExportResults_Click;
                }

                _btnExportResults = value;
                if (_btnExportResults != null)
                {
                    _btnExportResults.Click += btnExportResults_Click;
                }
            }
        }

        private ComboBox _cboValidateType;

        internal ComboBox cboValidateType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboValidateType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboValidateType != null)
                {
                    
                    
                    _cboValidateType.SelectedIndexChanged -= cboValidateType_SelectedIndexChanged;
                }

                _cboValidateType = value;
                if (_cboValidateType != null)
                {
                    _cboValidateType.SelectedIndexChanged += cboValidateType_SelectedIndexChanged;
                }
            }
        }

        private Button _btnProcessIndiv;

        internal Button btnProcessIndiv
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnProcessIndiv;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnProcessIndiv != null)
                {
                    _btnProcessIndiv.Click -= btnProcessIndiv_Click;
                }

                _btnProcessIndiv = value;
                if (_btnProcessIndiv != null)
                {
                    _btnProcessIndiv.Click += btnProcessIndiv_Click;
                }
            }
        }

        private GroupBox _grpCatImport;

        internal GroupBox grpCatImport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCatImport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCatImport != null)
                {
                }

                _grpCatImport = value;
                if (_grpCatImport != null)
                {
                }
            }
        }

        private Button _btnValidateResults;

        internal Button btnValidateResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnValidateResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnValidateResults != null)
                {
                    _btnValidateResults.Click -= btnValidateResults_Click;
                }

                _btnValidateResults = value;
                if (_btnValidateResults != null)
                {
                    _btnValidateResults.Click += btnValidateResults_Click;
                }
            }
        }

        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        private Label _lblProgress;

        internal Label lblProgress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProgress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProgress != null)
                {
                }

                _lblProgress = value;
                if (_lblProgress != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpExcelFile = new GroupBox();
            _btnExportResults = new Button();
            _btnExportResults.Click += new EventHandler(btnExportResults_Click);
            _btnCheckFiles = new Button();
            _btnCheckFiles.Click += new EventHandler(btnCheckFiles_Click);
            _tcData = new TabControl();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _pbStatus = new ProgressBar();
            _lblProgress = new Label();
            _lblMessages = new Label();
            _btnExportParts = new LinkLabel();
            _llOpenFolder = new LinkLabel();
            _llOpenFolder.LinkClicked += new LinkLabelLinkClickedEventHandler(llOpenFolder_LinkClicked);
            _cboValidateType = new ComboBox();
            _cboValidateType.SelectedIndexChanged += new EventHandler(cboValidateType_SelectedIndexChanged);
            _btnProcessIndiv = new Button();
            _btnProcessIndiv.Click += new EventHandler(btnProcessIndiv_Click);
            _grpCatImport = new GroupBox();
            _btnValidateResults = new Button();
            _btnValidateResults.Click += new EventHandler(btnValidateResults_Click);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _grpExcelFile.SuspendLayout();
            _grpCatImport.SuspendLayout();
            SuspendLayout();
            //
            // grpExcelFile
            //
            _grpExcelFile.Controls.Add(_btnExportResults);
            _grpExcelFile.Controls.Add(_btnCheckFiles);
            _grpExcelFile.Location = new Point(8, 40);
            _grpExcelFile.Name = "grpExcelFile";
            _grpExcelFile.Size = new Size(231, 57);
            _grpExcelFile.TabIndex = 3;
            _grpExcelFile.TabStop = false;
            _grpExcelFile.Text = "Initial Import";
            //
            // btnExportResults
            //
            _btnExportResults.Location = new Point(118, 19);
            _btnExportResults.Name = "btnExportResults";
            _btnExportResults.Size = new Size(106, 23);
            _btnExportResults.TabIndex = 5;
            _btnExportResults.Text = "Export Results";
            _btnExportResults.UseVisualStyleBackColor = true;
            //
            // btnCheckFiles
            //
            _btnCheckFiles.Location = new Point(6, 20);
            _btnCheckFiles.Name = "btnCheckFiles";
            _btnCheckFiles.Size = new Size(106, 23);
            _btnCheckFiles.TabIndex = 0;
            _btnCheckFiles.Text = "Check Files";
            _btnCheckFiles.UseVisualStyleBackColor = true;
            //
            // tcData
            //
            _tcData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcData.Location = new Point(8, 103);
            _tcData.Name = "tcData";
            _tcData.SelectedIndex = 0;
            _tcData.Size = new Size(864, 483);
            _tcData.TabIndex = 8;
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnClose.UseVisualStyleBackColor = true;
            _btnClose.Location = new Point(816, 621);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 9;
            _btnClose.Text = "Close";
            //
            // pbStatus
            //
            _pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pbStatus.Location = new Point(8, 621);
            _pbStatus.Name = "pbStatus";
            _pbStatus.Size = new Size(752, 23);
            _pbStatus.Step = 1;
            _pbStatus.TabIndex = 10;
            //
            // lblProgress
            //
            _lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblProgress.Location = new Point(768, 624);
            _lblProgress.Name = "lblProgress";
            _lblProgress.Size = new Size(40, 16);
            _lblProgress.TabIndex = 11;
            _lblProgress.Text = "0%";
            _lblProgress.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblMessages
            //
            _lblMessages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _lblMessages.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMessages.ForeColor = Color.Red;
            _lblMessages.Location = new Point(5, 594);
            _lblMessages.Name = "lblMessages";
            _lblMessages.Size = new Size(868, 19);
            _lblMessages.TabIndex = 12;
            _lblMessages.TextAlign = ContentAlignment.MiddleLeft;
            _lblMessages.Visible = false;
            //
            // btnExportParts
            //
            _btnExportParts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnExportParts.Location = new Point(690, 8);
            _btnExportParts.Name = "btnExportParts";
            _btnExportParts.Size = new Size(88, 23);
            _btnExportParts.TabIndex = 13;
            _btnExportParts.TabStop = true;
            _btnExportParts.Text = "Export Parts";
            //
            // llOpenFolder
            //
            _llOpenFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _llOpenFolder.Location = new Point(575, 8);
            _llOpenFolder.Name = "llOpenFolder";
            _llOpenFolder.Size = new Size(88, 23);
            _llOpenFolder.TabIndex = 14;
            _llOpenFolder.TabStop = true;
            _llOpenFolder.Text = "Open Folders";
            //
            // cboValidateType
            //
            _cboValidateType.FormattingEnabled = true;
            _cboValidateType.Location = new Point(6, 21);
            _cboValidateType.Name = "cboValidateType";
            _cboValidateType.Size = new Size(365, 21);
            _cboValidateType.TabIndex = 1;
            //
            // btnProcessIndiv
            //
            _btnProcessIndiv.Location = new Point(377, 19);
            _btnProcessIndiv.Name = "btnProcessIndiv";
            _btnProcessIndiv.Size = new Size(345, 23);
            _btnProcessIndiv.TabIndex = 4;
            _btnProcessIndiv.Text = "Process -->";
            _btnProcessIndiv.TextAlign = ContentAlignment.MiddleLeft;
            _btnProcessIndiv.UseVisualStyleBackColor = true;
            //
            // grpCatImport
            //
            _grpCatImport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpCatImport.Controls.Add(_btnValidateResults);
            _grpCatImport.Controls.Add(_btnProcessIndiv);
            _grpCatImport.Controls.Add(_cboValidateType);
            _grpCatImport.Location = new Point(245, 40);
            _grpCatImport.Name = "grpCatImport";
            _grpCatImport.Size = new Size(627, 57);
            _grpCatImport.TabIndex = 6;
            _grpCatImport.TabStop = false;
            _grpCatImport.Text = "Category Processing";
            //
            // btnValidateResults
            //
            _btnValidateResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnValidateResults.Location = new Point(499, 19);
            _btnValidateResults.Name = "btnValidateResults";
            _btnValidateResults.Size = new Size(122, 23);
            _btnValidateResults.TabIndex = 6;
            _btnValidateResults.Text = "Revalidate Results";
            _btnValidateResults.UseVisualStyleBackColor = true;
            //
            // Button1
            //
            _Button1.Location = new Point(403, 3);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(152, 23);
            _Button1.TabIndex = 15;
            _Button1.Text = "ValidateOrdersNoParts";
            _Button1.UseVisualStyleBackColor = true;
            //
            // FRMPartsInvoiceImport
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(912, 654);
            Controls.Add(_Button1);
            Controls.Add(_grpCatImport);
            Controls.Add(_llOpenFolder);
            Controls.Add(_btnExportParts);
            Controls.Add(_lblMessages);
            Controls.Add(_lblProgress);
            Controls.Add(_pbStatus);
            Controls.Add(_btnClose);
            Controls.Add(_tcData);
            Controls.Add(_grpExcelFile);
            MinimumSize = new Size(920, 688);
            Name = "FRMPartsInvoiceImport";
            Text = "(PII) Parts Invoice Import";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpExcelFile, 0);
            Controls.SetChildIndex(_tcData, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_pbStatus, 0);
            Controls.SetChildIndex(_lblProgress, 0);
            Controls.SetChildIndex(_lblMessages, 0);
            Controls.SetChildIndex(_btnExportParts, 0);
            Controls.SetChildIndex(_llOpenFolder, 0);
            Controls.SetChildIndex(_grpCatImport, 0);
            Controls.SetChildIndex(_Button1, 0);
            _grpExcelFile.ResumeLayout(false);
            _grpCatImport.ResumeLayout(false);
            ResumeLayout(false);
        }

        
        

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private List<Importer.DuplicateInvoice> _duplicateInvoices = new List<Importer.DuplicateInvoice>();

        private List<Importer.DuplicateInvoice> DuplicateInvoices
        {
            get
            {
                return _duplicateInvoices;
            }

            set
            {
                _duplicateInvoices = value;
            }
        }

        private void cboValidateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
            var switchExpr = Combo.get_GetSelectedItemValue(cboValidateType);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString(): // nothing
                    {
                        btnProcessIndiv.Visible = false;
                        break;
                    }

                case var case1 when case1 == 1.ToString(): // Replenishment
                    {
                        btnProcessIndiv.Visible = false;
                        break;
                    }

                case var case2 when case2 == 2.ToString(): // Unable to locate PO
                    {
                        btnProcessIndiv.Visible = false;
                        break;
                    }

                case var case3 when case3 == 3.ToString(): // Matched PO
                    {
                        btnProcessIndiv.Visible = true;
                        btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
                        break;
                    }

                case var case4 when case4 == 4.ToString(): // Matched PO Price Above
                    {
                        btnProcessIndiv.Visible = true;
                        btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
                        break;
                    }

                case var case5 when case5 == 5.ToString(): // Matched PO Price Below
                    {
                        btnProcessIndiv.Visible = true;
                        btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
                        break;
                    }

                case var case6 when case6 == 6.ToString(): // Purchase Credits
                    {
                        btnProcessIndiv.Visible = true;
                        btnProcessIndiv.Text = "Update PO's With Invoice Details -->";
                        break;
                    }

                case var case7 when case7 == 7.ToString(): // Supplier Invoice Created
                    {
                        btnProcessIndiv.Visible = false;
                        btnProcessIndiv.Text = "Remove Records -->";
                        break;
                    }

                case var case8 when case8 == 8.ToString(): // Matched PO no parts added so no cost
                    {
                        btnProcessIndiv.Visible = false;
                        btnProcessIndiv.Text = "Update PO's With Included Parts and Invoice Details -->";
                        break;
                    }

                case var case9 when case9 == 9.ToString(): // SentToSage
                    {
                        btnProcessIndiv.Visible = false;
                        btnProcessIndiv.Text = "Remove Records -->";
                        break;
                    }

                case var case10 when case10 == 10.ToString(): // Visit not done
                    {
                        btnProcessIndiv.Visible = false;
                        break;
                    }
                // btnProcessIndiv.Text = "Remove Records -->"
                case var case11 when case11 == 14.ToString(): // Matched PO no parts added so no cost
                    {
                        btnProcessIndiv.Visible = false;
                        break;
                    }
            }
        }

        private void btnProcessIndiv_Click(object sender, EventArgs e)
        {
            var switchExpr = Combo.get_GetSelectedItemValue(cboValidateType);
            switch (switchExpr)
            {
                case var @case when @case == 2.ToString(): // Unable to Locate PO
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        ValidateOrder(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        MoveProgressOn(true);
                        ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        Cursor.Current = Cursors.Default;
                        break;
                    }

                case var case1 when case1 == 3.ToString(): // Matched PO Exactly
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        // get my datatable and loop round

                        DataView dvProcessData;
                        dvProcessData = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        pbStatus.Value = 0;
                        pbStatus.Maximum = dvProcessData.Count + 1;
                        for (int i = 0, loopTo = dvProcessData.Count - 1; i <= loopTo; i++)
                        {
                            bool InsertDB = true;
                            if (string.IsNullOrEmpty(dvProcessData.Table.Rows[i]["OrderID"].ToString()))
                            {
                                InsertDB = false;
                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Unable to locate the OrderID for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }
                            // Exit Sub
                            else if ((dvProcessData.Table.Rows[i]["Exclude"].ToString() ?? "") == "True") // excluded
                            {
                                InsertDB = false;
                            }

                            // get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                            int OrderStatusID = 0;
                            OrderStatusID = App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                            if (OrderStatusID == 1)
                            {
                                InsertDB = false;
                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Supplier Invoice for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }

                            if (InsertDB == true)
                            {
                                int orderId = Entity.Sys.Helper.MakeIntegerValid(dvProcessData.Table.Rows[i]["OrderID"]);
                                var oOrder = App.DB.Order.Order_Get(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                                var oSupplierInvoice = new Entity.Orders.SupplierInvoice();
                                oSupplierInvoice.SetOrderID = dvProcessData.Table.Rows[i]["OrderID"].ToString();
                                oSupplierInvoice.SetInvoiceReference = dvProcessData.Table.Rows[i]["InvoiceNo"].ToString();
                                oSupplierInvoice.SetInvoiceDate = dvProcessData.Table.Rows[i]["InvoiceDate"].ToString();
                                oSupplierInvoice.SetGoodsAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalGrossAmount"].ToString());
                                oSupplierInvoice.SetVATAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalVatAmount"].ToString());
                                oSupplierInvoice.SetTotalAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalNetAmount"].ToString());
                                oSupplierInvoice.SetTaxCodeID = 5373;
                                oSupplierInvoice.SetNominalCode = GetNominalCode(orderId: orderId);
                                if (oOrder is object)
                                {
                                    if (oOrder.OrderTypeID == (int)Entity.Sys.Enums.OrderType.Job)
                                    {
                                        var dtCharge = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID);
                                        if (dtCharge.Rows.Count > 0)
                                        {
                                            string ChargeNominalCode = Conversions.ToString(dtCharge.Rows[0]["ChargeNominalCode"]);
                                            if (Conversions.ToDouble(ChargeNominalCode) == 0)
                                            {
                                                oSupplierInvoice.SetExtraRef = ".";
                                            }
                                            else
                                            {
                                                oSupplierInvoice.SetExtraRef = ChargeNominalCode;
                                            }
                                        }
                                        else
                                        {
                                            oSupplierInvoice.SetExtraRef = ".";
                                        }
                                    }
                                    else
                                    {
                                        oSupplierInvoice.SetExtraRef = ".";
                                    }
                                }
                                else
                                {
                                    oSupplierInvoice.SetExtraRef = ".";
                                }

                                oSupplierInvoice.SetReadyToSendToSage = true;
                                oSupplierInvoice.SetSentToSage = 0;
                                oSupplierInvoice.SetOldSystemInvoice = 0;
                                oSupplierInvoice.SetDateExported = null;
                                oSupplierInvoice.SetKeyedBy = App.loggedInUser.UserID;
                                try
                                {
                                    App.DB.SupplierInvoices.Insert(oSupplierInvoice);
                                    App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), true);
                                    bool RequiresAuth = Conversions.ToBoolean(dvProcessData.Table.Rows[i]["RequiresAuthorisation"].ToString());
                                    if (RequiresAuth == true)
                                    {
                                        App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), RequiresAuth);
                                    }
                                    else
                                    {
                                        App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), 7);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    App.ShowMessage("An error has occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                MoveProgressOn(false);
                            }
                        }

                        ValidateAllRecords();
                        ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        Cursor.Current = Cursors.Default;
                        break;
                    }

                case var case2 when case2 == 4.ToString(): // Matched PO Price Above
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        // get my datatable and loop round

                        DataView dvProcessData;
                        dvProcessData = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        pbStatus.Value = 0;
                        pbStatus.Maximum = dvProcessData.Count + 1;
                        for (int i = 0, loopTo1 = dvProcessData.Count - 1; i <= loopTo1; i++)
                        {
                            bool InsertDB = true;
                            if (string.IsNullOrEmpty(dvProcessData.Table.Rows[i]["OrderID"].ToString()))
                            {
                                InsertDB = false;
                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Unable to locate the OrderID for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }
                            // Exit Sub
                            else if ((dvProcessData.Table.Rows[i]["Exclude"].ToString() ?? "") == "True") // excluded
                            {
                                InsertDB = false;
                            }

                            // get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                            int OrderStatusID = 0;
                            OrderStatusID = App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                            if (OrderStatusID == 1)
                            {
                                InsertDB = false;
                                bool RequiresAuth = Conversions.ToBoolean(dvProcessData.Table.Rows[i]["RequiresAuthorisation"].ToString());
                                if (RequiresAuth == true)
                                {
                                    App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), RequiresAuth);
                                }

                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Supplier Invoice for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }

                            if (InsertDB == true)
                            {
                                int orderId = Entity.Sys.Helper.MakeIntegerValid(dvProcessData.Table.Rows[i]["OrderID"]);
                                var oOrder = App.DB.Order.Order_Get(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                                var oSupplierInvoice = new Entity.Orders.SupplierInvoice();
                                oSupplierInvoice.SetOrderID = dvProcessData.Table.Rows[i]["OrderID"].ToString();
                                oSupplierInvoice.SetInvoiceReference = dvProcessData.Table.Rows[i]["InvoiceNo"].ToString();
                                oSupplierInvoice.SetInvoiceDate = dvProcessData.Table.Rows[i]["InvoiceDate"].ToString();
                                oSupplierInvoice.SetGoodsAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalGrossAmount"].ToString());
                                oSupplierInvoice.SetVATAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalVatAmount"].ToString());
                                oSupplierInvoice.SetTotalAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalNetAmount"].ToString());
                                oSupplierInvoice.SetTaxCodeID = 5373;
                                oSupplierInvoice.SetNominalCode = GetNominalCode(orderId);
                                // oSupplierInvoice.SetExtraRef = "."

                                if (oOrder is object)
                                {
                                    if (oOrder.OrderTypeID == (int)Entity.Sys.Enums.OrderType.Job)
                                    {
                                        var dtCharge = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID);
                                        if (dtCharge.Rows.Count > 0)
                                        {
                                            string ChargeNominalCode = Conversions.ToString(dtCharge.Rows[0]["ChargeNominalCode"]);
                                            if (Conversions.ToDouble(ChargeNominalCode) == 0)
                                            {
                                                oSupplierInvoice.SetExtraRef = ".";
                                            }
                                            else
                                            {
                                                oSupplierInvoice.SetExtraRef = ChargeNominalCode;
                                            }
                                        }
                                        else
                                        {
                                            oSupplierInvoice.SetExtraRef = ".";
                                        }
                                    }
                                    else
                                    {
                                        oSupplierInvoice.SetExtraRef = ".";
                                    }
                                }
                                else
                                {
                                    oSupplierInvoice.SetExtraRef = ".";
                                }

                                oSupplierInvoice.SetReadyToSendToSage = true;
                                oSupplierInvoice.SetSentToSage = 0;
                                oSupplierInvoice.SetOldSystemInvoice = 0;
                                oSupplierInvoice.SetDateExported = null;
                                oSupplierInvoice.SetKeyedBy = App.loggedInUser.UserID;
                                try
                                {
                                    App.DB.SupplierInvoices.Insert(oSupplierInvoice);
                                    App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), true);
                                    bool RequiresAuth = Conversions.ToBoolean(dvProcessData.Table.Rows[i]["RequiresAuthorisation"].ToString());
                                    if (RequiresAuth == true)
                                    {
                                        App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), RequiresAuth);
                                    }
                                    else
                                    {
                                        App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), 7);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    App.ShowMessage("An error has occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                MoveProgressOn(false);
                            }
                        }

                        ValidateAllRecords();
                        ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        Cursor.Current = Cursors.Default;
                        break;
                    }

                case var case3 when case3 == 6.ToString(): // Credits
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        // get my datatable and loop round

                        DataView dvProcessData;
                        dvProcessData = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        pbStatus.Value = 0;
                        pbStatus.Maximum = dvProcessData.Count + 1;
                        for (int i = 0, loopTo2 = dvProcessData.Count - 1; i <= loopTo2; i++)
                        {
                            bool InsertDB = true;
                            if (string.IsNullOrEmpty(dvProcessData.Table.Rows[i]["OrderID"].ToString()))
                            {
                                InsertDB = false;
                                bool RequiresAuth = Conversions.ToBoolean(dvProcessData.Table.Rows[i]["RequiresAuthorisation"].ToString());
                                if (RequiresAuth == true)
                                {
                                    App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), RequiresAuth);
                                }

                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Unable to locate the OrderID for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }
                            // Exit Sub
                            else if ((dvProcessData.Table.Rows[i]["Exclude"].ToString() ?? "") == "True") // excluded
                            {
                                InsertDB = false;
                            }

                            // get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                            int OrderStatusID = 0;
                            OrderStatusID = App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                            if (OrderStatusID == 1)
                            {
                                InsertDB = false;
                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Supplier Invoice for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }

                            if (InsertDB == true)
                            {
                                var oOrder = App.DB.Order.Order_Get(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                                int OrderID = Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString());
                                string CreditReference = dvProcessData.Table.Rows[i]["InvoiceNo"].ToString();
                                string CreditReceivedDate = dvProcessData.Table.Rows[i]["InvoiceDate"].ToString();
                                string Amount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalGrossAmount"].ToString()).ToString();
                                int TaxCodeID = 5373;
                                int NominalCode = GetNominalCode(OrderID);
                                // oCredit.SetExtraRef = "."
                                string ChargeNominalCode = "";
                                if (oOrder is object)
                                {
                                    if (oOrder.OrderTypeID == (int)Entity.Sys.Enums.OrderType.Job)
                                    {
                                        var dtCharge = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID);
                                        if (dtCharge.Rows.Count > 0)
                                        {
                                            ChargeNominalCode = Conversions.ToString(dtCharge.Rows[0]["ChargeNominalCode"]);
                                            if (Conversions.ToDouble(ChargeNominalCode) == 0)
                                            {
                                                ChargeNominalCode = "";
                                            }
                                            else
                                            {
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                }

                                var oCredit = new Entity.PartsToBeCrediteds.PartsToBeCredited();
                                oCredit = new Entity.PartsToBeCrediteds.PartsToBeCredited();
                                oCredit.SetOrderID = OrderID;
                                oCredit.SetOrderReference = App.DB.Order.Order_Get(OrderID).OrderReference;
                                int dept = Conversions.ToInteger(App.DB.Order.Order_Get(OrderID).DepartmentRef);
                                var dtc = new DataTable();
                                var dt = App.DB.ExecuteWithReturn("Select * from tblPOInvoiceImport_Parts Where InvoiceNo = '" + dvProcessData.Table.Rows[i]["InvoiceNo"].ToString() + "'");
                                bool failed = true;
                                foreach (DataRow row in dt.Rows)
                                {
                                    // insert the parts to be credited
                                    var part = App.DB.Part.Part_Get_For_Code_And_Supplier(Conversions.ToString(row["SupplierPartCode"]), Conversions.ToInteger(dvProcessData.Table.Rows[i]["SupplierID"]));
                                    int sPartID = -1;
                                    if (part is null)
                                    {
                                        sPartID = -1;
                                    }
                                    else
                                    {
                                        sPartID = part.SPartID;
                                    }

                                    var InOrder = App.DB.ExecuteWithReturn("Select * From tblOrderPart Where OrderID = " + OrderID + " AND PartSupplierID = " + sPartID);
                                    if (InOrder.Rows.Count > 0)
                                    {
                                        failed = false;
                                        oCredit.SetPartID = part.PartID;
                                        oCredit.SetQty = row["Quantity"];
                                        oCredit.SetCreditReceived = Conversions.ToDouble(row["NetAmount"].ToString().Replace("-", ""));
                                        oCredit.SetStatusID = 3;
                                        oCredit.SetSupplierID = dvProcessData.Table.Rows[i]["SupplierID"];
                                        oCredit.SetPartOrderID = InOrder.Rows[0]["OrderPartID"];
                                        dtc = App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(Conversions.ToInteger(InOrder.Rows[0]["OrderPartID"])).Table;
                                        if (dtc.Rows.Count > 0) // Update
                                        {
                                            oCredit.SetPartsToBeCreditedID = dtc.Rows[0]["PartsToBeCreditedID"];
                                            App.DB.PartsToBeCredited.Update(oCredit);
                                        }
                                        else // Insert
                                        {
                                            oCredit = App.DB.PartsToBeCredited.Insert(oCredit);
                                        }
                                    }
                                }  // parts for invoice loop

                                if (failed == true)  // we couldnt match any parts it was a disaster so only option is add the credit against first part in order
                                {
                                    var InOrder = App.DB.ExecuteWithReturn("Select Top (1) * From tblOrderPart Where OrderID = " + OrderID);
                                    int partid = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString("Select Top (1) PartID From tblPartSupplier Where PartSupplierID = " + InOrder.Rows[0]["PartSupplierID"])));
                                    oCredit.SetPartID = partid;
                                    oCredit.SetQty = 1;
                                    oCredit.SetCreditReceived = Conversions.ToDouble(dvProcessData.Table.Rows[i]["TotalNetAmount"].ToString().Replace("-", ""));
                                    oCredit.SetStatusID = 3;
                                    oCredit.SetSupplierID = dvProcessData.Table.Rows[i]["SupplierID"];
                                    oCredit.SetPartOrderID = InOrder.Rows[0]["OrderPartID"];
                                    dtc = App.DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(Conversions.ToInteger(InOrder.Rows[0]["OrderPartID"])).Table;  // table containing the part in question
                                    if (dtc.Rows.Count > 0) // Update
                                    {
                                        oCredit.SetPartsToBeCreditedID = dtc.Rows[0]["PartsToBeCreditedID"];
                                        App.DB.PartsToBeCredited.Update(oCredit);
                                    }
                                    else // Insert
                                    {
                                        oCredit = App.DB.PartsToBeCredited.Insert(oCredit);
                                    }
                                }

                                if (dtc.Rows.Count == 0)
                                {
                                    int partcreditsID = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(dvProcessData.Table.Rows[i]["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(dvProcessData.Table.Rows[i]["InvoiceDate"].ToString()), DateTime.MinValue, TaxCodeID, "5300", dept.ToString(), ChargeNominalCode, dvProcessData.Table.Rows[i]["InvoiceNo"].ToString());
                                    App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + partcreditsID + "," + oCredit.PartsToBeCreditedID + ")");
                                }
                                else if (Information.IsDBNull(dtc.Rows[0]["PartCreditsID"]))
                                {
                                    int partcreditsID = App.DB.PartsToBeCredited.PartCredits_Insert(Conversions.ToDouble(dvProcessData.Table.Rows[i]["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(dvProcessData.Table.Rows[i]["InvoiceDate"].ToString()), DateTime.MinValue, TaxCodeID, "5300", dept.ToString(), ChargeNominalCode, dvProcessData.Table.Rows[i]["InvoiceNo"].ToString());
                                    App.DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" + partcreditsID + "," + oCredit.PartsToBeCreditedID + ")");
                                }
                                else
                                {
                                    App.DB.PartsToBeCredited.PartCredits_Update(Conversions.ToInteger(dtc.Rows[0]["PartCreditsID"]), Conversions.ToDouble(dvProcessData.Table.Rows[i]["TotalNetAmount"].ToString().Replace("-", "")), "", Conversions.ToDate(dvProcessData.Table.Rows[i]["InvoiceDate"].ToString()), DateTime.MinValue, TaxCodeID, "5300", dept.ToString(), ChargeNominalCode, dvProcessData.Table.Rows[i]["InvoiceNo"].ToString());
                                }

                                App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), true);
                                MoveProgressOn(false);
                            }
                        }  // next credit
                           // ValidateAllRecords()
                        ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        Cursor.Current = Cursors.Default;
                        break;
                    }

                case var case4 when case4 == 5.ToString(): // Matched PO Price Below
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        // get my datatable and loop round

                        DataView dvProcessData;
                        dvProcessData = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        pbStatus.Value = 0;
                        pbStatus.Maximum = dvProcessData.Count + 1;
                        for (int i = 0, loopTo3 = dvProcessData.Count - 1; i <= loopTo3; i++)
                        {
                            bool InsertDB = true;
                            if (string.IsNullOrEmpty(dvProcessData.Table.Rows[i]["OrderID"].ToString()))
                            {
                                InsertDB = false;
                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Unable to locate the OrderID for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }
                            // Exit Sub
                            else if ((dvProcessData.Table.Rows[i]["Exclude"].ToString() ?? "") == "True") // excluded
                            {
                                InsertDB = false;
                            }

                            // get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                            int OrderStatusID = 0;
                            OrderStatusID = App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                            if (OrderStatusID == 1)
                            {
                                InsertDB = false;
                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Supplier Invoice for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }

                            if (InsertDB == true)
                            {
                                int orderId = Entity.Sys.Helper.MakeIntegerValid(dvProcessData.Table.Rows[i]["OrderID"]);
                                var oOrder = App.DB.Order.Order_Get(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                                var oSupplierInvoice = new Entity.Orders.SupplierInvoice();
                                oSupplierInvoice.SetOrderID = dvProcessData.Table.Rows[i]["OrderID"].ToString();
                                oSupplierInvoice.SetInvoiceReference = dvProcessData.Table.Rows[i]["InvoiceNo"].ToString();
                                oSupplierInvoice.SetInvoiceDate = dvProcessData.Table.Rows[i]["InvoiceDate"].ToString();
                                oSupplierInvoice.SetGoodsAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalGrossAmount"].ToString());
                                oSupplierInvoice.SetVATAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalVatAmount"].ToString());
                                oSupplierInvoice.SetTotalAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalNetAmount"].ToString());
                                oSupplierInvoice.SetTaxCodeID = 5373;
                                oSupplierInvoice.SetNominalCode = GetNominalCode(orderId);
                                if (oOrder is object)
                                {
                                    if (oOrder.OrderTypeID == (int)Entity.Sys.Enums.OrderType.Job)
                                    {
                                        var dtCharge = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID);
                                        if (dtCharge.Rows.Count > 0)
                                        {
                                            string ChargeNominalCode = Conversions.ToString(dtCharge.Rows[0]["ChargeNominalCode"]);
                                            if (Conversions.ToDouble(ChargeNominalCode) == 0)
                                            {
                                                oSupplierInvoice.SetExtraRef = ".";
                                            }
                                            else
                                            {
                                                oSupplierInvoice.SetExtraRef = ChargeNominalCode;
                                            }
                                        }
                                        else
                                        {
                                            oSupplierInvoice.SetExtraRef = ".";
                                        }
                                    }
                                    else
                                    {
                                        oSupplierInvoice.SetExtraRef = ".";
                                    }
                                }
                                else
                                {
                                    oSupplierInvoice.SetExtraRef = ".";
                                }

                                oSupplierInvoice.SetReadyToSendToSage = true;
                                oSupplierInvoice.SetSentToSage = 0;
                                oSupplierInvoice.SetOldSystemInvoice = 0;
                                oSupplierInvoice.SetDateExported = null;
                                oSupplierInvoice.SetKeyedBy = App.loggedInUser.UserID;
                                try
                                {
                                    App.DB.SupplierInvoices.Insert(oSupplierInvoice);
                                    App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), true);
                                    bool RequiresAuth = Conversions.ToBoolean(dvProcessData.Table.Rows[i]["RequiresAuthorisation"].ToString());
                                    if (RequiresAuth == true)
                                    {
                                        App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), RequiresAuth);
                                    }
                                    else
                                    {
                                        App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), 7);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    App.ShowMessage("An error has occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                MoveProgressOn(false);
                            }
                        }

                        ValidateAllRecords();
                        ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        Cursor.Current = Cursors.Default;
                        break;
                    }

                case var case5 when case5 == 7.ToString(): // Supplier Invoice Created
                    {
                        btnProcessIndiv.Visible = false;
                        btnProcessIndiv.Text = "Remove Records -->";
                        break;
                    }

                case var case6 when case6 == 8.ToString(): // Matched PO no parts added so no cost, add parts and invoice
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        // get my datatable and loop round

                        DataView dvProcessData;
                        dvProcessData = App.DB.ImportValidation.POInvoiceImport_ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        pbStatus.Value = 0;
                        pbStatus.Maximum = dvProcessData.Count + 1;
                        for (int i = 0, loopTo4 = dvProcessData.Count - 1; i <= loopTo4; i++)
                        {
                            bool InsertDB = true;
                            if (string.IsNullOrEmpty(dvProcessData.Table.Rows[i]["OrderID"].ToString()))
                            {
                                InsertDB = false;
                                bool RequiresAuth = Conversions.ToBoolean(dvProcessData.Table.Rows[i]["RequiresAuthorisation"].ToString());
                                if (RequiresAuth == true)
                                {
                                    App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), RequiresAuth);
                                }

                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Unable to locate the OrderID for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }
                            // Exit Sub
                            else if ((dvProcessData.Table.Rows[i]["Exclude"].ToString() ?? "") == "True") // excluded
                            {
                                InsertDB = false;
                            }

                            // get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                            int OrderStatusID = 0;
                            OrderStatusID = App.DB.ImportValidation.POInvoiceImport_GetOrderStatus(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                            if (OrderStatusID == 1)
                            {
                                InsertDB = false;
                                App.ShowMessage("An error has occurred:" + Constants.vbCrLf + "Supplier Invoice for PO " + dvProcessData.Table.Rows[i]["PurchaseOrderNo"].ToString() + " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MoveProgressOn(false);
                            }

                            if (InsertDB == true)
                            {
                                int orderId = Entity.Sys.Helper.MakeIntegerValid(dvProcessData.Table.Rows[i]["OrderID"]);
                                var oOrder = App.DB.Order.Order_Get(Conversions.ToInteger(dvProcessData.Table.Rows[i]["OrderID"].ToString()));
                                var oSupplierInvoice = new Entity.Orders.SupplierInvoice();
                                oSupplierInvoice.SetOrderID = dvProcessData.Table.Rows[i]["OrderID"].ToString();
                                oSupplierInvoice.SetInvoiceReference = dvProcessData.Table.Rows[i]["InvoiceNo"].ToString();
                                oSupplierInvoice.SetInvoiceDate = dvProcessData.Table.Rows[i]["InvoiceDate"].ToString();
                                oSupplierInvoice.SetGoodsAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalGrossAmount"].ToString());
                                oSupplierInvoice.SetVATAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalVatAmount"].ToString());
                                oSupplierInvoice.SetTotalAmount = Convert.ToDouble(dvProcessData.Table.Rows[i]["TotalNetAmount"].ToString());
                                oSupplierInvoice.SetTaxCodeID = 5373;
                                oSupplierInvoice.SetNominalCode = GetNominalCode(orderId);
                                // oSupplierInvoice.SetExtraRef = "."

                                if (oOrder is object)
                                {
                                    if (oOrder.OrderTypeID == (int)Entity.Sys.Enums.OrderType.Job)
                                    {
                                        var dtCharge = App.DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID);
                                        if (dtCharge.Rows.Count > 0)
                                        {
                                            string ChargeNominalCode = Conversions.ToString(dtCharge.Rows[0]["ChargeNominalCode"]);
                                            if (Conversions.ToDouble(ChargeNominalCode) == 0)
                                            {
                                                oSupplierInvoice.SetExtraRef = ".";
                                            }
                                            else
                                            {
                                                oSupplierInvoice.SetExtraRef = ChargeNominalCode;
                                            }
                                        }
                                        else
                                        {
                                            oSupplierInvoice.SetExtraRef = ".";
                                        }
                                    }
                                    else
                                    {
                                        oSupplierInvoice.SetExtraRef = ".";
                                    }
                                }
                                else
                                {
                                    oSupplierInvoice.SetExtraRef = ".";
                                }

                                oSupplierInvoice.SetReadyToSendToSage = true;
                                oSupplierInvoice.SetSentToSage = 0;
                                oSupplierInvoice.SetOldSystemInvoice = 0;
                                oSupplierInvoice.SetDateExported = null;
                                oSupplierInvoice.SetKeyedBy = App.loggedInUser.UserID;
                                try
                                {
                                    App.DB.SupplierInvoices.Insert(oSupplierInvoice);
                                    App.DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), true);
                                    bool RequiresAuth = Conversions.ToBoolean(dvProcessData.Table.Rows[i]["RequiresAuthorisation"].ToString());
                                    if (RequiresAuth == true)
                                    {
                                        App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), RequiresAuth);
                                    }
                                    else
                                    {
                                        App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dvProcessData.Table.Rows[i]["ID"].ToString()), 7);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    App.ShowMessage("An error has occurred:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                MoveProgressOn(false);
                            }
                        }
                        // ValidateAllRecords()
                        ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
                        Cursor.Current = Cursors.Default;
                        break;
                    }

                case var case7 when case7 == 9.ToString(): // SentToSage
                    {
                        break;
                    }
            }
        }

        public void ValidateAllRecords()
        {
            // ShowMessage("Validation can take up to two minutes.  The progress bar at the bottom will not increase during this time.  Please be patient.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            var dvAllData = App.DB.ImportValidation.POInvoiceImport_ShowData_Mk1();
            int Steps = dvAllData.Count; // RD
            pbStatus.Value = 0;
            pbStatus.Maximum = Steps + 1;
            foreach (DataRow dr in dvAllData.Table.Rows)
            {
                int id = Entity.Sys.Helper.MakeIntegerValid(dr["ID"]);
                App.DB.ImportValidation.POInvoiceImport_ValidateOrder(id); // Then 'Then Debugger.Break()
                MoveProgressOn();
            }

            var argcombo = cboValidateType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
            ShowData();
            lblMessages.Text = "Validation complete.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        public void ValidateCurrentlyDisplayedRecords()
        {
            // ShowMessage("Validation can take up to two minutes.  The progress bar at the bottom will not increase during this time.  Please be patient.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            App.DB.ImportValidation.POInvoiceImport_ValidateOrders(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
            ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
            lblMessages.Text = "Validation complete.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        public void ValidateOrder(int ValidateType)
        {
            lblMessages.Text = "Now validating orders, this can take up to two minutes. Please be patient.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.WaitCursor;
            App.DB.ImportValidation.POInvoiceImport_ValidateOrders(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
            ShowData(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboValidateType)));
            lblMessages.Text = "Validation complete.";
            lblMessages.Visible = true;
            Cursor.Current = Cursors.Default;
        }

        private void btnCheckFiles_Click(object sender, EventArgs e)
        {
            lblMessages.Text = "Starting import...";
            lblMessages.Visible = true;

            // clear duplicate records list
            DuplicateInvoices.Clear();
            pbStatus.Value = 0;
            pbStatus.Maximum = 1;
            PreImportData();
            var argcombo = cboValidateType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
            // once import is completed show data imported
            ShowData();
            lblMessages.Text = "Import complete.";
            lblMessages.Visible = true;

            // validate all
            // ValidateAllRecords()

            // if we have duplicates display them to user
            if (DuplicateInvoices.Count > 0)
            {
                var duplicates = new List<string>();
                foreach (Importer.DuplicateInvoice duplicate in DuplicateInvoices)
                    duplicates.Add("Invovice: " + duplicate.InvoiceNo + " InvoiceDate: " + duplicate.InvoiceDate + " PartCode:  " + duplicate.SupplierPartCode);
                if (App.ShowMessageWithDetails("Import Complete", "The following invoices are duplicates and have not been imported.", duplicates) == DialogResult.OK)
                {
                    var frmDuplicateInvoices = new FRMDuplicateInvoices(DuplicateInvoices);
                    frmDuplicateInvoices.ShowDialog();
                }
            }
            else
            {
                App.ShowMessage("Import Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // clear duplicate list
            DuplicateInvoices.Clear();
            Cursor.Current = Cursors.Default;
        }

        private void PreImportData()
        {
            Microsoft.Office.Interop.Excel.Application oExcel;

            // Build table to hold list of paths for checking.
            var dt_Folders = new DataTable();
            dt_Folders.Columns.Add("FolderPath");
            dt_Folders.Columns.Add("FriendlyName");
            dt_Folders.Columns.Add("SupplierID");
            dt_Folders.Rows.Add(App.TheSystem.Configuration.DocumentsLocation + @"PartsInvoiceFiles\NHC\", "NorwichHeatingComponents", "21");
            dt_Folders.Rows.Add(App.TheSystem.Configuration.DocumentsLocation + @"PartsInvoiceFiles\PTS\", "PTS", "20");
            dt_Folders.Rows.Add(App.TheSystem.Configuration.DocumentsLocation + @"PartsInvoiceFiles\PartsCenter\", "PartsCenter", "22");
            dt_Folders.Rows.Add(App.TheSystem.Configuration.DocumentsLocation + @"PartsInvoiceFiles\Plumbase\", "Plumbase", "58");
            dt_Folders.Rows.Add(App.TheSystem.Configuration.DocumentsLocation + @"PartsInvoiceFiles\CPS\", "CPS", "20");

            // Cycle through table looking for files.
            int FileCount = 0;
            foreach (DataRow dr_Folders in dt_Folders.Rows)
            {
                // make a reference to a directory
                var di = new System.IO.DirectoryInfo(Conversions.ToString(dr_Folders["FolderPath"]));
                var diar1 = di.GetFiles();

                // list the names of all files in the specified directory
                foreach (System.IO.FileInfo CurrentFile in diar1)
                {
                    // Is it an excel file?
                    if ((CurrentFile.Extension ?? "") == ".xls" | (CurrentFile.Extension ?? "") == ".xlsx")
                    {
                        // Is an Excel file
                        oExcel = new Microsoft.Office.Interop.Excel.Application();
                        oExcel.DisplayAlerts = false;
                        Microsoft.Office.Interop.Excel.Worksheet oWorksheet;
                        oExcel.Workbooks.Add(CurrentFile.FullName);
                        oWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)oExcel.Worksheets[1];
                        string strCom = " SELECT * FROM [" + oWorksheet.Name + "$]";
                        string strCon = "";
                        if ((CurrentFile.Extension.Trim().ToLower() ?? "") == (".xls".ToLower() ?? ""))
                        {
                            strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + CurrentFile.FullName + " ; Extended Properties=Excel 8.0; ";
                        }
                        else if ((CurrentFile.Extension.Trim().ToLower() ?? "") == (".xlsx".ToLower() ?? ""))
                        {
                            strCon = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + CurrentFile.FullName + " ; Extended Properties=Excel 12.0; ";
                        }

                        var conn = new System.Data.OleDb.OleDbConnection(strCon);
                        var adapter = new System.Data.OleDb.OleDbDataAdapter();
                        var data = new DataSet();
                        adapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strCom, conn);
                        data.Clear();
                        adapter.Fill(data);
                        FileCount += 1;
                        pbStatus.Maximum += data.Tables[0].Rows.Count;
                    }
                    else
                    {
                        // Is NOT an Excel file
                        System.IO.File.Move(CurrentFile.FullName, (string)(dr_Folders["FolderPath"] + @"\Failed\" + CurrentFile.Name));
                    }
                }
            }

            int FileLoops = 0;
            int PartLoops = 0;
            foreach (DataRow dr_Folders in dt_Folders.Rows)
            {
                // make a reference to a directory
                var di = new System.IO.DirectoryInfo(Conversions.ToString(dr_Folders["FolderPath"]));
                var diar1 = di.GetFiles();

                // list the names of all files in the specified directory
                foreach (System.IO.FileInfo CurrentFile in diar1)
                {
                    // Is it an excel file?
                    if ((CurrentFile.Extension ?? "") == ".xls" | (CurrentFile.Extension ?? "") == ".xlsx")
                    {
                        FileLoops += 1;
                        PartLoops = 0;
                        // Is an Excel file
                        oExcel = new Microsoft.Office.Interop.Excel.Application();
                        oExcel.DisplayAlerts = false;
                        Microsoft.Office.Interop.Excel.Worksheet oWorksheet;
                        oExcel.Workbooks.Add(CurrentFile.FullName);
                        oWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)oExcel.Worksheets[1];
                        string strCom = " SELECT * FROM [" + oWorksheet.Name + "$]";
                        string strCon = "";
                        if ((CurrentFile.Extension.Trim().ToLower() ?? "") == (".xls".ToLower() ?? ""))
                        {
                            strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + CurrentFile.FullName + " ; Extended Properties=Excel 8.0; ";
                        }
                        else if ((CurrentFile.Extension.Trim().ToLower() ?? "") == (".xlsx".ToLower() ?? ""))
                        {
                            strCon = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + CurrentFile.FullName + " ; Extended Properties=Excel 12.0; ";
                        }

                        var conn = new System.Data.OleDb.OleDbConnection(strCon);
                        var adapter = new System.Data.OleDb.OleDbDataAdapter();
                        var data = new DataSet();
                        var switchExpr = dr_Folders["FriendlyName"].ToString();
                        switch (switchExpr)
                        {
                            case "PartsCenter":
                            case "NorwichHeatingComponents":
                            case "CPS":
                                {
                                    data.Tables.Add();
                                    var colString = new DataColumn("Product Code");
                                    colString.DataType = Type.GetType("System.String");
                                    data.Tables[0].Columns.Add(colString);
                                    break;
                                }

                            case "PTS":
                                {
                                    data.Tables.Add();
                                    var colString = new DataColumn("Keyword");
                                    colString.DataType = Type.GetType("System.String");
                                    data.Tables[0].Columns.Add(colString);
                                    break;
                                }

                            default:
                                {
                                    data.Tables.Add();
                                    var colString = new DataColumn("Keyword");
                                    colString.DataType = Type.GetType("System.String");
                                    data.Tables[0].Columns.Add(colString);
                                    break;
                                }
                        }

                        adapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strCom, conn);
                        data.Clear();
                        adapter.Fill(data.Tables[0]);
                        DataView dv;
                        dv = new DataView(data.Tables[0]);
                        if ((dr_Folders["FriendlyName"].ToString() ?? "") == "PartsCenter")
                        {
                            dv.Sort = "Customer Order Number";
                        }
                        else if ((dr_Folders["FriendlyName"].ToString() ?? "") == "NorwichHeatingComponents")
                        {
                            dv.Sort = "Gasway Order No";
                        }
                        else if ((dr_Folders["FriendlyName"].ToString() ?? "") == "PTS")
                        {
                            dv.Sort = "Your Order";
                        }
                        else if ((dr_Folders["FriendlyName"].ToString() ?? "") == "CPS")
                        {
                            if (dv.Table.Columns.Contains("Customer Order Number"))
                                dv.Sort = "Customer Order Number";
                            if (dv.Table.Columns.Contains("Customer_Order_Number"))
                                dv.Sort = "Customer_Order_Number";
                        }
                        else if ((dr_Folders["FriendlyName"].ToString() ?? "") == "Plumbase")
                        {
                            dv.Sort = "Customer Order No (Hr)";
                        }
                        else
                        {
                            dv.Sort = "Your Order";
                        }
                        // dv.Sort = "Customer Order Number"
                        data.Tables.Clear();
                        data.Tables.Add(dv.ToTable());
                        var LastPONumber = new string[5001];
                        var LastInvoiceNumber = new string[5001];
                        int NoOfParts = 0;
                        int TotalQtyOfParts = 0;
                        double TotalUnitPrice = 0;
                        double TotalNetAmount = 0;
                        double TotalVATAmount = 0;
                        double TotalGrossAmount = 0;
                        bool SecondaryPart = false;
                        bool lastpartinserted = false;
                        int orderID = 0;
                        for (int i = 0, loopTo = data.Tables[0].Rows.Count - 1; i <= loopTo; i++)
                        {
                            int SupplierID = Conversions.ToInteger(dr_Folders["SupplierID"]);
                            string InvoiceNo = null;
                            string InvoiceDate = null;
                            string PurchaseOrderNo = null;
                            string Engineer = null;
                            string SiteAddress = null;
                            string OrderType = null;
                            string SupplierPartCode = null;
                            string Description = "Unspecified";
                            int Quantity = 0;
                            double UnitPrice = 0;
                            double NetAmount = 0;
                            double VATAmount = 0;
                            double GrossAmount = 0;
                            bool InsertDB = true;
                            var Row = data.Tables[0].Rows[i];
                            var switchExpr1 = dr_Folders["FriendlyName"].ToString();
                            switch (switchExpr1)
                            {
                                case "NorwichHeatingComponents":
                                    {
                                        if (Row["Gasway Order No"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["Number"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["Product Code"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Information.IsDBNull(Row["Number"]))
                                        {
                                            InvoiceNo = "Unspecified";
                                        }
                                        else
                                        {
                                            InvoiceNo = Strings.Trim(Conversions.ToString(Row["Number"]));
                                        }

                                        if (Row["Date"] == DBNull.Value)
                                        {
                                            InvoiceDate = "01/01/1900";
                                        }
                                        else
                                        {
                                            InvoiceDate = Strings.Trim(Conversions.ToString(Row["Date"]));
                                        }

                                        if (Row["Gasway Order No"] == DBNull.Value)
                                        {
                                            PurchaseOrderNo = "Unspecified";
                                        }
                                        else
                                        {
                                            PurchaseOrderNo = Strings.Trim(Conversions.ToString(Row["Gasway Order No"]));
                                        }

                                        if (Row["Product Code"] == DBNull.Value)
                                        {
                                            SupplierPartCode = "Unspecified";
                                        }
                                        else
                                        {
                                            SupplierPartCode = Strings.Trim(Conversions.ToString(Row["Product Code"]));
                                        }

                                        if (Row["Description"] == DBNull.Value)
                                        {
                                            Description = "Unspecified";
                                        }
                                        else
                                        {
                                            Description = Strings.Trim(Conversions.ToString(Row["Description"]));
                                        }

                                        if (InsertDB)
                                        {
                                            OrderType = "Unspecified";
                                            if (Row["Quantity"] == DBNull.Value)
                                            {
                                                Quantity = 0;
                                            }
                                            else
                                            {
                                                Quantity = Conversions.ToInteger(Strings.Trim(Conversions.ToString(Row["Quantity"])));
                                                TotalQtyOfParts += Quantity;
                                            }

                                            if (Row["Net Price"] == DBNull.Value)
                                            {
                                                UnitPrice = 0;
                                            }
                                            else
                                            {
                                                UnitPrice = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Net Price"])));
                                                TotalUnitPrice += UnitPrice;
                                            }

                                            if (Row["Net Amount"] == DBNull.Value)
                                            {
                                                NetAmount = 0;
                                            }
                                            else
                                            {
                                                NetAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Net Amount"])));
                                                TotalNetAmount += NetAmount;
                                            }

                                            if (Row["Tax Amount"] == DBNull.Value)
                                            {
                                                VATAmount = 0;
                                            }
                                            else
                                            {
                                                VATAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Tax Amount"])));
                                                TotalVATAmount += VATAmount;
                                            }

                                            if (Row["Gross Amount"] == DBNull.Value)
                                            {
                                                GrossAmount = 0;
                                            }
                                            else
                                            {
                                                GrossAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Gross Amount"])));
                                                TotalGrossAmount += GrossAmount;
                                            }
                                        }

                                        break;
                                    }

                                case "PartsCenter":
                                    {
                                        if (Row["Customer Order Number"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["Product Code"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["Invoice Number"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["Invoice Number"] == DBNull.Value)
                                        {
                                            InvoiceNo = "Unspecified";
                                        }
                                        else
                                        {
                                            InvoiceNo = Strings.Trim(Conversions.ToString(Row["Invoice Number"]));
                                        }

                                        if (Row["Invoice Date"] == DBNull.Value)
                                        {
                                            InvoiceDate = "01/01/1900";
                                        }
                                        else
                                        {
                                            InvoiceDate = Strings.Trim(Conversions.ToString(Row["Invoice Date"]));
                                        }

                                        if (Row["Customer Order Number"] == DBNull.Value)
                                        {
                                            PurchaseOrderNo = "Unspecified";
                                        }
                                        else
                                        {
                                            PurchaseOrderNo = Strings.Trim(Conversions.ToString(Row["Customer Order Number"]));
                                        }

                                        SupplierPartCode = Strings.Trim(Row["Product Code"].ToString());
                                        if (Row["Product Description"] == DBNull.Value)
                                        {
                                            Description = "Unspecified";
                                        }
                                        else
                                        {
                                            Description = Strings.Trim(Conversions.ToString(Row["Product Description"]));
                                        }

                                        if (InsertDB)
                                        {
                                            OrderType = "Unspecified";
                                            Engineer = "Unspecified";
                                            SiteAddress = "Unspecified";
                                            if (Row["Line Qty"] == DBNull.Value)
                                            {
                                                Quantity = 0;
                                            }
                                            else
                                            {
                                                Quantity = Conversions.ToInteger(Strings.Trim(Conversions.ToString(Row["Line Qty"])));
                                                TotalQtyOfParts += Quantity;
                                            }

                                            if (Row["Unit Price"] == DBNull.Value)
                                            {
                                                UnitPrice = 0;
                                            }
                                            else
                                            {
                                                UnitPrice = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Unit Price"])));
                                                TotalUnitPrice += UnitPrice;
                                            }

                                            if (Row["Line Nett Value"] == DBNull.Value)
                                            {
                                                NetAmount = 0;
                                            }
                                            else
                                            {
                                                NetAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Line Nett Value"])));
                                                TotalNetAmount += NetAmount;
                                            }

                                            if (Row["Line VAT Amount"] == DBNull.Value)
                                            {
                                                VATAmount = 0;
                                            }
                                            else
                                            {
                                                VATAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Line VAT Amount"])));
                                                TotalVATAmount += VATAmount;
                                            }

                                            if (Row["Line Gross Value"] == DBNull.Value)
                                            {
                                                GrossAmount = 0;
                                            }
                                            else
                                            {
                                                GrossAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Line Gross Value"])));
                                                TotalGrossAmount += GrossAmount;
                                            }
                                        }

                                        break;
                                    }

                                case "PTS":
                                    {
                                        if (Row["Your Order"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["InvNo"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["Keyword"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["INVNO"] == DBNull.Value)
                                        {
                                            InvoiceNo = "Unspecified";
                                        }
                                        else
                                        {
                                            InvoiceNo = Strings.Trim(Conversions.ToString(Row["INVNO"]));
                                        }

                                        if (Row["Date"] == DBNull.Value)
                                        {
                                            InvoiceDate = "01/01/1900";
                                        }
                                        else
                                        {
                                            InvoiceDate = Strings.Trim(Conversions.ToString(Row["Date"]));
                                        }

                                        if (Row["Your Order"] == DBNull.Value)
                                        {
                                            PurchaseOrderNo = "Unspecified";
                                        }
                                        else
                                        {
                                            PurchaseOrderNo = Strings.Trim(Conversions.ToString(Row["Your Order"]));
                                        }

                                        if (Row["Keyword"] == DBNull.Value)
                                        {
                                            SupplierPartCode = "Unspecified";
                                        }
                                        else
                                        {
                                            SupplierPartCode = Strings.Trim(Conversions.ToString(Row["Keyword"]));
                                        }

                                        if (Row["Description"] == DBNull.Value)
                                        {
                                            Description = "Unspecified";
                                        }
                                        else
                                        {
                                            Description = Strings.Trim(Conversions.ToString(Row["Description"]));
                                        }

                                        if (InsertDB)
                                        {
                                            OrderType = "Unspecified";
                                            Engineer = "Unspecified";
                                            SiteAddress = "Unspecified";
                                            if (Row["Invoiced"] == DBNull.Value)
                                            {
                                                Quantity = 0;
                                            }
                                            else
                                            {
                                                Quantity = Conversions.ToInteger(Strings.Trim(Conversions.ToString(Row["Invoiced"])));
                                                TotalQtyOfParts += Quantity;
                                            }

                                            if (Row["Cost"] == DBNull.Value)
                                            {
                                                UnitPrice = 0;
                                            }
                                            else
                                            {
                                                UnitPrice = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Cost"])));
                                                TotalUnitPrice += UnitPrice;
                                            }

                                            if (Row["Value"] == DBNull.Value)
                                            {
                                                NetAmount = 0;
                                            }
                                            else
                                            {
                                                NetAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Value"])));
                                                TotalNetAmount += NetAmount;
                                            }

                                            if (Row["VAT Value"] == DBNull.Value)
                                            {
                                                VATAmount = 0;
                                            }
                                            else
                                            {
                                                VATAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["VAT Value"])));
                                                TotalVATAmount += VATAmount;
                                            }

                                            GrossAmount = NetAmount + VATAmount;
                                            TotalGrossAmount += GrossAmount;
                                        }

                                        break;
                                    }

                                case "Plumbase":
                                    {
                                        if (Row["Customer Order No (Hr)"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["Invoice"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["Part Number (Li)"] == DBNull.Value)
                                            InsertDB = false;
                                        if (Row["Invoice"] == DBNull.Value)
                                        {
                                            InvoiceNo = "Unspecified";
                                        }
                                        else
                                        {
                                            InvoiceNo = Strings.Trim(Conversions.ToString(Row["Invoice"]));
                                        }

                                        if (Row["Invoice Date (Li)"] == DBNull.Value)
                                        {
                                            InvoiceDate = "01/01/1900";
                                        }
                                        else
                                        {
                                            InvoiceDate = Strings.Trim(Conversions.ToString(Row["Invoice Date (Li)"]));
                                        }

                                        if (Row["Customer Order No (Hr)"] == DBNull.Value)
                                        {
                                            PurchaseOrderNo = "Unspecified";
                                        }
                                        else
                                        {
                                            PurchaseOrderNo = Strings.Trim(Conversions.ToString(Row["Customer Order No (Hr)"]));
                                        }

                                        if (Row["Part Number (Li)"] == DBNull.Value)
                                        {
                                            SupplierPartCode = "Unspecified";
                                        }
                                        else
                                        {
                                            SupplierPartCode = Strings.Trim(Conversions.ToString(Row["Part Number (Li)"]));
                                        }

                                        if (Row["Full Description (Li)"] == DBNull.Value)
                                        {
                                            Description = "Unspecified";
                                        }
                                        else
                                        {
                                            Description = Strings.Trim(Conversions.ToString(Row["Full Description (Li)"]));
                                        }

                                        if (InsertDB)
                                        {
                                            OrderType = "Unspecified";
                                            Engineer = "Unspecified";
                                            SiteAddress = "Unspecified";
                                            if (Row["Quantity"] == DBNull.Value)
                                            {
                                                Quantity = 0;
                                            }
                                            else
                                            {
                                                Quantity = Conversions.ToInteger(Strings.Trim(Conversions.ToString(Row["Quantity"])));
                                                TotalQtyOfParts += Quantity;
                                            }

                                            if (Row["Price"] == DBNull.Value)
                                            {
                                                UnitPrice = 0;
                                            }
                                            else
                                            {
                                                UnitPrice = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Price"])));
                                                TotalUnitPrice += UnitPrice;
                                            }

                                            if (Row["Goods"] == DBNull.Value)
                                            {
                                                NetAmount = 0;
                                            }
                                            else
                                            {
                                                NetAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Goods"])));
                                                TotalNetAmount += NetAmount;
                                            }

                                            if (Row["VAT"] == DBNull.Value)
                                            {
                                                VATAmount = 0;
                                            }
                                            else
                                            {
                                                VATAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["VAT"])));
                                                TotalVATAmount += VATAmount;
                                            }

                                            GrossAmount = NetAmount + VATAmount;
                                            TotalGrossAmount += GrossAmount;
                                        }

                                        break;
                                    }

                                case "CPS":
                                    {
                                        if (Row.Table.Columns.Contains("Customer Order Number"))
                                        {
                                            if (Row["Customer Order Number"] == DBNull.Value)
                                            {
                                                InsertDB = false;
                                                PurchaseOrderNo = "Unspecified";
                                            }
                                            else
                                            {
                                                PurchaseOrderNo = Strings.Trim(Conversions.ToString(Row["Customer Order Number"]));
                                            }
                                        }

                                        if (Row.Table.Columns.Contains("Customer_Order_Number"))
                                        {
                                            if (Row["Customer_Order_Number"] == DBNull.Value)
                                            {
                                                InsertDB = false;
                                                PurchaseOrderNo = "Unspecified";
                                            }
                                            else
                                            {
                                                PurchaseOrderNo = Strings.Trim(Conversions.ToString(Row["Customer_Order_Number"]));
                                            }
                                        }

                                        if (Row.Table.Columns.Contains("Invoice Number"))
                                        {
                                            if (Row["Invoice Number"] == DBNull.Value)
                                            {
                                                InsertDB = false;
                                                InvoiceNo = "Unspecified";
                                            }
                                            else
                                            {
                                                InvoiceNo = Strings.Trim(Conversions.ToString(Row["Invoice Number"]));
                                            }
                                        }

                                        if (Row.Table.Columns.Contains("Invoice_Number"))
                                        {
                                            if (Row["Invoice_Number"] == DBNull.Value)
                                            {
                                                InsertDB = false;
                                                InvoiceNo = "Unspecified";
                                            }
                                            else
                                            {
                                                InvoiceNo = Strings.Trim(Conversions.ToString(Row["Invoice_Number"]));
                                            }
                                        }

                                        if (Row.Table.Columns.Contains("Product Code"))
                                        {
                                            if (Row["Product Code"] == DBNull.Value)
                                            {
                                                InsertDB = false;
                                                SupplierPartCode = "Unspecified";
                                            }
                                            else
                                            {
                                                SupplierPartCode = Strings.Trim(Conversions.ToString(Row["Product Code"]));
                                            }
                                        }

                                        if (Row.Table.Columns.Contains("Product_Code"))
                                        {
                                            if (Row["Product_Code"] == DBNull.Value)
                                            {
                                                InsertDB = false;
                                                SupplierPartCode = "Unspecified";
                                            }
                                            else
                                            {
                                                SupplierPartCode = Strings.Trim(Conversions.ToString(Row["Product_Code"]));
                                            }
                                        }

                                        if (Row.Table.Columns.Contains("Invoice Date"))
                                        {
                                            if (Row["Invoice Date"] == DBNull.Value)
                                            {
                                                InvoiceDate = "Unspecified";
                                            }
                                            else
                                            {
                                                InvoiceDate = Strings.Trim(Conversions.ToString(Row["Invoice Date"]));
                                            }
                                        }

                                        if (Row.Table.Columns.Contains("Invoice_Date"))
                                        {
                                            if (Row["Invoice_Date"] == DBNull.Value)
                                            {
                                                InvoiceDate = "Unspecified";
                                            }
                                            else
                                            {
                                                InvoiceDate = Strings.Trim(Conversions.ToString(Row["Invoice_Date"]));
                                            }
                                        }

                                        if (Row.Table.Columns.Contains("Product Description"))
                                        {
                                            if (Row["Product Description"] == DBNull.Value)
                                            {
                                                Description = "Unspecified";
                                            }
                                            else
                                            {
                                                Description = Strings.Trim(Conversions.ToString(Row["Product Description"]));
                                            }
                                        }

                                        if (Row.Table.Columns.Contains("Product_Description"))
                                        {
                                            if (Row["Product_Description"] == DBNull.Value)
                                            {
                                                Description = "Unspecified";
                                            }
                                            else
                                            {
                                                Description = Strings.Trim(Conversions.ToString(Row["Product_Description"]));
                                            }
                                        }

                                        if (InsertDB)
                                        {
                                            OrderType = "Unspecified";
                                            Engineer = "Unspecified";
                                            SiteAddress = "Unspecified";
                                            if (Row.Table.Columns.Contains("Sales Quantity"))
                                            {
                                                if (Row["Sales Quantity"] == DBNull.Value)
                                                {
                                                    Quantity = 0;
                                                }
                                                else
                                                {
                                                    Quantity = Conversions.ToInteger(Strings.Trim(Conversions.ToString(Row["Sales Quantity"])));
                                                    TotalQtyOfParts += Quantity;
                                                }
                                            }

                                            if (Row.Table.Columns.Contains("Sales_Quantity"))
                                            {
                                                if (Row["Sales_Quantity"] == DBNull.Value)
                                                {
                                                    Quantity = 0;
                                                }
                                                else
                                                {
                                                    Quantity = Conversions.ToInteger(Strings.Trim(Conversions.ToString(Row["Sales_Quantity"])));
                                                    TotalQtyOfParts += Quantity;
                                                }
                                            }

                                            if (Row.Table.Columns.Contains("Price Per Item"))
                                            {
                                                if (Row["Price Per Item"] == DBNull.Value)
                                                {
                                                    UnitPrice = 0;
                                                }
                                                else
                                                {
                                                    UnitPrice = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Price Per Item"])));
                                                    TotalUnitPrice += UnitPrice;
                                                }
                                            }

                                            if (Row.Table.Columns.Contains("Price_Per_Item"))
                                            {
                                                if (Row["Price_Per_Item"] == DBNull.Value)
                                                {
                                                    UnitPrice = 0;
                                                }
                                                else
                                                {
                                                    UnitPrice = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Price_Per_Item"])));
                                                    TotalUnitPrice += UnitPrice;
                                                }
                                            }

                                            if (Row.Table.Columns.Contains("Sales Value"))
                                            {
                                                if (Row["Sales Value"] == DBNull.Value)
                                                {
                                                    NetAmount = 0;
                                                }
                                                else
                                                {
                                                    NetAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Sales Value"])));
                                                    TotalNetAmount += NetAmount;
                                                }
                                            }

                                            if (Row.Table.Columns.Contains("Sales_Value"))
                                            {
                                                if (Row["Sales_Value"] == DBNull.Value)
                                                {
                                                    NetAmount = 0;
                                                }
                                                else
                                                {
                                                    NetAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Sales_Value"])));
                                                    TotalNetAmount += NetAmount;
                                                }
                                            }

                                            if (Row.Table.Columns.Contains("Sales VAT Value"))
                                            {
                                                if (Row["Sales VAT Value"] == DBNull.Value)
                                                {
                                                    VATAmount = 0;
                                                }
                                                else
                                                {
                                                    VATAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Sales VAT Value"])));
                                                    TotalVATAmount += VATAmount;
                                                }
                                            }

                                            if (Row.Table.Columns.Contains("Sales_Vat_Value"))
                                            {
                                                if (Row["Sales_Vat_Value"] == DBNull.Value)
                                                {
                                                    VATAmount = 0;
                                                }
                                                else
                                                {
                                                    VATAmount = Conversions.ToDouble(Strings.Trim(Conversions.ToString(Row["Sales_Vat_Value"])));
                                                    TotalVATAmount += VATAmount;
                                                }
                                            }

                                            GrossAmount = NetAmount + VATAmount;
                                            TotalGrossAmount += GrossAmount;
                                        }

                                        break;
                                    }
                            }

                            try
                            {
                                int ImportOrderExistsAndHasBeenSent = App.DB.ImportValidation.POInvoiceImport_CheckImportHasBeenSent(InvoiceNo, Conversions.ToDate(InvoiceDate), SupplierPartCode);
                                // lets check if the import has been sent
                                if (ImportOrderExistsAndHasBeenSent > 0)
                                {
                                    MoveProgressOn();
                                    continue;
                                }

                                int ImportOrderExists = App.DB.ImportValidation.POInvoiceImport_CheckImportInvoiceExists(InvoiceNo, Conversions.ToDate(InvoiceDate), SupplierPartCode);
                                if (ImportOrderExists > 0)
                                {
                                    InsertDB = false; // import already in db
                                    var duplicate = new Importer.DuplicateInvoice();
                                    duplicate.PurchaseOrderNo = PurchaseOrderNo;
                                    duplicate.SupplierPartCode = SupplierPartCode;
                                    duplicate.Description = Description;
                                    duplicate.Quantity = Quantity;
                                    duplicate.UnitPrice = UnitPrice;
                                    duplicate.NetAmount = NetAmount;
                                    duplicate.VATAmount = VATAmount;
                                    duplicate.GrossAmount = GrossAmount;
                                    duplicate.InvoiceNo = InvoiceNo;
                                    duplicate.InvoiceDate = InvoiceDate;
                                    duplicate.SupplierID = SupplierID;
                                    duplicate.TotalQtyOfParts = TotalQtyOfParts;
                                    DuplicateInvoices.Add(duplicate);
                                }

                                if (InsertDB)
                                {
                                    if (!checkArray(LastPONumber, PurchaseOrderNo) | checkArray(LastPONumber, PurchaseOrderNo) & !checkArray(LastInvoiceNumber, InvoiceNo))
                                    {
                                        // create the PO holder In the db
                                        NoOfParts = 0;
                                        TotalQtyOfParts = 0;
                                        TotalGrossAmount = 0;
                                        TotalNetAmount = 0;
                                        TotalUnitPrice = 0;
                                        TotalVATAmount = 0;
                                        // insert order into db and retrieve order id
                                        orderID = App.DB.ImportValidation.POInvoiceImport_InsertOrder(InvoiceNo, Conversions.ToDate(InvoiceDate), PurchaseOrderNo, SupplierID, OrderType);
                                        LastPONumber[i] = PurchaseOrderNo;
                                        LastInvoiceNumber[i] = InvoiceNo;
                                        SecondaryPart = false;
                                        lastpartinserted = true;
                                    }
                                    else
                                    {
                                        lastpartinserted = false;
                                    }

                                    NoOfParts += 1;
                                    // insert the part into the table
                                    App.DB.ImportValidation.POInvoiceImport_InsertPart(PurchaseOrderNo, SupplierPartCode, Description, Quantity, UnitPrice, NetAmount, VATAmount, GrossAmount, InvoiceNo);
                                    App.DB.ImportValidation.POInvoiceImport_UpdateOrderTotals(PurchaseOrderNo, Quantity, UnitPrice, NetAmount, VATAmount, GrossAmount, TotalQtyOfParts, InvoiceNo);
                                    // validate order
                                    if (orderID > 0)
                                    {
                                        App.DB.ImportValidation.POInvoiceImport_ValidateOrder(orderID);
                                    }
                                }

                                if (InsertDB)
                                {
                                    PartLoops += 1;
                                    lblMessages.Text = "Adding part " + PartLoops + " of " + data.Tables[0].Rows.Count + " from file " + FileLoops + " of " + FileCount + ".";
                                    lblMessages.Visible = true;
                                    // DB.ImportValidation.Parts_PartsInvoiceImportData(InvoiceNo, InvoiceDate, PurchaseOrderNo, Engineer, SiteAddress, OrderType, SupplierPartCode, Description, Quantity, UnitPrice, NetAmount, VATAmount, GrossAmount)
                                }

                                MoveProgressOn();
                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        try
                        {
                            System.IO.File.Move(CurrentFile.FullName, (string)(dr_Folders["FolderPath"] + @"\Processed\" + CurrentFile.Name));
                        }
                        catch
                        {
                        }
                    }
                }
            }

            MoveProgressOn(true);
        }

        private void ValidateOrdersWithNoParts()
        {
            Cursor.Current = Cursors.WaitCursor;
            // get my datatable and loop round

            DataView dvOrderData;
            dvOrderData = App.DB.ImportValidation.POInvoiceImport_GetOrdersWithNoParts(8);
            pbStatus.Value = 0;
            pbStatus.Maximum = dvOrderData.Count + 1;
            for (int i = 0, loopTo = dvOrderData.Count - 1; i <= loopTo; i++)
            {
                DataView dvPartsData;
                dvPartsData = App.DB.ImportValidation.POInvoiceImport_GetPOParts(dvOrderData.Table.Rows[i][3].ToString(), dvOrderData.Table.Rows[i][1].ToString());
                if (!(dvPartsData.Count == 0))
                {
                    int ValidPartCount = 0;
                    for (int p = 0, loopTo1 = dvPartsData.Count - 1; p <= loopTo1; p++)
                    {
                        if (Conversions.ToInteger(dvPartsData.Table.Rows[p][3].ToString()) < 0)
                        {
                            App.DB.ImportValidation.POInvoiceImport_UpdateFailedPart(Conversions.ToInteger(dvPartsData.Table.Rows[p][9].ToString()), Conversions.ToBoolean(1));
                        }
                        else if (Conversions.ToInteger(dvPartsData.Table.Rows[p][3].ToString()) == 0)
                        {
                            App.DB.ImportValidation.POInvoiceImport_UpdateFailedPart(Conversions.ToInteger(dvPartsData.Table.Rows[p][9].ToString()), Conversions.ToBoolean(1));
                        }
                        else if (App.DB.ImportValidation.POInvoiceImport_ValidatePart(Conversions.ToInteger(dvOrderData.Table.Rows[i][4].ToString()), dvPartsData.Table.Rows[p][1].ToString()) == 1)
                        {
                            App.DB.ImportValidation.POInvoiceImport_UpdateFailedPart(Conversions.ToInteger(dvPartsData.Table.Rows[p][9].ToString()), Conversions.ToBoolean(0));
                            ValidPartCount += 1;
                        }
                        else if (App.DB.ImportValidation.POInvoiceImport_ValidatePart(Conversions.ToInteger(dvOrderData.Table.Rows[i][4].ToString()), dvPartsData.Table.Rows[p][1].ToString()) == 0 | App.DB.ImportValidation.POInvoiceImport_ValidatePart(Conversions.ToInteger(dvOrderData.Table.Rows[i][4].ToString()), dvPartsData.Table.Rows[p][1].ToString()) > 1)
                        {
                            App.DB.ImportValidation.POInvoiceImport_UpdateFailedPart(Conversions.ToInteger(dvPartsData.Table.Rows[p][9].ToString()), Conversions.ToBoolean(1));
                        }
                    }

                    if (ValidPartCount == dvPartsData.Count)
                    {
                        // insert the parts to the purchase order and revalidate orders

                        var CurrentOrder = App.DB.Order.Order_Get(Conversions.ToInteger(dvOrderData.Table.Rows[i][14].ToString()));
                        for (int p = 0, loopTo2 = dvPartsData.Count - 1; p <= loopTo2; p++)
                        {
                            int PartID = App.DB.ImportValidation.POInvoiceImport_GetPartID(Conversions.ToInteger(dvOrderData.Table.Rows[i][4].ToString()), dvPartsData.Table.Rows[p][1].ToString());
                            var Part = App.DB.Part.Part_Get(PartID);
                            var dvPartSupplier = App.DB.PartSupplier.Get_ByPartIDAndSupplierID(PartID, Conversions.ToInteger(dvOrderData.Table.Rows[i][4].ToString()));
                            if (dvPartSupplier.Count == 0)
                            {
                            }
                            else if (dvPartSupplier.Count == 1)
                            {
                                var EngineerVisit = App.DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(CurrentOrder.OrderID);
                                var oOrderPart = new Entity.OrderParts.OrderPart();
                                oOrderPart.IgnoreExceptionsOnSetMethods = true;
                                oOrderPart.SetOrderID = CurrentOrder.OrderID;
                                oOrderPart.SetPartSupplierID = dvPartSupplier.Table.Rows[0][0].ToString();
                                oOrderPart.SetQuantity = dvPartsData.Table.Rows[p][3].ToString();
                                oOrderPart.SetBuyPrice = dvPartSupplier.Table.Rows[0][4].ToString();
                                oOrderPart.SetSellPrice = Part.SellPrice;
                                oOrderPart.SetQuantityReceived = dvPartsData.Table.Rows[p][3].ToString();
                                var val = new Entity.OrderParts.OrderPartValidator();
                                val.Validate(oOrderPart);
                                oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !CurrentOrder.DoNotConsolidated);
                                if (CurrentOrder.OrderTypeID == (int)Entity.Sys.Enums.OrderType.Job)
                                {
                                    App.DB.EngineerVisitPartProductAllocated.InsertOne(EngineerVisit.EngineerVisitID, "Part", oOrderPart.Quantity, oOrderPart.OrderPartID, PartID, 1);
                                }

                                CurrentOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Complete);
                                App.DB.Order.Update(CurrentOrder);
                            }
                            else
                            {
                                App.ShowMessage("Unable to process Part - Multiple Part Supplier Found for Part : " + dvPartsData.Table.Rows[p][1].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        App.DB.ImportValidation.POInvoiceImport_ValidateOrders(8);
                    }
                    else
                    {
                        App.DB.ImportValidation.POInvoiceImport_UpdateValidationType(Conversions.ToInteger(dvOrderData.Table.Rows[i][0].ToString()), 12);
                    }
                }

                MoveProgressOn(false);
            }

            MoveProgressOn(true);
            Cursor.Current = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnExportResults_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Enabled = false;
                DataView data;
                string sheetName = "";
                string sql = "";
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboValidateType)) == Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncludedUnableToMatchParts))
                {
                    sql = "EXEC POInvoiceImport_ExportResultsIncPartDetail " + Combo.get_GetSelectedItemValue(cboValidateType);
                    data = new DataView(App.DB.ExecuteWithReturn(sql));
                    foreach (DataColumn col in data.Table.Columns)
                    {
                        if (col.DataType == Type.GetType("System.String"))
                        {
                            foreach (DataRow row in data.Table.Rows)
                                row[col.ColumnName] = "'" + row[col.ColumnName];
                        }
                    }
                }
                else
                {
                    sql = "EXEC POInvoiceImport_ExportResults " + Combo.get_GetSelectedItemValue(cboValidateType);
                    data = new DataView(App.DB.ExecuteWithReturn(sql));
                    foreach (DataColumn col in data.Table.Columns)
                    {
                        if (col.DataType == Type.GetType("System.String"))
                        {
                            foreach (DataRow row in data.Table.Rows)
                                row[col.ColumnName] = "'" + row[col.ColumnName];
                        }
                    }
                }

                sheetName = Strings.Trim(Combo.get_GetSelectedItemDescription(cboValidateType)).Replace("(", "").Replace(")", "").Replace(" ", "");
                if (Strings.Len(sheetName) < 23)
                {
                }
                else
                {
                    sheetName = sheetName.Substring(0, 23);
                }

                sheetName = sheetName + Conversions.ToString(DateAndTime.Today).Replace("/", "");
                Entity.Sys.ExportHelper.Export(data.Table, sheetName, Entity.Sys.Enums.ExportType.CSV);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error exporting : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void llOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", App.TheSystem.Configuration.DocumentsLocation + @"PartsInvoiceFiles\");
        }

        private void btnValidateResults_Click(object sender, EventArgs e)
        {
            ValidateAllRecords();
        }

        
        

        public bool checkArray(string[] var, string Text)
        {
            if (Array.IndexOf(var, Text) > -1)
            {
                return true; // found
            }
            else
            {
                return false;
            }
        }

        public void ShowData(int ValidateType = 0)
        {
            tcData.TabPages.Clear();
            var tp = new TabPage();
            var data = new UCDataPartsInvoiceImport();
            data.Dock = DockStyle.Fill;
            data.Data = App.DB.ImportValidation.POInvoiceImport_ShowData(ValidateType);
            data.ValidateType = Combo.get_GetSelectedItemValue(cboValidateType);
            tp.Text = "PO Invoice Import Data (" + data.Data.Count + " Records)";
            tp.Controls.Add(data);
            tcData.TabPages.Add(tp);
            tcData.SelectedIndex = 0;
            MoveProgressOn(true);
        }

        private void KillInstances(Microsoft.Office.Interop.Excel.Application app)
        {
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
            GC.Collect();
            var mp = Process.GetProcessesByName("EXCEL");
            foreach (var p in mp)
            {
                try
                {
                    if (p.Responding)
                    {
                        if (string.IsNullOrEmpty(p.MainWindowTitle))
                        {
                            p.Kill();
                        }
                    }
                    else
                    {
                        p.Kill();
                    }
                }
                catch
                {
                }
            };
        }

        public void MoveProgressOn(bool toMaximum = false)
        {
            if (toMaximum)
            {
                pbStatus.Value = pbStatus.Maximum;
                lblProgress.Text = "100%";
            }
            else
            {
                pbStatus.Value += 1;
                lblProgress.Text = Math.Floor(pbStatus.Value / (double)pbStatus.Maximum * 100) + "%";
            }

            Application.DoEvents();
        }

        public void SetLastPartAttempted(string PartCode)
        {
            lblMessages.Visible = true;
            lblMessages.Text = PartCode;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ValidateOrdersWithNoParts();
        }

        /// <summary>
        /// Get nominal code for order
        /// </summary>
        /// <param name="orderId">Integer</param>
        /// <returns>Integer</returns>
        public int GetNominalCode(int orderId)
        {
            // give nominal code a default value incase db can't find anything
            int nominalCode = 5300;

            // using the orderid, get the job information
            var dvJob = App.DB.Order.Orders_GetJob(orderId);
            // populate the data with the purchase nominal data
            var dtPurchaseNominal = App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PurchaseNominal).Table;

            // check if dataview is not empty
            if (dvJob.Table.Rows.Count > 0)
            {
                // get the region id from the job
                int regionID = Entity.Sys.Helper.MakeIntegerValid(dvJob[0]["RegionID"]);

                // if the region id is gasway commerical then give it different else give it the default value
                try
                {
                    if (regionID == (int)Entity.Sys.Enums.Region.GaswayCommercial)
                    {
                        if (dtPurchaseNominal.Select("Name='Gasway Commerical'").Length > 0)
                        {
                            var row = dtPurchaseNominal.Select("Name='Gasway Commerical'")[0];
                            if (!row.IsNull("Name"))
                            {
                                nominalCode = Entity.Sys.Helper.MakeIntegerValid(row["Description"]);
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    if (dtPurchaseNominal.Select("Name='Standard'").Length > 0)
                    {
                        var row = dtPurchaseNominal.Select("Name='Standard'")[0];
                        if (!row.IsNull("Name"))
                        {
                            nominalCode = Entity.Sys.Helper.MakeIntegerValid(row["Description"]);
                        }
                    }
                }
            }

            return nominalCode;
        }
    }
}