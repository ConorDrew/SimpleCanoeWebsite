using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class DataGridOrderTextBoxColumn : DataGridTextBoxColumn
    {
        public DataGridOrderTextBoxColumn() : base()
        {
            TextBox.BackColor = Color.LightYellow;
        }

        protected override void Abort(int rowNum)
        {
            base.Abort(rowNum);
        }

        protected override bool Commit(CurrencyManager dataSource, int rowNum)
        {
            return base.Commit(dataSource, rowNum);
        }

        protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)
        {
            TextBox.Enabled = true;
            base.Edit(source, rowNum, bounds, false, instantText, cellIsVisible);
        }

        protected override int GetMinimumHeight()
        {
            return base.GetMinimumHeight();
        }

        protected override int GetPreferredHeight(Graphics g, object value)
        {
            return base.GetPreferredHeight(g, value);
        }

        protected override Size GetPreferredSize(Graphics g, object value)
        {
            return base.GetPreferredSize(g, value);
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum)
        {
            base.Paint(g, bounds, source, rowNum);
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, bool alignToRight)
        {
            base.Paint(g, bounds, source, rowNum, alignToRight);
        }
    }
}