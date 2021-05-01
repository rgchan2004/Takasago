
Imports System.Data
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports DuoVia.FuzzyStrings
Imports Syncfusion.Pdf
Imports Syncfusion.DocIO
Imports Syncfusion.DocIO.DLS
Imports Syncfusion.DocToPDFConverter
Imports Syncfusion.XlsIO
Imports System.Data.SqlClient
Imports Scripting
Imports Syncfusion.Pdf.Graphics
Imports System.Drawing
Imports Syncfusion.Pdf.Parsing
Imports Newtonsoft.Json

Public Class MainForm
    Public bigData As New DataTable
    Public dt, dt3, productMasterDT, shiptoDT, poDT As New DataTable
    Public searchData As New DataTable
    Public webSearchData As New DataTable
    Public tender As String
    Public endSection As Boolean
    Public unitPriceColumn, qtyColumn, itemColumn As Integer
    Public defaultFolder As String = "C:\AIOfflines\"
    'Public databaseFolder As String = "C:\Users\dch\OneDrive - DCH Holdings Limited (1)\HospitalDatabase\OrderFiles"
    Public databaseFolder As String = "c:\HospitalDatabase\OrderFiles"
    Public rpaFolder As String = "C:\HospitalDatabase\RPAInbound\"
    'Public pdfFolder As String = "C:\Users\dch\OneDrive - DCH Holdings Limited (1)\HospitalDatabase\PdfOrderFiles"
    Public pdfFolder As String = "C:\HospitalDatabase\PdfOrderFiles"
    Public hospitalSelected As String = "SingHealth"
    Public POtoProcess As String
    Dim folderName As String
    Public consString As String = "Data Source=DESKTOP-S3PGIOO\SQLEXPRESS;User ID=lynn;Password=Skm9627j#;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
    'Public consString As String = "Data Source=SGPRPASERVER\SQLEXPRESS;User ID=sa;Password=abcd1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

    Private Sub StartLearningButton_Click(sender As Object, e As EventArgs)
        'Dim folder = "C:\Users\user\Documents\GitHubSurfacePro\OfflineOrders"
        Dim folder = "C:\Users\user\Documents\AI Documents"
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"

        Dim dt2, dt3 As New DataTable
        'Dim bigData As New DataTable

        'initialize values
        endSection = False
        tender = "none"
        dt.Rows.Clear()
        bigData.Clear()

        DataGridBigData.DataSource = bigData

        'Using Adp As New OleDbDataAdapter("select * from [OutputKeyValue.csv]", CnStr)
        '    Adp.Fill(dt2)
        'End Using
        'DataGridViewPairValue.DataSource = dt2

        'Using Adp As New OleDbDataAdapter("select * from [OutputLines.csv]", CnStr)
        '    Adp.Fill(dt3)
        'End Using
        'DataGridViewLines.DataSource = dt3
        'With dt
        '.Columns.Add("A1", System.Type.GetType("System.String"))
        '.Columns.Add("A2", System.Type.GetType("System.String"))
        '.Columns.Add("A3", System.Type.GetType("System.String"))
        '.Columns.Add("A4", System.Type.GetType("System.String"))
        '.Columns.Add("A5", System.Type.GetType("System.String"))
        'End With

        'Dim thereader1 As New IO.StreamReader("C:\Users\user\Documents\GitHubSurfacePro\OfflineOrders\OutputTables.csv", System.Text.Encoding.Default)
        Dim thereader1 As New IO.StreamReader("C:\Users\user\Documents\AI Documents\OutputTables.csv", System.Text.Encoding.Default)

        Dim numOfLines = 0
        Dim sline1 As String = ""
        Do
            sline1 = thereader1.ReadLine
            If sline1 Is Nothing Then Exit Do
            Dim thecolumns() As String = sline1.Split(vbTab)
            If (thecolumns.Length() > 1) Then
                Dim tenderStr = GetTender(thecolumns(2))
                If (tenderStr <> "none") Then
                    'MessageBox.Show("tender is " + tenderStr)
                    tender = tenderStr
                End If
            End If
            numOfLines += 1
        Loop
        thereader1.Close()

        SearchProgressBar.Minimum = 0
        SearchProgressBar.Maximum = numOfLines

        Dim thereader As New IO.StreamReader("C:\Users\user\Documents\AI Documents\OutputTables.csv", System.Text.Encoding.Default)
        Dim sline As String = ""
        Do
            sline = thereader.ReadLine
            If sline Is Nothing Then Exit Do
            Dim thecolumns() As String = sline.Split(vbTab)
            Dim newrow As DataRow = dt.NewRow
            'For index As Integer = 0 To thecolumns.Length() - 1
            'newrow(index) = thecolumns(index)
            'Next
            newrow(0) = thecolumns(0)
            If (thecolumns.Length() = 3) Then
                newrow(1) = thecolumns(1) + thecolumns(2)
            ElseIf (thecolumns.Length() = 2) Then
                newrow(1) = thecolumns(1)
            ElseIf (thecolumns.Length() > 3) Then
                newrow(1) = thecolumns(1) + thecolumns(2)
                newrow(2) = thecolumns(3)
            End If

            If ((newrow(0).ToString() <> "") And Not (newrow(0).ToString().StartsWith("Table"))) Then
                'Marker(newrow)
                ParseDataRowBigData(tender, newrow)
                dt.Rows.Add(newrow)
            End If
            SearchProgressBar.Increment(1)
            System.Threading.Thread.Sleep(100)
        Loop
        thereader.Close()

        DataGridViewResponses.DataSource = dt
        DataGridViewResponses.Columns(0).Width = 400
        DataGridViewResponses.Columns(1).Width = 300
        DataGridViewResponses.Columns(2).Width = 10
        DataGridViewResponses.Columns(3).Width = 300
        DataGridViewResponses.Columns(4).Width = 10
        DataGridViewResponses.Columns(5).Width = 10
        DataGridViewResponses.Columns(6).Width = 800
        DataGridViewResponses.Columns(7).Width = 100


        'DataGridViewResponses.AutoResizeColumns()
        DataGridViewResponses.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewResponses.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(5).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(7).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'DataGridViewPairValue.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewPairValue.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewLines.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewLines.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        RemarksTextField.Text = tender

    End Sub


    Private Sub NTUCHealth_HandRespondClick(sender As Object, e As EventArgs)

        Dim folder = defaultFolder & "memory"
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"

        Dim dt2 As New DataTable

        'initialize
        dt.Rows.Clear()
        endSection = False
        tender = "none"

        'Using Adp As New OleDbDataAdapter("select * from [OutputKeyValue.csv]", CnStr)
        '    Adp.Fill(dt2)
        'End Using
        'DataGridViewPairValue.DataSource = dt2

        'Using Adp As New OleDbDataAdapter("select * from [OutputLines.csv]", CnStr)
        '    Adp.Fill(dt3)
        'End Using
        'DataGridViewLines.DataSource = dt3

        Dim thereaderLine As New IO.StreamReader(folder & "\interim-pdf-page-1-text.txt", System.Text.Encoding.Default)

        'Only for Parkway
        Dim shipTo As String = ""
        Dim ctr As Integer = 0

        Do
            shipTo = thereaderLine.ReadLine
            ctr += 1
            If ctr = 2 Then
                TextBoxShipTo.Text = shipTo
                Exit Do
            End If
        Loop

        Dim thereader As New IO.StreamReader(folder & "\OutputTables.csv", System.Text.Encoding.Default)
        SearchProgressBar.Minimum = 0
        SearchProgressBar.Maximum = 100
        SearchProgressBar.Value = 0

        Dim sline As String = ""
        Do
            sline = thereader.ReadLine
            If sline Is Nothing Then Exit Do
            Dim thecolumns() As String = sline.Split(vbTab)
            Dim newrow As DataRow = dt.NewRow
            Dim newrowItem As DataRow = dt3.NewRow

            If (dt3.Rows.Count = 0) Then
                'newrowItem(0) = "Item"
                'newrowItem(1) = "Unit Price"
                'newrowItem(2) = "Qty"
                'newrowItem(3) = "Remarks"
                newrowItem(0) = ""
                newrowItem(1) = ""
                newrowItem(2) = ""
                newrowItem(3) = ""
            Else
                newrowItem(0) = "0000"
                newrowItem(1) = "0.00"
                newrowItem(2) = "0"
            End If

            For index As Integer = 0 To thecolumns.Length() - 1
                newrow(index) = thecolumns(index)
            Next

            If ((newrow(0).ToString() <> "") And Not (newrow(0).ToString().StartsWith("Table"))) Then
                ParseDataRowParkWay(newrow, thecolumns.Length())
                dt.Rows.Add(newrow)
                dt3.Rows.Add(newrowItem)
            End If
            SearchProgressBar.Increment(1)
        Loop
        thereader.Close()
        SearchProgressBar.Value = SearchProgressBar.Maximum

        DataGridViewResponses.DataSource = dt
        DataGridViewResponses.Columns(0).Width = 100
        DataGridViewResponses.Columns(1).Width = 300
        DataGridViewResponses.Columns(2).Width = 50
        DataGridViewResponses.Columns(3).Width = 30
        DataGridViewResponses.Columns(4).Width = 60
        DataGridViewResponses.Columns(5).Width = 60
        DataGridViewResponses.Columns(6).Width = 250
        DataGridViewResponses.Columns(7).Width = 50
        DataGridViewResponses.Columns(8).Width = 70
        DataGridViewLines.RowHeadersVisible = True

        DataGridViewResponses.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        'DataGridViewResponses.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(6).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewResponses.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(7).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewLines.DataSource = dt3
        DataGridViewLines.RowHeadersVisible = False

        RemarksTextField.Text = tender

    End Sub
    Private Sub ParkWayResponse_Click(sender As Object, e As EventArgs) Handles RespondButton.Click

        Dim folder = defaultFolder & "memory"
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"

        Dim dt2 As New DataTable

        'determine which hospital
        If (RadioButtonParkway.Checked) Then
            'Parkway Hospital
        End If


        'initialize
        dt.Rows.Clear()
        dt3.Rows.Clear()

        endSection = False
        tender = "none"

        Dim thereaderLine As New IO.StreamReader(folder & "\interim-pdf-page-1-text.txt", System.Text.Encoding.Default)

        'Only for Parkway
        Dim shipTo As String = ""
        Dim ctr As Integer = 0

        Do
            shipTo = thereaderLine.ReadLine

            If (shipTo Is Nothing) Then
                Continue Do
            End If

            ctr += 1
            If ctr = 2 Then
                TextBoxShipTo.Text = shipTo
            End If

            If (shipTo.Contains("P/O No:")) Then
                Dim po_line As String = thereaderLine.ReadLine
                TextBoxPO.Text = po_line
                Exit Do
            End If
        Loop

        Dim thereader As New IO.StreamReader(folder & "\OutputTables.csv", System.Text.Encoding.Default)
        SearchProgressBar.Minimum = 0
        SearchProgressBar.Maximum = 100
        SearchProgressBar.Value = 0

        Dim sline As String = ""
        Do
            sline = thereader.ReadLine
            If sline Is Nothing Then Exit Do
            Dim thecolumns() As String = sline.Split(vbTab)
            Dim newrow As DataRow = dt.NewRow
            Dim newrowItem As DataRow = dt3.NewRow

            For index As Integer = 0 To thecolumns.Length() - 1
                newrow(index) = thecolumns(index)
            Next

            If (dt3.Rows.Count = 0) Then
                newrowItem(0) = "Item"
                newrowItem(1) = "Unit Price"
                newrowItem(2) = "Qty"
            Else
                newrowItem(1) = newrow(unitPriceColumn)

                'get qty
                Dim str As String = newrow(qtyColumn).ToString
                Dim regex As Regex = New Regex("\d+")

                Dim match As Match = regex.Match(str)

                If (match.Success) Then
                    newrowItem(2) = match.Value
                Else
                    newrowItem(2) = newrow(qtyColumn)
                End If


            End If

            If ((newrow(0).ToString() <> "") And Not (newrow(0).ToString().StartsWith("Table")) And Not (String.IsNullOrEmpty(newrow(unitPriceColumn).ToString))) Then
                ParseDataRowParkWay(newrow, thecolumns.Length())
                dt.Rows.Add(newrow)
                dt3.Rows.Add(newrowItem)
            End If

            SearchProgressBar.Increment(1)
        Loop
        thereader.Close()

        SearchProgressBar.Value = SearchProgressBar.Maximum

        DataGridViewResponses.DataSource = dt
        DataGridViewResponses.RowHeadersVisible = False
        DataGridViewResponses.Columns(0).Width = 200
        DataGridViewResponses.Columns(1).Width = 100
        DataGridViewResponses.Columns(2).Width = 50
        DataGridViewResponses.Columns(3).Width = 30
        DataGridViewResponses.Columns(4).Width = 60
        DataGridViewResponses.Columns(5).Width = 60
        DataGridViewResponses.Columns(6).Width = 50
        DataGridViewResponses.Columns(7).Width = 50
        DataGridViewResponses.Columns(8).Width = 70


        'DataGridViewResponses.AutoResizeColumns()
        DataGridViewResponses.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        'DataGridViewResponses.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(6).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewResponses.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(7).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'DataGridViewPairValue.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewPairValue.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'DataGridViewLines.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewLines.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridViewLines.DataSource = dt3
        DataGridViewLines.RowHeadersVisible = False
        RemarksTextField.Text = tender

    End Sub


    Private Sub ParkWayLoadFromTableCSV(folder As String)

        'Dim folder = defaultFolder & "memory"
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"

        Dim dt2 As New DataTable

        'determine which hospital

        'initialize
        dt.Rows.Clear()
        dt3.Rows.Clear()

        endSection = False
        tender = "none"

        Dim thereaderLine As New IO.StreamReader(folder & "\interim-pdf-page-1-text.txt", System.Text.Encoding.Default)

        'Only for Parkway
        Dim shipTo As String = ""
        Dim ctr As Integer = 0

        Do
            shipTo = thereaderLine.ReadLine

            If (shipTo Is Nothing) Then
                Continue Do
            End If

            ctr += 1
            If ctr = 2 Then
                TextBoxShipTo.Text = shipTo
            End If

            If (shipTo.Contains("P/O No:")) Then
                Dim po_line As String = thereaderLine.ReadLine
                TextBoxPO.Text = po_line
                Exit Do
            End If
        Loop

        Dim thereader As New IO.StreamReader(folder & "\OutputTables.csv", System.Text.Encoding.Default)
        SearchProgressBar.Minimum = 0
        SearchProgressBar.Maximum = 100
        SearchProgressBar.Value = 0

        Dim sline As String = ""
        Do
            sline = thereader.ReadLine
            If sline Is Nothing Then Exit Do
            Dim thecolumns() As String = sline.Split(vbTab)
            Dim newrow As DataRow = dt.NewRow
            Dim newrowItem As DataRow = dt3.NewRow

            For index As Integer = 0 To thecolumns.Length() - 1
                newrow(index) = thecolumns(index)
            Next

            If (dt3.Rows.Count = 0) Then
                newrowItem(0) = "Item"
                newrowItem(1) = "Unit Price"
                newrowItem(2) = "Qty"
            Else
                newrowItem(1) = newrow(unitPriceColumn)

                'get qty
                Dim str As String = newrow(qtyColumn).ToString
                Dim regex As Regex = New Regex("\d+")

                Dim match As Match = regex.Match(str)

                If (match.Success) Then
                    newrowItem(2) = match.Value
                Else
                    newrowItem(2) = newrow(qtyColumn)
                End If


            End If

            If ((newrow(0).ToString() <> "") And Not (newrow(0).ToString().StartsWith("Table")) And Not (String.IsNullOrEmpty(newrow(unitPriceColumn).ToString))) Then
                ParseDataRowParkWay(newrow, thecolumns.Length())
                dt.Rows.Add(newrow)
                dt3.Rows.Add(newrowItem)
            End If

            SearchProgressBar.Increment(1)
        Loop
        thereader.Close()

        SearchProgressBar.Value = SearchProgressBar.Maximum

        DataGridViewResponses.DataSource = dt
        DataGridViewResponses.RowHeadersVisible = False
        DataGridViewResponses.Columns(0).Width = 200
        DataGridViewResponses.Columns(1).Width = 100
        DataGridViewResponses.Columns(2).Width = 50
        DataGridViewResponses.Columns(3).Width = 30
        DataGridViewResponses.Columns(4).Width = 60
        DataGridViewResponses.Columns(5).Width = 60
        DataGridViewResponses.Columns(6).Width = 50
        DataGridViewResponses.Columns(7).Width = 50
        DataGridViewResponses.Columns(8).Width = 70


        'DataGridViewResponses.AutoResizeColumns()
        DataGridViewResponses.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        'DataGridViewResponses.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(6).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewResponses.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(7).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'DataGridViewPairValue.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewPairValue.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'DataGridViewLines.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewLines.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridViewLines.DataSource = dt3
        DataGridViewLines.RowHeadersVisible = False
        RemarksTextField.Text = tender

    End Sub

    Private Sub SingHealthLoadFromTableCSV(folder As String)
        'Dim folder = defaultFolder & "memory"
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"

        Dim dt2 As New DataTable

        'determine which hospital

        'initialize
        itemColumn = 1
        unitPriceColumn = 3
        qtyColumn = 2


        dt.Rows.Clear()
        dt3.Rows.Clear()

        endSection = False
        tender = "none"

        Dim thereaderLine As New IO.StreamReader(folder & "\interim-pdf-page-1-text.txt", System.Text.Encoding.Default)

        'Only for Parkway
        Dim shipTo As String = ""
        Dim ctr As Integer = 0

        Do
            shipTo = thereaderLine.ReadLine

            If (shipTo Is Nothing) Then
                Continue Do
            End If

            ctr += 1
            'If ctr = 2 Then
            '    TextBoxShipTo.Text = shipTo
            'End If

            If (shipTo.Contains("Purchase Order : ")) Then
                Dim r As Regex = New Regex("Purchase Order : \d+")
                Dim m As Match = r.Match(shipTo)
                TextBoxPO.Text = m.Value.Substring(17)
                Exit Do
            End If
        Loop



        Dim thereader As New IO.StreamReader(folder & "\OutputTables.csv", System.Text.Encoding.Default)
        SearchProgressBar.Minimum = 0
        SearchProgressBar.Maximum = 100
        SearchProgressBar.Value = 0

        Dim sline As String = ""
        Dim sn As Integer = 1

        Do
            sline = thereader.ReadLine

            If sline Is Nothing Then Exit Do

            Dim thecolumns() As String = sline.Split(vbTab)

            'Check for and not include repeated headers
            If dt.Rows.Count <> 0 And thecolumns(0).StartsWith("ITEM") Then
                Continue Do
            End If

            Dim newrow As DataRow = dt.NewRow
            Dim newrowItem As DataRow = dt3.NewRow

            If dt.Rows.Count = 0 Then
                newrow(0) = "S/N"
            Else
                newrow(0) = sn
            End If

            Dim i As Integer = 1
            For index As Integer = 0 To thecolumns.Length() - 1
                If String.IsNullOrEmpty(thecolumns(index)) Then Continue For
                newrow(i) = thecolumns(index)
                i += 1
            Next



            If (dt3.Rows.Count = 0) Then
                newrowItem(0) = "S/N"
                newrowItem(1) = "Item"
                newrowItem(2) = "Unit Price"
                newrowItem(3) = "Qty"
            Else
                newrowItem(0) = sn

                newrowItem(2) = newrow(unitPriceColumn)

                'get qty
                Dim str As String = newrow(qtyColumn).ToString
                Dim regex As Regex = New Regex("\d+")

                Dim match As Match = regex.Match(str)

                If (match.Success) Then
                    newrowItem(3) = match.Value
                Else
                    newrowItem(3) = newrow(qtyColumn)
                End If
            End If

            If newrow(1).ToString() <> "" And Not newrow(1).ToString().StartsWith("Table") And Not String.IsNullOrEmpty(newrow(unitPriceColumn).ToString) Then
                ParseDataRowParkWay(newrow, thecolumns.Length())

                If dt.Rows.Count <> 0 Then sn += 1

                dt.Rows.Add(newrow)
                dt3.Rows.Add(newrowItem)
            End If

            SearchProgressBar.Increment(1)
        Loop
        thereader.Close()

        SearchProgressBar.Value = SearchProgressBar.Maximum

        DataGridViewResponses.DataSource = dt
        DataGridViewResponses.RowHeadersVisible = False
        DataGridViewResponses.Columns(0).Width = 30
        DataGridViewResponses.Columns(1).Width = 200
        DataGridViewResponses.Columns(2).Width = 100
        DataGridViewResponses.Columns(3).Width = 50
        DataGridViewResponses.Columns(4).Width = 30
        DataGridViewResponses.Columns(5).Width = 60
        DataGridViewResponses.Columns(6).Width = 60
        DataGridViewResponses.Columns(7).Width = 50
        DataGridViewResponses.Columns(8).Width = 50
        DataGridViewResponses.Columns(9).Width = 70


        'DataGridViewResponses.AutoResizeColumns()
        DataGridViewResponses.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        'DataGridViewResponses.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(7).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewResponses.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(8).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewResponses.Columns(4).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'DataGridViewPairValue.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewPairValue.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewLines.DataSource = dt3
        DataGridViewLines.RowHeadersVisible = False

        DataGridViewLines.Columns(0).Width = 30
        DataGridViewLines.Columns(1).Width = 150

        DataGridViewLines.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewLines.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        RemarksTextField.Text = tender

    End Sub
    Private Sub NHGLoadFromTableCSV(folder As String)
        'Dim folder = defaultFolder & "memory"
        Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"

        Dim dt2 As New DataTable

        'determine which hospital

        'initialize
        itemColumn = 1
        unitPriceColumn = 4
        qtyColumn = 2


        dt.Rows.Clear()
        dt3.Rows.Clear()

        endSection = False
        tender = "none"

        Dim thereaderLine As New IO.StreamReader(folder & "\interim-pdf-page-1-text.txt", System.Text.Encoding.Default)

        'Only for Parkway
        Dim shipTo As String = ""
        Dim ctr As Integer = 0

        Do
            shipTo = thereaderLine.ReadLine

            If (shipTo Is Nothing) Then
                Continue Do
            End If

            ctr += 1
            'If ctr = 2 Then
            '    TextBoxShipTo.Text = shipTo
            'End If

            If (shipTo.Contains("PO Number:")) Then
                Dim r As Regex = New Regex("PO Number: \d+")
                Dim m As Match = r.Match(shipTo)
                TextBoxPO.Text = m.Value.Substring(11)
                Exit Do
            End If
        Loop



        Dim thereader As New IO.StreamReader(folder & "\OutputTables.csv", System.Text.Encoding.Default)
        SearchProgressBar.Minimum = 0
        SearchProgressBar.Maximum = 100
        SearchProgressBar.Value = 0

        Dim sline As String = ""
        Dim sn As Integer = 1

        Do
            sline = thereader.ReadLine

            If sline Is Nothing Then Exit Do

            Dim r = New Regex("\S")
            Dim m = r.Match(sline)

            If Not m.Success Then Continue Do

            Dim thecolumns() As String = sline.Split(vbTab)

            Dim newrow As DataRow = dt.NewRow
            Dim newrowItem As DataRow = dt3.NewRow

            If dt.Rows.Count = 0 Then
                newrow(0) = "S/N"
            Else
                newrow(0) = sn
            End If

            If String.IsNullOrEmpty(thecolumns(0)) Then
                Dim j As Integer = 1
                For index As Integer = 1 To thecolumns.Length() - 1
                    If String.IsNullOrEmpty(thecolumns(index)) Then Continue For

                    If index = 1 Then
                        r = New Regex("^\s*\d+\s+")
                        m = r.Match(thecolumns(index))

                        If m.Success Then dt.Rows(dt.Rows.Count - 1)(j + 1) = m.Value

                        dt.Rows(dt.Rows.Count - 1)(j) += dt.Rows(dt.Rows.Count - 1)(j + 2)
                        Dim MaterialRow2Split As String() = Regex.Split(thecolumns(index), "^\s*\d+\s+")
                        dt.Rows(dt.Rows.Count - 1)(j) += If(MaterialRow2Split.Length = 1, MaterialRow2Split(0), MaterialRow2Split(1))

                        dt.Rows(dt.Rows.Count - 1)(j + 2) = ""

                        j += 2
                    Else
                        dt.Rows(dt.Rows.Count - 1)(j) += thecolumns(index)

                        If index = 3 Then
                            m = Regex.Match(thecolumns(index), "[\d\.]+")
                            dt3.Rows(dt.Rows.Count - 1)(2) = m.Value

                            Dim m1 = Regex.Match(dt.Rows(dt.Rows.Count - 1)(j - 2), "\d+")

                            Dim m2 = Regex.Match(thecolumns(index), "([\d\.]+)/(\d+)")

                            If m2.Success Then
                                dt3.Rows(dt.Rows.Count - 1)(3) = Convert.ToInt32(m1.Value) / Convert.ToInt32(m2.Groups(2).ToString())
                            Else
                                dt3.Rows(dt.Rows.Count - 1)(3) = m1.Value
                            End If
                        End If

                            j += 1
                        End If
                Next
                Continue Do
            End If

            Dim i As Integer = 1
            For index As Integer = 1 To thecolumns.Length() - 1
                If String.IsNullOrEmpty(thecolumns(index)) Then Continue For

                If index = 1 Then
                    r = New Regex("^\s*Material\s+QTY\s*$")
                    m = r.Match(thecolumns(index))

                    If m.Success Then
                        newrow(i) = "Material"
                        newrow(i + 1) = "Qty"
                    ElseIf Regex.Match(thecolumns(index), "\s+PER\s+OUTER\s+\d+\s*$").Success Then
                        newrow(i) = Regex.Replace(thecolumns(index), "\s+\d+\s+PER\s+OUTER\s+", " PER OUTER ")
                        newrow(i + 1) = Regex.Match(thecolumns(index), "\s+(\d+)\s+PER\s+OUTER\s+").Groups(1)
                    Else
                        r = New Regex("\s+\d+\s*$")
                        m = r.Match(thecolumns(index))

                        If m.Success Then
                            newrow(i) = Regex.Split(thecolumns(index), "\s+\d+\s*$")(0)
                            newrow(i + 1) = m.Value
                        Else
                            newrow(i) = thecolumns(index)
                        End If
                    End If
                    i += 2
                Else
                    newrow(i) = thecolumns(index)
                    i += 1
                End If
            Next



            If (dt3.Rows.Count = 0) Then
                newrowItem(0) = "S/N"
                newrowItem(1) = "Item"
                newrowItem(2) = "Unit Price"
                newrowItem(3) = "Qty"
            Else
                newrowItem(0) = sn

                m = Regex.Match(newrow(unitPriceColumn).ToString(), "[\d\.]+")
                If m.Success Then newrowItem(2) = m.Value

                'get qty
                Dim m1 = Regex.Match(newrow(qtyColumn).ToString, "\d+")

                Dim m2 = Regex.Match(newrow(unitPriceColumn).ToString(), "([\d\.]+)/(\d+)")

                If m2.Success Then : newrowItem(3) = Convert.ToInt32(m1.Value) / Convert.ToInt32(m2.Groups(2).ToString())
                Else : newrowItem(3) = m1.Value
                End If
            End If

            If newrow(1).ToString() <> "" And Not newrow(1).ToString().StartsWith("Table") Then
                ParseDataRowParkWay(newrow, thecolumns.Length())

                If dt.Rows.Count <> 0 Then sn += 1

                dt.Rows.Add(newrow)
                dt3.Rows.Add(newrowItem)
            End If

            SearchProgressBar.Increment(1)
        Loop
        thereader.Close()

        SearchProgressBar.Value = SearchProgressBar.Maximum

        DataGridViewResponses.DataSource = dt
        DataGridViewResponses.RowHeadersVisible = False

        DataGridViewResponses.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewResponses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        DataGridViewResponses.Columns(7).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(8).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewResponses.Columns(4).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        DataGridViewLines.DataSource = dt3
        DataGridViewLines.RowHeadersVisible = False

        DataGridViewLines.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        RemarksTextField.Text = tender
    End Sub
    Private Sub ParseDataRowParkWay(thisRow As DataRow, len As Integer)
        For index As Integer = 1 To len
            If thisRow(index).ToString.Contains("Description") Then
                itemColumn = index
            End If

            If thisRow(index).ToString.Contains("Unit Price") Then
                unitPriceColumn = index
            End If

            If thisRow(index).ToString.Contains("Quantity") Then
                qtyColumn = index
            End If
        Next

    End Sub

    Private Sub ParseDataRowNTUCHealth(thisRow As DataRow)
        Dim part1 As String = thisRow(0)
        Dim part2 As String = thisRow(1)


        If (GetItemType(part1)) Then
            thisRow(7) = "item"
            thisRow(6) = GetItem(part2)
        Else
            thisRow(7) = "none"
        End If
        Dim shipTo As String = GetShipTo(part2)


        'NTUC Health
        If (GetNTUCHealth(part2)) Then
            TextBoxSoldTo.Text = "NTUC Health"
        End If

        If (shipTo <> "none") Then
            TextBoxShipTo.Text = shipTo
        End If

    End Sub

    Private Sub ParseDataRowBigData(tender As String, thisRow As DataRow)
        Dim part1 As String = thisRow(0)
        Dim part2 As String = thisRow(1)
        Static Dim entity As String = "main"

        'Dim part2 As String = thisRow(1)

        'determine entitytype
        Dim entityType As String = GetItemType(part1)
        endSection = GetEndSection(part2)

        If (entityType <> "none") Then
            If (entity = entityType) Then
                entity = entityType + thisRow(1)
            Else
                entity = entityType
            End If
            If (endSection) Then
                thisRow(3) = "main"
            Else
                thisRow(3) = entity
            End If
        Else
            thisRow(3) = entity
        End If

        If (endSection) Then
            thisRow(3) = "main"
        End If


        'do not insert into big data
        'insert into big data
        Dim newrow As DataRow = bigData.NewRow
        'For index As Integer = 0 To thecolumns.Length() - 1
        'newrow(index) = thecolumns(index)
        'Next
        newrow(0) = tender
        newrow(1) = thisRow(3)
        newrow(2) = thisRow(0)
        newrow(3) = thisRow(1)
        bigData.Rows.Add(newrow)

    End Sub


    Private Sub WebSearchButton_Click(sender As Object, e As EventArgs)


        SearchProgressBar.Minimum = 0
        SearchProgressBar.Maximum = 20
        SearchProgressBar.Value = 0

        DataGridViewWebSearch.DataSource = webSearchData

        Dim thereader As New IO.StreamReader("C:\Users\user\Documents\GitHubSurfacePro\SCRAPY\postscrape\postscrape\spiders\WebSearchResults.csv", System.Text.Encoding.Default)
        Dim sline As String = ""
        Do
            sline = thereader.ReadLine
            If sline Is Nothing Then Exit Do
            Dim thecolumns() As String = sline.Split(vbTab)
            Dim newrow As DataRow = webSearchData.NewRow
            For index As Integer = 0 To thecolumns.Length() - 1
                newrow(index) = thecolumns(index)
            Next
            webSearchData.Rows.Add(newrow)
            System.Threading.Thread.Sleep(1000)
            SearchProgressBar.Increment(1)
        Loop
        thereader.Close()



        DataGridViewWebSearch.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewWebSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewWebSearch.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridViewWebSearch.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewWebSearch.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Function PlaceHolder() As String
        ' The input string.
        Dim value As String = "4.1 Item 2"

        ' Invoke the Match method.
        Dim m As Match = Regex.Match(value, "^([0-9\.]+) item ([0-9]+)", RegexOptions.IgnoreCase)

        ' If successful, write the group.
        If (m.Success) Then
            Dim key1 As String = m.Groups(1).Value
            Dim key2 As String = m.Groups(2).Value
            MessageBox.Show(key1 + " " + key2)
        Else
            MessageBox.Show("nothing")
        End If
        Dim value1 As String = "GPOR 30918 - Quantities and Prevailing Price"

        ' Invoke the Match method.
        Dim m1 As Match = Regex.Match(value1, "^GPOR ([0-9]+) (\-)", RegexOptions.IgnoreCase)

        ' If successful, write the group.
        If (m1.Success) Then
            Dim key1 As String = m1.Groups(1).Value
            'Dim key2 As String = m1.Groups(2).Value
            MessageBox.Show(key1 + " ")
        Else
            MessageBox.Show("nothing")
        End If

        Dim str1 As String = "hello me"

        If (str1.FuzzyEquals("hello me")) Then
            MessageBox.Show("equal")
        Else
            MessageBox.Show("not equal")
        End If

        Dim coefficient As Double = str1.FuzzyMatch("hello")
        MessageBox.Show("co-e is " + coefficient.ToString())
        Return "none"
    End Function
    Private Function GetItemType(lineContents As String) As Boolean

        ' The input string.
        Static Dim item As String
        'Static Dim entity As String

        ' Invoke the Match method.
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "^([0-9\.]+) item ([0-9]+) ([A-Za-z0-9\-]+])", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "item ([0-9]+) ([\-]+) \w+", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "item ([0-9]+) (\-) ([\w]+)", RegexOptions.IgnoreCase)
        Dim itemType As Match = Regex.Match(lineContents, "^([0-9]+)", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "item ([0-9]+) (\-) ([A-Za-z0-9\- ]+])", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "^item [^.]*\.", RegexOptions.IgnoreCase)
        'Dim entityType As Match = Regex.Match(lineContents, "^([0-9\.]+) item ([0-9]+)", RegexOptions.IgnoreCase)

        ' If successful, write the group.
        If (itemType.Success) Then
            item = itemType.Groups(1).Value
            Return True
        Else
            Return False
        End If
    End Function

    Private Function GetItem(lineContents As String) As String

        ' The input string.
        Static Dim item As String
        'Static Dim entity As String

        ' Invoke the Match method.
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "^([0-9\.]+) item ([0-9]+) ([A-Za-z0-9\-]+])", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "item ([0-9]+) ([\-]+) \w+", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "item ([0-9]+) (\-) ([\w]+)", RegexOptions.IgnoreCase)
        Dim itemFound As Match = Regex.Match(lineContents, "([0-9]{10}) ([A-Za-z0-9\- \(\)\/.,]+)", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "item ([0-9]+) (\-) ([A-Za-z0-9\- ]+])", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "^item [^.]*\.", RegexOptions.IgnoreCase)
        'Dim entityType As Match = Regex.Match(lineContents, "^([0-9\.]+) item ([0-9]+)", RegexOptions.IgnoreCase)

        ' If successful, write the group.
        If (itemFound.Success) Then
            item = itemFound.Groups(2).Value
            Return item
        Else
            Return "none"
        End If
    End Function


    Private Function GetTender(lineContents As String) As String

        ' The input string.
        Static Dim tender As String
        'Static Dim entity As String

        ' Invoke the Match method.
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "^([0-9\.]+) item ([0-9]+) ([A-Za-z0-9\-]+])", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "item ([0-9]+) ([\-]+) \w+", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "item ([0-9]+) (\-) ([\w]+)", RegexOptions.IgnoreCase)
        'MessageBox.Show(lineContents)
        Dim entityTypeItem As Match = Regex.Match(lineContents, "^GPOR ([0-9]+) (\-)")
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "item ([0-9]+) (\-) ([A-Za-z0-9\- ]+])", RegexOptions.IgnoreCase)
        'Dim entityTypeItem As Match = Regex.Match(lineContents, "^item [^.]*\.", RegexOptions.IgnoreCase)
        'Dim entityType As Match = Regex.Match(lineContents, "^([0-9\.]+) item ([0-9]+)", RegexOptions.IgnoreCase)

        ' If successful, write the group.
        If (entityTypeItem.Success) Then
            Dim key1 As String = entityTypeItem.Groups(1).Value
            'Dim key2 As String = entityTypeItem.Groups(2).Value
            'Dim key3 As String = entityTypeItem.Groups(3).Value
            'MessageBox.Show(key1 + " " + key2)
            'entityType = "item" + "#" + key1 + "#" + key2 + "#" + key3 + "#" + entityTypeItem.Value
            tender = "GPOR-" + key1
        Else
            tender = "none"
        End If

        Dim endEntityMarker As String = "Submission of Supporting Documents"
        Dim getGPORMarker As String = "Supporting Documents Attach all supporting documents for this RFP in one zip file. The maximum file size for the attachment is 100MB. "
        Dim getGPORValue As String = "GPOR 30918 - Quantities and Prevailing Price.xlsx"

        Return tender
    End Function

    Private Function GetEndSection(lineContents As String) As String

        'MessageBox.Show(lineContents)
        Dim entityTypeItem As Match = Regex.Match(lineContents, "^([0-9\.]+) Submission of Supporting Documents")

        ' If successful, write the group.
        If (entityTypeItem.Success Or endSection) Then
            'Dim key1 As String = entityTypeItem.Groups(1).Value
            'Dim key2 As String = entityTypeItem.Groups(2).Value
            'Dim key3 As String = entityTypeItem.Groups(3).Value
            'MessageBox.Show(key1 + " " + key2)
            'entityType = "item" + "#" + key1 + "#" + key2 + "#" + key3 + "#" + entityTypeItem.Value
            endSection = True
            Return True
        Else
            Return False
        End If

        Dim endEntityMarker As String = "Submission of Supporting Documents"
        Dim getGPORMarker As String = "Supporting Documents Attach all supporting documents for this RFP in one zip file. The maximum file size for the attachment is 100MB. "
        Dim getGPORValue As String = "GPOR 30918 - Quantities and Prevailing Price.xlsx"
    End Function


    Private Function GetShipTo(lineContents As String) As String

        'MessageBox.Show(lineContents)
        Dim shipTo As Match = Regex.Match(lineContents, "^Ship To ([0-9A-Za-z, ]+)")
        'Dim shipTo As Match = Regex.Match(lineContents, "^Ship To *")

        ' If successful, write the group.
        If (shipTo.Success) Then
            Return shipTo.Groups(1).Value
        Else
            Return "none"
        End If
    End Function

    Private Function GetNTUCHealth(lineContents As String) As Boolean

        'MessageBox.Show(lineContents)
        Dim NTUCHealth As Match = Regex.Match(lineContents, "^NTUC Health*")

        ' If successful, write the group.
        If (NTUCHealth.Success) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dt
            .Columns.Add("A0", System.Type.GetType("System.String"))
            .Columns.Add("A1", System.Type.GetType("System.String"))
            .Columns.Add("A2", System.Type.GetType("System.String"))
            .Columns.Add("A3", System.Type.GetType("System.String"))
            .Columns.Add("A4", System.Type.GetType("System.String"))
            .Columns.Add("A5", System.Type.GetType("System.String"))
            .Columns.Add("A6", System.Type.GetType("System.String"))
            .Columns.Add("A7", System.Type.GetType("System.String"))
            .Columns.Add("A8", System.Type.GetType("System.String"))
            .Columns.Add("A9", System.Type.GetType("System.String"))
            .Columns.Add("A10", System.Type.GetType("System.String"))
            .Columns.Add("A11", System.Type.GetType("System.String"))
        End With

        With dt3
            .Columns.Add("S/N", System.Type.GetType("System.String"))
            .Columns.Add("Item", System.Type.GetType("System.String"))
            .Columns.Add("Unit Price", System.Type.GetType("System.String"))
            .Columns.Add("Quantity", System.Type.GetType("System.String"))
            .Columns.Add("Remark", System.Type.GetType("System.String"))
        End With

        With bigData
            .Columns.Add("tender", System.Type.GetType("System.String"))
            .Columns.Add("entity", System.Type.GetType("System.String"))
            .Columns.Add("key", System.Type.GetType("System.String"))
            .Columns.Add("value", System.Type.GetType("System.String"))
            .Columns.Add("searchable", System.Type.GetType("System.Boolean"))
            .Columns.Add("weightage", System.Type.GetType("System.Double"))
        End With

        With webSearchData
            .Columns.Add("Bid", System.Type.GetType("System.String"))
            .Columns.Add("Estimated Budget", System.Type.GetType("System.String"))
        End With

        RadioButtonSingHealth.Checked = True

        LoadMasterData()

        'Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQyNDAxQDMxMzgyZTMzMmUzME02U1Q0TzZuQW1RcWZ0Y2xhYjFBczNyNVJLVWZHbUlzK09XdmF3cDkyWDg9")
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzYwNjQ3QDMxMzgyZTMzMmUzMGt6d0pDdXhWUThqWVJTZjV2ZEtxMnRNRGQzNFJOcndHSVhaMlMzSUw5TVk9")

    End Sub

    Private Function RespondQuestion(entity As String, question As String) As String
        'perform fuzzy search

        searchData = bigData.Clone()
        searchData = bigData.Copy()

        If (entity = "item:Tamoxifen 20mg Tablets ") Then
            Dim i As Integer = 0
        End If

        For Each row As DataRow In searchData.Rows
            Dim entityToSearch As String = row.Item("entity")
            Dim coX As Double = entity.FuzzyMatch(row.Item("entity"))


            If coX > 0.97 Then
                row.Item("searchable") = True
            Else
                row.Item("searchable") = False
            End If
        Next row

        For Each row As DataRow In searchData.Rows
            row.Item("weightage") = question.FuzzyMatch(row.Item("key"))
        Next row

        Dim xRow As DataRow = searchData.Rows(0)
        Dim initialCo As Double = xRow.Item("weightage")
        Dim index As Integer = 0
        Dim found As Boolean = False


        For i As Integer = 0 To searchData.Rows.Count - 1
            If (searchData.Rows(i).Item("searchable")) Then
                initialCo = searchData.Rows(i).Item("weightage")
                index = i
                found = True
                Exit For
            End If
        Next

        If Not found Then
            Return "none"
        End If

        For i As Integer = 0 To searchData.Rows.Count - 1
            If (searchData.Rows(i).Item("searchable")) Then
                If (initialCo < searchData.Rows(i).Item("weightage")) Then
                    initialCo = searchData.Rows(i).Item("weightage")
                    index = i
                End If
            End If
        Next

        DataGridViewSearch.DataSource = searchData

        Dim yRow As DataRow = searchData.Rows(index)
        Dim returnStr = yRow.Item("value")

        If returnStr Is Nothing Then
            Return "none"
        ElseIf returnStr = "" Then
            Return "none"
        Else
            Return returnStr
        End If



    End Function


    Private Sub GeneratePDF_Click(sender As Object, e As EventArgs) Handles GeneratePDF.Click
        If String.IsNullOrEmpty(TextBoxShipToCode.Text.ToString) Then
            MessageBox.Show("Ship To cannot be empty")
            Return
        End If


        Using excelEngine As New ExcelEngine()

            Dim application As IApplication = excelEngine.Excel
            application.DefaultVersion = ExcelVersion.Excel2013
            Dim workbook As IWorkbook = application.Workbooks.Create(1)
            Dim worksheet As IWorksheet = workbook.Worksheets(0)
            Dim tempDT As DataTable


            tempDT = dt3.Clone()
            tempDT = dt3.Copy()

            tempDT.Rows.RemoveAt(0)
            tempDT.Columns.RemoveAt(0)
            Dim newRow As DataRow = tempDT.NewRow

            'newRow(0) = TextBoxShipToCode.Text
            'newRow(1) = RemarksTextField.Text
            'tempDT.Rows.InsertAt(newRow, 0)


            Dim view As DataView = tempDT.DefaultView
            worksheet.ImportDataView(view, False, 2, 1)
            worksheet.SetText(1, 1, TextBoxShipToCode.Text.ToString)
            worksheet.SetText(1, 2, RemarksTextField.Text.ToString)
            worksheet.SetText(1, 3, TextBoxPO.Text.ToString)

            Dim leftString = POtoProcess.Split("."c)(0) ' Take the first index in the array
            workbook.SaveAs(rpaFolder + leftString + "Order.xlsx")

        End Using
        SaveToHospitalOrders()
        'purge the file
        IO.File.Delete(POtoProcess)
    End Sub

    Private Sub SaveToHospitalOrders()
        Dim hospitalOrderTbl As New DataTable

        hospitalOrderTbl.Columns.Add("Item")
        hospitalOrderTbl.Columns.Add("Description")
        hospitalOrderTbl.Columns.Add("Hospital")

        Dim ctr As Integer = 0

        For Each row As DataRow In dt.Rows

            Dim newRow As DataRow = hospitalOrderTbl.NewRow
            Dim itemRow = dt3.Rows(ctr)
            If IsDBNull(itemRow("item")) Then
                Continue For
            End If

            newRow("Item") = itemRow("Item")
            newRow("Description") = row(itemColumn)
            newRow("Hospital") = hospitalSelected

            hospitalOrderTbl.Rows.Add(newRow)
            ctr += 1
        Next

        hospitalOrderTbl.Rows.RemoveAt(0)

        'insert into the sql
        If hospitalOrderTbl.Rows.Count > 0 Then
            Using con As New SqlConnection(consString)
                Using cmd As New SqlCommand("Insert_HospitalOrders")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@tblHospitalOrder", hospitalOrderTbl)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End If

    End Sub

    Private Sub ConvertDocPDF_Click(sender As Object, e As EventArgs)
        'Convert .doc or .docx to .pdf files via Send To menu
        Dim fso As New FileSystemObject
        'Dim ts As TextStream = CreateObject("Scripting.FileSystemObject")

        Dim docPath As String = "C:\Users\user\Documents\GitHubSurfacePro\WordToPDFSample\WordToPDFSample\Data\sample.doc"
        docPath = fso.GetAbsolutePathName(docPath)
        If docPath.Substring(docPath.Length - 4, 4).ToLower() = ".doc" Or docPath.Substring(docPath.Length - 5, 5).ToLower() = ".docx" Then
            Dim objWord = CreateObject("Word.Application")
            Dim pdfPath = fso.GetParentFolderName(docPath) & "\" &
            fso.GetBaseName(docPath) & ".pdf"
            objWord.Visible = False
            Dim objDoc = objWord.documents.open(docPath)
            objDoc.saveas(pdfPath, 17)
            objDoc.Close
            objWord.Quit
        End If
    End Sub


    Private Sub PeformTextExtract(sender As Object, e As EventArgs) Handles ConvertDocPDF.Click

        'copy the PDF to memory folder
        'If ListBoxPOs.SelectedItems.Count = 0 Then
        'MsgBox("No PDF file selected.")
        'Exit Sub
        'End If

        'POtoProcess = ListBoxPOs.SelectedItem(0).ToString()
        'If POtoProcess Is Nothing Then
        'Return
        'End If

        POtoProcess = "Ultiva.pdf"
        hospitalSelected = "PARKWAY"
        'retreive from database

        folderName = "FB023562-2533-EB11-8C77-082E5F03BB51"
        'folderName = ListBoxPOs.SelectedValue().ToString()

        'PdfDocumentView.Load(pdfFolder + "\" + hospitalSelected + "\" + POtoProcess)

        PdfViewerControl.Load(databaseFolder + "\" + hospitalSelected + "\" + folderName + "\" + POtoProcess)
        'PdfViewerControl.ShowToolBar = True


        'My.Computer.FileSystem.CopyFile(
        '                                POtoProcess,
        '                                defaultFolder & "memory\interim.pdf",
        '                                 overwrite:=True)

        'Dim p As New Process
        'p.StartInfo.WorkingDirectory = defaultFolder & "memory"
        'p.StartInfo.FileName = defaultFolder & "src\python_textextract.cmd"   '"script.py" must be in the debug folder'
        'p.StartInfo.RedirectStandardOutput = False
        'p.StartInfo.UseShellExecute = True
        'p.StartInfo.CreateNoWindow = False



        'Dim zipper As System.Diagnostics.Process = System.Diagnostics.Process.Start(p.StartInfo)
        'Dim timeout As Integer = 60000 '1 minute in milliseconds

        'If Not zipper.WaitForExit(timeout) Then
        'Something went wrong with the zipping process; we waited longer than a minute
        'Else
        'delete remaining pdfs
        '    MessageBox.Show("Completed")
        '    ParkWayLoadFromTableCSV()
        'End If

        'MessageBox.Show("Completed")


        If hospitalSelected = "PARKWAY" Then
            'C:\HospitalDatabase\OrderFiles\Parkway\FB023562-2533-EB11-8C77-082E5F03BB51

            ParkWayLoadFromTableCSV(databaseFolder + "\" + hospitalSelected + "\" + folderName)
        ElseIf hospitalSelected = "SingHealth" Then
            SingHealthLoadFromTableCSV(databaseFolder + "\" + hospitalSelected + "\" + folderName)
        ElseIf hospitalSelected = "NHG" Then
            NHGLoadFromTableCSV(databaseFolder + "\" + hospitalSelected + "\" + folderName)
        End If


    End Sub

    Private Sub ProductMasterLoad_Click(sender As Object, e As EventArgs) Handles ProductMasterLoadButton.Click



        'Dim consString As String = "Data Source=DESKTOP-S3PGIOO\SQLEXPRESS;User ID=lynn;Password=Skm9627j#;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        Using con As New SqlConnection(consString)
            Using cmd As New SqlCommand("Get_ItemMaster")
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                'cmd.Parameters.AddWithValue("@hospital", "SingHealth")
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(productMasterDT)
                End Using
            End Using
        End Using

        DataGridViewProductMaster.DataSource = productMasterDT
        DataGridViewProductMaster.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewProductMaster.RowHeadersVisible = False
        DataGridViewProductMaster.Columns(0).Width = 140
        DataGridViewProductMaster.Columns(1).Width = 200
        'DataGridViewProductMaster.Columns(2).Width = 140
        'DataGridViewProductMaster.Columns(3).Width = 149
        'DataGridViewProductMaster.Columns(4).Width = 140
        'DataGridViewProductMaster.Columns(5).Width = 100
        'DataGridViewProductMaster.Columns(6).Width = 10

        DataGridViewProductMaster.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewProductMaster.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        DataGridViewProductMaster.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridViewProductMaster.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


        'productMasterDT.Columns.RemoveAt(0)
        'productMasterDT.Columns.RemoveAt(0)
        'productMasterDT.Columns.RemoveAt(0)
        'productMasterDT.Columns.RemoveAt(3)
        productMasterDT.Columns.Add()
        'productMasterDT.Columns.RemoveAt(0)

        productMasterDT.Columns(2).ColumnName = "Hospital"
        productMasterDT.Columns.Add()
        productMasterDT.Columns(3).ColumnName = "Points"
        productMasterDT.Columns(3).DataType = GetType(Double)

    End Sub

    Private Sub LoadMasterData()



        'Dim consString As String = "Data Source=DESKTOP-S3PGIOO\SQLEXPRESS;User ID=lynn;Password=Skm9627j#;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        Using con As New SqlConnection(consString)
            Using cmd As New SqlCommand("Get_ItemMaster")
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(productMasterDT)
                End Using
            End Using
        End Using




        DataGridViewProductMaster.DataSource = productMasterDT
        DataGridViewProductMaster.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewProductMaster.RowHeadersVisible = False
        DataGridViewProductMaster.Columns(0).Width = 140
        DataGridViewProductMaster.Columns(1).Width = 200


        DataGridViewProductMaster.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridViewProductMaster.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        DataGridViewProductMaster.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridViewProductMaster.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'productMasterDT.Columns.Add()
        'productMasterDT.Columns(2).ColumnName = "Hospital"

        'Dim consString1 As String = "Data Source=DESKTOP-S3PGIOO\SQLEXPRESS;User ID=lynn;Password=Skm9627j#;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        Using con As New SqlConnection(consString)
            Using cmd As New SqlCommand("Get_HospitalOrder")
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@hospital", hospitalSelected)
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(productMasterDT)
                End Using
            End Using
        End Using


        productMasterDT.Columns.Add()
        productMasterDT.Columns(2).ColumnName = "Points"
    End Sub

    Private Sub GetHospitalShipToCodes()
        'Dim consString As String = "Data Source=DESKTOP-S3PGIOO\SQLEXPRESS;User ID=lynn;Password=Skm9627j#;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        Using con As New SqlConnection(consString)
            Using cmd As New SqlCommand("GetHospitalShipToCode")
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@hospital", "SingHealth")
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(shiptoDT)
                End Using
            End Using
        End Using
    End Sub

    Private Sub CalculateProximityButton_Click(sender As Object, e As EventArgs) Handles CalculateProximityButton.Click
        AssignPointsDescription(TextBoxStrToSearch.Text)
    End Sub

    Private Sub ButtonChooseCloseMatchItem_Click(sender As Object, e As EventArgs) Handles ButtonChooseCloseMatchItem.Click
        AssignPointsItem(TextBoxItemToSearch.Text)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewResponses.CellClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        Dim value As Object = DataGridViewResponses.Rows(e.RowIndex).Cells(itemColumn).Value
        If IsDBNull(value) Then
            TextBoxStrToSearch.Text = "" ' blank if dbnull values
            TextBoxItemToSearch.Text = ""
        Else
            Dim v = CType(value, String)
            If RadioButtonSingHealth.Checked Then
                Dim r1 As Regex = New Regex("\d+")
                Dim m1 As Match = r1.Match(v)
                TextBoxStrToSearch.Text = v.Substring(InStr(v, m1.Value) + m1.Value.Length)

                Dim r2 As Regex = New Regex("\d{6}")
                Dim m2 As Match = r2.Match(v)
                TextBoxItemToSearch.Text = m2.Value
            ElseIf RadioButtonNHG.Checked Then
                Dim r2 As Regex = New Regex("\d{6}")
                Dim m2 As Match = r2.Match(v)
                TextBoxItemToSearch.Text = m2.Value

                TextBoxStrToSearch.Text = v
            Else
                TextBoxStrToSearch.Text = v
            End If
        End If
    End Sub

    Private Sub ButtonSaveShipTo_Click(sender As Object, e As EventArgs) Handles ButtonSaveShipTo.Click
        'insert into the sql
        If shiptoDT.Rows.Count > 0 Then
            'Dim consString As String = "Data Source=DESKTOP-S3PGIOO\SQLEXPRESS;User ID=lynn;Password=Skm9627j#;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            Using con As New SqlConnection(consString)
                Using cmd As New SqlCommand("Insert_ShipTo")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@tblShipTo", shiptoDT)
                    cmd.Parameters.AddWithValue("@hospital", hospitalSelected)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            MsgBox("Changes Done.")
        End If
    End Sub

    Private Sub ButtonRotatePDF_Click(sender As Object, e As EventArgs) Handles ButtonRotate90.Click

        POtoProcess = "Ultiva.pdf"
        hospitalSelected = "PARKWAY"
        'retreive from database

        folderName = "FB023562-2533-EB11-8C77-082E5F03BB51"
        'Load a PDF document
        Dim ldoc As PdfLoadedDocument = New PdfLoadedDocument(pdfFolder + "\" + hospitalSelected + "\" + POtoProcess)
        'Create a new instance of PdfDocument class
        Dim doc As PdfDocument = New PdfDocument()
        'Set document rotation angle as 90 degree
        doc.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90
        'Import PDF document
        doc.ImportPageRange(ldoc, 0, (ldoc.Pages.Count - 1))
        'doc.Close()
        'ldoc.Close()
        'Save and Close the document
        doc.Save(pdfFolder + "\" + hospitalSelected + "\ROTATED" + POtoProcess)
        doc.Close(True)
        ldoc.Close()
        PdfViewerControl.Load(pdfFolder + "\" + hospitalSelected + "\ROTATED" + POtoProcess)
        'My.Computer.FileSystem.CopyFile( pdfFolder +"\" + hospitalSelected + "\" + POtoProcess, pdfFolder + "\" + hospitalSelected + "\ROTATED" + POtoProcess, overwrite:=True)

    End Sub

    Private Sub ButtonLoadPdtXls_Click(sender As Object, e As EventArgs) Handles ButtonLoadPdtXls.Click
        Dim folder = defaultFolder & "MasterData\materialmaster.xlsx"
        Dim conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=Yes'"
        conStr = String.Format(conStr, folder)

        Using Adp As New OleDbDataAdapter("select * from [sheet1$]", conStr)
            Adp.Fill(productMasterDT)
        End Using
    End Sub

    Private Sub ButtonRotate180_Click(sender As Object, e As EventArgs) Handles ButtonRotate180.Click
        'Load a PDF document
        Dim ldoc As PdfLoadedDocument = New PdfLoadedDocument(pdfFolder + "\" + hospitalSelected + "\" + POtoProcess)
        'Create a new instance of PdfDocument class
        Dim doc As PdfDocument = New PdfDocument()
        'Set document rotation angle as 90 degree
        doc.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle270
        'Import PDF document
        doc.ImportPageRange(ldoc, 0, (ldoc.Pages.Count - 1))
        'doc.Close()
        'ldoc.Close()
        'Save and Close the document
        doc.Save(pdfFolder + "\" + hospitalSelected + "\ROTATED" + POtoProcess)
        doc.Close(True)
        ldoc.Close()
        PdfViewerControl.Load(pdfFolder + "\" + hospitalSelected + "\ROTATED" + POtoProcess)
        'My.Computer.FileSystem.CopyFile( pdfFolder +"\" + hospitalSelected + "\" + POtoProcess, pdfFolder + "\" + hospitalSelected + "\ROTATED" + POtoProcess, overwrite:=True)
    End Sub

    Private Sub ButtonRotate270_Click(sender As Object, e As EventArgs) Handles ButtonRotate270.Click
        'Load a PDF document
        Dim ldoc As PdfLoadedDocument = New PdfLoadedDocument(pdfFolder + "\" + hospitalSelected + "\" + POtoProcess)
        'Create a new instance of PdfDocument class
        Dim doc As PdfDocument = New PdfDocument()
        'Set document rotation angle as 90 degree
        doc.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle270
        'Import PDF document
        doc.ImportPageRange(ldoc, 0, (ldoc.Pages.Count - 1))
        'doc.Close()
        'ldoc.Close()
        'Save and Close the document
        doc.Save(pdfFolder + "\" + hospitalSelected + "\ROTATED" + POtoProcess)
        doc.Close(True)
        ldoc.Close()
        PdfViewerControl.Load(pdfFolder + "\" + hospitalSelected + "\ROTATED" + POtoProcess)
        'My.Computer.FileSystem.CopyFile( pdfFolder +"\" + hospitalSelected + "\" + POtoProcess, pdfFolder + "\" + hospitalSelected + "\ROTATED" + POtoProcess, overwrite:=True)
    End Sub

    Private Sub PdfViewerControl_Click(sender As Object, e As EventArgs) Handles PdfViewerControl.Click

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged

    End Sub

    Private Sub RadioButtonNTUCHealth_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNTUCHealth.CheckedChanged

    End Sub

    Private Sub ListBoxPOs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxPOs.SelectedIndexChanged

    End Sub
    Private Sub LoadShipTo()
        shiptoDT.Clear()

        'Load the shipto location
        Using con As New SqlConnection(consString)
            Using cmd As New SqlCommand("Get_HospitalShipToCode")
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@hospital", hospitalSelected)
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(shiptoDT)
                End Using
            End Using
        End Using

        DataGridViewShipTo.DataSource = shiptoDT

        DataGridViewShipTo.RowHeadersVisible = False
        DataGridViewShipTo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewShipTo.Columns(0).Width = 200
        DataGridViewShipTo.Columns(1).Width = 200
        'DataGridViewShipTo.Columns(2).Width = 10


        'DataGridViewShipTo.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewShipTo.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridViewShipTo.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        'DataGridViewShipTo.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DataGridViewShipTo.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DataGridViewShipTo.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub RadioButtonSingHealth_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSingHealth.CheckedChanged
        If RadioButtonSingHealth.Checked Then
            hospitalSelected = "SingHealth"
            LoadShipTo()
        End If
    End Sub

    Private Sub RadioButtonNHG_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNHG.CheckedChanged
        If RadioButtonNHG.Checked Then
            hospitalSelected = "NHG"
            LoadShipTo()
        End If
    End Sub

    Private Sub ButtonManualEntry_Click(sender As Object, e As EventArgs) Handles ButtonManualEntry.Click
        If String.IsNullOrEmpty(TextBoxShipToCode.Text.ToString) Then
            MessageBox.Show("Ship To cannot be empty")
            Return
        End If


        Using excelEngine As New ExcelEngine()

            Dim application As IApplication = excelEngine.Excel
            application.DefaultVersion = ExcelVersion.Excel2013
            Dim workbook As IWorkbook = application.Workbooks.Create(1)
            Dim worksheet As IWorksheet = workbook.Worksheets(0)
            Dim tempDT As DataTable


            tempDT = dt3.Clone()
            tempDT = dt3.Copy()

            tempDT.Rows.RemoveAt(0)
            tempDT.Columns.RemoveAt(0)
            Dim newRow As DataRow = tempDT.NewRow

            'newRow(0) = TextBoxShipToCode.Text
            'newRow(1) = RemarksTextField.Text
            'tempDT.Rows.InsertAt(newRow, 0)


            Dim view As DataView = tempDT.DefaultView
            worksheet.ImportDataView(view, False, 2, 1)
            worksheet.SetText(1, 1, TextBoxShipToCode.Text.ToString)
            worksheet.SetText(1, 2, RemarksTextField.Text.ToString)
            worksheet.SetText(1, 3, TextBoxPO.Text.ToString)

            Dim leftString = POtoProcess.Split("."c)(0) ' Take the first index in the array
            workbook.SaveAs(rpaFolder + leftString + "Order.xlsx")

        End Using
        SaveToHospitalOrders()
        'purge the file
        IO.File.Delete(POtoProcess)

        Dim p As New Process
        p.StartInfo.WorkingDirectory = rpaFolder
        p.StartInfo.FileName = "python"   '"script.py" must be in the debug folder'
        p.StartInfo.Arguments = "T:\HospitalDatabase\lazy.py " + rpaFolder + POtoProcess.Split("."c)(0) + "Order.xlsx"
        'p.StartInfo.Arguments = "C:\file.py " + rpaFolder + POtoProcess.Split("."c)(0) + "Order.xlsx"
        p.StartInfo.RedirectStandardOutput = False
        p.StartInfo.UseShellExecute = False
        p.StartInfo.CreateNoWindow = True



        Dim zipper As System.Diagnostics.Process = System.Diagnostics.Process.Start(p.StartInfo)
        Dim timeout As Integer = 300000 '5 minute in milliseconds

        Using con As New SqlConnection(consString)
            Dim sql As String = "update HospitalOrderPDF set Processed = 'Yes' where GeneratedFolder = @gf"
            Using cmd As New SqlCommand(sql)
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                cmd.Parameters.Add("@gf", SqlDbType.UniqueIdentifier).Value = Guid.Parse(folderName)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using

        Dim poDT1 As DataSet = New DataSet()

        Using con As New SqlConnection(consString)
            Dim sql As String = "SELECT PDFName, GeneratedFolder from HospitalOrderPDF WHERE Processed = 'No' and Hospital = @h"
            Using cmd As New SqlCommand(sql)
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@h", SqlDbType.VarChar).Value = hospitalSelected
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(poDT1)
                End Using
            End Using
        End Using

        ListBoxPOs.DataSource = poDT1.Tables(0)
        ListBoxPOs.DisplayMember = "PDFName"
        ListBoxPOs.ValueMember = "GeneratedFolder"
    End Sub

    Private Sub ButtonSaveProductsToSql_Click(sender As Object, e As EventArgs) Handles ButtonSaveProductsToSql.Click

        productMasterDT.Columns.RemoveAt(0)
        productMasterDT.Columns.RemoveAt(0)
        productMasterDT.Columns.RemoveAt(0)
        productMasterDT.Columns.RemoveAt(3)
        'productMasterDT.Columns.Add()
        productMasterDT.Columns.RemoveAt(0)


        'insert into the sql
        If productMasterDT.Rows.Count > 0 Then
            'Dim consString As String = "Data Source=DESKTOP-S3PGIOO\SQLEXPRESS;User ID=lynn;Password=Skm9627j#;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

            Using con As New SqlConnection(consString)
                Using cmd As New SqlCommand("Insert_ItemMaster")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@tblItemMaster", productMasterDT)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End If

    End Sub



    Private Sub ButtonChooseItem_Click(sender As Object, e As EventArgs) Handles ButtonChooseItem.Click

        Dim selectedRow = productMasterDT.Rows(DataGridViewProductMaster.CurrentCell.RowIndex)

        'Dim selectedRow = productMasterDT.Rows(0)
        Dim itemNumber = selectedRow(0)

        Dim poItem = dt3.Rows(DataGridViewResponses.CurrentCell.RowIndex)
        poItem(1) = itemNumber

    End Sub

    Private Sub DataGridViewShipTo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewShipTo.CellClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        Dim value As Object = DataGridViewShipTo.Rows(e.RowIndex).Cells(1).Value

        If IsDBNull(value) Then
            TextBoxSoldTo.Text = "" ' blank if dbnull values
        Else
            TextBoxShipToCode.Text = CType(value, String)
        End If

    End Sub

    Private Sub CheckDirectoryButton_Click(sender As Object, e As EventArgs) Handles CheckDirectoryButton.Click
        Select Case True
            Case Me.RadioButtonParkway.Checked
                'do something
                hospitalSelected = "Parkway"
            Case Me.RadioButtonNTUCHealth.Checked
                'do something else
                hospitalSelected = "NTUCHealth"
            Case Me.RadioButtonSingHealth.Checked
                'do something else
                hospitalSelected = "SingHealth"
            Case Me.RadioButtonNHG.Checked
                hospitalSelected = "NHG"
        End Select
        'Dim strDirectory As String = defaultFolder & "AllPOs\" & hospitalSelected
        'Dim myFiles As String()

        'myFiles = IO.Directory.GetFiles(strDirectory, "*.*", IO.SearchOption.TopDirectoryOnly)

        'ListBoxPOs.Items.Clear()
        'For Each item In myFiles
        '    ListBoxPOs.Items.Add(item)
        'Next

        Dim poDT1 As DataSet = New DataSet()

        'Dim consString As String = "Data Source=DESKTOP-S3PGIOO\SQLEXPRESS;User ID=lynn;Password=Skm9627j#;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        Using con As New SqlConnection(consString)
            Dim sql As String = "SELECT PDFName, GeneratedFolder from HospitalOrderPDF WHERE Processed = 'No' and Hospital = @h"
            Using cmd As New SqlCommand(sql)
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add("@h", SqlDbType.VarChar).Value = hospitalSelected
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(poDT1)
                End Using
            End Using
        End Using

        ListBoxPOs.DataSource = poDT1.Tables(0)
        ListBoxPOs.DisplayMember = "PDFName"
        ListBoxPOs.ValueMember = "GeneratedFolder"


    End Sub

    Private Sub AssignPointsDescription(strToCompare As String)


        SearchProgressBar.Minimum = 0
        SearchProgressBar.Maximum = productMasterDT.Rows.Count
        SearchProgressBar.Value = 0


        'For Each xRow In productMasterDT.Rows
        '    xRow(2) = 0
        '    SearchProgressBar.Increment(1)
        'Next
        'SearchProgressBar.Increment(1)

        DataGridViewProductMaster.Refresh()
        For Each xRow In productMasterDT.Rows
            Dim estimate As Double = strToCompare.FuzzyMatch(xRow(1))
            If (estimate < 0) Then
                estimate = 0
            End If
            xRow(2) = Math.Round(estimate, 4)
            SearchProgressBar.Increment(1)
        Next
        DataGridViewProductMaster.DataSource = productMasterDT
        productMasterDT.DefaultView.Sort = "Points DESC"
        productMasterDT = productMasterDT.DefaultView.ToTable

    End Sub

    Private Sub AssignPointsItem(strToCompare As String)

        SearchProgressBar.Minimum = 0
        SearchProgressBar.Maximum = productMasterDT.Rows.Count
        SearchProgressBar.Value = 0


        'For Each xRow In productMasterDT.Rows
        '    xRow(2) = 0
        '    SearchProgressBar.Increment(1)
        'Next


        DataGridViewProductMaster.Refresh()
        For Each xRow In productMasterDT.Rows
            Dim estimate As Double = strToCompare.FuzzyMatch(xRow(0))
            If (estimate < 0) Then
                estimate = 0
            End If
            xRow(2) = Math.Round(estimate, 4)
            SearchProgressBar.Increment(1)
        Next
        DataGridViewProductMaster.DataSource = productMasterDT
        productMasterDT.DefaultView.Sort = "Points DESC"
        productMasterDT = productMasterDT.DefaultView.ToTable


    End Sub
End Class
