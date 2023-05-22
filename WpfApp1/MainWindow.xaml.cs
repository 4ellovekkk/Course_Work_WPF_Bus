using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdminPanel adm_win;
        private Home usr_win;
        private Register rega;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем введенные пользователем данные
            string username = Login.Text; 
            string password = Password.Text;

            // Проверяем введенный логин и пароль на соответствие заданным условиям
           /* if (VerifyUsername(username) && VerifyPassword(password))
            {*/
                MessageBox.Show("YEP");
                Admin_log_Click();
           /* }
            else
            {
                // Логин и/или пароль не соответствуют заданным условиям, выводим сообщение об ошибке
                MessageBox.Show("Неправильный логин и/или пароль");
            }*/


        }

        // Функция для проверки логина на соответствие заданным условиям
        private bool VerifyUsername(string username)
        {
            // Проверяем, что логин не пустой и содержит только буквы, цифры и символы "_", ".", "-"
            string pattern = @"^[a-zA-Z0-9_.-]+$";
            return Regex.IsMatch(username, pattern);
        }

        // Функция для проверки пароля на соответствие заданным условиям
        private bool VerifyPassword(string password)
        {
            // Проверяем, что пароль не пустой и содержит хотя бы одну букву и одну цифру
            string pattern = @"^(?=.*[a-zA-Z])(?=.*[0-9]).{4,}$";
            return Regex.IsMatch(password, pattern);
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
        private void Admin_log_Click()
        {
            if ((Login.Text == "admin") && (Password.Text == "admin"))
            { 
            if (adm_win == null)
            {
                // Создание экземпляра второго окна
                AdminPanel adm_win = new AdminPanel();
                adm_win.Show();
                this.Close();
            }
            else
            {
                // Если второе окно уже открыто, просто активируем его
                adm_win.Activate();
            }
        }
           else
            {
                if (usr_win == null)
                {
                    // Создание экземпляра второго окна
                    Home usr_win = new Home();
                    usr_win.Show();
                    this.Close();
                }
                else
                {
                    // Если второе окно уже открыто, просто активируем его
                    usr_win.Activate();
                }
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
                if (rega == null)
                {
                    // Создание экземпляра второго окна
                    Register rega = new Register();
                    rega.Show();
                }
                else
                {
                    // Если второе окно уже открыто, просто активируем его
                    rega.Activate();
                }
            }
        }
    }
