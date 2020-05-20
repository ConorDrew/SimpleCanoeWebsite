using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class FRMDuplicateInvoices : FRMBaseForm
    {
        public FRMDuplicateInvoices()
        {
            base.Load += FRMDuplicateInovoices_Load;
            base.FormClosing += FRMDuplicateInvoices_FormClosing;
        }

        

        public FRMDuplicateInvoices(List<Importer.DuplicateInvoice> duplicateInvoices) : base()
        {
            base.Load += FRMDuplicateInovoices_Load;
            base.FormClosing += FRMDuplicateInvoices_FormClosing;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            _duplicateInvoices = duplicateInvoices;

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

        private TabControl _tcData;

        internal TabControl tcData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcData != null)
                {
                }

                _tcData = value;
                if (_tcData != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _tcData = new TabControl();
            SuspendLayout();
            //
            // tcData
            //
            _tcData.Dock = DockStyle.Fill;
            _tcData.Location = new Point(0, 32);
            _tcData.Name = "tcData";
            _tcData.SelectedIndex = 0;
            _tcData.Size = new Size(1008, 430);
            _tcData.TabIndex = 9;
            //
            // FRMDuplicateInvoices
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1008, 462);
            Controls.Add(_tcData);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(848, 496);
            Name = "FRMDuplicateInvoices";
            Text = "Job Portal - Duplicate Imports";
            Controls.SetChildIndex(_tcData, 0);
            ResumeLayout(false);
        }

        private List<Importer.DuplicateInvoice> _duplicateInvoices = new List<Importer.DuplicateInvoice>();

        private List<Importer.DuplicateInvoice> DuplicateInvoices
        {
            get
            {
                return _duplicateInvoices;
            }
        }

        
        

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void FRMDuplicateInovoices_Load(object sender, EventArgs e)
        {
            tcData.TabPages.Clear();
            var tp = new TabPage();
            var dt = Entity.Sys.Helper.ToDataTable(DuplicateInvoices);
            var dv = new DataView(dt);
            var data = new UCDataPODuplicateInvoice();
            data.Dock = DockStyle.Fill;
            data.Data = dv;
            tp.Controls.Add(data);
            tcData.TabPages.Add(tp);
            tcData.SelectedIndex = 0;
        }

        private void FRMDuplicateInvoices_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // check user wants to close window
                if (e.CloseReason == CloseReason.FormOwnerClosing || e.CloseReason == CloseReason.UserClosing)
                {
                    if (Interaction.MsgBox("Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Form closing") == MsgBoxResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }

        
    }
}