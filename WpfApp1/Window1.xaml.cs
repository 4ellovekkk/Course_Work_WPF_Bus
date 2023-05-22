using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;
using System.Data.OleDb;
using WpfApp1.DB;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlTypes;
using WpfApp1.Models;
using System.Globalization;
using MaterialDesignThemes.Wpf;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Home ?hm;
        public Window1()
        {
            InitializeComponent();
            string cmd;
            String connectionString = @"Data Source=VYDRA-PC; Initial Catalog=Course_Work_Bus; Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string[] abc = { "Борисов", "Минск", "Нарочь" };
            cmd = ($"SELECT[Path].start_point[откуда], [Path].end_point[куда], Route.timer[В пути], Route.otxod[отправление] FROM Route INNER join [Path] on [Path].id = Route.path_id\r\nWHERE Path.start_point=N'{abc[1]}' and Path.end_point=N'{abc[0]}' and Route.how_often LIKE N'%Everyady%'");
            SqlCommand createCommand = new SqlCommand(cmd, con);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Students"); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
            Res.ItemsSource = dt.DefaultView; // Сам вывод 
            con.Close();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try{
                SqlConnection connection = new SqlConnection(@"Data Source=VYDRA-PC; Initial Catalog=Course_Work_Bus; Integrated Security=True");

                connection.Open();
                string cmd = "SELECT Path.start_point,Path.end_point, Route.how_often, Route.otxod,Route.Timer from Route inner join Path on Route.path_id=Path.id \r\n"; // Из какой таблицы нужен вывод 
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Students"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                Res.ItemsSource = dt.DefaultView; // Сам вывод 
                connection.Close();
            }
            catch (Exception ex) { }
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            if (hm == null)
            {
                // Создание экземпляра второго окна
                Home hm = new WpfApp1.Home();
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

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
