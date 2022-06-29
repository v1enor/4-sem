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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;


namespace Kyrsach
{
    class DataBase
    {
        HashFunc Hash = new HashFunc();
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-PQRNELH\SQLEXPRESS;Initial Catalog=VA_Crypto;Integrated Security=True");
        public string HashFuncExamination(string source)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = Hash.GetHash(sha256Hash, source);

                //MessageBox.Show($"Хэш SHA256 строки {source} равен: {hash}.");
                //Login.Text = hash.ToString();
                return hash;
                //MessageBox.Show("Проверка хэша...");

                //if (Hash.VerifyHash(sha256Hash, source, hash))
                //{
                //    MessageBox.Show("Хэши одинаковые.");
                //}
                //else
                //{
                //    MessageBox.Show("Хэши не совпадают.");
                //}
            }
        }

        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
        //public DataTable Select(string selectSQL)
        //{
        //    DataTable dataTable = new DataTable("dataBase");
        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-PQRNELH\SQLEXPRESS;Initial Catalog=VA_Crypto;Integrated Security=True");
        //    sqlConnection.Open();
        //    SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //    sqlCommand.CommandText = selectSQL;
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //    sqlDataAdapter.Fill(dataTable);
        //    return dataTable;
        //}
    }
}
