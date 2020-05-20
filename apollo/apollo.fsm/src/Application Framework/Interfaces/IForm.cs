using System;

namespace FSM
{
    public interface IForm
    {
        void LoadMe(object sender, EventArgs e);

        IUserControl LoadedControl { get; }

        void ResetMe(int newID);
    }
}