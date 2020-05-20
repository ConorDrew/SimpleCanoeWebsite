using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMQuoteRejection : FRMBaseForm, IForm
    {
        

        public FRMQuoteRejection() : base()
        {
            
            
            base.Load += FRMQuoteContractSite_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            TheLoadedControl = new UCQuoteRejection();
            pnlMain.Controls.Add((Control)TheLoadedControl);
            LoadedControl.StateChanged += ResetMe;
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
        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        private Panel _pnlMain;

        internal Panel pnlMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlMain != null)
                {
                }

                _pnlMain = value;
                if (_pnlMain != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._pnlMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Location = new System.Drawing.Point(8, 312);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 25);
            this._btnSave.TabIndex = 2;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(72, 312);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 25);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _pnlMain
            // 
            this._pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlMain.Location = new System.Drawing.Point(0, 12);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(688, 292);
            this._pnlMain.TabIndex = 1;
            // 
            // FRMQuoteRejection
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(696, 350);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(704, 384);
            this.Name = "FRMQuoteRejection";
            this.Text = "Reject Quote : ID {0}";
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            ((UCQuoteRejection)TheLoadedControl).ReasonChanged += ReasonChanged;
            Reason = Entity.Sys.Helper.MakeStringValid(get_GetParameter(1));
            ReasonID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(2));
            LoadForm(sender, e, this);
        }

        public IUserControl LoadedControl
        {
            get
            {
                return (IUserControl)pnlMain.Controls[0];
            }
        }

        public void ResetMe(int newID)
        {
            ID = newID;
        }

        
        
        private IUserControl TheLoadedControl;

        public event ReasonEditedEventHandler ReasonEdited;

        public delegate void ReasonEditedEventHandler(string reason, int ReasonID);

        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        private string _Reason = "";

        public string Reason
        {
            get
            {
                return _Reason;
            }

            set
            {
                _Reason = value;
                if (string.IsNullOrEmpty(Reason))
                {
                    Text = "Add reason for rejection";
                }
                else
                {
                    Text = "Edit reason for rejection";
                    ((UCQuoteRejection)TheLoadedControl).txtReason.Text = Reason;
                }
            }
        }

        private int _ReasonID = 0;

        public int ReasonID
        {
            get
            {
                return _ReasonID;
            }

            set
            {
                _ReasonID = value;
                if (ReasonID == 0)
                {
                }
                else
                {
                    var argcombo = ((UCQuoteRejection)TheLoadedControl).cboPossibleReasons;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, ReasonID.ToString());
                    // CType(TheLoadedControl, UCQuoteRejection).cboPossibleReasons.SelectedIndex = ReasonID
                }
            }
        }

        private Entity.Sys.Enums.FormState _pageState;

        private Entity.Sys.Enums.FormState PageState
        {
            get
            {
                return _pageState;
            }

            set
            {
                _pageState = value;
            }
        }

        private void FRMQuoteContractSite_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadedControl.Save())
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

        public void ReasonChanged(string reason, int ReasonID)
        {
            ReasonEdited?.Invoke(reason, ReasonID);
        }

        
    }
}