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
    /// Логика взаимодействия для AddSudentWindow.xaml
    /// </summary>
    public partial class AddSudentWindow : Window
    {
        public AddSudentWindow()
        {
            InitializeComponent();
            try
            {
                Services.GroupService service = new Services.GroupService();
                cbGroups.ItemsSource = service.Groups();
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
                Services.StudentService student = new Services.StudentService();

                var dbStudent = new DB.Student();
                dbStudent.SurName = tbSurName.Text;
                dbStudent.Name = tbName.Text;
                dbStudent.IsStudent = true;
                dbStudent.PathImage = tbImage.Text;
                var idGr = (cbGroups.SelectedItem as DB.Group).GroupId;
                dbStudent.GroupId = idGr;
                student.AddStudent(dbStudent);

                MessageBox.Show("Студент добавлен в базу!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
