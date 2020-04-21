using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace FSM
{
    public class DataGridRowHeightSetter
    {
        private DataGrid dg;
        private ArrayList rowObjects;

        public DataGridRowHeightSetter(DataGrid dg)
        {
            this.dg = dg;
            InitHeights();
        }

        public int this[int row]
        {
            get
            {
                try
                {
                    var pi = rowObjects[row].GetType().GetProperty("Height");
                    return Conversions.ToInteger(Conversion.Fix(pi.GetValue(rowObjects[row], null)));
                }
                catch
                {
                    throw new ArgumentException("invalid row index");
                }
            }

            set
            {
                try
                {
                    var pi = rowObjects[row].GetType().GetProperty("Height");
                    pi.SetValue(rowObjects[row], value, null);
                }
                catch
                {
                    throw new ArgumentException("Invalid row index");
                }
            }
        }

        private void InitHeights()
        {
            var mi = dg.GetType().GetMethod("get_DataGridRows", BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            Array dgra = (Array)mi.Invoke(dg, null);
            rowObjects = new ArrayList();
            object dgrr;
            foreach (var dgrr in dgra)
            {
                if (dgrr.ToString().EndsWith("DataGridRelationshipRow") == true)
                {
                    rowObjects.Add(dgrr);
                }
            }
        }
    }
}