using System.Data;
using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for User_cabinet.xaml
    /// </summary>
    public partial class User_cabinet : Window
    {
        private MainWindow ?main_win;
        private Home ?hm;
        private Window1? w1;
        private Personal_data ?prs;

        public User_cabinet()
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
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (main_win == null)
            {
                // Создание экземпляра второго окна
                MainWindow main_win = new MainWindow();
                main_win.Show();
                this.Close();
            }
            else
            {
                // Если второе окно уже открыто, просто активируем его
                main_win.Activate();
                this.Close();
            }
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            if (hm == null)
            {
                // Создание экземпляра второго окна
                Home hm = new Home();
                hm.Show();
                this.Close();
            }
            else
            {
                // Если второе окно уже открыто, просто активируем его
                hm.Activate();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=VYDRA-PC; Initial Catalog=Course_Work_Bus; Integrated Security=True");

                connection.Open();
                string cmd = "SELECT Path.start_point,Path.end_point, Route.how_often, Route.otxod,Route.Timer from Route inner join Path on Route.path_id=Path.id \r\n"; // Из какой таблицы нужен вывод 
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Students"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                Table1.ItemsSource = dt.DefaultView; // Сам вывод 
                connection.Close();
            }
            catch (Exception ex) { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (main_win == null)
            {
                // Создание экземпляра второго окна
                Window1 w1= new Window1();
                w1.Show();
                this.Close();
            }
            else
            {
                // Если второе окно уже открыто, просто активируем его
                w1.Activate();
                this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (prs == null)
            {
                // Создание экземпляра второго окна
                Personal_data prs = new Personal_data();
                prs.Show();
                this.Close();
            }
            else
            {
                // Если второе окно уже открыто, просто активируем его
                prs.Activate();
                this.Close();
            }
        }
    }
}
