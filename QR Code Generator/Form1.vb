Imports QR_Code_Generator
Imports QRCoder
Imports QRCoder.PayloadGenerator

Public Class Form1
    Dim c1 As Color
    Dim c2 As Color
    Dim isurl As Boolean
    Dim isphonenum As Boolean
    Dim istext As Boolean
    Dim iswifi As Boolean
    Dim WithEvents printDoc As New Printing.PrintDocument()
    Private Sub Qrtext()
        Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(TextBox1.Text, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As QRCode = New QRCode(qrCodeData)
        Dim qrCodeImage As Bitmap = qrCode.GetGraphic(20)
        If c1 <> Nothing Or c2 <> Nothing Then
            qrCodeImage = qrCode.GetGraphic(20, c1, c2, True)
        Else
            qrCodeImage = qrCode.GetGraphic(20, Color.White, Color.Black, True)
        End If
        PictureBox1.Image = qrCodeImage

    End Sub
    Private Sub urlQr()
        Dim generator As Url = New Url(TextBox1.Text)
        Dim payload As String = generator.ToString()
        Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As QRCode = New QRCode(qrCodeData)
        Dim qrCodeAsBitmap = qrCode.GetGraphic(20)
        If c1 <> Nothing Or c2 <> Nothing Then
            qrCodeAsBitmap = qrCode.GetGraphic(20, c1, c2, True)
        Else
            qrCodeAsBitmap = qrCode.GetGraphic(20, Color.White, Color.Black, True)
        End If
        PictureBox1.Image = qrCodeAsBitmap
    End Sub


    Private Sub wifi()
        Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
        Dim wifiPayload As PayloadGenerator.WiFi = New PayloadGenerator.WiFi(TextBox1.Text, TextBox2.Text, PayloadGenerator.WiFi.Authentication.WPA)
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(wifiPayload.ToString(), QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As QRCode = New QRCode(qrCodeData)
        Dim qrCodeImage As Bitmap
        If c1 <> Nothing Or c2 <> Nothing Then
            qrCodeImage = qrCode.GetGraphic(20, c1, c2, True)
        Else
            qrCodeImage = qrCode.GetGraphic(20, Color.White, Color.Black, True)
        End If

        PictureBox1.Image = qrCodeImage
        'icons8-text-64.png
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If SplitContainer1.SplitterDistance > 75 Then
            SplitContainer1.SplitterDistance -= 10
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button7.Enabled = False
            Button10.Enabled = False
        Else
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button7.Enabled = True
            Button10.Enabled = True
            Timer1.Enabled = False

        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If SplitContainer1.SplitterDistance < 260 Then
            SplitContainer1.SplitterDistance += 10
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button10.Enabled = False
            Button7.Enabled = False
        Else
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button7.Enabled = True
            Button10.Enabled = True
            Timer2.Enabled = False
        End If
    End Sub
    Sub openclose()
        If SplitContainer1.SplitterDistance > 75 Then
            Timer1.Enabled = True
        Else
            Timer2.Enabled = True
        End If
    End Sub
    Sub qrphonenum()
        Dim generator As PhoneNumber = New PhoneNumber(TextBox1.Text)
        Dim payload As String = generator.ToString()
        Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As QRCode = New QRCode(qrCodeData)
        Dim qrCodeAsBitmap = qrCode.GetGraphic(20)
        If c1 <> Nothing Or c2 <> Nothing Then
            qrCodeAsBitmap = qrCode.GetGraphic(20, c1, c2, True)
        Else
            qrCodeAsBitmap = qrCode.GetGraphic(20, Color.White, Color.Black, True)
        End If
        PictureBox1.Image = qrCodeAsBitmap
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        openclose()
    End Sub
    'Dim qrCodeImage As Bitmap = qrCode.GetGraphic(20, Color.Black, Color.White, CType(Bitmap.FromFile("C:\myimage.png"), Bitmap))
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If TextBox1.Text Is String.Empty Then
            MsgBox("الرجاء ادخال المعلومات المطلوبة في الحقل", Title:="تحذير هناك حقل فارغ")
            Exit Sub
        ElseIf TextBox2.Text Is String.Empty AndAlso iswifi = True Then
            MsgBox("الرجاء ادخال المعلومات المطلوبة في الحقل", Title:="تحذير هناك حقل فارغ")
            Exit Sub
        End If
        Try
            If isphonenum Then
                qrphonenum()
            ElseIf istext Then
                Qrtext()
            ElseIf iswifi Then
                wifi()
            ElseIf isurl Then
                urlQr()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TextBox2.Clear()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim colr As DialogResult
        colr = ColorDialog1.ShowDialog
        If colr = Windows.Forms.DialogResult.OK Then
            c1 = ColorDialog1.Color
            Button6.ForeColor = c1
        End If

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        Dim colr As DialogResult
        colr = ColorDialog1.ShowDialog
        If colr = Windows.Forms.DialogResult.OK Then
            c2 = ColorDialog1.Color
            Button11.ForeColor = c2
        End If
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        iswifi = False
        istext = False
        isphonenum = False
        isurl = True
        Label1.Text = "Url:"
        Label2.Visible = False
        TextBox2.Visible = False
        TextBox1.Clear()

        If SplitContainer1.SplitterDistance < 75 Then
            Exit Sub
        End If
        openclose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label1.Text = "SSID(NetWorkname):"
        isurl = False
        istext = False
        isphonenum = False
        iswifi = True
        Label2.Visible = True
        TextBox2.Visible = True
        TextBox1.Clear()

        If SplitContainer1.SplitterDistance < 75 Then
            Exit Sub
        End If
        openclose()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label1.Text = "PhoneNumber:"
        isurl = False
        istext = False
        iswifi = False
        isphonenum = True
        TextBox1.Clear()
        Label2.Visible = False
        TextBox2.Visible = False
        If SplitContainer1.SplitterDistance < 75 Then
            Exit Sub
        End If
        openclose()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Label1.Text = "Text:"
        isurl = False
        iswifi = False
        isphonenum = False
        TextBox1.Clear()
        istext = True
        Label2.Visible = False
        TextBox2.Visible = False
        If SplitContainer1.SplitterDistance < 75 Then
            Exit Sub
        End If
        openclose()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MsgBox("Instagram:1g_di ,Facebook:Hassan Abdulbaqi", Title:="My Socials")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isurl = True
    End Sub
    Private Sub PrintImage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage
        e.Graphics.DrawImage(PictureBox1.Image, e.MarginBounds.Left, e.MarginBounds.Top)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            printDoc.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
