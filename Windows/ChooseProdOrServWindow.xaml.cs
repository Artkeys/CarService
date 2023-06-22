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
using System.Windows.Shapes;

namespace CarService.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChooseProdOrServWindow.xaml
    /// </summary>
    public partial class ChooseProdOrServWindow : Window
    {
        public int idDetailOrService;
        public string nameProduct;
        public string priceProduct;
        public string availability;
        public string detailOrService;
        public ChooseProdOrServWindow()
        {
            InitializeComponent();
            productListView.ItemsSource = App.DB.DetailOrService.Where(x => x.Amount > 0).ToList();
        }

        private void ChooseBtn_Click(object sender, RoutedEventArgs e) //Нажатие кнопки выбора
        {
            DetailOrService chooseProd = (sender as Button).DataContext as DetailOrService;
            idDetailOrService = chooseProd.IdDetailOrService;
            nameProduct = chooseProd.Name.ToString();
            priceProduct = chooseProd.Price.ToString();
            availability = chooseProd.Amount.ToString();
            detailOrService = chooseProd.TypeProduct.ToString();
            this.Close();
        }

        public int retIdDetail() //Возврат id
        {
            return idDetailOrService;
        }
        public string retNameProd() //Возврат названия
        {
            return nameProduct;
        }
        public string retPrice() //Возврат цены
        {
            return priceProduct;
        }
        public string retAvailability() //Возврат наличия
        {
            return availability;
        }

        public string retDetail() //Возврат детали
        {
            return detailOrService;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) //Передвижение окна с помощью левой кнопки мыши
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Закрытие окна
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) //Сворачивание окна
        {
            this.WindowState = WindowState.Minimized;
        }

        private void searchTxt_TextChanged(object sender, TextChangedEventArgs e) //Поиск деталей или услуг
        {
            productListView.ItemsSource = App.DB.DetailOrService.Where(x => x.Amount > 0 && x.Name.StartsWith(searchTxt.Text)).ToList();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e) //Кнопка сброса
        {
            productListView.ItemsSource = App.DB.DetailOrService.Where(x => x.Amount > 0).ToList();
            searchTxt.Text = "";
        }
    }
}
