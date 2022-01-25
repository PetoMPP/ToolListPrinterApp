using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolListPrinterLibrary.Models;

namespace ToolListPrinterLibrary.DataProcessing
{
    public class ExcelProcessing
    {
        private const int MaxA4PageHeight = 750;
        private const int MaxA4PageWidth = 85;
        private const int TitleFontSize = 16;
        private static readonly Color TitleFontColor = Color.White;
        private static readonly Color TitleBackgroundColor = Color.FromArgb(1, 112, 184);
        private const int TitleRowHeight = 21;
        private const int SubTitleFontSize = 14;
        private static readonly Color SubTitleFontColor = Color.FromArgb(1, 112, 184);
        private static readonly Color SubTitleBackgroundColor = Color.Transparent;
        private const int SubTitleRowHeight = 19;
        private const int RegularFontSize = 11;
        private static readonly Color RegularFontColor = Color.Black;
        private static readonly Color RegularBackgroundColor = Color.Transparent;
        private static readonly Color MissingBackgroundColor = Color.Yellow;
        private const int RegularRowHeight = 15;

        public static void ActivateLicense() => ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        public static string CreateExcelFileFromModel(PartModel model, bool ignoreMissing = false)
        {
            // counters
            int currRow = 1;
            int currSheet = 1;
            // filepath
            string filePath = GetFilePath(model);
            // count needed worksheets 
            List<WorksheetModel> requiredWorksheets = CalculateRequiredWorksheets(model);
            // create workbook
            ExcelPackage package = new();
            foreach (WorksheetModel worksheetModel in requiredWorksheets)
            {
                worksheetModel.Name = $"Arkusz {currSheet}";
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetModel.Name);
                // Add header
                using (ExcelRange range = worksheet.Cells[currRow, 1, currRow, 2])
                {
                    AddTitleCells(model, range);
                }
                currRow++;
                using (ExcelRange range = worksheet.Cells[currRow, 1, currRow + 1, 1])
                {
                    AddExplicationKeyCell(range);
                }
                using (ExcelRange range = worksheet.Cells[currRow, 2])
                {
                    AddMissingToolKeyCell(range);
                }
                currRow++;
                using (ExcelRange range = worksheet.Cells[currRow, 2])
                {
                    AddPresentToolKeyCell(range);
                }
                currRow++;
                foreach (ToolListModel list in worksheetModel.ToolLists)
                {
                    // add subtitle
                    using (ExcelRange range = worksheet.Cells[currRow, 1, currRow, 2])
                    {
                        AddSubTitleCells(list, range);
                    }
                    currRow++;
                    switch (ignoreMissing)
                    {
                        case true:
                            foreach (ListPositionModel position in list.ListPositions)
                            {
                                AddPositionCell(currRow, worksheet, position);
                                currRow++;
                            }
                            break;
                        case false:
                            foreach (ListPositionModel position in list.ListPositions)
                            {
                                AddPositionCell(currRow, worksheet, position);
                                MarkMissingPositions(currRow, worksheet, position);
                                currRow++;
                            }
                            break;
                    }
                }
                // apply styles to whole sheet
                using (ExcelRange range = worksheet.Cells[1, 1, currRow, 2])
                {
                    ApplyGlobalStyles(range);
                }
                // border applying
                for (int i = 1; i < currRow; i++)
                {
                    for (int j = 1; j <= 2; j++)
                    {
                        ExcelRange range = worksheet.Cells[i, j];
                        range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin, Color.Black);
                    }
                }
                double totalWidth = 0;
                for (int i = 1; i <= 2; i++)
                {
                    totalWidth += worksheet.Columns[i].Width;
                }
                if (totalWidth >= MaxA4PageWidth)
                {
                    double widthDiff = totalWidth - MaxA4PageWidth;
                    worksheet.Columns[2].Width -= widthDiff;
                }
                else
                {
                    double widthDiff = MaxA4PageWidth - totalWidth;
                    worksheet.Columns[2].Width += widthDiff;
                }
                currRow = 1;
                currSheet++;
            }
            // save file
            FileInfo fileInfo = new(filePath);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }
            package.SaveAs(new FileInfo(filePath));
            return filePath;
        }

        private static void MarkMissingPositions(int currRow, ExcelWorksheet worksheet, ListPositionModel position)
        {
            if (!position.IsPresent)
            {
                using ExcelRange range = worksheet.Cells[currRow, 1, currRow, 2];
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(MissingBackgroundColor);
            }
        }

        private static void AddPositionCell(int currRow, ExcelWorksheet worksheet, ListPositionModel position)
        {
            using (ExcelRange range = worksheet.Cells[currRow, 1])
            {
                AddRegularNameCell(position, range);
            }
            using (ExcelRange range = worksheet.Cells[currRow, 2])
            {
                AddRegularDescriptionCell(position, range);
            }
        }

        private static void AddPresentToolKeyCell(ExcelRange range)
        {
            range.Merge = true;
            range.Value = "Narzędzia w maszynie";
            // Apply header styles
            range.Style.Font.Name = "Calibri";
            range.Style.Font.Size = RegularFontSize;
            range.Style.Font.Color.SetColor(RegularFontColor);
            range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(RegularBackgroundColor);
        }

        private static void AddMissingToolKeyCell(ExcelRange range)
        {
            range.Value = "Narzędzia w skrzyni";
            // Apply header styles
            range.Style.Font.Name = "Calibri";
            range.Style.Font.Size = RegularFontSize;
            range.Style.Font.Color.SetColor(RegularFontColor);
            range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(MissingBackgroundColor);
        }

        private static void AddExplicationKeyCell(ExcelRange range)
        {
            range.Value = "Legenda:";
            // Apply header styles
            range.Merge = true;
            range.Style.Font.Name = "Calibri";
            range.Style.Font.Size = RegularFontSize;
            range.Style.Font.Color.SetColor(RegularFontColor);
            range.Style.Font.Bold = true;
            range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(RegularBackgroundColor);
        }

        private static void ApplyGlobalStyles(ExcelRange range) => range.AutoFitColumns();

        private static void AddRegularCell(string value, ExcelRange range)
        {
            range.Value = value;
            // Apply header styles
            range.Style.Font.Name = "Calibri";
            range.Style.Font.Size = RegularFontSize;
            range.Style.Font.Color.SetColor(RegularFontColor);
            range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(RegularBackgroundColor);
        }

        private static void AddRegularOrderCodeCell(ListPositionModel position, ExcelRange range) => AddRegularCell(position.OrderCode, range);

        private static void AddRegularDescriptionCell(ListPositionModel position, ExcelRange range) => AddRegularCell(position.Description, range);

        private static void AddRegularNameCell(ListPositionModel position, ExcelRange range) => AddRegularCell(position.Name, range);

        private static void AddSubTitleCells(ToolListModel list, ExcelRange range)
        {
            range.Merge = true;
            range.Value = "Mocowanie " + list.Clamping + $" - {list.MachineName}";
            // Apply header styles
            range.Style.Font.Name = "Calibri";
            range.Style.Font.Size = SubTitleFontSize;
            range.Style.Font.Color.SetColor(SubTitleFontColor);
            range.Style.Font.Bold = true;
            range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(SubTitleBackgroundColor);
        }

        private static void AddTitleCells(PartModel model, ExcelRange range)
        {
            range.Merge = true;
            range.Value = "Lista narzędzi do zlecenia " + model.PartName;
            // Apply header styles
            range.Style.Font.Name = "Calibri";
            range.Style.Font.Size = TitleFontSize;
            range.Style.Font.Color.SetColor(TitleFontColor);
            range.Style.Font.Bold = true;
            range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(TitleBackgroundColor);
        }

        private static List<WorksheetModel> CalculateRequiredWorksheets(PartModel model)
        {
            List<WorksheetModel> requiredWorksheets = new() { new() { ToolLists = new() } };
            int currHeight = TitleRowHeight + (2 * RegularRowHeight);
            // calculate height of each clamping
            foreach (ToolListModel list in model.ToolLists)
            {
                int contentHeight = SubTitleRowHeight + (list.ListPositions.Count * RegularRowHeight);
                currHeight += contentHeight;
                if (currHeight <= MaxA4PageHeight)
                {
                    requiredWorksheets.Last().ToolLists.Add(list);
                }
                else
                {
                    currHeight = TitleRowHeight + contentHeight;
                    requiredWorksheets.Add(new() { ToolLists = new() { list } });
                }
            }
            return requiredWorksheets;
        }

        private static string GetFilePath(PartModel model)
        {
            string path = ConfigurationManager.AppSettings["OutputFolder"];
            if (!path.EndsWith('\\'))
            {
                path += '\\';
            }
            return path + $"{model.PartName}-" + DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + ".xslx";
        }
        public static void OpenFileInExcel(string filePath)
        {
            Application excel = new();
            Workbook workbook = excel.Workbooks.Open(filePath);
            workbook.Worksheets.Select();
            excel.Visible = true;
        }
    }
}
