using System;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
    public class SubMenuNode : LinkLabel
    {
        public SubMenuNode(string nameIn)
        {
            LevelNumber = 1;
            MyName = nameIn;
        }

        public SubMenuNode(string nameIn, int LevelNumberIn)
        {
            LevelNumber = LevelNumberIn;
            MyName = nameIn;
        }

        public SubMenuNode(string nameIn, Entity.Sys.Enums.TableNames tableToSearchIn)
        {
            LevelNumber = 1;
            MyName = nameIn;
            TableToSearch = tableToSearchIn;
        }

        public SubMenuNode(string nameIn, Entity.Sys.Enums.TableNames tableToSearchIn, int LevelNumberIn)
        {
            LevelNumber = LevelNumberIn;
            MyName = nameIn;
            TableToSearch = tableToSearchIn;
        }

        public SubMenuNode(string nameIn, string formToOpenIn)
        {
            LevelNumber = 1;
            MyName = nameIn;
            FormToOpen = formToOpenIn;
        }

        public SubMenuNode(string nameIn, string formToOpenIn, int LevelNumberIn)
        {
            LevelNumber = LevelNumberIn;
            MyName = nameIn;
            FormToOpen = formToOpenIn;
        }

        private int _LevelNumber = 1;

        public int LevelNumber
        {
            get
            {
                return _LevelNumber;
            }

            set
            {
                _LevelNumber = value;
            }
        }

        private string _MyName = "";

        public string MyName
        {
            get
            {
                return _MyName;
            }

            set
            {
                _MyName = value;
                Text = MyName;
                if (LevelNumber == 1)
                {
                    Location = new Point(5, App.MainForm.MenuBar.pnlSubMenu.Controls.Count * 20);
                    Size = new Size(152, 15);
                }
                else
                {
                    Location = new Point(10 * LevelNumber, App.MainForm.MenuBar.pnlSubMenu.Controls.Count * 20);
                    Size = new Size(152 - 10 * LevelNumber, 15);
                }

                LinkColor = Color.FromArgb(0, 52, 102);
                ActiveLinkColor = Color.FromArgb(0, 52, 102);
                DisabledLinkColor = Color.FromArgb(0, 52, 102);
                VisitedLinkColor = Color.FromArgb(0, 52, 102);
                Click += ButtonClicked;
            }
        }

        private Array _ChildNodes = null;

        public Array ChildNodes
        {
            get
            {
                return _ChildNodes;
            }

            set
            {
                _ChildNodes = value;
                foreach (SubMenuNode childNode in ChildNodes)
                    App.MainForm.MenuBar.pnlSubMenu.Controls.Add(childNode);
            }
        }

        private string _FormToOpen = "UsePanels";

        public string FormToOpen
        {
            get
            {
                return _FormToOpen;
            }

            set
            {
                _FormToOpen = value;
            }
        }

        private Entity.Sys.Enums.TableNames _TableToSearch = Entity.Sys.Enums.TableNames.NO_TABLE;

        public Entity.Sys.Enums.TableNames TableToSearch
        {
            get
            {
                return _TableToSearch;
            }

            set
            {
                _TableToSearch = value;
            }
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Navigation.Sub_Menu(this);
        }
    }
}