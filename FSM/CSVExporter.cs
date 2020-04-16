// Decompiled with JetBrains decompiler
// Type: FSM.CSVExporter
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class CSVExporter
  {
    public bool CreateCSV(DataView CSVData)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Title = "Please choose a file name for your CSV Export";
      saveFileDialog.Filter = "CSV (Comma Delimited) (*.csv)|*.csv";
      string fileName;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
        fileName = saveFileDialog.FileName;
      if (File.Exists(fileName))
        File.Delete(fileName);
      FileStream fileStream = File.Create(fileName);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream);
      bool flag;
      try
      {
        IEnumerator enumerator;
        try
        {
          enumerator = CSVData.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            string str = string.Empty;
            object[] itemArray = current.ItemArray;
            int index = 0;
            while (index < itemArray.Length)
            {
              object objectValue = RuntimeHelpers.GetObjectValue(itemArray[index]);
              str = str + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(objectValue)) + ",";
              checked { ++index; }
            }
            streamWriter.WriteLine(str);
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        streamWriter.Close();
        fileStream.Close();
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        streamWriter.Close();
        fileStream.Close();
      }
      return flag;
    }
  }
}
