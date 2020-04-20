using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace FSM
{
    public class CSVExporter
    {
        public bool CreateCSV(DataView CSVData)
        {

            // create our stream
            FileStream stream;
            var StrFileName = default(string);
            var fileBrowser = new SaveFileDialog();
            fileBrowser.Title = "Please choose a file name for your CSV Export";
            fileBrowser.Filter = "CSV (Comma Delimited) (*.csv)|*.csv";
            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                StrFileName = fileBrowser.FileName;
            }

            if (File.Exists(StrFileName))
            {
                File.Delete(StrFileName);
            }

            // create our file - which conveniently gives us a stream to it.
            stream = File.Create(StrFileName);

            // create a StreamWriter which lets us write to the file
            var writer = new StreamWriter(stream);
            try
            {

                // First, we'll create a local CSV line. Then we'll write it. 
                foreach (DataRow row in CSVData.Table.Rows)
                {
                    string str = string.Empty;
                    foreach (object item in row.ItemArray)
                        str += Entity.Sys.Helper.MakeStringValid(item) + ",";
                    writer.WriteLine(str);
                }

                // by the time we get here we should have everything set. Just close all the streams
                // and we'll be set.
                writer.Close();
                stream.Close();

                // Return how many records we processed

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                // close the writers
                writer.Close();
                stream.Close();
            }
        }
    }
}