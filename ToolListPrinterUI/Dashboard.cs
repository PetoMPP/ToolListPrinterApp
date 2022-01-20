using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolListPrinterLibrary.DataProcessing;
using ToolListPrinterLibrary.Models;

namespace ToolListPrinterUI
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void CreateAndOpenFileButton_Click(object sender, EventArgs e)
        {
            // Create model
            // PartModel model = TDMProcessing.CreatePartModel(partNumberTextBox.Text);
            PartModel model = new() { PartName = "Trial", ToolLists = new() { new() { ToolListName = "556451_555", ListPositions = new() { new() { CompId = "55050", Description = "FAA", OrderCode = "070-555" } } } } };
            // Create file
            string filePath = ExcelProcessing.CreateExcelFileFromModel(model);
            // Open file
            ExcelProcessing.OpenFileInExcel(@filePath);
            //Process.Start(filePath);
        }
    }
}
