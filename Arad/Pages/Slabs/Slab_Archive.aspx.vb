Public Class Slab_Archive
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = "آرشیو قطعات"
            Me.MultiView1.SetActiveView(ArchiveArchive)
            FillDataGrid()

        Catch ex As Exception
        End Try

    End Sub
    Private Sub FillDataGrid()
        Try
            Dim table As New Data.DataTable
            Dim slab As New Slabs
            Dim dataType As Integer = 0
            table = slab.SlabsSelectByType(dataType)

            If table.Rows.Count > 0 Then
                Me.DG_Archive.DataSource = table
                DG_Archive.DataBind()
            Else
                '"رکوردی برای نمایش یافت نگردید."
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Search_Btn_Click(sender As Object, e As EventArgs)
        FillSearchDataGrid()
    End Sub

    Private Sub FillSearchDataGrid()
        Try
            Dim table As New Data.DataTable
            Dim slab As New Slabs

            Dim slabType As Decimal = 0
            If SlabType_Chk.Checked = False Then
                slabType = 0
            Else
                slabType = SlabType_RBtn.SelectedValue
            End If


            Dim slabId As Decimal = 0
            If SlabId_Chk.Checked = False Then
                slabId = 0
            Else
                slabId = SlabId_Txt.Text
            End If


            table = slab.SlabsSelectBySearch(slabType, slabId)
            If table.Rows.Count > 0 Then
                Me.DG_Archive.DataSource = table
                DG_Archive.DataBind()
            Else
                Me.Message.ErrMessages(Arad.Message.MessageType.Warning) = "قطعه ای برای نمایش یافت نگردید."
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class
