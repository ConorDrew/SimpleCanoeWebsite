using System;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public partial class FrmEngineerVisitPhoto
    {
        public FrmEngineerVisitPhoto()
        {
            InitializeComponent();
        }

        public FrmEngineerVisitPhoto(Image image)
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            picImage.Image = image;
        }

        private void btnSavePicture_Click(object sender, EventArgs e)
        {
            var photoFileDialog = new SaveFileDialog();
            photoFileDialog.AddExtension = true;
            photoFileDialog.DefaultExt = "*.jpg";
            photoFileDialog.Title = "Please type a file name for the photograph";
            photoFileDialog.Filter = "JPEG|*.jpg";
            if (photoFileDialog.ShowDialog() == DialogResult.OK)
            {
                picImage.Image.Save(photoFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}