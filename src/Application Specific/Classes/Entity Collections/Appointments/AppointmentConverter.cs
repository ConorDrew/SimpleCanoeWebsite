
namespace FSM.Entity
{
    namespace Appointments
    {
        public class AppointmentConverter
        {
            // Function to convert picklist managerid's to new appointment id
            public int ToNew(int appointmentID)
            {
                switch (appointmentID)
                {
                    case (int)Sys.Enums.AppointmentsPicklist.FirstCall:
                        {
                            return (int)Sys.Enums.Appointments.FirstCall;
                        }

                    case (int)Sys.Enums.AppointmentsPicklist.EightAmTillTwelvePm:
                        {
                            return (int)Sys.Enums.Appointments.EightAmTillTwelvePm;
                        }

                    case (int)Sys.Enums.AppointmentsPicklist.TenAmTillTwoPm:
                        {
                            return (int)Sys.Enums.Appointments.TenAmTillTwoPm;
                        }

                    case (int)Sys.Enums.AppointmentsPicklist.TwelvePmTillFourPm:
                        {
                            return (int)Sys.Enums.Appointments.TwelvePmTillFourPm;
                        }

                    case (int)Sys.Enums.AppointmentsPicklist.TwoPmTillSixPm:
                        {
                            return (int)Sys.Enums.Appointments.TwoPmTillSixPm;
                        }

                    case (int)Sys.Enums.AppointmentsPicklist.Am:
                        {
                            return (int)Sys.Enums.Appointments.Am;
                        }

                    case (int)Sys.Enums.AppointmentsPicklist.Pm:
                        {
                            return (int)Sys.Enums.Appointments.Pm;
                        }

                    case (int)Sys.Enums.AppointmentsPicklist.Anytime:
                        {
                            return (int)Sys.Enums.Appointments.Anytime;
                        }

                    default:
                        {
                            return 0; // invalid picklist number
                        }
                }
            }

            // Function to convert appointment id to old picklist manager id
            public int ToOld(int appointmentID)
            {
                switch (appointmentID)
                {
                    case (int)Sys.Enums.Appointments.FirstCall:
                        {
                            return (int)Sys.Enums.AppointmentsPicklist.FirstCall;
                        }

                    case (int)Sys.Enums.Appointments.EightAmTillTwelvePm:
                        {
                            return (int)Sys.Enums.AppointmentsPicklist.EightAmTillTwelvePm;
                        }

                    case (int)Sys.Enums.Appointments.TenAmTillTwoPm:
                        {
                            return (int)Sys.Enums.AppointmentsPicklist.TenAmTillTwoPm;
                        }

                    case (int)Sys.Enums.Appointments.TwelvePmTillFourPm:
                        {
                            return (int)Sys.Enums.AppointmentsPicklist.TwelvePmTillFourPm;
                        }

                    case (int)Sys.Enums.Appointments.TwoPmTillSixPm:
                        {
                            return (int)Sys.Enums.AppointmentsPicklist.TwoPmTillSixPm;
                        }

                    case (int)Sys.Enums.Appointments.Am:
                        {
                            return (int)Sys.Enums.AppointmentsPicklist.Am;
                        }

                    case (int)Sys.Enums.Appointments.Pm:
                        {
                            return (int)Sys.Enums.AppointmentsPicklist.Pm;
                        }

                    case (int)Sys.Enums.Appointments.Anytime:
                        {
                            return (int)Sys.Enums.AppointmentsPicklist.Anytime;
                        }

                    default:
                        {
                            return 0; // invalid appointment dd
                        }
                }
            }
        }
    }
}