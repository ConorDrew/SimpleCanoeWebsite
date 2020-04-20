using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCSignature : UserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCSignature() : base()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        private PictureBox _pbSignature;

        internal PictureBox pbSignature
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbSignature;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _pbSignature = value;
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _pbSignature = new PictureBox();
            SuspendLayout();
            // 
            // pbSignature
            // 
            _pbSignature.Location = new Point(0, 0);
            _pbSignature.Name = "pbSignature";
            _pbSignature.Size = new Size(320, 88);
            _pbSignature.TabIndex = 12;
            _pbSignature.TabStop = false;
            // 
            // UCSignature
            // 
            Controls.Add(_pbSignature);
            Name = "UCSignature";
            Size = new Size(320, 88);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string _signatureData = "";

        public string SignatureData
        {
            get
            {
                return _signatureData;
            }

            set
            {
                _signatureData = value;
                var argpic = pbSignature;
                var signatureControl = new Entity.Sys.SignatureBox(ref argpic);
                signatureControl.plotSignature(SignatureData);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}