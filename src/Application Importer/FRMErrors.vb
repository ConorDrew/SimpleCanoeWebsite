Public Class FRMErrors : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal errorString As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.txtErrors.Text = errorString.Trim
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents btnClose As System.Windows.Forms.Button

    Friend WithEvents txtErrors As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtErrors = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Location = New System.Drawing.Point(776, 432)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        '
        'txtErrors
        '
        Me.txtErrors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErrors.Location = New System.Drawing.Point(8, 40)
        Me.txtErrors.Multiline = True
        Me.txtErrors.Name = "txtErrors"
        Me.txtErrors.ReadOnly = True
        Me.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtErrors.Size = New System.Drawing.Size(824, 384)
        Me.txtErrors.TabIndex = 1
        Me.txtErrors.Text = ""
        '
        'FRMErrors
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(840, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtErrors)
        Me.Controls.Add(Me.btnClose)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(848, 496)
        Me.Name = "FRMErrors"
        Me.Text = "Job Portal - Import Errors"
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.txtErrors, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Public ReadOnly Property LoadedControl() As IUserControl
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

End Class