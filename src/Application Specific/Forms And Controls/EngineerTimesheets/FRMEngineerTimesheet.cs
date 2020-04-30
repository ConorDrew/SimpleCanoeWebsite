using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace FSM
{
    public partial class FRMEngineerTimesheet : FRMBaseForm, IForm
    {
        public FRMEngineerTimesheet()
        {
            InitializeComponent();
        }

        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.TimeSheetTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            CurrentTimesheet = App.DB.EngineerTimesheets.Get(Conversions.ToInteger(get_GetParameter(0)));
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(get_GetParameter(1), "Visit", false)))
            {
                cboType.Enabled = false;
                btnFindRecord.Enabled = false;
            }
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

        
        
        private Entity.EngineerTimeSheets.EngineerTimeSheet _CurrentTimesheet;

        private Entity.EngineerTimeSheets.EngineerTimeSheet CurrentTimesheet
        {
            get
            {
                return _CurrentTimesheet;
            }

            set
            {
                _CurrentTimesheet = value;
                if (_CurrentTimesheet is null)
                {
                    _CurrentTimesheet = new Entity.EngineerTimeSheets.EngineerTimeSheet();
                    _CurrentTimesheet.Exists = false;
                }

                if (CurrentTimesheet.Exists)
                {
                    Populate();
                }
                else
                {
                    oEngineer = null;
                    var argcombo = cboType;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
                    txtComments.Text = "";
                    dtpFrom.Value = DateAndTime.Now;
                    dtpTo.Value = DateAndTime.Now;
                }
            }
        }

        private Entity.Engineers.Engineer _oEngineer;

        public Entity.Engineers.Engineer oEngineer
        {
            get
            {
                return _oEngineer;
            }

            set
            {
                _oEngineer = value;
                if (_oEngineer is object)
                {
                    txtSearch.Text = oEngineer.Name;
                }
                else
                {
                    txtSearch.Text = "";
                }
            }
        }

        
        

        private void FRMEngineerTimesheet_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnFindRecord_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                oEngineer = App.DB.Engineer.Engineer_Get(ID);
            }
        }

        
        

        private void Populate()
        {
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentTimesheet.TimeSheetTypeID.ToString());
            oEngineer = App.DB.Engineer.Engineer_Get(CurrentTimesheet.EngineerID);
            txtComments.Text = CurrentTimesheet.Comments;
            dtpFrom.Value = CurrentTimesheet.StartDateTime;
            dtpTo.Value = CurrentTimesheet.EndDateTime;
        }

        private void Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentTimesheet.IgnoreExceptionsOnSetMethods = true;
                CurrentTimesheet.SetTimeSheetTypeID = Combo.get_GetSelectedItemValue(cboType);
                if (oEngineer is object)
                {
                    CurrentTimesheet.SetEngineerID = oEngineer.EngineerID;
                }

                CurrentTimesheet.SetComments = txtComments.Text;
                CurrentTimesheet.StartDateTime = dtpFrom.Value;
                CurrentTimesheet.EndDateTime = dtpTo.Value;
                var cV = new Entity.EngineerTimeSheets.EngineerTimeSheetValidator();
                cV.Validate(CurrentTimesheet);
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(get_GetParameter(1), "General", false)))
                {
                    if (CurrentTimesheet.Exists)
                    {
                        App.DB.EngineerTimesheets.Update(CurrentTimesheet);
                    }
                    else
                    {
                        App.DB.EngineerTimesheets.Insert(CurrentTimesheet);
                    }
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(get_GetParameter(1), "Visit", false)))
                {
                    if (CurrentTimesheet.Exists)
                    {
                        App.DB.EngineerTimesheets.UpdateVisit(CurrentTimesheet);
                    }
                    else
                    {
                        // DB.EngineerVisitsTimeSheet.Insert(CurrentTimesheet)
                    }
                }

                App.ShowMessage("Timesheet Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        
    }
}