Public Class Message
    Inherits System.Web.UI.UserControl
    Dim Messages As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Messages = String.Empty Then
                Me.ErrMessages(Me.ViewState("MessageType")) = Messages
            End If

        Catch ex As Exception

        End Try
    End Sub

    Enum MessageType
        None = 0
        Err = 1
        Warning = 2
        Success = 3
    End Enum


    Public Property ErrMessages(Optional ByVal MessageType As MessageType = MessageType.None) As String
        Get
            Return Messages
        End Get
        Set(value As String)
            Me.ViewState("MessageType") = MessageType

            If String.IsNullOrEmpty(value) Then
                Me.ViewState("Messages") = String.Empty
                Messages = String.Empty
                Me.DIV1.InnerHtml = String.Empty
                Me.DIV2.Visible = False

            Else
                Messages += "<div style='height:22px'>" + value + "</div>"
                Me.Image1.ImageUrl = Me.MessageTypeStyles(MessageType)
                Me.DIV1.InnerHtml = Me.Messages
                Me.DIV2.Visible = True
            End If

        End Set
    End Property

    Private Function MessageTypeStyles(ByVal MsgType As MessageType)
        Select Case MsgType

            Case MessageType.Err
                DIV2.Style.Add("border-right", "#ff0000 1px solid")
                DIV2.Style.Add("border-top", "#ff0000 1px solid")
                DIV2.Style.Add("border-left", "#ff0000 1px solid")
                DIV2.Style.Add("border-bottom", "#ff0000 1px solid")
                DIV2.Style.Add("background-color", "#ffe4e4")
                DIV2.Style.Add("color", "#B30000")


            Case MessageType.None
                DIV2.Style.Add("border-right", "#0400FF 1px solid")
                DIV2.Style.Add("border-top", "#0400FF 1px solid")
                DIV2.Style.Add("border-left", "#0400FF 1px solid")
                DIV2.Style.Add("border-bottom", "#0400FF 1px solid")
                DIV2.Style.Add("background-color", "#DFE2FF")
                DIV1.Style.Add("color", "#001A83")

            Case MessageType.Success
                DIV2.Style.Add("border-right", "#33C62E 1px solid")
                DIV2.Style.Add("border-top", "#33C62E 1px solid")
                DIV2.Style.Add("border-left", "#33C62E 1px solid")
                DIV2.Style.Add("border-bottom", "#33C62E 1px solid")
                DIV2.Style.Add("background-color", "#D8FFD4")
                DIV1.Style.Add("color", "#118300")

            Case MessageType.Warning
                DIV2.Style.Add("border-right", "#FFE600 1px solid")
                DIV2.Style.Add("border-top", "#FFE600 1px solid")
                DIV2.Style.Add("border-left", "#FFE600 1px solid")
                DIV2.Style.Add("border-bottom", "#FFE600 1px solid")
                DIV2.Style.Add("background-color", "#FFFCD0")
                DIV1.Style.Add("color", "#714915")

        End Select

    End Function

End Class