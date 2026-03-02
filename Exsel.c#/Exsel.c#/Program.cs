using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Пример_приложения_чтение_данных_из_Excel_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Application excelApp = new Application();

            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }

            // Путь к файлу на рабочем столе
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "exselLab.xlsx");

            // Проверяем, существует ли файл (дополнение для надежности)
            if (!System.IO.File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден: " + filePath);
                excelApp.Quit();
                return;
            }

            Workbook excelBook = excelApp.Workbooks.Open(filePath);
            Worksheet excelSheet = excelBook.Sheets[1];
            Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;

            for (int i = 1; i <= rows; i++)
            {

                Console.Write("\r\n");
                for (int j = 1; j <= cols; j++)
                {
                    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                        Console.Write(excelRange.Cells[i, j].Value2.ToString() + " \t");
                }
            }

            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            Console.ReadLine();
        }
    }
}