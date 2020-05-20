using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class UCJobCostings : UCBase
    {
        public UCJobCostings()
        {
            base.Load += UCJobCost_Load;
        }

        public UCJobCostings(int IDToLinkToIn) : base()
        {
            base.Load += UCJobCost_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            IDToLinkTo = IDToLinkToIn;
            Dock = DockStyle.Fill;
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
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SuspendLayout();
            //
            // UCJobCostings
            //
            Name = "UCJobCostings";
            Size = new Size(504, 560);
            ResumeLayout(false);
        }

        private Entity.JobInstalls.JobInstall _JI;

        private Entity.JobInstalls.JobInstall JI
        {
            get
            {
                return _JI;
            }

            set
            {
                _JI = value;
            }
        }

        private int _IDToLinkTo = 0;

        public int IDToLinkTo
        {
            get
            {
                return _IDToLinkTo;
            }

            set
            {
                _IDToLinkTo = value;
                if (IDToLinkTo == 0)
                {
                }
                else
                {
                }
            }
        }

        private DataView _dvDocuments;

        private void UCJobCost_Load(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }
    }
}