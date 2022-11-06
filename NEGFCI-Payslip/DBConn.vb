Imports System.Data.OleDb
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module dbconn
    'Public dbcon As New OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=mydata.accdb;Jet OLEDB:Database Password=mersonpoge")
    Public dbcon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mydata.accdb;Jet OLEDB:Database Password=mersonpoge") 'install MS ACCESS Runtime
    Public SQLDataset As New DataSet
    Public SQLDA As New OleDbDataAdapter
    Public datatable As New DataTable
    Public cmd As New OleDbCommand
    Public Params As New List(Of OleDbParameter)
    Public Reader As OleDbDataReader
    Public Recordcount As Integer
    Public MsgErr As Object
    Public PrimaryKey As Integer
    Public retriveID As Integer

    Public DES As New TripleDESCryptoServiceProvider
    Public MD5 As New MD5CryptoServiceProvider

    'user information
    'Administrator information
    Public userID As Integer
    Public DataFullName As String
    Public Quotes As String
    Public UserName As String
    Public UserPass As String

    Public Sub AddParam(ByVal Name As String, ByVal Value As Object) 'Security for avoiding SQL Injection Error
        Dim NewParam As New OleDbParameter(Name, Value)
        Params.Add(NewParam)
    End Sub

    Public Sub QRecord(ByVal FQuery As String) 'Get sa record count retreive
        Try
            dbcon.Open()
            cmd = New OleDbCommand(FQuery, dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))

            Params.Clear()
            SQLDataset = New DataSet
            SQLDA = New OleDbDataAdapter(cmd)
            Recordcount = SQLDA.Fill(SQLDataset)

            dbcon.Close()
        Catch ex As Exception
            Params.Clear()
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
    End Sub

    Public Sub DoSQL(ByVal SQL As String) 'Execute SQL commnand
        MsgErr = Nothing
        Try
            dbcon.Open()
            cmd = New OleDbCommand(SQL, dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            'cmd.ExecuteNonQuery()
            retriveID = cmd.ExecuteScalar '; Select LAST_INSERT_ID()

            dbcon.Close()
        Catch ex As Exception
            Params.Clear()
            MsgErr = ex.Message
            MsgBox(ex.Message, vbCritical, "ERROR MESSAGE")
            dbcon.Close()
        End Try
    End Sub

    Public Function CheckConnection() As Boolean 'Check Connection if working or connected to the Database
        Try
            dbcon.Open()
            MsgBox("Connected Successfully!", vbInformation, "Message")

            dbcon.Close()
            Return True

        Catch ex As Exception
            MsgBox("Connection Failed!", vbCritical, "Message")
            MsgBox(ex.Message, vbExclamation, "Message")
            dbcon.Close()
            Return False
        End Try
    End Function

    Public Sub PK(ByVal SQL As String) 'Get Primary key executed 
        Try
            dbcon.Open()
            cmd = New OleDbCommand(SQL, dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader
            Reader.Read()
            PrimaryKey = Reader(0)

            dbcon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

            Params.Clear()
            PrimaryKey = Nothing
            dbcon.Close()
        End Try

    End Sub

    Public Sub wait(ByVal seconds As Integer) 'Timer waiting Time
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub

    Public Function MD5HASH(ByVal Value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Value))
    End Function

    Public Function Encrypt(ByVal StringInput As String, ByVal key As String) As String
        DES.Key = MD5HASH(key)
        DES.Mode = CipherMode.ECB
        Dim buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(StringInput)
        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length))
    End Function

    Public Sub Load_userData()
        Try
            dbcon.Open()
            cmd = New OleDbCommand("select * from tbluser where id=" & userID & "", dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader

            Do While Reader.Read = True
                DataFullName = Reader("name").ToString
                UserName = Reader("username").ToString
                UserPass = Reader("password").ToString
                Quotes = Reader("quotes").ToString
            Loop
            dbcon.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "ERROR MESSAGE")
            dbcon.Close()
        End Try

    End Sub

End Module
