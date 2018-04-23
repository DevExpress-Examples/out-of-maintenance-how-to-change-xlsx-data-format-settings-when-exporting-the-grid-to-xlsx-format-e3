using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;


namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.nwindDataSet.Products);
        }
        string filePath = "Test.xlsx";

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void Export()
        {
            gridView1.ExportToXlsx(filePath);
            Process.Start(filePath);
        }
    }
}
