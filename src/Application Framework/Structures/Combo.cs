using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Windows.Forms;

namespace FSM
{
    public class Combo
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string _description = "";

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        private string _value = "";

        public string Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        private object _additionalItem = null;

        public object AdditionalItem
        {
            get
            {
                return _additionalItem;
            }

            set
            {
                _additionalItem = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public Combo(string descriptionIn, string valueIn, object additionalItemIn = null)
        {
            Description = descriptionIn;
            Value = valueIn;
            AdditionalItem = additionalItemIn;
        }

        public static void SetSelectedComboItem_By_Value(ref ComboBox combo, string value)
        {
            int index = 0;
            foreach (Combo item in combo.Items)
            {
                if ((item.Value ?? "") == (value ?? ""))
                {
                    combo.SelectedIndex = index;
                    return;
                }

                index += 1;
            }
        }

        public static void SetSelectedComboItem_By_Description(ref ComboBox combo, string description)
        {
            int index = 0;
            foreach (Combo item in combo.Items)
            {
                if ((item.Description ?? "") == (description ?? ""))
                {
                    combo.SelectedIndex = index;
                    return;
                }

                index += 1;
            }
        }

        public static string get_GetSelectedItemValue(ComboBox comboIn)
        {
            if (comboIn.Items.Count > 0)
            {
                return ((Combo)comboIn.SelectedItem).Value;
            }
            else
            {
                return 0.ToString();
            }
        }

        public static string get_GetSelectedItemDescription(ComboBox comboIn)
        {
            try
            {
                if (get_IsAnInitialItem(comboIn))
                {
                    return "";
                }
                else
                {
                    return ((Combo)comboIn.SelectedItem).Description;
                }
            }
            catch
            {
                return "";
            }
        }

        private static bool get_IsAnInitialItem(ComboBox comboIn)
        {
            try
            {
                if (((Combo)comboIn.SelectedItem).Description.ToLower().StartsWith("-- Please Select --".ToLower()))
                {
                    return true;
                }
                else if (((Combo)comboIn.SelectedItem).Description.ToLower().StartsWith("-- Add New --".ToLower()))
                {
                    return true;
                }
                else if (((Combo)comboIn.SelectedItem).Description.ToLower().StartsWith("-- Other --".ToLower()))
                {
                    return true;
                }
                else if (((Combo)comboIn.SelectedItem).Description.ToLower().StartsWith("-- No Filter --".ToLower()))
                {
                    return true;
                }
                else if (((Combo)comboIn.SelectedItem).Description.ToLower().StartsWith("-- Off The Road --".ToLower()))
                {
                    return true;
                }
                else if (((Combo)comboIn.SelectedItem).Description.ToLower().StartsWith("-- Not Applicable --".ToLower()))
                {
                    return true;
                }
                else if (((Combo)comboIn.SelectedItem).Description.ToLower().StartsWith("--".ToLower()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        // Set the format and data
        public static void SetUpCombo(ref ComboBox c, DataTable DT, string ValueMember, string DisplayMember, Entity.Sys.Enums.ComboValues InitialItemText = Entity.Sys.Enums.ComboValues.None)
        {
            c.Items.Clear();
            if (InitialItemText != Entity.Sys.Enums.ComboValues.None)
            {
                switch (InitialItemText)
                {
                    case Entity.Sys.Enums.ComboValues.Please_Select:
                        {
                            c.Items.Add(new Combo("-- Please Select --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Please_Select_Negative:
                        {
                            c.Items.Add(new Combo("-- Please Select --", (-1).ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Add_New:
                        {
                            c.Items.Add(new Combo("-- Add New --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Other:
                        {
                            c.Items.Add(new Combo("-- Other --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.No_Filter:
                        {
                            c.Items.Add(new Combo("-- No Filter --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Off_The_Road:
                        {
                            c.Items.Add(new Combo("-- Off The Road --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Not_Applicable:
                        {
                            c.Items.Add(new Combo("-- Not Applicable --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Dashes:
                        {
                            c.Items.Add(new Combo("--", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.All_Appointments:
                        {
                            c.Items.Add(new Combo("-- All Appointments --", 0.ToString()));
                            break;
                        }
                }
            }

            if (DT is object)
            {
                foreach (DataRow DataRow in DT.Rows)
                    c.Items.Add(new Combo(SetComboDeletedPostfix(DataRow, DisplayMember), Conversions.ToString(DataRow[ValueMember])));
            }

            c.DisplayMember = "Description";
            c.ValueMember = "Value";
            switch (InitialItemText)
            {
                case Entity.Sys.Enums.ComboValues.Please_Select_Negative:
                    {
                        SetSelectedComboItem_By_Value(ref c, "-1");
                        break;
                    }

                default:
                    {
                        SetSelectedComboItem_By_Value(ref c, "0");
                        break;
                    }
            }
        }

        public static void SetUpComboQual(ref ComboBox c, DataTable DT, string ValueMember, string DisplayMember, Entity.Sys.Enums.ComboValues InitialItemText = Entity.Sys.Enums.ComboValues.None)
        {
            c.Items.Clear();
            if (InitialItemText != Entity.Sys.Enums.ComboValues.None)
            {
                switch (InitialItemText)
                {
                    case Entity.Sys.Enums.ComboValues.Please_Select:
                        {
                            c.Items.Add(new Combo("-- Please Select --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Add_New:
                        {
                            c.Items.Add(new Combo("-- Add New --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Other:
                        {
                            c.Items.Add(new Combo("-- Other --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.No_Filter:
                        {
                            c.Items.Add(new Combo("-- No Filter --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Off_The_Road:
                        {
                            c.Items.Add(new Combo("-- Off The Road --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Not_Applicable:
                        {
                            c.Items.Add(new Combo("-- Not Applicable --", 0.ToString()));
                            break;
                        }

                    case Entity.Sys.Enums.ComboValues.Dashes:
                        {
                            c.Items.Add(new Combo("--", 0.ToString()));
                            break;
                        }
                }
            }

            if (DT is object)
            {
                foreach (DataRow DataRow in DT.Rows)
                    c.Items.Add(new Combo(DataRow["Description"] + " * " + SetComboDeletedPostfix(DataRow, DisplayMember), Conversions.ToString(DataRow[ValueMember])));
            }

            c.DisplayMember = "Description";
            c.ValueMember = "Value";
            SetSelectedComboItem_By_Value(ref c, "0");
        }

        // Place a prefix on the item to indicate the fact that it is a deleted record
        private static string SetComboDeletedPostfix(DataRow DR, string DisplayMember)
        {
            if (DR.Table.Columns.Contains("Deleted") && Helper.MakeBooleanValid(DR["Deleted"]))
            {
                return Conversions.ToString(DR[DisplayMember] + App.TheSystem.DeletedPostfix);
            }
            else
            {
                return Conversions.ToString(DR[DisplayMember]);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}