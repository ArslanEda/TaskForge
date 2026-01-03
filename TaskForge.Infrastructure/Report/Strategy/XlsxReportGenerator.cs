using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using TaskForge.Domain.ReportDomain;

namespace TaskForge.Infrastructure.ReportStorage.Strategy
{
    public class XlsxReportGenerator : IReportStrategy
    {
        public string Format => "xlsx";

        public byte[] Generate(IEnumerable<ReportTaskItem> tasks)
        {
            ExcelPackage.License.SetNonCommercialOrganization("TaskForge");

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("TASK FORGE");

            string[] headers = ["NO", "TITLE", "PRIORITY", "CREATED", "COMPLETED"];
            for (int i = 0; i < headers.Length; i++)
            {
                ws.Cells[1, i + 1].Value = headers[i];
            }

            using (var range = ws.Cells[1, 1, 1, headers.Length])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.Lavender);
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            int row = 2;
            int index = 1;
            foreach (var task in tasks)
            {
                ws.Cells[row, 1].Value = index++;
                ws.Cells[row, 2].Value = task.Title;
                ws.Cells[row, 3].Value = task.Priority;
                ws.Cells[row, 4].Value = task.CreatedAt;
                ws.Cells[row, 5].Value = task.IsCompleted ? "Yes" : "No";

                using (var dataRow = ws.Cells[row, 1, row, headers.Length])
                {
                    dataRow.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    dataRow.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                row++;
            }

            ws.Cells.AutoFitColumns();

            return package.GetAsByteArray();
        }
    }
}

