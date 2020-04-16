// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word._Application
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [CompilerGenerated]
  [Guid("00020970-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface _Application
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_3();

    [DispId(0)]
    [IndexerName("Name")]
    string this[] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [DispId(6)]
    Documents Documents { [DispId(6), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_3();

    [DispId(5)]
    Selection Selection { [DispId(5), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap3_17();

    [DispId(23)]
    bool Visible { [DispId(23), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(23), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap4_62();

    [DispId(94)]
    WdAlertLevel DisplayAlerts { [DispId(94), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(94), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap5_21();

    [DispId(1105)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Quit([MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveChanges, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object OriginalFormat, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object RouteDocument);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap6_41();

    [DispId(371)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    float CentimetersToPoints([In] float Centimeters);
  }
}
