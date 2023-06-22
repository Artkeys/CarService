using CarService.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProducts.xaml
    /// </summary>
    public partial class PageProducts : Page
    {
        public PageProducts()
        {
            InitializeComponent();
            productListView.ItemsSource = App.DB.DetailOrService.ToList();
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e) //Добавление товара или услуги
        {
            AddEditProductWindow addEditProductWindow = new AddEditProductWindow(null);
            addEditProductWindow.Title = "Добавление продукта";
            addEditProductWindow.TitleTb.Text = "Добавление продукта";
            App.mainWindow.Visibility = Visibility.Hidden;
            addEditProductWindow.ShowDialog();
            App.mainWindow.Visibility = Visibility.Visible;
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            productListView.ItemsSource = App.DB.DetailOrService.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e) //Редактирование товара или услуги
        {
            AddEditProductWindow addEditProductWindow = new AddEditProductWindow((sender as Button).DataContext as DetailOrService);
            addEditProductWindow.Title = "Редактирование продукта";
            addEditProductWindow.TitleTb.Text = "Редактирование продукта";
            App.mainWindow.Visibility = Visibility.Hidden;
            addEditProductWindow.ShowDialog();
            App.mainWindow.Visibility = Visibility.Visible;
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            productListView.ItemsSource = App.DB.DetailOrService.ToList();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e) //Удаление товара или услуги
        {
            DetailOrService detailOrServiceForRemoving = (sender as Button).DataContext as DetailOrService;
            if (MessageBox.Show($"Вы точно хотите удалить деталь или услугу с названием: {detailOrServiceForRemoving.Name}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.DB.DetailOrService.Remove(detailOrServiceForRemoving);
                    App.DB.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    productListView.ItemsSource = App.DB.DetailOrService.ToList();
                    File.Delete($"{detailOrServiceForRemoving.pathImageProducts}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Имеются связанные таблицы", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void AvailabilityCheckBox_Checked(object sender, RoutedEventArgs e) //Проверка включенного чекбокса
        {
            productListView.ItemsSource = App.DB.DetailOrService.Where(x => x.Amount > 0 && x.Name.StartsWith(searchTxt.Text)).ToList();
        }

        private void AvailabilityCheckBox_Unchecked(object sender, RoutedEventArgs e) //Проверка выключенного чекбокса
        {
            productListView.ItemsSource = App.DB.DetailOrService.Where(x => x.Name.StartsWith(searchTxt.Text)).ToList();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e) //Сброс поиска
        {
            productListView.ItemsSource = App.DB.DetailOrService.ToList();
            searchTxt.Text = "";
            AvailabilityCheckBox.IsChecked = false;
        }

        private void searchTxt_TextChanged(object sender, TextChangedEventArgs e) //Поиск деталей или услуг
        {
            if (AvailabilityCheckBox.IsChecked == true)
            {
                productListView.ItemsSource = App.DB.DetailOrService.Where(x => x.Amount > 0 && x.Name.StartsWith(searchTxt.Text)).ToList();
            }

            else
            {
                productListView.ItemsSource = App.DB.DetailOrService.Where(x => x.Name.StartsWith(searchTxt.Text)).ToList();
            }
        }

        private void addAmountBtn_Click(object sender, RoutedEventArgs e) //Добавление количества деталей
        {
            addAmountProduct addAmountProduct = new addAmountProduct((sender as Button).DataContext as DetailOrService);
            addAmountProduct.ShowDialog();
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            productListView.ItemsSource = App.DB.DetailOrService.ToList();
        }
    }
}
