﻿Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class FrmReports1
      Dim _con As New MySqlConnection(ConfigurationManager.ConnectionStrings("myConnection").ConnectionString)
    Dim _cmd As MySqlCommand

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dispose()
    End Sub

    Private Sub TileItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) 
        MsgBox("Under Development")
    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) 
        MsgBox("Under Development")
    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) 
        MsgBox("Under Development")
    End Sub

    Private Sub TileItem3_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) 
        MsgBox("Under Development")
    End Sub

    Private Sub TileItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) 
        MsgBox("Under Development")
    End Sub
    'comments
    Private Sub FrmReports1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
