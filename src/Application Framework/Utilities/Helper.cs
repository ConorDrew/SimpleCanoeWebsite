using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FSM.Entity
{
    namespace Sys
    {
        public class Helper
        {
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public static string MakeStringValid(object o)
            {
                try
                {
                    if (o is null)
                    {
                        return "";
                    }
                    else if (o == DBNull.Value)
                    {
                        return "";
                    }
                    else if (o.GetType() == typeof(string) && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(o, "vbcrlf", false)))
                    {
                        return "";
                    }
                    else if (o.GetType() == typeof(string) && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(o, "&nbsp;", false)))
                    {
                        return "";
                    }
                    else
                    {
                        return Conversions.ToString(o).Trim();
                    }
                }
                catch
                {
                    return "";
                }
            }

            public static int MakeIntegerValid(object o)
            {
                try
                {
                    if (o is null)
                    {
                        return 0;
                    }
                    else if (o == DBNull.Value)
                    {
                        return 0;
                    }
                    else if (string.IsNullOrEmpty(Conversions.ToString(o)))
                    {
                        return 0;
                    }
                    else
                    {
                        try
                        {
                            return Conversions.ToInteger(o);
                        }
                        catch
                        {
                            return 0;
                        }
                    }
                }
                catch
                {
                    return 0;
                }
            }

            public static bool IsValidInteger(object o)
            {
                string value = MakeStringValid(o);
                if (!Information.IsNumeric(value))
                {
                    return false;
                }
                else
                {
                    int pos = Strings.InStr(value, ".");
                    if (pos == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public static double MakeDoubleValid(object o)
            {
                try
                {
                    if (o is null)
                    {
                        return 0.0;
                    }
                    else if (o == DBNull.Value)
                    {
                        return 0.0;
                    }
                    else if (string.IsNullOrEmpty(Conversions.ToString(o)))
                    {
                        return 0.0;
                    }
                    else if (double.IsNaN(Conversions.ToDouble(o)))
                    {
                        return 0.0;
                    }
                    else
                    {
                        try
                        {
                            return Conversions.ToDouble(o);
                        }
                        catch
                        {
                            return 0.0;
                        }
                    }
                }
                catch
                {
                    return 0.0;
                }
            }

            public static double RoundDown(double number, int decimalPlaces)
            {
                return Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces);
            }

            public static bool MakeBooleanValid(object o)
            {
                try
                {
                    var switchExpr = App.TheSystem.DataBaseServerType;
                    switch (switchExpr)
                    {
                        case Enums.DatabaseSystems.MySQL:
                            {
                                if (o == DBNull.Value)
                                {
                                    return false;
                                }
                                else
                                {
                                    return Conversions.ToBoolean(Conversions.ToSByte(o).ToString());
                                }

                                break;
                            }

                        case Enums.DatabaseSystems.Microsoft_SQL_Server:
                            {
                                if (o is null)
                                {
                                    return false;
                                }
                                else if (o == DBNull.Value)
                                {
                                    return false;
                                }
                                else
                                {
                                    return Conversions.ToBoolean(o);
                                }

                                break;
                            }
                    }
                }
                catch
                {
                    return false;
                }

                return default;
            }

            public static DateTime MakeDateTimeValid(object o)
            {
                try
                {
                    if (o is null)
                    {
                        return default;
                    }
                    else if (o == DBNull.Value)
                    {
                        return default;
                    }
                    else
                    {
                        return Conversions.ToDate(FormatDateTime_Load(Conversions.ToDate(o)));
                    }
                }
                catch
                {
                    return default;
                }
            }

            public static DateTime? MakeNullableDateTimeValid(object o)
            {
                if (o is null)
                {
                    return default;
                }
                else if (o == DBNull.Value)
                {
                    return default;
                }
                else
                {
                    return DateTime.Parse(FormatDateTime_Load(Conversions.ToDate(0)));
                }
            }

            public static TimeSpan MakeTimeValid(object o)
            {
                if (o is null)
                {
                    return default;
                }
                else if (o == DBNull.Value)
                {
                    return default;
                }
                else if (!(o.GetType() == typeof(TimeSpan)))
                {
                    return default;
                }
                else
                {
                    return (TimeSpan)o;
                }
            }

            public static TimeSpan FormatTime(string o)
            {
                string time = Strings.Format(o, "HH:mm:ss");
                return TimeSpan.Parse(time);
            }

            public static string FormatDateTime_Load(DateTime DateTime)
            {
                return Strings.Format(DateTime, "dd/MMM/yyyy HH:mm:ss");
            }

            public static string CleanText(string text)
            {
                return text.Replace(Constants.vbNewLine, " ").Replace("'", "''").Replace("\"", "\"\"").Replace("[", "[[").Replace("]", "]]").Trim();
            }

            public static string RemoveSpecialCharacters(string text)
            {
                string removed = MakeStringValid(text);
                return Regex.Replace(removed, @"[^A-Za-z0-9\-\s/]", "");
            }

            public static string ToTitleCase(string text)
            {
                var textInfo = new CultureInfo("en-US", false).TextInfo;
                text = textInfo.ToTitleCase(text.ToLower());
                return text;
            }

            public static DataTable ToDataTable<T>(IList<T> list)
            {
                // declare new datatable
                var dt = new DataTable();

                // if the list is empty then we return a blank table
                if (list is null || !list.Any())
                {
                    return dt;
                }
                // get all the class properties
                var fields = list.First().GetType().GetProperties();
                // use the class properties as column name
                foreach (PropertyInfo field in fields)
                    dt.Columns.Add(field.Name, field.PropertyType);
                // populate datatable with values
                foreach (T item in list)
                {
                    var row = dt.NewRow();
                    foreach (PropertyInfo field in fields)
                    {
                        row[field.Name] = item.GetType().GetProperty(field.Name);
                    }

                    dt.Rows.Add(row);
                }

                return dt;
            }

            public static bool ValidatePhoneNumber(string number)
            {
                return Regex.Match(number, @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$", RegexOptions.IgnoreCase).Success;
            }

            public static string FormatPostcode(object postcode)
            {
                string pc = MakeStringValid(postcode);
                if (pc.Length < 3)
                    return pc;
                pc = pc.Replace("-", "");
                pc = pc.ToUpper();
                pc = pc.Insert(pc.Length - 3, " ");
                return pc;
            }

            public static string ConvertToPostcode(object postcode)
            {
                string pc = MakeStringValid(postcode).Trim();
                if (pc.Length < 3)
                    return pc;
                pc = pc.Replace(" ", "");
                pc = pc.ToUpper();
                pc = pc.Insert(pc.Length - 3, "-");
                return pc;
            }

            public static bool IsEmailValid(string email)
            {
                try
                {
                    var mail = new MailAddress(email);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            public static string MakeFileNameValid(string fileName)
            {
                foreach (char c in Path.GetInvalidFileNameChars())
                    fileName = fileName.Replace(Conversions.ToString(c), "_");
                return fileName;
            }

            public static int GetNumber(object value)
            {
                value = MakeStringValid(value);
                string number = string.Empty;
                char[] myChars = (char[])value;
                foreach (char ch in myChars)
                {
                    if (char.IsDigit(ch))
                    {
                        number += Conversions.ToString(ch);
                    }
                }

                return Convert.ToInt32(number);
            }

            public static object InsertDateIntoDb(DateTime date)
            {
                if (date == default || date == DateTime.MinValue)
                {
                    return DBNull.Value;
                }

                return date;
            }

            public static bool IsStringEmpty(object value)
            {
                value = MakeStringValid(value);
                return string.IsNullOrEmpty(Conversions.ToString(value)) | string.IsNullOrWhiteSpace(Conversions.ToString(value));
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            // Set the format and data
            public static void SetUpDataGrid(DataGrid dg, bool captionIsVisible = false)
            {
                dg.TableStyles.Clear();
                dg.TableStyles.Add(DefaultTableStyle());
                dg.AllowNavigation = false;
                dg.CaptionVisible = captionIsVisible;
                dg.AlternatingBackColor = Color.White;
                dg.BackgroundColor = Color.White;
                dg.BorderStyle = BorderStyle.FixedSingle;
                dg.CaptionBackColor = Color.SteelBlue;
                dg.CaptionForeColor = Color.White;
                dg.Font = new Font("Verdana", 8.0F);
                dg.ForeColor = Color.Navy;
                dg.GridLineColor = Color.LightSteelBlue;
                dg.HeaderBackColor = Color.SteelBlue;
                dg.HeaderFont = new Font("Verdana", 8.0F, FontStyle.Bold);
                dg.HeaderForeColor = Color.White;
                dg.LinkColor = Color.Navy;
                dg.ParentRowsBackColor = Color.White;
                dg.ParentRowsForeColor = Color.LightSteelBlue;
                dg.ParentRowsVisible = false;
                dg.RowHeadersVisible = false;
                dg.SelectionBackColor = Color.Gainsboro;
                dg.SelectionForeColor = Color.Navy;
                dg.ReadOnly = true;
                dg.Cursor = Cursors.Hand;
                dg.Click += dGrid_Multievents;
                dg.CurrentCellChanged += dGrid_Multievents;
            }

            // Fire the events required
            public static void dGrid_Multievents(object sender, EventArgs e)
            {
                DataGrid dg = (DataGrid)sender;
                if (dg.ReadOnly)
                {
                    if (dg.CurrentCell.ColumnNumber > -1 & dg.CurrentRowIndex > -1)
                    {
                        dg.CurrentCell = new DataGridCell(dg.CurrentRowIndex, -1);
                        dg.Select(dg.CurrentRowIndex);
                    }
                }
            }

            public static void RemoveEventHandlers(DataGrid dg)
            {
                dg.Click -= dGrid_Multievents;
                dg.CurrentCellChanged -= dGrid_Multievents;
            }

            // Set the style
            public static DataGridTableStyle DefaultTableStyle()
            {
                var DataGridTableStyle1 = new DataGridTableStyle();
                DataGridTableStyle1.AlternatingBackColor = Color.White;
                DataGridTableStyle1.BackColor = Color.White;
                DataGridTableStyle1.ForeColor = Color.Navy;
                DataGridTableStyle1.GridLineColor = Color.LightSteelBlue;
                DataGridTableStyle1.HeaderBackColor = Color.SteelBlue;
                DataGridTableStyle1.HeaderForeColor = Color.White;
                DataGridTableStyle1.LinkColor = Color.Navy;
                DataGridTableStyle1.MappingName = "";
                DataGridTableStyle1.ReadOnly = true;
                DataGridTableStyle1.RowHeadersVisible = false;
                DataGridTableStyle1.SelectionBackColor = Color.Gainsboro;
                DataGridTableStyle1.SelectionForeColor = Color.Navy;
                return DataGridTableStyle1;
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public static void SetUpDataGridView(DataGridView dgv, bool captionIsVisible = false)
            {
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.FixedSingle;
                dgv.Font = new Font("Verdana", 8.0F);
                dgv.ForeColor = Color.Navy;
                dgv.GridColor = Color.LightSteelBlue;
                dgv.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                dgv.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 8.0F, FontStyle.Bold);
                dgv.RowHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.RowHeadersVisible = true;
                dgv.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
                dgv.DefaultCellStyle.SelectionForeColor = Color.Navy;
                dgv.ReadOnly = false;
                dgv.Cursor = Cursors.Hand;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8.0F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.RowHeadersVisible = false;
                // AddHandler dgv.Click, AddressOf dGridView_Multievents
                // AddHandler dgv.CurrentCellChanged, AddressOf dGrid_Multievents
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public static void ClearGroupBox(GroupBox grp)
            {
                foreach (Control cntr in grp.Controls)
                {
                    if (cntr is TextBox)
                    {
                        ((TextBox)cntr).Text = "";
                    }
                    else if (cntr is ComboBox)
                    {
                        ComboBox argcombo = (ComboBox)cntr;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
                    }
                    else if (cntr is CheckBox)
                    {
                        ((CheckBox)cntr).Checked = false;
                    }
                    else if (cntr is NumericUpDown)
                    {
                        ((NumericUpDown)cntr).Value = 1;
                    }
                    else if (cntr is RadioButton)
                    {
                        ((RadioButton)cntr).Checked = false;
                    }
                    else if (cntr is DateTimePicker)
                    {
                        ((DateTimePicker)cntr).Value = DateAndTime.Today.Date;
                    }
                }
            }

            public static void ClearTabControl(TabControl tabcontrol)
            {
                foreach (TabPage page in tabcontrol.TabPages)
                {
                    foreach (Control ctrl in page.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            ((TextBox)ctrl).Text = "";
                        }
                        else if (ctrl is ComboBox)
                        {
                            ComboBox argcombo = (ComboBox)ctrl;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
                        }
                        else if (ctrl is CheckBox)
                        {
                            ((CheckBox)ctrl).Checked = false;
                        }
                        else if (ctrl is NumericUpDown)
                        {
                            ((NumericUpDown)ctrl).Value = 1;
                        }
                        else if (ctrl is RadioButton)
                        {
                            ((RadioButton)ctrl).Checked = false;
                        }
                        else if (ctrl is DateTimePicker)
                        {
                            ((DateTimePicker)ctrl).Value = DateAndTime.Today.Date;
                        }
                    }
                }
            }

            public static void MakeReadOnly(GroupBox grp, bool readOnlyState)
            {
                foreach (Control cntr in grp.Controls)
                {
                    if (cntr is TextBox)
                    {
                        ((TextBox)cntr).ReadOnly = readOnlyState;
                    }
                    else if (cntr is ComboBox)
                    {
                        ((ComboBox)cntr).Enabled = !readOnlyState;
                    }
                    else if (cntr is CheckBox)
                    {
                        ((CheckBox)cntr).Enabled = !readOnlyState;
                    }
                    else if (cntr is Button)
                    {
                        ((Button)cntr).Enabled = !readOnlyState;
                    }
                    else if (cntr is TabControl)
                    {
                        ((TabControl)cntr).Enabled = !readOnlyState;
                    }
                    else if (cntr is CheckedListBox)
                    {
                        ((CheckedListBox)cntr).Enabled = !readOnlyState;
                    }
                    else if (cntr is DateTimePicker)
                    {
                        ((DateTimePicker)cntr).Enabled = !readOnlyState;
                    }
                    else if (cntr is DataGrid)
                    {
                        ((DataGrid)cntr).Enabled = !readOnlyState;
                    }
                }
            }

            public static void Setup_Button(ref Button btn, string caption)
            {
                btn.FlatStyle = FlatStyle.Standard;
                btn.ImageList = null;
                btn.ImageIndex = default;
                btn.Cursor = Cursors.Hand;
                var hoverToolTip = new ToolTip();
                hoverToolTip.SetToolTip(btn, caption);
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public static string HashPassword(string password)
            {
                using (var hasher = MD5.Create())
                {
                    var dbytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
                    var sBuilder = new StringBuilder();
                    for (int n = 0, loopTo = dbytes.Length - 1; n <= loopTo; n++)
                        sBuilder.Append(dbytes[n].ToString("X2"));
                    return sBuilder.ToString();
                }
            }

            public static string GetTextResource(string FileName)
            {
                var assem = Assembly.GetExecutingAssembly();
                var resStream = assem.GetManifestResourceStream(App.TheSystem.Product + "." + FileName);
                var reader = new StreamReader(resStream);
                string returnText = reader.ReadToEnd();
                resStream.Close();
                return returnText.Trim();
            }

            public static Stream GetStream(string FileName)
            {
                var assem = Assembly.GetExecutingAssembly();
                string[] resources = assem.GetManifestResourceNames();
                string file = resources.Where(x => x.Contains(FileName)).FirstOrDefault();
                return assem.GetManifestResourceStream(file);
            }

            // Start any process on the client machine by filename
            public static void StartProcess(string filename)
            {
                Cursor.Current = Cursors.WaitCursor;
                Process.Start(filename);
                Cursor.Current = Cursors.Default;
            }

            public static int CalculateDays(DateTime d1, DateTime d2)
            {
                return Conversions.ToInteger((d2.Date - d1.Date).TotalDays);
            }

            public static double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(DegToRad(lat1)) * Math.Sin(DegToRad(lat2)) + Math.Cos(DegToRad(lat1)) * Math.Cos(DegToRad(lat2)) * Math.Cos(DegToRad(theta));
                dist = Math.Acos(dist);
                dist = RadToDeg(dist);
                dist = dist * 60 * 1.1515;
                if (Conversions.ToString(unit) == "K")
                {
                    dist = dist * 1.609344;
                }
                else if (Conversions.ToString(unit) == "N")
                {
                    dist = dist * 0.8684;
                }

                return dist;
            }

            public static double DegToRad(double deg)
            {
                return deg * Math.PI / 180.0;
            }

            public static double RadToDeg(double rad)
            {
                return rad / Math.PI * 180.0;
            }

            private static string GenerateRandomPassword(int length)
            {
                string _chars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ[_!23456790";
                var randomBytes = new byte[length + 1];
                var rng = new RNGCryptoServiceProvider();
                rng.GetBytes(randomBytes);
                var chars = new char[length + 1];
                int count = _chars.Length;
                for (int i = 0, loopTo = length - 1; i <= loopTo; i++)
                    chars[i] = _chars[Conversions.ToInteger(randomBytes[i]) % count];
                return new string(chars);
            }

            public static string CreateRandomPassword(int length)
            {
                string pass = string.Empty;
                while (true)
                {
                    pass = GenerateRandomPassword(length);
                    int upper = 0;
                    int num = 0;
                    int special = 0;
                    int lower = 0;
                    foreach (char c in pass)
                    {
                        if (c > 'A' && c < 'Z')
                        {
                            upper += 1;
                        }
                        else if (c > 'a' && c < 'z')
                        {
                            lower += 1;
                        }
                        else if (c > '0' && c < '9')
                        {
                            num += 1;
                        }
                        else
                        {
                            special += 1;
                        }
                    }

                    if (upper >= 2 && num >= 1 && 1 >= special)
                    {
                        break;
                    }
                }

                return pass;
            }

            public static Color ContrastColor(Color color)
            {
                double luma = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
                return luma > 0.5 ? Color.Black : Color.White;
            }

            public static DataRow GetDataRowFromDataSource(object dataSource, int rowIndex)
            {
                return (dataSource as DataView)?.Table?.Rows[rowIndex]
                    ?? (dataSource as DataTable)?.Rows[rowIndex]
                    ?? throw new Exception("Unable to cast datasource");
            }
        }
    }
}