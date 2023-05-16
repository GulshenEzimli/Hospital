using ClosedXML.Excel;
using HospitalManagement.Attributes;
using HospitalManagement.Models;
using HospitalManagement.ViewModels.UserControls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Procedures
{
    public class ExportExcelProcedureCommand : BaseCommand
    {
        private readonly ProceduresViewModel _procedureViewModel;

        public ExportExcelProcedureCommand(ProceduresViewModel procedureViewModel)
        {
            _procedureViewModel = procedureViewModel;
        }

        public override void Execute(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                DefaultExt = ".xlsx"
            };

            if (saveFileDialog.ShowDialog() == false)
                return;

            var modelType = typeof(ProcedureModel);
            var properties = modelType.GetProperties();
            var dataTable = new DataTable();
            var exportedProperties = new List<PropertyInfo>();

            foreach (var property in properties)
            {
                Attribute attribute = property.GetCustomAttribute(typeof(ExcelIgnoreAttribute));

                if (attribute != null)
                    continue;

                exportedProperties.Add(property);
            }

            foreach (var exportedProperty in exportedProperties)
            {
                ExcelColumnAttribute attribute = exportedProperty.GetCustomAttribute<ExcelColumnAttribute>();

                if (attribute != null)
                {
                    dataTable.Columns.Add(attribute.Name);
                }
                else
                {
                    dataTable.Columns.Add(exportedProperty.Name);
                }
            }

            foreach (var model in _procedureViewModel.Values)
            {
                List<object> rowValues = new List<object>();

                foreach (var property in exportedProperties)
                {
                    var propertyValue = property.GetValue(model);
                    rowValues.Add(propertyValue);
                }

                dataTable.Rows.Add(rowValues.ToArray());
            }

            var workbook = new XLWorkbook();

            workbook.Worksheets.Add(dataTable, "Data");

            workbook.SaveAs(saveFileDialog.FileName);

            Process.Start(saveFileDialog.FileName);
        }
    }
}
