using System;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class DataGridEditableTextBoxColumn : DataGridTextBoxColumn
    {
        public DataGridEditableTextBoxColumn() : base()
        {
        }

        protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
        {
            try
            {
                backBrush = _backColour;
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            }
            catch (Exception ex)
            {
            }
        }

        private Brush _backColour = Brushes.White;

        public Brush BackColourBrush
        {
            get
            {
                return _backColour;
            }

            set
            {
                _backColour = value;
            }
        }
    }
}