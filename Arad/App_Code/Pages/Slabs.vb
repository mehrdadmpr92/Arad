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

    Public Function SlabSelect_SubSlabs(ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "SlabSelect_SubSlabs"

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
    Friend Function SlabsAssemblySelect_BySlabId(ByVal slabId As String) As DataTable
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "SlabsAssemblySelect_BySlabId"

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

    Public Function Slab_Assembly_Insert(ByVal tbl As DataTable, ByVal slabId As String, ByVal slabNameEng As String, ByVal slabName As String, ByVal fileName As String,
                                         ByVal description As String, ByVal submitPersianDate As String, ByVal version As Integer, ByVal slabType As Integer)

        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()
            Dim i As Integer = 0
            Dim Param As SqlParameter
            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.Connection = connection.Connection

            Dim myTbl As New Data.DataTable
            Dim number As String = ""
            Dim slabsTotal As String = ""

            If slabType = 3 Then
                Dim x As Integer
                For x = 0 To tbl.Rows.Count - 1
                    If Not number.Length = 0 Then
                        number += "',"
                    End If
                    number += "'" + tbl.Rows(x).Item("شماره قطعه").ToString + "'"

                    myTbl = SlabSelect_SubSlabs(tbl.Rows(x).Item("شماره قطعه").ToString())

                    If myTbl.Rows.Count > 0 Then
                        number += "," + myTbl.Rows(0).Item("Sub_Slabs").ToString()
                    End If


                    If slabsTotal.Length > 0 Then
                        slabsTotal += "union all"
                    End If
                    slabsTotal += " Select '" + slabId + "'as Assembly_SlabId ," + tbl.Rows(x).Item("تعداد").ToString() +
                            " as SubSlabTedad,'" + tbl.Rows(x).Item("شماره قطعه").ToString() + "' as SubSlabId" + vbCrLf
                    slabsTotal += "union all  " + vbCrLf

                    slabsTotal += "select '" + slabId + "' as Assembly_SlabId , ( " +
                        tbl.Rows(x).Item("تعداد").ToString() + "* SubSlabTedad) as SubSlabTedad,SubSlabId "

                    slabsTotal += "From SlabSubTotal" + vbCrLf
                    slabsTotal += " Where Assembly_SlabId='" + tbl.Rows(x).Item("شماره قطعه").ToString() + "'" + vbCrLf

                Next
            End If

            slabsTotal = " select Assembly_slabId , sum(SubSlabTedad), SubSlabId from(" + vbCrLf +
                slabsTotal + vbCrLf +
                ") as tbl group by Assembly_SlabId , SubSlabId" + vbCrLf


            slabsTotal = " delete from SlabSubTotal where Assembly_SlabId=' " + slabId + "' " + vbCrLf + vbCrLf + vbCrLf + "(" + vbCrLf + slabsTotal +
                vbCrLf + ")"



            Dim str As String = " begin tran t1 " + vbCrLf

            str += slabsTotal + vbCrLf + vbCrLf + vbCrLf + vbCrLf
            str += " update [Slabs] set SlabMaxVersion='N' where slabId=@slabId " + vbCrLf + vbCrLf
            str += " insert into [Slabs] (SlabMaxVersion , slabId , Version , SlabType ,slabNameEng , slabName , FileName , Description ,  
                    SubmitPersianDate ,Sub_Slabs)" + vbCrLf +
                    "Values('Y' , @slabId , @version , @slabType , @slabNameEng , @slabName , @fileName , @description , @submitPersianDate,@Sub_Slabs)" + vbCrLf


            Dim j As Integer
            str += "declare @SlabId_Num decimal" + vbCrLf
            str += "Select Max(SlabId_Num) from Slabs where slabId='" + slabId + "'" + vbCrLf + vbCrLf

            For j = 0 To tbl.Rows.Count - 1
                str += "insert Into Slab_Subs(Tedad ,Row , SlabId , SlabID_Num) " + vbCrLf
                str += "Values(" + tbl.Rows(j).Item("تعداد").ToString + "," + tbl.Rows(j).Item("ردیف").ToString + ", '" +
                    tbl.Rows(j).Item("شماره قطعه").ToString + "' , @SlabId_Num)" + vbCrLf

                str += vbCrLf + " "
            Next


            str += "if (@@Error <> 0) begin rollback tran t1 set @output=1 end else begin commit tran t1 set @output=0   end" + vbCrLf



            connection.Adapter.SelectCommand.CommandText = str
            connection.Adapter.SelectCommand.CommandType = CommandType.Text

            Dim sqlparams(9) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@version", version)
            sqlparams(2) = New SqlParameter("@slabType", slabType)
            sqlparams(3) = New SqlParameter("@slabName", slabName)
            sqlparams(4) = New SqlParameter("@slabNameEng", slabNameEng)
            sqlparams(5) = New SqlParameter("@fileName", fileName)
            sqlparams(6) = New SqlParameter("@description", description)
            sqlparams(7) = New SqlParameter("@submitPersianDate", submitPersianDate)
            sqlparams(8) = New SqlParameter
            sqlparams(8).Direction = Data.ParameterDirection.Output
            sqlparams(8).ParameterName = "@output"
            sqlparams(8).DbType = Data.DbType.Decimal
            sqlparams(9) = New SqlParameter("@Sub_Slabs", number)


            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next
            connection.Adapter.SelectCommand.ExecuteNonQuery()
            Return sqlparams(8).Value.ToString
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()

        Catch ex As Exception
            Return 1
        End Try


    End Function

    Friend Function Slab_Sefareshi_Update(v As Object, text1 As String, text2 As String, text3 As String) As String
        Throw New NotImplementedException()
    End Function

    Public Function Slab_Assembly_Update(ByVal slabId As String, ByVal slabName As String, slabNameEng As String, ByVal Description As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()



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


            Dim i As Integer = 0
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
