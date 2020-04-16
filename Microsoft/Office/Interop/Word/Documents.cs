// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Documents
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.CustomMarshalers;

namespace Microsoft.Office.Interop.Word
{
  [CompilerGenerated]
  [Guid("0002096C-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface Documents : IEnumerable
  {
    [DispId(-4)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (EnumeratorToEnumVariantMarshaler))]
    new IEnumerator GetEnumerator();

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_4();

    [DispId(0)]
    Document this[[MarshalAs(UnmanagedType.Struct), In] ref object Index] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap2_4();

    [DispId(14)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Document Add(
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Template,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object NewTemplate,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object DocumentType,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Visible);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap3_4();

    [DispId(19)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    Document Open(
      [MarshalAs(UnmanagedType.Struct), In] ref object FileName,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object ConfirmConversions,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object ReadOnly,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object AddToRecentFiles,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object PasswordDocument,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object PasswordTemplate,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Revert,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object WritePasswordDocument,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object WritePasswordTemplate,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Format,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Encoding,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object Visible,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object OpenAndRepair,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object DocumentDirection,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object NoEncodingDialog,
      [MarshalAs(UnmanagedType.Struct), In, Optional] ref object XMLTransform);
  }
}
