using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    // Imports SolutionsNET.BusinessClass.Bases

    public class DataGridComboBoxColumn : DataGridColumnStyle
    {
        public DataGridComboBoxColumn()
        {
            base.WidthChanged += NewComboBoxColumn_WidthChanged;
        }

        public DataGridComboBoxColumn(System.Data.SqlClient.SqlTransaction trans, bool isGetFrom = false)
        {
            base.WidthChanged += NewComboBoxColumn_WidthChanged;
            _getFrom = isGetFrom;
            myComboBox = new ComboBox();
            myComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            myComboBox.Cursor = Cursors.Hand;
            myComboBox.Visible = false;
            this.trans = trans;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public DataGridComboBoxColumn(bool isGetFrom = false)
        {
            base.WidthChanged += NewComboBoxColumn_WidthChanged;
            _getFrom = isGetFrom;
            myComboBox = new ComboBox();
            myComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            myComboBox.Cursor = Cursors.Hand;
            myComboBox.Visible = false;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        // This internal combobox is the key component of all this.
        // It will be moved around to the cells that are to be edited
        // set to the correct value and then shown.  When
        // the user navigates off the cell, then this combobox is
        // hidden.
        private ComboBox _myComboBox;

        private ComboBox myComboBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _myComboBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_myComboBox != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _myComboBox.SelectedIndexChanged -= myComboBox_SelectedIndexChanged;
                }

                _myComboBox = value;
                if (_myComboBox != null)
                {
                    _myComboBox.SelectedIndexChanged += myComboBox_SelectedIndexChanged;
                }
            }
        }

        private bool _getFrom = false;
        private int _theID = 0;
        private string _type = "";
        private string _searchingFor;
        private int _returnID = 0;
        private System.Data.SqlClient.SqlTransaction trans;

        public event itemSelectedEventHandler itemSelected;

        public delegate void itemSelectedEventHandler();

        // You will see this used in the "Edit" and "Commit" members below.
        private int myPreviouslyEditedCellRow;

        private void myComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_getFrom == true)
            {
                int[] IDs;
                var switchExpr = Conversions.ToInteger(myComboBox.SelectedValue);
                switch (switchExpr)
                {
                    case 1:
                        {
                            // SUPPLIER
                            int SupplierID = 0;
                            SearchingFor = "Supplier";
                            if ((Type ?? "") == "Product")
                            {
                                if (trans is object)
                                {
                                    SupplierID = App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct, trans, TheID);
                                }
                                else
                                {
                                    SupplierID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct, TheID));
                                }

                                if (SupplierID == 0)
                                    return;
                                FRMChooseSupplierPacks FRMChoose = (FRMChooseSupplierPacks)App.ShowForm(typeof(FRMChooseSupplierPacks), true, new object[] { SupplierID, TheID, 0, trans });
                                if (FRMChoose.DialogResult == DialogResult.OK)
                                {
                                    ReturnID = FRMChoose.ProductSupplierID;
                                }
                            }
                            else
                            {
                                if (trans is object)
                                {
                                    SupplierID = App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart, trans, TheID);
                                }
                                else
                                {
                                    SupplierID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart, TheID));
                                }

                                if (SupplierID == 0)
                                    return;
                                FRMChooseSupplierPacks FRMChoose = (FRMChooseSupplierPacks)App.ShowForm(typeof(FRMChooseSupplierPacks), true, new object[] { SupplierID, 0, TheID, trans });
                                if (FRMChoose.DialogResult == DialogResult.OK)
                                {
                                    ReturnID = FRMChoose.PartSupplierID;
                                }
                            }

                            itemSelected?.Invoke();
                            break;
                        }

                    case 3:
                        {
                            // WAREHOUSE
                            SearchingFor = "Warehouse";
                            if ((Type ?? "") == "Product")
                            {
                                if (trans is object)
                                {
                                    ReturnID = App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct, trans, TheID);
                                }
                                else
                                {
                                    ReturnID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct, TheID));
                                }
                            }
                            else if (trans is object)
                            {
                                ReturnID = App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart, trans, TheID);
                            }
                            else
                            {
                                ReturnID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart, TheID));
                            }

                            itemSelected?.Invoke();
                            break;
                        }

                    case 2:
                        {
                            // VAN
                            SearchingFor = "Van";
                            if ((Type ?? "") == "Product")
                            {
                                if (trans is object)
                                {
                                    ReturnID = App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct, trans, TheID);
                                }
                                else
                                {
                                    ReturnID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct, TheID));
                                }
                            }
                            else if (trans is object)
                            {
                                ReturnID = App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart, trans, TheID);
                            }
                            else
                            {
                                ReturnID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart, TheID));
                            }

                            itemSelected?.Invoke();
                            break;
                        }
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public int ReturnID
        {
            get
            {
                return _returnID;
            }

            set
            {
                _returnID = value;
            }
        }

        public int TheID
        {
            get
            {
                return _theID;
            }

            set
            {
                _theID = value;
            }
        }

        public string SearchingFor
        {
            get
            {
                return _searchingFor;
            }

            set
            {
                _searchingFor = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public ComboBox ComboBox
        {
            get
            {
                // We expose the combobox so that its databinding
                // properties can be set when we are setting
                // the columnstyle properties.
                return myComboBox;
            }
        }

        private DataGrid parentGrid
        {
            get
            {
                // Just an internal convenience, used in the "Paint" method below.
                return (DataGrid)Container;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Abort(int rowNum)
        {
            // when the user aborts the editing of a combobox cell, this method is called and
            // it will remove the combobox from site on the form.
            myComboBox.Visible = false;
        }

        protected override bool Commit(CurrencyManager dataSource, int rowNum)
        {
            // when the user select's a new item, then the new value needs to be set
            // in the bound data.
            // The call to "SetColumnValueAtRow" sets the correct value from
            // the("selectedValue")property in the bound data source.

            // We qualify this to only rows that we know from the 'Edit' method
            // that we have been editing.

            // And of course, set the combobox to not be visible in any case.
            try
            {
                if (myPreviouslyEditedCellRow == rowNum)
                {
                    base.SetColumnValueAtRow(dataSource, rowNum, myComboBox.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                // AMY PUPOSELY LEFT EMPTY
            }

            myComboBox.Visible = false;
            return true;
        }

        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)

        {
            // Here is where the work takes place.  Whenever ever the user enters the cell
            // by any means, this override method is called.

            Debug.WriteLine(string.Format("ComboBox Edit; current Height: {0}", myComboBox.Height));

            // At this point, the cell is looking just like a text box, and displaying the
            // appropriate to the user.  But now that we have navigation into the cell, we
            // need to display our combobox overtop of the location in the form.  But first
            // we need to make sure that the combobox will be displaying the correct value
            // for this cell.

            // First, use our method "GetColumnValueAtRow" to obtain the actual display
            // value that corresponds to the value in this cell.
            // Typically, this is a classic "Lookup" situation, so its a guid,
            // or ID code of some sort.  In this demo, its a two letter code
            // (such as PA for Pennsylvania) for the state.  So what gets returned
            // is the "DisplayValue" for the state code.  In other words, "Pennsylvania"
            // is returned, not "PA"
            var currentValue = GetColumnValueAtRow(source, rowNum);
            if (currentValue is null)
            {
                // If its a new row, or if its never been set, then we tell the
                // combobox that there is NO selection.
                myComboBox.SelectedItem = null;
            }
            else
            {
                // But otherwise, we use the "FindStringExact" method to get
                // the corresponding Index value of a string in our bound "lookup" list
                // And we set the "SelectedIndex" value accordingly.  This causes the
                // combobox to have the correct item displayed when we set its
                // "Visible" property from false to true.
                myComboBox.SelectedIndex = myComboBox.FindStringExact(Conversions.ToString(currentValue));
            }

            // This prepares the combobox to be the correct back color for when there
            // are alternating row colors.
            if (IsOdd(rowNum))
            {
                myComboBox.BackColor = base.DataGridTableStyle.AlternatingBackColor;
            }
            else
            {
                myComboBox.BackColor = base.DataGridTableStyle.BackColor;
            }

            // Bounds is a rectangle object that corresponds to the exact coordinates and
            // size of the current cell we need to edit.  So we use it to put the
            // combobox at the correct location, and we display it here too.
            myComboBox.Location = new Point(bounds.X, bounds.Y);
            myComboBox.Visible = true;

            // This is a nice UI touch, not functionally necessary but I like it.
            // It gives consistency to the look and feel the user is
            // navigating the grid.
            if (currentValue is object)
            {
                // make the text selected by default
                try
                {
                    myComboBox.SelectionStart = 0;
                    myComboBox.SelectionLength = currentValue.ToString().Length;
                }
                catch (Exception ex)
                {
                    // AMY PUPOSELY LEFT EMPTY
                }
            }

            Debug.WriteLine("SelectedItem: " + myComboBox.SelectedIndex.ToString());

            // And this will indicate to the "Commit" method that we have edited the cell
            // in this row.
            myPreviouslyEditedCellRow = rowNum;
        }

        private bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override object GetColumnValueAtRow(CurrencyManager source, int rowNum)
        {
            // This is a key method.  Given the row number and the
            // source CurrencyManager, (which contains a reference
            // to the bound DataSource list), we can obtain the
            // *ValueMember* from the MyBase method, and then use that
            // to obtain the *DisplayMember* from the combobox
            // And that is what this method will return.

            // Get the ValueMember (The lookup code so to speak, like "PA"
            // in our example)
            var myValueMember = base.GetColumnValueAtRow(source, rowNum);
            object myDisplayMember;

            // Get the DisplayMember.  In our example it would be "Pennsylvania"
            myDisplayMember = getItem(myValueMember, true);

            // And return the DisplayMember value
            return myDisplayMember;
        }

        private object getItem(object findByValue, bool findByValueMember)
        {
            // This method will find items in our ComboBox's datasource.
            // Given a valueMember it will find the corresponding
            // displayMember, or given a displayMember
            // it will find the corresponding valueMember.
            // The "findByValueMember" tells us which way it is.

            // if findByValueMember is true then we want to return
            // the corresponding DisplayMember
            // otherwise then we want to return the corresponding
            // ValueMember
            string returnProperty = myComboBox.DisplayMember;
            string compareProperty = myComboBox.ValueMember;
            if (findByValueMember)
            {
                returnProperty = myComboBox.DisplayMember;
                compareProperty = myComboBox.ValueMember;
            }
            else
            {
                returnProperty = myComboBox.ValueMember;
                compareProperty = myComboBox.DisplayMember;
            }

            // Of course, we iterate datasource of combobox list
            // NOT the datasource of the datagrid

            // We get the currency manager of the datasource here.
            CurrencyManager myCm = (CurrencyManager)base.DataGridTableStyle.DataGrid.BindingContext[myComboBox.DataSource];

            if (myCm.List is DataView)
            {
                // The ComboBox is bound to a DataView, or DataTable that implements a default
                // DataView and so cast the currency manager's list to a DataView
                DataView myDV = (DataView)myCm.List;

                // Now do the iteration
                int myIndex;
                var loopTo = myDV.Count - 1;
                for (myIndex = 0; myIndex <= loopTo; myIndex += 1)
                {
                    if (findByValue.Equals(myDV[myIndex][compareProperty]))
                    {
                        break;
                    }
                }

                // If set item was found return corresponding value, otherwise return nothing
                if (myIndex < myDV.Count)
                {
                    return myDV[myIndex][returnProperty];
                }
                else
                {
                    return null;
                }
            }
            else if (myCm.List is BindableCollection)
            {
                // The ComboBox is bound to an IBindingList implementation
                // so cast the currency manager's list to an IBindingList object
                BindableCollection myList = (BindableCollection)myCm.List;
                var myItem = default(BindableItem);
                bool isEqual = false;

                // Now do the iteration
                foreach (var myItem1 in myList)
                {
                    if (findByValue.Equals(myItem1.get_PropertyValue(compareProperty)))
                    {
                        isEqual = true;
                        break;
                    }
                }

                // If set item was found return corresponding value, otherwise return nothing
                if (isEqual)
                {
                    return myItem.get_PropertyValue(returnProperty);
                }
                else
                {
                    return null;
                }
            }

            return default;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void NewComboBoxColumn_WidthChanged(object sender, EventArgs e)

        {
            // This method is what adjusts the width of the combobox
            // if the user resizes the datagrid column.
            myComboBox.Width = base.Width;
            base.Invalidate();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override int GetMinimumHeight()
        {
            // When the datagrid is first being painted, it checks each column
            // for this method and whichever column returns the highest value
            // that is the value that the row height is set too.

            // By setting this property to some text value, we force the combobox to adjust
            // it's height to its font size.  It apparently gets its default
            // font size from its container, which is the datagrid.
            // So if we change the font of the datagrid, this combobox
            // font default changes accordingly, and we want our combobox
            // to reflect that.  Hence setting the text to 'something'
            // Otherwise, the font size will not be reflected in the
            // height of our combobox and our minimum height may not
            // be adequate.
            myComboBox.SelectedText = "something";
            return GetPreferredHeight(null, null);
        }

        protected override int GetPreferredHeight(Graphics g, object value)
        {
            return myComboBox.Height;
        }

        protected override Size GetPreferredSize(Graphics g, object value)
        {
            return new Size(myComboBox.Width, GetPreferredHeight(g, value));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum)

        {
            Paint(g, bounds, source, rowNum, false);
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, bool alignToRight)

        {
            base.Paint(g, bounds, source, rowNum, Brushes.White, Brushes.Black, false);
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)

        {
            // This method is responsible for painting the cell
            // for all instances except when the combobox is visible.
            // This method usually gets called once for each
            // row in the column.  So the grid uses this method
            // on each column style to paint itself cell by
            // cell from left to right and top to bottom.

            // So first, we want to get the value of the text that needs to be shown.
            string displayMember = Conversions.ToString(GetColumnValueAtRow(source, rowNum));

            // Next we want to paint the whole background color of
            // the cell area appropriately.  By using the backBrush
            // passed in, we get the color of the rest of the row
            // and so this column cell will match the rest of the
            // row.  This makes for row selections and alternating
            // row colors to be painted appropriately in this cell.

            // colour the row if it is selected
            if (source.Position != -1)
            {
                if (rowNum == source.Position)
                {
                    g.FillRectangle(new SolidBrush(Color.LightSteelBlue), bounds);
                }
                else
                {
                    g.FillRectangle(backBrush, bounds);
                }
            }

            // demo this line and then comment it out.
            // g.FillRectangle(New SolidBrush(Color.White), bounds)

            // Next, we create slightly adjusted rectangle in which to
            // paint the text overtop of the background just painted.
            RectangleF textRect;
            textRect = new RectangleF(bounds.X + 1, bounds.Y + 2, bounds.Width - 3, FontHeight);

            // demo this line to show how an unadjusted text draw looks
            // then comment it out.
            // textRect = New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height)

            g.DrawString(displayMember, myComboBox.Font, foreBrush, textRect);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        protected override void SetDataGridInColumn(DataGrid value)
        {
            // This method probably sets a reference within
            // our base to the parent datagrid, so it may be
            // retrieved from the MyBase.Container property.
            // Likely called early on when the tablestyle is
            // added to the DataGridTableStyles collection
            // of the datagrid to which this belongs
            base.SetDataGridInColumn(value);

            // And here, we make sure that the Parent DataGrid
            // contains a reference to this instance in its
            // collection of contained controls.
            if (!value.Controls.Contains(myComboBox))
            {
                value.Controls.Add(myComboBox);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}