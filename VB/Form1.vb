Imports System.Text
Imports System.Diagnostics
Imports System.Globalization
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
' ...

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' A path to export a report.
        Dim reportPath As String = "c:\\Test.txt"

        ' Create a report instance.
        Dim report As New XtraReport1()

        ' Get its Text export options.
        Dim txtOptions As TextExportOptions = report.ExportOptions.Text

        ' Set Text-specific export options.
        txtOptions.Encoding = Encoding.Unicode
        txtOptions.Separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator.ToString()

        ' Export the report to Text.
        report.ExportToText(reportPath)

        ' Show the result.
        StartProcess(reportPath)
    End Sub

    ' Use this method if you want to automaically open
    ' the created Text file in the default program.
    Public Sub StartProcess(ByVal path As String)
        Dim process As New Process()
        Try
            process.StartInfo.FileName = path
            process.Start()
            process.WaitForInputIdle()
        Catch
        End Try
    End Sub
End Class
