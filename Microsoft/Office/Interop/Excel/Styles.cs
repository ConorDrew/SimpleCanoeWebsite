// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Excel.Styles
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
  [CompilerGenerated]
  [InterfaceType(2)]
  [Guid("00020853-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface Styles : IEnumerable
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_3();

    [DispId(181)]
    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Style Add([MarshalAs(UnmanagedType.BStr), In] string Name, [MarshalAs(UnmanagedType.Struct), In, Optional] object BasedOn);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_4();

    [DispId(0)]
    [IndexerName("_Default")]
    Style this[[MarshalAs(UnmanagedType.Struct), In] object Index] { [DispId(0), MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }
  }
}
