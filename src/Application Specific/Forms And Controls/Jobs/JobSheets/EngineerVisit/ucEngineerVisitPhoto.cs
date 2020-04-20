using System;
using System.Drawing;

namespace FSM
{
    public partial class ucEngineerVisitPhoto
    {
        public ucEngineerVisitPhoto()
        {
            InitializeComponent();
        }

        public event PhotoDeleteClickedEventHandler PhotoDeleteClicked;

        public delegate void PhotoDeleteClickedEventHandler(int EngineerVisitPhotoID);

        public event PhotoCaptionChangedEventHandler PhotoCaptionChanged;

        public delegate void PhotoCaptionChangedEventHandler(int EngineerVisitPhotoID, string Caption);

        private int _engineerVisitPhotoID;

        public int EngineerVisitPhotoID
        {
            get
            {
                return _engineerVisitPhotoID;
            }

            set
            {
                _engineerVisitPhotoID = value;
            }
        }

        public Image Photo
        {
            get
            {
                return picPhoto.Image;
            }

            set
            {
                picPhoto.Image = value;
            }
        }

        public string Caption
        {
            get
            {
                return txtCaption.Text;
            }

            set
            {
                txtCaption.Text = value;
            }
        }

        private void picDeleteImage_Click(object sender, EventArgs e)
        {
            PhotoDeleteClicked?.Invoke(EngineerVisitPhotoID);
        }

        private void txtCaption_TextChanged(object sender, EventArgs e)
        {
            PhotoCaptionChanged?.Invoke(EngineerVisitPhotoID, txtCaption.Text);
        }

        private void picPhoto_Click(object sender, EventArgs e)
        {
            var frmEngineerVisitPhoto = new FrmEngineerVisitPhoto(Photo);
            frmEngineerVisitPhoto.ShowDialog();
        }
    }
}