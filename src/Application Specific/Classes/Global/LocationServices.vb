Imports System.Runtime.Serialization

Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq



Namespace LocationServices

    Public Class DataIn
        Public Property postcode As String
    End Class

    Public Class LocationServices
        Public Function GetLongLat(ByVal PostCode As String) As Object
            Dim webClient As New WebClient()
            Dim url As String = "https://api.postcodes.io/postcodes/"

            ''  webClient.Headers.Set(HttpRequestHeader.Authorization, "AccessKey live_I04FZlBf4G32vRXnoMUN2U7oq")

            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json")
            Dim response As String = webClient.DownloadString(url & PostCode.Replace("-", ""))
            Dim json As Object = JsonConvert.DeserializeObject(response)
            Return json
        End Function

        Public Function GetGoogleDistance(ByVal OriginLong As String, ByVal OriginLat As String, ByVal DestLong As String, ByVal DestLat As String) As Object
            Dim api As String = "AIzaSyCnwir28a6nUmeo2On1gBQvcvEGk-eoa4g"
            Dim webClient As New WebClient()

            ' lat / long this order

            Dim url As String = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=40.6655101,-73.89188969999998&destinations=40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.6905615%2C-73.9976592%7C40.659569%2C-73.933783%7C40.729029%2C-73.851524%7C40.6860072%2C-73.6334271%7C40.598566%2C-73.7527626%7C40.659569%2C-73.933783%7C40.729029%2C-73.851524%7C40.6860072%2C-73.6334271%7C40.598566%2C-73.7527626&key=" & api

            ''  webClient.Headers.Set(HttpRequestHeader.Authorization, "AccessKey live_I04FZlBf4G32vRXnoMUN2U7oq")

            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json")
            Dim response As String = webClient.DownloadString(url)
            Dim json As JObject = JObject.Parse(response)
            'JsonConvert.DeserializeObject(response)
            Dim time As String = json.SelectToken("rows[0].elements[0].duration.value").ToString

            '        "rows": [ {
            '"elements": [ {
            '  "status": "OK",
            '  "duration": {
            '    "value": 340110,

            Return json
        End Function
    End Class
End Namespace



