using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FRMAddPartToBeCredited : FRMBaseForm, IForm
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
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _GroupBox1 = new GroupBox();
            _Label2 = new Label();
            _txtQtyToReturn = new TextBox();
            _txtQtyAvailable = new TextBox();
            _Label1 = new Label();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOK
            // 
            _btnOK.Location = new Point(298, 52);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 2;
            _btnOK.Text = "OK";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            _GroupBox1.Controls.Add(_Label2);
            _GroupBox1.Controls.Add(_txtQtyToReturn);
            _GroupBox1.Controls.Add(_btnOK);
            _GroupBox1.Controls.Add(_txtQtyAvailable);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Location = new Point(12, 38);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(384, 91);
            _GroupBox1.TabIndex = 3;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Return part to the supplier for credit?";
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 57);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(115, 13);
            _Label2.TabIndex = 3;
            _Label2.Text = "Quantity To Return";
            // 
            // txtQtyToReturn
            // 
            _txtQtyToReturn.Location = new Point(123, 54);
            _txtQtyToReturn.Name = "txtQtyToReturn";
            _txtQtyToReturn.Size = new Size(100, 21);
            _txtQtyToReturn.TabIndex = 2;
            _txtQtyToReturn.Text = "0";
            _txtQtyToReturn.TextAlign = HorizontalAlignment.Right;
            // 
            // txtQtyAvailable
            // 
            _txtQtyAvailable.Location = new Point(123, 27);
            _txtQtyAvailable.Name = "txtQtyAvailable";
            _txtQtyAvailable.ReadOnly = true;
            _txtQtyAvailable.Size = new Size(100, 21);
            _txtQtyAvailable.TabIndex = 1;
            _txtQtyAvailable.TextAlign = HorizontalAlignment.Right;
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(6, 30);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(111, 13);
            _Label1.TabIndex = 0;
            _Label1.Text = "Quantity Available";
            // 
            // FRMAddPartToBeCredited
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 136);
            ControlBox = false;
            Controls.Add(_GroupBox1);
            Name = "FRMAddPartToBeCredited";
            Text = "Add Part To Be Credited";
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            ResumeLayout(false);
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

        private TextBox _txtQtyToReturn;

        internal TextBox txtQtyToReturn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQtyToReturn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQtyToReturn != null)
                {
                }

                _txtQtyToReturn = value;
                if (_txtQtyToReturn != null)
                {
                }
            }
        }

        private TextBox _txtQtyAvailable;

        internal TextBox txtQtyAvailable
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQtyAvailable;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQtyAvailable != null)
                {
                }

                _txtQtyAvailable = value;
                if (_txtQtyAvailable != null)
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
    }
}