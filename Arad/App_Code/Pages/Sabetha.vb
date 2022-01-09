Imports System.Data
Imports System.Data.SqlClient

Public Class Sabetha


    Public Function Fixcher_Insert(ByVal fixcherName As String, ByVal fixcherCode As String, ByVal fixcherTedadMojaz As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object
            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.Connection = connection.Connection

            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Fixcher_Insert"

            Dim sqlparams(3) As SqlParameter
            sqlparams(0) = New SqlParameter("@fixcherName", fixcherName)
            sqlparams(1) = New SqlParameter("@fixcherCode", fixcherCode)
            sqlparams(2) = New SqlParameter("@fixcherTedadMojaz", fixcherTedadMojaz)
            sqlparams(3) = New SqlParameter
            sqlparams(3).Direction = Data.ParameterDirection.Output
            sqlparams(3).ParameterName = "@output"
            sqlparams(3).DbType = Data.DbType.Decimal

            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(3).Value.ToString

        Catch ex As Exception
            Return 1
        Finally
        End Try
    End Function

    Public Function FixcherCode_Check(ByVal fixcherCode As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "FixcherCode_Check"

            Dim sqlparams(0) As SqlParameter
            sqlparams(0) = New SqlParameter("@fixcherCode", fixcherCode)

            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next


            connection.DataTable = New DataTable("Table")
            connection.Adapter.Fill(connection.DataTable)
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return connection.DataTable

        Catch ex As Exception
            Return Nothing
        Finally
        End Try
    End Function
End Class
