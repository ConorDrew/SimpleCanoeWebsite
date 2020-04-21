using System;
using System.Runtime.InteropServices;

namespace FSM
{
    /// <summary>
    /// Class containing the IOleMessageFilter
    /// thread error-handling functions.
    /// </summary>
    internal class MessageFilter : IOleMessageFilter
    {
        /// <summary>Start the filter.</summary>
        public static void Register()
        {
            IOleMessageFilter newFilter = new MessageFilter();
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(newFilter, ref oldFilter);
        }

        /// <summary>Done with the filter, close it.</summary>
        public static void Revoke()
        {
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(null, ref oldFilter);
        }

        // IOleMessageFilter functions.
        /// <summary>Handle incoming thread requests.</summary>
        public int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo)
        {
            // Return the flag SERVERCALL_ISHANDLED.
            return 0;
        }

        /// <summary>Thread call was rejected, so try again.</summary>
        public int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType)
        {
            if (dwRejectType == 2)
            {
                // flag = SERVERCALL_RETRYLATER.
                // Retry the thread call immediately if return >=0 &
                // <100.
                return 99;
            }
            // Too busy; cancel call.
            return -1;
        }

        public int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
        {
            // Return the flag PENDINGMSG_WAITDEFPROCESS.
            return 2;
        }

        /// <summary>Implement the IOleMessageFilter interface.</summary>
        [DllImport("Ole32.dll")]
        private static extern int CoRegisterMessageFilter(IOleMessageFilter newFilter, ref IOleMessageFilter oldFilter);
    }

    [ComImport()]
    [Guid("00000016-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IOleMessageFilter
    {
        [PreserveSig()]
        int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo);

        [PreserveSig()]
        int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType);

        [PreserveSig()]
        int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType);
    }
}