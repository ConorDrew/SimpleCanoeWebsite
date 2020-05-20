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
    public class FRMCheckListManager : FRMBaseForm, IForm
    {
        

        public FRMCheckListManager() : base()
        {
            
            
            base.Load += FRMCheckListManager_Load;

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
        private GroupBox _grpSections;

        internal GroupBox grpSections
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSections;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSections != null)
                {
                }

                _grpSections = value;
                if (_grpSections != null)
                {
                }
            }
        }

        private DataGrid _dgSection;

        internal DataGrid dgSection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSection != null)
                {
                    _dgSection.Click -= dgSection_Click;
                }

                _dgSection = value;
                if (_dgSection != null)
                {
                    _dgSection.Click += dgSection_Click;
                }
            }
        }

        private Button _btnRemoveSection;

        internal Button btnRemoveSection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveSection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveSection != null)
                {
                    _btnRemoveSection.Click -= btnRemoveSection_Click;
                }

                _btnRemoveSection = value;
                if (_btnRemoveSection != null)
                {
                    _btnRemoveSection.Click += btnRemoveSection_Click;
                }
            }
        }

        private Button _btnUpdateSection;

        internal Button btnUpdateSection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdateSection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdateSection != null)
                {
                    _btnUpdateSection.Click -= btnUpdateSection_Click;
                }

                _btnUpdateSection = value;
                if (_btnUpdateSection != null)
                {
                    _btnUpdateSection.Click += btnUpdateSection_Click;
                }
            }
        }

        private TextBox _txtSection;

        internal TextBox txtSection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSection != null)
                {
                }

                _txtSection = value;
                if (_txtSection != null)
                {
                }
            }
        }

        private GroupBox _grpAreas;

        internal GroupBox grpAreas
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAreas;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAreas != null)
                {
                }

                _grpAreas = value;
                if (_grpAreas != null)
                {
                }
            }
        }

        private Button _btnUpdateArea;

        internal Button btnUpdateArea
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdateArea;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdateArea != null)
                {
                    _btnUpdateArea.Click -= btnUpdateArea_Click;
                }

                _btnUpdateArea = value;
                if (_btnUpdateArea != null)
                {
                    _btnUpdateArea.Click += btnUpdateArea_Click;
                }
            }
        }

        private Button _btnRemoveArea;

        internal Button btnRemoveArea
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveArea;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveArea != null)
                {
                    _btnRemoveArea.Click -= btnRemoveArea_Click;
                }

                _btnRemoveArea = value;
                if (_btnRemoveArea != null)
                {
                    _btnRemoveArea.Click += btnRemoveArea_Click;
                }
            }
        }

        private DataGrid _dgArea;

        internal DataGrid dgArea
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgArea;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgArea != null)
                {
                    _dgArea.Click -= dgArea_Click;
                }

                _dgArea = value;
                if (_dgArea != null)
                {
                    _dgArea.Click += dgArea_Click;
                }
            }
        }

        private DataGrid _dgTask;

        internal DataGrid dgTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgTask != null)
                {
                    _dgTask.Click -= dgTask_Click;
                }

                _dgTask = value;
                if (_dgTask != null)
                {
                    _dgTask.Click += dgTask_Click;
                }
            }
        }

        private DataGrid _dgSubTask;

        internal DataGrid dgSubTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSubTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSubTask != null)
                {
                    _dgSubTask.Click -= dgSubTask_Click;
                }

                _dgSubTask = value;
                if (_dgSubTask != null)
                {
                    _dgSubTask.Click += dgSubTask_Click;
                }
            }
        }

        private GroupBox _grpTasks;

        internal GroupBox grpTasks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpTasks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpTasks != null)
                {
                }

                _grpTasks = value;
                if (_grpTasks != null)
                {
                }
            }
        }

        private GroupBox _grpSubTask;

        internal GroupBox grpSubTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSubTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSubTask != null)
                {
                }

                _grpSubTask = value;
                if (_grpSubTask != null)
                {
                }
            }
        }

        private Button _btnRemoveTask;

        internal Button btnRemoveTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveTask != null)
                {
                    _btnRemoveTask.Click -= btnRemoveTask_Click;
                }

                _btnRemoveTask = value;
                if (_btnRemoveTask != null)
                {
                    _btnRemoveTask.Click += btnRemoveTask_Click;
                }
            }
        }

        private Button _btnRemoveSubTask;

        internal Button btnRemoveSubTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveSubTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveSubTask != null)
                {
                    _btnRemoveSubTask.Click -= btnRemoveSubTask_Click;
                }

                _btnRemoveSubTask = value;
                if (_btnRemoveSubTask != null)
                {
                    _btnRemoveSubTask.Click += btnRemoveSubTask_Click;
                }
            }
        }

        private TextBox _txtArea;

        internal TextBox txtArea
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtArea;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtArea != null)
                {
                }

                _txtArea = value;
                if (_txtArea != null)
                {
                }
            }
        }

        private TextBox _txtTasks;

        internal TextBox txtTasks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTasks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTasks != null)
                {
                }

                _txtTasks = value;
                if (_txtTasks != null)
                {
                }
            }
        }

        private TextBox _txtSubTasks;

        internal TextBox txtSubTasks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSubTasks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSubTasks != null)
                {
                }

                _txtSubTasks = value;
                if (_txtSubTasks != null)
                {
                }
            }
        }

        private Button _btnUpdateTask;

        internal Button btnUpdateTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdateTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdateTask != null)
                {
                    _btnUpdateTask.Click -= btnUpdateTask_Click;
                }

                _btnUpdateTask = value;
                if (_btnUpdateTask != null)
                {
                    _btnUpdateTask.Click += btnUpdateTask_Click;
                }
            }
        }

        private Button _btnUpdateSubTask;

        internal Button btnUpdateSubTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdateSubTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdateSubTask != null)
                {
                    _btnUpdateSubTask.Click -= btnUpdateSubTask_Click;
                }

                _btnUpdateSubTask = value;
                if (_btnUpdateSubTask != null)
                {
                    _btnUpdateSubTask.Click += btnUpdateSubTask_Click;
                }
            }
        }

        private Button _btnMoveDownArea;

        internal Button btnMoveDownArea
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMoveDownArea;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMoveDownArea != null)
                {
                    _btnMoveDownArea.Click -= btnMoveDownArea_Click;
                }

                _btnMoveDownArea = value;
                if (_btnMoveDownArea != null)
                {
                    _btnMoveDownArea.Click += btnMoveDownArea_Click;
                }
            }
        }

        private Button _btnMoveUpArea;

        internal Button btnMoveUpArea
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMoveUpArea;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMoveUpArea != null)
                {
                    _btnMoveUpArea.Click -= btnMoveUpArea_Click;
                }

                _btnMoveUpArea = value;
                if (_btnMoveUpArea != null)
                {
                    _btnMoveUpArea.Click += btnMoveUpArea_Click;
                }
            }
        }

        private Button _btnMoveDownTask;

        internal Button btnMoveDownTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMoveDownTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMoveDownTask != null)
                {
                    _btnMoveDownTask.Click -= btnMoveDownTask_Click;
                }

                _btnMoveDownTask = value;
                if (_btnMoveDownTask != null)
                {
                    _btnMoveDownTask.Click += btnMoveDownTask_Click;
                }
            }
        }

        private Button _btnMoveUpTask;

        internal Button btnMoveUpTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMoveUpTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMoveUpTask != null)
                {
                    _btnMoveUpTask.Click -= btnMoveUpTask_Click;
                }

                _btnMoveUpTask = value;
                if (_btnMoveUpTask != null)
                {
                    _btnMoveUpTask.Click += btnMoveUpTask_Click;
                }
            }
        }

        private Button _btnMoveDownSubTask;

        internal Button btnMoveDownSubTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMoveDownSubTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMoveDownSubTask != null)
                {
                    _btnMoveDownSubTask.Click -= btnMoveDownSubTask_Click;
                }

                _btnMoveDownSubTask = value;
                if (_btnMoveDownSubTask != null)
                {
                    _btnMoveDownSubTask.Click += btnMoveDownSubTask_Click;
                }
            }
        }

        private Button _btnMoveUpSubTask;

        internal Button btnMoveUpSubTask
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMoveUpSubTask;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMoveUpSubTask != null)
                {
                    _btnMoveUpSubTask.Click -= btnMoveUpSubTask_Click;
                }

                _btnMoveUpSubTask = value;
                if (_btnMoveUpSubTask != null)
                {
                    _btnMoveUpSubTask.Click += btnMoveUpSubTask_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpSections = new System.Windows.Forms.GroupBox();
            this._txtSection = new System.Windows.Forms.TextBox();
            this._btnUpdateSection = new System.Windows.Forms.Button();
            this._btnRemoveSection = new System.Windows.Forms.Button();
            this._dgSection = new System.Windows.Forms.DataGrid();
            this._grpAreas = new System.Windows.Forms.GroupBox();
            this._btnMoveDownArea = new System.Windows.Forms.Button();
            this._btnMoveUpArea = new System.Windows.Forms.Button();
            this._txtArea = new System.Windows.Forms.TextBox();
            this._btnUpdateArea = new System.Windows.Forms.Button();
            this._btnRemoveArea = new System.Windows.Forms.Button();
            this._dgArea = new System.Windows.Forms.DataGrid();
            this._grpTasks = new System.Windows.Forms.GroupBox();
            this._btnMoveDownTask = new System.Windows.Forms.Button();
            this._btnMoveUpTask = new System.Windows.Forms.Button();
            this._txtTasks = new System.Windows.Forms.TextBox();
            this._btnUpdateTask = new System.Windows.Forms.Button();
            this._btnRemoveTask = new System.Windows.Forms.Button();
            this._dgTask = new System.Windows.Forms.DataGrid();
            this._grpSubTask = new System.Windows.Forms.GroupBox();
            this._btnMoveDownSubTask = new System.Windows.Forms.Button();
            this._btnMoveUpSubTask = new System.Windows.Forms.Button();
            this._txtSubTasks = new System.Windows.Forms.TextBox();
            this._btnUpdateSubTask = new System.Windows.Forms.Button();
            this._btnRemoveSubTask = new System.Windows.Forms.Button();
            this._dgSubTask = new System.Windows.Forms.DataGrid();
            this._grpSections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSection)).BeginInit();
            this._grpAreas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgArea)).BeginInit();
            this._grpTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgTask)).BeginInit();
            this._grpSubTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSubTask)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpSections
            // 
            this._grpSections.Controls.Add(this._txtSection);
            this._grpSections.Controls.Add(this._btnUpdateSection);
            this._grpSections.Controls.Add(this._btnRemoveSection);
            this._grpSections.Controls.Add(this._dgSection);
            this._grpSections.Location = new System.Drawing.Point(16, 12);
            this._grpSections.Name = "_grpSections";
            this._grpSections.Size = new System.Drawing.Size(400, 300);
            this._grpSections.TabIndex = 2;
            this._grpSections.TabStop = false;
            this._grpSections.Text = "Sections";
            // 
            // _txtSection
            // 
            this._txtSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSection.Location = new System.Drawing.Point(8, 268);
            this._txtSection.Name = "_txtSection";
            this._txtSection.Size = new System.Drawing.Size(240, 21);
            this._txtSection.TabIndex = 2;
            // 
            // _btnUpdateSection
            // 
            this._btnUpdateSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnUpdateSection.Location = new System.Drawing.Point(256, 268);
            this._btnUpdateSection.Name = "_btnUpdateSection";
            this._btnUpdateSection.Size = new System.Drawing.Size(64, 24);
            this._btnUpdateSection.TabIndex = 3;
            this._btnUpdateSection.Text = "Add";
            this._btnUpdateSection.Click += new System.EventHandler(this.btnUpdateSection_Click);
            // 
            // _btnRemoveSection
            // 
            this._btnRemoveSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRemoveSection.Location = new System.Drawing.Point(328, 268);
            this._btnRemoveSection.Name = "_btnRemoveSection";
            this._btnRemoveSection.Size = new System.Drawing.Size(64, 24);
            this._btnRemoveSection.TabIndex = 4;
            this._btnRemoveSection.Text = "Remove";
            this._btnRemoveSection.Click += new System.EventHandler(this.btnRemoveSection_Click);
            // 
            // _dgSection
            // 
            this._dgSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgSection.DataMember = "";
            this._dgSection.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgSection.Location = new System.Drawing.Point(8, 20);
            this._dgSection.Name = "_dgSection";
            this._dgSection.Size = new System.Drawing.Size(384, 240);
            this._dgSection.TabIndex = 1;
            this._dgSection.Click += new System.EventHandler(this.dgSection_Click);
            // 
            // _grpAreas
            // 
            this._grpAreas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._grpAreas.Controls.Add(this._btnMoveDownArea);
            this._grpAreas.Controls.Add(this._btnMoveUpArea);
            this._grpAreas.Controls.Add(this._txtArea);
            this._grpAreas.Controls.Add(this._btnUpdateArea);
            this._grpAreas.Controls.Add(this._btnRemoveArea);
            this._grpAreas.Controls.Add(this._dgArea);
            this._grpAreas.Location = new System.Drawing.Point(16, 320);
            this._grpAreas.Name = "_grpAreas";
            this._grpAreas.Size = new System.Drawing.Size(400, 224);
            this._grpAreas.TabIndex = 3;
            this._grpAreas.TabStop = false;
            this._grpAreas.Text = "Areas For Section ";
            // 
            // _btnMoveDownArea
            // 
            this._btnMoveDownArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMoveDownArea.Location = new System.Drawing.Point(368, 128);
            this._btnMoveDownArea.Name = "_btnMoveDownArea";
            this._btnMoveDownArea.Size = new System.Drawing.Size(24, 23);
            this._btnMoveDownArea.TabIndex = 9;
            this._btnMoveDownArea.Text = "/\\";
            this._btnMoveDownArea.Click += new System.EventHandler(this.btnMoveDownArea_Click);
            // 
            // _btnMoveUpArea
            // 
            this._btnMoveUpArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMoveUpArea.Location = new System.Drawing.Point(368, 160);
            this._btnMoveUpArea.Name = "_btnMoveUpArea";
            this._btnMoveUpArea.Size = new System.Drawing.Size(24, 23);
            this._btnMoveUpArea.TabIndex = 10;
            this._btnMoveUpArea.Text = "\\/";
            this._btnMoveUpArea.Click += new System.EventHandler(this.btnMoveUpArea_Click);
            // 
            // _txtArea
            // 
            this._txtArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtArea.Location = new System.Drawing.Point(8, 192);
            this._txtArea.Name = "_txtArea";
            this._txtArea.Size = new System.Drawing.Size(240, 21);
            this._txtArea.TabIndex = 6;
            // 
            // _btnUpdateArea
            // 
            this._btnUpdateArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnUpdateArea.Location = new System.Drawing.Point(256, 192);
            this._btnUpdateArea.Name = "_btnUpdateArea";
            this._btnUpdateArea.Size = new System.Drawing.Size(64, 24);
            this._btnUpdateArea.TabIndex = 7;
            this._btnUpdateArea.Text = "Add";
            this._btnUpdateArea.Click += new System.EventHandler(this.btnUpdateArea_Click);
            // 
            // _btnRemoveArea
            // 
            this._btnRemoveArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRemoveArea.Location = new System.Drawing.Point(328, 193);
            this._btnRemoveArea.Name = "_btnRemoveArea";
            this._btnRemoveArea.Size = new System.Drawing.Size(64, 24);
            this._btnRemoveArea.TabIndex = 8;
            this._btnRemoveArea.Text = "Remove";
            this._btnRemoveArea.Click += new System.EventHandler(this.btnRemoveArea_Click);
            // 
            // _dgArea
            // 
            this._dgArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgArea.DataMember = "";
            this._dgArea.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgArea.Location = new System.Drawing.Point(8, 26);
            this._dgArea.Name = "_dgArea";
            this._dgArea.Size = new System.Drawing.Size(352, 158);
            this._dgArea.TabIndex = 5;
            this._dgArea.Click += new System.EventHandler(this.dgArea_Click);
            // 
            // _grpTasks
            // 
            this._grpTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpTasks.Controls.Add(this._btnMoveDownTask);
            this._grpTasks.Controls.Add(this._btnMoveUpTask);
            this._grpTasks.Controls.Add(this._txtTasks);
            this._grpTasks.Controls.Add(this._btnUpdateTask);
            this._grpTasks.Controls.Add(this._btnRemoveTask);
            this._grpTasks.Controls.Add(this._dgTask);
            this._grpTasks.Location = new System.Drawing.Point(424, 12);
            this._grpTasks.Name = "_grpTasks";
            this._grpTasks.Size = new System.Drawing.Size(368, 300);
            this._grpTasks.TabIndex = 4;
            this._grpTasks.TabStop = false;
            this._grpTasks.Text = "Tasks For Area";
            // 
            // _btnMoveDownTask
            // 
            this._btnMoveDownTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMoveDownTask.Location = new System.Drawing.Point(336, 204);
            this._btnMoveDownTask.Name = "_btnMoveDownTask";
            this._btnMoveDownTask.Size = new System.Drawing.Size(24, 23);
            this._btnMoveDownTask.TabIndex = 15;
            this._btnMoveDownTask.Text = "/\\";
            this._btnMoveDownTask.Click += new System.EventHandler(this.btnMoveDownTask_Click);
            // 
            // _btnMoveUpTask
            // 
            this._btnMoveUpTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMoveUpTask.Location = new System.Drawing.Point(336, 236);
            this._btnMoveUpTask.Name = "_btnMoveUpTask";
            this._btnMoveUpTask.Size = new System.Drawing.Size(24, 23);
            this._btnMoveUpTask.TabIndex = 16;
            this._btnMoveUpTask.Text = "\\/";
            this._btnMoveUpTask.Click += new System.EventHandler(this.btnMoveUpTask_Click);
            // 
            // _txtTasks
            // 
            this._txtTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTasks.Location = new System.Drawing.Point(8, 268);
            this._txtTasks.Name = "_txtTasks";
            this._txtTasks.Size = new System.Drawing.Size(208, 21);
            this._txtTasks.TabIndex = 12;
            // 
            // _btnUpdateTask
            // 
            this._btnUpdateTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnUpdateTask.Location = new System.Drawing.Point(224, 268);
            this._btnUpdateTask.Name = "_btnUpdateTask";
            this._btnUpdateTask.Size = new System.Drawing.Size(64, 24);
            this._btnUpdateTask.TabIndex = 13;
            this._btnUpdateTask.Text = "Add";
            this._btnUpdateTask.Click += new System.EventHandler(this.btnUpdateTask_Click);
            // 
            // _btnRemoveTask
            // 
            this._btnRemoveTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRemoveTask.Location = new System.Drawing.Point(296, 269);
            this._btnRemoveTask.Name = "_btnRemoveTask";
            this._btnRemoveTask.Size = new System.Drawing.Size(64, 24);
            this._btnRemoveTask.TabIndex = 14;
            this._btnRemoveTask.Text = "Remove";
            this._btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // _dgTask
            // 
            this._dgTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgTask.DataMember = "";
            this._dgTask.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgTask.Location = new System.Drawing.Point(8, 20);
            this._dgTask.Name = "_dgTask";
            this._dgTask.Size = new System.Drawing.Size(320, 240);
            this._dgTask.TabIndex = 11;
            this._dgTask.Click += new System.EventHandler(this.dgTask_Click);
            // 
            // _grpSubTask
            // 
            this._grpSubTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSubTask.Controls.Add(this._btnMoveDownSubTask);
            this._grpSubTask.Controls.Add(this._btnMoveUpSubTask);
            this._grpSubTask.Controls.Add(this._txtSubTasks);
            this._grpSubTask.Controls.Add(this._btnUpdateSubTask);
            this._grpSubTask.Controls.Add(this._btnRemoveSubTask);
            this._grpSubTask.Controls.Add(this._dgSubTask);
            this._grpSubTask.Location = new System.Drawing.Point(424, 320);
            this._grpSubTask.Name = "_grpSubTask";
            this._grpSubTask.Size = new System.Drawing.Size(368, 224);
            this._grpSubTask.TabIndex = 5;
            this._grpSubTask.TabStop = false;
            this._grpSubTask.Text = "Sub Tasks For Task";
            // 
            // _btnMoveDownSubTask
            // 
            this._btnMoveDownSubTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMoveDownSubTask.Location = new System.Drawing.Point(336, 128);
            this._btnMoveDownSubTask.Name = "_btnMoveDownSubTask";
            this._btnMoveDownSubTask.Size = new System.Drawing.Size(24, 23);
            this._btnMoveDownSubTask.TabIndex = 21;
            this._btnMoveDownSubTask.Text = "/\\";
            this._btnMoveDownSubTask.Click += new System.EventHandler(this.btnMoveDownSubTask_Click);
            // 
            // _btnMoveUpSubTask
            // 
            this._btnMoveUpSubTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMoveUpSubTask.Location = new System.Drawing.Point(336, 160);
            this._btnMoveUpSubTask.Name = "_btnMoveUpSubTask";
            this._btnMoveUpSubTask.Size = new System.Drawing.Size(24, 23);
            this._btnMoveUpSubTask.TabIndex = 22;
            this._btnMoveUpSubTask.Text = "\\/";
            this._btnMoveUpSubTask.Click += new System.EventHandler(this.btnMoveUpSubTask_Click);
            // 
            // _txtSubTasks
            // 
            this._txtSubTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSubTasks.Location = new System.Drawing.Point(8, 192);
            this._txtSubTasks.Name = "_txtSubTasks";
            this._txtSubTasks.Size = new System.Drawing.Size(208, 21);
            this._txtSubTasks.TabIndex = 18;
            // 
            // _btnUpdateSubTask
            // 
            this._btnUpdateSubTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnUpdateSubTask.Location = new System.Drawing.Point(224, 192);
            this._btnUpdateSubTask.Name = "_btnUpdateSubTask";
            this._btnUpdateSubTask.Size = new System.Drawing.Size(64, 24);
            this._btnUpdateSubTask.TabIndex = 19;
            this._btnUpdateSubTask.Text = "Add";
            this._btnUpdateSubTask.Click += new System.EventHandler(this.btnUpdateSubTask_Click);
            // 
            // _btnRemoveSubTask
            // 
            this._btnRemoveSubTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRemoveSubTask.Location = new System.Drawing.Point(296, 192);
            this._btnRemoveSubTask.Name = "_btnRemoveSubTask";
            this._btnRemoveSubTask.Size = new System.Drawing.Size(64, 24);
            this._btnRemoveSubTask.TabIndex = 20;
            this._btnRemoveSubTask.Text = "Remove";
            this._btnRemoveSubTask.Click += new System.EventHandler(this.btnRemoveSubTask_Click);
            // 
            // _dgSubTask
            // 
            this._dgSubTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgSubTask.DataMember = "";
            this._dgSubTask.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgSubTask.Location = new System.Drawing.Point(8, 26);
            this._dgSubTask.Name = "_dgSubTask";
            this._dgSubTask.Size = new System.Drawing.Size(320, 158);
            this._dgSubTask.TabIndex = 17;
            this._dgSubTask.Click += new System.EventHandler(this.dgSubTask_Click);
            // 
            // FRMCheckListManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(800, 558);
            this.Controls.Add(this._grpSubTask);
            this.Controls.Add(this._grpTasks);
            this.Controls.Add(this._grpAreas);
            this.Controls.Add(this._grpSections);
            this.MinimumSize = new System.Drawing.Size(808, 592);
            this.Name = "FRMCheckListManager";
            this.Text = "CheckList Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpSections.ResumeLayout(false);
            this._grpSections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSection)).EndInit();
            this._grpAreas.ResumeLayout(false);
            this._grpAreas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgArea)).EndInit();
            this._grpTasks.ResumeLayout(false);
            this._grpTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgTask)).EndInit();
            this._grpSubTask.ResumeLayout(false);
            this._grpSubTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSubTask)).EndInit();
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupSectionsDataGrid();
            SetupAreasDataGrid();
            SetupTasksDataGrid();
            SetupSubTaskDataGrid();
            SectionDataView = App.DB.Section.Section_GetAll();
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
            // DO NOTHING
        }

        
        
        private bool SectionSelected = false;
        private bool AreaSelected = false;
        private bool TaskSelected = false;
        private bool SubTaskSelected = false;
        private DataView _SectionDataView = null;

        public DataView SectionDataView
        {
            get
            {
                return _SectionDataView;
            }

            set
            {
                _SectionDataView = value;
                _SectionDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblSection.ToString();
                _SectionDataView.AllowNew = false;
                _SectionDataView.AllowEdit = false;
                _SectionDataView.AllowDelete = false;
                dgSection.DataSource = SectionDataView;
            }
        }

        private DataRow SelectedSectionDataRow
        {
            get
            {
                if (!(dgSection.CurrentRowIndex == -1))
                {
                    return SectionDataView[dgSection.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _AreaDataView = null;

        public DataView AreaDataView
        {
            get
            {
                return _AreaDataView;
            }

            set
            {
                _AreaDataView = value;
                _AreaDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblArea.ToString();
                _AreaDataView.AllowNew = false;
                _AreaDataView.AllowEdit = false;
                _AreaDataView.AllowDelete = false;
                dgArea.DataSource = AreaDataView;
            }
        }

        private DataRow SelectedAreaDataRow
        {
            get
            {
                if (!(dgArea.CurrentRowIndex == -1))
                {
                    return AreaDataView[dgArea.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _TaskDataView = null;

        public DataView TaskDataView
        {
            get
            {
                return _TaskDataView;
            }

            set
            {
                _TaskDataView = value;
                _TaskDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblTask.ToString();
                _TaskDataView.AllowNew = false;
                _TaskDataView.AllowEdit = false;
                _TaskDataView.AllowDelete = false;
                dgTask.DataSource = TaskDataView;
            }
        }

        private DataRow SelectedTaskDataRow
        {
            get
            {
                if (!(dgTask.CurrentRowIndex == -1))
                {
                    return TaskDataView[dgTask.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _SubTaskDataView = null;

        public DataView SubTaskDataView
        {
            get
            {
                return _SubTaskDataView;
            }

            set
            {
                _SubTaskDataView = value;
                _SubTaskDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblSubTask.ToString();
                _SubTaskDataView.AllowNew = false;
                _SubTaskDataView.AllowEdit = false;
                _SubTaskDataView.AllowDelete = false;
                dgSubTask.DataSource = SubTaskDataView;
            }
        }

        private DataRow SelectedSubTaskDataRow
        {
            get
            {
                if (!(dgSubTask.CurrentRowIndex == -1))
                {
                    return SubTaskDataView[dgSubTask.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        
        

        public void SetupSectionsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSection);
            var tStyle = dgSection.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Desc = new DataGridLabelColumn();
            Desc.Format = "";
            Desc.FormatInfo = null;
            Desc.HeaderText = "Description";
            Desc.MappingName = "Description";
            Desc.ReadOnly = true;
            Desc.Width = 300;
            Desc.NullText = "";
            tStyle.GridColumnStyles.Add(Desc);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSection.ToString();
            dgSection.TableStyles.Add(tStyle);
        }

        public void SetupAreasDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgArea);
            var tStyle = dgArea.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Desc = new DataGridLabelColumn();
            Desc.Format = "";
            Desc.FormatInfo = null;
            Desc.HeaderText = "Description";
            Desc.MappingName = "Description";
            Desc.ReadOnly = true;
            Desc.Width = 300;
            Desc.NullText = "";
            tStyle.GridColumnStyles.Add(Desc);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblArea.ToString();
            dgArea.TableStyles.Add(tStyle);
        }

        public void SetupTasksDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgTask);
            var tStyle = dgTask.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Desc = new DataGridLabelColumn();
            Desc.Format = "";
            Desc.FormatInfo = null;
            Desc.HeaderText = "Description";
            Desc.MappingName = "Description";
            Desc.ReadOnly = true;
            Desc.Width = 300;
            Desc.NullText = "";
            tStyle.GridColumnStyles.Add(Desc);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblTask.ToString();
            dgTask.TableStyles.Add(tStyle);
        }

        public void SetupSubTaskDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSubTask);
            var tStyle = dgSubTask.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Desc = new DataGridLabelColumn();
            Desc.Format = "";
            Desc.FormatInfo = null;
            Desc.HeaderText = "Description";
            Desc.MappingName = "Description";
            Desc.ReadOnly = true;
            Desc.Width = 300;
            Desc.NullText = "";
            tStyle.GridColumnStyles.Add(Desc);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSubTask.ToString();
            dgSubTask.TableStyles.Add(tStyle);
        }

        private void FRMCheckListManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void dgSection_Click(object sender, EventArgs e)
        {
            if (SelectedSectionDataRow is null)
            {
                btnUpdateSection.Text = "Add";
                return;
            }

            SectionSelected = true;
            txtSection.Text = Conversions.ToString(SelectedSectionDataRow["Description"]);
            btnUpdateSection.Text = "Update";
            AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(SelectedSectionDataRow["SectionID"]));
            grpAreas.Text = Conversions.ToString("Areas For Section: " + SelectedSectionDataRow["Description"]);
            if (TaskDataView is object)
            {
                TaskDataView.Table.Rows.Clear();
                grpTasks.Text = "Tasks";
            }

            if (SubTaskDataView is object)
            {
                SubTaskDataView.Table.Rows.Clear();
                grpSubTask.Text = "Sub-Tasks";
            }

            txtArea.Text = "";
            btnUpdateArea.Text = "Add";
            txtTasks.Text = "";
            btnUpdateTask.Text = "Add";
            txtSubTasks.Text = "";
            btnUpdateSubTask.Text = "Add";
        }

        private void dgArea_Click(object sender, EventArgs e)
        {
            if (SelectedAreaDataRow is null)
            {
                btnUpdateArea.Text = "Add";
                return;
            }

            AreaSelected = true;
            txtArea.Text = Conversions.ToString(SelectedAreaDataRow["Description"]);
            btnUpdateArea.Text = "Update";
            TaskDataView = App.DB.Task.Task_Get_For_Area(SelectedAreaDataRow["AreaID"]);
            grpTasks.Text = Conversions.ToString("Tasks For Area: " + SelectedAreaDataRow["Description"]);
            if (SubTaskDataView is object)
            {
                SubTaskDataView.Table.Rows.Clear();
                grpSubTask.Text = "Sub-Tasks";
            }

            txtTasks.Text = "";
            btnUpdateTask.Text = "Add";
            txtSubTasks.Text = "";
            btnUpdateSubTask.Text = "Add";
        }

        private void dgTask_Click(object sender, EventArgs e)
        {
            if (SelectedTaskDataRow is null)
            {
                btnUpdateTask.Text = "Add";
                return;
            }

            TaskSelected = true;
            txtTasks.Text = Conversions.ToString(SelectedTaskDataRow["Description"]);
            btnUpdateTask.Text = "Update";
            grpSubTask.Text = Conversions.ToString("Sub-Tasks For Task: " + SelectedTaskDataRow["Description"]);
            SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(SelectedTaskDataRow["TaskID"]));
            txtSubTasks.Text = "";
            btnUpdateSubTask.Text = "Add";
        }

        private void dgSubTask_Click(object sender, EventArgs e)
        {
            if (SelectedSubTaskDataRow is null)
            {
                btnUpdateSubTask.Text = "Add";
                return;
            }

            SubTaskSelected = true;
            txtSubTasks.Text = Conversions.ToString(SelectedSubTaskDataRow["Description"]);
            btnUpdateSubTask.Text = "Update";
        }

        private void btnUpdateSection_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if ((btnUpdateSection.Text ?? "") == "Add")
            {
                ok = AddSection();
            }
            else
            {
                if (SelectedSectionDataRow is null)
                {
                    App.ShowMessage("Please select a section to update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (App.ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                ok = UpdateSection();
            }

            if (ok)
            {
                btnUpdateSection.Text = "Add";
                btnUpdateArea.Text = "Add";
                btnUpdateTask.Text = "Add";
                btnUpdateSubTask.Text = "Add";
                txtSection.Text = "";
                txtArea.Text = "";
                txtTasks.Text = "";
                txtSubTasks.Text = "";
                SectionDataView = App.DB.Section.Section_GetAll();
                if (AreaDataView is object)
                {
                    AreaDataView.Table.Rows.Clear();
                    grpAreas.Text = "Areas";
                }

                if (TaskDataView is object)
                {
                    TaskDataView.Table.Rows.Clear();
                    grpTasks.Text = "Tasks";
                }

                if (SubTaskDataView is object)
                {
                    SubTaskDataView.Table.Rows.Clear();
                    grpSubTask.Text = "Sub-Tasks";
                }
            }
        }

        private void btnUpdateArea_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if ((btnUpdateArea.Text ?? "") == "Add")
            {
                if (SelectedSectionDataRow is null | SectionSelected == false)
                {
                    App.ShowMessage("Please select a section to link this area to", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ok = AddArea();
            }
            else
            {
                if (SelectedAreaDataRow is null)
                {
                    App.ShowMessage("Please select an area to update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (App.ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                ok = UpdateArea();
            }

            if (ok)
            {
                btnUpdateArea.Text = "Add";
                btnUpdateTask.Text = "Add";
                btnUpdateSubTask.Text = "Add";
                txtArea.Text = "";
                txtTasks.Text = "";
                txtSubTasks.Text = "";
                AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(SelectedSectionDataRow["SectionID"]));
                if (TaskDataView is object)
                {
                    TaskDataView.Table.Rows.Clear();
                    grpTasks.Text = "Tasks";
                }

                if (SubTaskDataView is object)
                {
                    SubTaskDataView.Table.Rows.Clear();
                    grpSubTask.Text = "Sub-Tasks";
                }
            }
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if ((btnUpdateTask.Text ?? "") == "Add")
            {
                if (SelectedAreaDataRow is null | AreaSelected == false)
                {
                    App.ShowMessage("Please select an area to link this task to", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ok = AddTask();
            }
            else
            {
                if (SelectedTaskDataRow is null)
                {
                    App.ShowMessage("Please select a task to update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (App.ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                ok = UpdateTask();
            }

            if (ok)
            {
                btnUpdateTask.Text = "Add";
                btnUpdateSubTask.Text = "Add";
                txtTasks.Text = "";
                txtSubTasks.Text = "";
                TaskDataView = App.DB.Task.Task_Get_For_Area(SelectedAreaDataRow["AreaID"]);
                if (SubTaskDataView is object)
                {
                    SubTaskDataView.Table.Rows.Clear();
                    grpSubTask.Text = "Sub-Tasks";
                }
            }
        }

        private void btnUpdateSubTask_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if ((btnUpdateSubTask.Text ?? "") == "Add")
            {
                if (SelectedTaskDataRow is null | TaskSelected == false)
                {
                    App.ShowMessage("Please select a task to link this sub task to", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ok = AddSubTask();
            }
            else
            {
                if (SelectedSubTaskDataRow is null)
                {
                    App.ShowMessage("Please select a sub task to update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (App.ShowMessage("Are you sure you want to update? This will change ALL historic data.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                ok = UpdateSubTask();
            }

            if (ok)
            {
                btnUpdateSubTask.Text = "Add";
                txtSubTasks.Text = "";
                SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(SelectedTaskDataRow["TaskID"]));
            }
        }

        private void btnRemoveSection_Click(object sender, EventArgs e)
        {
            if (SelectedSectionDataRow is null)
            {
                App.ShowMessage("Plase select a section to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you want to remove this Section? All associated Areas, Tasks and Sub-Tasks will no longer be usable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                App.DB.Section.Delete(Conversions.ToInteger(SelectedSectionDataRow["SectionID"]));
                btnUpdateSection.Text = "Add";
                btnUpdateArea.Text = "Add";
                btnUpdateTask.Text = "Add";
                btnUpdateSubTask.Text = "Add";
                txtSection.Text = "";
                txtArea.Text = "";
                txtTasks.Text = "";
                txtSubTasks.Text = "";
                SectionDataView = App.DB.Section.Section_GetAll();
                if (AreaDataView is object)
                {
                    AreaDataView.Table.Rows.Clear();
                    grpAreas.Text = "Areas";
                }

                if (TaskDataView is object)
                {
                    TaskDataView.Table.Rows.Clear();
                    grpTasks.Text = "Tasks";
                }

                if (SubTaskDataView is object)
                {
                    SubTaskDataView.Table.Rows.Clear();
                    grpSubTask.Text = "Sub-Tasks";
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Could not delete section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRemoveArea_Click(object sender, EventArgs e)
        {
            if (SelectedAreaDataRow is null | SelectedSectionDataRow is null)
            {
                App.ShowMessage("Plase select an area to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you want to remove this Area? All associated Tasks and Sub-Tasks will no longer be usable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                App.DB.Area.Delete(Conversions.ToInteger(SelectedAreaDataRow["AreaID"]));
                btnUpdateArea.Text = "Add";
                btnUpdateTask.Text = "Add";
                btnUpdateSubTask.Text = "Add";
                txtArea.Text = "";
                txtTasks.Text = "";
                txtSubTasks.Text = "";
                AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(SelectedSectionDataRow["SectionID"]));
                if (TaskDataView is object)
                {
                    TaskDataView.Table.Rows.Clear();
                    grpTasks.Text = "Tasks";
                }

                if (SubTaskDataView is object)
                {
                    SubTaskDataView.Table.Rows.Clear();
                    grpSubTask.Text = "Sub-Tasks";
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Could not delete area", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (SelectedTaskDataRow is null | SelectedAreaDataRow is null)
            {
                App.ShowMessage("Plase select a task to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you want to remove this Task? All associated Sub-Tasks will no longer be usable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                App.DB.Task.Delete(Conversions.ToInteger(SelectedTaskDataRow["TaskID"]));
                btnUpdateTask.Text = "Add";
                btnUpdateSubTask.Text = "Add";
                txtTasks.Text = "";
                txtSubTasks.Text = "";
                TaskDataView = App.DB.Task.Task_Get_For_Area(SelectedAreaDataRow["AreaID"]);
                if (SubTaskDataView is object)
                {
                    SubTaskDataView.Table.Rows.Clear();
                    grpSubTask.Text = "Sub-Tasks";
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Could not delete task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRemoveSubTask_Click(object sender, EventArgs e)
        {
            if (SelectedSubTaskDataRow is null | SelectedTaskDataRow is null)
            {
                App.ShowMessage("Plase select a sub task to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you want to remove this Sub-Task?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                App.DB.SubTask.Delete(Conversions.ToInteger(SelectedSubTaskDataRow["SubTaskID"]));
                btnUpdateSubTask.Text = "Add";
                txtSubTasks.Text = "";
                SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(SelectedTaskDataRow["TaskID"]));
            }
            catch (Exception ex)
            {
                App.ShowMessage("Could not delete sub task", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnMoveUpArea_Click(object sender, EventArgs e)
        {
            if (SelectedAreaDataRow is null)
            {
                App.ShowMessage("Plase select an area to move down", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            App.DB.Area.Area_AdjustOrderNumber(Conversions.ToInteger(SelectedAreaDataRow["AreaID"]), Conversions.ToInteger(SelectedAreaDataRow["OrderNumber"]), Conversions.ToInteger((int)SelectedAreaDataRow["OrderNumber"] + 1), Conversions.ToInteger(SelectedAreaDataRow["SectionID"]));
            AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(SelectedAreaDataRow["SectionID"]));
        }

        private void btnMoveDownArea_Click(object sender, EventArgs e)
        {
            if (SelectedAreaDataRow is null)
            {
                App.ShowMessage("Plase select an area to move up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            App.DB.Area.Area_AdjustOrderNumber(Conversions.ToInteger(SelectedAreaDataRow["AreaID"]), Conversions.ToInteger(SelectedAreaDataRow["OrderNumber"]), Conversions.ToInteger((int)SelectedAreaDataRow["OrderNumber"] - 1), Conversions.ToInteger(SelectedAreaDataRow["SectionID"]));
            AreaDataView = App.DB.Area.Area_Get_For_Section(Conversions.ToInteger(SelectedAreaDataRow["SectionID"]));
        }

        private void btnMoveUpTask_Click(object sender, EventArgs e)
        {
            if (SelectedTaskDataRow is null)
            {
                App.ShowMessage("Plase select a task to move down", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            App.DB.Task.Task_AdjustOrderNumber(Conversions.ToInteger(SelectedTaskDataRow["TaskID"]), Conversions.ToInteger(SelectedTaskDataRow["OrderNumber"]), Conversions.ToInteger((int)SelectedTaskDataRow["OrderNumber"] + 1), Conversions.ToInteger(SelectedTaskDataRow["AreaID"]));
            TaskDataView = App.DB.Task.Task_Get_For_Area(SelectedTaskDataRow["AreaID"]);
        }

        private void btnMoveDownTask_Click(object sender, EventArgs e)
        {
            if (SelectedTaskDataRow is null)
            {
                App.ShowMessage("Plase select a task to move up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            App.DB.Task.Task_AdjustOrderNumber(Conversions.ToInteger(SelectedTaskDataRow["TaskID"]), Conversions.ToInteger(SelectedTaskDataRow["OrderNumber"]), Conversions.ToInteger((int)SelectedTaskDataRow["OrderNumber"] - 1), Conversions.ToInteger(SelectedTaskDataRow["AreaID"]));
            TaskDataView = App.DB.Task.Task_Get_For_Area(SelectedTaskDataRow["AreaID"]);
        }

        private void btnMoveUpSubTask_Click(object sender, EventArgs e)
        {
            if (SelectedSubTaskDataRow is null)
            {
                App.ShowMessage("Plase select a sub task to move down", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            App.DB.SubTask.SubTask_AdjustOrderNumber(Conversions.ToInteger(SelectedSubTaskDataRow["SubTaskID"]), Conversions.ToInteger(SelectedSubTaskDataRow["OrderNumber"]), Conversions.ToInteger((int)SelectedSubTaskDataRow["OrderNumber"] + 1), Conversions.ToInteger(SelectedSubTaskDataRow["TaskID"]));
            SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(SelectedSubTaskDataRow["TaskID"]));
        }

        private void btnMoveDownSubTask_Click(object sender, EventArgs e)
        {
            if (SelectedSubTaskDataRow is null)
            {
                App.ShowMessage("Plase select a sub task to move up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            App.DB.SubTask.SubTask_AdjustOrderNumber(Conversions.ToInteger(SelectedSubTaskDataRow["SubTaskID"]), Conversions.ToInteger(SelectedSubTaskDataRow["OrderNumber"]), Conversions.ToInteger((int)SelectedSubTaskDataRow["OrderNumber"] - 1), Conversions.ToInteger(SelectedSubTaskDataRow["TaskID"]));
            SubTaskDataView = App.DB.SubTask.SubTask_Get_For_Task(Conversions.ToInteger(SelectedSubTaskDataRow["TaskID"]));
        }

        
        

        private bool AddSection()
        {
            try
            {
                var oSection = new Entity.Sections.Section();
                Cursor = Cursors.WaitCursor;
                oSection.IgnoreExceptionsOnSetMethods = true;
                oSection.SetDescription = txtSection.Text;
                var sV = new Entity.Sections.SectionValidator();
                sV.Validate(oSection);
                oSection = App.DB.Section.Insert(oSection);
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

        private bool UpdateSection()
        {
            try
            {
                var oSection = new Entity.Sections.Section();
                Cursor = Cursors.WaitCursor;
                oSection.IgnoreExceptionsOnSetMethods = true;
                if (SelectedSectionDataRow is null)
                {
                    return default;
                }

                oSection.SetDescription = txtSection.Text;
                oSection.SetSectionID = SelectedSectionDataRow["SectionID"];
                var sV = new Entity.Sections.SectionValidator();
                sV.Validate(oSection);
                App.DB.Section.Update(oSection);
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

        private bool AddArea()
        {
            try
            {
                var oArea = new Entity.Areas.Area();
                Cursor = Cursors.WaitCursor;
                oArea.IgnoreExceptionsOnSetMethods = true;
                oArea.SetDescription = txtArea.Text;
                oArea.SetSectionID = SelectedSectionDataRow["SectionID"];
                var aV = new Entity.Areas.AreaValidator();
                aV.Validate(oArea);
                oArea = App.DB.Area.Insert(oArea);
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

        private bool UpdateArea()
        {
            try
            {
                var oArea = new Entity.Areas.Area();
                Cursor = Cursors.WaitCursor;
                oArea.IgnoreExceptionsOnSetMethods = true;
                if (SelectedAreaDataRow is null | SelectedSectionDataRow is null)
                {
                    return default;
                }

                oArea.SetDescription = txtArea.Text;
                oArea.SetSectionID = SelectedSectionDataRow["SectionID"];
                oArea.SetAreaID = SelectedAreaDataRow["AreaID"];
                oArea.SetOrderNumber = SelectedAreaDataRow["OrderNumber"];
                var aV = new Entity.Areas.AreaValidator();
                aV.Validate(oArea);
                App.DB.Area.Update(oArea);
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

        private bool AddTask()
        {
            try
            {
                var oTask = new Entity.Tasks.Task();
                Cursor = Cursors.WaitCursor;
                oTask.IgnoreExceptionsOnSetMethods = true;
                oTask.SetDescription = txtTasks.Text;
                oTask.SetAreaID = SelectedAreaDataRow["AreaID"];
                var tV = new Entity.Tasks.TaskValidator();
                tV.Validate(oTask);
                oTask = App.DB.Task.Insert(oTask);
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

        private bool UpdateTask()
        {
            try
            {
                var oTask = new Entity.Tasks.Task();
                Cursor = Cursors.WaitCursor;
                oTask.IgnoreExceptionsOnSetMethods = true;
                if (SelectedAreaDataRow is null | SelectedTaskDataRow is null)
                {
                    return default;
                }

                oTask.SetDescription = txtTasks.Text;
                oTask.SetAreaID = SelectedAreaDataRow["AreaID"];
                oTask.SetOrderNumber = SelectedTaskDataRow["OrderNumber"];
                oTask.SetTaskID = SelectedTaskDataRow["TaskID"];
                var tV = new Entity.Tasks.TaskValidator();
                tV.Validate(oTask);
                App.DB.Task.Update(oTask);
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

        private bool AddSubTask()
        {
            try
            {
                var oSubTask = new Entity.SubTasks.SubTask();
                Cursor = Cursors.WaitCursor;
                oSubTask.IgnoreExceptionsOnSetMethods = true;
                oSubTask.SetDescription = txtSubTasks.Text;
                oSubTask.SetTaskID = SelectedTaskDataRow["TaskID"];
                var stV = new Entity.SubTasks.SubTaskValidator();
                stV.Validate(oSubTask);
                oSubTask = App.DB.SubTask.Insert(oSubTask);
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

        private bool UpdateSubTask()
        {
            try
            {
                var oSubTask = new Entity.SubTasks.SubTask();
                Cursor = Cursors.WaitCursor;
                oSubTask.IgnoreExceptionsOnSetMethods = true;
                if (SelectedTaskDataRow is null | SelectedSubTaskDataRow is null)
                {
                    return default;
                }

                oSubTask.SetDescription = txtSubTasks.Text;
                oSubTask.SetTaskID = SelectedTaskDataRow["TaskID"];
                oSubTask.SetSubTaskID = SelectedSubTaskDataRow["SubTaskID"];
                oSubTask.SetOrderNumber = SelectedSubTaskDataRow["OrderNumber"];
                var stV = new Entity.SubTasks.SubTaskValidator();
                stV.Validate(oSubTask);
                App.DB.SubTask.Update(oSubTask);
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