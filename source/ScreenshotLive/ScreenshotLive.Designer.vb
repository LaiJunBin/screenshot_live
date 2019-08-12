<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScreenshotLive
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SwitchCaptureScreenButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SwitchCaptureScreenButton
        '
        Me.SwitchCaptureScreenButton.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SwitchCaptureScreenButton.Location = New System.Drawing.Point(13, 13)
        Me.SwitchCaptureScreenButton.Name = "SwitchCaptureScreenButton"
        Me.SwitchCaptureScreenButton.Size = New System.Drawing.Size(259, 112)
        Me.SwitchCaptureScreenButton.TabIndex = 0
        Me.SwitchCaptureScreenButton.Text = "Start Capture Screen"
        Me.SwitchCaptureScreenButton.UseVisualStyleBackColor = True
        '
        'ScreenshotLive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 140)
        Me.Controls.Add(Me.SwitchCaptureScreenButton)
        Me.Name = "ScreenshotLive"
        Me.Text = "ScreenshotLive"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SwitchCaptureScreenButton As System.Windows.Forms.Button
End Class
