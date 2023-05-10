using ClosedXML.Excel;
using HospitalManagement.Attributes;
using HospitalManagement.Models;
using HospitalManagement.ViewModels.UserControls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace HospitalManagement.Commands.Nurses
{
    public class ExportExcelNurseCommand : BaseCommand
    {
        private readonly NursesViewModel _nursesViewModel;
        public ExportExcelNurseCommand(NursesViewModel nursesViewModel)
        {
            _nursesViewModel = nursesViewModel;
        }
        public override void Execute(object parameter)
        {
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                DefaultExt = ".xlsx",
            };

            if (fileDialog.ShowDialog() == false)
                return;

            DataTable dataTable = new DataTable();

            var type = typeof(NurseModel);
            var properties = type.GetProperties();
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

            foreach (var nurseModel in _nursesViewModel.Values)
            {
                List<object> rowValues = new List<object>();
                foreach (var exportedProperty in exportedProperties)
                {
                    var propertyValue = exportedProperty.GetValue(nurseModel);
                    rowValues.Add(propertyValue);
                }
                dataTable.Rows.Add(rowValues.ToArray());
            }


            XLWorkbook workbook = new XLWorkbook();
            workbook.Worksheets.Add(dataTable,"Data");
            workbook.SaveAs(fileDialog.FileName);

            Process.Start(fileDialog.FileName);
        }
    }
}
