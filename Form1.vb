Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.IO
Imports System.Environment
Imports System.Windows
Imports System.ComponentModel

Public Class Form1
    Dim DownloadClient As New WebClient
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler DownloadClient.DownloadProgressChanged, AddressOf ShowDownProgress
        AddHandler DownloadClient.DownloadFileCompleted, AddressOf DownloadFileCompleted
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim url = TextBox1.Text
        Dim ept = ""
        Dim zero As Long = 0
        ProgressBar1.Value = 15
        AxPDFView1.SetCtrlPDFURL(url, ept, ept, zero)
        ProgressBar1.Value = 70
        AxPDFView1.SaveAsDlg(ept, zero)
        AxPDFView1.CloseFile()
        ProgressBar1.Value = 100
    End Sub
    Private Sub ShowDownProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Invoke(New Action(Of Integer)(Sub(i) ProgressBar1.Value = i), e.ProgressPercentage)
    End Sub
    Private Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim htmlText = My.Computer.FileSystem.ReadAllText(Path.GetTempPath + "botu.html")
        Dim expr = ",'http:.*?(?<!,)pdf"
        Dim pdfUrl = ""
        Dim mc As MatchCollection = Regex.Matches(htmlText, expr)
        Dim m As Match
        For Each m In mc
            pdfUrl = Mid(m.ToString, 3)
        Next m
        TextBox1.Text = pdfUrl
        My.Computer.FileSystem.DeleteFile(Path.GetTempPath + "botu.html")
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pdfQuery = HttpUtility.ParseQueryString(New Uri(TextBox2.Text).Query)
        Dim bookid = pdfQuery.GetValues("bookid")(0)
        Dim downloadURL = "http://www.cnbooksearch.com/CheckIpForRead.aspx?bookid=" + bookid
        DownloadClient.DownloadFileAsync(New Uri(downloadURL), Path.GetTempPath + "botu.html")
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        System.Diagnostics.Process.Start("https://github.com/qinlili23333/BotuDecrypt")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        System.Diagnostics.Process.Start("http://www.cnbooksearch.com/")
    End Sub
    Dim Nginx As Process
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Nginx Is Nothing Then
            Directory.SetCurrentDirectory(CurrentDirectory + "\nginx")
            Button2.Text = "正在启动Nginx服务"
            ProgressBar1.Value = 15
            Nginx = Process.Start("nginx.exe")
            If Nginx IsNot Nothing Then
                Button2.Text = "选择文件"
                ProgressBar1.Value = 100
            Else
                Button2.Text = "Nginx服务启动失败"
                ProgressBar1.Value = 0
            End If
        Else
            Dim fd As New OpenFileDialog() With {
                                   .CheckFileExists = True,
                                   .CheckPathExists = True,
                                   .Title = "Select the game file.",
                                   .Multiselect = False,
                                   .RestoreDirectory = True,
                                   .InitialDirectory = CurrentDirectory
                                   }
            If fd.ShowDialog() = Forms.DialogResult.OK Then
                File.Copy(fd.FileName, "html\temp.pdf", True)
                TextBox1.Text = "http://localhost:4399/temp.pdf"
            Else
                ProgressBar1.Value = 0
            End If
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim Proc = Process.GetProcessesByName("nginx")
        If Proc.Length > 0 Then
            For Each ToKill In Proc
                ToKill.Kill()
            Next
        End If
    End Sub
End Class
