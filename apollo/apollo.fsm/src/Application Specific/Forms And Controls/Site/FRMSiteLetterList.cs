using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMSiteLetterList : FRMBaseForm, IForm
    {
        public FRMSiteLetterList()
        {
            InitializeComponent();
        }

        

        public void LoadMe(object sender, EventArgs e)
        {
            SetupTemplateDataGrid();
            var dt = new DataTable();
            dt.Columns.Add("Template");
            DataRow r;
            var files = Directory.GetFiles(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\SiteLetters\");
            foreach (string f in files)
            {
                if ((f.Replace(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\SiteLetters\", "") ?? "") != "vssver.scc")
                {
                    r = dt.NewRow();
                    r["Template"] = Path.GetFileName(f);
                    dt.Rows.Add(r);
                }
            }

            dvLetters = new DataView(dt);
        }

        public IUserControl LoadedControl
        {
            get
            {
                return default;
            }
        }

        public void ResetMe(int newID)
        {
        }

        
        
        private DataView _dvLetters = null;

        public DataView dvLetters
        {
            get
            {
                return _dvLetters;
            }

            set
            {
                _dvLetters = value;
                _dvLetters.Table.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString();
                _dvLetters.AllowNew = false;
                _dvLetters.AllowEdit = false;
                _dvLetters.AllowDelete = false;
                dgLetters.DataSource = dvLetters;
            }
        }

        private DataRow SelectedLetterDatarow
        {
            get
            {
                if (!(dgLetters.CurrentRowIndex == -1))
                {
                    return dvLetters[dgLetters.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private string _selectedTemplate = "";

        public string SelectedTemplate
        {
            get
            {
                return _selectedTemplate;
            }

            set
            {
                _selectedTemplate = value;
            }
        }

        
        

        public void SetupTemplateDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgLetters);
            var tStyle = dgLetters.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Template = new DataGridLabelColumn();
            Template.Format = "";
            Template.FormatInfo = null;
            Template.HeaderText = "Template";
            Template.MappingName = "Template";
            Template.ReadOnly = true;
            Template.Width = 300;
            Template.NullText = "";
            tStyle.GridColumnStyles.Add(Template);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSite.ToString();
            dgLetters.TableStyles.Add(tStyle);
        }

        
        

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (SelectedLetterDatarow is null)
            {
                return;
            }

            SelectedTemplate = Conversions.ToString(SelectedLetterDatarow["Template"]);
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void FRMSiteLetterList_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        
    }
}