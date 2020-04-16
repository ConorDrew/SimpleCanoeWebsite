// Decompiled with JetBrains decompiler
// Type: FSM.LocationServices.LocationServices
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Runtime.CompilerServices;

namespace FSM.LocationServices
{
  public class LocationServices
  {
    public object GetLongLat(string PostCode)
    {
      WebClient webClient = new WebClient();
      string str = "https://api.postcodes.io/postcodes/";
      webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
      return RuntimeHelpers.GetObjectValue(JsonConvert.DeserializeObject(webClient.DownloadString(str + PostCode.Replace("-", ""))));
    }

    public object GetGoogleDistance(
      string OriginLong,
      string OriginLat,
      string DestLong,
      string DestLat)
    {
      string str = "AIzaSyCnwir28a6nUmeo2On1gBQvcvEGk-eoa4g";
      WebClient webClient = new WebClient();
      string address = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=40.6655101,-73.89188969999998&destinations=40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.659569%2C-73.933783%7C40.729029%2C-73.851524%7C40.6860072%2C-73.6334271%7C40.598566%2C-73.7527626%7C40.659569%2C-73.933783%7C40.729029%2C-73.851524%7C40.6860072%2C-73.6334271%7C40.598566%2C-73.7527626&key=" + str;
      webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
      JObject jobject = JObject.Parse(webClient.DownloadString(address));
      jobject.SelectToken("rows[0].elements[0].duration.value").ToString();
      return (object) jobject;
    }
  }
}
