Imports System.Configuration
Imports System.IO
Imports MySql.Data.MySqlClient
Public Class Passwordrecover
     Dim _ApplicationID As String
    Dim _cmd As MySqlCommand
    ReadOnly _con As MySqlConnection = New MySqlConnection(ConfigurationManager.ConnectionStrings("myConnection").ConnectionString)
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim Passwordpassword As String
        If txtCell.Text=""
            MsgBox("Enter cell number first")
            Exit Sub
        End If
        Try
           _con.Close()
            _con.Open()
            _cmd =
                New MySqlCommand(
                   "Select distinct(password) from users where phone ='"& txtCell.Text &"' ",_con)
           Passwordpassword=_cmd.ExecuteScalar
        _cmd.Dispose
        _con.Close()

           With SerialPort1
                    .WriteLine("AT" & vbCrLf)
                    Threading.Thread.Sleep(1000)
                    .WriteLine("AT+CMGF=1" & vbCrLf) 'Instruct the GSM / GPRS modem to operate in SMS text mode
                    Threading.Thread.Sleep(1000)
                    .WriteLine("AT+CMGS=""" & txtCell.Text & """" & vbCr) 'sender ko no. rakhne ho tyo txtnumber ma 
                    Threading.Thread.Sleep(1000) 'thapeko
                    .WriteLine("Your recoverd passord is " & Passwordpassword & vbCrLf & Chr(26)) 'txtmessage automatic huna parchha haina?
                    'did you get my message?
                End With
            MsgBox("Password recoverd")
        Catch ex As Exception
             _cmd.Dispose
        _con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub openport()
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
            ' BtnConnect.Text = "Connect"
        Else
            Try
                With SerialPort1
                    .PortName = Trim(Mid("COM7", 1, 5))
                    .BaudRate = 9600
                    .Parity = IO.Ports.Parity.None
                    .DataBits = 8
                    .StopBits = Ports.StopBits.One
                    .Handshake = Ports.Handshake.None
                    .RtsEnable = True
                    .DtrEnable = True
                    .Open()
                    .WriteLine("AT+CNMI=1,2,0,0,0" & vbCrLf) 'send whatever data that it receives to serial port  
                End With
                t1.Visible = True
                t2.Visible = True
                'BtnConnect.Text = "Disconnect"
            Catch ex As Exception
                t1.Visible = False
                t2.Visible = False
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Passwordrecover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        openport()
    End Sub

    Private Sub Passwordrecover_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose
    End Sub
End Class