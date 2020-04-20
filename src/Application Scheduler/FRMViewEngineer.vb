Imports System.Collections.Generic
Imports FSM.Entity.Sys
Imports System.Linq

Public Class FRMViewEngineer : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal dtEngineer As DataTable)
        MyBase.New()

        Engineer = dtEngineer

        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub


    Friend WithEvents grpEngineerInfo As GroupBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblEngGroup As Label
    Friend WithEvents lblRegion As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents lblTelNum As Label
    Friend WithEvents lblManName As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Customer_Get_ForSiteIDTableAdapter1 As FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter
    Friend WithEvents grpPostcodes As GroupBox
    Friend WithEvents txtPostcode As TextBox
    Friend WithEvents grpQualifications As GroupBox
    Friend WithEvents txtQual As TextBox
    Friend WithEvents txtRegion As TextBox
    Friend WithEvents txtManager As TextBox
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents txtEngineerGroup As TextBox
    Friend WithEvents btnClose As Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpEngineerInfo = New System.Windows.Forms.GroupBox()
        Me.txtManager = New System.Windows.Forms.TextBox()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.txtEngineerGroup = New System.Windows.Forms.TextBox()
        Me.txtRegion = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblEngGroup = New System.Windows.Forms.Label()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblTelNum = New System.Windows.Forms.Label()
        Me.lblManName = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Customer_Get_ForSiteIDTableAdapter1 = New FSM.FSMDataSetTableAdapters.Customer_Get_ForSiteIDTableAdapter()
        Me.grpPostcodes = New System.Windows.Forms.GroupBox()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.grpQualifications = New System.Windows.Forms.GroupBox()
        Me.txtQual = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpEngineerInfo.SuspendLayout()
        Me.grpPostcodes.SuspendLayout()
        Me.grpQualifications.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpEngineerInfo
        '
        Me.grpEngineerInfo.Controls.Add(Me.txtManager)
        Me.grpEngineerInfo.Controls.Add(Me.txtDepartment)
        Me.grpEngineerInfo.Controls.Add(Me.txtEngineerGroup)
        Me.grpEngineerInfo.Controls.Add(Me.txtRegion)
        Me.grpEngineerInfo.Controls.Add(Me.txtPhone)
        Me.grpEngineerInfo.Controls.Add(Me.txtName)
        Me.grpEngineerInfo.Controls.Add(Me.lblEngGroup)
        Me.grpEngineerInfo.Controls.Add(Me.lblRegion)
        Me.grpEngineerInfo.Controls.Add(Me.lblDepartment)
        Me.grpEngineerInfo.Controls.Add(Me.lblTelNum)
        Me.grpEngineerInfo.Controls.Add(Me.lblManName)
        Me.grpEngineerInfo.Controls.Add(Me.lblName)
        Me.grpEngineerInfo.Enabled = False
        Me.grpEngineerInfo.Location = New System.Drawing.Point(0, 53)
        Me.grpEngineerInfo.Name = "grpEngineerInfo"
        Me.grpEngineerInfo.Size = New System.Drawing.Size(829, 146)
        Me.grpEngineerInfo.TabIndex = 1
        Me.grpEngineerInfo.TabStop = False
        Me.grpEngineerInfo.Text = "Engineer Information"
        '
        'txtManager
        '
        Me.txtManager.Enabled = False
        Me.txtManager.Location = New System.Drawing.Point(560, 31)
        Me.txtManager.Name = "txtManager"
        Me.txtManager.Size = New System.Drawing.Size(247, 21)
        Me.txtManager.TabIndex = 64
        '
        'txtDepartment
        '
        Me.txtDepartment.Enabled = False
        Me.txtDepartment.Location = New System.Drawing.Point(560, 60)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(247, 21)
        Me.txtDepartment.TabIndex = 63
        '
        'txtEngineerGroup
        '
        Me.txtEngineerGroup.Enabled = False
        Me.txtEngineerGroup.Location = New System.Drawing.Point(560, 90)
        Me.txtEngineerGroup.Name = "txtEngineerGroup"
        Me.txtEngineerGroup.Size = New System.Drawing.Size(247, 21)
        Me.txtEngineerGroup.TabIndex = 62
        '
        'txtRegion
        '
        Me.txtRegion.Enabled = False
        Me.txtRegion.Location = New System.Drawing.Point(120, 90)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.Size = New System.Drawing.Size(247, 21)
        Me.txtRegion.TabIndex = 61
        '
        'txtPhone
        '
        Me.txtPhone.Enabled = False
        Me.txtPhone.Location = New System.Drawing.Point(120, 60)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(247, 21)
        Me.txtPhone.TabIndex = 8
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(120, 31)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(247, 21)
        Me.txtName.TabIndex = 6
        '
        'lblEngGroup
        '
        Me.lblEngGroup.AutoSize = True
        Me.lblEngGroup.Location = New System.Drawing.Point(453, 93)
        Me.lblEngGroup.Name = "lblEngGroup"
        Me.lblEngGroup.Size = New System.Drawing.Size(101, 13)
        Me.lblEngGroup.TabIndex = 5
        Me.lblEngGroup.Text = "Engineer Group:"
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(12, 93)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(51, 13)
        Me.lblRegion.TabIndex = 4
        Me.lblRegion.Text = "Region:"
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Location = New System.Drawing.Point(453, 63)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(80, 13)
        Me.lblDepartment.TabIndex = 3
        Me.lblDepartment.Text = "Department:"
        '
        'lblTelNum
        '
        Me.lblTelNum.AutoSize = True
        Me.lblTelNum.Location = New System.Drawing.Point(12, 63)
        Me.lblTelNum.Name = "lblTelNum"
        Me.lblTelNum.Size = New System.Drawing.Size(96, 13)
        Me.lblTelNum.TabIndex = 2
        Me.lblTelNum.Text = "Phone Number:"
        '
        'lblManName
        '
        Me.lblManName.AutoSize = True
        Me.lblManName.Location = New System.Drawing.Point(453, 34)
        Me.lblManName.Name = "lblManName"
        Me.lblManName.Size = New System.Drawing.Size(61, 13)
        Me.lblManName.TabIndex = 1
        Me.lblManName.Text = "Manager:"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(12, 34)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(45, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'Customer_Get_ForSiteIDTableAdapter1
        '
        Me.Customer_Get_ForSiteIDTableAdapter1.ClearBeforeFill = True
        '
        'grpPostcodes
        '
        Me.grpPostcodes.Controls.Add(Me.txtPostcode)
        Me.grpPostcodes.Location = New System.Drawing.Point(0, 205)
        Me.grpPostcodes.Name = "grpPostcodes"
        Me.grpPostcodes.Size = New System.Drawing.Size(829, 159)
        Me.grpPostcodes.TabIndex = 2
        Me.grpPostcodes.TabStop = False
        Me.grpPostcodes.Text = "Postcodes"
        '
        'txtPostcode
        '
        Me.txtPostcode.Location = New System.Drawing.Point(15, 25)
        Me.txtPostcode.Multiline = True
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.ReadOnly = True
        Me.txtPostcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPostcode.Size = New System.Drawing.Size(792, 116)
        Me.txtPostcode.TabIndex = 0
        '
        'grpQualifications
        '
        Me.grpQualifications.Controls.Add(Me.txtQual)
        Me.grpQualifications.Location = New System.Drawing.Point(0, 370)
        Me.grpQualifications.Name = "grpQualifications"
        Me.grpQualifications.Size = New System.Drawing.Size(829, 159)
        Me.grpQualifications.TabIndex = 3
        Me.grpQualifications.TabStop = False
        Me.grpQualifications.Text = "Qualifications"
        '
        'txtQual
        '
        Me.txtQual.Location = New System.Drawing.Point(15, 25)
        Me.txtQual.Multiline = True
        Me.txtQual.Name = "txtQual"
        Me.txtQual.ReadOnly = True
        Me.txtQual.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQual.Size = New System.Drawing.Size(792, 116)
        Me.txtQual.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(15, 532)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FRMViewEngineer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(829, 561)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpQualifications)
        Me.Controls.Add(Me.grpPostcodes)
        Me.Controls.Add(Me.grpEngineerInfo)
        Me.MaximumSize = New System.Drawing.Size(845, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(845, 600)
        Me.Name = "FRMViewEngineer"
        Me.Text = "Viewing Engineer : "
        Me.Controls.SetChildIndex(Me.grpEngineerInfo, 0)
        Me.Controls.SetChildIndex(Me.grpPostcodes, 0)
        Me.Controls.SetChildIndex(Me.grpQualifications, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.grpEngineerInfo.ResumeLayout(False)
        Me.grpEngineerInfo.PerformLayout()
        Me.grpPostcodes.ResumeLayout(False)
        Me.grpPostcodes.PerformLayout()
        Me.grpQualifications.ResumeLayout(False)
        Me.grpQualifications.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        Populate()
        LoadForm(sender, e, Me)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _engineer As DataTable = Nothing

    Public Property Engineer() As DataTable
        Get
            Return _engineer
        End Get
        Set(ByVal Value As DataTable)
            _engineer = Value
        End Set
    End Property

#End Region

#Region "Functions"

    Private Sub FRMEngineer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub Populate()
        Me.Text = "Viewing Engineer : " & Engineer(0).Item("Name")

        If Not IsDBNull(Engineer(0).Item("Name")) Then
            Me.txtName.Text = Engineer(0).Item("Name")
        Else
            Me.txtName.Text = "<<No Name set>>"
        End If

        If Not IsDBNull(Engineer(0).Item("TelephoneNum")) Then
            Me.txtPhone.Text = "<<No Phone Number Set>>"
        Else
            Me.txtPhone.Text = Engineer(0).Item("TelephoneNum")
        End If

        If Not IsDBNull(Engineer(0).Item("Region")) Then
            Me.txtRegion.Text = Engineer(0).Item("Region")
        Else
            Me.txtRegion.Text = "<<No Region set>>"
        End If

        If Not IsDBNull(Engineer(0).Item("Manager")) Then
            Me.txtManager.Text = Engineer(0).Item("Manager")
        Else
            Me.txtManager.Text = "<<No Manager set>>"
        End If

        If Not IsDBNull(Engineer(0).Item("Department")) Then
            Me.txtDepartment.Text = Engineer(0).Item("Department")
        Else
            Me.txtDepartment.Text = "<<No Department set>>"
        End If

        If Not IsDBNull(Engineer(0).Item("EngineerGroup")) Then
            Me.txtEngineerGroup.Text = Engineer(0).Item("EngineerGroup")
        Else
            Me.txtEngineerGroup.Text = "<<No Engineer Group set>>"
        End If

        If Not IsDBNull(Engineer(0).Item("PostCodes")) Then
            Me.txtPostcode.Text = Engineer(0).Item("PostCodes")
        Else
            Me.txtPostcode.Text = "<<No PostCodes set >>"
        End If

        If Not IsDBNull(Engineer(0).Item("Qualifications")) Then
            Me.txtQual.Text = Engineer(0).Item("Qualifications")
        Else
            Me.txtQual.Text = "<<No Qualifications set>>"
        End If

    End Sub

#End Region

#Region "Events"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
#End Region


End Class