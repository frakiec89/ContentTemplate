using ContentTemplate.DB;
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

namespace ContentTemplate.MyForms
{
    /// <summary>
    /// Логика взаимодействия для StudentChangeWindow.xaml
    /// </summary>
    public partial class StudentChangeWindow : Window
    {

        public DB.Student Student { get; private set; } 

        public StudentChangeWindow(DB.Student student)
        {
            InitializeComponent();
            try
            {
                Student = student;
                Services.GroupService service = new Services.GroupService();
                cbGroups.ItemsSource = service.Groups();
                tbName.Text = Student.Name;
                tbImage.Text = Student.PathImage;
                tbSurName.Text = Student.SurName;
                cbGroups.SelectedItem = (cbGroups.ItemsSource as List<Group>).Find(x => x.GroupId == Student.GroupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                Services.StudentService service = new();

                Student.Name = tbName.Text;
                Student.PathImage = tbImage.Text;
                Student.SurName = tbSurName.Text;
                Student.GroupId = (cbGroups.SelectedItem as Group).GroupId;
                Student.Group = (cbGroups.SelectedItem as Group);
                service.UpdateStudent(Student);
                MessageBox.Show("Объект  обновлен, Обновите контент");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
