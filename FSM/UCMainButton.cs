// Decompiled with JetBrains decompiler
// Type: FSM.UCMainButton
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCMainButton : UCBase
  {
    private IContainer components;
    private Enums.MenuTypes _MenuType;
    private bool _IAmSelected;

    public UCMainButton()
    {
      this._MenuType = Enums.MenuTypes.NONE;
      this._IAmSelected = false;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual PictureBox picIcon
    {
      get
      {
        return this._picIcon;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.CtrlMouseEnter);
        EventHandler eventHandler2 = new EventHandler(this.CtrlMouseLeave);
        EventHandler eventHandler3 = new EventHandler(this.CtrlClick);
        PictureBox picIcon1 = this._picIcon;
        if (picIcon1 != null)
        {
          picIcon1.MouseEnter -= eventHandler1;
          picIcon1.MouseLeave -= eventHandler2;
          picIcon1.Click -= eventHandler3;
        }
        this._picIcon = value;
        PictureBox picIcon2 = this._picIcon;
        if (picIcon2 == null)
          return;
        picIcon2.MouseEnter += eventHandler1;
        picIcon2.MouseLeave += eventHandler2;
        picIcon2.Click += eventHandler3;
      }
    }

    internal virtual Label lblMenuCaption
    {
      get
      {
        return this._lblMenuCaption;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.CtrlMouseEnter);
        EventHandler eventHandler2 = new EventHandler(this.CtrlMouseLeave);
        EventHandler eventHandler3 = new EventHandler(this.CtrlClick);
        Label lblMenuCaption1 = this._lblMenuCaption;
        if (lblMenuCaption1 != null)
        {
          lblMenuCaption1.MouseEnter -= eventHandler1;
          lblMenuCaption1.MouseLeave -= eventHandler2;
          lblMenuCaption1.Click -= eventHandler3;
        }
        this._lblMenuCaption = value;
        Label lblMenuCaption2 = this._lblMenuCaption;
        if (lblMenuCaption2 == null)
          return;
        lblMenuCaption2.MouseEnter += eventHandler1;
        lblMenuCaption2.MouseLeave += eventHandler2;
        lblMenuCaption2.Click += eventHandler3;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ResourceManager resourceManager = new ResourceManager(typeof (UCMainButton));
      this.picIcon = new PictureBox();
      this.lblMenuCaption = new Label();
      this.SuspendLayout();
      this.picIcon.BackgroundImage = (Image) resourceManager.GetObject("picIcon.BackgroundImage");
      this.picIcon.Cursor = Cursors.Hand;
      this.picIcon.Dock = DockStyle.Left;
      this.picIcon.Location = new System.Drawing.Point(0, 0);
      this.picIcon.Name = "picIcon";
      this.picIcon.Size = new Size(40, 32);
      this.picIcon.SizeMode = PictureBoxSizeMode.CenterImage;
      this.picIcon.TabIndex = 0;
      this.picIcon.TabStop = false;
      this.lblMenuCaption.BackColor = Color.Transparent;
      this.lblMenuCaption.Cursor = Cursors.Hand;
      this.lblMenuCaption.Dock = DockStyle.Fill;
      this.lblMenuCaption.Font = new Font("Verdana", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMenuCaption.ForeColor = Color.White;
      this.lblMenuCaption.Location = new System.Drawing.Point(40, 0);
      this.lblMenuCaption.Name = "lblMenuCaption";
      this.lblMenuCaption.Size = new Size(120, 32);
      this.lblMenuCaption.TabIndex = 3;
      this.lblMenuCaption.Text = "SET IN CODE";
      this.lblMenuCaption.TextAlign = ContentAlignment.MiddleLeft;
      this.BackgroundImage = (Image) resourceManager.GetObject("$this.BackgroundImage");
      this.Controls.Add((Control) this.lblMenuCaption);
      this.Controls.Add((Control) this.picIcon);
      this.Name = nameof (UCMainButton);
      this.Size = new Size(160, 32);
      this.ResumeLayout(false);
    }

    public event UCMainButton.ButtonClickedEventHandler ButtonClicked;

    [Category("MenuItem")]
    [Description("Menu Caption Text")]
    public string Caption
    {
      get
      {
        return this.lblMenuCaption.Text;
      }
      set
      {
        this.lblMenuCaption.Text = value;
      }
    }

    [Category("MenuItem")]
    [Description("Menu Image")]
    public Image Image
    {
      get
      {
        return this.picIcon.Image;
      }
      set
      {
        this.picIcon.Image = value;
      }
    }

    [Category("MenuItem")]
    [Description("Menu Type")]
    public Enums.MenuTypes MenuType
    {
      get
      {
        return this._MenuType;
      }
      set
      {
        this._MenuType = value;
      }
    }

    public bool IAmSelected
    {
      get
      {
        return this._IAmSelected;
      }
      set
      {
        this._IAmSelected = value;
        if (value)
          this.State = Enums.MenuImageTypes.Selected;
        else
          this.State = Enums.MenuImageTypes.Unselected;
      }
    }

    private Enums.MenuImageTypes PreviousState
    {
      get
      {
        return this.IAmSelected ? Enums.MenuImageTypes.Selected : Enums.MenuImageTypes.Unselected;
      }
    }

    private Enums.MenuImageTypes State
    {
      set
      {
        switch (value)
        {
          case Enums.MenuImageTypes.NONE:
            this.picIcon.BackgroundImage = (Image) new Bitmap(Helper.GetStream("Unselected.bmp"));
            this.BackgroundImage = (Image) new Bitmap(Helper.GetStream("Unselected.bmp"));
            break;
          case Enums.MenuImageTypes.Unselected:
            this.picIcon.BackgroundImage = (Image) new Bitmap(Helper.GetStream("Unselected.bmp"));
            this.BackgroundImage = (Image) new Bitmap(Helper.GetStream("Unselected.bmp"));
            break;
          case Enums.MenuImageTypes.Selected:
            this.picIcon.BackgroundImage = (Image) new Bitmap(Helper.GetStream("Selected.bmp"));
            this.BackgroundImage = (Image) new Bitmap(Helper.GetStream("Selected.bmp"));
            break;
          case Enums.MenuImageTypes.Hover:
            this.picIcon.BackgroundImage = (Image) new Bitmap(Helper.GetStream("Hover.bmp"));
            this.BackgroundImage = (Image) new Bitmap(Helper.GetStream("Hover.bmp"));
            break;
        }
      }
    }

    private void CtrlMouseEnter(object sender, EventArgs e)
    {
      this.State = Enums.MenuImageTypes.Hover;
    }

    private void CtrlMouseLeave(object sender, EventArgs e)
    {
      this.State = this.PreviousState;
    }

    private void CtrlClick(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      UCMainButton.ButtonClickedEventHandler buttonClickedEvent = this.ButtonClickedEvent;
      if (buttonClickedEvent == null)
        return;
      buttonClickedEvent(this.MenuType);
    }

    public delegate void ButtonClickedEventHandler(Enums.MenuTypes MenuType);
  }
}
