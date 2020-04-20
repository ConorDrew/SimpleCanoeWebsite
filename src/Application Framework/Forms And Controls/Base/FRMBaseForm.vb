Public Class FRMBaseForm : Inherits System.Windows.Forms.Form : Implements IBaseForm

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
    Friend WithEvents picHeader As System.Windows.Forms.PictureBox

    Friend WithEvents picHeaderCont As System.Windows.Forms.PictureBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMBaseForm))
        Me.picHeader = New System.Windows.Forms.PictureBox()
        Me.picHeaderCont = New System.Windows.Forms.PictureBox()
        CType(Me.picHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHeaderCont, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picHeader
        '
        Me.picHeader.Location = New System.Drawing.Point(0, 0)
        Me.picHeader.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.picHeader.Name = "picHeader"
        Me.picHeader.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.picHeader.Size = New System.Drawing.Size(55, 50)
        Me.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picHeader.TabIndex = 0
        Me.picHeader.TabStop = False
        '
        'picHeaderCont
        '
        Me.picHeaderCont.Dock = System.Windows.Forms.DockStyle.Top
        Me.picHeaderCont.Location = New System.Drawing.Point(0, 0)
        Me.picHeaderCont.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.picHeaderCont.Name = "picHeaderCont"
        Me.picHeaderCont.Size = New System.Drawing.Size(528, 45)
        Me.picHeaderCont.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picHeaderCont.TabIndex = 1
        Me.picHeaderCont.TabStop = False
        '
        'FRMBaseForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(528, 382)
        Me.Controls.Add(Me.picHeader)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FRMBaseForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Field Service Management"
        CType(Me.picHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHeaderCont, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Objects"

#Region "Button Mouse Hover Methods"

    Private _FormButtons As ArrayList = Nothing

    Public Property FormButtons() As ArrayList Implements IBaseForm.FormButtons
        Get
            Return _FormButtons
        End Get
        Set(ByVal Value As ArrayList)
            _FormButtons = Value
        End Set
    End Property

    Public Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs, ByVal frm As IForm) Implements IBaseForm.LoadForm
        _FormButtons = New ArrayList
        If IsRFT Then
            Me.picHeader.Image = Global.FSM.My.Resources.Resources.RFT
        ElseIf IsGasway Then
            Me.picHeader.Image = Global.FSM.My.Resources.Resources.GaswayHO
        ElseIf IsBlueflame Then
            Me.picHeader.Image = Global.FSM.My.Resources.Resources.Blueflame
        End If

        LoopControls(frm)

        SetupButtonMouseOvers()
    End Sub

    'Added to allow forms that do not implement IForm
    Public Sub LoadForm(ByVal frm As Form) Implements IBaseForm.LoadForm
        _FormButtons = New ArrayList
        If IsRFT Then
            Me.picHeader.Image = Global.FSM.My.Resources.Resources.RFT
        ElseIf IsGasway Then
            Me.picHeader.Image = Global.FSM.My.Resources.Resources.GaswayHO
        ElseIf IsBlueflame Then
            Me.picHeader.Image = Global.FSM.My.Resources.Resources.Blueflame
        End If

        LoopControls(frm)

        SetupButtonMouseOvers()
    End Sub

    Private Sub LoopControls(ByVal controlToLoop As Control) Implements IBaseForm.LoopControls
        For Each control As Control In controlToLoop.Controls
            If control.GetType.Name = "TabControl" Then
                LoopControls(control)
            ElseIf control.GetType.Name = "TabPage" Then
                CType(control, TabPage).BackColor = Color.White
                LoopControls(control)
            ElseIf control.GetType.Name = "GroupBox" Then
                CType(control, GroupBox).FlatStyle = FlatStyle.System
                LoopControls(control)
            ElseIf control.GetType.Name = "Panel" Then
                LoopControls(control)
            ElseIf control.GetType.Name = "Button" Then
                If CType(control, Button).Name.Substring(0, 5) = "btnxx" Then
                Else
                    CType(control, Button).FlatStyle = FlatStyle.Standard
                    CType(control, Button).Cursor = Cursors.Hand
                    CType(control, Button).AccessibleDescription = CType(control, Button).Text
                    CType(control, Button).UseVisualStyleBackColor = False
                    CType(control, Button).BackColor = System.Drawing.SystemColors.Control
                    FormButtons.Add(control)
                End If

            ElseIf control.GetType.Name = "ComboBox" Then
                If CType(control, ComboBox).Name = "cbotypeWiz" Then
                Else

                    CType(control, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
                    CType(control, ComboBox).Cursor = Cursors.Hand
                End If

            ElseIf control.GetType.Name = "CheckBox" Then
                CType(control, CheckBox).FlatStyle = FlatStyle.System
                CType(control, CheckBox).Cursor = Cursors.Hand
            ElseIf control.GetType.Name = "RadioButton" Then
                CType(control, RadioButton).FlatStyle = FlatStyle.System
                CType(control, RadioButton).Cursor = Cursors.Hand
            ElseIf control.GetType.Name = "NumericUpDown" Then
                CType(control, NumericUpDown).Cursor = Cursors.Hand
            ElseIf control.GetType.Name = "DataGrid" Then
                Entity.Sys.Helper.SetUpDataGrid(CType(control, DataGrid))
                Dim tStyle As DataGridTableStyle = CType(control, DataGrid).TableStyles(0)
                tStyle.ReadOnly = True
                tStyle.MappingName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
                CType(control, DataGrid).TableStyles.Add(tStyle)
            ElseIf control.GetType.Name = "UCButton" Then
                CType(control, Button).AccessibleDescription = CType(control, Button).Text
                FormButtons.Add(control)
            Else
                If control.GetType().IsSubclassOf(GetType(UCBase)) Then
                    LoopControls(CType(control, UCBase))
                End If
            End If
        Next
    End Sub

    Public Sub SetupButtonMouseOvers() Implements IBaseForm.SetupButtonMouseOvers
        For Each btn As Object In FormButtons
            AddHandler CType(btn, Button).MouseHover, AddressOf CreateHover
        Next
    End Sub

    Private Sub CreateHover(ByVal sender As Object, ByVal e As System.EventArgs) Implements IBaseForm.CreateHover
        Entity.Sys.Helper.Setup_Button(sender, CType(sender, Button).AccessibleDescription)
    End Sub

#End Region

#Region "Form Properties"

    Private _FormParameters As Array = Nothing

    Public WriteOnly Property SetFormParameters() As Array Implements IBaseForm.SetFormParameters
        Set(ByVal Value As Array)
            _FormParameters = Value
        End Set
    End Property

    Public ReadOnly Property GetParameter(Optional ByVal indexOfArrayToGet As Integer = 0) As Object Implements IBaseForm.GetParameter
        Get
            If _FormParameters Is Nothing Then
                Return Nothing
            End If
            If _FormParameters.Length = 0 Then
                Return Nothing
            End If
            If indexOfArrayToGet > _FormParameters.Length - 1 Then
                Return Nothing
            End If

            Return _FormParameters(indexOfArrayToGet)
        End Get
    End Property

    Public ReadOnly Property GetParameterCount() As Integer Implements IBaseForm.GetParameterCount
        Get
            Return _FormParameters.Length
        End Get
    End Property

#End Region

#End Region

#Region "Events"

    Private Sub picHeader_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles picHeader.MouseHover
        Dim hoverToolTip As New ToolTip
        hoverToolTip.SetToolTip(Me.picHeader, TheSystem.Description)
    End Sub

#End Region

End Class