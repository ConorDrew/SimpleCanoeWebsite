Imports System.Collections.Generic
Imports System.Net.Mail

Namespace Entity

    Namespace Sys

        Public Class Emails

#Region "Properties"

            Private _From As String = ""

            Public Property From() As String
                Get
                    Return _From
                End Get
                Set(ByVal Value As String)
                    _From = Value
                End Set
            End Property

            Private _To As String = ""

            Public Property [To]() As String
                Get
                    Return _To
                End Get
                Set(ByVal Value As String)
                    _To = Value
                End Set
            End Property

            Private _Cc As String = ""

            Public Property CC() As String
                Get
                    Return _Cc
                End Get
                Set(ByVal Value As String)
                    _Cc = Value
                End Set
            End Property

            Private _BCc As String = ""

            Public Property BCC() As String
                Get
                    Return _BCc
                End Get
                Set(ByVal Value As String)
                    _BCc = Value
                End Set
            End Property

            Private _Subject As String = ""

            Public Property Subject() As String
                Get
                    Return _Subject
                End Get
                Set(ByVal Value As String)
                    _Subject = Value
                End Set
            End Property

            Private _Body As String = ""

            Public Property Body() As String
                Get
                    Return _Body
                End Get
                Set(ByVal Value As String)
                    _Body = Value
                End Set
            End Property

            Private _Attachments As New ArrayList

            Public Property Attachments() As ArrayList
                Get
                    Return _Attachments
                End Get
                Set(ByVal Value As ArrayList)
                    _Attachments = Value
                End Set
            End Property

            Private _DateTimeSent As DateTime = Nothing

            Public Property DateTimeSent() As DateTime
                Get
                    Return _DateTimeSent
                End Get
                Set(ByVal Value As DateTime)
                    _DateTimeSent = Value
                End Set
            End Property

            Private _SendMe As Boolean = False

            Public Property SendMe() As Boolean
                Get
                    Return _SendMe
                End Get
                Set(ByVal Value As Boolean)
                    _SendMe = Value
                End Set
            End Property

            Private _toList As New List(Of String)

            Public Property ToList() As List(Of String)
                Get
                    Return _toList
                End Get
                Set(ByVal value As List(Of String))
                    _toList = value
                End Set
            End Property

#End Region

#Region "Functions"

            Public Function Send() As Boolean
                Try
                    If Me.SendMe Then
                        Dim message As New MailMessage
                        Dim email As New SmtpClient
                        Me.From = IIf(String.IsNullOrEmpty(Me.From), EmailAddress.Gabriel, Me.From)
                        message.From = New MailAddress(Me.From)
#If DEBUG Or RFTTEST Then
                        message.To.Add(EmailAddress.Test)
                        Return True

#Else
                        If ToList.Count > 0 Then
                            For Each toEmail As String In ToList
                                message.To.Add(toEmail)
                            Next
                        Else
                            message.To.Add(Me.To)
                        End If

                        If Not Me.CC = Nothing Then
                            Dim CCArray As Array = Split(Me.CC, ",")
                            For i As Integer = 0 To CCArray.Length - 1
                                message.CC.Add(CCArray(i))
                            Next
                        End If
                        If Not Me.BCC = Nothing Then
                            Dim BCCArray As Array = Split(Me.BCC, ",")
                            For i As Integer = 0 To BCCArray.Length - 1
                                message.Bcc.Add(BCCArray(i))
                            Next
                        End If
#End If

                        message.Subject = Me.Subject
                        message.Body = Me.Body

                        For Each file As String In Attachments
                            If System.IO.File.Exists(file) Then
                                message.Attachments.Add(New System.Net.Mail.Attachment(file))
                            End If
                        Next

                        message.IsBodyHtml = True

                        email.Host = TheSystem.Configuration.SMTPServer
                        email.Port = 25
                        email.Credentials = New Net.NetworkCredential("", "")
                        email.Send(message)
                        message.Attachments.Dispose()
                        Return True
                    End If
                Catch ex As Exception
                    ShowMessage("Email could not be sent : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

#End Region

        End Class

    End Namespace

End Namespace