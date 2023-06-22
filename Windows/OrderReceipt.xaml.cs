using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarService.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderReceipt.xaml
    /// </summary>
    public partial class OrderReceipt : Window
    {
        public OrderReceipt(int id)
        {
            InitializeComponent();
           DataContext = App.DB.Order.Where(x => x.IdOrder == id).ToList();
           orderlistListView.ItemsSource = App.DB.OrderList.Where(x => x.IdOrder == id).ToList();
            sumTb.Text = App.DB.OrderList.Where(x => x.IdOrder == id).Sum(x => x.SumPrice).ToString() + " руб.";
        }

        private void printBtn_Click(object sender, RoutedEventArgs e) //Печать чека
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
                MessageBox.Show("Распечатка прошла успешно!");
                this.Close();
            }
        }
    }
}
