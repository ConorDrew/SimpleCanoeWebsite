﻿// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.SignatureBox
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
    public class SignatureBox
    {
        private int oldX;
        private int oldY;
        private Bitmap bmp;
        private int[] SigArrayXO;
        private int[] SigArrayYO;
        private string SigDataO;
        private int SigMovesO;
        private bool startedSig;
        private bool isMouseDown;
        private int pointNumber;
        private bool firstTime;
        private ArrayList pointsArray;
        private bool isReadOnlyVar;
        private Graphics gphDraw;
        private PictureBox _Signature;

        public virtual PictureBox Signature
        {
            get
            {
                return this._Signature;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.Signature_MouseDown);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.Signature_MouseMove);
                MouseEventHandler mouseEventHandler3 = new MouseEventHandler(this.Signature_MouseUp);
                PictureBox signature1 = this._Signature;
                if (signature1 != null)
                {
                    signature1.MouseDown -= mouseEventHandler1;
                    signature1.MouseMove -= mouseEventHandler2;
                    signature1.MouseUp -= mouseEventHandler3;
                }
                this._Signature = value;
                PictureBox signature2 = this._Signature;
                if (signature2 == null)
                    return;
                signature2.MouseDown += mouseEventHandler1;
                signature2.MouseMove += mouseEventHandler2;
                signature2.MouseUp += mouseEventHandler3;
            }
        }

        public bool isReadOnly
        {
            get
            {
                return this.isReadOnlyVar;
            }
            set
            {
                this.isReadOnlyVar = value;
            }
        }

        public string getSignatureText
        {
            get
            {
                int num1 = 0;
                string str1 = "";
                int num2 = 0;
                try
                {
                    ProjectData.ClearProjectError();
                    num1 = -2;
                    int num4 = checked(this.SigMovesO - 1);
                    int index = 0;
                    goto label_6;
                    label_4:
                    string str2 = str1 + this.PadHex(this.SigArrayXO[index]) + this.PadHex(this.SigArrayYO[index]);
                    checked { ++index; }
                    label_6:
                    if (index <= num4)
                        goto label_4;
                    goto label_13;
                }
                catch (Exception ex) when (ex is Exception & (uint)num1 > 0U & num2 == 0)
                {
                    ProjectData.SetProjectError(ex);
                }
                throw ProjectData.CreateProjectError(-2146828237);
                label_13:
                if (num2 != 0)
                    ProjectData.ClearProjectError();
                return str1;
            }
        }

        public bool hasSigned
        {
            get
            {
                return this.startedSig;
            }
        }

        private string PadHex(int inNum)
        {
            string str = "0" + string.Format("{0:X8}", (object)inNum);
            return str.Substring(checked(str.Length - 2), 2);
        }

        private int reversePadHex(string inHex)
        {
            return this.unHex(inHex);
        }

        private int convertChar(char charIn)
        {
            int num2;
            try
            {
                num2 = Conversions.ToInteger(charIn.ToString());
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                switch (charIn)
                {
                    case 'A':
                        num2 = 10;
                        break;

                    case 'B':
                        num2 = 11;
                        break;

                    case 'C':
                        num2 = 12;
                        break;

                    case 'D':
                        num2 = 13;
                        break;

                    case 'E':
                        num2 = 14;
                        break;

                    case 'F':
                        num2 = 15;
                        break;

                    default:
                        num2 = 0;
                        break;
                }
                ProjectData.ClearProjectError();
            }
            return num2;
        }

        private int unHex(string hexIn)
        {
            Stack stack = new Stack();
            int num2 = 0;
            string str = hexIn;
            int index = 0;
            while (index < str.Length)
            {
                char ch = str[index];
                stack.Push((object)ch);
                checked { ++index; }
            }
            int num3 = 0;
            foreach (char charIn in stack)
            {
                checked { num2 += (int)Math.Round(unchecked((double)this.convertChar(charIn) * Math.Pow(16.0, (double)num3))); }
                checked { ++num3; }
            }

            return num2;
        }

        private void setupSignature()
        {
            this.bmp = new Bitmap(this.Signature.Width, this.Signature.Height);
            this.gphDraw = Graphics.FromImage((Image)this.bmp);
            this.gphDraw.FillRectangle((Brush)new SolidBrush(Color.White), new Rectangle(0, 0, this.Signature.Width, this.Signature.Height));
            this.gphDraw.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, checked(this.Signature.Width - 1), checked(this.Signature.Height - 1)));
            this.Signature.Image = (Image)this.bmp;
            this.Signature.Refresh();
            Application.DoEvents();
        }

        private void Signature_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (!isReadOnlyVar)
                {
                    oldX = e.X;
                    oldY = e.Y;
                    this.SigArrayXO[SigMovesO] = e.X;
                    this.SigArrayYO[SigMovesO] = e.Y + 128;
                    SigMovesO += 1;
                    startedSig = true;
                    isMouseDown = true;
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Signature is too large!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void Signature_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown & !isReadOnlyVar)
            {
                try
                {
                    System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.Black);
                    gphDraw.DrawLine(p, oldX, oldY, e.X, e.Y);

                    oldX = e.X;
                    oldY = e.Y;
                    this.SigArrayXO[SigMovesO] = oldX;
                    this.SigArrayYO[SigMovesO] = oldY;
                    SigMovesO += 1;
                    Signature.Image = bmp;
                    startedSig = true;
                }
                catch
                {
                }
            }
        }

        private void Signature_MouseUp(object sender, MouseEventArgs e)
        {
            this.isMouseDown = false;
        }

        public SignatureBox(ref PictureBox pic)
        {
            this.SigArrayXO = new int[2501];
            this.SigArrayYO = new int[2501];
            this.SigDataO = "";
            this.startedSig = false;
            this.isMouseDown = false;
            this.pointNumber = 0;
            this.firstTime = true;
            this.pointsArray = new ArrayList();
            this.isReadOnlyVar = false;
            this.Signature = new PictureBox();
            this.Signature = pic;
            this.setupSignature();
        }

        public void ClearSignature()
        {
            this.setupSignature();
            Array.Clear((Array)this.SigArrayXO, 0, this.SigArrayXO.Length);
            Array.Clear((Array)this.SigArrayYO, 0, this.SigArrayYO.Length);
            this.SigDataO = "";
            this.SigMovesO = 0;
            this.firstTime = true;
            this.pointNumber = 0;
            this.startedSig = false;
        }

        public void plotSignature(string signatureText)
        {
            int startIndex = 0;
            int num1 = 0;
            int num2 = 0;
            double num3 = 0.7;
            try
            {
                if ((uint)Operators.CompareString(signatureText, "", false) <= 0U)
                    return;
                if (signatureText.Length > 0)
                {
                    int num4 = int.Parse(signatureText.Substring(startIndex, 2), NumberStyles.AllowHexSpecifier);
                    int num5 = int.Parse(signatureText.Substring(checked(startIndex + 2), 2), NumberStyles.AllowHexSpecifier);
                    while (startIndex < signatureText.Length)
                    {
                        string s1 = signatureText.Substring(startIndex, 2);
                        string s2 = signatureText.Substring(checked(startIndex + 2), 2);
                        try
                        {
                            num1 = int.Parse(s1, NumberStyles.AllowHexSpecifier);
                            num2 = int.Parse(s2, NumberStyles.AllowHexSpecifier);
                        }
                        catch (FormatException ex)
                        {
                            ProjectData.SetProjectError((Exception)ex);
                            int num6 = (int)MessageBox.Show(ex.Message);
                            ProjectData.ClearProjectError();
                        }
                        if (num2 > (int)sbyte.MaxValue)
                        {
                            num4 = num1;
                            num5 = checked(num2 - 128);
                        }
                        else
                        {
                            this.gphDraw.DrawLine(new Pen(Color.Black), new PointF((float)num4 * (float)num3, (float)num5 * (float)num3), new PointF((float)num1 * (float)num3, (float)num2 * (float)num3));
                            num4 = num1;
                            num5 = num2;
                        }
                        checked { startIndex += 4; }
                        this.SigArrayXO[checked((int)Math.Round(unchecked((double)startIndex / 4.0)) - 1)] = num4;
                        this.SigArrayYO[checked((int)Math.Round(unchecked((double)startIndex / 4.0)) - 1)] = num5;
                    }
                }
                this.SigMovesO = checked((int)Math.Round(unchecked((double)startIndex / 4.0)));
                this.Signature.Image = (Image)this.bmp;
                this.Signature.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num4 = (int)Interaction.MsgBox((object)"Unable to map this string!", MsgBoxStyle.Exclamation, (object)"Error");
                ProjectData.ClearProjectError();
            }
        }

        public Bitmap getBitmap()
        {
            return (Bitmap)this.Signature.Image;
        }
    }
}