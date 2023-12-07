Imports System.Data.SqlClient

Public Class EMPLOYEEREPORT
    Sub disrecords()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim ds1 As New DataSet
        Dim adp As New SqlDataAdapter("select * from logintab3 where EMPLOYEENAME='" & ComboBox1.Text & "'", conn)


        adp.Fill(ds1)
        DataGridView6.DataSource = ds1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()


    End Sub
    Dim q1var As String



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackColor = Color.MintCream

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim ds1 As New DataSet
        Dim adp As New SqlDataAdapter("select * from logintab3  order by EMPLOYEENAME", conn)
        adp.Fill(ds1)
        DataGridView6.DataSource = ds1.Tables(0)
        If conn.State = ConnectionState.Open Then conn.Close()

    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub EMPLOYEEREPOT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd1 As New SqlCommand("select EMPLOYEENAME from logintab3", conn)
        Dim d1 As SqlDataReader = cmd1.ExecuteReader()
        While d1.Read

            ComboBox1.Items.Add(d1(0).ToString)
        End While


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.BackColor = Color.MintCream
        disrecords()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim XPos, YPos As Long
        YPos = 50
        Dim MyFont As New Font("Arial", 18)
        XPos = 10
        e.Graphics.DrawString("BISLERI WATER DISTUBUTORS", MyFont, Brushes.Black, XPos, YPos)
        YPos += 50
        MyFont = New Font("Arial", 12)
        e.Graphics.DrawString("No. 101, 4th floor, UB City, Bangalore - 560001", MyFont, Brushes.Black, XPos, YPos)
        YPos += 100
        XPos = 10
        e.Graphics.DrawString("EMPLOYEE List Report", MyFont, Brushes.Black, XPos, YPos)
        YPos += 50
        XPos = 10
        MyFont = New Font("Arial", 12)
        e.Graphics.DrawString("EMPLOYEEID", MyFont, Brushes.Black, XPos, YPos)
        XPos = XPos + 150
        e.Graphics.DrawString("EMPLOYEENAME", MyFont, Brushes.Black, XPos, YPos)
        XPos = XPos + 150
        e.Graphics.DrawString("PHONENO", MyFont, Brushes.Black, XPos, YPos)
        XPos = XPos + 150
        e.Graphics.DrawString("EMAIL", MyFont, Brushes.Black, XPos, YPos)
        XPos = XPos + 200
        e.Graphics.DrawString("SALARY", MyFont, Brushes.Black, XPos, YPos)
        XPos = XPos + 150

        YPos += 25
        XPos = 10
        e.Graphics.DrawString("______________________________________________________________________________________________", MyFont, Brushes.Black, XPos, YPos)



        YPos += 25
        For Each r As DataGridViewRow In DataGridView6.Rows
            q1var = r.Cells(1).Value & " : " & r.Cells(2).Value
            XPos = 10
            e.Graphics.DrawString(r.Cells(0).Value, MyFont, Brushes.Black, XPos, YPos)
            XPos = XPos + 150
            e.Graphics.DrawString(r.Cells(1).Value, MyFont, Brushes.Black, XPos, YPos)
            XPos = XPos + 150
            e.Graphics.DrawString(r.Cells(4).Value, MyFont, Brushes.Black, XPos, YPos)
            XPos = XPos + 150
            e.Graphics.DrawString(r.Cells(5).Value, MyFont, Brushes.Black, XPos, YPos)
            XPos = XPos + 200
            e.Graphics.DrawString(r.Cells(6).Value, MyFont, Brushes.Black, XPos, YPos)
            XPos = XPos + 150

            YPos += 25
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.MintCream

        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.BackColor = Color.MintCream

        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Button5.BackColor = Color.MintCream

        ComboBox1.Sorted = True
    End Sub

    Private Sub DataGridView6_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView6.CellContentClick

    End Sub
End Class