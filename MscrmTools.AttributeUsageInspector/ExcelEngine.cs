using System;
using System.IO;
using Microsoft.Xrm.Sdk.Metadata;
using OfficeOpenXml;

namespace MscrmTools.AttributeUsageInspector
{
    class ExcelEngine
    {
        private readonly ExcelPackage innerWorkBook;

        public ExcelEngine()
        {
            innerWorkBook = new ExcelPackage();
        }

        public void AddEntity(EntityMetadata emd, DetectionResults data)
        {
            var sheet = AddWorkSheet(emd.DisplayName.UserLocalizedLabel != null ? emd.DisplayName.UserLocalizedLabel.Label : "N/A", emd.LogicalName);

            if (data.Fault != null)
            {
                sheet.Cells[1, 1].Value = data.Fault.Message;

                return;
            }

            int i = 1;
            sheet.Cells[i, 1].Value = "Displayname";
            sheet.Cells[i, 2].Value = "Logical name";
            sheet.Cells[i, 3].Value = "Attribute Type";
            sheet.Cells[i, 4].Value = "On Form(s)";
            sheet.Cells[i, 5].Value = "Data usage";

            foreach (var result in data.Results)
            {
                i++;
                sheet.Cells[i, 1].Value = result.Attribute.DisplayName.UserLocalizedLabel?.Label;
                sheet.Cells[i, 2].Value = result.Attribute.LogicalName;
                sheet.Cells[i, 3].Value = result.Attribute.AttributeType.Value;
                sheet.Cells[i, 4].Value = data.AttributeIsContainedInForms(result.Attribute.LogicalName);
                sheet.Cells[i, 5].Value = result.Percentage;
            }
        }

        /// <summary>
        /// Add a new worksheet
        /// </summary>
        /// <param name="displayName">Name of the worksheet</param>
        /// <param name="logicalName">Logical name of the entity</param>
        /// <returns></returns>
        public ExcelWorksheet AddWorkSheet(string displayName, string logicalName = null)
        {
            string name;

            if (logicalName != null)
            {
                if (logicalName.Length >= 26)
                {
                    name = logicalName;
                }
                else
                {
                    var remainingLength = 31 - 3 - 3 - logicalName.Length;
                    name = string.Format("{0} ({1})",
                        remainingLength == 0
                            ? "..."
                            : (displayName.Length > remainingLength
                                ? displayName.Substring(0, remainingLength)
                                : displayName),
                        logicalName);
                }
            }
            else
                name = displayName;
            name = name
                .Replace(":", " ")
                .Replace("\\", " ")
                .Replace("/", " ")
                .Replace("?", " ")
                .Replace("*", " ")
                .Replace("[", " ")
                .Replace("]", " ");

            if (name.Length > 31)
                name = name.Substring(0, 31);

            ExcelWorksheet sheet = null;
            int i = 1;
            do
            {
                try
                {
                    sheet = innerWorkBook.Workbook.Worksheets.Add(name);
                }
                catch (Exception)
                {
                    name = name.Substring(0, name.Length - 2) + "_" + i;
                    i++;
                }
            } while (sheet == null);

            return sheet;
        }

        public void Save(string path)
        {
            innerWorkBook.SaveAs(new FileInfo(path));
        }
    }
}
