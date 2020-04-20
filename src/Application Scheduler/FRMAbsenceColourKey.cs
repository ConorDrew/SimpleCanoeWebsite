using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMAbsenceColourKey
    {
        public FRMAbsenceColourKey()
        {
            InitializeComponent();
        }

        private void FRMAbsenceColourKey_Load(object sender, EventArgs e)
        {
            setUpDg();
            dgAbsences.DataSource = App.DB.EngineerAbsence.EngineerAbsenceTypes_GetAll();
        }

        private void setUpDg()
        {
            ModScheduler.SetUpSchedulerDataGrid(dgAbsences, false);
            var tsSummary = dgAbsences.TableStyles[0];
            var absence = new frmEngineerSchedule.unavailableBar();
            absence.Format = "";
            absence.FormatInfo = null;
            absence.HeaderText = "Colour";
            absence.MappingName = "AbsenceColumn";
            absence.ReadOnly = true;
            absence.Width = 60;
            absence.NullText = "";
            tsSummary.GridColumnStyles.Add(absence);
            var Description = new DataGridLabelColumn();
            Description.MappingName = "Description";
            Description.HeaderText = "Absence Type";
            Description.ReadOnly = true;
            Description.Alignment = HorizontalAlignment.Center;
            Description.Width = 100;
            tsSummary.GridColumnStyles.Add(Description);
            tsSummary.MappingName = "tblEngineerAbsenceTypes";
        }
    }
}