// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word._Document
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [CompilerGenerated]
  [Guid("0002096B-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface _Document
  {
    [DispId(0)]
    [IndexerName("Name")]
    string this[] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_6();

    [DispId(4)]
    Bookmarks Bookmarks { [DispId(4), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [DispId(6)]
    Tables Tables { [DispId(6), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_29();

    [DispId(1101)]
    PageSetup PageSetup { [DispId(1101), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; [DispId(1101), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: MarshalAs(UnmanagedType.Interface), In] set; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap3_9();

    [DispId(41)]
    Range Content { [DispId(41), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap4_34();

    [DispId(70)]
    bool GrammarChecked { [DispId(70), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(70), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    [DispId(71)]
    bool SpellingChecked { [DispId(71), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(71), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap5_72();

    [DispId(1105)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Close([MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveChanges, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object OriginalFormat, [MarshalAs(UnmanagedType.Struct), In, Optional] ref object RouteDocument);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap6_4();

    [DispId(65535)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Select();

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap7_7();

    [DispId(113)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Activate();

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap8_116();

    [DispId(376)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SaveAs(
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object FileName,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object FileFormat,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object LockComments,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Password,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AddToRecentFiles,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object WritePassword,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object ReadOnlyRecommended,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object EmbedTrueTypeFonts,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveNativePictureFormat,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveFormsData,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveAsAOCELetter,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Encoding,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object InsertLineBreaks,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AllowSubstitutions,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object LineEnding,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AddBiDiMarks);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap9_136();

    [DispId(568)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SaveAs2(
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object FileName,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object FileFormat,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object LockComments,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Password,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AddToRecentFiles,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object WritePassword,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object ReadOnlyRecommended,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object EmbedTrueTypeFonts,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveNativePictureFormat,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveFormsData,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object SaveAsAOCELetter,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Encoding,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object InsertLineBreaks,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AllowSubstitutions,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object LineEnding,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AddBiDiMarks,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object CompatibilityMode);
  }
}
