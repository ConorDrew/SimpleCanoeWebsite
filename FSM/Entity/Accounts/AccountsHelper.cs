// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Accounts.AccountsHelper
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;

namespace FSM.Entity.Accounts
{
    public class AccountsHelper
    {
        public static string FormatSunDepartment(string department)
        {
            return true == App.IsGasway ? Helper.MakeIntegerValid((object)department).ToString("000") : Helper.MakeStringValid((object)department);
        }

        public static string GetAccountPeriod(DateTime dt)
        {
            int month = dt.Month;
            string str = string.Empty;
            switch (month)
            {
                case 1:
                    str = Conversions.ToString(dt.Year) + "/10";
                    break;

                case 2:
                    str = Conversions.ToString(dt.Year) + "/11";
                    break;

                case 3:
                    str = Conversions.ToString(dt.Year) + "/12";
                    break;

                case 4:
                    str = Conversions.ToString(dt.AddYears(1).Year) + "/01";
                    break;

                case 5:
                    str = Conversions.ToString(dt.AddYears(1).Year) + "/02";
                    break;

                case 6:
                    str = Conversions.ToString(dt.AddYears(1).Year) + "/03";
                    break;

                case 7:
                    str = Conversions.ToString(dt.AddYears(1).Year) + "/04";
                    break;

                case 8:
                    str = Conversions.ToString(dt.AddYears(1).Year) + "/05";
                    break;

                case 9:
                    str = Conversions.ToString(dt.AddYears(1).Year) + "/06";
                    break;

                case 10:
                    str = Conversions.ToString(dt.AddYears(1).Year) + "/07";
                    break;

                case 11:
                    str = Conversions.ToString(dt.AddYears(1).Year) + "/08";
                    break;

                case 12:
                    str = Conversions.ToString(dt.AddYears(1).Year) + "/09";
                    break;
            }
            return str;
        }
    }
}