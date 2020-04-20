using System;
using System.Data;
using System.Windows.Forms;
using FSM.Entity.EngineerRoles;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMEngineerRolesDeleteMe
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        // Public ReadOnly Property LoadedControl As IUserControl Implements IForm.LoadedControl
        // Get
        // Return Nothing
        // End Get
        // End Property

        // Public Sub LoadMe(sender As Object, e As EventArgs) Implements IForm.LoadMe
        // LoadForm(sender, e, Me)
        // Me.PopulateEngineerRole()
        // End Sub

        // Public Sub ResetMe(newID As Integer) Implements IForm.ResetMe
        // Throw New NotImplementedException()
        // End Sub

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _dvEngineerRole;

        public FRMEngineerRolesDeleteMe()
        {
            // This call is required by the designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            PopulateEngineerRole();
        }

        private DataView DvEngineerRole
        {
            get
            {
                return _dvEngineerRole;
            }

            set
            {
                _dvEngineerRole = value;
                _dvEngineerRole.Table.TableName = "EngineerRole";
                dgrdEngineerRoles.DataSource = _dvEngineerRole;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void PopulateEngineerRole()
        {
            SetupDgrdEngineerRoles();
            var dt = Helper.ToDataTable(App.DB.EngineerRole.GetAll());
            var dv = new DataView(dt);
            DvEngineerRole = dv;
        }

        public void SaveEngineerRole()
        {
            try
            {
                var engineerRole = new EngineerRole();
                engineerRole.Name = txtName.ToString().Trim();
                engineerRole.HourlyCostToCompany = Conversions.ToDecimal(Helper.MakeDoubleValid(txtHourlyCostToCompany));
                engineerRole.Description = txtDescription.ToString().Trim();
                engineerRole = App.DB.EngineerRole.Insert(engineerRole);
                if (engineerRole.Id > 0)
                {
                    // success => refresh grid
                    PopulateEngineerRole();
                }
                else
                {
                    App.ShowMessage("The operation failed. Please change name and try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("The operation. Error: " + ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupDgrdEngineerRoles()
        {
            Helper.SetUpDataGrid(dgrdEngineerRoles);
            var dgts = dgrdEngineerRoles.TableStyles[0];
            var roleName = new DataGridJobTypeColumn();
            roleName.Format = "";
            roleName.FormatInfo = null;
            roleName.HeaderText = "Role Name";
            roleName.MappingName = "Name";
            roleName.ReadOnly = true;
            roleName.Width = 145;
            roleName.NullText = "";
            dgts.GridColumnStyles.Add(roleName);
            var rate = new DataGridJobTypeColumn();
            rate.Format = "";
            rate.FormatInfo = null;
            rate.HeaderText = "Hourly Cost";
            rate.MappingName = "HourlyCostToCompany";
            rate.ReadOnly = true;
            rate.Width = 100;
            rate.NullText = "";
            dgts.GridColumnStyles.Add(rate);
            var description = new DataGridJobTypeColumn();
            description.Format = "";
            description.FormatInfo = null;
            description.HeaderText = "Description";
            description.MappingName = "Desctription";
            description.ReadOnly = true;
            description.Width = 100;
            description.NullText = "";
            dgts.GridColumnStyles.Add(description);
            dgts.ReadOnly = true;
            dgts.MappingName = "EngineerRole";
            dgrdEngineerRoles.TableStyles.Add(dgts);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private void cmdSave_Click(object sender, EventArgs e)
        {
        }
    }
}