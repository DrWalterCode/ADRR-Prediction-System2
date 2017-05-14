Imports System.Configuration
Imports System.IO.Ports
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices
Imports MySql.Data.MySqlClient

Public Class FrmNurses
      Dim _con As New MySqlConnection(ConfigurationManager.ConnectionStrings("myConnection").ConnectionString)
    Dim _cmd As MySqlCommand

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
         Dispose()
    End Sub

    Private Sub TileItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem5.ItemClick
       Try
             Me.TabControl1.SelectedIndex = 1
       Catch ex As Exception

       End Try
    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem2.ItemClick
        Try
             Me.TabControl1.SelectedIndex = 2
       Catch ex As Exception

       End Try
    End Sub

    Private Sub TileItem6_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem6.ItemClick
        Try
             Me.TabControl1.SelectedIndex = 3
       Catch ex As Exception

       End Try
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
            If (((((((Me.p1.Text = "") Or (Me.p2.Text = "")) Or (Me.p3.Text = "")) Or (Me.p4.Text = "")) Or (Me.p5.Text = "")) Or (Me.p6.Text = "")) Or (Me.p7.Text = "")) Then
        Interaction.MsgBox("Make sure all fields filled in", MsgBoxStyle.ApplicationModal, "Missing Parameters")
    Else
        Try 
            Dim sql As String = "INSERT into patients(fullname,idnumber,dateofbirth,sex,cell,region,station) values (@fullname,@idnumber,@dateofbirth,@sex,@cell,@region,@station)"
            Dim parameters As String() = New String() { "fullname", "idnumber", "dateofbirth", "sex", "cell", "region", "station" }
            Dim values As String() = New String() { Me.p1.Text, Me.p2.Text, Me.p3.Text, Me.p4.Text, Me.p5.Text, Me.p6.Text, Me.p7.Text }
             Dim saveupdate As New InsertUpdateData
            saveupdate.SaveUpdateDelete(sql, parameters, values)
            MsgBox("Patient Saved Successfully", MsgBoxStyle.ApplicationModal, Nothing)
            Try 
                Dim port As SerialPort = Me.SerialPort1
                port.WriteLine("AT" & ChrW(13) & ChrW(10))
                Thread.Sleep(&H3E8)
                port.WriteLine("AT+CMGF=1" & ChrW(13) & ChrW(10))
                Thread.Sleep(&H3E8)
                port.WriteLine(("AT+CMGS=""" & Me.p5.Text & """" & ChrW(13)))
                Thread.Sleep(&H3E8)
                port.WriteLine("Your blood sample is undergoing tests.You will be notified when results are out." & ChrW(13) & ChrW(10) & ChrW(26))
                port = Nothing
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError
            End Try
            Me.Cleartxtpatient
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me._cmd.Dispose
            Me._con.Close
            Interaction.MsgBox(exception2.Message, MsgBoxStyle.ApplicationModal, Nothing)
            ProjectData.ClearProjectError
        End Try
    End If

    End Sub
    Private Sub openport()
    If Me.SerialPort1.IsOpen Then
        Me.SerialPort1.Close
    Else
        Try 
            Dim port As SerialPort = Me.SerialPort1
            port.PortName = Strings.Trim(Strings.Mid("COM7", 1, 5))
            port.BaudRate = &H2580
            port.Parity = Parity.None
            port.DataBits = 8
            port.StopBits = StopBits.One
            port.Handshake = Handshake.None
            port.RtsEnable = True
            port.DtrEnable = True
            port.Open
            port.WriteLine("AT+CNMI=1,2,0,0,0" & ChrW(13) & ChrW(10))
            port = Nothing
            Me.t1.Visible = True
            Me.t2.Visible = True
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.t1.Visible = False
            Me.t2.Visible = False
            Interaction.MsgBox(exception.Message, MsgBoxStyle.ApplicationModal, Nothing)
            ProjectData.ClearProjectError
        End Try
    End If
End Sub

 

 Private Sub Cleartxtpatient()
    Me.p1.Text = ""
    Me.p2.Text = ""
    Me.p3.Text = ""
    Me.p4.SelectedIndex = -1
    Me.p5.Text = ""
    Me.p6.SelectedIndex = -1
    Me.p7.Text = ""
End Sub

 Private Sub FrmNurses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       Try
            openport()
       Catch ex As Exception
            MsgBox(ex.Message)
       End Try
    End Sub

    Private Sub p5_TextChanged(sender As Object, e As EventArgs) Handles p5.TextChanged

    End Sub

    Private Sub p2_TextChanged(sender As Object, e As EventArgs) Handles p2.TextChanged
        

    End Sub

    Private Sub FrmNurses_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
         If ((((Me.v1.Text = "") Or (Me.v2.Text = "")) Or (Me.v3.Text = "")) Or (Me.v4.Text = "")) Then
        Interaction.MsgBox("Make sure all fields filled in", MsgBoxStyle.ApplicationModal, "Missing Parameters")
    Else
        Try 
            Dim sql As String = "INSERT into viralload(IDnumber,cell,natureofsample,viralload) values (@IDnumber,@cell,@natureofsample,@viralload)"
            Dim parameters As String() = New String() { "IDnumber", "cell", "natureofsample", "viralload" }
            Dim values As String() = New String() { Me.v1.Text, Me.v2.Text, Me.v3.Text, Me.v4.Text }
            Dim saveupdate As New InsertUpdateData
            saveupdate.SaveUpdateDelete(sql, parameters, values)
            Interaction.MsgBox("Viral Load Saved Successfully", MsgBoxStyle.ApplicationModal, Nothing)
            Try 
                Dim port As SerialPort = Me.SerialPort1
                port.WriteLine("AT" & ChrW(13) & ChrW(10))
                Thread.Sleep(&H3E8)
                port.WriteLine("AT+CMGF=1" & ChrW(13) & ChrW(10))
                Thread.Sleep(&H3E8)
                port.WriteLine(("AT+CMGS=""" & Me.v2.Text & """" & ChrW(13)))
                Thread.Sleep(&H3E8)
                port.WriteLine(("Your viral load results are as follows : Viral Load -" & Me.v4.Text & " your next test should be Within 2-4 weeks" & ChrW(13) & ChrW(10) & ChrW(26)))
                port = Nothing
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError
            End Try
            Me.Cleartxtviralload
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me._cmd.Dispose
            Me._con.Close
            Interaction.MsgBox(exception2.Message, MsgBoxStyle.ApplicationModal, Nothing)
            ProjectData.ClearProjectError
        End Try
    End If

    End Sub

    Private Sub Cleartxtviralload()
    Me.v1.Text = ""
    Me.v2.Text = ""
    Me.v3.SelectedIndex = -1
    Me.v4.Text = ""
    End Sub

    Private Sub TileItem3_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem3.ItemClick
        Try
             Me.TabControl1.SelectedIndex = 0
       Catch ex As Exception

       End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
          If ((((Me.c1.Text = "") Or (Me.c2.Text = "")) Or (Me.c3.Text = "")) Or (Me.c4.Text = "")) Then
        Interaction.MsgBox("Make sure all fields filled in", MsgBoxStyle.ApplicationModal, "Missing Parameters")
    Else
        Try 
            Dim sql As String = "INSERT into cd4count(IDnumber,cell,natureofsample,cd4count) values (@IDnumber,@cell,@natureofsample,@cd4count)"
            Dim parameters As String() = New String() { "IDnumber", "cell", "natureofsample", "cd4count" }
            Dim values As String() = New String() { Me.c1.Text, Me.c2.Text, Me.c3.Text, Me.c4.Text }
            Dim saveupdate As New InsertUpdateData
            saveupdate.SaveUpdateDelete(sql, parameters, values)
            Interaction.MsgBox("CD4 Count Saved Successfully", MsgBoxStyle.ApplicationModal, Nothing)
            Try 
                Dim port As SerialPort = Me.SerialPort1
                port.WriteLine("AT" & ChrW(13) & ChrW(10))
                Thread.Sleep(&H3E8)
                port.WriteLine("AT+CMGF=1" & ChrW(13) & ChrW(10))
                Thread.Sleep(&H3E8)
                port.WriteLine(("AT+CMGS=""" & Me.c2.Text & """" & ChrW(13)))
                Thread.Sleep(&H3E8)
                port.WriteLine(("Your CD4 Count results are as follows : CD4 -" & Me.v4.Text & " cells/mm3 your next test should be Within 2-4 weeks" & ChrW(13) & ChrW(10) & ChrW(26)))
                port = Nothing
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError
            End Try
            Me.Cleartxtcd4count
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me._cmd.Dispose
            Me._con.Close
            Interaction.MsgBox(exception2.Message, MsgBoxStyle.ApplicationModal, Nothing)
            ProjectData.ClearProjectError
        End Try
    End If
        End Sub
 Private Sub Cleartxtcd4count()
    Me.c1.Text = ""
    Me.c2.Text = ""
    Me.c3.SelectedIndex = -1
    Me.c4.Text = ""
End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
         If (((((Me.d1.Text = "") Or (Me.d2.Text = "")) Or (Me.d3.Text = "")) Or (Me.d4.Text = "")) Or (Me.d5.Text = "")) Then
        Interaction.MsgBox("Make sure all fields filled in", MsgBoxStyle.ApplicationModal, "Missing Parameters")
    Else
        Try 
            Dim sql As String = "INSERT into drugs(IDnumber,cell,drug,dosage,dosagePeriod) values (@IDnumber,@cell,@drug,@dosage,@dosagePeriod)"
            Dim parameters As String() = New String() { "IDnumber", "cell", "drug", "dosage", "dosagePeriod" }
            Dim values As String() = New String() { Me.d1.Text, Me.d2.Text, Me.d3.Text, Me.d4.Text, Me.d5.Text }
             Dim saveupdate As New InsertUpdateData
            saveupdate.SaveUpdateDelete(sql, parameters, values)
            Interaction.MsgBox("Drug Prescription Saved Successfully", MsgBoxStyle.ApplicationModal, Nothing)
            Try 
                Dim port As SerialPort = Me.SerialPort1
                port.WriteLine("AT" & ChrW(13) & ChrW(10))
                Thread.Sleep(&H3E8)
                port.WriteLine("AT+CMGF=1" & ChrW(13) & ChrW(10))
                Thread.Sleep(&H3E8)
                port.WriteLine(("AT+CMGS=""" & Me.c2.Text & """" & ChrW(13)))
                Thread.Sleep(&H3E8)
                port.WriteLine(String.Concat(New String() { "Given your results you have been prescribed- :", Me.d4.Text, " mg to be taken ", Me.d5.Text, ChrW(13) & ChrW(10) & ChrW(26) }))
                port = Nothing
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError
            End Try
            Me.Cleartxtdrugs
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me._cmd.Dispose
            Me._con.Close
            Interaction.MsgBox(exception2.Message, MsgBoxStyle.ApplicationModal, Nothing)
            ProjectData.ClearProjectError
        End Try
    End If

    End Sub

    Private Sub Cleartxtdrugs()
    Me.d1.Text = ""
    Me.d2.Text = ""
    Me.d3.SelectedIndex = -1
    Me.d4.Text = ""
    Me.d5.SelectedIndex = -1
End Sub

    Private Sub v1_TextChanged(sender As Object, e As EventArgs) Handles v1.TextChanged
         Try 
        Me._con.Close
        Me._con.Open
        Me._cmd = New MySqlCommand(("Select cell from patients where idnumber ='" & Me.v1.Text & "' "), Me._con)
        Me.v2.Text = Conversions.ToString(Me._cmd.ExecuteScalar)
        Me._cmd.Dispose
        Me._con.Close
    Catch exception1 As Exception
        ProjectData.SetProjectError(exception1)
        Dim exception As Exception = exception1
        Me._cmd.Dispose
        Me._con.Close
        ProjectData.ClearProjectError
    End Try
    End Sub

    Private Sub c1_TextChanged(sender As Object, e As EventArgs) Handles c1.TextChanged
         Try 
        Me._con.Close
        Me._con.Open
        Me._cmd = New MySqlCommand(("Select cell from patients where idnumber ='" & Me.c1.Text & "' "), Me._con)
        Me.c2.Text = Conversions.ToString(Me._cmd.ExecuteScalar)
        Me._cmd.Dispose
        Me._con.Close
    Catch exception1 As Exception
        ProjectData.SetProjectError(exception1)
        Dim exception As Exception = exception1
        Me._cmd.Dispose
        Me._con.Close
        ProjectData.ClearProjectError
    End Try
    End Sub

    Private Sub d1_TextChanged(sender As Object, e As EventArgs) Handles d1.TextChanged
         Try 
        Me._con.Close
        Me._con.Open
        Me._cmd = New MySqlCommand(("Select cell from patients where idnumber ='" & Me.d1.Text & "' "), Me._con)
        Me.d2.Text = Conversions.ToString(Me._cmd.ExecuteScalar)
        Me._cmd.Dispose
        Me._con.Close
    Catch exception1 As Exception
        ProjectData.SetProjectError(exception1)
        Dim exception As Exception = exception1
        Me._cmd.Dispose
        Me._con.Close
        ProjectData.ClearProjectError
    End Try
    End Sub
End Class
