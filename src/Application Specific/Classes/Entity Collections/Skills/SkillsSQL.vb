Namespace Entity.Skills
    Public Class SkillsSQL

        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

        Public Function SkillType_Insert(ByVal oSkillType As SkillType) As SkillType
            _database.ClearParameter()
            _database.AddParameter("@Name", oSkillType.Name)
            _database.AddParameter("@AddedBy", loggedInUser.UserID)
            oSkillType.SetSkillTypeID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SkillType_Insert"))
            oSkillType.Exists = True
            Return oSkillType
        End Function

        Public Function SkillType_Update(ByVal oSkillType As SkillType) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@SkillTypeID", oSkillType.SkillTypeID)
            _database.AddParameter("@Name", oSkillType.Name)

            Return CBool(_database.ExecuteSP_ReturnRowsAffected("SkillType_Update") = 1)
        End Function

        Public Function SkillType_Get_BySkill(ByVal skillId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SkillID", skillId)
            Return New DataView(_database.ExecuteSP_DataTable("SkillType_Get_BySkill"))
        End Function

        Public Function SkillType_GetAll() As DataView
            _database.ClearParameter()
            Return New DataView(_database.ExecuteSP_DataTable("SkillType_GetAll"))
        End Function

        Public Function SkillMatrix_Insert(ByVal skillId As Integer, ByVal skillTypeId As Integer) As Integer
            _database.ClearParameter()
            _database.AddParameter("@SkillTypeId", skillTypeId)
            _database.AddParameter("@SkillId", skillId)
            Return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SkillMatrix_Insert"))
        End Function

        Public Function SkillMatrix_GetAll() As DataView
            _database.ClearParameter()
            Return New DataView(_database.ExecuteSP_DataTable("SkillMatrix_GetAll"))
        End Function

        Public Function Skills_GetAllNotAssignedType() As DataView
            _database.ClearParameter()
            Return New DataView(_database.ExecuteSP_DataTable("Skills_GetAllNotAssignedType"))
        End Function

        Public Function SkillMatrix_GetAll_ByType(ByVal skillTypeId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SkillTypeId", skillTypeId)
            Return New DataView(_database.ExecuteSP_DataTable("SkillMatrix_GetAll_ByType"))
        End Function

        Public Function SkillMatrix_Delete(ByVal skillMatrixId As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@SkillMatrixId", skillMatrixId)

            Return CBool(_database.ExecuteSP_ReturnRowsAffected("SkillMatrix_Delete") = 1)
        End Function
    End Class
End Namespace

