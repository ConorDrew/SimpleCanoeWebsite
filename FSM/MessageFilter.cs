// Decompiled with JetBrains decompiler
// Type: FSM.MessageFilter
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Runtime.InteropServices;

namespace FSM
{
  internal class MessageFilter : IOleMessageFilter
  {
    public static void Register()
    {
      IOleMessageFilter newFilter = (IOleMessageFilter) new MessageFilter();
      IOleMessageFilter oldFilter = (IOleMessageFilter) null;
      MessageFilter.CoRegisterMessageFilter(newFilter, ref oldFilter);
    }

    public static void Revoke()
    {
      IOleMessageFilter oldFilter = (IOleMessageFilter) null;
      MessageFilter.CoRegisterMessageFilter((IOleMessageFilter) null, ref oldFilter);
    }

    int IOleMessageFilter.HandleInComingCall(
      int dwCallType,
      IntPtr hTaskCaller,
      int dwTickCount,
      IntPtr lpInterfaceInfo)
    {
      return 0;
    }

    int IOleMessageFilter.RetryRejectedCall(
      IntPtr hTaskCallee,
      int dwTickCount,
      int dwRejectType)
    {
      return dwRejectType == 2 ? 99 : -1;
    }

    int IOleMessageFilter.MessagePending(
      IntPtr hTaskCallee,
      int dwTickCount,
      int dwPendingType)
    {
      return 2;
    }

    [DllImport("Ole32.dll")]
    private static extern int CoRegisterMessageFilter(
      IOleMessageFilter newFilter,
      ref IOleMessageFilter oldFilter);
  }
}
