using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMSmokeComo : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMSmokeComo));
            _GroupBox1 = new GroupBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _Label4 = new Label();
            _dtpDate = new DateTimePicker();
            _txtLocation = new TextBox();
            _Label3 = new Label();
            _cboDateType = new ComboBox();
            _Label2 = new Label();
            _cboPower = new ComboBox();
            _Label1 = new Label();
            _lbltype = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _cboDetType = new ComboBox();
            _chkNA = new CheckBox();
            _chkNA.CheckedChanged += new EventHandler(chkNA_CheckedChanged);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_chkNA);
            _GroupBox1.Controls.Add(_Button1);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_dtpDate);
            _GroupBox1.Controls.Add(_txtLocation);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_cboDateType);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_cboPower);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_lbltype);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Controls.Add(_cboDetType);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(422, 206);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Add/ Amend";
            // 
            // Button1
            // 
            _Button1.UseVisualStyleBackColor = true;
            _Button1.Location = new Point(6, 177);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(75, 23);
            _Button1.TabIndex = 12;
            _Button1.Text = "Close";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            _Label4.AutoSize = true;
            _Label4.Location = new Point(54, 115);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(36, 13);
            _Label4.TabIndex = 11;
            _Label4.Text = "Dated";
            // 
            // dtpDate
            // 
            _dtpDate.Location = new Point(122, 111);
            _dtpDate.Name = "dtpDate";
            _dtpDate.Size = new Size(136, 20);
            _dtpDate.TabIndex = 10;
            // 
            // txtLocation
            // 
            _txtLocation.Location = new Point(122, 57);
            _txtLocation.Name = "txtLocation";
            _txtLocation.Size = new Size(243, 20);
            _txtLocation.TabIndex = 9;
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Location = new Point(54, 140);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(57, 13);
            _Label3.TabIndex = 8;
            _Label3.Text = "Date Type";
            // 
            // cboDateType
            // 
            _cboDateType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDateType.FormattingEnabled = true;
            _cboDateType.Location = new Point(122, 137);
            _cboDateType.Name = "cboDateType";
            _cboDateType.Size = new Size(243, 21);
            _cboDateType.TabIndex = 7;
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(54, 87);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(64, 13);
            _Label2.TabIndex = 6;
            _Label2.Text = "Power Type";
            // 
            // cboPower
            // 
            _cboPower.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPower.FormattingEnabled = true;
            _cboPower.Location = new Point(122, 84);
            _cboPower.Name = "cboPower";
            _cboPower.Size = new Size(243, 21);
            _cboPower.TabIndex = 5;
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(54, 60);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(48, 13);
            _Label1.TabIndex = 4;
            _Label1.Text = "Location";
            // 
            // lbltype
            // 
            _lbltype.AutoSize = true;
            _lbltype.Location = new Point(54, 33);
            _lbltype.Name = "lbltype";
            _lbltype.Size = new Size(31, 13);
            _lbltype.TabIndex = 2;
            _lbltype.Text = "Type";
            // 
            // btnOK
            // 
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(341, 177);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "Save";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // cboDetType
            // 
            _cboDetType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDetType.FormattingEnabled = true;
            _cboDetType.Location = new Point(122, 30);
            _cboDetType.Name = "cboDetType";
            _cboDetType.Size = new Size(243, 21);
            _cboDetType.TabIndex = 0;
            // 
            // chkNA
            // 
            _chkNA.AutoSize = true;
            _chkNA.Location = new Point(280, 113);
            _chkNA.Name = "chkNA";
            _chkNA.Size = new Size(79, 17);
            _chkNA.TabIndex = 13;
            _chkNA.Text = "Not Known";
            _chkNA.UseVisualStyleBackColor = true;
            // 
            // FRMSmokeComo
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(439, 215);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FRMSmokeComo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add/Amend";
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            Load += new EventHandler(FRMChangePriority_Load);
            ResumeLayout(false);
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private Button _btnOK;

        internal Button btnOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        private ComboBox _cboDetType;

        internal ComboBox cboDetType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDetType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDetType != null)
                {
                }

                _cboDetType = value;
                if (_cboDetType != null)
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

        private DateTimePicker _dtpDate;

        internal DateTimePicker dtpDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDate != null)
                {
                }

                _dtpDate = value;
                if (_dtpDate != null)
                {
                }
            }
        }

        private TextBox _txtLocation;

        internal TextBox txtLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLocation != null)
                {
                }

                _txtLocation = value;
                if (_txtLocation != null)
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

        private ComboBox _cboDateType;

        internal ComboBox cboDateType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDateType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDateType != null)
                {
                }

                _cboDateType = value;
                if (_cboDateType != null)
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

        private ComboBox _cboPower;

        internal ComboBox cboPower
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPower;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPower != null)
                {
                }

                _cboPower = value;
                if (_cboPower != null)
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

        private Label _lbltype;

        internal Label lbltype
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltype;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltype != null)
                {
                }

                _lbltype = value;
                if (_lbltype != null)
                {
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

        private CheckBox _chkNA;

        internal CheckBox chkNA
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkNA;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkNA != null)
                {
                    _chkNA.CheckedChanged -= chkNA_CheckedChanged;
                }

                _chkNA = value;
                if (_chkNA != null)
                {
                    _chkNA.CheckedChanged += chkNA_CheckedChanged;
                }
            }
        }
    }
}