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
    public partial class Personal_data : Window
    {
        private User_cabinet ?bebra;
        public Personal_data()
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
                if (bebra == null)
                {
                    // Создание экземпляра второго окна
                    User_cabinet bebra = new User_cabinet();
                    bebra.Show();
                }
                else
                {
                    // Если второе окно уже открыто, просто активируем его
                    bebra.Activate();
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
