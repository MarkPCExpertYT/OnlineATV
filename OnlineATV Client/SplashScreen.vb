Imports LibVLCSharp.Shared
Imports System.Net
Imports System.Reflection.Emit

Public NotInheritable Class SplashScreen

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        ' Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        Version.Text = Form1.VersionString

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        Try
            IO.File.Delete(Environment.GetFolderPath(26) + "\rtmp.txt")
        Catch ex As Exception
        End Try
        My.Computer.Network.DownloadFile("https://alekeagle.me/hCbGVwu5aF.txt", Environment.GetFolderPath(26) + "\rtmp.txt")
        'IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt")
        If IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt").Contains("rtmp://") = False Then
            MsgBox("Server is unavaible or inactive, channels 1-10 will not work.")
            Return
        End If
        'MsgBox(IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt"))
        Form1.mp = New MediaPlayer(New Media(Form1.libVLC, New Uri(IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt") + "/ch1")))
        Form1.VideoView1.MediaPlayer = Form1.mp
        Form1.Label1.Text = "Please select a channel
Status: To-Do
URL: Unavailable"
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub MainLayoutPanel_Paint(sender As Object, e As PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub
End Class
