Imports System.ComponentModel

Public Class UCMainButton : Inherits FSM.UCBase

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lblMenuCaption As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UCMainButton))
        Me.picIcon = New System.Windows.Forms.PictureBox
        Me.lblMenuCaption = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'picIcon
        '
        Me.picIcon.BackgroundImage = CType(resources.GetObject("picIcon.BackgroundImage"), System.Drawing.Image)
        Me.picIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picIcon.Dock = System.Windows.Forms.DockStyle.Left
        Me.picIcon.Location = New System.Drawing.Point(0, 0)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(40, 32)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picIcon.TabIndex = 0
        Me.picIcon.TabStop = False
        '
        'lblMenuCaption
        '
        Me.lblMenuCaption.BackColor = System.Drawing.Color.Transparent
        Me.lblMenuCaption.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMenuCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMenuCaption.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenuCaption.ForeColor = System.Drawing.Color.White
        Me.lblMenuCaption.Location = New System.Drawing.Point(40, 0)
        Me.lblMenuCaption.Name = "lblMenuCaption"
        Me.lblMenuCaption.Size = New System.Drawing.Size(120, 32)
        Me.lblMenuCaption.TabIndex = 3
        Me.lblMenuCaption.Text = "SET IN CODE"
        Me.lblMenuCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UCMainButton
        '
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.Controls.Add(Me.lblMenuCaption)
        Me.Controls.Add(Me.picIcon)
        Me.Name = "UCMainButton"
        Me.Size = New System.Drawing.Size(160, 32)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Event ButtonClicked(ByVal MenuType As Entity.Sys.Enums.MenuTypes)

#Region "Properties"

    <Category("MenuItem"), Description("Menu Caption Text")> _
    Public Property Caption() As String
        Get
            Return Me.lblMenuCaption.Text
        End Get
        Set(ByVal Value As String)
            Me.lblMenuCaption.Text = Value
        End Set
    End Property

    <Category("MenuItem"), Description("Menu Image")> _
        Public Property Image() As Image
        Get
            Return Me.picIcon.Image
        End Get
        Set(ByVal Value As Image)
            Me.picIcon.Image = Value
        End Set
    End Property

    Private _MenuType As Entity.Sys.Enums.MenuTypes = Entity.Sys.Enums.MenuTypes.NONE
    <Category("MenuItem"), Description("Menu Type")> _
       Public Property MenuType() As Entity.Sys.Enums.MenuTypes
        Get
            Return _MenuType
        End Get
        Set(ByVal Value As Entity.Sys.Enums.MenuTypes)
            _MenuType = Value
        End Set
    End Property

    Private _IAmSelected As Boolean = False
    Public Property IAmSelected() As Boolean
        Get
            Return _IAmSelected
        End Get
        Set(ByVal Value As Boolean)
            _IAmSelected = Value
            If Value Then
                State = Entity.Sys.Enums.MenuImageTypes.Selected
            Else
                State = Entity.Sys.Enums.MenuImageTypes.Unselected
            End If
        End Set
    End Property

    Private ReadOnly Property PreviousState() As Entity.Sys.Enums.MenuImageTypes
        Get
            If IAmSelected Then
                Return Entity.Sys.Enums.MenuImageTypes.Selected
            Else
                Return Entity.Sys.Enums.MenuImageTypes.Unselected
            End If
        End Get
    End Property

    Private WriteOnly Property State() As Entity.Sys.Enums.MenuImageTypes
        Set(ByVal Value As Entity.Sys.Enums.MenuImageTypes)
            Select Case Value
                Case Entity.Sys.Enums.MenuImageTypes.NONE
                    Me.picIcon.BackgroundImage = New Bitmap(Entity.Sys.Helper.GetStream("Unselected.bmp"))
                    Me.BackgroundImage = New Bitmap(Entity.Sys.Helper.GetStream("Unselected.bmp"))
                Case Entity.Sys.Enums.MenuImageTypes.Unselected
                    Me.picIcon.BackgroundImage = New Bitmap(Entity.Sys.Helper.GetStream("Unselected.bmp"))
                    Me.BackgroundImage = New Bitmap(Entity.Sys.Helper.GetStream("Unselected.bmp"))
                Case Entity.Sys.Enums.MenuImageTypes.Selected
                    Me.picIcon.BackgroundImage = New Bitmap(Entity.Sys.Helper.GetStream("Selected.bmp"))
                    Me.BackgroundImage = New Bitmap(Entity.Sys.Helper.GetStream("Selected.bmp"))
                Case Entity.Sys.Enums.MenuImageTypes.Hover
                    Me.picIcon.BackgroundImage = New Bitmap(Entity.Sys.Helper.GetStream("Hover.bmp"))
                    Me.BackgroundImage = New Bitmap(Entity.Sys.Helper.GetStream("Hover.bmp"))
            End Select
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub CtrlMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMenuCaption.MouseEnter, picIcon.MouseEnter
        State = Entity.Sys.Enums.MenuImageTypes.Hover
    End Sub

    Private Sub CtrlMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMenuCaption.MouseLeave, picIcon.MouseLeave
        State = PreviousState
    End Sub

    Private Sub CtrlClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMenuCaption.Click, picIcon.Click
        RaiseEvent ButtonClicked(MenuType)
    End Sub

#End Region

End Class
