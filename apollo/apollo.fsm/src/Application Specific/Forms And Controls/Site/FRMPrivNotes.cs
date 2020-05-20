using System;
using System.Data;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMPrivNotes
    {
        public FRMPrivNotes()
        {
            InitializeComponent();
        }

        public DataRow dr = null;
        public DateTime Max = DateTime.MaxValue;
        public DataTable dt = new DataTable();

        private void FRMChangePriority_Load(object sender, EventArgs e)
        {
            Entity.Sys.Helper.SetUpDataGridView(dgvNotes);
            // dgvNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvNotes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvNotes.AutoGenerateColumns = false;
            dgvNotes.Columns.Clear();
            dgvNotes.EditMode = DataGridViewEditMode.EditOnEnter;
            var SiteID = new DataGridViewTextBoxColumn();
            SiteID.Width = 1;
            SiteID.DataPropertyName = "JobNoteID";
            SiteID.Name = "JobNoteID";
            SiteID.ReadOnly = true;
            SiteID.Visible = false;
            SiteID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvNotes.Columns.Add(SiteID);
            var Code = new DataGridViewTextBoxColumn();
            Code.Width = 110;
            Code.DataPropertyName = "JobNumber";
            Code.Name = "JobNumber";
            Code.ReadOnly = true;
            Code.Visible = true;
            Code.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvNotes.Columns.Add(Code);
            var Description = new DataGridViewTextBoxColumn();
            Description.Width = 600;
            Description.DataPropertyName = "Note";
            Description.Name = "Note";
            Description.ReadOnly = true;
            Description.Visible = true;
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            // Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dgvNotes.Columns.Add(Description);
            var Qty = new DataGridViewTextBoxColumn();
            Qty.Width = 130;
            Qty.DataPropertyName = "LastEdited";
            Qty.Name = "LastEdited";
            Qty.HeaderText = "Last Edited";
            Qty.ReadOnly = true;
            Qty.Visible = true;
            Qty.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvNotes.Columns.Add(Qty);
            var Time = new DataGridViewTextBoxColumn();
            Time.Width = 145;
            Time.DataPropertyName = "EditedBy";
            Time.HeaderText = "Edited By";
            Time.Name = "EditedBy";
            Time.ReadOnly = true;
            Time.Visible = true;
            Time.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvNotes.Columns.Add(Time);
            dgvNotes.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = App.loggedInUser.UserID;
            dr[2] = App.loggedInUser.UserID;
            dr[3] = txtEngineernotes.Text;
            dr[4] = DateTime.Now;
            dr[5] = App.loggedInUser.Username;
            dr[6] = DateTime.Now;
            dr[7] = App.loggedInUser.Username;
            dr[8] = 0;
            dr[9] = "New..";
            dr[10] = 0;
            dt.Rows.InsertAt(dr, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }
    }
}