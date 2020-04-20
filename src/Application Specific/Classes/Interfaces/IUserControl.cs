using System;
using System.Data;

namespace FSM
{
    public interface IUserControl
    {
        void LoadForm(object sender, EventArgs e);

        object LoadedItem { get; }

        event RecordsChangedEventHandler RecordsChanged;

        delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        event StateChangedEventHandler StateChanged;

        delegate void StateChangedEventHandler(int newID);

        void Populate(int ID = 0);
        bool Save();
    }
}