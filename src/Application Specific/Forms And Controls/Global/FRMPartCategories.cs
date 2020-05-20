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
    public class FRMPartCategories : FRMBaseForm, IForm
    {
        

        public FRMPartCategories() : base()
        {
            
            
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
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._btnAddNew = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._dgManager = new System.Windows.Forms.DataGrid();
            this._grpDetails = new System.Windows.Forms.GroupBox();
            this._cboCategory = new System.Windows.Forms.ComboBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgManager)).BeginInit();
            this._grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._btnAddNew);
            this._GroupBox1.Controls.Add(this._btnDelete);
            this._GroupBox1.Controls.Add(this._dgManager);
            this._GroupBox1.Location = new System.Drawing.Point(8, 12);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(780, 372);
            this._GroupBox1.TabIndex = 2;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Part Categories Mapping";
            // 
            // _btnAddNew
            // 
            this._btnAddNew.AccessibleDescription = "Add new item";
            this._btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddNew.Location = new System.Drawing.Point(8, 16);
            this._btnAddNew.Name = "_btnAddNew";
            this._btnAddNew.Size = new System.Drawing.Size(48, 24);
            this._btnAddNew.TabIndex = 5;
            this._btnAddNew.Text = "New";
            this._btnAddNew.UseVisualStyleBackColor = true;
            this._btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.AccessibleDescription = "Delete item";
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDelete.Location = new System.Drawing.Point(724, 18);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(48, 24);
            this._btnDelete.TabIndex = 6;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // _dgManager
            // 
            this._dgManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgManager.DataMember = "";
            this._dgManager.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgManager.Location = new System.Drawing.Point(8, 49);
            this._dgManager.Name = "_dgManager";
            this._dgManager.Size = new System.Drawing.Size(764, 315);
            this._dgManager.TabIndex = 0;
            this._dgManager.Click += new System.EventHandler(this.dgManager_Click);
            // 
            // _grpDetails
            // 
            this._grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpDetails.Controls.Add(this._cboCategory);
            this._grpDetails.Controls.Add(this._Label1);
            this._grpDetails.Controls.Add(this._txtName);
            this._grpDetails.Controls.Add(this._Label2);
            this._grpDetails.Controls.Add(this._btnSave);
            this._grpDetails.Location = new System.Drawing.Point(8, 384);
            this._grpDetails.Name = "_grpDetails";
            this._grpDetails.Size = new System.Drawing.Size(780, 56);
            this._grpDetails.TabIndex = 8;
            this._grpDetails.TabStop = false;
            this._grpDetails.Text = "Details";
            // 
            // _cboCategory
            // 
            this._cboCategory.Location = new System.Drawing.Point(409, 21);
            this._cboCategory.Name = "_cboCategory";
            this._cboCategory.Size = new System.Drawing.Size(306, 21);
            this._cboCategory.TabIndex = 9;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(357, 24);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(80, 23);
            this._Label1.TabIndex = 8;
            this._Label1.Text = "Map To";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(79, 21);
            this._txtName.MaxLength = 255;
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(265, 21);
            this._txtName.TabIndex = 5;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(8, 24);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(80, 23);
            this._Label2.TabIndex = 5;
            this._Label2.Text = "Map From";
            // 
            // _btnSave
            // 
            this._btnSave.AccessibleDescription = "Save item";
            this._btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSave.ImageIndex = 1;
            this._btnSave.Location = new System.Drawing.Point(721, 19);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(48, 23);
            this._btnSave.TabIndex = 7;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FRMPartCategories
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(796, 454);
            this.Controls.Add(this._GroupBox1);
            this.Controls.Add(this._grpDetails);
            this.MinimumSize = new System.Drawing.Size(496, 488);
            this.Name = "FRMPartCategories";
            this.Text = "Part Categories";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgManager)).EndInit();
            this._grpDetails.ResumeLayout(false);
            this._grpDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
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

        public void ResetMe(int newID)
        {
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

        
    }
}