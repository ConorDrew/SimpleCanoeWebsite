Public Class DLGVisitAdditionalWorkSheet : Inherits FSM.FRMBaseForm

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
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    Friend WithEvents lblcbo1 As System.Windows.Forms.Label
    Friend WithEvents lbltxt1 As System.Windows.Forms.Label
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents cbo1 As System.Windows.Forms.ComboBox
    Friend WithEvents lbltxt2 As System.Windows.Forms.Label
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents cbo2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo2 As System.Windows.Forms.Label
    Friend WithEvents cbo3 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo3 As System.Windows.Forms.Label
    Friend WithEvents cbo4 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo4 As System.Windows.Forms.Label
    Friend WithEvents cbo5 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo5 As System.Windows.Forms.Label
    Friend WithEvents cbo6 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo6 As System.Windows.Forms.Label
    Friend WithEvents cbo7 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo7 As System.Windows.Forms.Label
    Friend WithEvents cbo8 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo8 As System.Windows.Forms.Label
    Friend WithEvents cbo9 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo9 As System.Windows.Forms.Label
    Friend WithEvents cbo10 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo10 As System.Windows.Forms.Label
    Friend WithEvents cbo11 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo11 As System.Windows.Forms.Label
    Friend WithEvents cbo12 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo12 As System.Windows.Forms.Label
    Friend WithEvents cbo13 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo13 As System.Windows.Forms.Label
    Friend WithEvents cbo14 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo14 As System.Windows.Forms.Label
    Friend WithEvents cbo15 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo15 As System.Windows.Forms.Label
    Friend WithEvents cbo16 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo16 As System.Windows.Forms.Label
    Friend WithEvents cbo17 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo17 As System.Windows.Forms.Label
    Friend WithEvents cbo18 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo18 As System.Windows.Forms.Label
    Friend WithEvents lbltxt3 As System.Windows.Forms.Label
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents lbltxt4 As System.Windows.Forms.Label
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents lbltxt5 As System.Windows.Forms.Label
    Friend WithEvents txt5 As System.Windows.Forms.TextBox
    Friend WithEvents lbltxt6 As System.Windows.Forms.Label
    Friend WithEvents txt6 As System.Windows.Forms.TextBox
    Friend WithEvents lbltxt7 As System.Windows.Forms.Label
    Friend WithEvents txt7 As System.Windows.Forms.TextBox
    Friend WithEvents lbltxt8 As System.Windows.Forms.Label
    Friend WithEvents txt8 As System.Windows.Forms.TextBox
    Friend WithEvents lbltxt9 As System.Windows.Forms.Label
    Friend WithEvents txt9 As System.Windows.Forms.TextBox
    Friend WithEvents lbltxt10 As System.Windows.Forms.Label
    Friend WithEvents txt10 As System.Windows.Forms.TextBox
    Friend WithEvents cbo19 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo19 As System.Windows.Forms.Label
    Friend WithEvents cbo20 As System.Windows.Forms.ComboBox
    Friend WithEvents lblcbo20 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbltxt11 As System.Windows.Forms.Label
    Friend WithEvents txt11 As System.Windows.Forms.TextBox
    Friend WithEvents lbltxt12 As System.Windows.Forms.Label
    Friend WithEvents txt12 As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblcbo1 = New System.Windows.Forms.Label()
        Me.lbltxt1 = New System.Windows.Forms.Label()
        Me.txt1 = New System.Windows.Forms.TextBox()
        Me.cbo1 = New System.Windows.Forms.ComboBox()
        Me.lbltxt2 = New System.Windows.Forms.Label()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.cbo2 = New System.Windows.Forms.ComboBox()
        Me.lblcbo2 = New System.Windows.Forms.Label()
        Me.cbo3 = New System.Windows.Forms.ComboBox()
        Me.lblcbo3 = New System.Windows.Forms.Label()
        Me.cbo4 = New System.Windows.Forms.ComboBox()
        Me.lblcbo4 = New System.Windows.Forms.Label()
        Me.cbo5 = New System.Windows.Forms.ComboBox()
        Me.lblcbo5 = New System.Windows.Forms.Label()
        Me.cbo6 = New System.Windows.Forms.ComboBox()
        Me.lblcbo6 = New System.Windows.Forms.Label()
        Me.cbo7 = New System.Windows.Forms.ComboBox()
        Me.lblcbo7 = New System.Windows.Forms.Label()
        Me.cbo8 = New System.Windows.Forms.ComboBox()
        Me.lblcbo8 = New System.Windows.Forms.Label()
        Me.cbo9 = New System.Windows.Forms.ComboBox()
        Me.lblcbo9 = New System.Windows.Forms.Label()
        Me.cbo10 = New System.Windows.Forms.ComboBox()
        Me.lblcbo10 = New System.Windows.Forms.Label()
        Me.cbo11 = New System.Windows.Forms.ComboBox()
        Me.lblcbo11 = New System.Windows.Forms.Label()
        Me.cbo12 = New System.Windows.Forms.ComboBox()
        Me.lblcbo12 = New System.Windows.Forms.Label()
        Me.cbo13 = New System.Windows.Forms.ComboBox()
        Me.lblcbo13 = New System.Windows.Forms.Label()
        Me.cbo14 = New System.Windows.Forms.ComboBox()
        Me.lblcbo14 = New System.Windows.Forms.Label()
        Me.cbo15 = New System.Windows.Forms.ComboBox()
        Me.lblcbo15 = New System.Windows.Forms.Label()
        Me.cbo16 = New System.Windows.Forms.ComboBox()
        Me.lblcbo16 = New System.Windows.Forms.Label()
        Me.cbo17 = New System.Windows.Forms.ComboBox()
        Me.lblcbo17 = New System.Windows.Forms.Label()
        Me.cbo18 = New System.Windows.Forms.ComboBox()
        Me.lblcbo18 = New System.Windows.Forms.Label()
        Me.lbltxt3 = New System.Windows.Forms.Label()
        Me.txt3 = New System.Windows.Forms.TextBox()
        Me.lbltxt4 = New System.Windows.Forms.Label()
        Me.txt4 = New System.Windows.Forms.TextBox()
        Me.lbltxt5 = New System.Windows.Forms.Label()
        Me.txt5 = New System.Windows.Forms.TextBox()
        Me.lbltxt6 = New System.Windows.Forms.Label()
        Me.txt6 = New System.Windows.Forms.TextBox()
        Me.lbltxt7 = New System.Windows.Forms.Label()
        Me.txt7 = New System.Windows.Forms.TextBox()
        Me.lbltxt8 = New System.Windows.Forms.Label()
        Me.txt8 = New System.Windows.Forms.TextBox()
        Me.lbltxt9 = New System.Windows.Forms.Label()
        Me.txt9 = New System.Windows.Forms.TextBox()
        Me.lbltxt10 = New System.Windows.Forms.Label()
        Me.txt10 = New System.Windows.Forms.TextBox()
        Me.cbo19 = New System.Windows.Forms.ComboBox()
        Me.lblcbo19 = New System.Windows.Forms.Label()
        Me.cbo20 = New System.Windows.Forms.ComboBox()
        Me.lblcbo20 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltxt11 = New System.Windows.Forms.Label()
        Me.txt11 = New System.Windows.Forms.TextBox()
        Me.lbltxt12 = New System.Windows.Forms.Label()
        Me.txt12 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(12, 526)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 38
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(902, 526)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 39
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblcbo1
        '
        Me.lblcbo1.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo1.Location = New System.Drawing.Point(8, 82)
        Me.lblcbo1.Name = "lblcbo1"
        Me.lblcbo1.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo1.TabIndex = 22
        Me.lblcbo1.Text = "Heat Input KW/h"
        '
        'lbltxt1
        '
        Me.lbltxt1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt1.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt1.Location = New System.Drawing.Point(508, 81)
        Me.lbltxt1.Name = "lbltxt1"
        Me.lbltxt1.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt1.TabIndex = 48
        Me.lbltxt1.Text = "Fuel"
        '
        'txt1
        '
        Me.txt1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt1.Location = New System.Drawing.Point(786, 78)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(178, 21)
        Me.txt1.TabIndex = 23
        '
        'cbo1
        '
        Me.cbo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo1.Location = New System.Drawing.Point(310, 79)
        Me.cbo1.Name = "cbo1"
        Me.cbo1.Size = New System.Drawing.Size(178, 21)
        Me.cbo1.TabIndex = 47
        '
        'lbltxt2
        '
        Me.lbltxt2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt2.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt2.Location = New System.Drawing.Point(508, 108)
        Me.lbltxt2.Name = "lbltxt2"
        Me.lbltxt2.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt2.TabIndex = 50
        Me.lbltxt2.Text = "Fuel"
        '
        'txt2
        '
        Me.txt2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt2.Location = New System.Drawing.Point(786, 105)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(178, 21)
        Me.txt2.TabIndex = 49
        '
        'cbo2
        '
        Me.cbo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo2.Location = New System.Drawing.Point(310, 106)
        Me.cbo2.Name = "cbo2"
        Me.cbo2.Size = New System.Drawing.Size(178, 21)
        Me.cbo2.TabIndex = 52
        '
        'lblcbo2
        '
        Me.lblcbo2.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo2.Location = New System.Drawing.Point(8, 109)
        Me.lblcbo2.Name = "lblcbo2"
        Me.lblcbo2.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo2.TabIndex = 51
        Me.lblcbo2.Text = "Heat Input KW/h"
        '
        'cbo3
        '
        Me.cbo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo3.Location = New System.Drawing.Point(310, 133)
        Me.cbo3.Name = "cbo3"
        Me.cbo3.Size = New System.Drawing.Size(178, 21)
        Me.cbo3.TabIndex = 54
        '
        'lblcbo3
        '
        Me.lblcbo3.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo3.Location = New System.Drawing.Point(8, 136)
        Me.lblcbo3.Name = "lblcbo3"
        Me.lblcbo3.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo3.TabIndex = 53
        Me.lblcbo3.Text = "Heat Input KW/h"
        '
        'cbo4
        '
        Me.cbo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo4.Location = New System.Drawing.Point(310, 160)
        Me.cbo4.Name = "cbo4"
        Me.cbo4.Size = New System.Drawing.Size(178, 21)
        Me.cbo4.TabIndex = 56
        '
        'lblcbo4
        '
        Me.lblcbo4.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo4.Location = New System.Drawing.Point(8, 163)
        Me.lblcbo4.Name = "lblcbo4"
        Me.lblcbo4.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo4.TabIndex = 55
        Me.lblcbo4.Text = "Heat Input KW/h"
        '
        'cbo5
        '
        Me.cbo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo5.Location = New System.Drawing.Point(310, 187)
        Me.cbo5.Name = "cbo5"
        Me.cbo5.Size = New System.Drawing.Size(178, 21)
        Me.cbo5.TabIndex = 58
        '
        'lblcbo5
        '
        Me.lblcbo5.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo5.Location = New System.Drawing.Point(8, 190)
        Me.lblcbo5.Name = "lblcbo5"
        Me.lblcbo5.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo5.TabIndex = 57
        Me.lblcbo5.Text = "Heat Input KW/h"
        '
        'cbo6
        '
        Me.cbo6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo6.Location = New System.Drawing.Point(310, 214)
        Me.cbo6.Name = "cbo6"
        Me.cbo6.Size = New System.Drawing.Size(178, 21)
        Me.cbo6.TabIndex = 60
        '
        'lblcbo6
        '
        Me.lblcbo6.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo6.Location = New System.Drawing.Point(8, 217)
        Me.lblcbo6.Name = "lblcbo6"
        Me.lblcbo6.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo6.TabIndex = 59
        Me.lblcbo6.Text = "Heat Input KW/h"
        '
        'cbo7
        '
        Me.cbo7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo7.Location = New System.Drawing.Point(310, 241)
        Me.cbo7.Name = "cbo7"
        Me.cbo7.Size = New System.Drawing.Size(178, 21)
        Me.cbo7.TabIndex = 62
        '
        'lblcbo7
        '
        Me.lblcbo7.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo7.Location = New System.Drawing.Point(8, 244)
        Me.lblcbo7.Name = "lblcbo7"
        Me.lblcbo7.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo7.TabIndex = 61
        Me.lblcbo7.Text = "Heat Input KW/h"
        '
        'cbo8
        '
        Me.cbo8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo8.Location = New System.Drawing.Point(310, 268)
        Me.cbo8.Name = "cbo8"
        Me.cbo8.Size = New System.Drawing.Size(178, 21)
        Me.cbo8.TabIndex = 64
        '
        'lblcbo8
        '
        Me.lblcbo8.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo8.Location = New System.Drawing.Point(8, 271)
        Me.lblcbo8.Name = "lblcbo8"
        Me.lblcbo8.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo8.TabIndex = 63
        Me.lblcbo8.Text = "Heat Input KW/h"
        '
        'cbo9
        '
        Me.cbo9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo9.Location = New System.Drawing.Point(310, 295)
        Me.cbo9.Name = "cbo9"
        Me.cbo9.Size = New System.Drawing.Size(178, 21)
        Me.cbo9.TabIndex = 66
        '
        'lblcbo9
        '
        Me.lblcbo9.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo9.Location = New System.Drawing.Point(8, 298)
        Me.lblcbo9.Name = "lblcbo9"
        Me.lblcbo9.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo9.TabIndex = 65
        Me.lblcbo9.Text = "Heat Input KW/h"
        '
        'cbo10
        '
        Me.cbo10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo10.Location = New System.Drawing.Point(310, 322)
        Me.cbo10.Name = "cbo10"
        Me.cbo10.Size = New System.Drawing.Size(178, 21)
        Me.cbo10.TabIndex = 68
        '
        'lblcbo10
        '
        Me.lblcbo10.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo10.Location = New System.Drawing.Point(8, 325)
        Me.lblcbo10.Name = "lblcbo10"
        Me.lblcbo10.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo10.TabIndex = 67
        Me.lblcbo10.Text = "Heat Input KW/h"
        '
        'cbo11
        '
        Me.cbo11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo11.Location = New System.Drawing.Point(310, 349)
        Me.cbo11.Name = "cbo11"
        Me.cbo11.Size = New System.Drawing.Size(178, 21)
        Me.cbo11.TabIndex = 70
        '
        'lblcbo11
        '
        Me.lblcbo11.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo11.Location = New System.Drawing.Point(8, 352)
        Me.lblcbo11.Name = "lblcbo11"
        Me.lblcbo11.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo11.TabIndex = 69
        Me.lblcbo11.Text = "Heat Input KW/h"
        '
        'cbo12
        '
        Me.cbo12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo12.Location = New System.Drawing.Point(310, 376)
        Me.cbo12.Name = "cbo12"
        Me.cbo12.Size = New System.Drawing.Size(178, 21)
        Me.cbo12.TabIndex = 72
        '
        'lblcbo12
        '
        Me.lblcbo12.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo12.Location = New System.Drawing.Point(8, 379)
        Me.lblcbo12.Name = "lblcbo12"
        Me.lblcbo12.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo12.TabIndex = 71
        Me.lblcbo12.Text = "Heat Input KW/h"
        '
        'cbo13
        '
        Me.cbo13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo13.Location = New System.Drawing.Point(310, 403)
        Me.cbo13.Name = "cbo13"
        Me.cbo13.Size = New System.Drawing.Size(178, 21)
        Me.cbo13.TabIndex = 74
        '
        'lblcbo13
        '
        Me.lblcbo13.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo13.Location = New System.Drawing.Point(8, 406)
        Me.lblcbo13.Name = "lblcbo13"
        Me.lblcbo13.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo13.TabIndex = 73
        Me.lblcbo13.Text = "Heat Input KW/h"
        '
        'cbo14
        '
        Me.cbo14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo14.Location = New System.Drawing.Point(310, 430)
        Me.cbo14.Name = "cbo14"
        Me.cbo14.Size = New System.Drawing.Size(178, 21)
        Me.cbo14.TabIndex = 76
        '
        'lblcbo14
        '
        Me.lblcbo14.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo14.Location = New System.Drawing.Point(8, 433)
        Me.lblcbo14.Name = "lblcbo14"
        Me.lblcbo14.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo14.TabIndex = 75
        Me.lblcbo14.Text = "Heat Input KW/h"
        '
        'cbo15
        '
        Me.cbo15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo15.Location = New System.Drawing.Point(310, 460)
        Me.cbo15.Name = "cbo15"
        Me.cbo15.Size = New System.Drawing.Size(178, 21)
        Me.cbo15.TabIndex = 78
        '
        'lblcbo15
        '
        Me.lblcbo15.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo15.Location = New System.Drawing.Point(8, 463)
        Me.lblcbo15.Name = "lblcbo15"
        Me.lblcbo15.Size = New System.Drawing.Size(285, 23)
        Me.lblcbo15.TabIndex = 77
        Me.lblcbo15.Text = "Heat Input KW/h"
        '
        'cbo16
        '
        Me.cbo16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo16.Location = New System.Drawing.Point(310, 487)
        Me.cbo16.Name = "cbo16"
        Me.cbo16.Size = New System.Drawing.Size(178, 21)
        Me.cbo16.TabIndex = 80
        '
        'lblcbo16
        '
        Me.lblcbo16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcbo16.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo16.Location = New System.Drawing.Point(8, 491)
        Me.lblcbo16.Name = "lblcbo16"
        Me.lblcbo16.Size = New System.Drawing.Size(272, 23)
        Me.lblcbo16.TabIndex = 79
        Me.lblcbo16.Text = "Heat Input KW/h"
        '
        'cbo17
        '
        Me.cbo17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo17.Location = New System.Drawing.Point(786, 402)
        Me.cbo17.Name = "cbo17"
        Me.cbo17.Size = New System.Drawing.Size(178, 21)
        Me.cbo17.TabIndex = 82
        '
        'lblcbo17
        '
        Me.lblcbo17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcbo17.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo17.Location = New System.Drawing.Point(508, 406)
        Me.lblcbo17.Name = "lblcbo17"
        Me.lblcbo17.Size = New System.Drawing.Size(272, 23)
        Me.lblcbo17.TabIndex = 81
        Me.lblcbo17.Text = "Heat Input KW/h"
        '
        'cbo18
        '
        Me.cbo18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo18.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo18.Location = New System.Drawing.Point(786, 429)
        Me.cbo18.Name = "cbo18"
        Me.cbo18.Size = New System.Drawing.Size(178, 21)
        Me.cbo18.TabIndex = 84
        '
        'lblcbo18
        '
        Me.lblcbo18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcbo18.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo18.Location = New System.Drawing.Point(508, 433)
        Me.lblcbo18.Name = "lblcbo18"
        Me.lblcbo18.Size = New System.Drawing.Size(272, 23)
        Me.lblcbo18.TabIndex = 83
        Me.lblcbo18.Text = "Heat Input KW/h"
        '
        'lbltxt3
        '
        Me.lbltxt3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt3.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt3.Location = New System.Drawing.Point(508, 135)
        Me.lbltxt3.Name = "lbltxt3"
        Me.lbltxt3.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt3.TabIndex = 86
        Me.lbltxt3.Text = "Fuel"
        '
        'txt3
        '
        Me.txt3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt3.Location = New System.Drawing.Point(786, 132)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(178, 21)
        Me.txt3.TabIndex = 85
        '
        'lbltxt4
        '
        Me.lbltxt4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt4.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt4.Location = New System.Drawing.Point(508, 162)
        Me.lbltxt4.Name = "lbltxt4"
        Me.lbltxt4.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt4.TabIndex = 88
        Me.lbltxt4.Text = "Fuel"
        '
        'txt4
        '
        Me.txt4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt4.Location = New System.Drawing.Point(786, 159)
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(178, 21)
        Me.txt4.TabIndex = 87
        '
        'lbltxt5
        '
        Me.lbltxt5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt5.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt5.Location = New System.Drawing.Point(508, 189)
        Me.lbltxt5.Name = "lbltxt5"
        Me.lbltxt5.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt5.TabIndex = 90
        Me.lbltxt5.Text = "Fuel"
        '
        'txt5
        '
        Me.txt5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt5.Location = New System.Drawing.Point(786, 186)
        Me.txt5.Name = "txt5"
        Me.txt5.Size = New System.Drawing.Size(178, 21)
        Me.txt5.TabIndex = 89
        '
        'lbltxt6
        '
        Me.lbltxt6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt6.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt6.Location = New System.Drawing.Point(508, 216)
        Me.lbltxt6.Name = "lbltxt6"
        Me.lbltxt6.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt6.TabIndex = 92
        Me.lbltxt6.Text = "Fuel"
        '
        'txt6
        '
        Me.txt6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt6.Location = New System.Drawing.Point(786, 213)
        Me.txt6.Name = "txt6"
        Me.txt6.Size = New System.Drawing.Size(178, 21)
        Me.txt6.TabIndex = 91
        '
        'lbltxt7
        '
        Me.lbltxt7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt7.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt7.Location = New System.Drawing.Point(508, 243)
        Me.lbltxt7.Name = "lbltxt7"
        Me.lbltxt7.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt7.TabIndex = 94
        Me.lbltxt7.Text = "Fuel"
        '
        'txt7
        '
        Me.txt7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt7.Location = New System.Drawing.Point(786, 240)
        Me.txt7.Name = "txt7"
        Me.txt7.Size = New System.Drawing.Size(178, 21)
        Me.txt7.TabIndex = 93
        '
        'lbltxt8
        '
        Me.lbltxt8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt8.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt8.Location = New System.Drawing.Point(508, 270)
        Me.lbltxt8.Name = "lbltxt8"
        Me.lbltxt8.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt8.TabIndex = 96
        Me.lbltxt8.Text = "Fuel"
        '
        'txt8
        '
        Me.txt8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt8.Location = New System.Drawing.Point(786, 267)
        Me.txt8.Name = "txt8"
        Me.txt8.Size = New System.Drawing.Size(178, 21)
        Me.txt8.TabIndex = 95
        '
        'lbltxt9
        '
        Me.lbltxt9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt9.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt9.Location = New System.Drawing.Point(508, 297)
        Me.lbltxt9.Name = "lbltxt9"
        Me.lbltxt9.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt9.TabIndex = 98
        Me.lbltxt9.Text = "Fuel"
        '
        'txt9
        '
        Me.txt9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt9.Location = New System.Drawing.Point(786, 294)
        Me.txt9.Name = "txt9"
        Me.txt9.Size = New System.Drawing.Size(178, 21)
        Me.txt9.TabIndex = 97
        '
        'lbltxt10
        '
        Me.lbltxt10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt10.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt10.Location = New System.Drawing.Point(508, 324)
        Me.lbltxt10.Name = "lbltxt10"
        Me.lbltxt10.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt10.TabIndex = 100
        Me.lbltxt10.Text = "Fuel"
        '
        'txt10
        '
        Me.txt10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt10.Location = New System.Drawing.Point(786, 321)
        Me.txt10.Name = "txt10"
        Me.txt10.Size = New System.Drawing.Size(178, 21)
        Me.txt10.TabIndex = 99
        '
        'cbo19
        '
        Me.cbo19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo19.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo19.Location = New System.Drawing.Point(786, 456)
        Me.cbo19.Name = "cbo19"
        Me.cbo19.Size = New System.Drawing.Size(178, 21)
        Me.cbo19.TabIndex = 102
        '
        'lblcbo19
        '
        Me.lblcbo19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcbo19.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo19.Location = New System.Drawing.Point(508, 459)
        Me.lblcbo19.Name = "lblcbo19"
        Me.lblcbo19.Size = New System.Drawing.Size(272, 23)
        Me.lblcbo19.TabIndex = 101
        Me.lblcbo19.Text = "Heat Input KW/h"
        '
        'cbo20
        '
        Me.cbo20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo20.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo20.Location = New System.Drawing.Point(786, 483)
        Me.cbo20.Name = "cbo20"
        Me.cbo20.Size = New System.Drawing.Size(178, 21)
        Me.cbo20.TabIndex = 104
        '
        'lblcbo20
        '
        Me.lblcbo20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcbo20.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcbo20.Location = New System.Drawing.Point(508, 486)
        Me.lblcbo20.Name = "lblcbo20"
        Me.lblcbo20.Size = New System.Drawing.Size(272, 23)
        Me.lblcbo20.TabIndex = 103
        Me.lblcbo20.Text = "Heat Input KW/h"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(310, 38)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(654, 21)
        Me.cboType.TabIndex = 106
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 23)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Worsheet type"
        '
        'lbltxt11
        '
        Me.lbltxt11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt11.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt11.Location = New System.Drawing.Point(508, 352)
        Me.lbltxt11.Name = "lbltxt11"
        Me.lbltxt11.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt11.TabIndex = 109
        Me.lbltxt11.Text = "Fuel"
        '
        'txt11
        '
        Me.txt11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt11.Location = New System.Drawing.Point(786, 349)
        Me.txt11.Name = "txt11"
        Me.txt11.Size = New System.Drawing.Size(178, 21)
        Me.txt11.TabIndex = 108
        '
        'lbltxt12
        '
        Me.lbltxt12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxt12.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxt12.Location = New System.Drawing.Point(508, 379)
        Me.lbltxt12.Name = "lbltxt12"
        Me.lbltxt12.Size = New System.Drawing.Size(272, 23)
        Me.lbltxt12.TabIndex = 111
        Me.lbltxt12.Text = "Fuel"
        '
        'txt12
        '
        Me.txt12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt12.Location = New System.Drawing.Point(786, 376)
        Me.txt12.Name = "txt12"
        Me.txt12.Size = New System.Drawing.Size(178, 21)
        Me.txt12.TabIndex = 110
        '
        'DLGVisitAdditionalWorkSheet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(989, 561)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbltxt12)
        Me.Controls.Add(Me.txt12)
        Me.Controls.Add(Me.lbltxt11)
        Me.Controls.Add(Me.txt11)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbo20)
        Me.Controls.Add(Me.lblcbo20)
        Me.Controls.Add(Me.cbo19)
        Me.Controls.Add(Me.lblcbo19)
        Me.Controls.Add(Me.lbltxt10)
        Me.Controls.Add(Me.txt10)
        Me.Controls.Add(Me.lbltxt9)
        Me.Controls.Add(Me.txt9)
        Me.Controls.Add(Me.lbltxt8)
        Me.Controls.Add(Me.txt8)
        Me.Controls.Add(Me.lbltxt7)
        Me.Controls.Add(Me.txt7)
        Me.Controls.Add(Me.lbltxt6)
        Me.Controls.Add(Me.txt6)
        Me.Controls.Add(Me.lbltxt5)
        Me.Controls.Add(Me.txt5)
        Me.Controls.Add(Me.lbltxt4)
        Me.Controls.Add(Me.txt4)
        Me.Controls.Add(Me.lbltxt3)
        Me.Controls.Add(Me.txt3)
        Me.Controls.Add(Me.cbo18)
        Me.Controls.Add(Me.lblcbo18)
        Me.Controls.Add(Me.cbo17)
        Me.Controls.Add(Me.lblcbo17)
        Me.Controls.Add(Me.cbo16)
        Me.Controls.Add(Me.lblcbo16)
        Me.Controls.Add(Me.cbo15)
        Me.Controls.Add(Me.lblcbo15)
        Me.Controls.Add(Me.cbo14)
        Me.Controls.Add(Me.lblcbo14)
        Me.Controls.Add(Me.cbo13)
        Me.Controls.Add(Me.lblcbo13)
        Me.Controls.Add(Me.cbo12)
        Me.Controls.Add(Me.lblcbo12)
        Me.Controls.Add(Me.cbo11)
        Me.Controls.Add(Me.lblcbo11)
        Me.Controls.Add(Me.cbo10)
        Me.Controls.Add(Me.lblcbo10)
        Me.Controls.Add(Me.cbo9)
        Me.Controls.Add(Me.lblcbo9)
        Me.Controls.Add(Me.cbo8)
        Me.Controls.Add(Me.lblcbo8)
        Me.Controls.Add(Me.cbo7)
        Me.Controls.Add(Me.lblcbo7)
        Me.Controls.Add(Me.cbo6)
        Me.Controls.Add(Me.lblcbo6)
        Me.Controls.Add(Me.cbo5)
        Me.Controls.Add(Me.lblcbo5)
        Me.Controls.Add(Me.cbo4)
        Me.Controls.Add(Me.lblcbo4)
        Me.Controls.Add(Me.cbo3)
        Me.Controls.Add(Me.lblcbo3)
        Me.Controls.Add(Me.cbo2)
        Me.Controls.Add(Me.lblcbo2)
        Me.Controls.Add(Me.lbltxt2)
        Me.Controls.Add(Me.txt2)
        Me.Controls.Add(Me.lbltxt1)
        Me.Controls.Add(Me.cbo1)
        Me.Controls.Add(Me.txt1)
        Me.Controls.Add(Me.lblcbo1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.Name = "DLGVisitAdditionalWorkSheet"
        Me.Text = "Appliance Work Sheet"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.lblcbo1, 0)
        Me.Controls.SetChildIndex(Me.txt1, 0)
        Me.Controls.SetChildIndex(Me.cbo1, 0)
        Me.Controls.SetChildIndex(Me.lbltxt1, 0)
        Me.Controls.SetChildIndex(Me.txt2, 0)
        Me.Controls.SetChildIndex(Me.lbltxt2, 0)
        Me.Controls.SetChildIndex(Me.lblcbo2, 0)
        Me.Controls.SetChildIndex(Me.cbo2, 0)
        Me.Controls.SetChildIndex(Me.lblcbo3, 0)
        Me.Controls.SetChildIndex(Me.cbo3, 0)
        Me.Controls.SetChildIndex(Me.lblcbo4, 0)
        Me.Controls.SetChildIndex(Me.cbo4, 0)
        Me.Controls.SetChildIndex(Me.lblcbo5, 0)
        Me.Controls.SetChildIndex(Me.cbo5, 0)
        Me.Controls.SetChildIndex(Me.lblcbo6, 0)
        Me.Controls.SetChildIndex(Me.cbo6, 0)
        Me.Controls.SetChildIndex(Me.lblcbo7, 0)
        Me.Controls.SetChildIndex(Me.cbo7, 0)
        Me.Controls.SetChildIndex(Me.lblcbo8, 0)
        Me.Controls.SetChildIndex(Me.cbo8, 0)
        Me.Controls.SetChildIndex(Me.lblcbo9, 0)
        Me.Controls.SetChildIndex(Me.cbo9, 0)
        Me.Controls.SetChildIndex(Me.lblcbo10, 0)
        Me.Controls.SetChildIndex(Me.cbo10, 0)
        Me.Controls.SetChildIndex(Me.lblcbo11, 0)
        Me.Controls.SetChildIndex(Me.cbo11, 0)
        Me.Controls.SetChildIndex(Me.lblcbo12, 0)
        Me.Controls.SetChildIndex(Me.cbo12, 0)
        Me.Controls.SetChildIndex(Me.lblcbo13, 0)
        Me.Controls.SetChildIndex(Me.cbo13, 0)
        Me.Controls.SetChildIndex(Me.lblcbo14, 0)
        Me.Controls.SetChildIndex(Me.cbo14, 0)
        Me.Controls.SetChildIndex(Me.lblcbo15, 0)
        Me.Controls.SetChildIndex(Me.cbo15, 0)
        Me.Controls.SetChildIndex(Me.lblcbo16, 0)
        Me.Controls.SetChildIndex(Me.cbo16, 0)
        Me.Controls.SetChildIndex(Me.lblcbo17, 0)
        Me.Controls.SetChildIndex(Me.cbo17, 0)
        Me.Controls.SetChildIndex(Me.lblcbo18, 0)
        Me.Controls.SetChildIndex(Me.cbo18, 0)
        Me.Controls.SetChildIndex(Me.txt3, 0)
        Me.Controls.SetChildIndex(Me.lbltxt3, 0)
        Me.Controls.SetChildIndex(Me.txt4, 0)
        Me.Controls.SetChildIndex(Me.lbltxt4, 0)
        Me.Controls.SetChildIndex(Me.txt5, 0)
        Me.Controls.SetChildIndex(Me.lbltxt5, 0)
        Me.Controls.SetChildIndex(Me.txt6, 0)
        Me.Controls.SetChildIndex(Me.lbltxt6, 0)
        Me.Controls.SetChildIndex(Me.txt7, 0)
        Me.Controls.SetChildIndex(Me.lbltxt7, 0)
        Me.Controls.SetChildIndex(Me.txt8, 0)
        Me.Controls.SetChildIndex(Me.lbltxt8, 0)
        Me.Controls.SetChildIndex(Me.txt9, 0)
        Me.Controls.SetChildIndex(Me.lbltxt9, 0)
        Me.Controls.SetChildIndex(Me.txt10, 0)
        Me.Controls.SetChildIndex(Me.lbltxt10, 0)
        Me.Controls.SetChildIndex(Me.lblcbo19, 0)
        Me.Controls.SetChildIndex(Me.cbo19, 0)
        Me.Controls.SetChildIndex(Me.lblcbo20, 0)
        Me.Controls.SetChildIndex(Me.cbo20, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cboType, 0)
        Me.Controls.SetChildIndex(Me.txt11, 0)
        Me.Controls.SetChildIndex(Me.lbltxt11, 0)
        Me.Controls.SetChildIndex(Me.txt12, 0)
        Me.Controls.SetChildIndex(Me.lbltxt12, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Properties"

    Private _updating As Boolean = True

    Public Property Updating() As Boolean
        Get
            Return _updating
        End Get
        Set(ByVal Value As Boolean)
            _updating = Value
        End Set
    End Property

    Private _Worksheet As Entity.EngineerVisitAdditionals.EngineerVisitAdditional

    Public Property Worksheet() As Entity.EngineerVisitAdditionals.EngineerVisitAdditional
        Get
            Return _Worksheet
        End Get
        Set(ByVal Value As Entity.EngineerVisitAdditionals.EngineerVisitAdditional)
            _Worksheet = Value
        End Set
    End Property

    Private _EngineerVisit As Entity.EngineerVisits.EngineerVisit

    Public Property EngineerVisit() As Entity.EngineerVisits.EngineerVisit
        Get
            Return _EngineerVisit
        End Get
        Set(ByVal Value As Entity.EngineerVisits.EngineerVisit)
            _EngineerVisit = Value
        End Set
    End Property

    Private _TheSite As Entity.Sites.Site

    Public Property TheSite() As Entity.Sites.Site
        Get
            Return _TheSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _TheSite = Value
        End Set
    End Property

    Private _jobID As Integer

    Public Property JobID() As Integer
        Get
            Return _jobID
        End Get
        Set(ByVal Value As Integer)
            _jobID = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub DLGVisitAssetWorkSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If loggedInUser.Admin = False Then

            btnSave.Enabled = False
            cboType.Enabled = False
            cbo1.Enabled = False
            cbo2.Enabled = False
            cbo3.Enabled = False
            cbo4.Enabled = False
            cbo5.Enabled = False
            cbo6.Enabled = False
            cbo7.Enabled = False
            cbo8.Enabled = False
            cbo9.Enabled = False
            cbo10.Enabled = False

            cbo11.Enabled = False
            cbo12.Enabled = False
            cbo13.Enabled = False
            cbo14.Enabled = False
            cbo15.Enabled = False
            cbo16.Enabled = False
            cbo17.Enabled = False
            cbo18.Enabled = False
            cbo19.Enabled = False
            cbo20.Enabled = False

            txt1.ReadOnly = True
            txt2.ReadOnly = True
            txt3.ReadOnly = True
            txt4.ReadOnly = True
            txt5.ReadOnly = True
            txt6.ReadOnly = True
            txt7.ReadOnly = True
            txt8.ReadOnly = True
            txt9.ReadOnly = True
            txt10.ReadOnly = True

        End If
        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.TestType).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetSelectedComboItem_By_Value(Me.cboType, Worksheet.TestTypeID)

        If Worksheet.Exists = True And Updating = True Then
            Loadin()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Worksheet.SetTestTypeID = cboType.SelectedItem("value")
            Worksheet.SetEngineerVisitID = EngineerVisit.EngineerVisitID
            Worksheet.SetTest1 = Combo.GetSelectedItemValue(Me.cbo1)
            Worksheet.SetTest2 = Combo.GetSelectedItemValue(Me.cbo2)
            Worksheet.SetTest3 = Combo.GetSelectedItemValue(Me.cbo3)
            Worksheet.SetTest4 = Combo.GetSelectedItemValue(Me.cbo4)
            Worksheet.SetTest5 = Combo.GetSelectedItemValue(Me.cbo5)
            Worksheet.SetTest6 = Combo.GetSelectedItemValue(Me.cbo6)
            Worksheet.SetTest7 = Combo.GetSelectedItemValue(Me.cbo7)
            Worksheet.SetTest8 = Combo.GetSelectedItemValue(Me.cbo8)
            Worksheet.SetTest9 = Combo.GetSelectedItemValue(Me.cbo9)
            Worksheet.SetTest10 = Combo.GetSelectedItemValue(Me.cbo10)
            Worksheet.SetTest111 = Combo.GetSelectedItemValue(Me.cbo11)
            Worksheet.SetTest112 = Combo.GetSelectedItemValue(Me.cbo12)
            Worksheet.SetTest113 = Combo.GetSelectedItemValue(Me.cbo13)
            Worksheet.SetTest114 = Combo.GetSelectedItemValue(Me.cbo14)
            Worksheet.SetTest115 = Combo.GetSelectedItemValue(Me.cbo15)
            Worksheet.SetTest116 = Combo.GetSelectedItemValue(Me.cbo16)
            Worksheet.SetTest117 = Combo.GetSelectedItemValue(Me.cbo17)
            Worksheet.SetTest118 = Combo.GetSelectedItemValue(Me.cbo18)
            Worksheet.SetTest119 = Combo.GetSelectedItemValue(Me.cbo19)
            Worksheet.SetTest120 = Combo.GetSelectedItemValue(Me.cbo20)

            Worksheet.SetTest11 = txt1.Text
            Worksheet.SetTest12 = txt2.Text
            Worksheet.SetTest13 = txt3.Text
            Worksheet.SetTest14 = txt4.Text
            Worksheet.SetTest15 = txt5.Text
            Worksheet.SetTest216 = txt6.Text
            Worksheet.SetTest217 = txt7.Text
            Worksheet.SetTest218 = txt8.Text
            Worksheet.SetTest219 = txt9.Text
            Worksheet.SetTest220 = txt10.Text
            Worksheet.SetTest221 = txt11.Text
            Worksheet.SetTest222 = txt12.Text

            If Updating Then
                DB.EngineerVisitAdditional.Update(Worksheet)
            Else
                DB.EngineerVisitAdditional.Insert(Worksheet)
            End If

            Me.DialogResult = DialogResult.OK
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Error saving details : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

#End Region

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        setQuestions()

    End Sub

    Sub setQuestions()
        Try
            Dim testTypeID As Integer = Combo.GetSelectedItemValue(Me.cboType)
            If testTypeID = 69108 Then

                comSafetyRec()

            ElseIf testTypeID = 69109 Then

                comStrength()

            ElseIf testTypeID = 69110 Then

                comPurge()

            ElseIf testTypeID = 69111 Then

                comTight()
            Else
                hideAll()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub Loadin()

        '_worksheetData = EngineerVisitAdditionalChecks.Get(_worksheetID);

        ''

        Combo.SetSelectedComboItem_By_Value(Me.cboType, Worksheet.TestTypeID)

        setQuestions()

        If _Worksheet.Test1 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo1, _Worksheet.Test1.ToString)
        If _Worksheet.Test2 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo2, _Worksheet.Test2.ToString)
        If _Worksheet.Test3 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo3, _Worksheet.Test3.ToString)
        If _Worksheet.Test4 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo4, _Worksheet.Test4.ToString)
        If _Worksheet.Test5 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo5, _Worksheet.Test5.ToString)
        If _Worksheet.Test6 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo6, _Worksheet.Test6.ToString)
        If _Worksheet.Test7 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo7, _Worksheet.Test7.ToString)
        If _Worksheet.Test8 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo8, _Worksheet.Test8.ToString)
        If _Worksheet.Test9 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo9, _Worksheet.Test9.ToString)
        If _Worksheet.Test10 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo10, _Worksheet.Test10.ToString)
        If _Worksheet.Test111 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo11, _Worksheet.Test111.ToString)
        If _Worksheet.Test112 > 0 Then Combo.SetSelectedComboItem_By_Value(cbo12, _Worksheet.Test112.ToString)
        If (_Worksheet.Test113 > 0) Then Combo.SetSelectedComboItem_By_Value(cbo13, _Worksheet.Test113.ToString)
        If (_Worksheet.Test114 > 0) Then Combo.SetSelectedComboItem_By_Value(cbo14, _Worksheet.Test114.ToString)
        If (_Worksheet.Test115 > 0) Then Combo.SetSelectedComboItem_By_Value(cbo15, _Worksheet.Test115.ToString)
        If (_Worksheet.Test116 > 0) Then Combo.SetSelectedComboItem_By_Value(cbo16, _Worksheet.Test116.ToString)
        If (_Worksheet.Test117 > 0) Then Combo.SetSelectedComboItem_By_Value(cbo17, _Worksheet.Test117.ToString)
        If (_Worksheet.Test118 > 0) Then Combo.SetSelectedComboItem_By_Value(cbo18, _Worksheet.Test118.ToString)

        txt1.Text = _Worksheet.Test11
        txt2.Text = _Worksheet.Test12
        txt3.Text = _Worksheet.Test13
        txt4.Text = _Worksheet.Test14
        txt5.Text = _Worksheet.Test15
        txt6.Text = _Worksheet.Test216
        txt7.Text = _Worksheet.Test217
        txt8.Text = _Worksheet.Test218
        txt9.Text = _Worksheet.Test219
        txt10.Text = _Worksheet.Test220
        txt11.Text = _Worksheet.Test221
        txt12.Text = _Worksheet.Test222

        If (_Worksheet.Test119 > 0) Then Combo.SetSelectedComboItem_By_Value(cbo19, _Worksheet.Test119.ToString)
        If (_Worksheet.Test120 > 0) Then Combo.SetSelectedComboItem_By_Value(cbo20, _Worksheet.Test120.ToString)

    End Sub

    Sub hideAll()

        cbo1.Visible = (False)
        cbo2.Visible = (False)
        cbo3.Visible = (False)
        cbo4.Visible = (False)
        cbo5.Visible = (False)
        cbo6.Visible = (False)
        cbo7.Visible = (False)
        cbo8.Visible = (False)
        cbo9.Visible = (False)
        cbo10.Visible = (False)
        cbo11.Visible = (False)
        cbo12.Visible = (False)
        cbo13.Visible = (False)
        cbo14.Visible = (False)
        cbo15.Visible = (False)
        cbo16.Visible = (False)
        cbo17.Visible = (False)
        cbo18.Visible = (False)
        cbo19.Visible = (False)
        cbo20.Visible = (False)

        lblcbo1.Visible = (False)
        lblcbo2.Visible = (False)
        lblcbo3.Visible = (False)
        lblcbo4.Visible = (False)
        lblcbo5.Visible = (False)
        lblcbo6.Visible = (False)
        lblcbo7.Visible = (False)
        lblcbo8.Visible = (False)
        lblcbo9.Visible = (False)
        lblcbo10.Visible = (False)
        lblcbo11.Visible = (False)
        lblcbo12.Visible = (False)
        lblcbo13.Visible = (False)
        lblcbo14.Visible = (False)
        lblcbo15.Visible = (False)
        lblcbo16.Visible = (False)
        lblcbo17.Visible = (False)
        lblcbo18.Visible = (False)
        lblcbo19.Visible = (False)
        lblcbo20.Visible = (False)

        txt1.Visible = (False)
        txt2.Visible = (False)
        txt3.Visible = (False)
        txt4.Visible = (False)
        txt5.Visible = (False)
        txt6.Visible = (False)
        txt7.Visible = (False)
        txt8.Visible = (False)
        txt9.Visible = (False)
        txt10.Visible = (False)
        txt11.Visible = (False)
        txt12.Visible = (False)

        lbltxt1.Visible = (False)
        lbltxt2.Visible = (False)
        lbltxt3.Visible = (False)
        lbltxt4.Visible = (False)
        lbltxt5.Visible = (False)
        lbltxt6.Visible = (False)
        lbltxt7.Visible = (False)
        lbltxt8.Visible = (False)
        lbltxt9.Visible = (False)
        lbltxt10.Visible = (False)
        lbltxt11.Visible = (False)
        lbltxt12.Visible = (False)

    End Sub

    Sub comSafetyRec()

        cbo1.Visible = (True)
        cbo2.Visible = (True)
        cbo3.Visible = (True)
        cbo4.Visible = (True)
        cbo5.Visible = (True)
        cbo6.Visible = (True)
        cbo7.Visible = (True)
        cbo8.Visible = (True)
        cbo9.Visible = (True)
        cbo10.Visible = (True)
        cbo11.Visible = (True)
        cbo12.Visible = (True)
        cbo13.Visible = (True)
        cbo14.Visible = (True)
        cbo15.Visible = (True)
        cbo16.Visible = (True)
        cbo17.Visible = (True)
        cbo18.Visible = (True)
        cbo19.Visible = (True)
        cbo20.Visible = (False)

        lblcbo1.Visible = (True)
        lblcbo2.Visible = (True)
        lblcbo3.Visible = (True)
        lblcbo4.Visible = (True)
        lblcbo5.Visible = (True)
        lblcbo6.Visible = (True)
        lblcbo7.Visible = (True)
        lblcbo8.Visible = (True)
        lblcbo9.Visible = (True)
        lblcbo10.Visible = (True)
        lblcbo11.Visible = (True)
        lblcbo12.Visible = (True)
        lblcbo13.Visible = (True)
        lblcbo14.Visible = (True)
        lblcbo15.Visible = (True)
        lblcbo16.Visible = (True)
        lblcbo17.Visible = (True)
        lblcbo18.Visible = (True)
        lblcbo19.Visible = (True)
        lblcbo20.Visible = (False)

        txt1.Visible = (False)
        txt2.Visible = (False)
        txt3.Visible = (False)
        txt4.Visible = (False)
        txt5.Visible = (False)
        txt6.Visible = (False)
        txt7.Visible = (False)
        txt8.Visible = (False)
        txt9.Visible = (False)
        txt10.Visible = (False)
        txt11.Visible = (False)
        txt12.Visible = (False)

        lbltxt1.Visible = (False)
        lbltxt2.Visible = (False)
        lbltxt3.Visible = (False)
        lbltxt4.Visible = (False)
        lbltxt5.Visible = (False)
        lbltxt6.Visible = (False)
        lbltxt7.Visible = (False)
        lbltxt8.Visible = (False)
        lbltxt9.Visible = (False)
        lbltxt10.Visible = (False)
        lbltxt11.Visible = (False)
        lbltxt12.Visible = (False)

        lblcbo1.Text = "Is the meter installation accessible?"
        Combo.SetUpCombo(Me.cbo1, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo2.Text = "Is the meter adequately supported?"
        Combo.SetUpCombo(Me.cbo2, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo3.Text = "Is the ECV accessible?"
        Combo.SetUpCombo(Me.cbo3, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo4.Text = "Is the ECV fitted with a handle?"
        Combo.SetUpCombo(Me.cbo4, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo5.Text = "Is the ECV labeled with direction of operation?"
        Combo.SetUpCombo(Me.cbo5, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo6.Text = "Is the ECV complete with emergency notice?"
        Combo.SetUpCombo(Me.cbo6, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo7.Text = "Is the meter room/compartment/housing adequately Ventilated?"
        Combo.SetUpCombo(Me.cbo7, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo8.Text = "Is the meter room/compartment/housing clear of combustibles etc?"
        Combo.SetUpCombo(Me.cbo8, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo9.Text = "Is a gas installation line diagram fixed near to the primary meter?"
        Combo.SetUpCombo(Me.cbo9, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo10.Text = "Is the gas installation line diagram current/up-to-date?"
        Combo.SetUpCombo(Me.cbo10, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo11.Text = "Are emergency/isolation valves fitted?"
        Combo.SetUpCombo(Me.cbo11, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo12.Text = "Are emergency/isolation valve handles in place and suitably lablled?"
        Combo.SetUpCombo(Me.cbo12, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo13.Text = "Is the gas installation line diagram current/up-to-date?"
        Combo.SetUpCombo(Me.cbo13, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo14.Text = "Is the gas pipework adequately supported?"
        Combo.SetUpCombo(Me.cbo14, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo15.Text = "Is the gas pipework, where located in ducts, adequately ventilated?"
        Combo.SetUpCombo(Me.cbo15, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo16.Text = "Is the gas pipework colour coded/identified?"
        Combo.SetUpCombo(Me.cbo16, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo17.Text = "Is the gas installation electrically bonded?"
        Combo.SetUpCombo(Me.cbo17, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo18.Text = "Is the pipework suitably sleeved and sealed, as appropriate?"
        Combo.SetUpCombo(Me.cbo18, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        lblcbo19.Text = "Has a gas strength/tightness test been carried out?"
        Combo.SetUpCombo(Me.cbo19, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

    End Sub

    Sub comStrength()

        cbo1.Visible = (True)
        cbo2.Visible = (True)
        cbo3.Visible = (True)
        cbo4.Visible = (True)
        cbo5.Visible = (False)
        cbo6.Visible = (False)
        cbo7.Visible = (False)
        cbo8.Visible = (False)
        cbo9.Visible = (False)
        cbo10.Visible = (False)
        cbo11.Visible = (False)
        cbo12.Visible = (False)
        cbo13.Visible = (False)
        cbo14.Visible = (False)
        cbo15.Visible = (False)
        cbo16.Visible = (False)
        cbo17.Visible = (False)
        cbo18.Visible = (False)
        cbo19.Visible = (False)
        cbo20.Visible = (True)

        lblcbo1.Visible = (True)
        lblcbo2.Visible = (True)
        lblcbo3.Visible = (True)
        lblcbo4.Visible = (True)
        lblcbo5.Visible = (False)
        lblcbo6.Visible = (False)
        lblcbo7.Visible = (False)
        lblcbo8.Visible = (False)
        lblcbo9.Visible = (False)
        lblcbo10.Visible = (False)
        lblcbo11.Visible = (False)
        lblcbo12.Visible = (False)
        lblcbo13.Visible = (False)
        lblcbo14.Visible = (False)
        lblcbo15.Visible = (False)
        lblcbo16.Visible = (False)
        lblcbo17.Visible = (False)
        lblcbo18.Visible = (False)
        lblcbo19.Visible = (False)
        lblcbo20.Visible = (True)

        txt1.Visible = (True)
        txt2.Visible = (True)
        txt3.Visible = (True)
        txt4.Visible = (True)
        txt5.Visible = (True)
        txt6.Visible = (True)
        txt7.Visible = (False)
        txt8.Visible = (False)
        txt9.Visible = (False)
        txt10.Visible = (False)
        txt11.Visible = (False)
        txt12.Visible = (False)

        lbltxt1.Visible = (True)
        lbltxt2.Visible = (True)
        lbltxt3.Visible = (True)
        lbltxt4.Visible = (True)
        lbltxt5.Visible = (True)
        lbltxt6.Visible = (True)
        lbltxt7.Visible = (False)
        lbltxt8.Visible = (False)
        lbltxt9.Visible = (False)
        lbltxt10.Visible = (False)
        lbltxt11.Visible = (False)
        lbltxt12.Visible = (False)

        Dim dr As DataRow
        Dim dt As New DataTable

        dt.Columns.Add("Name")
        dt.Columns.Add("Value")

        dr = dt.NewRow
        dr("Name") = "- Please Select -"
        dr("Value") = 0
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "Pneumatic"
        dr("Value") = 1
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "Hydrostatic"
        dr("Value") = 2
        dt.Rows.Add(dr)

        cbo1.Items.Clear()

        If Not dt Is Nothing Then
            For Each DataRow As DataRow In dt.Rows
                cbo1.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
            Next
        End If

        cbo1.DisplayMember = "Description"
        cbo1.ValueMember = "Value"
        cbo1.SelectedIndex = 0
        '

        lblcbo1.Text = ("State test method - ")

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")

        dt.Rows.Add("- Please Select -", 0)
        dt.Rows.Add("New", 1)
        dt.Rows.Add("New extension", 2)
        dt.Rows.Add("Existing", 3)

        cbo2.Items.Clear()
        If Not dt Is Nothing Then
            For Each DataRow As DataRow In dt.Rows
                cbo2.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
            Next
        End If

        cbo2.DisplayMember = "Description"
        cbo2.ValueMember = "Value"
        cbo2.SelectedIndex = 0

        lblcbo2.Text = ("Installation - ")

        Combo.SetUpCombo(Me.cbo3, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo3.Text = ("Have components not suitable for strength testing been removed or isolated from installation as necessary")

        lbltxt1.Text = ("Calculated strength test pressure")

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")

        dt.Rows.Add("- Please Select -", 0)
        dt.Rows.Add("Air", 1)
        dt.Rows.Add("Nitrogen", 2)
        dt.Rows.Add("Water", 3)

        cbo4.Items.Clear()
        If Not dt Is Nothing Then
            For Each DataRow As DataRow In dt.Rows
                cbo4.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
            Next
        End If

        cbo4.DisplayMember = "Description"
        cbo4.ValueMember = "Value"
        cbo4.SelectedIndex = 0

        lblcbo4.Text = ("Test medium - air, nitrogen, water etc.")

        lbltxt2.Text = ("Stabilisation Period (minutes)")

        lbltxt3.Text = ("Strength Test Duration (STD) (minutes)")

        lbltxt4.Text = ("Permitted pressure drop (% STP)")

        lbltxt5.Text = ("Calculated pressure Drop")

        lbltxt6.Text = ("Actual pressure Drop")

        Combo.SetUpCombo(Me.cbo20, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFail).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo20.Text = ("Strength Test Pass or Fail")

    End Sub

    Sub comTight()

        cbo1.Visible = (True)
        cbo2.Visible = (True)
        cbo3.Visible = (True)
        cbo4.Visible = (True)
        cbo5.Visible = (False)
        cbo6.Visible = (True)
        cbo7.Visible = (True)
        cbo8.Visible = (True)
        cbo9.Visible = (True)
        cbo10.Visible = (True)
        cbo11.Visible = (False)
        cbo12.Visible = (False)
        cbo13.Visible = (False)
        cbo14.Visible = (False)
        cbo15.Visible = (False)
        cbo16.Visible = (False)
        cbo17.Visible = (False)
        cbo18.Visible = (False)
        cbo19.Visible = (True)
        cbo20.Visible = (True)

        lblcbo1.Visible = (True)
        lblcbo2.Visible = (True)
        lblcbo3.Visible = (True)
        lblcbo4.Visible = (True)
        lblcbo5.Visible = (False)
        lblcbo6.Visible = (True)
        lblcbo7.Visible = (True)
        lblcbo8.Visible = (True)
        lblcbo9.Visible = (True)
        lblcbo10.Visible = (True)
        lblcbo11.Visible = (False)
        lblcbo12.Visible = (False)
        lblcbo13.Visible = (False)
        lblcbo14.Visible = (False)
        lblcbo15.Visible = (False)
        lblcbo16.Visible = (False)
        lblcbo17.Visible = (False)
        lblcbo18.Visible = (False)
        lblcbo19.Visible = (True)
        lblcbo20.Visible = (True)

        txt1.Visible = (True)
        txt2.Visible = (True)
        txt3.Visible = (True)
        txt4.Visible = (True)
        txt5.Visible = (True)
        txt6.Visible = (True)
        txt7.Visible = (True)
        txt8.Visible = (True)
        txt9.Visible = (True)
        txt10.Visible = (True)
        txt11.Visible = (True)
        txt12.Visible = (False)

        lbltxt1.Visible = (True)
        lbltxt2.Visible = (True)
        lbltxt3.Visible = (True)
        lbltxt4.Visible = (True)
        lbltxt5.Visible = (True)
        lbltxt6.Visible = (True)
        lbltxt7.Visible = (True)
        lbltxt8.Visible = (True)
        lbltxt9.Visible = (True)
        lbltxt10.Visible = (True)
        lbltxt11.Visible = (True)
        lbltxt12.Visible = (False)

        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")

        dt.Rows.Add("- Please Select -", 0)
        dt.Rows.Add("Natural Gas (NG)", 1)
        dt.Rows.Add("Liquefied Petroleum Gas (LPG)", 2)
        cbo1.Items.Clear()
        If Not dt Is Nothing Then
            For Each DataRow As DataRow In dt.Rows
                cbo1.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
            Next
        End If

        cbo1.DisplayMember = "Description"
        cbo1.ValueMember = "Value"
        cbo1.SelectedIndex = 0

        lblcbo1.Text = ("Gas Type - ")

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")

        dt.Rows.Add("- Please Select -", 0)
        dt.Rows.Add("New", 1)
        dt.Rows.Add("New extension", 2)
        dt.Rows.Add("Existing", 3)
        cbo2.Items.Clear()
        If Not dt Is Nothing Then
            For Each DataRow As DataRow In dt.Rows
                cbo2.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
            Next
        End If

        cbo2.DisplayMember = "Description"
        cbo2.ValueMember = "Value"
        cbo2.SelectedIndex = 0

        lblcbo2.Text = ("Installation - ")

        Combo.SetUpCombo(Me.cbo3, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo3.Text = ("Could weather/changes in temperature affect test?")

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")

        dt.Rows.Add("- Please Select -", 0)
        dt.Rows.Add("Diaphragm", 1)
        dt.Rows.Add("Rotary", 2)
        dt.Rows.Add("Turbine", 3)
        cbo4.Items.Clear()
        If Not dt Is Nothing Then
            For Each DataRow As DataRow In dt.Rows
                cbo4.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
            Next
        End If

        cbo4.DisplayMember = "Description"
        cbo4.ValueMember = "Value"
        cbo4.SelectedIndex = 0
        lblcbo4.Text = ("Meter Type - ")

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")

        'dt.Rows.Add("- Please Select -", 0)
        'dt.Rows.Add("U16", 1)
        'dt.Rows.Add("U40", 2)
        'dt.Rows.Add("P7", 3)
        'dt.Rows.Add("U25", 4)
        'cbo5.Items.Clear()
        'If Not dt Is Nothing Then
        '    For Each DataRow As DataRow In dt.Rows
        '        cbo5.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
        '    Next
        'End If

        'cbo5.DisplayMember = "Description"
        'cbo5.ValueMember = "Value"
        'cbo5.SelectedIndex = 0

        'lblcbo5.Text = ("Meter Design - ")

        Combo.SetUpCombo(Me.cbo6, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo6.Text = ("Meter Bypass Installed and Sealed?")

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")

        dt.Rows.Add("- Please Select -", 0)
        dt.Rows.Add("Fuel gas", 1)
        dt.Rows.Add("Air", 2)
        cbo7.Items.Clear()
        If Not dt Is Nothing Then
            For Each DataRow As DataRow In dt.Rows
                cbo7.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
            Next
        End If

        cbo7.DisplayMember = "Description"
        cbo7.ValueMember = "Value"
        cbo7.SelectedIndex = 0
        lblcbo7.Text = ("Test Medium - ")

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")

        dt.Rows.Add("- Please Select -", 0)
        dt.Rows.Add("Water", 1)
        dt.Rows.Add("High SG", 2)
        dt.Rows.Add("Electronic", 2)
        cbo8.Items.Clear()
        If Not dt Is Nothing Then
            For Each DataRow As DataRow In dt.Rows
                cbo8.Items.Add(New Combo(DataRow.Item("Name"), DataRow.Item("Value")))
            Next
        End If

        cbo8.DisplayMember = "Description"
        cbo8.ValueMember = "Value"
        cbo8.SelectedIndex = 0
        lblcbo8.Text = ("Pressure Gauge Type - ")

        Combo.SetUpCombo(Me.cbo9, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo9.Text = ("Any inadequately ventilated areas to check?")

        Combo.SetUpCombo(Me.cbo10, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo10.Text = ("Is barometric pressure correction necessary?")

        Combo.SetUpCombo(Me.cbo19, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo19.Text = ("Have inadequately ventilated areas been checked?")

        Combo.SetUpCombo(Me.cbo20, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFail).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo20.Text = ("Tightness test Pass or Fail")

        lbltxt1.Text = ("Installation Volume : Gas Meter (m3)")

        lbltxt2.Text = ("Installation Volume : Installation pipework and fittings (m3)")

        lbltxt3.Text = ("Installation Volume : Total IV (m3)")

        lbltxt4.Text = ("Tightness test pressure (TTP) mbar")

        lbltxt5.Text = ("MPLR m3/hr (IGE/UP/1) or MAPD mbar (IGE/UP/1A) ")

        lbltxt6.Text = ("Let-by test period existing installations (minutes)")

        lbltxt7.Text = ("Stabilisation period (minutes)")

        lbltxt8.Text = ("Tightness test duration (TTD) (minutes)")

        lbltxt9.Text = ("Actual pressure drop (if any) mbar")

        lbltxt10.Text = ("Actual leak rate m3/hr")

        lbltxt11.Text = ("Meter Designation (U16,U40,Etc.) - ")

    End Sub

    Sub comPurge()

        cbo1.Visible = (True)
        cbo2.Visible = (True)
        cbo3.Visible = (True)
        cbo4.Visible = (True)
        cbo5.Visible = (True)
        cbo6.Visible = (True)
        cbo7.Visible = (True)
        cbo8.Visible = (True)
        cbo9.Visible = (True)
        cbo10.Visible = (True)
        cbo11.Visible = (False)
        cbo12.Visible = (False)
        cbo13.Visible = (False)
        cbo14.Visible = (False)
        cbo15.Visible = (False)
        cbo16.Visible = (False)
        cbo17.Visible = (False)
        cbo18.Visible = (False)
        cbo19.Visible = (False)
        cbo20.Visible = (True)

        lblcbo1.Visible = (True)
        lblcbo2.Visible = (True)
        lblcbo3.Visible = (True)
        lblcbo4.Visible = (True)
        lblcbo5.Visible = (True)
        lblcbo6.Visible = (True)
        lblcbo7.Visible = (True)
        lblcbo8.Visible = (True)
        lblcbo9.Visible = (True)
        lblcbo10.Visible = (True)
        lblcbo11.Visible = (False)
        lblcbo12.Visible = (False)
        lblcbo13.Visible = (False)
        lblcbo14.Visible = (False)
        lblcbo15.Visible = (False)
        lblcbo16.Visible = (False)
        lblcbo17.Visible = (False)
        lblcbo18.Visible = (False)
        lblcbo19.Visible = (False)
        lblcbo20.Visible = (True)

        txt1.Visible = (True)
        txt2.Visible = (True)
        txt3.Visible = (True)
        txt4.Visible = (True)
        txt5.Visible = (False)
        txt6.Visible = (False)
        txt7.Visible = (False)
        txt8.Visible = (False)
        txt9.Visible = (False)
        txt10.Visible = (False)
        txt11.Visible = (False)
        txt12.Visible = (False)

        lbltxt1.Visible = (True)
        lbltxt2.Visible = (True)
        lbltxt3.Visible = (True)
        lbltxt4.Visible = (True)
        lbltxt5.Visible = (False)
        lbltxt6.Visible = (False)
        lbltxt7.Visible = (False)
        lbltxt8.Visible = (False)
        lbltxt9.Visible = (False)
        lbltxt10.Visible = (False)
        lbltxt11.Visible = (False)
        lbltxt12.Visible = (False)

        Combo.SetUpCombo(Me.cbo1, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo1.Text = ("Has a risk assessment been carried out?")

        Combo.SetUpCombo(Me.cbo2, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo2.Text = ("Has a written procedure for the purge been prepared?")

        Combo.SetUpCombo(Me.cbo3, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo3.Text = ("Have 'NO SMOKING' signs etc been displayed as necessary?")

        Combo.SetUpCombo(Me.cbo4, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo4.Text = ("Have persons in the vicinity of the purge been advised accordingly?")

        Combo.SetUpCombo(Me.cbo5, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo5.Text = ("Have all appropriate valves to and from the section of pipe been labelled?")

        Combo.SetUpCombo(Me.cbo6, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo6.Text = ("Where nitrogen gas is being used for an indirect purge, have the gas cylinders been checked/verified for their correct content?")

        Combo.SetUpCombo(Me.cbo7, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo7.Text = ("Are suitable extinguishers available in case of an incident?")

        Combo.SetUpCombo(Me.cbo8, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo8.Text = ("Are two-way radios (intrinsically safe) available?")

        Combo.SetUpCombo(Me.cbo9, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo9.Text = ("Are all electrical bonds fitted as necessary?")

        Combo.SetUpCombo(Me.cbo10, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.YesNo).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo10.Text = ("Is gas detector/oxygen measuring device, as appropriate, intrinsically safe?")

        Combo.SetUpCombo(Me.cbo20, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PassFail).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        lblcbo20.Text = ("Purge Pass or Fail")

        lbltxt1.Text = ("Calculate purge Volume : Gas meter (m3)")

        lbltxt2.Text = ("Calculate purge Volume : Installation pipework and fittings (m3)")

        lbltxt3.Text = ("Calculate purge Volume : Total purge volume (m3)")

        lbltxt4.Text = ("Carry out purge noting final test criteria readings (O2% or LFL%)")

    End Sub

End Class