using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMBookJob
    {
        public FRMBookJob()
        {
            InitializeComponent();
        }

        public DataRow dr = null;
        public DateTime Max = DateTime.MaxValue;
        public DataTable dt = new DataTable();
        private DateTime Min = DateAndTime.Today.AddDays(1);

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 0)
            {
                App.ShowMessage("Please select an AM or PM appointment ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dtpDate.SelectedDates.Count == 0)
            {
                App.ShowMessage("Please select a Date ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void FRMChangePriority_Load(object sender, EventArgs e)
        {
            var argc = cboAppointment;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Appointments, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            dtpDate.MaxDate = Max;
            dtpDate.MinDate = Min;
            dtpDate.SelectDate(DateAndTime.Today);
            dtpDate.ActiveMonth.Month = Min.Month;
            dtpDate.ActiveMonth.Year = Min.Year;
            var d = new Pabo.Calendar.DateItem[dt.Rows.Count / (double)2 + 1];
            int i = 0;
            int inarea = 0;
            int col = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["AMPM"], "AM", false)))
                {
                    d[i] = new Pabo.Calendar.DateItem();
                    inarea = 0;
                    col = Conversions.ToInteger(col + row["Avail"]);
                    if (Conversions.ToBoolean(row["Avail"] > 0))
                    {
                        // d(i).Text = d(i).Text & "AM"
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["InArea"], 1, false)))
                    {
                        inarea += 1;
                    }
                }
                else
                {
                    d[i].Date = Conversions.ToDate(row["Date"]);
                    if (Conversions.ToBoolean(row["Avail"] > 0))
                    {
                        // d(i).Text = d(i).Text & " PM"

                    }

                    col = Conversions.ToInteger(col + row["Avail"]);
                    var switchExpr = col;
                    switch (switchExpr)
                    {
                        case 0:
                            {
                                d[i].BackColor1 = Color.Red;
                                break;
                            }

                        // Case Is > 20
                        // d(i).BackColor1 = Color.Green

                        case object _ when switchExpr > 10:
                            {
                                d[i].BackColor1 = Color.Yellow;
                                break;
                            }

                        case object _ when switchExpr > 2:
                            {
                                d[i].BackColor1 = Color.Orange;
                                break;
                            }
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["InArea"], 1, false)))
                    {
                        inarea += 1;
                    }

                    if (inarea > 0)
                    {
                        d[i].BackColor1 = Color.Green;
                    }

                    col = 0;
                    i = i + 1;
                }
            }

            dtpDate.AddDateInfo(d);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var argcombo = cboAppointment;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void dtpDate_MonthChanged(object sender, Pabo.Calendar.DayClickEventArgs e)
        {
            var dr = dt.Select("Date = '" + Conversions.ToDate(e.Date).ToString("dd/MM/yyyy") + " 00:00:00' AND Avail > 0");
            if (dr.Length > 1)
            {
                // two avaialble appointemnts
                lblMessage.Text = "AM and PM Available";
            }
            else if (dr.Length > 0 && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr[0]["AMPM"], "AM", false)))
            {
                lblMessage.Text = "AM Available";
            }
            else if (dr.Length > 0 && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr[0]["AMPM"], "PM", false)))
            {
                lblMessage.Text = "PM Available";
            }
            else
            {
                lblMessage.Text = "No Suggested Appointments available on this day";
            }

            var dr2 = dt.Select("Date = '" + Conversions.ToDate(e.Date).ToString("dd/MM/yyyy") + " 00:00:00' AND InArea = 1");
            if (dr2.Length > 1)
            {
                // two avaialble appointemnts

                lblMessage.Text = "Engineer in this area AM and PM";
            }
            else if (dr2.Length > 0 && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr2[0]["AMPM"], "AM", false)))
            {
                lblMessage.Text = "Engineer in this area AM";
                if (Conversions.ToBoolean(dr.Length > 0 && Operators.ConditionalCompareObjectEqual(dr[0]["AMPM"], "PM", false) | Operators.ConditionalCompareObjectEqual(dr[1]["AMPM"], "PM", false)))
                {
                    lblMessage.Text += ", PM is also Available but no close engineer";
                }
            }
            else if (dr2.Length > 0 && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr2[0]["AMPM"], "PM", false)))
            {
                lblMessage.Text = "Engineer in this area PM";
                if (dr.Length > 0 && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr[0]["AMPM"], "AM", false)))
                {
                    lblMessage.Text += ", AM is also Available but no close engineer";
                }
            }
            else
            {
            }
        }
    }
}