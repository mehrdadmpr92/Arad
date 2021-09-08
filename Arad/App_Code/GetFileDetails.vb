Imports Microsoft.VisualBasic

Public Class GetFileDetails
    Public Function FileFieldSelected(ByVal FileField As System.Web.UI.HtmlControls.HtmlInputFile) As Boolean
        ' Returns a True if the passed
        ' FileField has had a user post a file
        If FileField.PostedFile Is Nothing Then Return False
        If FileField.PostedFile.ContentLength = 0 Then Return False
        Return True
    End Function
    Public Function GetByteArrayFromFileField(ByVal FileField As System.Web.UI.HtmlControls.HtmlInputFile) As Byte()
        ' Returns a byte array from the passed 
        ' file field controls file
        Dim intFileLength As Integer, bytData() As Byte
        Dim objStream As System.IO.Stream
        If FileFieldSelected(FileField) Then
            intFileLength = FileField.PostedFile.ContentLength
            ReDim bytData(intFileLength)
            objStream = FileField.PostedFile.InputStream
            objStream.Read(bytData, 0, intFileLength)
            Return bytData

        End If

    End Function
    Public Function FileFieldType(ByVal FileField As _
      System.Web.UI.HtmlControls.HtmlInputFile) As String
        ' Returns the type of the posted file
        If Not FileField.PostedFile Is Nothing Then
            If FileField.PostedFile.FileName.IndexOf(".") > 0 Then
                Dim mytype As String() = FileField.PostedFile.FileName.Split(".")
                Return "." + mytype(1)
            Else
                Return FileField.PostedFile.ContentType
            End If

        End If
    End Function
    Public Function FileFieldLength(ByVal FileField As _
      System.Web.UI.HtmlControls.HtmlInputFile) As Integer
        ' Returns the length of the posted file
        If Not FileField.PostedFile Is Nothing Then _
          Return FileField.PostedFile.ContentLength

    End Function
    Public Function FileFieldFilename(ByVal FileField As System.Web.UI.HtmlControls.HtmlInputFile) As String
        ' Returns the core filename of the posted file
        If Not FileField.PostedFile Is Nothing Then _
        Return Replace(FileField.PostedFile.FileName, StrReverse(Mid(StrReverse(FileField.PostedFile.FileName), InStr(1, StrReverse(FileField.PostedFile.FileName), "\"))), "")
    End Function

    Public Function FileFieldTypes(ByVal FileField As _
  System.Web.UI.HtmlControls.HtmlInputFile) As String
        ' Returns the core filename of the posted file
        If Not FileField.PostedFile Is Nothing Then
            Dim filename As String
            filename = Replace(FileField.PostedFile.FileName, StrReverse(Mid(StrReverse(FileField.PostedFile.FileName), InStr(1, StrReverse(FileField.PostedFile.FileName), "\"))), "")
            Return Mid(filename, (filename.Length - 2), 3)
        End If
    End Function
    Public Function GetFilenameForEveryExplorers(ByVal FileField As System.Web.UI.HtmlControls.HtmlInputFile) As String
        Dim indexOfLink As Integer = -1
        Dim fileName1 As String = ""
        If Me.FileFieldSelected(FileField) = True Then
            indexOfLink = FileField.PostedFile.FileName.ToString.LastIndexOf("\")
        Else
            Return fileName1
        End If
        If indexOfLink <> -1 Then
            fileName1 = FileField.PostedFile.FileName.ToString.Remove(0, indexOfLink + 1)
        Else
            fileName1 = FileField.PostedFile.FileName.ToString
        End If
        Return fileName1
    End Function
End Class

