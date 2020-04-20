Public Class UCSignature : Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents pbSignature As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pbSignature = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'pbSignature
        '
        Me.pbSignature.Location = New System.Drawing.Point(0, 0)
        Me.pbSignature.Name = "pbSignature"
        Me.pbSignature.Size = New System.Drawing.Size(320, 88)
        Me.pbSignature.TabIndex = 12
        Me.pbSignature.TabStop = False
        '
        'UCSignature
        '
        Me.Controls.Add(Me.pbSignature)
        Me.Name = "UCSignature"
        Me.Size = New System.Drawing.Size(320, 88)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables / Properties"

    Private _signatureData As String = ""
    Public Property SignatureData() As String
        Get
            Return _signatureData
        End Get
        Set(ByVal Value As String)
            _signatureData = Value
            Dim signatureControl As New Entity.Sys.SignatureBox(Me.pbSignature)
            signatureControl.plotSignature(SignatureData)
        End Set
    End Property

#End Region

End Class
