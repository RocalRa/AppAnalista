
Imports System
Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement

Public Class Funciones_VB
    Public Function textFileWithHeader(pathFileName As String, destPathFileName As String, headerSample As String, Optional includeHeader As Boolean = True) As Boolean
        If My.Computer.FileSystem.FileExists(destPathFileName) Then
            My.Computer.FileSystem.DeleteFile(destPathFileName)
        End If
        Dim sReader As New IO.StreamReader(pathFileName)
        Dim sWriter As New IO.StreamWriter(destPathFileName)
        Dim startWrite As Boolean = False

        Do While Not sReader.EndOfStream
            Dim line As String = sReader.ReadLine()
            If line.Length > 0 Then If Mid(line, 1, 1) = "|" Then line = Mid(line, 2, line.Length)
            If line.Length > 0 Then If Mid(line, line.Length, 1) = "|" Then line = Mid(line, 1, line.Length - 1)
            If line.Replace(" ", "") = headerSample Then
                If Not startWrite Then
                    startWrite = True
                    If includeHeader Then sWriter.WriteLine(line.Replace("|", ";").Replace(" ", ""))
                End If
            ElseIf line.Replace(" ", "") = "List contains no data" Then
                'hago lo que tenga que hacer
                sWriter.WriteLine(headerSample.Replace("|", ";"))

            ElseIf startWrite Then
                If line.Replace("-", "").Replace("+", "").Length > 0 Then
                    sWriter.WriteLine(line.Replace("|", ";"))
                End If
            End If
        Loop
        sWriter.Close()
        sWriter.Dispose()
        sReader.Close()
        sReader.Dispose()

        Return True

    End Function

    Public Function AuthenticateUser(domainName As String, userName As String, password As String) As Boolean
        Dim ret = False
        Try
            Dim de = New DirectoryEntry("LDAP://" + domainName, userName, password)
            Dim dsearch = New DirectorySearcher(de)
            dsearch.FindOne()

            ret = True
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Public Function Name(logon As String) As String
        Dim usrName = ""

        Try
            usrName = UserPrincipal.FindByIdentity(New PrincipalContext(ContextType.Domain), logon).ToString()
        Catch ex As Exception
            usrName = "404 | User not Found"
        End Try

        Return usrName
    End Function


End Class