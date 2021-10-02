Public Class Slab_Archive
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = "آرشیو قطعات"
            Me.MultiView1.SetActiveView(ArchiveArchive)


        Catch ex As Exception
        End Try

    End Sub
    Private Sub FillDataGrid()
        Try

            Dim table As New Data.DataTable
            Dim slab As New Slabs


            Dim dataType As Integer = 0
            table = slab.SlabSelect(dataType)

            If table.Rows.Count > 0 Then
                Me.DG_Archive.DataSource = table
                DG_Archive.DataBind()
            Else
                '"رکوردی برای نمایش یافت نگردید."
            End If

        Catch ex As Exception
        End Try
    End Sub

End Class
