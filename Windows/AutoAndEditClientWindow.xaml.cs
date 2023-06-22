using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для AutoAndEditClientWindow.xaml
    /// </summary>
    public partial class AutoAndEditClientWindow : Window
    {
        int idClient;
        bool sorting = false;
        public AutoAndEditClientWindow(Client selectedClient)
        {
            InitializeComponent();
            DataContext = selectedClient;
            idClient = selectedClient.IdClient;
            autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == selectedClient.IdClient).ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e) //Сохранения информации о клиенте
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(surnameTxt.Text))
                errors.AppendLine("Введите фамилию клиента");

            if (string.IsNullOrWhiteSpace(nameTxt.Text))
                errors.AppendLine("Введи имя клиента");

            if (string.IsNullOrWhiteSpace(patronymicTxt.Text))
                errors.AppendLine("Введи отчество клиента");

            if (dateOfBirth.SelectedDate.Value == null)
                errors.AppendLine("Выберите дату рождения клиента");

            if (string.IsNullOrWhiteSpace(telephoneTxt.Text))
                errors.AppendLine("Введите номер телефона клиента");

            if (errors.Length > 0)                            //Проверка на пустоту всех полей
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                App.DB.SaveChanges();
                MessageBox.Show("Информация сохранена", "Успешно!");
            }

            catch { }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) //Кнопка отмены
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Кнопка закрытия формы
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) //Кнопка сворачивания
        {
            WindowState = WindowState.Minimized;
        }

        private void AddAutoBtn_Click(object sender, RoutedEventArgs e) //Добавление автомобиля
        {
            AddEditAutoWindow addEditAutoWindow = new AddEditAutoWindow(null, DataContext as Client);
            addEditAutoWindow.Title = "Добавление авто";
            addEditAutoWindow.TitleTb.Text = "Добавление авто";
            addEditAutoWindow.ShowDialog();
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient).ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e) //Редактирование автомобиля
        {
            AddEditAutoWindow addEditAutoWindow = new AddEditAutoWindow((sender as Button).DataContext as Auto, DataContext as Client);
            addEditAutoWindow.Title = "Редактирование авто";
            addEditAutoWindow.TitleTb.Text = "Редактирование авто";
            addEditAutoWindow.ShowDialog();
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient).ToList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e) //Удаление автомобиля
        {
            Auto autoForRemoving = (sender as Button).DataContext as Auto;
            if ((MessageBox.Show($"Вы действительно хотите удалить автомобиль с маркой: {autoForRemoving.Mark} модели: {autoForRemoving.Model} с гос.номером {autoForRemoving.GosNumber}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes))
            {
                try
                {
                    App.DB.Auto.Remove(autoForRemoving);
                    App.DB.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient).ToList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void searchTxt_TextChanged(object sender, TextChangedEventArgs e) //Поиск по различным критериям
        {
            autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient && (x.Mark.StartsWith(searchTxt.Text) || x.Model.StartsWith(searchTxt.Text) || x.GosNumber.StartsWith(searchTxt.Text))).ToList();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e) //Сброс поиска
        {
            autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient).ToList();
            searchTxt.Text = "";
        }

        private void MarkTb_PreviewMouseDown(object sender, MouseButtonEventArgs e) //Сортировка по марке
        {
            if (sorting == false)
            {
                autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient && (x.Mark.StartsWith(searchTxt.Text) || x.Model.StartsWith(searchTxt.Text) || x.GosNumber.StartsWith(searchTxt.Text))).OrderBy(x => x.Mark).ToList();
                sorting = true;
            }

            else
            {
                autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient && (x.Mark.StartsWith(searchTxt.Text) || x.Model.StartsWith(searchTxt.Text) || x.GosNumber.StartsWith(searchTxt.Text))).OrderByDescending(x => x.Mark).ToList();
                sorting = false;
            }
        }

        private void ModelTb_PreviewMouseDown(object sender, MouseButtonEventArgs e) //Сортировка по модели
        {
            if (sorting == false)
            {
                autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient && (x.Mark.StartsWith(searchTxt.Text) || x.Model.StartsWith(searchTxt.Text) || x.GosNumber.StartsWith(searchTxt.Text))).OrderBy(x => x.Model).ToList();
                sorting = true;
            }

            else
            {
                autoListView.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient && (x.Mark.StartsWith(searchTxt.Text) || x.Model.StartsWith(searchTxt.Text) || x.GosNumber.StartsWith(searchTxt.Text))).OrderByDescending(x => x.Model).ToList();
                sorting = false;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) //Передвижение окна с помощью левой кнопки мыши
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
