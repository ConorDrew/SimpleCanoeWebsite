Public Class ucEngineerVisitPhoto

    Public Event PhotoDeleteClicked(ByVal EngineerVisitPhotoID As Integer)
    Public Event PhotoCaptionChanged(ByVal EngineerVisitPhotoID As Integer, ByVal Caption As String)

    Private _engineerVisitPhotoID As Integer
    Public Property EngineerVisitPhotoID() As Integer
        Get
            Return _engineerVisitPhotoID
        End Get
        Set(ByVal value As Integer)
            _engineerVisitPhotoID = value
        End Set
    End Property

    Public Property Photo() As Image
        Get
            Return picPhoto.Image
        End Get
        Set(ByVal value As Image)
            picPhoto.Image = value
        End Set
    End Property

    Public Property Caption() As String
        Get
            Return txtCaption.Text
        End Get
        Set(ByVal value As String)
            txtCaption.Text = value
        End Set
    End Property


    Private Sub picDeleteImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picDeleteImage.Click
        RaiseEvent PhotoDeleteClicked(EngineerVisitPhotoID)
    End Sub

    Private Sub txtCaption_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
        RaiseEvent PhotoCaptionChanged(EngineerVisitPhotoID, txtCaption.Text)
    End Sub

    Private Sub picPhoto_Click(sender As Object, e As EventArgs) Handles picPhoto.Click
        Dim frmEngineerVisitPhoto As New FrmEngineerVisitPhoto(Photo)
        frmEngineerVisitPhoto.ShowDialog()
    End Sub
End Class
