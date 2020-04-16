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
            this._FormButtons = (ArrayList)null;
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
            this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
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
            foreach (Control control in controlToLoop.Controls)
            {
                if (Operators.CompareString(control.GetType().Name, "TabControl", false) == 0)
                    this.LoopControls(control);
                else if (Operators.CompareString(control.GetType().Name, "TabPage", false) == 0)
                {
                    ((TabPage)control).BackColor = Color.White;
                    this.LoopControls(control);
                }
                else if (Operators.CompareString(control.GetType().Name, "GroupBox", false) == 0)
                {
                    ((GroupBox)control).FlatStyle = FlatStyle.System;
                    this.LoopControls(control);
                }
                else if (Operators.CompareString(control.GetType().Name, "Panel", false) == 0)
                    this.LoopControls(control);
                else if (Operators.CompareString(control.GetType().Name, "Button", false) == 0)
                {
                    ((ButtonBase)control).FlatStyle = FlatStyle.Standard;
                    control.Cursor = Cursors.Hand;
                    ((ButtonBase)control).UseVisualStyleBackColor = false;
                    ((ButtonBase)control).BackColor = SystemColors.Control;
                    control.AccessibleDescription = ((ButtonBase)control).Text;
                    this.FormButtons.Add((object)control);
                }
                else if (Operators.CompareString(control.GetType().Name, "ComboBox", false) == 0)
                {
                    ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                    control.Cursor = Cursors.Hand;
                }
                else if (Operators.CompareString(control.GetType().Name, "CheckBox", false) == 0)
                {
                    ((ButtonBase)control).FlatStyle = FlatStyle.System;
                    control.Cursor = Cursors.Hand;
                }
                else if (Operators.CompareString(control.GetType().Name, "NumericUpDown", false) == 0)
                    control.Cursor = Cursors.Hand;
                else if (Operators.CompareString(control.GetType().Name, "DataGrid", false) == 0)
                {
                    Helper.SetUpDataGrid((DataGrid)control, false);
                    DataGridTableStyle tableStyle = ((DataGrid)control).TableStyles[0];
                    tableStyle.ReadOnly = true;
                    tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
                    ((DataGrid)control).TableStyles.Add(tableStyle);
                }
                else if (Operators.CompareString(control.GetType().Name, "UCButton", false) == 0)
                {
                    control.AccessibleDescription = ((ButtonBase)control).Text;
                    this.FormButtons.Add((object)control);
                }
                else if (control.GetType().IsSubclassOf(typeof(UCBase)))
                    this.LoopControls(control);
            }
        }

        public void SetupButtonMouseOvers()
        {
            foreach (object btn in FormButtons)
            {
                ((Control)RuntimeHelpers.GetObjectValue(btn)).MouseHover += new EventHandler(this.CreateHover);
            }
        }

        private void CreateHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Helper.Setup_Button(ref btn, ((Control)sender).AccessibleDescription);
            sender = (object)btn;
        }
    }
}