using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TaskForge.Domain.ReportDomain;

namespace TaskForge.Infrastructure.ReportStorage.Strategy
{
    public class PdfReportGenerator : IReportStrategy
    {
        public string Format => "pdf";

        public byte[] Generate(IEnumerable<ReportTaskItem> tasks)
        {

            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Column(col =>
                    {
                        col.Item().Text("TASK FORGE")
                            .SemiBold()
                            .FontSize(18)
                            .FontColor(Colors.BlueGrey.Medium)
                            .AlignCenter();

                        col.Item().PaddingVertical(8);
                    });

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(35);
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(2);
                        });

                        table.Header(header =>
                        {
                            HeaderCell(header.Cell(), "NO");
                            HeaderCell(header.Cell(), "TITLE");
                            HeaderCell(header.Cell(), "PRIORITY");
                            HeaderCell(header.Cell(), "CREATED");
                            HeaderCell(header.Cell(), "COMPLETED");
                        });

                        int index = 1;

                        foreach (var task in tasks)
                        {
                            CellStyle(table.Cell()).Text(index++.ToString());
                            CellStyle(table.Cell()).Text(task.Title);
                            CellStyle(table.Cell()).Text(task.Priority);
                            CellStyle(table.Cell()).Text(task.CreatedAt);
                            CellStyle(table.Cell()).Text(task.IsCompleted ? "Yes" : "No");
                        }

                        void HeaderCell(IContainer container, string text)
                        {
                            HeaderStyle(container).Text(text)
                                .SemiBold()
                                .FontColor(Colors.White);
                        }

                        IContainer HeaderStyle(IContainer container) => container
                            .Background(Colors.BlueGrey.Medium)
                            .Border(0.5f)
                            .Padding(5)
                            .AlignCenter();

                        IContainer CellStyle(IContainer container) => container
                            .Border(0.5f)
                            .Padding(5)
                            .AlignCenter();
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.CurrentPageNumber();
                        });
                });
            });

            return document.GeneratePdf();
        }
    }
}
    

