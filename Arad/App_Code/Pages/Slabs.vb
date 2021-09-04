Imports System.Data
Imports System.Data.SqlClient

Public Class Slabs

    Public Function Slab_Assembly_Insert(ByVal slabId As Decimal, ByVal slabName As String, slabNameEng As String, ByVal Description As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Assembly_Insert"

            Dim sqlparams(4) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabName", slabName)
            sqlparams(2) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(3) = New SqlParameter("@Description", Description)
            sqlparams(4) = New SqlParameter
            sqlparams(4).Direction = Data.ParameterDirection.Output
            sqlparams(4).ParameterName = "@output"
            sqlparams(4).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(4).Value.ToString

        Catch ex As Exception
            Return 1
        Finally
        End Try
    End Function

    Public Function SlabSelect(ByVal slabType As Integer)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "SlabSelect"

            Dim sqlparams(0) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabType", slabType)

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

    Public Function SlabSelect_BySlabId(ByVal slabId As Decimal)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "SlabSelect_BySlabId"

            Dim sqlparams(0) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)

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

    Public Function Slab_Assembly_Update(ByVal slabId As Decimal, ByVal slabName As String, slabNameEng As String, ByVal Description As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Assembly_Update"

            Dim sqlparams(4) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabName", slabName)
            sqlparams(2) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(3) = New SqlParameter("@Description", Description)
            sqlparams(4) = New SqlParameter
            sqlparams(4).Direction = Data.ParameterDirection.Output
            sqlparams(4).ParameterName = "@output"
            sqlparams(4).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(4).Value.ToString

        Catch ex As Exception
            Return 1
        Finally
        End Try
    End Function


    Public Function Slab_Assembly_Delete(ByVal slabId As Decimal)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Assembly_Delete"

            Dim sqlparams(1) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter
            sqlparams(1).Direction = Data.ParameterDirection.Output
            sqlparams(1).ParameterName = "@output"
            sqlparams(1).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(1).Value.ToString

        Catch ex As Exception
            Return 1
        Finally
        End Try
    End Function




End Class
