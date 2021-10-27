Imports System.Data
Imports System.Data.SqlClient

Public Class Slabs


    Public Function SlabsSelectBySearch(ByVal slabType As String, ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "SlabsSelectBySearch"

            Dim sqlparams(1) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabType", slabType)
            sqlparams(1) = New SqlParameter("@slabId", slabId)

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


    Public Function SlabsSelectByType(ByVal slabType As Integer)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "SlabsSelectByType"

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

    Public Function SlabSelect_BySlabId(ByVal slabId As String)
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

    Public Function SlabSelect_LikeSlabId(ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "SlabSelect_LikeSlabId"

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

    'Friend Function Slab_Sefareshi_Insert(text1 As String, text2 As String, slabType As String, text3 As String, text4 As String, v As Object) As String
    '    Throw New NotImplementedException()
    'End Function

    Public Function Slab_Assembly_Insert(ByVal slabId As String, ByVal slabName As String, slabNameEng As String,
                                         ByVal Description As String, ByVal FileName As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Assembly_Insert"

            Dim sqlparams(5) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabName", slabName)
            sqlparams(2) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(3) = New SqlParameter("@Description", Description)
            sqlparams(4) = New SqlParameter("@FileName", FileName)
            sqlparams(5) = New SqlParameter
            sqlparams(5).Direction = Data.ParameterDirection.Output
            sqlparams(5).ParameterName = "@output"
            sqlparams(5).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(5).Value.ToString

        Catch ex As Exception
            Return 1
        Finally
        End Try
    End Function

    Friend Function Slab_Sefareshi_Update(v As Object, text1 As String, text2 As String, text3 As String) As String
        Throw New NotImplementedException()
    End Function

    Public Function Slab_Assembly_Update(ByVal slabId As String, ByVal slabName As String, slabNameEng As String, ByVal Description As String)
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


    Public Function Slab_Assembly_Delete(ByVal slabId As String)
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


    Public Function Slab_Tolidi_Insert(ByVal slabId As String, ByVal slabName As String, ByVal SlabType As Integer,
                                       slabNameEng As String, ByVal Megdar As Decimal, ByVal VaznMasrafi As Decimal,
                                       ByVal VaznKhales As Decimal, ByVal BoradeId As Decimal, ByVal Tedadhasele As Decimal,
                                       FileName As String, ByVal Description As String, ByVal SubmitPersianDate As String,
                                       ByVal SlabIdAvvaliyeh As String)


        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Tolidi_Insert"

            Dim sqlparams(13) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabName", slabName)
            sqlparams(2) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(3) = New SqlParameter("@Description", Description)
            sqlparams(4) = New SqlParameter("@FileName", FileName)
            sqlparams(5) = New SqlParameter("@SlabType", SlabType)
            sqlparams(6) = New SqlParameter("@Megdar", Megdar)
            sqlparams(7) = New SqlParameter("@VaznMasrafi", VaznMasrafi)
            sqlparams(8) = New SqlParameter("@VaznKhales", VaznKhales)
            sqlparams(9) = New SqlParameter("@SubmitPersianDate", SubmitPersianDate)
            sqlparams(10) = New SqlParameter
            sqlparams(10).Direction = Data.ParameterDirection.Output
            sqlparams(10).ParameterName = "@output"
            sqlparams(10).DbType = Data.DbType.Decimal
            sqlparams(11) = New SqlParameter("@BoradeId", BoradeId)
            sqlparams(12) = New SqlParameter("@Tedadhasele", Tedadhasele)
            sqlparams(13) = New SqlParameter("@SlabIdAvvaliyeh", SlabIdAvvaliyeh)


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(10).Value.ToString

        Catch ex As Exception
            Return 1
        Finally
        End Try
    End Function


    Public Function Slab_Tolidi_Update(ByVal slabId As String, ByVal slabName As String, slabNameEng As String, ByVal Description As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Tolidi_Update"

            Dim sqlparams(4) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabName", slabName)
            sqlparams(2) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(3) = New SqlParameter("@Description", Description)
            sqlparams(4) = New SqlParameter("@Megdar", Megdar)
            sqlparams(5) = New SqlParameter("@VaznMasrafi", VaznMasrafi)
            sqlparams(6) = New SqlParameter("@VaznKhales", VaznKhales)
            sqlparams(7) = New SqlParameter
            sqlparams(7).Direction = Data.ParameterDirection.Output
            sqlparams(7).ParameterName = "@output"
            sqlparams(7).DbType = Data.DbType.Decimal


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

    Private Function VaznKhales() As SqlDbType
        Throw New NotImplementedException()
    End Function

    Private Function VaznMasrafi() As SqlDbType
        Throw New NotImplementedException()
    End Function

    Private Function Megdar() As SqlDbType
        Throw New NotImplementedException()
    End Function

    Public Function Slab_Tolidi_Delete(ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Tolidi_Delete"

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

    Public Function Slab_kharidani_Insert(ByVal slabId As String, ByVal slabName As String, ByVal SlabType As Integer,
                                       slabNameEng As String, ByVal Description As String, ByVal FileName As String)

        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_kharidani_Insert"

            Dim sqlparams(6) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabName", slabName)
            sqlparams(2) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(3) = New SqlParameter("@Description", Description)
            sqlparams(4) = New SqlParameter("@FileName", FileName)
            sqlparams(5) = New SqlParameter("@SlabType", SlabType)
            sqlparams(6) = New SqlParameter
            sqlparams(6).Direction = Data.ParameterDirection.Output
            sqlparams(6).ParameterName = "@output"
            sqlparams(6).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 2
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(6).Value.ToString

        Catch ex As Exception
            Return 2
        Finally
        End Try
    End Function


    Public Function Slab_kharidani_Update(ByVal slabId As String, ByVal slabName As String, slabNameEng As String, ByVal Description As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_kharidani_Update"

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
                i += 2
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(4).Value.ToString

        Catch ex As Exception
            Return 2
        Finally
        End Try
    End Function


    Public Function Slab_kharidani_Delete(ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_kharidani_Delete"

            Dim sqlparams(1) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter
            sqlparams(1).Direction = Data.ParameterDirection.Output
            sqlparams(1).ParameterName = "@output"
            sqlparams(1).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 2
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(1).Value.ToString

        Catch ex As Exception
            Return 2
        Finally
        End Try
    End Function

    Public Function Slab_Sefareshi_Insert(ByVal slabId As String, ByVal slabName As String, ByVal SlabType As Integer,
                                       slabNameEng As String, ByVal Description As String, ByVal FileName As String)

        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Sefareshi_Insert"

            Dim sqlparams(6) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabName", slabName)
            sqlparams(2) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(3) = New SqlParameter("@Description", Description)
            sqlparams(4) = New SqlParameter("@FileName", FileName)
            sqlparams(5) = New SqlParameter("@SlabType", SlabType)
            sqlparams(6) = New SqlParameter
            sqlparams(6).Direction = Data.ParameterDirection.Output
            sqlparams(6).ParameterName = "@output"
            sqlparams(6).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 4
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(6).Value.ToString

        Catch ex As Exception
            Return 4
        Finally
        End Try
    End Function


    Public Function Slab_Sefareshi_Update(ByVal slabId As String, ByVal slabName As String, slabNameEng As String, ByVal Description As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Sefareshi_Update"

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
                i += 4
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(4).Value.ToString

        Catch ex As Exception
            Return 4
        Finally
        End Try
    End Function


    Public Function Slab_Sefareshi_Delete(ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Sefareshi_Delete"

            Dim sqlparams(1) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter
            sqlparams(1).Direction = Data.ParameterDirection.Output
            sqlparams(1).ParameterName = "@output"
            sqlparams(1).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 4
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(1).Value.ToString

        Catch ex As Exception
            Return 4
        Finally
        End Try
    End Function

    Public Function Slab_Masrafi_Insert(ByVal slabId As String, ByVal slabName As String, ByVal SlabType As Integer,
                                       slabNameEng As String, ByVal Description As String, ByVal FileName As String)

        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Masrafi_Insert"

            Dim sqlparams(6) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabName", slabName)
            sqlparams(2) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(3) = New SqlParameter("@Description", Description)
            sqlparams(4) = New SqlParameter("@FileName", FileName)
            sqlparams(5) = New SqlParameter("@SlabType", SlabType)
            sqlparams(6) = New SqlParameter
            sqlparams(6).Direction = Data.ParameterDirection.Output
            sqlparams(6).ParameterName = "@output"
            sqlparams(6).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 5
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(6).Value.ToString

        Catch ex As Exception
            Return 5
        Finally
        End Try
    End Function


    Public Function Slab_Masrafi_Update(ByVal slabId As String, ByVal slabName As String, slabNameEng As String, ByVal Description As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Masrafi_Update"

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
                i += 5
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(4).Value.ToString

        Catch ex As Exception
            Return 5
        Finally
        End Try
    End Function


    Public Function Slab_Masrafi_Delete(ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Masrafi_Delete"

            Dim sqlparams(1) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter
            sqlparams(1).Direction = Data.ParameterDirection.Output
            sqlparams(1).ParameterName = "@output"
            sqlparams(1).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 5
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(1).Value.ToString

        Catch ex As Exception
            Return 5
        Finally
        End Try
    End Function

    Public Function Slab_Abzar_Insert(ByVal slabId As String, ByVal slabName As String, ByVal SlabType As Integer,
                                       slabNameEng As String, ByVal Description As String, ByVal FileName As String)

        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Abzar_Insert"

            Dim sqlparams(6) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@slabName", slabName)
            sqlparams(2) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(3) = New SqlParameter("@Description", Description)
            sqlparams(4) = New SqlParameter("@FileName", FileName)
            sqlparams(5) = New SqlParameter("@SlabType", SlabType)
            sqlparams(6) = New SqlParameter
            sqlparams(6).Direction = Data.ParameterDirection.Output
            sqlparams(6).ParameterName = "@output"
            sqlparams(6).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 6
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(6).Value.ToString

        Catch ex As Exception
            Return 6
        Finally
        End Try
    End Function


    Public Function Slab_Abzar_Update(ByVal slabId As String, ByVal slabName As String, slabNameEng As String, ByVal Description As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Abzar_Update"

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
                i += 6
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(4).Value.ToString

        Catch ex As Exception
            Return 6
        Finally
        End Try
    End Function


    Public Function Slab_Abzar_Delete(ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "Slab_Abzar_Delete"

            Dim sqlparams(1) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter
            sqlparams(1).Direction = Data.ParameterDirection.Output
            sqlparams(1).ParameterName = "@output"
            sqlparams(1).DbType = Data.DbType.Decimal


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 6
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(1).Value.ToString

        Catch ex As Exception
            Return 6
        Finally
        End Try
    End Function


    Public Function SlabBoradeSelect()
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "SlabBoradeSelect"


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
