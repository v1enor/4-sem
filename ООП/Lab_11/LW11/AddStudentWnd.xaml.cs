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
using System.Windows.Shapes;

namespace LW11
{
    /// <summary>
    /// Логика взаимодействия для AddStudentWnd.xaml
    /// </summary>
    public partial class AddStudentWnd : Window
    {
        public AddStudentWnd()
        {
            InitializeComponent();
            BirthdayBox.DisplayDateEnd = DateTime.Now;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            Student student = new Student();
            try
            {
                student.Name = NameBox.Text;
                student.Surname = SurnameBox.Text;
                student.Patronymic = PatronymicBox.Text;
                student.Speciality = SpecialityBox.Text;
                student.Birthday = Convert.ToDateTime(BirthdayBox.Text);
                student.Course = Convert.ToInt32(CourseBox.Text);
                student.GroupNumber = Convert.ToInt32(GroupBox.Text);
                if (GenderBox.Text == "Male")
                {
                    student.Gender = "Male";
                }
                else if (GenderBox.Text == "Female")
                {
                    student.Gender = "Female";
                }
                student.PhoneNumber = PhoneBox.Text;
                student.ImageSrc = ImageBox.Text;

                student.AddressID = Convert.ToInt32(IDBox.Text);

                address.ID = Convert.ToInt32(IDBox.Text);
                address.Street = StreetBox.Text;
                address.C_Index = Convert.ToInt32(IndexBox.Text);
                address.City = CityBox.Text;
                address.Home = HomeBox.Text;

                MessageBox.Show("Student added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            using (UniversityModel db = new UniversityModel())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Addresses.Add(address);
                        db.SaveChanges();

                        db.Students.Add(student);
                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            this.Close();
            MainWindow.mainWnd.ShowStudents(sender, e);
        }

        private async Task AddStudent()
        {
            Address address = new Address();
            Student student = new Student();
            try
            {
                student.Name = NameBox.Text;
                student.Surname = SurnameBox.Text;
                student.Patronymic = PatronymicBox.Text;
                student.Speciality = SpecialityBox.Text;
                student.Birthday = Convert.ToDateTime(BirthdayBox.Text);
                student.Course = Convert.ToInt32(CourseBox.Text);
                student.GroupNumber = Convert.ToInt32(GroupBox.Text);
                if (GenderBox.Text == "Male")
                {
                    student.Gender = "Male";
                }
                else if (GenderBox.Text == "Female")
                {
                    student.Gender = "Female";
                }
                student.PhoneNumber = PhoneBox.Text;
                student.ImageSrc = ImageBox.Text;

                student.AddressID = Convert.ToInt32(IDBox.Text);

                address.ID = Convert.ToInt32(IDBox.Text);
                address.Street = StreetBox.Text;
                address.C_Index = Convert.ToInt32(IndexBox.Text);
                address.City = CityBox.Text;
                address.Home = HomeBox.Text;

                MessageBox.Show("Student added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            using (UniversityModel db = new UniversityModel())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Addresses.Add(address);
                        await db.SaveChangesAsync();

                        db.Students.Add(student);
                        await db.SaveChangesAsync();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            this.Close();
        }
    }
}
