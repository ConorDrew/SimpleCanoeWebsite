using Microsoft.VisualBasic;

namespace FSM
{
    public class ErrorMsg
    {
        public const string ERROR_MSG_CAPTION = "Error";

        public static string InputExceedsMaxCharsAllowed(string fieldName, short maxChars)
        {
            return string.Format("*{0} exceeds maximum length of {1} characters.", fieldName, maxChars);
        }

        public static string Message(string _message)
        {
            return string.Format("*{0}.", _message);
        }

        public static string AddSeperator()
        {
            return "****************************************************";
        }

        public static string FieldRequired(string fieldName)
        {
            return string.Format("*{0} is required.", fieldName);
        }

        public static string NotNumeric(string fieldName)
        {
            return string.Format("*{0} is required to be numeric.", fieldName);
        }

        public static string InvalidFormat(string fieldName, string requiredformat)
        {
            return string.Format("*{0} must be in the following format: {1}", fieldName, requiredformat);
        }

        public static string LoginIncorrect()
        {
            return string.Format("*User Details are incorrect.");
        }

        public static string AlreadyExists(string fieldName)
        {
            return string.Format("*{0} already exists.", fieldName);
        }

        public static string ErrorOccured(string msg)
        {
            return string.Format("The system encountered an error, please contact support informing them of the following error: " + Constants.vbCrLf + "{0}", msg);
        }

        public static string FieldMinimumLengthNotAchieved(string fieldName, int minimumLength)
        {
            if (minimumLength > 1)
            {
                return string.Format("*{0} must be at least {1} characters in length.", fieldName, minimumLength);
            }
            else
            {
                return string.Format("*{0} must be at least {1} characters in length.", fieldName, minimumLength);
            }
        }

        public static string FieldNotWithinRange(string fieldName, string value1, string value2)
        {
            return string.Format("*{0} must be between {1} and {2}", fieldName, value1, value2);
        }

        public static string FieldsDoNotMatch(string fieldName1, string fieldname2)
        {
            return string.Format("*{0} does not match {1}", fieldName1, fieldname2);
        }

        public static string NegativeNumber(string fieldName1)
        {
            return string.Format("*{0} cannot be a negative number.", fieldName1);
        }
    }
}