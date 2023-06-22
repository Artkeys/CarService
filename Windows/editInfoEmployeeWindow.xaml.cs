using CarService.Classes;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace CarService.Windows
{
    /// <summary>
    /// Логика взаимодействия для editInfoEmployeeWindow.xaml
    /// </summary>
    public partial class editInfoEmployeeWindow : Window
    {
        private Employee _currentEmployee = new Employee();
        OpenFileDialog photo = new OpenFileDialog();
        public editInfoEmployeeWindow(Employee selectedEmployee)
        {
            InitializeComponent();
            educationCmb.ItemsSource = new string[] { "Сред.спец", "Высшее" };
            rolesCmb.ItemsSource = App.DB.Roles.ToList();
            if (selectedEmployee != null)
            {
                _currentEmployee = selectedEmployee;
            }

            DataContext = _currentEmployee;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Кнопка закрытия окна
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) //Кнопка сворачивания
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ChoosePhotoBtn_Click(object sender, RoutedEventArgs e) //Кнопка выбора фото
        {
            photo.Title = "Выберите фото";
            photo.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (photo.ShowDialog() == true)
            {
                string directItem = photo.FileName;
                string nameImage = photo.FileName.Substring(photo.FileName.LastIndexOf('\\') + 1);
                ChoosePhotoImage.Source = new BitmapImage(new Uri(photo.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e) //Кнопка сохранения
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(surnameTxt.Text))
                errors.AppendLine("Введите фамилию сотрудника");

            if (string.IsNullOrWhiteSpace(nameTxt.Text))
                errors.AppendLine("Введите имя сотрудника");

            if (string.IsNullOrWhiteSpace(patronymicTxt.Text))
                errors.AppendLine("Введите отчество сотрудника");

            if (_currentEmployee.DateOfBirth == null)
                errors.AppendLine("Выберите дату рождения сотрудника");

            if (_currentEmployee.Education == null)
                errors.AppendLine("Выберите образование сотрудника");

            if (string.IsNullOrWhiteSpace(specialityTxt.Text))
                errors.AppendLine("Введите специальность сотрудника");

            if (_currentEmployee.Roles == null)
                errors.AppendLine("Выберите должность сотрудника");

            if (string.IsNullOrWhiteSpace(loginTxt.Text))
                errors.AppendLine("Введите логин сотрудника");

            if (string.IsNullOrWhiteSpace(passwordTxt.Text))
                errors.AppendLine("Введите пароль сотрудника");

            if (errors.Length > 0)                            //Проверка на пустоту всех полей
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string passLevel = validPasswordClass.password_level(passwordTxt.Text);

            if (passLevel != "Надежный пароль")
            {
                MessageBox.Show(validPasswordClass.password_level(passwordTxt.Text));
                return;
            }

            try
            {

                if (photo.FileName == "")
                {
                    _currentEmployee.img = "question.png";
                    App.DB.SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    this.Close();
                }

                else
                {
                    translateImage();
                    _currentEmployee.img = photo.FileName.Substring(photo.FileName.LastIndexOf('\\') + 1);
                    App.DB.SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    this.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) //Кнопка отмены
        {
            this.Close();
        }

        private void translateImage() //Функция для перевода в системную папку
        {
            try
            {
                string currdir = Directory.GetCurrentDirectory();
                int pos = currdir.LastIndexOf("bin");
                string curr = currdir.Substring(0, pos);

                string destinationPath = $"{curr}\\resources\\image\\user\\";
                string destinationFile = System.IO.Path.Combine(destinationPath, System.IO.Path.GetFileName(photo.FileName));
                File.Copy(photo.FileName, destinationFile, true);
                MessageBox.Show("Перенос состоялся успешно!");
            }

            catch { }

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) //Передвижение окна с помощью левой кнопки мыши
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private void surnameTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита от некорректного ввода
        {
            if (!char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void nameTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита от некорректного ввода
        {
            if (!char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void patronymicTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита от некорректного ввода
        {
            if (!char.IsLetter(e.Text, 0)) e.Handled = true;
        }
    }
}
