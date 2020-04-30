using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCDocuments : UCBase, IUserControl
    {
        

        public UCDocuments() : base()
        {
            
            
            base.Load += UCDocuments_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboDocumentTypeID;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.DocumentTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _grpDocuments;

        internal GroupBox grpDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpDocuments != null)
                {
                }

                _grpDocuments = value;
                if (_grpDocuments != null)
                {
                }
            }
        }

        private Label _lblTableEnumID;

        internal Label lblTableEnumID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTableEnumID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTableEnumID != null)
                {
                }

                _lblTableEnumID = value;
                if (_lblTableEnumID != null)
                {
                }
            }
        }

        private ComboBox _cboDocumentTypeID;

        internal ComboBox cboDocumentTypeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDocumentTypeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDocumentTypeID != null)
                {
                }

                _cboDocumentTypeID = value;
                if (_cboDocumentTypeID != null)
                {
                }
            }
        }

        private Label _lblDocumentTypeID;

        internal Label lblDocumentTypeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDocumentTypeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDocumentTypeID != null)
                {
                }

                _lblDocumentTypeID = value;
                if (_lblDocumentTypeID != null)
                {
                }
            }
        }

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        private Label _lblName;

        internal Label lblName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblName != null)
                {
                }

                _lblName = value;
                if (_lblName != null)
                {
                }
            }
        }

        private TextBox _txtNotes;

        internal TextBox txtNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotes != null)
                {
                }

                _txtNotes = value;
                if (_txtNotes != null)
                {
                }
            }
        }

        private Label _lblNotes;

        internal Label lblNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNotes != null)
                {
                }

                _lblNotes = value;
                if (_lblNotes != null)
                {
                }
            }
        }

        private TextBox _txtLocation;

        internal TextBox txtLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLocation != null)
                {
                }

                _txtLocation = value;
                if (_txtLocation != null)
                {
                }
            }
        }

        private Label _lblLocation;

        internal Label lblLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLocation != null)
                {
                }

                _lblLocation = value;
                if (_lblLocation != null)
                {
                }
            }
        }

        private Button _btnBrowse;

        internal Button btnBrowse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnBrowse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnBrowse != null)
                {
                    _btnBrowse.Click -= btnBrowse_Click;
                }

                _btnBrowse = value;
                if (_btnBrowse != null)
                {
                    _btnBrowse.Click += btnBrowse_Click;
                }
            }
        }

        private TextBox _txtDocumentName;

        internal TextBox txtDocumentName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDocumentName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDocumentName != null)
                {
                }

                _txtDocumentName = value;
                if (_txtDocumentName != null)
                {
                }
            }
        }

        private Label _lblAddedBy;

        internal Label lblAddedBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddedBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddedBy != null)
                {
                }

                _lblAddedBy = value;
                if (_lblAddedBy != null)
                {
                }
            }
        }

        private Label _lblLastUpdated;

        internal Label lblLastUpdated
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLastUpdated;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLastUpdated != null)
                {
                }

                _lblLastUpdated = value;
                if (_lblLastUpdated != null)
                {
                }
            }
        }

        private Button _btnOpen;

        internal Button btnOpen
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOpen;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOpen != null)
                {
                    _btnOpen.Click -= btnOpen_Click;
                }

                _btnOpen = value;
                if (_btnOpen != null)
                {
                    _btnOpen.Click += btnOpen_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpDocuments = new GroupBox();
            _btnOpen = new Button();
            _btnOpen.Click += new EventHandler(btnOpen_Click);
            _lblLastUpdated = new Label();
            _lblAddedBy = new Label();
            _txtDocumentName = new TextBox();
            _btnBrowse = new Button();
            _btnBrowse.Click += new EventHandler(btnBrowse_Click);
            _lblTableEnumID = new Label();
            _cboDocumentTypeID = new ComboBox();
            _lblDocumentTypeID = new Label();
            _txtName = new TextBox();
            _lblName = new Label();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _txtLocation = new TextBox();
            _lblLocation = new Label();
            _grpDocuments.SuspendLayout();
            SuspendLayout();
            //
            // grpDocuments
            //
            _grpDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpDocuments.Controls.Add(_btnOpen);
            _grpDocuments.Controls.Add(_lblLastUpdated);
            _grpDocuments.Controls.Add(_lblAddedBy);
            _grpDocuments.Controls.Add(_txtDocumentName);
            _grpDocuments.Controls.Add(_btnBrowse);
            _grpDocuments.Controls.Add(_lblTableEnumID);
            _grpDocuments.Controls.Add(_cboDocumentTypeID);
            _grpDocuments.Controls.Add(_lblDocumentTypeID);
            _grpDocuments.Controls.Add(_txtName);
            _grpDocuments.Controls.Add(_lblName);
            _grpDocuments.Controls.Add(_txtNotes);
            _grpDocuments.Controls.Add(_lblNotes);
            _grpDocuments.Controls.Add(_txtLocation);
            _grpDocuments.Controls.Add(_lblLocation);
            _grpDocuments.Location = new Point(8, 8);
            _grpDocuments.Name = "grpDocuments";
            _grpDocuments.Size = new Size(636, 533);
            _grpDocuments.TabIndex = 1;
            _grpDocuments.TabStop = false;
            _grpDocuments.Text = "Main Details";
            //
            // btnOpen
            //
            _btnOpen.AccessibleDescription = "Open Document";
            _btnOpen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOpen.Location = new Point(539, 417);
            _btnOpen.Name = "btnOpen";
            _btnOpen.Size = new Size(88, 23);
            _btnOpen.TabIndex = 8;
            _btnOpen.Text = "Open";
            //
            // lblLastUpdated
            //
            _lblLastUpdated.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _lblLastUpdated.ForeColor = Color.Blue;
            _lblLastUpdated.Location = new Point(128, 499);
            _lblLastUpdated.Name = "lblLastUpdated";
            _lblLastUpdated.Size = new Size(499, 24);
            _lblLastUpdated.TabIndex = 33;
            //
            // lblAddedBy
            //
            _lblAddedBy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _lblAddedBy.ForeColor = Color.Blue;
            _lblAddedBy.Location = new Point(128, 459);
            _lblAddedBy.Name = "lblAddedBy";
            _lblAddedBy.Size = new Size(499, 24);
            _lblAddedBy.TabIndex = 32;
            //
            // txtDocumentName
            //
            _txtDocumentName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtDocumentName.Location = new Point(128, 418);
            _txtDocumentName.Name = "txtDocumentName";
            _txtDocumentName.ReadOnly = true;
            _txtDocumentName.Size = new Size(403, 21);
            _txtDocumentName.TabIndex = 7;
            _txtDocumentName.Tag = "";
            //
            // btnBrowse
            //
            _btnBrowse.AccessibleDescription = "Find Document To Upload";
            _btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnBrowse.Location = new Point(539, 386);
            _btnBrowse.Name = "btnBrowse";
            _btnBrowse.Size = new Size(88, 23);
            _btnBrowse.TabIndex = 6;
            _btnBrowse.Text = "Browse";
            //
            // lblTableEnumID
            //
            _lblTableEnumID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _lblTableEnumID.ForeColor = Color.Blue;
            _lblTableEnumID.Location = new Point(8, 28);
            _lblTableEnumID.Name = "lblTableEnumID";
            _lblTableEnumID.Size = new Size(616, 20);
            _lblTableEnumID.TabIndex = 31;
            //
            // cboDocumentTypeID
            //
            _cboDocumentTypeID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboDocumentTypeID.Cursor = Cursors.Hand;
            _cboDocumentTypeID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDocumentTypeID.Location = new Point(128, 59);
            _cboDocumentTypeID.Name = "cboDocumentTypeID";
            _cboDocumentTypeID.Size = new Size(499, 21);
            _cboDocumentTypeID.TabIndex = 2;
            _cboDocumentTypeID.Tag = "Documents.DocumentTypeID";
            //
            // lblDocumentTypeID
            //
            _lblDocumentTypeID.Location = new Point(8, 59);
            _lblDocumentTypeID.Name = "lblDocumentTypeID";
            _lblDocumentTypeID.Size = new Size(112, 20);
            _lblDocumentTypeID.TabIndex = 31;
            _lblDocumentTypeID.Text = "Document Type";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(128, 90);
            _txtName.MaxLength = 50;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(499, 21);
            _txtName.TabIndex = 3;
            _txtName.Tag = "Documents.Name";
            //
            // lblName
            //
            _lblName.Location = new Point(8, 90);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(96, 20);
            _lblName.TabIndex = 31;
            _lblName.Text = "Reference";
            //
            // txtNotes
            //
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(128, 121);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Both;
            _txtNotes.Size = new Size(499, 256);
            _txtNotes.TabIndex = 4;
            _txtNotes.Tag = "Documents.Notes";
            //
            // lblNotes
            //
            _lblNotes.Location = new Point(8, 121);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(112, 20);
            _lblNotes.TabIndex = 31;
            _lblNotes.Text = "Notes";
            //
            // txtLocation
            //
            _txtLocation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtLocation.Location = new Point(128, 387);
            _txtLocation.MaxLength = 16;
            _txtLocation.Name = "txtLocation";
            _txtLocation.ReadOnly = true;
            _txtLocation.Size = new Size(403, 21);
            _txtLocation.TabIndex = 5;
            _txtLocation.Tag = "Documents.Location";
            //
            // lblLocation
            //
            _lblLocation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblLocation.Location = new Point(8, 387);
            _lblLocation.Name = "lblLocation";
            _lblLocation.Size = new Size(104, 20);
            _lblLocation.TabIndex = 31;
            _lblLocation.Text = "Document";
            //
            // UCDocuments
            //
            Controls.Add(_grpDocuments);
            Name = "UCDocuments";
            Size = new Size(651, 555);
            _grpDocuments.ResumeLayout(false);
            _grpDocuments.PerformLayout();
            ResumeLayout(false);
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentDocuments;
            }
        }

        
        

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Documentss.Documents _currentDocuments;

        public Entity.Documentss.Documents CurrentDocuments
        {
            get
            {
                return _currentDocuments;
            }

            set
            {
                _currentDocuments = value;
                if (CurrentDocuments is null)
                {
                    CurrentDocuments = new Entity.Documentss.Documents();
                    CurrentDocuments.Exists = false;
                }

                if (CurrentDocuments.Exists)
                {
                    Populate();
                }
                else
                {
                    lblAddedBy.Text = "Added By : NOT SAVED";
                    lblLastUpdated.Text = "Last Updated By : NOT SAVED";
                    btnBrowse.Enabled = true;
                    btnOpen.Enabled = false;
                }

                lblTableEnumID.Text = "This document is linked to record ID '" + IDToLinkTo + "' for the entity of '" + EntityToLinkTo.ToString().Replace("TBL", "") + "'";
            }
        }

        private Entity.Sys.Enums.TableNames _EntityToLinkTo;

        public Entity.Sys.Enums.TableNames EntityToLinkTo
        {
            get
            {
                return _EntityToLinkTo;
            }

            set
            {
                _EntityToLinkTo = value;
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
            }
        }

        private void UCDocuments_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.ShowDialog();
            if (dlg.FileName.Trim().Length > 0)
            {
                txtLocation.Text = dlg.FileName.Trim();
                txtDocumentName.Text = new System.IO.FileInfo(dlg.FileName.Trim()).Name;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Entity.Sys.Helper.StartProcess(txtLocation.Text.Trim());
            App.DB.Documents.Opened(CurrentDocuments.DocumentID);
            CurrentDocuments = App.DB.Documents.Documents_Get(CurrentDocuments.DocumentID);
            Populate();
            StateChanged?.Invoke(CurrentDocuments.DocumentID);
        }

        
        

        public void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentDocuments = App.DB.Documents.Documents_Get(ID);
            }

            var argcombo = cboDocumentTypeID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentDocuments.DocumentTypeID.ToString());
            txtName.Text = CurrentDocuments.Name;
            txtNotes.Text = CurrentDocuments.Notes;
            txtLocation.Text = CurrentDocuments.Location;
            txtDocumentName.Text = new System.IO.FileInfo(CurrentDocuments.Location).Name;
            lblAddedBy.Text = "Added By : " + CurrentDocuments.AddedByUserName + " at " + Strings.Format(CurrentDocuments.AddedOn, "dddd dd MMMM yyyy HH:mm:ss") + ".";
            lblLastUpdated.Text = "Last Updated By : " + CurrentDocuments.LastUpdatedByUserName + " at " + Strings.Format(CurrentDocuments.LastUpdatedOn, "dddd dd MMMM yyyy HH:mm:ss") + ".";
            btnBrowse.Enabled = false;
            btnOpen.Enabled = true;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentDocuments.IgnoreExceptionsOnSetMethods = true;
                CurrentDocuments.SetTableEnumID = Conversions.ToInteger(EntityToLinkTo);
                CurrentDocuments.SetRecordID = IDToLinkTo;
                CurrentDocuments.SetDocumentTypeID = Combo.get_GetSelectedItemValue(cboDocumentTypeID);
                CurrentDocuments.SetName = txtName.Text.Trim();
                CurrentDocuments.SetNotes = txtNotes.Text.Trim();
                CurrentDocuments.SetLocation = txtLocation.Text.Trim();
                var cV = new Entity.Documentss.DocumentsValidator();
                cV.Validate(CurrentDocuments);
                if (CurrentDocuments.Exists)
                {
                    App.DB.Documents.Update(CurrentDocuments);
                }
                else
                {
                    CurrentDocuments = App.DB.Documents.Insert(CurrentDocuments);
                }

                StateChanged?.Invoke(CurrentDocuments.DocumentID);
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
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

        
    }
}