Imports System
Imports System.Drawing.Drawing2D
Imports System.IO
Imports DocumentFormat.OpenXml

Namespace Entity

    Namespace Sys

        Public Class ImageHelper

            Public Class ImageDetails
                Public Property Id As UInt32

                Public Sub New(ByVal fileName As String)
                    Me.ImageFile = fileName
                End Sub

                Private _widthInCm As Decimal

                Public WriteOnly Property WidthInCm As Decimal
                    Set(ByVal value As Decimal)
                        _widthInCm = value
                    End Set
                End Property

                Private _heightInCm As Decimal

                Public WriteOnly Property HeightInCm As Decimal
                    Set(ByVal value As Decimal)
                        _heightInCm = value
                    End Set
                End Property

                Const emusPerInch As Integer = 914400
                Const emusPerCm As Integer = 360000

                Public ReadOnly Property cx As Long
                    Get

                        If _widthInCm > 0 Then
                            Return CLng(Math.Round(_widthInCm * emusPerCm))
                        ElseIf _image.Width > 0 Then
                            Return CLng(Math.Round((_image.Width / _image.HorizontalResolution) * emusPerInch))
                        Else
                            Throw New InvalidDataException("WidthInCm/WidthInPx has not been set")
                        End If
                    End Get
                End Property

                Public ReadOnly Property cy As Long
                    Get

                        If _heightInCm > 0 Then
                            Return CLng(Decimal.Round(_heightInCm * emusPerCm))
                        ElseIf _image.Height > 0 Then
                            Return CLng(Math.Round((_image.Height / _image.VerticalResolution) * emusPerInch))
                        Else
                            Throw New InvalidDataException("HeightInCm/HeightInPx has not been set")
                        End If
                    End Get
                End Property

                Public ReadOnly Property WidthInPx As Integer
                    Get
                        Return _image.Width
                    End Get
                End Property

                Public ReadOnly Property HeightInPx As Integer
                    Get
                        Return _image.Height
                    End Get
                End Property

                Private _imageFileName As String
                Private _image As Image

                Public Property ImageFile As String
                    Get
                        Return _imageFileName
                    End Get
                    Set(ByVal value As String)
                        _imageFileName = value

                        Using fs = New FileStream(value, FileMode.Open, FileAccess.Read, FileShare.Read)
                            _image = Image.FromStream(fs)
                        End Using
                    End Set
                End Property

                Public Property ImageObject As Image
                    Get
                        Return _image
                    End Get
                    Set(ByVal value As Image)
                        _image = value
                    End Set
                End Property

                Public Sub ResizeImage(ByVal targetWidth As Integer)
                    If _image Is Nothing Then Throw New InvalidOperationException("The Image has not been referenced. Add an image first using .ImageFile or .ImageObject")
                    Dim percent As Double = CDbl(_image.Width) / targetWidth
                    Dim destWidth As Integer = CInt((_image.Width / percent))
                    Dim destHeight As Integer = CInt((_image.Height / percent))
                    Dim b As Bitmap = New Bitmap(destWidth, destHeight)
                    Dim g As Graphics = Graphics.FromImage(CType(b, Image))

                    Try
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic
                        g.SmoothingMode = SmoothingMode.HighQuality
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality
                        g.CompositingQuality = CompositingQuality.HighQuality
                        g.DrawImage(_image, 0, 0, destWidth, destHeight)
                    Finally
                        g.Dispose()
                    End Try

                    _image = CType(b, Image)
                End Sub
            End Class
        End Class

    End Namespace

End Namespace