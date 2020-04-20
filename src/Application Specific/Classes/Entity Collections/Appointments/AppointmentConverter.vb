Namespace Entity

    Namespace Appointments

        Public Class AppointmentConverter
            'Function to convert picklist managerid's to new appointment id
            Public Function ToNew(ByVal appointmentID As Integer) As Integer
                Select Case appointmentID
                    Case Entity.Sys.Enums.AppointmentsPicklist.FirstCall
                        Return Entity.Sys.Enums.Appointments.FirstCall
                    Case Entity.Sys.Enums.AppointmentsPicklist.EightAmTillTwelvePm
                        Return Entity.Sys.Enums.Appointments.EightAmTillTwelvePm
                    Case Entity.Sys.Enums.AppointmentsPicklist.TenAmTillTwoPm
                        Return Entity.Sys.Enums.Appointments.TenAmTillTwoPm
                    Case Entity.Sys.Enums.AppointmentsPicklist.TwelvePmTillFourPm
                        Return Entity.Sys.Enums.Appointments.TwelvePmTillFourPm
                    Case Entity.Sys.Enums.AppointmentsPicklist.TwoPmTillSixPm
                        Return Entity.Sys.Enums.Appointments.TwoPmTillSixPm
                    Case Entity.Sys.Enums.AppointmentsPicklist.Am
                        Return Entity.Sys.Enums.Appointments.Am
                    Case Entity.Sys.Enums.AppointmentsPicklist.Pm
                        Return Entity.Sys.Enums.Appointments.Pm
                    Case Entity.Sys.Enums.AppointmentsPicklist.Anytime
                        Return Entity.Sys.Enums.Appointments.Anytime
                    Case Else
                        Return 0 'invalid picklist number
                End Select
            End Function

            'Function to convert appointment id to old picklist manager id
            Public Function ToOld(ByVal appointmentID As Integer) As Integer
                Select Case appointmentID
                    Case Entity.Sys.Enums.Appointments.FirstCall
                        Return Entity.Sys.Enums.AppointmentsPicklist.FirstCall
                    Case Entity.Sys.Enums.Appointments.EightAmTillTwelvePm
                        Return Entity.Sys.Enums.AppointmentsPicklist.EightAmTillTwelvePm
                    Case Entity.Sys.Enums.Appointments.TenAmTillTwoPm
                        Return Entity.Sys.Enums.AppointmentsPicklist.TenAmTillTwoPm
                    Case Entity.Sys.Enums.Appointments.TwelvePmTillFourPm
                        Return Entity.Sys.Enums.AppointmentsPicklist.TwelvePmTillFourPm
                    Case Entity.Sys.Enums.Appointments.TwoPmTillSixPm
                        Return Entity.Sys.Enums.AppointmentsPicklist.TwoPmTillSixPm
                    Case Entity.Sys.Enums.Appointments.Am
                        Return Entity.Sys.Enums.AppointmentsPicklist.Am
                    Case Entity.Sys.Enums.Appointments.Pm
                        Return Entity.Sys.Enums.AppointmentsPicklist.Pm
                    Case Entity.Sys.Enums.Appointments.Anytime
                        Return Entity.Sys.Enums.AppointmentsPicklist.Anytime
                    Case Else
                        Return 0 'invalid appointment dd
                End Select
            End Function
        End Class

    End Namespace

End Namespace

