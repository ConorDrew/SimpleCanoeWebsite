using Microsoft.VisualBasic;

namespace FSM
{
    public class ErrorMsg
    {
        public const string ERROR_MSG_CAPTION = "Error";

        public static string FieldRequired(string fieldName)
        {
            return string.Format("*{0} is required.", fieldName);
        }

        public static string ErrorOccured(string msg)
        {
            return string.Format("The system encountered an error, please contact support informing them of the following error: " + Constants.vbCrLf + "{0}", msg);
        }

        public static string NegativeNumber(string fieldName1)
        {
            return string.Format("*{0} cannot be a negative number.", fieldName1);
        }
    }
}