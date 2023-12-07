Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Sale
    Sub disrecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim ds1 As New DataSet
        Dim adp As New SqlDataAdapter("select * from sale where PRODUCTNAME='" & ComboBox1.Text & "'", conn)
        adp.Fill(ds1)
        DataGridView5.DataSource = ds1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Sale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("select PRODUCTNAME from logintab2001", conn)
        Dim d1 As SqlDataReader = cmd.ExecuteReader()
        While d1.Read

            ComboBox1.Items.Add(d1(0).ToString)
        End While
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.BackColor = Color.MintCream
        disrecords()


    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView5.CellContentClick
        tempvar = DataGridView5.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("select * from sale where PRODUCTNAME='" & tempvar & "'", conn)
        Dim d1 As SqlDataReader = cmd.ExecuteReader
        If d1.HasRows Then
            d1.Read()
            ComboBox1.Items.Add(d1(0).ToString)
            TextBox1.Text = d1(1).ToString
            TextBox2.Text = d1(2).ToString
            TextBox3.Text = d1(3).ToString
            TextBox4.Text = d1(4).ToString
            TextBox5.Text = d1(5).ToString
            TextBox6.Text = d1(6).ToString
            TextBox7.Text = d1(7).ToString
        End If

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackColor = Color.MintCream

        Dim q1var, q2var As String
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()


        q1var = "insert into sale("
        q2var = "values("
        q1var = q1var & "PRODUCTNAME" & ","
        q2var = q2var & "'" & ComboBox1.Text & "',"
        q1var = q1var & "PRODUCTTYPE" & ","
        q2var = q2var & "'" & TextBox1.Text & "',"
        q1var = q1var & "QUANTITY" & ","
        q2var = q2var & "'" & TextBox2.Text & "',"
        q1var = q1var & "PRICE" & ","
        q2var = q2var & "'" & TextBox3.Text & "',"
        q1var = q1var & "TAXAMOUNT" & ","
        q2var = q2var & "'" & TextBox4.Text & "',"
        q1var = q1var & "TOTAL" & ","
        q2var = q2var & "'" & TextBox5.Text & "',"
        q1var = q1var & "BILLNO" & ","
        q2var = q2var & "'" & TextBox6.Text & "',"
        q1var = q1var & "DATE" & ","
        q2var = q2var & "'" & DateTimePicker1.Text & "',"
        q1var = q1var & "CUSTOMERNAME" & ")"
        q2var = q2var & "'" & TextBox7.Text & "')"
        Dim cmd As New SqlCommand(q1var & q2var, conn)
        cmd.ExecuteNonQuery()
        MsgBox("STOCK ADDED")


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.BackColor = Color.MintCream

        Me.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.MintCream

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        ComboBox1.Sorted = True

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("select * from logintab2001 where PRODUCTNAME='" & ComboBox1.Text & "'", conn)
        Dim ex As SqlDataReader = cmd.ExecuteReader()
        If ex.HasRows Then
            ex.Read()
            TextBox1.Text = ex(1).ToString
            TextBox3.Text = ex(3).ToString
            TextBox4.Text = ex(4).ToString


        End If
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
        Dim taxamount, total As Integer
        taxamount = (Val(TextBox2.Text) * Val(TextBox3.Text)) * (Val(TextBox4.Text) / 100)
        total = (Val(TextBox2.Text) * Val(TextBox3.Text)) + taxamount
        TextBox5.Text = total
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
    Dim tempvar As String
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Button5.BackColor = Color.MintCream


        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("delete from SALE where PRODUCTNAME ='" & tempvar & "'", conn)
        cmd.ExecuteNonQuery()
        MsgBox("STOCK DELETED SUCCESSFULLY")
        disrecords()
    End Sub

    Private Sub TextBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.Leave
        If Not Regex.Match(TextBox7.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER ALPHABET VALUES ONLY")
            TextBox7.Clear()
            TextBox7.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub
End Class