Imports System.Data.SqlClient
Public Class Manage_stocks

    Private Property q1var As String

    Private Property q2var As String

    Sub disrecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim ds1 As New DataSet
        Dim adp As New SqlDataAdapter("select * from logintab2001", conn)
        adp.Fill(ds1)
        DataGridView2.DataSource = ds1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Manage_stocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disrecords()
    End Sub
    Dim tempvar As String
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        tempvar = DataGridView2.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("select * from logintab2001 where PRODUCTNAME ='" & tempvar & "'", conn)
        Dim d1 As SqlDataReader = cmd.ExecuteReader
        If d1.HasRows Then
            d1.Read()
            TextBox1.Text = d1(0).ToString
            TextBox2.Text = d1(1).ToString
            TextBox3.Text = d1(2).ToString
            TextBox4.Text = d1(3).ToString
            TextBox5.Text = d1(4).ToString
            TextBox6.Text = d1(5).ToString
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.BackColor = Color.MintCream

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("delete from logintab2001 where PRODUCTNAME ='" & tempvar & "'", conn)
        cmd.ExecuteNonQuery()
        MsgBox("STOCK DELETED SUCCESSFULLY")
        disrecords()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.MintCream
        Me.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.BackColor = Color.MintCream

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button4.BackColor = Color.MintCream
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("delete from logintab2001 where PRODUCTNAME ='" & TextBox1.Text & "'", conn)
        cmd.ExecuteNonQuery()
        MsgBox("STOCK DELETED SUCCESSFULLY")
        disrecords()


        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        q1var = "insert into logintab2001("
        q2var = "values("
        q1var = q1var & "PRODUCTNAME" & ","
        q2var = q2var & "'" & TextBox1.Text & "',"
        q1var = q1var & "PRODUCTTYPE" & ","
        q2var = q2var & "'" & TextBox2.Text & "',"
        q1var = q1var & "QUANTITY" & ","
        q2var = q2var & "'" & TextBox3.Text & "',"
        q1var = q1var & "PRICE" & ","
        q2var = q2var & "'" & TextBox4.Text & "',"
        q1var = q1var & "TAXAMOUNT" & ","
        q2var = q2var & "'" & TextBox5.Text & "',"
        q1var = q1var & "TOTAL" & ")"
        q2var = q2var & "'" & TextBox6.Text & "')"
        Dim cmd1 As New SqlCommand(q1var & q2var, conn)
        cmd1.ExecuteNonQuery()
        MsgBox("STOCK UPDATED SUCCESSFULLY")
        disrecords()


    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub
End Class