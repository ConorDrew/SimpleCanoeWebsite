// Decompiled with JetBrains decompiler
// Type: FSM.VersionChecker
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FSM
{
  [StandardModule]
  public sealed class VersionChecker
  {
    public static void Unlock()
    {
      try
      {
        if (VersionChecker.AlreadyRunning())
          App.DB.Job.UnlockTimed(App.loggedInUser.UserID);
        else
          App.DB.Job.UnlockAll(App.loggedInUser.UserID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private static void DifferentVersionsMessage(
      string AssemblyVesion,
      string LatestVersion,
      string LatestVersionReleased,
      string MessageIn)
    {
      int num = (int) App.ShowMessage("WARNING!\r\n\r\nAssembly version checking has discovered a version inconsistency.\r\n\r\nThis program's assembly version is: " + AssemblyVesion + "\r\nThe database reports the latest version is: " + LatestVersion + " (Released: " + LatestVersionReleased + ")\r\n\r\n" + MessageIn, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private static void NotSetupMessage(string MessageIn)
    {
      int num = (int) App.ShowMessage(MessageIn, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    private static bool AlreadyRunning()
    {
      Process currentProcess = Process.GetCurrentProcess();
      Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
      if (processesByName.Length == 1)
        return false;
      int num = checked (processesByName.Length - 1);
      int index = 0;
      while (index <= num)
      {
        if (DateTime.Compare(processesByName[index].StartTime, currentProcess.StartTime) < 0)
          return true;
        checked { ++index; }
      }
      return false;
    }
  }
}
