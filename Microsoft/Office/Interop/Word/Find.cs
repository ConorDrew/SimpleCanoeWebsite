// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Find
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [CompilerGenerated]
  [Guid("000209B0-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface Find
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_26();

    [DispId(22)]
    string Text { [DispId(22), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(22), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: MarshalAs(UnmanagedType.BStr), In] set; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_4();

    [DispId(25)]
    Replacement Replacement { [DispId(25), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap3_15();

    [DispId(444)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    bool Execute(
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object FindText,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchCase,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchWholeWord,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchWildcards,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchSoundsLike,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchAllWordForms,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Forward,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Wrap,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Format,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object ReplaceWith,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Replace,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchKashida,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchDiacritics,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchAlefHamza,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object MatchControl);
  }
}
