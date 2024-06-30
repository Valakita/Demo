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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DEMOEKZ
{
    /// <summary>
    /// Логика взаимодействия для ExecutorWindow.xaml
    /// </summary>
    public partial class ExecutorWindow : Window
    {
        public ExecutorWindow()
        {
            InitializeComponent();
        }

        DataBase dataBase = new DataBase();
        private void Input_Button_Click(object sender, RoutedEventArgs e)
        {
            AccessAsExecutor();
        }
        public void AccessAsExecutor()
        {

            string username = Login_Text.Text;
            string password = Password_Text.Text;

            string query = "SELECT * FROM Executors WHERE login = @Username AND password = @Password";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DataBase.Role = dataTable.Rows[0]["role"].ToString();
                MessageBox.Show("Вход выполнен успешно!");
                ShowApplication();
                EnterAsExecutor_Grid.Visibility = Visibility.Collapsed;
                Executor_Grid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль!");
            }

        }
        public void SendEmail()
        {
            
        }
        public void ShowApplication()
        {
            string command = "SELECT * FROM Applications INNER JOIN Malfunctions on Applications.type=Malfunctions.id where executor ='" + DataBase.Role + "'";
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

        private void Search_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataBase.OpenConnection();
            string cmd = $"SELECT * from Applications INNER JOIN Malfunctions on Applications.type=Malfunctions.id where concat (id,date, description, equipment, status, type, comment, username,usermail,executor) like'%{Search_Text.Text}%'";
            SqlCommand createCommand = new SqlCommand(cmd, dataBase.GetConnection());
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
                ApplicationsTable.ItemsSource = " ";
            }
        }

        private void Change_App_Click(object sender, RoutedEventArgs e)
        {
            ChangeStatus();
        }
        public void ChangeStatus()
        {
            var statusIndex = Status_ComboBox.SelectedIndex;
            if (statusIndex == 0)
            {

                if (ApplicationsTable.SelectedItem != null)
                {
                    var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                    int selectedRecordId = (int)selectedRow.Row["id"];
                    DateTime currentTime = DateTime.Today;
                    string query = $"UPDATE Applications set status='Выполнена' WHERE id = @RecordId";

                    SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                    command.Parameters.AddWithValue("@RecordId", selectedRecordId);
                    command.Parameters.AddWithValue("@DateEnd", currentTime);
                    dataBase.OpenConnection();
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Заявка принята на отработку!");
                    ShowApplication();
                    SendEmail();
                }
                else
                {
                    MessageBox.Show("Выберите запись!");
                }
            }           
            else if (statusIndex == 1)
            {

                if (ApplicationsTable.SelectedItem != null)
                {
                    var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                    int selectedRecordId = (int)selectedRow.Row["id"];

                    string query = $"DELETE FROM Applications WHERE id = @RecordId";

                    SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                    command.Parameters.AddWithValue("@RecordId", selectedRecordId);
                    dataBase.OpenConnection();
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Заявка отклонена!");
                    ShowApplication();
                }
                else
                {
                    MessageBox.Show("Выберите запись для удаления.");
                }
            }

        }

        public void ChangeDescription()
        {
            if (ApplicationsTable.SelectedItem != null)
            {
                var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                int selectedRecordId = (int)selectedRow.Row["id"];
                string desc = Description_Text.Text;

                string query = $"UPDATE Applications SET comment = @NewValue WHERE id = @RecordId";

                SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                command.Parameters.AddWithValue("@RecordId", selectedRecordId);
                command.Parameters.AddWithValue("@NewValue", desc);
                dataBase.OpenConnection();
                command.ExecuteNonQuery();
                dataBase.CloseConnection();

                MessageBox.Show("Описание заявки изменено!");
                ShowApplication();
            }
            else
            {
                MessageBox.Show("Выберите запись!");
            }
        }
        private void Change_Description_Click(object sender, RoutedEventArgs e)
        {
            ChangeDescription();
        }
    }
}
