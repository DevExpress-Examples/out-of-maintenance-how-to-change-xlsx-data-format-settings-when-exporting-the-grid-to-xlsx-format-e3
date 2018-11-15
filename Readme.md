<!-- default file list -->
*Files to look at*:

* [CustomEditor.cs](./CS/WindowsApplication3/CustomEditor.cs) (VB: [CustomEditor.vb](./VB/WindowsApplication3/CustomEditor.vb))
* [Main.cs](./CS/WindowsApplication3/Main.cs) (VB: [Main.vb](./VB/WindowsApplication3/Main.vb))
* [Program.cs](./CS/WindowsApplication3/Program.cs) (VB: [Program.vb](./VB/WindowsApplication3/Program.vb))
<!-- default file list end -->
# How to change XLSX data format settings when exporting the Grid to XLSX format


<p><strong>Starting with version 14.2</strong>, we introduced new <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument17733">data-aware</a> export. This export engine is used by default according to the static <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressExportExportSettings_DefaultExportTypetopic">ExportSettings.DefaultExportType</a> property. Various data shaping options that are applied within the grid are retained in output XLS-XLSX documents. Thus, formatting of values that you use in a grid will be correctly reflected in Excel. <br /><br /><strong>For older versions:</strong></p>
<p><br />By default, when exporting data from a grid to the XLSX format, the data is formatted to one of available formats in XLSX. If in Excel two Decimal Places are used for numeric data by default, numeric values with a floating point will be shown with two decimal places regardless of a format set for a corresponding grid column or repository item.</p>
<p>There are two solutions to overcome this shortcoming:</p>
<p><br /> 1. You can export values as text. In this case, your formatting will be preserved. For this, assign <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsRepositoryRepositoryItemTextEdittopic"><u>RepositoryItemTextEdit</u></a> to a column by setting the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridColumnsGridColumn_ColumnEdittopic"><u>GridColumn.ColumnEdit property</u></a> and set the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsRepositoryRepositoryItem_ExportModetopic"><u>RepositoryItemTextEdit.ExportMode property</u></a> to DisplayText. In this case, you can export data as text for specific columns. In addition, you can determine the Export Mode for all data in the grid. For this, pass an <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraPrintingXlsxExportOptionstopic"><u>XlsxExportOptions</u></a> object with the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPrintingXlsExportOptionsBase_TextExportModetopic"><u>XlsxExportOptions.TextExportMode property</u></a> set to Text to the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseBaseView_ExportToXlsxtopic915"><u>GridView.ExportToXlsx method</u></a>. This approach has one disadvantage, though. Since values are exported as text, you will not be able to execute any calculations with them in Excel.</p>
<p>2. You can export data as values and change XLSX data format settings. To do it, create a custom <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsRepositoryRepositoryItemTextEdittopic"><u>RepositoryItemTextEdit</u></a> as shown in the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument4716"><u>Custom Editors</u></a> help article, and override the GetBrick method. In this method, you can set the TextBrick.XlsxFormatString property to a required value. In this case, you will be able to execute any calculations with exported data in Excel.</p>
<p>This example illustrates how to implement the second approach. In this project we have added the XlsxFormatString property to a custom RepositoryItemTextEdit.</p>

<br/>


