// Decompiled with JetBrains decompiler
// Type: FSM.DLGVisitAdditionalWorkSheet
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisitAdditionals;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DLGVisitAdditionalWorkSheet : FRMBaseForm
  {
    private IContainer components;
    private bool _updating;
    private EngineerVisitAdditional _Worksheet;
    private EngineerVisit _EngineerVisit;
    private FSM.Entity.Sites.Site _TheSite;
    private int _jobID;

    public DLGVisitAdditionalWorkSheet()
    {
      this.Load += new EventHandler(this.DLGVisitAssetWorkSheet_Load);
      this._updating = true;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel1 = this._btnCancel;
        if (btnCancel1 != null)
          btnCancel1.Click -= eventHandler;
        this._btnCancel = value;
        Button btnCancel2 = this._btnCancel;
        if (btnCancel2 == null)
          return;
        btnCancel2.Click += eventHandler;
      }
    }

    internal virtual Label lblcbo1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cbo20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcbo20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType
    {
      get
      {
        return this._cboType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboType_SelectedIndexChanged);
        ComboBox cboType1 = this._cboType;
        if (cboType1 != null)
          cboType1.SelectedIndexChanged -= eventHandler;
        this._cboType = value;
        ComboBox cboType2 = this._cboType;
        if (cboType2 == null)
          return;
        cboType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltxt12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txt12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnCancel = new Button();
      this.btnSave = new Button();
      this.lblcbo1 = new Label();
      this.lbltxt1 = new Label();
      this.txt1 = new TextBox();
      this.cbo1 = new ComboBox();
      this.lbltxt2 = new Label();
      this.txt2 = new TextBox();
      this.cbo2 = new ComboBox();
      this.lblcbo2 = new Label();
      this.cbo3 = new ComboBox();
      this.lblcbo3 = new Label();
      this.cbo4 = new ComboBox();
      this.lblcbo4 = new Label();
      this.cbo5 = new ComboBox();
      this.lblcbo5 = new Label();
      this.cbo6 = new ComboBox();
      this.lblcbo6 = new Label();
      this.cbo7 = new ComboBox();
      this.lblcbo7 = new Label();
      this.cbo8 = new ComboBox();
      this.lblcbo8 = new Label();
      this.cbo9 = new ComboBox();
      this.lblcbo9 = new Label();
      this.cbo10 = new ComboBox();
      this.lblcbo10 = new Label();
      this.cbo11 = new ComboBox();
      this.lblcbo11 = new Label();
      this.cbo12 = new ComboBox();
      this.lblcbo12 = new Label();
      this.cbo13 = new ComboBox();
      this.lblcbo13 = new Label();
      this.cbo14 = new ComboBox();
      this.lblcbo14 = new Label();
      this.cbo15 = new ComboBox();
      this.lblcbo15 = new Label();
      this.cbo16 = new ComboBox();
      this.lblcbo16 = new Label();
      this.cbo17 = new ComboBox();
      this.lblcbo17 = new Label();
      this.cbo18 = new ComboBox();
      this.lblcbo18 = new Label();
      this.lbltxt3 = new Label();
      this.txt3 = new TextBox();
      this.lbltxt4 = new Label();
      this.txt4 = new TextBox();
      this.lbltxt5 = new Label();
      this.txt5 = new TextBox();
      this.lbltxt6 = new Label();
      this.txt6 = new TextBox();
      this.lbltxt7 = new Label();
      this.txt7 = new TextBox();
      this.lbltxt8 = new Label();
      this.txt8 = new TextBox();
      this.lbltxt9 = new Label();
      this.txt9 = new TextBox();
      this.lbltxt10 = new Label();
      this.txt10 = new TextBox();
      this.cbo19 = new ComboBox();
      this.lblcbo19 = new Label();
      this.cbo20 = new ComboBox();
      this.lblcbo20 = new Label();
      this.cboType = new ComboBox();
      this.Label1 = new Label();
      this.lbltxt11 = new Label();
      this.txt11 = new TextBox();
      this.lbltxt12 = new Label();
      this.txt12 = new TextBox();
      this.SuspendLayout();
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(12, 526);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 38;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(902, 526);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 39;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.lblcbo1.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo1.Location = new System.Drawing.Point(8, 82);
      this.lblcbo1.Name = "lblcbo1";
      this.lblcbo1.Size = new Size(285, 23);
      this.lblcbo1.TabIndex = 22;
      this.lblcbo1.Text = "Heat Input KW/h";
      this.lbltxt1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt1.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt1.Location = new System.Drawing.Point(508, 81);
      this.lbltxt1.Name = "lbltxt1";
      this.lbltxt1.Size = new Size(272, 23);
      this.lbltxt1.TabIndex = 48;
      this.lbltxt1.Text = "Fuel";
      this.txt1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt1.Location = new System.Drawing.Point(786, 78);
      this.txt1.Name = "txt1";
      this.txt1.Size = new Size(178, 21);
      this.txt1.TabIndex = 23;
      this.cbo1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo1.Location = new System.Drawing.Point(310, 79);
      this.cbo1.Name = "cbo1";
      this.cbo1.Size = new Size(178, 21);
      this.cbo1.TabIndex = 47;
      this.lbltxt2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt2.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt2.Location = new System.Drawing.Point(508, 108);
      this.lbltxt2.Name = "lbltxt2";
      this.lbltxt2.Size = new Size(272, 23);
      this.lbltxt2.TabIndex = 50;
      this.lbltxt2.Text = "Fuel";
      this.txt2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt2.Location = new System.Drawing.Point(786, 105);
      this.txt2.Name = "txt2";
      this.txt2.Size = new Size(178, 21);
      this.txt2.TabIndex = 49;
      this.cbo2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo2.Location = new System.Drawing.Point(310, 106);
      this.cbo2.Name = "cbo2";
      this.cbo2.Size = new Size(178, 21);
      this.cbo2.TabIndex = 52;
      this.lblcbo2.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo2.Location = new System.Drawing.Point(8, 109);
      this.lblcbo2.Name = "lblcbo2";
      this.lblcbo2.Size = new Size(285, 23);
      this.lblcbo2.TabIndex = 51;
      this.lblcbo2.Text = "Heat Input KW/h";
      this.cbo3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo3.Location = new System.Drawing.Point(310, 133);
      this.cbo3.Name = "cbo3";
      this.cbo3.Size = new Size(178, 21);
      this.cbo3.TabIndex = 54;
      this.lblcbo3.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo3.Location = new System.Drawing.Point(8, 136);
      this.lblcbo3.Name = "lblcbo3";
      this.lblcbo3.Size = new Size(285, 23);
      this.lblcbo3.TabIndex = 53;
      this.lblcbo3.Text = "Heat Input KW/h";
      this.cbo4.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo4.Location = new System.Drawing.Point(310, 160);
      this.cbo4.Name = "cbo4";
      this.cbo4.Size = new Size(178, 21);
      this.cbo4.TabIndex = 56;
      this.lblcbo4.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo4.Location = new System.Drawing.Point(8, 163);
      this.lblcbo4.Name = "lblcbo4";
      this.lblcbo4.Size = new Size(285, 23);
      this.lblcbo4.TabIndex = 55;
      this.lblcbo4.Text = "Heat Input KW/h";
      this.cbo5.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo5.Location = new System.Drawing.Point(310, 187);
      this.cbo5.Name = "cbo5";
      this.cbo5.Size = new Size(178, 21);
      this.cbo5.TabIndex = 58;
      this.lblcbo5.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo5.Location = new System.Drawing.Point(8, 190);
      this.lblcbo5.Name = "lblcbo5";
      this.lblcbo5.Size = new Size(285, 23);
      this.lblcbo5.TabIndex = 57;
      this.lblcbo5.Text = "Heat Input KW/h";
      this.cbo6.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo6.Location = new System.Drawing.Point(310, 214);
      this.cbo6.Name = "cbo6";
      this.cbo6.Size = new Size(178, 21);
      this.cbo6.TabIndex = 60;
      this.lblcbo6.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo6.Location = new System.Drawing.Point(8, 217);
      this.lblcbo6.Name = "lblcbo6";
      this.lblcbo6.Size = new Size(285, 23);
      this.lblcbo6.TabIndex = 59;
      this.lblcbo6.Text = "Heat Input KW/h";
      this.cbo7.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo7.Location = new System.Drawing.Point(310, 241);
      this.cbo7.Name = "cbo7";
      this.cbo7.Size = new Size(178, 21);
      this.cbo7.TabIndex = 62;
      this.lblcbo7.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo7.Location = new System.Drawing.Point(8, 244);
      this.lblcbo7.Name = "lblcbo7";
      this.lblcbo7.Size = new Size(285, 23);
      this.lblcbo7.TabIndex = 61;
      this.lblcbo7.Text = "Heat Input KW/h";
      this.cbo8.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo8.Location = new System.Drawing.Point(310, 268);
      this.cbo8.Name = "cbo8";
      this.cbo8.Size = new Size(178, 21);
      this.cbo8.TabIndex = 64;
      this.lblcbo8.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo8.Location = new System.Drawing.Point(8, 271);
      this.lblcbo8.Name = "lblcbo8";
      this.lblcbo8.Size = new Size(285, 23);
      this.lblcbo8.TabIndex = 63;
      this.lblcbo8.Text = "Heat Input KW/h";
      this.cbo9.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo9.Location = new System.Drawing.Point(310, 295);
      this.cbo9.Name = "cbo9";
      this.cbo9.Size = new Size(178, 21);
      this.cbo9.TabIndex = 66;
      this.lblcbo9.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo9.Location = new System.Drawing.Point(8, 298);
      this.lblcbo9.Name = "lblcbo9";
      this.lblcbo9.Size = new Size(285, 23);
      this.lblcbo9.TabIndex = 65;
      this.lblcbo9.Text = "Heat Input KW/h";
      this.cbo10.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo10.Location = new System.Drawing.Point(310, 322);
      this.cbo10.Name = "cbo10";
      this.cbo10.Size = new Size(178, 21);
      this.cbo10.TabIndex = 68;
      this.lblcbo10.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo10.Location = new System.Drawing.Point(8, 325);
      this.lblcbo10.Name = "lblcbo10";
      this.lblcbo10.Size = new Size(285, 23);
      this.lblcbo10.TabIndex = 67;
      this.lblcbo10.Text = "Heat Input KW/h";
      this.cbo11.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo11.Location = new System.Drawing.Point(310, 349);
      this.cbo11.Name = "cbo11";
      this.cbo11.Size = new Size(178, 21);
      this.cbo11.TabIndex = 70;
      this.lblcbo11.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo11.Location = new System.Drawing.Point(8, 352);
      this.lblcbo11.Name = "lblcbo11";
      this.lblcbo11.Size = new Size(285, 23);
      this.lblcbo11.TabIndex = 69;
      this.lblcbo11.Text = "Heat Input KW/h";
      this.cbo12.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo12.Location = new System.Drawing.Point(310, 376);
      this.cbo12.Name = "cbo12";
      this.cbo12.Size = new Size(178, 21);
      this.cbo12.TabIndex = 72;
      this.lblcbo12.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo12.Location = new System.Drawing.Point(8, 379);
      this.lblcbo12.Name = "lblcbo12";
      this.lblcbo12.Size = new Size(285, 23);
      this.lblcbo12.TabIndex = 71;
      this.lblcbo12.Text = "Heat Input KW/h";
      this.cbo13.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo13.Location = new System.Drawing.Point(310, 403);
      this.cbo13.Name = "cbo13";
      this.cbo13.Size = new Size(178, 21);
      this.cbo13.TabIndex = 74;
      this.lblcbo13.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo13.Location = new System.Drawing.Point(8, 406);
      this.lblcbo13.Name = "lblcbo13";
      this.lblcbo13.Size = new Size(285, 23);
      this.lblcbo13.TabIndex = 73;
      this.lblcbo13.Text = "Heat Input KW/h";
      this.cbo14.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo14.Location = new System.Drawing.Point(310, 430);
      this.cbo14.Name = "cbo14";
      this.cbo14.Size = new Size(178, 21);
      this.cbo14.TabIndex = 76;
      this.lblcbo14.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo14.Location = new System.Drawing.Point(8, 433);
      this.lblcbo14.Name = "lblcbo14";
      this.lblcbo14.Size = new Size(285, 23);
      this.lblcbo14.TabIndex = 75;
      this.lblcbo14.Text = "Heat Input KW/h";
      this.cbo15.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo15.Location = new System.Drawing.Point(310, 460);
      this.cbo15.Name = "cbo15";
      this.cbo15.Size = new Size(178, 21);
      this.cbo15.TabIndex = 78;
      this.lblcbo15.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo15.Location = new System.Drawing.Point(8, 463);
      this.lblcbo15.Name = "lblcbo15";
      this.lblcbo15.Size = new Size(285, 23);
      this.lblcbo15.TabIndex = 77;
      this.lblcbo15.Text = "Heat Input KW/h";
      this.cbo16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbo16.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo16.Location = new System.Drawing.Point(310, 487);
      this.cbo16.Name = "cbo16";
      this.cbo16.Size = new Size(178, 21);
      this.cbo16.TabIndex = 80;
      this.lblcbo16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblcbo16.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo16.Location = new System.Drawing.Point(8, 491);
      this.lblcbo16.Name = "lblcbo16";
      this.lblcbo16.Size = new Size(272, 23);
      this.lblcbo16.TabIndex = 79;
      this.lblcbo16.Text = "Heat Input KW/h";
      this.cbo17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbo17.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo17.Location = new System.Drawing.Point(786, 402);
      this.cbo17.Name = "cbo17";
      this.cbo17.Size = new Size(178, 21);
      this.cbo17.TabIndex = 82;
      this.lblcbo17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblcbo17.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo17.Location = new System.Drawing.Point(508, 406);
      this.lblcbo17.Name = "lblcbo17";
      this.lblcbo17.Size = new Size(272, 23);
      this.lblcbo17.TabIndex = 81;
      this.lblcbo17.Text = "Heat Input KW/h";
      this.cbo18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbo18.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo18.Location = new System.Drawing.Point(786, 429);
      this.cbo18.Name = "cbo18";
      this.cbo18.Size = new Size(178, 21);
      this.cbo18.TabIndex = 84;
      this.lblcbo18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblcbo18.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo18.Location = new System.Drawing.Point(508, 433);
      this.lblcbo18.Name = "lblcbo18";
      this.lblcbo18.Size = new Size(272, 23);
      this.lblcbo18.TabIndex = 83;
      this.lblcbo18.Text = "Heat Input KW/h";
      this.lbltxt3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt3.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt3.Location = new System.Drawing.Point(508, 135);
      this.lbltxt3.Name = "lbltxt3";
      this.lbltxt3.Size = new Size(272, 23);
      this.lbltxt3.TabIndex = 86;
      this.lbltxt3.Text = "Fuel";
      this.txt3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt3.Location = new System.Drawing.Point(786, 132);
      this.txt3.Name = "txt3";
      this.txt3.Size = new Size(178, 21);
      this.txt3.TabIndex = 85;
      this.lbltxt4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt4.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt4.Location = new System.Drawing.Point(508, 162);
      this.lbltxt4.Name = "lbltxt4";
      this.lbltxt4.Size = new Size(272, 23);
      this.lbltxt4.TabIndex = 88;
      this.lbltxt4.Text = "Fuel";
      this.txt4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt4.Location = new System.Drawing.Point(786, 159);
      this.txt4.Name = "txt4";
      this.txt4.Size = new Size(178, 21);
      this.txt4.TabIndex = 87;
      this.lbltxt5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt5.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt5.Location = new System.Drawing.Point(508, 189);
      this.lbltxt5.Name = "lbltxt5";
      this.lbltxt5.Size = new Size(272, 23);
      this.lbltxt5.TabIndex = 90;
      this.lbltxt5.Text = "Fuel";
      this.txt5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt5.Location = new System.Drawing.Point(786, 186);
      this.txt5.Name = "txt5";
      this.txt5.Size = new Size(178, 21);
      this.txt5.TabIndex = 89;
      this.lbltxt6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt6.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt6.Location = new System.Drawing.Point(508, 216);
      this.lbltxt6.Name = "lbltxt6";
      this.lbltxt6.Size = new Size(272, 23);
      this.lbltxt6.TabIndex = 92;
      this.lbltxt6.Text = "Fuel";
      this.txt6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt6.Location = new System.Drawing.Point(786, 213);
      this.txt6.Name = "txt6";
      this.txt6.Size = new Size(178, 21);
      this.txt6.TabIndex = 91;
      this.lbltxt7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt7.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt7.Location = new System.Drawing.Point(508, 243);
      this.lbltxt7.Name = "lbltxt7";
      this.lbltxt7.Size = new Size(272, 23);
      this.lbltxt7.TabIndex = 94;
      this.lbltxt7.Text = "Fuel";
      this.txt7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt7.Location = new System.Drawing.Point(786, 240);
      this.txt7.Name = "txt7";
      this.txt7.Size = new Size(178, 21);
      this.txt7.TabIndex = 93;
      this.lbltxt8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt8.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt8.Location = new System.Drawing.Point(508, 270);
      this.lbltxt8.Name = "lbltxt8";
      this.lbltxt8.Size = new Size(272, 23);
      this.lbltxt8.TabIndex = 96;
      this.lbltxt8.Text = "Fuel";
      this.txt8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt8.Location = new System.Drawing.Point(786, 267);
      this.txt8.Name = "txt8";
      this.txt8.Size = new Size(178, 21);
      this.txt8.TabIndex = 95;
      this.lbltxt9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt9.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt9.Location = new System.Drawing.Point(508, 297);
      this.lbltxt9.Name = "lbltxt9";
      this.lbltxt9.Size = new Size(272, 23);
      this.lbltxt9.TabIndex = 98;
      this.lbltxt9.Text = "Fuel";
      this.txt9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt9.Location = new System.Drawing.Point(786, 294);
      this.txt9.Name = "txt9";
      this.txt9.Size = new Size(178, 21);
      this.txt9.TabIndex = 97;
      this.lbltxt10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt10.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt10.Location = new System.Drawing.Point(508, 324);
      this.lbltxt10.Name = "lbltxt10";
      this.lbltxt10.Size = new Size(272, 23);
      this.lbltxt10.TabIndex = 100;
      this.lbltxt10.Text = "Fuel";
      this.txt10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt10.Location = new System.Drawing.Point(786, 321);
      this.txt10.Name = "txt10";
      this.txt10.Size = new Size(178, 21);
      this.txt10.TabIndex = 99;
      this.cbo19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbo19.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo19.Location = new System.Drawing.Point(786, 456);
      this.cbo19.Name = "cbo19";
      this.cbo19.Size = new Size(178, 21);
      this.cbo19.TabIndex = 102;
      this.lblcbo19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblcbo19.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo19.Location = new System.Drawing.Point(508, 459);
      this.lblcbo19.Name = "lblcbo19";
      this.lblcbo19.Size = new Size(272, 23);
      this.lblcbo19.TabIndex = 101;
      this.lblcbo19.Text = "Heat Input KW/h";
      this.cbo20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cbo20.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbo20.Location = new System.Drawing.Point(786, 483);
      this.cbo20.Name = "cbo20";
      this.cbo20.Size = new Size(178, 21);
      this.cbo20.TabIndex = 104;
      this.lblcbo20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblcbo20.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblcbo20.Location = new System.Drawing.Point(508, 486);
      this.lblcbo20.Name = "lblcbo20";
      this.lblcbo20.Size = new Size(272, 23);
      this.lblcbo20.TabIndex = 103;
      this.lblcbo20.Text = "Heat Input KW/h";
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(310, 38);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(654, 21);
      this.cboType.TabIndex = 106;
      this.Label1.Location = new System.Drawing.Point(7, 41);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(136, 23);
      this.Label1.TabIndex = 105;
      this.Label1.Text = "Worsheet type";
      this.lbltxt11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt11.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt11.Location = new System.Drawing.Point(508, 352);
      this.lbltxt11.Name = "lbltxt11";
      this.lbltxt11.Size = new Size(272, 23);
      this.lbltxt11.TabIndex = 109;
      this.lbltxt11.Text = "Fuel";
      this.txt11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt11.Location = new System.Drawing.Point(786, 349);
      this.txt11.Name = "txt11";
      this.txt11.Size = new Size(178, 21);
      this.txt11.TabIndex = 108;
      this.lbltxt12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbltxt12.Font = new Font("Verdana", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbltxt12.Location = new System.Drawing.Point(508, 379);
      this.lbltxt12.Name = "lbltxt12";
      this.lbltxt12.Size = new Size(272, 23);
      this.lbltxt12.TabIndex = 111;
      this.lbltxt12.Text = "Fuel";
      this.txt12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txt12.Location = new System.Drawing.Point(786, 376);
      this.txt12.Name = "txt12";
      this.txt12.Size = new Size(178, 21);
      this.txt12.TabIndex = 110;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(989, 561);
      this.ControlBox = false;
      this.Controls.Add((Control) this.lbltxt12);
      this.Controls.Add((Control) this.txt12);
      this.Controls.Add((Control) this.lbltxt11);
      this.Controls.Add((Control) this.txt11);
      this.Controls.Add((Control) this.cboType);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.cbo20);
      this.Controls.Add((Control) this.lblcbo20);
      this.Controls.Add((Control) this.cbo19);
      this.Controls.Add((Control) this.lblcbo19);
      this.Controls.Add((Control) this.lbltxt10);
      this.Controls.Add((Control) this.txt10);
      this.Controls.Add((Control) this.lbltxt9);
      this.Controls.Add((Control) this.txt9);
      this.Controls.Add((Control) this.lbltxt8);
      this.Controls.Add((Control) this.txt8);
      this.Controls.Add((Control) this.lbltxt7);
      this.Controls.Add((Control) this.txt7);
      this.Controls.Add((Control) this.lbltxt6);
      this.Controls.Add((Control) this.txt6);
      this.Controls.Add((Control) this.lbltxt5);
      this.Controls.Add((Control) this.txt5);
      this.Controls.Add((Control) this.lbltxt4);
      this.Controls.Add((Control) this.txt4);
      this.Controls.Add((Control) this.lbltxt3);
      this.Controls.Add((Control) this.txt3);
      this.Controls.Add((Control) this.cbo18);
      this.Controls.Add((Control) this.lblcbo18);
      this.Controls.Add((Control) this.cbo17);
      this.Controls.Add((Control) this.lblcbo17);
      this.Controls.Add((Control) this.cbo16);
      this.Controls.Add((Control) this.lblcbo16);
      this.Controls.Add((Control) this.cbo15);
      this.Controls.Add((Control) this.lblcbo15);
      this.Controls.Add((Control) this.cbo14);
      this.Controls.Add((Control) this.lblcbo14);
      this.Controls.Add((Control) this.cbo13);
      this.Controls.Add((Control) this.lblcbo13);
      this.Controls.Add((Control) this.cbo12);
      this.Controls.Add((Control) this.lblcbo12);
      this.Controls.Add((Control) this.cbo11);
      this.Controls.Add((Control) this.lblcbo11);
      this.Controls.Add((Control) this.cbo10);
      this.Controls.Add((Control) this.lblcbo10);
      this.Controls.Add((Control) this.cbo9);
      this.Controls.Add((Control) this.lblcbo9);
      this.Controls.Add((Control) this.cbo8);
      this.Controls.Add((Control) this.lblcbo8);
      this.Controls.Add((Control) this.cbo7);
      this.Controls.Add((Control) this.lblcbo7);
      this.Controls.Add((Control) this.cbo6);
      this.Controls.Add((Control) this.lblcbo6);
      this.Controls.Add((Control) this.cbo5);
      this.Controls.Add((Control) this.lblcbo5);
      this.Controls.Add((Control) this.cbo4);
      this.Controls.Add((Control) this.lblcbo4);
      this.Controls.Add((Control) this.cbo3);
      this.Controls.Add((Control) this.lblcbo3);
      this.Controls.Add((Control) this.cbo2);
      this.Controls.Add((Control) this.lblcbo2);
      this.Controls.Add((Control) this.lbltxt2);
      this.Controls.Add((Control) this.txt2);
      this.Controls.Add((Control) this.lbltxt1);
      this.Controls.Add((Control) this.cbo1);
      this.Controls.Add((Control) this.txt1);
      this.Controls.Add((Control) this.lblcbo1);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnSave);
      this.MinimumSize = new Size(1000, 600);
      this.Name = nameof (DLGVisitAdditionalWorkSheet);
      this.Text = "Appliance Work Sheet";
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo1, 0);
      this.Controls.SetChildIndex((Control) this.txt1, 0);
      this.Controls.SetChildIndex((Control) this.cbo1, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt1, 0);
      this.Controls.SetChildIndex((Control) this.txt2, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt2, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo2, 0);
      this.Controls.SetChildIndex((Control) this.cbo2, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo3, 0);
      this.Controls.SetChildIndex((Control) this.cbo3, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo4, 0);
      this.Controls.SetChildIndex((Control) this.cbo4, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo5, 0);
      this.Controls.SetChildIndex((Control) this.cbo5, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo6, 0);
      this.Controls.SetChildIndex((Control) this.cbo6, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo7, 0);
      this.Controls.SetChildIndex((Control) this.cbo7, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo8, 0);
      this.Controls.SetChildIndex((Control) this.cbo8, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo9, 0);
      this.Controls.SetChildIndex((Control) this.cbo9, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo10, 0);
      this.Controls.SetChildIndex((Control) this.cbo10, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo11, 0);
      this.Controls.SetChildIndex((Control) this.cbo11, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo12, 0);
      this.Controls.SetChildIndex((Control) this.cbo12, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo13, 0);
      this.Controls.SetChildIndex((Control) this.cbo13, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo14, 0);
      this.Controls.SetChildIndex((Control) this.cbo14, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo15, 0);
      this.Controls.SetChildIndex((Control) this.cbo15, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo16, 0);
      this.Controls.SetChildIndex((Control) this.cbo16, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo17, 0);
      this.Controls.SetChildIndex((Control) this.cbo17, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo18, 0);
      this.Controls.SetChildIndex((Control) this.cbo18, 0);
      this.Controls.SetChildIndex((Control) this.txt3, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt3, 0);
      this.Controls.SetChildIndex((Control) this.txt4, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt4, 0);
      this.Controls.SetChildIndex((Control) this.txt5, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt5, 0);
      this.Controls.SetChildIndex((Control) this.txt6, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt6, 0);
      this.Controls.SetChildIndex((Control) this.txt7, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt7, 0);
      this.Controls.SetChildIndex((Control) this.txt8, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt8, 0);
      this.Controls.SetChildIndex((Control) this.txt9, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt9, 0);
      this.Controls.SetChildIndex((Control) this.txt10, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt10, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo19, 0);
      this.Controls.SetChildIndex((Control) this.cbo19, 0);
      this.Controls.SetChildIndex((Control) this.lblcbo20, 0);
      this.Controls.SetChildIndex((Control) this.cbo20, 0);
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.cboType, 0);
      this.Controls.SetChildIndex((Control) this.txt11, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt11, 0);
      this.Controls.SetChildIndex((Control) this.txt12, 0);
      this.Controls.SetChildIndex((Control) this.lbltxt12, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public bool Updating
    {
      get
      {
        return this._updating;
      }
      set
      {
        this._updating = value;
      }
    }

    public EngineerVisitAdditional Worksheet
    {
      get
      {
        return this._Worksheet;
      }
      set
      {
        this._Worksheet = value;
      }
    }

    public EngineerVisit EngineerVisit
    {
      get
      {
        return this._EngineerVisit;
      }
      set
      {
        this._EngineerVisit = value;
      }
    }

    public FSM.Entity.Sites.Site TheSite
    {
      get
      {
        return this._TheSite;
      }
      set
      {
        this._TheSite = value;
      }
    }

    public int JobID
    {
      get
      {
        return this._jobID;
      }
      set
      {
        this._jobID = value;
      }
    }

    private void DLGVisitAssetWorkSheet_Load(object sender, EventArgs e)
    {
      if (!App.loggedInUser.Admin)
      {
        this.btnSave.Enabled = false;
        this.cboType.Enabled = false;
        this.cbo1.Enabled = false;
        this.cbo2.Enabled = false;
        this.cbo3.Enabled = false;
        this.cbo4.Enabled = false;
        this.cbo5.Enabled = false;
        this.cbo6.Enabled = false;
        this.cbo7.Enabled = false;
        this.cbo8.Enabled = false;
        this.cbo9.Enabled = false;
        this.cbo10.Enabled = false;
        this.cbo11.Enabled = false;
        this.cbo12.Enabled = false;
        this.cbo13.Enabled = false;
        this.cbo14.Enabled = false;
        this.cbo15.Enabled = false;
        this.cbo16.Enabled = false;
        this.cbo17.Enabled = false;
        this.cbo18.Enabled = false;
        this.cbo19.Enabled = false;
        this.cbo20.Enabled = false;
        this.txt1.ReadOnly = true;
        this.txt2.ReadOnly = true;
        this.txt3.ReadOnly = true;
        this.txt4.ReadOnly = true;
        this.txt5.ReadOnly = true;
        this.txt6.ReadOnly = true;
        this.txt7.ReadOnly = true;
        this.txt8.ReadOnly = true;
        this.txt9.ReadOnly = true;
        this.txt10.ReadOnly = true;
      }
      ComboBox cboType1 = this.cboType;
      Combo.SetUpCombo(ref cboType1, App.DB.Picklists.GetAll(Enums.PickListTypes.TestType, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboType = cboType1;
      ComboBox cboType2 = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType2, Conversions.ToString(this.Worksheet.TestTypeID));
      this.cboType = cboType2;
      if (!(this.Worksheet.Exists & this.Updating))
        return;
      this.Loadin();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.Worksheet.SetTestTypeID = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.cboType.SelectedItem, new object[1]
        {
          (object) "value"
        }, (string[]) null));
        this.Worksheet.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
        this.Worksheet.SetTest1 = (object) Combo.get_GetSelectedItemValue(this.cbo1);
        this.Worksheet.SetTest2 = (object) Combo.get_GetSelectedItemValue(this.cbo2);
        this.Worksheet.SetTest3 = (object) Combo.get_GetSelectedItemValue(this.cbo3);
        this.Worksheet.SetTest4 = (object) Combo.get_GetSelectedItemValue(this.cbo4);
        this.Worksheet.SetTest5 = (object) Combo.get_GetSelectedItemValue(this.cbo5);
        this.Worksheet.SetTest6 = (object) Combo.get_GetSelectedItemValue(this.cbo6);
        this.Worksheet.SetTest7 = (object) Combo.get_GetSelectedItemValue(this.cbo7);
        this.Worksheet.SetTest8 = (object) Combo.get_GetSelectedItemValue(this.cbo8);
        this.Worksheet.SetTest9 = (object) Combo.get_GetSelectedItemValue(this.cbo9);
        this.Worksheet.SetTest10 = (object) Combo.get_GetSelectedItemValue(this.cbo10);
        this.Worksheet.SetTest111 = (object) Combo.get_GetSelectedItemValue(this.cbo11);
        this.Worksheet.SetTest112 = (object) Combo.get_GetSelectedItemValue(this.cbo12);
        this.Worksheet.SetTest113 = (object) Combo.get_GetSelectedItemValue(this.cbo13);
        this.Worksheet.SetTest114 = (object) Combo.get_GetSelectedItemValue(this.cbo14);
        this.Worksheet.SetTest115 = (object) Combo.get_GetSelectedItemValue(this.cbo15);
        this.Worksheet.SetTest116 = (object) Combo.get_GetSelectedItemValue(this.cbo16);
        this.Worksheet.SetTest117 = (object) Combo.get_GetSelectedItemValue(this.cbo17);
        this.Worksheet.SetTest118 = (object) Combo.get_GetSelectedItemValue(this.cbo18);
        this.Worksheet.SetTest119 = (object) Combo.get_GetSelectedItemValue(this.cbo19);
        this.Worksheet.SetTest120 = (object) Combo.get_GetSelectedItemValue(this.cbo20);
        this.Worksheet.SetTest11 = (object) this.txt1.Text;
        this.Worksheet.SetTest12 = (object) this.txt2.Text;
        this.Worksheet.SetTest13 = (object) this.txt3.Text;
        this.Worksheet.SetTest14 = (object) this.txt4.Text;
        this.Worksheet.SetTest15 = (object) this.txt5.Text;
        this.Worksheet.SetTest216 = (object) this.txt6.Text;
        this.Worksheet.SetTest217 = (object) this.txt7.Text;
        this.Worksheet.SetTest218 = (object) this.txt8.Text;
        this.Worksheet.SetTest219 = (object) this.txt9.Text;
        this.Worksheet.SetTest220 = (object) this.txt10.Text;
        this.Worksheet.SetTest221 = (object) this.txt11.Text;
        this.Worksheet.SetTest222 = (object) this.txt12.Text;
        if (this.Updating)
          App.DB.EngineerVisitAdditional.Update(this.Worksheet);
        else
          App.DB.EngineerVisitAdditional.Insert(this.Worksheet);
        this.DialogResult = DialogResult.OK;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error saving details : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void cboType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.setQuestions();
    }

    public void setQuestions()
    {
      try
      {
        switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)))
        {
          case 69108:
            this.comSafetyRec();
            break;
          case 69109:
            this.comStrength();
            break;
          case 69110:
            this.comPurge();
            break;
          case 69111:
            this.comTight();
            break;
          default:
            this.hideAll();
            break;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void Loadin()
    {
      ComboBox cboType = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(this.Worksheet.TestTypeID));
      this.cboType = cboType;
      this.setQuestions();
      ComboBox combo;
      if (this._Worksheet.Test1 > 0)
      {
        combo = this.cbo1;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test1.ToString());
        this.cbo1 = combo;
      }
      if (this._Worksheet.Test2 > 0)
      {
        combo = this.cbo2;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test2.ToString());
        this.cbo2 = combo;
      }
      if (this._Worksheet.Test3 > 0)
      {
        combo = this.cbo3;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test3.ToString());
        this.cbo3 = combo;
      }
      if (this._Worksheet.Test4 > 0)
      {
        combo = this.cbo4;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test4.ToString());
        this.cbo4 = combo;
      }
      if (this._Worksheet.Test5 > 0)
      {
        combo = this.cbo5;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test5.ToString());
        this.cbo5 = combo;
      }
      if (this._Worksheet.Test6 > 0)
      {
        combo = this.cbo6;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test6.ToString());
        this.cbo6 = combo;
      }
      if (this._Worksheet.Test7 > 0)
      {
        combo = this.cbo7;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test7.ToString());
        this.cbo7 = combo;
      }
      if (this._Worksheet.Test8 > 0)
      {
        combo = this.cbo8;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test8.ToString());
        this.cbo8 = combo;
      }
      if (this._Worksheet.Test9 > 0)
      {
        combo = this.cbo9;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test9.ToString());
        this.cbo9 = combo;
      }
      if (this._Worksheet.Test10 > 0)
      {
        combo = this.cbo10;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test10.ToString());
        this.cbo10 = combo;
      }
      if (this._Worksheet.Test111 > 0)
      {
        combo = this.cbo11;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test111.ToString());
        this.cbo11 = combo;
      }
      if (this._Worksheet.Test112 > 0)
      {
        combo = this.cbo12;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test112.ToString());
        this.cbo12 = combo;
      }
      if (this._Worksheet.Test113 > 0)
      {
        combo = this.cbo13;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test113.ToString());
        this.cbo13 = combo;
      }
      if (this._Worksheet.Test114 > 0)
      {
        combo = this.cbo14;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test114.ToString());
        this.cbo14 = combo;
      }
      if (this._Worksheet.Test115 > 0)
      {
        combo = this.cbo15;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test115.ToString());
        this.cbo15 = combo;
      }
      if (this._Worksheet.Test116 > 0)
      {
        combo = this.cbo16;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test116.ToString());
        this.cbo16 = combo;
      }
      if (this._Worksheet.Test117 > 0)
      {
        combo = this.cbo17;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test117.ToString());
        this.cbo17 = combo;
      }
      if (this._Worksheet.Test118 > 0)
      {
        combo = this.cbo18;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test118.ToString());
        this.cbo18 = combo;
      }
      this.txt1.Text = this._Worksheet.Test11;
      this.txt2.Text = this._Worksheet.Test12;
      this.txt3.Text = this._Worksheet.Test13;
      this.txt4.Text = this._Worksheet.Test14;
      this.txt5.Text = this._Worksheet.Test15;
      this.txt6.Text = this._Worksheet.Test216;
      this.txt7.Text = this._Worksheet.Test217;
      this.txt8.Text = this._Worksheet.Test218;
      this.txt9.Text = this._Worksheet.Test219;
      this.txt10.Text = this._Worksheet.Test220;
      this.txt11.Text = this._Worksheet.Test221;
      this.txt12.Text = this._Worksheet.Test222;
      if (this._Worksheet.Test119 > 0)
      {
        combo = this.cbo19;
        Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test119.ToString());
        this.cbo19 = combo;
      }
      if (this._Worksheet.Test120 <= 0)
        return;
      combo = this.cbo20;
      Combo.SetSelectedComboItem_By_Value(ref combo, this._Worksheet.Test120.ToString());
      this.cbo20 = combo;
    }

    public void hideAll()
    {
      this.cbo1.Visible = false;
      this.cbo2.Visible = false;
      this.cbo3.Visible = false;
      this.cbo4.Visible = false;
      this.cbo5.Visible = false;
      this.cbo6.Visible = false;
      this.cbo7.Visible = false;
      this.cbo8.Visible = false;
      this.cbo9.Visible = false;
      this.cbo10.Visible = false;
      this.cbo11.Visible = false;
      this.cbo12.Visible = false;
      this.cbo13.Visible = false;
      this.cbo14.Visible = false;
      this.cbo15.Visible = false;
      this.cbo16.Visible = false;
      this.cbo17.Visible = false;
      this.cbo18.Visible = false;
      this.cbo19.Visible = false;
      this.cbo20.Visible = false;
      this.lblcbo1.Visible = false;
      this.lblcbo2.Visible = false;
      this.lblcbo3.Visible = false;
      this.lblcbo4.Visible = false;
      this.lblcbo5.Visible = false;
      this.lblcbo6.Visible = false;
      this.lblcbo7.Visible = false;
      this.lblcbo8.Visible = false;
      this.lblcbo9.Visible = false;
      this.lblcbo10.Visible = false;
      this.lblcbo11.Visible = false;
      this.lblcbo12.Visible = false;
      this.lblcbo13.Visible = false;
      this.lblcbo14.Visible = false;
      this.lblcbo15.Visible = false;
      this.lblcbo16.Visible = false;
      this.lblcbo17.Visible = false;
      this.lblcbo18.Visible = false;
      this.lblcbo19.Visible = false;
      this.lblcbo20.Visible = false;
      this.txt1.Visible = false;
      this.txt2.Visible = false;
      this.txt3.Visible = false;
      this.txt4.Visible = false;
      this.txt5.Visible = false;
      this.txt6.Visible = false;
      this.txt7.Visible = false;
      this.txt8.Visible = false;
      this.txt9.Visible = false;
      this.txt10.Visible = false;
      this.txt11.Visible = false;
      this.txt12.Visible = false;
      this.lbltxt1.Visible = false;
      this.lbltxt2.Visible = false;
      this.lbltxt3.Visible = false;
      this.lbltxt4.Visible = false;
      this.lbltxt5.Visible = false;
      this.lbltxt6.Visible = false;
      this.lbltxt7.Visible = false;
      this.lbltxt8.Visible = false;
      this.lbltxt9.Visible = false;
      this.lbltxt10.Visible = false;
      this.lbltxt11.Visible = false;
      this.lbltxt12.Visible = false;
    }

    public void comSafetyRec()
    {
      this.cbo1.Visible = true;
      this.cbo2.Visible = true;
      this.cbo3.Visible = true;
      this.cbo4.Visible = true;
      this.cbo5.Visible = true;
      this.cbo6.Visible = true;
      this.cbo7.Visible = true;
      this.cbo8.Visible = true;
      this.cbo9.Visible = true;
      this.cbo10.Visible = true;
      this.cbo11.Visible = true;
      this.cbo12.Visible = true;
      this.cbo13.Visible = true;
      this.cbo14.Visible = true;
      this.cbo15.Visible = true;
      this.cbo16.Visible = true;
      this.cbo17.Visible = true;
      this.cbo18.Visible = true;
      this.cbo19.Visible = true;
      this.cbo20.Visible = false;
      this.lblcbo1.Visible = true;
      this.lblcbo2.Visible = true;
      this.lblcbo3.Visible = true;
      this.lblcbo4.Visible = true;
      this.lblcbo5.Visible = true;
      this.lblcbo6.Visible = true;
      this.lblcbo7.Visible = true;
      this.lblcbo8.Visible = true;
      this.lblcbo9.Visible = true;
      this.lblcbo10.Visible = true;
      this.lblcbo11.Visible = true;
      this.lblcbo12.Visible = true;
      this.lblcbo13.Visible = true;
      this.lblcbo14.Visible = true;
      this.lblcbo15.Visible = true;
      this.lblcbo16.Visible = true;
      this.lblcbo17.Visible = true;
      this.lblcbo18.Visible = true;
      this.lblcbo19.Visible = true;
      this.lblcbo20.Visible = false;
      this.txt1.Visible = false;
      this.txt2.Visible = false;
      this.txt3.Visible = false;
      this.txt4.Visible = false;
      this.txt5.Visible = false;
      this.txt6.Visible = false;
      this.txt7.Visible = false;
      this.txt8.Visible = false;
      this.txt9.Visible = false;
      this.txt10.Visible = false;
      this.txt11.Visible = false;
      this.txt12.Visible = false;
      this.lbltxt1.Visible = false;
      this.lbltxt2.Visible = false;
      this.lbltxt3.Visible = false;
      this.lbltxt4.Visible = false;
      this.lbltxt5.Visible = false;
      this.lbltxt6.Visible = false;
      this.lbltxt7.Visible = false;
      this.lbltxt8.Visible = false;
      this.lbltxt9.Visible = false;
      this.lbltxt10.Visible = false;
      this.lbltxt11.Visible = false;
      this.lbltxt12.Visible = false;
      this.lblcbo1.Text = "Is the meter installation accessible?";
      ComboBox cbo1 = this.cbo1;
      Combo.SetUpCombo(ref cbo1, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo1 = cbo1;
      this.lblcbo2.Text = "Is the meter adequately supported?";
      ComboBox cbo2 = this.cbo2;
      Combo.SetUpCombo(ref cbo2, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo2 = cbo2;
      this.lblcbo3.Text = "Is the ECV accessible?";
      ComboBox cbo3 = this.cbo3;
      Combo.SetUpCombo(ref cbo3, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo3 = cbo3;
      this.lblcbo4.Text = "Is the ECV fitted with a handle?";
      ComboBox cbo4 = this.cbo4;
      Combo.SetUpCombo(ref cbo4, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo4 = cbo4;
      this.lblcbo5.Text = "Is the ECV labeled with direction of operation?";
      ComboBox cbo5 = this.cbo5;
      Combo.SetUpCombo(ref cbo5, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo5 = cbo5;
      this.lblcbo6.Text = "Is the ECV complete with emergency notice?";
      ComboBox cbo6 = this.cbo6;
      Combo.SetUpCombo(ref cbo6, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo6 = cbo6;
      this.lblcbo7.Text = "Is the meter room/compartment/housing adequately Ventilated?";
      ComboBox cbo7 = this.cbo7;
      Combo.SetUpCombo(ref cbo7, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo7 = cbo7;
      this.lblcbo8.Text = "Is the meter room/compartment/housing clear of combustibles etc?";
      ComboBox cbo8 = this.cbo8;
      Combo.SetUpCombo(ref cbo8, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo8 = cbo8;
      this.lblcbo9.Text = "Is a gas installation line diagram fixed near to the primary meter?";
      ComboBox cbo9 = this.cbo9;
      Combo.SetUpCombo(ref cbo9, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo9 = cbo9;
      this.lblcbo10.Text = "Is the gas installation line diagram current/up-to-date?";
      ComboBox cbo10 = this.cbo10;
      Combo.SetUpCombo(ref cbo10, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo10 = cbo10;
      this.lblcbo11.Text = "Are emergency/isolation valves fitted?";
      ComboBox cbo11 = this.cbo11;
      Combo.SetUpCombo(ref cbo11, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo11 = cbo11;
      this.lblcbo12.Text = "Are emergency/isolation valve handles in place and suitably lablled?";
      ComboBox cbo12 = this.cbo12;
      Combo.SetUpCombo(ref cbo12, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo12 = cbo12;
      this.lblcbo13.Text = "Is the gas installation line diagram current/up-to-date?";
      ComboBox cbo13 = this.cbo13;
      Combo.SetUpCombo(ref cbo13, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo13 = cbo13;
      this.lblcbo14.Text = "Is the gas pipework adequately supported?";
      ComboBox cbo14 = this.cbo14;
      Combo.SetUpCombo(ref cbo14, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo14 = cbo14;
      this.lblcbo15.Text = "Is the gas pipework, where located in ducts, adequately ventilated?";
      ComboBox cbo15 = this.cbo15;
      Combo.SetUpCombo(ref cbo15, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo15 = cbo15;
      this.lblcbo16.Text = "Is the gas pipework colour coded/identified?";
      ComboBox cbo16 = this.cbo16;
      Combo.SetUpCombo(ref cbo16, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo16 = cbo16;
      this.lblcbo17.Text = "Is the gas installation electrically bonded?";
      ComboBox cbo17 = this.cbo17;
      Combo.SetUpCombo(ref cbo17, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo17 = cbo17;
      this.lblcbo18.Text = "Is the pipework suitably sleeved and sealed, as appropriate?";
      ComboBox cbo18 = this.cbo18;
      Combo.SetUpCombo(ref cbo18, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo18 = cbo18;
      this.lblcbo19.Text = "Has a gas strength/tightness test been carried out?";
      ComboBox cbo19 = this.cbo19;
      Combo.SetUpCombo(ref cbo19, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo19 = cbo19;
    }

    public void comStrength()
    {
      this.cbo1.Visible = true;
      this.cbo2.Visible = true;
      this.cbo3.Visible = true;
      this.cbo4.Visible = true;
      this.cbo5.Visible = false;
      this.cbo6.Visible = false;
      this.cbo7.Visible = false;
      this.cbo8.Visible = false;
      this.cbo9.Visible = false;
      this.cbo10.Visible = false;
      this.cbo11.Visible = false;
      this.cbo12.Visible = false;
      this.cbo13.Visible = false;
      this.cbo14.Visible = false;
      this.cbo15.Visible = false;
      this.cbo16.Visible = false;
      this.cbo17.Visible = false;
      this.cbo18.Visible = false;
      this.cbo19.Visible = false;
      this.cbo20.Visible = true;
      this.lblcbo1.Visible = true;
      this.lblcbo2.Visible = true;
      this.lblcbo3.Visible = true;
      this.lblcbo4.Visible = true;
      this.lblcbo5.Visible = false;
      this.lblcbo6.Visible = false;
      this.lblcbo7.Visible = false;
      this.lblcbo8.Visible = false;
      this.lblcbo9.Visible = false;
      this.lblcbo10.Visible = false;
      this.lblcbo11.Visible = false;
      this.lblcbo12.Visible = false;
      this.lblcbo13.Visible = false;
      this.lblcbo14.Visible = false;
      this.lblcbo15.Visible = false;
      this.lblcbo16.Visible = false;
      this.lblcbo17.Visible = false;
      this.lblcbo18.Visible = false;
      this.lblcbo19.Visible = false;
      this.lblcbo20.Visible = true;
      this.txt1.Visible = true;
      this.txt2.Visible = true;
      this.txt3.Visible = true;
      this.txt4.Visible = true;
      this.txt5.Visible = true;
      this.txt6.Visible = true;
      this.txt7.Visible = false;
      this.txt8.Visible = false;
      this.txt9.Visible = false;
      this.txt10.Visible = false;
      this.txt11.Visible = false;
      this.txt12.Visible = false;
      this.lbltxt1.Visible = true;
      this.lbltxt2.Visible = true;
      this.lbltxt3.Visible = true;
      this.lbltxt4.Visible = true;
      this.lbltxt5.Visible = true;
      this.lbltxt6.Visible = true;
      this.lbltxt7.Visible = false;
      this.lbltxt8.Visible = false;
      this.lbltxt9.Visible = false;
      this.lbltxt10.Visible = false;
      this.lbltxt11.Visible = false;
      this.lbltxt12.Visible = false;
      DataTable dataTable1 = new DataTable();
      dataTable1.Columns.Add("Name");
      dataTable1.Columns.Add("Value");
      DataRow row1 = dataTable1.NewRow();
      row1["Name"] = (object) "- Please Select -";
      row1["Value"] = (object) 0;
      dataTable1.Rows.Add(row1);
      DataRow row2 = dataTable1.NewRow();
      row2["Name"] = (object) "Pneumatic";
      row2["Value"] = (object) 1;
      dataTable1.Rows.Add(row2);
      DataRow row3 = dataTable1.NewRow();
      row3["Name"] = (object) "Hydrostatic";
      row3["Value"] = (object) 2;
      dataTable1.Rows.Add(row3);
      this.cbo1.Items.Clear();
      IEnumerator enumerator1;
      if (dataTable1 != null)
      {
        try
        {
          enumerator1 = dataTable1.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            this.cbo1.Items.Add((object) new Combo(Conversions.ToString(current["Name"]), Conversions.ToString(current["Value"]), (object) null));
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
      }
      this.cbo1.DisplayMember = "Description";
      this.cbo1.ValueMember = "Value";
      this.cbo1.SelectedIndex = 0;
      this.lblcbo1.Text = "State test method - ";
      DataTable dataTable2 = new DataTable();
      dataTable2.Columns.Add("Name");
      dataTable2.Columns.Add("Value");
      dataTable2.Rows.Add((object) "- Please Select -", (object) 0);
      dataTable2.Rows.Add((object) "New", (object) 1);
      dataTable2.Rows.Add((object) "New extension", (object) 2);
      dataTable2.Rows.Add((object) "Existing", (object) 3);
      this.cbo2.Items.Clear();
      IEnumerator enumerator2;
      if (dataTable2 != null)
      {
        try
        {
          enumerator2 = dataTable2.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            this.cbo2.Items.Add((object) new Combo(Conversions.ToString(current["Name"]), Conversions.ToString(current["Value"]), (object) null));
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      this.cbo2.DisplayMember = "Description";
      this.cbo2.ValueMember = "Value";
      this.cbo2.SelectedIndex = 0;
      this.lblcbo2.Text = "Installation - ";
      ComboBox c = this.cbo3;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo3 = c;
      this.lblcbo3.Text = "Have components not suitable for strength testing been removed or isolated from installation as necessary";
      this.lbltxt1.Text = "Calculated strength test pressure";
      DataTable dataTable3 = new DataTable();
      dataTable3.Columns.Add("Name");
      dataTable3.Columns.Add("Value");
      dataTable3.Rows.Add((object) "- Please Select -", (object) 0);
      dataTable3.Rows.Add((object) "Air", (object) 1);
      dataTable3.Rows.Add((object) "Nitrogen", (object) 2);
      dataTable3.Rows.Add((object) "Water", (object) 3);
      this.cbo4.Items.Clear();
      IEnumerator enumerator3;
      if (dataTable3 != null)
      {
        try
        {
          enumerator3 = dataTable3.Rows.GetEnumerator();
          while (enumerator3.MoveNext())
          {
            DataRow current = (DataRow) enumerator3.Current;
            this.cbo4.Items.Add((object) new Combo(Conversions.ToString(current["Name"]), Conversions.ToString(current["Value"]), (object) null));
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
        }
      }
      this.cbo4.DisplayMember = "Description";
      this.cbo4.ValueMember = "Value";
      this.cbo4.SelectedIndex = 0;
      this.lblcbo4.Text = "Test medium - air, nitrogen, water etc.";
      this.lbltxt2.Text = "Stabilisation Period (minutes)";
      this.lbltxt3.Text = "Strength Test Duration (STD) (minutes)";
      this.lbltxt4.Text = "Permitted pressure drop (% STP)";
      this.lbltxt5.Text = "Calculated pressure Drop";
      this.lbltxt6.Text = "Actual pressure Drop";
      c = this.cbo20;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.PassFail, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo20 = c;
      this.lblcbo20.Text = "Strength Test Pass or Fail";
    }

    public void comTight()
    {
      this.cbo1.Visible = true;
      this.cbo2.Visible = true;
      this.cbo3.Visible = true;
      this.cbo4.Visible = true;
      this.cbo5.Visible = false;
      this.cbo6.Visible = true;
      this.cbo7.Visible = true;
      this.cbo8.Visible = true;
      this.cbo9.Visible = true;
      this.cbo10.Visible = true;
      this.cbo11.Visible = false;
      this.cbo12.Visible = false;
      this.cbo13.Visible = false;
      this.cbo14.Visible = false;
      this.cbo15.Visible = false;
      this.cbo16.Visible = false;
      this.cbo17.Visible = false;
      this.cbo18.Visible = false;
      this.cbo19.Visible = true;
      this.cbo20.Visible = true;
      this.lblcbo1.Visible = true;
      this.lblcbo2.Visible = true;
      this.lblcbo3.Visible = true;
      this.lblcbo4.Visible = true;
      this.lblcbo5.Visible = false;
      this.lblcbo6.Visible = true;
      this.lblcbo7.Visible = true;
      this.lblcbo8.Visible = true;
      this.lblcbo9.Visible = true;
      this.lblcbo10.Visible = true;
      this.lblcbo11.Visible = false;
      this.lblcbo12.Visible = false;
      this.lblcbo13.Visible = false;
      this.lblcbo14.Visible = false;
      this.lblcbo15.Visible = false;
      this.lblcbo16.Visible = false;
      this.lblcbo17.Visible = false;
      this.lblcbo18.Visible = false;
      this.lblcbo19.Visible = true;
      this.lblcbo20.Visible = true;
      this.txt1.Visible = true;
      this.txt2.Visible = true;
      this.txt3.Visible = true;
      this.txt4.Visible = true;
      this.txt5.Visible = true;
      this.txt6.Visible = true;
      this.txt7.Visible = true;
      this.txt8.Visible = true;
      this.txt9.Visible = true;
      this.txt10.Visible = true;
      this.txt11.Visible = true;
      this.txt12.Visible = false;
      this.lbltxt1.Visible = true;
      this.lbltxt2.Visible = true;
      this.lbltxt3.Visible = true;
      this.lbltxt4.Visible = true;
      this.lbltxt5.Visible = true;
      this.lbltxt6.Visible = true;
      this.lbltxt7.Visible = true;
      this.lbltxt8.Visible = true;
      this.lbltxt9.Visible = true;
      this.lbltxt10.Visible = true;
      this.lbltxt11.Visible = true;
      this.lbltxt12.Visible = false;
      DataTable dataTable1 = new DataTable();
      dataTable1.Columns.Add("Name");
      dataTable1.Columns.Add("Value");
      dataTable1.Rows.Add((object) "- Please Select -", (object) 0);
      dataTable1.Rows.Add((object) "Natural Gas (NG)", (object) 1);
      dataTable1.Rows.Add((object) "Liquefied Petroleum Gas (LPG)", (object) 2);
      this.cbo1.Items.Clear();
      IEnumerator enumerator1;
      if (dataTable1 != null)
      {
        try
        {
          enumerator1 = dataTable1.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            this.cbo1.Items.Add((object) new Combo(Conversions.ToString(current["Name"]), Conversions.ToString(current["Value"]), (object) null));
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
      }
      this.cbo1.DisplayMember = "Description";
      this.cbo1.ValueMember = "Value";
      this.cbo1.SelectedIndex = 0;
      this.lblcbo1.Text = "Gas Type - ";
      DataTable dataTable2 = new DataTable();
      dataTable2.Columns.Add("Name");
      dataTable2.Columns.Add("Value");
      dataTable2.Rows.Add((object) "- Please Select -", (object) 0);
      dataTable2.Rows.Add((object) "New", (object) 1);
      dataTable2.Rows.Add((object) "New extension", (object) 2);
      dataTable2.Rows.Add((object) "Existing", (object) 3);
      this.cbo2.Items.Clear();
      IEnumerator enumerator2;
      if (dataTable2 != null)
      {
        try
        {
          enumerator2 = dataTable2.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            this.cbo2.Items.Add((object) new Combo(Conversions.ToString(current["Name"]), Conversions.ToString(current["Value"]), (object) null));
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
      }
      this.cbo2.DisplayMember = "Description";
      this.cbo2.ValueMember = "Value";
      this.cbo2.SelectedIndex = 0;
      this.lblcbo2.Text = "Installation - ";
      ComboBox c = this.cbo3;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo3 = c;
      this.lblcbo3.Text = "Could weather/changes in temperature affect test?";
      DataTable dataTable3 = new DataTable();
      dataTable3.Columns.Add("Name");
      dataTable3.Columns.Add("Value");
      dataTable3.Rows.Add((object) "- Please Select -", (object) 0);
      dataTable3.Rows.Add((object) "Diaphragm", (object) 1);
      dataTable3.Rows.Add((object) "Rotary", (object) 2);
      dataTable3.Rows.Add((object) "Turbine", (object) 3);
      this.cbo4.Items.Clear();
      IEnumerator enumerator3;
      if (dataTable3 != null)
      {
        try
        {
          enumerator3 = dataTable3.Rows.GetEnumerator();
          while (enumerator3.MoveNext())
          {
            DataRow current = (DataRow) enumerator3.Current;
            this.cbo4.Items.Add((object) new Combo(Conversions.ToString(current["Name"]), Conversions.ToString(current["Value"]), (object) null));
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
        }
      }
      this.cbo4.DisplayMember = "Description";
      this.cbo4.ValueMember = "Value";
      this.cbo4.SelectedIndex = 0;
      this.lblcbo4.Text = "Meter Type - ";
      DataTable dataTable4 = new DataTable()
      {
        Columns = {
          "Name",
          "Value"
        }
      };
      c = this.cbo6;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo6 = c;
      this.lblcbo6.Text = "Meter Bypass Installed and Sealed?";
      DataTable dataTable5 = new DataTable();
      dataTable5.Columns.Add("Name");
      dataTable5.Columns.Add("Value");
      dataTable5.Rows.Add((object) "- Please Select -", (object) 0);
      dataTable5.Rows.Add((object) "Fuel gas", (object) 1);
      dataTable5.Rows.Add((object) "Air", (object) 2);
      this.cbo7.Items.Clear();
      IEnumerator enumerator4;
      if (dataTable5 != null)
      {
        try
        {
          enumerator4 = dataTable5.Rows.GetEnumerator();
          while (enumerator4.MoveNext())
          {
            DataRow current = (DataRow) enumerator4.Current;
            this.cbo7.Items.Add((object) new Combo(Conversions.ToString(current["Name"]), Conversions.ToString(current["Value"]), (object) null));
          }
        }
        finally
        {
          if (enumerator4 is IDisposable)
            (enumerator4 as IDisposable).Dispose();
        }
      }
      this.cbo7.DisplayMember = "Description";
      this.cbo7.ValueMember = "Value";
      this.cbo7.SelectedIndex = 0;
      this.lblcbo7.Text = "Test Medium - ";
      DataTable dataTable6 = new DataTable();
      dataTable6.Columns.Add("Name");
      dataTable6.Columns.Add("Value");
      dataTable6.Rows.Add((object) "- Please Select -", (object) 0);
      dataTable6.Rows.Add((object) "Water", (object) 1);
      dataTable6.Rows.Add((object) "High SG", (object) 2);
      dataTable6.Rows.Add((object) "Electronic", (object) 2);
      this.cbo8.Items.Clear();
      IEnumerator enumerator5;
      if (dataTable6 != null)
      {
        try
        {
          enumerator5 = dataTable6.Rows.GetEnumerator();
          while (enumerator5.MoveNext())
          {
            DataRow current = (DataRow) enumerator5.Current;
            this.cbo8.Items.Add((object) new Combo(Conversions.ToString(current["Name"]), Conversions.ToString(current["Value"]), (object) null));
          }
        }
        finally
        {
          if (enumerator5 is IDisposable)
            (enumerator5 as IDisposable).Dispose();
        }
      }
      this.cbo8.DisplayMember = "Description";
      this.cbo8.ValueMember = "Value";
      this.cbo8.SelectedIndex = 0;
      this.lblcbo8.Text = "Pressure Gauge Type - ";
      c = this.cbo9;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo9 = c;
      this.lblcbo9.Text = "Any inadequately ventilated areas to check?";
      c = this.cbo10;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo10 = c;
      this.lblcbo10.Text = "Is barometric pressure correction necessary?";
      c = this.cbo19;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo19 = c;
      this.lblcbo19.Text = "Have inadequately ventilated areas been checked?";
      c = this.cbo20;
      Combo.SetUpCombo(ref c, App.DB.Picklists.GetAll(Enums.PickListTypes.PassFail, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo20 = c;
      this.lblcbo20.Text = "Tightness test Pass or Fail";
      this.lbltxt1.Text = "Installation Volume : Gas Meter (m3)";
      this.lbltxt2.Text = "Installation Volume : Installation pipework and fittings (m3)";
      this.lbltxt3.Text = "Installation Volume : Total IV (m3)";
      this.lbltxt4.Text = "Tightness test pressure (TTP) mbar";
      this.lbltxt5.Text = "MPLR m3/hr (IGE/UP/1) or MAPD mbar (IGE/UP/1A) ";
      this.lbltxt6.Text = "Let-by test period existing installations (minutes)";
      this.lbltxt7.Text = "Stabilisation period (minutes)";
      this.lbltxt8.Text = "Tightness test duration (TTD) (minutes)";
      this.lbltxt9.Text = "Actual pressure drop (if any) mbar";
      this.lbltxt10.Text = "Actual leak rate m3/hr";
      this.lbltxt11.Text = "Meter Designation (U16,U40,Etc.) - ";
    }

    public void comPurge()
    {
      this.cbo1.Visible = true;
      this.cbo2.Visible = true;
      this.cbo3.Visible = true;
      this.cbo4.Visible = true;
      this.cbo5.Visible = true;
      this.cbo6.Visible = true;
      this.cbo7.Visible = true;
      this.cbo8.Visible = true;
      this.cbo9.Visible = true;
      this.cbo10.Visible = true;
      this.cbo11.Visible = false;
      this.cbo12.Visible = false;
      this.cbo13.Visible = false;
      this.cbo14.Visible = false;
      this.cbo15.Visible = false;
      this.cbo16.Visible = false;
      this.cbo17.Visible = false;
      this.cbo18.Visible = false;
      this.cbo19.Visible = false;
      this.cbo20.Visible = true;
      this.lblcbo1.Visible = true;
      this.lblcbo2.Visible = true;
      this.lblcbo3.Visible = true;
      this.lblcbo4.Visible = true;
      this.lblcbo5.Visible = true;
      this.lblcbo6.Visible = true;
      this.lblcbo7.Visible = true;
      this.lblcbo8.Visible = true;
      this.lblcbo9.Visible = true;
      this.lblcbo10.Visible = true;
      this.lblcbo11.Visible = false;
      this.lblcbo12.Visible = false;
      this.lblcbo13.Visible = false;
      this.lblcbo14.Visible = false;
      this.lblcbo15.Visible = false;
      this.lblcbo16.Visible = false;
      this.lblcbo17.Visible = false;
      this.lblcbo18.Visible = false;
      this.lblcbo19.Visible = false;
      this.lblcbo20.Visible = true;
      this.txt1.Visible = true;
      this.txt2.Visible = true;
      this.txt3.Visible = true;
      this.txt4.Visible = true;
      this.txt5.Visible = false;
      this.txt6.Visible = false;
      this.txt7.Visible = false;
      this.txt8.Visible = false;
      this.txt9.Visible = false;
      this.txt10.Visible = false;
      this.txt11.Visible = false;
      this.txt12.Visible = false;
      this.lbltxt1.Visible = true;
      this.lbltxt2.Visible = true;
      this.lbltxt3.Visible = true;
      this.lbltxt4.Visible = true;
      this.lbltxt5.Visible = false;
      this.lbltxt6.Visible = false;
      this.lbltxt7.Visible = false;
      this.lbltxt8.Visible = false;
      this.lbltxt9.Visible = false;
      this.lbltxt10.Visible = false;
      this.lbltxt11.Visible = false;
      this.lbltxt12.Visible = false;
      ComboBox cbo1 = this.cbo1;
      Combo.SetUpCombo(ref cbo1, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo1 = cbo1;
      this.lblcbo1.Text = "Has a risk assessment been carried out?";
      ComboBox cbo2 = this.cbo2;
      Combo.SetUpCombo(ref cbo2, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo2 = cbo2;
      this.lblcbo2.Text = "Has a written procedure for the purge been prepared?";
      ComboBox cbo3 = this.cbo3;
      Combo.SetUpCombo(ref cbo3, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo3 = cbo3;
      this.lblcbo3.Text = "Have 'NO SMOKING' signs etc been displayed as necessary?";
      ComboBox cbo4 = this.cbo4;
      Combo.SetUpCombo(ref cbo4, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo4 = cbo4;
      this.lblcbo4.Text = "Have persons in the vicinity of the purge been advised accordingly?";
      ComboBox cbo5 = this.cbo5;
      Combo.SetUpCombo(ref cbo5, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo5 = cbo5;
      this.lblcbo5.Text = "Have all appropriate valves to and from the section of pipe been labelled?";
      ComboBox cbo6 = this.cbo6;
      Combo.SetUpCombo(ref cbo6, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo6 = cbo6;
      this.lblcbo6.Text = "Where nitrogen gas is being used for an indirect purge, have the gas cylinders been checked/verified for their correct content?";
      ComboBox cbo7 = this.cbo7;
      Combo.SetUpCombo(ref cbo7, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo7 = cbo7;
      this.lblcbo7.Text = "Are suitable extinguishers available in case of an incident?";
      ComboBox cbo8 = this.cbo8;
      Combo.SetUpCombo(ref cbo8, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo8 = cbo8;
      this.lblcbo8.Text = "Are two-way radios (intrinsically safe) available?";
      ComboBox cbo9 = this.cbo9;
      Combo.SetUpCombo(ref cbo9, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo9 = cbo9;
      this.lblcbo9.Text = "Are all electrical bonds fitted as necessary?";
      ComboBox cbo10 = this.cbo10;
      Combo.SetUpCombo(ref cbo10, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo10 = cbo10;
      this.lblcbo10.Text = "Is gas detector/oxygen measuring device, as appropriate, intrinsically safe?";
      ComboBox cbo20 = this.cbo20;
      Combo.SetUpCombo(ref cbo20, App.DB.Picklists.GetAll(Enums.PickListTypes.PassFail, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cbo20 = cbo20;
      this.lblcbo20.Text = "Purge Pass or Fail";
      this.lbltxt1.Text = "Calculate purge Volume : Gas meter (m3)";
      this.lbltxt2.Text = "Calculate purge Volume : Installation pipework and fittings (m3)";
      this.lbltxt3.Text = "Calculate purge Volume : Total purge volume (m3)";
      this.lbltxt4.Text = "Carry out purge noting final test criteria readings (O2% or LFL%)";
    }
  }
}
