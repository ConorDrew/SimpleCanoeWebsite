Imports System.Data.SqlClient

Namespace Entity

    Namespace StandardSentences

        Public Class StandardSentenceSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("StandardSentence_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblStandardSentences.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Insert](ByVal oStandardSentence As StandardSentence)
                _database.ClearParameter()
                AddSentenceParametersToCommand(oStandardSentence)
                _database.ExecuteSP_NO_Return("StandardSentence_Insert")

            End Sub

            Public Sub [Update](ByVal oStandardSentence As StandardSentence)
                _database.ClearParameter()
                _database.AddParameter("@SentenceID", oStandardSentence.SentenceID, True)
                AddSentenceParametersToCommand(oStandardSentence)
                _database.ExecuteSP_NO_Return("StandardSentence_Update")
            End Sub

            Private Sub AddSentenceParametersToCommand(ByRef oStandardSentence As StandardSentence)
                With _database
                    .AddParameter("@Sentence", oStandardSentence.Sentence, True)
                End With
            End Sub

            Public Sub [Delete](ByVal SentenceID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@SentenceID", SentenceID, True)
                _database.ExecuteSP_NO_Return("StandardSentence_Delete")
            End Sub

#End Region


        End Class

    End Namespace

End Namespace