Public Class FrmEngineerVisitPhoto

    Public Sub New(image As Image)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        picImage.Image = image
    End Sub

    Private Sub btnSavePicture_Click(sender As Object, e As EventArgs) Handles btnSavePicture.Click
        Dim photoFileDialog As New SaveFileDialog
        photoFileDialog.AddExtension = True
        photoFileDialog.DefaultExt = "*.jpg"
        photoFileDialog.Title = "Please type a file name for the photograph"
        photoFileDialog.Filter = "JPEG|*.jpg"

        If photoFileDialog.ShowDialog =DialogResult.OK Then
            picImage.Image.Save(photoFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub


End Class