// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Excel._Chart
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
  [CompilerGenerated]
  [Guid("000208D6-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface _Chart
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_42();

    [LCIDConversion(2)]
    [DispId(23)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object Axes([MarshalAs(UnmanagedType.Struct), In, Optional] object Type, [In] XlAxisGroup AxisGroup = XlAxisGroup.xlPrimary);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_8();

    [LCIDConversion(11)]
    [DispId(196)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void ChartWizard(
      [MarshalAs(UnmanagedType.Struct), In, Optional] object Source,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object Gallery,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object Format,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object PlotBy,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object CategoryLabels,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object SeriesLabels,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object HasLegend,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object Title,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object CategoryTitle,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object ValueTitle,
      [MarshalAs(UnmanagedType.Struct), In, Optional] object ExtraTitle);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap3_63();

    [DispId(68)]
    [LCIDConversion(1)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object SeriesCollection([MarshalAs(UnmanagedType.Struct), In, Optional] object Index);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap4_32();

    [DispId(1413)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetSourceData([MarshalAs(UnmanagedType.Interface), In] Range Source, [MarshalAs(UnmanagedType.Struct), In, Optional] object PlotBy);
  }
}
