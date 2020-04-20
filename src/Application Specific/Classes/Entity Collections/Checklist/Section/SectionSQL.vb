Imports System.Data.SqlClient

Namespace Entity

Namespace Sections

Public Class SectionSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal SectionID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@SectionID", SectionID, True)
            _database.ExecuteSP_NO_Return("Section_Delete")
    End Sub

    Public Function [Section_Get](ByVal SectionID As Integer) As Section
        _database.ClearParameter()
        _database.AddParameter("@SectionID", SectionID)
        
        'Get the datatable from the database store in dt
        Dim dt As DataTable = _database.ExecuteSP_DataTable("Section_Get")
        
        If Not dt Is Nothing Then			
			if dt.rows.count > 0 then
				Dim oSection As New Section
				With oSection
				    .IgnoreExceptionsOnSetMethods = True
						.SetSectionID= dt.Rows(0).Item("SectionID")
				.SetDescription= dt.Rows(0).Item("Description")

					.SetDeleted = dt.Rows(0).Item("Deleted")               
				End With		
				oSection.Exists = true				
			Return oSection
			else
					Return Nothing
			end if 
			       Else
            Return Nothing
        End If
    End Function

    Public Function [Section_GetAll]() As DataView
       _database.ClearParameter()
        Dim dt As DataTable = _database.ExecuteSP_DataTable("Section_GetAll")
        dt.TableName = Entity.Sys.Enums.TableNames.tblSection.ToString
        Return New DataView(dt)
    End Function
   
    Public Function [Insert](ByVal oSection As Section) As Section
		 _database.ClearParameter()			
                AddSectionParametersToCommand(oSection)

		oSection.SetSectionID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Section_Insert"))				
        oSection.Exists = True
        Return oSection
    End Function   
    

    Public Sub [Update](ByVal oSection As Section)
		_database.ClearParameter()
		_database.AddParameter("@SectionID", oSection.SectionID, True)  
		AddSectionParametersToCommand(oSection)
		_database.ExecuteSP_NO_Return("Section_Update")
    End Sub



    Private Sub AddSectionParametersToCommand(ByRef oSection As Section)    
        With _database
			.AddParameter("@Description", oSection.Description, True)
        End With        
    End Sub      
    

#End Region

End Class

End Namespace

End Namespace


