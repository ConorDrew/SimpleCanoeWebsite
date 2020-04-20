Imports System.Collections.Generic

Public Class FRMDuplicateInvoices : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal duplicateInvoices As List(Of Importer.DuplicateInvoice))
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _duplicateInvoices = duplicateInvoices

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

    Friend WithEvents tcData As TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tcData = New System.Windows.Forms.TabControl()
        Me.SuspendLayout()
        '
        'tcData
        '
        Me.tcData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcData.Location = New System.Drawing.Point(0, 32)
        Me.tcData.Name = "tcData"
        Me.tcData.SelectedIndex = 0
        Me.tcData.Size = New System.Drawing.Size(1008, 430)
        Me.tcData.TabIndex = 9
        '
        'FRMDuplicateInvoices
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1008, 462)
        Me.Controls.Add(Me.tcData)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(848, 496)
        Me.Name = "FRMDuplicateInvoices"
        Me.Text = "Job Portal - Duplicate Imports"
        Me.Controls.SetChildIndex(Me.tcData, 0)
        Me.ResumeLayout(False)

    End Sub

    Private _duplicateInvoices As New List(Of Importer.DuplicateInvoice)

    Private ReadOnly Property DuplicateInvoices() As List(Of Importer.DuplicateInvoice)
        Get
            Return _duplicateInvoices
        End Get
    End Property

#End Region

#Region "Interface Methods"

    Public ReadOnly Property LoadedControl() As IUserControl
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub FRMDuplicateInovoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.tcData.TabPages.Clear()

        Dim tp As New TabPage
        Dim dt As DataTable = Entity.Sys.Helper.ToDataTable(DuplicateInvoices)
        Dim dv As DataView = New DataView(dt)

        Dim data As New UCDataPODuplicateInvoice
        data.Dock = DockStyle.Fill
        data.Data = dv

        tp.Controls.Add(data)
        Me.tcData.TabPages.Add(tp)
        Me.tcData.SelectedIndex = 0
    End Sub

    Private Sub FRMDuplicateInvoices_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            'check user wants to close window
            If e.CloseReason = CloseReason.FormOwnerClosing OrElse e.CloseReason = CloseReason.UserClosing Then
                If MsgBox("Are you sure?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Form closing") = MsgBoxResult.No Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

End Class