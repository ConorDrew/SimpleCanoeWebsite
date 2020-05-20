using System;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace FSM.MessageBird
{
    public class Sending
    {
        public string recipients { get; set; }
        public string body { get; set; }
        public string originator { get; set; }
    }

    public class TextClient
    {
        public void MakeCall(string Message, string Number, string Froms)
        {
            if (App.IsGasway)
            {
                var webClient = new WebClient();
                string url = "https://rest.messagebird.com";
                webClient.Headers.Set(HttpRequestHeader.Authorization, "AccessKey live_I04FZlBf4G32vRXnoMUN2U7oq");
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                string response = webClient.DownloadString(url + "/balance");
                var s = new Sending();
                if ((Number.Substring(0, 2) ?? "") == "01")
                {
                    Number = "0044" + Number.Remove(0, 1);
                    s.recipients = Number;
                    s.body = Message;
                    object serializedParameters1 = JsonConvert.SerializeObject(s);
                    try
                    {
                        response = webClient.UploadString(url + "/voicemessages", "POST", Conversions.ToString(serializedParameters1));
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    s.recipients = Number;
                    s.body = Message;
                    s.originator = Froms;
                    object serializedParameters = JsonConvert.SerializeObject(s);
                    try
                    {
                        response = webClient.UploadString(url + "/messages", "POST", Conversions.ToString(serializedParameters));
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}