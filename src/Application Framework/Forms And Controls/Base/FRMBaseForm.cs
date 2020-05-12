using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMBaseForm : Form, IBaseForm
    {
        public FRMBaseForm() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components is null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        //internal PictureBox picHeader
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    get
        //    {
        //        return _picHeader;
        //    }

        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (_picHeader != null)
        //        {
        //            _picHeader.MouseHover -= picHeader_MouseHover;
        //        }

        //        _picHeader = value;
        //        if (_picHeader != null)
        //        {
        //            _picHeader.MouseHover += picHeader_MouseHover;
        //        }
        //    }
        //}

        private PictureBox _picHeaderCont;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMBaseForm));
            this._picHeaderCont = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._picHeaderCont)).BeginInit();
            this.SuspendLayout();
            //
            // _picHeaderCont
            //
            this._picHeaderCont.Dock = System.Windows.Forms.DockStyle.Top;
            this._picHeaderCont.Location = new System.Drawing.Point(0, 0);
            this._picHeaderCont.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this._picHeaderCont.Name = "_picHeaderCont";
            this._picHeaderCont.Size = new System.Drawing.Size(528, 45);
            this._picHeaderCont.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picHeaderCont.TabIndex = 1;
            this._picHeaderCont.TabStop = false;
            //
            // FRMBaseForm
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 382);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FRMBaseForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Field Service Management";
            ((System.ComponentModel.ISupportInitialize)(this._picHeaderCont)).EndInit();
            this.ResumeLayout(false);
        }

        private ArrayList _FormButtons = null;

        public ArrayList FormButtons
        {
            get
            {
                return _FormButtons;
            }

            set
            {
                _FormButtons = value;
            }
        }

        public void LoadForm(object sender, EventArgs e, IForm frm)
        {
            _FormButtons = new ArrayList();
            if (App.IsRFT)
            {
                this.Icon = new Icon("Resources\\rft_logo.ico");
            }
            else if (App.IsGasway)
            {
                this.Icon = new Icon("Resources\\GW_Icon.ico");
            }
            else if (App.IsBlueflame)
            {
                this.Icon = new Icon("Resources\\Blueflame_Icon.ico");
            }

            LoopControls((Control)frm);
            SetupButtonMouseOvers();
        }

        // Added to allow forms that do not implement IForm
        public void LoadForm(Form frm)
        {
            _FormButtons = new ArrayList();
            if (App.IsRFT)
            {
                this.Icon = new Icon("Resources\\rft_logo.ico");
            }
            else if (App.IsGasway)
            {
                this.Icon = new Icon("Resources\\GW_Icon.ico");
            }
            else if (App.IsBlueflame)
            {
                this.Icon = new Icon("Resources\\Blueflame_Icon.ico");
            }

            LoopControls((Control)frm);
            SetupButtonMouseOvers();
        }

        public void LoopControls(Control controlToLoop)
        {
            foreach (Control control in controlToLoop.Controls)
            {
                if ((control.GetType().Name ?? "") == "TabControl")
                {
                    LoopControls(control);
                }
                else if ((control.GetType().Name ?? "") == "TabPage")
                {
                    ((TabPage)control).BackColor = Color.White;
                    LoopControls(control);
                }
                else if ((control.GetType().Name ?? "") == "GroupBox")
                {
                    ((GroupBox)control).FlatStyle = FlatStyle.System;
                    LoopControls(control);
                }
                else if ((control.GetType().Name ?? "") == "Panel")
                {
                    LoopControls(control);
                }
                else if ((control.GetType().Name ?? "") == "Button")
                {
                    if ((((Button)control).Name.Substring(0, 5) ?? "") == "btnxx")
                    {
                    }
                    else
                    {
                        ((Button)control).FlatStyle = FlatStyle.Standard;
                        ((Button)control).Cursor = Cursors.Hand;
                        ((Button)control).AccessibleDescription = ((Button)control).Text;
                        ((Button)control).UseVisualStyleBackColor = false;
                        ((Button)control).BackColor = SystemColors.Control;
                        FormButtons.Add(control);
                    }
                }
                else if ((control.GetType().Name ?? "") == "ComboBox")
                {
                    if ((((ComboBox)control).Name ?? "") == "cbotypeWiz")
                    {
                    }
                    else
                    {
                        ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                        ((ComboBox)control).Cursor = Cursors.Hand;
                    }
                }
                else if ((control.GetType().Name ?? "") == "CheckBox")
                {
                    ((CheckBox)control).FlatStyle = FlatStyle.System;
                    ((CheckBox)control).Cursor = Cursors.Hand;
                }
                else if ((control.GetType().Name ?? "") == "RadioButton")
                {
                    ((RadioButton)control).FlatStyle = FlatStyle.System;
                    ((RadioButton)control).Cursor = Cursors.Hand;
                }
                else if ((control.GetType().Name ?? "") == "NumericUpDown")
                {
                    ((NumericUpDown)control).Cursor = Cursors.Hand;
                }
                else if ((control.GetType().Name ?? "") == "DataGrid")
                {
                    Entity.Sys.Helper.SetUpDataGrid((DataGrid)control);
                    var tStyle = ((DataGrid)control).TableStyles[0];
                    tStyle.ReadOnly = true;
                    tStyle.MappingName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString();
                    ((DataGrid)control).TableStyles.Add(tStyle);
                }
                else if ((control.GetType().Name ?? "") == "UCButton")
                {
                    ((Button)control).AccessibleDescription = ((Button)control).Text;
                    FormButtons.Add(control);
                }
                else if (control.GetType().IsSubclassOf(typeof(UCBase)))
                {
                    LoopControls((UCBase)control);
                }
            }
        }

        public void SetupButtonMouseOvers()
        {
            foreach (object btn in FormButtons)
                ((Button)btn).MouseHover += CreateHover;
        }

        public void CreateHover(object sender, EventArgs e)
        {
            Button argbtn = (Button)sender;
            Entity.Sys.Helper.Setup_Button(ref argbtn, ((Button)sender).AccessibleDescription);
        }

        private object[] _FormParameters = null;

        public object[] SetFormParameters
        {
            set
            {
                _FormParameters = value;
            }
        }

        public object GetParameter
        {
            get
            {
                return null;
            }
        }

        public object get_GetParameter(int indexOfArrayToGet = 0)
        {
            if (_FormParameters is null)
            {
                return null;
            }

            if (_FormParameters.Length == 0)
            {
                return null;
            }

            if (indexOfArrayToGet > _FormParameters.Length - 1)
            {
                return null;
            }

            return this._FormParameters[indexOfArrayToGet];
        }

        public int GetParameterCount
        {
            get
            {
                return _FormParameters.Length;
            }
        }

        //public void picHeader_MouseHover(object sender, EventArgs e)
        //{
        //    var hoverToolTip = new ToolTip();
        //    hoverToolTip.SetToolTip(picHeader, App.TheSystem.Description);
        //}
    }
}