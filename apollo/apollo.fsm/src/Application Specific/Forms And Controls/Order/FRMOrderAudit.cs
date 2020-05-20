using System;
using System.Data;
using System.Management.Automation.Language;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMOrderAudit : FRMBaseForm, IForm
    {
        private const int ORDER_ID = 0;
        public FRMOrderAudit() : base()
        {
            // This call is required by the Windows Form Designer.
            this.InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(this.components is null))
                {
                    this.components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        public void LoadMe(object sender, EventArgs e)
        {
            base.LoadForm(sender, e, this);
            SetupOrderAuditDataGrid();
            PopulateDatagrid();
        }

        public FSM.IUserControl LoadedControl
        {
            get
            {
                throw new NotImplementedException();
                return null;
            }
        }

        public void ResetMe(int newID)
        {
            throw new NotImplementedException();
        }

        private DataView _dvOrderAudits;

        private DataView OrderAuditsDataview
        {
            get
            {
                return _dvOrderAudits;
            }

            set
            {
                _dvOrderAudits = value;
                _dvOrderAudits.AllowNew = false;
                _dvOrderAudits.AllowEdit = false;
                _dvOrderAudits.AllowDelete = false;
                _dvOrderAudits.Table.TableName = FSM.Entity.Sys.Enums.TableNames.tblOrderAudit.ToString();
                this.dgOrderAudits.DataSource = OrderAuditsDataview;
            }
        }

        private DataRow SelectedOrderAuditDataRow
        {
            get
            {
                if (!(this.dgOrderAudits.CurrentRowIndex == -1))
                {
                    return OrderAuditsDataview[this.dgOrderAudits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }


        private void SetupOrderAuditDataGrid()
        {
            var tbStyle = this.dgOrderAudits.TableStyles[0];
            var ActionChange = new FSM.DataGridLabelColumn();
            ActionChange.Format = "";
            ActionChange.FormatInfo = null;
            ActionChange.HeaderText = "Action";
            ActionChange.MappingName = "Description";
            ActionChange.ReadOnly = true;
            ActionChange.Width = 650;
            ActionChange.NullText = "";
            tbStyle.GridColumnStyles.Add(ActionChange);
            var ReasonType = new FSM.DataGridLabelColumn();
            ReasonType.Format = "";
            ReasonType.FormatInfo = null;
            ReasonType.HeaderText = "Reason";
            ReasonType.MappingName = "OrderAuditReasonType";
            ReasonType.ReadOnly = true;
            ReasonType.Width = 150;
            ReasonType.NullText = "";
            tbStyle.GridColumnStyles.Add(ReasonType);
            var ActionDateTime = new FSM.DataGridLabelColumn();
            ActionDateTime.Format = "dddd dd MMMM yyyy HH:mm:ss";
            ActionDateTime.FormatInfo = null;
            ActionDateTime.HeaderText = "Action Date Time";
            ActionDateTime.MappingName = "TimeChanged";
            ActionDateTime.ReadOnly = true;
            ActionDateTime.Width = 150;
            ActionDateTime.NullText = "";
            tbStyle.GridColumnStyles.Add(ActionDateTime);
            var Fullname = new FSM.DataGridLabelColumn();
            Fullname.Format = "";
            Fullname.FormatInfo = null;
            Fullname.HeaderText = "User";
            Fullname.MappingName = "Fullname";
            Fullname.ReadOnly = true;
            Fullname.Width = 100;
            Fullname.NullText = "";
            tbStyle.GridColumnStyles.Add(Fullname);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = FSM.Entity.Sys.Enums.TableNames.tblOrderAudit.ToString();
            this.dgOrderAudits.TableStyles.Add(tbStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void FRMOrderAudit_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }


        public void PopulateDatagrid()
        {
            try
            {
                OrderAuditsDataview = FSM.App.DB.OrderAudits.Get_For_Job(Conversions.ToInteger(base.get_GetParameter(ORDER_ID)));
            }
            catch (Exception ex)
            {
                FSM.App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}