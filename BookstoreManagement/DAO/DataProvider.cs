using MySql.Data.MySqlClient;
using System.Data;

namespace BookstoreManagement.DAO
{
    public class DataProvider
    {
        private static DataProvider _instance;
        private string path = "server = b42mrn7vlh9llfnl9bjk-mysql.services.clever-cloud.com; port = 3306; database = b42mrn7vlh9llfnl9bjk; username = u73erd9wreoxmhex; password = B2HaZx1z8Q3kBR621vk5;";
        //private string path = "server = localhost; port = 3306; database = QuanLyBanSach; username = root; password = andy9999;";

        public static DataProvider Instance
        {
            get { if (_instance == null) _instance = new DataProvider(); return DataProvider._instance; }
            private set { DataProvider._instance = value; }
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(path))
            {
                connection.Open();
                MySqlCommand mysqlCommand = new MySqlCommand(query, connection);
                MySqlDataAdapter adpt = new MySqlDataAdapter(mysqlCommand);
                adpt.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query)
        {
            int successfulRows = 0;
            using (MySqlConnection connection = new MySqlConnection(path))
            {
                connection.Open();
                MySqlCommand mysqlCommand = new MySqlCommand(query, connection);
                successfulRows = mysqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            return successfulRows;
        }

        public object ExecuteScalar(string query)
        {
            object count = 0;
            using (MySqlConnection connection = new MySqlConnection(path))
            {
                connection.Open();
                MySqlCommand mysqlCommand = new MySqlCommand(query, connection);
                count = mysqlCommand.ExecuteScalar();
                connection.Close();
            }
            return count;
        }

        public void ExecuteNonQuery2(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(path))
            {
                connection.Open();
                MySqlCommand mysqlCommand = new MySqlCommand(query, connection);
                connection.Close();
            }
        }
    }
}
