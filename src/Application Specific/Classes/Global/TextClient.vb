Imports System.Net
Imports Newtonsoft.Json

Namespace MessageBird

    Public Class Sending
        Public Property recipients As String
        Public Property body As String
        Public Property originator As String
    End Class

    Public Class TextClient

        Public Sub MakeCall(ByVal Message As String, ByVal Number As String, ByVal Froms As String)
            If IsGasway Then

                Dim webClient As New WebClient()

                Dim url As String = "https://rest.messagebird.com"
                webClient.Headers.Set(HttpRequestHeader.Authorization, "AccessKey live_I04FZlBf4G32vRXnoMUN2U7oq")
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json")

                Dim response As String = webClient.DownloadString(url & "/balance")

                Dim s As New Sending

                If Number.Substring(0, 2) = "01" Then
                    Number = "0044" & Number.Remove(0, 1)
                    s.recipients = Number
                    s.body = Message

                    Dim serializedParameters1 As Object = JsonConvert.SerializeObject(s)

                    Try
                        response = webClient.UploadString(url & "/voicemessages", "POST", serializedParameters1)
                    Catch ex As Exception

                    End Try
                Else

                    s.recipients = Number
                    s.body = Message
                    s.originator = Froms

                    Dim serializedParameters As Object = JsonConvert.SerializeObject(s)

                    Try
                        response = webClient.UploadString(url & "/messages", "POST", serializedParameters)
                    Catch ex As Exception

                    End Try

                End If
            End If
        End Sub

    End Class

End Namespace