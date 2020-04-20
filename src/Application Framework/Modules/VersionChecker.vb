Public Module VersionChecker

#Region "Functions"

    Public Sub Unlock()
        Try
           
            If AlreadyRunning() Then

                DB.Job.UnlockTimed(loggedInUser.UserID)

            Else

                DB.Job.UnlockAll(loggedInUser.UserID)

            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub DifferentVersionsMessage(ByVal AssemblyVesion As String, ByVal LatestVersion As String, ByVal LatestVersionReleased As String, ByVal MessageIn As String)
        Dim message As String = "WARNING!" & vbNewLine & vbNewLine & _
            "Assembly version checking has discovered a version inconsistency." & vbNewLine & vbNewLine & _
            "This program's assembly version is: " & AssemblyVesion & vbNewLine & _
            "The database reports the latest version is: " & LatestVersion & " (Released: " & LatestVersionReleased & ")" & _
            vbNewLine & vbNewLine & MessageIn
        ShowMessage(message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub NotSetupMessage(ByVal MessageIn As String)
        ShowMessage(MessageIn, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub


    Private Function AlreadyRunning() As Boolean
        ' Get our process name.
        Dim my_proc As Process = Process.GetCurrentProcess
        Dim my_name As String = my_proc.ProcessName

        ' Get information about processes with this name.
        Dim procs() As Process = _
            Process.GetProcessesByName(my_name)

        ' If there is only one, it's us.
        If procs.Length = 1 Then Return False

        ' If there is more than one process,
        ' see if one has a StartTime before ours.
        Dim i As Integer
        For i = 0 To procs.Length - 1
            If procs(i).StartTime < my_proc.StartTime Then _
                Return True
        Next i

        ' If we get here, we were first.
        Return False
    End Function

#End Region

End Module
