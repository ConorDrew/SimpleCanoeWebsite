// Decompiled with JetBrains decompiler
// Type: FSM.BindableChildItem
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

namespace FSM
{
  public abstract class BindableChildItem : BindableItem
  {
    public event BindableChildItem.RemoveMeEventHandler RemoveMe;

    private void onRemoveMe()
    {
      // ISSUE: reference to a compiler-generated field
      BindableChildItem.RemoveMeEventHandler removeMeEvent = this.RemoveMeEvent;
      if (removeMeEvent == null)
        return;
      removeMeEvent(this);
    }

    protected override void CancelEdit()
    {
      base.CancelEdit();
      if (!this._isNew)
        return;
      this.onRemoveMe();
    }

    public delegate void RemoveMeEventHandler(BindableChildItem item);
  }
}
