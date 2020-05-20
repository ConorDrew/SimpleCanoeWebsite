using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMCreateServices
    {
        public FRMCreateServices()
        {
            InitializeComponent();
        }

        public int SiteID;

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Information.IsNumeric(txtAmount.Text) && Conversions.ToDouble(txtAmount.Text) > 0)
                {
                    CreateServices();
                    Interaction.MsgBox(txtAmount.Text + " Services created!", MsgBoxStyle.Information);
                    if (Modal)
                    {
                        Close();
                    }
                    else
                    {
                        Dispose();
                    }
                }
                else
                {
                    App.ShowMessage("Please select an Amount to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Somthing went terribly wrong , best speak to Rob", MsgBoxStyle.Critical, "Ooooppss");
            }
        }

        private void FRMChangePriority_Load(object sender, EventArgs e)
        {
        }

        private void CreateServices()
        {
            for (int i = 1, loopTo = Conversions.ToInteger(txtAmount.Text); i <= loopTo; i++)
            {
                // CREATE JOB
                var job = new Entity.Jobs.Job();
                job.SetPropertyID = SiteID;
                job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Contract);
                if (chxCert.Checked)
                {
                    job.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service and Certificate'")[0]["ManagerID"];
                }
                else
                {
                    job.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")[0]["ManagerID"];
                }

                job.SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open);
                job.SetCreatedByUserID = App.loggedInUser.UserID;
                job.SetFOC = true;
                var JobNumber = new JobNumber();
                JobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
                job.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                job.SetPONumber = "";
                job.SetQuoteID = 0;

                // INSERT JOB ITEM
                var jobOfWork = new Entity.JobOfWorks.JobOfWork();
                jobOfWork.SetPONumber = "";
                jobOfWork.IgnoreExceptionsOnSetMethods = true;
                var site = App.DB.Sites.Get(SiteID);
                var customerSors = App.DB.CustomerScheduleOfRate.Exists(4693, "Hassle Free Service", "HF1", site.CustomerID);
                int customerSorId = 0;
                if (customerSors.Rows.Count > 0)
                    customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                if (!(customerSorId > 0))
                {
                    var customerSor = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate()
                    {
                        SetCode = "HF1",
                        SetDescription = "Hassle Free Service",
                        SetPrice = 0.0,
                        SetScheduleOfRatesCategoryID = 4693,
                        SetTimeInMins = 45,
                        SetCustomerID = site.CustomerID
                    };
                    customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                    App.DB.CustomerScheduleOfRate.Delete(customerSorId);
                }

                var jobItem = new Entity.JobItems.JobItem();
                jobItem.IgnoreExceptionsOnSetMethods = true;
                jobItem.SetSummary = "Hassle Free Service";
                jobItem.SetQty = 1;
                jobItem.SetRateID = customerSorId;
                jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                jobOfWork.JobItems.Add(jobItem);
                var engineerVisit = new Entity.EngineerVisits.EngineerVisit();
                engineerVisit.IgnoreExceptionsOnSetMethods = true;
                engineerVisit.SetEngineerID = 0; // engineerID
                if (chxCert.Checked)
                {
                    engineerVisit.SetNotesToEngineer = "Service and Cert Appliance Covered by Hassle Free Heating";
                }
                else
                {
                    engineerVisit.SetNotesToEngineer = "Service Appliance Covered by Hassle Free Heating";
                }

                engineerVisit.StartDateTime = DateTime.MinValue;
                engineerVisit.EndDateTime = DateTime.MinValue;
                engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
                jobOfWork.EngineerVisits.Add(engineerVisit);
                job.JobOfWorks.Add(jobOfWork);
                job = App.DB.Job.Insert(job);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
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