Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports System.Reflection
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports DevExpress.XtraPrinting

Namespace DXSample
	<UserRepositoryItem("RegisterCustomEdit")> _
	Public Class RepositoryItemCustomEdit
		Inherits RepositoryItemTextEdit

		Shared Sub New()
			RegisterCustomEdit()
		End Sub

		Public Sub New()
		End Sub

		Public Const CustomEditName As String = "CustomEdit"

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return CustomEditName
			End Get
		End Property

		Public Shared Sub RegisterCustomEdit()
			Dim img As Image = Nothing
			Try
				img = CType(Bitmap.FromStream(System.Reflection.Assembly.GetExecutingAssembly(). GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp")), Bitmap)
			Catch
			End Try
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(CustomEdit), GetType(RepositoryItemCustomEdit), GetType(TextEditViewInfo), New TextEditPainter(), True, img))
		End Sub

		Private xlsxFormatString_Renamed As String

		Public Property XlsxFormatString() As String
			Get
				Return xlsxFormatString_Renamed
			End Get
			Set(ByVal value As String)
				If xlsxFormatString_Renamed <> value Then
					xlsxFormatString_Renamed = value
					OnPropertiesChanged()
				End If
			End Set
		End Property

		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			BeginUpdate()
			Try
				MyBase.Assign(item)
				Dim source As RepositoryItemCustomEdit = TryCast(item, RepositoryItemCustomEdit)
				If source Is Nothing Then
					Return
				End If
				XlsxFormatString = source.XlsxFormatString
			Finally
				EndUpdate()
			End Try
		End Sub

		Public Overrides Function GetBrick(ByVal info As PrintCellHelperInfo) As VisualBrick
			Dim brick As TextBrick = TryCast(MyBase.GetBrick(info), TextBrick)
			brick.XlsxFormatString = XlsxFormatString
			Return brick
		End Function
	End Class


	Public Class CustomEdit
		Inherits TextEdit

		Shared Sub New()
			RepositoryItemCustomEdit.RegisterCustomEdit()
		End Sub

		Public Sub New()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemCustomEdit.CustomEditName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemCustomEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemCustomEdit)
			End Get
		End Property

	End Class
End Namespace


