Public Class TransactionResult

    Enum Status
        Standby = -2
        Failed = -1
        Warning = 0
        Ok = 1
        Clear = 2
    End Enum

    Private _TException As Exception
    Public Property TException As Exception
        Get
            Return _TException
        End Get
        Set(value As Exception)
            _TException = value
        End Set
    End Property

    Private _tstatus As Status = Status.Standby
    Public Property TStatus As Status
        Get
            Return _tstatus
        End Get
        Set(value As Status)
            If value = Status.Clear Then
                Message = ""
                TException = Nothing
            End If
            _tstatus = value
        End Set
    End Property

    Private _message As String = ""
    Public Property Message As String
        Get
            Return _message
        End Get
        Set(value As String)
            _message = value
        End Set
    End Property

    Public Sub setMessage(ByVal msg As String, ByVal status As Status, Optional ByVal except As Exception = Nothing)
        Message = msg : TStatus = status : TException = except
    End Sub


End Class