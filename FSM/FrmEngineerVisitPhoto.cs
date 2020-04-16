// Decompiled with JetBrains decompiler
// Type: FSM.FrmEngineerVisitPhoto
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FrmEngineerVisitPhoto : Form
  {
    private IContainer components;

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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmEngineerVisitPhoto));
      this.Panel1 = new Panel();
      this.btnSavePicture = new Button();
      this.picImage = new PictureBox();
      this.Panel1.SuspendLayout();
      ((ISupportInitialize) this.picImage).BeginInit();
      this.SuspendLayout();
      this.Panel1.Controls.Add((Control) this.btnSavePicture);
      this.Panel1.Dock = DockStyle.Bottom;
      this.Panel1.Location = new System.Drawing.Point(0, 668);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(877, 32);
      this.Panel1.TabIndex = 1;
      this.btnSavePicture.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSavePicture.Location = new System.Drawing.Point(799, 6);
      this.btnSavePicture.Name = "btnSavePicture";
      this.btnSavePicture.Size = new Size(75, 23);
      this.btnSavePicture.TabIndex = 0;
      this.btnSavePicture.Text = "Save";
      this.btnSavePicture.UseVisualStyleBackColor = true;
      this.picImage.Dock = DockStyle.Fill;
      this.picImage.Location = new System.Drawing.Point(0, 0);
      this.picImage.Name = "picImage";
      this.picImage.Size = new Size(877, 668);
      this.picImage.SizeMode = PictureBoxSizeMode.Zoom;
      this.picImage.TabIndex = 2;
      this.picImage.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(877, 700);
      this.Controls.Add((Control) this.picImage);
      this.Controls.Add((Control) this.Panel1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FrmEngineerVisitPhoto);
      this.Text = "Engineer Visit Photo";
      this.Panel1.ResumeLayout(false);
      ((ISupportInitialize) this.picImage).EndInit();
      this.ResumeLayout(false);
    }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSavePicture
    {
      get
      {
        return this._btnSavePicture;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSavePicture_Click);
        Button btnSavePicture1 = this._btnSavePicture;
        if (btnSavePicture1 != null)
          btnSavePicture1.Click -= eventHandler;
        this._btnSavePicture = value;
        Button btnSavePicture2 = this._btnSavePicture;
        if (btnSavePicture2 == null)
          return;
        btnSavePicture2.Click += eventHandler;
      }
    }

    internal virtual PictureBox picImage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public FrmEngineerVisitPhoto(Image image)
    {
      this.InitializeComponent();
      this.picImage.Image = image;
    }

    private void btnSavePicture_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.AddExtension = true;
      saveFileDialog.DefaultExt = "*.jpg";
      saveFileDialog.Title = "Please type a file name for the photograph";
      saveFileDialog.Filter = "JPEG|*.jpg";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.picImage.Image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
    }
  }
}
