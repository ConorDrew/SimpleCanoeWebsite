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

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private PictureBox _picHeader;

        internal PictureBox picHeader
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picHeader;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picHeader != null)
                {
                    _picHeader.MouseHover -= picHeader_MouseHover;
                }

                _picHeader = value;
                if (_picHeader != null)
                {
                    _picHeader.MouseHover += picHeader_MouseHover;
                }
            }
        }

        private PictureBox _picHeaderCont;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMBaseForm));
            _picHeader = new PictureBox();
            _picHeader.MouseHover += new EventHandler(picHeader_MouseHover);
            _picHeaderCont = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)_picHeader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picHeaderCont).BeginInit();
            SuspendLayout();
            //
            // picHeader
            //
            _picHeader.Location = new Point(0, 0);
            _picHeader.Margin = new Padding(0, 0, 3, 0);
            _picHeader.Name = "picHeader";
            _picHeader.Padding = new Padding(5, 0, 0, 0);
            _picHeader.Size = new Size(55, 50);
            _picHeader.SizeMode = PictureBoxSizeMode.StretchImage;
            _picHeader.TabIndex = 0;
            _picHeader.TabStop = false;
            //
            // picHeaderCont
            //
            _picHeaderCont.Dock = DockStyle.Top;
            _picHeaderCont.Location = new Point(0, 0);
            _picHeaderCont.Margin = new Padding(3, 0, 3, 3);
            _picHeaderCont.Name = "picHeaderCont";
            _picHeaderCont.Size = new Size(528, 45);
            _picHeaderCont.SizeMode = PictureBoxSizeMode.StretchImage;
            _picHeaderCont.TabIndex = 1;
            _picHeaderCont.TabStop = false;
            //
            // FRMBaseForm
            //
            AutoScaleBaseSize = new Size(6, 14);
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(528, 382);
            Controls.Add(_picHeader);
            Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "FRMBaseForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Field Service Management";
            ((System.ComponentModel.ISupportInitialize)_picHeader).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picHeaderCont).EndInit();
            ResumeLayout(false);
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
                picHeader.Image = My.Resources.Resources.RFT;
            }
            else if (App.IsGasway)
            {
                picHeader.Image = My.Resources.Resources.GW_Logo;
            }
            else if (App.IsBlueflame)
            {
                picHeader.Image = My.Resources.Resources.Blueflame;
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
                picHeader.Image = My.Resources.Resources.RFT;
            }
            else if (App.IsGasway)
            {
                picHeader.Image = My.Resources.Resources.GW_Logo;
            }
            else if (App.IsBlueflame)
            {
                picHeader.Image = My.Resources.Resources.Blueflame;
            }

            LoopControls(frm);
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

        public void picHeader_MouseHover(object sender, EventArgs e)
        {
            var hoverToolTip = new ToolTip();
            hoverToolTip.SetToolTip(picHeader, App.TheSystem.Description);
        }
    }
}