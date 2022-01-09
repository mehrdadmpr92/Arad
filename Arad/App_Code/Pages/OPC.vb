Imports System.Data
Imports System.Data.SqlClient

Public Class OPC

    Public Function OpcOperationSelect()
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "OpcOperationSelect"


            connection.DataTable = New DataTable("Table")
            connection.Adapter.Fill(connection.DataTable)
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return connection.DataTable

        Catch ex As Exception
            Return Nothing
        Finally
        End Try
    End Function


    Public Function Fixcher_Select(ByVal fixcherCode As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Fixcher_Select"

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

    Public Function Slab_Opc_Insert(ByVal slabId As String, ByVal RowNo As Integer, ByVal OperationId As Integer, ByVal OperationDesc As String,
                                    Tools As String, FixcherId As Decimal, TarefeWorker As Integer, NumWorker As Integer, TanzimTime As String,
                                    SlabTime As String, SubmitUserId As Integer, SubmitPersianDate As String)



        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object
            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.Connection = connection.Connection




            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Opc_Insert"

            Dim sqlparams(12) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@RowNo", RowNo)
            sqlparams(2) = New SqlParameter("@OperationId", OperationId)
            sqlparams(3) = New SqlParameter("@OperationDesc", OperationDesc)
            sqlparams(4) = New SqlParameter("@Tools", Tools)
            sqlparams(5) = New SqlParameter("@FixcherId", FixcherId)
            sqlparams(6) = New SqlParameter("@TarefeWorker", TarefeWorker)
            sqlparams(7) = New SqlParameter("@NumWorker", NumWorker)
            sqlparams(8) = New SqlParameter("@TanzimTime", TanzimTime)
            sqlparams(9) = New SqlParameter("@SlabTime", SlabTime)
            sqlparams(10) = New SqlParameter("@SubmitPersianDate", SubmitPersianDate)
            sqlparams(11) = New SqlParameter("@SubmitUserId", SubmitUserId)
            sqlparams(12) = New SqlParameter
            sqlparams(12).Direction = Data.ParameterDirection.Output
            sqlparams(12).ParameterName = "@output"
            sqlparams(12).DbType = Data.DbType.Decimal




            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(12).Value.ToString

        Catch ex As Exception
            Return 1
        Finally
        End Try
    End Function

    Public Function Slab_Opc_Sub_Delete(ByVal SlabOpcSubId As Integer)



        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object
            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.Connection = connection.Connection

            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Opc_Sub_Delete"

            Dim sqlparams(1) As SqlParameter
            sqlparams(0) = New SqlParameter("@SlabOpcSubId", SlabOpcSubId)
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

    Public Function Slab_OPC_Select(ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_OPC_Select"

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

    Public Function Slab_Opc_Insert_Finish(ByVal slabId As String, ByVal slabOPC_Finish As Boolean)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object
            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.Connection = connection.Connection

            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Opc_Insert_Finish"

            Dim sqlparams(2) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabOPC_Finish", slabOPC_Finish)
            sqlparams(2) = New SqlParameter
            sqlparams(2).Direction = Data.ParameterDirection.Output
            sqlparams(2).ParameterName = "@output"
            sqlparams(2).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(2).Value.ToString

        Catch ex As Exception
            Return 1
        Finally
        End Try
    End Function

End Class
