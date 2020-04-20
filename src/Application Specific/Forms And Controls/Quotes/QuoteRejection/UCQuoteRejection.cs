using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCQuoteRejection : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCQuoteRejection() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCQuoteContractSite_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboPossibleReasons;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.QuoteRejectionReasons).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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
        private GroupBox _grpMain;

        internal GroupBox grpMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpMain != null)
                {
                }

                _grpMain = value;
                if (_grpMain != null)
                {
                }
            }
        }

        private ComboBox _cboPossibleReasons;

        internal ComboBox cboPossibleReasons
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPossibleReasons;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPossibleReasons != null)
                {
                }

                _cboPossibleReasons = value;
                if (_cboPossibleReasons != null)
                {
                }
            }
        }

        private TextBox _txtReason;

        internal TextBox txtReason
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtReason;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtReason != null)
                {
                }

                _txtReason = value;
                if (_txtReason != null)
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

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpMain = new GroupBox();
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _Label2 = new Label();
            _Label1 = new Label();
            _txtReason = new TextBox();
            _cboPossibleReasons = new ComboBox();
            _grpMain.SuspendLayout();
            SuspendLayout();
            // 
            // grpMain
            // 
            _grpMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpMain.Controls.Add(_btnAdd);
            _grpMain.Controls.Add(_Label2);
            _grpMain.Controls.Add(_Label1);
            _grpMain.Controls.Add(_txtReason);
            _grpMain.Controls.Add(_cboPossibleReasons);
            _grpMain.Location = new Point(8, 8);
            _grpMain.Name = "grpMain";
            _grpMain.Size = new Size(625, 266);
            _grpMain.TabIndex = 1;
            _grpMain.TabStop = false;
            _grpMain.Text = "Quote Rejection Reason";
            // 
            // btnAdd
            // 
            _btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAdd.Location = new Point(568, 33);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(48, 23);
            _btnAdd.TabIndex = 2;
            _btnAdd.Text = "Add";
            // 
            // Label2
            // 

            _Label2.Location = new Point(16, 32);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(112, 23);
            _Label2.TabIndex = 3;
            _Label2.Text = "Possible Reasons:";
            // 
            // Label1
            // 

            _Label1.Location = new Point(16, 64);
            _Label1.Name = "Label1";
            _Label1.TabIndex = 2;
            _Label1.Text = "Reason:";
            // 
            // txtReason
            // 
            _txtReason.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtReason.Location = new Point(136, 64);
            _txtReason.Multiline = true;
            _txtReason.Name = "txtReason";
            _txtReason.ScrollBars = ScrollBars.Vertical;
            _txtReason.Size = new Size(480, 192);
            _txtReason.TabIndex = 3;
            _txtReason.Text = "";
            // 
            // cboPossibleReasons
            // 
            _cboPossibleReasons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboPossibleReasons.Location = new Point(136, 33);
            _cboPossibleReasons.Name = "cboPossibleReasons";
            _cboPossibleReasons.Size = new Size(424, 21);
            _cboPossibleReasons.TabIndex = 1;
            // 
            // UCQuoteRejection
            // 
            Controls.Add(_grpMain);
            Name = "UCQuoteRejection";
            Size = new Size(640, 288);
            _grpMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return txtReason.Text;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string ExtraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public event ReasonChangedEventHandler ReasonChanged;

        public delegate void ReasonChangedEventHandler(string reason, int ReasonID);

        private void UCQuoteContractSite_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtReason.Text.Trim().Length > 0)
            {
                txtReason.Text += " " + Combo.get_GetSelectedItemDescription(cboPossibleReasons);
            }
            else
            {
                txtReason.Text += Combo.get_GetSelectedItemDescription(cboPossibleReasons);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (txtReason.Text.Trim().Length > 0)
                {
                    ReasonChanged?.Invoke(txtReason.Text.Trim(), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPossibleReasons)));
                    return true;
                }
                else
                {
                    App.ShowMessage("Please enter a reason", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

    }
}