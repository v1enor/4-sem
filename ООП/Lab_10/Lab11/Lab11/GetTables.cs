using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Lab11
{
    public static class GetTables
    {
        static SqlConnection connection;
        public static DataTable GetFiles(SqlConnection c)
        {
            connection = c;
            string get_files = "select * from Files ";
            SqlDataAdapter adapter = new SqlDataAdapter(get_files, connection);
            DataTable rc = new DataTable("Files");
            adapter.Fill(rc);
            return rc;
        }
        
        public static DataTable GetAuthors(SqlConnection c)
        {
            connection = c;
            string get_auth = "select * from Authors ";
            SqlDataAdapter adapter = new SqlDataAdapter(get_auth, connection);
            DataTable rc = new DataTable("Authors");
            adapter.Fill(rc);
            return rc;
        }

        
        public static DataTable Search(string table, string param, SqlConnection c)
        {
            connection = c;
            DataTable rc = new DataTable();
            if(table.Equals("Books"))
            {
                string get_books = "select * from Books where title like '%" + param + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(get_books, connection);
                rc.TableName = "Books";
                adapter.Fill(rc);
            }
            else if(table.Equals("Files"))
            {
                string get_files = "select * from Files where file_id like '%" + param + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(get_files, connection);
                rc.TableName = "Files";
                adapter.Fill(rc);
            }
            else if (table.Equals("Authors"))
            {
                string get_auth = "select * from Authors where FIO like '%" + param + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(get_auth, connection);
                rc.TableName = "Authors";
                adapter.Fill(rc);
            }
            return rc;
        }
    }
}
