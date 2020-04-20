using System;
using System.Data;
using System.Windows.Forms;

namespace FSM
{
    public interface ISchedulerForm
    {
        string Name { get; }
        string EngineerID { get; set; }
        bool IsDisposed { get; }
        PictureBox PicPlanner { get; }
        DataTable TimeSlotDt { get; set; }

        string selectedDay();

        IntPtr Handle { get; }
    }
}