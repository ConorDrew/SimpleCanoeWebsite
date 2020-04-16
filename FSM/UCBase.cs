// Decompiled with JetBrains decompiler
// Type: FSM.UCBase
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
  public class UCBase : UserControl
  {
    private IContainer components;
    private ArrayList _FormButtons;

    public UCBase()
    {
      this._FormButtons = (ArrayList) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.AutoScroll = true;
      this.BackColor = Color.White;
      this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = "CTRLBase";
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

    public void LoadBaseControl(Control ctrl)
    {
      this.Dock = DockStyle.Fill;
      this._FormButtons = new ArrayList();
      this.LoopControls(ctrl);
      this.SetupButtonMouseOvers();
    }

    private void LoopControls(Control controlToLoop)
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
            ((ButtonBase) current).FlatStyle = FlatStyle.Standard;
            current.Cursor = Cursors.Hand;
            ((ButtonBase) current).UseVisualStyleBackColor = false;
            ((ButtonBase) current).BackColor = SystemColors.Control;
            current.AccessibleDescription = ((ButtonBase) current).Text;
            this.FormButtons.Add((object) current);
          }
          else if (Operators.CompareString(current.GetType().Name, "ComboBox", false) == 0)
          {
            ((ComboBox) current).DropDownStyle = ComboBoxStyle.DropDownList;
            current.Cursor = Cursors.Hand;
          }
          else if (Operators.CompareString(current.GetType().Name, "CheckBox", false) == 0)
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

    private void CreateHover(object sender, EventArgs e)
    {
      Button btn = (Button) sender;
      Helper.Setup_Button(ref btn, ((Control) sender).AccessibleDescription);
      sender = (object) btn;
    }
  }
}
