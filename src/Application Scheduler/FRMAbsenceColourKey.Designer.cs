using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMAbsenceColourKey : Form
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
            _dgAbsences = new DataGrid();
            ((System.ComponentModel.ISupportInitialize)_dgAbsences).BeginInit();
            SuspendLayout();
            // 
            // dgAbsences
            // 
            _dgAbsences.AllowNavigation = false;
            _dgAbsences.AlternatingBackColor = Color.GhostWhite;
            _dgAbsences.BackgroundColor = Color.White;
            _dgAbsences.BorderStyle = BorderStyle.FixedSingle;
            _dgAbsences.CaptionBackColor = Color.RoyalBlue;
            _dgAbsences.CaptionForeColor = Color.White;
            _dgAbsences.CaptionVisible = false;
            _dgAbsences.DataMember = "";
            _dgAbsences.Dock = DockStyle.Fill;
            _dgAbsences.Font = new Font("Verdana", 8.0F);
            _dgAbsences.ForeColor = Color.MidnightBlue;
            _dgAbsences.GridLineColor = Color.RoyalBlue;
            _dgAbsences.HeaderBackColor = Color.MidnightBlue;
            _dgAbsences.HeaderFont = new Font("Tahoma", 8.0F, FontStyle.Bold);
            _dgAbsences.HeaderForeColor = Color.Lavender;
            _dgAbsences.LinkColor = Color.Teal;
            _dgAbsences.Location = new Point(0, 0);
            _dgAbsences.Name = "dgAbsences";
            _dgAbsences.ParentRowsBackColor = Color.Lavender;
            _dgAbsences.ParentRowsForeColor = Color.MidnightBlue;
            _dgAbsences.ParentRowsVisible = false;
            _dgAbsences.RowHeadersVisible = false;
            _dgAbsences.SelectionBackColor = Color.Teal;
            _dgAbsences.SelectionForeColor = Color.PaleGreen;
            _dgAbsences.Size = new Size(292, 266);
            _dgAbsences.TabIndex = 8;
            // 
            // FRMAbsenceColourKey
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 266);
            Controls.Add(_dgAbsences);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FRMAbsenceColourKey";
            Text = "Absence Colour Key";
            ((System.ComponentModel.ISupportInitialize)_dgAbsences).EndInit();
            Load += new EventHandler(FRMAbsenceColourKey_Load);
            ResumeLayout(false);
        }

        private DataGrid _dgAbsences;

        internal DataGrid dgAbsences
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAbsences;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAbsences != null)
                {
                }

                _dgAbsences = value;
                if (_dgAbsences != null)
                {
                }
            }
        }
    }
}