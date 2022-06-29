using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lab11
{
    public static class Sort
    {
        public static SqlConnection connection;
        public static DataTable SortBooksbyPages(SqlConnection c)
        {
            connection = c;
            string get_books = "select * from Books order by pages desc";
            SqlDataAdapter adapter = new SqlDataAdapter(get_books, connection);
            DataTable rc = new DataTable("Books");
            adapter.Fill(rc);
            return rc;
        }
        public static DataTable SortBooksbyYear(SqlConnection c)
        {
            connection = c;
            string get_books = "select * from Books order by year desc";
            SqlDataAdapter adapter = new SqlDataAdapter(get_books, connection);
            DataTable rc = new DataTable("Books");
            adapter.Fill(rc);
            return rc;
        }
        public static DataTable SortBooksbyTitle(SqlConnection c)
        {
            connection = c;
            string get_books = "select * from Books order by title asc";
            SqlDataAdapter adapter = new SqlDataAdapter(get_books, connection);
            DataTable rc = new DataTable("Books");
            adapter.Fill(rc);
            return rc;
        }
    }
}
