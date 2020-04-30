using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace FSM.Entity
{
    namespace Sys
    {
        public class Emails
        {
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private string _From = "";

            public string From
            {
                get
                {
                    return _From;
                }

                set
                {
                    _From = value;
                }
            }

            private string _To = "";

            public string To
            {
                get
                {
                    return _To;
                }

                set
                {
                    _To = value;
                }
            }

            private string _Cc = "";

            public string CC
            {
                get
                {
                    return _Cc;
                }

                set
                {
                    _Cc = value;
                }
            }

            private string _BCc = "";

            public string BCC
            {
                get
                {
                    return _BCc;
                }

                set
                {
                    _BCc = value;
                }
            }

            private string _Subject = "";

            public string Subject
            {
                get
                {
                    return _Subject;
                }

                set
                {
                    _Subject = value;
                }
            }

            private string _Body = "";

            public string Body
            {
                get
                {
                    return _Body;
                }

                set
                {
                    _Body = value;
                }
            }

            private ArrayList _Attachments = new ArrayList();

            public ArrayList Attachments
            {
                get
                {
                    return _Attachments;
                }

                set
                {
                    _Attachments = value;
                }
            }

            private DateTime _DateTimeSent = default;

            public DateTime DateTimeSent
            {
                get
                {
                    return _DateTimeSent;
                }

                set
                {
                    _DateTimeSent = value;
                }
            }

            private bool _SendMe = false;

            public bool SendMe
            {
                get
                {
                    return _SendMe;
                }

                set
                {
                    _SendMe = value;
                }
            }

            private List<string> _toList = new List<string>();

            public List<string> ToList
            {
                get
                {
                    return _toList;
                }

                set
                {
                    _toList = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public bool Send()
            {
                try
                {
                    if (SendMe)
                    {
                        var message = new MailMessage();
                        var email = new SmtpClient();
                        From = Conversions.ToString(Interaction.IIf(string.IsNullOrEmpty(From), EmailAddress.Gabriel, From));
                        message.From = new MailAddress(From);
                        /* TODO ERROR: Skipped IfDirectiveTrivia */
#if Debug || RFTTEST
                        message.To.Add(EmailAddress.Test);
                        return true;
#endif
                        /* TODO ERROR: Skipped ElseDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
                        message.Subject = Subject;
                        message.Body = Body;
                        foreach (string file in Attachments)
                        {
                            if (System.IO.File.Exists(file))
                            {
                                message.Attachments.Add(new Attachment(file));
                            }
                        }

                        message.IsBodyHtml = true;
                        email.Host = App.TheSystem.Configuration.SMTPServer;
                        email.Port = 25;
                        email.Credentials = new System.Net.NetworkCredential("", "");
                        email.Send(message);
                        message.Attachments.Dispose();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Email could not be sent : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return default;
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}