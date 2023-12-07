Imports System.Data.SqlClient
Imports System.Text.RegularExpressions


Public Class Product_details
    Sub disrecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim ds1 As New DataSet
        Dim adp As New SqlDataAdapter("select * from logintab1999", conn)
        adp.Fill(ds1)
        DataGridView4.DataSource = ds1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackColor = Color.MintCream

        Dim q1var, q2var As String
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        q1var = "insert into logintab1999("
        q2var = "values("
        q1var = q1var & "PRODUCTNAME" & ","
        q2var = q2var & "'" & TextBox1.Text & "',"
        q1var = q1var & "PRODUCTTYPE" & ")"
        q2var = q2var & "'" & ComboBox1.Text & "')"
        Dim cmd As New SqlCommand(q1var & q2var, conn)
        cmd.ExecuteNonQuery()
        MsgBox("STOCK SAVED SUCCESSFULLY")
        disrecords()

    End Sub

    Private Sub Product_details_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disrecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("select PRODUCTTYPE from logintab1997", conn)
        Dim d1 As SqlDataReader = cmd.ExecuteReader()
        While d1.Read

            ComboBox1.Items.Add(d1(0).ToString)
        End While

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.BackColor = Color.MintCream

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.BackColor = Color.MintCream

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("delete from logintab1999 where PRODUCTNAME ='" & tempvar & "'", conn)
        cmd.ExecuteNonQuery()
        MsgBox("data deleted successfully")
        disrecords()
    End Sub
    Dim tempvar As String
    Private Sub DataGridView4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick
        tempvar = DataGridView4.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("select * from logintab2001 where PRODUCTNAME='" & tempvar & "'", conn)
        Dim d1 As SqlDataReader = cmd.ExecuteReader
        If d1.HasRows Then
            d1.Read()
            TextBox1.Text = d1(0).ToString
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
      

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Clear()
        ComboBox1.Sorted = True
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button4.BackColor = Color.MintCream

        TextBox1.Clear()
        ComboBox1.Sorted = True
    End Sub
End Class