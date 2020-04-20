using System;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class DataGridCheckBox : DataGridColumnStyle
    {
        public DataGridCheckBox()
        {
            chkBox = new CheckBox();
            chkBox.Checked = false;
            chkBox.Visible = false;
            chkBox.CheckAlign = ContentAlignment.MiddleCenter;
            Alignment = HorizontalAlignment.Center;
        }

        private CheckBox _chkBox;

        internal CheckBox chkBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _chkBox = value;
            }
        }

        // The isEditing field tracks whether or not the user is
        // editing data with the hosted control.
        private bool isEditing;

        protected override void Abort(int rowNum)
        {
            isEditing = false;
            chkBox.CheckedChanged -= CheckBoxChanged;
            base.Invalidate();
        }

        public event CheckedChangedEventHandler CheckedChanged;

        public delegate void CheckedChangedEventHandler(int @checked);

        private void CheckBoxChanged(object sender, EventArgs e)
        {
            isEditing = true;
            base.ColumnStartedEditing(chkBox);
        }

        protected override bool Commit(CurrencyManager dataSource, int rowNum)
        {
            chkBox.Bounds = Rectangle.Empty;
            chkBox.CheckedChanged += CheckBoxChanged;

            // If Not isEditing Then
            // Return True
            // End If
            isEditing = false;
            chkBox.Enabled = true;
            try
            {
                int value = Conversions.ToInteger(chkBox.Checked) * -1;
                base.SetColumnValueAtRow(dataSource, rowNum, value);
                CheckedChanged?.Invoke(Conversions.ToInteger(chkBox.Checked));
            }
            catch
            {
            }

            base.Invalidate();
            try
            {
                ((DataRowView)dataSource.Current).Row.AcceptChanges();
            }
            catch (Exception ex)
            {
            }

            return true;
        }

        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)





        {
            if (!Information.IsDBNull(base.GetColumnValueAtRow(source, rowNum)))
            {
                bool value = Conversions.ToBoolean(base.GetColumnValueAtRow(source, rowNum));
                if (cellIsVisible)
                {
                    chkBox.Bounds = new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width - 4, bounds.Height - 4);

                    chkBox.BackColor = Color.Transparent;
                    chkBox.Checked = !value;
                    chkBox.Visible = true;
                    base.SetColumnValueAtRow(source, rowNum, chkBox.Checked);
                    chkBox.CheckedChanged += CheckBoxChanged;
                    CheckedChanged?.Invoke(Conversions.ToInteger(chkBox.Checked));
                }
                else
                {
                    chkBox.Checked = value;
                    chkBox.Visible = false;
                }

                if (chkBox.Visible)
                {
                    base.DataGridTableStyle.DataGrid.Invalidate(bounds);
                }
            }

            Commit(source, rowNum);
            base.ConcedeFocus();
            base.UpdateUI(source, rowNum, instantText);
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            var rect = new Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width - 3, bounds.Height - 3);
            if (Information.IsDBNull(base.GetColumnValueAtRow(source, rowNum)) == false)
            {
                bool @checked = Conversions.ToBoolean(base.GetColumnValueAtRow(source, rowNum));
                g.FillRectangle(backBrush, bounds);
                if (@checked == true)
                {
                    ControlPaint.DrawCheckBox(g, rect, ButtonState.Checked);
                }
                else
                {
                    ControlPaint.DrawCheckBox(g, rect, ButtonState.Normal);
                }
            }
            else
            {
                g.FillRectangle(backBrush, bounds);
                ControlPaint.DrawCheckBox(g, rect, ButtonState.Inactive);
            }
        }

        protected override void SetDataGridInColumn(DataGrid value)
        {
            base.SetDataGridInColumn(value);
            if (!(chkBox.Parent is null))
            {
                chkBox.Parent.Controls.Remove(chkBox);
            }

            if (!(value is null))
            {
                value.Controls.Add(chkBox);
            }
        }

        public override bool ReadOnly
        {
            get
            {
                return !chkBox.Enabled;
            }

            set
            {
                chkBox.Enabled = !value;
            }
        }

        protected override Size GetPreferredSize(Graphics g, object value)
        {
            return default;
        }

        protected override int GetMinimumHeight()
        {
            return default;
        }

        protected override int GetPreferredHeight(Graphics g, object value)
        {
            return default;
        }

        protected override void ColumnStartedEditing(Control editingControl)
        {
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum)
        {
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, bool alignToRight)
        {
        }
    }
}