Module Module1
    Public Function encodedBarcode(genBarcode As String)
        Dim EAN13 As String = genBarcode.Substring(0, 1) & Convert.ToChar(65 + Val(genBarcode(1)))
        Dim first As String = genBarcode.Substring(0, 1)
        Dim mid_ As String = ""
        Dim last As String = ""
        Dim flag As Boolean = False

        'for first 2 to 6 digit
        For i = 2 To 6
            flag = False
            Select Case i
                Case 2
                    If Val(first) >= 0 And Val(first) <= 3 Then flag = True

                Case 3
                    If Val(first) = 0 Or Val(first) = 4 Or Val(first) = 7 Or Val(first) = 8 Then flag = True

                Case 4
                    If Val(first) = 0 Or Val(first) = 1 Or Val(first) = 4 Or Val(first) = 5 Or Val(first) = 9 Then flag = True
                    'bug in case 5
                Case 5
                    If Val(first) = 0 Or Val(first) = 2 Or Val(first) = 5 Or Val(first) = 6 Or Val(first) = 7 Then flag = True

                Case 6
                    If Val(first) = 0 Or Val(first) = 3 Or Val(first) = 6 Or Val(first) = 8 Or Val(first) = 9 Then flag = True

            End Select

            If flag Then
                mid_ = mid_ & Convert.ToChar(65 + Val(genBarcode(i)))
            Else
                mid_ = mid_ & Convert.ToChar(75 + Val(genBarcode(i)))

            End If

        Next

        'for last 6 digit
        For i = 7 To 12
            last = last & Convert.ToChar(97 + Val(genBarcode(i)))
        Next

        'final EAN13 encoded
        EAN13 = EAN13 & mid_ & Convert.ToChar("*") & last & Convert.ToChar("+")
        Return EAN13

    End Function

End Module
