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
    public class FRMTypeMakeModel : FRMBaseForm, IForm
    {
        public FRMTypeMakeModel() : base()
        {
            base.Load += FRMManager_Load;

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
        private GroupBox _grpItems;

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
                    _dgManager.CurrentCellChanged -= dgManager_Click;
                }

                _dgManager = value;
                if (_dgManager != null)
                {
                    _dgManager.Click += dgManager_Click;
                    _dgManager.CurrentCellChanged += dgManager_Click;
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

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                    _cboType.SelectedIndexChanged -= cboType_SelectedIndexChanged;
                }

                _cboType = value;
                if (_cboType != null)
                {
                    _cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
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

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
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

        private TextBox _txtDescription;

        internal TextBox txtDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDescription != null)
                {
                }

                _txtDescription = value;
                if (_txtDescription != null)
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

        private TextBox _txtPercentageRate;

        internal TextBox txtPercentageRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPercentageRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPercentageRate != null)
                {
                }

                _txtPercentageRate = value;
                if (_txtPercentageRate != null)
                {
                }
            }
        }

        private Label _lblPercentageRate;

        internal Label lblPercentageRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPercentageRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPercentageRate != null)
                {
                }

                _lblPercentageRate = value;
                if (_lblPercentageRate != null)
                {
                }
            }
        }

        private CheckBox _cbxShowOnJob;

        internal CheckBox cbxShowOnJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxShowOnJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxShowOnJob != null)
                {
                }

                _cbxShowOnJob = value;
                if (_cbxShowOnJob != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpItems = new System.Windows.Forms.GroupBox();
            this._dgManager = new System.Windows.Forms.DataGrid();
            this._btnAddNew = new System.Windows.Forms.Button();
            this._Label1 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._grpDetails = new System.Windows.Forms.GroupBox();
            this._cbxShowOnJob = new System.Windows.Forms.CheckBox();
            this._txtPercentageRate = new System.Windows.Forms.TextBox();
            this._lblPercentageRate = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgManager)).BeginInit();
            this._grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpItems
            // 
            this._grpItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpItems.Controls.Add(this._dgManager);
            this._grpItems.Controls.Add(this._btnAddNew);
            this._grpItems.Location = new System.Drawing.Point(8, 39);
            this._grpItems.Name = "_grpItems";
            this._grpItems.Size = new System.Drawing.Size(368, 449);
            this._grpItems.TabIndex = 5;
            this._grpItems.TabStop = false;
            this._grpItems.Text = "Items";
            // 
            // _dgManager
            // 
            this._dgManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgManager.DataMember = "";
            this._dgManager.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgManager.Location = new System.Drawing.Point(8, 53);
            this._dgManager.Name = "_dgManager";
            this._dgManager.Size = new System.Drawing.Size(352, 388);
            this._dgManager.TabIndex = 3;
            this._dgManager.CurrentCellChanged += new System.EventHandler(this.dgManager_Click);
            this._dgManager.Click += new System.EventHandler(this.dgManager_Click);
            // 
            // _btnAddNew
            // 
            this._btnAddNew.AccessibleDescription = "Add new item";
            this._btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddNew.Location = new System.Drawing.Point(8, 24);
            this._btnAddNew.Name = "_btnAddNew";
            this._btnAddNew.Size = new System.Drawing.Size(48, 23);
            this._btnAddNew.TabIndex = 2;
            this._btnAddNew.Text = "New";
            this._btnAddNew.UseVisualStyleBackColor = true;
            this._btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 12);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(72, 23);
            this._Label1.TabIndex = 4;
            this._Label1.Text = "Select Type";
            // 
            // _cboType
            // 
            this._cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboType.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboType.DisplayMember = "Description";
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(88, 12);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(288, 21);
            this._cboType.TabIndex = 1;
            this._cboType.ValueMember = "Value";
            this._cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // _grpDetails
            // 
            this._grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpDetails.Controls.Add(this._cbxShowOnJob);
            this._grpDetails.Controls.Add(this._txtPercentageRate);
            this._grpDetails.Controls.Add(this._lblPercentageRate);
            this._grpDetails.Controls.Add(this._Label3);
            this._grpDetails.Controls.Add(this._txtName);
            this._grpDetails.Controls.Add(this._txtDescription);
            this._grpDetails.Controls.Add(this._Label2);
            this._grpDetails.Controls.Add(this._btnSave);
            this._grpDetails.Location = new System.Drawing.Point(384, 12);
            this._grpDetails.Name = "_grpDetails";
            this._grpDetails.Size = new System.Drawing.Size(392, 244);
            this._grpDetails.TabIndex = 7;
            this._grpDetails.TabStop = false;
            this._grpDetails.Text = "Details";
            // 
            // _cbxShowOnJob
            // 
            this._cbxShowOnJob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cbxShowOnJob.AutoSize = true;
            this._cbxShowOnJob.Location = new System.Drawing.Point(208, 216);
            this._cbxShowOnJob.Name = "_cbxShowOnJob";
            this._cbxShowOnJob.Size = new System.Drawing.Size(98, 17);
            this._cbxShowOnJob.TabIndex = 10;
            this._cbxShowOnJob.Text = "Show on Job";
            this._cbxShowOnJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._cbxShowOnJob.UseVisualStyleBackColor = true;
            // 
            // _txtPercentageRate
            // 
            this._txtPercentageRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtPercentageRate.Location = new System.Drawing.Point(104, 212);
            this._txtPercentageRate.MaxLength = 255;
            this._txtPercentageRate.Name = "_txtPercentageRate";
            this._txtPercentageRate.Size = new System.Drawing.Size(87, 21);
            this._txtPercentageRate.TabIndex = 9;
            this._txtPercentageRate.Visible = false;
            // 
            // _lblPercentageRate
            // 
            this._lblPercentageRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblPercentageRate.Location = new System.Drawing.Point(6, 212);
            this._lblPercentageRate.Name = "_lblPercentageRate";
            this._lblPercentageRate.Size = new System.Drawing.Size(72, 21);
            this._lblPercentageRate.TabIndex = 8;
            this._lblPercentageRate.Text = "Rate (%)";
            this._lblPercentageRate.Visible = false;
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 56);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(72, 23);
            this._Label3.TabIndex = 6;
            this._Label3.Text = "Description";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(104, 24);
            this._txtName.MaxLength = 255;
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(280, 21);
            this._txtName.TabIndex = 5;
            // 
            // _txtDescription
            // 
            this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescription.Location = new System.Drawing.Point(104, 56);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtDescription.Size = new System.Drawing.Size(280, 148);
            this._txtDescription.TabIndex = 6;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(8, 24);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(48, 23);
            this._Label2.TabIndex = 5;
            this._Label2.Text = "Name";
            // 
            // _btnSave
            // 
            this._btnSave.AccessibleDescription = "Save item";
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSave.ImageIndex = 1;
            this._btnSave.Location = new System.Drawing.Point(336, 212);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(48, 23);
            this._btnSave.TabIndex = 7;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FRMTypeMakeModel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(784, 494);
            this.Controls.Add(this._grpDetails);
            this.Controls.Add(this._grpItems);
            this.Controls.Add(this._Label1);
            this.Controls.Add(this._cboType);
            this.MinimumSize = new System.Drawing.Size(792, 528);
            this.Name = "FRMTypeMakeModel";
            this.Text = "Picklists / Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgManager)).EndInit();
            this._grpDetails.ResumeLayout(false);
            this._grpDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupManagerDataGrid();
            Settings = App.DB.Manager.Get();
            var argc = cboType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.PickListTypesLimited().Table, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            PopulateDatagrid(Entity.Sys.Enums.FormState.Load);
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
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
                _dvManager.Table.TableName = Entity.Sys.Enums.TableNames.tblPickLists.ToString();
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

        private Entity.Management.Settings _settings = null;

        public Entity.Management.Settings Settings
        {
            get
            {
                return _settings;
            }

            set
            {
                _settings = value;
            }
        }

        private void SetupManagerDataGrid()
        {
            var tbStyle = dgManager.TableStyles[0];
            var name = new DataGridLabelColumn();
            name.Format = "";
            name.FormatInfo = null;
            name.HeaderText = "Name";
            name.MappingName = "Name";
            name.ReadOnly = true;
            name.Width = 177;
            name.NullText = "";
            tbStyle.GridColumnStyles.Add(name);
            var description = new DataGridLabelColumn();
            description.Format = "";
            description.FormatInfo = null;
            description.HeaderText = "Description";
            description.MappingName = "Description";
            description.ReadOnly = true;
            description.Width = 177;
            description.NullText = "";
            tbStyle.GridColumnStyles.Add(description);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPickLists.ToString();
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
                        btnSave.Enabled = false;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Insert:
                    {
                        grpDetails.Enabled = true;
                        btnAddNew.Enabled = true;
                        btnSave.Enabled = true;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Update:
                    {
                        btnAddNew.Enabled = true;
                        grpDetails.Enabled = true;
                        btnSave.Enabled = true;
                        break;
                    }
            }

            PageState = state;
        }

        private void FRMManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                PopulateDatagrid(Entity.Sys.Enums.FormState.Load);
            }
            else
            {
                PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
            }

            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.Engineer_Levels))
            {
                cbxShowOnJob.Visible = true;
            }
            else
            {
                cbxShowOnJob.Visible = false;
            }
        }

        private void dgManager_Click(object sender, EventArgs e)
        {
            try
            {
                SetUpPageState(Entity.Sys.Enums.FormState.Update);
                if (SelectedManagerDataRow is object)
                {
                    if ((Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow["Name"]) ?? "") == "RC - Recall")
                    {
                        App.ShowMessage("This item cannont be edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetUpPageState(Entity.Sys.Enums.FormState.Insert);
                        return;
                    }

                    txtName.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow["Name"]);
                    txtDescription.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow["Description"]);
                    if (Conversions.ToDouble(Entity.Sys.Helper.MakeDoubleValid(SelectedManagerDataRow["PercentageRate"])) == 0.0)
                    {
                        cbxShowOnJob.Checked = Conversions.ToBoolean(0);
                    }
                    else
                    {
                        cbxShowOnJob.Checked = Conversions.ToBoolean(1);
                    }
                }
                else if (cboType.SelectedIndex == 0)
                {
                    SetUpPageState(Entity.Sys.Enums.FormState.Load);
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
            try
            {
                lblPercentageRate.Visible = false;
                txtPercentageRate.Visible = false;
                if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == 0)
                {
                    var dt = new DataTable();
                    dt.TableName = Entity.Sys.Enums.TableNames.tblPickLists.ToString();
                    ManagerDataview = new DataView(dt);
                }
                else
                {
                    ManagerDataview = App.DB.Picklists.GetAll((Entity.Sys.Enums.PickListTypes)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)));
                    var switchExpr = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType));
                    switch (switchExpr)
                    {
                        case (int)(Entity.Sys.Enums.PickListTypes.VATCodes):
                        case (int)(Entity.Sys.Enums.PickListTypes.PartCategories):
                            {
                                lblPercentageRate.Visible = true;
                                txtPercentageRate.Visible = true;
                                break;
                            }
                    }
                }

                SetUpPageState(state);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Private Sub SaveSettings()
        // Try
        // Settings.IgnoreExceptionsOnSetMethods = True
        // Settings.SetWorkingHoursStart = Combo.GetSelectedItemValue(Me.cboWorkingHoursStart)
        // Settings.SetWorkingHoursEnd = Combo.GetSelectedItemValue(Me.cboWorkingHoursEnd)
        // Settings.SetMileageRate = Me.txtMileageRate.Text.Trim
        // Settings.SetPartsMarkup = Me.txtPartsMarkup.Text.Trim
        // Settings.SetRatesMarkup = Me.txtRatesMarkup.Text.Trim
        // Settings.SetCalloutPrefix = Me.txtCalloutPrefix.Text.Trim
        // Settings.SetMiscPrefix = Me.txtMiscPrefix.Text.Trim
        // Settings.SetPPMPrefix = Me.txtPPMPrefix.Text.Trim
        // Settings.SetQuotePrefix = Me.txtQuotePrefix.Text.Trim
        // Settings.SetTimeSlot = cboTimeSlot.SelectedItem
        // Settings.SetInvoicePrefix = Me.txtInvoicePrefix.Text.Trim
        // Settings.SetRecallVariable = Me.txtRecallVariable.Text.Trim
        // Settings.SetPartsImportMarkup = Me.txtPartsImportMarkup.text.trim
        // Settings.SetServiceFromLetterPrefix = Me.txtServiceFromLetterPrefix.Text.Trim

        // Dim sV As New Entity.Management.SettingsValidator
        // sV.Validate(Settings)

        // DB.Manager.UpdateSettings(Settings)

        // 'UPDATE ALL CUSTOMERS WHO ACCEPT CHANGES
        // DB.CustomerCharge.UpdateALL(Settings.MileageRate, Settings.PartsMarkup, Settings.RatesMarkup)
        // 'UPDATE ALL SITES WHO ACCEPT CHANGES
        // DB.SiteCharge.UpdateALL(Settings.MileageRate, Settings.PartsMarkup, Settings.RatesMarkup)

        // ShowMessage("Settings updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        // Catch vex As ValidationException
        // Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
        // msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
        // ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        // Catch ex As Exception
        // ShowMessage("Error Saving : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        // End Try
        // End Sub

        private void Save()
        {
            var picklist = new Entity.PickLists.PickList();
            picklist.IgnoreExceptionsOnSetMethods = true;
            picklist.SetName = txtName.Text.Trim();
            picklist.SetDescription = txtDescription.Text.Trim();
            picklist.SetEnumTypeID = Combo.get_GetSelectedItemValue(cboType);
            var switchExpr = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType));
            switch (switchExpr)
            {
                case (int)(Entity.Sys.Enums.PickListTypes.VATCodes):
                case (int)(Entity.Sys.Enums.PickListTypes.PartCategories):
                    {
                        picklist.SetPercentageRate = txtPercentageRate.Text.Trim();
                        break;
                    }

                default:
                    {
                        picklist.SetPercentageRate = 0.0;
                        if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.Engineer_Levels))
                        {
                            picklist.SetPercentageRate = Conversions.ToDouble(cbxShowOnJob.Checked);
                        }

                        break;
                    }
            }

            if (PageState == Entity.Sys.Enums.FormState.Update)
            {
                picklist.SetManagerID = SelectedManagerDataRow["ManagerID"];
            }

            var validator = new Entity.PickLists.PickListValidator();
            try
            {
                validator.Validate(picklist);
                var switchExpr1 = PageState;
                switch (switchExpr1)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            App.DB.Picklists.Insert(picklist);
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            App.DB.Picklists.Update(picklist);
                            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.PartCategories))
                                App.DB.Picklists.UpdateSellPrices(picklist);
                            break;
                        }
                }

                PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
            }
            catch (ValidationException ex)
            {
                App.ShowMessage(validator.CriticalMessagesString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    if ((int)App.ShowMessage(Conversions.ToString("Are you sure you want to delete \"" + SelectedManagerDataRow["Name"] + "\" from \"" + Combo.get_GetSelectedItemDescription(cboType) + "\"?"), MessageBoxButtons.YesNo, (MessageBoxIcon)MsgBoxStyle.Question) == (int)MsgBoxResult.Yes)
                    {
                        if ((Entity.Sys.Enums.PickListTypes)Conversions.ToInteger(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType))) == Entity.Sys.Enums.PickListTypes.Regions)
                        {
                            var dv = App.DB.Picklists.Region_Usage(Conversions.ToInteger(SelectedManagerDataRow["ManagerID"]));
                            if (dv.Table.Rows.Count > 0)
                            {
                                string str = "The region you are trying to delete is still allocated to the following records:" + Constants.vbCrLf;
                                foreach (DataRow dr in dv.Table.Rows)
                                    str += Conversions.ToString("* " + dr["type"] + " - ") + dr["Name"] + Constants.vbCrLf;
                                MessageBox.Show(str, "Region Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        App.DB.Picklists.Delete(Conversions.ToInteger(SelectedManagerDataRow["ManagerID"]));
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