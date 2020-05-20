﻿using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMEngineerHistory : FRMBaseForm, IForm
    {
        

        public FRMEngineerHistory() : base()
        {
            
            
            base.Load += FRMEngineerHistory_Load;

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
        private GroupBox _grpHistory;

        internal GroupBox grpHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpHistory != null)
                {
                }

                _grpHistory = value;
                if (_grpHistory != null)
                {
                }
            }
        }

        private DataGrid _dgHistory;

        internal DataGrid dgHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgHistory != null)
                {
                    _dgHistory.DoubleClick -= dgHistory_DoubleClick;
                }

                _dgHistory = value;
                if (_dgHistory != null)
                {
                    _dgHistory.DoubleClick += dgHistory_DoubleClick;
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
            this._grpHistory = new System.Windows.Forms.GroupBox();
            this._btnAdd = new System.Windows.Forms.Button();
            this._dgHistory = new System.Windows.Forms.DataGrid();
            this._grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpHistory
            // 
            this._grpHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpHistory.Controls.Add(this._btnAdd);
            this._grpHistory.Controls.Add(this._dgHistory);
            this._grpHistory.Location = new System.Drawing.Point(8, 12);
            this._grpHistory.Name = "_grpHistory";
            this._grpHistory.Size = new System.Drawing.Size(856, 468);
            this._grpHistory.TabIndex = 1;
            this._grpHistory.TabStop = false;
            this._grpHistory.Text = "Double Click To View / Edit";
            // 
            // _btnAdd
            // 
            this._btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAdd.Location = new System.Drawing.Point(8, 436);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(64, 23);
            this._btnAdd.TabIndex = 2;
            this._btnAdd.Text = "Add";
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // _dgHistory
            // 
            this._dgHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgHistory.DataMember = "";
            this._dgHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgHistory.Location = new System.Drawing.Point(8, 26);
            this._dgHistory.Name = "_dgHistory";
            this._dgHistory.Size = new System.Drawing.Size(840, 402);
            this._dgHistory.TabIndex = 1;
            this._dgHistory.DoubleClick += new System.EventHandler(this.dgHistory_DoubleClick);
            // 
            // FRMEngineerHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(872, 486);
            this.Controls.Add(this._grpHistory);
            this.MinimumSize = new System.Drawing.Size(880, 520);
            this.Name = "FRMEngineerHistory";
            this.Text = "Engineer History For Profile : {0}";
            this._grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgHistory)).EndInit();
            this.ResumeLayout(false);

        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            ID = Entity.Sys.Helper.MakeIntegerValid(get_GetParameter(0));
            LoadForm(sender, e, this);
            SetupDataGrid();
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
                Van = App.DB.Van.Van_Get(ID);
            }
        }

        private Entity.Vans.Van _Van = null;

        public Entity.Vans.Van Van
        {
            get
            {
                return _Van;
            }

            set
            {
                _Van = value;
                Text = "Engineer History For Profile : " + Van.Registration;
                VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(Van.VanID);
            }
        }

        private DataView _VanHistory;

        public DataView VanHistory
        {
            get
            {
                return _VanHistory;
            }

            set
            {
                _VanHistory = value;
                _VanHistory.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVan.ToString();
                _VanHistory.AllowNew = false;
                _VanHistory.AllowEdit = false;
                _VanHistory.AllowDelete = false;
                dgHistory.DataSource = VanHistory;
            }
        }

        private DataRow SelectedHistoryDataRow
        {
            get
            {
                if (!(dgHistory.CurrentRowIndex == -1))
                {
                    return VanHistory[dgHistory.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        
        

        public void SetupDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgHistory);
            var tStyle = dgHistory.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Engineer";
            Engineer.ReadOnly = true;
            Engineer.Width = 330;
            Engineer.NullText = "";
            tStyle.GridColumnStyles.Add(Engineer);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dddd dd MMMM yyyy HH:mm";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "From";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 250;
            StartDateTime.NullText = "";
            tStyle.GridColumnStyles.Add(StartDateTime);
            var EndDateTime = new DataGridLabelColumn();
            EndDateTime.Format = "dddd dd MMMM yyyy HH:mm";
            EndDateTime.FormatInfo = null;
            EndDateTime.HeaderText = "To";
            EndDateTime.MappingName = "EndDateTime";
            EndDateTime.ReadOnly = true;
            EndDateTime.Width = 250;
            EndDateTime.NullText = "Until Further Notice";
            tStyle.GridColumnStyles.Add(EndDateTime);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVan.ToString();
            dgHistory.TableStyles.Add(tStyle);
        }

        private void FRMEngineerHistory_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMEngineerVan), true, new object[] { 0, Van.VanID, this });
            VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(Van.VanID);
        }

        private void dgHistory_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedHistoryDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMEngineerVan), true, new object[] { SelectedHistoryDataRow["EngineerVanID"], Van.VanID, this });
            VanHistory = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(Van.VanID);
        }

        // Private Sub frmProgramma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        // If MessageBox.Show("Are you sur to close this application?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        // Else
        // e.Cancel = True
        // End If
        // End Sub

        
    }
}