// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Cell
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [CompilerGenerated]
  [Guid("0002094E-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface Cell
  {
    [DispId(0)]
    [IndexerName("Range")]
    Range this[] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_21();

    [DispId(200)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Delete([MarshalAs(UnmanagedType.Struct), In, Optional] ref object ShiftCells);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_8();

    [DispId(108)]
    bool WordWrap { [DispId(108), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(108), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
  }
}
