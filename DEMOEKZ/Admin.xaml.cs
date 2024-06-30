using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Net;
using System.Net.Mail;

namespace DEMOEKZ
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }
        DataBase dataBase = new DataBase();

        private void Input_Button_Click(object sender, RoutedEventArgs e)
        {
            AccessAsAdmin();
        }
        public void AccessAsAdmin()
        {

            string username = Login_Text.Text;
            string password = Password_Text.Text;

            string query = "SELECT * FROM Admin WHERE login = @Username AND password = @Password";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                
                MessageBox.Show("Вход выполнен успешно!");
                ShowApplication();
                EnterAsAdmin_Grid.Visibility = Visibility.Collapsed;
                Admin_Grid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль!");
            }

        }
        public void ShowApplication()
        {
            string command = "SELECT * FROM Applications inner join Malfunctions on Applications.type=Malfunctions.id";
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

        public void ChangeStatus()
        {
            var statusIndex = Status_ComboBox.SelectedIndex;
            if (statusIndex == 0)
            {

                if (ApplicationsTable.SelectedItem != null)
                {
                    var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                    int selectedRecordId = (int)selectedRow.Row["id"];

                    string query = $"UPDATE Applications set status='В работе' WHERE id = @RecordId";

                    SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                    command.Parameters.AddWithValue("@RecordId", selectedRecordId);
                    dataBase.OpenConnection();
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Заявка принята на отработку!");
                    ShowApplication();
                }
                else
                {
                    MessageBox.Show("Выберите запись!");
                }
            }
            if (statusIndex == 1)
            {
                if (ApplicationsTable.SelectedItem != null)
                {
                    var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                    int selectedRecordId = (int)selectedRow.Row["id"];

                    string query = $"UPDATE Applications set status='Выполнена' WHERE id = @RecordId";

                    SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                    command.Parameters.AddWithValue("@RecordId", selectedRecordId);
                    dataBase.OpenConnection();
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Заявка выполнена!");
                    ShowApplication();
                }
                else
                {
                    MessageBox.Show("Выберите запись!");
                }
            }
            if (statusIndex == 2)
            {

                if (ApplicationsTable.SelectedItem != null)
                {
                    var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                    int selectedRecordId = (int)selectedRow.Row["id"];

                    string query = $"UPDATE Applications set status='Отклонена' WHERE id = @RecordId";

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

        public void ChangeExecutor()
        {
            var executorIndex = Executor_ComboBox.SelectedIndex;
            if (executorIndex == 0)
            {

                if (ApplicationsTable.SelectedItem != null)
                {
                    var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                    int selectedRecordId = (int)selectedRow.Row["id"];

                    string query = $"UPDATE Applications set executor='Электрик' WHERE id = @RecordId";

                    SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                    command.Parameters.AddWithValue("@RecordId", selectedRecordId);
                    dataBase.OpenConnection();
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Заявка отправлена Исполнителю!");
                    ShowApplication();
                }
                else
                {
                    MessageBox.Show("Выберите запись!");
                }
            }
            if (executorIndex == 1)
            {
                if (ApplicationsTable.SelectedItem != null)
                {
                    var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                    int selectedRecordId = (int)selectedRow.Row["id"];

                    string query = $"UPDATE Applications set executor='Плотник' WHERE id = @RecordId";

                    SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                    command.Parameters.AddWithValue("@RecordId", selectedRecordId);
                    dataBase.OpenConnection();
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Заявка отправлена Исполнителю!");
                    ShowApplication();
                }
                else
                {
                    MessageBox.Show("Выберите запись!");
                }
            }
            if (executorIndex == 2)
            {
                if (ApplicationsTable.SelectedItem != null)
                {
                    var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                    int selectedRecordId = (int)selectedRow.Row["id"];

                    string query = $"UPDATE Applications set executor='Сантехник' WHERE id = @RecordId";

                    SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                    command.Parameters.AddWithValue("@RecordId", selectedRecordId);
                    dataBase.OpenConnection();
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Заявка отправлена Исполнителю!");
                    ShowApplication();
                }
                else
                {
                    MessageBox.Show("Выберите запись!");
                }
            }
            if (executorIndex == 3)
            {
                if (ApplicationsTable.SelectedItem != null)
                {
                    var selectedRow = (DataRowView)ApplicationsTable.SelectedItem;
                    int selectedRecordId = (int)selectedRow.Row["id"];

                    string query = $"UPDATE Applications set executor='Уборщик' WHERE id = @RecordId";

                    SqlCommand command = new SqlCommand(query, dataBase.GetConnection());
                    command.Parameters.AddWithValue("@RecordId", selectedRecordId);
                    dataBase.OpenConnection();
                    command.ExecuteNonQuery();
                    dataBase.CloseConnection();

                    MessageBox.Show("Заявка отправлена Исполнителю!");
                    ShowApplication();
                }
                else
                {
                    MessageBox.Show("Выберите запись!");
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

                string query = $"UPDATE Applications SET description = @NewValue WHERE id = @RecordId";

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

        private void Change_App_Click(object sender, RoutedEventArgs e)
        {
            ChangeStatus();
        }

        private void Change_Executor_Click(object sender, RoutedEventArgs e)
        {
            ChangeExecutor();
        }

        private void Change_Description_Click(object sender, RoutedEventArgs e)
        {
            ChangeDescription();
        }

        private void Search_Text_TextChanged(object sender, TextChangedEventArgs e)
        {

                dataBase.OpenConnection();
                string cmd = $"SELECT * from Applications where concat (id,date, description, equipment, status, type, comment, username,usermail,executor) like'%{Search_Text.Text}%'";
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
       
        public void ShowStatistic()
        {
            dataBase.OpenConnection();
            string cmd = $"SELECT * from Applications inner join Malfunctions on Applications.type=Malfunctions.id";
            SqlCommand createCommand = new SqlCommand(cmd, dataBase.GetConnection());
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable();
            dataAdp.Fill(dt);
            if (dt.Rows.Count > 0)
            {               
                All_App_Text.Text = dt.Rows.Count.ToString();
                dataBase.CloseConnection();
            }
            else
            {
                All_App_Text.Text = "0";
            }
        }
        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            Admin_Grid.Visibility = Visibility.Collapsed;
            Statistic_Grid.Visibility = Visibility.Visible;
            ShowStatistic();
            LoadData_Done();
            LoadData_InWork();
            LoadData_Denite();

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Statistic_Grid.Visibility = Visibility.Collapsed;
            Admin_Grid.Visibility = Visibility.Visible;
        }

        private void Defect_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var index = Defect_Box.SelectedIndex;
            dataBase.OpenConnection();
            string cmd = $"SELECT * from Applications inner join Malfunctions on Applications.type=Malfunctions.id where type={index+1}";
            SqlCommand createCommand = new SqlCommand(cmd, dataBase.GetConnection());
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable();
            dataAdp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Defect_App_Text.Text = dt.Rows.Count.ToString();
                dataBase.CloseConnection();
            }
            else
            {
                Defect_App_Text.Text = "0";
            }
        }
        private void LoadData_Done()
        {

            dataBase.OpenConnection();
            string cmd = $"SELECT * from Applications inner join Malfunctions on Applications.type=Malfunctions.id where status like 'Выполнена'";
            SqlCommand createCommand = new SqlCommand(cmd, dataBase.GetConnection());
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable();
            dataAdp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Done_App_Text.Text = dt.Rows.Count.ToString();
                dataBase.CloseConnection();
            }
            else
            {
                Done_App_Text.Text = "0";
            }
        }
        private void LoadData_InWork()
        {

            dataBase.OpenConnection();
            string cmd = $"SELECT * from Applications inner join Malfunctions on Applications.type=Malfunctions.id where status like 'В работе'";
            SqlCommand createCommand = new SqlCommand(cmd, dataBase.GetConnection());
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable();
            dataAdp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                InWork_App_Text.Text = dt.Rows.Count.ToString();
                dataBase.CloseConnection();
            }
            else
            {
                InWork_App_Text.Text = "0";
            }
        }
        private void LoadData_Denite()
        {

            dataBase.OpenConnection();
            string cmd = $"SELECT * from Applications inner join Malfunctions on Applications.type=Malfunctions.id where status like 'Отклонена'";
            SqlCommand createCommand = new SqlCommand(cmd, dataBase.GetConnection());
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable();
            dataAdp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Denite_App_Text.Text = dt.Rows.Count.ToString();
                dataBase.CloseConnection();
            }
            else
            {
                Denite_App_Text.Text = "0";
            }
        }
    }
}

