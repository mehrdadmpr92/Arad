'Imports System
'Imports System.Web
'Imports System.Drawing
'Imports System.Drawing.Imaging
'Imports System.Collections.Generic
'Imports System.IO

'Partial Class FileUpload

'    Dim files As New GetFiledetails

'    Public ReadOnly Property fileselect() As String
'        Get

'            Return files.FileFieldSelected(File1)
'        End Get
'    End Property
'    Public ReadOnly Property filename() As String
'        Get
'            Return IIf(files.GetFilenameForEveryExplorers(File1).LastIndexOf(".") = -1, files.GetFilenameForEveryExplorers(File1),
'            Mid(files.GetFilenameForEveryExplorers(File1), 1, files.GetFilenameForEveryExplorers(File1).LastIndexOf(".")))
'        End Get
'    End Property
'    Public ReadOnly Property fileLength() As Integer
'        Get
'            Return files.FileFieldLength(File1)
'        End Get
'    End Property
'    Public ReadOnly Property fileByte() As Byte()
'        Get
'            Return files.GetByteArrayFromFileField(File1)
'        End Get
'    End Property
'    Public ReadOnly Property filetype() As String
'        Get
'            Return files.FileFieldType(File1)
'        End Get
'    End Property
'    Public Property RequiredFieldValidatorValidationGroup() As String
'        Get
'            Return RequiredFieldValidator1.ValidationGroup
'        End Get
'        Set(ByVal value As String)
'            RegularExpressionValidator1.ValidationGroup = value
'            RequiredFieldValidator1.ValidationGroup = value
'        End Set

'    End Property
'    Public Property RegularExpressionValidator1ValidationGroup() As String
'        Get
'            Return RegularExpressionValidator1.ValidationGroup
'        End Get
'        Set(ByVal value As String)
'            RegularExpressionValidator1.ValidationGroup = value

'        End Set

'    End Property
'    Public Property validateVisible() As String
'        Get
'            Return RequiredFieldValidator1.Visible
'        End Get
'        Set(ByVal value As String)
'            RequiredFieldValidator1.Visible = value
'        End Set

'    End Property

'    Public Property ValidationExpression()
'        Get
'            Return RegularExpressionValidator1.ValidationExpression
'        End Get
'        Set(ByVal value)
'            RegularExpressionValidator1.ValidationExpression = value
'        End Set

'    End Property

'    Public Property ValidationErrorMessage() As String
'        Get
'            Return RegularExpressionValidator1.ErrorMessage
'        End Get
'        Set(ByVal value As String)
'            RegularExpressionValidator1.ErrorMessage = value
'        End Set

'    End Property





'    'Public Shared ImageFormats As SortedDictionary(Of Guid, Object)

'    Shared Sub New()
'        'ImageFormats = New SortedDictionary(Of Guid, Object)
'        'ImageFormats.Add(ImageFormat.Bmp.Guid, "pdf")
'        'ImageFormats.Add(ImageFormat.Emf.Guid, "doc")
'        'ImageFormats.Add(ImageFormat.Exif.Guid, "docx")
'        'ImageFormats.Add(ImageFormat.Gif.Guid, "zip")
'        'ImageFormats.Add(ImageFormat.Jpeg.Guid, "rar")
'        'ImageFormats.Add(ImageFormat.Png.Guid, "")
'        'ImageFormats.Add(ImageFormat.Tiff.Guid, "image/tiff")
'        'ImageFormats.Add(ImageFormat.Wmf.Guid, "image/wmf")

'    End Sub

'    Public ReadOnly Property File() As HtmlInputFile
'        Get
'            Return File1
'        End Get
'    End Property

Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

End Sub

'    Protected Sub Lbtn_Upload_Movaggat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lbtn_Upload_Movaggat.Click
'        Dim names As String = Server.MapPath(".\Temp\") + "..\..\..\Slab_Files\" & Date.Now.Hour.ToString + "_" + filename + ".pdf"
'        If fileselect Then
'            File1.PostedFile.SaveAs(names)
'            System.IO.File.Open(names, FileMode.Open, FileAccess.Read)
'        End If

'        Response.Redirect("..\..\Slab_Files\" & Date.Now.Hour.ToString + "_" + filename + ".pdf")
'        'Dim client As New Net.WebClient
'        'Dim muri As New Uri("http://your_url")
'        'Dim destPath = Server.MapPath(names)
'        'client.DownloadFile(muri, destPath)
'        'HyperLink1.Visible = True
'        'HyperLink1.NavigateUrl = "names"
'        'HyperLink1.Text = "Open"
'    End Sub

'End Class