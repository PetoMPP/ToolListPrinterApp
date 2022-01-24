using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolListPrinterLibrary.DataProcessing;
using ToolListPrinterLibrary.Models;

namespace ToolListPrinterUI
{
    public partial class AdvancedMode : Form
    {
        private PartModel _partModel;
        private readonly Form _callingForm;
        public AdvancedMode(Form callingForm)
        {
            _callingForm = callingForm;
            InitializeComponent();
        }

        private void LoadToolListsButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(partNumberTextBox.Text))
            {
                MessageBox.Show("Pole nie może być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PartModel model = TDMProcessing.CreatePartModel(partNumberTextBox.Text);
            if (model.ToolLists.Count == 0)
            {
                MessageBox.Show($"Nie znaleziono list narzędziowych dla programu {model.PartName}!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _partModel = model;
            WireUpCheckedListBox();
        }

        private void WireUpCheckedListBox()
        {
            toolListsListBox.Items.Clear();
            toolListsListBox.Items.AddRange(_partModel.ToolLists.ToArray());
            toolListsListBox.DisplayMember = "DisplayName";
        }

        private void CreateAndOpenFileButton_Click(object sender, EventArgs e)
        {
            string filePath;
            if (toolListsListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show($"Nie wybrano żadnych list do druku!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<ToolListModel> checkedToolLists = new();
            foreach (ToolListModel toolList in toolListsListBox.CheckedItems)
            {
                checkedToolLists.Add(toolList);
            }
            _partModel.ToolLists = checkedToolLists;
            switch (ignoreMissingCheckBox.Checked)
            {
                case true:
                    filePath = ExcelProcessing.CreateExcelFileFromModel(_partModel, ignoreMissing: true);
                    break;
                case false:
                    filePath = ExcelProcessing.CreateExcelFileFromModel(_partModel);
                    break;
            }
            // Open file
            ExcelProcessing.OpenFileInExcel(filePath);
        }

        private void AdvancedMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            _callingForm.Show();
        }
    }
}
