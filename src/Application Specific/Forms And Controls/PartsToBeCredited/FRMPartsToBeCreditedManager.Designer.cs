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
            _grpFilter = new GroupBox();
            _Label5 = new Label();
            _cboStatus = new ComboBox();
            _cboStatus.SelectedIndexChanged += new EventHandler(cboStatus_SelectedIndexChanged);
            _txtCreditReference = new TextBox();
            _txtCreditReference.TextChanged += new EventHandler(txtCreditReference_TextChanged);
            _Label4 = new Label();
            _txtPart = new TextBox();
            _txtPart.TextChanged += new EventHandler(txtPart_TextChanged);
            _Label3 = new Label();
            _txtSupplier = new TextBox();
            _txtSupplier.TextChanged += new EventHandler(txtSupplier_TextChanged);
            _Label2 = new Label();
            _txtOrderReference = new TextBox();
            _txtOrderReference.TextChanged += new EventHandler(txtOrderReference_TextChanged);
            _Label1 = new Label();
            _grpJobs = new GroupBox();
            _dgCredits = new DataGrid();
            _dgCredits.DoubleClick += new EventHandler(dgCredits_DoubleClick);
            _dgCredits.MouseUp += new MouseEventHandler(dgCredits_MouseUp);
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _btnGenerateCreditDocument = new Button();
            _btnGenerateCreditDocument.Click += new EventHandler(btnGenerateCreditDocument_Click);
            _btnCreditAmount = new Button();
            _btnCreditAmount.Click += new EventHandler(btnCreditAmount_Click);
            _grpFilter.SuspendLayout();
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCredits).BeginInit();
            SuspendLayout();
            // 
            // grpFilter
            // 
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_Label5);
            _grpFilter.Controls.Add(_cboStatus);
            _grpFilter.Controls.Add(_txtCreditReference);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_txtPart);
            _grpFilter.Controls.Add(_Label3);
            _grpFilter.Controls.Add(_txtSupplier);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_txtOrderReference);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Location = new Point(12, 38);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(859, 101);
            _grpFilter.TabIndex = 1;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            // 
            // Label5
            // 
            _Label5.AutoSize = true;
            _Label5.Location = new Point(329, 44);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(43, 13);
            _Label5.TabIndex = 9;
            _Label5.Text = "Status";
            // 
            // cboStatus
            // 
            _cboStatus.FormattingEnabled = true;
            _cboStatus.Location = new Point(439, 41);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(329, 21);
            _cboStatus.TabIndex = 0;
            // 
            // txtCreditReference
            // 
            _txtCreditReference.Location = new Point(439, 14);
            _txtCreditReference.Name = "txtCreditReference";
            _txtCreditReference.Size = new Size(206, 21);
            _txtCreditReference.TabIndex = 8;
            // 
            // Label4
            // 
            _Label4.AutoSize = true;
            _Label4.Location = new Point(329, 17);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(104, 13);
            _Label4.TabIndex = 7;
            _Label4.Text = "Credit Reference";
            // 
            // txtPart
            // 
            _txtPart.Location = new Point(114, 68);
            _txtPart.Name = "txtPart";
            _txtPart.Size = new Size(206, 21);
            _txtPart.TabIndex = 6;
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Location = new Point(6, 71);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(30, 13);
            _Label3.TabIndex = 5;
            _Label3.Text = "Part";
            // 
            // txtSupplier
            // 
            _txtSupplier.Location = new Point(114, 41);
            _txtSupplier.Name = "txtSupplier";
            _txtSupplier.Size = new Size(206, 21);
            _txtSupplier.TabIndex = 3;
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 44);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(54, 13);
            _Label2.TabIndex = 2;
            _Label2.Text = "Supplier";
            // 
            // txtOrderReference
            // 
            _txtOrderReference.Location = new Point(114, 14);
            _txtOrderReference.Name = "txtOrderReference";
            _txtOrderReference.Size = new Size(206, 21);
            _txtOrderReference.TabIndex = 1;
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(6, 17);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(102, 13);
            _Label1.TabIndex = 0;
            _Label1.Text = "Order Reference";
            // 
            // grpJobs
            // 
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgCredits);
            _grpJobs.Location = new Point(12, 145);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(859, 309);
            _grpJobs.TabIndex = 2;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Double Click To View / Edit";
            // 
            // dgCredits
            // 
            _dgCredits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgCredits.DataMember = "";
            _dgCredits.HeaderForeColor = SystemColors.ControlText;
            _dgCredits.Location = new Point(8, 20);
            _dgCredits.Name = "dgCredits";
            _dgCredits.Size = new Size(843, 281);
            _dgCredits.TabIndex = 0;
            // 
            // btnReset
            // 
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(12, 460);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 3;
            _btnReset.Text = "Reset";
            // 
            // btnAddNew
            // 
            _btnAddNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddNew.Location = new Point(379, 460);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.Size = new Size(162, 23);
            _btnAddNew.TabIndex = 4;
            _btnAddNew.Text = "Add New Part To Credit";
            // 
            // btnGenerateCreditDocument
            // 
            _btnGenerateCreditDocument.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnGenerateCreditDocument.Location = new Point(547, 460);
            _btnGenerateCreditDocument.Name = "btnGenerateCreditDocument";
            _btnGenerateCreditDocument.Size = new Size(176, 23);
            _btnGenerateCreditDocument.TabIndex = 5;
            _btnGenerateCreditDocument.Text = "Generate Credit Document";
            // 
            // btnCreditAmount
            // 
            _btnCreditAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnCreditAmount.Location = new Point(729, 460);
            _btnCreditAmount.Name = "btnCreditAmount";
            _btnCreditAmount.Size = new Size(134, 23);
            _btnCreditAmount.TabIndex = 0;
            _btnCreditAmount.Text = "Add Credit Amount";
            // 
            // FRMPartsToBeCreditedManager
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(883, 485);
            Controls.Add(_btnCreditAmount);
            Controls.Add(_btnGenerateCreditDocument);
            Controls.Add(_btnAddNew);
            Controls.Add(_grpFilter);
            Controls.Add(_grpJobs);
            Controls.Add(_btnReset);
            Name = "FRMPartsToBeCreditedManager";
            Text = "Parts To Be Credited Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_btnAddNew, 0);
            Controls.SetChildIndex(_btnGenerateCreditDocument, 0);
            Controls.SetChildIndex(_btnCreditAmount, 0);
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgCredits).EndInit();
            Load += new EventHandler(FRMOrderManager_Load);
            ResumeLayout(false);
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