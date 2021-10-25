Public Class DateSelector

    Function today_Date_Fa()
        Try
            Dim persiancalendar As New System.Globalization.PersianCalendar

            Dim today_date As String
            today_date = persiancalendar.GetYear(Date.Now).ToString + "/" + IIf(persiancalendar.GetMonth(Date.Now).ToString.Length = 1, "0" + persiancalendar.GetMonth(Date.Now).ToString, persiancalendar.GetMonth(Date.Now).ToString) + "/" + IIf(persiancalendar.GetDayOfMonth(Date.Now).ToString.Length = 1, "0" + persiancalendar.GetDayOfMonth(Date.Now).ToString, persiancalendar.GetDayOfMonth(Date.Now).ToString)

            Return today_date

        Catch ex As Exception

        End Try
    End Function

End Class
