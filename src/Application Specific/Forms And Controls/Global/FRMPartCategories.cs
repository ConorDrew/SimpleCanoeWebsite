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
    public class FRMPartCategories : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMPartCategories() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMPartCategories_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboCategory;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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
        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private DataGrid _dgManager;

        internal DataGrid dgManager
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgManager;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgManager != null)
                {
                    _dgManager.Click -= dgManager_Click;
                }

                _dgManager = value;
                if (_dgManager != null)
                {
                    _dgManager.Click += dgManager_Click;
                }
            }
        }

        private Button _btnAddNew;

        internal Button btnAddNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddNew != null)
                {
                    _btnAddNew.Click -= btnAddNew_Click;
                }

                _btnAddNew = value;
                if (_btnAddNew != null)
                {
                    _btnAddNew.Click += btnAddNew_Click;
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

        private GroupBox _grpDetails;

        internal GroupBox grpDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpDetails != null)
                {
                }

                _grpDetails = value;
                if (_grpDetails != null)
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

        private ComboBox _cboCategory;

        internal ComboBox cboCategory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCategory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCategory != null)
                {
                }

                _cboCategory = value;
                if (_cboCategory != null)
                {
                }
            }
        }

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _dgManager = new DataGrid();
            _dgManager.Click += new EventHandler(dgManager_Click);
            _grpDetails = new GroupBox();
            _cboCategory = new ComboBox();
            _Label1 = new Label();
            _txtName = new TextBox();
            _Label2 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgManager).BeginInit();
            _grpDetails.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_btnAddNew);
            _GroupBox1.Controls.Add(_btnDelete);
            _GroupBox1.Controls.Add(_dgManager);
            _GroupBox1.Location = new Point(8, 40);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(780, 344);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Part Categories Mapping";
            // 
            // btnAddNew
            // 
            _btnAddNew.AccessibleDescription = "Add new item";
            _btnAddNew.Cursor = Cursors.Hand;
            _btnAddNew.UseVisualStyleBackColor = true;
            _btnAddNew.Location = new Point(8, 16);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.Size = new Size(48, 24);
            _btnAddNew.TabIndex = 5;
            _btnAddNew.Text = "New";
            // 
            // btnDelete
            // 
            _btnDelete.AccessibleDescription = "Delete item";
            _btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnDelete.Cursor = Cursors.Hand;
            _btnDelete.UseVisualStyleBackColor = true;
            _btnDelete.Location = new Point(724, 18);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(48, 24);
            _btnDelete.TabIndex = 6;
            _btnDelete.Text = "Delete";
            // 
            // dgManager
            // 
            _dgManager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgManager.DataMember = "";
            _dgManager.HeaderForeColor = SystemColors.ControlText;
            _dgManager.Location = new Point(8, 49);
            _dgManager.Name = "dgManager";
            _dgManager.Size = new Size(764, 287);
            _dgManager.TabIndex = 0;
            // 
            // grpDetails
            // 
            _grpDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _grpDetails.Controls.Add(_cboCategory);
            _grpDetails.Controls.Add(_Label1);
            _grpDetails.Controls.Add(_txtName);
            _grpDetails.Controls.Add(_Label2);
            _grpDetails.Controls.Add(_btnSave);
            _grpDetails.Location = new Point(8, 384);
            _grpDetails.Name = "grpDetails";
            _grpDetails.Size = new Size(780, 56);
            _grpDetails.TabIndex = 8;
            _grpDetails.TabStop = false;
            _grpDetails.Text = "Details";
            // 
            // cboCategory
            // 
            _cboCategory.Location = new Point(409, 21);
            _cboCategory.Name = "cboCategory";
            _cboCategory.Size = new Size(306, 21);
            _cboCategory.TabIndex = 9;
            // 
            // Label1
            // 
            _Label1.Location = new Point(357, 24);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(80, 23);
            _Label1.TabIndex = 8;
            _Label1.Text = "Map To";
            // 
            // txtName
            // 
            _txtName.Location = new Point(79, 21);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(265, 21);
            _txtName.TabIndex = 5;
            // 
            // Label2
            // 
            _Label2.Location = new Point(8, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(80, 23);
            _Label2.TabIndex = 5;
            _Label2.Text = "Map From";
            // 
            // btnSave
            // 
            _btnSave.AccessibleDescription = "Save item";
            _btnSave.Cursor = Cursors.Hand;
            _btnSave.UseVisualStyleBackColor = true;
            _btnSave.ImageIndex = 1;
            _btnSave.Location = new Point(721, 19);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(48, 23);
            _btnSave.TabIndex = 7;
            _btnSave.Text = "Save";
            // 
            // FRMPartCategories
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(796, 454);
            Controls.Add(_GroupBox1);
            Controls.Add(_grpDetails);
            MinimumSize = new Size(496, 488);
            Name = "FRMPartCategories";
            Text = "Part Categories";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpDetails, 0);
            Controls.SetChildIndex(_GroupBox1, 0);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgManager).EndInit();
            _grpDetails.ResumeLayout(false);
            _grpDetails.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupManagerDataGrid();
            PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        private DataView _dvManager;

        private DataView ManagerDataview
        {
            get
            {
                return _dvManager;
            }

            set
            {
                _dvManager = value;
                _dvManager.AllowNew = false;
                _dvManager.AllowEdit = false;
                _dvManager.AllowDelete = false;
                _dvManager.Table.TableName = Entity.Sys.Enums.TableNames.tblPartCategoryMapping.ToString();
                dgManager.DataSource = ManagerDataview;
            }
        }

        private DataRow SelectedManagerDataRow
        {
            get
            {
                if (!(dgManager.CurrentRowIndex == -1))
                {
                    return ManagerDataview[dgManager.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupManagerDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgManager);
            var tbStyle = dgManager.TableStyles[0];
            var PartMapID = new DataGridLabelColumn();
            PartMapID.HeaderText = "ID";
            PartMapID.MappingName = "PartMapID";
            PartMapID.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(PartMapID);
            var name = new DataGridLabelColumn();
            name.Format = "";
            name.FormatInfo = null;
            name.HeaderText = "Map To";
            name.MappingName = "Name";
            name.ReadOnly = true;
            name.Width = 177;
            name.NullText = "";
            tbStyle.GridColumnStyles.Add(name);
            var mapping = new DataGridLabelColumn();
            mapping.Format = "";
            mapping.FormatInfo = null;
            mapping.HeaderText = "Map From";
            mapping.MappingName = "PartMapMatch";
            mapping.ReadOnly = true;
            mapping.Width = 177;
            mapping.NullText = "";
            tbStyle.GridColumnStyles.Add(mapping);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartCategoryMapping.ToString();
            dgManager.TableStyles.Add(tbStyle);
        }

        private void SetUpPageState(Entity.Sys.Enums.FormState state)
        {
            Entity.Sys.Helper.ClearGroupBox(grpDetails);
            switch (state)
            {
                case Entity.Sys.Enums.FormState.Load:
                    {
                        grpDetails.Enabled = false;
                        btnAddNew.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Insert:
                    {
                        grpDetails.Enabled = true;
                        btnAddNew.Enabled = true;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Update:
                    {
                        btnAddNew.Enabled = true;
                        grpDetails.Enabled = true;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        break;
                    }
            }

            PageState = state;
        }

        private void FRMPartCategories_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void dgManager_Click(object sender, EventArgs e)
        {
            try
            {
                SetUpPageState(Entity.Sys.Enums.FormState.Update);
                if (SelectedManagerDataRow is object)
                {
                    txtName.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow["PartMapMatch"]);
                    var argcombo = cboCategory;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(SelectedManagerDataRow["ManagerID"]));
                }
                else
                {
                    SetUpPageState(Entity.Sys.Enums.FormState.Insert);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Item data cannot load : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SetUpPageState(Entity.Sys.Enums.FormState.Insert);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void PopulateDatagrid(Entity.Sys.Enums.FormState state)
        {
            ManagerDataview = App.DB.Picklists.GetAllPartMappings(Entity.Sys.Enums.PickListTypes.PartCategories);
            SetUpPageState(state);
        }

        private void Save()
        {
            try
            {
                var switchExpr = PageState;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            App.DB.Picklists.InsertPartCategory(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboCategory)), txtName.Text);
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            App.DB.Picklists.UpdatePartMapping(Conversions.ToInteger(SelectedManagerDataRow["PartMapID"]), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboCategory)), txtName.Text);
                            break;
                        }
                }

                PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error Saving : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            try
            {
                if (SelectedManagerDataRow is object)
                {
                    if ((int)App.ShowMessage(Conversions.ToString("Are you sure you want to delete \"" + SelectedManagerDataRow["Name"] + "\" from " + " Part Categories " + "?"), MessageBoxButtons.YesNo, (MessageBoxIcon)MsgBoxStyle.Question) == (int)MsgBoxResult.Yes)
                    {
                        App.DB.Picklists.DeletePartMapping(Conversions.ToInteger(SelectedManagerDataRow["PartMapID"]));
                        PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
                    }
                }
                else
                {
                    App.ShowMessage("Please select an item to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error deleting : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}