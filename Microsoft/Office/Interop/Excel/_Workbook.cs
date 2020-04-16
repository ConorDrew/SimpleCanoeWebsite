// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Excel._Workbook
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
  [CompilerGenerated]
  [Guid("000208DA-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface _Workbook
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_20();

    [LCIDConversion(3)]
    [DispId(277)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Close([MarshalAs(UnmanagedType.Struct), In, Optional] object SaveChanges, [MarshalAs(UnmanagedType.Struct), In, Optional] object Filename, [MarshalAs(UnmanagedType.Struct), In, Optional] object RouteWorkbook);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_87();

    [DispId(493)]
    Styles Styles { [DispId(493), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap3_15();

    [DispId(494)]
    Sheets Worksheets { [DispId(494), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap4_40();

    [DispId(1925)]
    [LCIDConversion(12)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SaveAs(
      [MarshalAs(UnmanagedType.Struct), In, Optional] object Filename,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object FileFormat,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object Password,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object WriteResPassword,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object ReadOnlyRecommended,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object CreateBackup,
      [In] XlSaveAsAccessMode AccessMode = XlSaveAsAccessMode.xlNoChange,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object ConflictResolution,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object AddToMru,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object TextCodepage,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object TextVisualLayout,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object Local);
  }
}
