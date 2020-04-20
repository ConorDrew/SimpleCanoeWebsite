using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FSM.LocationServices
{
    public class DataIn
    {
        public string postcode { get; set; }
    }

    public class LocationServices
    {
        public object GetLongLat(string PostCode)
        {
            var webClient = new WebClient();
            string url = "https://api.postcodes.io/postcodes/";

            // '  webClient.Headers.Set(HttpRequestHeader.Authorization, "AccessKey live_I04FZlBf4G32vRXnoMUN2U7oq")

            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = webClient.DownloadString(url + PostCode.Replace("-", ""));
            var json = JsonConvert.DeserializeObject(response);
            return json;
        }

        public object GetGoogleDistance(string OriginLong, string OriginLat, string DestLong, string DestLat)
        {
            string api = "AIzaSyCnwir28a6nUmeo2On1gBQvcvEGk-eoa4g";
            var webClient = new WebClient();

            // lat / long this order

            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=40.6655101,-73.89188969999998&destinations=40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.659569%2C-73.933783%7C40.729029%2C-73.851524%7C40.6860072%2C-73.6334271%7C40.598566%2C-73.7527626%7C40.659569%2C-73.933783%7C40.729029%2C-73.851524%7C40.6860072%2C-73.6334271%7C40.598566%2C-73.7527626&key=" + api;

            // '  webClient.Headers.Set(HttpRequestHeader.Authorization, "AccessKey live_I04FZlBf4G32vRXnoMUN2U7oq")

            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = webClient.DownloadString(url);
            var json = JObject.Parse(response);
            // JsonConvert.DeserializeObject(response)
            string time = json.SelectToken("rows[0].elements[0].duration.value").ToString();

            // "rows": [ {
            // "elements": [ {
            // "status": "OK",
            // "duration": {
            // "value": 340110,

            return json;
        }
    }
}