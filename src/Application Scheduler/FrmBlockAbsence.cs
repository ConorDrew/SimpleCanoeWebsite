using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FrmBlockAbsence
    {
        public FrmBlockAbsence()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            LoadAbsencestypeComboBox();
        }

        public event UserAbsenceChangedEventHandler UserAbsenceChanged;

        public delegate void UserAbsenceChangedEventHandler();

        
        private DataView _dvEmployees;

        public DataView EmployeesDataView
        {
            get
            {
                return _dvEmployees;
            }

            set
            {
                _dvEmployees = value;
                if (EmployeesDataView is object)
                {
                    if (EmployeesDataView.Table is object)
                    {
                        _dvEmployees.Table.TableName = "tblEmployees";
                        _dvEmployees.AllowNew = false;
                    }
                }

                dgEmployees.DataSource = EmployeesDataView;
            }
        }

        
        

        private void setUpDataGrid()
        {
            SuspendLayout();
            Entity.Sys.Helper.SetUpDataGrid(dgEmployees);
            var ts = dgEmployees.TableStyles[0];

            // Set up columns
            ts.ReadOnly = false;
            dgEmployees.ReadOnly = false;
            var include = new DataGridBoolColumn();
            include.HeaderText = "Include";
            include.MappingName = "Include";
            include.ReadOnly = false;
            include.Width = 50;
            include.AllowNull = false;
            ts.GridColumnStyles.Add(include);
            var name = new DataGridLabelColumn();
            name.Format = "";
            name.FormatInfo = null;
            name.HeaderText = "Name";
            name.MappingName = "Name";
            name.ReadOnly = true;
            name.Width = 200;
            ts.GridColumnStyles.Add(name);
            ts.MappingName = "tblEmployees";
            dgEmployees.TableStyles.Add(ts);
            ResumeLayout(true);
        }

        private void LoadAbsencestypeComboBox()
        {
            var dt = new DataTable();
            dt = App.DB.EngineerAbsence.EngineerAbsenceTypes_GetAll();
            var pleaseSelect = dt.NewRow();
            pleaseSelect["Description"] = "-- Please Select --";
            pleaseSelect["EngineerAbsenceTypeID"] = 0;
            dt.Rows.InsertAt(pleaseSelect, 0);
            dt.AcceptChanges();
            cboType.DataSource = dt;
            cboType.DisplayMember = "Description";
            cboType.ValueMember = "EngineerAbsenceTypeID";
        }

        private void Save()
        {
            try
            {
                if (!(Information.IsNumeric(txtStartTimeHours.Text) && Conversions.ToDouble(txtStartTimeHours.Text) >= 0 && Conversions.ToDouble(txtStartTimeHours.Text) <= 23 && Information.IsNumeric(txtStartTimeMinutes.Text) && Conversions.ToDouble(txtStartTimeMinutes.Text) >= 0 && Conversions.ToDouble(txtStartTimeMinutes.Text) <= 59))
                {
                    MessageBox.Show("Start time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return;
                }

                if (!(Information.IsNumeric(txtEndTimeHours.Text) && Conversions.ToDouble(txtEndTimeHours.Text) >= 0 && Conversions.ToDouble(txtEndTimeHours.Text) <= 23 && Information.IsNumeric(txtEndTimeMinutes.Text) && Conversions.ToDouble(txtEndTimeMinutes.Text) >= 0 && Conversions.ToDouble(txtEndTimeMinutes.Text) <= 59))
                {
                    MessageBox.Show("End time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return;
                }

                var startTime = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, Conversions.ToInteger(txtStartTimeHours.Text), Conversions.ToInteger(txtStartTimeMinutes.Text), 0);
                var endTime = new DateTime(dtTo.Value.Year, dtTo.Value.Month, dtTo.Value.Day, Conversions.ToInteger(txtEndTimeHours.Text), Conversions.ToInteger(txtEndTimeMinutes.Text), 0);
                if (DateTime.Compare(startTime, endTime) > 0)
                {
                    MessageBox.Show("End date can not be before start date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return;
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(cboType.SelectedValue, 0, false)))
                {
                    MessageBox.Show("Please select an absence type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return;
                }

                Entity.UserAbsence.UserAbsence ua = null;
                Entity.EngineerAbsence.EngineerAbsence ea;
                foreach (DataRowView r in EmployeesDataView)
                {
                    if (Conversions.ToBoolean(r["Include"]))
                    {
                        if ((cboEmployeeGroup.Text ?? "") == "Engineers")
                        {
                            ea = new Entity.EngineerAbsence.EngineerAbsence();
                            ea.IgnoreExceptionsOnSetMethods = false;
                            ea.SetComments = txtComments.Text;
                            ea.SetAbsenceTypeID = cboType.SelectedValue;
                            ea.SetEngineerID = Conversions.ToString(r["ID"]);
                            ea.DateFrom = startTime;
                            ea.DateTo = endTime;
                            App.DB.EngineerAbsence.Insert(ea);
                        }
                        else
                        {
                            ua = new Entity.UserAbsence.UserAbsence();
                            ua.IgnoreExceptionsOnSetMethods = false;
                            ua.SetComments = txtComments.Text;
                            ua.SetAbsenceTypeID = cboType.SelectedValue;
                            ua.SetUserID = Conversions.ToString(r["ID"]);
                            ua.DateFrom = startTime;
                            ua.DateTo = endTime;
                            App.DB.UserAbsence.Insert(ua);
                        }
                    }
                }

                UserAbsenceChanged?.Invoke();
                if (Modal)
                {
                    Close();
                }
                else
                {
                    Dispose();
                }
            }
            catch (ValidationException ex)
            {
                string msg = "Please correct the following errors:{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, ex.Validator.CriticalMessagesString());
                MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        

        private void FrmBlockAbsence_Load(object sender, EventArgs e)
        {
            LoadForm(this);
            setUpDataGrid();
            cboEmployeeGroup.SelectedIndex = 0;
            ActiveControl = cboEmployeeGroup;
            cboEmployeeGroup.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgEmployees_Clicks(object sender, EventArgs e)
        {
            try
            {
                // this code mainly facilitates single clicks to change the state of a checkbox
                int includeColumn = 0;
                var pt = dgEmployees.PointToClient(MousePosition);
                var hti = dgEmployees.HitTest(pt);
                var bmb = BindingContext[dgEmployees.DataSource,
dgEmployees.DataMember];
                if (hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell && hti.Column == includeColumn)
                {
                    bool selected = !Conversions.ToBoolean(dgEmployees[hti.Row, includeColumn]);
                    dgEmployees[hti.Row, includeColumn] = selected;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmployeesDataView is object)
                {
                    if (EmployeesDataView.Table is object)
                    {
                        foreach (DataRow r in EmployeesDataView.Table.Rows)
                            r["Include"] = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmployeesDataView is object)
                {
                    if (EmployeesDataView.Table is object)
                    {
                        foreach (DataRow r in EmployeesDataView.Table.Rows)
                            r["Include"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboEmployeeGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var dt = new DataTable();
                if ((cboEmployeeGroup.Text ?? "") == "Engineers")
                {
                    dt = App.DB.Engineer.Engineer_GetAll().Table;
                    dt.Columns["EngineerID"].ColumnName = "ID";
                    gbEmployees.Text = "Engineers";
                }
                else
                {
                    dt = App.DB.User.GetAll().Table;
                    dt.Columns["Fullname"].ColumnName = "Name";
                    dt.Columns["UserID"].ColumnName = "ID";
                    gbEmployees.Text = "Users";
                }

                var dc = new DataColumn();
                dc.DataType = typeof(bool);
                dc.DefaultValue = false;
                dc.ColumnName = "Include";
                dc.ReadOnly = false;
                dt.Columns.Add(dc);
                dt.TableName = "tblEmployees";
                dt.AcceptChanges();
                EmployeesDataView = new DataView(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEndTimeHours_TextChanged(object sender, EventArgs e)
        {
            var sequence = new TextBox[] { txtStartTimeHours, txtStartTimeMinutes, txtEndTimeHours, txtEndTimeMinutes };
            TextBox currentBox = (TextBox)sender;
            if (currentBox.Text.Length >= 2 && Array.IndexOf(sequence, currentBox) < sequence.Length - 1)
            {
                sequence[Array.IndexOf(sequence, currentBox) + 1].Focus();
                sequence[Array.IndexOf(sequence, currentBox) + 1].SelectAll();
            }
            else if (currentBox.Text.Length == 0 && Array.IndexOf(sequence, currentBox) - 1 >= 0)
            {
                sequence[Array.IndexOf(sequence, currentBox) - 1].Focus();
                sequence[Array.IndexOf(sequence, currentBox) - 1].SelectAll();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool itemsSelected = false;
                if (EmployeesDataView is object)
                {
                    if (EmployeesDataView.Table is object)
                    {
                        foreach (DataRowView r in EmployeesDataView)
                        {
                            if (Conversions.ToBoolean(r["Include"]))
                            {
                                itemsSelected = true;
                            }
                        }
                    }
                }

                if (itemsSelected == false)
                {
                    MessageBox.Show("You must select at least one employee from the list", "Selection required", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorMsg.ErrorOccured(ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}