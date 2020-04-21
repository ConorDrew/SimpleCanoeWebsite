using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCMainButton : UCBase
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCMainButton() : base()
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
        private IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private PictureBox _picIcon;

        internal PictureBox picIcon
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picIcon;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picIcon != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _picIcon.MouseEnter -= CtrlMouseEnter;
                    _picIcon.MouseLeave -= CtrlMouseLeave;
                    _picIcon.Click -= CtrlClick;
                }

                _picIcon = value;
                if (_picIcon != null)
                {
                    _picIcon.MouseEnter += CtrlMouseEnter;
                    _picIcon.MouseLeave += CtrlMouseLeave;
                    _picIcon.Click += CtrlClick;
                }
            }
        }

        private Label _lblMenuCaption;

        internal Label lblMenuCaption
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMenuCaption;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMenuCaption != null)
                {
                    _lblMenuCaption.MouseEnter -= CtrlMouseEnter;
                    _lblMenuCaption.MouseLeave -= CtrlMouseLeave;
                    _lblMenuCaption.Click -= CtrlClick;
                }

                _lblMenuCaption = value;
                if (_lblMenuCaption != null)
                {
                    _lblMenuCaption.MouseEnter += CtrlMouseEnter;
                    _lblMenuCaption.MouseLeave += CtrlMouseLeave;
                    _lblMenuCaption.Click += CtrlClick;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.Resources.ResourceManager(typeof(UCMainButton));
            _picIcon = new PictureBox();
            _picIcon.MouseEnter += new EventHandler(CtrlMouseEnter);
            _picIcon.MouseLeave += new EventHandler(CtrlMouseLeave);
            _picIcon.Click += new EventHandler(CtrlClick);
            _lblMenuCaption = new Label();
            _lblMenuCaption.MouseEnter += new EventHandler(CtrlMouseEnter);
            _lblMenuCaption.MouseLeave += new EventHandler(CtrlMouseLeave);
            _lblMenuCaption.Click += new EventHandler(CtrlClick);
            SuspendLayout();
            //
            // picIcon
            //
            _picIcon.BackgroundImage = (Image)resources.GetObject("picIcon.BackgroundImage");
            _picIcon.Cursor = Cursors.Hand;
            _picIcon.Dock = DockStyle.Left;
            _picIcon.Location = new Point(0, 0);
            _picIcon.Name = "picIcon";
            _picIcon.Size = new Size(40, 32);
            _picIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            _picIcon.TabIndex = 0;
            _picIcon.TabStop = false;
            //
            // lblMenuCaption
            //
            _lblMenuCaption.BackColor = Color.Transparent;
            _lblMenuCaption.Cursor = Cursors.Hand;
            _lblMenuCaption.Dock = DockStyle.Fill;
            _lblMenuCaption.Font = new Font("Verdana", 8.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMenuCaption.ForeColor = Color.White;
            _lblMenuCaption.Location = new Point(40, 0);
            _lblMenuCaption.Name = "lblMenuCaption";
            _lblMenuCaption.Size = new Size(120, 32);
            _lblMenuCaption.TabIndex = 3;
            _lblMenuCaption.Text = "SET IN CODE";
            _lblMenuCaption.TextAlign = ContentAlignment.MiddleLeft;
            //
            // UCMainButton
            //
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(_lblMenuCaption);
            Controls.Add(_picIcon);
            Name = "UCMainButton";
            Size = new Size(160, 32);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        public event ButtonClickedEventHandler ButtonClicked;

        public delegate void ButtonClickedEventHandler(Entity.Sys.Enums.MenuTypes MenuType);

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        [Category("MenuItem")]
        [Description("Menu Caption Text")]
        public string Caption
        {
            get
            {
                return lblMenuCaption.Text;
            }

            set
            {
                lblMenuCaption.Text = value;
            }
        }

        [Category("MenuItem")]
        [Description("Menu Image")]
        public Image Image
        {
            get
            {
                return picIcon.Image;
            }

            set
            {
                picIcon.Image = value;
            }
        }

        private Entity.Sys.Enums.MenuTypes _MenuType = Entity.Sys.Enums.MenuTypes.NONE;

        [Category("MenuItem")]
        [Description("Menu Type")]
        public Entity.Sys.Enums.MenuTypes MenuType
        {
            get
            {
                return _MenuType;
            }

            set
            {
                _MenuType = value;
            }
        }

        private bool _IAmSelected = false;

        public bool IAmSelected
        {
            get
            {
                return _IAmSelected;
            }

            set
            {
                _IAmSelected = value;
                if (value)
                {
                    State = Entity.Sys.Enums.MenuImageTypes.Selected;
                }
                else
                {
                    State = Entity.Sys.Enums.MenuImageTypes.Unselected;
                }
            }
        }

        private Entity.Sys.Enums.MenuImageTypes PreviousState
        {
            get
            {
                if (IAmSelected)
                {
                    return Entity.Sys.Enums.MenuImageTypes.Selected;
                }
                else
                {
                    return Entity.Sys.Enums.MenuImageTypes.Unselected;
                }
            }
        }

        private Entity.Sys.Enums.MenuImageTypes State
        {
            set
            {
                switch (value)
                {
                    case Entity.Sys.Enums.MenuImageTypes.NONE:
                        {
                            picIcon.BackgroundImage = new Bitmap(Entity.Sys.Helper.GetStream("Unselected.bmp"));
                            BackgroundImage = new Bitmap(Entity.Sys.Helper.GetStream("Unselected.bmp"));
                            break;
                        }

                    case Entity.Sys.Enums.MenuImageTypes.Unselected:
                        {
                            picIcon.BackgroundImage = new Bitmap(Entity.Sys.Helper.GetStream("Unselected.bmp"));
                            BackgroundImage = new Bitmap(Entity.Sys.Helper.GetStream("Unselected.bmp"));
                            break;
                        }

                    case Entity.Sys.Enums.MenuImageTypes.Selected:
                        {
                            picIcon.BackgroundImage = new Bitmap(Entity.Sys.Helper.GetStream("Selected.bmp"));
                            BackgroundImage = new Bitmap(Entity.Sys.Helper.GetStream("Selected.bmp"));
                            break;
                        }

                    case Entity.Sys.Enums.MenuImageTypes.Hover:
                        {
                            picIcon.BackgroundImage = new Bitmap(Entity.Sys.Helper.GetStream("Hover.bmp"));
                            BackgroundImage = new Bitmap(Entity.Sys.Helper.GetStream("Hover.bmp"));
                            break;
                        }
                }
            }
        }

        private void CtrlMouseEnter(object sender, EventArgs e)
        {
            State = Entity.Sys.Enums.MenuImageTypes.Hover;
        }

        private void CtrlMouseLeave(object sender, EventArgs e)
        {
            State = PreviousState;
        }

        private void CtrlClick(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(MenuType);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}