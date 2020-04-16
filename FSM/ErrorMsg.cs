// Decompiled with JetBrains decompiler
// Type: FSM.ErrorMsg
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

namespace FSM
{
  public class ErrorMsg
  {
    public const string ERROR_MSG_CAPTION = "Error";

    public static string InputExceedsMaxCharsAllowed(string fieldName, short maxChars)
    {
      return string.Format("*{0} exceeds maximum length of {1} characters.", (object) fieldName, (object) maxChars);
    }

    public static string Message(string _message)
    {
      return string.Format("*{0}.", (object) _message);
    }

    public static string AddSeperator()
    {
      return "****************************************************";
    }

    public static string FieldRequired(string fieldName)
    {
      return string.Format("*{0} is required.", (object) fieldName);
    }

    public static string NotNumeric(string fieldName)
    {
      return string.Format("*{0} is required to be numeric.", (object) fieldName);
    }

    public static string InvalidFormat(string fieldName, string requiredformat)
    {
      return string.Format("*{0} must be in the following format: {1}", (object) fieldName, (object) requiredformat);
    }

    public static string LoginIncorrect()
    {
      return string.Format("*User Details are incorrect.");
    }

    public static string AlreadyExists(string fieldName)
    {
      return string.Format("*{0} already exists.", (object) fieldName);
    }

    public static string ErrorOccured(string msg)
    {
      return string.Format("The system encountered an error, please contact support informing them of the following error: \r\n{0}", (object) msg);
    }

    public static string FieldMinimumLengthNotAchieved(string fieldName, int minimumLength)
    {
      return minimumLength > 1 ? string.Format("*{0} must be at least {1} characters in length.", (object) fieldName, (object) minimumLength) : string.Format("*{0} must be at least {1} characters in length.", (object) fieldName, (object) minimumLength);
    }

    public static string FieldNotWithinRange(string fieldName, string value1, string value2)
    {
      return string.Format("*{0} must be between {1} and {2}", (object) fieldName, (object) value1, (object) value2);
    }

    public static string FieldsDoNotMatch(string fieldName1, string fieldname2)
    {
      return string.Format("*{0} does not match {1}", (object) fieldName1, (object) fieldname2);
    }

    public static string NegativeNumber(string fieldName1)
    {
      return string.Format("*{0} cannot be a negative number.", (object) fieldName1);
    }
  }
}
