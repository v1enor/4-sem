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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lab11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString;
        SqlConnection connection;
        DataTable files;
        DataTable authors;

        private void FillBookList()
        {
            string get_books = "select * from Books";
            SqlCommand command = new SqlCommand(get_books, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable books = new DataTable("Books");
            adapter.Fill(books);
            this.datagrid.ItemsSource = books.AsDataView();
        }
        private void FillForm()
        {
            files = GetTables.GetFiles(this.connection);
            authors = GetTables.GetAuthors(this.connection);
            for (int i = 0; i < files.Rows.Count; i++) this.file_select.Items.Add(files.Rows[i][0]);
            for (int i = 0; i < authors.Rows.Count; i++) this.auth_select.Items.Add(authors.Rows[i][0]);
            this.file_select.SelectedIndex = 0;
            this.auth_select.SelectedIndex = 0;
        }

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ElibConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                FillBookList();
                FillForm();
                //----------------------------
                
            }
            catch(Exception ex)
            {
                this.errors.Text = ex.Message + '\n' + this.errors.Text;
            }
        }

        private void btnUP_Click(object sender, RoutedEventArgs e)
        {
            this.datagrid.SelectedIndex = this.datagrid.SelectedIndex == 0 ? 0 : this.datagrid.SelectedIndex - 1;
        }
        private void btnDOWN_Click(object sender, RoutedEventArgs e)
        {
            this.datagrid.SelectedIndex = this.datagrid.SelectedIndex == this.datagrid.Items.Count - 1 ? this.datagrid.SelectedIndex : this.datagrid.SelectedIndex + 1;
        }
        private void btn_sort_pages_Click(object sender, RoutedEventArgs e)
        {
            this.datagrid.ItemsSource = null;
            this.datagrid.ItemsSource = Sort.SortBooksbyPages(this.connection).DefaultView;
            this.datagrid.Items.Refresh();
        }
        private void btn_sort_year_Click(object sender, RoutedEventArgs e)
        {
            this.datagrid.ItemsSource = null;
            this.datagrid.ItemsSource = Sort.SortBooksbyYear(this.connection).DefaultView;
            this.datagrid.Items.Refresh();
        }
        private void btn_sort_title_Click(object sender, RoutedEventArgs e)
        {
            this.datagrid.ItemsSource = null;
            this.datagrid.ItemsSource = Sort.SortBooksbyTitle(this.connection).DefaultView;
            this.datagrid.Items.Refresh();
        }
        private bool CheckForm()
        {
            bool rc = true;
            if (this.title_select.Text.Equals(""))
            {
                rc = false;
                this.errors.Text = "Нет названия" + '\n' + this.errors.Text;
            }
            int p, y;
            if(!int.TryParse(this.pages_select.Text, out p))
            {
                rc = false;
                this.errors.Text = "Плохие страницы" + '\n' + this.errors.Text;
            }
            if (int.TryParse(this.year_select.Text, out y))
            {
                if( y > 2020 || y < 1500)
                {
                    rc = false;
                    this.errors.Text = "Плохой год" + '\n' + this.errors.Text;
                }
            }
            else
            {
                rc = false;
                this.errors.Text = "Плохой год" + '\n' + this.errors.Text;
            }
            return rc;
        }
        private void btn_AddBook_Click(object sender, RoutedEventArgs e)
        {
            if(CheckForm())
            {
                SqlTransaction trans = null;
                SqlCommand comm = null;
                try
                {
                    comm = connection.CreateCommand();
                    trans = connection.BeginTransaction("BookAdding");
                    comm.CommandText = "insert into Books(title, author, file_id, pages, year) values ('" +
                        this.title_select.Text+"', '" +
                        this.auth_select.SelectedItem.ToString() + "', '"+
                        this.file_select.SelectedItem.ToString() + "', "+
                        this.pages_select.Text + ", "+
                        this.year_select.Text +")";
                    comm.Transaction = trans;
                    comm.ExecuteNonQuery();
                    trans.Commit();
                    FillBookList();
                }
                catch (Exception ex)
                {
                    this.errors.Text = ex.Message + '\n' + this.errors.Text;
                }
            }
        }
        private void btn_delBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = datagrid.SelectedItem;
            if (selectedItem != null)
            {
                try
                {
                    if (((DataView)datagrid.ItemsSource).Table.TableName.Equals("Books"))
                    {
                        SqlCommand comm = connection.CreateCommand();
                        comm.CommandText = "delete Books where title like '" +
                            ((DataRowView)selectedItem).Row.ItemArray[0] + "'";
                        comm.ExecuteNonQuery();
                        FillBookList();
                    }
                    else if(((DataView)datagrid.ItemsSource).Table.TableName.Equals("Files"))
                    {
                        SqlCommand comm = connection.CreateCommand();
                        comm.CommandText = "delete Files where file_id like '" +
                            ((DataRowView)selectedItem).Row.ItemArray[0] + "'";
                        comm.ExecuteNonQuery();
                        this.datagrid.ItemsSource = GetTables.GetFiles(this.connection).DefaultView;
                        FillForm();
                    }
                    else
                    {
                        SqlCommand comm = connection.CreateCommand();
                        comm.CommandText = "delete Authors where FIO like '" +
                            ((DataRowView)selectedItem).Row.ItemArray[0] + "'";
                        comm.ExecuteNonQuery();
                        this.datagrid.ItemsSource = GetTables.GetAuthors(this.connection).DefaultView;
                        FillForm();
                    }
                }
                catch (Exception ex)
                {
                    this.errors.Text = ex.Message + '\n' + this.errors.Text;
                }
            }

        }
        private void btn_showFiles_Click(object sender, RoutedEventArgs e)
        {
            this.datagrid.ItemsSource = GetTables.GetFiles(this.connection).DefaultView;
        }
        private void btn_showAuthors_Click(object sender, RoutedEventArgs e)
        {
            this.datagrid.ItemsSource = GetTables.GetAuthors(this.connection).DefaultView;
        }
        private void btn_showBooks_Click(object sender, RoutedEventArgs e)
        {
            FillBookList();
        }
        private void btn_AddAu_Click(object sender, RoutedEventArgs e)
        {
            if(!this.fio_select.Text.Equals("") && !this.country_select.Text.Equals(""))
            {
                SqlTransaction trans = null;
                SqlCommand comm = null;
                try
                {
                    comm = connection.CreateCommand();
                    trans = connection.BeginTransaction("AuthAdding");
                    comm.CommandText = "insert into Authors(FIO, country) values ('" +
                        this.fio_select.Text + "', '" +
                        this.country_select.Text + "')";
                    comm.Transaction = trans;
                    comm.ExecuteNonQuery();
                    trans.Commit();
                    this.datagrid.ItemsSource = GetTables.GetAuthors(this.connection).DefaultView;
                    FillForm();
                }
                catch (Exception ex)
                {
                    this.errors.Text = ex.Message + '\n' + this.errors.Text;
                }
            }
        }
        private void btn_AddFi_Click(object sender, RoutedEventArgs e)
        {
            int size;
            if(!this.fileid_select.Text.Equals("") &&
                this.format_select.SelectedIndex != -1 &&
                int.TryParse(this.filesize_select.Text, out size))
            {
                SqlTransaction trans = null;
                SqlCommand comm = null;
                try
                {
                    comm = connection.CreateCommand();
                    trans = connection.BeginTransaction("BookAdding");
                    comm.CommandText = "insert into Files(file_id, format, file_size) values ('" +
                        this.fileid_select.Text + "', '" +
                        ((ComboBoxItem)this.format_select.Items[this.format_select.SelectedIndex]).Content + "', " +
                        size.ToString() + ")";
                    comm.Transaction = trans;
                    comm.ExecuteNonQuery();
                    trans.Commit();
                    FillForm();
                    this.datagrid.ItemsSource = GetTables.GetFiles(this.connection).DefaultView;
                    
                }
                catch (Exception ex)
                {
                    this.errors.Text = ex.Message + '\n' + this.errors.Text;
                }
            }
            else this.errors.Text = "Все поля заполни слыш" + '\n' + this.errors.Text;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.connection.Close();
        }

        private void search_field_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if(!this.search_field.Text.Equals(""))
                this.datagrid.ItemsSource = GetTables.Search(((DataView)datagrid.ItemsSource).Table.TableName, this.search_field.Text, connection).DefaultView;
            }
            catch (Exception ex)
            {
                this.errors.Text = ex.Message + '\n' + this.errors.Text;
            }
        }
    }
}
