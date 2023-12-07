Imports System.Data.SqlClient
Imports System.Text.RegularExpressions


Class SIGNUP

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button3.BackColor = Color.MintCream


        Me.Close()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub SIGNUP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button2.BackColor = Color.MintCream
       
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Button1.BackColor = Color.MintCream


        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd3 As New SqlCommand("select * from logintab3 where EMPLOYEEID='" & TextBox1.Text & "'", conn)
        Dim d2 As SqlDataReader = cmd3.ExecuteReader()
        If d2.HasRows Then
            MsgBox("EMPLOYEE-ID ALREADY EXIST")
            Exit Sub
        End If


        Dim q1var, q2var As String
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()

        q1var = "insert into logintab3("
        q2var = "values("
        q1var = q1var & "EMPLOYEEID" & ","
        q2var = q2var & "'" & TextBox1.Text & "',"
        q1var = q1var & "EMPLOYEENAME" & ","
        q2var = q2var & "'" & TextBox2.Text & "',"
        q1var = q1var & "EMPLOYEEADDRESS" & ","
        q2var = q2var & "'" & TextBox3.Text & "',"
        q1var = q1var & "GENDER" & ","
        q2var = q2var & "'" & TextBox4.Text & "',"
        q1var = q1var & "PHONENO" & ","
        q2var = q2var & "'" & TextBox5.Text & "',"
        q1var = q1var & "EMAIL" & ","
        q2var = q2var & "'" & TextBox6.Text & "',"
        q1var = q1var & "SALARY" & ","
        q2var = q2var & "'" & TextBox7.Text & "',"
        q1var = q1var & "DESIGNATION" & ","
        q2var = q2var & "'" & TextBox8.Text & "',"
        q1var = q1var & "QUALIFICATION" & ")"
        q2var = q2var & "'" & TextBox9.Text & "')"
        Dim cmd As New SqlCommand(q1var & q2var, conn)
        cmd.ExecuteNonQuery()
        MsgBox("SIGNED IN SUCCESSFULLY")
    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.Leave
        If Regex.Match(TextBox5.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER NUMBERICAL VALUES ONLY")
            TextBox5.Clear()
            TextBox5.Focus()
            Exit Sub
        End If


        TextBox5.MaxLength = 10
        Dim a As Integer
        a = Len(TextBox5.Text)
        If (a < 10) Then
            MsgBox("ENTER 10-DIGIT PHONE NUMBER")
            TextBox5.Clear()
            TextBox5.Focus()
            Exit Sub
        End If


        Dim fd As String
        fd = TextBox5.Text(0)
        If Not ((fd = "6") Or (fd = "7") Or (fd = "8") Or (fd = "9")) Then
            MsgBox("ENTER VALID PHONE NUMBER")
            TextBox5.Clear()
            TextBox5.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox2_Leave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        If Not Regex.Match(TextBox2.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER ALPHABET VALUES ONLY")
            TextBox2.Clear()
            TextBox2.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TextBox2_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.Leave
        Dim regex As Regex = New Regex("^[a-zA-Z0-9+_.-]+@[a-zA-z0-9.-]+$")
        Dim isvalid As Boolean = regex.IsMatch(TextBox6.Text.Trim)
        If Not isvalid Then
            MsgBox("INVALID E-MAIL")
            Exit Sub
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.Leave
        If Regex.Match(TextBox7.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER NUMBERICAL VALUES ONLY")
            TextBox7.Clear()
            TextBox7.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub TextBox4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.Leave
        If Not Regex.Match(TextBox4.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER ALPHABET VALUES ONLY")
            TextBox4.Clear()
            TextBox4.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.Leave
        If Not Regex.Match(TextBox8.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER ALPHABET VALUES ONLY")
            TextBox8.Clear()
            TextBox8.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox9_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.Leave
        If Not Regex.Match(TextBox9.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER ALPHABET VALUES ONLY")
            TextBox9.Clear()
            TextBox9.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub
End Class