Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Prodcut_type

    Private Property q1var As String

    Private Property q2var As String

    Sub disrecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim ds1 As New DataSet
        Dim adp As New SqlDataAdapter("select * from logintab1997", conn)
        adp.Fill(ds1)
        DataGridView3.DataSource = ds1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub


    Private Sub Prodcut_type_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disrecords()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackColor = Color.MintCream

        Dim q1var, q2var As String
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()


        q1var = "insert into logintab1997("
        q2var = "values("
        q1var = q1var & "PRODUCTTYPE" & ")"
        q2var = q2var & "'" & TextBox1.Text & "')"
        Dim cmd As New SqlCommand(q1var & q2var, conn)
        cmd.ExecuteNonQuery()
        MsgBox("STOCK SAVED SUCCESSFULLY")
        disrecords()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.BackColor = Color.MintCream
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.BackColor = Color.MintCream

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("delete from logintab1997 where PRODUCTTYPE ='" & tempvar & "'", conn)
        cmd.ExecuteNonQuery()
        MsgBox("STOCK DELETED SUCCESSFULLY")
        disrecords()
    End Sub
    Dim tempvar As String
    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        tempvar = DataGridView3.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("select * from logintab1997 where PRODUCTTYPE='" & tempvar & "'", conn)
        Dim d1 As SqlDataReader = cmd.ExecuteReader
        If d1.HasRows Then
            d1.Read()
            TextBox1.Text = d1(0).ToString
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.MintCream

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("delete from logintab1997 where PRODUCTTYPE ='" & TextBox1.Text & "'", conn)
        cmd.ExecuteNonQuery()
        MsgBox("STOCK DELETED SUCCESSFULLY")
        disrecords()


        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()


        q1var = "insert into logintab1997("
        q2var = "values("
        q1var = q1var & "PRODUCTTYPE" & ")"
        q2var = q2var & "'" & TextBox1.Text & "')"
        Dim cmd1 As New SqlCommand(q1var & q2var, conn)
        cmd1.ExecuteNonQuery()
        MsgBox("STOCK ADDED")
        disrecords()

    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        If Not Regex.Match(TextBox1.Text, "^[a-z.  ]*$", RegexOptions.IgnoreCase).Success Then
            MsgBox("ENTER ALPHABET VALUES ONLY")
            TextBox1.Clear()
            TextBox1.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.BackColor = Color.MintCream

        TextBox1.Clear()

    End Sub
End Class