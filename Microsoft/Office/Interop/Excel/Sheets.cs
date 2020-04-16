// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Excel.Sheets
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
  [CompilerGenerated]
  [Guid("000208D7-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface Sheets : IEnumerable
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_3();

    [LCIDConversion(4)]
    [DispId(181)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object Add([MarshalAs(UnmanagedType.Struct), In, Optional] object Before, [MarshalAs(UnmanagedType.Struct), In, Optional] object After, [MarshalAs(UnmanagedType.Struct), In, Optional] object Count, [MarshalAs(UnmanagedType.Struct), In, Optional] object Type);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_1();

    [DispId(118)]
    int Count { [DispId(118), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap3_2();

    [DispId(170)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object get_Item([MarshalAs(UnmanagedType.Struct), In] object Index);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap4_9();

    [DispId(0)]
    [IndexerName("_Default")]
    object this[[MarshalAs(UnmanagedType.Struct), In] object Index] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.IDispatch)] get; }
  }
}
