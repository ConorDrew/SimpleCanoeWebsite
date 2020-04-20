// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.Helper
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
    public class Helper
    {
        public static string MakeStringValid(object o)
        {
            string str;
            try
            {
                str = o != null ? (o != DBNull.Value ? ((object)o.GetType() != (object)typeof(string) || !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(o, (object)"vbcrlf", false) ? ((object)o.GetType() != (object)typeof(string) || !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(o, (object)"&nbsp;", false) ? Conversions.ToString(o).Trim() : "") : "") : "") : "";
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                str = "";
                ProjectData.ClearProjectError();
            }
            return str;
        }

        public static int MakeIntegerValid(object o)
        {
            int num;
            try
            {
                if (o == null)
                    num = 0;
                else if (o == DBNull.Value)
                    num = 0;
                else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(o), "", false) == 0)
                {
                    num = 0;
                }
                else
                {
                    try
                    {
                        num = Conversions.ToInteger(o);
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        num = 0;
                        ProjectData.ClearProjectError();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                num = 0;
                ProjectData.ClearProjectError();
            }
            return num;
        }

        public static bool IsValidInteger(object o)
        {
            string String1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(o));
            return Versioned.IsNumeric((object)String1) && Microsoft.VisualBasic.Strings.InStr(String1, ".", CompareMethod.Binary) == 0;
        }

        public static double MakeDoubleValid(object o)
        {
            double num;
            try
            {
                if (o == null)
                    num = 0.0;
                else if (o == DBNull.Value)
                    num = 0.0;
                else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(o), "", false) == 0)
                    num = 0.0;
                else if (double.IsNaN(Conversions.ToDouble(o)))
                {
                    num = 0.0;
                }
                else
                {
                    try
                    {
                        num = Conversions.ToDouble(o);
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        num = 0.0;
                        ProjectData.ClearProjectError();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                num = 0.0;
                ProjectData.ClearProjectError();
            }
            return num;
        }

        public static double RoundDown(double number, int decimalPlaces)
        {
            return Math.Floor(number * Math.Pow(10.0, (double)decimalPlaces)) / Math.Pow(10.0, (double)decimalPlaces);
        }

        public static bool MakeBooleanValid(object o)
        {
            bool flag = false;
            try
            {
                switch (App.TheSystem.DataBaseServerType)
                {
                    case Enums.DatabaseSystems.MySQL:
                        flag = o != DBNull.Value && Conversions.ToBoolean(Conversions.ToSByte(o).ToString());
                        break;

                    case Enums.DatabaseSystems.Microsoft_SQL_Server:
                        flag = o != null && (o != DBNull.Value && Conversions.ToBoolean(o));
                        break;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        public static DateTime MakeDateTimeValid(object o)
        {
            DateTime dateTime;
            try
            {
                dateTime = o != null ? (o != DBNull.Value ? Conversions.ToDate(Helper.FormatDateTime_Load(Conversions.ToDate(o))) : DateTime.MinValue) : DateTime.MinValue;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                dateTime = DateTime.MinValue;
                ProjectData.ClearProjectError();
            }
            return dateTime;
        }

        public static DateTime? MakeNullableDateTimeValid(object o)
        {
            return o != null ? (o != DBNull.Value ? new DateTime?(Conversions.ToDate(Helper.FormatDateTime_Load(Conversions.ToDate(o)))) : new DateTime?()) : new DateTime?();
        }

        public static TimeSpan MakeTimeValid(object o)
        {
            TimeSpan timeSpan;
            if (o == null)
                timeSpan = new TimeSpan();
            else if (o == DBNull.Value)
                timeSpan = new TimeSpan();
            else if ((object)o.GetType() != (object)typeof(TimeSpan))
            {
                timeSpan = new TimeSpan();
            }
            else
            {
                object obj = o;
                timeSpan = obj != null ? (TimeSpan)obj : new TimeSpan();
            }
            return timeSpan;
        }

        public static TimeSpan FormatTime(string o)
        {
            return TimeSpan.Parse(Microsoft.VisualBasic.Strings.Format((object)o, "HH:mm:ss"));
        }

        public static string FormatDateTime_Load(DateTime DateTime)
        {
            return Microsoft.VisualBasic.Strings.Format((object)DateTime, "dd/MMM/yyyy HH:mm:ss");
        }

        public static string CleanText(string text)
        {
            return text.Replace("\r\n", " ").Replace("'", "''").Replace("\"", "\"\"").Replace("[", "[[").Replace("]", "]]").Trim();
        }

        public static string RemoveSpecialCharacters(string text)
        {
            return Regex.Replace(Helper.MakeStringValid((object)text), "[^A-Za-z0-9\\-\\s/]", "");
        }

        public static string ToTitleCase(string text)
        {
            text = new CultureInfo("en-US", false).TextInfo.ToTitleCase(text.ToLower());
            return text;
        }

        //public static DataTable ToDataTable<T>(IList<T> list)
        //{
        //    DataTable dataTable = new DataTable();
        //    if (list == null || !list.Any<T>())
        //        return dataTable;
        //    PropertyInfo[] properties = list.First<T>().GetType().GetProperties();
        //    PropertyInfo[] propertyInfoArray1 = properties;
        //    int index1 = 0;
        //    while (index1 < propertyInfoArray1.Length)
        //    {
        //        PropertyInfo propertyInfo = propertyInfoArray1[index1];
        //        dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
        //        checked { ++index1; }
        //    }
        //    try
        //    {
        //        foreach (T obj1 in (IEnumerable<T>)list)
        //        {
        //            T obj2 = obj1;
        //            DataRow row = dataTable.NewRow();
        //            PropertyInfo[] propertyInfoArray2 = properties;
        //            int index2 = 0;
        //            while (index2 < propertyInfoArray2.Length)
        //            {
        //                PropertyInfo propertyInfo = propertyInfoArray2[index2];
        //                object property = (object)obj2.GetType().GetProperty(propertyInfo.Name);
        //                DataRow dataRow = row;
        //                string name = propertyInfo.Name;
        //                object[] objArray;
        //                bool[] flagArray;
        //                object obj3 = NewLateBinding.LateGet(property, (System.Type)null, "GetValue", objArray = new object[2]
        //                {
        //      (object) obj2,
        //      null
        //                }, (string[])null, (System.Type[])null, flagArray = new bool[2]
        //                {
        //      true,
        //      false
        //                });
        //                if (flagArray[0])
        //                    obj2 = (T)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof(T));
        //                object objectValue = RuntimeHelpers.GetObjectValue(obj3);
        //                dataRow[name] = objectValue;
        //                checked { ++index2; }
        //            }
        //            dataTable.Rows.Add(row);
        //        }
        //    }
        //    finally
        //    {
        //        IEnumerator<T> enumerator;
        //        enumerator?.Dispose();
        //    }
        //    return dataTable;
        //}

        public static DataTable ToDataTable<T>(IList<T> list)
        {
            // declare new datatable
            DataTable dt = new DataTable();

            // if the list is empty then we return a blank table
            if (list == null || !list.Any())
                return dt;
            // get all the class properties
            PropertyInfo[] fields = list.First().GetType().GetProperties();
            // use the class properties as column name
            foreach (PropertyInfo field in fields)
                dt.Columns.Add(field.Name, field.PropertyType);
            // populate datatable with values
            foreach (T item in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo field in fields)
                {
                    object p = item.GetType().GetProperty(field.Name).GetValue(item, null);
                    row[field.Name] = p;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static bool ValidatePhoneNumber(string number)
        {
            return Regex.Match(number, "^(\\+44\\s?7\\d{3}|\\(?07\\d{3}\\)?)\\s?\\d{3}\\s?\\d{3}$", RegexOptions.IgnoreCase).Success;
        }

        public static string FormatPostcode(object postcode)
        {
            string str = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(postcode));
            if (str.Length < 3)
                return str;
            string upper = str.Replace("-", "").ToUpper();
            return upper.Insert(checked(upper.Length - 3), " ");
        }

        public static string ConvertToPostcode(object postcode)
        {
            string str = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(postcode)).Trim();
            if (str.Length < 3)
                return str;
            string upper = str.Replace(" ", "").ToUpper();
            return upper.Insert(checked(upper.Length - 3), "-");
        }

        public static bool IsEmailValid(string email)
        {
            bool flag;
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                flag = true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        public static string MakeFileNameValid(string fileName)
        {
            char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
            int index = 0;
            while (index < invalidFileNameChars.Length)
            {
                char ch = invalidFileNameChars[index];
                fileName = fileName.Replace(Conversions.ToString(ch), "_");
                checked { ++index; }
            }
            return fileName;
        }

        public static int GetNumber(object value)
        {
            value = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(value));
            string empty = string.Empty;
            char[] charArrayRankOne = Conversions.ToCharArrayRankOne(NewLateBinding.LateGet(value, (System.Type)null, "ToCharArray", new object[0], (string[])null, (System.Type[])null, (bool[])null));
            int index = 0;
            while (index < charArrayRankOne.Length)
            {
                char c = charArrayRankOne[index];
                if (char.IsDigit(c))
                    empty += Conversions.ToString(c);
                checked { ++index; }
            }
            return Convert.ToInt32(empty);
        }

        public static object InsertDateIntoDb(DateTime date)
        {
            return DateTime.Compare(date, DateTime.MinValue) == 0 || DateTime.Compare(date, DateTime.MinValue) == 0 ? (object)DBNull.Value : (object)date;
        }

        public static bool IsStringEmpty(object value)
        {
            value = (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(value));
            return string.IsNullOrEmpty(Conversions.ToString(value)) | string.IsNullOrWhiteSpace(Conversions.ToString(value));
        }

        public static void SetUpDataGrid(DataGrid dg, bool captionIsVisible = false)
        {
            dg.TableStyles.Clear();
            dg.TableStyles.Add(Helper.DefaultTableStyle());
            dg.AllowNavigation = false;
            dg.CaptionVisible = captionIsVisible;
            dg.AlternatingBackColor = Color.White;
            dg.BackgroundColor = Color.White;
            dg.BorderStyle = BorderStyle.FixedSingle;
            dg.CaptionBackColor = Color.SteelBlue;
            dg.CaptionForeColor = Color.White;
            dg.Font = new Font("Verdana", 8f);
            dg.ForeColor = Color.Navy;
            dg.GridLineColor = Color.LightSteelBlue;
            dg.HeaderBackColor = Color.SteelBlue;
            dg.HeaderFont = new Font("Verdana", 8f, FontStyle.Bold);
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
            dg.Click += new EventHandler(Helper.dGrid_Multievents);
            dg.CurrentCellChanged += new EventHandler(Helper.dGrid_Multievents);
        }

        public static void dGrid_Multievents(object sender, EventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            if (!dataGrid.ReadOnly || !(dataGrid.CurrentCell.ColumnNumber > -1 & dataGrid.CurrentRowIndex > -1))
                return;
            dataGrid.CurrentCell = new DataGridCell(dataGrid.CurrentRowIndex, -1);
            dataGrid.Select(dataGrid.CurrentRowIndex);
        }

        public static void RemoveEventHandlers(DataGrid dg)
        {
            dg.Click -= new EventHandler(Helper.dGrid_Multievents);
            dg.CurrentCellChanged -= new EventHandler(Helper.dGrid_Multievents);
        }

        public static DataGridTableStyle DefaultTableStyle()
        {
            return new DataGridTableStyle()
            {
                AlternatingBackColor = Color.White,
                BackColor = Color.White,
                ForeColor = Color.Navy,
                GridLineColor = Color.LightSteelBlue,
                HeaderBackColor = Color.SteelBlue,
                HeaderForeColor = Color.White,
                LinkColor = Color.Navy,
                MappingName = "",
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionBackColor = Color.Gainsboro,
                SelectionForeColor = Color.Navy
            };
        }

        public static void SetUpDataGridView(DataGridView dgv, bool captionIsVisible = false)
        {
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.Font = new Font("Verdana", 8f);
            dgv.ForeColor = Color.Navy;
            dgv.GridColor = Color.LightSteelBlue;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 8f, FontStyle.Bold);
            dgv.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersVisible = true;
            dgv.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Navy;
            dgv.ReadOnly = false;
            dgv.Cursor = Cursors.Hand;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersVisible = false;
        }

        public static void ClearGroupBox(GroupBox grp)
        {
            foreach (Control current in grp.Controls)
            {
                switch (current)
                {
                    case TextBox _:
                        ((TextBox)current).Text = "";
                        break;

                    case ComboBox _:
                        ComboBox combo = (ComboBox)current;
                        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(0));
                        break;

                    case CheckBox _:
                        ((CheckBox)current).Checked = false;
                        break;

                    case NumericUpDown _:
                        ((NumericUpDown)current).Value = Decimal.One;
                        break;

                    case RadioButton _:
                        ((RadioButton)current).Checked = false;
                        break;

                    case DateTimePicker _:
                        ((DateTimePicker)current).Value = DateAndTime.Today.Date;
                        break;
                }
            }
        }

        public static void ClearTabControl(TabControl tabcontrol)
        {
            foreach (TabPage current1 in tabcontrol.TabPages)
            {
                foreach (Control current2 in current1.Controls)
                {
                    switch (current2)
                    {
                        case TextBox _:
                            ((TextBox)current2).Text = "";
                            break;

                        case ComboBox _:
                            ComboBox combo = (ComboBox)current2;
                            Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(0));
                            break;

                        case CheckBox _:
                            ((CheckBox)current2).Checked = false;
                            break;

                        case NumericUpDown _:
                            ((NumericUpDown)current2).Value = Decimal.One;
                            break;

                        case RadioButton _:
                            ((RadioButton)current2).Checked = false;
                            break;

                        case DateTimePicker _:
                            ((DateTimePicker)current2).Value = DateAndTime.Today.Date;
                            break;
                    }
                }
            }
        }

        public static void MakeReadOnly(GroupBox grp, bool readOnlyState)
        {
            foreach (Control current in grp.Controls)
            {
                switch (current)
                {
                    case TextBox _:
                        ((TextBoxBase)current).ReadOnly = readOnlyState;
                        break;

                    case ComboBox _:
                        current.Enabled = !readOnlyState;
                        break;

                    case CheckBox _:
                        current.Enabled = !readOnlyState;
                        break;

                    case Button _:
                        current.Enabled = !readOnlyState;
                        break;

                    case TabControl _:
                        current.Enabled = !readOnlyState;
                        break;

                    case CheckedListBox _:
                        current.Enabled = !readOnlyState;
                        break;

                    case DateTimePicker _:
                        current.Enabled = !readOnlyState;
                        break;

                    case DataGrid _:
                        current.Enabled = !readOnlyState;
                        break;
                }
            }
        }

        public static void Setup_Button(ref Button btn, string caption)
        {
            btn.FlatStyle = FlatStyle.Standard;
            btn.ImageList = (ImageList)null;
            btn.ImageIndex = 0;
            btn.Cursor = Cursors.Hand;
            new ToolTip().SetToolTip((Control)btn, caption);
        }

        public static string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder stringBuilder = new StringBuilder();
                int num = checked(hash.Length - 1);
                int index = 0;
                while (index <= num)
                {
                    stringBuilder.Append(hash[index].ToString("X2"));
                    checked { ++index; }
                }
                return stringBuilder.ToString();
            }
        }

        public static string GetTextResource(string FileName)
        {
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(App.TheSystem.Product + "." + FileName);
            string end = new StreamReader(manifestResourceStream).ReadToEnd();
            manifestResourceStream.Close();
            return end.Trim();
        }

        public static Stream GetStream(string FileName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(App.TheSystem.Product + "." + FileName);
        }

        public static void StartProcess(string filename)
        {
            Cursor.Current = Cursors.WaitCursor;
            Process.Start(filename);
            Cursor.Current = Cursors.Default;
        }

        public static int CalculateDays(DateTime d1, DateTime d2)
        {
            return checked((int)Math.Round((d2.Date - d1.Date).TotalDays));
        }

        public static double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double deg = lon1 - lon2;
            double num = Helper.RadToDeg(Math.Acos(Math.Sin(Helper.DegToRad(lat1)) * Math.Sin(Helper.DegToRad(lat2)) + Math.Cos(Helper.DegToRad(lat1)) * Math.Cos(Helper.DegToRad(lat2)) * Math.Cos(Helper.DegToRad(deg)))) * 60.0 * 1.1515;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(unit), "K", false) == 0)
                num *= 1.609344;
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Conversions.ToString(unit), "N", false) == 0)
                num *= 0.8684;
            return num;
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
            string str = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ[_!23456790";
            byte[] data = new byte[checked(length + 1)];
            new RNGCryptoServiceProvider().GetBytes(data);
            char[] chArray = new char[checked(length + 1)];
            int length1 = str.Length;
            int num = checked(length - 1);
            int index = 0;
            while (index <= num)
            {
                chArray[index] = str[(int)data[index] % length1];
                checked { ++index; }
            }
            return new string(chArray);
        }

        public static string CreateRandomPassword(int length)
        {
            string empty = string.Empty;
            string randomPassword;
            int num1;
            int num2;
            int num3;
            do
            {
                randomPassword = Helper.GenerateRandomPassword(length);
                num1 = 0;
                num2 = 0;
                num3 = 0;
                int num4 = 0;
                string str = randomPassword;
                int index = 0;
                while (index < str.Length)
                {
                    char ch = str[index];
                    if (ch > 'A' && ch < 'Z')
                        checked { ++num1; }
                    else if (ch > 'a' && ch < 'z')
                        checked { ++num4; }
                    else if (ch > '0' && ch < '9')
                        checked { ++num2; }
                    else
                        checked { ++num3; }
                    checked { ++index; }
                }
            }
            while (num1 < 2 || num2 < 1 || 1 < num3);
            return randomPassword;
        }

        public static Color ContrastColor(Color color)
        {
            return (0.299 * (double)color.R + 0.587 * (double)color.G + 0.114 * (double)color.B) / (double)byte.MaxValue > 0.5 ? Color.Black : Color.White;
        }
    }
}