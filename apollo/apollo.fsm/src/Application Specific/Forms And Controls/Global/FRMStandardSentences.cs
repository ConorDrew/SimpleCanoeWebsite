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
    public class FRMStandardSentences : FRMBaseForm, IForm
    {
        

        public FRMStandardSentences() : base()
        {
            
            
            base.Load += FRMPartCategories_Load;

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
        private GroupBox _gpbStandardSentences;

        internal GroupBox gpbStandardSentences
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbStandardSentences;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbStandardSentences != null)
                {
                }

                _gpbStandardSentences = value;
                if (_gpbStandardSentences != null)
                {
                }
            }
        }

        private GroupBox _gpbEditAdd;

        internal GroupBox gpbEditAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbEditAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbEditAdd != null)
                {
                }

                _gpbEditAdd = value;
                if (_gpbEditAdd != null)
                {
                }
            }
        }

        private DataGrid _dgStandardSentences;

        internal DataGrid dgStandardSentences
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgStandardSentences;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgStandardSentences != null)
                {
                    _dgStandardSentences.Click -= dgStandardSentences_Click;
                }

                _dgStandardSentences = value;
                if (_dgStandardSentences != null)
                {
                    _dgStandardSentences.Click += dgStandardSentences_Click;
                }
            }
        }

        private TextBox _txtSentence;

        internal TextBox txtSentence
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSentence;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSentence != null)
                {
                }

                _txtSentence = value;
                if (_txtSentence != null)
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
            this._gpbStandardSentences = new System.Windows.Forms.GroupBox();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnAddNew = new System.Windows.Forms.Button();
            this._dgStandardSentences = new System.Windows.Forms.DataGrid();
            this._gpbEditAdd = new System.Windows.Forms.GroupBox();
            this._txtSentence = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._gpbStandardSentences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgStandardSentences)).BeginInit();
            this._gpbEditAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gpbStandardSentences
            // 
            this._gpbStandardSentences.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._gpbStandardSentences.Controls.Add(this._btnDelete);
            this._gpbStandardSentences.Controls.Add(this._btnAddNew);
            this._gpbStandardSentences.Controls.Add(this._dgStandardSentences);
            this._gpbStandardSentences.Location = new System.Drawing.Point(8, 12);
            this._gpbStandardSentences.Name = "_gpbStandardSentences";
            this._gpbStandardSentences.Size = new System.Drawing.Size(608, 476);
            this._gpbStandardSentences.TabIndex = 2;
            this._gpbStandardSentences.TabStop = false;
            this._gpbStandardSentences.Text = "Standard Sentences";
            // 
            // _btnDelete
            // 
            this._btnDelete.Location = new System.Drawing.Point(520, 16);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(75, 23);
            this._btnDelete.TabIndex = 2;
            this._btnDelete.Text = "Delete";
            this._btnDelete.Visible = false;
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // _btnAddNew
            // 
            this._btnAddNew.Location = new System.Drawing.Point(8, 16);
            this._btnAddNew.Name = "_btnAddNew";
            this._btnAddNew.Size = new System.Drawing.Size(75, 23);
            this._btnAddNew.TabIndex = 1;
            this._btnAddNew.Text = "Add New";
            this._btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // _dgStandardSentences
            // 
            this._dgStandardSentences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgStandardSentences.DataMember = "";
            this._dgStandardSentences.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgStandardSentences.Location = new System.Drawing.Point(8, 42);
            this._dgStandardSentences.Name = "_dgStandardSentences";
            this._dgStandardSentences.Size = new System.Drawing.Size(592, 426);
            this._dgStandardSentences.TabIndex = 0;
            this._dgStandardSentences.Click += new System.EventHandler(this.dgStandardSentences_Click);
            // 
            // _gpbEditAdd
            // 
            this._gpbEditAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gpbEditAdd.Controls.Add(this._txtSentence);
            this._gpbEditAdd.Controls.Add(this._Label1);
            this._gpbEditAdd.Controls.Add(this._btnSave);
            this._gpbEditAdd.Location = new System.Drawing.Point(624, 12);
            this._gpbEditAdd.Name = "_gpbEditAdd";
            this._gpbEditAdd.Size = new System.Drawing.Size(224, 476);
            this._gpbEditAdd.TabIndex = 3;
            this._gpbEditAdd.TabStop = false;
            this._gpbEditAdd.Text = "Add/Edit";
            // 
            // _txtSentence
            // 
            this._txtSentence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSentence.Location = new System.Drawing.Point(8, 42);
            this._txtSentence.Multiline = true;
            this._txtSentence.Name = "_txtSentence";
            this._txtSentence.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtSentence.Size = new System.Drawing.Size(208, 256);
            this._txtSentence.TabIndex = 0;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 24);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(100, 23);
            this._Label1.TabIndex = 1;
            this._Label1.Text = "Sentence";
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(136, 306);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 3;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FRMStandardSentences
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(856, 494);
            this.Controls.Add(this._gpbEditAdd);
            this.Controls.Add(this._gpbStandardSentences);
            this.Name = "FRMStandardSentences";
            this.Text = "Standard Sentences";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._gpbStandardSentences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgStandardSentences)).EndInit();
            this._gpbEditAdd.ResumeLayout(false);
            this._gpbEditAdd.PerformLayout();
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

        private DataView _dvStandardSentences;

        private DataView DvStandardSentences
        {
            get
            {
                return _dvStandardSentences;
            }

            set
            {
                _dvStandardSentences = value;
                _dvStandardSentences.AllowNew = false;
                _dvStandardSentences.AllowEdit = false;
                _dvStandardSentences.AllowDelete = false;
                _dvStandardSentences.Table.TableName = Entity.Sys.Enums.TableNames.tblStandardSentences.ToString();
                dgStandardSentences.DataSource = DvStandardSentences;
            }
        }

        private DataRow SelectedStandardSentencesDataRow
        {
            get
            {
                if (!(dgStandardSentences.CurrentRowIndex == -1))
                {
                    return DvStandardSentences[dgStandardSentences.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        
        

        private void SetupManagerDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgStandardSentences);
            var tbStyle = dgStandardSentences.TableStyles[0];
            var Sentence = new DataGridLabelColumn();
            Sentence.Format = "";
            Sentence.FormatInfo = null;
            Sentence.HeaderText = "Sentence";
            Sentence.MappingName = "Sentence";
            Sentence.ReadOnly = true;
            Sentence.Width = 550;
            Sentence.NullText = "";
            tbStyle.GridColumnStyles.Add(Sentence);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblStandardSentences.ToString();
            dgStandardSentences.TableStyles.Add(tbStyle);
        }

        private void SetUpPageState(Entity.Sys.Enums.FormState state)
        {
            Entity.Sys.Helper.ClearGroupBox(gpbEditAdd);
            switch (state)
            {
                case Entity.Sys.Enums.FormState.Load:
                    {
                        gpbEditAdd.Enabled = false;
                        btnAddNew.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Insert:
                    {
                        gpbEditAdd.Enabled = true;
                        btnAddNew.Enabled = true;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Update:
                    {
                        btnAddNew.Enabled = true;
                        gpbEditAdd.Enabled = true;
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

        private void dgStandardSentences_Click(object sender, EventArgs e)
        {
            try
            {
                SetUpPageState(Entity.Sys.Enums.FormState.Update);
                if (SelectedStandardSentencesDataRow is object)
                {
                    txtSentence.Text = Entity.Sys.Helper.MakeStringValid(SelectedStandardSentencesDataRow["Sentence"]);
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
            DvStandardSentences = App.DB.StandardSentence.GetAll();
            SetUpPageState(state);
        }

        private void Save()
        {
            var oStandardSentence = new Entity.StandardSentences.StandardSentence();
            oStandardSentence.IgnoreExceptionsOnSetMethods = true;
            oStandardSentence.SetSentence = txtSentence.Text.Trim();
            var validator = new Entity.StandardSentences.StandardSentenceValidator();
            try
            {
                validator.Validate(oStandardSentence);
                var switchExpr = PageState;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            App.DB.StandardSentence.Insert(oStandardSentence);
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            oStandardSentence.SetSentenceID = SelectedStandardSentencesDataRow["SentenceID"];
                            App.DB.StandardSentence.Update(oStandardSentence);
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
                if (SelectedStandardSentencesDataRow is object)
                {
                    if ((int)App.ShowMessage(Conversions.ToString("Are you sure you want to delete \"" + SelectedStandardSentencesDataRow["Sentence"] + "\"?"), MessageBoxButtons.YesNo, (MessageBoxIcon)MsgBoxStyle.Question) == (int)MsgBoxResult.Yes)
                    {
                        App.DB.StandardSentence.Delete(Conversions.ToInteger(SelectedStandardSentencesDataRow["SentenceID"]));
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