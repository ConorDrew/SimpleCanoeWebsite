Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitAdditionals

        Public Class EngineerVisitAdditionalSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal EngineerVisitAdditionalID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitAdditionalID", EngineerVisitAdditionalID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitAdditional_Delete")
            End Sub

            Public Function [EngineerVisitAdditional_Get](ByVal EngineerVisitAdditionalID As Integer) As EngineerVisitAdditional
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitAdditionalID", EngineerVisitAdditionalID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAdditional_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerVisitAdditional As New EngineerVisitAdditional
                        With oEngineerVisitAdditional
                            .IgnoreExceptionsOnSetMethods = True
                            .SetTestTypeID = dt.Rows(0).Item("TestType")
                            .SetEngineerVisitAdditionalID = dt.Rows(0).Item("EngineerVisitAdditionalID")
                            .SetTest1 = dt.Rows(0).Item("Test1")
                            .SetTest2 = dt.Rows(0).Item("Test2")
                            .SetTest3 = dt.Rows(0).Item("Test3")
                            .SetTest4 = dt.Rows(0).Item("Test4")
                            .SetTest5 = dt.Rows(0).Item("Test5")
                            .SetTest6 = dt.Rows(0).Item("Test6")
                            .SetTest7 = dt.Rows(0).Item("Test7")
                            .SetTest8 = dt.Rows(0).Item("Test8")
                            .SetTest9 = dt.Rows(0).Item("Test9")
                            .SetTest10 = dt.Rows(0).Item("Test10")
                            .SetTest111 = dt.Rows(0).Item("Test111")
                            .SetTest112 = dt.Rows(0).Item("Test112")
                            .SetTest113 = dt.Rows(0).Item("Test113")
                            .SetTest114 = dt.Rows(0).Item("Test114")
                            .SetTest115 = dt.Rows(0).Item("Test115")
                            .SetTest116 = dt.Rows(0).Item("Test116")
                            .SetTest117 = dt.Rows(0).Item("Test117")
                            .SetTest118 = dt.Rows(0).Item("Test118")
                            .SetTest119 = dt.Rows(0).Item("Test119")
                            .SetTest120 = dt.Rows(0).Item("Test120")

                            .SetTest121 = dt.Rows(0).Item("Test121")
                            .SetTest122 = dt.Rows(0).Item("Test122")
                            .SetTest123 = dt.Rows(0).Item("Test123")
                            .SetTest124 = dt.Rows(0).Item("Test124")
                            .SetTest125 = dt.Rows(0).Item("Test125")

                            .SetTest11 = dt.Rows(0).Item("Test11")
                            .SetTest12 = dt.Rows(0).Item("Test12")
                            .SetTest13 = dt.Rows(0).Item("Test13")
                            .SetTest14 = dt.Rows(0).Item("Test14")
                            .SetTest15 = dt.Rows(0).Item("Test15")
                            .SetTest216 = dt.Rows(0).Item("Test216")
                            .SetTest217 = dt.Rows(0).Item("Test217")
                            .SetTest218 = dt.Rows(0).Item("Test218")
                            .SetTest219 = dt.Rows(0).Item("Test219")
                            .SetTest220 = dt.Rows(0).Item("Test220")
                            .SetTest221 = dt.Rows(0).Item("Test221")
                            .SetTest222 = dt.Rows(0).Item("Test222")
                            .SetTest223 = dt.Rows(0).Item("Test223")
                            .SetTest224 = dt.Rows(0).Item("Test224")
                            .SetTest225 = dt.Rows(0).Item("Test225")
                            .SetTest226 = dt.Rows(0).Item("Test226")
                            .SetTest227 = dt.Rows(0).Item("Test227")
                            .SetTest228 = dt.Rows(0).Item("Test228")
                            .SetTest229 = dt.Rows(0).Item("Test229")
                            .SetTest230 = dt.Rows(0).Item("Test230")
                            .SetTest231 = dt.Rows(0).Item("Test231")
                            .SetTest232 = dt.Rows(0).Item("Test232")
                            .SetTest233 = dt.Rows(0).Item("Test233")
                            .SetTest234 = dt.Rows(0).Item("Test234")
                            .SetTest235 = dt.Rows(0).Item("Test235")
                            .SetTest236 = dt.Rows(0).Item("Test236")
                            .SetTest237 = dt.Rows(0).Item("Test237")
                            .SetTest238 = dt.Rows(0).Item("Test238")
                            .SetTest239 = dt.Rows(0).Item("Test239")
                            .SetTest240 = dt.Rows(0).Item("Test240")

                            .SetTest16 = MakeDateSafe(dt.Rows(0).Item("Test16"))
                            .SetTest17 = MakeDateSafe(dt.Rows(0).Item("Test17"))
                            .SetTest18 = MakeDateSafe(dt.Rows(0).Item("Test18"))
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")

                        End With
                        oEngineerVisitAdditional.Exists = True
                        Return oEngineerVisitAdditional
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function EngineerVisitAdditional_GetForEngineerVisit(ByVal EngineerVisitID As Integer, ByVal Type As Integer) As EngineerVisitAdditional
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID)
                _database.AddParameter("@TestType", Type)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAdditional_GetForEngineerVisit")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerVisitAdditional As New EngineerVisitAdditional
                        With oEngineerVisitAdditional
                            .IgnoreExceptionsOnSetMethods = True
                            .SetTestTypeID = dt.Rows(0).Item("TestType")
                            .SetEngineerVisitAdditionalID = dt.Rows(0).Item("EngineerVisitAdditionalID")
                            .SetTest1 = dt.Rows(0).Item("Test1")
                            .SetTest2 = dt.Rows(0).Item("Test2")
                            .SetTest3 = dt.Rows(0).Item("Test3")
                            .SetTest4 = dt.Rows(0).Item("Test4")
                            .SetTest5 = dt.Rows(0).Item("Test5")
                            .SetTest6 = dt.Rows(0).Item("Test6")
                            .SetTest7 = dt.Rows(0).Item("Test7")
                            .SetTest8 = dt.Rows(0).Item("Test8")
                            .SetTest9 = dt.Rows(0).Item("Test9")
                            .SetTest10 = dt.Rows(0).Item("Test10")
                            .SetTest111 = dt.Rows(0).Item("Test111")
                            .SetTest112 = dt.Rows(0).Item("Test112")
                            .SetTest113 = dt.Rows(0).Item("Test113")
                            .SetTest114 = dt.Rows(0).Item("Test114")
                            .SetTest115 = dt.Rows(0).Item("Test115")
                            .SetTest116 = dt.Rows(0).Item("Test116")
                            .SetTest117 = dt.Rows(0).Item("Test117")
                            .SetTest118 = dt.Rows(0).Item("Test118")
                            .SetTest119 = dt.Rows(0).Item("Test119")
                            .SetTest120 = dt.Rows(0).Item("Test120")

                            .SetTest121 = dt.Rows(0).Item("Test121")
                            .SetTest122 = dt.Rows(0).Item("Test122")
                            .SetTest123 = dt.Rows(0).Item("Test123")
                            .SetTest124 = dt.Rows(0).Item("Test124")
                            .SetTest125 = dt.Rows(0).Item("Test125")
                            .SetTest126 = dt.Rows(0).Item("Test126")
                            .SetTest127 = dt.Rows(0).Item("Test127")
                            .SetTest128 = dt.Rows(0).Item("Test128")
                            .SetTest129 = dt.Rows(0).Item("Test129")
                            .SetTest130 = dt.Rows(0).Item("Test130")
                            .SetTest131 = dt.Rows(0).Item("Test131")
                            .SetTest132 = dt.Rows(0).Item("Test132")
                            .SetTest133 = dt.Rows(0).Item("Test133")
                            .SetTest134 = dt.Rows(0).Item("Test134")
                            .SetTest135 = dt.Rows(0).Item("Test135")
                            .SetTest136 = dt.Rows(0).Item("Test136")
                            .SetTest137 = dt.Rows(0).Item("Test137")
                            .SetTest138 = dt.Rows(0).Item("Test138")
                            .SetTest139 = dt.Rows(0).Item("Test139")
                            .SetTest140 = dt.Rows(0).Item("Test140")

                            .SetTest11 = dt.Rows(0).Item("Test11")
                            .SetTest12 = dt.Rows(0).Item("Test12")
                            .SetTest13 = dt.Rows(0).Item("Test13")
                            .SetTest14 = dt.Rows(0).Item("Test14")
                            .SetTest15 = dt.Rows(0).Item("Test15")
                            .SetTest216 = dt.Rows(0).Item("Test216")
                            .SetTest217 = dt.Rows(0).Item("Test217")
                            .SetTest218 = dt.Rows(0).Item("Test218")
                            .SetTest219 = dt.Rows(0).Item("Test219")
                            .SetTest220 = dt.Rows(0).Item("Test220")
                            .SetTest221 = dt.Rows(0).Item("Test221")
                            .SetTest222 = dt.Rows(0).Item("Test222")
                            .SetTest223 = dt.Rows(0).Item("Test223")
                            .SetTest224 = dt.Rows(0).Item("Test224")
                            .SetTest225 = dt.Rows(0).Item("Test225")
                            .SetTest226 = dt.Rows(0).Item("Test226")
                            .SetTest227 = dt.Rows(0).Item("Test227")
                            .SetTest228 = dt.Rows(0).Item("Test228")
                            .SetTest229 = dt.Rows(0).Item("Test229")
                            .SetTest230 = dt.Rows(0).Item("Test230")
                            .SetTest231 = dt.Rows(0).Item("Test231")
                            .SetTest232 = dt.Rows(0).Item("Test232")
                            .SetTest233 = dt.Rows(0).Item("Test233")
                            .SetTest234 = dt.Rows(0).Item("Test234")
                            .SetTest235 = dt.Rows(0).Item("Test235")
                            .SetTest236 = dt.Rows(0).Item("Test236")
                            .SetTest237 = dt.Rows(0).Item("Test237")
                            .SetTest238 = dt.Rows(0).Item("Test238")
                            .SetTest239 = dt.Rows(0).Item("Test239")
                            .SetTest240 = dt.Rows(0).Item("Test240")

                            .SetTest16 = MakeDateSafe(dt.Rows(0).Item("Test16"))
                            .SetTest17 = MakeDateSafe(dt.Rows(0).Item("Test17"))
                            .SetTest18 = MakeDateSafe(dt.Rows(0).Item("Test18"))
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")

                        End With
                        oEngineerVisitAdditional.Exists = True
                        Return oEngineerVisitAdditional
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [EngineerVisitAdditional_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAdditional_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitNCCGSR.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oEngineerVisitAdditional As EngineerVisitAdditional) As EngineerVisitAdditional
                _database.ClearParameter()
                AddEngineerVisitAdditionalParametersToCommand(oEngineerVisitAdditional)

                oEngineerVisitAdditional.SetEngineerVisitAdditionalID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitAdditional_Insert"))
                oEngineerVisitAdditional.Exists = True
                Return oEngineerVisitAdditional
            End Function

            Public Sub [Update](ByVal oEngineerVisitAdditional As EngineerVisitAdditional)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitAdditionalID", oEngineerVisitAdditional.EngineerVisitAdditionalID, True)
                AddEngineerVisitAdditionalParametersToCommand(oEngineerVisitAdditional)
                _database.ExecuteSP_NO_Return("EngineerVisitAdditional_Update")
            End Sub

            Private Sub AddEngineerVisitAdditionalParametersToCommand(ByRef oEngineerVisitAdditional As EngineerVisitAdditional)
                With _database

                    Dim date1 As DateTime = oEngineerVisitAdditional.Test16
                    Dim date2 As DateTime = oEngineerVisitAdditional.Test17
                    Dim date3 As DateTime = oEngineerVisitAdditional.Test18
                    .AddParameter("@EngineerVisitID", oEngineerVisitAdditional.EngineerVisitID, True)
                    .AddParameter("@TestType", oEngineerVisitAdditional.TestTypeID, True)
                    .AddParameter("@Test1", oEngineerVisitAdditional.Test1, True)
                    .AddParameter("@Test2", oEngineerVisitAdditional.Test2, True)
                    .AddParameter("@Test3", oEngineerVisitAdditional.Test3, True)
                    .AddParameter("@Test4", oEngineerVisitAdditional.Test4, True)
                    .AddParameter("@Test5", oEngineerVisitAdditional.Test5, True)
                    .AddParameter("@Test6", oEngineerVisitAdditional.Test6, True)
                    .AddParameter("@Test7", oEngineerVisitAdditional.Test7, True)
                    .AddParameter("@Test8", oEngineerVisitAdditional.Test8, True)
                    .AddParameter("@Test9", oEngineerVisitAdditional.Test9, True)
                    .AddParameter("@Test10", oEngineerVisitAdditional.Test10, True)
                    .AddParameter("@Test111", oEngineerVisitAdditional.Test111, True)
                    .AddParameter("@Test112", oEngineerVisitAdditional.Test112, True)
                    .AddParameter("@Test113", oEngineerVisitAdditional.Test113, True)
                    .AddParameter("@Test114", oEngineerVisitAdditional.Test114, True)
                    .AddParameter("@Test115", oEngineerVisitAdditional.Test115, True)
                    .AddParameter("@Test116", oEngineerVisitAdditional.Test116, True)
                    .AddParameter("@Test117", oEngineerVisitAdditional.Test117, True)
                    .AddParameter("@Test118", oEngineerVisitAdditional.Test118, True)
                    .AddParameter("@Test119", oEngineerVisitAdditional.Test119, True)
                    .AddParameter("@Test120", oEngineerVisitAdditional.Test120, True)

                    .AddParameter("@Test11", oEngineerVisitAdditional.Test11, True)
                    .AddParameter("@Test12", oEngineerVisitAdditional.Test12, True)
                    .AddParameter("@Test13", oEngineerVisitAdditional.Test13, True)
                    .AddParameter("@Test14", oEngineerVisitAdditional.Test14, True)
                    .AddParameter("@Test15", oEngineerVisitAdditional.Test15, True)
                    .AddParameter("@Test216", oEngineerVisitAdditional.Test216, True)
                    .AddParameter("@Test217", oEngineerVisitAdditional.Test217, True)
                    .AddParameter("@Test218", oEngineerVisitAdditional.Test218, True)
                    .AddParameter("@Test219", oEngineerVisitAdditional.Test219, True)
                    .AddParameter("@Test220", oEngineerVisitAdditional.Test220, True)
                    .AddParameter("@Test221", oEngineerVisitAdditional.Test221, True)
                    .AddParameter("@Test222", oEngineerVisitAdditional.Test222, True)
                    .AddParameter("@Test223", oEngineerVisitAdditional.Test223, True)
                    .AddParameter("@Test224", oEngineerVisitAdditional.Test224, True)
                    .AddParameter("@Test225", oEngineerVisitAdditional.Test225, True)
                    .AddParameter("@Test226", oEngineerVisitAdditional.Test226, True)
                    .AddParameter("@Test227", oEngineerVisitAdditional.Test227, True)
                    .AddParameter("@Test228", oEngineerVisitAdditional.Test228, True)
                    .AddParameter("@Test229", oEngineerVisitAdditional.Test229, True)
                    .AddParameter("@Test230", oEngineerVisitAdditional.Test230, True)
                    .AddParameter("@Test231", oEngineerVisitAdditional.Test231, True)
                    .AddParameter("@Test232", oEngineerVisitAdditional.Test232, True)
                    .AddParameter("@Test233", oEngineerVisitAdditional.Test233, True)
                    .AddParameter("@Test234", oEngineerVisitAdditional.Test234, True)
                    .AddParameter("@Test235", oEngineerVisitAdditional.Test235, True)
                    .AddParameter("@Test236", oEngineerVisitAdditional.Test236, True)
                    .AddParameter("@Test237", oEngineerVisitAdditional.Test237, True)
                    .AddParameter("@Test238", oEngineerVisitAdditional.Test238, True)
                    .AddParameter("@Test239", oEngineerVisitAdditional.Test239, True)
                    .AddParameter("@Test240", oEngineerVisitAdditional.Test240, True)

                    If oEngineerVisitAdditional.Test16 = DateTime.MinValue Then
                        .AddParameter("@Test16", DBNull.Value, True)
                    Else
                        .AddParameter("@Test16", Entity.Sys.Helper.MakeDateTimeValid(oEngineerVisitAdditional.Test16), True)
                    End If
                    If oEngineerVisitAdditional.Test17 = DateTime.MinValue Then
                        .AddParameter("@Test17", DBNull.Value, True)
                    Else
                        .AddParameter("@Test17", Entity.Sys.Helper.MakeDateTimeValid(oEngineerVisitAdditional.Test17), True)
                    End If
                    If oEngineerVisitAdditional.Test18 = DateTime.MinValue Then
                        .AddParameter("@Test18", DBNull.Value, True)
                    Else
                        .AddParameter("@Test18", Entity.Sys.Helper.MakeDateTimeValid(oEngineerVisitAdditional.Test18), True)
                    End If

                End With
            End Sub

            Public Function EngineerVisitAdditionalWorkSheet_GetForVisitDV(ByVal EngineerVisitID As Integer, Optional ByVal Oil As Integer = -1) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@TestType", 0)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAdditional_GetForEngineerVisit")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitSmokeComo_GetForVisitDV(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAlarms_GetForEngineerVisit")
                dt.TableName = "Alarms"
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(ByVal EngineerVisitID As Integer, Optional ByVal test As Integer = -1) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@TestType", test)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAdditional_GetForEngineerVisit")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString
                Return New DataView(dt)
            End Function

#End Region

            Public Shared Function MakeDateSafe(ByVal myDate As Object) As DateTime
                If myDate.ToString = "" Then
                    'myDate.ToString("yyyy/MM/dd hh:mm:ss") = "0001/01/01 12:00:00" Or
                    Return CDate("01/01/1900")
                Else
                    Return myDate
                End If

            End Function

            Public Function EngineerVisitAdditionalWorkSheet_ElectricalZsMatrix_Get() As DataTable
                _database.ClearParameter()

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ElectricalZsMatrix_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString
                Return (dt)
            End Function

        End Class

    End Namespace

End Namespace