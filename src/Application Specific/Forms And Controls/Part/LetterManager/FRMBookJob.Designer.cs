using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMBookJob : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMBookJob));
            _GroupBox1 = new GroupBox();
            _Label4 = new Label();
            _txtEngineernotes = new TextBox();
            _lblMessage = new Label();
            _dtpDate = new Pabo.Calendar.MonthCalendar();
            _dtpDate.DayClick += new Pabo.Calendar.DayClickEventHandler(dtpDate_MonthChanged);
            _Label2 = new Label();
            _cboAppointment = new ComboBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _Label3 = new Label();
            _Label1 = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_txtEngineernotes);
            _GroupBox1.Controls.Add(_lblMessage);
            _GroupBox1.Controls.Add(_dtpDate);
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_cboAppointment);
            _GroupBox1.Controls.Add(_Button1);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Location = new Point(5, 1);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(505, 421);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            // 
            // Label4
            // 
            _Label4.AutoSize = true;
            _Label4.Location = new Point(19, 333);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(145, 13);
            _Label4.TabIndex = 14;
            _Label4.Text = "Additional Notes To Engineer";
            // 
            // txtEngineernotes
            // 
            _txtEngineernotes.Location = new Point(170, 330);
            _txtEngineernotes.Multiline = true;
            _txtEngineernotes.Name = "txtEngineernotes";
            _txtEngineernotes.Size = new Size(226, 51);
            _txtEngineernotes.TabIndex = 13;
            // 
            // lblMessage
            // 
            _lblMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _lblMessage.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMessage.ForeColor = Color.Maroon;
            _lblMessage.Location = new Point(7, 241);
            _lblMessage.Name = "lblMessage";
            _lblMessage.Size = new Size(492, 24);
            _lblMessage.TabIndex = 12;
            _lblMessage.TextAlign = ContentAlignment.TopCenter;
            // 
            // dtpDate
            // 
            _dtpDate.ActiveMonth.Month = 5;
            _dtpDate.ActiveMonth.Year = 2017;
            _dtpDate.Culture = new System.Globalization.CultureInfo("en-GB");
            _dtpDate.Footer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            _dtpDate.Header.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            _dtpDate.Header.TextColor = Color.White;
            _dtpDate.ImageList = null;
            _dtpDate.Location = new Point(170, 43);
            _dtpDate.MaxDate = new DateTime(2027, 5, 10, 12, 28, 13, 983);
            _dtpDate.MinDate = new DateTime(2007, 5, 10, 12, 28, 13, 983);
            _dtpDate.Month.BackgroundImage = null;
            _dtpDate.Month.DateFont = new Font("Microsoft Sans Serif", 8.25F);
            _dtpDate.Month.TextFont = new Font("Microsoft Sans Serif", 8.25F);
            _dtpDate.Name = "dtpDate";
            _dtpDate.SelectionMode = Pabo.Calendar.mcSelectionMode.One;
            _dtpDate.Size = new Size(225, 195);
            _dtpDate.TabIndex = 11;
            _dtpDate.Weekdays.Font = new Font("Microsoft Sans Serif", 8.25F);
            _dtpDate.Weeknumbers.Font = new Font("Microsoft Sans Serif", 8.25F);
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(93, 282);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(66, 13);
            _Label2.TabIndex = 10;
            _Label2.Text = "Appointment";
            // 
            // cboAppointment
            // 
            _cboAppointment.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAppointment.FormattingEnabled = true;
            _cboAppointment.Location = new Point(170, 277);
            _cboAppointment.Name = "cboAppointment";
            _cboAppointment.Size = new Size(226, 21);
            _cboAppointment.TabIndex = 8;
            // 
            // Button1
            // 
            _Button1.UseVisualStyleBackColor = true;
            _Button1.Location = new Point(7, 392);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(75, 23);
            _Button1.TabIndex = 7;
            _Button1.Text = "Cancel";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.ForeColor = Color.Maroon;
            _Label3.Location = new Point(184, 16);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(186, 16);
            _Label3.TabIndex = 6;
            _Label3.Text = "Please select an Appointment";
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(93, 55);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(30, 13);
            _Label1.TabIndex = 3;
            _Label1.Text = "Date";
            // 
            // btnOK
            // 
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(424, 392);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 1;
            _btnOK.Text = "Proceed";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // FRMBookJob
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(513, 434);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(529, 393);
            Name = "FRMBookJob";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Appointment";
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

        private ComboBox _cboAppointment;

        internal ComboBox cboAppointment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAppointment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAppointment != null)
                {
                }

                _cboAppointment = value;
                if (_cboAppointment != null)
                {
                }
            }
        }

        private Pabo.Calendar.MonthCalendar _dtpDate;

        internal Pabo.Calendar.MonthCalendar dtpDate
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
                    _dtpDate.DayClick -= dtpDate_MonthChanged;
                }

                _dtpDate = value;
                if (_dtpDate != null)
                {
                    _dtpDate.DayClick += dtpDate_MonthChanged;
                }
            }
        }

        private Label _lblMessage;

        internal Label lblMessage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMessage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMessage != null)
                {
                }

                _lblMessage = value;
                if (_lblMessage != null)
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

        private TextBox _txtEngineernotes;

        internal TextBox txtEngineernotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineernotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineernotes != null)
                {
                }

                _txtEngineernotes = value;
                if (_txtEngineernotes != null)
                {
                }
            }
        }
    }
}