using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Sys
    {
        public class ImageHelper
        {
            public class ImageDetails
            {
                public uint Id { get; set; }

                public ImageDetails(string fileName)
                {
                    ImageFile = fileName;
                }

                private decimal _widthInCm;

                public decimal WidthInCm
                {
                    set
                    {
                        _widthInCm = value;
                    }
                }

                private decimal _heightInCm;

                public decimal HeightInCm
                {
                    set
                    {
                        _heightInCm = value;
                    }
                }

                private const int emusPerInch = 914400;
                private const int emusPerCm = 360000;

                public long cx
                {
                    get
                    {
                        if (_widthInCm > 0)
                        {
                            return Conversions.ToLong(Math.Round(_widthInCm * emusPerCm));
                        }
                        else if (_image.Width > 0)
                        {
                            return Conversions.ToLong(Math.Round(_image.Width / _image.HorizontalResolution * emusPerInch));
                        }
                        else
                        {
                            throw new InvalidDataException("WidthInCm/WidthInPx has not been set");
                        }
                    }
                }

                public long cy
                {
                    get
                    {
                        if (_heightInCm > 0)
                        {
                            return Conversions.ToLong(decimal.Round(_heightInCm * emusPerCm));
                        }
                        else if (_image.Height > 0)
                        {
                            return Conversions.ToLong(Math.Round(_image.Height / _image.VerticalResolution * emusPerInch));
                        }
                        else
                        {
                            throw new InvalidDataException("HeightInCm/HeightInPx has not been set");
                        }
                    }
                }

                public int WidthInPx
                {
                    get
                    {
                        return _image.Width;
                    }
                }

                public int HeightInPx
                {
                    get
                    {
                        return _image.Height;
                    }
                }

                private string _imageFileName;
                private Image _image;

                public string ImageFile
                {
                    get
                    {
                        return _imageFileName;
                    }

                    set
                    {
                        _imageFileName = value;
                        using (object fs = new FileStream(value, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            _image = Image.FromStream((Stream)fs);
                        }
                    }
                }

                public Image ImageObject
                {
                    get
                    {
                        return _image;
                    }

                    set
                    {
                        _image = value;
                    }
                }

                public void ResizeImage(int targetWidth)
                {
                    if (_image is null)
                        throw new InvalidOperationException("The Image has not been referenced. Add an image first using .ImageFile or .ImageObject");
                    double percent = Conversions.ToDouble(_image.Width) / targetWidth;
                    int destWidth = Conversions.ToInteger(_image.Width / percent);
                    int destHeight = Conversions.ToInteger(_image.Height / percent);
                    var b = new Bitmap(destWidth, destHeight);
                    var g = Graphics.FromImage(b);
                    try
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.DrawImage(_image, 0, 0, destWidth, destHeight);
                    }
                    finally
                    {
                        g.Dispose();
                    }

                    _image = b;
                }
            }
        }
    }
}