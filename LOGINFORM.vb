Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class LOGINFORM

   

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.BackColor = Color.MintCream
        TextBox1.Clear()
        TextBox2.Clear()

        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackColor = Color.MintCream


        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        Dim cmd0 As New SqlCommand("select * from ADMIN where ADMINNAME='" & UCase(TextBox1.Text) & "'and ADMINID='" & TextBox2.Text & "'", conn)
        Dim D1 As SqlDataReader = cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("LOGIN SUCCESS")
            MDIParent1.Show()
            TextBox1.Text = ""
            TextBox2.Text = ""
            Me.Hide()
            If conn.State = ConnectionState.Open Then conn.Close()
        Else
            MsgBox("USERNAME OR PASSWORD IS NOT CORRECT PLEASE CHECK")


        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        
    End Sub

    Private Sub LOGINFORM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        TextBox2.PasswordChar = ""
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        TextBox2.PasswordChar = "*"
    End Sub
End Class