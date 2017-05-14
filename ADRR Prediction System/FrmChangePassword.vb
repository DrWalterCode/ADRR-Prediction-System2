Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class FrmChangePassword
    Dim ReadOnly _con As MySqlConnection = New MySqlConnection(ConfigurationManager.ConnectionStrings("myConnection").ConnectionString)
    Dim _cmd As MySqlCommand

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If txtNewPwd.Text <> txtConNewPwd.Text Then
            MsgBox(" New password did match.", MsgBoxStyle.Critical, "New Password")
            txtNewPwd.SelectAll()
            Exit Sub
        End If

         Dim passwordold As String
            passwordold = txtOldPwd.Text

        Try
            _con.Open()
            _cmd =
                New MySqlCommand(
                    "UPDATE Users SET password = '" & txtNewPwd.Text &
                    "' WHERE Username ='" & txtUsername.Text.ToString.Replace("'", "''") & "' and password ='" + passwordold + "'", _con)
            _cmd.ExecuteNonQuery
            MsgBox("Password successfully changed..", MsgBoxStyle.Information, "New Password")
            _cmd.Dispose()
            _con.Close()
            txtOldPwd.Text = ""
            txtConNewPwd.Text = ""
            txtNewPwd.Text = ""
            Dispose()
        Catch ex As Exception
            _cmd.Dispose()
            _con.Close()
            MsgBox("Failed to update password. Retry")
            txtOldPwd.Text = ""
            txtConNewPwd.Text = ""
            txtNewPwd.Text = ""
        End Try
    End Sub
    Private Sub FrmChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub exitescp_Click(sender As Object, e As EventArgs) 
        _con.Close()
        Dispose()
    End Sub

    Private Sub FrmChangePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dispose()
        End If
    End Sub
End Class