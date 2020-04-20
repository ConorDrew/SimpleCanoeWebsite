Public Interface ISchedulerForm

    ReadOnly Property Name() As String

    Property EngineerID() As String

    ReadOnly Property IsDisposed() As Boolean

    ReadOnly Property PicPlanner() As PictureBox

    Property TimeSlotDt() As DataTable

    Function selectedDay() As String

    ReadOnly Property Handle() As IntPtr

End Interface
