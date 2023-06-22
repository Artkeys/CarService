using CarService.Windows;
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

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageClients.xaml
    /// </summary>
    public partial class PageClients : Page
    {
        bool sorting = false;
        public PageClients()
        {
            InitializeComponent();
            clientsListView.ItemsSource = App.DB.Client.ToList();
        }

        private void searchTxt_TextChanged(object sender, TextChangedEventArgs e) //Поиск по фамилии или телефону
        {
            clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).ToList();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e) //Кнопка сброса
        {
            clientsListView.ItemsSource = App.DB.Client.ToList();
            searchTxt.Text = "";
        }

        private void FIOTb_PreviewMouseDown(object sender, MouseButtonEventArgs e) //Сортировка по ФИО
        {
            if (sorting == false)
            {
                clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).OrderBy(x => x.Surname).ToList();
                sorting = true;
            }

            else
            {
                clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).OrderByDescending(x => x.Surname).ToList();
                sorting = false;
            }   
        }

        private void dateTb_PreviewMouseDown(object sender, MouseButtonEventArgs e) //Сортировка по Дате рождения
        {
            if (sorting == false)
            {
                clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).OrderBy(x => x.DateOfBirth).ToList();
                sorting = true;
            }

            else
            {
                clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).OrderByDescending(x => x.DateOfBirth).ToList();
                sorting = false;
            }
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e) //Кнопка добавления клиента
        {
            Windows.AddEditClientWindows addClientWindow = new Windows.AddEditClientWindows(null);
            addClientWindow.Title = "Добавление клиента";
            App.mainWindow.Visibility = Visibility.Hidden;
            addClientWindow.ShowDialog();
            App.mainWindow.Visibility = Visibility.Visible;
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            clientsListView.ItemsSource = App.DB.Client.ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e) //Кнопка редактирования клиента и просмотра авто
        {
            AutoAndEditClientWindow autoAndEditClientWindow = new AutoAndEditClientWindow((sender as Button).DataContext as Client);
            autoAndEditClientWindow.Title = "Редактирование и авто клиента";
            App.mainWindow.Visibility = Visibility.Hidden;
            autoAndEditClientWindow.ShowDialog();
            App.mainWindow.Visibility = Visibility.Visible;
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            clientsListView.ItemsSource =App.DB.Client.ToList();
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e) //Кнопка удаления клиента
        {
            Client clientForRemoving = (sender as Button).DataContext as Client;
            if ((MessageBox.Show($"Вы действительно хотите удалить клиента: {clientForRemoving.Surname} {clientForRemoving.Name} {clientForRemoving.Patronymic}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes))
            {
                try
                {
                    App.DB.Client.Remove(clientForRemoving);
                    App.DB.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    clientsListView.ItemsSource = App.DB.Client.ToList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Имеются связанные таблицы","Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
