<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerate
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerate))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.pnlCenter = New System.Windows.Forms.Panel()
        Me.lblRate = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSalary = New System.Windows.Forms.Label()
        Me.txtPayPeriod = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCompute = New System.Windows.Forms.Button()
        Me.btnSaveOnly = New System.Windows.Forms.Button()
        Me.btnSavePrint = New System.Windows.Forms.Button()
        Me.txtOTrate = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblNetPay = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblIncentTotal = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbldeductTotal = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOT = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.txtworkHR = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GridViewIncent = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GridViewDeduct = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlCenter.SuspendLayout()
        CType(Me.GridViewIncent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDeduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'pnlCenter
        '
        Me.pnlCenter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlCenter.Controls.Add(Me.Button1)
        Me.pnlCenter.Controls.Add(Me.lblRate)
        Me.pnlCenter.Controls.Add(Me.Label10)
        Me.pnlCenter.Controls.Add(Me.lblSalary)
        Me.pnlCenter.Controls.Add(Me.txtPayPeriod)
        Me.pnlCenter.Controls.Add(Me.Label21)
        Me.pnlCenter.Controls.Add(Me.btnClear)
        Me.pnlCenter.Controls.Add(Me.btnCompute)
        Me.pnlCenter.Controls.Add(Me.btnSaveOnly)
        Me.pnlCenter.Controls.Add(Me.btnSavePrint)
        Me.pnlCenter.Controls.Add(Me.txtOTrate)
        Me.pnlCenter.Controls.Add(Me.Label20)
        Me.pnlCenter.Controls.Add(Me.lblNetPay)
        Me.pnlCenter.Controls.Add(Me.Label18)
        Me.pnlCenter.Controls.Add(Me.lblIncentTotal)
        Me.pnlCenter.Controls.Add(Me.Label17)
        Me.pnlCenter.Controls.Add(Me.lbldeductTotal)
        Me.pnlCenter.Controls.Add(Me.Label11)
        Me.pnlCenter.Controls.Add(Me.txtOT)
        Me.pnlCenter.Controls.Add(Me.txtworkHR)
        Me.pnlCenter.Controls.Add(Me.lblPosition)
        Me.pnlCenter.Controls.Add(Me.lblDepartment)
        Me.pnlCenter.Controls.Add(Me.lblName)
        Me.pnlCenter.Controls.Add(Me.Label9)
        Me.pnlCenter.Controls.Add(Me.GridViewIncent)
        Me.pnlCenter.Controls.Add(Me.GridViewDeduct)
        Me.pnlCenter.Controls.Add(Me.Label8)
        Me.pnlCenter.Controls.Add(Me.Label7)
        Me.pnlCenter.Controls.Add(Me.Label6)
        Me.pnlCenter.Controls.Add(Me.Label5)
        Me.pnlCenter.Controls.Add(Me.Label4)
        Me.pnlCenter.Controls.Add(Me.Label2)
        Me.pnlCenter.Controls.Add(Me.Label1)
        Me.pnlCenter.Controls.Add(Me.Label3)
        Me.pnlCenter.Location = New System.Drawing.Point(63, 12)
        Me.pnlCenter.Name = "pnlCenter"
        Me.pnlCenter.Size = New System.Drawing.Size(1169, 560)
        Me.pnlCenter.TabIndex = 1
        '
        'lblRate
        '
        Me.lblRate.AutoSize = True
        Me.lblRate.BackColor = System.Drawing.Color.Transparent
        Me.lblRate.Font = New System.Drawing.Font("Century Gothic", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRate.Location = New System.Drawing.Point(510, 83)
        Me.lblRate.Name = "lblRate"
        Me.lblRate.Size = New System.Drawing.Size(74, 23)
        Me.lblRate.TabIndex = 409
        Me.lblRate.Text = "--------"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(455, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 23)
        Me.Label10.TabIndex = 408
        Me.Label10.Text = "RATE:"
        '
        'lblSalary
        '
        Me.lblSalary.BackColor = System.Drawing.Color.Transparent
        Me.lblSalary.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalary.ForeColor = System.Drawing.Color.Blue
        Me.lblSalary.Location = New System.Drawing.Point(776, 162)
        Me.lblSalary.Name = "lblSalary"
        Me.lblSalary.Size = New System.Drawing.Size(228, 23)
        Me.lblSalary.TabIndex = 407
        Me.lblSalary.Text = "---------------"
        Me.lblSalary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayPeriod
        '
        Me.txtPayPeriod.BackColor = System.Drawing.Color.White
        Me.txtPayPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPayPeriod.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayPeriod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPayPeriod.HintForeColor = System.Drawing.Color.Empty
        Me.txtPayPeriod.HintText = ""
        Me.txtPayPeriod.isPassword = False
        Me.txtPayPeriod.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.txtPayPeriod.LineIdleColor = System.Drawing.Color.MediumBlue
        Me.txtPayPeriod.LineMouseHoverColor = System.Drawing.Color.LightBlue
        Me.txtPayPeriod.LineThickness = 2
        Me.txtPayPeriod.Location = New System.Drawing.Point(733, 115)
        Me.txtPayPeriod.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtPayPeriod.Name = "txtPayPeriod"
        Me.txtPayPeriod.Size = New System.Drawing.Size(332, 36)
        Me.txtPayPeriod.TabIndex = 406
        Me.txtPayPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(609, 122)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(123, 23)
        Me.Label21.TabIndex = 405
        Me.Label21.Text = "PAY PERIOD:"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(335, 516)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(155, 37)
        Me.btnClear.TabIndex = 404
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnCompute
        '
        Me.btnCompute.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnCompute.FlatAppearance.BorderSize = 0
        Me.btnCompute.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCompute.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompute.ForeColor = System.Drawing.Color.White
        Me.btnCompute.Location = New System.Drawing.Point(496, 516)
        Me.btnCompute.Name = "btnCompute"
        Me.btnCompute.Size = New System.Drawing.Size(176, 37)
        Me.btnCompute.TabIndex = 403
        Me.btnCompute.Text = "Compute Total"
        Me.btnCompute.UseVisualStyleBackColor = False
        '
        'btnSaveOnly
        '
        Me.btnSaveOnly.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnSaveOnly.FlatAppearance.BorderSize = 0
        Me.btnSaveOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveOnly.ForeColor = System.Drawing.Color.White
        Me.btnSaveOnly.Location = New System.Drawing.Point(174, 516)
        Me.btnSaveOnly.Name = "btnSaveOnly"
        Me.btnSaveOnly.Size = New System.Drawing.Size(155, 37)
        Me.btnSaveOnly.TabIndex = 402
        Me.btnSaveOnly.Text = "Save Only"
        Me.btnSaveOnly.UseVisualStyleBackColor = False
        '
        'btnSavePrint
        '
        Me.btnSavePrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnSavePrint.FlatAppearance.BorderSize = 0
        Me.btnSavePrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSavePrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavePrint.ForeColor = System.Drawing.Color.White
        Me.btnSavePrint.Location = New System.Drawing.Point(13, 516)
        Me.btnSavePrint.Name = "btnSavePrint"
        Me.btnSavePrint.Size = New System.Drawing.Size(155, 37)
        Me.btnSavePrint.TabIndex = 401
        Me.btnSavePrint.Text = "Save && Print"
        Me.btnSavePrint.UseVisualStyleBackColor = False
        '
        'txtOTrate
        '
        Me.txtOTrate.BackColor = System.Drawing.Color.White
        Me.txtOTrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOTrate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOTrate.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOTrate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtOTrate.HintForeColor = System.Drawing.Color.Empty
        Me.txtOTrate.HintText = ""
        Me.txtOTrate.isPassword = False
        Me.txtOTrate.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.txtOTrate.LineIdleColor = System.Drawing.Color.MediumBlue
        Me.txtOTrate.LineMouseHoverColor = System.Drawing.Color.LightBlue
        Me.txtOTrate.LineThickness = 2
        Me.txtOTrate.Location = New System.Drawing.Point(277, 155)
        Me.txtOTrate.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtOTrate.Name = "txtOTrate"
        Me.txtOTrate.Size = New System.Drawing.Size(84, 36)
        Me.txtOTrate.TabIndex = 400
        Me.txtOTrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(127, 162)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(153, 23)
        Me.Label20.TabIndex = 399
        Me.Label20.Text = "OVERTIME RATE:"
        '
        'lblNetPay
        '
        Me.lblNetPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetPay.ForeColor = System.Drawing.Color.Red
        Me.lblNetPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNetPay.Location = New System.Drawing.Point(945, 520)
        Me.lblNetPay.Name = "lblNetPay"
        Me.lblNetPay.Size = New System.Drawing.Size(221, 33)
        Me.lblNetPay.TabIndex = 398
        Me.lblNetPay.Text = "----------------"
        Me.lblNetPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.Location = New System.Drawing.Point(808, 520)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(131, 33)
        Me.Label18.TabIndex = 397
        Me.Label18.Text = "NETPAY:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIncentTotal
        '
        Me.lblIncentTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblIncentTotal.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncentTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblIncentTotal.Location = New System.Drawing.Point(852, 471)
        Me.lblIncentTotal.Name = "lblIncentTotal"
        Me.lblIncentTotal.Size = New System.Drawing.Size(213, 23)
        Me.lblIncentTotal.TabIndex = 396
        Me.lblIncentTotal.Text = "---------------"
        Me.lblIncentTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(609, 471)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 23)
        Me.Label17.TabIndex = 395
        Me.Label17.Text = "TOTAL:"
        '
        'lbldeductTotal
        '
        Me.lbldeductTotal.BackColor = System.Drawing.Color.Transparent
        Me.lbldeductTotal.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldeductTotal.ForeColor = System.Drawing.Color.Blue
        Me.lbldeductTotal.Location = New System.Drawing.Point(372, 471)
        Me.lbldeductTotal.Name = "lbldeductTotal"
        Me.lbldeductTotal.Size = New System.Drawing.Size(213, 23)
        Me.lbldeductTotal.TabIndex = 394
        Me.lbldeductTotal.Text = "---------------"
        Me.lbldeductTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(129, 471)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 23)
        Me.Label11.TabIndex = 393
        Me.Label11.Text = "TOTAL:"
        '
        'txtOT
        '
        Me.txtOT.BackColor = System.Drawing.Color.White
        Me.txtOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOT.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtOT.HintForeColor = System.Drawing.Color.Empty
        Me.txtOT.HintText = ""
        Me.txtOT.isPassword = False
        Me.txtOT.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.txtOT.LineIdleColor = System.Drawing.Color.MediumBlue
        Me.txtOT.LineMouseHoverColor = System.Drawing.Color.LightBlue
        Me.txtOT.LineThickness = 2
        Me.txtOT.Location = New System.Drawing.Point(273, 115)
        Me.txtOT.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtOT.Name = "txtOT"
        Me.txtOT.Size = New System.Drawing.Size(84, 36)
        Me.txtOT.TabIndex = 392
        Me.txtOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtworkHR
        '
        Me.txtworkHR.BackColor = System.Drawing.Color.White
        Me.txtworkHR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtworkHR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtworkHR.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtworkHR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtworkHR.HintForeColor = System.Drawing.Color.Empty
        Me.txtworkHR.HintText = ""
        Me.txtworkHR.isPassword = False
        Me.txtworkHR.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.txtworkHR.LineIdleColor = System.Drawing.Color.MediumBlue
        Me.txtworkHR.LineMouseHoverColor = System.Drawing.Color.LightBlue
        Me.txtworkHR.LineThickness = 2
        Me.txtworkHR.Location = New System.Drawing.Point(363, 76)
        Me.txtworkHR.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtworkHR.Name = "txtworkHR"
        Me.txtworkHR.Size = New System.Drawing.Size(84, 36)
        Me.txtworkHR.TabIndex = 391
        Me.txtworkHR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.BackColor = System.Drawing.Color.Transparent
        Me.lblPosition.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.ForeColor = System.Drawing.Color.Black
        Me.lblPosition.Location = New System.Drawing.Point(706, 83)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(124, 22)
        Me.lblPosition.TabIndex = 389
        Me.lblPosition.Text = "-------------------"
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartment.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment.ForeColor = System.Drawing.Color.Black
        Me.lblDepartment.Location = New System.Drawing.Point(737, 49)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(124, 22)
        Me.lblDepartment.TabIndex = 388
        Me.lblDepartment.Text = "-------------------"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(294, 49)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(124, 22)
        Me.lblName.TabIndex = 385
        Me.lblName.Text = "-------------------"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Location = New System.Drawing.Point(7, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(250, 33)
        Me.Label9.TabIndex = 384
        Me.Label9.Text = "Generate Payslip"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GridViewIncent
        '
        Me.GridViewIncent.AllowUserToAddRows = False
        Me.GridViewIncent.AllowUserToDeleteRows = False
        Me.GridViewIncent.AllowUserToResizeColumns = False
        Me.GridViewIncent.AllowUserToResizeRows = False
        Me.GridViewIncent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridViewIncent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridViewIncent.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.GridViewIncent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GridViewIncent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewIncent.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.GridViewIncent.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn3, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(154, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewIncent.DefaultCellStyle = DataGridViewCellStyle9
        Me.GridViewIncent.EnableHeadersVisualStyles = False
        Me.GridViewIncent.GridColor = System.Drawing.Color.DimGray
        Me.GridViewIncent.Location = New System.Drawing.Point(613, 223)
        Me.GridViewIncent.MultiSelect = False
        Me.GridViewIncent.Name = "GridViewIncent"
        Me.GridViewIncent.ReadOnly = True
        Me.GridViewIncent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridViewIncent.RowHeadersVisible = False
        Me.GridViewIncent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GridViewIncent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewIncent.Size = New System.Drawing.Size(452, 245)
        Me.GridViewIncent.TabIndex = 383
        '
        'DataGridViewImageColumn3
        '
        Me.DataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewImageColumn3.HeaderText = "Del"
        Me.DataGridViewImageColumn3.Image = CType(resources.GetObject("DataGridViewImageColumn3.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3"
        Me.DataGridViewImageColumn3.ReadOnly = True
        Me.DataGridViewImageColumn3.Width = 42
        '
        'DataGridViewTextBoxColumn6
        '
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
        Me.DataGridViewTextBoxColumn7.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn8.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 96
        '
        'GridViewDeduct
        '
        Me.GridViewDeduct.AllowUserToAddRows = False
        Me.GridViewDeduct.AllowUserToDeleteRows = False
        Me.GridViewDeduct.AllowUserToResizeColumns = False
        Me.GridViewDeduct.AllowUserToResizeRows = False
        Me.GridViewDeduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridViewDeduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridViewDeduct.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.GridViewDeduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GridViewDeduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewDeduct.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.GridViewDeduct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(154, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewDeduct.DefaultCellStyle = DataGridViewCellStyle12
        Me.GridViewDeduct.EnableHeadersVisualStyles = False
        Me.GridViewDeduct.GridColor = System.Drawing.Color.DimGray
        Me.GridViewDeduct.Location = New System.Drawing.Point(133, 223)
        Me.GridViewDeduct.MultiSelect = False
        Me.GridViewDeduct.Name = "GridViewDeduct"
        Me.GridViewDeduct.ReadOnly = True
        Me.GridViewDeduct.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridViewDeduct.RowHeadersVisible = False
        Me.GridViewDeduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GridViewDeduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewDeduct.Size = New System.Drawing.Size(452, 245)
        Me.GridViewDeduct.TabIndex = 382
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewImageColumn1.HeaderText = "Del"
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 42
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "#"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 25
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn4.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 96
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(608, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 381
        Me.Label8.Text = "POSITION:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(608, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 23)
        Me.Label7.TabIndex = 380
        Me.Label7.Text = "DEPARTMENT:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(609, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 23)
        Me.Label6.TabIndex = 379
        Me.Label6.Text = "INCENTIVE:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(129, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 23)
        Me.Label5.TabIndex = 378
        Me.Label5.Text = "DEDUCTION:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(608, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 25)
        Me.Label4.TabIndex = 377
        Me.Label4.Text = "GROSS SALARY:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(128, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 23)
        Me.Label2.TabIndex = 376
        Me.Label2.Text = "OVERTIME HRS:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(128, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 23)
        Me.Label1.TabIndex = 375
        Me.Label1.Text = "WORKING HRS REGULAR:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(128, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 23)
        Me.Label3.TabIndex = 374
        Me.Label3.Text = "EMPLOYEE NAME:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(939, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(215, 37)
        Me.Button1.TabIndex = 410
        Me.Button1.Text = "Select employee"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmGenerate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1294, 599)
        Me.Controls.Add(Me.pnlCenter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGenerate"
        Me.Text = "frmGenerate"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCenter.ResumeLayout(False)
        Me.pnlCenter.PerformLayout()
        CType(Me.GridViewIncent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDeduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents pnlCenter As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridViewIncent As System.Windows.Forms.DataGridView
    Friend WithEvents GridViewDeduct As System.Windows.Forms.DataGridView
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents txtOT As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents txtworkHR As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents lblIncentTotal As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbldeductTotal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblNetPay As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtOTrate As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnCompute As System.Windows.Forms.Button
    Friend WithEvents btnSaveOnly As System.Windows.Forms.Button
    Friend WithEvents btnSavePrint As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtPayPeriod As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblSalary As System.Windows.Forms.Label
    Friend WithEvents DataGridViewImageColumn3 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRate As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
