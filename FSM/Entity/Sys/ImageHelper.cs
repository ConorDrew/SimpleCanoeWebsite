// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.ImageHelper
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace FSM.Entity.Sys
{
  public class ImageHelper
  {
    public class ImageDetails
    {
      private Decimal _widthInCm;
      private Decimal _heightInCm;
      private const int emusPerInch = 914400;
      private const int emusPerCm = 360000;
      private string _imageFileName;
      private Image _image;

      public uint Id { get; set; }

      public ImageDetails(string fileName)
      {
        this.ImageFile = fileName;
      }

      public Decimal WidthInCm
      {
        set
        {
          this._widthInCm = value;
        }
      }

      public Decimal HeightInCm
      {
        set
        {
          this._heightInCm = value;
        }
      }

      public long cx
      {
        get
        {
          if (Decimal.Compare(this._widthInCm, Decimal.Zero) > 0)
            return Convert.ToInt64(Math.Round(Decimal.Multiply(this._widthInCm, new Decimal(360000L))));
          if (this._image.Width > 0)
            return checked ((long) Math.Round(unchecked ((double) this._image.Width / (double) this._image.HorizontalResolution * 914400.0)));
          throw new InvalidDataException("WidthInCm/WidthInPx has not been set");
        }
      }

      public long cy
      {
        get
        {
          if (Decimal.Compare(this._heightInCm, Decimal.Zero) > 0)
            return Convert.ToInt64(Decimal.Round(Decimal.Multiply(this._heightInCm, new Decimal(360000L))));
          if (this._image.Height > 0)
            return checked ((long) Math.Round(unchecked ((double) this._image.Height / (double) this._image.VerticalResolution * 914400.0)));
          throw new InvalidDataException("HeightInCm/HeightInPx has not been set");
        }
      }

      public int WidthInPx
      {
        get
        {
          return this._image.Width;
        }
      }

      public int HeightInPx
      {
        get
        {
          return this._image.Height;
        }
      }

      public string ImageFile
      {
        get
        {
          return this._imageFileName;
        }
        set
        {
          this._imageFileName = value;
          using (object obj = (object) new FileStream(value, FileMode.Open, FileAccess.Read, FileShare.Read))
            this._image = Image.FromStream((Stream) obj);
        }
      }

      public Image ImageObject
      {
        get
        {
          return this._image;
        }
        set
        {
          this._image = value;
        }
      }

      public void ResizeImage(int targetWidth)
      {
        if (this._image == null)
          throw new InvalidOperationException("The Image has not been referenced. Add an image first using .ImageFile or .ImageObject");
        double num = (double) this._image.Width / (double) targetWidth;
        int width = checked ((int) Math.Round(unchecked ((double) this._image.Width / num)));
        int height = checked ((int) Math.Round(unchecked ((double) this._image.Height / num)));
        Bitmap bitmap = new Bitmap(width, height);
        using (Graphics graphics = Graphics.FromImage((Image) bitmap))
        {
          graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
          graphics.SmoothingMode = SmoothingMode.HighQuality;
          graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
          graphics.CompositingQuality = CompositingQuality.HighQuality;
          graphics.DrawImage(this._image, 0, 0, width, height);
        }
        this._image = (Image) bitmap;
      }
    }
  }
}
