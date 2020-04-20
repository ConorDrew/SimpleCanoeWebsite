using System;

namespace FSM.Entity
{
    namespace Accounts
    {
        public class AccountsHelper
        {
            public static string FormatSunDepartment(string department)
            {
                switch (true)
                {
                    case object _ when App.IsGasway:
                        {
                            return Sys.Helper.MakeIntegerValid(department).ToString("000");
                        }

                    default:
                        {
                            return Sys.Helper.MakeStringValid(department);
                        }
                }
            }

            public static string GetAccountPeriod(DateTime dt)
            {
                int accMonth = dt.Month;
                string accPeriod = string.Empty;
                switch (accMonth)
                {
                    case 1: // Jan
                        {
                            accPeriod = dt.Year + "/" + "10";
                            break;
                        }

                    case 2: // Feb
                        {
                            accPeriod = dt.Year + "/" + "11";
                            break;
                        }

                    case 3: // Mar
                        {
                            accPeriod = dt.Year + "/" + "12";
                            break;
                        }

                    case 4: // Apr
                        {
                            accPeriod = dt.AddYears(1).Year + "/" + "01";
                            break;
                        }

                    case 5: // May
                        {
                            accPeriod = dt.AddYears(1).Year + "/" + "02";
                            break;
                        }

                    case 6: // Jun
                        {
                            accPeriod = dt.AddYears(1).Year + "/" + "03";
                            break;
                        }

                    case 7: // Jul
                        {
                            accPeriod = dt.AddYears(1).Year + "/" + "04";
                            break;
                        }

                    case 8: // Aug
                        {
                            accPeriod = dt.AddYears(1).Year + "/" + "05";
                            break;
                        }

                    case 9: // Sep
                        {
                            accPeriod = dt.AddYears(1).Year + "/" + "06";
                            break;
                        }

                    case 10: // Oct
                        {
                            accPeriod = dt.AddYears(1).Year + "/" + "07";
                            break;
                        }

                    case 11: // Nov
                        {
                            accPeriod = dt.AddYears(1).Year + "/" + "08";
                            break;
                        }

                    case 12: // Dec
                        {
                            accPeriod = dt.AddYears(1).Year + "/" + "09";
                            break;
                        }
                }

                return accPeriod;
            }
        }
    }
}