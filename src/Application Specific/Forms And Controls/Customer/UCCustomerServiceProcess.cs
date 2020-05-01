using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCCustomerServiceProcess : UCBase, IUserControl
    {
        public UCCustomerServiceProcess(int _customerId) : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            CustomerId = _customerId;
            Populate();
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

        private GroupBox _grpBxServiceDate;

        private LinkLabel _lnkDownloadExampleTemplate;

        private GroupBox _grpTemplate3;

        private Button _btnDownloadTemplate3;

        internal Button btnDownloadTemplate3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDownloadTemplate3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDownloadTemplate3 != null)
                {
                    _btnDownloadTemplate3.Click -= btnDownloadTemplate3_Click;
                }

                _btnDownloadTemplate3 = value;
                if (_btnDownloadTemplate3 != null)
                {
                    _btnDownloadTemplate3.Click += btnDownloadTemplate3_Click;
                }
            }
        }

        private Button _btnAddTemplate3;

        internal Button btnAddTemplate3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddTemplate3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddTemplate3 != null)
                {
                    _btnAddTemplate3.Click -= btnAddTemplate3_Click;
                }

                _btnAddTemplate3 = value;
                if (_btnAddTemplate3 != null)
                {
                    _btnAddTemplate3.Click += btnAddTemplate3_Click;
                }
            }
        }

        private Button _btnTestTemplate3;

        internal Button btnTestTemplate3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnTestTemplate3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnTestTemplate3 != null)
                {
                    _btnTestTemplate3.Click -= btnTestTemplate3_Click;
                }

                _btnTestTemplate3 = value;
                if (_btnTestTemplate3 != null)
                {
                    _btnTestTemplate3.Click += btnTestTemplate3_Click;
                }
            }
        }

        private GroupBox _grpTemplate2;

        private Button _btnDownloadTemplate2;

        internal Button btnDownloadTemplate2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDownloadTemplate2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDownloadTemplate2 != null)
                {
                    _btnDownloadTemplate2.Click -= btnDownloadTemplate2_Click;
                }

                _btnDownloadTemplate2 = value;
                if (_btnDownloadTemplate2 != null)
                {
                    _btnDownloadTemplate2.Click += btnDownloadTemplate2_Click;
                }
            }
        }

        private Button _btnAddTemplate2;

        internal Button btnAddTemplate2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddTemplate2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddTemplate2 != null)
                {
                    _btnAddTemplate2.Click -= btnAddTemplate2_Click;
                }

                _btnAddTemplate2 = value;
                if (_btnAddTemplate2 != null)
                {
                    _btnAddTemplate2.Click += btnAddTemplate2_Click;
                }
            }
        }

        private Button _btnTestTemplate2;

        internal Button btnTestTemplate2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnTestTemplate2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnTestTemplate2 != null)
                {
                    _btnTestTemplate2.Click -= btnTestTemplate2_Click;
                }

                _btnTestTemplate2 = value;
                if (_btnTestTemplate2 != null)
                {
                    _btnTestTemplate2.Click += btnTestTemplate2_Click;
                }
            }
        }

        private GroupBox _grpTemplate1;

        private Button _btnDownloadTemplate1;

        internal Button btnDownloadTemplate1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDownloadTemplate1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDownloadTemplate1 != null)
                {
                    _btnDownloadTemplate1.Click -= btnDownloadTemplate1_Click;
                }

                _btnDownloadTemplate1 = value;
                if (_btnDownloadTemplate1 != null)
                {
                    _btnDownloadTemplate1.Click += btnDownloadTemplate1_Click;
                }
            }
        }

        private Button _btnAddTemplate1;

        internal Button btnAddTemplate1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddTemplate1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddTemplate1 != null)
                {
                    _btnAddTemplate1.Click -= btnAddTemplate1_Click;
                }

                _btnAddTemplate1 = value;
                if (_btnAddTemplate1 != null)
                {
                    _btnAddTemplate1.Click += btnAddTemplate1_Click;
                }
            }
        }

        private Button _btnTestTemplate1;

        internal Button btnTestTemplate1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnTestTemplate1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnTestTemplate1 != null)
                {
                    _btnTestTemplate1.Click -= btnTestTemplate1_Click;
                }

                _btnTestTemplate1 = value;
                if (_btnTestTemplate1 != null)
                {
                    _btnTestTemplate1.Click += btnTestTemplate1_Click;
                }
            }
        }

        private Button _btnDeleteProcess;

        private TextBox _txtAppointment3;

        internal TextBox txtAppointment3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAppointment3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAppointment3 != null)
                {
                }

                _txtAppointment3 = value;
                if (_txtAppointment3 != null)
                {
                }
            }
        }

        private Label _lblAppointment3;

        private TextBox _txtAppointment2;

        internal TextBox txtAppointment2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAppointment2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAppointment2 != null)
                {
                }

                _txtAppointment2 = value;
                if (_txtAppointment2 != null)
                {
                }
            }
        }

        private Label _lblAppointment2;

        private TextBox _txtAppointment1;

        internal TextBox txtAppointment1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAppointment1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAppointment1 != null)
                {
                }

                _txtAppointment1 = value;
                if (_txtAppointment1 != null)
                {
                }
            }
        }

        private Label _lblAppointment1;

        private TextBox _txtLetter3;

        internal TextBox txtLetter3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLetter3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLetter3 != null)
                {
                }

                _txtLetter3 = value;
                if (_txtLetter3 != null)
                {
                }
            }
        }

        private Label _lblLetter3;

        private TextBox _txtLetter2;

        internal TextBox txtLetter2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLetter2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLetter2 != null)
                {
                }

                _txtLetter2 = value;
                if (_txtLetter2 != null)
                {
                }
            }
        }

        private Label _lblLetter2;

        private TextBox _txtLetter1;

        internal TextBox txtLetter1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLetter1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLetter1 != null)
                {
                }

                _txtLetter1 = value;
                if (_txtLetter1 != null)
                {
                }
            }
        }

        private Label _lblLetter1;

        private Button _btnSaveServiceProcess;

        private GroupBox _grpPatchCheck;

        private Button _btnDownloadPatchCheckTemplate;

        internal Button btnDownloadPatchCheckTemplate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDownloadPatchCheckTemplate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDownloadPatchCheckTemplate != null)
                {
                    _btnDownloadPatchCheckTemplate.Click -= btnDownloadPatchCheckTemplate_Click;
                }

                _btnDownloadPatchCheckTemplate = value;
                if (_btnDownloadPatchCheckTemplate != null)
                {
                    _btnDownloadPatchCheckTemplate.Click += btnDownloadPatchCheckTemplate_Click;
                }
            }
        }

        private Button _btnAddPatchCheckTemplate;

        internal Button btnAddPatchCheckTemplate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddPatchCheckTemplate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddPatchCheckTemplate != null)
                {
                    _btnAddPatchCheckTemplate.Click -= btnAddPatchCheckTemplate_Click;
                }

                _btnAddPatchCheckTemplate = value;
                if (_btnAddPatchCheckTemplate != null)
                {
                    _btnAddPatchCheckTemplate.Click += btnAddPatchCheckTemplate_Click;
                }
            }
        }

        private Button _btnTestPatchCheckTemplate;

        internal Button btnTestPatchCheckTemplate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnTestPatchCheckTemplate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnTestPatchCheckTemplate != null)
                {
                    _btnTestPatchCheckTemplate.Click -= btnTestPatchCheckTemplate_Click;
                }

                _btnTestPatchCheckTemplate = value;
                if (_btnTestPatchCheckTemplate != null)
                {
                    _btnTestPatchCheckTemplate.Click += btnTestPatchCheckTemplate_Click;
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpBxServiceDate = new GroupBox();
            _grpPatchCheck = new GroupBox();
            _btnDownloadPatchCheckTemplate = new Button();
            _btnDownloadPatchCheckTemplate.Click += new EventHandler(btnDownloadPatchCheckTemplate_Click);
            _btnAddPatchCheckTemplate = new Button();
            _btnAddPatchCheckTemplate.Click += new EventHandler(btnAddPatchCheckTemplate_Click);
            _btnTestPatchCheckTemplate = new Button();
            _btnTestPatchCheckTemplate.Click += new EventHandler(btnTestPatchCheckTemplate_Click);
            _lnkDownloadExampleTemplate = new LinkLabel();
            _lnkDownloadExampleTemplate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkDownloadExampleTemplate_LinkClicked);
            _grpTemplate3 = new GroupBox();
            _btnDownloadTemplate3 = new Button();
            _btnDownloadTemplate3.Click += new EventHandler(btnDownloadTemplate3_Click);
            _btnAddTemplate3 = new Button();
            _btnAddTemplate3.Click += new EventHandler(btnAddTemplate3_Click);
            _btnTestTemplate3 = new Button();
            _btnTestTemplate3.Click += new EventHandler(btnTestTemplate3_Click);
            _grpTemplate2 = new GroupBox();
            _btnDownloadTemplate2 = new Button();
            _btnDownloadTemplate2.Click += new EventHandler(btnDownloadTemplate2_Click);
            _btnAddTemplate2 = new Button();
            _btnAddTemplate2.Click += new EventHandler(btnAddTemplate2_Click);
            _btnTestTemplate2 = new Button();
            _btnTestTemplate2.Click += new EventHandler(btnTestTemplate2_Click);
            _grpTemplate1 = new GroupBox();
            _btnDownloadTemplate1 = new Button();
            _btnDownloadTemplate1.Click += new EventHandler(btnDownloadTemplate1_Click);
            _btnAddTemplate1 = new Button();
            _btnAddTemplate1.Click += new EventHandler(btnAddTemplate1_Click);
            _btnTestTemplate1 = new Button();
            _btnTestTemplate1.Click += new EventHandler(btnTestTemplate1_Click);
            _btnDeleteProcess = new Button();
            _btnDeleteProcess.Click += new EventHandler(btnDeleteProcess_Click);
            _txtAppointment3 = new TextBox();
            _lblAppointment3 = new Label();
            _txtAppointment2 = new TextBox();
            _lblAppointment2 = new Label();
            _txtAppointment1 = new TextBox();
            _lblAppointment1 = new Label();
            _txtLetter3 = new TextBox();
            _lblLetter3 = new Label();
            _txtLetter2 = new TextBox();
            _lblLetter2 = new Label();
            _txtLetter1 = new TextBox();
            _lblLetter1 = new Label();
            _btnSaveServiceProcess = new Button();
            _btnSaveServiceProcess.Click += new EventHandler(btnSaveServiceProcess_Click);
            _grpBxServiceDate.SuspendLayout();
            _grpPatchCheck.SuspendLayout();
            _grpTemplate3.SuspendLayout();
            _grpTemplate2.SuspendLayout();
            _grpTemplate1.SuspendLayout();
            SuspendLayout();
            //
            // grpBxServiceDate
            //
            _grpBxServiceDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpBxServiceDate.Controls.Add(_grpPatchCheck);
            _grpBxServiceDate.Controls.Add(_lnkDownloadExampleTemplate);
            _grpBxServiceDate.Controls.Add(_grpTemplate3);
            _grpBxServiceDate.Controls.Add(_grpTemplate2);
            _grpBxServiceDate.Controls.Add(_grpTemplate1);
            _grpBxServiceDate.Controls.Add(_btnDeleteProcess);
            _grpBxServiceDate.Controls.Add(_txtAppointment3);
            _grpBxServiceDate.Controls.Add(_lblAppointment3);
            _grpBxServiceDate.Controls.Add(_txtAppointment2);
            _grpBxServiceDate.Controls.Add(_lblAppointment2);
            _grpBxServiceDate.Controls.Add(_txtAppointment1);
            _grpBxServiceDate.Controls.Add(_lblAppointment1);
            _grpBxServiceDate.Controls.Add(_txtLetter3);
            _grpBxServiceDate.Controls.Add(_lblLetter3);
            _grpBxServiceDate.Controls.Add(_txtLetter2);
            _grpBxServiceDate.Controls.Add(_lblLetter2);
            _grpBxServiceDate.Controls.Add(_txtLetter1);
            _grpBxServiceDate.Controls.Add(_lblLetter1);
            _grpBxServiceDate.Controls.Add(_btnSaveServiceProcess);
            _grpBxServiceDate.FlatStyle = FlatStyle.System;
            _grpBxServiceDate.Location = new Point(3, 3);
            _grpBxServiceDate.Name = "grpBxServiceDate";
            _grpBxServiceDate.Size = new Size(621, 550);
            _grpBxServiceDate.TabIndex = 3;
            _grpBxServiceDate.TabStop = false;
            _grpBxServiceDate.Text = "Service Process";
            //
            // grpPatchCheck
            //
            _grpPatchCheck.Controls.Add(_btnDownloadPatchCheckTemplate);
            _grpPatchCheck.Controls.Add(_btnAddPatchCheckTemplate);
            _grpPatchCheck.Controls.Add(_btnTestPatchCheckTemplate);
            _grpPatchCheck.Location = new Point(13, 371);
            _grpPatchCheck.Name = "grpPatchCheck";
            _grpPatchCheck.Size = new Size(358, 61);
            _grpPatchCheck.TabIndex = 165;
            _grpPatchCheck.TabStop = false;
            _grpPatchCheck.Text = "Patch Check";
            //
            // btnDownloadPatchCheckTemplate
            //
            _btnDownloadPatchCheckTemplate.Location = new Point(127, 22);
            _btnDownloadPatchCheckTemplate.Name = "btnDownloadPatchCheckTemplate";
            _btnDownloadPatchCheckTemplate.Size = new Size(86, 25);
            _btnDownloadPatchCheckTemplate.TabIndex = 157;
            _btnDownloadPatchCheckTemplate.Text = "Download";
            _btnDownloadPatchCheckTemplate.Visible = false;
            //
            // btnAddPatchCheckTemplate
            //
            _btnAddPatchCheckTemplate.Location = new Point(10, 22);
            _btnAddPatchCheckTemplate.Name = "btnAddPatchCheckTemplate";
            _btnAddPatchCheckTemplate.Size = new Size(70, 25);
            _btnAddPatchCheckTemplate.TabIndex = 148;
            _btnAddPatchCheckTemplate.Text = "Add";
            //
            // btnTestPatchCheckTemplate
            //
            _btnTestPatchCheckTemplate.Location = new Point(260, 22);
            _btnTestPatchCheckTemplate.Name = "btnTestPatchCheckTemplate";
            _btnTestPatchCheckTemplate.Size = new Size(70, 25);
            _btnTestPatchCheckTemplate.TabIndex = 156;
            _btnTestPatchCheckTemplate.Text = "Test";
            _btnTestPatchCheckTemplate.Visible = false;
            //
            // lnkDownloadExampleTemplate
            //
            _lnkDownloadExampleTemplate.AutoSize = true;
            _lnkDownloadExampleTemplate.Location = new Point(433, 28);
            _lnkDownloadExampleTemplate.Name = "lnkDownloadExampleTemplate";
            _lnkDownloadExampleTemplate.Size = new Size(172, 13);
            _lnkDownloadExampleTemplate.TabIndex = 164;
            _lnkDownloadExampleTemplate.TabStop = true;
            _lnkDownloadExampleTemplate.Text = "Download Example Template";
            //
            // grpTemplate3
            //
            _grpTemplate3.Controls.Add(_btnDownloadTemplate3);
            _grpTemplate3.Controls.Add(_btnAddTemplate3);
            _grpTemplate3.Controls.Add(_btnTestTemplate3);
            _grpTemplate3.Location = new Point(13, 283);
            _grpTemplate3.Name = "grpTemplate3";
            _grpTemplate3.Size = new Size(358, 61);
            _grpTemplate3.TabIndex = 163;
            _grpTemplate3.TabStop = false;
            _grpTemplate3.Text = "Template";
            //
            // btnDownloadTemplate3
            //
            _btnDownloadTemplate3.Location = new Point(127, 22);
            _btnDownloadTemplate3.Name = "btnDownloadTemplate3";
            _btnDownloadTemplate3.Size = new Size(86, 25);
            _btnDownloadTemplate3.TabIndex = 157;
            _btnDownloadTemplate3.Text = "Download";
            _btnDownloadTemplate3.Visible = false;
            //
            // btnAddTemplate3
            //
            _btnAddTemplate3.Location = new Point(10, 22);
            _btnAddTemplate3.Name = "btnAddTemplate3";
            _btnAddTemplate3.Size = new Size(70, 25);
            _btnAddTemplate3.TabIndex = 148;
            _btnAddTemplate3.Text = "Add";
            //
            // btnTestTemplate3
            //
            _btnTestTemplate3.Location = new Point(260, 22);
            _btnTestTemplate3.Name = "btnTestTemplate3";
            _btnTestTemplate3.Size = new Size(70, 25);
            _btnTestTemplate3.TabIndex = 156;
            _btnTestTemplate3.Text = "Test";
            _btnTestTemplate3.Visible = false;
            //
            // grpTemplate2
            //
            _grpTemplate2.Controls.Add(_btnDownloadTemplate2);
            _grpTemplate2.Controls.Add(_btnAddTemplate2);
            _grpTemplate2.Controls.Add(_btnTestTemplate2);
            _grpTemplate2.Location = new Point(13, 170);
            _grpTemplate2.Name = "grpTemplate2";
            _grpTemplate2.Size = new Size(358, 61);
            _grpTemplate2.TabIndex = 162;
            _grpTemplate2.TabStop = false;
            _grpTemplate2.Text = "Template";
            //
            // btnDownloadTemplate2
            //
            _btnDownloadTemplate2.Location = new Point(127, 22);
            _btnDownloadTemplate2.Name = "btnDownloadTemplate2";
            _btnDownloadTemplate2.Size = new Size(86, 25);
            _btnDownloadTemplate2.TabIndex = 157;
            _btnDownloadTemplate2.Text = "Download";
            _btnDownloadTemplate2.Visible = false;
            //
            // btnAddTemplate2
            //
            _btnAddTemplate2.Location = new Point(10, 22);
            _btnAddTemplate2.Name = "btnAddTemplate2";
            _btnAddTemplate2.Size = new Size(70, 25);
            _btnAddTemplate2.TabIndex = 148;
            _btnAddTemplate2.Text = "Add";
            //
            // btnTestTemplate2
            //
            _btnTestTemplate2.Location = new Point(260, 22);
            _btnTestTemplate2.Name = "btnTestTemplate2";
            _btnTestTemplate2.Size = new Size(70, 25);
            _btnTestTemplate2.TabIndex = 156;
            _btnTestTemplate2.Text = "Test";
            _btnTestTemplate2.Visible = false;
            //
            // grpTemplate1
            //
            _grpTemplate1.Controls.Add(_btnDownloadTemplate1);
            _grpTemplate1.Controls.Add(_btnAddTemplate1);
            _grpTemplate1.Controls.Add(_btnTestTemplate1);
            _grpTemplate1.Location = new Point(13, 55);
            _grpTemplate1.Name = "grpTemplate1";
            _grpTemplate1.Size = new Size(358, 61);
            _grpTemplate1.TabIndex = 161;
            _grpTemplate1.TabStop = false;
            _grpTemplate1.Text = "Template";
            //
            // btnDownloadTemplate1
            //
            _btnDownloadTemplate1.Location = new Point(127, 22);
            _btnDownloadTemplate1.Name = "btnDownloadTemplate1";
            _btnDownloadTemplate1.Size = new Size(86, 25);
            _btnDownloadTemplate1.TabIndex = 157;
            _btnDownloadTemplate1.Text = "Download";
            _btnDownloadTemplate1.Visible = false;
            //
            // btnAddTemplate1
            //
            _btnAddTemplate1.Location = new Point(10, 22);
            _btnAddTemplate1.Name = "btnAddTemplate1";
            _btnAddTemplate1.Size = new Size(70, 25);
            _btnAddTemplate1.TabIndex = 148;
            _btnAddTemplate1.Text = "Add";
            //
            // btnTestTemplate1
            //
            _btnTestTemplate1.Location = new Point(260, 22);
            _btnTestTemplate1.Name = "btnTestTemplate1";
            _btnTestTemplate1.Size = new Size(70, 25);
            _btnTestTemplate1.TabIndex = 156;
            _btnTestTemplate1.Text = "Test";
            _btnTestTemplate1.Visible = false;
            //
            // btnDeleteProcess
            //
            _btnDeleteProcess.Location = new Point(13, 508);
            _btnDeleteProcess.Name = "btnDeleteProcess";
            _btnDeleteProcess.Size = new Size(90, 23);
            _btnDeleteProcess.TabIndex = 146;
            _btnDeleteProcess.Text = "Delete";
            //
            // txtAppointment3
            //
            _txtAppointment3.Location = new Point(274, 256);
            _txtAppointment3.Name = "txtAppointment3";
            _txtAppointment3.Size = new Size(57, 21);
            _txtAppointment3.TabIndex = 145;
            //
            // lblAppointment3
            //
            _lblAppointment3.AutoSize = true;
            _lblAppointment3.Location = new Point(169, 259);
            _lblAppointment3.Name = "lblAppointment3";
            _lblAppointment3.Size = new Size(90, 13);
            _lblAppointment3.TabIndex = 144;
            _lblAppointment3.Text = "Appointment 3";
            //
            // txtAppointment2
            //
            _txtAppointment2.Location = new Point(274, 143);
            _txtAppointment2.Name = "txtAppointment2";
            _txtAppointment2.Size = new Size(57, 21);
            _txtAppointment2.TabIndex = 143;
            //
            // lblAppointment2
            //
            _lblAppointment2.AutoSize = true;
            _lblAppointment2.Location = new Point(169, 146);
            _lblAppointment2.Name = "lblAppointment2";
            _lblAppointment2.Size = new Size(90, 13);
            _lblAppointment2.TabIndex = 142;
            _lblAppointment2.Text = "Appointment 2";
            //
            // txtAppointment1
            //
            _txtAppointment1.Location = new Point(274, 28);
            _txtAppointment1.Name = "txtAppointment1";
            _txtAppointment1.Size = new Size(57, 21);
            _txtAppointment1.TabIndex = 141;
            //
            // lblAppointment1
            //
            _lblAppointment1.AutoSize = true;
            _lblAppointment1.Location = new Point(169, 31);
            _lblAppointment1.Name = "lblAppointment1";
            _lblAppointment1.Size = new Size(90, 13);
            _lblAppointment1.TabIndex = 140;
            _lblAppointment1.Text = "Appointment 1";
            //
            // txtLetter3
            //
            _txtLetter3.Location = new Point(88, 256);
            _txtLetter3.Name = "txtLetter3";
            _txtLetter3.Size = new Size(57, 21);
            _txtLetter3.TabIndex = 139;
            //
            // lblLetter3
            //
            _lblLetter3.AutoSize = true;
            _lblLetter3.Location = new Point(20, 259);
            _lblLetter3.Name = "lblLetter3";
            _lblLetter3.Size = new Size(51, 13);
            _lblLetter3.TabIndex = 138;
            _lblLetter3.Text = "Letter 3";
            //
            // txtLetter2
            //
            _txtLetter2.Location = new Point(88, 143);
            _txtLetter2.Name = "txtLetter2";
            _txtLetter2.Size = new Size(57, 21);
            _txtLetter2.TabIndex = 137;
            //
            // lblLetter2
            //
            _lblLetter2.AutoSize = true;
            _lblLetter2.Location = new Point(20, 146);
            _lblLetter2.Name = "lblLetter2";
            _lblLetter2.Size = new Size(51, 13);
            _lblLetter2.TabIndex = 136;
            _lblLetter2.Text = "Letter 2";
            //
            // txtLetter1
            //
            _txtLetter1.Location = new Point(88, 28);
            _txtLetter1.Name = "txtLetter1";
            _txtLetter1.Size = new Size(57, 21);
            _txtLetter1.TabIndex = 135;
            //
            // lblLetter1
            //
            _lblLetter1.AutoSize = true;
            _lblLetter1.Location = new Point(20, 31);
            _lblLetter1.Name = "lblLetter1";
            _lblLetter1.Size = new Size(51, 13);
            _lblLetter1.TabIndex = 134;
            _lblLetter1.Text = "Letter 1";
            //
            // btnSaveServiceProcess
            //
            _btnSaveServiceProcess.Location = new Point(515, 508);
            _btnSaveServiceProcess.Name = "btnSaveServiceProcess";
            _btnSaveServiceProcess.Size = new Size(90, 23);
            _btnSaveServiceProcess.TabIndex = 61;
            _btnSaveServiceProcess.Text = "Save";
            //
            // UCCustomerServiceProcess
            //
            Controls.Add(_grpBxServiceDate);
            Name = "UCCustomerServiceProcess";
            Size = new Size(640, 569);
            _grpBxServiceDate.ResumeLayout(false);
            _grpBxServiceDate.PerformLayout();
            _grpPatchCheck.ResumeLayout(false);
            _grpTemplate3.ResumeLayout(false);
            _grpTemplate2.ResumeLayout(false);
            _grpTemplate1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private int _customerId;

        public int CustomerId
        {
            get
            {
                return _customerId;
            }

            set
            {
                _customerId = value;
            }
        }

        private Entity.Customers.CustomerServiceProcess _serviceProcess;

        public Entity.Customers.CustomerServiceProcess ServiceProcess
        {
            get
            {
                return _serviceProcess;
            }

            set
            {
                _serviceProcess = value;
                if (_serviceProcess is null)
                {
                    _serviceProcess = new Entity.Customers.CustomerServiceProcess();
                    _serviceProcess.Exists = false;
                }
            }
        }

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public object LoadedItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        private void btnSaveServiceProcess_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDeleteProcess_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin))
            {
                string msg = "You do not have the necessary security permissions to edit this information.";
                throw new System.Security.SecurityException(msg);
            }

            if (Helper.MakeIntegerValid(ServiceProcess?.CustomerServiceProcessID) == 0)
            {
                return;
            }

            try
            {
                if (!App.DB.Customer.CustomerServiceProcess_Delete(ServiceProcess.CustomerServiceProcessID))
                {
                    throw new Exception("Failed to delete!");
                }

                Populate();
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTemplate1_Click(object sender, EventArgs e)
        {
            var template = TemplateHelper.AddTemplate();
            if (template is object)
            {
                ServiceProcess.Template1 = template;
                btnAddTemplate1.Text = "Change";
                btnTestTemplate1.Visible = true;
                btnDownloadTemplate1.Visible = true;
            }
            else if (ServiceProcess.Template1 is object)
            {
                btnAddTemplate1.Text = "Change";
                btnTestTemplate1.Visible = true;
                btnDownloadTemplate1.Visible = true;
            }
            else
            {
                btnAddTemplate1.Text = "Add";
                btnTestTemplate1.Visible = false;
                btnDownloadTemplate1.Visible = false;
            }
        }

        private void btnAddTemplate2_Click(object sender, EventArgs e)
        {
            var template = TemplateHelper.AddTemplate();
            if (template is object)
            {
                ServiceProcess.Template2 = template;
                btnAddTemplate2.Text = "Change";
                btnTestTemplate2.Visible = true;
                btnDownloadTemplate2.Visible = true;
            }
            else if (ServiceProcess.Template2 is object)
            {
                btnAddTemplate2.Text = "Change";
                btnTestTemplate2.Visible = true;
                btnDownloadTemplate2.Visible = true;
            }
            else
            {
                btnAddTemplate2.Text = "Add";
                btnTestTemplate2.Visible = false;
                btnDownloadTemplate2.Visible = false;
            }
        }

        private void btnAddTemplate3_Click(object sender, EventArgs e)
        {
            var template = TemplateHelper.AddTemplate();
            if (template is object)
            {
                ServiceProcess.Template3 = template;
                btnAddTemplate3.Text = "Change";
                btnTestTemplate3.Visible = true;
                btnDownloadTemplate3.Visible = true;
            }
            else if (ServiceProcess.Template3 is object)
            {
                btnAddTemplate3.Text = "Change";
                btnTestTemplate3.Visible = true;
                btnDownloadTemplate3.Visible = true;
            }
            else
            {
                btnAddTemplate3.Text = "Add";
                btnTestTemplate3.Visible = false;
                btnDownloadTemplate3.Visible = false;
            }
        }

        private void btnAddPatchCheckTemplate_Click(object sender, EventArgs e)
        {
            var template = TemplateHelper.AddTemplate();
            if (template is object)
            {
                ServiceProcess.PatchCheckTemplate = template;
                btnAddPatchCheckTemplate.Text = "Change";
                btnTestPatchCheckTemplate.Visible = true;
                btnDownloadPatchCheckTemplate.Visible = true;
            }
            else if (ServiceProcess.PatchCheckTemplate is object)
            {
                btnAddPatchCheckTemplate.Text = "Change";
                btnTestPatchCheckTemplate.Visible = true;
                btnDownloadPatchCheckTemplate.Visible = true;
            }
            else
            {
                btnAddPatchCheckTemplate.Text = "Add";
                btnTestPatchCheckTemplate.Visible = false;
                btnDownloadPatchCheckTemplate.Visible = false;
            }
        }

        private void btnTestTemplate1_Click(object sender, EventArgs e)
        {
            if (ServiceProcess.Template1 is object)
                TemplateHelper.TestTemplate(ServiceProcess.Template1, Enums.TemplateType.ServiceLetter);
        }

        private void btnTestTemplate2_Click(object sender, EventArgs e)
        {
            if (ServiceProcess.Template2 is object)
                TemplateHelper.TestTemplate(ServiceProcess.Template2, Enums.TemplateType.ServiceLetter);
        }

        private void btnTestTemplate3_Click(object sender, EventArgs e)
        {
            if (ServiceProcess.Template3 is object)
                TemplateHelper.TestTemplate(ServiceProcess.Template3, Enums.TemplateType.ServiceLetter);
        }

        private void btnTestPatchCheckTemplate_Click(object sender, EventArgs e)
        {
            if (ServiceProcess.PatchCheckTemplate is object)
                TemplateHelper.TestTemplate(ServiceProcess.PatchCheckTemplate, Enums.TemplateType.ServiceLetter);
        }

        private void btnDownloadTemplate1_Click(object sender, EventArgs e)
        {
            if (ServiceProcess.Template1 is object)
                TemplateHelper.DownloadTemplate(ServiceProcess.Template1);
        }

        private void btnDownloadTemplate2_Click(object sender, EventArgs e)
        {
            if (ServiceProcess.Template2 is object)
                TemplateHelper.DownloadTemplate(ServiceProcess.Template2);
        }

        private void btnDownloadTemplate3_Click(object sender, EventArgs e)
        {
            if (ServiceProcess.Template3 is object)
                TemplateHelper.DownloadTemplate(ServiceProcess.Template3);
        }

        private void btnDownloadPatchCheckTemplate_Click(object sender, EventArgs e)
        {
            if (ServiceProcess.PatchCheckTemplate is object)
                TemplateHelper.DownloadTemplate(ServiceProcess.PatchCheckTemplate);
        }

        private void lnkDownloadExampleTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string savePath = dlg.SelectedPath + @"\ServiceLetterTemplate.docx";
                    File.Copy(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\ServiceLetters\ServiceLetterExample.docx", savePath);
                    App.ShowMessage("File downloaded to " + dlg.SelectedPath + @"\ServiceLetterTemplate.docx", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Template could not be saved : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dlg.Dispose();
                Cursor.Current = Cursors.Default;
            }
        }

        public void Populate(int ID = 0)
        {
            ServiceProcess = App.DB.Customer.CustomerServiceProcess_Get_ForCustomer(CustomerId);
            txtLetter1.Text = ServiceProcess.Letter1.ToString();
            txtLetter2.Text = ServiceProcess.Letter2.ToString();
            txtLetter3.Text = ServiceProcess.Letter3.ToString();
            txtAppointment1.Text = ServiceProcess.Appointment1.ToString();
            txtAppointment2.Text = ServiceProcess.Appointment2.ToString();
            txtAppointment3.Text = ServiceProcess.Appointment3.ToString();
            btnAddTemplate1.Text = ServiceProcess.Template1 is object ? "Change" : "Add";
            btnTestTemplate1.Visible = ServiceProcess.Template1 is object;
            btnDownloadTemplate1.Visible = ServiceProcess.Template1 is object;
            btnAddTemplate2.Text = ServiceProcess.Template2 is object ? "Change" : "Add";
            btnTestTemplate2.Visible = ServiceProcess.Template2 is object;
            btnDownloadTemplate2.Visible = ServiceProcess.Template2 is object;
            btnAddTemplate3.Text = ServiceProcess.Template3 is object ? "Change" : "Add";
            btnTestTemplate3.Visible = ServiceProcess.Template3 is object;
            btnDownloadTemplate3.Visible = ServiceProcess.Template3 is object;
            btnAddPatchCheckTemplate.Text = ServiceProcess.PatchCheckTemplate is object ? "Change" : "Add";
            btnTestPatchCheckTemplate.Visible = ServiceProcess.PatchCheckTemplate is object;
            btnDownloadPatchCheckTemplate.Visible = ServiceProcess.PatchCheckTemplate is object;
        }

        public bool Save()
        {
            try
            {
                if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.IT))
                {
                    string msg = "You do not have the necessary security permissions to edit this information.";
                    throw new System.Security.SecurityException(msg);
                }

                if (App.ShowMessage("Save service process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    {
                        var withBlock = ServiceProcess;
                        withBlock.SetCustomerID = CustomerId;
                        withBlock.SetLetter1 = Helper.MakeIntegerValid(txtLetter1.Text);
                        withBlock.SetLetter2 = Helper.MakeIntegerValid(txtLetter2.Text);
                        withBlock.SetLetter3 = Helper.MakeIntegerValid(txtLetter3.Text);
                        withBlock.SetAppointment1 = Helper.MakeIntegerValid(txtAppointment1.Text);
                        withBlock.SetAppointment2 = Helper.MakeIntegerValid(txtAppointment2.Text);
                        withBlock.SetAppointment3 = Helper.MakeIntegerValid(txtAppointment3.Text);
                    }

                    if (!App.DB.Customer.CustomerServiceProcess_Update(ServiceProcess))
                    {
                        throw new Exception("Failed to save!");
                    }

                    App.ShowMessage("Process saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error saving details : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return default;
        }
    }
}