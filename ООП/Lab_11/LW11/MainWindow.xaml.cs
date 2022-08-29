using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace LW11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWnd;
        public MainWindow()
        {
            InitializeComponent();
            mainWnd = this;

            using (UniversityModel db = new UniversityModel())
            {
                var students = db.Students.Include("Address").ToList();

                dataTable.ItemsSource = students;
            }
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            AddStudentWnd addStudentWnd = new AddStudentWnd();
            addStudentWnd.Show();
        }

        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            Student student = new Student();
            student = (Student)dataTable.SelectedItem;
            address.ID = Convert.ToInt32(student.AddressID);
            //MessageBox.Show(student.AddressID.ToString());

            using (UniversityModel db = new UniversityModel())
            {
                List<Student> deleteStudent = db.Students.Where(s => s.StudentID == student.StudentID).ToList();
                List<Address> deleteAddress = db.Addresses.Where(a => a.ID == address.ID).ToList();

                db.Students.Remove(deleteStudent[0]);
                db.Addresses.Remove(deleteAddress[0]);
                db.SaveChanges();
                MessageBox.Show("Студент удален!");
            }

            ShowStudents(sender, e);
        }

        private void ChangeStudent(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student = (Student)dataTable.SelectedItem;

            using(UniversityModel db = new UniversityModel())
            {
                Student st = db.Students.Where(s => s.AddressID == student.AddressID).First();
                MessageBox.Show(st.ToString());
                st.Name = student.Name;
                st.Surname = student.Surname;
                st.Patronymic = student.Patronymic;
                st.Speciality = student.Speciality;
                st.Birthday = student.Birthday;
                st.Course = student.Course;
                st.GroupNumber = student.GroupNumber;
                st.Gender = student.Gender;
                st.PhoneNumber = student.PhoneNumber;
                st.ImageSrc = student.ImageSrc;
                st.Address.City = student.Address.City;
                st.Address.Street = student.Address.Street;
                st.Address.C_Index = student.Address.C_Index;
                st.Address.Home = student.Address.Home;
                db.SaveChanges();

                MessageBox.Show("Студент изменен!");
            }

            ShowStudents(sender, e);
        }

        public void ShowStudents(object sender, RoutedEventArgs e)
        {
            using (UniversityModel db = new UniversityModel())
            {
                var students = db.Students.Include("Address").ToList();
                MessageBox.Show(students[0].ToString());

                dataTable.ItemsSource = students;
            }
        }

        public void SearchChanged(object sender, RoutedEventArgs e)
        {
            Regex reg = new Regex(searchBox.Text);

            using(UniversityModel db = new UniversityModel())
            {
                var students = db.Students.Include("Address").ToList();
                List<Student> searched = new List<Student>();
                foreach (var student in students)
                {
                    if (reg.IsMatch(student.Surname))
                    {
                        searched.Add(student);
                    }
                }

                dataTable.ItemsSource = searched;
            }
        }
    }
}
