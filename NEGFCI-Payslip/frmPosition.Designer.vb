<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosition
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPosition))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.GridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btnOption = New System.Windows.Forms.PictureBox()
        Me.btnSearch = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlAdd = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtrate = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtposition = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'GridView
        '
        Me.GridView.AllowUserToAddRows = False
        Me.GridView.AllowUserToDeleteRows = False
        Me.GridView.AllowUserToResizeColumns = False
        Me.GridView.AllowUserToResizeRows = False
        Me.GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridView.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.GridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn1, Me.Column1, Me.DataGridViewButtonColumn2, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.Rate})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(89, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.GridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridView.EnableHeadersVisualStyles = False
        Me.GridView.GridColor = System.Drawing.Color.DimGray
        Me.GridView.Location = New System.Drawing.Point(0, 100)
        Me.GridView.MultiSelect = False
        Me.GridView.Name = "GridView"
        Me.GridView.ReadOnly = True
        Me.GridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridView.RowHeadersVisible = False
        Me.GridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridView.Size = New System.Drawing.Size(500, 373)
        Me.GridView.TabIndex = 251
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewImageColumn1.HeaderText = "Del"
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Edit"
        Me.Column1.Image = CType(resources.GetObject("Column1.Image"), System.Drawing.Image)
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 47
        '
        'DataGridViewButtonColumn2
        '
        Me.DataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewButtonColumn2.HeaderText = "Select"
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.ReadOnly = True
        Me.DataGridViewButtonColumn2.Width = 66
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 34
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn6.HeaderText = "#"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 25
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.HeaderText = "Position"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Rate
        '
        Me.Rate.HeaderText = "Rate"
        Me.Rate.Name = "Rate"
        Me.Rate.ReadOnly = True
        Me.Rate.Width = 73
        '
        'btnAdd
        '
        Me.btnAdd.ActiveBorderThickness = 1
        Me.btnAdd.ActiveCornerRadius = 20
        Me.btnAdd.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnAdd.ActiveForecolor = System.Drawing.Color.White
        Me.btnAdd.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.ButtonText = "Add"
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnAdd.IdleBorderThickness = 1
        Me.btnAdd.IdleCornerRadius = 20
        Me.btnAdd.IdleFillColor = System.Drawing.Color.White
        Me.btnAdd.IdleForecolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnAdd.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnAdd.Location = New System.Drawing.Point(382, 0)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(113, 48)
        Me.btnAdd.TabIndex = 365
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOption
        '
        Me.btnOption.BackColor = System.Drawing.Color.Transparent
        Me.btnOption.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOption.Image = CType(resources.GetObject("btnOption.Image"), System.Drawing.Image)
        Me.btnOption.Location = New System.Drawing.Point(6, 5)
        Me.btnOption.Name = "btnOption"
        Me.btnOption.Size = New System.Drawing.Size(39, 39)
        Me.btnOption.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnOption.TabIndex = 364
        Me.btnOption.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(54, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(39, 39)
        Me.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnSearch.TabIndex = 300
        Me.btnSearch.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnExit.Location = New System.Drawing.Point(462, 7)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(30, 30)
        Me.btnExit.TabIndex = 5
        Me.btnExit.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "List of Position"
        '
        'txtSearch
        '
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSearch.HintForeColor = System.Drawing.Color.DimGray
        Me.txtSearch.HintText = "Input Text...."
        Me.txtSearch.isPassword = False
        Me.txtSearch.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSearch.LineIdleColor = System.Drawing.Color.Silver
        Me.txtSearch.LineMouseHoverColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSearch.LineThickness = 3
        Me.txtSearch.Location = New System.Drawing.Point(93, 4)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(280, 41)
        Me.txtSearch.TabIndex = 299
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnAdd)
        Me.Panel4.Controls.Add(Me.btnOption)
        Me.Panel4.Controls.Add(Me.btnSearch)
        Me.Panel4.Controls.Add(Me.txtSearch)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 48)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(500, 52)
        Me.Panel4.TabIndex = 249
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 48)
        Me.Panel1.TabIndex = 248
        '
        'pnlAdd
        '
        Me.pnlAdd.BackColor = System.Drawing.Color.White
        Me.pnlAdd.Controls.Add(Me.Label3)
        Me.pnlAdd.Controls.Add(Me.btnSave)
        Me.pnlAdd.Controls.Add(Me.Label1)
        Me.pnlAdd.Controls.Add(Me.txtrate)
        Me.pnlAdd.Controls.Add(Me.Label10)
        Me.pnlAdd.Controls.Add(Me.txtposition)
        Me.pnlAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAdd.Location = New System.Drawing.Point(0, 100)
        Me.pnlAdd.Name = "pnlAdd"
        Me.pnlAdd.Size = New System.Drawing.Size(500, 373)
        Me.pnlAdd.TabIndex = 252
        Me.pnlAdd.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 25)
        Me.Label3.TabIndex = 367
        Me.Label3.Text = "Create new"
        '
        'btnSave
        '
        Me.btnSave.ActiveBorderThickness = 1
        Me.btnSave.ActiveCornerRadius = 20
        Me.btnSave.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnSave.ActiveForecolor = System.Drawing.Color.White
        Me.btnSave.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.ButtonText = "Save"
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnSave.IdleBorderThickness = 1
        Me.btnSave.IdleCornerRadius = 20
        Me.btnSave.IdleFillColor = System.Drawing.Color.White
        Me.btnSave.IdleForecolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnSave.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnSave.Location = New System.Drawing.Point(99, 243)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(280, 48)
        Me.btnSave.TabIndex = 366
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(211, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Rate: *"
        '
        'txtrate
        '
        Me.txtrate.BackColor = System.Drawing.Color.White
        Me.txtrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtrate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtrate.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtrate.HintForeColor = System.Drawing.Color.Empty
        Me.txtrate.HintText = ""
        Me.txtrate.isPassword = False
        Me.txtrate.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.txtrate.LineIdleColor = System.Drawing.Color.MediumBlue
        Me.txtrate.LineMouseHoverColor = System.Drawing.Color.LightBlue
        Me.txtrate.LineThickness = 2
        Me.txtrate.Location = New System.Drawing.Point(173, 185)
        Me.txtrate.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(132, 36)
        Me.txtrate.TabIndex = 38
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(200, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 20)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Position: *"
        '
        'txtposition
        '
        Me.txtposition.BackColor = System.Drawing.Color.White
        Me.txtposition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtposition.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtposition.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtposition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtposition.HintForeColor = System.Drawing.Color.Empty
        Me.txtposition.HintText = ""
        Me.txtposition.isPassword = False
        Me.txtposition.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.txtposition.LineIdleColor = System.Drawing.Color.MediumBlue
        Me.txtposition.LineMouseHoverColor = System.Drawing.Color.LightBlue
        Me.txtposition.LineThickness = 2
        Me.txtposition.Location = New System.Drawing.Point(99, 114)
        Me.txtposition.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtposition.Name = "txtposition"
        Me.txtposition.Size = New System.Drawing.Size(280, 36)
        Me.txtposition.TabIndex = 36
        Me.txtposition.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'frmPosition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 473)
        Me.Controls.Add(Me.pnlAdd)
        Me.Controls.Add(Me.GridView)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPosition"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " NEGFC Inc. - Position"
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlAdd.ResumeLayout(False)
        Me.pnlAdd.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents GridView As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btnOption As System.Windows.Forms.PictureBox
    Friend WithEvents btnSearch As System.Windows.Forms.PictureBox
    Friend WithEvents txtSearch As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExit As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlAdd As System.Windows.Forms.Panel
    Friend WithEvents btnSave As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtrate As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtposition As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewButtonColumn2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
