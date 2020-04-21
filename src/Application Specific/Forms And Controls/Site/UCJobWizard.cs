using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCJobWizard : UCBase, IUserControl
    {
        public UCJobWizard() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            try
            {
                tcSites.TabPages[0].Enabled = true;
                tcSites.TabPages.Remove(tabJobType);
                tcSites.TabPages.Remove(tabJobDetails);
                tcSites.TabPages.Remove(tabAppliance);
                tcSites.TabPages.Remove(TabCharging);
                tcSites.TabPages.Remove(tabAdditional);
                tcSites.TabPages.Remove(TabBook);
                tcSites.TabPages.Remove(tcComplete);
                tcSites.TabPages.Remove(tabExistingJobs);
            }
            catch (Exception ex)
            {
            }

            var argc = cboTitle;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc1 = cbotypeWiz;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc2 = cboPayTerms;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.JobWizTerms, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc3 = cboAdditional;
            Combo.SetUpCombo(ref argc3, DynamicDataTables.JobWizAdditional, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc4 = cboAppointment;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll((Enums.PickListTypes)78).Table, "ManagerID", "Name", Enums.ComboValues.All_Appointments);
            var argc5 = cboEngineer;
            Combo.SetUpCombo(ref argc5, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Enums.ComboValues.Not_Applicable);

            // cboEngineer.Items.Add(New Combo("-- Not Applicable --", 0))
            // Combo.SetSelectedComboItem_By_Value(cboEngineer, 0)

            btnxxSiteNext.Visible = false;
            cbotypeWiz.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbotypeWiz.AutoCompleteSource = AutoCompleteSource.ListItems;
            // Combo.SetUpCombo(Me.cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
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

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private TabPage _tabJobDetails;

        internal TabPage tabJobDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabJobDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabJobDetails != null)
                {
                }

                _tabJobDetails = value;
                if (_tabJobDetails != null)
                {
                }
            }
        }

        private TabPage _tabAppliance;

        internal TabPage tabAppliance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabAppliance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabAppliance != null)
                {
                }

                _tabAppliance = value;
                if (_tabAppliance != null)
                {
                }
            }
        }

        private TabPage _tabJobType;

        internal TabPage tabJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabJobType != null)
                {
                }

                _tabJobType = value;
                if (_tabJobType != null)
                {
                }
            }
        }

        private TabPage _tabProp;

        internal TabPage tabProp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabProp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabProp != null)
                {
                }

                _tabProp = value;
                if (_tabProp != null)
                {
                }
            }
        }

        private TabControl _tcSites;

        internal TabControl tcSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcSites != null)
                {
                }

                _tcSites = value;
                if (_tcSites != null)
                {
                }
            }
        }

        private TextBox _txtSearch;

        internal TextBox txtSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearch != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _txtSearch.KeyDown -= txtSearch_TextChanged;
                }

                _txtSearch = value;
                if (_txtSearch != null)
                {
                    _txtSearch.KeyDown += txtSearch_TextChanged;
                }
            }
        }

        private DataGridView _DGVSites;

        internal DataGridView DGVSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DGVSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DGVSites != null)
                {
                    _DGVSites.RowPostPaint -= dgvSitesContracrPaint;
                    _DGVSites.SelectionChanged -= (_, __) => DGVSites_CellContentClick();
                }

                _DGVSites = value;
                if (_DGVSites != null)
                {
                    _DGVSites.RowPostPaint += dgvSitesContracrPaint;
                    _DGVSites.SelectionChanged += (_, __) => DGVSites_CellContentClick();
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private Button _btnEditSite;

        internal Button btnEditSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEditSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEditSite != null)
                {
                    _btnEditSite.Click -= btnEditSite_Click;
                }

                _btnEditSite = value;
                if (_btnEditSite != null)
                {
                    _btnEditSite.Click += btnEditSite_Click;
                }
            }
        }

        private Button _btnAddSite;

        internal Button btnAddSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddSite != null)
                {
                    _btnAddSite.Click -= btnAddSite_Click;
                }

                _btnAddSite = value;
                if (_btnAddSite != null)
                {
                    _btnAddSite.Click += btnAddSite_Click;
                }
            }
        }

        private Label _Label7;

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
                {
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private ComboBox _cboTitle;

        internal ComboBox cboTitle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTitle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTitle != null)
                {
                }

                _cboTitle = value;
                if (_cboTitle != null)
                {
                }
            }
        }

        private TextBox _txtAddress1;

        internal TextBox txtAddress1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress1 != null)
                {
                }

                _txtAddress1 = value;
                if (_txtAddress1 != null)
                {
                }
            }
        }

        private TextBox _txtAddress2;

        internal TextBox txtAddress2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress2 != null)
                {
                }

                _txtAddress2 = value;
                if (_txtAddress2 != null)
                {
                }
            }
        }

        private TextBox _txtPostcode;

        internal TextBox txtPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPostcode != null)
                {
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
                {
                }
            }
        }

        private TextBox _txtSurname;

        internal TextBox txtSurname
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSurname;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSurname != null)
                {
                }

                _txtSurname = value;
                if (_txtSurname != null)
                {
                }
            }
        }

        private TextBox _txtFirstName;

        internal TextBox txtFirstName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFirstName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFirstName != null)
                {
                }

                _txtFirstName = value;
                if (_txtFirstName != null)
                {
                }
            }
        }

        private TextBox _txtAddress3;

        internal TextBox txtAddress3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress3 != null)
                {
                }

                _txtAddress3 = value;
                if (_txtAddress3 != null)
                {
                }
            }
        }

        private Label _Label9;

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
                {
                }
            }
        }

        private TextBox _txtEmail;

        internal TextBox txtEmail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEmail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEmail != null)
                {
                }

                _txtEmail = value;
                if (_txtEmail != null)
                {
                }
            }
        }

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        private TextBox _txtTel;

        internal TextBox txtTel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTel != null)
                {
                }

                _txtTel = value;
                if (_txtTel != null)
                {
                }
            }
        }

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
                {
                }
            }
        }

        private TextBox _txtMob;

        internal TextBox txtMob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMob != null)
                {
                }

                _txtMob = value;
                if (_txtMob != null)
                {
                }
            }
        }

        private Label _Label10;

        internal Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label10 != null)
                {
                }

                _Label10 = value;
                if (_Label10 != null)
                {
                }
            }
        }

        private TextBox _txtCustomer;

        internal TextBox txtCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomer != null)
                {
                }

                _txtCustomer = value;
                if (_txtCustomer != null)
                {
                }
            }
        }

        private Button _btnxxSiteNext;

        internal Button btnxxSiteNext
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxSiteNext;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxSiteNext != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnxxSiteNext.Click -= btnSiteNext_Click;
                }

                _btnxxSiteNext = value;
                if (_btnxxSiteNext != null)
                {
                    _btnxxSiteNext.Click += btnSiteNext_Click;
                }
            }
        }

        private Button _btnxxOther;

        internal Button btnxxOther
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxOther;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxOther != null)
                {
                    _btnxxOther.Click -= btnxx_Click;
                }

                _btnxxOther = value;
                if (_btnxxOther != null)
                {
                    _btnxxOther.Click += btnxx_Click;
                }
            }
        }

        private Button _btnxxBreakdown;

        internal Button btnxxBreakdown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxBreakdown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxBreakdown != null)
                {
                    _btnxxBreakdown.Click -= btnxx_Click;
                }

                _btnxxBreakdown = value;
                if (_btnxxBreakdown != null)
                {
                    _btnxxBreakdown.Click += btnxx_Click;
                }
            }
        }

        private Label _Label11;

        internal Label Label11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label11 != null)
                {
                }

                _Label11 = value;
                if (_Label11 != null)
                {
                }
            }
        }

        private Button _BtnxxService;

        internal Button BtnxxService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BtnxxService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BtnxxService != null)
                {
                    _BtnxxService.Click -= btnxx_Click;
                }

                _BtnxxService = value;
                if (_BtnxxService != null)
                {
                    _BtnxxService.Click += btnxx_Click;
                }
            }
        }

        private Label _lbltype;

        internal Label lbltype
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbltype;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbltype != null)
                {
                }

                _lbltype = value;
                if (_lbltype != null)
                {
                }
            }
        }

        private ComboBox _cbotypeWiz;

        internal ComboBox cbotypeWiz
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbotypeWiz;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbotypeWiz != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _cbotypeWiz.SelectedIndexChanged -= cbotypeWiz_SelectedIndexChanged;
                }

                _cbotypeWiz = value;
                if (_cbotypeWiz != null)
                {
                    _cbotypeWiz.SelectedIndexChanged += cbotypeWiz_SelectedIndexChanged;
                }
            }
        }

        private DataGridView _DgMain;

        internal DataGridView DgMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DgMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DgMain != null)
                {
                }

                _DgMain = value;
                if (_DgMain != null)
                {
                }
            }
        }

        private Button _btnMinusMain;

        internal Button btnMinusMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMinusMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMinusMain != null)
                {
                    _btnMinusMain.Click -= btnMinusMain_Click;
                }

                _btnMinusMain = value;
                if (_btnMinusMain != null)
                {
                    _btnMinusMain.Click += btnMinusMain_Click;
                }
            }
        }

        private Button _btnAddMain;

        internal Button btnAddMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddMain != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnAddMain.Click -= btnAddMain_Click;
                }

                _btnAddMain = value;
                if (_btnAddMain != null)
                {
                    _btnAddMain.Click += btnAddMain_Click;
                }
            }
        }

        private ComboBox _cboMainApps;

        internal ComboBox cboMainApps
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboMainApps;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboMainApps != null)
                {
                }

                _cboMainApps = value;
                if (_cboMainApps != null)
                {
                }
            }
        }

        private Label _Label13;

        internal Label Label13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label13 != null)
                {
                }

                _Label13 = value;
                if (_Label13 != null)
                {
                }
            }
        }

        private Button _btnxxJobNext;

        internal Button btnxxJobNext
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxJobNext;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxJobNext != null)
                {
                    _btnxxJobNext.Click -= btnJobNext_Click;
                }

                _btnxxJobNext = value;
                if (_btnxxJobNext != null)
                {
                    _btnxxJobNext.Click += btnJobNext_Click;
                }
            }
        }

        private Label _Label12;

        internal Label Label12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label12 != null)
                {
                }

                _Label12 = value;
                if (_Label12 != null)
                {
                }
            }
        }

        private Button _btnxxSOR;

        internal Button btnxxSOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxSOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxSOR != null)
                {
                    _btnxxSOR.Click -= btnxx_Click;
                }

                _btnxxSOR = value;
                if (_btnxxSOR != null)
                {
                    _btnxxSOR.Click += btnxx_Click;
                }
            }
        }

        private Panel _pnlSOR;

        internal Panel pnlSOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlSOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlSOR != null)
                {
                }

                _pnlSOR = value;
                if (_pnlSOR != null)
                {
                }
            }
        }

        private DataGridView _DGSOR;

        internal DataGridView DGSOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DGSOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DGSOR != null)
                {
                }

                _DGSOR = value;
                if (_DGSOR != null)
                {
                }
            }
        }

        private TextBox _txtSORQty;

        internal TextBox txtSORQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSORQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSORQty != null)
                {
                }

                _txtSORQty = value;
                if (_txtSORQty != null)
                {
                }
            }
        }

        private Label _Label14;

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

        private Button _btnSORAdd;

        internal Button btnSORAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSORAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSORAdd != null)
                {
                    // End Sub

                    _btnSORAdd.Click -= btnSORAdd_Click;
                }

                _btnSORAdd = value;
                if (_btnSORAdd != null)
                {
                    _btnSORAdd.Click += btnSORAdd_Click;
                }
            }
        }

        private ComboBox _cboSOR;

        internal ComboBox cboSOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSOR != null)
                {
                }

                _cboSOR = value;
                if (_cboSOR != null)
                {
                }
            }
        }

        private Button _btnSORMinus;

        internal Button btnSORMinus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSORMinus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSORMinus != null)
                {
                    _btnSORMinus.Click -= btnSORMinus_Click;
                }

                _btnSORMinus = value;
                if (_btnSORMinus != null)
                {
                    _btnSORMinus.Click += btnSORMinus_Click;
                }
            }
        }

        private Button _btnxxApplianceNext;

        internal Button btnxxApplianceNext
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxApplianceNext;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxApplianceNext != null)
                {
                    _btnxxApplianceNext.Click -= btnxxApplianceNext_Click;
                }

                _btnxxApplianceNext = value;
                if (_btnxxApplianceNext != null)
                {
                    _btnxxApplianceNext.Click += btnxxApplianceNext_Click;
                }
            }
        }

        private Button _btnxxDetailsNext;

        internal Button btnxxDetailsNext
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxDetailsNext;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxDetailsNext != null)
                {
                    _btnxxDetailsNext.Click -= btnxxDetailsNext_Click;
                }

                _btnxxDetailsNext = value;
                if (_btnxxDetailsNext != null)
                {
                    _btnxxDetailsNext.Click += btnxxDetailsNext_Click;
                }
            }
        }

        private TabPage _TabCharging;

        internal TabPage TabCharging
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabCharging;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabCharging != null)
                {
                }

                _TabCharging = value;
                if (_TabCharging != null)
                {
                }
            }
        }

        private Label _Label18;

        internal Label Label18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label18 != null)
                {
                }

                _Label18 = value;
                if (_Label18 != null)
                {
                }
            }
        }

        private Panel _pnlCharge;

        internal Panel pnlCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlCharge != null)
                {
                }

                _pnlCharge = value;
                if (_pnlCharge != null)
                {
                }
            }
        }

        private Label _Label17;

        internal Label Label17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label17 != null)
                {
                }

                _Label17 = value;
                if (_Label17 != null)
                {
                }
            }
        }

        private TextBox _txtCharge;

        internal TextBox txtCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCharge != null)
                {
                }

                _txtCharge = value;
                if (_txtCharge != null)
                {
                }
            }
        }

        private Button _btnxxChargeNext;

        internal Button btnxxChargeNext
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxChargeNext;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxChargeNext != null)
                {
                    _btnxxChargeNext.Click -= btnxxChargeNext_Click;
                }

                _btnxxChargeNext = value;
                if (_btnxxChargeNext != null)
                {
                    _btnxxChargeNext.Click += btnxxChargeNext_Click;
                }
            }
        }

        private TextBox _txtPayInst;

        internal TextBox txtPayInst
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPayInst;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPayInst != null)
                {
                }

                _txtPayInst = value;
                if (_txtPayInst != null)
                {
                }
            }
        }

        private CheckBox _chkRecall;

        internal CheckBox chkRecall
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkRecall;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkRecall != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _chkRecall.CheckedChanged -= chkRecall_CheckedChanged;
                }

                _chkRecall = value;
                if (_chkRecall != null)
                {
                    _chkRecall.CheckedChanged += chkRecall_CheckedChanged;
                }
            }
        }

        private Label _Label19;

        internal Label Label19
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label19;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label19 != null)
                {
                }

                _Label19 = value;
                if (_Label19 != null)
                {
                }
            }
        }

        private Label _Label20;

        internal Label Label20
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label20;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label20 != null)
                {
                }

                _Label20 = value;
                if (_Label20 != null)
                {
                }
            }
        }

        private Panel _pnlSymptoms;

        internal Panel pnlSymptoms
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlSymptoms;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlSymptoms != null)
                {
                }

                _pnlSymptoms = value;
                if (_pnlSymptoms != null)
                {
                }
            }
        }

        private Label _lblSymptom;

        internal Label lblSymptom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSymptom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSymptom != null)
                {
                }

                _lblSymptom = value;
                if (_lblSymptom != null)
                {
                }
            }
        }

        private ComboBox _cboSymptom;

        internal ComboBox cboSymptom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSymptom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSymptom != null)
                {
                }

                _cboSymptom = value;
                if (_cboSymptom != null)
                {
                }
            }
        }

        private Label _Label15;

        internal Label Label15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label15 != null)
                {
                }

                _Label15 = value;
                if (_Label15 != null)
                {
                }
            }
        }

        private DataGridView _DGSymptoms;

        internal DataGridView DGSymptoms
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DGSymptoms;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DGSymptoms != null)
                {
                }

                _DGSymptoms = value;
                if (_DGSymptoms != null)
                {
                }
            }
        }

        private Button _btnSymMinus;

        internal Button btnSymMinus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSymMinus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSymMinus != null)
                {
                    _btnSymMinus.Click -= btnSymMinus_Click;
                }

                _btnSymMinus = value;
                if (_btnSymMinus != null)
                {
                    _btnSymMinus.Click += btnSymMinus_Click;
                }
            }
        }

        private Button _btnSymAdd;

        internal Button btnSymAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSymAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSymAdd != null)
                {
                    _btnSymAdd.Click -= btnSymAdd_Click;
                }

                _btnSymAdd = value;
                if (_btnSymAdd != null)
                {
                    _btnSymAdd.Click += btnSymAdd_Click;
                }
            }
        }

        private Label _lblPriority;

        internal Label lblPriority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPriority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPriority != null)
                {
                }

                _lblPriority = value;
                if (_lblPriority != null)
                {
                }
            }
        }

        private ComboBox _cboPriority;

        internal ComboBox cboPriority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPriority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPriority != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _cboPriority.SelectedIndexChanged -= cboPriority_SelectedIndexChanged;
                }

                _cboPriority = value;
                if (_cboPriority != null)
                {
                    _cboPriority.SelectedIndexChanged += cboPriority_SelectedIndexChanged;
                }
            }
        }

        private TabPage _tabAdditional;

        internal TabPage tabAdditional
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabAdditional;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabAdditional != null)
                {
                }

                _tabAdditional = value;
                if (_tabAdditional != null)
                {
                }
            }
        }

        private Button _btnxxAdditionalNext;

        internal Button btnxxAdditionalNext
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxAdditionalNext;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxAdditionalNext != null)
                {
                    _btnxxAdditionalNext.Click -= btnxxAdditionalNext_Click;
                }

                _btnxxAdditionalNext = value;
                if (_btnxxAdditionalNext != null)
                {
                    _btnxxAdditionalNext.Click += btnxxAdditionalNext_Click;
                }
            }
        }

        private Label _Label22;

        internal Label Label22
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label22;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label22 != null)
                {
                }

                _Label22 = value;
                if (_Label22 != null)
                {
                }
            }
        }

        private Label _Label21;

        internal Label Label21
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label21;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label21 != null)
                {
                }

                _Label21 = value;
                if (_Label21 != null)
                {
                }
            }
        }

        private ComboBox _cboAdditional;

        internal ComboBox cboAdditional
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAdditional;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAdditional != null)
                {
                }

                _cboAdditional = value;
                if (_cboAdditional != null)
                {
                }
            }
        }

        private DataGridView _DGAdditional;

        internal DataGridView DGAdditional
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DGAdditional;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DGAdditional != null)
                {
                }

                _DGAdditional = value;
                if (_DGAdditional != null)
                {
                }
            }
        }

        private Button _btnAdditionalMinus;

        internal Button btnAdditionalMinus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdditionalMinus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdditionalMinus != null)
                {
                    _btnAdditionalMinus.Click -= btnAdditionalMinus_Click;
                }

                _btnAdditionalMinus = value;
                if (_btnAdditionalMinus != null)
                {
                    _btnAdditionalMinus.Click += btnAdditionalMinus_Click;
                }
            }
        }

        private Button _btnAdditionalPlus;

        internal Button btnAdditionalPlus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdditionalPlus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdditionalPlus != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnAdditionalPlus.Click -= btnAdditionalPlus_Click;
                }

                _btnAdditionalPlus = value;
                if (_btnAdditionalPlus != null)
                {
                    _btnAdditionalPlus.Click += btnAdditionalPlus_Click;
                }
            }
        }

        private Label _Label16;

        internal Label Label16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label16 != null)
                {
                }

                _Label16 = value;
                if (_Label16 != null)
                {
                }
            }
        }

        private ComboBox _cboPayTerms;

        internal ComboBox cboPayTerms
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPayTerms;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPayTerms != null)
                {
                    _cboPayTerms.SelectedIndexChanged -= cboPayTerms_SelectedIndexChanged;
                }

                _cboPayTerms = value;
                if (_cboPayTerms != null)
                {
                    _cboPayTerms.SelectedIndexChanged += cboPayTerms_SelectedIndexChanged;
                }
            }
        }

        private Label _lblCoverplanServ;

        internal Label lblCoverplanServ
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCoverplanServ;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCoverplanServ != null)
                {
                }

                _lblCoverplanServ = value;
                if (_lblCoverplanServ != null)
                {
                }
            }
        }

        private TabPage _TabBook;

        internal TabPage TabBook
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabBook;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabBook != null)
                {
                }

                _TabBook = value;
                if (_TabBook != null)
                {
                }
            }
        }

        private Label _lblBookText;

        internal Label lblBookText
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBookText;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBookText != null)
                {
                }

                _lblBookText = value;
                if (_lblBookText != null)
                {
                }
            }
        }

        private Label _Label23;

        internal Label Label23
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label23;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label23 != null)
                {
                }

                _Label23 = value;
                if (_Label23 != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFromDate;

        internal DateTimePicker dtpFromDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFromDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFromDate != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _dtpFromDate.ValueChanged -= dtpFromDate_ValueChanged;
                }

                _dtpFromDate = value;
                if (_dtpFromDate != null)
                {
                    _dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
                }
            }
        }

        private Button _btnOption10;

        internal Button btnOption10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOption10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOption10 != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnOption10.Click -= btnOption_Click;
                    _btnOption10.Paint -= Button_Paint;
                }

                _btnOption10 = value;
                if (_btnOption10 != null)
                {
                    _btnOption10.Click += btnOption_Click;
                    _btnOption10.Paint += Button_Paint;
                }
            }
        }

        private Button _btnOption4;

        internal Button btnOption4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOption4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOption4 != null)
                {
                    _btnOption4.Click -= btnOption_Click;
                    _btnOption4.Paint -= Button_Paint;
                }

                _btnOption4 = value;
                if (_btnOption4 != null)
                {
                    _btnOption4.Click += btnOption_Click;
                    _btnOption4.Paint += Button_Paint;
                }
            }
        }

        private Button _btnOption3;

        internal Button btnOption3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOption3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOption3 != null)
                {
                    _btnOption3.Click -= btnOption_Click;
                    _btnOption3.Paint -= Button_Paint;
                }

                _btnOption3 = value;
                if (_btnOption3 != null)
                {
                    _btnOption3.Click += btnOption_Click;
                    _btnOption3.Paint += Button_Paint;
                }
            }
        }

        private Button _btnOption2;

        internal Button btnOption2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOption2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOption2 != null)
                {
                    _btnOption2.Click -= btnOption_Click;
                    _btnOption2.Paint -= Button_Paint;
                }

                _btnOption2 = value;
                if (_btnOption2 != null)
                {
                    _btnOption2.Click += btnOption_Click;
                    _btnOption2.Paint += Button_Paint;
                }
            }
        }

        private Button _btnOption1;

        internal Button btnOption1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOption1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOption1 != null)
                {
                    _btnOption1.Click -= btnOption_Click;
                    _btnOption1.Paint -= Button_Paint;
                }

                _btnOption1 = value;
                if (_btnOption1 != null)
                {
                    _btnOption1.Click += btnOption_Click;
                    _btnOption1.Paint += Button_Paint;
                }
            }
        }

        private CheckBox _chkKeepTogether;

        internal CheckBox chkKeepTogether
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkKeepTogether;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkKeepTogether != null)
                {
                    _chkKeepTogether.CheckedChanged -= chkKeepTogether_CheckedChanged;
                }

                _chkKeepTogether = value;
                if (_chkKeepTogether != null)
                {
                    _chkKeepTogether.CheckedChanged += chkKeepTogether_CheckedChanged;
                }
            }
        }

        private GroupBox _gpCombo;

        internal GroupBox gpCombo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpCombo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpCombo != null)
                {
                }

                _gpCombo = value;
                if (_gpCombo != null)
                {
                }
            }
        }

        private Panel _pnlTypeOfWorks;

        internal Panel pnlTypeOfWorks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlTypeOfWorks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlTypeOfWorks != null)
                {
                }

                _pnlTypeOfWorks = value;
                if (_pnlTypeOfWorks != null)
                {
                }
            }
        }

        private ComboBox _cboTypeOfWorks;

        internal ComboBox cboTypeOfWorks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTypeOfWorks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTypeOfWorks != null)
                {
                    _cboTypeOfWorks.SelectedIndexChanged -= cboTypeOfWorks_SelectedIndexChanged;
                }

                _cboTypeOfWorks = value;
                if (_cboTypeOfWorks != null)
                {
                    _cboTypeOfWorks.SelectedIndexChanged += cboTypeOfWorks_SelectedIndexChanged;
                }
            }
        }

        private Label _Label25;

        internal Label Label25
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label25;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label25 != null)
                {
                }

                _Label25 = value;
                if (_Label25 != null)
                {
                }
            }
        }

        private Button _btnxxFollow;

        internal Button btnxxFollow
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxFollow;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxFollow != null)
                {
                }

                _btnxxFollow = value;
                if (_btnxxFollow != null)
                {
                }
            }
        }

        private Button _btnxx1;

        internal Button btnxx1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxx1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxx1 != null)
                {
                    // Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcSites.SelectedIndexChanged
                    // tcSites.SelectedTab = tcSites.TabPages.Item(tab)

                    // End Sub

                    // event of tabpages

                    _btnxx1.Click -= btnxx1_Click;
                }

                _btnxx1 = value;
                if (_btnxx1 != null)
                {
                    _btnxx1.Click += btnxx1_Click;
                }
            }
        }

        private Button _btnxx2;

        internal Button btnxx2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxx2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxx2 != null)
                {
                    _btnxx2.Click -= btnxx1_Click;
                }

                _btnxx2 = value;
                if (_btnxx2 != null)
                {
                    _btnxx2.Click += btnxx1_Click;
                }
            }
        }

        private Button _btnxx3;

        internal Button btnxx3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxx3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxx3 != null)
                {
                    _btnxx3.Click -= btnxx1_Click;
                }

                _btnxx3 = value;
                if (_btnxx3 != null)
                {
                    _btnxx3.Click += btnxx1_Click;
                }
            }
        }

        private Button _btnxx4;

        internal Button btnxx4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxx4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxx4 != null)
                {
                    _btnxx4.Click -= btnxx1_Click;
                }

                _btnxx4 = value;
                if (_btnxx4 != null)
                {
                    _btnxx4.Click += btnxx1_Click;
                }
            }
        }

        private Button _btnxx5;

        internal Button btnxx5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxx5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxx5 != null)
                {
                    _btnxx5.Click -= btnxx1_Click;
                }

                _btnxx5 = value;
                if (_btnxx5 != null)
                {
                    _btnxx5.Click += btnxx1_Click;
                }
            }
        }

        private Button _btnxx6;

        internal Button btnxx6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxx6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxx6 != null)
                {
                    _btnxx6.Click -= btnxx1_Click;
                }

                _btnxx6 = value;
                if (_btnxx6 != null)
                {
                    _btnxx6.Click += btnxx1_Click;
                }
            }
        }

        private Button _btnJobHistory;

        internal Button btnJobHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnJobHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnJobHistory != null)
                {
                    _btnJobHistory.Click -= btnJobHistory_Click;
                }

                _btnJobHistory = value;
                if (_btnJobHistory != null)
                {
                    _btnJobHistory.Click += btnJobHistory_Click;
                }
            }
        }

        private CheckBox _chkCert;

        internal CheckBox chkCert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCert != null)
                {
                }

                _chkCert = value;
                if (_chkCert != null)
                {
                }
            }
        }

        private Label _lblcert;

        internal Label lblcert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcert != null)
                {
                }

                _lblcert = value;
                if (_lblcert != null)
                {
                }
            }
        }

        private Label _Label26;

        internal Label Label26
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label26;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label26 != null)
                {
                }

                _Label26 = value;
                if (_Label26 != null)
                {
                }
            }
        }

        private TextBox _txtPONumber;

        internal TextBox txtPONumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPONumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPONumber != null)
                {
                    _txtPONumber.TextChanged -= txtPONumber_TextChanged;
                }

                _txtPONumber = value;
                if (_txtPONumber != null)
                {
                    _txtPONumber.TextChanged += txtPONumber_TextChanged;
                }
            }
        }

        private Label _lblAdditional;

        internal Label lblAdditional
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAdditional;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAdditional != null)
                {
                }

                _lblAdditional = value;
                if (_lblAdditional != null)
                {
                }
            }
        }

        private TextBox _txtAdditional;

        internal TextBox txtAdditional
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAdditional;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAdditional != null)
                {
                    _txtAdditional.TextChanged -= txtAdditional_TextChanged;
                }

                _txtAdditional = value;
                if (_txtAdditional != null)
                {
                    _txtAdditional.TextChanged += txtAdditional_TextChanged;
                }
            }
        }

        private ComboBox _cboAppointment;

        internal ComboBox cboAppointment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAppointment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAppointment != null)
                {
                    _cboAppointment.SelectedIndexChanged -= cboAppointment_SelectedIndexChanged_1;
                }

                _cboAppointment = value;
                if (_cboAppointment != null)
                {
                    _cboAppointment.SelectedIndexChanged += cboAppointment_SelectedIndexChanged_1;
                }
            }
        }

        private Label _Label24;

        internal Label Label24
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label24;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label24 != null)
                {
                }

                _Label24 = value;
                if (_Label24 != null)
                {
                }
            }
        }

        private ComboBox _cboEngineer;

        internal ComboBox cboEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineer != null)
                {
                    _cboEngineer.SelectedIndexChanged -= cboEngineer_SelectedIndexChanged;
                }

                _cboEngineer = value;
                if (_cboEngineer != null)
                {
                    _cboEngineer.SelectedIndexChanged += cboEngineer_SelectedIndexChanged;
                }
            }
        }

        private TabPage _tcComplete;

        internal TabPage tcComplete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcComplete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcComplete != null)
                {
                }

                _tcComplete = value;
                if (_tcComplete != null)
                {
                }
            }
        }

        private Label _Label27;

        internal Label Label27
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label27;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label27 != null)
                {
                }

                _Label27 = value;
                if (_Label27 != null)
                {
                }
            }
        }

        private Button _btnRestart;

        internal Button btnRestart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRestart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRestart != null)
                {
                    _btnRestart.Click -= Button1_Click;
                }

                _btnRestart = value;
                if (_btnRestart != null)
                {
                    _btnRestart.Click += Button1_Click;
                }
            }
        }

        private Label _Label28;

        internal Label Label28
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label28;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label28 != null)
                {
                }

                _Label28 = value;
                if (_Label28 != null)
                {
                }
            }
        }

        private TextBox _txtContractRef;

        internal TextBox txtContractRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractRef != null)
                {
                }

                _txtContractRef = value;
                if (_txtContractRef != null)
                {
                }
            }
        }

        private ToolTip _ToolTip1;

        internal ToolTip ToolTip1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolTip1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolTip1 != null)
                {
                }

                _ToolTip1 = value;
                if (_ToolTip1 != null)
                {
                }
            }
        }

        private TabPage _tabExistingJobs;

        internal TabPage tabExistingJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabExistingJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabExistingJobs != null)
                {
                }

                _tabExistingJobs = value;
                if (_tabExistingJobs != null)
                {
                }
            }
        }

        private DataGridView _dgExistingVisits;

        internal DataGridView dgExistingVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgExistingVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgExistingVisits != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _dgExistingVisits.CellClick -= dgExistingVisits_CellClick;
                }

                _dgExistingVisits = value;
                if (_dgExistingVisits != null)
                {
                    _dgExistingVisits.CellClick += dgExistingVisits_CellClick;
                }
            }
        }

        private Label _Label29;

        internal Label Label29
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label29;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label29 != null)
                {
                }

                _Label29 = value;
                if (_Label29 != null)
                {
                }
            }
        }

        private Button _btnxxNewJob;

        internal Button btnxxNewJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxNewJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxNewJob != null)
                {
                    _btnxxNewJob.Click -= btnxxNewJob_Click;
                }

                _btnxxNewJob = value;
                if (_btnxxNewJob != null)
                {
                    _btnxxNewJob.Click += btnxxNewJob_Click;
                }
            }
        }

        private Button _btnxxExistingJobBack;

        internal Button btnxxExistingJobBack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxExistingJobBack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxExistingJobBack != null)
                {
                    _btnxxExistingJobBack.Click -= btnxx1_Click;
                }

                _btnxxExistingJobBack = value;
                if (_btnxxExistingJobBack != null)
                {
                    _btnxxExistingJobBack.Click += btnxx1_Click;
                }
            }
        }

        private Button _btnxxExistingJobNext;

        internal Button btnxxExistingJobNext
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxExistingJobNext;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxExistingJobNext != null)
                {
                    _btnxxExistingJobNext.Click -= btnxxExistingJobNext_Click;
                }

                _btnxxExistingJobNext = value;
                if (_btnxxExistingJobNext != null)
                {
                    _btnxxExistingJobNext.Click += btnxxExistingJobNext_Click;
                }
            }
        }

        private Label _lblUnabletoConfirm;

        internal Label lblUnabletoConfirm
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblUnabletoConfirm;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblUnabletoConfirm != null)
                {
                }

                _lblUnabletoConfirm = value;
                if (_lblUnabletoConfirm != null)
                {
                }
            }
        }

        private TextBox _txtSiteNotes;

        internal TextBox txtSiteNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSiteNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSiteNotes != null)
                {
                }

                _txtSiteNotes = value;
                if (_txtSiteNotes != null)
                {
                }
            }
        }

        private Label _Label30;

        internal Label Label30
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label30;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label30 != null)
                {
                }

                _Label30 = value;
                if (_Label30 != null)
                {
                }
            }
        }

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

        private Label _Label31;

        internal Label Label31
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label31;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label31 != null)
                {
                }

                _Label31 = value;
                if (_Label31 != null)
                {
                }
            }
        }

        private Label _lblBookedInfo;

        internal Label lblBookedInfo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBookedInfo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBookedInfo != null)
                {
                    _lblBookedInfo.Click -= lblBookedInfo_Click;
                }

                _lblBookedInfo = value;
                if (_lblBookedInfo != null)
                {
                    _lblBookedInfo.Click += lblBookedInfo_Click;
                }
            }
        }

        private Button _btnxxExternalBM;

        internal Button btnxxExternalBM
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxExternalBM;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxExternalBM != null)
                {
                    _btnxxExternalBM.Click -= btnxx_Click;
                }

                _btnxxExternalBM = value;
                if (_btnxxExternalBM != null)
                {
                    _btnxxExternalBM.Click += btnxx_Click;
                }
            }
        }

        private Button _btnxxCarpentry;

        internal Button btnxxCarpentry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxCarpentry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxCarpentry != null)
                {
                    _btnxxCarpentry.Click -= btnxx_Click;
                }

                _btnxxCarpentry = value;
                if (_btnxxCarpentry != null)
                {
                    _btnxxCarpentry.Click += btnxx_Click;
                }
            }
        }

        private Button _btnxxPlumbing;

        internal Button btnxxPlumbing
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxPlumbing;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxPlumbing != null)
                {
                    _btnxxPlumbing.Click -= btnxx_Click;
                }

                _btnxxPlumbing = value;
                if (_btnxxPlumbing != null)
                {
                    _btnxxPlumbing.Click += btnxx_Click;
                }
            }
        }

        private Button _btnxxElectrical;

        internal Button btnxxElectrical
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxElectrical;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxElectrical != null)
                {
                    _btnxxElectrical.Click -= btnxx_Click;
                }

                _btnxxElectrical = value;
                if (_btnxxElectrical != null)
                {
                    _btnxxElectrical.Click += btnxx_Click;
                }
            }
        }

        private Button _btnxxMultiTrade;

        internal Button btnxxMultiTrade
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxMultiTrade;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxMultiTrade != null)
                {
                    _btnxxMultiTrade.Click -= btnxx_Click;
                }

                _btnxxMultiTrade = value;
                if (_btnxxMultiTrade != null)
                {
                    _btnxxMultiTrade.Click += btnxx_Click;
                }
            }
        }

        private Button _btnxxKitchens;

        internal Button btnxxKitchens
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnxxKitchens;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnxxKitchens != null)
                {
                    _btnxxKitchens.Click -= btnxx_Click;
                }

                _btnxxKitchens = value;
                if (_btnxxKitchens != null)
                {
                    _btnxxKitchens.Click += btnxx_Click;
                }
            }
        }

        private Panel _pnlTimeReq;

        internal Panel pnlTimeReq
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlTimeReq;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlTimeReq != null)
                {
                }

                _pnlTimeReq = value;
                if (_pnlTimeReq != null)
                {
                }
            }
        }

        private Label _Label34;

        internal Label Label34
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label34;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label34 != null)
                {
                }

                _Label34 = value;
                if (_Label34 != null)
                {
                }
            }
        }

        private TextBox _txtHrs;

        internal TextBox txtHrs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHrs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHrs != null)
                {
                }

                _txtHrs = value;
                if (_txtHrs != null)
                {
                }
            }
        }

        private Label _Label32;

        internal Label Label32
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label32;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label32 != null)
                {
                }

                _Label32 = value;
                if (_Label32 != null)
                {
                }
            }
        }

        private Label _Label33;

        internal Label Label33
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label33;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label33 != null)
                {
                }

                _Label33 = value;
                if (_Label33 != null)
                {
                }
            }
        }

        private TextBox _txtDays;

        internal TextBox txtDays
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDays;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDays != null)
                {
                }

                _txtDays = value;
                if (_txtDays != null)
                {
                }
            }
        }

        private Button _btnRefresh;

        internal Button btnRefresh
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRefresh;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRefresh != null)
                {
                    _btnRefresh.Click -= Button2_Click;
                }

                _btnRefresh = value;
                if (_btnRefresh != null)
                {
                    _btnRefresh.Click += Button2_Click;
                }
            }
        }

        private Button _btnOption8;

        internal Button btnOption8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOption8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOption8 != null)
                {
                    _btnOption8.Click -= btnOption_Click;
                    _btnOption8.Paint -= Button_Paint;
                }

                _btnOption8 = value;
                if (_btnOption8 != null)
                {
                    _btnOption8.Click += btnOption_Click;
                    _btnOption8.Paint += Button_Paint;
                }
            }
        }

        private Button _btnOption7;

        internal Button btnOption7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOption7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOption7 != null)
                {
                    _btnOption7.Click -= btnOption_Click;
                    _btnOption7.Paint -= Button_Paint;
                }

                _btnOption7 = value;
                if (_btnOption7 != null)
                {
                    _btnOption7.Click += btnOption_Click;
                    _btnOption7.Paint += Button_Paint;
                }
            }
        }

        private Button _btnOption6;

        internal Button btnOption6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOption6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOption6 != null)
                {
                    _btnOption6.Click -= btnOption_Click;
                    _btnOption6.Paint -= Button_Paint;
                }

                _btnOption6 = value;
                if (_btnOption6 != null)
                {
                    _btnOption6.Click += btnOption_Click;
                    _btnOption6.Paint += Button_Paint;
                }
            }
        }

        private Button _btnOption5;

        internal Button btnOption5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOption5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOption5 != null)
                {
                    _btnOption5.Click -= btnOption_Click;
                    _btnOption5.Paint -= Button_Paint;
                }

                _btnOption5 = value;
                if (_btnOption5 != null)
                {
                    _btnOption5.Click += btnOption_Click;
                    _btnOption5.Paint += Button_Paint;
                }
            }
        }

        private Label _Label35;

        internal Label Label35
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label35;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label35 != null)
                {
                }

                _Label35 = value;
                if (_Label35 != null)
                {
                }
            }
        }

        private TextBox _txtDiscountCode;

        internal TextBox txtDiscountCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDiscountCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDiscountCode != null)
                {
                    _txtDiscountCode.TextChanged -= txtDiscountCode_TextChanged;
                }

                _txtDiscountCode = value;
                if (_txtDiscountCode != null)
                {
                    _txtDiscountCode.TextChanged += txtDiscountCode_TextChanged;
                }
            }
        }

        private PictureBox _picTick;

        internal PictureBox picTick
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picTick;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picTick != null)
                {
                }

                _picTick = value;
                if (_picTick != null)
                {
                }
            }
        }

        private PictureBox _picCross;

        internal PictureBox picCross
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picCross;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picCross != null)
                {
                }

                _picCross = value;
                if (_picCross != null)
                {
                }
            }
        }

        private Button _btnDocument;

        internal Button btnDocument
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDocument;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDocument != null)
                {
                    _btnDocument.Click -= Button1_Click_1;
                }

                _btnDocument = value;
                if (_btnDocument != null)
                {
                    _btnDocument.Click += Button1_Click_1;
                }
            }
        }

        private Button _txtSearchSite;

        internal Button txtSearchSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearchSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearchSite != null)
                {
                    _txtSearchSite.Click -= txtSearchSite_MouseClick;
                }

                _txtSearchSite = value;
                if (_txtSearchSite != null)
                {
                    _txtSearchSite.Click += txtSearchSite_MouseClick;
                }
            }
        }

        private CheckBox _chbCommercial;

        internal CheckBox chbCommercial
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chbCommercial;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chbCommercial != null)
                {
                }

                _chbCommercial = value;
                if (_chbCommercial != null)
                {
                }
            }
        }

        private Label _lblContactAlert;

        internal Label lblContactAlert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContactAlert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContactAlert != null)
                {
                }

                _lblContactAlert = value;
                if (_lblContactAlert != null)
                {
                }
            }
        }

        private TextBox _txtContactAlert;

        internal TextBox txtContactAlert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContactAlert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContactAlert != null)
                {
                }

                _txtContactAlert = value;
                if (_txtContactAlert != null)
                {
                }
            }
        }

        private Label _lblDefect;

        internal Label lblDefect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDefect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDefect != null)
                {
                }

                _lblDefect = value;
                if (_lblDefect != null)
                {
                }
            }
        }

        private TextBox _txtDefect;

        internal TextBox txtDefect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDefect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDefect != null)
                {
                }

                _txtDefect = value;
                if (_txtDefect != null)
                {
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UCJobWizard));
            _tabJobDetails = new TabPage();
            _pnlTimeReq = new Panel();
            _Label34 = new Label();
            _txtHrs = new TextBox();
            _Label32 = new Label();
            _Label33 = new Label();
            _txtDays = new TextBox();
            _Label26 = new Label();
            _txtPONumber = new TextBox();
            _txtPONumber.TextChanged += new EventHandler(txtPONumber_TextChanged);
            _lblAdditional = new Label();
            _txtAdditional = new TextBox();
            _txtAdditional.TextChanged += new EventHandler(txtAdditional_TextChanged);
            _btnxx2 = new Button();
            _btnxx2.Click += new EventHandler(btnxx1_Click);
            _pnlTypeOfWorks = new Panel();
            _cboTypeOfWorks = new ComboBox();
            _cboTypeOfWorks.SelectedIndexChanged += new EventHandler(cboTypeOfWorks_SelectedIndexChanged);
            _Label25 = new Label();
            _pnlSymptoms = new Panel();
            _lblSymptom = new Label();
            _cboSymptom = new ComboBox();
            _Label15 = new Label();
            _DGSymptoms = new DataGridView();
            _btnSymMinus = new Button();
            _btnSymMinus.Click += new EventHandler(btnSymMinus_Click);
            _btnSymAdd = new Button();
            _btnSymAdd.Click += new EventHandler(btnSymAdd_Click);
            _lblPriority = new Label();
            _cboPriority = new ComboBox();
            _cboPriority.SelectedIndexChanged += new EventHandler(cboPriority_SelectedIndexChanged);
            _Label12 = new Label();
            _btnxxDetailsNext = new Button();
            _btnxxDetailsNext.Click += new EventHandler(btnxxDetailsNext_Click);
            _tabAppliance = new TabPage();
            _btnxx3 = new Button();
            _btnxx3.Click += new EventHandler(btnxx1_Click);
            _Label20 = new Label();
            _Label13 = new Label();
            _DgMain = new DataGridView();
            _btnMinusMain = new Button();
            _btnMinusMain.Click += new EventHandler(btnMinusMain_Click);
            _btnAddMain = new Button();
            _btnAddMain.Click += new EventHandler(btnAddMain_Click);
            _cboMainApps = new ComboBox();
            _btnxxApplianceNext = new Button();
            _btnxxApplianceNext.Click += new EventHandler(btnxxApplianceNext_Click);
            _tabJobType = new TabPage();
            _btnxxExternalBM = new Button();
            _btnxxExternalBM.Click += new EventHandler(btnxx_Click);
            _btnxxCarpentry = new Button();
            _btnxxCarpentry.Click += new EventHandler(btnxx_Click);
            _btnxxPlumbing = new Button();
            _btnxxPlumbing.Click += new EventHandler(btnxx_Click);
            _btnxxElectrical = new Button();
            _btnxxElectrical.Click += new EventHandler(btnxx_Click);
            _btnxxMultiTrade = new Button();
            _btnxxMultiTrade.Click += new EventHandler(btnxx_Click);
            _btnxxKitchens = new Button();
            _btnxxKitchens.Click += new EventHandler(btnxx_Click);
            _btnxx1 = new Button();
            _btnxx1.Click += new EventHandler(btnxx1_Click);
            _pnlSOR = new Panel();
            _DGSOR = new DataGridView();
            _btnxxFollow = new Button();
            _txtSORQty = new TextBox();
            _Label14 = new Label();
            _btnSORAdd = new Button();
            _btnSORAdd.Click += new EventHandler(btnSORAdd_Click);
            _cboSOR = new ComboBox();
            _btnSORMinus = new Button();
            _btnSORMinus.Click += new EventHandler(btnSORMinus_Click);
            _btnxxSOR = new Button();
            _btnxxSOR.Click += new EventHandler(btnxx_Click);
            _lbltype = new Label();
            _cbotypeWiz = new ComboBox();
            _cbotypeWiz.SelectedIndexChanged += new EventHandler(cbotypeWiz_SelectedIndexChanged);
            _btnxxBreakdown = new Button();
            _btnxxBreakdown.Click += new EventHandler(btnxx_Click);
            _Label11 = new Label();
            _BtnxxService = new Button();
            _BtnxxService.Click += new EventHandler(btnxx_Click);
            _btnxxOther = new Button();
            _btnxxOther.Click += new EventHandler(btnxx_Click);
            _btnxxJobNext = new Button();
            _btnxxJobNext.Click += new EventHandler(btnJobNext_Click);
            _tabProp = new TabPage();
            _lblDefect = new Label();
            _txtDefect = new TextBox();
            _chbCommercial = new CheckBox();
            _lblContactAlert = new Label();
            _txtContactAlert = new TextBox();
            _txtSearchSite = new Button();
            _txtSearchSite.Click += new EventHandler(txtSearchSite_MouseClick);
            _txtName = new TextBox();
            _txtSiteNotes = new TextBox();
            _Label30 = new Label();
            _Label28 = new Label();
            _txtContractRef = new TextBox();
            _btnJobHistory = new Button();
            _btnJobHistory.Click += new EventHandler(btnJobHistory_Click);
            _btnxxSiteNext = new Button();
            _btnxxSiteNext.Click += new EventHandler(btnSiteNext_Click);
            _Label10 = new Label();
            _txtCustomer = new TextBox();
            _Label9 = new Label();
            _txtEmail = new TextBox();
            _Label8 = new Label();
            _txtTel = new TextBox();
            _Label6 = new Label();
            _txtMob = new TextBox();
            _txtAddress3 = new TextBox();
            _Label7 = new Label();
            _Label5 = new Label();
            _Label4 = new Label();
            _Label3 = new Label();
            _Label2 = new Label();
            _cboTitle = new ComboBox();
            _txtAddress1 = new TextBox();
            _txtAddress2 = new TextBox();
            _txtPostcode = new TextBox();
            _txtSurname = new TextBox();
            _txtFirstName = new TextBox();
            _btnEditSite = new Button();
            _btnEditSite.Click += new EventHandler(btnEditSite_Click);
            _btnAddSite = new Button();
            _btnAddSite.Click += new EventHandler(btnAddSite_Click);
            _Label1 = new Label();
            _txtSearch = new TextBox();
            _txtSearch.KeyDown += new KeyEventHandler(txtSearch_TextChanged);
            _DGVSites = new DataGridView();
            _DGVSites.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvSitesContracrPaint);
            _DGVSites.SelectionChanged += new EventHandler(DGVSites_CellContentClick);
            _tcSites = new TabControl();
            _tabExistingJobs = new TabPage();
            _btnxxExistingJobBack = new Button();
            _btnxxExistingJobBack.Click += new EventHandler(btnxx1_Click);
            _btnxxExistingJobNext = new Button();
            _btnxxExistingJobNext.Click += new EventHandler(btnxxExistingJobNext_Click);
            _dgExistingVisits = new DataGridView();
            _dgExistingVisits.CellClick += new DataGridViewCellEventHandler(dgExistingVisits_CellClick);
            _Label29 = new Label();
            _btnxxNewJob = new Button();
            _btnxxNewJob.Click += new EventHandler(btnxxNewJob_Click);
            _tabAdditional = new TabPage();
            _chkCert = new CheckBox();
            _lblcert = new Label();
            _btnxx4 = new Button();
            _btnxx4.Click += new EventHandler(btnxx1_Click);
            _lblCoverplanServ = new Label();
            _Label22 = new Label();
            _Label21 = new Label();
            _cboAdditional = new ComboBox();
            _DGAdditional = new DataGridView();
            _btnAdditionalMinus = new Button();
            _btnAdditionalMinus.Click += new EventHandler(btnAdditionalMinus_Click);
            _btnAdditionalPlus = new Button();
            _btnAdditionalPlus.Click += new EventHandler(btnAdditionalPlus_Click);
            _btnxxAdditionalNext = new Button();
            _btnxxAdditionalNext.Click += new EventHandler(btnxxAdditionalNext_Click);
            _TabCharging = new TabPage();
            _lblUnabletoConfirm = new Label();
            _btnxx5 = new Button();
            _btnxx5.Click += new EventHandler(btnxx1_Click);
            _Label16 = new Label();
            _cboPayTerms = new ComboBox();
            _cboPayTerms.SelectedIndexChanged += new EventHandler(cboPayTerms_SelectedIndexChanged);
            _chkRecall = new CheckBox();
            _chkRecall.CheckedChanged += new EventHandler(chkRecall_CheckedChanged);
            _Label19 = new Label();
            _Label18 = new Label();
            _pnlCharge = new Panel();
            _picTick = new PictureBox();
            _Label35 = new Label();
            _txtDiscountCode = new TextBox();
            _txtDiscountCode.TextChanged += new EventHandler(txtDiscountCode_TextChanged);
            _Label17 = new Label();
            _txtCharge = new TextBox();
            _picCross = new PictureBox();
            _txtPayInst = new TextBox();
            _btnxxChargeNext = new Button();
            _btnxxChargeNext.Click += new EventHandler(btnxxChargeNext_Click);
            _TabBook = new TabPage();
            _btnOption8 = new Button();
            _btnOption8.Click += new EventHandler(btnOption_Click);
            _btnOption8.Paint += new PaintEventHandler(Button_Paint);
            _btnOption7 = new Button();
            _btnOption7.Click += new EventHandler(btnOption_Click);
            _btnOption7.Paint += new PaintEventHandler(Button_Paint);
            _btnOption6 = new Button();
            _btnOption6.Click += new EventHandler(btnOption_Click);
            _btnOption6.Paint += new PaintEventHandler(Button_Paint);
            _btnOption5 = new Button();
            _btnOption5.Click += new EventHandler(btnOption_Click);
            _btnOption5.Paint += new PaintEventHandler(Button_Paint);
            _btnRefresh = new Button();
            _btnRefresh.Click += new EventHandler(Button2_Click);
            _Label31 = new Label();
            _Label24 = new Label();
            _cboEngineer = new ComboBox();
            _cboEngineer.SelectedIndexChanged += new EventHandler(cboEngineer_SelectedIndexChanged);
            _btnxx6 = new Button();
            _btnxx6.Click += new EventHandler(btnxx1_Click);
            _gpCombo = new GroupBox();
            _cboAppointment = new ComboBox();
            _cboAppointment.SelectedIndexChanged += new EventHandler(cboAppointment_SelectedIndexChanged_1);
            _lblBookText = new Label();
            _Label23 = new Label();
            _dtpFromDate = new DateTimePicker();
            _dtpFromDate.ValueChanged += new EventHandler(dtpFromDate_ValueChanged);
            _btnOption10 = new Button();
            _btnOption10.Click += new EventHandler(btnOption_Click);
            _btnOption10.Paint += new PaintEventHandler(Button_Paint);
            _btnOption4 = new Button();
            _btnOption4.Click += new EventHandler(btnOption_Click);
            _btnOption4.Paint += new PaintEventHandler(Button_Paint);
            _btnOption3 = new Button();
            _btnOption3.Click += new EventHandler(btnOption_Click);
            _btnOption3.Paint += new PaintEventHandler(Button_Paint);
            _btnOption2 = new Button();
            _btnOption2.Click += new EventHandler(btnOption_Click);
            _btnOption2.Paint += new PaintEventHandler(Button_Paint);
            _btnOption1 = new Button();
            _btnOption1.Click += new EventHandler(btnOption_Click);
            _btnOption1.Paint += new PaintEventHandler(Button_Paint);
            _chkKeepTogether = new CheckBox();
            _chkKeepTogether.CheckedChanged += new EventHandler(chkKeepTogether_CheckedChanged);
            _tcComplete = new TabPage();
            _btnDocument = new Button();
            _btnDocument.Click += new EventHandler(Button1_Click_1);
            _lblBookedInfo = new Label();
            _lblBookedInfo.Click += new EventHandler(lblBookedInfo_Click);
            _Label27 = new Label();
            _btnRestart = new Button();
            _btnRestart.Click += new EventHandler(Button1_Click);
            _ToolTip1 = new ToolTip(components);
            _tabJobDetails.SuspendLayout();
            _pnlTimeReq.SuspendLayout();
            _pnlTypeOfWorks.SuspendLayout();
            _pnlSymptoms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_DGSymptoms).BeginInit();
            _tabAppliance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_DgMain).BeginInit();
            _tabJobType.SuspendLayout();
            _pnlSOR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_DGSOR).BeginInit();
            _tabProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_DGVSites).BeginInit();
            _tcSites.SuspendLayout();
            _tabExistingJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgExistingVisits).BeginInit();
            _tabAdditional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_DGAdditional).BeginInit();
            _TabCharging.SuspendLayout();
            _pnlCharge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_picTick).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_picCross).BeginInit();
            _TabBook.SuspendLayout();
            _gpCombo.SuspendLayout();
            _tcComplete.SuspendLayout();
            SuspendLayout();
            //
            // tabJobDetails
            //
            _tabJobDetails.Controls.Add(_pnlTimeReq);
            _tabJobDetails.Controls.Add(_Label26);
            _tabJobDetails.Controls.Add(_txtPONumber);
            _tabJobDetails.Controls.Add(_lblAdditional);
            _tabJobDetails.Controls.Add(_txtAdditional);
            _tabJobDetails.Controls.Add(_btnxx2);
            _tabJobDetails.Controls.Add(_pnlTypeOfWorks);
            _tabJobDetails.Controls.Add(_pnlSymptoms);
            _tabJobDetails.Controls.Add(_lblPriority);
            _tabJobDetails.Controls.Add(_cboPriority);
            _tabJobDetails.Controls.Add(_Label12);
            _tabJobDetails.Controls.Add(_btnxxDetailsNext);
            _tabJobDetails.Location = new Point(4, 22);
            _tabJobDetails.Name = "tabJobDetails";
            _tabJobDetails.Size = new Size(877, 774);
            _tabJobDetails.TabIndex = 4;
            _tabJobDetails.Text = "Job Details";
            //
            // pnlTimeReq
            //
            _pnlTimeReq.Controls.Add(_Label34);
            _pnlTimeReq.Controls.Add(_txtHrs);
            _pnlTimeReq.Controls.Add(_Label32);
            _pnlTimeReq.Controls.Add(_Label33);
            _pnlTimeReq.Controls.Add(_txtDays);
            _pnlTimeReq.Location = new Point(124, 354);
            _pnlTimeReq.Name = "pnlTimeReq";
            _pnlTimeReq.Size = new Size(550, 42);
            _pnlTimeReq.TabIndex = 173;
            _pnlTimeReq.Visible = false;
            //
            // Label34
            //
            _Label34.AutoSize = true;
            _Label34.Font = new Font("Verdana", 10.0F);
            _Label34.Location = new Point(432, 11);
            _Label34.Name = "Label34";
            _Label34.Size = new Size(32, 17);
            _Label34.TabIndex = 174;
            _Label34.Text = "Hrs";
            //
            // txtHrs
            //
            _txtHrs.Location = new Point(347, 10);
            _txtHrs.Name = "txtHrs";
            _txtHrs.Size = new Size(79, 21);
            _txtHrs.TabIndex = 173;
            //
            // Label32
            //
            _Label32.AutoSize = true;
            _Label32.Font = new Font("Verdana", 10.0F);
            _Label32.Location = new Point(3, 12);
            _Label32.Name = "Label32";
            _Label32.Size = new Size(135, 17);
            _Label32.TabIndex = 170;
            _Label32.Text = "Time Requirement";
            //
            // Label33
            //
            _Label33.AutoSize = true;
            _Label33.Font = new Font("Verdana", 10.0F);
            _Label33.Location = new Point(264, 11);
            _Label33.Name = "Label33";
            _Label33.Size = new Size(43, 17);
            _Label33.TabIndex = 172;
            _Label33.Text = "Days";
            //
            // txtDays
            //
            _txtDays.Location = new Point(189, 10);
            _txtDays.Name = "txtDays";
            _txtDays.Size = new Size(69, 21);
            _txtDays.TabIndex = 171;
            //
            // Label26
            //
            _Label26.AutoSize = true;
            _Label26.Font = new Font("Verdana", 10.0F);
            _Label26.Location = new Point(128, 407);
            _Label26.Name = "Label26";
            _Label26.Size = new Size(143, 17);
            _Label26.TabIndex = 169;
            _Label26.Text = "PO / Order Number";
            //
            // txtPONumber
            //
            _txtPONumber.Location = new Point(306, 407);
            _txtPONumber.Name = "txtPONumber";
            _txtPONumber.Size = new Size(358, 21);
            _txtPONumber.TabIndex = 168;
            //
            // lblAdditional
            //
            _lblAdditional.AutoSize = true;
            _lblAdditional.Font = new Font("Verdana", 10.0F);
            _lblAdditional.Location = new Point(127, 453);
            _lblAdditional.Name = "lblAdditional";
            _lblAdditional.Size = new Size(97, 17);
            _lblAdditional.TabIndex = 167;
            _lblAdditional.Text = "Work Details";
            _lblAdditional.Visible = false;
            //
            // txtAdditional
            //
            _txtAdditional.Location = new Point(305, 450);
            _txtAdditional.Multiline = true;
            _txtAdditional.Name = "txtAdditional";
            _txtAdditional.Size = new Size(358, 99);
            _txtAdditional.TabIndex = 166;
            _txtAdditional.Visible = false;
            //
            // btnxx2
            //
            _btnxx2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnxx2.BackColor = SystemColors.Control;
            _btnxx2.BackgroundImage = (Image)resources.GetObject("btnxx2.BackgroundImage");
            _btnxx2.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxx2.Cursor = Cursors.Hand;
            _btnxx2.Location = new Point(3, 707);
            _btnxx2.Name = "btnxx2";
            _btnxx2.Size = new Size(62, 45);
            _btnxx2.TabIndex = 163;
            _btnxx2.UseVisualStyleBackColor = false;
            //
            // pnlTypeOfWorks
            //
            _pnlTypeOfWorks.Controls.Add(_cboTypeOfWorks);
            _pnlTypeOfWorks.Controls.Add(_Label25);
            _pnlTypeOfWorks.Location = new Point(124, 354);
            _pnlTypeOfWorks.Name = "pnlTypeOfWorks";
            _pnlTypeOfWorks.Size = new Size(550, 42);
            _pnlTypeOfWorks.TabIndex = 162;
            //
            // cboTypeOfWorks
            //
            _cboTypeOfWorks.Font = new Font("Verdana", 9.0F);
            _cboTypeOfWorks.FormattingEnabled = true;
            _cboTypeOfWorks.Location = new Point(189, 10);
            _cboTypeOfWorks.Name = "cboTypeOfWorks";
            _cboTypeOfWorks.Size = new Size(357, 22);
            _cboTypeOfWorks.TabIndex = 163;
            _cboTypeOfWorks.Visible = false;
            //
            // Label25
            //
            _Label25.AutoSize = true;
            _Label25.Font = new Font("Verdana", 10.0F);
            _Label25.Location = new Point(11, 10);
            _Label25.Name = "Label25";
            _Label25.Size = new Size(112, 17);
            _Label25.TabIndex = 162;
            _Label25.Text = "Type Of Works";
            _Label25.Visible = false;
            //
            // pnlSymptoms
            //
            _pnlSymptoms.Controls.Add(_lblSymptom);
            _pnlSymptoms.Controls.Add(_cboSymptom);
            _pnlSymptoms.Controls.Add(_Label15);
            _pnlSymptoms.Controls.Add(_DGSymptoms);
            _pnlSymptoms.Controls.Add(_btnSymMinus);
            _pnlSymptoms.Controls.Add(_btnSymAdd);
            _pnlSymptoms.Location = new Point(95, 155);
            _pnlSymptoms.Name = "pnlSymptoms";
            _pnlSymptoms.Size = new Size(602, 193);
            _pnlSymptoms.TabIndex = 158;
            //
            // lblSymptom
            //
            _lblSymptom.AutoSize = true;
            _lblSymptom.Font = new Font("Verdana", 10.0F);
            _lblSymptom.Location = new Point(34, 14);
            _lblSymptom.Name = "lblSymptom";
            _lblSymptom.Size = new Size(76, 17);
            _lblSymptom.TabIndex = 159;
            _lblSymptom.Text = "Symptom";
            //
            // cboSymptom
            //
            _cboSymptom.Font = new Font("Verdana", 9.0F);
            _cboSymptom.FormattingEnabled = true;
            _cboSymptom.Location = new Point(210, 12);
            _cboSymptom.Name = "cboSymptom";
            _cboSymptom.Size = new Size(358, 22);
            _cboSymptom.TabIndex = 158;
            //
            // Label15
            //
            _Label15.AutoSize = true;
            _Label15.Font = new Font("Verdana", 10.0F);
            _Label15.Location = new Point(34, 67);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(140, 17);
            _Label15.TabIndex = 157;
            _Label15.Text = "Applied Symptoms";
            //
            // DGSymptoms
            //
            _DGSymptoms.AllowUserToAddRows = false;
            _DGSymptoms.AllowUserToDeleteRows = false;
            _DGSymptoms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _DGSymptoms.ColumnHeadersVisible = false;
            _DGSymptoms.Location = new Point(210, 67);
            _DGSymptoms.MultiSelect = false;
            _DGSymptoms.Name = "DGSymptoms";
            _DGSymptoms.ReadOnly = true;
            _DGSymptoms.RowHeadersVisible = false;
            _DGSymptoms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _DGSymptoms.ShowCellErrors = false;
            _DGSymptoms.ShowEditingIcon = false;
            _DGSymptoms.ShowRowErrors = false;
            _DGSymptoms.Size = new Size(359, 122);
            _DGSymptoms.TabIndex = 156;
            //
            // btnSymMinus
            //
            _btnSymMinus.Location = new Point(346, 39);
            _btnSymMinus.Name = "btnSymMinus";
            _btnSymMinus.Size = new Size(39, 23);
            _btnSymMinus.TabIndex = 155;
            _btnSymMinus.Text = "-";
            _btnSymMinus.UseVisualStyleBackColor = true;
            //
            // btnSymAdd
            //
            _btnSymAdd.Location = new Point(391, 39);
            _btnSymAdd.Name = "btnSymAdd";
            _btnSymAdd.Size = new Size(39, 23);
            _btnSymAdd.TabIndex = 154;
            _btnSymAdd.Text = "+";
            _btnSymAdd.UseVisualStyleBackColor = true;
            //
            // lblPriority
            //
            _lblPriority.AutoSize = true;
            _lblPriority.Font = new Font("Verdana", 10.0F);
            _lblPriority.Location = new Point(127, 120);
            _lblPriority.Name = "lblPriority";
            _lblPriority.Size = new Size(57, 17);
            _lblPriority.TabIndex = 157;
            _lblPriority.Text = "Priority";
            _lblPriority.Visible = false;
            //
            // cboPriority
            //
            _cboPriority.Font = new Font("Verdana", 9.0F);
            _cboPriority.FormattingEnabled = true;
            _cboPriority.Location = new Point(304, 118);
            _cboPriority.Name = "cboPriority";
            _cboPriority.Size = new Size(357, 22);
            _cboPriority.TabIndex = 156;
            _cboPriority.Visible = false;
            //
            // Label12
            //
            _Label12.AutoSize = true;
            _Label12.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label12.Location = new Point(411, 28);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(141, 25);
            _Label12.TabIndex = 20;
            _Label12.Text = "Job Details";
            //
            // btnxxDetailsNext
            //
            _btnxxDetailsNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnxxDetailsNext.BackColor = SystemColors.Control;
            _btnxxDetailsNext.BackgroundImage = (Image)resources.GetObject("btnxxDetailsNext.BackgroundImage");
            _btnxxDetailsNext.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxxDetailsNext.Cursor = Cursors.Hand;
            _btnxxDetailsNext.Location = new Point(812, 707);
            _btnxxDetailsNext.Name = "btnxxDetailsNext";
            _btnxxDetailsNext.Size = new Size(62, 45);
            _btnxxDetailsNext.TabIndex = 154;
            _btnxxDetailsNext.UseVisualStyleBackColor = false;
            _btnxxDetailsNext.Visible = false;
            //
            // tabAppliance
            //
            _tabAppliance.Controls.Add(_btnxx3);
            _tabAppliance.Controls.Add(_Label20);
            _tabAppliance.Controls.Add(_Label13);
            _tabAppliance.Controls.Add(_DgMain);
            _tabAppliance.Controls.Add(_btnMinusMain);
            _tabAppliance.Controls.Add(_btnAddMain);
            _tabAppliance.Controls.Add(_cboMainApps);
            _tabAppliance.Controls.Add(_btnxxApplianceNext);
            _tabAppliance.Location = new Point(4, 22);
            _tabAppliance.Name = "tabAppliance";
            _tabAppliance.Size = new Size(877, 774);
            _tabAppliance.TabIndex = 3;
            _tabAppliance.Text = "Associated Assets";
            //
            // btnxx3
            //
            _btnxx3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnxx3.BackColor = SystemColors.Control;
            _btnxx3.BackgroundImage = (Image)resources.GetObject("btnxx3.BackgroundImage");
            _btnxx3.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxx3.Cursor = Cursors.Hand;
            _btnxx3.Location = new Point(3, 627);
            _btnxx3.Name = "btnxx3";
            _btnxx3.Size = new Size(62, 45);
            _btnxx3.TabIndex = 169;
            _btnxx3.UseVisualStyleBackColor = false;
            //
            // Label20
            //
            _Label20.AutoSize = true;
            _Label20.Font = new Font("Verdana", 10.0F);
            _Label20.Location = new Point(218, 97);
            _Label20.Name = "Label20";
            _Label20.Size = new Size(436, 17);
            _Label20.TabIndex = 168;
            _Label20.Text = "Add any asset either to be serviced or affected by the works";
            //
            // Label13
            //
            _Label13.AutoSize = true;
            _Label13.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label13.Location = new Point(291, 31);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(243, 25);
            _Label13.TabIndex = 150;
            _Label13.Text = "Associated Asset(s)";
            //
            // DgMain
            //
            _DgMain.AllowUserToAddRows = false;
            _DgMain.AllowUserToDeleteRows = false;
            _DgMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _DgMain.ColumnHeadersVisible = false;
            _DgMain.Location = new Point(292, 210);
            _DgMain.MultiSelect = false;
            _DgMain.Name = "DgMain";
            _DgMain.ReadOnly = true;
            _DgMain.RowHeadersVisible = false;
            _DgMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _DgMain.ShowCellErrors = false;
            _DgMain.ShowEditingIcon = false;
            _DgMain.ShowRowErrors = false;
            _DgMain.Size = new Size(293, 175);
            _DgMain.TabIndex = 149;
            //
            // btnMinusMain
            //
            _btnMinusMain.Location = new Point(392, 182);
            _btnMinusMain.Name = "btnMinusMain";
            _btnMinusMain.Size = new Size(39, 23);
            _btnMinusMain.TabIndex = 148;
            _btnMinusMain.Text = "-";
            _btnMinusMain.UseVisualStyleBackColor = true;
            //
            // btnAddMain
            //
            _btnAddMain.Location = new Point(437, 182);
            _btnAddMain.Name = "btnAddMain";
            _btnAddMain.Size = new Size(39, 23);
            _btnAddMain.TabIndex = 147;
            _btnAddMain.Text = "+";
            _btnAddMain.UseVisualStyleBackColor = true;
            //
            // cboMainApps
            //
            _cboMainApps.Cursor = Cursors.Hand;
            _cboMainApps.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboMainApps.Location = new Point(292, 155);
            _cboMainApps.Name = "cboMainApps";
            _cboMainApps.Size = new Size(293, 21);
            _cboMainApps.TabIndex = 146;
            _cboMainApps.Tag = "";
            //
            // btnxxApplianceNext
            //
            _btnxxApplianceNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnxxApplianceNext.BackColor = SystemColors.Control;
            _btnxxApplianceNext.BackgroundImage = (Image)resources.GetObject("btnxxApplianceNext.BackgroundImage");
            _btnxxApplianceNext.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxxApplianceNext.Cursor = Cursors.Hand;
            _btnxxApplianceNext.Location = new Point(812, 627);
            _btnxxApplianceNext.Name = "btnxxApplianceNext";
            _btnxxApplianceNext.Size = new Size(62, 45);
            _btnxxApplianceNext.TabIndex = 151;
            _btnxxApplianceNext.UseVisualStyleBackColor = false;
            _btnxxApplianceNext.Visible = false;
            //
            // tabJobType
            //
            _tabJobType.Controls.Add(_btnxxExternalBM);
            _tabJobType.Controls.Add(_btnxxCarpentry);
            _tabJobType.Controls.Add(_btnxxPlumbing);
            _tabJobType.Controls.Add(_btnxxElectrical);
            _tabJobType.Controls.Add(_btnxxMultiTrade);
            _tabJobType.Controls.Add(_btnxxKitchens);
            _tabJobType.Controls.Add(_btnxx1);
            _tabJobType.Controls.Add(_pnlSOR);
            _tabJobType.Controls.Add(_btnxxSOR);
            _tabJobType.Controls.Add(_lbltype);
            _tabJobType.Controls.Add(_cbotypeWiz);
            _tabJobType.Controls.Add(_btnxxBreakdown);
            _tabJobType.Controls.Add(_Label11);
            _tabJobType.Controls.Add(_BtnxxService);
            _tabJobType.Controls.Add(_btnxxOther);
            _tabJobType.Controls.Add(_btnxxJobNext);
            _tabJobType.Location = new Point(4, 22);
            _tabJobType.Name = "tabJobType";
            _tabJobType.Size = new Size(877, 774);
            _tabJobType.TabIndex = 8;
            _tabJobType.Text = "Job Type";
            //
            // btnxxExternalBM
            //
            _btnxxExternalBM.BackColor = SystemColors.Control;
            _btnxxExternalBM.Cursor = Cursors.Hand;
            _btnxxExternalBM.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxExternalBM.Location = new Point(196, 270);
            _btnxxExternalBM.Name = "btnxxExternalBM";
            _btnxxExternalBM.Size = new Size(511, 41);
            _btnxxExternalBM.TabIndex = 164;
            _btnxxExternalBM.Text = "Other External B and M";
            _btnxxExternalBM.UseVisualStyleBackColor = false;
            _btnxxExternalBM.Visible = false;
            //
            // btnxxCarpentry
            //
            _btnxxCarpentry.BackColor = SystemColors.Control;
            _btnxxCarpentry.Cursor = Cursors.Hand;
            _btnxxCarpentry.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxCarpentry.Location = new Point(196, 226);
            _btnxxCarpentry.Name = "btnxxCarpentry";
            _btnxxCarpentry.Size = new Size(511, 41);
            _btnxxCarpentry.TabIndex = 163;
            _btnxxCarpentry.Tag = "71039";
            _btnxxCarpentry.Text = "Carpentry";
            _btnxxCarpentry.UseVisualStyleBackColor = false;
            _btnxxCarpentry.Visible = false;
            //
            // btnxxPlumbing
            //
            _btnxxPlumbing.BackColor = SystemColors.Control;
            _btnxxPlumbing.Cursor = Cursors.Hand;
            _btnxxPlumbing.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxPlumbing.Location = new Point(196, 182);
            _btnxxPlumbing.Name = "btnxxPlumbing";
            _btnxxPlumbing.Size = new Size(511, 41);
            _btnxxPlumbing.TabIndex = 162;
            _btnxxPlumbing.Tag = "4754";
            _btnxxPlumbing.Text = "Plumbing";
            _btnxxPlumbing.UseVisualStyleBackColor = false;
            _btnxxPlumbing.Visible = false;
            //
            // btnxxElectrical
            //
            _btnxxElectrical.BackColor = SystemColors.Control;
            _btnxxElectrical.Cursor = Cursors.Hand;
            _btnxxElectrical.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxElectrical.Location = new Point(196, 138);
            _btnxxElectrical.Name = "btnxxElectrical";
            _btnxxElectrical.Size = new Size(511, 41);
            _btnxxElectrical.TabIndex = 161;
            _btnxxElectrical.Tag = "68121";
            _btnxxElectrical.Text = "Electrical";
            _btnxxElectrical.UseVisualStyleBackColor = false;
            _btnxxElectrical.Visible = false;
            //
            // btnxxMultiTrade
            //
            _btnxxMultiTrade.BackColor = SystemColors.Control;
            _btnxxMultiTrade.Cursor = Cursors.Hand;
            _btnxxMultiTrade.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxMultiTrade.Location = new Point(196, 94);
            _btnxxMultiTrade.Name = "btnxxMultiTrade";
            _btnxxMultiTrade.Size = new Size(511, 41);
            _btnxxMultiTrade.TabIndex = 160;
            _btnxxMultiTrade.Tag = "71044";
            _btnxxMultiTrade.Text = "Multi Trade";
            _btnxxMultiTrade.UseVisualStyleBackColor = false;
            _btnxxMultiTrade.Visible = false;
            //
            // btnxxKitchens
            //
            _btnxxKitchens.BackColor = SystemColors.Control;
            _btnxxKitchens.Cursor = Cursors.Hand;
            _btnxxKitchens.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxKitchens.Location = new Point(196, 50);
            _btnxxKitchens.Name = "btnxxKitchens";
            _btnxxKitchens.Size = new Size(511, 41);
            _btnxxKitchens.TabIndex = 159;
            _btnxxKitchens.Text = "Kitchens";
            _btnxxKitchens.UseVisualStyleBackColor = false;
            _btnxxKitchens.Visible = false;
            //
            // btnxx1
            //
            _btnxx1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnxx1.BackColor = SystemColors.Control;
            _btnxx1.BackgroundImage = (Image)resources.GetObject("btnxx1.BackgroundImage");
            _btnxx1.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxx1.Cursor = Cursors.Hand;
            _btnxx1.Location = new Point(3, 627);
            _btnxx1.Name = "btnxx1";
            _btnxx1.Size = new Size(62, 45);
            _btnxx1.TabIndex = 158;
            _btnxx1.UseVisualStyleBackColor = false;
            //
            // pnlSOR
            //
            _pnlSOR.Controls.Add(_DGSOR);
            _pnlSOR.Controls.Add(_btnxxFollow);
            _pnlSOR.Controls.Add(_txtSORQty);
            _pnlSOR.Controls.Add(_Label14);
            _pnlSOR.Controls.Add(_btnSORAdd);
            _pnlSOR.Controls.Add(_cboSOR);
            _pnlSOR.Controls.Add(_btnSORMinus);
            _pnlSOR.Location = new Point(193, 423);
            _pnlSOR.Name = "pnlSOR";
            _pnlSOR.Size = new Size(519, 159);
            _pnlSOR.TabIndex = 156;
            _pnlSOR.Visible = false;
            //
            // DGSOR
            //
            _DGSOR.AllowUserToAddRows = false;
            _DGSOR.AllowUserToDeleteRows = false;
            _DGSOR.AllowUserToResizeRows = false;
            _DGSOR.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _DGSOR.Location = new Point(3, 31);
            _DGSOR.MultiSelect = false;
            _DGSOR.Name = "DGSOR";
            _DGSOR.ReadOnly = true;
            _DGSOR.ShowCellErrors = false;
            _DGSOR.ShowEditingIcon = false;
            _DGSOR.ShowRowErrors = false;
            _DGSOR.Size = new Size(513, 120);
            _DGSOR.TabIndex = 150;
            //
            // btnxxFollow
            //
            _btnxxFollow.BackColor = SystemColors.Control;
            _btnxxFollow.Cursor = Cursors.Hand;
            _btnxxFollow.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxFollow.Location = new Point(3, 53);
            _btnxxFollow.Name = "btnxxFollow";
            _btnxxFollow.Size = new Size(511, 72);
            _btnxxFollow.TabIndex = 157;
            _btnxxFollow.Text = "Quoted Works /" + (char)13 + (char)10 + "Follow Up Works";
            _btnxxFollow.UseVisualStyleBackColor = false;
            _btnxxFollow.Visible = false;
            //
            // txtSORQty
            //
            _txtSORQty.Location = new Point(412, 5);
            _txtSORQty.Name = "txtSORQty";
            _txtSORQty.Size = new Size(44, 21);
            _txtSORQty.TabIndex = 155;
            _txtSORQty.Text = "1";
            //
            // Label14
            //
            _Label14.AutoSize = true;
            _Label14.Font = new Font("Verdana", 10.0F);
            _Label14.Location = new Point(382, 6);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(33, 17);
            _Label14.TabIndex = 154;
            _Label14.Text = "Qty";
            _Label14.Visible = false;
            //
            // btnSORAdd
            //
            _btnSORAdd.Location = new Point(488, 3);
            _btnSORAdd.Name = "btnSORAdd";
            _btnSORAdd.Size = new Size(26, 23);
            _btnSORAdd.TabIndex = 151;
            _btnSORAdd.Text = "+";
            _btnSORAdd.UseVisualStyleBackColor = true;
            //
            // cboSOR
            //
            _cboSOR.BackColor = SystemColors.Window;
            _cboSOR.Font = new Font("Verdana", 9.0F);
            _cboSOR.FormattingEnabled = true;
            _cboSOR.Location = new Point(3, 4);
            _cboSOR.Name = "cboSOR";
            _cboSOR.Size = new Size(373, 22);
            _cboSOR.TabIndex = 153;
            //
            // btnSORMinus
            //
            _btnSORMinus.Location = new Point(460, 3);
            _btnSORMinus.Name = "btnSORMinus";
            _btnSORMinus.Size = new Size(25, 23);
            _btnSORMinus.TabIndex = 152;
            _btnSORMinus.Text = "-";
            _btnSORMinus.UseVisualStyleBackColor = true;
            //
            // btnxxSOR
            //
            _btnxxSOR.BackColor = SystemColors.Control;
            _btnxxSOR.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxSOR.Location = new Point(196, 379);
            _btnxxSOR.Name = "btnxxSOR";
            _btnxxSOR.Size = new Size(513, 38);
            _btnxxSOR.TabIndex = 28;
            _btnxxSOR.Tag = "67098";
            _btnxxSOR.Text = "SOR Based Works";
            _btnxxSOR.UseVisualStyleBackColor = false;
            //
            // lbltype
            //
            _lbltype.AutoSize = true;
            _lbltype.Font = new Font("Verdana", 10.0F);
            _lbltype.Location = new Point(206, 324);
            _lbltype.Name = "lbltype";
            _lbltype.Size = new Size(70, 17);
            _lbltype.TabIndex = 9;
            _lbltype.Text = "Job Type";
            _lbltype.Visible = false;
            //
            // cbotypeWiz
            //
            _cbotypeWiz.BackColor = SystemColors.Window;
            _cbotypeWiz.Font = new Font("Verdana", 9.0F);
            _cbotypeWiz.FormattingEnabled = true;
            _cbotypeWiz.Location = new Point(282, 322);
            _cbotypeWiz.Name = "cbotypeWiz";
            _cbotypeWiz.Size = new Size(326, 22);
            _cbotypeWiz.TabIndex = 8;
            _cbotypeWiz.Visible = false;
            //
            // btnxxBreakdown
            //
            _btnxxBreakdown.BackColor = SystemColors.Control;
            _btnxxBreakdown.Cursor = Cursors.Hand;
            _btnxxBreakdown.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxBreakdown.Location = new Point(196, 147);
            _btnxxBreakdown.Name = "btnxxBreakdown";
            _btnxxBreakdown.Size = new Size(511, 72);
            _btnxxBreakdown.TabIndex = 4;
            _btnxxBreakdown.Tag = "4703";
            _btnxxBreakdown.Text = "Breakdown";
            _btnxxBreakdown.UseVisualStyleBackColor = false;
            //
            // Label11
            //
            _Label11.AutoSize = true;
            _Label11.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label11.Location = new Point(390, 23);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(117, 25);
            _Label11.TabIndex = 3;
            _Label11.Text = "Job Type";
            //
            // BtnxxService
            //
            _BtnxxService.BackColor = SystemColors.Control;
            _BtnxxService.Cursor = Cursors.Hand;
            _BtnxxService.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _BtnxxService.Location = new Point(196, 63);
            _BtnxxService.Name = "BtnxxService";
            _BtnxxService.Size = new Size(511, 72);
            _BtnxxService.TabIndex = 0;
            _BtnxxService.Tag = "519";
            _BtnxxService.Text = "Service";
            _BtnxxService.UseVisualStyleBackColor = false;
            //
            // btnxxOther
            //
            _btnxxOther.BackColor = SystemColors.Control;
            _btnxxOther.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxOther.Location = new Point(196, 314);
            _btnxxOther.Name = "btnxxOther";
            _btnxxOther.Size = new Size(511, 38);
            _btnxxOther.TabIndex = 5;
            _btnxxOther.Text = "Other";
            _btnxxOther.UseVisualStyleBackColor = false;
            //
            // btnxxJobNext
            //
            _btnxxJobNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnxxJobNext.BackColor = SystemColors.Control;
            _btnxxJobNext.BackgroundImage = (Image)resources.GetObject("btnxxJobNext.BackgroundImage");
            _btnxxJobNext.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxxJobNext.Cursor = Cursors.Hand;
            _btnxxJobNext.Location = new Point(812, 627);
            _btnxxJobNext.Name = "btnxxJobNext";
            _btnxxJobNext.Size = new Size(62, 45);
            _btnxxJobNext.TabIndex = 27;
            _btnxxJobNext.UseVisualStyleBackColor = false;
            _btnxxJobNext.Visible = false;
            //
            // tabProp
            //
            _tabProp.Controls.Add(_lblDefect);
            _tabProp.Controls.Add(_txtDefect);
            _tabProp.Controls.Add(_chbCommercial);
            _tabProp.Controls.Add(_lblContactAlert);
            _tabProp.Controls.Add(_txtContactAlert);
            _tabProp.Controls.Add(_txtSearchSite);
            _tabProp.Controls.Add(_txtName);
            _tabProp.Controls.Add(_txtSiteNotes);
            _tabProp.Controls.Add(_Label30);
            _tabProp.Controls.Add(_Label28);
            _tabProp.Controls.Add(_txtContractRef);
            _tabProp.Controls.Add(_btnJobHistory);
            _tabProp.Controls.Add(_btnxxSiteNext);
            _tabProp.Controls.Add(_Label10);
            _tabProp.Controls.Add(_txtCustomer);
            _tabProp.Controls.Add(_Label9);
            _tabProp.Controls.Add(_txtEmail);
            _tabProp.Controls.Add(_Label8);
            _tabProp.Controls.Add(_txtTel);
            _tabProp.Controls.Add(_Label6);
            _tabProp.Controls.Add(_txtMob);
            _tabProp.Controls.Add(_txtAddress3);
            _tabProp.Controls.Add(_Label7);
            _tabProp.Controls.Add(_Label5);
            _tabProp.Controls.Add(_Label4);
            _tabProp.Controls.Add(_Label3);
            _tabProp.Controls.Add(_Label2);
            _tabProp.Controls.Add(_cboTitle);
            _tabProp.Controls.Add(_txtAddress1);
            _tabProp.Controls.Add(_txtAddress2);
            _tabProp.Controls.Add(_txtPostcode);
            _tabProp.Controls.Add(_txtSurname);
            _tabProp.Controls.Add(_txtFirstName);
            _tabProp.Controls.Add(_btnEditSite);
            _tabProp.Controls.Add(_btnAddSite);
            _tabProp.Controls.Add(_Label1);
            _tabProp.Controls.Add(_txtSearch);
            _tabProp.Controls.Add(_DGVSites);
            _tabProp.Location = new Point(4, 22);
            _tabProp.Name = "tabProp";
            _tabProp.Size = new Size(877, 774);
            _tabProp.TabIndex = 0;
            _tabProp.Text = "Property";
            //
            // lblDefect
            //
            _lblDefect.AutoSize = true;
            _lblDefect.Location = new Point(208, 583);
            _lblDefect.Name = "lblDefect";
            _lblDefect.Size = new Size(109, 13);
            _lblDefect.TabIndex = 38;
            _lblDefect.Text = "Defect Contractor";
            //
            // txtDefect
            //
            _txtDefect.Location = new Point(318, 582);
            _txtDefect.Name = "txtDefect";
            _txtDefect.ReadOnly = true;
            _txtDefect.Size = new Size(300, 21);
            _txtDefect.TabIndex = 37;
            //
            // chbCommercial
            //
            _chbCommercial.AutoSize = true;
            _chbCommercial.Enabled = false;
            _chbCommercial.Location = new Point(476, 525);
            _chbCommercial.Name = "chbCommercial";
            _chbCommercial.RightToLeft = RightToLeft.Yes;
            _chbCommercial.Size = new Size(140, 17);
            _chbCommercial.TabIndex = 36;
            _chbCommercial.Text = "Commercial/District";
            _chbCommercial.UseVisualStyleBackColor = true;
            //
            // lblContactAlert
            //
            _lblContactAlert.AutoSize = true;
            _lblContactAlert.Location = new Point(208, 553);
            _lblContactAlert.Name = "lblContactAlert";
            _lblContactAlert.Size = new Size(88, 13);
            _lblContactAlert.TabIndex = 35;
            _lblContactAlert.Text = "Contact Alerts";
            //
            // txtContactAlert
            //
            _txtContactAlert.Location = new Point(318, 552);
            _txtContactAlert.Name = "txtContactAlert";
            _txtContactAlert.ReadOnly = true;
            _txtContactAlert.Size = new Size(300, 21);
            _txtContactAlert.TabIndex = 34;
            //
            // txtSearchSite
            //
            _txtSearchSite.Location = new Point(610, 56);
            _txtSearchSite.Name = "txtSearchSite";
            _txtSearchSite.Size = new Size(69, 21);
            _txtSearchSite.TabIndex = 33;
            _txtSearchSite.Text = "Search";
            _txtSearchSite.UseVisualStyleBackColor = true;
            //
            // txtName
            //
            _txtName.Location = new Point(448, 279);
            _txtName.Name = "txtName";
            _txtName.ReadOnly = true;
            _txtName.Size = new Size(171, 21);
            _txtName.TabIndex = 32;
            //
            // txtSiteNotes
            //
            _txtSiteNotes.Location = new Point(318, 611);
            _txtSiteNotes.Multiline = true;
            _txtSiteNotes.Name = "txtSiteNotes";
            _txtSiteNotes.ReadOnly = true;
            _txtSiteNotes.ScrollBars = ScrollBars.Vertical;
            _txtSiteNotes.Size = new Size(301, 55);
            _txtSiteNotes.TabIndex = 31;
            //
            // Label30
            //
            _Label30.AutoSize = true;
            _Label30.Location = new Point(208, 616);
            _Label30.Name = "Label30";
            _Label30.Size = new Size(65, 13);
            _Label30.TabIndex = 30;
            _Label30.Text = "Site Notes";
            //
            // Label28
            //
            _Label28.AutoSize = true;
            _Label28.Location = new Point(208, 525);
            _Label28.Name = "Label28";
            _Label28.Size = new Size(79, 13);
            _Label28.TabIndex = 29;
            _Label28.Text = "Contract Ref";
            //
            // txtContractRef
            //
            _txtContractRef.Cursor = Cursors.Hand;
            _txtContractRef.Location = new Point(318, 522);
            _txtContractRef.Name = "txtContractRef";
            _txtContractRef.ReadOnly = true;
            _txtContractRef.Size = new Size(121, 21);
            _txtContractRef.TabIndex = 28;
            //
            // btnJobHistory
            //
            _btnJobHistory.Location = new Point(318, 672);
            _btnJobHistory.Name = "btnJobHistory";
            _btnJobHistory.Size = new Size(144, 51);
            _btnJobHistory.TabIndex = 27;
            _btnJobHistory.Text = "Job History";
            _btnJobHistory.UseVisualStyleBackColor = true;
            //
            // btnxxSiteNext
            //
            _btnxxSiteNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnxxSiteNext.BackColor = SystemColors.Control;
            _btnxxSiteNext.BackgroundImage = (Image)resources.GetObject("btnxxSiteNext.BackgroundImage");
            _btnxxSiteNext.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxxSiteNext.Cursor = Cursors.Hand;
            _btnxxSiteNext.Location = new Point(812, 681);
            _btnxxSiteNext.Name = "btnxxSiteNext";
            _btnxxSiteNext.Size = new Size(62, 45);
            _btnxxSiteNext.TabIndex = 26;
            _btnxxSiteNext.UseVisualStyleBackColor = false;
            //
            // Label10
            //
            _Label10.AutoSize = true;
            _Label10.Location = new Point(208, 255);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(63, 13);
            _Label10.TabIndex = 25;
            _Label10.Text = "Customer";
            //
            // txtCustomer
            //
            _txtCustomer.Location = new Point(318, 252);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(301, 21);
            _txtCustomer.TabIndex = 24;
            //
            // Label9
            //
            _Label9.AutoSize = true;
            _Label9.Location = new Point(208, 498);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(38, 13);
            _Label9.TabIndex = 23;
            _Label9.Text = "Email";
            //
            // txtEmail
            //
            _txtEmail.Location = new Point(318, 495);
            _txtEmail.Name = "txtEmail";
            _txtEmail.ReadOnly = true;
            _txtEmail.Size = new Size(301, 21);
            _txtEmail.TabIndex = 22;
            //
            // Label8
            //
            _Label8.AutoSize = true;
            _Label8.Location = new Point(208, 471);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(46, 13);
            _Label8.TabIndex = 21;
            _Label8.Text = "Tel No.";
            //
            // txtTel
            //
            _txtTel.Location = new Point(318, 468);
            _txtTel.Name = "txtTel";
            _txtTel.ReadOnly = true;
            _txtTel.Size = new Size(121, 21);
            _txtTel.TabIndex = 20;
            //
            // Label6
            //
            _Label6.AutoSize = true;
            _Label6.Location = new Point(445, 471);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(53, 13);
            _Label6.TabIndex = 19;
            _Label6.Text = "Mob No.";
            //
            // txtMob
            //
            _txtMob.Location = new Point(498, 468);
            _txtMob.Name = "txtMob";
            _txtMob.ReadOnly = true;
            _txtMob.Size = new Size(121, 21);
            _txtMob.TabIndex = 18;
            //
            // txtAddress3
            //
            _txtAddress3.Location = new Point(318, 414);
            _txtAddress3.Name = "txtAddress3";
            _txtAddress3.ReadOnly = true;
            _txtAddress3.Size = new Size(301, 21);
            _txtAddress3.TabIndex = 17;
            //
            // Label7
            //
            _Label7.AutoSize = true;
            _Label7.Location = new Point(208, 444);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(58, 13);
            _Label7.TabIndex = 16;
            _Label7.Text = "Postcode";
            //
            // Label5
            //
            _Label5.AutoSize = true;
            _Label5.Location = new Point(208, 363);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(57, 13);
            _Label5.TabIndex = 14;
            _Label5.Text = "Address ";
            //
            // Label4
            //
            _Label4.AutoSize = true;
            _Label4.Location = new Point(208, 336);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(59, 13);
            _Label4.TabIndex = 13;
            _Label4.Text = "Surname";
            //
            // Label3
            //
            _Label3.AutoSize = true;
            _Label3.Location = new Point(208, 309);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(68, 13);
            _Label3.TabIndex = 12;
            _Label3.Text = "First Name";
            //
            // Label2
            //
            _Label2.AutoSize = true;
            _Label2.Location = new Point(208, 282);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(31, 13);
            _Label2.TabIndex = 11;
            _Label2.Text = "Title";
            //
            // cboTitle
            //
            _cboTitle.Enabled = false;
            _cboTitle.FormattingEnabled = true;
            _cboTitle.Location = new Point(318, 279);
            _cboTitle.Name = "cboTitle";
            _cboTitle.Size = new Size(121, 21);
            _cboTitle.TabIndex = 10;
            //
            // txtAddress1
            //
            _txtAddress1.Location = new Point(318, 360);
            _txtAddress1.Name = "txtAddress1";
            _txtAddress1.ReadOnly = true;
            _txtAddress1.Size = new Size(301, 21);
            _txtAddress1.TabIndex = 9;
            //
            // txtAddress2
            //
            _txtAddress2.Location = new Point(318, 387);
            _txtAddress2.Name = "txtAddress2";
            _txtAddress2.ReadOnly = true;
            _txtAddress2.Size = new Size(301, 21);
            _txtAddress2.TabIndex = 8;
            //
            // txtPostcode
            //
            _txtPostcode.Location = new Point(318, 441);
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.ReadOnly = true;
            _txtPostcode.Size = new Size(301, 21);
            _txtPostcode.TabIndex = 7;
            //
            // txtSurname
            //
            _txtSurname.Location = new Point(318, 333);
            _txtSurname.Name = "txtSurname";
            _txtSurname.ReadOnly = true;
            _txtSurname.Size = new Size(301, 21);
            _txtSurname.TabIndex = 6;
            //
            // txtFirstName
            //
            _txtFirstName.Location = new Point(318, 306);
            _txtFirstName.Name = "txtFirstName";
            _txtFirstName.ReadOnly = true;
            _txtFirstName.Size = new Size(301, 21);
            _txtFirstName.TabIndex = 5;
            //
            // btnEditSite
            //
            _btnEditSite.Location = new Point(468, 672);
            _btnEditSite.Name = "btnEditSite";
            _btnEditSite.Size = new Size(151, 51);
            _btnEditSite.TabIndex = 4;
            _btnEditSite.Text = "Ammend Other " + (char)13 + (char)10 + "Fields / View Other Notes";
            _btnEditSite.UseVisualStyleBackColor = true;
            //
            // btnAddSite
            //
            _btnAddSite.Location = new Point(788, 54);
            _btnAddSite.Name = "btnAddSite";
            _btnAddSite.Size = new Size(75, 23);
            _btnAddSite.TabIndex = 3;
            _btnAddSite.Text = "Add Site";
            _btnAddSite.UseVisualStyleBackColor = true;
            //
            // Label1
            //
            _Label1.AutoSize = true;
            _Label1.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(383, 24);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(145, 25);
            _Label1.TabIndex = 2;
            _Label1.Text = "Search Site";
            //
            // txtSearch
            //
            _txtSearch.Location = new Point(303, 56);
            _txtSearch.Name = "txtSearch";
            _txtSearch.Size = new Size(301, 21);
            _txtSearch.TabIndex = 1;
            //
            // DGVSites
            //
            _DGVSites.AllowUserToAddRows = false;
            _DGVSites.AllowUserToDeleteRows = false;
            _DGVSites.AllowUserToOrderColumns = true;
            _DGVSites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _DGVSites.EditMode = DataGridViewEditMode.EditProgrammatically;
            _DGVSites.Location = new Point(14, 88);
            _DGVSites.MultiSelect = false;
            _DGVSites.Name = "DGVSites";
            _DGVSites.ReadOnly = true;
            _DGVSites.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _DGVSites.Size = new Size(849, 150);
            _DGVSites.TabIndex = 0;
            //
            // tcSites
            //
            _tcSites.Controls.Add(_tabProp);
            _tcSites.Controls.Add(_tabExistingJobs);
            _tcSites.Controls.Add(_tabJobType);
            _tcSites.Controls.Add(_tabJobDetails);
            _tcSites.Controls.Add(_tabAppliance);
            _tcSites.Controls.Add(_tabAdditional);
            _tcSites.Controls.Add(_TabCharging);
            _tcSites.Controls.Add(_TabBook);
            _tcSites.Controls.Add(_tcComplete);
            _tcSites.Dock = DockStyle.Fill;
            _tcSites.Location = new Point(0, 0);
            _tcSites.Name = "tcSites";
            _tcSites.SelectedIndex = 0;
            _tcSites.Size = new Size(885, 800);
            _tcSites.TabIndex = 0;
            //
            // tabExistingJobs
            //
            _tabExistingJobs.BackColor = SystemColors.Control;
            _tabExistingJobs.Controls.Add(_btnxxExistingJobBack);
            _tabExistingJobs.Controls.Add(_btnxxExistingJobNext);
            _tabExistingJobs.Controls.Add(_dgExistingVisits);
            _tabExistingJobs.Controls.Add(_Label29);
            _tabExistingJobs.Controls.Add(_btnxxNewJob);
            _tabExistingJobs.Location = new Point(4, 22);
            _tabExistingJobs.Name = "tabExistingJobs";
            _tabExistingJobs.Size = new Size(877, 774);
            _tabExistingJobs.TabIndex = 13;
            _tabExistingJobs.Text = "ExistingJobs";
            //
            // btnxxExistingJobBack
            //
            _btnxxExistingJobBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnxxExistingJobBack.BackColor = SystemColors.Control;
            _btnxxExistingJobBack.BackgroundImage = (Image)resources.GetObject("btnxxExistingJobBack.BackgroundImage");
            _btnxxExistingJobBack.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxxExistingJobBack.Cursor = Cursors.Hand;
            _btnxxExistingJobBack.Location = new Point(3, 627);
            _btnxxExistingJobBack.Name = "btnxxExistingJobBack";
            _btnxxExistingJobBack.Size = new Size(62, 45);
            _btnxxExistingJobBack.TabIndex = 179;
            _btnxxExistingJobBack.UseVisualStyleBackColor = false;
            //
            // btnxxExistingJobNext
            //
            _btnxxExistingJobNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnxxExistingJobNext.BackColor = SystemColors.Control;
            _btnxxExistingJobNext.BackgroundImage = (Image)resources.GetObject("btnxxExistingJobNext.BackgroundImage");
            _btnxxExistingJobNext.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxxExistingJobNext.Cursor = Cursors.Hand;
            _btnxxExistingJobNext.Location = new Point(812, 627);
            _btnxxExistingJobNext.Name = "btnxxExistingJobNext";
            _btnxxExistingJobNext.Size = new Size(62, 45);
            _btnxxExistingJobNext.TabIndex = 178;
            _btnxxExistingJobNext.UseVisualStyleBackColor = false;
            //
            // dgExistingVisits
            //
            _dgExistingVisits.AllowUserToAddRows = false;
            _dgExistingVisits.AllowUserToDeleteRows = false;
            _dgExistingVisits.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dgExistingVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgExistingVisits.ColumnHeadersVisible = false;
            _dgExistingVisits.Location = new Point(40, 103);
            _dgExistingVisits.MultiSelect = false;
            _dgExistingVisits.Name = "dgExistingVisits";
            _dgExistingVisits.ReadOnly = true;
            _dgExistingVisits.RowHeadersVisible = false;
            _dgExistingVisits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgExistingVisits.ShowCellErrors = false;
            _dgExistingVisits.ShowEditingIcon = false;
            _dgExistingVisits.ShowRowErrors = false;
            _dgExistingVisits.Size = new Size(805, 164);
            _dgExistingVisits.TabIndex = 177;
            //
            // Label29
            //
            _Label29.AutoSize = true;
            _Label29.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label29.Location = new Point(314, 35);
            _Label29.Name = "Label29";
            _Label29.Size = new Size(249, 25);
            _Label29.TabIndex = 5;
            _Label29.Text = "New Or Existing Job";
            //
            // btnxxNewJob
            //
            _btnxxNewJob.BackColor = SystemColors.Control;
            _btnxxNewJob.Cursor = Cursors.Hand;
            _btnxxNewJob.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnxxNewJob.Location = new Point(173, 319);
            _btnxxNewJob.Name = "btnxxNewJob";
            _btnxxNewJob.Size = new Size(511, 72);
            _btnxxNewJob.TabIndex = 4;
            _btnxxNewJob.Text = "New Job";
            _btnxxNewJob.UseVisualStyleBackColor = false;
            //
            // tabAdditional
            //
            _tabAdditional.Controls.Add(_chkCert);
            _tabAdditional.Controls.Add(_lblcert);
            _tabAdditional.Controls.Add(_btnxx4);
            _tabAdditional.Controls.Add(_lblCoverplanServ);
            _tabAdditional.Controls.Add(_Label22);
            _tabAdditional.Controls.Add(_Label21);
            _tabAdditional.Controls.Add(_cboAdditional);
            _tabAdditional.Controls.Add(_DGAdditional);
            _tabAdditional.Controls.Add(_btnAdditionalMinus);
            _tabAdditional.Controls.Add(_btnAdditionalPlus);
            _tabAdditional.Controls.Add(_btnxxAdditionalNext);
            _tabAdditional.Location = new Point(4, 22);
            _tabAdditional.Name = "tabAdditional";
            _tabAdditional.Size = new Size(877, 774);
            _tabAdditional.TabIndex = 10;
            _tabAdditional.Text = "Additional Items";
            _tabAdditional.UseVisualStyleBackColor = true;
            //
            // chkCert
            //
            _chkCert.CheckAlign = ContentAlignment.MiddleCenter;
            _chkCert.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkCert.Location = new Point(561, 431);
            _chkCert.Name = "chkCert";
            _chkCert.Size = new Size(40, 40);
            _chkCert.TabIndex = 184;
            _chkCert.UseVisualStyleBackColor = true;
            //
            // lblcert
            //
            _lblcert.AutoSize = true;
            _lblcert.Font = new Font("Verdana", 10.0F);
            _lblcert.ForeColor = Color.Maroon;
            _lblcert.Location = new Point(311, 442);
            _lblcert.Name = "lblcert";
            _lblcert.Size = new Size(145, 17);
            _lblcert.TabIndex = 183;
            _lblcert.Text = "L/L Cert Required? ";
            _lblcert.Visible = false;
            //
            // btnxx4
            //
            _btnxx4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnxx4.BackColor = SystemColors.Control;
            _btnxx4.BackgroundImage = (Image)resources.GetObject("btnxx4.BackgroundImage");
            _btnxx4.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxx4.Cursor = Cursors.Hand;
            _btnxx4.Location = new Point(3, 627);
            _btnxx4.Name = "btnxx4";
            _btnxx4.Size = new Size(62, 45);
            _btnxx4.TabIndex = 182;
            _btnxx4.UseVisualStyleBackColor = false;
            //
            // lblCoverplanServ
            //
            _lblCoverplanServ.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _lblCoverplanServ.Font = new Font("Verdana", 16.0F, FontStyle.Bold);
            _lblCoverplanServ.ForeColor = Color.Red;
            _lblCoverplanServ.Location = new Point(145, 80);
            _lblCoverplanServ.Name = "lblCoverplanServ";
            _lblCoverplanServ.Size = new Size(594, 106);
            _lblCoverplanServ.TabIndex = 181;
            _lblCoverplanServ.Text = "This Site Has A Coverplan Service Outstanding";
            _lblCoverplanServ.TextAlign = ContentAlignment.MiddleCenter;
            _lblCoverplanServ.Visible = false;
            //
            // Label22
            //
            _Label22.AutoSize = true;
            _Label22.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label22.Location = new Point(349, 35);
            _Label22.Name = "Label22";
            _Label22.Size = new Size(208, 25);
            _Label22.TabIndex = 179;
            _Label22.Text = "Additional Items";
            //
            // Label21
            //
            _Label21.AutoSize = true;
            _Label21.Font = new Font("Verdana", 10.0F);
            _Label21.Location = new Point(138, 240);
            _Label21.Name = "Label21";
            _Label21.Size = new Size(114, 17);
            _Label21.TabIndex = 178;
            _Label21.Text = "Additional Item";
            //
            // cboAdditional
            //
            _cboAdditional.Font = new Font("Verdana", 9.0F);
            _cboAdditional.FormattingEnabled = true;
            _cboAdditional.Location = new Point(314, 238);
            _cboAdditional.Name = "cboAdditional";
            _cboAdditional.Size = new Size(285, 22);
            _cboAdditional.TabIndex = 177;
            //
            // DGAdditional
            //
            _DGAdditional.AllowUserToAddRows = false;
            _DGAdditional.AllowUserToDeleteRows = false;
            _DGAdditional.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _DGAdditional.ColumnHeadersVisible = false;
            _DGAdditional.Location = new Point(141, 294);
            _DGAdditional.MultiSelect = false;
            _DGAdditional.Name = "DGAdditional";
            _DGAdditional.ReadOnly = true;
            _DGAdditional.RowHeadersVisible = false;
            _DGAdditional.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _DGAdditional.ShowCellErrors = false;
            _DGAdditional.ShowEditingIcon = false;
            _DGAdditional.ShowRowErrors = false;
            _DGAdditional.Size = new Size(598, 113);
            _DGAdditional.TabIndex = 176;
            //
            // btnAdditionalMinus
            //
            _btnAdditionalMinus.Location = new Point(406, 266);
            _btnAdditionalMinus.Name = "btnAdditionalMinus";
            _btnAdditionalMinus.Size = new Size(39, 23);
            _btnAdditionalMinus.TabIndex = 175;
            _btnAdditionalMinus.Text = "-";
            _btnAdditionalMinus.UseVisualStyleBackColor = true;
            //
            // btnAdditionalPlus
            //
            _btnAdditionalPlus.Location = new Point(451, 266);
            _btnAdditionalPlus.Name = "btnAdditionalPlus";
            _btnAdditionalPlus.Size = new Size(39, 23);
            _btnAdditionalPlus.TabIndex = 174;
            _btnAdditionalPlus.Text = "+";
            _btnAdditionalPlus.UseVisualStyleBackColor = true;
            //
            // btnxxAdditionalNext
            //
            _btnxxAdditionalNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnxxAdditionalNext.BackColor = SystemColors.Control;
            _btnxxAdditionalNext.BackgroundImage = (Image)resources.GetObject("btnxxAdditionalNext.BackgroundImage");
            _btnxxAdditionalNext.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxxAdditionalNext.Cursor = Cursors.Hand;
            _btnxxAdditionalNext.Location = new Point(812, 627);
            _btnxxAdditionalNext.Name = "btnxxAdditionalNext";
            _btnxxAdditionalNext.Size = new Size(62, 45);
            _btnxxAdditionalNext.TabIndex = 180;
            _btnxxAdditionalNext.UseVisualStyleBackColor = false;
            _btnxxAdditionalNext.Visible = false;
            //
            // TabCharging
            //
            _TabCharging.Controls.Add(_lblUnabletoConfirm);
            _TabCharging.Controls.Add(_btnxx5);
            _TabCharging.Controls.Add(_Label16);
            _TabCharging.Controls.Add(_cboPayTerms);
            _TabCharging.Controls.Add(_chkRecall);
            _TabCharging.Controls.Add(_Label19);
            _TabCharging.Controls.Add(_Label18);
            _TabCharging.Controls.Add(_pnlCharge);
            _TabCharging.Controls.Add(_txtPayInst);
            _TabCharging.Controls.Add(_btnxxChargeNext);
            _TabCharging.Font = new Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _TabCharging.Location = new Point(4, 22);
            _TabCharging.Name = "TabCharging";
            _TabCharging.Size = new Size(877, 774);
            _TabCharging.TabIndex = 9;
            _TabCharging.Text = "Charging";
            _TabCharging.UseVisualStyleBackColor = true;
            //
            // lblUnabletoConfirm
            //
            _lblUnabletoConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _lblUnabletoConfirm.Font = new Font("Verdana", 16.0F, FontStyle.Bold);
            _lblUnabletoConfirm.ForeColor = Color.Red;
            _lblUnabletoConfirm.Location = new Point(141, 269);
            _lblUnabletoConfirm.Name = "lblUnabletoConfirm";
            _lblUnabletoConfirm.Size = new Size(594, 106);
            _lblUnabletoConfirm.TabIndex = 182;
            _lblUnabletoConfirm.Text = "Unable to confirm if any payment is due please check notes";
            _lblUnabletoConfirm.TextAlign = ContentAlignment.MiddleCenter;
            _lblUnabletoConfirm.Visible = false;
            //
            // btnxx5
            //
            _btnxx5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnxx5.BackColor = SystemColors.Control;
            _btnxx5.BackgroundImage = (Image)resources.GetObject("btnxx5.BackgroundImage");
            _btnxx5.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxx5.Cursor = Cursors.Hand;
            _btnxx5.Location = new Point(3, 627);
            _btnxx5.Name = "btnxx5";
            _btnxx5.Size = new Size(62, 45);
            _btnxx5.TabIndex = 176;
            _btnxx5.UseVisualStyleBackColor = false;
            //
            // Label16
            //
            _Label16.AutoSize = true;
            _Label16.Font = new Font("Verdana", 10.0F);
            _Label16.Location = new Point(142, 561);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(115, 17);
            _Label16.TabIndex = 175;
            _Label16.Text = "Payment Terms";
            //
            // cboPayTerms
            //
            _cboPayTerms.Font = new Font("Verdana", 9.0F);
            _cboPayTerms.FormattingEnabled = true;
            _cboPayTerms.Location = new Point(318, 561);
            _cboPayTerms.Name = "cboPayTerms";
            _cboPayTerms.Size = new Size(285, 22);
            _cboPayTerms.TabIndex = 174;
            //
            // chkRecall
            //
            _chkRecall.AutoSize = true;
            _chkRecall.Font = new Font("Verdana", 12.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkRecall.ForeColor = Color.Red;
            _chkRecall.Location = new Point(445, 239);
            _chkRecall.Name = "chkRecall";
            _chkRecall.Size = new Size(15, 14);
            _chkRecall.TabIndex = 168;
            _chkRecall.UseVisualStyleBackColor = true;
            //
            // Label19
            //
            _Label19.AutoSize = true;
            _Label19.Font = new Font("Verdana", 10.0F);
            _Label19.Location = new Point(142, 237);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(47, 17);
            _Label19.TabIndex = 167;
            _Label19.Text = "Recall";
            //
            // Label18
            //
            _Label18.AutoSize = true;
            _Label18.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label18.Location = new Point(389, 28);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(118, 25);
            _Label18.TabIndex = 166;
            _Label18.Text = "Charging";
            //
            // pnlCharge
            //
            _pnlCharge.Controls.Add(_picTick);
            _pnlCharge.Controls.Add(_Label35);
            _pnlCharge.Controls.Add(_txtDiscountCode);
            _pnlCharge.Controls.Add(_Label17);
            _pnlCharge.Controls.Add(_txtCharge);
            _pnlCharge.Controls.Add(_picCross);
            _pnlCharge.Location = new Point(132, 458);
            _pnlCharge.Name = "pnlCharge";
            _pnlCharge.Size = new Size(611, 78);
            _pnlCharge.TabIndex = 165;
            //
            // picTick
            //
            _picTick.BackColor = Color.White;
            _picTick.BackgroundImage = My.Resources.Resources.tick;
            _picTick.Cursor = Cursors.No;
            _picTick.Image = My.Resources.Resources.tick;
            _picTick.InitialImage = My.Resources.Resources.tick;
            _picTick.Location = new Point(407, 6);
            _picTick.Name = "picTick";
            _picTick.Size = new Size(33, 27);
            _picTick.SizeMode = PictureBoxSizeMode.StretchImage;
            _picTick.TabIndex = 183;
            _picTick.TabStop = false;
            _picTick.Visible = false;
            //
            // Label35
            //
            _Label35.AutoSize = true;
            _Label35.Font = new Font("Verdana", 10.0F);
            _Label35.Location = new Point(10, 11);
            _Label35.Name = "Label35";
            _Label35.Size = new Size(132, 17);
            _Label35.TabIndex = 168;
            _Label35.Text = "Promotional Code";
            //
            // txtDiscountCode
            //
            _txtDiscountCode.Location = new Point(255, 6);
            _txtDiscountCode.Name = "txtDiscountCode";
            _txtDiscountCode.Size = new Size(123, 27);
            _txtDiscountCode.TabIndex = 167;
            _txtDiscountCode.TextAlign = HorizontalAlignment.Center;
            //
            // Label17
            //
            _Label17.AutoSize = true;
            _Label17.Font = new Font("Verdana", 10.0F);
            _Label17.Location = new Point(10, 44);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(232, 17);
            _Label17.TabIndex = 166;
            _Label17.Text = "Payment On Completion Charge";
            //
            // txtCharge
            //
            _txtCharge.Location = new Point(255, 39);
            _txtCharge.Name = "txtCharge";
            _txtCharge.Size = new Size(123, 27);
            _txtCharge.TabIndex = 165;
            _txtCharge.Text = "0";
            _txtCharge.TextAlign = HorizontalAlignment.Center;
            //
            // picCross
            //
            _picCross.BackColor = Color.White;
            _picCross.BackgroundImage = My.Resources.Resources.cross;
            _picCross.Cursor = Cursors.No;
            _picCross.Image = My.Resources.Resources.cross;
            _picCross.InitialImage = My.Resources.Resources.cross;
            _picCross.Location = new Point(407, 6);
            _picCross.Name = "picCross";
            _picCross.Size = new Size(33, 27);
            _picCross.SizeMode = PictureBoxSizeMode.StretchImage;
            _picCross.TabIndex = 184;
            _picCross.TabStop = false;
            _picCross.Visible = false;
            //
            // txtPayInst
            //
            _txtPayInst.Location = new Point(145, 75);
            _txtPayInst.Multiline = true;
            _txtPayInst.Name = "txtPayInst";
            _txtPayInst.ReadOnly = true;
            _txtPayInst.Size = new Size(598, 141);
            _txtPayInst.TabIndex = 0;
            _txtPayInst.TextAlign = HorizontalAlignment.Center;
            //
            // btnxxChargeNext
            //
            _btnxxChargeNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnxxChargeNext.BackColor = SystemColors.Control;
            _btnxxChargeNext.BackgroundImage = (Image)resources.GetObject("btnxxChargeNext.BackgroundImage");
            _btnxxChargeNext.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxxChargeNext.Cursor = Cursors.Hand;
            _btnxxChargeNext.Location = new Point(812, 627);
            _btnxxChargeNext.Name = "btnxxChargeNext";
            _btnxxChargeNext.Size = new Size(62, 45);
            _btnxxChargeNext.TabIndex = 162;
            _btnxxChargeNext.UseVisualStyleBackColor = false;
            _btnxxChargeNext.Visible = false;
            //
            // TabBook
            //
            _TabBook.Controls.Add(_btnOption8);
            _TabBook.Controls.Add(_btnOption7);
            _TabBook.Controls.Add(_btnOption6);
            _TabBook.Controls.Add(_btnOption5);
            _TabBook.Controls.Add(_btnRefresh);
            _TabBook.Controls.Add(_Label31);
            _TabBook.Controls.Add(_Label24);
            _TabBook.Controls.Add(_cboEngineer);
            _TabBook.Controls.Add(_btnxx6);
            _TabBook.Controls.Add(_gpCombo);
            _TabBook.Controls.Add(_lblBookText);
            _TabBook.Controls.Add(_Label23);
            _TabBook.Controls.Add(_dtpFromDate);
            _TabBook.Controls.Add(_btnOption10);
            _TabBook.Controls.Add(_btnOption4);
            _TabBook.Controls.Add(_btnOption3);
            _TabBook.Controls.Add(_btnOption2);
            _TabBook.Controls.Add(_btnOption1);
            _TabBook.Controls.Add(_chkKeepTogether);
            _TabBook.Location = new Point(4, 22);
            _TabBook.Name = "TabBook";
            _TabBook.Size = new Size(877, 774);
            _TabBook.TabIndex = 11;
            _TabBook.Text = "Book Visit";
            _TabBook.UseVisualStyleBackColor = true;
            //
            // btnOption8
            //
            _btnOption8.BackColor = Color.PaleGreen;
            _btnOption8.Cursor = Cursors.Hand;
            _btnOption8.Font = new Font("Verdana", 14.0F);
            _btnOption8.ImageAlign = ContentAlignment.TopCenter;
            _btnOption8.Location = new Point(441, 422);
            _btnOption8.Name = "btnOption8";
            _btnOption8.Size = new Size(404, 72);
            _btnOption8.TabIndex = 187;
            _btnOption8.Text = "Searching.....";
            _btnOption8.TextAlign = ContentAlignment.TopCenter;
            _btnOption8.UseVisualStyleBackColor = false;
            //
            // btnOption7
            //
            _btnOption7.BackColor = Color.PaleGreen;
            _btnOption7.Cursor = Cursors.Hand;
            _btnOption7.Font = new Font("Verdana", 14.0F);
            _btnOption7.ImageAlign = ContentAlignment.TopCenter;
            _btnOption7.Location = new Point(33, 422);
            _btnOption7.Name = "btnOption7";
            _btnOption7.Size = new Size(404, 72);
            _btnOption7.TabIndex = 186;
            _btnOption7.Text = "Searching.....";
            _btnOption7.TextAlign = ContentAlignment.TopCenter;
            _btnOption7.UseVisualStyleBackColor = false;
            //
            // btnOption6
            //
            _btnOption6.BackColor = Color.PaleGreen;
            _btnOption6.Cursor = Cursors.Hand;
            _btnOption6.Font = new Font("Verdana", 14.0F);
            _btnOption6.ImageAlign = ContentAlignment.TopCenter;
            _btnOption6.Location = new Point(441, 344);
            _btnOption6.Name = "btnOption6";
            _btnOption6.Size = new Size(404, 72);
            _btnOption6.TabIndex = 185;
            _btnOption6.Text = "Searching.....";
            _btnOption6.TextAlign = ContentAlignment.TopCenter;
            _btnOption6.UseVisualStyleBackColor = false;
            //
            // btnOption5
            //
            _btnOption5.BackColor = Color.PaleGreen;
            _btnOption5.Cursor = Cursors.Hand;
            _btnOption5.Font = new Font("Verdana", 14.0F);
            _btnOption5.ImageAlign = ContentAlignment.TopCenter;
            _btnOption5.Location = new Point(33, 344);
            _btnOption5.Name = "btnOption5";
            _btnOption5.Size = new Size(404, 72);
            _btnOption5.TabIndex = 184;
            _btnOption5.Text = "Searching.....";
            _btnOption5.TextAlign = ContentAlignment.TopCenter;
            _btnOption5.UseVisualStyleBackColor = false;
            //
            // btnRefresh
            //
            _btnRefresh.Location = new Point(754, 137);
            _btnRefresh.Name = "btnRefresh";
            _btnRefresh.Size = new Size(75, 23);
            _btnRefresh.TabIndex = 183;
            _btnRefresh.Text = "Refresh";
            _btnRefresh.UseVisualStyleBackColor = true;
            //
            // Label31
            //
            _Label31.AutoSize = true;
            _Label31.Location = new Point(167, 575);
            _Label31.Name = "Label31";
            _Label31.Size = new Size(539, 13);
            _Label31.TabIndex = 182;
            _Label31.Text = "Green = Best Selection(s)   , Orange = Not as efficient option ,  Red = Only use " + "if authorised";
            //
            // Label24
            //
            _Label24.AutoSize = true;
            _Label24.Font = new Font("Verdana", 10.0F);
            _Label24.Location = new Point(42, 140);
            _Label24.Name = "Label24";
            _Label24.Size = new Size(126, 17);
            _Label24.TabIndex = 181;
            _Label24.Text = "Specific Engineer";
            //
            // cboEngineer
            //
            _cboEngineer.Font = new Font("Verdana", 9.0F);
            _cboEngineer.FormattingEnabled = true;
            _cboEngineer.Location = new Point(215, 138);
            _cboEngineer.Name = "cboEngineer";
            _cboEngineer.Size = new Size(176, 22);
            _cboEngineer.TabIndex = 180;
            //
            // btnxx6
            //
            _btnxx6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnxx6.BackColor = SystemColors.Control;
            _btnxx6.BackgroundImage = (Image)resources.GetObject("btnxx6.BackgroundImage");
            _btnxx6.BackgroundImageLayout = ImageLayout.Stretch;
            _btnxx6.Cursor = Cursors.Hand;
            _btnxx6.Location = new Point(3, 627);
            _btnxx6.Name = "btnxx6";
            _btnxx6.Size = new Size(62, 45);
            _btnxx6.TabIndex = 179;
            _btnxx6.UseVisualStyleBackColor = false;
            //
            // gpCombo
            //
            _gpCombo.Controls.Add(_cboAppointment);
            _gpCombo.ForeColor = SystemColors.ActiveCaptionText;
            _gpCombo.Location = new Point(401, 86);
            _gpCombo.Name = "gpCombo";
            _gpCombo.Size = new Size(434, 51);
            _gpCombo.TabIndex = 178;
            _gpCombo.TabStop = false;
            _gpCombo.Text = "Appointment Type";
            //
            // cboAppointment
            //
            _cboAppointment.Font = new Font("Verdana", 9.0F);
            _cboAppointment.FormattingEnabled = true;
            _cboAppointment.Location = new Point(6, 16);
            _cboAppointment.Name = "cboAppointment";
            _cboAppointment.Size = new Size(422, 22);
            _cboAppointment.TabIndex = 175;
            //
            // lblBookText
            //
            _lblBookText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _lblBookText.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblBookText.Location = new Point(3, 49);
            _lblBookText.Name = "lblBookText";
            _lblBookText.Size = new Size(871, 34);
            _lblBookText.TabIndex = 177;
            _lblBookText.Text = "Booking Visits";
            _lblBookText.TextAlign = ContentAlignment.MiddleCenter;
            //
            // Label23
            //
            _Label23.AutoSize = true;
            _Label23.Font = new Font("Verdana", 10.0F);
            _Label23.Location = new Point(42, 104);
            _Label23.Name = "Label23";
            _Label23.Size = new Size(106, 17);
            _Label23.TabIndex = 176;
            _Label23.Text = "Booking From";
            //
            // dtpFromDate
            //
            _dtpFromDate.Location = new Point(215, 102);
            _dtpFromDate.Name = "dtpFromDate";
            _dtpFromDate.Size = new Size(176, 21);
            _dtpFromDate.TabIndex = 175;
            //
            // btnOption10
            //
            _btnOption10.BackColor = Color.PaleGreen;
            _btnOption10.Cursor = Cursors.Hand;
            _btnOption10.Font = new Font("Verdana", 14.0F);
            _btnOption10.ImageAlign = ContentAlignment.TopCenter;
            _btnOption10.Location = new Point(33, 500);
            _btnOption10.Name = "btnOption10";
            _btnOption10.Size = new Size(812, 72);
            _btnOption10.TabIndex = 174;
            _btnOption10.Text = "Searching.....";
            _btnOption10.TextAlign = ContentAlignment.TopCenter;
            _btnOption10.UseVisualStyleBackColor = false;
            //
            // btnOption4
            //
            _btnOption4.BackColor = Color.PaleGreen;
            _btnOption4.Cursor = Cursors.Hand;
            _btnOption4.Font = new Font("Verdana", 14.0F);
            _btnOption4.ImageAlign = ContentAlignment.TopCenter;
            _btnOption4.Location = new Point(441, 266);
            _btnOption4.Name = "btnOption4";
            _btnOption4.Size = new Size(404, 72);
            _btnOption4.TabIndex = 173;
            _btnOption4.Text = "Searching.....";
            _btnOption4.TextAlign = ContentAlignment.TopCenter;
            _btnOption4.UseVisualStyleBackColor = false;
            //
            // btnOption3
            //
            _btnOption3.BackColor = Color.PaleGreen;
            _btnOption3.Cursor = Cursors.Hand;
            _btnOption3.Font = new Font("Verdana", 14.0F);
            _btnOption3.ImageAlign = ContentAlignment.TopCenter;
            _btnOption3.Location = new Point(33, 266);
            _btnOption3.Name = "btnOption3";
            _btnOption3.Size = new Size(404, 72);
            _btnOption3.TabIndex = 172;
            _btnOption3.Text = "Searching.....";
            _btnOption3.TextAlign = ContentAlignment.TopCenter;
            _btnOption3.UseVisualStyleBackColor = false;
            //
            // btnOption2
            //
            _btnOption2.BackColor = Color.PaleGreen;
            _btnOption2.Cursor = Cursors.Hand;
            _btnOption2.Font = new Font("Verdana", 14.0F);
            _btnOption2.ImageAlign = ContentAlignment.TopCenter;
            _btnOption2.Location = new Point(441, 188);
            _btnOption2.Name = "btnOption2";
            _btnOption2.Size = new Size(404, 72);
            _btnOption2.TabIndex = 171;
            _btnOption2.Text = "Searching.....";
            _btnOption2.TextAlign = ContentAlignment.TopCenter;
            _btnOption2.UseVisualStyleBackColor = false;
            //
            // btnOption1
            //
            _btnOption1.BackColor = Color.PaleGreen;
            _btnOption1.Cursor = Cursors.Hand;
            _btnOption1.Font = new Font("Verdana", 14.0F);
            _btnOption1.ImageAlign = ContentAlignment.TopCenter;
            _btnOption1.Location = new Point(31, 188);
            _btnOption1.Name = "btnOption1";
            _btnOption1.Size = new Size(406, 72);
            _btnOption1.TabIndex = 170;
            _btnOption1.Text = "Searching.....";
            _btnOption1.TextAlign = ContentAlignment.TopCenter;
            _btnOption1.UseVisualStyleBackColor = false;
            //
            // chkKeepTogether
            //
            _chkKeepTogether.AutoSize = true;
            _chkKeepTogether.Checked = true;
            _chkKeepTogether.CheckState = CheckState.Checked;
            _chkKeepTogether.Font = new Font("Verdana", 12.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkKeepTogether.ForeColor = Color.Black;
            _chkKeepTogether.Location = new Point(356, 17);
            _chkKeepTogether.Name = "chkKeepTogether";
            _chkKeepTogether.Size = new Size(196, 22);
            _chkKeepTogether.TabIndex = 169;
            _chkKeepTogether.Text = "Keep Visits Together";
            _chkKeepTogether.UseVisualStyleBackColor = true;
            //
            // tcComplete
            //
            _tcComplete.Controls.Add(_btnDocument);
            _tcComplete.Controls.Add(_lblBookedInfo);
            _tcComplete.Controls.Add(_Label27);
            _tcComplete.Controls.Add(_btnRestart);
            _tcComplete.Location = new Point(4, 22);
            _tcComplete.Name = "tcComplete";
            _tcComplete.Size = new Size(877, 774);
            _tcComplete.TabIndex = 12;
            _tcComplete.Text = "Complete";
            _tcComplete.UseVisualStyleBackColor = true;
            //
            // btnDocument
            //
            _btnDocument.Location = new Point(84, 311);
            _btnDocument.Name = "btnDocument";
            _btnDocument.Size = new Size(708, 23);
            _btnDocument.TabIndex = 180;
            _btnDocument.Text = "Add Documentation";
            _btnDocument.UseVisualStyleBackColor = true;
            //
            // lblBookedInfo
            //
            _lblBookedInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _lblBookedInfo.Font = new Font("Verdana", 10.0F, FontStyle.Bold);
            _lblBookedInfo.Location = new Point(8, 236);
            _lblBookedInfo.Name = "lblBookedInfo";
            _lblBookedInfo.Size = new Size(856, 32);
            _lblBookedInfo.TabIndex = 179;
            _lblBookedInfo.Text = "Booked with";
            _lblBookedInfo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // Label27
            //
            _Label27.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _Label27.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label27.Location = new Point(3, 185);
            _Label27.Name = "Label27";
            _Label27.Size = new Size(871, 34);
            _Label27.TabIndex = 178;
            _Label27.Text = "Bookings Complete";
            _Label27.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnRestart
            //
            _btnRestart.BackColor = Color.PaleGreen;
            _btnRestart.Cursor = Cursors.Hand;
            _btnRestart.Font = new Font("Verdana", 18.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnRestart.Location = new Point(84, 334);
            _btnRestart.Name = "btnRestart";
            _btnRestart.Size = new Size(708, 72);
            _btnRestart.TabIndex = 171;
            _btnRestart.Text = "Restart";
            _btnRestart.UseVisualStyleBackColor = false;
            //
            // ToolTip1
            //
            _ToolTip1.AutomaticDelay = 100;
            _ToolTip1.AutoPopDelay = 5000;
            _ToolTip1.InitialDelay = 20;
            _ToolTip1.IsBalloon = true;
            _ToolTip1.ReshowDelay = 10;
            //
            // UCJobWizard
            //
            Controls.Add(_tcSites);
            Name = "UCJobWizard";
            Size = new Size(885, 800);
            _tabJobDetails.ResumeLayout(false);
            _tabJobDetails.PerformLayout();
            _pnlTimeReq.ResumeLayout(false);
            _pnlTimeReq.PerformLayout();
            _pnlTypeOfWorks.ResumeLayout(false);
            _pnlTypeOfWorks.PerformLayout();
            _pnlSymptoms.ResumeLayout(false);
            _pnlSymptoms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_DGSymptoms).EndInit();
            _tabAppliance.ResumeLayout(false);
            _tabAppliance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_DgMain).EndInit();
            _tabJobType.ResumeLayout(false);
            _tabJobType.PerformLayout();
            _pnlSOR.ResumeLayout(false);
            _pnlSOR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_DGSOR).EndInit();
            _tabProp.ResumeLayout(false);
            _tabProp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_DGVSites).EndInit();
            _tcSites.ResumeLayout(false);
            _tabExistingJobs.ResumeLayout(false);
            _tabExistingJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgExistingVisits).EndInit();
            _tabAdditional.ResumeLayout(false);
            _tabAdditional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_DGAdditional).EndInit();
            _TabCharging.ResumeLayout(false);
            _TabCharging.PerformLayout();
            _pnlCharge.ResumeLayout(false);
            _pnlCharge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_picTick).EndInit();
            ((System.ComponentModel.ISupportInitialize)_picCross).EndInit();
            _TabBook.ResumeLayout(false);
            _TabBook.PerformLayout();
            _gpCombo.ResumeLayout(false);
            _tcComplete.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            tcSites.TabPages.Clear();
            tcSites.TabPages.Add(tabProp);
        }

        public object LoadedItem
        {
            get
            {
                return default;
                // Return CurrentSite
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool StopSelect = false;
        private List<string> SkillsList = new List<string>();
        private string PromotionText = "";
        private double FinalCharge = 0;
        private string FinalText = "";
        private DataTable PromotionsDT;
        private bool ProgChange;
        private bool TimeReqOption = false;
        private string BookingDetail = "";
        private double visitcharge1;
        private string visitterm1;
        private double visitcharge2;
        private string visitterm2;
        private int jobids;
        private int servTime = 0;
        private int visitsBooked = 0;
        private DateTime lastDate = DateTime.MinValue;
        private int lastEngineerID = 0;
        private int reqtime;
        private bool Manualrecall = false;
        private string jobtype = "";
        private int RecallJobTypeID;
        private int RecallJobID;
        private UCDocumentsList DocumentsControl;
        private UCQuotesList QuotesControl;
        private UCCustomerScheduleOfRate CustomerScheduleOfRateControl;
        private Entity.ContractsOriginal.ContractOriginal CurrentContract = null;
        private DataTable appointments = new DataTable();
        private DataTable Temp = new DataTable();
        private DataTable Schedulerapps = new DataTable();
        private string SpecialTrade = "";
        private bool LPGNEEDED = false;
        private bool OILNEEDED = false;
        private bool NATNEEDED = false;
        private bool HETASNEEDED = false;
        private bool ASNEEDED = false;
        private bool WAUNEEDED = false;
        private bool COMMNEEDED = false;
        private DateTime currentFilterDate;
        private int LastsiteID;
        private bool GasConfirmedInBoiler = true;
        private bool SiteChange = false;
        private DataTable DTPrivNotes;
        private Entity.Jobs.Job CurrentJob;
        private Entity.EngineerVisits.EngineerVisit currentVisit;
        private List<string> rftBundle = new List<string>();
        private string costCentre = null;

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Form _FromForm;

        public Form FromForm
        {
            get
            {
                return _FromForm;
            }

            set
            {
                _FromForm = value;
            }
        }

        private DataView _MainDataView = null;

        public DataView MainDataView
        {
            get
            {
                return _MainDataView;
            }

            set
            {
                _MainDataView = value;
                _MainDataView.Table.TableName = "MainApps";
                _MainDataView.AllowNew = false;
                _MainDataView.AllowEdit = true;
                _MainDataView.AllowDelete = false;
                DgMain.DataSource = MainDataView;
            }
        }

        private DataView _DGVAdditional = null;

        public DataView DGVAdditional
        {
            get
            {
                return _DGVAdditional;
            }

            set
            {
                _DGVAdditional = value;
                _DGVAdditional.Table.TableName = "Additional";
                _DGVAdditional.AllowNew = false;
                _DGVAdditional.AllowEdit = true;
                _DGVAdditional.AllowDelete = false;
                DGAdditional.DataSource = _DGVAdditional;
            }
        }

        private DataView _SORDataView = null;

        public DataView SORDataView
        {
            get
            {
                return _SORDataView;
            }

            set
            {
                _SORDataView = value;
                _SORDataView.Table.TableName = "SOR";
                _SORDataView.AllowNew = false;
                _SORDataView.AllowEdit = true;
                _SORDataView.AllowDelete = false;
                DGSOR.DataSource = SORDataView;
            }
        }

        private DataView _SORSymp = null;
        private List<int> CoverApps = new List<int>();
        private List<int> ChargeApps = new List<int>();

        public DataView SympDataView
        {
            get
            {
                return _SORSymp;
            }

            set
            {
                _SORSymp = value;
                _SORSymp.Table.TableName = "Symptoms";
                _SORSymp.AllowNew = false;
                _SORSymp.AllowEdit = true;
                _SORSymp.AllowDelete = false;
                DGSymptoms.DataSource = SympDataView;
            }
        }

        private DataGridViewRow SelectedMainDataRow
        {
            get
            {
                if (DgMain.CurrentRow is object && !(DgMain.CurrentRow.Index == -1))
                {
                    return DgMain.CurrentRow;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _SiteDT;

        public DataView SiteDT
        {
            get
            {
                return _SiteDT;
            }

            set
            {
                _SiteDT = value;
            }
        }

        private int _SiteID;

        public int SiteID
        {
            get
            {
                return _SiteID;
            }

            set
            {
                _SiteID = value;
            }
        }

        private DataGridViewRow SelecteddgvSitesDataRow
        {
            get
            {
                if (DGVSites.CurrentRow is object && !(DGVSites.CurrentRow.Index == -1))
                {
                    return DGVSites.CurrentRow;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Customers.Customer _theCustomer;

        private Entity.Customers.Customer theCustomer
        {
            get
            {
                return _theCustomer;
            }

            set
            {
                _theCustomer = value;
            }
        }

        private int _SelectedCustomerID = 0;

        private int SelectedCustomerID
        {
            get
            {
                return _SelectedCustomerID;
            }

            set
            {
                _SelectedCustomerID = value;
            }
        }

        private int time = 0;
        private int priTime = 0;
        private int secTime = 0;
        private bool FlagShown = false;
        private Entity.Sites.Site CurrentSite;
        private Entity.Customers.Customer CurrentCustomer;
        private bool UseContractVisit = false;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupSiteDataGridView()
        {
            Helper.SetUpDataGridView(DGVSites);
            DGVSites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVSites.AutoGenerateColumns = false;
            DGVSites.Columns.Clear();
            DGVSites.EditMode = DataGridViewEditMode.EditOnEnter;
            var Terms = new DataGridViewTextBoxColumn();
            Terms.HeaderText = "Terms";
            Terms.FillWeight = 25;
            Terms.DataPropertyName = "Terms";
            Terms.Name = "Terms";
            Terms.ReadOnly = true;
            Terms.Visible = false;
            Terms.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGVSites.Columns.Add(Terms);
            var ContractID = new DataGridViewTextBoxColumn();
            ContractID.HeaderText = "ContractID";
            ContractID.FillWeight = 25;
            ContractID.DataPropertyName = "ContractID";
            ContractID.Name = "ContractID";
            ContractID.ReadOnly = true;
            ContractID.Visible = false;
            ContractID.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGVSites.Columns.Add(ContractID);
            var SiteID = new DataGridViewTextBoxColumn();
            SiteID.HeaderText = "SiteID";
            SiteID.FillWeight = 25;
            SiteID.DataPropertyName = "siteid";
            SiteID.Name = "siteid";
            SiteID.ReadOnly = true;
            SiteID.Visible = false;
            SiteID.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGVSites.Columns.Add(SiteID);
            var Customer = new DataGridViewTextBoxColumn();
            Customer.HeaderText = "Customer";
            Customer.FillWeight = 25;
            Customer.DataPropertyName = "Customer";
            Customer.Name = "Customer";
            Customer.ReadOnly = true;
            Customer.Visible = true;
            Customer.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(Customer);
            var PartNumber = new DataGridViewTextBoxColumn();
            PartNumber.HeaderText = "Site Name";
            PartNumber.DataPropertyName = "SiteName";
            PartNumber.FillWeight = 20;
            PartNumber.ReadOnly = true;
            PartNumber.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(PartNumber);
            var Address1 = new DataGridViewTextBoxColumn();
            Address1.FillWeight = 35;
            Address1.HeaderText = "Address 1";
            Address1.DataPropertyName = "Address1";
            Address1.Name = "Address1";
            Address1.ReadOnly = true;
            Address1.Visible = true;
            Address1.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(Address1);
            var Address2 = new DataGridViewTextBoxColumn();
            Address2.FillWeight = 30;
            Address2.HeaderText = "Address 2";
            Address2.DataPropertyName = "Address2";
            Address2.Name = "Address2";
            Address2.ReadOnly = true;
            Address2.Visible = true;
            Address2.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(Address2);
            var Address3 = new DataGridViewTextBoxColumn();
            Address3.FillWeight = 30;
            Address3.HeaderText = "Address 3";
            Address3.DataPropertyName = "Address3";
            Address3.Name = "Address3";
            Address3.ReadOnly = true;
            Address3.Visible = false;
            Address3.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(Address3);
            var Postcode = new DataGridViewTextBoxColumn();
            Postcode.HeaderText = "Postcode";
            Postcode.DataPropertyName = "Postcode";
            Postcode.Name = "Postcode";
            Postcode.FillWeight = 25;
            Postcode.ReadOnly = true;
            Postcode.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(Postcode);
            var Tel = new DataGridViewTextBoxColumn();
            Tel.HeaderText = "Tel No.";
            Tel.DataPropertyName = "TelephoneNum";
            Tel.Name = "TelephoneNum";
            Tel.FillWeight = 20;
            Tel.ReadOnly = true;
            Tel.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(Tel);
            var Mob = new DataGridViewTextBoxColumn();
            Mob.HeaderText = "Mobile No.";
            Mob.DataPropertyName = "faxnum";
            Mob.Name = "faxnum";
            Mob.FillWeight = 20;
            Mob.ReadOnly = true;
            Mob.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(Mob);
            var EmailAddress = new DataGridViewTextBoxColumn();
            EmailAddress.HeaderText = "Email Address";
            EmailAddress.DataPropertyName = "EmailAddress";
            EmailAddress.Name = "EmailAddress";
            EmailAddress.FillWeight = 16;
            EmailAddress.ReadOnly = true;
            EmailAddress.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(EmailAddress);
            var ContractRef = new DataGridViewTextBoxColumn();
            ContractRef.HeaderText = "Contract Ref";
            ContractRef.DataPropertyName = "ContractRef";
            ContractRef.Name = "ContractRef";
            ContractRef.FillWeight = 20;
            ContractRef.ReadOnly = true;
            ContractRef.SortMode = DataGridViewColumnSortMode.Automatic;
            DGVSites.Columns.Add(ContractRef);
            var Title = new DataGridViewTextBoxColumn();
            Title.FillWeight = 40;
            Title.HeaderText = "Title";
            Title.DataPropertyName = "Title";
            Title.Name = "Title";
            Title.ReadOnly = true;
            Title.Visible = false;
            Title.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGVSites.Columns.Add(Title);
            var FirstName = new DataGridViewTextBoxColumn();
            FirstName.FillWeight = 40;
            FirstName.HeaderText = "Address 3";
            FirstName.DataPropertyName = "FirstName";
            FirstName.Name = "FirstName";
            FirstName.ReadOnly = true;
            FirstName.Visible = false;
            FirstName.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGVSites.Columns.Add(FirstName);
            var Surname = new DataGridViewTextBoxColumn();
            Surname.FillWeight = 40;
            Surname.HeaderText = "Address 3";
            Surname.DataPropertyName = "Surname";
            Surname.Name = "Surname";
            Surname.ReadOnly = true;
            Surname.Visible = false;
            Surname.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGVSites.Columns.Add(Surname);
            var Notes = new DataGridViewTextBoxColumn();
            Notes.FillWeight = 40;
            Notes.HeaderText = "Notes";
            Notes.DataPropertyName = "Notes";
            Notes.Name = "Notes";
            Notes.ReadOnly = true;
            Notes.Visible = false;
            Notes.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGVSites.Columns.Add(Notes);
            var Name = new DataGridViewTextBoxColumn();
            Name.FillWeight = 40;
            Name.HeaderText = "Address 3";
            Name.DataPropertyName = "Name";
            Name.Name = "Name";
            Name.ReadOnly = true;
            Name.Visible = false;
            Name.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGVSites.Columns.Add(Name);

            // DGVSites.Sort(Customer, System.ComponentModel.ListSortDirection.Descending)
        }

        public void SetupAppsDG()
        {
            Helper.SetUpDataGridView(DgMain);
            DgMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgMain.AutoGenerateColumns = false;
            DgMain.Columns.Clear();
            DgMain.EditMode = DataGridViewEditMode.EditOnEnter;
            var SiteID = new DataGridViewTextBoxColumn();
            SiteID.FillWeight = 25;
            SiteID.DataPropertyName = "AssetID";
            SiteID.Name = "AssetID";
            SiteID.ReadOnly = true;
            SiteID.Visible = false;
            SiteID.SortMode = DataGridViewColumnSortMode.Programmatic;
            DgMain.Columns.Add(SiteID);
            var Customer = new DataGridViewTextBoxColumn();
            Customer.FillWeight = 25;
            Customer.DataPropertyName = "Product";
            Customer.Name = "Product";
            Customer.ReadOnly = true;
            Customer.Visible = true;
            Customer.SortMode = DataGridViewColumnSortMode.Programmatic;
            DgMain.Columns.Add(Customer);

            // DGVSites.Sort(Customer, System.ComponentModel.ListSortDirection.Descending)
        }

        public void SetupSOR()
        {
            Helper.SetUpDataGridView(DGSOR);
            DGSOR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGSOR.AutoGenerateColumns = false;
            DGSOR.Columns.Clear();
            DGSOR.EditMode = DataGridViewEditMode.EditOnEnter;
            var SiteID = new DataGridViewTextBoxColumn();
            SiteID.FillWeight = 25;
            SiteID.DataPropertyName = "SORID";
            SiteID.Name = "SORID";
            SiteID.ReadOnly = true;
            SiteID.Visible = false;
            SiteID.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGSOR.Columns.Add(SiteID);
            var Code = new DataGridViewTextBoxColumn();
            Code.FillWeight = 25;
            Code.DataPropertyName = "Code";
            Code.Name = "Code";
            Code.ReadOnly = true;
            Code.Visible = true;
            Code.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGSOR.Columns.Add(Code);
            var Description = new DataGridViewTextBoxColumn();
            Description.FillWeight = 100;
            Description.DataPropertyName = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Visible = true;
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGSOR.Columns.Add(Description);
            var Qty = new DataGridViewTextBoxColumn();
            Qty.FillWeight = 15;
            Qty.DataPropertyName = "Qty";
            Qty.Name = "Qty";
            Qty.ReadOnly = true;
            Qty.Visible = true;
            Qty.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGSOR.Columns.Add(Qty);
            var Time = new DataGridViewTextBoxColumn();
            Time.FillWeight = 20;
            Time.DataPropertyName = "TimeInMins";
            Time.HeaderText = "Mins";
            Time.Name = "TimeInMins";
            Time.ReadOnly = true;
            Time.Visible = true;
            Time.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGSOR.Columns.Add(Time);
            var Price = new DataGridViewTextBoxColumn();
            Price.FillWeight = 25;
            Price.DataPropertyName = "Price";
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Visible = false;
            Price.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGSOR.Columns.Add(Price);

            // DGVSites.Sort(Customer, System.ComponentModel.ListSortDirection.Descending)
        }

        public void SetupDGSymptoms()
        {
            Helper.SetUpDataGridView(DGSymptoms);
            DGSymptoms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGSymptoms.AutoGenerateColumns = false;
            DGSymptoms.Columns.Clear();
            DGSymptoms.EditMode = DataGridViewEditMode.EditOnEnter;
            var ID = new DataGridViewTextBoxColumn();
            ID.FillWeight = 1;
            ID.DataPropertyName = "SypID";
            ID.Name = "SypID";
            ID.ReadOnly = true;
            ID.Visible = true;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGSymptoms.Columns.Add(ID);
            var Code = new DataGridViewTextBoxColumn();
            Code.FillWeight = 25;
            Code.DataPropertyName = "Code";
            Code.Name = "Code";
            Code.ReadOnly = true;
            Code.Visible = true;
            Code.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGSymptoms.Columns.Add(Code);
            var Description = new DataGridViewTextBoxColumn();
            Description.FillWeight = 100;
            Description.DataPropertyName = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Visible = true;
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGSymptoms.Columns.Add(Description);
        }

        public void SetupDGAdditional()
        {
            Helper.SetUpDataGridView(DGAdditional);
            DGAdditional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGAdditional.AutoGenerateColumns = false;
            DGAdditional.Columns.Clear();
            DGAdditional.EditMode = DataGridViewEditMode.EditOnEnter;
            var ID = new DataGridViewTextBoxColumn();
            ID.FillWeight = 25;
            ID.DataPropertyName = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGAdditional.Columns.Add(ID);
            var Product = new DataGridViewTextBoxColumn();
            Product.FillWeight = 25;
            Product.DataPropertyName = "Product";
            Product.Name = "Product";
            Product.ReadOnly = true;
            Product.Visible = false;
            Product.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGAdditional.Columns.Add(Product);
            var AssetID = new DataGridViewTextBoxColumn();
            AssetID.FillWeight = 25;
            AssetID.DataPropertyName = "AssetID";
            AssetID.Name = "AssetID";
            AssetID.ReadOnly = true;
            AssetID.Visible = false;
            AssetID.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGAdditional.Columns.Add(AssetID);
            var Description = new DataGridViewTextBoxColumn();
            Description.FillWeight = 100;
            Description.DataPropertyName = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Visible = true;
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            DGAdditional.Columns.Add(Description);
        }

        public void SetupExisitingJobs()
        {
            Helper.SetUpDataGridView(dgExistingVisits);
            dgExistingVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgExistingVisits.AutoGenerateColumns = false;
            dgExistingVisits.Columns.Clear();
            dgExistingVisits.EditMode = DataGridViewEditMode.EditOnEnter;
            var ID = new DataGridViewTextBoxColumn();
            ID.FillWeight = 25;
            ID.DataPropertyName = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgExistingVisits.Columns.Add(ID);
            var AssetID = new DataGridViewTextBoxColumn();
            AssetID.FillWeight = 26;
            AssetID.DataPropertyName = "CreatedDate";
            AssetID.Name = "Created Date";
            AssetID.ReadOnly = true;
            AssetID.Visible = true;
            AssetID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgExistingVisits.Columns.Add(AssetID);
            var JobNumber = new DataGridViewTextBoxColumn();
            JobNumber.FillWeight = 25;
            JobNumber.DataPropertyName = "JobNumber";
            JobNumber.Name = "Job Number";
            JobNumber.ReadOnly = true;
            JobNumber.Visible = true;
            JobNumber.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgExistingVisits.Columns.Add(JobNumber);
            var Product = new DataGridViewTextBoxColumn();
            Product.FillWeight = 25;
            Product.DataPropertyName = "JobType";
            Product.Name = "Job Type";
            Product.ReadOnly = true;
            Product.Visible = true;
            Product.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgExistingVisits.Columns.Add(Product);
            var Description = new DataGridViewTextBoxColumn();
            Description.FillWeight = 150;
            Description.DataPropertyName = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Visible = true;
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgExistingVisits.Columns.Add(Description);
        }

        private void dgvSitesContracrPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < DGVSites.RowCount - 1)
            {
                var dgvRow = DGVSites.Rows[e.RowIndex];

                // <== This is the header Name
                // If CInt(dgvRow.Cells("EmployeeStatus_Training_e26").Value) <> 2 Then

                // <== But this is the name assigned to it in the properties of the control
                if (!string.IsNullOrEmpty(dgvRow.Cells["ContractRef"].Value.ToString()))
                {
                    dgvRow.DefaultCellStyle.ForeColor = Color.Green;
                    dgvRow.DefaultCellStyle.SelectionForeColor = Color.Green;
                }
                else
                {
                    // dgvRow.DefaultCellStyle.BackColor = Color.LightPink
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public bool Save()
        {
            return true;
        }

        public void Populate(int ID = 0)
        {
        }

        private void txtSearch_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RunFilter();
            }
        }

        private void RunFilter()
        {
            if (txtSearch.Text.Length > 0)
            {
                SiteDT = App.DB.Sites.Search_JobWizard(Helper.MakeStringValid(txtSearch.Text), App.loggedInUser.UserID);
                StopSelect = true;
                DGVSites.DataSource = SiteDT;
                if (DGVSites.RowCount > 0)
                {
                    DGVSites.Rows[0].Selected = false;
                    StopSelect = false;
                }
                else
                {
                    ClearSiteDetails();
                }
            }
            else
            {
                ClearSiteDetails();
            }
        }

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMSite), true, null);
            Cursor = Cursors.WaitCursor;
            RunFilter();
            Cursor = Cursors.Default;
        }

        private void btnEditSite_Click(object sender, EventArgs e)
        {
            if (SelecteddgvSitesDataRow.Index >= 0)
            {
                int selectedRow = DGVSites.CurrentCell.RowIndex;
                int selectedCol = DGVSites.CurrentCell.ColumnIndex;
                int selectedSiteID = SiteID;
                App.ShowForm(typeof(FRMSite), true, new object[] { SiteID, My.MyProject.Forms.FRMJobWizard });
                Cursor = Cursors.WaitCursor;
                RunFilter();
                DGVSites.Rows[selectedRow].Cells[selectedCol].Selected = true;
                SiteID = selectedSiteID;
                populateSiteData();
                Cursor = Cursors.Default;
                PopulateSite();
            }
        }

        private void PopulateSite()
        {
            txtCustomer.Text = CurrentCustomer.Name;
            ProgChange = true;
            var argcombo = cboTitle;
            Combo.SetSelectedComboItem_By_Description(ref argcombo, CurrentSite.Salutation);
            txtFirstName.Text = CurrentSite.FirstName;
            txtSurname.Text = CurrentSite.Surname;
            txtAddress1.Text = CurrentSite.Address1;
            txtAddress2.Text = CurrentSite.Address2;
            txtAddress3.Text = CurrentSite.Address3;
            txtPostcode.Text = CurrentSite.Postcode;
            txtTel.Text = CurrentSite.TelephoneNum;
            txtMob.Text = CurrentSite.FaxNum;
            txtEmail.Text = CurrentSite.EmailAddress;
            txtContactAlert.Text = CurrentSite.ContactAlerts;
            txtDefect.Text = CurrentSite.Defects;
            chbCommercial.Checked = CurrentSite.CommercialDistrict;
            txtContractRef.Text = Helper.MakeStringValid(SelecteddgvSitesDataRow.Cells["ContractRef"].Value);
            ProgChange = false;
            SiteChange = false;
        }

        private void DGVSites_CellContentClick()
        {
            if (StopSelect == false && SelecteddgvSitesDataRow is object && SelecteddgvSitesDataRow.Index > -1)
            {
                SiteID = Helper.MakeIntegerValid(SelecteddgvSitesDataRow.Cells["SiteID"].Value);
                btnxxSiteNext.Visible = true;
                if (LastsiteID != SiteID)
                {
                    CurrentContract = null;
                    // ''''' HERE FOR ANY CLEARING '''''''

                    chkCert.Visible = false;
                    chkCert.Checked = false;
                    lblcert.Visible = false;
                    try
                    {
                        tcSites.TabPages[0].Enabled = true;
                        tab = 0;
                        tcSites.TabPages.Remove(tabExistingJobs);
                        tcSites.TabPages.Remove(tabJobType);
                        tcSites.TabPages.Remove(tabJobDetails);
                        tcSites.TabPages.Remove(tabAppliance);
                        tcSites.TabPages.Remove(TabCharging);
                        tcSites.TabPages.Remove(tabAdditional);
                        tcSites.TabPages.Remove(TabBook);
                        tcSites.TabPages.Remove(tcComplete);
                        tcSites.SelectedIndex = 0;
                    }
                    // tcSites.SelectedIndex = 1
                    catch (Exception ex)
                    {
                        tcSites.SelectedIndex = 0;
                    }

                    GasConfirmedInBoiler = true;
                    var dv = new DataView();
                    var dt1 = new DataTable();
                    dt1.TableName = "1";
                    dt1.Columns.Add("SypID");
                    dt1.Columns.Add("Code");
                    dt1.Columns.Add("Description");
                    dv.Table = dt1;
                    SympDataView = dv;
                    DGSymptoms.DataSource = dt1;
                    SiteChange = false;
                    foreach (Control c in tabJobType.Controls)   // neat way to toggle button colors
                    {
                        if (c is Button)
                        {
                            c.BackColor = SystemColors.Control;
                        }
                    }

                    btnxxNewJob.BackColor = SystemColors.Control;
                    txtPONumber.Text = "";
                    txtAdditional.Text = "";
                }

                LastsiteID = SiteID;
                DTPrivNotes = App.DB.Job.GetAllJobNotes(SiteID);
                populateSiteData();
                if (CurrentCustomer.CustomerTypeID != (int)Enums.CustomerType.Domestic)
                {
                    chkCert.Checked = true;
                }
                else
                {
                    chkCert.Checked = false;
                }

                PromotionsDT = App.DB.Customer.CustomerType_GetAll_Promotions(CurrentCustomer.CustomerTypeID).Table;
                ParentForm.Text = "Job: Adding new for " + CurrentSite.Salutation + " " + CurrentSite.Surname + " - " + CurrentSite.Address1 + " " + CurrentSite.Postcode + (CurrentSite.CommercialDistrict ? " *DISTRICT* " : "");
                var c1 = ParentForm.Controls.Find("btnPrivateNotes", true);
                Button b1 = (Button)c1[0];
                b1.Visible = false;
                PopulateSite();
                string ContractText = "";
                if (!Information.IsDBNull(SelecteddgvSitesDataRow.Cells["ContractID"].Value))
                {
                    CurrentContract = new Entity.ContractsOriginal.ContractOriginal();
                    CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(SelecteddgvSitesDataRow.Cells["ContractID"].Value));
                    ContractText += txtContractRef.Text + " - " + App.DB.Picklists.Get_One_As_Object(CurrentContract.ContractTypeID).Name + Constants.vbNewLine + "(" + CurrentContract.ContractStartDate.ToString("dd/MM/yy") + "-" + CurrentContract.ContractEndDate.ToString("dd/MM/yy") + ")";
                    if (CurrentContract.PlumbingDrainage == true)
                    {
                        ContractText += Constants.vbNewLine + "Plumbing And Drainage Cover : YES";
                    }
                    else
                    {
                        ContractText += Constants.vbNewLine + "Plumbing And Drainage Cover : NO";
                    }

                    if (CurrentContract.GasSupplyPipework == true)
                    {
                        ContractText += Constants.vbNewLine + "Gas Pipework Cover : YES";
                    }
                    else
                    {
                        ContractText += Constants.vbNewLine + "Gas Pipework Cover : NO";
                    }

                    if (CurrentContract.WindowLockPest == true)
                    {
                        ContractText += Constants.vbNewLine + "Window Lock And Pest Cover : YES";
                    }
                    else
                    {
                        ContractText += Constants.vbNewLine + "Window Lock And Pest Cover : NO";
                    }
                }

                ToolTip1.SetToolTip(txtContractRef, ContractText);
            }
            else
            {
                btnxxSiteNext.Visible = false;

                // ClearSiteDetails()
            }
        }

        private void populateSiteData()
        {
            CurrentSite = App.DB.Sites.Get(SiteID);
            CurrentCustomer = App.DB.Customer.Customer_Get(CurrentSite.CustomerID);
        }

        private void btnJobHistory_Click(object sender, EventArgs e)
        {
            if (SelecteddgvSitesDataRow.Index >= 0)
            {
                App.ShowForm(typeof(FRMSiteVisitManager), true, new object[] { Helper.MakeIntegerValid(SiteID), My.MyProject.Forms.FRMJobWizard });
            }
        }

        private void dgExistingVisits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgExistingVisits.SelectedRows.Count > 0)
            {
                btnxxExistingJobNext.Enabled = true;
                btnxxExistingJobNext.Visible = true;
                btnxxNewJob.BackColor = SystemColors.Control;
                CurrentJob = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Conversions.ToInteger(dgExistingVisits.SelectedRows[0].Cells[0].Value));
                currentVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(dgExistingVisits.SelectedRows[0].Cells[0].Value));
                if (CurrentJob is object)
                {
                    var assetdt = App.DB.Asset.Asset_GetForSite(SiteID).Table;
                    var alist = CurrentJob.Assets;
                    MainDataView = App.DB.ContractOriginal.GetAssetsForContract(0, true);
                    foreach (Entity.JobAssets.JobAsset ar in alist)
                    {
                        try
                        {
                            var datarow = assetdt.Select("AssetID = " + ar.AssetID)[0];
                            MainDataView.AllowNew = true;
                            var newrow = MainDataView.AddNew();
                            newrow["AssetID"] = ar.AssetID;
                            var asset = App.DB.Asset.Asset_Get(ar.AssetID);
                            newrow["Product"] = datarow["Product"];
                            newrow.EndEdit();
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    DgMain.DataSource = MainDataView;
                }
            }
            else
            {
                btnxxExistingJobNext.Enabled = false;
            }
        }

        private void btnxxNewJob_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.PaleGreen)
            {
                ((Button)sender).BackColor = SystemColors.Control;
                if (dgExistingVisits.SelectedRows.Count < 1)
                {
                    btnxxExistingJobNext.Visible = false;
                }
            }
            else
            {
                dgExistingVisits.ClearSelection();
                ((Button)sender).BackColor = Color.PaleGreen;
                btnxxExistingJobNext.Visible = true;
                CurrentJob = null;
                currentVisit = null;
            }
        }

        private void cbotypeWiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cbotypeWiz)) < 1)
            {
                btnxxJobNext.Visible = false;
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cbotypeWiz)) == (double)Enums.JobTypes.ServiceCertificate)
            {
                lblcert.Visible = true;
                chkCert.Visible = true;
                chkCert.Checked = true;
                btnxxJobNext.Visible = true;
                jobtype = Combo.get_GetSelectedItemDescription(cbotypeWiz).ToUpper();
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cbotypeWiz)) == (double)Enums.JobTypes.Service)
            {
                lblcert.Visible = true;
                chkCert.Visible = true;
                chkCert.Checked = false;
                btnxxJobNext.Visible = true;
                jobtype = Combo.get_GetSelectedItemDescription(cbotypeWiz).ToUpper();
            }
            else
            {
                lblcert.Visible = false;
                chkCert.Visible = false;
                btnxxJobNext.Visible = true;
                jobtype = Combo.get_GetSelectedItemDescription(cbotypeWiz).ToUpper();
                btnxxDetailsNext.Visible = true;
            }
        }

        private void btnSORAdd_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSOR)) > 0 && Information.IsNumeric(txtSORQty.Text) && txtSORQty.Text.Length > 0 && Conversions.ToDouble(txtSORQty.Text) > 0)
            {
                SORDataView.AllowNew = true;
                var newrow = SORDataView.AddNew();
                Entity.CustomerScheduleOfRates.CustomerScheduleOfRate sor;
                sor = App.DB.CustomerScheduleOfRate.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboSOR)));
                newrow["SORID"] = sor.CustomerScheduleOfRateID;
                newrow["Code"] = sor.Code;
                newrow["Description"] = sor.Description;
                newrow["Qty"] = txtSORQty.Text;
                newrow["TimeInMins"] = sor.TimeInMins;
                newrow["Price"] = sor.Price;
                newrow.EndEdit();
                DGSOR.DataSource = SORDataView;
                txtSORQty.Text = "1";
            }

            if (DGSOR.RowCount > 0)
            {
                // If CurrentSite.PoNumReqd And txtPONumber.Text.Length = 0 Then

                // Else

                // If cboPriority.Items.Count > 0 And Combo.GetSelectedItemValue(cboPriority) < 1 Then
                // Else
                btnxxJobNext.Visible = true;
            }
            // End If
            // End If
            else
            {
                btnxxJobNext.Visible = false;
            }
        }

        private void btnSORMinus_Click(object sender, EventArgs e)
        {
            if (DGSOR.CurrentRow is object)
            {
                SORDataView.AllowDelete = true;
                SORDataView.Table.Rows.RemoveAt(DGSOR.CurrentRow.Index);
            }

            if (DGSOR.RowCount > 0)
            {
                if (CurrentSite.PoNumReqd & txtPONumber.Text.Length == 0)
                {
                }
                else if (cboPriority.Items.Count > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPriority)) < 1)
                {
                }
                else
                {
                    btnxxJobNext.Visible = true;
                }
            }
            else
            {
                btnxxJobNext.Visible = false;
            }
        }

        private void btnAddMain_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboMainApps)) > 0)
            {
                MainDataView.AllowNew = true;
                var newrow = MainDataView.AddNew();
                newrow["AssetID"] = Combo.get_GetSelectedItemValue(cboMainApps);
                newrow["Product"] = Combo.get_GetSelectedItemDescription(cboMainApps);
                newrow.EndEdit();
                DgMain.DataSource = MainDataView;
            }

            if (DgMain.RowCount > 0)
            {
                btnxxApplianceNext.Visible = true;
            }
            else
            {
                btnxxApplianceNext.Visible = false;
            }
        }

        private void btnMinusMain_Click(object sender, EventArgs e)
        {
            if (DgMain.CurrentRow is object)
            {
                MainDataView.AllowDelete = true;
                MainDataView.Table.Rows.RemoveAt(SelectedMainDataRow.Index);
            }

            if (DgMain.RowCount > 0)
            {
                btnxxApplianceNext.Visible = true;
            }
            else
            {
                btnxxApplianceNext.Visible = false;
            }
        }

        private void cboPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateJobDetails();
        }

        private void txtPONumber_TextChanged(object sender, EventArgs e)
        {
            ValidateJobDetails();
        }

        private void btnSymAdd_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSymptom)) > 0)
            {
                SympDataView.AllowNew = true;
                var newrow = SympDataView.AddNew();
                newrow["SypID"] = Combo.get_GetSelectedItemValue(cboSymptom);
                newrow["Code"] = Combo.get_GetSelectedItemDescription(cboSymptom).Split(' ')[0];
                newrow["Description"] = Combo.get_GetSelectedItemDescription(cboSymptom).Substring(Combo.get_GetSelectedItemDescription(cboSymptom).IndexOf(" ") + 1);
                // Combo.GetSelectedItemDescription(cboSymptom).Split("^")(1)
                newrow.EndEdit();
                DGSymptoms.DataSource = SympDataView;
            }

            ValidateJobDetails();
        }

        private void ValidateJobDetails()
        {
            if ((DGSymptoms.RowCount > 0 | pnlSymptoms.Visible == false) & (cboPriority.Visible == false | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPriority)) > 0) | (jobtype ?? "") != "BREAKDOWN" & (jobtype ?? "") != "SERVICE" | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboTypeOfWorks)) > 0)
            {
                if (CurrentSite.PoNumReqd & txtPONumber.Text.Length > 0 | !CurrentSite.PoNumReqd)
                {
                    btnxxDetailsNext.Visible = true;
                }
                else
                {
                    btnxxDetailsNext.Visible = true;
                }

                foreach (DataGridViewRow dr in DGSymptoms.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr.Cells["Code"].Value, "OTHER", false)) && txtAdditional.Text.Length == 0)
                    {
                        btnxxDetailsNext.Visible = false;
                    }
                }
            }
            else
            {
                btnxxDetailsNext.Visible = false;
            }
        }

        private void btnSymMinus_Click(object sender, EventArgs e)
        {
            if (DGSymptoms.CurrentRow is object)
            {
                SympDataView.AllowDelete = true;
                SympDataView.Table.Rows.RemoveAt(DGSymptoms.CurrentRow.Index);
            }

            ValidateJobDetails();
        }

        private void cboTypeOfWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateJobDetails();
        }

        private void btnSiteNext_Click(object sender, EventArgs e)
        {
            var argc = cboPriority;
            Combo.SetUpCombo(ref argc, App.DB.Customer.Priorities_Get_For_CustomerID_Active(CurrentSite.CustomerID).Table, "ManagerID", "Name", Enums.ComboValues.Not_Applicable);
            var argc1 = cboSymptom;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Symptoms).Table, "ManagerID", "Combo", Enums.ComboValues.Please_Select);
            var dv = new DataView();
            var dt1 = new DataTable();
            dt1.TableName = "1";
            dt1.Columns.Add("SORID");
            dt1.Columns.Add("Code");
            dt1.Columns.Add("Description");
            dt1.Columns.Add("Qty");
            dt1.Columns.Add("TimeInMins");
            dt1.Columns.Add("Price");
            dv.Table = dt1;
            SORDataView = dv;
            DGSOR.DataSource = dt1;
            if (tcSites.TabCount == 1)
            {
                tcSites.TabPages.Insert(1, tabExistingJobs);
            }

            tab = 1;
            tcSites.SelectedIndex = 1;
            Application.DoEvents();
            tcSites.SelectedTab = tcSites.TabPages[tab];
            Application.DoEvents();
            dgExistingVisits.DataSource = App.DB.EngineerVisits.EngineerVisits_Get_AllReady_ForSite(CurrentSite.SiteID);
            dgExistingVisits.ClearSelection();
            btnxxExistingJobNext.BackColor = SystemColors.Control;
        }

        private void btnxxExistingJobNext_Click(object sender, EventArgs e)
        {
            if (App.IsRFT)  // TODO drive a favorite for customer id in db  ' ATM im using button name and tag to hold text type and jobtypeID
            {
                btnxxBreakdown.Visible = false;
                BtnxxService.Visible = false;
                btnxxKitchens.Visible = false;
                btnxxMultiTrade.Visible = true;
                btnxxPlumbing.Visible = true;
                btnxxElectrical.Visible = true;
                btnxxExternalBM.Visible = false;
                btnxxCarpentry.Visible = true;
            }
            else
            {
                btnxxBreakdown.Visible = true;
                BtnxxService.Visible = true;
                btnxxKitchens.Visible = false;
                btnxxMultiTrade.Visible = false;
                btnxxPlumbing.Visible = false;
                btnxxElectrical.Visible = false;
                btnxxExternalBM.Visible = false;
                btnxxCarpentry.Visible = false;
            }

            if (btnxxNewJob.BackColor == Color.PaleGreen)
            {
                if (tcSites.TabCount == 2)
                {
                    tcSites.TabPages.Insert(2, tabJobType);
                }

                tab = 2;
                tcSites.SelectedIndex = 2;
                lblUnabletoConfirm.Visible = false;
                CurrentJob = null;
                var c1 = ParentForm.Controls.Find("btnPrivateNotes", true);
                Button b1 = (Button)c1[0];
                b1.Visible = true;
            }
            else if (dgExistingVisits.SelectedRows.Count > 0)
            {
                lblUnabletoConfirm.Visible = true;
                CurrentJob = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Conversions.ToInteger(dgExistingVisits.SelectedRows[0].Cells[0].Value));
                currentVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(dgExistingVisits.SelectedRows[0].Cells[0].Value));
                DGSymptoms.DataSource = App.DB.EngineerVisits.GetSymptoms(currentVisit.EngineerVisitID);
                var extpropdt = App.DB.EngineerVisits.GetExtendedProperties(currentVisit.EngineerVisitID);
                if (extpropdt.Rows.Count > 0)
                {
                    txtAdditional.Text = Conversions.ToString(extpropdt.Rows[0]["AdditionalNotes"]);
                }
                else if (currentVisit.NotesToEngineer.LastIndexOf("based Works -") > 0)
                {
                    txtAdditional.Text = currentVisit.NotesToEngineer.Substring(currentVisit.NotesToEngineer.LastIndexOf("based Works -") + 13).Trim(' ');
                }
                else if (currentVisit.NotesToEngineer.LastIndexOf("- See SOR List") > 0)
                {
                    txtAdditional.Text = currentVisit.NotesToEngineer.Substring(currentVisit.NotesToEngineer.LastIndexOf("- See SOR List") + 14).Trim(' ');
                }
                else
                {
                    txtAdditional.Text = currentVisit.NotesToEngineer;
                }

                // JOB TYPES '''''''''''''''''''''''''

                // JobTypes

                if (tcSites.TabCount == 2)
                {
                    tcSites.TabPages.Insert(2, tabJobType);
                }

                tab = 2;
                tcSites.SelectedIndex = 2;
                var switchExpr = CurrentJob.JobTypeID;
                switch (switchExpr)
                {
                    case (int)Enums.JobTypes.Service:
                        {
                            btnxx_Click(BtnxxService, new EventArgs());
                            break;
                        }

                    case (int)Enums.JobTypes.ServiceCertificate:
                        {
                            btnxx_Click(BtnxxService, new EventArgs());
                            chkCert.Checked = true;
                            break;
                        }

                    case (int)Enums.JobTypes.Breakdown:
                        {
                            btnxx_Click(btnxxBreakdown, new EventArgs());
                            break;
                        }

                    case (int)Enums.JobTypes.Dayworks:
                        {
                            btnxx_Click(btnxxSOR, new EventArgs());
                            pnlSOR.Visible = true;
                            var argc = cboSOR;
                            Combo.SetUpCombo(ref argc, App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(CurrentCustomer.CustomerID).Table, "CustomerScheduleOfRateID", "Description", Enums.ComboValues.Please_Select);
                            var al = App.DB.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(currentVisit.JobOfWorkID);
                            foreach (Entity.JobItems.JobItem a in al)
                            {
                                var Sor = App.DB.CustomerScheduleOfRate.Get(a.RateID);
                                if (Sor is object)
                                {
                                    SORDataView.AllowNew = true;
                                    var newrow = SORDataView.AddNew();
                                    newrow["SORID"] = a.RateID;
                                    newrow["Code"] = Sor.Code;
                                    newrow["Description"] = Sor.Description;
                                    newrow["Qty"] = a.Qty;
                                    newrow["TimeInMins"] = Sor.TimeInMins;
                                    newrow["Price"] = Sor.Price;
                                    newrow.EndEdit();
                                    DGSOR.DataSource = SORDataView;
                                }
                            }

                            if (DGSOR.RowCount > 0)
                            {
                                btnxxJobNext.Visible = true;
                                jobtype = "SOR";
                            }
                            else
                            {
                                btnxxJobNext.Visible = false;
                            }

                            break;
                        }

                    case (int)Enums.JobTypes.Installation:
                        {
                            btnxx_Click(btnxxOther, new EventArgs());
                            var argcombo = cbotypeWiz;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentJob.JobTypeID.ToString());
                            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cbotypeWiz)) < 1)
                            {
                                btnxxJobNext.Visible = false;
                            }
                            else
                            {
                                btnxxJobNext.Visible = true;
                            }

                            var al = App.DB.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(currentVisit.JobOfWorkID); // for each JobOfWorks get the sors applied - SORS are attaached to JOWS not Visits directly.
                            foreach (Entity.JobItems.JobItem a in al)
                            {
                                var Sor = App.DB.CustomerScheduleOfRate.Get(a.RateID);
                                if (Sor is object)
                                {
                                    SORDataView.AllowNew = true;
                                    var newrow = SORDataView.AddNew();
                                    newrow["SORID"] = a.RateID;
                                    newrow["Code"] = Sor.Code;
                                    newrow["Description"] = Sor.Description;
                                    newrow["Qty"] = a.Qty;
                                    newrow["TimeInMins"] = Sor.TimeInMins;
                                    newrow["Price"] = Sor.Price;
                                    newrow.EndEdit();
                                    DGSOR.DataSource = SORDataView;
                                }
                            }

                            break;
                        }

                    default:
                        {
                            btnxx_Click(btnxxOther, new EventArgs());
                            cbotypeWiz.Visible = true;
                            lbltype.Visible = true;
                            if (cboPriority.Items.Count > 1)
                            {
                                lblPriority.Visible = true;
                                cboPriority.Visible = true;
                            }
                            else
                            {
                                lblPriority.Visible = false;
                                cboPriority.Visible = false;
                            }

                            pnlSymptoms.Visible = true;
                            lblAdditional.Visible = true;
                            txtAdditional.Visible = true;
                            lblcert.Visible = false;
                            chkCert.Visible = false;
                            pnlSOR.Visible = false;
                            var argcombo1 = cbotypeWiz;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentJob.JobTypeID.ToString());
                            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cbotypeWiz)) < 1)
                            {
                                btnxxJobNext.Visible = false;
                            }
                            else
                            {
                                btnxxJobNext.Visible = true;
                            }

                            var al = App.DB.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(currentVisit.JobOfWorkID);
                            foreach (Entity.JobItems.JobItem a in al)
                            {
                                var Sor = App.DB.CustomerScheduleOfRate.Get(a.RateID);
                                if (Sor is object)
                                {
                                    SORDataView.AllowNew = true;
                                    var newrow = SORDataView.AddNew();
                                    newrow["SORID"] = a.RateID;
                                    newrow["Code"] = Sor.Code;
                                    newrow["Description"] = Sor.Description;
                                    newrow["Qty"] = a.Qty;
                                    newrow["TimeInMins"] = Sor.TimeInMins;
                                    newrow["Price"] = Sor.Price;
                                    newrow.EndEdit();
                                    DGSOR.DataSource = SORDataView;
                                }
                            }

                            break;
                        }
                }

                var c = ParentForm.Controls.Find("btnSaveProg", true);
                Button b = (Button)c[0];
                b.Visible = true;
                if (tcSites.TabCount == 3)
                {
                    btnJobNext_Click(btnxxJobNext, new EventArgs());
                }

                if (DgMain.RowCount > 0 & tcSites.TabCount == 4)
                {
                    btnxxApplianceNext_Click(btnxxApplianceNext, new EventArgs());
                    // tcSites.TabPages.Insert(4, tabJobDetails)
                    // tab = tcSites.SelectedIndex + 1
                    // tcSites.SelectedIndex = tcSites.SelectedIndex + 1
                }

                var dv = new DataView();
                var dt1 = new DataTable();
                dt1.TableName = "1";
                dt1.Columns.Add("SypID");
                dt1.Columns.Add("Code");
                dt1.Columns.Add("Description");
                dv.Table = dt1;
                SympDataView = dv;
                DGSymptoms.DataSource = dt1;
                if ((jobtype ?? "") == "SERVICE")
                {
                    btnxxDetailsNext.Visible = true;
                }

                var JOW = App.DB.JobOfWorks.JobOfWork_Get(currentVisit.JobOfWorkID);
                txtPONumber.Text = JOW.PONumber;
                var argcombo2 = cboPriority;
                Combo.SetSelectedComboItem_By_Value(ref argcombo2, JOW.Priority.ToString());
                var Sympdt = App.DB.EngineerVisits.GetSymptoms(currentVisit.EngineerVisitID);
                foreach (DataRow dr in Sympdt.Rows)
                {
                    SympDataView.AllowNew = true;
                    var newrow = SympDataView.AddNew();
                    newrow["SypID"] = dr["SymptomID"];
                    newrow["Code"] = dr["Code"];
                    newrow["Description"] = dr["Description"];
                    newrow.EndEdit();
                    DGSymptoms.DataSource = SympDataView;
                }

                ValidateJobDetails();
                var c1 = ParentForm.Controls.Find("btnPrivateNotes", true);
                Button b1 = (Button)c1[0];
                b1.Visible = true;
            }
        }

        private void btnJobNext_Click(object sender, EventArgs e)
        {
            var c = ParentForm.Controls.Find("btnSaveProg", true);
            Button b = (Button)c[0];
            b.Visible = true;
            pnlSymptoms.Visible = true;
            rftBundle.AddRange(new[] { "KITCHENS", "BATHROOMS", "PLUMBING", "ELECTRICAL", "OTHER INTERNAL B AND M", "OTHER EXTERNAL B AND M", "MULTI TRADE", "BATHROOM FITTING", "BRICKLAYER", "BB" });
            if (tcSites.TabCount == 3)
            {
                tcSites.TabPages.Insert(3, tabAppliance);
                var argc = cboMainApps;
                Combo.SetUpCombo(ref argc, App.DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
                if ((jobtype ?? "") != "SERVICE")
                {
                    cboMainApps.Items.Add(new Combo("Non Asset Related", 1.ToString()));
                }

                if (App.IsGasway)
                {
                    cboMainApps.Items.Add(new Combo("Boiler - Unknown", 2.ToString()));
                    cboMainApps.Items.Add(new Combo("Storage Boiler - Unknown", 3.ToString()));
                    cboMainApps.Items.Add(new Combo("Oil Boiler - Unknown", 4.ToString()));
                    cboMainApps.Items.Add(new Combo("Gas Fire - Unknown", 5.ToString()));
                    cboMainApps.Items.Add(new Combo("Unit Heater - Unknown", 6.ToString()));
                    cboMainApps.Items.Add(new Combo("Large Unit Heater - Unknown", 7.ToString()));
                    cboMainApps.Items.Add(new Combo("Water Heater - Unknown", 8.ToString()));
                    cboMainApps.Items.Add(new Combo("Unvented Cylinder - Unknown", 9.ToString()));
                    cboMainApps.Items.Add(new Combo("Cooker - Unknown", 10.ToString()));
                    cboMainApps.Items.Add(new Combo("Hob - Unknown", 11.ToString()));
                    cboMainApps.Items.Add(new Combo("Warm Air Unit - Unknown", 12.ToString()));
                    cboMainApps.Items.Add(new Combo("Air Source - Unknown", 13.ToString()));
                    cboMainApps.Items.Add(new Combo("Range Cooker - Unknown", 14.ToString()));
                    cboMainApps.Items.Add(new Combo("Solid Fuel - Unknown", 15.ToString()));
                }

                if (btnxxNewJob.BackColor == Color.PaleGreen)
                {
                    MainDataView = App.DB.ContractOriginal.GetAssetsForContract(0, true); // just to setup the grid
                }
            }

            if ((jobtype ?? "") == "BREAKDOWN")
            {
                TimeReqOption = false;
                pnlTimeReq.Visible = false;
                pnlTypeOfWorks.Visible = true;
                cboTypeOfWorks.Items.Clear();
                var argc1 = cboTypeOfWorks;
                Combo.SetUpCombo(ref argc1, DynamicDataTables.JobWizTypesOfWork, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            }
            else if ((jobtype ?? "") == "SERVICE")
            {
                TimeReqOption = false;
                pnlTimeReq.Visible = false;
                pnlTypeOfWorks.Visible = true;
                cboTypeOfWorks.Items.Clear();
                var argc2 = cboTypeOfWorks;
                Combo.SetUpCombo(ref argc2, DynamicDataTables.JobWizServTypesOfWork, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            }
            else if ((jobtype ?? "") == "INSTALLATION" | (jobtype ?? "") == "KITCHENS AND BATHROOMS" | App.IsRFT)
            {
                TimeReqOption = true;  // use the days and hours options
                pnlTimeReq.Visible = true;
                pnlTypeOfWorks.Visible = false;
                cboTypeOfWorks.Items.Clear();
            }
            else
            {
                TimeReqOption = false;
                pnlTimeReq.Visible = false;
                pnlTypeOfWorks.Visible = false;
                cboTypeOfWorks.Items.Clear();
            }

            tab = tcSites.SelectedIndex + 1;
            tcSites.SelectedIndex = tcSites.SelectedIndex + 1;
            if (DgMain.RowCount > 0)
            {
                btnxxApplianceNext.Visible = true;
            }
            else
            {
                btnxxApplianceNext.Visible = false;
            }
        }

        private void btnxxApplianceNext_Click(object sender, EventArgs e)
        {
            if (tcSites.TabCount == 4)
            {
                var dv = new DataView();
                var dt1 = new DataTable();
                dt1.TableName = "1";
                dt1.Columns.Add("SypID");
                dt1.Columns.Add("Code");
                dt1.Columns.Add("Description");
                dv.Table = dt1;
                SympDataView = dv;
                DGSymptoms.DataSource = dt1;
                tcSites.TabPages.Insert(4, tabJobDetails);
            }

            tab = tcSites.SelectedIndex + 1;
            tcSites.SelectedIndex = tcSites.SelectedIndex + 1;
            if (DGSymptoms.RowCount > 0 & (cboPriority.Visible == false | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPriority)) > 0) | (jobtype ?? "") != "BREAKDOWN" & (jobtype ?? "") != "SERVICE" | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboTypeOfWorks)) > 0)
            {
                if (CurrentSite.PoNumReqd & txtPONumber.Text.Length > 0 | !CurrentSite.PoNumReqd)
                {
                    btnxxDetailsNext.Visible = true;
                }
                else
                {
                    btnxxDetailsNext.Visible = true;
                }
            }
            else
            {
                btnxxDetailsNext.Visible = false;
            }

            if ((jobtype ?? "") == "SERVICE")
            {
                lblPriority.Visible = false;
                cboPriority.Visible = false;
                pnlSymptoms.Visible = false;
                btnxxDetailsNext.Visible = true;
            }
            else
            {
                // lblPriority.Visible = True
                // cboPriority.Visible = True
                // pnlSymptoms.Visible = True
                // btnxxDetailsNext.Visible = True
            }
        }

        private void btnxxDetailsNext_Click(object sender, EventArgs e)
        {
            if (CurrentSite.PoNumReqd && txtPONumber.Text.Length < 1)
            {
                Interaction.MsgBox("Please add a PO Reference", MsgBoxStyle.OkOnly, "Opps");
                return;
            }

            var Assetsdt = new DataTable();
            if (!(SelecteddgvSitesDataRow.Cells["ContractID"].Value == DBNull.Value))
            {
                var dt = App.DB.ContractOriginalSite.GetAll_ContractID2(Conversions.ToInteger(SelecteddgvSitesDataRow.Cells["ContractID"].Value), CurrentSite.CustomerID).Table;
                Assetsdt = App.DB.ContractOriginalPPMVisit.GetAllAssets_For_ContractSiteID(Conversions.ToInteger(dt.Rows[0]["ContractSiteID"])).Table;
            }

            lblCoverplanServ.Text = "";
            if (CurrentSite.LastServiceDate.AddMonths(10) < DateAndTime.Today) // is it 10 months or more old
            {
                lblCoverplanServ.Visible = true;
                lblCoverplanServ.Text = "This Sites service visit is due soon, please book." + Constants.vbNewLine;
                lblCoverplanServ.Visible = true;
            }
            else if (CurrentSite.LastServiceDate.AddMonths(12) < DateAndTime.Today & CurrentCustomer.CustomerTypeID == 516)
            {
                lblCoverplanServ.Text = "This Sites service visit is overdue and must be booked now." + Constants.vbNewLine;
            }
            else
            {
                lblCoverplanServ.Visible = false;
            }

            if (Assetsdt.Rows.Count > 0)
            {
                lblCoverplanServ.Visible = true;
                lblCoverplanServ.Text += "This Site Has A Coverplan Service Outstanding - Due Before " + CurrentSite.LastServiceDate.AddMonths(12);
            }
            else
            {
                lblCoverplanServ.Visible = false;
            }

            var dv = new DataView();
            var dt1 = new DataTable();
            dt1.TableName = "2";
            dt1.Columns.Add("ID");
            dt1.Columns.Add("AssetID");
            dt1.Columns.Add("Description");
            dt1.Columns.Add("Product");
            dt1.Columns.Add("Cert");
            dv.Table = dt1;
            DGVAdditional = dv;
            DGAdditional.DataSource = dt1;
            btnxxAdditionalNext.Visible = true;
            if (App.IsRFT)
            {
                if (tcSites.TabCount == 5)
                {
                    tcSites.TabPages.Insert(5, TabCharging);
                }

                tab = tcSites.SelectedIndex + 1;
                tcSites.SelectedIndex = tcSites.SelectedIndex + 1;
                DoCharging();
                AdditionalCharging();
                var argcombo = cboPayTerms;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, 2.ToString());
                btnxxChargeNext_Click(btnxxChargeNext, new EventArgs());
            }
            else
            {
                if (tcSites.TabCount == 5)
                {
                    tcSites.TabPages.Insert(5, tabAdditional);
                }

                tab = tcSites.SelectedIndex + 1;
                tcSites.SelectedIndex = tcSites.SelectedIndex + 1;
            }

            // DoCharging()
            // AdditionalCharging()
        }

        private void btnxxAdditionalNext_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPayTerms)) < 1)
            {
                btnxxChargeNext.Visible = false;
            }
            else
            {
                btnxxChargeNext.Visible = true;
            }

            if (tcSites.TabCount == 6)
            {
                tcSites.TabPages.Insert(6, TabCharging);
            }

            tab = tcSites.SelectedIndex + 1;
            tcSites.SelectedIndex = tcSites.SelectedIndex + 1;
            DoCharging();
            AdditionalCharging();
            FinalCharge = Conversions.ToDouble(txtCharge.Text);
            FinalText = txtPayInst.Text;
            txtCharge.Text = Strings.Format(Conversions.ToDouble(txtCharge.Text), "C");
            CheckDiscount();
        }

        private void btnxxChargeNext_Click(object sender, EventArgs e)
        {
            // If IsRFT Then
            // If tcSites.TabCount = 6 Then
            // tcSites.TabPages.Insert(6, TabBook)
            // End If
            // tab = tcSites.SelectedIndex + 1
            // tcSites.SelectedIndex = tcSites.SelectedIndex + 1
            // Else
            // If tcSites.TabCount = 7 Then
            // tcSites.TabPages.Insert(7, TabBook)
            // End If
            // tab = tcSites.SelectedIndex + 1
            // tcSites.SelectedIndex = tcSites.SelectedIndex + 1
            // End If

            // CreateVisits()

            // FindAppointments()
            SaveProgress();
        }

        private void btnAdditionalPlus_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAdditional)) > 0)
            {
                var ResultAsset = default(int);
                var ResultProduct = default(string);
                var ResultCert = default(bool);
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAdditional)) == 1)  // 1 = service also
                {
                    FRMSelectAsset dialogue;
                    dialogue = (FRMSelectAsset)App.checkIfExists(typeof(FRMSelectAsset).Name, true);
                    if (dialogue is null)
                    {
                        dialogue = (FRMSelectAsset)Activator.CreateInstance(typeof(FRMSelectAsset));
                    }
                    // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                    dialogue.ShowInTaskbar = false;
                    dialogue.SiteID = CurrentSite.SiteID;
                    dialogue.ShowDialog();
                    if (dialogue.DialogResult == DialogResult.OK)
                    {
                        // newRow.Item("AssetID") = dialogue.SelectedAssetDataRow.Item("AssetID")
                        ResultAsset = Conversions.ToInteger(dialogue.SelectedAssetDataRow["AssetID"]);
                        ResultProduct = Conversions.ToString(dialogue.SelectedAssetDataRow["Product"]);
                        ResultCert = dialogue.chkCERT2.Checked;
                    }

                    dialogue.Close();
                }

                chkCert.Visible = true;
                chkCert.Checked = true;
                lblcert.Visible = true;
                DGVAdditional.AllowNew = true;
                var newrow = DGVAdditional.AddNew();
                newrow["ID"] = Combo.get_GetSelectedItemValue(cboAdditional);
                newrow["description"] = Combo.get_GetSelectedItemDescription(cboAdditional) + " - " + ResultProduct.Split('-')[0];
                newrow["AssetID"] = ResultAsset;
                newrow["Product"] = ResultProduct;
                newrow["Cert"] = ResultCert;
                newrow.EndEdit();
                DGAdditional.DataSource = DGVAdditional;
            }
        }

        private void btnAdditionalMinus_Click(object sender, EventArgs e)
        {
            if (DGAdditional.CurrentRow is object)
            {
                DGVAdditional.AllowDelete = true;
                DGVAdditional.Table.Rows.RemoveAt(DGAdditional.CurrentRow.Index);
            }
        }

        private void chkRecall_CheckedChanged(object sender, EventArgs e)
        {
            Manualrecall = true;
        }

        public void DoCharging()
        {
            int defaultTerm = 0;
            visitcharge1 = 0;
            visitterm1 = "";
            var switchExpr = CurrentCustomer.Terms;
            switch (switchExpr)
            {
                case (int)Enums.Terms.POC:
                    {
                        defaultTerm = 3;
                        break;
                    }

                case (int)Enums.Terms.OTI30Days:
                case (int)Enums.Terms.OTI7Days:
                case (int)Enums.Terms.OTIByReturn:
                    {
                        defaultTerm = 2;
                        break;
                    }

                default:
                    {
                        defaultTerm = 3;
                        break;
                    }
            }

            SpecialTrade = "";
            time = 0;
            LPGNEEDED = false;
            OILNEEDED = false;
            NATNEEDED = false;
            HETASNEEDED = false;
            ASNEEDED = false;
            WAUNEEDED = false;
            COMMNEEDED = false;
            UseContractVisit = false;
            txtPayInst.Text = Constants.vbNewLine;
            txtCharge.Text = "£0.00";
            // 'customer type
            var c = App.DB.Customer.Customer_Get(CurrentSite.CustomerID);
            var switchExpr1 = jobtype;
            switch (switchExpr1)
            {
                case "BREAKDOWN":
                    {
                        txtPayInst.Text += "Breakdown job applied" + Constants.vbNewLine;
                        // ' check if recall likely
                        bool gassupplyissue = false;
                        string quoterate = App.DB.Picklists.Get_One_As_Object((int)Enums.JobItemPrice.BDOWN).Description;
                        var switchExpr2 = Combo.get_GetSelectedItemValue(cboTypeOfWorks);
                        switch (switchExpr2)
                        {
                            case var @case when @case == 2.ToString():
                                {
                                    SpecialTrade = "COMM";
                                    quoterate = App.DB.Picklists.Get_One_As_Object((int)Enums.JobItemPrice.COMM).Description;
                                    break;
                                }

                            case var case1 when case1 == 3.ToString():
                                {
                                    SpecialTrade = "PLUM";
                                    quoterate = App.DB.Picklists.Get_One_As_Object((int)Enums.JobItemPrice.PLUM).Description;
                                    break;
                                }

                            case var case2 when case2 == 4.ToString():
                                {
                                    SpecialTrade = "ELEC";
                                    quoterate = App.DB.Picklists.Get_One_As_Object((int)Enums.JobItemPrice.ELEC).Description;
                                    break;
                                }

                            case var case3 when case3 == 5.ToString():
                                {
                                    SpecialTrade = "BANDM";
                                    quoterate = App.DB.Picklists.Get_One_As_Object((int)Enums.JobItemPrice.BANDM).Description;
                                    break;
                                }

                            default:
                                {
                                    foreach (DataRowView dr in SympDataView)
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["SypID"], 69783, false)))
                                        {
                                            SpecialTrade = "PLUM";
                                            quoterate = App.DB.Picklists.Get_One_As_Object((int)Enums.JobItemPrice.PLUM).Description;
                                        }

                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["SypID"], 69784, false)))
                                        {
                                            SpecialTrade = "ELEC";
                                            quoterate = App.DB.Picklists.Get_One_As_Object((int)Enums.JobItemPrice.ELEC).Description;
                                        }

                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["SypID"], 69785, false)))
                                        {
                                            SpecialTrade = "BANDM";
                                            quoterate = App.DB.Picklists.Get_One_As_Object((int)Enums.JobItemPrice.BANDM).Description;
                                        }
                                    }

                                    break;
                                }
                        }

                        bool ss = false;
                        bool sys = false;
                        foreach (DataRowView dgv in SympDataView)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgv["SypID"], 69790, false) | Operators.ConditionalCompareObjectEqual(dgv["SypID"], 69791, false))) // gas
                            {
                                ss = true;
                            }

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dgv["SypID"], 69663, false) | Operators.ConditionalCompareObjectEqual(dgv["SypID"], 69664, false) | Operators.ConditionalCompareObjectEqual(dgv["SypID"], 69668, false)))
                            {
                                sys = true;
                            }
                        }

                        bool recall = false;
                        bool PosRecall = false;
                        if (!Manualrecall)
                        {
                            var dt = App.DB.EngineerVisits.GetLastVisit(CurrentSite.SiteID);
                            var PrevSymptoms = new DataTable();
                            if (dt.Rows.Count > 0)
                            {
                                PrevSymptoms = App.DB.EngineerVisits.GetSymptoms(Conversions.ToInteger(dt.Rows[0]["Engineervisitid"]));
                            }

                            // ' catch a pos recall

                            foreach (DataRowView dvr in SympDataView)
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dvr["Code"], "RECALL ", false)))
                                {
                                    PosRecall = true;
                                    break;
                                }
                            }

                            if (dt.Rows.Count > 0)
                            {
                                if (PrevSymptoms.Rows.Count == 0)
                                {
                                    if ((dt.Rows.Count > 0 && !Information.IsDBNull(dt.Rows[0]["StartdateTime"]) && Conversions.ToDate(dt.Rows[0]["StartdateTime"]).AddDays(28) < DateTime.Today) & PosRecall)
                                    {
                                        recall = true;
                                        RecallJobTypeID = Conversions.ToInteger(dt.Rows[0]["JobTypeID"]);
                                        RecallJobID = Conversions.ToInteger(dt.Rows[0]["JobID"]);
                                    }
                                }
                                else if ((!Information.IsDBNull(dt.Rows[0]["StartdateTime"]) && Conversions.ToDate(dt.Rows[0]["StartdateTime"]).AddDays(28) < DateTime.Today) & (jobtype ?? "") == "BREAKDOWN")
                                {
                                    foreach (DataRow dd in PrevSymptoms.Rows)
                                    {
                                        foreach (DataRowView dvr in SympDataView)
                                        {
                                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dvr["SypID"], dd["SymptomID"], false)))
                                            {
                                                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dvr["SypID"], 69668, false)))
                                                {
                                                    recall = true;
                                                    RecallJobTypeID = Conversions.ToInteger(dt.Rows[0]["JobTypeID"]);
                                                    RecallJobID = Conversions.ToInteger(dt.Rows[0]["JobID"]);
                                                    break;
                                                }
                                            }
                                        }

                                        if (recall)
                                            break;
                                    }

                                    if (recall == false)
                                    {
                                        txtPayInst.Text += "A visit has been carried out within 28 days but as the symptoms have changed, it is suggested this is an new fault" + Constants.vbNewLine;
                                    }
                                }
                            }

                            chkRecall.Checked = recall;
                        }
                        else
                        {
                            recall = chkRecall.Checked;
                        }

                        if (recall)
                        {
                            txtPayInst.Text += "This visit has been marked as a recall no charge will be applied" + Constants.vbNewLine;
                            var argcombo = cboPayTerms;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo, 4.ToString());
                            txtCharge.Text = "£0.00";
                        }
                        else
                        {
                            if (PosRecall == true)
                            {
                                txtPayInst.Text += "This visit has been marked as a recall no charge will be applied" + Constants.vbNewLine;
                            }

                            var switchExpr3 = c.CustomerTypeID;
                            switch (switchExpr3)
                            {
                                case (int)Enums.CustomerType.SocialHousing:
                                    {
                                        time = 45;
                                        // housing
                                        txtPayInst.Text += "Social Housing or Council works are not chargeable" + Constants.vbNewLine;
                                        var argcombo1 = cboPayTerms;
                                        Combo.SetSelectedComboItem_By_Value(ref argcombo1, 4.ToString());
                                        txtCharge.Text = "£0.00";
                                        break;
                                    }

                                case (int)Enums.CustomerType.Insurance:
                                    {
                                        time = 45;
                                        // Insurance
                                        txtPayInst.Text += "Insurance Works are OTI" + Constants.vbNewLine;
                                        var argcombo2 = cboPayTerms;
                                        Combo.SetSelectedComboItem_By_Value(ref argcombo2, 2.ToString());
                                        txtCharge.Text = "£0.00";
                                        break;
                                    }

                                default:
                                    {
                                        time = 45;
                                        object IsContract = false;
                                        if (!Information.IsDBNull(SelecteddgvSitesDataRow.Cells["ContractID"].Value))
                                        {
                                            CurrentContract = new Entity.ContractsOriginal.ContractOriginal();
                                            CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(SelecteddgvSitesDataRow.Cells["ContractID"].Value));
                                        }
                                        // others

                                        if (CurrentContract is object)
                                        {
                                            IsContract = true;
                                            var drt = default(DataRow);
                                            var dt = new DataTable();

                                            // Dim contractSite As Entity.QuoteContractOriginalSites.QuoteContractOriginalSite
                                            if (!Information.IsDBNull(SelecteddgvSitesDataRow.Cells["ContractID"].Value))
                                            {
                                                CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(SelecteddgvSitesDataRow.Cells["ContractID"].Value));
                                                dt = App.DB.ContractOriginalSite.GetAll_ContractID2(Conversions.ToInteger(SelecteddgvSitesDataRow.Cells["ContractID"].Value), CurrentSite.CustomerID).Table;
                                                drt = dt.Select("tick = 1")[0];
                                            }

                                            var argcombo3 = cboPayTerms;
                                            Combo.SetSelectedComboItem_By_Value(ref argcombo3, 1.ToString());
                                            txtPayInst.Text += "Works charges would normally be covered by Contract" + Constants.vbNewLine;
                                            txtCharge.Text = "£0.00";
                                            if (ss & !CurrentContract.GasSupplyPipework)
                                            {
                                                if (Interaction.MsgBox("Symptoms Indicate a gas leak has been suggested. Is this leak / smell located near / on the covered appliance", MsgBoxStyle.YesNo) == MsgBoxResult.No)
                                                {
                                                    txtPayInst.Text += "Gas leak works not covered by any contract extras" + Constants.vbNewLine;
                                                    gassupplyissue = true;
                                                    txtCharge.Text = "£" + quoterate;
                                                    GasConfirmedInBoiler = false;
                                                    var argcombo4 = cboPayTerms;
                                                    Combo.SetSelectedComboItem_By_Value(ref argcombo4, defaultTerm.ToString());
                                                }
                                            }

                                            if (sys & CurrentContract.ContractTypeID != 68032 & CurrentContract.ContractTypeID != 69767 & CurrentContract.ContractTypeID != 369)
                                            {
                                                txtPayInst.Text += "This Coverplan does not cover system issues" + Constants.vbNewLine;
                                                txtCharge.Text = "£" + quoterate;
                                                var argcombo5 = cboPayTerms;
                                                Combo.SetSelectedComboItem_By_Value(ref argcombo5, defaultTerm.ToString());
                                            }

                                            // here

                                            if (!string.IsNullOrEmpty(SpecialTrade) && (SpecialTrade ?? "") == "PLUM" & !CurrentContract.PlumbingDrainage | (SpecialTrade ?? "") == "ELEC" & !CurrentContract.PlumbingDrainage | (SpecialTrade ?? "") == "BANDM" & !CurrentContract.WindowLockPest)
                                            {
                                                var argcombo6 = cboPayTerms;
                                                Combo.SetSelectedComboItem_By_Value(ref argcombo6, defaultTerm.ToString());
                                                txtCharge.Text = "£" + quoterate;
                                                txtPayInst.Text += "Works not covered by any contract extras" + Constants.vbNewLine;
                                            }

                                            /// go through cover apps work out if anything to pay.
                                            var Assetsdt = new DataTable();
                                            Assetsdt = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(Conversions.ToInteger(drt["ContractSiteID"]), CurrentSite.SiteID).Table;
                                            int mainapps = 0;
                                            int Secondryapps = 0;
                                            if (dt.Rows.Count > 0) // dt is from above its contractoriginalsite table
                                            {
                                                mainapps = Conversions.ToInteger(dt.Rows[0]["MainAppliances"]);
                                                Secondryapps = Conversions.ToInteger(dt.Rows[0]["SecondryAppliances"]);
                                            }

                                            int pri = 0;
                                            int Sec = 0;
                                            if (Assetsdt.Rows.Count > 0 && !Information.IsDBNull(Assetsdt.Rows[0]["AssetID"]))
                                            {
                                                // we got accosiated apps
                                                foreach (DataRow dr in Assetsdt.Rows)
                                                {
                                                    foreach (DataGridViewRow dr1 in DgMain.Rows)
                                                    {
                                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr1.Cells["AssetID"].Value, dr["AssetID"], false)))
                                                        {
                                                            CoverApps.Add(Conversions.ToInteger(dr["AssetID"]));
                                                            if (CheckMainApps(dr1.Cells["Product"].Value.ToString().Split('-')[0]))
                                                            {
                                                                // main apps
                                                                pri = pri + 1;
                                                            }
                                                            else
                                                            {
                                                                Sec = Sec + 1;
                                                            }

                                                            if (pri + Sec >= DgMain.Rows.Count)
                                                                break;
                                                        }
                                                    }

                                                    if (pri + Sec >= DgMain.Rows.Count)
                                                        break;
                                                }
                                            }
                                            // may or may not have all the appliances listed by user

                                            if (pri + Sec < DgMain.Rows.Count) // user has hinted there may be another app under cover
                                            {
                                                if (pri < mainapps)
                                                {
                                                    // missing a main appliance which should be under cover
                                                    foreach (DataGridViewRow dr1 in DgMain.Rows)
                                                    {
                                                        if (CoverApps.Contains(Conversions.ToInteger(dr1.Cells["AssetID"].Value)))
                                                            continue;
                                                        if (CheckMainApps(dr1.Cells["Product"].Value.ToString().Split('-')[0]))
                                                        {
                                                            CoverApps.Add(Conversions.ToInteger(dr1.Cells["AssetID"].Value)); // main app added to list
                                                            pri = pri + 1;
                                                            if (pri >= mainapps)
                                                                break; // all main apps found
                                                        }
                                                    }
                                                }
                                            }

                                            if (pri + Sec < DgMain.Rows.Count) // still havent hit the total so .. check on secondrys
                                            {
                                                if (Sec < Secondryapps)
                                                {
                                                    // missing a secondry appliance which should be covered
                                                    foreach (DataGridViewRow dr1 in DgMain.Rows)
                                                    {
                                                        if (CoverApps.Contains(Conversions.ToInteger(dr1.Cells["AssetID"].Value)))
                                                            continue;
                                                        if (!CheckMainApps(dr1.Cells["Product"].Value.ToString().Split('-')[0]))
                                                        {
                                                            CoverApps.Add(Conversions.ToInteger(dr1.Cells["AssetID"].Value)); // sec app added to list
                                                            Sec = Sec + 1;
                                                            if (Sec >= Secondryapps)
                                                                break; // all sec apps found
                                                        }
                                                    }
                                                }
                                            }

                                            /// Anything left over will be chargeable?
                                            int excontcount = 0;
                                            foreach (DataGridViewRow dr2 in DgMain.Rows)
                                            {
                                                if (CoverApps.Contains(Conversions.ToInteger(dr2.Cells["AssetID"].Value)))
                                                    continue;

                                                // ''''TODO
                                                txtPayInst.Text += "Additional Appliances listed to that which are covered in plan or non appliance related , A callout Charge Has been Applied" + Constants.vbNewLine;
                                                var argcombo7 = cboPayTerms;
                                                Combo.SetSelectedComboItem_By_Value(ref argcombo7, defaultTerm.ToString());
                                                txtPayInst.Text += "Breakdown Charge Applied" + Constants.vbNewLine;
                                                txtCharge.Text = "£" + quoterate; // breakdown
                                            }

                                            foreach (DataGridViewRow dr1 in DgMain.Rows)
                                            {
                                                if (CoverApps.Contains(Conversions.ToInteger(dr1.Cells["AssetID"].Value)))
                                                    continue;
                                            }
                                        }
                                        else
                                        {
                                            var argcombo8 = cboPayTerms;
                                            Combo.SetSelectedComboItem_By_Value(ref argcombo8, defaultTerm.ToString());
                                            txtPayInst.Text += "Breakdown Charge Applied" + Constants.vbNewLine;
                                            txtCharge.Text = "£" + quoterate;
                                        } // breakdown

                                        bool userissue = false;
                                        foreach (DataRowView dr in SympDataView)
                                        {
                                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Code"], "USER ", false) | Operators.ConditionalCompareObjectEqual(dr["Code"], "NOISE ", false)))
                                            {
                                                userissue = true;
                                                if (CurrentContract is object)
                                                {
                                                    var argcombo9 = cboPayTerms;
                                                    Combo.SetSelectedComboItem_By_Value(ref argcombo9, defaultTerm.ToString());
                                                    txtPayInst.Text += "Symptoms selected indicate this visit should be chargeable.";
                                                    txtCharge.Text = "£" + quoterate; // breakdown current rate
                                                }

                                                break;
                                            }
                                        }

                                        break;
                                    }

                                    // If userissue and
                            }
                        }

                        break;
                    }

                case "SERVICE":
                    {
                        txtPayInst.Text += "Service job Applied" + Constants.vbNewLine;
                        var switchExpr4 = c.CustomerTypeID;
                        switch (switchExpr4)
                        {
                            case (int)Enums.CustomerType.SocialHousing:
                                {
                                    time = 45;
                                    // housing
                                    txtPayInst.Text += "Social Housing or Council Service works are not chargeable" + Constants.vbNewLine;
                                    var argcombo10 = cboPayTerms;
                                    Combo.SetSelectedComboItem_By_Value(ref argcombo10, 4.ToString());
                                    txtCharge.Text = "£0.00";
                                    break;
                                }

                            case (int)Enums.CustomerType.Insurance:
                                {
                                    time = 45;
                                    // Insurance
                                    txtPayInst.Text += "Insurance Works are OTI" + Constants.vbNewLine;
                                    var argcombo11 = cboPayTerms;
                                    Combo.SetSelectedComboItem_By_Value(ref argcombo11, 2.ToString());
                                    txtCharge.Text = "£0.00";
                                    break;
                                }

                            default:
                                {
                                    var dt = new DataTable();
                                    var drt = default(DataRow);
                                    object IsContract = false;
                                    Entity.QuoteContractOriginalSites.QuoteContractOriginalSite contractSite;
                                    if (!Information.IsDBNull(SelecteddgvSitesDataRow.Cells["ContractID"].Value))
                                    {
                                        CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(SelecteddgvSitesDataRow.Cells["ContractID"].Value));
                                        dt = App.DB.ContractOriginalSite.GetAll_ContractID2(Conversions.ToInteger(SelecteddgvSitesDataRow.Cells["ContractID"].Value), CurrentSite.CustomerID).Table;
                                        drt = dt.Select("tick = 1")[0];
                                    }
                                    // others
                                    CoverApps = new List<int>();
                                    ChargeApps = new List<int>();
                                    if (CurrentContract is object)
                                    {
                                        IsContract = true;
                                        var argcombo12 = cboPayTerms;
                                        Combo.SetSelectedComboItem_By_Value(ref argcombo12, 1.ToString());
                                        txtPayInst.Text += "Works charges would normally be covered by Contract" + Constants.vbNewLine;
                                        txtCharge.Text = "£0.00";

                                        /// go through cover apps work out if anything to pay.
                                        var Assetsdt = new DataTable();
                                        Assetsdt = App.DB.ContractOriginalPPMVisit.GetAllAssets_For_ContractSiteID(Conversions.ToInteger(drt["ContractSiteID"])).Table;
                                        int mainapps = 0;
                                        int Secondryapps = 0;
                                        if (dt.Rows.Count > 0) // dt is from above its contractoriginalsite table
                                        {
                                            mainapps = Conversions.ToInteger(dt.Rows[0]["MainAppliances"]);
                                            Secondryapps = Conversions.ToInteger(dt.Rows[0]["SecondryAppliances"]);
                                        }

                                        int pri = 0;
                                        int Sec = 0;
                                        if (Assetsdt.Rows.Count == 0)
                                        {
                                            var argcombo13 = cboPayTerms;
                                            Combo.SetSelectedComboItem_By_Value(ref argcombo13, defaultTerm.ToString());
                                            txtPayInst.Text += "Any Service Visits Have already been completed for this Contract Period" + Constants.vbNewLine;
                                            txtCharge.Text = "£0.00";
                                        }
                                        else
                                        {
                                            UseContractVisit = true;
                                            if (!Information.IsDBNull(Assetsdt.Rows[0]["AssetID"]))
                                            {
                                                // we got accosiated apps
                                                foreach (DataRow dr in Assetsdt.Rows)
                                                {
                                                    foreach (DataGridViewRow dr1 in DgMain.Rows)
                                                    {
                                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr1.Cells["AssetID"].Value, dr["AssetID"], false)))
                                                        {
                                                            CoverApps.Add(Conversions.ToInteger(dr["AssetID"]));
                                                            if (CheckMainApps(dr1.Cells["Product"].Value.ToString().Split('-')[0]))
                                                            {
                                                                // main apps
                                                                time += servTime;
                                                                pri = pri + 1;
                                                            }
                                                            else
                                                            {
                                                                time += servTime;
                                                                Sec = Sec + 1;
                                                            }

                                                            if (pri + Sec >= DgMain.Rows.Count)
                                                                break;
                                                        }
                                                    }

                                                    if (pri + Sec >= DgMain.Rows.Count)
                                                        break;
                                                }
                                            }
                                            // may or may not have all the appliances listed by user

                                            if (pri + Sec < DgMain.Rows.Count) // user has hinted there may be another app under cover
                                            {
                                                if (pri < mainapps)
                                                {
                                                    // missing a main appliance which should be under cover
                                                    foreach (DataGridViewRow dr1 in DgMain.Rows)
                                                    {
                                                        if (CoverApps.Contains(Conversions.ToInteger(dr1.Cells["AssetID"].Value)))
                                                            continue;
                                                        if (CheckMainApps(dr1.Cells["Product"].Value.ToString().Split('-')[0]))
                                                        {
                                                            time += servTime;
                                                            CoverApps.Add(Conversions.ToInteger(dr1.Cells["AssetID"].Value)); // main app added to list
                                                            pri = pri + 1;
                                                            if (pri >= mainapps)
                                                                break; // all main apps found
                                                        }
                                                    }
                                                }
                                            }

                                            if (pri + Sec < DgMain.Rows.Count) // still havent hit the total so .. check on secondrys
                                            {
                                                if (Sec < Secondryapps)
                                                {
                                                    // missing a secondry appliance which should be covered
                                                    foreach (DataGridViewRow dr1 in DgMain.Rows)
                                                    {
                                                        if (CoverApps.Contains(Conversions.ToInteger(dr1.Cells["AssetID"].Value)))
                                                            continue;
                                                        if (!CheckMainApps(dr1.Cells["Product"].Value.ToString().Split('-')[0]))
                                                        {
                                                            CoverApps.Add(Conversions.ToInteger(dr1.Cells["AssetID"].Value)); // sec app added to list
                                                            Sec = Sec + 1;
                                                            time += servTime;
                                                            if (Sec >= Secondryapps)
                                                                break; // all sec apps found
                                                        }
                                                    }
                                                }
                                            }

                                            /// Anything left over will be chargeable?
                                            int excontcount = 0;
                                            double HighService = 0;
                                            foreach (DataGridViewRow dr2 in DgMain.Rows)   // '' NEW Pricing bit ''''
                                            {
                                                if (CoverApps.Contains(Conversions.ToInteger(dr2.Cells["AssetID"].Value)))
                                                    continue;

                                                // bit for adding more time
                                                CheckMainApps(dr2.Cells["Product"].Value.ToString().Split('-')[0]);
                                                time += servTime;
                                                if (Conversions.ToDouble(Pricing(dr2.Cells["Product"].Value.ToString().Split('-')[0])) > HighService)
                                                {
                                                    HighService = Conversions.ToDouble(Pricing(dr2.Cells["Product"].Value.ToString().Split('-')[0]));
                                                }
                                            }

                                            foreach (DataGridViewRow dr1 in DgMain.Rows)
                                            {
                                                if (CoverApps.Contains(Conversions.ToInteger(dr1.Cells["AssetID"].Value)))
                                                    continue;
                                                // ' start charging
                                                ChargeApps.Add(Conversions.ToInteger(dr1.Cells["AssetID"].Value));
                                                excontcount += 1;
                                                var argcombo14 = cboPayTerms;
                                                Combo.SetSelectedComboItem_By_Value(ref argcombo14, defaultTerm.ToString());

                                                // ''''''''''''''''''''''''''''''''''''''''''''''''''NEW PRICING''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                                if (CoverApps.Count + excontcount > 1)
                                                {
                                                    txtCharge.Text = "£" + Conversions.ToDouble(Conversions.ToDouble(txtCharge.Text) + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("ADDAPP", (Enums.PickListTypes)71)));
                                                }
                                                else
                                                {
                                                    txtCharge.Text = "£" + Conversions.ToDouble(Conversions.ToDouble(txtCharge.Text) + Conversions.ToDouble(HighService));
                                                }

                                                txtPayInst.Text += dr1.Cells["Product"].Value.ToString().Split('-')[0] + " Service Not covered under contract." + Constants.vbNewLine;
                                            }

                                            // If excontcount > 2 Then txtCharge.Text = CDbl(txtCharge.Text) * 0.9
                                        }
                                    }
                                    else // non coverplan
                                    {
                                        int excontcount = 0;
                                        double HighService = 0;
                                        foreach (DataGridViewRow dr2 in DgMain.Rows)   // '' NEW Pricing bit ''''
                                        {
                                            if (Conversions.ToDouble(Pricing(dr2.Cells["Product"].Value.ToString().Split('-')[0])) > HighService)
                                            {
                                                HighService = Conversions.ToDouble(Pricing(dr2.Cells["Product"].Value.ToString().Split('-')[0]));
                                            }
                                        }

                                        foreach (DataGridViewRow dr1 in DgMain.Rows)
                                        {
                                            // '

                                            // ' start charging
                                            ChargeApps.Add(Conversions.ToInteger(dr1.Cells["AssetID"].Value));
                                            excontcount += 1;
                                            CheckMainApps(dr1.Cells["Product"].Value.ToString().Split('-')[0]);
                                            time += servTime;
                                            var argcombo15 = cboPayTerms;
                                            Combo.SetSelectedComboItem_By_Value(ref argcombo15, defaultTerm.ToString());

                                            // ''''''''''''''''''''''''''''''''''''''''''NEW PRICING''''''''''''''''''''''''''''''''''''
                                            if (excontcount > 1)
                                            {
                                                txtCharge.Text = "£" + Conversions.ToDouble(Conversions.ToDouble(txtCharge.Text) + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("ADDAPP", (Enums.PickListTypes)71)));
                                            }
                                            else
                                            {
                                                txtCharge.Text = "£" + Conversions.ToDouble(HighService);
                                            }
                                        }
                                    }

                                    break;
                                }
                        }

                        if (OILNEEDED)
                        {
                            Interaction.MsgBox("Please explain to the customer that the Oil boiler will need to be turned off the previous evening in order it cool for the service", MsgBoxStyle.OkOnly, "Advice");
                        }

                        break;
                    }

                case "SOR":
                    {
                        // SOR BASED Call
                        double cost = 0;
                        foreach (DataGridViewRow dr in DGSOR.Rows)
                        {
                            time += dr.Cells["TimeInMins"].Value;
                            cost += dr.Cells["Price"].Value;
                        }

                        var switchExpr5 = c.CustomerTypeID;
                        switch (switchExpr5)
                        {
                            case (int)Enums.CustomerType.SocialHousing:
                                {
                                    // Combo.SetSelectedComboItem_By_Value(cboPayTerms, 4)
                                    txtPayInst.Text += "SOR Works not chargeable upfront" + Constants.vbNewLine;
                                    break;
                                }

                            default:
                                {
                                    txtPayInst.Text += "SOR Works charges Applied" + Constants.vbNewLine;
                                    txtCharge.Text = "£" + Conversions.ToDouble(Conversions.ToDouble(txtCharge.Text) + Conversions.ToDouble(cost));
                                    break;
                                }
                        }

                        break;
                    }

                default:
                    {
                        if (TimeReqOption)
                        {
                            if (Information.IsNumeric(txtDays.Text) && Conversions.ToInteger(txtDays.Text) > 0)
                            {
                                time = 200;
                            }
                            else if (Information.IsNumeric(txtHrs.Text))
                            {
                                time = Conversions.ToInteger(Conversions.ToDouble(txtHrs.Text));
                            }
                        }

                        if (time == 0)
                            time = 60;
                        txtPayInst.Text += "Unknown costs, please manually complete" + Constants.vbNewLine;
                        break;
                    }
            }

            foreach (DataGridViewRow dr in DgMain.Rows)
                CheckMainApps(dr.Cells["Product"].Value.ToString().Split('-')[0]);  // just to check the engineer in a mo
            if (c.CustomerTypeID == (int)Enums.CustomerType.Agency)
            {
                var argcombo16 = cboPayTerms;
                Combo.SetSelectedComboItem_By_Value(ref argcombo16, 2.ToString());
            }

            if (time > 200)
                time = 200; // TODO - the most the SP can handle at this time without rewrite - also need to check into next days (BIG)
            priTime = time;
            visitcharge1 = Conversions.ToDouble(txtCharge.Text);
            visitterm1 = Combo.get_GetSelectedItemDescription(cboPayTerms);
        }

        public void AdditionalCharging()
        {
            visitcharge2 = 0;
            visitterm2 = "";
            time = 0;
            int defaultTerm = 0;
            var switchExpr = CurrentCustomer.Terms;
            switch (switchExpr)
            {
                case (int)Enums.Terms.POC:
                    {
                        defaultTerm = 3;
                        break;
                    }

                case (int)Enums.Terms.OTI30Days:
                case (int)Enums.Terms.OTI7Days:
                case (int)Enums.Terms.OTIByReturn:
                    {
                        defaultTerm = 2;
                        break;
                    }

                default:
                    {
                        defaultTerm = 3;
                        break;
                    }
            }

            txtPayInst.Text += Constants.vbNewLine;
            // 'customer type
            var c = App.DB.Customer.Customer_Get(CurrentSite.CustomerID);
            var CoverApps = new List<int>();
            int pri = 0;
            int Sec = 0;
            double serviceCharge = 0;
            double BreakdownCharge = 0;
            if (DGAdditional.Rows.Count > 0)
            {
                foreach (DataRowView dgr in DGVAdditional)
                {
                    var switchExpr1 = dgr["ID"];
                    switch (switchExpr1)
                    {
                        case var @case when @case == "1": // service
                            {
                                DGVAdditional.RowFilter = "ID=1";
                                serviceCharge = 0;
                                var switchExpr2 = c.CustomerTypeID;
                                switch (switchExpr2)
                                {
                                    case (int)Enums.CustomerType.SocialHousing:
                                        {
                                            // housing

                                            time = 40;  // hack for now // 'todo
                                            break;
                                        }

                                    default:
                                        {
                                            var dt = new DataTable();
                                            var drt = default(DataRow);
                                            var Contract = default(Entity.ContractsOriginal.ContractOriginal);
                                            Entity.QuoteContractOriginalSites.QuoteContractOriginalSite contractSite;
                                            if (!Information.IsDBNull(SelecteddgvSitesDataRow.Cells["ContractID"].Value))
                                            {
                                                Contract = App.DB.ContractOriginal.Get(Conversions.ToInteger(SelecteddgvSitesDataRow.Cells["ContractID"].Value));
                                                dt = App.DB.ContractOriginalSite.GetAll_ContractID2(Conversions.ToInteger(SelecteddgvSitesDataRow.Cells["ContractID"].Value), CurrentSite.CustomerID).Table;
                                                drt = dt.Select("tick = 1")[0];
                                            }
                                            // others

                                            if (Contract is object)
                                            {
                                                var argcombo = cboPayTerms;
                                                Combo.SetSelectedComboItem_By_Value(ref argcombo, 1.ToString());
                                                txtPayInst.Text += "Service charges would normally be covered by Contract" + Constants.vbNewLine;
                                                /// go through cover apps work out if anything to pay.
                                                var Assetsdt = new DataTable();
                                                Assetsdt = App.DB.ContractOriginalPPMVisit.GetAllAssets_For_ContractSiteID(Conversions.ToInteger(drt["ContractSiteID"])).Table;
                                                if (Assetsdt.Rows.Count == 0)
                                                {
                                                    txtPayInst.Text += "Any Service Visits Have already been completed for this Contract Period servicing will be chargeable" + Constants.vbNewLine;
                                                }
                                                else
                                                {
                                                    int mainapps = Conversions.ToInteger(Assetsdt.Rows[0]["MainAppliances"]);
                                                    int Secondryapps = Conversions.ToInteger(Assetsdt.Rows[0]["SecondryAppliances"]);
                                                    UseContractVisit = true;
                                                    if (!Information.IsDBNull(Assetsdt.Rows[0]["AssetID"]))
                                                    {
                                                        // we got accosiated apps
                                                        foreach (DataRow dr in Assetsdt.Rows)
                                                        {
                                                            foreach (DataRowView dr1 in DGVAdditional)
                                                            {
                                                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr1["AssetID"], dr["AssetID"], false)))
                                                                {
                                                                    CoverApps.Add(Conversions.ToInteger(dr["AssetID"]));
                                                                    if (CheckMainApps(dr1["Product"].ToString().Split('-')[0]))
                                                                    {
                                                                        // main apps
                                                                        time += servTime;
                                                                        pri = pri + 1;
                                                                    }
                                                                    else
                                                                    {
                                                                        time += servTime;
                                                                        Sec = Sec + 1;
                                                                    }

                                                                    if (pri + Sec >= DgMain.Rows.Count)
                                                                        break;
                                                                }
                                                            }

                                                            if (pri + Sec >= DgMain.Rows.Count)
                                                                break;
                                                        }
                                                    }
                                                    // may not have all the appliances listed by user

                                                    if (pri < mainapps)
                                                    {
                                                        // missing a main appliance which should be under cover

                                                        if (CoverApps.Contains(Conversions.ToInteger(dgr["AssetID"])))
                                                            continue;
                                                        if (CheckMainApps(dgr["Product"].ToString().Split('-')[0], true))
                                                        {
                                                            CoverApps.Add(Conversions.ToInteger(dgr["AssetID"])); // main app added to list
                                                            pri = pri + 1;
                                                            time += servTime;
                                                        }
                                                    }

                                                    if (Sec < Secondryapps)
                                                    {
                                                        // missing a secondry appliance which should be covered

                                                        if (CoverApps.Contains(Conversions.ToInteger(dgr["AssetID"])))
                                                            continue;
                                                        if (!CheckMainApps(dgr["Product"].ToString().Split('-')[0], true))
                                                        {
                                                            CoverApps.Add(Conversions.ToInteger(dgr["AssetID"])); // sec app added to list
                                                            Sec = Sec + 1;
                                                            time += servTime;
                                                            if (Sec >= Secondryapps)
                                                                break; // all sec apps found
                                                        }
                                                    }

                                                    /// Anything left over will be chargeable?
                                                    int excontcount = 0;
                                                    double HighService = 0;
                                                    foreach (DataRowView dr2 in DGVAdditional)  // '' NEW Pricing bit ''''
                                                    {
                                                        if (CoverApps.Contains(Conversions.ToInteger(dr2["AssetID"])))
                                                            continue;
                                                        if (Conversions.ToDouble(Pricing(dr2["Product"].ToString().Split('-')[0])) > HighService)
                                                        {
                                                            HighService = Conversions.ToDouble(Pricing(dr2["Product"].ToString().Split('-')[0]));
                                                        }
                                                    }

                                                    foreach (DataRowView dr1 in DGVAdditional)
                                                    {
                                                        if (CoverApps.Contains(Conversions.ToInteger(dr1["AssetID"])))
                                                            continue;
                                                        // ' start charging
                                                        ChargeApps.Add(Conversions.ToInteger(dr1["AssetID"]));
                                                        excontcount += 1;
                                                        var argcombo1 = cboPayTerms;
                                                        Combo.SetSelectedComboItem_By_Value(ref argcombo1, defaultTerm.ToString());
                                                        CheckMainApps(dr1["Product"].ToString().Split('-')[0]);
                                                        time += servTime;

                                                        // ''''''''''''''''''''''''''''''''''''''''''''''''''NEW PRICING''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                                        if (CoverApps.Count + excontcount > 1)
                                                        {
                                                            serviceCharge = serviceCharge + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("ADDAPP", (Enums.PickListTypes)71));
                                                        }
                                                        else
                                                        {
                                                            serviceCharge = serviceCharge + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("BDOWNPLUS", (Enums.PickListTypes)71));
                                                        }

                                                        txtPayInst.Text += dr1["Product"].ToString().Split('-')[0] + " Service Not covered under contract." + Constants.vbNewLine;
                                                    }

                                                    if (chkCert.Checked == true && DGVAdditional.Count > 0)
                                                    {
                                                        txtPayInst.Text += " LandLord Certificate covered under coverplan" + Constants.vbNewLine;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                var argcombo2 = cboPayTerms;
                                                Combo.SetSelectedComboItem_By_Value(ref argcombo2, defaultTerm.ToString());
                                                double highestPrice = 0;
                                                double tempPrice;
                                                foreach (DataRowView item in DGVAdditional)
                                                {
                                                    tempPrice = Helper.MakeDoubleValid(Pricing(item["Product"].ToString().Split('-')[0]));
                                                    if (tempPrice > highestPrice)
                                                    {
                                                        highestPrice = tempPrice;
                                                    }

                                                    time += servTime;
                                                }

                                                serviceCharge += Helper.MakeDoubleValid(App.DB.Picklists.Get_Single_Description("ADDAPP", (Enums.PickListTypes)71)) * (DGVAdditional.Count - 1) + highestPrice;
                                                if (chkCert.Checked == true && DGVAdditional.Count > 0)
                                                {
                                                    serviceCharge += Helper.MakeDoubleValid(App.DB.Picklists.Get_Single_Description("LLCERT", (Enums.PickListTypes)71));
                                                }
                                            }

                                            break;
                                        }
                                }

                                break;
                            }
                    }
                }
            }

            txtCharge.Text = "£" + Conversions.ToDouble(Conversions.ToDouble(txtCharge.Text) + Conversions.ToDouble(serviceCharge));
            secTime = time;
            DGVAdditional.RowFilter = "1=1";
            visitcharge2 = Conversions.ToDouble(serviceCharge);
            visitterm2 = Combo.get_GetSelectedItemDescription(cboPayTerms);
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // stop duplicating button code
            int engineerID = Conversions.ToInteger(btn.Tag.ToString().Split('^')[0]);
            DateTime Datein = Conversions.ToDate(btn.Tag.ToString().Split('^')[1]);
            string Period = btn.Tag.ToString().Split('^')[2];
            var c = ParentForm.Controls.Find("btnSaveProg", true);
            Button b = (Button)c[0];
            if (!RunValidation())
            {
                return;
            }

            b.Visible = false;
            BookingDetail = "Visit booked with " + App.DB.Engineer.Engineer_Get(engineerID).Name + " Scheduled " + Datein.ToString("dd/MM/yyyy") + " " + Period;
            try
            {
                if (Conversions.ToInteger(txtCharge.Text.Replace("£", "")) > 0)
                {
                    BookingDetail += " Charging " + Strings.Format(Conversions.ToDouble(txtCharge.Text), "C");
                }
            }
            catch (Exception ex)
            {
            }

            btnxx6.Enabled = false;
            visitsBooked += 1;
            Cursor = Cursors.WaitCursor;
            // Add Notes about appointment
            var f = new FrmAdditionalNotes();
            f.ShowDialog();
            var job = CreateVisits(engineerID, Datein, Period, priTime, f.txtAdditionalNotes.Text, visitsBooked);
            CurrentJob = job;
            BookingDetail += " Job Number : " + job.JobNumber;
            if (chkKeepTogether.Checked & secTime > 0)
            {
                visitsBooked += 1;
                job = CreateVisits(engineerID, Datein, Period, secTime, f.txtAdditionalNotes.Text, visitsBooked);
                BookingDetail += ", " + job.JobNumber;
            }
            else if (secTime > 0)
            {
                // jobtype = "SERVICE"    ''''''''''''''''''''''''''''''''''' HARD CODE DODGYNESS
                FindAppointments(true);   // '' -  lets go round again '''' :)
            }

            lblBookedInfo.Text = BookingDetail + " (Click here to view job)";
            Cursor = Cursors.Default;
            btnxx6.Enabled = true;
            Notes(); // prompt for notes
        }

        public bool RunValidation()
        {
            if (CurrentSite.PoNumReqd && txtPONumber.Text.Length < 1)
            {
            }

            return true;
        }

        public Entity.Jobs.Job CreateVisits(int EngineerID, DateTime Datein, string Period, double time, string additionalNotes, int visit = 1)
        {
            bool newJob = false;
            if (CurrentJob is null | visit == 2)
            {
                newJob = true;
            }

            Entity.Jobs.Job job;
            if (newJob)
            {
                job = new Entity.Jobs.Job();
            }
            else
            {
                job = CurrentJob;
            }

            double visittime = time;
            if (chkRecall.Checked & RecallJobTypeID == 4703 & (jobtype ?? "") != "SERVICE" & newJob == true)  // if its a recall just add on the current job
            {
                job = App.DB.Job.Job_Get(RecallJobID);
            }
            else
            {
                var JobNumber_ds = new DataSet();
                JobNumber jobnumber;
                if (newJob)
                {
                    jobnumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
                    job.SetJobNumber = jobnumber.Prefix + jobnumber.Number;
                    // job.SetJobNumber = Job_JobNumber
                }

                job.SetPropertyID = CurrentSite.SiteID;
                job.SetJobDefinitionEnumID = 3;
                if (jobtype.ToUpper().Contains("SERVICE") | visit == 2)
                {
                    job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Service); // service
                    if (chkCert.Checked)
                    {
                        job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.llCert); // ll cert
                    }
                }
                else if (btnxxOther.BackColor == Color.PaleGreen & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboTypeOfWorks)) > 0)
                {
                    job.SetJobTypeID = Combo.get_GetSelectedItemValue(cboTypeOfWorks);
                }
                else if ((jobtype ?? "") == "SOR")
                {
                    job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Dayworks); // Dayworks
                }
                else if ((jobtype ?? "") == "BREAKDOWN")
                {
                    job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Breakdown); // breakdown
                }
                else if ((jobtype ?? "") == "PLUMBING")
                {
                    job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Plumbing);
                }
                else if ((jobtype ?? "") == "CARPENTRY")
                {
                    job.SetJobTypeID = 71039;
                }
                else if ((jobtype ?? "") == "ELECTRICAL")
                {
                    job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.RenewablesElectrical);
                }
                else if ((jobtype ?? "") == "MULTI TRADE")
                {
                    job.SetJobTypeID = 71044;
                }
                else
                {
                    job.SetJobTypeID = Helper.MakeIntegerValid(Enums.JobTypes.Dayworks);
                } // Dayworks

                job.SetCreatedByUserID = App.loggedInUser.UserID;
                job.SetPONumber = DBNull.Value;
                job.SetQuoteID = 0;
                job.SetContractID = 0;
                job.SetToBePartPaid = false;
                job.SetRetention = 0;
                job.SetCollectPayment = false;
                job.SetPOC = false;
                job.SetFOC = false;
                job.SetOTI = false;
                if (visit == 1)
                {
                    var switchExpr = visitterm1;
                    switch (switchExpr)
                    {
                        case "OTI":
                            {
                                job.SetOTI = true;
                                break;
                            }

                        case "POC":
                            {
                                job.SetPOC = true;
                                break;
                            }

                        case "FOC":
                            {
                                job.SetFOC = true;
                                break;
                            }

                        default:
                            {
                                job.SetFOC = true;
                                break;
                            }
                    }
                }
                else
                {
                }

                job.SetDeleted = Conversions.ToBoolean(0);

                /// job assets
                var arraylist1 = new ArrayList();
                if (newJob == false)
                {
                    App.DB.ExecuteScalar("Delete tblJobAsset where JobID = " + CurrentJob.JobID);
                }

                if (visit == 1)
                {
                    foreach (DataGridViewRow dr in DgMain.Rows)
                    {
                        if (Conversions.ToBoolean((dr.Cells["Product"].Value.ToString().Contains("- Unknown") | dr.Cells["Product"].Value.ToString().Contains("Non Appliance Related")) & dr.Cells["AssetID"].Value < 21))
                        {
                        }
                        else
                        {
                            var jobass = new Entity.JobAssets.JobAsset();
                            jobass.SetAssetID = dr.Cells["AssetID"].Value;
                            jobass.SetJobID = job.JobID;
                            arraylist1.Add(jobass);
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow dr in DGAdditional.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr.Cells["ID"].Value, 1, false)))
                        {
                            var jobass = new Entity.JobAssets.JobAsset();
                            jobass.SetAssetID = dr.Cells["AssetID"].Value;
                            jobass.SetJobID = job.JobID;
                            arraylist1.Add(jobass);
                        }
                    }
                }

                job.Assets = arraylist1;
            }

            Entity.JobOfWorks.JobOfWork jow;
            if (newJob)
            {
                jow = new Entity.JobOfWorks.JobOfWork();
            }
            else
            {
                jow = App.DB.JobOfWorks.JobOfWork_Get(currentVisit.JobOfWorkID);
            }

            jow.SetJobID = job.JobID;
            jow.SetDeleted = Conversions.ToBoolean("0");
            jow.SetPONumber = txtPONumber.Text;
            jow.SetStatus = "1";
            jow.SetPriority = Combo.get_GetSelectedItemValue(cboPriority);
            if (newJob)
            {
                jow.PriorityDateSet = DateTime.Now;
            }
            else if (jow.PriorityDateSet < new DateTime(2001, 1, 1) | jow.PriorityDateSet == DateTime.MinValue) // check if it's way old
            {
                jow.PriorityDateSet = DateTime.Now;
            }

            if (!newJob)
            {
                App.DB.JobItems.DeleteAll_ForJOW(currentVisit.JobOfWorkID);
            }

            var SORdt = App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(CurrentCustomer.CustomerID).Table;
            DataRow[] sorRows;
            var sorTableSERV = SORdt.Clone();
            int count = 0;
            if (CurrentCustomer.CustomerTypeID == (int)Enums.CustomerType.SocialHousing)
            {
                if ((jobtype ?? "") == "SERVICE" | visit == 2)
                {
                    try
                    {
                        sorTableSERV.Rows.Add(SORdt.Select("Code='EA7007,'")[0].ItemArray);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if ((jobtype ?? "") == "BREAKDOWN")
                {
                    try
                    {
                        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPriority)) == (double)Enums.JobPriority.EMTwentyFourHours)
                        {
                            sorTableSERV.Rows.Add(SORdt.Select("Code='EA7003'")[0].ItemArray);
                        }
                        else
                        {
                            sorTableSERV.Rows.Add(SORdt?.Select("Code='EA7005'")[0].ItemArray);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if ((jobtype ?? "") == "SOR")
                {
                    try
                    {
                        foreach (DataGridViewRow dr in DGSOR.Rows)
                            sorTableSERV.Rows.Add(SORdt.Select("Code='" + dr.Cells["code"].Value.ToString() + "'")[0].ItemArray);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else if ((jobtype ?? "") == "SERVICE" | visit == 2)
            {
                if (visit == 1)
                {
                    foreach (DataGridViewRow dr in DgMain.Rows)
                    {
                        try
                        {
                            if (count > 0)
                            {
                                sorTableSERV.Rows.Add(SORdt.Select("Code='SERVADD'")[0].ItemArray);
                                continue;
                            }

                            switch (true)
                            {
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("SOLID"):
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("WOOD"):
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("OPEN FIRE"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='EA7001^'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("COMMERCIAL"):
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("CONVECTOR HEATER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='C1'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("STORE"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV5'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("OIL BOILER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SVOB'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("BOILER"):
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("COND BOILER"):
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("COND COMBI"):
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("BACK BOILER"):
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("STD EFF BOILER"):
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("STD EFF COMBI"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV1'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("WARM AIR UNIT"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV4'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("AIR SOURCE"):
                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("GROUND SOURCE"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SVASHP'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("LARGE UNIT HEATER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV10A'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("UNIT HEATER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV10'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("GAS FIRE"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV6'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("WATER HEATER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV7'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("UNVENTED CYLINDER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SERV UNVENT'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("RANGE COOKER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV8'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }
                                // 2 X attend

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("COOKER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV8'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr.Cells["Product"].Value.ToString().ToUpper().Split('-')[0].Contains("HOB"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV9'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else
                {
                    foreach (DataRowView dr in DGVAdditional)
                    {
                        if (count > 0)
                        {
                            sorTableSERV.Rows.Add(SORdt.Select("Code='SERVADD'")[0].ItemArray);
                            continue;
                        }

                        try
                        {
                            switch (true)
                            {
                                case object _ when dr["Product"].ToString().ToUpper().ToUpper().Split('-')[0].Contains("SOLID"):
                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("WOOD"):
                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("OPEN FIRE"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='EA7001^'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("COMMERCIAL"):
                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("CONVECTOR HEATER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='C1'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("STORE"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV5'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("OIL BOILER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SVOB'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("BOILER"):
                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("COND BOILER"):
                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("COND COMBI"):
                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("BACK BOILER"):
                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("STD EFF BOILER"):
                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("STD EFF COMBI"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV1'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("WARM AIR UNIT"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV4'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("AIR SOURCE"):
                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("GROUND SOURCE"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SVASHP'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("LARGE UNIT HEATER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV10A'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("UNIT HEATER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV10'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("GAS FIRE"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV6'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("WATER HEATER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV7'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("UNVENTED CYLINDER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SERV UNVENT'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("RANGE COOKER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV8'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }
                                // 2 X attend

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("COOKER"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV8'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }

                                case object _ when dr["Product"].ToString().ToUpper().Split('-')[0].Contains("HOB"):
                                    {
                                        sorTableSERV.Rows.Add(SORdt.Select("Code='SV9'")[0].ItemArray);
                                        count += 1;
                                        break;
                                    }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            else if ((jobtype ?? "") == "BREAKDOWN")
            {
                try
                {
                    sorTableSERV.Rows.Add(SORdt.Select("Code='CBK'")[0].ItemArray);
                }
                catch (Exception ex)
                {
                }

                if (CurrentCustomer.CustomerTypeID == (int)Enums.CustomerType.Insurance)
                {
                    try
                    {
                        sorTableSERV.Rows.Add(SORdt.Select("Code='INSBRK'")[0].ItemArray);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else if ((jobtype ?? "") == "SOR")
            {
                foreach (DataGridViewRow dr in DGSOR.Rows)
                {
                    try
                    {
                        sorTableSERV.Rows.Add(SORdt.Select("Code='" + dr.Cells["code"].Value.ToString() + "'")[0].ItemArray);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            if (sorTableSERV.Rows.Count < 1)
            {
                sorTableSERV.Rows.Add(SORdt.Select("Code='DEFAULTS' AND Description = 'Normal Labour'")[0].ItemArray);
            }

            sorRows = sorTableSERV.Select("1=1");
            foreach (DataRow DR in sorRows)
            {
                var sorRow = DR;
                var customerSors = App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(sorRow["ScheduleOfRatesCategoryID"]), Conversions.ToString(sorRow["Description"]), Conversions.ToString(sorRow["Code"]), CurrentSite.CustomerID);
                int customerSorId = 0;
                if (customerSors.Rows.Count > 0)
                    customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                if (!(customerSorId > 0))
                {
                    var customerSor = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate()
                    {
                        SetCode = sorRow["Code"],
                        SetDescription = sorRow["Description"],
                        SetPrice = sorRow["Price"],
                        SetScheduleOfRatesCategoryID = sorRow["ScheduleOfRatesCategoryID"],
                        SetTimeInMins = sorRow["TimeInMins"],
                        SetCustomerID = CurrentSite.CustomerID
                    };
                    customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                }

                double sorqty = 1;  // make sor qty react to time allowance
                if (TimeReqOption == true)
                {
                    if (Information.IsNumeric(txtDays.Text) && Conversions.ToInteger(txtDays.Text) > 0)
                    {
                        sorqty = Conversions.ToInteger(txtDays.Text) * 8;
                    }
                    else
                    {
                        sorqty = 0;
                    }

                    if (Information.IsNumeric(txtHrs.Text) && Conversions.ToInteger(txtHrs.Text) > 0)
                    {
                        sorqty += Conversions.ToDouble(txtHrs.Text);
                    }

                    if (sorqty == 0)
                        sorqty = 1; // SET A DEFAULT UP
                }

                var jobItem = new Entity.JobItems.JobItem();
                jobItem.IgnoreExceptionsOnSetMethods = true;
                jobItem.SetSummary = sorRow["Description"];
                jobItem.SetQty = 1;
                jobItem.SetRateID = customerSorId;
                jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                if (newJob)
                {
                    jow.JobItems.Add(jobItem);
                }
                else
                {
                    jobItem.SetJobOfWorkID = jow.JobOfWorkID;
                    App.DB.JobItems.Insert(jobItem);
                }
            }

            string startdatetime = "";
            string enddatetime = "";
            int appointmentID = 0;
            Entity.EngineerVisits.EngineerVisit ev;
            if (newJob)
            {
                ev = new Entity.EngineerVisits.EngineerVisit();
                if (costCentre is object)
                {
                    ev.SetExpectedDepartment = costCentre;
                }
            }
            else
            {
                ev = currentVisit;
            }

            // FIND THE GAP
            if (Datein > DateTime.MinValue.AddDays(2))
            {
                var switchExpr1 = Period;
                switch (switchExpr1)
                {
                    case "AM":
                        {
                            Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 08:00:01");
                            appointmentID = 69943;
                            break;
                        }

                    case "PM":
                        {
                            Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 12:00:01");
                            appointmentID = 69944;
                            break;
                        }

                    case "8-12":
                        {
                            Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 08:00:01");
                            appointmentID = 69939;
                            break;
                        }

                    case "10-2":
                        {
                            Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 10:00:01");
                            appointmentID = 69940;
                            break;
                        }

                    case "12-4":
                        {
                            Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 12:00:01");
                            appointmentID = 69941;
                            break;
                        }

                    case "2-6":
                        {
                            Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 14:00:01");
                            appointmentID = 69942;
                            break;
                        }

                    case "8AM":
                        {
                            Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 08:00:00");
                            appointmentID = 69938;
                            break;
                        }

                    case "ANY":
                        {
                            Datein = Conversions.ToDate(Conversions.ToString(Datein).Substring(0, 10) + " 12:00:00");
                            appointmentID = 69945;
                            break;
                        }
                }

                startdatetime = Conversions.ToString(Datein).Replace("/", "-");
                var DT = App.DB.EngineerVisits.Find_The_Gap(Strings.Format(Datein, "yyyy-MM-dd"), EngineerID, Period);
                if (DT.Rows.Count == 0 | (Period ?? "") == "8AM")
                {
                }

                // 69938	78	8AM / FIRST CALL
                // 69939	78	8AM - 12PM
                // 69940	78	10AM - 2PM
                // 69941	78	12PM - 4PM
                // 69942	78	2PM - 6PM
                // 69943	78	AM
                // 69944	78	PM
                // 69945	78	ANYTIME
                else
                {
                    startdatetime = Conversions.ToString(DT.Rows[0]["EndDateTime"]);
                }

                if (TimeReqOption == true)
                {
                    if (Information.IsNumeric(txtDays.Text) && Conversions.ToInteger(txtDays.Text) > 0)
                    {
                        visittime = Conversions.ToInteger(txtDays.Text) * 24 * 60;
                    }
                    else
                    {
                        visittime = 0;
                    }

                    if (Information.IsNumeric(txtHrs.Text) && Conversions.ToInteger(txtHrs.Text) > 0)
                    {
                        visittime += Conversions.ToDouble(txtHrs.Text) * 60;
                    }

                    if (visittime == 0)
                        visittime = 60; // SET A DEFAULT UP
                }

                enddatetime = Conversions.ToString(Conversions.ToDate(startdatetime).AddMinutes(Conversions.ToDouble(visittime)));
                startdatetime = Strings.Format(Conversions.ToDate(startdatetime), "yyyy-MM-dd HH:mm:ss");
                enddatetime = Strings.Format(Conversions.ToDate(enddatetime), "yyyy-MM-dd HH:mm:ss");
                ev.StartDateTime = Conversions.ToDate(startdatetime);
                ev.EndDateTime = Conversions.ToDate(enddatetime);
                ev.SetAppointmentID = appointmentID;
                ev.SetStatusEnumID = "5";
            }
            else
            {
                ev.SetStatusEnumID = "4";
            }

            ev.SetJobOfWorkID = jow.JobOfWorkID;
            string payterms;
            if (visit == 1)
            {
                payterms = visitterm1;
            }
            else
            {
                payterms = visitterm2;
            }

            if ((Period ?? "") == "Anytime")
            {
                Period = "ANY";
            }

            ev.SetNotesToEngineer = "(" + Period + ")";
            foreach (string s in SkillsList)
                ev.SetNotesToEngineer = ev.NotesToEngineer + " *" + s + "*";
            if (CurrentSite.CommercialDistrict)
            {
                ev.SetNotesToEngineer = ev.NotesToEngineer + " DISTRICT";
            }

            if (additionalNotes.Length > 0)
            {
                ev.SetNotesToEngineer = ev.NotesToEngineer + " - " + additionalNotes + " -";
            }

            if ((jobtype ?? "") == "SERVICE" | visit == 2)
            {
                if (chkCert.Checked)
                {
                    ev.SetNotesToEngineer = ev.NotesToEngineer + " Service & Cert Visit - ";
                }
                else
                {
                    ev.SetNotesToEngineer = ev.NotesToEngineer + " Service Visit - ";
                }

                foreach (DataGridViewRow dr in DgMain.Rows)
                    ev.SetNotesToEngineer = ev.NotesToEngineer + dr.Cells["Product"].Value.ToString().Split('-')[0] + " - " + dr.Cells["Product"].Value.ToString().Split('-')[1] + ", ";
                ev.SetNotesToEngineer = ev.NotesToEngineer + " " + txtAdditional.Text + " - " + payterms;
            }
            else if ((jobtype ?? "") == "BREAKDOWN")
            {
                ev.SetNotesToEngineer = ev.NotesToEngineer + " Breakdown Visit - ";
                foreach (DataGridViewRow dr in DGSymptoms.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr.Cells["Code"].Value, "OTHER", false)))
                        continue;
                    ev.SetNotesToEngineer = ev.NotesToEngineer + dr.Cells["Description"].Value + ", ";
                }

                ev.SetNotesToEngineer = ev.NotesToEngineer + " " + txtAdditional.Text + " - " + payterms;
            }
            else if ((jobtype ?? "") == "SOR")
            {
                ev.SetNotesToEngineer = ev.NotesToEngineer + " Complete SOR based Works  - See SOR List";
                ev.SetNotesToEngineer = ev.NotesToEngineer + " " + txtAdditional.Text + " - " + payterms;
            }
            else
            {
                ev.SetNotesToEngineer = ev.NotesToEngineer + " Complete " + jobtype + " based Works - ";
                ev.SetNotesToEngineer = ev.NotesToEngineer + " " + txtAdditional.Text + " - " + payterms;
            }

            if (visit == 1)
            {
                if ((visitterm1 ?? "") == "POC") // POC
                {
                    ev.SetNotesToEngineer = ev.NotesToEngineer + " £" + visitcharge1 + " inc VAT";
                }
            }
            else if ((visitterm2 ?? "") == "POC") // POC
            {
                ev.SetNotesToEngineer = ev.NotesToEngineer + " £" + visitcharge2 + " inc VAT";
            }

            ev.SetPartsToFit = false;
            ev.SetEngineerID = EngineerID;
            var ja1 = new Entity.JobAudits.JobAudit();
            string ActionChange = "";
            if (!job.Exists)
            {
                jow.EngineerVisits.Add(ev);
                job.JobOfWorks.Add(jow);
                job = App.DB.Job.Insert(job);
                ActionChange = "New Visit Inserted through the Wizard (By User " + App.loggedInUser.Fullname + ") - Status: NOT SET (Unique Visit ID: " + ev.EngineerVisitID + ")";
            }
            else
            {
                job = App.DB.Job.Update(job, new ArrayList(), new ArrayList(), new ArrayList());
                App.DB.JobOfWorks.Update_PONumber(jow);
                App.DB.JobOfWorks.Update_Priority(jow);
                App.DB.EngineerVisits.Update(ev, CurrentJob.JobID, true);
                ActionChange = "Visit Updated through the Wizard (By User " + App.loggedInUser.Fullname + ") - Status: NOT SET (Unique Visit ID: " + ev.EngineerVisitID + ")";
            }

            jobids = job.JobID;

            // Add symptoms to visit
            App.DB.EngineerVisits.DeleteExtendedProperties(ev.EngineerVisitID);
            App.DB.EngineerVisits.DeleteSymptoms(ev.EngineerVisitID);
            foreach (DataGridViewRow dr in DGSymptoms.Rows)
                App.DB.EngineerVisits.InsertSymptom(ev.EngineerVisitID, Conversions.ToInteger(dr.Cells["SypID"].Value));
            // Add Additional Text
            if (txtAdditional.Text.ToString().Length > 0)
            {
                App.DB.EngineerVisits.InsertAdditionalText(ev.EngineerVisitID, txtAdditional.Text.ToString());
            }

            ja1.SetJobID = job.JobID;
            ja1.SetActionChange = ActionChange;
            App.DB.JobAudit.Insert(ja1);
            if (string.IsNullOrEmpty(BookingDetail))
            {
                BookingDetail = "Job saved as ready for schedule Job Number - " + job.JobNumber;
                foreach (DataRow dr in DTPrivNotes.Select("JobNoteID = 0"))
                    App.DB.Job.SaveJobNotes(0, Conversions.ToString(dr["Note"]), Conversions.ToInteger(dr["EditedByUserID"]), job.JobID, Conversions.ToInteger(dr["CreatedByUserID"])).ToTable();
                DTPrivNotes = App.DB.Job.GetAllJobNotes(CurrentSite.SiteID);
                try
                {
                    tcSites.TabPages[0].Enabled = true;
                    tcSites.TabPages.Remove(tabProp);
                    // tcSites.TabPages.Add(tabProp)
                    tcSites.TabPages.Remove(tabExistingJobs);
                    tcSites.TabPages.Remove(tabJobType);
                    tcSites.TabPages.Remove(tabJobDetails);
                    tcSites.TabPages.Remove(tabAppliance);
                    tcSites.TabPages.Remove(TabCharging);
                    tcSites.TabPages.Remove(tabAdditional);
                    tcSites.TabPages.Remove(TabBook);
                    tcSites.TabPages.Insert(tcSites.TabCount, tcComplete);
                    tab = tcSites.SelectedIndex + 1;
                    tcSites.SelectedIndex = tcSites.SelectedIndex + 1;
                    tcSites.SelectedIndex = 1;
                }
                // tcSites.SelectedIndex = 1
                // Temp.Clear()
                catch (Exception ex)
                {
                    tcSites.TabPages.Insert(tcSites.TabCount, tcComplete);
                    tab = tcSites.SelectedIndex + 1;
                    tcSites.SelectedIndex = tcSites.SelectedIndex + 1;
                    tcSites.SelectedIndex = 0;
                }

                return job;
            }
            else if (visit == 2 | (DGVAdditional is object && DGVAdditional.Count == 0))
            {
                if (BookingDetail.Contains("Job saved as ready for schedule Job"))
                {
                    BookingDetail += " & " + job.JobNumber;
                }
                else
                {
                    // If tcSites.TabCount = 8 Then
                    var dt = new DataTable();
                    dt = DTPrivNotes;
                    var dr = dt.NewRow();
                    dr[0] = 0;
                    dr[1] = App.loggedInUser.UserID;
                    dr[2] = App.loggedInUser.UserID;
                    dr[3] = "Visit booked with " + App.DB.Engineer.Engineer_Get(EngineerID).Name + " Scheduled " + Datein.ToString("dd/MM/yyyy") + " " + Period;
                    dr[4] = DateTime.Now;
                    dr[5] = App.loggedInUser.Username;
                    dr[6] = DateTime.Now;
                    dr[7] = App.loggedInUser.Username;
                    dr[8] = 0;
                    dr[9] = "New..";
                    dr[10] = 0;
                    dt.Rows.InsertAt(dr, 0);
                    DTPrivNotes = dt;
                    foreach (DataRow dr1 in DTPrivNotes.Select("JobNoteID = 0"))
                        App.DB.Job.SaveJobNotes(0, Conversions.ToString(dr1["Note"]), Conversions.ToInteger(dr1["EditedByUserID"]), job.JobID, Conversions.ToInteger(dr1["CreatedByUserID"])).ToTable();
                    DTPrivNotes = App.DB.Job.GetAllJobNotes(CurrentSite.SiteID);
                    try
                    {
                        tcSites.TabPages[0].Enabled = true;
                        tcSites.TabPages.Remove(tabProp);
                        // tcSites.TabPages.Add(tabProp)
                        tcSites.TabPages.Remove(tabExistingJobs);
                        tcSites.TabPages.Remove(tabJobType);
                        tcSites.TabPages.Remove(tabJobDetails);
                        tcSites.TabPages.Remove(tabAppliance);
                        tcSites.TabPages.Remove(TabCharging);
                        tcSites.TabPages.Remove(tabAdditional);
                        tcSites.TabPages.Remove(TabBook);
                        tcSites.SelectedIndex = 1;
                        // tcSites.SelectedIndex = 1
                        // Temp.Clear()
                        tcSites.TabPages.Insert(tcSites.TabCount, tcComplete);
                        tab = tcSites.SelectedIndex + 1;
                        tcSites.SelectedIndex = tcSites.SelectedIndex + 1;
                    }
                    catch (Exception ex)
                    {
                        tcSites.TabPages.Insert(tcSites.TabCount, tcComplete);
                        tab = tcSites.SelectedIndex + 1;
                        tcSites.SelectedIndex = tcSites.SelectedIndex + 1;
                        tcSites.SelectedIndex = 0;
                    }
                }
            }

            return job;
        }

        private bool CheckMainApps(string Wordin, bool secondry = false)
        {
            switch (true)
            {
                case object _ when Wordin.ToUpper().Contains("SOLID"):
                case object _ when Wordin.ToUpper().Contains("WOOD"):
                case object _ when Wordin.ToUpper().Contains("OPEN FIRE"):
                    {
                        HETASNEEDED = true;
                        servTime = 90;
                        break;
                    }

                case object _ when Wordin.ToUpper().Contains("COMMERCIAL"):
                case object _ when Wordin.ToUpper().Contains("CONVECTOR HEATER"):
                    {
                        COMMNEEDED = true;
                        servTime = 90;
                        break;
                    }

                case object _ when Wordin.ToUpper().Contains("STORE"):
                    {
                        servTime = 45;
                        return true;
                    }

                case object _ when Wordin.ToUpper().Contains("OIL BOILER"):
                    {
                        servTime = 60;
                        OILNEEDED = true;
                        return true;
                    }

                case object _ when Wordin.ToUpper().Contains("BOILER"):
                case object _ when Wordin.ToUpper().Contains("COND BOILER"):
                case object _ when Wordin.ToUpper().Contains("COND COMBI"):
                case object _ when Wordin.ToUpper().Contains("BACK BOILER"):
                case object _ when Wordin.ToUpper().Contains("STD EFF BOILER"):
                case object _ when Wordin.ToUpper().Contains("STD EFF COMBI"):
                    {
                        servTime = 45;
                        NATNEEDED = true;
                        return true;
                    }

                case object _ when Wordin.ToUpper().Contains("WARM AIR UNIT"):
                    {
                        NATNEEDED = true;
                        WAUNEEDED = true;
                        servTime = 75;
                        return true;
                    }

                case object _ when Wordin.ToUpper().Contains("AIR SOURCE"):
                case object _ when Wordin.ToUpper().Contains("GROUND SOURCE"):
                    {
                        ASNEEDED = true;
                        servTime = 35;
                        return true;
                    }

                case object _ when Wordin.ToUpper().Contains("LARGE UNIT HEATER"):
                    {
                        NATNEEDED = true;
                        servTime = 60;
                        break;
                    }

                // 2 x Attend

                case object _ when Wordin.ToUpper().Contains("UNIT HEATER"):
                    {
                        NATNEEDED = true;
                        servTime = 30;
                        break;
                    }

                case object _ when Wordin.ToUpper().Contains("GAS FIRE"):
                    {
                        NATNEEDED = true;
                        servTime = 45;
                        break;
                    }

                case object _ when Wordin.ToUpper().Contains("WATER HEATER"):
                    {
                        NATNEEDED = true;
                        servTime = 60;
                        break;
                    }

                case object _ when Wordin.ToUpper().Contains("UNVENTED CYLINDER"):
                    {
                        servTime = 15;
                        break;
                    }

                case object _ when Wordin.ToUpper().Contains("RANGE COOKER"):
                    {
                        NATNEEDED = true;
                        servTime = 90;
                        break;
                    }

                // 2 X attend

                case object _ when Wordin.ToUpper().Contains("COOKER"):
                    {
                        NATNEEDED = true;
                        servTime = 55;
                        break;
                    }

                case object _ when Wordin.ToUpper().Contains("HOB"):
                    {
                        NATNEEDED = true;
                        servTime = 30;
                        break;
                    }
            }

            return false;
        }

        private string Pricing(string wordin)
        {
            switch (true)
            {
                case object _ when wordin.ToUpper().Contains("STORE"):
                    {
                        return App.DB.Picklists.Get_Single_Description("STOREBLR", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("OIL BOILER"):
                    {
                        return App.DB.Picklists.Get_Single_Description("OILBLR", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("BOILER"):
                case object _ when wordin.ToUpper().Contains("COND BOILER"):
                case object _ when wordin.ToUpper().Contains("COND COMBI"):
                case object _ when wordin.ToUpper().Contains("BACK BOILER"):
                case object _ when wordin.ToUpper().Contains("STD EFF BOILER"):
                case object _ when wordin.ToUpper().Contains("STD EFF COMBI"):
                    {
                        return App.DB.Picklists.Get_Single_Description("BOILER", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("WARM AIR UNIT"):
                    {
                        return App.DB.Picklists.Get_Single_Description("WARMAIR", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("AIR SOURCE"):
                    {
                        return App.DB.Picklists.Get_Single_Description("AIRANDSOL", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("LARGE UNIT HEATER"):
                    {
                        return App.DB.Picklists.Get_Single_Description("LRGUNIT", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("UNIT HEATER"):
                    {
                        return App.DB.Picklists.Get_Single_Description("UNITHTR", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("GAS FIRE"):
                    {
                        return App.DB.Picklists.Get_Single_Description("GASFIRE", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("WATER HEATER"):
                    {
                        return App.DB.Picklists.Get_Single_Description("WATERHTR", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("UNVENTED CYLINDER"):
                    {
                        if (DgMain.RowCount == 1)
                        {
                            return App.DB.Picklists.Get_Single_Description("UNVENT", (Enums.PickListTypes)71);
                        }
                        else
                        {
                            return App.DB.Picklists.Get_Single_Description("UNVENTPLUS", (Enums.PickListTypes)71);
                        }

                        break;
                    }

                case object _ when wordin.ToUpper().Contains("RANGE COOKER"):
                    {
                        return App.DB.Picklists.Get_Single_Description("RNGCKR", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("COOKER"):
                    {
                        return App.DB.Picklists.Get_Single_Description("CKR", (Enums.PickListTypes)71);
                    }

                case object _ when wordin.ToUpper().Contains("HOB"):
                    {
                        return App.DB.Picklists.Get_Single_Description("HOB", (Enums.PickListTypes)71);
                    }
            }

            return default;
        }

        // 475	14	Domestic
        // 513	14	Agency
        // 514	14	Manufacturer
        // 515	14	Commercial/Industrial
        // 516	14	Housing Association/Council
        // 517	14	Insurance
        // 518	14	Private Landlord
        // 539	14	Unknown
        // 4715	14	Sub Contractor
        // 6430	14	Non Chargeable
        // 68552	14	GBS

        private void FindAppointments(bool SecondVisit = false)
        {
            // work out time requirement
            var btns = new[] { btnOption1, btnOption2, btnOption3, btnOption4, btnOption5, btnOption6, btnOption7, btnOption8, btnOption10 };
            foreach (Button b in btns)
                b.Visible = false;
            Application.DoEvents();
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Dim temp As New DataTable

            if (secTime == 0)
            {
                chkKeepTogether.Visible = false;
            }
            else
            {
                chkKeepTogether.Visible = true;
            }

            if (chkKeepTogether.Checked)
            {
                reqtime = priTime + secTime;
                lblBookText.Text = "Booking All Visits";
            }
            else if (!SecondVisit)
            {
                reqtime = priTime;
                if (jobtype.ToUpper().Contains("SERVICE"))
                {
                    dtpFromDate.Value = DateAndTime.Now.AddDays(14);
                    // TODO title
                    lblBookText.Text = "Booking Service Visit";
                }
                else
                {
                    dtpFromDate.Value = DateAndTime.Now;
                    // TODO title
                    lblBookText.Text = "Booking " + jobtype + " Visit";
                }
            }
            else
            {
                reqtime = secTime;
                dtpFromDate.Value = DateAndTime.Now.AddDays(14);
                if (jobtype.ToUpper().Contains("SERVICE"))
                {
                    dtpFromDate.Value = DateAndTime.Now.AddDays(14);
                    // TODO title
                    lblBookText.Text = "Booking Service Visit";
                }
                else
                {
                    dtpFromDate.Value = DateAndTime.Now;
                    // TODO title
                    lblBookText.Text = "Booking " + jobtype + " Visit";
                }
            }

            bool liverefresh = false;
            if (Temp.Rows.Count == 0 | currentFilterDate > DateTime.MinValue & dtpFromDate.Value.AddDays(-7) > currentFilterDate | dtpFromDate.Value < currentFilterDate)
            {
                // temp.Clear()
                liverefresh = true;
                currentFilterDate = Conversions.ToDate(dtpFromDate.Value);
                if (!CurrentCustomer.SuperBook)
                {
                    Temp = App.DB.EngineerVisits.Get_Appointments_Multi(dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm"), priTime);
                }
                else
                {
                    Temp = App.DB.EngineerVisits.Get_Appointments_Multi(dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm"), priTime, 1); // create the structure
                    Temp.Clear();
                }

                Temp.Columns.Add("AssignedArea");
            }

            // get the skills needed for this customer (if any)
            IList<int> levelsList = new List<int>();
            int co = 0;
            var dd = App.DB.Customer.Requirements_Get_For_CustomerID(CurrentCustomer.CustomerID).Table.Select("tick = 1");
            foreach (DataRow d in dd)
            {
                levelsList.Add(Conversions.ToInteger(d["ManagerID"]));
                co += 1;
            }

            // Get any skills needed for this job type
            var JobLevels = App.DB.EngineerLevel.Get_List_For_JobType(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cbotypeWiz)));
            foreach (DataRow dr in JobLevels.Rows)
                levelsList.Add(Conversions.ToInteger(dr["SkillID"]));

            // if no skills / qualifications are needed then add the default retail trained qual - always need one qual
            if (co == 0 & JobLevels.Rows.Count == 0)
            {
                levelsList.Add(69697);
            }

            var SiteFuel = App.DB.Sites.SiteFuel_GetAll_ForSite(CurrentSite.SiteID);
            // Dim AdditionalService As Boolean
            // For Each dd1 As DataGridViewRow In DGAdditional.Rows
            // If dd1.Cells("ID").Value = 1 Then
            // AdditionalService = True
            // End If

            // Next
            // if site is flagged as district commercial guys should go
            if (jobtype.ToUpper().Contains("BREAKDOWN") & Conversions.ToInteger(CurrentSite.CommercialDistrict) == 1)
            {
                COMMNEEDED = true;
            }

            // if a selected appliance is fuel LPG, an LPG skill is required
            LPGNEEDED = false;
            var ass = new Entity.Assets.Asset();
            foreach (DataGridViewRow row in DgMain.Rows)
            {
                if (Conversions.ToBoolean(row.Cells["ASSETID"].Value > 20))
                {
                    ass = App.DB.Asset.Asset_Get(Conversions.ToInteger(row.Cells["ASSETID"].Value));
                }
                else
                {
                    foreach (DataRow dr in SiteFuel.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["FuelID"], 378, false)))
                        {
                            LPGNEEDED = true;
                        }
                    }
                }

                if (ass.GasTypeID == 378) // LPG
                {
                    LPGNEEDED = true;
                }
            }

            // ''''''''''''''''''''''''''WHATS NEEDED ''''''''''''''''''''''''''''''''''''

            SkillsList.Clear();

            // CORE GAS
            if (NATNEEDED)
            {
                levelsList.Add(68820);
                SkillsList.Add("NAT GAS");
            }
            // LPG
            if (LPGNEEDED)
            {
                levelsList.Add(68857);
                SkillsList.Add("LPG");
            }
            // COMM
            if (COMMNEEDED)
            {
                levelsList.Add(68846);
                SkillsList.Add("COMMERCIAL");
            }
            // WAU
            if (WAUNEEDED)
            {
                levelsList.Add(68836);
                SkillsList.Add("WAU");
            }
            // OIL
            if (OILNEEDED)
            {
                levelsList.Add(68863);
                SkillsList.Add("OIL");
            }
            // AIR SOURCE
            if (ASNEEDED)
            {
                levelsList.Add(69743);
                SkillsList.Add("ASHP");
            }
            // HETAS
            if (HETASNEEDED)
            {
                levelsList.Add(68877);
                SkillsList.Add("HEATAS");
            }
            // ELECT
            if ((SpecialTrade ?? "") == "ELEC")
            {
                levelsList.Add(68868);
                SkillsList.Add("ELEC");
            }
            // PLUMBER
            if ((SpecialTrade ?? "") == "PLUM")
            {
                // levelsList.Add(68857)
            }
            // BANDM
            if ((SpecialTrade ?? "") == "BANDM")
            {
                // levelsList.Add(68857)
            }

            // '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            if (liverefresh)
            {
                foreach (DataRow r in Temp.Rows)
                    r["AssignedArea"] = 1;
                Temp = AppointmentStrip(ref Temp, (List<int>)levelsList, false); // strip out not postcoded engineers and those who dont work on this work.
            }

            appointments.Clear();
            appointments = Temp.Clone();
            appointments.Columns["EIGHT_TWELVE"].DataType = Type.GetType("System.Double");
            appointments.Columns["TEN_TWO"].DataType = Type.GetType("System.Double");
            appointments.Columns["TWELVE_FOUR"].DataType = Type.GetType("System.Double");
            appointments.Columns["TWO_SIX"].DataType = Type.GetType("System.Double");
            appointments.Columns.Add("SCORE");
            appointments.Columns["SCORE"].DataType = Type.GetType("System.Int32");
            foreach (DataRow row in Temp.Rows)
                appointments.ImportRow(row);
            var AppointmentsView = new DataView();
            appointments.TableName = "Appointments";
            AppointmentsView.Table = appointments;
            DateTime targettime = Conversions.ToDate(workingdays(DateTime.Now.ToString(), 2));
            if ((jobtype ?? "") == "BREAKDOWN")
            {
            }
            else
            {
                targettime = Conversions.ToDate(workingdays(DateTime.Now.ToString(), 200));
            }

            // ' get target time
            var dt = App.DB.Customer.Priorities_Get_For_CustomerID_Active(CurrentCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPriority))).Table;
            if (dt.Rows.Count == 1)
            {
                var dr = dt.Rows[0];
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["IncludeWeekends"], true, false)))
                {
                    targettime = DateTime.Now.AddHours(Conversions.ToDouble(dr["TargetHours"]));
                }
                else
                {
                    if (Conversions.ToBoolean(dr["TargetHours"] < 24))
                    {
                        targettime = DateTime.Now.AddHours(Conversions.ToDouble(dr["TargetHours"]));
                    }

                    double days1 = Conversions.ToDouble(dr["TargetHours"] / 24); // cheat
                    if (days1 < 1)
                    {
                        targettime = Conversions.ToDate(workingdays(DateTime.Now.ToString(), 1));
                    }
                    else
                    {
                        targettime = Conversions.ToDate(workingdays(DateTime.Now.ToString(), Conversions.ToInteger(days1)));
                    }
                }

                // need to do explicit ones like only exclude ooh or only exclude BH but its rare so ent bothered right now

                // Select Case Combo.GetSelectedItemDescription(cboPriority)
                // Case "P1 - 5 Days"
                // targettime = workingdays(DateTime.Now.ToString, 5)
                // Case "Service"
                // Case "EM - 24HRS"
                // targettime = DateTime.Now.AddHours(24) ' 24 Hours is 24Hrs
                // Case "R1 - 20 Days"
                // targettime = workingdays(DateTime.Now.ToString, 20)
                // Case "RC -Recall"
                // targettime = workingdays(DateTime.Now.ToString, 5)
                // Case "Dayworks"
                // Case "P3 - 3 Days"
                // targettime = workingdays(DateTime.Now.ToString, 3)
                // Case "Appt - 28 Days"
                // targettime = workingdays(DateTime.Now.ToString, 28)
                // End Select
            }

            var Contract247 = new List<int>();
            Contract247.AddRange(new[] { 67353, 68032, 68376 });
            if (CurrentContract is object && Contract247.Contains(CurrentContract.ContractTypeID))
            {
                targettime = Conversions.ToDate(DateTime.Now.AddHours(24).ToString("yyyy-MM-dd") + " 18:00"); // end of next day
            }
            else if (CurrentContract is object)
            {
                targettime = Conversions.ToDate(Conversions.ToDate(workingdays(Conversions.ToString(DateTime.Now), 1)).ToString("yyyy-MM-dd") + " 18:00"); // end of next WORKING day
            }

            AppointmentsView.Table.Columns.Add("InTarget");
            foreach (DataRow dr in AppointmentsView.Table.Rows)
            {
                DateTime t1 = Conversions.ToDate(dr["Date"] + " 12:00");
                if (t1 < targettime)
                {
                    dr["InTarget"] = "1";
                }
                else
                {
                    dr["InTarget"] = "0";
                }
            }

            // '''''''''''''''''''''just for schedulers'''''''''''''''''''''

            levelsList = new List<int>();
            int co1 = 0;
            var dd1 = App.DB.Customer.Requirements_Get_For_CustomerID(CurrentCustomer.CustomerID).Table.Select("tick = 1");
            foreach (DataRow d in dd1)
            {
                levelsList.Add(Conversions.ToInteger(d["ManagerID"]));
                co1 += 1;
            }

            if (co1 == 0)
            {
                levelsList.Add(69697);
            }

            /// pull in the schedulers
            Schedulerapps.Columns.Add("AssignedArea");
            Schedulerapps = App.DB.EngineerVisits.Get_Appointments_Scheduler(dtpFromDate.Value.ToString("yyyy-MM-dd HH:mm"), reqtime);
            Schedulerapps = AppointmentStrip(ref Schedulerapps, (List<int>)levelsList, true); // still strip postcodes but keep weekends regardless
            var SchedulerAppsView = new DataView();
            Schedulerapps.TableName = "SchAppointments";
            SchedulerAppsView.Table = Schedulerapps;
            SchedulerAppsView.Table.Columns.Add("InTarget");
            foreach (DataRow dr in SchedulerAppsView.Table.Rows)
            {
                DateTime t1 = Conversions.ToDate(dr["Date"] + " 12:00");
                if (t1 < targettime)
                {
                    dr["InTarget"] = "1";
                }
                else
                {
                    dr["InTarget"] = "0";
                }
            }

            string secFilter = "";
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboEngineer)) > 0)
            {
                secFilter = " AND EngineerID = " + Combo.get_GetSelectedItemValue(cboEngineer);
            }

            if (!SecondVisit)
            {
                var switchExpr = Combo.get_GetSelectedItemValue(cboAppointment);
                switch (switchExpr)
                {
                    case var @case when @case == Conversions.ToString(Enums.AppointmentsPicklist.FirstCall):
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND EightAMAvail = 1 AND remainingAM >= " + reqtime + secFilter;
                            break;
                        }

                    case var case1 when case1 == Conversions.ToString(Enums.AppointmentsPicklist.Am):
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND remainingAM >= " + reqtime + secFilter;
                            break;
                        }

                    case var case2 when case2 == Conversions.ToString(Enums.AppointmentsPicklist.Pm):
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND remainingPM >= " + reqtime + secFilter;
                            break;
                        }

                    case var case3 when case3 == Conversions.ToString(Enums.AppointmentsPicklist.EightAmTillTwelvePm): // 8 - 12
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [EIGHT_TWELVE] >= " + reqtime + secFilter;
                            break;
                        }

                    case var case4 when case4 == Conversions.ToString(Enums.AppointmentsPicklist.TenAmTillTwoPm): // 10- 2
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TEN_TWO] >= " + reqtime + secFilter;
                            break;
                        }

                    case var case5 when case5 == Conversions.ToString(Enums.AppointmentsPicklist.TwelvePmTillFourPm): // 12- 4
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TWELVE_FOUR] >= " + reqtime + secFilter;
                            break;
                        }

                    case var case6 when case6 == Conversions.ToString(Enums.AppointmentsPicklist.TwoPmTillSixPm): // 2 - 6
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TWO_SIX] >= " + reqtime + secFilter;
                            break;
                        }

                    default:
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "#" + secFilter;
                            break;
                        }
                }
            }
            else  // second visit try to lock the engineer ///////// TODO ////////////
            {
                var switchExpr1 = Combo.get_GetSelectedItemValue(cboAppointment);
                switch (switchExpr1)
                {
                    case var case7 when case7 == Conversions.ToString(Enums.AppointmentsPicklist.FirstCall):
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND EightAMAvail = 1 AND remainingAM >= " + reqtime + secFilter;
                            break;
                        }

                    case var case8 when case8 == Conversions.ToString(Enums.AppointmentsPicklist.Am):
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND remainingAM >= " + reqtime + secFilter;
                            break;
                        }

                    case var case9 when case9 == Conversions.ToString(Enums.AppointmentsPicklist.Pm):
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND remainingPM >= " + reqtime + secFilter;
                            break;
                        }

                    case var case10 when case10 == Conversions.ToString(Enums.AppointmentsPicklist.EightAmTillTwelvePm): // 8 - 12
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [EIGHT_TWELVE] >= " + reqtime + secFilter;
                            break;
                        }

                    case var case11 when case11 == Conversions.ToString(Enums.AppointmentsPicklist.TenAmTillTwoPm): // 10- 2
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TEN_TWO] >= " + reqtime + secFilter;
                            break;
                        }

                    case var case12 when case12 == Conversions.ToString(Enums.AppointmentsPicklist.TwelvePmTillFourPm): // 12- 4
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TWELVE_FOUR] >= " + reqtime + secFilter;
                            break;
                        }

                    case var case13 when case13 == Conversions.ToString(Enums.AppointmentsPicklist.TwoPmTillSixPm): // 2 - 6
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "# AND [TWO_SIX] >= " + reqtime + secFilter;
                            break;
                        }

                    default:
                        {
                            AppointmentsView.RowFilter = "Date>= #" + dtpFromDate.Value.ToString("yyyy-MM-dd") + "#" + secFilter;
                            break;
                        }
                }
            }

            // If rbANY.Checked Or rbALL.Checked Then
            // '
            // End If

            AppointmentsView.Table.Columns.Add("AMCLOSE");
            AppointmentsView.Table.Columns.Add("PMCLOSE");
            AppointmentsView.Table.Columns.Add("COMBCLOSE");
            AppointmentsView.Table.Columns.Add("ORIGAMCLOSE");
            AppointmentsView.Table.Columns.Add("ORIGPMCLOSE");
            // ''''''''''''''''''''''''''In Area Shit ''''''''''''''''''''''''''''''''

            foreach (DataRow dr in AppointmentsView.Table.Rows)
            {
                if (!Information.IsDBNull(dr["AMLatitude"]) & !Information.IsDBNull(CurrentSite.Latitude) & Conversions.ToDouble(CurrentSite.Latitude) != 0.0)
                {
                    double d = distance(Conversions.ToDouble(dr["AMLatitude"]), Conversions.ToDouble(dr["AMLongitude"]), Conversions.ToDouble(CurrentSite.Latitude), Conversions.ToDouble(CurrentSite.Longitude), 'M');
                    dr["AMCLOSE"] = d;
                    dr["ORIGAMCLOSE"] = Math.Round(d, 2);
                }
                else
                {
                    dr["AMCLOSE"] = DBNull.Value;
                }

                if (!Information.IsDBNull(dr["PMLatitude"]) & !Information.IsDBNull(CurrentSite.Latitude) & Conversions.ToDouble(CurrentSite.Latitude) != 0.0)
                {
                    double d2 = distance(Conversions.ToDouble(dr["PMLatitude"]), Conversions.ToDouble(dr["PMLongitude"]), Conversions.ToDouble(CurrentSite.Latitude), Conversions.ToDouble(CurrentSite.Longitude), 'M');
                    dr["PMCLOSE"] = d2;
                    dr["ORIGPMCLOSE"] = Math.Round(d2, 2);
                }
                else
                {
                    dr["PMCLOSE"] = DBNull.Value;
                }

                if (Information.IsDBNull(dr["ORIGPMCLOSE"]) || Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["ORIGPMCLOSE"], "", false)))
                    dr["ORIGPMCLOSE"] = "Unknown";
                if (Information.IsDBNull(dr["ORIGAMCLOSE"]) || Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["ORIGAMCLOSE"], "", false)))
                    dr["ORIGAMCLOSE"] = "Unknown";
                if (Information.IsDBNull(dr["AMCLOSE"]) & Information.IsDBNull(dr["PMCLOSE"]))
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["AssignedArea"], 1, false)))
                    {
                        dr["AMCLOSE"] = 9;
                        dr["PMCLOSE"] = 9;
                    }
                    else
                    {
                        dr["AMCLOSE"] = 21;
                        dr["PMCLOSE"] = 21;
                    }
                }
                else if (Information.IsDBNull(dr["AMCLOSE"]))
                {
                    dr["AMCLOSE"] = dr["PMCLOSE"] - Conversions.ToInteger(8);
                }
                else if (Information.IsDBNull(dr["PMCLOSE"]))
                {
                    dr["PMCLOSE"] = dr["AMCLOSE"] - Conversions.ToInteger(8);
                }

                dr["COMBCLOSE"] = Conversions.ToInteger(dr["PMCLOSE"]) + Conversions.ToInteger(dr["AMCLOSE"]);
            }

            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            // ''''''''''''''''''''''''''''SCORING SECTION'''''''''''''''''''''''''''''''

            foreach (DataRowView row in AppointmentsView)
            {
                int score = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(row["Date"]), dtpFromDate.Value) * 4); // multiply to increase effect
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["AssignedArea"], 1, false)))
                    score = score + 25;
                score = (int)(score + DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(row["Date"]), DateAndTime.Now.Date) * 2); // general time score - sooner the better
                if ((jobtype ?? "") == "SERVICE" | SecondVisit)  // '' assume second visit is service
                {
                    score += 30;
                    score = Conversions.ToInteger(score + row["ServPri"] * -1);
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["ServPri"], 0, false)))
                    {
                        score += -1000;
                    }
                }
                else if ((jobtype ?? "") == "BREAKDOWN")
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["InTarget"], 1, false)))
                        score = score + 50;
                    score = (int)(score + DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(row["Date"]), targettime) * 2);
                    score = Conversions.ToInteger(score + row["BreakPri"] * -1);
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["BreakPri"], 0, false)))
                    {
                        score += -1000;
                    }
                }

                score = Conversions.ToInteger(score + row["COMBCLOSE"] * -1 * 2); // the further away the more it deducts
                row["SCORE"] = score;
            }

            // multiday checks

            int days = 0;
            txtHrs.Text = txtHrs.Text.Length == 0 ? "0" : txtHrs.Text;
            txtDays.Text = txtDays.Text.Length == 0 ? "0" : txtDays.Text;
            if (Conversions.ToDouble(txtDays.Text) > 0 && Conversions.ToDouble(txtHrs.Text) > 0)
            {
                days = Conversions.ToInteger(txtDays.Text) + 1;
            }

            var engCollection = new List<int>();
            var appointmentstableCopy = AppointmentsView.Table.Copy();
            if (Conversions.ToInteger(txtHrs.Text) > 8 | Conversions.ToInteger(txtDays.Text) > 0)
            {
                foreach (DataRow dr in AppointmentsView.Table.Rows) // Fucked up way of getting unique values
                {
                    if (engCollection.Contains(Conversions.ToInteger(dr["EngineerID"])))
                    {
                    }
                    else
                    {
                        engCollection.Add(Conversions.ToInteger(dr["EngineerID"]));
                    }
                }

                foreach (int ii in engCollection)
                {
                    if (App.DB.EngineerVisits.Get_Appointments_ForEngineer(dtpFromDate.Value.ToString("yyyy-MM-dd"), 120, ii, days).Rows.Count == days)
                    {
                    }
                    // pass
                    else
                    {
                        var drs = appointmentstableCopy.Select("EngineerID = " + ii);
                        foreach (DataRow dr in drs)
                            appointmentstableCopy.Rows.Remove(dr);
                    }
                }

                AppointmentsView.Table = appointmentstableCopy;
            }

            // '''' SORTING

            AppointmentsView.Sort = "Score DESC";
            if ((jobtype ?? "") == "SERVICE")
            {
            }
            // AppointmentsView.Sort = "InTarget DESC,AssignedArea DESC, ServPri ASC, COMBCLOSE ASC, AMCLOSE ASC, PMCLOSE ASC, daynumber ASC ,cbuoc ASC, TotalRemaining DESC, RemainingAM DESC,RemainingPM DESC"
            else
            {
                // AppointmentsView.Sort = "InTarget DESC,AssignedArea DESC, BreakPri ASC, COMBCLOSE ASC, AMCLOSE ASC, PMCLOSE ASC, daynumber ASC ,cbuoc ASC, TotalRemaining DESC, RemainingAM DESC,RemainingPM DESC"
            }

            SchedulerAppsView.Sort = "InTarget Desc, daynumber asc, TotalRemaining DESC, RemainingAM ASC,RemainingPM ASC";
            var buttons = new[] { btnOption1, btnOption2, btnOption3, btnOption4, btnOption5, btnOption6, btnOption7, btnOption8, btnOption10 };
            int buts = 0;
            int c = 0;
            int i = 0;
            // For i As Integer = 0 To 4 ' appoints - 1

            while (c < AppointmentsView.Count)
            {
                if (i == 8)
                    break;
                string detail = "";
                string aa = "";
                string callo = "";
                string target = "";
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(AppointmentsView[c]["AssignedArea"], 1, false)))
                {
                    aa = "Yes";
                }
                else
                {
                    aa = "No";
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(AppointmentsView[c]["cbuoc"], 1, false)))
                {
                    callo = "Yes";
                }
                else
                {
                    callo = "No";
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(AppointmentsView[c]["InTarget"], 1, false)))
                {
                    target = "Yes";
                }
                else
                {
                    target = "No";
                }

                // code will stop offering 8AM's if its today
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(AppointmentsView[c]["EightAMAvail"], "1", false) & AppointmentsView[c]["remainingAM"] >= reqtime & Conversions.ToDate(Conversions.ToDate(AppointmentsView[c]["Date"]).ToString("dd/MM/yyyy") + " 00:00") > Conversions.ToDate(DateTime.Today.ToString("dd/MM/yyyy") + " 08:00")))  // ' can offer 8AM
                {
                    detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGAMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                    if (Conversions.ToBoolean(AppointmentsView[c]["AMCLOSE"] < 22))
                    {
                        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 69938 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 0)
                        {
                            buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 8AM");
                            buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^8AM" + "^" + detail;
                            buttons[i].Visible = true;
                            var argbutton = buttons[i];
                            DoButtonColor(AppointmentsView[c], targettime, ref argbutton);
                            buttons[i].Refresh();
                            i = i + 1;
                            buts = buts + 1;
                            if (i == 8)
                                break;
                        }
                    }
                }

                // anytime
                if (Conversions.ToBoolean(AppointmentsView[c]["remainingAM"] >= reqtime & AppointmentsView[c]["remainingPM"] >= reqtime & AppointmentsView[c]["AMCLOSE"] < 22 & AppointmentsView[c]["PMCLOSE"] < 22)) // ' can offer am or pm
                {
                    if (DateTime.Now.Hour > 9 & (Conversions.ToDate(AppointmentsView[c]["Date"]).ToString("dd/MM/yyyy") ?? "") == (DateAndTime.Today.ToString("dd/MM/yyyy") ?? ""))  // its too late to book mornings
                    {
                    }

                    // nope
                    else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 69943 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 0)
                    {
                        detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGAMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " AM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^AM" + "^" + detail;
                        buttons[i].Visible = true;
                        // give a chance in hell

                        var argbutton1 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton1);
                        buttons[i].Refresh();
                        i = i + 1;
                        buts = buts + 1;
                        if (i == 8)
                            break;
                    }

                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 69944 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 0)
                    {
                        detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGPMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                        buts = buts + 1;
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " PM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^PM" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton2 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton2);
                        buttons[i].Refresh();
                        i = i + 1;
                    }

                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 69945)
                    {
                        buts = buts + 1;
                        detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGPMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " ANYTIME");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^ANY" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton3 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton3);
                        buttons[i].Refresh();
                        i = i + 1;
                    }

                    if (Conversions.ToBoolean(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == (double)69939 & AppointmentsView[c]["EIGHT_TWELVE"] >= reqtime))
                    {
                        detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGAMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                        buts = buts + 1;
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 8AM - 12PM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^8-12" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton4 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton4);
                        buttons[i].Refresh();
                        i = i + 1;
                    }

                    if (Conversions.ToBoolean(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == (double)69940 & AppointmentsView[c]["TEN_TWO"] >= reqtime))
                    {
                        detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGPMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                        buts = buts + 1;
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 10AM - 2PM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^10-2" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton5 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton5);
                        buttons[i].Refresh();
                        i = i + 1;
                    }

                    if (Conversions.ToBoolean(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == (double)69941 & AppointmentsView[c]["TWELVE_FOUR"] >= reqtime))
                    {
                        detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGPMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                        buts = buts + 1;
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 12PM - 4PM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^12-4" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton6 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton6);
                        buttons[i].Refresh();
                        i = i + 1;
                    }

                    if (Conversions.ToBoolean(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == (double)69942 & AppointmentsView[c]["TWO_SIX"] >= reqtime))
                    {
                        buts = buts + 1;
                        detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGPMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 2PM - 6PM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^2-6" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton7 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton7);
                        buttons[i].Refresh();
                        i = i + 1;
                    }
                }

                // AM
                else if (Conversions.ToBoolean(AppointmentsView[c]["remainingAM"] >= reqtime & AppointmentsView[c]["AMCLOSE"] < 22))  // ' offer AM
                {
                    if (DateTime.Today.Hour > 9 & (Conversions.ToDate(AppointmentsView[c]["Date"]).ToString("dd/MM/yyyy") ?? "") == (DateAndTime.Today.ToString("dd/MM/yyyy") ?? ""))  // its too late to book mornings
                    {
                    }

                    // nope
                    else
                    {
                        detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGAMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 69943 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 0)
                        {
                            buts = buts + 1;
                            buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " AM");
                            buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^AM" + "^" + detail;
                            buttons[i].Visible = true;
                            var argbutton13 = buttons[i];
                            DoButtonColor(AppointmentsView[c], targettime, ref argbutton13);
                            buttons[i].Refresh();
                            i = i + 1;
                        }

                        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 69945)
                        {
                            buts = buts + 1;
                            buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " ANYTIME");
                            buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^ANY" + "^" + detail;
                            buttons[i].Visible = true;
                            var argbutton14 = buttons[i];
                            DoButtonColor(AppointmentsView[c], targettime, ref argbutton14);
                            buttons[i].Refresh();
                            i = i + 1;
                        }

                        if (Conversions.ToBoolean(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == (double)69939 & AppointmentsView[c]["EIGHT_TWELVE"] >= reqtime))
                        {
                            buts = buts + 1;
                            buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 8AM - 12PM");
                            buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^8-12" + "^" + detail;
                            buttons[i].Visible = true;
                            var argbutton15 = buttons[i];
                            DoButtonColor(AppointmentsView[c], targettime, ref argbutton15);
                            buttons[i].Refresh();
                            i = i + 1;
                        }

                        if (Conversions.ToBoolean(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == (double)69940 & AppointmentsView[c]["TEN_TWO"] >= reqtime))
                        {
                            buts = buts + 1;
                            buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 10AM - 2PM");
                            buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^10-2" + "^" + detail;
                            buttons[i].Visible = true;
                            var argbutton16 = buttons[i];
                            DoButtonColor(AppointmentsView[c], targettime, ref argbutton16);
                            buttons[i].Refresh();
                            i = i + 1;
                        }
                    }
                }
                else if (Conversions.ToBoolean(AppointmentsView[c]["remainingPM"] >= reqtime & AppointmentsView[c]["PMCLOSE"] < 22))  // ' Offer PM
                {
                    detail = Conversions.ToString("Distance : " + AppointmentsView[c]["ORIGPMCLOSE"] + "  Area Engineer : " + aa + "  On Call Engineer : " + callo + "  In Target : " + target);
                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 69944 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 0)
                    {
                        buts = buts + 1;
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " PM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^PM" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton8 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton8);
                        buttons[i].Refresh();
                        i = i + 1;
                    }

                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == 69945)
                    {
                        buts = buts + 1;
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " ANYTIME");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^ANY" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton9 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton9);
                        buttons[i].Refresh();
                        i = i + 1;
                    }

                    if (Conversions.ToBoolean(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == (double)69940 & AppointmentsView[c]["TEN_TWO"] >= reqtime))
                    {
                        buts = buts + 1;
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 10AM - 2PM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^10-2" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton10 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton10);
                        buttons[i].Refresh();
                        i = i + 1;
                    }

                    if (Conversions.ToBoolean(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == (double)69941 & AppointmentsView[c]["TWELVE_FOUR"] >= reqtime))
                    {
                        buts = buts + 1;
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 12PM - 4PM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^12-4" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton11 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton11);
                        buttons[i].Refresh();
                        i = i + 1;
                    }

                    if (Conversions.ToBoolean(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) == (double)69942 & AppointmentsView[c]["TWO_SIX"] >= reqtime))
                    {
                        buts = buts + 1;
                        buttons[i].Text = Conversions.ToString(Conversions.ToString(AppointmentsView[c]["name"] + Constants.vbNewLine) + AppointmentsView[c]["Date"] + " 2PM - 6PM");
                        buttons[i].Tag = Conversions.ToString(AppointmentsView[c]["EngineerID"] + "^") + AppointmentsView[c]["Date"] + "^2-6" + "^" + detail;
                        buttons[i].Visible = true;
                        var argbutton12 = buttons[i];
                        DoButtonColor(AppointmentsView[c], targettime, ref argbutton12);
                        buttons[i].Refresh();
                        i = i + 1;
                    }
                }

                // buttons(i).Text = AppointmentsView.Table.Rows(i)("name") & vbNewLine & AppointmentsView.Table.Rows(i)("Date") & " " & AppointmentsView.Table.Rows(i)("TimeOfDay")
                // buttons(i).Tag = AppointmentsView.Table.Rows(i)("EngineerID") & "^" & AppointmentsView.Table.Rows(i)("Date") & "^" & AppointmentsView.Table.Rows(i)("TimeOfDay")
                c = c + 1;
            }

            int appoints = buts;
            if (buts < 8)
            {
                appoints = buts;
                int c1 = 0;
                foreach (Button bt in buttons)
                {
                    c1 = c1 + 1;
                    if (c1 > appoints)
                    {
                        bt.Visible = false;
                    }
                }
            }

            var fail = default(bool);
            var appointmentperiod = default(string);
            var switchExpr2 = Combo.get_GetSelectedItemValue(cboAppointment);
            switch (switchExpr2)
            {
                case var case14 when case14 == Conversions.ToString(Enums.AppointmentsPicklist.FirstCall):
                    {
                        if ((DateAndTime.Today.ToString("tt") ?? "") == "PM")
                        {
                            appointmentperiod = "PM";
                        }
                        else
                        {
                            appointmentperiod = "AM";
                        }

                        break;
                    }

                case var case15 when case15 == Conversions.ToString(Enums.AppointmentsPicklist.Am):
                    {
                        if ((DateAndTime.Today.ToString("tt") ?? "") == "PM")
                        {
                            appointmentperiod = "PM";
                        }
                        else
                        {
                            appointmentperiod = "AM";
                        }

                        break;
                    }

                case var case16 when case16 == Conversions.ToString(Enums.AppointmentsPicklist.Pm):
                    {
                        appointmentperiod = "PM";
                        break;
                    }

                case var case17 when case17 == Conversions.ToString(Enums.AppointmentsPicklist.EightAmTillTwelvePm): // 8 - 12
                    {
                        if ((DateAndTime.Today.ToString("tt") ?? "") == "PM")
                        {
                            appointmentperiod = "12PM - 4PM";
                        }
                        else
                        {
                            appointmentperiod = "8AM - 12PM";
                        }

                        break;
                    }

                case var case18 when case18 == Conversions.ToString(Enums.AppointmentsPicklist.TenAmTillTwoPm): // 10- 2
                    {
                        if ((DateAndTime.Today.ToString("tt") ?? "") == "PM")
                        {
                            appointmentperiod = "12PM - 4PM";
                        }
                        else
                        {
                            appointmentperiod = "10AM - 2PM";
                        }

                        break;
                    }

                case var case19 when case19 == Conversions.ToString(Enums.AppointmentsPicklist.TwelvePmTillFourPm): // 12- 4
                    {
                        appointmentperiod = "12PM - 4PM";
                        break;
                    }

                case var case20 when case20 == Conversions.ToString(Enums.AppointmentsPicklist.TwoPmTillSixPm): // 2 - 6
                    {
                        appointmentperiod = "2PM - 6PM";
                        break;
                    }

                case var case21 when case21 == Conversions.ToString(Enums.AppointmentsPicklist.Anytime):
                    {
                        appointmentperiod = "ANYTIME";
                        break;
                    }
            }

            foreach (DataRowView dr in SchedulerAppsView)
            {
                if (Conversions.ToDate(dr["Date"]) >= Conversions.ToDate(DateTime.Now.AddHours(8).ToString("dd/MM/yyyy")))
                {
                    if ((Conversions.ToDate(dr["Date"]).ToString("dd/MM/yyyy") ?? "") == (targettime.ToString("dd/MM/yyyy") ?? ""))
                    {
                        // If dr("RemainingAM") < reqtime And targettime.ToString("tt") = "AM" Then 'No AM appointment
                        // fail = True
                        // Else
                        // all ok
                        buttons[appoints].Text = Conversions.ToString(dr["name"] + Constants.vbNewLine + Conversions.ToDate(dr["Date"]).ToString("dd/MM/yyyy") + " " + appointmentperiod);
                        buttons[appoints].Tag = dr["EngineerID"] + "^" + Conversions.ToDate(dr["Date"]).ToString("dd/MM/yyyy") + "^" + appointmentperiod;
                        buttons[appoints].Visible = true;
                        if ((Conversions.ToDate(dr["Date"]).ToString("dd/MM/yyyy") ?? "") == (targettime.ToString("dd/MM/yyyy") ?? "") & Conversions.ToDate(dr["Date"] + " 18:00") < targettime | (Conversions.ToDate(dr["Date"]).ToString("dd/MM/yyyy") ?? "") == (DateAndTime.Today.ToString("dd/MM/yyyy") ?? "") & (DateAndTime.Today.ToString("tt") ?? "") == "PM")
                        {
                            buttons[appoints].BackColor = Color.Coral;
                        }
                        else if (Conversions.ToDate(dr["Date"] + " 12:00") < targettime)
                        {
                            buttons[appoints].BackColor = Color.PaleGreen;
                        }
                        else
                        {
                            buttons[appoints].BackColor = Color.Red;
                        }

                        fail = false;
                        break;
                    }
                    // End If
                    else // CDate(dr("Date")) < targettime Then
                    {
                        // all ok
                        buttons[appoints].Text = Conversions.ToString(SchedulerAppsView[0]["name"] + Constants.vbNewLine + Conversions.ToDate(dr["Date"]).ToString("dd/MM/yyyy") + " " + appointmentperiod);
                        buttons[appoints].Tag = SchedulerAppsView[0]["EngineerID"] + "^" + Conversions.ToDate(dr["Date"]).ToString("dd/MM/yyyy") + "^" + appointmentperiod;
                        buttons[appoints].Visible = true;
                        if ((Conversions.ToDate(dr["Date"]).ToString("dd/MM/yyyy") ?? "") == (targettime.ToString("dd/MM/yyyy") ?? "") & Conversions.ToDate(dr["Date"] + " 18:00") < targettime | (Conversions.ToDate(dr["Date"]).ToString("dd/MM/yyyy") ?? "") == (DateAndTime.Today.ToString("dd/MM/yyyy") ?? "") & (DateAndTime.Today.ToString("tt") ?? "") == "PM")
                        {
                            buttons[appoints].BackColor = Color.Coral;
                        }
                        else if (Conversions.ToDate(dr["Date"] + " 12:00") < targettime)
                        {
                            buttons[appoints].BackColor = Color.PaleGreen;
                        }
                        else
                        {
                            buttons[appoints].BackColor = Color.Red;
                        }

                        fail = false;
                        break;
                    }
                }

                fail = true;
            }

            if (fail == true)
            {
                buttons[appoints].Visible = false;
            }

            Cursor = Cursors.Default;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        public double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (Conversions.ToString(unit) == "K")
            {
                dist = dist * 1.609344;
            }
            else if (Conversions.ToString(unit) == "N")
            {
                dist = dist * 0.8684;
            }

            return dist;
        }

        private double deg2rad(double deg)
        {
            return deg * Math.PI / 180.0;
        }

        private double rad2deg(double rad)
        {
            return rad / Math.PI * 180.0;
        }

        public DataTable AppointmentStrip(ref DataTable appointments, List<int> levelslist, bool IsScheduler = false)
        {
            var engineerLevels = App.DB.EngineerLevel.GetAllInDate().Table;
            for (int i1 = appointments.Rows.Count - 1; i1 >= 0; i1 -= 1)
            {
                var dr = appointments.Rows[i1];
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["keep"], 0, false) & Operators.ConditionalCompareObjectEqual(dr["remove"], 0, false)))
                {
                    // ' remove non qualified engineers

                    // Dim engineerLevels As DataTable = DB.EngineerLevel.Get(dr("EngineerID")).Table
                    bool removeengineer = true;
                    bool AssignedArea = true;
                    bool cbuoc = false;
                    foreach (int i in levelslist)
                    {
                        foreach (DataRow dr2 in engineerLevels.Select(Conversions.ToString("EngineerID = " + dr["EngineerID"])))
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr2["ManagerID"], 69698, false))) // hes on call and avaialble
                            {
                                cbuoc = true;
                            }

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(i, dr2["ManagerID"], false)))
                            {
                                removeengineer = false;
                                break;
                            }

                            removeengineer = true;
                        }

                        if (removeengineer == true)
                            break;
                    }

                    if ((jobtype ?? "") == "SERVICE")
                    {
                        if (!Information.IsDBNull(dr["ServPri"]) && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["ServPri"], "10", false))) // And Not IsScheduler Then
                        {
                            removeengineer = true;
                        }
                    }
                    else if ((jobtype ?? "") == "BREAKDOWN")
                    {
                        if (!Information.IsDBNull(dr["BreakPri"]) && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["BreakPri"], "10", false))) // And Not IsScheduler Then
                        {
                            removeengineer = true;
                        }
                    }

                    if (cbuoc && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["ONCALL"], 1, false)))
                    {
                        dr["cbuoc"] = 1;
                    }

                    if (removeengineer == false)
                    {
                        removeengineer = true; // will remove unless
                        if (IsScheduler)
                        {
                            removeengineer = true;
                        }
                        else
                        {
                            AssignedArea = false;
                            removeengineer = false;
                        }

                        var engpostcodes = new List<string>();
                        var dt = App.DB.EngineerPostalRegion.GetTicked(Conversions.ToInteger(dr["EngineerID"])).Table;
                        foreach (DataRow row in dt.Rows)
                            engpostcodes.Add(Conversions.ToString(row["Name"]));
                        if (engpostcodes.Contains(CurrentSite.Postcode.Substring(0, CurrentSite.Postcode.IndexOf("-"))))
                        {
                            if (IsScheduler)
                            {
                                removeengineer = false;
                            }
                            else
                            {
                                AssignedArea = true;
                                removeengineer = false;
                            }
                        }
                    }

                    if (cbuoc)
                    {
                        foreach (DataRow dr3 in appointments.Select(Conversions.ToString("engineerid = " + dr["EngineerID"] + " AND ONCALL = 0")))   // dont remove the oncall engineer days
                        {
                            if (removeengineer)
                            {
                                dr3["remove"] = 1;
                            }
                            else
                            {
                                dr3["keep"] = 1;
                                if (AssignedArea == false)
                                {
                                    dr3["AssignedArea"] = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow dr3 in appointments.Select(Conversions.ToString("engineerid = " + dr["EngineerID"])))
                        {
                            if (removeengineer)
                            {
                                dr3["remove"] = 1;
                            }
                            else
                            {
                                dr3["keep"] = 1;
                                if (AssignedArea == false)
                                {
                                    dr3["AssignedArea"] = 0;
                                }
                            }
                        }
                    }
                } // end of if that checks if its already been marked to be deleted
            }

            var dtr = appointments.Select("remove = 1  AND CBUOC = 0");
            foreach (DataRow dr9 in dtr)  // remove the engineers not eligable
                appointments.Rows.Remove(dr9);
            var Contract247 = new List<int>();
            Contract247.AddRange(new[] { 67353, 68032, 68376 });

            // Saturdays / bank holidays - FOR EM AND PLAT OR RECALL

            bool includeweekends = false;
            var dt2 = App.DB.Customer.Priorities_Get_For_CustomerID_Active(CurrentCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPriority))).Table;
            if (dt2.Rows.Count == 1)
            {
                var dr1 = dt2.Rows[0];
                includeweekends = Conversions.ToBoolean(dr1["IncludeWeekends"]);
            }

            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPriority)) == 66983 | includeweekends || CurrentContract is object && Contract247.Contains(CurrentContract.ContractTypeID) || chkRecall.Checked)
            {
            }

            // remove unless its the scheduler or a on call engineer

            // For Each dr10 As DataRow In appointments.Select("1=1")
            // If (CDate(dr10("thedate")).DayOfWeek = DayOfWeek.Saturday OrElse CDate(dr10("thedate")).DayOfWeek = DayOfWeek.Sunday OrElse dr10("BH") = 1) And IsScheduler = False And dr10("cbuoc") = 0 Then
            // appointments.Rows.Remove(dr10)
            // End If

            // Next
            else
            {
                // remove BH and saturdays
                foreach (DataRow dr10 in appointments.Select("1=1"))
                {
                    if (Conversions.ToDate(dr10["thedate"]).DayOfWeek == DayOfWeek.Saturday || Conversions.ToDate(dr10["thedate"]).DayOfWeek == DayOfWeek.Sunday || Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr10["BH"], 1, false)))
                    {
                        appointments.Rows.Remove(dr10);
                    }
                }
            }

            return appointments;
        }

        public string workingdays(string Startdate, int Workingdaysin)
        {
            object count = 0;
            var dvBankHolidays = App.DB.TimeSlotRates.BankHolidays_GetAll();
            for (int i = 0, loopTo = Workingdaysin; i <= loopTo; i++)
            {
                count = count + 1;
                var weekday = Conversions.ToDate(Startdate).AddDays(Conversions.ToDouble(count)).DayOfWeek;
                if (dvBankHolidays.Table.Select("BankHolidayDate='" + Conversions.ToDate(Strings.Format(Conversions.ToDate(Startdate).AddDays(Conversions.ToDouble(count)), "dd/MM/yyyy")) + "'").Length > 0)
                {
                }
                else if (weekday == DayOfWeek.Saturday | weekday == DayOfWeek.Sunday)
                {
                }
                else
                {
                    i = i + 1;
                }
            }

            return Conversions.ToDate(Startdate).AddDays(Conversions.ToDouble(count)).ToString();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int tab = 1;

        private void btnxx1_Click(object sender, EventArgs e)
        {
            tab = tcSites.SelectedIndex - 1;
            tcSites.SelectedTab = tcSites.TabPages[tab];
            Temp.Clear();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            FindAppointments();
        }

        private void cboAppointment_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tcSites.TabPages.Contains(TabBook))
            {
                FindAppointments();
            }
        }

        private void DoButtonColor(DataRowView dr, DateTime targettime, ref Button button)
        {
            if (Conversions.ToInteger(dr["SCORE"]) > 10)
            {
                button.BackColor = Color.PaleGreen;
            }
            else if (Conversions.ToInteger(dr["SCORE"]) > -10)
            {
                button.BackColor = Color.Coral;
            }
            else
            {
                button.BackColor = Color.Red;
            }
        }

        private void cboEngineer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If Combo.GetSelectedItemValue(cboEngineer) > 0 Then
            if (tab > 4)
            {
                FindAppointments();
            }

            // End If
        }

        public void ClearSiteDetails()
        {
            DGVSites.DataSource = null;
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtPostcode.Text = "";
            txtCustomer.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtMob.Text = "";
            txtSurname.Text = "";
            txtTel.Text = "";
            chkCert.Visible = false;
            chkCert.Checked = false;
            lblcert.Visible = false;
            txtAdditional.Text = "";
            CurrentContract = null;
            txtContractRef.Text = "";
            txtName.Text = "";
            txtPONumber.Text = "";
            txtSiteNotes.Text = "";
            var argcombo = cboTitle;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            DGVSites.DataSource = null;
        }

        public void Reset()
        {
            // For Each dr As DataRow In DTPrivNotes.Select("JobNoteID = 0")

            // DB.Job.SaveJobNotes(0, dr("Note"), dr("EditedByUserID"), CurrentJob.JobID, dr("CreatedByUserID")).ToTable()

            // Next

            btnxxNewJob.BackColor = SystemColors.Control;
            cbotypeWiz.BackColor = SystemColors.Window;
            txtHrs.Text = "";
            txtDays.Text = "";
            btnxxExistingJobNext.Visible = false;
            btnxxJobNext.Visible = false;
            btnxxSiteNext.Visible = false;
            btnxxDetailsNext.Visible = false;
            foreach (Control c in tabJobType.Controls)   // neat way to toggle button colors
            {
                if (c is Button)
                {
                    c.BackColor = SystemColors.Control;
                }
            }

            txtSearch.Text = "";

            // ''''' HERE FOR ANY CLEARING '''''''
            try
            {
                tab = 0;
                tcSites.TabPages[0].Enabled = true;
                tcSites.TabPages.Remove(tabProp);
                tcSites.TabPages.Add(tabProp);
                tcSites.TabPages.Remove(tabExistingJobs);
                tcSites.TabPages.Remove(tabJobType);
                tcSites.TabPages.Remove(tabJobDetails);
                tcSites.TabPages.Remove(tabAppliance);
                tcSites.TabPages.Remove(TabCharging);
                tcSites.TabPages.Remove(tabAdditional);
                tcSites.TabPages.Remove(TabBook);
                tcSites.TabPages.Remove(tcComplete);
                tcSites.SelectedIndex = 0;
                // tcSites.SelectedIndex = 1
                Temp.Clear();
            }
            catch (Exception ex)
            {
                tcSites.SelectedIndex = 0;
            }

            GasConfirmedInBoiler = true;
            var dv = new DataView();
            var dt1 = new DataTable();
            dt1.TableName = "1";
            dt1.Columns.Add("SypID");
            dt1.Columns.Add("Code");
            dt1.Columns.Add("Description");
            dv.Table = dt1;
            SympDataView = dv;
            DGSymptoms.DataSource = dt1;
            SiteChange = false;
            BookingDetail = "";
            visitsBooked = 0;
            try
            {
                var c1 = ParentForm.Controls.Find("btnSaveProg", true);
                Button b = (Button)c1[0];
                b.Visible = false;
                var c2 = ParentForm.Controls.Find("btnPrivateNotes", true);
                Button b2 = (Button)c2[0];
                b2.Visible = false;
            }
            catch (Exception ex)
            {
            }

            RunFilter();
        }

        public void SaveProgress()
        {
            BookingDetail = "";
            visitsBooked += 1;
            if (tab < 5)
            {
                DoCharging();
            }

            CurrentJob = CreateVisits(0, DateTime.MinValue, "", priTime, "", visitsBooked);
            if (chkKeepTogether.Checked & secTime > 0)
            {
                visitsBooked += 1;
                CreateVisits(0, DateTime.MinValue, "", secTime, "", visitsBooked);
                // ElseIf secTime > 0 Then
                // '  jobtype = "SERVICE"    ''''''''''''''''''''''''''''''''''' HARD CODE DODGYNESS
                // FindAppointments(True)   ''' -  lets go round again '''' :)
            }

            lblBookedInfo.Text = BookingDetail + " (Click here to view job)";
            try
            {
                var c1 = ParentForm.Controls.Find("btnSaveProg", true);
                Button b = (Button)c1[0];
                b.Visible = false;
                var c2 = ParentForm.Controls.Find("btnPrivateNotes", true);
                Button b2 = (Button)c2[0];
                b2.Visible = false;
            }
            catch (Exception ex)
            {
            }
            // CreateVisits(0, Date.MinValue, "", 0, 1)
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Notes()
        {
            var f = new FRMPrivNotes();
            f.dt = DTPrivNotes;
            f.ShowDialog();
            DTPrivNotes = f.dt;
            if (tcSites.TabCount == 9) // complete tab
            {
            }

            foreach (DataRow dr in DTPrivNotes.Select("JobNoteID = 0"))
                App.DB.Job.SaveJobNotes(0, Conversions.ToString(dr["Note"]), Conversions.ToInteger(dr["EditedByUserID"]), jobids, Conversions.ToInteger(dr["CreatedByUserID"]));
            DTPrivNotes = App.DB.Job.GetAllJobNotes(CurrentSite.SiteID);
        }

        private void chkKeepTogether_CheckedChanged(object sender, EventArgs e)
        {
            if (tcSites.SelectedIndex == 6)
            {
                FindAppointments();
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button button2 = (Button)sender;
            string detail = "";
            try
            {
                detail = button2.Tag.ToString().Split('^')[3];
            }
            catch (Exception ex)
            {
                detail = "";
            }

            var bfont = new Font("Verdana", 7);
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(detail, bfont, Brushes.Black, Conversions.ToInteger(button2.Width / (double)2), button2.Height - 10, stringFormat);
        }

        private void btnxx_Click(object sender, EventArgs e)
        {
            foreach (Control c in tabJobType.Controls)   // neat way to toggle button colors
            {
                if (c is Button)
                {
                    if ((c.Name ?? "") == (((Button)sender).Name ?? ""))
                    {
                        c.BackColor = Color.PaleGreen;
                        jobtype = c.Text.ToUpper();
                        if (c.Tag is object && c.Tag.ToString().Length > 0)
                        {
                            var argcombo = cbotypeWiz;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(c.Tag));  // set the cbojobtype if there is a tag on the button
                        }

                        btnxxJobNext.Visible = true;
                        if ((c.Name ?? "") == "btnxxSOR")
                        {
                            pnlSOR.Visible = true;
                            jobtype = "SOR";
                            pnlSOR.Visible = true;
                            var argc = cboSOR;
                            Combo.SetUpCombo(ref argc, App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(CurrentCustomer.CustomerID).Table, "CustomerScheduleOfRateID", "Description", Enums.ComboValues.Please_Select);
                            if (DGSOR.RowCount > 0)
                            {
                                if (CurrentSite.PoNumReqd & txtPONumber.Text.Length == 0)
                                {
                                }
                                else if (cboPriority.Items.Count > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPriority)) < 1)
                                {
                                }
                                else
                                {
                                    btnxxJobNext.Visible = true;
                                }
                            }
                            else
                            {
                                btnxxJobNext.Visible = false;
                            }
                        }

                        if ((c.Name ?? "") == "btnxxOther")
                        {
                            btnxxOther.Visible = false;
                            pnlSymptoms.Visible = true;
                            lbltype.Visible = true;
                            cbotypeWiz.Visible = true;
                            cbotypeWiz.BackColor = Color.PaleGreen;
                            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cbotypeWiz)) < 1)
                            {
                                btnxxJobNext.Visible = false;
                            }
                            else
                            {
                                if (CurrentSite.PoNumReqd & txtPONumber.Text.Length == 0)
                                {
                                }
                                else if (cboPriority.Items.Count > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPriority)) < 1)
                                {
                                }
                                else
                                {
                                    btnxxJobNext.Visible = true;
                                }

                                jobtype = Combo.get_GetSelectedItemDescription(cbotypeWiz).ToUpper();
                            }
                        }

                        if ((c.Name ?? "") == "BtnxxService")
                        {
                            pnlSymptoms.Visible = false;
                            chkCert.Checked = true;
                        }

                        if (cboPriority.Items.Count > 1)
                        {
                            lblPriority.Visible = true;
                            cboPriority.Visible = true;
                        }
                        else
                        {
                            lblPriority.Visible = false;
                            cboPriority.Visible = false;
                        }

                        lblAdditional.Visible = true;
                        txtAdditional.Visible = true;
                    }
                    else if ((c.Parent.Name ?? "") == "tabJobType")
                    {
                        c.BackColor = SystemColors.Control;
                        if ((c.Name ?? "") == "btnxxOther")
                        {
                            c.Visible = true;
                            lbltype.Visible = false;
                            cbotypeWiz.Visible = false;
                            cbotypeWiz.BackColor = SystemColors.Window;
                        }

                        if ((c.Name ?? "") == "btnxxSOR")
                        {
                            pnlSOR.Visible = false;
                        }
                    }
                }
            }
        }

        private void cboPayTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPayTerms)) < 1)
            {
                btnxxChargeNext.Visible = false;
            }
            else
            {
                btnxxChargeNext.Visible = true;
            }
            // DoCharging()

            visitcharge1 = Conversions.ToDouble(txtCharge.Text);
            visitterm1 = Combo.get_GetSelectedItemDescription(cboPayTerms);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FindAppointments();
        }

        private void txtDiscountCode_TextChanged(object sender, EventArgs e)
        {
            CheckDiscount();
        }

        private void CheckDiscount()
        {
            PromotionText = "";
            var dr = PromotionsDT.Select("Code = '" + txtDiscountCode.Text + "'");
            if (dr.Length > 0)
            {
                picCross.Visible = false;
                picTick.Visible = true;
                txtCharge.Text = (string)(Conversions.ToDouble(FinalCharge) - Conversions.ToDouble(FinalCharge) * (dr[0]["DiscountPercent"] / 100));
                txtPayInst.Text = Conversions.ToString(FinalText + Constants.vbNewLine + "Promotion Applied: " + dr[0]["PromotionText"] + " = -" + Strings.Format(Conversions.ToDouble(Conversions.ToString(Math.Round(Conversions.ToDouble(FinalCharge) * (dr[0]["DiscountPercent"] / 100), 2))), "C"));
                PromotionText = Conversions.ToString("Promotion Applied: " + dr[0]["PromotionText"] + " = -" + Strings.Format(Conversions.ToDouble(Conversions.ToString(Math.Round(Conversions.ToDouble(FinalCharge) * (dr[0]["DiscountPercent"] / 100), 2))), "C"));
            }
            else
            {
                picCross.Visible = true;
                picTick.Visible = false;
                txtCharge.Text = FinalCharge.ToString();
                txtPayInst.Text = FinalText;
            }

            if (txtDiscountCode.Text.Length == 0)
            {
                picCross.Visible = false;
                picTick.Visible = false;
                txtCharge.Text = FinalCharge.ToString();
                txtPayInst.Text = FinalText;
            }

            txtCharge.Text = Strings.Format(Conversions.ToDouble(txtCharge.Text), "C");
        }

        private void txtAdditional_TextChanged(object sender, EventArgs e)
        {
            ValidateJobDetails();
        }

        private void lblBookedInfo_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMLogCallout), true, new object[] { CurrentJob.JobID, CurrentSite.SiteID, this });
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMDocuments), true, new object[] { Enums.TableNames.tblJob, CurrentJob.JobID, 0, this });
        }

        private void txtSearchSite_MouseClick(object sender, EventArgs e)
        {
            RunFilter();
        }
    }
}