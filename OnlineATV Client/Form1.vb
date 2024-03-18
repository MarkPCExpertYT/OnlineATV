Imports System.Net
Imports System.Security
Imports LibVLCSharp.[Shared]

Public Class Form1
    Public PlayerGraphics As Graphics
    Public libVLC = New LibVLC()
    Public WithEvents mp As MediaPlayer
    Public CurrentChannel As Int32 = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreen.Show()
        SplashScreen.Refresh()

        Try
            IO.File.Delete(Environment.GetFolderPath(26) + "\rtmp.txt")
        Catch ex As Exception
        End Try
        Dim client As WebClient = New WebClient()
        client.Credentials = New NetworkCredential("ezyro_35056950", "di4pwp5em")
        client.DownloadFile("ftp://ftpupload.net/htdocs/rtmp.txt", Environment.GetFolderPath(26) + "\rtmp.txt")
        'IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt")
        If IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt").Contains("rtmp://") = False Then
            MsgBox("Server is unavaible or inactive, channels 1-10 will not work.")
            Return
        End If
        'MsgBox(IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt"))
        mp = New MediaPlayer(New Media(libVLC, New Uri(IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt") + "/ch1")))
        VideoView1.MediaPlayer = mp
        Label1.Text = "Please select a channel
Status: None
URL: Unavailable"
        SplashScreen.Close()
        PlayerGraphics = VideoView1.CreateGraphics()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Panel1.Visible = True Then
            Panel1.Hide()
        Else
            Panel1.Show()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mp.Stop()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If mp.Mute = True Then
            Button2.Text = "Mute"
        Else
            Button2.Text = "Unmute"
        End If
        mp.ToggleMute()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        mp.Stop()
        mp.Media.Dispose()
        'My.Computer.Network.DownloadFile("http://hyperactive.ezyro.com/rtmp.txt", Environment.GetFolderPath(26) + "\rtmp.txt")
        'MsgBox(IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt") + "/ch" + Convert.ToString(ListView1.SelectedIndices(0) + 1))
        VideoView1.MediaPlayer = Nothing
        If ListView1.SelectedIndices(0) + 1 = 11 Then
            Dim customin As String = InputBox("Please enter an RTMP URL", "OnlineATV Client")
            If Not String.IsNullOrWhiteSpace(customin) Then
                Try
                    mp.Media = New Media(libVLC, New Uri(customin))
                Catch ex As Exception
                    MsgBox("Invalid URL")
                    Return
                End Try
            Else
                MsgBox("URL can't be blank")
                Return
            End If
            Label1.Text = "Custom channel
Status: Waiting on LibVLC...
URL: " & customin
            VideoView1.MediaPlayer = mp
            mp.Play()
            PlayerGraphics.DrawString("C", New Font("MS Gothic", 16, FontStyle.Bold), Brushes.Lime, New PointF(32, 32))
            Timer1.Start()
            Return
        End If
        mp.Media = New Media(libVLC, New Uri(IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt") + "/ch" + Convert.ToString(ListView1.SelectedIndices(0) + 1)))
        VideoView1.MediaPlayer = mp
        mp.Play()
        Label1.Text = "Channel " & Convert.ToString(ListView1.SelectedIndices(0) + 1) & "
Status: Waiting on LibVLC...
URL: " & IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt") + "/ch" + Convert.ToString(ListView1.SelectedIndices(0) + 1)
        PlayerGraphics.DrawString(Convert.ToString(ListView1.SelectedIndices(0) + 1), New Font("MS Gothic", 16, FontStyle.Bold), Brushes.Lime, New PointF(32, 32))
        Timer1.Start()
        Timer2.Start()
        CurrentChannel = ListView1.SelectedIndices(0) + 1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        HowTo.Show()
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.D1 OrElse e.KeyCode = Keys.D2 OrElse e.KeyCode = Keys.D3 OrElse e.KeyCode = Keys.D4 OrElse e.KeyCode = Keys.D5 OrElse e.KeyCode = Keys.D6 OrElse e.KeyCode = Keys.D7 OrElse e.KeyCode = Keys.D8 OrElse e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0 Then
            If e.KeyCode = Keys.D1 Then OATVSwitchChannel(1)
            If e.KeyCode = Keys.D2 Then OATVSwitchChannel(2)
            If e.KeyCode = Keys.D3 Then OATVSwitchChannel(3)
            If e.KeyCode = Keys.D4 Then OATVSwitchChannel(4)
            If e.KeyCode = Keys.D5 Then OATVSwitchChannel(5)
            If e.KeyCode = Keys.D6 Then OATVSwitchChannel(6)
            If e.KeyCode = Keys.D7 Then OATVSwitchChannel(7)
            If e.KeyCode = Keys.D8 Then OATVSwitchChannel(8)
            If e.KeyCode = Keys.D9 Then OATVSwitchChannel(9)
            If e.KeyCode = Keys.D0 Then OATVSwitchChannel(10)
        End If

        If My.Computer.Keyboard.AltKeyDown = True Then
            If Not e.KeyCode = Keys.Enter Then
                If FMainActive = True Then
                    If MenuStrip1.Visible = True Then MenuStrip1.Hide() Else MenuStrip1.Show()
                End If
            End If
        End If
    End Sub

    Public Function OATVSwitchChannel(channel As Int16) As Integer
        mp.Stop()
        mp.Media.Dispose()
        'My.Computer.Network.DownloadFile("http://hyperactive.ezyro.com/rtmp.txt", Environment.GetFolderPath(26) + "\rtmp.txt")
        'MsgBox(IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt") + "/ch" + Convert.ToString(ListView1.SelectedIndices(0) + 1))
        VideoView1.MediaPlayer = Nothing
        mp.Media = New Media(libVLC, New Uri(IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt") + "/ch" + Convert.ToString(channel)))
        VideoView1.MediaPlayer = mp
        mp.Play()
        Label1.Text = "Channel " & Convert.ToString(channel) & "
Status: Waiting on LibVLC...
URL: " & IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt") + "/ch" + Convert.ToString(channel)
        PlayerGraphics.DrawString(Convert.ToString(channel), New Font("MS Gothic", 16, FontStyle.Bold), Brushes.Lime, New PointF(32, 32))
        Timer1.Start()
        Timer2.Start()
        CurrentChannel = channel
        Return 0
    End Function

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        mp.Volume = TrackBar1.Value
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PlayerGraphics.Clear(Color.Transparent)
        Timer1.Stop()
    End Sub

    Private Sub VideoView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles VideoView1.MouseDoubleClick
        ExitFullScreen()
    End Sub

    Private Sub EnterFullScreen()
        SplitContainer1.Hide()
        Panel1.Hide()
        MenuStrip1.Hide()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub ExitFullScreen()
        SplitContainer1.Show()
        Panel1.Show()
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.WindowState = FormWindowState.Normal
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox("Press alt-enter to exit fullscreen", MsgBoxStyle.Information, "OnlineATV Client")
        EnterFullScreen()
    End Sub
    Dim StateVal As String = "Unknown"
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'If mp.State = VLCState.Buffering Then StateVal = "Buffering"
        'If mp.State = VLCState.Opening Then StateVal = "Opening"
        'If mp.State = VLCState.Playing Then StateVal = "Playing"
        'If mp.State = VLCState.Error Then StateVal = "Error"
        'If mp.State = VLCState.Ended Then StateVal = "Ended"
        'If mp.State = VLCState.Paused Then StateVal = "Paused"
        'If mp.State = VLCState.Stopped Then StateVal = "Stopped"
        Try
            Label1.Text = "Channel " & CurrentChannel.ToString & "
Status: " & StateVal & "
URL: " & IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt") + "/ch" + CurrentChannel.ToString
        Catch ex As Exception

        End Try
    End Sub

    Public Sub mp_Buffering() Handles mp.Buffering
        StateVal = "Buffering"
        PictureBox1.Show()
        PictureBox1.Image = My.Resources.nois2
    End Sub
    Public Sub mp_playing() Handles mp.Playing
        StateVal = "Playing"
        PictureBox1.Hide()
    End Sub
    Public Sub mp_opening() Handles mp.Opening
        StateVal = "Opening"
        PictureBox1.Show()
        PictureBox1.Image = My.Resources.nois2
    End Sub
    Public Sub mp_error() Handles mp.EncounteredError
        StateVal = "Error"
        PictureBox1.Show()
        PictureBox1.Image = My.Resources.noise
    End Sub
    Public Sub mp_endreached() Handles mp.EndReached
        StateVal = "Ended"
        PictureBox1.Show()
        PictureBox1.Image = My.Resources.noise
    End Sub
    Public Sub mp_paused() Handles mp.Paused
        StateVal = "Paused"
        PictureBox1.Hide()
    End Sub
    Public Sub mp_stopped() Handles mp.Stopped
        StateVal = "Stopped"
        PictureBox1.Show()
        PictureBox1.Image = My.Resources.noise
    End Sub
    Public Sub mp_nothing() Handles mp.TimeChanged
        StateVal = "Playing (" & Math.Round(mp.Time / 1000) & " seconds)"
        PictureBox1.Hide()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter AndAlso e.Alt = True Then
            ExitFullScreen()
            e.Handled = True
        End If
    End Sub

    Private Sub DisableNoiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableNoiseToolStripMenuItem.Click
        If DisableNoiseToolStripMenuItem.Checked = True Then
            PictureBox1.Dock = DockStyle.None
            PictureBox1.SendToBack()
        Else
            PictureBox1.Dock = DockStyle.Fill
            PictureBox1.BringToFront()
        End If
    End Sub

    Private Sub CustomChannelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomChannelToolStripMenuItem.Click
        Dim customin As String = InputBox("Please enter an RTMP URL", "OnlineATV Client")
        mp.Media = New Media(libVLC, New Uri(customin))
        Label1.Text = "Custom channel
Status: Waiting on LibVLC...
URL: " & customin
        VideoView1.MediaPlayer = mp
        mp.Play()
        PlayerGraphics.DrawString("Custom", New Font("MS Gothic", 16, FontStyle.Bold), Brushes.Lime, New PointF(32, 32))
        Timer1.Start()
        Timer2.Start()
    End Sub

    Private Sub FullscreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullscreenToolStripMenuItem.Click
        MsgBox("Press alt+enter to exit fullscreen", MsgBoxStyle.Information, "OnlineATV Client")
        EnterFullScreen()
    End Sub

    Private Sub ShowhideInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowhideInfoToolStripMenuItem.Click
        If Panel1.Visible = True Then
            Panel1.Hide()
            ShowhideInfoToolStripMenuItem.Checked = True
        Else
            Panel1.Show()
            ShowhideInfoToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub MuteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MuteToolStripMenuItem.Click
        If mp.Mute = True Then
            MuteToolStripMenuItem.Checked = False
        Else
            MuteToolStripMenuItem.Checked = True
        End If
        mp.ToggleMute()
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click
        mp.Stop()
    End Sub

    Private Sub HowDoIStreamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HowDoIStreamToolStripMenuItem.Click
        HowTo.Show()
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        mp.Stop()
        mp.Play()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If My.Computer.Keyboard.AltKeyDown = True Then
            Me.Form1_KeyUp(Me, New KeyEventArgs(Keys.None))
        End If
    End Sub
    Public FMainActive As Boolean
    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FMainActive = False
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FMainActive = True
    End Sub
End Class
