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
            if (string.IsNullOrWhiteSpace(partNumberTextBox.Text))
            {
                MessageBox.Show("Pole nie może być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PartModel model = TDMProcessing.CreatePartModel(partNumberTextBox.Text);
            // Create file
            if (model.ToolLists.Count == 0)
            {
                MessageBox.Show($"Nie znaleziono list narzędziowych dla programu {model.PartName}!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string filePath;
            switch (ignoreMissingCheckBox.Checked)
            {
                case true:
                    filePath = ExcelProcessing.CreateExcelFileFromModel(model, ignoreMissing: true);
                    break;
                case false:
                    filePath = ExcelProcessing.CreateExcelFileFromModel(model);
                    break;
            }
            // Open file
            ExcelProcessing.OpenFileInExcel(filePath);
        }

        private void AdvancedModeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AdvancedMode(this).Show();
            Hide();
        }
    }
}
