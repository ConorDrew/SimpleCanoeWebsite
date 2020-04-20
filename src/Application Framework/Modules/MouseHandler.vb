Imports System.Runtime.InteropServices

Public Class MouseHandler
    Implements System.IDisposable

    Public Event mouseMoved(ByVal x As Integer, ByVal y As Integer)

    Public Sub New()
        HookMouse()
    End Sub

#Region "Mouse Hook & API"

    Public Delegate Function CallBack( _
        ByVal nCode As Integer, _
        ByVal wParam As IntPtr, _
        ByVal lParam As IntPtr) As Integer

    Dim WH_MOUSE As Integer = 7
    Shared hHook As Integer = 0

    'Keep the reference so that the delegate is not garbage collected.
    Private hookproc As CallBack

    'Import for the SetWindowsHookEx function.
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
     Public Overloads Shared Function SetWindowsHookEx _
          (ByVal idHook As Integer, ByVal HookProc As CallBack, _
           ByVal hInstance As IntPtr, ByVal wParam As Integer) As Integer
    End Function

    'Import for the CallNextHookEx function.
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
     Public Overloads Shared Function CallNextHookEx _
          (ByVal idHook As Integer, ByVal nCode As Integer, _
           ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function
    'Import for the UnhookWindowsHookEx function.
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
         Public Overloads Shared Function UnhookWindowsHookEx _
              (ByVal idHook As Integer) As Boolean
    End Function


    'Point structure declaration.
    <StructLayout(LayoutKind.Sequential)> Public Structure Point
        Public x As Integer
        Public y As Integer
    End Structure

    'MouseHookStruct structure declaration.
    <StructLayout(LayoutKind.Sequential)> Public Structure MouseHookStruct
        Public pt As Point
        Public hwnd As Integer
        Public wHitTestCode As Integer
        Public dwExtraInfo As Integer
    End Structure


    Private Sub HookMouse()
        hookproc = AddressOf MouseHookProc
        hHook = SetWindowsHookEx(WH_MOUSE, _
                                 hookproc, _
                                 IntPtr.Zero, _
                                AppDomain.CurrentDomain.GetCurrentThreadId())

    End Sub

    Public Function MouseHookProc( _
      ByVal nCode As Integer, _
      ByVal wParam As IntPtr, _
      ByVal lParam As IntPtr) As Integer

        Try
            Dim MyMouseHookStruct As New MouseHookStruct

            Dim ret As Integer

            If (nCode < 0) Then
                Return CallNextHookEx(hHook, nCode, wParam, lParam)
            End If

            MyMouseHookStruct = CType(Marshal.PtrToStructure(lParam, MyMouseHookStruct.GetType()), MouseHookStruct)

            RaiseEvent mouseMoved(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y)

            Return CallNextHookEx(hHook, nCode, wParam, lParam)
        Catch

        End Try

    End Function


#End Region


    Public Sub Dispose() Implements System.IDisposable.Dispose
        Dim ret As Boolean = UnhookWindowsHookEx(hHook)
    End Sub
End Class
