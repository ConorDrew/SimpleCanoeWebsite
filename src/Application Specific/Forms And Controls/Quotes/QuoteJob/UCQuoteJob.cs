using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.CostCentres.Enums;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCQuoteJob : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCQuoteJob() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCQuoteJob_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboQuoteStatus;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.Quote_Status).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = cboJobType;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Not_Applicable);
            var argc2 = cboScheduleOfRatesCategoryID;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.ScheduleRatesCategories).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboVAT;
            Combo.SetUpCombo(ref argc3, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select);
            var argc4 = cboAsbestos;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.Quote_Asbestos).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboAccess;
            Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Enums.PickListTypes.Quote_AccessEquipment).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboElectricalPack;
            Combo.SetUpCombo(ref argc6, DynamicDataTables.Quote_ElectricianPack, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc7 = cboDept;
                        Combo.SetUpCombo(ref argc7, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc8 = cboDept;
                        Combo.SetUpCombo(ref argc8, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }
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
        private Label _lblQuoteStatus;

        internal Label lblQuoteStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuoteStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuoteStatus != null)
                {
                }

                _lblQuoteStatus = value;
                if (_lblQuoteStatus != null)
                {
                }
            }
        }

        private Label _lblQuoteDate;

        internal Label lblQuoteDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuoteDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuoteDate != null)
                {
                }

                _lblQuoteDate = value;
                if (_lblQuoteDate != null)
                {
                }
            }
        }

        private ComboBox _cboQuoteStatus;

        internal ComboBox cboQuoteStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQuoteStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQuoteStatus != null)
                {
                    _cboQuoteStatus.SelectedIndexChanged -= cboQuoteStatus_SelectedIndexChanged;
                }

                _cboQuoteStatus = value;
                if (_cboQuoteStatus != null)
                {
                    _cboQuoteStatus.SelectedIndexChanged += cboQuoteStatus_SelectedIndexChanged;
                }
            }
        }

        private GroupBox _grpJobItems;

        internal GroupBox grpJobItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobItems != null)
                {
                }

                _grpJobItems = value;
                if (_grpJobItems != null)
                {
                }
            }
        }

        private TextBox _txtReference;

        internal TextBox txtReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtReference != null)
                {
                }

                _txtReference = value;
                if (_txtReference != null)
                {
                }
            }
        }

        private ComboBox _cboJobType;

        internal ComboBox cboJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobType != null)
                {
                }

                _cboJobType = value;
                if (_cboJobType != null)
                {
                }
            }
        }

        private Label _lblJobType;

        internal Label lblJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobType != null)
                {
                }

                _lblJobType = value;
                if (_lblJobType != null)
                {
                }
            }
        }

        private Label _lblCustomer;

        internal Label lblCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomer != null)
                {
                }

                _lblCustomer = value;
                if (_lblCustomer != null)
                {
                }
            }
        }

        private TextBox _txtBOC;

        internal TextBox txtBOC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBOC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBOC != null)
                {
                }

                _txtBOC = value;
                if (_txtBOC != null)
                {
                }
            }
        }

        private Label _lblPartsCost;

        internal Label lblPartsCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPartsCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPartsCost != null)
                {
                }

                _lblPartsCost = value;
                if (_lblPartsCost != null)
                {
                }
            }
        }

        private GroupBox _grpParts;

        internal GroupBox grpParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpParts != null)
                {
                }

                _grpParts = value;
                if (_grpParts != null)
                {
                }
            }
        }

        private Button _btnRemovePartProduct;

        internal Button btnRemovePartProduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemovePartProduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemovePartProduct != null)
                {
                    _btnRemovePartProduct.Click -= btnRemovePartProduct_Click;
                }

                _btnRemovePartProduct = value;
                if (_btnRemovePartProduct != null)
                {
                    _btnRemovePartProduct.Click += btnRemovePartProduct_Click;
                }
            }
        }

        private Button _btnFindPart;

        internal Button btnFindPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindPart != null)
                {
                    _btnFindPart.Click -= btnFindPart_Click;
                }

                _btnFindPart = value;
                if (_btnFindPart != null)
                {
                    _btnFindPart.Click += btnFindPart_Click;
                }
            }
        }

        private DataGrid _dgPartsAndProducts;

        internal DataGrid dgPartsAndProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPartsAndProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPartsAndProducts != null)
                {
                }

                _dgPartsAndProducts = value;
                if (_dgPartsAndProducts != null)
                {
                }
            }
        }

        private DateTimePicker _dtpQuoteDate;

        internal DateTimePicker dtpQuoteDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpQuoteDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpQuoteDate != null)
                {
                }

                _dtpQuoteDate = value;
                if (_dtpQuoteDate != null)
                {
                }
            }
        }

        private TextBox _txtSiteName;

        internal TextBox txtSiteName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSiteName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSiteName != null)
                {
                }

                _txtSiteName = value;
                if (_txtSiteName != null)
                {
                }
            }
        }

        private Label _lblProperty;

        internal Label lblProperty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProperty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProperty != null)
                {
                }

                _lblProperty = value;
                if (_lblProperty != null)
                {
                }
            }
        }

        private Label _lblQuoteRef;

        internal Label lblQuoteRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuoteRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuoteRef != null)
                {
                }

                _lblQuoteRef = value;
                if (_lblQuoteRef != null)
                {
                }
            }
        }

        private TextBox _txtCustomerName;

        internal TextBox txtCustomerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomerName != null)
                {
                }

                _txtCustomerName = value;
                if (_txtCustomerName != null)
                {
                }
            }
        }

        private DataGrid _dgScheduleOfRates;

        internal DataGrid dgScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgScheduleOfRates != null)
                {
                }

                _dgScheduleOfRates = value;
                if (_dgScheduleOfRates != null)
                {
                }
            }
        }

        private ComboBox _cboScheduleOfRatesCategoryID;

        internal ComboBox cboScheduleOfRatesCategoryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboScheduleOfRatesCategoryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboScheduleOfRatesCategoryID != null)
                {
                }

                _cboScheduleOfRatesCategoryID = value;
                if (_cboScheduleOfRatesCategoryID != null)
                {
                }
            }
        }

        private Label _lblScheduleOfRatesCategoryID;

        internal Label lblScheduleOfRatesCategoryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblScheduleOfRatesCategoryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblScheduleOfRatesCategoryID != null)
                {
                }

                _lblScheduleOfRatesCategoryID = value;
                if (_lblScheduleOfRatesCategoryID != null)
                {
                }
            }
        }

        private TextBox _txtCode;

        internal TextBox txtCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCode != null)
                {
                }

                _txtCode = value;
                if (_txtCode != null)
                {
                }
            }
        }

        private Label _lblCode;

        internal Label lblCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCode != null)
                {
                }

                _lblCode = value;
                if (_lblCode != null)
                {
                }
            }
        }

        private TextBox _txtDescription;

        internal TextBox txtDescription
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

        internal Label lblDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDescription != null)
                {
                }

                _lblDescription = value;
                if (_lblDescription != null)
                {
                }
            }
        }

        private TextBox _txtPrice;

        internal TextBox txtPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPrice != null)
                {
                }

                _txtPrice = value;
                if (_txtPrice != null)
                {
                }
            }
        }

        private Label _lblPrice;

        internal Label lblPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPrice != null)
                {
                }

                _lblPrice = value;
                if (_lblPrice != null)
                {
                }
            }
        }

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private Button _btnRemove;

        internal Button btnRemove
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemove;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemove != null)
                {
                    _btnRemove.Click -= btnRemove_Click;
                }

                _btnRemove = value;
                if (_btnRemove != null)
                {
                    _btnRemove.Click += btnRemove_Click;
                }
            }
        }

        private Button _btnSiteScheduleOfRates;

        internal Button btnSiteScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSiteScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSiteScheduleOfRates != null)
                {
                    _btnSiteScheduleOfRates.Click -= btnSiteScheduleOfRates_Click;
                }

                _btnSiteScheduleOfRates = value;
                if (_btnSiteScheduleOfRates != null)
                {
                    _btnSiteScheduleOfRates.Click += btnSiteScheduleOfRates_Click;
                }
            }
        }

        private TextBox _txtQuantity;

        internal TextBox txtQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuantity != null)
                {
                }

                _txtQuantity = value;
                if (_txtQuantity != null)
                {
                }
            }
        }

        private Label _lblQuantity;

        internal Label lblQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuantity != null)
                {
                }

                _lblQuantity = value;
                if (_lblQuantity != null)
                {
                }
            }
        }

        private TextBox _txtPartsCost;

        internal TextBox txtPartsCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartsCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartsCost != null)
                {
                    _txtPartsCost.LostFocus -= txtPartsTotal_LostFocus;
                }

                _txtPartsCost = value;
                if (_txtPartsCost != null)
                {
                    _txtPartsCost.LostFocus += txtPartsTotal_LostFocus;
                }
            }
        }

        private Label _lblPartsMarkup;

        internal Label lblPartsMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPartsMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPartsMarkup != null)
                {
                }

                _lblPartsMarkup = value;
                if (_lblPartsMarkup != null)
                {
                }
            }
        }

        private TextBox _txtPartsProductsMarkup;

        internal TextBox txtPartsProductsMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartsProductsMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartsProductsMarkup != null)
                {
                    _txtPartsProductsMarkup.LostFocus -= txtPartsTotal_LostFocus;
                }

                _txtPartsProductsMarkup = value;
                if (_txtPartsProductsMarkup != null)
                {
                    _txtPartsProductsMarkup.LostFocus += txtPartsTotal_LostFocus;
                }
            }
        }

        private Label _lblTotalPartsCharge;

        internal Label lblTotalPartsCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTotalPartsCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTotalPartsCharge != null)
                {
                }

                _lblTotalPartsCharge = value;
                if (_lblTotalPartsCharge != null)
                {
                }
            }
        }

        private TextBox _txtPartsCostTotal;

        internal TextBox txtPartsCostTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartsCostTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartsCostTotal != null)
                {
                }

                _txtPartsCostTotal = value;
                if (_txtPartsCostTotal != null)
                {
                }
            }
        }

        private Label _lblSORCost;

        internal Label lblSORCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSORCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSORCost != null)
                {
                }

                _lblSORCost = value;
                if (_lblSORCost != null)
                {
                }
            }
        }

        private TextBox _txtScheduleRatesCost;

        internal TextBox txtScheduleRatesCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtScheduleRatesCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtScheduleRatesCost != null)
                {
                    _txtScheduleRatesCost.LostFocus -= txtPartsTotal_LostFocus;
                }

                _txtScheduleRatesCost = value;
                if (_txtScheduleRatesCost != null)
                {
                    _txtScheduleRatesCost.LostFocus += txtPartsTotal_LostFocus;
                }
            }
        }

        private Label _lblSORMarkup;

        internal Label lblSORMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSORMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSORMarkup != null)
                {
                }

                _lblSORMarkup = value;
                if (_lblSORMarkup != null)
                {
                }
            }
        }

        private TextBox _txtScheduleRateMarkup;

        internal TextBox txtScheduleRateMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtScheduleRateMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtScheduleRateMarkup != null)
                {
                }

                _txtScheduleRateMarkup = value;
                if (_txtScheduleRateMarkup != null)
                {
                }
            }
        }

        private Label _lblTotalSORCharge;

        internal Label lblTotalSORCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTotalSORCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTotalSORCharge != null)
                {
                }

                _lblTotalSORCharge = value;
                if (_lblTotalSORCharge != null)
                {
                }
            }
        }

        private TextBox _txtScheduleRatesCostTotal;

        internal TextBox txtScheduleRatesCostTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtScheduleRatesCostTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtScheduleRatesCostTotal != null)
                {
                }

                _txtScheduleRatesCostTotal = value;
                if (_txtScheduleRatesCostTotal != null)
                {
                }
            }
        }

        private GroupBox _grpRates;

        internal GroupBox grpRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpRates != null)
                {
                }

                _grpRates = value;
                if (_grpRates != null)
                {
                }
            }
        }

        private TextBox _txtTimeInMins;

        internal TextBox txtTimeInMins
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTimeInMins;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTimeInMins != null)
                {
                }

                _txtTimeInMins = value;
                if (_txtTimeInMins != null)
                {
                }
            }
        }

        private Label _lblTime;

        internal Label lblTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTime != null)
                {
                }

                _lblTime = value;
                if (_lblTime != null)
                {
                }
            }
        }

        private Label _lblAsbestosNotes;

        internal Label lblAsbestosNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAsbestosNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAsbestosNotes != null)
                {
                }

                _lblAsbestosNotes = value;
                if (_lblAsbestosNotes != null)
                {
                }
            }
        }

        private TextBox _txtAsbestos;

        internal TextBox txtAsbestos
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAsbestos;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAsbestos != null)
                {
                }

                _txtAsbestos = value;
                if (_txtAsbestos != null)
                {
                }
            }
        }

        private ComboBox _cboAsbestos;

        internal ComboBox cboAsbestos
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAsbestos;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAsbestos != null)
                {
                }

                _cboAsbestos = value;
                if (_cboAsbestos != null)
                {
                }
            }
        }

        private Label _lblAsbestosStatus;

        internal Label lblAsbestosStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAsbestosStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAsbestosStatus != null)
                {
                }

                _lblAsbestosStatus = value;
                if (_lblAsbestosStatus != null)
                {
                }
            }
        }

        private Label _lblInstallerNotes;

        internal Label lblInstallerNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInstallerNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInstallerNotes != null)
                {
                }

                _lblInstallerNotes = value;
                if (_lblInstallerNotes != null)
                {
                }
            }
        }

        private TextBox _txtInstallerNotes;

        internal TextBox txtInstallerNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInstallerNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInstallerNotes != null)
                {
                }

                _txtInstallerNotes = value;
                if (_txtInstallerNotes != null)
                {
                }
            }
        }

        private GroupBox _gpOtherLabour;

        internal GroupBox gpOtherLabour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpOtherLabour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpOtherLabour != null)
                {
                }

                _gpOtherLabour = value;
                if (_gpOtherLabour != null)
                {
                }
            }
        }

        private TextBox _txtElectricianCharge;

        internal TextBox txtElectricianCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtElectricianCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtElectricianCharge != null)
                {
                }

                _txtElectricianCharge = value;
                if (_txtElectricianCharge != null)
                {
                }
            }
        }

        private Label _lblTotalElectricianCharge;

        internal Label lblTotalElectricianCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTotalElectricianCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTotalElectricianCharge != null)
                {
                }

                _lblTotalElectricianCharge = value;
                if (_lblTotalElectricianCharge != null)
                {
                }
            }
        }

        private TextBox _txtElectricianMarkup;

        internal TextBox txtElectricianMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtElectricianMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtElectricianMarkup != null)
                {
                }

                _txtElectricianMarkup = value;
                if (_txtElectricianMarkup != null)
                {
                }
            }
        }

        private Label _lblElectricianMarkup;

        internal Label lblElectricianMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblElectricianMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblElectricianMarkup != null)
                {
                }

                _lblElectricianMarkup = value;
                if (_lblElectricianMarkup != null)
                {
                }
            }
        }

        private TextBox _txtElectricianCost;

        internal TextBox txtElectricianCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtElectricianCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtElectricianCost != null)
                {
                }

                _txtElectricianCost = value;
                if (_txtElectricianCost != null)
                {
                }
            }
        }

        private Label _lblElectricianCost;

        internal Label lblElectricianCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblElectricianCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblElectricianCost != null)
                {
                }

                _lblElectricianCost = value;
                if (_lblElectricianCost != null)
                {
                }
            }
        }

        private Label _lblTotalInstallerCharge;

        internal Label lblTotalInstallerCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTotalInstallerCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTotalInstallerCharge != null)
                {
                }

                _lblTotalInstallerCharge = value;
                if (_lblTotalInstallerCharge != null)
                {
                }
            }
        }

        private TextBox _txtInstallerMarkup;

        internal TextBox txtInstallerMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInstallerMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInstallerMarkup != null)
                {
                }

                _txtInstallerMarkup = value;
                if (_txtInstallerMarkup != null)
                {
                }
            }
        }

        private Label _lblInstallerMarkup;

        internal Label lblInstallerMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInstallerMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInstallerMarkup != null)
                {
                }

                _lblInstallerMarkup = value;
                if (_lblInstallerMarkup != null)
                {
                }
            }
        }

        private TextBox _txtInstallerCost;

        internal TextBox txtInstallerCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInstallerCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInstallerCost != null)
                {
                }

                _txtInstallerCost = value;
                if (_txtInstallerCost != null)
                {
                }
            }
        }

        private Label _lblInstallerCost;

        internal Label lblInstallerCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInstallerCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInstallerCost != null)
                {
                }

                _lblInstallerCost = value;
                if (_lblInstallerCost != null)
                {
                }
            }
        }

        private TextBox _txtBuilderCharge;

        internal TextBox txtBuilderCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBuilderCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBuilderCharge != null)
                {
                }

                _txtBuilderCharge = value;
                if (_txtBuilderCharge != null)
                {
                }
            }
        }

        private Label _lblTotalBuilderCharge;

        internal Label lblTotalBuilderCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTotalBuilderCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTotalBuilderCharge != null)
                {
                }

                _lblTotalBuilderCharge = value;
                if (_lblTotalBuilderCharge != null)
                {
                }
            }
        }

        private TextBox _txtBuilderMarkup;

        internal TextBox txtBuilderMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBuilderMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBuilderMarkup != null)
                {
                }

                _txtBuilderMarkup = value;
                if (_txtBuilderMarkup != null)
                {
                }
            }
        }

        private Label _lblBuilderMarkup;

        internal Label lblBuilderMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBuilderMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBuilderMarkup != null)
                {
                }

                _lblBuilderMarkup = value;
                if (_lblBuilderMarkup != null)
                {
                }
            }
        }

        private TextBox _txtBuilderCost;

        internal TextBox txtBuilderCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBuilderCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBuilderCost != null)
                {
                }

                _txtBuilderCost = value;
                if (_txtBuilderCost != null)
                {
                }
            }
        }

        private Label _lblBuilderCost;

        internal Label lblBuilderCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBuilderCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBuilderCost != null)
                {
                }

                _lblBuilderCost = value;
                if (_lblBuilderCost != null)
                {
                }
            }
        }

        private TextBox _txtInstallerCharge;

        internal TextBox txtInstallerCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInstallerCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInstallerCharge != null)
                {
                }

                _txtInstallerCharge = value;
                if (_txtInstallerCharge != null)
                {
                }
            }
        }

        private TextBox _txtAccess;

        internal TextBox txtAccess
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccess;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccess != null)
                {
                }

                _txtAccess = value;
                if (_txtAccess != null)
                {
                }
            }
        }

        private Label _lblAddCharges;

        internal Label lblAddCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddCharges != null)
                {
                }

                _lblAddCharges = value;
                if (_lblAddCharges != null)
                {
                }
            }
        }

        private ComboBox _cboAccess;

        internal ComboBox cboAccess
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAccess;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAccess != null)
                {
                }

                _cboAccess = value;
                if (_cboAccess != null)
                {
                }
            }
        }

        private Label _lblAccessEquipment;

        internal Label lblAccessEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAccessEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAccessEquipment != null)
                {
                }

                _lblAccessEquipment = value;
                if (_lblAccessEquipment != null)
                {
                }
            }
        }

        private TextBox _txtInstallerLabourDays;

        internal TextBox txtInstallerLabourDays
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInstallerLabourDays;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInstallerLabourDays != null)
                {
                }

                _txtInstallerLabourDays = value;
                if (_txtInstallerLabourDays != null)
                {
                }
            }
        }

        private Label _lblInstallerDays;

        internal Label lblInstallerDays
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInstallerDays;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInstallerDays != null)
                {
                }

                _lblInstallerDays = value;
                if (_lblInstallerDays != null)
                {
                }
            }
        }

        private TextBox _txtElectricianHours;

        internal TextBox txtElectricianHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtElectricianHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtElectricianHours != null)
                {
                }

                _txtElectricianHours = value;
                if (_txtElectricianHours != null)
                {
                }
            }
        }

        private Label _lblElectricianPack;

        internal Label lblElectricianPack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblElectricianPack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblElectricianPack != null)
                {
                }

                _lblElectricianPack = value;
                if (_lblElectricianPack != null)
                {
                }
            }
        }

        private TextBox _txtElectricianNotes;

        internal TextBox txtElectricianNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtElectricianNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtElectricianNotes != null)
                {
                }

                _txtElectricianNotes = value;
                if (_txtElectricianNotes != null)
                {
                }
            }
        }

        private Label _lblElectricianNotes;

        internal Label lblElectricianNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblElectricianNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblElectricianNotes != null)
                {
                }

                _lblElectricianNotes = value;
                if (_lblElectricianNotes != null)
                {
                }
            }
        }

        private Label _lblElectricianPackHours;

        internal Label lblElectricianPackHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblElectricianPackHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblElectricianPackHours != null)
                {
                }

                _lblElectricianPackHours = value;
                if (_lblElectricianPackHours != null)
                {
                }
            }
        }

        private Label _lblElectOr;

        internal Label lblElectOr
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblElectOr;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblElectOr != null)
                {
                }

                _lblElectOr = value;
                if (_lblElectOr != null)
                {
                }
            }
        }

        private ComboBox _cboElectricalPack;

        internal ComboBox cboElectricalPack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboElectricalPack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboElectricalPack != null)
                {
                    _cboElectricalPack.SelectedIndexChanged -= cboElectricalPack_SelectedIndexChanged;
                }

                _cboElectricalPack = value;
                if (_cboElectricalPack != null)
                {
                    _cboElectricalPack.SelectedIndexChanged += cboElectricalPack_SelectedIndexChanged;
                }
            }
        }

        private TextBox _txtElectricianArrivalHour;

        internal TextBox txtElectricianArrivalHour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtElectricianArrivalHour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtElectricianArrivalHour != null)
                {
                }

                _txtElectricianArrivalHour = value;
                if (_txtElectricianArrivalHour != null)
                {
                }
            }
        }

        private Label _lblElectricianHour;

        internal Label lblElectricianHour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblElectricianHour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblElectricianHour != null)
                {
                }

                _lblElectricianHour = value;
                if (_lblElectricianHour != null)
                {
                }
            }
        }

        private TextBox _txtElectricianArrivalDay;

        internal TextBox txtElectricianArrivalDay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtElectricianArrivalDay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtElectricianArrivalDay != null)
                {
                }

                _txtElectricianArrivalDay = value;
                if (_txtElectricianArrivalDay != null)
                {
                }
            }
        }

        private Label _lblElectricianArrivalDay;

        internal Label lblElectricianArrivalDay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblElectricianArrivalDay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblElectricianArrivalDay != null)
                {
                }

                _lblElectricianArrivalDay = value;
                if (_lblElectricianArrivalDay != null)
                {
                }
            }
        }

        private TextBox _txtBuilderArrivalHour;

        internal TextBox txtBuilderArrivalHour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBuilderArrivalHour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBuilderArrivalHour != null)
                {
                }

                _txtBuilderArrivalHour = value;
                if (_txtBuilderArrivalHour != null)
                {
                }
            }
        }

        private Label _lblBuilderHour;

        internal Label lblBuilderHour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBuilderHour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBuilderHour != null)
                {
                }

                _lblBuilderHour = value;
                if (_lblBuilderHour != null)
                {
                }
            }
        }

        private TextBox _txtBuilderArrivalDay;

        internal TextBox txtBuilderArrivalDay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBuilderArrivalDay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBuilderArrivalDay != null)
                {
                }

                _txtBuilderArrivalDay = value;
                if (_txtBuilderArrivalDay != null)
                {
                }
            }
        }

        private Label _lblArrivalDay;

        internal Label lblArrivalDay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblArrivalDay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblArrivalDay != null)
                {
                }

                _lblArrivalDay = value;
                if (_lblArrivalDay != null)
                {
                }
            }
        }

        private TextBox _txtBuilderHours;

        internal TextBox txtBuilderHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBuilderHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBuilderHours != null)
                {
                    _txtBuilderHours.TextChanged -= txtBuilderHours_TextChanged;
                }

                _txtBuilderHours = value;
                if (_txtBuilderHours != null)
                {
                    _txtBuilderHours.TextChanged += txtBuilderHours_TextChanged;
                }
            }
        }

        private TextBox _txtBuilderNotes;

        internal TextBox txtBuilderNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBuilderNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBuilderNotes != null)
                {
                }

                _txtBuilderNotes = value;
                if (_txtBuilderNotes != null)
                {
                }
            }
        }

        private Label _lblBuilderNotes;

        internal Label lblBuilderNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBuilderNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBuilderNotes != null)
                {
                }

                _lblBuilderNotes = value;
                if (_lblBuilderNotes != null)
                {
                }
            }
        }

        private Label _lblBuilderLabourHours;

        internal Label lblBuilderLabourHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBuilderLabourHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBuilderLabourHours != null)
                {
                }

                _lblBuilderLabourHours = value;
                if (_lblBuilderLabourHours != null)
                {
                }
            }
        }

        private Label _lblBuilderLabour;

        internal Label lblBuilderLabour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBuilderLabour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBuilderLabour != null)
                {
                }

                _lblBuilderLabour = value;
                if (_lblBuilderLabour != null)
                {
                }
            }
        }

        private Label _lblBOC;

        internal Label lblBOC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBOC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBOC != null)
                {
                }

                _lblBOC = value;
                if (_lblBOC != null)
                {
                }
            }
        }

        private TextBox _txtDeposit;

        internal TextBox txtDeposit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDeposit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDeposit != null)
                {
                }

                _txtDeposit = value;
                if (_txtDeposit != null)
                {
                }
            }
        }

        private Label _lblDeposit;

        internal Label lblDeposit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDeposit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDeposit != null)
                {
                }

                _lblDeposit = value;
                if (_lblDeposit != null)
                {
                }
            }
        }

        private TextBox _txtincVAT;

        internal TextBox txtincVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtincVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtincVAT != null)
                {
                }

                _txtincVAT = value;
                if (_txtincVAT != null)
                {
                }
            }
        }

        private Label _lblIncVAT;

        internal Label lblIncVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblIncVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblIncVAT != null)
                {
                }

                _lblIncVAT = value;
                if (_lblIncVAT != null)
                {
                }
            }
        }

        private ComboBox _cboVAT;

        internal ComboBox cboVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVAT != null)
                {
                    _cboVAT.SelectedIndexChanged -= txtPartsTotal_LostFocus;
                }

                _cboVAT = value;
                if (_cboVAT != null)
                {
                    _cboVAT.SelectedIndexChanged += txtPartsTotal_LostFocus;
                }
            }
        }

        private Label _lblVAT;

        internal Label lblVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVAT != null)
                {
                }

                _lblVAT = value;
                if (_lblVAT != null)
                {
                }
            }
        }

        private TextBox _txtGrandTotal;

        internal TextBox txtGrandTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtGrandTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtGrandTotal != null)
                {
                    _txtGrandTotal.TextChanged -= txtGrandTotal_TextChanged;
                }

                _txtGrandTotal = value;
                if (_txtGrandTotal != null)
                {
                    _txtGrandTotal.TextChanged += txtGrandTotal_TextChanged;
                }
            }
        }

        private TextBox _txtTotalCosts;

        internal TextBox txtTotalCosts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTotalCosts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTotalCosts != null)
                {
                }

                _txtTotalCosts = value;
                if (_txtTotalCosts != null)
                {
                }
            }
        }

        private Label _lblSale;

        internal Label lblSale
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSale;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSale != null)
                {
                }

                _lblSale = value;
                if (_lblSale != null)
                {
                }
            }
        }

        private TextBox _txtProfitPound;

        internal TextBox txtProfitPound
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfitPound;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfitPound != null)
                {
                }

                _txtProfitPound = value;
                if (_txtProfitPound != null)
                {
                }
            }
        }

        private Label _lblProfitSlash;

        internal Label lblProfitSlash
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProfitSlash;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProfitSlash != null)
                {
                }

                _lblProfitSlash = value;
                if (_lblProfitSlash != null)
                {
                }
            }
        }

        private TextBox _txtProfitPerc;

        internal TextBox txtProfitPerc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfitPerc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfitPerc != null)
                {
                }

                _txtProfitPerc = value;
                if (_txtProfitPerc != null)
                {
                }
            }
        }

        private Label _lblProfit;

        internal Label lblProfit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProfit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProfit != null)
                {
                }

                _lblProfit = value;
                if (_lblProfit != null)
                {
                }
            }
        }

        private Label _lblTotalCosts;

        internal Label lblTotalCosts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTotalCosts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTotalCosts != null)
                {
                }

                _lblTotalCosts = value;
                if (_lblTotalCosts != null)
                {
                }
            }
        }

        private CheckBox _chkSORCharge;

        internal CheckBox chkSORCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSORCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSORCharge != null)
                {
                    _chkSORCharge.CheckedChanged -= chkSORCharge_CheckedChanged;
                }

                _chkSORCharge = value;
                if (_chkSORCharge != null)
                {
                    _chkSORCharge.CheckedChanged += chkSORCharge_CheckedChanged;
                }
            }
        }

        private TextBox _txtSurveyor;

        internal TextBox txtSurveyor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSurveyor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSurveyor != null)
                {
                }

                _txtSurveyor = value;
                if (_txtSurveyor != null)
                {
                }
            }
        }

        private Label _lblSurveyor;

        internal Label lblSurveyor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSurveyor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSurveyor != null)
                {
                }

                _lblSurveyor = value;
                if (_lblSurveyor != null)
                {
                }
            }
        }

        private Label _lblLastChangedOn;

        internal Label lblLastChangedOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLastChangedOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLastChangedOn != null)
                {
                }

                _lblLastChangedOn = value;
                if (_lblLastChangedOn != null)
                {
                }
            }
        }

        private TextBox _txtChangedDate;

        internal TextBox txtChangedDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtChangedDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtChangedDate != null)
                {
                }

                _txtChangedDate = value;
                if (_txtChangedDate != null)
                {
                }
            }
        }

        private Label _lblChangedBy;

        internal Label lblChangedBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblChangedBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblChangedBy != null)
                {
                }

                _lblChangedBy = value;
                if (_lblChangedBy != null)
                {
                }
            }
        }

        private TextBox _txtChangedBy;

        internal TextBox txtChangedBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtChangedBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtChangedBy != null)
                {
                }

                _txtChangedBy = value;
                if (_txtChangedBy != null)
                {
                }
            }
        }

        private Label _lblNA;

        internal Label lblNA
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNA;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNA != null)
                {
                }

                _lblNA = value;
                if (_lblNA != null)
                {
                }
            }
        }

        private Label _lblEstStartDAte;

        internal Label lblEstStartDAte
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEstStartDAte;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEstStartDAte != null)
                {
                }

                _lblEstStartDAte = value;
                if (_lblEstStartDAte != null)
                {
                }
            }
        }

        private DateTimePicker _dtpestStartDate;

        internal DateTimePicker dtpestStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpestStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpestStartDate != null)
                {
                }

                _dtpestStartDate = value;
                if (_dtpestStartDate != null)
                {
                }
            }
        }

        private Label _lblPurchaseDept;

        internal Label lblPurchaseDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPurchaseDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPurchaseDept != null)
                {
                }

                _lblPurchaseDept = value;
                if (_lblPurchaseDept != null)
                {
                }
            }
        }

        private ComboBox _cboDept;

        internal ComboBox cboDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDept != null)
                {
                }

                _cboDept = value;
                if (_cboDept != null)
                {
                }
            }
        }

        private CheckBox _chkService;

        internal CheckBox chkService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkService != null)
                {
                }

                _chkService = value;
                if (_chkService != null)
                {
                }
            }
        }

        private CheckBox _chkHOver;

        internal CheckBox chkHOver
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkHOver;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkHOver != null)
                {
                }

                _chkHOver = value;
                if (_chkHOver != null)
                {
                }
            }
        }

        private TextBox _txtOriginalQuote;

        internal TextBox txtOriginalQuote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOriginalQuote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOriginalQuote != null)
                {
                }

                _txtOriginalQuote = value;
                if (_txtOriginalQuote != null)
                {
                }
            }
        }

        private Label _lblOriginalQuote;

        internal Label lblOriginalQuote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOriginalQuote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOriginalQuote != null)
                {
                }

                _lblOriginalQuote = value;
                if (_lblOriginalQuote != null)
                {
                }
            }
        }

        private Button _btnEmailSOR;

        internal Button btnEmailSOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEmailSOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEmailSOR != null)
                {
                    _btnEmailSOR.Click -= btnEmailSOR_Click;
                }

                _btnEmailSOR = value;
                if (_btnEmailSOR != null)
                {
                    _btnEmailSOR.Click += btnEmailSOR_Click;
                }
            }
        }

        private GroupBox _grpTotals;

        internal GroupBox grpTotals
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpTotals;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpTotals != null)
                {
                }

                _grpTotals = value;
                if (_grpTotals != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpRates = new GroupBox();
            _btnEmailSOR = new Button();
            _btnEmailSOR.Click += new EventHandler(btnEmailSOR_Click);
            _txtTimeInMins = new TextBox();
            _lblTime = new Label();
            _btnSiteScheduleOfRates = new Button();
            _btnSiteScheduleOfRates.Click += new EventHandler(btnSiteScheduleOfRates_Click);
            _btnRemove = new Button();
            _btnRemove.Click += new EventHandler(btnRemove_Click);
            _cboScheduleOfRatesCategoryID = new ComboBox();
            _lblScheduleOfRatesCategoryID = new Label();
            _txtCode = new TextBox();
            _lblCode = new Label();
            _txtDescription = new TextBox();
            _lblDescription = new Label();
            _dgScheduleOfRates = new DataGrid();
            _txtPrice = new TextBox();
            _lblPrice = new Label();
            _lblQuantity = new Label();
            _txtQuantity = new TextBox();
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _lblQuoteStatus = new Label();
            _lblQuoteDate = new Label();
            _cboQuoteStatus = new ComboBox();
            _cboQuoteStatus.SelectedIndexChanged += new EventHandler(cboQuoteStatus_SelectedIndexChanged);
            _grpJobItems = new GroupBox();
            _lblNA = new Label();
            _lblEstStartDAte = new Label();
            _txtInstallerLabourDays = new TextBox();
            _dtpestStartDate = new DateTimePicker();
            _lblInstallerDays = new Label();
            _txtAccess = new TextBox();
            _lblAddCharges = new Label();
            _cboAccess = new ComboBox();
            _lblAccessEquipment = new Label();
            _lblAsbestosNotes = new Label();
            _txtAsbestos = new TextBox();
            _cboAsbestos = new ComboBox();
            _lblAsbestosStatus = new Label();
            _lblInstallerNotes = new Label();
            _txtInstallerNotes = new TextBox();
            _txtReference = new TextBox();
            _cboJobType = new ComboBox();
            _lblJobType = new Label();
            _lblCustomer = new Label();
            _grpTotals = new GroupBox();
            _txtOriginalQuote = new TextBox();
            _lblOriginalQuote = new Label();
            _txtGrandTotal = new TextBox();
            _txtGrandTotal.TextChanged += new EventHandler(txtGrandTotal_TextChanged);
            _chkSORCharge = new CheckBox();
            _chkSORCharge.CheckedChanged += new EventHandler(chkSORCharge_CheckedChanged);
            _lblBOC = new Label();
            _txtDeposit = new TextBox();
            _lblDeposit = new Label();
            _txtincVAT = new TextBox();
            _lblIncVAT = new Label();
            _cboVAT = new ComboBox();
            _cboVAT.SelectedIndexChanged += new EventHandler(txtPartsTotal_LostFocus);
            _lblVAT = new Label();
            _txtTotalCosts = new TextBox();
            _lblSale = new Label();
            _txtProfitPound = new TextBox();
            _lblProfitSlash = new Label();
            _txtProfitPerc = new TextBox();
            _lblProfit = new Label();
            _lblTotalCosts = new Label();
            _txtPartsCostTotal = new TextBox();
            _txtBuilderCharge = new TextBox();
            _lblTotalBuilderCharge = new Label();
            _txtBuilderMarkup = new TextBox();
            _lblBuilderMarkup = new Label();
            _txtBuilderCost = new TextBox();
            _lblBuilderCost = new Label();
            _txtElectricianCharge = new TextBox();
            _lblTotalElectricianCharge = new Label();
            _txtElectricianMarkup = new TextBox();
            _lblElectricianMarkup = new Label();
            _txtElectricianCost = new TextBox();
            _lblElectricianCost = new Label();
            _txtInstallerCharge = new TextBox();
            _lblTotalInstallerCharge = new Label();
            _txtInstallerMarkup = new TextBox();
            _lblInstallerMarkup = new Label();
            _txtInstallerCost = new TextBox();
            _lblInstallerCost = new Label();
            _txtScheduleRatesCostTotal = new TextBox();
            _lblTotalSORCharge = new Label();
            _txtScheduleRateMarkup = new TextBox();
            _lblSORMarkup = new Label();
            _txtScheduleRatesCost = new TextBox();
            _txtScheduleRatesCost.LostFocus += new EventHandler(txtPartsTotal_LostFocus);
            _lblSORCost = new Label();
            _lblTotalPartsCharge = new Label();
            _txtPartsProductsMarkup = new TextBox();
            _txtPartsProductsMarkup.LostFocus += new EventHandler(txtPartsTotal_LostFocus);
            _lblPartsMarkup = new Label();
            _txtBOC = new TextBox();
            _txtPartsCost = new TextBox();
            _txtPartsCost.LostFocus += new EventHandler(txtPartsTotal_LostFocus);
            _lblPartsCost = new Label();
            _grpParts = new GroupBox();
            _btnRemovePartProduct = new Button();
            _btnRemovePartProduct.Click += new EventHandler(btnRemovePartProduct_Click);
            _btnFindPart = new Button();
            _btnFindPart.Click += new EventHandler(btnFindPart_Click);
            _dgPartsAndProducts = new DataGrid();
            _dtpQuoteDate = new DateTimePicker();
            _txtSiteName = new TextBox();
            _lblProperty = new Label();
            _lblQuoteRef = new Label();
            _txtCustomerName = new TextBox();
            _gpOtherLabour = new GroupBox();
            _txtBuilderArrivalHour = new TextBox();
            _lblBuilderHour = new Label();
            _txtBuilderArrivalDay = new TextBox();
            _lblArrivalDay = new Label();
            _txtBuilderHours = new TextBox();
            _txtBuilderHours.TextChanged += new EventHandler(txtBuilderHours_TextChanged);
            _txtBuilderNotes = new TextBox();
            _lblBuilderNotes = new Label();
            _lblBuilderLabourHours = new Label();
            _lblBuilderLabour = new Label();
            _txtElectricianArrivalHour = new TextBox();
            _lblElectricianHour = new Label();
            _txtElectricianArrivalDay = new TextBox();
            _lblElectricianArrivalDay = new Label();
            _txtElectricianHours = new TextBox();
            _txtElectricianNotes = new TextBox();
            _lblElectricianNotes = new Label();
            _lblElectricianPackHours = new Label();
            _lblElectOr = new Label();
            _cboElectricalPack = new ComboBox();
            _cboElectricalPack.SelectedIndexChanged += new EventHandler(cboElectricalPack_SelectedIndexChanged);
            _lblElectricianPack = new Label();
            _txtSurveyor = new TextBox();
            _lblSurveyor = new Label();
            _lblLastChangedOn = new Label();
            _txtChangedDate = new TextBox();
            _lblChangedBy = new Label();
            _txtChangedBy = new TextBox();
            _lblPurchaseDept = new Label();
            _cboDept = new ComboBox();
            _chkService = new CheckBox();
            _chkHOver = new CheckBox();
            _grpRates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRates).BeginInit();
            _grpJobItems.SuspendLayout();
            _grpTotals.SuspendLayout();
            _grpParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPartsAndProducts).BeginInit();
            _gpOtherLabour.SuspendLayout();
            SuspendLayout();
            // 
            // grpRates
            // 
            _grpRates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _grpRates.Controls.Add(_btnEmailSOR);
            _grpRates.Controls.Add(_txtTimeInMins);
            _grpRates.Controls.Add(_lblTime);
            _grpRates.Controls.Add(_btnSiteScheduleOfRates);
            _grpRates.Controls.Add(_btnRemove);
            _grpRates.Controls.Add(_cboScheduleOfRatesCategoryID);
            _grpRates.Controls.Add(_lblScheduleOfRatesCategoryID);
            _grpRates.Controls.Add(_txtCode);
            _grpRates.Controls.Add(_lblCode);
            _grpRates.Controls.Add(_txtDescription);
            _grpRates.Controls.Add(_lblDescription);
            _grpRates.Controls.Add(_dgScheduleOfRates);
            _grpRates.Controls.Add(_txtPrice);
            _grpRates.Controls.Add(_lblPrice);
            _grpRates.Controls.Add(_lblQuantity);
            _grpRates.Controls.Add(_txtQuantity);
            _grpRates.Controls.Add(_btnAdd);
            _grpRates.Font = new Font("Verdana", 8.25F);
            _grpRates.Location = new Point(8, 339);
            _grpRates.Name = "grpRates";
            _grpRates.Size = new Size(539, 358);
            _grpRates.TabIndex = 6;
            _grpRates.TabStop = false;
            _grpRates.Text = "Schedule Of  Rates";
            // 
            // btnEmailSOR
            // 
            _btnEmailSOR.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnEmailSOR.Font = new Font("Verdana", 8.25F);
            _btnEmailSOR.Location = new Point(6, 164);
            _btnEmailSOR.Name = "btnEmailSOR";
            _btnEmailSOR.Size = new Size(111, 23);
            _btnEmailSOR.TabIndex = 17;
            _btnEmailSOR.Text = "Email SOR List";
            // 
            // txtTimeInMins
            // 
            _txtTimeInMins.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtTimeInMins.Font = new Font("Verdana", 8.25F);
            _txtTimeInMins.Location = new Point(176, 270);
            _txtTimeInMins.MaxLength = 9;
            _txtTimeInMins.Name = "txtTimeInMins";
            _txtTimeInMins.Size = new Size(355, 21);
            _txtTimeInMins.TabIndex = 10;
            _txtTimeInMins.Tag = "SystemScheduleOfRate.Price";
            // 
            // lblTime
            // 
            _lblTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblTime.Font = new Font("Verdana", 8.25F);
            _lblTime.Location = new Point(8, 271);
            _lblTime.Name = "lblTime";
            _lblTime.Size = new Size(136, 20);
            _lblTime.TabIndex = 9;
            _lblTime.Text = "Time (in Minutes)";
            // 
            // btnSiteScheduleOfRates
            // 
            _btnSiteScheduleOfRates.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSiteScheduleOfRates.Font = new Font("Verdana", 8.25F);
            _btnSiteScheduleOfRates.Location = new Point(307, 326);
            _btnSiteScheduleOfRates.Name = "btnSiteScheduleOfRates";
            _btnSiteScheduleOfRates.Size = new Size(224, 23);
            _btnSiteScheduleOfRates.TabIndex = 16;
            _btnSiteScheduleOfRates.Text = "Add Site Schedule Of Rates";
            // 
            // btnRemove
            // 
            _btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRemove.Font = new Font("Verdana", 8.25F);
            _btnRemove.Location = new Point(451, 164);
            _btnRemove.Name = "btnRemove";
            _btnRemove.Size = new Size(80, 23);
            _btnRemove.TabIndex = 2;
            _btnRemove.Text = "Remove";
            // 
            // cboScheduleOfRatesCategoryID
            // 
            _cboScheduleOfRatesCategoryID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _cboScheduleOfRatesCategoryID.Cursor = Cursors.Hand;
            _cboScheduleOfRatesCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboScheduleOfRatesCategoryID.Font = new Font("Verdana", 8.25F);
            _cboScheduleOfRatesCategoryID.Location = new Point(176, 198);
            _cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID";
            _cboScheduleOfRatesCategoryID.Size = new Size(355, 21);
            _cboScheduleOfRatesCategoryID.TabIndex = 4;
            _cboScheduleOfRatesCategoryID.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            // 
            // lblScheduleOfRatesCategoryID
            // 
            _lblScheduleOfRatesCategoryID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblScheduleOfRatesCategoryID.Font = new Font("Verdana", 8.25F);
            _lblScheduleOfRatesCategoryID.Location = new Point(8, 198);
            _lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID";
            _lblScheduleOfRatesCategoryID.Size = new Size(179, 20);
            _lblScheduleOfRatesCategoryID.TabIndex = 3;
            _lblScheduleOfRatesCategoryID.Text = "Schedule Of Rates Category";
            // 
            // txtCode
            // 
            _txtCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtCode.Font = new Font("Verdana", 8.25F);
            _txtCode.Location = new Point(176, 222);
            _txtCode.MaxLength = 50;
            _txtCode.Name = "txtCode";
            _txtCode.Size = new Size(355, 21);
            _txtCode.TabIndex = 6;
            _txtCode.Tag = "SystemScheduleOfRate.Code";
            // 
            // lblCode
            // 
            _lblCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblCode.Font = new Font("Verdana", 8.25F);
            _lblCode.Location = new Point(8, 222);
            _lblCode.Name = "lblCode";
            _lblCode.Size = new Size(72, 20);
            _lblCode.TabIndex = 5;
            _lblCode.Text = "Code";
            // 
            // txtDescription
            // 
            _txtDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtDescription.Font = new Font("Verdana", 8.25F);
            _txtDescription.Location = new Point(176, 246);
            _txtDescription.MaxLength = 0;
            _txtDescription.Multiline = true;
            _txtDescription.Name = "txtDescription";
            _txtDescription.ScrollBars = ScrollBars.Vertical;
            _txtDescription.Size = new Size(355, 20);
            _txtDescription.TabIndex = 8;
            _txtDescription.Tag = "SystemScheduleOfRate.Description";
            // 
            // lblDescription
            // 
            _lblDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblDescription.Font = new Font("Verdana", 8.25F);
            _lblDescription.Location = new Point(8, 246);
            _lblDescription.Name = "lblDescription";
            _lblDescription.Size = new Size(112, 20);
            _lblDescription.TabIndex = 7;
            _lblDescription.Text = "Description";
            // 
            // dgScheduleOfRates
            // 
            _dgScheduleOfRates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _dgScheduleOfRates.DataMember = "";
            _dgScheduleOfRates.Font = new Font("Verdana", 8.25F);
            _dgScheduleOfRates.HeaderForeColor = SystemColors.ControlText;
            _dgScheduleOfRates.Location = new Point(8, 20);
            _dgScheduleOfRates.Name = "dgScheduleOfRates";
            _dgScheduleOfRates.Size = new Size(523, 138);
            _dgScheduleOfRates.TabIndex = 0;
            // 
            // txtPrice
            // 
            _txtPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtPrice.Font = new Font("Verdana", 8.25F);
            _txtPrice.Location = new Point(48, 294);
            _txtPrice.MaxLength = 9;
            _txtPrice.Name = "txtPrice";
            _txtPrice.Size = new Size(122, 21);
            _txtPrice.TabIndex = 12;
            _txtPrice.Tag = "SystemScheduleOfRate.Price";
            // 
            // lblPrice
            // 
            _lblPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblPrice.Font = new Font("Verdana", 8.25F);
            _lblPrice.Location = new Point(8, 294);
            _lblPrice.Name = "lblPrice";
            _lblPrice.Size = new Size(40, 20);
            _lblPrice.TabIndex = 11;
            _lblPrice.Text = "Price";
            // 
            // lblQuantity
            // 
            _lblQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblQuantity.Font = new Font("Verdana", 8.25F);
            _lblQuantity.Location = new Point(176, 294);
            _lblQuantity.Name = "lblQuantity";
            _lblQuantity.Size = new Size(56, 20);
            _lblQuantity.TabIndex = 13;
            _lblQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            _txtQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _txtQuantity.Font = new Font("Verdana", 8.25F);
            _txtQuantity.Location = new Point(256, 294);
            _txtQuantity.MaxLength = 9;
            _txtQuantity.Name = "txtQuantity";
            _txtQuantity.Size = new Size(275, 21);
            _txtQuantity.TabIndex = 14;
            _txtQuantity.Tag = "";
            // 
            // btnAdd
            // 
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAdd.Font = new Font("Verdana", 8.25F);
            _btnAdd.Location = new Point(8, 326);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(80, 23);
            _btnAdd.TabIndex = 15;
            _btnAdd.Text = "Add";
            // 
            // lblQuoteStatus
            // 
            _lblQuoteStatus.Font = new Font("Verdana", 8.25F);
            _lblQuoteStatus.Location = new Point(474, 38);
            _lblQuoteStatus.Name = "lblQuoteStatus";
            _lblQuoteStatus.Size = new Size(88, 23);
            _lblQuoteStatus.TabIndex = 61;
            _lblQuoteStatus.Text = "Quote Status:";
            // 
            // lblQuoteDate
            // 
            _lblQuoteDate.Font = new Font("Verdana", 8.25F);
            _lblQuoteDate.Location = new Point(475, 3);
            _lblQuoteDate.Name = "lblQuoteDate";
            _lblQuoteDate.Size = new Size(80, 23);
            _lblQuoteDate.TabIndex = 60;
            _lblQuoteDate.Text = "Quote Date:";
            // 
            // cboQuoteStatus
            // 
            _cboQuoteStatus.Font = new Font("Verdana", 8.25F);
            _cboQuoteStatus.ItemHeight = 13;
            _cboQuoteStatus.Location = new Point(560, 37);
            _cboQuoteStatus.Name = "cboQuoteStatus";
            _cboQuoteStatus.Size = new Size(151, 21);
            _cboQuoteStatus.TabIndex = 4;
            // 
            // grpJobItems
            // 
            _grpJobItems.Controls.Add(_lblNA);
            _grpJobItems.Controls.Add(_lblEstStartDAte);
            _grpJobItems.Controls.Add(_txtInstallerLabourDays);
            _grpJobItems.Controls.Add(_dtpestStartDate);
            _grpJobItems.Controls.Add(_lblInstallerDays);
            _grpJobItems.Controls.Add(_txtAccess);
            _grpJobItems.Controls.Add(_lblAddCharges);
            _grpJobItems.Controls.Add(_cboAccess);
            _grpJobItems.Controls.Add(_lblAccessEquipment);
            _grpJobItems.Controls.Add(_lblAsbestosNotes);
            _grpJobItems.Controls.Add(_txtAsbestos);
            _grpJobItems.Controls.Add(_cboAsbestos);
            _grpJobItems.Controls.Add(_lblAsbestosStatus);
            _grpJobItems.Controls.Add(_lblInstallerNotes);
            _grpJobItems.Controls.Add(_txtInstallerNotes);
            _grpJobItems.Font = new Font("Verdana", 8.25F);
            _grpJobItems.Location = new Point(8, 66);
            _grpJobItems.Name = "grpJobItems";
            _grpJobItems.Size = new Size(539, 266);
            _grpJobItems.TabIndex = 5;
            _grpJobItems.TabStop = false;
            _grpJobItems.Text = "Job Details";
            // 
            // lblNA
            // 
            _lblNA.Font = new Font("Verdana", 8.25F);
            _lblNA.Location = new Point(120, 245);
            _lblNA.Name = "lblNA";
            _lblNA.Size = new Size(73, 19);
            _lblNA.TabIndex = 72;
            _lblNA.Text = "N/A";
            _lblNA.Visible = false;
            // 
            // lblEstStartDAte
            // 
            _lblEstStartDAte.Font = new Font("Verdana", 8.25F);
            _lblEstStartDAte.Location = new Point(8, 246);
            _lblEstStartDAte.Name = "lblEstStartDAte";
            _lblEstStartDAte.Size = new Size(109, 17);
            _lblEstStartDAte.TabIndex = 73;
            _lblEstStartDAte.Text = "Est Start Date";
            // 
            // txtInstallerLabourDays
            // 
            _txtInstallerLabourDays.Font = new Font("Verdana", 8.25F);
            _txtInstallerLabourDays.Location = new Point(123, 147);
            _txtInstallerLabourDays.MaxLength = 50;
            _txtInstallerLabourDays.Name = "txtInstallerLabourDays";
            _txtInstallerLabourDays.Size = new Size(143, 21);
            _txtInstallerLabourDays.TabIndex = 20;
            _txtInstallerLabourDays.Tag = "SystemScheduleOfRate.Code";
            // 
            // dtpestStartDate
            // 
            _dtpestStartDate.CalendarFont = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dtpestStartDate.Font = new Font("Verdana", 8.25F);
            _dtpestStartDate.Location = new Point(123, 242);
            _dtpestStartDate.Name = "dtpestStartDate";
            _dtpestStartDate.Size = new Size(167, 21);
            _dtpestStartDate.TabIndex = 72;
            _dtpestStartDate.Value = new DateTime(2007, 8, 13, 15, 56, 20, 616);
            // 
            // lblInstallerDays
            // 
            _lblInstallerDays.Font = new Font("Verdana", 8.25F);
            _lblInstallerDays.Location = new Point(8, 150);
            _lblInstallerDays.Name = "lblInstallerDays";
            _lblInstallerDays.Size = new Size(98, 20);
            _lblInstallerDays.TabIndex = 19;
            _lblInstallerDays.Text = "Installer Days";
            // 
            // txtAccess
            // 
            _txtAccess.AcceptsReturn = true;
            _txtAccess.Font = new Font("Verdana", 8.25F);
            _txtAccess.Location = new Point(460, 216);
            _txtAccess.MaxLength = 50;
            _txtAccess.Name = "txtAccess";
            _txtAccess.Size = new Size(71, 21);
            _txtAccess.TabIndex = 18;
            _txtAccess.Tag = "SystemScheduleOfRate.Code";
            // 
            // lblAddCharges
            // 
            _lblAddCharges.Font = new Font("Verdana", 8.25F);
            _lblAddCharges.Location = new Point(328, 219);
            _lblAddCharges.Name = "lblAddCharges";
            _lblAddCharges.Size = new Size(134, 20);
            _lblAddCharges.TabIndex = 17;
            _lblAddCharges.Text = "Access / Add Charges";
            // 
            // cboAccess
            // 
            _cboAccess.Cursor = Cursors.Hand;
            _cboAccess.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAccess.Font = new Font("Verdana", 8.25F);
            _cboAccess.Location = new Point(123, 216);
            _cboAccess.Name = "cboAccess";
            _cboAccess.Size = new Size(201, 21);
            _cboAccess.TabIndex = 14;
            _cboAccess.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            // 
            // lblAccessEquipment
            // 
            _lblAccessEquipment.Font = new Font("Verdana", 8.25F);
            _lblAccessEquipment.Location = new Point(6, 216);
            _lblAccessEquipment.Name = "lblAccessEquipment";
            _lblAccessEquipment.Size = new Size(114, 20);
            _lblAccessEquipment.TabIndex = 13;
            _lblAccessEquipment.Text = "Access Equipment";
            // 
            // lblAsbestosNotes
            // 
            _lblAsbestosNotes.Font = new Font("Verdana", 8.25F);
            _lblAsbestosNotes.Location = new Point(8, 174);
            _lblAsbestosNotes.Name = "lblAsbestosNotes";
            _lblAsbestosNotes.Size = new Size(112, 20);
            _lblAsbestosNotes.TabIndex = 12;
            _lblAsbestosNotes.Text = "Asbestos Notes";
            // 
            // txtAsbestos
            // 
            _txtAsbestos.Font = new Font("Verdana", 8.25F);
            _txtAsbestos.Location = new Point(123, 174);
            _txtAsbestos.MaxLength = 50;
            _txtAsbestos.Multiline = true;
            _txtAsbestos.Name = "txtAsbestos";
            _txtAsbestos.Size = new Size(410, 36);
            _txtAsbestos.TabIndex = 11;
            _txtAsbestos.Tag = "SystemScheduleOfRate.Code";
            // 
            // cboAsbestos
            // 
            _cboAsbestos.Cursor = Cursors.Hand;
            _cboAsbestos.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAsbestos.Font = new Font("Verdana", 8.25F);
            _cboAsbestos.Location = new Point(397, 147);
            _cboAsbestos.Name = "cboAsbestos";
            _cboAsbestos.Size = new Size(136, 21);
            _cboAsbestos.TabIndex = 10;
            _cboAsbestos.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            // 
            // lblAsbestosStatus
            // 
            _lblAsbestosStatus.Font = new Font("Verdana", 8.25F);
            _lblAsbestosStatus.Location = new Point(272, 150);
            _lblAsbestosStatus.Name = "lblAsbestosStatus";
            _lblAsbestosStatus.Size = new Size(114, 20);
            _lblAsbestosStatus.TabIndex = 9;
            _lblAsbestosStatus.Text = "Asbestos Status";
            // 
            // lblInstallerNotes
            // 
            _lblInstallerNotes.Font = new Font("Verdana", 8.25F);
            _lblInstallerNotes.Location = new Point(8, 23);
            _lblInstallerNotes.Name = "lblInstallerNotes";
            _lblInstallerNotes.Size = new Size(98, 20);
            _lblInstallerNotes.TabIndex = 8;
            _lblInstallerNotes.Text = "Installer Notes";
            // 
            // txtInstallerNotes
            // 
            _txtInstallerNotes.Font = new Font("Verdana", 8.25F);
            _txtInstallerNotes.Location = new Point(123, 23);
            _txtInstallerNotes.MaxLength = 50;
            _txtInstallerNotes.Multiline = true;
            _txtInstallerNotes.Name = "txtInstallerNotes";
            _txtInstallerNotes.Size = new Size(410, 118);
            _txtInstallerNotes.TabIndex = 7;
            _txtInstallerNotes.Tag = "SystemScheduleOfRate.Code";
            // 
            // txtReference
            // 
            _txtReference.Font = new Font("Verdana", 8.25F);
            _txtReference.Location = new Point(316, 37);
            _txtReference.MaxLength = 50;
            _txtReference.Name = "txtReference";
            _txtReference.Size = new Size(154, 21);
            _txtReference.TabIndex = 3;
            // 
            // cboJobType
            // 
            _cboJobType.Font = new Font("Verdana", 8.25F);
            _cboJobType.ItemHeight = 13;
            _cboJobType.Location = new Point(316, 1);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(154, 21);
            _cboJobType.TabIndex = 1;
            // 
            // lblJobType
            // 
            _lblJobType.Font = new Font("Verdana", 8.25F);
            _lblJobType.Location = new Point(252, 3);
            _lblJobType.Name = "lblJobType";
            _lblJobType.Size = new Size(72, 23);
            _lblJobType.TabIndex = 56;
            _lblJobType.Text = "Job Type:";
            // 
            // lblCustomer
            // 
            _lblCustomer.Font = new Font("Verdana", 8.25F);
            _lblCustomer.Location = new Point(8, 4);
            _lblCustomer.Name = "lblCustomer";
            _lblCustomer.Size = new Size(80, 23);
            _lblCustomer.TabIndex = 54;
            _lblCustomer.Text = "Customer:";
            // 
            // grpTotals
            // 
            _grpTotals.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _grpTotals.Controls.Add(_txtOriginalQuote);
            _grpTotals.Controls.Add(_lblOriginalQuote);
            _grpTotals.Controls.Add(_txtGrandTotal);
            _grpTotals.Controls.Add(_chkSORCharge);
            _grpTotals.Controls.Add(_lblBOC);
            _grpTotals.Controls.Add(_txtDeposit);
            _grpTotals.Controls.Add(_lblDeposit);
            _grpTotals.Controls.Add(_txtincVAT);
            _grpTotals.Controls.Add(_lblIncVAT);
            _grpTotals.Controls.Add(_cboVAT);
            _grpTotals.Controls.Add(_lblVAT);
            _grpTotals.Controls.Add(_txtTotalCosts);
            _grpTotals.Controls.Add(_lblSale);
            _grpTotals.Controls.Add(_txtProfitPound);
            _grpTotals.Controls.Add(_lblProfitSlash);
            _grpTotals.Controls.Add(_txtProfitPerc);
            _grpTotals.Controls.Add(_lblProfit);
            _grpTotals.Controls.Add(_lblTotalCosts);
            _grpTotals.Controls.Add(_txtPartsCostTotal);
            _grpTotals.Controls.Add(_txtBuilderCharge);
            _grpTotals.Controls.Add(_lblTotalBuilderCharge);
            _grpTotals.Controls.Add(_txtBuilderMarkup);
            _grpTotals.Controls.Add(_lblBuilderMarkup);
            _grpTotals.Controls.Add(_txtBuilderCost);
            _grpTotals.Controls.Add(_lblBuilderCost);
            _grpTotals.Controls.Add(_txtElectricianCharge);
            _grpTotals.Controls.Add(_lblTotalElectricianCharge);
            _grpTotals.Controls.Add(_txtElectricianMarkup);
            _grpTotals.Controls.Add(_lblElectricianMarkup);
            _grpTotals.Controls.Add(_txtElectricianCost);
            _grpTotals.Controls.Add(_lblElectricianCost);
            _grpTotals.Controls.Add(_txtInstallerCharge);
            _grpTotals.Controls.Add(_lblTotalInstallerCharge);
            _grpTotals.Controls.Add(_txtInstallerMarkup);
            _grpTotals.Controls.Add(_lblInstallerMarkup);
            _grpTotals.Controls.Add(_txtInstallerCost);
            _grpTotals.Controls.Add(_lblInstallerCost);
            _grpTotals.Controls.Add(_txtScheduleRatesCostTotal);
            _grpTotals.Controls.Add(_lblTotalSORCharge);
            _grpTotals.Controls.Add(_txtScheduleRateMarkup);
            _grpTotals.Controls.Add(_lblSORMarkup);
            _grpTotals.Controls.Add(_txtScheduleRatesCost);
            _grpTotals.Controls.Add(_lblSORCost);
            _grpTotals.Controls.Add(_lblTotalPartsCharge);
            _grpTotals.Controls.Add(_txtPartsProductsMarkup);
            _grpTotals.Controls.Add(_lblPartsMarkup);
            _grpTotals.Controls.Add(_txtBOC);
            _grpTotals.Controls.Add(_txtPartsCost);
            _grpTotals.Controls.Add(_lblPartsCost);
            _grpTotals.Font = new Font("Verdana", 8.25F);
            _grpTotals.Location = new Point(579, 490);
            _grpTotals.Name = "grpTotals";
            _grpTotals.Size = new Size(592, 207);
            _grpTotals.TabIndex = 64;
            _grpTotals.TabStop = false;
            _grpTotals.Text = "Summary Of Quote";
            // 
            // txtOriginalQuote
            // 
            _txtOriginalQuote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtOriginalQuote.Enabled = false;
            _txtOriginalQuote.Font = new Font("Verdana", 8.25F);
            _txtOriginalQuote.Location = new Point(292, 10);
            _txtOriginalQuote.MaxLength = 50;
            _txtOriginalQuote.Name = "txtOriginalQuote";
            _txtOriginalQuote.ReadOnly = true;
            _txtOriginalQuote.Size = new Size(99, 21);
            _txtOriginalQuote.TabIndex = 94;
            // 
            // lblOriginalQuote
            // 
            _lblOriginalQuote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblOriginalQuote.Font = new Font("Verdana", 8.25F);
            _lblOriginalQuote.Location = new Point(136, 9);
            _lblOriginalQuote.Name = "lblOriginalQuote";
            _lblOriginalQuote.Size = new Size(172, 23);
            _lblOriginalQuote.TabIndex = 95;
            _lblOriginalQuote.Text = "Original Quote (ex VAT)";
            _lblOriginalQuote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtGrandTotal
            // 
            _txtGrandTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtGrandTotal.Enabled = false;
            _txtGrandTotal.Font = new Font("Verdana", 8.25F);
            _txtGrandTotal.Location = new Point(41, 183);
            _txtGrandTotal.MaxLength = 50;
            _txtGrandTotal.Name = "txtGrandTotal";
            _txtGrandTotal.Size = new Size(70, 21);
            _txtGrandTotal.TabIndex = 87;
            // 
            // chkSORCharge
            // 
            _chkSORCharge.AutoSize = true;
            _chkSORCharge.Location = new Point(9, 17);
            _chkSORCharge.Name = "chkSORCharge";
            _chkSORCharge.Size = new Size(97, 17);
            _chkSORCharge.TabIndex = 93;
            _chkSORCharge.Text = "SOR Charge";
            _chkSORCharge.UseVisualStyleBackColor = true;
            // 
            // lblBOC
            // 
            _lblBOC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblBOC.Font = new Font("Verdana", 8.25F);
            _lblBOC.Location = new Point(461, 183);
            _lblBOC.Name = "lblBOC";
            _lblBOC.Size = new Size(51, 19);
            _lblBOC.TabIndex = 92;
            _lblBOC.Text = "B.O.C";
            _lblBOC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDeposit
            // 
            _txtDeposit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtDeposit.Enabled = false;
            _txtDeposit.Font = new Font("Verdana", 8.25F);
            _txtDeposit.Location = new Point(397, 183);
            _txtDeposit.MaxLength = 50;
            _txtDeposit.Name = "txtDeposit";
            _txtDeposit.Size = new Size(64, 21);
            _txtDeposit.TabIndex = 91;
            // 
            // lblDeposit
            // 
            _lblDeposit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblDeposit.Font = new Font("Verdana", 8.25F);
            _lblDeposit.Location = new Point(346, 184);
            _lblDeposit.Name = "lblDeposit";
            _lblDeposit.Size = new Size(51, 19);
            _lblDeposit.TabIndex = 90;
            _lblDeposit.Text = "Deposit";
            _lblDeposit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtincVAT
            // 
            _txtincVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtincVAT.Enabled = false;
            _txtincVAT.Font = new Font("Verdana", 8.25F);
            _txtincVAT.Location = new Point(275, 183);
            _txtincVAT.MaxLength = 50;
            _txtincVAT.Name = "txtincVAT";
            _txtincVAT.ReadOnly = true;
            _txtincVAT.Size = new Size(65, 21);
            _txtincVAT.TabIndex = 89;
            // 
            // lblIncVAT
            // 
            _lblIncVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblIncVAT.Font = new Font("Verdana", 8.25F);
            _lblIncVAT.Location = new Point(218, 184);
            _lblIncVAT.Name = "lblIncVAT";
            _lblIncVAT.Size = new Size(68, 17);
            _lblIncVAT.TabIndex = 88;
            _lblIncVAT.Text = "inc VAT:";
            _lblIncVAT.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboVAT
            // 
            _cboVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboVAT.Cursor = Cursors.Hand;
            _cboVAT.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVAT.Font = new Font("Verdana", 8.25F);
            _cboVAT.Location = new Point(138, 183);
            _cboVAT.Name = "cboVAT";
            _cboVAT.Size = new Size(78, 21);
            _cboVAT.TabIndex = 22;
            _cboVAT.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            // 
            // lblVAT
            // 
            _lblVAT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblVAT.Font = new Font("Verdana", 8.25F);
            _lblVAT.Location = new Point(111, 185);
            _lblVAT.Name = "lblVAT";
            _lblVAT.Size = new Size(37, 15);
            _lblVAT.TabIndex = 21;
            _lblVAT.Text = "VAT";
            // 
            // txtTotalCosts
            // 
            _txtTotalCosts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtTotalCosts.Enabled = false;
            _txtTotalCosts.Font = new Font("Verdana", 8.25F);
            _txtTotalCosts.Location = new Point(138, 159);
            _txtTotalCosts.MaxLength = 50;
            _txtTotalCosts.Name = "txtTotalCosts";
            _txtTotalCosts.ReadOnly = true;
            _txtTotalCosts.Size = new Size(78, 21);
            _txtTotalCosts.TabIndex = 81;
            // 
            // lblSale
            // 
            _lblSale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblSale.Font = new Font("Verdana", 8.25F);
            _lblSale.Location = new Point(9, 183);
            _lblSale.Name = "lblSale";
            _lblSale.Size = new Size(33, 19);
            _lblSale.TabIndex = 86;
            _lblSale.Text = "Sale";
            _lblSale.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtProfitPound
            // 
            _txtProfitPound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtProfitPound.Enabled = false;
            _txtProfitPound.Font = new Font("Verdana", 8.25F);
            _txtProfitPound.Location = new Point(365, 159);
            _txtProfitPound.MaxLength = 50;
            _txtProfitPound.Name = "txtProfitPound";
            _txtProfitPound.ReadOnly = true;
            _txtProfitPound.Size = new Size(64, 21);
            _txtProfitPound.TabIndex = 85;
            // 
            // lblProfitSlash
            // 
            _lblProfitSlash.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblProfitSlash.Font = new Font("Verdana", 8.25F);
            _lblProfitSlash.Location = new Point(347, 157);
            _lblProfitSlash.Name = "lblProfitSlash";
            _lblProfitSlash.Size = new Size(10, 23);
            _lblProfitSlash.TabIndex = 84;
            _lblProfitSlash.Text = "/";
            _lblProfitSlash.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtProfitPerc
            // 
            _txtProfitPerc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtProfitPerc.Enabled = false;
            _txtProfitPerc.Font = new Font("Verdana", 8.25F);
            _txtProfitPerc.Location = new Point(292, 158);
            _txtProfitPerc.MaxLength = 50;
            _txtProfitPerc.Name = "txtProfitPerc";
            _txtProfitPerc.ReadOnly = true;
            _txtProfitPerc.Size = new Size(48, 21);
            _txtProfitPerc.TabIndex = 83;
            // 
            // lblProfit
            // 
            _lblProfit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblProfit.Font = new Font("Verdana", 8.25F);
            _lblProfit.Location = new Point(218, 156);
            _lblProfit.Name = "lblProfit";
            _lblProfit.Size = new Size(45, 23);
            _lblProfit.TabIndex = 82;
            _lblProfit.Text = "Profit";
            _lblProfit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalCosts
            // 
            _lblTotalCosts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblTotalCosts.Font = new Font("Verdana", 8.25F);
            _lblTotalCosts.Location = new Point(9, 156);
            _lblTotalCosts.Name = "lblTotalCosts";
            _lblTotalCosts.Size = new Size(102, 23);
            _lblTotalCosts.TabIndex = 80;
            _lblTotalCosts.Text = "Total Costs";
            _lblTotalCosts.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPartsCostTotal
            // 
            _txtPartsCostTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtPartsCostTotal.Enabled = false;
            _txtPartsCostTotal.Font = new Font("Verdana", 8.25F);
            _txtPartsCostTotal.Location = new Point(512, 39);
            _txtPartsCostTotal.Name = "txtPartsCostTotal";
            _txtPartsCostTotal.ReadOnly = true;
            _txtPartsCostTotal.Size = new Size(72, 21);
            _txtPartsCostTotal.TabIndex = 9;
            // 
            // txtBuilderCharge
            // 
            _txtBuilderCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtBuilderCharge.Enabled = false;
            _txtBuilderCharge.Font = new Font("Verdana", 8.25F);
            _txtBuilderCharge.Location = new Point(512, 135);
            _txtBuilderCharge.Name = "txtBuilderCharge";
            _txtBuilderCharge.ReadOnly = true;
            _txtBuilderCharge.Size = new Size(72, 21);
            _txtBuilderCharge.TabIndex = 76;
            // 
            // lblTotalBuilderCharge
            // 
            _lblTotalBuilderCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblTotalBuilderCharge.Font = new Font("Verdana", 8.25F);
            _lblTotalBuilderCharge.Location = new Point(344, 133);
            _lblTotalBuilderCharge.Name = "lblTotalBuilderCharge";
            _lblTotalBuilderCharge.Size = new Size(168, 23);
            _lblTotalBuilderCharge.TabIndex = 79;
            _lblTotalBuilderCharge.Text = "Total Builder Charge";
            _lblTotalBuilderCharge.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtBuilderMarkup
            // 
            _txtBuilderMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtBuilderMarkup.Font = new Font("Verdana", 8.25F);
            _txtBuilderMarkup.Location = new Point(292, 135);
            _txtBuilderMarkup.Name = "txtBuilderMarkup";
            _txtBuilderMarkup.Size = new Size(48, 21);
            _txtBuilderMarkup.TabIndex = 75;
            // 
            // lblBuilderMarkup
            // 
            _lblBuilderMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblBuilderMarkup.Font = new Font("Verdana", 8.25F);
            _lblBuilderMarkup.Location = new Point(219, 135);
            _lblBuilderMarkup.Name = "lblBuilderMarkup";
            _lblBuilderMarkup.Size = new Size(80, 20);
            _lblBuilderMarkup.TabIndex = 78;
            _lblBuilderMarkup.Text = "Markup (%)";
            _lblBuilderMarkup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtBuilderCost
            // 
            _txtBuilderCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtBuilderCost.Enabled = false;
            _txtBuilderCost.Font = new Font("Verdana", 8.25F);
            _txtBuilderCost.Location = new Point(138, 135);
            _txtBuilderCost.MaxLength = 50;
            _txtBuilderCost.Name = "txtBuilderCost";
            _txtBuilderCost.Size = new Size(78, 21);
            _txtBuilderCost.TabIndex = 74;
            // 
            // lblBuilderCost
            // 
            _lblBuilderCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblBuilderCost.Font = new Font("Verdana", 8.25F);
            _lblBuilderCost.Location = new Point(9, 133);
            _lblBuilderCost.Name = "lblBuilderCost";
            _lblBuilderCost.Size = new Size(147, 23);
            _lblBuilderCost.TabIndex = 77;
            _lblBuilderCost.Text = "Builder Cost";
            _lblBuilderCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtElectricianCharge
            // 
            _txtElectricianCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtElectricianCharge.Enabled = false;
            _txtElectricianCharge.Font = new Font("Verdana", 8.25F);
            _txtElectricianCharge.Location = new Point(512, 112);
            _txtElectricianCharge.Name = "txtElectricianCharge";
            _txtElectricianCharge.ReadOnly = true;
            _txtElectricianCharge.Size = new Size(72, 21);
            _txtElectricianCharge.TabIndex = 67;
            // 
            // lblTotalElectricianCharge
            // 
            _lblTotalElectricianCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblTotalElectricianCharge.Font = new Font("Verdana", 8.25F);
            _lblTotalElectricianCharge.Location = new Point(344, 109);
            _lblTotalElectricianCharge.Name = "lblTotalElectricianCharge";
            _lblTotalElectricianCharge.Size = new Size(168, 23);
            _lblTotalElectricianCharge.TabIndex = 73;
            _lblTotalElectricianCharge.Text = "Total Electrician Charge";
            _lblTotalElectricianCharge.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtElectricianMarkup
            // 
            _txtElectricianMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtElectricianMarkup.Font = new Font("Verdana", 8.25F);
            _txtElectricianMarkup.Location = new Point(292, 112);
            _txtElectricianMarkup.Name = "txtElectricianMarkup";
            _txtElectricianMarkup.Size = new Size(48, 21);
            _txtElectricianMarkup.TabIndex = 66;
            // 
            // lblElectricianMarkup
            // 
            _lblElectricianMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblElectricianMarkup.Font = new Font("Verdana", 8.25F);
            _lblElectricianMarkup.Location = new Point(219, 109);
            _lblElectricianMarkup.Name = "lblElectricianMarkup";
            _lblElectricianMarkup.Size = new Size(80, 23);
            _lblElectricianMarkup.TabIndex = 72;
            _lblElectricianMarkup.Text = "Markup (%)";
            _lblElectricianMarkup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtElectricianCost
            // 
            _txtElectricianCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtElectricianCost.Enabled = false;
            _txtElectricianCost.Font = new Font("Verdana", 8.25F);
            _txtElectricianCost.Location = new Point(138, 112);
            _txtElectricianCost.MaxLength = 50;
            _txtElectricianCost.Name = "txtElectricianCost";
            _txtElectricianCost.Size = new Size(78, 21);
            _txtElectricianCost.TabIndex = 65;
            // 
            // lblElectricianCost
            // 
            _lblElectricianCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblElectricianCost.Font = new Font("Verdana", 8.25F);
            _lblElectricianCost.Location = new Point(9, 110);
            _lblElectricianCost.Name = "lblElectricianCost";
            _lblElectricianCost.Size = new Size(147, 23);
            _lblElectricianCost.TabIndex = 71;
            _lblElectricianCost.Text = "Electrician Cost";
            _lblElectricianCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtInstallerCharge
            // 
            _txtInstallerCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtInstallerCharge.Enabled = false;
            _txtInstallerCharge.Font = new Font("Verdana", 8.25F);
            _txtInstallerCharge.Location = new Point(512, 88);
            _txtInstallerCharge.Name = "txtInstallerCharge";
            _txtInstallerCharge.ReadOnly = true;
            _txtInstallerCharge.Size = new Size(72, 21);
            _txtInstallerCharge.TabIndex = 64;
            // 
            // lblTotalInstallerCharge
            // 
            _lblTotalInstallerCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblTotalInstallerCharge.Font = new Font("Verdana", 8.25F);
            _lblTotalInstallerCharge.Location = new Point(344, 86);
            _lblTotalInstallerCharge.Name = "lblTotalInstallerCharge";
            _lblTotalInstallerCharge.Size = new Size(160, 23);
            _lblTotalInstallerCharge.TabIndex = 70;
            _lblTotalInstallerCharge.Text = "Total Installer Charge";
            _lblTotalInstallerCharge.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtInstallerMarkup
            // 
            _txtInstallerMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtInstallerMarkup.Font = new Font("Verdana", 8.25F);
            _txtInstallerMarkup.Location = new Point(292, 88);
            _txtInstallerMarkup.Name = "txtInstallerMarkup";
            _txtInstallerMarkup.Size = new Size(48, 21);
            _txtInstallerMarkup.TabIndex = 63;
            // 
            // lblInstallerMarkup
            // 
            _lblInstallerMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblInstallerMarkup.Font = new Font("Verdana", 8.25F);
            _lblInstallerMarkup.Location = new Point(219, 86);
            _lblInstallerMarkup.Name = "lblInstallerMarkup";
            _lblInstallerMarkup.Size = new Size(80, 23);
            _lblInstallerMarkup.TabIndex = 69;
            _lblInstallerMarkup.Text = "Markup (%)";
            _lblInstallerMarkup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtInstallerCost
            // 
            _txtInstallerCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtInstallerCost.Enabled = false;
            _txtInstallerCost.Font = new Font("Verdana", 8.25F);
            _txtInstallerCost.Location = new Point(138, 88);
            _txtInstallerCost.MaxLength = 50;
            _txtInstallerCost.Name = "txtInstallerCost";
            _txtInstallerCost.Size = new Size(78, 21);
            _txtInstallerCost.TabIndex = 62;
            // 
            // lblInstallerCost
            // 
            _lblInstallerCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblInstallerCost.Font = new Font("Verdana", 8.25F);
            _lblInstallerCost.Location = new Point(9, 86);
            _lblInstallerCost.Name = "lblInstallerCost";
            _lblInstallerCost.Size = new Size(136, 23);
            _lblInstallerCost.TabIndex = 68;
            _lblInstallerCost.Text = "Installer Cost";
            _lblInstallerCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtScheduleRatesCostTotal
            // 
            _txtScheduleRatesCostTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtScheduleRatesCostTotal.Enabled = false;
            _txtScheduleRatesCostTotal.Font = new Font("Verdana", 8.25F);
            _txtScheduleRatesCostTotal.Location = new Point(512, 63);
            _txtScheduleRatesCostTotal.Name = "txtScheduleRatesCostTotal";
            _txtScheduleRatesCostTotal.ReadOnly = true;
            _txtScheduleRatesCostTotal.Size = new Size(72, 21);
            _txtScheduleRatesCostTotal.TabIndex = 12;
            // 
            // lblTotalSORCharge
            // 
            _lblTotalSORCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblTotalSORCharge.Font = new Font("Verdana", 8.25F);
            _lblTotalSORCharge.Location = new Point(344, 62);
            _lblTotalSORCharge.Name = "lblTotalSORCharge";
            _lblTotalSORCharge.Size = new Size(168, 23);
            _lblTotalSORCharge.TabIndex = 61;
            _lblTotalSORCharge.Text = "Total SOR Charge";
            _lblTotalSORCharge.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtScheduleRateMarkup
            // 
            _txtScheduleRateMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtScheduleRateMarkup.Font = new Font("Verdana", 8.25F);
            _txtScheduleRateMarkup.Location = new Point(292, 63);
            _txtScheduleRateMarkup.Name = "txtScheduleRateMarkup";
            _txtScheduleRateMarkup.Size = new Size(48, 21);
            _txtScheduleRateMarkup.TabIndex = 11;
            // 
            // lblSORMarkup
            // 
            _lblSORMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblSORMarkup.Font = new Font("Verdana", 8.25F);
            _lblSORMarkup.Location = new Point(219, 60);
            _lblSORMarkup.Name = "lblSORMarkup";
            _lblSORMarkup.Size = new Size(80, 23);
            _lblSORMarkup.TabIndex = 59;
            _lblSORMarkup.Text = "Markup (%)";
            _lblSORMarkup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtScheduleRatesCost
            // 
            _txtScheduleRatesCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtScheduleRatesCost.Enabled = false;
            _txtScheduleRatesCost.Font = new Font("Verdana", 8.25F);
            _txtScheduleRatesCost.Location = new Point(138, 63);
            _txtScheduleRatesCost.MaxLength = 50;
            _txtScheduleRatesCost.Name = "txtScheduleRatesCost";
            _txtScheduleRatesCost.Size = new Size(78, 21);
            _txtScheduleRatesCost.TabIndex = 10;
            // 
            // lblSORCost
            // 
            _lblSORCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblSORCost.Font = new Font("Verdana", 8.25F);
            _lblSORCost.Location = new Point(9, 60);
            _lblSORCost.Name = "lblSORCost";
            _lblSORCost.Size = new Size(147, 23);
            _lblSORCost.TabIndex = 57;
            _lblSORCost.Text = "SOR Cost";
            _lblSORCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalPartsCharge
            // 
            _lblTotalPartsCharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblTotalPartsCharge.Font = new Font("Verdana", 8.25F);
            _lblTotalPartsCharge.Location = new Point(344, 39);
            _lblTotalPartsCharge.Name = "lblTotalPartsCharge";
            _lblTotalPartsCharge.Size = new Size(181, 23);
            _lblTotalPartsCharge.TabIndex = 54;
            _lblTotalPartsCharge.Text = "Total Parts Charge";
            _lblTotalPartsCharge.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPartsProductsMarkup
            // 
            _txtPartsProductsMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtPartsProductsMarkup.Font = new Font("Verdana", 8.25F);
            _txtPartsProductsMarkup.Location = new Point(292, 39);
            _txtPartsProductsMarkup.Name = "txtPartsProductsMarkup";
            _txtPartsProductsMarkup.Size = new Size(48, 21);
            _txtPartsProductsMarkup.TabIndex = 8;
            // 
            // lblPartsMarkup
            // 
            _lblPartsMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblPartsMarkup.Font = new Font("Verdana", 8.25F);
            _lblPartsMarkup.Location = new Point(219, 37);
            _lblPartsMarkup.Name = "lblPartsMarkup";
            _lblPartsMarkup.Size = new Size(80, 23);
            _lblPartsMarkup.TabIndex = 52;
            _lblPartsMarkup.Text = "Markup (%)";
            _lblPartsMarkup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtBOC
            // 
            _txtBOC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtBOC.Font = new Font("Verdana", 8.25F);
            _txtBOC.Location = new Point(512, 183);
            _txtBOC.MaxLength = 50;
            _txtBOC.Name = "txtBOC";
            _txtBOC.ReadOnly = true;
            _txtBOC.Size = new Size(72, 21);
            _txtBOC.TabIndex = 16;
            // 
            // txtPartsCost
            // 
            _txtPartsCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtPartsCost.Enabled = false;
            _txtPartsCost.Font = new Font("Verdana", 8.25F);
            _txtPartsCost.Location = new Point(138, 39);
            _txtPartsCost.MaxLength = 50;
            _txtPartsCost.Name = "txtPartsCost";
            _txtPartsCost.Size = new Size(78, 21);
            _txtPartsCost.TabIndex = 7;
            // 
            // lblPartsCost
            // 
            _lblPartsCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblPartsCost.Font = new Font("Verdana", 8.25F);
            _lblPartsCost.Location = new Point(9, 37);
            _lblPartsCost.Name = "lblPartsCost";
            _lblPartsCost.Size = new Size(136, 23);
            _lblPartsCost.TabIndex = 50;
            _lblPartsCost.Text = "Parts Cost";
            _lblPartsCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpParts
            // 
            _grpParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _grpParts.Controls.Add(_btnRemovePartProduct);
            _grpParts.Controls.Add(_btnFindPart);
            _grpParts.Controls.Add(_dgPartsAndProducts);
            _grpParts.Font = new Font("Verdana", 8.25F);
            _grpParts.Location = new Point(579, 230);
            _grpParts.Name = "grpParts";
            _grpParts.Size = new Size(592, 254);
            _grpParts.TabIndex = 8;
            _grpParts.TabStop = false;
            _grpParts.Text = "Parts && Products Required";
            // 
            // btnRemovePartProduct
            // 
            _btnRemovePartProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemovePartProduct.Font = new Font("Verdana", 8.25F);
            _btnRemovePartProduct.Location = new Point(481, 226);
            _btnRemovePartProduct.Name = "btnRemovePartProduct";
            _btnRemovePartProduct.Size = new Size(96, 22);
            _btnRemovePartProduct.TabIndex = 3;
            _btnRemovePartProduct.Text = "Remove";
            // 
            // btnFindPart
            // 
            _btnFindPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnFindPart.Font = new Font("Verdana", 8.25F);
            _btnFindPart.Location = new Point(9, 226);
            _btnFindPart.Name = "btnFindPart";
            _btnFindPart.Size = new Size(88, 22);
            _btnFindPart.TabIndex = 1;
            _btnFindPart.Text = "Add Part";
            // 
            // dgPartsAndProducts
            // 
            _dgPartsAndProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgPartsAndProducts.DataMember = "";
            _dgPartsAndProducts.Font = new Font("Verdana", 8.25F);
            _dgPartsAndProducts.HeaderForeColor = SystemColors.ControlText;
            _dgPartsAndProducts.Location = new Point(12, 25);
            _dgPartsAndProducts.Name = "dgPartsAndProducts";
            _dgPartsAndProducts.Size = new Size(564, 195);
            _dgPartsAndProducts.TabIndex = 10;
            // 
            // dtpQuoteDate
            // 
            _dtpQuoteDate.CalendarFont = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dtpQuoteDate.Font = new Font("Verdana", 8.25F);
            _dtpQuoteDate.Location = new Point(560, 2);
            _dtpQuoteDate.Name = "dtpQuoteDate";
            _dtpQuoteDate.Size = new Size(151, 21);
            _dtpQuoteDate.TabIndex = 2;
            _dtpQuoteDate.Value = new DateTime(2007, 8, 13, 15, 56, 20, 616);
            // 
            // txtSiteName
            // 
            _txtSiteName.Font = new Font("Verdana", 8.25F);
            _txtSiteName.Location = new Point(77, 38);
            _txtSiteName.Name = "txtSiteName";
            _txtSiteName.ReadOnly = true;
            _txtSiteName.Size = new Size(172, 21);
            _txtSiteName.TabIndex = 49;
            _txtSiteName.TabStop = false;
            // 
            // lblProperty
            // 
            _lblProperty.Font = new Font("Verdana", 8.25F);
            _lblProperty.Location = new Point(8, 37);
            _lblProperty.Name = "lblProperty";
            _lblProperty.Size = new Size(80, 23);
            _lblProperty.TabIndex = 55;
            _lblProperty.Text = "Property:";
            // 
            // lblQuoteRef
            // 
            _lblQuoteRef.Font = new Font("Verdana", 8.25F);
            _lblQuoteRef.Location = new Point(251, 37);
            _lblQuoteRef.Name = "lblQuoteRef";
            _lblQuoteRef.Size = new Size(73, 23);
            _lblQuoteRef.TabIndex = 57;
            _lblQuoteRef.Text = "Quote Ref:";
            // 
            // txtCustomerName
            // 
            _txtCustomerName.Font = new Font("Verdana", 8.25F);
            _txtCustomerName.Location = new Point(77, 3);
            _txtCustomerName.Name = "txtCustomerName";
            _txtCustomerName.ReadOnly = true;
            _txtCustomerName.Size = new Size(172, 21);
            _txtCustomerName.TabIndex = 48;
            _txtCustomerName.TabStop = false;
            // 
            // gpOtherLabour
            // 
            _gpOtherLabour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _gpOtherLabour.Controls.Add(_txtBuilderArrivalHour);
            _gpOtherLabour.Controls.Add(_lblBuilderHour);
            _gpOtherLabour.Controls.Add(_txtBuilderArrivalDay);
            _gpOtherLabour.Controls.Add(_lblArrivalDay);
            _gpOtherLabour.Controls.Add(_txtBuilderHours);
            _gpOtherLabour.Controls.Add(_txtBuilderNotes);
            _gpOtherLabour.Controls.Add(_lblBuilderNotes);
            _gpOtherLabour.Controls.Add(_lblBuilderLabourHours);
            _gpOtherLabour.Controls.Add(_lblBuilderLabour);
            _gpOtherLabour.Controls.Add(_txtElectricianArrivalHour);
            _gpOtherLabour.Controls.Add(_lblElectricianHour);
            _gpOtherLabour.Controls.Add(_txtElectricianArrivalDay);
            _gpOtherLabour.Controls.Add(_lblElectricianArrivalDay);
            _gpOtherLabour.Controls.Add(_txtElectricianHours);
            _gpOtherLabour.Controls.Add(_txtElectricianNotes);
            _gpOtherLabour.Controls.Add(_lblElectricianNotes);
            _gpOtherLabour.Controls.Add(_lblElectricianPackHours);
            _gpOtherLabour.Controls.Add(_lblElectOr);
            _gpOtherLabour.Controls.Add(_cboElectricalPack);
            _gpOtherLabour.Controls.Add(_lblElectricianPack);
            _gpOtherLabour.Font = new Font("Verdana", 8.25F);
            _gpOtherLabour.Location = new Point(579, 72);
            _gpOtherLabour.Name = "gpOtherLabour";
            _gpOtherLabour.Size = new Size(592, 152);
            _gpOtherLabour.TabIndex = 65;
            _gpOtherLabour.TabStop = false;
            _gpOtherLabour.Text = "Other Labour";
            // 
            // txtBuilderArrivalHour
            // 
            _txtBuilderArrivalHour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtBuilderArrivalHour.Font = new Font("Verdana", 8.25F);
            _txtBuilderArrivalHour.Location = new Point(543, 83);
            _txtBuilderArrivalHour.MaxLength = 50;
            _txtBuilderArrivalHour.Name = "txtBuilderArrivalHour";
            _txtBuilderArrivalHour.Size = new Size(33, 21);
            _txtBuilderArrivalHour.TabIndex = 40;
            _txtBuilderArrivalHour.Tag = "SystemScheduleOfRate.Code";
            // 
            // lblBuilderHour
            // 
            _lblBuilderHour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblBuilderHour.Font = new Font("Verdana", 8.25F);
            _lblBuilderHour.Location = new Point(503, 86);
            _lblBuilderHour.Name = "lblBuilderHour";
            _lblBuilderHour.Size = new Size(40, 20);
            _lblBuilderHour.TabIndex = 39;
            _lblBuilderHour.Text = "Hour";
            // 
            // txtBuilderArrivalDay
            // 
            _txtBuilderArrivalDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtBuilderArrivalDay.Font = new Font("Verdana", 8.25F);
            _txtBuilderArrivalDay.Location = new Point(467, 83);
            _txtBuilderArrivalDay.MaxLength = 50;
            _txtBuilderArrivalDay.Name = "txtBuilderArrivalDay";
            _txtBuilderArrivalDay.Size = new Size(33, 21);
            _txtBuilderArrivalDay.TabIndex = 38;
            _txtBuilderArrivalDay.Tag = "SystemScheduleOfRate.Code";
            // 
            // lblArrivalDay
            // 
            _lblArrivalDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblArrivalDay.Font = new Font("Verdana", 8.25F);
            _lblArrivalDay.Location = new Point(394, 86);
            _lblArrivalDay.Name = "lblArrivalDay";
            _lblArrivalDay.Size = new Size(77, 20);
            _lblArrivalDay.TabIndex = 37;
            _lblArrivalDay.Text = "Arrival Day";
            // 
            // txtBuilderHours
            // 
            _txtBuilderHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtBuilderHours.Font = new Font("Verdana", 8.25F);
            _txtBuilderHours.Location = new Point(123, 82);
            _txtBuilderHours.MaxLength = 50;
            _txtBuilderHours.Name = "txtBuilderHours";
            _txtBuilderHours.Size = new Size(58, 21);
            _txtBuilderHours.TabIndex = 33;
            _txtBuilderHours.Tag = "SystemScheduleOfRate.Code";
            // 
            // txtBuilderNotes
            // 
            _txtBuilderNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtBuilderNotes.Font = new Font("Verdana", 8.25F);
            _txtBuilderNotes.Location = new Point(123, 109);
            _txtBuilderNotes.MaxLength = 50;
            _txtBuilderNotes.Multiline = true;
            _txtBuilderNotes.Name = "txtBuilderNotes";
            _txtBuilderNotes.Size = new Size(453, 30);
            _txtBuilderNotes.TabIndex = 30;
            _txtBuilderNotes.Tag = "SystemScheduleOfRate.Code";
            // 
            // lblBuilderNotes
            // 
            _lblBuilderNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblBuilderNotes.Font = new Font("Verdana", 8.25F);
            _lblBuilderNotes.Location = new Point(8, 110);
            _lblBuilderNotes.Name = "lblBuilderNotes";
            _lblBuilderNotes.Size = new Size(109, 20);
            _lblBuilderNotes.TabIndex = 36;
            _lblBuilderNotes.Text = "Builder Notes";
            // 
            // lblBuilderLabourHours
            // 
            _lblBuilderLabourHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblBuilderLabourHours.Font = new Font("Verdana", 8.25F);
            _lblBuilderLabourHours.Location = new Point(184, 85);
            _lblBuilderLabourHours.Name = "lblBuilderLabourHours";
            _lblBuilderLabourHours.Size = new Size(32, 20);
            _lblBuilderLabourHours.TabIndex = 35;
            _lblBuilderLabourHours.Text = "Hrs";
            // 
            // lblBuilderLabour
            // 
            _lblBuilderLabour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblBuilderLabour.Font = new Font("Verdana", 8.25F);
            _lblBuilderLabour.Location = new Point(8, 85);
            _lblBuilderLabour.Name = "lblBuilderLabour";
            _lblBuilderLabour.Size = new Size(109, 20);
            _lblBuilderLabour.TabIndex = 32;
            _lblBuilderLabour.Text = "Builder Labour";
            // 
            // txtElectricianArrivalHour
            // 
            _txtElectricianArrivalHour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtElectricianArrivalHour.Font = new Font("Verdana", 8.25F);
            _txtElectricianArrivalHour.Location = new Point(543, 15);
            _txtElectricianArrivalHour.MaxLength = 50;
            _txtElectricianArrivalHour.Name = "txtElectricianArrivalHour";
            _txtElectricianArrivalHour.Size = new Size(33, 21);
            _txtElectricianArrivalHour.TabIndex = 29;
            _txtElectricianArrivalHour.Tag = "SystemScheduleOfRate.Code";
            // 
            // lblElectricianHour
            // 
            _lblElectricianHour.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblElectricianHour.Font = new Font("Verdana", 8.25F);
            _lblElectricianHour.Location = new Point(503, 18);
            _lblElectricianHour.Name = "lblElectricianHour";
            _lblElectricianHour.Size = new Size(40, 20);
            _lblElectricianHour.TabIndex = 28;
            _lblElectricianHour.Text = "Hour";
            // 
            // txtElectricianArrivalDay
            // 
            _txtElectricianArrivalDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtElectricianArrivalDay.Font = new Font("Verdana", 8.25F);
            _txtElectricianArrivalDay.Location = new Point(467, 15);
            _txtElectricianArrivalDay.MaxLength = 50;
            _txtElectricianArrivalDay.Name = "txtElectricianArrivalDay";
            _txtElectricianArrivalDay.Size = new Size(33, 21);
            _txtElectricianArrivalDay.TabIndex = 27;
            _txtElectricianArrivalDay.Tag = "SystemScheduleOfRate.Code";
            // 
            // lblElectricianArrivalDay
            // 
            _lblElectricianArrivalDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblElectricianArrivalDay.Font = new Font("Verdana", 8.25F);
            _lblElectricianArrivalDay.Location = new Point(394, 18);
            _lblElectricianArrivalDay.Name = "lblElectricianArrivalDay";
            _lblElectricianArrivalDay.Size = new Size(77, 20);
            _lblElectricianArrivalDay.TabIndex = 26;
            _lblElectricianArrivalDay.Text = "Arrival Day";
            // 
            // txtElectricianHours
            // 
            _txtElectricianHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtElectricianHours.Font = new Font("Verdana", 8.25F);
            _txtElectricianHours.Location = new Point(265, 15);
            _txtElectricianHours.MaxLength = 50;
            _txtElectricianHours.Name = "txtElectricianHours";
            _txtElectricianHours.Size = new Size(58, 21);
            _txtElectricianHours.TabIndex = 22;
            _txtElectricianHours.Tag = "SystemScheduleOfRate.Code";
            // 
            // txtElectricianNotes
            // 
            _txtElectricianNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtElectricianNotes.Font = new Font("Verdana", 8.25F);
            _txtElectricianNotes.Location = new Point(123, 41);
            _txtElectricianNotes.MaxLength = 50;
            _txtElectricianNotes.Multiline = true;
            _txtElectricianNotes.Name = "txtElectricianNotes";
            _txtElectricianNotes.Size = new Size(453, 36);
            _txtElectricianNotes.TabIndex = 21;
            _txtElectricianNotes.Tag = "SystemScheduleOfRate.Code";
            // 
            // lblElectricianNotes
            // 
            _lblElectricianNotes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblElectricianNotes.Font = new Font("Verdana", 8.25F);
            _lblElectricianNotes.Location = new Point(8, 42);
            _lblElectricianNotes.Name = "lblElectricianNotes";
            _lblElectricianNotes.Size = new Size(109, 20);
            _lblElectricianNotes.TabIndex = 25;
            _lblElectricianNotes.Text = "Electrician Notes";
            // 
            // lblElectricianPackHours
            // 
            _lblElectricianPackHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblElectricianPackHours.Font = new Font("Verdana", 8.25F);
            _lblElectricianPackHours.Location = new Point(326, 18);
            _lblElectricianPackHours.Name = "lblElectricianPackHours";
            _lblElectricianPackHours.Size = new Size(32, 20);
            _lblElectricianPackHours.TabIndex = 24;
            _lblElectricianPackHours.Text = "Hrs";
            // 
            // lblElectOr
            // 
            _lblElectOr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblElectOr.Font = new Font("Verdana", 8.25F);
            _lblElectOr.Location = new Point(241, 18);
            _lblElectOr.Name = "lblElectOr";
            _lblElectOr.Size = new Size(31, 20);
            _lblElectOr.TabIndex = 23;
            _lblElectOr.Text = "Or";
            // 
            // cboElectricalPack
            // 
            _cboElectricalPack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboElectricalPack.Cursor = Cursors.Hand;
            _cboElectricalPack.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboElectricalPack.Font = new Font("Verdana", 8.25F);
            _cboElectricalPack.Location = new Point(123, 16);
            _cboElectricalPack.Name = "cboElectricalPack";
            _cboElectricalPack.Size = new Size(116, 21);
            _cboElectricalPack.TabIndex = 21;
            _cboElectricalPack.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            // 
            // lblElectricianPack
            // 
            _lblElectricianPack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblElectricianPack.Font = new Font("Verdana", 8.25F);
            _lblElectricianPack.Location = new Point(8, 17);
            _lblElectricianPack.Name = "lblElectricianPack";
            _lblElectricianPack.Size = new Size(109, 20);
            _lblElectricianPack.TabIndex = 21;
            _lblElectricianPack.Text = "Electrician Pack";
            // 
            // txtSurveyor
            // 
            _txtSurveyor.Font = new Font("Verdana", 8.25F);
            _txtSurveyor.Location = new Point(821, 2);
            _txtSurveyor.MaxLength = 50;
            _txtSurveyor.Name = "txtSurveyor";
            _txtSurveyor.ReadOnly = true;
            _txtSurveyor.Size = new Size(204, 21);
            _txtSurveyor.TabIndex = 66;
            // 
            // lblSurveyor
            // 
            _lblSurveyor.Font = new Font("Verdana", 8.25F);
            _lblSurveyor.Location = new Point(715, 6);
            _lblSurveyor.Name = "lblSurveyor";
            _lblSurveyor.Size = new Size(76, 23);
            _lblSurveyor.TabIndex = 67;
            _lblSurveyor.Text = "Surveyor";
            // 
            // lblLastChangedOn
            // 
            _lblLastChangedOn.Font = new Font("Verdana", 8.25F);
            _lblLastChangedOn.Location = new Point(714, 40);
            _lblLastChangedOn.Name = "lblLastChangedOn";
            _lblLastChangedOn.Size = new Size(106, 23);
            _lblLastChangedOn.TabIndex = 68;
            _lblLastChangedOn.Text = "Last Changed On";
            // 
            // txtChangedDate
            // 
            _txtChangedDate.Font = new Font("Verdana", 8.25F);
            _txtChangedDate.Location = new Point(821, 38);
            _txtChangedDate.MaxLength = 50;
            _txtChangedDate.Name = "txtChangedDate";
            _txtChangedDate.ReadOnly = true;
            _txtChangedDate.Size = new Size(66, 21);
            _txtChangedDate.TabIndex = 69;
            // 
            // lblChangedBy
            // 
            _lblChangedBy.Font = new Font("Verdana", 8.25F);
            _lblChangedBy.Location = new Point(890, 39);
            _lblChangedBy.Name = "lblChangedBy";
            _lblChangedBy.Size = new Size(29, 23);
            _lblChangedBy.TabIndex = 70;
            _lblChangedBy.Text = "by";
            // 
            // txtChangedBy
            // 
            _txtChangedBy.Font = new Font("Verdana", 8.25F);
            _txtChangedBy.Location = new Point(914, 38);
            _txtChangedBy.MaxLength = 50;
            _txtChangedBy.Name = "txtChangedBy";
            _txtChangedBy.ReadOnly = true;
            _txtChangedBy.Size = new Size(111, 21);
            _txtChangedBy.TabIndex = 71;
            // 
            // lblPurchaseDept
            // 
            _lblPurchaseDept.Font = new Font("Verdana", 8.25F);
            _lblPurchaseDept.Location = new Point(1031, 26);
            _lblPurchaseDept.Name = "lblPurchaseDept";
            _lblPurchaseDept.Size = new Size(125, 16);
            _lblPurchaseDept.TabIndex = 72;
            _lblPurchaseDept.Text = "Purchase Dept";
            _lblPurchaseDept.TextAlign = ContentAlignment.TopCenter;
            // 
            // cboDept
            // 
            _cboDept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboDept.Cursor = Cursors.Hand;
            _cboDept.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDept.Font = new Font("Verdana", 8.25F);
            _cboDept.Location = new Point(1039, 39);
            _cboDept.Name = "cboDept";
            _cboDept.Size = new Size(116, 21);
            _cboDept.TabIndex = 41;
            _cboDept.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
            // 
            // chkService
            // 
            _chkService.AutoSize = true;
            _chkService.Checked = true;
            _chkService.CheckState = CheckState.Checked;
            _chkService.Location = new Point(1039, 5);
            _chkService.Name = "chkService";
            _chkService.Size = new Size(53, 17);
            _chkService.TabIndex = 73;
            _chkService.Text = "Serv";
            _chkService.UseVisualStyleBackColor = true;
            // 
            // chkHOver
            // 
            _chkHOver.AutoSize = true;
            _chkHOver.Checked = true;
            _chkHOver.CheckState = CheckState.Checked;
            _chkHOver.Location = new Point(1098, 5);
            _chkHOver.Name = "chkHOver";
            _chkHOver.Size = new Size(66, 17);
            _chkHOver.TabIndex = 74;
            _chkHOver.Text = "H.Over";
            _chkHOver.UseVisualStyleBackColor = true;
            // 
            // UCQuoteJob
            // 
            Controls.Add(_chkHOver);
            Controls.Add(_chkService);
            Controls.Add(_cboDept);
            Controls.Add(_txtCustomerName);
            Controls.Add(_cboQuoteStatus);
            Controls.Add(_lblPurchaseDept);
            Controls.Add(_txtChangedBy);
            Controls.Add(_lblChangedBy);
            Controls.Add(_txtChangedDate);
            Controls.Add(_lblLastChangedOn);
            Controls.Add(_txtSurveyor);
            Controls.Add(_lblSurveyor);
            Controls.Add(_gpOtherLabour);
            Controls.Add(_grpRates);
            Controls.Add(_lblQuoteStatus);
            Controls.Add(_lblQuoteDate);
            Controls.Add(_grpJobItems);
            Controls.Add(_txtReference);
            Controls.Add(_cboJobType);
            Controls.Add(_lblJobType);
            Controls.Add(_lblCustomer);
            Controls.Add(_grpTotals);
            Controls.Add(_grpParts);
            Controls.Add(_dtpQuoteDate);
            Controls.Add(_txtSiteName);
            Controls.Add(_lblProperty);
            Controls.Add(_lblQuoteRef);
            Name = "UCQuoteJob";
            Size = new Size(1179, 705);
            _grpRates.ResumeLayout(false);
            _grpRates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRates).EndInit();
            _grpJobItems.ResumeLayout(false);
            _grpJobItems.PerformLayout();
            _grpTotals.ResumeLayout(false);
            _grpTotals.PerformLayout();
            _grpParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgPartsAndProducts).EndInit();
            _gpOtherLabour.ResumeLayout(false);
            _gpOtherLabour.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupPartsAndProductsDataGrid();
            SetupScheduleOfRatesDataGrid();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentQuoteJob;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        public event RefreshButtonEventHandler RefreshButton;

        public delegate void RefreshButtonEventHandler();

        private Entity.Sites.Site _CurrentSite;

        public Entity.Sites.Site CurrentSite
        {
            get
            {
                return _CurrentSite;
            }

            set
            {
                _CurrentSite = value;
                CurrentQuoteJob.SetSiteID = CurrentSite.SiteID;
                if (!(CurrentQuoteJob.Exists == true))
                {
                    CustomerCharge = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(CurrentSite.CustomerID);
                    if (!Information.IsNothing(CustomerCharge))
                    {
                        txtPartsProductsMarkup.Text = CustomerCharge.PartsMarkup + "%";
                        txtScheduleRateMarkup.Text = CustomerCharge.RatesMarkup + "%";
                    }

                    QuoteNumber = App.DB.QuoteJob.GetNextQuoteNumber();
                    if (!Information.IsNothing(QuoteNumber))
                    {
                        txtReference.Text = QuoteNumber.Prefix + QuoteNumber.JobNumber;
                    }
                }

                txtSiteName.Text = CurrentSite.Address1 + " " + CurrentSite.Address2 + ", " + CurrentSite.Postcode;
                txtCustomerName.Text = App.DB.Customer.Customer_Get(CurrentSite.CustomerID).Name;
                if (AssetsDataView is null)
                {
                    AssetsDataView = App.DB.Asset.Asset_GetForSite(CurrentSite.SiteID);
                }
            }
        }

        private Entity.CustomerCharges.CustomerCharge _CustomerCharge;

        public Entity.CustomerCharges.CustomerCharge CustomerCharge
        {
            get
            {
                return _CustomerCharge;
            }

            set
            {
                _CustomerCharge = value;
            }
        }

        private Entity.QuoteJobs.QuoteJob _CurrentQuoteJob;

        public Entity.QuoteJobs.QuoteJob CurrentQuoteJob
        {
            get
            {
                return _CurrentQuoteJob;
            }

            set
            {
                _CurrentQuoteJob = value;
                if (_CurrentQuoteJob is null)
                {
                    _CurrentQuoteJob = new Entity.QuoteJobs.QuoteJob();
                    _CurrentQuoteJob.Exists = false;
                    _CurrentQuoteJob.ScheduleOfRates = BuildUpScheduleOfRatesDataview();
                }

                dtpQuoteDate.Value = DateAndTime.Now;
                Loading = true;
                Populate();
                Loading = false;
                PartsAndProducts = CurrentQuoteJob.QuoteJobPartsAndProducts;
            }
        }

        private DataView _AssetsTable = null;

        public DataView AssetsDataView
        {
            get
            {
                return _AssetsTable;
            }

            set
            {
                _AssetsTable = value;
                _AssetsTable.Table.TableName = Enums.TableNames.tblQuoteJobAssets.ToString();
                _AssetsTable.AllowNew = false;
                _AssetsTable.AllowEdit = false;
                _AssetsTable.AllowDelete = false;
            }
        }

        private DataView _PartsAndProducts = null;

        public DataView PartsAndProducts
        {
            get
            {
                return _PartsAndProducts;
            }

            set
            {
                _PartsAndProducts = value;
                _PartsAndProducts.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
                _PartsAndProducts.AllowNew = false;
                _PartsAndProducts.AllowEdit = false;
                _PartsAndProducts.AllowDelete = false;
                dgPartsAndProducts.DataSource = PartsAndProducts;
            }
        }

        private DataRow SelectedAssetDataRow
        {
            get
            {
                return null;
            }
        }

        private DataRow SelectedRatesDataRow
        {
            get
            {
                if (!(dgScheduleOfRates.CurrentRowIndex == -1))
                {
                    return CurrentQuoteJob.ScheduleOfRates[dgScheduleOfRates.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _JobItemsTable = null;

        public DataView JobItemsDataView
        {
            get
            {
                return _JobItemsTable;
            }

            set
            {
                _JobItemsTable = value;
                _JobItemsTable.Table.TableName = Enums.TableNames.tblQuoteJobItem.ToString();
                _JobItemsTable.AllowNew = false;
                _JobItemsTable.AllowEdit = false;
                _JobItemsTable.AllowDelete = false;
            }
        }

        private DataRow SelectedItemDataRow
        {
            get
            {
                return null;
            }
        }

        private Enums.FormState _JobItemState = Enums.FormState.Insert;
        private bool _loading = false;

        private bool Loading
        {
            get
            {
                return _loading;
            }

            set
            {
                _loading = value;
            }
        }

        private int _PartProductID = 0;

        public int PartProductID
        {
            get
            {
                return _PartProductID;
            }

            set
            {
                _PartProductID = value;
            }
        }

        private bool _QuoteNumberUsed = false;

        public bool QuoteNumberUsed
        {
            get
            {
                return _QuoteNumberUsed;
            }

            set
            {
                _QuoteNumberUsed = value;
            }
        }

        private JobNumber _QuoteNumber = new JobNumber();

        public JobNumber QuoteNumber
        {
            get
            {
                return _QuoteNumber;
            }

            set
            {
                _QuoteNumber = value;
            }
        }

        private double _TotalCosts;

        public double TotalCosts
        {
            get
            {
                return _TotalCosts;
            }

            set
            {
                _TotalCosts = value;
            }
        }

        private void UCQuoteJob_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void txtPartsTotal_LostFocus(object sender, EventArgs e)
        {
            if (CurrentQuoteJob is object)
            {
                WorkOutGrandTotal();
            }
        }

        private void cboQuoteStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // IS THE FORM LOADING
            if (Loading | CurrentQuoteJob is null)
            {
                return;
            }

            // IF ADDING NEW CANNOT ACCEPT OR REJECT
            if (!CurrentQuoteJob.Exists & ((Enums.Quote_JobStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQuoteStatus)) == Enums.Quote_JobStatus.Accepted | (Enums.Quote_JobStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQuoteStatus)) == Enums.Quote_JobStatus.Rejected))
            {
                App.ShowMessage("You can not accept or reject a quote until you have saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var argcombo = cboQuoteStatus;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Helper.MakeIntegerValid(Enums.QuoteContractStatus.Generated).ToString());
                return;
            }

            // ACCEPTING
            if ((Enums.Quote_JobStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQuoteStatus)) == Enums.Quote_JobStatus.Accepted)
            {
                QuoteJob_Create_InstallJob();
            }

            // REJECTING
            else if ((Enums.Quote_JobStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboQuoteStatus)) == Enums.Quote_JobStatus.Rejected)
            {
                App.ShowForm(typeof(FRMQuoteRejection), true, new object[] { this, "" });
                Populate(CurrentQuoteJob.QuoteJobID);
            }
        }

        public string QuoteJob_Create_InstallJob()
        {
            MsgBoxResult msgRes;
            msgRes = (MsgBoxResult)App.ShowMessage("You are converting this quote to a live job." + Constants.vbCrLf + "Do you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if ((int)msgRes == (int)DialogResult.Yes)
            {
                if (Save() == false)
                {
                    return "";
                }
            }
            else if (msgRes == MsgBoxResult.No)
            {
                CurrentQuoteJob = App.DB.QuoteJob.Update(CurrentQuoteJob);
                return "";
            }
            else if (msgRes == MsgBoxResult.Cancel)
            {
                var argcombo = cboQuoteStatus;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentQuoteJob.StatusEnumID.ToString());
                return "";
            }

            Loading = true;
            string rads = "";
            bool fail = false;
            var supList = new List<int>();
            var supName = new List<string>();
            int specialpartid = Consts.SpecialOrderPartNumber;
            string convertedJobNumber = "";
            foreach (DataRow dr in PartsAndProducts.Table.Rows)
            {
                if (dr["Extra"].ToString().Contains("Rad:"))
                {
                    rads += dr["Extra"].ToString().Replace("Rad: ", "") + " : " + dr["Name"] + ", ";
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Supplier"], "No Supplier", false)))
                {
                    fail = true;
                    // specialpartid = dr("ID")
                }

                if (!Information.IsDBNull(dr["SupplierID"]))
                {
                    supList.Add(Helper.MakeIntegerValid(dr["SupplierID"]));
                    if (!supName.Contains(Conversions.ToString(dr["Supplier"])))
                    {
                        supName.Add(Conversions.ToString(dr["Supplier"]));
                    }
                }
            }

            // Going to workout what existing orders we got and then ask user where they want to place the specials
            if (fail)
            {
                var f = new FRMGenDropBox();
                var sups = App.DB.Supplier.Supplier_GetAll().Table;
                f.cbo2.Items.Clear();
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                foreach (DataRow dr in sups.Rows)
                {
                    if (supList.Contains(Helper.MakeIntegerValid(dr["SupplierID"])))
                    {
                        dt.Rows.Add(new string[] { dr["SupplierID"], dr["Name"], "0" });
                    }
                }

                var argc = f.cbo2;
                Combo.SetUpCombo(ref argc, dt, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select); // 
                f.cbo1.Visible = false;
                f.cbo2.Visible = true;
                f.lblTop.Text = "Please select the Supplier for specials";
                f.lblMiddle.Text = "";
                f.lblref.Text = "";
                f.txtref.Visible = false;
                f.ShowDialog();
                if (f.DialogResult == DialogResult.Cancel)
                {
                    return "";
                }

                int supid = Conversions.ToInteger(Combo.get_GetSelectedItemValue(f.cbo2));
                int supplierpartid = Conversions.ToInteger(App.DB.PartSupplier.Get_ByPartIDAndSupplierID(specialpartid, supid).Table.Rows[0]["PartSupplierID"]); // get the first - thats fine
                foreach (DataRow dr in PartsAndProducts.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Supplier"], "No Supplier", false)))
                    {
                        dr["PartSupplierID"] = supplierpartid;
                        dr["SpecialDescription"] = dr["Name"];
                        dr["SpecialCost"] = 0.01;
                    }
                }

                convertedJobNumber = App.DB.Job.Job_Get_For_Quote_ID(CurrentQuoteJob.QuoteJobID)?.JobNumber;
                if (!string.IsNullOrEmpty(convertedJobNumber))
                {
                    Interaction.MsgBox("Quote has already been converted, Install JobNumber : " + convertedJobNumber);
                    return convertedJobNumber;
                }
                else
                {
                    Save();
                }
            }

            string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDept));
            if (Helper.IsValidInteger(department) && Helper.MakeIntegerValid(department) <= 0)
            {
                Interaction.MsgBox("Please select the department for the purchase");
                return "";
            }

            if (txtElectricianCost.Text.Length < 1)
                txtElectricianCost.Text = "£0";
            // 'Eng NOTES
            string notes = "";
            notes += "WHO SURVEYED JOB - " + txtSurveyor.Text + Constants.vbCrLf;
            notes += "JOB LENGTH IN DAYS - " + txtInstallerLabourDays.Text + Constants.vbCrLf;
            notes += "SUPPLIERS - " + string.Join(",", supName.ToArray());
            notes += "RADIATOR POSITIONS - " + rads + Constants.vbCrLf;
            notes += "ASBESTOS - " + Combo.get_GetSelectedItemDescription(cboAsbestos) + " : " + txtAsbestos.Text + Constants.vbCrLf;
            notes += "ADDITIONAL JOB NOTES - " + txtInstallerNotes.Text + Constants.vbCrLf;
            notes += "BUILDING WORK INVOLVED - " + txtBuilderNotes.Text + Constants.vbCrLf;
            notes += "BUILDER ARRIVAL DAY / HOUR - " + txtBuilderArrivalDay.Text + "/" + txtBuilderArrivalHour.Text + Constants.vbCrLf;
            notes += "ACCESS EQUIPTMENT REQUIRED - " + Combo.get_GetSelectedItemDescription(cboAccess) + Constants.vbCrLf;
            notes += "ELECTRICIAN ARRIVAL DAY / HOUR - " + txtElectricianArrivalDay.Text + "/" + txtElectricianArrivalHour.Text + Constants.vbCrLf;
            notes += "BALANCE ON COMPLETION - " + txtBOC.Text + Constants.vbCrLf;

            // 'Electrician NOTES
            string ElecNotes = "";
            ElecNotes += "ELECTRICIAN NOTES - " + txtElectricianNotes.Text + Constants.vbCrLf;
            ElecNotes += "ELECTRICIAN PACK / LABOUR  - " + Combo.get_GetSelectedItemDescription(cboElectricalPack) + " / " + txtElectricianHours.Text + "HRS" + Constants.vbCrLf;
            ElecNotes += "ASBESTOS - " + Combo.get_GetSelectedItemDescription(cboAsbestos) + " : " + txtAsbestos.Text + Constants.vbCrLf;
            ElecNotes += "ELECTRICIAN ARRIVAL DAY / HOUR - " + txtElectricianArrivalDay.Text + "/" + txtElectricianArrivalHour.Text + Constants.vbCrLf;
            ElecNotes += "ELECTRICIAN COSTS - " + txtElectricianCost.Text + Constants.vbCrLf;

            // 'BUILDER NOTES
            string BuilderNotes = "";
            BuilderNotes += "BUILDER NOTES - " + txtBuilderNotes.Text + Constants.vbCrLf;
            BuilderNotes += "BUILDER LABOUR  - " + txtBuilderHours.Text + "HRS" + Constants.vbCrLf;
            BuilderNotes += "ASBESTOS - " + Combo.get_GetSelectedItemDescription(cboAsbestos) + " : " + txtAsbestos.Text + Constants.vbCrLf;
            BuilderNotes += "BUILDER ARRIVAL DAY / HOUR - " + txtBuilderArrivalDay.Text + "/" + txtBuilderArrivalHour.Text + Constants.vbCrLf;
            BuilderNotes += "ACCESS EQUIPTMENT REQUIRED - " + Combo.get_GetSelectedItemDescription(cboAccess) + Constants.vbCrLf;
            if (txtBuilderArrivalDay.Text.Length == 0)
            {
                txtBuilderArrivalDay.Text = "0";
            }

            if (txtElectricianArrivalDay.Text.Length == 0)
            {
                txtElectricianArrivalDay.Text = "0";
            }

            bool ReqBuilder = Helper.MakeDoubleValid(txtBuilderCost.Text) > 0 | Helper.MakeIntegerValid(txtBuilderArrivalDay.Text) > 0 ? true : false;
            bool ReqElectrian = Helper.MakeDoubleValid(txtElectricianCost.Text) > 0 | Helper.MakeIntegerValid(txtElectricianArrivalDay.Text) > 0 ? true : false;
            bool ReqService = Conversions.ToBoolean(1);
            bool ReqHandOver = Conversions.ToBoolean(1);

            // check to see if job has been created by another user
            convertedJobNumber = App.DB.Job.Job_Get_For_Quote_ID(CurrentQuoteJob.QuoteJobID)?.JobNumber;
            if (!string.IsNullOrEmpty(convertedJobNumber))
            {
                Interaction.MsgBox("Quote has already been converted, Install JobNumber : " + convertedJobNumber);
                return convertedJobNumber;
            }

            string jn = App.DB.QuoteJob.QuoteJob_Create_Install(CurrentQuoteJob.SiteID, txtSurveyor.Text, notes, BuilderNotes, ElecNotes, Combo.get_GetSelectedItemValue(cboDept), CurrentQuoteJob.QuoteJobID, ReqElectrian, ReqBuilder, chkService.Checked, chkHOver.Checked, Helper.MakeDoubleValid(txtElectricianCost.Text), Helper.MakeDoubleValid(txtBuilderCost.Text));
            var argcombo1 = cboQuoteStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Conversions.ToString(Enums.Quote_JobStatus.Accepted));
            Loading = false;
            Save();
            Populate(CurrentQuoteJob.QuoteJobID);
            Interaction.MsgBox("Quote Successfully Converted, Install JobNumber : C" + jn);
            return "C" + jn;
        }

        private void btnFindPart_Click(object sender, EventArgs e)
        {
            FRMFindPart dialogue1;
            dialogue1 = (FRMFindPart)App.checkIfExists(typeof(FRMFindPart).Name, true);
            if (dialogue1 is null)
            {
                dialogue1 = (FRMFindPart)Activator.CreateInstance(typeof(FRMFindPart));
            }
            // dialogue1.Icon = New Icon(dialogue1.GetType(), "Logo.ico")
            dialogue1.ShowInTaskbar = false;
            dialogue1.TableToSearch = Enums.TableNames.NOT_IN_Database_tblPartSupplierQty;
            dialogue1.ShowDialog();
            DataRow[] datarows = null;
            if (dialogue1.DialogResult == DialogResult.OK)
            {
                datarows = dialogue1.Datarows;
            }
            else
            {
                return;
            }

            foreach (DataRow dr in datarows)
            {
                DataRow newRow;
                if (Helper.MakeBooleanValid(dr["IsPartPack"]))
                {
                    int supplierId = Helper.MakeIntegerValid(dr["SupplierID"]);
                    int packId = Helper.MakeIntegerValid(dr["PartID"]);
                    var dvPartPack = App.DB.Part.PartPack_Get(packId);
                    int qty = Conversions.ToInteger(dr["Qty"]);
                    foreach (DataRowView drPart in dvPartPack)
                    {
                        newRow = CurrentQuoteJob.QuoteJobPartsAndProducts.Table.NewRow();
                        int partId = Helper.MakeIntegerValid(drPart["PartID"]);
                        var dvPartSupplier = App.DB.PartSupplier.Get_ByPartIDAndSupplierID(partId, supplierId);
                        newRow["SellPrice"] = 0.0;
                        newRow["Extra"] = "";
                        newRow["ID"] = drPart["PartID"];
                        newRow["Number"] = drPart["PartNumber"];
                        newRow["PartSupplierID"] = dvPartSupplier[0]["PartSupplierID"];
                        newRow["Name"] = drPart["PartName"];
                        newRow["Quantity"] = drPart["Qty"] * qty;
                        newRow["BuyPrice"] = dvPartSupplier[0]["Price"];
                        newRow["Total"] = newRow["Quantity"] * newRow["BuyPrice"];
                        newRow["Type"] = "Part";
                        newRow["Supplier"] = dvPartSupplier[0]["SupplierName"];
                        CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.Add(newRow);
                    }
                }
                else
                {
                    newRow = CurrentQuoteJob.QuoteJobPartsAndProducts.Table.NewRow();
                    newRow["SellPrice"] = 0.0;
                    newRow["Extra"] = "";
                    newRow["ID"] = dr["PartID"];
                    newRow["Number"] = dr["PartNumber"];
                    newRow["PartSupplierID"] = dr["PartSupplierID"];
                    newRow["Name"] = dr["PartName"];
                    newRow["Quantity"] = dr["Qty"];
                    newRow["BuyPrice"] = dr["Price"];
                    newRow["Total"] = newRow["Quantity"] * newRow["BuyPrice"];
                    newRow["Type"] = "Part";
                    newRow["Supplier"] = dr["SupplierName"];
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["IsSpecialPart"], 1, false)))
                    {
                        var f = new FRMSpecialOrder(0, 0, 0);
                        f.ShowDialog();
                        if (f.DialogResult == DialogResult.OK)
                        {
                            newRow["Quantity"] = f.Quantity;
                            newRow["BuyPrice"] = f.Price;
                            newRow["SpecialCost"] = f.Price;
                            newRow["Name"] = f.PartName;
                            newRow["SpecialDescription"] = f.PartName;
                            newRow["Number"] = f.SPN;
                            newRow["Extra"] = f.SPN;
                            newRow["Total"] = newRow["Quantity"] * newRow["BuyPrice"];
                        }
                        else
                        {
                        }
                    }

                    CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.Add(newRow);
                }
            }

            SetupPartsTotals();
        }

        private void btnSiteScheduleOfRates_Click(object sender, EventArgs e)
        {
            var argDataviewToLinkToIn = CurrentQuoteJob.ScheduleOfRates;
            using (var f = new FRMSiteScheduleOfRateList(CurrentQuoteJob.SiteID, ref argDataviewToLinkToIn, true))
            {
                f.ShowDialog();
            }

            dgScheduleOfRates.DataSource = CurrentQuoteJob.ScheduleOfRates;
            SetupSORTotals();
        }

        private void btnRemovePartProduct_Click(object sender, EventArgs e)
        {
            if (dgPartsAndProducts.CurrentRowIndex > -1)
            {
                CurrentQuoteJob.QuoteJobPartsAndProducts.Table.AcceptChanges();
                CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.RemoveAt(dgPartsAndProducts.CurrentRowIndex);
                SetupPartsTotals();
            }
            else
            {
                App.ShowMessage("Please select item to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string errorMsg = "";
            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboScheduleOfRatesCategoryID)) > 0))
            {
                errorMsg = "* Category is missing" + Constants.vbCrLf;
                valid = false;
            }

            if (txtDescription.Text.Trim().Length == 0)
            {
                errorMsg += "* Description is missing" + Constants.vbCrLf;
                valid = false;
            }

            if (txtPrice.Text.Trim().Length == 0)
            {
                errorMsg += "* Price is missing" + Constants.vbCrLf;
                valid = false;
            }
            else if (Information.IsNumeric(txtPrice.Text) == false)
            {
                errorMsg += "* Price must be numeric" + Constants.vbCrLf;
                valid = false;
            }

            if (txtQuantity.Text.Trim().Length == 0)
            {
                errorMsg += "* Quantity is missing" + Constants.vbCrLf;
                valid = false;
            }
            else if (Information.IsNumeric(txtQuantity.Text) == false)
            {
                errorMsg += "* Quantity must be numeric" + Constants.vbCrLf;
                valid = false;
            }

            if (valid)
            {
                var rate = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate();
                rate.IgnoreExceptionsOnSetMethods = true;
                rate.SetScheduleOfRatesCategoryID = Combo.get_GetSelectedItemValue(cboScheduleOfRatesCategoryID);
                rate.SetCode = txtCode.Text;
                rate.SetDescription = txtDescription.Text;
                rate.SetPrice = txtPrice.Text;
                rate.SetTimeInMins = txtTimeInMins.Text;
                rate = App.DB.CustomerScheduleOfRate.Insert(rate);
                // now delete the rate (we do this because the rate is local to this quote only,
                // it will still show on the quote.)
                App.DB.CustomerScheduleOfRate.Delete(rate.CustomerScheduleOfRateID);
                DataRow newRow;
                newRow = CurrentQuoteJob.ScheduleOfRates.Table.NewRow();
                newRow["RateID"] = rate.CustomerScheduleOfRateID;
                newRow["ScheduleOfRatesCategoryID"] = rate.ScheduleOfRatesCategoryID;
                newRow["Category"] = Combo.get_GetSelectedItemDescription(cboScheduleOfRatesCategoryID);
                newRow["Code"] = rate.Code;
                newRow["Description"] = rate.Description;
                newRow["Price"] = rate.Price;
                newRow["TimeInMins"] = rate.TimeInMins;
                newRow["Quantity"] = txtQuantity.Text;
                newRow["Total"] = Helper.MakeDoubleValid(newRow["Price"]) * Helper.MakeDoubleValid(newRow["Quantity"]);
                CurrentQuoteJob.ScheduleOfRates.Table.Rows.Add(newRow);
                var argcombo = cboScheduleOfRatesCategoryID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
                txtCode.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
                txtQuantity.Text = "";
                txtTimeInMins.Text = "";
                dgScheduleOfRates.DataSource = CurrentQuoteJob.ScheduleOfRates;
                SetupSORTotals();
            }
            else
            {
                MessageBox.Show("Please correct the following:" + Constants.vbCrLf + errorMsg, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (SelectedRatesDataRow is object)
            {
                {
                    var withBlock = SelectedRatesDataRow;
                    if ((int)MessageBox.Show(Conversions.ToString("DELETE :" + withBlock["Description"]), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)MsgBoxResult.Yes)
                    {
                        CurrentQuoteJob.ScheduleOfRates.Table.Rows.Remove(SelectedRatesDataRow);
                        SetupSORTotals();
                    }
                }
            }
        }

        private void btnAddToJobItems_Click(object sender, EventArgs e)
        {
            if (SelectedRatesDataRow is null)
            {
                App.ShowMessage("Please select rate to add description to job item list", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            JobItemsDataView.Table.AcceptChanges();
            var newRow = JobItemsDataView.Table.NewRow();
            newRow["Summary"] = Helper.MakeStringValid(SelectedRatesDataRow["Description"]);
            newRow["RateID"] = Helper.MakeIntegerValid(SelectedRatesDataRow["RateID"]);
            newRow["Qty"] = Helper.MakeDoubleValid(SelectedRatesDataRow["Quantity"]);
            JobItemsDataView.Table.Rows.Add(newRow);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupPartsAndProductsDataGrid()
        {
            Helper.SetUpDataGrid(dgPartsAndProducts);
            var tStyle = dgPartsAndProducts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var number = new DataGridLabelColumn();
            number.Format = "";
            number.FormatInfo = null;
            number.HeaderText = "Number";
            number.MappingName = "number";
            number.ReadOnly = true;
            number.Width = 100;
            number.NullText = "";
            tStyle.GridColumnStyles.Add(number);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 160;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var quantity = new DataGridLabelColumn();
            quantity.Format = "";
            quantity.FormatInfo = null;
            quantity.HeaderText = "Qty";
            quantity.MappingName = "quantity";
            quantity.ReadOnly = true;
            quantity.Width = 50;
            quantity.NullText = "";
            tStyle.GridColumnStyles.Add(quantity);
            var Sellprice = new DataGridLabelColumn();
            Sellprice.Format = "C";
            Sellprice.FormatInfo = null;
            Sellprice.HeaderText = "Buy Price";
            Sellprice.MappingName = "BuyPrice";
            Sellprice.ReadOnly = true;
            Sellprice.Width = 75;
            Sellprice.NullText = "";
            tStyle.GridColumnStyles.Add(Sellprice);
            var Extra = new DataGridLabelColumn();
            Extra.Format = "";
            Extra.FormatInfo = null;
            Extra.HeaderText = "Extra";
            Extra.MappingName = "Extra";
            Extra.ReadOnly = false;
            Extra.Width = 75;
            Extra.NullText = "";
            tStyle.GridColumnStyles.Add(Extra);
            var Supplier = new DataGridLabelColumn();
            Supplier.Format = "";
            Supplier.FormatInfo = null;
            Supplier.HeaderText = "Supplier";
            Supplier.MappingName = "Supplier";
            Supplier.ReadOnly = false;
            Supplier.Width = 75;
            Supplier.NullText = "";
            tStyle.GridColumnStyles.Add(Supplier);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
            dgPartsAndProducts.TableStyles.Add(tStyle);
        }

        public void SetupScheduleOfRatesDataGrid()
        {
            Helper.SetUpDataGrid(dgScheduleOfRates);
            var tStyle = dgScheduleOfRates.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 90;
            Category.NullText = "";
            tStyle.GridColumnStyles.Add(Category);
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Code";
            Code.MappingName = "Code";
            Code.ReadOnly = true;
            Code.Width = 75;
            Code.NullText = "";
            tStyle.GridColumnStyles.Add(Code);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 150;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var TimeInMins = new DataGridLabelColumn();
            TimeInMins.Format = "C";
            TimeInMins.FormatInfo = null;
            TimeInMins.HeaderText = "Time";
            TimeInMins.MappingName = "TimeInMins";
            TimeInMins.ReadOnly = false;
            TimeInMins.Width = 50;
            TimeInMins.NullText = "";
            tStyle.GridColumnStyles.Add(TimeInMins);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Unit Price";
            Price.MappingName = "Price";
            Price.ReadOnly = false;
            Price.Width = 75;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var Quantity = new DataGridLabelColumn();
            Quantity.Format = "";
            Quantity.FormatInfo = null;
            Quantity.HeaderText = "Unit Qty";
            Quantity.MappingName = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 75;
            Quantity.NullText = "";
            tStyle.GridColumnStyles.Add(Quantity);
            var Total = new DataGridLabelColumn();
            Total.Format = "C";
            Total.FormatInfo = null;
            Total.HeaderText = "Total";
            Total.MappingName = "Total";
            Total.ReadOnly = false;
            Total.Width = 75;
            Total.NullText = "";
            tStyle.GridColumnStyles.Add(Total);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
            dgScheduleOfRates.TableStyles.Add(tStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void WorkOutGrandTotal()
        {
            if (string.IsNullOrEmpty(txtPartsCost.Text))
            {
                txtPartsCost.Text = "£0.00";
            }
            else if (!Information.IsNumeric(txtPartsCost.Text.Trim().Replace("£", "")))
            {
                txtPartsCost.Text = "£0.00";
            }
            else
            {
                txtPartsCost.Text = Strings.Format(Helper.MakeDoubleValid(txtPartsCost.Text.Trim().Replace("£", "")), "C");
            }

            if (string.IsNullOrEmpty(txtPartsProductsMarkup.Text))
            {
                txtPartsProductsMarkup.Text = "0%";
            }
            else if (!Information.IsNumeric(txtPartsProductsMarkup.Text.Trim().Replace("%", "")))
            {
                txtPartsProductsMarkup.Text = "0%";
            }
            else
            {
                txtPartsProductsMarkup.Text = txtPartsProductsMarkup.Text.Trim().Replace("%", "") + "%";
            }

            if (string.IsNullOrEmpty(txtScheduleRatesCost.Text))
            {
                txtScheduleRatesCost.Text = "£0.00";
            }
            else if (!Information.IsNumeric(txtScheduleRatesCost.Text.Trim().Replace("£", "")))
            {
                txtScheduleRatesCost.Text = "£0.00";
            }
            else
            {
                txtScheduleRatesCost.Text = Strings.Format(Helper.MakeDoubleValid(txtScheduleRatesCost.Text.Trim().Replace("£", "")), "C");
            }

            if (string.IsNullOrEmpty(txtScheduleRateMarkup.Text))
            {
                txtScheduleRateMarkup.Text = "0%";
            }
            else if (!Information.IsNumeric(txtScheduleRateMarkup.Text.Trim().Replace("%", "")))
            {
                txtScheduleRateMarkup.Text = "0%";
            }
            else
            {
                txtScheduleRateMarkup.Text = txtScheduleRateMarkup.Text.Trim().Replace("%", "") + "%";
            }

            if (string.IsNullOrEmpty(txtInstallerCost.Text))
            {
                txtInstallerCost.Text = "£0.00";
            }
            else if (!Information.IsNumeric(txtInstallerCost.Text.Trim().Replace("£", "")))
            {
                txtInstallerCost.Text = "£0.00";
            }
            else
            {
                txtInstallerCost.Text = Strings.Format(Helper.MakeDoubleValid(txtInstallerCost.Text.Trim().Replace("£", "")), "C");
            }

            if (string.IsNullOrEmpty(txtInstallerMarkup.Text))
            {
                txtInstallerMarkup.Text = "0%";
            }
            else if (!Information.IsNumeric(txtInstallerMarkup.Text.Trim().Replace("%", "")))
            {
                txtInstallerMarkup.Text = "0%";
            }
            else
            {
                txtInstallerMarkup.Text = txtInstallerMarkup.Text.Trim().Replace("%", "") + "%";
            }

            if (string.IsNullOrEmpty(txtBuilderCost.Text))
            {
                txtBuilderCost.Text = "£0.00";
            }
            else if (!Information.IsNumeric(txtBuilderCost.Text.Trim().Replace("£", "")))
            {
                txtBuilderCost.Text = "£0.00";
            }
            else
            {
                txtBuilderCost.Text = Strings.Format(Helper.MakeDoubleValid(txtBuilderCost.Text.Trim().Replace("£", "")), "C");
            }

            if (string.IsNullOrEmpty(txtBuilderMarkup.Text))
            {
                txtBuilderMarkup.Text = "0%";
            }
            else if (!Information.IsNumeric(txtBuilderMarkup.Text.Trim().Replace("%", "")))
            {
                txtBuilderMarkup.Text = "0%";
            }
            else
            {
                txtBuilderMarkup.Text = txtBuilderMarkup.Text.Trim().Replace("%", "") + "%";
            }

            if (string.IsNullOrEmpty(txtElectricianCost.Text))
            {
                txtElectricianCost.Text = "£0.00";
            }
            else if (!Information.IsNumeric(txtElectricianCost.Text.Trim().Replace("£", "")))
            {
                txtElectricianCost.Text = "£0.00";
            }
            else
            {
                txtElectricianCost.Text = Strings.Format(Helper.MakeDoubleValid(txtElectricianCost.Text.Trim().Replace("£", "")), "C");
            }

            if (string.IsNullOrEmpty(txtElectricianMarkup.Text))
            {
                txtElectricianMarkup.Text = "0%";
            }
            else if (!Information.IsNumeric(txtElectricianMarkup.Text.Trim().Replace("%", "")))
            {
                txtElectricianMarkup.Text = "0%";
            }
            else
            {
                txtElectricianMarkup.Text = txtElectricianMarkup.Text.Trim().Replace("%", "") + "%";
            }

            double productPartTotal = 0.0;
            productPartTotal = Helper.MakeDoubleValid(txtPartsCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(Conversions.ToDouble(txtPartsCost.Text.Replace("£", "")) / 100) * Helper.MakeDoubleValid(txtPartsProductsMarkup.Text.Replace("%", ""));
            txtPartsCostTotal.Text = Strings.Format(productPartTotal, "C");
            double scheduleRateTotal = 0.0;
            scheduleRateTotal = Helper.MakeDoubleValid(txtScheduleRatesCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(Conversions.ToDouble(txtScheduleRatesCost.Text.Replace("£", "")) / 100) * Helper.MakeDoubleValid(txtScheduleRateMarkup.Text.Replace("%", ""));
            txtScheduleRatesCostTotal.Text = Strings.Format(scheduleRateTotal, "C");
            double InstallerTotal = 0.0;
            InstallerTotal = Helper.MakeDoubleValid(txtInstallerCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(Conversions.ToDouble(txtInstallerCost.Text.Replace("£", "")) / 100) * Helper.MakeDoubleValid(txtInstallerMarkup.Text.Replace("%", ""));
            txtInstallerCharge.Text = Strings.Format(InstallerTotal, "C");
            double BuilderTotal = 0.0;
            BuilderTotal = Helper.MakeDoubleValid(txtBuilderCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(Conversions.ToDouble(txtBuilderCost.Text.Replace("£", "")) / 100) * Helper.MakeDoubleValid(txtBuilderMarkup.Text.Replace("%", ""));
            txtBuilderCharge.Text = Strings.Format(BuilderTotal, "C");
            double ElectricianTotal = 0.0;
            ElectricianTotal = Helper.MakeDoubleValid(txtElectricianCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(Conversions.ToDouble(txtElectricianCost.Text.Replace("£", "")) / 100) * Helper.MakeDoubleValid(txtElectricianMarkup.Text.Replace("%", ""));
            txtElectricianCharge.Text = Strings.Format(ElectricianTotal, "C");
            double AdditionalCharge = Helper.MakeDoubleValid(txtAccess.Text.Replace("£", ""));
            if (chkSORCharge.Checked)
            {
                txtInstallerCharge.Text = 0.ToString();
                txtElectricianCharge.Text = 0.ToString();
                txtBuilderCharge.Text = 0.ToString();
                txtPartsCostTotal.Text = 0.ToString();
                AdditionalCharge = 0;
            }
            else
            {
                txtScheduleRatesCostTotal.Text = 0.ToString();
            }

            double GrandTotal = 0.0;
            GrandTotal = Helper.MakeDoubleValid(txtPartsCostTotal.Text.Replace("£", "")) + Helper.MakeDoubleValid(txtScheduleRatesCostTotal.Text.Replace("£", "")) + Helper.MakeDoubleValid(txtInstallerCharge.Text.Replace("£", "")) + Helper.MakeDoubleValid(txtElectricianCharge.Text.Replace("£", "")) + Helper.MakeDoubleValid(txtBuilderCharge.Text.Replace("£", "")) + AdditionalCharge;
            txtGrandTotal.Text = Strings.Format(GrandTotal, "C");
            if (CurrentQuoteJob is object)
            {
                {
                    var withBlock = CurrentQuoteJob;
                    withBlock.SetPartsAndProductsTotal = productPartTotal;
                    withBlock.SetScheduleOfRatesTotal = scheduleRateTotal;
                    withBlock.SetScheduleOfRatesTotal = ElectricianTotal;
                    withBlock.SetGrandTotal = GrandTotal;
                }
            }

            TotalCosts = Helper.MakeDoubleValid(txtBuilderCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(txtElectricianCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(txtInstallerCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(txtPartsCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(txtAccess.Text.Replace("£", ""));
            txtTotalCosts.Text = Strings.Format(TotalCosts, "C");
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVAT)) > 0)
            {
                double VATRate = App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboVAT))).VATRate;
                txtProfitPound.Text = Strings.Format(Helper.MakeDoubleValid(txtGrandTotal.Text.Replace("£", "")) - TotalCosts, "C");
                txtProfitPerc.Text = Math.Round(Helper.MakeDoubleValid(txtProfitPound.Text) / Helper.MakeDoubleValid(txtGrandTotal.Text.Replace("£", "")) * 100, 2) + "%";
                txtGrandTotal.Text = Strings.Format(Helper.MakeDoubleValid(txtGrandTotal.Text.Replace("£", "")), "C");
                txtincVAT.Text = Strings.Format(Helper.MakeDoubleValid(txtGrandTotal.Text.Replace("£", "")) * (1 + VATRate / 100), "C");
                // Me.txtDeposit.Text = Format(CurrentQuoteJob.DepositAmount, "C")
                txtBOC.Text = Strings.Format(Helper.MakeDoubleValid(txtGrandTotal.Text.Replace("£", "")) * (1 + VATRate / 100) - Helper.MakeDoubleValid(txtDeposit.Text.Replace("£", "")), "C");
            }
        }

        private void Populate(int ID = 0)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Summary"));
            dt.Columns.Add(new DataColumn("RateID"));
            dt.Columns.Add(new DataColumn("Qty"));
            JobItemsDataView = new DataView(dt);
            if (CurrentQuoteJob.Exists)
            {
                if (Conversions.ToInteger(CurrentQuoteJob.StatusEnumID) == -1)
                {
                    Helper.MakeReadOnly(grpJobItems, true);
                    cboJobType.Enabled = false;
                    txtReference.Enabled = false;
                    dtpQuoteDate.Enabled = false;
                    cboQuoteStatus.Enabled = false;
                    grpParts.Enabled = false;
                    grpRates.Enabled = false;
                    grpTotals.Enabled = false;
                }
                else
                {
                    Helper.MakeReadOnly(grpJobItems, false);
                    cboJobType.Enabled = true;
                    txtReference.Enabled = true;
                    dtpQuoteDate.Enabled = true;
                    cboQuoteStatus.Enabled = true;
                    grpParts.Enabled = true;
                    grpRates.Enabled = true;
                    grpTotals.Enabled = true;
                }

                var argcombo = cboJobType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentQuoteJob.JobTypeID.ToString());
                var argcombo1 = cboQuoteStatus;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentQuoteJob.StatusEnumID.ToString());
                txtReference.Text = CurrentQuoteJob.Reference;
                dtpQuoteDate.Value = CurrentQuoteJob.DateCreated;
                txtPartsCost.Text = Strings.Format(CurrentQuoteJob.PartsCost, "C");
                txtPartsProductsMarkup.Text = CurrentQuoteJob.PartsAndProductsMarkup + "%";
                txtPartsCostTotal.Text = Strings.Format(Helper.MakeDoubleValid(CurrentQuoteJob.PartsCost + CurrentQuoteJob.PartsCost / 100 * Conversions.ToDouble(CurrentQuoteJob.PartsAndProductsMarkup)), "C");
                dgScheduleOfRates.DataSource = CurrentQuoteJob.ScheduleOfRates;
                txtScheduleRatesCost.Text = Strings.Format(CurrentQuoteJob.ScheduleOfRatesTotal, "C");
                txtScheduleRateMarkup.Text = CurrentQuoteJob.ScheduleOfRatesMarkup + "%";
                txtScheduleRatesCostTotal.Text = Strings.Format(Helper.MakeDoubleValid(CurrentQuoteJob.ScheduleOfRatesTotal + CurrentQuoteJob.ScheduleOfRatesTotal / 100 * CurrentQuoteJob.ScheduleOfRatesMarkup), "C");
                txtElectricianCost.Text = Strings.Format(CurrentQuoteJob.ElectricianCost, "C");
                txtElectricianMarkup.Text = CurrentQuoteJob.ElectricianMarkUp + "%";
                txtElectricianCharge.Text = Strings.Format(Helper.MakeDoubleValid(Helper.MakeDoubleValid(txtElectricianCost.Text) + Helper.MakeDoubleValid(txtElectricianCost.Text) / 100 * CurrentQuoteJob.ElectricianMarkUp), "C");
                txtInstallerCost.Text = Strings.Format(CurrentQuoteJob.EngineerCost, "C");
                txtInstallerMarkup.Text = CurrentQuoteJob.EngineerMarkUp + "%";
                txtInstallerCharge.Text = Strings.Format(Helper.MakeDoubleValid(CurrentQuoteJob.EngineerCost + CurrentQuoteJob.EngineerCost / 100 * CurrentQuoteJob.EngineerMarkUp), "C");
                txtBuilderCost.Text = Strings.Format(CurrentQuoteJob.BuilderCost, "C");
                txtBuilderMarkup.Text = CurrentQuoteJob.BuilderMarkUp + "%";
                txtBuilderCharge.Text = Strings.Format(Helper.MakeDoubleValid(CurrentQuoteJob.BuilderCost + CurrentQuoteJob.BuilderCost / 100 * CurrentQuoteJob.BuilderMarkUp), "C");
                chkSORCharge.Checked = Conversions.ToBoolean(CurrentQuoteJob.SORCharge);
                var argcombo2 = cboVAT;
                Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentQuoteJob.VatRateID.ToString());
                var argcombo3 = cboElectricalPack;
                Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentQuoteJob.ElectricianPackTypeID.ToString());
                // new workdetails
                txtAccess.Text = CurrentQuoteJob.AdditionalCosts.ToString();
                txtInstallerNotes.Text = CurrentQuoteJob.NotesToEngineer;
                txtInstallerLabourDays.Text = CurrentQuoteJob.EngineerLabourHrs.ToString();
                var argcombo4 = cboAsbestos;
                Combo.SetSelectedComboItem_By_Value(ref argcombo4, CurrentQuoteJob.AsbestosID.ToString());
                txtAsbestos.Text = CurrentQuoteJob.AsbestosComment;
                var argcombo5 = cboAccess;
                Combo.SetSelectedComboItem_By_Value(ref argcombo5, CurrentQuoteJob.AccessEquipmentID.ToString());
                txtElectricianHours.Text = CurrentQuoteJob.ElectricianLabourHrs.ToString();
                txtElectricianArrivalDay.Text = CurrentQuoteJob.ElectricianArrivalDayNo.ToString();
                txtElectricianArrivalHour.Text = CurrentQuoteJob.ElectricianArrivalHour.ToString();
                txtElectricianNotes.Text = CurrentQuoteJob.NotesToElectrician;
                txtBuilderHours.Text = CurrentQuoteJob.BuilderLabourHrs.ToString();
                txtBuilderArrivalDay.Text = CurrentQuoteJob.BuilderArrivalDayNo.ToString();
                txtBuilderArrivalHour.Text = CurrentQuoteJob.BuilderArrivalHour.ToString();
                txtBuilderNotes.Text = CurrentQuoteJob.NotesToBuilder;
                txtOriginalQuote.Text = Strings.Format(CurrentQuoteJob.OriginalQuotedAmount, "C");
                TotalCosts = CurrentQuoteJob.BuilderCost + CurrentQuoteJob.ElectricianCost + CurrentQuoteJob.EngineerCost + CurrentQuoteJob.PartsCost + CurrentQuoteJob.AdditionalCosts;
                txtTotalCosts.Text = Strings.Format(TotalCosts, "C");
                txtDeposit.Text = Strings.Format(CurrentQuoteJob.DepositAmount, "C");
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVAT)) > 0)
                {
                    double VATRate = App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboVAT))).VATRate;
                    txtProfitPound.Text = Strings.Format(CurrentQuoteJob.QuotedAmount - TotalCosts, "C");
                    txtProfitPerc.Text = Math.Round(Helper.MakeDoubleValid(txtProfitPound.Text.Replace("£", "")) / CurrentQuoteJob.QuotedAmount * 100, 2) + "%";
                    txtGrandTotal.Text = Strings.Format(CurrentQuoteJob.QuotedAmount, "C");
                    txtincVAT.Text = Strings.Format(CurrentQuoteJob.QuotedAmount * (1 + VATRate / 100), "C");
                    txtBOC.Text = Strings.Format(CurrentQuoteJob.QuotedAmount * (1 + VATRate / 100) - CurrentQuoteJob.DepositAmount, "C");
                }

                if (CurrentQuoteJob.EstStartDate > DateTime.MinValue)
                {
                    lblNA.Visible = false;
                    dtpestStartDate.Visible = true;
                    dtpestStartDate.Value = CurrentQuoteJob.EstStartDate;
                }
                else
                {
                    lblNA.Visible = true;
                    dtpestStartDate.Visible = false;
                }

                try // LAZY
                {
                    var ev = App.DB.EngineerVisits.EngineerVisits_Get_New_As_Object(CurrentQuoteJob.SurveyVisitID);
                    var Eng = App.DB.Engineer.Engineer_Get(ev.EngineerID);
                    txtSurveyor.Text = Eng.Name;
                }
                catch (Exception ex)
                {
                    txtSurveyor.Text = "N/A";
                }

                txtChangedDate.Text = CurrentQuoteJob.ChangedDateTime.ToString("dd/MM/yyyy");
                var User = App.DB.User.Get(CurrentQuoteJob.ChangedByUserID);
                txtChangedBy.Text = User.Fullname;
                var argcombo6 = cboDept;
                Combo.SetSelectedComboItem_By_Value(ref argcombo6, CurrentQuoteJob.Department.Trim());
            }
            else
            {
                txtInstallerCost.Text = Strings.Format(0, "C");
                txtElectricianCost.Text = Strings.Format(0, "C");
                txtBuilderCost.Text = Strings.Format(0, "C");
                txtGrandTotal.Text = Strings.Format(0, "C");
                txtDeposit.Text = Strings.Format(0, "C");
                txtPartsCost.Text = Strings.Format(0, "C");
                txtBOC.Text = Strings.Format(0, "C");
                txtScheduleRatesCost.Text = Strings.Format(0, "C");
                txtProfitPound.Text = Strings.Format(0, "C");
                txtOriginalQuote.Text = Strings.Format(CurrentQuoteJob.OriginalQuotedAmount, "C");
                CurrentQuoteJob.QuoteJobPartsAndProducts = App.DB.QuoteJob.Get_Parts_And_Products_For_QuoteJobID(CurrentQuoteJob.QuoteJobID);
            }

            RefreshButton?.Invoke();
        }

        public void LoadDepartment()
        {
            string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDept));
            if (Helper.IsValidInteger(department) && !(Helper.MakeIntegerValid(department) <= 0))
            {
                var cc = App.DB.CostCentre.Get((int)CurrentQuoteJob?.JobTypeID, (int)CurrentSite?.CustomerID, GetBy.JobTypeIdAndCutomerId)?.FirstOrDefault();
                var argcombo = cboDept;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(cc?.CostCentreId));
            }
            else if (!Information.IsNumeric(department))
            {
                var cc = App.DB.CostCentre.Get((int)CurrentQuoteJob?.JobTypeID, (int)CurrentSite?.CustomerID, GetBy.JobTypeIdAndCutomerId)?.FirstOrDefault();
                var argcombo1 = cboDept;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, Helper.MakeStringValid(cc?.CostCentreId));
            }
        }

        private void SetupPartsTotals()
        {
            double parts = 0.0;
            foreach (DataRow row in CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows)
                parts += row["Quantity"] * row["BuyPrice"];
            CurrentQuoteJob.SetPartsAndProductsTotal = parts;
            txtPartsCost.Text = Strings.Format(parts, "C");
            WorkOutGrandTotal();
        }

        private void SetupSORTotals()
        {
            double rates = 0.0;
            foreach (DataRow row in CurrentQuoteJob.ScheduleOfRates.Table.Rows)
                rates += row["Total"];
            CurrentQuoteJob.SetScheduleOfRatesTotal = rates;
            txtScheduleRatesCost.Text = Strings.Format(rates, "C");
            WorkOutGrandTotal();
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentQuoteJob.IgnoreExceptionsOnSetMethods = true;
                CurrentQuoteJob.SetJobDefinitionEnumID = Helper.MakeIntegerValid(Enums.JobDefinition.Quoted);
                CurrentQuoteJob.SetJobTypeID = Combo.get_GetSelectedItemValue(cboJobType);
                CurrentQuoteJob.SetStatusEnumID = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboQuoteStatus));
                CurrentQuoteJob.SetReference = txtReference.Text.Trim();
                CurrentQuoteJob.DateCreated = dtpQuoteDate.Value;
                CurrentQuoteJob.SetPartsAndProductsTotal = txtPartsCost.Text.Trim().Replace("£", "");
                CurrentQuoteJob.SetPartsAndProductsMarkup = txtPartsProductsMarkup.Text.Trim().Replace("%", "");
                CurrentQuoteJob.SetGrandTotal = txtBOC.Text.Trim().Replace("£", "");
                CurrentQuoteJob.SetScheduleOfRatesMarkup = txtScheduleRateMarkup.Text.Trim().Replace("%", "");
                CurrentQuoteJob.SetScheduleOfRatesTotal = txtScheduleRatesCost.Text.Trim().Replace("£", "");
                CurrentQuoteJob.SetMileageRate = 0;
                CurrentQuoteJob.SetEstimatedMileage = 0;
                CurrentQuoteJob.SetNotesToEngineer = txtInstallerNotes.Text;
                CurrentQuoteJob.SetNotesToElectrician = txtElectricianNotes.Text;
                CurrentQuoteJob.SetNotesToBuilder = txtBuilderNotes.Text;
                CurrentQuoteJob.SetEngineerLabourHrs = Helper.MakeDoubleValid(txtInstallerLabourDays.Text);
                CurrentQuoteJob.SetElectricianLabourHrs = Helper.MakeDoubleValid(txtElectricianHours.Text);
                CurrentQuoteJob.SetBuilderLabourHrs = Helper.MakeDoubleValid(txtBuilderHours.Text);
                CurrentQuoteJob.SetEngineerMarkUp = Helper.MakeDoubleValid(txtInstallerMarkup.Text.Replace("%", ""));
                CurrentQuoteJob.SetElectricianMarkUp = Helper.MakeDoubleValid(txtElectricianMarkup.Text.Replace("%", ""));
                CurrentQuoteJob.SetBuilderMarkUp = Helper.MakeDoubleValid(txtBuilderMarkup.Text.Replace("%", ""));
                CurrentQuoteJob.SetElectricianArrivalDayNo = Helper.MakeIntegerValid(txtElectricianArrivalDay.Text);
                CurrentQuoteJob.SetElectricianArrivalHour = Helper.MakeIntegerValid(txtElectricianArrivalHour.Text);
                CurrentQuoteJob.SetBuilderArrivalDayNo = Helper.MakeIntegerValid(txtBuilderArrivalDay.Text);
                CurrentQuoteJob.SetBuilderArrivalHour = Helper.MakeIntegerValid(txtBuilderArrivalHour.Text);
                CurrentQuoteJob.SetPartsCost = Helper.MakeDoubleValid(txtPartsCost.Text);
                CurrentQuoteJob.SetEngineerCost = Helper.MakeDoubleValid(txtInstallerCost.Text);
                CurrentQuoteJob.SetBuilderCost = Helper.MakeDoubleValid(txtBuilderCost.Text);
                CurrentQuoteJob.SetElectricianCost = Helper.MakeDoubleValid(txtElectricianCost.Text);
                CurrentQuoteJob.SetQuotedAmount = Helper.MakeDoubleValid(txtGrandTotal.Text);
                CurrentQuoteJob.SetDepositAmount = Helper.MakeDoubleValid(txtDeposit.Text);
                CurrentQuoteJob.SetVatRateID = Combo.get_GetSelectedItemValue(cboVAT);
                CurrentQuoteJob.ChangedDateTime = DateAndTime.Now;
                CurrentQuoteJob.SetChangedByUserID = App.loggedInUser.UserID;
                CurrentQuoteJob.SetOriginalQuotedAmount = CurrentQuoteJob.OriginalQuotedAmount;
                CurrentQuoteJob.SetElectricianPackTypeID = Combo.get_GetSelectedItemValue(cboElectricalPack);
                CurrentQuoteJob.SetSORCharge = chkSORCharge.Checked;
                CurrentQuoteJob.SetAccessEquipmentID = Combo.get_GetSelectedItemValue(cboAccess);
                CurrentQuoteJob.SetAsbestosID = Combo.get_GetSelectedItemValue(cboAsbestos);
                CurrentQuoteJob.SetAdditionalCosts = Helper.MakeDoubleValid(txtAccess.Text);
                CurrentQuoteJob.SetAsbestosComment = txtAsbestos.Text;
                CurrentQuoteJob.EstStartDate = Helper.MakeDateTimeValid(dtpQuoteDate.Value);
                CurrentQuoteJob.SetSurveyVisitID = CurrentQuoteJob.SurveyVisitID;
                CurrentQuoteJob.SetDepartment = Combo.get_GetSelectedItemValue(cboDept);
                CurrentQuoteJob.QuoteAssets.Clear();
                foreach (DataRow row in AssetsDataView.Table.Rows)
                {
                    if (Conversions.ToBoolean(row["Tick"]))
                    {
                        var qJobAsset = new Entity.QuoteJobAssets.QuoteJobAsset();
                        qJobAsset.SetAssetID = Helper.MakeIntegerValid(row["AssetID"]);
                        CurrentQuoteJob.QuoteAssets.Add(qJobAsset);
                    }
                }

                Entity.QuoteJobOfWorks.QuoteJobOfWork qJobOfWork;
                if (CurrentQuoteJob.QuoteJobOfWorks.Count > 0)
                {
                    qJobOfWork = (Entity.QuoteJobOfWorks.QuoteJobOfWork)CurrentQuoteJob.QuoteJobOfWorks[0];
                    qJobOfWork.QuoteJobItems.Clear();
                }
                else
                {
                    qJobOfWork = new Entity.QuoteJobOfWorks.QuoteJobOfWork();
                }

                qJobOfWork.IgnoreExceptionsOnSetMethods = true;
                CurrentQuoteJob.QuoteJobOfWorks.Clear();
                foreach (DataRow row in CurrentQuoteJob.ScheduleOfRates.Table.Rows)
                {
                    var qJobItem = new Entity.QuoteJobItems.QuoteJobItem();
                    qJobItem.IgnoreExceptionsOnSetMethods = true;
                    qJobItem.SetSummary = Helper.MakeStringValid(row["Description"]);
                    qJobItem.SetRateID = Helper.MakeIntegerValid(row["RateID"]);
                    if (row.Table.Columns.Contains("SystemLinkID"))
                    {
                        qJobItem.SetSystemLinkID = Helper.MakeIntegerValid(row["SystemLinkID"]);
                    }

                    qJobItem.SetQty = Helper.MakeDoubleValid(row["Quantity"]);
                    qJobOfWork.QuoteJobItems.Add(qJobItem);
                }

                CurrentQuoteJob.QuoteJobOfWorks.Add(qJobOfWork);
                var jV = new Entity.QuoteJobs.QuoteJobValidator();
                jV.Validate(CurrentQuoteJob, JobItemsDataView);
                if (CurrentQuoteJob.Exists)
                {
                    CurrentQuoteJob = App.DB.QuoteJob.Update(CurrentQuoteJob);
                }
                else
                {
                    CurrentQuoteJob = App.DB.QuoteJob.Insert(CurrentQuoteJob);
                    QuoteNumberUsed = true;
                    App.ShowMessage("Quote added : " + CurrentQuoteJob.Reference, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                StateChanged?.Invoke(CurrentQuoteJob.QuoteJobID);
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

        public void RejectReasonChanged(string Reason, int ReasonID)
        {
            CurrentQuoteJob.SetReasonForReject = Reason;
            CurrentQuoteJob.SetReasonForRejectID = ReasonID;
            Save();
        }

        private DataView BuildUpScheduleOfRatesDataview()
        {
            var newTable = new DataTable();
            newTable.Columns.Add("ScheduleOfRatesCategoryID");
            newTable.Columns.Add("Category");
            newTable.Columns.Add("Code");
            newTable.Columns.Add("Description");
            newTable.Columns.Add("Price", Type.GetType("System.Double"));
            newTable.Columns.Add("Quantity", Type.GetType("System.Double"));
            newTable.Columns.Add("Total", Type.GetType("System.Double"));
            newTable.Columns.Add("RateID", Type.GetType("System.Int32"));
            newTable.Columns.Add("TimeInMins", Type.GetType("System.Int32"));
            newTable.TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
            return new DataView(newTable);
        }

        private void cboElectricalPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Electrician

            var switchExpr = Combo.get_GetSelectedItemValue(cboElectricalPack);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                    {
                        txtElectricianCost.Text = Strings.Format(Helper.MakeDoubleValid(CurrentQuoteJob?.ElectricianLabourHrs) * 27.5, "C"); // Hard coded Rate TODO
                        break;
                    }

                case var case1 when case1 == 1.ToString():
                    {
                        txtElectricianCost.Text = Strings.Format(100, "C");
                        break;
                    }

                case var case2 when case2 == 2.ToString():
                    {
                        txtElectricianCost.Text = Strings.Format(155, "C");
                        break;
                    }

                case var case3 when case3 == 3.ToString():
                    {
                        txtElectricianCost.Text = Strings.Format(500, "C");
                        break;
                    }
            }

            WorkOutGrandTotal();
        }

        private void chkSORCharge_CheckedChanged(object sender, EventArgs e)
        {
            WorkOutGrandTotal();
        }

        private void txtBuilderHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double bulderDayRate = 200.0;
                double days = Helper.MakeDoubleValid(txtBuilderHours.Text) / 8;
                double bulderDays = Math.Ceiling(days / 0.5) * 0.5;
                txtBuilderCost.Text = Strings.Format(bulderDays * bulderDayRate, "C");
            }
            catch (Exception ex)
            {
            }

            WorkOutGrandTotal();
        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
        }

        private string EmailBody(DataTable dt)
        {
            string Body = @"<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:w=""urn:schemas-microsoft-com:office:word"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:m=""http://schemas.microsoft.com/office/2004/12/omml"" xmlns=""http://www.w3.org/TR/REC-html40""><head><meta http-equiv=Content-Type content=""text/html; charset=iso-8859-1""><meta name=Generator content=""Microsoft Word 15 (filtered medium)""><style><!--
                        /* Font Definitions */
                        @font-face
                            {font-family:""Cambria Math"";
                            panose-1:2 4 5 3 5 4 6 3 2 4;}
                        @font-face
                            {font-family:Calibri;
                            panose-1:2 15 5 2 2 2 4 3 2 4;}
                        /* Style Definitions */
                        p.MsoNormal, li.MsoNormal, div.MsoNormal
                            {margin:0cm;
                            margin-bottom:.0001pt;
                            font-size:11.0pt;
                            font-family:""Calibri"",sans-serif;
                            mso-fareast-language:EN-US;}
                        a:link, span.MsoHyperlink
                            {mso-style-priority:99;
                            color:#0563C1;
                            text-decoration:underline;}
                        a:visited, span.MsoHyperlinkFollowed
                            {mso-style-priority:99;
                            color:#954F72;
                            text-decoration:underline;}
                        span.EmailStyle17
                            {mso-style-type:personal-compose;
                            font-family:""Calibri"",sans-serif;
                            color:windowtext;}
                        .MsoChpDefault
                            {mso-style-type:export-only;
                            font-family:""Calibri"",sans-serif;
                            mso-fareast-language:EN-US;}
                        @page WordSection1
                            {size:612.0pt 792.0pt;
                            margin:72.0pt 72.0pt 72.0pt 72.0pt;}
                        div.WordSection1
                            {page:WordSection1;}
                        --></style><!--[if gte mso 9]><xml>
                        <o:shapedefaults v:ext=""edit"" spidmax=""1026"" />
                        </xml><![endif]--><!--[if gte mso 9]><xml>
                        <o:shapelayout v:ext=""edit"">
                        <o:idmap v:ext=""edit"" data=""1"" />
                        </o:shapelayout></xml><![endif]--></head><body lang=EN-GB link=""#0563C1"" vlink=""#954F72"">
                        <div class=WordSection1><p class=MsoNormal>Dear Sir/Madam,<o:p></o:p></p>
                        <p class=MsoNormal><o:p>&nbsp;</o:p></p>
                        <table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 align=left width=799 style='width:599.15pt;border-collapse:collapse;margin-left:6.75pt;margin-right:6.75pt'>
                        <tr style='height:15.0pt'>
                        <td width=115 nowrap valign=bottom style='width:86.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
                        <p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
                        <b><span style='color:black;mso-fareast-language:EN-GB'>SOR CODE<o:p></o:p></span></b></p>
                        </td>
                        <td width=487 nowrap valign=bottom style='width:365.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
                        <p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>Description<o:p></o:p></span></b></p>
                        </td>
                        <td width=64 nowrap valign=bottom style='width:48.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
                        <p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>Qty<o:p></o:p></span></b></p>
                        </td>
                        <td width=70 nowrap valign=bottom style='width:52.15pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
                        <p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>UnitPrice<o:p></o:p></span></b></p>
                        </td>
                        <td width=64 nowrap valign=bottom style='width:70.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>Line Total<o:p></o:p></span></b></p>
                        </td>
                        </tr>";
            foreach (DataRow dr in dt.Rows)
                Body += Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(@"
            <tr style='height:15.0pt'>
            <td width=115 nowrap valign=bottom style='width:86.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
            <p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>" + dr["Code"] + @"<o:p></o:p></span></p>
            </td>
            <td width=487 nowrap valign=bottom style='width:365.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>") + dr["Description"] + @"<o:p></o:p>
            </span></p>
            </td>
            <td width=64 nowrap valign=bottom style='width:48.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>") + dr["quantity"] + @"<o:p></o:p>
            </span></p>
            </td>
            <td width=70 nowrap valign=bottom style='width:52.15pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>£") + dr["Price"] + @"<o:p></o:p></span>
            </p></td>
            <td width=64 nowrap valign=bottom style='width:55.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>£") + dr["Total"] + @"<o:p></o:p></span>
            </p>
            </td>
            </tr>";
            Body += @"</table>
                <p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p>
                <p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p>
                <p class=MsoNormal><o:p></o:p></p></div>";
            return Body;
        }

        private void btnEmailSOR_Click(object sender, EventArgs e)
        {
            if (Helper.IsEmailValid(App.loggedInUser.EmailAddress))
            {
                string Body = EmailBody(CurrentQuoteJob.ScheduleOfRates.Table);
                var oEmail = new Emails();
                oEmail.Body = Body;
                oEmail.From = EmailAddress.FSM;
                oEmail.To = App.loggedInUser.EmailAddress;
                oEmail.Subject = "SOR List";
                oEmail.SendMe = true;
                oEmail.Send();
            }
            else
            {
                App.ShowMessage("Your email address has not been added to your account, please contact IT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}