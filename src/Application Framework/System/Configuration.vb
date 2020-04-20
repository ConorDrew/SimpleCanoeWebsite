Namespace Entity

    Namespace Sys

        Public Class Configuration

            Public Sub New()
                Dim ConfigurationDetails As New DataSet

                Dim configRow As Integer = 0

                'Select config file for release type
                If IsRFT Then
                    ConfigurationDetails.ReadXml(Application.StartupPath & "\ApplicationSettings_RFT.config")
                ElseIf IsRFTTEST Then
                    ConfigurationDetails.ReadXml(Application.StartupPath & "\ApplicationSettings_RFTTEST.config")
                ElseIf IsBlueflame Then
                    ConfigurationDetails.ReadXml(Application.StartupPath & "\ApplicationSettings_Blueflame.config")
                ElseIf IsBlueflameTest Then
                    ConfigurationDetails.ReadXml(Application.StartupPath & "\ApplicationSettings_BlueflameTest.config")
                ElseIf IsGasway Or IsRelease Then
                    ConfigurationDetails.ReadXml(Application.StartupPath & "\ApplicationSettings.config")
                Else
                    'if were in beta, we have access to all configs
                    ConfigurationDetails.ReadXml(Application.StartupPath & "\ApplicationSettings_Beta.config")

                    Dim dbs As New DataTable
                    dbs.Columns.Add("ValueMember")
                    dbs.Columns.Add(New DataColumn("DisplayMember"))
                    dbs.Columns.Add(New DataColumn("Deleted"))

                    Dim index As Integer = 1
                    For Each config As DataRow In ConfigurationDetails.Tables(0).Rows
                        'if we can connect to db then add it to selection
                        If TestConnection(config.Item("DatabaseServer"), config.Item("DatabaseName"),
                                          config.Item("DatabaseUsername"), config.Item("DatabasePassword")) Then

                            dbs.Rows.Add(New String() {index, config.Item("DatabaseFriendlyName"), "0"})
                        End If
                        index += 1
                    Next

                    'if we have more than one connection then we default display selection window
                    If dbs.Rows.Count > 1 Then
                        Dim f As New FRMSelectDatabase(dbs)
                        f.ShowDialog()
                        configRow = f.SelectedDb
                    End If

                End If

                'set system configuration properties
                Dim value As String = ConfigurationDetails.Tables(0).Rows(configRow).Item("DatabaseName")
                Try
                    DBName = [Enum].Parse(GetType(Enums.DataBaseName), value)
                Catch ex As Exception
                    MsgBox("Enum for database missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    App.CloseApplication()
                End Try

                DatabaseServer = ConfigurationDetails.Tables(0).Rows(configRow).Item("DatabaseServer")
                DatabaseUsername = ConfigurationDetails.Tables(0).Rows(configRow).Item("DatabaseUsername")
                DatabasePassword = ConfigurationDetails.Tables(0).Rows(configRow).Item("DatabasePassword")
                DatabaseName = ConfigurationDetails.Tables(0).Rows(configRow).Item("DatabaseName")
                DocumentsLocation = ConfigurationDetails.Tables(0).Rows(configRow).Item("DocumentsLocation")
                DatabaseFriendlyName = ConfigurationDetails.Tables(0).Rows(configRow).Item("DatabaseFriendlyName")
                TemplateLocation = ConfigurationDetails.Tables(0).Rows(configRow).Item("TemplateLocation")

                DatabasePort = ConfigurationDetails.Tables(0).Rows(configRow).Item("DatabasePort")
                SuperAdminID = ConfigurationDetails.Tables(0).Rows(configRow).Item("SuperAdminID")
                SupportEmailFrom = ConfigurationDetails.Tables(0).Rows(configRow).Item("SupportEmailFrom")
                SupportEmailTo = ConfigurationDetails.Tables(0).Rows(configRow).Item("SupportEmailTo")
                SalesEmailFrom = ConfigurationDetails.Tables(0).Rows(configRow).Item("SalesEmailFrom")
                InfoEmail = ConfigurationDetails.Tables(0).Rows(configRow).Item("FeedbackEmailFrom")
                SMTPServer = ConfigurationDetails.Tables(0).Rows(configRow).Item("SMTPServer")
                SMTPServerUsername = ConfigurationDetails.Tables(0).Rows(configRow).Item("SMTPServerUsername")
                SMTPServerPassword = ConfigurationDetails.Tables(0).Rows(configRow).Item("SMTPServerPassword")
                VATNO = ConfigurationDetails.Tables(0).Rows(configRow).Item("VATNO")

                CompanyName = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyName")
                CompanyAddres1 = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyAddres1")
                CompanyAddres2 = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyAddres2")
                CompanyAddres3 = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyAddres3")
                CompanyAddres4 = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyAddres4")
                CompanyAddres5 = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyAddres5")
                CompanyPostcode = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyPostcode")
                CompanyTelephoneNumber = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyTelephoneNumber")
                CompanyWebsite = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyWebsite")
                CompanyDomain = ConfigurationDetails.Tables(0).Rows(configRow).Item("CompanyDomain")

                CompanyFullAddress = CompanyName & ", " & CompanyAddres1 & ", " & CompanyAddres2 & ", " & CompanyAddres3 & ", " & CompanyPostcode
            End Sub

            Private Function TestConnection(ByVal dbServer As String, ByVal dbName As String,
                                            ByVal dbUsername As String, ByVal dbPass As String) As Boolean

                'set up connection string
                Dim str As String = ""
                If (dbServer.Contains(".\")) Then
                    str = "Data Source=" & dbServer & ";Initial Catalog=" & dbName & ";Integrated Security=True"
                Else
                    str = "Server=tcp:" & dbServer & ";"
                    str += "User Id=" & dbUsername & ";"
                    If dbPass.Trim.Length > 0 Then
                        str += "Password=" & dbPass & ";"
                    End If
                    str += "Database=" & dbName & ";"
                End If

                'TEST CONNECTION
                Try
                    Using conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(str)
                        Try
                            conn.Open()
                            Return True
                        Catch ex As Exception
                        Finally
                            If conn.State = ConnectionState.Open Then
                                conn.Close()
                            End If
                        End Try
                    End Using
                Catch ex As Exception
                End Try
            End Function

#Region "Configuration"

            Private _isDebug As Boolean = False

            Public ReadOnly Property IsDebug As Boolean
                Get
#If DEBUG Then
                    _isDebug = True
#End If
                    Return _isDebug
                End Get
            End Property

            Private _isRelease As Boolean = False

            Public ReadOnly Property IsRelease As Boolean
                Get
#If RELEASE Then
                    _isRelease = True
#End If
                    Return _isRelease
                End Get
            End Property

            Private _isGasway As Boolean = False

            Public ReadOnly Property IsGasway As Boolean
                Get
#If GASWAY Then
                    _isGasway = True
#End If
                    Return _isGasway
                End Get
            End Property

            Private _isRFT As Boolean = False

            Public ReadOnly Property IsRFT As Boolean
                Get
#If RFT Then
                    _isRFT = True
#End If
                    Return _isRFT
                End Get
            End Property

            Private _isRFTTEST As Boolean = False

            Public ReadOnly Property IsRFTTEST As Boolean
                Get
#If RFTTEST Then
                    _isRFTTEST = True
#End If
                    Return _isRFTTEST
                End Get
            End Property

            Private _isBlueflame As Boolean = False

            Public ReadOnly Property IsBlueflame As Boolean
                Get
#If Blueflame Then
                    _isBlueflame = True
#End If
                    Return _isBlueflame
                End Get
            End Property

            Private _isBlueflameTest As Boolean = False

            Public ReadOnly Property IsBlueflameTest As Boolean
                Get
#If BlueflameTest Then
                    _isBlueflameTest = True
#End If
                    Return _isBlueflameTest
                End Get
            End Property

#End Region

#Region "Database"

            Private _DatabaseServer As String = String.Empty

            Public Property DatabaseServer() As String
                Get
                    Return _DatabaseServer
                End Get
                Set(ByVal Value As String)
                    _DatabaseServer = Value
                End Set
            End Property

            Private _DatabaseFriendlyName As String = String.Empty

            Public Property DatabaseFriendlyName() As String
                Get
                    Return _DatabaseFriendlyName
                End Get
                Set(ByVal Value As String)
                    _DatabaseFriendlyName = Value
                End Set
            End Property

            Private _DBName As Entity.Sys.Enums.DataBaseName

            Public Property DBName() As Entity.Sys.Enums.DataBaseName
                Get
                    Return _DBName
                End Get
                Set(ByVal value As Entity.Sys.Enums.DataBaseName)
                    _DBName = value
                End Set
            End Property

            Private _DatabaseUsername As String = String.Empty

            Public Property DatabaseUsername() As String
                Get
                    Return _DatabaseUsername
                End Get
                Set(ByVal Value As String)
                    _DatabaseUsername = Value
                End Set
            End Property

            Private _DatabasePassword As String = String.Empty

            Public Property DatabasePassword() As String
                Get
                    Return _DatabasePassword
                End Get
                Set(ByVal Value As String)
                    _DatabasePassword = Value
                End Set
            End Property

            Private _DatabaseName As String = String.Empty

            Public Property DatabaseName() As String
                Get
                    Return _DatabaseName
                End Get
                Set(ByVal Value As String)
                    _DatabaseName = Value
                End Set
            End Property

            Private _DatabasePort As String = String.Empty

            Public Property DatabasePort() As String
                Get
                    Return _DatabasePort
                End Get
                Set(ByVal Value As String)
                    _DatabasePort = Value
                End Set
            End Property

            Public ReadOnly Property ConnectionString() As String
                Get
                    Dim str As String = ""
                    Select Case TheSystem.DataBaseServerType
                        Case Enums.DatabaseSystems.MySQL
                            str += "server=" & DatabaseServer & ";"
                            str += "user id=" & DatabaseUsername & ";"
                            If DatabasePassword.Trim.Length > 0 Then
                                str += "password=" & DatabasePassword & ";"
                            End If
                            str += "database=" & DatabaseName & ";"
                            str += "port=" & DatabasePort & ";"
                        Case Enums.DatabaseSystems.Microsoft_SQL_Server
                            If (DatabaseServer.Contains(".\")) Then
                                str = "Data Source=" & DatabaseServer & ";Initial Catalog=" & DatabaseName & ";Integrated Security=True"
                            Else
                                str = "Server=tcp:" & DatabaseServer & ";"
                                str += "User Id=" & DatabaseUsername & ";"
                                If DatabasePassword.Trim.Length > 0 Then
                                    str += "Password=" & DatabasePassword & ";"
                                End If
                                str += "Database=" & DatabaseName & ";"
                            End If
                    End Select

                    Return str
                End Get
            End Property

#End Region

#Region "System Dependant"

            Public ReadOnly Property SystemVersion() As String
                Get
                    Return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileVersion
                End Get
            End Property

            Private _SuperAdminID As Integer = 0

            Public Property SuperAdminID() As Integer
                Get
                    Return _SuperAdminID
                End Get
                Set(ByVal Value As Integer)
                    _SuperAdminID = Value
                End Set
            End Property

            Private _SupportEmailFrom As String = String.Empty

            Public Property SupportEmailFrom() As String
                Get
                    Return _SupportEmailFrom
                End Get
                Set(ByVal Value As String)
                    _SupportEmailFrom = Value
                End Set
            End Property

            Private _SupportEmailTo As String = String.Empty

            Public Property SupportEmailTo() As String
                Get
                    Return _SupportEmailTo
                End Get
                Set(ByVal Value As String)
                    _SupportEmailTo = Value
                End Set
            End Property

            Private _SalesEmailFrom As String = String.Empty

            Public Property SalesEmailFrom() As String
                Get
                    Return _SalesEmailFrom
                End Get
                Set(ByVal Value As String)
                    _SalesEmailFrom = Value
                End Set
            End Property

            Public Property InfoEmail() As String

            Private _SMTPServer As String = String.Empty

            Public Property SMTPServer() As String
                Get
                    Return _SMTPServer
                End Get
                Set(ByVal Value As String)
                    _SMTPServer = Value
                End Set
            End Property

            Private _SMTPServerUsername As String = String.Empty

            Public Property SMTPServerUsername() As String
                Get
                    Return _SMTPServerUsername
                End Get
                Set(ByVal Value As String)
                    _SMTPServerUsername = Value
                End Set
            End Property

            Private _SMTPServerPassword As String = String.Empty

            Public Property SMTPServerPassword() As String
                Get
                    Return _SMTPServerPassword
                End Get
                Set(ByVal Value As String)
                    _SMTPServerPassword = Value
                End Set
            End Property

            Private _DocumentsLocation As String = String.Empty

            Public Property DocumentsLocation() As String
                Get
                    Return _DocumentsLocation
                End Get
                Set(ByVal Value As String)
                    _DocumentsLocation = Value
                End Set
            End Property

            Private _TemplateLocation As String = String.Empty

            Public Property TemplateLocation() As String
                Get
                    Return _TemplateLocation
                End Get
                Set(ByVal Value As String)
                    _TemplateLocation = Value
                End Set
            End Property

            Private _VATNO As String = String.Empty

            Public Property VATNO() As String
                Get
                    Return _VATNO
                End Get
                Set(ByVal Value As String)
                    _VATNO = Value
                End Set
            End Property

            Public CompanyName As String
            Public CompanyAddres1 As String
            Public CompanyAddres2 As String
            Public CompanyAddres3 As String
            Public CompanyAddres4 As String
            Public CompanyAddres5 As String
            Public CompanyPostcode As String
            Public CompanyTelephoneNumber As String
            Public CompanyWebsite As String
            Public CompanyDomain As String
            Public CompanyFullAddress As String

#End Region

        End Class

    End Namespace

End Namespace