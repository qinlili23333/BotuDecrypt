Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.IO

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
End Class
