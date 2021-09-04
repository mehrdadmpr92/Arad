

Public Class Slab_Insert_Assembly
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = "ثبت قطعه اسمبلی"
            Me.MultiView1.SetActiveView(ViewEdit)
            FillDataGrid()

            FillDataGrid()
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub Submit_Btn_Click(sender As Object, e As EventArgs)
        Try
            Dim slab As New Slabs
            Dim err As String = slab.Slab_Assembly_Insert(SlabId_Txt.Text, PerSlabName_Txt.Text,
                                                      SlabName_Txt.Text, SlabDesc_Txt.Text)

            If err = 0 Then
                SlabId_Txt.Text = ""
                PerSlabName_Txt.Text = ""
                SlabName_Txt.Text = ""
                SlabDesc_Txt.Text = ""


                FillDataGrid()
                Me.MultiView1.SetActiveView(AssemblyArchive)

            Else
            End If


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

    Protected Sub Return_Btn_Click(sender As Object, e As EventArgs)
        Me.MultiView1.SetActiveView(AssemblySubmit)
    End Sub

    Protected Sub LbtEdit_Click_Click(sender As Object, e As EventArgs)
        Try
            Dim lbt As New LinkButton
            lbt = sender
            Me.ViewState("EditSlabId") = lbt.CommandArgument

            Dim slabId As Decimal = lbt.CommandArgument
            Me.MultiView1.SetActiveView(ViewEdit)

            Dim slab As New Slabs
            Dim table As New Data.DataTable

            table = slab.SlabSelect_BySlabId(slabId)
            If table.Rows.Count = 1 Then
                SlabIdEdit_Txt.Text = slabId
                SlabNameEdit_Txt.Text = table.Rows(0).Item("SlabNameEng").ToString
                PerSlabNameEdit_Txt.Text = table.Rows(0).Item("SlabName").ToString
                SlabDescEdit_Txt.Text = table.Rows(0).Item("Description").ToString
            Else
                'درخواست شما با مشکل مواجه شد
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Edit_Btn_Click(sender As Object, e As EventArgs)
        Try
            Dim slab As New Slabs
            Dim err As String = slab.Slab_Assembly_Update(Me.ViewState("EditSlabId"), PerSlabNameEdit_Txt.Text,
                                                      SlabNameEdit_Txt.Text, SlabDescEdit_Txt.Text)

            If err = 0 Then
                SlabIdEdit_Txt.Text = ""
                PerSlabNameEdit_Txt.Text = ""
                SlabNameEdit_Txt.Text = ""
                SlabDescEdit_Txt.Text = ""
                Me.ViewState("EditSlabId") = ""

                FillDataGrid()
                Me.MultiView1.SetActiveView(AssemblyArchive)

            Else
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Delete_Btn_Click(sender As Object, e As EventArgs)
        Try
            Dim btn As New LinkButton
            btn = sender
            Me.ViewState("Delete_SlabId") = btn.CommandArgument

            Dim slab As New Slabs
            Dim err As String = slab.Slab_Assembly_Delete(Me.ViewState("Delete_SlabId"))

            If err = 0 Then
                Me.ViewState("Delete_SlabId") = ""
                FillDataGrid()
                Me.MultiView1.SetActiveView(AssemblyArchive)

            Else
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

