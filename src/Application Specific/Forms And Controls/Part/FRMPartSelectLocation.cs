using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMPartSelectLocation : FRMBaseForm, IForm
    {
        public FRMPartSelectLocation() : base()
        {
            base.Load += FRMSelectLocation_Load;

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
        private Button _btnOK;

        internal Button btnOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOK != null)
                {
                    // Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
                    // If Not Locations.Table.Select("Tick=1").Length = 1 Then
                    // ShowMessage("Please ensure only one location has been selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    // Exit Sub
                    // End If

                    // With CType(Locations.Table.Select("Tick=1")(0), DataRow)
                    // If .Item("Type") = "Warehouse" Then
                    // _LocationID = .Item("ID")
                    // _PartSupplierID = 0
                    // _SupplierID = 0
                    // Else
                    // _LocationID = 0
                    // _PartSupplierID = .Item("ID")
                    // _SupplierID = .Item("OtherID")
                    // End If

                    // _InPack = .Item("InPack")
                    // _Price = .Item("Price")
                    // End With

                    // Me.DialogResult =DialogResult.OK
                    // End Sub

                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        private GroupBox _grpLocations;

        internal GroupBox grpLocations
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpLocations;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpLocations != null)
                {
                }

                _grpLocations = value;
                if (_grpLocations != null)
                {
                }
            }
        }

        private DataGridView _dgvLocations;

        internal DataGridView dgvLocations
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvLocations;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvLocations != null)
                {
                    _dgvLocations.SelectionChanged -= dgvLocations_SelectionChanged;
                }

                _dgvLocations = value;
                if (_dgvLocations != null)
                {
                    _dgvLocations.SelectionChanged += dgvLocations_SelectionChanged;
                }
            }
        }

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    // Private Sub dgLocations_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
                    // Try
                    // Try
                    // Dim HitTestInfo As DataGrid.HitTestInfo = Me.dgLocations.HitTest(e.X, e.Y)
                    // If Locations.Table.Rows(HitTestInfo.Row) Is Nothing Then
                    // Exit Sub
                    // End If
                    // If Not Locations.Table.Columns(HitTestInfo.Column).ColumnName.Trim.ToLower = "Tick".ToLower Then
                    // Exit Sub
                    // End If
                    // Catch
                    // Exit Sub
                    // End Try

                    // If SelectedDataRow Is Nothing Then
                    // Exit Sub
                    // End If

                    // Dim selected As Boolean = Not CBool(Me.dgLocations(Me.dgLocations.CurrentRowIndex, 0))
                    // Me.dgLocations(Me.dgLocations.CurrentRowIndex, 0) = selected
                    // Catch ex As Exception
                    // ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    // End Try
                    // End Sub

                    _btnCancel.Click -= btnClose_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnClose_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._grpLocations = new System.Windows.Forms.GroupBox();
            this._dgvLocations = new System.Windows.Forms.DataGridView();
            this._grpLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvLocations)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(856, 444);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(60, 25);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(12, 444);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(56, 25);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _grpLocations
            // 
            this._grpLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpLocations.Controls.Add(this._dgvLocations);
            this._grpLocations.Location = new System.Drawing.Point(12, 12);
            this._grpLocations.Name = "_grpLocations";
            this._grpLocations.Size = new System.Drawing.Size(904, 426);
            this._grpLocations.TabIndex = 3;
            this._grpLocations.TabStop = false;
            this._grpLocations.Text = "Select location to add to : {0}";
            // 
            // _dgvLocations
            // 
            this._dgvLocations.AllowUserToAddRows = false;
            this._dgvLocations.AllowUserToDeleteRows = false;
            this._dgvLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvLocations.Location = new System.Drawing.Point(7, 21);
            this._dgvLocations.Name = "_dgvLocations";
            this._dgvLocations.ReadOnly = true;
            this._dgvLocations.Size = new System.Drawing.Size(891, 399);
            this._dgvLocations.TabIndex = 0;
            this._dgvLocations.SelectionChanged += new System.EventHandler(this.dgvLocations_SelectionChanged);
            // 
            // FRMPartSelectLocation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(928, 481);
            this.ControlBox = false;
            this.Controls.Add(this._grpLocations);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.MinimumSize = new System.Drawing.Size(825, 420);
            this.Name = "FRMPartSelectLocation";
            this.Text = "Add Van Stock Part to ...";
            this._grpLocations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvLocations)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupLocationsDataGridView();

            // If GetParameter(8) = "DailyStockReplen" Then
            // dt = DB.Part.Part_Locations_Get_For_Replenishment_Suppliers_Only(GetParameter(0))
            // Else
            // dt = DB.Part.Part_Locations_Get_For_Replenishment(GetParameter(0))
            // End If

            // For Each warehouse As ArrayList In CType(GetParameter(4), ArrayList)
            // For Each row As DataRow In CType(warehouse.Item(1), DataTable).Rows
            // If row.Item("PartID") = GetParameter(0) Then
            // If Not row.Item("LocationID") = 0 Then
            // For Each location As DataRow In dt.Table.Rows
            // If GetParameter(8) = "" Then
            // If location.Item("Type") = "Warehouse" Then
            // If location.Item("ID") = row.Item("LocationID") Then
            // location.Item("InStock") = (Entity.Sys.Helper.MakeIntegerValid(location.Item("InStock")) - Entity.Sys.Helper.MakeIntegerValid(row.Item("Quantity")))
            // End If
            // End If
            // Else
            // If location.Item("Type") = "Warehouse" Then
            // location.Delete()
            // End If
            // End If
            // Next
            // End If
            // End If
            // Next
            // Next

            // For Each van As ArrayList In CType(GetParameter(5), ArrayList)
            // For Each row As DataRow In CType(van.Item(1), DataTable).Rows
            // If row.Item("PartID") = GetParameter(0) Then
            // If Not row.Item("LocationID") = 0 Then
            // For Each location As DataRow In dt.Table.Rows
            // If GetParameter(8) = "" Then
            // If location.Item("Type") = "Warehouse" Then
            // If location.Item("ID") = row.Item("LocationID") Then
            // location.Item("InStock") = (Entity.Sys.Helper.MakeIntegerValid(location.Item("InStock")) - Entity.Sys.Helper.MakeIntegerValid(row.Item("Quantity")))
            // End If
            // End If
            // Else
            // If location.Item("Type") = "Warehouse" Then
            // location.Delete()
            // End If
            // End If
            // Next
            // End If
            // End If
            // Next
            // Next

            // If Not Entity.Sys.Helper.MakeIntegerValid(GetParameter(7)) = 0 Then
            // For Each row As DataRow In dt.Table.Rows
            // 'If row.Item("Type") = Entity.Sys.Helper.MakeStringValid(GetParameter(6)) And row.Item("ID") = Entity.Sys.Helper.MakeIntegerValid(GetParameter(7)) Then
            // row.Item("Tick") = True
            // 'Exit For
            // 'End If
            // Next
            // End If

            // Locations = dt

            grpLocations.Text = Conversions.ToString(Conversions.ToString(Conversions.ToString("Please select where you would like to get " + get_GetParameter(3) + " of item '") + get_GetParameter(1) + "' for location '") + get_GetParameter(2) + "' from");
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
            // DO NOTHING
        }

        public void SetupLocationsDataGridView()
        {
            Entity.Sys.Helper.SetUpDataGridView(dgvLocations);
            dgvLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocations.AutoGenerateColumns = false;
            dgvLocations.Columns.Clear();
            dgvLocations.EditMode = DataGridViewEditMode.EditOnEnter;
            var LocationID = new DataGridViewTextBoxColumn();
            LocationID.HeaderText = "LocationID";
            LocationID.FillWeight = 25;
            LocationID.DataPropertyName = "LocationID";
            LocationID.ReadOnly = true;
            LocationID.Visible = true;
            LocationID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvLocations.Columns.Add(LocationID);
            var Registration = new DataGridViewTextBoxColumn();
            Registration.FillWeight = 60;
            Registration.HeaderText = "Registration";
            Registration.DataPropertyName = "Registration";
            Registration.ReadOnly = true;
            Registration.Visible = true;
            Registration.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvLocations.Columns.Add(Registration);

            // Dim PartNumber As New DataGridViewTextBoxColumn
            // PartNumber.HeaderText = "Part Number"
            // PartNumber.DataPropertyName = "PartNumber"
            // PartNumber.FillWeight = 15
            // PartNumber.ReadOnly = True
            // PartNumber.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvLocations.Columns.Add(PartNumber)

            // Dim Amount As New DataGridViewTextBoxColumn
            // Amount.HeaderText = "Amount"
            // Amount.DataPropertyName = "Amount"
            // Amount.FillWeight = 15
            // Amount.ReadOnly = True
            // Amount.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvLocations.Columns.Add(Amount)

            // Dim MinQty As New DataGridViewTextBoxColumn
            // MinQty.HeaderText = "Min"
            // MinQty.DataPropertyName = "Min"
            // MinQty.FillWeight = 15
            // MinQty.ReadOnly = False
            // MinQty.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvLocations.Columns.Add(MinQty)

            // Dim MaxQty As New DataGridViewTextBoxColumn
            // MaxQty.HeaderText = "Max"
            // MaxQty.DataPropertyName = "Max"
            // MaxQty.FillWeight = 15
            // MaxQty.ReadOnly = False
            // MaxQty.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvLocations.Columns.Add(MaxQty)

            // Dim MinMaxID As New DataGridViewTextBoxColumn
            // MinMaxID.HeaderText = "MinMaxID"
            // MinMaxID.DataPropertyName = "MinMaxID"
            // MinMaxID.FillWeight = 15
            // MinMaxID.ReadOnly = True
            // MinMaxID.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvLocations.Columns.Add(MinMaxID)
        }

        // Private Sub SetupDG()
        // Entity.Sys.Helper.SetUpDataGrid(Me.dgLocations)
        // Dim tbStyle As DataGridTableStyle = Me.dgLocations.TableStyles(0)

        // tbStyle.GridColumnStyles.Clear()

        // tbStyle.ReadOnly = False
        // Me.dgLocations.ReadOnly = False
        // tbStyle.AllowSorting = False

        // Dim Tick As New DataGridBoolColumn
        // Tick.HeaderText = ""
        // Tick.MappingName = "Tick"
        // Tick.ReadOnly = False
        // Tick.Width = 25
        // Tick.NullText = ""
        // tbStyle.GridColumnStyles.Add(Tick)

        // Dim Type As New DataGridLabelColumn
        // Type.Format = ""
        // Type.FormatInfo = Nothing
        // Type.HeaderText = "Type"
        // Type.MappingName = "Type"
        // Type.ReadOnly = True
        // Type.Width = 150
        // Type.NullText = ""
        // tbStyle.GridColumnStyles.Add(Type)

        // Dim Name As New DataGridLabelColumn
        // Name.Format = ""
        // Name.FormatInfo = Nothing
        // Name.HeaderText = "Name"
        // Name.MappingName = "Name"
        // Name.ReadOnly = True
        // Name.Width = 200
        // Name.NullText = ""
        // tbStyle.GridColumnStyles.Add(Name)

        // Dim InStock As New DataGridLabelColumn
        // InStock.Format = ""
        // InStock.FormatInfo = Nothing
        // InStock.HeaderText = "Stock"
        // InStock.MappingName = "InStock"
        // InStock.ReadOnly = True
        // InStock.Width = 75
        // InStock.NullText = ""
        // tbStyle.GridColumnStyles.Add(InStock)

        // Dim InPack As New DataGridLabelColumn
        // InPack.Format = ""
        // InPack.FormatInfo = Nothing
        // InPack.HeaderText = "In Pack"
        // InPack.MappingName = "InPack"
        // InPack.ReadOnly = True
        // InPack.Width = 75
        // InPack.NullText = ""
        // tbStyle.GridColumnStyles.Add(InPack)

        // Dim Price As New DataGridLabelColumn
        // Price.Format = "C"
        // Price.FormatInfo = Nothing
        // Price.HeaderText = "Price"
        // Price.MappingName = "Price"
        // Price.ReadOnly = True
        // Price.Width = 100
        // Price.NullText = ""
        // tbStyle.GridColumnStyles.Add(Price)

        // tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblLocations.ToString
        // Me.dgLocations.TableStyles.Add(tbStyle)
        // End Sub

        // Private _Locations As DataView = Nothing
        // Public Property Locations() As DataView
        // Get
        // Return _Locations
        // End Get
        // Set(ByVal Value As DataView)
        // _Locations = Value
        // _Locations.Table.TableName = Entity.Sys.Enums.TableNames.tblLocations.ToString
        // _Locations.AllowNew = False
        // _Locations.AllowEdit = True
        // _Locations.AllowDelete = False
        // Me.dgLocations.DataSource = Locations
        // End Set
        // End Property

        // Private ReadOnly Property SelectedDataRow() As DataRow
        // Get
        // If Not Me.dgLocations.CurrentRowIndex = -1 Then
        // Return Locations(Me.dgLocations.CurrentRowIndex).Row
        // Else
        // Return Nothing
        // End If
        // End Get
        // End Property

        private DataTable m_dTable5 = null;

        public DataTable LocationsDataGridView
        {
            get
            {
                return m_dTable5;
            }

            set
            {
                m_dTable5 = value;
                // m_dTable5.Table.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                // m_dTable5.AllowNew = False
                // m_dTable5.AllowEdit = True
                // m_dTable5.AllowDelete = False
                dgvLocations.DataSource = value;
            }
        }

        private DataGridViewRow SelecteddgvLocationsDataRow
        {
            get
            {
                if (!(dgvLocations.CurrentRow.Index == -1))
                {
                    return dgvLocations.CurrentRow;
                }
                else
                {
                    return null;
                }

                // If Not Me.dgvParts.CurrentRowIndex = -1 Then
                // Return PartsDataGridView(Me.dgvParts.CurrentRowIndex).Row
                // Else
                // Return Nothing
                // End If
            }
        }

        private int _LocationID = 0;

        public int LocationID
        {
            get
            {
                return _LocationID;
            }

            set
            {
                _LocationID = value;
            }
        }

        private int _PartSupplierID = 0;

        public int PartSupplierID
        {
            get
            {
                return _PartSupplierID;
            }
        }

        private int _SupplierID = 0;

        public int SupplierID
        {
            get
            {
                return _SupplierID;
            }
        }

        private int _InPack = 0;

        private double _Price = 0.0;

        public double Price
        {
            get
            {
                return _Price;
            }
        }

        private bool _Loading = true;

        public bool Loading
        {
            get
            {
                return _Loading;
            }

            set
            {
                _Loading = value;
            }
        }

        private void FRMSelectLocation_Load(object sender, EventArgs e)
        {
            Loading = true;
            LoadMe(sender, e);
            Loading = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void dgvLocations_SelectionChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                if (SelecteddgvLocationsDataRow is null)
                {
                    return;
                }

                LocationID = Conversions.ToInteger(SelecteddgvLocationsDataRow.Cells[0].Value);
            }
        }
    }
}