// Decompiled with JetBrains decompiler
// Type: FSM.MouseHandler
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.InteropServices;

namespace FSM
{
  public class MouseHandler : IDisposable
  {
    private static int hHook = 0;
    private int WH_MOUSE;
    private MouseHandler.CallBack hookproc;

    public event MouseHandler.mouseMovedEventHandler mouseMoved;

    public MouseHandler()
    {
      this.WH_MOUSE = 7;
      this.HookMouse();
    }

    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int SetWindowsHookEx(
      int idHook,
      MouseHandler.CallBack HookProc,
      IntPtr hInstance,
      int wParam);

    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool UnhookWindowsHookEx(int idHook);

    private void HookMouse()
    {
      this.hookproc = new MouseHandler.CallBack(this.MouseHookProc);
      MouseHandler.hHook = MouseHandler.SetWindowsHookEx(this.WH_MOUSE, this.hookproc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
    }

    public int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
      int num;
      try
      {
        MouseHandler.MouseHookStruct mouseHookStruct1 = new MouseHandler.MouseHookStruct();
        if (nCode < 0)
        {
          num = MouseHandler.CallNextHookEx(MouseHandler.hHook, nCode, wParam, lParam);
        }
        else
        {
          object structure = Marshal.PtrToStructure(lParam, mouseHookStruct1.GetType());
          MouseHandler.MouseHookStruct mouseHookStruct2 = structure != null ? (MouseHandler.MouseHookStruct) structure : new MouseHandler.MouseHookStruct();
          // ISSUE: reference to a compiler-generated field
          MouseHandler.mouseMovedEventHandler mouseMovedEvent = this.mouseMovedEvent;
          if (mouseMovedEvent != null)
            mouseMovedEvent(mouseHookStruct2.pt.x, mouseHookStruct2.pt.y);
          num = MouseHandler.CallNextHookEx(MouseHandler.hHook, nCode, wParam, lParam);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return num;
    }

    public void Dispose()
    {
      MouseHandler.UnhookWindowsHookEx(MouseHandler.hHook);
    }

    public delegate void mouseMovedEventHandler(int x, int y);

    public delegate int CallBack(int nCode, IntPtr wParam, IntPtr lParam);

    public struct Point
    {
      public int x;
      public int y;
    }

    public struct MouseHookStruct
    {
      public MouseHandler.Point pt;
      public int hwnd;
      public int wHitTestCode;
      public int dwExtraInfo;
    }
  }
}
