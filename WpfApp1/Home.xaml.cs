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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
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
