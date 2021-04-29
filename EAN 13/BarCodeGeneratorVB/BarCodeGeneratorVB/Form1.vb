
Imports System.Drawing.Text

Public Class Form1
    Public trueSideTotal As Integer
    Public falseSideTotal As Integer
    Public total As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBarcode.Font = New System.Drawing.Font("Code EAN13", 72)
        
    End Sub
    Private Sub txtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtQty.Focus()
        End If
        
    End Sub

    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                generateBarcode()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            generateBarcode()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub generateBarcode()
        If txtItemCode.Text.Length = 12 Then
            'increment
            txtItemCode.Text = Val(txtItemCode.Text) + 1
            'true side
            trueSideTotal = Val(txtItemCode.Text(0)) + Val(txtItemCode.Text(2)) + Val(txtItemCode.Text(4)) + Val(txtItemCode.Text(6)) + Val(txtItemCode.Text(8)) + Val(txtItemCode.Text(10))
            'false side
            falseSideTotal = (Val(txtItemCode.Text(1)) + Val(txtItemCode.Text(3)) + Val(txtItemCode.Text(5)) + Val(txtItemCode.Text(7)) + Val(txtItemCode.Text(9)) + Val(txtItemCode.Text(11))) * 3
            'total checksum
            total = 10 - ((trueSideTotal + falseSideTotal) Mod 10)
            If total = 10 Then
                total = 0
            End If
            'output result
            txtEAN.Text = txtItemCode.Text(0) & txtItemCode.Text(1) & txtItemCode.Text(2) & txtItemCode.Text(3) & txtItemCode.Text(4) & txtItemCode.Text(5) & txtItemCode.Text(6) & txtItemCode.Text(7) & txtItemCode.Text(8) & txtItemCode.Text(9) & txtItemCode.Text(10) & txtItemCode.Text(11) & total.ToString

            dgv.Rows.Add(txtEAN.Text, "@example Item", "@unit", "1")

            txtEncoded.Text = encodedBarcode(txtEAN.Text)
            txtBarcode.Text = encodedBarcode(txtEAN.Text)
        Else
            MsgBox("Invalid format must required 12 digits !", vbCritical, "INVALID FORMAT")
        End If

    End Sub

    


End Class
