// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Accounts.SSC
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FSM.Entity.Accounts
{
    public class SSC
    {
        public SSC()
        {
            this.Payload = (Payload)null;
        }

        public Payload Payload { get; set; }

        public bool SaveToXml()
        {
            bool flag = false;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                int num = (int)folderBrowserDialog.ShowDialog();
                if (folderBrowserDialog.SelectedPath.Trim().Length != 0)
                {
                    string[] strArray = new string[10];
                    strArray[0] = folderBrowserDialog.SelectedPath;
                    strArray[1] = "\\S_Legder_Export_";
                    strArray[2] = Conversions.ToString(DateAndTime.Now.Day);
                    strArray[3] = "_";
                    DateTime now = DateAndTime.Now;
                    strArray[4] = now.ToString("MMM");
                    strArray[5] = "_";
                    now = DateAndTime.Now;
                    strArray[6] = Conversions.ToString(now.Year);
                    strArray[7] = "_";
                    now = DateAndTime.Now;
                    strArray[8] = now.ToString("HHmmss");
                    strArray[9] = ".xml";
                    string path = string.Concat(strArray);
                    new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite).Close();
                    StreamWriter streamWriter = new StreamWriter(path);
                    xmlSerializer.Serialize((TextWriter)streamWriter, (object)this);
                    streamWriter.Close();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Error converting to xml: \r\n\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
                ProjectData.ClearProjectError();
            }
            finally
            {
            }
            return flag;
        }
    }
}