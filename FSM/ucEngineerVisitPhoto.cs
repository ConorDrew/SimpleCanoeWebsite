// Decompiled with JetBrains decompiler
// Type: FSM.ucEngineerVisitPhoto
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class ucEngineerVisitPhoto : UserControl
  {
    private IContainer components;
    private int _engineerVisitPhotoID;

    public ucEngineerVisitPhoto()
    {
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.txtCaption = new TextBox();
      this.picPhoto = new PictureBox();
      this.picDeleteImage = new PictureBox();
      ((ISupportInitialize) this.picPhoto).BeginInit();
      ((ISupportInitialize) this.picDeleteImage).BeginInit();
      this.SuspendLayout();
      this.txtCaption.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCaption.Location = new System.Drawing.Point(3, 240);
      this.txtCaption.Multiline = true;
      this.txtCaption.Name = "txtCaption";
      this.txtCaption.Size = new Size(228, 44);
      this.txtCaption.TabIndex = 1;
      this.picPhoto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.picPhoto.BackColor = Color.White;
      this.picPhoto.Location = new System.Drawing.Point(3, 3);
      this.picPhoto.Name = "picPhoto";
      this.picPhoto.Size = new Size(228, 231);
      this.picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
      this.picPhoto.TabIndex = 4;
      this.picPhoto.TabStop = false;
      this.picDeleteImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.picDeleteImage.BackColor = Color.Transparent;
      this.picDeleteImage.Cursor = Cursors.Hand;
      this.picDeleteImage.Image = (Image) FSM.My.Resources.Resources.delete;
      this.picDeleteImage.Location = new System.Drawing.Point(208, 3);
      this.picDeleteImage.Name = "picDeleteImage";
      this.picDeleteImage.Size = new Size(23, 22);
      this.picDeleteImage.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picDeleteImage.TabIndex = 5;
      this.picDeleteImage.TabStop = false;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.WhiteSmoke;
      this.BorderStyle = BorderStyle.FixedSingle;
      this.Controls.Add((Control) this.picDeleteImage);
      this.Controls.Add((Control) this.txtCaption);
      this.Controls.Add((Control) this.picPhoto);
      this.Name = nameof (ucEngineerVisitPhoto);
      this.Size = new Size(234, 287);
      ((ISupportInitialize) this.picPhoto).EndInit();
      ((ISupportInitialize) this.picDeleteImage).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual TextBox txtCaption
    {
      get
      {
        return this._txtCaption;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtCaption_TextChanged);
        TextBox txtCaption1 = this._txtCaption;
        if (txtCaption1 != null)
          txtCaption1.TextChanged -= eventHandler;
        this._txtCaption = value;
        TextBox txtCaption2 = this._txtCaption;
        if (txtCaption2 == null)
          return;
        txtCaption2.TextChanged += eventHandler;
      }
    }

    internal virtual PictureBox picPhoto
    {
      get
      {
        return this._picPhoto;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.picPhoto_Click);
        PictureBox picPhoto1 = this._picPhoto;
        if (picPhoto1 != null)
          picPhoto1.Click -= eventHandler;
        this._picPhoto = value;
        PictureBox picPhoto2 = this._picPhoto;
        if (picPhoto2 == null)
          return;
        picPhoto2.Click += eventHandler;
      }
    }

    internal virtual PictureBox picDeleteImage
    {
      get
      {
        return this._picDeleteImage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.picDeleteImage_Click);
        PictureBox picDeleteImage1 = this._picDeleteImage;
        if (picDeleteImage1 != null)
          picDeleteImage1.Click -= eventHandler;
        this._picDeleteImage = value;
        PictureBox picDeleteImage2 = this._picDeleteImage;
        if (picDeleteImage2 == null)
          return;
        picDeleteImage2.Click += eventHandler;
      }
    }

    public event ucEngineerVisitPhoto.PhotoDeleteClickedEventHandler PhotoDeleteClicked;

    public event ucEngineerVisitPhoto.PhotoCaptionChangedEventHandler PhotoCaptionChanged;

    public int EngineerVisitPhotoID
    {
      get
      {
        return this._engineerVisitPhotoID;
      }
      set
      {
        this._engineerVisitPhotoID = value;
      }
    }

    public Image Photo
    {
      get
      {
        return this.picPhoto.Image;
      }
      set
      {
        this.picPhoto.Image = value;
      }
    }

    public string Caption
    {
      get
      {
        return this.txtCaption.Text;
      }
      set
      {
        this.txtCaption.Text = value;
      }
    }

    private void picDeleteImage_Click(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      ucEngineerVisitPhoto.PhotoDeleteClickedEventHandler deleteClickedEvent = this.PhotoDeleteClickedEvent;
      if (deleteClickedEvent == null)
        return;
      deleteClickedEvent(this.EngineerVisitPhotoID);
    }

    private void txtCaption_TextChanged(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      ucEngineerVisitPhoto.PhotoCaptionChangedEventHandler captionChangedEvent = this.PhotoCaptionChangedEvent;
      if (captionChangedEvent == null)
        return;
      captionChangedEvent(this.EngineerVisitPhotoID, this.txtCaption.Text);
    }

    private void picPhoto_Click(object sender, EventArgs e)
    {
      int num = (int) new FrmEngineerVisitPhoto(this.Photo).ShowDialog();
    }

    public delegate void PhotoDeleteClickedEventHandler(int EngineerVisitPhotoID);

    public delegate void PhotoCaptionChangedEventHandler(int EngineerVisitPhotoID, string Caption);
  }
}
