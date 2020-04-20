Imports System.Data.SqlClient

Namespace Entity

    Namespace CheckLists

        Public Class CheckListSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll_For_Engineer_Visit(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("CheckLists_GetAll_For_Engineer_Visit")
                dt.TableName = Entity.Sys.Enums.TableNames.tblChecklists.ToString
                Return New DataView(dt)
            End Function

            Public Function Get_Questions_And_Answers_For_Section(ByVal SectionID As Integer, ByVal CheckListID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SectionID", SectionID, True)
                _database.AddParameter("@DateAdded", Now(), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Checklists_Get_Questions_For_Section")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCheckListAnswers.ToString

                If Not CheckListID = 0 Then
                    dt.AcceptChanges()
                    Dim answers As DataTable = Get_Answers(CheckListID).Table

                    For Each question As DataRow In dt.Rows
                        Dim dr As DataRow

                        If Not Entity.Sys.Helper.MakeIntegerValid(question.Item("SubTaskID")) = 0 Then
                            If answers.Select("EnumTableID = " & CInt(Entity.Sys.Enums.TableNames.tblSubTask) & " AND QuestionID = " & question.Item("SubTaskID")).Length > 0 Then
                                dr = answers.Select("EnumTableID = " & CInt(Entity.Sys.Enums.TableNames.tblSubTask) & " AND QuestionID = " & question.Item("SubTaskID"))(0)
                                question.Item("Result") = dr.Item("ResultID")
                                question.Item("Comments") = dr.Item("Comments")
                            End If
                        Else
                            If Not Entity.Sys.Helper.MakeIntegerValid(question.Item("TaskID")) = 0 Then
                                If answers.Select("EnumTableID = " & CInt(Entity.Sys.Enums.TableNames.tblTask) & " AND QuestionID = " & question.Item("TaskID")).Length > 0 Then
                                    dr = answers.Select("EnumTableID = " & CInt(Entity.Sys.Enums.TableNames.tblTask) & " AND QuestionID = " & question.Item("TaskID"))(0)
                                    question.Item("Result") = dr.Item("ResultID")
                                    question.Item("Comments") = dr.Item("Comments")
                                End If
                            Else
                                If Not Entity.Sys.Helper.MakeIntegerValid(question.Item("AreaID")) = 0 Then
                                    If answers.Select("EnumTableID = " & CInt(Entity.Sys.Enums.TableNames.tblArea) & " AND QuestionID = " & question.Item("AreaID")).Length > 0 Then
                                        dr = answers.Select("EnumTableID = " & CInt(Entity.Sys.Enums.TableNames.tblArea) & " AND QuestionID = " & question.Item("AreaID"))(0)
                                        question.Item("Result") = dr.Item("ResultID")
                                        question.Item("Comments") = dr.Item("Comments")
                                    End If
                                Else
                                    If answers.Select("EnumTableID = " & CInt(Entity.Sys.Enums.TableNames.tblSection) & " AND QuestionID = " & question.Item("SectionID")).Length > 0 Then
                                        dr = answers.Select("EnumTableID = " & CInt(Entity.Sys.Enums.TableNames.tblSection) & " AND QuestionID = " & question.Item("SectionID"))(0)
                                        question.Item("Result") = dr.Item("ResultID")
                                        question.Item("Comments") = dr.Item("Comments")
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If

                Return New DataView(dt)
            End Function

            Private Function Get_Answers(ByVal CheckListID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CheckListID", CheckListID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Checklists_Get_Answers")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCheckListAnswers.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get](ByVal CheckListID As Integer) As CheckList
                _database.ClearParameter()
                _database.AddParameter("@CheckListID", CheckListID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CheckLists_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCheckList As New CheckList
                        With oCheckList
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCheckListID = dt.Rows(0).Item("CheckListID")
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")
                            .SetSectionID = dt.Rows(0).Item("SectionID")
                            .AddedOn = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("AddedOn"))
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oCheckList.Exists = True
                        Return oCheckList
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Sub Delete(ByVal CheckListID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@CheckListID", CheckListID, True)
                _database.ExecuteSP_NO_Return("CheckLists_Delete")
            End Sub

            Public Function Insert(ByVal oCheckList As CheckList) As CheckList
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", oCheckList.EngineerVisitID, True)
                _database.AddParameter("@SectionID", oCheckList.SectionID, True)

                oCheckList.SetCheckListID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CheckLists_Insert"))
                oCheckList.Exists = True

                Return oCheckList
            End Function

            Public Sub DeleteAnswers(ByVal CheckListID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@CheckListID", CheckListID, True)
                _database.ExecuteSP_NO_Return("CheckLists_Delete_Answers")
            End Sub

            Public Sub InsertAnswer(ByVal oCheckListAnswer As CheckListAnswer)
                _database.ClearParameter()
                _database.AddParameter("@CheckListID", oCheckListAnswer.CheckListID, True)
                _database.AddParameter("@EnumTableID", oCheckListAnswer.EnumTableID, True)
                _database.AddParameter("@QuestionID", oCheckListAnswer.QuestionID, True)
                _database.AddParameter("@ResultID", oCheckListAnswer.ResultID, True)
                _database.AddParameter("@Comments", oCheckListAnswer.Comments, True)

                _database.ExecuteSP_NO_Return("CheckLists_Insert_Answer")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


