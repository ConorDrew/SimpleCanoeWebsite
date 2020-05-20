using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCSearchSpares : UCBase, ISearchControl
    {
        

        public UCSearchSpares() : base()
        {
            base.Load += UCSearchSetup_Load;

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

        private ComboBox _cboSearchFor;

        internal ComboBox cboSearchFor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSearchFor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSearchFor != null)
                {
                    
                    
                    _cboSearchFor.SelectedIndexChanged -= cboSearchFor_SelectedIndexChanged;
                }

                _cboSearchFor = value;
                if (_cboSearchFor != null)
                {
                    _cboSearchFor.SelectedIndexChanged += cboSearchFor_SelectedIndexChanged;
                }
            }
        }

        private TextBox _txtCriteria;

        internal TextBox txtCriteria
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCriteria;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCriteria != null)
                {
                    _txtCriteria.KeyUp -= txtCriteria_KeyUp;
                }

                _txtCriteria = value;
                if (_txtCriteria != null)
                {
                    _txtCriteria.KeyUp += txtCriteria_KeyUp;
                }
            }
        }

        private Button _btnFind;

        internal Button btnFind
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFind;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFind != null)
                {
                    _btnFind.Click -= btnFind_Click;
                }

                _btnFind = value;
                if (_btnFind != null)
                {
                    _btnFind.Click += btnFind_Click;
                }
            }
        }

        private ComboBox _cboSearchOn;

        internal ComboBox cboSearchOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSearchOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSearchOn != null)
                {
                }

                _cboSearchOn = value;
                if (_cboSearchOn != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _Label1 = new Label();
            _cboSearchFor = new ComboBox();
            _cboSearchFor.SelectedIndexChanged += new EventHandler(cboSearchFor_SelectedIndexChanged);
            _Label2 = new Label();
            _txtCriteria = new TextBox();
            _txtCriteria.KeyUp += new KeyEventHandler(txtCriteria_KeyUp);
            _btnFind = new Button();
            _btnFind.Click += new EventHandler(btnFind_Click);
            _cboSearchOn = new ComboBox();
            _Label3 = new Label();
            _Label4 = new Label();
            SuspendLayout();
            //
            // Label1
            //
            _Label1.Location = new Point(8, 3);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(72, 16);
            _Label1.TabIndex = 0;
            _Label1.Text = "Search";
            //
            // cboSearchFor
            //
            _cboSearchFor.Cursor = Cursors.Hand;
            _cboSearchFor.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSearchFor.Location = new Point(34, 18);
            _cboSearchFor.Name = "cboSearchFor";
            _cboSearchFor.Size = new Size(123, 21);
            _cboSearchFor.TabIndex = 1;
            //
            // Label2
            //
            _Label2.Location = new Point(7, 65);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(152, 16);
            _Label2.TabIndex = 2;
            _Label2.Text = "Enter Search Criteria";
            //
            // txtCriteria
            //
            _txtCriteria.Location = new Point(10, 84);
            _txtCriteria.MaxLength = 25;
            _txtCriteria.Name = "txtCriteria";
            _txtCriteria.Size = new Size(96, 21);
            _txtCriteria.TabIndex = 2;
            //
            // btnFind
            //
            _btnFind.AccessibleDescription = "Search for records by comparing multiple columns";
            _btnFind.Cursor = Cursors.Hand;
            _btnFind.Location = new Point(112, 84);
            _btnFind.Name = "btnFind";
            _btnFind.Size = new Size(45, 23);
            _btnFind.TabIndex = 3;
            _btnFind.Text = "Find";
            _btnFind.UseVisualStyleBackColor = true;
            //
            // cboSearchOn
            //
            _cboSearchOn.Cursor = Cursors.Hand;
            _cboSearchOn.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSearchOn.Location = new Point(34, 41);
            _cboSearchOn.Name = "cboSearchOn";
            _cboSearchOn.Size = new Size(123, 21);
            _cboSearchOn.TabIndex = 4;
            //
            // Label3
            //
            _Label3.Location = new Point(8, 44);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(72, 16);
            _Label3.TabIndex = 5;
            _Label3.Text = "On";
            //
            // Label4
            //
            _Label4.AutoSize = true;
            _Label4.Location = new Point(8, 21);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(25, 13);
            _Label4.TabIndex = 6;
            _Label4.Text = "For";
            //
            // UCSearchSpares
            //
            Controls.Add(_Label4);
            Controls.Add(_cboSearchOn);
            Controls.Add(_btnFind);
            Controls.Add(_txtCriteria);
            Controls.Add(_Label2);
            Controls.Add(_cboSearchFor);
            Controls.Add(_Label1);
            Controls.Add(_Label3);
            Name = "UCSearchSpares";
            Size = new Size(160, 111);
            ResumeLayout(false);
            PerformLayout();
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            var argc = cboSearchFor;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Setup_Search_Options(Entity.Sys.Enums.MenuTypes.Spares), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argcombo = cboSearchFor;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(Entity.Sys.Enums.TableNames.tblPart));
        }

        public void Search()
        {
            if ((Combo.get_GetSelectedItemValue(cboSearchFor) ?? "") == "0")
            {
                App.ShowMessage("Please select what you would like to search for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Navigation.Close_Middle();
            Navigation.Close_Right();
            foreach (Form form in App.MainForm.MdiChildren)
                form.Dispose();
            var switchExpr = Combo.get_GetSelectedItemValue(cboSearchFor);
            switch (switchExpr)
            {
                case var @case when @case == Conversions.ToString(Entity.Sys.Enums.TableNames.tblSupplier):
                    {
                        App.MainForm.SetSearchResults(App.DB.Supplier.Supplier_Search(txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(cboSearchOn)), Entity.Sys.Enums.PageViewing.Supplier, false, false);
                        break;
                    }

                case var case1 when case1 == Conversions.ToString(Entity.Sys.Enums.TableNames.tblProduct):
                    {
                        App.MainForm.SetSearchResults(App.DB.Product.Product_Search(txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(cboSearchOn)), Entity.Sys.Enums.PageViewing.Product, false, false);
                        break;
                    }

                case var case2 when case2 == Conversions.ToString(Entity.Sys.Enums.TableNames.tblPart):
                    {
                        App.MainForm.SetSearchResults(App.DB.Part.Part_Search(txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(cboSearchOn)), Entity.Sys.Enums.PageViewing.Part, false, false);
                        break;
                    }

                case var case3 when case3 == Conversions.ToString(Entity.Sys.Enums.TableNames.tblWarehouse):
                    {
                        App.MainForm.SetSearchResults(App.DB.Warehouse.Warehouse_Search(txtCriteria.Text.Trim(), Combo.get_GetSelectedItemValue(cboSearchOn)), Entity.Sys.Enums.PageViewing.Warehouse, false, false);
                        break;
                    }
            }
        }

        private void cboSearchFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var argc = cboSearchOn;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Setup_Search_On_Options(Entity.Sys.Enums.MenuTypes.Spares, (Entity.Sys.Enums.TableNames)Convert.ToInt32(Combo.get_GetSelectedItemValue(cboSearchFor))), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argcombo = cboSearchOn;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "");
        }

        private void UCSearchSetup_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtCriteria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        
    }
}