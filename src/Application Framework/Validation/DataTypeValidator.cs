using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM
{
    public class DataTypeValidator
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool _ignoreExceptionsOnSetMethods = false;

        public bool IgnoreExceptionsOnSetMethods
        {
            get
            {
                return _ignoreExceptionsOnSetMethods;
            }

            set
            {
                _ignoreExceptionsOnSetMethods = value;
            }
        }

        private Hashtable _errorTable;

        public Hashtable Errors
        {
            get
            {
                return _errorTable;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public DataTypeValidator()
        {
            _errorTable = new Hashtable();
        }

        public void SetValue(object sender, string variableName, object value)
        {
            if (value is null)
            {
                return;
            }

            var f = default(System.Reflection.FieldInfo);
            var propertyName = default(string);
            if (!(value.GetType().IsPrimitive | (value.GetType().FullName ?? "") == "System.String" | (value.GetType().FullName ?? "") == "System.DBNull" | (value.GetType().FullName ?? "") == "System.Decimal"))
            {
                throw new Exception("SetValue() can only be used with primitive & string types.");
            }

            try
            {
                // ################################## Begin changes by Henry ####################################
                // f = sender.GetType().GetField(variableName, _
                // System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic Or _
                // System.Reflection.BindingFlags.NonPublic)

                // #################################### Replaced with: ##########################################
                // Loop through the base clases of sender to find the property wanted
                var senderType = sender.GetType();
                while (f is null)
                {
                    f = senderType.GetField(variableName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.FlattenHierarchy);

                    // If a field wasn't found, try the base class if there is one
                    if (f is null && sender.GetType().BaseType is object)
                    {
                        senderType = senderType.BaseType;
                    }
                    else
                    {
                        break;
                    }
                }
                // ####################################### End replaced #########################################

                string strValue = "";
                propertyName = GetAssociatedSetPropertyName(variableName);
                bool setProperty = true;
                if ((value.GetType().FullName ?? "") == "System.DBNull")
                {
                    setProperty = false;
                }

                if (setProperty)
                {
                    var switchExpr = f.FieldType.FullName;
                    switch (switchExpr)
                    {
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Integer":
                        case "System.Decimal":
                        case "System.Double":
                            {
                                if (Conversions.ToString(value).Trim().Length == 0)
                                {
                                    // setProperty = False
                                    // Else
                                    // value = 0
                                    setProperty = true;
                                }

                                break;
                            }
                    }
                }

                // for a list of types:
                // ms-help://MS.VSCC.2003/MS.MSDNQTR.2003APR.1033/vblr7/html/vagrpDataType.htm

                if (setProperty)
                {
                    // ok, try and set the value of the variable
                    f.SetValue(sender, Convert.ChangeType(value, f.FieldType));
                }

                // remove error if a previous one exists
                RemoveError(propertyName);
            }
            catch (NullReferenceException nre)
            {
                // remove error if a previous one exists
                RemoveError(propertyName);
                string message = "Field name '{0}' could not be found in class '{1}'.";
                throw new NullReferenceException(string.Format(message, variableName, sender.GetType().Name));
            }
            catch (Exception ex)
            {
                // remove error if a previous one exists
                RemoveError(propertyName);

                // value could not be converted  to correct data type.
                string message = "*'{0}' could not be set because the input was not of type {1}.";
                message = string.Format(message, propertyName, f.FieldType.Name);
                if (IgnoreExceptionsOnSetMethods)
                {
                    AddError(propertyName, message);
                }
                else
                {
                    throw new Exception(message);
                }
            }
        }

        private string GetAssociatedSetPropertyName(string fieldName)
        {
            string propertyName = fieldName.Substring(fieldName.IndexOf("_") + 1);
            propertyName = char.ToUpper(propertyName[0]) + propertyName.Substring(1);
            return propertyName;
        }

        private void AddError(string propertyName, string errorMessage)
        {
            _errorTable.Add(propertyName, errorMessage);
        }

        private void RemoveError(string propertyName)
        {
            _errorTable.Remove(propertyName);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}