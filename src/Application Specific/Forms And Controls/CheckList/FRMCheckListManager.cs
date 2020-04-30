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
            _grpSections = new GroupBox();
            _txtSection = new TextBox();
            _btnUpdateSection = new Button();
            _btnUpdateSection.Click += new EventHandler(btnUpdateSection_Click);
            _btnRemoveSection = new Button();
            _btnRemoveSection.Click += new EventHandler(btnRemoveSection_Click);
            _dgSection = new DataGrid();
            _dgSection.Click += new EventHandler(dgSection_Click);
            _grpAreas = new GroupBox();
            _btnMoveDownArea = new Button();
            _btnMoveDownArea.Click += new EventHandler(btnMoveDownArea_Click);
            _btnMoveUpArea = new Button();
            _btnMoveUpArea.Click += new EventHandler(btnMoveUpArea_Click);
            _txtArea = new TextBox();
            _btnUpdateArea = new Button();
            _btnUpdateArea.Click += new EventHandler(btnUpdateArea_Click);
            _btnRemoveArea = new Button();
            _btnRemoveArea.Click += new EventHandler(btnRemoveArea_Click);
            _dgArea = new DataGrid();
            _dgArea.Click += new EventHandler(dgArea_Click);
            _grpTasks = new GroupBox();
            _btnMoveDownTask = new Button();
            _btnMoveDownTask.Click += new EventHandler(btnMoveDownTask_Click);
            _btnMoveUpTask = new Button();
            _btnMoveUpTask.Click += new EventHandler(btnMoveUpTask_Click);
            _txtTasks = new TextBox();
            _btnUpdateTask = new Button();
            _btnUpdateTask.Click += new EventHandler(btnUpdateTask_Click);
            _btnRemoveTask = new Button();
            _btnRemoveTask.Click += new EventHandler(btnRemoveTask_Click);
            _dgTask = new DataGrid();
            _dgTask.Click += new EventHandler(dgTask_Click);
            _grpSubTask = new GroupBox();
            _btnMoveDownSubTask = new Button();
            _btnMoveDownSubTask.Click += new EventHandler(btnMoveDownSubTask_Click);
            _btnMoveUpSubTask = new Button();
            _btnMoveUpSubTask.Click += new EventHandler(btnMoveUpSubTask_Click);
            _txtSubTasks = new TextBox();
            _btnUpdateSubTask = new Button();
            _btnUpdateSubTask.Click += new EventHandler(btnUpdateSubTask_Click);
            _btnRemoveSubTask = new Button();
            _btnRemoveSubTask.Click += new EventHandler(btnRemoveSubTask_Click);
            _dgSubTask = new DataGrid();
            _dgSubTask.Click += new EventHandler(dgSubTask_Click);
            _grpSections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSection).BeginInit();
            _grpAreas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgArea).BeginInit();
            _grpTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTask).BeginInit();
            _grpSubTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSubTask).BeginInit();
            SuspendLayout();
            //
            // grpSections
            //
            _grpSections.Controls.Add(_txtSection);
            _grpSections.Controls.Add(_btnUpdateSection);
            _grpSections.Controls.Add(_btnRemoveSection);
            _grpSections.Controls.Add(_dgSection);
            _grpSections.Location = new Point(16, 40);
            _grpSections.Name = "grpSections";
            _grpSections.Size = new Size(400, 272);
            _grpSections.TabIndex = 2;
            _grpSections.TabStop = false;
            _grpSections.Text = "Sections";
            //
            // txtSection
            //
            _txtSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSection.Location = new Point(8, 240);
            _txtSection.Name = "txtSection";
            _txtSection.Size = new Size(240, 21);
            _txtSection.TabIndex = 2;
            _txtSection.Text = "";
            //
            // btnUpdateSection
            //
            _btnUpdateSection.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnUpdateSection.Location = new Point(256, 240);
            _btnUpdateSection.Name = "btnUpdateSection";
            _btnUpdateSection.Size = new Size(64, 24);
            _btnUpdateSection.TabIndex = 3;
            _btnUpdateSection.Text = "Add";
            //
            // btnRemoveSection
            //
            _btnRemoveSection.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemoveSection.Location = new Point(328, 240);
            _btnRemoveSection.Name = "btnRemoveSection";
            _btnRemoveSection.Size = new Size(64, 24);
            _btnRemoveSection.TabIndex = 4;
            _btnRemoveSection.Text = "Remove";
            //
            // dgSection
            //
            _dgSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSection.DataMember = "";
            _dgSection.HeaderForeColor = SystemColors.ControlText;
            _dgSection.Location = new Point(8, 20);
            _dgSection.Name = "dgSection";
            _dgSection.Size = new Size(384, 212);
            _dgSection.TabIndex = 1;
            //
            // grpAreas
            //
            _grpAreas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpAreas.Controls.Add(_btnMoveDownArea);
            _grpAreas.Controls.Add(_btnMoveUpArea);
            _grpAreas.Controls.Add(_txtArea);
            _grpAreas.Controls.Add(_btnUpdateArea);
            _grpAreas.Controls.Add(_btnRemoveArea);
            _grpAreas.Controls.Add(_dgArea);
            _grpAreas.Location = new Point(16, 320);
            _grpAreas.Name = "grpAreas";
            _grpAreas.Size = new Size(400, 224);
            _grpAreas.TabIndex = 3;
            _grpAreas.TabStop = false;
            _grpAreas.Text = "Areas For Section ";
            //
            // btnMoveDownArea
            //
            _btnMoveDownArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnMoveDownArea.Location = new Point(368, 128);
            _btnMoveDownArea.Name = "btnMoveDownArea";
            _btnMoveDownArea.Size = new Size(24, 23);
            _btnMoveDownArea.TabIndex = 9;
            _btnMoveDownArea.Text = @"/\";
            //
            // btnMoveUpArea
            //
            _btnMoveUpArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnMoveUpArea.Location = new Point(368, 160);
            _btnMoveUpArea.Name = "btnMoveUpArea";
            _btnMoveUpArea.Size = new Size(24, 23);
            _btnMoveUpArea.TabIndex = 10;
            _btnMoveUpArea.Text = @"\/";
            //
            // txtArea
            //
            _txtArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtArea.Location = new Point(8, 192);
            _txtArea.Name = "txtArea";
            _txtArea.Size = new Size(240, 21);
            _txtArea.TabIndex = 6;
            _txtArea.Text = "";
            //
            // btnUpdateArea
            //
            _btnUpdateArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnUpdateArea.Location = new Point(256, 192);
            _btnUpdateArea.Name = "btnUpdateArea";
            _btnUpdateArea.Size = new Size(64, 24);
            _btnUpdateArea.TabIndex = 7;
            _btnUpdateArea.Text = "Add";
            //
            // btnRemoveArea
            //
            _btnRemoveArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemoveArea.Location = new Point(328, 193);
            _btnRemoveArea.Name = "btnRemoveArea";
            _btnRemoveArea.Size = new Size(64, 24);
            _btnRemoveArea.TabIndex = 8;
            _btnRemoveArea.Text = "Remove";
            //
            // dgArea
            //
            _dgArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgArea.DataMember = "";
            _dgArea.HeaderForeColor = SystemColors.ControlText;
            _dgArea.Location = new Point(8, 26);
            _dgArea.Name = "dgArea";
            _dgArea.Size = new Size(352, 158);
            _dgArea.TabIndex = 5;
            //
            // grpTasks
            //
            _grpTasks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpTasks.Controls.Add(_btnMoveDownTask);
            _grpTasks.Controls.Add(_btnMoveUpTask);
            _grpTasks.Controls.Add(_txtTasks);
            _grpTasks.Controls.Add(_btnUpdateTask);
            _grpTasks.Controls.Add(_btnRemoveTask);
            _grpTasks.Controls.Add(_dgTask);
            _grpTasks.Location = new Point(424, 40);
            _grpTasks.Name = "grpTasks";
            _grpTasks.Size = new Size(368, 272);
            _grpTasks.TabIndex = 4;
            _grpTasks.TabStop = false;
            _grpTasks.Text = "Tasks For Area";
            //
            // btnMoveDownTask
            //
            _btnMoveDownTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnMoveDownTask.Location = new Point(336, 176);
            _btnMoveDownTask.Name = "btnMoveDownTask";
            _btnMoveDownTask.Size = new Size(24, 23);
            _btnMoveDownTask.TabIndex = 15;
            _btnMoveDownTask.Text = @"/\";
            //
            // btnMoveUpTask
            //
            _btnMoveUpTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnMoveUpTask.Location = new Point(336, 208);
            _btnMoveUpTask.Name = "btnMoveUpTask";
            _btnMoveUpTask.Size = new Size(24, 23);
            _btnMoveUpTask.TabIndex = 16;
            _btnMoveUpTask.Text = @"\/";
            //
            // txtTasks
            //
            _txtTasks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtTasks.Location = new Point(8, 240);
            _txtTasks.Name = "txtTasks";
            _txtTasks.Size = new Size(208, 21);
            _txtTasks.TabIndex = 12;
            _txtTasks.Text = "";
            //
            // btnUpdateTask
            //
            _btnUpdateTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnUpdateTask.Location = new Point(224, 240);
            _btnUpdateTask.Name = "btnUpdateTask";
            _btnUpdateTask.Size = new Size(64, 24);
            _btnUpdateTask.TabIndex = 13;
            _btnUpdateTask.Text = "Add";
            //
            // btnRemoveTask
            //
            _btnRemoveTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemoveTask.Location = new Point(296, 241);
            _btnRemoveTask.Name = "btnRemoveTask";
            _btnRemoveTask.Size = new Size(64, 24);
            _btnRemoveTask.TabIndex = 14;
            _btnRemoveTask.Text = "Remove";
            //
            // dgTask
            //
            _dgTask.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgTask.DataMember = "";
            _dgTask.HeaderForeColor = SystemColors.ControlText;
            _dgTask.Location = new Point(8, 20);
            _dgTask.Name = "dgTask";
            _dgTask.Size = new Size(320, 212);
            _dgTask.TabIndex = 11;
            //
            // grpSubTask
            //
            _grpSubTask.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSubTask.Controls.Add(_btnMoveDownSubTask);
            _grpSubTask.Controls.Add(_btnMoveUpSubTask);
            _grpSubTask.Controls.Add(_txtSubTasks);
            _grpSubTask.Controls.Add(_btnUpdateSubTask);
            _grpSubTask.Controls.Add(_btnRemoveSubTask);
            _grpSubTask.Controls.Add(_dgSubTask);
            _grpSubTask.Location = new Point(424, 320);
            _grpSubTask.Name = "grpSubTask";
            _grpSubTask.Size = new Size(368, 224);
            _grpSubTask.TabIndex = 5;
            _grpSubTask.TabStop = false;
            _grpSubTask.Text = "Sub Tasks For Task";
            //
            // btnMoveDownSubTask
            //
            _btnMoveDownSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnMoveDownSubTask.Location = new Point(336, 128);
            _btnMoveDownSubTask.Name = "btnMoveDownSubTask";
            _btnMoveDownSubTask.Size = new Size(24, 23);
            _btnMoveDownSubTask.TabIndex = 21;
            _btnMoveDownSubTask.Text = @"/\";
            //
            // btnMoveUpSubTask
            //
            _btnMoveUpSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnMoveUpSubTask.Location = new Point(336, 160);
            _btnMoveUpSubTask.Name = "btnMoveUpSubTask";
            _btnMoveUpSubTask.Size = new Size(24, 23);
            _btnMoveUpSubTask.TabIndex = 22;
            _btnMoveUpSubTask.Text = @"\/";
            //
            // txtSubTasks
            //
            _txtSubTasks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtSubTasks.Location = new Point(8, 192);
            _txtSubTasks.Name = "txtSubTasks";
            _txtSubTasks.Size = new Size(208, 21);
            _txtSubTasks.TabIndex = 18;
            _txtSubTasks.Text = "";
            //
            // btnUpdateSubTask
            //
            _btnUpdateSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnUpdateSubTask.Location = new Point(224, 192);
            _btnUpdateSubTask.Name = "btnUpdateSubTask";
            _btnUpdateSubTask.Size = new Size(64, 24);
            _btnUpdateSubTask.TabIndex = 19;
            _btnUpdateSubTask.Text = "Add";
            //
            // btnRemoveSubTask
            //
            _btnRemoveSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemoveSubTask.Location = new Point(296, 192);
            _btnRemoveSubTask.Name = "btnRemoveSubTask";
            _btnRemoveSubTask.Size = new Size(64, 24);
            _btnRemoveSubTask.TabIndex = 20;
            _btnRemoveSubTask.Text = "Remove";
            //
            // dgSubTask
            //
            _dgSubTask.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSubTask.DataMember = "";
            _dgSubTask.HeaderForeColor = SystemColors.ControlText;
            _dgSubTask.Location = new Point(8, 26);
            _dgSubTask.Name = "dgSubTask";
            _dgSubTask.Size = new Size(320, 158);
            _dgSubTask.TabIndex = 17;
            //
            // FRMCheckListManager
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(800, 558);
            Controls.Add(_grpSubTask);
            Controls.Add(_grpTasks);
            Controls.Add(_grpAreas);
            Controls.Add(_grpSections);
            MinimumSize = new Size(808, 592);
            Name = "FRMCheckListManager";
            Text = "CheckList Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpSections, 0);
            Controls.SetChildIndex(_grpAreas, 0);
            Controls.SetChildIndex(_grpTasks, 0);
            Controls.SetChildIndex(_grpSubTask, 0);
            _grpSections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSection).EndInit();
            _grpAreas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgArea).EndInit();
            _grpTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgTask).EndInit();
            _grpSubTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSubTask).EndInit();
            ResumeLayout(false);
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