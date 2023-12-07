Imports System.Data.SqlClient

Public Class Empdetails

    Private Property q1var As String

    Private Property q2var As String

    Sub disrecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim ds1 As New DataSet
        Dim adp As New SqlDataAdapter("select * from logintab3", conn)
        adp.Fill(ds1)
        DataGridView1.DataSource = ds1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackColor = Color.MintCream

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("delete from logintab3 where EMPLOYEEID='" & tempvar & "'", conn)
        cmd.ExecuteNonQuery()
        MsgBox("DATA DELTED SUCCESSFULLY")
        disrecords()

    End Sub

    Private Sub Empdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disrecords()
    End Sub
    Dim tempvar As String
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        tempvar = DataGridView1.CurrentRow.Cells(0).Value
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("select * from logintab3 where EMPLOYEEID='" & tempvar & "'", conn)
        Dim d1 As SqlDataReader = cmd.ExecuteReader
        If d1.HasRows Then
            d1.Read()
            TextBox1.Text = d1(0).ToString
            TextBox2.Text = d1(1).ToString
            TextBox3.Text = d1(2).ToString
            TextBox4.Text = d1(3).ToString
            TextBox5.Text = d1(4).ToString
            TextBox6.Text = d1(5).ToString
            TextBox7.Text = d1(6).ToString
            TextBox8.Text = d1(7).ToString
            TextBox9.Text = d1(8).ToString

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.MintCream
        Me.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.BackColor = Color.MintCream

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd As New SqlCommand("delete from logintab3 where EMPLOYEEID='" & tempvar & "'", conn)
        cmd.ExecuteNonQuery()
        MsgBox("DATA DELTED SUCCESSFULLY")
        disrecords()

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
        Dim cmd1 As New SqlCommand(q1var & q2var, conn)
        cmd1.ExecuteNonQuery()
        MsgBox("SIGNED IN SUCCESSFULLY")
        disrecords()
    End Sub
End Class