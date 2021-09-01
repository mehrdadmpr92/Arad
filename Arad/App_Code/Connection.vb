Imports System.Data

NotInheritable Class Connection
    Public Connection As New SqlClient.SqlConnection
    Public Command As New SqlClient.SqlCommand
    Public Adapter As New SqlClient.SqlDataAdapter
    Public DataSet As DataSet
    Public DataTable As DataTable

    Public Sub New()
        Try

            Connection.ConnectionString = "Data Source=.;Initial Catalog=Arad;User ID=sa; password=abc@123"

            Me.Command.Connection = Me.Connection
            Me.Adapter.SelectCommand = New SqlClient.SqlCommand
            Me.Adapter.SelectCommand.Connection = Me.Connection
            Me.Adapter.UpdateCommand = New SqlClient.SqlCommand
            Me.Adapter.UpdateCommand.Connection = Me.Connection
            Me.Adapter.DeleteCommand = New SqlClient.SqlCommand
            Me.Adapter.DeleteCommand.Connection = Me.Connection
        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Sub Finalize()
        Try
            MyBase.Finalize()
            If Me.Connection IsNot Nothing Then Me.Connection.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Function GetConnectionParameters(ByVal ParamererName As String) As String
        Dim StartIndex As Integer
        Dim Lenth As Integer
        StartIndex = Me.Connection.ConnectionString.IndexOf(ParamererName) + 8
        Lenth = Connection.ConnectionString.Substring(StartIndex).IndexOf(";")
        Return Connection.ConnectionString.Substring(StartIndex, Lenth)
    End Function
End Class