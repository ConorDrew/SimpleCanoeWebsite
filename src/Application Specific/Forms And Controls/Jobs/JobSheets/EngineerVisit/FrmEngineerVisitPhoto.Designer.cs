using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FrmEngineerVisitPhoto : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEngineerVisitPhoto));
            _Panel1 = new Panel();
            _btnSavePicture = new Button();
            _btnSavePicture.Click += new EventHandler(btnSavePicture_Click);
            _picImage = new PictureBox();
            _Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_picImage).BeginInit();
            SuspendLayout();
            // 
            // Panel1
            // 
            _Panel1.Controls.Add(_btnSavePicture);
            _Panel1.Dock = DockStyle.Bottom;
            _Panel1.Location = new Point(0, 668);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(877, 32);
            _Panel1.TabIndex = 1;
            // 
            // btnSavePicture
            // 
            _btnSavePicture.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSavePicture.Location = new Point(799, 6);
            _btnSavePicture.Name = "btnSavePicture";
            _btnSavePicture.Size = new Size(75, 23);
            _btnSavePicture.TabIndex = 0;
            _btnSavePicture.Text = "Save";
            _btnSavePicture.UseVisualStyleBackColor = true;
            // 
            // picImage
            // 
            _picImage.Dock = DockStyle.Fill;
            _picImage.Location = new Point(0, 0);
            _picImage.Name = "picImage";
            _picImage.Size = new Size(877, 668);
            _picImage.SizeMode = PictureBoxSizeMode.Zoom;
            _picImage.TabIndex = 2;
            _picImage.TabStop = false;
            // 
            // FrmEngineerVisitPhoto
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 700);
            Controls.Add(_picImage);
            Controls.Add(_Panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmEngineerVisitPhoto";
            Text = "Engineer Visit Photo";
            _Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_picImage).EndInit();
            ResumeLayout(false);
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                }
            }
        }

        private Button _btnSavePicture;

        internal Button btnSavePicture
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSavePicture;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSavePicture != null)
                {
                    _btnSavePicture.Click -= btnSavePicture_Click;
                }

                _btnSavePicture = value;
                if (_btnSavePicture != null)
                {
                    _btnSavePicture.Click += btnSavePicture_Click;
                }
            }
        }

        private PictureBox _picImage;

        internal PictureBox picImage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picImage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picImage != null)
                {
                }

                _picImage = value;
                if (_picImage != null)
                {
                }
            }
        }
    }
}