using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using QRCoder;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DEMOEKZ
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            
        }
        DataBase dataBase = new DataBase();
        private void Input_Button_Click(object sender, RoutedEventArgs e)
        {
            AccessAsUser();

        }
        public void AccessAsUser()
        {

            string username = Login_Text.Text;
            string password = Password_Text.Text;

            string query = "SELECT * FROM Users WHERE login = @Username AND password = @Password";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DataBase.FIO = dataTable.Rows[0]["FIO"].ToString();
                DataBase.Mail = dataTable.Rows[0]["mail"].ToString();
                MessageBox.Show("Вход выполнен успешно!");
                ShowApplication();
                Main_Grid.Visibility = Visibility.Collapsed;
                User_Grid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль!");
            }

        }

        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            Main_Grid.Visibility = Visibility.Collapsed;
            Registration_Grid.Visibility = Visibility.Visible;
        }

        private void Application_Button_Click(object sender, RoutedEventArgs e)
        {
            SendApplication();
        }
       
        public void SendApplication()
        {
            string equipment = Equipment_Text.Text;
            var defect = Defect_ComboBox.SelectedIndex;
            string description = Description_Text.Text;
            DateTime currentTime = DateTime.Today;
          
            string query = "INSERT INTO Applications (date,equipment,type,description,username,usermail,status) VALUES (@Date ,@Equipment, @Type, @Description,@Name,@Mail, 'В ожидании')";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            command.Parameters.AddWithValue("@Equipment", equipment);
            command.Parameters.AddWithValue("@Type", defect+1);
            command.Parameters.AddWithValue("@Description", description);           
            command.Parameters.AddWithValue("@Date", currentTime);
            command.Parameters.AddWithValue("@Name", DataBase.FIO);
            command.Parameters.AddWithValue("@Mail", DataBase.Mail);

            dataBase.OpenConnection();
            command.ExecuteNonQuery();
            dataBase.CloseConnection();

            MessageBox.Show("Заявка успешно отправлена!");
            ShowApplication();
            Equipment_Text.Text = "";           
            Description_Text.Text = "";

        }
        public void ShowApplication()
        {
            string command = "SELECT * FROM Applications INNER JOIN Malfunctions on Applications.type=Malfunctions.id where usermail ='" + DataBase.Mail+"'";
            SqlCommand createCommand = new SqlCommand(command, dataBase.GetConnection());
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable();
            dataAdp.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                ApplicationsTable.ItemsSource = dt.DefaultView;

                dataBase.CloseConnection();
            }
            else
            {
                MessageBox.Show("Заявок не найдено!");
            }
        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Login_Reg_Text.Text;
            string password = Password_Reg_Text.Text;
            string mail = Mail_Reg_Text.Text;
            string FIO = FIO_Reg_Text.Text;
            if (Reg_User())
            {
                string query = "INSERT INTO Users (login,password,mail,FIO) VALUES (@Login,@Password,@Mail,@FIO)";

                SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Mail", mail);
                command.Parameters.AddWithValue("@FIO", FIO);


                dataBase.OpenConnection();
                command.ExecuteNonQuery();
                dataBase.CloseConnection();


                DataBase.FIO = mail;
                DataBase.Mail = FIO;

                MessageBox.Show("Вы успешно зарегистрировались!");
                Login_Reg_Text.Text = "";
                Password_Reg_Text.Text = "";
                Mail_Reg_Text.Text = "";
                FIO_Reg_Text.Text = "";
                Registration_Grid.Visibility = Visibility.Collapsed;
                User_Grid.Visibility = Visibility.Visible;
            }
           
        }
        public bool Reg_User()
        {
            string login = Login_Reg_Text.Text;
            string password = Password_Reg_Text.Text;

            string query = "SELECT * FROM Users WHERE login = @Username AND password = @Password";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            command.Parameters.AddWithValue("@Username", login);
            command.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
              
                MessageBox.Show("такой пользователь уже есть!");              
                return false;
            }
            else
            {               
                return true;
            }

        }

        private void Quality_Button_Click(object sender, RoutedEventArgs e)
        {
            User_Grid.Visibility = Visibility.Collapsed;
            Quality_Grid.Visibility = Visibility.Visible;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Quality_Grid.Visibility = Visibility.Collapsed;
            User_Grid.Visibility = Visibility.Visible;
        }
       
    }
}
