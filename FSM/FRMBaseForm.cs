// Decompiled with JetBrains decompiler
// Type: FSM.FRMBaseForm
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMBaseForm : Form, IBaseForm
  {
    private IContainer components;
    private ArrayList _FormButtons;
    private Array _FormParameters;

    public FRMBaseForm()
    {
      this._FormButtons = (ArrayList) null;
      this._FormParameters = (Array) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual PictureBox picHeader
    {
      get
      {
        return this._picHeader;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.picHeader_MouseHover);
        PictureBox picHeader1 = this._picHeader;
        if (picHeader1 != null)
          picHeader1.MouseHover -= eventHandler;
        this._picHeader = value;
        PictureBox picHeader2 = this._picHeader;
        if (picHeader2 == null)
          return;
        picHeader2.MouseHover += eventHandler;
      }
    }

    internal virtual PictureBox picHeaderCont { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMBaseForm));
      this.picHeader = new PictureBox();
      this.picHeaderCont = new PictureBox();
      ((ISupportInitialize) this.picHeader).BeginInit();
      ((ISupportInitialize) this.picHeaderCont).BeginInit();
      this.SuspendLayout();
      this.picHeader.Location = new System.Drawing.Point(0, 0);
      this.picHeader.Margin = new Padding(0, 0, 3, 0);
      this.picHeader.Name = "picHeader";
      this.picHeader.Padding = new Padding(5, 0, 0, 0);
      this.picHeader.Size = new Size(55, 50);
      this.picHeader.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picHeader.TabIndex = 0;
      this.picHeader.TabStop = false;
      this.picHeaderCont.Dock = DockStyle.Top;
      this.picHeaderCont.Location = new System.Drawing.Point(0, 0);
      this.picHeaderCont.Margin = new Padding(3, 0, 3, 3);
      this.picHeaderCont.Name = "picHeaderCont";
      this.picHeaderCont.Size = new Size(528, 45);
      this.picHeaderCont.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picHeaderCont.TabIndex = 1;
      this.picHeaderCont.TabStop = false;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.AutoScroll = true;
      this.BackColor = Color.White;
      this.ClientSize = new Size(528, 382);
      this.Controls.Add((Control) this.picHeader);
      this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.Name = nameof (FRMBaseForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Field Service Management";
      ((ISupportInitialize) this.picHeader).EndInit();
      ((ISupportInitialize) this.picHeaderCont).EndInit();
      this.ResumeLayout(false);
    }

    public ArrayList FormButtons
    {
      get
      {
        return this._FormButtons;
      }
      set
      {
        this._FormButtons = value;
      }
    }

    public void LoadForm(object sender, EventArgs e, IForm frm)
    {
      this._FormButtons = new ArrayList();
      if (App.IsRFT)
        this.picHeader.Image = (Image) FSM.My.Resources.Resources.RFT;
      else if (App.IsGasway)
        this.picHeader.Image = (Image) FSM.My.Resources.Resources.GaswayHO;
      else if (App.IsBlueflame)
        this.picHeader.Image = (Image) FSM.My.Resources.Resources.Blueflame;
      this.LoopControls((Control) frm);
      this.SetupButtonMouseOvers();
    }

    public void LoadForm(Form frm)
    {
      this._FormButtons = new ArrayList();
      if (App.IsRFT)
        this.picHeader.Image = (Image) FSM.My.Resources.Resources.RFT;
      else if (App.IsGasway)
        this.picHeader.Image = (Image) FSM.My.Resources.Resources.GaswayHO;
      else if (App.IsBlueflame)
        this.picHeader.Image = (Image) FSM.My.Resources.Resources.Blueflame;
      this.LoopControls((Control) frm);
      this.SetupButtonMouseOvers();
    }

    void IBaseForm.LoopControls(Control controlToLoop)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = controlToLoop.Controls.GetEnumerator();
        while (enumerator.MoveNext())
        {
          Control current = (Control) enumerator.Current;
          if (Operators.CompareString(current.GetType().Name, "TabControl", false) == 0)
            this.LoopControls(current);
          else if (Operators.CompareString(current.GetType().Name, "TabPage", false) == 0)
          {
            ((TabPage) current).BackColor = Color.White;
            this.LoopControls(current);
          }
          else if (Operators.CompareString(current.GetType().Name, "GroupBox", false) == 0)
          {
            ((GroupBox) current).FlatStyle = FlatStyle.System;
            this.LoopControls(current);
          }
          else if (Operators.CompareString(current.GetType().Name, "Panel", false) == 0)
            this.LoopControls(current);
          else if (Operators.CompareString(current.GetType().Name, "Button", false) == 0)
          {
            if (Operators.CompareString(current.Name.Substring(0, 5), "btnxx", false) != 0)
            {
              ((ButtonBase) current).FlatStyle = FlatStyle.Standard;
              current.Cursor = Cursors.Hand;
              current.AccessibleDescription = ((ButtonBase) current).Text;
              ((ButtonBase) current).UseVisualStyleBackColor = false;
              ((ButtonBase) current).BackColor = SystemColors.Control;
              this.FormButtons.Add((object) current);
            }
          }
          else if (Operators.CompareString(current.GetType().Name, "ComboBox", false) == 0)
          {
            if (Operators.CompareString(current.Name, "cbotypeWiz", false) != 0)
            {
              ((ComboBox) current).DropDownStyle = ComboBoxStyle.DropDownList;
              current.Cursor = Cursors.Hand;
            }
          }
          else if (Operators.CompareString(current.GetType().Name, "CheckBox", false) == 0)
          {
            ((ButtonBase) current).FlatStyle = FlatStyle.System;
            current.Cursor = Cursors.Hand;
          }
          else if (Operators.CompareString(current.GetType().Name, "RadioButton", false) == 0)
          {
            ((ButtonBase) current).FlatStyle = FlatStyle.System;
            current.Cursor = Cursors.Hand;
          }
          else if (Operators.CompareString(current.GetType().Name, "NumericUpDown", false) == 0)
            current.Cursor = Cursors.Hand;
          else if (Operators.CompareString(current.GetType().Name, "DataGrid", false) == 0)
          {
            Helper.SetUpDataGrid((DataGrid) current, false);
            DataGridTableStyle tableStyle = ((DataGrid) current).TableStyles[0];
            tableStyle.ReadOnly = true;
            tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
            ((DataGrid) current).TableStyles.Add(tableStyle);
          }
          else if (Operators.CompareString(current.GetType().Name, "UCButton", false) == 0)
          {
            current.AccessibleDescription = ((ButtonBase) current).Text;
            this.FormButtons.Add((object) current);
          }
          else if (current.GetType().IsSubclassOf(typeof (UCBase)))
            this.LoopControls(current);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public void SetupButtonMouseOvers()
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.FormButtons.GetEnumerator();
        while (enumerator.MoveNext())
          ((Control) RuntimeHelpers.GetObjectValue(enumerator.Current)).MouseHover += new EventHandler(this.CreateHover);
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    void IBaseForm.CreateHover(object sender, EventArgs e)
    {
      Button btn = (Button) sender;
      Helper.Setup_Button(ref btn, ((Control) sender).AccessibleDescription);
      sender = (object) btn;
    }

    public Array SetFormParameters
    {
      set
      {
        this._FormParameters = value;
      }
    }

    public object get_GetParameter(int indexOfArrayToGet = 0)
    {
      if (this._FormParameters == null || this._FormParameters.Length == 0 || indexOfArrayToGet > checked (this._FormParameters.Length - 1))
        return (object) null;
      return NewLateBinding.LateIndexGet((object) this._FormParameters, new object[1]
      {
        (object) indexOfArrayToGet
      }, (string[]) null);
    }

    public int GetParameterCount
    {
      get
      {
        return this._FormParameters.Length;
      }
    }

    private void picHeader_MouseHover(object sender, EventArgs e)
    {
      new ToolTip().SetToolTip((Control) this.picHeader, App.TheSystem.Description);
    }
  }
}
