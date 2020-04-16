// Decompiled with JetBrains decompiler
// Type: FSM.SubMenuNode
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
  public class SubMenuNode : LinkLabel
  {
    private int _LevelNumber;
    private string _MyName;
    private Array _ChildNodes;
    private string _FormToOpen;
    private Enums.TableNames _TableToSearch;

    public SubMenuNode(string nameIn)
    {
      this._LevelNumber = 1;
      this._MyName = "";
      this._ChildNodes = (Array) null;
      this._FormToOpen = "UsePanels";
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this.LevelNumber = 1;
      this.MyName = nameIn;
    }

    public SubMenuNode(string nameIn, int LevelNumberIn)
    {
      this._LevelNumber = 1;
      this._MyName = "";
      this._ChildNodes = (Array) null;
      this._FormToOpen = "UsePanels";
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this.LevelNumber = LevelNumberIn;
      this.MyName = nameIn;
    }

    public SubMenuNode(string nameIn, Enums.TableNames tableToSearchIn)
    {
      this._LevelNumber = 1;
      this._MyName = "";
      this._ChildNodes = (Array) null;
      this._FormToOpen = "UsePanels";
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this.LevelNumber = 1;
      this.MyName = nameIn;
      this.TableToSearch = tableToSearchIn;
    }

    public SubMenuNode(string nameIn, Enums.TableNames tableToSearchIn, int LevelNumberIn)
    {
      this._LevelNumber = 1;
      this._MyName = "";
      this._ChildNodes = (Array) null;
      this._FormToOpen = "UsePanels";
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this.LevelNumber = LevelNumberIn;
      this.MyName = nameIn;
      this.TableToSearch = tableToSearchIn;
    }

    public SubMenuNode(string nameIn, string formToOpenIn)
    {
      this._LevelNumber = 1;
      this._MyName = "";
      this._ChildNodes = (Array) null;
      this._FormToOpen = "UsePanels";
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this.LevelNumber = 1;
      this.MyName = nameIn;
      this.FormToOpen = formToOpenIn;
    }

    public SubMenuNode(string nameIn, string formToOpenIn, int LevelNumberIn)
    {
      this._LevelNumber = 1;
      this._MyName = "";
      this._ChildNodes = (Array) null;
      this._FormToOpen = "UsePanels";
      this._TableToSearch = Enums.TableNames.NO_TABLE;
      this.LevelNumber = LevelNumberIn;
      this.MyName = nameIn;
      this.FormToOpen = formToOpenIn;
    }

    public int LevelNumber
    {
      get
      {
        return this._LevelNumber;
      }
      set
      {
        this._LevelNumber = value;
      }
    }

    public string MyName
    {
      get
      {
        return this._MyName;
      }
      set
      {
        this._MyName = value;
        this.Text = this.MyName;
        if (this.LevelNumber == 1)
        {
          this.Location = new System.Drawing.Point(5, checked (App.MainForm.MenuBar.pnlSubMenu.Controls.Count * 20));
          this.Size = new Size(152, 15);
        }
        else
        {
          this.Location = new System.Drawing.Point(checked (10 * this.LevelNumber), checked (App.MainForm.MenuBar.pnlSubMenu.Controls.Count * 20));
          this.Size = new Size(checked (152 - 10 * this.LevelNumber), 15);
        }
        this.LinkColor = Color.FromArgb(0, 52, 102);
        this.ActiveLinkColor = Color.FromArgb(0, 52, 102);
        this.DisabledLinkColor = Color.FromArgb(0, 52, 102);
        this.VisitedLinkColor = Color.FromArgb(0, 52, 102);
        this.Click += new EventHandler(this.ButtonClicked);
      }
    }

    public Array ChildNodes
    {
      get
      {
        return this._ChildNodes;
      }
      set
      {
        this._ChildNodes = value;
        IEnumerator enumerator;
        try
        {
          enumerator = this.ChildNodes.GetEnumerator();
          while (enumerator.MoveNext())
          {
            SubMenuNode current = (SubMenuNode) enumerator.Current;
            App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) current);
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
    }

    public string FormToOpen
    {
      get
      {
        return this._FormToOpen;
      }
      set
      {
        this._FormToOpen = value;
      }
    }

    public Enums.TableNames TableToSearch
    {
      get
      {
        return this._TableToSearch;
      }
      set
      {
        this._TableToSearch = value;
      }
    }

    private void ButtonClicked(object sender, EventArgs e)
    {
      Navigation.Sub_Menu(this);
    }
  }
}
