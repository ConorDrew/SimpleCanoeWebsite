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
    public class FRMTypeMakeModel : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMTypeMakeModel() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal GroupBox grpItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpItems != null)
                {
                }

                _grpItems = value;
                if (_grpItems != null)
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
            _grpItems = new GroupBox();
            _dgManager = new DataGrid();
            _dgManager.Click += new EventHandler(dgManager_Click);
            _dgManager.CurrentCellChanged += new EventHandler(dgManager_Click);
            _dgManager.Click += new EventHandler(dgManager_Click);
            _dgManager.CurrentCellChanged += new EventHandler(dgManager_Click);
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _Label1 = new Label();
            _cboType = new ComboBox();
            _cboType.SelectedIndexChanged += new EventHandler(cboType_SelectedIndexChanged);
            _grpDetails = new GroupBox();
            _cbxShowOnJob = new CheckBox();
            _txtPercentageRate = new TextBox();
            _lblPercentageRate = new Label();
            _Label3 = new Label();
            _txtName = new TextBox();
            _txtDescription = new TextBox();
            _Label2 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgManager).BeginInit();
            _grpDetails.SuspendLayout();
            SuspendLayout();
            // 
            // grpItems
            // 
            _grpItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpItems.Controls.Add(_dgManager);
            _grpItems.Controls.Add(_btnAddNew);
            _grpItems.Location = new Point(8, 72);
            _grpItems.Name = "grpItems";
            _grpItems.Size = new Size(368, 416);
            _grpItems.TabIndex = 5;
            _grpItems.TabStop = false;
            _grpItems.Text = "Items";
            // 
            // dgManager
            // 
            _dgManager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgManager.DataMember = "";
            _dgManager.HeaderForeColor = SystemColors.ControlText;
            _dgManager.Location = new Point(8, 53);
            _dgManager.Name = "dgManager";
            _dgManager.Size = new Size(352, 355);
            _dgManager.TabIndex = 3;
            // 
            // btnAddNew
            // 
            _btnAddNew.AccessibleDescription = "Add new item";
            _btnAddNew.Cursor = Cursors.Hand;
            _btnAddNew.UseVisualStyleBackColor = true;
            _btnAddNew.Location = new Point(8, 24);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.Size = new Size(48, 23);
            _btnAddNew.TabIndex = 2;
            _btnAddNew.Text = "New";
            // 
            // Label1
            // 
            _Label1.Location = new Point(8, 45);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(72, 23);
            _Label1.TabIndex = 4;
            _Label1.Text = "Select Type";
            // 
            // cboType
            // 
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboType.Cursor = Cursors.Hand;
            _cboType.DisplayMember = "Description";
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(88, 45);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(288, 21);
            _cboType.TabIndex = 1;
            _cboType.ValueMember = "Value";
            // 
            // grpDetails
            // 
            _grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _grpDetails.Controls.Add(_cbxShowOnJob);
            _grpDetails.Controls.Add(_txtPercentageRate);
            _grpDetails.Controls.Add(_lblPercentageRate);
            _grpDetails.Controls.Add(_Label3);
            _grpDetails.Controls.Add(_txtName);
            _grpDetails.Controls.Add(_txtDescription);
            _grpDetails.Controls.Add(_Label2);
            _grpDetails.Controls.Add(_btnSave);
            _grpDetails.Location = new Point(384, 40);
            _grpDetails.Name = "grpDetails";
            _grpDetails.Size = new Size(392, 216);
            _grpDetails.TabIndex = 7;
            _grpDetails.TabStop = false;
            _grpDetails.Text = "Details";
            // 
            // cbxShowOnJob
            // 
            _cbxShowOnJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _cbxShowOnJob.AutoSize = true;
            _cbxShowOnJob.Location = new Point(208, 188);
            _cbxShowOnJob.Name = "cbxShowOnJob";
            _cbxShowOnJob.Size = new Size(98, 17);
            _cbxShowOnJob.TabIndex = 10;
            _cbxShowOnJob.Text = "Show on Job";
            _cbxShowOnJob.TextAlign = ContentAlignment.MiddleRight;
            _cbxShowOnJob.UseVisualStyleBackColor = true;
            // 
            // txtPercentageRate
            // 
            _txtPercentageRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtPercentageRate.Location = new Point(104, 184);
            _txtPercentageRate.MaxLength = 255;
            _txtPercentageRate.Name = "txtPercentageRate";
            _txtPercentageRate.Size = new Size(87, 21);
            _txtPercentageRate.TabIndex = 9;
            _txtPercentageRate.Visible = false;
            // 
            // lblPercentageRate
            // 
            _lblPercentageRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblPercentageRate.Location = new Point(6, 184);
            _lblPercentageRate.Name = "lblPercentageRate";
            _lblPercentageRate.Size = new Size(72, 21);
            _lblPercentageRate.TabIndex = 8;
            _lblPercentageRate.Text = "Rate (%)";
            _lblPercentageRate.Visible = false;
            // 
            // Label3
            // 
            _Label3.Location = new Point(8, 56);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(72, 23);
            _Label3.TabIndex = 6;
            _Label3.Text = "Description";
            // 
            // txtName
            // 
            _txtName.Location = new Point(104, 24);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(280, 21);
            _txtName.TabIndex = 5;
            // 
            // txtDescription
            // 
            _txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _txtDescription.Location = new Point(104, 56);
            _txtDescription.Multiline = true;
            _txtDescription.Name = "txtDescription";
            _txtDescription.ScrollBars = ScrollBars.Vertical;
            _txtDescription.Size = new Size(280, 120);
            _txtDescription.TabIndex = 6;
            // 
            // Label2
            // 
            _Label2.Location = new Point(8, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(48, 23);
            _Label2.TabIndex = 5;
            _Label2.Text = "Name";
            // 
            // btnSave
            // 
            _btnSave.AccessibleDescription = "Save item";
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Cursor = Cursors.Hand;
            _btnSave.UseVisualStyleBackColor = true;
            _btnSave.ImageIndex = 1;
            _btnSave.Location = new Point(336, 184);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(48, 23);
            _btnSave.TabIndex = 7;
            _btnSave.Text = "Save";
            // 
            // FRMTypeMakeModel
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(784, 494);
            Controls.Add(_grpDetails);
            Controls.Add(_grpItems);
            Controls.Add(_Label1);
            Controls.Add(_cboType);
            MinimumSize = new Size(792, 528);
            Name = "FRMTypeMakeModel";
            Text = "Picklists / Settings";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_cboType, 0);
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_grpItems, 0);
            Controls.SetChildIndex(_grpDetails, 0);
            _grpItems.ResumeLayout(false);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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



        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
                        case Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.VATCodes):
                        case Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.PartCategories):
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
                case Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.VATCodes):
                case Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.PartCategories):
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

    }
}