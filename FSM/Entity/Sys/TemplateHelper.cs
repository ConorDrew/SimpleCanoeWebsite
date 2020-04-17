// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.TemplateHelper
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using DocumentFormat.OpenXml.Packaging;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
    public class TemplateHelper
    {
        public static byte[] AddTemplate()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            byte[] numArray = (byte[])null;
            if (openFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
            {
                Cursor.Current = Cursors.WaitCursor;
                numArray = TemplateHelper.ReadWordDoc(openFileDialog.FileName);
                Cursor.Current = Cursors.Default;
            }
            return numArray;
        }

        public static byte[] ReadWordDoc(string file)
        {
            Cursor.Current = Cursors.WaitCursor;
            if ((uint)Operators.CompareString(Path.GetExtension(file), ".docx", false) > 0U)
                throw new Exception("Invalid File Extension.\r\n\r\n.docx Files Only!");
            FileStream fileStream = new FileStream(file, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader((Stream)fileStream);
            byte[] numArray = binaryReader.ReadBytes(checked((int)fileStream.Length));
            binaryReader.Close();
            fileStream.Close();
            return numArray;
        }

        private static void WriteWordDoc(string fileName, byte[] data)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            BinaryWriter binaryWriter = new BinaryWriter((Stream)fileStream);
            binaryWriter.Write(data);
            binaryWriter.Close();
            fileStream.Close();
        }

        public static void TestTemplate(byte[] template, Enums.TemplateType templateType)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string empty = string.Empty;
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                int num = (int)folderBrowserDialog.ShowDialog();
                if (folderBrowserDialog.SelectedPath.Trim().Length == 0 || templateType != Enums.TemplateType.ServiceLetter)
                    return;
                string savePath = folderBrowserDialog.SelectedPath + "\\ServiceLetter_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                TemplateHelper.TestServiceLetter(template, savePath);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Debugger.Break();
                ProjectData.ClearProjectError();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private static void TestServiceLetter(byte[] template, string savePath)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (memoryStream)
            {
                memoryStream.Write(template, 0, template.Length);
                WordprocessingDocument doc1 = WordprocessingDocument.Open((Stream)memoryStream, true);
                using (doc1)
                {
                    FSM.Entity.CompanyDetails.CompanyDetails companyDetails = App.DB.CompanyDetails.Get();
                    PrintHelper.ReplaceText(doc1, "$Customer", companyDetails.Name);
                    PrintHelper.ReplaceText(doc1, "$Address1", companyDetails.Address1);
                    PrintHelper.ReplaceText(doc1, "$Address2", companyDetails.Address2);
                    PrintHelper.ReplaceText(doc1, "$Address3", companyDetails.Address3);
                    PrintHelper.ReplaceText(doc1, "$Address4", companyDetails.Address4);
                    PrintHelper.ReplaceText(doc1, "$Address5", companyDetails.Address5);
                    PrintHelper.ReplaceText(doc1, "$Postcode", Helper.FormatPostcode((object)companyDetails.Postcode));
                    PrintHelper.ReplaceText(doc1, "$TheDate", DateTime.Now.ToString("dd/MM/yyyy"));
                    WordprocessingDocument doc2 = doc1;
                    DateTime dateTime = DateTime.Now;
                    string text1 = dateTime.ToString("dddd, dd/MM/yyyy");
                    PrintHelper.ReplaceText(doc2, "$Date", text1);
                    WordprocessingDocument doc3 = doc1;
                    dateTime = DateTime.Now;
                    dateTime = dateTime.AddDays(366.0);
                    string text2 = dateTime.ToString("dd/MM/yyyy");
                    PrintHelper.ReplaceText(doc3, "$Expiry", text2);
                    PrintHelper.ReplaceText(doc1, "$Name", companyDetails.Name);
                    dateTime = DateTime.Now;
                    if (dateTime.Hour > 12)
                        PrintHelper.ReplaceText(doc1, "$AMPM", "between 12:00pm and 5:30pm");
                    else
                        PrintHelper.ReplaceText(doc1, "$AMPM", "between 8:00am and 1:00pm");
                    PrintHelper.ReplaceText(doc1, "$GasCharge", "£41.37");
                    PrintHelper.ReplaceText(doc1, "$CarpCharge", "£97.76");
                    PrintHelper.ReplaceText(doc1, "$JobRef", "C_TestTemplate");
                }
                FileStream fileStream = new FileStream(savePath, FileMode.CreateNew);
                memoryStream.Position = 0L;
                using (fileStream)
                    memoryStream.WriteTo((Stream)fileStream);
                fileStream.Close();
                Process.Start(savePath);
            }
        }

        public static void DownloadTemplate(byte[] template)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = "Template_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                int num = (int)folderBrowserDialog.ShowDialog();
                if (folderBrowserDialog.SelectedPath.Trim().Length == 0)
                    return;
                TemplateHelper.WriteWordDoc(folderBrowserDialog.SelectedPath + "\\" + str, template);
                Process.Start(folderBrowserDialog.SelectedPath + "\\" + str);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Debugger.Break();
                ProjectData.ClearProjectError();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}