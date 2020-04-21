using System;
using System.Runtime.InteropServices;

namespace FSM
{
    public class MouseHandler : IDisposable
    {
        public event mouseMovedEventHandler mouseMoved;

        public delegate void mouseMovedEventHandler(int x, int y);

        public MouseHandler()
        {
            HookMouse();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public delegate int CallBack(int nCode, IntPtr wParam, IntPtr lParam);

        private int WH_MOUSE = 7;
        private static int hHook = 0;

        // Keep the reference so that the delegate is not garbage collected.
        private CallBack hookproc;

        // Import for the SetWindowsHookEx function.
        [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, CallBack HookProc, IntPtr hInstance, int wParam);

        // Import for the CallNextHookEx function.
        [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        // Import for the UnhookWindowsHookEx function.
        [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        // Point structure declaration.
        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int x;
            public int y;
        }

        // MouseHookStruct structure declaration.
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseHookStruct
        {
            public Point pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        private void HookMouse()
        {
            hookproc = MouseHookProc;
            hHook = SetWindowsHookEx(WH_MOUSE, hookproc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
        }

        public int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)

        {
            try
            {
                var MyMouseHookStruct = new MouseHookStruct();
                int ret;
                if (nCode < 0)
                {
                    return CallNextHookEx(hHook, nCode, wParam, lParam);
                }

                MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, MyMouseHookStruct.GetType());
                mouseMoved?.Invoke(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y);
                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            catch
            {
            }

            return default;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        public void Dispose()
        {
            bool ret = UnhookWindowsHookEx(hHook);
        }
    }
}