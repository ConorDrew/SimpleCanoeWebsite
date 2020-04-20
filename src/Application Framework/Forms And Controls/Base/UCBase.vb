Public Class UCBase : Inherits System.Windows.Forms.UserControl

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'CTRLBase
        '
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CTRLBase"

    End Sub

#End Region

#Region "Properties"

    Private _FormButtons As ArrayList = Nothing
    Public Property FormButtons() As ArrayList
        Get
            Return _FormButtons
        End Get
        Set(ByVal Value As ArrayList)
            _FormButtons = Value
        End Set
    End Property

#End Region

#Region "Functions"

    Public Sub LoadBaseControl(ByVal ctrl As Control)
        Me.Dock = DockStyle.Fill

        _FormButtons = New ArrayList

        LoopControls(ctrl)

        SetupButtonMouseOvers()
    End Sub

    Private Sub LoopControls(ByVal controlToLoop As Control)
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
                CType(control, Button).FlatStyle = FlatStyle.Standard
                CType(control, Button).Cursor = Cursors.Hand
                CType(control, Button).UseVisualStyleBackColor = False
                CType(control, Button).BackColor = System.Drawing.SystemColors.Control
                CType(control, Button).AccessibleDescription = CType(control, Button).Text
                FormButtons.Add(control)
            ElseIf control.GetType.Name = "ComboBox" Then
                CType(control, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
                CType(control, ComboBox).Cursor = Cursors.Hand
            ElseIf control.GetType.Name = "CheckBox" Then
                CType(control, CheckBox).FlatStyle = FlatStyle.System
                CType(control, CheckBox).Cursor = Cursors.Hand
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

    Public Sub SetupButtonMouseOvers()
        For Each btn As Object In FormButtons
            AddHandler CType(btn, Button).MouseHover, AddressOf CreateHover
        Next
    End Sub

    Private Sub CreateHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Entity.Sys.Helper.Setup_Button(sender, CType(sender, Button).AccessibleDescription)
    End Sub

#End Region

End Class
