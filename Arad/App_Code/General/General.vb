Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class General


    Public Sub DropDownFill(ByVal DDObj As System.Web.UI.WebControls.DropDownList, ByVal DataField As String, ByVal DataValue As String, ByVal DataSource As Data.DataTable, Optional ByVal SelectValue As Decimal = 0)
        DDObj.DataTextField = DataField
        DDObj.DataValueField = DataValue

        DDObj.DataSource = DataSource
        DDObj.DataBind()
        If SelectValue <> 0 Then
            DDObj.SelectedValue = SelectValue
        End If

    End Sub



End Class
