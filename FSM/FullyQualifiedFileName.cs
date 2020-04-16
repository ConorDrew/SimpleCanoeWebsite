// Decompiled with JetBrains decompiler
// Type: FSM.FullyQualifiedFileName
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
  public class FullyQualifiedFileName
  {
    public string Text;

    public FullyQualifiedFileName()
    {
      this.Text = string.Empty;
    }

    private static string extractExtension(string text)
    {
      string folder;
      string name;
      string ext;
      FullyQualifiedFileName.splitText(text, ref folder, ref name, ref ext);
      return ext;
    }

    private static string extractFolder(string text)
    {
      string defaultFolder;
      string name;
      string ext;
      FullyQualifiedFileName.splitText(text, ref defaultFolder, ref name, ref ext);
      if (Operators.CompareString(defaultFolder, "\\", false) == 0)
        defaultFolder = XmlPersister.DefaultFolder;
      return defaultFolder;
    }

    private static string extractFolderAndName(string text)
    {
      string defaultFolder;
      string name;
      string ext;
      FullyQualifiedFileName.splitText(text, ref defaultFolder, ref name, ref ext);
      if (defaultFolder.Length == 0)
        defaultFolder = XmlPersister.DefaultFolder;
      return defaultFolder + name;
    }

    private static string extractName(string text)
    {
      string folder;
      string name;
      string ext;
      FullyQualifiedFileName.splitText(text, ref folder, ref name, ref ext);
      return name;
    }

    private static string extractNameWithExt(string text)
    {
      string folder;
      string name;
      string ext;
      FullyQualifiedFileName.splitText(text, ref folder, ref name, ref ext);
      return ext.Length > 0 ? name + "." + ext : name;
    }

    private static void splitText(
      string toSplit,
      ref string folder,
      ref string name,
      ref string ext)
    {
      folder = string.Empty;
      name = string.Empty;
      ext = string.Empty;
      if (toSplit.Length > 0)
      {
        int length1 = toSplit.LastIndexOf("\\");
        if (length1 > 0)
        {
          folder = toSplit.Substring(0, length1);
          name = toSplit.Substring(checked (length1 + 1));
        }
        else
          name = toSplit;
        toSplit = name;
        if (toSplit.Length > 0)
        {
          int length2 = toSplit.LastIndexOf(".");
          if (length2 > 0)
          {
            name = toSplit.Substring(0, length2);
            ext = toSplit.Substring(checked (length2 + 1));
          }
        }
      }
      if (folder.EndsWith("\\"))
        return;
      folder += "\\";
    }

    public string Extension
    {
      get
      {
        return FullyQualifiedFileName.extractExtension(this.Text);
      }
    }

    public string Folder
    {
      get
      {
        return FullyQualifiedFileName.extractFolder(this.Text);
      }
      set
      {
        if (!value.EndsWith("\\"))
          value += "\\";
        this.Text = value + this.NameAndExt;
      }
    }

    public string FolderAndName
    {
      get
      {
        return FullyQualifiedFileName.extractFolderAndName(this.Text);
      }
    }

    public string Name
    {
      get
      {
        return FullyQualifiedFileName.extractName(this.Text);
      }
    }

    public string NameAndExt
    {
      get
      {
        return FullyQualifiedFileName.extractNameWithExt(this.Text);
      }
    }
  }
}
