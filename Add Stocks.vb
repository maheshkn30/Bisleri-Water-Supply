Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Add_Stocks

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackColor = Color.MintCream
      
        Dim q1var, q2var As String
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()


        q1var = "insert into logintab2001("
        q2var = "values("
        q1var = q1var & "PRODUCTNAME" & ","
        q2var = q2var & "'" & ComboBox1.Text & "',"
        q1var = q1var & "PRODUCTTYPE" & ","
        q2var = q2var & "'" & ComboBox2.Text & "',"
        q1var = q1var & "QUANTITY" & ","
        q2var = q2var & "'" & TextBox1.Text & "',"
        q1var = q1var & "PRICE" & ","
        q2var = q2var & "'" & TextBox2.Text & "',"
        q1var = q1var & "TAXAMOUNT" & ","
        q2var = q2var & "'" & TextBox3.Text & "',"
        q1var = q1var & "TOTAL" & ")"
        q2var = q2var & "'" & TextBox4.Text & "')"
        Dim cmd As New SqlCommand(q1var & q2var, conn)
        cmd.ExecuteNonQuery()
        MsgBox("STOCK ADDED")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.BackColor = Color.MintCream

        Me.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.MintCream


        ComboBox1.Sorted = True
        ComboBox2.Sorted = True
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()


    End Sub

    Private Sub Add_Stocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("select PRODUCTTYPE from logintab1997", conn)
        Dim d1 As SqlDataReader = cmd.ExecuteReader()
        While d1.Read

            ComboBox2.Items.Add(d1(0).ToString)
        End While
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("select PRODUCTNAME from logintab1999", conn)
        Dim d2 As SqlDataReader = cmd1.ExecuteReader()
        While d2.Read

            ComboBox1.Items.Add(d2(0).ToString)
        End While

    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        If Regex.Match(TextBox1.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER NUMBERICAL VALUES ONLY")
            TextBox1.Clear()
            TextBox1.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        If Regex.Match(TextBox2.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER NUMBERICAL VALUES ONLY")
            TextBox2.Clear()
            TextBox2.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
     
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
    
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged


    End Sub

    Private Sub TextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.Leave
        Dim total As String
        total = (Val(TextBox1.Text) * Val(TextBox2.Text) * (TextBox3.Text) / 100)
        TextBox4.Text = ((Val(TextBox1.Text) * (Val(TextBox2.Text)) + total))


    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
      
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class