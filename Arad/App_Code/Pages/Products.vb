Imports System.Data
Imports System.Data.SqlClient

Public Class Products


    Public Function New_Product_Insert(ByVal slabId As String, ByVal ProductTradeName As String, ByVal ProductTradeCode As String,
                                      ServiceManualFile As String, ByVal UserManualFile As String, ByVal CatalogFile As String,
                                      ByVal TechFile As String, ByVal RevisionFile As String, ByVal ConfirmationFile As String,
                                      SalesGuideFile As String, ByVal BookletsFile As String, ByVal RelatedFile As String,
                                      ByVal SubmitPersianDate As String)


        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "New_Product_Insert"

            Dim sqlparams(13) As SqlParameter
            sqlparams(0) = New SqlParameter("@slabId", slabId)
            sqlparams(1) = New SqlParameter("@ProductTradeName", ProductTradeName)
            sqlparams(2) = New SqlParameter("@ProductTradeCode", ProductTradeCode)
            sqlparams(3) = New SqlParameter("@ServiceManualFile", ServiceManualFile)
            sqlparams(4) = New SqlParameter("@UserManualFile", UserManualFile)
            sqlparams(5) = New SqlParameter("@CatalogFile", CatalogFile)
            sqlparams(6) = New SqlParameter("@TechFile", TechFile)
            sqlparams(7) = New SqlParameter("@RevisionFile", RevisionFile)
            sqlparams(8) = New SqlParameter("@ConfirmationFile", ConfirmationFile)
            sqlparams(9) = New SqlParameter("@SalesGuideFile", SalesGuideFile)
            sqlparams(10) = New SqlParameter("@BookletsFile", BookletsFile)
            sqlparams(11) = New SqlParameter("@RelatedFile", RelatedFile)
            sqlparams(12) = New SqlParameter("@SubmitPersianDate", SubmitPersianDate)
            sqlparams(13) = New SqlParameter
            sqlparams(13).Direction = Data.ParameterDirection.Output
            sqlparams(13).ParameterName = "@output"
            sqlparams(13).DbType = Data.DbType.Decimal



            For Each Param In sqlparams
                connection.Adapter.SelectCommand.Parameters.Add(sqlparams(i))
                i += 1
            Next

            connection.Adapter.SelectCommand.ExecuteNonQuery()
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return sqlparams(13).Value.ToString

        Catch ex As Exception
            Return 1
        Finally
        End Try
    End Function
    Public Function SlabSelectForProduct(ByVal slabId As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "SlabSelectForProduct"

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

    Public Function SubSlabsStatusSelectForProduct(ByVal Sub_Slabs As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()
            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.Connection = connection.Connection

            Sub_Slabs = Sub_Slabs.Replace("''", "'")
            Dim str As String = ""

            str += "Select" + vbCrLf

            str += " SlabName , SlabNameEng , SlabId , SlabType ," + vbCrLf

            str += " case when Slabs.Sarparast_Flag='N' then N'قطعه شماره '+ Slabs.SlabId + N'توسط سرپرست برگشت داده شده است' + '<br/>' " + vbCrLf
            str += " when Slabs.Sarparast_Flag='O' then N'قطعه شماره '+ Slabs.SlabId + N'در انتظارتایید سرپرست می باشد' + '<br/>' " + vbCrLf
            str += "else N'' end as Slab_Saraparast_Status ," + vbCrLf

            str += " case when Slabs.Sarparast_Flag='N' Or Slabs.Sarparast_Flag='O' then 'False' " + vbCrLf
            str += "else 'True' end as Slab_Saraparast_Flag ," + vbCrLf


            str += " ( " + vbCrLf
            str += "case when (dbo.SlabOPC_Sarparast_Flag(Slabs.SlabId) is null) and (Slabs.SlabType = 1 OR Slabs.SlabType=3) then " + vbCrLf
            str += " N'مراحل ساخت قطعه ' + Slabs.SlabId + N'ثبت نگردیده است .' + '<br/>' " + vbCrLf
            str += " when (dbo.SlabOPC_Sarparast_Flag(Slabs.SlabId)='N') and (Slabs.SlabType = 1 OR Slabs.SlabType=3) then " + vbCrLf
            str += " N'مراحل ساخت قطعه ' + Slabs.SlabId + N'توسط سرپرست رد گردیده است .' + '<br/>' " + vbCrLf
            str += " when (dbo.SlabOPC_Sarparast_Flag(Slabs.SlabId)='O') and (Slabs.SlabType = 1 OR Slabs.SlabType=3) then " + vbCrLf
            str += " N'مراحل ساخت قطعه ' + Slabs.SlabId + N'توسط سرپرست بررسی نگردیده است .' + '<br/>' " + vbCrLf
            str += "else '' end " + vbCrLf
            str += ") as SubSlabs_Status"


            str += " ( " + vbCrLf
            str += "case when (dbo.SlabOPC_Sarparast_Flag(Slabs.SlabId) is null) and (Slabs.SlabType = 1 OR Slabs.SlabType=3) then 'False'" + vbCrLf
            str += " when (dbo.SlabOPC_Sarparast_Flag(Slabs.SlabId)='N') and (Slabs.SlabType = 1 OR Slabs.SlabType=3) then 'False' " + vbCrLf
            str += " when (dbo.SlabOPC_Sarparast_Flag(Slabs.SlabId)='O') and (Slabs.SlabType = 1 OR Slabs.SlabType=3) then 'False' " + vbCrLf
            str += "else 'True' end " + vbCrLf
            str += ") as SubSlabs_Flag"


            str += " From Slabs" + vbCrLf
            str += "Slabs.SlabId in (" + Sub_Slabs + ") and slabs.SlabMaxVersion = 'Y' "





            connection.Adapter.SelectCommand.CommandText = str
            connection.Adapter.SelectCommand.CommandType = CommandType.Text


            connection.DataTable = New DataTable("Table")
            connection.Adapter.Fill(connection.DataTable)
            If connection.Connection.State <> ConnectionState.Closed Then connection.Connection.Close()
            Return connection.DataTable

        Catch ex As Exception
            Return Nothing
        Finally
        End Try
    End Function

    Public Function CheckProductTradeCode(ByVal ProductTradeCode As String)
        Try
            Dim connection As New Connection
            If connection.Connection.State <> ConnectionState.Open Then connection.Connection.Open()

            Dim i As Integer = 0
            Dim Param As Object

            connection.Adapter.SelectCommand.Parameters.Clear()
            connection.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            connection.Adapter.SelectCommand.CommandText = "CheckProductTradeCode"

            Dim sqlparams(0) As SqlParameter
            sqlparams(0) = New SqlParameter("@ProductTradeCode", ProductTradeCode)

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
