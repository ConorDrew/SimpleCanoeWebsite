// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.InlineShapes
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [CompilerGenerated]
  [Guid("000209A9-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface InlineShapes : IEnumerable
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_5();

    [DispId(0)]
    InlineShape this[[In] int Index] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(100)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    InlineShape AddPicture(
      [MarshalAs(UnmanagedType.BStr), In] string FileName,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object LinkToFile,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveWithDocument,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Range);
  }
}
