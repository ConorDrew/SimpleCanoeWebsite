// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.Emails
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
    public class Emails
    {
        private string _From;
        private string _To;
        private string _Cc;
        private string _BCc;
        private string _Subject;
        private string _Body;
        private ArrayList _Attachments;
        private DateTime _DateTimeSent;
        private bool _SendMe;
        private List<string> _toList;

        public Emails()
        {
            this._From = "";
            this._To = "";
            this._Cc = "";
            this._BCc = "";
            this._Subject = "";
            this._Body = "";
            this._Attachments = new ArrayList();
            this._DateTimeSent = DateTime.MinValue;
            this._SendMe = false;
            this._toList = new List<string>();
        }

        public string From
        {
            get
            {
                return this._From;
            }
            set
            {
                this._From = value;
            }
        }

        public string To
        {
            get
            {
                return this._To;
            }
            set
            {
                this._To = value;
            }
        }

        public string CC
        {
            get
            {
                return this._Cc;
            }
            set
            {
                this._Cc = value;
            }
        }

        public string BCC
        {
            get
            {
                return this._BCc;
            }
            set
            {
                this._BCc = value;
            }
        }

        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
            }
        }

        public string Body
        {
            get
            {
                return this._Body;
            }
            set
            {
                this._Body = value;
            }
        }

        public ArrayList Attachments
        {
            get
            {
                return this._Attachments;
            }
            set
            {
                this._Attachments = value;
            }
        }

        public DateTime DateTimeSent
        {
            get
            {
                return this._DateTimeSent;
            }
            set
            {
                this._DateTimeSent = value;
            }
        }

        public bool SendMe
        {
            get
            {
                return this._SendMe;
            }
            set
            {
                this._SendMe = value;
            }
        }

        public List<string> ToList
        {
            get
            {
                return this._toList;
            }
            set
            {
                this._toList = value;
            }
        }

        public bool Send()
        {
            bool flag = false;
            try
            {
                if (this.SendMe)
                {
                    MailMessage mailMessage = new MailMessage();
                    SmtpClient smtpClient = new SmtpClient();
                    this.From = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(this.From), (object)EmailAddress.Gabriel, (object)this.From));
                    mailMessage.From = new MailAddress(this.From);
                    mailMessage.To.Add(EmailAddress.Test);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)App.ShowMessage("Email could not be sent : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }
    }
}