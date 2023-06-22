using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReport.xaml
    /// </summary>
    public partial class PageReport : System.Windows.Controls.Page
    {
        class SumInMonth //Класс для создания первого отчёта
        {
            public string month { get; set; }
            public double sum { get; set; }
        }

        class CountOfSales //Класс для создания второго отчёта
        {
            public string name { get; set; }
            public int? count { get; set; }
        }

        List<SumInMonth> sumInMonths = new List<SumInMonth>();

        public PageReport()
        {
            InitializeComponent();
            completionSumGrid();
            reportSumGrid.ItemsSource = sumInMonths;
        }

        public void completionSumGrid() //Формирование первого отчёта
        {
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            //Заполнение DataGrid
            for (int i = 0; i < 12; i++)
            {
                SumInMonth sumInMonthTemp = new SumInMonth();
                sumInMonthTemp.month = months[i];
                foreach (OrderList positionOrder in App.DB.OrderList)
                {
                    if (positionOrder.Order.DateOfRegistration.Value.Month == i + 1)
                    {
                        sumInMonthTemp.sum += positionOrder.SumPrice.Value;
                    }
                }

                sumInMonths.Add(sumInMonthTemp);
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e) //Кнопка поиска для формирования второго отчёта
        {

            List<CountOfSales> countOfSales = new List<CountOfSales>();
            foreach (DetailOrService detailOrService in App.DB.DetailOrService)
            {
                CountOfSales temp = new CountOfSales();
                temp.name = detailOrService.Name;
                temp.count = 0;
                foreach(OrderList orderList in App.DB.OrderList)
                {
                    if (startDate.SelectedDate == null || endDate.SelectedDate == null || endDate.SelectedDate.Value <= startDate.SelectedDate.Value)
                    {
                        MessageBox.Show("Введите корректную дату", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if(temp.name == orderList.DetailOrService.Name &&  orderList.Order.DateOfRegistration >= startDate.SelectedDate.Value && orderList.Order.DateOfRegistration <= endDate.SelectedDate.Value)
                    {
                        temp.count += orderList.Amount;
                    }
                }

                countOfSales.Add(temp);
            }

            reportCountGrid.ItemsSource = countOfSales;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e) //Кнопка для экспорта отчётов
        {
            if(reportTab.SelectedIndex == 0)
            {
                sumReportPrint();
            }

            else
            {
                countReportPrint();
            }
        }

        public void sumReportPrint() //Экспорт в эксель первого отчёта
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheetMain = (Excel.Worksheet)workbook.Sheets[1];
            sheetMain.Cells[1, 1] = "Месяц";
            sheetMain.Cells[1, 2] = "Сумма";
            for (int i = 0; i < reportSumGrid.Columns.Count; i++)
            {
                for (int j = 0; j < reportSumGrid.Items.Count; j++)
                {
                    TextBlock b = reportSumGrid.Columns[i].GetCellContent(reportSumGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheetMain.Cells[j + 3, i + 1];
                    if (b != null)
                    {
                        myRange.Value2 = b.Text;

                    }
                    else { break; }
                }
            }
            double sum = 0;
            for (int i = 0; i < 12; i++)
            {
                TextBlock b = reportSumGrid.Columns[1].GetCellContent(reportSumGrid.Items[i]) as TextBlock;
                sum += Convert.ToDouble(b.Text.Substring(0, b.Text.Length - 4));
            }
            sheetMain.Cells[16, 1] = "Общая сумма " + sum + " руб.";
            sheetMain.Columns.AutoFit();
        }

        public void countReportPrint() //Экспорт в эксель второго отчёта
        {
            if (startDate.SelectedDate == null || endDate.SelectedDate == null || endDate.SelectedDate.Value <= startDate.SelectedDate.Value)
            {
                MessageBox.Show("Введите корректную дату", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheetMain = (Excel.Worksheet)workbook.Sheets[1];
            sheetMain.Cells[1, 1] = "Название";
            sheetMain.Cells[1, 2] = "Количество";
            for (int i = 0; i < reportCountGrid.Columns.Count; i++)
            {
                for (int j = 0; j < reportCountGrid.Items.Count; j++)
                {
                    TextBlock b = reportCountGrid.Columns[i].GetCellContent(reportCountGrid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheetMain.Cells[j + 3, i + 1];
                    if (b != null)
                    {
                        myRange.Value2 = b.Text;

                    }
                    else { break; }
                }
            }

            var lastRow = sheetMain.Cells[sheetMain.Rows.Count, 1].End[XlDirection.xlUp].Row;
            var newRow = lastRow + 2;
            sheetMain.Cells[newRow, 1] = "Дата с " + startDate.SelectedDate.Value.ToString() + " по " + endDate.SelectedDate.Value.ToString();
            sheetMain.Columns.AutoFit();
        }
    }
}
