// Decompiled with JetBrains decompiler
// Type: FSM.UCSideBar
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCSideBar : UCBase
  {
    private IContainer components;

    public UCSideBar()
    {
      this.InitializeComponent();
      this.btnCustomer.ButtonClicked += new UCMainButton.ButtonClickedEventHandler(this.MenuSelectionChanged);
      this.btnSpares.ButtonClicked += new UCMainButton.ButtonClickedEventHandler(this.MenuSelectionChanged);
      this.btnStaff.ButtonClicked += new UCMainButton.ButtonClickedEventHandler(this.MenuSelectionChanged);
      this.btnJobs.ButtonClicked += new UCMainButton.ButtonClickedEventHandler(this.MenuSelectionChanged);
      this.btnInvoicing.ButtonClicked += new UCMainButton.ButtonClickedEventHandler(this.MenuSelectionChanged);
      this.btnReports.ButtonClicked += new UCMainButton.ButtonClickedEventHandler(this.MenuSelectionChanged);
      this.btnVan.ButtonClicked += new UCMainButton.ButtonClickedEventHandler(this.MenuSelectionChanged);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Panel pnlButtons { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual UCMainButton btnVan { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual UCMainButton btnReports { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Splitter Splitter1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlMenu { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlHeader { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlSubMenu { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual UCMainButton btnCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual UCMainButton btnSpares { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual UCMainButton btnJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual UCMainButton btnInvoicing { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual UCMainButton btnStaff { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (UCSideBar));
      this.pnlButtons = new Panel();
      this.btnVan = new UCMainButton();
      this.btnReports = new UCMainButton();
      this.btnInvoicing = new UCMainButton();
      this.btnJobs = new UCMainButton();
      this.btnStaff = new UCMainButton();
      this.btnSpares = new UCMainButton();
      this.btnCustomer = new UCMainButton();
      this.Splitter1 = new Splitter();
      this.pnlSearch = new Panel();
      this.pnlMenu = new Panel();
      this.pnlSubMenu = new Panel();
      this.Label1 = new Label();
      this.pnlHeader = new Panel();
      this.Label2 = new Label();
      this.lblTitle = new Label();
      this.pnlButtons.SuspendLayout();
      this.pnlMenu.SuspendLayout();
      this.pnlHeader.SuspendLayout();
      this.SuspendLayout();
      this.pnlButtons.Controls.Add((Control) this.btnVan);
      this.pnlButtons.Controls.Add((Control) this.btnReports);
      this.pnlButtons.Controls.Add((Control) this.btnInvoicing);
      this.pnlButtons.Controls.Add((Control) this.btnJobs);
      this.pnlButtons.Controls.Add((Control) this.btnStaff);
      this.pnlButtons.Controls.Add((Control) this.btnSpares);
      this.pnlButtons.Controls.Add((Control) this.btnCustomer);
      this.pnlButtons.Dock = DockStyle.Bottom;
      this.pnlButtons.Location = new System.Drawing.Point(0, 430);
      this.pnlButtons.Name = "pnlButtons";
      this.pnlButtons.Size = new Size(160, 224);
      this.pnlButtons.TabIndex = 1;
      this.btnVan.AutoScroll = true;
      this.btnVan.BackColor = Color.White;
      this.btnVan.BackgroundImage = (Image) componentResourceManager.GetObject("btnVan.BackgroundImage");
      this.btnVan.Caption = "Fleet";
      this.btnVan.Dock = DockStyle.Top;
      this.btnVan.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnVan.FormButtons = (ArrayList) null;
      this.btnVan.IAmSelected = false;
      this.btnVan.Image = (Image) componentResourceManager.GetObject("btnVan.Image");
      this.btnVan.Location = new System.Drawing.Point(0, 192);
      this.btnVan.MenuType = Enums.MenuTypes.FleetVan;
      this.btnVan.Name = "btnVan";
      this.btnVan.Size = new Size(160, 32);
      this.btnVan.TabIndex = 8;
      this.btnReports.AutoScroll = true;
      this.btnReports.BackColor = Color.White;
      this.btnReports.BackgroundImage = (Image) componentResourceManager.GetObject("btnReports.BackgroundImage");
      this.btnReports.Caption = "Reports";
      this.btnReports.Dock = DockStyle.Top;
      this.btnReports.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnReports.FormButtons = (ArrayList) null;
      this.btnReports.IAmSelected = false;
      this.btnReports.Image = (Image) componentResourceManager.GetObject("btnReports.Image");
      this.btnReports.Location = new System.Drawing.Point(0, 160);
      this.btnReports.MenuType = Enums.MenuTypes.Reports;
      this.btnReports.Name = "btnReports";
      this.btnReports.Size = new Size(160, 32);
      this.btnReports.TabIndex = 7;
      this.btnInvoicing.AutoScroll = true;
      this.btnInvoicing.BackColor = Color.White;
      this.btnInvoicing.BackgroundImage = (Image) componentResourceManager.GetObject("btnInvoicing.BackgroundImage");
      this.btnInvoicing.Caption = "Invoicing";
      this.btnInvoicing.Dock = DockStyle.Top;
      this.btnInvoicing.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnInvoicing.FormButtons = (ArrayList) null;
      this.btnInvoicing.IAmSelected = false;
      this.btnInvoicing.Image = (Image) componentResourceManager.GetObject("btnInvoicing.Image");
      this.btnInvoicing.Location = new System.Drawing.Point(0, 128);
      this.btnInvoicing.MenuType = Enums.MenuTypes.Invoicing;
      this.btnInvoicing.Name = "btnInvoicing";
      this.btnInvoicing.Size = new Size(160, 32);
      this.btnInvoicing.TabIndex = 6;
      this.btnJobs.AutoScroll = true;
      this.btnJobs.BackColor = Color.White;
      this.btnJobs.BackgroundImage = (Image) componentResourceManager.GetObject("btnJobs.BackgroundImage");
      this.btnJobs.Caption = "Jobs";
      this.btnJobs.Dock = DockStyle.Top;
      this.btnJobs.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnJobs.FormButtons = (ArrayList) null;
      this.btnJobs.IAmSelected = false;
      this.btnJobs.Image = (Image) componentResourceManager.GetObject("btnJobs.Image");
      this.btnJobs.Location = new System.Drawing.Point(0, 96);
      this.btnJobs.MenuType = Enums.MenuTypes.Jobs;
      this.btnJobs.Name = "btnJobs";
      this.btnJobs.Size = new Size(160, 32);
      this.btnJobs.TabIndex = 5;
      this.btnStaff.AutoScroll = true;
      this.btnStaff.BackColor = Color.White;
      this.btnStaff.BackgroundImage = (Image) componentResourceManager.GetObject("btnStaff.BackgroundImage");
      this.btnStaff.Caption = "Staff";
      this.btnStaff.Dock = DockStyle.Top;
      this.btnStaff.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnStaff.FormButtons = (ArrayList) null;
      this.btnStaff.IAmSelected = false;
      this.btnStaff.Image = (Image) componentResourceManager.GetObject("btnStaff.Image");
      this.btnStaff.Location = new System.Drawing.Point(0, 64);
      this.btnStaff.MenuType = Enums.MenuTypes.Staff;
      this.btnStaff.Name = "btnStaff";
      this.btnStaff.Size = new Size(160, 32);
      this.btnStaff.TabIndex = 4;
      this.btnSpares.AutoScroll = true;
      this.btnSpares.BackColor = Color.White;
      this.btnSpares.BackgroundImage = (Image) componentResourceManager.GetObject("btnSpares.BackgroundImage");
      this.btnSpares.Caption = "Spares";
      this.btnSpares.Dock = DockStyle.Top;
      this.btnSpares.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnSpares.FormButtons = (ArrayList) null;
      this.btnSpares.IAmSelected = false;
      this.btnSpares.Image = (Image) componentResourceManager.GetObject("btnSpares.Image");
      this.btnSpares.Location = new System.Drawing.Point(0, 32);
      this.btnSpares.MenuType = Enums.MenuTypes.Spares;
      this.btnSpares.Name = "btnSpares";
      this.btnSpares.Size = new Size(160, 32);
      this.btnSpares.TabIndex = 3;
      this.btnCustomer.AutoScroll = true;
      this.btnCustomer.BackColor = Color.White;
      this.btnCustomer.BackgroundImage = (Image) componentResourceManager.GetObject("btnCustomer.BackgroundImage");
      this.btnCustomer.Caption = "Customers";
      this.btnCustomer.Dock = DockStyle.Top;
      this.btnCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnCustomer.FormButtons = (ArrayList) null;
      this.btnCustomer.IAmSelected = false;
      this.btnCustomer.Image = (Image) componentResourceManager.GetObject("btnCustomer.Image");
      this.btnCustomer.Location = new System.Drawing.Point(0, 0);
      this.btnCustomer.MenuType = Enums.MenuTypes.Customers;
      this.btnCustomer.Name = "btnCustomer";
      this.btnCustomer.Size = new Size(160, 32);
      this.btnCustomer.TabIndex = 0;
      this.Splitter1.BackColor = Color.Silver;
      this.Splitter1.Dock = DockStyle.Bottom;
      this.Splitter1.Enabled = false;
      this.Splitter1.Location = new System.Drawing.Point(0, 425);
      this.Splitter1.Name = "Splitter1";
      this.Splitter1.Size = new Size(160, 5);
      this.Splitter1.TabIndex = 2;
      this.Splitter1.TabStop = false;
      this.pnlSearch.Dock = DockStyle.Bottom;
      this.pnlSearch.Location = new System.Drawing.Point(0, 273);
      this.pnlSearch.Name = "pnlSearch";
      this.pnlSearch.Size = new Size(160, 152);
      this.pnlSearch.TabIndex = 3;
      this.pnlMenu.Controls.Add((Control) this.pnlSubMenu);
      this.pnlMenu.Controls.Add((Control) this.Label1);
      this.pnlMenu.Controls.Add((Control) this.pnlHeader);
      this.pnlMenu.Dock = DockStyle.Fill;
      this.pnlMenu.Location = new System.Drawing.Point(0, 0);
      this.pnlMenu.Name = "pnlMenu";
      this.pnlMenu.Size = new Size(160, 273);
      this.pnlMenu.TabIndex = 4;
      this.pnlSubMenu.AutoScroll = true;
      this.pnlSubMenu.Dock = DockStyle.Fill;
      this.pnlSubMenu.Location = new System.Drawing.Point(0, 50);
      this.pnlSubMenu.Name = "pnlSubMenu";
      this.pnlSubMenu.Size = new Size(160, 223);
      this.pnlSubMenu.TabIndex = 6;
      this.Label1.BackColor = Color.FromArgb(224, 224, 224);
      this.Label1.Dock = DockStyle.Top;
      this.Label1.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.DimGray;
      this.Label1.Location = new System.Drawing.Point(0, 34);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(160, 16);
      this.Label1.TabIndex = 5;
      this.Label1.Text = "Please select option";
      this.pnlHeader.BackColor = Color.FromArgb(224, 224, 224);
      this.pnlHeader.BackgroundImage = (Image) componentResourceManager.GetObject("pnlHeader.BackgroundImage");
      this.pnlHeader.Controls.Add((Control) this.Label2);
      this.pnlHeader.Controls.Add((Control) this.lblTitle);
      this.pnlHeader.Dock = DockStyle.Top;
      this.pnlHeader.Location = new System.Drawing.Point(0, 0);
      this.pnlHeader.Name = "pnlHeader";
      this.pnlHeader.Size = new Size(160, 34);
      this.pnlHeader.TabIndex = 4;
      this.Label2.BackColor = Color.Transparent;
      this.Label2.Font = new Font("Verdana", 11f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label2.ForeColor = Color.White;
      this.Label2.Location = new System.Drawing.Point(0, 0);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(32, 32);
      this.Label2.TabIndex = 29;
      this.Label2.Text = ">>";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      this.lblTitle.BackColor = Color.Transparent;
      this.lblTitle.Font = new Font("Verdana", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTitle.ForeColor = Color.White;
      this.lblTitle.Location = new System.Drawing.Point(32, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new Size(128, 32);
      this.lblTitle.TabIndex = 28;
      this.lblTitle.Text = "HOME";
      this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
      this.Controls.Add((Control) this.pnlMenu);
      this.Controls.Add((Control) this.pnlSearch);
      this.Controls.Add((Control) this.Splitter1);
      this.Controls.Add((Control) this.pnlButtons);
      this.Name = nameof (UCSideBar);
      this.Size = new Size(160, 654);
      this.pnlButtons.ResumeLayout(false);
      this.pnlMenu.ResumeLayout(false);
      this.pnlHeader.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void MenuSelectionChanged(Enums.MenuTypes MenuType)
    {
      Navigation.Navigate(MenuType);
    }
  }
}
