// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word.Bookmark
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [CompilerGenerated]
  [Guid("00020968-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface Bookmark
  {
    [DispId(0)]
    [IndexerName("Name")]
    string this[] { [DispId(0), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }

    [DispId(1)]
    Range Range { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }
  }
}
