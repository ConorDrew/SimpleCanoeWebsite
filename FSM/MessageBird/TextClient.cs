// Decompiled with JetBrains decompiler
// Type: FSM.MessageBird.TextClient
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.Net;

namespace FSM.MessageBird
{
  public class TextClient
  {
    public void MakeCall(string Message, string Number, string Froms)
    {
      if (!App.IsGasway)
        return;
      WebClient webClient = new WebClient();
      string str1 = "https://rest.messagebird.com";
      webClient.Headers.Set(HttpRequestHeader.Authorization, "AccessKey live_I04FZlBf4G32vRXnoMUN2U7oq");
      webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
      string str2 = webClient.DownloadString(str1 + "/balance");
      Sending sending = new Sending();
      if (Operators.CompareString(Number.Substring(0, 2), "01", false) == 0)
      {
        Number = "0044" + Number.Remove(0, 1);
        sending.recipients = Number;
        sending.body = Message;
        object obj = (object) JsonConvert.SerializeObject((object) sending);
        try
        {
          str2 = webClient.UploadString(str1 + "/voicemessages", "POST", Conversions.ToString(obj));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        sending.recipients = Number;
        sending.body = Message;
        sending.originator = Froms;
        object obj = (object) JsonConvert.SerializeObject((object) sending);
        try
        {
          str2 = webClient.UploadString(str1 + "/messages", "POST", Conversions.ToString(obj));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
    }
  }
}
