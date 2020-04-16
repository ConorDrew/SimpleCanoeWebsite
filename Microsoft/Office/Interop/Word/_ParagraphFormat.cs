// Decompiled with JetBrains decompiler
// Type: Microsoft.Office.Interop.Word._ParagraphFormat
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Word
{
  [CompilerGenerated]
  [Guid("00020953-0000-0000-C000-000000000046")]
  [TypeIdentifier]
  [ComImport]
  public interface _ParagraphFormat
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_6();

    [DispId(101)]
    WdParagraphAlignment Alignment { [DispId(101), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(101), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
  }
}
