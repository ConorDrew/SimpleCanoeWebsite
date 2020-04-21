using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCSearchJobs : UCBase, ISearchControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCSearchJobs() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCSearchPerformanceSetup_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

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

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
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

        private ComboBox _cboSearchFor;

        internal ComboBox cboSearchFor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSearchFor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSearchFor != null)
                {
                }

                _cboSearchFor = value;
                if (_cboSearchFor != null)
                {
                }
            }
        }

        private TextBox _txtCriteria;

        internal TextBox txtCriteria
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCriteria;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCriteria != null)
                {
                }

                _txtCriteria = value;
                if (_txtCriteria != null)
                {
                }
            }
        }

        private Button _btnFind;

        internal Button btnFind
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFind;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFind != null)
                {
                    _btnFind.Click -= btnFind_Click;
                }

                _btnFind = value;
                if (_btnFind != null)
                {
                    _btnFind.Click += btnFind_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _Label1 = new Label();
            _cboSearchFor = new ComboBox();
            _Label2 = new Label();
            _txtCriteria = new TextBox();
            _btnFind = new Button();
            _btnFind.Click += new EventHandler(btnFind_Click);
            SuspendLayout();
            //
            // Label1
            //
            _Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label1.Location = new Point(8, 8);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(72, 16);
            _Label1.TabIndex = 0;
            _Label1.Text = "Search For";
            //
            // cboSearchFor
            //
            _cboSearchFor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _cboSearchFor.Cursor = Cursors.Hand;
            _cboSearchFor.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSearchFor.Location = new Point(8, 24);
            _cboSearchFor.Name = "cboSearchFor";
            _cboSearchFor.Size = new Size(152, 21);
            _cboSearchFor.TabIndex = 1;
            //
            // Label2
            //
            _Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label2.Location = new Point(8, 48);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(152, 16);
            _Label2.TabIndex = 2;
            _Label2.Text = "Enter Search Criteria";
            //
            // txtCriteria
            //
            _txtCriteria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtCriteria.Location = new Point(8, 64);
            _txtCriteria.MaxLength = 25;
            _txtCriteria.Name = "txtCriteria";
            _txtCriteria.Size = new Size(103, 21);
            _txtCriteria.TabIndex = 2;
            //
            // btnFind
            //
            _btnFind.AccessibleDescription = "Search for records by comparing multiple columns";
            _btnFind.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnFind.Cursor = Cursors.Hand;
            _btnFind.Location = new Point(117, 64);
            _btnFind.Name = "btnFind";
            _btnFind.Size = new Size(43, 23);
            _btnFind.TabIndex = 3;
            _btnFind.Text = "Find";
            _btnFind.UseVisualStyleBackColor = true;
            //
            // UCSearchJobs
            //
            Controls.Add(_btnFind);
            Controls.Add(_txtCriteria);
            Controls.Add(_Label2);
            Controls.Add(_cboSearchFor);
            Controls.Add(_Label1);
            Name = "UCSearchJobs";
            Size = new Size(160, 96);
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            var argc = cboSearchFor;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Setup_Search_Options(Entity.Sys.Enums.MenuTypes.Jobs), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        public void Search()
        {
            if ((Combo.get_GetSelectedItemValue(cboSearchFor) ?? "") == "0")
            {
                App.ShowMessage("Please select what you would like to search for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Navigation.Close_Middle();
            Navigation.Close_Right();
            foreach (Form form in App.MainForm.MdiChildren)
                form.Dispose();
            var switchExpr = Combo.get_GetSelectedItemValue(cboSearchFor);
            switch (switchExpr)
            {
                case var @case when @case == Conversions.ToString(Entity.Sys.Enums.TableNames.tblEngineerVisit):
                    {
                        App.ShowForm(typeof(FRMVisitManager), false, new object[] { App.DB.EngineerVisits.EngineerVisits_Search(txtCriteria.Text.Trim()) });
                        break;
                    }

                case var case1 when case1 == Conversions.ToString(Entity.Sys.Enums.TableNames.tblQuotes):
                    {
                        App.ShowForm(typeof(FRMQuoteManager), false, new object[] { App.DB.Quotes.Quotes_Search(txtCriteria.Text.Trim()) });
                        break;
                    }
            }
        }

        private void UCSearchPerformanceSetup_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Search();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}