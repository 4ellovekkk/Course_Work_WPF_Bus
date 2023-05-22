using System.Data;
using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private User_cabinet ?hw;
        private Order  ord;
        public Home()
        {
            InitializeComponent();
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
        
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if (hw == null)
            {
                // Создание экземпляра второго окна
                User_cabinet hw = new User_cabinet();
                hw.Show();
            }
            else
            {
                // Если второе окно уже открыто, просто активируем его
                hw.Activate();
            }
        }
        public void LoadDataIntoDataGrid()
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (hw == null)
            {
                // Создание экземпляра второго окна
                Order ord = new Order();
                ord.Show();
            }
            else
            {
                // Если второе окно уже открыто, просто активируем его
                ord.Activate();
            }
        }
    }
    
}
