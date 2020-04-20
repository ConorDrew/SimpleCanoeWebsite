Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports DocumentFormat.OpenXml.Packaging
Imports FSM.Entity.ContactAttempts
Imports iTextSharp.text.pdf
Imports text = iTextSharp.text
Imports WD = Microsoft.Office.Interop.Word
Imports WP = DocumentFormat.OpenXml.Wordprocessing

Namespace Entity

    Namespace Sys

        Public Class Printing

#Region "Variables / Properties"

            Dim details1 As String = ""
            Dim details2 As String = ""
            Private tableCnt As Integer = 1
            Dim answer As DialogResult = DialogResult.No
            Private InsertDocument As Boolean = True

            Private _wordApp As Word.Application = Nothing

            Public Property MsWordApp() As Word.Application
                Get
                    Return _wordApp
                End Get
                Set(ByVal Value As Word.Application)
                    _wordApp = Value
                End Set
            End Property

            Private _wordDoc As Word.Document = Nothing

            Private Property WordDoc() As Word.Document
                Get
                    Return _wordDoc
                End Get
                Set(ByVal Value As Word.Document)
                    _wordDoc = Value
                End Set
            End Property

            Private _detailsToPrint As Object = Nothing

            Private Property DetailsToPrint() As Object
                Get
                    Return _detailsToPrint
                End Get
                Set(ByVal Value As Object)
                    _detailsToPrint = Value
                End Set
            End Property

            Private _documentName As String = String.Empty

            Private Property DocumentName() As String
                Get
                    Return _documentName
                End Get
                Set(ByVal Value As String)
                    _documentName = Value.Replace("/", "").Replace("\", "")
                End Set
            End Property

            Private _printType As Enums.SystemDocumentType

            Private Property PrintType() As Enums.SystemDocumentType
                Get
                    Return _printType
                End Get
                Set(ByVal Value As Enums.SystemDocumentType)
                    _printType = Value
                End Set
            End Property

            Private _orderID As Integer

            Public Property OrderID() As Integer
                Get
                    Return _orderID
                End Get
                Set(ByVal Value As Integer)
                    _orderID = Value
                End Set
            End Property

            Private _siteID As Integer

            Public Property SiteID() As Integer
                Get
                    Return _siteID
                End Get
                Set(ByVal Value As Integer)
                    _siteID = Value
                End Set
            End Property

            Private _ContractsDT As DataTable

            Public Property ContractsDT() As DataTable
                Get
                    Return _ContractsDT
                End Get
                Set(ByVal Value As DataTable)
                    _ContractsDT = Value
                End Set
            End Property

            Private _lsrErrors As New List(Of LSR.LSRError)

            Private Property LSRErrors() As List(Of LSR.LSRError)
                Get
                    Return _lsrErrors
                End Get
                Set(ByVal value As List(Of LSR.LSRError))
                    _lsrErrors = value
                End Set
            End Property

            Dim missedfirst As Boolean = False
            Dim ddsort As String = ""
            Dim ddAcc As String = ""
            Dim wpFilePath As String = ""
            Dim p As String = "Gasway100"

#End Region

#Region "Functions"

            Public Sub New(ByVal detailsToPrintIn As Object, ByVal documentNameIn As String, ByVal printTypeIn As Enums.SystemDocumentType,
                           Optional ByVal multipleDocs As Boolean = False, Optional ByVal OrderID As Integer = 0,
                           Optional ByVal isEmail As Boolean = False, Optional ByVal ApptsPerDay As Integer = 13,
                           Optional ByVal CustomerID As Integer = Nothing, Optional ByVal LetterCreationDate As DateTime = Nothing,
                           Optional dt As DataTable = Nothing)

                ContractsDT = dt
                DetailsToPrint = detailsToPrintIn
                DocumentName = documentNameIn
                PrintType = printTypeIn
                Me.OrderID = OrderID
                If Not isEmail = True Then
                    If multipleDocs = True Then
                        PrintMultiDocs(ApptsPerDay, CustomerID, LetterCreationDate)
                    Else
                        Print()
                    End If
                End If
            End Sub

            Public Function MultiEmail() As ArrayList
                Dim DetailsToPrint As String = ""
                Dim success As Boolean = False
                Dim filePath As String = ""
                Dim returnStuff As New ArrayList

                Cursor.Current = Cursors.WaitCursor

                Select Case PrintType

                    Case Enums.SystemDocumentType.ContractBatch

#Region "Contract Batch"

                        Try
                            GenerateDDMS(ContractsDT.Select())
                            filePath = GenerateRenewalLetters(ContractsDT.Select())
                            success = True
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            If success Then
                                returnStuff.Add(filePath)
                            End If
                            Cursor.Current = Cursors.Default
                        End Try
                        Return returnStuff

#End Region

                    Case Enums.SystemDocumentType.ContractExpiry

#Region "Contract Expiry"

                        Try
                            filePath = GenerateAnnualExpiryLetters(ContractsDT.Select("InvoiceFrequencyID = 6" & " OR ContractTypeID = 69420"))
                            success = True
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            If success Then
                                returnStuff.Add(filePath)
                            End If
                            Cursor.Current = Cursors.Default
                        End Try
                        Return returnStuff

#End Region

                    Case Else
                        Return returnStuff
                End Select
            End Function

            Public Function EmailWP() As String 'wordprocessing
                Dim success As Boolean = False
                wpFilePath = ""
                Try
                    Cursor.Current = Cursors.WaitCursor

                    Select Case PrintType
                        Case Enums.SystemDocumentType.JobImportLetters
                            Dim dt As DataTable = CType(Me.DetailsToPrint, ArrayList).Item(0)
                            Dim engineerVisit As EngineerVisits.EngineerVisit = Nothing
                            If CType(Me.DetailsToPrint, ArrayList).Count > 1 Then
                                engineerVisit = CType(Me.DetailsToPrint, ArrayList).Item(1)
                            End If
                            Dim r As DataRow = dt.Rows(0)
                            Dim job As New Jobs.Job

                            job = DB.Job.Job_Get(r("JobID"))
                            Dim visitAmount As Integer = DB.EngineerVisits.EngineerVisits_Get_All_JobID(CInt(r("JobID"))).Count
                            Dim letter1 As Boolean = IIf(visitAmount > 1, False, True)
                            success = GenerateJobLetter(dt.Rows(0), job, letter1, Nothing, engineerVisit)
                            If Not success Then Throw New Exception
                            'mark letter as completed in dbf
                            If letter1 Then
                                success = DB.JobImports.JobImport_Update_Letter1(r, job)
                            Else
                                success = DB.JobImports.JobImport_Update_Letter2(r, job)
                            End If
                            If Not success Then Throw New Exception
                    End Select
                Catch ex As Exception
                    success = False
                    ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Cursor.Current = Cursors.Default
                End Try
                Return wpFilePath
            End Function

            Private Sub PrintMultiDocs(Optional ByVal MinsPerDayIn As Integer = 550, Optional ByVal CustomerID As Integer = Nothing, Optional ByVal LetterCreationDate As DateTime = Nothing)
                '  Dim DetailsToPrint As String = ""
                Dim success As Boolean = False
                Dim filePath As String = ""

                Select Case PrintType
                    Case Enums.SystemDocumentType.GSRBatch

#Region "Batch GSR"

                        Try
                            LSRErrors.Clear()
                            Dim folderToSaveTo As New FolderBrowserDialog
                            folderToSaveTo.ShowDialog()
                            If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                                Exit Sub
                            Else
                                filePath = folderToSaveTo.SelectedPath & "\" &
                                    DocumentName & Strings.Format(Now, "ddMMMyyyyHHmmss") & ".docx"
                            End If

                            Dim fullDocument As New List(Of Byte())

                            Dim dr() As DataRow = CType(Me.DetailsToPrint, ArrayList).Item(0)
                            For Each r As DataRow In dr
                                Dim engineerVisitId As Integer = Helper.MakeIntegerValid(r("EngineerVisitID"))
                                Dim jobNumber As String = Helper.MakeStringValid(r("JobNumber"))
                                success = PrintGSR(engineerVisitId, fullDocument, jobNumber)
                            Next

                            If success Then
                                If fullDocument.Count > 0 Then
                                    File.WriteAllBytes(filePath, PrintHelper.CombineDocs(fullDocument))

                                    PrintHelper.RemoveSpacingInDoc(filePath)
                                    If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor) Then filePath = PrintHelper.LockFile(filePath, True)
                                End If
                            End If

                            If LSRErrors.Count > 0 Then
                                Dim errors As New List(Of String)
                                For Each lsrError As LSR.LSRError In LSRErrors
                                    With lsrError
                                        errors.Add("Job Number: " & .JobNumber & " | Visit Date: " & .VisitDate &
                                                   " | Engineer:  " & .Engineer & " | EngineerVisitID:  " & .EngineerVisitID)
                                    End With
                                Next
                                ShowMessageWithDetails("Blank LSRs", "The following jobs have blank LSRs!", errors)
                            End If
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            If success Then
                                Process.Start(filePath)
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.ServiceLetters

#Region "Service Letters"

                        Dim folderName As String = "C:\"

                        Try

                            Dim obj As Object
                            Dim t As System.Type

                            ' Get the ProgID for Word
                            t = System.Type.GetTypeFromProgID("Word.Application", True)

                            obj = System.Activator.CreateInstance(t, True)

                            MsWordApp = CType(obj, Word.Application)

                            MessageFilter.Register()

                            'WordApp = New Word.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False

                            folderName = TheSystem.Configuration.DocumentsLocation & "ServiceLetters\ServiceLetters" & Strings.Format(Now, "ddMMyyHHmm") & "\"
                            If System.IO.Directory.Exists(folderName) = False Then
                                System.IO.Directory.CreateDirectory(folderName)
                            End If

                            filePath = folderName & "ServiceLetters1_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc"

                            Dim Letter1Doc As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetter.dot")
                            Dim Letter2Doc As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetter.dot")
                            Dim Letter2HandLetters As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetter.dot")
                            '  WordDoc = WordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetter.dot")
                            Dim Letter3Doc As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetter.dot")
                            Dim Letter3HandLetters As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetter.dot")

                            Letter1Doc.GrammarChecked = True
                            Letter1Doc.SpellingChecked = True

                            Letter2Doc.GrammarChecked = True
                            Letter2Doc.SpellingChecked = True

                            Letter2HandLetters.GrammarChecked = True
                            Letter2HandLetters.SpellingChecked = True

                            Letter3Doc.GrammarChecked = True
                            Letter3Doc.SpellingChecked = True

                            Letter3HandLetters.GrammarChecked = True
                            Letter3HandLetters.SpellingChecked = True

                            Dim dr() As DataRow = CType(Me.DetailsToPrint, ArrayList).Item(0)

                            'Dim AMsToDo As Integer = 0
                            'Dim AMsAssigned As Integer = 0
                            'AMsToDo = dr.Length / 2

                            Dim servicePriority As Integer = 0
                            Dim rows As Array = DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table.Select("Name = 'Service'")
                            If rows.Length = 0 Then
                                Dim oPickList As New PickLists.PickList
                                oPickList.SetName = "Service"
                                oPickList.SetEnumTypeID = CInt(Enums.PickListTypes.JOWPriority)
                                servicePriority = DB.Picklists.Insert(oPickList)
                            Else
                                servicePriority = CType(rows(0), DataRow).Item("ManagerID")
                            End If

                            Dim oWriteSolidFuels As System.IO.StreamWriter
                            oWriteSolidFuels = File.CreateText(folderName & "SolidFuels.txt")
                            oWriteSolidFuels.WriteLine("Solid Fuels Properties : ")

                            Dim oWriteWA As System.IO.StreamWriter
                            oWriteWA = File.CreateText(folderName & "WarningsAdvice.txt")
                            oWriteWA.WriteLine("Properties with Warnings/Advice : ")

                            Dim oWriteVoids As System.IO.StreamWriter
                            oWriteVoids = File.CreateText(folderName & "Voids.txt")
                            oWriteVoids.WriteLine("Voids Properties : ")

                            Dim oWriteSiteFuel As System.IO.StreamWriter
                            oWriteSiteFuel = File.CreateText(folderName & "NonGasSiteFuels.txt")
                            oWriteSiteFuel.WriteLine("Non Gas Site Fuel Properties : ")

                            Dim HighestLoops As Integer = 0

                            Try
                                Dim AMPM As String = ""
                                Dim Fuel As String = ""
                                Dim dtDays As New DataTable
                                dtDays.Columns.Add("MondayDate", GetType(DateTime))
                                dtDays.Columns.Add("TheDate", GetType(DateTime))
                                dtDays.Columns.Add("Count")
                                dtDays.Columns.Add("AM")
                                dtDays.Columns.Add("PM")
                                dtDays.Columns.Add("ApptsMinsTally")
                                dtDays.Columns.Add("Loops")

                                Dim dtLetter2AMPM As New DataTable
                                dtLetter2AMPM.Columns.Add("Date", GetType(DateTime))
                                dtLetter2AMPM.Columns.Add("Count")
                                dtLetter2AMPM.Columns.Add("AMAssigned")

                                Dim dtLetter3AMPM As New DataTable
                                dtLetter3AMPM.Columns.Add("Date", GetType(DateTime))
                                dtLetter3AMPM.Columns.Add("Count")
                                dtLetter3AMPM.Columns.Add("AMAssigned")

                                DB.LetterManager.Clear_LetterDays_Table()

                                'LETS DO DATES FIRST
                                For Each d As DataRow In dr
                                    If CustomerID = 5155 And CDate(d("LastServiceDate")) < CDate("2012-05-01 00:00:00") Then
                                        'do nothing
                                        Dim DateHolder As Date = CDate(d("LastServiceDate"))
                                    Else
                                        If d("type") = "Letter 1" Then
                                            Dim oSite As Sites.Site = DB.Sites.Get(d("SiteID"))
                                            Dim sorRows() As DataRow

                                            If oSite.CommercialDistrict = True Then
                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7008'")
                                            ElseIf oSite.SolidFuel = True Then
                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7001'")
                                            Else
                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7007'")
                                            End If

                                            Dim TimeInMins As Integer
                                            If sorRows.Length > 0 Then
                                                Dim sorRow As DataRow = sorRows(0)
                                                Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(sorRow("ScheduleOfRatesCategoryID"), sorRow("Description"), sorRow("Code"), CustomerID)
                                                Dim customerSorId As Integer = Helper.MakeIntegerValid(customerSors(0)(0))

                                                If customerSorId > 0 Then
                                                    Dim customerSor As CustomerScheduleOfRates.CustomerScheduleOfRate = DB.CustomerScheduleOfRate.Get(customerSorId)
                                                    If customerSor Is Nothing Then customerSor = New CustomerScheduleOfRates.CustomerScheduleOfRate
                                                    'Use Site SOR
                                                    TimeInMins = customerSor.TimeInMins
                                                Else
                                                    'Use System SOR
                                                    TimeInMins = sorRow("TimeInMins")
                                                End If
                                            End If

                                            If CustomerID = 5155 Then 'Waveney
                                                If CDate(d("NextVisitDate")) <= CDate("2013-05-07 00:00:00") Then
                                                    Dim NewNextVisitDate As DateTime = LetterCreationDate.AddDays(56)
                                                    d("NextVisitDate") = DateHelper.CheckBankHolidaySatOrSun(NewNextVisitDate)
                                                Else
                                                    d("NextVisitDate") = DateHelper.CheckBankHolidaySatOrSun(d("NextVisitDate"))
                                                End If
                                            Else
                                                d("NextVisitDate") = DateHelper.CheckBankHolidaySatOrSun(d("NextVisitDate"))
                                            End If

                                            Dim MaxLoops As Integer = 1

                                            Dim ApptFound As Boolean = False
                                            Do While ApptFound = False
                                                For lps As Integer = 1 To MaxLoops

                                                    If lps > HighestLoops Then HighestLoops = lps

                                                    For dow As Integer = 1 To 4
                                                        Dim dvBankHolidays As DataView = DB.TimeSlotRates.BankHolidays_GetAll
                                                        If dvBankHolidays.Table.Select("BankHolidayDate='" & DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow) & "'").Length = 0 Then
                                                            Dim theRow() As DataRow = dtDays.Select("MondayDate='" & DateHelper.GetTheMonday(d("NextVisitDate")) &
                                                                                                    "' AND TheDate='" & DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow) &
                                                                                                    "' AND Loops='" & lps & "'")
                                                            If theRow.Length = 0 Then
                                                                dtDays.Rows.Add(New Object() {DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), 1, 1, 0, TimeInMins, lps})
                                                                DB.LetterManager.Insert_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), TimeInMins, lps)
                                                                ApptFound = True
                                                                Exit For
                                                            Else
                                                                Dim ApptsMinsTally As Integer = theRow(0).Item("ApptsMinsTally")
                                                                If ApptsMinsTally <= (MinsPerDayIn / 2) Then
                                                                    theRow(0).Item("count") += 1
                                                                    theRow(0).Item("AM") += 1
                                                                    theRow(0).Item("ApptsMinsTally") += TimeInMins
                                                                    DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")),
                                                                                                             DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow),
                                                                                                             theRow(0).Item("count"), theRow(0).Item("AM"), Nothing,
                                                                                                             theRow(0).Item("ApptsMinsTally"), lps)
                                                                    ApptFound = True
                                                                    Exit For
                                                                ElseIf ApptsMinsTally > (MinsPerDayIn / 2) And ApptsMinsTally <= MinsPerDayIn Then
                                                                    theRow(0).Item("count") += 1
                                                                    theRow(0).Item("PM") += 1
                                                                    theRow(0).Item("ApptsMinsTally") += TimeInMins
                                                                    DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")),
                                                                                                             DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow),
                                                                                                             theRow(0).Item("count"), Nothing, theRow(0).Item("PM"),
                                                                                                             theRow(0).Item("ApptsMinsTally"), lps)
                                                                    ApptFound = True
                                                                    Exit For
                                                                Else
                                                                    ApptFound = False
                                                                End If
                                                            End If
                                                        Else
                                                            ApptFound = False
                                                        End If
                                                    Next

                                                    If ApptFound = False Then
                                                        Dim dvBankHolidays As DataView = DB.TimeSlotRates.BankHolidays_GetAll
                                                        Dim dow As Integer = 0
                                                        Dim ResetApptMins As Boolean = False

                                                        If dvBankHolidays.Table.Select("BankHolidayDate='" & DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow) & "'").Length = 0 Then
                                                            Dim theRow() As DataRow = dtDays.Select("MondayDate='" & DateHelper.GetTheMonday(d("NextVisitDate")) &
                                                                                                    "' AND TheDate='" & DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow) & "' AND Loops='" & lps & "'")
                                                            If theRow.Length = 0 Then
                                                                dtDays.Rows.Add(New Object() {DateHelper.GetTheMonday(d("NextVisitDate")),
                                                                                DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), 1, 1, 0, TimeInMins, lps})
                                                                DB.LetterManager.Insert_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")),
                                                                                                         DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), TimeInMins, lps)
                                                                ApptFound = True
                                                            Else
                                                                Dim ApptsMinsTally As Integer = theRow(0).Item("ApptsMinsTally")
                                                                If ApptsMinsTally <= (MinsPerDayIn / 2) Then
                                                                    theRow(0).Item("count") += 1
                                                                    theRow(0).Item("AM") += 1
                                                                    theRow(0).Item("ApptsMinsTally") += TimeInMins
                                                                    DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")),
                                                                                                             DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow),
                                                                                                             theRow(0).Item("count"), theRow(0).Item("AM"), Nothing,
                                                                                                             theRow(0).Item("ApptsMinsTally"), lps)
                                                                    ApptFound = True
                                                                ElseIf ApptsMinsTally > (MinsPerDayIn / 2) And ApptsMinsTally <= MinsPerDayIn Then
                                                                    theRow(0).Item("count") += 1
                                                                    theRow(0).Item("PM") += 1
                                                                    theRow(0).Item("ApptsMinsTally") += TimeInMins
                                                                    DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")),
                                                                                                             DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow),
                                                                                                             theRow(0).Item("count"), Nothing, theRow(0).Item("PM"),
                                                                                                             theRow(0).Item("ApptsMinsTally"), lps)
                                                                    ApptFound = True
                                                                Else
                                                                    'theRow(0).Item("ApptsMinsTally") = 0
                                                                    MaxLoops += 1
                                                                End If
                                                            End If
                                                        Else
                                                            MaxLoops += 1
                                                        End If
                                                    End If

                                                    If ApptFound Then Exit For
                                                Next
                                            Loop

                                        ElseIf d("Type") = "Letter 2" Then

                                            Dim theRow() As DataRow = dtLetter2AMPM.Select("Date='" & d("NextVisitDate") & "'")
                                            If theRow.Length = 0 Then
                                                dtLetter2AMPM.Rows.Add(New Object() {d("NextVisitDate"), 1, 0})
                                            Else
                                                theRow(0).Item("count") += 1
                                            End If
                                        ElseIf d("Type") = "Letter 3" Then

                                            Dim theRow() As DataRow = dtLetter3AMPM.Select("Date='" & d("NextVisitDate") & "'")
                                            If theRow.Length = 0 Then
                                                dtLetter3AMPM.Rows.Add(New Object() {d("NextVisitDate"), 1, 0})
                                            Else
                                                theRow(0).Item("count") += 1
                                            End If
                                        Else

                                        End If
                                    End If
                                Next d

                                Dim WordDocCopy As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection.dot")
                                Dim WordDoc2Copy As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection2.dot")
                                Dim WordDoc2HandCopy As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection2HandLetter.dot")
                                Dim WordDoc3Copy As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection3.dot")
                                Dim WordDoc3HandCopy As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection3HandLetter.dot")
                                Dim WordDoc3HandCopyCommercial As Word.Document = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection3HandLetterDistrict.dot")

                                WordDoc2Copy.GrammarChecked = True
                                WordDoc2Copy.SpellingChecked = True

                                WordDoc2HandCopy.GrammarChecked = True
                                WordDoc2HandCopy.SpellingChecked = True

                                WordDoc3Copy.GrammarChecked = True
                                WordDoc3Copy.SpellingChecked = True

                                WordDoc3HandCopy.GrammarChecked = True
                                WordDoc3HandCopy.SpellingChecked = True

                                WordDoc3HandCopyCommercial.GrammarChecked = True
                                WordDoc3HandCopyCommercial.SpellingChecked = True

                                Dim _currentJob As Jobs.Job
                                Dim theVisitDate As DateTime

                                Dim trans As SqlClient.SqlTransaction = Nothing
                                Dim con As SqlClient.SqlConnection = Nothing

                                Dim Letter1_CurrentApptDay As Integer = 1 'Zero based day of week (1 = Tuesday)
                                Dim Letter1_TodaysApptsLength As Integer = 0

                                'MAIN LOOP
                                For Each r As DataRow In dr
                                    Try
                                        If CustomerID = 5155 And CDate(r("LastServiceDate")) < CDate("2012-05-01 00:00:00") Then
                                            'do nothing
                                            Dim DateHolder As Date = CDate(r("LastServiceDate"))
                                        Else
                                            con = New SqlClient.SqlConnection(DB.ServerConnectionString)
                                            con.Open()
                                            trans = con.BeginTransaction(IsolationLevel.ReadUncommitted)

                                            Dim JobNumber As New JobNumber
                                            Select Case CustomerID
                                                Case Enums.Customer.NCC 'Norwich City Council
                                                    JobNumber = DB.Job.GetNextJobNumber(Enums.JobDefinition.SERVICE_LETTER_JOB, trans)
                                                Case Else
                                                    JobNumber = DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout, trans)
                                            End Select

                                            If r("type") = "Letter 1" Then

                                                WordDoc = Letter1Doc

                                                WordDoc.GrammarChecked = True
                                                WordDoc.SpellingChecked = True

                                                WordDocCopy.Select()
                                                MsWordApp.Selection.WholeStory()
                                                MsWordApp.Selection.Copy()
                                                WordDoc.Activate()
                                                MsWordApp.Selection.EndKey(Unit:=Word.WdUnits.wdStory)
                                                MsWordApp.Selection.Paste()

                                                Dim VisitDateHolder As Date = r("NextVisitDate")
                                                Dim PostCodeHolder As String = Sys.Helper.FormatPostcode(r("Postcode"))

                                                For Each dDay As DataRow In dtDays.Rows
                                                    If dDay("MondayDate") = DateHelper.GetTheMonday(r("NextVisitDate")) And dDay("Count") <> 0 Then
                                                        theVisitDate = dDay("TheDate")
                                                        dDay("Count") -= 1
                                                        If dDay("AM") <> 0 Then
                                                            AMPM = "AM"
                                                            dDay("AM") -= 1
                                                            DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(r("NextVisitDate")), dDay("TheDate"), dDay("Count"), dDay("AM"), Nothing, dDay("ApptsMinsTally"), dDay("Loops"))
                                                        Else
                                                            AMPM = "PM"
                                                            dDay("PM") -= 1
                                                            DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(r("NextVisitDate")), dDay("TheDate"), dDay("Count"), Nothing, dDay("PM"), dDay("ApptsMinsTally"), dDay("Loops"))
                                                        End If
                                                        Exit For
                                                    End If
                                                Next dDay

                                            ElseIf r("Type") = "Letter 2" Then

                                                WordDoc = Letter2Doc

                                                WordDoc.GrammarChecked = True
                                                WordDoc.SpellingChecked = True

                                                WordDoc2Copy.Select()
                                                MsWordApp.Selection.WholeStory()
                                                MsWordApp.Selection.Copy()
                                                WordDoc.Activate()
                                                MsWordApp.Selection.EndKey(Unit:=Word.WdUnits.wdStory)
                                                MsWordApp.Selection.Paste()

                                                theVisitDate = DateHelper.CheckBankHolidaySatOrSun(r("NextVisitDate"))

                                                Dim theRow() As DataRow = dtLetter2AMPM.Select("Date='" & r("NextVisitDate") & "'")
                                                If theRow.Length > 0 Then
                                                    If theRow(0)("AMAssigned") >= (theRow(0)("Count") / 2) Then
                                                        AMPM = "PM"
                                                    Else
                                                        AMPM = "AM"
                                                        theRow(0)("AMAssigned") += 1

                                                    End If
                                                End If

                                                MsWordApp.Selection.InsertBreak()

                                            ElseIf r("Type") = "Letter 3" Then

                                                WordDoc = Letter3Doc

                                                WordDoc.GrammarChecked = True
                                                WordDoc.SpellingChecked = True

                                                WordDoc3Copy.Select()
                                                MsWordApp.Selection.WholeStory()
                                                MsWordApp.Selection.Copy()
                                                WordDoc.Activate()
                                                MsWordApp.Selection.EndKey(Unit:=Word.WdUnits.wdStory)
                                                MsWordApp.Selection.Paste()

                                                theVisitDate = DateHelper.CheckBankHolidaySatOrSun(r("NextVisitDate"))

                                                Dim theRow() As DataRow = dtLetter3AMPM.Select("Date='" & r("NextVisitDate") & "'")
                                                If theRow.Length > 0 Then
                                                    If theRow(0)("AMAssigned") >= (theRow(0)("Count") / 2) Then
                                                        AMPM = "PM"
                                                    Else
                                                        AMPM = "AM"
                                                        theRow(0)("AMAssigned") += 1
                                                    End If
                                                End If
                                            End If

                                            success = GenerateServiceLetter(r, AMPM, theVisitDate, JobNumber.Prefix & JobNumber.JobNumber, Now)

                                            If success = True Then

                                                Dim oSite As Sites.Site = DB.Sites.Get(r("SiteID"))

                                                If r("type") = "Letter 1" Then
                                                    Letter1Doc = WordDoc
                                                ElseIf r("Type") = "Letter 2" Then
                                                    Letter2Doc = WordDoc

                                                    'HAND DELIVER LETTER
                                                    WordDoc = Letter2HandLetters

                                                    WordDoc.GrammarChecked = True
                                                    WordDoc.SpellingChecked = True

                                                    WordDoc2HandCopy.Select()
                                                    MsWordApp.Selection.WholeStory()
                                                    MsWordApp.Selection.Copy()
                                                    WordDoc.Activate()
                                                    MsWordApp.Selection.EndKey(Unit:=Word.WdUnits.wdStory)
                                                    MsWordApp.Selection.Paste()
                                                    success = GenerateServiceLetter(r, AMPM, theVisitDate, JobNumber.Prefix & JobNumber.JobNumber, Now)
                                                    Letter2HandLetters = WordDoc

                                                ElseIf r("Type") = "Letter 3" Then
                                                    Letter3Doc = WordDoc
                                                    'HAND DELIVER LETTER
                                                    WordDoc = Letter3HandLetters

                                                    WordDoc.GrammarChecked = True
                                                    WordDoc.SpellingChecked = True

                                                    If oSite.CommercialDistrict = True Then
                                                        WordDoc3HandCopyCommercial.Select()
                                                    Else
                                                        WordDoc3HandCopy.Select()
                                                    End If

                                                    MsWordApp.Selection.WholeStory()
                                                    MsWordApp.Selection.Copy()
                                                    WordDoc.Activate()
                                                    MsWordApp.Selection.EndKey(Unit:=Word.WdUnits.wdStory)
                                                    MsWordApp.Selection.Paste()
                                                    success = GenerateServiceLetter(r, AMPM, theVisitDate, JobNumber.Prefix & JobNumber.JobNumber, Now)
                                                    Letter3HandLetters = WordDoc
                                                End If

                                                If success = True Then

                                                    'CREATE JOB
                                                    _currentJob = New Jobs.Job
                                                    _currentJob.SetPropertyID = r("SiteID")
                                                    _currentJob.SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Callout)
                                                    _currentJob.SetJobTypeID = DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service and Certificate'")(0).Item("ManagerID")
                                                    _currentJob.SetStatusEnumID = CInt(Enums.JobStatus.Open)
                                                    _currentJob.SetCreatedByUserID = loggedInUser.UserID
                                                    _currentJob.SetFOC = True

                                                    _currentJob.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
                                                    _currentJob.SetPONumber = ""
                                                    _currentJob.SetQuoteID = 0
                                                    _currentJob.SetContractID = 0

                                                    '  INSERT JOB ITEM
                                                    Dim jobOfWork As New JobOfWorks.JobOfWork
                                                    jobOfWork.SetPONumber = ""
                                                    jobOfWork.SetPriority = servicePriority
                                                    If Not jobOfWork.Priority = 0 Then
                                                        jobOfWork.PriorityDateSet = Now
                                                    End If
                                                    jobOfWork.IgnoreExceptionsOnSetMethods = True

                                                    Dim sorRows() As DataRow = Nothing

                                                    If r("Type") = "Letter 1" Then
                                                        If oSite.CommercialDistrict = True Then
                                                            sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7008'")
                                                        ElseIf oSite.SolidFuel = True Then
                                                            sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7001'")
                                                        Else
                                                            sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7007'")
                                                        End If
                                                    ElseIf r("Type") = "Letter 2" Then
                                                        If oSite.CommercialDistrict = True Then
                                                            sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7008*'")
                                                        ElseIf oSite.SolidFuel = True Then
                                                            sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7001*'")
                                                        Else
                                                            sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7007*'")
                                                        End If
                                                    ElseIf r("Type") = "Letter 3" Then
                                                        If oSite.CommercialDistrict = True Then
                                                            sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7008^'")
                                                        ElseIf oSite.SolidFuel = True Then
                                                            sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7001^'")
                                                        Else
                                                            sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7007^'")
                                                        End If
                                                    End If

                                                    If sorRows.Length > 0 Then
                                                        Dim sorRow As DataRow = sorRows(0)
                                                        Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(sorRow("ScheduleOfRatesCategoryID"), sorRow("Description"), sorRow("Code"), CustomerID)
                                                        Dim customerSorId As Integer = 0
                                                        If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors(0)(0))

                                                        If Not customerSorId > 0 Then
                                                            Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                                                                .SetCode = sorRow("Code"),
                                                                .SetDescription = sorRow("Description"),
                                                                .SetPrice = sorRow("Price"),
                                                                .SetScheduleOfRatesCategoryID = sorRow("ScheduleOfRatesCategoryID"),
                                                                .SetTimeInMins = sorRow("TimeInMins"),
                                                                .SetCustomerID = CustomerID
                                                            }
                                                            customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
                                                            DB.CustomerScheduleOfRate.Delete(customerSorId)
                                                        End If

                                                        Dim jobItem As New JobItems.JobItem
                                                        jobItem.IgnoreExceptionsOnSetMethods = True
                                                        jobItem.SetSummary = sorRow("Description")
                                                        jobItem.SetQty = 1
                                                        jobItem.SetRateID = customerSorId
                                                        jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
                                                        jobOfWork.JobItems.Add(jobItem)
                                                    End If

                                                    Dim engineerVisit As New EngineerVisits.EngineerVisit
                                                    engineerVisit.IgnoreExceptionsOnSetMethods = True
                                                    engineerVisit.SetEngineerID = 0

                                                    'set site fuel in visit notes
                                                    If (r("SiteFuel") Is DBNull.Value) Then
                                                        Fuel = ""
                                                    ElseIf r("SiteFuel") = "Gas" Or r("siteFuel") = "0" Then
                                                        Fuel = ""
                                                    Else
                                                        Fuel = r("siteFuel")
                                                    End If

                                                    engineerVisit.SetNotesToEngineer = "(" & AMPM & ") - " & Fuel & " - Carry out safety inspection"

                                                    Select Case CustomerID
                                                        Case Enums.Customer.NCC 'Norwich City Council
                                                            If r("Type") = "Letter 2" Then
                                                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Take hand delivered letter and red sticker. "
                                                            ElseIf r("Type") = "Letter 3" Then
                                                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer
                                                            End If
                                                            If r("Type") <> "Letter 1" Then
                                                                engineerVisit.SetPartsToFit = True
                                                            End If
                                                        Case 5872
                                                            If r("Type") = "Letter 2" Then
                                                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Second Visit, Take hand delivered letter and Yellow Sticker. Service Expires: " & CDate(r("LastServiceDate")).AddYears(1)
                                                            ElseIf r("Type") = "Letter 3" Then
                                                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape."
                                                            End If
                                                            If r("Type") <> "Letter 1" Then
                                                                engineerVisit.SetPartsToFit = False
                                                            End If

                                                        Case 5155
                                                            Dim ChangedDate As DateTime = CDate(r("LastServiceDate")).AddYears(1)
                                                            ChangedDate = ChangedDate.AddDays(-7)
                                                            ChangedDate = DateHelper.CheckBankHolidaySatOrSun(ChangedDate)

                                                            If r("Type") = "Letter 2" Then
                                                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Second Visit, Take hand delivered letter and Red Sticker. Final Visit: " & ChangedDate
                                                            ElseIf r("Type") = "Letter 3" Then
                                                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape."
                                                            End If
                                                            If r("Type") <> "Letter 1" Then
                                                                engineerVisit.SetPartsToFit = False
                                                            End If

                                                        Case Else
                                                            If r("Type") = "Letter 2" Then
                                                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer
                                                            ElseIf r("Type") = "Letter 3" Then
                                                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer
                                                            End If
                                                            If r("Type") <> "Letter 1" Then
                                                                engineerVisit.SetPartsToFit = False
                                                            End If
                                                    End Select

                                                    engineerVisit.StartDateTime = DateTime.MinValue
                                                    engineerVisit.EndDateTime = DateTime.MinValue
                                                    engineerVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Ready_For_Schedule)
                                                    engineerVisit.DueDate = theVisitDate
                                                    engineerVisit.SetAMPM = AMPM

                                                    If r("Type") = "Letter 1" Then
                                                        engineerVisit.SetVisitNumber = 1
                                                    ElseIf r("Type") = "Letter 2" Then
                                                        engineerVisit.SetVisitNumber = 2
                                                    ElseIf r("Type") = "Letter 3" Then
                                                        engineerVisit.SetVisitNumber = 3
                                                    End If

                                                    jobOfWork.EngineerVisits.Add(engineerVisit)

                                                    If r("Type") = "Letter 3" And CustomerID <> Enums.Customer.NCC Then
                                                        jobOfWork.EngineerVisits.Add(engineerVisit)
                                                    End If

                                                    _currentJob.JobOfWorks.Add(jobOfWork)
                                                    _currentJob = DB.Job.Insert(_currentJob, trans)

                                                    'RECORD JOB/LETTER CREATION
                                                    DB.LetterManager.LetterGenerated(r("SiteID"), r("Type"), r("LastServiceDate"), _currentJob.JobID, folderName, trans)

                                                    'RECORD SOLID FUELS
                                                    If r("SolidFuel") = True Then
                                                        oWriteSolidFuels.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " &
                                                                                   r("Address3") & ", " & r("Address4") & ", " & r("Address5") & ", " &
                                                                                   Sys.Helper.FormatPostcode(r("Postcode")))
                                                    End If

                                                    'RECORD WARNINGS OR ADVICE
                                                    If r("Notes").ToString.Contains("T1WARN") Or r("Notes").ToString.Contains("T1ADVI") Or
                                                        r("Notes").ToString.Contains("T2WARN") Or r("Notes").ToString.Contains("T2ADVI") Then
                                                        oWriteWA.WriteLine(" ")
                                                        oWriteWA.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & r("Address4") & ", " &
                                                                           r("Address5") & ", " & Sys.Helper.FormatPostcode(r("Postcode")) & " NOTES : " & r("Notes"))

                                                    End If

                                                    'RECORD VOID PROPERTIES
                                                    If Helper.MakeBooleanValid(r("PropertyVoid")) = True Then
                                                        oWriteVoids.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " &
                                                                              r("Address4") & ", " & r("Address5") & ", " & Sys.Helper.FormatPostcode(r("Postcode")))

                                                    End If

                                                    'RECORD NON GAS SITE FUELS
                                                    If Not r("SiteFuel") Is DBNull.Value Then
                                                        If Not r("SiteFuel") = "Gas" Then
                                                            oWriteSiteFuel.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " &
                                                                                     r("Address4") & ", " & r("Address5") & ", " & Sys.Helper.FormatPostcode(r("Postcode")) & ", " & r("SiteFuel"))
                                                        End If
                                                    End If
                                                End If
                                            End If

                                            trans.Commit()
                                        End If
                                    Catch ex As Exception
                                        ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

                                        If Not trans Is Nothing Then
                                            trans.Rollback()
                                        End If
                                        If Not con Is Nothing Then
                                            con.Close()
                                        End If
                                    End Try
                                Next r

                                oWriteSolidFuels.Close()
                                oWriteWA.Close()
                                oWriteVoids.Close()
                                oWriteSiteFuel.Close()

                                WordDoc = Letter1Doc

                                WordDoc.GrammarChecked = True
                                WordDoc.SpellingChecked = True

                                Letter2Doc.Activate()
                                MsWordApp.Selection.WholeStory()
                                MsWordApp.Selection.Font.Name = "Arial"
                                Letter2Doc.SaveAs(folderName & "ServiceLetters2_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc")

                                Letter3Doc.Activate()
                                MsWordApp.Selection.WholeStory()
                                MsWordApp.Selection.Font.Name = "Arial"
                                Letter3Doc.SaveAs(folderName & "ServiceLetters3_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc")

                                Letter2HandLetters.Activate()
                                MsWordApp.Selection.WholeStory()
                                MsWordApp.Selection.Font.Name = "Arial"
                                Letter2HandLetters.SaveAs(folderName & "ServiceLetters2HandDeliver_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc")

                                Letter3HandLetters.Activate()
                                MsWordApp.Selection.WholeStory()
                                MsWordApp.Selection.Font.Name = "Arial"
                                Letter3HandLetters.SaveAs(folderName & "ServiceLetters3HandDeliver_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc")

                                System.Runtime.InteropServices.Marshal.ReleaseComObject(Letter2Doc)
                                Letter2Doc = Nothing
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDocCopy)
                                WordDocCopy = Nothing
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc2Copy)
                                WordDoc2Copy = Nothing
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc2HandCopy)
                                WordDoc2HandCopy = Nothing

                                System.Runtime.InteropServices.Marshal.ReleaseComObject(Letter3Doc)
                                Letter3Doc = Nothing
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc3Copy)
                                WordDoc3Copy = Nothing
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc3HandCopy)
                                WordDoc3HandCopy = Nothing
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc3HandCopyCommercial)
                                WordDoc3HandCopyCommercial = Nothing

                                WordDoc.Activate()
                            Catch ex As Exception
                                ShowMessage("Letter Generation Failed : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                            'GENERATE EXCEL REPORT
                            'GET ALL TOMORROWS LETTER 3 VISITS
                            'IS TOMORROW SAT OR SUN - THEN GET MONDAY
                            Dim tomorrow As DateTime = Strings.Format(Now.AddDays(1), "dd-MMM-yyyy") & " 00:00:00"
                            If Now.DayOfWeek = DayOfWeek.Friday Then
                                tomorrow = Strings.Format(Now.AddDays(3), "dd-MMM-yyyy") & " 00:00:00"
                            ElseIf Now.DayOfWeek = DayOfWeek.Saturday Then
                                tomorrow = Strings.Format(Now.AddDays(2), "dd-MMM-yyyy") & " 00:00:00"
                            End If

                            Dim dt3rdVisitReport As DataTable = DB.LetterManager.Letter3_TomorrowsVisit(tomorrow)
                            Dim exporter As New Exporting(dt3rdVisitReport, "3rd Visits", folderName)
                            exporter = Nothing
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            MsWordApp.Selection.WholeStory()
                            MsWordApp.Selection.Font.Name = "Arial"
                            Finalise(filePath, success)

                            MessageFilter.Revoke()

                            If success Then
                                Process.Start(folderName)

                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.ServiceLettersMK2

#Region "Service Letters MK2"

                        Dim folderName As String = "C:\"

                        Try
                            folderName = TheSystem.Configuration.DocumentsLocation & "ServiceLetters\ServiceLetters" & Strings.Format(Now, "ddMMyyHHmm") & "\"
                            Directory.CreateDirectory(folderName)
                            Dim dt As DataTable = CType(Me.DetailsToPrint, ArrayList).Item(0).table

                            Dim oWriteSolidFuels As StreamWriter
                            oWriteSolidFuels = File.CreateText(folderName & "SolidFuels.txt")
                            oWriteSolidFuels.WriteLine("Solid Fuels Properties : ")

                            Dim oWriteWA As StreamWriter
                            oWriteWA = File.CreateText(folderName & "WarningsAdvice.txt")
                            oWriteWA.WriteLine("Properties with Warnings/Advice : ")

                            Dim oWriteVoids As StreamWriter
                            oWriteVoids = File.CreateText(folderName & "Voids.txt")
                            oWriteVoids.WriteLine("Voids Properties : ")

                            Dim oWriteSiteFuel As StreamWriter
                            oWriteSiteFuel = File.CreateText(folderName & "NonGasSiteFuels.txt")
                            oWriteSiteFuel.WriteLine("Non Gas Site Fuel Properties : ")

                            Try
                                Try
                                    Dim theVisitDate As DateTime
                                    Dim Letter1_CurrentApptDay As Integer = 1 'Zero based day of week (1 = Tuesday)
                                    Dim Letter1_TodaysApptsLength As Integer = 0

                                    'MAIN LOOP
                                    Dim JustLetters As Boolean = False
                                    If dt.Columns.Contains("JobNumber") Then
                                        JustLetters = True
                                    Else
                                        dt.Columns.Add("JobNumber")
                                        dt.Columns.Add("JobID")
                                    End If

                                    Dim VisitTime As Integer = 0
                                    If dt.Select("Type = 'Letter 1' AND SendLetterTick = 1").Length > 0 Then

                                        filePath = folderName & "ServiceLetters1_" & Strings.Format(Now, "ddMMyyHHmm") & ".docx"

                                        Dim document As New List(Of Byte())
                                        Dim dr() As DataRow = (From row In dt.AsEnumerable() Where row.Field(Of String)("Type") = "Letter 1" And row.Field(Of Boolean)("SendLetterTick") = True Select row).ToArray()
                                        For Each r As DataRow In dr

                                            If Helper.MakeDateTimeValid(r("BookedDateTime")) = Nothing Then Continue For
                                            Dim VisitDateHolder As Date = r("BookedDateTime")
                                            theVisitDate = r("BookedDateTime")
                                            Dim fuel As String = ""
                                            Dim AMPM As String = Helper.MakeStringValid(r("AMPM"))
                                            Dim fuelId As Integer = 0

                                            If r.Table.Columns.Contains("FuelID") AndAlso Not IsDBNull(r("FuelID")) Then fuelId = Helper.MakeIntegerValid(r("FuelID"))
                                            Dim jobnumbers As New Jobs.Job
                                            If JustLetters = False Then
                                                jobnumbers = DB.Job.GenerateServiceLetterJob(r, CustomerID, AMPM, fuelId)
                                            Else
                                                jobnumbers.SetJobID = r("JobID")
                                                jobnumbers.SetJobNumber = r("JobNumber")
                                            End If
                                            If Not r("SiteFuel").ToString.StartsWith("&") Then
                                                success = GenerateServiceLetterMK2(r, AMPM, theVisitDate, jobnumbers.JobNumber, Now, document, jobnumbers.JobID, JustLetters)
                                                If success = True Then
                                                    'RECORD JOB/LETTER CREATION
                                                    If JustLetters = False Then
                                                        DB.LetterManager.LetterGeneratedMK2(r("SiteID"), r("Type"), r("LastServiceDate"), jobnumbers.JobID, folderName, fuelId)
                                                    End If

                                                    'RECORD SOLID FUELS
                                                    If r("SolidFuel") = True Then
                                                        oWriteSolidFuels.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")))
                                                    End If
                                                    'RECORD WARNINGS OR ADVICE
                                                    If r("Notes").ToString.Contains("T1WARN") Or r("Notes").ToString.Contains("T1ADVI") Or
                                                            r("Notes").ToString.Contains("T2WARN") Or r("Notes").ToString.Contains("T2ADVI") Then
                                                        oWriteWA.WriteLine(" ")
                                                        oWriteWA.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")) & ", " & " NOTES : " & r("Notes"))
                                                    End If
                                                    'RECORD VOID PROPERTIES
                                                    If Helper.MakeBooleanValid(r("PropertyVoid")) = True Then
                                                        oWriteVoids.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")))
                                                    End If
                                                    'RECORD NON GAS SITE FUELS
                                                    If Not r("SiteFuel") Is DBNull.Value Then
                                                        If Not r("SiteFuel") = "Gas" Then
                                                            oWriteSiteFuel.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")) & ", " & r("SiteFuel"))
                                                        End If
                                                    End If
                                                End If
                                            End If

                                        Next

                                        If document.Count > 0 Then
                                            File.WriteAllBytes(filePath, PrintHelper.CombineDocs(document))
                                        End If

                                    End If

                                    If dt.Select("Type = 'Letter 2' AND SendLetterTick = 1").Length > 0 Then
                                        filePath = folderName & "ServiceLetters2_" & Strings.Format(Now, "ddMMyyHHmmss") & ".docx"
                                        Dim document As New List(Of Byte())
                                        Dim dr() As DataRow = (From row In dt.AsEnumerable() Where row.Field(Of String)("Type") = "Letter 2" And row.Field(Of Boolean)("SendLetterTick") = True Select row).ToArray()
                                        For Each r As DataRow In dr

                                            If Helper.MakeDateTimeValid(r("BookedDateTime")) = Nothing Then Continue For
                                            Dim VisitDateHolder As Date = r("BookedDateTime")
                                            theVisitDate = r("BookedDateTime")
                                            Dim fuel As String = ""
                                            Dim AMPM As String = r("AMPM")
                                            Dim fuelId As Integer = 0
                                            If r.Table.Columns.Contains("FuelID") AndAlso Not IsDBNull(r("FuelID")) Then fuelId = Helper.MakeIntegerValid(r("FuelID"))
                                            Dim jobnumbers As New Jobs.Job
                                            If JustLetters = False Then
                                                jobnumbers = DB.Job.GenerateServiceLetterJob(r, CustomerID, AMPM, fuelId)
                                                r("JobNumber") = jobnumbers.JobNumber
                                                r("JobID") = jobnumbers.JobID
                                            Else
                                                jobnumbers.SetJobID = r("JobID")
                                                jobnumbers.SetJobNumber = r("JobNumber")
                                            End If

                                            If Not r("SiteFuel").ToString.StartsWith("&") Then
                                                success = GenerateServiceLetterMK2(r, AMPM, theVisitDate, jobnumbers.JobNumber, Now, document, jobnumbers.JobID, JustLetters)

                                                If success = True Then
                                                    'RECORD JOB/LETTER CREATION
                                                    If JustLetters = False Then
                                                        DB.LetterManager.LetterGeneratedMK2(r("SiteID"), r("Type"), r("LastServiceDate"), jobnumbers.JobID, folderName, fuelId)
                                                    End If

                                                    'RECORD SOLID FUELS
                                                    If r("SolidFuel") = True Then
                                                        oWriteSolidFuels.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")))
                                                    End If
                                                    'RECORD WARNINGS OR ADVICE
                                                    If r("Notes").ToString.Contains("T1WARN") Or r("Notes").ToString.Contains("T1ADVI") Or
                                                        r("Notes").ToString.Contains("T2WARN") Or r("Notes").ToString.Contains("T2ADVI") Then
                                                        oWriteWA.WriteLine(" ")
                                                        oWriteWA.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")) & ", " & " NOTES : " & r("Notes"))
                                                    End If
                                                    'RECORD VOID PROPERTIES
                                                    If Helper.MakeBooleanValid(r("PropertyVoid")) = True Then
                                                        oWriteVoids.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")))
                                                    End If
                                                    'RECORD NON GAS SITE FUELS
                                                    If Not r("SiteFuel") Is DBNull.Value Then
                                                        If Not r("SiteFuel") = "Gas" Then
                                                            oWriteSiteFuel.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")) & ", " & r("SiteFuel"))
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Next
                                        If document.Count > 0 Then
                                            File.WriteAllBytes(filePath, PrintHelper.CombineDocs(document))
                                        End If
                                    End If

                                    If dt.Select("Type = 'Letter 3' AND SendLetterTick = 1").Length > 0 Then
                                        filePath = folderName & "ServiceLetters3_" & Strings.Format(Now, "ddMMyyHHmm") & ".docx"
                                        Dim document As New List(Of Byte())
                                        Dim dr() As DataRow = (From row In dt.AsEnumerable() Where row.Field(Of String)("Type") = "Letter 3" And row.Field(Of Boolean)("SendLetterTick") = True Select row).ToArray()

                                        For Each r As DataRow In dr
                                            If Helper.MakeDateTimeValid(r("BookedDateTime")) = Nothing Then Continue For

                                            Dim VisitDateHolder As Date = r("BookedDateTime")
                                            If r("CustomerID") = Enums.Customer.NCC Then
                                                theVisitDate = r("BookedDateTime")
                                            Else
                                                theVisitDate = r("BookedDateTime")
                                            End If

                                            Dim fuel As String = ""
                                            Dim fuelId As Integer = 0
                                            If r.Table.Columns.Contains("FuelID") AndAlso Not IsDBNull(r("FuelID")) Then fuelId = Helper.MakeIntegerValid(r("FuelID"))
                                            Dim AMPM As String = r("AMPM")
                                            Dim jobnumbers As New Jobs.Job
                                            If JustLetters = False Then
                                                jobnumbers = DB.Job.GenerateServiceLetterJob(r, CustomerID, AMPM, fuelId)

                                                r("JobNumber") = jobnumbers.JobNumber
                                                r("JobID") = jobnumbers.JobID
                                            Else
                                                jobnumbers.SetJobID = r("JobID")
                                                jobnumbers.SetJobNumber = r("JobNumber")
                                            End If

                                            If Not r("SiteFuel").ToString.StartsWith("&") Then
                                                success = GenerateServiceLetterMK2(r, AMPM, theVisitDate, jobnumbers.JobNumber, Now, document, jobnumbers.JobID, JustLetters)

                                                If success = True Then
                                                    'RECORD JOB/LETTER CREATION
                                                    If JustLetters = False Then
                                                        DB.LetterManager.LetterGeneratedMK2(r("SiteID"), r("Type"), r("LastServiceDate"), jobnumbers.JobID, folderName, fuelId)
                                                    End If

                                                    'RECORD SOLID FUELS
                                                    If r("SolidFuel") = True Then
                                                        oWriteSolidFuels.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")))
                                                    End If
                                                    'RECORD WARNINGS OR ADVICE
                                                    If r("Notes").ToString.Contains("T1WARN") Or r("Notes").ToString.Contains("T1ADVI") Or
                                                        r("Notes").ToString.Contains("T2WARN") Or r("Notes").ToString.Contains("T2ADVI") Then
                                                        oWriteWA.WriteLine(" ")
                                                        oWriteWA.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")) & " NOTES : " & r("Notes"))
                                                    End If
                                                    'RECORD VOID PROPERTIES
                                                    If Helper.MakeBooleanValid(r("PropertyVoid")) = True Then
                                                        oWriteVoids.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")))
                                                    End If
                                                    'RECORD NON GAS SITE FUELS
                                                    If Not r("SiteFuel") Is DBNull.Value Then
                                                        If Not r("SiteFuel") = "Gas" Then
                                                            oWriteSiteFuel.WriteLine(r("Name") & ", " & r("Address1") & ", " & r("Address2") & ", " & r("Address3") & ", " & Sys.Helper.FormatPostcode(r("Postcode")) & ", " & r("SiteFuel"))
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Next

                                        If document.Count > 0 Then
                                            File.WriteAllBytes(filePath, PrintHelper.CombineDocs(document))
                                        End If

                                    End If
                                Catch ex As Exception
                                    ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try

                                oWriteSolidFuels.Close()
                                oWriteWA.Close()
                                oWriteVoids.Close()
                                oWriteSiteFuel.Close()
                            Catch ex As Exception
                                ShowMessage("Letter Generation Failed : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                            'GENERATE EXCEL REPORT
                            'GET ALL TOMORROWS LETTER 3 VISITS
                            'IS TOMORROW SAT OR SUN - THEN GET MONDAY
                            Dim tomorrow As DateTime = Strings.Format(Now.AddDays(1), "dd-MMM-yyyy") & " 00:00:00"
                            If Now.DayOfWeek = DayOfWeek.Friday Then
                                tomorrow = Strings.Format(Now.AddDays(3), "dd-MMM-yyyy") & " 00:00:00"
                            ElseIf Now.DayOfWeek = DayOfWeek.Saturday Then
                                tomorrow = Strings.Format(Now.AddDays(2), "dd-MMM-yyyy") & " 00:00:00"
                            End If

                            Dim dt3rdVisitReport As DataTable = DB.LetterManager.Letter3_TomorrowsVisit(tomorrow)
                            Dim exporter As New Exporting(dt3rdVisitReport, "3rd Visits", folderName)
                            exporter = Nothing
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Finalise(filePath, success)

                            MessageFilter.Revoke()

                            If success Then
                                Process.Start(folderName)
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.ServiceLetterReport

#Region "Service Letter Report"

                        Dim folderName As String = "C:\"

                        Try
                            MsWordApp = New Word.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False

                            Dim dt As DataTable = CType(Me.DetailsToPrint, ArrayList).Item(0)

                            folderName = TheSystem.Configuration.DocumentsLocation & "ServiceLetters\ServiceLetters" & Strings.Format(Now, "ddMMyyHHmm") & "\"
                            If System.IO.Directory.Exists(folderName) = False Then
                                System.IO.Directory.CreateDirectory(folderName)
                            End If

                            Dim SiteName As String = dt.Rows(0).Item("Name")

                            filePath = folderName & SiteName & "ServiceLetters_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc"

                            Dim dr() As DataRow
                            Dim r As DataRow

                            'Print Letter 1
                            dr = dt.Select("LetterType ='Letter 1'")
                            If dr.Length > 0 Then
                                r = dr(0)
                                Select Case CustomerID
                                    Case 2846 'NCC
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection.dot")
                                    Case 5155 'Waveney
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\WDCAnnualSafetyInspection.dot")
                                    Case 4703 'Suffolk Housing
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\SuffolkAnnualSafetyInspection.dot")
                                    Case 5545 'Cambridge Housing Society
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\CHS_AnnualSafetyInspection.dot")
                                    Case 5385 'Kier
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\KierAnnualSafetyInspection.dot")
                                    Case 5853 'Hastoe
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\HastoeAnnualSafetyInspection.dot")
                                    Case 6341 'Hastoe 2
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\HastoeAnnualSafetyInspectionGBS.dot")
                                    Case 5872 'Victory
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\VHTAnnualSafetyInspection.dot")
                                    Case 6526 'TEN
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\TENAnnualSafetyInspection1.dot")
                                    Case 6561 'TEN
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\SAFAnnualSafetyInspection1.dot")

                                    Case Else
                                End Select

                                If GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")) Then
                                    MsWordApp.Selection.WholeStory()
                                    MsWordApp.Selection.Font.Name = "Arial"
                                    WordDoc.SaveAs(folderName & "ServiceLetter1_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc")
                                End If
                            End If

                            'Print Letter 2
                            dr = dt.Select("LetterType ='Letter 2'")
                            If dr.Length > 0 Then
                                r = dr(0)
                                Select Case CustomerID
                                    Case 2846 'NCC
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection2.dot")
                                    Case 5155 'Waveney
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\WDCAnnualSafetyInspection2.dot")
                                    Case 4703 'Suffolk Housing
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\SuffolkAnnualSafetyInspection2.dot")
                                    Case 5545 'Cambridge Housing Society
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\CHS_AnnualSafetyInspection2.dot")
                                    Case 5385 'Kier
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\KierAnnualSafetyInspection2.dot")
                                    Case 5853 'Hastoe
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\HastoeAnnualSafetyInspection2.dot")
                                    Case 6341 'Hastoe
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\HastoeAnnualSafetyInspection2GBS.dot")
                                    Case 5872 'Victory
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\VHTAnnualSafetyInspection2.dot")
                                    Case 6526 'TEN
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\TENAnnualSafetyInspection2.dot")
                                    Case 6561 ' SAF
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\SAFAnnualSafetyInspection2.dot")
                                    Case Else
                                End Select

                                If GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")) Then
                                    MsWordApp.Selection.WholeStory()
                                    MsWordApp.Selection.Font.Name = "Arial"
                                    WordDoc.SaveAs(folderName & "ServiceLetter2_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc")
                                End If

                                Select Case CustomerID
                                    Case 2846 'NCC
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection2HandLetter.dot")
                                    Case Else
                                End Select

                                If GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")) Then
                                    MsWordApp.Selection.WholeStory()
                                    MsWordApp.Selection.Font.Name = "Arial"
                                    WordDoc.SaveAs(folderName & "ServiceLetter2Hand_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc")
                                End If
                            End If

                            'Print Letter 3
                            dr = dt.Select("LetterType ='Letter 3'")
                            If dr.Length > 0 Then
                                r = dr(0)
                                Select Case CustomerID
                                    Case 2846 'NCC
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection3.dot")
                                    Case 5155 'Waveney
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\WDCAnnualSafetyInspection3.dot")
                                    Case 5385 'Kier
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\KierAnnualSafetyInspection3.dot")
                                    Case 5853 'Hastoe
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\HastoeAnnualSafetyInspection3.dot")
                                    Case 6341 'Hastoe
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\HastoeAnnualSafetyInspection3.dot")
                                    Case 5872 'Victory
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\VHTAnnualSafetyInspection3.dot")
                                    Case 6526 'TEN
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\TENAnnualSafetyInspection3.dot")
                                    Case 6561 'SAF
                                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\SAFAnnualSafetyInspection3.dot")
                                    Case Else
                                End Select

                                If GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")) Then
                                    MsWordApp.Selection.WholeStory()
                                    MsWordApp.Selection.Font.Name = "Arial"
                                    WordDoc.SaveAs(folderName & "ServiceLetter3_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc")
                                End If

                                If r("CommercialDistrict") = True Then
                                    Select Case CustomerID
                                        Case 2846 'NCC
                                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection3HandLetterDistrict.dot")
                                    End Select
                                Else
                                    Select Case CustomerID
                                        Case 2846 'NCC
                                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\NCCAnnualSafetyInspection3HandLetter.dot")
                                        Case Else
                                    End Select
                                End If

                                If GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")) Then
                                    MsWordApp.Selection.WholeStory()
                                    MsWordApp.Selection.Font.Name = "Arial"
                                    WordDoc.SaveAs(folderName & "ServiceLetter3Hand_" & Strings.Format(Now, "ddMMyyHHmm") & ".doc")
                                End If
                            End If

                            Dim oWriteSolidFuels As System.IO.StreamWriter
                            oWriteSolidFuels = System.IO.File.CreateText(folderName & "Summary.txt")
                            oWriteSolidFuels.WriteLine("Letter Type" & vbTab & vbTab & "Letter Created" & vbTab & vbTab & vbTab & "Due Date" & vbTab & vbTab & "AM/PM" & vbTab & vbTab & "Job Number")
                            For Each drS As DataRow In dt.Rows
                                oWriteSolidFuels.WriteLine(drS("LetterType") & vbTab & vbTab & drS("DateCreated") & vbTab & vbTab & drS("DueDate") & vbTab & vbTab & drS("AMPM") & vbTab & vbTab & drS("JobNumber"))
                            Next

                            oWriteSolidFuels.Close()

                            success = True
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            DestroyWord(True)
                            If success Then
                                Process.Start(folderName)
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.GSRDue

#Region "GSR Due"

                        Try
                            Dim dtPrinted As New DataTable
                            dtPrinted.Columns.Add("AssetID")
                            dtPrinted.Columns.Add("DateDue")

                            Dim fLastGSRReport As FRMLastGSRReport = CType(Me.DetailsToPrint, ArrayList).Item(1)
                            fLastGSRReport.MoveProgressOn()

                            Dim dv As DataView = CType(Me.DetailsToPrint, ArrayList).Item(0)
                            filePath = TheSystem.Configuration.DocumentsLocation & "GSRDueLettersCreated" & Strings.Format(Now, "ddMMyyHHmmff") & ".docx"
                            IO.File.Copy(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\BlankNp.docx", filePath)
                            Dim batch As WordprocessingDocument = WordprocessingDocument.Open(filePath, True)
                            Using (batch)

                                Dim domesticSitesAdded As New DataTable
                                domesticSitesAdded.Columns.Add("SiteID", System.Type.GetType("System.Int32"))
                                domesticSitesAdded.Columns.Add("DueDate", System.Type.GetType("System.DateTime"))

                                Dim nonDomesticCustomersAdded As New DataTable
                                nonDomesticCustomersAdded.Columns.Add("CustomerID")

                                For Each dr As DataRowView In dv
                                    If dr("CustomerID") = Enums.Customer.Domestic Then
                                        Dim domSel() As DataRow = domesticSitesAdded.Select("DueDate='" & Helper.MakeDateTimeValid(dr("DueDate")) & "' AND SiteID =" & Helper.MakeIntegerValid(dr("siteID")))
                                        If domSel.Length = 0 Then

                                            Dim selSites() As DataRow
                                            selSites = dv.Table.Select("SiteID =" & dr("siteID") & " AND DueDate='" & dr("DueDate") & "'")
                                            Dim tFilePath As String = TheSystem.Configuration.DocumentsLocation & CInt(Enums.TableNames.tblSite) & "\" & dr("SiteID") & "\ServiceReminders"
                                            Directory.CreateDirectory(tFilePath)
                                            tFilePath += "\ServiceReminder_" & Helper.MakeDateTimeValid(dr("DueDate")).ToLongDateString & ".docx"
                                            success = GenerateDomesticGSRDue(selSites, dtPrinted, tFilePath, batch)
                                            If success = True Then
                                                If Helper.MakeBooleanValid(dr("Email")) And Helper.IsEmailValid(Helper.MakeStringValid(dr("EmailAddress"))) Then
                                                    Dim email As New Emails
                                                    email.To = dr("EmailAddress")
                                                    email.BCC = EmailAddress.Coverplan
                                                    email.From = EmailAddress.Enquiries
                                                    email.Subject = "Appliance Service Reminder"
                                                    email.Body = "Dear Tenant, <br/><br/>" & vbCrLf & vbCrLf
                                                    email.Body += "Please find your service reminder attached.<br/><br/>" & vbCrLf & vbCrLf
                                                    email.Body += "Kind regards," & "<br/><br/>"
                                                    email.Body += TheSystem.Configuration.CompanyName
                                                    email.Attachments.Add(tFilePath)
                                                    email.SendMe = True
                                                    email.Send()
                                                End If
                                            End If
                                            Dim domr As DataRow = Nothing
                                            domr = domesticSitesAdded.NewRow
                                            domr("SiteID") = dr("siteID")
                                            domr("DueDate") = Helper.MakeDateTimeValid(dr("DueDate"))
                                            domesticSitesAdded.Rows.Add(domr)
                                            domesticSitesAdded.AcceptChanges()
                                        End If
                                        fLastGSRReport.MoveProgressOn()

                                    End If

                                Next dr

                                For Each dr As DataRowView In dv
                                    If Not dr("CustomerID") = Enums.Customer.Domestic Then

                                        If nonDomesticCustomersAdded.Select("CustomerID=" & dr("CustomerID")).Length = 0 Then
                                            Dim selCust() As DataRow
                                            selCust = dv.Table.Select("CustomerID=" & dr("CustomerID"))
                                            Dim tFilePath As String = TheSystem.Configuration.DocumentsLocation & CInt(Enums.TableNames.tblSite) & "\" & dr("SiteID") & "\ServiceReminders"
                                            Directory.CreateDirectory(tFilePath)
                                            tFilePath += "\ServiceReminder.docx"
                                            success = GenerateLLGSRDue(selCust, dtPrinted, tFilePath, batch)
                                            If success = True Then
                                                If Helper.MakeBooleanValid(dr("Email")) And Helper.IsEmailValid(Helper.MakeStringValid(dr("EmailAddress"))) Then
                                                    Dim email As New Emails
                                                    email.To = dr("EmailAddress")
                                                    email.BCC = EmailAddress.Coverplan
                                                    email.From = EmailAddress.Enquiries
                                                    email.Subject = "Appliance Service Reminder"
                                                    email.Body = "Dear Tenant, <br/><br/>" & vbCrLf & vbCrLf
                                                    email.Body += "Please find your service reminder attached.<br/><br/>" & vbCrLf & vbCrLf
                                                    email.Body += "Kind regards," & "<br/><br/>"
                                                    email.Body += TheSystem.Configuration.CompanyName
                                                    email.Attachments.Add(tFilePath)
                                                    email.SendMe = True
                                                    email.Send()
                                                End If
                                            End If
                                            Dim r As DataRow
                                            r = nonDomesticCustomersAdded.NewRow
                                            r("CustomerID") = dr("CustomerID")
                                            nonDomesticCustomersAdded.Rows.Add(r)
                                        End If
                                        fLastGSRReport.MoveProgressOn()
                                    End If
                                Next dr
                                For Each pr As DataRow In dtPrinted.Rows
                                    DB.EngineerVisitAssetWorkSheet.PrintedGSRLettersInsert(pr("AssetID"), pr("DateDue"))
                                Next
                            End Using
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Finalise(filePath, success)
                            If success Then
                                Process.Start(filePath)
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.ContractExpiry

#Region "Contract Expry"

                        Try
                            Dim fCMngr As FRMContractManager = CType(Me.DetailsToPrint, ArrayList).Item(1)

                            MsWordApp = New Word.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False

                            fCMngr.MoveProgressOn()

                            Dim dt As DataTable = CType(Me.DetailsToPrint, ArrayList).Item(0)
                            If System.IO.Directory.Exists(TheSystem.Configuration.DocumentsLocation & "ContractExpiryLetters") = False Then
                                System.IO.Directory.CreateDirectory(TheSystem.Configuration.DocumentsLocation & "ContractExpiryLetters")
                            End If
                            fCMngr.MoveProgressOn()

                            filePath = TheSystem.Configuration.DocumentsLocation & "ContractExpiryLetters\" & DocumentName & Strings.Format(Now, "dd-MM-yyyy HHmm") & ".doc" '"_" & dr("ContractReference") & ".doc"
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ContractExpiry.dot")
                            MsWordApp.Selection.WholeStory()
                            MsWordApp.Selection.Copy()
                            Dim i As Integer = 1
                            Dim tblIndex As Integer = 2
                            For Each dr As DataRow In dt.Rows
                                success = GenerateContractExpiry(dr, tblIndex)
                                i += 1
                                tblIndex += 2
                                If i <= dt.Rows.Count Then
                                    MsWordApp.Selection.EndKey(Unit:=Word.WdUnits.wdStory)
                                    MsWordApp.Selection.InsertBreak(Type:=Word.WdBreakType.wdPageBreak)
                                    MsWordApp.Selection.Paste()
                                End If
                                fCMngr.MoveProgressOn()
                            Next dr
                            WordDoc.SaveAs(CObj(filePath))
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc)
                            WordDoc = Nothing
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Finalise(filePath, success)
                            If success Then
                                Cursor.Current = Cursors.WaitCursor
                                Process.Start(filePath)
                                Cursor.Current = Cursors.Default
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.Invoice

#Region "Invoices"

                        Dim details As New ArrayList
                        details = CType(Me.DetailsToPrint, ArrayList)
                        Dim arLst As New ArrayList
                        arLst = CType(details.Item(0), ArrayList)

                        If details.Count > 1 Then
                            details1 = CType(details.Item(1), String)
                            details2 = CType(details.Item(2), String)
                        End If

                        Dim invoices As New ArrayList

                        For Each InvoiceID As ArrayList In arLst
                            Try
                                Dim oInvoice As Invoiceds.Invoiced = DB.Invoiced.Invoiced_Get(InvoiceID(0))
                                If oInvoice.PaidByID > 0 Then details2 = DB.Picklists.Get_One_As_Object(oInvoice.PaidByID)?.Name
                                If oInvoice.AdhocInvoiceType <> "" Then details1 = oInvoice.AdhocInvoiceType

                                filePath = TheSystem.Configuration.DocumentsLocation & DocumentName & "_" & oInvoice.InvoiceNumber & "_" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".docx"
                                Directory.CreateDirectory(Path.GetDirectoryName(filePath))

                                File.Copy(Application.StartupPath & "\Templates\Blank.docx", filePath)
                                Cursor.Current = Cursors.WaitCursor

                                Dim batch As WordprocessingDocument = WordprocessingDocument.Open(filePath, True)
                                Using batch
                                    Dim dtInvoicedLines As DataTable = DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(InvoiceID(0)).Table
                                    Dim ContractsDT As DataTable = DB.ContractOriginal.Get_NotProcessed(dtInvoicedLines.Rows(0)("ContractID")).Table
                                    ContractsDT.Columns.Add("InvoiceNumber")

                                    If ContractsDT.Rows.Count > 0 AndAlso ContractsDT.Rows(0)("InitialPaymentType").ToString.Length > 1 Then
                                        ContractsDT.Rows(0)("InvoiceNumber") = oInvoice.InvoiceNumber
                                        If Not IsDBNull(ContractsDT.Rows(0)("InvoiceNumber")) Then
                                            If IsDBNull(ContractsDT.Rows(0)("InitialPaymentType")) OrElse ContractsDT.Rows(0)("InitialPaymentType") <> "Invoice" OrElse (details1 = "DDRECEIPT") Then
                                                success = GenerateReceipt(ContractsDT.Rows(0), batch, ContractsDT.Rows(0)("RegionID") = Enums.Region.GaswayCommercial, False)
                                            Else
                                                success = GenerateContractInvoice(ContractsDT.Rows(0), batch, ContractsDT.Rows(0)("RegionID") = Enums.Region.GaswayCommercial, False)
                                            End If
                                        End If
                                    Else
                                        success = GenerateSalesInvoice(oInvoice, batch, InvoiceID(1) = Enums.Region.GaswayCommercial)
                                    End If
                                End Using
                            Catch ex As Exception
                                success = False
                                ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally

                                If IsRFT Then
                                    filePath = filePath.ToLower.Replace(".doc", ".pdf")
                                End If

                                Finalise(filePath, success, True, False)

                                invoices.Add(filePath)
                                Cursor.Current = Cursors.Default
                            End Try
                        Next InvoiceID

                        Finalise("", False, False, True)

                        For Each i As String In invoices
                            Process.Start(i)
                        Next

#End Region

                    Case Enums.SystemDocumentType.SupplierPurchaseOrder

#Region "Supplier Purchase Order"

                        Dim details As ArrayList = CType(Me.DetailsToPrint, ArrayList)
                        Dim oSite As Sites.Site = Nothing
                        Dim oWarehouse As Warehouses.Warehouse = Nothing
                        Dim oUser As Users.User = CType(details.Item(4), Users.User)
                        Dim oAdditionalCharges As DataView = CType(details.Item(7), DataView)
                        Dim isPdf As Boolean = If(CType(details.Item(8), DialogResult) = DialogResult.Yes, True, False)
                        Dim ds As DataSet = CType(details.Item(0), DataSet)

                        If Not details.Item(3) Is Nothing Then
                            oWarehouse = CType(details.Item(3), Warehouses.Warehouse)
                        End If

                        If details.Item(1) = "Site" Then
                            oSite = CType(details.Item(2), Sites.Site)
                            oWarehouse = Nothing
                        ElseIf details.Item(1) = "Warehouse" Then
                            oSite = Nothing
                            oWarehouse = CType(details.Item(2), Warehouses.Warehouse)
                        ElseIf details.Item(1) = "Van" Then
                            oSite = Nothing
                            If details.Item(2) Is Nothing Then
                                oWarehouse = Nothing
                            Else
                                oWarehouse = CType(details.Item(2), Warehouses.Warehouse)
                            End If
                        End If

                        For Each dt As DataTable In ds.Tables
                            Try
                                Dim oSupplier As Suppliers.Supplier = DB.Supplier.Supplier_Get(dt.Rows(0).Item("SupplierID"))
                                filePath = TheSystem.Configuration.DocumentsLocation & DocumentName & Strings.Format(Now, "ddMMMyyyyHHmmss") & Helper.MakeFileNameValid(oSupplier.Name) & ".docx"
                                Cursor.Current = Cursors.WaitCursor
                                success = GeneratePurchaseOrder(oSite, oWarehouse, dt, oSupplier, oUser, Helper.MakeStringValid(details.Item(5)), Helper.MakeDateTimeValid(details.Item(6)), oAdditionalCharges, filePath, isPdf)
                            Catch ex As Exception
                                success = False
                                ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally

                                If success Then
                                    If isPdf Then filePath = Path.ChangeExtension(filePath, ".pdf")
                                    Cursor.Current = Cursors.WaitCursor
                                    Process.Start(filePath)
                                    Cursor.Current = Cursors.Default
                                End If
                                Cursor.Current = Cursors.Default
                            End Try
                        Next

#End Region

                    Case Enums.SystemDocumentType.ContractOption1

#Region "Contract Option 1"

                        Try

                            Dim folderToSaveTo As New FolderBrowserDialog
                            folderToSaveTo.ShowDialog()

                            If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                                Exit Sub
                            End If
                            Cursor.Current = Cursors.WaitCursor

                            filePath = folderToSaveTo.SelectedPath & "\" & DocumentName & Strings.Format(Now, "ddMMMyyyyHHmmss") & ".docx"
                            IO.File.Copy(Application.StartupPath & "\Templates\Blank.docx", filePath)

                            Dim batch As WordprocessingDocument = WordprocessingDocument.Open(filePath, True)
                            Using (batch)
                                For Each contractId As Integer In CType(DetailsToPrint, List(Of Integer))
                                    Dim dtContracts As DataTable = DB.ContractOriginal.ProcessContract(contractId)
                                    If dtContracts Is Nothing Then Continue For
                                    Dim dr As DataRow = dtContracts.Rows(0)
                                    success = GenerateContractLetter(dr, batch)
                                Next
                            End Using
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            If success Then
                                Process.Start(filePath)
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.PartCredit

#Region "Part Credit"

                        Try
                            Dim details As New ArrayList
                            details = CType(Me.DetailsToPrint, ArrayList)

                            Dim folderToSaveTo As New FolderBrowserDialog
                            folderToSaveTo.ShowDialog()

                            If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                                Exit Sub
                            Else
                                filePath = folderToSaveTo.SelectedPath & "\" & DocumentName & Strings.Format(Now, "ddMMMyyyyHHmmss") & ".doc"
                            End If

                            MsWordApp = New Word.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False

                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\CREDIT.dot")
                            MsWordApp.Selection.WholeStory()
                            MsWordApp.Selection.Copy()

                            Dim i As Integer = 1
                            Dim tblIndex As Integer = 0
                            Dim dt As New DataTable
                            Dim detailsdt As New DataTable
                            For h As Integer = 0 To details.Count - 1
                                'Dim ds As New DataSet
                                If h = 0 Then
                                    dt = details.Item(0)
                                Else
                                    detailsdt = details.Item(h)
                                    dt.ImportRow(detailsdt.Rows(0))
                                End If
                            Next

                            DetailsToPrint = dt 'ds.Tables(0)
                            success = Credit()

                            WordDoc.SaveAs(CObj(filePath))
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc)
                            WordDoc = Nothing
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Finalise(filePath, success)
                            If success Then
                                '   Process.Start(TheSystem.Configuration.DocumentsLocation & "ContractExpiryLetters")
                                Cursor.Current = Cursors.WaitCursor
                                Process.Start(filePath)
                                Cursor.Current = Cursors.Default
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.ProForma

#Region "ProForma"

                        Dim details As New ArrayList
                        details = CType(Me.DetailsToPrint, ArrayList)

                        Dim job As New Jobs.Job
                        Dim Contract As ContractsOriginal.ContractOriginal
                        Dim cos As New ContractOriginalSites.ContractOriginalSite
                        Dim invoices As New ArrayList
                        MsWordApp = New Word.Application
                        MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                        MsWordApp.Visible = False

                        If details.Item(0) = "JOB" Then
                            job = CType(details.Item(1), Jobs.Job)
                            details1 = CType(details.Item(2), String)
                            details2 = CType(details.Item(3), String)
                            filePath = TheSystem.Configuration.DocumentsLocation & DocumentName & "_" & job.JobNumber & ".doc"
                            Cursor.Current = Cursors.WaitCursor
                            Dim Customer As Customers.Customer = DB.Customer.Customer_Get_ForSiteID(job.PropertyID) ' get the customer to check region
                            If Customer.RegionID = Enums.Region.GaswayCommercial Then
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\InvoiceGC.dot") 'use Standard GC Invoice Template
                            Else
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\Invoice.dot") 'use Standard Invoice Template
                            End If
                        ElseIf details.Item(0) = "CONTRACT" Then
                            cos = CType(details.Item(1), ContractOriginalSites.ContractOriginalSite)
                            Contract = DB.ContractOriginal.Get(cos.ContractID)
                            details1 = CType(details.Item(2), String)
                            details2 = CType(details.Item(3), String)
                            filePath = TheSystem.Configuration.DocumentsLocation & DocumentName & "_" & Contract.ContractReference & ".doc"
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\Invoice.dot") 'use Standard Invoice Template
                        End If

                        Try
                            success = GenerateProforma(job, cos)
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Finalise(filePath, success, True, False)
                            invoices.Add(filePath)
                            Cursor.Current = Cursors.Default
                        End Try

                        Finalise("", False, False, True)
                        For Each i As String In invoices
                            Process.Start(i)
                        Next

#End Region

                    Case Enums.SystemDocumentType.ProFormaFromVisit

#Region "ProForma From Visit"

                        Dim details As New ArrayList
                        details = CType(Me.DetailsToPrint, ArrayList)
                        Dim job As New Jobs.Job
                        Dim invoices As New ArrayList
                        MsWordApp = New Word.Application
                        MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                        MsWordApp.Visible = False
                        If details.Item(0) = "JOB" Then
                            job = CType(details.Item(1), Jobs.Job)      'Job Entity
                            details1 = CType(details.Item(2), String)   'Money
                            details2 = CType(details.Item(3), String)   'VAT
                            filePath = TheSystem.Configuration.DocumentsLocation & DocumentName & "_" & job.JobNumber & ".doc" ' name doc
                            Dim Customer As Customers.Customer = DB.Customer.Customer_Get_ForSiteID(job.PropertyID) ' get the customer to check region
                            If Customer.RegionID = Enums.Region.GaswayCommercial Then
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\InvoiceGC.dot") 'use Standard GC Invoice Template
                            Else
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\Invoice.dot") 'use Standard Invoice Template
                            End If
                        End If

                        Try
                            Cursor.Current = Cursors.WaitCursor
                            success = GenerateProformaFromVisit(job) 'Use FromVisit Function
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Finalise(filePath, success, True, False)
                            invoices.Add(filePath)
                            Cursor.Current = Cursors.Default
                        End Try
                        Finalise("", False, False, True)
                        For Each i As String In invoices
                            Process.Start(i) ' open Word
                        Next

#End Region

                    Case Enums.SystemDocumentType.AlphaPartCredit

#Region "Alpha Part Credit"

                        Try
                            Dim details As New ArrayList
                            details = CType(Me.DetailsToPrint, ArrayList)

                            Dim folderToSaveTo As New FolderBrowserDialog
                            folderToSaveTo.ShowDialog()

                            If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                                Exit Sub
                            Else
                                filePath = folderToSaveTo.SelectedPath & "\" & DocumentName & Strings.Format(Now, "ddMMMyyyyHHmmss") & ".doc"
                            End If

                            MsWordApp = New Word.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False

                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\AlphaReturnsForm.dot")
                            MsWordApp.Selection.WholeStory()
                            MsWordApp.Selection.Copy()

                            Dim i As Integer = 1
                            Dim tblIndex As Integer = 0
                            Dim dt As New DataTable
                            Dim detailsdt As New DataTable
                            For h As Integer = 0 To details.Count - 1
                                'Dim ds As New DataSet
                                If h = 0 Then
                                    dt = details.Item(0)
                                Else
                                    detailsdt = details.Item(h)
                                    dt.ImportRow(detailsdt.Rows(0))
                                End If
                            Next

                            DetailsToPrint = dt 'ds.Tables(0)
                            success = AlphaCredit()

                            WordDoc.SaveAs(CObj(filePath))
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc)
                            WordDoc = Nothing
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Finalise(filePath, success)
                            If success Then
                                '   Process.Start(TheSystem.Configuration.DocumentsLocation & "ContractExpiryLetters")
                                Cursor.Current = Cursors.WaitCursor
                                Process.Start(filePath)
                                Cursor.Current = Cursors.Default
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.JobImportLetters

#Region "Job Import"

                        Try
                            Dim folderToSaveTo As New FolderBrowserDialog
                            folderToSaveTo.ShowDialog()

                            If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                                Exit Sub
                            End If
                            filePath = folderToSaveTo.SelectedPath & "\" & DocumentName & Strings.Format(Now, "ddMMMyyyyHHmmss") & ".docx"
                            File.Copy(Application.StartupPath & "\Templates\BlankNp.docx", filePath)

                            Dim dt As DataTable = CType(Me.DetailsToPrint, ArrayList).Item(0).table
                            Dim scheduleJobs As Boolean = CType(Me.DetailsToPrint, ArrayList).Item(1)

                            Dim batch As WordprocessingDocument = WordprocessingDocument.Open(filePath, True)
                            Using (batch)
                                For Each r As DataRow In dt.Select("Letter1 Is Null AND Tick = 1")
                                    If IsDBNull(r("AMPM")) And scheduleJobs Then Continue For
                                    Dim job As New Jobs.Job
                                    job = DB.Job.CreateJobImportAdHocVisit(r, scheduleJobs)

                                    If Not scheduleJobs Then Continue For
                                    If job Is Nothing Then Throw New Exception
                                    success = GenerateJobLetter(r, job, True, batch)
                                    If Not success Then Throw New Exception
                                    'mark letter as completed in db
                                    success = DB.JobImports.JobImport_Update_Letter1(r, job)
                                Next
                                For Each r As DataRow In dt.Select("Letter1 Is Not Null AND Letter2 Is Null AND Tick = 1")
                                    If IsDBNull(r("AMPM")) And scheduleJobs Then Continue For
                                    Dim job As New Jobs.Job
                                    job = DB.Job.CreateJobImportAdHocVisit(r, scheduleJobs)

                                    If Not scheduleJobs Then Continue For
                                    If job Is Nothing Then Throw New Exception
                                    success = GenerateJobLetter(r, job, False, batch)
                                    If Not success Then Throw New Exception
                                    success = DB.JobImports.JobImport_Update_Letter2(r, job)
                                Next
                            End Using
                            Dim batchFilePath As String = TheSystem.Configuration.DocumentsLocation & "JobImports\BatchLetters\" & DocumentName & "_GEN_" & Strings.Format(Now, "ddMMMyyyyHHmmss") & ".docx"
                            File.Copy(filePath, batchFilePath)
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Finalise(filePath, success)
                            If success Then
                                Cursor.Current = Cursors.WaitCursor
                                Process.Start(filePath)
                                Cursor.Current = Cursors.Default
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                    Case Enums.SystemDocumentType.SalesCredit

#Region "Sales Credit"

                        Try
                            Cursor.Current = Cursors.WaitCursor
                            filePath = TheSystem.Configuration.DocumentsLocation & "\Sales Credits\" & DocumentName & "_" & CType(DetailsToPrint, DataTable).Rows(0)("InvoiceNumber").ToString & ".docx"
                            Directory.CreateDirectory(Path.GetDirectoryName(filePath))
                            filePath = FileCheck(filePath)
                            success = GenerateCredit(CType(DetailsToPrint, DataTable), filePath)
                            PrintHelper.RemoveSpacingInDoc(filePath)
                        Catch ex As Exception
                            success = False
                            ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            Finalise(filePath, success)
                            If success Then
                                Cursor.Current = Cursors.WaitCursor
                                Process.Start(filePath)
                                Cursor.Current = Cursors.Default
                            End If
                            Cursor.Current = Cursors.Default
                        End Try

#End Region

                End Select
            End Sub

            Private Sub Print()
                Dim success As Boolean = False
                Dim filePath As String = ""

                Try
                    Select Case PrintType
                        Case Enums.SystemDocumentType.DomGSR, Enums.SystemDocumentType.GSR,
                             Enums.SystemDocumentType.ASHP, Enums.SystemDocumentType.SaffUnv,
                             Enums.SystemDocumentType.PropMaint, Enums.SystemDocumentType.ComCat,
                             Enums.SystemDocumentType.ComGSR, Enums.SystemDocumentType.ServiceLetters,
                             Enums.SystemDocumentType.Analyser, Enums.SystemDocumentType.SalesCredit,
                             Enums.SystemDocumentType.SiteLetter, Enums.SystemDocumentType.ContractOption1,
                             Enums.SystemDocumentType.SVR
                        Case Else
                            If OrderID > 0 Then
                                filePath = TheSystem.Configuration.DocumentsLocation & DocumentName & Strings.Format(Now, "ddMMMyyyyHHmmss") & ".doc"
                            Else
                                Dim folderToSaveTo As New FolderBrowserDialog
                                folderToSaveTo.ShowDialog()

                                If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                                    Exit Sub
                                Else
                                    filePath = folderToSaveTo.SelectedPath & "\" & DocumentName & Strings.Format(Now, "ddMMMyyyyHHmmss") & ".doc"
                                End If
                            End If
                    End Select

                    Cursor.Current = Cursors.WaitCursor

                    Select Case PrintType
                        Case Enums.SystemDocumentType.DomGSR, Enums.SystemDocumentType.GSR,
                             Enums.SystemDocumentType.ASHP, Enums.SystemDocumentType.SaffUnv,
                             Enums.SystemDocumentType.PropMaint, Enums.SystemDocumentType.ComCat,
                             Enums.SystemDocumentType.ComGSR

                            Dim engineerVisitId As Integer = If(DetailsToPrint(0).GetType() Is GetType(EngineerVisits.EngineerVisit), DetailsToPrint(0).EngineerVisitID, DetailsToPrint(0))
                            Dim savePath As String = String.Empty
                            Dim folderToSaveTo As New FolderBrowserDialog
                            folderToSaveTo.ShowDialog()
                            If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                                Exit Sub
                            Else
                                savePath = folderToSaveTo.SelectedPath & "\" &
                                    DocumentName & Strings.Format(Now, "ddMMMyyyyHHmmss") & ".docx"
                            End If

                            Dim fullDocument As New List(Of Byte())
                            success = PrintGSR(engineerVisitId, fullDocument)

                            If success Then
                                If fullDocument.Count > 0 Then
                                    File.WriteAllBytes(savePath, PrintHelper.CombineDocs(fullDocument))
                                    PrintHelper.RemoveSpacingInDoc(savePath)
                                    If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor) Then savePath = PrintHelper.LockFile(savePath, True)
                                    Process.Start(savePath)
                                End If
                            End If

                            If PrintType = Enums.SystemDocumentType.GSR Then
                                Dim MinorElectrical As EngineerVisitAdditionals.EngineerVisitAdditional =
                                    DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(
                                    engineerVisitId, Enums.AdditionalChecksTypes.MinorWorksSingleCircuitElecCert)
                                If Not MinorElectrical Is Nothing Then
                                    ElecCertPDF(CType(DetailsToPrint(0), EngineerVisits.EngineerVisit), MinorElectrical, "Minor Works Cert")
                                End If
                                Dim engineerVisit As EngineerVisits.EngineerVisit = CType(Me.DetailsToPrint(0), EngineerVisits.EngineerVisit)
                                If engineerVisit IsNot Nothing Then
                                    Dim dvEngineerVisitDefects As DataView = CType(Me.DetailsToPrint(2), DataView)
                                    Dim drWarningNotices As DataRow() = (From x In dvEngineerVisitDefects.Table.AsEnumerable() Where Helper.MakeBooleanValid(x("WarningNoticeIssued")) = True Select x).ToArray()
                                    For Each drWarningNotice As DataRow In drWarningNotices
                                        WarningNoticePDF(engineerVisit, drWarningNotice, "GasWarningNotice")
                                    Next
                                End If

                            End If
                            Cursor.Current = Cursors.Default

                        Case Enums.SystemDocumentType.ServiceLetters
                            Dim dr As DataRow = DetailsToPrint(0)
                            success = GenerateServiceLetterMK2(dr, dr("AMPM"), CDate(dr("StartDateTime")), dr("JobNUmber"), Today, Nothing, dr("jobid"), True)
                            success = False
                        Case Enums.SystemDocumentType.ContractOption1
                            Dim dr As DataRow = CType(DetailsToPrint(0), DataTable).Rows(0)
                            success = GenerateContractLetter(dr)
                        Case Enums.SystemDocumentType.JobSheet
                            MsWordApp = New WD.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\WorkSheet.dot")
                            success = GenerateJobSheet(CType(Me.DetailsToPrint(0), EngineerVisits.EngineerVisit))
                        Case Enums.SystemDocumentType.QCPrint
                            MsWordApp = New WD.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False
                            success = QCPrint()
                        Case Enums.SystemDocumentType.Install
                            MsWordApp = New WD.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\Install.dot")
                            success = Install(CType(Me.DetailsToPrint(0), EngineerVisits.EngineerVisit))
                        Case Enums.SystemDocumentType.ElecMinor
                            MsWordApp = New WD.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False
                            Dim MinorElectrical As EngineerVisitAdditionals.EngineerVisitAdditional = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(Me.DetailsToPrint(0).EngineerVisitID, Enums.AdditionalChecksTypes.MinorWorksSingleCircuitElecCert)
                            Cursor.Current = Cursors.WaitCursor
                            ' new PDF method
                            ElecCertPDF((CType(Me.DetailsToPrint(0), EngineerVisits.EngineerVisit)), MinorElectrical, "Minor Works Cert")
                        Case Enums.SystemDocumentType.CommissioningChecklist
                            MsWordApp = New WD.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False
                            Cursor.Current = Cursors.WaitCursor
                            success = ComChecklist(CType(Me.DetailsToPrint(0), EngineerVisits.EngineerVisit))
                        Case Enums.SystemDocumentType.HotWorksPermit
                            Cursor.Current = Cursors.WaitCursor
                            success = GenerateHotWorksPermit(CType(Me.DetailsToPrint(0), EngineerVisits.EngineerVisit))
                        Case Enums.SystemDocumentType.SVR
                            Dim savePath As String = String.Empty
                            Dim folderToSaveTo As New FolderBrowserDialog
                            folderToSaveTo.ShowDialog()
                            If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                                Exit Sub
                            Else
                                savePath = folderToSaveTo.SelectedPath & "\" & DocumentName & Now.ToString("ddMMMyyyyHHmmss") & ".docx"
                            End If
                            Cursor.Current = Cursors.WaitCursor
                            success = SiteVisitReport(CType(Me.DetailsToPrint(0), EngineerVisits.EngineerVisit), savePath)
                            filePath = savePath
                        Case Enums.SystemDocumentType.JobContactLetter
                            MsWordApp = New WD.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\JobContactLetter.dot")
                            success = JobContactLetter(CType(Me.DetailsToPrint(0), Jobs.Job))

                        Case Enums.SystemDocumentType.SiteLetter
                            SiteID = DetailsToPrint.item(1)
                            Dim fSelectTemplate As FRMSiteLetterList = ShowForm(GetType(FRMSiteLetterList), True, Nothing)
                            If fSelectTemplate.SelectedTemplate.Length > 0 Then
                                Cursor.Current = Cursors.WaitCursor
                                Dim savePath As String = TheSystem.Configuration.DocumentsLocation & "SiteLetters\" & SiteID & "\" & fSelectTemplate.SelectedTemplate
                                Dim fileName As String = Path.GetFileNameWithoutExtension(savePath)
                                savePath = savePath.Replace(fileName, fileName & "_" & DateTime.Now.ToString("ddMMMyyyyHHmmss"))
                                Dim template As String = Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\SiteLetters\" & fSelectTemplate.SelectedTemplate
                                success = SiteLetter(template, savePath)
                                filePath = savePath
                            End If
                        Case Enums.SystemDocumentType.PartCredit
                            MsWordApp = New WD.Application
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
                            MsWordApp.Visible = False
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\CREDIT.dot")
                            success = Credit()
                        Case Enums.SystemDocumentType.SalesCredit
                            filePath = TheSystem.Configuration.DocumentsLocation & "\Sales Credits\" & DocumentName & "_" & CType(DetailsToPrint, DataTable).Rows(0)("CreditReference").ToString & ".docx"
                            Directory.CreateDirectory(Path.GetDirectoryName(filePath))
                            filePath = FileCheck(filePath)
                            success = GenerateCredit(CType(DetailsToPrint, DataTable), filePath)
                            Process.Start(filePath)
                        Case Enums.SystemDocumentType.Analyser
                            Dim dt As DataTable = CType(Me.DetailsToPrint, DataTable)
                            success = GenerateAnalyserLetter(dt)
                        Case Enums.SystemDocumentType.PaymentReceipt
                            Dim invoiceId As Integer = 0
                            invoiceId = CType(Me.DetailsToPrint, Integer)
                            Try
                                Dim oInvoice As Invoiceds.Invoiced = DB.Invoiced.Invoiced_Get(invoiceId)
                                success = GenerateSalesInvoice(oInvoice, Nothing, False)
                            Catch ex As Exception
                                success = False
                                ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        Case Enums.SystemDocumentType.Warn
                            Dim engineerVisit As EngineerVisits.EngineerVisit = CType(Me.DetailsToPrint(0), EngineerVisits.EngineerVisit)
                            If engineerVisit IsNot Nothing Then
                                Dim dvEngineerVisitDefects As DataView = CType(Me.DetailsToPrint(1), DataView)
                                Dim drWarningNotices As DataRow() = (From x In dvEngineerVisitDefects.Table.AsEnumerable() Where Helper.MakeBooleanValid(x("WarningNoticeIssued")) = True Select x).ToArray()
                                For Each drWarningNotice As DataRow In drWarningNotices
                                    WarningNoticePDF(engineerVisit, drWarningNotice, "GasWarningNotice")
                                Next
                            End If
                    End Select
                Catch ex As Exception
                    success = False
                    ShowMessage("Error printing : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Select Case PrintType
                        Case Enums.SystemDocumentType.DomGSR, Enums.SystemDocumentType.GSR,
                             Enums.SystemDocumentType.ASHP, Enums.SystemDocumentType.SaffUnv,
                             Enums.SystemDocumentType.PropMaint, Enums.SystemDocumentType.ComCat,
                             Enums.SystemDocumentType.ComGSR, Enums.SystemDocumentType.ServiceLetters,
                             Enums.SystemDocumentType.Analyser, Enums.SystemDocumentType.ContractOption1,
                             Enums.SystemDocumentType.CommissioningChecklist, Enums.SystemDocumentType.SalesCredit,
                             Enums.SystemDocumentType.HotWorksPermit, Enums.SystemDocumentType.PaymentReceipt
                        Case Else
                            If success Then
                                filePath = Finalise(filePath, success)
                                Cursor.Current = Cursors.WaitCursor
                                Process.Start(filePath)
                                Cursor.Current = Cursors.Default
                            End If
                    End Select
                    Cursor.Current = Cursors.Default
                End Try
            End Sub

            Private Function PrintGSR(ByVal engineerVisitId As Integer, ByVal fullDocument As List(Of Byte()), Optional jobNumber As String = "", Optional isSvr As Boolean = False) As Boolean
                Try
                    Dim batch As Boolean = If(String.IsNullOrEmpty(jobNumber), False, True)
                    Dim success As Boolean = False
                    Dim isBlank As Boolean = False
                    Dim goldenRule As String = String.Empty
                    Dim hasLsrHeaderLetter As Boolean = False

                    Dim oEngineerVisit As EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId)
                    Dim oSite As Sites.Site = DB.Sites.Get(oEngineerVisit.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId)

                    Dim ASHP As EngineerVisitAdditionals.EngineerVisitAdditional = Nothing
                    Dim PM As EngineerVisitAdditionals.EngineerVisitAdditional = Nothing
                    Dim SaffUnv As EngineerVisitAdditionals.EngineerVisitAdditional = Nothing
                    Dim ComCatAdd As EngineerVisitAdditionals.EngineerVisitAdditional = Nothing

                    Dim dvAdditionalWorksheet As DataView = Nothing
                    Dim comLsrList As New List(Of Integer) From {Enums.AdditionalChecksTypes.CommercialStrengthTestCP16, Enums.AdditionalChecksTypes.CommercialPurgingTestCP16,
                         Enums.AdditionalChecksTypes.CommercialSiteChecksCP17, Enums.AdditionalChecksTypes.CommercialTightnessTestCP16}

                    Dim dvFaults As DataView = DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(engineerVisitId)

                    Dim template As String = ""
                    Dim saveDir As String = TheSystem.Configuration.DocumentsLocation & CInt(Enums.TableNames.tblEngineerVisit) & "\" & oEngineerVisit.EngineerVisitID
                    Directory.CreateDirectory(saveDir)

                    If (PrintType = Enums.SystemDocumentType.GSR Or
                        PrintType = Enums.SystemDocumentType.GSRBatch) Then
                        ASHP = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet)
                        PM = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist)
                        SaffUnv = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SaffronUnventedReport)
                        ComCatAdd = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialCateringCP42)

                        dvAdditionalWorksheet = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(oEngineerVisit.EngineerVisitID)
                        Dim comWorkSheets As DataRow() = (From x In dvAdditionalWorksheet.Table.AsEnumerable() Where comLsrList.Contains(Helper.MakeIntegerValid(x("TestType"))) Select x).ToArray()
                        If comWorkSheets.Length > 0 Then
                            dvAdditionalWorksheet = New DataView(comWorkSheets.CopyToDataTable())
                        Else
                            dvAdditionalWorksheet = Nothing
                        End If

                    ElseIf PrintType = Enums.SystemDocumentType.ASHP Then
                        ASHP = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet)

                    ElseIf PrintType = Enums.SystemDocumentType.PropMaint Then
                        PM = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist)
                        GoTo ProptMain

                    ElseIf PrintType = Enums.SystemDocumentType.ComCat Then
                        ComCatAdd = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialCateringCP42)

                    ElseIf PrintType = Enums.SystemDocumentType.COMSR Or PrintType = Enums.SystemDocumentType.ComGSR Then
                        dvAdditionalWorksheet = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(oEngineerVisit.EngineerVisitID)
                        Dim comWorkSheets As DataRow() = (From x In dvAdditionalWorksheet.Table.AsEnumerable() Where comLsrList.Contains(Helper.MakeIntegerValid(x("TestType"))) Select x).ToArray()
                        If comWorkSheets.Length > 0 Then
                            dvAdditionalWorksheet = New DataView(comWorkSheets.CopyToDataTable())
                        Else
                            dvAdditionalWorksheet = Nothing
                        End If

                    ElseIf PrintType = Enums.SystemDocumentType.SaffUnv Then
                        SaffUnv = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SaffronUnventedReport)
                        GoTo SaffUnv

                    End If

                    If ((dvAdditionalWorksheet Is Nothing OrElse dvAdditionalWorksheet.Count = 0) And ASHP Is Nothing) Or
                        (PrintType = Enums.SystemDocumentType.DomGSR) Then

                        Dim gasLsrs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Gas)
                        Dim oilLsrs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Oil)
                        Dim unventedLsrs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Unvented)
                        Dim hpLsrs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.ASHP)
                        hpLsrs.Table.Merge(DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.GSHP).Table)
                        Dim comCatLsrs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.ComCat)
                        Dim hiuLsrs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.HIU)
                        Dim otherLsrs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Other)
                        otherLsrs.Table.Merge(DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Solar).Table)
                        Dim solidFuelLsrs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.SolidFuel)

                        If PrintType = Enums.SystemDocumentType.ComCat Then
                            gasLsrs = New DataView
                            oilLsrs = New DataView
                            otherLsrs = New DataView
                            unventedLsrs = New DataView
                            hpLsrs = New DataView
                            hiuLsrs = New DataView
                            solidFuelLsrs = New DataView
                        End If

                        If gasLsrs.Table.Rows.Count = 0 And oilLsrs.Table.Rows.Count = 0 And solidFuelLsrs.Table.Rows.Count = 0 And
                            otherLsrs.Table.Rows.Count = 0 And hpLsrs.Table.Rows.Count = 0 And hiuLsrs.Table.Rows.Count = 0 And
                            comCatLsrs.Table.Rows.Count = 0 And unventedLsrs.Table.Rows.Count = 0 And dvFaults.Table.Rows.Count = 0 And
                            (dvAdditionalWorksheet Is Nothing OrElse dvAdditionalWorksheet.Count = 0) And ASHP Is Nothing And
                            PM Is Nothing And SaffUnv Is Nothing And ComCatAdd Is Nothing Then
                            isBlank = True
                            success = True
                            GoTo NextLSR
                        End If

                        Dim hasOnlyDefects As Boolean = (gasLsrs.Table.Rows.Count = 0 AndAlso oilLsrs.Table.Rows.Count = 0 AndAlso
                            otherLsrs.Table.Rows.Count = 0 AndAlso hpLsrs.Table.Rows.Count = 0 AndAlso
                            hiuLsrs.Table.Rows.Count = 0 AndAlso comCatLsrs.Table.Rows.Count = 0 AndAlso
                            dvFaults.Table.Rows.Count > 0)

                        If gasLsrs.Table.Rows.Count > 0 Then
                            If oSite.CustomerID = Enums.Customer.NCC Then
                                template = Application.StartupPath & "\Templates\GSR\GSR_NCC.docx"
                            ElseIf oSite.CustomerID = Enums.Customer.WDC Then
                                template = Application.StartupPath & "\Templates\GSR\GSR_WDC.docx"
                            Else
                                template = Application.StartupPath & "\Templates\GSR\GSR.docx"
                            End If
                            Dim savePath As String = saveDir & "\GSR" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)

                            Dim printerHeader As Boolean = False
                            If Not isSvr Then
                                If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), oSite.CustomerID = Enums.Customer.NCC)
                                If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                            End If

                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, gasLsrs, template, savePath, Enums.WorksheetFuelTypes.Gas, goldenRule, fullDocument, oSite.CustomerID = Enums.Customer.NCC)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_GAS")
                            End If
                        End If

                        If oilLsrs.Table.Rows.Count > 0 Then
                            Dim savePath As String = saveDir & "\GSROil" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSROil.docx"

                            Dim printerHeader As Boolean = False
                            If Not isSvr Then
                                If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), oSite.CustomerID = Enums.Customer.NCC)
                                If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                            End If

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, oilLsrs, template, savePath, Enums.WorksheetFuelTypes.Oil, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OIL")
                            End If
                        End If

                        If otherLsrs.Table.Rows.Count > 0 Or hasOnlyDefects Then
                            Dim savePath As String = saveDir & "\GSROther" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSROther.docx"

                            Dim printerHeader As Boolean = False
                            If Not isSvr Then
                                If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), oSite.CustomerID = Enums.Customer.NCC)
                                If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                            End If

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, otherLsrs, template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER")
                            End If
                        End If

                        If solidFuelLsrs.Table.Rows.Count > 0 Then
                            Dim savePath As String = saveDir & "\GSRSolidFuel" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSRSolidFuel.docx"

                            Dim printerHeader As Boolean = False
                            If Not isSvr Then
                                If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), oSite.CustomerID = Enums.Customer.NCC)
                                If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                            End If

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, solidFuelLsrs, template, savePath, Enums.WorksheetFuelTypes.SolidFuel, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_SOLIDFUEL")
                            End If
                        End If

                        If hpLsrs.Table.Rows.Count > 0 Then
                            Dim savePath As String = saveDir & "\GSRASHPGSHP" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSRASHPGSHP.docx"

                            Dim printerHeader As Boolean = False
                            If Not isSvr Then
                                If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), oSite.CustomerID = Enums.Customer.NCC)
                                If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                            End If

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, hpLsrs, template, savePath, Enums.WorksheetFuelTypes.ASHP, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_ASHPGSHP")
                            End If
                        End If

                        If hiuLsrs.Table.Rows.Count > 0 Then
                            Dim savePath As String = saveDir & "\GSRHIU" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSRHIU.docx"

                            Dim printerHeader As Boolean = False
                            If Not isSvr Then
                                If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), oSite.CustomerID = Enums.Customer.NCC)
                                If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                            End If

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, hiuLsrs, template, savePath, Enums.WorksheetFuelTypes.HIU, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_HIU")
                            End If
                        End If

                        If unventedLsrs.Table.Rows.Count > 0 Then
                            Dim savePath As String = saveDir & "\GSRUnvented" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSRUnvented.docx"

                            Dim printerHeader As Boolean = False
                            If Not isSvr Then
                                If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), oSite.CustomerID = Enums.Customer.NCC)
                                If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                            End If

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = Unvented(oEngineerVisit, oSite, template, savePath, unventedLsrs, goldenRule, fullDocument, printerHeader)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_GSRUnvented")
                            End If
                        End If

                        If comCatLsrs.Table.Rows.Count > 0 Then
                            Dim savePath As String = saveDir & "\GSRCOMCAT2" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSRCOMCAT2.docx"

                            Dim printerHeader As Boolean = False
                            If Not isSvr Then
                                If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), oSite.CustomerID = Enums.Customer.NCC)
                                If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                            End If

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, comCatLsrs, template, savePath, Enums.WorksheetFuelTypes.Unvented, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_COMCAT2")
                            End If
                        End If

                        If Not ComCatAdd Is Nothing Then
                            Dim savePath As String = saveDir & "\GSRCOMCAT" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSRCOMCAT.docx"

                            Dim printerHeader As Boolean = False
                            If Not isSvr Then
                                If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), oSite.CustomerID = Enums.Customer.NCC)
                                If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                            End If

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = COMCAT(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument, printerHeader)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_COMCAT")
                            End If
                        End If

                    ElseIf Not ASHP Is Nothing Then
                        Dim savePath As String = saveDir & "\ASHPM" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                        savePath = FileCheck(savePath)
                        template = Application.StartupPath & "\Templates\GSR\GSRASHPM.docx"

                        Dim printerHeader As Boolean = False
                        If Not isSvr Then
                            If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), False)
                            If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                        End If

                        goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                        success = ASHPM(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument, printerHeader)

                        If success And Not batch Then
                            savePath = PrintHelper.LockFile(savePath, True)
                            GSRSave(savePath, oEngineerVisit, oSite, "LSR_ASHPM")
                        End If

                        If dvFaults.Count > 0 Then
                            savePath = saveDir & "\GSROther" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSROther.docx"

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, False, New DataView(New DataTable), template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER")
                            End If
                        End If
                    Else
                        Dim savePath As String = saveDir & "\COMSR" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                        savePath = FileCheck(savePath)
                        template = Application.StartupPath & "\Templates\GSR\GSRCOMSR.docx"

                        Dim printerHeader As Boolean = False
                        If Not isSvr Then
                            If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), False)
                            If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                        End If

                        goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                        success = COMSR(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument, printerHeader)

                        If success And Not batch Then
                            savePath = PrintHelper.LockFile(savePath, True)
                            GSRSave(savePath, oEngineerVisit, oSite, "LSR_COMSR")
                        End If

                        If (dvAdditionalWorksheet IsNot Nothing AndAlso dvAdditionalWorksheet.Count > 0) Then
                            savePath = saveDir & "\COMTANDP" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSRCOMTANDP.docx"

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = COMTANDP(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_COMTANDP")
                            End If
                        End If

                        If dvFaults.Count > 0 Then
                            savePath = saveDir & "\GSROther" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSROther.docx"

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, False, New DataView(New DataTable), template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER")
                            End If
                        End If
                    End If

ProptMain:
                    If PM IsNot Nothing Then
                        Dim savePath As String = saveDir & "\PropMain" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                        savePath = FileCheck(savePath)
                        template = Application.StartupPath & "\Templates\GSR\GSRPropMain.docx"

                        Dim printerHeader As Boolean = False
                        If Not isSvr Then
                            If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), False)
                            If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                        End If

                        goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                        success = ProptMain(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument, printerHeader)

                        If success And Not batch Then
                            savePath = PrintHelper.LockFile(savePath, True)
                            GSRSave(savePath, oEngineerVisit, oSite, "LSR_PropMain")
                        End If

                        If dvFaults.Count > 0 Then
                            savePath = saveDir & "\GSROther" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSROther.docx"

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, False, New DataView(New DataTable), template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER")
                            End If
                        End If
                    End If

SaffUnv:
                    If SaffUnv IsNot Nothing Then
                        Dim savePath As String = saveDir & "\SAFUnvASHP" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                        savePath = FileCheck(savePath)
                        template = Application.StartupPath & "\Templates\GSR\GSRUnvASHP.docx"

                        Dim printerHeader As Boolean = False
                        If Not isSvr Then
                            If Not hasLsrHeaderLetter Then printerHeader = If(batch, Helper.MakeBooleanValid(CType(Me.DetailsToPrint, ArrayList).Item(1)), False)
                            If Not hasLsrHeaderLetter Then hasLsrHeaderLetter = printerHeader
                        End If

                        goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                        success = SAFUnvented(oEngineerVisit, oSite, SaffUnv, template, savePath, goldenRule, fullDocument, printerHeader)

                        If success And Not batch Then
                            savePath = PrintHelper.LockFile(savePath, True)
                            GSRSave(savePath, oEngineerVisit, oSite, "LSR_SAFUnvASHP")
                        End If

                        If dvFaults.Count > 0 Then
                            savePath = saveDir & "\GSROther" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                            savePath = FileCheck(savePath)
                            template = Application.StartupPath & "\Templates\GSR\GSROther.docx"

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID)
                            success = GSR(oEngineerVisit, oSite, dvFaults, False, New DataView(New DataTable), template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument)

                            If success And Not batch Then
                                savePath = PrintHelper.LockFile(savePath, True)
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER")
                            End If
                        End If
                    End If
NextLSR:

                    If isBlank Then
                        Dim lsrError As New LSR.LSRError
                        With lsrError
                            .EngineerVisitID = oEngineerVisit.EngineerVisitID
                            Dim eng As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                            .Engineer = If(eng IsNot Nothing, eng.Name, "Unknown")
                            .VisitDate = oEngineerVisit.StartDateTime
                            .JobNumber = jobNumber
                        End With
                        LSRErrors.Add(lsrError)
                    End If

                    Return success
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Private Function GenerateServiceLetter(ByVal dr As DataRow, ByVal AMPM As String, ByVal VisitDate As DateTime, ByVal JobNumber As String, ByVal TheDate As DateTime) As Boolean

                Try

                    For Each wordField As System.Text.RegularExpressions.Match In GetTemplateFields(WordDoc.Content.Text)
                        Select Case wordField.Value.ToLower
                            Case "[Address1]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address1")))
                            Case "[Address2]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address2")))
                            Case "[Address3]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address3")))
                            Case "[Address4]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address4")))
                            Case "[Address5]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address5")))
                            Case "[Postcode]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(Sys.Helper.FormatPostcode(dr("Postcode"))))
                            Case "[theDate]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Strings.Format(TheDate, "dd/MM/yyyy"))
                            Case "[Date]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Strings.Format(VisitDate, "dd/MM/yyyy"))
                                '    ReplaceText(WordDoc, wordField.Value, Strings.format(Sys.Helper.MakeDateTimeValid(dr(0)("VisitDate")).AddYears(1), "dd/MM/yyyy"))
                            Case "[Name]".ToLower
                                Dim name As String = Sys.Helper.MakeStringValid(dr("Name"))
                                If name.Contains("T2") Then
                                    name = name.Substring(0, InStr(name, "T2") - 1)
                                End If
                                name = name.Replace("T1 ", "")
                                name = name.Trim
                                ReplaceText(WordDoc, wordField.Value, name)
                            Case "[AMPM]".ToLower
                                If AMPM = "AM" Then
                                    ReplaceText(WordDoc, wordField.Value, "8:00am - 1:00pm")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, "12:00pm - 5:30pm")
                                End If
                            Case "[JobRef]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(JobNumber))
                            Case "[gascharge]".ToLower
                                Dim thecutoff As DateTime = New Date(2017, 3, 31)
                                If DateDiff(DateInterval.Day, VisitDate, thecutoff) < 0 Then
                                    ReplaceText(WordDoc, wordField.Value, "£41.37")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, "£37.00")
                                End If
                            Case "[carpcharge]".ToLower
                                If DateDiff(DateInterval.Day, VisitDate, New Date(2017, 3, 31)) < 0 Then
                                    ReplaceText(WordDoc, wordField.Value, "£97.76")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, "£88.03")
                                End If

                        End Select
                    Next

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try

            End Function

            Private Function GenerateAnalyserLetter(ByVal dt As DataTable) As Boolean
                Try
                    Dim usingdoc As String = Application.StartupPath & "\Templates\FGATempAnton.docx"
                    Dim dr As DataRow = dt.Rows(0)

                    Dim byteArray As Byte() = File.ReadAllBytes(usingdoc)
                    Dim mm As MemoryStream = New MemoryStream
                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            Dim docText As String = Nothing

                            Dim sr As StreamReader = New StreamReader(wordDoc.MainDocumentPart.GetStream)
                            Using (sr)
                                docText = sr.ReadToEnd
                            End Using

                            docText = docText.Replace("[Date]", Now.ToLongDateString)
                            docText = docText.Replace("[Serial]", dr("SerialNumber"))
                            docText = docText.Replace("[Faults]", dr("Faults"))
                            docText = docText.Replace("[Username]", loggedInUser.Fullname)
                            docText = docText.Replace("[Email]", loggedInUser.EmailAddress)
                            Dim sw As StreamWriter = New StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create))
                            Using (sw)
                                sw.Write(docText)
                            End Using
                        End Using

                        Dim linkedDoc As New Documentss.Documents
                        linkedDoc.SetTableEnumID = CInt(Enums.TableNames.tblEquipment)
                        linkedDoc.SetRecordID = CInt(dr("EquipmentID"))
                        linkedDoc.SetDocumentTypeID = 205

                        Dim filePath As String = TheSystem.Configuration.DocumentsLocation &
                            CInt(Enums.TableNames.tblEquipment) & "\" & CInt(dr("EquipmentID"))
                        Directory.CreateDirectory(filePath)

                        Dim newfile As String = filePath & "\AnalyserSerialNumber" & dr("SerialNumber") & "_" &
                            DateTime.Now.ToFileTime & ".docx"
                        Dim fileStream As FileStream = New FileStream(newfile, System.IO.FileMode.CreateNew)
                        mm.Position = 0
                        Using (fileStream)
                            mm.WriteTo(fileStream)
                        End Using
                        fileStream.Close()

                        Dim openFile As Boolean = False
                        If Not Helper.MakeBooleanValid(dr("SendEmail")) Then openFile = True

                        newfile = PrintHelper.LockFile(newfile, True)

                        linkedDoc.SetNotes = ""
                        linkedDoc.SetLocation = filePath
                        linkedDoc.SetName = "Anton Sprint eVo2, Serial Number " & dr("SerialNumber")
                        linkedDoc = DB.Documents.Insert(linkedDoc, False)

                        If CBool(dr("SendEmail")) Then
                            Dim email As New Emails
                            email.To = dr("EmailAddress")
                            email.From = loggedInUser.EmailAddress
                            email.Subject = "Anton Sprint eVo2, Serial Number " & dr("SerialNumber")
                            email.Body = "Please see letter attached"
                            email.Attachments.Add(newfile)
                            email.SendMe = True
                            email.Send()
                        Else
                            Process.Start(newfile)
                        End If
                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateServiceLetterMK2(ByVal dr As DataRow, ByVal AMPM As String, ByVal VisitDate As DateTime, ByVal JobNumber As String, ByVal TheDate As DateTime,
                                                      Optional ByVal batch As List(Of Byte()) = Nothing, Optional ByVal jobid As Integer = 0, Optional ByVal justLetters As Boolean = False) As Boolean

                Dim customerId As Integer = Helper.MakeIntegerValid(dr("CustomerID"))
                Dim patchCheck As Boolean = dr.Table.Columns.Contains("PatchCheck") AndAlso Helper.MakeBooleanValid(dr("PatchCheck"))
                Dim serviceProcess As Customers.CustomerServiceProcess = DB.Customer.CustomerServiceProcess_Get_ForCustomer(customerId)
                Dim letter As String = Helper.MakeStringValid(dr("Type")).ToLower()
                Dim template As Byte() = Nothing
                Dim fileName As String = If(dr.Table.Columns.Contains("FileName") AndAlso Not String.IsNullOrEmpty(Helper.MakeStringValid(dr("FileName"))), Helper.MakeStringValid(dr("FileName")), String.Empty)
                Dim contacts As DataView = DB.Contact.Contacts_GetAll_ForLink(CInt(Enums.TableNames.tblSite), Helper.MakeIntegerValid(dr("SiteID")))
                Dim drPOC As DataRow = Nothing

                If Not String.IsNullOrEmpty(fileName) Then
                    template = TemplateHelper.ReadWordDoc(Application.StartupPath & TheSystem.Configuration.TemplateLocation & fileName)
                Else
                    If Helper.MakeIntegerValid(serviceProcess?.CustomerServiceProcessID) = 0 Then
                        If patchCheck Then
                            template = TemplateHelper.ReadWordDoc(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetters\PatchCheck.docx")
                        Else
                            template = TemplateHelper.ReadWordDoc(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetters\AnnualSafetyInspection.docx")
                        End If
                    Else
                        If patchCheck Then
                            template = serviceProcess.PatchCheckTemplate
                        Else
                            Select Case letter
                                Case "letter 1"
                                    template = serviceProcess.Template1
                                Case "letter 2"
                                    template = serviceProcess.Template2
                                Case "letter 3"
                                    template = serviceProcess.Template3
                            End Select
                        End If
                    End If
                End If

                If template Is Nothing Then
                    Throw New Exception("Unable to locate template!")
                End If

                For Each contact As DataRowView In contacts
                    If Helper.MakeBooleanValid(contact("POC")) = True Then
                        drPOC = contact.Row
                    End If
                Next

                Try
                    Dim count As Integer = If(drPOC IsNot Nothing, 2, 1)
                    For i As Integer = 0 To count - 1 Step 1
                        Dim goldenRule As String = GetDocumentGoldenRule("AnnualSafetyInspection", Helper.MakeIntegerValid(dr("SiteID")))
                        Dim byteArray As Byte() = template
                        Dim mm As MemoryStream = New MemoryStream
                        Using (mm)
                            mm.Write(byteArray, 0, byteArray.Length)
                            Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                            Using (wordDoc)

                                PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)

                                AddCompanyDetails(wordDoc, True)

                                Dim customer As Customers.Customer = DB.Customer.Customer_Get_ForSiteID(Helper.MakeIntegerValid(dr("SiteID")))
                                If customer IsNot Nothing Then PrintHelper.ReplaceText(wordDoc, "$Customer", customer.Name)
                                PrintHelper.ReplaceText(wordDoc, "$Address1", If(drPOC IsNot Nothing AndAlso Not IsDBNull(drPOC("Address1")), drPOC("Address1"), dr("Address1")))
                                PrintHelper.ReplaceText(wordDoc, "$Address2", If(drPOC IsNot Nothing AndAlso Not IsDBNull(drPOC("Address2")), drPOC("Address2"), dr("Address2")))
                                PrintHelper.ReplaceText(wordDoc, "$Address3", If(drPOC IsNot Nothing AndAlso Not IsDBNull(drPOC("Address3")), drPOC("Address3"), dr("Address3")))
                                PrintHelper.ReplaceText(wordDoc, "$Address4", String.Empty)
                                PrintHelper.ReplaceText(wordDoc, "$Address5", String.Empty)
                                PrintHelper.ReplaceText(wordDoc, "$Postcode", If(drPOC IsNot Nothing AndAlso Not IsDBNull(drPOC("Postcode")), Helper.FormatPostcode(drPOC("Postcode")), Helper.FormatPostcode(dr("Postcode"))))
                                PrintHelper.ReplaceText(wordDoc, "$TheDate", Strings.Format(TheDate, "dd/MM/yyyy"))
                                PrintHelper.ReplaceText(wordDoc, "$Date", VisitDate.ToString("dddd, dd/MM/yyyy"))
                                PrintHelper.ReplaceText(wordDoc, "$Expiry", Strings.Format(CDate(dr("LastServiceDate")).AddDays(366), "dd/MM/yyyy"))

                                Dim name As String = String.Empty
                                If (drPOC IsNot Nothing AndAlso Not IsDBNull(drPOC("FirstName"))) Then
                                    name = Helper.MakeStringValid(drPOC("Title")) & " " & Helper.MakeStringValid(drPOC("FirstName")) & " " & Helper.MakeStringValid(drPOC("LastName"))
                                End If
                                If name.Length > 0 Then name += " on behalf of "
                                name += Sys.Helper.MakeStringValid(dr("Name"))
                                If name.Contains("T2") Then
                                    name = name.Replace("T2 ", "")
                                End If
                                name = name.Replace("T1 ", "")
                                name = name.Trim
                                PrintHelper.ReplaceText(wordDoc, "$Name", StrConv(name, VbStrConv.ProperCase).Replace("&", "&amp;"))
                                If String.IsNullOrEmpty(AMPM) Then
                                    AMPM = If(VisitDate.Hour < 12, "AM", "PM")
                                End If
                                If AMPM = "AM" Then
                                    PrintHelper.ReplaceText(wordDoc, "$AMPM", "between 8:00am and 1:00pm")
                                Else
                                    PrintHelper.ReplaceText(wordDoc, "$AMPM", "between 12:00pm and 5:30pm")
                                End If
                                PrintHelper.ReplaceText(wordDoc, "$GasCharge", "£41.37")
                                PrintHelper.ReplaceText(wordDoc, "$CarpCharge", "£97.76")
                                PrintHelper.ReplaceText(wordDoc, "$JobRef", Helper.MakeStringValid(JobNumber))

                                wordDoc.MainDocumentPart.Document.Body.InsertAfter(New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})), wordDoc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            End Using

                            Dim linkedDoc As New Documentss.Documents
                            linkedDoc.SetTableEnumID = CInt(Enums.TableNames.tblJob)
                            linkedDoc.SetRecordID = jobid
                            linkedDoc.SetDocumentTypeID = 205

                            Dim filePath As String = TheSystem.Configuration.DocumentsLocation & CInt(Enums.TableNames.tblJob) & "\" & jobid
                            Directory.CreateDirectory(filePath)

                            Dim newfile As String = filePath & "\" & dr("Type") & DateTime.Now.ToString("HHmmssfff") & ".docx"
                            Dim fileStream As FileStream = New FileStream(newfile, FileMode.CreateNew)
                            mm.Position = 0
                            Using (fileStream)
                                mm.WriteTo(fileStream)
                            End Using

                            linkedDoc.SetNotes = ""
                            linkedDoc.SetLocation = filePath
                            linkedDoc = DB.Documents.Insert(linkedDoc, False)

                            If Not justLetters And DB.LetterManager.LetterGenerated_CheckToday(dr("Type"), jobid, TheDate).Rows.Count > 0 Then
                                Return True
                            End If
                            If batch IsNot Nothing Then
                                batch.Add(mm.ToArray())
                            Else
                                Process.Start(newfile)
                            End If

                            drPOC = Nothing
                        End Using
                    Next

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Public Function GenerateJobLetter(ByVal dr As DataRow, ByVal job As Jobs.Job, ByVal letter1 As Boolean,
                                              Optional ByVal batch As WordprocessingDocument = Nothing,
                                              Optional ByVal engineervisit As EngineerVisits.EngineerVisit = Nothing) As Boolean

                Dim oSite As Sites.Site = DB.Sites.Get(Helper.MakeIntegerValid(dr("SiteID")))
                Dim oJobOfWork As JobOfWorks.JobOfWork = CType(job.JobOfWorks(0), JobOfWorks.JobOfWork)
                Dim letter As Integer = 0
                If Not letter1 Then letter = 1
                Dim oEngineerVisit As EngineerVisits.EngineerVisit
                If engineervisit Is Nothing Then
                    oEngineerVisit = CType(oJobOfWork.EngineerVisits(letter), EngineerVisits.EngineerVisit)
                Else
                    oEngineerVisit = engineervisit
                End If

                Dim doc As String = String.Empty
                Dim workStream As String = Helper.MakeStringValid(dr("Type")).ToLower()
                Dim templateLocation As String = Application.StartupPath & "\Templates\Electrical\"
                Dim template As String = String.Empty

                Select Case True
                    Case workStream = "NCC-EICR".ToLower  'eicr job
                        template = If(letter1, "NCCTestingLetter1.docx", "NCCTestingLetter2.docx")
                        doc = templateLocation & template
                    Case workStream = "NCC-SURVEY-UPGRADE".ToLower, workStream = "NCC-SURVEY-REWIRE".ToLower 'rewire/upgrade job
                        template = If(letter1, "NCCElecMainLetter1.docx", "NCCElecMainLetter2.docx")
                        doc = templateLocation & template
                    Case workStream = "VHT-SMOKE".ToLower
                        doc = templateLocation & "VHTSMOKE.docx"
                    Case workStream = "VHT-REMEDIAL".ToLower
                        doc = templateLocation & "VHTRemedial.docx"
                    Case workStream = "SHS-REMEDIAL".ToLower
                        doc = templateLocation & "SHSRemedial.docx"
                    Case workStream = "FHG-REMEDIAL".ToLower
                        doc = templateLocation & "FHGRemedial.docx"
                    Case workStream = "NCC-REMEDIAL".ToLower
                        doc = templateLocation & "NCCRemedial.docx"
                    Case workStream = "VHT-EICR".ToLower
                        template = If(letter1, "VHTTestingLetter1.docx", "VHTTestingLetter2.docx")
                        doc = templateLocation & template
                    Case workStream = "SHS-EICR".ToLower
                        template = If(letter1, "SHSEicrLetter1.docx", "SHSEicrLetter2.docx")
                        doc = templateLocation & template
                    Case workStream = "FHG-EICR".ToLower
                        template = If(letter1, "FHGTestingLetter1.docx", "FHGTestingLetter2.docx")
                        doc = templateLocation & template
                End Select

                If String.IsNullOrEmpty(doc) Then
                    template = If(letter1, "NCCTestingLetter1.docx", "NCCTestingLetter2.docx")
                    doc = templateLocation & template
                End If

                Try
                    Dim goldenRule As String = GetDocumentGoldenRule(doc, Helper.MakeIntegerValid(dr("SiteID")))
                    Dim byteArray As Byte() = File.ReadAllBytes(doc)
                    Dim mm As MemoryStream = New MemoryStream

                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)

                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                            Dim name As String = StrConv(Helper.MakeStringValid(dr("Name")), VbStrConv.ProperCase).Replace("&", "&amp;").Trim()
                            If name.Length = 0 Then
                                name = "The Occupier"
                            End If
                            PrintHelper.ReplaceText(wordDoc, "[Name]", name)
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSite.Address1)
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSite.Address2)
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSite.Address3)
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode))
                            PrintHelper.ReplaceText(wordDoc, "[Letter]", Now.ToLongDateString)
                            Dim visitDate As DateTime = If(oEngineerVisit.StartDateTime <> Nothing, oEngineerVisit.StartDateTime, job.DateCreated)
                            PrintHelper.ReplaceText(wordDoc, "[Date]", visitDate.ToString("dd MMM yyyy"))
                            dr("BookedVisit") = visitDate

                            Dim timePeriod As String = String.Empty
                            timePeriod = If(visitDate.Hour < 12, "8:00am - 1:00pm", "12:00pm - 5:30pm")

                            If visitDate.Hour < 12 Then
                                PrintHelper.ReplaceText(wordDoc, "[Time]", timePeriod)
                            Else 'cant tell so all day
                                PrintHelper.ReplaceText(wordDoc, "[Time]", timePeriod)
                            End If
                            PrintHelper.ReplaceText(wordDoc, "[User]", loggedInUser.Fullname)
                            If Helper.MakeStringValid(dr("Type")).Contains("Rewire") Then 'eicr job
                                PrintHelper.ReplaceText(wordDoc, "[Type]", "electrical rewiring")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[Type]", "electrical upgrades")
                            End If
                            If batch IsNot Nothing Then
                                wordDoc.MainDocumentPart.Document.Body.InsertAfter(
                                    New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})),
                                    wordDoc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            End If
                        End Using

                        Dim linkedDoc As New Documentss.Documents
                        linkedDoc.SetTableEnumID = CInt(Enums.TableNames.tblJob)
                        linkedDoc.SetRecordID = job.JobID
                        linkedDoc.SetDocumentTypeID = 205

                        Dim filePath As String = TheSystem.Configuration.DocumentsLocation & CInt(Enums.TableNames.tblJob) & "\" & job.JobID
                        Directory.CreateDirectory(filePath)

                        Dim newfile As String = filePath & "\" & Helper.MakeStringValid(dr("Type"))
                        newfile += If(letter1, "_L1", "_L2")
                        newfile += "_" & oSite.Address1.Replace("\", "").Replace("/", "") & ".docx"

                        newfile = FileCheck(newfile)

                        Dim fileStream As FileStream = New FileStream(newfile, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                        mm.Position = 0
                        Using (fileStream)
                            mm.WriteTo(fileStream)
                        End Using

                        linkedDoc.SetNotes = ""
                        linkedDoc.SetLocation = filePath
                        linkedDoc.SetName = If(letter1, "Letter1", "Letter2")
                        linkedDoc = DB.Documents.Insert(linkedDoc, False)

                        Dim contactAttempt As New ContactAttempt
                        With contactAttempt
                            .ContactMethedID = 3
                            .LinkID = CInt(Enums.TableNames.tblJob)
                            .LinkRef = job.JobID
                            .ContactMade = Now
                            .Notes = If(letter1, "Letter 1", "Letter 2") & " Generated"
                            .ContactMadeByUserId = loggedInUser.UserID
                        End With
                        contactAttempt = DB.ContactAttempts.Insert(contactAttempt)

                        If Not batch Is Nothing Then
                            Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                            Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr("SiteID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                            Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                            mm.Position = 0

                            Using mm
                                chunk.FeedData(mm)
                            End Using

                            Dim altChunk As WP.AltChunk = New WP.AltChunk()
                            altChunk.Id = altChunkId
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            mainPart.Document.Save()
                        Else
                            wpFilePath = newfile
                        End If
                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try

            End Function

            Private Function GeneratePurchaseOrder(ByVal oSite As Sites.Site, ByVal oWarehouse As Warehouses.Warehouse, ByVal dt As DataTable, ByVal oSupplier As Suppliers.Supplier,
                                                   ByVal oUser As Users.User, ByVal poNumber As String, ByVal deadline As DateTime, ByVal dvCharges As DataView, ByVal savePath As String,
                                                   ByVal toPdf As Boolean) As Boolean

                Dim template As String = Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\Invoice\SupplierPurchaseOrder.docx"

                Try
                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream
                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)

                            AddCompanyDetails(wordDoc, True, True)

                            Dim deliveryAddress1 As String = ""
                            Dim deliveryAddress2 As String = ""
                            Dim deliveryAddress3 As String = ""
                            Dim deliveryAddress4 As String = ""
                            Dim deliveryAddress5 As String = ""
                            Dim deliveryAddressPostcode As String = ""

                            If Not oSite Is Nothing Then
                                deliveryAddress1 = oSite.Address1
                                deliveryAddress2 = oSite.Address2
                                deliveryAddress3 = oSite.Address3
                                deliveryAddress4 = oSite.Address4
                                deliveryAddress5 = oSite.Address5
                                deliveryAddressPostcode = oSite.Postcode
                            ElseIf Not oWarehouse Is Nothing Then
                                deliveryAddress1 = oWarehouse.Address1
                                deliveryAddress2 = oWarehouse.Address2
                                deliveryAddress3 = oWarehouse.Address3
                                deliveryAddress4 = oWarehouse.Address4
                                deliveryAddress5 = oWarehouse.Address5
                                deliveryAddressPostcode = oWarehouse.Postcode
                            Else
                                deliveryAddress1 = TheSystem.Configuration.CompanyName
                                deliveryAddress2 = TheSystem.Configuration.CompanyAddres1
                                deliveryAddress3 = TheSystem.Configuration.CompanyAddres2
                                deliveryAddress4 = TheSystem.Configuration.CompanyAddres3
                                deliveryAddress5 = TheSystem.Configuration.CompanyAddres4
                                deliveryAddressPostcode = TheSystem.Configuration.CompanyPostcode
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress1]", deliveryAddress1)
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress2]", deliveryAddress2)
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress3]", deliveryAddress3)
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress4]", deliveryAddress4)
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress5]", deliveryAddress5)
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryPostcode]", Helper.FormatPostcode(deliveryAddressPostcode))

                            PrintHelper.ReplaceText(wordDoc, "[Name]", oSupplier.Name)
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSupplier.Address1)
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSupplier.Address2)
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSupplier.Address3)
                            PrintHelper.ReplaceText(wordDoc, "[Address4]", oSupplier.Address4)
                            PrintHelper.ReplaceText(wordDoc, "[Address5]", oSupplier.Address5)
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSupplier.Postcode))

                            PrintHelper.ReplaceText(wordDoc, "[Date]", DateTime.Now.ToString("dd MMM yyyy"))
                            PrintHelper.ReplaceText(wordDoc, "[User]", oUser.Fullname)
                            PrintHelper.ReplaceText(wordDoc, "[OrderNumber]", poNumber)
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryDueDate]", If(deadline <> Nothing, deadline.ToString("dd MMM yyyy"), "N/A"))

                            Dim dtParts As New DataTable
                            dtParts.Columns.Add("Item")
                            dtParts.Columns.Add("Description")
                            dtParts.Columns.Add("Number")
                            dtParts.Columns.Add("Price")
                            dtParts.Columns.Add("Qty")
                            dtParts.Columns.Add("Total")
                            Dim total As Double = 0.0

                            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                                Dim index As Integer = 1
                                For Each r As DataRow In dt.Rows
                                    Dim nr As DataRow = dtParts.NewRow
                                    nr("Item") = index
                                    nr("Description") = r("Name")
                                    nr("Number") = r("Number")
                                    nr("Price") = Helper.MakeDoubleValid(r("BuyPrice")).ToString("C")
                                    nr("Qty") = r("QuantityOnOrder")
                                    nr("Total") = Helper.MakeDoubleValid(Helper.MakeDoubleValid(r("BuyPrice")) * Helper.MakeDoubleValid(r("QuantityOnOrder"))).ToString("C")
                                    total += Helper.MakeDoubleValid(Helper.MakeDoubleValid(r("BuyPrice")) * Helper.MakeDoubleValid(r("QuantityOnOrder"))).ToString("C")
                                    dtParts.Rows.Add(nr)
                                    index += 1
                                Next

                                PrintHelper.AddRowsToTable(wordDoc, "Item", dtParts, "Arial", "16")
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[Total]", total.ToString("C"))

                            Dim dtCharges As New DataTable
                            dtCharges.Columns.Add("Type")
                            dtCharges.Columns.Add("Price")

                            If dvCharges IsNot Nothing AndAlso dvCharges.Table.Rows.Count > 0 Then
                                For Each r As DataRow In dvCharges.Table.Rows
                                    Dim nr As DataRow = dtCharges.NewRow
                                    nr("Type") = r("ChargeType")
                                    nr("Price") = Helper.MakeDoubleValid(r("Amount")).ToString("C")
                                    dtCharges.Rows.Add(nr)
                                Next

                                PrintHelper.AddRowsToTable(wordDoc, "Type", dtCharges, "Arial", "16")
                            End If

                        End Using

                        savePath = FileCheck(savePath)
                        Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                        mm.Position = 0
                        Using (fileStream)
                            mm.WriteTo(fileStream)
                        End Using

                        If toPdf Then
                            savePath = PrintHelper.ToPdf(savePath)
                        End If

                        Dim linkedDoc As New Documentss.Documents
                        linkedDoc.SetTableEnumID = CInt(Enums.TableNames.tblOrder)
                        linkedDoc.SetRecordID = OrderID
                        linkedDoc.SetDocumentTypeID = 162
                        linkedDoc.SetName = Path.GetFileName(savePath)
                        linkedDoc.SetNotes = ""
                        linkedDoc.SetLocation = savePath

                        Dim cV As New Documentss.DocumentsValidator
                        cV.Validate(linkedDoc)

                        linkedDoc = DB.Documents.Insert(linkedDoc)

                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("ERROR : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Function

            Private Function GenerateJobSheet(ByVal EngineerVisit As EngineerVisits.EngineerVisit) As Boolean
                Try
                    Dim job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID)
                    ' Get the payment terms and paidby details
                    Dim jow As JobOfWorks.JobOfWork = DB.JobOfWorks.JobOfWork_Get(EngineerVisit.JobOfWorkID)

                    Dim jobOrOrderNumber As String = ""
                    Dim rowIndex As Integer = 1
                    Dim subTotal As Double = 0.0
                    Dim site As Sites.Site = DB.Sites.Get(job.PropertyID)

                    With WordDoc.Tables.Item(2)
                        With .Rows.Add()
                            .Range.Font.Bold = CInt(False)
                            .Range.Font.Size = 9
                            .Range.Borders.Item(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone
                            .Range.Borders.Item(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone
                        End With
                        rowIndex += 1

                        'Job Number /  'Order Number / Contract
                        If jow.PONumber.Length = 0 Then
                            .Cell(rowIndex, 1).Range.Text = job.JobNumber
                        Else
                            .Cell(rowIndex, 1).Range.Text = job.JobNumber & " / " & jow.PONumber
                        End If
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 1).Range)
                        .Cell(rowIndex, 3).Range.Text = site.Address1 & ", " & site.Address2 & ", " & Sys.Helper.FormatPostcode(site.Postcode)

                        Dim cou As Integer = 0
                        .Cell(rowIndex, 4).Range.Text = EngineerVisit.NotesToEngineer
                        .Cell(rowIndex, 5).Range.Text = EngineerVisit.OutcomeDetails
                        .Cell(rowIndex, 5).Range.Font.Bold = CInt(True)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 4).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 3).Range)
                    End With

                    With WordDoc.Tables.Item(1)
                        .Cell(3, 1).Range.Text = Helper.MakeStringValid(site.Name)
                        .Cell(4, 1).Range.Text = Helper.MakeStringValid(site.Address1)
                        .Cell(5, 1).Range.Text = Helper.MakeStringValid(site.Address2)
                        .Cell(6, 1).Range.Text = Helper.MakeStringValid(site.Address3)
                        .Cell(7, 1).Range.Text = Helper.MakeStringValid(site.Address4)
                        .Cell(8, 1).Range.Text = Helper.MakeStringValid(site.Address5)
                        .Cell(9, 1).Range.Text = Helper.MakeStringValid(Sys.Helper.FormatPostcode(site.Postcode))
                        .Cell(3, 5).Range.Text = ""
                        .Cell(5, 5).Range.Text = Strings.Format(EngineerVisit.StartDateTime, "dd/MM/yyyy")
                        .Cell(7, 5).Range.Text = Helper.MakeStringValid("")

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(4, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(5, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(6, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(7, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(8, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(5, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(7, 5).Range)
                    End With
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateProforma(ByVal job As Jobs.Job, ByVal cos As ContractOriginalSites.ContractOriginalSite) As Boolean
                Try
                    Dim jobnumber As String = ""

                    If DetailsToPrint.item(0) = "JOB" Then

                        jobnumber = job.JobNumber
                    Else
                        jobnumber = DB.ContractOriginal.Get(cos.ContractID).ContractReference
                    End If

                    ' Get the payment terms and paidby details
                    'LETS GET THE INVOICE LINES MADE
                    Dim jobOrOrderNumber As String = ""
                    Dim rowIndex As Integer = 1
                    Dim subTotal As Double = 0.0

                    With WordDoc.Tables.Item(2)
                        With .Rows.Add()
                            .Range.Font.Bold = CInt(False)
                            .Range.Font.Size = 9
                            .Range.Borders.Item(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone
                            .Range.Borders.Item(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone
                        End With
                        rowIndex += 1

                        'Job Number /  'Order Number / Contract
                        .Cell(rowIndex, 1).Range.Text = jobnumber
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 1).Range)
                        Select Case Helper.MakeStringValid(DetailsToPrint.item(0))
                            Case "JOB"
                                Dim site As Sites.Site = DB.Sites.Get(job.PropertyID)
                                .Cell(rowIndex, 3).Range.Text = site.Address1 & ", " & site.Address2 & ", " & Sys.Helper.FormatPostcode(site.Postcode)
                                .Cell(rowIndex, 4).Range.Text = details1

                                .Cell(rowIndex, 5).Range.Text = Strings.Format(CDbl(details2), "C")
                                .Cell(rowIndex, 5).Range.Font.Bold = CInt(True)
                                subTotal += CDbl(details2)

                                System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 3).Range)
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 4).Range)
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 5).Range)

                            Case "CONTRACT"
                                Dim site As Sites.Site = DB.Sites.Get(cos.PropertyID)
                                .Cell(rowIndex, 3).Range.Text = site.Address1 & ", " & site.Address2 & ", " & Sys.Helper.FormatPostcode(site.Postcode)
                                .Cell(rowIndex, 4).Range.Text = details1
                                .Cell(rowIndex, 5).Range.Text = Strings.Format(CDbl(details2), "C")
                                subTotal += Helper.MakeDoubleValid(details2)

                                System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 3).Range)
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 4).Range)
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 5).Range)
                        End Select
                    End With

                    Dim VATRate As Decimal = Sys.Helper.MakeDoubleValid(DetailsToPrint.item(4))
                    Dim VATRateDecimal As Decimal = VATRate / 100

                    '***********************************************************************************
                    'REST OF THE DOCUMENT

                    With WordDoc.Tables.Item(1)
                        .Cell(1, 1).Range.Text = Helper.MakeStringValid("PRO-FORMA")

                        With WordDoc.Tables.Item(3)
                            .Cell(2, 1).Range.Text = "PRO-FORMA"
                            .Cell(3, 1).Range.Text = "This is NOT a VAT Invoice"
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(2, 1).Range)
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 1).Range)
                        End With

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(1, 1).Range)
                    End With

                    Dim dtinvoicedetails As DataTable = DB.Invoiced.InvoiceDetails_Get_InvoiceToBeRaisedID(DetailsToPrint.item(5)).Table

                    With WordDoc.Tables.Item(1)
                        .Cell(3, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("SiteName"))
                        .Cell(4, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address1"))
                        .Cell(5, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address2"))
                        .Cell(6, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address3"))
                        .Cell(7, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address4"))
                        .Cell(8, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address5"))
                        .Cell(9, 1).Range.Text = Helper.MakeStringValid(Sys.Helper.FormatPostcode(dtinvoicedetails.Rows(0).Item("postcode")))
                        .Cell(3, 5).Range.Text = ""
                        .Cell(5, 5).Range.Text = Strings.Format(Today, "dd/MM/yyyy")
                        .Cell(7, 5).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("AccountNumber"))

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(4, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(5, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(6, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(7, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(8, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(5, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(7, 5).Range)
                    End With

                    With WordDoc.Tables.Item(3)
                        .Cell(2, 5).Range.Text = Strings.Format(subTotal, "C")
                        .Cell(3, 5).Range.Text = Strings.Format(subTotal * VATRateDecimal, "C")
                        .Cell(4, 5).Range.Text = Strings.Format((subTotal * VATRateDecimal) + subTotal, "C")

                        With .Rows
                            .WrapAroundText = True
                            .HorizontalPosition = Word.WdTablePosition.wdTableLeft
                            .RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn
                            .DistanceLeft = MsWordApp.CentimetersToPoints(0.32)
                            .DistanceRight = MsWordApp.CentimetersToPoints(0.32)
                            .VerticalPosition = Word.WdTablePosition.wdTableBottom
                            .RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin
                            .DistanceTop = MsWordApp.CentimetersToPoints(0)
                            .DistanceBottom = MsWordApp.CentimetersToPoints(0)
                            .AllowOverlap = False
                        End With

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(2, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(4, 5).Range)

                    End With
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateProformaFromVisit(ByVal job As Jobs.Job) As Boolean
                Try
                    Dim jobnumber As String = ""

                    If DetailsToPrint.item(0) = "JOB" Then

                        jobnumber = job.JobNumber
                    Else
                        '  jobnumber = DB.ContractOriginal.Get(cos.ContractID).ContractReference
                    End If

                    ' Get the payment terms and paidby details
                    'LETS GET THE INVOICE LINES MADE
                    Dim jobOrOrderNumber As String = ""
                    Dim rowIndex As Integer = 1
                    Dim subTotal As Double = 0.0

                    Dim sites As Sites.Site = DB.Sites.Get(job.PropertyID)
                    Dim siteHO As Sites.Site = DB.Sites.Get(job.PropertyID)

                    If Not sites.CustomerID = Enums.Customer.Domestic Then
                        siteHO = DB.Sites.Get(sites.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq)
                    End If

                    With WordDoc.Tables.Item(2)
                        With .Rows.Add()
                            .Range.Font.Bold = CInt(False)
                            .Range.Font.Size = 9
                            .Range.Borders.Item(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone
                            .Range.Borders.Item(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone
                        End With
                        rowIndex += 1

                        'Job Number /
                        .Cell(rowIndex, 1).Range.Text = jobnumber
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 1).Range)
                        .Cell(rowIndex, 3).Range.Text = sites.Address1 & ", " & sites.Address2 & ", " & Sys.Helper.FormatPostcode(sites.Postcode)
                        .Cell(rowIndex, 4).Range.Text = details1
                        .Cell(rowIndex, 5).Range.Text = Strings.Format(CDbl(details2), "C")
                        .Cell(rowIndex, 5).Range.Font.Bold = CInt(True)
                        subTotal += CDbl(details2)

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 3).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 4).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(rowIndex, 5).Range)
                    End With

                    Dim customer As Customers.Customer = DB.Customer.Customer_Get(sites.CustomerID)
                    Dim VATRate As Decimal = Sys.Helper.MakeDoubleValid(DetailsToPrint.item(4))
                    Dim VATRateDecimal As Decimal = VATRate / 100

                    '***********************************************************************************
                    'REST OF THE DOCUMENT

                    With WordDoc.Tables.Item(1)
                        .Cell(1, 1).Range.Text = Helper.MakeStringValid("PRO-FORMA")

                        With WordDoc.Tables.Item(3)
                            .Cell(2, 1).Range.Text = "PRO-FORMA"
                            .Cell(3, 1).Range.Text = "This is NOT a VAT Invoice"
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(2, 1).Range)
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 1).Range)
                        End With

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(1, 1).Range)
                    End With

                    With WordDoc.Tables.Item(1)
                        .Cell(3, 1).Range.Text = Helper.MakeStringValid(siteHO.Name)
                        .Cell(4, 1).Range.Text = Helper.MakeStringValid(siteHO.Address1)
                        .Cell(5, 1).Range.Text = Helper.MakeStringValid(siteHO.Address2)
                        .Cell(6, 1).Range.Text = Helper.MakeStringValid(siteHO.Address3)
                        .Cell(7, 1).Range.Text = Helper.MakeStringValid(siteHO.Address4)
                        .Cell(8, 1).Range.Text = Helper.MakeStringValid(siteHO.Address5)
                        .Cell(9, 1).Range.Text = Helper.MakeStringValid(Sys.Helper.FormatPostcode(siteHO.Postcode))
                        .Cell(3, 5).Range.Text = ""
                        .Cell(5, 5).Range.Text = Strings.Format(Today, "dd/MM/yyyy")
                        .Cell(7, 5).Range.Text = Helper.MakeStringValid(customer.AccountNumber)

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(4, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(5, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(6, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(7, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(8, 1).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(5, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(7, 5).Range)
                    End With

                    With WordDoc.Tables.Item(3)
                        .Cell(2, 5).Range.Text = Strings.Format(subTotal, "C")
                        .Cell(3, 5).Range.Text = Strings.Format(subTotal * VATRateDecimal, "C")
                        .Cell(4, 5).Range.Text = Strings.Format((subTotal * VATRateDecimal) + subTotal, "C")

                        With .Rows
                            .WrapAroundText = True
                            .HorizontalPosition = Word.WdTablePosition.wdTableLeft
                            .RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn
                            .DistanceLeft = MsWordApp.CentimetersToPoints(0.32)
                            .DistanceRight = MsWordApp.CentimetersToPoints(0.32)
                            .VerticalPosition = Word.WdTablePosition.wdTableBottom
                            .RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin
                            .DistanceTop = MsWordApp.CentimetersToPoints(0)
                            .DistanceBottom = MsWordApp.CentimetersToPoints(0)
                            .AllowOverlap = False
                        End With

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(2, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(3, 5).Range)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(.Cell(4, 5).Range)
                    End With
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function QCPrint() As Boolean
                Select Case Helper.MakeIntegerValid(DetailsToPrint(1))
                    Case CInt(Enums.AdditionalChecksTypes.WorkInProgressAuditDomGASWork)
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\WIP Audit Domestic Gas Work.dot")
                    Case CInt(Enums.AdditionalChecksTypes.PostCompleteAuditDomWork)
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\Post Complete Audit Domestic Work.dot")
                    Case CInt(Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork)
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\WIP Audit Domestic Oil Work.dot")
                    Case CInt(Enums.AdditionalChecksTypes.WorkInProgressAuditCommercialGASWork)
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\WIP Audit Commercial Gas Work.dot")
                    Case CInt(Enums.AdditionalChecksTypes.ElectricalAudit)
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ElectricalQC.dot")
                End Select

                Dim add As EngineerVisitAdditionals.EngineerVisitAdditional = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(DetailsToPrint(0), DetailsToPrint(1))

                If add.Test125 = 0 Then add.SetTest125 = 53
                Dim eng As Engineers.Engineer = DB.Engineer.Engineer_Get(CInt(add.Test125))
                Dim engv As DataTable = DB.EngineerVisits.EngineerVisits_Get(DetailsToPrint(0)).Table
                Dim auitor As Engineers.Engineer = DB.Engineer.Engineer_Get(CInt(engv(0)("EngineerID")))
                Dim address As Sites.Site = DB.Sites.Get(DetailsToPrint(0), Sites.SiteSQL.GetBy.EngineerVisitId)
                Dim job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(DetailsToPrint(0))
                Dim customer As Customers.Customer = DB.Customer.Customer_Get(address.CustomerID)

                Try
                    For Each wordField As System.Text.RegularExpressions.Match In GetTemplateFields(WordDoc.Content.Text)
                        Select Case wordField.Value.ToLower
                            Case "[Client]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(customer.Name))
                            Case "[UPRN]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(address.PolicyNumber))
                            Case "[Project]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(add.Test1).Name))
                            Case "[Address]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(address.Address1 & ", " & address.Address2 & ", " & address.Address3 & ", " & address.Postcode))
                            Case "[Type]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(add.Test237).Name))
                            Case "[eng]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.Name))
                            Case "[ename]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.Name))
                            Case "[CompletedBy]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.Name))
                            Case "[aname]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(auitor.Name))
                            Case "[QCBy]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(auitor.Name))
                            Case "[sum]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(engv(0)("OutcomeDetails")))
                            Case "[jn]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(add.Test238))
                            Case "[gs]".ToLower
                                If DetailsToPrint(1) = CInt(Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork) Or address.SiteFuel = "Oil" Then
                                    ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.OftecNo))
                                Else
                                    ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.GasSafeNo))
                                End If
                            Case "[date]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(Format(engv(0)("StartDateTime"), "dd/MM/yyyy")))
                            Case "[date2]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(Format(engv(0)("StartDateTime"), "dd/MM/yyyy")))
                            Case "[outcome]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(add.Test124).Name))
                            Case "[add]".ToLower
                                Dim strings As String = address.Address1 & ", " & vbNewLine & address.Address2 & ", " & vbNewLine & Sys.Helper.FormatPostcode(address.Postcode)
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(strings))
                            Case "[Make]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test235)
                            Case "[Model]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test236)
                            Case "[1]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test1).Name)
                            Case "[2]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test2).Name)
                            Case "[3]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test3).Name)
                            Case "[4]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test4).Name)
                            Case "[5]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test5).Name)
                            Case "[6]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test6).Name)
                            Case "[7]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test7).Name)
                            Case "[8]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test8).Name)
                            Case "[9]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test9).Name)
                            Case "[10]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test10).Name)
                            Case "[1a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test111).Name)
                            Case "[2a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test2).Name)
                            Case "[3a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test3).Name)
                            Case "[4a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test4).Name)
                            Case "[5a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test5).Name)
                            Case "[6a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test6).Name)
                            Case "[7a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test7).Name)
                            Case "[8a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test8).Name)
                            Case "[9a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test9).Name)
                            Case "[10a]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test10).Name)
                            Case "[11]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test111).Name)
                            Case "[12]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test112).Name)
                            Case "[13]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test113).Name)
                            Case "[14]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test114).Name)
                            Case "[15]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test115).Name)
                            Case "[16]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test116).Name)
                            Case "[17]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test117).Name)
                            Case "[18]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test118).Name)
                            Case "[19]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test119).Name)
                            Case "[20]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test120).Name)
                            Case "[21]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test121).Name)
                            Case "[22]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test122).Name)
                            Case "[23]".ToLower
                                ReplaceText(WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test123).Name)
                            Case "[c1]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test11)
                            Case "[c2]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test12)
                            Case "[c3]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test13)
                            Case "[c4]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test14)
                            Case "[c5]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test15)
                            Case "[c6]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test216)
                            Case "[c7]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test217)
                            Case "[c8]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test218)
                            Case "[c9]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test219)
                            Case "[c10]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test220)
                            Case "[c11]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test221)
                            Case "[c12]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test222)
                            Case "[c13]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test223)
                            Case "[c14]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test224)
                            Case "[c15]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test225)
                            Case "[c16]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test226)
                            Case "[c17]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test227)
                            Case "[c18]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test228)
                            Case "[c19]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test229)
                            Case "[c20]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test230)
                            Case "[c21]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test231)
                            Case "[c22]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test232)
                            Case "[c23]".ToLower
                                ReplaceText(WordDoc, wordField.Value, add.Test233)
                        End Select
                    Next

                    If Not engv(0)("EngineerSignature") Is Nothing Then
                        Dim es As Byte() = engv(0)("EngineerSignature")
                        Dim engSig As Bitmap = New Bitmap(New IO.MemoryStream(es))
                        engSig.Save(Application.StartupPath & "\TEMP\EngSig.bmp")
                        If DetailsToPrint(1) <> CInt(Enums.AdditionalChecksTypes.ElectricalAudit) Then
                            WordDoc.Bookmarks.Item("asig").Range.InlineShapes.AddPicture(Application.StartupPath & "\Temp\EngSig.bmp")
                        End If
                    End If

                    If Not engv(0)("CustomerSignature") Is Nothing Then
                        Dim cs As Byte() = engv(0)("CustomerSignature")
                        Dim custSig As Bitmap = New Bitmap(New IO.MemoryStream(cs))
                        custSig.Save(Application.StartupPath & "\TEMP\CustSig.bmp")
                        If DetailsToPrint(1) <> CInt(Enums.AdditionalChecksTypes.ElectricalAudit) Then
                            WordDoc.Bookmarks.Item("esig").Range.InlineShapes.AddPicture(Application.StartupPath & "\Temp\CustSig.bmp")
                        End If
                    End If

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try

            End Function

            Private Function GenerateContractExpiry(ByVal dr As DataRow, ByVal tblIndex As Integer) As Boolean

                Try
                    For Each wordField As System.Text.RegularExpressions.Match In GetTemplateFields(WordDoc.Content.Text)
                        Select Case wordField.Value.ToLower
                            Case "[Address1]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address1")))
                            Case "[Address2]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address2")))
                            Case "[Address3]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address3")))
                            Case "[Address4]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address4")))
                            Case "[Address5]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address5")))
                            Case "[Postcode]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.FormatPostcode(dr("Postcode")))
                            Case "[Date]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Strings.Format(Now, "dd/MM/yyyy"))
                            Case "[CompanyName]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Name")))
                            Case "[ExpiryDate]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Strings.Format(Sys.Helper.MakeDateTimeValid(dr("ContractEndDate")), "dd/MM/yyyy"))
                            Case "[user]".ToLower
                                ReplaceText(WordDoc, wordField.Value, loggedInUser.Fullname)
                            Case "[ContractType]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("ContractType")))
                            Case "[ContractReference]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("ContractReference")))
                            Case "[SiteAddress1]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("SiteAddress1")))
                            Case "[PriceSentence]".ToLower
                                Dim strSentence As String = ""

                                strSentence = DB.Picklists.Get_Single_Description(dr("ContractType"), Enums.PickListTypes.ContractPricing)
                                ReplaceText(WordDoc, wordField.Value, strSentence)

                            Case "[ExcludeSentence]".ToLower
                                Dim strSentence As String = ""

                                If dr("ContractType") = "Gold Star" Or dr("ContractType") = "Platinum Star" Then
                                    strSentence = "Please be advised that we are now offering cover for boilermates or any other make of thermal store product as an additional appliance. Should you have a thermal store product"
                                End If
                                ' in your property and require cover, this could be added for an additional £109.34 per annum

                                ReplaceText(WordDoc, wordField.Value, strSentence)

                            Case "[ExcludeSentence2]".ToLower
                                Dim strSentence As String = ""

                                If dr("ContractType") = "Gold Star" Then strSentence = " in your property and require cover, this could be added for an additional " & Format(CDbl(DB.Picklists.Get_Single_Description("Additional Appliance", 52)), "C") & " per annum."

                                If dr("ContractType") = "Platinum Star" Then strSentence = " in your property and require cover, this could be added for an additional " & Format(CDbl(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52)), "C") & " per annum."

                                ReplaceText(WordDoc, wordField.Value, strSentence)
                            Case "[AHE]".ToLower
                                Dim strSentence As String = DB.Picklists.Get_Single_Description("AHE", 52)
                                ReplaceText(WordDoc, wordField.Value, strSentence)
                        End Select
                    Next

                    With WordDoc.Tables.Item(tblIndex)
                        If Sys.Helper.MakeBooleanValid(dr("DirectDebit")) = True Then
                            .Cell(2, 1).Delete()
                        Else
                            .Cell(1, 1).Delete()
                        End If

                    End With

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try

            End Function

            Private Function GenerateDomesticGSRDue(ByVal dr() As DataRow, ByVal dtPrinted As DataTable, ByVal savePath As String, Optional ByVal batch As WordprocessingDocument = Nothing) As Boolean
                Try
                    Dim template As String = Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\GSRDue.docx"
                    Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr(0)("SiteID")))
                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream

                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            Dim currentContract As ContractsOriginal.ContractOriginal = DB.ContractOriginal.Get_Current_ForSite(dr(0)("SiteID"))
                            If currentContract Is Nothing Then
                                PrintHelper.DeleteBookmark(wordDoc, "OnContract1")
                                PrintHelper.DeleteBookmark(wordDoc, "StarMainMessage")

                                Dim dvOnContractAppliances As DataView = DB.Asset.Asset_GetForSite(dr(0)("SiteID"))
                                Dim dt As New DataTable
                                dt.Columns.Add("Appliance")

                                For Each ddr As DataRowView In dvOnContractAppliances
                                    If Helper.MakeBooleanValid(ddr("Active")) Then
                                        Dim nr As DataRow
                                        nr = dt.NewRow
                                        nr("Appliance") = ddr("Product")
                                        dt.Rows.Add(nr)
                                    End If
                                Next ddr

                                PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                                If dt.Rows.Count > 0 Then PrintHelper.ReplaceBookmarkWithTable(wordDoc, "ApplianceTable", dt)

                                PrintHelper.ReplaceText(wordDoc, "[ContractCover]", "If you would like us to carry out your annual service and/or to discuss our Maintenance Cover further, please call us on 01603 309599.")
                            Else

                                Dim dvOnContractAppliances As DataView = DB.ContractOriginal.
                                ContractOriginalSiteAsset_GetAll_SiteID(dr(0)("SiteID"))
                                Dim dt As New DataTable
                                dt.Columns.Add("Appliance")

                                For Each ddr As DataRowView In dvOnContractAppliances
                                    Dim nr As DataRow
                                    nr = dt.NewRow
                                    nr("Appliance") = ddr("Appliance")
                                    dt.Rows.Add(nr)
                                Next ddr

                                If dt.Rows.Count > 0 Then PrintHelper.ReplaceBookmarkWithTable(wordDoc, "ApplianceTable", dt)
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract1")
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract2")
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract3")
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract4")
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract5")
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract6")
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract7")

                                PrintHelper.ReplaceText(wordDoc, "[ContractCover]", "If you would like us to carry out your annual service please call us on 01603 309590.")

                            End If
                            PrintHelper.ReplaceText(wordDoc, "[Tenant]", Sys.Helper.MakeStringValid(dr(0)("Tenant")))
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", dr(0)("Address1"))
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", dr(0)("Address2"))
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", dr(0)("Address3"))
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Sys.Helper.FormatPostcode(dr(0)("Postcode")))
                            PrintHelper.ReplaceText(wordDoc, "[Date]", Now.ToShortDateString())
                            PrintHelper.ReplaceText(wordDoc, "[NextServiceDate]", Strings.Format(Sys.Helper.MakeDateTimeValid(dr(0)("VisitDate")).AddYears(1), "dd/MM/yyyy"))
                            wordDoc.MainDocumentPart.Document.Body.InsertAfter(
                                New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})),
                                wordDoc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            wordDoc.MainDocumentPart.Document.Save()
                        End Using

                        savePath = FileCheck(savePath)
                        Dim fileStream As FileStream = New FileStream(savePath, System.IO.FileMode.CreateNew)
                        mm.Position = 0
                        Using (fileStream)
                            mm.WriteTo(fileStream)
                        End Using

                        For Each r As DataRow In dr
                            Dim ar As DataRow = dtPrinted.NewRow
                            ar("AssetID") = r("AssetID")
                            ar("DateDue") = r("DueDate")
                            dtPrinted.Rows.Add(ar)
                        Next r

                        If Not batch Is Nothing Then
                            Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                            Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr(0)("SiteID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                            Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                            mm.Position = 0

                            Using mm
                                chunk.FeedData(mm)
                            End Using

                            Dim altChunk As WP.AltChunk = New WP.AltChunk()
                            altChunk.Id = altChunkId
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            mainPart.Document.Save()
                        Else
                            Process.Start(savePath)
                        End If
                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateLLGSRDue(ByVal dr() As DataRow, ByVal dtPrinted As DataTable, ByVal savePath As String,
                                                         Optional ByVal batch As WordprocessingDocument = Nothing) As Boolean
                Try
                    Dim template As String = Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\GSRDueLL.docx"
                    Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr(0)("SiteID")))
                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream

                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            Dim dt As New DataTable
                            dt.Columns.Add("Property")
                            dt.Columns.Add("Service Due Date")
                            dt.Columns.Add("Appliance")

                            Dim lastSiteId As Integer = 0
                            For Each r As DataRow In dr
                                Dim nr As DataRow
                                nr = dt.NewRow
                                If lastSiteId <> r("SiteID") Then nr("Property") = r("Tenant") & ", " & r("Address1") & ", " & r("Address2") & ", " & Sys.Helper.FormatPostcode(r("Postcode"))
                                nr("Service Due Date") = Strings.Format(Sys.Helper.MakeDateTimeValid(r("DueDate")).AddYears(1), "dd-MMM-yyyy")
                                nr("Appliance") = r("Appliance")
                                dt.Rows.Add(nr)
                                lastSiteId = r("SiteID")
                            Next r

                            PrintHelper.ReplaceBookmarkWithTable(wordDoc, "SitesAndAppliances", dt)
                            Dim selHQ As Sites.Site = DB.Sites.Get(dr(0)("CustomerID"), Sites.SiteSQL.GetBy.CustomerHq)
                            If selHQ Is Nothing Then Return False
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                            PrintHelper.ReplaceText(wordDoc, "[CustomerName]", Sys.Helper.MakeStringValid(dr(0)("CustomerName")))
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", selHQ.Address1)
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", selHQ.Address2)
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", selHQ.Address3)
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Sys.Helper.FormatPostcode(selHQ.Postcode))
                            PrintHelper.ReplaceText(wordDoc, "[Date]", Now.ToShortDateString())
                            wordDoc.MainDocumentPart.Document.Body.InsertAfter(
                                New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})),
                                wordDoc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            wordDoc.MainDocumentPart.Document.Save()
                        End Using

                        savePath = FileCheck(savePath)
                        Dim fileStream As FileStream = New FileStream(savePath, System.IO.FileMode.CreateNew)
                        mm.Position = 0
                        Using (fileStream)
                            mm.WriteTo(fileStream)
                        End Using

                        For Each r As DataRow In dr
                            Dim ar As DataRow = dtPrinted.NewRow
                            ar("AssetID") = r("AssetID")
                            ar("DateDue") = r("DueDate")
                            dtPrinted.Rows.Add(ar)
                        Next r

                        If Not batch Is Nothing Then
                            Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                            Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr(0)("SiteID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                            Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                            mm.Position = 0

                            Using mm
                                chunk.FeedData(mm)
                            End Using

                            Dim altChunk As WP.AltChunk = New WP.AltChunk()
                            altChunk.Id = altChunkId
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            mainPart.Document.Save()
                        Else
                            Process.Start(savePath)
                        End If
                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GSR(ByVal oEngineerVisit As EngineerVisits.EngineerVisit, ByVal oSite As Sites.Site, ByVal dvFaults As DataView, ByVal printHeader As Boolean, ByVal GSRS As DataView, ByVal template As String, ByVal savePath As String,
                                 ByVal Fuel As Enums.WorksheetFuelTypes, ByVal goldenRule As String, Optional ByVal fullDocument As List(Of Byte()) = Nothing, Optional ByVal NCCTemplate As Boolean = False) As Boolean
                Try
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                    Dim imageIndex As Integer = 100
                    Dim oSiteHQ As Sites.Site = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)

                    Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = oEngineerVisit.ManualEntryOn
                    End If

                    Dim noOfRowsPerPage As Integer = 4 'as most pages have 4
                    Select Case Fuel
                        Case Enums.WorksheetFuelTypes.Unvented
                            noOfRowsPerPage = 12
                        Case Enums.WorksheetFuelTypes.Oil
                            noOfRowsPerPage = 1
                        Case Else
                            noOfRowsPerPage = 4
                    End Select
                    Dim pageNumbers As New List(Of Integer)
                    pageNumbers.Add(Math.Ceiling(GSRS.Table.Rows.Count / noOfRowsPerPage))

                    Dim pages As Integer = pageNumbers.Max
                    If pages < 1 Then pages = 1
                    Try
                        'gsr
                        For page As Integer = 1 To pages

                            Dim lowAppIndex As Integer = (page * noOfRowsPerPage) - noOfRowsPerPage
                            Dim highAppIndex As Integer = page * noOfRowsPerPage

                            Dim finaldoc As Byte() = Nothing
                            Dim byteArray As Byte() = File.ReadAllBytes(template)
                            Dim mm As MemoryStream = New MemoryStream
                            Using (mm)
                                mm.Write(byteArray, 0, byteArray.Length)
                                Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                                Using (wordDoc)
                                    PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                                    If engineer Is Nothing Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafeIDNo", "")
                                    ElseIf Fuel = Enums.WorksheetFuelTypes.Oil Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafeIDNo", engineer.OftecNo)
                                    Else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafeIDNo", engineer.GasSafeNo)
                                    End If

                                    Dim uid As String = oEngineerVisit.EngineerVisitID & "_" & Now.ToString("ddMMyyyyhhmm") & "_" & Fuel.ToString().ToUpper()
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobSiteName", oSite.Name.Replace("T1", "").Trim(), "8")
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress1", oSite.Address1, "8")
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress2", oSite.Address2, "8")
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress3", oSite.Address3, "8")
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobPostCode", Helper.FormatPostcode(oSite.Postcode), "8")
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate", uid, "6", True)
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate1", visitDate.ToLongDateString)
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate2", visitDate.ToLongDateString)

                                    AddCompanyDetails(wordDoc, True)

                                    If oEngineerVisit.GasServiceCompleted = True And oEngineerVisit.OutcomeEnumID <> Enums.EngineerVisitOutcomes.Complete Then
                                        Dim customer As Customers.Customer = DB.Customer.Customer_Get_ForSiteID(oSite.SiteID)
                                        Dim motstyle As Boolean = False
                                        If customer IsNot Nothing AndAlso customer.MOTStyleService = True Then motstyle = True

                                        Dim actualServiceDate As DateTime
                                        If oEngineerVisit.StartDateTime = Date.MinValue Then
                                            If oEngineerVisit.TimeSheets.Table.Rows.Count > 0 Then
                                                actualServiceDate = oEngineerVisit.TimeSheets.Table.Rows(0).Item("StartDateTime")
                                            Else
                                                actualServiceDate = Now()
                                            End If
                                        Else
                                            actualServiceDate = oEngineerVisit.StartDateTime
                                        End If

                                        Dim oldLastServiceDate As DateTime = Nothing
                                        Dim lastServiceDate As DateTime = Nothing
                                        'update all

                                        oldLastServiceDate = Helper.MakeDateTimeValid(oSite.LastServiceDate)
                                        Dim sfServiceDiff As Integer = DateDiff(DateInterval.Month, actualServiceDate, oldLastServiceDate.AddYears(1))
                                        If oldLastServiceDate.AddYears(1) > actualServiceDate And
                                        sfServiceDiff >= 0 And sfServiceDiff <= 2 And motstyle Then
                                            lastServiceDate = oldLastServiceDate.AddYears(1)
                                        Else
                                            lastServiceDate = actualServiceDate
                                        End If

                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "NextServiceDue", lastServiceDate.AddYears(1).ToLongDateString)
                                    ElseIf oEngineerVisit.GasServiceCompleted = True And oEngineerVisit.OutcomeEnumID = Enums.EngineerVisitOutcomes.Complete And
                                    oEngineerVisit.VisitLocked Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "NextServiceDue", oSite.LastServiceDate.AddYears(1).ToLongDateString)
                                    Else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "NextServiceDue", visitDate.AddYears(1).ToLongDateString)
                                    End If

                                    Dim selected As PickLists.PickList = DB.Picklists.Get_One_As_Object(oEngineerVisit.SignatureSelectedID)
                                    If selected Is Nothing Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "JobCustomerName", oEngineerVisit.CustomerName)
                                    Else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "JobCustomerName", oEngineerVisit.CustomerName & " (" & selected.Name & ")")
                                    End If

                                    If Not oSiteHQ Is Nothing Then
                                        Dim strAddress As String = String.Empty

                                        If oSiteHQ.Address1.Length > 0 Then
                                            strAddress += oSiteHQ.Address1 & ", "
                                        End If

                                        If oSiteHQ.Address2.Length > 0 Then
                                            strAddress += oSiteHQ.Address2 & ", "
                                        End If

                                        If strAddress.Length > 0 Then
                                            strAddress = strAddress.Substring(0, strAddress.Length - 2)
                                        End If

                                        Dim strAddress1 As String = String.Empty

                                        If oSiteHQ.Address3.Length > 0 Then
                                            strAddress1 += oSiteHQ.Address3 & ", "
                                        End If

                                        If oSiteHQ.Address4.Length > 0 Then
                                            strAddress1 += oSiteHQ.Address4 & ", "
                                        End If

                                        If oSiteHQ.Address5.Length > 0 Then
                                            strAddress1 += oSiteHQ.Address5 & ", "
                                        End If

                                        If strAddress.Length > 0 And strAddress1.Length > 1 Then
                                            strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2)
                                        End If

                                        Dim customerName As String = If(oSiteHQ.CustomerID <> Enums.Customer.Domestic, DB.Customer.Customer_Get(oSite.CustomerID).Name, "")

                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordName", customerName, "8")
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress1", strAddress, "8")
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress2", strAddress1, "8")
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LLPostcode", Helper.FormatPostcode(oSiteHQ.Postcode), "8")
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LLTelNo", oSiteHQ.TelephoneNum, "8")
                                    Else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordName", "")
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress1", "")
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress2", "")
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LLPostcode", "")
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LLTelNo", "")
                                    End If

                                    Dim propRented As PickLists.PickList = DB.Picklists.Get_One_As_Object(oEngineerVisit.PropertyRented)
                                    If propRented Is Nothing Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Rented", "")
                                    Else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Rented", propRented.Name, "8")
                                    End If

                                    If engineer Is Nothing Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", "")
                                    Else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", engineer.Name)
                                    End If

                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "CustomerName", oEngineerVisit.CustomerName)
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "OtherNotes", oEngineerVisit.OutcomeDetails)

                                    Select Case Fuel
                                        Case Enums.WorksheetFuelTypes.Gas, Enums.WorksheetFuelTypes.Oil,
                                         Enums.WorksheetFuelTypes.Other, Enums.WorksheetFuelTypes.Unvented
                                            If GSRS.Table.Rows.Count = 0 Then
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "NoOfAppliances", "0", "8")
                                            Else
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "NoOfAppliances", GSRS.Table.Select("ApplianceTested='Yes'").Length, "8")
                                            End If
                                        Case Else
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "NoOfAppliances", GSRS.Table.Rows.Count, "8")
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "NumInspected", GSRS.Table.Rows.Count, "8")
                                    End Select

                                    Dim COMO As DataView = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.COMOAlarm)
                                    Dim SMOKE As DataView = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SmokeAlarm)

                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "COMO", COMO.Count.ToString)
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "SMOKE", SMOKE.Count.ToString)

                                    If Fuel = Enums.WorksheetFuelTypes.Gas Then
                                        Dim ecv As PickLists.PickList = DB.Picklists.Get_One_As_Object(oEngineerVisit.EmergencyControlAccessibleID)
                                        If ecv Is Nothing Then
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "ECV", "")
                                        Else
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "ECV", ecv.Name)
                                        End If
                                        Dim tightest As PickLists.PickList = DB.Picklists.Get_One_As_Object(oEngineerVisit.GasInstallationTightnessTestID)
                                        If tightest Is Nothing Then
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "tightest", "")
                                        Else
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "tightest", tightest.Name)
                                        End If
                                        Dim bonding As PickLists.PickList = DB.Picklists.Get_One_As_Object(oEngineerVisit.BondingID)
                                        If bonding Is Nothing Then
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Bonding", "")
                                        Else
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Bonding", bonding.Name)
                                        End If
                                    End If
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "WorkCarriedOut", oEngineerVisit.OutcomeDetails)
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobVisitNumber", oEngineerVisit.EngineerVisitID, "9", True)

                                    If oEngineerVisit.EngineerSignature Is Nothing Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "EngineerSignature", "")
                                    Else
                                        Dim engSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.EngineerSignature))
                                        Dim imgSavePath As String = Application.StartupPath & "\TEMP\EngSig.jpg"

                                        If Fuel = Enums.WorksheetFuelTypes.Unvented Then
                                            PrintHelper.ReplaceBookmarkWithImage(wordDoc, "AJ", engSig, imgSavePath, imageIndex)
                                            imageIndex += 1
                                        Else
                                            PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngineerSignature", engSig, imgSavePath, imageIndex)
                                            imageIndex += 1
                                        End If
                                    End If

                                    If oEngineerVisit.CustomerSignature Is Nothing Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CustomerSignature", "")
                                    Else
                                        Dim custSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.CustomerSignature))
                                        Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                        PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustomerSignature", custSig, imgSavePath, imageIndex)
                                        imageIndex += 1
                                    End If

                                    If GSRS.Table.Rows.Count = 0 OrElse IsDBNull(GSRS.Table.Rows(0)("ReadingType")) Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafe", "7939")
                                    Else
                                        Select Case Helper.MakeIntegerValid(GSRS.Table.Rows(0)("ReadingType"))
                                            Case 0
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafe", "7939")
                                            Case 2
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafe", "6102")
                                        End Select
                                    End If

                                    Dim logo As Byte() = Nothing
                                    Try
                                        logo = DB.ExecuteScalar("Select Logo FROM tblCustomer where CustomerID = " &
                                                            oSite.CustomerID)
                                    Catch
                                        logo = Nothing
                                    End Try

                                    If logo IsNot Nothing Then
                                        Dim custLogo As Bitmap = New Bitmap(New IO.MemoryStream(logo))
                                        Dim imgSavePath As String = Application.StartupPath & "\TEMP\custLogo.jpg"
                                        PrintHelper.ReplaceBookmarkWithImage(wordDoc, "Logo", custLogo, imgSavePath, imageIndex)
                                        imageIndex += 1
                                    Else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Logo", "")
                                    End If

                                    If NCCTemplate Then
                                        If oSite.LeaseHold = True Then
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Tenant", "Leaseholder", "8")
                                        Else
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Tenant", "Tenanted", "8")
                                        End If
                                    End If

                                    'TO BE REMOVED AFTER APPROVAL - CONFIRM WITH YF
                                    If Not oEngineerVisit.EngineerVisitNCCGSR Is Nothing Then
                                        Dim dvNccGsr As DataView = DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_Get_Friendly(oEngineerVisit.EngineerVisitNCCGSR.EngineerVisitNCCGSRID)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Rad", oEngineerVisit.EngineerVisitNCCGSR.Radiators)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Age", oEngineerVisit.EngineerVisitNCCGSR.ApproxAgeOfBoiler)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Info1", Helper.MakeStringValid(dvNccGsr(0)("CorrectMaterialsUsed")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Info2", Helper.MakeStringValid(dvNccGsr(0)("InstallationPipeWorkCorrect")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Info3", Helper.MakeStringValid(dvNccGsr(0)("InstallationSafeToUse")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SF", Helper.MakeStringValid(dvNccGsr(0)("StrainerFitted")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SI", Helper.MakeStringValid(dvNccGsr(0)("StrainerInspected")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "HST", Helper.MakeStringValid(dvNccGsr(0)("HeatingSystemType")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "PH", Helper.MakeStringValid(dvNccGsr(0)("PartialHeating")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CT", Helper.MakeStringValid(dvNccGsr(0)("CylinderType")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Jack", Helper.MakeStringValid(dvNccGsr(0)("Jacket")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Im", Helper.MakeStringValid(dvNccGsr(0)("Immersion")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CO", Helper.MakeStringValid(dvNccGsr(0)("CODetectorFitted")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "FL", Helper.MakeStringValid(dvNccGsr(0)("FillDisc")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SIT", Helper.MakeStringValid(dvNccGsr(0)("SITimer")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CertType", Helper.MakeStringValid(dvNccGsr(0)("CertificateType")))
                                    End If

                                    If Fuel <> Enums.WorksheetFuelTypes.Unvented Then
                                        Dim dtAppliances As DataTable
                                        Dim dtFaults As DataTable
                                        Try
                                            dtAppliances = GSRS.Table.AsEnumerable().Where(Function(row, index) index >= lowAppIndex And index < highAppIndex).CopyToDataTable()
                                        Catch ex As Exception
                                            dtAppliances = New DataTable
                                        End Try

                                        Dim lowIndex As Integer = (page * 2) - 2
                                        Dim highIndex As Integer = page * 2
                                        Try
                                            Try
                                                Dim assetIds As List(Of Integer) = (From r In dtAppliances.AsEnumerable() Select r.Field(Of Integer)("AssetID")).ToList()
                                                dtFaults = dvFaults.Table.AsEnumerable().Where(Function(row, index) assetIds.Contains(Helper.MakeStringValid(row("AssetID")))).CopyToDataTable()

                                                Try
                                                    Dim drSiteFaults As DataRow() = dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0")
                                                    If drSiteFaults.Length > 0 Then
                                                        dtFaults.Merge(drSiteFaults.CopyToDataTable().AsEnumerable().Where(Function(row, index) index >= lowIndex And index < highIndex).CopyToDataTable())
                                                    End If
                                                Catch ex As Exception
                                                    'empty
                                                End Try
                                                'TO BE READDED AFTER APPROVAL -  CONFIRM WITH YF
                                                'If Fuel = Enums.WorksheetFuelTypes.Gas Then
                                                '    dtFaults = dtFaults.Select("CategoryID = " & CInt(Enums.DefectCategory.AtRisk) & " OR CategoryID = " & CInt(Enums.DefectCategory.ImmediatelyDangerous)).CopyToDataTable()
                                                'End If
                                            Catch ex As Exception
                                                'no assets
                                                dtFaults = New DataTable
                                                Dim siteFaults As DataTable = dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0").CopyToDataTable()
                                                dtFaults.Merge(siteFaults.AsEnumerable().Where(Function(row, index) index >= lowIndex And index < highIndex).CopyToDataTable())
                                            End Try
                                        Catch ex As Exception
                                            dtFaults = New DataTable
                                        End Try

                                        Dim appCount As Integer = If(dtAppliances IsNot Nothing, dtAppliances.Rows.Count, 0)

                                        AddAppliancesBatch(wordDoc, appCount, dtAppliances, dtFaults, False, CInt(Fuel))
                                    End If

                                    If Fuel = Enums.WorksheetFuelTypes.Unvented Then

                                        AddAppliancesBatch(wordDoc, GSRS.Table.Rows.Count, GSRS.Table, dvFaults.Table, False, CInt(Fuel))

                                        Dim ad As EngineerVisitAdditionals.EngineerVisitAdditional = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialCateringCP42)
                                        If ad IsNot Nothing Then
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", ad.Test221)
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", ad.Test222)
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", ad.Test223)
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", ad.Test224)
                                        End If

                                        Dim WorkRequest As String = ""
                                        WorkRequest = oEngineerVisit.NotesToEngineer
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", WorkRequest)

                                        Dim WorkResult As String = ""
                                        WorkResult = oEngineerVisit.NotesFromEngineer
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", WorkResult)
                                    End If
                                End Using
                            End Using

                            Dim docsToMerge As New List(Of Byte())
                            docsToMerge.Add(mm.ToArray())

                            'TO BE READDED AFTER APPROVAL -  CONFIRM WITH YF
                            'If Fuel = Enums.WorksheetFuelTypes.Gas Then
                            '    Dim dtCurrentPageFaults As DataTable = New DataTable()
                            '    Dim currentAssetIds As List(Of Integer) = GSRS.Table.AsEnumerable().Where(Function(row, index) index >= lowAppIndex And index < highAppIndex)?.Select(Function(x) Helper.MakeIntegerValid(x("AssetID")))?.ToList()
                            '    If currentAssetIds?.Count > 0 Then
                            '        Dim assetFaults As DataRow() = dvFaults.Table.AsEnumerable().Where(Function(row, index) currentAssetIds.Contains(Helper.MakeStringValid(row("AssetID")))).ToArray()
                            '        If assetFaults?.Length > 0 Then dtCurrentPageFaults = assetFaults?.CopyToDataTable()
                            '    End If
                            '    If page = 1 Then
                            '        Dim siteFaults As DataRow() = dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0")
                            '        If siteFaults?.Length > 0 Then dtCurrentPageFaults.Merge(siteFaults.CopyToDataTable())
                            '    End If

                            '    docsToMerge.Add(AddLgsrSupplementaryInformation(oEngineerVisit, New DataView(dtCurrentPageFaults), oSite.SiteID, page)?.ToArray())
                            'End If

                            If printHeader = True And page = pages Then
                                docsToMerge.Add(LsrHeaderLetter(oSite, oSiteHQ, visitDate, Nothing)?.ToArray())
                            End If

                            finaldoc = PrintHelper.CombineDocs(docsToMerge)

                            savePath = FileCheck(savePath)

                            If finaldoc IsNot Nothing Then
                                fullDocument.Add(finaldoc)
                            Else
                                Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                                mm.Position = 0
                                Using (fileStream)
                                    mm.WriteTo(fileStream)
                                End Using
                            End If
                        Next
                        Return True
                    Catch ex As Exception
                        ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End Try
                Catch ex As Exception

                End Try
            End Function

            Private Function AddLgsrSupplementaryInformation(ByVal engineerVisit As EngineerVisits.EngineerVisit, ByVal dvDefects As DataView, ByVal siteId As Integer, ByVal pageNo As Integer) As Byte()
                Dim doc As Byte() = Nothing
                Dim template As String = Application.StartupPath & "\Templates\GSR\LGSR_Supplementary_Info.docx"
                Dim cGoldenRule As String = GetDocumentGoldenRule(template, siteId)
                Dim cbyteArray As Byte() = File.ReadAllBytes(template)
                Dim cmm As MemoryStream = New MemoryStream
                Using (cmm)
                    cmm.Write(cbyteArray, 0, cbyteArray.Length)
                    Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(cmm, True)
                    Using (wordDoc)
                        PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", cGoldenRule)

                        Dim dt As New DataTable
                        dt.Columns.Add("Appliance")
                        dt.Columns.Add("Category")
                        dt.Columns.Add("Reason")
                        dt.Columns.Add("Action Taken")
                        dt.Columns.Add("Comments")

                        If dvDefects.Count > 0 Then
                            For Each r As DataRow In dvDefects.Table.Select("", "AssetID DESC")
                                Dim nr As DataRow
                                nr = dt.NewRow
                                nr("Appliance") = r("typemakemodel")
                                nr("Category") = r("Category")
                                nr("Reason") = r("Reason")
                                nr("Action Taken") = r("ActionTaken")
                                nr("Comments") = r("Comments")
                                dt.Rows.Add(nr)
                            Next
                        End If

                        If dt.Rows.Count > 0 Then
                            PrintHelper.AddRowsToTable(wordDoc, "[NCS]", dt, "Arial", "14")
                            PrintHelper.ReplaceText(wordDoc, "[NoDefects]", String.Empty)
                        Else
                            PrintHelper.DeleteTableBookmark(wordDoc, "[NCS]")
                            PrintHelper.ReplaceText(wordDoc, "[NoDefects]", "NO DEFECTS RECORDED")
                        End If

                        If pageNo = 1 Then

                            If Not Helper.IsStringEmpty(engineerVisit.OutcomeDetails) Then
                                PrintHelper.ReplaceText(wordDoc, "[EngineerNotes]", engineerVisit.OutcomeDetails)
                            Else
                                PrintHelper.DeleteTableBookmark(wordDoc, "[EngineerNotes]")
                            End If

                            Dim COMO As DataView = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(engineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.COMOAlarm)
                            Dim SMOKE As DataView = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(engineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SmokeAlarm)

                            PrintHelper.ReplaceText(wordDoc, "[Como]", COMO.Count.ToString)
                            PrintHelper.ReplaceText(wordDoc, "[Smoke]", SMOKE.Count.ToString)

                            Dim dvNccGsr As DataView = DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_Get_Friendly(engineerVisit.EngineerVisitNCCGSR?.EngineerVisitNCCGSRID)
                            If dvNccGsr?.Count > 0 AndAlso Helper.MakeIntegerValid(dvNccGsr(0)("CorrectMaterialsUsedID")) > 0 Then
                                PrintHelper.ReplaceText(wordDoc, "[Rad]", Helper.MakeStringValid(dvNccGsr(0)("Radiators")))
                                PrintHelper.ReplaceText(wordDoc, "[Age]", Helper.MakeStringValid(dvNccGsr(0)("ApproxAgeOfBoiler")))
                                PrintHelper.ReplaceText(wordDoc, "[Info1]", Helper.MakeStringValid(dvNccGsr(0)("CorrectMaterialsUsed")))
                                PrintHelper.ReplaceText(wordDoc, "[Info2]", Helper.MakeStringValid(dvNccGsr(0)("InstallationPipeWorkCorrect")))
                                PrintHelper.ReplaceText(wordDoc, "[Info3]", Helper.MakeStringValid(dvNccGsr(0)("InstallationSafeToUse")))
                                PrintHelper.ReplaceText(wordDoc, "[SF]", Helper.MakeStringValid(dvNccGsr(0)("StrainerFitted")))
                                PrintHelper.ReplaceText(wordDoc, "[SI]", Helper.MakeStringValid(dvNccGsr(0)("StrainerInspected")))
                                PrintHelper.ReplaceText(wordDoc, "[HST]", Helper.MakeStringValid(dvNccGsr(0)("HeatingSystemType")))
                                PrintHelper.ReplaceText(wordDoc, "[PH]", Helper.MakeStringValid(dvNccGsr(0)("PartialHeating")))
                                PrintHelper.ReplaceText(wordDoc, "[CT]", Helper.MakeStringValid(dvNccGsr(0)("CylinderType")))
                                PrintHelper.ReplaceText(wordDoc, "[Jack]", Helper.MakeStringValid(dvNccGsr(0)("Jacket")))
                                PrintHelper.ReplaceText(wordDoc, "[IM]", Helper.MakeStringValid(dvNccGsr(0)("Immersion")))
                                PrintHelper.ReplaceText(wordDoc, "[CO]", Helper.MakeStringValid(dvNccGsr(0)("CODetectorFitted")))
                                PrintHelper.ReplaceText(wordDoc, "[FL]", Helper.MakeStringValid(dvNccGsr(0)("FillDisc")))
                                PrintHelper.ReplaceText(wordDoc, "[SIT]", Helper.MakeStringValid(dvNccGsr(0)("SITimer")))
                                PrintHelper.ReplaceText(wordDoc, "[CertType]", Helper.MakeStringValid(dvNccGsr(0)("CertificateType")))
                            Else
                                PrintHelper.DeleteTableBookmark(wordDoc, "[NCC]")
                            End If
                        Else
                            PrintHelper.DeleteTableBookmark(wordDoc, "[EngineerNotes]")
                            PrintHelper.DeleteTableBookmark(wordDoc, "[Como]")
                            PrintHelper.DeleteTableBookmark(wordDoc, "[NCC]")

                        End If

                        Dim para As WP.Paragraph = wordDoc.MainDocumentPart.Document.Body.ChildElements.First(Of WP.Paragraph)()
                        If para.ParagraphProperties Is Nothing Then para.ParagraphProperties = New WP.ParagraphProperties
                        para.ParagraphProperties.PageBreakBefore = New WP.PageBreakBefore()
                        wordDoc.MainDocumentPart.Document.Save()

                        doc = cmm.ToArray()
                    End Using
                End Using
                Return doc
            End Function

            Public Function LsrHeaderLetter(ByVal oSite As Sites.Site, ByVal oSiteHq As Sites.Site, ByVal visitDate As DateTime, ByVal mm As MemoryStream) As Byte()
                Dim finalDoc As Byte() = Nothing
                If oSiteHq Is Nothing Then oSiteHq = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)
                Dim coverLetterTemplate As String = Application.StartupPath & "\Templates\GSR\GSRCoveringLetter.docx"
                Dim cGoldenRule As String = GetDocumentGoldenRule(coverLetterTemplate, oSite.SiteID)
                Dim cbyteArray As Byte() = File.ReadAllBytes(coverLetterTemplate)
                Dim cmm As MemoryStream = New MemoryStream
                Using (cmm)
                    cmm.Write(cbyteArray, 0, cbyteArray.Length)
                    Dim cwordDoc As WordprocessingDocument = WordprocessingDocument.Open(cmm, True)
                    Using (cwordDoc)

                        PrintHelper.ReplaceText(cwordDoc, "[GoldenRule]", cGoldenRule)
                        AddCompanyDetails(cwordDoc, True, False, False)
                        If oSiteHq.CustomerID = Enums.Customer.Domestic Then
                            PrintHelper.ReplaceText(cwordDoc, "[CustomerName]", "the person(s) responsible for your property")
                        Else
                            PrintHelper.ReplaceText(cwordDoc, "[CustomerName]", oSiteHq.Name)
                        End If
                        PrintHelper.ReplaceText(cwordDoc, "[SiteName]", oSite.Name.Replace("T1", "").Trim)
                        PrintHelper.ReplaceText(cwordDoc, "[Name]", Helper.ToTitleCase(oSite.Name.Replace("T1", "").Trim))
                        PrintHelper.ReplaceText(cwordDoc, "[Address1]", oSite.Address1)
                        PrintHelper.ReplaceText(cwordDoc, "[Address2]", oSite.Address2)
                        PrintHelper.ReplaceText(cwordDoc, "[Address3]", oSite.Address3)
                        PrintHelper.ReplaceText(cwordDoc, "[Address4]", oSite.Address4)
                        PrintHelper.ReplaceText(cwordDoc, "[Address5]", oSite.Address5)
                        PrintHelper.ReplaceText(cwordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode))
                        PrintHelper.ReplaceText(cwordDoc, "[Date]", Now.ToShortDateString())
                        PrintHelper.ReplaceText(cwordDoc, "[ServiceDate]", visitDate.ToShortDateString)
                        Dim telNo As String = If(oSiteHq.CustomerID = Enums.Customer.Victory, "01603 309600", "01603 258617")
                        PrintHelper.ReplaceText(cwordDoc, "[TelNo]", telNo)

                        Dim para As WP.Paragraph =
                        cwordDoc.MainDocumentPart.Document.Body.
                        ChildElements.First(Of WP.Paragraph)()

                        If para.ParagraphProperties Is Nothing Then
                            para.ParagraphProperties = New WP.ParagraphProperties
                        End If

                        para.ParagraphProperties.PageBreakBefore = New WP.PageBreakBefore()

                    End Using
                    If mm IsNot Nothing Then
                        Dim files As New List(Of MemoryStream) From {mm, cmm}
                        finalDoc = PrintHelper.CombineDocs(files)
                    Else
                        finalDoc = cmm.ToArray()
                    End If
                End Using
                Return finalDoc
            End Function

            Private Function Add_Appliances_PreVisit(ByVal wordDoc As Word.Document, ByVal numberOfAppliances As Integer,
                                        ByVal currentPage As Integer, ByVal numberOfPages As Integer,
                                        ByVal Assets As DataTable, ByVal faults As DataTable,
                                        ByVal nextTableForPrint As Integer, Optional ByVal NCCTemplate As Boolean = False) As Integer

                Dim numberToReturn As Integer = numberOfAppliances
                Dim rowNo As Integer = 0
                Dim actualNo As Integer = 0

                Dim ApplianceRows As Integer = 0
                If NCCTemplate Then
                    ApplianceRows = 4
                Else
                    ApplianceRows = 4
                End If

                For i As Integer = (numberOfAppliances - 1) To (numberOfAppliances - ApplianceRows) Step -1
                    rowNo += 1
                    actualNo += 1

                    Try
                        Dim emptyWord As String = ""
                        'This should be not Appliance Tested - not landlord appliance
                        Dim llAppliance As PickLists.PickList
                        llAppliance = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("ApplianceTestedID"))
                        If Not llAppliance Is Nothing Then
                            If llAppliance.Name = "No" Then
                                emptyWord = "Not Tested"
                            End If
                        End If

                        For Each wordField As System.Text.RegularExpressions.Match In GetTemplateFields(wordDoc.Content.Text)
                            Select Case wordField.Value
                                Case "[" & (rowNo).ToString & "A]"
                                    ReplaceText(wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("Location")))
                                Case "[" & (rowNo).ToString & "B]"
                                    ReplaceText(wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("Type")))
                                Case "[" & (rowNo).ToString & "C]"
                                    ReplaceText(wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("Make")))
                                Case "[" & (rowNo).ToString & "D]"
                                    ReplaceText(wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("Model")))
                                Case "[" & (rowNo).ToString & "E]"
                                    Dim oPicklist As PickLists.PickList
                                    oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("LandlordsApplianceID"))
                                    If Not oPicklist.Name Is Nothing Then
                                        ReplaceText(wordDoc, wordField.Value, oPicklist.Name)
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, "")
                                    End If
                                Case "[" & (rowNo).ToString & "F]"
                                    Dim oPicklist As PickLists.PickList
                                    oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("ApplianceServiceOrInspectedID"))
                                    If Not oPicklist Is Nothing Then
                                        ReplaceText(wordDoc, wordField.Value, oPicklist.Name)
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "G]"
                                    Dim oPicklist As PickLists.PickList
                                    oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("ApplianceSafeID"))
                                    If Not oPicklist Is Nothing Then
                                        ReplaceText(wordDoc, wordField.Value, oPicklist.Name)
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "H]"
                                    Dim oPicklist As PickLists.PickList
                                    oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("FlueTerminationSatisfactoryID"))
                                    If Not oPicklist Is Nothing Then
                                        ReplaceText(wordDoc, wordField.Value, oPicklist.Name)
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "I]"
                                    Dim oPicklist As PickLists.PickList
                                    oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("VisualConditionOfFlueSatisfactoryID"))
                                    If Not oPicklist Is Nothing Then
                                        ReplaceText(wordDoc, wordField.Value, oPicklist.Name)
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "J]"
                                    Dim oPicklist As PickLists.PickList
                                    oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("FlueFlowTestID"))
                                    If Not oPicklist Is Nothing Then
                                        ReplaceText(wordDoc, wordField.Value, oPicklist.Name)
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "K]"
                                    Dim oPicklist As PickLists.PickList
                                    oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("SpillageTestID"))
                                    If Not oPicklist Is Nothing Then
                                        ReplaceText(wordDoc, wordField.Value, oPicklist.Name)
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "L]"
                                    Dim oPicklist As PickLists.PickList
                                    oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("VentilationProvisionSatisfactoryID"))
                                    If Not oPicklist Is Nothing Then
                                        ReplaceText(wordDoc, wordField.Value, oPicklist.Name)
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "M]"
                                    Dim oPicklist As PickLists.PickList
                                    oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("SafetyDeviceOperationID"))
                                    If Not oPicklist Is Nothing Then
                                        ReplaceText(wordDoc, wordField.Value, oPicklist.Name)
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "N]"
                                    If emptyWord.Length = 0 Then
                                        If Helper.MakeDoubleValid(Assets.Rows(i).Item("InletStaticPressure")) = 0 Then
                                            ReplaceText(wordDoc, wordField.Value, "N/A")
                                        Else
                                            ReplaceText(wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("InletStaticPressure")))
                                        End If
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "O]"
                                    If emptyWord.Length = 0 Then
                                        If Helper.MakeDoubleValid(Assets.Rows(i).Item("InletWorkingPressure")) = 0 Then
                                            ReplaceText(wordDoc, wordField.Value, "N/A")
                                        Else
                                            ReplaceText(wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("InletWorkingPressure")))
                                        End If
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "P]"
                                    If emptyWord.Length = 0 Then
                                        If Helper.MakeDoubleValid(Assets.Rows(i).Item("MinBurnerPressure")) = 0 Then
                                            ReplaceText(wordDoc, wordField.Value, "N/A")
                                        Else
                                            ReplaceText(wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("MinBurnerPressure")))
                                        End If
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "Q]"
                                    If emptyWord.Length = 0 Then
                                        If Helper.MakeDoubleValid(Assets.Rows(i).Item("MaxBurnerPressure")) = 0 Then
                                            ReplaceText(wordDoc, wordField.Value, "N/A")
                                        Else
                                            ReplaceText(wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("MaxBurnerPressure")))
                                        End If
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "R]"
                                    If emptyWord.Length = 0 Then
                                        If Helper.MakeDoubleValid(Assets.Rows(i).Item("CO2")) = 0 Then
                                            ReplaceText(wordDoc, wordField.Value, "N/A")
                                        Else
                                            ReplaceText(wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("CO2")))
                                        End If
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "S]"
                                    If emptyWord.Length = 0 Then
                                        If Helper.MakeDoubleValid(Assets.Rows(i).Item("CO2CORatio")) = 0 Then
                                            ReplaceText(wordDoc, wordField.Value, "N/A")
                                        Else
                                            ReplaceText(wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("CO2CORatio")))
                                        End If
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "T]"
                                    If emptyWord.Length = 0 Then
                                        ReplaceText(wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("GCNumber")))
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "U]"
                                    If emptyWord.Length = 0 Then
                                        ReplaceText(wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("SerialNum")))
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "V]"
                                    If emptyWord.Length = 0 Then
                                        If Helper.MakeDoubleValid(Assets.Rows(i).Item("DHWFlowRate")) = 0 Then
                                            ReplaceText(wordDoc, wordField.Value, "N/A")
                                        Else
                                            ReplaceText(wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("DHWFlowRate")))
                                        End If
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "W]"
                                    If emptyWord.Length = 0 Then
                                        If Helper.MakeDoubleValid(Assets.Rows(i).Item("ColdWaterTemp")) = 0 Then
                                            ReplaceText(wordDoc, wordField.Value, "N/A")
                                        Else
                                            ReplaceText(wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("ColdWaterTemp")))
                                        End If
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                                Case "[" & (rowNo).ToString & "X]"
                                    If emptyWord.Length = 0 Then
                                        If Helper.MakeDoubleValid(Assets.Rows(i).Item("DHWTemp")) = 0 Then
                                            ReplaceText(wordDoc, wordField.Value, "N/A")
                                        Else
                                            ReplaceText(wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("DHWTemp")))
                                        End If
                                    Else
                                        ReplaceText(wordDoc, wordField.Value, emptyWord)
                                    End If
                            End Select
                        Next
                        numberToReturn -= 1
                    Catch ex As Exception
                        actualNo -= 1

                        For Each wordField As System.Text.RegularExpressions.Match In GetTemplateFields(wordDoc.Content.Text)
                            Select Case wordField.Value
                                Case "[" & (rowNo).ToString & "A]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "B]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "C]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "D]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "E]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "F]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "G]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "H]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "I]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "J]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "K]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "L]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "M]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "N]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "O]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "P]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "Q]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "R]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "S]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "T]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "U]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "V]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "W]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                                Case "[" & (rowNo).ToString & "X]"
                                    ReplaceText(wordDoc, wordField.Value, "")
                            End Select
                        Next
                        numberToReturn = 0
                    End Try

                Next

                Return numberToReturn

            End Function

            Private Sub AddAppliancesBatch(ByVal wordDoc As WordprocessingDocument, ByVal numberOfAppliances As Integer, ByVal EngineerVisitAssetWorksheets As DataTable, ByVal faults As DataTable, Optional ByVal NCCTemplate As Boolean = False, Optional ByVal Fuel As Integer = 0)
                Dim noOfApp As Integer = numberOfAppliances

                Dim rowNo As Integer = 0
                Dim actualNo As Integer = 0

                Dim nextFaultRowForPrint As Integer = 0
                Dim ApplianceRows As Integer = 0

                If Fuel = Enums.WorksheetFuelTypes.Unvented Then
                    ApplianceRows = 12
                ElseIf Fuel = Enums.WorksheetFuelTypes.SolidFuel Then
                    ApplianceRows = 2
                Else
                    ApplianceRows = 4
                End If

                For i As Integer = 0 To (ApplianceRows - 1) Step 1
                    If Not faults Is Nothing Then
                        Try
                            If faults.Rows.Count = 0 And Fuel = 3 Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "No")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "No")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "No")
                            Else
                                For Each faultRow As DataRow In faults.Select("AssetID = " & EngineerVisitAssetWorksheets.Rows(i).Item("AssetID"))
                                    If Not faultRow.Item("ADDEDTOPRINTOUT") = True Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AA" & nextFaultRowForPrint, CStr(faultRow.Item("FullReason")).Trim)
                                        If Fuel = 2 Or Fuel = 0 Or Fuel = 5 Or Fuel = 9 Or Fuel = 7 Then
                                            If faultRow.Item("WarningNoticeIssued") Then
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" & nextFaultRowForPrint, "Yes")
                                            Else
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" & nextFaultRowForPrint, "No")
                                            End If
                                        ElseIf Fuel = 3 Then
                                            If faultRow.Item("WarningNoticeIssued") Then
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "Yes")
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "Yes")
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "Yes")
                                            Else
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "No")
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "No")
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "No")
                                            End If
                                        End If
                                        If Fuel <> 3 Then
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DD" & nextFaultRowForPrint, CStr(faultRow.Item("ActionTaken")))
                                        End If

                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CC" & nextFaultRowForPrint, faultRow.Item("Disconnected"))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "EE" & nextFaultRowForPrint, CStr(faultRow.Item("Comments")))

                                        faultRow.Item("ADDEDTOPRINTOUT") = True
                                        If Fuel = 1 Then nextFaultRowForPrint += 1
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                        End Try
                    End If

                    nextFaultRowForPrint += 1
                    rowNo += 1
                    actualNo += 1
                    Try
                        Dim dvAssetWorksheet As DataView = DB.EngineerVisitAssetWorkSheet.Get_Friendly(Helper.MakeIntegerValid(EngineerVisitAssetWorksheets.Rows(i).Item("EngineerVisitAssetWorkSheetID")))

                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AAA" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceTested")))
                        If Fuel = Enums.WorksheetFuelTypes.Unvented Then
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "A" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Type")))
                        Else
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "A" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Location")))
                        End If

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.Gas, Enums.WorksheetFuelTypes.Oil
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Type")))
                            Case Enums.WorksheetFuelTypes.Unvented
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Make")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Reading")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.Unvented
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Model")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Make")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.HIU, Enums.WorksheetFuelTypes.ASHP, Enums.WorksheetFuelTypes.GSHP
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Model") & " / " & dvAssetWorksheet(0)("SerialNum")))
                            Case Enums.WorksheetFuelTypes.Unvented
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("MaxBurnerPressure")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Model")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.Unvented, Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "E" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("InletStaticPressure")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "E" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("LandlordsAppliance")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "F" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("FlueTerminationSatisfactory")))
                            Case Enums.WorksheetFuelTypes.Unvented
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "F" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("DHWFlowRate")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "F" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceServiceOrInspected")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "G" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("VisualConditionOfFlueSatisfactory")))
                            Case Enums.WorksheetFuelTypes.Unvented
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "G" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ColdWaterTemp")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "G" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceSafe")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "H" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("FlueFlowTest")))
                            Case Enums.WorksheetFuelTypes.Unvented, Enums.WorksheetFuelTypes.ASHP, Enums.WorksheetFuelTypes.GSHP
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "H" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Discharge")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "H" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("FlueTerminationSatisfactory")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "I" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("SpillageTest")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "I" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("VisualConditionOfFlueSatisfactory")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel, Enums.WorksheetFuelTypes.HIU, Enums.WorksheetFuelTypes.ASHP, Enums.WorksheetFuelTypes.GSHP
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("VentilationProvisionSatisfactory")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("FlueFlowTest")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("SafetyDeviceOperation")))
                            Case Enums.WorksheetFuelTypes.HIU
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Nozzle")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("SpillageTest")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("LandlordsAppliance")))
                            Case Enums.WorksheetFuelTypes.HIU
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("SpillageTest")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("VentilationProvisionSatisfactory")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceTested")))
                            Case Enums.WorksheetFuelTypes.HIU
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("SpillageTest")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("SafetyDeviceOperation")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.Gas, Enums.WorksheetFuelTypes.Oil
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("InletStaticPressure")))
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceServiceOrInspected")))
                            Case Enums.WorksheetFuelTypes.Unvented
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceSafe")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Overall")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.Gas, Enums.WorksheetFuelTypes.Oil
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("InletWorkingPressure")))
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Discharge")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("SweepOutcome")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "P" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("SweepOutcome")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "P" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("MinBurnerPressure")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("FlueType")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("MaxBurnerPressure")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "R" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("DHWFlowRate")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "R" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("CO2")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "S" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("BurModel")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "S" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("CO2CORatio")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.Gas
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "T" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("BurMake")))
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "T" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Overall")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "T" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("GCNumber")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.Gas
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "U" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("BurModel")))
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "U" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ColdWaterTempString")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "U" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("SerialNum")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "V" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("DHWTempString")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "V" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("DHWFlowRate")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "W" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("InletWorkingPressureString")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "W" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ColdWaterTemp")))
                        End Select

                        Select Case Fuel
                            Case Enums.WorksheetFuelTypes.SolidFuel
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("MinBurnerPressureString")))
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("DHWTemp")))
                        End Select

                        PrintHelper.ReplaceGSRBookmark(wordDoc, "QQ" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("MinBurnerPressure")))
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "RR" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Nozzle")))
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SS" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("BurMake")))
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "TT" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("BurModel")))

                        Select Case Helper.MakeIntegerValid(dvAssetWorksheet(0)("TankID"))
                            Case 0
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" & (rowNo).ToString, "N/A")
                            Case 1
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" & (rowNo).ToString, "Plastic")
                            Case 2
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" & (rowNo).ToString, "Bunded")
                            Case 3
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" & (rowNo).ToString, "Metal")
                            Case Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" & (rowNo).ToString, "")
                        End Select

                        PrintHelper.ReplaceGSRBookmark(wordDoc, "VV" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("FlueType")))
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "WW" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("GasType")))
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Y" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceSafe")))

                        Dim warningCount As Integer = 0
                        Dim warningOutput As String = ""
                        If faults?.Rows.Count > 0 Then
                            Dim drWarnings As DataRow() = faults.Select("AssetID = " & dvAssetWorksheet(0)("AssetID") & " AND WarningNoticeIssued = 1")
                            If drWarnings?.Length > 0 Then warningCount = drWarnings.Length
                        End If

                        If warningCount > 0 Then
                            warningOutput = "Yes"
                        Else
                            warningOutput = "No"
                        End If
                        If Fuel = Enums.WorksheetFuelTypes.SolidFuel Then
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" & (rowNo).ToString, warningOutput)
                        Else
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" & (rowNo).ToString, warningCount.ToString())
                        End If

                        If Fuel = Enums.WorksheetFuelTypes.SolidFuel AndAlso rowNo = 1 Then
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "KS" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("CO2String")))
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "IS" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("CO2CORatioString")))
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "CL" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("BurMakeString")))
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "IH" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("NozzleString")))
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AF" & (rowNo).ToString, Helper.MakeStringValid(dvAssetWorksheet(0)("Tank")))
                        End If

                        noOfApp -= 1
                    Catch ex As Exception
                        actualNo -= 1
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AAA" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "A" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "B" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "C" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "D" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "E" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "F" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "G" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "H" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "I" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "J" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "K" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "L" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "M" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "N" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "O" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "P" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "R" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "S" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "T" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "U" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "V" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "W" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "X" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "QQ" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Y" & (rowNo).ToString, "")
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" & (rowNo).ToString, "")

                        noOfApp = 0
                    End Try

                Next

                Dim NewPageCompareNo As Integer = 0
                NewPageCompareNo = 5

                If noOfApp = 0 Then
                    'LETS PUT NONE APPLIANCE DEFECTS IN
                    If PrintType <> Enums.SystemDocumentType.COMSR Then
                        If Not faults Is Nothing Then
                            Try
                                'For Each faultRow As DataRow In faults.Select("AssetID = 0")
                                For Each faultRow As DataRow In faults.Select("ADDEDTOPRINTOUT = 0 AND (AssetID IS NULL OR AssetID = 0)")
                                    '    If CInt(faultRow("AssetID")) = 0 Then
                                    If actualNo = NewPageCompareNo Then
                                        'NEED A NEW PAGE

                                        nextFaultRowForPrint = 0
                                    End If
                                    If Not faultRow.Item("ADDEDTOPRINTOUT") = True Then
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AA" & (nextFaultRowForPrint).ToString, CStr(faultRow.Item("FullReason")).Trim)
                                        If Fuel = 2 Or Fuel = 0 Or Fuel = 5 Or Fuel = 9 Or Fuel = 7 Then 'gas/others/ashp/HIU
                                            If faultRow.Item("WarningNoticeIssued") Then
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" & (nextFaultRowForPrint).ToString, "Yes")
                                            Else
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" & (nextFaultRowForPrint).ToString, "No")
                                            End If

                                        ElseIf Fuel = 3 Then
                                            If faultRow.Item("WarningNoticeIssued") Then
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "Yes")
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "Yes")
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "Yes")
                                            Else
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "No")
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "No")
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "No")
                                            End If
                                        End If
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CC" & (nextFaultRowForPrint).ToString, faultRow.Item("Disconnected"))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "DD" & (nextFaultRowForPrint).ToString, CStr(faultRow.Item("ActionTaken")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "EE" & (nextFaultRowForPrint).ToString, CStr(faultRow.Item("Comments")))
                                        faultRow.Item("ADDEDTOPRINTOUT") = True
                                        nextFaultRowForPrint += 1
                                    End If
                                    actualNo = 1
                                Next
                            Catch ex As Exception
                                'no faults for this row so dont do anything
                            End Try
                        Else
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB" & (nextFaultRowForPrint).ToString, "")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "")
                        End If
                    Else

                        If Not faults Is Nothing Then
                            Try
                                Dim warningNotice As Boolean = False
                                Dim RemidialString As String = ""
                                For Each faultRow As DataRow In faults.Select("ADDEDTOPRINTOUT = 0")
                                    If CInt(faultRow("AssetID")) = 0 Then

                                        If Not faultRow.Item("ADDEDTOPRINTOUT") = True Then
                                            RemidialString += CStr(faultRow.Item("FullReason")).Trim
                                            RemidialString += " - "
                                            RemidialString += CStr(faultRow.Item("ActionTaken")) & " ,  "
                                            If faultRow.Item("WarningNoticeIssued") Then
                                                warningNotice = True
                                            End If
                                            faultRow.Item("ADDEDTOPRINTOUT") = True
                                            nextFaultRowForPrint += 1
                                        End If
                                    End If
                                    actualNo = 1
                                Next
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", RemidialString)
                            Catch ex As Exception
                                'no faults for this row so dont do anything
                            End Try
                        Else
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB" & (nextFaultRowForPrint).ToString, "")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "")
                        End If
                    End If
                End If
            End Sub

            Private Function SiteVisitReport(ByVal engineerVisit As EngineerVisits.EngineerVisit, ByVal savePath As String) As Boolean
                Try
                    engineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisit.EngineerVisitID)
                    Dim job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(engineerVisit.EngineerVisitID)
                    Dim site As Sites.Site = DB.Sites.Get(job.PropertyID)
                    Dim customer As Customers.Customer = DB.Customer.Customer_Get(site.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(engineerVisit.EngineerID)
                    Dim visitCharge As EngineerVisitCharges.EngineerVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Get(engineerVisit.EngineerVisitID)
                    Dim siteHq As Sites.Site = DB.Sites.Get(site.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)

                    Dim startDate As DateTime = engineerVisit.StartDateTime
                    Dim endDate As DateTime = engineerVisit.EndDateTime
                    If startDate = Nothing Then startDate = engineerVisit.ManualEntryOn
                    If endDate = Nothing Then endDate = engineerVisit.ManualEntryOn

                    Dim imageIndex As Integer = 101
                    Dim total As Double = 0.0
                    Dim vat As Double = 0.0

                    If visitCharge IsNot Nothing Then
                        Select Case visitCharge.ChargeTypeID
                            Case CInt(Enums.JobChargingType.QuoteValue)
                                If job.JobDefinitionEnumID = CInt(Enums.JobDefinition.Quoted) Then
                                    total = DB.QuoteJob.Get(job.QuoteID).GrandTotal
                                End If
                            Case CInt(Enums.JobChargingType.JobValue)
                                total = visitCharge.JobValue
                            Case CInt(Enums.JobChargingType.PercentageOfQuote)
                                If job.JobDefinitionEnumID = CInt(Enums.JobDefinition.Quoted) Then
                                    total = ((visitCharge.Charge / 100) * DB.QuoteJob.Get(job.QuoteID).GrandTotal)
                                End If
                        End Select
                        vat = DB.EngineerVisits.EngineerCharge_VAT_Amount(visitCharge.EngineerVisitChargeID, startDate, total)
                    End If

                    Dim fullDocument As New List(Of Byte())

                    Dim usingdoc As String = Application.StartupPath & "\Templates\SiteVisitReport.docx"
                    Dim byteArray As Byte() = File.ReadAllBytes(usingdoc)
                    Dim mm As MemoryStream = New MemoryStream
                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)

                            AddCompanyDetails(wordDoc, True)

                            PrintHelper.ReplaceText(wordDoc, "[JobVisitNumber]", job.JobNumber & "" & engineerVisit.EngineerVisitID)
                            PrintHelper.ReplaceText(wordDoc, "[VisitDate]", startDate.ToLongDateString)
                            PrintHelper.ReplaceText(wordDoc, "[GasSafeIDNo]", Helper.MakeStringValid(engineer?.GasSafeNo))
                            PrintHelper.ReplaceText(wordDoc, "[JobCustomerName]", Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(engineerVisit.SignatureSelectedID)?.Name) & " " & engineerVisit.CustomerName)
                            PrintHelper.ReplaceText(wordDoc, "[JobAddressName]", site.Name)
                            PrintHelper.ReplaceText(wordDoc, "[JobAddress1]", site.Address1)
                            PrintHelper.ReplaceText(wordDoc, "[JobAddress2]", site.Address2)
                            PrintHelper.ReplaceText(wordDoc, "[JobAddress3]", site.Address3)
                            PrintHelper.ReplaceText(wordDoc, "[JobPostCode]", Helper.FormatPostcode(site.Postcode))
                            PrintHelper.ReplaceText(wordDoc, "[JobTelNo]", site.TelephoneNum)
                            PrintHelper.ReplaceText(wordDoc, "[LandLordAddress3]", "")

                            If Not siteHq Is Nothing Then
                                Dim strAddress As String = String.Empty

                                If siteHq.Address1.Length > 0 Then
                                    strAddress += siteHq.Address1 & ", "
                                End If

                                If siteHq.Address2.Length > 0 Then
                                    strAddress += siteHq.Address2 & ", "
                                End If

                                If strAddress.Length > 0 Then
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2)
                                End If

                                Dim strAddress1 As String = String.Empty

                                If siteHq.Address3.Length > 0 Then
                                    strAddress1 += siteHq.Address3 & ", "
                                End If

                                If siteHq.Address4.Length > 0 Then
                                    strAddress1 += siteHq.Address4 & ", "
                                End If

                                If siteHq.Address5.Length > 0 Then
                                    strAddress1 += siteHq.Address5 & ", "
                                End If

                                If strAddress.Length > 0 And strAddress1.Length > 1 Then
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2)
                                End If

                                Dim customerName As String = If(siteHq.CustomerID <> Enums.Customer.Domestic, customer.Name, "")

                                PrintHelper.ReplaceText(wordDoc, "[LandLordName]", customerName)
                                PrintHelper.ReplaceText(wordDoc, "[LandLordAddress1]", strAddress)
                                PrintHelper.ReplaceText(wordDoc, "[LandLordAddress2]", strAddress1)
                                PrintHelper.ReplaceText(wordDoc, "[LLPostcode]", Helper.FormatPostcode(siteHq.Postcode))
                                PrintHelper.ReplaceText(wordDoc, "[LLTelNo]", siteHq.TelephoneNum)
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[LandLordName]", "")
                                PrintHelper.ReplaceText(wordDoc, "[LandLordAddress1]", "")
                                PrintHelper.ReplaceText(wordDoc, "[LandLordAddress2]", "")
                                PrintHelper.ReplaceText(wordDoc, "[LLPostcode]", "")
                                PrintHelper.ReplaceText(wordDoc, "[LLTelNo]", "")
                            End If

                            Dim strJOW As String = String.Empty
                            For Each jow As JobOfWorks.JobOfWork In job.JobOfWorks
                                strJOW += jow.PONumber & "/"
                            Next
                            If strJOW.Length > 0 Then
                                strJOW = strJOW.Substring(0, strJOW.Length - 1)
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[PO]", strJOW)
                            PrintHelper.ReplaceText(wordDoc, "[From]", startDate.ToShortTimeString)
                            PrintHelper.ReplaceText(wordDoc, "[To]", endDate.ToShortTimeString)

                            Dim dvFaults As DataView = DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(engineerVisit.EngineerVisitID)
                            Dim warningNotices As DataRow() = (From r In dvFaults.Table.AsEnumerable() Where r.Field(Of Boolean)("WarningNoticeIssued") = True Select r).ToArray()
                            Dim warningNotice As String = If(warningNotices.Count > 0, "Yes", "No")
                            PrintHelper.ReplaceText(wordDoc, "[Warning]", warningNotice)

                            PrintHelper.ReplaceText(wordDoc, "[Engineer]", Helper.MakeStringValid(engineer?.Name))
                            PrintHelper.ReplaceText(wordDoc, "[Outcome]", engineerVisit.VisitOutcome)
                            PrintHelper.ReplaceText(wordDoc, "[PaymentMethod]", Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(engineerVisit.PaymentMethodID)?.Name))
                            PrintHelper.ReplaceText(wordDoc, "[Total]", If(total = 0, "", total.ToString("c")))
                            PrintHelper.ReplaceText(wordDoc, "[VAT]", If(vat = 0, "", vat.ToString("c")))
                            PrintHelper.ReplaceText(wordDoc, "[AmntDue]", If(total + vat = 0, "", (total + vat).ToString("c")))
                            PrintHelper.ReplaceText(wordDoc, "[OutcomeDetails]", engineerVisit.OutcomeDetails)
                            PrintHelper.ReplaceText(wordDoc, "[WorkRequired]", engineerVisit.NotesToEngineer)

                            If engineerVisit.EngineerSignature Is Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "")
                            Else
                                Dim engSig As Bitmap = New Bitmap(New IO.MemoryStream(engineerVisit.EngineerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\EngSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            End If

                            If engineerVisit.CustomerSignature Is Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig", "")
                            Else
                                Dim custSig As Bitmap = New Bitmap(New IO.MemoryStream(engineerVisit.CustomerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig", custSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            End If

                            Dim dt As New DataTable
                            dt.Columns.Add("Part No")
                            dt.Columns.Add("Description")
                            dt.Columns.Add("Qty")

                            If engineerVisit.PartsAndProductsUsed.Table IsNot Nothing AndAlso engineerVisit.PartsAndProductsUsed.Table.Rows.Count > 0 Then
                                For Each r As DataRow In engineerVisit.PartsAndProductsUsed.Table.Rows
                                    Dim nr As DataRow
                                    nr = dt.NewRow
                                    nr("Part No") = r("Number")
                                    nr("Description") = r("Name")
                                    nr("Qty") = r("Quantity")
                                    dt.Rows.Add(nr)
                                Next r
                            End If

                            PrintHelper.AddRowsToTable(wordDoc, "[Parts]", dt, "Arial", "16", 1)

                            Dim dtTimeSheet As New DataTable
                            dtTimeSheet.Columns.Add("Start")
                            dtTimeSheet.Columns.Add("End")
                            dtTimeSheet.Columns.Add("Type")
                            dtTimeSheet.Columns.Add("Comments")

                            If engineerVisit.TimeSheets.Table IsNot Nothing AndAlso engineerVisit.TimeSheets.Table.Rows.Count > 0 Then
                                For Each r As DataRow In engineerVisit.TimeSheets.Table.Rows
                                    Dim nr As DataRow
                                    nr = dtTimeSheet.NewRow
                                    nr("Start") = Helper.MakeDateTimeValid(r("StartDateTime")).ToString("HH:mm")
                                    nr("End") = Helper.MakeDateTimeValid(r("EndDateTime")).ToString("HH:mm")
                                    nr("Type") = r("TimeSheetType")
                                    nr("Comments") = r("Comments")
                                    dtTimeSheet.Rows.Add(nr)
                                Next r
                            End If

                            PrintHelper.AddRowsToTable(wordDoc, "[TimeSheets]", dtTimeSheet, "Arial", "16", 1)
                        End Using

                        fullDocument.Add(mm.ToArray())
                        PrintGSR(engineerVisit.EngineerVisitID, fullDocument, "", True)

                        If fullDocument.Count > 0 Then
                            File.WriteAllBytes(savePath, PrintHelper.CombineDocs(fullDocument))

                            PrintHelper.RemoveSpacingInDoc(savePath)
                            If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor) Then savePath = PrintHelper.LockFile(savePath, True)
                        End If
                    End Using

                    Dim cbyteArray As Byte() = File.ReadAllBytes(savePath)
                    Dim cmm As MemoryStream = New MemoryStream
                    Using (cmm)
                        cmm.Write(cbyteArray, 0, cbyteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(cmm, True)
                        Using (wordDoc)
                            PrintHelper.ReplaceText(wordDoc, "Landlord’s appliance", "Appliance")
                            PrintHelper.ReplaceText(wordDoc, "Landlord’s Details", "Details")
                            PrintHelper.ReplaceText(wordDoc, "LANDLORD", "")
                            wordDoc.MainDocumentPart.Document.Save()
                        End Using

                        Directory.CreateDirectory(Path.GetDirectoryName(savePath))
                        If File.Exists(savePath) Then File.Delete(savePath)

                        Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                        cmm.Position = 0
                        Using (fileStream)
                            cmm.WriteTo(fileStream)
                        End Using
                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Sub AddCompanyDetails(ByVal doc As WordprocessingDocument, ByVal useLogo As Boolean, Optional ByVal centreLogo As Boolean = False, Optional ByVal isCommercial As Boolean = False)
                Dim companyDetails As CompanyDetails.CompanyDetails = DB.CompanyDetails.Get()

                PrintHelper.ReplaceText(doc, "[CompanyName]", companyDetails.Name)
                PrintHelper.ReplaceText(doc, "[CompanyAddress1]", companyDetails.Address1)
                PrintHelper.ReplaceText(doc, "[CompanyAddress2]", companyDetails.Address2)
                PrintHelper.ReplaceText(doc, "[CompanyAddress3]", companyDetails.Address3)
                PrintHelper.ReplaceText(doc, "[CompanyAddress4]", companyDetails.Address4)
                PrintHelper.ReplaceText(doc, "[CompanyAddress5]", companyDetails.Address5)
                PrintHelper.ReplaceText(doc, "[CompanyPostcode]", Helper.MakeStringValid(companyDetails.Postcode))
                PrintHelper.ReplaceText(doc, "[CompanyTelephoneNumber]", companyDetails.TelephoneNumber)
                PrintHelper.ReplaceText(doc, "[CompanyWebsite]", companyDetails.Website)
                PrintHelper.ReplaceText(doc, "[CompanyEmail]", companyDetails.EmailAddress)
                PrintHelper.ReplaceText(doc, "[CompanySortCode]", companyDetails.SortCode)
                PrintHelper.ReplaceText(doc, "[CompanyAccountNumber]", companyDetails.AccountNumber)
                PrintHelper.ReplaceText(doc, "[CompanyNumber]", companyDetails.CompanyNumber)
                PrintHelper.ReplaceText(doc, "[CompanyVatNumber]", companyDetails.VatNumber)

                If useLogo Then
                    Dim logo As Bitmap = Nothing
                    If IsRFT Then
                        logo = Global.FSM.My.Resources.Resources.rft_logo
                    ElseIf IsGasway Then
                        logo = If(isCommercial, Global.FSM.My.Resources.Resources.GC_Logo, Global.FSM.My.Resources.Resources.GW_Logo)
                    ElseIf IsBlueflame Then
                        logo = Global.FSM.My.Resources.Resources.Blueflame
                    End If
                    Dim imgSavePath As String = Application.StartupPath & "\TEMP\companyLogo.jpg"
                    PrintHelper.ReplaceBookmarkWithImage(doc, "Logo", logo, imgSavePath, 100, centreLogo)
                End If
            End Sub

            Private Function JobContactLetter(ByVal job As Jobs.Job) As Boolean
                Try

                    Dim oSite As Sites.Site = DB.Sites.Get(job.PropertyID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)

                    Dim visitDate As String = Me.DetailsToPrint(1)

                    Dim currentPage As Integer = 1

                    For Each wordField As System.Text.RegularExpressions.Match In GetTemplateFields(WordDoc.Content.Text)
                        Select Case wordField.Value.ToLower

                            Case "[VisitDate]".ToLower
                                If visitDate = Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, "")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, visitDate)
                                End If

                            Case "[VisitDate2]".ToLower
                                If visitDate = Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, "")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, visitDate)
                                End If
                            Case "[SentDate]".ToLower
                                If visitDate = Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, "")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, Now.ToString("dd/MM/yyyy"))
                                End If

                            Case "[JobAddressName]".ToLower
                                ReplaceText(WordDoc, wordField.Value, oSite.Name)
                            Case "[Address1]".ToLower
                                ReplaceText(WordDoc, wordField.Value, oSite.Address1)
                            Case "[Address2]".ToLower

                                ReplaceText(WordDoc, wordField.Value, oSite.Address2)

                            Case "[Address3]".ToLower

                                If oSite.Address3.Length > 0 Then
                                    ReplaceText(WordDoc, wordField.Value, oSite.Address3)
                                ElseIf oSite.Address4.Length > 0 Then
                                    ReplaceText(WordDoc, wordField.Value, oSite.Address4)
                                Else
                                    ReplaceText(WordDoc, wordField.Value, oSite.Address5)
                                End If

                            Case "[Name]".ToLower

                                ReplaceText(WordDoc, wordField.Value, oSite.Name)

                            Case "[PostCode]".ToLower

                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.FormatPostcode(oSite.Postcode))

                        End Select
                    Next

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function COMSR(ByVal oEngineerVisit As EngineerVisits.EngineerVisit, ByVal oSite As Sites.Site, ByVal template As String, ByVal savePath As String, ByVal goldenRule As String,
                                   Optional ByVal fullDocument As List(Of Byte()) = Nothing, Optional ByVal addLsrHeaderLetter As Boolean = False) As Boolean
                Try
                    Dim Job As Jobs.Job =
                        DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                    Dim EngVisitCharge As EngineerVisitCharges.EngineerVisitCharge =
                        DB.EngineerVisitCharge.EngineerVisitCharge_Get(oEngineerVisit.EngineerVisitID)

                    Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = oEngineerVisit.ManualEntryOn
                    End If

                    Dim imageIndex As Integer = 100
                    Dim GSRs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(oEngineerVisit.EngineerVisitID)
                    Dim numberOfAppliances As Integer = GSRs.Table.Rows.Count

                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream

                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID & "_" & visitDate.ToString("ddMMyyyyhhmm") & "_" & "COMSR")
                            If Not oEngineerVisit.EngineerSignature Is Nothing Then
                                Dim engSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.EngineerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\EngSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "")
                            End If

                            Dim ComChecks As EngineerVisitAdditionals.EngineerVisitAdditional =
                                DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 0)

                            If Not oEngineerVisit.CustomerSignature Is Nothing Then
                                Dim custSig As Bitmap = New Bitmap(New MemoryStream(oEngineerVisit.CustomerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig", custSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig", "")
                            End If

                            Dim currentPage As Integer = 1
                            Dim ositeHQ As Sites.Site = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobNo", Job.JobNumber & "-" & oEngineerVisit.EngineerVisitID)

                            If engineer Is Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", engineer.GasSafeNo)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C", engineer.Name)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", engineer.Name)
                            End If

                            If visitDate = Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", visitDate.ToLongDateString)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", engineer.Name)
                            End If
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "E", oSite.Name, "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "F", oSite.Address1, "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "G", oSite.Address2, "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "H", Sys.Helper.FormatPostcode(oSite.Postcode), "8")

                            If Not ositeHQ Is Nothing Then
                                Dim strAddress As String = String.Empty
                                Dim strAddress1 As String = String.Empty

                                If ositeHQ.Address1.Length > 0 Then
                                    strAddress += ositeHQ.Address1 & ", "
                                End If

                                If ositeHQ.Address2.Length > 0 Then
                                    strAddress += ositeHQ.Address2 & ", "
                                End If

                                If strAddress.Length > 0 Then
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2)
                                End If

                                If ositeHQ.Address3.Length > 0 Then
                                    strAddress1 += ositeHQ.Address3 & ", "
                                End If

                                If ositeHQ.Address4.Length > 0 Then
                                    strAddress1 += ositeHQ.Address4 & ", "
                                End If

                                If strAddress1.Length > 0 Then
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", DB.Customer.Customer_Get(oSite.CustomerID).Name, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", strAddress, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", strAddress1, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "", "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", Sys.Helper.FormatPostcode(ositeHQ.Postcode), "8")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O", "")
                            End If

                            Dim warning As String = "No"
                            For Each row As DataRow In DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(oEngineerVisit.EngineerVisitID).Table.Rows
                                warning = "No"
                                If Helper.MakeBooleanValid(row.Item("WarningNoticeIssued")) Then
                                    warning = "Yes"
                                    Exit For
                                End If
                            Next
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", warning)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", warning)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", warning)

                            If oEngineerVisit.OutcomeDetails Is Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", oEngineerVisit.OutcomeDetails)
                            End If

                            If ComChecks IsNot Nothing Then
                                Dim selected As PickLists.PickList = DB.Picklists.Get_One_As_Object(ComChecks.Test1)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test2)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test3)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test4)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test5)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test6)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test7)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test8)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test9)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test10)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test111)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test112)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AL", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test113)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AM", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test114)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AN", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test115)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AO", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test116)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AP", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test117)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AQ", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test118)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AR", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test119)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AS", selected.Name)
                                AddAppliancesBatch(wordDoc, numberOfAppliances, GSRs.Table, Nothing)
                            Else
                                ShowMessage("Could not generate document : Missing Worksheet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return False
                            End If
                        End Using

                        If addLsrHeaderLetter Then
                            Dim lsrHeaderTemplate As Byte() = LsrHeaderLetter(oSite, Nothing, visitDate, mm)
                            fullDocument.Add(lsrHeaderTemplate)
                            File.WriteAllBytes(savePath, lsrHeaderTemplate)
                        Else
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0
                            Using (fileStream)
                                mm.WriteTo(fileStream)
                            End Using
                        End If
                        fullDocument.Add(mm.ToArray())

                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function COMCAT(ByVal EngineerVisit As EngineerVisits.EngineerVisit, ByVal oSite As Sites.Site, ByVal template As String, ByVal savePath As String, ByVal goldenRule As String,
                                    Optional ByVal fullDocument As List(Of Byte()) = Nothing, Optional ByVal addLsrHeaderLetter As Boolean = False) As Boolean
                Try

                    Dim Job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)

                    Dim EngVisitCharge As EngineerVisitCharges.EngineerVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Get(EngineerVisit.EngineerVisitID)

                    Dim visitDate As DateTime = EngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = EngineerVisit.ManualEntryOn
                    End If

                    Dim imageIndex As Integer = 100
                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream

                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                            PrintHelper.ReplaceText(wordDoc, "[Job]", EngineerVisit.EngineerVisitID & "_" & visitDate.ToString("ddMMyyyyhhmm") & "_" & "COMCAT")
                            If Not EngineerVisit.EngineerSignature Is Nothing Then
                                Dim engSig As Bitmap = New Bitmap(New IO.MemoryStream(EngineerVisit.EngineerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\EngSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "")
                            End If

                            Dim ComChecks As EngineerVisitAdditionals.EngineerVisitAdditional =
                                DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(
                                EngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialCateringCP42)

                            If Not EngineerVisit.CustomerSignature Is Nothing Then
                                Dim custSig As Bitmap = New Bitmap(New IO.MemoryStream(EngineerVisit.CustomerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "J", custSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", "")
                            End If

                            Dim currentPage As Integer = 1
                            Dim ositeHQ As Sites.Site = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobNo", Job.JobNumber & "-" & EngineerVisit.EngineerVisitID, "9", True)

                            If engineer Is Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", engineer.GasSafeNo)
                            End If

                            If visitDate = Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", visitDate.ToLongDateString)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", engineer.Name)
                            End If
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "E", oSite.Name, "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "F", oSite.Address1, "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "G", oSite.Address2, "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "H", Sys.Helper.FormatPostcode(oSite.Postcode), "8")

                            If Not ositeHQ Is Nothing Then
                                Dim strAddress As String = String.Empty
                                Dim strAddress1 As String = String.Empty

                                If ositeHQ.Address1.Length > 0 Then
                                    strAddress += ositeHQ.Address1 & ", "
                                End If

                                If ositeHQ.Address2.Length > 0 Then
                                    strAddress += ositeHQ.Address2 & ", "
                                End If

                                If strAddress.Length > 0 Then
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2)
                                End If

                                If ositeHQ.Address3.Length > 0 Then
                                    strAddress1 += ositeHQ.Address3 & ", "
                                End If

                                If ositeHQ.Address4.Length > 0 Then
                                    strAddress1 += ositeHQ.Address4 & ", "
                                End If

                                If strAddress1.Length > 0 Then
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", ositeHQ.Name, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", strAddress, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", strAddress1, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "", "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O", Sys.Helper.FormatPostcode(ositeHQ.Postcode), "8")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O", "")
                            End If

                            Dim selected As PickLists.PickList = DB.Picklists.Get_One_As_Object(ComChecks.Test1)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test2)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test3)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test4)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test5)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test6)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test7)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test8)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test9)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test10)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test111)
                            PrintHelper.ReplaceGSRBookmark(
                                wordDoc, "AL", IIf(selected.ManagerID = 70132, "Yes", "NO"))
                            PrintHelper.ReplaceGSRBookmark(
                                wordDoc, "AM", IIf(selected.ManagerID = 70133, "Yes", "NO"))
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test112)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AN", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test113)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AO", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test114)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AP", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test115)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AQ", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test116)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AR", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test117)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AS", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test118)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AT", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test119)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AU", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test120)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test121)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test122)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test123)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test124)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BE", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test125)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BF", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test126)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BG", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test127)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BH", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test128)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BI", selected.Name)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BK", ComChecks.Test11)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", ComChecks.Test12)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test129)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test130)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BM", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test131)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BN", selected.Name)
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test132)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BO", selected.Name)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BP", ComChecks.Test13)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BQ", ComChecks.Test14)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BR", ComChecks.Test15)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BS", ComChecks.Test216)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BT", ComChecks.Test217)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BU", ComChecks.Test218)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BV", ComChecks.Test219)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "CA", ComChecks.Test220)
                        End Using

                        If addLsrHeaderLetter Then
                            Dim lsrHeaderTemplate As Byte() = LsrHeaderLetter(oSite, Nothing, visitDate, mm)
                            fullDocument.Add(lsrHeaderTemplate)
                            File.WriteAllBytes(savePath, lsrHeaderTemplate)
                        Else
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0
                            Using (fileStream)
                                mm.WriteTo(fileStream)
                            End Using
                        End If
                        fullDocument.Add(mm.ToArray())
                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function ProptMain(ByVal oEngineerVisit As EngineerVisits.EngineerVisit, ByVal oSite As Sites.Site, ByVal template As String, ByVal savePath As String, ByVal goldenRule As String,
                                       Optional ByVal fullDocument As List(Of Byte()) = Nothing, Optional addLsrHeaderLetter As Boolean = False) As Boolean
                Try
                    Dim Job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                    Dim ositeHQ As Sites.Site = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)

                    Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = oEngineerVisit.ManualEntryOn
                    End If

                    Dim PropMain As EngineerVisitAdditionals.EngineerVisitAdditional =
                        DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(
                        oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist)

                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream

                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                            If engineer Is Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a1", oSite.Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b1", oSite.Address1 & oSite.Address2 & ", " & oSite.Address3, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", Sys.Helper.FormatPostcode(oSite.Postcode), "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", engineer.Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", visitDate, "11")
                            End If

                            If visitDate = Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "w1", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", DB.Picklists.Get_One_As_Object(PropMain.Test1).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", DB.Picklists.Get_One_As_Object(PropMain.Test2).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", DB.Picklists.Get_One_As_Object(PropMain.Test3).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q1", DB.Picklists.Get_One_As_Object(PropMain.Test4).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r1", DB.Picklists.Get_One_As_Object(PropMain.Test5).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t1", PropMain.Test11, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u1", PropMain.Test12, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "w1", PropMain.Test13, "11")
                            End If
                        End Using

                        If addLsrHeaderLetter Then
                            Dim lsrHeaderTemplate As Byte() = LsrHeaderLetter(oSite, ositeHQ, visitDate, mm)
                            fullDocument.Add(lsrHeaderTemplate)
                            File.WriteAllBytes(savePath, lsrHeaderTemplate)
                        Else
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0
                            Using (fileStream)
                                mm.WriteTo(fileStream)
                            End Using
                        End If
                        fullDocument.Add(mm.ToArray())

                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function Unvented(ByVal oEngineerVisit As EngineerVisits.EngineerVisit, ByVal oSite As Sites.Site, ByVal template As String, ByVal savePath As String, ByVal LSR As DataView, ByVal goldenRule As String,
                                      Optional ByRef fullDocument As List(Of Byte()) = Nothing, Optional addLsrHeaderLetter As Boolean = False) As Boolean
                Try
                    Dim Job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)

                    Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = oEngineerVisit.ManualEntryOn
                    End If
                    Dim imageIndex As Integer = 100

                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream
                    Dim oPicklist As PickLists.PickList
                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSite.Name)
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSite.Address1)
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSite.Address2)
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode))
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("FlueTerminationSatisfactoryID"))
                            PrintHelper.ReplaceText(wordDoc, "[i]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("FlueFlowTestID"))
                            PrintHelper.ReplaceText(wordDoc, "[ii]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("SpillageTestID"))
                            PrintHelper.ReplaceText(wordDoc, "[iii]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("VentilationProvisionSatisfactoryID"))
                            PrintHelper.ReplaceText(wordDoc, "[iv]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("TankID"))
                            PrintHelper.ReplaceText(wordDoc, "[v]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("DischargeID"))
                            PrintHelper.ReplaceText(wordDoc, "[vi]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("SweepOutcomeID"))
                            PrintHelper.ReplaceText(wordDoc, "[vii]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("SafetyDeviceOperationID"))
                            PrintHelper.ReplaceText(wordDoc, "[viii]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("OverallID"))
                            PrintHelper.ReplaceText(wordDoc, "[ix]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("ApplianceTestedID"))
                            PrintHelper.ReplaceText(wordDoc, "[x]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("VisualConditionOfFlueSatisfactoryID"))
                            PrintHelper.ReplaceText(wordDoc, "[xi]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("LandlordsApplianceID"))
                            PrintHelper.ReplaceText(wordDoc, "[xii]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("ApplianceServiceOrInspectedID"))
                            PrintHelper.ReplaceText(wordDoc, "[xiii]", oPicklist.Name)
                            oPicklist = Nothing
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("ApplianceSafeID"))
                            PrintHelper.ReplaceText(wordDoc, "[xiv]", oPicklist.Name)

                            PrintHelper.ReplaceText(wordDoc, "[Additional]", oEngineerVisit.OutcomeDetails)
                            If visitDate = Nothing Then
                                PrintHelper.ReplaceText(wordDoc, "[Date]", "")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[Date]", visitDate.ToLongDateString)
                            End If
                            Dim engineerName As String = If(engineer Is Nothing, "", engineer.Name)
                            PrintHelper.ReplaceText(wordDoc, "[Engineer]", engineerName)

                            If Not oEngineerVisit.CustomerSignature Is Nothing Then
                                Dim CustSig As Bitmap = New Bitmap(New MemoryStream(oEngineerVisit.CustomerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "Tenant", CustSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Tenant", "")
                            End If
                        End Using

                        If addLsrHeaderLetter Then
                            Dim lsrHeaderTemplate As Byte() = LsrHeaderLetter(oSite, Nothing, visitDate, mm)
                            fullDocument.Add(lsrHeaderTemplate)
                            File.WriteAllBytes(savePath, lsrHeaderTemplate)
                        Else
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0
                            Using (fileStream)
                                mm.WriteTo(fileStream)
                            End Using
                        End If
                        fullDocument.Add(mm.ToArray())
                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function SAFUnvented(ByVal oEngineerVisit As EngineerVisits.EngineerVisit, ByVal oSite As Sites.Site, ByVal SAFUNV1 As EngineerVisitAdditionals.EngineerVisitAdditional, ByVal template As String, ByVal savePath As String,
                                         ByVal goldenRule As String, Optional ByRef fullDocument As List(Of Byte()) = Nothing, Optional ByVal addLsrHeaderLetter As Boolean = False) As Boolean
                Try
                    Dim Job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                    Dim oSiteHQ As Sites.Site = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)

                    Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = oEngineerVisit.ManualEntryOn
                    End If
                    Dim imageIndex As Integer = 101

                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream

                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID & "_" & visitDate.ToString("ddMMyyyyhhmm") & "_" & "UNVENTED")
                            If Not oSiteHQ Is Nothing Then
                                Dim strAddress As String = String.Empty

                                If oSiteHQ.Address1.Length > 0 Then
                                    strAddress += oSiteHQ.Address1 & ", "
                                End If

                                If oSiteHQ.Address2.Length > 0 Then
                                    strAddress += oSiteHQ.Address2 & ", "
                                End If

                                If strAddress.Length > 0 Then
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2)
                                End If

                                Dim strAddress1 As String = String.Empty

                                If oSiteHQ.Address3.Length > 0 Then
                                    strAddress1 += oSiteHQ.Address3 & ", "
                                End If

                                If oSiteHQ.Address4.Length > 0 Then
                                    strAddress1 += oSiteHQ.Address4 & ", "
                                End If

                                If oSiteHQ.Address5.Length > 0 Then
                                    strAddress1 += oSiteHQ.Address5 & ", "
                                End If

                                If strAddress.Length > 0 And strAddress1.Length > 1 Then
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordName", DB.Customer.Customer_Get(oSite.CustomerID).Name, "8", True)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress1", strAddress, "8", True)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress2", strAddress1, "8", True)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LLPostcode", Helper.FormatPostcode(oSiteHQ.Postcode), "8", True)
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordName", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress2", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LLPostcode", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LLTelNo", "")
                            End If

                            Dim logo As Byte() = Nothing
                            Try
                                logo = DB.ExecuteScalar("Select Logo FROM tblCustomer where CustomerID = " &
                                                            oSite.CustomerID)
                            Catch
                                logo = Nothing
                            End Try

                            If logo IsNot Nothing Then
                                Dim custLogo As Bitmap = New Bitmap(New MemoryStream(logo))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\custLogo.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(
                                        wordDoc, "Logo", custLogo, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Logo", "")
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[JobNo]", Job.JobNumber)
                            PrintHelper.ReplaceText(wordDoc, "[A]", oSite.Name)
                            PrintHelper.ReplaceText(wordDoc, "[B]", oSite.Address1)
                            PrintHelper.ReplaceText(wordDoc, "[C]", oSite.Address2)
                            PrintHelper.ReplaceText(wordDoc, "[D]", Helper.FormatPostcode(oSite.Postcode))
                            PrintHelper.ReplaceText(wordDoc, "[E]", oSite.TelephoneNum)

                            PrintHelper.ReplaceText(wordDoc, "[AA]", SAFUNV1.Test11)
                            PrintHelper.ReplaceText(wordDoc, "[AB]", SAFUNV1.Test12)
                            PrintHelper.ReplaceText(wordDoc, "[AC]", SAFUNV1.Test13)
                            PrintHelper.ReplaceText(wordDoc, "[AD]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test1).Name)
                            PrintHelper.ReplaceText(wordDoc, "[AE]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test2).Name)
                            PrintHelper.ReplaceText(wordDoc, "[AF]", SAFUNV1.Test14)
                            PrintHelper.ReplaceText(wordDoc, "[AG]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test3).Name)
                            PrintHelper.ReplaceText(wordDoc, "[AH]", SAFUNV1.Test15)
                            PrintHelper.ReplaceText(wordDoc, "[AI]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test4).Name)
                            PrintHelper.ReplaceText(wordDoc, "[AJ]", SAFUNV1.Test216)
                            PrintHelper.ReplaceText(wordDoc, "[AK]", SAFUNV1.Test217)
                            PrintHelper.ReplaceText(wordDoc, "[AL]", SAFUNV1.Test218)
                            PrintHelper.ReplaceText(wordDoc, "[AM]", SAFUNV1.Test219)
                            PrintHelper.ReplaceText(wordDoc, "[AN]", SAFUNV1.Test220)
                            PrintHelper.ReplaceText(wordDoc, "[AO]", SAFUNV1.Test221)
                            PrintHelper.ReplaceText(wordDoc, "[AP]", SAFUNV1.Test222)
                            PrintHelper.ReplaceText(wordDoc, "[AQ]", SAFUNV1.Test223)
                            PrintHelper.ReplaceText(wordDoc, "[AR]", SAFUNV1.Test224)
                            PrintHelper.ReplaceText(wordDoc, "[AS]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test5).Name)
                            PrintHelper.ReplaceText(wordDoc, "[AT]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test6).Name)
                            PrintHelper.ReplaceText(wordDoc, "[AU]", SAFUNV1.Test225)
                            PrintHelper.ReplaceText(wordDoc, "[AV]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test7).Name)
                            PrintHelper.ReplaceText(wordDoc, "[AW]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test8).Name)
                            PrintHelper.ReplaceText(wordDoc, "[AX]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test9).Name)
                            PrintHelper.ReplaceText(wordDoc, "[AY]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test10).Name)

                            PrintHelper.ReplaceText(wordDoc, "[BA]", SAFUNV1.Test226)
                            PrintHelper.ReplaceText(wordDoc, "[BB]", SAFUNV1.Test227)
                            PrintHelper.ReplaceText(wordDoc, "[BC]", SAFUNV1.Test228)
                            PrintHelper.ReplaceText(wordDoc, "[BD]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test111).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BE]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test112).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BF]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test113).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BG]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test114).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BH]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test115).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BI]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test116).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BJ]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test117).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BK]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test118).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BL]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test119).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BM]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test120).Name)
                            PrintHelper.ReplaceText(wordDoc, "[BN]", SAFUNV1.Test229)
                            PrintHelper.ReplaceText(wordDoc, "[BO]", SAFUNV1.Test230)
                            PrintHelper.ReplaceText(wordDoc, "[BP]", SAFUNV1.Test231)

                            If visitDate = Nothing Then
                                PrintHelper.ReplaceText(wordDoc, "[BS]", "")
                                PrintHelper.ReplaceText(wordDoc, "[BW]", "")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[BS]", visitDate.ToLongDateString)
                                PrintHelper.ReplaceText(wordDoc, "[BW]", visitDate.ToLongDateString)
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[BR]", engineer.Name)
                            PrintHelper.ReplaceText(wordDoc, "[BU]", oEngineerVisit.CustomerName)

                            If Not oEngineerVisit.EngineerSignature Is Nothing Then
                                Dim engSig As Bitmap = New Bitmap(New MemoryStream(oEngineerVisit.EngineerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\EngSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig2", engSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig2", "")
                            End If

                            If Not oEngineerVisit.CustomerSignature Is Nothing Then
                                Dim CustSig As Bitmap = New Bitmap(New MemoryStream(oEngineerVisit.CustomerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig2", CustSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig2", "")
                            End If
                        End Using

                        If addLsrHeaderLetter Then
                            Dim lsrHeaderTemplate As Byte() = LsrHeaderLetter(oSite, oSiteHQ, visitDate, mm)
                            fullDocument.Add(lsrHeaderTemplate)
                            File.WriteAllBytes(savePath, lsrHeaderTemplate)
                        Else
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0
                            Using (fileStream)
                                mm.WriteTo(fileStream)
                            End Using
                        End If
                        fullDocument.Add(mm.ToArray())
                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function ComChecklist(ByVal oEngineerVisit As EngineerVisits.EngineerVisit) As Boolean
                Try
                    Dim Job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID)
                    Dim oSite As Sites.Site = DB.Sites.Get(Job.PropertyID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                    Dim CommChecks As EngineerVisitAdditionals.EngineerVisitAdditional =
                        DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(
                        oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommissioningChecklist)
                    Dim oSiteHQ As Sites.Site
                    oSiteHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)

                    Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = oEngineerVisit.ManualEntryOn
                    End If
                    Dim imageIndex As Integer = 101

                    Dim template As String = Application.StartupPath & "\Templates\CommissioningChecklist.docx"

                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream
                    Dim saveDir As String = TheSystem.Configuration.DocumentsLocation &
                        CInt(Enums.TableNames.tblEngineerVisit) & "\" & oEngineerVisit.EngineerVisitID
                    Directory.CreateDirectory(saveDir)
                    Dim savePath As String = saveDir & "\CommisioningChecklist" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)

                            Dim strAddress As String = String.Empty

                            If oSite.Address1.Length > 0 Then
                                strAddress += oSite.Address1 & ", "
                            End If

                            If oSite.Address2.Length > 0 Then
                                strAddress += oSite.Address2 & ", " & oSite.Address3 & ", " & oSite.Postcode
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[custName]", oSite.Name)
                            PrintHelper.ReplaceText(wordDoc, "[tel1]", oSite.TelephoneNum)
                            PrintHelper.ReplaceText(wordDoc, "[address1]", strAddress)
                            PrintHelper.ReplaceText(wordDoc, "[makeModel]", CommChecks.Test12)
                            PrintHelper.ReplaceText(wordDoc, "[serial]", CommChecks.Test13)
                            PrintHelper.ReplaceText(wordDoc, "[commission]", engineer.Name)
                            PrintHelper.ReplaceText(wordDoc, "[commDate]", visitDate.ToLongDateString)
                            PrintHelper.ReplaceText(wordDoc, "[Breg]", CommChecks.Test11)

                            Select Case CommChecks.Test1
                                Case Enums.CommisioningChecksEnums.RoomThermostatAndTimer
                                    PrintHelper.ReplaceText(wordDoc, "[a]", "X")
                                    PrintHelper.ReplaceText(wordDoc, "[b]", "")
                                    PrintHelper.ReplaceText(wordDoc, "[h]", "")
                                    PrintHelper.ReplaceText(wordDoc, "[i]", "")
                                Case Enums.CommisioningChecksEnums.LoadWeatherCompensation
                                    PrintHelper.ReplaceText(wordDoc, "[a]", "")
                                    PrintHelper.ReplaceText(wordDoc, "[b]", "X")
                                    PrintHelper.ReplaceText(wordDoc, "[h]", "")
                                    PrintHelper.ReplaceText(wordDoc, "[i]", "")
                                Case Enums.CommisioningChecksEnums.ProgrammableRoomThermostat
                                    PrintHelper.ReplaceText(wordDoc, "[a]", "")
                                    PrintHelper.ReplaceText(wordDoc, "[b]", "")
                                    PrintHelper.ReplaceText(wordDoc, "[h]", "X")
                                    PrintHelper.ReplaceText(wordDoc, "[i]", "")
                                Case Enums.CommisioningChecksEnums.OptimumStartControl
                                    PrintHelper.ReplaceText(wordDoc, "[a]", "")
                                    PrintHelper.ReplaceText(wordDoc, "[b]", "")
                                    PrintHelper.ReplaceText(wordDoc, "[h]", "")
                                    PrintHelper.ReplaceText(wordDoc, "[i]", "X")
                            End Select

                            If CommChecks.Test2 = Enums.CommisioningChecksEnums.CylinderThermostatAndTimer Then
                                PrintHelper.ReplaceText(wordDoc, "[c]", "X")
                                PrintHelper.ReplaceText(wordDoc, "[j]", "")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[c]", "")
                                PrintHelper.ReplaceText(wordDoc, "[j]", "X")
                            End If

                            If CommChecks.Test3 = Enums.CommisioningChecksEnums.Fitted Then
                                PrintHelper.ReplaceText(wordDoc, "[d]", "X")
                                PrintHelper.ReplaceText(wordDoc, "[k]", "")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[d]", "")
                                PrintHelper.ReplaceText(wordDoc, "[k]", "X")
                            End If

                            If CommChecks.Test4 = Enums.CommisioningChecksEnums.Fitted Then
                                PrintHelper.ReplaceText(wordDoc, "[e]", "X")
                                PrintHelper.ReplaceText(wordDoc, "[l]", "")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[e]", "")
                                PrintHelper.ReplaceText(wordDoc, "[l]", "X")
                            End If

                            If CommChecks.Test5 = Enums.CommisioningChecksEnums.Fitted Then
                                PrintHelper.ReplaceText(wordDoc, "[f]", "X")
                                PrintHelper.ReplaceText(wordDoc, "[m]", "")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[f]", "")
                                PrintHelper.ReplaceText(wordDoc, "[m]", "X")
                            End If

                            If CommChecks.Test6 = Enums.CommisioningChecksEnums.Fitted Then
                                PrintHelper.ReplaceText(wordDoc, "[g]", "X")
                                PrintHelper.ReplaceText(wordDoc, "[n]", "")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[g]", "")
                                PrintHelper.ReplaceText(wordDoc, "[n]", "X")
                            End If

                            If CommChecks.Test7 = Enums.YesNo.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[o]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[o]", "")
                            End If

                            If CommChecks.Test8 = Enums.YesNo.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[p]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[p]", "")
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[cleaner]", CommChecks.Test14)
                            PrintHelper.ReplaceText(wordDoc, "[inhibitor]", CommChecks.Test15)
                            PrintHelper.ReplaceText(wordDoc, "[quantity]", CommChecks.Test216)

                            If CommChecks.Test9 = Enums.YesNo.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[q]", "X")
                                PrintHelper.ReplaceText(wordDoc, "[r]", "")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[q]", "")
                                PrintHelper.ReplaceText(wordDoc, "[r]", "X")
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[gasRate1]", CommChecks.Test217)
                            PrintHelper.ReplaceText(wordDoc, "[burnPress1]", CommChecks.Test218)
                            PrintHelper.ReplaceText(wordDoc, "[burnPress2]", CommChecks.Test219)
                            PrintHelper.ReplaceText(wordDoc, "[flowTemp]", CommChecks.Test220)
                            PrintHelper.ReplaceText(wordDoc, "[returnTemp]", CommChecks.Test221)

                            If CommChecks.Test10 = Enums.YesNoNA.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[s]", "X")
                                PrintHelper.ReplaceText(wordDoc, "[u]", "")
                            ElseIf CommChecks.Test10 = Enums.YesNoNA.No Then
                                PrintHelper.ReplaceText(wordDoc, "[s]", "")
                                PrintHelper.ReplaceText(wordDoc, "[u]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[s]", "")
                                PrintHelper.ReplaceText(wordDoc, "[u]", "")
                            End If

                            If CommChecks.Test111 = Enums.YesNoNA.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[t]", "X")
                                PrintHelper.ReplaceText(wordDoc, "[v]", "")
                            ElseIf CommChecks.Test111 = Enums.YesNoNA.No Then
                                PrintHelper.ReplaceText(wordDoc, "[t]", "")
                                PrintHelper.ReplaceText(wordDoc, "[v]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[t]", "")
                                PrintHelper.ReplaceText(wordDoc, "[v]", "")
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[scale]", CommChecks.Test222)
                            PrintHelper.ReplaceText(wordDoc, "[gasRate3]", CommChecks.Test223)
                            PrintHelper.ReplaceText(wordDoc, "[burnPress3]", CommChecks.Test224)
                            PrintHelper.ReplaceText(wordDoc, "[burnPress4]", CommChecks.Test225)
                            PrintHelper.ReplaceText(wordDoc, "[inletTemp]", CommChecks.Test226)

                            If CommChecks.Test112 = Enums.YesNo.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[x]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[x]", "")
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[temp]", CommChecks.Test227)
                            PrintHelper.ReplaceText(wordDoc, "[flowRate]", CommChecks.Test228)

                            If CommChecks.Test113 = Enums.YesNo.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[y]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[y]", "")
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[maxCO]", CommChecks.Test229)
                            PrintHelper.ReplaceText(wordDoc, "[maxRatio]", CommChecks.Test230)
                            PrintHelper.ReplaceText(wordDoc, "[minCO]", CommChecks.Test231)
                            PrintHelper.ReplaceText(wordDoc, "[minRatio]", CommChecks.Test232)

                            If CommChecks.Test114 = Enums.YesNo.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[z]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[z]", "")
                            End If
                            If CommChecks.Test115 = Enums.YesNo.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[aa]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[aa]", "")
                            End If
                            If CommChecks.Test116 = Enums.YesNo.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[ab]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[ab]", "")
                            End If
                            If CommChecks.Test117 = Enums.YesNo.Yes Then
                                PrintHelper.ReplaceText(wordDoc, "[ac]", "X")
                            Else
                                PrintHelper.ReplaceText(wordDoc, "[ac]", "")
                            End If

                            If Not oEngineerVisit.EngineerSignature Is Nothing Then
                                Dim engSig As Bitmap = New Bitmap(New MemoryStream(oEngineerVisit.EngineerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\EngSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "engSig", engSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "engSig", "")
                            End If

                            If Not oEngineerVisit.CustomerSignature Is Nothing Then
                                Dim CustSig As Bitmap = New Bitmap(New MemoryStream(oEngineerVisit.CustomerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "custSig", CustSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "custSig", "")
                            End If
                        End Using

                        savePath = FileCheck(savePath)

                        Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                        mm.Position = 0
                        Using (fileStream)
                            mm.WriteTo(fileStream)
                        End Using
                    End Using

                    Process.Start(savePath)

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateHotWorksPermit(ByVal oEngineerVisit As EngineerVisits.EngineerVisit) As Boolean
                Try
                    Dim job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID)
                    Dim oSite As Sites.Site = DB.Sites.Get(job.PropertyID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                    Dim hotWorks As EngineerVisitAdditionals.EngineerVisitAdditional = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.HotWorksPermit)
                    Dim oSiteHQ As Sites.Site = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)

                    Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                    If visitDate = Nothing Then visitDate = oEngineerVisit.ManualEntryOn

                    Dim imageIndex As Integer = 101
                    Dim template As String = Application.StartupPath & "\Templates\HotWorksPermit.docx"

                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream
                    Dim saveDir As String = TheSystem.Configuration.DocumentsLocation & CInt(Enums.TableNames.tblEngineerVisit) & "\" & oEngineerVisit.EngineerVisitID
                    Directory.CreateDirectory(saveDir)
                    Dim savePath As String = saveDir & "\HotWorksPermit" & Now.Day & "_" & Now.ToString("MMM") & "_" & Now.Year & ".docx"
                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)

                            PrintHelper.ReplaceText(wordDoc, "[JobNumber]", job.JobNumber.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test220]", hotWorks.Test220.ToUpper())

                            Dim strAddress As String = String.Empty
                            If oSite.Address1.Length > 0 Then
                                strAddress += oSite.Address1 & ", "
                            End If
                            If oSite.Address2.Length > 0 Then
                                strAddress += oSite.Address2 & ", " & oSite.Address3 & ", " & oSite.Postcode
                            End If

                            PrintHelper.ReplaceText(wordDoc, "[Address]", strAddress)

                            PrintHelper.ReplaceText(wordDoc, "[Test221]", hotWorks.Test221.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test222]", hotWorks.Test222.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test11]", hotWorks.Test11.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[EngineerName]", engineer.Name.ToUpper())

                            PrintHelper.ReplaceText(wordDoc, "[Test11]", hotWorks.Test11.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test12]", hotWorks.Test12.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test13]", hotWorks.Test13.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test14]", hotWorks.Test14.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test15]", hotWorks.Test15.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test216]", hotWorks.Test216.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test217]", hotWorks.Test217.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test218]", hotWorks.Test218.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test219]", hotWorks.Test219.ToUpper())

                            PrintHelper.ReplaceText(wordDoc, "[Test223]", hotWorks.Test223.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test224]", hotWorks.Test224.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test225]", hotWorks.Test225.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test226]", hotWorks.Test226.ToUpper())
                            PrintHelper.ReplaceText(wordDoc, "[Test227]", hotWorks.Test227.ToUpper())

                            PrintHelper.ReplaceText(wordDoc, "[VisitDate]", visitDate.ToString("dd/MM/yyyy HH:mm"))

                            If Not oEngineerVisit.EngineerSignature Is Nothing Then
                                Dim engSig As Bitmap = New Bitmap(New MemoryStream(oEngineerVisit.EngineerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\EngSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex)
                                imageIndex += 1
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig1", engSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig1", "")
                            End If
                        End Using

                        savePath = FileCheck(savePath)

                        Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                        mm.Position = 0
                        Using (fileStream)
                            mm.WriteTo(fileStream)
                        End Using
                    End Using

                    Process.Start(savePath)

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function ASHPM(ByVal oEngineerVisit As EngineerVisits.EngineerVisit, ByVal oSite As Sites.Site, ByVal template As String, ByVal savePath As String, ByVal goldenRule As String,
                                   Optional ByVal fullDocument As List(Of Byte()) = Nothing, Optional addHeaderLetter As Boolean = False) As Boolean

                Try
                    Dim Job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                    Dim EngVisitCharge As EngineerVisitCharges.EngineerVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Get(oEngineerVisit.EngineerVisitID)
                    Dim GSRs As DataView = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(oEngineerVisit.EngineerVisitID)
                    Dim numberOfAppliances As Integer = GSRs.Table.Rows.Count

                    Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = oEngineerVisit.ManualEntryOn
                    End If

                    Dim total As Double = 0.0
                    Dim vat As Double = 0.0
                    Dim ASHP As EngineerVisitAdditionals.EngineerVisitAdditional = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet)
                    Dim Solar As EngineerVisitAdditionals.EngineerVisitAdditional = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SolarThermalReport)

                    Dim ositeHQ As Sites.Site = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)
                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream

                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID & "_" & visitDate.ToString("ddMMyyyyhhmm") & "_" & "ASHPM")
                            If engineer Is Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobSiteName", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress2", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress3", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobPostCode", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobTelNo", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobSiteName", oSite.Name, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress1", oSite.Address1, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress2", oSite.Address2, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress3", oSite.Address3, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobPostCode", Sys.Helper.FormatPostcode(oSite.Postcode), "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobTelNo", oSite.TelephoneNum, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", engineer.Name, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a", ASHP.Test11)
                            End If

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobVisitNumber", Job.JobNumber & "-" & oEngineerVisit.EngineerVisitID, "9", True)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate", Format(visitDate, "dd/MM/yyyy"), "9", True)

                            If visitDate = Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "d", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "e", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "h", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "i", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "j", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "k", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "l", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "m", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "s", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "v", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "w", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "x", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWCYL", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWMOD", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWSERIAL", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b", ASHP.Test12)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c", ASHP.Test13)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "d", ASHP.Test14)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "e", ASHP.Test15)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f", ASHP.Test216)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g", ASHP.Test217)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "h", ASHP.Test218)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "i", ASHP.Test219)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "j", ASHP.Test220)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "k", ASHP.Test221)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "l", ASHP.Test222)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "m", ASHP.Test223)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n", ASHP.Test224)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o", ASHP.Test225)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p", ASHP.Test226)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q", ASHP.Test227)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r", ASHP.Test228)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "s", ASHP.Test229)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t", ASHP.Test230)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u", ASHP.Test231)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "v", ASHP.Test232)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "w", ASHP.Test233)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "x", ASHP.Test234)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWCYL", ASHP.Test235)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWMOD", ASHP.Test236)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWSERIAL", ASHP.Test237)
                            End If

                            If Not Solar Is Nothing And visitDate <> Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a1", oSite.Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b1", oSite.Address1 & ", " & oSite.Address2, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", Sys.Helper.FormatPostcode(oSite.Postcode), "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "d1", oSite.TelephoneNum, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "e1", oSite.FaxNum, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", engineer.Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", Format(visitDate, "dd/MM/yyyy"), "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "h1", Solar.Test217, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "j1", Solar.Test218, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "k1", DB.Picklists.Get_One_As_Object(Solar.Test1).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "l1", DB.Picklists.Get_One_As_Object(Solar.Test2).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "m1", DB.Picklists.Get_One_As_Object(Solar.Test3).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", DB.Picklists.Get_One_As_Object(Solar.Test4).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", DB.Picklists.Get_One_As_Object(Solar.Test5).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", DB.Picklists.Get_One_As_Object(Solar.Test6).Name, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q1", Solar.Test11, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r1", Solar.Test12, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "s1", Solar.Test13, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t1", Solar.Test14, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u1", Solar.Test15, "11")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "v1", Solar.Test216, "11")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "d1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "e1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "h1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "j1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "k1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "l1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "m1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "s1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "v1", "")
                            End If
                        End Using

                        If addHeaderLetter Then
                            Dim lsrHeaderTemplate As Byte() = LsrHeaderLetter(oSite, ositeHQ, visitDate, mm)
                            fullDocument.Add(lsrHeaderTemplate)
                            File.WriteAllBytes(savePath, lsrHeaderTemplate)
                        Else
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0
                            Using (fileStream)
                                mm.WriteTo(fileStream)
                            End Using
                        End If
                        fullDocument.Add(mm.ToArray())

                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try

            End Function

            Private Function COMTANDP(ByVal oEngineerVisit As EngineerVisits.EngineerVisit, ByVal oSite As Sites.Site, ByVal template As String, ByVal savePath As String, ByVal goldenRule As String, Optional ByVal fullDocument As List(Of Byte()) = Nothing) As Boolean
                Try
                    Dim Job As Jobs.Job =
                        DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                    Dim ositeHQ As Sites.Site = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)

                    Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = oEngineerVisit.ManualEntryOn
                    End If
                    Dim imageIndex As Integer = 100

                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream

                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule)
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID & "_" & visitDate.ToString("ddMMyyyyhhmm") & "_" & "COMTANDP")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobNo", Job.JobNumber & "-" & oEngineerVisit.EngineerVisitID)
                            If engineer Is Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", engineer.GasSafeNo)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C", engineer.Name)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", engineer.Name)
                            End If

                            If visitDate = Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", visitDate.ToLongDateString)
                            End If

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "E", oSite.Name, "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "F", oSite.Address1, "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "G", oSite.Address2, "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "H", Sys.Helper.FormatPostcode(oSite.Postcode), "8")
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "I", oSite.TelephoneNum, "8")

                            If Not ositeHQ Is Nothing Then
                                Dim strAddress As String = String.Empty
                                Dim strAddress1 As String = String.Empty

                                If ositeHQ.Address1.Length > 0 Then
                                    strAddress += ositeHQ.Address1 & ", "
                                End If

                                If ositeHQ.Address2.Length > 0 Then
                                    strAddress += ositeHQ.Address2 & ", "
                                End If

                                If strAddress.Length > 0 Then
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2)
                                End If

                                If ositeHQ.Address3.Length > 0 Then
                                    strAddress1 += ositeHQ.Address3 & ", "
                                End If

                                If ositeHQ.Address4.Length > 0 Then
                                    strAddress1 += ositeHQ.Address4 & ", "
                                End If

                                If strAddress1.Length > 0 Then
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", DB.Customer.Customer_Get(oSite.CustomerID).Name, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", strAddress, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", strAddress1, "8")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", Sys.Helper.FormatPostcode(ositeHQ.Postcode), "8")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "")
                            End If
                            Dim warning As String = "No"
                            For Each row As DataRow In DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(oEngineerVisit.EngineerVisitID).Table.Rows
                                If Helper.MakeBooleanValid(row.Item("WarningNoticeIssued")) Then
                                    warning = "Yes"
                                    Exit For
                                End If
                            Next

                            If Not oEngineerVisit.CustomerSignature Is Nothing Then
                                Dim custSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.CustomerSignature))
                                Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig1", custSig, imgSavePath, imageIndex)
                                imageIndex += 1
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig1", "")
                            End If

                            If warning = "Yes" Then
                                If Not oEngineerVisit.EngineerSignature Is Nothing Then
                                    Dim engSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.EngineerSignature))
                                    Dim imgSavePath As String = Application.StartupPath & "\TEMP\EngSig.jpg"
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig2", engSig, imgSavePath, imageIndex)
                                    imageIndex += 1
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig2", "")
                                End If

                                If Not oEngineerVisit.CustomerSignature Is Nothing Then
                                    Dim custSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.CustomerSignature))
                                    Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig2", custSig, imgSavePath, imageIndex)
                                    imageIndex += 1
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig2", "")
                                End If

                                If visitDate = Nothing Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", visitDate.ToLongDateString)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DA", "")
                            Else
                                If Not oEngineerVisit.EngineerSignature Is Nothing Then
                                    Dim engSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.EngineerSignature))
                                    Dim imgSavePath As String = Application.StartupPath & "\TEMP\EngSig.jpg"
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex)
                                    imageIndex += 1
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "")
                                End If

                                If Not oEngineerVisit.CustomerSignature Is Nothing Then
                                    Dim custSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.CustomerSignature))
                                    Dim imgSavePath As String = Application.StartupPath & "\TEMP\CustSig.jpg"
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig", custSig, imgSavePath, imageIndex)
                                    imageIndex += 1
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig", "")
                                End If

                                If visitDate = Nothing Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DA", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DA", visitDate.ToLongDateString)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "")
                            End If

                            If oEngineerVisit.OutcomeDetails Is Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", "")
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", oEngineerVisit.OutcomeDetails)
                            End If

                            Dim ComChecks As EngineerVisitAdditionals.EngineerVisitAdditional =
                                DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(
                                oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialStrengthTestCP16)

                            If ComChecks IsNot Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X1", "X")

                                Dim cSelected As String = ""
                                Select Case (ComChecks.Test1)
                                    Case 1
                                        cSelected = "P"
                                    Case 2
                                        cSelected = "H"

                                End Select
                                If String.IsNullOrEmpty(cSelected) Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", cSelected)
                                End If

                                cSelected = ""
                                Select Case (ComChecks.Test2)
                                    Case 1
                                        cSelected = "N"
                                    Case 2
                                        cSelected = "NE"
                                    Case 3
                                        cSelected = "E"
                                End Select
                                If String.IsNullOrEmpty(cSelected) Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", cSelected)
                                End If

                                Dim selected As PickLists.PickList = DB.Picklists.Get_One_As_Object(ComChecks.Test3)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", selected.Name)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", ComChecks.Test11)

                                cSelected = ""
                                Select Case (ComChecks.Test4)
                                    Case 1
                                        cSelected = "AIR"
                                    Case 2
                                        cSelected = "NITRO"
                                    Case 3
                                        cSelected = "WATER"
                                End Select
                                If String.IsNullOrEmpty(cSelected) Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", cSelected)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", ComChecks.Test12)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", ComChecks.Test13)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", ComChecks.Test14)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", ComChecks.Test15)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", ComChecks.Test216)

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test120)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", selected.Name)
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X1", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", "")
                            End If

                            ComChecks = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(
                                    oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialTightnessTestCP16)

                            If ComChecks IsNot Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X2", "X")

                                Dim cSelected As String = ""
                                Select Case (ComChecks.Test1)
                                    Case 1
                                        cSelected = "NG"
                                    Case 2
                                        cSelected = "LPG"
                                End Select
                                If String.IsNullOrEmpty(cSelected) Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", cSelected)
                                End If

                                cSelected = ""
                                Select Case (ComChecks.Test2)
                                    Case 1
                                        cSelected = "N"
                                    Case 2
                                        cSelected = "NE"
                                    Case 3
                                        cSelected = "E"
                                End Select
                                If String.IsNullOrEmpty(cSelected) Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", cSelected)
                                End If

                                Dim selected As PickLists.PickList = DB.Picklists.Get_One_As_Object(ComChecks.Test3)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", selected.Name)

                                cSelected = ""
                                Select Case (ComChecks.Test4)
                                    Case 1
                                        cSelected = "Diap"
                                    Case 2
                                        cSelected = "Rota"
                                    Case 3
                                        cSelected = "Turb"
                                End Select
                                If String.IsNullOrEmpty(cSelected) Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", cSelected)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BE", ComChecks.Test221)

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test6)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BF", selected.Name)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BG", ComChecks.Test11)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BH", ComChecks.Test12)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BI", ComChecks.Test13)

                                cSelected = ""
                                Select Case (ComChecks.Test7)
                                    Case 1
                                        cSelected = "Fuel Gas"
                                    Case 2
                                        cSelected = "Air"

                                End Select
                                If String.IsNullOrEmpty(cSelected) Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", cSelected)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BK", ComChecks.Test14)

                                cSelected = ""
                                Select Case (ComChecks.Test8)
                                    Case 1
                                        cSelected = "Water"
                                    Case 2
                                        cSelected = "H. SG"
                                    Case 3
                                        cSelected = "Elec"

                                End Select
                                If String.IsNullOrEmpty(cSelected) Then
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", "")
                                Else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", cSelected)
                                End If

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BM", ComChecks.Test15)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BN", ComChecks.Test216)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BO", ComChecks.Test217)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BP", ComChecks.Test218)

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test9)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BQ", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test10)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BR", selected.Name)

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BT", ComChecks.Test219)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BU", ComChecks.Test220)

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test119)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BV", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test120)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BX", selected.Name)
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X2", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BE", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BF", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BG", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BH", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BI", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BK", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BM", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BN", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BO", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BP", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BQ", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BR", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BT", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BU", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BV", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BX", "")
                            End If

                            ComChecks = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(
                                    oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialPurgingTestCP16)

                            If ComChecks IsNot Nothing Then
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X3", "X")

                                Dim selected As PickLists.PickList = DB.Picklists.Get_One_As_Object(ComChecks.Test1)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CA", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test2)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CB", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test3)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CC", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test4)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CD", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test5)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CE", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test6)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CF", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test7)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CG", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test8)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CH", selected.Name)
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test9)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CI", selected.Name)

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CJ", ComChecks.Test11)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CK", ComChecks.Test12)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CL", ComChecks.Test13)

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test10)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CM", selected.Name)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CN", ComChecks.Test14)

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test120)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CO", ComChecks.Test14)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CP", selected.Name)
                            Else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X3", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CA", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CB", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CC", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CD", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CE", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CF", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CG", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CH", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CI", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CJ", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CK", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CL", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CM", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CN", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CO", "")
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CP", "")
                            End If
                        End Using

                        Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                        mm.Position = 0
                        Using (fileStream)
                            mm.WriteTo(fileStream)
                        End Using
                        fullDocument.Add(mm.ToArray())
                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function Install(ByVal EngineerVisit As EngineerVisits.EngineerVisit) As Boolean
                Try
                    Dim Job As Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID)

                    Dim oSite As Sites.Site = DB.Sites.Get(Job.PropertyID)
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                    Dim engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)

                    Dim visitDate As DateTime = EngineerVisit.StartDateTime
                    If visitDate = Nothing Then
                        visitDate = EngineerVisit.ManualEntryOn
                    End If

                    Dim total As Double = 0.0
                    Dim vat As Double = 0.0

                    Dim Assets As DataView = DB.JobAsset.JobAsset_Get_For_Job(Job.JobID)

                    Dim numberOfAppliances As Integer = Assets.Table.Rows.Count

                    Dim numberOfPages As Integer = Math.Ceiling(numberOfAppliances / 5)
                    If numberOfPages = 0 Then
                        numberOfPages += 1
                    End If

                    Dim currentPage As Integer = 1

                    Dim ositeHQ As Sites.Site = Nothing
                    If Not oSite.CustomerID = Enums.Customer.Domestic Then
                        ositeHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)
                    End If

                    For Each wordField As System.Text.RegularExpressions.Match In GetTemplateFields(WordDoc.Content.Text)
                        Select Case wordField.Value.ToLower
                            Case "[JobVisitNumber]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Job.JobNumber & "-" & EngineerVisit.EngineerVisitID)
                            Case "[VisitDate]".ToLower
                                If visitDate = Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, "")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, visitDate.ToLongDateString)
                                End If
                            Case "[GasSafeIDNo]".ToLower()
                                If engineer Is Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, "")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, engineer.GasSafeNo)
                                End If
                            Case "[JobCustomerName]".ToLower
                                Dim selected As PickLists.PickList = DB.Picklists.Get_One_As_Object(EngineerVisit.SignatureSelectedID)
                                If selected Is Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, EngineerVisit.CustomerName)
                                Else
                                    ReplaceText(WordDoc, wordField.Value, selected.Name & " " & EngineerVisit.CustomerName)
                                End If
                            Case "[JobAddressName]".ToLower
                                ReplaceText(WordDoc, wordField.Value, oSite.Name)
                            Case "[JobAddress1]".ToLower
                                ReplaceText(WordDoc, wordField.Value, oSite.Address1)
                            Case "[JobAddress2]".ToLower
                                ReplaceText(WordDoc, wordField.Value, oSite.Address2)
                            Case "[JobAddress3]".ToLower
                                ReplaceText(WordDoc, wordField.Value, oSite.Address3)
                            Case "[JobPostCode]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.FormatPostcode(oSite.Postcode))
                            Case "[JobTelNo]".ToLower
                                ReplaceText(WordDoc, wordField.Value, oSite.TelephoneNum)
                            Case "[LandLordName]".ToLower
                                If Not ositeHQ Is Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, DB.Customer.Customer_Get(oSite.CustomerID).Name)
                                Else
                                    ReplaceText(WordDoc, wordField.Value, "")
                                End If
                            Case "[LandLordAddress1]".ToLower
                                If Not ositeHQ Is Nothing Then
                                    Dim strAddress As String = String.Empty

                                    If ositeHQ.Address1.Length > 0 Then
                                        strAddress += ositeHQ.Address1
                                    End If

                                    ReplaceText(WordDoc, wordField.Value, strAddress)
                                Else
                                    ReplaceText(WordDoc, wordField.Value, "")
                                End If
                            Case "[LandLordAddress2]".ToLower
                                If Not ositeHQ Is Nothing Then
                                    Dim strAddress As String = String.Empty

                                    If ositeHQ.Address2.Length > 0 Then
                                        strAddress += ositeHQ.Address2
                                    End If

                                    ReplaceText(WordDoc, wordField.Value, strAddress)
                                Else
                                    ReplaceText(WordDoc, wordField.Value, "")
                                End If
                            Case "[LandLordAddress3]".ToLower
                                If Not ositeHQ Is Nothing Then
                                    Dim strAddress As String = String.Empty

                                    If ositeHQ.Address3.Length > 0 Then
                                        strAddress += ositeHQ.Address3
                                    End If

                                    ReplaceText(WordDoc, wordField.Value, strAddress)
                                Else
                                    ReplaceText(WordDoc, wordField.Value, "")
                                End If
                            Case "[LLPostcode]".ToLower
                                If Not ositeHQ Is Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, Sys.Helper.FormatPostcode(ositeHQ.Postcode))
                                Else
                                    ReplaceText(WordDoc, wordField.Value, "")
                                End If
                            Case "[LLTelNo]".ToLower
                                If Not ositeHQ Is Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, ositeHQ.TelephoneNum)
                                Else
                                    ReplaceText(WordDoc, wordField.Value, "")
                                End If
                            Case "[PO]".ToLower
                                If Job.PONumber.Trim.Length = 0 Then
                                    ReplaceText(WordDoc, wordField.Value, "N/A")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, Job.PONumber)
                                End If
                            Case "[From]".ToLower
                                Dim sd As DateTime = Helper.MakeDateTimeValid(EngineerVisit.StartDateTime)
                                If sd = Nothing Then
                                    If Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn) = Nothing Then
                                        ReplaceText(WordDoc, wordField.Value, "")
                                    Else
                                        sd = Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn)
                                        ReplaceText(WordDoc, wordField.Value, sd.ToShortTimeString)
                                    End If
                                Else
                                    ReplaceText(WordDoc, wordField.Value, sd.ToShortTimeString)
                                End If
                            Case "[To]".ToLower
                                Dim ed As DateTime = Helper.MakeDateTimeValid(EngineerVisit.EndDateTime)
                                If ed = Nothing Then
                                    If Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn) = Nothing Then
                                        ReplaceText(WordDoc, wordField.Value, "")
                                    Else
                                        ed = Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn)
                                        ReplaceText(WordDoc, wordField.Value, ed.ToShortTimeString)
                                    End If
                                Else
                                    ReplaceText(WordDoc, wordField.Value, ed.ToShortTimeString)
                                End If
                            Case "[GASSAFEID]".ToLower
                                Dim eng As Engineers.Engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)
                                If eng Is Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, "")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, eng.GasSafeNo)
                                End If
                            Case "[Engineer]".ToLower
                                Dim eng As Engineers.Engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID)
                                If eng Is Nothing Then
                                    ReplaceText(WordDoc, wordField.Value, "")
                                Else
                                    ReplaceText(WordDoc, wordField.Value, eng.Name)
                                End If
                            Case "[WorkRequired]".ToLower
                                ReplaceText(WordDoc, wordField.Value, EngineerVisit.NotesToEngineer)
                        End Select
                    Next

                    MsWordApp.Selection.WholeStory()
                    MsWordApp.Selection.Copy()

                    numberOfAppliances = Add_Appliances_PreVisit(WordDoc, numberOfAppliances, currentPage, numberOfPages, Assets.Table, Nothing, 1)
                    'While (numberOfAppliances > 0)
                    '    WordApp.Selection.EndKey()
                    '    WordApp.Selection.InsertBreak(Word.WdBreakType.wdPageBreak)
                    '    WordApp.Selection.Paste()
                    '    currentPage += 1

                    '    numberOfAppliances = Add_Appliances_PreVisit(WordDoc, numberOfAppliances, currentPage, numberOfPages, Assets.Table, Nothing, currentPage)
                    'End While

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function SiteLetter(ByVal template As String, ByVal savePath As String) As Boolean
                Try
                    Dim oContact As Contacts.Contact = DB.Contact.Contact_Get(DetailsToPrint.item(0))
                    Dim oSite As Sites.Site = DB.Sites.Get(DetailsToPrint.item(1))

                    Dim byteArray As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream
                    Using (mm)
                        mm.Write(byteArray, 0, byteArray.Length)
                        Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using (wordDoc)
                            AddCompanyDetails(wordDoc, True, True)
                            Dim name As String = If(oContact Is Nothing, oSite.Name, oContact.FirstName & " " & oContact.Surname)
                            PrintHelper.ReplaceText(wordDoc, "[Name]", name)
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSite.Address1)
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSite.Address2)
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSite.Address3)
                            PrintHelper.ReplaceText(wordDoc, "[Address4]", oSite.Address4)
                            PrintHelper.ReplaceText(wordDoc, "[Address5]", oSite.Address5)
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode))
                            PrintHelper.ReplaceText(wordDoc, "[theDate]", DateTime.Now.ToString("dd MMMM yyyy"))
                        End Using

                        Directory.CreateDirectory(Path.GetDirectoryName(savePath))
                        savePath = FileCheck(savePath)
                        Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                        mm.Position = 0
                        Using (fileStream)
                            mm.WriteTo(fileStream)
                        End Using

                        Dim linkedDoc As New Documentss.Documents
                        linkedDoc.SetTableEnumID = CInt(Enums.TableNames.tblSite)
                        linkedDoc.SetRecordID = oSite.SiteID
                        linkedDoc.SetDocumentTypeID = 205
                        linkedDoc.SetName = Path.GetFileName(savePath)
                        linkedDoc.SetNotes = ""
                        linkedDoc.SetLocation = savePath

                        Dim cV As New Documentss.DocumentsValidator
                        cV.Validate(linkedDoc)

                        linkedDoc = DB.Documents.Insert(linkedDoc)
                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function Credit() As Boolean
                Try
                    Dim rowIndex As Integer = 1
                    'Dim dt As DataTable = CType(DetailsToPrint.item(0), DataTable)
                    Dim dt As DataTable = CType(DetailsToPrint, DataTable)
                    Dim Supplier As String = ""
                    Dim address1 As String = ""
                    Dim address2 As String = ""
                    Dim address3 As String = ""
                    Dim address4 As String = ""
                    Dim address5 As String = ""
                    Dim postcode As String = ""
                    Dim accountNumber As String = ""
                    Dim CreditRef As String = ""

                    For Each r As DataRow In dt.Rows
                        If CBool(r("Tick")) = True Then
                            With WordDoc.Tables.Item(1)
                                With .Rows.Add()
                                    .Range.Font.Bold = CInt(False)
                                    .Range.Font.Size = 7
                                    .Range.Borders.Item(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone
                                    .Range.Borders.Item(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone
                                End With
                                rowIndex += 1

                                .Cell(rowIndex, 1).Range.Text = Helper.MakeStringValid(r("CreditReference"))
                                .Cell(rowIndex, 2).Range.Text = Helper.MakeStringValid(r("OrderReference"))
                                .Cell(rowIndex, 3).Range.Text = Helper.MakeStringValid(r("PartNumber"))
                                .Cell(rowIndex, 4).Range.Text = Helper.MakeStringValid(r("PartName"))
                                .Cell(rowIndex, 5).Range.Text = Helper.MakeIntegerValid(r("Qty"))
                                .Cell(rowIndex, 6).Range.Text = Strings.Format(Helper.MakeDoubleValid(r("Price")), "C")
                                .Cell(rowIndex, 7).Range.Text = Strings.Format(Helper.MakeDoubleValid(r("Total")), "C")
                                .Cell(rowIndex, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                                .Cell(rowIndex, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                                .Cell(rowIndex, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                                .Cell(rowIndex, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft

                                Supplier = Helper.MakeStringValid(r.Item("Supplier"))
                                address1 = Helper.MakeStringValid(r.Item("Address1"))
                                address2 = Helper.MakeStringValid(r.Item("Address2"))
                                address3 = Helper.MakeStringValid(r.Item("Address3"))
                                address4 = Helper.MakeStringValid(r.Item("Address4"))
                                address5 = Helper.MakeStringValid(r.Item("Address5"))
                                postcode = Helper.FormatPostcode(r.Item("Postcode"))
                                accountNumber = Helper.MakeStringValid(r.Item("GaswayAccount"))
                            End With

                        End If

                    Next

                    For Each wordField As System.Text.RegularExpressions.Match In GetTemplateFields(WordDoc.Content.Text)
                        Select Case wordField.Value.ToLower
                            Case "[CombinedCreditNumber]".ToLower
                                ReplaceText(WordDoc, wordField.Value, "")
                            Case "[Name]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Supplier)
                            Case "[Address1]".ToLower
                                ReplaceText(WordDoc, wordField.Value, address1)
                            Case "[Address2]".ToLower
                                ReplaceText(WordDoc, wordField.Value, address2)
                            Case "[Address3]".ToLower
                                ReplaceText(WordDoc, wordField.Value, address3)
                            Case "[Address4]".ToLower
                                ReplaceText(WordDoc, wordField.Value, address4)
                            Case "[Address5]".ToLower
                                ReplaceText(WordDoc, wordField.Value, address5)
                            Case "[Postcode]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Sys.Helper.FormatPostcode(postcode))
                            Case "[Date]".ToLower
                                ReplaceText(WordDoc, wordField.Value, Strings.Format(Now, "dd MMMM yyyy"))
                            Case "[OUR_ACCOUNT_SUPPLIER]".ToLower
                                ReplaceText(WordDoc, wordField.Value, accountNumber)
                            Case "[User]".ToLower
                                ReplaceText(WordDoc, wordField.Value, loggedInUser.Fullname)
                        End Select
                    Next
                    WordDoc.Content.Font.Name = "Arial"
                    WordDoc.Tables.Item(1).AllowAutoFit = True
                    WordDoc.Tables.Item(1).AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent)
                    WordDoc.Tables.Item(1).Range.Font.Size = 8

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function AlphaCredit() As Boolean
                Try
                    Dim rowIndex As Integer = 1
                    Dim dt As DataTable = CType(DetailsToPrint, DataTable)
                    For Each r As DataRow In dt.Rows
                        If CBool(r("Tick")) = True Then
                            With WordDoc.Tables.Item(1)
                                If Not rowIndex = 1 Then
                                    With .Rows.Add()
                                        .Range.Font.Bold = CInt(False)
                                        .Range.Font.Size = 7
                                    End With
                                End If
                                rowIndex += 1
                                .Cell(rowIndex, 1).Range.Text = ""
                                .Cell(rowIndex, 2).Range.Text = Helper.MakeStringValid(r("PartName"))
                                .Cell(rowIndex, 2).WordWrap = True
                                .Cell(rowIndex, 3).Range.Text = Helper.MakeStringValid(r("PartNumber"))
                                .Cell(rowIndex, 3).WordWrap = True
                                .Cell(rowIndex, 4).Range.Text = ""
                                .Cell(rowIndex, 5).Range.Text = ""
                                .Cell(rowIndex, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                                .Cell(rowIndex, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                                .Cell(rowIndex, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                                .Cell(rowIndex, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                            End With
                        End If
                    Next
                    WordDoc.Content.Font.Name = "Arial"
                    WordDoc.Tables.Item(1).AllowAutoFit = True
                    WordDoc.Tables.Item(1).AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow)
                    WordDoc.Tables.Item(1).Range.Font.Size = 8
                    WordDoc.Tables.Item(1).Rows.Item(1).Range.Font.Size = 11
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GetDocumentGoldenRule(ByVal templateFilePath As String, ByVal refNo As Integer) As String
                '##Neopost|DocumentID(invoice)|PostalClass(2)|MergeCriteria(MAL)|DocumentSortation(1)|OutputFormat(D)|Colour/Mono(M)|CustomerID(CID)
                Dim neopost As String = "##Neopost"
                Dim documentType As String = String.Empty
                Dim postalClass As String = "2"
                Dim mergeCriteria As String = "MAL"
                Dim documentOrder As String = String.Empty
                Dim outputFormat As String = "S"
                Dim color As String = "M"

                Dim filename As String = Path.GetFileNameWithoutExtension(templateFilePath)

                Select Case True
                    Case filename.ToLower = "GSRCoveringLetter".ToLower
                        documentType = "CoverLetter"
                        documentOrder = "1"
                    Case filename.ToLower.Contains("AnnualSafetyInspection".ToLower), filename.ToLower.Contains("PatchCheck".ToLower)
                        documentType = "AnnualSafetyInspection"
                        documentOrder = "1"
                    Case filename.ToLower.Contains("GSRDue".ToLower)
                        documentType = "ServiceReminder"
                        documentOrder = "1"
                    Case filename.ToLower.Contains("TestingLetter".ToLower), filename.ToLower.Contains("ElecMainLetter".ToLower)
                        documentType = "ElectricalTesting"
                        documentOrder = "1"
                    Case filename.ToLower.Contains("GSR".ToLower)
                        documentType = "GSR"
                        documentOrder = "2"
                    Case filename.ToLower.Contains("ContractDD".ToLower)
                        documentType = "Contract"
                        documentOrder = "1"
                    Case filename.ToLower.Contains("ContractOption".ToLower)
                        documentType = "Contract"
                        documentOrder = "2"
                    Case filename.ToLower.Contains("Receipt".ToLower), filename.ToLower.Contains("Invoice".ToLower)
                        documentType = "Invoice"
                        documentOrder = "3"
                    Case filename.ToLower.Contains("ContractTransfer".ToLower)
                        documentType = "Contract"
                        documentOrder = "4"
                End Select

                Dim goldenRule As String =
                    String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|",
                                  neopost, documentType, postalClass, mergeCriteria, documentOrder, outputFormat, color, refNo)
                Return goldenRule
            End Function

            Private Function GenerateDDMS(ByVal drContracts As DataRow()) As Boolean
                Dim dtDdmsNew As DataTable = New DataTable()
                dtDdmsNew.Columns.Add("Ref")
                dtDdmsNew.Columns.Add("Unknown")
                dtDdmsNew.Columns.Add("Salutation")
                dtDdmsNew.Columns.Add("FirstName")
                dtDdmsNew.Columns.Add("OtherName")
                dtDdmsNew.Columns.Add("LastName")
                dtDdmsNew.Columns.Add("Unknown1")
                dtDdmsNew.Columns.Add("Unknown2")
                dtDdmsNew.Columns.Add("Address1")
                dtDdmsNew.Columns.Add("Address2")
                dtDdmsNew.Columns.Add("Address3")
                dtDdmsNew.Columns.Add("Address4")
                dtDdmsNew.Columns.Add("Unknown3")
                dtDdmsNew.Columns.Add("Tel")
                dtDdmsNew.Columns.Add("Unknown4")
                dtDdmsNew.Columns.Add("Postcode")
                dtDdmsNew.Columns.Add("SortCode")
                dtDdmsNew.Columns.Add("AccNum")
                dtDdmsNew.Columns.Add("NameOnAcc")
                dtDdmsNew.Columns.Add("Ref2")
                dtDdmsNew.Columns.Add("InvoiceNumber")
                dtDdmsNew.Columns.Add("Type")
                dtDdmsNew.Columns.Add("SecondPayment")
                dtDdmsNew.Columns.Add("FirstPayment")
                dtDdmsNew.Columns.Add("ProcessDate")
                dtDdmsNew.Columns.Add("Unknown5")
                dtDdmsNew.Columns.Add("Installments")
                dtDdmsNew.Columns.Add("SecondPayment2")
                dtDdmsNew.Columns.Add("Unknown6")
                dtDdmsNew.Columns.Add("SecondPayment3")
                dtDdmsNew.Columns.Add("ContractEnd")
                Dim dtDdmsAmend As DataTable = New DataTable()
                dtDdmsAmend = dtDdmsNew.Clone()

                Try

                    For Each dr As DataRow In drContracts
                        Dim ddmsRef As String = Helper.MakeStringValid(dr("DDMSRef"))
                        Dim contractRef As String = Helper.MakeStringValid(dr("ContractReference"))
                        Dim payType As String = Helper.MakeStringValid(dr("Type"))
                        Dim siteId As Integer = Helper.MakeIntegerValid(dr("siteid"))
                        Dim installments As Integer = Helper.MakeIntegerValid(dr("installments"))
                        Dim pifId As Integer = If((Helper.MakeIntegerValid(dr("PreviousInvoiceFrequencyID")) = 0), Helper.MakeIntegerValid(dr("InvoiceFrequencyID")), Helper.MakeIntegerValid(dr("PreviousInvoiceFrequencyID")))
                        Dim invoiceFreq As Enums.InvoiceFrequency = CType(Helper.MakeIntegerValid(dr("InvoiceFrequencyID")), Enums.InvoiceFrequency)
                        Dim paymentMade As Boolean = False

                        If installments Mod 12 = 0 AndAlso installments <> 0 Then
                        Else
                            paymentMade = True
                        End If

                        Dim processing As DateTime = Helper.MakeDateTimeValid(dr("DDProcessingDate"))
                        Dim contractEnd As DateTime = Helper.MakeDateTimeValid(dr("ContractEndDate"))
                        Dim wrapper As Simple3Des = New Simple3Des(p)
                        Dim ddSort As String = String.Empty
                        Dim ddAcc As String = String.Empty

                        Try
                            ddSort = wrapper.DecryptData(Helper.MakeStringValid(dr("sc")))
                            ddAcc = wrapper.DecryptData(Helper.MakeStringValid(dr("Ac")))
                        Catch ex As Exception
                        End Try

                        Dim cc As Object = Nothing

                        If ddmsRef.Length > 3 Then
                            cc = App.DB.ExecuteScalar("SELECT COUNT(DDMSREF) FROM tblContractOriginal co " & "INNER JOIN tblContractOriginalSite cos ON cos.ContractID = co.ContractID " & "Where co.Deleted = 0 AND co.DDMSREF = '" & ddmsRef & "' AND cos.SiteID <> " & siteId)
                        Else
                            cc = App.DB.ExecuteScalar("SELECT COUNT(DDMSREF) FROM tblContractOriginal co " & "INNER JOIN tblContractOriginalSite cos ON cos.ContractID = co.ContractID " & "Where co.Deleted = 0 AND co.DDMSREF = '" & contractRef & "' AND cos.SiteID <> " & siteId)
                        End If

                        If Helper.MakeIntegerValid(cc) < 1 Then
                            Dim priceDiff As Double = Helper.MakeDoubleValid(dr("FirstAmount")) - Helper.MakeDoubleValid(dr("SecondPayment"))
                            Dim drDDMSNew As DataRow = dtDdmsNew.NewRow()
                            drDDMSNew("Ref") = If((ddmsRef.Length > 3), ddmsRef, contractRef)
                            drDDMSNew("Salutation") = Helper.MakeStringValid(dr("PayerSalutation")).Replace(",", "")
                            drDDMSNew("FirstName") = Helper.MakeStringValid(dr("PayerFirst")).Replace(",", "")
                            drDDMSNew("LastName") = Helper.MakeStringValid(dr("PayerSurname")).Replace(",", "")
                            drDDMSNew("Address1") = Helper.MakeStringValid(dr("PayerAddress1")).Replace(",", "")
                            drDDMSNew("Address2") = Helper.MakeStringValid(dr("PayerAddress2")).Replace(",", "")
                            drDDMSNew("Address3") = Helper.MakeStringValid(dr("PayerAddress3")).Replace(",", "")
                            drDDMSNew("Address4") = Helper.MakeStringValid(dr("PayerAddress4")).Replace(",", "")
                            drDDMSNew("Tel") = Helper.MakeStringValid(dr("PayerTel")).Replace(",", "")
                            drDDMSNew("Postcode") = Helper.FormatPostcode(dr("PayerPostCode")).Replace(",", "")
                            drDDMSNew("SortCode") = ddSort
                            drDDMSNew("AccNum") = ddAcc
                            drDDMSNew("NameOnAcc") = If((Helper.MakeStringValid(dr("AccName")).Length > 0), Helper.MakeStringValid(dr("AccName")).Replace(",", ""), Helper.MakeStringValid(dr("PayerName")).Replace(",", ""))
                            drDDMSNew("Ref2") = If((ddmsRef.Length > 3), ddmsRef, contractRef)
                            drDDMSNew("InvoiceNumber") = Helper.MakeStringValid(dr("InvoiceNumber")).Replace(",", "")
                            drDDMSNew("Type") = "17"
                            drDDMSNew("SecondPayment") = Helper.MakeStringValid(dr("SecondPayment")).Replace(",", "")
                            drDDMSNew("FirstPayment") = If((paymentMade), "0", Helper.MakeStringValid(priceDiff.ToString()))
                            drDDMSNew("ProcessDate") = If((Not paymentMade), DateHelper.GetFirstDayOfMonth(processing).ToString("dd/MM/yyyy"), DateHelper.GetFirstDayOfMonth(processing.AddMonths(1)).ToString("dd/MM/yyyy"))
                            drDDMSNew("Installments") = Helper.MakeStringValid(dr("Installments")).Replace(",", "")
                            drDDMSNew("SecondPayment2") = Helper.MakeStringValid(dr("SecondPayment"))
                            drDDMSNew("SecondPayment3") = If((paymentMade), Helper.MakeStringValid(dr("SecondPayment")), Helper.MakeStringValid(dr("FirstAmount")))
                            drDDMSNew("ContractEnd") = contractEnd.ToString("dd/MM/yyyy")

                            If Helper.MakeIntegerValid(dr("Renewed")) = 0 OrElse (pifId <> Helper.MakeIntegerValid(dr("InvoiceFrequencyID"))) OrElse payType = "TRANSD" OrElse payType = "AMMENDD" OrElse payType = "RENEWALD" Then

                                If installments = 0 AndAlso invoiceFreq <> Enums.InvoiceFrequency.AnnuallyDD Then
                                Else
                                    dtDdmsNew.Rows.Add(drDDMSNew)
                                End If
                            ElseIf payType <> "AMMEND" AndAlso payType <> "TRANS" Then

                                If installments = 0 Then
                                Else
                                    dtDdmsAmend.Rows.Add(drDDMSNew.ItemArray)
                                End If
                            End If
                        End If
                    Next
                Catch ex As Exception
                    ShowMessage("Could not generate ddms : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try

                Try
                    Dim ddmsNewCsv As String = "DDMS_IMPORT_NEW" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".csv"
                    Dim ddmsAmendCsv As String = "DDMS_IMPORT_RENEW_AMMEND" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".csv"
                    Dim ddmsNewCsvData As String = ExportHelper.DataTableToCSVNoHeaders(dtDdmsNew)
                    Dim ddmsAmendCsvData As String = String.Format(ExportHelper.DataTableToCSVNoHeaders(dtDdmsAmend))
                    Dim fileDir As String = TheSystem.Configuration.DocumentsLocation & "Contracts\DDMS\"
                    Directory.CreateDirectory(fileDir)
                    Dim fsDdmsNew As FileStream = New FileStream(fileDir & ddmsNewCsv, FileMode.OpenOrCreate, FileAccess.ReadWrite)

                    Using fsDdmsNew
                        Dim info As Byte() = New UTF8Encoding(True).GetBytes(ddmsNewCsvData)
                        fsDdmsNew.Write(info, 0, info.Length)
                    End Using

                    fsDdmsNew.Close()
                    Dim fsDdmsAmend As FileStream = New FileStream(fileDir & ddmsAmendCsv, FileMode.OpenOrCreate, FileAccess.ReadWrite)

                    Using fsDdmsAmend
                        Dim info As Byte() = New UTF8Encoding(True).GetBytes(ddmsAmendCsvData)
                        fsDdmsAmend.Write(info, 0, info.Length)
                    End Using

                    fsDdmsAmend.Close()
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate ddms : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateRenewalLetters(ByVal drContracts As DataRow()) As String
                Dim fileName As String = "Contract_Renewal_" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".docx"
                Dim fileDir As String = TheSystem.Configuration.DocumentsLocation & "Contracts\Renewal"
                Directory.CreateDirectory(fileDir)
                Dim filePath As String = fileDir & "\" & fileName
                File.Copy(Application.StartupPath & "\Templates\Blank.docx", filePath)

                Try
                    Dim batch As WordprocessingDocument = WordprocessingDocument.Open(filePath, True)
                    Using batch
                        For Each dr As DataRow In drContracts
                            Dim payType As String = Helper.MakeStringValid(dr("Type"))
                            Dim success As Boolean = False
                            Dim renewed As Boolean = Helper.MakeBooleanValid(dr("Renewed"))
                            Dim invoiceFreq As Enums.InvoiceFrequency = CType(Helper.MakeIntegerValid(dr("InvoiceFrequencyID")), Enums.InvoiceFrequency)
                            Dim installments As Integer = Helper.MakeIntegerValid(dr("installments"))

                            If payType = "AMMEND" OrElse payType = "TRANS" Then
                            Else
                                If (Not renewed AndAlso installments > 0) Or
                                    (payType = "TRANSD" OrElse payType = "RENEWALD" OrElse payType = "AMMENDD") Or
                                    (Not renewed AndAlso invoiceFreq = Enums.InvoiceFrequency.AnnuallyDD) Then
                                    success = GenerateDDLetter(dr, batch)

                                    If Not success Then
                                        Throw New Exception
                                    End If
                                ElseIf installments > 0 Then
                                    success = GenerateDDRenewalLetter(dr, batch)

                                    If Not success Then
                                        Throw New Exception
                                    End If
                                End If
                            End If

                            success = GenerateContractLetter(dr, batch)

                            If Not success Then
                                Throw New Exception
                            End If

                            If Not String.IsNullOrEmpty(Helper.MakeStringValid(dr("InvoiceNumber"))) Then

                                If String.IsNullOrEmpty(Helper.MakeStringValid(dr("InitialPaymentType"))) OrElse
                                    Helper.MakeStringValid(dr("InitialPaymentType")) <> "Invoice" Then
                                    success = GenerateReceipt(dr, batch)

                                    If Not success Then
                                        Throw New Exception
                                    End If
                                Else
                                    success = GenerateContractInvoice(dr, batch)

                                    If Not success Then
                                        Throw New Exception
                                    End If
                                End If
                            End If

                            If payType = "TRANS" Then
                                success = GenerateTransferLetter(dr, batch)

                                If Not success Then
                                    Throw New Exception
                                End If
                            End If
                        Next
                    End Using

                    Return filePath
                Catch ex As Exception
                    ShowMessage("Could not generate renewal letter : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return String.Empty
                End Try
            End Function

            Private Function GenerateDDLetter(ByVal dr As DataRow, ByVal batch As WordprocessingDocument) As Boolean
                Try
                    If Helper.MakeStringValid(dr("UpgradedFrom")).Length > 0 Then Return True
                    Dim invoiceFreq As Enums.InvoiceFrequency = CType(Helper.MakeIntegerValid(dr("InvoiceFrequencyID")), Enums.InvoiceFrequency)
                    Dim template As String = Application.StartupPath & "\Templates\Contracts"
                    template += If((invoiceFreq = Enums.InvoiceFrequency.AnnuallyDD), "\ContractDDA.docx", "\ContractDD.docx")
                    Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")))
                    Dim fileByte As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream()

                    Using mm
                        mm.Write(fileByte, 0, fileByte.Length)
                        Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                        Using doc
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule)
                            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"))
                            Dim companyName As String = If((Helper.MakeStringValid(dr("PayerSalutation")).Length > 0), Helper.MakeStringValid(dr("PayerSalutation") & " " & dr("PayerSurname")), Helper.MakeStringValid(dr("PayerName")))
                            PrintHelper.ReplaceText(doc, "[CompanyName]", companyName)
                            PrintHelper.ReplaceText(doc, "[Name]", companyName)
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("PayerAddress1")))
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("PayerAddress2")))
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("PayerAddress3")))
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("PayerPostcode")))
                            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(dr("ContractType")))
                            Dim ddmsRef As String = If((Helper.MakeStringValid(dr("DDMSRef")).Length > 3), Helper.MakeStringValid(dr("DDMSRef")), Helper.MakeStringValid(dr("ContractReference")))
                            PrintHelper.ReplaceText(doc, "[DebitRef]", ddmsRef)
                            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(dr("ContractReference") & " - " & dr("siteAddress1") & ", " & dr("siteAddress2") & ", " & dr("sitePostcode")))
                            Dim installments As Integer = Helper.MakeIntegerValid(dr("installments"))
                            Dim paymentMade As Boolean = False
                            Dim contractStart As DateTime = Helper.MakeDateTimeValid(dr("ContractStartDate"))
                            Dim processing As DateTime = Helper.MakeDateTimeValid(dr("DDProcessingDate"))

                            If installments Mod 12 = 0 Then
                                processing = If(contractStart = DateHelper.GetFirstDayOfMonth(contractStart), DateHelper.GetFirstDayOfMonth(contractStart), DateHelper.GetFirstDayOfMonth(contractStart.AddMonths(1)))
                                PrintHelper.ReplaceText(doc, "[FirstDate]", processing.ToString("dd/MM/yyyy"))
                            Else
                                paymentMade = True
                                PrintHelper.ReplaceText(doc, "[FirstDate]", DateHelper.GetFirstDayOfMonth(processing.AddMonths(1)).ToString("dd/MM/yyyy"))
                            End If

                            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(dr("siteAddress1") & ", " & dr("siteAddress2") & ", " & dr("sitePostcode")))
                            PrintHelper.ReplaceText(doc, "[First]", If((paymentMade), Helper.MakeDoubleValid(dr("SecondPayment")).ToString("C"), Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C")))
                            PrintHelper.ReplaceText(doc, "[Second]", Helper.MakeDoubleValid(dr("SecondPayment")).ToString("C"))
                            PrintHelper.ReplaceText(doc, "[Inst]", (Helper.MakeIntegerValid(dr("Installments")) - 1).ToString())
                            Dim acName As String = If((Helper.MakeStringValid(dr("AccName")).Length > 0), Helper.MakeStringValid(dr("AccName")), Helper.MakeStringValid(dr("PayerName")))
                            PrintHelper.ReplaceText(doc, "[AcName]", acName)
                            Dim wrapper As Simple3Des = New Simple3Des(p)
                            Dim ddSort As String = String.Empty
                            Dim ddAcc As String = String.Empty

                            Try
                                ddSort = wrapper.DecryptData(Helper.MakeStringValid(dr("sc")))
                                ddAcc = wrapper.DecryptData(Helper.MakeStringValid(dr("Ac")))
                            Catch
                            End Try

                            PrintHelper.ReplaceText(doc, "[AcNumber]", ddAcc)
                            PrintHelper.ReplaceText(doc, "[ScCode]", ddSort)
                            Dim ahe As Double = CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                            PrintHelper.ReplaceText(doc, "[AHE]", If((invoiceFreq = Enums.InvoiceFrequency.AnnuallyDD), ahe.ToString("C"), Math.Round(ahe / 12, 2).ToString("C")))
                            Dim pageCount As Integer = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText)
                            Dim addBreaks As Integer = 1
                            addBreaks += If((pageCount Mod 2 = 0), 0, 1)

                            For i As Integer = 0 To addBreaks - 1
                                doc.MainDocumentPart.Document.Body.InsertAfter(
                                    New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})),
                                    doc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            Next

                            doc.MainDocumentPart.Document.Save()
                            Dim saveDir As String = TheSystem.Configuration.DocumentsLocation & "SiteContracts\" & Helper.MakeStringValid(dr("ContractReference"))
                            Directory.CreateDirectory(saveDir)
                            Dim fileName As String = "DD_" & DateTime.Now.ToString("dd_MM_yyyy_HH_mm") & ".docx"
                            Dim savePath As String = saveDir & "\" & fileName
                            savePath = FileCheck(savePath)
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0

                            Using fileStream
                                mm.WriteTo(fileStream)
                            End Using

                            fileStream.Close()
                        End Using

                        Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                        Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr("ContractID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                        Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                        mm.Position = 0

                        Using mm
                            chunk.FeedData(mm)
                        End Using

                        Dim altChunk As WP.AltChunk = New WP.AltChunk()
                        altChunk.Id = altChunkId
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                        mainPart.Document.Save()
                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate dd letter : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateDDRenewalLetter(ByVal dr As DataRow, ByVal batch As WordprocessingDocument) As Boolean
                Try
                    Dim invoiceFreq As Enums.InvoiceFrequency = CType(Helper.MakeIntegerValid(dr("InvoiceFrequencyID")), Enums.InvoiceFrequency)
                    Dim template As String = Application.StartupPath & "\Templates\Contracts"
                    template += If((invoiceFreq = Enums.InvoiceFrequency.AnnuallyDD), "\ContractDDARenewal.docx", "\ContractDDRenewal.docx")
                    Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")))
                    Dim fileByte As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream()

                    Using mm
                        mm.Write(fileByte, 0, fileByte.Length)
                        Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)

                        Using doc
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule)
                            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"))
                            Dim companyName As String = If((Helper.MakeStringValid(dr("PayerSalutation")).Length > 0), Helper.MakeStringValid(dr("PayerSalutation") & " " & dr("PayerSurname")), Helper.MakeStringValid(dr("PayerName")))
                            PrintHelper.ReplaceText(doc, "[CompanyName]", companyName)
                            PrintHelper.ReplaceText(doc, "[Name]", companyName)
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("PayerAddress1")))
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("PayerAddress2")))
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("PayerAddress3")))
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("PayerPostcode")))
                            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(dr("ContractType")))
                            Dim ddmsRef As String = If((Helper.MakeStringValid(dr("DDMSRef")).Length > 3), Helper.MakeStringValid(dr("DDMSRef")), Helper.MakeStringValid(dr("ContractReference")))
                            PrintHelper.ReplaceText(doc, "[DebitRef]", ddmsRef)
                            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(dr("ContractReference") & " - " & dr("siteAddress1") & ", " & dr("siteAddress2") & ", " & dr("sitePostcode")))
                            Dim installments As Integer = Helper.MakeIntegerValid(dr("installments"))
                            Dim paymentMade As Boolean = False
                            Dim contractStart As DateTime = Helper.MakeDateTimeValid(dr("ContractStartDate"))
                            Dim processing As DateTime = Helper.MakeDateTimeValid(dr("DDProcessingDate"))

                            If (installments Mod 12 = 0 AndAlso installments <> 0) Or (invoiceFreq = Enums.InvoiceFrequency.AnnuallyDD AndAlso installments = 1) Then
                                PrintHelper.ReplaceText(doc, "[FirstDate]", If((contractStart.Day = 1), DateHelper.GetFirstDayOfMonth(contractStart).ToString("dd/MM/yyyy"),
                                                        DateHelper.GetFirstDayOfMonth(contractStart.AddMonths(1)).ToString("dd/MM/yyyy")))
                            Else
                                paymentMade = True
                                PrintHelper.ReplaceText(doc, "[FirstDate]", DateHelper.GetFirstDayOfMonth(contractStart.AddMonths(2)).ToString("dd/MM/yyyy"))
                            End If

                            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(dr("siteAddress1") & ", " & dr("siteAddress2") & ", " & dr("sitePostcode")))
                            PrintHelper.ReplaceText(doc, "[First]", If((paymentMade), Helper.MakeDoubleValid(dr("SecondPayment")).ToString("C"), Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C")))
                            PrintHelper.ReplaceText(doc, "[Second]", Helper.MakeDoubleValid(dr("SecondPayment")).ToString("C"))
                            PrintHelper.ReplaceText(doc, "[Inst]", (Helper.MakeIntegerValid(dr("Installments")) - 1).ToString())
                            PrintHelper.ReplaceText(doc, "[Inst2]", (Helper.MakeIntegerValid(dr("Installments"))).ToString())

                            Dim monthlyApp As Double = 0.0
                            Dim contractType As Integer = Helper.MakeIntegerValid(dr("ContractTypeID"))
                            If contractType = CInt(Enums.ContractTypes.PlatinumStar) Then
                                monthlyApp = CDbl(DB.Picklists.Get_Single_Description("PS Additional Monthly", 52))
                            Else
                                monthlyApp = CDbl(DB.Picklists.Get_Single_Description("Additional Monthly", 52))
                            End If
                            PrintHelper.ReplaceText(doc, "[MonthApp]", If((invoiceFreq = Enums.InvoiceFrequency.AnnuallyDD), Math.Round(monthlyApp * 12, 2).ToString("C"), monthlyApp.ToString("C")))
                            Dim ahe As Double = CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                            PrintHelper.ReplaceText(doc, "[AHE]", If((invoiceFreq = Enums.InvoiceFrequency.AnnuallyDD), ahe.ToString("C"), Math.Round(ahe / 12, 2).ToString("C")))
                            PrintHelper.ReplaceText(doc, "[UserName]", TheSystem.Configuration.CompanyName & " Coverplan Team")
                            Dim pageCount As Integer = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText)
                            Dim addBreaks As Integer = 1
                            addBreaks += If((pageCount Mod 2 = 0), 0, 1)

                            For i As Integer = 0 To addBreaks - 1
                                doc.MainDocumentPart.Document.Body.InsertAfter(
                                    New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})),
                                    doc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            Next

                            doc.MainDocumentPart.Document.Save()
                            Dim saveDir As String = TheSystem.Configuration.DocumentsLocation & "SiteContracts\" & Helper.MakeStringValid(dr("ContractReference"))
                            Directory.CreateDirectory(saveDir)
                            Dim fileName As String = "DDRenewal_" & DateTime.Now.ToString("dd_MM_yyyy_HH_mm") & ".docx"
                            Dim savePath As String = saveDir & "\" & fileName
                            savePath = FileCheck(savePath)
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0

                            Using fileStream
                                mm.WriteTo(fileStream)
                            End Using

                            fileStream.Close()
                        End Using

                        Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                        Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr("ContractID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                        Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                        mm.Position = 0

                        Using mm
                            chunk.FeedData(mm)
                        End Using

                        Dim altChunk As WP.AltChunk = New WP.AltChunk()
                        altChunk.Id = altChunkId
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                        mainPart.Document.Save()
                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate dd renewal letter : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateContractLetter(ByVal dr As DataRow, Optional ByVal batch As WordprocessingDocument = Nothing) As Boolean
                Try
                    Dim template As String = Application.StartupPath & "\Templates\Contracts\ContractOption11.docx"
                    Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")))
                    Dim fileByte As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream()

                    Using mm
                        mm.Write(fileByte, 0, fileByte.Length)
                        Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)

                        Using doc
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule)
                            Dim customerName As String = If((Helper.MakeIntegerValid(dr("CustomerID")) = CInt(Enums.Customer.Domestic)), Helper.MakeStringValid(dr("SiteName")), Helper.MakeStringValid(dr("CustName")))
                            Dim dvAdditionalContacts As DataView = DB.Contact.Contacts_GetAll_ForLink(CInt(Enums.TableNames.tblSite), Helper.MakeIntegerValid(dr("SiteID")))
                            Dim drOnContractContacts As DataRow() = dvAdditionalContacts.Table.Select("OnContract = 1")
                            For Each drContact As DataRow In drOnContractContacts
                                customerName += " / " & Helper.MakeStringValid(drContact("Title")) & " " &
                                    Helper.MakeStringValid(drContact("FirstName")) & " " & Helper.MakeStringValid(drContact("LastName"))
                            Next
                            PrintHelper.ReplaceText(doc, "[CustomerName]", customerName)
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("SiteAddress1")))
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("SiteAddress2")))
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("SiteAddress3")))
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("SitePostcode")))
                            PrintHelper.ReplaceText(doc, "[ContractType]", Helper.MakeStringValid(dr("ContractType")))
                            PrintHelper.ReplaceText(doc, "[ContractReference]", Helper.MakeStringValid(dr("ContractReference")))
                            PrintHelper.ReplaceText(doc, "[ContractStart]", Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy"))
                            PrintHelper.ReplaceText(doc, "[ContractEnd]", Helper.MakeDateTimeValid(dr("ContractEndDate")).ToString("dd/MM/yyyy"))
                            Dim contractTotal As Double = Math.Round(Helper.MakeDoubleValid(dr("ContractPrice")) * 1.2, 2)
                            PrintHelper.ReplaceText(doc, "[Total]", contractTotal.ToString("C"))
                            Dim drAssets As DataRow() = DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(Helper.MakeIntegerValid(dr("ContractSiteID")), Helper.MakeIntegerValid(dr("SiteID"))).Table.Select("Tick = 1")
                            Dim dtAssets As DataTable = New DataTable()
                            dtAssets.Columns.Add("ApplianceCount")
                            dtAssets.Columns.Add("Appliance")
                            Dim primaryAssetCount As Integer = 0
                            Dim secondaryAssetCount As Integer = 0
                            Dim count As Integer = 1

                            If drAssets.Count > 0 Then
                                Dim drPrimaryAssets As DataRow() = (From a In drAssets.CopyToDataTable().AsEnumerable Where Helper.MakeBooleanValid(a("PrimAsset")) = True Select a).ToArray()
                                primaryAssetCount = drPrimaryAssets.Length

                                For Each drContractAsset As DataRow In drPrimaryAssets
                                    Dim drAsset As DataRow = dtAssets.NewRow()
                                    drAsset("ApplianceCount") = "APPLIANCE " & count
                                    drAsset("Appliance") = drContractAsset("Product")
                                    dtAssets.Rows.Add(drAsset)
                                    count += 1
                                Next

                                Dim drSecondaryAssets As DataRow() = (From a In drAssets.CopyToDataTable().AsEnumerable Where Helper.MakeBooleanValid(a("PrimAsset")) = False Select a).ToArray()
                                secondaryAssetCount = drSecondaryAssets.Length

                                For Each drContractAsset As DataRow In drSecondaryAssets
                                    Dim drAsset As DataRow = dtAssets.NewRow()
                                    drAsset("ApplianceCount") = "APPLIANCE " & count
                                    drAsset("Appliance") = drContractAsset("Product")
                                    dtAssets.Rows.Add(drAsset)
                                    count += 1
                                Next
                            End If

                            For i As Integer = 0 To (Helper.MakeIntegerValid(dr("MainAppliances")) - primaryAssetCount) - 1
                                Dim drAsset As DataRow = dtAssets.NewRow()
                                drAsset("ApplianceCount") = "APPLIANCE " & count
                                drAsset("Appliance") = If((String.IsNullOrEmpty(Helper.MakeStringValid(dr("ManualApp")))), "UNKNOWN APPLIANCE", Helper.MakeStringValid(dr("ManualApp")))
                                dtAssets.Rows.Add(drAsset)
                                count += 1
                            Next

                            For i As Integer = 0 To (Helper.MakeIntegerValid(dr("SecondryAppliances")) - secondaryAssetCount) - 1
                                Dim drAsset As DataRow = dtAssets.NewRow()
                                drAsset("ApplianceCount") = "APPLIANCE " & count
                                drAsset("Appliance") = If((String.IsNullOrEmpty(Helper.MakeStringValid(dr("ManualApp")))), "UNKNOWN APPLIANCE", Helper.MakeStringValid(dr("SecondApp")))
                                dtAssets.Rows.Add(drAsset)
                                count += 1
                            Next

                            PrintHelper.ReplaceBookmarkWithTable(doc, "ApplianceTable", dtAssets, False, Enums.TableCellProperties.ContractAppliance)
                            Dim hasWindowLockPest As Boolean = Helper.MakeBooleanValid(dr("WindowLockPest"))
                            Dim hasPlumbingDrainage As Boolean = Helper.MakeBooleanValid(dr("PlumbingDrainage"))
                            Dim hasGasSupplyPipework As Boolean = Helper.MakeBooleanValid(dr("GasSupplyPipework"))
                            PrintHelper.ReplaceText(doc, "[GasSupplyPipework]", If((hasGasSupplyPipework), "Yes", "No"))
                            PrintHelper.ReplaceText(doc, "[PlumbingDrainage]", If((hasPlumbingDrainage), "Yes", "No"))
                            PrintHelper.ReplaceText(doc, "[WindowLockPest]", If((hasWindowLockPest), "Yes", "No"))
                            PrintHelper.ReplaceText(doc, "[UserName]", TheSystem.Configuration.CompanyName & " Coverplan Team")
                            Dim pageCount As Integer = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText)
                            Dim para As WP.Paragraph = New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page}))
                            doc.MainDocumentPart.Document.Body.InsertAfter(para, doc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            doc.MainDocumentPart.Document.Save()
                            Dim templateTnC As String = Application.StartupPath & "\Templates\Contracts\ContractTermsAndConditions.docx"
                            Dim fileByteTnC As Byte() = File.ReadAllBytes(templateTnC)
                            Dim mmTnC As MemoryStream = New MemoryStream()

                            Using mmTnC
                                mmTnC.Write(fileByteTnC, 0, fileByteTnC.Length)
                                Dim docTnC As WordprocessingDocument = WordprocessingDocument.Open(mmTnC, True)

                                Using docTnC

                                    If Helper.MakeIntegerValid(dr("DiscountID")) <> CInt(Enums.ContractTypes.EmployeeFree) Then
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef")
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef1")
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef2")
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef3")
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef4")
                                    End If

                                    Dim termsPageCount As Integer = Helper.MakeIntegerValid(docTnC.ExtendedFilePropertiesPart.Properties.Pages.InnerText)
                                    Dim addBreaks As Integer = 1
                                    addBreaks += If(((pageCount + termsPageCount) Mod 2 = 0), 0, 1)

                                    For i As Integer = 0 To addBreaks - 1
                                        docTnC.MainDocumentPart.Document.Body.InsertAfter(
                                            New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})),
                                            docTnC.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                                    Next

                                    docTnC.MainDocumentPart.Document.Save()
                                End Using

                                Dim mainPartContract As MainDocumentPart = doc.MainDocumentPart
                                Dim altChunkIdContract As String = "AltId" & Helper.MakeIntegerValid(dr("ContractID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                                Dim chunkContract As AlternativeFormatImportPart = mainPartContract.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkIdContract)
                                mmTnC.Position = 0

                                Using mmTnC
                                    chunkContract.FeedData(mmTnC)
                                End Using

                                Dim altChunkContract As WP.AltChunk = New WP.AltChunk()
                                altChunkContract.Id = altChunkIdContract
                                mainPartContract.Document.Body.InsertAfter(altChunkContract, mainPartContract.Document.Body.Elements(Of WP.Paragraph)().Last())
                                mainPartContract.Document.Save()
                            End Using
                        End Using

                        Dim saveDir As String = TheSystem.Configuration.DocumentsLocation & "SiteContracts\" & Helper.MakeStringValid(dr("ContractReference"))
                        Directory.CreateDirectory(saveDir)
                        Dim fileName As String = "Contract_" & DateTime.Now.ToString("dd_MM_yyyy_HH_mm") & ".docx"
                        Dim savePath As String = saveDir & "\" & fileName
                        savePath = FileCheck(savePath)
                        Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                        mm.Position = 0

                        Using fileStream
                            mm.WriteTo(fileStream)
                        End Using

                        fileStream.Close()
                        If batch IsNot Nothing Then
                            Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                            Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr("ContractID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                            Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                            mm.Position = 0

                            Using mm
                                chunk.FeedData(mm)
                            End Using

                            Dim altChunk As WP.AltChunk = New WP.AltChunk()
                            altChunk.Id = altChunkId
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            mainPart.Document.Save()
                        Else
                            Process.Start(savePath)
                        End If
                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate contract letter : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateReceipt(ByVal dr As DataRow, ByVal batch As WordprocessingDocument, Optional ByVal isCommercial As Boolean = False, Optional addPage As Boolean = True) As Boolean
                Try
                    If dr.Table.Columns.Contains("UpgradedFrom") AndAlso Helper.MakeStringValid(dr("UpgradedFrom")).Length > 0 Then Return True
                    Dim invoiceFreq As Enums.InvoiceFrequency = CType(Helper.MakeIntegerValid(dr("InvoiceFrequencyID")), Enums.InvoiceFrequency)
                    Dim template As String = Application.StartupPath & "\Templates\Invoice\Receipt.docx"
                    Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")))
                    Dim fileByte As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream()

                    Using mm
                        mm.Write(fileByte, 0, fileByte.Length)
                        Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)

                        Using doc
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule)
                            AddCompanyDetails(doc, True, False, isCommercial)
                            PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dr("PayerName")))
                            PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dr("Payeraddress1")))
                            PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dr("PayerAddress2")))
                            PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dr("PayerAddress3")))
                            PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dr("PayerPostcode")))
                            PrintHelper.ReplaceText(doc, "[InvoiceNumber]", Helper.MakeStringValid(dr("InvoiceNumber")))
                            PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(dr("RaiseDate")).ToString("dd/MM/yyyy"))
                            PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dr("CustAcc")))
                            Dim dtContract As DataTable = New DataTable()
                            dtContract.Columns.Add("ContractReference")
                            dtContract.Columns.Add("Address")
                            dtContract.Columns.Add("Work")
                            dtContract.Columns.Add("Total")
                            Dim drContract As DataRow = dtContract.NewRow()
                            drContract("ContractReference") = If((String.IsNullOrEmpty(Helper.MakeStringValid(dr("PoNumber")))), Helper.MakeStringValid(dr("ContractReference")), Helper.MakeStringValid(dr("ContractReference") & " / " & dr("PoNumber")))
                            drContract("Address") = Helper.MakeStringValid(dr("SiteAddress1") & ", " & dr("SiteAddress2") & ", " & dr("SitePostcode"))
                            Dim payType As String = Helper.MakeStringValid(dr("Type"))
                            Dim contractType As String = Helper.MakeStringValid(dr("ContractType"))
                            Dim installments As Integer = Helper.MakeIntegerValid(dr("installments"))
                            Dim paymentMade As Boolean = False
                            Dim renewed As Boolean = Helper.MakeBooleanValid(dr("Renewed"))
                            Dim contractTotal As Double = Helper.MakeDoubleValid(dr("ContractPrice"))
                            Dim subTotal As Double = 0.0

                            If installments Mod 12 = 0 AndAlso installments <> 0 Then
                            Else
                                paymentMade = True
                            End If

                            If renewed AndAlso installments = 0 Then
                                drContract("Work") = contractType & " Coverplan Renewal " & vbCrLf & vbCrLf & "Paid " & Math.Round(contractTotal * 1.2, 2).ToString("C") & " by " & Helper.MakeStringValid(dr("InitialPaymentType")) & ", received with thanks." & "" & vbCrLf & vbCrLf & "Please find enclosed your certificate of cover." & vbCrLf & vbCrLf & "Thank you for renewing your plan."
                                drContract("Total") = contractTotal.ToString("C")
                                subTotal += contractTotal
                            ElseIf installments = 0 Then
                                drContract("Work") = contractType & " Coverplan commencing " & Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") & "." & vbCrLf & vbCrLf & "Paid " & Math.Round(contractTotal * 1.2, 2).ToString("C") & " by " & Helper.MakeStringValid(dr("InitialPaymentType")) & ", received with thanks. " & vbCrLf & vbCrLf & "Please find enclosed your certificate of cover." & vbCrLf & vbCrLf & "Thank you for taking out this plan."
                                drContract("Total") = contractTotal.ToString("C")
                                subTotal += contractTotal
                            ElseIf installments = 1 OrElse invoiceFreq = Enums.InvoiceFrequency.AnnuallyDD Then
                                drContract("Work") = contractType & " Coverplan commencing " & Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") & "." & vbCrLf & vbCrLf & "1 payment of " & Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C") & " to be paid annually by direct debit" & "" & vbCrLf & vbCrLf & "Please find enclosed your certificate of cover." & vbCrLf & vbCrLf & "Thank you for taking out this plan."
                                drContract("Total") = Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C")
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero)
                            ElseIf installments > 0 AndAlso paymentMade AndAlso (payType = "AMMENDD" OrElse payType = "TRANSD" OrElse payType = "RENEWALD") Then
                                drContract("Work") = contractType & " Coverplan commencing " & Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") & "." & vbCrLf & vbCrLf & "1st payment of " & Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C") & " paid by " & Helper.MakeStringValid(dr("InitialPaymentType")) & ", received with thanks. " & installments & " payments to be paid by monthly direct debit " & vbCrLf & vbCrLf & "Please find enclosed your certificate of cover." & vbCrLf & vbCrLf & "Thank you for renewing your plan."
                                drContract("Total") = Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C")
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero)
                            ElseIf installments > 0 AndAlso paymentMade Then
                                drContract("Work") = contractType & " Coverplan commencing " & Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") & "." & vbCrLf & vbCrLf & "1st payment of " & Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C") & " paid by " & Helper.MakeStringValid(dr("InitialPaymentType")) & ", received with thanks. " & installments & " payments to be paid by monthly direct debit " & vbCrLf & vbCrLf & "Please find enclosed your certificate of cover." & vbCrLf & vbCrLf & "Thank you for taking out this plan."
                                drContract("Total") = Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C")
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero)
                            ElseIf installments > 0 Then
                                drContract("Work") = contractType & " Coverplan commencing " & Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") & "." & vbCrLf & vbCrLf & "1 payment of " & Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C") & " to be paid by Annual direct debit " & vbCrLf & vbCrLf & "Please find enclosed your certificate of cover." & vbCrLf & vbCrLf & "Thank you for taking out this plan."
                                drContract("Total") = Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C")
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero)
                            End If

                            dtContract.Rows.Add(drContract)
                            PrintHelper.AddRowsToTable(doc, "Job No", dtContract, "Arial", "20")
                            PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"))
                            PrintHelper.ReplaceText(doc, "[VAT]", Helper.RoundDown(subTotal * 0.2, 2).ToString("C"))
                            PrintHelper.ReplaceText(doc, "[TiVAT]", Helper.RoundDown(subTotal * 1.2, 2).ToString("C"))
                            If addPage Then
                                Dim pageCount As Integer = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText)
                                Dim addBreaks As Integer = 1
                                addBreaks += If((pageCount Mod 2 = 0), 0, 1)

                                For i As Integer = 0 To addBreaks - 1
                                    doc.MainDocumentPart.Document.Body.InsertAfter(New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})), doc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                                Next
                            End If

                            doc.MainDocumentPart.Document.Save()
                            Dim saveDir As String = TheSystem.Configuration.DocumentsLocation & "SiteContracts\" & Helper.MakeStringValid(dr("ContractReference"))
                            Directory.CreateDirectory(saveDir)
                            Dim fileName As String = "Receipt_" & DateTime.Now.ToString("dd_MM_yyyy_HH_mm") & ".docx"
                            Dim savePath As String = saveDir & "\" & fileName
                            savePath = FileCheck(savePath)
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0

                            Using fileStream
                                mm.WriteTo(fileStream)
                            End Using

                            fileStream.Close()
                        End Using

                        Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                        Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr("ContractID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                        Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                        mm.Position = 0

                        Using mm
                            chunk.FeedData(mm)
                        End Using

                        Dim altChunk As WP.AltChunk = New WP.AltChunk()
                        altChunk.Id = altChunkId
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                        mainPart.Document.Save()
                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate dd renewal letter : " & vbNewLine & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateCredit(ByVal dt As DataTable, ByVal savePath As String) As Boolean
                Try
                    Dim rr As DataRow() = Nothing
                    If dt.Columns.Contains("Credit") Then
                        rr = dt.Select("Credit > 0")
                    Else
                        rr = dt.Select("Amount > 0")
                    End If
                    Dim dtInvoiceDetails As DataTable = DB.Invoiced.InvoiceDetails_Get_InvoicedID(CInt(dt.Rows(0)("InvoicedID"))).Table

                    If dtInvoiceDetails.Rows.Count > 0 Then
                        If rr.Length > 0 Then

                            Dim template As String = Application.StartupPath & "\Templates\Invoice\SalesCredit.docx"
                            Dim subTotal As Double = 0.0
                            Dim oCredit As SalesCredits.SalesCredit = If(rr.Length = 1, DB.SalesCredit.SalesCredit_Get(rr(0)("SalesCreditID")), DB.SalesCredit.SalesCredit_Get_For_InvoicedLine(rr(0)("InvoicedLineID")))
                            Dim site As Sites.Site = DB.Sites.Get(rr(0)("SiteID"))

                            Dim fileByte As Byte() = File.ReadAllBytes(template)
                            Dim mm As MemoryStream = New MemoryStream()
                            Using mm
                                mm.Write(fileByte, 0, fileByte.Length)
                                Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                                Using doc
                                    AddCompanyDetails(doc, True, False, site.RegionID = Enums.Region.GaswayCommercial)
                                    PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("SiteName")))
                                    PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("address1")))
                                    PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("address2")))
                                    PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("address3")))
                                    PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dtInvoiceDetails.Rows(0)("postcode")))
                                    PrintHelper.ReplaceText(doc, "[InvoiceNumber]", Helper.MakeStringValid(oCredit.CreditReference))
                                    PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(oCredit.DateCredited.ToString("dd/MM/yyyy")))
                                    PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("AccountNumber")))

                                    Dim dtContract As DataTable = New DataTable()
                                    dtContract.Columns.Add("ContractReference")
                                    dtContract.Columns.Add("Address")
                                    dtContract.Columns.Add("Work")
                                    dtContract.Columns.Add("Total")

                                    For Each dr As DataRow In rr

                                        Dim drContract As DataRow = dtContract.NewRow()
                                        Dim Line As InvoicedLiness.InvoicedLines = DB.InvoicedLines.InvoicedLines_Get(dr("InvoicedLineID"))

                                        drContract("ContractReference") = If((Helper.MakeStringValid(dr("PoNumber")).Length = 0), Helper.MakeStringValid(dr("JobNumber")), Helper.MakeStringValid(dr("JobNumber") & " / " & dr("PoNumber")))

                                        Select Case CType(dr("InvoiceTypeID"), Enums.InvoiceType)
                                            Case Enums.InvoiceType.Visit
                                                Dim siteVisit As Sites.Site = DB.Sites.Get(dr("SiteID"))
                                                drContract("Address") = siteVisit.Address1 & ", " & siteVisit.Address2 & ", " & Helper.FormatPostcode(site.Postcode)
                                                drContract("Work") = dr("NotesFromEngineer") & vbNewLine & vbNewLine & "Credit Against Invoice " & dr("InvoiceNumber").ToString & " - " & oCredit.ReasonForCredit
                                                drContract("Total") = Helper.MakeDoubleValid(dr("Credit")).ToString("C")
                                                subTotal += Helper.MakeDoubleValid(dr("Credit"))

                                            Case Enums.InvoiceType.Order
                                                Dim orderTotal As Double = 0.0
                                                Dim ppOrdersData As DataTable = DB.Order.Order_ItemsGetAll(dr("OrderID")).Table
                                                If ppOrdersData.Rows.Count > 0 Then
                                                    For Each ppo As DataRow In ppOrdersData.Rows
                                                        orderTotal += Helper.MakeDoubleValid(ppo("QuantityReceived")) * Helper.MakeDoubleValid(ppo("SellPrice"))
                                                    Next ppo
                                                End If

                                                Dim siteOrder As Sites.Site = DB.Sites.Get(dr("SiteID"))
                                                drContract("Address") = siteOrder.Address1 & ", " & siteOrder.Address2 & ", " & Helper.FormatPostcode(siteOrder.Postcode)
                                                drContract("Work") = ""
                                                drContract("Total") = orderTotal.ToString("C")
                                                subTotal += orderTotal

                                            Case Enums.InvoiceType.Contract_Option1
                                                Dim siteContract As Sites.Site = DB.Sites.Get(dr("SiteID"))
                                                drContract("Address") = siteContract.Address1 & ", " & siteContract.Address2 & ", " & Helper.FormatPostcode(siteContract.Postcode)
                                                If siteContract.RegionID = Enums.Region.GaswayCommercial Then
                                                    drContract("Work") = "Periodic Service Charge " & vbNewLine & vbNewLine & "Credit Against Invoice " & dr("InvoiceNumber").ToString & " - " & oCredit.ReasonForCredit
                                                Else
                                                    drContract("Work") = "Contract Payment " & vbNewLine & vbNewLine & "Credit Against Invoice " & dr("InvoiceNumber").ToString & " - " & oCredit.ReasonForCredit
                                                End If
                                                drContract("Total") = Helper.MakeDoubleValid(dr("Credit")).ToString("C")
                                                subTotal += Helper.MakeDoubleValid(dr("Credit"))
                                        End Select
                                        dtContract.Rows.Add(drContract)
                                    Next
                                    PrintHelper.AddRowsToTable(doc, "Job No", dtContract, "Arial", "20")

                                    Dim VATRate As Decimal = Helper.MakeDoubleValid(dtInvoiceDetails.Rows(0)("VATRATE"))
                                    Dim VATRateDecimal As Decimal = VATRate / 100

                                    PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"))
                                    PrintHelper.ReplaceText(doc, "[VAT]", Math.Round(subTotal * VATRateDecimal, 2).ToString("C"))
                                    PrintHelper.ReplaceText(doc, "[TiVAT]", Math.Round((subTotal * VATRateDecimal) + subTotal, 2).ToString("C"))

                                End Using

                                Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                                mm.Position = 0

                                Using fileStream
                                    mm.WriteTo(fileStream)
                                End Using

                                fileStream.Close()
                            End Using
                        End If
                    End If

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate invoice : " & vbNewLine & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateSalesInvoice(ByVal invoice As Invoiceds.Invoiced, ByVal batch As WordprocessingDocument, ByVal isCommerical As Boolean) As Boolean
                Try
                    Dim dtInvoiceDetails As DataTable = DB.Invoiced.InvoiceDetails_Get_InvoicedID(invoice.InvoicedID).Table
                    If dtInvoiceDetails.Rows.Count > 0 Then

                        Dim template As String = Application.StartupPath & "\Templates\Invoice\Invoice.docx"
                        Dim savePath As String = TheSystem.Configuration.DocumentsLocation & "SiteInvoices\" & invoice.InvoiceNumber & "\Invoice_" & DateTime.Now.ToString("dd_MM_yyyy_HH_mm") & ".docx"

                        Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(invoice.InvoicedID))

                        Dim fileByte As Byte() = File.ReadAllBytes(template)
                        Dim mm As MemoryStream = New MemoryStream()
                        Using mm
                            mm.Write(fileByte, 0, fileByte.Length)
                            Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                            Using doc
                                PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule)
                                AddCompanyDetails(doc, True, False, isCommerical)
                                PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("SiteName")))
                                PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("address1")))
                                PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("address2")))
                                PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("address3")))
                                PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dtInvoiceDetails.Rows(0).Item("postcode")))
                                PrintHelper.ReplaceText(doc, "[InvoiceNumber]", invoice.InvoiceNumber)
                                PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(invoice.RaisedDate).ToString("dd/MM/yyyy"))
                                PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("AccountNumber")))

                                Dim dtInvoiceLines As DataTable = DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(invoice.InvoicedID).Table
                                If dtInvoiceLines.Rows.Count > 0 Then
                                    Dim subTotal As Double = 0.0

                                    Dim dtJobDetails As DataTable = New DataTable()
                                    dtJobDetails.Columns.Add("Job")
                                    dtJobDetails.Columns.Add("Address")
                                    dtJobDetails.Columns.Add("Work")
                                    dtJobDetails.Columns.Add("Total")

                                    For Each line As DataRow In dtInvoiceLines.Rows
                                        Dim drJob As DataRow = dtJobDetails.NewRow()
                                        drJob("Job") = If((Helper.MakeStringValid(line("PoNumber")).Length = 0), Helper.MakeStringValid(line("JobNumber")), Helper.MakeStringValid(line("JobNumber") & " / " & line("PoNumber")))

                                        Dim additionalNotes As String = DB.Invoiced.Invoice_GetAdditionalNotes(invoice.InvoicedID)
                                        Dim site As Sites.Site = DB.Sites.Get(line("SiteID"))
                                        drJob("Address") = site.Address1 & ", " & site.Address2 & ", " & Helper.FormatPostcode(site.Postcode) & " Ref: " & site.PolicyNumber

                                        If String.IsNullOrEmpty(additionalNotes) Then
                                            additionalNotes = Helper.MakeStringValid(line("Notes"))

                                            If Not String.IsNullOrEmpty(additionalNotes) Then
                                                DB.Invoiced.Invoice_UpdateAdditionalNotes(invoice.InvoicedID, additionalNotes)
                                            End If
                                        End If

                                        Select Case CType(line("InvoiceTypeID"), Enums.InvoiceType)
                                            Case Enums.InvoiceType.Visit

                                                If Helper.MakeBooleanValid(line("UseSORDescription")) Then
                                                    Dim dt As DataTable = DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(line("EngineerVisitID")).Table
                                                    Dim sorDetails As String = ""
                                                    Dim sorTotal As Double = 0.0

                                                    For Each dr As DataRow In dt.Select("tick = 1")
                                                        sorDetails += dr("NumUnitsUsed") & " X " & dr("code") & "-" & dr("Summary") & "(£" & dr("Price") & ")" & vbCrLf & vbCrLf
                                                        sorTotal += Helper.MakeDoubleValid(dr("Total")).ToString("C")
                                                    Next
                                                    drJob("Work") = sorDetails
                                                    drJob("Total") = sorTotal.ToString("C")
                                                    subTotal += sorTotal
                                                Else
                                                    drJob("Work") = line("NotesFromEngineer")
                                                    drJob("Total") = Helper.MakeDoubleValid(line("Amount")).ToString("C")
                                                    subTotal += Helper.MakeDoubleValid(line("Amount"))
                                                End If

                                            Case Enums.InvoiceType.Order
                                                Dim orderTotal As Double = 0.0
                                                Dim ppOrdersData As DataTable = DB.Order.Order_ItemsGetAll(line("OrderID")).Table
                                                If ppOrdersData.Rows.Count > 0 Then
                                                    For Each ppo As DataRow In ppOrdersData.Rows
                                                        orderTotal += Helper.MakeDoubleValid(ppo("QuantityReceived")) * Helper.MakeDoubleValid(ppo("SellPrice"))
                                                    Next ppo
                                                End If

                                                drJob("Total") = orderTotal.ToString("C")
                                                subTotal += orderTotal

                                            Case Enums.InvoiceType.Contract_Option1
                                                Dim cont As ContractsOriginal.ContractOriginal = DB.ContractOriginal.Get(line("ContractID"))

                                                Dim period As String = ""

                                                Select Case cont.InvoiceFrequencyID
                                                    Case Enums.InvoiceFrequency_NoWeeK.Monthly
                                                        period = "Monthly"
                                                    Case Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits
                                                        period = "4 Month"
                                                    Case Enums.InvoiceFrequency_NoWeeK.Quarterly
                                                        period = "Quarterly"
                                                    Case Enums.InvoiceFrequency_NoWeeK.Bi_Annually
                                                        period = "Bi-Annual"
                                                    Case Enums.InvoiceFrequency_NoWeeK.Annually
                                                        period = "Annual"
                                                    Case Else
                                                        period = ""
                                                End Select

                                                If site.RegionID = Enums.Region.GaswayCommercial Then
                                                    drJob("Work") = period & " Service Charge for Gasway Commercial maintenance contract"
                                                Else
                                                    drJob("Work") = "Contract Payment"

                                                    If details1 = "DDRECEIPT" Then
                                                        drJob("Work") = "Unpaid Direct Debit collection for the month of " & invoice.RaisedDate.ToString("MMMM") & "." & vbNewLine & vbNewLine & "Paid by " & details2 & ", received with thanks."

                                                    ElseIf details1 = "DDINVOICE" Then
                                                        drJob("Work") = "Unpaid Direct Debit collection for the month of " & invoice.RaisedDate.ToString("MMMM") & "." & vbNewLine & vbNewLine & "Please arrange payment to cover this shortfall"
                                                    End If

                                                End If

                                                drJob("Total") = Helper.MakeDoubleValid(line("Amount")).ToString("C")
                                                subTotal += Helper.MakeDoubleValid(line("Amount"))
                                        End Select

                                        If Not String.IsNullOrEmpty(additionalNotes) Then
                                            drJob("Work") += vbNewLine & vbNewLine & additionalNotes
                                        End If

                                        dtJobDetails.Rows.Add(drJob)
                                    Next

                                    Dim drLastRow As DataRow = dtJobDetails.Rows(dtInvoiceDetails.Rows.Count - 1)

                                    Dim paymentdetails As DataTable = DB.ExecuteWithReturn("SELECT PT.Name as PaymentTerm, ISNULL(PB.NAme,'') as PaymentBy from tblinvoiced I INNER JOIN tblpicklists PT ON PT.ManagerID = I.TermID LEFT JOIN tblpicklists PB ON PB.managerid = I.PaidByID WHERE InvoicedID = " & invoice.InvoicedID)
                                    If paymentdetails.Rows.Count > 0 Then
                                        If paymentdetails.Rows(0)("PaymentTerm") = "RECEIPT" Then
                                            PrintHelper.ReplaceText(doc, "INVOICE", "RECEIPT")
                                            PrintHelper.ReplaceText(doc, "STRICTLY 30 DAYS NET", "PAID WITH THANKS")
                                            drLastRow("Work") += vbNewLine & vbNewLine & "Paid by " & paymentdetails.Rows(0)("PaymentBy") & " With thanks."
                                        Else
                                            PrintHelper.ReplaceText(doc, "STRICTLY 30 DAYS NET", paymentdetails.Rows(0)("PaymentTerm"))
                                        End If
                                    End If

                                    PrintHelper.AddRowsToTable(doc, "Job No", dtJobDetails, "Arial", "20")

                                    Dim vatRate As Decimal = Helper.MakeDoubleValid(dtInvoiceDetails.Rows(0).Item("VATRATE"))
                                    Dim vatRateDecimal As Decimal = vatRate / 100
                                    PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"))
                                    PrintHelper.ReplaceText(doc, "[VAT]", Math.Round(subTotal * vatRateDecimal, 2).ToString("C"))
                                    PrintHelper.ReplaceText(doc, "[TiVAT]", Math.Round((subTotal * vatRateDecimal) + subTotal, 2).ToString("C"))

                                    doc.MainDocumentPart.Document.Save()

                                    Directory.CreateDirectory(Path.GetDirectoryName(savePath))
                                    savePath = FileCheck(savePath)
                                    Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                                    mm.Position = 0
                                    Using fileStream
                                        mm.WriteTo(fileStream)
                                    End Using
                                End If
                            End Using

                            If batch IsNot Nothing Then
                                Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                                Dim altChunkId As String = "AltId" & invoice.InvoicedID & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                                Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                                mm.Position = 0

                                Using mm
                                    chunk.FeedData(mm)
                                End Using

                                Dim altChunk As WP.AltChunk = New WP.AltChunk()
                                altChunk.Id = altChunkId
                                mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                                mainPart.Document.Save()
                            Else
                                Process.Start(savePath)
                            End If

                        End Using
                    End If
                Catch ex As Exception
                    ShowMessage("Could not generate invoice : " & vbNewLine & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateContractInvoice(ByVal dr As DataRow, ByVal batch As WordprocessingDocument, Optional ByVal isCommerical As Boolean = False, Optional ByVal addPage As Boolean = True) As Boolean
                Try
                    Dim template As String = Application.StartupPath & "\Templates\Invoice\Invoice.docx"
                    Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")))
                    Dim fileByte As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream()

                    Using mm
                        mm.Write(fileByte, 0, fileByte.Length)
                        Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)

                        Using doc
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule)
                            AddCompanyDetails(doc, True, False, isCommerical)
                            PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dr("PayerName")))
                            PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dr("Payeraddress1")))
                            PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dr("PayerAddress2")))
                            PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dr("PayerAddress3")))
                            PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dr("PayerPostcode")))
                            PrintHelper.ReplaceText(doc, "[InvoiceNumber]", Helper.MakeStringValid(dr("InvoiceNumber")))
                            PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(dr("RaiseDate")).ToString("dd/MM/yyyy"))
                            PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dr("CustAcc")))
                            Dim dtContract As DataTable = New DataTable()
                            dtContract.Columns.Add("ContractReference")
                            dtContract.Columns.Add("Address")
                            dtContract.Columns.Add("Work")
                            dtContract.Columns.Add("Total")
                            Dim drContract As DataRow = dtContract.NewRow()
                            drContract("ContractReference") = If((Helper.MakeStringValid(dr("PoNumber")).Length = 0), Helper.MakeStringValid(dr("ContractReference")), Helper.MakeStringValid(dr("ContractReference") & " / " & dr("PoNumber")))
                            drContract("Address") = Helper.MakeStringValid(dr("SiteAddress1") & ", " & dr("SiteAddress2") & ", " & dr("SitePostcode"))
                            Dim contractType As String = Helper.MakeStringValid(dr("ContractType"))
                            Dim contractTypeId As Integer = Helper.MakeIntegerValid(dr("ContractTypeID"))
                            Dim siteRegion As Integer = Helper.MakeIntegerValid(dr("SiteRegion"))
                            Dim contractTotal As Double = Helper.MakeDoubleValid(dr("ContractPrice"))
                            Dim subTotal As Double = 0.0

                            If siteRegion = CInt(Enums.Region.GaswayCommercial) Then
                                drContract("Work") = "Periodic Service Charge"
                            ElseIf (contractTypeId = CInt(Enums.ContractTypes.GoldStarAgency)) OrElse (contractTypeId = CInt(Enums.ContractTypes.PlatinumStarAgency)) Then
                                drContract("Work") = contractType & " Coverplan Renewal. " & vbCrLf & vbCrLf &
                                    "Blanket cover for all gas appliances" & vbCrLf & vbCrLf &
                                    "Please find enclosed your certificate of cover." & vbCrLf & vbCrLf &
                                    "Thank you for Renewing this plan."
                                drContract("Total") = contractTotal.ToString("C")
                                subTotal += contractTotal
                            Else
                                drContract("Work") = contractType & " Coverplan Renewal. " & vbCrLf & vbCrLf &
                                    "Please find enclosed your certificate of cover." & vbCrLf & vbCrLf & "Thank you for Renewing this plan."
                                drContract("Total") = contractTotal.ToString("C")
                                subTotal += contractTotal
                            End If

                            dtContract.Rows.Add(drContract)
                            PrintHelper.AddRowsToTable(doc, "Job No", dtContract, "20")
                            PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"))
                            PrintHelper.ReplaceText(doc, "[VAT]", Math.Round(subTotal * 0.2, 2).ToString("C"))
                            PrintHelper.ReplaceText(doc, "[TiVAT]", Math.Round(subTotal * 1.2, 2).ToString("C"))
                            If addPage Then
                                Dim pageCount As Integer = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText)
                                Dim addBreaks As Integer = 1
                                addBreaks += If((pageCount Mod 2 = 0), 0, 1)

                                For i As Integer = 0 To addBreaks - 1
                                    doc.MainDocumentPart.Document.Body.InsertAfter(New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})), doc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                                Next
                            End If

                            doc.MainDocumentPart.Document.Save()
                            Dim saveDir As String = TheSystem.Configuration.DocumentsLocation & "SiteContracts\" & Helper.MakeStringValid(dr("ContractReference"))
                            Directory.CreateDirectory(saveDir)
                            Dim fileName As String = "Invoice_" & DateTime.Now.ToString("dd_MM_yyyy_HH_mm") & ".docx"
                            Dim savePath As String = saveDir & "\" & fileName
                            savePath = FileCheck(savePath)
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0

                            Using fileStream
                                mm.WriteTo(fileStream)
                            End Using

                            fileStream.Close()
                        End Using

                        Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                        Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr("ContractID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                        Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                        mm.Position = 0

                        Using mm
                            chunk.FeedData(mm)
                        End Using

                        Dim altChunk As WP.AltChunk = New WP.AltChunk()
                        altChunk.Id = altChunkId
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                        mainPart.Document.Save()
                    End Using

                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate invoice : " & vbNewLine & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateTransferLetter(ByVal dr As DataRow, ByVal batch As WordprocessingDocument) As Boolean
                Try
                    Dim template As String = Application.StartupPath & "\Templates\Contracts\ContractTransfer.docx"
                    Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")))
                    Dim fileByte As Byte() = File.ReadAllBytes(template)
                    Dim mm As MemoryStream = New MemoryStream()

                    Using mm
                        mm.Write(fileByte, 0, fileByte.Length)
                        Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)

                        Using doc
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule)
                            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"))
                            Dim companyName As String = If((Helper.MakeStringValid(dr("PayerSalutation")).Length > 0), Helper.MakeStringValid(dr("PayerSalutation") & " " & dr("PayerSurname")), Helper.MakeStringValid(dr("PayerName")))
                            PrintHelper.ReplaceText(doc, "[CompanyName]", companyName)
                            PrintHelper.ReplaceText(doc, "[Name]", companyName)
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("PayerAddress1")))
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("PayerAddress2")))
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("PayerAddress3")))
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("PayerPostcode")))
                            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(dr("ContractType")))
                            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(dr("ContractReference") & " - " & dr("siteAddress1") & ", " & dr("siteAddress2") & ", " & dr("sitePostcode")))
                            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(dr("siteAddress1") & ", " & dr("siteAddress2") & ", " & dr("sitePostcode")))
                            PrintHelper.ReplaceText(doc, "[UserName]", TheSystem.Configuration.CompanyName & " Coverplan Team")
                            Dim pageCount As Integer = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText)
                            Dim addBreaks As Integer = 1
                            addBreaks += If((pageCount Mod 2 = 0), 0, 1)

                            For i As Integer = 0 To addBreaks - 1
                                doc.MainDocumentPart.Document.Body.InsertAfter(
                                    New WP.Paragraph(New WP.Run(New WP.Break() With {.Type = WP.BreakValues.Page})),
                                    doc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                            Next

                            doc.MainDocumentPart.Document.Save()
                            Dim saveDir As String = TheSystem.Configuration.DocumentsLocation & "SiteContracts\" & Helper.MakeStringValid(dr("ContractReference"))
                            Directory.CreateDirectory(saveDir)
                            Dim fileName As String = "Transfer_" & DateTime.Now.ToString("dd_MM_yyyy_HH_mm") & ".docx"
                            Dim savePath As String = saveDir & "\" & fileName
                            savePath = FileCheck(savePath)
                            Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            mm.Position = 0

                            Using fileStream
                                mm.WriteTo(fileStream)
                            End Using

                            fileStream.Close()
                        End Using

                        Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                        Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr("ContractID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                        Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                        mm.Position = 0

                        Using mm
                            chunk.FeedData(mm)
                        End Using

                        Dim altChunk As WP.AltChunk = New WP.AltChunk()
                        altChunk.Id = altChunkId
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                        mainPart.Document.Save()
                    End Using
                    Return True
                Catch ex As Exception
                    ShowMessage("Could not generate transfer letter : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Function

            Private Function GenerateAnnualExpiryLetters(ByVal drAnnualContracts As DataRow()) As String
                Dim fileName As String = "Annual_Contract_Expiry_" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".docx"
                Dim fileDir As String = TheSystem.Configuration.DocumentsLocation & "Contracts\AnnualExpiry"
                Directory.CreateDirectory(fileDir)
                Dim filePath As String = fileDir & "\" & fileName
                File.Copy(Application.StartupPath & "\Templates\ServiceLetter.docx", filePath)

                Try
                    Dim batch As WordprocessingDocument = WordprocessingDocument.Open(filePath, True)
                    Using batch
                        For Each dr As DataRow In drAnnualContracts

                            Try
                                If Helper.MakeDoubleValid(dr("RenewalPrice")) = 0 Then Continue For
                                Dim template As String = Application.StartupPath & "\Templates\Contracts\AnnualContractExpiry.docx"
                                Dim goldenRule As String = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")))
                                Dim fileByte As Byte() = File.ReadAllBytes(template)
                                Dim mm As MemoryStream = New MemoryStream()

                                Using mm
                                    mm.Write(fileByte, 0, fileByte.Length)
                                    Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)

                                    Using doc
                                        PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule)
                                        PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("PayerAddress1")))
                                        PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("PayerAddress2")))
                                        PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("PayerAddress3")))
                                        PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("PayerPostcode")))
                                        PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"))
                                        Dim companyName As String = If((Helper.MakeStringValid(dr("PayerSalutation")).Length > 0), Helper.MakeStringValid(dr("PayerSalutation") & " " & dr("PayerSurname")), Helper.MakeStringValid(dr("PayerName")))
                                        PrintHelper.ReplaceText(doc, "[CompanyName]", companyName)
                                        PrintHelper.ReplaceText(doc, "[ExpiryDate]", Helper.MakeDateTimeValid(dr("ContractEndDate")).ToString("dd/MM/yyyy"))
                                        PrintHelper.ReplaceText(doc, "[User]", TheSystem.Configuration.CompanyName & " Coverplan Team")
                                        PrintHelper.ReplaceText(doc, "[ContractType]", Helper.MakeStringValid(dr("ContractType")))
                                        PrintHelper.ReplaceText(doc, "[ContractReference]", Helper.MakeStringValid(dr("ContractReference")))
                                        PrintHelper.ReplaceText(doc, "[SiteAddress1]", Helper.MakeStringValid(dr("SiteAddress1")))
                                        Dim price As String = If((Helper.MakeDoubleValid(dr("RenewalPrice")) = -1), 0.ToString("C"), Helper.MakeDoubleValid(dr("RenewalPrice")).ToString("C"))
                                        PrintHelper.ReplaceText(doc, "[PriceSentence]", price)

                                        Dim addAppPrice As Double = Helper.MakeDoubleValid(DB.Picklists.Get_Single_Description("Additional Appliance", 52))
                                        If dr("ContractType") = "Platinum Star" Then addAppPrice = Helper.MakeDoubleValid(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52))

                                        If addAppPrice > 0 Then
                                            Dim sentence As String = "Please be advised that we are now offering cover for boilermates " & "or any other make of thermal store product as an additional appliance. " &
                                                "Should you have a thermal store product in your property and require cover, " & "this could be added for an additional " &
                                                addAppPrice.ToString("C") & " per annum."
                                            PrintHelper.ReplaceText(doc, "[ExcludeSentence]", sentence)
                                        Else
                                            PrintHelper.DeleteBookmark(doc, "ExcludeSentence")
                                        End If

                                        Dim ahe As Double = Helper.MakeDoubleValid(DB.Picklists.Get_Single_Description("AHE", 52))
                                        PrintHelper.ReplaceText(doc, "[AHE]", ahe.ToString("C"))
                                        Dim pageCount As Integer = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText)
                                        Dim addBreaks As Integer = 1
                                        addBreaks += If((pageCount Mod 2 = 0), 0, 1)

                                        For i As Integer = 0 To addBreaks - 1
                                            doc.MainDocumentPart.Document.Body.InsertAfter(
                                                New WP.Paragraph(New WP.Run(New WP.Break() With {
                                                .Type = WP.BreakValues.Page})),
                                                doc.MainDocumentPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                                        Next

                                        doc.MainDocumentPart.Document.Save()
                                        Dim saveDir As String = TheSystem.Configuration.DocumentsLocation & "SiteContracts\" & Helper.MakeStringValid(dr("ContractReference"))
                                        Directory.CreateDirectory(saveDir)
                                        Dim savePath As String = saveDir & "\" & fileName
                                        savePath = FileCheck(savePath)
                                        Dim fileStream As FileStream = New FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                                        mm.Position = 0

                                        Using fileStream
                                            mm.WriteTo(fileStream)
                                        End Using

                                        fileStream.Close()
                                    End Using

                                    Dim mainPart As MainDocumentPart = batch.MainDocumentPart
                                    Dim altChunkId As String = "AltId" & Helper.MakeIntegerValid(dr("ContractID")) & DateTime.Now.ToString("ddMMyyyyHHmmssfff")
                                    Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)
                                    mm.Position = 0

                                    Using mm
                                        chunk.FeedData(mm)
                                    End Using

                                    Dim altChunk As WP.AltChunk = New WP.AltChunk()
                                    altChunk.Id = altChunkId
                                    mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of WP.Paragraph)().Last())
                                    mainPart.Document.Save()
                                End Using
                            Catch ex As Exception
                                ShowMessage("Could not renewal letter for " & Helper.MakeStringValid(dr("ContractReference")) & ": " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        Next
                    End Using

                    Return filePath
                Catch ex As Exception
                    ShowMessage("Could not renewal letter: " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return String.Empty
                End Try
            End Function

#End Region

#Region " Utilities "

            Private Function Finalise(ByVal filepath As String, ByVal success As Boolean, Optional ByVal withSave As Boolean = True, Optional ByVal withKill As Boolean = True, Optional ByVal gsr As Boolean = False) As String
                On Error Resume Next

                Dim documentLine As Documentss.Documents

                If success Then
                    If Not WordDoc Is Nothing Then
                        If withSave Then
                            If filepath.Trim.Length > 0 Then
                                If OrderID > 0 Then
                                    If answer = DialogResult.No Then

                                        WordDoc.SaveAs(CObj(filepath))
                                        Dim linkedDoc As New Documentss.Documents

                                        linkedDoc.SetTableEnumID = CInt(Enums.TableNames.tblOrder)
                                        linkedDoc.SetRecordID = OrderID
                                        linkedDoc.SetDocumentTypeID = 162

                                        Dim fileName As String() = filepath.Split("\")
                                        linkedDoc.SetName = fileName(filepath.Split("\").Length - 1)

                                        linkedDoc.SetNotes = ""
                                        linkedDoc.SetLocation = filepath

                                        Dim cV As New Documentss.DocumentsValidator
                                        cV.Validate(linkedDoc)

                                        linkedDoc = DB.Documents.Insert(linkedDoc)

                                        System.IO.File.Delete(filepath)
                                    Else
                                        'hhhh
                                        filepath = filepath.ToLower.Replace(".doc", ".pdf")

                                        If System.IO.File.Exists(filepath) Then
                                            System.IO.File.Delete(filepath)
                                        End If

                                        WordDoc.SaveAs(CObj(filepath), Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF)
                                        Process.Start(filepath)

                                        While Not System.IO.File.Exists(filepath)
                                            System.Threading.Thread.Sleep(1000)
                                        End While

                                        Dim linkedDoc As New Documentss.Documents

                                        linkedDoc.SetTableEnumID = CInt(Enums.TableNames.tblOrder)
                                        linkedDoc.SetRecordID = OrderID
                                        linkedDoc.SetDocumentTypeID = 162

                                        Dim fileName As String() = filepath.Split("\")
                                        linkedDoc.SetName = fileName(filepath.Split("\").Length - 1)

                                        linkedDoc.SetNotes = ""
                                        linkedDoc.SetLocation = filepath

                                        Dim cV As New Documentss.DocumentsValidator
                                        cV.Validate(linkedDoc)

                                        linkedDoc = DB.Documents.Insert(linkedDoc)

                                    End If
                                ElseIf PrintType = Enums.SystemDocumentType.SiteLetter Then
                                    Dim linkedDoc As New Documentss.Documents

                                    linkedDoc.SetTableEnumID = CInt(Enums.TableNames.tblSite)
                                    linkedDoc.SetRecordID = SiteID
                                    linkedDoc.SetDocumentTypeID = 205

                                    Dim fileName As String() = filepath.Split("\")
                                    linkedDoc.SetName = fileName(filepath.Split("\").Length - 1)
                                    If System.IO.Directory.Exists(filepath.Replace(linkedDoc.Name, "")) = False Then
                                        System.IO.Directory.CreateDirectory(filepath.Replace(linkedDoc.Name, ""))
                                    End If

                                    WordDoc.SaveAs(CObj(filepath))

                                    linkedDoc.SetNotes = ""
                                    linkedDoc.SetLocation = filepath

                                    Dim cV As New Documentss.DocumentsValidator
                                    cV.Validate(linkedDoc)

                                    linkedDoc = DB.Documents.Insert(linkedDoc)

                                    ' System.IO.File.Delete(filepath)
                                Else
                                    filepath = FileCheck(filepath)
                                    Dim fileExt As String = Path.GetExtension(filepath)
                                    If fileExt = ".pdf" Then
                                        WordDoc.SaveAs(CObj(filepath), Microsoft.Office.Interop.Word.
                                                       WdSaveFormat.wdFormatPDF)
                                    Else
                                        WordDoc.SaveAs(CObj(filepath))
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                DestroyWord(withKill)

                Return filepath
            End Function

            Private Function FileCheck(ByVal filePath As String) As String
                'check if file exists first
                Try
                    If File.Exists(filePath) Then
                        File.Delete(filePath)
                    End If
                Catch ex As Exception
                    'can't delete because another process is using
                    Dim ext As String = Path.GetExtension(filePath)
                    filePath = filePath.Replace(ext, "_New" & ext)
                End Try

                Return filePath
            End Function

            Public Sub DestroyWord(ByVal withKill As Boolean)
                If Not WordDoc Is Nothing Then
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc.Content)
                    WordDoc.Close(SaveChanges:=False)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc)
                    WordDoc = Nothing
                End If

                If withKill Then
                    If Not MsWordApp Is Nothing Then
                        For Each doc As Word.Document In _wordApp.Documents
                            doc.Close(SaveChanges:=False)
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc)
                            doc = Nothing
                        Next

                        MsWordApp.Quit(SaveChanges:=False)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(MsWordApp)
                        MsWordApp = Nothing
                    End If

                    Dim mp As Process() = Process.GetProcessesByName("WINWORD")
                    Dim p As Process
                    For Each p In mp
                        If p.Responding Then
                            If p.MainWindowTitle = "" Then
                                p.Kill()
                            End If
                        Else
                            p.Kill()
                        End If
                    Next p
                    On Error GoTo - 1
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Sub

            Public Shared Function GetTemplateFields(ByVal documentText As String) As System.Text.RegularExpressions.MatchCollection
                Dim regex As New System.Text.RegularExpressions.Regex("\[[A-z|0-9]*\]")
                Return regex.Matches(documentText)
            End Function

            Public Shared Sub ReplaceText(ByRef msWordDoc As Word.Document, ByVal OldText As String, ByVal NewText As String)
                With msWordDoc.Content.Find
                    .Text = OldText
                    If NewText.Length > 255 Then
                        .Replacement.Text = NewText.Substring(0, 255)
                    Else
                        .Replacement.Text = NewText
                    End If
                    .Execute(Replace:=Word.WdReplace.wdReplaceAll)
                End With
            End Sub

            Public Function GSRSave(ByVal filepath As String, ByVal oEngineerVisit As EngineerVisits.EngineerVisit,
                                         ByVal oSite As Sites.Site, ByVal fileName As String) As Boolean
                Try
                    Dim oCustomer As Customers.Customer = DB.Customer.Customer_Get_Light(oSite.CustomerID)
                    If oCustomer Is Nothing Then Return False
                    Dim oDocument As Documentss.Documents = DB.Documents.Documents_Get_ByFilePath(filepath)
                    If oDocument Is Nothing Then
                        oDocument = New Documentss.Documents
                        oDocument.SetTableEnumID = CInt(Enums.TableNames.tblEngineerVisit)
                        oDocument.SetRecordID = oEngineerVisit.EngineerVisitID
                        oDocument.SetDocumentTypeID = Consts.GSR
                        oDocument.SetName = fileName
                        oDocument.SetNotes = "Printed on " & Now.ToShortDateString & " at " & Now.ToString("HH:mm") &
                        " by " & loggedInUser.Fullname
                        oDocument.SetLocation = filepath
                        DB.Documents.Insert(oDocument, False)
                    Else
                        oDocument.SetNotes = "Last printed on " & Now.ToShortDateString & " at " & Now.ToString("HH:mm") &
                            " by " & loggedInUser.Fullname
                        DB.Documents.Update(oDocument)
                    End If
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Private Sub ElecCertPDF(ByVal oEngineerVisit As EngineerVisits.EngineerVisit, ByVal ElectricalResuts As EngineerVisitAdditionals.EngineerVisitAdditional, ByVal filename As String)

                Dim filePath As String = TheSystem.Configuration.DocumentsLocation & CInt(Enums.TableNames.tblEngineerVisit)
                If Not System.IO.Directory.Exists(filePath) Then
                    System.IO.Directory.CreateDirectory(filePath)
                End If
                filePath += "\" & oEngineerVisit.EngineerVisitID
                If Not System.IO.Directory.Exists(filePath) Then
                    System.IO.Directory.CreateDirectory(filePath)
                End If
                filePath += "\" & filename & DateTime.Now.ToString("ddMMyyHHmmss") & ".pdf"

                'If Not r("CustomerID") = Enums.Customer.NCC Then GSRSave(filePath, oEngineerVisit)

                Dim pdfTemp As String = Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\" & filename & ".pdf" ' ---> It's the original pdf form you want to fill
                Dim newFile As String = filePath ' ---> It will generate new pdf that you have filled from your program

                ' ------ READING -------

                Dim pdfReader As New PdfReader(pdfTemp)
                ' ------ WRITING -------
                Dim ms As MemoryStream = New MemoryStream()
                Dim pdfStamper As PdfStamper = New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "4") 'Creating the PDF in version 1.4

                'Method 1
                pdfStamper.FormFlattening = If(loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.PDFEditor), False, True)
                ' If you don�t specify version and append flag (last 2 params) in below line then you may receive �Extended Features� error when you open generated PDF
                ' Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)

                'pdfStamper.FormfFlattening = True
                'pdfStamper.AcroFields.GenerateAppearances = True

                Dim pdfFormFields As AcroFields = pdfStamper.AcroFields

                '--------Get some Data-----------
                Dim osite As Sites.Site = DB.Sites.Get(ElectricalResuts.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId)
                Dim ositeHQ As New Sites.Site

                If Not osite.CustomerID = Enums.Customer.Domestic Then ositeHQ = DB.Sites.Get(osite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)

                ' ------ SET YOUR FORM FIELDS ------

                PdfSetFormFieldText(pdfFormFields, "Client", ositeHQ.Name, 7.7F)
                PdfSetFormFieldText(pdfFormFields, "ClientAddress", ositeHQ.Address1 & Chr(10) & ositeHQ.Address2 & Chr(10) & ositeHQ.Address3, 7.7F)
                PdfSetFormFieldText(pdfFormFields, "ClientPostcode", Sys.Helper.FormatPostcode(ositeHQ.Postcode), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Installer", osite.Name, 7.7F)
                PdfSetFormFieldText(pdfFormFields, "InstallerAddress", osite.Address1 & Chr(10) & osite.Address2 & Chr(10) & osite.Address3, 7.7F)
                PdfSetFormFieldText(pdfFormFields, "InstallerPostcode", Sys.Helper.FormatPostcode(osite.Postcode), 7.7F)

                Dim ref As String = "20656" & oEngineerVisit.EngineerVisitID
                Dim length As Integer = ref.Length
                Dim character As Integer = 0
                For character = length To 0 Step -1
                    ref = ref.Insert(character, "  ")
                Next

                'Dim unicode As BaseFont = BaseFont.CreateFont(BaseFont.ZAPFDINGBATS, BaseFont.ZAPFDINGBATS, BaseFont.NOT_EMBEDDED)
                'pdfFormFields.SetFieldProperty("ID", "textfont", unicode, Nothing)
                'pdfFormFields.SetField("ID", "4") 'tick

                'Dim fields() As String = pdfStamper.AcroFields.Fields.[Select](Function(x) x.Key).ToArray()
                'For key As Integer = 0 To fields.Count - 1
                '    pdfStamper.AcroFields.SetFieldProperty(fields(key), "setfflags", PdfFormField.FF_READ_ONLY, Nothing)
                'Next
                PdfSetFormFieldText(pdfFormFields, "CertNo", ref, 14.25F)

                PdfSetFormFieldText(pdfFormFields, "Description1", ElectricalResuts.Test11, 8.0F)

                Select Case ElectricalResuts.Test1
                    Case 69996
                        PDFSetTick(pdfFormFields, "New", ref, 12.0F)
                    Case 69997
                        PDFSetTick(pdfFormFields, "Addition", ref, 12.0F)
                    Case 69998
                        PDFSetTick(pdfFormFields, "Alteration", ref, 12.0F)
                End Select

                Select Case ElectricalResuts.Test2
                    Case 386
                        PDFSetTick(pdfFormFields, "RecordsYes", ref, 12.0F)
                    Case 387
                        PDFSetTick(pdfFormFields, "RecordsNo", ref, 12.0F)
                End Select

                PdfSetFormFieldText(pdfFormFields, "BS7671", "2008", 8.0F)

                PdfSetFormFieldText(pdfFormFields, "Date1", "2015", 8.0F)

                Select Case ElectricalResuts.Test3
                    Case 69999
                        PDFSetTick(pdfFormFields, "TNS", ref, 8.0F)
                    Case 70001
                        PDFSetTick(pdfFormFields, "TNCS", ref, 12.0F)
                    Case 70000
                        PDFSetTick(pdfFormFields, "TT", ref, 12.0F)
                    Case 70002
                        PDFSetTick(pdfFormFields, "Other1", ref, 12.0F)
                End Select

                PdfSetFormFieldText(pdfFormFields, "Specify1", ElectricalResuts.Test12, 12.0F)

                PDFSetTick(pdfFormFields, "Ac", ref, 12.0F)
                '  PdfSetFormFieldText(pdfFormFields, "Dc", ref, 12.0F)

                PdfSetFormFieldText(pdfFormFields, "Phases", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test4).Name, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "Wires", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test5).Name, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "Voltage1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test6).Name, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "Frequency", "50", 8.0F)
                If ElectricalResuts.Test7 = 421 Then
                    PDFSetTick(pdfFormFields, "Polarity1", ref, 8.0F)
                End If
                PdfSetFormFieldText(pdfFormFields, "FaultCurrent", ElectricalResuts.Test13, 8.0F)

                PdfSetFormFieldText(pdfFormFields, "Device", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test8).Name, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "Type1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test9).Name, 8.0F)

                PdfSetFormFieldText(pdfFormFields, "Impedance", ElectricalResuts.Test14, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "RatedCurrent", ElectricalResuts.Test15, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "SupplySource", ElectricalResuts.Test216, 8.0F)

                If ElectricalResuts.Test10 = 70017 Then
                    PDFSetTick(pdfFormFields, "Facility", ref, 12.0F)
                Else
                    PDFSetTick(pdfFormFields, "EarthElectrode", ref, 12.0F)
                End If

                PdfSetFormFieldText(pdfFormFields, "Location1", ElectricalResuts.Test217, 8.0F)

                PdfSetFormFieldText(pdfFormFields, "Type2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test111).Name, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "Ma", ElectricalResuts.Test223, 8.0F) ' text13

                PdfSetFormFieldText(pdfFormFields, "Resistance", ElectricalResuts.Test218, 8.0F)

                PdfSetFormFieldText(pdfFormFields, "EarthConductor1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test112).Name, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "EarthConductor2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test113).Name, 8.0F)
                PDFSetTick(pdfFormFields, "EarthingConductor3", ref, 8.0F)

                PdfSetFormFieldText(pdfFormFields, "BondingConductor1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test114).Name, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "BondingConductor2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test115).Name, 8.0F)
                PDFSetTick(pdfFormFields, "BondingConductor3", ref, 8.0F)

                PdfSetFormFieldText(pdfFormFields, "SupplyConductor1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test116).Name, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "SupplyConductor2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test117).Name, 8.0F)
                PDFSetTick(pdfFormFields, "SupplyConductor3", ref, 8.0F)

                If ElectricalResuts.Test118 = Enums.TabletYesNoNA.Yes Then
                    PDFSetTick(pdfFormFields, "WaterPipe", ref, 8.0F)
                End If
                If ElectricalResuts.Test119 = Enums.TabletYesNoNA.Yes Then
                    PDFSetTick(pdfFormFields, "GasPipe", ref, 8.0F)
                End If
                If ElectricalResuts.Test120 = Enums.TabletYesNoNA.Yes Then
                    PDFSetTick(pdfFormFields, "OilPipe", ref, 8.0F)
                End If
                'If ElectricalResuts.Test118 = Enums.TabletYesNoNA.Yes Then ' not used
                '    PdfSetFormFieldText(pdfFormFields, "Other2", ref, 8.0F)
                'End If
                If ElectricalResuts.Test122 = Enums.TabletYesNoNA.Yes Then
                    PDFSetTick(pdfFormFields, "Lighting", ref, 8.0F)
                End If
                If ElectricalResuts.Test121 = Enums.TabletYesNoNA.Yes Then
                    PDFSetTick(pdfFormFields, "Steel", ref, 8.0F)
                End If

                '   PdfSetFormFieldText(pdfFormFields, "Specify2", ref, 8.0F) not used
                PdfSetFormFieldText(pdfFormFields, "Delay", ElectricalResuts.Test224, 8.0F)
                PdfSetFormFieldText(pdfFormFields, "Time", ElectricalResuts.Test225, 8.0F)

                Dim EquipmentDT As DataTable = DB.Engineer.Equipment_GetForEngineer(oEngineerVisit.EngineerID).Table
                Dim List As String = ""
                For Each EquipmentDR As DataRow In EquipmentDT.Select("EquipmentTypeID = 70962") ' Electrical Test Instrument
                    List += EquipmentDR("SerialNumber") & Chr(10)
                Next

                PdfSetFormFieldText(pdfFormFields, "SerialNumber", List, 8.0F)

                PdfSetFormFieldText(pdfFormFields, "FuseDevice", ElectricalResuts.Test220, 8.0F)  ' text10
                PdfSetFormFieldText(pdfFormFields, "BSEN", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test123).Name, 8.0F) 'cbo23
                PdfSetFormFieldText(pdfFormFields, "Voltage2", ElectricalResuts.Test221, 8.0F)   'text11
                PdfSetFormFieldText(pdfFormFields, "Poles", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test124).Name, 8.0F) 'cbo24
                PdfSetFormFieldText(pdfFormFields, "Location2", ElectricalResuts.Test222, 8.0F) ' text12
                PdfSetFormFieldText(pdfFormFields, "Rating1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test125).Name, 8.0F) 'cbo25
                PdfSetFormFieldText(pdfFormFields, "CircuitNo", ElectricalResuts.Test226, 8.0F) ' text16
                PdfSetFormFieldText(pdfFormFields, "Designation", ElectricalResuts.Test227, 8.0F) 'text17
                PdfSetFormFieldText(pdfFormFields, "Wiring", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test126).Name, 8.0F) ' cbo26
                PdfSetFormFieldText(pdfFormFields, "Method", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test127).Name, 8.0F) 'cbo27
                PdfSetFormFieldText(pdfFormFields, "PointsServed", ElectricalResuts.Test228, 8.0F) ' text18
                PdfSetFormFieldText(pdfFormFields, "Live", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test128).Name, 8.0F) ' cbo28
                PdfSetFormFieldText(pdfFormFields, "CPC", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test129).Name, 8.0F) ' cbo29
                PdfSetFormFieldText(pdfFormFields, "Disconnection", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name, 8.0F) ' cbo30
                PdfSetFormFieldText(pdfFormFields, "BSENNo", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test131).Name, 8.0F) ' cbo31
                PdfSetFormFieldText(pdfFormFields, "TypeNo", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test132).Name, 8.0F) ' cbo32
                PdfSetFormFieldText(pdfFormFields, "Rating2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test133).Name, 8.0F) ' cbo33
                PdfSetFormFieldText(pdfFormFields, "Capacity", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test134).Name, 8.0F) ' cbo34
                PdfSetFormFieldText(pdfFormFields, "RCD", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test135).Name, 8.0F) ' cbo35

                Dim elecDt As DataTable = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_ElectricalZsMatrix_Get ' Get the matrix

                Dim BSNo As String = DB.Picklists.Get_One_As_Object(ElectricalResuts.Test131).Name
                Select Case BSNo  ' some are duplicated in matrix so covert to primary Number for this section of code
                    Case "1362"
                        BSNo = "1361"
                    Case "60898", "61008"
                        BSNo = "3871"
                    Case "61008"
                        BSNo = "61009"
                End Select

                Dim Type As String = DB.Picklists.Get_One_As_Object(ElectricalResuts.Test132).Name

                Select Case Type ' same with type
                    Case "B"
                        Type = "3"
                    Case "3", "C"
                        Type = "4"
                    Case "D"
                        Type = "5"
                End Select

                Dim rated As String = DB.Picklists.Get_One_As_Object(ElectricalResuts.Test133).Name
                If rated = "2" Then rated = "3" ' fix for error on tablet
                Dim dr As DataRow
                Try
                    dr = elecDt.Select("Rated = " & rated)(0)
                Catch ex As Exception
                    dr = elecDt.Select("Rated = 3")(0)
                End Try

                Dim result As String = "N/A"
                If DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name = "0.4" Or DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name = "5" Then
                    If BSNo = "3871" Then
                        result = dr("BS" & BSNo & "_" & Type)
                    Else
                        result = dr("BS" & BSNo & "_" & (DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name).ToString.Replace(".", ""))
                    End If
                End If

                PdfSetFormFieldText(pdfFormFields, "BS7671Value", result, 8.0F)

                PdfSetFormFieldText(pdfFormFields, "R1", ElectricalResuts.Test229, 8.0F) 'text19
                PdfSetFormFieldText(pdfFormFields, "Rn", ElectricalResuts.Test230, 8.0F)  'text20
                PdfSetFormFieldText(pdfFormFields, "R2", ElectricalResuts.Test231, 8.0F)  'text21
                PdfSetFormFieldText(pdfFormFields, "Figure8", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test136).Name, 8.0F) ' cbo36

                PdfSetFormFieldText(pdfFormFields, "R1R2", ElectricalResuts.Test232, 8.0F) 'text22
                PdfSetFormFieldText(pdfFormFields, "R22", "N/A", 8.0F) ' n/a
                PdfSetFormFieldText(pdfFormFields, "LiveLive", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test137).Name, 8.0F) ' cbo37
                PdfSetFormFieldText(pdfFormFields, "LiveEarth", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test138).Name, 8.0F) ' cbo38
                PdfSetFormFieldText(pdfFormFields, "Polarity2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test139).Name, 8.0F) ' cbo39
                PdfSetFormFieldText(pdfFormFields, "Zs", ElectricalResuts.Test233, 8.0F) 'text23
                PdfSetFormFieldText(pdfFormFields, "RCDTest1", ElectricalResuts.Test234, 8.0F) 'text24
                PdfSetFormFieldText(pdfFormFields, "RCDTest2", ElectricalResuts.Test235, 8.0F) 'text25
                PdfSetFormFieldText(pdfFormFields, "TestButtonOp", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test140).Name, 8.0F) 'cbo40
                PdfSetFormFieldText(pdfFormFields, "CircuitDetails", "Electronic Equipment or Accessories", 8.0F) ' always
                PdfSetFormFieldText(pdfFormFields, "RiskAssessment", "N/A", 5.0F) 'HC small
                PdfSetFormFieldText(pdfFormFields, "JobTitle", "Electrician", 8.0F) ' HC

                Dim Engineer As Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)
                PdfSetFormFieldText(pdfFormFields, "Engineer", Engineer.Name, 8.0F) ' Get engineer

                Dim visitDate As DateTime = oEngineerVisit.StartDateTime
                If visitDate = Nothing Then
                    visitDate = oEngineerVisit.ManualEntryOn
                End If

                PdfSetFormFieldText(pdfFormFields, "Date2", visitDate.ToShortDateString, 8.0F)

                Dim fp As AcroFields.FieldPosition = pdfFormFields.GetFieldPositions("Signature")(0)

                Dim page As Integer = fp.page
                Dim rect As text.Rectangle = fp.position

                Dim engSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.EngineerSignature))
                engSig.Save(Application.StartupPath & "\TEMP\EngSig.bmp")

                Dim image As text.Image = text.Image.GetInstance(Application.StartupPath & "\TEMP\EngSig.bmp")

                image.ScaleToFit(rect.Width, rect.Height)
                image.SetAbsolutePosition(rect.Left, rect.Bottom)

                Dim over As PdfContentByte = pdfStamper.GetOverContent(page)
                over.AddImage(image)

                ' close the pdf
                pdfStamper.Close()
                ' pdfReader.close() ---> DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP
                pdfStamper.Close()

                pdfReader.Close() 'DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP - well i did!!
                Cursor.Current = Cursors.WaitCursor
                Process.Start(filePath)
                Cursor.Current = Cursors.Default
            End Sub

            Private Sub PDFSetTick(ByRef acroFields As AcroFields, ByVal fieldName As String, ByVal replacementText As String, ByVal textSize As Single)
                Dim pdfFormFields As AcroFields = acroFields
                Dim font As text.Font = text.FontFactory.GetFont(Application.StartupPath & "/fonts/zapfdingbats.ttf",
                                        BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 0.5F, text.Font.NORMAL, text.BaseColor.BLACK)
                Dim bf As BaseFont = font.BaseFont
                pdfFormFields.SetFieldProperty(fieldName, "textfont", bf, Nothing)
                pdfFormFields.SetField(fieldName, "4") 'tick '4
                pdfFormFields.SetFieldProperty(fieldName, "textsize", 5.0F, Nothing)

            End Sub

            Private Sub PdfSetFormFieldText(ByRef acroFields As AcroFields, ByVal fieldName As String, ByVal replacementText As String, ByVal textSize As Single)

                'Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

                'Dim font As iTextSharp.text.Font = New iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL)  ' need to sus out regarding

                Dim pdfFormFields As AcroFields = acroFields

                pdfFormFields.SetFieldProperty(fieldName, "bgcolor", iTextSharp.text.BaseColor.WHITE, Nothing)

                pdfFormFields.SetFieldProperty(fieldName, "textsize", textSize, Nothing)

                pdfFormFields.SetField(fieldName, replacementText)

            End Sub

            Private Sub WarningNoticePDF(ByVal oEngineerVisit As Entity.EngineerVisits.EngineerVisit, ByVal WarningNotice As DataRow, ByVal filename As String)

                Dim filePath As String = TheSystem.Configuration.DocumentsLocation & CInt(Entity.Sys.Enums.TableNames.tblEngineerVisit)
                If Not System.IO.Directory.Exists(filePath) Then
                    System.IO.Directory.CreateDirectory(filePath)
                End If
                filePath += "\" & oEngineerVisit.EngineerVisitID
                If Not System.IO.Directory.Exists(filePath) Then
                    System.IO.Directory.CreateDirectory(filePath)
                End If
                filePath += "\" & filename & DateTime.Now.ToString("ddMMyyHHmmss") & ".pdf"

                'If Not r("CustomerID") = Entity.Sys.Enums.Customer.NCC Then GSRSave(filePath, oEngineerVisit)

                Dim pdfTemp As String = Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\" & filename & ".pdf" ' ---> It's the original pdf form you want to fill
                Dim newFile As String = filePath ' ---> It will generate new pdf that you have filled from your program

                ' ------ READING -------

                Dim pdfReader As New PdfReader(pdfTemp)
                ' ------ WRITING -------
                Dim ms As MemoryStream = New MemoryStream()
                Dim pdfStamper As PdfStamper = New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "4") 'Creating the PDF in version 1.4

                'Method 1
                pdfStamper.FormFlattening = True
                ' If you don�t specify version and append flag (last 2 params) in below line then you may receive �Extended Features� error when you open generated PDF
                ' Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)

                'pdfStamper.FormfFlattening = True
                'pdfStamper.AcroFields.GenerateAppearances = True

                Dim pdfFormFields As AcroFields = pdfStamper.AcroFields

                '--------Get some Data-----------

                Dim osite As Sites.Site = DB.Sites.Get(oEngineerVisit.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId)
                Dim ositeHQ As Sites.Site = DB.Sites.Get(osite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq)

                If osite.CustomerID = Enums.Customer.Domestic Then ositeHQ = New Sites.Site

                Dim Timesheets As DataTable = DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(oEngineerVisit.EngineerVisitID).Table
                Dim Engineer As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)

                Dim LastWorking As DateTime = Date.MinValue
                For Each dr As DataRow In Timesheets.Rows
                    If CDate(dr("EnddateTime")) > LastWorking AndAlso dr("TimesheetTypeID") = "211" Then
                        LastWorking = CDate(dr("Enddatetime"))
                    End If

                Next
                If LastWorking = Date.MinValue Then LastWorking = oEngineerVisit.EndDateTime
                ' ------ SET YOUR FORM FIELDS ------

                PdfSetFormFieldText(pdfFormFields, "ClientName", ositeHQ.Name, 6.0F)
                PdfSetFormFieldText(pdfFormFields, "ClientAddress", ositeHQ.Address1 & ", ", 6.0F)
                PdfSetFormFieldText(pdfFormFields, "ClientPostcode", ositeHQ.Address2 & ", " & ositeHQ.Address3 & ", " & ositeHQ.Postcode, 6.0F)
                PdfSetFormFieldText(pdfFormFields, "TenantName", osite.Name, 6.0F)
                PdfSetFormFieldText(pdfFormFields, "TenantAddress", osite.Address1 & ", ", 6.0F)
                PdfSetFormFieldText(pdfFormFields, "TenantPostcode", osite.Address2 & ", " & osite.Address3 & ", " & osite.Postcode, 6.0F)
                PdfSetFormFieldText(pdfFormFields, "IssueDate", LastWorking.ToString("dd/MM/yyyy"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "IssueTime", LastWorking.ToString("HH:mm"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "EngName", Engineer.Name, 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Make", WarningNotice("Make"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Model", WarningNotice("Model"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Type", WarningNotice("Model"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Location", WarningNotice("Location"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Reason", WarningNotice("Reason"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Action", WarningNotice("ActionTaken"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Present", WarningNotice("NoticeLeft"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Refused", WarningNotice("NoSign"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "NG1", WarningNotice("SupplierInformed"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "NG2", WarningNotice("SupplierInformed"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "TenName", oEngineerVisit.CustomerName, 7.7F)
                PdfSetFormFieldText(pdfFormFields, "TenDate", LastWorking.ToString("dd/MM/yyyy"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "GasEscape", WarningNotice("GasEscape"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Reason2", WarningNotice("SupplierInformedReason"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Reference", WarningNotice("SupplierInformedRef"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Riddor", WarningNotice("RiddorReported"), 7.7F)
                PdfSetFormFieldText(pdfFormFields, "Reason3", WarningNotice("RiddorReportedDetails"), 7.7F)
                ' ------------------ DO TICKS ----------------------------------------------
                If WarningNotice("CategoryID") = 405 Then
                    PDFSetTick(pdfFormFields, "ID", "", 8.0F)
                ElseIf WarningNotice("CategoryID") = 404 Then
                    If WarningNotice("TurnedOff") = "1" Then
                        PDFSetTick(pdfFormFields, "AR1", "", 8.0F)
                    Else
                        PDFSetTick(pdfFormFields, "AR2", "", 8.0F)
                    End If

                End If

                '--------------------------------------------------------------------------
                Dim engSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.EngineerSignature))
                engSig.Save(Application.StartupPath & "\TEMP\EngSig.bmp")

                Dim ad As PushbuttonField = pdfFormFields.GetNewPushbuttonFromField("EngSig")
                '   ad.setLayout(PushbuttonField.LAYOUT_ICON_ONLY)
                ' ad.setProportionalIcon(True);
                ad.Image = text.Image.GetInstance((Application.StartupPath & "\TEMP\EngSig.bmp"))
                pdfFormFields.ReplacePushbuttonField("EngSig", ad.Field)

                Dim CustSig As Bitmap = New Bitmap(New IO.MemoryStream(oEngineerVisit.CustomerSignature))
                CustSig.Save(Application.StartupPath & "\TEMP\CustSig.bmp")

                Dim ad1 As PushbuttonField = pdfFormFields.GetNewPushbuttonFromField("Signature")
                '   ad.setLayout(PushbuttonField.LAYOUT_ICON_ONLY)
                ' ad.setProportionalIcon(True);
                ad1.Image = text.Image.GetInstance((Application.StartupPath & "\TEMP\CustSig.bmp"))
                pdfFormFields.ReplacePushbuttonField("Signature", ad1.Field)

                ' close the pdf
                pdfStamper.Close()
                ' pdfReader.close() ---> DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP
                pdfStamper.Close()

                pdfReader.Close() 'DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP - well i did!!
                Cursor.Current = Cursors.WaitCursor
                Process.Start(filePath)
                Cursor.Current = Cursors.Default
            End Sub

#End Region

        End Class

    End Namespace

End Namespace