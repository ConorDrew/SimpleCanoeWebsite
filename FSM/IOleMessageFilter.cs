// Decompiled with JetBrains decompiler
// Type: FSM.IOleMessageFilter
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FSM
{
  [Guid("00000016-0000-0000-C000-000000000046")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  internal interface IOleMessageFilter
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    int HandleInComingCall(
      int dwCallType,
      IntPtr hTaskCaller,
      int dwTickCount,
      IntPtr lpInterfaceInfo);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType);
  }
}
