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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContentTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Services.StudentService studentService;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                studentService = new Services.StudentService();
                listBoxContent.ItemsSource = studentService.GetStudents();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void bthChange_Click(object sender, RoutedEventArgs e)
        {
           
            var b = e.OriginalSource as Button;
           var s = b.DataContext as Student;
            MessageBox.Show("Вы выбрали студента по  имени - " + s.Name);
        }

        private void addGroup_Click(object sender, RoutedEventArgs e)
        {
            MyForms.AddGroupWindow window = new MyForms.AddGroupWindow();
            window.Show();
        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            MyForms.AddSudentWindow window = new MyForms.AddSudentWindow();
            window.Show();
        }
    }
}
