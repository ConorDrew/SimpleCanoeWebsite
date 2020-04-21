using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FSM
{
    public static class VersionChecker
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public static void Unlock()
        {
            try
            {
                if (AlreadyRunning())
                {
                    App.DB.Job.UnlockTimed(App.loggedInUser.UserID);
                }
                else
                {
                    App.DB.Job.UnlockAll(App.loggedInUser.UserID);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void DifferentVersionsMessage(string AssemblyVesion, string LatestVersion, string LatestVersionReleased, string MessageIn)
        {
            string message = "WARNING!" + Constants.vbNewLine + Constants.vbNewLine + "Assembly version checking has discovered a version inconsistency." + Constants.vbNewLine + Constants.vbNewLine + "This program's assembly version is: " + AssemblyVesion + Constants.vbNewLine + "The database reports the latest version is: " + LatestVersion + " (Released: " + LatestVersionReleased + ")" + Constants.vbNewLine + Constants.vbNewLine + MessageIn;

            App.ShowMessage(message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private static void NotSetupMessage(string MessageIn)
        {
            App.ShowMessage(MessageIn, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private static bool AlreadyRunning()
        {
            // Get our process name.
            var my_proc = Process.GetCurrentProcess();
            string my_name = my_proc.ProcessName;

            // Get information about processes with this name.
            var procs = Process.GetProcessesByName(my_name);

            // If there is only one, it's us.
            if (procs.Length == 1)
                return false;

            // If there is more than one process,
            // see if one has a StartTime before ours.
            int i;
            var loopTo = procs.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (procs[i].StartTime < my_proc.StartTime)
                    return true;
            }

            // If we get here, we were first.
            return false;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}