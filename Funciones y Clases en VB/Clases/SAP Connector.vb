Imports SAPFEWSELib

Public Class SAPConnector

#Region "Var Declaration"
    Dim SAPAppl As New GuiApplication
    Dim SAPConn As GuiConnection
    Dim SAPSess As GuiSession
    Dim SAPGUI As Object
#End Region

#Region "Properties"

    Dim _transactionResult As New TransactionResult()
    Public Property TransactionResult As TransactionResult
        Get
            Return _transactionResult
        End Get
        Set(value As TransactionResult)
            _transactionResult = value
        End Set
    End Property

    Dim _isSAPOpen As Boolean
    ''' <summary>
    ''' Validate if SAP is Open.
    ''' </summary>
    ''' <returns>True if there is a Open Connection</returns>
    Public Property isSAPOpen() As Boolean
        Get
            Return _isSAPOpen
        End Get
        Set(value As Boolean)
            _isSAPOpen = value
        End Set
    End Property

    ReadOnly Property connection() As GuiConnection
        Get
            Return SAPConn
        End Get
    End Property

    ReadOnly Property application() As GuiApplication
        Get
            Return SAPAppl
        End Get
    End Property

    ReadOnly Property session() As GuiSession
        Get
            Return SAPSess
        End Get
    End Property

#End Region


#Region "Constructors"
    Public Sub New()
        ValidateSAPConnection()
    End Sub

    Protected Overrides Sub Finalize()
        Try
            GC.SuppressFinalize(SAPSess)
            GC.SuppressFinalize(SAPConn)
            GC.SuppressFinalize(SAPAppl)
            GC.SuppressFinalize(SAPGUI)

            SAPSess = Nothing
            SAPConn = Nothing
            SAPAppl = Nothing
            SAPGUI = Nothing

            GC.SuppressFinalize(Me)
            MyBase.Finalize()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Overridable Procedures"
    ''' <summary>
    ''' Validate if SAP has a System Message Window
    ''' </summary>
    ''' <param name="SAPSess"></param>
    Overridable Sub Check_System(ByRef SAPSess As GuiSession)
        Dim retId As Object
        retId = SAPSess.FindById("wnd[1]", False)
        If Not (retId Is Nothing) Then
            SAPSess.FindById("wnd[1]").SetFocus()
            Dim msg = SAPSess.FindById("wnd[1]").Text
            If msg = "System Messages" Then
                SAPSess.FindById("wnd[1]/tbar[0]/btn[12]").press()
            End If
        End If
    End Sub
#End Region

#Region "Public Subs"

    ''' <summary>
    ''' Validate if exists a SAP Session open.
    ''' </summary>
    Public Sub ValidateSAPConnection()
        Try
            SAPSess = Nothing
            SAPConn = Nothing
            SAPAppl = Nothing
            SAPGUI = Nothing
            SAPGUI = GetObject("SAPGUI")
            SAPAppl = SAPGUI.GetScriptingEngine
            SAPAppl.AllowSystemMessages = False
            SAPConn = SAPAppl.Children(0)
            SAPSess = SAPConn.Children(0)
            isSAPOpen = True
        Catch ex As Exception
            isSAPOpen = False
        End Try
    End Sub





#End Region

End Class
