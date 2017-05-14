Imports System.Configuration
Imports System.IO.Ports
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices
Imports MySql.Data.MySqlClient

Public Class FrmKnowledge
      Dim _con As New MySqlConnection(ConfigurationManager.ConnectionStrings("myConnection").ConnectionString)
    Dim _cmd As MySqlCommand

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Try
            Dim sql As String = "Update cd4settings set Optimum=@Optimum,Severe=@Severe,low=@low"
            Dim parameters As String() = New String() {"Optimum", "Severe", "low" }
            Dim values As String() = New String() { Me.o1.Text, Me.s1.Text, Me.l1.Text}
            Dim saveupdate As New InsertUpdateData
            saveupdate.SaveUpdateDelete(sql, parameters, values)
            Interaction.MsgBox("CD4 Settings Saved Successfully", MsgBoxStyle.ApplicationModal, Nothing)
            Fillcd4
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
         Try
           Dim sql As String = "Update viralloadsettings set Optimum=@Optimum,Severe=@Severe,low=@low"
            Dim parameters As String() = New String() {"Optimum", "Severe", "low" }
            Dim values As String() = New String() { Me.o2.Text, Me.s2.Text, Me.l2.Text}
            Dim saveupdate As New InsertUpdateData
            saveupdate.SaveUpdateDelete(sql, parameters, values)
            Interaction.MsgBox("Viral Load Settings Saved Successfully", MsgBoxStyle.ApplicationModal, Nothing)
            Fillviralload
        Catch ex As Exception

        End Try
    End Sub
    private sub Fillcd4
        try
          _con.close()
            _con.Open()
            _cmd =
                New mySqlCommand(
                    "select Optimum,Severe,low from cd4settings ", _con)
            dim dr as MySqlDataReader=_cmd.ExecuteReader()
            if dr.Read() = True
                o1.Text = dr(0).ToString()
                s1.Text = dr(1).ToString()
                l1.Text = dr(2).ToString()
            End If
          Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            _con.Close()
        End Try
    End sub

     private sub Fillviralload
        try
          _con.close()
            _con.Open()
            _cmd =
                New mySqlCommand(
                    "select Optimum,Severe,low from viralloadsettings ", _con)
            dim dr as MySqlDataReader=_cmd.ExecuteReader()
            if dr.Read() = True
                o2.Text = dr(0).ToString()
                s2.Text = dr(1).ToString()
                l2.Text = dr(2).ToString()
            End If
          Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            _con.Close()
        End Try
    End sub
    Private Sub FrmKnowledge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Fillcd4
            Fillviralload
        Catch ex As Exception

        End Try
    End Sub
End Class
