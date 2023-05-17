Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports System.Diagnostics

Namespace DXSample

    Public Partial Class Main
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
            productsTableAdapter.Fill(nwindDataSet.Products)
        End Sub

        Private filePath As String = "Test.xlsx"

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Export()
        End Sub

        Private Sub Export()
            gridView1.ExportToXlsx(filePath)
            Call Process.Start(filePath)
        End Sub
    End Class
End Namespace
