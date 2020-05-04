using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCFleetEquipment : UCBase, IUserControl
    {
        public UCFleetEquipment() : base()
        {
            base.Load += UCVan_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
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

        private GroupBox _grpVan;

        private Label _lblName;

        internal Label lblName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblName != null)
                {
                }

                _lblName = value;
                if (_lblName != null)
                {
                }
            }
        }

        private TextBox _txtCost;

        internal TextBox txtCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCost != null)
                {
                }

                _txtCost = value;
                if (_txtCost != null)
                {
                }
            }
        }

        private Label _lblCost;

        private RichTextBox _txtDescription;

        internal RichTextBox txtDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDescription != null)
                {
                }

                _txtDescription = value;
                if (_txtDescription != null)
                {
                }
            }
        }

        private Label _lblDescription;

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpVan = new GroupBox();
            _lblName = new Label();
            _txtCost = new TextBox();
            _lblCost = new Label();
            _txtName = new TextBox();
            _lblDescription = new Label();
            _txtDescription = new RichTextBox();
            _grpVan.SuspendLayout();
            SuspendLayout();
            //
            // grpVan
            //
            _grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVan.Controls.Add(_txtDescription);
            _grpVan.Controls.Add(_lblDescription);
            _grpVan.Controls.Add(_txtName);
            _grpVan.Controls.Add(_lblName);
            _grpVan.Controls.Add(_txtCost);
            _grpVan.Controls.Add(_lblCost);
            _grpVan.Location = new Point(12, 13);
            _grpVan.Name = "grpVan";
            _grpVan.Size = new Size(415, 151);
            _grpVan.TabIndex = 3;
            _grpVan.TabStop = false;
            _grpVan.Text = "Details";
            //
            // lblName
            //
            _lblName.Location = new Point(12, 33);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(58, 20);
            _lblName.TabIndex = 47;
            _lblName.Text = "Name";
            //
            // txtCost
            //
            _txtCost.Location = new Point(299, 30);
            _txtCost.MaxLength = 10;
            _txtCost.Name = "txtCost";
            _txtCost.Size = new Size(77, 21);
            _txtCost.TabIndex = 3;
            //
            // lblCost
            //
            _lblCost.Location = new Point(241, 33);
            _lblCost.Name = "lblCost";
            _lblCost.Size = new Size(73, 20);
            _lblCost.TabIndex = 45;
            _lblCost.Text = "Cost";
            //
            // txtName
            //
            _txtName.Location = new Point(95, 30);
            _txtName.MaxLength = 20;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(131, 21);
            _txtName.TabIndex = 1;
            //
            // lblDescription
            //
            _lblDescription.Location = new Point(12, 69);
            _lblDescription.Name = "lblDescription";
            _lblDescription.Size = new Size(84, 20);
            _lblDescription.TabIndex = 49;
            _lblDescription.Text = "Description";
            //
            // txtDescription
            //
            _txtDescription.Location = new Point(95, 69);
            _txtDescription.Name = "txtDescription";
            _txtDescription.Size = new Size(281, 62);
            _txtDescription.TabIndex = 50;
            _txtDescription.Text = "";
            //
            // UCFleetEquipment
            //
            BackColor = Color.White;
            Controls.Add(_grpVan);
            Name = "UCFleetEquipment";
            Size = new Size(439, 179);
            _grpVan.ResumeLayout(false);
            _grpVan.PerformLayout();
            ResumeLayout(false);
        }

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentEquipment;
            }
        }

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.FleetVans.FleetEquipment _currentEquipment;

        public Entity.FleetVans.FleetEquipment CurrentEquipment
        {
            get
            {
                return _currentEquipment;
            }

            set
            {
                _currentEquipment = value;
                if (_currentEquipment is null)
                {
                    _currentEquipment = new Entity.FleetVans.FleetEquipment();
                    _currentEquipment.Exists = false;
                }
            }
        }

        private void UCVan_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        // Public Sub PopulateQuantities(ByVal VanID As Integer)
        // PartQuantitiesDataview = DB.Part.PartLocations_GetForVanHM(VanID)
        // End Sub

        public void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentEquipment = App.DB.FleetEquipment.Get(ID);
            }

            txtName.Text = CurrentEquipment.Name;
            txtCost.Text = CurrentEquipment.Cost.ToString();
            txtDescription.Text = CurrentEquipment.Description;
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentEquipment.IgnoreExceptionsOnSetMethods = true;
                CurrentEquipment.SetName = txtName.Text.Trim();
                CurrentEquipment.SetCost = txtCost.Text.Trim();
                CurrentEquipment.SetDescription = txtDescription.Text.Trim();
                var cV = new Entity.FleetVans.FleetEquipmentValidator();
                cV.Validate(CurrentEquipment);
                if (CurrentEquipment.Exists)
                {
                    App.DB.FleetEquipment.Update(CurrentEquipment);
                }
                else
                {
                    CurrentEquipment = App.DB.FleetEquipment.Insert(CurrentEquipment);
                }

                App.MainForm.RefreshEntity(CurrentEquipment.EquipmentID);
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}