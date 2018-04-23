Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports System.Diagnostics


Namespace DXSample
	Partial Public Class Main
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
			Me.productsTableAdapter.Fill(Me.nwindDataSet.Products)
		End Sub
		Private filePath As String = "Test.xlsx"

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			Export()
		End Sub

		Private Sub Export()
			gridView1.ExportToXlsx(filePath)
			Process.Start(filePath)
		End Sub
	End Class
End Namespace
