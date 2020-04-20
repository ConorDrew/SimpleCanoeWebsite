using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Sys
    {
        public class SignatureBox
        {
            public SignatureBox()
            {
                Signature = new PictureBox();
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public SignatureBox(ref PictureBox pic)
            {
                Signature = new PictureBox();
                Signature = pic;
                setupSignature();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private int oldX;
            private int oldY;
            private Bitmap bmp;
            private int[] SigArrayXO = new int[2501];
            private int[] SigArrayYO = new int[2501];
            private string SigDataO = "";
            private int SigMovesO;
            private bool startedSig = false;
            private bool isMouseDown = false;
            private int pointNumber = 0;
            private bool firstTime = true;
            private ArrayList pointsArray = new ArrayList();
            private bool isReadOnlyVar = false;
            private Graphics gphDraw;
            private PictureBox _Signature;

            private PictureBox Signature
            {
                [MethodImpl(MethodImplOptions.Synchronized)]
                get
                {
                    return _Signature;
                }

                [MethodImpl(MethodImplOptions.Synchronized)]
                set
                {
                    if (_Signature != null)
                    {

                        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                        /* TODO ERROR: Skipped RegionDirectiveTrivia */
                        _Signature.MouseDown -= Signature_MouseDown;
                        _Signature.MouseMove -= Signature_MouseMove;
                        _Signature.MouseUp -= Signature_MouseUp;
                    }

                    _Signature = value;
                    if (_Signature != null)
                    {
                        _Signature.MouseDown += Signature_MouseDown;
                        _Signature.MouseMove += Signature_MouseMove;
                        _Signature.MouseUp += Signature_MouseUp;
                    }
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool isReadOnly
            {
                get
                {
                    return isReadOnlyVar;
                }

                set
                {
                    isReadOnlyVar = value;
                }
            }

            public string getSignatureText
            {
                get
                {
                    ;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
                    /* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 1359


                    Input:
                                        On Error Resume Next

                     */
                    int j;
                    var sigData = default(string);
                    var loopTo = SigMovesO - 1;
                    for (j = 0; j <= loopTo; j++)
                        sigData = sigData + PadHex(SigArrayXO[j]) + PadHex(SigArrayYO[j]);
                    return sigData;
                }
            }

            public bool hasSigned
            {
                get
                {
                    return startedSig;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private string PadHex(int inNum)
            {
                string tempNum;
                tempNum = "0" + string.Format("{0:X8}", inNum);
                return tempNum.Substring(tempNum.Length - 2, 2);
            }

            private int reversePadHex(string inHex)
            {
                return unHex(inHex);
            }

            private int convertChar(char charIn)
            {
                int returnInt = new int();
                try
                {
                    returnInt = Conversions.ToInteger(charIn.ToString());
                }
                catch (Exception ex)
                {
                    switch (charIn)
                    {
                        case 'A':
                            {
                                returnInt = 10;
                                break;
                            }

                        case 'B':
                            {
                                returnInt = 11;
                                break;
                            }

                        case 'C':
                            {
                                returnInt = 12;
                                break;
                            }

                        case 'D':
                            {
                                returnInt = 13;
                                break;
                            }

                        case 'E':
                            {
                                returnInt = 14;
                                break;
                            }

                        case 'F':
                            {
                                returnInt = 15;
                                break;
                            }

                        default:
                            {
                                returnInt = default;
                                break;
                            }
                    }
                }

                return returnInt;
            }

            private int unHex(string hexIn)
            {
                var charStack = new Stack();
                int total = new int();
                total = 0;
                foreach (char c in hexIn)
                    charStack.Push(c);
                int worth = 0;
                foreach (char c in charStack)
                {
                    total = total + Conversions.ToInteger(convertChar(c) * Math.Pow(16, worth));
                    worth += 1;
                }

                return total;
            }

            private void setupSignature()
            {
                bmp = new Bitmap(Signature.Width, Signature.Height);
                gphDraw = Graphics.FromImage(bmp);
                gphDraw.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Signature.Width, Signature.Height));

                gphDraw.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, Signature.Width - 1, Signature.Height - 1));


                Signature.Image = bmp;
                Signature.Refresh();
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
                        SigArrayXO[SigMovesO] = e.X;
                        SigArrayYO[SigMovesO] = e.Y + 128;
                        SigMovesO += 1;
                        startedSig = true;
                        isMouseDown = true;
                    }
                }
                catch (IndexOutOfRangeException ex)
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
                        var p = new Pen(Color.Black);
                        gphDraw.DrawLine(p, oldX, oldY, e.X, e.Y);
                        oldX = e.X;
                        oldY = e.Y;
                        SigArrayXO[SigMovesO] = oldX;
                        SigArrayYO[SigMovesO] = oldY;
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
                isMouseDown = false;
            }

            public void ClearSignature()
            {
                setupSignature();
                Array.Clear(SigArrayXO, 0, SigArrayXO.Length);
                Array.Clear(SigArrayYO, 0, SigArrayYO.Length);
                SigDataO = "";
                SigMovesO = 0;
                firstTime = true;
                pointNumber = 0;
                startedSig = false;
            }

            public void plotSignature(string signatureText)
            {
                int sigPos = 0;
                int plotX = 0;
                int plotXOld = 0;
                int plotY = 0;
                int plotYOld = 0;
                string sX, sY;
                double multiplier = 0.7;
                try
                {
                    if (!string.IsNullOrEmpty(signatureText))
                    {
                        if (signatureText.Length > 0)
                        {
                            plotXOld = int.Parse(signatureText.Substring(sigPos, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                            plotYOld = int.Parse(signatureText.Substring(sigPos + 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                            while (sigPos < signatureText.Length)
                            {
                                sX = signatureText.Substring(sigPos, 2);
                                sY = signatureText.Substring(sigPos + 2, 2);
                                try
                                {
                                    plotX = int.Parse(sX, System.Globalization.NumberStyles.AllowHexSpecifier);
                                    plotY = int.Parse(sY, System.Globalization.NumberStyles.AllowHexSpecifier);
                                }
                                catch (FormatException fe)
                                {
                                    MessageBox.Show(fe.Message);
                                }

                                if (plotY > 127)
                                {
                                    plotXOld = plotX;
                                    plotYOld = plotY - 128;
                                }
                                else
                                {
                                    gphDraw.DrawLine(new Pen(Color.Black), new PointF((float)(plotXOld * multiplier), (float)(plotYOld * multiplier)), new PointF((float)(plotX * multiplier), (float)(plotY * multiplier)));
                                    plotXOld = plotX;
                                    plotYOld = plotY;
                                }

                                sigPos = sigPos + 4;
                                SigArrayXO[Conversions.ToInteger(sigPos / (double)4) - 1] = plotXOld;
                                SigArrayYO[Conversions.ToInteger(sigPos / (double)4) - 1] = plotYOld;
                            }
                        }

                        SigMovesO = Conversions.ToInteger(sigPos / (double)4);
                        Signature.Image = bmp;
                        Signature.Refresh();
                        Application.DoEvents();
                    }
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox("Unable to map this string!", MsgBoxStyle.Exclamation, "Error");
                }
            }

            public Bitmap getBitmap()
            {
                return (Bitmap)Signature.Image;
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}