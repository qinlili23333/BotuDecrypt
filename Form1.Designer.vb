<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.AxPDFView1 = New AxPDFVIEWLib.AxPDFView()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.AxPDFView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1250, 191)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(236, 99)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "解密保存"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(155, 191)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(1089, 99)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "https://botu-bks-books.bj.bcebos.com/a01pbooks/L/38/1133729.pdf"
        '
        'AxPDFView1
        '
        Me.AxPDFView1.Enabled = True
        Me.AxPDFView1.Location = New System.Drawing.Point(291, 1)
        Me.AxPDFView1.Name = "AxPDFView1"
        Me.AxPDFView1.OcxState = CType(resources.GetObject("AxPDFView1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxPDFView1.Size = New System.Drawing.Size(68, 56)
        Me.AxPDFView1.TabIndex = 3
        Me.AxPDFView1.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 305)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1483, 40)
        Me.ProgressBar1.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(155, 86)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(1009, 99)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "http://www.cnbooksearch.com/BookRead.aspx?bookid=374061"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 41)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "页面链接"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 41)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "PDF地址"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(1170, 86)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(313, 99)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "读取PDF地址"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.125!)
        Me.Button5.Location = New System.Drawing.Point(1305, 1)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(178, 79)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "博图"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.125!)
        Me.Button4.Location = New System.Drawing.Point(3, 1)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(282, 79)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "开源Repo"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 22.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(400, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(734, 78)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "UI丑是Feature不爽不要用"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1487, 347)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.AxPDFView1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "博图PDF解密工具by琴梨梨 v1.0.0"
        CType(Me.AxPDFView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents AxPDFView1 As AxPDFVIEWLib.AxPDFView
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label1 As Label
End Class
