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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
            FillComboBox();
            FillComboBox1();



        }
        public void FillComboBox()
        {
            try
            {
                String connectionString = @"Data Source=VYDRA-PC; Initial Catalog=Course_Work_Bus; Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select start_point from Path UNION SELECT start_point From Path", con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                xYx.ItemsSource = dt.DefaultView;
                xYx.DisplayMemberPath = "start_point";
                xYx.SelectedValuePath = "start_point";
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
            }
        }
        public void FillComboBox1()
        {
            try
            {
                String connectionString = @"Data Source=VYDRA-PC; Initial Catalog=Course_Work_Bus; Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select end_point from Path UNION SELECT end_point From Path", con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Yxx.ItemsSource = dt.DefaultView;
                Yxx.DisplayMemberPath = "end_point";
                Yxx.SelectedValuePath = "end_point";
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
            }
        }
        public void FillComboBox2(object sender, RoutedEventArgs e)
        {
            try
            {

                string cmd;
                String connectionString = @"Data Source=VYDRA-PC; Initial Catalog=Course_Work_Bus; Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string[] abc = { "Борисов", "Минск", "Нарочь" };
                string bb = abc[xYx.SelectedIndex];
                string qq = abc[Yxx.SelectedIndex];
                if ((Data.SelectedDate.Value.DayOfWeek.ToString() != "Saturday") || (Data.SelectedDate.Value.DayOfWeek.ToString() != "Sunday"))
                {

                    cmd = ($"SELECT[Path].start_point[откуда], [Path].end_point[куда], Route.timer[В пути], Route.otxod[отправление] FROM Route INNER join [Path] on [Path].id = Route.path_id\r\nWHERE Path.start_point=N'{bb}' and Path.end_point=N'{qq}' and Route.how_often LIKE N'%Everyady%'");
                }
                else
                {
                    cmd = ($"use Course_Work_Bus\r\nSELECT[Path].start_point[откуда], [Path].end_point[куда], Route.timer[В пути], Route.otxod[отправление]\r\nFROM Route INNER join[Path] on[Path].id = Route.path_id\r\nWHERE Path.start_point=N'{bb}' and Path.end_point=N'{qq}' and (Route.how_often LIKE N'%Everyady%' or Route.how_often LIKE N'%Holiday%')");
                }

                SqlCommand createCommand = new SqlCommand(cmd, con);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Students"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                Res.ItemsSource = dt.DefaultView; // Сам вывод 
                con.Close();
            }
            catch (Exception ex)
            {
            }
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
            MessageBox.Show("Успешно Заброниовано");           
        }

    }
}