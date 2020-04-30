using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class UCEngineerVan : UCBase, IUserControl
    {
        

        public UCEngineerVan() : base()
        {
            
            
            base.Load += UCEngineerVan_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            var argc = cboEngineerID;
            Combo.SetUpCombo(ref argc, App.DB.Engineer.Engineer_GetAll_IncludeDeleted().Table, "EngineerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _grpEngineerVan;

        internal GroupBox grpEngineerVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineerVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineerVan != null)
                {
                }

                _grpEngineerVan = value;
                if (_grpEngineerVan != null)
                {
                }
            }
        }

        private ComboBox _cboEngineerID;

        internal ComboBox cboEngineerID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineerID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineerID != null)
                {
                }

                _cboEngineerID = value;
                if (_cboEngineerID != null)
                {
                }
            }
        }

        private Label _lblEngineerID;

        internal Label lblEngineerID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngineerID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngineerID != null)
                {
                }

                _lblEngineerID = value;
                if (_lblEngineerID != null)
                {
                }
            }
        }

        private DateTimePicker _dtpStartDateTime;

        internal DateTimePicker dtpStartDateTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpStartDateTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpStartDateTime != null)
                {
                }

                _dtpStartDateTime = value;
                if (_dtpStartDateTime != null)
                {
                }
            }
        }

        private Label _lblStartDateTime;

        internal Label lblStartDateTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStartDateTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStartDateTime != null)
                {
                }

                _lblStartDateTime = value;
                if (_lblStartDateTime != null)
                {
                }
            }
        }

        private DateTimePicker _dtpEndDateTime;

        internal DateTimePicker dtpEndDateTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEndDateTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEndDateTime != null)
                {
                }

                _dtpEndDateTime = value;
                if (_dtpEndDateTime != null)
                {
                }
            }
        }

        private Label _lblEndDateTime;

        internal Label lblEndDateTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEndDateTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEndDateTime != null)
                {
                }

                _lblEndDateTime = value;
                if (_lblEndDateTime != null)
                {
                }
            }
        }

        private CheckBox _chkUntilFurtherNotice;

        internal CheckBox chkUntilFurtherNotice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkUntilFurtherNotice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkUntilFurtherNotice != null)
                {
                    _chkUntilFurtherNotice.CheckedChanged -= chkUntilFurtherNotice_CheckedChanged;
                }

                _chkUntilFurtherNotice = value;
                if (_chkUntilFurtherNotice != null)
                {
                    _chkUntilFurtherNotice.CheckedChanged += chkUntilFurtherNotice_CheckedChanged;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpEngineerVan = new GroupBox();
            _chkUntilFurtherNotice = new CheckBox();
            _chkUntilFurtherNotice.CheckedChanged += new EventHandler(chkUntilFurtherNotice_CheckedChanged);
            _cboEngineerID = new ComboBox();
            _lblEngineerID = new Label();
            _dtpStartDateTime = new DateTimePicker();
            _lblStartDateTime = new Label();
            _dtpEndDateTime = new DateTimePicker();
            _lblEndDateTime = new Label();
            _grpEngineerVan.SuspendLayout();
            SuspendLayout();
            //
            // grpEngineerVan
            //
            _grpEngineerVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineerVan.Controls.Add(_chkUntilFurtherNotice);
            _grpEngineerVan.Controls.Add(_cboEngineerID);
            _grpEngineerVan.Controls.Add(_lblEngineerID);
            _grpEngineerVan.Controls.Add(_dtpStartDateTime);
            _grpEngineerVan.Controls.Add(_lblStartDateTime);
            _grpEngineerVan.Controls.Add(_dtpEndDateTime);
            _grpEngineerVan.Controls.Add(_lblEndDateTime);
            _grpEngineerVan.Location = new Point(8, 8);
            _grpEngineerVan.Name = "grpEngineerVan";
            _grpEngineerVan.Size = new Size(601, 114);
            _grpEngineerVan.TabIndex = 1;
            _grpEngineerVan.TabStop = false;
            _grpEngineerVan.Text = "Main Details";
            //
            // chkUntilFurtherNotice
            //
            _chkUntilFurtherNotice.Location = new Point(408, 88);
            _chkUntilFurtherNotice.Name = "chkUntilFurtherNotice";
            _chkUntilFurtherNotice.Size = new Size(136, 24);
            _chkUntilFurtherNotice.TabIndex = 5;
            _chkUntilFurtherNotice.Text = "Until Further Notice";
            //
            // cboEngineerID
            //
            _cboEngineerID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboEngineerID.Cursor = Cursors.Hand;
            _cboEngineerID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEngineerID.Location = new Point(112, 24);
            _cboEngineerID.Name = "cboEngineerID";
            _cboEngineerID.Size = new Size(480, 21);
            _cboEngineerID.TabIndex = 2;
            _cboEngineerID.Tag = "EngineerVan.EngineerID";
            //
            // lblEngineerID
            //
            _lblEngineerID.Location = new Point(8, 24);
            _lblEngineerID.Name = "lblEngineerID";
            _lblEngineerID.Size = new Size(71, 20);
            _lblEngineerID.TabIndex = 31;
            _lblEngineerID.Text = "Engineer";
            //
            // dtpStartDateTime
            //
            _dtpStartDateTime.CustomFormat = "dd MMMM yyyy HH:mm";
            _dtpStartDateTime.Format = DateTimePickerFormat.Custom;
            _dtpStartDateTime.Location = new Point(112, 56);
            _dtpStartDateTime.Name = "dtpStartDateTime";
            _dtpStartDateTime.Size = new Size(184, 21);
            _dtpStartDateTime.TabIndex = 3;
            _dtpStartDateTime.Tag = "EngineerVan.StartDateTime";
            //
            // lblStartDateTime
            //
            _lblStartDateTime.Location = new Point(8, 56);
            _lblStartDateTime.Name = "lblStartDateTime";
            _lblStartDateTime.Size = new Size(104, 20);
            _lblStartDateTime.TabIndex = 31;
            _lblStartDateTime.Text = "Start Date Time";
            //
            // dtpEndDateTime
            //
            _dtpEndDateTime.CustomFormat = "dd MMMM yyyy HH:mm";
            _dtpEndDateTime.Format = DateTimePickerFormat.Custom;
            _dtpEndDateTime.Location = new Point(408, 56);
            _dtpEndDateTime.Name = "dtpEndDateTime";
            _dtpEndDateTime.Size = new Size(184, 21);
            _dtpEndDateTime.TabIndex = 4;
            _dtpEndDateTime.Tag = "EngineerVan.EndDateTime";
            //
            // lblEndDateTime
            //
            _lblEndDateTime.Location = new Point(304, 56);
            _lblEndDateTime.Name = "lblEndDateTime";
            _lblEndDateTime.Size = new Size(96, 20);
            _lblEndDateTime.TabIndex = 31;
            _lblEndDateTime.Text = "End Date Time";
            //
            // UCEngineerVan
            //
            Controls.Add(_grpEngineerVan);
            Name = "UCEngineerVan";
            Size = new Size(616, 136);
            _grpEngineerVan.ResumeLayout(false);
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
                return CurrentEngineerVan;
            }
        }

        
        

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private int _VanID = 0;

        public int VanID
        {
            get
            {
                return _VanID;
            }

            set
            {
                _VanID = value;
            }
        }

        private Entity.EngineerVans.EngineerVan _currentEngineerVan;

        public Entity.EngineerVans.EngineerVan CurrentEngineerVan
        {
            get
            {
                return _currentEngineerVan;
            }

            set
            {
                _currentEngineerVan = value;
                if (CurrentEngineerVan is null)
                {
                    CurrentEngineerVan = new Entity.EngineerVans.EngineerVan();
                    CurrentEngineerVan.Exists = false;
                }

                if (CurrentEngineerVan.Exists)
                {
                    Populate();
                }
            }
        }

        private void UCEngineerVan_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void chkUntilFurtherNotice_CheckedChanged(object sender, EventArgs e)
        {
            dtpEndDateTime.Enabled = !chkUntilFurtherNotice.Checked;
        }

        
        

        public void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentEngineerVan = App.DB.EngineerVan.EngineerVan_Get(ID);
            }

            var argcombo = cboEngineerID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentEngineerVan.EngineerID.ToString());
            dtpStartDateTime.Value = CurrentEngineerVan.StartDateTime;
            if (CurrentEngineerVan.EndDateTime == default)
            {
                chkUntilFurtherNotice.Checked = true;
                dtpEndDateTime.Value = DateAndTime.Now;
            }
            else
            {
                chkUntilFurtherNotice.Checked = false;
                dtpEndDateTime.Value = CurrentEngineerVan.EndDateTime;
            }

            dtpEndDateTime.Enabled = !chkUntilFurtherNotice.Checked;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentEngineerVan.IgnoreExceptionsOnSetMethods = true;
                CurrentEngineerVan.SetEngineerID = Combo.get_GetSelectedItemValue(cboEngineerID);
                CurrentEngineerVan.SetVanID = VanID;
                CurrentEngineerVan.StartDateTime = dtpStartDateTime.Value;
                if (chkUntilFurtherNotice.Checked | dtpEndDateTime.Value > DateTime.Now)
                {
                    if (chkUntilFurtherNotice.Checked)
                    {
                        CurrentEngineerVan.EndDateTime = default;
                    }
                    else
                    {
                        CurrentEngineerVan.EndDateTime = dtpEndDateTime.Value;
                    }

                    var dvCurrentEngineersOnVan = App.DB.EngineerVan.EngineerVan_GetAll_For_Van(VanID);
                    var drActiveEngineers = dvCurrentEngineersOnVan.Table.Select("EnddateTime > '" + DateTime.Now + "' Or EnddateTime Is null");
                    if (drActiveEngineers.Length > 0)
                    {
                        string Message = "There is currently an engineer assigned to this profile, by adding this engineer you will be removing the current engineer assigned, would you like to continue?";
                        if (App.ShowMessage(Message, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return false;
                        }
                        else
                        {
                            foreach (DataRow drActiveEngineer in drActiveEngineers)
                            {
                                int engineerVanId = Entity.Sys.Helper.MakeIntegerValid(drActiveEngineer["EngineerVanID"]);
                                if (engineerVanId > 0)
                                {
                                    var activeEngineerVan = App.DB.EngineerVan.EngineerVan_Get(engineerVanId);
                                    activeEngineerVan.EndDateTime = DateTime.Now;
                                    App.DB.EngineerVan.Update(activeEngineerVan);
                                }
                            }
                        }
                    }
                }
                else
                {
                    CurrentEngineerVan.EndDateTime = dtpEndDateTime.Value;
                }

                var cV = new Entity.EngineerVans.EngineerVanValidator();
                cV.Validate(CurrentEngineerVan);
                if (CurrentEngineerVan.Exists)
                {
                    App.DB.EngineerVan.Update(CurrentEngineerVan);
                    if (CurrentEngineerVan.StartDateTime < DateTime.Now.AddDays(2))
                    {
                        if (App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID > 0 && App.DB.User.Get(App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID).EmailAddress.Length > 2)
                        {
                            Email(Entity.Sys.EmailAddress.StockFinancials, "The engineer (" + App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).Name + ") has been deactivated On the van " + App.DB.Van.Van_Get(CurrentEngineerVan.VanID).Registration, App.loggedInUser.Fullname, App.DB.User.Get(App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID).EmailAddress);
                        }
                        else
                        {
                            Email(Entity.Sys.EmailAddress.StockFinancials, "A New engineer (" + App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).Name + ") has been deactivated On the van " + App.DB.Van.Van_Get(CurrentEngineerVan.VanID).Registration + "", App.loggedInUser.Fullname, "");
                        }
                    }
                }
                else
                {
                    CurrentEngineerVan = App.DB.EngineerVan.Insert(CurrentEngineerVan);
                    if (App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID > 0 && App.DB.User.Get(App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID).EmailAddress.Length > 2)
                    {
                        Email(Entity.Sys.EmailAddress.StockFinancials, "A New engineer (" + App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).Name + ") has been added To van " + App.DB.Van.Van_Get(CurrentEngineerVan.VanID).Registration, App.loggedInUser.Fullname, App.DB.User.Get(App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).ManagerUserID).EmailAddress);
                    }
                    else
                    {
                        Email(Entity.Sys.EmailAddress.StockFinancials, "A New engineer (" + App.DB.Engineer.Engineer_Get(CurrentEngineerVan.EngineerID).Name + ") has been added To van " + App.DB.Van.Van_Get(CurrentEngineerVan.VanID).Registration, App.loggedInUser.Fullname, "");
                    }
                }

                StateChanged?.Invoke(CurrentEngineerVan.EngineerVanID);
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

        private void Email(string emailadd, string message, string addinguser, string cc)
        {
            string PersonName = null;
            string GreetingPart = null;
            var FeedbackEmail = new Entity.Sys.Emails();
            FeedbackEmail.From = Entity.Sys.EmailAddress.Gabriel;
            FeedbackEmail.To = emailadd;
            FeedbackEmail.CC = cc;
            FeedbackEmail.Subject = "An Engineer to van link has been modified";
            FeedbackEmail.Body = "<span style='font-family: Calibri, Sans-Serif'>" + "<p>Hi</p>" + "<p>User : " + addinguser + " has modified an engineer to van link</p>" + "<p>" + message + "</p>" + "<p>King Regards,</p>" + "<p>" + App.TheSystem.Configuration.CompanyName + "</p>" + "</span>";
            FeedbackEmail.SendMe = true;
            if (FeedbackEmail.Send())
            {
            }
        }

        
    }
}