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
            this._btnOK = new System.Windows.Forms.Button();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._txtQtyToReturn = new System.Windows.Forms.TextBox();
            this._txtQtyAvailable = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(298, 52);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 2;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Controls.Add(this._Label2);
            this._GroupBox1.Controls.Add(this._txtQtyToReturn);
            this._GroupBox1.Controls.Add(this._btnOK);
            this._GroupBox1.Controls.Add(this._txtQtyAvailable);
            this._GroupBox1.Controls.Add(this._Label1);
            this._GroupBox1.Location = new System.Drawing.Point(12, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(384, 91);
            this._GroupBox1.TabIndex = 3;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Return part to the supplier for credit?";
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(6, 57);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(114, 13);
            this._Label2.TabIndex = 3;
            this._Label2.Text = "Quantity To Return";
            // 
            // _txtQtyToReturn
            // 
            this._txtQtyToReturn.Location = new System.Drawing.Point(123, 54);
            this._txtQtyToReturn.Name = "_txtQtyToReturn";
            this._txtQtyToReturn.Size = new System.Drawing.Size(100, 21);
            this._txtQtyToReturn.TabIndex = 2;
            this._txtQtyToReturn.Text = "0";
            this._txtQtyToReturn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _txtQtyAvailable
            // 
            this._txtQtyAvailable.Location = new System.Drawing.Point(123, 27);
            this._txtQtyAvailable.Name = "_txtQtyAvailable";
            this._txtQtyAvailable.ReadOnly = true;
            this._txtQtyAvailable.Size = new System.Drawing.Size(100, 21);
            this._txtQtyAvailable.TabIndex = 1;
            this._txtQtyAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(6, 30);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(111, 13);
            this._Label1.TabIndex = 0;
            this._Label1.Text = "Quantity Available";
            // 
            // FRMAddPartToBeCredited
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 113);
            this.ControlBox = false;
            this.Controls.Add(this._GroupBox1);
            this.MaximumSize = new System.Drawing.Size(422, 152);
            this.MinimumSize = new System.Drawing.Size(422, 152);
            this.Name = "FRMAddPartToBeCredited";
            this.Text = "Add Part To Be Credited";
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this.ResumeLayout(false);

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