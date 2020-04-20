Namespace Entity

    Namespace Sys

        Public Class SignatureBox

#Region "Variables"

            Private oldX As Int32
            Private oldY As Int32
            Private bmp As System.Drawing.Bitmap
            Private SigArrayXO(2500) As Integer
            Private SigArrayYO(2500) As Integer
            Private SigDataO As String = ""
            Private SigMovesO As Integer
            Private startedSig As Boolean = False
            Private isMouseDown As Boolean = False
            Private pointNumber As Integer = 0
            Private firstTime As Boolean = True
            Private pointsArray As New ArrayList
            Private isReadOnlyVar As Boolean = False
            Private gphDraw As System.Drawing.Graphics
            Private WithEvents Signature As New PictureBox

#End Region

#Region "Properties"

            Public Property isReadOnly() As Boolean
                Get
                    Return isReadOnlyVar
                End Get
                Set(ByVal Value As Boolean)
                    isReadOnlyVar = Value
                End Set
            End Property

            Public ReadOnly Property getSignatureText() As String
                Get
                    On Error Resume Next
                    Dim j As Int32
                    Dim sigData As String

                    For j = 0 To SigMovesO - 1
                        sigData = sigData & PadHex(SigArrayXO(j)) & PadHex(SigArrayYO(j))
                    Next

                    Return sigData
                End Get
            End Property

            Public ReadOnly Property hasSigned() As Boolean
                Get
                    Return startedSig
                End Get
            End Property

#End Region

#Region "Private Utility Methods"

            Private Function PadHex(ByVal inNum As Integer) As String
                Dim tempNum As String
                tempNum = "0" + String.Format("{0:X8}", inNum)
                Return tempNum.Substring(tempNum.Length - 2, 2)
            End Function

            Private Function reversePadHex(ByVal inHex As String) As Integer
                Return unHex(inHex)
            End Function

            Private Function convertChar(ByVal charIn As Char) As Integer
                Dim returnInt As New Integer
                Try
                    returnInt = CInt(charIn.ToString)
                Catch ex As Exception
                    Select Case (charIn)
                        Case "A"c
                            returnInt = 10

                        Case "B"c
                            returnInt = 11

                        Case "C"c
                            returnInt = 12

                        Case "D"c
                            returnInt = 13

                        Case "E"c
                            returnInt = 14

                        Case "F"c
                            returnInt = 15

                        Case Else
                            returnInt = Nothing

                    End Select
                End Try
                Return returnInt
            End Function

            Private Function unHex(ByVal hexIn As String) As Integer
                Dim charStack As New Stack

                Dim total As New Integer
                total = 0
                For Each c As Char In hexIn
                    charStack.Push(c)
                Next
                Dim worth As Integer = 0
                For Each c As Char In charStack
                    total = total + CInt((convertChar(c) * 16 ^ worth))
                    worth += 1
                Next
                Return total
            End Function

            Private Sub setupSignature()
                bmp = New Bitmap(Signature.Width, Signature.Height)
                gphDraw = Graphics.FromImage(bmp)
                gphDraw.FillRectangle( _
                    New SolidBrush(Color.White), _
                    New Rectangle(0, 0, Signature.Width, Signature.Height))
                gphDraw.DrawRectangle( _
                    New System.Drawing.Pen(System.Drawing.Color.Black), _
                    New Rectangle(0, 0, Signature.Width - 1, _
                    Signature.Height - 1))
                Signature.Image = bmp
                Signature.Refresh()

                Application.DoEvents()
            End Sub

#End Region

#Region "Event Handlers"

            Private Sub Signature_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Signature.MouseDown
                Try
                    If Not isReadOnlyVar Then
                        oldX = e.X
                        oldY = e.Y
                        SigArrayXO(SigMovesO) = e.X
                        SigArrayYO(SigMovesO) = e.Y + 128
                        SigMovesO += 1
                        startedSig = True
                        isMouseDown = True
                    End If
                Catch ex As IndexOutOfRangeException
                    MessageBox.Show("Signature is too large!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End Try
            End Sub

            Private Sub Signature_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Signature.MouseMove
                If isMouseDown And Not isReadOnlyVar Then
                    Try
                        Dim p As New System.Drawing.Pen(System.Drawing.Color.Black)
                        gphDraw.DrawLine(p, oldX, oldY, e.X, e.Y)

                        oldX = e.X
                        oldY = e.Y
                        SigArrayXO(SigMovesO) = oldX
                        SigArrayYO(SigMovesO) = oldY
                        SigMovesO += 1
                        Signature.Image = bmp
                        startedSig = True
                    Catch

                    End Try
                End If
            End Sub

            Private Sub Signature_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Signature.MouseUp
                isMouseDown = False
            End Sub

#End Region

#Region "Public Methods"

            Public Sub New(ByRef pic As PictureBox)
                Signature = pic
                Me.setupSignature()
            End Sub

            Public Sub ClearSignature()
                setupSignature()
                Array.Clear(SigArrayXO, 0, SigArrayXO.Length)
                Array.Clear(SigArrayYO, 0, SigArrayYO.Length)
                SigDataO = ""
                SigMovesO = 0
                firstTime = True
                pointNumber = 0
                startedSig = False
            End Sub

            Public Sub plotSignature(ByVal signatureText As String)
                Dim sigPos As Integer = 0
                Dim plotX As Integer = 0
                Dim plotXOld As Integer = 0
                Dim plotY As Integer = 0
                Dim plotYOld As Integer = 0
                Dim sX, sY As String
                Dim multiplier As Double = 0.7
                Try

                    If Not (signatureText) = "" Then

                        If (signatureText.Length > 0) Then

                            plotXOld = Integer.Parse(signatureText.Substring(sigPos, 2), System.Globalization.NumberStyles.AllowHexSpecifier)
                            plotYOld = Integer.Parse(signatureText.Substring(sigPos + 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier)
                            While (sigPos < signatureText.Length)
                                sX = signatureText.Substring(sigPos, 2)
                                sY = signatureText.Substring(sigPos + 2, 2)
                                Try
                                    plotX = Integer.Parse(sX, System.Globalization.NumberStyles.AllowHexSpecifier)
                                    plotY = Integer.Parse(sY, System.Globalization.NumberStyles.AllowHexSpecifier)
                                Catch fe As System.FormatException
                                    MessageBox.Show(fe.Message)
                                End Try
                                If plotY > 127 Then
                                    plotXOld = plotX
                                    plotYOld = plotY - 128
                                Else

                                    gphDraw.DrawLine(New System.Drawing.Pen(System.Drawing.Color.Black), New PointF(plotXOld * multiplier, plotYOld * multiplier), New PointF(plotX * multiplier, plotY * multiplier))


                                    plotXOld = plotX
                                    plotYOld = plotY
                                End If
                                sigPos = sigPos + 4

                                SigArrayXO(CInt((sigPos / 4)) - 1) = plotXOld
                                SigArrayYO(CInt((sigPos / 4)) - 1) = plotYOld

                            End While
                        End If

                        SigMovesO = CInt(sigPos / 4)
                        Signature.Image = bmp
                        Signature.Refresh()
                        Application.DoEvents()
                    End If
                Catch ex As Exception
                    MsgBox("Unable to map this string!", MsgBoxStyle.Exclamation, "Error")
                End Try
            End Sub

            Public Function getBitmap() As Bitmap
                Return CType(Signature.Image, Bitmap)
            End Function

#End Region

        End Class

    End Namespace

End Namespace