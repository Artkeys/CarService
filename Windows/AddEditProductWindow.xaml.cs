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
using static System.Net.Mime.MediaTypeNames;

namespace CarService.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {
        OpenFileDialog photo = new OpenFileDialog();
        private DetailOrService _currentDetailOrService = new DetailOrService();
        public AddEditProductWindow(DetailOrService selectedDetailOrService)
        {
            InitializeComponent();

            if (selectedDetailOrService != null)
            {
                _currentDetailOrService = selectedDetailOrService;
            }

            DataContext = _currentDetailOrService;
            typeCmb.ItemsSource = new string[] { "Товар", "Услуга" };
        }

        private void ChoosePhotoBtn_Click(object sender, RoutedEventArgs e) //Выбор фото
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
            if (string.IsNullOrWhiteSpace(nameTxt.Text))
                errors.AppendLine("Введите названия детали или услуги клиента");

            if (string.IsNullOrWhiteSpace(amountTxt.Text))
                errors.AppendLine("Введите количество деталей");

            if (string.IsNullOrWhiteSpace(priceTxt.Text))
                errors.AppendLine("Введите цену детали или услуги");

            if (typeCmb.SelectedItem == null)
                errors.AppendLine("Выберите тип продукта");

            if (errors.Length > 0)                            //Проверка на пустоту всех полей
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentDetailOrService.IdDetailOrService == 0)
            {
                translateImage();
                _currentDetailOrService.image = photo.FileName.Substring(photo.FileName.LastIndexOf('\\') + 1);
                App.DB.DetailOrService.Add(_currentDetailOrService);
                try
                {
                    App.DB.SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                
            }

            else
            {
                try
                {
                    if (photo.FileName == "")
                    {
                        App.DB.SaveChanges();
                        MessageBox.Show("Информация сохранена!");
                        this.Close();
                    }

                    else
                    {
                        translateImage();
                        _currentDetailOrService.image = photo.FileName.Substring(photo.FileName.LastIndexOf('\\') + 1);
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
        }

        private void translateImage() //Функция для перевода в системную папку
        {
            try
            {
                string currdir = Directory.GetCurrentDirectory();
                int pos = currdir.LastIndexOf("bin");
                string curr = currdir.Substring(0, pos);

                string destinationPath = $"{curr}\\resources\\image\\product\\";
                string destinationFile = System.IO.Path.Combine(destinationPath, System.IO.Path.GetFileName(photo.FileName));
                File.Copy(photo.FileName, destinationFile, true);
                MessageBox.Show("Перенос состоялся успешно!");
            }

            catch { }
            
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) //Кнопка отмены
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Кнопка закрытия окна
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) //Кнопка сворачивания
        {
            WindowState = WindowState.Minimized;
        }

        private void amountTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита данных от ввода количества 
        {
            if (!char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void priceTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита данных от ввода цены
        {
            if (e.Text == ",")
            {
                if (((TextBox)sender).Text.Contains(",") || ((TextBox)sender).Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                int result;
                if (!int.TryParse(e.Text, out result))
                {
                    e.Handled = true;
                }
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
