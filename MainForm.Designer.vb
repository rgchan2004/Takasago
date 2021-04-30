<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim MessageBoxSettings1 As Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings = New Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings()
        Dim PdfViewerPrinterSettings1 As Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings = New Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings()
        Dim TextSearchSettings1 As Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings = New Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings()
        Me.DataGridViewResponses = New System.Windows.Forms.DataGridView()
        Me.DataGridViewLines = New System.Windows.Forms.DataGridView()
        Me.SearchProgressBar = New System.Windows.Forms.ProgressBar()
        Me.RemarksTextField = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxShipToCode = New System.Windows.Forms.TextBox()
        Me.DataGridBigData = New System.Windows.Forms.DataGridView()
        Me.RespondButton = New System.Windows.Forms.Button()
        Me.DataGridViewSearch = New System.Windows.Forms.DataGridView()
        Me.DataGridViewWebSearch = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GeneratePDF = New System.Windows.Forms.Button()
        Me.ConvertDocPDF = New System.Windows.Forms.Button()
        Me.ProductMasterLoadButton = New System.Windows.Forms.Button()
        Me.DataGridViewProductMaster = New System.Windows.Forms.DataGridView()
        Me.CalculateProximityButton = New System.Windows.Forms.Button()
        Me.TextBoxStrToSearch = New System.Windows.Forms.TextBox()
        Me.TextBoxShipTo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBoxSoldTo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonChooseItem = New System.Windows.Forms.Button()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.CheckDirectoryButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListBoxPOs = New System.Windows.Forms.ListBox()
        Me.DataGridViewShipTo = New System.Windows.Forms.DataGridView()
        Me.TextBoxItemToSearch = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ButtonChooseCloseMatchItem = New System.Windows.Forms.Button()
        Me.GroupBoxHospitals = New System.Windows.Forms.GroupBox()
        Me.RadioButtonNHG = New System.Windows.Forms.RadioButton()
        Me.RadioButtonNTUCHealth = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButtonSingHealth = New System.Windows.Forms.RadioButton()
        Me.RadioButtonParkway = New System.Windows.Forms.RadioButton()
        Me.ButtonSaveProductsToSql = New System.Windows.Forms.Button()
        Me.TextBoxPO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ButtonLoadPdtXls = New System.Windows.Forms.Button()
        Me.ButtonSaveShipTo = New System.Windows.Forms.Button()
        Me.ButtonRotate90 = New System.Windows.Forms.Button()
        Me.ButtonRotate180 = New System.Windows.Forms.Button()
        Me.ButtonRotate270 = New System.Windows.Forms.Button()
        Me.PdfViewerControl = New Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl()
        Me.ButtonManualEntry = New System.Windows.Forms.Button()
        CType(Me.DataGridViewResponses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridBigData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewWebSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewProductMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewShipTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxHospitals.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewResponses
        '
        Me.DataGridViewResponses.AllowUserToAddRows = False
        Me.DataGridViewResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewResponses.Location = New System.Drawing.Point(326, 254)
        Me.DataGridViewResponses.Name = "DataGridViewResponses"
        Me.DataGridViewResponses.RowHeadersWidth = 82
        Me.DataGridViewResponses.Size = New System.Drawing.Size(662, 293)
        Me.DataGridViewResponses.TabIndex = 0
        '
        'DataGridViewLines
        '
        Me.DataGridViewLines.AllowUserToAddRows = False
        Me.DataGridViewLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridViewLines.Location = New System.Drawing.Point(998, 254)
        Me.DataGridViewLines.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DataGridViewLines.Name = "DataGridViewLines"
        Me.DataGridViewLines.RowHeadersWidth = 82
        Me.DataGridViewLines.RowTemplate.Height = 33
        Me.DataGridViewLines.Size = New System.Drawing.Size(287, 293)
        Me.DataGridViewLines.TabIndex = 4
        '
        'SearchProgressBar
        '
        Me.SearchProgressBar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SearchProgressBar.Location = New System.Drawing.Point(328, 221)
        Me.SearchProgressBar.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.SearchProgressBar.Name = "SearchProgressBar"
        Me.SearchProgressBar.Size = New System.Drawing.Size(339, 21)
        Me.SearchProgressBar.TabIndex = 5
        '
        'RemarksTextField
        '
        Me.RemarksTextField.Location = New System.Drawing.Point(6, 210)
        Me.RemarksTextField.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.RemarksTextField.Multiline = True
        Me.RemarksTextField.Name = "RemarksTextField"
        Me.RemarksTextField.Size = New System.Drawing.Size(196, 25)
        Me.RemarksTextField.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 188)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Remarks"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 132)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Ship To Code"
        '
        'TextBoxShipToCode
        '
        Me.TextBoxShipToCode.Location = New System.Drawing.Point(6, 154)
        Me.TextBoxShipToCode.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.TextBoxShipToCode.Multiline = True
        Me.TextBoxShipToCode.Name = "TextBoxShipToCode"
        Me.TextBoxShipToCode.Size = New System.Drawing.Size(196, 25)
        Me.TextBoxShipToCode.TabIndex = 10
        '
        'DataGridBigData
        '
        Me.DataGridBigData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridBigData.Location = New System.Drawing.Point(470, 892)
        Me.DataGridBigData.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DataGridBigData.Name = "DataGridBigData"
        Me.DataGridBigData.RowHeadersWidth = 82
        Me.DataGridBigData.RowTemplate.Height = 33
        Me.DataGridBigData.Size = New System.Drawing.Size(492, 156)
        Me.DataGridBigData.TabIndex = 14
        Me.DataGridBigData.Visible = False
        '
        'RespondButton
        '
        Me.RespondButton.Image = CType(resources.GetObject("RespondButton.Image"), System.Drawing.Image)
        Me.RespondButton.Location = New System.Drawing.Point(18, 27)
        Me.RespondButton.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.RespondButton.Name = "RespondButton"
        Me.RespondButton.Size = New System.Drawing.Size(102, 60)
        Me.RespondButton.TabIndex = 15
        Me.RespondButton.Text = "Button3"
        Me.RespondButton.UseVisualStyleBackColor = True
        '
        'DataGridViewSearch
        '
        Me.DataGridViewSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSearch.Location = New System.Drawing.Point(145, 807)
        Me.DataGridViewSearch.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DataGridViewSearch.Name = "DataGridViewSearch"
        Me.DataGridViewSearch.RowHeadersWidth = 82
        Me.DataGridViewSearch.RowTemplate.Height = 33
        Me.DataGridViewSearch.Size = New System.Drawing.Size(354, 397)
        Me.DataGridViewSearch.TabIndex = 16
        Me.DataGridViewSearch.Visible = False
        '
        'DataGridViewWebSearch
        '
        Me.DataGridViewWebSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewWebSearch.Location = New System.Drawing.Point(11, 748)
        Me.DataGridViewWebSearch.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DataGridViewWebSearch.Name = "DataGridViewWebSearch"
        Me.DataGridViewWebSearch.RowHeadersWidth = 82
        Me.DataGridViewWebSearch.RowTemplate.Height = 33
        Me.DataGridViewWebSearch.Size = New System.Drawing.Size(342, 504)
        Me.DataGridViewWebSearch.TabIndex = 18
        Me.DataGridViewWebSearch.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 13)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Load Orders :"
        '
        'GeneratePDF
        '
        Me.GeneratePDF.Location = New System.Drawing.Point(6, 17)
        Me.GeneratePDF.Name = "GeneratePDF"
        Me.GeneratePDF.Size = New System.Drawing.Size(196, 23)
        Me.GeneratePDF.TabIndex = 20
        Me.GeneratePDF.Text = "Generate Order Document"
        Me.GeneratePDF.UseVisualStyleBackColor = True
        '
        'ConvertDocPDF
        '
        Me.ConvertDocPDF.Location = New System.Drawing.Point(326, 129)
        Me.ConvertDocPDF.Name = "ConvertDocPDF"
        Me.ConvertDocPDF.Size = New System.Drawing.Size(161, 23)
        Me.ConvertDocPDF.TabIndex = 21
        Me.ConvertDocPDF.Text = "Perform Text Extract"
        Me.ConvertDocPDF.UseVisualStyleBackColor = True
        '
        'ProductMasterLoadButton
        '
        Me.ProductMasterLoadButton.Location = New System.Drawing.Point(326, 156)
        Me.ProductMasterLoadButton.Name = "ProductMasterLoadButton"
        Me.ProductMasterLoadButton.Size = New System.Drawing.Size(161, 25)
        Me.ProductMasterLoadButton.TabIndex = 22
        Me.ProductMasterLoadButton.Text = "Load Product Master"
        Me.ProductMasterLoadButton.UseVisualStyleBackColor = True
        '
        'DataGridViewProductMaster
        '
        Me.DataGridViewProductMaster.AllowUserToAddRows = False
        Me.DataGridViewProductMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewProductMaster.Location = New System.Drawing.Point(1, 254)
        Me.DataGridViewProductMaster.Name = "DataGridViewProductMaster"
        Me.DataGridViewProductMaster.ReadOnly = True
        Me.DataGridViewProductMaster.RowHeadersWidth = 82
        Me.DataGridViewProductMaster.Size = New System.Drawing.Size(320, 293)
        Me.DataGridViewProductMaster.TabIndex = 23
        '
        'CalculateProximityButton
        '
        Me.CalculateProximityButton.Location = New System.Drawing.Point(495, 129)
        Me.CalculateProximityButton.Name = "CalculateProximityButton"
        Me.CalculateProximityButton.Size = New System.Drawing.Size(172, 23)
        Me.CalculateProximityButton.TabIndex = 24
        Me.CalculateProximityButton.Text = "Choose Closest Match Item Desc"
        Me.CalculateProximityButton.UseVisualStyleBackColor = True
        '
        'TextBoxStrToSearch
        '
        Me.TextBoxStrToSearch.Location = New System.Drawing.Point(767, 134)
        Me.TextBoxStrToSearch.Name = "TextBoxStrToSearch"
        Me.TextBoxStrToSearch.Size = New System.Drawing.Size(221, 20)
        Me.TextBoxStrToSearch.TabIndex = 25
        '
        'TextBoxShipTo
        '
        Me.TextBoxShipTo.Location = New System.Drawing.Point(170, 36)
        Me.TextBoxShipTo.Multiline = True
        Me.TextBoxShipTo.Name = "TextBoxShipTo"
        Me.TextBoxShipTo.Size = New System.Drawing.Size(151, 48)
        Me.TextBoxShipTo.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(124, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Ship to"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1140, 1086)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(381, 48)
        Me.TextBox1.TabIndex = 28
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1140, 1086)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(381, 48)
        Me.TextBox2.TabIndex = 29
        '
        'TextBoxSoldTo
        '
        Me.TextBoxSoldTo.Location = New System.Drawing.Point(171, 90)
        Me.TextBoxSoldTo.Multiline = True
        Me.TextBoxSoldTo.Name = "TextBoxSoldTo"
        Me.TextBoxSoldTo.Size = New System.Drawing.Size(150, 40)
        Me.TextBoxSoldTo.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(685, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Ship To"
        '
        'ButtonChooseItem
        '
        Me.ButtonChooseItem.Location = New System.Drawing.Point(886, 210)
        Me.ButtonChooseItem.Name = "ButtonChooseItem"
        Me.ButtonChooseItem.Size = New System.Drawing.Size(102, 35)
        Me.ButtonChooseItem.TabIndex = 32
        Me.ButtonChooseItem.Text = "Assign Item ------>>"
        Me.ButtonChooseItem.UseVisualStyleBackColor = True
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'CheckDirectoryButton
        '
        Me.CheckDirectoryButton.Location = New System.Drawing.Point(13, 148)
        Me.CheckDirectoryButton.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.CheckDirectoryButton.Name = "CheckDirectoryButton"
        Me.CheckDirectoryButton.Size = New System.Drawing.Size(103, 33)
        Me.CheckDirectoryButton.TabIndex = 33
        Me.CheckDirectoryButton.Text = "Check PO PDFs"
        Me.CheckDirectoryButton.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(120, 13)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Ship to Location :"
        '
        'ListBoxPOs
        '
        Me.ListBoxPOs.FormattingEnabled = True
        Me.ListBoxPOs.Location = New System.Drawing.Point(122, 149)
        Me.ListBoxPOs.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ListBoxPOs.Name = "ListBoxPOs"
        Me.ListBoxPOs.Size = New System.Drawing.Size(199, 95)
        Me.ListBoxPOs.TabIndex = 36
        '
        'DataGridViewShipTo
        '
        Me.DataGridViewShipTo.AllowUserToDeleteRows = False
        Me.DataGridViewShipTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewShipTo.Location = New System.Drawing.Point(767, 24)
        Me.DataGridViewShipTo.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DataGridViewShipTo.Name = "DataGridViewShipTo"
        Me.DataGridViewShipTo.RowHeadersWidth = 82
        Me.DataGridViewShipTo.RowTemplate.Height = 33
        Me.DataGridViewShipTo.Size = New System.Drawing.Size(221, 96)
        Me.DataGridViewShipTo.TabIndex = 37
        '
        'TextBoxItemToSearch
        '
        Me.TextBoxItemToSearch.Location = New System.Drawing.Point(767, 172)
        Me.TextBoxItemToSearch.Name = "TextBoxItemToSearch"
        Me.TextBoxItemToSearch.Size = New System.Drawing.Size(221, 20)
        Me.TextBoxItemToSearch.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(678, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Item Description"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(694, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Item Number"
        '
        'ButtonChooseCloseMatchItem
        '
        Me.ButtonChooseCloseMatchItem.Location = New System.Drawing.Point(495, 155)
        Me.ButtonChooseCloseMatchItem.Name = "ButtonChooseCloseMatchItem"
        Me.ButtonChooseCloseMatchItem.Size = New System.Drawing.Size(172, 26)
        Me.ButtonChooseCloseMatchItem.TabIndex = 41
        Me.ButtonChooseCloseMatchItem.Text = "Choose Closest Match Item No"
        Me.ButtonChooseCloseMatchItem.UseVisualStyleBackColor = True
        '
        'GroupBoxHospitals
        '
        Me.GroupBoxHospitals.Controls.Add(Me.RadioButtonNHG)
        Me.GroupBoxHospitals.Controls.Add(Me.RadioButtonNTUCHealth)
        Me.GroupBoxHospitals.Controls.Add(Me.RadioButton4)
        Me.GroupBoxHospitals.Controls.Add(Me.RadioButton3)
        Me.GroupBoxHospitals.Controls.Add(Me.RadioButtonSingHealth)
        Me.GroupBoxHospitals.Controls.Add(Me.RadioButtonParkway)
        Me.GroupBoxHospitals.Location = New System.Drawing.Point(326, 13)
        Me.GroupBoxHospitals.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBoxHospitals.Name = "GroupBoxHospitals"
        Me.GroupBoxHospitals.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBoxHospitals.Size = New System.Drawing.Size(341, 102)
        Me.GroupBoxHospitals.TabIndex = 42
        Me.GroupBoxHospitals.TabStop = False
        Me.GroupBoxHospitals.Text = "Hospital"
        '
        'RadioButtonNHG
        '
        Me.RadioButtonNHG.AutoSize = True
        Me.RadioButtonNHG.Location = New System.Drawing.Point(13, 40)
        Me.RadioButtonNHG.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadioButtonNHG.Name = "RadioButtonNHG"
        Me.RadioButtonNHG.Size = New System.Drawing.Size(49, 17)
        Me.RadioButtonNHG.TabIndex = 5
        Me.RadioButtonNHG.TabStop = True
        Me.RadioButtonNHG.Text = "NHG"
        Me.RadioButtonNHG.UseVisualStyleBackColor = True
        '
        'RadioButtonNTUCHealth
        '
        Me.RadioButtonNTUCHealth.AutoSize = True
        Me.RadioButtonNTUCHealth.Location = New System.Drawing.Point(194, 19)
        Me.RadioButtonNTUCHealth.Name = "RadioButtonNTUCHealth"
        Me.RadioButtonNTUCHealth.Size = New System.Drawing.Size(89, 17)
        Me.RadioButtonNTUCHealth.TabIndex = 4
        Me.RadioButtonNTUCHealth.TabStop = True
        Me.RadioButtonNTUCHealth.Text = "NTUC Health"
        Me.RadioButtonNTUCHealth.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(13, 79)
        Me.RadioButton4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(99, 17)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Changi Hospital"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(194, 36)
        Me.RadioButton3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(119, 17)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Seng Kang Hospital"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButtonSingHealth
        '
        Me.RadioButtonSingHealth.AutoSize = True
        Me.RadioButtonSingHealth.Location = New System.Drawing.Point(13, 19)
        Me.RadioButtonSingHealth.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadioButtonSingHealth.Name = "RadioButtonSingHealth"
        Me.RadioButtonSingHealth.Size = New System.Drawing.Size(116, 17)
        Me.RadioButtonSingHealth.TabIndex = 1
        Me.RadioButtonSingHealth.TabStop = True
        Me.RadioButtonSingHealth.Text = "SingHealth Pharma"
        Me.RadioButtonSingHealth.UseVisualStyleBackColor = True
        '
        'RadioButtonParkway
        '
        Me.RadioButtonParkway.AutoSize = True
        Me.RadioButtonParkway.Location = New System.Drawing.Point(13, 60)
        Me.RadioButtonParkway.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadioButtonParkway.Name = "RadioButtonParkway"
        Me.RadioButtonParkway.Size = New System.Drawing.Size(107, 17)
        Me.RadioButtonParkway.TabIndex = 0
        Me.RadioButtonParkway.TabStop = True
        Me.RadioButtonParkway.Text = "Parkway Hospital"
        Me.RadioButtonParkway.UseVisualStyleBackColor = True
        '
        'ButtonSaveProductsToSql
        '
        Me.ButtonSaveProductsToSql.Location = New System.Drawing.Point(326, 184)
        Me.ButtonSaveProductsToSql.Name = "ButtonSaveProductsToSql"
        Me.ButtonSaveProductsToSql.Size = New System.Drawing.Size(161, 25)
        Me.ButtonSaveProductsToSql.TabIndex = 43
        Me.ButtonSaveProductsToSql.Text = "Save Product Master to Server"
        Me.ButtonSaveProductsToSql.UseVisualStyleBackColor = True
        '
        'TextBoxPO
        '
        Me.TextBoxPO.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxPO.Location = New System.Drawing.Point(6, 98)
        Me.TextBoxPO.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.TextBoxPO.Multiline = True
        Me.TextBoxPO.Name = "TextBoxPO"
        Me.TextBoxPO.ReadOnly = True
        Me.TextBoxPO.Size = New System.Drawing.Size(196, 25)
        Me.TextBoxPO.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 78)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "PO No."
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox1.Controls.Add(Me.ButtonManualEntry)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextBoxPO)
        Me.GroupBox1.Controls.Add(Me.GeneratePDF)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBoxShipToCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RemarksTextField)
        Me.GroupBox1.Location = New System.Drawing.Point(992, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 539)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Convert to JDE"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(124, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Sold To"
        '
        'ButtonLoadPdtXls
        '
        Me.ButtonLoadPdtXls.Location = New System.Drawing.Point(495, 184)
        Me.ButtonLoadPdtXls.Name = "ButtonLoadPdtXls"
        Me.ButtonLoadPdtXls.Size = New System.Drawing.Size(172, 25)
        Me.ButtonLoadPdtXls.TabIndex = 49
        Me.ButtonLoadPdtXls.Text = "Load Product Master from XLS"
        Me.ButtonLoadPdtXls.UseVisualStyleBackColor = True
        '
        'ButtonSaveShipTo
        '
        Me.ButtonSaveShipTo.Location = New System.Drawing.Point(674, 90)
        Me.ButtonSaveShipTo.Name = "ButtonSaveShipTo"
        Me.ButtonSaveShipTo.Size = New System.Drawing.Size(88, 25)
        Me.ButtonSaveShipTo.TabIndex = 50
        Me.ButtonSaveShipTo.Text = "Save Ship To"
        Me.ButtonSaveShipTo.UseVisualStyleBackColor = True
        '
        'ButtonRotate90
        '
        Me.ButtonRotate90.Location = New System.Drawing.Point(679, 209)
        Me.ButtonRotate90.Name = "ButtonRotate90"
        Me.ButtonRotate90.Size = New System.Drawing.Size(69, 36)
        Me.ButtonRotate90.TabIndex = 53
        Me.ButtonRotate90.Text = "Rotate 90deg PDF"
        Me.ButtonRotate90.UseVisualStyleBackColor = True
        '
        'ButtonRotate180
        '
        Me.ButtonRotate180.Location = New System.Drawing.Point(748, 209)
        Me.ButtonRotate180.Name = "ButtonRotate180"
        Me.ButtonRotate180.Size = New System.Drawing.Size(81, 36)
        Me.ButtonRotate180.TabIndex = 54
        Me.ButtonRotate180.Text = "Rotate 180deg PDF"
        Me.ButtonRotate180.UseVisualStyleBackColor = True
        '
        'ButtonRotate270
        '
        Me.ButtonRotate270.Location = New System.Drawing.Point(829, 209)
        Me.ButtonRotate270.Name = "ButtonRotate270"
        Me.ButtonRotate270.Size = New System.Drawing.Size(57, 36)
        Me.ButtonRotate270.TabIndex = 55
        Me.ButtonRotate270.Text = "Rotate 270 PDF"
        Me.ButtonRotate270.UseVisualStyleBackColor = True
        '
        'PdfViewerControl
        '
        Me.PdfViewerControl.CursorMode = Syncfusion.Windows.Forms.PdfViewer.PdfViewerCursorMode.SelectTool
        Me.PdfViewerControl.EnableContextMenu = True
        Me.PdfViewerControl.EnableNotificationBar = True
        Me.PdfViewerControl.HorizontalScrollOffset = 0
        Me.PdfViewerControl.IsBookmarkEnabled = True
        Me.PdfViewerControl.IsTextSearchEnabled = True
        Me.PdfViewerControl.IsTextSelectionEnabled = True
        Me.PdfViewerControl.Location = New System.Drawing.Point(1, 552)
        Me.PdfViewerControl.Margin = New System.Windows.Forms.Padding(2)
        MessageBoxSettings1.EnableNotification = True
        Me.PdfViewerControl.MessageBoxSettings = MessageBoxSettings1
        Me.PdfViewerControl.MinimumZoomPercentage = 50
        Me.PdfViewerControl.Name = "PdfViewerControl"
        Me.PdfViewerControl.PageBorderThickness = 1
        PdfViewerPrinterSettings1.PageOrientation = Syncfusion.Windows.PdfViewer.PdfViewerPrintOrientation.[Auto]
        PdfViewerPrinterSettings1.PageSize = Syncfusion.Windows.PdfViewer.PdfViewerPrintSize.ActualSize
        PdfViewerPrinterSettings1.PrintLocation = CType(resources.GetObject("PdfViewerPrinterSettings1.PrintLocation"), System.Drawing.PointF)
        PdfViewerPrinterSettings1.ShowPrintStatusDialog = True
        Me.PdfViewerControl.PrinterSettings = PdfViewerPrinterSettings1
        Me.PdfViewerControl.ReferencePath = Nothing
        Me.PdfViewerControl.ScrollDisplacementValue = 0
        Me.PdfViewerControl.ShowHorizontalScrollBar = True
        Me.PdfViewerControl.ShowToolBar = True
        Me.PdfViewerControl.ShowVerticalScrollBar = True
        Me.PdfViewerControl.Size = New System.Drawing.Size(1295, 392)
        Me.PdfViewerControl.SpaceBetweenPages = 8
        Me.PdfViewerControl.TabIndex = 52
        Me.PdfViewerControl.Text = "PdfViewerControl1"
        TextSearchSettings1.CurrentInstanceColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(64, Byte), Integer))
        TextSearchSettings1.HighlightAllInstance = True
        TextSearchSettings1.OtherInstanceColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PdfViewerControl.TextSearchSettings = TextSearchSettings1
        Me.PdfViewerControl.ThemeName = "Default"
        Me.PdfViewerControl.VerticalScrollOffset = 0
        Me.PdfViewerControl.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.[Default]
        Me.PdfViewerControl.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.[Default]
        '
        'ButtonManualEntry
        '
        Me.ButtonManualEntry.Location = New System.Drawing.Point(6, 48)
        Me.ButtonManualEntry.Name = "ButtonManualEntry"
        Me.ButtonManualEntry.Size = New System.Drawing.Size(196, 23)
        Me.ButtonManualEntry.TabIndex = 47
        Me.ButtonManualEntry.Text = "Manual Entry"
        Me.ButtonManualEntry.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1545, 933)
        Me.Controls.Add(Me.ButtonRotate270)
        Me.Controls.Add(Me.ButtonRotate180)
        Me.Controls.Add(Me.ButtonRotate90)
        Me.Controls.Add(Me.PdfViewerControl)
        Me.Controls.Add(Me.ButtonSaveShipTo)
        Me.Controls.Add(Me.ButtonLoadPdtXls)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ButtonSaveProductsToSql)
        Me.Controls.Add(Me.GroupBoxHospitals)
        Me.Controls.Add(Me.ButtonChooseCloseMatchItem)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBoxItemToSearch)
        Me.Controls.Add(Me.DataGridViewShipTo)
        Me.Controls.Add(Me.ListBoxPOs)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CheckDirectoryButton)
        Me.Controls.Add(Me.ButtonChooseItem)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxSoldTo)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxShipTo)
        Me.Controls.Add(Me.TextBoxStrToSearch)
        Me.Controls.Add(Me.CalculateProximityButton)
        Me.Controls.Add(Me.DataGridViewProductMaster)
        Me.Controls.Add(Me.ProductMasterLoadButton)
        Me.Controls.Add(Me.ConvertDocPDF)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridViewWebSearch)
        Me.Controls.Add(Me.DataGridViewSearch)
        Me.Controls.Add(Me.RespondButton)
        Me.Controls.Add(Me.DataGridBigData)
        Me.Controls.Add(Me.SearchProgressBar)
        Me.Controls.Add(Me.DataGridViewResponses)
        Me.Controls.Add(Me.DataGridViewLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "MainForm"
        Me.Text = "DCH Auriga Pharma Bid Assist"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridViewResponses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridBigData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewWebSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewProductMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewShipTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxHospitals.ResumeLayout(False)
        Me.GroupBoxHospitals.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridViewResponses As DataGridView
    Friend WithEvents DataGridViewLines As DataGridView
    Friend WithEvents SearchProgressBar As ProgressBar
    Friend WithEvents RemarksTextField As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxShipToCode As TextBox
    Friend WithEvents DataGridBigData As DataGridView
    Friend WithEvents RespondButton As Button
    Friend WithEvents DataGridViewSearch As DataGridView
    Friend WithEvents DataGridViewWebSearch As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents GeneratePDF As Button
    Friend WithEvents ConvertDocPDF As Button
    Friend WithEvents ProductMasterLoadButton As Button
    Friend WithEvents DataGridViewProductMaster As DataGridView
    Friend WithEvents CalculateProximityButton As Button
    Friend WithEvents TextBoxStrToSearch As TextBox
    Friend WithEvents TextBoxShipTo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBoxSoldTo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonChooseItem As Button
    Friend WithEvents DirectorySearcher1 As DirectoryServices.DirectorySearcher
    Friend WithEvents CheckDirectoryButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents ListBoxPOs As ListBox
    Friend WithEvents DataGridViewShipTo As DataGridView
    Friend WithEvents TextBoxItemToSearch As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ButtonChooseCloseMatchItem As Button
    Friend WithEvents GroupBoxHospitals As GroupBox
    Friend WithEvents RadioButtonParkway As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButtonSingHealth As RadioButton
    Friend WithEvents ButtonSaveProductsToSql As Button
    Friend WithEvents TextBoxPO As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ButtonLoadPdtXls As Button
    Friend WithEvents ButtonSaveShipTo As Button
    Friend WithEvents PdfViewerControl As Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl
    Friend WithEvents ButtonRotate90 As Button
    Friend WithEvents ButtonRotate180 As Button
    Friend WithEvents ButtonRotate270 As Button
    Friend WithEvents RadioButtonNTUCHealth As RadioButton
    Friend WithEvents RadioButtonNHG As RadioButton
    Friend WithEvents ButtonManualEntry As Button
End Class
