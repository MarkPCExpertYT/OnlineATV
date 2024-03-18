Public Class HowTo
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = IO.File.ReadAllText(Environment.GetFolderPath(26) + "\rtmp.txt")
        'For Each x As RadioButton In Me.Controls
        '    If x.GetType() Then
        '        If x.Checked = True Then
        '        If Not x.Name.Contains("RRadioButton") Then
        '            TextBox2.Text = "ch" & x.Name.Remove(0, 12)
        '        End If
        '    End If
        'Next
        If RadioButton1.Checked = True Then TextBox2.Text = "ch1"
        If RadioButton2.Checked = True Then TextBox2.Text = "ch2"
        If RadioButton3.Checked = True Then TextBox2.Text = "ch3"
        If RadioButton4.Checked = True Then TextBox2.Text = "ch4"
        If RadioButton5.Checked = True Then TextBox2.Text = "ch5"
        If RadioButton6.Checked = True Then TextBox2.Text = "ch6"
        If RadioButton7.Checked = True Then TextBox2.Text = "ch7"
        If RadioButton8.Checked = True Then TextBox2.Text = "ch8"
        If RadioButton9.Checked = True Then TextBox2.Text = "ch9"
        If RadioButton10.Checked = True Then TextBox2.Text = "ch10"
        TabControl1.SelectTab(TabControl1.SelectedIndex + 1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.SelectTab(TabControl1.SelectedIndex + 1)
    End Sub
End Class