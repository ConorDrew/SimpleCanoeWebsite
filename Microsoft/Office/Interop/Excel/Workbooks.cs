// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Excel.Workbooks
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
  [CompilerGenerated]
  [Guid("000208DB-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface Workbooks : IEnumerable
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_3();

    [DispId(181)]
    [LCIDConversion(1)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Workbook Add([MarshalAs(UnmanagedType.Struct), In, Optional] object Template);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_2();

    [DispId(170)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Workbook get_Item([MarshalAs(UnmanagedType.Struct), In] object Index);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap3_3();

    [DispId(0)]
    [IndexerName("_Default")]
    Workbook this[[MarshalAs(UnmanagedType.Struct), In] object Index] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }
  }
}
