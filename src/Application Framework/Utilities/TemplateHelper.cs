using DocumentFormat.OpenXml.Packaging;
using Microsoft.VisualBasic;
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
            var dlg = new OpenFileDialog();
            byte[] doc = null;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.FileName))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    doc = ReadWordDoc(dlg.FileName);
                    Cursor.Current = Cursors.Default;
                }
            }

            return doc;
        }

        public static byte[] ReadWordDoc(string file)
        {
            Cursor.Current = Cursors.WaitCursor;
            if ((Path.GetExtension(file) ?? "") != ".docx")
            {
                throw new Exception("Invalid File Extension." + Constants.vbCrLf + Constants.vbCrLf + ".docx Files Only!");
            }

            var fileStream = new FileStream(file, FileMode.Open);
            var binaryReader = new BinaryReader(fileStream);
            var doc = binaryReader.ReadBytes(Conversions.ToInteger(fileStream.Length));
            binaryReader.Close();
            fileStream.Close();
            return doc;
            Cursor.Current = Cursors.Default;
        }

        private static void WriteWordDoc(string fileName, byte[] data)
        {
            var fs = new FileStream(fileName, FileMode.Create);
            var bw = new BinaryWriter(fs);
            bw.Write(data);
            bw.Close();
            fs.Close();
        }

        public static void TestTemplate(byte[] template, Enums.TemplateType templateType)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string filePath = string.Empty;
                var saveDir = new FolderBrowserDialog();
                saveDir.ShowDialog();
                if (saveDir.SelectedPath.Trim().Length == 0)
                {
                    return;
                }
                else
                {
                    switch (templateType)
                    {
                        case Enums.TemplateType.ServiceLetter:
                            {
                                filePath = saveDir.SelectedPath + @"\ServiceLetter_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                                TestServiceLetter(template, filePath);
                                break;
                            }
                        case Enums.TemplateType.Eicr:
                            {
                                filePath = saveDir.SelectedPath + @"\Eicr_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                                TestEicrLetter(template, filePath);
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.Break();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private static void TestServiceLetter(byte[] template, string savePath)
        {
            var mm = new MemoryStream();
            using (mm)
            {
                mm.Write(template, 0, template.Length);
                var doc = WordprocessingDocument.Open(mm, true);
                using (doc)
                {
                    var companyDetails = App.DB.CompanyDetails.Get();
                    PrintHelper.ReplaceText(doc, "$Customer", companyDetails.Name);
                    PrintHelper.ReplaceText(doc, "$Address1", companyDetails.Address1);
                    PrintHelper.ReplaceText(doc, "$Address2", companyDetails.Address2);
                    PrintHelper.ReplaceText(doc, "$Address3", companyDetails.Address3);
                    PrintHelper.ReplaceText(doc, "$Address4", companyDetails.Address4);
                    PrintHelper.ReplaceText(doc, "$Address5", companyDetails.Address5);
                    PrintHelper.ReplaceText(doc, "$Postcode", Helper.FormatPostcode(companyDetails.Postcode));
                    PrintHelper.ReplaceText(doc, "$TheDate", DateTime.Now.ToString("dd/MM/yyyy"));
                    PrintHelper.ReplaceText(doc, "$Date", DateTime.Now.ToString("dddd, dd/MM/yyyy"));
                    PrintHelper.ReplaceText(doc, "$Expiry", DateTime.Now.AddDays(366).ToString("dd/MM/yyyy"));
                    PrintHelper.ReplaceText(doc, "$Name", companyDetails.Name);
                    if (DateTime.Now.Hour > 12)
                    {
                        PrintHelper.ReplaceText(doc, "$AMPM", "between 12:00pm and 5:30pm");
                    }
                    else
                    {
                        PrintHelper.ReplaceText(doc, "$AMPM", "between 8:00am and 1:00pm");
                    }

                    PrintHelper.ReplaceText(doc, "$GasCharge", "£41.37");
                    PrintHelper.ReplaceText(doc, "$CarpCharge", "£97.76");
                    PrintHelper.ReplaceText(doc, "$JobRef", "C_TestTemplate");
                }

                var fileStream = new FileStream(savePath, FileMode.CreateNew);
                mm.Position = 0;
                using (fileStream)
                    mm.WriteTo(fileStream);
                fileStream.Close();
                Process.Start(savePath);
            }
        }

        private static void TestEicrLetter(byte[] template, string savePath)
        {
            MemoryStream mm = new MemoryStream();
            using (mm)
            {
                mm.Write(template, 0, template.Length);
                WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);
                using (doc)
                {
                    CompanyDetails.CompanyDetails companyDetails = App.DB.CompanyDetails.Get();
                    PrintHelper.ReplaceText(doc, "[Name]", companyDetails.Name);
                    PrintHelper.ReplaceText(doc, "[Address1]", companyDetails.Address1);
                    PrintHelper.ReplaceText(doc, "[Address2]", companyDetails.Address2);
                    PrintHelper.ReplaceText(doc, "[Address3]", companyDetails.Address3);
                    PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(companyDetails.Postcode));
                    PrintHelper.ReplaceText(doc, "[Letter]", DateTime.Now.ToString("dd/MM/yyyy"));
                    PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dddd, dd/MM/yyyy"));

                    if (DateTime.Now.Hour > 12)
                        PrintHelper.ReplaceText(doc, "[Time]", "between 12:00pm and 5:30pm");
                    else
                        PrintHelper.ReplaceText(doc, "[Time]", "between 8:00am and 1:00pm");
                    PrintHelper.ReplaceText(doc, "[User]", App.loggedInUser.Fullname);
                    PrintHelper.ReplaceText(doc, "[Type]", "Test");
                }
                FileStream fileStream = new FileStream(savePath, FileMode.CreateNew);
                mm.Position = 0;
                using ((fileStream))
                    mm.WriteTo(fileStream);
                fileStream.Close();

                Process.Start(savePath);
            }
        }

        public static void DownloadTemplate(byte[] template)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string filename = "Template_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                var saveDir = new FolderBrowserDialog();
                saveDir.ShowDialog();
                if (saveDir.SelectedPath.Trim().Length == 0)
                {
                    return;
                }
                else
                {
                    WriteWordDoc(saveDir.SelectedPath + @"\" + filename, template);
                    Process.Start(saveDir.SelectedPath + @"\" + filename);
                }
            }
            catch (Exception ex)
            {
                Debugger.Break();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}