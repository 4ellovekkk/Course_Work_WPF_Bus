using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private Home ?usr_cab;
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                // Продолжайте с регистрационной логикой здесь
                // ...
                MessageBox.Show("Регистрация успешна!");
                this.Close();
                if (usr_cab == null)
                {
                    // Создание экземпляра второго окна
                    Home bebra = new Home();
                    bebra.Show();
                    this.Close();
                }
                else
                {
                    // Если второе окно уже открыто, просто активируем его
                    usr_cab.Activate();
                }
            }
        }

        private bool ValidateForm()
        {
            // Проверка поля "Логин"
            if (string.IsNullOrWhiteSpace(Login.Text))
            {
                MessageBox.Show("Введите логин.");
                return false;
            }

            // Проверка поля "Пароль"
            if (string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Введите пароль.");
                return false;
            }

            // Проверка поля "Имя"
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show("Введите имя.");
                return false;
            }

            // Проверка поля "Фамилия"
            if (string.IsNullOrWhiteSpace(Surname.Text))
            {
                MessageBox.Show("Введите фамилию.");
                return false;
            }

            // Проверка поля "Отчество"

            // Проверка поля "Email" с использованием регулярного выражения
            if (!Regex.IsMatch(Email.Text, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"))
            {
                MessageBox.Show("Введите корректный email.");
                return false;
            }

            // Проверка поля "Дата рождения"
            if (string.IsNullOrWhiteSpace(DateOfBirth.Text))
            {
                MessageBox.Show("Введите дату рождения.");
                return false;
            }

            if (!DateTime.TryParse(DateOfBirth.Text, out _))
            {
                MessageBox.Show("Введите корректную дату рождения.");
                return false;
            }

            // Дополнительные проверки, если необходимо

            return true;
        }

        private void X_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void O_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window window = Window.GetWindow(this); // Получаем текущее окно

            if (window != null)
            {
                window.WindowState = WindowState.Minimized; // Устанавливаем состояние окна в "свернуто"
            }
        }
        
    }
}
