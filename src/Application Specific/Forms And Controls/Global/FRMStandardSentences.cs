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
            _gpbStandardSentences = new GroupBox();
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _dgStandardSentences = new DataGrid();
            _dgStandardSentences.Click += new EventHandler(dgStandardSentences_Click);
            _gpbEditAdd = new GroupBox();
            _txtSentence = new TextBox();
            _Label1 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _gpbStandardSentences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgStandardSentences).BeginInit();
            _gpbEditAdd.SuspendLayout();
            SuspendLayout();
            //
            // gpbStandardSentences
            //
            _gpbStandardSentences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _gpbStandardSentences.Controls.Add(_btnDelete);
            _gpbStandardSentences.Controls.Add(_btnAddNew);
            _gpbStandardSentences.Controls.Add(_dgStandardSentences);
            _gpbStandardSentences.Location = new Point(8, 40);
            _gpbStandardSentences.Name = "gpbStandardSentences";
            _gpbStandardSentences.Size = new Size(608, 448);
            _gpbStandardSentences.TabIndex = 2;
            _gpbStandardSentences.TabStop = false;
            _gpbStandardSentences.Text = "Standard Sentences";
            //
            // btnDelete
            //
            _btnDelete.Location = new Point(520, 16);
            _btnDelete.Name = "btnDelete";
            _btnDelete.TabIndex = 2;
            _btnDelete.Text = "Delete";
            _btnDelete.Visible = false;
            //
            // btnAddNew
            //
            _btnAddNew.Location = new Point(8, 16);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.TabIndex = 1;
            _btnAddNew.Text = "Add New";
            //
            // dgStandardSentences
            //
            _dgStandardSentences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgStandardSentences.DataMember = "";
            _dgStandardSentences.HeaderForeColor = SystemColors.ControlText;
            _dgStandardSentences.Location = new Point(8, 42);
            _dgStandardSentences.Name = "dgStandardSentences";
            _dgStandardSentences.Size = new Size(592, 398);
            _dgStandardSentences.TabIndex = 0;
            //
            // gpbEditAdd
            //
            _gpbEditAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbEditAdd.Controls.Add(_txtSentence);
            _gpbEditAdd.Controls.Add(_Label1);
            _gpbEditAdd.Controls.Add(_btnSave);
            _gpbEditAdd.Location = new Point(624, 40);
            _gpbEditAdd.Name = "gpbEditAdd";
            _gpbEditAdd.Size = new Size(224, 448);
            _gpbEditAdd.TabIndex = 3;
            _gpbEditAdd.TabStop = false;
            _gpbEditAdd.Text = "Add/Edit";
            //
            // txtSentence
            //
            _txtSentence.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSentence.Location = new Point(8, 42);
            _txtSentence.Multiline = true;
            _txtSentence.Name = "txtSentence";
            _txtSentence.ScrollBars = ScrollBars.Vertical;
            _txtSentence.Size = new Size(208, 256);
            _txtSentence.TabIndex = 0;
            _txtSentence.Text = "";
            //
            // Label1
            //
            _Label1.Location = new Point(8, 24);
            _Label1.Name = "Label1";
            _Label1.TabIndex = 1;
            _Label1.Text = "Sentence";
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSave.Location = new Point(136, 306);
            _btnSave.Name = "btnSave";
            _btnSave.TabIndex = 3;
            _btnSave.Text = "Save";
            //
            // FRMStandardSentences
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(856, 494);
            Controls.Add(_gpbEditAdd);
            Controls.Add(_gpbStandardSentences);
            Name = "FRMStandardSentences";
            Text = "Standard Sentences";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_gpbStandardSentences, 0);
            Controls.SetChildIndex(_gpbEditAdd, 0);
            _gpbStandardSentences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgStandardSentences).EndInit();
            _gpbEditAdd.ResumeLayout(false);
            ResumeLayout(false);
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