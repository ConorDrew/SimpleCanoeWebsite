using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCDocumentsList : UCBase
    {
        public UCDocumentsList()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCDocumentsList_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCDocumentsList(Entity.Sys.Enums.TableNames EntityToLinkToIn, int IDToLinkToIn) : base()
        {
            base.Load += UCDocumentsList_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            EntityToLinkTo = EntityToLinkToIn;
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

        private DataGrid _dgDocuments;

        internal DataGrid dgDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgDocuments != null)
                {
                    _dgDocuments.DoubleClick -= dgDocuments_DoubleClick;
                }

                _dgDocuments = value;
                if (_dgDocuments != null)
                {
                    _dgDocuments.DoubleClick += dgDocuments_DoubleClick;
                }
            }
        }

        private Button _btnDelete;

        internal Button btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
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
            _grpDocuments = new GroupBox();
            _dgDocuments = new DataGrid();
            _dgDocuments.DoubleClick += new EventHandler(dgDocuments_DoubleClick);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _grpDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgDocuments).BeginInit();
            SuspendLayout();
            // 
            // grpDocuments
            // 
            _grpDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpDocuments.Controls.Add(_dgDocuments);
            _grpDocuments.Location = new Point(8, 8);
            _grpDocuments.Name = "grpDocuments";
            _grpDocuments.Size = new Size(488, 512);
            _grpDocuments.TabIndex = 0;
            _grpDocuments.TabStop = false;
            _grpDocuments.Text = "Double Click To View / Edit";
            // 
            // dgDocuments
            // 
            _dgDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgDocuments.DataMember = "";
            _dgDocuments.HeaderForeColor = SystemColors.ControlText;
            _dgDocuments.Location = new Point(8, 26);
            _dgDocuments.Name = "dgDocuments";
            _dgDocuments.Size = new Size(472, 478);
            _dgDocuments.TabIndex = 1;
            // 
            // btnDelete
            // 
            _btnDelete.AccessibleDescription = "";
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDelete.Location = new Point(440, 528);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(56, 25);
            _btnDelete.TabIndex = 3;
            _btnDelete.Text = "Delete";
            // 
            // btnAdd
            // 
            _btnAdd.AccessibleDescription = "";
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAdd.Location = new Point(8, 528);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(56, 25);
            _btnAdd.TabIndex = 2;
            _btnAdd.Text = "Add";
            // 
            // UCDocumentsList
            // 
            Controls.Add(_btnDelete);
            Controls.Add(_btnAdd);
            Controls.Add(_grpDocuments);
            Name = "UCDocumentsList";
            Size = new Size(504, 560);
            _grpDocuments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgDocuments).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
                if (IDToLinkTo == 0)
                {
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (EntityToLinkTo == Entity.Sys.Enums.TableNames.tblCustomer)
                    {
                        // So we can see site documents as well at customer level
                        Documents = App.DB.Documents.Documents_GetAll_For_Customer_ID(EntityToLinkTo, IDToLinkTo);
                    }
                    else if (EntityToLinkTo == Entity.Sys.Enums.TableNames.tblSite)
                    {
                        Documents = App.DB.Documents.Documents_GetAll_For_Site_ID(EntityToLinkTo, IDToLinkTo);
                    }
                    else
                    {
                        Documents = App.DB.Documents.Documents_GetAll_For_Entity_ID(EntityToLinkTo, IDToLinkTo);
                    }

                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
        }

        private DataView _dvDocuments;

        public DataView Documents
        {
            get
            {
                return _dvDocuments;
            }

            set
            {
                _dvDocuments = value;
                _dvDocuments.Table.TableName = Entity.Sys.Enums.TableNames.tblDocuments.ToString();
                _dvDocuments.AllowNew = false;
                _dvDocuments.AllowEdit = false;
                _dvDocuments.AllowDelete = false;
                dgDocuments.DataSource = Documents;
            }
        }

        private DataRow SelectedDocumentDataRow
        {
            get
            {
                if (!(dgDocuments.CurrentRowIndex == -1))
                {
                    return Documents[dgDocuments.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupDocumentsDataGrid()
        {
            var tStyle = dgDocuments.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Reference";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 200;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 100;
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 200;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var LastUpdated = new DataGridLabelColumn();
            LastUpdated.Format = "dddd dd MMMM yyyy HH:mm:ss";
            LastUpdated.FormatInfo = null;
            LastUpdated.HeaderText = "Last Updated";
            LastUpdated.MappingName = "LastUpdatedOn";
            LastUpdated.ReadOnly = true;
            LastUpdated.Width = 200;
            LastUpdated.NullText = "";
            tStyle.GridColumnStyles.Add(LastUpdated);
            var LastUpdatedBy = new DataGridLabelColumn();
            LastUpdatedBy.Format = "";
            LastUpdatedBy.FormatInfo = null;
            LastUpdatedBy.HeaderText = "Last Updated By";
            LastUpdatedBy.MappingName = "LastUpdatedByUserName";
            LastUpdatedBy.ReadOnly = true;
            LastUpdatedBy.Width = 200;
            LastUpdatedBy.NullText = "";
            tStyle.GridColumnStyles.Add(LastUpdatedBy);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblDocuments.ToString();
            dgDocuments.TableStyles.Add(tStyle);
        }

        private void UCDocumentsList_Load(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupDocumentsDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMDocuments), true, new object[] { EntityToLinkTo, Entity.Sys.Helper.MakeIntegerValid(IDToLinkTo), 0, this });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedDocumentDataRow is null)
            {
                App.ShowMessage("Please select a document to delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            App.DB.Documents.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedDocumentDataRow["DocumentID"]));
            // Documents = DB.Documents.Documents_GetAll_For_Entity_ID(EntityToLinkTo, IDToLinkTo)
            // JUST REFERESH THROUGH THE PROPERTY
            IDToLinkTo = IDToLinkTo;
        }

        private void dgDocuments_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedDocumentDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMDocuments), true, new object[] { (Entity.Sys.Enums.TableNames)Conversions.ToInteger(SelectedDocumentDataRow["TableEnumID"]), Entity.Sys.Helper.MakeIntegerValid(IDToLinkTo), Entity.Sys.Helper.MakeIntegerValid(SelectedDocumentDataRow["DocumentID"]), this });
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void Populate()
        {
            if (EntityToLinkTo == Entity.Sys.Enums.TableNames.tblCustomer)
            {
                // So we can see site documents as well at customer level
                Documents = App.DB.Documents.Documents_GetAll_For_Customer_ID(EntityToLinkTo, IDToLinkTo);
            }
            else if (EntityToLinkTo == Entity.Sys.Enums.TableNames.tblSite)
            {
                Documents = App.DB.Documents.Documents_GetAll_For_Site_ID(EntityToLinkTo, IDToLinkTo);
            }
            else
            {
                Documents = App.DB.Documents.Documents_GetAll_For_Entity_ID(EntityToLinkTo, IDToLinkTo);
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}