Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Threading

Public Class ScreenshotLive

    Dim CaptureScreenRunning As Boolean = False
    Dim CaptureScreenThread As Thread

    Const ScreenshotPath As String = "ScreenshotLive/screen.png"

    Private Sub ScreenshotLive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CaptureScreenThread = New Thread(
            Sub()
                While True
                    If CaptureScreenRunning Then
                        captureScreen(ScreenshotPath)
                    End If
                End While
            End Sub
        )

        CaptureScreenThread.Start()
    End Sub

    Private Sub ScreenshotLive_Close() Handles MyBase.FormClosed
        CaptureScreenRunning = False
        Do While My.Computer.FileSystem.FileExists(ScreenshotPath)
            Try
                My.Computer.FileSystem.DeleteFile(ScreenshotPath)
            Catch ex As Exception
            End Try
        Loop
        End
    End Sub

    Sub captureScreen(ByVal filename As String)

        Dim graph As Graphics = Nothing

        Try
            Dim frmleft = My.Computer.Screen.WorkingArea
            Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
            Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
            Dim bmp As New Bitmap(screenWidth, screenHeight)
            graph = Graphics.FromImage(bmp)
            Dim screenx As Integer = frmleft.X
            Dim screeny As Integer = frmleft.Y
            graph.CopyFromScreen(screenx, screeny, 0, 0, bmp.Size)
            bmp.Save(filename)
            bmp.Dispose()
            graph.Dispose()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SwitchCaptureScreenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchCaptureScreenButton.Click
        CaptureScreenRunning = Not CaptureScreenRunning
        SwitchCaptureScreenButton.Text = If(CaptureScreenRunning, "Running...", "Start Capture Screen")
    End Sub
End Class