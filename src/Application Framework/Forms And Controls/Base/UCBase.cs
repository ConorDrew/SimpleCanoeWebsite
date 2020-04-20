using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCBase : UserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCBase() : base()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

        }

        // UserControl overrides dispose to clean up the component list.
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
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            // 
            // CTRLBase
            // 
            AutoScroll = true;
            BackColor = Color.White;
            Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Name = "CTRLBase";
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void LoadBaseControl(Control ctrl)
        {
            Dock = DockStyle.Fill;
            _FormButtons = new ArrayList();
            LoopControls(ctrl);
            SetupButtonMouseOvers();
        }

        private void LoopControls(Control controlToLoop)
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
                    ((Button)control).FlatStyle = FlatStyle.Standard;
                    ((Button)control).Cursor = Cursors.Hand;
                    ((Button)control).UseVisualStyleBackColor = false;
                    ((Button)control).BackColor = SystemColors.Control;
                    ((Button)control).AccessibleDescription = ((Button)control).Text;
                    FormButtons.Add(control);
                }
                else if ((control.GetType().Name ?? "") == "ComboBox")
                {
                    ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                    ((ComboBox)control).Cursor = Cursors.Hand;
                }
                else if ((control.GetType().Name ?? "") == "CheckBox")
                {
                    ((CheckBox)control).FlatStyle = FlatStyle.System;
                    ((CheckBox)control).Cursor = Cursors.Hand;
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

        private void CreateHover(object sender, EventArgs e)
        {
            Button argbtn = (Button)sender;
            Entity.Sys.Helper.Setup_Button(ref argbtn, ((Button)sender).AccessibleDescription);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}