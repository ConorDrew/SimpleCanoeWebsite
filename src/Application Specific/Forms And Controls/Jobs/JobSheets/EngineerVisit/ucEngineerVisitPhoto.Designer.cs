using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class ucEngineerVisitPhoto : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
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
            _txtCaption = new TextBox();
            _txtCaption.TextChanged += new EventHandler(txtCaption_TextChanged);
            _picPhoto = new PictureBox();
            _picPhoto.Click += new EventHandler(picPhoto_Click);
            _picDeleteImage = new PictureBox();
            _picDeleteImage.Click += new EventHandler(picDeleteImage_Click);
            ((System.ComponentModel.ISupportInitialize)_picPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picDeleteImage).BeginInit();
            SuspendLayout();
            // 
            // txtCaption
            // 
            _txtCaption.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCaption.Location = new Point(3, 240);
            _txtCaption.Multiline = true;
            _txtCaption.Name = "txtCaption";
            _txtCaption.Size = new Size(228, 44);
            _txtCaption.TabIndex = 1;
            // 
            // picPhoto
            // 
            _picPhoto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _picPhoto.BackColor = Color.White;
            _picPhoto.Location = new Point(3, 3);
            _picPhoto.Name = "picPhoto";
            _picPhoto.Size = new Size(228, 231);
            _picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            _picPhoto.TabIndex = 4;
            _picPhoto.TabStop = false;
            // 
            // picDeleteImage
            // 
            _picDeleteImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _picDeleteImage.BackColor = Color.Transparent;
            _picDeleteImage.Cursor = Cursors.Hand;
            _picDeleteImage.Image = My.Resources.Resources.delete;
            _picDeleteImage.Location = new Point(208, 3);
            _picDeleteImage.Name = "picDeleteImage";
            _picDeleteImage.Size = new Size(23, 22);
            _picDeleteImage.SizeMode = PictureBoxSizeMode.StretchImage;
            _picDeleteImage.TabIndex = 5;
            _picDeleteImage.TabStop = false;
            // 
            // ucEngineerVisitPhoto
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.WhiteSmoke;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(_picDeleteImage);
            Controls.Add(_txtCaption);
            Controls.Add(_picPhoto);
            Name = "ucEngineerVisitPhoto";
            Size = new Size(234, 287);
            ((System.ComponentModel.ISupportInitialize)_picPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picDeleteImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox _txtCaption;

        internal TextBox txtCaption
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCaption;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCaption != null)
                {
                    _txtCaption.TextChanged -= txtCaption_TextChanged;
                }

                _txtCaption = value;
                if (_txtCaption != null)
                {
                    _txtCaption.TextChanged += txtCaption_TextChanged;
                }
            }
        }

        private PictureBox _picPhoto;

        internal PictureBox picPhoto
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picPhoto;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picPhoto != null)
                {
                    _picPhoto.Click -= picPhoto_Click;
                }

                _picPhoto = value;
                if (_picPhoto != null)
                {
                    _picPhoto.Click += picPhoto_Click;
                }
            }
        }

        private PictureBox _picDeleteImage;

        internal PictureBox picDeleteImage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picDeleteImage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picDeleteImage != null)
                {
                    _picDeleteImage.Click -= picDeleteImage_Click;
                }

                _picDeleteImage = value;
                if (_picDeleteImage != null)
                {
                    _picDeleteImage.Click += picDeleteImage_Click;
                }
            }
        }
    }
}