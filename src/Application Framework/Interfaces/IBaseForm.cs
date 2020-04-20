using System;
using System.Collections;
using System.Windows.Forms;

namespace FSM
{
    public interface IBaseForm
    {
        ArrayList FormButtons { get; set; }

        void LoadForm(object sender, EventArgs e, IForm frm);
        void LoadForm(Form frm);
        void LoopControls(Control controlToLoop);
        void SetupButtonMouseOvers();
        void CreateHover(object sender, EventArgs e);

        Array SetFormParameters { set; }
        object GetParameter { get; }
        int GetParameterCount { get; }
    }
}