using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMPartsToBeCreditedManager : FRMBaseForm, IForm
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
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
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._txtCreditReference = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._txtPart = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtSupplier = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._txtOrderReference = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._grpJobs = new System.Windows.Forms.GroupBox();
            this._dgCredits = new System.Windows.Forms.DataGrid();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnAddNew = new System.Windows.Forms.Button();
            this._btnGenerateCreditDocument = new System.Windows.Forms.Button();
            this._btnCreditAmount = new System.Windows.Forms.Button();
            this._grpFilter.SuspendLayout();
            this._grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCredits)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._Label5);
            this._grpFilter.Controls.Add(this._cboStatus);
            this._grpFilter.Controls.Add(this._txtCreditReference);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._txtPart);
            this._grpFilter.Controls.Add(this._Label3);
            this._grpFilter.Controls.Add(this._txtSupplier);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._txtOrderReference);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Location = new System.Drawing.Point(12, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(859, 101);
            this._grpFilter.TabIndex = 1;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _Label5
            // 
            this._Label5.AutoSize = true;
            this._Label5.Location = new System.Drawing.Point(329, 44);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(43, 13);
            this._Label5.TabIndex = 9;
            this._Label5.Text = "Status";
            // 
            // _cboStatus
            // 
            this._cboStatus.FormattingEnabled = true;
            this._cboStatus.Location = new System.Drawing.Point(439, 41);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(329, 21);
            this._cboStatus.TabIndex = 0;
            this._cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // _txtCreditReference
            // 
            this._txtCreditReference.Location = new System.Drawing.Point(439, 14);
            this._txtCreditReference.Name = "_txtCreditReference";
            this._txtCreditReference.Size = new System.Drawing.Size(206, 21);
            this._txtCreditReference.TabIndex = 8;
            this._txtCreditReference.TextChanged += new System.EventHandler(this.txtCreditReference_TextChanged);
            // 
            // _Label4
            // 
            this._Label4.AutoSize = true;
            this._Label4.Location = new System.Drawing.Point(329, 17);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(104, 13);
            this._Label4.TabIndex = 7;
            this._Label4.Text = "Credit Reference";
            // 
            // _txtPart
            // 
            this._txtPart.Location = new System.Drawing.Point(114, 68);
            this._txtPart.Name = "_txtPart";
            this._txtPart.Size = new System.Drawing.Size(206, 21);
            this._txtPart.TabIndex = 6;
            this._txtPart.TextChanged += new System.EventHandler(this.txtPart_TextChanged);
            // 
            // _Label3
            // 
            this._Label3.AutoSize = true;
            this._Label3.Location = new System.Drawing.Point(6, 71);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(30, 13);
            this._Label3.TabIndex = 5;
            this._Label3.Text = "Part";
            // 
            // _txtSupplier
            // 
            this._txtSupplier.Location = new System.Drawing.Point(114, 41);
            this._txtSupplier.Name = "_txtSupplier";
            this._txtSupplier.Size = new System.Drawing.Size(206, 21);
            this._txtSupplier.TabIndex = 3;
            this._txtSupplier.TextChanged += new System.EventHandler(this.txtSupplier_TextChanged);
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(6, 44);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(54, 13);
            this._Label2.TabIndex = 2;
            this._Label2.Text = "Supplier";
            // 
            // _txtOrderReference
            // 
            this._txtOrderReference.Location = new System.Drawing.Point(114, 14);
            this._txtOrderReference.Name = "_txtOrderReference";
            this._txtOrderReference.Size = new System.Drawing.Size(206, 21);
            this._txtOrderReference.TabIndex = 1;
            this._txtOrderReference.TextChanged += new System.EventHandler(this.txtOrderReference_TextChanged);
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(6, 17);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(102, 13);
            this._Label1.TabIndex = 0;
            this._Label1.Text = "Order Reference";
            // 
            // _grpJobs
            // 
            this._grpJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobs.Controls.Add(this._dgCredits);
            this._grpJobs.Location = new System.Drawing.Point(12, 119);
            this._grpJobs.Name = "_grpJobs";
            this._grpJobs.Size = new System.Drawing.Size(859, 335);
            this._grpJobs.TabIndex = 2;
            this._grpJobs.TabStop = false;
            this._grpJobs.Text = "Double Click To View / Edit";
            // 
            // _dgCredits
            // 
            this._dgCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgCredits.DataMember = "";
            this._dgCredits.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgCredits.Location = new System.Drawing.Point(8, 20);
            this._dgCredits.Name = "_dgCredits";
            this._dgCredits.Size = new System.Drawing.Size(843, 307);
            this._dgCredits.TabIndex = 0;
            this._dgCredits.DoubleClick += new System.EventHandler(this.dgCredits_DoubleClick);
            this._dgCredits.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgCredits_MouseUp);
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(12, 460);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 3;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnAddNew
            // 
            this._btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddNew.Location = new System.Drawing.Point(379, 460);
            this._btnAddNew.Name = "_btnAddNew";
            this._btnAddNew.Size = new System.Drawing.Size(162, 23);
            this._btnAddNew.TabIndex = 4;
            this._btnAddNew.Text = "Add New Part To Credit";
            this._btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // _btnGenerateCreditDocument
            // 
            this._btnGenerateCreditDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnGenerateCreditDocument.Location = new System.Drawing.Point(547, 460);
            this._btnGenerateCreditDocument.Name = "_btnGenerateCreditDocument";
            this._btnGenerateCreditDocument.Size = new System.Drawing.Size(176, 23);
            this._btnGenerateCreditDocument.TabIndex = 5;
            this._btnGenerateCreditDocument.Text = "Generate Credit Document";
            this._btnGenerateCreditDocument.Click += new System.EventHandler(this.btnGenerateCreditDocument_Click);
            // 
            // _btnCreditAmount
            // 
            this._btnCreditAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCreditAmount.Location = new System.Drawing.Point(729, 460);
            this._btnCreditAmount.Name = "_btnCreditAmount";
            this._btnCreditAmount.Size = new System.Drawing.Size(134, 23);
            this._btnCreditAmount.TabIndex = 0;
            this._btnCreditAmount.Text = "Add Credit Amount";
            this._btnCreditAmount.Click += new System.EventHandler(this.btnCreditAmount_Click);
            // 
            // FRMPartsToBeCreditedManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(883, 485);
            this.Controls.Add(this._btnCreditAmount);
            this.Controls.Add(this._btnGenerateCreditDocument);
            this.Controls.Add(this._btnAddNew);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._grpJobs);
            this.Controls.Add(this._btnReset);
            this.Name = "FRMPartsToBeCreditedManager";
            this.Text = "Parts To Be Credited Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRMOrderManager_Load);
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this._grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgCredits)).EndInit();
            this.ResumeLayout(false);

        }

        private GroupBox _grpFilter;

        internal GroupBox grpFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilter != null)
                {
                }

                _grpFilter = value;
                if (_grpFilter != null)
                {
                }
            }
        }

        private GroupBox _grpJobs;

        internal GroupBox grpJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobs != null)
                {
                }

                _grpJobs = value;
                if (_grpJobs != null)
                {
                }
            }
        }

        private DataGrid _dgCredits;

        internal DataGrid dgCredits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgCredits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgCredits != null)
                {
                    _dgCredits.DoubleClick -= dgCredits_DoubleClick;
                    _dgCredits.MouseUp -= dgCredits_MouseUp;
                }

                _dgCredits = value;
                if (_dgCredits != null)
                {
                    _dgCredits.DoubleClick += dgCredits_DoubleClick;
                    _dgCredits.MouseUp += dgCredits_MouseUp;
                }
            }
        }

        private Button _btnReset;

        internal Button btnReset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReset != null)
                {
                    _btnReset.Click -= btnReset_Click;
                }

                _btnReset = value;
                if (_btnReset != null)
                {
                    _btnReset.Click += btnReset_Click;
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

        private Button _btnGenerateCreditDocument;

        internal Button btnGenerateCreditDocument
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGenerateCreditDocument;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGenerateCreditDocument != null)
                {
                    _btnGenerateCreditDocument.Click -= btnGenerateCreditDocument_Click;
                }

                _btnGenerateCreditDocument = value;
                if (_btnGenerateCreditDocument != null)
                {
                    _btnGenerateCreditDocument.Click += btnGenerateCreditDocument_Click;
                }
            }
        }

        private Button _btnCreditAmount;

        internal Button btnCreditAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreditAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreditAmount != null)
                {
                    _btnCreditAmount.Click -= btnCreditAmount_Click;
                }

                _btnCreditAmount = value;
                if (_btnCreditAmount != null)
                {
                    _btnCreditAmount.Click += btnCreditAmount_Click;
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

        private ComboBox _cboStatus;

        internal ComboBox cboStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged -= cboStatus_SelectedIndexChanged;
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
                }
            }
        }

        private TextBox _txtCreditReference;

        internal TextBox txtCreditReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCreditReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCreditReference != null)
                {
                    _txtCreditReference.TextChanged -= txtCreditReference_TextChanged;
                }

                _txtCreditReference = value;
                if (_txtCreditReference != null)
                {
                    _txtCreditReference.TextChanged += txtCreditReference_TextChanged;
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
                    _txtPart.TextChanged -= txtPart_TextChanged;
                }

                _txtPart = value;
                if (_txtPart != null)
                {
                    _txtPart.TextChanged += txtPart_TextChanged;
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
                    _txtSupplier.TextChanged -= txtSupplier_TextChanged;
                }

                _txtSupplier = value;
                if (_txtSupplier != null)
                {
                    _txtSupplier.TextChanged += txtSupplier_TextChanged;
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

        private TextBox _txtOrderReference;

        internal TextBox txtOrderReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOrderReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOrderReference != null)
                {
                    _txtOrderReference.TextChanged -= txtOrderReference_TextChanged;
                }

                _txtOrderReference = value;
                if (_txtOrderReference != null)
                {
                    _txtOrderReference.TextChanged += txtOrderReference_TextChanged;
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
    }
}